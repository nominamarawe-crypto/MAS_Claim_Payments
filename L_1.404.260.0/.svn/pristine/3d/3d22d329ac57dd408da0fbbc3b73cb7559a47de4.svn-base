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
//Last updated Dushan 20/08/2009
public partial class dthPay020 : System.Web.UI.Page
{
    private long polno;
    private string MOS;

    private int infodat;
    private int dateofdeath;
    private string EPF;
    private string COD;   
    private int COM;
    private int TBL;
    private int TRM;
    private int SUM;
    private int MOD;
    private double PRM;
    private int DUE;
    private int PAC;
    private string STA;
    private int AGT;
    private int ORG;
    private int PrePayingTerm;


    private int brcode;

    //******* variables for DTHREF ***************
    private double ADB;
    private double FPU;
    private double SJ; private double SJsysGenerat;
    private double FE;
    private string ageAdmitYN;
    private string revivalsYN, adbonexgr;
    private string assNomYN;
    private string reinsYN ="";
    private double vestedBonus;
    private double interimBonus;
    private double totbons;
    private double surrrenderedbons;
    private int bonussurrYr;
    private double netsurrAmt;
    private long claimno;
    private double deposit;
    private double premtot;
    private double demmands;
    private double defint;
    private double loancap;
    private double loanint;
    private double exgraciaAmt;
    //private  double totamount;
    //private  int missingprems;
    //private  string polcompleYM = "";

    private double sumassured;
    private double stgpmnt, stgpmnt1, stgpmnt2, stgpmnt3;
    private int inforceDuration;
    private int ageofchild;
    private int ageofsecondlife;
    private int paidPremcount;
    private int seclifeage;
    double amtForAgeDiff = 0;
    double amtForAgeDiffInt = 0;
    string ageStatus = "";

    //--- variables to update DTHREF -----

    private string causeStr;
    //private int causeCode;
    private string decision;
    private string minutes;
    private double suassOrPVAL;
    private double adbPVL;
    private double fpuPVL;
    private double fePVL;
    private double sjPVL;
    private double DDEP;

    private string FEearlyPay = "";
    private string ADBlatepay = "";

    private double otheradd;
    private double otherDeduct;
    private double refOfPrems;
    private double amtOut;
    private bool repudiatnFlag;

    private int countStatic;
    private int causeofDth;
    private int benefitPeriod;
    DataManager dthpayObj, dm;
    General gg;
    private ArrayList arr01;
    private ArrayList arr02;

    private string memoApprv = "";
    //private double paidSJAmount = 0.0;

    double fullageofSecond;

    //Task 36978
    private ArrayList Prms1;
    private ArrayList Prms2;
    private int pol;
    public int term;
    private int paiddue;
    private int commdate;
    private int maxPaidDate;
    private long Clmno;
    private double ageamt;
    private double AgeDiffInt;
    private int tble;
    private int pacode;
    private int agt;
    private int org;
    private int serbr;
    private double prm;
    private string polst;
    private int mode;
    string selqry;
    private int maxLedgerDue;
    private int paidduemnth;
    private int paidduedays;
    private int pdyrs;
    private int totinstlmnts;
    private double singlprmdiff;
    private double remnprmdiff;
    public int dthdate;
    private int BRN;
    int rcptno = 0;
    private int dueyr;
    private int duemnth;
    private string name;
    private double sngleprm;
    private int nextdueyr;
    private int nextduemn;
    private int nextduelstyr;
    private int nextduelstmn;
    private bool isfirst;
    private double yrlyprm;
    private int fstyrdueyr;
    private int fstyrduemn;

    private int havePayment;
    private string havePaymentWarring;

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

    protected void Page_Load(object sender, EventArgs e)
    {

        


        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
            //Name = Session["Surname"].ToString();
            BRN = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            //EPage.Messege = "Your Session Expired. Please Log on to the System!";
            Response.Redirect("SessionError.aspx", false);
        }

        if (!Page.IsPostBack)
        {


            if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
            {
                polno = this.PreviousPage.Polno;
                MOS = this.PreviousPage.mos;
            }
            try
            {
                dthpayObj = new DataManager();
                dm = new DataManager();
                gg = new General();
                //!!!!!!!!
                //brcode = 10;
                brcode = Convert.ToInt32(Session["brcode"]);

                #region------------------------Check Repudiation--------------------
                string repudationsel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='"+MOS+"'";
                if (dthpayObj.existRecored(repudationsel) != 0)
                {                    
                    throw new Exception("This Policy Has Been Repudiated. Please Try Repudiation Pay Option!");
                }
                #endregion

                this.lblpolno.Text = polno.ToString();

                if (MOS.Equals("M")) { this.lbllifetype.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lbllifetype.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lbllifetype.Text = "Second Life"; }
                else if (MOS.Equals("C")) { this.lbllifetype.Text = "Child"; }
                else { }

                //this.ddlagediff.Items.Add(new ListItem("Age OK", "N"));
                //this.ddlagediff.Items.Add(new ListItem("Age Overstated", "N"));
                //this.ddlagediff.Items.Add(new ListItem("Age Understated", "Y"));

                #region //-------- POLICY HISTORY -----
                string LPOLHIScheck = "select * from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                if (dthpayObj.existRecored(LPOLHIScheck) != 0)
                {
                    string LPOLHISread = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "'  ";
                    dthpayObj.readSql(LPOLHISread);
                    OracleDataReader polhisReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (polhisReader.Read())
                    {
                        if (!polhisReader.IsDBNull(0)) { COD = polhisReader.GetString(0); } else { COD = ""; }

                        if (!polhisReader.IsDBNull(2)) { COM = polhisReader.GetInt32(2); } else { COM = 0; }
                        if (!polhisReader.IsDBNull(3)) { TBL = polhisReader.GetInt32(3); } else { TBL = 0; }
                        if (!polhisReader.IsDBNull(4)) { TRM = polhisReader.GetInt32(4); } else { TRM = 0; }
                        if (!polhisReader.IsDBNull(5)) { SUM = polhisReader.GetInt32(5); } else { SUM = 0; }
                        if (!polhisReader.IsDBNull(6)) { MOD = polhisReader.GetInt32(6); } else { MOD = 0; }
                        if (!polhisReader.IsDBNull(7)) { PRM = polhisReader.GetDouble(7); } else { PRM = 0; }
                        if (!polhisReader.IsDBNull(8)) { DUE = polhisReader.GetInt32(8); } else { DUE = 0; }
                        if (!polhisReader.IsDBNull(9)) { PAC = polhisReader.GetInt32(9); } else { PAC = 0; }

                        //if (!polhisReader.IsDBNull(15)) { STA = polhisReader.GetString(15); } else { STA = ""; }
                        if (!polhisReader.IsDBNull(10)) { AGT = polhisReader.GetInt32(10); } else { AGT = 0; }
                        if (!polhisReader.IsDBNull(11)) { ORG = polhisReader.GetInt32(11); } else { ORG = 0; }
                        if (!polhisReader.IsDBNull(14)) { PrePayingTerm = polhisReader.GetInt32(14); } else { PrePayingTerm = 0; }
                    }
                    polhisReader.Close();
                    polhisReader.Dispose();
                }
                else
                {
                    //dthpayObj.connclose();                    
                    throw new Exception("No Terminated Policy Details Found");
                }

                #endregion

                #region ----------Cheak plan Benefit Period-------------
                string tbalePlanCheck = "select * from lund.tabnam where tdtabl=" + TBL + "";
                if (dthpayObj.existRecored(tbalePlanCheck) != 0)
                {
                    string tbalePlanCheckRead = "select BENEFIT_PERIOD from lund.tabnam where tdtabl=" + TBL + "";
                    dthpayObj.readSql(tbalePlanCheckRead);
                    OracleDataReader tbalePlanCheckReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (tbalePlanCheckReader.Read())
                    {
                        if (!tbalePlanCheckReader.IsDBNull(0)) { benefitPeriod = tbalePlanCheckReader.GetInt32(0); } else { benefitPeriod = 0; } 
                    }
                    tbalePlanCheckReader.Close();
                    tbalePlanCheckReader.Dispose();
                }
                #endregion

                double x = 0;

               
                #region //---------- DTHREF -----------


                string dthrefSelect = "select DRCLMNO ,DRACCBF ,DRAGEADMIT ,DRRINSYN ,DRREVIVALS ,DRASSIGNEENOM ,DRVESTEDBON ,DRINTERIMBON ,DRBONSURRAMT ,";
                dthrefSelect += "DRBONSURRYR ,DRSWARNAJAYA ,DRFUNERALEXP ,DRFPU ,DRDEPOSITS , DRDEFPREM ,DRINT ,DRLONCAP ,DRLOANINT ,DRNETCLM ,DRPAIDNO , ";
                dthrefSelect += "DRNETSURR, DDECISION, CAUSEOFDEATHSTR, ADBPAYAMT, SJPAYAMT, FPUPAYAMT, FEPAYAMT, DROTHERADITNS, DEOTHERDEDUCT, REFUND_OF_PREMS," +
                    "SMASS_PVAL, MEMOAPRV, FE_EARLYPAY, ADB_LATEPAY, MINUTES, EXGRACIA_AMOUNT,AGE_AMT,AGE_STATUS,AGEDIFINRST, DCAUSEOFDTH from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";

                if (dthpayObj.existRecored(dthrefSelect) != 0)
                {
                    dthpayObj.readSql(dthrefSelect);
                    OracleDataReader dthrefReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    #region //***** while loop ********

                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { claimno = dthrefReader.GetInt64(0); } else { claimno = 0; }
                        if (!dthrefReader.IsDBNull(1)) { ADB = dthrefReader.GetInt64(1); } else { ADB = 0; }
                        if (!dthrefReader.IsDBNull(12)) { FPU = dthrefReader.GetInt64(12); } else { FPU = 0; }
                        if (!dthrefReader.IsDBNull(10)) { SJ = dthrefReader.GetInt64(10); } else { SJ = 0; }
                        if (!dthrefReader.IsDBNull(11)) { FE = dthrefReader.GetInt64(11); } else { FE = 0; }

                        double ADBPAYAMT = 0;       //23
                        double SJPAYAMT = 0;
                        double FPUPAYAMT = 0;
                        double FEPAYAMT = 0;

                        DDEP = 0;

                        if (!dthrefReader.IsDBNull(23)) { ADBPAYAMT = dthrefReader.GetDouble(23); } else { ADBPAYAMT = 0; }
                        if (!dthrefReader.IsDBNull(24)) { SJPAYAMT = dthrefReader.GetDouble(24); } else { SJPAYAMT = 0; }
                        if (!dthrefReader.IsDBNull(25)) { FPUPAYAMT = dthrefReader.GetDouble(25); } else { FPUPAYAMT = 0; }
                        if (!dthrefReader.IsDBNull(26)) { FEPAYAMT = dthrefReader.GetDouble(26); } else { FEPAYAMT = 0; }

                        if (ADBPAYAMT > 0) { ADB = ADBPAYAMT; }
                        if (FPUPAYAMT > 0) { FPU = FPUPAYAMT; }
                        if (SJPAYAMT > 0) { SJ = SJPAYAMT; }
                        if (FEPAYAMT > 0) { FE = FEPAYAMT; }

                        if (!dthrefReader.IsDBNull(27)) { otheradd = dthrefReader.GetDouble(27); } else { otheradd = 0; }
                        if (!dthrefReader.IsDBNull(28)) { otherDeduct = dthrefReader.GetDouble(28); } else { otherDeduct = 0; }
                        if (!dthrefReader.IsDBNull(29)) { refOfPrems = dthrefReader.GetDouble(29); } else { refOfPrems = 0; }
                        if (!dthrefReader.IsDBNull(30)) { x = dthrefReader.GetDouble(30); } else { x = 0; }
                        if (!dthrefReader.IsDBNull(31)) { memoApprv = dthrefReader.GetString(31); } else { memoApprv = ""; }

                        if (!dthrefReader.IsDBNull(2)) { ageAdmitYN = dthrefReader.GetString(2); } else { ageAdmitYN = ""; }
                        if (!dthrefReader.IsDBNull(4)) { revivalsYN = dthrefReader.GetString(4); } else { revivalsYN = ""; }
                        if (!dthrefReader.IsDBNull(5)) { assNomYN = dthrefReader.GetString(5); } else { assNomYN = ""; }
                        if (!dthrefReader.IsDBNull(3)) { reinsYN = dthrefReader.GetString(3); } else { reinsYN = ""; }

                        if (!dthrefReader.IsDBNull(6)) { vestedBonus = dthrefReader.GetDouble(6); } else { vestedBonus = 0; }
                        if (!dthrefReader.IsDBNull(7)) { interimBonus = dthrefReader.GetDouble(7); } else { interimBonus = 0; }
                        if (!dthrefReader.IsDBNull(8)) { surrrenderedbons = dthrefReader.GetDouble(8); } else { surrrenderedbons = 0; }
                        if (!dthrefReader.IsDBNull(9)) { bonussurrYr = dthrefReader.GetInt32(9); } else { bonussurrYr = 0; }
                        if (!dthrefReader.IsDBNull(20)) { netsurrAmt = dthrefReader.GetDouble(20); } else { netsurrAmt = 0; }

                        if (!dthrefReader.IsDBNull(13)) { deposit = dthrefReader.GetDouble(13); } else { deposit = 0; }
                        if (!dthrefReader.IsDBNull(14)) { demmands = dthrefReader.GetDouble(14); } else { demmands = 0; }
                        if (!dthrefReader.IsDBNull(15)) { defint = dthrefReader.GetDouble(15); } else { defint = 0; }
                        if (!dthrefReader.IsDBNull(16)) { loancap = dthrefReader.GetDouble(16); } else { loancap = 0; }
                        if (!dthrefReader.IsDBNull(17)) { loanint = dthrefReader.GetDouble(17); } else { loanint = 0; }

                        if (deposit > 0) { DDEP = deposit; }
                        if (!dthrefReader.IsDBNull(22)) { causeStr = dthrefReader.GetString(22); } else { causeStr = ""; }
                        if (!dthrefReader.IsDBNull(21)) { decision = dthrefReader.GetString(21); } else { decision = ""; }

                        if (!dthrefReader.IsDBNull(32)) { FEearlyPay = dthrefReader.GetString(32); } else { FEearlyPay = ""; }
                        if (!dthrefReader.IsDBNull(33)) { ADBlatepay = dthrefReader.GetString(33); } else { ADBlatepay = ""; }
                        if (!dthrefReader.IsDBNull(34)) { minutes = dthrefReader.GetString(34); } else { minutes = ""; }
                        if (!dthrefReader.IsDBNull(35)) { exgraciaAmt = dthrefReader.GetDouble(35); } else { exgraciaAmt = 0; }
                        if (!dthrefReader.IsDBNull(36)) { txtagediffamt.Text = String.Format("{0:N}", dthrefReader.GetDouble(36)); }
                        if (!dthrefReader.IsDBNull(37))
                        {
                            ageStatus = dthrefReader.GetString(37);

                            if (ageStatus == "N")
                                ddlagediff.SelectedIndex = 0;
                            if (ageStatus == "O")
                                ddlagediff.SelectedIndex = 1;
                            if (ageStatus == "Y")
                                ddlagediff.SelectedIndex = 2;
                        }
                        if (!dthrefReader.IsDBNull(38)) { txtagediffamtInt.Text = String.Format("{0:N}", dthrefReader.GetDouble(38)); }
                        if (!dthrefReader.IsDBNull(39)) { causeofDth = dthrefReader.GetInt32(39); } else { causeofDth = 0; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();

                    #endregion

                }
                else
                {
                    //dthpayObj.connclose();                    
                    throw new Exception("No Death Reference Details!");
                }
                if (deposit == 0)
                {
                    // Task no:23420
                    //string strDeposite = "SELECT DPDEPAMT FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO=" + polno + " AND DPMOS='" + MOF + "'";
                    //if (dthpayObj.existRecored(strDeposite) != 0)
                    //{
                    //    dthpayObj.readSql(strDeposite);
                    //    OracleDataReader dthdepREADER = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //    while (dthdepREADER.Read())
                    //        if (!dthdepREADER.IsDBNull(0)) { deposit = dthdepREADER.GetDouble(0); }
                    //    dthdepREADER.Close();
                    //    dthdepREADER.Dispose();
                    //}  
                    string strDeposite = "SELECT DPDEPAMT FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO=" + polno + " AND DPMOS='" + MOF + "'";
                    if (dthpayObj.existRecored(strDeposite) == 0)
                    {
                        deposit = gg.Deposit(polno, dthpayObj);
                    } 
                }
                
                this.txtotheradd.Text = otheradd.ToString();
                this.txtotherdeduct.Text = otherDeduct.ToString();
                this.txtrefofPrems.Text = refOfPrems.ToString();
                this.txtRefofdep.Text = deposit.ToString();
                this.lblcauseOfDeath.Text = causeStr;
                this.txtdecision.Text = decision;
                this.txtminutes.Text = minutes;


                if (MOF.Equals("M"))
                {
                    this.txtLoan.Text = loancap.ToString();
                    this.txtLoanint.Text = loanint.ToString();
                }
                else
                {
                    CustomValidator13.Enabled = false;
                    CustomValidator14.Enabled = false;
                    this.txtLoan.Text = "-";
                    this.txtLoanint.Text = "-";
                }

                if (TBL == 13 || TBL == 38) { chkStage1.Enabled = true; chkStage2.Enabled = true; }
                if (TBL == 38) { ChkStage3.Enabled = true; }

                if (deposit > 0) { chkRefdep.Checked = true; }

                #endregion

                #region //---------- DTHINT -----------
                string dthintSelect = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4, ditel, dinforel, DPOLST from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=2  ";
                if (dthpayObj.existRecored(dthintSelect) == 0)
                {
                    //dthpayObj.connclose();                    
                    throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                }
                else
                {
                    dthpayObj.readSql(dthintSelect);
                    OracleDataReader dthintREADER = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintREADER.Read())
                    {
                        if (!dthintREADER.IsDBNull(0)) { infodat = dthintREADER.GetInt32(0); } else { infodat = 0; }
                        if (!dthintREADER.IsDBNull(3)) { dateofdeath = dthintREADER.GetInt32(3); } else { dateofdeath = 0; }
                        if (!dthintREADER.IsDBNull(13)) { STA = dthintREADER.GetString(13); } else { STA = ""; }
                    }
                    dthintREADER.Close();
                    dthintREADER.Dispose();
                }

                //if (dateofdeath < int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2))) { STA = "I"; }
                #endregion
                
                #region //****** Demmands ********

                //******** Showing Demmands ******
                int dateofdthYM = int.Parse(dateofdeath.ToString().Substring(0, 6));
                int dateofdthdate = int.Parse(dateofdeath.ToString().Substring(6, 2));
                int comdate = int.Parse(COM.ToString().Substring(6, 2));
                int demanddate = 0;
                double demandPrem = 0.0;
                int count = 0;
                string mydemandsql = "";
                arr01 = new ArrayList();
                arr02 = new ArrayList();

                //Table 56 Changes
                //string mydemandsql = "select pdcod, pddue, pdprm from LPHS.DEMAND where pdpol='" + polno + "' and " +
                //    "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";

                if (dateofdthdate > comdate)
                {
                    mydemandsql = "select pdcod, pddue, pdprm from LPHS.DEMAND where pdpol='" + polno + "' and " +
                        "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= " + dateofdthYM + " and pddue <= " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";
                }
                else
                {
                    mydemandsql = "select pdcod, pddue, pdprm from LPHS.DEMAND where pdpol='" + polno + "' and " +
                        "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";
                }

                if (dthpayObj.existRecored(mydemandsql) != 0)
                {
                    dthpayObj.readSql(mydemandsql);
                    OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (mydemandreader01.Read())
                    {
                        count++;
                        demanddate = mydemandreader01.GetInt32(1);
                        demandPrem = mydemandreader01.GetDouble(2);
                        int demanddateYMD = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2));
                        if (demanddateYMD <= dateofdeath)
                        {
                            arr01.Add(demanddate.ToString());
                            arr02.Add(demandPrem.ToString());
                            if (count == 1)
                            {
                                this.createDemmandTable(demanddate.ToString(), count - 1, memoApprv, STA);
                                this.createDemmandTable(demanddate.ToString(), count, memoApprv, STA);
                            }
                            else { this.createDemmandTable(demanddate.ToString(), count, memoApprv, STA); }
                        }
                    }
                    //countStatic = count;
                    mydemandreader01.Close();
                    mydemandreader01.Dispose();
                }

