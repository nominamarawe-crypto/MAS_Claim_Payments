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
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

public partial class prtPmnt002 : System.Web.UI.Page
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

    private  int polno;
    private  string MOS;
    private int claimno;

    private  double totamount, adbamt, exgramt;
    private  double amtOut;
    private  string payee = "";

    private string epfNum = "";

    //***** for nominee *******
    private string NOMNAME;
    private int DOB;
    private string NIC;
    private double PER;
    private int NOMNUM;

    //***** for hiere ********
    private int heireNo;
    private string heire;
    private string heireName;
    private string heireAd;
    private int heireDOB;
    private string mst;
    
    //******Exgracia**********
    bool isExgracia = false;

    DataManager dthpayObj;
    private  ArrayList arrListNom;
    private  ArrayList arrListLHI;
    private ArrayList arrListADBPayee;
    private  string[] ASIarr;
    private  string[] LPTarr;
    private  ArrayList vouIndexes;
    private ArrayList Slivouindex;

    private  int recCount;
    private  int vouCountStatic;
    private  int vouToBeCreatedCount;

    private bool isADBPayee;
    private int isADBPayeeAuthorized;
    private string isADBPayeeReject; 
    // if vouCountStatic + vouToBeCreatedCount = recCount that implies payment is completed
    
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Session["EPFNUM"] = "8045";
        //epfNum = Session["EPFNUM"].ToString();

        

        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mos;
        }
        dthpayObj = new DataManager();

        try
        {
            if (!Page.IsPostBack)
            {
                #region //---- view state ------
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;

                ViewState["EPFNum"] = EPF;
                ViewState["totamount"] = totamount;
                ViewState["amtOut"] = amtOut;
                ViewState["payee"] = payee;
                ViewState["arrListNom"] = arrListNom;
                ViewState["arrListLHI"] = arrListLHI;
                ViewState["ASIarr"] = ASIarr;
                ViewState["LPTarr"] = LPTarr;
                ViewState["vouIndexes"] = vouIndexes;
                ViewState["isExgracia"] = isExgracia;

                ViewState["recCount"] = recCount;
                ViewState["vouCountStatic"] = vouCountStatic;
                ViewState["vouToBeCreatedCount"] = vouToBeCreatedCount;

                ViewState["arrListNom"] = arrListNom;
                ViewState["arrListLHI"] = arrListLHI;
                ViewState["arrListADBPayee"] = arrListADBPayee;
                ViewState["ASIarr"] = ASIarr;
                ViewState["LPTarr"] = LPTarr;
                ViewState["vouIndexes"] = vouIndexes;
                ViewState["isADBPayee"] = isADBPayee;
                #endregion

                #region-----------------------ADB on exgracia or not change option--------------
                if (exgramt > 0)
                {
                    double ADBONEX = 0;
                    string exgrAmtsSel = "select ADBONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF ='" + MOS + "' ";
                    if (dthpayObj.existRecored(exgrAmtsSel) != 0)
                    {
                        dthpayObj.readSql(exgrAmtsSel);
                        OracleDataReader exgaciareader = dthpayObj.oraComm.ExecuteReader();
                        while (exgaciareader.Read())
                        {
                            if (!exgaciareader.IsDBNull(0)) { ADBONEX = exgaciareader.GetDouble(0); }
                        }
                        exgaciareader.Close();
                    }
                    if (ADBONEX > 0) { this.chkAdbexgracia.Checked = true; }
                }
                #endregion

                #region----------------------- Check ADB Memo Approved --------------
                string adbPaymentSelect = "select * from LPHS.DTH_ADBPAYMENTS where policy_no=" + polno + " and mos='" + MOS + "'";
                if (dthpayObj.existRecored(adbPaymentSelect) == 0)
                {
                    throw new Exception("Please create ADB payment memo!");
                }

                string adbPaymentSelect1 = "select * from LPHS.DTH_ADBPAYMENTS where policy_no=" + polno + " and mos='" + MOS + "' and IS_MEMO_APPROVE='N'";
                if (dthpayObj.existRecored(adbPaymentSelect1) != 0)
                {
                    throw new Exception("Please approve ADB payment memo!");
                }
                #endregion
            }      

            if (Session["EPFNum"] != null)
            {
                epfNum = Session["EPFNum"].ToString();
            }
            else
            {
                throw new Exception("Your Session Variable Expired Please Log on to the System!");
            }

            #region //---- view state ------

            if (Page.IsPostBack)
            {
                if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }

                if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
                if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
                if (ViewState["isExgracia"] != null) { isExgracia = bool.Parse(ViewState["isExgracia"].ToString()); }

                if (ViewState["arrListNom"] != null) { arrListNom = (ArrayList)ViewState["arrListNom"]; }
                if (ViewState["arrListLHI"] != null) { arrListLHI = (ArrayList)ViewState["arrListLHI"]; }
                if (ViewState["arrListADBPayee"] != null) { arrListADBPayee = (ArrayList)ViewState["arrListADBPayee"]; }
                if (ViewState["ASIarr"] != null) { ASIarr = (string[])ViewState["ASIarr"]; }
                if (ViewState["LPTarr"] != null) { LPTarr = (string[])ViewState["LPTarr"]; }
                if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState["vouIndexes"]; }

                if (ViewState["recCount"] != null) { recCount = int.Parse(ViewState["recCount"].ToString()); }
                if (ViewState["vouCountStatic"] != null) { vouCountStatic = int.Parse(ViewState["vouCountStatic"].ToString()); }
                if (ViewState["vouToBeCreatedCount"] != null) { vouToBeCreatedCount = int.Parse(ViewState["vouToBeCreatedCount"].ToString()); }
                if (ViewState["isADBPayee"] != null) { isADBPayee = bool.Parse(ViewState["isADBPayee"].ToString()); }
            }

            #endregion

            arrListLHI = new ArrayList();
            arrListNom = new ArrayList();
            arrListADBPayee = new ArrayList();

            int payautDate = 0;
            int payOkCount = 0;
            int vouOKcount = 0;

            string dthrefSel = "select PAYEE, PAYAUTDT, TOTPAYAMT, AMTOUT, ADBPAYAMT, EXGRACIA_AMOUNT, DRCLMNO from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";
            if (dthpayObj.existRecored(dthrefSel) != 0)
            {
                dthpayObj.readSql(dthrefSel);
                OracleDataReader drefrd = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (drefrd.Read())
                {
                    if (!drefrd.IsDBNull(0)) { payee = drefrd.GetString(0); } else { payee = ""; }
                    if (!drefrd.IsDBNull(1)) { payautDate = drefrd.GetInt32(1); } else { payautDate = 0; }
                    if (!drefrd.IsDBNull(2)) { totamount = drefrd.GetDouble(2); } else { totamount = 0; }
                    if (!drefrd.IsDBNull(3)) { amtOut = drefrd.GetDouble(3); } else { amtOut = 0; }
                    if (!drefrd.IsDBNull(4)) { adbamt = drefrd.GetDouble(4); } else { adbamt = 0; }
                    if (!drefrd.IsDBNull(5)) { exgramt = drefrd.GetDouble(5); } else { exgramt = 0; }
                    if (!drefrd.IsDBNull(6)) { claimno = drefrd.GetInt32(6); } else { claimno = 0; }
                }
                drefrd.Close();
                drefrd.Dispose();

                if (amtOut <= 0)
                {
                    dthpayObj.connclose();
                    throw new Exception("No Part Payments for this Policy!");
                }                

                if (payautDate == 0)
                {
                    int i1 = 0;
                    if (payee.Equals("NOM"))
                    {
                        #region
                        int rows3 = 0;
                        double nomiShare = 0;
                        string NOMAD1 = "";
                        string NOMAD2 = "";
                        string NOMAD3 = "";
                        string NOMAD4 = "";

                        string nomSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER, PAYSTATUS, ADBVOUSTA, NOMAD1, NOMAD2, NOMAD3, NOMAD4, nvl(IS_ADBREJECT,'N') from LUND.NOMINEE where POLNO = " + polno + " and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null) order by nomno ";
                        if (dthpayObj.existRecored(nomSelect) != 0)
                        {
                            dthpayObj.readSql(nomSelect);
                            OracleDataReader nomineeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                string paystatus = "";
                                string vst = "";
                                i1++;
                                if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); }
                                if (!nomineeReader.IsDBNull(2)) { DOB = nomineeReader.GetInt32(2); }
                                if (!nomineeReader.IsDBNull(3)) { NIC = nomineeReader.GetString(3); }
                                if (!nomineeReader.IsDBNull(4)) { PER = nomineeReader.GetDouble(4); }
                                if (!nomineeReader.IsDBNull(5)) { paystatus = nomineeReader.GetString(5); }
                                if (!nomineeReader.IsDBNull(6)) { vst = nomineeReader.GetString(6); }
                                if (!nomineeReader.IsDBNull(7)) { NOMAD1 = nomineeReader.GetString(7); }
                                if (!nomineeReader.IsDBNull(8)) { NOMAD2 = nomineeReader.GetString(8); }
                                if (!nomineeReader.IsDBNull(9)) { NOMAD3 = nomineeReader.GetString(9); }
                                if (!nomineeReader.IsDBNull(10)) { NOMAD4 = nomineeReader.GetString(10); }
                                if (!nomineeReader.IsDBNull(11)) { isADBPayeeReject = nomineeReader.GetString(11); }

                                NOMNUM = nomineeReader.GetInt32(0);

                                nomiShare = (PER * adbamt) / 100;

                                if (paystatus.Equals("OK") && isADBPayeeReject != "Y")
                                {
                                    rows3 = NOMNUM;
                                    payOkCount++;
                                    createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM, nomiShare, vst, isADBPayeeReject);
                                    string[] nomArr = new string[9];
                                    nomArr[0] = NOMNAME;
                                    nomArr[1] = NOMAD1;
                                    nomArr[2] = NOMAD2;
                                    nomArr[3] = PER.ToString();
                                    nomArr[4] = NOMNUM.ToString();
                                    nomArr[5] = nomiShare.ToString();
                                    nomArr[6] = paystatus;
                                    nomArr[7] = NOMAD3;
                                    nomArr[8] = NOMAD4;

                                    arrListNom.Add(nomArr);

                                }
                                if (vst.Equals("Y")) { vouOKcount++; }

                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                        }
                        #endregion
                    }
                    //else if (payee.Equals("LHI"))
                    else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                    {
                        #region
                        double theShare = 0;
                        double amt = 0;
                        int count = 0;
                        string hiereAd1 = "";
                        string hiereAd2 = "";
                        string hiereAd3 = "";
                        string hiereAd4 = "";
                        string heireSelect = "select lhhno, lhhire, lhmst, lhname, lhad1, lhdob, LHPAYST, LHSHARE, LHAMOUNT, ADBVOUSTA, lhad2, lhad3, lhad4, nvl(IS_ADBREJECT,'N') from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOS + "' and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null)  ";
                        if (dthpayObj.existRecored(heireSelect) != 0)
                        {
                            dthpayObj.readSql(heireSelect);
                            OracleDataReader heireSelectReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (heireSelectReader.Read())
                            {
                                string paystatus = "";
                                string vst = "";
                                heireNo = heireSelectReader.GetInt32(0);
                                if (!heireSelectReader.IsDBNull(1)) { heire = heireSelectReader.GetString(1); } else { heire = ""; }
                                if (!heireSelectReader.IsDBNull(2)) { mst = heireSelectReader.GetString(2); } else { mst = ""; }
                                if (!heireSelectReader.IsDBNull(3)) { heireName = heireSelectReader.GetString(3); } else { heireName = ""; }
                                if (!heireSelectReader.IsDBNull(4)) { hiereAd1 = heireSelectReader.GetString(4); } else { heireAd = ""; }
                                if (!heireSelectReader.IsDBNull(6)) { paystatus = heireSelectReader.GetString(6); } else { paystatus = ""; }
                                if (!heireSelectReader.IsDBNull(9)) { vst = heireSelectReader.GetString(9); } else { vst = ""; }
                                if (!heireSelectReader.IsDBNull(7)) { theShare = heireSelectReader.GetDouble(7); } else { theShare = 0; }
                                //if (!heireSelectReader.IsDBNull(8)) { amt = heireSelectReader.GetDouble(8); }
                                if (!heireSelectReader.IsDBNull(10)) { hiereAd2 = heireSelectReader.GetString(10); } else { hiereAd2 = ""; }
                                if (!heireSelectReader.IsDBNull(11)) { hiereAd3 = heireSelectReader.GetString(11); } else { hiereAd3 = ""; }
                                if (!heireSelectReader.IsDBNull(12)) { hiereAd4 = heireSelectReader.GetString(12); } else { hiereAd4 = ""; }
                                if (!heireSelectReader.IsDBNull(13)) { isADBPayeeReject = heireSelectReader.GetString(13); } else { isADBPayeeReject = ""; }
                                if (heireName.Equals("")) { theShare = 0; }
                                amt = adbamt * theShare;

                                if (paystatus.Equals("OK") && isADBPayeeReject != "Y")
                                {
                                    count = heireNo;
                                    payOkCount++;
                                    createShareTable(heire, heireName, theShare, amt, count, vst, isADBPayeeReject);

                                    //string hiereAd1 = "";
                                    //string hiereAd2 = "";
                                    //if (heireAd.Length <= 50) { hiereAd1 = heireAd.Substring(0, heireAd.Length); hiereAd2 = ""; }
                                    //else if ((heireAd.Length > 50) && (heireAd.Length <= 100)) { hiereAd1 = heireAd.Substring(0, 50); hiereAd2 = heireAd.Substring(50, (heireAd.Length - 50)); }
                                    string[] hireDet = new string[9];
                                    hireDet[0] = heire;
                                    hireDet[1] = heireName;
                                    hireDet[2] = hiereAd1;
                                    hireDet[3] = hiereAd2;
                                    hireDet[4] = heireNo.ToString();
                                    hireDet[5] = paystatus;
                                    hireDet[6] = amt.ToString();
                                    hireDet[7] = hiereAd3;
                                    hireDet[8] = hiereAd4;
                                    arrListLHI.Add(hireDet);

                                }
                                if ((paystatus.Equals("OK")) || (paystatus.Equals("PN"))) { i1++; }
                                if (vst.Equals("Y")) { vouOKcount++; }
                            }
                            heireSelectReader.Close();
                            heireSelectReader.Dispose();
                        }

                        #endregion
                    }
                    else if (payee.Equals("ASI"))
                    {
                        #region
                        string ASS_STATUS = "";
                        string ASS_INITIAL = "";
                        string ASS_SURNAME = "";
                        string ASS_FULLNAME = "";
                        string ASS_SHORTNAME = "";
                        string ASS_AD1 = "";
                        string ASS_AD2 = "";
                        string ASS_AD3 = "";
                        string ASS_AD4 = "";
                        long ACCT_NO = 0;
                        int rowNum = 0;

                        string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, PAYSTATUS, ADBVOUSTA, ASS_AD3 from LUND.ASSIGNEE  where POLICY_NO = " + polno + "  and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null) ";
                        if (dthpayObj.existRecored(asiSelect) != 0)
                        {
                            dthpayObj.readSql(asiSelect);
                            OracleDataReader prassReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (prassReader.Read())
                            {
                                string paystatus = "";
                                string vst = "";
                                i1++;
                                if (!prassReader.IsDBNull(0)) { ASS_STATUS = prassReader.GetString(0); }
                                if (!prassReader.IsDBNull(1)) { ASS_INITIAL = prassReader.GetString(1); }
                                if (!prassReader.IsDBNull(2)) { ASS_SURNAME = prassReader.GetString(2); }
                                if (!prassReader.IsDBNull(3)) { ASS_FULLNAME = prassReader.GetString(3); }
                                if (!prassReader.IsDBNull(4)) { ASS_SHORTNAME = prassReader.GetString(4); }
                                if (!prassReader.IsDBNull(5)) { ASS_AD1 = prassReader.GetString(5); }
                                if (!prassReader.IsDBNull(6)) { ASS_AD2 = prassReader.GetString(6); }
                                if (!prassReader.IsDBNull(7)) { ACCT_NO = prassReader.GetInt64(7); }
                                if (!prassReader.IsDBNull(8)) { paystatus = prassReader.GetString(8); }
                                if (!prassReader.IsDBNull(9)) { vst = prassReader.GetString(9); }
                                if (!prassReader.IsDBNull(10)) { ASS_AD3 = prassReader.GetString(10); }

                                string name01 = ASS_STATUS + " " + ASS_INITIAL + " " + ASS_SURNAME;
                                string addre = ASS_AD1 + " " + ASS_AD2 + " " + ASS_AD3;

                                if (paystatus.Equals("OK") && isADBPayeeReject != "Y")
                                {
                                    rowNum++;
                                    payOkCount++;
                                    this.createASItable(name01, ASS_FULLNAME, ASS_SHORTNAME, addre, ACCT_NO.ToString(), rowNum, vst);
                                    ASIarr = new string[6];
                                    ASIarr[0] = name01;
                                    ASIarr[1] = ASS_AD1;
                                    ASIarr[2] = ASS_AD2;
                                    ASIarr[3] = ACCT_NO.ToString();
                                    ASIarr[4] = ASS_AD3;
                                    ASIarr[5] = "";

                                    //ASIarr[4] = amtOut;                                         
                                }
                                if (vst.Equals("Y")) { vouOKcount++; }
                            }
                            prassReader.Close();
                            prassReader.Dispose();
                        }

                        #endregion
                    }
                    else if (payee.Equals("LPT"))
                    {
                        #region
                        string NOMAD1 = "";
                        string NOMAD2 = "";
                        string NOMAD3 = "";
                        string NOMAD4 = "";
                        int incr = 0;

                        string living_prtSelect = "select trim(NOMNAM), NOMDOB, NOMNIC, NOMPER, trim(NOMAD1), trim(NOMAD2), PAYSTATUS, ADBVOUSTA, trim(NOMAD3), trim(NOMAD4), nvl(IS_ADBREJECT,'N') from LUND.LIVING_PRT where polno = " + polno + " and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null) ";
                        if (dthpayObj.existRecored(living_prtSelect) != 0)
                        {
                            dthpayObj.readSql(living_prtSelect);
                            OracleDataReader nomineeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                string paystatus = "";
                                string vst = "";
                                i1++;
                                if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); }
                                if (!nomineeReader.IsDBNull(1)) { DOB = nomineeReader.GetInt32(1); }
                                if (!nomineeReader.IsDBNull(2)) { NIC = nomineeReader.GetString(2); }
                                if (!nomineeReader.IsDBNull(3)) { PER = nomineeReader.GetInt32(3); }
                                if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); }
                                if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); }
                                if (!nomineeReader.IsDBNull(6)) { paystatus = nomineeReader.GetString(6); }
                                if (!nomineeReader.IsDBNull(7)) { vst = nomineeReader.GetString(7); }
                                if (!nomineeReader.IsDBNull(8)) { NOMAD3 = nomineeReader.GetString(8); }
                                if (!nomineeReader.IsDBNull(9)) { NOMAD4 = nomineeReader.GetString(9); }
                                if (!nomineeReader.IsDBNull(10)) { isADBPayeeReject = nomineeReader.GetString(10); }

                                string addr = NOMAD1 + " " + NOMAD2 + " " + NOMAD3 + " " + NOMAD4;

                                if (paystatus.Equals("OK") && isADBPayeeReject != "Y")
                                {
                                    incr++;
                                    payOkCount++;
                                    this.createLPTtable(NOMNAME, NIC, DOB, addr, incr, vst, isADBPayeeReject);
                                    LPTarr = new string[5];
                                    if (!NOMNAME.Equals(""))
                                        LPTarr[0] = NOMNAME;

                                    if (!NOMAD1.Equals(""))
                                        LPTarr[1] = NOMAD1;
                                    if (!NOMAD2.Equals(""))
                                        LPTarr[2] = NOMAD2;
                                    if (!NOMAD3.Equals(""))
                                        LPTarr[3] = NOMAD3;
                                    if (!NOMAD4.Equals(""))
                                        LPTarr[4] = NOMAD4;
                                }

                                if (vst.Equals("Y"))
                                {
                                    vouOKcount++;
                                }
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                        }

                        #endregion
                    }

                    #region ---------------ADB payee------------------ 
                    string adbHeireSelect = "select PAYEENO, NEW_PAYEE, PAYEENAME, PAYEEAD1, PAYEEDOB, PAYEEPAYST, PAYEESHARE, PAYEEAMOUNT, ISPAYEEAUTHO, ISPAYEEREJECT, VOUST, PAYEEAD1, PAYEEAD2, PAYEEAD3, PAYEEAD4 from LPHS.DTH_ADBPAYMENT_DISTN where POLICY_NO=" + polno + " and MOS='" + MOS + "' and CLAIM_NO=" + claimno + " and (ISPAYEEREJECT <> 'Y' or ISPAYEEREJECT is null)  ";

                    if (dthpayObj.existRecored(adbHeireSelect) != 0)
                    {
                        double share, heireAmount;
                        string vst = "";
                        isADBPayee = true;
                        string paystatus = "";
                        string payeeAdd1 = "";
                        string payeeAdd2 = "";
                        string payeeAdd3 = "";
                        string payeeAdd4 = "";

                        dthpayObj.readSql(adbHeireSelect);
                        OracleDataReader adbheireSelectReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (adbheireSelectReader.Read())
                        { 
                            heireNo = adbheireSelectReader.GetInt32(0);
                            if (!adbheireSelectReader.IsDBNull(1)) { heire = adbheireSelectReader.GetString(1); } else { heire = ""; }
                            if (!adbheireSelectReader.IsDBNull(2)) { heireName = adbheireSelectReader.GetString(2); } else { heireName = ""; }
                            if (!adbheireSelectReader.IsDBNull(3)) { heireAd = adbheireSelectReader.GetString(3); } else { heireAd = ""; }
                            if (!adbheireSelectReader.IsDBNull(4)) { heireDOB = adbheireSelectReader.GetInt32(4); } else { heireDOB = 0; }
                            if (!adbheireSelectReader.IsDBNull(5)) { paystatus = adbheireSelectReader.GetString(5); } else { paystatus = ""; }
                            if (!adbheireSelectReader.IsDBNull(6)) { share = adbheireSelectReader.GetDouble(6); } else { share = 0; }
                            if (!adbheireSelectReader.IsDBNull(7)) { heireAmount = adbheireSelectReader.GetDouble(7); } else { heireAmount = 0; }
                            if (!adbheireSelectReader.IsDBNull(8)) { isADBPayeeAuthorized = adbheireSelectReader.GetInt32(8); } else { isADBPayeeAuthorized = 0; }
                            if (!adbheireSelectReader.IsDBNull(9)) { isADBPayeeReject = adbheireSelectReader.GetString(9); } else { isADBPayeeReject = ""; }
                            if (!adbheireSelectReader.IsDBNull(10)) { vst = adbheireSelectReader.GetString(10); } else { vst = ""; }
                            if (!adbheireSelectReader.IsDBNull(11)) { payeeAdd1 = adbheireSelectReader.GetString(11); } else { payeeAdd1 = ""; }
                            if (!adbheireSelectReader.IsDBNull(12)) { payeeAdd2 = adbheireSelectReader.GetString(12); } else { payeeAdd2 = ""; }
                            if (!adbheireSelectReader.IsDBNull(13)) { payeeAdd3 = adbheireSelectReader.GetString(13); } else { payeeAdd3 = ""; }
                            if (!adbheireSelectReader.IsDBNull(14)) { payeeAdd4 = adbheireSelectReader.GetString(14); } else { payeeAdd4 = ""; }

                            if (paystatus.Equals("OK") && isADBPayeeAuthorized == 1 && (isADBPayeeReject != "Y" || isADBPayeeReject == ""))
                            {
                                payOkCount++;
                                createShareTable(heire, heireName, share, heireAmount, heireNo, vst, isADBPayeeReject);
                                //createNomineeTable(heire, share.ToString(), heireNo, heireNo, heireAmount, vst, isADBPayeeReject);

                                string[] adbArr = new string[10];
                                adbArr[0] = heire;
                                adbArr[1] = share.ToString();
                                adbArr[2] = paystatus;
                                adbArr[3] = heireNo.ToString();
                                adbArr[4] = payeeAdd1;
                                adbArr[5] = payeeAdd2;
                                adbArr[6] = payeeAdd3;
                                adbArr[7] = payeeAdd4;
                                adbArr[8] = heireName;
                                adbArr[9] = heireAmount.ToString();

                                arrListADBPayee.Add(adbArr);
                            }

                            if (vst.Equals("Y"))
                            {
                                vouOKcount++;
                            }
                        }
                        adbheireSelectReader.Close();
                        adbheireSelectReader.Dispose();
                    }
                    #endregion

                    recCount = i1;
                    vouCountStatic = vouOKcount;
                    //vouToBeCreatedCount = payOkCount;
                    if (payOkCount == vouOKcount)
                    {
                        this.btnVouCr.Enabled = false;
                        this.btnSlicVou.Enabled = false;
                        this.btnCancelPayment.Enabled = false;
                    }
                    else
                    {
                        this.btnVouCr.Enabled = true;
                        this.btnSlicVou.Enabled = true;
                        this.btnCancelPayment.Enabled = true;
                    }
                    if (vouOKcount > 0) { this.btnCancelPayment.Enabled = false; chkAdbexgracia.Enabled = false; }
                    else { this.btnCancelPayment.Enabled = true; }

                    this.lblpolno.Text = polno.ToString();
                    if (MOS.Equals("M")) { this.lbllifeType.Text = "Main Life"; }
                    else if (MOS.Equals("S")) { this.lbllifeType.Text = "Spouce"; }
                    else if (MOS.Equals("2")) { this.lbllifeType.Text = "Second Life"; }
                    this.lbltotclm.Text = String.Format("{0:N}", adbamt);
                    if (payee.Equals("NOM")) { this.lblpayee.Text = "NOMINEE"; }
                    else if (payee.Equals("ASI")) { this.lblpayee.Text = "ASSIGNEE"; }
                    else if (payee.Equals("LPT")) { this.lblpayee.Text = "LIVING PARTNER"; }
                    else if (payee.Equals("LHI")) { this.lblpayee.Text = "LEGAL HEIRES"; }
                    else if (payee.Equals("ML")) { this.lblpayee.Text = "Main Life"; }
                }
                else
                {
                    dthpayObj.connclose();
                    throw new Exception("Payments Already Completed!");
                }

                // else { throw new Exception("Payment not yet Authorized! Cannot Create Vouchers!"); }

            }
            else
            {
                dthpayObj.connclose();
                throw new Exception("Invalid Policy No.");
            }


            dthpayObj.connclose();

           
                  
        }
        catch (Exception ex)
        {
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

     
    }

    protected void btnVouCr_Click(object sender, EventArgs e)
    {
        dthpayObj = new DataManager();
        string Availability = "N";
        double shradb = 0;
        double shradbfac = 0;

        try
        {
            
            dthpayObj.begintransaction();
            vouIndexes = new ArrayList();
            int tempCount = 0;
            double tempADBEx = 0.0;

            if ((chkAdbexgracia.Visible)&&(chkAdbexgracia.Enabled))
            {
                string exgraciaSelect = "select dpolnum,adbonex from lphs.exgracia_amts where dpolnum = " + polno + " and mof ='" + MOS + "' ";

                if (dthpayObj.existRecored(exgraciaSelect) != 0)
                {
                    dthpayObj.readSql(exgraciaSelect);
                    OracleDataReader exgRead = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (exgRead.Read())
                    {
                        if (!exgRead.IsDBNull(1)) { tempADBEx = exgRead.GetDouble(1); } else { tempADBEx = 0.0; }
                    }
                }

                if ((chkAdbexgracia.Checked) || tempADBEx > 0)
                {
                    adbamt = amtOut;
                    isExgracia = true;
                    ViewState.Add("isExgracia", isExgracia.ToString());
                }
                else
                {
                    adbamt = 0;
                }
                string dthrefupd = "update lphs.dthref set EXGRACIA_AMOUNT=" + adbamt + " where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "'";
                dthpayObj.insertRecords(dthrefupd);

                //string exgraciaSelect = "select dpolnum from lphs.exgracia_amts where dpolnum = " + polno + " and mof ='" + MOS + "' ";
                if (dthpayObj.existRecored(exgraciaSelect) != 0)
                {
                    string exgrupd = "UPDATE LPHS.EXGRACIA_AMTS SET ADBONEX =" + adbamt + " where DPOLNUM = " + polno + " and MOF = '" + MOS + "' ";
                    dthpayObj.insertRecords(exgrupd);
                }
                else
                {
                    //insert into LPHS.EXGRACIA_AMTS(DPOLNUM , MOF, SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX)
                    //values(1263094, 'M', 0, 25000, 0, 0, 0, 0, 0)
                    if (isExgracia)
                    {
                        string exgrinsert = "insert into LPHS.EXGRACIA_AMTS(DPOLNUM , MOF, SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX)" +
                            " values(" + polno + ", '" + MOS + "', 0, " + adbamt + ", 0, 0, 0, 0, 0)";
                        dthpayObj.insertRecords(exgrinsert);
                    }
                }
            }

            #region ----------- ADB Payee ---------------
            if (arrListADBPayee.Count > 0)
            {
                foreach (string[] star in arrListADBPayee)
                {
                    heireNo = int.Parse(star[3]);
                    string chk = "chk" + heireNo;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouIndexes.Add(heireNo.ToString()); tempCount++; }
                } 
            }
            #endregion

            if (payee.Equals("NOM"))
            {
                foreach (string[] strarr in arrListNom)
                {
                    NOMNUM = int.Parse(strarr[4]);
                    string chk = "chk" + NOMNUM;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouIndexes.Add(NOMNUM.ToString()); tempCount++; }
                }
            }
            //else if (payee.Equals("LHI"))
            else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
            {
                foreach (string[] star in arrListLHI)
                {
                    heireNo = int.Parse(star[4]);
                    string chk = "chk" + heireNo;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouIndexes.Add(heireNo.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LPT"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouIndexes.Add("1"); tempCount++; }
            }
            else if (payee.Equals("ASI") && !isADBPayee)
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouIndexes.Add("1"); tempCount++; }
            } 

            vouToBeCreatedCount = tempCount;
            if (vouCountStatic == recCount) { this.btnVouCr.Enabled = false; this.btnSlicVou.Enabled = false; }

            this.Polno = polno;
            this.mOS = MOS;
            this.isExgracia = IsExgracia;

            //#region reinsure email

            //string reinsurechck = "select AVAILABILITY,RE_INS_ADB,RE_INS_ADB_FAC from LPHS.DTH_REINSURANCE_DTL where CLAIMNO='"+ claimno + "'";
            

            //if (dthpayObj.existRecored(reinsurechck) != 0)
            //{
            //    dthpayObj.readSql(reinsurechck);
            //    OracleDataReader dthControlReader = dthpayObj.oraComm.ExecuteReader();
            //    dthControlReader.Read();
            //    if (!dthControlReader.IsDBNull(0)) { Availability = dthControlReader.GetString(0); }
            //    if (!dthControlReader.IsDBNull(1)) { shradb = dthControlReader.GetDouble(1); }
            //    if (!dthControlReader.IsDBNull(2)) { shradbfac = dthControlReader.GetDouble(2); }
            //    dthControlReader.Close();
            //    dthControlReader.Dispose();
            //}

            //#endregion

            dthpayObj.commit();

        }
        catch (Exception ex) 
        {
            dthpayObj.rollback();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

        //if (Availability == "Y" && (shradb+shradbfac) > 0)
        //{
        //    Response.Redirect("PaymentForm.aspx?pState=2&clmno=" + claimno + "&polno=" + polno + "&mos=" + MOS + "&adb=1");
        //}
    }

    protected void btnCancelPayment_Click(object sender, EventArgs e)
    {
        dthpayObj = new DataManager();
        try 
        {
          
            //epfNum = Session["EPFNUM"].ToString();

            string dthrefSel = "select * from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";
            if (dthpayObj.existRecored(dthrefSel) != 0)
            {
                string dthrefUpd = "update lphs.dthref set amtout = 0, completed= 'Y', payautdt = " + int.Parse(this.setDate()[0]) + ", payautepf = '" + epfNum + "' where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";
                dthpayObj.insertRecords(dthrefUpd);

                this.btnCancelPayment.Enabled = false;
                this.btnVouCr.Enabled = false;
                this.btnSlicVou.Enabled = false;
            }
            else
            {
                dthpayObj.connclose();
                throw new Exception("No Record to Cancel");
            }

            dthpayObj.connclose();
        }
        catch (Exception ex)
        {
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    private void createNomineeTable(string nominee, string percentage, int rowNumber, int nomnum, double theShare, string voust, string isadbPayeeReject)
    {
        TableRow trow = new TableRow();
        TableCell tcell0 = new TableCell();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        tcell5.Style["color"] = "red";
        tcell5.Style["font-weight"] = "bold";

        Label lbl0 = new Label();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
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

        lbl4.ID = "isadbPayeeReject" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "isadbPayeeReject" + rowNumber); //Text Value
        
        if (voust.Equals("Y"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (isadbPayeeReject.Equals("Y"))
        {
            chk01.Checked = false;
            chk01.Enabled = false;
            lbl4.Text = "Canceled";
        } 

        tcell0.Controls.Add(lbl0);
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(chk01);
        tcell5.Controls.Add(lbl4);

        trow.Cells.Add(tcell0);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);
        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell5);

        Table1.Rows.Add(trow);
    }

    private void createLPTtable(string name, string nic, int dob, string ad, int count, string vst, string isadbPayeeReject)
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
        tcel62.Style["color"] = "red";
        tcel62.Style["font-weight"] = "bold";

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl32 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl61 = new Label();
        Label lbl62 = new Label();

        CheckBox chk01 = new CheckBox();
        if (vst.Equals("OK"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (isadbPayeeReject.Equals("Y"))
        {
            chk01.Checked = false;
            chk01.Enabled = false;
            lbl62.Text = "Canceled";
        }

        chk01.ID = "chk" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + count); //Text Value

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
        lbl51.Text = "Create Voucher: ";

        lbl61.ID = "isadbPayeeReject" + count;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "isadbPayeeReject" + count); //Text Value
        lbl61.Text = "Status : ";

        lbl62.ID = "status" + count;
        lbl62.Attributes.Add("runat", "Server");
        lbl62.Attributes.Add("Name", "status" + count); //Text Value 

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
        tcel61.Controls.Add(lbl61);
        tcel62.Controls.Add(lbl62);

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

    private void createASItable(string name, string fullname, string shortname, string address, string acctno, int rowno, string vst)
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
        if (vst.Equals("OK"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        } 

        chk01.ID = "chk" + rowno;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + rowno); //Text Value

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
        lbl61.Text = "Create Voucher: ";

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

    protected void createShareTable(string relation, string name, double share, double amount, int count, string vst, string isadbPayeeReject)
    {

        TableRow trow = new TableRow();
        TableRow trow2 = new TableRow();

        TableCell tcel01 = new TableCell();
        tcel01.Style["text-align"] = "Center";
        TableCell tcel02 = new TableCell();
        TableCell tcel03 = new TableCell();
        TableCell tcel04 = new TableCell();
        TableCell tcel05 = new TableCell();
        TableCell tcel06 = new TableCell();
        tcel06.Style["color"] = "red";
        tcel06.Style["font-weight"] = "bold";

        Label lbl01 = new Label();
        Label lbl02 = new Label();
        TextBox txt01 = new TextBox();
        TextBox txt02 = new TextBox();
        CheckBox chk01 = new CheckBox();
        Label lbl03 = new Label();

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
        //txt01.TextChanged += new System.EventHandler(this.TextBox_TextChanged);// txt.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
        if (count == 0) { txt01.Text = "Share"; txt01.Font.Bold = true; txt01.Style["text-align"] = "Center"; }
        else { txt01.Text = String.Format("{0:N}", share); txt01.Style["text-align"] = "Center"; }
        txt01.ReadOnly = true;

        txt02.MaxLength = 12;
        txt02.ID = "txtAmt" + count;
        txt02.Attributes.Add("runat", "Server");
        txt02.Attributes.Add("Name", "txtAmt" + count);
        if (count == 0) { txt02.Text = "Amount"; txt02.Font.Bold = true; txt02.Style["text-align"] = "Center"; }
        else { txt02.Text = String.Format("{0:N}", amount); txt02.Style["text-align"] = "Right"; }
        txt02.ReadOnly = true;

        chk01.ID = "chk" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + count);

        lbl03.ID = "isadbPayeeReject" + count;
        lbl03.Attributes.Add("runat", "Server");
        lbl03.Attributes.Add("Name", "isadbPayeeReject" + count); //Text Value

        if (count == 0) { chk01.Visible = false; }
        if (vst.Equals("Y"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (isadbPayeeReject.Equals("Y"))
        {
            chk01.Checked = false;
            chk01.Enabled = false;
            lbl03.Text = "Canceled";
        } 

        tcel01.Controls.Add(lbl01);
        tcel02.Controls.Add(lbl02);
        tcel03.Controls.Add(txt01);
        tcel04.Controls.Add(txt02);
        tcel05.Controls.Add(chk01);
        tcel06.Controls.Add(lbl03);

        trow.Cells.Add(tcel01);
        trow.Cells.Add(tcel02);
        trow.Cells.Add(tcel03);
        trow.Cells.Add(tcel04);
        trow.Cells.Add(tcel05);
        trow.Cells.Add(tcel06);

        this.Table1.Rows.Add(trow);

    }
    //private void TextBox_TextChanged(object sender, System.EventArgs e)
    //{
    //    CustomControl.TxtBox ctrl = (CustomControls.TxtBox)sender;
    //    double share;
    //    share=
    //}
    

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mOS
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public double AmtOut
    {
        get { return amtOut; }
        set { amtOut = value; }
    }
    public string Payee
    {
        get { return payee; }
        set { payee = value; }
    }
    public bool IsExgracia
    {
        get { return isExgracia; }
        set { isExgracia = value; }
    }
    public string EPF
    {
        get { return epfNum; }
        set { epfNum = value; }
    }
    public int RecCount
    {
        get { return recCount; }
        set { recCount = value; }
    }
    public int VouCountStatic
    {
        get { return vouCountStatic; }
        set { vouCountStatic = value; }
    }
    public int VouToBeCreatedCount
    {
        get { return vouToBeCreatedCount; }
        set { vouToBeCreatedCount = value; }
    }
    public ArrayList VouIndexes
    {
        get { return vouIndexes; }
        set { vouIndexes = value; }
    }
    public ArrayList SlicVou
    {
        get { return Slivouindex; }
        set { Slivouindex = value; }
    }
    public ArrayList ArrListNom
    {
        get { return arrListNom; }
        set { arrListNom = value; }
    }
    public ArrayList ArrListLHI
    {
        get { return arrListLHI; }
        set { arrListLHI = value; }
    }
    public ArrayList ArrListADBPayee
    {
        get { return arrListADBPayee; }
        set { arrListADBPayee = value; }
    }
    public string[] aSIarr
    {
        get { return ASIarr; }
        set { ASIarr = value; }
    }
    public string[] lPTarr
    {
        get { return LPTarr; }
        set { LPTarr = value; }
    }
    public bool IsADBPayee
    {
        get { return isADBPayee; }
        set { isADBPayee = value; }
    }

    protected void btnSlicVou_Click(object sender, EventArgs e)
    {
        dthpayObj = new DataManager();
        bool isExgracia = false;
        try
        {
            
            Slivouindex = new ArrayList();
            int tempCount = 0;

            dthpayObj.begintransaction();

            if ((chkAdbexgracia.Visible) && (chkAdbexgracia.Enabled))
            {
                if (chkAdbexgracia.Checked)
                {
                    adbamt = amtOut;
                    isExgracia = true;
                    ViewState.Add("isExgracia", isExgracia.ToString());
                }
                else
                {
                    adbamt = 0;
                }
                string dthrefupd = "update lphs.dthref set EXGRACIA_AMOUNT=" + adbamt + " where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "'";
                dthpayObj.insertRecords(dthrefupd);

                string exgraciaSelect = "select dpolnum from lphs.exgracia_amts where dpolnum = " + polno + " and mof ='" + MOS + "' ";
                if (dthpayObj.existRecored(exgraciaSelect) != 0)
                {
                    string exgrupd = "UPDATE LPHS.EXGRACIA_AMTS SET ADBONEX =" + adbamt + " where DPOLNUM = " + polno + " and MOF = '" + MOS + "' ";
                    dthpayObj.insertRecords(exgrupd);
                }
                else
                {
                    //insert into LPHS.EXGRACIA_AMTS(DPOLNUM , MOF, SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX)
                    //values(1263094, 'M', 0, 25000, 0, 0, 0, 0, 0)
                    if (isExgracia)
                    {
                        string exgrinsert = "insert into LPHS.EXGRACIA_AMTS(DPOLNUM , MOF, SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX)" +
                            " values(" + polno + ", '" + MOS + "', 0, " + adbamt + ", 0, 0, 0, 0, 0)";
                        dthpayObj.insertRecords(exgrinsert);
                    }
                }
            }

            if (payee.Equals("NOM"))
            {
                foreach (string[] strarr in arrListNom)
                {
                    NOMNUM = int.Parse(strarr[4]);
                    string chk = "chk" + NOMNUM;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { Slivouindex.Add(NOMNUM.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
            {
                foreach (string[] star in arrListLHI)
                {
                    heireNo = int.Parse(star[4]);
                    string chk = "chk" + heireNo;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { Slivouindex.Add(heireNo.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LPT"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { Slivouindex.Add("1"); tempCount++; }
            }
            else if (payee.Equals("ASI"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { Slivouindex.Add("1"); tempCount++; }
            }

            #region ----------- ADB Payee ---------------
            if (arrListADBPayee.Count > 0)
            {
                foreach (string[] star in arrListADBPayee)
                {
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { Slivouindex.Add("1"); tempCount++; }
                }
            }
            #endregion

            vouToBeCreatedCount = tempCount;
            if (vouCountStatic == recCount) { this.btnVouCr.Enabled = false; this.btnSlicVou.Enabled = false; }

            //Server.Transfer("",true);
            this.Polno = polno;
            this.mOS = MOS;
            this.isExgracia = isExgracia;
            dthpayObj.commit();
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
