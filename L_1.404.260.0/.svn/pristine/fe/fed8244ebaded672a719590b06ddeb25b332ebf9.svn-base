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

public partial class dthPay003 : System.Web.UI.Page
{
    private long polno;
    private string MOF;
   
//    private int infodat;
    private int dateofdeath;
//    private string epf;
    private double ADB;
    private double FPU;
    private double SJ;
    private double FE;
    private string FEearlyPay = "";
    private string ADBlatepay = "";

    private int COM;
    private int TBL;
    private int TRM;
    private int SUM;
    private int MOD;
    private double PRM;
//            private int DUE;
    private string STA;
    private string PayeeName;
    public int PayeeAge;
    private double agediffint;

        private double vestedBonus;
        private int bonusEndDate;
        private double interimBonus;
        private double totbons;
        private double surrrenderedbons;
        private int bonussurrYr;
        private double netsurrAmt;
        private long claimno;
        private double deposit;
        private double demmands;
        private double defint;
        private double loancap;
        private double loanint;
        private int missingprems;
        private string polcompleYM;
        private double amtComyr;
        private string minutes;
        private double Ageamount;
        private double AgediffIntst;
        private string NOMNAME;
        private int DOB;
        private string NIC;
        private double PER;
    //    private int NOMNUM;
        public int dueDate;
        private double otheradd;
        private double otherdeuct;
        private double refOfPrems;
        public int interimBonStYr;
        private double grossClm;
        private double netclm;
        private double outAmt;
        private double sumassured;
        private string thePayee;
        private string sumassDesc;
        private String EPF;
        private String Name;

        private double stagePayment;
        private double stampduty;
    private double deductAmt;
    private double thrstagepay;

    private int havePayment;
    private string havePaymentWarring;
    private bool signatureDisplay;
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

