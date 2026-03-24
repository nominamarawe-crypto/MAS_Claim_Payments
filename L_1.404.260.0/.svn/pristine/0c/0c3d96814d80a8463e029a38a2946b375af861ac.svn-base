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

    private string COD;
//    private int POL;
//    private int COM;
//    private int TBL;
//    private int TRM;
//    private int SUM;
    private int MOD;
//    private  double PRM;
    private int DUE;
    private int PAC;
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
    private string Address;
    private string NIC;
    private string EnterEPF;
    private int EDate;
    private int AutEPF;
    private int ADate;

    private string pnominame;
    private double ppercentage;
    private string pNIC;
    private string pEnterEPF;
    private string pEDate;
    private int polDuraYrs, polDuraMnths, polDuraDays;

    //******* variables for DTHREF ***************

    private  long ADB;
    private  long FPU;
    private  long SJ;
    private  long FE;
    private string ageAdmitYN;
    private double ageAdmitAmt = 0.0;//...Add by buddhika 2009/03/23..
    private double ageAdmitAmtEntry = 0.0;//...Add by buddhika 2009/04/7..
    private double loanAmt = 0.0; //task 36202
    private double loanIntrest = 0.0;//task 36202
    private string revivalsYN;
    //private string assNomYN;
    private  string reinsYN;
    private  double vestedBonus;
    private  double interimBonus;
    private double surrrenderedbons;
    private int bonussurrYr;
//    private double netsurrAmt;
    private  int ageatentry;
    private long dateOfBirth = 0;
    private double fullAge = 0;
    private  double deposit;
