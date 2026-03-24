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
using System.Net;
using System.Web.Configuration;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Odbc;

public partial class dthReg002 : System.Web.UI.Page 
{
    private int polno;
    private string MOF;
    private int dateofdeath;    
   
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
    private long claimNo = 0;
    private string cof;
    private string Intdate;//...2009/05/22 for death intimation date by Buddhika
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
    //private double tempkkkkk;
    private double LMIPY01;
    private string EPF = "";
    private string nominame;
    private double percentage;
    private string Address;
    private string NIC;
    private string EnterEPF;
    private int EDate;

    private double newpercentage = 0;
    private double NomPer = 0;

    private string pnominame;
    private double ppercentage;
    private string pNIC;
    private string pEnterEPF;
    private string pEDate;

    private int AutEPF;
    private int ADate; 

    //******* variables for DTHREF ***************

    private long ADB;
    private long FPU;
    private long SJ;
    private long FE;
    private string ageAdmitYN = "";
    private long dateOfBirth = 0;
    private double fullAge = 0;
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
    public string hasLoan = "N";
   
    public int LoanCommencementDate=0;
    public double CapitalToBePaid = 0, InterestToBePaid = 0, InterestAsAtDeath = 0, CapitalAsAtDeath = 0;
   // double loaninterest = 0;
    private string isFuterePremWaivedOff;
    private int benefitPeriod;
    private string matClaimNo = "";
    private string vouType = "";
    private string branchId;
    private string branchName;
    private int dthclaimNo = 0;
    DataManager dthintobj;
    Table56 table56;
    AMLDesignatedPerson amlDesignated;

    private int havePayment;
    private string havePaymentWarring;
    private DateDifference datediffobj;

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

    //DataManager dthRegObj;
    //LoanBackCal loanbackobj;

    protected void Page_Load(object sender, EventArgs e)   
    {
        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
            branchId = Session["brcode"].ToString();
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
            dthintobj = new DataManager();
            using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
            {
                try
                {
                    dateValidation dv = new dateValidation();
                    if (!dv.dateValid(dateofdeath.ToString())) { throw new Exception("Invalid Date of Death"); }
                    branch = int.Parse(Session["brcode"].ToString());

                    #region  ------------- DTHINT - Read Death intimation details ----------------
                    string dthintSelect = @"select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4,
                            ditel, dinforel, dclm, dsta, dconfst, dcof,to_char(DENTDATE,'yyyyMMdd') from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "'  ";
                    if (!dal.IsRecordExist(dthintSelect))
                    {
                        throw new Exception("No Death Intimation Details!");
                    }
                    else
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthintSelect))
                        {
                            using (DataTableReader dthintREADER = dataTable.CreateDataReader())
                            {
                                while (dthintREADER.Read())
                                {
                                    infodat =Convert.ToInt32(dthintREADER[0]); // informed Date                          

                                    if (!dthintREADER.IsDBNull(11)) { infotel = Convert.ToInt64(dthintREADER[11]); } else { infotel = 0; }
                                    if (!dthintREADER.IsDBNull(1)) { polstat = dthintREADER.GetString(1); } else { polstat = ""; }
                                    if (!dthintREADER.IsDBNull(2)) { nameOfDead = dthintREADER.GetString(2); } else { nameOfDead = ""; }
                                    if (!dthintREADER.IsDBNull(3)) { dateofdeath = Convert.ToInt32(dthintREADER[3]); }
                                    if (!dthintREADER.IsDBNull(4)) { methofInfo = dthintREADER.GetString(4); } else { methofInfo = ""; }
                                    if (!dthintREADER.IsDBNull(5)) { infoid = dthintREADER.GetString(5); } else { infoid = ""; }
                                    if (!dthintREADER.IsDBNull(6)) { infoname = dthintREADER.GetString(6); } else { infoname = ""; }
                                    if (!dthintREADER.IsDBNull(7)) { infoad1 = dthintREADER.GetString(7); } else { infoad1 = ""; }
                                    if (!dthintREADER.IsDBNull(8)) { infoad2 = dthintREADER.GetString(8); } else { infoad2 = ""; }
                                    if (!dthintREADER.IsDBNull(9)) { infoad3 = dthintREADER.GetString(9); } else { infoad3 = ""; }
                                    if (!dthintREADER.IsDBNull(10)) { infoad4 = dthintREADER.GetString(10); } else { infoad4 = ""; }
                                    if (!dthintREADER.IsDBNull(12)) { inforel = dthintREADER.GetString(12); } else { inforel = ""; }
                                    if (!dthintREADER.IsDBNull(13)) { claimNo = Convert.ToInt64(dthintREADER[13]); } else { claimNo = 0; }
                                    if (!dthintREADER.IsDBNull(15)) { confst = dthintREADER.GetString(15); } else { confst = ""; }
                                    if (!dthintREADER.IsDBNull(16)) { cof = dthintREADER.GetString(16); } else { cof = ""; }
                                    if (!dthintREADER.IsDBNull(17)) { Intdate = dthintREADER.GetString(17); } //...2009/05/22 for death intimation date by Buddhika
                                }
                            }
                        }
                    }

                    if (confst.Equals("Y")) 
                    { 
                        this.btnregister.Enabled = false; 
                        if(int.Parse(Session["brcode"].ToString()) == 10)
                        {
                            btnupdateCuse.Visible = true;
                        }
                    }
                    else { this.btnregister.Enabled = true; btnupdateCuse.Visible = false; }

                    if (int.Parse(Session["brcode"].ToString()) == 10)
                    {
                        pnlCauseOfDeath.Visible = true;
                    }
                    else
                    {
                        pnlCauseOfDeath.Visible = false;
                    }
                    
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

