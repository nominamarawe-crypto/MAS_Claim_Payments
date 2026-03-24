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

public partial class dthRev002 : System.Web.UI.Page
{
    // last Update 2011/01/05
    // Update 2010/12/02
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
    private int polno;
    private string MOF;

    private int infodat;
    private int dateofdeath;
    private long infotel;
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

    /*private double sumassured;
    private int table;
    private int term;
    private int dateofComm;*/
    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;

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
    private string STA;

    private int EPF;
    //DataManager objRev;
    //DataManager dm;
    User_Authentication objUserAuthentication;

    protected void Page_Load(object sender, EventArgs e)
    {
        //objRev = new DataManager();



        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            ViewState["EPF"] = this.PreviousPage.EPF;
        }
        if (!Page.IsPostBack)
        {
            ViewState["ipADDR"] = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
            {
                try
                {
                    dal.OpenDBConnection();
                    //dal.OpenTransaction();
                    this.lblpolno.Text = polno.ToString();
                    this.lblmof.Text = mof(MOF);

                    objUserAuthentication = new User_Authentication();
                    if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC02"))
                    {
                        throw new Exception("You have no Authority for this option");
                    }

                    #region //---------lpolhis ----------------

                    string LPOLHIScheck = "select * from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "'  ";

                    if (dal.IsRecordExist(LPOLHIScheck))
                    {
                        string LPOLHISread = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "'  ";
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(LPOLHISread))
                        {
                            using (DataTableReader polhisReader = dataTable.CreateDataReader())
                            {
                                while (polhisReader.Read())
                                {
                                    if (!polhisReader.IsDBNull(0)) { COD = polhisReader.GetString(0); } else { COD = ""; }
                                    if (!polhisReader.IsDBNull(2)) { COM = Convert.ToInt32(polhisReader[2]); } else { COM = 0; }
                                    if (!polhisReader.IsDBNull(3)) { TBL = Convert.ToInt16(polhisReader[3]); } else { TBL = 0; }
                                    if (!polhisReader.IsDBNull(4)) { TRM = Convert.ToInt16(polhisReader[4]); } else { TRM = 0; }
                                    if (!polhisReader.IsDBNull(5))
                                    { this.lblsumassured.Text = String.Format("{0:N}", Convert.ToDouble(polhisReader[5])); }
                                    else { this.lblsumassured.Text = "0"; }
                                    if (!polhisReader.IsDBNull(15)) { STA = polhisReader.GetString(15); } else { STA = ""; }
                                    if (COM.ToString().Length == 8)
                                    { this.lbldtofcomm.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2); }
                                    this.lbltab.Text = TBL.ToString();
                                    this.lblterm.Text = TRM.ToString();

                                }
                            }
                        }

                    }
                    else
                    {
                        throw new Exception("No Terminated Policy Details Found!");
                    }

                    if (STA.Equals("I")) this.lblpolstat.Text = "INFORCE";
                    else this.lblpolstat.Text = "LAPSED";


                    #endregion

                    #region  //*************** dthint ********************************************************************

                    string dthintSelect = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4, ditel, dinforel, dclm from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=2  ";
                    if (!dal.IsRecordExist(dthintSelect))
                    {
                        throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                    }
                    else
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthintSelect))
                        {
                            using (DataTableReader dthintREADER = dataTable.CreateDataReader())
                            {
                                while (dthintREADER.Read())
                                {
                                    if (!dthintREADER.IsDBNull(0)) { infodat = Convert.ToInt32(dthintREADER[0]); } else { infodat = 0; }
                                    if (!dthintREADER.IsDBNull(3)) { dateofdeath = Convert.ToInt32(dthintREADER[3]); } else { dateofdeath = 0; }
                                    if (!dthintREADER.IsDBNull(11)) { infotel = Convert.ToInt64(dthintREADER[11]); } else { infotel = 0; }
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
                                    if (!dthintREADER.IsDBNull(13)) { claimNo = Convert.ToInt64(dthintREADER[13]); } else { claimNo = 0; }
                                }

                            }
                        }
                    }
                    
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
                    if (infodat != 0)
                    {
                        this.lbldtofintim.Text = infodat.ToString().Substring(0, 4) + "/" + infodat.ToString().Substring(4, 2) + "/" + infodat.ToString().Substring(6, 2);
                    }
                    this.lblpolstat.Text = polstate(polstat);

                    #endregion

                    #region // ************** PHNAME  ********************************************************************

                    string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(sql))
                    {
                        using (DataTableReader oraDtReader = dataTable.CreateDataReader())
                        {
                            while (oraDtReader.Read())
                            {
                                if (!oraDtReader.IsDBNull(0))
                                    phname = oraDtReader.GetString(0);
                                if (!oraDtReader.IsDBNull(1))
                                    phname = phname + "" + oraDtReader.GetString(1);
                                if (!oraDtReader.IsDBNull(2))
                                    phname = phname + "" + oraDtReader.GetString(2);
                                if (!oraDtReader.IsDBNull(3)) { ad1 = (oraDtReader.GetString(3)); }
                                if (!oraDtReader.IsDBNull(4)) { ad2 = (oraDtReader.GetString(4)); }
                                if (!oraDtReader.IsDBNull(5)) { ad3 = (oraDtReader.GetString(5)); }
                                if (!oraDtReader.IsDBNull(6)) { ad4 = (oraDtReader.GetString(6)); }

                            }

                        }
                    }

                    this.lblnameofInsured.Text = phname;
                    this.lblassuredad1.Text = ad1 + " " + ad2;
                    this.lblassuredad2.Text = ad3 + " " + ad4;

                    //******************************* VALFILE ******************************************************

                    string valsql = "select valage1 from LCLM.VALFILE where valpol='" + polno + "'";
                    int ageatentry = 0;
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(valsql))
                    {
                        using (DataTableReader valfilereader = dataTable.CreateDataReader())
                        {
                            while (valfilereader.Read())
                            {
                                ageatentry = Convert.ToInt16(valfilereader[0]);
                            }

                        }
                    }

                    if (MOF.Equals("M"))
                    {
                        this.lblageatentrystr.Visible = true;
                        this.lblageatentry.Visible = true;
                        this.lblageatentry.Text = ageatentry.ToString();
                    }
                    //-----------------------------------------------------------------------------------------------

                    #endregion


                    //-------
                    ViewState["polno"] = polno;
                    ViewState["MOF"] = MOF;
                    ViewState["dateofdeath"] = dateofdeath;
                    ViewState["claimNo"] = claimNo;
                    dal.CloseDBConnection();
                }
                catch (Exception ex)
                {
                    dal.CloseDBConnection();
                    EPage.Messege = ex.Message;
                    Response.Redirect("EPage.aspx");
                }
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["dateofdeath"] != null) { dateofdeath = int.Parse(ViewState["dateofdeath"].ToString()); }
            if (ViewState["claimNo"] != null) { claimNo = long.Parse(ViewState["claimNo"].ToString()); }
            EPF = Convert.ToInt32(ViewState["EPF"]);
        }
    }

    protected void btnReverse_Click(object sender, EventArgs e)
    {
        string ipADDR = ViewState["ipADDR"].ToString();
        using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
        {
            try
            {
                dal.OpenDBConnection();
                dal.OpenTransaction();
                bool valMovflag = false;
                bool matClearflag = false;

                #region  //**************** Restoring Policy Details ********************************


                string LPOLHISread = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "'  ";
                if (!dal.IsRecordExist(LPOLHISread))
                {
                    throw new Exception("No Terminated Police Details Found.");
                }
                using (DataTable dataTable = dal.ReadSQLtoDataTable(LPOLHISread))
                {
                    using (DataTableReader polhisReader = dataTable.CreateDataReader())
                    {
                        while (polhisReader.Read())
                        {
                            if (!polhisReader.IsDBNull(0)) { COD = polhisReader.GetString(0); } else { COD = ""; }
                            if (!polhisReader.IsDBNull(1)) { POL = Convert.ToInt32(polhisReader[1]); } else { POL = 0; }
                            if (!polhisReader.IsDBNull(2)) { COM = Convert.ToInt32(polhisReader[2]); } else { COM = 0; }
                            if (!polhisReader.IsDBNull(3)) { TBL = Convert.ToInt32(polhisReader[3]); } else { TBL = 0; }
                            if (!polhisReader.IsDBNull(4)) { TRM = Convert.ToInt32(polhisReader[4]); } else { TRM = 0; }
                            if (!polhisReader.IsDBNull(5)) { SUM = Convert.ToInt32(polhisReader[5]); } else { SUM = 0; }
                            if (!polhisReader.IsDBNull(6)) { MOD = Convert.ToInt32(polhisReader[6]); } else { MOD = 0; }
                            if (!polhisReader.IsDBNull(7)) { PRM = Convert.ToDouble(polhisReader[7]); } else { PRM = 0; }
                            if (!polhisReader.IsDBNull(8)) { DUE = Convert.ToInt32(polhisReader[8]); } else { DUE = 0; }
                            if (!polhisReader.IsDBNull(9)) { PAC = Convert.ToInt32(polhisReader[9]); } else { PAC = 0; }
                            if (!polhisReader.IsDBNull(10)) { AGT = Convert.ToInt32(polhisReader[10]); } else { AGT = 0; }
                            if (!polhisReader.IsDBNull(11)) { ORG = Convert.ToInt32(polhisReader[11]); } else { ORG = 0; }
                            if (!polhisReader.IsDBNull(12)) { BRN = Convert.ToInt32(polhisReader[12]); } else { BRN = 0; }
                            if (!polhisReader.IsDBNull(13)) { OBR = Convert.ToInt32(polhisReader[13]); } else { OBR = 0; }
                            if (!polhisReader.IsDBNull(14)) { PTR = Convert.ToInt32(polhisReader[14]); } else { PTR = 0; }
                            if (!polhisReader.IsDBNull(15)) { STA = polhisReader.GetString(15); } else { STA = ""; }

                        }
                    }


                    string premastsql = "select * from lphs.premast where pmpol=" + polno + "";
                    string liflapssql = "select * from lphs.liflaps where lppol=" + polno + "";
                    string Dthout = "select * from lphs.dthout where POLNO=" + polno + "";

                    if (STA.Equals("I") && !dal.IsRecordExist(premastsql) && !dal.IsRecordExist(Dthout))
                    {
                        string premastInsert = "insert into lphs.premast(PMCOD, PMPOL, PMCOM, PMTBL, PMTRM, PMSUM, PMMOD, PMPRM, PMDUE, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR ) values( '" + COD + "' ," + POL + "," + COM + "," + TBL + "," + TRM + "," + SUM + "," + MOD + "," + PRM + "," + DUE + "," + PAC + "," + AGT + "," + ORG + "," + BRN + "," + OBR + "," + PTR + ")";
                        dal.ExecuteTableUpdateQuery(premastInsert);
                    }
                    else if (STA.Equals("L") && !dal.IsRecordExist(liflapssql) && !dal.IsRecordExist(Dthout))
                    {
                        //string liflapsInsert = "insert into lphs.liflaps(LPCOD, LPPOL, LPCOM, LPTBL, LPTRM, LPSUM, LPMOD, LPPRM, LPDUE, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR ) values( '" + COD + "' ," + POL + "," + COM + "," + TBL + "," + TRM + "," + SUM + "," + MOD + "," + PRM + "," + DUE + "," + PAC + "," + AGT + "," + ORG + "," + BRN + "," + OBR + "," + PTR + ")";
                        //dal.ExecuteTableUpdateQuery(liflapsInsert);

                        //Task 24735
                        if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49) && STA.Equals("L") && MOF.Equals("M") && dal.IsRecordExist(premastsql))
                        {
                            string delpremastsql = "delete from lphs.premast where pmpol=" + polno + "";
                            dal.ExecuteTableUpdateQuery(delpremastsql);
                        } 

                        string liflapsInsert = "insert into lphs.liflaps(LPCOD, LPPOL, LPCOM, LPTBL, LPTRM, LPSUM, LPMOD, LPPRM, LPDUE, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR ) values( '" + COD + "' ," + POL + "," + COM + "," + TBL + "," + TRM + "," + SUM + "," + MOD + "," + PRM + "," + DUE + "," + PAC + "," + AGT + "," + ORG + "," + BRN + "," + OBR + "," + PTR + ")";
                        dal.ExecuteTableUpdateQuery(liflapsInsert); 
                    }
                    //Table 56 Changes
                    else if (STA.Equals("I") && dal.IsRecordExist(premastsql))
                    {
                        string updatepremastsql = "update lphs.premast set PMCOD='" + COD + "', PMDUE=" + DUE + ", PMPRM=" + PRM + " where pmpol=" + polno + "";
                        dal.ExecuteTableUpdateQuery(updatepremastsql);
                    }

                    if (dal.IsRecordExist(Dthout))
                    {
                        string UpdateDthout = "update lphs.dthout set DTHPRO='N',PRODATE=0 where POLNO=" + polno + "";
                        dal.ExecuteTableUpdateQuery(UpdateDthout);
                    }

                    //string polhisDel = "delete from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                    //dal.ExecuteTableUpdateQuery(polhisDel);
                    #region-----------------------------VALUATION MOVEMENT-----------------------
                    // procedure MOVEMENT_DEATH(v_SUBCODE in number , p_POLICYNO in number, p_COMMENCEMENT_date in number, p_PLAN in number, p_TERM in number, p_SUMASSURED in number, p_MODE_CODE in number, p_PREMIUM in number,p_TRANSACTION_DATE in date, p_EXIT_DUE in number)
                    List<StoredProcedureInputParameters> inputParaList = new List<StoredProcedureInputParameters>();
                    inputParaList.Add(new StoredProcedureInputParameters("v_SUBCODE", 27));
                    inputParaList.Add(new StoredProcedureInputParameters("p_POLICYNO", POL));
                    inputParaList.Add(new StoredProcedureInputParameters("p_COMMENCEMENT_date", COM));
                    inputParaList.Add(new StoredProcedureInputParameters("p_PLAN", TBL));
                    inputParaList.Add(new StoredProcedureInputParameters("p_TERM", TRM));
                    inputParaList.Add(new StoredProcedureInputParameters("p_SUMASSURED", SUM));
                    inputParaList.Add(new StoredProcedureInputParameters("p_MODE_CODE", MOD));
                    inputParaList.Add(new StoredProcedureInputParameters("p_PREMIUM", PRM));
                    inputParaList.Add(new StoredProcedureInputParameters("p_TRANSACTION_DATE", System.DateTime.Now));
                    inputParaList.Add(new StoredProcedureInputParameters("p_EXIT_DUE", DUE));
                    inputParaList.Add(new StoredProcedureInputParameters("p_MOS", MOF));
                    dal.ExecuteSotredProcedure("VALUATION.VMEX.MOVEMENT_DEATH", inputParaList);

                    #endregion

                    #region-----------------------------CLEAR MATURITY(2015/04/10)-----------------------
                     

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

                    if (matClearflag)
                    {
                        List<StoredProcedureInputParameters> inputParaList1 = new List<StoredProcedureInputParameters>();
                        inputParaList1.Add(new StoredProcedureInputParameters("policyno", polno.ToString()));
                        inputParaList1.Add(new StoredProcedureInputParameters("sysid", "D"));
                        inputParaList1.Add(new StoredProcedureInputParameters("ftype", "R"));
                        inputParaList1.Add(new StoredProcedureInputParameters("dateofdthorsurrn", dateofdeath));
                        inputParaList1.Add(new StoredProcedureInputParameters("tblno", TBL));
                        inputParaList1.Add(new StoredProcedureInputParameters("ptype", MOF));
                        dal.ExecuteSotredProcedure("LPHS.MATURITY_CLEAR_DEATH", inputParaList1);
                        inputParaList1.Clear();
                    }
                    #endregion

                    string polhisDel = "delete from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                    dal.ExecuteTableUpdateQuery(polhisDel);
                }

                #endregion

                #region //**************** Checking Cheque print status - Editted by Dushan**********************
                string cashBookcheck = "select PRINT1, VOU_LEVEL from CASHBOOK.TEMP_CB where POLNO='" + polno + "' and CLAIMNO in (select to_char(DRCLMNO) from LPHS.DTHREF where DRPOLNO='" + polno + "' and drclmno=" + claimNo + ") and VOUNO LIKE 'T%'";
                using (DataTable dataTable = dal.ReadSQLtoDataTable(cashBookcheck))
                {
                    int print = 0;
                    String mis;
                    using (DataTableReader cashbookreader = dataTable.CreateDataReader())
                    {
                        while (cashbookreader.Read())
                        {
                            if (!cashbookreader.IsDBNull(0)) { print = Convert.ToInt32(cashbookreader[0]); } else { print = 0; }
                            if (!cashbookreader.IsDBNull(1)) { mis = cashbookreader.GetString(1); } else { mis = "N"; }

                            if ((print == 1) || (mis == "Y"))
                            {
                                throw new Exception("Cheque Already Printed. Claim Cannot be Reversed!");
                            }
                        }
                    }
                }



                #endregion

                #region//**************** Restoring DTHINT table ********************************************
                string dthintRestore = "update lphs.dthint set dsta='0', dconfst='', DDTOFDTH=0  where dpolno=" + polno + " and dmos='" + MOF + "' ";

                //string dthintRestore = "update lphs.dthint set dsta='0', dconfdat=0, dconfepf='',dconfip='', dconfbr=0, dconftime='', dconfst='',DDTOFDTH=0  where dpolno=" + polno + " and dmos='" + MOF + "' ";

                
                dal.ExecuteTableUpdateQuery(dthintRestore);
                #endregion

                #region  //**************** Restoring Loan Details *********************************************

                string checkForLoan = " select LOANNO,  RECIEPTNO  ,PRINTDATE ,BRANCH from  lphs.LOAN_RCIEPT_REPRINT where POLINO = " + polno + "  and TYPE_OF_SETTLMNT = 'D'";
                //"select LLON from LPAY.LPLLEDG where LPOL=" + polno + " and LTYP1='D' and lptp=10";
                using (DataTable dataTable = dal.ReadSQLtoDataTable(checkForLoan))
                {
                    using (DataTableReader loanReader = dataTable.CreateDataReader())
                    {
                        int receiptNumber = 0, loanNumber = 0, receiptDate = 0, receiptBranch = 0, count = 0;
                        
                        while (loanReader.Read())
                        {
                            loanNumber = Convert.ToInt32(loanReader[0]);
                            receiptNumber = Convert.ToInt32(loanReader.GetString(1).Split('/')[1]);
                            receiptDate = Convert.ToInt32(loanReader[2]);
                            receiptBranch = Convert.ToInt32(loanReader[3]);

                            count++;
                        }
                        switch (count)
                        {
                            case 0:
                                this.testlbl.Text = "No Loans";
                                break;
                            case 1:
                                List<StoredProcedureInputParameters> inputParaList = new List<StoredProcedureInputParameters>();

                                inputParaList.Add(new StoredProcedureInputParameters("loanNumber", loanNumber));
                                inputParaList.Add(new StoredProcedureInputParameters("policyNumber", polno));
                                inputParaList.Add(new StoredProcedureInputParameters("dateOfDeath", dateofdeath));
                                inputParaList.Add(new StoredProcedureInputParameters("receiptNumber", receiptNumber));
                                inputParaList.Add(new StoredProcedureInputParameters("receiptDate", receiptDate));
                                inputParaList.Add(new StoredProcedureInputParameters("receiptBranch", receiptBranch));
                                inputParaList.Add(new StoredProcedureInputParameters("machineIP", ipADDR));
                                inputParaList.Add(new StoredProcedureInputParameters("EPF", EPF));

                                dal.ExecuteSotredProcedure("lpay.life_functions.loanBackCalculationReverse", inputParaList);
                                break;
                            default:
                                throw new Exception("Can not reverse more than  one loan");
                        }
                    }
                }




                #endregion

                #region  //**************** reversing payee tables ***********************************************

                ArrayList vounoArray = new ArrayList();
                ArrayList ADBvounoArray = new ArrayList();
                string vouno = "";
                string ADBvouno = "";
                string payee = "";

                string payeeSel = "select payee from lphs.dthref where drpolno = " + polno + " and drmos = '" + MOF + "'  ";
                if (dal.IsRecordExist(payeeSel))
                {
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(payeeSel))
                    {
                        using (DataTableReader payeeReader = dataTable.CreateDataReader())
                        {
                            while (payeeReader.Read())
                            {
                                if (!payeeReader.IsDBNull(0)) { payee = payeeReader.GetString(0); } else { payee = ""; }
                            }
                        }
                    }
                    #region//**************** Delete from DTHREF  & insert to DTHREFHIS

                    string dthrefhisInsert = @"insert into lphs.dthrefhis 
                        ( select   DRPOLNO , DRMOS ,DRCLMNO , DRACCBF , DRAGEADMIT ,DRRINSYN ,DRREVIVALS , DRASSIGNEENOM , DRVESTEDBON , DRINTERIMBON , DRBONSURRAMT ,
                                   DRBONSURRYR , DRSWARNAJAYA , DRFUNERALEXP , DRFPU , DRDEPOSITS , DROTHERADITNS , DRGROSSCLM , DEOTHERDEDUCT , DRDEFPREM , DRINT ,
                                   DRLONCAP , DRLOANINT ,DRNETCLM , DRPAIDNO , DRAGT , DRNETSURR , DCAUSEOFDTH , DDECISION , DLOW , DENTDT , DENTEPF ,ADBPAYAMT , SJPAYAMT ,
                                   FPUPAYAMT , FEPAYAMT , CAUSEOFDEATHSTR ,SMASS_PVAL , REFUND_OF_PREMS , AMTOUT , MEMOAPRV , APRVDATE , APRVEPF , PAYEE , TOTPAYAMT , PAYAUTDT ,
                                   PAYAUTEPF , COMPLETED , FE_EARLYPAY , ADB_LATEPAY , DISTN_AUT , DISTN_AUTDATE , DISTN_AUTEPF , EXGRACIA_AMOUNT ,AGE_STATUS , AGE_AMT , 
                                   INTBONSTYR , MINUTES , BRANCH , POL_COMPLETED , AMT_TO_COMPLETE , THR_STG_PMNT , POL_COMPL_YN , DRADMITNO ,AGEDIFINRST , MEMO_CREATED_DATE ,
                                   MEMO_CREATED_EPF, sysdate, '" + ipADDR + "' , '" + EPF + "' from lphs.dthref where drpolno = " + polno + " and drmos = '" + MOF + "' )";
                    dal.ExecuteTableUpdateQuery(dthrefhisInsert);

                    string dthrefDel = "delete from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "'";
                    dal.ExecuteTableUpdateQuery(dthrefDel);

                    #endregion

                    if (payee.Equals("NOM"))
                    {
                        #region LUND.NOMINEE
                        string nomSelect = "select NOMNAM, NOMPER, VOUNO, ADBVOUNO from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(nomSelect))
                        {
                            using (DataTableReader nomineeReader = dataTable.CreateDataReader())
                            {
                                while (nomineeReader.Read())
                                {
                                    if (!nomineeReader.IsDBNull(2)) { vouno = nomineeReader.GetString(2); } else { vouno = ""; }
                                    if (!nomineeReader.IsDBNull(3)) { ADBvouno = nomineeReader.GetString(3); } else { ADBvouno = ""; }

                                    vounoArray.Add(vouno);
                                    if ((ADBvouno != null) && (!ADBvouno.Equals(""))) { ADBvounoArray.Add(ADBvouno); }
                                }

                                string nomUpd = "UPDATE LUND.NOMINEE SET PAYSTATUS = '' , VOUSTA = '' , VOUNO = '' , ADBVOUSTA = '' , ADBVOUNO = '' , PAYAUTDATE = 0 , " +
                                    " PAYAUTEPF = '' , ADBAUTDATE = 0 , ADBAUTEPF = '', VOUDATE='', ADBVOUDATE='', NOMSHARE='' WHERE POLNO = " + polno + " ";
                                dal.ExecuteTableUpdateQuery(nomUpd);
                            }
                        }


                        #endregion
                    }
                    else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                    {
                        #region lphs.legal_hires
                        string heireSelect = "select VOUNO, ADBVOUNO from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' ";
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(heireSelect))
                        {
                            using (DataTableReader heireSelectReader = dataTable.CreateDataReader())
                            {
                                while (heireSelectReader.Read())
                                {
                                    if (!heireSelectReader.IsDBNull(0)) { vouno = heireSelectReader.GetString(0); } else { vouno = ""; }
                                    if (!heireSelectReader.IsDBNull(1)) { ADBvouno = heireSelectReader.GetString(1); } else { ADBvouno = ""; }

                                    vounoArray.Add(vouno);
                                    if ((ADBvouno != null) && (!ADBvouno.Equals(""))) { ADBvounoArray.Add(ADBvouno); }
                                }
                                if (heireSelectReader.HasRows)
                                {
                                    string lhiUpd = "UPDATE LPHS.LEGAL_HIRES SET LHSHARE = 0 , LHAMOUNT = 0 , LHPAYST = '' , VOUSTA = '' , VOUNO = '', VOUDATE='', ADBVOUSTA = '' , ADBVOUNO = '', ADBVOUDATE='', " +
                                        "ADBAMT = 0 , PAYAUTDATE = 0 , PAYAUTEPF = '' , ADBAUTDATE = 0 , ADBAUTEPF = '' WHERE lhpolno=" + polno + " and lhmof='" + MOF + "' ";
                                    dal.ExecuteTableUpdateQuery(lhiUpd);
                                }
                            }
                        }



                        #endregion
                    }
                    else if (payee.Equals("ASI"))
                    {
                        #region  LUND.ASSIGNEE

                        //string asiSelect = "select ASS_FULLNAME, VOUNO, ADBVOUNO from LUND.ASSIGNEE  where POLICY_NO = " + polno + " and vouno is not null ";
                        string asiSelect = "select ASS_FULLNAME, VOUNO, ADBVOUNO from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";

                        using (DataTable dataTable = dal.ReadSQLtoDataTable(asiSelect))
                        {
                            using (DataTableReader prassReader = dataTable.CreateDataReader())
                            {
                                while (prassReader.Read())
                                {
                                    if (!prassReader.IsDBNull(1)) { vouno = prassReader.GetString(1); } else { vouno = ""; }
                                    if (!prassReader.IsDBNull(2)) { ADBvouno = prassReader.GetString(2); } else { ADBvouno = ""; }

                                    vounoArray.Add(vouno);
                                    if ((ADBvouno != null) && (!ADBvouno.Equals(""))) { ADBvounoArray.Add(ADBvouno); }
                                }
                                if (prassReader.HasRows)
                                {
                                    string assigneeUPD = "UPDATE LUND.ASSIGNEE SET VOUSTA = '' , VOUNO = '' , ADBVOUSTA = '' , ADBVOUNO = '' , PAYAUTDATE = 0 , PAYAUTEPF = '' , ADBAUTDATE = 0 ," +
                                        " ADBAUTEPF = '' WHERE  POLICY_NO = " + polno + " ";
                                    dal.ExecuteTableUpdateQuery(assigneeUPD);
                                }
                            }
                        }
                        #endregion
                    }
                    else if (payee.Equals("LPT"))
                    {
                        #region  LUND.LIVING_PRT

                        string living_prtSelect = "select NOMNAM, NOMPER, VOUNO, ADBVOUNO from LUND.LIVING_PRT where polno = " + polno + " ";

                        using (DataTable dataTable = dal.ReadSQLtoDataTable(living_prtSelect))
                        {
                            using (DataTableReader nomineeReader = dataTable.CreateDataReader())
                            {
                                while (nomineeReader.Read())
                                {
                                    if (!nomineeReader.IsDBNull(2)) { vouno = nomineeReader.GetString(2); } else { vouno = ""; }
                                    if (!nomineeReader.IsDBNull(3)) { ADBvouno = nomineeReader.GetString(3); } else { ADBvouno = ""; }

                                    vounoArray.Add(vouno);
                                    if ((ADBvouno != null) && (!ADBvouno.Equals(""))) { ADBvounoArray.Add(ADBvouno); }
                                }

                                if (nomineeReader.HasRows)
                                {
                                    string lptUpd = "UPDATE LUND.LIVING_PRT SET PAYSTATUS = '' , VOUSTA = '' , VOUNO = '' , ADBVOUSTA = '' , " +
                                      " ADBVOUNO = '' , PAYAUTDATE = 0 , PAYAUTEPF = '' , ADBAUTDATE = 0 , ADBAUTEPF = '' WHERE polno = " + polno + " ";
                                    dal.ExecuteTableUpdateQuery(lptUpd);
                                }
                            }
                        }

                        #endregion
                    }
                }
                else
                {
                    throw new Exception("No Terminated Police Details Found.");
                }


                #endregion

                #region//**************** Deleting ADB Payments **********************************************************************
                string dthADBPayDel = "delete from LPHS.DTH_ADBPAYMENTS where POLICY_NO=" + polno + " and MOS='" + MOF + "' ";
                dal.ExecuteTableUpdateQuery(dthADBPayDel);

                string dthADBDisDel = "delete from LPHS.DTH_ADBPAYMENT_DISTN where policy_no=" + polno + " and mos='" + MOF + "' ";
                dal.ExecuteTableUpdateQuery(dthADBDisDel);

                string dthADBRejDel = "delete from LPHS.DTH_ADBPAYEE_REJECT where POLICY_NO=" + polno + " and MOS='" + MOF + "' ";
                dal.ExecuteTableUpdateQuery(dthADBRejDel);
                #endregion

                #region//---------------reversing PERIODIC_PAYDET--------------------
                string periodicdel = "delete from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and LIFE_TYP='" + MOF + "' and CLMTYPE='DTC'";
                dal.ExecuteTableUpdateQuery(periodicdel);
                #endregion

                #region//-------------Deleted Demands Restoring-----Editted By Dushan------------
                int deathym = int.Parse(dateofdeath.ToString().Substring(0, 6));
                string selectdem = "select * from lphs.demand_del where pdpol='" + polno + "' and pddue >=" + deathym + " and (pdcod='1' or pdcod='2' or pdcod='3')";
                string selectddm = "select * from lphs.demand where pdpol='" + polno + "' and pddue >=" + deathym + " and (pdcod='1' or pdcod='2' or pdcod='3')";

                if (dal.IsRecordExist(selectdem) && !dal.IsRecordExist(selectddm))
                {
                    //Task 29459 - Demand Delete
                    string demanddel = "DELETE FROM LPHS.DEMAND WHERE PDPOL = " + polno + " AND STATUS = 'D'";
                    dal.ExecuteTableUpdateQuery(demanddel);
                    //

                    string demanddelinsert = "insert into lphs.demand(PDCOD, PDPOL, PDDUE, PDPRM, PDPAC, PDTAB, PDTER, PDPDT, STATUS) select " +
                        "PDCOD, PDPOL, PDDUE, PDPRM, PDPAC, PDTAB, PDTER, PDPDT, STATUS from lphs.demand_del where pdpol='" + polno + "' and pddue >=" + deathym + " and (pdcod='1' or pdcod='2' or pdcod='3')";
                    dal.ExecuteTableUpdateQuery(demanddelinsert);
                    string demanddelete = "delete from lphs.demand_del where pdpol='" + polno + "' and pddue >=" + deathym + " and (pdcod='1' or pdcod='2' or pdcod='3')";
                    dal.ExecuteTableUpdateQuery(demanddelete);
                }
                #endregion

                #region //**************** ledger reverse and commission reverse ********************************

                int today = int.Parse(this.setDate()[0]);
                int DPDDUE = 0; string INSERT_TYPE = ""; string DPCOD = ""; int DPPDT = 0;
                string ddeamndSel = "select DPDDUE, INSERT_TYPE, DPCOD, DPPDT from LPHS.DDEMAND where DPDPOL = " + polno + " and SETTLMNT_TYPE = 'D'";
                if (dal.IsRecordExist(ddeamndSel))
                {
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(ddeamndSel))
                    {
                        using (DataTableReader ddemReader = dataTable.CreateDataReader())
                        {
                            while (ddemReader.Read())
                            {
                                if (!ddemReader.IsDBNull(0)) { DPDDUE = Convert.ToInt32(ddemReader[0]); } else { DPDDUE = 0; }
                                if (!ddemReader.IsDBNull(1)) { INSERT_TYPE = ddemReader.GetString(1); } else { INSERT_TYPE = ""; }
                                if (!ddemReader.IsDBNull(2)) { DPCOD = ddemReader.GetString(2); } else { DPCOD = ""; }
                                if (!ddemReader.IsDBNull(3)) { DPPDT = Convert.ToInt32(ddemReader[3]); } else { DPPDT = 0; }

                                string ledgersel = "select * from LCLM.LEDGER where llpol = " + polno + " and lldue =" + DPDDUE + "  and lltyp = 1 and llcod = 8";
                                string ledgerhissel = "SELECT nvl(max(REVERSE_COUNT),0) FROM LCLM.LEDGERHIS WHERE LLPOL=" + polno + " and lldue =" + DPDDUE + "  and lltyp = 1";
                                if (dal.IsRecordExist(ledgersel))
                                {
                                    int reverse = 0;
                                    using (DataTable dataTable1 = dal.ReadSQLtoDataTable(ledgerhissel))
                                    {
                                        using (DataTableReader ledgerhisreader = dataTable1.CreateDataReader())
                                        {
                                            ledgerhisreader.Read();
                                            if (!ledgerhisreader.IsDBNull(0)) { reverse = Convert.ToInt32(ledgerhisreader[0]); }
                                            reverse++;
                                        }
                                    }

                                    string ledgerhisinsert = " insert into lclm.ledgerhis(select LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT, LLPBR, LLREC," + EPF + "," + today + ",'DT'," + reverse + " from lclm.ledger where LLPOL=" + polno + " and lldue =" + DPDDUE + "  and lltyp = 1)";

                                    dal.ExecuteTableUpdateQuery(ledgerhisinsert);

                                    string ledgerDel = "delete from LCLM.LEDGER  where llpol = " + polno + " and lldue =" + DPDDUE + "  and lltyp = 1 and llcod = 8";
                                    dal.ExecuteTableUpdateQuery(ledgerDel);
                                }

                                string lpaycomSelect = "select * from lpay.lpaycom where  lcpol=" + polno + "  and lcdue= " + DPDDUE + " and lcbtp='11' ";
                                if (dal.IsRecordExist(lpaycomSelect))
                                {
                                    string lpayComDelete = "UPDATE LPAY.LPAYCOM SET LCFST = '1',LCREV=" + today + " WHERE  lcpol=" + polno + "  and lcdue= " + DPDDUE + " and lcbtp='11'  ";
                                    dal.ExecuteTableUpdateQuery(lpayComDelete);

                                    string lpaycomrevsel = "select LCPOL,REVERSE_COUNT from lpay.lpaycomrev where   lcpol=" + polno + "  and lcdue= " + DPDDUE + " and lcbtp='11'  ";
                                    if (!dal.IsRecordExist(lpaycomrevsel))
                                    {
                                        string lpaycomhisin = "insert into LPAY.LPAYCOMREV " +
                                                               "(select  LCPBR, LCPDT, LCBTP, LCPOL, LCDUE, LCTBL, LCTRM, LCMOD, LCPRM, LCCDT, LCCOD, LCPAC, " +
                                        "LCAGT, LCORG, LCSBR, LCREC, LCCCD, LCREV,LCFST, LCOMDAT, LCLATEFEE," + today + "," + EPF + ",1,'0',null,sysdate" + // jayampathi 2011/01/05 remove field name part (LCPBR,LCPDT,LCBTP,LCPOL,LCDUE,LCTBL......)
                                                        " from lpay.lpaycom where lcpol=" + polno + "  and lcdue= " + DPDDUE + "  and lcbtp='11' )";// jayampathi , 2010/12/02 , add to query '0',null,sysdate
                                        dal.ExecuteTableUpdateQuery(lpaycomhisin);
                                    }
                                    else
                                    {
                                        int reverse = 0;

                                        using (DataTable dataTable1 = dal.ReadSQLtoDataTable(lpaycomrevsel))
                                        {
                                            using (DataTableReader ledgerhisread = dataTable1.CreateDataReader())
                                            {
                                                ledgerhisread.Read();
                                                if (!ledgerhisread.IsDBNull(1)) { reverse = Convert.ToInt32(ledgerhisread[1]); } else { reverse = 0; }
                                                reverse++;
                                            }
                                        }
                                        string updlpcomrev = "UPDATE LPAY.lpaycomrev SET REVERSE_COUNT=" + reverse + " where  lcpol=" + polno + "  AND lcdue= " + DPDDUE + " and lcbtp='11' ";
                                        dal.ExecuteTableUpdateQuery(updlpcomrev);
                                    }
                                }

                                string demSel = "SELECT PDPOL FROM LPHS.DEMAND WHERE PDPOL = " + polno + " and PDDUE = " + DPDDUE + " ";

                                string demandUpd = "UPDATE LPHS.DEMAND SET PDCOD = '" + DPCOD + "' , PDPDT = " + DPPDT + " WHERE PDPOL = " + polno + " and PDDUE = " + DPDDUE + " ";
                                dal.ExecuteTableUpdateQuery(demandUpd);

                            }
                        }
                    }
                }
                string ddemanddel = "DELETE FROM LPHS.DDEMAND WHERE DPDPOL = " + polno + " AND SETTLMNT_TYPE = 'D'";
                dal.ExecuteTableUpdateQuery(ddemanddel);
                #endregion

                #region.....LPAYMAS Reverse for Default Premium....
                int lmlrd_rdc = 0, lmebr_entbr = 0, lmrnb_rcptno = 0;
                string ledgersel2 = "select * from LCLM.LEDGER where llpol = " + polno + " and lltyp = 1 and llcod = 8";
               // if (dal.IsRecordExist(ledgersel2))
               // {
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(ledgersel2))
                    {
                        using (DataTableReader LedReader = dataTable.CreateDataReader())
                        {
                            while (LedReader.Read())
                            {
                                if (!LedReader.IsDBNull(0)) { DPDDUE = Convert.ToInt32(LedReader[1]); } else { DPDDUE = 0; }
                                if (!LedReader.IsDBNull(6)) { lmlrd_rdc = Convert.ToInt32(LedReader[6]); } else { lmlrd_rdc = 0; }
                                if (!LedReader.IsDBNull(7)) { lmebr_entbr = Convert.ToInt32(LedReader[7]); } else { lmebr_entbr = 0; }
                                if (!LedReader.IsDBNull(8)) { lmrnb_rcptno = Convert.ToInt32(LedReader.GetString(8).Trim()); } else { lmrnb_rcptno = 0; }

                                string lpaymasUPD1 = "update lpay.lpaymas set lpsta=1 where lpbrn = " + lmebr_entbr + " and lpptd = " + lmlrd_rdc + " and lpbtp = 11 and lprec = " + lmrnb_rcptno + "  ";
                                dal.ExecuteTableUpdateQuery(lpaymasUPD1);
                            }
                        }
                   // }
                }
                #endregion

                #region........Sundry Payment From Death Reverse.............

                string ledgersel1 = "select * from LCLM.LEDGER where llpol = " + polno + " and lltyp = 5 and llcod = 8";
                if (dal.IsRecordExist(ledgersel1))
                {
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(ledgersel1))
                    {
                        using (DataTableReader ddemReader = dataTable.CreateDataReader())
                        {
                            while (ddemReader.Read())
                            {
                                if (!ddemReader.IsDBNull(0)) { DPDDUE = Convert.ToInt32(ddemReader[1]); } else { DPDDUE = 0; }
                                if (!ddemReader.IsDBNull(6)) { lmlrd_rdc = Convert.ToInt32(ddemReader[6]); } else { lmlrd_rdc = 0; }
                                if (!ddemReader.IsDBNull(7)) { lmebr_entbr = Convert.ToInt32(ddemReader[7]); } else { lmebr_entbr = 0; }
                                if (!ddemReader.IsDBNull(8)) { lmrnb_rcptno = Convert.ToInt32(ddemReader.GetString(8).Trim()); } else { lmrnb_rcptno = 0; }

                                //...........REVERSE LPAY.LPAYCOM..................

                                string lpayComDelete = "UPDATE LPAY.LPAYCOM SET LCFST = '1',LCREV=" + today + " WHERE lcbtp='16' and lcpol=" + polno + "  and lcdue= " + DPDDUE + " ";
                                dal.ExecuteTableUpdateQuery(lpayComDelete);

                                string lpaycomrevsel = "select LCPOL,REVERSE_COUNT from lpay.lpaycomrev where lcbtp='16' and lcpol=" + polno + "  and lcdue= " + DPDDUE + " ";
                                if (!dal.IsRecordExist(lpaycomrevsel))
                                {
                                    string lpaycomhisin = "insert into LPAY.LPAYCOMREV(select  LCPBR, LCPDT, LCBTP, LCPOL, LCDUE, LCTBL, LCTRM, LCMOD, LCPRM, LCCDT, LCCOD, LCPAC, " +
                                                          " LCAGT, LCORG, LCSBR, LCREC, LCCCD, LCREV,LCFST, LCOMDAT, LCLATEFEE," + today + "," + EPF + ",1,'0',null,sysdate from lpay.lpaycom " +
                                                          " where lcbtp='16' and lcpol=" + polno + "  and lcdue= " + DPDDUE + " )"; // jayampathi , 2010/12/02 , add to query '0',null,sysdate
                                    dal.ExecuteTableUpdateQuery(lpaycomhisin);
                                }
                                else
                                {
                                    int reverse = 0;
                                    using (DataTable dataTable1 = dal.ReadSQLtoDataTable(lpaycomrevsel))
                                    {
                                        using (DataTableReader ledgerhisread = dataTable1.CreateDataReader())
                                        {
                                            ledgerhisread.Read();
                                            if (!ledgerhisread.IsDBNull(1)) { reverse = Convert.ToInt32(ledgerhisread[1]); } else { reverse = 0; }
                                            reverse++;
                                        }
                                    }
                                    string updlpcomrev = "UPDATE LPAY.lpaycomrev SET REVERSE_COUNT=" + reverse + " where lcbtp='16' AND lcpol=" + polno + "  AND lcdue= " + DPDDUE + " ";
                                    dal.ExecuteTableUpdateQuery(updlpcomrev);
                                }
                            }
                        }
                    }
                    //......Insert into ledger history.....
                    string ledgerhisinsert = "insert into lclm.ledgerhis(select LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT,";
                    ledgerhisinsert += "LLPBR, LLREC," + EPF + "," + today + ",'DS',1 from lclm.ledger where LLPOL=" + polno + " and lldue =" + DPDDUE + "  and lltyp = 5)";
                    dal.ExecuteTableUpdateQuery(ledgerhisinsert);
                    //............................................

                    //...........Delete Ledger............
                    string ledgerhisdel = "delete from LCLM.LEDGER where LLPOL=" + polno + " and lltyp = 5 and llcod = 8";
                    dal.ExecuteTableUpdateQuery(ledgerhisdel);

                    //......Delete Tag on LCLM.SUNDRY_RCPT.....
                    string deleteSundry = "UPDATE LCLM.SUNDRY_RCPT SET DELCOD = 1 WHERE SPOLNO=" + polno + " AND SYSCODE='D'";
                    dal.ExecuteTableUpdateQuery(deleteSundry);
                }

                //..........REVERSSE LPAY.LAPYMAS...................
                //string lpaymasCheck11 = "select * from lpay.lpaymas where lpbrn = " + lmebr_entbr + " and lpptd = " + lmlrd_rdc + " and lpbtp = 16 and lprec = " + lmrnb_rcptno + " ";

                //if (dal.IsRecordExist(lpaymasCheck11))
                //{
                    string lpaymasUPD = "update lpay.lpaymas set lpsta=1 where lpbrn = " + lmebr_entbr + " and lpptd = " + lmlrd_rdc + " and lpbtp = 16 and lprec = " + lmrnb_rcptno + "  ";
                    dal.ExecuteTableUpdateQuery(lpaymasUPD);
                //}

                //........Delete Records from LPHS.SUNDRY_DETAIL...........
                string detailDel = "DELETE FROM LCLM.SUNDRY_DETAIL WHERE SPOLNO=" + polno + " AND DUEYRMN=" + DPDDUE + "";
                dal.ExecuteTableUpdateQuery(detailDel);

                //........................................................

                #endregion

                #region  //**************** voucher detalil reverse **********************************************

                foreach (string vounum in vounoArray)
                {
                    string tempcbCheck = "select * from CASHBOOK.TEMP_CB where vouno='" + vounum + "'";
                    if (dal.IsRecordExist(tempcbCheck))
                    {

                        string tyempCBdel = "UPDATE CASHBOOK.TEMP_CB SET DELETED = '1',STATUS='Cancelled',CHQCAN='1',VOU_LEVEL='N' where vouno = '" + vounum + "' ";
                        dal.ExecuteTableUpdateQuery(tyempCBdel);

                        string VOUCHER_LOG_ENTRYinsert = "insert into cashbook.Voucher_Log_Entry(Voucher_No,RETURN_USER,RETURN_DATE) VALUES ('" + vounum + "', '" + EPF + "', to_date('" + this.setDate()[0] + "', 'yyyymmdd'))";
                        dal.ExecuteTableUpdateQuery(VOUCHER_LOG_ENTRYinsert);

                    }
                }

                foreach (string ADBvounum in ADBvounoArray)
                {
                    string tempcbCheck = "select * from cashbook.temp_cb where vouno='" + ADBvounum + "'";
                    if (dal.IsRecordExist(tempcbCheck))
                    {
                        string tyempCBdel = "UPDATE CASHBOOK.TEMP_CB SET DELETED = '1',STATUS='Cancelled',CHQCAN='1',VOU_LEVEL='N' where vouno = '" + ADBvounum + "' ";
                        dal.ExecuteTableUpdateQuery(tyempCBdel);

                        string VOUCHER_LOG_ENTRYinsert = "insert into cashbook.Voucher_Log_Entry(Voucher_No,RETURN_USER,RETURN_DATE) VALUES ('" + vouno + "', '" + EPF + "', to_date('" + this.setDate()[0] + "', 'yyyymmdd'))";
                        dal.ExecuteTableUpdateQuery(VOUCHER_LOG_ENTRYinsert);
                    }
                }
                #endregion

                #region//-------------Reversing SLIC Vouchers-------------------------------
                string slicvousel = "select SVVOUNO from LPHS.SLICVOUCHERS where SVPOL=" + polno + "";
                if (dal.IsRecordExist(slicvousel))
                {
                    string vou;
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(slicvousel))
                    {
                        using (DataTableReader slicvoureader = dataTable.CreateDataReader())
                        {
                            while (slicvoureader.Read())
                            {
                                if (!slicvoureader.IsDBNull(0)) { vou = slicvoureader.GetString(0); } else { vou = ""; }

                                string tempcbdel = "UPDATE CASHBOOK.TEMP_CB SET DELETED = '1',STATUS='Cancelled',CHQCAN='1',VOU_LEVEL='N' where VOUNO='" + vou + "'";
                                dal.ExecuteTableUpdateQuery(tempcbdel);
                                string tempdetldel = "delete from CASHBOOK.TEMP_DETL where VOUNO='" + vou + "'";
                                dal.ExecuteTableUpdateQuery(tempdetldel);
                            }
                        }
                    }
                    string slicvoudel = "delete from LPHS.SLICVOUCHERS where SVPOL=" + polno + "";
                    dal.ExecuteTableUpdateQuery(slicvoudel);
                }
                #endregion

                #region   //**************** Reversing Group entry grpbillingdet ***************************************

                int GBYEAR = 0; int GBMON = 0; string GBSUR = ""; string GBINI = ""; double GBPRM = 0; string GBIDCODE = ""; int GBPAC = 0; int GBPASUBCODE = 0; int GBTRANSDAT = 0; int GBBATCHCODE = 0; int BILLINGTYPE = 0; string FILEST = "";
                string GRPBILLINGsel = "select GBYEAR, GBMON, GBSUR, GBINI, GBPRM, GBIDCODE, GBPAC, GBPASUBCODE, GBTRANSDAT, GBBATCHCODE, BILLINGTYPE, FILEST from LPHS.GRPBILLINGHIS where gbpol = " + polno + " and CLM_SETTLE_TYPE = 'D' ";
                //if (dal.IsRecordExist(GRPBILLINGsel))
                //{
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(GRPBILLINGsel))
                    {
                        using (DataTableReader grpbillingRader = dataTable.CreateDataReader())
                        {
                            while (grpbillingRader.Read())
                            {
                                if (!grpbillingRader.IsDBNull(0)) { GBYEAR = Convert.ToInt32(grpbillingRader[0]); } else { GBYEAR = 0; }
                                if (!grpbillingRader.IsDBNull(1)) { GBMON = Convert.ToInt32(grpbillingRader[1]); } else { GBMON = 0; }
                                if (!grpbillingRader.IsDBNull(2)) { GBSUR = grpbillingRader.GetString(2); } else { GBSUR = ""; }
                                if (!grpbillingRader.IsDBNull(3)) { GBINI = grpbillingRader.GetString(3); } else { GBINI = ""; }
                                if (!grpbillingRader.IsDBNull(4)) { GBPRM =Convert.ToDouble( grpbillingRader[4]); } else { GBPRM = 0; }
                                if (!grpbillingRader.IsDBNull(5)) { GBIDCODE = grpbillingRader.GetString(5); } else { GBIDCODE = ""; }
                                if (!grpbillingRader.IsDBNull(6)) { GBPAC = Convert.ToInt32(grpbillingRader[6]); } else { GBPAC = 0; }
                                if (!grpbillingRader.IsDBNull(7)) { GBPASUBCODE = Convert.ToInt32(grpbillingRader[7]); } else { GBPASUBCODE = 0; }
                                if (!grpbillingRader.IsDBNull(8)) { GBTRANSDAT = Convert.ToInt32( grpbillingRader[8]); } else { GBTRANSDAT = 0; }
                                if (!grpbillingRader.IsDBNull(9)) { GBBATCHCODE = Convert.ToInt32(grpbillingRader[9]); } else { GBBATCHCODE = 0; }
                                if (!grpbillingRader.IsDBNull(10)) { BILLINGTYPE = Convert.ToInt32( grpbillingRader[10]); } else { BILLINGTYPE = 0; }
                                if (!grpbillingRader.IsDBNull(11)) { FILEST = grpbillingRader.GetString(11); } else { FILEST = ""; }

                                string billingSelect = "select gbpol from lphs.GRPBILLINGDET where gbpol = " + polno + " ";
                                if (!dal.IsRecordExist(billingSelect))
                                {
                                    string billingInsert = "INSERT INTO LPHS.GRPBILLINGDET (GBPOL ,GBYEAR ,GBMON ,GBSUR ,GBINI ,GBPRM ,GBIDCODE ,GBPAC ,GBPASUBCODE ,GBTRANSDAT ,GBBATCHCODE ,BILLINGTYPE ,FILEST ) " +
                                        " VALUES (" + polno + " ," + GBYEAR + " ," + GBMON + " ,'" + GBSUR + "' ,'" + GBINI + "' ," + GBPRM + " ,'" + GBIDCODE + "' ," + GBPAC + " ," + GBPASUBCODE + " ," + GBTRANSDAT + " ," + GBBATCHCODE + " ," + BILLINGTYPE + " ,'" + FILEST + "' )";
                                    dal.ExecuteTableUpdateQuery(billingInsert);
                                }
                            }
                        }
                    }
               // }

                string billingDel = "delete from lphs.GRPBILLINGHIS where gbpol = " + polno + " and CLM_SETTLE_TYPE = 'D' ";
                dal.ExecuteTableUpdateQuery(billingDel);

                #endregion

              

                #region Policy Complete Year Reverse by chandana

                #region LPAYMAS Update for completion year
                long receiptNo = 0;
                long ledgDate = 0;
                int ledgBranch = 0;

                //ledger record more than one has same receipt number, So it can retrive that receipt number using one record.
                string getLedgerRec = " SELECT LLDAT,LLPBR,LLREC FROM LCLM.LEDGER WHERE LLPOL=" + polno + " AND LLDUE IN (SELECT DPDDUE  FROM LPHS.DDEMAND WHERE DPDPOL=" + polno + " AND INSERT_TYPE='AFT'  AND  SETTLMNT_TYPE='DYC' AND ROWNUM<2) and lltyp = 1 and llcod = 8 ";
                using (DataTable dataTableLed = dal.ReadSQLtoDataTable(getLedgerRec))
                {
                    using (DataTableReader ledgerReader = dataTableLed.CreateDataReader())
                    {
                        while (ledgerReader.Read())
                        {
                            if (!ledgerReader.IsDBNull(0)) { ledgDate = Convert.ToInt64(ledgerReader[0]); }
                            if (!ledgerReader.IsDBNull(1)) { ledgBranch = Convert.ToInt32(ledgerReader[1]); } //changed by chandana
                            if (!ledgerReader.IsDBNull(2)) { receiptNo = Convert.ToInt64(ledgerReader[2]); }
                        }
                    }
                }


                string lpaymasUPDComp = "update lpay.lpaymas set lpsta=1 where lpbrn = " + ledgBranch + " and lpptd = " + ledgDate + " and lpbtp = 11 and lprec = " + receiptNo + "  ";
                dal.ExecuteTableUpdateQuery(lpaymasUPDComp);

                #endregion
                //-------------------------------------------------------------

                int _demand = 0;
                string completeYearDue = "SELECT DPDDUE  FROM LPHS.DDEMAND WHERE DPDPOL=" + polno + " AND INSERT_TYPE='AFT'  AND  SETTLMNT_TYPE='DYC'";

                using (DataTable dataTable = dal.ReadSQLtoDataTable(completeYearDue))
                {
                    using (DataTableReader demandReader = dataTable.CreateDataReader())
                    {
                        while (demandReader.Read())
                        {
                            _demand = (!demandReader.IsDBNull(0)) ? Convert.ToInt32(demandReader[0]) : _demand = 0;


                            #region Ledger
                            string ledgersel = "select * from LCLM.LEDGER where llpol = " + polno + " and lldue =" + _demand + "  and lltyp = 1 and llcod = 8";
                            string ledgerhissel = "SELECT nvl(max(REVERSE_COUNT),0) FROM LCLM.LEDGERHIS WHERE LLPOL=" + polno + " and lldue =" + _demand + "  and lltyp = 1";

                            if (dal.IsRecordExist(ledgersel))
                            {
                                int reverse = 0;
                                using (DataTable dataTable1 = dal.ReadSQLtoDataTable(ledgerhissel))
                                {
                                    using (DataTableReader ledgerhisreader = dataTable1.CreateDataReader())
                                    {
                                        ledgerhisreader.Read();
                                        if (!ledgerhisreader.IsDBNull(0)) { reverse = Convert.ToInt32(ledgerhisreader[0]); }
                                        reverse++;
                                    }
                                }

                                string ledgerhisinsert = " insert into lclm.ledgerhis(select LLPOL, LLDUE, LLTYP, LLCOD, LLPRM, LLMOD, LLDAT, LLPBR, LLREC," + EPF + "," + today + ",'DT'," + reverse + " from lclm.ledger where LLPOL=" + polno + " and lldue =" + _demand + "  and lltyp = 1)";

                                dal.ExecuteTableUpdateQuery(ledgerhisinsert);

                                string ledgerDel = "delete from LCLM.LEDGER  where llpol = " + polno + " and lldue =" + _demand + "  and lltyp = 1 and llcod = 8";
                                dal.ExecuteTableUpdateQuery(ledgerDel);
                            }
                            #endregion

                            #region LPAYCOM Reverse add Jam's code by chandana changing demand date

                            string lpaycomSelect = "select * from lpay.lpaycom where  lcpol=" + polno + "  and lcdue= " + _demand + " and lcbtp='11' ";
                            if (dal.IsRecordExist(lpaycomSelect))
                            {
                                string lpayComDelete = "UPDATE LPAY.LPAYCOM SET LCFST = '1',LCREV=" + today + " WHERE  lcpol=" + polno + "  and lcdue= " + _demand + " and lcbtp='11'  ";
                                dal.ExecuteTableUpdateQuery(lpayComDelete);

                                string lpaycomrevsel = "select LCPOL,REVERSE_COUNT from lpay.lpaycomrev where   lcpol=" + polno + "  and lcdue= " + _demand + " and lcbtp='11'  ";
                                if (!dal.IsRecordExist(lpaycomrevsel))
                                {
                                    string lpaycomhisin = "insert into LPAY.LPAYCOMREV " +
                                                           "(select  LCPBR, LCPDT, LCBTP, LCPOL, LCDUE, LCTBL, LCTRM, LCMOD, LCPRM, LCCDT, LCCOD, LCPAC, " +
                                    "LCAGT, LCORG, LCSBR, LCREC, LCCCD, LCREV,LCFST, LCOMDAT, LCLATEFEE," + today + "," + EPF + ",1,'0',null,sysdate" + // jayampathi 2011/01/05 remove field name part (LCPBR,LCPDT,LCBTP,LCPOL,LCDUE,LCTBL......)
                                                    " from lpay.lpaycom where lcpol=" + polno + "  and lcdue= " + _demand + "  and lcbtp='11' )";// jayampathi , 2010/12/02 , add to query '0',null,sysdate
                                    dal.ExecuteTableUpdateQuery(lpaycomhisin);
                                }
                                else
                                {
                                    int reverse = 0;

                                    using (DataTable dataTable1 = dal.ReadSQLtoDataTable(lpaycomrevsel))
                                    {
                                        using (DataTableReader ledgerhisread = dataTable1.CreateDataReader())
                                        {
                                            ledgerhisread.Read();
                                            if (!ledgerhisread.IsDBNull(1)) { reverse = Convert.ToInt32(ledgerhisread[1]); } else { reverse = 0; }
                                            reverse++;
                                        }
                                    }
                                    string updlpcomrev = "UPDATE LPAY.lpaycomrev SET REVERSE_COUNT=" + reverse + " where  lcpol=" + polno + "  AND lcdue= " + _demand + " and lcbtp='11' ";
                                    dal.ExecuteTableUpdateQuery(updlpcomrev);
                                }
                            }



                            #endregion


                           




                        }

                    }

                }

                #endregion


                #region DDmand delete for new death record use

                string _ddemanddel = "DELETE FROM LPHS.DDEMAND WHERE DPDPOL = " + polno + " AND INSERT_TYPE='AFT' AND  SETTLMNT_TYPE='DYC'";
                dal.ExecuteTableUpdateQuery(_ddemanddel);

                #endregion



                #region//****************reversing DEPOSITE_TEMP / DEPOSIT****************************************

                //----------Editted By Dushan/Buddhika--------------------------------

                string depositeDel = "delete from lphs.DEPOSITE_TEMP where DPPOLNO=" + polno + " and DPMOS='" + MOF + "'";
                dal.ExecuteTableUpdateQuery(depositeDel);

                string AdjpaymasSelect = "SELECT LPBRN, LPPDT, LPBTP, LPPOL, LPSTA, LPREC, LPAM1 FROM LPHS.ADJPAYMAS WHERE(LPBRN = " + Convert.ToInt32(Session["brcode"]) + ") AND (LPBTP = 55) AND (LPPOL = " + polno + ") AND (LPSTA <> '1')";
                if (dal.IsRecordExist(AdjpaymasSelect))
                {
                    int branch = 0;
                    int date = 0;
                    int type = 0;
                    int receiptno = 0;

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(AdjpaymasSelect))
                    {
                        using (DataTableReader AdjpayMasRader = dataTable.CreateDataReader())
                        {
                            while (AdjpayMasRader.Read())
                            {
                                if (!AdjpayMasRader.IsDBNull(0)) { branch = Convert.ToInt32(   AdjpayMasRader[0]); }
                                if (!AdjpayMasRader.IsDBNull(1)) { date = Convert.ToInt32(AdjpayMasRader[1]); }
                                if (!AdjpayMasRader.IsDBNull(2)) { type = Convert.ToInt32(AdjpayMasRader[2]); }
                                if (!AdjpayMasRader.IsDBNull(5)) { receiptno = Convert.ToInt32(AdjpayMasRader[5]); }

                                string AdjDetail = "SELECT ADJCOD, ADBRN, ADREC, ADJDAT, ADBOC, ADAMT FROM LPHS.ADJDETAILS WHERE (ADJCOD = " + type + ") AND (ADBRN = " + branch
                                                   + ") AND (ADREC = " + receiptno + ") AND (ADJDAT = " + date + ")";
                                if (dal.IsRecordExist(AdjDetail))
                                {
                                    int bocno = 0;
                                    double amount = 0;


                                    using (DataTable dataTable1 = dal.ReadSQLtoDataTable(AdjDetail))
                                    {
                                        using (DataTableReader AdjpayDetalRader = dataTable1.CreateDataReader())
                                        {
                                            while (AdjpayDetalRader.Read())
                                            {
                                                if (!AdjpayDetalRader.IsDBNull(4)) { bocno = Convert.ToInt32( AdjpayDetalRader[4]); }
                                                if (!AdjpayDetalRader.IsDBNull(5)) { amount =  Convert.ToDouble( AdjpayDetalRader[5]); }

                                                string DepositUpdate = "UPDATE LPAY.DEPOSIT SET DPTAM = " + amount + " WHERE DPBOC=" + bocno + "";
                                                dal.ExecuteTableUpdateQuery(DepositUpdate);

                                                string Adjdetaluddate = "UPDATE LPHS.ADJDETAILS SET ADDEL = 1 WHERE (ADJCOD = " + type + ") AND (ADBRN = " + branch
                                                           + ") AND (ADREC = " + receiptno + ") AND (ADJDAT = " + date + ") AND (ADBOC = " + bocno + ")";
                                                dal.ExecuteTableUpdateQuery(Adjdetaluddate);
                                            }
                                        }
                                    }
                                }
                                string AdjPayMasUpdate = "UPDATE LPHS.ADJPAYMAS SET LPSTA = '1',LPDDT=" + Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"))
                                                         + ",LPDEN=" + EPF + " WHERE (LPBRN = " + Convert.ToInt32(Session["brcode"])
                                                         + ") AND (LPBTP = 55) AND (LPPOL = " + polno + ") AND (LPREC = " + receiptno + ")";
                                dal.ExecuteTableUpdateQuery(AdjPayMasUpdate);
                            }
                        }
                    }
                    string InsertADJMASREV = " INSERT INTO LPHS.ADJMASREV(LPBRN, LPPDT, LPBTP, LPREC, LPPOL, LPPTP, LPAM1, LPCCO, LPCA1, LPCA2, LPCA3," +
                                           " LPCA4, LPSBR, LPTIM, LPIPA, LPACD, LPOPR, LPCUR,LPCRT, LPDDT, LPDEN, LPDCOM, LPTBL, LPTRM, LPINST, LPPA, " +
                                           " LPMD, LPAGT, LPORG, LPEDT, LONNO, LONSUF, LON_REC_NO)" +
                                           " (SELECT LPBRN, LPPDT, LPBTP, LPREC, LPPOL, LPPTP, LPAM1, LPCCO, LPCA1, LPCA2, LPCA3, LPCA4, LPSBR, " +
                                           " to_char(to_date('" + DateTime.Now.ToString("hh:mm:ss") + "','hh:MI:SS'),'hh:MI:SS'),'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString()
                                           + "',LPACD, LPOPR, LPCUR, LPCRT," + Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) + ", " + EPF + ", " +
                                           " LPDCOM, LPTBL, LPTRM, LPINST, LPPA, LPMD, LPAGT, LPORG, LPEDT,LONNO,LONSUF, LON_REC_NO FROM LPHS.ADJPAYMAS WHERE (LPBRN = " + Convert.ToInt32(Session["brcode"]) + ") AND (LPBTP = 55) AND (LPPOL = " + polno + ")AND (LPSTA <> '1'))";
                    dal.ExecuteTableUpdateQuery(InsertADJMASREV);
                }
                #endregion//-----------------------------------------------------------

                #region//**************** reversing DREQ **********************************************************************
                string dreqDel = "delete from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' ";
                dal.ExecuteTableUpdateQuery(dreqDel);
                #endregion

                #region//**************** reversing EXGRACIA_AMTS *************************************************************
                string exgrDel = "delete from lphs.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF='" + MOF + "' ";
                dal.ExecuteTableUpdateQuery(exgrDel);
                #endregion

                #region//**************** Reversing Child Prot Mas ******************************************************
                //string childprotmasdel = "delete from lclm.child_prot_mas where polno = " + polno + " and ptable = " + TBL + "";
                //dal.ExecuteTableUpdateQuery(childprotmasdel);
                #endregion

                #region//---------------Reversing VOUBANKDET------------Editted By Dushan----------------
                //This reverse process was done for the purpose of non deleted child protect vouchers in voubankdet.
                //at the earlier stage voubankdet was reversed but only reversed Death claim voucher. This time it will delete 'DC' vouchers.
                string voucherno = "";
                string vouchercode = "";
                string voubankseldc = "select POLICYNO, VOUCHERNO from LPHS.VOUBANKDET where POLICYNO=" + polno + "";
                //if (dal.IsRecordExist(voubankseldc))
                //{
                    using (DataTable dataTable1 = dal.ReadSQLtoDataTable(voubankseldc))
                    {
                        using (DataTableReader voubankdetreader = dataTable1.CreateDataReader())
                        {
                            while (voubankdetreader.Read())
                            {
                                if (!voubankdetreader.IsDBNull(1)) { voucherno = voubankdetreader.GetString(1); } else { voucherno = ""; }
                                if (voucherno != "") { vouchercode = voucherno.ToString().Substring(9, 2); }
                                if (vouchercode == "DC")
                                {
                                    string voubankdetdel = "delete from LPHS.VOUBANKDET where VOUCHERNO = '" + voucherno + "'";
                                    dal.ExecuteTableUpdateQuery(voubankdetdel);
                                }
                            }
                        }
                    }
                //}
                #endregion

                #region//----------------------Reversing Legal_hires------------------
                //string legalHiresel = "select * from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + MOF + "'";
                //if(objRev.existRecored(legalHiresel)!=0)
                //{
                //    string legalhiredel = "delete from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + MOF + "'";
                //    dal.ExecuteTableUpdateQuery(legalhiredel);
                //}
                #endregion

                #region-----------------------Reversing Repudiate Data------------------
                //string repusel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + "";
                //if (dal.IsRecordExist(repusel))
               // {
                    string repudel = "delete from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + "";
                    dal.ExecuteTableUpdateQuery(repudel);
                //}
                #endregion

                #region-----------------------------CLEAR MATURITY(2011/04/03)-----------------------

                //List<StoredProcedureInputParameters> inputParaList1 = new List<StoredProcedureInputParameters>();
                //inputParaList1.Add(new StoredProcedureInputParameters("policyno", polno.ToString()));
                //inputParaList1.Add(new StoredProcedureInputParameters("sysid", "D"));
                //inputParaList1.Add(new StoredProcedureInputParameters("ftype", "R"));
                //inputParaList1.Add(new StoredProcedureInputParameters("pType", MOF));
                //dal.ExecuteSotredProcedure("LPHS.MATURITY_CLEAR_NEW", inputParaList1);
                //inputParaList1.Clear();

                //List<StoredProcedureInputParameters> inputParaList1 = new List<StoredProcedureInputParameters>();
                //inputParaList1.Add(new StoredProcedureInputParameters("policyno", polno.ToString()));
                //inputParaList1.Add(new StoredProcedureInputParameters("sysid", "D"));
                //inputParaList1.Add(new StoredProcedureInputParameters("ftype", "R"));
                ////inputParaList1.Add(new StoredProcedureInputParameters("pType", MOF));
                //dal.ExecuteSotredProcedure("LPHS.MATURITY_CLEAR", inputParaList1);
                //inputParaList1.Clear();
                #endregion

                #region//**************** Committing Now **********************************************
                dal.CommitTransaction();
                dal.CloseDBConnection();
                this.lblsucess.Visible = true;
                this.btnRev.Enabled = false;
                #endregion
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction();
                dal.CloseDBConnection();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }

    protected string mof(string character)
    {
        string mofeka = "";
        if (character.Equals("M")) mofeka = "Main Life";

        else if (character.Equals("S")) mofeka = "Spouce";
        else mofeka = "Second Life";
        return mofeka;
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
    protected string polstate(string state)
    {
        string thestate = "";
        if (state.Equals("L"))
        {
            thestate = "Lapsed";
        }
        else
        {
            thestate = "Inforced";
        }
        return thestate;
    }

   

}
