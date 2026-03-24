using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class paymentDistn002 : System.Web.UI.Page
{
    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2)
        {
            month = "0" + month;
        }
        if (day.Length < 2)
        {
            day = "0" + day;
        }

        ourDate = year + month + day;
        datetime[0] = ourDate;
        // return ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        // return y;
        return datetime;

    }

    private long polno;
    private string MOF;
    private double totamount;
    private string recipient;
    private string low;
    private string recipient02;
    private string low02;
    private double exgraciaAmt;

    private int heireNo;
    private string heire;
    private string heireName;
    private string heireAd;
    private int heireDOB;
    private double share;   //***********
    private double heireAmount;
    private string mst;

    private int sonCount;
    private int daughterCount;
//    private int marriedDaughterCount;
//    private int broSisCount;
//    private bool spouceLiveYN;
//    private bool motherLiveYN;
//    private bool fatherLiveYN;
    
    //***** for nominee *******
    private string NOMNAME;
    private int DOB;
    private string NIC;
    private double PER;
    private int NOMNUM;
    private int flag;

    private double totPercentage;

    private int payAutDate;

    private string EPF = "";
//    private int epfnum;

    DataManager dm;
    private  ArrayList arr;
    private  ArrayList arrList;
    private  bool assiPresent;
    private  bool LPTpresent;
    private long claimno;
    private int dtofdth;
    private int tbl;
    
    private ArrayList amtShareArray;

    protected void Page_Load(object sender, EventArgs e)
    {
        //EPF = Session["EPFNum"].ToString();

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
            recipient02 = this.PreviousPage.Recipient02;
            low02 = this.PreviousPage.Low02;
            totamount = this.PreviousPage.Totamount;
            exgraciaAmt = this.PreviousPage.ExgraciaAmt;
            flag = this.PreviousPage.Pageflag;
            claimno = this.PreviousPage.Claimno;
            dtofdth = this.PreviousPage.Dtofdth;
            tbl = this.PreviousPage.TBL;
        }

        //if (!Page.IsPostBack)
        //{
        if (Session["EPFNum"] != null || Session["brcode"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            Response.Redirect("SessionError.aspx", false);
        }
        
            try
            {
                dm = new DataManager();                

                //dm.begintransaction();

                #region ---------- view state -------------
                if (!Page.IsPostBack)
                {
                    ViewState["polno"] = polno;
                    ViewState["MOF"] = MOF;
                    ViewState["claimno"] = claimno;
                    ViewState["recipient"] = recipient;
                    ViewState["low"] = low;
                    ViewState["recipient02"] = recipient02;
                    ViewState["low02"] = low02;
                    ViewState["totamount"] = totamount;
                    ViewState["exgraciaAmt"] = exgraciaAmt;
                    ViewState["payAutDate"] = payAutDate;

                    ViewState["arr"] = arr;
                    ViewState["arrList"] = arrList;
                    ViewState["assiPresent"] = assiPresent;
                    ViewState["LPTpresent"] = LPTpresent;
                    ViewState["flag"] = flag;
                    ViewState["tbl"] = tbl;
                }
                else
                {
                    if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                    if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }

                    if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
                    if (ViewState["recipient"] != null) { recipient = ViewState["recipient"].ToString(); }
                    if (ViewState["recipient02"] != null) { recipient02 = ViewState["recipient02"].ToString(); }
                    if (ViewState["low"] != null) { low = ViewState["low"].ToString(); }
                    if (ViewState["low02"] != null) { low02 = ViewState["low02"].ToString(); }
                    if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                    if (ViewState["exgraciaAmt"] != null) { exgraciaAmt = double.Parse(ViewState["exgraciaAmt"].ToString()); }
                    if (ViewState["payAutDate"] != null) { payAutDate = int.Parse(ViewState["payAutDate"].ToString()); }

                    if (ViewState["arr"] != null) { arr = (ArrayList)ViewState["arr"]; }
                    if (ViewState["arrList"] != null) { arrList = (ArrayList)ViewState["arrList"]; }
                    if (ViewState["assiPresent"] != null) { assiPresent = (bool)ViewState["assiPresent"]; }
                    if (ViewState["LPTpresent"] != null) { LPTpresent = (bool)ViewState["LPTpresent"]; }
                    if (ViewState["flag"] != null) { flag = int.Parse(ViewState["flag"].ToString()); }
                    if (ViewState["tbl"] != null) { tbl = int.Parse(ViewState["tbl"].ToString()); }
                }
                #endregion

//                double spouceShare = 0;
//                double motherShare = 0;
//                double fatherShare = 0;
//                double sonShare = 0;
//                double marriedDuaShare = 0;
//                double unmarriedDauShare = 0;
//                double broSisShare = 0;

                string paystatus = "";
                int okcount = 0;
                int recCount = 0;
                            
                arr = new ArrayList();
                amtShareArray = new ArrayList();
                arrList = new ArrayList();

                string dthrefSel = "select PAYEE, PAYAUTDT, dlow from lphs.dthref where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                if (dm.existRecored(dthrefSel) != 0)
                {
                    dm.readSql(dthrefSel);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { recipient = dthrefReader.GetString(0); } else { recipient = ""; }
                        if (!dthrefReader.IsDBNull(1)) { payAutDate = dthrefReader.GetInt32(1); } else { payAutDate = 0; }
                        if (!dthrefReader.IsDBNull(2)) { low = dthrefReader.GetString(2); } else { low = ""; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();
                }

                if (!recipient.Equals(recipient02)) 
                {
                    this.lblalert.Text = "You Have not Confirmed the Selected Reciepient in Previous Page. Distribution Regards to the Previously Confirmed Payee.";
                }
                //else if ((recipient.Equals(recipient02)) && (recipient.Equals("LHI")) && (!low.Equals(low02))) 
                //{
                //    this.lblalert.Text = "You Have not Confirmed the Selected Low in Previous Page. Distribution Regards to the Previously Confirmed Low.";
                //}

                if ((recipient != null) && (!recipient.Equals("")))
                {

                    this.btnOK.Enabled = true;
                    //*************** Distributing According to Recipient *************

                    if (recipient.Equals("ML"))
                    {
                        #region
                        if (MOF.Equals("M"))
                        {
                            dm.connclose();
                            throw new Exception("Main Life Death Occured. Payments cannot be made to Main Life!");
                        }
                        if (!Page.IsPostBack)
                        {
                            string mlname = "", phadd = "";
                            string phnamesel = "select PNINT, PNSUR, PNAD1, PNAD2, PNAD3, PNAD4 from LPHS.PHNAME where PNPOL=" + polno + "";
                            if (dm.existRecored(phnamesel) != 0)
                            {
                                dm.readSql(phnamesel);
                                OracleDataReader phnamereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while (phnamereader.Read())
                                {
                                    if (!phnamereader.IsDBNull(0)) { mlname = phnamereader.GetString(0).Trim(); }
                                    if (!phnamereader.IsDBNull(1)) { mlname += phnamereader.GetString(1).Trim(); }
                                    if (!phnamereader.IsDBNull(5) && !phnamereader.IsDBNull(5).Equals("")) { phadd = phnamereader.GetString(5); }
                                    else if (!phnamereader.IsDBNull(4) && !phnamereader.IsDBNull(4).Equals("")) { phadd = phnamereader.GetString(4); }
                                    else if (!phnamereader.IsDBNull(3) && !phnamereader.IsDBNull(3).Equals("")) { phadd = phnamereader.GetString(3); }
                                    else if (!phnamereader.IsDBNull(2) && !phnamereader.IsDBNull(2).Equals("")) { phadd = phnamereader.GetString(2); }
                                    else if (!phnamereader.IsDBNull(1) && !phnamereader.IsDBNull(1).Equals("")) { phadd = phnamereader.GetString(1); }
                                }
                                phnamereader.Close();
                                phnamereader.Dispose();
                                this.MLinsert(mlname, phadd, "", "ML", dm);
                            }
                            else
                            {
                                dm.connclose();
                                throw new Exception("Main Life Details are not available!");
                            }
                        }
                        //createNomineeTable("Main Life", "100", 1, 1, totamount, "");
                        //ViewState["recipient"] = "LHI";
                        #endregion
                    }
                    if (recipient.Equals("SL"))
                    {
                        #region
                        if (MOF.Equals("2"))
                        {
                            dm.connclose();
                            throw new Exception("Second Life Death Occured. Cannot make payments to Second Life");
                        }
                        if (!Page.IsPostBack)
                        {
                            string isSecLifeChild = "";
                            int perTyp = 0;
                            string isSecondLife = "select is_child_second_life from LUND.TABNAM where tdtabl=" + tbl + "";
                            if (dm.existRecored(isSecondLife) != 0)
                            {
                                dm.readSql(isSecondLife);
                                OracleDataReader isseclifereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while (isseclifereader.Read())
                                {
                                    if (!isseclifereader.IsDBNull(0)) { isSecLifeChild = isseclifereader.GetString(0).Trim(); } else { isSecLifeChild = ""; }
                                }
                                isseclifereader.Close();
                            }
                            else
                            {
                                dm.connclose();
                                throw new Exception("No Table Details Found!");
                            }

                            if (isSecLifeChild == "Y")
                            {
                                perTyp = 4;
                            }
                            else
                            {
                                perTyp = 3;
                            }

                            string slname = "";
                            //string seclifenamsel = "select FULLNAME from LUND.POLPERSONAL where POLNO=" + polno + " and PRPERTYPE=4";
                            //string seclifenamsel = "select FULLNAME from LUND.POLPERSONAL where POLNO=" + polno + " and PRPERTYPE = 3"; 
                            string seclifenamsel = "select FULLNAME from LUND.POLPERSONAL where POLNO=" + polno + " and PRPERTYPE = " + perTyp + "";

                            if (dm.existRecored(seclifenamsel) != 0)
                            {
                                dm.readSql(seclifenamsel);
                                OracleDataReader seclifereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while (seclifereader.Read())
                                {
                                    if (!seclifereader.IsDBNull(0)) { slname = seclifereader.GetString(0).Trim(); } else { slname = ""; }
                                }
                                seclifereader.Close();
                                //seclifereader.Dispose();

                            }
                            else
                            {
                                dm.connclose();
                                throw new Exception("No Second Life Details Found!");
                            }
                            this.MLinsert(slname, "", "", "SL", dm);

                            #region-----------Residence-----------------
                            string region="";
                            string lhareasel = "select LHAD1 from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + MOF + "' and LHHNO=1";
                            if (dm.existRecored(lhareasel) != 0)
                            {
                                dm.readSql(lhareasel);
                                OracleDataReader lhareader=dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while(lhareader.Read())
                                {
                                    if (!lhareader.IsDBNull(0)) { region = lhareader.GetString(0); } else { region = ""; }
                                }
                                lhareader.Close();
                                lhareader.Dispose();
                            }
                            if (region.Equals(""))
                            {
                                lblReside.Visible = true;
                                txtReside.Visible = true;
                            }
                            #endregion
                        }
                        #endregion
                    }
                    if (recipient.Equals("LHI")||recipient.Equals("ML")||recipient.Equals("SL"))
                    {
                        double shareamt;
                        double totshare=0;
                        double percentage;
                        #region
                         string heireSelect = "select lhhno, lhhire, lhmst, lhname, lhad1, lhdob, LHPAYST, lhshare, lhamount from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "'  ";
                         if (dm.existRecored(heireSelect) != 0)
                         {
                             dm.readSql(heireSelect);
                             OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                             while (heireSelectReader.Read())
                             {
                                 string[] hireDet = new string[6];
                                 string[] shareArray = new string[8];

                                 heireNo = heireSelectReader.GetInt32(0);
                                 if (!heireSelectReader.IsDBNull(1)) { heire = heireSelectReader.GetString(1); } else { heire = ""; }
                                 if (!heireSelectReader.IsDBNull(2)) { mst = heireSelectReader.GetString(2); } else { mst = ""; }
                                 if (!heireSelectReader.IsDBNull(3)) { heireName = heireSelectReader.GetString(3); } else { heireName = ""; }
                                 if (!heireSelectReader.IsDBNull(4)) { heireAd = heireSelectReader.GetString(4); } else { heireAd = ""; }
                                 if (!heireSelectReader.IsDBNull(5)) { heireDOB = heireSelectReader.GetInt32(5); } else { heireDOB = 0; }
                                 if (!heireSelectReader.IsDBNull(6)) { paystatus = heireSelectReader.GetString(6); } else { paystatus = ""; }
                                 if (!heireSelectReader.IsDBNull(7)) { share = heireSelectReader.GetDouble(7); } else { share = 0; }
                                 if (!heireSelectReader.IsDBNull(8)) { heireAmount = heireSelectReader.GetDouble(8); } else { heireAmount = 0; }

                                 #region------newly added by Dushan------
                                 if (paystatus.Equals("OK")) { okcount++; }
                                 recCount++;
                                 totshare += share;
                                 shareamt = Math.Truncate(Math.Round(share * totamount * 100, 4)) / 100;
                                 percentage = share*100;

                                 string[] lhiArr = new string[6];
                                 lhiArr[0] = heire;
                                 lhiArr[1] = percentage.ToString();
                                 lhiArr[2] = recCount.ToString();
                                 lhiArr[3] = shareamt.ToString();
                                 lhiArr[4] = heireNo.ToString();
                                 lhiArr[5] = paystatus;

                                 arr.Add(lhiArr);

                                 //createNomineeTable(heire, percentage.ToString(), recCount, heireNo, Math.Round(shareamt, 2), paystatus);
                                 createNomineeTable(heire, percentage.ToString(), recCount, heireNo, shareamt, paystatus);
                                 
                                 #endregion
                                 
                                 #region---Commented as request of Life Dept-------
                                 /*
                                 #region //------ creating amount array ------

                                 if (heireAmount > 0)
                                 {
                                     if (heire.Equals("Son"))
                                     {
                                         shareArray[0] = "Son";
                                     }
                                     else if (heire.Equals("Daughter"))
                                     {
                                         if (mst.Equals("M"))
                                         {
                                             shareArray[0] = "Married_Daughter";
                                         }
                                         else 
                                         {
                                             shareArray[0] = "Unmarried_Daughter";
                                         }
                                     }
                                     else if ((heire.Equals("Brother")) || (heire.Equals("Sister")))
                                     {
                                         shareArray[0] = "Brother_Sister";
                                     }
                                     else if (heire.Equals("Spouce"))
                                     {
                                         shareArray[0] = "Spouce";                                    
                                     }
                                     else if (heire.Equals("Mother"))
                                     {
                                         shareArray[0] = "Mother";
                                     }
                                     else if (heire.Equals("Father"))
                                     {
                                         shareArray[0] = "Father";
                                     }

                                     shareArray[1] = heireName;
                                     shareArray[2] = heireAd;
                                     shareArray[3] = heireDOB.ToString();
                                     shareArray[4] = heireNo.ToString();
                                     shareArray[5] = paystatus;
                                     shareArray[6] = share.ToString();
                                     shareArray[7] = heireAmount.ToString();

                                     amtShareArray.Add(shareArray);
                                 }

                                 #endregion                           

                                 if (paystatus.Equals("OK")) { okcount++; }
                                 if ((paystatus.Equals("OK")) || ((paystatus.Equals("PN")))) { recCount++; }

                                 

                                 //*****************************************************************************

                                 #region //-------- creating share algorithm array ----

                                 if (heire.Equals("Son"))
                                 {
                                     hireDet[0] = "Son";
                                     sonCount++;
                                 }
                                 else if (heire.Equals("Daughter"))
                                 {
                                     if (mst.Equals("M"))
                                     {
                                         hireDet[0] = "Married_Daughter";
                                         marriedDaughterCount++;
                                     }
                                     else
                                     {
                                         hireDet[0] = "Unmarried_Daughter";
                                     }
                                     daughterCount++;
                                 }
                                 else if ((heire.Equals("Brother")) || (heire.Equals("Sister")))
                                 {
                                     hireDet[0] = "Brother_Sister";
                                     broSisCount++;
                                 }
                                 else if (heire.Equals("Spouce"))
                                 {
                                     hireDet[0] = "Spouce";
                                     spouceLiveYN = true;
                                 }
                                 else if (heire.Equals("Mother"))
                                 {
                                     hireDet[0] = "Mother";
                                     motherLiveYN = true;
                                 }
                                 else if (heire.Equals("Father"))
                                 {
                                     hireDet[0] = "Father";
                                     fatherLiveYN = true;
                                 }
                                 else { hireDet[0] = heire; }

                                 //----------------------------------
                                 hireDet[1] = heireName;
                                 hireDet[2] = heireAd;
                                 hireDet[3] = heireDOB.ToString();
                                 hireDet[4] = heireNo.ToString();
                                 hireDet[5] = paystatus;

                                 arr.Add(hireDet);

                                 #endregion

                             }
                             heireSelectReader.Close();

                             double[] heireShare = this.shareAlgorithm(low, motherLiveYN, fatherLiveYN, spouceLiveYN, broSisCount, sonCount, daughterCount, marriedDaughterCount);
                             spouceShare = heireShare[0];
                             motherShare = heireShare[1];
                             fatherShare = heireShare[2];
                             sonShare = heireShare[3];
                             marriedDuaShare = heireShare[4];
                             unmarriedDauShare = heireShare[5];
                             broSisShare = heireShare[6];

                             int count = 0;
                             bool flag = false;

                             if (amtShareArray.Count == 0)
                             {

                                 #region //------ creating share table -----

                                 foreach (string[] hd in arr)
                                 {
                                     string heirestr = "";
                                     string heire_name = "";
                                     string heire_ad = "";
                                     string heire_DOB = "";
                                     double theShare = 0;
                                     double amt = 0;

                                     if (count == 0) { createShareTable(heirestr, heire_name, theShare, amt, count, paystatus); }

                                     count++;

                                     if (!hd[0].Equals(null) && !hd[0].Equals("")) { heirestr = hd[0]; }
                                     if (!hd[1].Equals(null) && !hd[1].Equals("")) { heire_name = hd[1]; }
                                     if (!hd[2].Equals(null) && !hd[2].Equals("")) { heire_ad = hd[2]; }
                                     if (!hd[3].Equals(null) && !hd[3].Equals("")) { heire_DOB = hd[3]; }
                                     if (!hd[5].Equals(null) && !hd[5].Equals("")) { paystatus = hd[5]; }

                                     if (heirestr.Equals("Son")) { theShare = sonShare; amt = totamount * theShare; }
                                     else if (heirestr.Equals("Married_Daughter")) { theShare = marriedDuaShare; amt = totamount * theShare; }
                                     else if (heirestr.Equals("Unmarried_Daughter")) { theShare = unmarriedDauShare; amt = totamount * theShare; }
                                     else if (heirestr.Equals("Brother_Sister")) { theShare = broSisShare; amt = totamount * theShare; }
                                     else if (heirestr.Equals("Spouce")) { theShare = spouceShare; amt = totamount * theShare; }
                                     else if (heirestr.Equals("Mother")) { theShare = motherShare; amt = totamount * theShare; }
                                     else if (heirestr.Equals("Father")) { theShare = fatherShare; amt = totamount * theShare; }
                                     else { }

                                     //------- this if condition can be removed if the user should have to be allowed to 
                                     //------- enter percentages for non recipient heires !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                                     if (theShare > 0)
                                     {
                                         createShareTable(heirestr, heire_name, theShare, amt, count, paystatus);
                                         flag = true;
                                     }
                                 }
                                 if (!flag)
                                 {
                                     this.createEmptyTable(arr, heireShare);
                                 }

                                 #endregion
                             }
                             else
                             {
                                 #region ------- Creating amount table ------

                                 int count2 = 0;
                                 foreach (string[] amtstrArr in amtShareArray)
                                 {
                                     string heirestr = "";
                                     string heire_name = "";                                   
                                     double theShare = 0;
                                     double amt = 0;

                                     if (count2 == 0) { createShareTable(heirestr, heire_name, theShare, amt, count2, paystatus); }
                                     count2++;

                                     if (!amtstrArr[0].Equals(null) && !amtstrArr[0].Equals("")) { heirestr = amtstrArr[0]; }
                                     if (!amtstrArr[1].Equals(null) && !amtstrArr[1].Equals("")) { heire_name = amtstrArr[1]; }                                                                         if (!amtstrArr[5].Equals(null) && !amtstrArr[5].Equals("")) { paystatus = amtstrArr[5]; }
                                     if (!amtstrArr[5].Equals(null) && !amtstrArr[5].Equals("")) { paystatus = amtstrArr[5]; }
                                     if (!amtstrArr[6].Equals(null) && !amtstrArr[6].Equals("")) { theShare = double.Parse(amtstrArr[6]); }
                                     if (!amtstrArr[7].Equals(null) && !amtstrArr[7].Equals("")) { amt = double.Parse(amtstrArr[7]); }
                                     
                                     createShareTable(heirestr, heire_name, theShare, amt, count2, paystatus);
                                 }

                                 #endregion//*/
                                 #endregion
                             }
                             heireSelectReader.Close();
                             heireSelectReader.Dispose();
                             //if (totshare < 1 && 1-totshare>0.1)
                             if (totshare < 1 && 1 - totshare > 0.01)
                             {
                                 this.cmdPayee.Visible = true;
                             }
                         }
                         else
                         {
                             dm.connclose();
                             throw new Exception("No Heire Details!");
                         }
                        #endregion
                    }
                    else if (recipient.Equals("ASI"))
                    {
                        #region

                        string ASS_STATUS = "";
                        string ASS_INITIAL = "";
                        string ASS_SURNAME = "";
                        string ASS_FULLNAME = "";
                        string ASS_SHORTNAME = "";
                        string ASS_AD1 = "";
                        string ASS_AD2 = "", ASS_AD3="";
                        long ACCT_NO = 0;
                        int rowNum = 0;

                        string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, PAYSTATUS, ASS_AD3 from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
                        if (dm.existRecored(asiSelect) != 0)
                        {
                            assiPresent = true;
                            dm.readSql(asiSelect);
                            OracleDataReader prassReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (prassReader.Read())
                            {
                                rowNum++;
                                if (!prassReader.IsDBNull(0)) { ASS_STATUS = prassReader.GetString(0); } else { ASS_STATUS = ""; }
                                if (!prassReader.IsDBNull(1)) { ASS_INITIAL = prassReader.GetString(1); } else { ASS_INITIAL = ""; }
                                if (!prassReader.IsDBNull(2)) { ASS_SURNAME = prassReader.GetString(2); } else { ASS_SURNAME = ""; }
                                if (!prassReader.IsDBNull(3)) { ASS_FULLNAME = prassReader.GetString(3); } else { ASS_FULLNAME = ""; }
                                if (!prassReader.IsDBNull(4)) { ASS_SHORTNAME = prassReader.GetString(4); } else { ASS_SHORTNAME = ""; }
                                if (!prassReader.IsDBNull(5)) { ASS_AD1 = prassReader.GetString(5); } else { ASS_AD1 = ""; }
                                if (!prassReader.IsDBNull(6)) { ASS_AD2 = prassReader.GetString(6); } else { ASS_AD2 = ""; }
                                if (!prassReader.IsDBNull(7)) { ACCT_NO = prassReader.GetInt64(7); } else { ACCT_NO = 0; }
                                if (!prassReader.IsDBNull(8)) { paystatus = prassReader.GetString(8); } else { paystatus = ""; }
                                if (!prassReader.IsDBNull(9)) { ASS_AD3 = prassReader.GetString(9); } else { ASS_AD3 = ""; }

                                if (paystatus.Equals("OK")) { okcount++; }
                                recCount++;
                                string name01 = ASS_STATUS + " " + ASS_FULLNAME;
                                string addre = ASS_AD1 + " " + ASS_AD2;

                                this.createASItable(name01, ASS_FULLNAME, ASS_SHORTNAME, addre, ACCT_NO.ToString(), rowNum, paystatus);
                            }
                            prassReader.Close();
                            prassReader.Dispose();

                        }

                        #endregion
                    }
                    else if (recipient.Equals("NOM"))
                    {
                        #region

                        double nomiShare = 0;
                        string nomSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER, PAYSTATUS from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                        if (dm.existRecored(nomSelect) != 0)
                        {                           
                            dm.readSql(nomSelect);
                            OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); } else { NOMNAME = ""; }
                                if (!nomineeReader.IsDBNull(2)) { DOB = nomineeReader.GetInt32(2); } else { DOB = 0; }
                                if (!nomineeReader.IsDBNull(3)) { NIC = nomineeReader.GetString(3); } else { NIC = ""; }
                                if (!nomineeReader.IsDBNull(4)) { PER = nomineeReader.GetDouble(4); } else { PER = 0.00; }
                                if (!nomineeReader.IsDBNull(5)) { paystatus = nomineeReader.GetString(5); } else { paystatus = ""; }
                                NOMNUM = nomineeReader.GetInt32(0);

                                if (paystatus.Equals("OK")) { okcount++; }
                                recCount++;
                                totPercentage += PER;
                                
                                nomiShare = PER * totamount;
                                nomiShare = Math.Round(nomiShare, 4);
                                nomiShare = Math.Truncate(nomiShare);
                                nomiShare = nomiShare / 100;
                                string[] nomArr = new string[7];
                                nomArr[0] = NOMNAME;
                                nomArr[1] = DOB.ToString();
                                nomArr[2] = NIC;
                                nomArr[3] = PER.ToString();
                                nomArr[4] = NOMNUM.ToString();
                                nomArr[5] = nomiShare.ToString();
                                nomArr[6] = paystatus;

                                arrList.Add(nomArr);
                                //createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM);
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();

                            if (totPercentage > 100)
                            {
                                dm.connclose();
                                throw new Exception("Please Adjust the Nominee Percentages so that Total Equals 100%");
                            }
                            else if (totPercentage < 100) { this.lblalert.Text = "Total Percentage doesn't Add Up to Make 100%"; }

                            int rows3 = 0;
                            foreach (string[] nomArr in arrList)
                            {
                                rows3++;

                                if (!nomArr[0].Equals(null) && !nomArr[0].Equals("")) { NOMNAME = nomArr[0]; }
                                if (!nomArr[1].Equals(null) && !nomArr[1].Equals("")) { DOB = int.Parse(nomArr[1]); }
                                if (!nomArr[2].Equals(null) && !nomArr[2].Equals("")) { NIC = nomArr[2]; }
                                if (!nomArr[3].Equals(null) && !nomArr[3].Equals("")) { PER = double.Parse(nomArr[3]); }
                                if (!nomArr[4].Equals(null) && !nomArr[4].Equals("")) { NOMNUM = int.Parse(nomArr[4]); }
                                if (!nomArr[5].Equals(null) && !nomArr[5].Equals("")) { nomiShare = double.Parse(nomArr[5]); }
                                if (!nomArr[6].Equals(null) && !nomArr[6].Equals("")) { paystatus = nomArr[6]; }

                                createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM, nomiShare, paystatus);
                            }
                        }
                        else
                        {

                        }

                        #endregion
                    }
                    else if (recipient.Equals("LPT"))
                    {
                        #region
                        string NOMAD1 = "";
                        string NOMAD2 = "";
                        int incr = 0;

                        string living_prtSelect = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, PAYSTATUS from LUND.LIVING_PRT where polno = " + polno + "  ";
                        if (dm.existRecored(living_prtSelect) != 0)
                        {
                            LPTpresent = true;
                            dm.readSql(living_prtSelect);
                            OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                incr++;
                                if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); }
                                if (!nomineeReader.IsDBNull(1)) { DOB = nomineeReader.GetInt32(1); }
                                if (!nomineeReader.IsDBNull(2)) { NIC = nomineeReader.GetString(2); }
                                if (!nomineeReader.IsDBNull(3)) { PER = nomineeReader.GetInt32(3); }
                                if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); }
                                if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); }
                                if (!nomineeReader.IsDBNull(6)) { paystatus = nomineeReader.GetString(6); }

                                if (paystatus.Equals("OK")) { okcount++; }
                                recCount++;
                                string addr = NOMAD1 + " " + NOMAD2;

                                this.createLPTtable(NOMNAME, NIC, DOB, addr, incr, paystatus);

                            } 
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                        }

                        #endregion
                    }
                    
                }
                else { this.btnOK.Enabled = false; this.lblReside.Visible = false; this.txtReside.Visible = false; }

                if ((recCount > 0) && (recCount == okcount)) { this.btnOK.Enabled = false; this.lblReside.Visible = false; this.txtReside.Visible = false; }
                else { this.btnOK.Enabled = true; }
                //dm.commit();
                dm.connclose();
            }
            catch (Exception ex)
            {
                //dm.rollback();
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }           
        }
    
    protected double [] shareAlgorithm(string correspondingLaw, bool moLive, bool faLive, bool spouceLive, int brosisCount, int soncount, int daughtercount, int marriedDaughterCount) {

        double[] arr = new double[7];

        double spouceShare = 0;
        double motherShare = 0;
        double fatherShare = 0;
        double sonShare = 0;
        double marriedDuaShare = 0;
        double unmarriedDauShare = 0;
        double broSisShare = 0;
        
        //  arr [0] = spouse share
        //  arr [1] = mother share
        //  arr [2] = father share
        //  arr [3] = son share
        //  arr [4] = maried daughter share
        //  arr [5] = unmarried daughter share
        //  arr [6] = bro/sis share
        
        if (correspondingLaw.Equals("General"))
        {
            if (spouceLive)
            {
                spouceShare = 0.5;
                if ((sonCount + daughterCount) > 0) { sonShare = 0.5 / (sonCount + daughterCount); }
                else { sonShare = 0; }
                marriedDuaShare = sonShare;
                unmarriedDauShare = sonShare;
                if (sonShare <= 0) { spouceShare = 1.0; }
            }
            else if ((sonCount > 0) || (daughterCount > 0))
            {
                sonShare = 1.0 / (sonCount + daughterCount);
                marriedDuaShare = sonShare;
                unmarriedDauShare = sonShare;
            }
            else if (moLive && faLive) 
            {
                motherShare = 0.5;
                fatherShare = 0.5;
            }
            else if (moLive || faLive) 
            {
                if (moLive) 
                {
                    motherShare = 0.5;
                    broSisShare = 0.5 / brosisCount;
                }
                else if (faLive) 
                {
                    fatherShare = 0.5;
                    broSisShare = 0.5 / brosisCount;
                }
            }
            else { broSisShare = 1.0 / brosisCount; }
         
        }
        else if (correspondingLaw.Equals("Upcountry"))
        {
            if (spouceLive)
            {
                spouceShare = 1.0 / (sonCount + daughterCount + 1);
                sonShare = spouceShare;
                marriedDuaShare = spouceShare;
                unmarriedDauShare = spouceShare;
            }
            else if ((sonCount > 0) || (daughterCount > 0))
            {
                sonShare = 1.0 / (sonCount + daughterCount);
                marriedDuaShare = sonShare;
                unmarriedDauShare = sonShare;
            }
            else if (moLive && faLive)
            {
                motherShare = 0.5;
                fatherShare = 0.5;
            }
            else if (moLive || faLive)
            {
                if (moLive)
                {
                    motherShare = 0.5;
                    broSisShare = 0.5 / brosisCount;
                }
                else if (faLive)
                {
                    fatherShare = 0.5;
                    broSisShare = 0.5 / brosisCount;
                }
            }
            else { broSisShare = 1.0 / brosisCount; }
        }
        //else if (correspondingLaw.Equals("Moore"))
        //{
            
        //}
        else if (correspondingLaw.Equals("Thesawalaamei"))
        {
            int unmarriedDauCount = daughtercount - marriedDaughterCount;

            if (spouceLive)
            {
                spouceShare = 0.5;
                if ((sonCount + unmarriedDauCount) > 0) { sonShare = 0.5 / (sonCount + unmarriedDauCount); }
                else { sonShare = 0; }
                unmarriedDauShare = sonShare;
                if (sonShare <= 0) { spouceShare = 1.0; }
            }
            else if ((sonCount > 0) || (daughterCount > 0))
            {
                sonShare = 1.0 / (sonCount + unmarriedDauCount);
                unmarriedDauShare = sonShare;
            }
            else if (moLive && faLive)
            {
                motherShare = 0.5;
                fatherShare = 0.5;
            }
            else if (moLive || faLive)
            {
                if (moLive)
                {
                    motherShare = 0.5;
                    broSisShare = 0.5 / brosisCount;
                }
                else if (faLive)
                {
                    fatherShare = 0.5;
                    broSisShare = 0.5 / brosisCount;
                }
            }
            else { broSisShare = 1.0 / brosisCount; }
           
        }
        //else if (correspondingLaw.Equals("Payment_To_Court"))
        //{

        //}
        //else if (correspondingLaw.Equals("Pay_To_Individual"))
        //{ 
                
        //}
        else { }

            arr[0] = spouceShare;
            arr[1] = motherShare;
            arr[2] = fatherShare;
            arr[3] = sonShare;
            arr[4] = marriedDuaShare;
            arr[5] = unmarriedDauShare;
            arr[6] = broSisShare;
        
        return arr;
     
    }

    protected void createShareTable(string relation, string name, double share, double amount, int count, string payst) {
        
        TableRow trow = new TableRow();
        TableRow trow2 = new TableRow();

        TableCell tcel01 = new TableCell();
        tcel01.Style["text-align"] = "Center";
        TableCell tcel02 = new TableCell();
        TableCell tcel03 = new TableCell();
        TableCell tcel04 = new TableCell();
        TableCell tcel05 = new TableCell();

        Label lbl01 = new Label();
        Label lbl02 = new Label();
        TextBox txt01 = new TextBox();
        TextBox txt02 = new TextBox();
        CheckBox chk01 = new CheckBox();

        lbl01.ID = "relation" + count;
        lbl01.Attributes.Add("runat", "Server");
        lbl01.Attributes.Add("Name", "relation" + count); //Text Value
        if ((count == 0)) { lbl01.Text = "Relationship"; lbl01.Font.Bold = true; }
        else { lbl01.Text = relation; }

        lbl02.ID = "name" + count;
        lbl02.Attributes.Add("runat", "Server");
        lbl02.Attributes.Add("Name", "name" + count); //Text Value
        lbl02.Style["text-align"] = "Center";
        if (count == 0) { lbl02.Text = "Name"; lbl02.Font.Bold = true; tcel02.Style["text-align"] = "Center"; }
        else { lbl02.Text = name; }       

        txt01.MaxLength = 4;
        txt01.ID = "txtShare" + count;
        txt01.Attributes.Add("runat", "Server");
        txt01.Attributes.Add("Name", "txtShare" + count);
        if (count == 0) { txt01.Text = "Share"; txt01.Font.Bold = true; txt01.Style["text-align"] = "Center"; }
        else { txt01.Text = String.Format("{0:N}", share); txt01.Style["text-align"] = "Center"; }
        if (payst.Equals("OK")) { txt01.ReadOnly = true; }
        else { txt01.ReadOnly = true; }

        txt02.MaxLength = 12;
        txt02.ID = "txtAmt" + count;
        txt02.Attributes.Add("runat", "Server");
        txt02.Attributes.Add("Name", "txtAmt" + count);
        if (count == 0) { txt02.Text = "Amount"; txt02.Font.Bold = true; txt02.Style["text-align"] = "Center"; }
        else { txt02.Text = String.Format("{0:N}", amount); txt02.Style["text-align"] = "Right"; }
        if (payst.Equals("OK")) { txt02.ReadOnly = true; }
        else { txt02.ReadOnly = true; }

        chk01.ID = "chk" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + count);
        if (count == 0) { chk01.Visible = false; }
        if (payst.Equals("OK")) {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        tcel01.Controls.Add(lbl01);
        tcel02.Controls.Add(lbl02);
        tcel03.Controls.Add(txt01);
        tcel04.Controls.Add(txt02);
        tcel05.Controls.Add(chk01);

        trow.Cells.Add(tcel01);
        trow.Cells.Add(tcel02);
        trow.Cells.Add(tcel03);
        trow.Cells.Add(tcel04);
        trow.Cells.Add(tcel05);

        this.Table1.Rows.Add(trow);

    }

    protected void createEmptyTable(ArrayList heireList, double [] heireShare)
    {
       double spouceShare = heireShare[0];
       double motherShare = heireShare[1];
       double fatherShare = heireShare[2];
       double sonShare = heireShare[3];
       double marriedDuaShare = heireShare[4];
       double unmarriedDauShare = heireShare[5];
       double broSisShare = heireShare[6];

        int count = 0;
        foreach (string[] hd in heireList)
        {
            string heirestr = "";
            string heire_name = "";
            string heire_ad = "";
            string heire_DOB = "";
            double theShare = 0;
            double amt = 0;
            string payst = "";

            count++;
            if (!hd[0].Equals(null) && !hd[0].Equals("")) { heirestr = hd[0]; }
            if (!hd[1].Equals(null) && !hd[1].Equals("")) { heire_name = hd[1]; }
            if (!hd[2].Equals(null) && !hd[2].Equals("")) { heire_ad = hd[2]; }
            if (!hd[3].Equals(null) && !hd[3].Equals("")) { heire_DOB = hd[3]; }
            if (!hd[5].Equals(null) && !hd[5].Equals("")) { payst = hd[5]; }

            if (heirestr.Equals("Son")) { theShare = sonShare; amt = totamount * theShare; }
            else if (heirestr.Equals("Married_Daughter")) { theShare = marriedDuaShare; amt = totamount * theShare; }
            else if (heirestr.Equals("Unmarried_Daughter")) { theShare = unmarriedDauShare; amt = totamount * theShare; }
            else if (heirestr.Equals("Brother_Sister")) { theShare = broSisShare; amt = totamount * theShare; }
            else if (heirestr.Equals("Spouce")) { theShare = spouceShare; amt = totamount * theShare; }
            else if (heirestr.Equals("Mother")) { theShare = motherShare; amt = totamount * theShare; }
            else if (heirestr.Equals("Father")) { theShare = fatherShare; amt = totamount * theShare; }
            else { }

            createShareTable(heirestr, heire_name, theShare, amt, count,payst);
            
            
        }
    
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        //dm.begintransaction();
        int i = 0;
        string payst = "";
        double totPerce = 0;
        double totamt = 0;
        try
        {
            //*************** if payment is not yet completed **********************************************

            //if (payAutDate == 0)
            //{
                if (arr.Count > 0)
                {
                    #region
                    foreach (string[] hda in arr)
                    {
                        i++;
                        heireNo = int.Parse(hda[4]);

                        string heireShareStr = "txtShare" + i;
                        string shareAmtStr = "txtAmt" + i;
                        string chk = "chk" + i;                       

                        TextBox txtShare = (TextBox)Table1.FindControl(heireShareStr);
                        TextBox txtShareAmt = (TextBox)Table1.FindControl(shareAmtStr);
                        CheckBox chkpaymentok = (CheckBox)Table1.FindControl(chk);

                        double sharePercentage = 0;
                        double shareAmount = 0;

                        if (recipient.Equals("LHI"))
                        {
                            sharePercentage = (double.Parse(hda[1]))/100;
                            shareAmount = double.Parse(hda[3]);
                        }
                        else if (recipient.Equals("ML")||recipient.Equals("SL"))
                        {
                            sharePercentage = 1;
                            shareAmount = totamount;
                        }
                        else
                        {
                            if (!(txtShare == null)) { sharePercentage = double.Parse(txtShare.Text.ToString())/100; }
                            if (!(txtShare == null)) { shareAmount = double.Parse(txtShareAmt.Text.ToString())/100; }
                        }
                        //shareAmount = Math.Truncate(Math.Round(shareAmount * 100, 4)) / 100;
                            //------ 20070328 -------------------
                        if (((totamount * sharePercentage) != shareAmount) && (((totamount * sharePercentage) - shareAmount >= 5) || ((totamount * sharePercentage) - shareAmount < 5)))
                        { this.cv.IsValid = false; this.cv.Text = "Percentage Doesn't Match With Amount."; }

                        if ((chkpaymentok != null) && (chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "OK"; }
                        else if ((chkpaymentok != null) && (!chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "PN"; }
                        else if ((chkpaymentok != null) && (!chkpaymentok.Enabled)) { payst = "OK"; }
                        else { payst = "NO"; }
                        totPerce += sharePercentage;
                        totamt += shareAmount;
                        //------- legal hire update -------------

                        string legalHieireUpdate = "UPDATE LPHS.LEGAL_HIRES SET LHSHARE = " + sharePercentage + " , LHAMOUNT = " + shareAmount + ","+
                            "LHPAYST = '" + payst + "', PAYAUTDATE = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '"+EPF+"' WHERE lhpolno=" + polno + " and lhmof='" + MOF + "' and lhhno=" + heireNo + " ";
                        dm.insertRecords(legalHieireUpdate);

                        ////------- dthref update -----------------

                        //string dthrefUpd = "UPDATE LPHS.DTHREF SET DLOW = '" + low + "' WHERE drpolno=" + polno + " and drmos='" + MOF + "' ";
                        //dm.insertRecords(dthrefUpd);

                    }
                                            if (totPerce > 1)
                                            { 
                                                this.cv.IsValid = false;
                                                this.cv.Text = "Total Percentage Exceeds 100!";
                                            }
                                            else if (totamt > totamount)
                                            {
                                                this.cv.IsValid = false;
                                                this.cv.Text = "Total Amount Exceeds Total Claim!";
                                            }
                                            else { }

                    string dthrefUp = "update lphs.dthref set DISTN_AUT =" + arr.Count + ", DISTN_AUTDATE = " + int.Parse(this.setDate()[0]) + ", DISTN_AUTEPF = '" + EPF + "' where drpolno = " + polno + " and drmos = '" + MOF + "'  ";
                    dm.insertRecords(dthrefUp);

                    #endregion                                   
                }
                else if (arrList.Count > 0)
                {
                    #region
                    foreach (string[] strArr in arrList) 
                    {
                        i++;
                        NOMNUM = int.Parse(strArr[4]);
                        string chk = "chk" + i;

                        CheckBox chkpaymentok = (CheckBox)Table1.FindControl(chk);
                        if ((chkpaymentok != null) && (chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "OK"; }
                        else if ((chkpaymentok != null) && (!chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "PN"; }
                        else if ((chkpaymentok != null) && (!chkpaymentok.Enabled)) { payst = "OK"; }
                        else { payst = "NO"; }
                        //------- NOMINEE update -------------

                        string nomUpdate = "UPDATE LUND.NOMINEE SET PAYSTATUS = '" + payst + "', PAYAUTDATE = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '" + EPF + "' WHERE POLNO = " + polno + " and NOMNO = " + NOMNUM + " ";
                        dm.insertRecords(nomUpdate);
                    }

                    string dthrefUp = "update lphs.dthref set DISTN_AUT =" + arrList.Count + ", DISTN_AUTDATE = " + int.Parse(this.setDate()[0]) + ", DISTN_AUTEPF = '" + EPF + "' where drpolno = " + polno + " and drmos = '" + MOF + "'  ";
                    dm.insertRecords(dthrefUp);

                    #endregion
                }
                else if (assiPresent)
                {
                    #region
                    CheckBox chkpaymentok = (CheckBox)Table1.FindControl("chk01");
                    if ((chkpaymentok != null) && (chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "OK"; }
                    else if ((chkpaymentok != null) && (!chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "PN"; }
                    else if ((chkpaymentok != null) && (!chkpaymentok.Enabled)) { payst = "OK"; }
                    else { payst = "NO"; }
                    //------- ASSIGNEE update -------------
                    string ASIUpd = "UPDATE LUND.ASSIGNEE SET PAYSTATUS = '" + payst + "', PAYAUTDATE = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '" + EPF + "' WHERE POLICY_NO = " + polno + " ";
                    dm.insertRecords(ASIUpd);

                    string dthrefUp = "update lphs.dthref set DISTN_AUT = 1, DISTN_AUTDATE = " + int.Parse(this.setDate()[0]) + ", DISTN_AUTEPF = '" + EPF + "' where drpolno = " + polno + " and drmos = '" + MOF + "'  ";
                    dm.insertRecords(dthrefUp);

                    #endregion
                }
                else if (LPTpresent)
                {
                    #region
                    CheckBox chkpaymentok = (CheckBox)Table1.FindControl("chk01");
                    if ((chkpaymentok != null) && (chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "OK"; }
                    else if ((chkpaymentok != null) && (!chkpaymentok.Checked) && (chkpaymentok.Enabled)) { payst = "PN"; }
                    else if ((chkpaymentok != null) && (!chkpaymentok.Enabled)) { payst = "OK"; }
                    else { payst = "NO"; }
                    //------- LIVING_PRT update -------------
                    string LIVING_PRTupd = "UPDATE LUND.LIVING_PRT SET PAYSTATUS = '" + payst + "', PAYAUTDATE = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '" + EPF + "' WHERE POLNO = " + polno + " ";
                    dm.insertRecords(LIVING_PRTupd);

                    string dthrefUp = "update lphs.dthref set DISTN_AUT = 1, DISTN_AUTDATE = " + int.Parse(this.setDate()[0]) + ", DISTN_AUTEPF = '" + EPF + "' where drpolno = " + polno + " and drmos = '" + MOF + "'  ";
                    dm.insertRecords(dthrefUp);

                    #endregion
                }
                if (recipient.Equals("SL"))
                {
                    string reside = this.txtReside.Text;
                    string slselect = "select * from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + MOF + "' and LHHNO=1 and LHHIRE='Second Life'";
                    if (dm.existRecored(slselect) != 0)
                    {
                        string updatesl = "update LPHS.LEGAL_HIRES set LHAD1='"+reside+"' where LHPOLNO=" + polno + " and LHMOF='" + MOF + "' and LHHNO=1 and LHHIRE='Second Life'";
                        dm.insertRecords(updatesl);
                    }
                }

                //********** code to confirm the payment in DTHREF *************??????????????????
                //********** COMMENTED ***********************************************************
                //string dthpayconf = "UPDATE LPHS.DTHREF SET  PAYAUTDT = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '" + EPF + "' ";
                //dm.insertRecords(dthpayconf);

                arr.Clear();
                arrList.Clear();
                //dm.commit();
                dm.connclose();
                this.lblsuccess.Visible = true;
                this.lblsuccess.Text = "Record Successfully Updated";
                this.btnOK.Enabled = false;
            //}
            //else 
            //{
            //    this.cv.IsValid = false;
            //    this.cv.Text = "Payment Completed. Cannot Alter!";
            //}
            this.btnOK.Enabled = false;
        }
        catch (Exception ex) {
            //dm.rollback(); 
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
         
        dm.connclose();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (flag == 1)
        {
            Response.Redirect("RepudiatePay003.aspx?polno=" + polno.ToString() + "&mos=" + MOF + "&clmno="+claimno+"");
        }
        else
        {
            Response.Redirect("dthPay002.aspx?polno=" + polno.ToString() + "&mos=" + MOF + "");
        }
    }

    private void createNomineeTable(string nominee, string percentage, int rowNumber, int nomnum, double theShare, string payst)
    {
        TableRow trow = new TableRow();
        TableCell tcell0 = new TableCell();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        Label lbl0 = new Label();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        CheckBox chk01 = new CheckBox();

        lbl0.ID = "nomnum" + rowNumber;
        lbl0.Attributes.Add("runat", "Server");
        lbl0.Attributes.Add("Name", "nomnum" + rowNumber); //Text Value
        lbl0.Text = nomnum.ToString();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "percentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
        lbl2.Text = percentage + "%";

        lbl3.ID = "theShare" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "theShare" + rowNumber); //Text Value
        lbl3.Text = String.Format("{0:N}", theShare);

        chk01.ID = "chk" + rowNumber;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + rowNumber); //Text Value      
        if (payst.Equals("OK")) { 
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }
        tcell0.Controls.Add(lbl0);
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(chk01);

        trow.Cells.Add(tcell0);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);
        trow.Cells.Add(tcell4);

        Table1.Rows.Add(trow);
    }

    private void createLPTtable(string name, string nic, int dob, string ad, int count, string payst)
    {
        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel21 = new TableCell();
        TableCell tcel22 = new TableCell();
        TableCell tcel31 = new TableCell();
        TableCell tcel32 = new TableCell();
        TableCell tcel41 = new TableCell();
        TableCell tcel42 = new TableCell();
        TableCell tcel51 = new TableCell();
        TableCell tcel52 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl32 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        CheckBox chk01 = new CheckBox();
        chk01.ID = "chk0" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk0" + count); //Text Value  
        if (payst.Equals("OK"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else 
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        lbl11.ID = "nameDesc" + count;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "nameDesc" + count); //Text Value
        lbl11.Text = "Living Partner's Name : ";

        lbl12.ID = "name" + count;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "name" + count); //Text Value
        lbl12.Text = name;

        lbl21.ID = "nicDesc" + count;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "nicDesc" + count); //Text Value
        lbl21.Text = "NIC Number : ";

        lbl22.ID = "nic" + count;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "nic" + count); //Text Value
        lbl22.Text = nic;
        
        lbl31.ID = "dobDesc" + count;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "dobDesc" + count); //Text Value
        lbl31.Text = "Date of Birth : ";

        lbl32.ID = "dob" + count;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "dob" + count); //Text Value
        if (dob.ToString().Length == 8)
        {
            lbl32.Text = dob.ToString().Substring(0, 4) + "/" + dob.ToString().Substring(4, 2) + "/" + dob.ToString().Substring(6, 2);
        }

        lbl41.ID = "adddesc" + count;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "adddesc" + count); //Text Value
        lbl41.Text = "Address : ";

        lbl42.ID = "ad" + count;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "ad" + count); //Text Value
        lbl42.Text = ad;

        lbl51.ID = "payst" + count;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "payst" + count); //Text Value
        lbl51.Text = "Payment OK : ";

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);
        tcel32.Controls.Add(lbl32);
        tcel41.Controls.Add(lbl41);
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);
        tcel52.Controls.Add(chk01);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow02.Cells.Add(tcel21);
        trow02.Cells.Add(tcel22);
        trow03.Cells.Add(tcel31);
        trow03.Cells.Add(tcel32);
        trow04.Cells.Add(tcel41);
        trow04.Cells.Add(tcel42);
        trow05.Cells.Add(tcel51);
        trow05.Cells.Add(tcel52);

        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
    }

    private void createASItable(string name, string fullname, string shortname, string address, string acctno, int rowno, string payst) 
    {
        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();
        TableRow trow06 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel21 = new TableCell();
        TableCell tcel22 = new TableCell();
        TableCell tcel31 = new TableCell();
        TableCell tcel32 = new TableCell();
        TableCell tcel41 = new TableCell();
        TableCell tcel42 = new TableCell();
        TableCell tcel51 = new TableCell();
        TableCell tcel52 = new TableCell();
        TableCell tcel61 = new TableCell();
        TableCell tcel62 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl32 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl52 = new Label();
        Label lbl61 = new Label();
        CheckBox chk01 = new CheckBox();
        chk01.ID = "chk0" + rowno;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk0" + rowno); //Text Value  
        if (payst.Equals("OK")) 
        { 
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        lbl11.ID = "nameDesc" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "nameDesc" + rowno); //Text Value
        lbl11.Text = "Assignee Name : ";

        lbl12.ID = "name" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "name" + rowno); //Text Value
        lbl12.Text = name;

        lbl21.ID = "fullnameDesc" + rowno;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "fullnameDesc" + rowno); //Text Value
        lbl21.Text = "Full Name : ";

        lbl22.ID = "fullname" + rowno;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "fullname" + rowno); //Text Value
        lbl22.Text = fullname;

        lbl31.ID = "shortnameDesc" + rowno;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "shortnameDesc" + rowno); //Text Value
        lbl31.Text = "Short Name : ";

        lbl32.ID = "shortname" + rowno;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "shortname" + rowno); //Text Value
        lbl32.Text = shortname;

        lbl41.ID = "adddesc" + rowno;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "adddesc" + rowno); //Text Value
        lbl41.Text = "Address : ";

        lbl42.ID = "address" + rowno;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "address" + rowno); //Text Value
        lbl42.Text = address;

        lbl51.ID = "acctnoDesc" + rowno;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "acctnoDesc" + rowno); //Text Value
        lbl51.Text = "Account No. : ";

        lbl52.ID = "acctno" + rowno;
        lbl52.Attributes.Add("runat", "Server");
        lbl52.Attributes.Add("Name", "acctno" + rowno); //Text Value
        lbl52.Text = acctno;

        lbl61.ID = "payst" + rowno;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "payst" + rowno); //Text Value
        lbl61.Text = "Payment OK : ";

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);
        tcel32.Controls.Add(lbl32);
        tcel41.Controls.Add(lbl41);
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);
        tcel52.Controls.Add(lbl52);
        tcel61.Controls.Add(lbl61);
        tcel62.Controls.Add(chk01);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow02.Cells.Add(tcel21);
        trow02.Cells.Add(tcel22);
        trow03.Cells.Add(tcel31);
        trow03.Cells.Add(tcel32);
        trow04.Cells.Add(tcel41);
        trow04.Cells.Add(tcel42);
        trow05.Cells.Add(tcel51);
        trow05.Cells.Add(tcel52);
        trow06.Cells.Add(tcel61);
        trow06.Cells.Add(tcel62);

        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
        Table1.Rows.Add(trow06);
    }
       
    private void MLinsert(string lhname, string lhadd, string married, string payee, DataManager dm)
    {
        int today = int.Parse(this.setDate()[0]);
        string enterip=Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        string lhiinsertinto = "insert into LPHS.LEGAL_HIRES(LHPOLNO, LHMOF, LHHNO, LHHIRE, LHNAME, LHAD1, LHENTDT, LHENTEPF, LHENTIP, LHSHARE) values(" + polno + ", '" + MOF + "', 1, '"+payee+"', '" + lhname + "', '"+lhadd+"', " + today + ", '" + EPF + "', '" + enterip + "', 1)";
        string lhidelete = "select * from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + MOF + "' and LHHNO=1";
        string vouoksel = lhidelete + " and VOUSTA='Y'";
        if (dm.existRecored(vouoksel) == 0)
        {
            if (dm.existRecored(lhidelete) != 0)
            {
                string mldelete = "delete from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + MOF + "' and LHHNO=1";
                dm.insertRecords(mldelete);
            }
            dm.insertRecords(lhiinsertinto);
        }        
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mOF
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public string Epf
    {
        get { return EPF; }
        set { EPF = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    
    protected void btnnext_Click(object sender, EventArgs e)
    {
        this.Polno = polno;
        this.mOF = MOF;
        Server.Transfer("~/dthVou001.aspx",true);
    }

    protected void cmdPayee_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/moreLegalHires001.aspx", true);
    }
}