                #endregion

                #region//----------------------LPLTRN check-----------------

                if (int.Parse(dateofdeath.ToString().Substring(0, 4)) < 2004)
                {
                    txtLoanint.ReadOnly = false;
                }

                string lpltrnsel = "select LTLRD from LPAY.LPAYTRN where LTLON in (select LMLON from LPHS.LPLMAST where LMPOL=" + polno + " and (LMCD1<>'D' or LMCD1 is null)) and LTLRD>" + dateofdeath + "";
                if (dthpayObj.existRecored(lpltrnsel) != 0)
                {
                    txtLoanint.ReadOnly = false;
                    txtLoan.ReadOnly = false;
                }
                #endregion


                //----------Calculating age of second life----Editted By Dushan-----------
                #region
                //Task 30675
                //if ((MOS == "2") && ((TBL == 38) || (TBL == 39) || (TBL == 49) || (TBL == 56)))
                if (((MOS == "2") || (MOS == "C")) && ((TBL == 38) || (TBL == 39) || (TBL == 49) || (TBL == 56)))
                {
                    String mosageselect = "select DOB from LUND.POLPERSONAL where POLNO= '" + polno + "' and (PRPERTYPE=4 OR PRPERTYPE=3)";
                    if (dthpayObj.existRecored(mosageselect) != 0)
                    {
                        dthpayObj.readSql(mosageselect);
                        OracleDataReader mosageread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (mosageread.Read())
                        {
                            if (!mosageread.IsDBNull(0)) { seclifeage = mosageread.GetInt32(0); } else { seclifeage = 0; }
                        }
                        mosageread.Close();
                        mosageread.Dispose();
                    }
                    else 
                    {
                        //dthpayObj.connclose();                        
                        throw new Exception("No Second Life Details Found!"); 
                    }
                    if (seclifeage > 9999999)
                    {
                        ageofsecondlife = this.dateComparison(seclifeage, dateofdeath)[0];

                        try
                        {
                            int seclifedob = seclifeage;
                            DateTime dtodsl = new DateTime(int.Parse(dateofdeath.ToString().Substring(0, 4)), int.Parse(dateofdeath.ToString().Substring(4, 2)), int.Parse(dateofdeath.ToString().Substring(6, 2)));
                            DateTime dtobsl = new DateTime(int.Parse(seclifedob.ToString().Substring(0, 4)), int.Parse(seclifedob.ToString().Substring(4, 2)), int.Parse(seclifedob.ToString().Substring(6, 2)));

                            fullageofSecond = dtodsl.Subtract(dtobsl).Days / 365.25;


                            if((int.Parse(dateofdeath.ToString().Substring(4, 2))==int.Parse(seclifedob.ToString().Substring(4, 2))) && (int.Parse(dateofdeath.ToString().Substring(0, 4))-int.Parse(seclifedob.ToString().Substring(0, 4))==14))
                            {
                                if (int.Parse(dateofdeath.ToString().Substring(6, 2)) - int.Parse(seclifedob.ToString().Substring(6, 2)) > 0)//exceed 14
                                    fullageofSecond = 14.1;
                                else
                                    fullageofSecond = 14.0;
                            
                            }


                           
                        }
                        catch (Exception)
                        {
                            
                            fullageofSecond = ageofsecondlife;
                        }


                    }
                    else
                    {
                        throw new Exception("Second life DOB not in a correct format");
                    }
                }
                #endregion
                //------------------------------------------------------------------------

                //************* sum assured calculation ****************************************************
                //************* only if sum assured is not calculated previously ***************************
                totbons = vestedBonus + interimBonus - surrrenderedbons;
                inforceDuration = this.dateComparison(COM, dateofdeath)[0];                
                paidPremcount = this.premcount(COM, dateofdeath, MOD, polno);
                //int premsForTerm = 0;
                int multiplyier = 0;
                string demandsql = "";
                if (MOD == 1) { multiplyier = 12; }
                else if (MOD == 2) { multiplyier = 6; }
                else if (MOD == 3) { multiplyier = 3; }
                else if (MOD == 4) { multiplyier = 1; }
                //premsForTerm = TRM * multiplyier;

                int demCount = 0;

                //Table 56 Changes
               // string demandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
               //"( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue < " + DUE + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";

                if (dateofdthdate > comdate)
                {
                    demandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                   "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue < " + DUE + " and pddue <= " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";
                }
                else
                {
                    demandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' and " +
                   "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue < " + DUE + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";
                }

                if (dthpayObj.existRecored(demandsql) != 0)
                {
                    dthpayObj.readSql(demandsql);
                    OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (mydemandreader01.Read())
                    {
                        demCount++;
                        //demanddate = mydemandreader01.GetInt32(1);
                        //int demanddateYMD = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2));                          
                    }
                    mydemandreader01.Close();
                    mydemandreader01.Dispose();
                }
                countStatic = demCount;

                //if (((TBL != 34) && (TBL != 38) && (TBL != 39) && (TBL != 46) && (TBL != 49)) || (STA.Equals("L")))
                //{
                //    this.txtvestedbons.Text = vestedBonus.ToString();
                //    this.txtinterimbons.Text = interimBonus.ToString();
                //}
                if ((MOS == "M")) 
                {
                    if (TBL != 2 || TBL != 4 || TBL != 6 || TBL != 42||TBL!=51)
                    {
                        this.txtvestedbons.Text = vestedBonus.ToString();
                        this.txtinterimbons.Text = interimBonus.ToString();
                    }
                    else 
                    {
                        this.txtvestedbons.Text = "0.00";
                        this.txtinterimbons.Text = "0.00";
                    }
                }

                else if ((MOS == "2" || MOS == "C")) 
                {
                    if ((TBL == 38) || (TBL == 39) || (TBL == 49)) 
                    { 
                        //if ((inforceDuration >= 5) && (ageofsecondlife >= 15))
                        if ((inforceDuration >= 5) && (fullageofSecond >14)) //15477
                        {
                            this.txtvestedbons.Text = vestedBonus.ToString();
                            this.txtinterimbons.Text = interimBonus.ToString();
                        }
                    }
                    else
                    {
                        this.txtvestedbons.Text = "0.00";
                        this.txtinterimbons.Text = "0.00";
                    }
                }
                else if ((MOS == "S")) 
                {
                    if ((TBL == 14) || (TBL == 46))
                    {
                        this.txtvestedbons.Text = vestedBonus.ToString();
                        this.txtinterimbons.Text = interimBonus.ToString();
                    }
                    else 
                    {
                        this.txtvestedbons.Text = "0.00";
                        this.txtinterimbons.Text = "0.00"; 
                    }
                }
                
                //else if ((MOS == "2") && ((TBL == 38) || (TBL == 39) || (TBL == 49)) && (STA.Equals("I")))
                //{
                //    if ((inforceDuration >= 5) && (ageofsecondlife > 15))
                //    {
                //        this.txtvestedbons.Text = vestedBonus.ToString();
                //        this.txtinterimbons.Text = interimBonus.ToString();
                //    }
                //}
                //if ((MOS == "S") && ((TBL != 14) || (TBL != 46)) && (STA.Equals("I")))
                //{
                //        this.txtvestedbons.Text = "0.00";
                //        this.txtinterimbons.Text = "0.00"; 
                //}
                //else 
                //{ 
                //    this.txtvestedbons.Text = "0.00"; this.txtinterimbons.Text = "0.00"; 
                //}
                

                #region // ---- checking for paid stage payment ---
                if (TBL == 13) 
                {
                    string vouno = "";
                    int voudat = 0;
                    int docno = 0;
                    string lclmmastSel = "select pvouno, pvoudat, pdocno from lclm.lcmmast where ptyp = 2 and ppolno = " + polno + " ";                    
                    if (dthpayObj.existRecored(lclmmastSel) != 0) 
                    {
                        dthpayObj.readSql(lclmmastSel);
                        OracleDataReader lclmmastread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (lclmmastread.Read()) 
                        {
                            if (!lclmmastread.IsDBNull(0)) { vouno = lclmmastread.GetString(0); } else { vouno = ""; }
                            if (!lclmmastread.IsDBNull(1)) { voudat = lclmmastread.GetInt32(1); } else { voudat = 0; }
                            if (!lclmmastread.IsDBNull(2)) { docno = lclmmastread.GetInt32(2); } else { docno = 0; }
                        }
                        lclmmastread.Close();
                        lclmmastread.Dispose();

                        if (docno > 0 && (voudat == 0 || (vouno == null || vouno.Equals("")))) { this.lblsuccess.Text = "there is and unpaid stage payment regarding this policy. Please Check."; }

                    }
                }

                #endregion

                #region  //******************* inforced ****************