                    #region   ****************** PHNAME - REad policy Holreds name and address *******************************************
                    string phname1 = "", phname2 = "", phname3 = "";
                    string sql = "select  pnsta, pnint, PNSUR, pnad1, pnad2, pnad3, pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(sql))
                    {
                        using (DataTableReader oraDtReader = dataTable.CreateDataReader())
                        {
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

                                if (!oraDtReader.IsDBNull(3)) { ad1 = (oraDtReader.GetString(3)); } else { ad1 = ""; }
                                if (!oraDtReader.IsDBNull(4)) { ad2 = (oraDtReader.GetString(4)); } else { ad2 = ""; }
                                if (!oraDtReader.IsDBNull(5)) { ad3 = (oraDtReader.GetString(5)); } else { ad3 = ""; }
                                if (!oraDtReader.IsDBNull(6)) { ad4 = (oraDtReader.GetString(6)); } else { ad4 = ""; }

                            }
                        }

                    }

                    this.lblnameofInsured.Text = phname;
                    this.lblassuredad1.Text = ad1 + " " + ad2;
                    this.lblassuredad2.Text = ad3 + " " + ad4;
                    #endregion

                    #region--------------------------- AGE AT ENTRY -------------------------------------------------------------
                    //Task 36304
                    string agesql = "";
                    if(MOF.Equals("M") || MOF.Equals("S") || MOF.Equals("C"))
                    {
                        if (MOF.Equals("M"))
                        {
                            agesql = "select age,ageproof,dob from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=1";
                        }
                        else if (MOF.Equals("S"))
                        {
                            agesql = "select age,ageproof,dob from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=2 union " +
                                "select age,ageproof,dob from LUND.POLPERSONAL_HISTORY where polno='" + polno + "' and prpertype=2 and " +
                                "SQNO = (select MAX(SQNO) from LUND.POLPERSONAL_HISTORY where polno='" + polno + "' and prpertype = 2 )";
                        }
                        else if (MOF.Equals("C"))
                        {
                            agesql = "select age,ageproof,dob from LUND.POLPERSONAL where polno='" + polno + "' and prpertype=4 union " +
                                "select age,ageproof,dob from LUND.POLPERSONAL_HISTORY where polno='" + polno + "' and prpertype=4 and " +
                                "SQNO = (select MAX(SQNO) from LUND.POLPERSONAL_HISTORY where polno='" + polno + "' and prpertype = 4 )";
                        }

                        using (DataTable dataTable = dal.ReadSQLtoDataTable(agesql))
                        {
                            using (DataTableReader agereader = dataTable.CreateDataReader())
                            {
                                while (agereader.Read())
                                {
                                    if (!agereader.IsDBNull(0)) { ageatentry = Convert.ToInt32(agereader[0]); } else { ageatentry = 0; }
                                    if (!agereader.IsDBNull(1)) { ageAdmitYN = agereader.GetString(1); } else { ageAdmitYN = ""; }
                                    if (!agereader.IsDBNull(2)) { dateOfBirth = Convert.ToInt64(agereader[2]); } else { dateOfBirth = 0; }
                                }
                            }
                        }
                    }

                    #endregion

                    #region--------------------------- Policy History ----------------------------------------------------------
                    //42488
                    string jpolhisSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, lpmod, LPCOD, LPPAC from lphs.jpolhis where lppol= " + polno + " and pdat=(select min(pdat) from lphs.jpolhis where lppol = " + polno + "  and pdat > " + dateofdeath + " )";
                    string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue, pmmod, PMCOD, PMPAC from lphs.premast where pmpol=" + polno + " ";
                    string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, lpmod, LPCOD, LPPAC from lphs.liflaps where lppol=" + polno + " ";
                    string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phmod , PHCOD, PHPAC, phsta from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                    string polhisSelect2 = "select phsum, phtbl, phtrm, phcom, phdue, phmod , PHCOD, PHPAC, phsta from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = 'M' ";
                    string query = "";
                    //42488
                    if (dal.IsRecordExist(jpolhisSelect))
                    { query = jpolhisSelect; }
                    else if (dal.IsRecordExist(premastSelect))
                    { query = premastSelect; }
                    else if (dal.IsRecordExist(liflapsSelect))
                    { query = liflapsSelect; }
                    else if (dal.IsRecordExist(polhisSelect))
                    { query = polhisSelect; }
                    else if (dal.IsRecordExist(polhisSelect2) && (MOF.Equals("S") || MOF.Equals("2")))
                    { query = polhisSelect2; }
                    else
                    { throw new Exception("No Policy Details!"); }

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(query))
                    {
                        using (DataTableReader premReader = dataTable.CreateDataReader())
                        {
                            while (premReader.Read())
                            {
                                if (!premReader.IsDBNull(0)) { sumassured = Convert.ToDouble(premReader[0]); } else { sumassured = 0; }
                                if (!premReader.IsDBNull(1)) { table = Convert.ToInt32(premReader[1]); } else { table = 0; }
                                if (!premReader.IsDBNull(2)) { term = Convert.ToInt32(premReader[2]); } else { term = 0; }
                                if (!premReader.IsDBNull(3)) { dateofComm = Convert.ToInt32(premReader[3]); } else { dateofComm = 0; }
                                if (!premReader.IsDBNull(4)) { DUE = Convert.ToInt32(premReader[4]); } else { DUE = 0; }
                                if (!premReader.IsDBNull(5)) { MOD = Convert.ToInt32(premReader[5]); } else { MOD = 0; }
                                if (!premReader.IsDBNull(6)) { COD = premReader[6].ToString(); } else { COD = ""; }
                                if (!premReader.IsDBNull(7)) { PAC = Convert.ToInt32(premReader[7]); } else { PAC = 0; }
                            }
                        }
                    }

                    #endregion

                    //Table 56 changes
                    string planDetails = "select BENEFIT_PERIOD from lund.tabnam where tdtabl=" + table + "";
                    if (dthintobj.existRecored(planDetails) != 0)
                    {
                        dthintobj.readSql(planDetails);
                        OracleDataReader planReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (planReader.Read())
                        {
                            if (!planReader.IsDBNull(0)) { benefitPeriod = planReader.GetInt32(0); } else { benefitPeriod = 0; }
                        }
                        planReader.Close();
                        planReader.Dispose();
                    }

                    #region------------Update Policy Status------------------------
                    //..............................................table 55 changes
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
                    #region ------------- Health Product Changes ------------
                    //if (table == 64)
                    //{
                    //    string tab = "";
                    //    string lpolhisSelect = "select PHMOS from lphs.lpolhis where phpol=" + polno + " ";

                    //    if (dthintobj.existRecored(lpolhisSelect) != 0)
                    //    {
                    //        dthintobj.readSql(lpolhisSelect);
                    //        OracleDataReader lpolhisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //        lpolhisReader.Read();
                    //        tab = lpolhisReader.GetString(0);
                    //        lpolhisReader.Close();
                    //        lpolhisReader.Dispose();
                    //    }
                    //    if (tab == "M")
                    //    {
                    //        string lpolhisSelectTable = "select PHTBL from lphs.lpolhis where phpol=" + polno + " ";

                    //        if (dthintobj.existRecored(lpolhisSelectTable) != 0)
                    //        {
                    //            dthintobj.readSql(lpolhisSelectTable);
                    //            OracleDataReader lpolhisTableReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //            lpolhisTableReader.Read();
                    //            table = lpolhisTableReader.GetInt32(0);
                    //            lpolhisTableReader.Close();
                    //            lpolhisTableReader.Dispose();
                    //        }
                    //    }
                    //}
                    //if (table == 55) //remove specific to plan 55  #44917
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
                    //    if (!dal.IsRecordExist(rcovSelect))
                    //    {
                    //        throw new Exception("No Cover Details!");
                    //    }
                    //    else
                    //    {
                    //        using (DataTable dataTable = dal.ReadSQLtoDataTable(rcovSelect))
                    //        {
                    //            using (DataTableReader rcovREADER = dataTable.CreateDataReader())
                    //            {
                    //                while (rcovREADER.Read())
                    //                {
                    //                    if (!rcovREADER.IsDBNull(0)) { sumassured = Convert.ToDouble(rcovREADER[0]); } else { sumassured = 0; }
                    //                    if (!rcovREADER.IsDBNull(1)) { dateofComm = Convert.ToInt32(rcovREADER[1]); } else { dateofComm = 0; }
                    //                    if (!rcovREADER.IsDBNull(2)) { term = Convert.ToInt32(rcovREADER[2]); } else { term = 0; }
                    //                }
                    //            }
                    //        }
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
                        string rcovHisSelect = @"select rsumas, rcomdat,rterm from LUND.RCOVER_HISTORY where rpol=" + polno + " and rcovr=" + rcov + " and entry_date>to_date(" + dateofdeath + ",'yyyy/MM/dd')";
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
                        else //#44917 if no cover details, give exception
                        {
                            throw new Exception("No Cover Details!");
                        }
                        #endregion
                    //}
                    #endregion

                    //Task 29280
                    if (term == 0 && table == 1)
                    {
                        term = 99;
                    }

                    //-----------------------------------------------------------------------------------------------------
                   General gg = new General();
                  //polstat = gg.policyStatusAtDeath(dal, polno, dateofdeath, MOD, table, dateofComm, PAC, COD); //gg.policyStatusAtDeath(dal, polno, dateofdeath, dal, MOD, table, dateofComm, PAC, COD);
                   polstat = gg.LapsetoInforce(dal, polno, dateofdeath, table, dateofComm, MOD, PAC, COD, term, MOF);
                    

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
                        DUE = gg.Duedate; 
                        int dueYMD = int.Parse(DUE.ToString() + dateofComm.ToString().Substring(6, 2));
                        polDuraYrs = this.dateComparison(dateofComm, dueYMD)[0];
                        polDuraMnths = this.dateComparison(dateofComm, dueYMD)[1];
                        polDuraDays = this.dateComparison(dateofComm, dueYMD)[2];
                        if (polDuraDays > 15)
                        {
                            polDuraMnths++;
                            if (polDuraMnths >= 12)
                            { polDuraMnths = 0; polDuraYrs++; }
                        }

                    }
                    this.lbldtofexit.Text = DUE.ToString().Substring(0, 4) + "/" + DUE.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);

                    this.lblpolicyDuratn.Text = polDuraYrs.ToString() + " Yrs " + polDuraMnths.ToString() + " Months";

                    #endregion

                    #region--------------------------- validating life type availability -----------------------------------
                     string MAIN_LIFE = "", SPOUCE = "", SECOND_LIFE = "", CHILD = "", IS_CHILD = "";
                     string tabcoversel = "select MAIN_LIFE, SPOUCE, SECOND_LIFE, CHILD, IS_CHILD_SECOND_LIFE, IS_FUTERPREM_WAIVEDOFF from LUND.TAB_COVERS where TAB_ID = " + table + "  ";
                    if (dal.IsRecordExist(tabcoversel))
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(tabcoversel))
                        {
                            using (DataTableReader tabcoverReader = dataTable.CreateDataReader())
                            {
                                while (tabcoverReader.Read())
                                {
                                    if (!tabcoverReader.IsDBNull(0)) { MAIN_LIFE = tabcoverReader.GetString(0); } else { MAIN_LIFE = ""; }
                                    if (!tabcoverReader.IsDBNull(1)) { SPOUCE = tabcoverReader.GetString(1); } else { SPOUCE = ""; }
                                    if (!tabcoverReader.IsDBNull(2)) { SECOND_LIFE = tabcoverReader.GetString(2); } else { SECOND_LIFE = ""; }
                                    if (!tabcoverReader.IsDBNull(3)) { CHILD = tabcoverReader.GetString(3); } else { CHILD = ""; }
                                    if (!tabcoverReader.IsDBNull(4)) { IS_CHILD = tabcoverReader.GetString(4); } else { IS_CHILD = ""; }
                                    if (!tabcoverReader.IsDBNull(5)) { isFuterePremWaivedOff = tabcoverReader.GetString(5); } else { isFuterePremWaivedOff = ""; }
                                }
                            }

                        }

                        if (MOF.Equals("M") && MAIN_LIFE.Equals("N")) { throw new Exception("This Life Type is not Available for this Table"); }
                        else if (MOF.Equals("S") && SPOUCE.Equals("N")) { throw new Exception("This Life Type is not Available for this Table"); }
                        //else if (MOF.Equals("2") && (SECOND_LIFE.Equals("N") || CHILD.Equals("N"))) { throw new Exception("This Life Type is not Available for this Table"); }
                        else if ((MOF.Equals("2") && SECOND_LIFE.Equals("N")) && (MOF.Equals("2") && IS_CHILD.Equals("N"))) { throw new Exception("This Life Type is not Available for this Table"); }
                        else if ((MOF.Equals("C") && CHILD.Equals("N")) && (MOF.Equals("C") && IS_CHILD.Equals("Y"))) { throw new Exception("This Life Type is not Available for this Table"); }
                    }
                    #endregion

                    #region--------------------------- calculating Age at Death -------
                    //if (MOF.Equals("M") || MOF.Equals("S")) //Task 36304
                     if (MOF.Equals("M") || MOF.Equals("S") || MOF.Equals("C")) //child age also required in case of 49
                    {
                        int duratn = int.Parse(this.setDate()[0].Substring(0, 4)) - int.Parse(dateofComm.ToString().Substring(0, 4));
                        int mnthdiff = int.Parse(this.setDate()[0].Substring(4, 2)) - int.Parse(dateofComm.ToString().Substring(4, 2));
                        if (mnthdiff > 6) { duratn++; }
                        else if (mnthdiff < -6) { duratn--; }

                        this.lblageatentstr.Visible = true;
                        this.lblageatentry.Visible = true;
                        this.lblageatdthstr.Visible = true;
                        this.lblageatdth.Visible = true;
                        this.lblageatentstrDOB.Visible = true;
                        this.lblageatentryDOB.Visible = true;
                        this.lblageatdthstrFull.Visible = true;
                        this.lblageatdthFull.Visible = true;
                        this.lblageatentry.Text = ageatentry.ToString();
                        int addtoAgeAtEntry = this.dateComparison(dateofComm, dateofdeath)[0];
                        //this.lblageatdth.Text = (ageatentry + duratn).ToString();
                        this.lblageatdth.Text = (ageatentry + addtoAgeAtEntry).ToString();
                        string tmpdod = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                        if (dateOfBirth > 0)
                        {
                            string tmpDOB = dateOfBirth.ToString().Substring(0, 4) + "/" + dateOfBirth.ToString().Substring(4, 2) + "/" + dateOfBirth.ToString().Substring(6, 2);
                            this.lblageatentryDOB.Text = tmpDOB;
                            this.lblageatdthFull.Text = GetFullAge(tmpDOB, tmpdod).ToString();
                        }
                        else 
                        {
                           this.lblageatentryDOB.Text = "Not Entered";
                           this.lblageatdthFull.Text = "NO";
                        
                        }



                    }
                    #endregion

                    //#region ------------- Health Product Changes ------------
                    ////if (table == 64)
                    ////{
                    ////    string tab = "";
                    ////    string lpolhisSelect = "select PHMOS from lphs.lpolhis where phpol=" + polno + " ";

                    ////    if (dthintobj.existRecored(lpolhisSelect) != 0)
                    ////    {
                    ////        dthintobj.readSql(lpolhisSelect);
                    ////        OracleDataReader lpolhisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    ////        lpolhisReader.Read();
                    ////        tab = lpolhisReader.GetString(0);
                    ////        lpolhisReader.Close();
                    ////        lpolhisReader.Dispose();
                    ////    }
                    ////    if (tab == "M")
                    ////    {
                    ////        string lpolhisSelectTable = "select PHTBL from lphs.lpolhis where phpol=" + polno + " ";

                    ////        if (dthintobj.existRecored(lpolhisSelectTable) != 0)
                    ////        {
                    ////            dthintobj.readSql(lpolhisSelectTable);
                    ////            OracleDataReader lpolhisTableReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    ////            lpolhisTableReader.Read();
                    ////            table = lpolhisTableReader.GetInt32(0);
                    ////            lpolhisTableReader.Close();
                    ////            lpolhisTableReader.Dispose();
                    ////        }
                    ////    }
                    ////}
                    //if (table == 55)
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
                    //    if (!dal.IsRecordExist(rcovSelect))
                    //    {
                    //        throw new Exception("No Cover Details!");
                    //    }
                    //    else
                    //    {
                    //        using (DataTable dataTable = dal.ReadSQLtoDataTable(rcovSelect))
                    //        {
                    //            using (DataTableReader rcovREADER = dataTable.CreateDataReader())
                    //            {
                    //                while (rcovREADER.Read())
                    //                {
                    //                    if (!rcovREADER.IsDBNull(0)) { sumassured = Convert.ToDouble(rcovREADER[0]); } else { sumassured = 0; }
                    //                    if (!rcovREADER.IsDBNull(1)) { dateofComm = Convert.ToInt32(rcovREADER[1]); } else { dateofComm = 0; }
                    //                    if (!rcovREADER.IsDBNull(2)) { term = Convert.ToInt32(rcovREADER[2]); } else { term = 0; }
                    //                }
                    //            }
                    //        }
                    //    }
                    //    #endregion
                    //}
                    //else
                    //{
                    //    #region  ------------- RCover - SA, COM DATE & Term details ----------------
                    //    int rcov = 0;
                    //    if (MOF == "S")
                    //    {
                    //        rcov = 101;
                    //    }
                    //    else
                    //    {
                    //        rcov = 1;
                    //    }
                    //    string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                    //    string rcovHisSelect = @"select rsumas, rcomdat,rterm from LUND.RCOVER_HISTORY where rpol=" + polno + " and rcovr=" + rcov + " and entry_date>to_date(" + dateofdeath + ",'yyyy/MM/dd')";
                    //    if (dthintobj.existRecored(rcovSelect) != 0)
                    //    {
                    //        dthintobj.readSql(rcovSelect);
                    //        OracleDataReader rcovReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //        rcovReader.Read();
                    //        sumassured = rcovReader.GetDouble(0);

                    //        //Task 25983
                    //        dateofComm = rcovReader.GetInt32(1);
                    //        term = rcovReader.GetInt32(2);

                    //        rcovReader.Close();
                    //        rcovReader.Dispose();
                    //    }
                    //    else if (dthintobj.existRecored(rcovHisSelect) != 0)
                    //    {
                    //        dthintobj.readSql(rcovHisSelect);
                    //        OracleDataReader rcovHisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //        rcovHisReader.Read();
                    //        sumassured = rcovHisReader.GetDouble(0);

                    //        //Task 25983
                    //        dateofComm = rcovHisReader.GetInt32(1);
                    //        term = rcovHisReader.GetInt32(2);

                    //        rcovHisReader.Close();
                    //        rcovHisReader.Dispose();
                    //    }
                    //    #endregion
                    //}
                    //#endregion

                    this.lblsumassured.Text = "Rs." + String.Format("{0:N}", sumassured);
                    this.lbltab.Text = table.ToString();
                    this.lblterm.Text = term.ToString();
                    this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);

                    bool existflag = false;

                    #region--------------------------- DTHREF -------------------------------------------------------------
                    string payee = "";
                    string CAUSEOFDEATHSTR = "";
                    string CAUSEOFDEATH = "0";
                    string dthrefSel = "select DRAGEADMIT, DRRINSYN, DRREVIVALS, DRASSIGNEENOM, PAYEE, PAYAUTDT, DRBONSURRAMT, DRBONSURRYR,AGE_AMT,AGEDIFINRST,DRCLMNO,CAUSEOFDEATHSTR,DCAUSEOFDTH from LPHS.DTHREF  where drpolno=" + polno + " and drmos='" + MOF + "' ";
                    if (dal.IsRecordExist(dthrefSel))
                    {
                        existflag = true;
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrefSel))
                        {
                            using (DataTableReader dthrefreader = dataTable.CreateDataReader())
                            {
                                while (dthrefreader.Read())
                                {
                                    if(ageAdmitYN == "" || ageAdmitYN == null)
                                    {
                                        if (!dthrefreader.IsDBNull(0)) { ageAdmitYN = dthrefreader.GetString(0); } else { ageAdmitYN = ""; }
                                    }
                                    
                                    if (!dthrefreader.IsDBNull(2)) { revivalsYN = dthrefreader.GetString(2); } else { revivalsYN = ""; }
                                    if (!dthrefreader.IsDBNull(3)) { assNomYN = dthrefreader.GetString(3); } else { assNomYN = ""; }
                                    if (!dthrefreader.IsDBNull(4)) { payee = dthrefreader.GetString(4); } else { payee = ""; }
                                    if (!dthrefreader.IsDBNull(5)) { payautDt = Convert.ToInt32(dthrefreader[5]); } else { payautDt = 0; }
                                    if (!dthrefreader.IsDBNull(6)) { surrrenderedbons = Convert.ToDouble(dthrefreader[6]); } else { surrrenderedbons = 0; }
                                    if (!dthrefreader.IsDBNull(7)) { bonussurrYr = Convert.ToInt32(dthrefreader[7]); } else { bonussurrYr = 0; }
                                    if (!dthrefreader.IsDBNull(8)) { ageAdmitAmt = Convert.ToDouble(dthrefreader[8]); TxtAgeEntry.Text = String.Format("{0:N}", ageAdmitAmt); } else { ageAdmitAmt = 0; }//...add by buddhika 2009/03/23....
                                    if (!dthrefreader.IsDBNull(9)) { ageEntryInter = Convert.ToDouble(dthrefreader[9]); TxtAgeEntryInter.Text = String.Format("{0:N}", ageEntryInter); } else { ageEntryInter = 0; }//...add by buddhika 2009/04/7....
                                    if (!dthrefreader.IsDBNull(10)) { dthclaimNo = Convert.ToInt32(dthrefreader[10]);  } else { dthclaimNo = 0; }//...task 36203....
                                    if (!dthrefreader.IsDBNull(11)) { CAUSEOFDEATHSTR = dthrefreader.GetString(11); } else { CAUSEOFDEATHSTR = ""; }
                                    if (!dthrefreader.IsDBNull(12)) { CAUSEOFDEATH = dthrefreader.GetDecimal(12).ToString(); } else { CAUSEOFDEATH = "0"; }
                                }
                            }
                        }
                    }
                    if ((CAUSEOFDEATHSTR == null) || (CAUSEOFDEATHSTR.Equals(""))) { this.txtcauseStr.Text = ""; } else { this.txtcauseStr.Text = CAUSEOFDEATHSTR;}
                    DropDownList1.SelectedValue = CAUSEOFDEATH.ToString();
                    #endregion

                    #region--------------------------- validating the spouce cover and Child cover  availability -----------

                    if ((table == 42 || table == 45 || table == 34) && (MOF.Equals("S")))
                    { throw new Exception("Tables 45, 42, 34 Does not consist Spouse Cover"); }
                    if ((table != 34 && table != 38 && table != 39 && table != 46 && table != 49 && table != 56) && (MOF.Equals("C")))
                    { throw new Exception("No Child Cover for tables other than 34, 38, 39, 46, 49, 56"); }
                    #endregion

                    //Table 56 Changes
                    #region ---------------------- Check Repudation -----------------------------
                    if (table == 56 && MOF != "M")
                    {
                        bool isRepudation = false;
                        string dthrepSel = "select * from LPHS.DTH_REPUDIATION  where policyno=" + polno + " and life_type='M' ";

                        if (dal.IsRecordExist(dthrepSel))
                        {
                            using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrepSel))
                            {
                                using (DataTableReader dthrepreader = dataTable.CreateDataReader())
                                {
                                    while (dthrepreader.Read())
                                    {
                                        isRepudation = true;
                                    }
                                }
                            }
                        }

                        if (isRepudation)
                        {
                            throw new Exception("There is a Main Life Repudiation Claim, Regarding this policy.");
                        }
                    } 
                    #endregion

                    #region--------------------------- drop down lists and buttons -----------------------------------------

                    if (ageAdmitYN.Equals("Y"))
                    {
                        this.ddlageadmit.Items.Add(new ListItem("Yes", "Y"));
                        this.ddlageadmit.Enabled = false;
                        TxtAgeEntry.ReadOnly = false;//..add by buddhika 2009/03/23....
                        TxtAgeEntryInter.ReadOnly = false;//..add by buddhika 2009/04/07....
                    }
                    else if (ageAdmitYN.Equals("N") || string.IsNullOrEmpty(revivalsYN))
                    {
                        this.ddlageadmit.Items.Add(new ListItem("No", "N"));
                        this.ddlageadmit.Enabled = false;
                        TxtAgeEntry.ReadOnly = true;//...add by buddhika 2009/03/23....
                        TxtAgeEntryInter.ReadOnly = true;//...add by buddhika 2009/04/7....
                    }
                    //else
                    //{
                    //    this.ddlageadmit.Items.Add(new ListItem("--Select--", "-1"));
                    //    this.ddlageadmit.Items.Add(new ListItem("No", "N"));
                    //    this.ddlageadmit.Items.Add(new ListItem("Yes", "Y"));
                       
                    //}



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




                    #endregion
                    if (MOF.Equals("M"))
                    {
                        #region--------------------------- Showing Loans -------------------------------------------------------
                        //task 36203
                        string loansql = "";
                        if (dthclaimNo != 0)
                        {
                            loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1, LMICP,drloncap,drloanint  from lphs.lplmast lm,lphs.dthref ld  where lmpol=drpolno and lmpol=" + polno + " and lmlon=(select max(lmlon) from lphs.lplmast where lmpol=" + polno + ")";

                        }
                        else
                        {
                            loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1, LMICP  from lphs.lplmast where lmpol=" + polno + " and (nvl(trim(lmset),'N') <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                        }
                        
                        int caldate = int.Parse(this.setDate()[0]);
                        int rows = 0;
                        double loantotal = 0;
                        double loaninttot = 0;
                        int lmcdt = 0;
                        if (dal.IsRecordExist(loansql))
                        {
                            ViewState["hasLoan"] = "Y";
                            existflag = true;
                            using (DataTable dataTable = dal.ReadSQLtoDataTable(loansql))
                            {
                                using (DataTableReader myloanreader = dataTable.CreateDataReader())
                                {
                                    while (myloanreader.Read())
                                    {
                                        if (!myloanreader.IsDBNull(0)) { LoanNum = Convert.ToInt32(myloanreader[0]); }
                                        if (!myloanreader.IsDBNull(13)) { lmcdt = Convert.ToInt32(myloanreader[13]); }
                                        ltrLoanNo.Text = LoanNum.ToString();
                                        ltrLoanGrantedDate.Text = myloanreader[13].ToString();
                                        ltrDateOfMaturity.Text = myloanreader[14].ToString();
                                        ltrCapitalGranted.Text = myloanreader[17].ToString();


                                        List<StoredProcedureInputParameters> inputParaList = new List<StoredProcedureInputParameters>();
                                        List<StoredProcedureInputParameters> outPutParaList = new List<StoredProcedureInputParameters>();

                                        inputParaList.Add(new StoredProcedureInputParameters("policyNumber", polno.ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("loanNumber", LoanNum.ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("dateOfDeath", dateofdeath.ToString()));

                                        outPutParaList.Add(new StoredProcedureInputParameters("InterestToBePaid", DatabaseAccessLayer.ParaType.Float, 12));
                                        outPutParaList.Add(new StoredProcedureInputParameters("CapitalToBePaid", DatabaseAccessLayer.ParaType.Float, 12));
                                        outPutParaList.Add(new StoredProcedureInputParameters("p_CapitalAsAtDeath", DatabaseAccessLayer.ParaType.Float, 12));
                                        outPutParaList.Add(new StoredProcedureInputParameters("p_InterestAsAtDeath", DatabaseAccessLayer.ParaType.Float, 12));

                                        List<StoredProcedureInputParameters> outPutList = dal.ExecuteSotredProcedure("lpay.life_functions.loanBackCalculationDisplay", inputParaList, outPutParaList);
                                        foreach (StoredProcedureInputParameters p in outPutList)
                                        {
                                            switch (p.ParamenterName)
                                            {
                                                case "InterestToBePaid":
                                                    InterestToBePaid = Convert.ToDouble(p.Value);
                                                    ltrInterestToBePaid.Text = String.Format("{0:N}", p.Value);
                                                    break;
                                                case "CapitalToBePaid":
                                                    CapitalToBePaid = Convert.ToDouble(p.Value);
                                                    ltrCapitalTobePaid.Text = String.Format("{0:N}", p.Value);
                                                    break;
                                                case "p_CapitalAsAtDeath":
                                                    CapitalAsAtDeath = Convert.ToDouble(p.Value);
                                                    ltrCapitalAsAtDeath.Text = String.Format("{0:N}", p.Value);
                                                    break;
                                                case "p_InterestAsAtDeath":
                                                    InterestAsAtDeath = Convert.ToDouble(p.Value);
                                                    ltrInterestAsAtDeath.Text = String.Format("{0:N}", p.Value);
                                                    break;
                                            }

                                            //, oracleCommand.Parameters[p.ParamenterName].Value));
                                            //p_InterestAsAtDeath := transferedInterest + InterestToBePaid ;
                                            //p_CapitalAsAtDeath := transferedCapital + CapitalToBePaid ;

                                        }
                                        ltrInterestPayment.Text = String.Format("{0:N}", (InterestAsAtDeath - InterestToBePaid));
                                        ltrCapitalPayement.Text = String.Format("{0:N}", (CapitalAsAtDeath - CapitalToBePaid));
                                        rows++;
                                    }

                                }
                            }
                        }
                        else
                        { ViewState["hasLoan"] = "N"; }

                        #endregion
                    }
                    else
                    {
                        ltrLoanNo.Text = "-";
                        ltrLoanGrantedDate.Text = "-";
                        ltrDateOfMaturity.Text = "-";
                        ltrCapitalGranted.Text = "-";
                        ltrInterestToBePaid.Text = "-";
                        ltrCapitalTobePaid.Text = "-";
                        ltrCapitalAsAtDeath.Text = "-";
                        ltrInterestAsAtDeath.Text = "-";
                        ltrInterestPayment.Text = "-";
                        ltrCapitalPayement.Text = "-";

                    }

                    //added by sindu
                    #region --------------------------- Showing Previous Nominees ----------------------------------------------------

                    int nomineeRow = 0;
                    string npEDate = "";
                    string nomineeSelect = "select ln.NOMNIC, ln.NOMNAM, ln.NOMPER,ln.ENTEPF,to_char(ln.ENTDATE,'yyyyMMdd')  from lund.nominee_temp ln where POLNO=" + polno + "";
                    if (dal.IsRecordExist(nomineeSelect))
                    {
                        this.Label3.Visible = true;
                        this.CreateTbHeaderPreviousNominee();
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(nomineeSelect))
                        {
                            using (DataTableReader nomReader = dataTable.CreateDataReader())
                            {
                                while (nomReader.Read())
                                {
                                    if (!nomReader.IsDBNull(0)) { pNIC = nomReader.GetString(0); } else { pNIC = "-"; }
                                    if (!nomReader.IsDBNull(1)) { pnominame = nomReader.GetString(1); } else { pnominame = "-"; }
                                    if (!nomReader.IsDBNull(2)) { ppercentage = Convert.ToDouble(nomReader[2]); } else { ppercentage = 0.0; }
                                    if (!nomReader.IsDBNull(3)) { pEnterEPF = nomReader.GetString(3); } else { pEnterEPF = "-"; }
                                    if (!nomReader.IsDBNull(4)) { pEDate = nomReader.GetString(4);  } else { pEDate = "-"; }

                                    if (pEDate != null || pEDate != "-")
                                    {
                                        npEDate = pEDate.ToString().Substring(0, 4) + "/" +
                                                  pEDate.ToString().Substring(4, 2) + "/" +
                                                  pEDate.ToString().Substring(6, 2);
                                    }

                                    this.createPreviousNomineeTable(pNIC, pnominame, ppercentage.ToString("0.00"), nomineeRow, pEnterEPF, npEDate);
                                    nomineeRow++;
                                }

                            }
                        }
                    }

                    #endregion
                    //...
                    #region --------------------------- Showing Nominees ----------------------------------------------------

                    int nomRow = 0;
                    string nEDate = "-", nADate = "-";

                    string maxEndosment = "select  * "
                        + " from lund.nominee ln left outer join LPHS.ENDORSE_POLICY_NONPREM lnt on ln.POLNO=lnt.POLICY_NO where ln.polno=" + polno + "";

                    if (dal.IsRecordExist(maxEndosment))
                    {
                        string maxEndosmentNum = "select nvl(max(ENDORSEMENT_NO),0) FROM LPHS.ENDORSE_POLICY_NONPREM where POLICY_NO=" + polno + "";

                        int imaxEndosmentNum = dal.CountRecords(maxEndosmentNum);

                        string nomSelect = "";
                        if (imaxEndosmentNum > 0)
                        {
                            nomSelect = "select  ln.NOMNIC ,ln.nomnam, ln.nomper,ln.ENTEPF,ln.ENTDATE, lnt.ENTRY_EPF,to_char(lnt.ENTRY_DATE,'yyyyMMdd') "
                               + " from lund.nominee ln left join LPHS.ENDORSE_POLICY_NONPREM lnt on ln.POLNO=lnt.POLICY_NO where ln.polno=" + polno + " AND ENDORSEMENT_NO=" + imaxEndosmentNum + "";
                        }
                        else
                        {
                            nomSelect = "select  ln.NOMNIC ,ln.nomnam, ln.nomper,ln.ENTEPF,ln.ENTDATE, lnt.ENTRY_EPF,to_char(lnt.ENTRY_DATE,'yyyyMMdd') "
                               + " from lund.nominee ln left join LPHS.ENDORSE_POLICY_NONPREM lnt on ln.POLNO=lnt.POLICY_NO where ln.polno=" + polno + "";
                        }

                        if (dal.IsRecordExist(nomSelect))
                        {
                            this.Label2.Visible = true;
                            this.CreateTbHeader();
                            using (DataTable dataTable = dal.ReadSQLtoDataTable(nomSelect))
                            {
                                using (DataTableReader nomReader = dataTable.CreateDataReader())
                                {
                                    while (nomReader.Read())
                                    {
                                        if (!nomReader.IsDBNull(0)) { NIC = nomReader.GetString(0); } else { NIC = "-"; }
                                        if (!nomReader.IsDBNull(1)) { nominame = nomReader.GetString(1); } else { nominame = "-"; }
                                        if (!nomReader.IsDBNull(2)) { percentage = Convert.ToDouble(nomReader[2]); } else { percentage = 0.0; } 
                                        if (!nomReader.IsDBNull(3)) { EnterEPF = nomReader.GetString(3); } else { EnterEPF = "-"; }
                                        if (!nomReader.IsDBNull(4)) { EDate = Convert.ToInt32(nomReader[4]); } else { EDate = 0; }
                                        if (!nomReader.IsDBNull(5)) { AutEPF = Convert.ToInt32(nomReader[5]); } else { AutEPF = 0; }
                                        if (!nomReader.IsDBNull(6)) { ADate = Convert.ToInt32(nomReader[6]); } else { ADate = 0; }
                                        //added by sindu 
                                        if (EDate > 0)
                                        {
                                            nEDate = EDate.ToString().Substring(0, 4) + "/" + EDate.ToString().Substring(4, 2) + "/" + EDate.ToString().Substring(6, 2);
                                        }
                                        if (ADate > 0)
                                        {
                                            nADate = ADate.ToString().Substring(0, 4) + "/" + ADate.ToString().Substring(4, 2) + "/" + ADate.ToString().Substring(6, 2);
                                        }
                                        //Modified by sindu 
                                        this.createNomineeTable(NIC, nominame, percentage.ToString("0.00"), nomRow, EnterEPF, nEDate, AutEPF.ToString(), nADate);
                                        nomRow++;

                                    }


                                }

                            }

                        }
                    }
                    //added by sindu 

                    string nullPercentageNominee = "select * from lund.nominee where polno=" + polno + " and nomper is null";
                    if (dal.IsRecordExist(nullPercentageNominee))
                    {
                        string qry = "update lund.nominee set nomper=" + NomPer + " where polno=" + polno + " and nomper is null";
                        dal.IsRecordExist(qry);
                    }
                                       

                    string NonPercentageNominee = "select * from lund.nominee where polno=" + polno + " and nomper=0";
                    if (dal.IsRecordExist(NonPercentageNominee))
                    {
                        string NonPercentageNomineecount = "select count(polno)   from lund.nominee where polno=" + polno + " and nomper=0";
                        double Nom = dal.CountRecords(NonPercentageNomineecount);

                        string selectNomineePercentage = "select * from lund.nominee where polno=" + polno + " and nomper>0";
                        if (dal.IsRecordExist(selectNomineePercentage))
                        {
                            string NomineePercentage = "select sum(nomper) from lund.nominee where polno=" + polno + " and nomper>0";
                            double nPercentage = dal.Count(NomineePercentage);
                            newpercentage += (100.00 - nPercentage) / Nom;
                        }
                        else
                        {
                            newpercentage += (100 / Nom);
                        }

                        string qry = "update lund.nominee set NOMPER=" + newpercentage + " where  POLNO=" + polno + "and nomper=0";
                        dal.IsRecordExist(qry);
                    }
                    //....... 
                     

                    #endregion

                    #region--------------------------- Showing Rider Covers ------------------------------------------------

                    string covername = "";
                    int rows2 = 0;
                    bool covervalid = false;
                    string rcoverSelect = "select rcovr, rsumas, rcomdat, rterm from lund.rcover where rpol=" + polno + " ";
                    if (dal.IsRecordExist(rcoverSelect) )
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(rcoverSelect))
                        {
                            using (DataTableReader rcoverReader = dataTable.CreateDataReader())
                            {
                                while (rcoverReader.Read())
                                {
                                    if (!rcoverReader.IsDBNull(0)) { covernum = Convert.ToInt32( rcoverReader[0]); } else { covernum = 0; }
                                    if (!rcoverReader.IsDBNull(1)) { coveramt = Convert.ToInt32(rcoverReader[1]); } else { coveramt = 0; }
                                    if (!rcoverReader.IsDBNull(2)) { comdat = Convert.ToInt32(rcoverReader[2]); } else { comdat = 0; }
                                    if (!rcoverReader.IsDBNull(3)) { covterm = Convert.ToInt32(rcoverReader[3]); } else { covterm = 0; }

                                    int covrExpire = int.Parse((int.Parse(dateofComm.ToString().Substring(0, 4)) + covterm).ToString() + dateofComm.ToString().Substring(4, 4));
                                    //if (covrExpire > dateofdeath)
                                    if ((covrExpire > dateofdeath) || (table == 56 && (dateofdeath >= dateofComm && dateofComm <= (covrExpire + (benefitPeriod * 10000)))))
                                    {
                                        string covernameSelect = "select rconam from lund.rcovrnam where rconum=" + covernum + " ";
                                        using (DataTable dataTable1 = dal.ReadSQLtoDataTable(covernameSelect))
                                        {
                                            using (DataTableReader coverNameReader = dataTable1.CreateDataReader())
                                            {
                                                while (coverNameReader.Read())
                                                {
                                                    if (!coverNameReader.IsDBNull(0)) { covername = coverNameReader.GetString(0); }
                                                }
                                            }
                                        }


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
                                            // Task 24806
                                            //if ((covernum == 202) || (covernum == 210) || (covernum == 211))
                                            //{
                                            //    this.createRiderCoverTable(covername, String.Format("{0:N}", (double)coveramt), rows2);
                                            //    rows2++;
                                            //    if (covernum == 202) { ADB = coveramt; }
                                            //    else if (covernum == 210) { SJ = coveramt; }
                                            //    else if ((table != 14) && (covernum == 111)) { FE = coveramt; }
                                            // }

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
                                }
                            }
                        }
                        if (MOF.Equals("M")) { this.lblcoverfor.Text = "Rider Benefits For Main Life"; }
                        else if (MOF.Equals("S")) { this.lblcoverfor.Text = "Rider Benefits For Spouse"; }
                        else { this.lblcoverfor.Text = "Rider Benefits For Second Life"; }

                    }
                    #endregion

                    #region --------------------------- Showing reinsurance -------------------------------------------------


                    string LREINSURselect = "select * from lphs.lreinsur where ripolno=" + polno + "";
                    if (dal.IsRecordExist(LREINSURselect))
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

                    #region --------------------------- Viewing Deposites ---------------------------------------------------
                    string depositsql = "select DPTAM from lpay.deposit where DPPOL=" + polno + " and nvl(dpdel,0) <> 1 and DPTAM > 0 ";
                    double tempDepo = 0;
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(depositsql))
                    {
                        using (DataTableReader depositreader = dataTable.CreateDataReader())
                        {
                            double depamount;
                            while (depositreader.Read())
                            {
                                depamount = 0;
                                if (!depositreader.IsDBNull(0)) { depamount = Convert.ToDouble(depositreader[0]); }
                                tempDepo += depamount;
                            }

                        }
                    }
                    deposit = tempDepo;
                    this.lbldeposits.Text = "Rs." + String.Format("{0:N}", deposit);
                    #endregion

                    #region--------------------------- Vested Bonus --------------------------------------------------------

                       //if (MOF.Equals("M") || childBonus)
                    //bonus will be given for table 49 if term>5 and child age>14 in case of child death (Dhanushka 2023/05/26)
                    //if (MOF.Equals("M"))

                    double tmp_ageFull=0;
                    double.TryParse(lblageatdthFull.Text, out tmp_ageFull);
                    if (MOF.Equals("M") || (MOF.Equals("C") && term > 5 && tmp_ageFull > 14 && table == 49))

                    {
                        double totbonus = 0;
                        int interimboncount = 0;
                        int yeardiff = 0;
                        int monthdiff = 0;
                        int lastpaymentY = 0;

                        int DCOym = int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                        if (polstat.Equals("I"))
                        {
                            yeardiff = int.Parse(dateofdeath.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                        }
                        else if (polstat.Equals("L"))
                        {
                            //yeardiff = int.Parse(DUE.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                            int multiplier = 0;
                            if (MOD == 1) { multiplier = 12; }
                            else if (MOD == 2) { multiplier = 6; }
                            else if (MOD == 3) { multiplier = 3; }
                            else if (MOD == 4) { multiplier = 1; }
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
                        // string incrementcountstrdclr = "";
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

                            using (DataTable dataTable = dal.ReadSQLtoDataTable(bonsql))
                            {
                                using (DataTableReader bonfilereader = dataTable.CreateDataReader())
                                {
                                    while (bonfilereader.Read())
                                    {
                                        flag = true;
                                        for (int j = 0; j < bonuscount; j++)
                                        {
                                            double annualbonus = 0;
                                            if (!bonfilereader.IsDBNull(j)) { annualbonus = Convert.ToDouble(bonfilereader[j]); }
                                            totbonus = totbonus + annualbonus;
                                            if (annualbonus == 0)
                                            {
                                                interimboncount++;
                                                break;
                                            }
                                            else { temp = annualbonus; }
                                        }
                                    }
                                }
                            }
                            if (!flag)
                            { totbonus = 0; }
                        }
                        vestedBonus = (totbonus * sumassured) / 1000;
                        if (table == 34)
                        { vestedBonus = totbonus; }
                        //interimboncount--;
                        if (interimboncount < 0) { interimboncount = 0; }
                        if (int.Parse(dateofdeath.ToString().Substring(0, 4)) != 2009)
                        {
                            interimBonus = (temp * interimboncount * sumassured) / 1000;
                        }
                        #region-----------New Interim bonus calculation of 2009
                        else//This part added for new Bonus calculation of 2009-------
                        {
                            // polMasRead pmr = new polMasRead(polno, dthRegObj);
                            //COM = pmr.COM;
                            int deathyear = int.Parse(dateofdeath.ToString().Substring(0, 4));
                            if ((int.Parse(deathyear.ToString() + dateofComm.ToString().Substring(4, 4)) > dateofdeath) || (deathyear == 2010))
                            {
                                deathyear--;
                            }
                            string bonuscal = "select LPHS.INT_BONUS_CAL(" + polno + ", " + yeardiff + ", " + deathyear + ", " + sumassured + ", " + table + ") from dual";
                            using (DataTable dataTable = dal.ReadSQLtoDataTable(bonuscal))
                            {
                                using (DataTableReader bonusreader = dataTable.CreateDataReader())
                                {
                                    while (bonusreader.Read())
                                    {
                                        if (!bonusreader.IsDBNull(0)) { interimBonus = Convert.ToDouble(bonusreader[0]); }
                                    }
                                }
                            }
                            interimBonus *= interimboncount;
                        }
                        //------------------------------------------------------------------
                        #endregion
                        if ((polstat.Equals("L") && ((term <= 10) && (polDuraYrs >= 2)) || ((term > 10) && (polDuraYrs >= 3))) || polstat.Equals("I"))
                        {
                            this.lbltotbons.Text = "Rs." + String.Format("{0:N}", (interimBonus + vestedBonus));
                            interimBonStYR = int.Parse(this.setDate()[0].Substring(0, 4)) - interimboncount - 1;
                        }
                        else
                        {
                            interimBonus = 0;
                            vestedBonus = 0;
                            interimBonStYR = 0;
                        }
                    }
                    if (MOF.Equals("S"))
                    {
                        interimBonus = 0;
                        vestedBonus = 0;
                        interimBonStYR = 0;
                        this.lbltotbons.Text = "Rs.0.00";
                    }


                    #endregion

                    #region  ------------- Get Branch Name ----------------
                    string branchNameSelect = @"select BRNAM from GENPAY.BRANCH where brcod=" + branchId + "";
                    if (dal.IsRecordExist(branchNameSelect))
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(branchNameSelect))
                        {
                            using (DataTableReader brnNameREADER = dataTable.CreateDataReader())
                            {
                                while (brnNameREADER.Read())
                                {
                                    if (!brnNameREADER.IsDBNull(0)) { branchName = brnNameREADER[0].ToString(); } else { branchName = ""; }
                                }
                            }
                        }
                    }
                    #endregion

                    #region ------------------ AML Designated List -----------------------------
                    amlDesignated = new AMLDesignatedPerson();
                    string AMLError = amlDesignated.Get_AMLDesignatedList(long.Parse(polno.ToString()), "R");

                    if (AMLError.Length > 0)
                    {
                        this.lblAMLDesignatedPersons.Text = AMLError;
                    }

                    #endregion

                    #region Check Same Day Payment Task 39176

                    string checkSamePayment = "select LCPOL,to_char(to_date(LCDUE||'01','yyyyMMdd'),'yyyy/MM'),to_char(ENTRY_DATE,'YYYY-MM-DD HH:MI:SS AM') from lpay.lpaycom where LCPOL='" + polno + "' and LCPDT='" + dateofdeath + "'";
                    if (dthintobj.existRecored(checkSamePayment) != 0)
                    {
                        string paidTime = "";
                        string paidDue = "";
                        dthintobj.readSql(checkSamePayment);
                        OracleDataReader checkSamePaymentReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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
                    ViewState["fullAge"] = fullAge;
                    ViewState["DOB"] = dateOfBirth;
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
                    ViewState["nameOfDead"] = nameOfDead;
                    ViewState["dateofComm"] = dateofComm;
                    ViewState["phname"] = phname;
                    ViewState["cof"] = cof;
                    ViewState["ad1"] = ad1;
                    ViewState["ad2"] = ad2;
                    ViewState["ad3"] = ad3;
                    ViewState["ad4"] = ad4;

                    ViewState["LoanNum"] = LoanNum;
                    //ViewState["rcptno"] = rcptno;
                    /*ViewState["LMNCP_LMCPY"] = LMNCP_LMCPY;
                    ViewState["LMIPY01"] = LMIPY01;
                    ViewState["polDuraYrs"] = polDuraYrs;
                    ViewState["polDuraMnths"] = polDuraMnths;*/
                    ViewState["loanCap"] = CapitalToBePaid;
                    ViewState["loanint"] = InterestToBePaid;
                    ViewState["Intdate"] = Intdate;
                    ViewState["isFuterePremWaivedOff"] = isFuterePremWaivedOff;
                    ViewState["table"] = table;
                    ViewState["benefitPeriod"] = benefitPeriod;
                    ViewState["COM"] = COM;
                    ViewState["brId"] = branchId;
                    ViewState["brName"] = branchName;

                    #endregion
                }
                catch (Exception ex)
                {
                    EPage.Messege = ex.Message.ToString();
                    Response.Redirect("EPage.aspx");
                }
                finally 
                { dal.CloseDBConnection(); }
            }
        }
        else
        {
            #region ----- get Data from view State --------
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
            if (ViewState["fullAge"] != null) { fullAge = double.Parse(ViewState["fullAge"].ToString()); }
            if (ViewState["dob"] != null) { dateOfBirth = long.Parse(ViewState["dob"].ToString()); }
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
            if (ViewState["loanCap"] != null) { CapitalToBePaid = double.Parse(ViewState["loanCap"].ToString()); }
            if (ViewState["loanint"] != null) { InterestToBePaid = double.Parse(ViewState["loanint"].ToString()); }
            if (ViewState["Intdate"] != null) { Intdate = ViewState["Intdate"].ToString(); }
            if (ViewState["hasLoan"] != null) { hasLoan = ViewState["hasLoan"].ToString();}
            if (ViewState["isFuterePremWaivedOff"] != null) { isFuterePremWaivedOff = ViewState["isFuterePremWaivedOff"].ToString(); }
            if (ViewState["table"] != null) { table = int.Parse(ViewState["table"].ToString()); }
            if (ViewState["benefitPeriod"] != null) { benefitPeriod = int.Parse(ViewState["benefitPeriod"].ToString()); }
            if (ViewState["COM"] != null) { COM = int.Parse(ViewState["COM"].ToString()); }
            if (ViewState["brId"] != null) { branchId = ViewState["brId"].ToString(); }
            if (ViewState["brName"] != null) { branchName = ViewState["brName"].ToString(); }
            if(ViewState["nameOfDead"] != null) { nameOfDead = ViewState["nameOfDead"].ToString(); }

            if (ViewState["havePayment"] != null) { havePayment = int.Parse(ViewState["havePayment"].ToString()); }
            if (ViewState["havePaymentWarring"] != null) { havePaymentWarring = ViewState["havePaymentWarring"].ToString(); }


            if (havePayment == 1)
            {
                lblhasPayWarr.Text = havePaymentWarring;
                lblhasPayWarr.ForeColor = System.Drawing.Color.Red;
                pnlHavePayment.Visible = true;
            }

            #endregion


        }

    }
   
    protected void btnregister_Click(object sender, EventArgs e)    
    {      
        string typeeka = "";
        string calcdate = setDate()[0];
        string ipADDR = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        double totsurrbonus = 0;
        double totbonus = 0;
        int surrbonuscount;
        bool flag = false;
        bool valMovflag = false;
        bool matClearflag = false;
        bool matEmailSendflag = false;
        bool isChildSecondLife = false;
        bool isHavePremiumPaidCovers = false;
        dthintobj = new DataManager();
        table56 = new Table56(); 
	string cstatus = "D";

        using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
        {
            try
            {
                dal.OpenTransaction();
                string dthintSelect = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=0 ";
                if (!dal.IsRecordExist(dthintSelect))
                {
                    throw new Exception("Death Intimation Already Confirmed or Deleted!");
                }
                else
                {
                    string[] ComDate = lbldtofcomm.Text.Split('/');
                    string ComDate2 = "";
                    foreach (string s in ComDate)
                    {
                        ComDate2 = ComDate2 + s;
                    }

                    //Table 56 changes
                    string planDetails = "select BENEFIT_PERIOD from lund.tabnam where tdtabl=" + table + "";
                    if (dthintobj.existRecored(planDetails) != 0)
                    {
                        dthintobj.readSql(planDetails);
                        OracleDataReader planReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (planReader.Read())
                        {
                            if (!planReader.IsDBNull(0)) { benefitPeriod = planReader.GetInt32(0); } else { benefitPeriod = 0; }
                        }
                        planReader.Close();
                        planReader.Dispose();
                    }

                    if (table == 56)
                    {
                        if (dateofdeath > (Convert.ToInt32(ComDate2) + ((Convert.ToInt32(lblterm.Text) + benefitPeriod) * 10000))) { throw new Exception("Date of Death Exceeds Benefit Period of Policy!"); }
                    }
                    else
                    {
                        //valdiation added by Dulan task 25312
                        //if (dateofdeath > (Convert.ToInt32(ComDate2) + (Convert.ToInt32(lblterm.Text) * 10000))) { throw new Exception("Date of Death Exceeds Matuarity Date of Policy!"); }
                        //valdiation added by Dulan task 25312

                        //Task 31667 
                        if (table != 3)
                        {
                            if (dateofdeath > (Convert.ToInt32(ComDate2) + (Convert.ToInt32(lblterm.Text) * 10000))) { throw new Exception("Date of Death Exceeds Matuarity Date of Policy!"); }
                        }
                    }
                    #region //************ Get Claim No or Generate Claim No ****************
                    string dthrefhisSel = "SELECT DPOLNO, DMOS ,DCLM FROM LPHS.DTHINT WHERE (DPOLNO = " + ViewState["polno"].ToString() + ") AND (DMOS = '" + ViewState["MOF"].ToString() + "')";//polno
                    if (dal.IsRecordExist(dthrefhisSel))
                    {
                        using (DataTable dtTable = dal.ReadSQLtoDataTable(dthrefhisSel))
                        {
                            using (DataTableReader dthrefhisReader = dtTable.CreateDataReader())
                            {
                                while (dthrefhisReader.Read())
                                {
                                    if (!dthrefhisReader.IsDBNull(2)) // Get Existing Claim No
                                    {
                                        claimNo =  Convert.ToInt32(dthrefhisReader[2]);
                                    }
                                    else  // Generate a New Claim No
                                    {
                                        claimNo = 0;                                        
                                    }
                                }
                            }

                        }
                    }
                    if (claimNo == 0)
                    {
                        string deathClaimNum = "SELECT RCNO FROM LCLM.ARREFNO WHERE RCTYPE='D'";
                        using (DataTable dtTable1 = dal.ReadSQLtoDataTable(deathClaimNum))
                        {
                            using (DataTableReader clmnoReader = dtTable1.CreateDataReader())
                            {
                                while (clmnoReader.Read())
                                {
                                    if (!clmnoReader.IsDBNull(0))
                                    {
                                        claimNo = Convert.ToInt64(clmnoReader[0]);
                                        flag = true;
                                    }
                                }
                            }
                        }
                        claimNo = claimNo + 1;
                        string Update = "UPDATE LCLM.ARREFNO SET RCNO=" + claimNo.ToString() + " WHERE RCTYPE='D'";
                        dal.ExecuteTableUpdateQuery(Update);
                    }
                    #endregion
                  
                    #region //************ Generating Policy History ****************
                    string premRead = "select  PMCOD, PMPOL, PMCOM, PMTBL, PMTRM, PMSUM, PMMOD, PMPRM, PMDUE, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR from LPHS.premast where PMPOL=" + polno + " ";
                    bool premflag = false;
                    using (DataTable dtTable = dal.ReadSQLtoDataTable(premRead))
                    {
                        using (DataTableReader premReader = dtTable.CreateDataReader())
                        {
                            while (premReader.Read())
                            {
                                typeeka = "I";
				cstatus = "I";
                                premflag = true;

                                if (!premReader.IsDBNull(0)) { COD = premReader.GetString(0);}
                                if (!premReader.IsDBNull(1)) { POL = Convert.ToInt32(premReader[1]); }
                                if (!premReader.IsDBNull(2)) { COM = Convert.ToInt32(premReader[2]); }
                                if (!premReader.IsDBNull(3)) { TBL = Convert.ToInt32(premReader[3]); }
                                if (!premReader.IsDBNull(4)) { TRM = Convert.ToInt32(premReader[4]); }
                                if (!premReader.IsDBNull(5)) { SUM = Convert.ToInt32(premReader[5]); }
                                if (!premReader.IsDBNull(6)) { MOD = Convert.ToInt32(premReader[6]); }
                                if (!premReader.IsDBNull(7)) { PRM = Convert.ToDouble(premReader[7]);} else { PRM = 0; }
                                if (!premReader.IsDBNull(8)) { DUE = Convert.ToInt32(premReader[8]); }
                                if (!premReader.IsDBNull(9)) { PAC = Convert.ToInt32(premReader[9]); }
                                if (!premReader.IsDBNull(10)) { AGT = Convert.ToInt32(premReader[10]); }
                                if (!premReader.IsDBNull(11)) { ORG = Convert.ToInt32(premReader[11]); }
                                if (!premReader.IsDBNull(12)) { BRN = Convert.ToInt32(premReader[12]); }
                                if (!premReader.IsDBNull(13)) { OBR = Convert.ToInt32(premReader[13]); }
                                if (!premReader.IsDBNull(14)) { PTR = Convert.ToInt32(premReader[14]); }
                            }
                        }
                    }
                    if (premflag)
                    {
                        string premSQL="";
                        //int tmpDue = 0;

                        switch (MOF)
                        {
                            case "M":
                                premSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                                if (TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49) premSQL = "update lphs.premast set pmcod='D' where pmpol= " + polno + "";


                                if(TBL == 43) //if table 43 then it should give the premium waver
                                    premSQL = "update lphs.premast set pmcod='D',pmdue=(to_number(substr(pmcom,1,6))+pmtrm*100) where pmpol= " + polno + "";

                                //------- Table 56 - Future Premiums Waived off ---------------------
                                if (TBL == 56 && isFuterePremWaivedOff == "Y")
                                {
                                    isHavePremiumPaidCovers = table56.isHavePremiumPaidCover(polno);

                                    if (!isHavePremiumPaidCovers)
                                    {
                                        //tmpDue = int.Parse(COM.ToString().Substring(0, 6)) + (TRM * 100);
                                        //premSQL = "update lphs.premast set pmcod='D', pmdue=" + tmpDue + "  where pmpol= " + polno + "";
                                        premSQL = "update lphs.premast set pmcod='D' where pmpol= " + polno + "";
                                    }
                                    else
                                    {
                                        //tmpDue = int.Parse(COM.ToString().Substring(0, 6)) + 100;
                                        //premSQL = "update lphs.premast set pmcod='H', pmdue=" + tmpDue + "  where pmpol= " + polno + "";
                                        premSQL = "update lphs.premast set pmcod='H' where pmpol= " + polno + "";
                                    }
                                }

                                break;
                            case "S":
                                premSQL = "update lphs.premast set pmcod='S' where pmpol= " + polno + ""; ;
                                if (TBL == 34) premSQL = "update lphs.premast set pmcod='S' where pmpol= " + polno + "";
                                break;
                            case "2":
                                //premSQL = "update lphs.premast set pmcod='G' where pmpol= " + polno + ""; 
                                //break;
                                #region --------------------- Check is second life is child --------------------
                                {
                                    string chkIsCecondLifeChild = "select * from LUND.TABNAM where tdtabl=" + TBL + " and is_child='Y' and is_child_second_life='Y'";
                                    if (dal.IsRecordExist(chkIsCecondLifeChild))
                                    {
                                        using (DataTable dtTableSecondLife = dal.ReadSQLtoDataTable(chkIsCecondLifeChild))
                                        {
                                            using (DataTableReader isChildSecondLifeReader = dtTableSecondLife.CreateDataReader())
                                            {
                                                while (isChildSecondLifeReader.Read())
                                                {
                                                    if (!isChildSecondLifeReader.IsDBNull(0))
                                                    {
                                                        isChildSecondLife = true;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                    if (isChildSecondLife)
                                    {
                                        premSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                                    }
                                    else if (TBL == 14)
                                    {
                                        premSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                                    }
                                    else
                                    {
                                        premSQL = "update lphs.premast set pmcod='G' where pmpol= " + polno + "";
                                    }
                                #endregion
                                }
                                break;
                            case "C":
                                {
                                    if (TBL == 49 || TBL == 46 || TBL == 56)
                                        premSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                                    if (TBL == 34)
                                        premSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                                    /*add newly foe tbl 38 etc*/
                                    else
                                        premSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                                }
                                break;
                        }
                        dal.ExecuteTableUpdateQuery(premSQL);
                    }
                    bool lapsflag = false;

                    if (!premflag)  // policy is not inforce(Not in Premast) check in lapse table
                    {
                        //----------------- liflaps data -----------------------------------------
                        string liflapsRead = "select  LPCOD, LPPOL, LPCOM, LPTBL, LPTRM, LPSUM, LPMOD, LPPRM, LPDUE, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR from LPHS.LIFLAPS where LPPOL=" + polno + " ";

                        using (DataTable dtTable = dal.ReadSQLtoDataTable(liflapsRead))
                        {
                            using (DataTableReader lapsReader = dtTable.CreateDataReader())
                            {
                                while (lapsReader.Read())
                                {
                                    typeeka = "L";
				    cstatus = "L";
                                    lapsflag = true;

                                        if (!lapsReader.IsDBNull(0)) { COD = lapsReader.GetString(0); }
                                        if (!lapsReader.IsDBNull(1)) { POL = Convert.ToInt32(lapsReader[1]); }
                                        if (!lapsReader.IsDBNull(2)) { COM = Convert.ToInt32(lapsReader[2]); }
                                        if (!lapsReader.IsDBNull(3)) { TBL = Convert.ToInt32(lapsReader[3]); }
                                        if (!lapsReader.IsDBNull(4)) { TRM = Convert.ToInt32(lapsReader[4]); }
                                        if (!lapsReader.IsDBNull(5)) { SUM = Convert.ToInt32(lapsReader[5]); }
                                        if (!lapsReader.IsDBNull(6)) { MOD = Convert.ToInt32(lapsReader[6]); }
                                        if (!lapsReader.IsDBNull(7)) { PRM = Convert.ToDouble(lapsReader[7]); }
                                        if (!lapsReader.IsDBNull(8)) { DUE = Convert.ToInt32(lapsReader[8]); }
                                        if (!lapsReader.IsDBNull(9)) { PAC = Convert.ToInt32(lapsReader[9]); }
                                        if (!lapsReader.IsDBNull(10)) { AGT = Convert.ToInt32(lapsReader[10]); }
                                        if (!lapsReader.IsDBNull(11)) { ORG = Convert.ToInt32(lapsReader[11]); }
                                        if (!lapsReader.IsDBNull(12)) { BRN = Convert.ToInt32(lapsReader[12]); }
                                        if (!lapsReader.IsDBNull(14)) { PTR = Convert.ToInt32(lapsReader[14]); }
                                    }
                                }
                            }
                        }
                        bool lpolhisflag = false;
                        if (!premflag && !lapsflag)
                        {
                            //----------------- lpolhis data -----------------------------------------
                            
                            string lpolhisRead = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR,PHSTA from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D'";

                            using (DataTable dtTable = dal.ReadSQLtoDataTable(lpolhisRead))
                            {
                                using (DataTableReader lpolhisReader = dtTable.CreateDataReader())
                                {
                                    while (lpolhisReader.Read())
                                    {
                                        typeeka = "L";
                                        cstatus = "L";
                                        lpolhisflag = true;

                                        if (!lpolhisReader.IsDBNull(0)) { COD = lpolhisReader.GetString(0); }
                                        if (!lpolhisReader.IsDBNull(1)) { POL = Convert.ToInt32(lpolhisReader[1]); }
                                        if (!lpolhisReader.IsDBNull(2)) { COM = Convert.ToInt32(lpolhisReader[2]); }
                                        if (!lpolhisReader.IsDBNull(3)) { TBL = Convert.ToInt32(lpolhisReader[3]); }
                                        if (!lpolhisReader.IsDBNull(4)) { TRM = Convert.ToInt32(lpolhisReader[4]); }
                                        if (!lpolhisReader.IsDBNull(5)) { SUM = Convert.ToInt32(lpolhisReader[5]); }
                                        if (!lpolhisReader.IsDBNull(6)) { MOD = Convert.ToInt32(lpolhisReader[6]); }
                                        if (!lpolhisReader.IsDBNull(7)) { PRM = Convert.ToDouble(lpolhisReader[7]); }
                                        if (!lpolhisReader.IsDBNull(8)) { DUE = Convert.ToInt32(lpolhisReader[8]); }
                                        if (!lpolhisReader.IsDBNull(9)) { PAC = Convert.ToInt32(lpolhisReader[9]); }
                                        if (!lpolhisReader.IsDBNull(10)) { AGT = Convert.ToInt32(lpolhisReader[10]); }
                                        if (!lpolhisReader.IsDBNull(11)) { ORG = Convert.ToInt32(lpolhisReader[11]); }
                                        if (!lpolhisReader.IsDBNull(12)) { BRN = Convert.ToInt32(lpolhisReader[12]); }
                                        if (!lpolhisReader.IsDBNull(14)) { PTR = Convert.ToInt32(lpolhisReader[14]); }
                                        if (!lpolhisReader.IsDBNull(15)) { typeeka = lpolhisReader.GetString(15); }
                                        if (!lpolhisReader.IsDBNull(15)) { cstatus = lpolhisReader.GetString(15); }
                                    }
                                }
                            }
                        }


                        if (!premflag && !lapsflag && !lpolhisflag)
                        {
                            throw new Exception("No Policy Details!");
                        }

                    #region ------------- Health Product Changes ------------
                    if (TBL == 64)
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
                                TBL = lpolhisTableReader.GetInt32(0);
                                lpolhisTableReader.Close();
                                lpolhisTableReader.Dispose();
                            }
                        }
                    }

                    if (polstat != "L")
                    {
                        if (TBL == 55)
                        {
                            #region  ------------- RCover - SA, COM DATE & Term details ----------------
                            int rcov = 0;
                            if (MOF == "M")
                            {
                                rcov = 1;
                            }
                            else if (MOF == "S")
                            {
                                rcov = 101;
                            }
                            string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                            if (!dal.IsRecordExist(rcovSelect))
                            {
                                throw new Exception("No Death Intimation Details!");
                            }
                            else
                            {
                                using (DataTable dataTable = dal.ReadSQLtoDataTable(rcovSelect))
                                {
                                    using (DataTableReader rcovREADER = dataTable.CreateDataReader())
                                    {
                                        while (rcovREADER.Read())
                                        {
                                            if (!rcovREADER.IsDBNull(0)) { SUM = Convert.ToInt32(rcovREADER[0]); } else { SUM = 0; }
                                            if (!rcovREADER.IsDBNull(1)) { COM = Convert.ToInt32(rcovREADER[1]); } else { COM = 0; }
                                            if (!rcovREADER.IsDBNull(2)) { TRM = Convert.ToInt32(rcovREADER[2]); } else { TRM = 0; }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region  ------------- RCover - SA, COM DATE & Term details ----------------
                            int rcov = 0;
                            if (MOF != "M")
                            {
                                if (MOF == "S")
                                {
                                    rcov = 101;
                                }
                                else
                                {
                                    rcov = 1;
                                }

                                //42488 begin
                                //string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                                string rcovSelect = "select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "" +
                                                 " union " +
                                                 " select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER_History a where A.RPOL= " + polno + " and A.RCOVR = " + rcov + " and " +
                                                 " ENTRY_DATE > (select to_date(DDTOFDTH, 'yyyymmdd') from lphs.dthint where dpolno = " + polno + " and dmos = '" + MOF + "')";
                                //42488 end
                                if (!dal.IsRecordExist(rcovSelect))
                                {

                                    throw new Exception("Spouse Cover Details Has Been Removed!");

                                }
                                else
                                {
                                    using (DataTable dataTable = dal.ReadSQLtoDataTable(rcovSelect))
                                    {
                                        using (DataTableReader rcovREADER = dataTable.CreateDataReader())
                                        {
                                            while (rcovREADER.Read())
                                            {
                                                if (!rcovREADER.IsDBNull(0)) { SUM = Convert.ToInt32(rcovREADER[0]); } else { SUM = 0; }
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion  

                    //---------------- update/insert into lpolhis -----------------------

                    //Task 36873
                    typeeka = polstat;
                    //---------------

                    string polhisread = "select * from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                    if (!dal.IsRecordExist(polhisread) )
                    {
                        string polhisinsertSQL = @"insert into lphs.lpolhis (PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, 
                           PHOBR, PHPTR, PHTYP, PHENT, PHEPF, PHIP, PHSTA, PHMOS,PHCLAIM,PHDATEOFINTIM ) values('" + COD + "'," + POL + "," + COM + "," + TBL + "," + TRM + "," + SUM + "," + MOD + "," + PRM + "," + DUE + "," + PAC + "," +
                           AGT + "," + ORG + "," + BRN + "," + OBR + "," + PTR + ", 'D'," + int.Parse(setDate()[0]) + ",'" + EPF + "', '" + ipADDR + "', '" + typeeka + "', '" + MOF + "','" + claimNo.ToString() + "'," + Convert.ToInt32(ViewState["Intdate"]) + ") ";

                        dal.ExecuteTableUpdateQuery(polhisinsertSQL);
                    }

                    //Task 24735
                    if (TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49 || TBL == 56)
                    {
                        if (MOF == "M")
                        {
                            typeeka = polstat;
                        }
                    }

                    //--------------- updating Policy Details ------------------------------------------

                    string lapsdeSQL = "";
                    if (!premflag) // change added by Dulan Task: 25371
                    {
                        if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49 || TBL == 56) && (MOF.Equals("M")))
                        {
                            //lapsdeSQL = "update lphs.liflaps set lpcod='D' where lppol= " + polno + "";

                            //Task 24735
                            if (typeeka == "I" && TBL != 56)
                            {
                                string lapseread = "select * from lphs.liflaps where lppol=" + polno + " ";
                                if (dal.IsRecordExist(lapseread))
                                {
                                    //Movement
                                    List<StoredProcedureInputParameters> inputParaList3 = new List<StoredProcedureInputParameters>();
                                    inputParaList3.Add(new StoredProcedureInputParameters("p_POLICYNO", POL));
                                    inputParaList3.Add(new StoredProcedureInputParameters("p_DEATH_DATE", dateofdeath));
                                    dal.ExecuteSotredProcedure("VALUATION.VMEX.DEATH_LAPSE_REVERSE_ON", inputParaList3);

                                    lapsdeSQL = "delete from lphs.liflaps where lppol=" + polno + " ";

                                    string premastinsertSQL = @"insert into lphs.premast(PMCOD, PMPOL, PMCOM, PMTBL, PMTRM, PMSUM, " +
                                                               "PMMOD, PMPRM, PMDUE, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR ) " +
                                                               "values('D'," + POL + "," + COM + "," + TBL + "," + TRM + "," + SUM + ", " +
                                                               "" + MOD + "," + PRM + "," + DUE + "," + PAC + "," + AGT + "," + ORG + ", " +
                                                               "" + BRN + "," + OBR + "," + PTR + ")";
                                    dal.ExecuteTableUpdateQuery(premastinsertSQL);
                                }
                            }
                            else
                            {
                                lapsdeSQL = "update lphs.liflaps set lpcod='D' where lppol= " + polno + "";
                            }
                        }
                        //else if (TBL == 55 && (MOF.Equals("S")))
                        //{
                        //    lapsdeSQL = "update lphs.liflaps set lpcod='S' where lppol= " + polno + "";
                        //}
                        //else
                        //{
                        //    lapsdeSQL = "delete from lphs.liflaps where lppol=" + polno + " ";
                        //}
                        else if (MOF.Equals("S"))
                        {
                            lapsdeSQL = "update lphs.liflaps set lpcod='S' where lppol= " + polno + "";
                        }
                        else if (MOF.Equals("2"))
                        {
                            #region --------------------- Check is second life is child --------------------

                            string chkIsCecondLifeChild = "select * from LUND.TABNAM where tdtabl=" + TBL + " and is_child='Y' and is_child_second_life='Y'";
                            if (dal.IsRecordExist(chkIsCecondLifeChild))
                            {
                                using (DataTable dtTableSecondLife = dal.ReadSQLtoDataTable(chkIsCecondLifeChild))
                                {
                                    using (DataTableReader isChildSecondLifeReader = dtTableSecondLife.CreateDataReader())
                                    {
                                        while (isChildSecondLifeReader.Read())
                                        {
                                            if (!isChildSecondLifeReader.IsDBNull(0))
                                            {
                                                isChildSecondLife = true;
                                            }
                                        }
                                    }

                                }
                            }

                            if (isChildSecondLife)
                            {
                                lapsdeSQL = "delete from lphs.premast where pmpol= " + polno + " ";
                            }
                            else if(TBL==14) //added by Rumesha for task 34560
                            {
                                lapsdeSQL = "delete from lphs.liflaps where lppol= " + polno + " ";
                            }
                            else
                            {
                                lapsdeSQL = "update lphs.premast set pmcod='G' where pmpol= " + polno + "";
                            }
                            #endregion
                        }
                        else
                        {
                            lapsdeSQL = "delete from lphs.liflaps where lppol=" + polno + " ";
                        }

                        dal.ExecuteTableUpdateQuery(lapsdeSQL);
                    }
                    #endregion

                    #region  //*********** Confirming In DTHINT ************************
                    string dthintUPD = "";
                    if (flag)
                    {
                        dthintUPD = @"update lphs.dthint set DPOLST='" + ViewState["polstat"].ToString() + "', dclm=" + claimNo + ", dsta=2 , dconfdat=" + setDate()[0] + " , dconfepf='" + EPF + @"' , 
                                    dconfip='" + ipADDR + "' , dconfbr=" + BRN + " , dconftime='" + setDate()[1] + "' , dconfst='Y' where dpolno=" + polno + " and dmos='" + MOF + "' ";
                    }
                    else
                    {
                        //acordinng to Chaminda Athauda(life) not need to confirm details of the policy if already exist 2012/10/18
                    dthintUPD = @"update lphs.dthint set DPOLST='" + ViewState["polstat"].ToString() + "', dclm=" + claimNo + ", dsta=2 , dconfepf='" + EPF + @"' , 
                    dconfst='Y' where dpolno=" + polno + " and dmos='" + MOF + "' ";
                    }
                    
                    dal.ExecuteTableUpdateQuery(dthintUPD);
                    #endregion

                    //????? apply back calculation -------

                    #region //************* Settling Loans ***************************
                    if (MOF.Equals("M"))
                    {
                        #region--------------------------- Showing Loans -------------------------------------------------------
                        string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1, LMICP  from lphs.lplmast where lmpol=" + polno + " and (nvl(trim(lmset),'N') <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                        int caldate = int.Parse(this.setDate()[0]);
                        int rows = 0;
                        double loantotal = 0;
                        double loaninttot = 0;
                        int lmcdt = 0;
                        DataManager dm = new DataManager();

                        if (dal.IsRecordExist(loansql))
                        {

                            ViewState["hasLoan"] = "Y";
                            using (DataTable dataTable = dal.ReadSQLtoDataTable(loansql))
                            {
                                using (DataTableReader myloanreader = dataTable.CreateDataReader())
                                {
                                    while (myloanreader.Read())
                                    {
                                        if (!myloanreader.IsDBNull(0)) { LoanNum = Convert.ToInt32(myloanreader[0]); }
                                        if (!myloanreader.IsDBNull(13)) { lmcdt = Convert.ToInt32(myloanreader[13]); }
                                        ltrLoanNo.Text = LoanNum.ToString();
                                        /*ltrLoanGrantedDate.Text = myloanreader[13].ToString();
                                        ltrDateOfMaturity.Text = myloanreader[14].ToString();
                                        ltrCapitalGranted.Text = myloanreader[17].ToString();*/


                                        List<StoredProcedureInputParameters> inputParaList = new List<StoredProcedureInputParameters>();
                                        List<StoredProcedureInputParameters> outPutParaList = new List<StoredProcedureInputParameters>();

                                        inputParaList.Add(new StoredProcedureInputParameters("policyNumber", polno.ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("loanNumber", LoanNum.ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("dateOfDeath", dateofdeath.ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("currentDate", setDate()[0]));
                                        inputParaList.Add(new StoredProcedureInputParameters("settlementBranch", branch.ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("EPF", dm.EpfCode(EPF.ToString())));
                                        inputParaList.Add(new StoredProcedureInputParameters("claimNo", ViewState["claimNo"].ToString()));
                                        inputParaList.Add(new StoredProcedureInputParameters("machineIP", ipADDR.ToString()));
                                        //policyNumber in number,loanNumber in number, dateOfDeath in number ,currentDate in number,settlementBranch in number,EPF in number, claimNo in varchar,machineIP in varchar,InterestToBePaid out varchar,CapitalToBePaid out varchar,p_CapitalAsAtDeath out varchar,p_InterestAsAtDeath
                                        outPutParaList.Add(new StoredProcedureInputParameters("InterestToBePaid", DatabaseAccessLayer.ParaType.Float, 12));
                                        outPutParaList.Add(new StoredProcedureInputParameters("CapitalToBePaid", DatabaseAccessLayer.ParaType.Float, 12));
                                        outPutParaList.Add(new StoredProcedureInputParameters("p_CapitalAsAtDeath", DatabaseAccessLayer.ParaType.Float, 12));
                                        outPutParaList.Add(new StoredProcedureInputParameters("p_InterestAsAtDeath", DatabaseAccessLayer.ParaType.Float, 12));

                                        List<StoredProcedureInputParameters> outPutList = dal.ExecuteSotredProcedure("lpay.life_functions.loanBackCalculation", inputParaList, outPutParaList);
                                        foreach (StoredProcedureInputParameters p in outPutList)
                                        {
                                            switch (p.ParamenterName)
                                            {
                                                case "InterestToBePaid":
                                                    InterestToBePaid = Convert.ToDouble(p.Value);
                                                    //InterestToBePaid = p.Value;// String.Format("{0:N}", p.Value);
                                                    break;
                                                case "CapitalToBePaid":
                                                    CapitalToBePaid = Convert.ToDouble(p.Value);
                                                    //CapitalToBePaid = p.Value;//String.Format("{0:N}", p.Value);
                                                    break;
                                                case "p_CapitalAsAtDeath":
                                                    CapitalAsAtDeath = Convert.ToDouble(p.Value);
                                                    //ViewState["CapitalAsAtDeath"] = p.Value;//String.Format("{0:N}", p.Value);
                                                    break;
                                                case "p_InterestAsAtDeath":
                                                    InterestAsAtDeath = Convert.ToDouble(p.Value);
                                                    //ViewState["InterestAsAtDeath"] = p.Value;//String.Format("{0:N}", p.Value);
                                                    break;
                                            }

                                        }
                                        ltrInterestPayment.Text = String.Format("{0:N}", (InterestAsAtDeath - InterestToBePaid));
                                        ltrCapitalPayement.Text = String.Format("{0:N}", (CapitalAsAtDeath - CapitalToBePaid));
                                        LoanCommencementDate = lmcdt; //Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2);
                                        rows++;

                                        inputParaList.Clear();
                                        outPutParaList.Clear();
                                        outPutList.Clear();

                                        /* if (rows == 1)
                                         {
                                             this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", (rows - 1));
                                             this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                                         }
                                         else
                                         {
                                             this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                                         }*/
                                    }

                                }
                            }
                        }
                        else
                        { ViewState["hasLoan"] = "N"; }
                        # endregion
                    }
                    else
                    {
                        ltrLoanNo.Text = "-";
                        ltrLoanGrantedDate.Text = "-";
                        ltrDateOfMaturity.Text = "-";
                        ltrCapitalGranted.Text = "-";
                        ltrInterestToBePaid.Text = "-";
                        ltrCapitalTobePaid.Text = "-";
                        ltrCapitalAsAtDeath.Text = "-";
                        ltrInterestAsAtDeath.Text = "-";
                        ltrInterestPayment.Text = "-";
                        ltrCapitalPayement.Text = "-";

                    }
                    #endregion




                    //*********** updating LPHS.DTHREF ***********************

                    string DCOstr = COM.ToString();
                    int commyr = int.Parse(COM.ToString().Substring(0, 4));
                    ageAdmitYN = this.ddlageadmit.SelectedItem.Value;
                    revivalsYN = this.ddlrinsYN.SelectedItem.Value;
                    ageAdmitAmt = Convert.ToDouble(this.TxtAgeEntry.Text.Trim());//....add by buddhika 2009/03/23...
                    ageEntryInter = Convert.ToDouble(TxtAgeEntryInter.Text.Trim());//....add by buddhika 2009/04/7...


                    #region  //----------------------------------- surrendered bonus ------------------------------------------

                    int DCOym = int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
                    //*************************************** Bonus Logic ******************************************

                    bonusurrYN = this.ddlbonsurrYN.SelectedItem.Value;
                    if ((this.txtbonsurryr.Text != null) && (bonusurrYN.Equals("Y"))) 
                    { 
                        bonussurrYr = int.Parse(this.txtbonsurryr.Text); 
                    }
                    else if (this.txtbonsurryr.Text == null) 
                    { 
                        throw new Exception("If You Want the Surrendered Bonus Please Give the Surrender Year!"); 
                    }

                    if (polstat.Equals("I")) //************** Inforce ********************************************
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
                        else //**************** Inforce and bonus surrendered ************************************
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
                                using (DataTable dtTable = dal.ReadSQLtoDataTable(bonsqlinf))
                                {
                                    using (DataTableReader bonfilereaderinf = dtTable.CreateDataReader())
                                    {
                                        while (bonfilereaderinf.Read())
                                        {
                                            flag = true;
                                            for (int j = 0; j < surrbonuscount; j++)
                                            {
                                                double annualbonus = Convert.ToDouble (bonfilereaderinf[j]);
                                                int bondeclaredyr =Convert.ToInt32 (bonfilereaderinf[j + surrbonuscount]);
                                                if (bondeclaredyr > bonussurrYr)
                                                { break; }
                                                else
                                                { totsurrbonus = totsurrbonus + annualbonus; }
                                            }
                                        }
                                        surrrenderedbons = (totsurrbonus * SUM) / 1000;
                                    }
                                }
                            }
                        }
                    }
                    else if (polstat.Equals("L")) //*************** policy lapsed *********************************************
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
                        else//*********** Lapse and bonus surrendered *****************************
                        {
                            surrbonuscount = bonussurrYr - commyr + 1;
                            string incrementcountstr = "";
                            string incrementcountstrdclr = "";
                            int i = 0;

                            if ( TRM < bonuscount )
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

                                flag = false;

                                using (DataTable dtTable = dal.ReadSQLtoDataTable(bonsqlapse))
                                {
                                    using (DataTableReader bonfilereaderlapse = dtTable.CreateDataReader())
                                    {
                                        while (bonfilereaderlapse.Read())
                                        {
                                            flag = true;
                                            for (int j = 0; j < (surrbonuscount); j++)
                                            {
                                                double annualbonus = Convert.ToDouble(bonfilereaderlapse[j]);
                                                int bondeclaredyr =  Convert.ToInt32(bonfilereaderlapse[j + surrbonuscount]);
                                                if (bondeclaredyr > bonussurrYr)
                                                { break; }
                                                else
                                                { totsurrbonus = totsurrbonus + annualbonus; }
                                            }
                                        }
                                    }
                                }
                                surrrenderedbons = (totsurrbonus * sumassured) / 1000;
                            }
                        }
                    }

                    #endregion

                        #region 34965
                        int paiddue = 0;
                        string getpaiddue = "select nvl(max(LLDUE), 0) from LCLM.LEDGER where LLPOL = '" + polno + "'";//polno
                        if (dal.IsRecordExist(getpaiddue))
                        {
                            using (DataTable dtTable = dal.ReadSQLtoDataTable(getpaiddue))
                            {
                                using (DataTableReader dthrefhisReader = dtTable.CreateDataReader())
                                {
                                    while (dthrefhisReader.Read())
                                    {
                                        if (!dthrefhisReader.IsDBNull(0)) // Get Existing Claim No
                                        {
                                            paiddue = Convert.ToInt32(dthrefhisReader[0]);
                                        }
                                        else  // Generate a New Claim No
                                        {
                                            paiddue = 0;
                                        }
                                    }
                                }

                            }
                        }
                        #endregion

                        // demmands ????????????????????????????????????

                    #region   //------------------------------------- inserting deathref -----------------------------------------

                    netsurrAmt = vestedBonus + interimBonus - surrrenderedbons;
                    string dthrefSelect = "select * from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                    if (!dal.IsRecordExist(dthrefSelect) )
                    {
                        string dthrefInsert = @"INSERT INTO LPHS.DTHREF 
                            (DRPOLNO ,DRMOS ,DRCLMNO ,DRACCBF ,DRAGEADMIT ,DRRINSYN ,
                             DRREVIVALS ,DRASSIGNEENOM ,DRVESTEDBON ,DRINTERIMBON ,DRBONSURRAMT ,DRBONSURRYR 
                             ,DRSWARNAJAYA ,DRFUNERALEXP , DRFPU ,DRDEPOSITS , DRDEFPREM ,DRINT ,
                             DRLONCAP ,DRLOANINT ,DRNETCLM ,   DRPAIDNO ,DRAGT, DRNETSURR, 
                             DENTDT, DENTEPF,AGE_AMT ,INTBONSTYR, branch,AGEDIFINRST,CAUSEOFDEATHSTR,DCAUSEOFDTH,CPOLSTAT,DRPAID_DUE )
                             VALUES (" +
                                 polno + " ,'" + MOF + "' , " + claimNo + " , " + ADB + " ,'" + ageAdmitYN + "' ,'" + reinsYN + "' ,'" +
                                 revivalsYN + "' ,'" + assNomYN + "' , " + vestedBonus + " , " + interimBonus + " , " + surrrenderedbons + " , " + bonussurrYr + " , " +
                                 SJ + " , " + FE + " , " + FPU + " , " + deposit + " ," + demmands + " , " + defint + " , " +
                                 CapitalToBePaid + " , " + InterestToBePaid + " , NULL , NULL , " + AGT + ", " + netsurrAmt + ", " +
                                 int.Parse(this.setDate()[0]) + ", '" + EPF + "'," + ageAdmitAmt + " ," + interimBonStYR + ", " + BRN + "," + ageEntryInter + ",'" + txtcauseStr.Text.Trim() + "','" + DropDownList1.SelectedValue + "','"+cstatus+"' ,'"+ paiddue + "' )";
                            dal.ExecuteTableUpdateQuery(dthrefInsert);

                        interimBonStYR = 0;
                    }
                    else
                    {
                        throw new Exception("Already Registered!");
                    }

                    #endregion

                    #region  //*************** updating GRPBILLINGDET ************************************

                    int GBYEAR = 0; int GBMON = 0; string GBSUR = ""; string GBINI = ""; double GBPRM = 0; string GBIDCODE = ""; int GBPAC = 0; int GBPASUBCODE = 0; int GBTRANSDAT = 0; int GBBATCHCODE = 0; int BILLINGTYPE = 0; string FILEST = "";
                    string GRPBILLINGsel = "select GBYEAR, GBMON, GBSUR, GBINI, GBPRM, GBIDCODE, GBPAC, GBPASUBCODE, GBTRANSDAT, GBBATCHCODE, BILLINGTYPE, FILEST from LPHS.GRPBILLINGDET where gbpol = " + polno + " ";
                    if (dal.IsRecordExist(GRPBILLINGsel))
                    {
                        using (DataTable dtTable = dal.ReadSQLtoDataTable(GRPBILLINGsel))
                        {
                            using (DataTableReader grpbillingRader = dtTable.CreateDataReader())
                            {
                                while (grpbillingRader.Read())
                                {
                                    if (!grpbillingRader.IsDBNull(0)) { GBYEAR = Convert.ToInt32(grpbillingRader[0]); } else { GBYEAR = 0; }
                                    if (!grpbillingRader.IsDBNull(1)) { GBMON = Convert.ToInt32(grpbillingRader[1]); } else { GBMON = 0; }
                                    if (!grpbillingRader.IsDBNull(2)) { GBSUR = grpbillingRader.GetString(2); } else { GBSUR = ""; }
                                    if (!grpbillingRader.IsDBNull(3)) { GBINI = grpbillingRader.GetString(3); } else { GBINI = ""; }
                                    if (!grpbillingRader.IsDBNull(4)) { GBPRM = Convert.ToDouble(grpbillingRader[4]); } else { GBPRM = 0; }
                                    if (!grpbillingRader.IsDBNull(5)) { GBIDCODE = grpbillingRader.GetString(5); } else { GBIDCODE = ""; }
                                    if (!grpbillingRader.IsDBNull(6)) { GBPAC = Convert.ToInt32(grpbillingRader[6]); } else { GBPAC = 0; }
                                    if (!grpbillingRader.IsDBNull(7)) { GBPASUBCODE = Convert.ToInt32(grpbillingRader[7]); } else { GBPASUBCODE = 0; }
                                    if (!grpbillingRader.IsDBNull(8)) { GBTRANSDAT = Convert.ToInt32(grpbillingRader[8]); } else { GBTRANSDAT = 0; }
                                    if (!grpbillingRader.IsDBNull(9)) { GBBATCHCODE = Convert.ToInt32(grpbillingRader[9]); } else { GBBATCHCODE = 0; }
                                    if (!grpbillingRader.IsDBNull(10)) { BILLINGTYPE = Convert.ToInt32(grpbillingRader[10]); } else { BILLINGTYPE = 0; }
                                    if (!grpbillingRader.IsDBNull(11)) { FILEST = grpbillingRader.GetString(11); } else { FILEST = ""; }


                                    string billingHisInsert = "INSERT INTO LPHS.GRPBILLINGHIS (GBPOL ,GBYEAR ,GBMON ,GBSUR ,GBINI ,GBPRM ,GBIDCODE ,GBPAC ,GBPASUBCODE ,GBTRANSDAT ,GBBATCHCODE ,BILLINGTYPE ,FILEST ,CLM_SETTLE_TYPE ) " +
                                        " VALUES (" + polno + " ," + GBYEAR + " ," + GBMON + " ,'" + GBSUR + "' ,'" + GBINI + "' ," + GBPRM + " ,'" + GBIDCODE + "' ," + GBPAC + " ," + GBPASUBCODE + " ," + GBTRANSDAT + " ," + GBBATCHCODE + " ," + BILLINGTYPE + " ,'" + FILEST + "' ,'D'  )";
                                    dal.ExecuteTableUpdateQuery(billingHisInsert);

                                    string BillingHistory = "INSERT INTO LPHS.GRPBILLINGDET_HISTORY (GBPOL, ENTRY_DATE, GBYEAR, GBMON, GBSUR, GBINI, GBPRM, GBIDCODE, GBPAC, GBPASUBCODE, GBTRANSDAT, GBBATCHCODE, BILLINGTYPE, FILEST) " +
                                        " VALUES(" + polno + ", to_date('" + DateTime.Now.ToString("yyyy/MM/dd") + "','YYYY/MM/DD')," + GBYEAR + "," + GBMON + ",'" + GBSUR + "','" + GBINI + "'," + GBPRM + ",'" + GBIDCODE + "'," + GBPAC + "," + GBPASUBCODE + "," + GBTRANSDAT + "," + GBBATCHCODE + "," + BILLINGTYPE + ",'" + FILEST + "')";
                                    dal.ExecuteTableUpdateQuery(BillingHistory);
                                }
                            }
                        }
                    }

                    string billingDel = "delete from lphs.GRPBILLINGDET where gbpol = " + polno + " ";
                    dal.ExecuteTableUpdateQuery(billingDel);

                    #endregion

                    //*********** committing now!!!!!!!!!!!!!!!! ******************************************************

                        this.lblsucess.Text = "Intimation Successfully Registered";
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

                #region --------------------- Is Valuation Movement Death Run --------------------
                string valMovDethRunSel = "select * from LPHS.VALUATION_MOVDEATH_RUNTBL a where A.TBL_NO=" + TBL + " and A.LIFE_TYPE='" + MOF + "'";
                if (dal.IsRecordExist(valMovDethRunSel))
                {
                    using (DataTable dtTableVal = dal.ReadSQLtoDataTable(valMovDethRunSel))
                    {
                        using (DataTableReader valMovDethRunReader = dtTableVal.CreateDataReader())
                        {
                            while (valMovDethRunReader.Read())
                            {
                                if (!valMovDethRunReader.IsDBNull(0)) 
                                {
                                    valMovflag = true;
                                } 
                            }
                        }

                    }
                }
                #endregion

                #region --------------------- Is Maturity Email Send --------------------
                string maturityEmailSendSel = "select * from LPHS.MATURITY_CLEAR_RUNTBL a where A.TBL_NO=" + TBL + " and A.LIFE_TYPE='" + MOF + "' and IS_SEND_EMAIL='Y'";
                if (dal.IsRecordExist(maturityEmailSendSel))
                {
                    using (DataTable dtTableVal = dal.ReadSQLtoDataTable(maturityEmailSendSel))
                    {
                        using (DataTableReader matEmailSendReader = dtTableVal.CreateDataReader())
                        {
                            while (matEmailSendReader.Read())
                            {
                                if (!matEmailSendReader.IsDBNull(0))
                                {
                                    matEmailSendflag = true;
                                }
                            }
                        }

                    }
                }
                #endregion

                #region --------------------- Is Maturity Clear Run --------------------
                string maturityClearRunSel = "select * from LPHS.MATURITY_CLEAR_RUNTBL a where A.TBL_NO=" + TBL + " and A.LIFE_TYPE='" + MOF + "' and IS_MATURITY_RUN='Y'";
                if (dal.IsRecordExist(maturityClearRunSel))
                {
                    using (DataTable dtTableVal = dal.ReadSQLtoDataTable(maturityClearRunSel))
                    {
                        using (DataTableReader matClearRunReader = dtTableVal.CreateDataReader())
                        {
                            while (matClearRunReader.Read())
                            {
                                if (!matClearRunReader.IsDBNull(0))
                                {
                                    matClearflag = true;
                                }
                            }
                        }

                    }
                }
                #endregion

                #region-----------------------------CLEAR MATURITY(2011/04/03) Task no:27546----------------------- 
                if (matEmailSendflag)
                {
                    string cashbookSel1 = "";
                    int stageDate = 0;
                    bool cashbook = false;

                    #region ------------ Check Is Maturity Voucher Process --------------------
                    //string cashbookSel = "select CLAIMNO from CASHBOOK.TEMP_CB where POLNO='" + polno + "' and VOUTYP like 'Maturity' and STATUS in ('Authorized','Paid')";
                    string cashbookSel = "select CLAIMNO, 'Maturity'  from CASHBOOK.TEMP_CB where POLNO='" + polno + "' and trim(VOUTYP) in ('Maturity') and trim(STATUS) in ('Pending','Authorized','Paid','Vou.Authorized','Paid Manual','Vou.Printed','Pay.Authorized') and DELETED='0'";
                    #endregion

                    #region ------------ Check Is Stage Payment Voucher Process --------------------
                    //string cashbookSel = "select CLAIMNO from CASHBOOK.TEMP_CB where POLNO='" + polno + "' and VOUTYP like 'Maturity' and STATUS in ('Authorized','Paid')";
                    cashbookSel1 = "select b.STAGE_DATE, b.PCLAIMNO, 'Stage' from CASHBOOK.TEMP_CB a, LCLM.LCMMAST b where A.POLNO=B.PPOLNO and POLNO='" + polno + "' and trim(VOUTYP) in ('Stage Payment') and trim(STATUS) in ('Pending','Authorized','Vou.Authorized','Paid Manual','Vou.Printed','Pay.Authorized') and DELETED='0' order by b.STAGE_DATE";
                    #endregion

                    if (dal.IsRecordExist(cashbookSel) || dal.IsRecordExist(cashbookSel1))
                    {
                        dthintobj.readSql(cashbookSel);
                        OracleDataReader cashbookReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (cashbookReader.Read())
                        {
                            if (!cashbookReader.IsDBNull(0)) { matClaimNo = cashbookReader.GetString(0); } else { matClaimNo = ""; }
                            if (!cashbookReader.IsDBNull(1)) { vouType = cashbookReader.GetString(1); } else { vouType = ""; }
                            cashbook = true;
                        }
                        cashbookReader.Close();
                        cashbookReader.Dispose();

                        dthintobj.readSql(cashbookSel1);
                        OracleDataReader cashbookReader1 = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (cashbookReader1.Read())
                        {
                            if (!cashbookReader1.IsDBNull(0)) { stageDate = cashbookReader1.GetInt32(0); } else { stageDate = 0; }
                            if (!cashbookReader1.IsDBNull(1)) { matClaimNo = cashbookReader1.GetString(1); } else { matClaimNo = ""; }
                            if (!cashbookReader1.IsDBNull(2)) { vouType = cashbookReader1.GetString(2); } else { vouType = ""; }
                        }
                        cashbookReader1.Close();
                        cashbookReader1.Dispose();

                        //if ((TBL != 38 && stageDate >= dateofdeath) || cashbook)
                        if ((stageDate >= dateofdeath) || cashbook)
                        {
                            sendEmail(new MemoryStream());
                            throw new Exception("Maturity payment processing! Please contact with Maturity Department!");
                        }
                    }

                    if (matClearflag)
                    {
                        List<StoredProcedureInputParameters> inputParaList1 = new List<StoredProcedureInputParameters>();
                        inputParaList1.Add(new StoredProcedureInputParameters("policyno", polno.ToString()));
                        inputParaList1.Add(new StoredProcedureInputParameters("sysid", "D"));
                        inputParaList1.Add(new StoredProcedureInputParameters("ftype", "F"));
                        inputParaList1.Add(new StoredProcedureInputParameters("dateofdthorsurrn", dateofdeath));
                        inputParaList1.Add(new StoredProcedureInputParameters("tblno", TBL));
                        inputParaList1.Add(new StoredProcedureInputParameters("ptype", MOF));
                        dal.ExecuteSotredProcedure("LPHS.MATURITY_CLEAR_DEATH", inputParaList1);
                        inputParaList1.Clear();
                    }
                }
                #endregion

                if (valMovflag)
                {
                    if ((TBL == 34 && MOF.Equals("C")) || TBL != 34)
                    { 
                        #region-----------------------------VALUATION MOVEMENT-----------------------
                        // procedure MOVEMENT_DEATH(v_SUBCODE in number , p_POLICYNO in number, p_COMMENCEMENT_date in number, p_PLAN in number, p_TERM in number, p_SUMASSURED in number, p_MODE_CODE in number, p_PREMIUM in number,p_TRANSACTION_DATE in date, p_EXIT_DUE in number)
                        List<StoredProcedureInputParameters> inputParaList2 = new List<StoredProcedureInputParameters>();
                        inputParaList2.Add(new StoredProcedureInputParameters("v_SUBCODE", 26));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_POLICYNO", polno));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_COMMENCEMENT_date", COM));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_PLAN", TBL));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_TERM", TRM));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_SUMASSURED", SUM));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_MODE_CODE", MOD));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_PREMIUM", PRM));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_TRANSACTION_DATE", System.DateTime.Now));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_EXIT_DUE", DUE));
                        inputParaList2.Add(new StoredProcedureInputParameters("p_MOS", MOF));
                        dal.ExecuteSotredProcedure("VALUATION.VMEX.MOVEMENT_DEATH", inputParaList2);
                        #endregion
                    }
                }

                #region----------------------------- Send email to Scaning Center -----------------------

                if (Convert.ToUInt32(branchId) != 23)
                {
                    sendEmailToScanningCenter(new MemoryStream());
                }

                #endregion

                //dal.RollbackTransaction();
                dal.CommitTransaction();
                dal.CloseDBConnection();
		
		#region Task 36053 Re-Insurance Automation Send Email
                ReInsurance reIns = new ReInsurance();
                reIns.sendReInuranceEmail(polno, claimNo, EPF);
                #endregion
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction();
                dal.CloseDBConnection();
                EPage.Messege = ex.Message.ToString();
                Response.Redirect("EPage.aspx");
            }
        }
    }

    public void sendEmail(MemoryStream ms)
    {
        string msg = "", msTyp = "", resTyp = "", pdfName_ = "";
        String body = "";
        string reciverAddr = "";
        string dthDate = "";
        string matDate = "";

        int plan_id = 200;
        List<string> EMailDataListCC = null;
        List<string> EMailDataListTO = null; 

        try
        {
            dthDate = dateofdeath.ToString().Substring(6, 2) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(0, 4);
            matDate = (COM + TRM * 10000).ToString();
            matDate = matDate.Substring(6, 2) + "/" + matDate.Substring(4, 2) + "/" + matDate.Substring(0, 4);

            EMailData mailOb = new EMailData(); 
            reciverAddr = mailOb.getEmailIDForDeathTO("DEATH", "TO", plan_id);

            mailOb.getEmailBodyDetails(plan_id, 1);
            //------------add cc list -----------------------------
            EMailDataListTO = new List<string>();
            EMailDataListTO = mailOb.getEmailIDForDeath("DEATH", "TO", plan_id);
            //-

            //------------add cc list -----------------------------
            EMailDataListCC = new List<string>();
            EMailDataListCC = mailOb.getEmailIDForDeath("DEATH", "CC", plan_id);
            //------------end adding --------------------------------
            String mails = mailOb.EmailAddr;
            String[] emailsArray = (!string.IsNullOrEmpty(mails)) ? mails.Split('~') : null;

            body = "<table style='font-family:Arial;font-size:11pt;width:100%'><tr><td colspan='2'>" +
                    mailOb.ToWhome + "</td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2' style='padding-bottom:15px;'>" +
                    mailOb.BodyContent + "</td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Policy no <span style='margin-left:110px'> :- " + polno.ToString() + " (Plan Id :- " + TBL + ")" + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "" + vouType + " Claim No <span style='margin-left:62px'> :- " + matClaimNo + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Name of Life Assured <span style='margin-left:39px'> :- " + phname + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Date of " + vouType + " Payment <span style='margin-left:20px'> :- " + matDate + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Date of Death <span style='margin-left:85px'> :- " + dthDate + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Death Registration Branch <span style='margin-left:12px'> :- " + branchName + "</span></td></tr><tr><td colspan='2' style='font-size:11px; padding-top:25px;'>" +
                    mailOb.Regards + "</td></tr><tr><td colspan='2'  style='font-size:11px;'>" +
                    mailOb.CompanyName + "</td></tr><tr><td colspan='2'  style='font-size:11px;'> " +
                    mailOb.DeptName + "</td></tr><tr><td colspan='2' style='font-size:11px;'>" +
                    mailOb.SecName + "</td></tr><tr><td colspan='2' style='font-size:11px;'>" +
                    mailOb.AddrLine1 + "</td></tr><tr><td colspan='2' style='font-size:11px;'>" +
                    mailOb.AddrLine2 + "</td></tr><tr><td colspan='2' style='font-size:11px;'>" +
                    "Tele " + mailOb.TeleNo + "</td></tr>";

            if (emailsArray != null)
            {
                foreach (String mailAddr in emailsArray)
                {
                    body = body + "<tr><td>" + mailAddr + "</td></tr>";
                }
            }

            body = body + "</table></td></tr></table>";

            //---------------------------send email settings ---------------------------------------------
            //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            string smtpClient = WebConfigurationManager.AppSettings["smtpClient"];
            string mailAddress_ = WebConfigurationManager.AppSettings["mailAddress"];
            string userName = WebConfigurationManager.AppSettings["userName"];
            string password = WebConfigurationManager.AppSettings["password"];
            int port = Convert.ToInt32(WebConfigurationManager.AppSettings["port"]);

            MailMessage mm = new MailMessage(mailAddress_, reciverAddr);
            mm.Subject = "Intimation of death claim received for " + vouType + " Policy - " + polno;
            mm.Body = body;
            //string pdfname = "Acturail-" + lblpolno.Text + ".pdf";
            //mm.Attachments.Add(new Attachment(ms, pdfname));
            mm.IsBodyHtml = true;

            if (EMailDataListTO != null)
            {
                foreach (string item in EMailDataListTO)
                {
                    if (item.ToString().ToUpper() != reciverAddr.ToUpper())
                    {
                        mm.To.Add(item);
                    }
                }
            }

            if (EMailDataListCC != null)
            {
                foreach (string item in EMailDataListCC)
                {
                    mm.CC.Add(item);

                }
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpClient;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["ssl"]);
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = userName;
            NetworkCred.Password = password;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;
            smtp.Port = port;

            smtp.Send(mm);
            msg = "email has sent successfully";
            msTyp = "1";
            resTyp = "email";
            updateEmailStatus(polno, claimNo, 1);
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        }
        catch (Exception ex)
        {
            if (ex is SmtpException || ex is SmtpFailedRecipientException)
            {
                msg = "Email Send Failed";
                msTyp = "2";
                resTyp = "email";
                updateEmailStatus(polno, claimNo, 2);
            }
            else
            {
                msg = "System error..!";
                msTyp = "3";
                resTyp = "email";
                updateEmailStatus(polno, claimNo, 3);
            }
        }
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    public void sendEmailToScanningCenter(MemoryStream ms)
    {
        string msg = "", msTyp = "", resTyp = "", pdfName_ = "";
        String body = "";
        string reciverAddr = "";
        string dthDate = "";
        string matDate = "";
        string userAndEpf = "";
        string regDateAndTime = "";
        string isFileAvailable = "";

        int plan_id = 300;
        List<string> EMailDataListCC = null;
        List<string> EMailDataListTO = null;

        try
        {
            if (Session["SurName"] != null && Session["EPFNum"] != null)
            {
                userAndEpf = Session["SurName"].ToString() + " - " + Session["EPFNum"].ToString();
            }

            regDateAndTime = setDate()[0].ToString().Substring(6, 2) + "/" + setDate()[0].ToString().Substring(4, 2) + "/" + setDate()[0].ToString().Substring(0, 2) + " - " + setDate()[1].ToString();
            dthDate = dateofdeath.ToString().Substring(6, 2) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(0, 4);
            matDate = (COM + TRM * 10000).ToString();
            matDate = matDate.Substring(6, 2) + "/" + matDate.Substring(4, 2) + "/" + matDate.Substring(0, 4);

            EMailData mailOb = new EMailData();
            reciverAddr = mailOb.getEmailIDForDeathTO("DEATH", "TO", plan_id);

            mailOb.getEmailBodyDetails(plan_id, 1);
            //------------add cc list -----------------------------
            EMailDataListTO = new List<string>();
            EMailDataListTO = mailOb.getEmailIDForDeath("DEATH", "TO", plan_id);
            //-

            //------------add cc list -----------------------------
            EMailDataListCC = new List<string>();
            EMailDataListCC = mailOb.getEmailIDForDeath("DEATH", "CC", plan_id);
            //------------end adding --------------------------------
            String mails = mailOb.EmailAddr;
            String[] emailsArray = (!string.IsNullOrEmpty(mails)) ? mails.Split('~') : null;

            isFileAvailable = this.getSacanFileAvailable(polno.ToString());

            body = "<table style='font-family:Arial;font-size:11pt;width:100%'><tr><td colspan='2'>" +
                    mailOb.ToWhome + "</td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2' style='padding-bottom:15px;'>" +
                    mailOb.BodyContent + "</td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2'></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Policy no <span style='margin-left:170px'> :- " + polno.ToString() + " (Plan Id :- " + TBL + ")" + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Death Claim No <span style='margin-left:135px'> :- " + claimNo + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Name of Life Assured <span style='margin-left:99px'> :- " + phname + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Life Type <span style='margin-left:171px'> :- " + LIFEtype(MOF) + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Date of Death <span style='margin-left:145px'> :- " + dthDate + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Death Registration Branch <span style='margin-left:72px'> :- " + branchName + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Death Claim Registered user <span style='margin-left:59px'> :- " + userAndEpf + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "Death Claim Registered Date and time <span style='margin-left:7px'> :- " + regDateAndTime + "</span></td></tr><tr><td colspan='2' style='font-weight:bold; font-size:12px;'>" +
                    "File available at the Scanning Center <span style='margin-left:17px'> :- " + isFileAvailable + "</span></td></tr><tr><td colspan='2' style='font-size:11px; padding-top:25px;'>" +
                    mailOb.Regards + "</td></tr><tr><td colspan='2'  style='font-size:11px;'>" +
                    mailOb.CompanyName + "</td></tr><tr><td colspan='2'  style='font-size:11px;'> " +
                    branchName + "</td></tr><tr><td colspan='2' style='font-size:11px;'></tr>";

            if (emailsArray != null)
            {
                foreach (String mailAddr in emailsArray)
                {
                    body = body + "<tr><td>" + mailAddr + "</td></tr>";
                }
            }

            body = body + "</table></td></tr></table>";

            //---------------------------send email settings ---------------------------------------------
            //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            string smtpClient = WebConfigurationManager.AppSettings["smtpClient"];
            string mailAddress_ = WebConfigurationManager.AppSettings["mailAddress"];
            string userName = WebConfigurationManager.AppSettings["userName"];
            string password = WebConfigurationManager.AppSettings["password"];
            int port = Convert.ToInt32(WebConfigurationManager.AppSettings["port"]);

            MailMessage mm = new MailMessage(mailAddress_, reciverAddr);
            mm.Subject = "Requesting physical file for death claim policy - " + polno;
            mm.Body = body;
            //string pdfname = "Acturail-" + lblpolno.Text + ".pdf";
            //mm.Attachments.Add(new Attachment(ms, pdfname));
            mm.IsBodyHtml = true;

            if (EMailDataListTO != null)
            {
                foreach (string item in EMailDataListTO)
                {
                    if (item.ToString().ToUpper() != reciverAddr.ToUpper())
                    {
                        mm.To.Add(item);
                    }
                }
            }

            if (EMailDataListCC != null)
            {
                foreach (string item in EMailDataListCC)
                {
                    mm.CC.Add(item);

                }
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpClient;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["ssl"]);
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = userName;
            NetworkCred.Password = password;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;
            smtp.Port = port;

            smtp.Send(mm);
            msg = "email has sent successfully";
            msTyp = "1";
            resTyp = "email";

            if (isFileAvailable == "Yes")
            {
                SacanningCenterFileRequest(polno, branchName);
            }
            updateCommonEmailStatus(polno, claimNo, plan_id, 1, "SCANING CENTER", isFileAvailable);
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        }
        catch (Exception ex)
        {
            if (ex is SmtpException || ex is SmtpFailedRecipientException)
            {
                msg = "Email Send Failed";
                msTyp = "2";
                resTyp = "email";
                updateCommonEmailStatus(polno, claimNo, plan_id, 2, "SCANING CENTER", "");
            }
            else
            {
                msg = "System error..!";
                msTyp = "3";
                resTyp = "email";
                updateCommonEmailStatus(polno, claimNo, plan_id, 3, "SCANING CENTER", "");
            }
        }
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    public void updateEmailStatus(long polno,long clmno, int sta)
    {        
        using (DatabaseAccessLayer dal1 = new DatabaseTransactionLayer())
        {
            dal1.OpenTransaction();
            try
            {
                string emailSendInsert = @"INSERT INTO LPHS.DEATMATURITY_MAILSEND
                            (POLICY_NO, CLAIM_NO, SEND_DATE, SEND_EPF, SEND_IP, SEND_BRANCH, EMAIL_STATUS)
                             VALUES (" + polno + " , " + clmno + " , sysdate ,'" + EPF + "' , '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "' , " + Convert.ToInt32(branchId) + ", " + sta + ")";
                dal1.ExecuteTableUpdateQuery(emailSendInsert);
                dal1.CommitTransaction();
                dal1.CloseDBConnection();
            }
            catch (Exception ex)
            {
                dal1.RollbackTransaction();
                dal1.CloseDBConnection();
                EPage.Messege = ex.ToString();
                Response.Redirect("EPage.aspx");
            }
        }
    }

    public void updateCommonEmailStatus(long polno, long clmno, int mailTyp, int sta, string purpose, string fileAvailable)
    {
        using (DatabaseAccessLayer dal1 = new DatabaseTransactionLayer())
        {
            dal1.OpenTransaction();
            try
            {
                string emailSendInsert = @"INSERT INTO LPHS.DEATH_MAILSEND
                            (POLICY_NO, CLAIM_NO, MAIL_TYPE, SEND_DATE, SEND_EPF, SEND_IP, SEND_BRANCH, EMAIL_STATUS, PURPOSE, FILE_AVAILABLE)
                             VALUES (" + polno + " , " + clmno + "," + mailTyp + " , sysdate ,'" + EPF + "' , '" +
                                         Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "' , " +
                                         Convert.ToInt32(branchId) + ", " + sta + ", '" + purpose + "', '" + fileAvailable + "')";
                dal1.ExecuteTableUpdateQuery(emailSendInsert);
                dal1.CommitTransaction();
                dal1.CloseDBConnection();
            }
            catch (Exception ex)
            {
                dal1.RollbackTransaction();
                dal1.CloseDBConnection();
                EPage.Messege = ex.ToString();
                Response.Redirect("EPage.aspx");
            }
        }
    }

    public void SacanningCenterFileRequest(long polno, string brnName)
    {
        OdbcConnection con = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");
        try
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

        }
        catch
        {
        }
        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = con;
        cmd.CommandText =
            @"INSERT INTO IMGDATA.IMGPF02 (Userid, Surname, Branch, Instype, Doctype, Plcnum, msgsnddt, msgsndtm,SCANTYP) " +
            "VALUES ('SEC5559' , 'D.C.Vidanage','Colombo' , " +
            "'L', 'P' ,'" + polno.ToString() + "' , '" + setDate()[0] + "', '" + setDate()[1] + "', ' ')";
        try
        {
            OdbcDataReader dr = cmd.ExecuteReader(); 
        }
        catch (Exception ex)
        {
        } 
        con.Close(); 
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

    private void CreateTbHeaderPreviousNominee()
    {
        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc1 = new TableHeaderCell();
        TableHeaderCell thc2 = new TableHeaderCell();
        TableHeaderCell thc3 = new TableHeaderCell();

        TableHeaderCell thc4 = new TableHeaderCell();
        TableHeaderCell thc5 = new TableHeaderCell();
        TableHeaderCell thc6 = new TableHeaderCell();

        thc1.Text = "NIC";
        thc2.Text = "Name ";
        thc3.Text = "Percentage";
        thc5.Text = "Enterd User EPF";
        thc6.Text = "Date";

        thr.Cells.Add(thc1);
        thr.Cells.Add(thc2);
        thr.Cells.Add(thc3);
        thr.Cells.Add(thc5);
        thr.Cells.Add(thc6);
        Table4.Rows.Add(thr); 
    }

    private void createPreviousNomineeTable(string nic, string nominee, string percentage, int rowNumber, string eEPF, string edate)
    {
        TableRow trow = new TableRow();
        TableRow trow1 = new TableRow();

        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        TableCell tcell6 = new TableCell();

        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
        Label lbl5 = new Label();
        Label lbl6 = new Label();

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

        lbl5.ID = "pEnterEPF" + rowNumber;
        lbl5.Attributes.Add("runat", "Server");
        lbl5.Attributes.Add("Name", "pEnterEPF" + rowNumber); //Text Value
        lbl5.Text = eEPF;

        lbl6.ID = "pEDate" + rowNumber;
        lbl6.Attributes.Add("runat", "Server");
        lbl6.Attributes.Add("Name", "pEDate" + rowNumber); //Text Value
        lbl6.Text = edate;

        tcell1.Controls.Add(lbl1);
        tcell1.CssClass = "nomNew";
        tcell2.Controls.Add(lbl2);
        tcell4.Controls.Add(lbl4);
        tcell5.Controls.Add(lbl5);
        tcell6.Controls.Add(lbl6);

        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell5);
        trow.Cells.Add(tcell6);

        Table4.Rows.Add(trow);
        Table4.CssClass = "policyDetail nom";
    }

    //......
    private void CreateTbHeader()
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
        //thc4.Text = "Address";
        thc5.Text = "Enterd EPF";
        thc6.Text = "Enterd Date";
        thc7.Text = "Authorized EPF";
        thc8.Text = "Authorized Date";

        thr.Cells.Add(thc1);
        thr.Cells.Add(thc2);
        thr.Cells.Add(thc3);
        //thr.Cells.Add(thc4);
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
        //lbl3.Text = Address ;

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
        tcell4.Controls.Add(lbl4);
        tcell5.Controls.Add(lbl5);
        tcell6.Controls.Add(lbl6);
        tcell7.Controls.Add(lbl7);
        tcell8.Controls.Add(lbl8);

        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        // trow.Cells.Add(tcell3);
        trow.Cells.Add(tcell5);
        trow.Cells.Add(tcell6);
        trow.Cells.Add(tcell7);
        trow.Cells.Add(tcell8);

        Table2.Rows.Add(trow);
        Table2.CssClass = "policyDetail nom";
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

    public string getSacanFileAvailable(string polno)
    {
        string fileAvailable = "";
        OdbcConnection con = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");
        try
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

        }
        catch
        {
        }
        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT SURNAME,BRANCH,DATECHG FROM imgdata.imgp02l6 where trim(plcnum) = '" + polno + "'";
        try
        {
            OdbcDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                fileAvailable = "No. This file has already been sent to " + dr[0].ToString() + " of " + dr[1].ToString() + " branch on " + dr[2].ToString() + "";
            }
            else
            {
                fileAvailable = "Yes";
            }
        }
        catch (Exception ex)
        {
        }
        con.Close();

        if (fileAvailable == "Yes")
        {
            OdbcConnection conNew = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");
            try
            {

                if (conNew.State == ConnectionState.Closed)
                    conNew.Open();

            }
            catch
            {
            }
            OdbcCommand cmdNew = new OdbcCommand();
            cmdNew.Connection = conNew;
            cmdNew.CommandText = @"SELECT SURNAME,BRANCH,MSGSNDDT FROM imgdata.imgp02l4 where trim(plcnum) = '" + polno + "'";
            try
            {
                OdbcDataReader drNew = cmdNew.ExecuteReader(CommandBehavior.CloseConnection);
                if (drNew.HasRows)
                {
                    fileAvailable = "Yes. This file has already been requested by " + drNew[0].ToString() + " of " + drNew[1].ToString() + " branch on " + drNew[2].ToString() + "";
                }
                else
                {
                    fileAvailable = "Yes";
                }
            }
            catch (Exception ex)
            {
            }
            conNew.Close();
        }

        return fileAvailable;
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
    protected void btnnext_Click(object sender, EventArgs e)
    {

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {

    }
    protected void btnloanreciept_Click1(object sender, EventArgs e)
    {

    }
    protected void btnprint_Click1(object sender, EventArgs e)
    {

    }
    protected void btnnext_Click1(object sender, EventArgs e)
    {

    }


    //public void sendReInuranceEmail(DatabaseAccessLayer dal,  DataManager dthintobj,int polno,long claimNo)
    //{
    //    string msg = "", msTyp = "", resTyp = "", pdfName_ = "";
    //    String body = "";
    //    string reciverAddr = "";
    //    string dthDate = "";
    //    string matDate = "";

    //    int plan_id = 200;
    //    List<string> EMailDataListCC = null;
    //    List<string> EMailDataListTO = null;
    //    //List<string> EMailDataListBCC = null;

    //    try
    //    {
    //        string liftyp = "";
    //        string gender = "";
    //        string dob = "";
    //        string polpersubsql = "";
    //        string status = polstat == "I" ? "Inforce" : "Lapse";
    //        string basicsum = "-";
    //        string fpusum = "-";
    //        string fpucov = "";
    //        string sjsum = "-";
    //        string sjcov = "";
    //        string adbsum = "-";
    //        string adbcov = "";
    //        string spousesum = "-";
    //        string cicsum = "-";
    //        string ciccov = "";
    //        switch (MOF)
    //        {
    //            case "M":
    //                liftyp = "Main Life";
    //                polpersubsql = "where polno='"+ polno + "' and prpertype='1'";
    //                fpucov = "('4')";
    //                sjcov = "('10')";
    //                adbcov = "('2')";
    //                ciccov = "('5','6')";
    //                break;
    //            case "S":
    //                polpersubsql = "where polno='" + polno + "' and prpertype='2'";
    //                liftyp = "Spouse";
    //                fpucov = "('104')";
    //                sjcov = "('110')";
    //                adbcov = "('102')";
    //                ciccov = "('105','106')";
    //                break;
    //            case "2":
    //                polpersubsql = "where polno='" + polno + "' and prpertype='3'";
    //                liftyp = "Second Life";
    //                fpucov = "('204')";
    //                sjcov = "('210')";
    //                adbcov = "('202')";
    //                ciccov = "('205','206')";
    //                break;
    //            case "C":
    //                polpersubsql = "where polno='" + polno + "' and prpertype in ('4','5','6',7','8')";
    //                liftyp = "Child";
    //                fpucov = "('304','404','504','604','704')";
    //                sjcov = "('310','410','510','610','710')";
    //                adbcov = "('302','402','502','602','702')";
    //                ciccov = "('7')";
    //                break;
    //            default:
    //                polpersubsql = "where polno='" + polno + "' and prpertype='1'";
    //                liftyp = "Main Life";
    //                break;
    //        }
    //        string sqlpersonal = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL "+polpersubsql;

    //        if (dthintobj.existRecored(sqlpersonal) != 0)
    //        {
    //            dthintobj.readSql(sqlpersonal);
    //            OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //            while (persreader.Read())
    //            {
    //                if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
    //                if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
    //            }
    //            persreader.Close();
    //            persreader.Dispose();
    //        }
    //        else
    //        {
    //            string sqlpersonalhis = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL_HISTORY " + polpersubsql;
    //            dthintobj.readSql(sqlpersonalhis);
    //            OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //            while (persreader.Read())
    //            {
    //                if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
    //                if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
    //            }
    //            persreader.Close();
    //            persreader.Dispose();
    //        }

    //        //string coversql = "select " +
    //        //    "(select SUM(RSUMAS) from lund.rcover where RPOL = '"+polno+"' and RCOVR in ('1')) as BASIC," +
    //        //    "(select SUM(RSUMAS) from lund.rcover where RPOL = '" + polno + "' and RCOVR in ('101')) as SPOUSE," +
    //        //    "(select SUM(RSUMAS) from lund.rcover where RPOL = '" + polno + "' and RCOVR in "+fpucov+") as FPU," +
    //        //    "(select SUM(RSUMAS) from lund.rcover where RPOL = '" + polno + "' and RCOVR in "+sjcov+") as SJ," +
    //        //    "(select SUM(RSUMAS) from lund.rcover where RPOL = '" + polno + "' and RCOVR in "+adbcov+") as ADB," +
    //        //    "(select SUM(RSUMAS) from lund.rcover where RPOL = '" + polno + "' and RCOVR in "+ciccov+") as CIC FROM DUAL";

    //        //if (dthintobj.existRecored(coversql) != 0)
    //        //{
    //        //    dthintobj.readSql(coversql);
    //        //    OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //        //    while (persreader.Read())
    //        //    {
    //        //        if (!persreader.IsDBNull(0)) { basicsum = persreader.GetInt32(0).ToString(); }
    //        //        if (!persreader.IsDBNull(1)) { spousesum = persreader.GetInt32(1).ToString(); }
    //        //        if (!persreader.IsDBNull(2)) { fpusum = persreader.GetInt32(2).ToString(); }
    //        //        if (!persreader.IsDBNull(3)) { sjsum = persreader.GetInt32(3).ToString(); }
    //        //        if (!persreader.IsDBNull(4)) { adbsum = persreader.GetInt32(4).ToString(); }
    //        //        if (!persreader.IsDBNull(5)) { cicsum = persreader.GetInt32(5).ToString(); }
    //        //    }
    //        //    persreader.Close();
    //        //    persreader.Dispose();
    //        //}
    //        Covers covers = new Covers();
    //        List<Covers> coverlist = new List<Covers>();
    //        coverlist = covers.GetolicyCovers(polno.ToString(), dthintobj);



    //        EMailData mailOb = new EMailData();
    //        reciverAddr = mailOb.getEmailIDForDeathTO("ACTU", "TO", plan_id);

            
    //        //------------add cc list -----------------------------
    //        EMailDataListTO = new List<string>();
    //        EMailDataListTO = mailOb.getEmailIDForDeath("ACTU", "TO", plan_id);
    //        //-

    //        //------------add cc list -----------------------------
    //        EMailDataListCC = new List<string>();
    //        EMailDataListCC = mailOb.getEmailIDForDeath("ACTU", "CC", plan_id);
    //        //------------end adding --------------------------------


    //        body = "<h3><b>New Death Claim Registration</b></h3>" +
    //            "<table style='font-family:Arial;font-size:11pt;'>" +
    //            "<tr><td>Claim No</td><td>:</td><td>" + ClaimNo + "</td></tr>" +
    //            "<tr><td>Policy No</td><td>:</td><td>" + polno + "</td></tr>" +
    //            "<tr><td>Plan No</td><td>:</td><td>" + TBL + "</td></tr>" +
    //            "<tr><td>Term</td><td>:</td><td>" + TRM + "</td></tr>" +
    //            "<tr><td>DOC of the Policy</td><td>:</td><td>" + COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2) + "</td></tr>" +
    //            "<tr><td>Name of the Deceased/Claimant</td><td>:</td><td>" + nameOfDead + "</td></tr>" +
    //            "<tr><td>Gender</td><td>:</td><td>" + gender + "</td></tr>" +
    //            "<tr><td>Date of Birth</td><td>:</td><td>" + dob + "</td></tr>" +
    //            "<tr><td>Claim Type</td><td>:</td><td>Death</td></tr>" +
    //            "</table>" +
    //            "<h4>Death Claim Information</h4>" +
    //            "<table style='font-family:Arial;font-size:11pt;margin-left:25px'>";
    //            foreach(Covers cov in coverlist)
    //            {
    //                body += "<tr><td>"+cov.CoverName+ "</td><td>:</td><td>" + cov.Sumass + "</td></tr>";
    //            }
                
                
    //            body += "</table>" +
    //            "<br>" +
    //            "<table style = 'font-family:Arial;font-size:11pt;' > " +
    //            "<tr><td>Policy Status</td><td>:</td><td>" + status + "</td></tr>" +
    //            "<tr><td>Life Type of Deceased/Claimant</td><td>:</td><td>" + liftyp + "</td></tr>" +
    //            "<tr><td>Date of Death/Disability/CIC</td><td>:</td><td>" + dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2) + "</td></tr>" +
    //            //"<tr><td>Caused of Death/Disability/Type of CIC Illness</td><td>:</td><td>-</td></tr>" +
    //            "</table>";
            

            

    //        //---------------------------send email settings ---------------------------------------------
    //        //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

    //        string smtpClient = WebConfigurationManager.AppSettings["smtpClient"];
    //        string mailAddress_ = WebConfigurationManager.AppSettings["mailAddress"];
    //        string userName = WebConfigurationManager.AppSettings["userName"];
    //        string password = WebConfigurationManager.AppSettings["password"];
    //        int port = Convert.ToInt32(WebConfigurationManager.AppSettings["port"]);

    //        MailMessage mm = new MailMessage(mailAddress_, reciverAddr);
    //        mm.Subject = "New Death Claim Registration - Claim No: "+claimNo;
    //        mm.Body = body;
    //        //string pdfname = "Acturail-" + lblpolno.Text + ".pdf";
    //        //mm.Attachments.Add(new Attachment(ms, pdfname));
    //        mm.IsBodyHtml = true;

    //        if (EMailDataListTO != null)
    //        {
    //            foreach (string item in EMailDataListTO)
    //            {
    //                if (item.ToString().ToUpper() != reciverAddr.ToUpper())
    //                {
    //                    mm.To.Add(item);
    //                }
    //            }
    //        }

    //        if (EMailDataListCC != null)
    //        {
    //            foreach (string item in EMailDataListCC)
    //            {
    //                mm.CC.Add(item);

    //            }
    //        }

    //        //if (EMailDataListBCC != null)
    //        //{
    //        //    foreach (string item in EMailDataListBCC)
    //        //    {
    //        //        mm.Bcc.Add(item);

    //        //    }
    //        //}

    //        SmtpClient smtp = new SmtpClient();
    //        smtp.Host = smtpClient;
    //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    //        smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["ssl"]);
    //        NetworkCredential NetworkCred = new NetworkCredential();
    //        NetworkCred.UserName = userName;
    //        NetworkCred.Password = password;
    //        smtp.UseDefaultCredentials = false;
    //        smtp.Credentials = NetworkCred;
    //        smtp.Port = port;

    //        smtp.Send(mm);

    //        string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
    //                        (POLNO,CLAIMNO,SENT_DATE,SENT_BY,TYPE)
    //                         VALUES ('"+ polno + "','" + claimNo + "' , sysdate, '" + EPF + "','REGISTRATION')";
    //        dal.ExecuteTableUpdateQuery(insertEmaillog);

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
        
    //}

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtcauseStr.Text = this.DropDownList1.SelectedItem.Text;
    }

    protected void btnupdateCuse_Click(object sender, EventArgs e)
    {
        string typeeka = "";
        string calcdate = setDate()[0];
        string ipADDR = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        double totsurrbonus = 0;
        double totbonus = 0;
        int surrbonuscount;
        bool flag = false;
        bool valMovflag = false;
        bool matClearflag = false;
        bool matEmailSendflag = false;
        bool isChildSecondLife = false;
        bool isHavePremiumPaidCovers = false;
        dthintobj = new DataManager();
        table56 = new Table56();

        using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
        {
            try
            {
                dal.OpenTransaction();
                string completed = "N";

                #region //************ Get Claim No or Generate Claim No ****************
                string dthrefhisSel = "SELECT DPOLNO, DMOS ,DCLM FROM LPHS.DTHINT WHERE (DPOLNO = " + ViewState["polno"].ToString() + ") AND (DMOS = '" + ViewState["MOF"].ToString() + "')";//polno
                if (dal.IsRecordExist(dthrefhisSel))
                {
                    using (DataTable dtTable = dal.ReadSQLtoDataTable(dthrefhisSel))
                    {
                        using (DataTableReader dthrefhisReader = dtTable.CreateDataReader())
                        {
                            while (dthrefhisReader.Read())
                            {
                                if (!dthrefhisReader.IsDBNull(2)) // Get Existing Claim No
                                {
                                    claimNo = Convert.ToInt32(dthrefhisReader[2]);
                                }
                                else  // Generate a New Claim No
                                {
                                    claimNo = 0;
                                }

                                
                            }
                        }

                    }
                }


                string dthrefhisSelCom = "SELECT POL_COMPL_YN,MEMOAPRV FROM LPHS.DTHREF WHERE (DRPOLNO = " + ViewState["polno"].ToString() + ") AND (DRMOS = '" + ViewState["MOF"].ToString() + "')";//polno
                if (dal.IsRecordExist(dthrefhisSelCom))
                {
                    using (DataTable dtTable = dal.ReadSQLtoDataTable(dthrefhisSelCom))
                    {
                        using (DataTableReader dthrefhisReader = dtTable.CreateDataReader())
                        {
                            while (dthrefhisReader.Read())
                            {
                                if (!dthrefhisReader.IsDBNull(1))
                                {
                                    completed = dthrefhisReader[1].ToString();
                                }
                            }
                        }

                    }
                }
                #endregion

                #region   //------------------------------------- inserting deathref -----------------------------------------

                netsurrAmt = vestedBonus + interimBonus - surrrenderedbons;
                string dthrefSelect = "select * from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                if (dal.IsRecordExist(dthrefSelect))
                {
                    string dthrefInsert = "UPDATE LPHS.DTHREF SET CAUSEOFDEATHSTR='" + txtcauseStr.Text.Trim() + "',DCAUSEOFDTH='" + DropDownList1.SelectedValue + "' WHERE DRPOLNO='"+ polno + "' and DRCLMNO='"+ claimNo + "' and drmos='" + MOF + "'";
                            
                    dal.ExecuteTableUpdateQuery(dthrefInsert);

                    interimBonStYR = 0;
                }
                else
                {
                    throw new Exception("No claim found!");
                }

                #endregion
                if(completed == "N")
                {
                    this.lblsucess.Text = "Cause of death sucessfully updated";
                }
                else
                {
                    string reinsemailcheck = "select * from lphs.DTH_REINS_EMAIL_LOG where POLNO='" + polno + "' and CLAIMNO='" + claimNo + "' ";
                    if (dthintobj.existRecored(reinsemailcheck) == 0)
                    {
                        this.lblsucess.Text = "Cause of death sucessfully updated. If you want sent mail to Actuarial click on 'Send Mail'";
                        btnSentMail.Visible = true;
                        btnupdateCuse.Visible = false;
                    }
                    else
                    {
                        this.lblsucess.Text = "Cause of death sucessfully updated";
                    }
                }
                
                this.lblsucess.Visible = true;
                //dal.RollbackTransaction();
                dal.CommitTransaction();
                dal.CloseDBConnection();

                if(completed == "N")
                {
                    #region Task 36053 Re-Insurance Automation Send Email
                    ReInsurance reIns = new ReInsurance();
                    reIns.sendReInuranceEmail(polno, claimNo, EPF);
                    #endregion
                }

            }
            catch (Exception ex)
            {
                dal.RollbackTransaction();
                dal.CloseDBConnection();
                EPage.Messege = ex.Message.ToString();
                Response.Redirect("EPage.aspx");
            }
        }
    }

    protected void btnSentMail_Click(object sender, EventArgs e)
    {
        #region Task 36053 Re-Insurance Automation Send Email
        ReInsurance reIns = new ReInsurance();
        reIns.sendReInuranceEmail(polno, claimNo, EPF);
        #endregion
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
