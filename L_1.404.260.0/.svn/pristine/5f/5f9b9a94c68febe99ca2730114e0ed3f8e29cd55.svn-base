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

public partial class dthVou002 : System.Web.UI.Page
{
    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;

    }

    private long polno;
    private string MOS;

    private double totamount;
    private double amtOut;
    private string payee = "";

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
    //    private int heireDOB;
    private string mst;

    DataManager dthpayObj;
    AMLDesignatedPerson amlDesignated;
    private ArrayList arrListNom;
    private ArrayList arrListLHI;
    private string[] ASIarr;
    private string[] LPTarr;
    private ArrayList vouIndexes;
    private ArrayList Slivouindex;

    //Rajitha Lakshan #42650
    private ArrayList vouEditIndexes;
    private ArrayList vouDeleteIndexes;


    private int recCount;
    private int vouCountStatic;
    private int vouToBeCreatedCount;
    private string EPF;
    private int claimNo;
    // if vouCountStatic + vouToBeCreatedCount = recCount that implies payment is completed

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mos;
        }
        if (!Page.IsPostBack)
        {
            if (Session["EPFNum"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }
        }
        dthpayObj = new DataManager();
        try
        {

            #region ----- view state ---------
            if (!Page.IsPostBack)
            {
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;

                ViewState["totamount"] = totamount;
                ViewState["amtOut"] = amtOut;
                ViewState["payee"] = payee;
                ViewState["arrListNom"] = arrListNom;
                ViewState["arrListLHI"] = arrListLHI;
                ViewState["ASIarr"] = ASIarr;
                ViewState["LPTarr"] = LPTarr;
                ViewState["vouIndexes"] = vouIndexes;
                ViewState["EPF"] = EPF;
                ViewState["recCount"] = recCount;
                ViewState["vouCountStatic"] = vouCountStatic;
                ViewState["vouToBeCreatedCount"] = vouToBeCreatedCount;
                ViewState["claimNo"] = claimNo;
            }
            else
            {
                if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }

                if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
                if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
                if (ViewState["arrListNom"] != null) { arrListNom = (ArrayList)ViewState["arrListNom"]; }
                if (ViewState["arrListLHI"] != null) { arrListLHI = (ArrayList)ViewState["arrListLHI"]; }
                if (ViewState["ASIarr"] != null) { ASIarr = (string[])ViewState["ASIarr"]; }
                if (ViewState["LPTarr"] != null) { LPTarr = (string[])ViewState["LPTarr"]; }
                if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState["vouIndexes"]; }
                if (ViewState["recCount"] != null) { recCount = int.Parse(ViewState["recCount"].ToString()); }
                if (ViewState["vouCountStatic"] != null) { vouCountStatic = int.Parse(ViewState["vouCountStatic"].ToString()); }
                if (ViewState["vouToBeCreatedCount"] != null) { vouToBeCreatedCount = int.Parse(ViewState["vouToBeCreatedCount"].ToString()); }
                if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
                if (ViewState["claimNo"] != null) { claimNo = int.Parse(ViewState["claimNo"].ToString()); }
            }
            #endregion

            arrListLHI = new ArrayList();
            arrListNom = new ArrayList();

            int payautDate = 0;
            int payOkCount = 0;
            int vouOKcount = 0;
            string completed = "";

            //Added By Shamaal - Check if there is a manual payment entry before printing Voucher in DEATH_MANUAL_MASTER
            string dtDMMSel = "select * from lphs.death_manual_master where POLICY_NO = " + polno + " and POLICY_TYPE = '" + MOS + "' ";
            if (dthpayObj.existRecored(dtDMMSel) == 0)
            {

                string dthrefSel = "select PAYEE, PAYAUTDT, DRNETCLM, AMTOUT, completed, DRCLMNO from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";
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
                        if (!drefrd.IsDBNull(4)) { completed = drefrd.GetString(4); } else { completed = ""; }
                        if (!drefrd.IsDBNull(5)) { claimNo = drefrd.GetInt32(5); } else { claimNo = 0; }
                    }
                    drefrd.Close();
                    drefrd.Dispose();

                    if (completed.Equals("R")) { this.lblmessage.Text = "Claim Repudiated"; }

                    //if (payautDate > 0)
                    //{
                    int i1 = 0;
                    int payAutCount = 0;

                    if (payee.Equals("NOM"))
                    {
                        #region
                        int rows3 = 0;
                        double nomiShare = 0;
                        string NOMAD1 = "";
                        string NOMAD2 = "";
                        string NOMAD3 = "";
                        string NOMAD4 = "";

                        string nomSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER, PAYSTATUS, VOUSTA, NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
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

                                NOMNUM = nomineeReader.GetInt32(0);

                                nomiShare = Math.Truncate(Math.Round(PER * totamount, 4)) / 100;

                                if (paystatus.Equals("OK"))
                                {
                                    rows3 = NOMNUM;
                                    payOkCount++;
                                    createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM, nomiShare, vst);
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
                                if ((paystatus.Equals("OK")) || (paystatus.Equals("PN")) || (paystatus.Equals("NO"))) { payAutCount++; }
                                if (vst.Equals("Y"))
                                {
                                    vouOKcount++;
                                }
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();

                            if (payAutCount != i1)
                            {
                                dthpayObj.connclose();
                                throw new Exception("Payment not yet Authorized! Cannot Create Vouchers!");
                            }
                        }
                        #endregion
                    }
                    else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                    {
                        #region
                        double theShare = 0;
                        double amt = 0;
                        int count = 0;
                        string heireSelect = "select lhhno, lhhire, lhmst, lhname, lhad1, lhdob, LHPAYST, LHSHARE, LHAMOUNT, VOUSTA, lhad2, lhad3, lhad4 from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOS + "'  ";
                        if (dthpayObj.existRecored(heireSelect) != 0)
                        {
                            int tempcnt = 0;
                            dthpayObj.readSql(heireSelect);
                            OracleDataReader heireSelectReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (heireSelectReader.Read())
                            {
                                string paystatus = "";
                                string vst = "";
                                string hiereAd1 = "";
                                string hiereAd2 = "";
                                string hieread3 = "";
                                string hieread4 = "";
                                tempcnt++;
                                heireNo = heireSelectReader.GetInt32(0);
                                if (!heireSelectReader.IsDBNull(1)) { heire = heireSelectReader.GetString(1); } else { heire = ""; }
                                if (!heireSelectReader.IsDBNull(2)) { mst = heireSelectReader.GetString(2); } else { mst = ""; }
                                if (!heireSelectReader.IsDBNull(3)) { heireName = heireSelectReader.GetString(3); } else { heireName = ""; }
                                if (!heireSelectReader.IsDBNull(4)) { hiereAd1 = heireSelectReader.GetString(4); } else { heireAd = ""; }
                                if (!heireSelectReader.IsDBNull(6)) { paystatus = heireSelectReader.GetString(6); } else { paystatus = ""; }
                                if (!heireSelectReader.IsDBNull(9)) { vst = heireSelectReader.GetString(9); } else { vst = ""; }
                                if (!heireSelectReader.IsDBNull(7)) { theShare = heireSelectReader.GetDouble(7); } else { theShare = 0; }
                                if (!heireSelectReader.IsDBNull(8)) { amt = heireSelectReader.GetDouble(8); } else { amt = 0; }
                                if (!heireSelectReader.IsDBNull(10)) { hiereAd2 = heireSelectReader.GetString(10); } else { hiereAd2 = ""; }
                                if (!heireSelectReader.IsDBNull(11)) { hieread3 = heireSelectReader.GetString(11); } else { hieread3 = ""; }
                                if (!heireSelectReader.IsDBNull(12)) { hieread4 = heireSelectReader.GetString(12); } else { hieread4 = ""; }

                                if (paystatus.Equals("OK"))
                                {
                                    count = heireNo;
                                    payOkCount++;
                                    createShareTable(heire, heireName, theShare, amt, count, vst);
                                    //amt = Math.Truncate(amt * 100) / 100;
                                    //string hiereAd1 = "";
                                    //string hiereAd2 = "";
                                    //if (heireAd.Length <= 50) { hiereAd1 = heireAd.Substring(0, heireAd.Length); hiereAd2 = ""; }
                                    //else if ((heireAd.Length > 50) && (heireAd.Length <= 100)) { hiereAd1 = heireAd.Substring(0, 50); hiereAd2 = heireAd.Substring(50, (heireAd.Length - 50)); }
                                    //hiereAd2 = hiereAd2 + " " + hieread3;
                                    string[] hireDet = new string[9];
                                    hireDet[0] = heire;
                                    hireDet[1] = heireName;
                                    hireDet[2] = hiereAd1;
                                    hireDet[3] = hiereAd2;
                                    hireDet[4] = heireNo.ToString();
                                    hireDet[5] = paystatus;
                                    hireDet[6] = amt.ToString();
                                    hireDet[7] = hieread3;
                                    hireDet[8] = hieread4;

                                    arrListLHI.Add(hireDet);
                                }

                                if ((paystatus.Equals("OK")) || (paystatus.Equals("PN"))) { i1++; }
                                if ((paystatus.Equals("OK")) || (paystatus.Equals("PN")) || (paystatus.Equals("NO"))) { payAutCount++; }
                                if (vst.Equals("Y")) { vouOKcount++; }
                            }
                            heireSelectReader.Close();
                            heireSelectReader.Dispose();
                            if (tempcnt != payAutCount)
                            {
                                dthpayObj.connclose();
                                throw new Exception("Payment not yet Authorized! Cannot Create Vouchers!");
                            }
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
                        long ACCT_NO = 0;
                        int rowNum = 0;

                        string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, PAYSTATUS, VOUSTA, ASS_AD3 from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
                        if (dthpayObj.existRecored(asiSelect) != 0)
                        {
                            dthpayObj.readSql(asiSelect);
                            OracleDataReader prassReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (prassReader.Read())
                            {
                                i1++;
                                string paystatus = "";
                                string vst = "";
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

                                string name01 = ASS_STATUS + " " + ASS_FULLNAME;
                                string addre = ASS_AD1 + " " + ASS_AD2 + " " + ASS_AD3;

                                if (paystatus.Equals("OK"))
                                {
                                    rowNum++;
                                    payOkCount++;
                                    this.createASItable(name01, ASS_FULLNAME, ASS_SHORTNAME, addre, ACCT_NO.ToString(), rowNum, vst);
                                    ASIarr = new string[5];
                                    ASIarr[0] = name01;
                                    ASIarr[1] = ASS_AD1;
                                    ASIarr[2] = ASS_AD2;
                                    ASIarr[3] = ASS_AD3;
                                    ASIarr[4] = ACCT_NO.ToString();
                                    //ASIarr[4] = totamount;                                         
                                }
                                if ((paystatus.Equals("OK")) || (paystatus.Equals("PN")) || (paystatus.Equals("NO"))) { payAutCount++; }
                                if (vst.Equals("Y")) { vouOKcount++; }
                            }
                            prassReader.Close();
                            prassReader.Dispose();
                            if (i1 != payAutCount)
                            {
                                dthpayObj.connclose();
                                throw new Exception("Payment not yet Authorized! Cannot Create Vouchers!");
                            }
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

                        string living_prtSelect = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, PAYSTATUS, VOUSTA, NOMAD3, NOMAD4 from LUND.LIVING_PRT where polno = " + polno + "  ";
                        if (dthpayObj.existRecored(living_prtSelect) != 0)
                        {
                            dthpayObj.readSql(living_prtSelect);
                            OracleDataReader nomineeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                string paystatus = "";
                                string vst = "";
                                i1++;
                                if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); } else { NOMNAME = ""; }
                                if (!nomineeReader.IsDBNull(1)) { DOB = nomineeReader.GetInt32(1); } else { DOB = 0; }
                                if (!nomineeReader.IsDBNull(2)) { NIC = nomineeReader.GetString(2); } else { NIC = ""; }
                                if (!nomineeReader.IsDBNull(3)) { PER = nomineeReader.GetInt32(3); } else { PER = 0; }
                                if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); } else { NOMAD1 = ""; }
                                if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); } else { NOMAD2 = ""; }
                                if (!nomineeReader.IsDBNull(6)) { paystatus = nomineeReader.GetString(6); } else { paystatus = ""; }
                                if (!nomineeReader.IsDBNull(7)) { vst = nomineeReader.GetString(7); } else { vst = ""; }
                                if (!nomineeReader.IsDBNull(8)) { NOMAD3 = nomineeReader.GetString(8); } else { NOMAD3 = ""; }
                                if (!nomineeReader.IsDBNull(9)) { NOMAD4 = nomineeReader.GetString(9); } else { NOMAD4 = ""; }

                                string addr = NOMAD1 + " " + NOMAD2 + " " + NOMAD3 + " " + NOMAD4;

                                if (paystatus.Equals("OK"))
                                {
                                    incr++;
                                    payOkCount++;
                                    this.createLPTtable(NOMNAME, NIC, DOB, addr, incr, vst);
                                    LPTarr = new string[6];
                                    LPTarr[0] = NOMNAME;
                                    LPTarr[1] = NOMAD1;
                                    LPTarr[2] = NOMAD2;
                                    LPTarr[3] = NOMAD3;
                                    LPTarr[4] = NOMAD4;
                                    LPTarr[5] = totamount.ToString();
                                }
                                if ((paystatus.Equals("OK")) || (paystatus.Equals("PN")) || (paystatus.Equals("NO"))) { payAutCount++; }
                                if (vst.Equals("Y")) { vouOKcount++; }
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                            if (i1 != payAutCount)
                            {
                                dthpayObj.connclose();
                                throw new Exception("Payment not yet Authorized! Cannot Create Vouchers!");
                            }
                        }

                        #endregion
                    }

                    recCount = i1;
                    vouCountStatic = vouOKcount;
                    //vouToBeCreatedCount = payOkCount;
                    //if ((payOkCount > 0) && (payOkCount == vouOKcount)) { this.btnVouCr.Enabled = false; }

                    if (payOkCount == vouOKcount) { this.btnVouCr.Enabled = false; this.btnSlivou.Enabled = false;  }

                    this.lblpolno.Text = polno.ToString();
                    if (MOS.Equals("M")) { this.lbllifeType.Text = "Main Life"; }
                    else if (MOS.Equals("S")) { this.lbllifeType.Text = "Spouce"; }
                    else if (MOS.Equals("2")) { this.lbllifeType.Text = "Second Life"; }
                    this.lbltotclm.Text = String.Format("{0:N}", totamount);
                    if (payee.Equals("NOM")) { this.lblpayee.Text = "NOMINEE"; }
                    else if (payee.Equals("ASI")) { this.lblpayee.Text = "ASSIGNEE"; }
                    else if (payee.Equals("LPT")) { this.lblpayee.Text = "LIVING PARTNER"; }
                    else if (payee.Equals("LHI")) { this.lblpayee.Text = "LEGAL HEIRES"; }
                    else if (payee.Equals("ML")) { this.lblpayee.Text = "MAIN LIFE"; }
                    else if (payee.Equals("SL")) { this.lblpayee.Text = "SECOND LIFE"; }
                    //}
                    //else { throw new Exception("Payment not yet Authorized! Cannot Create Vouchers!"); }

                    #region ------------------ AML Designated List -----------------------------
                    amlDesignated = new AMLDesignatedPerson();
                    string AMLError = amlDesignated.Get_AMLDesignatedList(long.Parse(polno.ToString()), "P");

                    if (AMLError.Length > 0)
                    {
                        this.lblAMLDesignatedPersons.Text = AMLError;
                        lblAMLDesignatedPersons.Visible = true;
                    }

                    #endregion
                    //string query = "select * from LPHS.SLICVOUCHERS where svpol= " + polno + ""; //Rajitha Lakshan 42650
                    //    if (dthpayObj.existRecored(query) == 0)
                    //    {
                    //        this.btnVouCr.Enabled = false; 
                    //    }
                    //    else
                    //    {
                    //        this.btnVouCr.Enabled = true;
                    //    }
                }
                else
                {
                    dthpayObj.connclose();
                    throw new Exception("Invalid Policy No.");
                }

                dthpayObj.connclose();

            }

            else
            {
                dthpayObj.connclose();
                throw new Exception("A Manual Payment Has been done for this policy");
            }

        }


        catch (Exception ex)
        {
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        //}


    }

    protected void btnVouCr_Click(object sender, EventArgs e)
    {
        try
        {
            vouIndexes = new ArrayList();
            int tempCount = 0;
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
            else if (payee.Equals("ASI"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouIndexes.Add("1"); tempCount++; }
            }

            vouToBeCreatedCount = tempCount;
            if (vouCountStatic == recCount) { this.btnVouCr.Enabled = false; this.btnSlivou.Enabled = false;  }

            //Server.Transfer("", true);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnVouEdit_Click(object sender, EventArgs e) //Rajitha Lakshan #42650
    {
        try
        {
            vouEditIndexes = new ArrayList();
            int tempCount = 0;
            if (payee.Equals("NOM"))
            {
                foreach (string[] strarr in arrListNom)
                {
                    NOMNUM = int.Parse(strarr[4]);
                    string chk = "chk" + NOMNUM;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouEditIndexes.Add(NOMNUM.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
            {
                foreach (string[] star in arrListLHI)
                {
                    heireNo = int.Parse(star[4]);
                    string chk = "chk" + heireNo;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouEditIndexes.Add(heireNo.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LPT"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouEditIndexes.Add("1"); tempCount++; }
            }
            else if (payee.Equals("ASI"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouEditIndexes.Add("1"); tempCount++; }
            }

            vouToBeCreatedCount = tempCount;
            if (vouCountStatic == recCount) { this.btnVouCr.Enabled = false; this.btnSlivou.Enabled = false; }

            //Server.Transfer("", true);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }


    protected void btnVouDelete_Click(object sender, EventArgs e) //Rajitha Lakshan #42650
    {
        try
        {
            vouDeleteIndexes = new ArrayList();
            int tempCount = 0;
            if (payee.Equals("NOM"))
            {
                foreach (string[] strarr in arrListNom)
                {
                    NOMNUM = int.Parse(strarr[4]);
                    string chk = "chk" + NOMNUM;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouDeleteIndexes.Add(NOMNUM.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
            {
                foreach (string[] star in arrListLHI)
                {
                    heireNo = int.Parse(star[4]);
                    string chk = "chk" + heireNo;
                    CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk);
                    if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouDeleteIndexes.Add(heireNo.ToString()); tempCount++; }
                }
            }
            else if (payee.Equals("LPT"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouDeleteIndexes.Add("1"); tempCount++; }
            }
            else if (payee.Equals("ASI"))
            {
                CheckBox chkVouOK = (CheckBox)Table1.FindControl("chk1");
                if ((chkVouOK.Checked) && (chkVouOK.Enabled)) { vouDeleteIndexes.Add("1"); tempCount++; }
            }

            vouToBeCreatedCount = tempCount;
            if (vouCountStatic == recCount) { this.btnVouCr.Enabled = false; this.btnSlivou.Enabled = false;  }

            //Server.Transfer("", true);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }


    private void createNomineeTable(string nominee, string percentage, int rowNumber, int nomnum, double theShare, string voust)
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

    private void createLPTtable(string name, string nic, int dob, string ad, int count, string vst)
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

    protected void createShareTable(string relation, string name, double share, double amount, int count, string vst)
    {

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

    public long Polno
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
    public ArrayList SlicVou
    {
        get { return Slivouindex; }
        set { Slivouindex = value; }
    }
    public string Epf
    {
        get { return EPF; }
        set { EPF = value; }
    }

    public int ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }

    protected void btnSlivou_Click(object sender, EventArgs e)
    {
        try
        {
            Slivouindex = new ArrayList();
            int tempCount = 0;
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

            vouToBeCreatedCount = tempCount;
            if (vouCountStatic == recCount) { this.btnVouCr.Enabled = false; this.btnSlivou.Enabled = false;  }

            //Server.Transfer("",true);

        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}