                if (STA.Equals("I"))
                {
                    //**************** 5, 14, 27, 13 *********************
                    if (TBL == 5 || TBL == 14 || TBL == 27 || TBL == 13 || TBL == 52 || TBL == 55)
                    {
                        sumassured = SUM;
                    }
                    //*************** 28 *********************************
                    else if (TBL == 28)
                    {
                        sumassured = (SUM * 2);
                    }
                    //*************** 29 *********************************
                    else if (TBL == 29 && MOF.Equals("M"))
                    {
                        sumassured = (SUM + (SUM * 0.05 * inforceDuration)) * 2;
                    }
                    //************** 42 ********************************
                    else if (TBL == 42)
                    {
                        if (MOD > 4)
                        {
                            if (inforceDuration == 0) { sumassured = PRM; }
                            else if (inforceDuration == 1) { sumassured = PRM * 2; }
                            else if (inforceDuration == 2) { sumassured = PRM * 3; }
                            else if (inforceDuration == 3) { sumassured = PRM * 4; }
                            else if (inforceDuration >= 4) { sumassured = PRM * 5; }
                            //else if (inforceDuration > 4) { sumassured = PRM * 5; }
                        }
                        else
                        {
                            // ---- getting total premiums from ledger ---
                            string ledgertotal = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                            string ledgertotal2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7  or llcod = 9) group by llpol";//...remove 2009/05/13....because of Yastiya default Adjsement ...  (or llcod = 8)
                            if (dthpayObj.existRecored(ledgertotal) != 0)
                            {
                                dthpayObj.readSql(ledgertotal2);
                                OracleDataReader ledgertotread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                ledgertotread.Read();
                                sumassured = ledgertotread.GetDouble(0);
                                ledgertotread.Close();
                                ledgertotread.Dispose();
                            }
                            if (inforceDuration > 1) { sumassured *= 2; }
                            //if (inforceDuration <= 1) { sumassured = paidPremcount * PRM; }
                            //else { sumassured = paidPremcount * PRM * 2; }
                        }
                    }
                    //**************** 45 *******************************
                    else if (TBL == 45)
                    {
                        sumassured = paidPremcount * PRM;
                    }
                    //**************** 22 *******************************
                    else if (TBL == 22)
                    {
                        sumassured = SUM;
                    }
                    //**************** 38 ********************************
                    else if ((TBL == 38) || (TBL == 39) || (TBL == 49))
                    {
                        #region
                        if (!MOF.Equals("M"))
                        {
                            if (MOF.Equals("C"))
                            {
                                //if (ageofsecondlife >= 15 && inforceDuration >= 5)
                                if (fullageofSecond > 14 && inforceDuration >= 5) //15477
                                {
                                    sumassured = SUM;
                                }

                            }
                            else if (MOF.Equals("2"))//-----Editted By Dushan----
                            {
                                //if ((inforceDuration >= 5) && (ageofsecondlife >= 15))//15477
                                if ((inforceDuration >= 5) && (fullageofSecond > 14))
                                {
                                    sumassured = SUM;
                                    //if ((inforceDuration >= 5) && (ageofsecondlife > 15))
                                    //{
                                    this.txtvestedbons.Text = vestedBonus.ToString();
                                    this.txtinterimbons.Text = interimBonus.ToString();
                                    //}
                                }
                                else
                                {
                                    sumassured = 0;
                                    string ledgerprem = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                                    string ledgerprem2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) group by llpol";
                                    if (dthpayObj.existRecored(ledgerprem) != 0)
                                    {
                                        dthpayObj.readSql(ledgerprem2);
                                        OracleDataReader ledgerpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                        ledgerpremread.Read();
                                        premtot = ledgerpremread.GetDouble(0);
                                        ledgerpremread.Close();
                                        ledgerpremread.Dispose();
                                    }
                                    this.txtrefofPrems.Text = premtot.ToString();
                                }
                            }
                            else if (MOF.Equals("S")) // 44977
                            {
                                sumassured = SUM;
                            }//-------------------------------------------------
                            else
                            {
                                sumassured = paidPremcount * PRM;
                            }
                        }
                        else
                        {
                            sumassured = SUM;
                        }
                        #endregion
                    }
                    //**************** 34 *********************************
                    else if (TBL == 40)  // remove (TBL == 34 ||)
                    {
                        if (!MOF.Equals("M"))
                        {
                            //sumassured = paidPremcount * PRM;
                            sumassured = 0;

                            string ledgerprem = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                            string ledgerprem2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) group by llpol";
                            if (dthpayObj.existRecored(ledgerprem) != 0)
                            {
                                dthpayObj.readSql(ledgerprem2);
                                OracleDataReader ledgerpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                ledgerpremread.Read();
                                premtot = ledgerpremread.GetDouble(0);
                                ledgerpremread.Close();
                                ledgerpremread.Dispose();
                            }
                            this.txtrefofPrems.Text = premtot.ToString();
                            txtsumPVL.ReadOnly = true;
                            txtrefofPrems.ReadOnly = true;
                        }
                        else
                        {
                            sumassured = SUM;
                            //vestedBonus = 0;
                        }
                    }

                    else if (TBL == 34)
                    {
                        if (MOF.Equals("S") || MOF.Equals("M")) // if main life death Only SumAssrd
                        {
                            premtot = 0;
                            sumassured = SUM;
                            this.txtrefofPrems.Text = premtot.ToString();
                        }
                        else
                        {
                            //Chlid Death
                            //Policy Terminate
                            sumassured = 0;

                            string ledgerprem = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                            string ledgerprem2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) group by llpol";
                            if (dthpayObj.existRecored(ledgerprem) != 0)
                            {
                                dthpayObj.readSql(ledgerprem2);
                                OracleDataReader ledgerpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                ledgerpremread.Read();
                                premtot = ledgerpremread.GetDouble(0);
                                ledgerpremread.Close();
                                ledgerpremread.Dispose();
                            }
                            this.txtrefofPrems.Text = premtot.ToString();//refund paid premiums
                            txtsumPVL.ReadOnly = true;

                            //Task 27311
                            //txtrefofPrems.ReadOnly = true;

                            string LPOLHIScheck1 = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA  from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and (phmos = 'M' OR  phmos = 'S' ) ";

                            if (dthpayObj.existRecored(LPOLHIScheck1) > 0)
                            {
                                dthpayObj.readSql(LPOLHIScheck1);
                                OracleDataReader lpolhisread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                int lastDue = COM;//temporary
                                while (lpolhisread.Read())
                                {
                                    lastDue = lpolhisread.GetInt32(8);
                                    lastDue = int.Parse(lastDue.ToString() + COM.ToString().Substring(6, 2)); //Set Date
                                }
                                lpolhisread.Close();
                                lpolhisread.Dispose();


                                int wavedPremiumCount = WaivedPremCount(lastDue, dateofdeath, MOD);
                                refOfPrems = premtot + wavedPremiumCount * PRM;//paid+ waived premiums
                                refOfPrems = Math.Round(refOfPrems, 2);
                            }
                            else
                            {
                                // refund paid premiums (already set)
                                //No bonus
                            }


                        }
                    }


                    else if (TBL == 46)
                    {
                        if (MOF.Equals("S") || MOF.Equals("M") || MOF.Equals("2"))
                        {
                            sumassured = 2 * SUM;
                        }
                        if (MOF.Equals("C"))
                        {
                            //sumassured = 2 * SUM;
                            sumassured = 0;
                            string ledgerprem = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                            string ledgerprem2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) group by llpol";
                            if (dthpayObj.existRecored(ledgerprem) != 0)
                            {
                                dthpayObj.readSql(ledgerprem2);
                                OracleDataReader ledgerpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                ledgerpremread.Read();
                                premtot = ledgerpremread.GetDouble(0);
                                ledgerpremread.Close();
                                ledgerpremread.Dispose();
                            }
                            this.txtrefofPrems.Text = premtot.ToString();
                        }
                    }
                    else if (TBL == 51)
                    {
                        double poldura = (double)this.Duration(COM, dateofdeath) / 12;
                        BenefitRead bfr = new BenefitRead();
                        bfr.Fetch(polno, SUM, TRM, dthpayObj);
                        QuotDataSet qds = new QuotDataSet();

                        sumassured = qds.Deathonmaturity(SUM, bfr.Invbenamt, poldura, bfr.Invbenrate, bfr.Lifecov);
                    }
                    else if (TBL == 53)
                    {
                        sumassured = SUM;
                    }
                    else if (TBL == 56)
                    {
                        if (MOF.Equals("M"))
                        {
                            sumassured = SUM * 3;
                        }
                        else if (MOF.Equals("2") || MOF.Equals("C"))
                        {
                            //
                            if (dateofdeath >= COM && dateofdeath <= (COM + ((TRM + benefitPeriod) * 10000)))
                            {
                                sumassured = 0;
                                string ledgerprem = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                                string ledgerprem2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) group by llpol";
                                if (dthpayObj.existRecored(ledgerprem) != 0)
                                {
                                    dthpayObj.readSql(ledgerprem2);
                                    OracleDataReader ledgerpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    ledgerpremread.Read();
                                    premtot = ledgerpremread.GetDouble(0);
                                    ledgerpremread.Close();
                                    ledgerpremread.Dispose();
                                }
                                this.txtrefofPrems.Text = premtot.ToString();
                            }
                        }
                        else
                        {
                            sumassured = SUM;
                        }
                    }
                    //Calculation For TBL 58
                    else if (TBL == 58)
                    {
                        double poldura = (double)this.Duration(COM, dateofdeath) / 12;

                        if (poldura > 1)
                        {
                            sumassured = (double)(SUM + (SUM * 0.05 * (int)poldura)) * 1.25;
                        }
                        else
                        {
                            sumassured = SUM * 1.25;
                        }                        
                    }
                    else
                    { sumassured = SUM; }

                    sumassured = Math.Round(sumassured, 2);
                }
                #endregion

                #region //******************* lapsed *******************

                else if (STA.Equals("L"))
                {
                    double lapsedPayedYears = 0;
                    int lapsedPayedMonths = 0;
                    int lapsedPayedDays = 0;

                    if (COM > 9999999)
                    {
                        lapsedPayedYears = this.dateComparison(COM, int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)))[0];
                        lapsedPayedMonths = this.dateComparison(COM, int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)))[1];
                        lapsedPayedDays = this.dateComparison(COM, int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)))[2];
                    }

                    lapsedPayedYears += ((double)lapsedPayedMonths / 12.0);
                    //lapsedPayedYears = Math.Round(lapsedPayedYears, 2);
                    //lapsedPayedYears -= (Math.Round((countStatic * (double)multiplyier / 12.0), 2));             
                    lapsedPayedYears -= (countStatic * (double)multiplyier / 12.0);
                    //lapsedPayedYears = Math.Round(lapsedPayedYears, 2);
                    double sumbyterm = (double)SUM / (double)TRM;

                    //*************** 5, 14, 27 ******************************
                    if (TBL == 5 || TBL == 14 || TBL == 27 || TBL == 17 || TBL == 52) //27 as Life Dept.
                    {
                        sumassured = (double)SUM / (double)TRM * lapsedPayedYears;
                    }
                    //************* 13 ***************************************
                    else if (TBL == 13)
                    {
                        if (TRM == 10)
                        {
                            //if (inforceDuration < 4) { sumassured = sumbyterm * lapsedPayedYears + totbons; }
                            if (lapsedPayedYears < 4) { sumassured = sumbyterm * lapsedPayedYears; }
                            //else if (inforceDuration > 3 && inforceDuration < 7)
                            else if (lapsedPayedYears > 3 && lapsedPayedYears < 7)
                            {
                                //sumassured = sumbyterm * lapsedPayedYears;
                                sumassured = sumbyterm * lapsedPayedYears;
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = 0;
                                chkStage2.Enabled = false;
                                chkStage2.Checked = false;
                                //sumassured -= stgpmnt;
                            }
                            //else if (inforceDuration > 6 && inforceDuration < 10)
                            else if (lapsedPayedYears > 6 && lapsedPayedYears < 10)
                            {
                                //sumassured = sumbyterm * lapsedPayedYears;
                                sumassured = sumbyterm * lapsedPayedYears;
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = SUM * 0.3;
                                //sumassured -= stgpmnt;
                            }
                            else
                            {
                                //dthpayObj.connclose();                                
                                throw new Exception("Policy Matured!");
                            }
                        }
                        else if (TRM == 15)
                        {
                            if (lapsedPayedYears < 5) { sumassured = sumbyterm * lapsedPayedYears; }
                            else if (lapsedPayedYears > 4 && lapsedPayedYears < 10)
                            {
                                sumassured = sumbyterm * lapsedPayedYears;
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = 0;
                                chkStage2.Enabled = false;
                                chkStage2.Checked = false;
                                //sumassured = sumassured-stgpmnt;
                            }
                            else if (lapsedPayedYears > 9 && lapsedPayedYears < 15)
                            {
                                sumassured = sumbyterm * lapsedPayedYears;
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = SUM * 0.2;
                                //sumassured -= stgpmnt;
                            }
                            else
                            {
                                //dthpayObj.connclose();
                                throw new Exception("Policy Matured!");
                            }
                        }
                        else if (TRM == 20)
                        {
                            if (lapsedPayedYears < 10) { sumassured = sumbyterm * lapsedPayedYears; }
                            else if (lapsedPayedYears > 9 && lapsedPayedYears < 15)
                            {
                                sumassured = sumbyterm * lapsedPayedYears;
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = 0;
                                chkStage2.Enabled = false;
                                chkStage2.Checked = false;
                                //sumassured -= stgpmnt;
                            }
                            else if (lapsedPayedYears > 14 && lapsedPayedYears < 20)
                            {
                                sumassured = sumbyterm * lapsedPayedYears;
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = SUM * 0.2;
                                //sumassured -= stgpmnt;
                            }
                            else
                            {
                                //dthpayObj.connclose();                                
                                throw new Exception("Policy Matured!");
                            }
                        }
                        else { }
                    }
                    //******************** 28 ******************************* 
                    else if (TBL == 28)
                    {
                        sumassured = sumbyterm * lapsedPayedYears;
                    }
                    //******************* 29 ********************************
                    else if (TBL == 29)
                    {
                        sumassured = ((SUM + (SUM * 0.05 * (int)lapsedPayedYears)) / TRM) * lapsedPayedYears;
                    }
                    //******************* 42 ********************************
                    else if (TBL == 42 || TBL == 45)
                    {
                        //amount calculated by the acturial department
                    }
                    //****************** 22 *********************************
                    else if (TBL == 22)
                    {
                        sumassured = sumbyterm * lapsedPayedYears;
                    }
                    //****************** 38, 34, 39 *************************
                    else if ((TBL == 38) || (TBL == 34) || (TBL == 39) || (TBL == 40) || (TBL == 49) || (TBL == 56))
                    {
                        if (TBL == 38)
                        {
                            int termbal;
                            termbal = TRM - (int)lapsedPayedYears;
                            if (termbal <= 1)
                            {
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = SUM * 0.2;
                                stgpmnt3 = SUM * 0.2;
                            }
                            else if (termbal <= 2)
                            {
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = SUM * 0.2;
                                stgpmnt3 = 0;
                            }
                            else if (termbal <= 3)
                            {
                                stgpmnt1 = SUM * 0.2;
                                stgpmnt2 = 0;
                                stgpmnt3 = 0;
                            }
                            else
                            {
                                stgpmnt1 = 0;
                                stgpmnt2 = 0;
                                stgpmnt3 = 0;
                            }

                        }

                        if (TBL == 56 && MOF == "S")
                        {
                            txtsumPVL.Text = "0";
                            txtsumPVL.ReadOnly = true;
                        }
                        else
                        {
                            if ((TRM <= 10 && lapsedPayedYears >= 2) || (TRM > 10 && lapsedPayedYears >= 3))
                            {
                                sumassured = sumbyterm * lapsedPayedYears;
                            }
                            else
                            {
                                txtsumPVL.Text = "0";
                                txtsumPVL.ReadOnly = true;
                            }
                        }

                        //Table 56 Changes
                        if (TBL == 34 || ((TBL == 56) && (MOF.Equals("C") || MOF.Equals("2"))))
                        {
                            if (MOF.Equals("M") || MOF.Equals("S"))
                            {
                                sumassured = (double)SUM / (double)TRM * lapsedPayedYears;
                            }
                            else
                            {
                                //string LPOLHIScheck1 = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA  from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = 'M' OR  phmos = 'S'  ";

                                //if (dthpayObj.existRecored(LPOLHIScheck1) > 0)
                                //{
                                    sumassured = 0;
                                    totbons = vestedBonus = interimBonus = surrrenderedbons=0;/////

                                    string ledgerprem = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                                    string ledgerprem2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) group by llpol";
                                    if (dthpayObj.existRecored(ledgerprem) != 0)
                                    {
                                        dthpayObj.readSql(ledgerprem2);
                                        OracleDataReader ledgerpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                        ledgerpremread.Read();
                                        premtot = ledgerpremread.GetDouble(0);
                                        ledgerpremread.Close();
                                        ledgerpremread.Dispose();
                                    }

                                    this.txtrefofPrems.Text = premtot.ToString();
                                    txtsumPVL.ReadOnly = true;

                                    //Table 56 Changes
                                    if (TBL == 56 && (TRM <= 10 && lapsedPayedYears >= 2) || (TRM > 10 && lapsedPayedYears >= 3))
                                    {
                                        this.txtrefofPrems.Text = premtot.ToString();
                                        txtsumPVL.ReadOnly = true;
                                    }
                                    else
                                    {
                                        this.txtrefofPrems.Text = "0";
                                        txtsumPVL.ReadOnly = true;
                                    }
                                //}
                            }

                            
                        }

                        //if ((TBL == 39) || (TBL == 49))
                        //{
                        //    string ledgertotal = "select llprm from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7 or llcod = 8 or llcod = 9) ";
                        //    string ledgertotal2 = "select sum(llprm)as sumOfPrm,llpol from lclm.ledger where llpol = " + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and (llcod = 5 or llcod = 6 or llcod = 7  or llcod = 9) group by llpol";//...remove 2009/05/13....because of Yastiya default Adjsement ...  (or llcod = 8)
                        //    if (dthpayObj.existRecored(ledgertotal) != 0)
                        //    {
                        //        dthpayObj.readSql(ledgertotal2);
                        //        OracleDataReader ledgertotread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        //        ledgertotread.Read();
                        //        sumassured = ledgertotread.GetDouble(0);
                        //        ledgertotread.Close();
                        //        ledgertotread.Dispose();
                        //    }
                        //    txtsumPVL.ReadOnly = true;
                        //}
                    }
                    else if (TBL == 53)
                    {
                       // sumassured = SUM;
                    }
                    else if (TBL == 55)
                    {
                        txtsumPVL.Text = "0";
                        txtsumPVL.ReadOnly = true;
                    }
                    //LAPS Calculations For TBL 58
                    else if(TBL == 58)
                    {
                        //Check if Payed term  grater than 2
                        if(lapsedPayedYears >= 2)
                        {
                            int premiumPaidterm = (int)lapsedPayedYears;

                            double increaceSA = (double)(SUM + Math.Round((SUM * 0.05 * (premiumPaidterm - 1)), 2));

                            sumassured = increaceSA * (lapsedPayedYears / PrePayingTerm);
                        }
                       
                    }
                    else { }

                    if ((TRM <= 10) && (lapsedPayedYears < 2))
                    {
                        //Table 45 surrender value
                        if (TBL != 45 && TBL != 58 && TBL != 57)
                        {
                            sumassured = 0;
                            repudiatnFlag = true;
                        }
                        else if (TBL == 45 && lapsedPayedYears < 1)
                        {
                            //Task 36696
                            //sumassured = 0;
                            //repudiatnFlag = true;
                        }
                    }
                    else if ((TRM > 10) && ((lapsedPayedYears < 3)))
                    {
                        //Table 45 surrender value
                        if (TBL != 45 && TBL != 58 && TBL != 57)
                        {
                            sumassured = 0;
                            repudiatnFlag = true;
                        }
                        else if (TBL == 45 && lapsedPayedYears < 1)
                        {
                            //Task 36696
                            //sumassured = 0;
                            //repudiatnFlag = true;
                        }
                    }
                    sumassured = Math.Round(sumassured, 2);
                }
                else { }

                #endregion

                //#region -------- Swarna Jayanthi Paid Amount ---------  
                ////string paidSJAmountSel = "select sum(TOTAMOUNT) from cashbook.temp_cb where POLNO = '" + polno + "' and VOUTYP='Swarna Jayanthi' and PRINT1=1 and STATUS='Paid'";
                //string paidSJAmountSel = "select sum(TOTAMOUNT) from cashbook.temp_cb where POLNO = '" + polno + "' and (VOUTYP='Swarna Jayanthi' or vouno like 'SJ/%') and PRINT1=1 and STATUS='Paid'";
                //dthpayObj.readSql(paidSJAmountSel);
                //OracleDataReader paidSJAmountRead = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //while (paidSJAmountRead.Read())
                //{
                //    if (!paidSJAmountRead.IsDBNull(0)) { paidSJAmount = paidSJAmountRead.GetDouble(0); } else { paidSJAmount = 0; } 
                //}
                //paidSJAmountRead.Close();
                //paidSJAmountRead.Dispose();
                //#endregion

                #region //***** Inforce and Lapsed *****
                if (STA.Equals("I"))
                {
                    this.lblsumassPVal.Text = "Sum Assured";
                    this.lbladb.Visible = true;
                    this.lbladb.Text = "A.D.B.";
                    this.txtadb.Visible = true;
                    // this.txtadb.Text = String.Format("{0:N}", ADB);
                    this.txtadb.Text = ADB.ToString();
                    if (ADBlatepay.Equals("Y")) { this.chkADBpaylater.Checked = true; } else { this.chkADBpaylater.Checked = false; }

                    this.lblfpu.Visible = true;
                    this.lblfpu.Text = "F.P.U.";
                    this.txtfpu.Visible = true;
                    // this.txtfpu.Text = String.Format("{0:N}", FPU);
                    this.txtfpu.Text = FPU.ToString();
                    if (FEearlyPay.Equals("Y")) { this.chkFEpayearly.Checked = true; } else { this.chkFEpayearly.Checked = false; }

                    this.lblfe.Visible = true;
                    this.lblfe.Text = "Funeral Expences";
                    this.txtfe.Visible = true;
                    // this.txtfe.Text = String.Format("{0:N}", FE);
                    this.txtfe.Text = FE.ToString();

                    #region ----------------- Swarna Jayanthi --------------
                    //this.lblSJGross.Visible = true;
                    //this.lblSJGross.Text = "Swarna Jayanthi Gross Amount";
                    //this.txtSJGrossAmt.Visible = true;
                    //this.txtSJGrossAmt.Text = SJ.ToString();

                    //this.lblSJPaid.Visible = true;
                    //this.lblSJPaid.Text = "Swarna Jayanthi Paid Amount";
                    //this.txtSJPaidAmt.Visible = true;
                    //this.txtSJPaidAmt.Text = paidSJAmount.ToString();

                    this.lblsj.Visible = true;
                    this.lblsj.Text = "Swarna Jayanthi";
                    this.txtsj.Visible = true;
                    //this.txtsj.Text = (SJ - paidSJAmount).ToString();
                    this.txtsj.Text = (SJ).ToString();
                    #endregion

                    #region // ---- code to read exgramts table ----
                    if (exgraciaAmt > 0)
                    {
                        double SUMONEX = 0, ADBONEX = 0, FPUONEX = 0, FEONEX = 0, SJONEX = 0, OTHERADDONEX = 0, REFOFPRMONEX = 0;
                        string exgrAmtsSel = "select SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF ='" + MOS + "' ";
                        dthpayObj.readSql(exgrAmtsSel);
                        OracleDataReader exgrAmtsRead = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (exgrAmtsRead.Read())
                        {
                            if (!exgrAmtsRead.IsDBNull(0)) { SUMONEX = exgrAmtsRead.GetDouble(0); } else { SUMONEX = 0; }
                            if (!exgrAmtsRead.IsDBNull(1)) { ADBONEX = exgrAmtsRead.GetDouble(1); } else { ADBONEX = 0; }
                            if (!exgrAmtsRead.IsDBNull(2)) { FPUONEX = exgrAmtsRead.GetDouble(2); } else { FPUONEX = 0; }
                            if (!exgrAmtsRead.IsDBNull(3)) { FEONEX = exgrAmtsRead.GetDouble(3); } else { FEONEX = 0; }
                            if (!exgrAmtsRead.IsDBNull(4)) { SJONEX = exgrAmtsRead.GetDouble(4); } else { SJONEX = 0; }
                            if (!exgrAmtsRead.IsDBNull(5)) { OTHERADDONEX = exgrAmtsRead.GetDouble(5); } else { OTHERADDONEX = 0; }
                            if (!exgrAmtsRead.IsDBNull(6)) { REFOFPRMONEX = exgrAmtsRead.GetDouble(6); } else { REFOFPRMONEX = 0; }

                        }
                        exgrAmtsRead.Close();
                        exgrAmtsRead.Dispose();

                        if (SUMONEX > 0) { this.chksumOnExg.Checked = true; }
                        if (ADBONEX > 0) { this.chkadbOnEx.Checked = true; }
                        if (FPUONEX > 0) { this.chkfpuOnExg.Checked = true; }
                        if (FEONEX > 0) { this.chkFeOnExg.Checked = true; }
                        if (SJONEX > 0) { this.chkSjonExg.Checked = true; }
                        if (OTHERADDONEX > 0) { this.chkotheraddOnExg.Checked = true; }
                        if (REFOFPRMONEX > 0) { this.chkrefpremonExg.Checked = true; }
                     
                    }
                    #endregion
                }
                else
                {
                    this.lblsumassPVal.Text = "Paid up Value";
                    this.chksumOnExg.Text = "Paid up Value on Exgracia";
                    this.lbladb.Visible = false;
                    this.txtadb.Visible = false;
                    this.lblfpu.Visible = false;
                    this.txtfpu.Visible = false;
                    this.lblfe.Visible = false;
                    this.txtfe.Visible = false;
                    
                    //this.lblsj.Visible = false;
                    //this.txtsj.Visible = false;
                    int lapsedPayedYr = this.dateComparison(COM, int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)))[0];
                    if (lapsedPayedYr >= 2)
                    {
                        //this.lblSJGross.Visible = true;
                        //this.lblSJGross.Text = "Swarna Jayanthi Gross Amount";
                        //this.txtSJGrossAmt.Visible = true;
                        //this.txtSJGrossAmt.Text = SJ.ToString();

                        //this.lblSJPaid.Visible = true;
                        //this.lblSJPaid.Text = "Swarna Jayanthi Paid Amount";
                        //this.txtSJPaidAmt.Visible = true;
                        //this.txtSJPaidAmt.Text = paidSJAmount.ToString();

                        this.lblsj.Visible = true;
                        this.lblsj.Text = "Swarna Jayanthi";
                        this.txtsj.Visible = true;
                        //this.txtsj.Text = (SJ - paidSJAmount).ToString();
                        this.txtsj.Text = (SJ).ToString();
                    }
                    else
                    {
                        //this.lblSJGross.Visible = false;
                        //this.txtSJGrossAmt.Visible = false;
                        //this.lblSJPaid.Visible = false;
                        //this.txtSJPaidAmt.Visible = false;
                        this.lblsj.Visible = false;
                        this.txtsj.Visible = false;
                    }
                    
                    this.chkFEpayearly.Visible = false;
                    this.chkADBpaylater.Visible = false;
                    this.chkFEpayearly.Checked = false;
                    this.chkADBpaylater.Checked = false;
                    this.chkadbOnEx.Visible = false;
                    this.chkfpuOnExg.Visible = false;
                    this.chkFeOnExg.Visible = false;
                    this.chkSjonExg.Visible = false;
                    
                    //Task 31932
                    //this.txtinterimbons.Visible = false;
                    //this.litintbon.Visible = false;

                    this.Label1.Visible = false;
                    this.Label2.Visible = false;
                }

                #endregion

                if (((memoApprv.Equals("Y")) || (memoApprv.Equals("R"))) && (x > 0)) { sumassured = x; }
                if (TBL != 42 && TBL != 45)
                { this.txtsumPVL.Text = sumassured.ToString(); }
                else
                { this.txtsumPVL.Text = "0"; this.txtrefofPrems.Text = sumassured.ToString(); }

                #region ---- making text boxes Read only selectively ----
                if ((memoApprv.Equals("Y")) || (memoApprv.Equals("R")))
                {
                    this.txtsumPVL.ReadOnly = true;
                    this.txtadb.ReadOnly = true;
                    this.txtfpu.ReadOnly = true;
                    this.txtfe.ReadOnly = true;
                    //this.txtsj.ReadOnly = true;
                    //this.txtSJGrossAmt.ReadOnly = true;
                    this.txtotheradd.ReadOnly = true;
                    this.txtotherdeduct.ReadOnly = true;
                    this.txtrefofPrems.ReadOnly = true;
                    this.txtagediffamt.ReadOnly = true;
                    this.txtagediffamtInt.ReadOnly = true;//...add on buddhika 2009/04/07....
                    this.txtvestedbons.ReadOnly = true;
                    this.chkADBpaylater.Enabled = false;
                    this.chkFEpayearly.Enabled = false;
                    this.ddlagediff.Enabled = false;

                    this.chkadbOnEx.Enabled = false;
                    this.chkFeOnExg.Enabled = false;
                    this.chkfpuOnExg.Enabled = false;
                    this.chkotheraddOnExg.Enabled = false;
                    this.chkrefpremonExg.Enabled = false;
                    this.chkSjonExg.Enabled = false;
                    this.chksumOnExg.Enabled = false;

                    this.btnok.Enabled = false;

                    if ((memoApprv.Equals("R"))) { this.btnSubmit.Enabled = false; } else { this.btnSubmit.Enabled = true; }

                    if ((memoApprv.Equals("R"))) { this.lblsuccess.Text = "Claim Repudiated"; this.lblsuccess.Visible = true; }
                }
                else
                {
                    //this.txtsumPVL.ReadOnly = false;
                    this.txtadb.ReadOnly = false;
                    this.txtfpu.ReadOnly = false;
                    this.txtfe.ReadOnly = false;
                    this.txtsj.ReadOnly = false;
                    this.txtotheradd.ReadOnly = false;
                    this.txtotherdeduct.ReadOnly = false;
                    //this.txtrefofPrems.ReadOnly = false;
                    this.txtagediffamt.ReadOnly = false;
                    this.txtagediffamtInt.ReadOnly = false;//...Add by Buddhika 2009/04/07...
                    this.txtvestedbons.ReadOnly = false;
                    this.chkADBpaylater.Enabled = true;
                    this.chkFEpayearly.Enabled = true;
                    this.ddlagediff.Enabled = true;

                    this.chkadbOnEx.Enabled = true;
                    this.chkFeOnExg.Enabled = true;
                    this.chkfpuOnExg.Enabled = true;
                    this.chkotheraddOnExg.Enabled = true;
                    this.chkrefpremonExg.Enabled = true;
                    this.chkSjonExg.Enabled = true;
                    this.chksumOnExg.Enabled = true;

                    this.btnok.Enabled = true;
                    this.btnSubmit.Enabled = false;
                }
                #endregion

                //#region Check Same Day Payment Task 39176
                
                //string checkSamePayment = "select LCPOL,to_char(to_date(LCDUE||'01','yyyyMMdd'),'yyyy/MM'),to_char(ENTRY_DATE,'YYYY-MM-DD HH:MI:SS AM') from lpay.lpaycom where LCPOL='"+ polno + "' and LCPDT='"+dateofdeath+"'";
                //if (dthpayObj.existRecored(checkSamePayment) != 0)
                //{
                //    string paidTime = "";
                //    string paidDue = "";
                //    dthpayObj.readSql(checkSamePayment);
                //    OracleDataReader checkSamePaymentReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    while (checkSamePaymentReader.Read())
                //    {
                //        if (!checkSamePaymentReader.IsDBNull(1)) { paidDue = checkSamePaymentReader.GetString(1); }
                //        if (!checkSamePaymentReader.IsDBNull(2)) { paidTime = checkSamePaymentReader.GetString(2); }

                //        havePayment = 1;
                //        havePaymentWarring = "Date of death and premium paid date of "+paidDue+" premium are same. Premium paid time "+paidTime+".";
                //        ViewState["havePayment"] = havePayment;
                //        ViewState["havePaymentWarring"] = havePaymentWarring;

                //        lblhasPayWarr.Text = havePaymentWarring;
                //        lblhasPayWarr.ForeColor = System.Drawing.Color.Red;
                //        pnlHavePayment.Visible = true;
                //    }
                //    checkSamePaymentReader.Close();
                //    checkSamePaymentReader.Dispose();
                //}
                //#endregion

                #region //------------ view state --------
                //please comment before loading to the test server

                //===========================================

                ViewState["brcode"] = brcode;
                ViewState["EPF"] = EPF;
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;
                ViewState["ageofsecondlife"] = ageofsecondlife;
                ViewState["fullageofsecondlife"] = fullageofSecond;

                
                ViewState["infodat"] = infodat;
                ViewState["dateofdeath"] = dateofdeath;                
                ViewState["COD"] = COD;              
                ViewState["COM"] = COM;
                ViewState["TBL"] = TBL;
                ViewState["TRM"] = TRM;
                ViewState["SUM"] = SUM;
                ViewState["MOD"] = MOD;
                ViewState["PRM"] = PRM;
                ViewState["DUE"] = DUE;
                ViewState["STA"] = STA;
                ViewState["PAC"] = PAC;
                ViewState["AGT"] = AGT;
                ViewState["ORG"] = ORG;
                ViewState["EPF"] = EPF;
                ViewState["ADB"] = ADB;
                ViewState["FPU"] = FPU;
                ViewState["SJ"] = SJ; ViewState["SJGen"] = SJ;
                ViewState["FE"] = FE;
                ViewState["FEearlyPay"] = FEearlyPay;
                ViewState["ADBlatepay"] = ADBlatepay;
                ViewState["DDEP"] = DDEP;
                ViewState["reinsYN"] = reinsYN;
                ViewState["vestedBonus"] = vestedBonus;
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
                ViewState["stgpmnt1"] = stgpmnt1;
                ViewState["stgpmnt2"] = stgpmnt2;
                ViewState["stgpmnt3"] = stgpmnt3;
                ViewState["sumassured"] = sumassured;
                ViewState["inforceDuration"] = inforceDuration;
                ViewState["repudiatnFlag"] = repudiatnFlag;

                ViewState["countStatic"] = countStatic;
                ViewState["arr01"] = arr01;
                ViewState["arr02"] = arr02;
                ViewState["memoApprv"] = memoApprv;
                ViewState["otherDeduct"] = otherDeduct;
                ViewState["causeofDth"] = causeofDth;
                ViewState["benefitPeriod"] = benefitPeriod;
                
                #endregion
                dthpayObj.connclose();
                dm.connClose();
            }
            catch (Exception ex)
            {
                dthpayObj.connclose();
                dm.connClose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            #region //------------ view state --------
            if (ViewState["brcode"] != null) { brcode = int.Parse(ViewState["brcode"].ToString()); }
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }
            if (ViewState["ageofsecondlife"] != null) { ageofsecondlife = int.Parse(ViewState["ageofsecondlife"].ToString()); }
            if (ViewState["fullageofsecondlife"] != null) { fullageofSecond = double.Parse(ViewState["fullageofsecondlife"].ToString()); }
            if (ViewState["infodat"] != null) { infodat = int.Parse(ViewState["infodat"].ToString()); }
            if (ViewState["dateofdeath"] != null) { dateofdeath = int.Parse(ViewState["dateofdeath"].ToString()); }
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }

            if (ViewState["COD"] != null) { COD = ViewState["COD"].ToString(); }
            if (ViewState["COM"] != null) { COM = int.Parse(ViewState["COM"].ToString()); }
            if (ViewState["TBL"] != null) { TBL = int.Parse(ViewState["TBL"].ToString()); }
            if (ViewState["TRM"] != null) { TRM = int.Parse(ViewState["TRM"].ToString()); }
            if (ViewState["SUM"] != null) { SUM = int.Parse(ViewState["SUM"].ToString()); }
            if (ViewState["MOD"] != null) { MOD = int.Parse(ViewState["MOD"].ToString()); }
            if (ViewState["PRM"] != null) { PRM = double.Parse(ViewState["PRM"].ToString()); }
            if (ViewState["DUE"] != null) { DUE = int.Parse(ViewState["DUE"].ToString()); }
            if (ViewState["STA"] != null) { STA = ViewState["STA"].ToString(); }
            if (ViewState["PAC"] != null) { PAC = int.Parse(ViewState["PAC"].ToString()); }
            if (ViewState["AGT"] != null) { AGT = int.Parse(ViewState["AGT"].ToString()); }
            if (ViewState["ORG"] != null) { ORG = int.Parse(ViewState["ORG"].ToString()); }
            if (ViewState["DDEP"] != null) { DDEP = double.Parse(ViewState["DDEP"].ToString());}

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

            if (ViewState["sumassured"] != null) { sumassured = double.Parse(ViewState["sumassured"].ToString()); }
            if (ViewState["stgpmnt1"] != null) { stgpmnt1 = double.Parse(ViewState["stgpmnt1"].ToString()); }
            if (ViewState["stgpmnt2"] != null) { stgpmnt2 = double.Parse(ViewState["stgpmnt2"].ToString()); }
            if (ViewState["stgpmnt3"] != null) { stgpmnt3 = double.Parse(ViewState["stgpmnt3"].ToString()); }
            if (ViewState["inforceDuration"] != null) { inforceDuration = int.Parse(ViewState["inforceDuration"].ToString()); }
            if (ViewState["repudiatnFlag"] != null) { repudiatnFlag = (bool)(ViewState["repudiatnFlag"]); }

            if (ViewState["countStatic"] != null) { countStatic = int.Parse(ViewState["countStatic"].ToString()); }
            if (ViewState["arr01"] != null) { arr01 = (ArrayList)ViewState["arr01"]; }
            if (ViewState["arr02"] != null) { arr02 = (ArrayList)ViewState["arr02"]; }
            if (ViewState["memoApprv"] != null) { memoApprv = ViewState["memoApprv"].ToString(); }
            if (ViewState["adbonexgr"] != null) { adbonexgr = ViewState["adbonexgr"].ToString(); }
            if (ViewState["otherDeduct"] != null) { otherDeduct = double.Parse(ViewState["otherDeduct"].ToString()); }
            if (ViewState["SJGen"] != null) { SJSysGenerat = double.Parse(ViewState["SJGen"].ToString()); }
            if (ViewState["causeofDth"] != null) { causeofDth = int.Parse(ViewState["causeofDth"].ToString()); }
            if (ViewState["benefitPeriod"] != null) { benefitPeriod = int.Parse(ViewState["benefitPeriod"].ToString()); }

            if (ViewState["havePayment"] != null) { havePayment = int.Parse(ViewState["havePayment"].ToString()); }
            if (ViewState["havePaymentWarring"] != null) { havePaymentWarring = ViewState["havePaymentWarring"].ToString(); }

    #endregion

    #region //----- else for post back -----

    int demanddate = 0;
            int incCount = 0;
            foreach (string demdate in arr01)
            {
                incCount++;
                demanddate = int.Parse(demdate);
                if (incCount == 1)
                {
                    this.createDemmandTable(demanddate.ToString(), incCount - 1, memoApprv, STA);
                    this.createDemmandTable(demanddate.ToString(), incCount, memoApprv, STA);
                }
                else
                {
                    this.createDemmandTable(demanddate.ToString(), incCount, memoApprv, STA);
                }
            }
            #endregion
           
        }

    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string MOF
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public string Adbonexgr
    {
        get { return adbonexgr; }
        set { adbonexgr = value; }
    }
    public int Seclifeage
    {
        get { return ageofsecondlife; }
        set { ageofsecondlife = value; }
    }

    public double SeclifeFullage
    {
        get { return fullageofSecond; }
        set { fullageofSecond = value; }
    }
    public double InterimBonus
    {
        get { return interimBonus; }
        set { interimBonus = value; }
    }
    public double VestedBonus
    {
        get { return vestedBonus; }
        set { vestedBonus = value; }
    }

    public double SJSysGenerat
    {
        get { return SJsysGenerat; }
        set { SJsysGenerat = value; }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        chkRefdep.Enabled = false;
        if (!repudiatnFlag)
        {            
            try
            {
                dthpayObj = new DataManager();
                dm = new DataManager();
                dm.begintransaction();
                //dthpayObj.begintransaction();

                #region//----------Loan Details Change------Editted By Dushan----
                double chgdloncap;
                double chngdlonint;
                if (txtLoan.Text == "-"){ txtLoan.Text = "0.0"; }
                if (txtLoanint.Text == "-") { txtLoanint.Text = "0.0"; }
                chgdloncap = double.Parse(txtLoan.Text);
                chngdlonint = double.Parse(txtLoanint.Text);
                if (chgdloncap != loancap || chngdlonint != loanint)
                {
                    //string dthrefupdt = "update LPHS.DTHREF set DRLONCAP=" + chgdloncap + " DRLOANINT="+chngdlonint+"";
                    //dm.insertRecords(dthrefupdt);
                    string dthlonchnginsert = "insert into LPHS.DTHLOANCHNG (LCPOL, LCDATE, LCEPF, LCCAP, LCINT, LCCHGCAP, LCCHGINT) values ("+polno+", "+setDate()[0]+",'"+EPF+"',"+loancap+", "+loanint+", "+chgdloncap+", "+chngdlonint+")";
                    dm.insertRecords(dthlonchnginsert);
                }
                #endregion

                #region ------ getting details of the page ----
                minutes = this.txtminutes.Text.Trim();
                string s1 = this.txtadb.Text;
                string s2 = this.txtfpu.Text;
                string s3 = this.txtfe.Text;
                string s4 = this.txtsj.Text;
                
                

                if ((this.txtsumPVL.Text != null) && (!this.txtsumPVL.Text.Equals(""))) { suassOrPVAL = double.Parse(this.txtsumPVL.Text); }
                if ((s1 != null) && (!s1.Equals(""))) { adbPVL = double.Parse(this.txtadb.Text); }
                if ((s2 != null) && (!s2.Equals(""))) { fpuPVL = double.Parse(this.txtfpu.Text); }
                if ((s3 != null) && (!s3.Equals(""))) { fePVL = double.Parse(this.txtfe.Text); }
                if ((s4 != null) && (!s4.Equals(""))) { sjPVL = double.Parse(this.txtsj.Text); }
                ageStatus = this.ddlagediff.SelectedItem.Value;

                if ((this.chkFEpayearly.Enabled) && (this.chkFEpayearly.Checked)) { FEearlyPay = "Y"; }
                else { FEearlyPay = "N"; }

                if ((this.chkADBpaylater.Enabled) && (this.chkADBpaylater.Checked))
                {
                    ADBlatepay = "Y";
                    amtOut = adbPVL;
                }
                else { ADBlatepay = "N"; amtOut = 0; }

                if ((this.txtotheradd.Text != null) && (!this.txtotheradd.Text.Equals(""))) { otheradd = double.Parse(this.txtotheradd.Text); }
                if ((this.txtotherdeduct.Text != null) && (!this.txtotherdeduct.Text.Equals(""))) { otherDeduct = double.Parse(this.txtotherdeduct.Text); }
                if ((this.txtrefofPrems.Text != null) && (!this.txtrefofPrems.Text.Equals(""))) { refOfPrems = double.Parse(this.txtrefofPrems.Text); }
                if ((this.txtvestedbons.Text != null) && (!this.txtvestedbons.Text.Equals(""))) { vestedBonus = double.Parse(this.txtvestedbons.Text); }
                if ((this.txtinterimbons.Text != null) && (!this.txtinterimbons.Text.Equals(""))) { interimBonus = double.Parse(this.txtinterimbons.Text); }

                double adbOnExgracia = 0;
                double fpuOnExgracia = 0;
                double feOnExgracia = 0;
                double sjOnExgracia = 0;
                double sumOnExgracia = 0;
                double refOfPremOnExgracia = 0;
                double otherAddingsOnExgracia = 0;

                if ((this.chkadbOnEx.Enabled) && (this.chkadbOnEx.Checked)) { exgraciaAmt += adbPVL; adbOnExgracia = adbPVL; adbonexgr = "Y"; } else { adbonexgr = "N"; }
                if ((this.chkFeOnExg.Enabled) && (this.chkFeOnExg.Checked)) { exgraciaAmt += fePVL; feOnExgracia = fePVL; }
                if ((this.chkfpuOnExg.Enabled) && (this.chkfpuOnExg.Checked)) { exgraciaAmt += fpuPVL; fpuOnExgracia = fpuPVL; }
                if ((this.chkotheraddOnExg.Enabled) && (this.chkotheraddOnExg.Checked)) { exgraciaAmt += otheradd; otherAddingsOnExgracia = otheradd; }
                if ((this.chkrefpremonExg.Enabled) && (this.chkrefpremonExg.Checked)) { exgraciaAmt += refOfPrems; refOfPremOnExgracia = refOfPrems; }
                if ((this.chkSjonExg.Enabled) && (this.chkSjonExg.Checked)) { exgraciaAmt += sjPVL; sjOnExgracia = sjPVL; }
                if ((this.chksumOnExg.Enabled) && (this.chksumOnExg.Checked)) { exgraciaAmt += suassOrPVAL; sumOnExgracia = suassOrPVAL; }
                if ((this.txtagediffamt.Text != null) && (!this.txtagediffamt.Text.Equals(""))) { amtForAgeDiff = double.Parse(this.txtagediffamt.Text); }
                if ((this.txtagediffamtInt.Text != null) && (!this.txtagediffamtInt.Text.Equals(""))) { amtForAgeDiffInt = double.Parse(this.txtagediffamtInt.Text); }//Add by buddhika 2009/04/07..

                string polcomyn;
                if (chkPolcomyr.Checked) { polcomyn = "Y"; } else { polcomyn = "N"; }
                if (!chkStage1.Enabled || !chkStage1.Checked) 
                {
                    stgpmnt1 = 0;
                    //suassOrPVAL -= stgpmnt; 
                    //otherDeduct += stgpmnt; 
                } //else { stgpmnt = 0; }
                if (!chkStage2.Enabled || !chkStage2.Checked) 
                {
                    stgpmnt2 = 0;
                    //suassOrPVAL -= stgpmnt2; 
                    //otherDeduct += stgpmnt2; 
                } //else { stgpmnt2 = 0; }
                if (!ChkStage3.Enabled || !ChkStage3.Checked)
                {
                    stgpmnt3 = 0;
                }

                ViewState["adbonexgr"] = adbonexgr;
                #endregion

                if (txtRefofdep.Text.Trim() == "")
                    deposit = 0.0;
                else
                    deposit = Convert.ToDouble(txtRefofdep.Text.Trim());
                #region --------DEPOSITE_TEMP------Editted by Dushan--------
                //This codes were added for the purpose of Keeping holded deposit data when reversing.

                 string deptempSelect = "SELECT * FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO=" + Polno + " AND DPMOS='" + MOF + "'";
                if (!(this.chkRefdep.Checked))
                {
                    deposit = 0;
                    if (dthpayObj.existRecored(deptempSelect) == 0)
                    {
                        string deptempUpdate = "INSERT INTO LPHS.DEPOSITE_TEMP (DPPOLNO, DPMOS, DPCLMNO, DPDEPAMT, DPENTEPF)" +
                            "VALUES (" + Polno + ",'" + MOF + "','" + claimno + "'," + DDEP + ",'" + EPF + "')";
                        dm.insertRecords(deptempUpdate);
                    }
                }
                else if (dthpayObj.existRecored(deptempSelect)!=0)
                {
                    string deptempDelete = "DELETE FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO="+Polno+" AND DPMOS='"+MOF+"'";
                    dm.insertRecords(deptempDelete);
                }

                #endregion

                #region ----------- dthref ------------------

                // deposit is 0 when record is writing on DEPOSITE_TEMP

                #region Task 34965
                //Task 34965 =================================
                if (STA.Equals("L")) //if lapse select the duductable stage
                {
                    if(stgpmnt1 != 0 && deductStage1.Checked)
                    {
                        stgpmnt = stgpmnt + stgpmnt1;
                    }
                    if (stgpmnt2 != 0 && deductStage2.Checked)
                    {
                        stgpmnt = stgpmnt + stgpmnt2;
                    }
                    if (stgpmnt3 != 0 && deductStage3.Checked)
                    {
                        stgpmnt = stgpmnt + stgpmnt3;
                    }
                }
                else
                {
                    stgpmnt = stgpmnt1 + stgpmnt2 + stgpmnt3;
                }


                //================================================
                #endregion

                // for updating the Deposit details after intimation.
                // modified by Amal @ 2012-01-06
                // Sql for updating Deposit Amount

                string  sqlUpdate= " UPDATE LPHS.DTHREF SET   DRDEPOSITS = "+
                    " (select NVL(sum(DPTAM),0) from lpay.deposit where DPPOL=" + polno + " and dpdel <> 1 and DPTAM>0 ) "+
                    " WHERE drpolno=" + polno + " and drmos='" + MOF + "' ";
                     dm.insertRecords(sqlUpdate);  

                    //


                string dthrefSelect = "select * from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";

                if (dthpayObj.existRecored(dthrefSelect) != 0)
                {
                    string dthrefUpdate = "UPDATE LPHS.DTHREF SET DRAGEADMIT='" + ageStatus + "',DROTHERADITNS = " + otheradd + ",  DRDEPOSITS = " + deposit + ", DEOTHERDEDUCT = " + otherDeduct + ", ADBPAYAMT = " + adbPVL + " , ";
                    dthrefUpdate += "SJPAYAMT = " + sjPVL + " , FPUPAYAMT = " + fpuPVL + " , FEPAYAMT = " + fePVL + " ,";
                    dthrefUpdate += " SMASS_PVAL = " + suassOrPVAL + ", THR_STG_PMNT = " + stgpmnt + ", REFUND_OF_PREMS=" + refOfPrems + ", AMTOUT = " + amtOut + ", FE_EARLYPAY ='" + FEearlyPay + "', " +
                    " ADB_LATEPAY = '" + ADBlatepay + "', EXGRACIA_AMOUNT = " + exgraciaAmt + ", AGE_STATUS = '" + ageStatus + "', AGE_AMT = " + amtForAgeDiff + ", " +
                    " DRVESTEDBON = " + vestedBonus + ", DRINTERIMBON = " + interimBonus + ", MINUTES = '" + minutes + "', POL_COMPL_YN='" + polcomyn + "',AGEDIFINRST=" + amtForAgeDiffInt + ", MEMO_CREATED_DATE=" + this.setDate()[0] + ", MEMO_CREATED_EPF='"+EPF+"'" +
                    " WHERE drpolno=" + polno + " and drmos='" + MOF + "' ";
                    
                    dm.insertRecords(dthrefUpdate);
                }
                else
                {
                    //dthpayObj.connclose();                    
                    throw new Exception("No Death Reference Details!");
                }

                #endregion

                #region ------- exgracia ---------
                if ((adbOnExgracia > 0) || (feOnExgracia > 0) || (fpuOnExgracia > 0) || (otherAddingsOnExgracia > 0) || (refOfPremOnExgracia > 0) || (sjOnExgracia > 0) || (sumOnExgracia > 0))
                {

                    string exgraciaSelect = "select dpolnum from lphs.exgracia_amts where dpolnum = " + polno + " and mof ='" + MOS + "' ";
                    if (dthpayObj.existRecored(exgraciaSelect) != 0)
                    {
                        string exgraciaUpdate = "UPDATE LPHS.EXGRACIA_AMTS SET SUMONEX = " + sumOnExgracia + " , ADBONEX = " + adbOnExgracia + " , FPUONEX = " + fpuOnExgracia + " , FEONEX = " + feOnExgracia + " , " +
                            " SJONEX = " + sjOnExgracia + " , OTHERADDONEX = " + otherAddingsOnExgracia + " , REFOFPRMONEX = " + refOfPremOnExgracia + " WHERE DPOLNUM = " + polno + " and MOF = '" + MOS + "' ";
                        dm.insertRecords(exgraciaUpdate);
                    }
                    else
                    {
                        string exgraciaInsert = "INSERT INTO LPHS.EXGRACIA_AMTS (DPOLNUM ,MOF ,SUMONEX ,ADBONEX ,FPUONEX ,FEONEX ,SJONEX ,OTHERADDONEX ,REFOFPRMONEX )" +
                            " VALUES (" + polno + " ,'" + MOS + "' ," + sumOnExgracia + " ," + adbOnExgracia + " ," + fpuOnExgracia + " ," + feOnExgracia + " ," + sjOnExgracia + " ," + otherAddingsOnExgracia + " ," + refOfPremOnExgracia + "  )";
                        dm.insertRecords(exgraciaInsert);
                    }
                }
                #endregion

                #region Save manual entry data
                DateTime dt = new DateTime();
                dt = System.DateTime.Now;
                string curTime = dt.ToString("yyyy-MM-dd HH:mm tt"); 
                if (ViewState["SJGen"] != null)
                {
                    SJSysGenerat = double.Parse(ViewState["SJGen"].ToString());
                }

                string epf = "";
                if (Session["EPFNum"] != null)
                {
                    epf = Session["EPFNum"].ToString();
                }
                string ip = GetEntryIP();

                string insertManualVal = "insert into LCLM.MANUAL_CHANG_VAL (ENTRY_DATE, POLNO, APP_TYPE, CAL_PRESENTVAL, MNL_PRESENTVAL, ENTRY_EPF, ENTRY_IP,Intimation_no) values( sysdate , " + polno + ", 'DES'  , '" + SJSysGenerat + "', '" + sjPVL + "', '" + epf + "', '" + ip + "' ,'" + 0 + "' )";
                dm.insertRecords(insertManualVal);

                #endregion

                


                this.lblsuccess.Visible = true;
                this.lblsuccess.Text = "Record Updated Successfully";
                this.btnSubmit.Enabled = true;
                this.btnok.Enabled = false;

                //dthpayObj.commit();
                dm.commit();
                dm.connClose();
                dthpayObj.connclose();
            }
            catch (Exception ex)
            {
                //dthpayObj.rollback();
                dm.rollback();
                dm.connClose();
                dthpayObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else { Response.Redirect("repudiation001.aspx"); }       

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {        
        try
        {
            dthpayObj = new DataManager();
            dm = new DataManager();
            dm.begintransaction();
            int x = 0;

            //if (this.chkadbOnEx.Enabled && this.chkadbOnEx.Checked) { adbonexgr = "Y"; } else { adbonexgr = "N"; }
          
            int demandCount = 0;
            double totdefint1 = defint;             
            string rcptno = "";
            double totdefint = 0;
            double interest;
            double totint;
            int graceperiod;

            #region........Sundry Receipt Payment Check.....
            if (txtagediffamt.Text.Trim() != "")
            {
                double SunAmount = 0.0;
                string getSundry = "SELECT SDIFFPR FROM LCLM.SUNDRY_RCPT WHERE SCLMNO ='" + claimno + "' AND SPOLNO=" + polno + " AND DELCOD = 0 AND SYSCODE = 'D'";
                dthpayObj.readSql(getSundry);
                OracleDataReader reader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    SunAmount = reader.GetDouble(0);
                }
                if (Convert.ToDouble(txtagediffamt.Text.Trim()) != SunAmount)
                {
                    //Task 36978
                    this.SundryPayment();
                    //throw new Exception("Please do the Sundry Payment to Continue Death Claim...");
                }

            }
            #endregion

            #region //****** Demmands ********

            //if (!((MOS.Equals("2") || MOS.Equals("C")) && ((TBL == 39 && (ageofsecondlife < 15 || inforceDuration < 5)) || (TBL == 38 && (ageofsecondlife < 15 || inforceDuration < 5)) || (TBL == 49 && (ageofsecondlife < 15 || inforceDuration < 5)) || TBL == 34 || TBL == 40 || TBL == 46)))
            //if (!((MOS.Equals("2") || MOS.Equals("C")) && ((TBL == 39 && (fullageofSecond <= 14 || inforceDuration < 5)) || (TBL == 38 && (fullageofSecond <= 14 || inforceDuration < 5)) || (TBL == 49 && (fullageofSecond <= 14 || inforceDuration < 5)) || TBL == 34 || TBL == 40 || TBL == 46 || TBL == 56))) ////15477
            if (!((MOS.Equals("C")) && ((TBL == 39 && (fullageofSecond <= 14 || inforceDuration < 5)) || (TBL == 38 && (fullageofSecond <= 14 || inforceDuration < 5)) || (TBL == 49 && (fullageofSecond <= 14 || inforceDuration < 5)) || TBL == 34 || TBL == 40 || TBL == 46 || TBL == 56)))//41925- Remove the "MOS.Equals("2")"
            {
                    //if (MOS.Equals("2") && (TBL == 39 || TBL == 38 || TBL == 49) && ((ageofsecondlife < 15) || (inforceDuration < 5)))
                    //{
                    if (!memoApprv.Equals("Y") && STA.Equals("I"))
                    {
                        int duration = 0;
                        double intcatch;
                        double totalintfac = 0;
                        double interestrate;
                        double dempremtemp = 0;
                        totint = totdefint;
                        //int rcptno1 = 0;
                        if (MOD == 4) { graceperiod = 15; }
                        else { graceperiod = 30; }

                        if (TBL == 42) { interestrate = 0.15; }
                        else { interestrate = 0.12; }

                    #region----------------Receipt No--------------------------

                    //..................Cange on 2008/08/21 by buddhika Write to LPYMAS to Generate receipt No.
                    //int newsurryear = int.Parse(setDate()[0].Substring(0, 4));
                    //string rcptnoquery = "SELECT RCNO FROM  LPAY.RCPTNO WHERE (RCBRNO = " + brcode + ") AND (RCYEAR = " + newsurryear + ") AND (RCTYPE = 11)";
                    //dthpayObj.readSql(rcptnoquery);
                    //OracleDataReader rcptReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //if (rcptReader.Read())
                    //{
                    //    rcptno1 = rcptReader.GetInt32(0);
                    //    rcptReader.Close();
                    //    rcptReader.Dispose();
                    //}
                    //else
                    //{
                    //    rcptno1 = 1;
                    //}
                    #endregion
                    int recid = 1;
                        foreach (string demdt in arr01)
                        {
                            if (x == 0)
                            {
                                dempremtemp = double.Parse(arr02[0].ToString());
                            }
                            x++;

                            int demanddate = int.Parse(demdt);
                            //newly added 24/04/2009--------Dushan
                            duration = Duration(demanddate, int.Parse(dateofdeath.ToString().Substring(0, 6)));
                            //-----------------------------
                            double demprem = double.Parse(arr02[x - 1].ToString());
                            //newly added 24/04/2009--------
                            if (duration == 0)
                            {
                                if (this.dateComparison(int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)), dateofdeath)[2] <= graceperiod) { duration = 0; }
                                //else { duration = Duration(demanddate, int.Parse(dateofdeath.ToString().Substring(0, 6))); }
                                else { duration = 1; }
                            }
                            else if (duration == 1)
                            {
                                if (this.dateComparison(int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)), dateofdeath)[2] <= graceperiod && this.dateComparison(int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)), dateofdeath)[1]==0) 
                                { duration = 0; }
                                //else { duration = Duration(demanddate, int.Parse(dateofdeath.ToString().Substring(0, 6))); }
                                else { duration = 1; }
                            }
                            //-------------------------------Dushan
                            //commented 24/04/2009
                            //if (this.dateComparison(int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)), dateofdeath)[2] <= graceperiod) { duration = 0; }
                            //else { duration = Duration(demanddate, int.Parse(dateofdeath.ToString().Substring(0, 6))); }
                            //-------------------------------Dushan
                            string chkname = "chk" + x.ToString();
                            CheckBox chkbox = new CheckBox();
                            chkbox = (CheckBox)Table1.FindControl(chkname);
                            if ((chkbox != null) && (!chkbox.Checked) && TBL != 45 && TBL != 42)//&& TBL != 42 Removed 21/04/2009
                            {
                                intcatch = interestCal(duration, interestrate);
                                interest = Math.Round(intcatch, 3);

                                if (dempremtemp == demprem)
                                {
                                    totalintfac += interest;
                                }
                                else
                                {
                                    totint += totalintfac * dempremtemp;
                                    totalintfac = 0;
                                    //totalMonths = duration;
                                    dempremtemp = demprem;
                                }


                                int demanddateymd = int.Parse(demdt.ToString() + COM.ToString().Substring(6, 2));
                                int datediffvbl = this.dateComparison(demanddateymd, dateofdeath)[2];
                                int monthdiffvbl = this.dateComparison(demanddateymd, dateofdeath)[1];
                                int yeardiffvbl = this.dateComparison(demanddateymd, dateofdeath)[0];


                                demandCount++;
                                demmands += demprem;


                                int www = this.dateComparison(int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2)), dateofdeath)[1];
                                double tempPREM = demprem;

                              
                                //--------- Generating Reciept No. ----------------
                                //int adjCode = 40;
                                // possibility of if condition !!!!!!!!!!!!!!!!!!???????????
                                #region.....Deposit Settlement Code Add 2009/03/13....

                                if (txtRefofdep.Text.Trim() == "")
                                    deposit = 0.0;
                                else
                                    deposit = Convert.ToDouble(txtRefofdep.Text.Trim());

                                
                                //if (deposit != 0.0)
                                //{
                                //    General obj = new General();

                                //    string IPAddress = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();

                                //    int epf = Convert.ToInt32(EPF);

                                //    int status = obj.Write_Deposit_Adjestment(brcode,Convert.ToInt32(polno), IPAddress, epf, dm);
                                //    if (status != 0)
                                //        throw new Exception("Deposit Adjustment not Complete.");
                                //}
                                #endregion

                                //--------- LPHS.DEMMAND Update -------------------
                                string PDCOD = ""; int PDPDT = 0;
                                string demSel = "select PDCOD, PDPDT from LPHS.DEMAND where PDPOL = " + polno + " and PDDUE = " + demanddate + " ";
                                if (dthpayObj.existRecored(demSel) != 0)
                                {
                                    dthpayObj.readSql(demSel);
                                    OracleDataReader demselReader = dthpayObj.oraComm.ExecuteReader();
                                    demselReader.Read();
                                    if (!demselReader.IsDBNull(0)) { PDCOD = demselReader.GetString(0); } else { PDCOD = ""; }
                                    if (!demselReader.IsDBNull(1)) { PDPDT = demselReader.GetInt32(1); } else { PDPDT = 0; }
                                    //demselReader.Close();
                                    //demselReader.Dispose();

                                    string demUpd = "UPDATE LPHS.DEMAND SET PDCOD = 'D' , PDPDT = " + int.Parse(this.setDate()[0]) + " WHERE PDPOL = " + polno + " and PDDUE = " + demanddate + " AND (PDCOD = '1' OR PDCOD = '2' OR PDCOD = '3')";
                                    dm.insertRecords(demUpd);

                                    string ddemSel = "select dpdpol from LPHS.DDEMAND where  DPDPOL = " + polno + " and DPDDUE = " + demanddate + " ";
                                    if (dthpayObj.existRecored(ddemSel) != 0)
                                    {
                                        string ddemUpd = "UPDATE LPHS.DDEMAND SET SETTLMNT_TYPE = 'D', DPCOD = '" + PDCOD + "', DPPDT = " + PDPDT + " where DPDPOL = " + polno + " and DPDDUE = " + demanddate + " ";
                                        dm.insertRecords(ddemUpd);
                                    }
                                    else
                                    {
                                        //dthpayObj.connclose();
                                        string dthoutsel = "select * from LPHS.DTHOUT where POLNO="+polno+" and DTHPRO='Y'";
                                        if (dthpayObj.existRecored(dthoutsel) != 0)
                                        {
                                            string ddemandInsert = "INSERT INTO LPHS.DDEMAND (DPDPOL ,DPDDUE, INSERT_TYPE, ENTEPF, ENTDATE, SETTLMNT_TYPE, DPCOD, DPPDT) VALUES ( " + polno + " , " + demanddate + ", 'OLD', '" + EPF + "', " + int.Parse(this.setDate()[0]) + ", 'D', '" + PDCOD + "', " + PDPDT + ")";
                                            dm.insertRecords(ddemandInsert);
                                        }
                                        else
                                        {
                                            throw new Exception("Please Complete the Processing Stage so that the Demands Could be Handled");
                                        }
                                    }
                                }                         



                                //rcptno1++;
                                ////rcptReader.Close();
                                ////rcptReader.Dispose();

                                //if (dthpayObj.existRecored(rcptnoquery) == 0)
                                //{
                                //    string inertRcptnoquery = "insert into LPAY.RCPTNO (RCBRNO, RCYEAR, RCTYPE, RCNO) values(" + brcode + "," + newsurryear + ",11," + rcptno1 + " )";
                                //    dm.insertRecords(inertRcptnoquery);
                                //}
                                //else
                                //{
                                //    string updRcptnoquery = "update LPAY.RCPTNO set RCNO=" + rcptno1 + " where RCBRNO=" + brcode + " and RCYEAR=" + newsurryear + "  and RCTYPE= 11 ";
                                //    dm.insertRecords(updRcptnoquery);
                                //}

                                #region--------------------------Writing on Payment Files----------------------
                                //...LPAY.LPAYCOM....
                                string lpaycomInsert = "INSERT INTO LPAY.LPAYCOM_DTH (claimno,LCPBR ,LCPDT ,LCBTP ,LCPOL ,LCDUE ,LCTBL ,LCTRM ,LCMOD ,LCPRM ,LCCDT ,LCCOD ,LCPAC ,LCAGT ,LCORG ,LCSBR , LCREC, LCLATEFEE,rec_id )";
                                lpaycomInsert += " VALUES ('"+ claimno + "'," + brcode + " ," + int.Parse(this.setDate()[0]) + " ,'11' ," + polno + " ," + demanddate + " ," + TBL + " ," + TRM + " ," + MOD + " ," + demprem + "";
                                lpaycomInsert += " ," + COM + " ,'8' ," + PAC + " ," + AGT + " ," + ORG + " ," + brcode + " ,'0' , " + (demprem * interest) + "," + recid + " )";//..Change on 20090518 Daet of Commence error on Commision reu of udeepa --int.Parse(this.setDate()[0])
                                dm.insertRecords(lpaycomInsert);

                                //.....LCLM.LEDGER.....
                                string ledgerInsert = "insert into lclm.ledger_dth (claimno,LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT, LLPBR, LLREC,rec_id) " +
                                                " VALUES ('" + claimno + "'," + polno + ", " + demanddate + ", 1, 8, " + demprem + ", " + MOD + ", " + int.Parse(this.setDate()[0]) + ", " + brcode + ", '0' ,"+recid+" ) ";
                                dm.insertRecords(ledgerInsert);

                                //.........LPAY.LPAYMAS.......
                                double am1 = (demprem * interest) + demprem;
                                string lpaymasInsertSQL = "insert into lpay.lpaymas_dth (claimno,lpbrn, lpptd, lpbtp, lprec, lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, lpedt, lptim, lpipa, lpacd, lpopr, lpcur, lpcrt,rec_id) values('" + claimno + "'," + brcode
                                                                        + ", " + int.Parse(setDate()[0]) + ", 11, 0, " + Convert.ToInt32(ViewState["claimno"]) + ", " + polno + ", '3', '5', " + am1 + ",  "+demprem+" , " + (demprem*interest) + ", " + brcode
                                                                        + ", " + int.Parse(setDate()[0]) + ", '" + DateTime.Now.ToLongTimeString() + "',  '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', 2235, " + dm.EpfCode(EPF) + ", 'LKR', 1 ,"+recid+")";
                                dm.insertRecords(lpaymasInsertSQL);
                            #endregion
                            recid = recid + 1;
                            }
                            //checkbox not checked check end
                        }
                        totint += totalintfac * dempremtemp;

                        #region-----------------Delete Demands--------Editted by Dushan--------------------------
                        int deathym = int.Parse(dateofdeath.ToString().Substring(0, 6));
                        string selectdem = "select pddue from lphs.demand where pdpol='" + polno + "' and (pdcod='1' or pdcod='2' or pdcod='3')";
                        if (dthpayObj.existRecored(selectdem) != 0)
                        {
                            dthpayObj.readSql(selectdem);
                            OracleDataReader selectdemReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (selectdemReader.Read())
                            {
                                int newdem;
                                if (!selectdemReader.IsDBNull(0)) { newdem = selectdemReader.GetInt32(0); } else { newdem = deathym; }
                                int demdate = int.Parse(newdem.ToString() + COM.ToString().Substring(6, 2));
                                if (dateofdeath <= demdate)
                                {
                                    string demanddelinsert = "insert into lphs.demand_del(PDCOD, PDPOL, PDDUE, PDPRM, PDPAC, PDTAB, PDTER, PDPDT, STATUS, DELCODE)(select PDCOD, PDPOL, PDDUE, PDPRM, PDPAC, PDTAB, PDTER, PDPDT, STATUS, 'D' from lphs.demand where pdpol='" + polno + "' and pddue =" + newdem + " and (pdcod='1' or pdcod='2' or pdcod='3'))";
                                    dm.insertRecords(demanddelinsert);
                                    string demanddelete = "delete from lphs.demand where pdpol='" + polno + "' and pddue =" + newdem + " and (pdcod='1' or pdcod='2' or pdcod='3')";
                                    dm.insertRecords(demanddelete);
                                }
                            }
                            //selectdemReader.Close();
                            //selectdemReader.Dispose();
                        }
                        #endregion

                        totdefint = defint;
                        if (totdefint == 0)
                            totdefint = totint;

                        if (demmands > 0)//death ref table update with the missing total premium and interest for them.
                        {
                            string dthrefSelect = "select * from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                            if (dthpayObj.existRecored(dthrefSelect) != 0)
                            {
                                string dthrefupdate = " update lphs.dthref set DRDEFPREM =" + demmands + " ,DRINT =" + totdefint + " where drpolno=" + polno + " and drmos='" + MOF + "' ";
                                dm.insertRecords(dthrefupdate);
                            }
                            else
                            {
                                //dthpayObj.connclose();
                                throw new Exception("Default Premium Settlement Failed!");
                            }
                        }

                    

                    }
                //}
            }   

           
            #endregion            

            #region payMemoRemind
            string updateActionDCT = "UPDATE LPHS.DCT_ACTION " +
                                          "  SET    " +

                                             "      PAYMEMOCOMPLETE  = 1,PAYMEMOCOMDT=sysdate,PAYMEMOCOMUSR='" + EPF + "' " +
                                         "   WHERE  POLICYNO     = " + Polno + " AND LIFETYPE=decode('" + MOF + "','M',1,'S',2,'2',3,'C',4)  AND PAYMEMOEPF IS NOT NULL ";
            dm.insertRecords(updateActionDCT);

            string updateRemindDCT = "UPDATE LPHS.DCT_REMINDERALERT " +
                                          "  SET    " +
                                            "       REMINDSTATUS   = 1 " +

                                         "   WHERE  POLNO=" + Polno + " AND LIFETYPE=decode('" + MOF + "','M',1,'S',2,'2',3,'C',4)  AND PAYMEMORMND=1 ";
            dm.insertRecords(updateRemindDCT);
            #endregion


            //dthpayObj.commit();
            dm.commit();
            dm.connClose();
            dthpayObj.connclose();
        }
        catch (Exception ex) 
        {
            //dthpayObj.rollback();
            dm.rollback();
            dm.connClose();
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
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

    public int premcount(int start, int end, int mode, long polno)
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
            premcount = totmonthdiff;
            //premcount = totmonthdiff + 1;
            //if (datediff > 15) { premcount++; }
        }
        else { }

        premcount -= this.demmandcount(polno, int.Parse(end.ToString().Substring(0,6)));

        return premcount;
    }

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
   
    public int demmandcount(long polno, int dtOfDthYm)
    {
        int demanddate = 0;
        int demandcount = 0;
        
        string mydemandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' and ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= " + dtOfDthYm + "  ";
        dthpayObj.readSql(mydemandsql);
        OracleDataReader mydemandreader = dthpayObj.oraComm.ExecuteReader();

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
       
        return demandcount;       
    }

    private void createDemmandTable(string due, int rowNumber, string payst, string polst)
    {
        try 
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            CheckBox chk01 = new CheckBox();

            lbl1.ID = "due" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "due" + rowNumber); //Text Value
            if (rowNumber == 0) { lbl1.Text = "Due"; }
            else { lbl1.Text = due; }

            lbl2.ID = "LoanNumber" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "due" + rowNumber); //Text Value
            lbl2.Text = "Wave Demmands?";

            chk01.ID = "chk" + rowNumber;
            chk01.Attributes.Add("runat", "Server");
            chk01.Attributes.Add("Name", "chk" + rowNumber); //Text Value         
            if (payst.Equals("Y") || polst.Equals("L")) { chk01.Enabled = false; }
            else { chk01.Enabled = true; }

            tcell1.Controls.Add(lbl1);
            if (rowNumber == 0) { tcell2.Controls.Add(lbl2);  }
            else { tcell2.Controls.Add(chk01); }
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            Table1.Rows.Add(trow);
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    private int maxReturn(int outerx, ArrayList arrList) {
        int incr = 0;
        foreach (string sInner in arrList)
        {
            int inner = int.Parse(sInner);
            if (outerx < inner) { outerx = inner; }
            incr++;
        }
        return outerx;
    }

    private int numberSeperator(string epf)
    {
        int x = 0;
        string s = "";
    a: for (int i = 0; i < epf.Length; i++)
        {
            try
            {
                x = int.Parse(epf.Substring(i, 1));
                s += x.ToString();
            }
            catch (Exception ex)
            {
                continue;
            }

        }
        return int.Parse(s);
    }

    //protected string createAdjRcNo(int brn, int year, int adjCode)
    //{
    //    string rcptnoStr = "";
    //    int recieptNo = 0;

    //    string adjnoSelect = "select adrcno from lphs.adjno where adbrno=" + brn + " and adyear=" + year + " and adtype = " + adjCode + " ";
    //    if (dthpayObj.existRecored(adjnoSelect) == 0)
    //    {
    //        string adjnoInsert = "INSERT INTO LPHS.ADJNO (ADBRNO ,ADYEAR ,ADTYPE ,ADRCNO ) VALUES (" + brn + " ," + year + " ," + adjCode + " ,1  )";
    //        dm.insertRecords(adjnoInsert);
    //        recieptNo++;
    //    }
    //    else
    //    {
    //        dthpayObj.readSql(adjnoSelect);
    //        OracleDataReader adjnoReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //        while (adjnoReader.Read())
    //        {
    //            recieptNo = adjnoReader.GetInt32(0);
    //            recieptNo++;
    //        }
    //        adjnoReader.Close();
    //        adjnoReader.Dispose();
    //        string adjnoUpdate = "update lphs.adjno set ADRCNO=" + recieptNo + " where adbrno=" + brn + " and adyear=" + year + " and adtype = " + adjCode + " ";
    //        dm.insertRecords(adjnoUpdate);
    //    }

    //    rcptnoStr = adjCode.ToString() + zeroFill(recieptNo, 7);

    //    return rcptnoStr;
    //}

    //protected string zeroFill(int num, int length)
    //{
    //    int numLength = int.Parse((num.ToString().Length).ToString());
    //    string formattedNum = num.ToString();
    //    for (int i = 0; i < (length - numLength); i++)
    //    {
    //        formattedNum = "0" + formattedNum;

    //    }
    //    return formattedNum;
    //}

    public double interestCal(int months, double rate)
    {
        double capital = 1;
        double interest=0;
        string intsel;
        int remainder;
        int years;

        intsel = "DFPRATE" + Convert.ToString(rate * 100);
        string selectdefpremrate = "select "+ intsel +" from LCLM.DEFPREMRATE where DFPMONTH=" + months + "";
        if (dthpayObj.existRecored(selectdefpremrate) != 0)
        {
            dthpayObj.readSql(selectdefpremrate);
            OracleDataReader defpremread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            defpremread.Read();
            if (!defpremread.IsDBNull(0)) { interest = defpremread.GetDouble(0); } else { interest = 0; }
            defpremread.Close();
            defpremread.Dispose();
        }
        if (interest==0)
        {
            //months = int.Parse(txtMonths.Text);
            years = months / 12;
            for (int i = 0; i < years; i++)
            {
                interest = capital * rate;
                capital += interest;
            }
            remainder = months % 12;
            interest = capital * (rate/12) * remainder;
            capital += interest;
            capital = Math.Round(capital, 4);
            interest = capital - 1;
        }
        return interest;
    }

    public string GetEntryIP()
    {
        string IP = null;
        System.Net.IPHostEntry _IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

        foreach (System.Net.IPAddress _IPAddress in _IPHostEntry.AddressList)
        {
            if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
            {
                IP = _IPAddress.ToString();
            }
        }
        return IP;
    }

    public int WaivedPremCount(int start, int end, int mode)
    {
        //?? using premcount(int start, int end, int mode, long polno)  & dateComparison(start, end)
        int yeardiff = 0;
        int monthdiff = 0;
        int datediff = 0;
        int premcount = 0;
        yeardiff = dateComparison(start, end)[0];
        monthdiff = dateComparison(start, end)[1];
        datediff = dateComparison(start, end)[2];

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
            premcount = totmonthdiff;
            //premcount = totmonthdiff + 1;
            //if (datediff > 15) { premcount++; }
        }
        else { }

        //premcount -= this.demmandcount(polno, int.Parse(end.ToString().Substring(0, 6)));

        return premcount;
    }
    //protected void txtSJPaidAmt_TextChanged(object sender, EventArgs e)
    //{
    //    this.txtsj.Text = (SJ - double.Parse(this.txtSJPaidAmt.Text)).ToString();
    //}
    protected void linkSJPaid_Click(object sender, EventArgs e)
    {
        string voucherType = "Swarna Jayanthi";
        string URL1 = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
        string URL = "<script type='text/javascript'>window.open('" + URL1 + "/Beegeneral/Payment/DefaultUI_Payemt_Type.aspx?policyType=" + voucherType + "&policyNo=" + polno + "','_blank');</script>";
        Response.Write(URL); 
    }


    public void SundryPayment()
    {
        pol = int.Parse(Polno.ToString());

        

        polMasRead policyread = new polMasRead(pol, dm);

        #region Get Claim Details
        string seldthref = "select DRCLMNO,DRAGEADMIT,AGE_AMT,AGEDIFINRST from lphs.dthref where DRPOLNO=" + Polno + " and DRMOS='" + MOS + "'";
        if (dm.existRecored(seldthref) != 0)
        {
            dm.readSql(seldthref);
            OracleDataReader red = dm.oraComm.ExecuteReader();
            while (red.Read())
            {
                if (!red.IsDBNull(0)) { Clmno = red.GetInt32(0); } else { Clmno = 0; }
                if (!red.IsDBNull(2)) { ageamt = red.GetDouble(2); } else { ageamt = 0.0; }
                if (!red.IsDBNull(2)) { AgeDiffInt = red.GetDouble(3); } else { AgeDiffInt = 0.0; }
            }
            red.Close();

        }
        #endregion

        #region Get Policy Details
        commdate = policyread.COM;
        tble = policyread.TBL;
        term = policyread.TRM;
        pacode = policyread.PAC;
        agt = policyread.AGT;
        org = policyread.ORG;
        serbr = policyread.OBR;
        prm = policyread.PRM;
        mode = policyread.MOD;

        #endregion


        //#region checkprmst
        //selqry = "select * from lphs.premast where pmpol=" + Polno + "";
        //if (dm.existRecored(selqry) != 0)
        //{
        //    polst = "Inforce";
        //}
        //else
        //{
        //    string statusofpol = "";
        //    string selstatusqry = "select PHSTA from lphs.lpolhis where phpol=" + Polno + "";
        //    dm.readSql(selstatusqry);
        //    OracleDataReader drred = dm.oraComm.ExecuteReader();
        //    while (drred.Read())
        //    {
        //        if (!drred.IsDBNull(0)) { statusofpol = drred.GetString(0); } else { statusofpol = ""; }

        //    }
        //    drred.Close();
        //    if (statusofpol == "I")
        //    {
        //        polst = "Inforce";
        //    }
        //    else
        //    {
        //        polst = "Lapse";
        //    }
        //}
        //#endregion


        #region Read phname

        selqry = "select PNSTA|| ' ' ||PNINT|| ' ' ||PNSUR from lphs.phname where pnpol=" + Polno + "";
        if (dm.existRecored(selqry) != 0)
        {
            #region Get Data From PHNAME
            dm.readSql(selqry);
            OracleDataReader read = dm.oraComm.ExecuteReader();
            while (read.Read())
            {
                if (!read.IsDBNull(0)) { name = read.GetString(0).Trim(); }
            }
            read.Close();
            #endregion
        }
        #endregion

        #region Get Death Date
        string getdthdt = "select DDTOFDTH from lphs.dthint where DPOLNO=" + Polno + " and DMOS='" + MOS + "'";
        if (dm.existRecored(getdthdt) != 0)
        {
            dm.readSql(getdthdt);
            OracleDataReader red1 = dm.oraComm.ExecuteReader();
            while (red1.Read())
            {
                if (!red1.IsDBNull(0)) { dthdate = red1.GetInt32(0); } else { dthdate = 0; }
            }
            red1.Close();
        }
        #endregion


        string getLegerMax = "select  max(LLDUE) from LCLM.LEDGER where LLPOL=" + Polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldat<=" + dthdate + "";
        if (dm.existRecored(getLegerMax) != 0)
        {
            dm.readSql(getLegerMax);
            OracleDataReader red1 = dm.oraComm.ExecuteReader();
            while (red1.Read())
            {
                if (!red1.IsDBNull(0)) { maxLedgerDue = red1.GetInt32(0); } else { maxLedgerDue = 0; }
            }
            red1.Close();
        }

        if (maxLedgerDue > 0)
        {
            int x;
            switch (mode)
            {
                case 1: x = 12; break;
                case 2: x = 6; break;
                case 3: x = 3; break;
                default: x = 1; break;
            }
            General gg = new General();
            maxPaidDate = int.Parse(maxLedgerDue + commdate.ToString().Substring(6, 2));
            maxPaidDate = gg.DateAdjust(maxPaidDate, 0, x, 0);
        }

        paiddue = this.dateComparison(commdate, maxPaidDate)[0];
        paidduemnth = this.dateComparison(commdate, maxPaidDate)[1];
        paidduedays = this.dateComparison(commdate, maxPaidDate)[2];
        if (paidduemnth > 0)
        {
            pdyrs = paiddue + 1;
        }
        else
        {
            pdyrs = paiddue;
        }

        #region Calculate premium diff
        if (mode == 4)
        {
            totinstlmnts = pdyrs * 12;
            singlprmdiff = (ageamt / totinstlmnts);
            remnprmdiff = singlprmdiff * 11;
        }
        else if (mode == 3)
        {
            totinstlmnts = pdyrs * 4;
            singlprmdiff = (ageamt / totinstlmnts);
            remnprmdiff = singlprmdiff * 3;
        }
        else if (mode == 2)
        {
            totinstlmnts = pdyrs * 2;
            singlprmdiff = (ageamt / totinstlmnts);
            remnprmdiff = singlprmdiff;
        }
        else
        {
            totinstlmnts = pdyrs;
            singlprmdiff = (ageamt / totinstlmnts);
        }
        #endregion


        #region Craete Dues
        dueyr = int.Parse(commdate.ToString().Substring(0, 4));
        duemnth = int.Parse(commdate.ToString().Substring(4, 2));
        if (mode == 4)
        {
            nextduemn = duemnth + 1;
            if (nextduemn > 12)
            {
                nextdueyr = dueyr + 1;
                nextduemn = nextduemn - 12;
            }
            else
            {
                nextdueyr = dueyr;
            }
            nextduelstmn = nextduemn + 10;
            if (nextduelstmn > 12)
            {
                nextduelstyr = nextdueyr + 1;
                nextduelstmn = nextduelstmn - 12;
            }
            else
            {
                nextduelstyr = nextdueyr;
            }
        }
        else if (mode == 3)
        {
            nextduemn = duemnth + 3;
            if (nextduemn > 12)
            {
                nextdueyr = dueyr + 1;
                nextduemn = nextduemn - 12;
            }
            else
            {
                nextdueyr = dueyr;
            }
            //nextduelstmn = nextduelstmn + 8;
            nextduelstmn = nextduemn + 8;
            if (nextduelstmn > 12)
            {
                nextduelstyr = nextdueyr + 1;
                nextduelstmn = nextduelstmn - 12;
            }
            else
            {
                nextduelstyr = nextdueyr;
            }
        }
        else if (mode == 2)
        {
            nextduemn = duemnth + 6;
            if (nextduemn > 12)
            {
                nextdueyr = dueyr + 1;
                nextduemn = nextduemn - 12;
            }
            else
            {
                nextdueyr = dueyr;
            }
            //nextduelstmn = nextduelstmn + 5;
            nextduelstmn = nextduemn + 5;
            if (nextduelstmn > 12)
            {
                nextduelstyr = nextdueyr + 1;
                nextduelstmn = nextduelstmn - 12;
            }
            else
            {
                nextduelstyr = nextdueyr;
            }
        }
        else
        {
            nextduemn = duemnth + 12;
            if (nextduemn > 12)
            {
                nextdueyr = dueyr + 1;
                nextduemn = nextduemn - 12;
            }
            else
            {
                nextdueyr = dueyr;
            }

            nextduelstmn = nextduemn + 12;
            if (nextduelstmn > 12)
            {
                nextduelstyr = nextdueyr + 1;
                nextduelstmn = nextduelstmn - 12;
            }
            else
            {
                nextduelstyr = nextdueyr;
            }
        }

        #endregion


        isfirst = true;
        CreateDynamicTable(isfirst);

        double tot = 0.0;
        double fulltot = 0.0;
        Prms1 = new ArrayList();
        Prms2 = new ArrayList();
        pol = (int)polno;
        //dm = new DataManager();
        int j = 1;
        polMasRead policyread1 = new polMasRead(pol, dm);
        term = policyread1.TRM;
        //for (int i = 1; i <= (paiddue+1); i++)
        for (int i = 1; i < (paiddue + 1); i++)
        //for (int i = 1; i <= (pdyrs + 1); i++)
        {
            //if ((i <= paiddue) && (j % 2 == 1))
            if ((i <= paiddue) && (j % 2 == 1))
            //if ((i <= pdyrs) && (j % 2 == 1))
            {
                TextBox txtname1 = new TextBox();
                txtname1 = (TextBox)Table2.FindControl("txt" + i.ToString());
                if (txtname1.Text != null)
                {
                    Prms1.Add(txtname1.Text);
                    tot = double.Parse(txtname1.Text);
                    fulltot = fulltot + tot;
                }
            }

            //if ((i <= paiddue) && (j % 2 == 0))
            if ((i < paiddue) && (j % 2 == 0))
            {
                TextBox txtname2 = new TextBox();
                txtname2 = (TextBox)Table2.FindControl("txt_" + i.ToString());
                if (txtname2.Text != null)
                {
                    Prms2.Add(txtname2.Text);
                    tot = double.Parse(txtname2.Text);
                    fulltot = fulltot + tot;
                }
            }
            j = i + 1;
        }
        fulltot = fulltot + singlprmdiff + remnprmdiff;
        double diff = 0;
        diff = double.Parse(ageamt.ToString("N2")) - double.Parse(fulltot.ToString("N2"));
        if (diff > 0.0)
        {
            //throw new Exception("Age amount is Greater than Total of Yearly Premium Differences...Rs." + (diff.ToString("N2")) + "");
        }
        else if (diff < 0.0)
        {
            //throw new Exception("Age amount is Less than Total of Yearly Premium Differences...Rs." + (diff.ToString("N2")) + "");
        }

        //////
        string fstdue = "";
        //dm = new DataManager();
        string selsundry = "select * from lclm.sundry_rcpt where SCLMNO='" + Clmno + "' and  SPOLNO=" + Polno + "  and SYSCODE='D' and DELCOD=0";

        if (dm.existRecored(selsundry) == 0)
        {
            #region Set Current Date
            string Currday = "";
            string curmnth = "";
            string Curr_Date = "";
            int Curryear = DateTime.Now.Year;
            int Currmnth = DateTime.Now.Month;
            if (Currmnth < 10)
            { curmnth = "0" + Currmnth.ToString(); }
            else
            { curmnth = Currmnth.ToString(); }
            int Currdate = DateTime.Now.Day;
            if (Currdate < 10)
            { Curr_Date = "0" + Currdate.ToString(); }
            else
            { Curr_Date = Currdate.ToString(); }
            Currday = Curryear.ToString() + curmnth + Curr_Date;
            //litdt.Text = Currday;
            #endregion

            string insert = "";
            int d_today = DateTime.Now.Year;

            string selrcptno = "select * FROM  LPAY.RCPTNO where RCBRNO =" + BRN + " and RCYEAR =" + d_today + " and RCTYPE = 16";
            if (dm.existRecored(selrcptno) != 0)
            {
                dm.readSql(selrcptno);
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) { rcptno = reader.GetInt32(0); } else { rcptno = 0; }
                }
                reader.Close();
                rcptno = rcptno + 1;
                insert = "UPDATE LPAY.RCPTNO set RCNO=" + rcptno + " where RCBRNO=" + BRN + " and RCYEAR=" + d_today + "  and RCTYPE= 16";
                dm.insertRecords(insert);

            }
            else
            {
                rcptno = 1;
                insert = "insert into LPAY.RCPTNO (RCBRNO, RCYEAR, RCTYPE, RCNO) values(" + BRN + "," + d_today + ",16," + rcptno + " )";
                dm.insertRecords(insert);
            }

            
            duemnth = int.Parse(commdate.ToString().Substring(4, 2));
            dueyr = int.Parse(commdate.ToString().Substring(0, 4));

            if (duemnth.ToString().Length != 2)
            {
                fstdue = dueyr.ToString() + "0" + duemnth.ToString();
            }
            else
            {
                fstdue = dueyr.ToString() + duemnth.ToString();
            }
            int lltype = 5;
            int llcode = 8;
            int nextdueyr = dueyr;
            string IP = Request.ServerVariables.Get("REMOTE_ADDR");
            double fstprm = System.Math.Round((singlprmdiff + remnprmdiff), 2);
            #region Write Data to LCLM.LEDGER

            string sql = "select * from lclm.ledger where LLPOL=" + polno + " and LLTYP=5  and lldue=" + int.Parse(fstdue) + "";
            if (dm.existRecored(sql) == 0)
            {
                insert = "insert into lclm.ledger(LLPOL,LLDUE,LLTYP,LLCOD,LLPRM,LLMOD,LLDAT,LLPBR,LLREC) " +
                            " values(" + polno + "," + int.Parse(fstdue) + "," + lltype + "," + llcode + "," + fstprm + "," + mode + "," + int.Parse(Currday) + "," + BRN + ",'" + rcptno + "')";
                dm.insertRecords(insert);
            }
            int l = 0;
            int k = 0;
            //for (int i = 0; i < paiddue; i++)
            for (int i = 0; i < (paiddue - 1); i++)
            //for (int i = 0; i < paiddue; i++)
            {
                nextdueyr = nextdueyr + 1;
                if (duemnth.ToString().Length != 2)
                {
                    fstdue = nextdueyr.ToString() + "0" + duemnth.ToString();
                }
                else
                {
                    fstdue = nextdueyr.ToString() + duemnth.ToString();
                }
                if (i % 2 == 0)
                {
                    fstprm = double.Parse(Prms1[k].ToString());
                    k++;

                }
                if (i % 2 != 0)
                {
                    fstprm = double.Parse(Prms2[l].ToString());
                    l++;
                }
                string sql1 = "select * from lclm.ledger where LLPOL=" + polno + " and LLTYP=5  and lldue=" + int.Parse(fstdue) + "";
                if (dm.existRecored(sql1) == 0)
                {
                    insert = "insert into lclm.ledger(LLPOL,LLDUE,LLTYP,LLCOD,LLPRM,LLMOD,LLDAT,LLPBR,LLREC) " +
                            " values(" + polno + "," + int.Parse(fstdue) + "," + lltype + "," + llcode + "," + fstprm + "," + mode + "," + int.Parse(Currday) + "," + BRN + ",'" + rcptno + "')";
                    dm.insertRecords(insert);
                }
            }
            #endregion


            #region Write Data to SUNDRY_RCPT and SUNDRY_DETAIL
            int due_yr = dueyr;
            selsundry = "select * from lclm.sundry_rcpt where SCLMNO='" + Clmno + "' and  SPOLNO=" + polno + " and RCPTNO=" + rcptno + " and SYSCODE='D'";
            if (dm.existRecored(selsundry) == 0)
            {
                insert = "insert into lclm.sundry_rcpt(SCLMNO,SPOLNO,RCPTNO,SDIFFPR,COMMDATE,TBLE,TERM,PACODE,RCVDNAME,ENTRYEPF,ENTRYIP,ENTRYDATE,PRINT,SYSCODE,ENTRY_BR,DIFFINT)" +
                        "values('" + Clmno + "'," + polno + "," + rcptno + "," + ageamt + "," + commdate + "," + tble + "," + term + "," + pacode + ",'" + name + "','" + EPF + "','" + IP + "',sysdate,1,'D'," + BRN + "," + AgeDiffInt + ")";
                dm.insertRecords(insert);

                for (int h = 0; h <= 1; h++)
                {
                    if (h == 0)
                    {
                        sngleprm = singlprmdiff;
                        string mnthstr = "";
                        mnthstr = duemnth.ToString();
                        if (mnthstr.Length < 2)
                        {
                            mnthstr = "0" + mnthstr;
                        }
                        fstdue = dueyr.ToString() + mnthstr;

                    }
                    if (h == 1)
                    {
                        sngleprm = remnprmdiff;
                        string mnthstr = "";
                        mnthstr = (duemnth + 1).ToString();
                        if (mnthstr.Length < 2)
                        {
                            mnthstr = "0" + mnthstr;
                        }
                        fstdue = dueyr.ToString() + mnthstr;
                    }
                    insert = "insert into lclm.sundry_detail(SCLMNO,SPOLNO,SRECNO,DUEYRMN,PRMAMT) values('" + Clmno + "'," + polno + "," + rcptno + "," + fstdue + "," + sngleprm + ")";
                    dm.insertRecords(insert);
                }
                j = 0;
                k = 0;
                //for (int i = 0; i < paiddue; i++)
                for (int i = 0; i < (paiddue - 1); i++)
                {
                    string StrMnth = "";
                    due_yr = due_yr + 1;
                    StrMnth = duemnth.ToString();
                    if (StrMnth.Length < 2)
                    {
                        StrMnth = "0" + StrMnth;
                    }

                    int fst_due = int.Parse(due_yr.ToString() + StrMnth);
                    if (i % 2 == 0)
                    {
                        fstprm = double.Parse(Prms1[k].ToString());
                        k++;

                    }
                    if (i % 2 != 0)
                    {
                        fstprm = double.Parse(Prms2[j].ToString());
                        j++;
                    }
                    string selsundet = "select * from lclm.sundry_detail where SCLMNO='" + Clmno + "' and SPOLNO=" + polno + " and DUEYRMN=" + fst_due + " ";
                    if (dm.existRecored(selsundet) == 0)
                    {
                        insert = "insert into lclm.sundry_detail(SCLMNO,SPOLNO,SRECNO,DUEYRMN,PRMAMT) values('" + Clmno + "'," + polno + "," + rcptno + "," + fst_due + "," + fstprm + ")";
                        dm.insertRecords(insert);
                    }

                }
            }
            else
            {
                insert = "UPDATE lclm.sundry_rcpt set SDIFFPR=" + ageamt + ",ENTRYEPF='" + EPF + "',ENTRYIP='" + IP + "',ENTRYDATE=sysdate,SYSCODE='D',ENTRY_BR=" + BRN + ",DIFFINT=" + AgeDiffInt + " where SCLMNO='" + Clmno + "' And SPOLNO=" + polno + " And RCPTNO=" + rcptno + "";
                dm.insertRecords(insert);
            }
            #endregion

            #region Write Data into LPAYMAS
            //use code =16 for lpaymas from sundry receipt(Death)
            //LPBTP=16 --- LPACD=2235--LPPTP=3


            string[] ti = DateTime.Now.ToString().Split(' ');
            string currtime = ti[1].ToString() + ti[2].ToString();

            string sellpaymas = "select * FROM  LPAY.LPAYMAS where LPBRN=" + BRN + " and LPBTP=16 and LPPTD=" + int.Parse(Currday) + " and LPREC=" + rcptno + "";
            if (dm.existRecored(sellpaymas) == 0)
            {
                insert = "insert into LPAY.LPAYMAS(LPBRN,LPPTD,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPAM1,LPCA1,LPCA2,LPACD,LPSTA,LPOPR,LPEDT,LPTIM,LPIPA,LPSBR,LPMD1)" +
                        " values(" + BRN + "," + int.Parse(Currday) + ",16," + rcptno + "," + polno + "," + polno + ",3," + ageamt + "," + ageamt + "," + AgeDiffInt + ",2235,0," +
                        " '" + dm.EpfCode(EPF) + "'," + int.Parse(Currday) + ",'" + currtime + "','" + IP + "'," + serbr + ",5) ";
                dm.insertRecords(insert);
            }
            #endregion

            #region Write Sundry Data to LPAYCOM
            //use code =16 for lpaycom from sundry receipt
            fstdue = dueyr.ToString() + duemnth.ToString();
            string LCCOD = "";
            string sellpaycom = "select * FROM  LPAY.LPAYCOM where LCPBR=" + BRN + " and LCBTP=16 and LCPDT=" + int.Parse(Currday) + " and LCREC='" + rcptno + "' and LCDUE=" + int.Parse(fstdue) + "";
            if (dm.existRecored(sellpaycom) == 0)
            {

                int ndueyr = dueyr;
                l = 0;
                int n = 0;
                LCCOD = "8";
                //for (int x = 0; x <= paiddue; x++)
                for (int x = 0; x < (paiddue - 1); x++)
                {
                    if (x == 0)
                    {
                        fstprm = singlprmdiff + remnprmdiff;
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            fstprm = double.Parse(Prms2[l].ToString());
                            l++;

                        }
                        if (x % 2 != 0)
                        {
                            fstprm = double.Parse(Prms1[n].ToString());
                            n++;
                        }
                    }

                    if (duemnth.ToString().Length != 2)
                    {
                        fstdue = ndueyr.ToString() + "0" + duemnth.ToString();
                    }
                    else
                    {
                        fstdue = ndueyr.ToString() + duemnth.ToString();
                    }
                    string selcom = "select * FROM  LPAY.LPAYCOM where LCPBR=" + BRN + " and LCBTP=16 and LCPDT=" + int.Parse(Currday) + " and LCREC='" + rcptno + "' and LCDUE=" + int.Parse(fstdue) + "";
                    if (dm.existRecored(selcom) == 0)
                    {
                        insert = "insert into LPAY.LPAYCOM(LCPBR,LCPDT,LCBTP,LCREC,LCPOL,LCDUE,LCTBL,LCTRM,LCMOD,LCPRM,LCCDT,LCPAC,LCAGT,LCORG,LCSBR,LCFST,LCCOD)" +
                               " values(" + BRN + "," + int.Parse(Currday) + ",'16','" + rcptno + "'," + polno + "," + int.Parse(fstdue) + "," + tble + "," + term + "," + mode + "," + fstprm + "," + commdate + "," + pacode + "," +
                               " " + agt + "," + org + "," + serbr + ",0,'" + LCCOD + "') ";
                        dm.insertRecords(insert);
                    }
                    ndueyr = ndueyr + 1;

                }
            }
            #endregion
        }
        else
        {
            throw new Exception("This Sundry Receipt has already been Issued..");
        }



    }



    private void CreateDynamicTable(bool first)
    {
        dueyr = int.Parse(commdate.ToString().Substring(0, 4));
        duemnth = int.Parse(commdate.ToString().Substring(4, 2));

        #region Calculate Yearly Premiums

        if (mode == 4)
        {
            yrlyprm = singlprmdiff * 12;
        }
        if (mode == 3)
        {
            yrlyprm = singlprmdiff * 4;
        }
        if (mode == 2)
        {
            yrlyprm = singlprmdiff * 2;
        }
        if (mode == 1)
        {
            yrlyprm = singlprmdiff;
        }
        #endregion

        // Fetch the number of Rows and Columns for the table   
        // using the properties  
        int i = 1;
        fstyrdueyr = dueyr;
        // Now iterate through the table and add your controls   
        //for (int count = 1; count <= paiddue; count++)
        //for (int count = 1; count < paiddue; count++)
        for (int count = 1; count <= pdyrs; count++)
        {
            fstyrdueyr = fstyrdueyr + 1;
            fstyrduemn = duemnth;


            TableRow tr = new TableRow();
            //if (i <= paiddue )
            //if (i < paiddue)
            if (i <= pdyrs)
            {

                TableCell tc2 = new TableCell();
                Label lbl = new Label();
                lbl.ID = "lbl" + i.ToString();
                if (fstyrduemn.ToString().Length != 2)
                {
                    lbl.Text = fstyrdueyr.ToString() + "/ 0" + fstyrduemn.ToString();
                }
                else
                {
                    lbl.Text = fstyrdueyr.ToString() + "/" + fstyrduemn.ToString();
                }

                TableCell tc = new TableCell();
                TextBox txtBox = new TextBox();
                txtBox.ID = "txt" + i.ToString();
                txtBox.Text = yrlyprm.ToString("N2");
                txtBox.Enabled = false;

                txtBox.Attributes.Add("onblur", "chkNumeric(" + txtBox.ID + ",'.')");

                CheckBox chk = new CheckBox();
                chk.ID = "chk" + i.ToString();
                chk.Attributes.Add("onclick", "checkbx(" + txtBox.ID + ",this)");
                // Add the control to the TableCell  
                tc2.Controls.Add(lbl);
                tc.Controls.Add(txtBox);
                tc.Controls.Add(chk);
                // Add the TableCell to the TableRow  
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc);

            }
            i++;
            fstyrdueyr = fstyrdueyr + 1;
            fstyrduemn = duemnth;
            //if (i <= paiddue)
            //if (i < paiddue)
            if (i <= pdyrs)
            {
                TableCell tc3 = new TableCell();
                Label lbl_ = new Label();
                lbl_.ID = "lbl_" + i.ToString();
                if (fstyrduemn.ToString().Length != 2)
                {
                    lbl_.Text = fstyrdueyr.ToString() + "/ 0" + fstyrduemn.ToString();
                }
                else
                {
                    lbl_.Text = fstyrdueyr.ToString() + "/" + fstyrduemn.ToString();
                }

                TableCell tc1 = new TableCell();
                TextBox txtBox_ = new TextBox();
                txtBox_.ID = "txt_" + i.ToString();
                txtBox_.Text = yrlyprm.ToString("N2");
                txtBox_.Enabled = false;

                txtBox_.Attributes.Add("onblur", "chkNumeric(" + txtBox_.ID + ",'.')");

                CheckBox chk_ = new CheckBox();
                chk_.ID = "chk_" + i.ToString();
                chk_.Attributes.Add("onclick", "checkbx(" + txtBox_.ID + ",this)");
                // Add the control to the TableCell 
                tc3.Controls.Add(lbl_);
                tc1.Controls.Add(txtBox_);
                tc1.Controls.Add(chk_);
                // Add the TableCell to the TableRow  
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc1);

            }
            i++;

            Table2.Rows.Add(tr);

            Table2.EnableViewState = true;
            ViewState["Table1"] = true;
        }
    }
}
