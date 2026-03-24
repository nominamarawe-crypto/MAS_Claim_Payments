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

public partial class dthReg002 : System.Web.UI.Page
{
    private int polno;
    private string MOF;
    private int dateofdeath;    
   
    private int dateofdeathDB;
    private int branch;
    private int infodat;
    private double infotel;
    private string polstat;
    private string nameOfDead;
    private string methofInfo;
    private string infoid;
    private string infoname;
    private string infoad1;
    private string infoad2;
    private string infoad3;
    private string infoad4;
    private string inforel;
    private long claimNo;
    private string cof;
    private double sumassured;
    private int table;
    private int term;
    private int dateofComm;
    private string phname = "";
    private string ad1 = "";
    private string ad2 = "";
    private string ad3 = "";
    private string ad4 = "";

    private string COD;
    private int POL;
    private int COM;
    private int TBL;
    private int TRM;
    private int SUM;
    private int MOD;
    private double PRM;
    private int DUE;
    private int PAC;
    private int AGT;
    private int ORG;
    private int BRN;
    private int OBR;
    private int PTR;

    private int LoanNum;
    private int rcptno;
    private double LMNCP_LMCPY;
    private double tempkkkkk;
    private double LMIPY01;
    private string EPF = "";
    private string nominame;
    private double percentage;
    private string Address;

    //******* variables for DTHREF ***************

    private long ADB;
    private long FPU;
    private long SJ;
    private long FE;
    private string ageAdmitYN = "";
    private double ageAdmitAmt = 0.0;//.....Add by buddhika 2009/03/23...
    private double ageEntryInter = 0.0;//...Add by buddhika 2009/04/07...
    private string revivalsYN = "";
    private string assNomYN = "";
    private string reinsYN = "";
    private double vestedBonus;
    private double interimBonus;
    private int interimBonStYR;
    private double surrrenderedbons;
    private int bonussurrYr;
    private double netsurrAmt;
    private int ageatentry;
    private double deposit;
    private string bonusurrYN = "";
    private double demmands;
    private double defint;
    private int bonuscount; 

    private int covernum ;
    private int coveramt;
    private int comdat;
    private int covterm;
    private int polDuraYrs, polDuraMnths, polDuraDays;
  
    private string confst = "";
    private int payautDt;

    double loanCapital = 0;
    double loaninterest = 0;

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

    DataManager dthRegObj;
    LoanBackCal loanbackobj;

