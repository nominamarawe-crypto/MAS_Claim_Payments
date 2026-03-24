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

public partial class dthReg003 : System.Web.UI.Page
{
    private  int polno;
    private  string MOF;
    private  int dateofdeath;
 
    private int dateofdeathDB;
//    private int branch;
    private int infodat;
    private double infotel;
    private  string polstat;
    private string nameOfDead;
    private string methofInfo;
    private string infoid;
    private string infoname;
    private string infoad1;
    private string infoad2;
    private string infoad3;
    private string infoad4;
    private string inforel;
    private  long claimNo;
    private string cof;

    private double sumassured;
    private int table;
    private int term;
    private  int dateofComm;
    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;

//    private string COD;
//    private int POL;
//    private int COM;
//    private int TBL;
//    private int TRM;
//    private int SUM;
//    private int MOD;
//    private  double PRM;
    private int DUE;
//    private int PAC;
//    private int AGT;
//    private int ORG;
//    private int BRN;
//    private int OBR;
//    private int PTR;

//    private int LoanNum;
//    private int rcptno;
//    private  double LMNCP_LMCPY;
//    private  double LMIPY01;
    private string nominame;
    private double percentage;
    private string address;
    private int polDuraYrs, polDuraMnths, polDuraDays;

    //******* variables for DTHREF ***************

    private  long ADB;
    private  long FPU;
    private  long SJ;
    private  long FE;
    private string ageAdmitYN;
    private double ageAdmitAmt = 0.0;//...Add by buddhika 2009/03/23..
    private double ageAdmitAmtEntry = 0.0;//...Add by buddhika 2009/04/7..
    private string revivalsYN;
    //private string assNomYN;
    private  string reinsYN;
    private  double vestedBonus;
    private  double interimBonus;
    private double surrrenderedbons;
    private int bonussurrYr;
//    private double netsurrAmt;
    private  int ageatentry;
    private  double deposit;
//    private string bonusurrYN;
//    private double demmands;
//    private double defint;
//    private int bonuscount;

    private  int covernum;
    private  int coveramt;
    private  int comdat;
    private  int covterm;

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

