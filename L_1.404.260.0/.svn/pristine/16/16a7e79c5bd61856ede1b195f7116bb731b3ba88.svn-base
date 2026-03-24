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
using System.Collections.Generic;
//Last Updated:28/08/2009 - Dushan
//Jayampathi 
//Amal
//Rashan
//Chandana
public partial class dthPay002 : System.Web.UI.Page
{
    private long polno;
    private string MOF;
    private int ageofsecond;
    private int infodat;
    private int dateofdeath;
    private string nameOfDead = "";

    private int bonusEndDate;
    private string COD;
    private int POL;
    private int COM;
    private int TBL;
    private int TRM;
    private int SUM;
    private int MOD;
    private double PRM, unadjdep;
    private double amtComyr;
    private int DUE;
    private string STA, memoepf = "";
    string EPF;
    private string PayeeName;
    public int PayeeAge;
    private double agediffint;
    private double interest = 0;
    private List<long> _duesToPaycompletYear;
    private int PAC;
    public int dueDate;

    private double fullageofSecond;
    public bool SignatureDisplay;

    //ViewState["userID"] = Session["UserId"];

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
    Table56 table56;
    //******* variables for DTHREF ***************
    private double ADB;
    private double FPU;
    private double SJ;
    private double FE;
    private string FEearlyPay = "";
    private string ADBlatepay = "", adbonexgr = "";

    private string ageAdmitYN;
    private string revivalsYN;
    private string assNomYN;
    private string reinsYN;
    private double vestedBonus;
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
    private int missingprems, polcompleYMD;
    private string polcompleYM, sumassDesc;

    private string ageStatus;
    private double ageDiffAmt;
    private string minutes;

    private double totamount;

    private string thePayee;

    private double otheradd;
    private double otherdeuct;
    private double thrstgamt;
    private double refOfPrems;
    private double stagedeuct;

    private double grossClm;
    private double netclm;
    private double outAmt;
    private double deductAmount;
    private double stagePayment;
    private double netclm_bfstamp;
    private double stamp_duty;

    private double sumassured;
    //private int ageofchild;
    //private int paidPremcount;

    private string NOMNAME;
    private int DOB, branch;
    private string NIC;
    private double PER;
    public int interimBonStYr;
    private string polcomyryn = "Y";
    public string memoaccept = "";
    private string payee;
    private bool isHavePremiumPaidCovers;
    private string status = "";