    protected void Page_Load(object sender, EventArgs e)   
    {
        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            Response.Redirect("SessionError.aspx");       
        }


        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dateofdeath = this.PreviousPage.Dtaeofdeath;
        }
        if (!Page.IsPostBack)
        {
            dthRegObj = new DataManager();
            try
            {
                dateValidation dv = new dateValidation();
                if (!dv.dateValid(dateofdeath.ToString())) { throw new Exception("Invalid Date of Death"); }
                branch = int.Parse(Session["brcode"].ToString());
                //branch = 10;

                //int testInt = this.dateAdd(20070404, 0, 4, 3);

                #region  //------------- DTHINT ----------------
                string dthintSelect = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4, ditel, dinforel, dclm, dsta, dconfst, dcof from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "'  ";
                if (dthRegObj.existRecored(dthintSelect) == 0)
                {
                    dthRegObj.connclose();
                    throw new Exception("No Death Intimation Details!");
                }
                else
                {
                    dthRegObj.readSql(dthintSelect);
                    OracleDataReader dthintREADER = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintREADER.Read())
                    {
                        infodat = dthintREADER.GetInt32(0);
                        dateofdeathDB = dthintREADER.GetInt32(3);
                        if (dateofdeathDB == 0)
                        {
                            string dthintInsert = "update lphs.dthint set ddtofdth = " + dateofdeath + " where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=0 ";
                            dthRegObj.insertRecords(dthintInsert);
                        }
                        else if (dateofdeathDB != dateofdeath)
                        {
                            string dthintInsert = "update lphs.dthint set ddtofdth = " + dateofdeath + " where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=0 ";
                            dthRegObj.insertRecords(dthintInsert);
                            this.lbldatemismatch.Text = "Previously Given Date of Death doesn't Match with new One";
                        }
                        else { }

                        if (!dthintREADER.IsDBNull(11)) { infotel = dthintREADER.GetInt64(11); } else { infotel = 0; }
                        if (!dthintREADER.IsDBNull(1)) { polstat = dthintREADER.GetString(1); } else { polstat = ""; }
                        if (!dthintREADER.IsDBNull(2)) { nameOfDead = dthintREADER.GetString(2); } else { nameOfDead = ""; }
                        if (!dthintREADER.IsDBNull(4)) { methofInfo = dthintREADER.GetString(4); } else { methofInfo = ""; }
                        if (!dthintREADER.IsDBNull(5)) { infoid = dthintREADER.GetString(5); } else { infoid = ""; }
                        if (!dthintREADER.IsDBNull(6)) { infoname = dthintREADER.GetString(6); } else { infoname = ""; }
                        if (!dthintREADER.IsDBNull(7)) { infoad1 = dthintREADER.GetString(7); } else { infoad1 = ""; }
                        if (!dthintREADER.IsDBNull(8)) { infoad2 = dthintREADER.GetString(8); } else { infoad2 = ""; }
                        if (!dthintREADER.IsDBNull(9)) { infoad3 = dthintREADER.GetString(9); } else { infoad3 = ""; }
                        if (!dthintREADER.IsDBNull(10)) { infoad4 = dthintREADER.GetString(10); } else { infoad4 = ""; }
                        if (!dthintREADER.IsDBNull(12)) { inforel = dthintREADER.GetString(12); } else { inforel = ""; }
                        if (!dthintREADER.IsDBNull(13)) { claimNo = dthintREADER.GetInt64(13); } else { claimNo = 0; }
                        if (!dthintREADER.IsDBNull(15)) { confst = dthintREADER.GetString(15); } else { confst = ""; }
                        if (!dthintREADER.IsDBNull(16)) { cof = dthintREADER.GetString(16); } else { cof = ""; }
                    }
                    dthintREADER.Close();
                    dthintREADER.Dispose();
                }

                if (confst.Equals("Y")) { this.btnregister.Enabled = false; }
                else { this.btnregister.Enabled = true; }

                #endregion

                #region //----------- Generating claim no. ----

                //string dthrefhisSel = "SELECT DPOLNO, DMOS ,DCLM FROM LPHS.DTHINT WHERE (DPOLNO = " + polno + ") AND (DMOS = '" + MOF + "')";
                //if (dthRegObj.existRecored(dthrefhisSel) != 0)
                //{
                //    dthRegObj.readSql(dthrefhisSel);
                //    OracleDataReader dthrefhisReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    while (dthrefhisReader.Read())
                //    {
                //        if (!dthrefhisReader.IsDBNull(2))
                //        { claimNo = dthrefhisReader.GetInt32(2); }
                //        else
                //        { claimNo = 0; }
                //    }
                //    dthrefhisReader.Close();
                //    dthrefhisReader.Dispose();
                //}
                //if (claimNo == 0)
                //{
                //    //string dclmSelect = "select max(dclm) from lphs.dthint ";
                //    //dthRegObj.readSql(dclmSelect);
                //    //OracleDataReader clmnoReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    //while (clmnoReader.Read())
                //    //{
                //    //    claimNo = clmnoReader.GetInt32(0);
                //    //}
                //    //clmnoReader.Close();
                //    //clmnoReader.Dispose();
                //    string deathClaimNum = "SELECT * FROM LCLM.ARREFNO WHERE RCTYPE='D'";
                //    dthRegObj.readSql(deathClaimNum);
                //    OracleDataReader clmnoReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    while (clmnoReader.Read())
                //    {
                //        if (!clmnoReader.IsDBNull(2))
                //        {
                //            claimNo = clmnoReader.GetInt64(2);
                //            claimNo = claimNo + 1;
                //            string Update = "UPDATE LCLM.ARREFNO SET RCNO=" + claimNo + " WHERE RCTYPE='D'";
                //            dthRegObj.insertRecords(Update);
                //        }
                //    }
                //    clmnoReader.Close();
                //    clmnoReader.Dispose();
                //}

                //if (claimNo == 0)
                //{
                //    string dclmSelect = "select max(dclm) from lphs.dthint ";
                //    dthRegObj.readSql(dclmSelect);
                //    OracleDataReader clmnoReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    while (clmnoReader.Read())
                //    {
                //        claimNo = clmnoReader.GetInt32(0);
                //    }
                //    claimNo++;
                //}

                #endregion

                #region-------Display Values--------------
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
                this.txtdtofdth.Text = dateofdeath.ToString();
                this.lbldtofintim.Text = infodat.ToString();
                //this.lblpolstat.Text = polstate(polstat);
                this.txtclmno.Text = claimNo.ToString();
                if (cof.Equals("C")) { this.lblcof.Text = "CIVIL"; }
                else if (cof.Equals("A")) { this.lblcof.Text = "ARMY"; }
                else if (cof.Equals("N")) { this.lblcof.Text = "NAVY"; }
                else if (cof.Equals("G")) { this.lblcof.Text = "AIR FORCE"; }
                else if (cof.Equals("B")) { this.lblcof.Text = "BUDDHIST CLERGY"; }
                #endregion

                #region   // ************** PHNAME  *******************************************
                string phname1 = "", phname2 = "", phname3 = "";

                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                if (dthRegObj.existRecored(sql) != 0)
                {
                    dthRegObj.readSql(sql);
                    OracleDataReader oraDtReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (oraDtReader.Read())
                    {
                        if (!oraDtReader.IsDBNull(0))
                        {
                            phname1 = oraDtReader.GetString(0);
                        }
                        if (!oraDtReader.IsDBNull(1))
                        {
                            phname2 = oraDtReader.GetString(1);
                        }
                        if (!oraDtReader.IsDBNull(2))
                        {
                            phname3 = oraDtReader.GetString(2);
                        }
                        phname = phname1 + "" + phname2 + "" + phname3;
                        //else { phname = ""; }
                        if (!oraDtReader.IsDBNull(3)) { ad1 = (oraDtReader.GetString(3)); } else { ad1 = ""; }
                        if (!oraDtReader.IsDBNull(4)) { ad2 = (oraDtReader.GetString(4)); } else { ad2 = ""; }
                        if (!oraDtReader.IsDBNull(5)) { ad3 = (oraDtReader.GetString(5)); } else { ad3 = ""; }
                        if (!oraDtReader.IsDBNull(6)) { ad4 = (oraDtReader.GetString(6)); } else { ad4 = ""; }

                    }
                    oraDtReader.Close();
                    oraDtReader.Dispose();
                }
                else
                {
                    phname = ""; ad1 = ""; ad2 = ""; ad3 = ""; ad4 = "";
                }
                this.lblnameofInsured.Text = phname;
                this.lblassuredad1.Text = ad1 + " " + ad2;
                this.lblassuredad2.Text = ad3 + " " + ad4;

                //******************************* AGE AT ENTRY ******************************************************
                //Task 36304
                if(MOF.Equals("M") || MOF.Equals("S"))
                {
                    string agesql = "";
                    if (MOF.Equals("M"))
                    {
                        agesql = "select age,ageproof from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=1";
                    }
                    else if (MOF.Equals("S"))
                    {
                        agesql = "select age,ageproof from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=2 union " +
                               "select age,ageproof from LUND.POLPERSONAL_HISTORY where polno='" + polno + "' and prpertype=2 and " +
                               "SQNO = (select MAX(SQNO) from LUND.POLPERSONAL_HISTORY where polno='" + polno + "' and prpertype = 2 )";
                    }
                    dthRegObj.readSql(agesql);
                    OracleDataReader valfilereader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (valfilereader.Read())
                    {
                        if (!valfilereader.IsDBNull(0)) { ageatentry = valfilereader.GetInt32(0); } else { ageatentry = 0; }
                        if (!valfilereader.IsDBNull(1)) { ageAdmitYN = valfilereader.GetString(1); } else { ageAdmitYN = ""; }

                    }
                    valfilereader.Close();
                    valfilereader.Dispose();
                }
                

                //-----------------------------------------------------------------------------------------------

                #endregion

                #region   //------------ Policy History --------????????!!!!!!!!

                string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue, pmmod from lphs.premast where pmpol=" + polno + " ";
                string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, lpmod from lphs.liflaps where lppol=" + polno + " ";
                string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phsta, phmod from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                if (dthRegObj.existRecored(premastSelect) != 0)
                {
                    dthRegObj.readSql(premastSelect);
                    OracleDataReader premReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    premReader.Read();
                    if (!premReader.IsDBNull(0)) { sumassured = premReader.GetDouble(0); } else { sumassured = 0; }
                    if (!premReader.IsDBNull(1)) { table = premReader.GetInt32(1); } else { table = 0; }
                    if (!premReader.IsDBNull(2)) { term = premReader.GetInt32(2); } else { term = 0; }
                    if (!premReader.IsDBNull(3)) { dateofComm = premReader.GetInt32(3); } else { dateofComm = 0; }
                    if (!premReader.IsDBNull(4)) { DUE = premReader.GetInt32(4); } else { DUE = 0; }
                    if (!premReader.IsDBNull(5)) { MOD = premReader.GetInt32(5); } else { MOD = 0; }

                    //polstat = "I";
                    premReader.Close();
                    premReader.Dispose();
                    //this.btnregister.Enabled = true;
                }
                else if (dthRegObj.existRecored(liflapsSelect) != 0)
                {
                    dthRegObj.readSql(liflapsSelect);
                    OracleDataReader lapsReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    lapsReader.Read();
                    if (!lapsReader.IsDBNull(0)) { sumassured = lapsReader.GetDouble(0); } else { sumassured = 0; }
                    if (!lapsReader.IsDBNull(1)) { table = lapsReader.GetInt32(1); } else { table = 0; }
                    if (!lapsReader.IsDBNull(2)) { term = lapsReader.GetInt32(2); } else { term = 0; }
                    if (!lapsReader.IsDBNull(3)) { dateofComm = lapsReader.GetInt32(3); } else { dateofComm = 0; }
                    if (!lapsReader.IsDBNull(4)) { DUE = lapsReader.GetInt32(4); } else { DUE = 0; }
                    if (!lapsReader.IsDBNull(5)) { MOD = lapsReader.GetInt32(5); } else { MOD = 0; }
                    //polstat = "L";
                    lapsReader.Close();
                    lapsReader.Dispose();
                    //this.btnregister.Enabled = true;
                }
                else if (dthRegObj.existRecored(polhisSelect) != 0)
                {
                    //**** this is for just diapalying registered details that is registration  already done and
                    // this page is requested for reprint purposes

                    dthRegObj.readSql(polhisSelect);
                    OracleDataReader polhisReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    polhisReader.Read();
                    if (!polhisReader.IsDBNull(0)) { sumassured = polhisReader.GetDouble(0); } else { sumassured = 0; }
                    if (!polhisReader.IsDBNull(1)) { table = polhisReader.GetInt32(1); } else { table = 0; }
                    if (!polhisReader.IsDBNull(2)) { term = polhisReader.GetInt32(2); } else { term = 0; }
                    if (!polhisReader.IsDBNull(3)) { dateofComm = polhisReader.GetInt32(3); } else { dateofComm = 0; }
                    if (!polhisReader.IsDBNull(4)) { DUE = polhisReader.GetInt32(4); } else { DUE = 0; }
                    //if (!polhisReader.IsDBNull(5)) { polstat = polhisReader.GetString(5); } else { polstat = ""; }
                    if (!polhisReader.IsDBNull(6)) { MOD = polhisReader.GetInt32(6); } else { MOD = 0; }
                    polhisReader.Close();
                    polhisReader.Dispose();
                    //this.btnregister.Enabled = false;
                }
                else
                {
                    dthRegObj.connclose();
                    throw new Exception("No Policy Details!");
                }

                this.lbldtofexit.Text = DUE.ToString().Substring(0, 4) + "/" + DUE.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);

                #region------------Update Policy Status------------------------
                General gg = new General();
                polstat = gg.LapsetoInforce(polno, dateofdeath, dthRegObj);
                string dthintupdate = "update LPHS.DTHINT set DPOLST='" + polstat + "' where DPOLNO=" + polno + " and DMOS='" + MOF + "'";
                dthRegObj.insertRecords(dthintupdate);
                #endregion

                this.lblpolstat.Text = polstate(polstat);
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
                    //    //dthRegObj.connclose();
                    //    throw new Exception("Policy Lapsed After the date of Death!");
                    //}
                }

                this.lblpolicyDuratn.Text = polDuraYrs.ToString() + " Yrs " + polDuraMnths.ToString() + " Months";

                #endregion

                #region//--- validating life type availability ---
                string MAIN_LIFE = "", SPOUCE = "", SECOND_LIFE = "", CHILD = "", IS_CHILD="";
                string tabcoversel = "select MAIN_LIFE, SPOUCE, SECOND_LIFE, CHILD,IS_CHILD_SECOND_LIFE from LUND.TAB_COVERS where TAB_ID = " + table + "  ";
                if (dthRegObj.existRecored(tabcoversel) != 0)
                {
                    dthRegObj.readSql(tabcoversel);
                    OracleDataReader tabcoverReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (tabcoverReader.Read()) 
                    {
                        if (!tabcoverReader.IsDBNull(0)) { MAIN_LIFE = tabcoverReader.GetString(0); } else { MAIN_LIFE = ""; }
                        if (!tabcoverReader.IsDBNull(1)) { SPOUCE = tabcoverReader.GetString(1); } else { SPOUCE = ""; }
                        if (!tabcoverReader.IsDBNull(2)) { SECOND_LIFE = tabcoverReader.GetString(2); } else { SECOND_LIFE = ""; }
                        if (!tabcoverReader.IsDBNull(3)) { CHILD = tabcoverReader.GetString(3); } else { CHILD = ""; }
                        if (!tabcoverReader.IsDBNull(4)) { IS_CHILD = tabcoverReader.GetString(4); } else { IS_CHILD = ""; }
                    }
                    tabcoverReader.Close();
                    tabcoverReader.Dispose();

                    if (MOF.Equals("M") && MAIN_LIFE.Equals("N")) { throw new Exception("This Life Type is not Available for this Table"); }
                    else if (MOF.Equals("S") && SPOUCE.Equals("N")) { throw new Exception("This Life Type is not Available for this Table"); }
                    //else if (MOF.Equals("2") && (SECOND_LIFE.Equals("N") || CHILD.Equals("N"))) { throw new Exception("This Life Type is not Available for this Table"); }
                    else if ((MOF.Equals("2") && SECOND_LIFE.Equals("N")) && (MOF.Equals("2") && IS_CHILD.Equals("N"))) { throw new Exception("This Life Type is not Available for this Table"); }
                    else if ((MOF.Equals("C") && CHILD.Equals("N"))&& (MOF.Equals("C") && IS_CHILD.Equals("Y"))) { throw new Exception("This Life Type is not Available for this Table"); }
                }
                #endregion

                #region//----- calculating Age at Death -------
                if (MOF.Equals("M") || MOF.Equals("S")) //Task 36304
                {
                    int duratn = int.Parse(this.setDate()[0].Substring(0, 4)) - int.Parse(dateofComm.ToString().Substring(0, 4));
                    int mnthdiff = int.Parse(this.setDate()[0].Substring(4, 2)) - int.Parse(dateofComm.ToString().Substring(4, 2));
                    if (mnthdiff > 6) { duratn++; }
                    else if (mnthdiff < -6) { duratn--; }
                   
                    this.lblageatentstr.Visible = true;
                    this.lblageatentry.Visible = true;
                    this.lblageatdthstr.Visible = true;
                    this.lblageatdth.Visible = true;
                    this.lblageatentry.Text = ageatentry.ToString();
                    int addtoAgeAtEntry = this.dateComparison(dateofComm, dateofdeath)[0];
                    //this.lblageatdth.Text = (ageatentry + duratn).ToString();
                    this.lblageatdth.Text = (ageatentry + addtoAgeAtEntry).ToString();
                }
                #endregion
                this.lblsumassured.Text = "Rs."+String.Format("{0:N}", sumassured);
                this.lbltab.Text = table.ToString();
                this.lblterm.Text = term.ToString();
                this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);

                bool existflag = false;

                #region    //---------- DTHREF -----------------
                string payee = "";
                string dthrefSel = "select DRAGEADMIT, DRRINSYN, DRREVIVALS, DRASSIGNEENOM, PAYEE, PAYAUTDT, DRBONSURRAMT, DRBONSURRYR,AGE_AMT,AGEDIFINRST from LPHS.DTHREF  where drpolno=" + polno + " and drmos='" + MOF + "' ";
                if (dthRegObj.existRecored(dthrefSel) != 0)
                {
                    existflag = true;
                    dthRegObj.readSql(dthrefSel);
                    OracleDataReader dthrefreader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefreader.Read())
                    {
                        if (!dthrefreader.IsDBNull(0)) { ageAdmitYN = dthrefreader.GetString(0); } else { ageAdmitYN = ""; }
                        if (!dthrefreader.IsDBNull(2)) { revivalsYN = dthrefreader.GetString(2); } else { revivalsYN = ""; }
                        if (!dthrefreader.IsDBNull(3)) { assNomYN = dthrefreader.GetString(3); } else { assNomYN = ""; }
                        if (!dthrefreader.IsDBNull(4)) { payee = dthrefreader.GetString(4); } else { payee = ""; }
                        if (!dthrefreader.IsDBNull(5)) { payautDt = dthrefreader.GetInt32(5); } else { payautDt = 0; }
                        if (!dthrefreader.IsDBNull(6)) { surrrenderedbons = dthrefreader.GetDouble(6); } else { surrrenderedbons = 0; }
                        if (!dthrefreader.IsDBNull(7)) { bonussurrYr = dthrefreader.GetInt32(7); } else { bonussurrYr = 0; }
                        if (!dthrefreader.IsDBNull(8)) { ageAdmitAmt = dthrefreader.GetDouble(8); TxtAgeEntry.Text = String.Format("{0:N}", ageAdmitAmt); } else { ageAdmitAmt = 0; }//...add by buddhika 2009/03/23....
                        if (!dthrefreader.IsDBNull(9)) { ageEntryInter = dthrefreader.GetDouble(9); TxtAgeEntryInter.Text = String.Format("{0:N}", ageEntryInter); } else { ageEntryInter = 0; }//...add by buddhika 2009/04/7....
                    }
                    dthrefreader.Close();
                    dthrefreader.Dispose();
                }

                #endregion+.
                
                // validating the spouce cover availability
                //if ((TBL == 42 || TBL == 45 || TBL == 34) && (MOF.Equals("S"))) { throw new Exception("Tables 45, 42, 34 Does not consist Spouce Cover"); }
                //if ((TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) && (MOF.Equals("C"))) { throw new Exception("No Child Cover for tables other than 34, 38, 39, 46, 49"); }
                if ((table == 42 || table == 45 || table == 34) && (MOF.Equals("S"))) { throw new Exception("Tables 45, 42, 34 Does not consist Spouce Cover"); }
                if ((table != 34 && table != 38 && table != 39 && table != 46 && table != 49) && (MOF.Equals("C"))) { throw new Exception("No Child Cover for tables other than 34, 38, 39, 46, 49"); }


                #region //--------- drop down lists and buttons ----

                if (ageAdmitYN.Equals("Y"))
                {
                    this.ddlageadmit.Items.Add(new ListItem("Yes", "Y"));
                    this.ddlageadmit.Enabled = false;
                    TxtAgeEntry.ReadOnly = false;//..add by buddhika 2009/03/23....
                    TxtAgeEntryInter.ReadOnly = false;//..add by buddhika 2009/04/07....
                }
                else if (ageAdmitYN.Equals("N"))
                {
                    this.ddlageadmit.Items.Add(new ListItem("No", "N"));
                    this.ddlageadmit.Enabled = false;
                    TxtAgeEntry.ReadOnly = true;//...add by buddhika 2009/03/23....
                    TxtAgeEntryInter.ReadOnly = true;//...add by buddhika 2009/04/7....
                }
                else
                {
                    this.ddlageadmit.Items.Add(new ListItem("Yes", "Y"));
                    this.ddlageadmit.Items.Add(new ListItem("No", "N"));
                }

                if (assNomYN.Equals("Y"))
                {
                    //this.ddlassnomYN.Items.Add(new ListItem("Yes", "Y"));
                    //this.ddlassnomYN.Enabled = false;
                }
                else if (assNomYN.Equals("N"))
                {
                    //this.ddlassnomYN.Items.Add(new ListItem("No", "N"));
                    //this.ddlassnomYN.Enabled = false;
                }
                else
                {
                    //this.ddlassnomYN.Items.Add(new ListItem("No", "N"));
                    //this.ddlassnomYN.Items.Add(new ListItem("Yes", "Y"));
                    //this.ddlassnomYN.Enabled = true;
                }

                if (revivalsYN.Equals("Y"))
                {
                    this.ddlrinsYN.Items.Add(new ListItem("Yes", "Y"));
                    this.ddlrinsYN.Enabled = false;
                }
                else if (revivalsYN.Equals("N"))
                {
                    this.ddlrinsYN.Items.Add(new ListItem("No", "N"));
                    this.ddlrinsYN.Enabled = false;
                }
                else
                {
                    this.ddlrinsYN.Items.Add(new ListItem("No", "N"));
                    this.ddlrinsYN.Items.Add(new ListItem("Yes", "Y"));
                }

                //--- surrenders ---
                if (existflag && bonusurrYN != null && bonusurrYN.Equals("Y"))
                {
                    //this.ddlbonsurrYN.Items.Add(new ListItem("Yes", "Y"));
                    this.ddlbonsurrYN.SelectedIndex = 1;
                    this.ddlbonsurrYN.Enabled = false;
                    this.txtbonsurryr.Text = bonussurrYr.ToString();
                    this.txtbonsurryr.ReadOnly = true;
                    //this.txtclmno.ReadOnly = true;
                }
                else if (existflag) 
                {
                    this.ddlbonsurrYN.SelectedIndex = 0;
                    this.ddlbonsurrYN.Enabled = false;                
                    this.txtbonsurryr.ReadOnly = true;
                    //this.txtclmno.ReadOnly = true;
                }
                else if (!existflag)
                {
                    //this.ddlbonsurrYN.Items.Add(new ListItem("No", "N"));
                    //this.ddlbonsurrYN.Items.Add(new ListItem("Yes", "Y"));
                    this.txtbonsurryr.Text = "";
                    this.txtbonsurryr.ReadOnly = false;
                    //this.txtclmno.ReadOnly = false;
                }

                //....................change on 2008/04/21.....Testing Form 2008/04/16
                //this.ddlrinsYN.Items.Add(new ListItem("No", "N"));
                //this.ddlrinsYN.Items.Add(new ListItem("Yes", "Y"));

                #endregion

                //--------------------------- Showing Loans -------------------------------------------------------
                #region
                string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1  from lphs.lplmast where lmpol=" + polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                int caldate = int.Parse(this.setDate()[0]);
                dthRegObj.readSql(loansql);
                OracleDataReader myloanreader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                int rows = 0;
                double loantotal = 0;
                double loaninttot = 0;

                while (myloanreader.Read())
                {
                    double[] arr = new double[9];

                    int lmpdt = 0;
                    int lmnid = 0;
                    int lmlrd = 0;
                    double lmpit = 0;
                    double lmnit = 0;
                    double lmpcp = 0;
                    double lmncp = 0;
                    double lmipy = 0;
                    double lmcpy = 0;
                    double lmitr = 0;
                    double lmcit = 0;
                    double lmccp = 0;
                    int lmcdt = 0;
                    int lmmdt = 0;

                    if (!myloanreader.IsDBNull(0)) { LoanNum = myloanreader.GetInt32(0); }
                    if (!myloanreader.IsDBNull(1)) { lmpdt = myloanreader.GetInt32(1); }
                    if (!myloanreader.IsDBNull(2)) { lmnid = myloanreader.GetInt32(2); }
                    if (!myloanreader.IsDBNull(3)) { lmlrd = myloanreader.GetInt32(3); }
                    if (!myloanreader.IsDBNull(4)) { lmpit = myloanreader.GetDouble(4); }
                    if (!myloanreader.IsDBNull(5)) { lmnit = myloanreader.GetDouble(5); }
                    if (!myloanreader.IsDBNull(6)) { lmpcp = myloanreader.GetDouble(6); }
                    if (!myloanreader.IsDBNull(7)) { lmncp = myloanreader.GetDouble(7); }
                    if (!myloanreader.IsDBNull(8)) { lmipy = myloanreader.GetDouble(8); }
                    if (!myloanreader.IsDBNull(9)) { lmcpy = myloanreader.GetDouble(9); }
                    if (!myloanreader.IsDBNull(10)) { lmitr = myloanreader.GetDouble(10); }
                    if (!myloanreader.IsDBNull(11)) { lmcit = myloanreader.GetDouble(11); }
                    if (!myloanreader.IsDBNull(12)) { lmccp = myloanreader.GetDouble(12); }
                    if (!myloanreader.IsDBNull(13)) { lmcdt = myloanreader.GetInt32(13); }
                    if (!myloanreader.IsDBNull(14)) { lmmdt = myloanreader.GetInt32(14); }

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



                    if ((!lmset.Equals("Y")) && (!(lmcd1.Equals("D"))))
                    {
                        this.Label1.Visible = true;
                        try
                        {
                            //arr = loanCalculation.calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, caldate);

                            //loantotal += arr[5];
                            //loaninttot += arr[8];

                            //loanCapital = arr[5];
                            //loaninterest = arr[8];
                            
                                
                            loanbackobj = new LoanBackCal(polno, dateofdeath, LoanNum);
                                loanCapital += loanbackobj.Loancap;
                                loaninterest += loanbackobj.Backinterest;
                        }
                        catch (Exception ex)
                        {
                            this.lblmessage.Text = ex.Message.ToString();
                            loantotal = 0;
                            loaninttot = 0;
                        }

                        //------------- Back Calculation Algorithm Applied 20070802 ------------

                        //double temploanCapital = loanCapital;
                        //loanCapital = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, loanCapital, ((double)lmitr / 200), lmpdt, lmpit)[0];
                        //loaninterest = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, temploanCapital, ((double)lmitr / 200), lmpdt, lmpit)[1];
                        //temploanCapital = loanCapital - loaninterest;

                        rows++;
                        if (rows == 1)
                        {
                            this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", (rows - 1));
                            this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                        }
                        else
                        {
                            this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                        }
                    }
                }                
                myloanreader.Close();

                #endregion
                //--------------------------- Showing Nominees ----------------------------------------------------
                #region
                int nomRow = 0;
                string nomSelect = "select nomnam, nomper,NOMAD1 || ' '  || NOMAD2 as NOMAD1 from lund.nominee where polno=" + polno + "";
                if (dthRegObj.existRecored(nomSelect) != 0)
                {
                    this.Label2.Visible = true;
                    dthRegObj.readSql(nomSelect);
                    OracleDataReader nomReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    this.CreateTbHeader();
                    while (nomReader.Read())
                    {
                        if (!nomReader.IsDBNull(0)) { nominame = nomReader.GetString(0); }
                        if (!nomReader.IsDBNull(1)) { percentage = nomReader.GetDouble(1); }
                        if (!nomReader.IsDBNull(2)) { Address = nomReader.GetString(2); }

                        this.createNomineeTable(nominame, percentage.ToString(), nomRow,Address);
                        nomRow++;
                    }
                    nomReader.Close();
                    nomReader.Dispose();
                    //this.ddlassnomYN.SelectedIndex = 1;
                }

                #endregion
                //--------------------------- Showing Rider Covers ------------------------------------------------
                #region

                string covername = "";
                int rows2 = 0;
                bool covervalid = false;
                string rcoverSelect = "select rcovr, rsumas, rcomdat, rterm from lund.rcover where rpol=" + polno + " ";
                if (dthRegObj.existRecored(rcoverSelect) == 0)
                {
                    //  this.btnaddcover.Visible = true;
                }
                else
                {
                    dthRegObj.readSql(rcoverSelect);
                    OracleDataReader rcoverReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rcoverReader.Read())
                    {
                        if (!rcoverReader.IsDBNull(0)) { covernum = rcoverReader.GetInt32(0); } else { covernum = 0; }
                        if (!rcoverReader.IsDBNull(1)) { coveramt = rcoverReader.GetInt32(1); } else { coveramt = 0; }
                        if (!rcoverReader.IsDBNull(2)) { comdat = rcoverReader.GetInt32(2); } else { comdat = 0; }
                        if (!rcoverReader.IsDBNull(3)) { covterm = rcoverReader.GetInt32(3); } else { covterm = 0; }

                        int covrExpire = int.Parse((int.Parse(dateofComm.ToString().Substring(0, 4)) + covterm).ToString() + dateofComm.ToString().Substring(4, 4));
                        if (covrExpire > dateofdeath)
                        {
                            string covernameSelect = "select rconam from lund.rcovrnam where rconum=" + covernum + " ";
                            dthRegObj.readSql(covernameSelect);
                            OracleDataReader coverNameReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (coverNameReader.Read())
                            {
                                if (!coverNameReader.IsDBNull(0)) { covername = coverNameReader.GetString(0); }
                            }
                            //coverNameReader.Close();
                            //coverNameReader.Dispose();

                            if ((MOF.Equals("M")) && (covernum.ToString().Length <= 2))
                            {
                                if ((covernum == 2) || (covernum == 4) || (covernum == 10) || (covernum == 11))
                                {
                                    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                    rows2++;

                                    if (covernum == 2) { ADB = coveramt; }
                                    else if (covernum == 4) { FPU = coveramt; }
                                    else if (covernum == 10) { SJ = coveramt; }
                                    else { FE = coveramt; }
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
                                        if (covernum == 102) { ADB = coveramt; }
                                        else if (covernum == 110) { SJ = coveramt; }
                                        else if ((table != 14) && (covernum == 111)) { FE = coveramt; }
                                        else { }
                                    }
                                }
                                else
                                {
                                    if ((covernum == 102) || (covernum == 110) || (covernum == 111))
                                    {
                                        this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                        rows2++;
                                        if (covernum == 102) { ADB = coveramt; }
                                        else if (covernum == 110) { SJ = coveramt; }
                                        else { FE = coveramt; }
                                    }
                                }
                            }
                            else if ((MOF.Equals("2")) && (covernum.ToString().Length > 2) && (int.Parse(covernum.ToString().Substring(0, 1)) > 1))
                            {
                                if ((covernum == 202) || (covernum == 210) || (covernum == 211))
                                {
                                    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                    rows2++;
                                    if (covernum == 202) { ADB = coveramt; }
                                    else if (covernum == 210) { SJ = coveramt; }
                                    else if ((table != 14) && (covernum == 111)) { FE = coveramt; }
                                    else { }
                                }
                            }
                            else 
                            {
                                //??????????????????????????????????????????????????????????????????????????????????????????????
                            }
                        }
                    }
                    rcoverReader.Close();
                    rcoverReader.Dispose();
                    if (MOF.Equals("M")) { this.lblcoverfor.Text = "Rider Benefits For Main Life"; }
                    else if (MOF.Equals("S")) { this.lblcoverfor.Text = "Rider Benefits For Spouse"; }
                    else { this.lblcoverfor.Text = "Rider Benefits For Second Life"; }

                }
                #endregion
                //--------------------------- showing reinsurance -------------------------------------------------
                #region

                string LREINSURselect = "select * from lphs.lreinsur where ripolno=" + polno + "";
                if (dthRegObj.existRecored(LREINSURselect) != 0)
                {
                    this.lblreinsyn.Text = "Yes";
                    reinsYN = "Y";
                }
                else
                {
                    this.lblreinsyn.Text = "No";
                    reinsYN = "N";
                }

                #endregion
                //--------------------------- Viewing Deposites ---------------------------------------------------
                #region
                DataManager deposits = new DataManager();
                string depositsql = "select DPTAM from lpay.deposit where DPPOL=" + polno + " and dpdel <> 1 and DPTAM > 0 ";
                deposits.readSql(depositsql);
                OracleDataReader depositreader = deposits.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                double tempDepo = 0;
                while (depositreader.Read())
                {
                    double depamount = 0;
                    if (!depositreader.IsDBNull(0)) { depamount = depositreader.GetDouble(0); }
                    tempDepo += depamount;
                }
                depositreader.Close();
                depositreader.Dispose();
                deposit = tempDepo;
                this.lbldeposits.Text = "Rs."+String.Format("{0:N}", deposit);
                #endregion
                //--------------------------- vested Bonus ----------------------------------------????????????????
                #region
                if (MOF.Equals("M"))
                {
                    double totbonus = 0;
                    int interimboncount = 0;
                    int yeardiff = 0;
                    int monthdiff = 0;
                    int lastpaymentY = 0;
                    //int lastpaymentm = 0;
                    //int exityear = 0;

                    int DCOym = int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                    if (polstat.Equals("I"))
                    {
                        yeardiff = int.Parse(dateofdeath.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                        //yeardiff = this.dateComparison(dateofComm, dateofdeath)[0];
                    }
                    else if (polstat.Equals("L"))
                    {
                        //yeardiff = int.Parse(DUE.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                        int multiplier = 0;
                        if (MOD == 1) { multiplier = 12; }
                        else if (MOD == 2) { multiplier = 6; }
                        else if (MOD == 3) { multiplier = 3; }
                        else if (MOD == 4) { multiplier = 1; }

                        // commented on 20071220
                        //int lastpaymentYM = 0;

                        //if (DUE > 0)
                        //{
                        //    lastpaymentY = int.Parse(DUE.ToString().Substring(0, 4));
                        //    //exityear = lastpaymentY;
                        //    lastpaymentm = int.Parse(DUE.ToString().Substring(4, 2));
                        //    lastpaymentm -= multiplier;
                        //    if (lastpaymentm <= 0) { lastpaymentm += 12; lastpaymentY--; }
                        //    if (lastpaymentm < 10) { lastpaymentYM = int.Parse(lastpaymentY.ToString() + "0" + lastpaymentm.ToString()); }
                        //    else { lastpaymentYM = int.Parse(lastpaymentY.ToString() + lastpaymentm.ToString()); }
                        //}

                        //yeardiff = this.dateComparison(dateofComm, int.Parse(lastpaymentYM.ToString() + dateofComm.ToString().Substring(6, 2)))[0];
                        //monthdiff = this.dateComparison(dateofComm, int.Parse(lastpaymentYM.ToString() + dateofComm.ToString().Substring(6, 2)))[1];

                        //lastpaymentY = int.Parse(DUE.ToString().Substring(0, 4)) - 1;

                        lastpaymentY = int.Parse(dateofComm.ToString().Substring(0, 4)) + polDuraYrs - 1;

                        yeardiff = this.dateComparison(dateofComm, int.Parse(DUE.ToString() + dateofComm.ToString().Substring(6, 2)))[0];
                        monthdiff = this.dateComparison(dateofComm, int.Parse(DUE.ToString() + dateofComm.ToString().Substring(6, 2)))[1];

                    }
                    else { }
                    bool flag = false;

                    //----- excluding bonus not declared years ----

                    //bonuscount = lastpaymentY - int.Parse(dateofComm.ToString().Substring(0, 4));
                    bonuscount = yeardiff;
                    if (polstat.Equals("L"))
                    {
                        if (lastpaymentY == 1963 || lastpaymentY == 1967 || lastpaymentY == 1972 || lastpaymentY == 1974 || lastpaymentY == 1976 || lastpaymentY == 1981 || lastpaymentY == 1984 || lastpaymentY == 1986 || lastpaymentY == 1989 || lastpaymentY == 1991 || lastpaymentY == 1996)
                        {
                            if (int.Parse(DUE.ToString().Substring(0, 4)) < (int.Parse(dateofComm.ToString().Substring(0, 4)) + polDuraYrs)) { bonuscount--; }
                        }
                        else if (lastpaymentY == 1964 || lastpaymentY == 1968 || lastpaymentY == 1977 || lastpaymentY == 1982 || lastpaymentY == 1987) { bonuscount -= 2; }
                        else if (lastpaymentY == 1965 || lastpaymentY == 1969 || lastpaymentY == 1978) { bonuscount -= 3; }
                        else if (lastpaymentY == 1970 || lastpaymentY == 1979) { bonuscount -= 4; }
                    }

                    string incrementcountstr = "";
                    string incrementcountstrdclr = "";
                    int i;
                    double temp = 0;
                    if (bonuscount > 0)
                    {
                        for (i = 1; i < (bonuscount + 1); i++)
                        {
                            if (i < 10)
                            {
                                incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                            }
                            else
                            {
                                incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                            }
                        }

                        incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));

                        //string bonsql = "select " + incrementcountstr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + table + " ";
                        string bonsql = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + table + " ";

                        dthRegObj.readSql(bonsql);
                        OracleDataReader bonfilereader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                        while (bonfilereader.Read())
                        {
                            flag = true;
                            for (int j = 0; j < bonuscount; j++)
                            {
                                double annualbonus = 0;
                                if (!bonfilereader.IsDBNull(j)) { annualbonus = bonfilereader.GetDouble(j); }
                                totbonus = totbonus + annualbonus;
                                if (annualbonus == 0)
                                {
                                    interimboncount++;
                                    break;
                                }
                                else { temp = annualbonus; }
                            }

                        }
                        bonfilereader.Close();
                        bonfilereader.Dispose();
                        if (!flag)
                        { totbonus = 0; }
                    }
                    vestedBonus = (totbonus * sumassured) / 1000;
                    if (table == 34)
                    { vestedBonus = totbonus; }
                    //interimboncount--;
                    if (interimboncount < 0) { interimboncount = 0; }
                    interimBonus = (temp * interimboncount * sumassured) / 1000;
                    if ((polstat.Equals("L") && ((term <= 10) && (polDuraYrs >= 2)) || ((term > 10) && (polDuraYrs >= 3))) || polstat.Equals("I"))
                    {
                        this.lbltotbons.Text = "Rs." + String.Format("{0:N}", (interimBonus + vestedBonus));
                        interimBonStYR = int.Parse(this.setDate()[0].Substring(0, 4)) - interimboncount - 1;
                    }
                    else { interimBonus = 0; vestedBonus = 0; interimBonStYR = 0; }
                }


                if (MOF.Equals("S"))
                {
                    interimBonus = 0; vestedBonus = 0; interimBonStYR = 0;
                    this.lbltotbons.Text = "Rs.0.00";
                }


                #endregion

                dthRegObj.connclose();

                #region ----- view state --------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["dateofdeath"] = dateofdeath;

                ViewState["PRM"] = PRM;
                ViewState["ADB"] = ADB;
                ViewState["FPU"] = FPU;
                ViewState["SJ"] = SJ;
                ViewState["FE"] = FE;
        
                ViewState["ageAdmitYN"] = ageAdmitYN;
                ViewState["ageAdmitAmt"] = ageAdmitAmt;//...add by buddhika 2009/03/23...
                ViewState["ageEntryInter"] = ageEntryInter;//..add by buddhika 2009/04/07...
                ViewState["revivalsYN"] = revivalsYN;
                ViewState["assNomYN"] = assNomYN;
                ViewState["interimBonStYR"] = interimBonStYR;
                ViewState["ageatentry"] = ageatentry;
                ViewState["bonuscount"] = bonuscount;

                ViewState["reinsYN"] = reinsYN;
                ViewState["vestedBonus"] = vestedBonus;
                ViewState["interimBonus"] = interimBonus;              
                ViewState["surrrenderedbons"] = surrrenderedbons;
                ViewState["bonussurrYr"] = bonussurrYr;
                ViewState["netsurrAmt"] = netsurrAmt;
                ViewState["claimNo"] = claimNo;
                ViewState["deposit"] = deposit;
                ViewState["demmands"] = demmands;
                ViewState["defint"] = defint;             
             
                ViewState["covernum"] = covernum;
                ViewState["coveramt"] = coveramt;
                ViewState["comdat"] = comdat;
                ViewState["covterm"] = covterm;

                ViewState["branch"] = branch;
                ViewState["polstat"] = polstat;
                //ViewState["claimNo"] = claimNo;
                ViewState["dateofComm"] = dateofComm;
                ViewState["phname"] = phname;
                ViewState["cof"] = cof;
                ViewState["ad1"] = ad1;
                ViewState["ad2"] = ad2;
                ViewState["ad3"] = ad3;
                ViewState["ad4"] = ad4;

                ViewState["LoanNum"] = LoanNum;
                ViewState["rcptno"] = rcptno;
                ViewState["LMNCP_LMCPY"] = LMNCP_LMCPY;
                ViewState["LMIPY01"] = LMIPY01;
                ViewState["polDuraYrs"] = polDuraYrs;
                ViewState["polDuraMnths"] = polDuraMnths;
                ViewState["loanCap"] = loanCapital;
                ViewState["loanint"] = loaninterest;
                              
                #endregion
            }
            catch (Exception ex)
            {
                dthRegObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            #region ----- view state --------
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["dateofdeath"] != null) { dateofdeath = int.Parse(ViewState["dateofdeath"].ToString()); }
            if (ViewState["ADB"] != null) { ADB = long.Parse(ViewState["ADB"].ToString()); }
            if (ViewState["FPU"] != null) { FPU = long.Parse(ViewState["FPU"].ToString()); }
            if (ViewState["SJ"] != null) { SJ = long.Parse(ViewState["SJ"].ToString()); }
            if (ViewState["FE"] != null) { FE = long.Parse(ViewState["FE"].ToString()); }
            if (ViewState["PRM"] != null) { PRM = double.Parse(ViewState["PRM"].ToString()); }
         
            if (ViewState["ageAdmitYN"] != null) { ageAdmitYN = ViewState["ageAdmitYN"].ToString(); }
            if (ViewState["ageAdmitAmt"] != null) { ageAdmitAmt = Convert.ToDouble(ViewState["ageAdmitAmt"].ToString()); }//...Add by buddhika 2009/03/23...
            if (ViewState["revivalsYN"] != null) { revivalsYN = ViewState["revivalsYN"].ToString(); }
            if (ViewState["assNomYN"] != null) { assNomYN = ViewState["assNomYN"].ToString(); }
            if (ViewState["interimBonStYR"] != null) { interimBonStYR = int.Parse(ViewState["interimBonStYR"].ToString()); }
            if (ViewState["ageatentry"] != null) { ageatentry = int.Parse(ViewState["ageatentry"].ToString()); }
            if (ViewState["bonuscount"] != null) { bonuscount = int.Parse(ViewState["bonuscount"].ToString()); }          

            if (ViewState["reinsYN"] != null) { reinsYN = ViewState["reinsYN"].ToString(); }
            if (ViewState["vestedBonus"] != null) { vestedBonus = double.Parse(ViewState["vestedBonus"].ToString()); }
            if (ViewState["interimBonus"] != null) { interimBonus = double.Parse(ViewState["interimBonus"].ToString()); }
            if (ViewState["surrrenderedbons"] != null) { surrrenderedbons = double.Parse(ViewState["surrrenderedbons"].ToString()); }
            if (ViewState["bonussurrYr"] != null) { bonussurrYr = int.Parse(ViewState["bonussurrYr"].ToString()); }
            if (ViewState["netsurrAmt"] != null) { netsurrAmt = double.Parse(ViewState["netsurrAmt"].ToString()); }
            if (ViewState["claimNo"] != null) { claimNo = long.Parse(ViewState["claimNo"].ToString()); }
            if (ViewState["deposit"] != null) { deposit = double.Parse(ViewState["deposit"].ToString()); }
            if (ViewState["demmands"] != null) { demmands = double.Parse(ViewState["demmands"].ToString()); }
            if (ViewState["defint"] != null) { defint = double.Parse(ViewState["defint"].ToString()); }

            if (ViewState["covernum"] != null) { covernum = int.Parse(ViewState["covernum"].ToString()); }
            if (ViewState["coveramt"] != null) { coveramt = int.Parse(ViewState["coveramt"].ToString()); }
            if (ViewState["comdat"] != null) { comdat = int.Parse(ViewState["comdat"].ToString()); }
            if (ViewState["covterm"] != null) { covterm = int.Parse(ViewState["covterm"].ToString()); }

            if (ViewState["branch"] != null) { branch = int.Parse(ViewState["branch"].ToString()); }
            if (ViewState["polstat"] != null) { polstat = ViewState["polstat"].ToString(); }
            //if (ViewState["claimNo"] != null) { claimNo = long.Parse(ViewState["claimNo"].ToString()); }
            if (ViewState["dateofComm"] != null) { dateofComm = int.Parse(ViewState["dateofComm"].ToString()); }
            if (ViewState["phname"] != null) { phname = ViewState["phname"].ToString(); }
            if (ViewState["cof"] != null) { cof = ViewState["cof"].ToString(); }
            if (ViewState["ad1"] != null) { ad1 = ViewState["ad1"].ToString(); }
            if (ViewState["ad2"] != null) { ad2 = ViewState["ad2"].ToString(); }
            if (ViewState["ad3"] != null) { ad3 = ViewState["ad3"].ToString(); }
            if (ViewState["ad4"] != null) { ad4 = ViewState["ad4"].ToString(); }

            if (ViewState["LoanNum"] != null) { LoanNum = int.Parse(ViewState["LoanNum"].ToString()); }
            if (ViewState["rcptno"] != null) { rcptno = int.Parse(ViewState["rcptno"].ToString()); }
            if (ViewState["LMNCP_LMCPY"] != null) { LMNCP_LMCPY = double.Parse(ViewState["LMNCP_LMCPY"].ToString()); }
            if (ViewState["LMIPY01"] != null) { LMIPY01 = double.Parse(ViewState["LMIPY01"].ToString()); }
            if (ViewState["polDuraYrs"] != null) { polDuraYrs = int.Parse(ViewState["polDuraYrs"].ToString()); }
            if (ViewState["polDuraMnths"] != null) { polDuraMnths = int.Parse(ViewState["polDuraMnths"].ToString()); }
            if (ViewState["loanCap"] != null) { loanCapital = double.Parse(ViewState["loanCap"].ToString()); }
            if (ViewState["loanint"] != null) { loaninterest = double.Parse(ViewState["loanint"].ToString()); }
         
            #endregion            
        }

    }
   
    protected void btnregister_Click(object sender, EventArgs e)    
    {      
        string typeeka = "";
        string calcdate = setDate()[0];
       
        double totsurrbonus = 0;
        double totbonus = 0;
        int surrbonuscount;
        dthRegObj = new DataManager();
        try
        {          
            dthRegObj.begintransaction();
            //if ((!this.txtclmno.Text.Trim().Equals(null)) && (int.Parse(this.txtclmno.Text.Trim()) == 0))
            //{
            //    //dthRegObj.connclose();
            //    throw new Exception("Please Enter the Claim Number!");
            //}
            //else claimNo = long.Parse(this.txtclmno.Text.Trim());

            string dthrefhisSel = "SELECT DPOLNO, DMOS ,DCLM FROM LPHS.DTHINT WHERE (DPOLNO = " + polno + ") AND (DMOS = '" + MOF + "')";
            if (dthRegObj.existRecored(dthrefhisSel) != 0)
            {
                dthRegObj.readSql(dthrefhisSel);
                OracleDataReader dthrefhisReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthrefhisReader.Read())
                {
                    if (!dthrefhisReader.IsDBNull(2))
                    { claimNo = dthrefhisReader.GetInt32(2); }
                    else
                    { claimNo = 0; }
                }
                //dthrefhisReader.Close();
                //dthrefhisReader.Dispose();
            }
            if (claimNo == 0)
            {
                //string dclmSelect = "select max(dclm) from lphs.dthint ";
                //dthRegObj.readSql(dclmSelect);
                //OracleDataReader clmnoReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //while (clmnoReader.Read())
                //{
                //    claimNo = clmnoReader.GetInt32(0);
                //}
                //clmnoReader.Close();
                //clmnoReader.Dispose();
                string deathClaimNum = "SELECT * FROM LCLM.ARREFNO WHERE RCTYPE='D'";
                dthRegObj.readSql(deathClaimNum);
                OracleDataReader clmnoReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (clmnoReader.Read())
                {
                    if (!clmnoReader.IsDBNull(2))
                    {
                        claimNo = clmnoReader.GetInt64(2);
                        claimNo = claimNo + 1;
                        string Update = "UPDATE LCLM.ARREFNO SET RCNO=" + claimNo + " WHERE RCTYPE='D'";
                        dthRegObj.insertRecords(Update);
                    }
                }
                //clmnoReader.Close();
                //clmnoReader.Dispose();
            }


            string dthintSelect = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=0 ";
            if (dthRegObj.existRecored(dthintSelect) == 0)
            {
                //dthRegObj.connclose();
                throw new Exception("Death Intimation Already Confirmed or Deleted!");
            }
            else
            {

                #region //************ Generating Policy History ****************

                string premRead = "select  PMCOD, PMPOL, PMCOM, PMTBL, PMTRM, PMSUM, PMMOD, PMPRM, PMDUE, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR from LPHS.premast where PMPOL=" + polno + " ";
                dthRegObj.readSql(premRead);
                OracleDataReader premReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                bool premflag = false;
                while (premReader.Read())
                {
                    typeeka = "I";
                    premflag = true;

                    if (!premReader.IsDBNull(0))
                    {
                        COD = premReader.GetString(0);
                    }

                    if (!premReader.IsDBNull(1)) { POL = premReader.GetInt32(1); }
                    if (!premReader.IsDBNull(2)) { COM = premReader.GetInt32(2); }
                    if (!premReader.IsDBNull(3)) { TBL = premReader.GetInt32(3); }
                    if (!premReader.IsDBNull(4)) { TRM = premReader.GetInt32(4); }
                    if (!premReader.IsDBNull(5)) { SUM = premReader.GetInt32(5); }
                    if (!premReader.IsDBNull(6)) { MOD = premReader.GetInt32(6); }
                    if (!premReader.IsDBNull(7)) { PRM = premReader.GetDouble(7); } else { PRM = 0; }
                    if (!premReader.IsDBNull(8)) { DUE = premReader.GetInt32(8); }
                    if (!premReader.IsDBNull(9)) { PAC = premReader.GetInt32(9); }
                    if (!premReader.IsDBNull(10)) { AGT = premReader.GetInt32(10); }
                    if (!premReader.IsDBNull(11)) { ORG = premReader.GetInt32(11); }
                    if (!premReader.IsDBNull(12)) { BRN = premReader.GetInt32(12); }
                    if (!premReader.IsDBNull(13)) { OBR = premReader.GetInt32(13); }
                    if (!premReader.IsDBNull(14)) { PTR = premReader.GetInt32(14); }

                }
                //premReader.Close();
                //premReader.Dispose();
                bool lapsflag = false;

                if (!premflag)
                {

                    //----------------- liflaps data -----------------------------------------


                    string liflapsRead = "select  LPCOD, LPPOL, LPCOM, LPTBL, LPTRM, LPSUM, LPMOD, LPPRM, LPDUE, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR from LPHS.LIFLAPS where LPPOL=" + polno + " ";
                    dthRegObj.readSql(liflapsRead);
                    OracleDataReader lapsReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (lapsReader.Read())
                    {
                        typeeka = "L";
                        lapsflag = true;

                        if (!lapsReader.IsDBNull(0))
                        {
                            COD = lapsReader.GetString(0);
                        }

                        if (!lapsReader.IsDBNull(1)) { POL = lapsReader.GetInt32(1); }
                        if (!lapsReader.IsDBNull(2)) { COM = lapsReader.GetInt32(2); }
                        if (!lapsReader.IsDBNull(3)) { TBL = lapsReader.GetInt32(3); }
                        if (!lapsReader.IsDBNull(4)) { TRM = lapsReader.GetInt32(4); }
                        if (!lapsReader.IsDBNull(5)) { SUM = lapsReader.GetInt32(5); }
                        if (!lapsReader.IsDBNull(6)) { MOD = lapsReader.GetInt32(6); }
                        if (!lapsReader.IsDBNull(7)) { PRM = lapsReader.GetDouble(7); }
                        if (!lapsReader.IsDBNull(8)) { DUE = lapsReader.GetInt32(8); }
                        if (!lapsReader.IsDBNull(9)) { PAC = lapsReader.GetInt32(9); }
                        if (!lapsReader.IsDBNull(10)) { AGT = lapsReader.GetInt32(10); }
                        if (!lapsReader.IsDBNull(11)) { ORG = lapsReader.GetInt32(11); }
                        if (!lapsReader.IsDBNull(12)) { BRN = lapsReader.GetInt32(12); }
                        if (!lapsReader.IsDBNull(14)) { PTR = lapsReader.GetInt32(14); }
                    }
                    //lapsReader.Close();
                    //lapsReader.Dispose();
                }

                if (!premflag && !lapsflag)
                {
                    //dthRegObj.connclose();
                    throw new Exception("No Policy Details!");
                }

                //---------------- update/insert into lpolhis -----------------------

                string ipADDR = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                int createHistory = 0;
                string polhisread = "select * from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                if (dthRegObj.existRecored(polhisread) == 0)
                {
                    string polhisinsertSQL = "insert into lphs.lpolhis (PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN,";
                    polhisinsertSQL += " PHOBR, PHPTR, PHTYP, PHENT, PHEPF, PHIP, PHSTA, PHMOS,PHCLAIM ) values('" + COD + "'," + POL + "," + COM + "," + TBL + "," + TRM + "," + SUM + "," + MOD + "," + PRM + "," + DUE + "," + PAC + ",";
                    polhisinsertSQL += " " + AGT + "," + ORG + "," + BRN + "," + OBR + "," + PTR + ", 'D'," + int.Parse(setDate()[0]) + ",'" + EPF + "', '" + ipADDR + "', '" + typeeka + "', '" + MOF + "','" + claimNo.ToString() + "') ";

                    createHistory = dthRegObj.insertRecords(polhisinsertSQL);
                }
                else
                {
                    //throw new Exception(" Policy Already Terminated!");
                    //commented on 20070419
                }

                //--------------- updating Policy Details ------------------------------------------

                //...Put this Comment on 2008/07/23 Because of discussion with Mr.Jayantha and Dushan

                //if ((TBL != 38) && (TBL != 39) && (TBL != 34) && (TBL != 48) && (TBL != 49) && (TBL != 14))
                //{
                if ((premflag) && (MOF.Equals("M")))
                {
                    string premdelSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                    dthRegObj.insertRecords(premdelSQL);
                }
                    //else if ((premflag) && (MOF.Equals("S"))) { 
                    
                    //}
                    //else if (!premflag) {
                        string lapsdeSQL = "delete from lphs.liflaps where lppol=" + polno + " ";
                        dthRegObj.insertRecords(lapsdeSQL);
                //    }
                //    else { }
                //}
                //else if (((TBL == 38) || (TBL == 39) || (TBL == 34) || (TBL == 48) || (TBL == 49) || (TBL == 14)) && (!premflag))
                //{
                //    //---- to add else code --------
                //    //---- added on 20080206 -------
                //    string lapsdeSQL = "delete from lphs.liflaps where lppol=" + polno + " ";
                //    dthRegObj.insertRecords(lapsdeSQL);
                //}
                
               
            #endregion

                #region  //*********** Confirming In DTHINT ************************

                string dthintUPD = "update lphs.dthint set dclm="+claimNo+", dsta=2 , dconfdat=" + int.Parse(setDate()[0]) + " , dconfepf='" + EPF + "' , ";
                dthintUPD += "dconfip='" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "' , dconfbr=" + BRN + " , dconftime='" + setDate()[1] + "' , dconfst='Y' where dpolno=" + polno + " and dmos='" + MOF + "' ";
                dthRegObj.insertRecords(dthintUPD);
                #endregion

                //????? apply back calculation -------

                #region //************* Settlign Loans ***************************
                
                rcptno = 0;

                try
                {
                    string loansql = "select lmlon, lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1, lmebr, lmsbr, lmpty, lmlsuf, lmrnb  from lphs.lplmast " +
                        " where lmpol=" + polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null) ";
                    if (dthRegObj.existRecored(loansql) != 0)
                    {
                        dthRegObj.readSql(loansql);
                        OracleDataReader myloanreader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (myloanreader.Read())
                        {
                            this.btnloanreciept.Visible = true;

                            int lmpdt = 0;
                            int lmnid = 0;
                            int lmlrd = 0;
                            double lmpit = 0;
                            double lmnit = 0;
                            double lmpcp = 0;
                            double lmncp = 0;
                            double lmipy = 0;
                            double lmcpy = 0;
                            double lmitr = 0;
                            double lmcit = 0;
                            double lmccp = 0;
                            int lmcdt = 0;
                            int lmmdt = 0;

                            LoanNum = myloanreader.GetInt32(0);
                            if (!myloanreader.IsDBNull(1)) { lmpdt = myloanreader.GetInt32(1); }
                            if (!myloanreader.IsDBNull(2)) { lmnid = myloanreader.GetInt32(2); }
                            if (!myloanreader.IsDBNull(3)) { lmlrd = myloanreader.GetInt32(3); }
                            if (!myloanreader.IsDBNull(4)) { lmpit = myloanreader.GetDouble(4); }
                            if (!myloanreader.IsDBNull(5)) { lmnit = myloanreader.GetDouble(5); }
                            if (!myloanreader.IsDBNull(6)) { lmpcp = myloanreader.GetDouble(6); }
                            if (!myloanreader.IsDBNull(7)) { lmncp = myloanreader.GetDouble(7); }
                            if (!myloanreader.IsDBNull(8)) { lmipy = myloanreader.GetDouble(8); }
                            if (!myloanreader.IsDBNull(9)) { lmcpy = myloanreader.GetDouble(9); }
                            if (!myloanreader.IsDBNull(10)) { lmitr = myloanreader.GetDouble(10); }
                            if (!myloanreader.IsDBNull(11)) { lmcit = myloanreader.GetDouble(11); }
                            if (!myloanreader.IsDBNull(12)) { lmccp = myloanreader.GetDouble(12); }
                            if (!myloanreader.IsDBNull(13)) { lmcdt = myloanreader.GetInt32(13); }
                            if (!myloanreader.IsDBNull(14)) { lmmdt = myloanreader.GetInt32(14); }
                            string lmset = "";
                            if (!myloanreader.IsDBNull(15)) { lmset = myloanreader.GetString(15); }
                            string lmcd1 = "";
                            if (!myloanreader.IsDBNull(16)) { lmcd1 = myloanreader.GetString(16); }
                            int lmebr = myloanreader.GetInt32(17);
                            int lmsbr = myloanreader.GetInt32(18);
                            int lmpty = 0;
                            if (!myloanreader.IsDBNull(19)) { lmpty = myloanreader.GetInt32(19); }
                            int lmlsuf = 0;
                            if (!myloanreader.IsDBNull(20)) { lmlsuf = myloanreader.GetInt32(20); }
                            int lmrnb = 0;
                            if (!myloanreader.IsDBNull(21)) { lmrnb = myloanreader.GetInt32(21); }

                            lmlsuf++;

                            if (!lmset.Equals("Y") && (!(lmcd1.Equals("D"))))
                            {
                                //-------------- updating LPLMAST ------------

                                //--------- generating loan reciept number --

                                int newsurryear = int.Parse(setDate()[0].Substring(0, 4));

                                
                                //string rcptnoquery = "select rcpno from lpay.rcptno2 where rcpbrno=" + branch + " and rcpyear=" + newsurryear + "  and rcptype= 'D' ";     //********* please refer the type *******
                                string rcptnoquery = "SELECT RCNO FROM  LPAY.RCPTNO WHERE (RCBRNO = " + branch + ") AND (RCYEAR = " + newsurryear + ") AND (RCTYPE = 10)";
                                dthRegObj.readSql(rcptnoquery);
                                OracleDataReader rcptReader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                if (rcptReader.Read())
                                {
                                    rcptno = rcptReader.GetInt32(0);
                                    rcptno++;
                                }
                                else
                                {
                                    rcptno = 1;
                                }
                                //rcptReader.Close();
                                //rcptReader.Dispose();

                                if (dthRegObj.existRecored(rcptnoquery) == 0)
                                {
                                    //string inertRcptnoquery = "insert into lpay.rcptno2 (rcpbrno, rcpyear, rcptype, rcpno) values(" + branch + "," + newsurryear + ",'D'," + rcptno + " )";
                                    string inertRcptnoquery = "insert into LPAY.RCPTNO (RCBRNO, RCYEAR, RCTYPE, RCNO) values(" + branch + "," + newsurryear + ",10," + rcptno + " )";
                                    dthRegObj.insertRecords(inertRcptnoquery);
                                }
                                else
                                {
                                    //string updRcptnoquery = "update lpay.rcptno2 set rcpno=" + rcptno + " where rcpbrno=" + branch + " and rcpyear=" + newsurryear + "  and rcptype= 'D' ";
                                    string updRcptnoquery = "update LPAY.RCPTNO set RCNO=" + rcptno + " where RCBRNO=" + branch + " and RCYEAR=" + newsurryear + "  and RCTYPE= 10 ";
                                    dthRegObj.insertRecords(updRcptnoquery);
                                }

                                double LMPDT01 = 0;
                                double LMNID01 = 0;
                                double LMPIT01 = 0;
                                double LMNIT01 = 0;
                                double LMPCP01 = 0;
                                LMNCP_LMCPY = 0;
                                double LMCIT01 = 0;
                                double LMCCP01 = 0;
                                LMIPY01 = 0;

                                try
                                {
                                    double[] arr = new double[9];
                                    try
                                    {

                                        arr = loanCalculation.calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, int.Parse(setDate()[0]));

                                        LMPDT01 = arr[0];
                                        LMNID01 = arr[1];
                                        LMPIT01 = arr[2];
                                        LMNIT01 = arr[3];
                                        LMPCP01 = arr[4];
                                        //LMNCP_LMCPY = loanCapital;
                                        loanbackobj = new LoanBackCal(polno, dateofdeath, LoanNum);
                                        LMNCP_LMCPY += loanbackobj.Loancap;
                                        LMIPY01 += loanbackobj.Backinterest;

                                        //LMNCP_LMCPY = loanCapital;
                                        LMCIT01 = arr[6];
                                        LMCCP01 = arr[7];
                                        //LMIPY01 = loaninterest;


                                        //------------- Back Calculation Algorithm Applied 20070802 ------------
                                        tempkkkkk = LMNCP_LMCPY;
                                        //LMNCP_LMCPY = this.backCalculationAlgorithm(lmcdt, dateofdeath, LMIPY01, LMNCP_LMCPY, (lmitr / 200), lmpdt, lmpit)[0];
                                        //LMIPY01 = this.backCalculationAlgorithm(lmcdt, dateofdeath, LMIPY01, tempkkkkk, (lmitr / 200), lmpdt, lmpit)[1];
                                        //tempkkkkk = LMNCP_LMCPY - LMIPY01;

                                        string updateLPLMAST = "update lphs.lplmast set  lmpdt=" + LMPDT01 + ", lmpcp=" + LMPCP01 + ", lmpit=" + LMPIT01 + ", lmnid=" + LMNID01 + "," +
                                            "lmncp=" + tempkkkkk + ", lmnit=" + LMNIT01 + ", lmebr=" + branch + ", lmlrd=" + int.Parse(setDate()[0]) + ", lmsbr=" + BRN + ", lmpty = 2, " +
                                            "lmrnb=" + rcptno + ",   lmcpy=" + tempkkkkk + ", lmipy=" + LMIPY01 + ", lmccp=" + LMCCP01 + ", lmcit=" + LMCIT01 + ", lmepf=" + int.Parse(EPF)
                                            + ", lmedt=" + int.Parse(setDate()[0]) + ", lmlsuf=" + lmlsuf + ", lmset='Y' where lmlon=" + LoanNum + " ";

                                        dthRegObj.insertRecords(updateLPLMAST);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }

                                }
                                catch (Exception ex)
                                {
                                    //dthRegObj.connclose();
                                    throw new Exception("Loan Master file update Failed! " + ex.Message.ToString());
                                }

                                #region //--------- writting into LPAYTRN ------------

                                //string LPAYRTNsql = "select * from lpay.lpaytrn where ltlon=" + LoanNum + " and  LTLRDC = " + int.Parse(setDate()[0]) + " and LTPTYC = 10 and LTRNBC = " + rcptno + " and LTLSUF = " + lmlsuf + " ";

                                //if (dthRegObj.existRecored(LPAYRTNsql) == 0)
                                //{
                                string insertLPAYRTN = "insert into lpay.lpaytrn (LTLON, LTPDT, LTPCP, LTPIT, LTNID, LTNCP, LTNIT, LTEBR, LTLRD, LTSBR, LTPTY, LTRNB, LTCPY, LTIPY, LTCCP, LTCIT, ";
                                insertLPAYRTN += " LTEPF, LTEDT, LTEBRC, LTLRDC, LTPTYC, LTRNBC, LTLSUF) values(" + LoanNum + "," + lmpdt + "," + lmpcp + "," + lmpit + "," + lmnid + "," + lmncp + "," + lmnit + "," + lmebr + "," + lmlrd + "," + lmsbr + "," + lmpty + "," + lmrnb + ",";
                                insertLPAYRTN += " " + lmcpy + "," + lmipy + "," + lmccp + "," + lmcit + "," + EPF + "," + int.Parse(setDate()[0]) + "," + branch + "," + int.Parse(setDate()[0]) + ", 10 , " + rcptno + ", " + lmlsuf + " )";

                                dthRegObj.insertRecords(insertLPAYRTN);
                                //}
                                //else
                                //{
                                //    //??????????????????????????????????
                                //}

                                #endregion

                                #region //------------ updating LPAY.LPLLEDG file -------------
                                try
                                {
                                    //string loanLedgerSQL = "select * from LPAY.lplledg where llon=" + LoanNum + " and lsuf=" + lmlsuf + " ";

                                    //if (dthRegObj.existRecored(loanLedgerSQL) == 0)
                                    //{
                                    string loanLedgInsert = "insert into lpay.lplledg (llon, lsuf, lpol, lrec, lpdt, lptp,lpbr, lcap, lint,ltag, ltyp1, lamt1, lmptp2 ) values (" + LoanNum + ", " + lmlsuf + "," + polno + "," + rcptno + "," + int.Parse(setDate()[0]) + ",'10'," + branch + "," + LMNCP_LMCPY + ", " + LMIPY01 + ", '0','D', " + (LMNCP_LMCPY + LMIPY01) + " , 'D' ) ";
                                    dthRegObj.insertRecords(loanLedgInsert);
                                    //}

                                    //else
                                    //{
                                    //    string loanLedgUpd = "update lpay.lplledg set lpol= " + polno + ", lrec= " + rcptno + ", lpdt=" + int.Parse(setDate()[0]) + ", lpbr = " + branch + ", lcap=" + LMNCP_LMCPY + ", lint=" + LMIPY01 + ", ltyp1='D', lamt1=" + (LMNCP_LMCPY + LMIPY01) + ", lmptp2='D' where llon=" + LoanNum + " and lsuf=" + lmlsuf + " ";
                                    //    dthRegObj.insertRecords(loanLedgUpd);
                                    //}
                                }
                                catch
                                {
                                    //dthRegObj.connclose();
                                    throw new Exception("Ledger File Update Failed!");
                                }

                                #endregion

                                #region //------------ inserting into LPAY.LPAYMAS TABLE ------------
                                try
                                {
                                    //string lpaymasSQL = "select * from lpay.lpaymas where lpbrn=" + branch + " and lpptd=" + int.Parse(setDate()[0]) + " and lpbtp = 10 and lprec=" + rcptno + " ";

                                    //if (dthRegObj.existRecored(lpaymasSQL) == 0)
                                    //{
                                    string lpaymasInsertSQL = "insert into lpay.lpaymas (lpbrn, lpptd, lpbtp, lprec, lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, lpedt, lptim, lpipa, lpacd, lpopr, lpcur, lpcrt) values(" + branch
                                        + ", " + int.Parse(setDate()[0]) + ", 10, " + rcptno + ", " + LoanNum + ", " + polno + ", 'D', '5', " + (LMNCP_LMCPY + LMIPY01) + ", " + LMNCP_LMCPY + ", " + LMIPY01 + ", " + BRN + ", " + int.Parse(setDate()[0])
                                        + ", '" + DateTime.Now.ToLongTimeString() + "',  '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', 2392, " + EPF + ", 'LKR', 1 )";
                                    dthRegObj.insertRecords(lpaymasInsertSQL);
                                    //}
                                    //else
                                    //{
                                    //    string lpaymasUpdSQL = "update lpay.lpaymas set  lpboc=" + LoanNum + ", lppol=" + polno + ", lpptp='D', lpmd1= '5', lpam1=" + (LMNCP_LMCPY + LMIPY01) + ", lpca1=" + LMNCP_LMCPY + ", lpca2=" + LMIPY01 + ", lpsbr=" + BRN + ", lpedt=" + int.Parse(setDate()[0]) + ", lptim='" + DateTime.Now.ToLongTimeString() + "', lpipa='" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', lpacd=2392, lpcur='LKR', lpcrt=1 where lpbrn=" + branch + " and lpptd=" + int.Parse(setDate()[0]) + " and lpbtp = 10 and lprec=" + rcptno + " ";
                                    //    dthRegObj.insertRecords(lpaymasUpdSQL);
                                    //}
                                }
                                catch
                                {
                                    //dthRegObj.connclose();
                                    throw new Exception("Payment Master File Update Failed!");
                                }

                                #endregion
                            }
                        }
                        //myloanreader.Close();
                        //myloanreader.Dispose();

                    }
                    else { LoanNum = 0; LMNCP_LMCPY = 0; LMIPY01 = 0; }
                }
                catch
                {
                    //dthRegObj.connclose();
                    throw new Exception("Loan Settlement Failed!");
                }
                #endregion

                //*********** updating LPHS.DTHREF ***********************
                
                string DCOstr = COM.ToString();
                int commyr = int.Parse(COM.ToString().Substring(0, 4));
                ageAdmitYN = this.ddlageadmit.SelectedItem.Value;
                revivalsYN = this.ddlrinsYN.SelectedItem.Value;
                ageAdmitAmt = Convert.ToDouble(this.TxtAgeEntry.Text.Trim());//....add by buddhika 2009/03/23...
                ageEntryInter = Convert.ToDouble(TxtAgeEntryInter.Text.Trim());//....add by buddhika 2009/04/7...
                //assNomYN = this.ddlassnomYN.SelectedItem.Value;
                //claimNo = long.Parse(this.txtclmno.Text);

                #region  //----------------------------------- surrendered bonus ------------------------------------------

                int DCOym = int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                //*************************************** Bonus Logic ******************************************

                bonusurrYN = this.ddlbonsurrYN.SelectedItem.Value;
                if ((this.txtbonsurryr.Text != null) && (bonusurrYN.Equals("Y"))) { bonussurrYr = int.Parse(this.txtbonsurryr.Text); }
                else if (this.txtbonsurryr.Text == null) { throw new Exception("If You Want the Surrendered Bonus Please Give the Surrender Year!"); }

                //************** Inforce ***********************************************************

                if (polstat.Equals("I"))
                {
                    if (bonusurrYN.Equals("N"))
                    {
                        if (TRM < bonuscount)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                        }                       
                    }

                 //**************** Inforce and bonus surrendered ************************************

                    else
                    {
                        surrbonuscount = bonussurrYr - commyr + 1;
                        string incrementcountstr = "";
                        string incrementcountstrdclr = "";
                        int i = 0;

                        if (TRM < bonuscount)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                        }
                        else
                        {

                            for (i = 1; i < (surrbonuscount + 1); i++)
                            {
                                if (i < 10)
                                {
                                    incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                                    incrementcountstrdclr = incrementcountstrdclr + "BONY" + "0" + Convert.ToString(i) + ", ";
                                }
                                else
                                {
                                    incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                                    incrementcountstrdclr = incrementcountstrdclr + "BONY" + Convert.ToString(i) + ", ";
                                }

                            }

                            incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));
                            incrementcountstrdclr = incrementcountstrdclr.Substring(0, incrementcountstrdclr.LastIndexOf(","));

                            //string bonsqlinf = "select " + incrementcountstr + "," + incrementcountstrdclr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + TBL + " ";
                            string bonsqlinf = "select " + incrementcountstr + "," + incrementcountstrdclr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + TBL + " ";
                            
                            dthRegObj.readSql(bonsqlinf);
                            OracleDataReader bonfilereaderinf = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                            bool flag = false;
                            while (bonfilereaderinf.Read())
                            {
                                flag = true;
                                for (int j = 0; j < surrbonuscount; j++)
                                {
                                    double annualbonus = bonfilereaderinf.GetDouble(j);
                                    int bondeclaredyr = bonfilereaderinf.GetInt32(j + surrbonuscount);
                                    if (bondeclaredyr > bonussurrYr)
                                    { break; }
                                    else
                                    { totsurrbonus = totsurrbonus + annualbonus; }
                                }

                            }
                            bonfilereaderinf.Close();
                            surrrenderedbons = (totsurrbonus * SUM) / 1000;
                        }
                    }
                }

                 //*************** policy lapsed *********************************************

                else if (polstat.Equals("L"))
                {
                    if (bonusurrYN.Equals("N"))
                    {
                        if (TRM < bonuscount)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                        }                        
                    }

                     //*********** Lapse and bonus surrendered *****************************

                    else
                    {
                        surrbonuscount = bonussurrYr - commyr + 1;
                        string incrementcountstr = "";
                        string incrementcountstrdclr = "";
                        int i = 0;

                        if (TRM < bonuscount)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                        }
                        else
                        {

                            for (i = 1; i < (surrbonuscount + 1); i++)
                            {
                                if (i < 10)
                                {
                                    incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                                    incrementcountstrdclr = incrementcountstrdclr + "BONY" + "0" + Convert.ToString(i) + ", ";
                                }
                                else
                                {
                                    incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                                    incrementcountstrdclr = incrementcountstrdclr + "BONY" + Convert.ToString(i) + ", ";
                                }


                            }

                            incrementcountstrdclr = incrementcountstrdclr.Substring(0, incrementcountstrdclr.LastIndexOf(","));
                            incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));


                            //string bonsqlapse = "select " + incrementcountstr + ", " + incrementcountstrdclr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + table + " ";
                            string bonsqlapse = "select " + incrementcountstr + ", " + incrementcountstrdclr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + table + " ";

                            dthRegObj.readSql(bonsqlapse);
                            OracleDataReader bonfilereaderlapse = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            bool flag = false;
                            while (bonfilereaderlapse.Read())
                            {
                                flag = true;
                                for (int j = 0; j < (surrbonuscount); j++)
                                {
                                    double annualbonus = bonfilereaderlapse.GetDouble(j);
                                    int bondeclaredyr = bonfilereaderlapse.GetInt32(j + surrbonuscount);
                                    if (bondeclaredyr > bonussurrYr)
                                    { break; }
                                    else
                                    { totsurrbonus = totsurrbonus + annualbonus; }
                                }
                            }
                            bonfilereaderlapse.Close();
                            surrrenderedbons = (totsurrbonus * sumassured) / 1000;
                        }
                    }
                }
                else { }
                #endregion

                // demmands ????????????????????????????????????

                #region   //------------------------------------- inserting deathref -----------------------------------------
                
                netsurrAmt = vestedBonus + interimBonus - surrrenderedbons;

                //demmand demobj = new demmand(polno, TBL, PRM, dateofdeath);
                //demmands = demobj.MissedPrems;
                //defint = demobj.Defaultlatefee;

                string dthrefSelect = "select * from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                if (dthRegObj.existRecored(dthrefSelect) == 0)
                {
                    string dthrefInsert = "INSERT INTO LPHS.DTHREF (DRPOLNO ,DRMOS ,DRCLMNO ,DRACCBF ,DRAGEADMIT ,DRRINSYN ,DRREVIVALS ,DRASSIGNEENOM ,DRVESTEDBON ,DRINTERIMBON ,DRBONSURRAMT ,DRBONSURRYR ,DRSWARNAJAYA ,DRFUNERALEXP ,DRFPU ,DRDEPOSITS , DRDEFPREM ,DRINT ,DRLONCAP ,DRLOANINT ,DRNETCLM ,DRPAIDNO ,DRAGT, DRNETSURR, DENTDT, DENTEPF,AGE_AMT ,INTBONSTYR, branch,AGEDIFINRST )";
                    dthrefInsert += " VALUES (" + polno + " ,'" + MOF + "' , " + claimNo + " , " + ADB + " ,'" + ageAdmitYN + "' ,'" + reinsYN + "' ,'" + revivalsYN + "' ,'" + assNomYN + "' , " + vestedBonus + " , " + interimBonus + " , " + surrrenderedbons + " , " + bonussurrYr + " , " + SJ + " , " + FE + " , " + FPU + " , " + deposit + " ,";
                    dthrefInsert += " " + demmands + " , " + defint + " , " + tempkkkkk + " , " + LMIPY01 + " , NULL , NULL , " + AGT + ", " + netsurrAmt + ", " + int.Parse(this.setDate()[0]) + ", '" + EPF + "'," + ageAdmitAmt + " ," + interimBonStYR + ", " + BRN + "," + ageEntryInter+ "  )";
                    dthRegObj.insertRecords(dthrefInsert);

                    interimBonStYR = 0;
                }
                else
                {
                    //dthRegObj.connclose();
                    throw new Exception( "Already Registered!");
                }

                #endregion

                #region  //*************** updating GRPBILLINGDET ************************************

                int GBYEAR = 0; int GBMON = 0; string GBSUR = ""; string GBINI = ""; double GBPRM = 0; string GBIDCODE = ""; int GBPAC = 0; int GBPASUBCODE = 0; int GBTRANSDAT = 0; int GBBATCHCODE = 0; int BILLINGTYPE = 0; string FILEST = "";
                string GRPBILLINGsel = "select GBYEAR, GBMON, GBSUR, GBINI, GBPRM, GBIDCODE, GBPAC, GBPASUBCODE, GBTRANSDAT, GBBATCHCODE, BILLINGTYPE, FILEST from LPHS.GRPBILLINGDET where gbpol = " + polno + " ";
                if (dthRegObj.existRecored(GRPBILLINGsel) != 0)
                {
                    dthRegObj.readSql(GRPBILLINGsel);
                    OracleDataReader grpbillingRader = dthRegObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (grpbillingRader.Read())
                    {
                        if (!grpbillingRader.IsDBNull(0)) { GBYEAR = grpbillingRader.GetInt32(0); } else { GBYEAR = 0; }
                        if (!grpbillingRader.IsDBNull(1)) { GBMON = grpbillingRader.GetInt32(1); } else { GBMON = 0; }
                        if (!grpbillingRader.IsDBNull(2)) { GBSUR = grpbillingRader.GetString(2); } else { GBSUR = ""; }
                        if (!grpbillingRader.IsDBNull(3)) { GBINI = grpbillingRader.GetString(3); } else { GBINI = ""; }
                        if (!grpbillingRader.IsDBNull(4)) { GBPRM = grpbillingRader.GetDouble(4); } else { GBPRM = 0; }
                        if (!grpbillingRader.IsDBNull(5)) { GBIDCODE = grpbillingRader.GetString(5); } else { GBIDCODE = ""; }
                        if (!grpbillingRader.IsDBNull(6)) { GBPAC = grpbillingRader.GetInt32(6); } else { GBPAC = 0; }
                        if (!grpbillingRader.IsDBNull(7)) { GBPASUBCODE = grpbillingRader.GetInt32(7); } else { GBPASUBCODE = 0; }
                        if (!grpbillingRader.IsDBNull(8)) { GBTRANSDAT = grpbillingRader.GetInt32(8); } else { GBTRANSDAT = 0; }
                        if (!grpbillingRader.IsDBNull(9)) { GBBATCHCODE = grpbillingRader.GetInt32(9); } else { GBBATCHCODE = 0; }
                        if (!grpbillingRader.IsDBNull(10)) { BILLINGTYPE = grpbillingRader.GetInt32(10); } else { BILLINGTYPE = 0; }
                        if (!grpbillingRader.IsDBNull(11)) { FILEST = grpbillingRader.GetString(11); } else { FILEST = ""; }

                        //string billingHisSelect = "select gbpol from lphs.GRPBILLINGHIS where gbpol = " + polno + " ";
                        //if (dthRegObj.existRecored(billingHisSelect) == 0)
                        //{
                        string billingHisInsert = "INSERT INTO LPHS.GRPBILLINGHIS (GBPOL ,GBYEAR ,GBMON ,GBSUR ,GBINI ,GBPRM ,GBIDCODE ,GBPAC ,GBPASUBCODE ,GBTRANSDAT ,GBBATCHCODE ,BILLINGTYPE ,FILEST ,CLM_SETTLE_TYPE ) " +
                            " VALUES (" + polno + " ," + GBYEAR + " ," + GBMON + " ,'" + GBSUR + "' ,'" + GBINI + "' ," + GBPRM + " ,'" + GBIDCODE + "' ," + GBPAC + " ," + GBPASUBCODE + " ," + GBTRANSDAT + " ," + GBBATCHCODE + " ," + BILLINGTYPE + " ,'" + FILEST + "' ,'D'  )";
                        dthRegObj.insertRecords(billingHisInsert);

                        string BillingHistory = "INSERT INTO LPHS.GRPBILLINGDET_HISTORY (GBPOL, ENTRY_DATE, GBYEAR, GBMON, GBSUR, GBINI, GBPRM, GBIDCODE, GBPAC, GBPASUBCODE, GBTRANSDAT, GBBATCHCODE, BILLINGTYPE, FILEST) "+
                            " VALUES(" + polno + ","+DateTime.Now.ToString("yyyy/MM/dd")+"," + GBYEAR + "," + GBMON + ",'" + GBSUR + "','" + GBINI + "'," + GBPRM + ",'" + GBIDCODE + "'," + GBPAC + "," + GBPASUBCODE + "," + GBTRANSDAT + "," + GBBATCHCODE + "," + BILLINGTYPE + ",'" + FILEST + "')";
                        //}
                    }
                    //grpbillingRader.Close();
                    //grpbillingRader.Dispose();
                }

                string billingDel = "delete from lphs.GRPBILLINGDET where gbpol = " + polno + " ";
                dthRegObj.insertRecords(billingDel);

                #endregion

                //*********** committing now!!!!!!!!!!!!!!!! ******************************************************

                dthRegObj.commit();
                this.lblsucess.Visible = true;
                this.btnregister.Enabled = false;

                this.txtbonsurryr.ReadOnly = true;

                #region //--------- drop down lists and buttons ------------

                if (ageAdmitYN.Equals("Y"))
                {
                    this.ddlageadmit.Items.Add(new ListItem("Yes", "Y"));
                    this.ddlageadmit.Enabled = false;
                    TxtAgeEntry.ReadOnly = false;//..add buddhika 2009/03/23...
                }
                else if (ageAdmitYN.Equals("N"))
                {
                    this.ddlageadmit.Items.Add(new ListItem("No", "N"));
                    this.ddlageadmit.Enabled = false;
                    TxtAgeEntry.ReadOnly = true;//..add buddhika 2009/03/23...

                }

                                    if (revivalsYN.Equals("Y"))
                                    {
                                        this.ddlrinsYN.Items.Add(new ListItem("Yes", "Y"));
                                        this.ddlrinsYN.Enabled = false;
                                    }
                                    else if (revivalsYN.Equals("N"))
                                    {
                                        this.ddlrinsYN.Items.Add(new ListItem("No", "N"));
                                        this.ddlrinsYN.Enabled = false;
                                    }
                                    else
                                    {
                                        this.ddlrinsYN.Items.Add(new ListItem("No", "N"));
                                        this.ddlrinsYN.Items.Add(new ListItem("Yes", "Y"));
                                    }

                    if (assNomYN.Equals("Y"))
                    {
                        //this.ddlassnomYN.Items.Add(new ListItem("Yes", "Y"));
                        //this.ddlassnomYN.Enabled = false;

                    }
                    else if (assNomYN.Equals("N"))
                    {
                        //this.ddlassnomYN.Items.Add(new ListItem("No", "N"));
                        //this.ddlassnomYN.Enabled = false;
                    }
                    
                    {
                        //this.ddlassnomYN.Items.Add(new ListItem("No", "N"));
                        //this.ddlassnomYN.Items.Add(new ListItem("Yes", "Y"));
                    }

                                    if (surrrenderedbons > 0)
                                    {
                                        //this.ddlbonsurrYN.Items.Add(new ListItem("Yes", "Y"));
                                        this.ddlbonsurrYN.SelectedIndex = 1;
                                        this.ddlbonsurrYN.Enabled = false;
                                        this.txtbonsurryr.Text = bonussurrYr.ToString();
                                        this.txtbonsurryr.ReadOnly = true;
                                    }
                                    else
                                    {
                                        //this.ddlbonsurrYN.Items.Add(new ListItem("No", "N"));
                                        //this.ddlbonsurrYN.Items.Add(new ListItem("Yes", "Y"));
                                        this.ddlbonsurrYN.Enabled = false;
                                        this.txtbonsurryr.Text = "";
                                        this.txtbonsurryr.ReadOnly = false;
                                    }

                #endregion
            }

            dthRegObj.connclose();
        }
        catch (Exception ex)
        {
            dthRegObj.rollback();
            dthRegObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
   
    protected string LIFEtype(string mainorspouse) {
        string lifetype = "";
        if (mainorspouse.Equals("M")) {
            lifetype = "Main Life";
        }
        else if (mainorspouse.Equals("S"))
        {
            lifetype = "Spouse";
        }
        else if (mainorspouse.Equals("2"))
        {
            lifetype = "Second Life";
        }
        else { lifetype = "Child"; }
        return lifetype;
    }
    protected string methodofinformation(string meth) {
        string method = "";
        if (meth.Equals("MAIL")) {
            method = "Mail";
        }
        else if (meth.Equals("COUN"))
        {
            method = "Counter";
        }
        else {
            method = "Call";
        }
        return method;
    
    }
    protected string polstate(string state) {
        string thestate = "";
        if (state.Equals("L"))
        {
            thestate = "Laps";
        }
        else {
            thestate = "In force";
        }
        return thestate;
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
            else {
                lbl3.Text = lmccp;
            }

            lbl4.ID = "lmnit" + rowNumber;
            lbl4.Attributes.Add("runat", "Server");
            lbl4.Attributes.Add("Name", "arr8" + rowNumber); //Text Value
            if (!arr8.Equals("Interest (Rs.)"))
            {
                lbl4.Text = String.Format("{0:N}", Convert.ToDouble(arr8));
            }
            else {
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

    private void CreateTbHeader()
    {
        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc1 = new TableHeaderCell();
        TableHeaderCell thc2 = new TableHeaderCell();
        TableHeaderCell thc3 = new TableHeaderCell();
        thc1.Text = "Name";
        thc2.Text = "Percentage";
        thc3.Text = "Address";
        thr.Cells.Add(thc1);
        thr.Cells.Add(thc2);
        thr.Cells.Add(thc3);
        Table2.Rows.Add(thr);
    }

    private void createNomineeTable(string nominee, string percentage, int rowNumber, string Address)
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
        lbl2.Text = percentage+"%";

        lbl3.ID = "Address" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "Address" + rowNumber); //Text Value
        lbl3.Text = Address ;

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

    public int Polno01 {
        get { return polno; }
        set { polno = value; }
    }
    public string mos01
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public int Dtaeofdeath01
    {
        get { return dateofdeath; }
        set { dateofdeath = value; }
    }

   //----------- Loan Reciept ----------------

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Phname
    {
        get { return phname; }
        set { phname = value; }
    }
    public string Ad1
    {
        get { return ad1; }
        set { ad1 = value; }
    }
    public string Ad2
    {
        get { return ad2; }
        set { ad2 = value; }
    }
    public string Ad3
    {
        get { return ad3; }
        set { ad3 = value; }
    }
    public string Ad4
    {
        get { return ad4; }
        set { ad4 = value; }
    }
    public int LOANNUM
    {
        get { return LoanNum; }
        set { LoanNum = value; }
    }
    public int Rcptno
    {
        get { return rcptno; }
        set { rcptno = value; }
    }
    public double LMNCP_LMCPYprop
    {
        get { return LMNCP_LMCPY; }
        set { LMNCP_LMCPY = value; }
    }
    public double LMIPY01prop
    {
        get { return LMIPY01; }
        set { LMIPY01 = value; }
    }
    public long ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }
    public string Cof
    {
        get { return cof; }
        set { cof = value; }
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

    protected int dateAdd(int theDate, int years, int months, int days) 
    {
        int year = int.Parse(theDate.ToString().Substring(0, 4));
        int month = int.Parse(theDate.ToString().Substring(4, 2));
        int day = int.Parse(theDate.ToString().Substring(6, 2));

        int oneOfThree = 0;

        bool condition = true;
        int loopCount = 0;

        if ((days > 31) && ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 12)))
        {
            oneOfThree = 31;
        }
        else if ((days > 30) && ((month == 4) || (month == 6) || (month == 9) || (month == 11)))
        {
            oneOfThree = 30;
        }
        else if ((days > 28) && (month == 2))
        {
            oneOfThree = 28;
        }
        else 
        {
            //oneOfThree = days;
            #region
            year += years;
            if (months > 12) 
            {
                year += (int)(months /12);
                months %= 12;
                month += months;
                if (month > 12)
                {
                    year++;
                    month -= 12;
                }
                day += days;
                #region
                if ((days > 31) && ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 12)))
                {
                    day -= 31; month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else if ((days > 30) && ((month == 4) || (month == 6) || (month == 9) || (month == 11)))
                {
                    day -= 30; month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else if ((days > 28) && (month == 2))
                {
                    day -= 28; month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                #endregion
            }
            else
            {
                month += months;
                if (month > 12)
                {
                    year++;
                    month -= 12;
                }
                day += days;
                #region
                if ((days > 31) && ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 12)))
                {
                    day -= 31; month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else if ((days > 30) && ((month == 4) || (month == 6) || (month == 9) || (month == 11)))
                {
                    day -= 30; month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else if ((days > 28) && (month == 2))
                {
                    day -= 28; month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                #endregion
            }
            #endregion
            condition = false;
        }

        #region
        
        while (condition)
        {
            loopCount++;
            if (loopCount == 1)
            {
                int remainingDaysOfMonth = oneOfThree - day;
                days -= remainingDaysOfMonth;
                month++;
            }
            else
            {
                if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 12))
                {
                    days -= 31; month++;
                }
                else if ((month == 4) || (month == 6) || (month == 9) || (month == 11))
                {
                    days -= 30; month++;
                }
                else if ((month == 2))
                {
                    days -= 28; month++;
                }
            }

            if (month > 12) { month = 1; year++; }
            if ((days <= 28) && (month == 2))
            {
                #region
                year += years;
                if (months > 12)
                {
                    year += (int)(months / 12);
                    months %= 12;
                    month += months;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else
                {
                    month += months;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                #endregion
                day = days;
                condition = false;
            }
            else if ((days <= 30) && ((month == 4) || (month == 6) || (month == 9) || (month == 11)))
            {
                #region
                year += years;
                if (months > 12)
                {
                    year += (int)(months / 12);
                    months %= 12;
                    month += months;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else
                {
                    month += months;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                #endregion
                day = days;
                condition = false;
            }
            else if ((days <= 31) && ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12)))
            {
                #region
                year += years;
                if (months > 12)
                {
                    year += (int)(months / 12);
                    months %= 12;
                    month += months;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                else
                {
                    month += months;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }
                }
                #endregion
                day = days;               
                condition = false;
            }
            else
            {
                condition = true;
            }
        }

        #endregion

        string monthStr = "";
        string dayStr = "";
        
        if (month >= 10) { monthStr = month.ToString(); }
        else { monthStr = "0" + month.ToString(); }
        if (day >= 10) { dayStr = day.ToString(); }
        else { dayStr = "0" + day.ToString(); }

        int retunDate = int.Parse(year.ToString() + monthStr + dayStr);
        return retunDate;
    
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
       
    
    protected void btnloanreciept_Click(object sender, EventArgs e)
    {

    }
}