    DataManager dthpayObj;
    General gg;

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["EPFNum"] != null)
        //{
        //    EPF = Session["EPFNum"].ToString();
        //    Name = Session["Surname"].ToString();
        //}
        //else
        //{
        //    throw new Exception("Your Session Variable Expired Please Log on to the System!");
        //}
        

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            #region ---- getting ----
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mOF;
            signatureDisplay = this.PreviousPage.SignatureDisplay;


            thePayee = this.PreviousPage.ThePayee;

            dateofdeath = this.PreviousPage.Dateofdeath;
          
            COM = this.PreviousPage.cOM;
            TBL = this.PreviousPage.tBL;
            TRM = this.PreviousPage.tRM;
            SUM = this.PreviousPage.sUM;
            MOD = this.PreviousPage.mOD;
            PRM = this.PreviousPage.pRM;
            STA = this.PreviousPage.sTA;
            EPF = this.PreviousPage.Memoepf;

            vestedBonus = this.PreviousPage.VestedBonus;
            bonusEndDate = Convert.ToInt32(Session["BonusEndDate"]);
            interimBonus = this.PreviousPage.InterimBonus;
            totbons = this.PreviousPage.Totbons;
            surrrenderedbons = this.PreviousPage.Surrrenderedbons;
            bonussurrYr = this.PreviousPage.BonussurrYr;
            netsurrAmt = this.PreviousPage.NetsurrAmt;
            claimno = this.PreviousPage.Claimno;
            deposit = this.PreviousPage.Deposit;
            demmands = this.PreviousPage.Demmands;
            defint = this.PreviousPage.Defint;
            loancap = this.PreviousPage.Loancap;
            loanint = this.PreviousPage.Loanint;
            missingprems = this.PreviousPage.Missingprems;
            polcompleYM = this.PreviousPage.PolcompleYM;
            amtComyr = this.PreviousPage.AmtComyr;
            interimBonStYr = this.PreviousPage.InterimBonStYr;
            otheradd = this.PreviousPage.Otheradd;
            otherdeuct = this.PreviousPage.Otherdeuct;
            refOfPrems = this.PreviousPage.RefOfPrems;
            thrstagepay = this.PreviousPage.ThrStgamt;

            grossClm = this.PreviousPage.GrossClm;
            netclm = this.PreviousPage.Netclm;
            outAmt = this.PreviousPage.OutAmt;
            sumassured = this.PreviousPage.Sumassured;

            ADB = this.PreviousPage.aDB;
            FPU = this.PreviousPage.fPU;
            SJ = this.PreviousPage.sJ;
            FE = this.PreviousPage.fE;

            FEearlyPay = this.PreviousPage.fEearlyPay;
            ADBlatepay = this.PreviousPage.aDBlatepay;
            minutes = this.PreviousPage.Minutes;
            sumassDesc = this.PreviousPage.SumassDesc;
            Ageamount = this.PreviousPage.AgeDiffAmt;
            AgediffIntst = this.PreviousPage.AgeDiffINT;

            stagePayment = this.PreviousPage.StagePayment;
            stampduty = this.PreviousPage.Stamp_Duty;
            deductAmt = this.PreviousPage.DeductAmount;
            #endregion
        }
        if (!Page.IsPostBack)
        {
            dthpayObj = new DataManager();
            try
            {
                //---------Editted By Dushan----------------
                if (!Page.IsPostBack)
                {
                    //gg = new General();
                    //Name = gg.getSurname(EPF);                    
                }
                //-------------------------------------------
                    hdfmof.Value = MOF;
                    hdfpolno.Value = polno.ToString();
                #region --------- display det ---------
                this.litpolno.Text = polno.ToString();
                this.litclmno.Text = claimno.ToString();
                this.lbltab.Text = TBL.ToString();
                this.lblterm.Text = TRM.ToString();

                if (STA.Equals("I")) this.litpolstat.Text = "INFORCE";
                else this.litpolstat.Text = "LAPSED";

                this.litDCO.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                this.litdtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);

                if (interimBonus != 0.00)
                {
                    int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                    int nxtbonyr = interimBonStYr;
                    int yearsdiff = this.dateComparisonNew(lstbondecyr, dateofdeath)[0];
                    for (int i = 0; i < yearsdiff; i++)
                    {
                        nxtbonyr = nxtbonyr + 1;
                    }
                    string Getintbonyr = "select INTBONSTYR from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and DRCLMNO=" + claimno + "";
                    int interimbonusstyear = 0;
                    DataManager dm = new DataManager();

                    if (dm.existRecored(Getintbonyr) != 0)
                    {
                        dm.readSql(Getintbonyr);
                        System.Data.OracleClient.OracleDataReader dr = dm.oraComm.ExecuteReader();
                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0)) { interimbonusstyear = dr.GetInt32(0); }
                        }
                        dr.Close();
                    }
                    if (interimbonusstyear == 0 && interimBonus != 0.00)
                    {
                        string Updateintbonst = "update LPHS.DTHREF set INTBONSTYR=" + interimBonStYr + " where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and INTBONSTYR=0";
                        dm.insertRecords(Updateintbonst);
                    }
                    dm.connClose();
                }

                if (vestedBonus != 0.00)
                {
                    if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49)
                    {
                        
                            string deathYMD = dateofdeath.ToString();
                            int deatMonthDate = int.Parse(deathYMD.Substring(deathYMD.Length - 4));
                            int deatYr = int.Parse(dateofdeath.ToString().Substring(0, 4));

                            DataManager dthintobj = new DataManager();

                            string liflapsSelect = "select phdue from lphs.lpolhis where phpol=" + polno + " ";

                            if (dthintobj.existRecored(liflapsSelect) != 0)
                            {
                                dthintobj.readSql(liflapsSelect);
                                OracleDataReader lapsReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                lapsReader.Read();
                                dueDate = lapsReader.GetInt32(0);
                                lapsReader.Close();
                                lapsReader.Dispose();
                            }



                            if (STA.Equals("I"))
                            {
                                if (deatMonthDate == 1231)
                                {
                                    this.LiteralComm.Text = COM.ToString().Substring(0, 4);
                                    this.LiteralBonus.Text = (deatYr).ToString();
                                    lblFrom.Visible = true;
                                    lblTo.Visible = true;
                                }
                                else
                                {
                                    this.LiteralComm.Text = COM.ToString().Substring(0, 4);
                                    this.LiteralBonus.Text = (deatYr - 1).ToString();
                                    lblFrom.Visible = true;
                                    lblTo.Visible = true;

                                }


                            }
                            else if (STA.Equals("L"))
                            {
                                string dueDateToString = dueDate.ToString();
                                int dueYear = int.Parse(dueDate.ToString().Substring(0, 4));
                                LiteralComm.Text = COM.ToString().Substring(0, 4);
                                LiteralBonus.Text = (dueYear - 1).ToString();
                                lblFrom.Visible = true;
                                lblTo.Visible = true;
                            }


                    }
                    else if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL != 49) && STA.Equals("I"))
                    {
                        LiteralComm.Text = "";
                        LiteralBonus.Text = "";
                        lblFrom.Visible = true;
                        lblTo.Visible = true;
                    }
                    else if ((TBL == 38) && STA.Equals("L"))
                    {
                        this.LiteralComm.Text = "";
                        this.LiteralBonus.Text = "";
                        lblFrom.Visible = false;
                        lblTo.Visible = false;
                    }

                }

                if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49) && MOF == "M")
                {
                    this.litvestedBonus.Text = String.Format("{0:N}", 0);
                    //lahiru 2020/08/13
                    //this.LiteralComm.Text = String.Format("{0:N}", 0);
                    //this.LiteralBonus.Text = String.Format("{0:N}", 0);
                }
                else
                {
                    //lahiru 2020/08/13
                    this.litvestedBonus.Text = String.Format("{0:N}", vestedBonus);
                    //this.LiteralComm.Text = COM.ToString().Substring(0, 4);
                    //this.LiteralBonus.Text =Convert.ToString(bonusEndDate);
                    //this.LiteralBonus.Text = dateofdeath.ToString().Substring(0, 4);
                }

                this.litinterimbons.Text = String.Format("{0:N}", interimBonus);
                
                this.litsurrbons.Text = String.Format("{0:N}", surrrenderedbons);
                this.litbonsurryear.Text = bonussurrYr.ToString();
                this.litdefprems.Text = String.Format("{0:N}", demmands);
                this.litpremint.Text = String.Format("{0:N}", defint);
                this.litloancap.Text = String.Format("{0:N}", loancap);
                this.litloanInt.Text = String.Format("{0:N}", loanint);

                if (ADBlatepay.Equals("Y")) { this.litadb.Text = "0.0"; }
                else { this.litadb.Text = String.Format("{0:N}", ADB); }
                if (FEearlyPay.Equals("Y")) { this.litfpu.Text = "0.0"; }
                else { this.litfpu.Text = String.Format("{0:N}", FPU); }


                this.litsj.Text = String.Format("{0:N}", SJ);
                this.litfe.Text = String.Format("{0:N}", FE);

                this.litPCY.Text = missingprems.ToString();
                this.litACY.Text = String.Format("{0:N}", amtComyr+ deductAmt);
                this.litpremcmplyr.Text = polcompleYM;

                this.litsumassured.Text = String.Format("{0:N}", sumassured);

                this.litotheradditns.Text = String.Format("{0:N}", otheradd);
                if (STA.Equals("L"))
                {
                    this.litotherdeduct.Text = String.Format("{0:N}", otherdeuct-thrstagepay);
                    this.litStagePayDeduction.Text = String.Format("{0:N}", thrstagepay);
                }
                else
                {
                    this.litotherdeduct.Text = String.Format("{0:N}", otherdeuct);
                    this.litStagePayDeduction.Text = String.Format("{0:N}", 0);
                }

                this.litrefofprms.Text = String.Format("{0:N}", refOfPrems);

                this.litdeprefunds.Text = String.Format("{0:N}", deposit);
                this.litgrossclaim.Text = String.Format("{0:N}", grossClm);
                this.litnetclm.Text = String.Format("{0:N}", netclm);
                this.littot.Text = String.Format("{0:N}", netclm);
                this.litamtoutstan.Text = String.Format("{0:N}", outAmt);
                this.litminutes.Text = minutes;
                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.litepf.Text = EPF;
                //this.litname.Text = Name;
                this.litsumassdesc.Text = sumassDesc;
                this.litagediff.Text = String.Format("{0:N}", Ageamount);
                this.litagediffIntst.Text = String.Format("{0:N}", AgediffIntst);

                this.litStagePayment.Text = String.Format("{0:N}", stagePayment);
                #endregion

                #region //--------- Showing Payee Detais --------------------

                if (thePayee.Equals("LHI"))
                {
                    string LHHIRE = "";
                    string LHNAME = "";
                    string LHAD1 = "";
                    string LHAD2 = "";
                    string LHAD3 = "";
                    string LHAD4 = "";
                    int LHDOB = 0;
                    string LHMST = "";
                    double LHSHARE = 0;
                    string add = "";
                    this.litpayeewho.Text = "Legal Heires";
                    Literal1.Visible = true;
                    //this.litpayee.Text = "Legal Heires";

                    string legalHeireSel = "select LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHSHARE, LHAMOUNT, LHAD2, LHAD3, LHAD4 from LPHS.LEGAL_HIRES where LHPOLNO = " + polno + " and LHMOF = '" + MOF + "' ";
                    if (dthpayObj.existRecored(legalHeireSel) != 0)
                    {
                        int loopCount = 0;
                        OracleDataReader legalHiereReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (legalHiereReader.Read())
                        {
                            loopCount++;
                            if (!legalHiereReader.IsDBNull(0)) { LHHIRE = legalHiereReader.GetString(0); }
                            if (!legalHiereReader.IsDBNull(1)) { LHNAME = legalHiereReader.GetString(1); }
                            if (!legalHiereReader.IsDBNull(2)) { LHAD1 = legalHiereReader.GetString(2); }
                            if (!legalHiereReader.IsDBNull(3)) { LHDOB = legalHiereReader.GetInt32(3); }
                            if (!legalHiereReader.IsDBNull(4)) { LHMST = legalHiereReader.GetString(4); }
                            if (!legalHiereReader.IsDBNull(5)) { LHSHARE = legalHiereReader.GetDouble(5); }
                            if (!legalHiereReader.IsDBNull(7)) { LHAD2 = legalHiereReader.GetString(7); }
                            if (!legalHiereReader.IsDBNull(8)) { LHAD3 = legalHiereReader.GetString(8); }
                            if (!legalHiereReader.IsDBNull(9)) { LHAD4 = legalHiereReader.GetString(9); }

                            if (LHMST.Equals("M")) { LHMST = "Married"; }
                            else { if (!LHHIRE.Equals("Spouce") && !LHHIRE.Equals("Mother") && !LHHIRE.Equals("Father")) { LHMST = "Unmarried"; } }
                            add = LHAD1 + " " + LHAD2 + " " + LHAD3 + " " + LHAD4;
                            //this.createHeireTable(LHHIRE, LHNAME, add, LHDOB.ToString(), LHMST, LHSHARE, loopCount);
                        }
                        legalHiereReader.Close();
                        legalHiereReader.Dispose();
                    }
                }
                else if (thePayee.Equals("LPT"))
                {
                    this.litpayeewho.Text = "Living Partner";
                    Literal1.Visible = true;
                    //this.litpayee.Text = "Living Partner";
                    string NOMAD1 = "";
                    string NOMAD2 = "";
                    string livingPrtSel = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2 from LUND.LIVING_PRT  where polno = " + polno + " ";
                    if (dthpayObj.existRecored(livingPrtSel) != 0)
                    {
                        int rows = 0;
                        dthpayObj.readSql(livingPrtSel);
                        OracleDataReader livingPrtReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (livingPrtReader.Read())
                        {
                            rows++;
                            if (!livingPrtReader.IsDBNull(0)) { NOMNAME = livingPrtReader.GetString(0); }
                            if (!livingPrtReader.IsDBNull(1)) { DOB = livingPrtReader.GetInt32(1); }
                            if (!livingPrtReader.IsDBNull(2)) { NIC = livingPrtReader.GetString(2); }
                            if (!livingPrtReader.IsDBNull(3)) { PER = livingPrtReader.GetDouble(3); }
                            if (!livingPrtReader.IsDBNull(4)) { NOMAD1 = livingPrtReader.GetString(4); }
                            if (!livingPrtReader.IsDBNull(5)) { NOMAD2 = livingPrtReader.GetString(5); }

                            string theAddress = NOMAD1 + " " + NOMAD2;
                            this.createLivingPrtTable(NOMNAME, theAddress, DOB.ToString(), NIC, PER.ToString(), rows);
                        }
                        livingPrtReader.Close();
                        livingPrtReader.Dispose();
                    }
                }
                else if (thePayee.Equals("NOM")) 
                {
                    int rows3 = 0;
                    this.litpayeewho.Text = "Nominee";
                    Literal1.Visible = true;
                    //this.litpayee.Text = "Nominee";
                    thePayee = "NOM";
                    double nomshare = 0.0;
                    string nomineeSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER,NOMSHARE   from lund.nominee where polno=" + polno + " ";
                    if (dthpayObj.existRecored(nomineeSelect) != 0)
                    {
                        TableHeaderRow tbhrw = new TableHeaderRow();
                        TableHeaderCell thcl = new TableHeaderCell();
                        TableHeaderCell thc2 = new TableHeaderCell();
                        TableHeaderCell thc3 = new TableHeaderCell();
                        TableHeaderCell thc4 = new TableHeaderCell();
                        TableHeaderCell thc5 = new TableHeaderCell();
                        thcl.Text = "Name"; thc2.Text = "Date of Birth";
                       // thc3.Text = "NIC Number"; 
                        thc4.Text = "Percentage";
                        thc4.Text = "Amount";
                        tbhrw.Controls.Add(thcl); tbhrw.Controls.Add(thc2);
                        //tbhrw.Controls.Add(thc3); 
                        tbhrw.Controls.Add(thc4); tbhrw.Controls.Add(thc5);
                        Table1.Controls.Add(tbhrw);
                        dthpayObj.readSql(nomineeSelect);
                        OracleDataReader nomineeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (nomineeReader.Read())
                        {
                            if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); }
                            if (!nomineeReader.IsDBNull(2)) { DOB = nomineeReader.GetInt32(2); }
                            if (!nomineeReader.IsDBNull(3)) { NIC = nomineeReader.GetString(3); }
                            if (!nomineeReader.IsDBNull(4)) { PER = nomineeReader.GetDouble(4); }
                            if (!nomineeReader.IsDBNull(5)) { nomshare = nomineeReader.GetDouble(5); } else { nomshare =( netclm * PER)/100; }
                            //createNomineeTable(NOMNAME, PER.ToString(), rows3);
                            if (DOB == 0)
                            {
                                if (rows3 == 0)
                                {
                                    PayeeName = NOMNAME;
                                }
                                else
                                {
                                    PayeeName = PayeeName + "," + NOMNAME;
                                }
                            }
                            else
                            {
                                string yr = DOB.ToString().Substring(0, 4);
                                string mn = DOB.ToString().Substring(4, 2);
                                string dt = DOB.ToString().Substring(6, 2);

                                DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                                DateTime today = DateTime.Now;
                                TimeSpan diff = today.Subtract(Bdate);
                                PayeeAge = (int)diff.TotalDays / 365;
                            }
                            createNomineeTable(NOMNAME, PER.ToString(), rows3, DOB, NIC,nomshare);
                            rows3++;
                        }
                        nomineeReader.Close();
                        nomineeReader.Dispose();
                    }

                }
                else if (thePayee.Equals("ASI"))
                {
                    string ASS_STATUS = "";
                    string ASS_FULLNAME = "";
                    string ASS_AD1 = "";
                    string ASS_AD2 = "";
                    long ACCT_NO = 0;
                    int rows2 = 0;

                    string prassigneeSelect = "select ASS_STATUS, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO  from LUND.PRASSIGNEE where policy_no = " + polno + " ";
                    if (dthpayObj.existRecored(prassigneeSelect) != 0)
                    {
                        this.litpayeewho.Text = "Assignee";
                        Literal1.Visible = true;
                        //this.litpayee.Text = "Assignee";
                        thePayee = "ASI";
                        dthpayObj.readSql(prassigneeSelect);
                        OracleDataReader prassigneeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (prassigneeReader.Read())
                        {
                            rows2++;
                            if (!prassigneeReader.IsDBNull(0)) { ASS_STATUS = prassigneeReader.GetString(0); }
                            if (!prassigneeReader.IsDBNull(1)) { ASS_FULLNAME = prassigneeReader.GetString(1); }
                            if (!prassigneeReader.IsDBNull(2)) { ASS_AD1 = prassigneeReader.GetString(2); }
                            if (!prassigneeReader.IsDBNull(3)) { ASS_AD2 = prassigneeReader.GetString(3); }
                            if (!prassigneeReader.IsDBNull(4)) { ACCT_NO = prassigneeReader.GetInt64(4); }

                            string theName = ASS_STATUS + " " + ASS_FULLNAME;
                            string theAddrs = ASS_AD1 + " " + ASS_AD2;

                            this.createAssigneeTable(theName, theAddrs, ACCT_NO, rows2);
                        }
                        prassigneeReader.Close();
                        prassigneeReader.Dispose();
                    }

                }
                else { }

                #endregion

                LtUserDetail.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now) + " " + String.Format("{0:hh:mm:ss}", DateTime.Now) + " , " + Session["EPFNum"].ToString() + " , " + Context.Request.ServerVariables["REMOTE_ADDR"].ToString();

                #region Digital Signature Task 39160

                string aprepf = "";
                string crrepf = "";
                string GetAprepf = "select APRVEPF,MEMO_CREATED_EPF from LPHS.DTHREF where DRPOLNO=" + polno + "";
                DataManager dtm = new DataManager();
                if (dtm.existRecored(GetAprepf) != 0)
                {
                    dtm.readSql(GetAprepf);
                    System.Data.OracleClient.OracleDataReader dr = dtm.oraComm.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0)) { aprepf = dr.GetString(0); }
                        if (!dr.IsDBNull(1)) { crrepf = dr.GetString(1); }
                    }
                    dr.Close();
                }
                dtm.connClose();

                if (signatureDisplay)
                {
                    #region creater signature



                       //get signature for apr epf
                       if (crrepf != "")
                       {
                        SignatureData signatureData = new SignatureData();
                        signatureData = signatureData.getSignature(crrepf);
                        if (signatureData.Signature != null)
                        {
                            lblSignature1.Visible = true;
                            string ImageName = crrepf.PadLeft(5, '0') + "_sign.png";
                            System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                            SignatureImage1.ImageUrl = "~/image/" + ImageName;
                            
                            lblName1.Visible = true;
                            lblDesig1.Visible = true;
                            lbldip1.Visible = true;
                            lblComp1.Visible = true;
                        }
                        else
                        {
                            lblSignature1.Visible = false;
                        }
                        this.lblName1.Text = signatureData.UserName + " ";
                        this.lbldip1.Text = "Life Insurance Section";
                        this.lblComp1.Text = "Sri Lanka Insurance Corporation life Ltd";

                        if (signatureData.Role != null)
                        {
                            this.lblDesig1.Text = signatureData.Role;
                        }
                        else
                        {
                            this.lblDesig1.Text = "Authorized Officer";
                        }
                    }
                    #endregion
                    #region aproved signature


                    //get signature for apr epf
                    if (aprepf != "")
                    {
                        SignatureData signatureData = new SignatureData();
                        signatureData = signatureData.getSignature(aprepf);
                        if (signatureData.Signature != null)
                        {
                            lblSignature.Visible = true;
                            string ImageName = aprepf.PadLeft(5, '0') + "_sign.png";
                            System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                            SignatureImage.ImageUrl = "~/image/" + ImageName;

                            lblName.Visible = true;
                            lblepf.Visible = true;
                            lblDesig.Visible = true;
                            lbldip.Visible = true;
                            lblComp.Visible = true;
                        }
                        else
                        {
                            lblSignature.Visible = false;
                        }
                        this.lblName.Text = signatureData.UserName + " ";
                        this.lbldip.Text = "Life Insurance Section";
                        this.lblComp.Text = "Sri Lanka Insurance Corporation life Ltd";
                        this.lblepf.Text = "( " + signatureData.EPF + " )";

                        if (signatureData.Role != null)
                        {
                            this.lblDesig.Text = signatureData.Role;
                        }
                        else
                        {
                            this.lblDesig.Text = "Authorized Officer";
                        }
                    }


                    #endregion
                }
                #endregion

            }
            catch (Exception ex) 
            {
                dthpayObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        
        }
    }

    public int[] dateComparisonNew(int startdate, int enddate)

    { //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
    }

    //private void createNomineeTable(string nominee, string percentage, int rowNumber)
    //{
    //    TableRow trow = new TableRow();
    //    TableCell tcell1 = new TableCell();
    //    TableCell tcell2 = new TableCell();
    //    Label lbl1 = new Label();
    //    Label lbl2 = new Label();

    //    lbl1.ID = "nominee" + rowNumber;
    //    lbl1.Attributes.Add("runat", "Server");
    //    lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
    //    lbl1.Text = "Name : " + nominee;

    //    lbl2.ID = "percentage" + rowNumber;
    //    lbl2.Attributes.Add("runat", "Server");
    //    lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
    //    lbl2.Text = percentage + "%";

    //    tcell1.Controls.Add(lbl1);
    //    tcell2.Controls.Add(lbl2);
    //    trow.Cells.Add(tcell1);
    //    trow.Cells.Add(tcell2);
    //    Table1.Rows.Add(trow);
    //}

    private void createNomineeTable(string nominee, string percentage, int rowNumber, int Dob, string nic,double shareamt)
    {

        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        //TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        //Label lbl3 = new Label();
        Label lbl4 = new Label();
        Label lbl5 = new Label();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;
        //lbl1.Width = 250;

        lbl2.ID = "dob" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "dob" + rowNumber); //Text Value
        lbl2.Text = Dob.ToString();
        //lbl2.Width = 150;

        //lbl3.ID = "nic" + rowNumber;
        //lbl3.Attributes.Add("runat", "Server");
        //lbl3.Attributes.Add("Name", "nic" + rowNumber); //Text Value
        //if (nic == null)
        //{
        //    lbl3.Text = " ";
        //}
        //else
        //{
        //    lbl3.Text = nic;
        //}
        // lbl3.Width = 100;

        lbl4.ID = "percentage" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
        if (percentage == null)
        {
            lbl4.Text = 0 + "%";
        }
        else
        {
            lbl4.Text = percentage + "%";
        }
        lbl5.ID = "Amount" + rowNumber;
        lbl5.Attributes.Add("runat", "Server");
        lbl5.Attributes.Add("Name", "Amount" + rowNumber); //Text Value
        lbl5.Text = String.Format("{0:N}", shareamt);
        
        //lbl4.Width = 100;

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        //tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(lbl4);
        tcell5.Controls.Add(lbl5);
        trow.Controls.Add(tcell1);
        trow.Controls.Add(tcell2);
        //trow.Controls.Add(tcell3);
        trow.Controls.Add(tcell4);
        trow.Controls.Add(tcell5);
        Table1.Controls.Add(trow);
    }


    private void createHeireTable(string heire, string name, string addr, string dob, string mst, double share, int loopCount)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();

        TableCell tcell11 = new TableCell();
        tcell11.Style["text-align"] = "Left";
        TableCell tcell12 = new TableCell();
        tcell12.Style["text-align"] = "Left";

        TableCell tcell21 = new TableCell();
        tcell21.Style["text-align"] = "Left";
        TableCell tcell22 = new TableCell();
        tcell22.Style["text-align"] = "Left";

        TableCell tcell31 = new TableCell();
        tcell31.Style["text-align"] = "Left";
        TableCell tcell32 = new TableCell();
        tcell32.Style["text-align"] = "Left";

        Label lbl11 = new Label();
        lbl11.ID = "heire" + loopCount;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "heire" + loopCount);
        lbl11.Text = "Heire : " + heire;

        Label lbl12 = new Label();
        lbl12.ID = "name" + loopCount;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "name" + loopCount);
        lbl12.Text = "Name : " + name;

        Label lbl21 = new Label();
        lbl21.ID = "addr" + loopCount;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "addr" + loopCount);
        lbl21.Text = "Address : " + addr;

        Label lbl22 = new Label();
        lbl22.ID = "dob" + loopCount;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "dob" + loopCount);
        lbl22.Text = "Date of Birth : " + dob;

        Label lbl31 = new Label();
        lbl31.ID = "share" + loopCount;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "share" + loopCount);
        lbl31.Text = "Share : " + String.Format("{0:N}", share);

        Label lbl32 = new Label();
        lbl32.ID = "mst" + loopCount;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "mst" + loopCount);
        lbl32.Text = mst;

        tcell11.Controls.Add(lbl11);
        tcell12.Controls.Add(lbl12);
        trow1.Cells.Add(tcell11);
        trow1.Cells.Add(tcell12);

        tcell21.Controls.Add(lbl21);
        trow2.Cells.Add(tcell21);
        tcell22.Controls.Add(lbl22);
        trow2.Cells.Add(tcell22);

        tcell31.Controls.Add(lbl31);
        tcell32.Controls.Add(lbl32);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);

        Table1.Rows.Add(trow1);
        Table1.Rows.Add(trow2);
        Table1.Rows.Add(trow3);
    }

    private void createLivingPrtTable(string name, string add, string dob, string nic, string per, int rows)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();

        TableCell tcell11 = new TableCell();
        tcell11.Style["text-align"] = "Left";

        TableCell tcell21 = new TableCell();
        tcell21.Style["text-align"] = "Left";

        TableCell tcell31 = new TableCell();
        tcell31.Style["text-align"] = "Left";
        TableCell tcell32 = new TableCell();
        tcell32.Style["text-align"] = "Left";
        TableCell tcell33 = new TableCell();
        tcell33.Style["text-align"] = "Left";

        Label lbl11 = new Label();
        lbl11.ID = "name" + rows;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "name" + rows);
        lbl11.Text = "Name : " + name;

        Label lbl21 = new Label();
        lbl21.ID = "add" + rows;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "add" + rows);
        lbl21.Text = "Address : " + add;

        Label lbl31 = new Label();
        lbl31.ID = "dob" + rows;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "dob" + rows);
        lbl31.Text = "DOB : " + dob;

        Label lbl32 = new Label();
        lbl32.ID = "nic" + rows;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "nic" + rows);
        lbl32.Text = "NIC : " + nic;

        Label lbl33 = new Label();
        lbl33.ID = "per" + rows;
        lbl33.Attributes.Add("runat", "Server");
        lbl33.Attributes.Add("Name", "per" + rows);
        lbl33.Text = "Percentage : " + String.Format("{0:N}", per) + "%";

        tcell11.Controls.Add(lbl11);
        trow1.Cells.Add(tcell11);
        tcell21.Controls.Add(lbl21);
        trow2.Cells.Add(tcell21);
        tcell31.Controls.Add(lbl31);
        tcell32.Controls.Add(lbl32);
        tcell33.Controls.Add(lbl33);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);
        trow3.Cells.Add(tcell33);

        Table1.Rows.Add(trow1);
        Table1.Rows.Add(trow2);
        Table1.Rows.Add(trow3);
    }

    private void createAssigneeTable(string theName, string adddress, long acctNo, int rowCount)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();

        TableCell tcell11 = new TableCell();
        tcell11.Style["text-align"] = "Left";

        TableCell tcell21 = new TableCell();
        tcell21.Style["text-align"] = "Left";

        TableCell tcell31 = new TableCell();
        tcell31.Style["text-align"] = "Left";

        Label lbl11 = new Label();
        lbl11.ID = "theName" + rowCount;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "theName" + rowCount);
        lbl11.Text = "Name : " + theName;

        Label lbl21 = new Label();
        lbl21.ID = "adddress" + rowCount;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "adddress" + rowCount);
        lbl21.Text = "Address : " + adddress;

        Label lbl31 = new Label();
        lbl31.ID = "acctNo" + rowCount;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "acctNo" + rowCount);
        lbl31.Text = "Account No. : " + acctNo;

        tcell11.Controls.Add(lbl11);
        trow1.Cells.Add(tcell11);
        tcell21.Controls.Add(lbl21);
        trow2.Cells.Add(tcell21);
        tcell31.Controls.Add(lbl31);
        trow3.Cells.Add(tcell31);

        Table1.Rows.Add(trow1);
        Table1.Rows.Add(trow2);
        Table1.Rows.Add(trow3);
    }



}