    DataManager dthRegObj02;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno01;
            MOF = this.PreviousPage.mos01;
            dateofdeath = this.PreviousPage.Dtaeofdeath01;
        }
        if (!Page.IsPostBack)
        {
            dthRegObj02 = new DataManager();
            try
            {
          
                #region --------------- DTHINT --------------------

                string dthintSelect = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4, ditel, dinforel, dclm, dcof from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=2  ";
                if (dthRegObj02.existRecored(dthintSelect) == 0)
                {
                    //dthRegObj02.connclose();
                    throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                }
                else
                {

                    dthRegObj02.readSql(dthintSelect);
                    OracleDataReader dthintREADER = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintREADER.Read())
                    {
                        if (!dthintREADER.IsDBNull(0))
                        {
                            infodat = dthintREADER.GetInt32(0);
                        }
                        if (!dthintREADER.IsDBNull(3))
                        {
                            dateofdeathDB = dthintREADER.GetInt32(3);
                        }

                        if (!dthintREADER.IsDBNull(11))
                        {
                            infotel = dthintREADER.GetInt64(11);
                        }
                        if (!dthintREADER.IsDBNull(1))
                        {
                            polstat = dthintREADER.GetString(1);
                        }
                        else { polstat = ""; }
                        if (!dthintREADER.IsDBNull(2))
                        {
                            nameOfDead = dthintREADER.GetString(2);
                        }
                        if (!dthintREADER.IsDBNull(4))
                        {
                            methofInfo = dthintREADER.GetString(4);
                        }
                        if (!dthintREADER.IsDBNull(5))
                        {
                            infoid = dthintREADER.GetString(5);
                        }
                        if (!dthintREADER.IsDBNull(6))
                        {
                            infoname = dthintREADER.GetString(6);
                        }
                        if (!dthintREADER.IsDBNull(7))
                        {
                            infoad1 = dthintREADER.GetString(7);
                        }
                        if (!dthintREADER.IsDBNull(8))
                        {
                            infoad2 = dthintREADER.GetString(8);
                        }
                        if (!dthintREADER.IsDBNull(9))
                        {
                            infoad3 = dthintREADER.GetString(9);
                        }
                        if (!dthintREADER.IsDBNull(10))
                        {
                            infoad4 = dthintREADER.GetString(10);
                        }
                        if (!dthintREADER.IsDBNull(12))
                        {
                            inforel = dthintREADER.GetString(12);
                        }
                        if (!dthintREADER.IsDBNull(13)) { claimNo = dthintREADER.GetInt64(13); } else { claimNo = 0; }
                        if (!dthintREADER.IsDBNull(14)) { cof = dthintREADER.GetString(14); } else { cof = ""; }
                    }
                    dthintREADER.Close();
                    dthintREADER.Dispose();
                }

                this.lblpolno.Text = polno.ToString();
                this.lblmof.Text = LIFEtype(MOF);
                this.lblmethofinfo.Text = methodofinformation(methofInfo);
                this.lblinfoid.Text = infoid;
                this.lblinfoname.Text = infoname;
                this.lblinfoad1.Text = infoad1;
                this.lblinfoad2.Text = infoad2;
                this.lblinfoad3.Text = infoad3;
                this.lblinfoad4.Text = infoad4;
                this.lblinfotel.Text = infotel.ToString();
                this.lblinforel.Text = inforel;
                this.lblnameofdead.Text = nameOfDead;
                this.lbldtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                this.lbldtofintim.Text = infodat.ToString().Substring(0, 4) + "/" + infodat.ToString().Substring(4, 2) + "/" + infodat.ToString().Substring(6, 2);
                this.lblpolstat.Text = polstate(polstat);
                this.lblclmno.Text = claimNo.ToString();
                if (cof.Equals("C")) { this.lblcof.Text = "CIVIL"; }
                else if (cof.Equals("A")) { this.lblcof.Text = "ARMY"; }
                else if (cof.Equals("N")) { this.lblcof.Text = "NAVY"; }
                else if (cof.Equals("G")) { this.lblcof.Text = "AIR FORCE"; }
                else if (cof.Equals("B")) { this.lblcof.Text = "BUDDHIST CLERGY"; }


                #endregion

                #region  // ************** PHNAME  **************************************

                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                dthRegObj02.readSql(sql);
                OracleDataReader oraDtReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraDtReader.Read())
                {
                    if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                    {
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                    }
                    if (!oraDtReader.IsDBNull(3)) { ad1 = (oraDtReader.GetString(3)); }
                    if (!oraDtReader.IsDBNull(4)) { ad2 = (oraDtReader.GetString(4)); }
                    if (!oraDtReader.IsDBNull(5)) { ad3 = (oraDtReader.GetString(5)); }
                    if (!oraDtReader.IsDBNull(6)) { ad4 = (oraDtReader.GetString(6)); }

                }
                oraDtReader.Close();
                oraDtReader.Dispose();

                this.lblnameofInsured.Text = phname;
                this.lblassuredad1.Text = ad1 + " " + ad2;
                this.lblassuredad2.Text = ad3 + " " + ad4;

                #endregion

                #region //********************** AGE AT ENTRY ***************************
                //Task 36304
                if(MOF.Equals("M") || MOF.Equals("S"))
                {
                    string agesql = "";
                    if (MOF.Equals("M"))
                    {
                        agesql = "select age from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=1";
                    }
                    else if (MOF.Equals("S"))
                    {
                        agesql = "select age from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=2";
                    }

                    dthRegObj02.readSql(agesql);
                    OracleDataReader valfilereader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (valfilereader.Read())
                    {
                        if (!valfilereader.IsDBNull(0)) { ageatentry = valfilereader.GetInt32(0); } else { ageatentry = 0; }
                    }
                    valfilereader.Close();
                    valfilereader.Dispose();
                }
                
                //-----------------------------------------------------------------------------------------------

                #endregion

                #region ----------- policy details ---------------
                string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue from lphs.premast where pmpol=" + polno + " ";
                string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue from lphs.liflaps where lppol=" + polno + " ";
                string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phsta from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                if (dthRegObj02.existRecored(premastSelect) != 0)
                {
                    dthRegObj02.readSql(premastSelect);
                    OracleDataReader premReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    premReader.Read();
                    sumassured = premReader.GetDouble(0);
                    table = premReader.GetInt32(1);
                    term = premReader.GetInt32(2);
                    if (!premReader.IsDBNull(3)) { dateofComm = premReader.GetInt32(3); } else { dateofComm = 0; }
                    //polstat = "I";
                    premReader.Close();
                    premReader.Dispose();
                }
                else if (dthRegObj02.existRecored(liflapsSelect) != 0)
                {
                    dthRegObj02.readSql(liflapsSelect);
                    OracleDataReader lapsReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    lapsReader.Read();
                    sumassured = lapsReader.GetDouble(0);
                    table = lapsReader.GetInt32(1);
                    term = lapsReader.GetInt32(2);
                    dateofComm = lapsReader.GetInt32(3);
                    DUE = lapsReader.GetInt32(4);
                    //polstat = "L";
                    lapsReader.Close();
                    lapsReader.Dispose();
                }
                else
                {
                    dthRegObj02.readSql(polhisSelect);
                    OracleDataReader polhisReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    polhisReader.Read();
                    sumassured = polhisReader.GetDouble(0);
                    table = polhisReader.GetInt32(1);
                    term = polhisReader.GetInt32(2);
                    dateofComm = polhisReader.GetInt32(3);
                    DUE = polhisReader.GetInt32(4);
                    //if (!polhisReader.IsDBNull(5)) polstat = polhisReader.GetString(5);
                    polhisReader.Close();
                    polhisReader.Dispose();
                }
                General gg = new General();
                polstat = gg.LapsetoInforce(polno, dateofdeath, dthRegObj02);
                //--- policy duration -----
                if (polstat.Equals("I"))
                {
                    polDuraYrs = this.dateComparison(dateofComm, dateofdeath)[0];
                    polDuraMnths = this.dateComparison(dateofComm, dateofdeath)[1];
                    polDuraDays = this.dateComparison(dateofComm, dateofdeath)[2];
                    if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }
                }
                else
                {
                    //---------- include code to read the ledger table to get the last paymnet date

                    int dueYMD = int.Parse(DUE.ToString() + dateofComm.ToString().Substring(6, 2));
                    polDuraYrs = this.dateComparison(dateofComm, dueYMD)[0];
                    polDuraMnths = this.dateComparison(dateofComm, dueYMD)[1];
                    polDuraDays = this.dateComparison(dateofComm, dueYMD)[2];
                    if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }

                    //-------- NEW CONDITION TO COMPARE EXIT YM WITH MATURITY -----
                    //if (dueYMD > dateofdeath)
                    //{
                    //    //dthRegObj02.connclose();
                    //    throw new Exception("Policy Lapsed After the date of Death!");
                    //}
                }

                this.lblduyrs.Text = polDuraYrs.ToString() + " Yrs " + polDuraMnths.ToString() + " Mnths";


                #endregion

                if (MOF.Equals("M") || MOF.Equals("S")) //Task 36304
                {
                    int duratn = int.Parse(this.setDate()[0].Substring(0, 4)) - int.Parse(dateofComm.ToString().Substring(0, 4));
                    int mnthdiff = int.Parse(this.setDate()[0].Substring(4, 2)) - int.Parse(dateofComm.ToString().Substring(4, 2));
                    if (mnthdiff > 6) duratn++;
                    else if (mnthdiff < -6) duratn--;
                    else { }

                    this.lblageatentstr.Visible = true;
                    this.lblageatentry.Visible = true;
                    this.lblageatdthstr.Visible = true;
                    this.lblageatdth.Visible = true;
                    this.lblageatentry.Text = ageatentry.ToString();
                    this.lblageatdth.Text = (ageatentry + duratn).ToString();
                }


                this.lblsumassured.Text = String.Format("{0:N}", sumassured);
                this.lbltab.Text = table.ToString();
                this.lblterm.Text = term.ToString();
                this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);
                                
               
                //---------------------------- Showing Loans ------------------------------------------------------
                #region
                string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1  from lphs.lplmast where lmpol=" + polno + " and (lmset = 'Y' or lmset is null) and (lmcd1 = 'D' or lmcd1 is null)";
                int caldate = int.Parse(this.setDate()[0]);
                dthRegObj02.readSql(loansql);
                OracleDataReader myloanreader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                int rows = 0;
                double loantotal = 0;
                double loaninttot = 0;

                while (myloanreader.Read())
                {

                    double[] arr = new double[9];
                    int LoanNum = myloanreader.GetInt32(0);
                    int lmpdt = myloanreader.GetInt32(1);
                    int lmnid = myloanreader.GetInt32(2);
                    int lmlrd = myloanreader.GetInt32(3);
                    double lmpit = myloanreader.GetDouble(4);
                    double lmnit = myloanreader.GetDouble(5);
                    double lmpcp = myloanreader.GetDouble(6);
                    double lmncp = myloanreader.GetDouble(7);
                    double lmipy = myloanreader.GetDouble(8);
                    double lmcpy = myloanreader.GetDouble(9);
                    double lmitr = myloanreader.GetDouble(10);
                    double lmcit = myloanreader.GetDouble(11);
                    double lmccp = myloanreader.GetDouble(12);
                    int lmcdt = myloanreader.GetInt32(13);
                    int lmmdt = myloanreader.GetInt32(14);
                    string lmset = "";
                    if (!myloanreader.IsDBNull(15))
                    {
                        lmset = myloanreader.GetString(15);
                    }
                    string lmcd1 = "";
                    if (!myloanreader.IsDBNull(16))
                    {
                        lmcd1 = myloanreader.GetString(16);
                    }



                    if ((lmset.Equals("Y")) && (!(lmcd1.Equals("D"))))
                    {
                        this.Label1.Visible = true;
                        double loanCapital = 0;
                        double loaninterest = 0;
                        try
                        {
                            arr = loanCalculation.calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, caldate);

                            loantotal += arr[5];
                            loaninttot += arr[8];

                            loanCapital = arr[5];
                            loaninterest = arr[8];                          
                        }
                        catch
                        {
                            loantotal = 0;
                            loaninttot = 0;
                        }

                        //------------- Back Calculation Algorithm Applied 20070802 ------------

                        double temploanCapital = loanCapital;
                        loanCapital = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, loanCapital, ((double)lmitr / 200), lmpdt, lmpit)[0];
                        loaninterest = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, temploanCapital, ((double)lmitr / 200), lmpdt, lmpit)[1];
                        temploanCapital = loanCapital - loaninterest;

                        if (rows == 0)
                        {
                            this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", rows);
                            this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(temploanCapital), Convert.ToString(loaninterest), rows);
                        }
                        else
                        {
                            this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(temploanCapital), Convert.ToString(loaninterest), rows);
                        }

                        rows++;
                    }

                }
                myloanreader.Close();
                myloanreader.Dispose();

                #endregion
                //-------------------- Showing Nominees -----------------------------------------------------------
                #region
                int nomRow = 0;
                string nomSelect = "select nomnam, nomper,NOMAD1  || '  ' || NOMAD2 as NOMAD1  from lund.nominee where polno=" + polno + "";
                if (dthRegObj02.existRecored(nomSelect) == 0)
                {
                    //this.lblassnom.Text = "No";
                }

                else
                {
                    this.Label2.Visible = true;
                    dthRegObj02.readSql(nomSelect);
                    OracleDataReader nomReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    this.CreateHeader();
                    while (nomReader.Read())
                    {
                        if (!nomReader.IsDBNull(0)) { nominame = nomReader.GetString(0); }
                        if (!nomReader.IsDBNull(1)) { percentage = nomReader.GetDouble(1); }
                        if (!nomReader.IsDBNull(2)) { address = nomReader.GetString(2); }

                        this.createNomineeTable(nominame, percentage.ToString(), nomRow, address);
                        nomRow++;
                    }
                    nomReader.Close();
                    nomReader.Dispose();
                    //this.lblassnom.Text = "Yes";
                }


                #endregion

                //------------------- Showing Rider Covers --------------------------------------------------------
                #region


                string covername = "";
                int rows2 = 0;
                string rcoverSelect = "select rcovr, rsumas, rcomdat, rterm from lund.rcover where rpol=" + polno + " ";
                if (dthRegObj02.existRecored(rcoverSelect) == 0)
                {
                    //  this.btnaddcover.Visible = true;
                }
                else
                {
                    dthRegObj02.readSql(rcoverSelect);
                    OracleDataReader rcoverReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rcoverReader.Read())
                    {
                        if (!rcoverReader.IsDBNull(0)) { covernum = rcoverReader.GetInt32(0); } else { covernum = 0; }
                        if (!rcoverReader.IsDBNull(1)) { coveramt = rcoverReader.GetInt32(1); } else { coveramt = 0; }
                        if (!rcoverReader.IsDBNull(2)) { comdat = rcoverReader.GetInt32(2); } else { comdat = 0; }
                        if (!rcoverReader.IsDBNull(3)) { covterm = rcoverReader.GetInt32(3); } else { covterm = 0; }

                        string covernameSelect = "select rconam from lund.rcovrnam where rconum=" + covernum + " ";
                        dthRegObj02.readSql(covernameSelect);
                        OracleDataReader coverNameReader = dthRegObj02.oraComm.ExecuteReader();
                        while (coverNameReader.Read())
                        {
                            covername = coverNameReader.GetString(0);
                        }
                        coverNameReader.Close();
                        if ((MOF.Equals("M")) && (covernum.ToString().Length <= 2))
                        {
                            if ((covernum == 2) || (covernum == 4) || (covernum == 10) || (covernum == 11))
                            {
                                this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                rows2++;

                                if (covernum == 2) ADB = coveramt;
                                else if (covernum == 4) FPU = coveramt;
                                else if (covernum == 10) SJ = coveramt;
                                else FE = coveramt;
                            }

                        }
                        else if ((MOF.Equals("S")) && (covernum.ToString().Length > 2) && (covernum.ToString().StartsWith("1")))
                        {
                            if ((table == 14) || (table == 38) || (table == 39))
                            {
                                if ((covernum == 102) || (covernum == 110) || (covernum == 111))
                                {
                                    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                    rows2++;
                                    if (covernum == 102) ADB = coveramt;
                                    else if (covernum == 110) SJ = coveramt;
                                    else if ((table != 14) && (covernum == 111)) FE = coveramt;
                                    else { }
                                }
                            }
                            else
                            {
                                if ((covernum == 102) || (covernum == 110) || (covernum == 111))
                                {

                                    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                    rows2++;
                                    if (covernum == 102) ADB = coveramt;
                                    else if (covernum == 110) SJ = coveramt;
                                    else FE = coveramt;

                                }
                            }

                        }
                        else if ((MOF.Equals("2")) && (covernum.ToString().Length > 2) && (int.Parse(covernum.ToString().Substring(0, 1)) > 1))
                        {
                            if ((covernum == 202) || (covernum == 210) || (covernum == 211))
                            {
                                this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                rows2++;
                                if (covernum == 202) ADB = coveramt;
                                else if (covernum == 210) SJ = coveramt;
                                else if ((table != 14) && (covernum == 111)) FE = coveramt;
                                else { }
                            }

                        }
                        else
                        {
                            //??????????????????????????????????????????????????????????????????????????????????????????????
                        }

                    }
                    rcoverReader.Close();
                    rcoverReader.Dispose();

                    if (MOF.Equals("M"))
                    {
                        this.lblcoverfor.Text = "Rider Benefits For Main Life";
                    }
                    else if (MOF.Equals("S"))
                    {
                        this.lblcoverfor.Text = "Rider Benefits For Spouse";
                    }
                    else
                    {
                        this.lblcoverfor.Text = "Rider Benefits For Second Life";
                    }

                }
                #endregion
                //--------------------- showing reinsurance -------------------------------------------------------
                #region

                string LREINSURselect = "select * from lphs.lreinsur where ripolno=" + polno + "";
                if (dthRegObj02.existRecored(LREINSURselect) != 0)
                {
                    this.lblreinsyn.Text = "Yes";
                    reinsYN = "Y";
                }
                else this.lblreinsyn.Text = "No";

                #endregion
                //--------------------- Viewing Deposites ---------------------------------------------------------
                #region
                DataManager deposits = new DataManager();
                string depositsql = "select DPTAM from lpay.deposit where DPPOL=" + polno + " AND DPDEL <> 1 and DPTAM>0 ";
                deposits.readSql(depositsql);
                OracleDataReader depositreader = deposits.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                double tempDepo = 0;
                while (depositreader.Read())
                {
                    double depamount = depositreader.GetDouble(0);
                    tempDepo  += depamount;

                }
                depositreader.Close();
                depositreader.Dispose();

                deposit = tempDepo;
                this.lbldeposits.Text = String.Format("{0:N}", deposit);
                #endregion
                //--------------------- viewing other details -----------------------------------------
                #region

                string dthrefSelect = "select DRAGEADMIT, DRRINSYN, DRREVIVALS, DRVESTEDBON, DRINTERIMBON, DRBONSURRAMT, DRBONSURRYR, DRASSIGNEENOM,AGE_AMT,AGEDIFINRST from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "'";
                dthRegObj02.readSql(dthrefSelect);
                OracleDataReader dthrefreader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthrefreader.Read()) {
                    if (!dthrefreader.IsDBNull(0)) { ageAdmitYN = dthrefreader.GetString(0); } else { ageAdmitYN = ""; }
                    if (!dthrefreader.IsDBNull(2)) { revivalsYN = dthrefreader.GetString(2); } else { revivalsYN = ""; }
                    if (!dthrefreader.IsDBNull(3)) { vestedBonus = dthrefreader.GetDouble(3); } else { vestedBonus = 0; }
                    if (!dthrefreader.IsDBNull(4)) { interimBonus = dthrefreader.GetDouble(4); } else { interimBonus = 0; }
                    if (!dthrefreader.IsDBNull(5)) { surrrenderedbons = dthrefreader.GetDouble(5); } else { surrrenderedbons = 0; }
                    if (!dthrefreader.IsDBNull(6)) { bonussurrYr = dthrefreader.GetInt32(6); } else { bonussurrYr = 0; }
                    //if (!dthrefreader.IsDBNull(7)) { assNomYN = dthrefreader.GetString(7); } else { assNomYN = ""; }
                    if (!dthrefreader.IsDBNull(8)) { ageAdmitAmt = dthrefreader.GetDouble(8); } else { ageAdmitAmt = 0.00; }//..add by buddhika 2009/03/23...
                    if (!dthrefreader.IsDBNull(9)) { ageAdmitAmtEntry = dthrefreader.GetDouble(9); } else { ageAdmitAmtEntry = 0.00; }//..add by buddhika 2009/04/7...
                }
                dthrefreader.Close();
                dthrefreader.Dispose();

                double totalBonus = vestedBonus + interimBonus - surrrenderedbons;
                this.lbltotbons.Text = String.Format("{0:N}", totalBonus);
                if (ageAdmitYN.Equals("Y")) { this.lblageadmit.Text = "Yes"; }
                else { this.lblageadmit.Text = "No"; }
                if (revivalsYN.Equals("Y")) { this.lblrevivals.Text = "Yes"; }
                else { this.lblrevivals.Text = "No"; }
                LbAgeAdminAmt.Text = String.Format("{0:N}", ageAdmitAmt);//..add by buddhika 2009/03/23...
                LbAgeAmtInt.Text = String.Format("{0:N}", ageAdmitAmt);//..add by buddhika 2009/03/23...
                //if (assNomYN.Equals("Y")) { this.lblassnom.Text = "Yes"; }
                //else { this.lblassnom.Text = "No"; }
                #endregion

                dthRegObj02.connclose();
                LtUserDetails.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now) + " " + String.Format("{0:hh:mm:ss}", DateTime.Now) + " , " + Session["EPFNum"].ToString() + " , " + Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            catch (Exception ex) 
            {
                dthRegObj02.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");            
            }
        
        }
        
    }

    protected string polstate(string state)
    {
        string thestate = "";
        if (state.Equals("L"))
        {
            thestate = "Lapsed";
        }
        else
        {
            thestate = "Inforce";
        }
        return thestate;
    }

    protected string methodofinformation(string meth)
    {
        string method = "";
        if (meth.Equals("MAIL"))
        {
            method = "Mail";
        }
        else if (meth.Equals("COUN"))
        {
            method = "Counter";
        }
        else
        {
            method = "Call";
        }
        return method;
    }

    protected string LIFEtype(string mainorspouse)
    {
        string lifetype = "";
        if (mainorspouse.Equals("M"))
        {
            lifetype = "Main Life";
        }
        else if (mainorspouse.Equals("S"))
        {
            lifetype = "Spouse";
        }
        else
        {
            lifetype = "Secod Life";
        }
        return lifetype;
    }

    private void createLoanTable(string LoanNumber, string lmcdt, string lmccp, string arr8, int rowNumber)
    {
        try
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


            lbl1.ID = "LoanNumber" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "LoanNumber" + rowNumber); //Text Value
            lbl1.Text = LoanNumber;

            lbl2.ID = "lmcdt" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "lmcdt" + rowNumber); //Text Value
            lbl2.Text = lmcdt;

            lbl3.ID = "lmccp" + rowNumber;
            lbl3.Attributes.Add("runat", "Server");
            lbl3.Attributes.Add("Name", "lmccp" + rowNumber); //Text Value
            if (!lmccp.Equals("Loan Capital (Rs.)"))
            {
                lbl3.Text = String.Format("{0:N}", Convert.ToDouble(lmccp));
            }
            else
            {
                lbl3.Text = lmccp;
            }

            lbl4.ID = "lmnit" + rowNumber;
            lbl4.Attributes.Add("runat", "Server");
            lbl4.Attributes.Add("Name", "arr8" + rowNumber); //Text Value
            if (!arr8.Equals("Interest (Rs.)"))
            {
                lbl4.Text = String.Format("{0:N}", Convert.ToDouble(arr8));
            }
            else
            {
                lbl4.Text = arr8;
            }
            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            tcell3.Controls.Add(lbl3);
            tcell4.Controls.Add(lbl4);

            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            trow.Cells.Add(tcell3);
            trow.Cells.Add(tcell4);

            Table1.Rows.Add(trow);


        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    private void CreateHeader()
    {
        TableHeaderRow tbhr = new TableHeaderRow();
        TableHeaderCell thCell1 = new TableHeaderCell();
        thCell1.Text = "Name";
        tbhr.Cells.Add(thCell1);

        TableHeaderCell thCell2 = new TableHeaderCell();
        thCell2.Text = "Percentage";
        tbhr.Cells.Add(thCell2);

        TableHeaderCell thCell3 = new TableHeaderCell();
        thCell3.Text = "Address";
        tbhr.Cells.Add(thCell3);

        Table2.Rows.Add(tbhr);
    }

    private void createNomineeTable(string nominee, string percentage, int rowNumber, string address)
    {
                     

        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "percentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
        lbl2.Text = percentage + "%";

        lbl3.ID = "Address" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "address" + rowNumber);
        lbl3.Text = address;

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);

        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);

        Table2.Rows.Add(trow);
    }

    private void createRiderCoverTable(string riderCover, string sumassured, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "riderCover" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "riderCover" + rowNumber); //Text Value
        lbl1.Text = riderCover;

        lbl2.ID = "sumassured" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "sumassured" + rowNumber); //Text Value
        lbl2.Text = sumassured;

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        Table3.Rows.Add(trow);
    }
    protected double[] backCalculationAlgorithm(int loanGrantDate, int dateofDth, double loanInt, double loanCap, double interestRate, int lmpdtParam, double lmpitParam)
    {
        double[] backVals = new double[2];

        #region
        //int monthDiffBetweenTodayAndLGDAT = this.dateComparison(loanGrantDate, int.Parse(this.setDate()[0]))[1];
        //int yearDiffBetweenTodayAndLGDAT = this.dateComparison(loanGrantDate, int.Parse(this.setDate()[0]))[0];

        //int monthDiffBetweenTodayAndLGDAT = this.dateComparison(loanGrantDate, dateofDth)[1];
        //int yearDiffBetweenTodayAndLGDAT = this.dateComparison(loanGrantDate, dateofDth)[0];

        //int sixmonthPeriodsInMonthDiff = (int)((monthDiffBetweenTodayAndLGDAT + (yearDiffBetweenTodayAndLGDAT * 12)) / 6);
        //int lastInterestCalcDate = this.dateAdd(loanGrantDate, 0, (sixmonthPeriodsInMonthDiff * 6), 0);
        /*
        int monthDiffBetweenTodayAndDtOfDth = this.dateComparison(dateofDth, int.Parse(this.setDate()[0]))[1];
        int dateDiffBetweenTodayAndDtOfDth = this.dateComparison(dateofDth, int.Parse(this.setDate()[0]))[2];
        if (dateDiffBetweenTodayAndDtOfDth > 15) { monthDiffBetweenTodayAndDtOfDth++; }
        */
        //double loanCapPresentVal4LLCD = loanCap / (Math.Pow((double)(1 + interestRate), monthDiffBetweenTodayAndLLCD));
        //double loanIntPresentVal4LLCD = loanInt / (Math.Pow((double)(1 + interestRate), monthDiffBetweenTodayAndLLCD));
        /*
        double PresentVal4LLCD4both = (loanCap + loanInt) / (Math.Pow((double)(1 + interestRate), monthDiffBetweenTodayAndDtOfDth));
        double presentLoanInt = PresentVal4LLCD4both - loanCap;
        double loanCapitalWithInterest = presentLoanInt + loanCap;
        */
        //int mthDiffBetLLCDandDtOfDth = this.dateComparison(lastInterestCalcDate, dateofdeath)[1];       
        //double loanIntPresentVal4LLCD = PresentVal4LLCD4both - loanCap + (loanCap * interestRate * mthDiffBetLLCDandDtOfDth);
        //double futrValTilDtofDth = loanCap + loanIntPresentVal4LLCD;
        #endregion

        double presentLoanInt = 0;
        double loanCapitalWithInterest = 0;
        double mnthDiffBetLMPDTAndDtOfDth = 0;
        int dateDiffBetLMPDTAndDtOfDth = 0;
        if (dateofDth <= lmpdtParam)
        {
            mnthDiffBetLMPDTAndDtOfDth = this.dateComparison(dateofDth, lmpdtParam)[1];
            dateDiffBetLMPDTAndDtOfDth = this.dateComparison(dateofDth, lmpdtParam)[2];
            if (dateDiffBetLMPDTAndDtOfDth > 15) { mnthDiffBetLMPDTAndDtOfDth++; }
            mnthDiffBetLMPDTAndDtOfDth /= 6;
            loanCapitalWithInterest = (loanCap + lmpitParam) / (Math.Pow((double)(1 + interestRate), mnthDiffBetLMPDTAndDtOfDth));
            presentLoanInt = loanCapitalWithInterest - loanCap;
        }
        else
        {
            mnthDiffBetLMPDTAndDtOfDth = this.dateComparison(lmpdtParam, dateofDth)[1];
            dateDiffBetLMPDTAndDtOfDth = this.dateComparison(lmpdtParam, dateofDth)[2];
            if (dateDiffBetLMPDTAndDtOfDth > 15) { mnthDiffBetLMPDTAndDtOfDth++; }
            loanCapitalWithInterest = loanCap + (loanCap * (interestRate / 6) * mnthDiffBetLMPDTAndDtOfDth) + loanInt;
            presentLoanInt = loanCapitalWithInterest - loanCap;
        }

        backVals[0] = loanCapitalWithInterest;
        backVals[1] = presentLoanInt;

        return backVals;

    }
    public int[] dateComparison(int startdate, int enddate)
    {
        //end date is today, startdate, enddate should be yyyymmdd format
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

}