//    private string bonusurrYN;
//    private double demmands;
//    private double defint;
//    private int bonuscount;

    private  int covernum;
    private  int coveramt;
    private  int comdat;
    private  int covterm;

    DataManager dthintobj;
    AMLDesignatedPerson amlDesignated;

    private int havePayment;
    private string havePaymentWarring;

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
            dthintobj = new DataManager();
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
                //this.lblpolstat.Text = polstate(polstat);
                this.lblclmno.Text = claimNo.ToString();
                if (cof.Equals("C")) { this.lblcof.Text = "CIVIL"; }
                else if (cof.Equals("A")) { this.lblcof.Text = "ARMY"; }
                else if (cof.Equals("N")) { this.lblcof.Text = "NAVY"; }
                else if (cof.Equals("G")) { this.lblcof.Text = "AIR FORCE"; }
                else if (cof.Equals("B")) { this.lblcof.Text = "BUDDHIST CLERGY"; }


                #endregion

                #region  --------------- PHNAME --------------------

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

                #region --------------- AGE AT ENTRY -------------------
                //Task 36304
                if (MOF.Equals("M") || MOF.Equals("S") || MOF.Equals("C"))
                {
                    string agesql = "";
                    if (MOF.Equals("M"))
                    {
                        agesql = "select age,ageproof,dob from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=1";
                    }
                    else if (MOF.Equals("S"))
                    {
                        agesql = "select age,ageproof,dob from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=2";
                    }
                    else if (MOF.Equals("C"))
                    {
                        agesql = "select age,ageproof,dob from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=4";
                    }
                    dthRegObj02.readSql(agesql);
                    OracleDataReader agereader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (agereader.Read())
                    {
                        if (!agereader.IsDBNull(0)) { ageatentry = agereader.GetInt32(0); } else { ageatentry = 0; }
                        if (!agereader.IsDBNull(1)) { ageAdmitYN = agereader.GetString(1); } else { ageAdmitYN = ""; }
                        if (!agereader.IsDBNull(2)) { dateOfBirth = agereader.GetInt64(2); } else { dateOfBirth = 0; }
                    }
                    agereader.Close();
                    agereader.Dispose();
                }
                
                //-----------------------------------------------------------------------------------------------

                #endregion

                #region --------------- policy details ------------
                string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue,pmmod, PMCOD, PMPAC from lphs.premast where pmpol=" + polno + " ";
                string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue,lpmod, LPCOD, LPPAC from lphs.liflaps where lppol=" + polno + " ";
                string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phsta,phmod , PHCOD, PHPAC from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                if (dthRegObj02.existRecored(premastSelect) != 0)
                {
                    dthRegObj02.readSql(premastSelect);
                    OracleDataReader premReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    premReader.Read();
                    sumassured = premReader.GetDouble(0);
                    table = premReader.GetInt32(1);
                    term = premReader.GetInt32(2);
                    if (!premReader.IsDBNull(3)) { dateofComm = premReader.GetInt32(3); } else { dateofComm = 0; }
                    if (!premReader.IsDBNull(5)) { MOD = Convert.ToInt32(premReader[5]); } else { MOD = 0; }
                    if (!premReader.IsDBNull(6)) { COD = premReader[6].ToString(); } else { COD = ""; }
                    if (!premReader.IsDBNull(7)) { PAC = Convert.ToInt32(premReader[7]); } else { PAC = 0; }
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
                    if (!lapsReader.IsDBNull(5)) { MOD = Convert.ToInt32(lapsReader[5]); } else { MOD = 0; }
                    if (!lapsReader.IsDBNull(6)) { COD = lapsReader[6].ToString(); } else { COD = ""; }
                    if (!lapsReader.IsDBNull(7)) { PAC = Convert.ToInt32(lapsReader[7]); } else { PAC = 0; }
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
                    if (!polhisReader.IsDBNull(6)) { MOD = Convert.ToInt32(polhisReader[6]); } else { MOD = 0; }
                    if (!polhisReader.IsDBNull(7)) { COD = polhisReader[7].ToString(); } else { COD = ""; }
                    if (!polhisReader.IsDBNull(8)) { PAC = Convert.ToInt32(polhisReader[8]); } else { PAC = 0; }
                    //if (!polhisReader.IsDBNull(5)) polstat = polhisReader.GetString(5);
                    polhisReader.Close();
                    polhisReader.Dispose();
                }

                //General gg = new General();
                //using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
                //{   
                //    polstat = gg.LapsetoInforce(dal, polno, dateofdeath, table, dateofComm, MOD, PAC, COD, term);
                //}
                //this.lblpolstat.Text = polstate(polstat);

                #region ------------- Health Product Changes ------------

                if (table == 64)
                {
                    string tab = "";
                    string lpolhisSelect = "select PHMOS from lphs.lpolhis where phpol=" + polno + " ";

                    if (dthintobj.existRecored(lpolhisSelect) != 0)
                    {
                        dthintobj.readSql(lpolhisSelect);
                        OracleDataReader lpolhisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        lpolhisReader.Read();
                        tab = lpolhisReader.GetString(0);
                        lpolhisReader.Close();
                        lpolhisReader.Dispose();
                    }
                    if (tab == "M")
                    {
                        string lpolhisSelectTable = "select PHTBL from lphs.lpolhis where phpol=" + polno + " ";

                        if (dthintobj.existRecored(lpolhisSelectTable) != 0)
                        {
                            dthintobj.readSql(lpolhisSelectTable);
                            OracleDataReader lpolhisTableReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            lpolhisTableReader.Read();
                            table = lpolhisTableReader.GetInt32(0);
                            lpolhisTableReader.Close();
                            lpolhisTableReader.Dispose();
                        }
                    }
                }
                //if (table == 55) #44917
                //{
                //    #region  ------------- RCover - SA, COM DATE & Term details ----------------
                //    int rcov = 0;
                //    if (MOF == "M")
                //    {
                //        rcov = 1;
                //    }
                //    else if (MOF == "S")
                //    {
                //        rcov = 101;
                //    }
                //    string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                //    if (dthRegObj02.existRecored(rcovSelect) == 0)
                //    {
                //        throw new Exception("No Cover Details!");
                //    }
                //    else
                //    {
                //        dthRegObj02.readSql(rcovSelect);
                //        OracleDataReader rcovReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //        rcovReader.Read();
                //        sumassured = rcovReader.GetDouble(0);
                //        dateofComm = rcovReader.GetInt32(1);
                //        term = rcovReader.GetInt32(2);
                //        rcovReader.Close();
                //        rcovReader.Dispose();
                //    }
                //    #endregion
                //}
                //else
                //{
                    #region  ------------- RCover - SA, COM DATE & Term details ----------------
                    int rcov = 0;
                    if (MOF == "S")
                    {
                        rcov = 101;
                    }
                    else
                    {
                        rcov = 1;
                    }
                    string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                    string rcovHisSelect = @"select rsumas, rcomdat,rterm from LUND.RCOVER_HISTORY where rpol=" + polno + " and rcovr=" + rcov + "";
                    if (dthintobj.existRecored(rcovSelect) != 0)
                    {
                        dthintobj.readSql(rcovSelect);
                        OracleDataReader rcovReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        rcovReader.Read();
                        sumassured = rcovReader.GetDouble(0);

                        //Task 25983
                        dateofComm = rcovReader.GetInt32(1);
                        term = rcovReader.GetInt32(2);

                        rcovReader.Close();
                        rcovReader.Dispose();
                    }
                    else if (dthintobj.existRecored(rcovHisSelect) != 0)
                    {
                        dthintobj.readSql(rcovHisSelect);
                        OracleDataReader rcovHisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        rcovHisReader.Read();
                        sumassured = rcovHisReader.GetDouble(0);

                        //Task 25983
                        dateofComm = rcovHisReader.GetInt32(1);
                        term = rcovHisReader.GetInt32(2);

                        rcovHisReader.Close();
                        rcovHisReader.Dispose();
                    }
                    #endregion
                //}
                #endregion

                //Task 29280
                if (term == 0 && table == 1)
                {
                    term = 99;
                }

                //Task 25982
                General gg = new General();
                using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
                {
                    polstat = gg.LapsetoInforce(dal, polno, dateofdeath, table, dateofComm, MOD, PAC, COD, term, MOF);
                }
                this.lblpolstat.Text = polstate(polstat);
                //General gg = new General();
                //polstat = gg.LapsetoInforce(polno, dateofdeath, dthRegObj02);
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

                    DUE = gg.Duedate; 
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

               // if (MOF.Equals("M") || MOF.Equals("S")) //Task 36304
                if (MOF.Equals("M") || MOF.Equals("S") || MOF.Equals("C")) //child age also required in case of 49
                {
                    int duratn = int.Parse(this.setDate()[0].Substring(0, 4)) - int.Parse(dateofComm.ToString().Substring(0, 4));
                    int mnthdiff = int.Parse(this.setDate()[0].Substring(4, 2)) - int.Parse(dateofComm.ToString().Substring(4, 2));
                    if (mnthdiff > 6) duratn++;
                    else if (mnthdiff < -6) duratn--;
                    else { }

                    //this.lblageatentstr.Visible = true;
                    this.lblageatentry.Visible = true;
                    //this.lblageatdthstr.Visible = true;
                    this.lblageatdth.Visible = true;
                    
                    //this.lblageatentry.Text = ageatentry.ToString();
                    //this.lblageatdth.Text = (ageatentry + duratn).ToString();
                  
                    string tmpdod = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                    //this.lblageatentryDOB.Text = tmpDOB;

                    if (dateOfBirth > 0)
                    {
                        string tmpDOB = dateOfBirth.ToString().Substring(0, 4) + "/" + dateOfBirth.ToString().Substring(4, 2) + "/" + dateOfBirth.ToString().Substring(6, 2);
                        this.lblageatentry.Text = ageatentry.ToString();// +"(" + GetFullAge(tmpDOB, tmpdod).ToString() + ")";
                        this.lblageatdth.Text=Math.Round(GetFullAge(tmpDOB, tmpdod)).ToString();
                    }
                    else
                    {
                        this.lblageatentry.Text = ageatentry.ToString();
                        this.lblageatdth.Text = (ageatentry + polDuraYrs).ToString();
                    }

                }


                this.lblsumassured.Text = String.Format("{0:N}", sumassured);
                this.lbltab.Text = table.ToString();
                this.lblterm.Text = term.ToString();
                this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);


                //----------------------------commented 2011/04/28 Showing Loans ------------------------------------------------------
                #region
                //task 36202
                string dthsql = @"select lm.lmlon,dr.drloncap,dr.drloanint,lm.lmcdt,dr.drclmno from lphs.lplmast lm, lphs.dthref dr  where lmpol = drpolno and lmpol = " + polno + " and lmlon = (select max(lmlon) from lphs.lplmast where lmpol = " + polno + ")";
                DataManager dthRef = new DataManager();
                dthRef.readSql(dthsql);
                int dthClaimNo = 0;
                string loanNumber = "";
                string capitalToBePaid = "";
                string interestToBePaid ="";
                int loanCommencementDate;
                int loanGrantDate = 0;
                OracleDataReader mydthrefreader = dthRef.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (mydthrefreader.Read())
                {
                    dthClaimNo = mydthrefreader.GetInt32(4);
                    loanNumber = mydthrefreader[0].ToString();
                    capitalToBePaid = mydthrefreader[1].ToString();
                    interestToBePaid = mydthrefreader[2].ToString();
                    loanGrantDate = mydthrefreader.GetInt32(3);
                }
                mydthrefreader.Close();
                mydthrefreader.Dispose();

                if (dthClaimNo != 0)
                {
                    this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", 0);
                    this.createLoanTable(loanNumber, (Convert.ToString(loanGrantDate).Substring(0, 4) + "/" + Convert.ToString(loanGrantDate).Substring(4, 2) + "/" + Convert.ToString(loanGrantDate).Substring(6, 2)), capitalToBePaid, interestToBePaid, 0);
                }
                else
                {
                    string loansql = @" select p.LOANNO, p.CAPITAL ,p.INTEREST,l.lmcdt   
                                    from   LPHS.LOAN_RCIEPT_REPRINT  P , lphs.lplmast L  
                                    where P.loanno = L.lmlon and P.POLINO =  " + polno + " and P.CLAIMNO =" + claimNo;
                    dthRegObj02.readSql(loansql);


                    OracleDataReader myloanreader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (myloanreader.Read())
                    {
                        loanNumber = myloanreader[0].ToString();
                        capitalToBePaid = myloanreader[1].ToString();
                        interestToBePaid = myloanreader[2].ToString();
                        loanGrantDate = myloanreader.GetInt32(3);

                        this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", 0);
                        this.createLoanTable(loanNumber, (Convert.ToString(loanGrantDate).Substring(0, 4) + "/" + Convert.ToString(loanGrantDate).Substring(4, 2) + "/" + Convert.ToString(loanGrantDate).Substring(6, 2)), capitalToBePaid, interestToBePaid, 0);

                    }
                    myloanreader.Close();
                    myloanreader.Dispose();
                }


                
 /*               string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1  from lphs.lplmast where lmpol=" + polno + " and (lmset = 'Y' or lmset is null) and (lmcd1 = 'D' or lmcd1 is null)";
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
                myloanreader.Dispose();*/

                #endregion

                //added by sindu
                #region --------------------------- Showing Previous Nominees ----------------------------------------------------

                int nomineeRow = 0;
                string npEDate = "";
                string nomineeSelect = "select ln.NOMNIC, ln.NOMNAM, ln.NOMPER,ln.ENTEPF,to_char(ln.ENTDATE,'yyyyMMdd')  from lund.nominee_temp ln where POLNO=" + polno + "";
                if (dthRegObj02.existRecored(nomineeSelect) == 0)
                {
                    //this.lblassnom.Text = "No";
                }

                else
                {
                    this.Label3.Visible = true;
                    dthRegObj02.readSql(nomineeSelect);
                    OracleDataReader nomReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    this.CreateTbHeaderPreviousNominee();

                    while (nomReader.Read())
                    {
                        if (!nomReader.IsDBNull(0)) { pNIC = nomReader.GetString(0); } else { pNIC = "-"; }
                        if (!nomReader.IsDBNull(1)) { pnominame = nomReader.GetString(1); } else { pnominame = "-"; }
                        if (!nomReader.IsDBNull(2)) { ppercentage = Convert.ToDouble(nomReader[2]); } else { ppercentage = 0.0; }
                        if (!nomReader.IsDBNull(3)) { pEnterEPF = nomReader.GetString(3); } else { pEnterEPF = "-"; }
                        if (!nomReader.IsDBNull(3)) { pEDate = nomReader.GetString(4); } else { pEDate = "-"; }

                        if (pEDate != null || pEDate != "-")
                        {
                            npEDate = pEDate.ToString().Substring(0, 4) + "/" + pEDate.ToString().Substring(4, 2) +
                                             "/" + pEDate.ToString().Substring(6, 2);
                        }

                        this.createPreviousNomineeTable(pNIC, pnominame, ppercentage.ToString("0.00"), nomineeRow, pEnterEPF, npEDate);
                        nomineeRow++;
                    }
                    nomReader.Close();
                    nomReader.Dispose();
                }

                #endregion
                //...

                //-------------------- Showing Nominees -----------------------------------------------------------
                #region
                int nomRow = 0;
                string nEDate = "-", nADate = "-";
                int imaxEndosmentNum = 0;

                string maxEndosment = "select  * from lund.nominee ln left outer join LPHS.ENDORSE_POLICY_NONPREM lnt on ln.POLNO=lnt.POLICY_NO where ln.polno=" + polno + "";
                if (dthRegObj02.existRecored(maxEndosment) !=0)
                {
                    string maxEndosmentNum = "select nvl(max(ENDORSEMENT_NO),0) FROM LPHS.ENDORSE_POLICY_NONPREM where POLICY_NO=" + polno + "";

                    if (dthRegObj02.existRecored(maxEndosmentNum) != 0)
                    {
                        dthRegObj02.readSql(maxEndosmentNum);
                        OracleDataReader nomEndorsementReader =
                            dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (nomEndorsementReader.Read())
                        {
                            if (!nomEndorsementReader.IsDBNull(0))
                            {
                                imaxEndosmentNum = Convert.ToInt32(nomEndorsementReader[0]);
                            }
                        }
                        nomEndorsementReader.Close();
                        nomEndorsementReader.Dispose();
                    }

                    string nomSelect = "";

                    if (imaxEndosmentNum > 0)
                    {
                        nomSelect = "select  ln.NOMNIC ,ln.nomnam, ln.nomper,ln.ENTEPF,ln.ENTDATE, lnt.ENTRY_EPF,to_char(lnt.ENTRY_DATE,'yyyyMMdd') " +
                            "from lund.nominee ln left outer join LPHS.ENDORSE_POLICY_NONPREM lnt on ln.POLNO=lnt.POLICY_NO " +
                            "where ln.polno=" + polno + " and lnt.ENDORSEMENT_NO=" + imaxEndosmentNum + "";
                    }
                    else
                    {
                        nomSelect = "select  ln.NOMNIC ,ln.nomnam, ln.nomper,ln.ENTEPF,ln.ENTDATE, lnt.ENTRY_EPF,to_char(lnt.ENTRY_DATE,'yyyyMMdd') " +
                                    "from lund.nominee ln left outer join LPHS.ENDORSE_POLICY_NONPREM lnt on ln.POLNO=lnt.POLICY_NO " +
                                    "where ln.polno=" + polno + "";
                    }

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
                            if (!nomReader.IsDBNull(0)) { NIC = nomReader.GetString(0); } else { NIC = "-"; }
                            if (!nomReader.IsDBNull(1)) { nominame = nomReader.GetString(1); } else { nominame = "-"; }
                            if (!nomReader.IsDBNull(2)) { percentage = Convert.ToDouble(nomReader[2]); } else { percentage = 0.0; }
                            if (!nomReader.IsDBNull(3)) { EnterEPF = nomReader.GetString(3); } else { EnterEPF = "-"; }
                            if (!nomReader.IsDBNull(4)) { EDate = Convert.ToInt32(nomReader[4]); } else { EDate = 0; }
                            if (!nomReader.IsDBNull(5)) { AutEPF = Convert.ToInt32(nomReader[5]); } else { AutEPF = 0; }
                            if (!nomReader.IsDBNull(6)) { ADate = Convert.ToInt32(nomReader[6]); } else { ADate = 0; }
                            if (EDate > 0)
                            {
                                nEDate = EDate.ToString().Substring(0, 4) + "/" + EDate.ToString().Substring(4, 2) +
                                         "/" + EDate.ToString().Substring(6, 2);
                            }

                            if (ADate > 0)
                            {
                                nADate = ADate.ToString().Substring(0, 4) + "/" + ADate.ToString().Substring(4, 2) +
                                         "/" + ADate.ToString().Substring(6, 2);
                            }

                            this.createNomineeTable(NIC, nominame, percentage.ToString("0.00"), nomRow, EnterEPF,
                                nEDate, AutEPF.ToString(), nADate);
                            nomRow++;
                        }

                        nomReader.Close();
                        nomReader.Dispose();
                        //this.lblassnom.Text = "Yes";
                    }
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
                            // Task 24806
                            //if ((covernum == 202) || (covernum == 210) || (covernum == 211))
                            //{
                            //    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                            //    rows2++;
                            //    if (covernum == 202) ADB = coveramt;
                            //    else if (covernum == 210) SJ = coveramt;
                            //    else if ((table != 14) && (covernum == 111)) FE = coveramt;
                            //    else { }
                            //}

                            if (table == 46)
                            {
                                if ((covernum == 202) || (covernum == 204) || (covernum == 210) || (covernum == 211))
                                {
                                    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                    rows2++;
                                    if (covernum == 202) { ADB = coveramt; }
                                    else if (covernum == 204) { FPU = coveramt; }
                                    else if (covernum == 210) { SJ = coveramt; }
                                    else if ((table != 14) && (covernum == 111)) { FE = coveramt; }
                                }
                            }
                            else
                            {
                                if ((covernum == 202) || (covernum == 210) || (covernum == 211))
                                {
                                    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                    rows2++;
                                    if (covernum == 202) { ADB = coveramt; }
                                    else if (covernum == 210) { SJ = coveramt; }
                                    else if ((table != 14) && (covernum == 111)) { FE = coveramt; }
                                }
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

                string dthrefSelect = "select DRAGEADMIT, DRRINSYN, DRREVIVALS, DRVESTEDBON, DRINTERIMBON, DRBONSURRAMT, DRBONSURRYR, DRASSIGNEENOM,AGE_AMT,AGEDIFINRST,DRLONCAP,DRLOANINT,DRCLMNO from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "'";
                dthRegObj02.readSql(dthrefSelect);
                OracleDataReader dthrefreader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthrefreader.Read()) {
                    if(ageAdmitYN == "" || ageAdmitYN == null)
                    {
                        if (!dthrefreader.IsDBNull(0)) { ageAdmitYN = dthrefreader.GetString(0); } else { ageAdmitYN = ""; }
                    }
                    
                    if (!dthrefreader.IsDBNull(2)) { revivalsYN = dthrefreader.GetString(2); } else { revivalsYN = ""; }
                    if (!dthrefreader.IsDBNull(3)) { vestedBonus = dthrefreader.GetDouble(3); } else { vestedBonus = 0; }
                    if (!dthrefreader.IsDBNull(4)) { interimBonus = dthrefreader.GetDouble(4); } else { interimBonus = 0; }
                    if (!dthrefreader.IsDBNull(5)) { surrrenderedbons = dthrefreader.GetDouble(5); } else { surrrenderedbons = 0; }
                    if (!dthrefreader.IsDBNull(6)) { bonussurrYr = dthrefreader.GetInt32(6); } else { bonussurrYr = 0; }
                    //if (!dthrefreader.IsDBNull(7)) { assNomYN = dthrefreader.GetString(7); } else { assNomYN = ""; }
                    if (!dthrefreader.IsDBNull(8)) { ageAdmitAmt = dthrefreader.GetDouble(8); } else { ageAdmitAmt = 0.00; }//..add by buddhika 2009/03/23...
                    if (!dthrefreader.IsDBNull(9)) { ageAdmitAmtEntry = dthrefreader.GetDouble(9); } else { ageAdmitAmtEntry = 0.00; }//..add by buddhika 2009/04/7...
                    if (!dthrefreader.IsDBNull(10)) { loanAmt = dthrefreader.GetDouble(10); } else { loanAmt = 0.00; }// task 36202
                    if (!dthrefreader.IsDBNull(11)) { loanIntrest = dthrefreader.GetDouble(11); } else { loanIntrest = 0.00; }// task 36202
                }
                dthrefreader.Close();
                dthrefreader.Dispose();

                double totalBonus = vestedBonus + interimBonus - surrrenderedbons; 
                lblBonuses.Text = String.Format("{0:N}", vestedBonus + interimBonus);/////////////////*////////
                this.lbltotbons.Text = String.Format("{0:N}", totalBonus);
                if (ageAdmitYN.Equals("Y")) { this.lblageadmit.Text = "Yes"; }
                else { this.lblageadmit.Text = "No"; }
                if (revivalsYN.Equals("Y")) { this.lblrevivals.Text = "Yes"; }
                else { this.lblrevivals.Text = "No"; }
                //LbAgeAdminAmt.Text = String.Format("{0:N}", ageAdmitAmt);//..add by buddhika 2009/03/23...
                //LbAgeAmtInt.Text = String.Format("{0:N}", ageAdmitAmt);//..add by buddhika 2009/03/23...
                LbAgeAdminAmt.Text = String.Format("{0:N}", loanAmt);//task 36202
                LbAgeAmtInt.Text = String.Format("{0:N}", loanIntrest);//task 36202
                //if (assNomYN.Equals("Y")) { this.lblassnom.Text = "Yes"; }
                //else { this.lblassnom.Text = "No"; }
                #endregion

                #region ------------------ AML Designated List -----------------------------
                amlDesignated = new AMLDesignatedPerson();
                string AMLError = amlDesignated.Get_AMLDesignatedList(long.Parse(polno.ToString()), "R");

                if (AMLError.Length > 0)
                {
                    this.lblAMLDesignatedPersons.Text = AMLError;
                    lblAMLDesignatedPersons.Visible = true;
                }

                #endregion

                #region Check Same Day Payment Task 39176

                string checkSamePayment = "select LCPOL,to_char(to_date(LCDUE||'01','yyyyMMdd'),'yyyy/MM'),to_char(ENTRY_DATE,'YYYY-MM-DD HH:MI:SS AM') from lpay.lpaycom where LCPOL='" + polno + "' and LCPDT='" + dateofdeath + "'";
                if (dthRegObj02.existRecored(checkSamePayment) != 0)
                {
                    string paidTime = "";
                    string paidDue = "";
                    dthRegObj02.readSql(checkSamePayment);
                    OracleDataReader checkSamePaymentReader = dthRegObj02.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (checkSamePaymentReader.Read())
                    {
                        if (!checkSamePaymentReader.IsDBNull(1)) { paidDue = checkSamePaymentReader.GetString(1); }
                        if (!checkSamePaymentReader.IsDBNull(2)) { paidTime = checkSamePaymentReader.GetString(2); }

                        havePayment = 1;
                        havePaymentWarring = "Date of death and premium paid date of " + paidDue + " premium are same. Premium paid time " + paidTime + ".";
                        ViewState["havePayment"] = havePayment;
                        ViewState["havePaymentWarring"] = havePaymentWarring;

                        lblhasPayWarr.Text = havePaymentWarring;
                        lblhasPayWarr.ForeColor = System.Drawing.Color.Red;
                        pnlHavePayment.Visible = true;
                    }
                    checkSamePaymentReader.Close();
                    checkSamePaymentReader.Dispose();
                }
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
            //Common common = new Common();
            //thestate = common.is30DaysLaps(polno) ? "Lapsed" : "In force"; //is30DaysLap
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

    private void CreateTbHeaderPreviousNominee()
    {
        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc1 = new TableHeaderCell();
        TableHeaderCell thc2 = new TableHeaderCell();
        TableHeaderCell thc3 = new TableHeaderCell();

        TableHeaderCell thc4 = new TableHeaderCell();
        TableHeaderCell thc5 = new TableHeaderCell();
        TableHeaderCell thc6 = new TableHeaderCell();
        //TableHeaderCell thc7 = new TableHeaderCell();
        //TableHeaderCell thc8 = new TableHeaderCell();

        thc1.Text = "NIC";
        thc2.Text = "Name ";
        thc3.Text = "Percentage";
        //thc4.Text = "Address";
        thc5.Text = "Enterd User EPF";
        thc6.Text = "Date";
        //thc7.Text = "Authorized User EPF";
        //thc8.Text = "Date";

        thr.Cells.Add(thc1);
        thr.Cells.Add(thc2);
        thr.Cells.Add(thc3);
        //thr.Cells.Add(thc4);
        thr.Cells.Add(thc5);
        thr.Cells.Add(thc6);
        //thr.Cells.Add(thc7);
        //thr.Cells.Add(thc8);
        Table4.Rows.Add(thr);
    }

    private void createPreviousNomineeTable(string nic, string nominee, string percentage, int rowNumber, string eEPF, string edate)
    {
        TableRow trow = new TableRow();
        TableRow trow1 = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        //....
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        TableCell tcell6 = new TableCell();
        //TableCell tcell7 = new TableCell();
        //TableCell tcell8 = new TableCell();

        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        //.....
        Label lbl4 = new Label();
        Label lbl5 = new Label();
        Label lbl6 = new Label();
        //Label lbl7 = new Label();
        //Label lbl8 = new Label();

        lbl4.ID = "pNIC" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "pNIC" + rowNumber); //Text Value
        lbl4.Text = nic;

        lbl1.ID = "ppnominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "pnominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "ppercentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "ppercentage" + rowNumber); //Text Value
        lbl2.Text = percentage + "%";

        //lbl3.ID = "Address" + rowNumber;
        //lbl3.Attributes.Add("runat", "Server");
        //lbl3.Attributes.Add("Name", "Address" + rowNumber); //Text Value
        //lbl3.Text = Address ;

        //.....


        lbl5.ID = "pEnterEPF" + rowNumber;
        lbl5.Attributes.Add("runat", "Server");
        lbl5.Attributes.Add("Name", "pEnterEPF" + rowNumber); //Text Value
        lbl5.Text = eEPF;

        lbl6.ID = "pEDate" + rowNumber;
        lbl6.Attributes.Add("runat", "Server");
        lbl6.Attributes.Add("Name", "pEDate" + rowNumber); //Text Value
        lbl6.Text = edate;

        //lbl7.ID = "AutEPF" + rowNumber;
        //lbl7.Attributes.Add("runat", "Server");
        //lbl7.Attributes.Add("Name", "AutEPF" + rowNumber); //Text Value
        //lbl7.Text = aEPF;

        //lbl8.ID = "ADate" + rowNumber;
        //lbl8.Attributes.Add("runat", "Server");
        //lbl8.Attributes.Add("Name", "ADate" + rowNumber); //Text Value
        //lbl8.Text = aDate;


        tcell1.Controls.Add(lbl1);
        tcell1.CssClass = "nomNew";
        tcell2.Controls.Add(lbl2);
        // tcell3.Controls.Add(lbl3);
        //...
        tcell4.Controls.Add(lbl4);
        tcell5.Controls.Add(lbl5);
        tcell6.Controls.Add(lbl6);
        //tcell7.Controls.Add(lbl7);
        //tcell8.Controls.Add(lbl8);

        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        // trow.Cells.Add(tcell3);
        //...
        trow.Cells.Add(tcell5);
        trow.Cells.Add(tcell6);
        //trow.Cells.Add(tcell7);
        //trow.Cells.Add(tcell8);

        Table4.Rows.Add(trow);
        Table4.CssClass = "policyDetail";
        // Table2.Rows.Add(trow1);
    }

    //......

    private void CreateHeader()
    {
        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc1 = new TableHeaderCell();
        TableHeaderCell thc2 = new TableHeaderCell();
        TableHeaderCell thc3 = new TableHeaderCell();

        TableHeaderCell thc4 = new TableHeaderCell();
        TableHeaderCell thc5 = new TableHeaderCell();
        TableHeaderCell thc6 = new TableHeaderCell();
        TableHeaderCell thc7 = new TableHeaderCell();
        TableHeaderCell thc8 = new TableHeaderCell();
        thc1.Text = "NIC";
        thc2.Text = "Name ";
        thc3.Text = "Percentage";
        // thc4.Text = "Address";
        thc5.Text = "Enterd EPF";
        thc6.Text = "Enterd Date";
        thc7.Text = "Authorized EPF";
        thc8.Text = "Authorized Date";

        thr.Cells.Add(thc1);
        thr.Cells.Add(thc2);
        thr.Cells.Add(thc3);
        // thr.Cells.Add(thc4);
        thr.Cells.Add(thc5);
        thr.Cells.Add(thc6);
        thr.Cells.Add(thc7);
        thr.Cells.Add(thc8);
        Table2.Rows.Add(thr);
    }

    private void createNomineeTable(string nic, string nominee, string percentage, int rowNumber, string eEPF, string edate, string aEPF, string aDate)
    {
        TableRow trow = new TableRow();
        TableRow trow1 = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        //....
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        TableCell tcell6 = new TableCell();
        TableCell tcell7 = new TableCell();
        TableCell tcell8 = new TableCell();

        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        //.....
        Label lbl4 = new Label();
        Label lbl5 = new Label();
        Label lbl6 = new Label();
        Label lbl7 = new Label();
        Label lbl8 = new Label();

        lbl4.ID = "NIC" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "NIC" + rowNumber); //Text Value
        lbl4.Text = nic;

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "percentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value 
        lbl2.Text = percentage + "%"; 

        //lbl3.ID = "Address" + rowNumber;
        //lbl3.Attributes.Add("runat", "Server");
        //lbl3.Attributes.Add("Name", "Address" + rowNumber); //Text Value
        //lbl3.Text = Address;

        //.....


        lbl5.ID = "EnterEPF" + rowNumber;
        lbl5.Attributes.Add("runat", "Server");
        lbl5.Attributes.Add("Name", "EnterEPF" + rowNumber); //Text Value
        lbl5.Text = eEPF;

        lbl6.ID = "EDate" + rowNumber;
        lbl6.Attributes.Add("runat", "Server");
        lbl6.Attributes.Add("Name", "EDate" + rowNumber); //Text Value
        lbl6.Text = edate;

        lbl7.ID = "AutEPF" + rowNumber;
        lbl7.Attributes.Add("runat", "Server");
        lbl7.Attributes.Add("Name", "AutEPF" + rowNumber); //Text Value
        lbl7.Text = aEPF;

        lbl8.ID = "ADate" + rowNumber;
        lbl8.Attributes.Add("runat", "Server");
        lbl8.Attributes.Add("Name", "ADate" + rowNumber); //Text Value
        lbl8.Text = aDate;


        tcell1.Controls.Add(lbl1);
        tcell1.CssClass = "nomNew";
        tcell2.Controls.Add(lbl2);
        // tcell3.Controls.Add(lbl3);
        //...
        tcell4.Controls.Add(lbl4);
        tcell5.Controls.Add(lbl5);
        tcell6.Controls.Add(lbl6);
        tcell7.Controls.Add(lbl7);
        tcell8.Controls.Add(lbl8);

        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        // trow.Cells.Add(tcell3);
        //...
        trow.Cells.Add(tcell5);
        trow.Cells.Add(tcell6);
        trow.Cells.Add(tcell7);
        trow.Cells.Add(tcell8);

        Table2.Rows.Add(trow);
        Table2.CssClass = "policyDetail";
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
        tcell1.CssClass = "coverLeft";
        tcell2.Controls.Add(lbl2);
        tcell2.CssClass = "coverRight";
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        Table3.Rows.Add(trow);
        Table3.CssClass = "coverDetail";
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

    public double GetFullAge(string dOb, string regDat)
    {
        DateTime dateOfBirth;
        DateTime regDate;


        int year, month, date, year1, month1, date1, year2, month2, date2;
        double finalYear = 0, finalMonth = 0, finalDate = 0;

        year = 0;
        month1 = 0;
        date = 0;
        year1 = 0;
        month1 = 0;
        date1 = 0;
        year2 = 0;
        month2 = 0;
        date2 = 0;

        if (regDat.Trim().Length != 10 || dOb.Trim().Length != 10) return 0;

        regDate = DateTime.Parse(regDat.ToString());
        dateOfBirth = DateTime.Parse(dOb);

        year1 = regDate.Year;
        year2 = dateOfBirth.Year;
        month1 = regDate.Month;
        month2 = dateOfBirth.Month;
        date1 = regDate.Day;
        date2 = dateOfBirth.Day;

        //date calculation part

        if (date1 < date2)
        {
            date = (30 + date1) - date2;
            month1 = month1 - 1;
        }
        else
        {
            date = date1 - date2;
        }

        if (month1 < month2)
        {
            month = (month1 + 12) - month2;
            year1 = year1 - 1;
        }
        else
        {
            month = month1 - month2;
        }
        year = year1 - year2;

        //apply the normal date formulla

        if (date != 0) finalDate = (double)date / 365;
        if (month != 0) finalMonth = (double)month / 12;

        finalYear = year + finalMonth + finalDate;

        //if (month > 6)
        //{
        //    year = year + 1;

        //}
        //if (month == 6 && date >= 1)
        //    year = year + 1;

        return finalYear;

    }

}