    private int havePayment;
    private string havePaymentWarring;
    private string stageyearString;
    bool isPremiumWave = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        _duesToPaycompletYear = new List<long>();
        gg = new General();
        if (!Page.IsPostBack)
        {
            if (Session["EPFNum"] != null)
            {
                branch = Convert.ToInt32(Session["brcode"]);
                EPF = Session["EPFNum"].ToString();

            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }
            Session["approveCLiked"] = "0";
        }
        else
        {
            if (Session["approveCLiked"] == "1")
            {
                if (Session["memoaccept"] == "Y")
                {
                    this.lblsuccess.Text = "Memo Accepted";
                    this.btnaccept.Visible = false;
                    this.btnPayshare.Visible = true;

                }
                else
                {
                    this.btnaccept.Visible = true;
                    this.btnPayshare.Visible = false;
                }
            }

        }
        lblerre.Text = "";
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.MOF;
            adbonexgr = this.PreviousPage.Adbonexgr;
            ageofsecond = this.PreviousPage.Seclifeage;
            fullageofSecond = this.PreviousPage.SeclifeFullage;
            hdfpolno.Value = polno.ToString();
            hdfmof.Value = MOF;
            Session["Polno"] = hdfpolno.Value;
            Session["MOF"] = hdfmof.Value;
        }
        else
        {
            if (Request.QueryString["polno"] != null) { polno = long.Parse(Request.QueryString["polno"].ToString()); }
            if (Request.QueryString["mos"] != null) { MOF = Request.QueryString["mos"].ToString(); }
            if (Request.QueryString["status"] != null) { status = Request.QueryString["status"].ToString(); }
            //ageofsecond = this.dateComparison(seclifeage, dateofdeath)[0];

        }
        if (!Page.IsPostBack)
        {

            string istrue = Request.QueryString.Get("err");
            if (istrue == "true")
            {
                polno = long.Parse(Request.QueryString.Get("pol"));
                MOF = Request.QueryString.Get("mof");
            }
            if (istrue == "true")
            {
                lblerre.Text = "This Policy Number does't have a cover for Child.";
            }
            if ((istrue == "true") && (MOF.Trim() != "2"))
            {
                lblerre.Text = "This Policy Number has a cover but No Death occured for Child....";
            }
            else
            {
                lblerre.Text = "";
            }
            dthpayObj = new DataManager();
            try
            {
                if (polno == 0)
                {
                    if (Request.QueryString["polno"] != null) { polno = long.Parse(Request.QueryString["polno"]); }
                    if (Request.QueryString["mos"] != null) { MOF = Request.QueryString["mos"].ToString(); }
                    hdfpolno.Value = polno.ToString();
                    hdfmof.Value = MOF;
                }

                #region //---------- viewing policy history.....

                string LPOLHIScheck = "select * from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                int currmmdd = 0;
                int stmmdd = 0;
                int currentmonth = 0;
                int startingMonth = 0;
                int policyCompleteMonth = 0;
                int policyCompleteYear = 0;

                if (dthpayObj.existRecored(LPOLHIScheck) != 0)
                {
                    string LPOLHISread = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "'  ";
                    dthpayObj.readSql(LPOLHISread);
                    OracleDataReader polhisReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (polhisReader.Read())
                    {
                        if (!polhisReader.IsDBNull(0)) { COD = polhisReader.GetString(0); } else { COD = ""; }

                        if (!polhisReader.IsDBNull(1)) { POL = polhisReader.GetInt32(1); } else { POL = 0; }
                        if (!polhisReader.IsDBNull(2)) { COM = polhisReader.GetInt32(2); Session["Comdate"] = COM; } else { COM = 0; }
                        if (!polhisReader.IsDBNull(3)) { TBL = polhisReader.GetInt32(3); } else { TBL = 0; }
                        if (!polhisReader.IsDBNull(4)) { TRM = polhisReader.GetInt32(4); } else { TRM = 0; }
                        if (!polhisReader.IsDBNull(5)) { SUM = polhisReader.GetInt32(5); } else { SUM = 0; }
                        if (!polhisReader.IsDBNull(6)) { MOD = polhisReader.GetInt32(6); } else { MOD = 0; }
                        if (!polhisReader.IsDBNull(7)) { PRM = polhisReader.GetDouble(7); } else { PRM = 0; }
                        if (!polhisReader.IsDBNull(8)) { DUE = polhisReader.GetInt32(8); } else { DUE = 0; }
                        if (!polhisReader.IsDBNull(9)) { PAC = polhisReader.GetInt32(9); } else { PAC = 0; }

                        //if (!polhisReader.IsDBNull(15)) { STA = polhisReader.GetString(15); } else { STA = ""; }

                        Session["TBL"] = TBL;
                        Session["TRM"] = TRM;
                    }
                    polhisReader.Close();
                    polhisReader.Dispose();

                    #region  //************** dthint ********************************************************************

                    string dthintSelect = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4, ditel, dinforel, DPOLST from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=2  ";
                    if (dthpayObj.existRecored(dthintSelect) == 0)
                    {
                        dthpayObj.connclose();
                        throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                    }
                    else
                    {
                        dthpayObj.readSql(dthintSelect);
                        OracleDataReader dthintREADER = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintREADER.Read())
                        {
                            if (!dthintREADER.IsDBNull(0)) { infodat = dthintREADER.GetInt32(0); } else { infodat = 0; }
                            if (!dthintREADER.IsDBNull(2)) { nameOfDead = dthintREADER.GetString(2); } else { nameOfDead = ""; }
                            if (!dthintREADER.IsDBNull(3)) { dateofdeath = dthintREADER.GetInt32(3); } else { dateofdeath = 0; }
                            if (!dthintREADER.IsDBNull(13)) { STA = dthintREADER.GetString(13); } else { STA = ""; }
                        }
                        dthintREADER.Close();
                        dthintREADER.Dispose();
                        this.lbldtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);

                    }

                    #endregion

                    this.lblpolno.Text = polno.ToString();
                    this.lbltab.Text = TBL.ToString();
                    this.lblterm.Text = TRM.ToString();
                    this.lblDCO.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                    if (STA.Equals("I")) this.lblpolstat.Text = "INFORCE";
                    else this.lblpolstat.Text = "LAPSED";

                    #endregion

                    //----------Calculating age of second life----Editted By Dushan-----------
                    #region
                    //Task 30745
                    //if ((MOF == "2") && ((TBL == 38) || (TBL == 39) || (TBL == 49) || (TBL == 56)) && (ageofsecond == 0))
                    if (((MOF == "2") || (MOF == "C")) && ((TBL == 38) || (TBL == 39) || (TBL == 49) || (TBL == 56)) && (ageofsecond == 0))
                    {
                        int seclifedob = 0;
                        String mosageselect = "select DOB from LUND.POLPERSONAL where POLNO= '" + polno + "' and (PRPERTYPE=4 OR PRPERTYPE=3)";
                        if (dthpayObj.existRecored(mosageselect) != 0)
                        {
                            dthpayObj.readSql(mosageselect);
                            OracleDataReader mosageread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (mosageread.Read())
                            {
                                if (!mosageread.IsDBNull(0)) { seclifedob = mosageread.GetInt32(0); } else { seclifedob = 0; }
                            }
                            mosageread.Close();
                            //mosageread.Dispose();
                        }
                        else
                        {
                            //dthpayObj.connclose();                        
                            throw new Exception("No Second Life Details Found!");
                        }
                        if (seclifedob > 9999999)
                        {
                            ageofsecond = this.dateComparison(seclifedob, dateofdeath)[0];


                            try
                            {
                                DateTime dtodsl = new DateTime(int.Parse(dateofdeath.ToString().Substring(0, 4)), int.Parse(dateofdeath.ToString().Substring(4, 2)), int.Parse(dateofdeath.ToString().Substring(6, 2)));
                                DateTime dtobsl = new DateTime(int.Parse(seclifedob.ToString().Substring(0, 4)), int.Parse(seclifedob.ToString().Substring(4, 2)), int.Parse(seclifedob.ToString().Substring(6, 2)));

                                fullageofSecond = dtodsl.Subtract(dtobsl).Days / 365.25;

                                if ((int.Parse(dateofdeath.ToString().Substring(4, 2)) == int.Parse(seclifedob.ToString().Substring(4, 2))) && (int.Parse(dateofdeath.ToString().Substring(0, 4)) - int.Parse(seclifedob.ToString().Substring(0, 4)) == 14))
                                {
                                    if (int.Parse(dateofdeath.ToString().Substring(6, 2)) - int.Parse(seclifedob.ToString().Substring(6, 2)) > 0)//exceed 14
                                        fullageofSecond = 14.1;
                                    else
                                        fullageofSecond = 14.0;

                                }




                            }
                            catch (Exception)
                            {

                                fullageofSecond = ageofsecond;
                            }

                        }
                        else
                        {
                            throw new Exception("Second life DOB not in a correct format");
                        }
                    }
                    #endregion
                    //

                    ViewState.Add("polnoint", polno);
                    ViewState.Add("MOFstr", MOF);
                    //hdfmof.Value = MOF;
                    /////----------- 20070614 --------------------------------/Pissu Kodikara....
                    if (STA.Equals("L")) { this.lblsumassDesc.Text = "Paidup Value"; sumassDesc = "Paidup Value"; }
                    else if (TBL == 28) { this.lblsumassDesc.Text = "Double the Sum Assured"; sumassDesc = "Double the Sum Assured"; }
                    else if (TBL == 29)
                    {
                        if (MOF == "M")
                        {
                            this.lblsumassDesc.Text = "Double the Increased Sum Assured"; sumassDesc = "Double the Increased Sum Assured";
                        }
                        else
                        {
                            this.lblsumassDesc.Text = "Basic Sum Assured"; sumassDesc = "Basic Sum Assured";
                        }
                    }
                    else { this.lblsumassDesc.Text = "Basic/Reduced Sum Assured"; sumassDesc = "Basic/Reduced Sum Assured"; }


                    #region   //------------- Claculating Policy Completed Year ----------------------

                    if ((COM > 9999999) && (dateofdeath > 9999999) && MOD != 5)
                    {
                        _duesToPaycompletYear = new List<long>(); //chandana
                        AmtPolComyear apc = new AmtPolComyear(polno, dateofdeath, MOF, dthpayObj);
                        amtComyr = apc.Polcomamt;
                        polcompleYMD = apc.Accomdt;
                        missingprems = apc.Noofprems;
                        polcompleYM = polcompleYMD.ToString().Substring(0, 6);
                        _duesToPaycompletYear = apc.DuesToComplete; //chandana



                        //checking deduction amount in case of disability waving no premium differance taken as deduction
                        //#43502
                        //bool isPremiumWave = false;
                        string getdisability = "select * from LCLM.DISABLE_MAS where DISABILITY_TYPE in (1,3) and mos='" + MOF + "' and  policy_no=" + polno;
                        isPremiumWave = (dthpayObj.existRecored(getdisability) != 0) ? true : false;

                        if (isPremiumWave)
                        {
                            amtComyr = 0;
                            deductAmount = 0;
                            _duesToPaycompletYear.Clear();
                            missingprems = 0;
                        }

                        //for safeside remain as it is with above code in case of not reccord in disablemas

                        if (COD.Equals("F")) //to be check
                        {
                            _duesToPaycompletYear.Clear();
                            missingprems = 0;
                            amtComyr = 0;

                        }



                        currmmdd = int.Parse(dateofdeath.ToString().Substring(4, 4));
                        stmmdd = int.Parse(COM.ToString().Substring(4, 4));
                        currentmonth = int.Parse(dateofdeath.ToString().Substring(4, 2));
                        startingMonth = int.Parse(COM.ToString().Substring(4, 2));
                        bool tag1 = false;
                        if (currmmdd < stmmdd) { policyCompleteYear = int.Parse(dateofdeath.ToString().Substring(0, 4)); }
                        else { policyCompleteYear = int.Parse(dateofdeath.ToString().Substring(0, 4)) + 1; tag1 = true; }
                        if (MOD == 4)
                        {
                            policyCompleteMonth = startingMonth - 1;
                            if (startingMonth == 0) { startingMonth = 12; policyCompleteYear--; }
                        }
                        else if (MOD == 3)
                        {
                            policyCompleteMonth = startingMonth - 3;
                            if (startingMonth == 0) { startingMonth = 12; policyCompleteYear--; }
                            if (startingMonth == -1) { startingMonth = 11; policyCompleteYear--; }
                            if (startingMonth == -2) { startingMonth = 10; policyCompleteYear--; }
                        }
                        else if (MOD == 2)
                        {
                            policyCompleteMonth = startingMonth - 6;
                            if (startingMonth == 0) { startingMonth = 12; policyCompleteYear--; }
                            if (startingMonth == -1) { startingMonth = 11; policyCompleteYear--; }
                            if (startingMonth == -2) { startingMonth = 10; policyCompleteYear--; }
                            if (startingMonth == -3) { startingMonth = 9; policyCompleteYear--; }
                            if (startingMonth == -4) { startingMonth = 8; policyCompleteYear--; }
                            if (startingMonth == -5) { startingMonth = 7; policyCompleteYear--; }
                        }
                        else if (MOD == 1)
                        {
                            if (tag1) { policyCompleteYear--; }
                        }
                        this.lblpremcompldyr.Text = gg.Formatdate(int.Parse(polcompleYM));
                    }
                    else if (MOD != 5)
                    {
                        dthpayObj.connclose();
                        throw new Exception("Commencement Month not in a Correct Format");
                    }

                    //if (startingMonth >= 10) { polcompleYM = policyCompleteYear.ToString() + startingMonth.ToString(); }
                    //else { polcompleYM = policyCompleteYear.ToString() + "0" + startingMonth.ToString(); }

                    //this.lblpremcompldyr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2);

                    //polcompleYMD = int.Parse(polcompleYM.ToString() + COM.ToString().Substring(6, 2));

                    #endregion

                    #region //************** dthref and amount/premiums to complete the policy year*****************

                    string dthrefSelect = "select DRCLMNO ,DRACCBF ,DRAGEADMIT ,DRRINSYN ,DRREVIVALS ,DRASSIGNEENOM ,DRVESTEDBON ,DRINTERIMBON ,";
                    dthrefSelect += "DRBONSURRAMT ,DRBONSURRYR ,DRSWARNAJAYA ,DRFUNERALEXP ,DRFPU ,DRDEPOSITS , DRDEFPREM ,DRINT ,DRLONCAP ,DRLOANINT ,";
                    dthrefSelect += "DRNETCLM ,DRPAIDNO , DRNETSURR, ADBPAYAMT, SJPAYAMT, FPUPAYAMT, FEPAYAMT, SMASS_PVAL, DROTHERADITNS, DEOTHERDEDUCT,";
                    dthrefSelect += " REFUND_OF_PREMS, MEMOAPRV, AMTOUT, FE_EARLYPAY, ADB_LATEPAY, AGE_STATUS, AGE_AMT, MINUTES,THR_STG_PMNT, POL_COMPL_YN," +
                        "AGEDIFINRST,PAYEE, MEMO_CREATED_EPF,AMT_TO_COMPLETE,INTBONSTYR,DIFF_DEDUCT,STAGE_PAYMENT,STAGE_PAYMENT_STR " +
                        " from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";

                    if (dthpayObj.existRecored(dthrefSelect) != 0)
                    {
                        dthpayObj.readSql(dthrefSelect);
                        OracleDataReader dthrefReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dthrefReader.Read())
                        {
                            if (!dthrefReader.IsDBNull(0)) { claimno = dthrefReader.GetInt64(0); } else { claimno = 0; }
                            if (!dthrefReader.IsDBNull(21)) { ADB = dthrefReader.GetDouble(21); } else { ADB = 0; }
                            if (!dthrefReader.IsDBNull(23)) { FPU = dthrefReader.GetDouble(23); } else { FPU = 0; }
                            if (!dthrefReader.IsDBNull(22)) { SJ = dthrefReader.GetDouble(22); } else { SJ = 0; }
                            if (!dthrefReader.IsDBNull(21)) { FE = dthrefReader.GetDouble(24); } else { FE = 0; }
                            if (!dthrefReader.IsDBNull(25)) { sumassured = dthrefReader.GetDouble(25); } else { sumassured = 0; }
                            if (!dthrefReader.IsDBNull(2)) { ageAdmitYN = dthrefReader.GetString(2); } else { ageAdmitYN = ""; }
                            if (!dthrefReader.IsDBNull(4)) { revivalsYN = dthrefReader.GetString(4); } else { revivalsYN = ""; }
                            if (!dthrefReader.IsDBNull(5)) { assNomYN = dthrefReader.GetString(5); } else { assNomYN = ""; }
                            if (!dthrefReader.IsDBNull(3)) { reinsYN = dthrefReader.GetString(3); } else { reinsYN = ""; }

                            if (!dthrefReader.IsDBNull(6)) { vestedBonus = dthrefReader.GetDouble(6); } else { vestedBonus = 0; }
                            if (!dthrefReader.IsDBNull(42)) { bonusEndDate = dthrefReader.GetInt32(42); } else { bonusEndDate = 0; }
                            if (!dthrefReader.IsDBNull(7)) { interimBonus = dthrefReader.GetDouble(7); } else { interimBonus = 0; }
                            if (!dthrefReader.IsDBNull(8)) { surrrenderedbons = dthrefReader.GetDouble(8); } else { surrrenderedbons = 0; }
                            if (!dthrefReader.IsDBNull(9)) { bonussurrYr = dthrefReader.GetInt32(9); } else { bonussurrYr = 0; }
                            if (!dthrefReader.IsDBNull(20)) { netsurrAmt = dthrefReader.GetDouble(20); } else { netsurrAmt = 0; }

                            if (!dthrefReader.IsDBNull(13)) { deposit = dthrefReader.GetDouble(13); } else { deposit = 0; }
                            if (!dthrefReader.IsDBNull(14)) { demmands = dthrefReader.GetDouble(14); } else { demmands = 0; }
                            if (!dthrefReader.IsDBNull(15)) { defint = dthrefReader.GetDouble(15); } else { defint = 0; }
                            if (!dthrefReader.IsDBNull(16)) { loancap = dthrefReader.GetDouble(16); } else { loancap = 0; }
                            if (!dthrefReader.IsDBNull(17)) { loanint = dthrefReader.GetDouble(17); } else { loanint = 0; }

                            if (!dthrefReader.IsDBNull(26)) { otheradd = dthrefReader.GetDouble(26); } else { otheradd = 0; }
                            if (!dthrefReader.IsDBNull(27)) { otherdeuct = dthrefReader.GetDouble(27); } else { otherdeuct = 0; }
                            if (!dthrefReader.IsDBNull(28)) { refOfPrems = dthrefReader.GetDouble(28); } else { refOfPrems = 0; }
                            if (!dthrefReader.IsDBNull(29)) { memoaccept = dthrefReader.GetString(29); } else { memoaccept = ""; }
                            if (!dthrefReader.IsDBNull(30)) { outAmt = dthrefReader.GetDouble(30); } else { outAmt = 0; }

                            if (!dthrefReader.IsDBNull(31)) { FEearlyPay = dthrefReader.GetString(31); } else { FEearlyPay = ""; }
                            if (!dthrefReader.IsDBNull(32)) { ADBlatepay = dthrefReader.GetString(32); } else { ADBlatepay = ""; }

                            if (!dthrefReader.IsDBNull(33)) { ageStatus = dthrefReader.GetString(33); } else { ageStatus = ""; }
                            if (!dthrefReader.IsDBNull(34)) { ageDiffAmt = dthrefReader.GetDouble(34); } else { ageDiffAmt = 0; }
                            if (!dthrefReader.IsDBNull(35)) { minutes = dthrefReader.GetString(35); } else { minutes = ""; }
                            if (!dthrefReader.IsDBNull(36)) { thrstgamt = dthrefReader.GetDouble(36); } else { thrstgamt = 0; }
                            if (!dthrefReader.IsDBNull(37)) { polcomyryn = dthrefReader.GetString(37); } else { polcomyryn = "Y"; }
                            if (!dthrefReader.IsDBNull(38)) { agediffint = dthrefReader.GetDouble(38); } else { agediffint = 0; }
                            if (!dthrefReader.IsDBNull(39)) { payee = dthrefReader.GetString(39); } else { payee = ""; }
                            if (!dthrefReader.IsDBNull(40)) { memoepf = dthrefReader.GetString(40); } else { memoepf = ""; }
                            if (!dthrefReader.IsDBNull(41) && memoaccept.Equals("Y")) { amtComyr = dthrefReader.GetDouble(41); missingprems = Convert.ToInt32(((double)amtComyr / PRM)); }  //CHADNANA
                            if (!dthrefReader.IsDBNull(43)) { deductAmount = dthrefReader.GetDouble(43); } else { deductAmount = 0; }
                            if (!dthrefReader.IsDBNull(44)) { stagePayment = dthrefReader.GetDouble(44); } else { stagePayment = 0; }
                            if (!dthrefReader.IsDBNull(45)) { stageyearString = dthrefReader.GetString(45); } else { stageyearString = ""; }

                            Session["VestedBonus"] = vestedBonus;
                            Session["interimBonus"] = interimBonus;
                            Session["otheradd"] = otheradd;
                            Session["BonusEndDate"] = bonusEndDate;
                        }
                        dthrefReader.Close();
                        dthrefReader.Dispose();


                        //Added task 36393
                        string dthrefSelect1 = "select INTBONSTYR  from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";

                        if (dthpayObj.existRecored(dthrefSelect1) != 0)
                        {
                            dthpayObj.readSql(dthrefSelect1);
                            OracleDataReader dthrefReader1 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                            while (dthrefReader1.Read())
                            {
                                if (!dthrefReader1.IsDBNull(0)) { interimBonStYr = dthrefReader1.GetInt32(0); } else { interimBonStYr = 0; }

                            }
                            dthrefReader1.Close();
                            dthrefReader1.Dispose();
                        }
                        //added from here 501 to 558
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



                                //string deathYMD = dateofdeath.ToString();
                                //int deatMonthDate = int.Parse(deathYMD.Substring(deathYMD.Length - 4));
                                //int deatYr = int.Parse(dateofdeath.ToString().Substring(0, 4));

                                //if (deatMonthDate == 1231)
                                //{
                                //    this.LiteralComm.Text = COM.ToString().Substring(0, 4);
                                //    this.LiteralBonus.Text = (deatYr).ToString();
                                //    lblFrom.Visible = true;
                                //    lblTo.Visible = true;
                                //}
                                //else 
                                //{
                                //    this.LiteralComm.Text = COM.ToString().Substring(0, 4);
                                //    this.LiteralBonus.Text = (deatYr - 1).ToString();
                                //    lblFrom.Visible = true;
                                //    lblTo.Visible = true;
                                //}


                            }
                            else if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL != 49) && STA.Equals("I"))
                            {
                                LiteralComm.Text = "";
                                LiteralBonus.Text = "";
                                lblFrom.Visible = false;
                                lblTo.Visible = false;
                            }
                            else if ((TBL == 38) && STA.Equals("L"))
                            {
                                this.LiteralComm.Text = "";
                                this.LiteralBonus.Text = "";
                                lblFrom.Visible = false;
                                lblTo.Visible = false;
                            }

                        }

                        #region-----------------------Unadjusted Deposits------------------------------
                        //Task no:23420
                        string deposittempsel = "SELECT DPDEPAMT FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO=" + polno + " AND DPMOS='" + MOF + "'";
                        if (!memoaccept.Equals("Y") && dthpayObj.existRecored(deposittempsel) == 0)
                        {
                            unadjdep = gg.Deposit(polno, dthpayObj);
                            deposit = unadjdep;
                        }
                        #endregion

                        //otherdeuct += thrstgamt + thrstgamt2;
                        //Claim Number assignment
                        Session["ClmNo"] = claimno;

                        #region  //-------------- Calculating No. Of Prems to Complete the Year ---------
                        int missingmonths = 0, daydiff = 0, monthdiff = 0, yeardiff = 0, missingyrs = 0, missingdays = 0;
                        if (TBL != 51)
                        {
                            if (MOD != 5)
                            {
                                daydiff = this.dateComparison(dateofdeath, polcompleYMD)[2];
                                monthdiff = this.dateComparison(dateofdeath, polcompleYMD)[1];
                                yeardiff = this.dateComparison(dateofdeath, polcompleYMD)[0];
                                missingmonths = yeardiff * 12 + monthdiff;
                                missingdays = 0;
                            }
                            else
                            {
                                daydiff = 0;
                                monthdiff = 0;
                                yeardiff = 0;
                                missingmonths = 0;
                                missingdays = 0;
                            }
                        }
                        else
                        {
                            double poldura = (double)this.Duration(COM, dateofdeath) / 12;
                            interest = 0;
                            BenefitRead bfr = new BenefitRead();
                            bfr.Fetch(POL, PRM, TRM, dthpayObj);
                            QuotDataSet qds = new QuotDataSet();
                            string lifecov = bfr.Lifecov;
                            qds.Deathonmaturity(PRM, bfr.Invbenamt, poldura, bfr.Invbenrate, bfr.Lifecov);
                            interest = qds.Interest;
                            this.lblSpace.Text = " ";
                            this.lblSpval.Text = ": " + String.Format("{0:N}", PRM);
                            this.lblIntrateval.Text = ": " + String.Format("{0:N}", interest);

                            if (lifecov.Equals("Y")) { this.lblLifecovyn.Text = ": Available"; }
                            else { this.lblLifecovyn.Text = ": Not Available"; }

                            //Make Visible
                            this.lblSpace.Visible = true;

                            this.lblSp.Visible = true;
                            this.lblSpval.Visible = true;
                            this.lblIntrate.Visible = true;
                            this.lblIntrateval.Visible = true;
                            this.lblLifecov.Visible = true;
                            this.lblLifecovyn.Visible = true;
                        }
                        //if (daydiff > 15) { missingmonths++; }


                        //--------- 20070606 modification ----------

                        if (STA.Equals("I") && TBL != 45 && TBL != 42 && TBL != 51)
                        {
                            #region-----------------------Inforce---------------------------------
                            int demanddate = 0;
                            string mydemandsql01 = "";
                            string mydemandsql02 = "";
                            string mydemandsql = "";
                            int dateofdthYM = int.Parse(dateofdeath.ToString().Substring(0, 6));
                            int dateofdthdate = int.Parse(dateofdeath.ToString().Substring(6, 2));
                            int comdate = int.Parse(COM.ToString().Substring(6, 2));

                            if (demmands > 0)
                            {
                                //string mydemandsql01 = "select pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                //   " pdcod = 'D' and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";

                                //string mydemandsql = "select max(pddue) from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                //    " pdcod = 'D' and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";
                                //if (dthpayObj.existRecored(mydemandsql01) != 0)
                                //{
                                //    dthpayObj.readSql(mydemandsql);
                                //    OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                //    mydemandreader01.Read();
                                //    if (!mydemandreader01.IsDBNull(0)) { demanddate = mydemandreader01.GetInt32(0); } else { demanddate = 0; }
                                //    mydemandreader01.Close();
                                //    mydemandreader01.Dispose();
                                //}

                                //Table 56 Changes

                                if (dateofdthdate > comdate)
                                {
                                    mydemandsql01 = "select pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                       " pdcod = 'D' and pddue <= " + dateofdthYM + " and pddue <= " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";

                                    mydemandsql = "select max(pddue) from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                        " pdcod = 'D' and pddue <= " + dateofdthYM + " and pddue <= " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";
                                }
                                else
                                {
                                    mydemandsql01 = "select pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                       " pdcod = 'D' and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";

                                    mydemandsql = "select max(pddue) from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                        " pdcod = 'D' and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";
                                }

                                if (dthpayObj.existRecored(mydemandsql01) != 0)
                                {
                                    dthpayObj.readSql(mydemandsql);
                                    OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    mydemandreader01.Read();
                                    if (!mydemandreader01.IsDBNull(0)) { demanddate = mydemandreader01.GetInt32(0); } else { demanddate = 0; }
                                    mydemandreader01.Close();
                                    mydemandreader01.Dispose();
                                }
                            }
                            else
                            {
                                //string mydemandsql02 = "select pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                //       " ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue >= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";

                                //string mydemandsql = "select min(pddue) from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                //        " ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue >= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";
                                //if (dthpayObj.existRecored(mydemandsql02) != 0)
                                //{
                                //    dthpayObj.readSql(mydemandsql);
                                //    OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                //    mydemandreader01.Read();
                                //    if (!mydemandreader01.IsDBNull(0)) { demanddate = mydemandreader01.GetInt32(0); } else { demanddate = 0; }
                                //    mydemandreader01.Close();
                                //    mydemandreader01.Dispose();
                                //}

                                //Table 56 Changes
                                if (dateofdthdate > comdate)
                                {
                                    mydemandsql02 = "select pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                       " ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue >= " + dateofdthYM + " and pddue <= " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";

                                    mydemandsql = "select min(pddue) from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                        " ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue >= " + dateofdthYM + " and pddue <= " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";
                                }
                                else
                                {
                                    mydemandsql02 = "select pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                       " ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue >= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";

                                    mydemandsql = "select min(pddue) from LPHS.DEMAND where pdpol='" + polno + "' and " +
                                        " ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue >= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " ";
                                }

                                if (dthpayObj.existRecored(mydemandsql02) != 0)
                                {
                                    dthpayObj.readSql(mydemandsql);
                                    OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    mydemandreader01.Read();
                                    if (!mydemandreader01.IsDBNull(0)) { demanddate = mydemandreader01.GetInt32(0); } else { demanddate = 0; }
                                    mydemandreader01.Close();
                                    mydemandreader01.Dispose();
                                }
                            }

                            int lastpaydateYear = 0;
                            int lastpaydateMonth = 0;
                            int lastpaydate = 0;
                            int xyz = 0;

                            if (MOD == 1) { xyz = 12; }
                            else if (MOD == 2) { xyz = 6; }
                            else if (MOD == 3) { xyz = 3; }
                            else if (MOD == 4) { xyz = 1; }
                            else { xyz = 12; }

                            //------------ uncommented on 20071003 --------------------
                            bool ledgerReliable = true;
                            int maxdemand = demanddate;
                            //string ledgerSelect01 = "select lldue from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 4) and lldue <= " + dateofdthYM + "";
                            //string ledgerSelect = "select max(lldue) from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 4) and lldue <= " + dateofdthYM + "";
                            string ledgerSelect01 = "select lldue from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldue <= " + dateofdthYM + "";
                            string ledgerSelect = "select max(lldue) from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldue <= " + dateofdthYM + "";
                            string ledgerSelect02 = "select lldue from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldue > " + dateofdthYM + "";
                            string ledgerSelect03 = "select min(lldue) from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldue > " + dateofdthYM + "";

                            if (MOD != 5)
                            {
                                if (dthpayObj.existRecored(ledgerSelect02) != 0 && ledgerReliable)
                                {
                                    //---- on 20080116 ---
                                    #region ---------------- if  ----------------
                                    dthpayObj.readSql(ledgerSelect03);
                                    OracleDataReader ledgrReader3 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    ledgrReader3.Read();
                                    if (!ledgrReader3.IsDBNull(0)) { demanddate = ledgrReader3.GetInt32(0); } else { demanddate = 0; }
                                    ledgrReader3.Close();
                                    ledgrReader3.Dispose();

                                    if (demanddate > 99999) { demanddate = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)); }
                                    else
                                    {
                                        dthpayObj.connclose();
                                        throw new Exception("Ledger File Error");
                                    }
                                    //missingmonths = this.dateComparison(demanddate, polcompleYMD)[1];
                                    //missingdays = this.dateComparison(demanddate, polcompleYMD)[2];
                                    //missingyrs = this.dateComparison(demanddate, polcompleYMD)[0];
                                    //missingmonths += missingyrs * 12;
                                    //if (missingmonths > 0) { missingprems = missingmonths / xyz; }
                                    //if (MOD == 4 && missingdays > 15) { missingprems++; }


                                    #endregion
                                }
                                else if (dthpayObj.existRecored(ledgerSelect01) != 0 && ledgerReliable)
                                {
                                    #region ---------------- else if  ----------------
                                    dthpayObj.readSql(ledgerSelect);
                                    OracleDataReader ledgrReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    ledgrReader.Read();
                                    if (!ledgrReader.IsDBNull(0)) { demanddate = ledgrReader.GetInt32(0); } else { demanddate = 0; }
                                    ledgrReader.Close();
                                    ledgrReader.Dispose();

                                    if (demanddate > 99999) { demanddate = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)); }
                                    else
                                    {
                                        dthpayObj.connclose();
                                        throw new Exception("Ledger File Error");
                                    }

                                    //if (!(MOF.Equals("2") && ((TBL == 39 && (ageofsecond < 15)) || (TBL == 38 && (ageofsecond < 15)) || (TBL == 49 && (ageofsecond < 15)) || TBL == 34 || TBL == 46)))
                                    //{
                                    if (int.Parse(demanddate.ToString().Substring(0, 6)) <= int.Parse(dateofdeath.ToString().Substring(0, 6)))
                                    {
                                        lastpaydate = demanddate;

                                        if (COD.Equals("F"))
                                        {
                                            int _lastdue = (int.Parse(COM.ToString().Substring(0, 6))) + (TRM * 100);
                                            string _lastDue = _lastdue.ToString() + COM.ToString().Substring(6, 2);
                                            lastpaydate = int.Parse(_lastDue);
                                        }

                                        // ---- uncreated demmands for before death unpaid premiums ---
                                        //if (demmands == 0 && (int.Parse(demanddate.ToString().Substring(0, 6)) > maxdemand) && this.dateComparison(lastpaydate, dateofdeath)[1] >= xyz && (int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)) < dateofdeath) && (TBL != 45 || TBL != 42) && (!((MOF.Equals("2") || MOF.Equals("C")) && ((TBL == 39 && (ageofsecond < 15)) || (TBL == 38 && (ageofsecond < 15)) || (TBL == 49 && (ageofsecond < 15)) || TBL == 34 || TBL == 40 || TBL == 46))) && (lastpaydate < dateofdeath))
                                        //if (demmands == 0 && (int.Parse(demanddate.ToString().Substring(0, 6)) > maxdemand) && this.dateComparison(lastpaydate, dateofdeath)[1] >= xyz && (int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)) < dateofdeath) && (TBL != 45 || TBL != 42) && (!((MOF.Equals("2") || MOF.Equals("C")) && ((TBL == 39 && (fullageofSecond <= 14)) || (TBL == 38 && (fullageofSecond <= 14)) || (TBL == 49 && (fullageofSecond <= 14)) || TBL == 34 || TBL == 40 || TBL == 46) || (TBL == 30))) && (lastpaydate < dateofdeath)) //15477

                                        //Table 56 Changes
                                        //if (demmands == 0 && (int.Parse(demanddate.ToString().Substring(0, 6)) > maxdemand) && this.dateComparison(lastpaydate, dateofdeath)[1] >= xyz && (int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)) < dateofdeath) && (TBL != 45 || TBL != 42) && (!((MOF.Equals("2") || MOF.Equals("C")) && ((TBL == 39 && (fullageofSecond <= 14)) || (TBL == 38 && (fullageofSecond <= 14)) || (TBL == 49 && (fullageofSecond <= 14)) || TBL == 34 || TBL == 40 || TBL == 46) || (TBL == 30))) && (lastpaydate < dateofdeath) && TBL != 3) //15477
                                        if (demmands == 0 && (int.Parse(demanddate.ToString().Substring(0, 6)) > maxdemand) && this.dateComparison(lastpaydate, dateofdeath)[1] >= xyz && (int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)) < dateofdeath) && (TBL != 45 || TBL != 42) && (!((MOF.Equals("2") || MOF.Equals("C")) && ((TBL == 39 && (fullageofSecond <= 14)) || (TBL == 38 && (fullageofSecond <= 14)) || (TBL == 49 && (fullageofSecond <= 14)) || TBL == 34 || TBL == 40 || TBL == 46 || TBL == 56) || (TBL == 30))) && (lastpaydate < dateofdeath) && TBL != 3) //15477
                                        {
                                            double dem1;
                                            //demmands = PRM * (this.dateComparison(lastpaydate, dateofdeath)[1] / (double)xyz); //22/04/2009
                                            dem1 = PRM * (this.dateComparison(lastpaydate, dateofdeath)[1] / (double)xyz);
                                            //if (this.dateComparison(lastpaydate, dateofdeath)[2] > 15)
                                            //{
                                            //    defint = PRM * .005 * (this.dateComparison(lastpaydate, dateofdeath)[1]);
                                            //}
                                            if (dem1 > 0) { throw new Exception("Demmands not found. Please enter Demmands manually!"); }
                                        }
                                        missingmonths = this.dateComparison(dateofdeath, polcompleYMD)[1];
                                        missingdays = this.dateComparison(dateofdeath, polcompleYMD)[2];
                                        missingyrs = this.dateComparison(dateofdeath, polcompleYMD)[0];
                                        missingmonths += missingyrs * 12;
                                        //if (missingmonths > 0) { missingprems = missingmonths / xyz; }
                                        //if (MOD == 4) { missingprems++; }                               
                                        //else if (MOD != 4 && missingprems > 0 && (missingmonths % xyz) > 0) { ++missingprems; }
                                        //else if (MOD == 4 && demmands == 0) { missingprems++; } --- commented on 20070215 ---
                                        //if (MOD == 4 && missingdays > 15) { missingprems++; }
                                        // --- commented on 20070327 -------
                                    }
                                    else
                                    {
                                        //--- this else part might be prepetually unreachable since the new if condition added afterwards ---
                                        missingmonths = this.dateComparison(demanddate, polcompleYMD)[1];
                                        missingdays = this.dateComparison(demanddate, polcompleYMD)[2];
                                        missingyrs = this.dateComparison(demanddate, polcompleYMD)[0];
                                        missingmonths += missingyrs * 12;
                                        //if (missingmonths > 0) { missingprems = missingmonths / xyz; }
                                        //if (MOD == 4 && missingdays > 15) { missingprems++; } not necessary because the day exactly matches
                                        //--missingprems;
                                        //if (MOD != 4 && missingprems > 0 && (missingmonths % xyz) == 0) { --missingprems; } 
                                        //if (MOD != 4 && missingprems > 0 && (missingmonths % xyz) == 0) { --missingprems; }
                                        //if (MOD == 4) { missingprems++; }
                                        // --- commented on 20071220 ---
                                    }
                                    //}

                                    #endregion
                                }
                                else //--------------- 20071003 ----------
                                {
                                    #region ---------------- else ----------------
                                    if (demmands == 0)
                                    {
                                        if (demanddate == 0) { demanddate = DUE; }
                                        demanddate = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2));
                                        //lastpaydateYear = int.Parse(demanddate.ToString().Substring(0, 4));
                                        //lastpaydateMonth = int.Parse(demanddate.ToString().Substring(4, 2));
                                        lastpaydateYear = this.lastpayDateym(demanddate, MOD)[1];
                                        lastpaydateMonth = this.lastpayDateym(demanddate, MOD)[0];

                                        if (lastpaydateMonth < 10)
                                        {
                                            lastpaydate = int.Parse(lastpaydateYear.ToString() + "0" + lastpaydateMonth.ToString() + demanddate.ToString().Substring(6, 2));
                                        }
                                        else
                                        {
                                            lastpaydate = int.Parse(lastpaydateYear.ToString() + lastpaydateMonth.ToString() + demanddate.ToString().Substring(6, 2));
                                        }
                                        if (this.dateComparison(lastpaydate, dateofdeath)[1] >= xyz && (TBL != 45 || TBL != 42)) { demmands = PRM; }
                                        if (lastpaydate > dateofdeath)
                                        {
                                            missingmonths = this.dateComparison(lastpaydate, polcompleYMD)[1];
                                            missingdays = this.dateComparison(lastpaydate, polcompleYMD)[2];
                                        }
                                        else
                                        {
                                            missingmonths = this.dateComparison(dateofdeath, polcompleYMD)[1];
                                            missingdays = this.dateComparison(dateofdeath, polcompleYMD)[2];
                                            missingyrs = this.dateComparison(lastpaydate, polcompleYMD)[0];
                                            missingmonths += missingyrs * 12;
                                        }
                                        //missingmonths = this.dateComparison(dateofdeath, polcompleYMD)[1]; //-- commented on 20070108
                                        //missingdays = this.dateComparison(dateofdeath, polcompleYMD)[2];   //-- commented on 20070108                                 
                                        //if ((this.dateComparison(dateofdeath, polcompleYMD)[2]) > 15) { missingmonths++; }
                                        //if (missingmonths > 0) { missingprems = missingmonths / xyz; }
                                        //if (MOD == 4 && missingdays > 15) { missingprems++; }
                                        //if (MOD != 4 && missingprems > 0 && (missingmonths % xyz) == 0) { --missingprems; }
                                        //if (MOD == 4) { missingprems++; }
                                        //commented on 20071229
                                    }
                                    else
                                    {
                                        demanddate = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2));

                                        //--- inserted on 20071219 ----
                                        lastpaydateYear = this.lastpayDateym(demanddate, MOD)[1];
                                        lastpaydateMonth = this.lastpayDateym(demanddate, MOD)[0];

                                        if (lastpaydateMonth < 10)
                                        {
                                            lastpaydate = int.Parse(lastpaydateYear.ToString() + "0" + lastpaydateMonth.ToString() + demanddate.ToString().Substring(6, 2));
                                        }
                                        else
                                        {
                                            lastpaydate = int.Parse(lastpaydateYear.ToString() + lastpaydateMonth.ToString() + demanddate.ToString().Substring(6, 2));
                                        }
                                        //-----

                                        missingmonths = this.dateComparison(dateofdeath, polcompleYMD)[1];
                                        //if ((this.dateComparison(dateofdeath, polcompleYMD)[2]) > 15) { missingmonths++; }
                                        //if (missingmonths > 0) { missingprems = missingmonths / xyz; }
                                        missingprems++;
                                    }

                                    #endregion
                                }
                            }

                            // ---- simplified logic ------
                            //if (MOD == 1) { missingprems = 0; }
                            //if (MOD == 2 && missingprems >= 2) { missingprems = 1; }
                            //if (MOD == 3 && missingprems >= 4) { missingprems = 3; }
                            //if (MOD == 4 && missingprems >= 12) { missingprems = 11; }
                            if (polcomyryn.Equals("Y"))
                            {
                                double payafdth = 0;
                                //amtComyr = missingprems * PRM;

                                #region-----------------check payments after Death-----------Dushan------
                                //int dthcom = int.Parse(dateofdthYM.ToString() + COM.ToString().Substring(6, 2));
                                //string ledgersel;
                                //if (dthcom >= dateofdeath)
                                //{
                                //    ledgersel = "select sum(LLPRM) from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldue||" + COM.ToString().Substring(6, 2) + " >= " + dateofdeath + " and lldue||" + COM.ToString().Substring(6, 2) + "<=" + polcompleYMD + "";
                                //}
                                //else
                                //{
                                //    ledgersel = "select sum(LLPRM) from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldue||" + COM.ToString().Substring(6, 2) + " > " + dateofdeath + " and lldue||" + COM.ToString().Substring(6, 2) + "<" + polcompleYMD + "";
                                //}
                                //if (dthpayObj.existRecored(ledgersel) != 0)
                                //{
                                //    dthpayObj.readSql(ledgersel);
                                //    OracleDataReader ledgerread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                //    while (ledgerread.Read())
                                //    {
                                //        if (!ledgerread.IsDBNull(0)) { payafdth = ledgerread.GetDouble(0); } else { payafdth = 0; }
                                //    }
                                //    ledgerread.Close();
                                //    ledgerread.Dispose();
                                //}
                                //amtComyr -= payafdth;
                                #endregion
                            }
                            else
                            {
                                amtComyr = 0;
                                _duesToPaycompletYear.Clear();
                            }

                            this.lblPCY.Text = missingprems.ToString();
                            this.lblACY.Text = String.Format("{0:N}", (double)(amtComyr));
                            //if (MOF.Equals("M")) { this.lblACY.Text = String.Format("{0:N}", (double)(missingprems * PRM)); }
                            //else { this.lblPCY.Text = "0"; this.lblACY.Text = "0.00"; }
                            //Table 56 Changes
                            //if ((TBL == 38 || TBL == 39 || TBL == 49) && (MOF.Equals("2")))
                            if ((TBL == 38 || TBL == 39 || TBL == 49 || TBL == 56) && (MOF.Equals("2")))
                            {
                                int inforceDuration = this.dateComparison(COM, dateofdeath)[0];
                                //if (ageofsecond < 15 || inforceDuration < 5)//changed according to court order 15477
                                if (fullageofSecond <= 14 || inforceDuration < 5)
                                {
                                    this.lblPCY.Text = "0";
                                    this.lblACY.Text = "0.00";
                                    amtComyr = 0.00;
                                    this.lblpremcompldyr.Text = "0";
                                    _duesToPaycompletYear.Clear();
                                }
                            }
                            if (TBL == 46 && MOF.Equals("2"))
                            {
                                this.lblPCY.Text = "0";
                                //this.lblACY.Text = "0.00";
                                //amtComyr = 0.00;
                                //this.lblpremcompldyr.Text = "0";
                                //_duesToPaycompletYear.Clear();
                            }
                            if ((TBL == 34 || TBL == 40) && MOF.Equals("C"))
                            {
                                this.lblPCY.Text = "0";
                                this.lblACY.Text = "0.00";
                                amtComyr = 0.00;
                                this.lblpremcompldyr.Text = "0";
                                _duesToPaycompletYear.Clear();
                            }

                            if ((TBL == 30 || TBL == 3) && MOF.Equals("M"))
                            {
                                this.lblPCY.Text = "0";
                                this.lblACY.Text = "0.00";
                                amtComyr = 0.00;
                                this.lblpremcompldyr.Text = "0";
                                _duesToPaycompletYear.Clear();
                            }

                            //Table 56 Changes
                            if (TBL == 56 && MOF.Equals("C"))
                            {
                                int inforceDuration = this.dateComparison(COM, dateofdeath)[0];
                                //if (ageofsecond < 15 || inforceDuration < 5)//changed according to court order 15477
                                if (fullageofSecond <= 14 || inforceDuration < 5)
                                {
                                    this.lblPCY.Text = "0";
                                    this.lblACY.Text = "0.00";
                                    amtComyr = 0.00;
                                    this.lblpremcompldyr.Text = "0";
                                    _duesToPaycompletYear.Clear();
                                }
                            }

                            //if ((TBL != 14 || TBL != 46) && (MOF.Equals("2")))
                            //{
                            //    lblvestedBonus.Text = "0.00";
                            //    lblinterimbons.Text = "0.00";
                            //}
                            #endregion
                        }

                        else
                        {
                            this.lblPCY.Text = "0";
                            this.lblACY.Text = "0.00";
                            amtComyr = 0.00;
                            _duesToPaycompletYear.Clear();
                        }

                        #region Amount to complete year Display by chandana
                        string _tmpStr = "";
                        foreach (long _lng in _duesToPaycompletYear)
                            _tmpStr += _lng.ToString().Substring(0, 4) + "/" + _lng.ToString().Substring(4, 2) + ",";
                        lbDuestoPay.Text = _tmpStr;

                        #endregion





                        #endregion

                        double ADB02 = 0;
                        double FPU02 = 0;

                        this.lblclmno.Text = claimno.ToString();
                        if (ADBlatepay.Equals("Y")) { this.lblADBliability.Visible = true; } else { this.lblADBliability.Visible = false; ADB02 = ADB; }
                        if (adbonexgr != null && adbonexgr.Equals("Y")) { this.lblADBonexgr.Visible = true; this.lblADBonexgr.Text = "ADB on Exgracia"; } else { this.lblADBonexgr.Visible = false; }
                        this.lbladb.Text = String.Format("{0:N}", (double)ADB);

                        if (FEearlyPay.Equals("Y")) { this.lblFEliability.Visible = true; } else { this.lblFEliability.Visible = false; FPU02 = FPU; }
                        this.lblfpu.Text = String.Format("{0:N}", (double)FPU);

                        if (STA.Equals("L"))
                        {
                            otherdeuct += thrstgamt;
                        }

                        this.lblsj.Text = String.Format("{0:N}", (double)SJ);
                        this.lblfe.Text = String.Format("{0:N}", (double)FE);

                        //task:22225 child bonus calculation
                        if ((tBL == 34 || tBL == 38 || tBL == 39 || tBL == 46 || tBL == 49) && MOF == "M")
                        {
                            //this.lblvestedBonus.Text = String.Format("{0:N}", vestedBonus) + " + Up to Maturity";
                            this.lblvestedBonus.Text = String.Format("{0:N}", 0);
                            //this.LiteralComm.Text = String.Format("{0:N}", 0);
                            //this.lblDateCom.Text = String.Format("{0:N}", 0);
                        }
                        else
                        {
                            this.lblvestedBonus.Text = String.Format("{0:N}", vestedBonus);
                            //this.LiteralBonus.Text = Convert.ToString(bonusEndDate);
                            //this.LiteralComm.Text = dateofdeath.ToString().Substring(0, 4);
                            //this.LiteralComm.Text = COM.ToString().Substring(0, 4);
                        }

                        this.lblinterimbons.Text = String.Format("{0:N}", interimBonus);
                        this.LiteralBonus2.Text = Convert.ToString(bonusEndDate);
                        this.LiteralDeath.Text = dateofdeath.ToString().Substring(0, 4);
                        this.lblsurrenderedbonus.Text = String.Format("{0:N}", surrrenderedbons);
                        this.lblbonsurryear.Text = bonussurrYr.ToString();
                        this.lbldefprems.Text = String.Format("{0:N}", demmands);
                        this.lblpremint.Text = String.Format("{0:N}", defint);
                        if (MOF.Equals("M"))
                        {
                            this.lblloancap.Text = String.Format("{0:N}", loancap);
                            this.lblloanint.Text = String.Format("{0:N}", loanint);
                        }
                        else
                        {
                            this.lblloancap.Text = "0.0";
                            this.lblloanint.Text = "0.0";
                        }
                        this.lblotheradditns.Text = String.Format("{0:N}", otheradd);

                        if (STA.Equals("L"))
                        {
                            this.lblotherdeduct.Text = String.Format("{0:N}", otherdeuct - thrstgamt);
                            this.lblStagePayDeduction.Text = String.Format("{0:N}", thrstgamt);
                        }
                        else
                        {
                            this.lblotherdeduct.Text = String.Format("{0:N}", otherdeuct);
                            this.lblStagePayDeduction.Text = String.Format("{0:N}", 0);
                        }



                        this.lblrefundofPrems.Text = String.Format("{0:N}", refOfPrems);
                        this.lbldeprefunds.Text = String.Format("{0:N}", deposit);
                        this.txtminutes.Text = minutes;
                        this.litagediff.Text = String.Format("{0:N}", ageDiffAmt);
                        this.litagediffIntst.Text = String.Format("{0:N}", agediffint);
                        double ageOverStAmt = 0;
                        double ageUnderStAmt = 0;

                        if (ageStatus.Equals("O")) { ageOverStAmt = ageDiffAmt; }
                        else if (ageStatus.Equals("U")) { ageUnderStAmt = ageDiffAmt; }

                        // ---- dependancy of life type ---
                        //if ((TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) || (STA.Equals("L") && TBL != 38))
                        if ((TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) || (STA.Equals("L") && TBL != 38 && TBL != 39 && TBL != 49))
                        {
                            switch (TBL)// 2011-05-31 jayampathi
                            {
                                case 34:
                                case 39:
                                    grossClm = sumassured + ADB02 + FPU02 + SJ + FE + refOfPrems + otheradd + deposit + ageOverStAmt;
                                    break;
                                default:
                                    grossClm = sumassured + ADB02 + FPU02 + SJ + FE + vestedBonus + interimBonus + refOfPrems + otheradd + deposit + ageOverStAmt;
                                    break;
                            }
                        }
                        else
                        {
                            grossClm = sumassured + ADB02 + FPU02 + SJ + FE + refOfPrems + otheradd + deposit + ageOverStAmt;
                            if (TBL != 38) { this.lblBonuspay.Text = "Bonus does not entitle to pay"; }
                            this.lblBonuspay.Visible = true;
                            if (((TBL == 46) || (TBL == 49)) && STA.Equals("I"))//Table 49 added to this condition on 19/10/2009 as Request of Indika.
                            {
                                this.lblBonuspay.Text = "Bonus will be paid at maturity";
                                this.lblBonuspay.Visible = true;
                            }

                            int inforceDuration = this.dateComparison(COM, dateofdeath)[0];
                            if ((TBL == 38 || TBL == 39 || TBL == 49) && (MOF.Equals("2") || MOF.Equals("C")))//Added child as per pradheephan on 12/02/2010
                            {
                                this.lblBonuspay.Visible = false;
                                //if ((ageofsecond >= 15 && inforceDuration >= 5)|| (STA.Equals("L")))//..Chage on 2009/05/15 ...Request of Pradeepan...
                                if ((fullageofSecond > 14 && inforceDuration >= 5) || (STA.Equals("L")))//..Chage on 2012/06/06 according to court decide Task 15477
                                {
                                    switch (TBL)// 2011-05-31 jayampathi
                                    {
                                        case 34:
                                        case 39: //by chandana 2012/02/24
                                            grossClm = MOF.Equals("2") ? sumassured + ADB02 + FPU02 + SJ + FE + refOfPrems + otheradd + deposit + ageOverStAmt + vestedBonus + interimBonus :
                                                sumassured + ADB02 + FPU02 + SJ + FE + refOfPrems + otheradd + deposit + ageOverStAmt;
                                            break;
                                        default:
                                            grossClm = sumassured + ADB02 + FPU02 + SJ + FE + vestedBonus + interimBonus + refOfPrems + otheradd + deposit + ageOverStAmt;
                                            break;
                                    }
                                }
                            }
                        }

                        //if(STA.Equals("L") && TBL== 39) // added by jayampathi 2011/08/22
                        //{
                        //    grossClm = sumassured + ADB02 + FPU02 + SJ + FE + vestedBonus + refOfPrems + otheradd + deposit + ageOverStAmt;
                        //}

                        //Table 39 & 49 added to this condition on 30/09/2013 as Task 20749.
                        //if (((TBL == 39) || (TBL == 49)) && STA.Equals("L"))
                        if (((TBL == 39) || (TBL == 49)) && STA.Equals("L") && MOF.Equals("M"))
                        {
                            grossClm = sumassured + ADB02 + FPU02 + SJ + FE + refOfPrems + otheradd + deposit + ageOverStAmt;

                            this.lblBonuspay.Text = "Bonus will be paid at maturity";
                            this.lblBonuspay.Visible = true;
                        }

                        this.lblgrossclaim.Text = String.Format("{0:N}", grossClm);

                        netclm = grossClm - (demmands + defint + loancap + loanint + surrrenderedbons + amtComyr + ageUnderStAmt + otherdeuct + ageDiffAmt + agediffint);
                        //if (MOF.Equals("M")) { netclm = grossClm - (demmands + defint + loancap + loanint + surrrenderedbons + (missingprems * PRM) + ageUnderStAmt); }
                        //else { netclm = grossClm - (demmands + defint + loancap + loanint + surrrenderedbons + ageUnderStAmt); }

                        //Task 29089
                        if (netclm < 0)
                        {
                            netclm = 0;
                        }

                        this.lbltot.Text = String.Format("{0:N}", netclm);
                        this.lblnetclaim.Text = String.Format("{0:N}", netclm);
                        this.lblamtoutst.Text = String.Format("{0:N}", outAmt);

                        if (memoaccept.Equals("Y"))
                        {
                            this.btnaccept.Visible = false;
                            this.btnPayshare.Visible = true;
                            lbDuestoPay.Text = "Paid at Authorization";
                        }
                        else
                        {
                            this.btnaccept.Visible = true;
                            this.btnPayshare.Visible = false;
                        }
                        if (assNomYN.Equals("")) { this.lblpayee.Text = ""; }
                        else if (assNomYN.Equals("Y")) { this.lblpayee.Text = "Assignee / Nominee"; lblpydis.Visible = true; }
                        else { this.lblpayee.Text = "Legal Heirs and/or Living Partner"; lblpydis.Visible = true; }
                    }
                    else
                    {
                        dthpayObj.connclose();
                        throw new Exception("No Death Reference Details!");
                    }

                    #endregion

                    #region //************** finantial limit check ******************************************

                    //long financialLimit = 0;
                    string EPF1 = Convert.ToString(dthpayObj.EpfCode(EPF));
                    string accssctrlSel = "select FINANTIAL_LIMIT from lphs.DTH_ACCESS_CTRL where epf = '" + EPF1.Trim() + "' and SYSTEM_ID = 'DTH' and FINANTIAL_LIMIT >= " + netclm + " ";
                    if (dthpayObj.existRecored(accssctrlSel) == 0)
                    {
                        //throw new Exception("This Claim Amount Exceeds Your Finantial Limit to Authorize");
                        if (this.btnaccept.Visible) { this.btnaccept.Enabled = false; }
                        this.lblacceptRestrict.Visible = true;
                    }
                    else { this.lblacceptRestrict.Visible = false; }

                    #endregion

                    #region Authorization check

                    if (dthpayObj.EpfCode(EPF) == dthpayObj.EpfCode(memoepf))
                    {

                        if (this.btnaccept.Visible)
                        {
                            this.btnaccept.Enabled = false;
                            this.lblacceptRestrict.Text = "Same Person cannot Create & Authorize the Voucher";
                            this.lblacceptRestrict.Visible = true;
                        }
                        //else
                        //    this.lblacceptRestrict.Text = "Claim already Authorized";

                        //this.lblacceptRestrict.Visible = true;
                        //if(!memoaccept.Equals("Y"))



                    }
                    #endregion



                    #region  //************** dreq ***********************************************************
                    bool existflag = false;
                    int reqCount = 0;
                    string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0 and (drrecdt = 0 or drrecdt is null) ";
                    if (dthpayObj.existRecored(dreqSelect) != 0)
                    {
                        dthpayObj.readSql(dreqSelect);
                        OracleDataReader dreqreader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dreqreader.Read())
                        {
                            existflag = true; reqCount++;
                        }
                        dreqreader.Close();
                        dreqreader.Dispose();
                    }
                    if (existflag) { this.lblmissingReq.Text = "There are " + reqCount.ToString() + " Requirement/s Not Yet Recieved"; }

                    #endregion

                    #region //-------------- Payee Details ---------------------

                    #region
                    string ASS_STATUS = "";
                    string ASS_FULLNAME = "";
                    string ASS_AD1 = "";
                    string ASS_AD2 = "", ASS_AD3 = "", ASS_AD = "";
                    long ACCT_NO = 0;
                    int rows2 = 0;
                    string LHHIRE = "";
                    string LHNAME = "";
                    string LHAD1 = "";
                    string LHAD2 = "";
                    string LHAD3 = "";
                    string LHAD4 = "";
                    int LHDOB = 0;
                    string LHMST = "";
                    double LHSHARE = 0;
                    if (payee == "ASI")
                    {
                        #region Assignee Details
                        string prassigneeSelect = "select ASS_STATUS, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, ASS_AD3 from LUND.ASSIGNEE where policy_no = " + polno + " ";
                        if (dthpayObj.existRecored(prassigneeSelect) != 0)
                        {
                            this.lblpayee.Text = "Assignee";
                            thePayee = "ASI";
                            lblpydis.Visible = true;
                            dthpayObj.readSql(prassigneeSelect);
                            OracleDataReader prassigneeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (prassigneeReader.Read())
                            {
                                rows2++;
                                if (!prassigneeReader.IsDBNull(0)) { ASS_STATUS = prassigneeReader.GetString(0); }
                                if (!prassigneeReader.IsDBNull(1)) { ASS_FULLNAME = prassigneeReader.GetString(1); }
                                if (!prassigneeReader.IsDBNull(2)) { ASS_AD1 = prassigneeReader.GetString(2); }
                                if (!prassigneeReader.IsDBNull(3)) { ASS_AD2 = prassigneeReader.GetString(3); }
                                if (!prassigneeReader.IsDBNull(5)) { ACCT_NO = prassigneeReader.GetInt64(5); }
                                if (!prassigneeReader.IsDBNull(6)) { ASS_AD3 = prassigneeReader.GetString(6); }

                                string theName = ASS_STATUS + " " + ASS_FULLNAME;
                                string theAddrs = ASS_AD1 + " " + ASS_AD2 + " " + ASS_AD3;

                                this.createAssigneeTable(theName, theAddrs, ACCT_NO, rows2);
                            }
                            prassigneeReader.Close();
                            prassigneeReader.Dispose();
                        }
                        #endregion
                    }
                    #region Nominee Details
                    else if (payee == "NOM")
                    {
                        int rows3 = 0;
                        this.lblpayee.Text = "Nominee";
                        thePayee = "NOM";
                        lblpydis.Visible = true;
                        string nomineeSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER   from lund.nominee where polno=" + polno + " ";
                        if (dthpayObj.existRecored(nomineeSelect) != 0)
                        {
                            TableHeaderRow tbhrw = new TableHeaderRow();
                            TableHeaderCell thcl = new TableHeaderCell();
                            TableHeaderCell thc2 = new TableHeaderCell();
                            TableHeaderCell thc3 = new TableHeaderCell();
                            TableHeaderCell thc4 = new TableHeaderCell();
                            thcl.Text = "Name"; thc2.Text = "Date of Birth";
                            thc3.Text = "NIC Number"; thc4.Text = "Percentage";
                            tbhrw.Controls.Add(thcl); tbhrw.Controls.Add(thc2);
                            tbhrw.Controls.Add(thc3); tbhrw.Controls.Add(thc4);
                            Table1.Controls.Add(tbhrw);
                            dthpayObj.readSql(nomineeSelect);
                            OracleDataReader nomineeReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); }
                                if (!nomineeReader.IsDBNull(2)) { DOB = nomineeReader.GetInt32(2); }
                                if (!nomineeReader.IsDBNull(3)) { NIC = nomineeReader.GetString(3); }
                                if (!nomineeReader.IsDBNull(4)) { PER = nomineeReader.GetDouble(4); }
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
                                createNomineeTable(NOMNAME, PER.ToString(), rows3, DOB, NIC);
                                rows3++;
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                        }

                    }
                    #endregion

                    #endregion

                    else if (payee == "LPT")
                    {
                        #region


                        if (TBL == 14)
                        {
                            this.lblpayee.Text = "Living Partner";
                            thePayee = "LPT";
                            lblpydis.Visible = true;
                            string NOMAD1 = "";
                            string NOMAD2 = "";
                            string NOMAD3 = "";
                            string NOMAD4 = "";
                            string livingPrtSel = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.LIVING_PRT  where polno = " + polno + " ";
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
                                    if (!livingPrtReader.IsDBNull(6)) { NOMAD3 = livingPrtReader.GetString(6); }
                                    if (!livingPrtReader.IsDBNull(7)) { NOMAD4 = livingPrtReader.GetString(7); }
                                    if (DOB == 0)
                                    {
                                        if (rows == 1)
                                        {
                                            PayeeName = NOMNAME;
                                        }
                                        else
                                        {
                                            PayeeName = PayeeName + "," + NOMNAME;
                                        }
                                        this.lbl_nominees.Text = "Please Enter the Date of Birth for  " + PayeeName + " Before Generating the Discharge Forms";
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
                                    string theAddress = NOMAD1 + " " + NOMAD2 + " " + NOMAD3 + " " + NOMAD4;
                                    this.createLivingPrtTable(NOMNAME, theAddress, DOB.ToString(), NIC, PER.ToString(), rows);
                                }
                                livingPrtReader.Close();
                                livingPrtReader.Dispose();
                            }
                        }
                    }
                    else
                    {
                        if (payee == "")
                        {
                            this.lblpayee.Text = "";
                            thePayee = "";
                        }
                        else
                        {
                            lblpydis.Visible = true;
                            this.lblpayee.Text = "Legal Heires";
                            thePayee = "LHI";
                        }

                        ////GridView1.DataSourceID = "SqlDataSource1";
                        //GridView1.DataBind();
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
                                if (LHDOB == 0)
                                {
                                    if (loopCount == 1)
                                    {
                                        PayeeName = LHNAME;
                                    }
                                    else
                                    {
                                        PayeeName = PayeeName + "," + LHNAME;
                                    }
                                    this.lbl_legalhrs.Text = "Please Enter the Date of Birth for  " + PayeeName + " Before Generating the Discharge Forms";
                                }
                                else
                                {
                                    if (LHDOB.ToString().Length == 8)
                                    {
                                        string yr = LHDOB.ToString().Substring(0, 4);
                                        string mn = LHDOB.ToString().Substring(4, 2);
                                        string dt = LHDOB.ToString().Substring(6, 2);

                                        DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                                        DateTime today = DateTime.Now;
                                        TimeSpan diff = today.Subtract(Bdate);
                                        PayeeAge = (int)diff.TotalDays / 365;
                                    }
                                }

                                if (LHMST.Equals("M")) { LHMST = "Married"; }
                                else { if (!LHHIRE.Equals("Spouce") && !LHHIRE.Equals("Mother") && !LHHIRE.Equals("Father")) { LHMST = "Unmarried"; } }

                                //this.createHeireTable(LHHIRE, LHNAME, LHAD1, LHDOB.ToString(), LHMST, LHSHARE, loopCount);
                            }

                            legalHiereReader.Close();
                            legalHiereReader.Dispose();
                        }
                    }
                    #endregion


                    #endregion

                    //if (STA.Equals("L"))
                    //{
                    //    Sumassured += thrstgamt;
                    //}

                    this.lblsumassured.Text = String.Format("{0:N}", sumassured);

                    //************* sum assured calculation **********************************

                    //totbons=vestedBonus+interimBonus-surrrenderedbons;
                    //inforceDuration = this.dateComparison(dateofdeath, COM)[0];
                    //paidPremcount = this.premcount(COM, dateofdeath, MOD, polno);


                    #region Task 34965
                    //Task 34965 ==============================================
                    //dateofdeath,COM,MOD,PRM,polcompleYM
                    if (memoaccept.Equals("Y"))
                    {
                        //amtComyr = amtComyr + deductAmount;
                        this.lblACY.Text = String.Format("{0:N}", (double)(amtComyr + deductAmount));

                        netclm = netclm - deductAmount;
                        this.lblnetclaim.Text = String.Format("{0:N}", netclm);
                        this.lbltot.Text = String.Format("{0:N}", netclm);


                        //Inforced Changes 
                        if (STA.Equals("I") && MOF.Equals("M"))
                        {
                            netclm = netclm + stagePayment;
                            grossClm = grossClm + stagePayment;
                            lblStgPmnt.Text = String.Format("{0:N}", stagePayment);
                            this.lblgrossclaim.Text = String.Format("{0:N}", grossClm);
                            this.lblnetclaim.Text = String.Format("{0:N}", netclm);
                            this.lbltot.Text = String.Format("{0:N}", netclm);
                        }
                    }
                    else
                    {
                        int yearcomdue = 0;
                        if (polcompleYM != null)
                        {
                            yearcomdue = Convert.ToInt32(polcompleYM.Replace("/", ""));
                        }

                        if (MOD != 5)
                        {
                            int lstpaiddue = 0;
                            deductAmount = 0;
                            //string checklastedue = "select nvl(max(LLDUE), 0) from LCLM.LEDGER where LLPOL = '" + polno + "' and LLDUE <= " + Convert.ToInt32(dateofdeath.ToString().Substring(0, 6)) + "";
                            string checklastedue = "select DRPAID_DUE from lphs.dthref where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";
                            if (dthpayObj.existRecored(checklastedue) != 0)
                            {
                                dthpayObj.readSql(checklastedue);
                                OracleDataReader checkduereader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                checkduereader.Read();
                                if (!checkduereader.IsDBNull(0)) { lstpaiddue = checkduereader.GetInt32(0); } else { lstpaiddue = 0; }
                                checkduereader.Close();
                                checkduereader.Dispose();
                            }

                            //if(lstpaiddue == 0)
                            //{
                            int paiddue = 0;
                            //string getpaiddue = "select nvl(max(LLDUE), 0) from LCLM.LEDGER where LLPOL = '" + polno + "' ";//polno
                            string getpaiddue = "select nvl(max(LLDUE), 0) from LCLM.LEDGER where LLPOL = '" + polno + "' and LLDAT<=" + dateofdeath + "";//polno
                            if (dthpayObj.existRecored(getpaiddue) != 0)
                            {
                                dthpayObj.readSql(getpaiddue);
                                OracleDataReader checkduereader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                checkduereader.Read();
                                if (!checkduereader.IsDBNull(0)) { paiddue = checkduereader.GetInt32(0); } else { paiddue = 0; }
                                checkduereader.Close();
                                checkduereader.Dispose();
                            }

                            if (paiddue != 0)
                            {
                                lstpaiddue = paiddue;
                                DataManager dthpayUpdate = new DataManager();
                                dthpayUpdate.begintransaction();
                                string dthrefInsert = @"UPDATE LPHS.DTHREF SET DRPAID_DUE = '" + paiddue + "' where drpolno=" + polno + " and drmos='" + MOF + "' ";
                                dthpayUpdate.insertRecords(dthrefInsert);
                                dthpayUpdate.commit();
                                dthpayUpdate.connclose();
                            }

                            //}


                            int checkdue = lstpaiddue;
                            if (lstpaiddue != 0 && !isPremiumWave)
                            {
                                do
                                {
                                    double payprm = 0;
                                    int nextDue = getNextDue(MOD, checkdue);

                                    if (nextDue <= yearcomdue)
                                    {
                                        string checkLedger = "select LLPRM from lclm.ledger where LLPOL='" + polno + "' and lldue='" + nextDue + "' union select LLPRM from lclm.ledger_dth where LLPOL='" + polno + "' and lldue='" + nextDue + "' ";

                                        if (dthpayObj.existRecored(checkLedger) != 0)
                                        {
                                            dthpayObj.readSql(checkLedger);
                                            System.Data.OracleClient.OracleDataReader dr = dthpayObj.oraComm.ExecuteReader();
                                            while (dr.Read())
                                            {
                                                if (!dr.IsDBNull(0)) { payprm += dr.GetInt32(0); }
                                            }
                                            dr.Close();
                                        }

                                        if (payprm != 0 && payprm < PRM)
                                        {
                                            deductAmount += PRM - payprm;
                                        }
                                    }
                                    checkdue = nextDue;

                                } while (checkdue <= yearcomdue);
                            }

                            //==========
                            if (amtComyr > 0)
                            {
                                int duecount = _duesToPaycompletYear.Count;

                                double amtTobePaid = PRM * duecount;

                                if (amtComyr < amtTobePaid)
                                {
                                    deductAmount = deductAmount + (amtTobePaid - amtComyr);
                                }
                            }
                            //===============

                            //amtComyr = amtComyr + deductAmount;
                            this.lblACY.Text = String.Format("{0:N}", (double)(amtComyr + deductAmount));

                            netclm = netclm - deductAmount;
                            this.lblnetclaim.Text = String.Format("{0:N}", netclm);
                            this.lbltot.Text = String.Format("{0:N}", netclm);

                            //task 36958 add table 59 
                            //Inforced Changes 
                            stagePayment = 0;
                            if (STA.Equals("I") && MOF.Equals("M") && (TBL == 13|| TBL == 59))
                            {
                                string vouno = "";
                                int voudat = 0;
                                int docno = 0;
                                double payamount = 0;
                                string yearstr = "";
                                string lclmmastSel = "select pvouno, pvoudat, pdocno,PPAYAMT,substr(STAGE_DATE,0,4) from lclm.lcmmast where ptyp = 2 and ppolno = " + polno + " and pdocno > 0 and (pvouno is null or pvoudat=0 or pvouno='')";
                                if (dthpayObj.existRecored(lclmmastSel) != 0)
                                {
                                    dthpayObj.readSql(lclmmastSel);
                                    OracleDataReader lclmmastread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    while (lclmmastread.Read())
                                    {
                                        if (!lclmmastread.IsDBNull(0)) { vouno = lclmmastread.GetString(0); } else { vouno = ""; }
                                        if (!lclmmastread.IsDBNull(1)) { voudat = lclmmastread.GetInt32(1); } else { voudat = 0; }
                                        if (!lclmmastread.IsDBNull(2)) { docno = lclmmastread.GetInt32(2); } else { docno = 0; }
                                        if (!lclmmastread.IsDBNull(3))
                                        {
                                            payamount = payamount + lclmmastread.GetInt32(3);
                                        }
                                        if (!lclmmastread.IsDBNull(4))
                                        {
                                            if (yearstr != "")
                                            {
                                                yearstr += ", ";
                                            }
                                            yearstr += lclmmastread.GetString(4);
                                        }
                                    }
                                    lclmmastread.Close();
                                    lclmmastread.Dispose();

                                    //if (docno > 0 && (voudat == 0 || (vouno == null || vouno.Equals(""))))
                                    //{
                                    stagePayment = payamount;
                                    netclm = netclm + stagePayment;
                                    grossClm = grossClm + stagePayment;
                                    stageyearString = yearstr;
                                    //}
                                    //else
                                    //{
                                    //stagePayment = 0;
                                    //}
                                    lblStgPmnt.Text = String.Format("{0:N}", stagePayment);
                                    this.lblgrossclaim.Text = String.Format("{0:N}", grossClm);
                                    this.lblnetclaim.Text = String.Format("{0:N}", netclm);
                                    this.lbltot.Text = String.Format("{0:N}", netclm);

                                }
                            }
                        }
                    }





                    //=========================================================
                    #endregion
                }
                else
                {
                    dthpayObj.connclose();
                    throw new Exception("No Terminated Policy Details Found!");
                }

                backCalculation(dthpayObj);

                dthpayObj.connclose();

                #region //---------- view state --------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                Session["MOF"] = MOF;
                ViewState["infodat"] = infodat;
                ViewState["dateofdeath"] = dateofdeath;
                Session["dateofdeath"] = dateofdeath;
                ViewState["nameOfDead"] = nameOfDead;
                Session["NameDead"] = nameOfDead;
                ViewState["COD"] = COD;
                ViewState["POL"] = POL;
                ViewState["COM"] = COM;
                ViewState["TBL"] = TBL;
                ViewState["TRM"] = TRM;
                ViewState["SUM"] = SUM;
                ViewState["MOD"] = MOD;
                ViewState["PRM"] = PRM;
                ViewState["DUE"] = DUE;
                ViewState["STA"] = STA;

                ViewState["ADB"] = ADB;
                ViewState["FPU"] = FPU;
                ViewState["SJ"] = SJ;
                ViewState["FE"] = FE;
                ViewState["FEearlyPay"] = FEearlyPay;
                ViewState["ADBlatepay"] = ADBlatepay;

                Session["ADB"] = ADB;
                Session["FPU"] = FPU;
                Session["SJ"] = SJ;
                Session["FE"] = FE;

                ViewState["reinsYN"] = reinsYN;
                ViewState["vestedBonus"] = vestedBonus;
                ViewState["bonusEndDate"] = bonusEndDate;
                ViewState["interimBonus"] = interimBonus;
                ViewState["totbons"] = totbons;
                ViewState["surrrenderedbons"] = surrrenderedbons;
                ViewState["bonussurrYr"] = bonussurrYr;
                ViewState["netsurrAmt"] = netsurrAmt;
                ViewState["claimno"] = claimno;
                ViewState["deposit"] = deposit;
                ViewState["demmands"] = demmands;
                ViewState["defint"] = defint;
                ViewState["loancap"] = loancap;
                ViewState["loanint"] = loanint;
                ViewState["missingprems"] = missingprems;

                ViewState["amtComyr"] = amtComyr;
                ViewState["polcompleYM"] = polcompleYM;
                Session["PolicyComYr"] = polcompleYM;
                ViewState["sumassDesc"] = sumassDesc;

                ViewState["ageStatus"] = ageStatus;
                ViewState["ageDiffAmt"] = ageDiffAmt;
                ViewState["minutes"] = minutes;

                ViewState["totamount"] = totamount;
                ViewState["thePayee"] = thePayee;
                ViewState["refOfPrems"] = refOfPrems;

                ViewState["grossClm"] = grossClm;
                ViewState["netclm"] = netclm;
                ViewState["outAmt"] = outAmt;
                ViewState["sumassured"] = sumassured;
                ViewState["otherdeuct"] = otherdeuct;
                ViewState["thrstgamt"] = thrstgamt;

                ViewState["otheradd"] = otheradd;//Add on 2009/04/21...
                ViewState["polcompleYMD"] = polcompleYMD;
                ViewState["missingprems"] = missingprems;
                Session["missingprems"] = missingprems;
                ViewState["EPF"] = EPF;
                ViewState["branch"] = branch;
                ViewState["memoepf"] = memoepf;
                ViewState["interest"] = interest;
                ViewState["PremumPayDues"] = _duesToPaycompletYear;
                ViewState["PAC"] = PAC;
                ViewState["agediffint"] = agediffint;

                Session["ageStatus"] = ageStatus;
                Session["ageDiffAmt"] = ageDiffAmt;
                Session["sumassured"] = sumassured;
                Session["deposit"] = deposit;

                Session["demmands"] = demmands;
                Session["defint"] = defint;
                Session["loancap"] = loancap;
                Session["loanint"] = loanint;

                Session["otherdeuct"] = otherdeuct;
                Session["thrstgamt"] = thrstgamt;
                Session["grossClm"] = grossClm;
                Session["netclm"] = netclm;

                
                ViewState["interimBonStYr"] = interimBonStYr;

                ViewState["deductAmount"] = deductAmount;
                ViewState["stagePayment"] = stagePayment;
                Session["deductAmount"] = deductAmount;
                ViewState["stageyearString"] = stageyearString;


                //Session["loanint"] = loanint;

                #endregion

                // Loan Back calculation methord call 
                // create by Roshan 2012/03//03

                if (status == "1")
                {
                    this.lblsuccess.Text = "Memo Accepted";
                }

            }
            catch (Exception ex)
            {
                dthpayObj.connclose();
                EPage.Messege = ex.ToString();
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            #region //------------- view state -------------
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["infodat"] != null) { infodat = int.Parse(ViewState["infodat"].ToString()); }
            if (ViewState["dateofdeath"] != null) { dateofdeath = int.Parse(ViewState["dateofdeath"].ToString()); }
            if (ViewState["nameOfDead"] != null) { nameOfDead = ViewState["nameOfDead"].ToString(); }

            if (ViewState["COD"] != null) { COD = ViewState["COD"].ToString(); }
            if (ViewState["POL"] != null) { POL = int.Parse(ViewState["POL"].ToString()); }
            if (ViewState["COM"] != null) { COM = int.Parse(ViewState["COM"].ToString()); }
            if (ViewState["TBL"] != null) { TBL = int.Parse(ViewState["TBL"].ToString()); }
            if (ViewState["TRM"] != null) { TRM = int.Parse(ViewState["TRM"].ToString()); }
            if (ViewState["SUM"] != null) { SUM = int.Parse(ViewState["SUM"].ToString()); }
            if (ViewState["MOD"] != null) { MOD = int.Parse(ViewState["MOD"].ToString()); }
            if (ViewState["PRM"] != null) { PRM = double.Parse(ViewState["PRM"].ToString()); }
            if (ViewState["DUE"] != null) { DUE = int.Parse(ViewState["DUE"].ToString()); }
            if (ViewState["STA"] != null) { STA = ViewState["STA"].ToString(); }

            if (ViewState["ADB"] != null) { ADB = double.Parse(ViewState["ADB"].ToString()); }
            if (ViewState["FPU"] != null) { FPU = double.Parse(ViewState["FPU"].ToString()); }
            if (ViewState["SJ"] != null) { SJ = double.Parse(ViewState["SJ"].ToString()); }
            if (ViewState["FE"] != null) { FE = double.Parse(ViewState["FE"].ToString()); }
            if (ViewState["FEearlyPay"] != null) { FEearlyPay = ViewState["FEearlyPay"].ToString(); }
            if (ViewState["ADBlatepay"] != null) { ADBlatepay = ViewState["ADBlatepay"].ToString(); }

            if (ViewState["reinsYN"] != null) { reinsYN = ViewState["reinsYN"].ToString(); }
            if (ViewState["vestedBonus"] != null) { vestedBonus = double.Parse(ViewState["vestedBonus"].ToString()); }
            if (ViewState["interimBonus"] != null) { interimBonus = double.Parse(ViewState["interimBonus"].ToString()); }
            if (ViewState["totbons"] != null) { totbons = double.Parse(ViewState["totbons"].ToString()); }
            if (ViewState["surrrenderedbons"] != null) { surrrenderedbons = double.Parse(ViewState["surrrenderedbons"].ToString()); }
            if (ViewState["bonussurrYr"] != null) { bonussurrYr = int.Parse(ViewState["bonussurrYr"].ToString()); }
            if (ViewState["netsurrAmt"] != null) { netsurrAmt = double.Parse(ViewState["netsurrAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["deposit"] != null) { deposit = double.Parse(ViewState["deposit"].ToString()); }
            if (ViewState["demmands"] != null) { demmands = double.Parse(ViewState["demmands"].ToString()); }
            if (ViewState["defint"] != null) { defint = double.Parse(ViewState["defint"].ToString()); }
            if (ViewState["loancap"] != null) { loancap = double.Parse(ViewState["loancap"].ToString()); }
            if (ViewState["loanint"] != null) { loanint = double.Parse(ViewState["loanint"].ToString()); }
            if (ViewState["missingprems"] != null) { missingprems = int.Parse(ViewState["missingprems"].ToString()); }
            if (ViewState["amtComyr"] != null) { amtComyr = double.Parse(ViewState["amtComyr"].ToString()); }

            if (ViewState["polcompleYM"] != null) { polcompleYM = ViewState["polcompleYM"].ToString(); }
            if (ViewState["sumassDesc"] != null) { sumassDesc = ViewState["sumassDesc"].ToString(); }

            if (ViewState["ageStatus"] != null) { ageStatus = ViewState["ageStatus"].ToString(); }
            if (ViewState["ageDiffAmt"] != null) { ageDiffAmt = double.Parse(ViewState["ageDiffAmt"].ToString()); }
            if (ViewState["agediffint"] != null) { agediffint = double.Parse(ViewState["agediffint"].ToString()); }
            if (ViewState["minutes"] != null) { minutes = ViewState["minutes"].ToString(); }

            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["thePayee"] != null) { thePayee = ViewState["thePayee"].ToString(); }
            if (ViewState["refOfPrems"] != null) { refOfPrems = double.Parse(ViewState["refOfPrems"].ToString()); }
            if (ViewState["grossClm"] != null) { grossClm = double.Parse(ViewState["grossClm"].ToString()); }
            if (ViewState["netclm"] != null) { netclm = double.Parse(ViewState["netclm"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["sumassured"] != null) { sumassured = double.Parse(ViewState["sumassured"].ToString()); }
            if (ViewState["otherdeuct"] != null) { otherdeuct = double.Parse(ViewState["otherdeuct"].ToString()); }
            if (ViewState["thrstgamt"] != null) { thrstgamt = double.Parse(ViewState["thrstgamt"].ToString()); }
            if (ViewState["otheradd"] != null) { otheradd = double.Parse(ViewState["otheradd"].ToString()); }//Add on 2009/04/21 by Buddhika
            if (ViewState["polcompleYMD"] != null) { polcompleYMD = int.Parse(ViewState["polcompleYMD"].ToString()); }
            if (ViewState["missingprems"] != null) { missingprems = int.Parse(ViewState["missingprems"].ToString()); }
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
            if (ViewState["branch"] != null) { branch = int.Parse(ViewState["branch"].ToString()); }
            if (ViewState["memoepf"] != null) { memoepf = ViewState["memoepf"].ToString(); }
            if (ViewState["interest"] != null) { interest = double.Parse(ViewState["interest"].ToString()); }
            if (ViewState["PremumPayDues"] != null) { _duesToPaycompletYear = (List<long>)ViewState["PremumPayDues"]; }

            if (ViewState["PAC"] != null) { PAC = int.Parse(ViewState["PAC"].ToString()); }

            if (ViewState["interimBonStYr"] != null) { interimBonStYr = int.Parse(ViewState["interimBonStYr"].ToString()); }

            if (ViewState["deductAmount"] != null) { deductAmount = double.Parse(ViewState["deductAmount"].ToString()); }
            if (ViewState["stagePayment"] != null) { stagePayment = double.Parse(ViewState["stagePayment"].ToString()); }

            if (ViewState["netclm_bfstamp"] != null) { netclm_bfstamp = double.Parse(ViewState["netclm_bfstamp"].ToString()); }
            if (ViewState["stamp_duty"] != null) { stamp_duty = double.Parse(ViewState["stamp_duty"].ToString()); }

            if (ViewState["havePayment"] != null) { havePayment = int.Parse(ViewState["havePayment"].ToString()); }
            if (ViewState["havePaymentWarring"] != null) { havePaymentWarring = ViewState["havePaymentWarring"].ToString(); }
            if (ViewState["stageyearString"] != null) { stageyearString = ViewState["stageyearString"].ToString(); }

            #endregion

        }
    }

    protected void btnaccept_Click(object sender, EventArgs e)
    {
        if (Session["approveCLiked"] == "0")
        {
            Session["approveCLiked"] = "1";
            dthpayObj = new DataManager();
            string Availability = "N";
            //DataManager dm = new DataManager();
            gg = new General();
            table56 = new Table56();
            int tmpDue = 0;
            int endoNo = 0;
            int polCompDue = 0;
            int demCount = 1;
            try
            {
                dthpayObj.begintransaction();

                int rcptno1 = 0;
                int paycount = 0;
                string paycuntqury = "select count(*) from lpay.lpaymas_dth  where claimno='" + claimno + "'";
                dthpayObj.readSql(paycuntqury);
                OracleDataReader paycountreader = dthpayObj.oraComm.ExecuteReader();
                if (paycountreader.Read())
                {
                    rcptno1 = paycountreader.GetInt32(0);
                    paycountreader.Close();
                    paycountreader.Dispose();
                }

                if (paycount > 0)
                {
                    for (int i = 1; i <= paycount; i++)
                    {
                        #region----------------Receipt No--------------------------

                        //..................Cange on 2008/08/21 by buddhika Write to LPYMAS to Generate receipt No.
                        int newsurryear1 = int.Parse(setDate()[0].Substring(0, 4));
                        string rcptnoquery1 = "SELECT RCNO FROM  LPAY.RCPTNO WHERE (RCBRNO = " + branch + ") AND (RCYEAR = " + newsurryear1 + ") AND (RCTYPE = 11)";
                        dthpayObj.readSql(rcptnoquery1);
                        OracleDataReader rcptReader = dthpayObj.oraComm.ExecuteReader();
                        if (rcptReader.Read())
                        {
                            rcptno1 = rcptReader.GetInt32(0);
                            rcptReader.Close();
                            rcptReader.Dispose();
                        }
                        else
                        {
                            rcptno1 = 1;
                        }
                        #endregion

                        if (dthpayObj.existRecored(rcptnoquery1) == 0)
                        {
                            string inertRcptnoquery = "insert into LPAY.RCPTNO (RCBRNO, RCYEAR, RCTYPE, RCNO) values(" + branch + "," + newsurryear1 + ",11," + rcptno1 + " )";
                            dthpayObj.insertRecords(inertRcptnoquery);
                        }
                        else
                        {
                            string updRcptnoquery1 = "update LPAY.RCPTNO set RCNO=" + rcptno1 + " where RCBRNO=" + branch + " and RCYEAR=" + newsurryear1 + "  and RCTYPE= 11 ";
                            dthpayObj.insertRecords(updRcptnoquery1);
                        }

                        #region Update Payment
                        //...LPAY.LPAYCOM....
                        string lpaycomInsertdth = "INSERT INTO LPAY.LPAYCOM (LCPBR ,LCPDT ,LCBTP ,LCPOL ,LCDUE ,LCTBL ,LCTRM ,LCMOD ,LCPRM ,LCCDT ,LCCOD ,LCPAC ,LCAGT ,LCORG ,LCSBR , LCREC, LCLATEFEE ) " +
                            "select LCPBR ," + int.Parse(this.setDate()[0]) + " ,LCBTP ,LCPOL ,LCDUE ,LCTBL ,LCTRM ,LCMOD ,LCPRM ,LCCDT ,LCCOD ,LCPAC ,LCAGT ,LCORG ,LCSBR , '" + rcptno1 + "', LCLATEFEE from LPAY.LPAYCOM_DTH where claimno='" + claimno + "' and rec_id='" + i + "'";

                        dthpayObj.insertRecords(lpaycomInsertdth);

                        //.....LCLM.LEDGER.....
                        string ledgerInsertdth = "insert into lclm.ledger (LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT, LLPBR, LLREC) " +
                                        "select LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, " + int.Parse(this.setDate()[0]) + ", LLPBR, '" + rcptno1 + "' from lclm.ledger_dth where claimno='" + claimno + "' and rec_id='" + i + "'";
                        dthpayObj.insertRecords(ledgerInsertdth);

                        //.........LPAY.LPAYMAS.......
                        string lpaymasInsertSQLsth = "insert into lpay.lpaymas (lpbrn, lpptd, lpbtp, lprec, lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, lpedt, lptim, lpipa, lpacd, lpopr, lpcur, lpcrt) " +
                            "select  lpbrn, " + int.Parse(setDate()[0]) + ", lpbtp, '" + rcptno1 + "', lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, " + int.Parse(setDate()[0]) + ", '" + DateTime.Now.ToLongTimeString() + "',  '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', lpacd, " + dthpayObj.EpfCode(EPF) + ", lpcur, lpcrt from lpay.lpaymas_dth  where claimno='" + claimno + "' and rec_id='" + i + "'";
                        dthpayObj.insertRecords(lpaymasInsertSQLsth);
                        #endregion
                    }

                }
                string deleteLpaycomtemp = "delete from LPAY.LPAYCOM_DTH where claimno='" + claimno + "'";
                dthpayObj.insertRecords(deleteLpaycomtemp);
                string deleteledgertemp = "delete from lclm.ledger_dth where claimno='" + claimno + "'";
                dthpayObj.insertRecords(deleteledgertemp);
                string deletelpaymastemp = "delete from lpay.lpaymas_dth  where claimno='" + claimno + "'";
                dthpayObj.insertRecords(deletelpaymastemp);
                //rcptReader.Close();
                //rcptReader.Dispose();


                //Task 31145
                //string dthrefUpd = "update lphs.dthref set DRGROSSCLM = " + grossClm + ", DRNETCLM =" + netclm + ", MEMOAPRV = 'Y', APRVDATE = " + int.Parse(this.setDate()[0]) + ", " +
                //    " APRVEPF = '" + EPF + "', POL_COMPLETED = " + polcompleYMD + ", AMT_TO_COMPLETE = " + amtComyr + " where drpolno =  " + polno + " and drmos = '" + MOF + "' ";
                string dthrefUpd = "update lphs.dthref set DRGROSSCLM = " + grossClm + ", DRNETCLM =" + netclm + ", MEMOAPRV = 'Y', APRVDATE = " + int.Parse(this.setDate()[0]) + ", " +
                " APRVEPF = '" + EPF + "', POL_COMPLETED = " + polcompleYMD + ", AMT_TO_COMPLETE = " + amtComyr + ", DRDEPOSITS=" + deposit + ",DIFF_DEDUCT=" + deductAmount + ",STAGE_PAYMENT=" + stagePayment + ",STAGE_PAYMENT_STR='"+stageyearString+"' where drpolno =  " + polno + " and drmos = '" + MOF + "' ";
                dthpayObj.insertRecords(dthrefUpd);

                #region payMemoRemind by chalaka

                string updateRemindDCT = "UPDATE LPHS.DCT_REMINDERALERT " +
                                              "  SET    " +
                                                "       REMINDSTATUS   = 1 " +

                                             "   WHERE  POLNO=" + Polno + " AND LIFETYPE=decode('" + MOF + "','M',1,'S',2,'2',3,'C',4)  AND PAYMEMORMND=1 ";
                dthpayObj.insertRecords(updateRemindDCT);
                #endregion

                //dthpayObj.connclose();
                this.lblsuccess.Text = "Memo Accepted";

                memoaccept = "Y";
                if (memoaccept.Equals("Y"))
                {
                    Session["memoaccept"] = "Y";
                    this.btnaccept.Visible = false;
                    this.btnPayshare.Visible = true;

                }
                else
                {
                    this.btnaccept.Visible = true;
                    this.btnPayshare.Visible = false;
                }
                gg.PaidNo(polno, "DRADMITNO", MOF, dthpayObj);
                if (deposit > 0)
                {
                    gg.Write_Deposit_Adjestment(branch, polno, Context.Request.ServerVariables["REMOTE_ADDR"].ToString(), gg.StrToNumFilter(EPF), dthpayObj);
                }

                #region--------------------------Writing on Payment Files---by chandana-------------------

                #region ----------------------- Table 56 Changes -----------------------------------------
                if (TBL == 56 && MOF == "M")
                {
                    string premSQLUpdate = "";
                    bool isOccex = false;
                    bool isHex = false;
                    bool isDisc = false;
                    double mainlifeCovAmt = 0;
                    double mainlifeOccexAmt = 0;
                    double mainlifeHexAmt = 0;
                    double mainlifeDiscAmt = 0;
                    double mainlifePremiumWaveAmt = 0;
                    double newpolicyPremiumAmt = 0;

                    isHavePremiumPaidCovers = table56.isHavePremiumPaidCover(polno);
                    isOccex = table56.isOCCEXHave(polno);
                    isHex = table56.isHEXHave(polno);
                    isDisc = table56.isDiscountHave(polno);

                    //Get Endorsement No
                    endoNo = table56.getCoverEndorsementNo(polno);

                    //Insert Cover History
                    string coverHistoryInsertSQL = "insert into LUND.RCOVER_HISTORY (rpol,rcovr,rcomdat,rsumas,rmode, rterm, rprm, rrate, roex, rhex,rdiscon,entry_date,entry_epf,SQNO,ENTERED_MODE)" +
                                                   "(select rpol, rcovr, rcomdat, rsumas, rmode, rterm, rprm, rrate, roex, rhex," +
                                                   "rdiscon, sysdate, " + dthpayObj.EpfCode(EPF) + ", " + endoNo + ", 3 " +
                                                   "from LUND.RCOVER where rpol=" + polno + ")";
                    dthpayObj.insertRecords(coverHistoryInsertSQL);

                    mainlifeCovAmt = table56.getMainLifeCoverAmount(polno);

                    if (isOccex)
                    {
                        string occexHistoryInsertSQL = "insert into LUND.ROCCEX_HISTORY " +
                                                   "(select rpol, rcovr, oeper, oeval, oeamt, oetrm," +
                                                   "sysdate, " + dthpayObj.EpfCode(EPF) + ", " + endoNo + " " +
                                                   "from LUND.ROCCEX where rpol=" + polno + ")";
                        dthpayObj.insertRecords(occexHistoryInsertSQL);

                        mainlifeOccexAmt = table56.getMainLifeOEXAmount(polno);
                    }

                    if (isHex)
                    {
                        string hexHistoryInsertSQL = "insert into LUND.RHELEX_HISTORY " +
                                                   "(select rpol, rcovr, heper, heval, heamt, hetrm," +
                                                   "sysdate, " + dthpayObj.EpfCode(EPF) + ", " + endoNo + " " +
                                                   "from LUND.RHELEX where rpol=" + polno + ")";
                        dthpayObj.insertRecords(hexHistoryInsertSQL);

                        mainlifeHexAmt = table56.getMainLifeHEXAmount(polno);
                    }

                    if (isDisc)
                    {
                        string discHistoryInsertSQL = "insert into LUND.RDISCON_HISTORY " +
                                                   "(select rpol, rcovr, disper, disval, disamt," +
                                                   "sysdate, " + dthpayObj.EpfCode(EPF) + ", " + endoNo + ", hetrm " +
                                                   "from LUND.RDISCON where rpol=" + polno + ")";
                        dthpayObj.insertRecords(discHistoryInsertSQL);

                        mainlifeDiscAmt = table56.getMainLifeDiscountAmount(polno);
                    }

                    mainlifePremiumWaveAmt = (mainlifeCovAmt + mainlifeOccexAmt + mainlifeHexAmt) - mainlifeDiscAmt;
                    newpolicyPremiumAmt = PRM - mainlifePremiumWaveAmt;

                    //Update Exsit Year && New Policy Premium Amount
                    if (!isHavePremiumPaidCovers)
                    {
                        tmpDue = int.Parse(COM.ToString().Substring(0, 6)) + (TRM * 100);
                        premSQLUpdate = "update lphs.premast set pmdue=" + tmpDue + "  where pmpol= " + polno + "";
                    }
                    else
                    {
                        tmpDue = int.Parse(COM.ToString().Substring(0, 6)) + 100;
                        premSQLUpdate = "update lphs.premast set pmdue=" + tmpDue + ", pmprm=" + newpolicyPremiumAmt + "  where pmpol= " + polno + "";
                    }
                    dthpayObj.insertRecords(premSQLUpdate);
                }
                #endregion
                //geting recept no

                long receiptNo = 0;

                int newsurryear = int.Parse(setDate()[0].Substring(0, 4));
                string rcptnoquery = "SELECT (nvl(max(RCNO),0)+1) FROM  LPAY.RCPTNO WHERE (RCBRNO = " + branch + ") AND (RCYEAR = " + newsurryear + ") AND (RCTYPE = 11)";

                dthpayObj.readSql(rcptnoquery);
                OracleDataReader receiptReader = dthpayObj.oraComm.ExecuteReader();
                while (receiptReader.Read()) receiptNo = (!receiptReader.IsDBNull(0)) ? receiptReader.GetInt64(0) : 1;

                //update the receipt number
                string checkreceipt = "select * from LPAY.RCPTNO where RCBRNO=" + branch + " and RCYEAR=" + newsurryear + "  and RCTYPE= 11 ";
                if (dthpayObj.existRecored(checkreceipt) == 0)
                {
                    string updRcptnoquery = "insert into LPAY.RCPTNO (RCBRNO,RCYEAR,RCTYPE,RCNO) values('" + branch + "','" + newsurryear + "','11','" + receiptNo + "')";
                    dthpayObj.insertRecords(updRcptnoquery);
                }
                else
                {
                    string updRcptnoquery = "update LPAY.RCPTNO set RCNO=" + receiptNo + " where RCBRNO=" + branch + " and RCYEAR=" + newsurryear + "  and RCTYPE= 11 ";
                    dthpayObj.insertRecords(updRcptnoquery);
                }

                    


                //.........LPAY.LPAYMAS.......
                //do not changed the default premium code, but removed the interest for premium

                //yyyy check if already data exist
                string q = "select * from lpay.lpaymas where lpbrn = " + branch + " and lppol= " + polno + "";

                if (dthpayObj.existRecored(q) == 0)
                {
                    double am1 = amtComyr;// (demprem * interest) + demprem;
                    string lpaymasInsertSQL = "insert into lpay.lpaymas (lpbrn, lpptd, lpbtp, lprec, lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, lpedt, lptim, lpipa, lpacd, lpopr, lpcur, lpcrt) values(" + branch
                                                            + ", " + int.Parse(setDate()[0]) + ", 11, " + receiptNo + ", " + Convert.ToInt32(ViewState["claimno"]) + ", " + polno + ", '3', '5', " + am1 + ",  " + am1 + " , " + 0 + ", " + branch
                                                            + ", " + int.Parse(setDate()[0]) + ", '" + DateTime.Now.ToLongTimeString() + "',  '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', 2235, " + dthpayObj.EpfCode(EPF) + ", 'LKR', 1 )";
                    dthpayObj.insertRecords(lpaymasInsertSQL);
                }
                //--yyyy


                //double am1 = amtComyr;// (demprem * interest) + demprem;
                //string lpaymasInsertSQL = "insert into lpay.lpaymas (lpbrn, lpptd, lpbtp, lprec, lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, lpedt, lptim, lpipa, lpacd, lpopr, lpcur, lpcrt) values(" + branch
                //                                        + ", " + int.Parse(setDate()[0]) + ", 11, " + receiptNo + ", " + Convert.ToInt32(ViewState["claimno"]) + ", " + polno + ", '3', '5', " + am1 + ",  " + am1 + " , " + 0 + ", " + branch
                //                                        + ", " + int.Parse(setDate()[0]) + ", '" + DateTime.Now.ToLongTimeString() + "',  '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', 2235, " + dthpayObj.EpfCode(EPF) + ", 'LKR', 1 )";
                //dthpayObj.insertRecords(lpaymasInsertSQL);




                foreach (long dueVal in _duesToPaycompletYear)
                {

                    //...LPAY.LPAYCOM.... but no commission to others So Agent & org is zero meeting 2012/03/09
                    string lpaycomInsert = "INSERT INTO LPAY.LPAYCOM (LCPBR ,LCPDT ,LCBTP ,LCPOL ,LCDUE ,LCTBL ,LCTRM ,LCMOD ,LCPRM ,LCCDT ,LCCOD ,LCPAC ,LCAGT ,LCORG ,LCSBR , LCREC, LCLATEFEE )";
                    lpaycomInsert += " VALUES (" + branch + " ," + int.Parse(this.setDate()[0]) + " ,'11' ," + polno + " ," + dueVal + " ," + TBL + " ," + TRM + " ," + MOD + " ," + PRM + " ";
                    lpaycomInsert += " ," + COM + " ,'8' ," + PAC + " ," + 0 + " ," + 0 + " ," + branch + " ,'" + receiptNo + "' , " + PRM + ")";//..Change on 20090518 Daet of Commence error on Commision reu of udeepa --int.Parse(this.setDate()[0])
                    dthpayObj.insertRecords(lpaycomInsert);

                    //.....LCLM.LEDGER.....
                    string ledgerInsert = "insert into lclm.ledger(LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT, LLPBR, LLREC) " +
                                    " VALUES (" + polno + ", " + dueVal + ", 1, 8, " + PRM + ", " + MOD + ", " + int.Parse(this.setDate()[0]) + ", " + branch + ", '" + receiptNo + "'  ) ";
                    dthpayObj.insertRecords(ledgerInsert);


                    //Task 29459
                    string demandSelect = "select * from LPHS.DEMAND where PDPOL=" + polno + " and PDDUE=" + dueVal + "";
                    if (dthpayObj.existRecored(demandSelect) == 0)
                    {
                        string demandInsert = "INSERT INTO LPHS.DEMAND (PDCOD ,PDPOL, PDDUE, PDPRM, PDPAC, PDTAB, PDTER, PDPDT, STATUS) " +
                                              "VALUES ( '5'," + polno + " , " + dueVal + ", " + PRM + ", " + PAC + ", " + TBL + ", " + TRM + ", " + int.Parse(this.setDate()[0]) + ", 'D')";
                        dthpayObj.insertRecords(demandInsert);
                    }
                    else
                    {
                        string demandUpdate = "UPDATE LPHS.DEMAND set PDCOD='5', PDPDT=" + int.Parse(this.setDate()[0]) + ", STATUS='D' WHERE PDPOL=" + polno + " and PDDUE=" + dueVal + "";
                        dthpayObj.insertRecords(demandUpdate);
                    }

                    if (_duesToPaycompletYear.Count == demCount)
                    {
                        polCompDue = int.Parse(dueVal.ToString());
                        int polCompDate = int.Parse(polCompDue.ToString() + "" + COM.ToString().Substring(6, 2));
                        int nextDue = this.NextEffectingDue(MOD, polCompDate);

                        string premastSelect = "select * from LPHS.PREMAST where PMPOL=" + polno + "";
                        string lapseSelect = "select * from LPHS.LIFLAPS where LPPOL=" + polno + "";
                        string lpolHisSelect = "select * from LPHS.LPOLHIS where PHPOL=" + polno + " and PHMOS='" + MOF + "' and PHTYP='D'";

                        if (dthpayObj.existRecored(premastSelect) != 0)
                        {
                            string premastUpdate = "UPDATE LPHS.PREMAST set PMDUE=" + nextDue + " WHERE PMPOL=" + polno + "";
                            dthpayObj.insertRecords(premastUpdate);
                        }
                        else if (dthpayObj.existRecored(lapseSelect) != 0)
                        {
                            string lapseUpdate = "UPDATE LPHS.LIFLAPS set LPDUE=" + nextDue + " WHERE LPPOL=" + polno + "";
                            dthpayObj.insertRecords(lapseUpdate);
                        }
                        else if (dthpayObj.existRecored(lpolHisSelect) != 0)
                        {
                            string lpolHisUpdate = "UPDATE LPHS.LPOLHIS set PHDUE=" + nextDue + " WHERE PHPOL=" + polno + " and PHMOS='" + MOF + "' and PHTYP='D'";
                            dthpayObj.insertRecords(lpolHisUpdate);
                        }
                    }

                    //insert to ddemand table for reversing purpose
                    //AFT for after death, DYC for death year completion

                    string ddemandInsert = "INSERT INTO LPHS.DDEMAND (DPDPOL ,DPDDUE, INSERT_TYPE, ENTEPF, ENTDATE, SETTLMNT_TYPE, DPCOD, DPPDT) VALUES ( " + polno + " , " + dueVal + ", 'AFT', '" + EPF + "', " + int.Parse(this.setDate()[0]) + ", 'DYC', '" + '4' + "', " + dateofdeath + ")";
                    dthpayObj.insertRecords(ddemandInsert);

                    demCount++;
                }

                #region Task 34965

                // Task 34965 ==============================================
                //dateofdeath,COM,MOD,PRM,polcompleYM
                int yearcomdue = 0;
                if (polcompleYM != null)
                {
                    yearcomdue = Convert.ToInt32(polcompleYM.Replace("/", ""));
                }

                if (MOD != 5)
                {
                    int lstpaiddue = 0;
                    deductAmount = 0;
                    //string checklastedue = "select nvl(max(LLDUE), 0) from LCLM.LEDGER where LLPOL = '" + polno + "' and LLDUE <= " + Convert.ToInt32(dateofdeath.ToString().Substring(0, 6)) + "";
                    string checklastedue = "select DRPAID_DUE from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOF + "'";
                    if (dthpayObj.existRecored(checklastedue) != 0)
                    {
                        dthpayObj.readSql(checklastedue);
                        OracleDataReader checkduereader = dthpayObj.oraComm.ExecuteReader();
                        checkduereader.Read();
                        if (!checkduereader.IsDBNull(0)) { lstpaiddue = checkduereader.GetInt32(0); } else { lstpaiddue = 0; }
                        checkduereader.Close();
                        checkduereader.Dispose();
                    }
                    int checkdue = lstpaiddue;
                    if (lstpaiddue != 0)
                    {
                        do
                        {
                            double payprm = 0;
                            int nextDue = getNextDue(MOD, checkdue);
                            double payamt = 0;
                            if (nextDue <= yearcomdue)
                            {
                                string checkLedger = "select LLPRM from lclm.ledger where LLPOL='" + polno + "' and lldue='" + nextDue + "'";

                                if (dthpayObj.existRecored(checkLedger) != 0)
                                {
                                    payprm = 0;
                                    dthpayObj.readSql(checkLedger);
                                    OracleDataReader drnew = dthpayObj.oraComm.ExecuteReader();
                                    while (drnew.Read())
                                    {
                                        if (!drnew.IsDBNull(0)) { payprm += drnew.GetInt32(0); }
                                    }
                                    drnew.Close();
                                    drnew.Dispose();
                                }

                                if (payprm != 0 && payprm < PRM)
                                {
                                    deductAmount += PRM - payprm;
                                    payamt = PRM - payprm;
                                    string ledgerInsertnew = "insert into lclm.ledger(LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT, LLPBR, LLREC) " +
                                         " VALUES (" + polno + ", " + nextDue + ", 2, 8, " + payamt + ", " + MOD + ", " + int.Parse(this.setDate()[0]) + ", " + branch + ", '" + receiptNo + "'  ) ";
                                    dthpayObj.insertRecords(ledgerInsertnew);
                                }
                            }
                            checkdue = nextDue;

                        } while (checkdue <= yearcomdue);
                    }
                }

                if (STA.Equals("L") && MOF.Equals("M") && (TBL==13 || TBL == 59))
                {
                    string vouno = "";
                    int voudat = 0;
                    int docno = 0;
                    double payamount = 0;
                    string stagepaymentupdate = "update lclm.lcmmast set PDELT='D' where ptyp = 2 and ppolno = " + polno + " and pdocno = 0";
                    dthpayObj.insertRecords(stagepaymentupdate);
                }

                //=========================================================
                #endregion

                #endregion

                //Task 29459 - Update next effecting



                #region ------------------Writing on lphs.Death_Sys_No File-----------------------------

                //int maxAdmitNo = 0;
                //int AdmitNo = 0;
                //string dthSysSelect = "select POLICY_NO, CLAIM_NO from LPHS.DEATH_SYS_NO where POLICY_NO=" + polno + " and CLAIM_NO=" + Convert.ToInt32(ViewState["claimno"]) + "";

                //if (dthpayObj.existRecored(dthSysSelect) == 0)
                //{
                //    string dthSysCount = "select POLICY_NO from LPHS.DEATH_SYS_NO";

                //    if (dthpayObj.existRecored(dthSysCount) == 0)
                //    {
                //        string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO) VALUES ( " + polno + " , " + Convert.ToInt32(ViewState["claimno"]) + ", '" + MOF + "', " + 36100 + ")";
                //        dthpayObj.insertRecords(dthSysNoInsert);
                //    }
                //    else
                //    {
                //        string dthMaxAdmitNo = "SELECT MAX(ADMIT_NO) FROM LPHS.DEATH_SYS_NO";

                //        dthpayObj.readSql(dthMaxAdmitNo);
                //        OracleDataReader dthSysReader = dthpayObj.oraComm.ExecuteReader();
                //        dthSysReader.Read();
                //        if (!dthSysReader.IsDBNull(0)) { maxAdmitNo = dthSysReader.GetInt32(0); } else { maxAdmitNo = 0; }
                //        dthSysReader.Close();
                //        dthSysReader.Dispose();

                //        AdmitNo = maxAdmitNo + 1;
                //        string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO) VALUES ( " + polno + " , " + Convert.ToInt32(ViewState["claimno"]) + ", '" + MOF + "', " + AdmitNo + ")";
                //        dthpayObj.insertRecords(dthSysNoInsert);
                //    }
                //}

                int admitNo = 0;
                string dthSysSelect = "select POLICY_NO, CLAIM_NO from LPHS.DEATH_SYS_NO where POLICY_NO=" + polno + " and CLAIM_NO=" + Convert.ToInt32(ViewState["claimno"]) + " and P_TYPE='" + MOF + "'";

                if (dthpayObj.existRecored(dthSysSelect) == 0)
                {
                    string dthControlAdmitNo = "SELECT ADMIT_NO FROM LPHS.DEATH_SYS_CONTROL";

                    dthpayObj.readSql(dthControlAdmitNo);
                    OracleDataReader dthControlReader = dthpayObj.oraComm.ExecuteReader();
                    dthControlReader.Read();
                    if (!dthControlReader.IsDBNull(0)) { admitNo = dthControlReader.GetInt32(0); } else { admitNo = 0; }
                    dthControlReader.Close();
                    dthControlReader.Dispose();

                    string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO, PAID_NO) VALUES ( " + polno + " , " + Convert.ToInt32(ViewState["claimno"]) + ", '" + MOF + "', " + admitNo + " , '0')";
                    dthpayObj.insertRecords(dthSysNoInsert);

                    admitNo += 1;

                    string dthControlUpdate = "UPDATE LPHS.DEATH_SYS_CONTROL SET ADMIT_NO=" + admitNo + "";
                    dthpayObj.insertRecords(dthControlUpdate);
                }

                #endregion

                #region reinsure email

                string reinsurechck = "select AVAILABILITY from LPHS.DTH_REINSURANCE_DTL where CLAIMNO='" + claimno + "'";

                if (dthpayObj.existRecored(reinsurechck) != 0)
                {
                    dthpayObj.readSql(reinsurechck);
                    OracleDataReader dthControlReader = dthpayObj.oraComm.ExecuteReader();
                    dthControlReader.Read();
                    if (!dthControlReader.IsDBNull(0)) { Availability = dthControlReader.GetString(0); }
                    dthControlReader.Close();
                    dthControlReader.Dispose();
                }
                if (Availability == "Y")
                {
                    string checckmail = "SELECT * FROM LPHS.DTH_REINS_EMAIL_LOG WHERE  POLNO='" + polno + "' and CLAIMNO='" + claimno + "' and TYPE='PAYMENT'";
                    if (dthpayObj.existRecored(checckmail) == 0)
                    {
                        string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                            (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                             VALUES ('" + polno + "','" + claimno + "' , sysdate, '" + EPF + "','PAYMENT')";
                        dthpayObj.insertRecords(insertEmaillog);

                        string updatePayment = "UPDATE LPHS.DTH_REINSURANCE_DTL set PAYMENT_DETAIL_SENT='Y'," +
                                    "PAYMENT_DETAIL_SENT_DATE=sysdate,RE_INS_STATUS='COMPLETED' where CLAIMNO='" + claimno + "'";
                        dthpayObj.insertRecords(updatePayment);
                    }
                }
                #endregion



                dthpayObj.commit();
                //dm.connClose();
                dthpayObj.connclose();



            }
            catch (Exception ex)
            {
                dthpayObj.rollback();
                //dm.connClose();
                dthpayObj.connclose();
                EPage.Messege = ex.ToString();
                Response.Redirect("EPage.aspx");
            }

            if (Availability == "Y")
            {
                Response.Redirect("PaymentForm.aspx?pState=2&clmno=" + claimno + "&polno=" + polno + "&mos=" + MOF + "&adblatepay=" + ADBlatepay + "");
            }
        }

    }
    public int Duration(int dema, int dtOfDthYm)
    {

        int totmonths = 0;
        if (dema > dtOfDthYm) { totmonths = 0; }
        int endtyr = int.Parse(dtOfDthYm.ToString().Substring(0, 4));
        int endmnth = int.Parse(dtOfDthYm.ToString().Substring(4, 2));
        int startyr = int.Parse(dema.ToString().Substring(0, 4));
        int startmnth = int.Parse(dema.ToString().Substring(4, 2));

        int monthdiff = endmnth - startmnth;
        if (monthdiff < 0)
        {
            monthdiff = endmnth + 12 - startmnth;
            endtyr--;
        }
        int yeardiff = endtyr - startyr;
        totmonths = (yeardiff * 12) + monthdiff;
        if (dema.ToString().Length == 8)
        {
            if (int.Parse(dtOfDthYm.ToString().Substring(6, 2)) - int.Parse(dema.ToString().Substring(6, 2)) < 0)
            {
                totmonths--;
            }
        }
        return totmonths;
    }

    /// <summary>
    /// This methord use to display back calaculation values
    /// Created by Roshan (2012/03/03)
    /// </summary>
    private void backCalculation(DataManager dthpayObj)
    {
        try
        {


            //dthpayObj = new DataManager();
            if (dthpayObj.oraConn.State == ConnectionState.Open)
                dthpayObj.oraComm.Connection = dthpayObj.oraConn;
            else
            {
                dthpayObj = new DataManager();
                dthpayObj.oraComm.Connection = dthpayObj.oraConn;
            }//changed by chandana 09/03/2012


            dthpayObj.oraComm.Parameters.Clear();
            dthpayObj.oraComm.CommandText = "lpay.life_functions.loanBackCalculationDisplay";
            dthpayObj.oraComm.CommandType = CommandType.StoredProcedure;
            dthpayObj.oraComm.Parameters.AddWithValue("policyNumber", lblpolno.Text);
            dthpayObj.oraComm.Parameters.AddWithValue("claimNo", lblclmno.Text);

            OracleParameter outParaInterestToBePaid = new OracleParameter("InterestToBePaid", OracleType.VarChar, 20);
            outParaInterestToBePaid.Direction = ParameterDirection.Output;

            OracleParameter outParaCapitalToBePaid = new OracleParameter("CapitalToBePaid", OracleType.VarChar, 20);
            outParaCapitalToBePaid.Direction = ParameterDirection.Output;

            OracleParameter outParap_CapitalAsAtDeath = new OracleParameter("p_CapitalAsAtDeath", OracleType.VarChar, 20);
            outParap_CapitalAsAtDeath.Direction = ParameterDirection.Output;

            OracleParameter outParap_InterestAsAtDeath = new OracleParameter("p_InterestAsAtDeath", OracleType.VarChar, 20);
            outParap_InterestAsAtDeath.Direction = ParameterDirection.Output;

            dthpayObj.oraComm.Parameters.Add(outParaInterestToBePaid);
            dthpayObj.oraComm.Parameters.Add(outParaCapitalToBePaid);
            dthpayObj.oraComm.Parameters.Add(outParap_CapitalAsAtDeath);
            dthpayObj.oraComm.Parameters.Add(outParap_InterestAsAtDeath);

            dthpayObj.oraComm.ExecuteNonQuery();

            if (dthpayObj.oraComm.Parameters["p_CapitalAsAtDeath"].Value.ToString() != string.Empty)
                if (MOF.Equals("M"))
                    lblBackloancap.Text = Convert.ToDouble(dthpayObj.oraComm.Parameters["p_CapitalAsAtDeath"].Value).ToString("N");
                else
                    lblBackloancap.Text = "0.00";

            if (dthpayObj.oraComm.Parameters["p_InterestAsAtDeath"].Value.ToString() != string.Empty)
                if (MOF.Equals("M"))
                    lblBackloanint.Text = Convert.ToDouble(dthpayObj.oraComm.Parameters["p_InterestAsAtDeath"].Value).ToString("N");
                else
                    lblBackloanint.Text = "0.00";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int premcount(int start, int end, int mode, int polno)
    {
        //start, end = yyyymmdd , mode = 1, 2, 3, 4 , polno for getting demmands
        int yeardiff = 0;
        int monthdiff = 0;
        int datediff = 0;
        int premcount = 0;
        yeardiff = this.dateComparison(start, end)[0];
        monthdiff = this.dateComparison(start, end)[1];
        datediff = this.dateComparison(start, end)[2];

        int totmonthdiff = yeardiff * 12 + monthdiff;
        if (mode == 1)
        {
            premcount = yeardiff++;
        }
        else if (mode == 2)
        {
            premcount = Math.Abs((totmonthdiff + 6) / 6);
        }
        else if (mode == 3)
        {
            premcount = Math.Abs((totmonthdiff + 3) / 3);
        }
        else if (mode == 4)
        {
            premcount = totmonthdiff + 1;
            if (datediff > 15) { premcount++; }
        }
        else { }

        premcount -= this.demmandcount(polno);

        return premcount;
    }

    public int demmandcount(int polno)
    {

        dthpayObj = new DataManager();
        int demanddate = 0;
        int demandcount = 0;

        string mydemandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' ";
        dthpayObj.readSql(mydemandsql);
        OracleDataReader mydemandreader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

        while (mydemandreader.Read())
        {
            string pdcodestr = mydemandreader.GetString(0);
            if ((pdcodestr.Equals("1")) || (pdcodestr.Equals("2")) || (pdcodestr.Equals("3")))
            {
                demanddate = mydemandreader.GetInt32(1);
                demandcount++;
            }
        }
        mydemandreader.Close();
        mydemandreader.Dispose();
        dthpayObj.connclose();
        return demandcount;

    }

    //*************** Properties *****************
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
    public int Dateofdeath
    {
        get { return dateofdeath; }
        set { dateofdeath = value; }
    }
    public int cOM
    {
        get { return COM; }
        set { COM = value; }
    }
    public int tBL
    {
        get { return TBL; }
        set { TBL = value; }
    }
    public int tRM
    {
        get { return TRM; }
        set { TRM = value; }
    }
    public int sUM
    {
        get { return SUM; }
        set { SUM = value; }
    }
    public int mOD
    {
        get { return MOD; }
        set { MOD = value; }
    }
    public double pRM
    {
        get { return PRM; }
        set { PRM = value; }
    }
    public string sTA
    {
        get { return STA; }
        set { STA = value; }
    }
    //*********************************************
    public double VestedBonus
    {
        get { return vestedBonus; }
        set { vestedBonus = value; }
    }
    public double InterimBonus
    {
        get { return interimBonus; }
        set { interimBonus = value; }
    }
    public double Totbons
    {
        get { return totbons; }
        set { totbons = value; }
    }
    public double Surrrenderedbons
    {
        get { return surrrenderedbons; }
        set { surrrenderedbons = value; }
    }
    public int BonussurrYr
    {
        get { return bonussurrYr; }
        set { bonussurrYr = value; }
    }
    public double NetsurrAmt
    {
        get { return netsurrAmt; }
        set { netsurrAmt = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public double Deposit
    {
        get { return deposit; }
        set { deposit = value; }
    }
    public double Demmands
    {
        get { return demmands; }
        set { demmands = value; }
    }
    public double Defint
    {
        get { return defint; }
        set { defint = value; }
    }
    public double Loancap
    {
        get { return loancap; }
        set { loancap = value; }
    }
    public double Loanint
    {
        get { return loanint; }
        set { loanint = value; }
    }

    public double aDB
    {
        get { return ADB; }
        set { ADB = value; }
    }
    public double fPU
    {
        get { return FPU; }
        set { FPU = value; }
    }
    public double sJ
    {
        get { return SJ; }
        set { SJ = value; }
    }
    public double fE
    {
        get { return FE; }
        set { FE = value; }
    }
    public string fEearlyPay
    {
        get { return FEearlyPay; }
        set { FEearlyPay = value; }
    }
    public string aDBlatepay
    {
        get { return ADBlatepay; }
        set { ADBlatepay = value; }
    }

    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public int Missingprems
    {
        get { return missingprems; }
        set { missingprems = value; }
    }
    public string PolcompleYM
    {
        get { return polcompleYM; }
        set { polcompleYM = value; }
    }

    public int InterimBonStYr
    {
        get { return interimBonStYr; }
        set { interimBonStYr = value; }
    }
    public double AmtComyr
    {
        get { return amtComyr; }
        set { amtComyr = value; }
    }

    public string ThePayee
    {
        get { return thePayee; }
        set { thePayee = value; }
    }

    public double Otheradd
    {
        get { return otheradd; }
        set { otheradd = value; }
    }
    public double Otherdeuct
    {
        get { return otherdeuct; }
        set { otherdeuct = value; }
    }
    public double ThrStgamt
    {
        get { return thrstgamt; }
        set { thrstgamt = value; }
    }
    public double Stagedeuct
    {
        get { return stagedeuct; }
        set { stagedeuct = value; }
    }
    public double RefOfPrems
    {
        get { return refOfPrems; }
        set { refOfPrems = value; }
    }

    public double GrossClm
    {
        get { return grossClm; }
        set { grossClm = value; }
    }
    public double Netclm
    {
        get { return netclm; }
        set { netclm = value; }
    }
    public double OutAmt
    {
        get { return outAmt; }
        set { outAmt = value; }
    }
    public double Sumassured
    {
        get { return sumassured; }
        set { sumassured = value; }
    }
    public string NameOfDead
    {
        get { return nameOfDead; }
        set { nameOfDead = value; }
    }

    public string AgeStatus
    {
        get { return ageStatus; }
        set { ageStatus = value; }
    }
    public double AgeDiffAmt
    {
        get { return ageDiffAmt; }
        set { ageDiffAmt = value; }
    }
    public double AgeDiffINT
    {
        get { return agediffint; }
        set { agediffint = value; }
    }
    public string Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }
    public string SumassDesc
    {
        get { return sumassDesc; }
        set { sumassDesc = value; }
    }
    public string Memoepf
    {
        get { return memoepf; }
        set { memoepf = value; }
    }
    public double Interest
    {
        get { return interest; }
        set { interest = value; }
    }

    public double DeductAmount
    {
        get { return deductAmount; }
        set { deductAmount = value; }
    }

    public double StagePayment
    {
        get { return stagePayment; }
        set { stagePayment = value; }
    }

    public double Netclm_BFStamp
    {
        get { return netclm_bfstamp; }
        set { netclm_bfstamp = value; }
    }

    public double Stamp_Duty
    {
        get { return stamp_duty; }
        set { stamp_duty = value; }
    }

    public string StageYearString
    {
        get { return stageyearString; }
        set { stageyearString = value; }
    }
    protected void btnPayshare_Click(object sender, EventArgs e)
    {
        //try
        //{
        if (!this.lbltot.Text.ToString().Equals(null) && !this.lbltot.Text.ToString().Equals(""))
        {
            totamount = double.Parse(this.lbltot.Text.ToString());
        }
        Server.Transfer("~/paymentDistn001.aspx", true);
        //}
        //    catch (Exception ex) {
        //        EPage.Messege = ex.Message;
        //        Response.Redirect("EPage.aspx");
        //    }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("dthVou001.aspx?polno=" + polno.ToString() + "&mos=" + MOF + "");
    }

    /*  old version of date comparison
    public int[] dateComparison(int startdate, int enddate)
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

        awuuduwenasa = endyear - styear;

        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            awuuduwenasa--;
        }

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            maasawenasa--;
            if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            maasawenasa--;
            if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            maasawenasa--;
            if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; }
        }
        else { }

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
    }
    */

    public int[] dateComparison(int startdate, int enddate)
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
    private void createNomineeTable(string nominee, string percentage, int rowNumber, int Dob, string nic)
    {

        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();

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

        lbl3.ID = "nic" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "nic" + rowNumber); //Text Value
        if (nic == null)
        {
            lbl3.Text = " ";
        }
        else
        {
            lbl3.Text = nic;
        }
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
        //lbl4.Width = 100;

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(lbl4);
        trow.Controls.Add(tcell1);
        trow.Controls.Add(tcell2);
        trow.Controls.Add(tcell3);
        trow.Controls.Add(tcell4);
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

    private int[] lastpayDateym(int theDue, int theMode)
    {
        int[] ymArr = new int[2];

        int dueyr = int.Parse(theDue.ToString().Substring(0, 4));
        int duemnth = int.Parse(theDue.ToString().Substring(4, 2));
        int theyr = dueyr;
        int themnth = duemnth;
        if (theMode == 1) { themnth -= 12; if (themnth <= 0) { themnth += 12; --theyr; } }
        else if (theMode == 2) { themnth -= 6; if (themnth <= 0) { themnth += 12; --theyr; } }
        else if (theMode == 3) { themnth -= 3; if (themnth <= 0) { themnth += 12; --theyr; } }
        else if (theMode == 4) { themnth = --themnth; if (themnth == 0) { themnth = 12; --theyr; } }

        ymArr[0] = themnth;
        ymArr[1] = theyr;
        return ymArr;
    }

    public int NextEffectingDue(int mode, int polComDueDate)
    {
        int nextEffectDue = 0;

        polComDueDate = this.dateCorrection(polComDueDate);

        DateTime dt = DateTime.ParseExact(polComDueDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

        if (mode == 1)
        {
            nextEffectDue = int.Parse(dt.AddMonths(12).ToString("yyyyMMdd").Substring(0, 6));
        }
        else if (mode == 2)
        {
            nextEffectDue = int.Parse(dt.AddMonths(6).ToString("yyyyMMdd").Substring(0, 6));
        }
        else if (mode == 3)
        {
            nextEffectDue = int.Parse(dt.AddMonths(3).ToString("yyyyMMdd").Substring(0, 6));
        }
        else if (mode == 4)
        {
            nextEffectDue = int.Parse(dt.AddMonths(1).ToString("yyyyMMdd").Substring(0, 6));
        }

        return nextEffectDue;
    }

    public int dateCorrection(int theDate)
    {
        int correctDate = 0;
        string dueYearMonth = theDate.ToString().Substring(0, 6);
        int year = int.Parse(theDate.ToString().Substring(0, 4));
        int month = int.Parse(theDate.ToString().Substring(4, 2));
        int day = int.Parse(theDate.ToString().Substring(6, 2));

        if (((month == 4) || (month == 6) || (month == 9) || (month == 11)) && (day == 31)) { day = 30; }

        else if ((month == 2) && ((day == 30) || (day == 30) || (day == 31))) { day = 28; }

        else if ((!((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))) && (month == 2) && (day == 29)) { day = 28; }

        if (day.ToString().Length < 2)
        {
            correctDate = int.Parse(dueYearMonth + "0" + day.ToString());
        }
        else
        {
            correctDate = int.Parse(dueYearMonth + "" + day.ToString());
        }

        return correctDate;
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {

    }

    protected void btnDischargeEng_Click(object sender, EventArgs e)
    {

    }


    public int getNextDue(int payMode, int cDue)
    {
        int nxtDue = 0;

        try
        {
            DateTime currentDue = DateTime.ParseExact(cDue.ToString(), "yyyyMM", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            switch (payMode)
            {
                case 1:
                    nxtDue = int.Parse(currentDue.AddMonths(12).ToString("yyyyMM"));
                    break;
                case 2:
                    nxtDue = int.Parse(currentDue.AddMonths(6).ToString("yyyyMM"));
                    break;
                case 3:
                    nxtDue = int.Parse(currentDue.AddMonths(3).ToString("yyyyMM"));
                    break;
                case 4:
                    nxtDue = int.Parse(currentDue.AddMonths(1).ToString("yyyyMM"));
                    break;
            }
        }
        catch (FormatException)
        {
            nxtDue = cDue;
        }

        return nxtDue;
    }

    protected void ChkSig(object sender, EventArgs e)
    {
        if (Signature.Checked)
        {
            SignatureDisplay = true;
        }
    }
}
