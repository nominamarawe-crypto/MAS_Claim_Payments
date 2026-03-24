using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Actuarial002 : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    DataManager dthintobj;
    private string EPF = "";
    private string PolNo = "";
    private string ClaimNo = "";
    private string ReInsAvailability = "";


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
    private string Intdate;
    private double sumassured;
    private int table;
    private int term;
    private int dateofComm;
    private string COD;
    private int MOD;
    private int DUE;
    private int PAC;
    private string causeOfDeath = "";
    private string ageAdmitYN = "";
    private double ageAdmitAmt = 0.0;
    private double ageEntryInter = 0.0;
    private string revivalsYN = "";
    private string assNomYN = "";
    private string reinsYN = "";
    private double surrrenderedbons;
    private int bonussurrYr;
    private string confst = "";
    private int payautDt;
    private string gender;
    private string dob;
    private string searchby;

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
        bool checkAuth = true;
        
        if (!Page.IsPostBack)
        {
            if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
            {
                searchby = Convert.ToString(((DropDownList)PreviousPage.FindControl("searchBy")).SelectedValue);
                if (searchby == "P")
                {
                    PolNo = Convert.ToString(((TextBox)PreviousPage.FindControl("txtpolno")).Text);
                    ClaimNo = Convert.ToString(((DropDownList)PreviousPage.FindControl("drClaimList")).SelectedValue);
                }
                else
                {
                    PolNo = Convert.ToString(((HiddenField)PreviousPage.FindControl("hdnPolno")).Value);
                    ClaimNo = Convert.ToString(((TextBox)PreviousPage.FindControl("txtClaimNo")).Text);
                }

                //ReInsAvailability = Convert.ToString(((DropDownList)PreviousPage.FindControl("ddlAvailbility")).SelectedValue);
                ViewState["PolNo"] = PolNo;
                ViewState["ClaimNo"] = ClaimNo;
                //ViewState["ReInsAvailability"] = ReInsAvailability;
                checkAuth = true;
            }
            else
            {
                PolNo = Request.QueryString["polno"];
                ClaimNo = Request.QueryString["clmno"];

                ViewState["PolNo"] = PolNo;
                ViewState["ClaimNo"] = ClaimNo;

                ddlAvailbility.Items[0].Text = "";
                ddlAvailbility.Enabled = false;
                txtRePerNO.Enabled = false;
                txtShrBasic.Enabled = false;
                txtShrBasicFac.Enabled = false;
                txtShrFPU.Enabled = false;
                txtShrFPU.Enabled = false;
                txtShrFPUFAC.Enabled = false;
                txtShrSJ.Enabled = false;
                txtShrSJFAC.Enabled = false;
                txtShrADB.Enabled = false;
                txtShrADBFAC.Enabled = false;
                txtShrSpouse.Enabled = false;
                txtShrSpouseFAC.Enabled = false;
                txtShrCIC.Enabled = false;
                txtShrCICFAC.Enabled = false;
                txtShrTPDA.Enabled = false;
                txtShrTPDAFAC.Enabled = false;
                txtShrTPDS.Enabled = false;
                txtShrTPDSFAC.Enabled = false;
                txtShrPPDB.Enabled = false;
                txtShrPPDBFAC.Enabled = false;
                txtshrwopa.Enabled = false;
                txtshrwopaFAC.Enabled = false;
                txtshrwops.Enabled = false;
                txtshrwopsFAC.Enabled = false;
                txtshrTot.Enabled = false;
                ddlInsure.Enabled = false;
                ddlfac.Enabled = false;
                btnregister.Visible = false;
                checkAuth = false;
            }
            try
            {
                #region -------------- Check Authority -----------------------
                if (checkAuth)
                {
                    objUserAuthentication = new User_Authentication();
                    if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC09"))
                    {
                        throw new Exception("You have no Authority for this option");
                    }
                }
               

                #endregion


            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }

            

            dthintobj = new DataManager();
            using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
            {
                try
                {

                    #region  ------------- DTHINT - Read Death intimation details ----------------
                    string dthintSelect = @"select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4,
                            ditel, dinforel, dclm, dsta, dconfst, dcof,to_char(DENTDATE,'yyyyMMdd'),DMOS from lphs.dthint where dpolno=" + PolNo + " and dclm='" + ClaimNo + "'  ";
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
                                    infodat = Convert.ToInt32(dthintREADER[0]); // informed Date                          

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
                                    if (!dthintREADER.IsDBNull(17)) { Intdate = dthintREADER.GetString(17); } 
                                    if(!dthintREADER.IsDBNull(18)) { MOF = dthintREADER.GetString(18); }
                                }
                            }
                        }
                    }

                    

                    #endregion

                    #region--------------------------- Policy History ----------------------------------------------------------
                    string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue, pmmod, PMCOD, PMPAC from lphs.premast where pmpol=" + PolNo + " ";
                    string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, lpmod, LPCOD, LPPAC from lphs.liflaps where lppol=" + PolNo + " ";
                    string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phmod , PHCOD, PHPAC, phsta from lphs.lpolhis where phpol=" + PolNo + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                    string query = "";
                    if (dal.IsRecordExist(premastSelect))
                    { query = premastSelect; }
                    else if (dal.IsRecordExist(liflapsSelect))
                    { query = liflapsSelect; }
                    else if (dal.IsRecordExist(polhisSelect))
                    { query = polhisSelect; }
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

                    #region--------------------------- DTHREF -------------------------------------------------------------
                    string payee = "";
                    string dthrefSel = "select DRAGEADMIT, DRRINSYN, DRREVIVALS, DRASSIGNEENOM, PAYEE, PAYAUTDT, DRBONSURRAMT, DRBONSURRYR,AGE_AMT,AGEDIFINRST,DRCLMNO,CAUSEOFDEATHSTR from LPHS.DTHREF  where drpolno=" + PolNo + " and drmos='" + MOF + "' ";
                    if (dal.IsRecordExist(dthrefSel))
                    {
                       
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrefSel))
                        {
                            using (DataTableReader dthrefreader = dataTable.CreateDataReader())
                            {
                                while (dthrefreader.Read())
                                {
                                    if (ageAdmitYN == "" || ageAdmitYN == null)
                                    {
                                        if (!dthrefreader.IsDBNull(0)) { ageAdmitYN = dthrefreader.GetString(0); } else { ageAdmitYN = ""; }
                                    }

                                    if (!dthrefreader.IsDBNull(2)) { revivalsYN = dthrefreader.GetString(2); } else { revivalsYN = ""; }
                                    if (!dthrefreader.IsDBNull(3)) { assNomYN = dthrefreader.GetString(3); } else { assNomYN = ""; }
                                    if (!dthrefreader.IsDBNull(4)) { payee = dthrefreader.GetString(4); } else { payee = ""; }
                                    if (!dthrefreader.IsDBNull(5)) { payautDt = Convert.ToInt32(dthrefreader[5]); } else { payautDt = 0; }
                                    if (!dthrefreader.IsDBNull(6)) { surrrenderedbons = Convert.ToDouble(dthrefreader[6]); } else { surrrenderedbons = 0; }
                                    if (!dthrefreader.IsDBNull(7)) { bonussurrYr = Convert.ToInt32(dthrefreader[7]); } else { bonussurrYr = 0; }
                                    if (!dthrefreader.IsDBNull(8)) { ageAdmitAmt = Convert.ToDouble(dthrefreader[8]); } else { ageAdmitAmt = 0; }
                                    if (!dthrefreader.IsDBNull(9)) { ageEntryInter = Convert.ToDouble(dthrefreader[9]); } else { ageEntryInter = 0; }
                                    if (!dthrefreader.IsDBNull(11)) { causeOfDeath = dthrefreader.GetString(11); } else { causeOfDeath = "-"; }

                                }
                            }
                        }
                    }

                    #endregion

                    

                    #region personal detail
                    string liftyp = "";
                    string gender = "";
                    string dob = "";
                    string polpersubsql = "";
                    string status = polstat == "I" ? "Inforce" : "Lapse";
                    switch (MOF)
                    {
                        case "M":
                            liftyp = "Main Life";
                            polpersubsql = "where polno='" + PolNo + "' and prpertype='1'";
                            break;
                        case "S":
                            polpersubsql = "where polno='" + PolNo + "' and prpertype='2'";
                            liftyp = "Spouse";
                            break;
                        case "2":
                            polpersubsql = "where polno='" + PolNo + "' and prpertype='3'";
                            liftyp = "Second Life";
                            break;
                        case "C":
                            polpersubsql = "where polno='" + PolNo + "' and prpertype in ('4','5','6',7','8')";
                            liftyp = "Child";
                            break;
                        default:
                            polpersubsql = "where polno='" + PolNo + "' and prpertype='1'";
                            liftyp = "Main Life";
                            break;
                    }
                    string sqlpersonal = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL " + polpersubsql;

                    if (dthintobj.existRecored(sqlpersonal) != 0)
                    {
                        dthintobj.readSql(sqlpersonal);
                        OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (persreader.Read())
                        {
                            if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
                            if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
                        }
                        persreader.Close();
                        persreader.Dispose();
                    }
                    else
                    {
                        string sqlpersonalhis = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL_HISTORY " + polpersubsql;
                        dthintobj.readSql(sqlpersonalhis);
                        OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (persreader.Read())
                        {
                            if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
                            if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
                        }
                        persreader.Close();
                        persreader.Dispose();
                    }
                    #endregion

                    #region personal detail
                    string emailsentby = "";
                    string senttime = "";
                    
                    
                    string emaillog = "select SENT_BY,to_char(SENT_DATE,'yyyy/MM/dd hh:mi:ss am') from LPHS.DTH_REINS_EMAIL_LOG where CLAIMNO='"+ClaimNo+"'";

                    if (dthintobj.existRecored(emaillog) != 0)
                    {
                        dthintobj.readSql(emaillog);
                        OracleDataReader emailreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (emailreader.Read())
                        {
                            if (!emailreader.IsDBNull(0)) { emailsentby = emailreader.GetString(0); }
                            if (!emailreader.IsDBNull(1)) { senttime = emailreader.GetString(1); }
                        }
                        emailreader.Close();
                        emailreader.Dispose();
                    }
                    else
                    {
                        string sqlpersonalhis = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL_HISTORY " + polpersubsql;
                        dthintobj.readSql(sqlpersonalhis);
                        OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (persreader.Read())
                        {
                            if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
                            if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
                        }
                        persreader.Close();
                        persreader.Dispose();
                    }
                    #endregion

                    #region ----- view state --------
                    //ViewState["PolNo"] = PolNo;
                    //ViewState["ClaimNo"] = ClaimNo;
                    //ViewState["ReInsAvailability"] = ReInsAvailability;
                    #endregion

                    #region Set Values to Display
                    lblClmNo.Text = ClaimNo;
                    lblpolno.Text = PolNo;
                    lblPlanNo.Text = table.ToString();
                    lblDOC.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);
                    lblName.Text = nameOfDead;
                    lblGender.Text = gender;
                    lblDOB.Text = dob;
                    lblPolstatus.Text = status;
                    lifType.Text = liftyp;
                    lblDOD.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                    lblCauseofDeath.Text = causeOfDeath;

                    lblEmailSentBy.Text = emailsentby;
                    lblEmailSentAt.Text = senttime;
                    #endregion

                    #region Cover Grid
                    Covers covers = new Covers();
                    List<Covers> coverlist = new List<Covers>();
                    coverlist = covers.GetolicyCovers(PolNo.ToString(), dthintobj);

                    coverGrid.DataSource = coverlist;
                    coverGrid.DataBind();
                    #endregion

                    #region ReInsure Details
                    string reinsuredetails = "select POLNO,CLAIMNO,AVAILABILITY,PERSON_NO,RE_INS_BASIC,RE_INS_FPU,RE_INS_SJ,RE_INS_ADB,RE_INS_SPOUSE,RE_INS_CI,RE_INS_TPD_A," +
                        "RE_INS_TPD_S,RE_INS_PPDB,RE_INS_WOP_A,RE_INS_WOP_S,RE_INT_TOT,RE_INSURER,RE_TYPE,RE_INS_BASIC_FAC,RE_INS_FPU_FAC,RE_INS_SJ_FAC,RE_INS_ADB_FAC,RE_INS_SPOUSE_FAC," +
                        "RE_INS_CI_FAC,RE_INS_TPD_A_FAC,RE_INS_TPD_S_FAC,RE_INS_PPDB_FAC,RE_INS_WOP_A_FAC,RE_INS_WOP_S_FAC,ENTRY_DATE,ENTRED_BY,RE_INS_STATUS,PAYMENT_DETAIL_SENT,PAYMENT_DETAIL_SENT_DATE " +
                        "FROM LPHS.DTH_REINSURANCE_DTL where CLAIMNO='"+ClaimNo+"'";
                    dthintobj.readSql(reinsuredetails);
                    OracleDataReader insreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (insreader.Read())
                    {
                        if (!insreader.IsDBNull(2))
                        {
                            ddlAvailbility.SelectedValue = insreader.GetString(2);
                        }
                        if (!insreader.IsDBNull(3))
                        {
                            txtRePerNO.Text = insreader.GetInt32(3).ToString();
                        }
                        if (!insreader.IsDBNull(4))
                        {
                            txtShrBasic.Text = insreader.GetDouble(4).ToString();
                        }
                        if (!insreader.IsDBNull(5))
                        {
                            txtShrFPU.Text = insreader.GetDouble(5).ToString();
                        }
                        if (!insreader.IsDBNull(6))
                        {
                            txtShrSJ.Text = insreader.GetDouble(6).ToString();
                        }
                        if (!insreader.IsDBNull(7))
                        {
                            txtShrADB.Text = insreader.GetDouble(7).ToString();
                        }
                        if (!insreader.IsDBNull(8))
                        {
                            txtShrSpouse.Text = insreader.GetDouble(8).ToString();
                        }
                        if (!insreader.IsDBNull(9))
                        {
                            txtShrCIC.Text = insreader.GetDouble(9).ToString();
                        }
                        if (!insreader.IsDBNull(10))
                        {
                            txtShrTPDA.Text = insreader.GetDouble(10).ToString();
                        }
                        if (!insreader.IsDBNull(11))
                        {
                            txtShrTPDS.Text = insreader.GetDouble(11).ToString();
                        }
                        if (!insreader.IsDBNull(12))
                        {
                            txtShrPPDB.Text = insreader.GetDouble(12).ToString();
                        }
                        if (!insreader.IsDBNull(13))
                        {
                            txtshrwopa.Text = insreader.GetDouble(13).ToString();
                        }
                        if (!insreader.IsDBNull(14))
                        {
                            txtshrwops.Text = insreader.GetDouble(14).ToString();
                        }
                        if (!insreader.IsDBNull(15))
                        {
                            txtshrTot.Text = insreader.GetDouble(15).ToString();
                        }
                        if (!insreader.IsDBNull(16))
                        {
                            ddlInsure.SelectedValue = insreader.GetString(16).ToString();
                        }
                        if (!insreader.IsDBNull(17))
                        {
                            ddlfac.Text = insreader.GetString(17).ToString();
                        }

                        if (!insreader.IsDBNull(18))
                        {
                            txtShrBasicFac.Text = insreader.GetDouble(18).ToString();
                        }
                        if (!insreader.IsDBNull(19))
                        {
                            txtShrFPUFAC.Text = insreader.GetDouble(19).ToString();
                        }
                        if (!insreader.IsDBNull(20))
                        {
                            txtShrSJFAC.Text = insreader.GetDouble(20).ToString();
                        }
                        if (!insreader.IsDBNull(21))
                        {
                            txtShrADBFAC.Text = insreader.GetDouble(21).ToString();
                        }
                        if (!insreader.IsDBNull(22))
                        {
                            txtShrSpouseFAC.Text = insreader.GetDouble(22).ToString();
                        }
                        if (!insreader.IsDBNull(23))
                        {
                            txtShrCICFAC.Text = insreader.GetDouble(23).ToString();
                        }
                        if (!insreader.IsDBNull(24))
                        {
                            txtShrTPDAFAC.Text = insreader.GetDouble(24).ToString();
                        }
                        if (!insreader.IsDBNull(25))
                        {
                            txtShrTPDSFAC.Text = insreader.GetDouble(25).ToString();
                        }
                        if (!insreader.IsDBNull(26))
                        {
                            txtShrPPDBFAC.Text = insreader.GetDouble(26).ToString();
                        }
                        if (!insreader.IsDBNull(27))
                        {
                            txtshrwopaFAC.Text = insreader.GetDouble(27).ToString();
                        }
                        if (!insreader.IsDBNull(28))
                        {
                            txtshrwopsFAC.Text = insreader.GetDouble(28).ToString();
                        }
                    }
                    insreader.Close();
                    insreader.Dispose();
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
            if (ViewState["PolNo"] != null) { PolNo = ViewState["PolNo"].ToString(); }
            if (ViewState["ClaimNo"] != null) { ClaimNo = ViewState["ClaimNo"].ToString(); }
            if (ViewState["ReInsAvailability"] != null) { ReInsAvailability = ViewState["ReInsAvailability"].ToString(); }

            #endregion
        }

    }

    protected void btnregister_Click(object sender, EventArgs e)
    {
        dthintobj = new DataManager();

        if(ddlAvailbility.SelectedValue == "Y" || ddlAvailbility.SelectedValue == "N")
        {
            using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
            {
                try
                {
                    dal.OpenTransaction();


                    string checkReinsurance = "select * from LPHS.DTH_REINSURANCE_DTL where POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNo + "' ";
                    if (dal.IsRecordExist(checkReinsurance))
                    {
                        string addtoHis = "INSERT INTO LPHS.DTH_REINSURANCE_DTL_HIS (POLNO,CLAIMNO,AVAILABILITY,PERSON_NO,RE_INS_BASIC,RE_INS_FPU," +
                                        "RE_INS_SJ,RE_INS_ADB,RE_INS_SPOUSE,RE_INS_CI,RE_INS_TPD_A,RE_INS_TPD_S,RE_INT_TOT,RE_INS_PPDB,RE_INS_WOP_A,RE_INS_WOP_S," +
                                        "RE_INS_BASIC_FAC,RE_INS_FPU_FAC,RE_INS_SJ_FAC,RE_INS_ADB_FAC,RE_INS_SPOUSE_FAC,RE_INS_CI_FAC,RE_INS_TPD_A_FAC,RE_INS_TPD_S_FAC," +
                                        "RE_INS_PPDB_FAC,RE_INS_WOP_A_FAC,RE_INS_WOP_S_FAC," +
                                        "RE_INSURER,RE_TYPE,ENTRY_DATE,ENTRED_BY,RE_INS_STATUS,PAYMENT_DETAIL_SENT,PAYMENT_DETAIL_SENT_DATE,EDITED_DATE,EDITED_BY)" +
                                    "select POLNO,CLAIMNO,AVAILABILITY,PERSON_NO,RE_INS_BASIC,RE_INS_FPU,RE_INS_SJ,RE_INS_ADB,RE_INS_SPOUSE,RE_INS_CI," +
                                    "RE_INS_TPD_A,RE_INS_TPD_S,RE_INT_TOT,RE_INS_PPDB,RE_INS_WOP_A,RE_INS_WOP_S,RE_INS_BASIC_FAC,RE_INS_FPU_FAC,RE_INS_SJ_FAC," +
                                    "RE_INS_ADB_FAC,RE_INS_SPOUSE_FAC,RE_INS_CI_FAC,RE_INS_TPD_A_FAC,RE_INS_TPD_S_FAC,RE_INS_PPDB_FAC,RE_INS_WOP_A_FAC,RE_INS_WOP_S_FAC," +
                                    "RE_INSURER,RE_TYPE,ENTRY_DATE,ENTRED_BY,RE_INS_STATUS," +
                                    "PAYMENT_DETAIL_SENT,PAYMENT_DETAIL_SENT_DATE,sysdate,'" + EPF + "' " +
                                    "FROM LPHS.DTH_REINSURANCE_DTL where POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNo + "' ";
                        dal.ExecuteTableUpdateQuery(addtoHis);

                        string deleteReinsurance = "DELETE FROM LPHS.DTH_REINSURANCE_DTL where POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNo + "' ";
                        dal.ExecuteTableUpdateQuery(deleteReinsurance);
                    }
                    #region Set Values
                    string clmno = lblClmNo.Text.Trim();
                    string polno = lblpolno.Text.Trim();
                    string availability = ddlAvailbility.SelectedValue.Trim();
                    string perno = txtRePerNO.Text.Trim();
                    string shrbasic = txtShrBasic.Text.Trim();
                    string shrfpu = txtShrFPU.Text.Trim();
                    string shrsj = txtShrSJ.Text.Trim();
                    string shradb = txtShrADB.Text.Trim();
                    string shrspouse = txtShrSpouse.Text.Trim();
                    string shrcic = txtShrCIC.Text.Trim();
                    string shrtpda = txtShrTPDA.Text.Trim();
                    string shrtpds = txtShrTPDS.Text.Trim();
                    string shrtot = txtshrTot.Text.Trim();
                    string shrppdb = txtShrPPDB.Text.Trim();
                    string shrwopa = txtshrwopa.Text.Trim();
                    string shrwops = txtshrwops.Text.Trim();
                    string reinsure = ddlInsure.SelectedValue.Trim();
                    string retyp = ddlfac.SelectedValue.Trim();
                    string status = "PENDING";
                    string shrbasicfac = txtShrBasicFac.Text.Trim();
                    string shrfpufac = txtShrFPUFAC.Text.Trim();
                    string shrsjfac = txtShrSJFAC.Text.Trim();
                    string shradbfac = txtShrADBFAC.Text.Trim();
                    string shrspousefac = txtShrSpouseFAC.Text.Trim();
                    string shrcicfac = txtShrCICFAC.Text.Trim();
                    string shrtpdafac = txtShrTPDAFAC.Text.Trim();
                    string shrtpdsfac = txtShrTPDSFAC.Text.Trim();
                    string shrppdbfac = txtShrPPDBFAC.Text.Trim();
                    string shrwopafac = txtshrwopaFAC.Text.Trim();
                    string shrwopsfac = txtshrwopsFAC.Text.Trim();
                    #endregion
                    string AddReInsurance = "INSERT INTO LPHS.DTH_REINSURANCE_DTL (POLNO,CLAIMNO,AVAILABILITY,PERSON_NO,RE_INS_BASIC,RE_INS_FPU," +
                                        "RE_INS_SJ,RE_INS_ADB,RE_INS_SPOUSE,RE_INS_CI,RE_INS_TPD_A,RE_INS_TPD_S,RE_INS_PPDB,RE_INS_WOP_A,RE_INS_WOP_S,RE_INT_TOT,RE_INS_BASIC_FAC," +
                                        "RE_INS_FPU_FAC,RE_INS_SJ_FAC,RE_INS_ADB_FAC,RE_INS_SPOUSE_FAC,RE_INS_CI_FAC,RE_INS_TPD_A_FAC,RE_INS_TPD_S_FAC,RE_INS_PPDB_FAC,RE_INS_WOP_A_FAC,RE_INS_WOP_S_FAC," +
                                        "RE_INSURER,RE_TYPE,ENTRY_DATE,ENTRED_BY,RE_INS_STATUS) values ('" + polno + "','" + clmno + "','" + availability + "'," +
                                        "'" + perno + "','" + shrbasic + "','" + shrfpu + "','" + shrsj + "','" + shradb + "','" + shrspouse + "','" + shrcic + "'," +
                                        "'" + shrtpda + "','" + shrtpds + "','" + shrppdb + "','" + shrwopa + "','" + shrwops + "','" + shrtot + "','" + shrbasicfac + "','" + shrfpufac + "','" + shrsjfac + "'," +
                                        "'" + shradbfac + "','" + shrspousefac + "','" + shrcicfac + "'," +
                                        "'" + shrtpdafac + "','" + shrtpdsfac + "','" + shrppdbfac + "','" + shrwopafac + "','" + shrwopsfac + "','" + reinsure + "'," +
                                        "'" + retyp + "',sysdate,'" + EPF + "','" + status + "')";
                    dal.ExecuteTableUpdateQuery(AddReInsurance);


                    string updteReinsure = "update LPHS.dthref set DRRINSYN='" + availability + "' where DRPOLNO='" + polno + "' and DRCLMNO='" + clmno + "'";
                    dal.ExecuteTableUpdateQuery(updteReinsure);

                    lblsucess.Visible = true;
                    dal.CommitTransaction();
                    dal.CloseDBConnection();



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

        
    }

    





    protected void coverGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void txtShrBasic_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrFPU_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrSJ_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrADB_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrSpouse_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrCIC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrTPDA_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrTPDS_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrPPDB_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtshrwops_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    public void setTotal()
    {
        double total = 0;
        
        double amountBasic = 0;
        if (!string.IsNullOrEmpty(txtShrBasic.Text.Trim()))
        {
            amountBasic = Double.Parse(txtShrBasic.Text.Trim());
        }

        double amountFPU = 0;
        if (!string.IsNullOrEmpty(txtShrFPU.Text.Trim()))
        {
            amountFPU = Double.Parse(txtShrFPU.Text.Trim());
        }

        double amountSJ = 0;
        if (!string.IsNullOrEmpty(txtShrSJ.Text.Trim()))
        {
            amountSJ = Double.Parse(txtShrSJ.Text.Trim());
        }

        double amountADB = 0;
        if (!string.IsNullOrEmpty(txtShrADB.Text.Trim()))
        {
            amountADB = Double.Parse(txtShrADB.Text.Trim());
        }

        double amountSpouse = 0;
        if (!string.IsNullOrEmpty(txtShrSpouse.Text.Trim()))
        {
            amountSpouse = Double.Parse(txtShrSpouse.Text.Trim());
        }

        double amountCIC = 0;
        if (!string.IsNullOrEmpty(txtShrCIC.Text.Trim()))
        {
            amountCIC = Double.Parse(txtShrCIC.Text.Trim());
        }

        double amountTPDA = 0;
        if (!string.IsNullOrEmpty(txtShrTPDA.Text.Trim()))
        {
            amountTPDA = Double.Parse(txtShrTPDA.Text.Trim());
        }

        double amountTPDS = 0;
        if (!string.IsNullOrEmpty(txtShrTPDS.Text.Trim()))
        {
            amountTPDS = Double.Parse(txtShrTPDS.Text.Trim());
        }

        double amountPPDB = 0;
        if (!string.IsNullOrEmpty(txtShrPPDB.Text.Trim()))
        {
            amountPPDB = Double.Parse(txtShrPPDB.Text.Trim());
        }

        double amountwops = 0;
        if (!string.IsNullOrEmpty(txtshrwops.Text.Trim()))
        {
            amountwops = Double.Parse(txtshrwops.Text.Trim());
        }

        double amountwopa = 0;
        if (!string.IsNullOrEmpty(txtshrwopa.Text.Trim()))
        {
            amountwopa = Double.Parse(txtshrwopa.Text.Trim());
        }

        double amountBasicFAC = 0;
        if (!string.IsNullOrEmpty(txtShrBasicFac.Text.Trim()))
        {
            amountBasicFAC = Double.Parse(txtShrBasicFac.Text.Trim());
        }

        double amountFPUFAC = 0;
        if (!string.IsNullOrEmpty(txtShrFPUFAC.Text.Trim()))
        {
            amountFPUFAC = Double.Parse(txtShrFPUFAC.Text.Trim());
        }

        double amountSJFAC = 0;
        if (!string.IsNullOrEmpty(txtShrSJFAC.Text.Trim()))
        {
            amountSJFAC = Double.Parse(txtShrSJFAC.Text.Trim());
        }

        double amountADBFAC = 0;
        if (!string.IsNullOrEmpty(txtShrADBFAC.Text.Trim()))
        {
            amountADBFAC = Double.Parse(txtShrADBFAC.Text.Trim());
        }

        double amountSpouseFAC = 0;
        if (!string.IsNullOrEmpty(txtShrSpouseFAC.Text.Trim()))
        {
            amountSpouseFAC = Double.Parse(txtShrSpouseFAC.Text.Trim());
        }

        double amountCICFAC = 0;
        if (!string.IsNullOrEmpty(txtShrCICFAC.Text.Trim()))
        {
            amountCIC = Double.Parse(txtShrCICFAC.Text.Trim());
        }

        double amountTPDAFAC = 0;
        if (!string.IsNullOrEmpty(txtShrTPDAFAC.Text.Trim()))
        {
            amountTPDAFAC = Double.Parse(txtShrTPDAFAC.Text.Trim());
        }

        double amountTPDSFAC = 0;
        if (!string.IsNullOrEmpty(txtShrTPDSFAC.Text.Trim()))
        {
            amountTPDSFAC = Double.Parse(txtShrTPDSFAC.Text.Trim());
        }

        double amountPPDBFAC = 0;
        if (!string.IsNullOrEmpty(txtShrPPDBFAC.Text.Trim()))
        {
            amountPPDBFAC = Double.Parse(txtShrPPDBFAC.Text.Trim());
        }

        double amountwopsFAC = 0;
        if (!string.IsNullOrEmpty(txtshrwopsFAC.Text.Trim()))
        {
            amountwopsFAC = Double.Parse(txtshrwopsFAC.Text.Trim());
        }

        double amountwopaFAC = 0;
        if (!string.IsNullOrEmpty(txtshrwopaFAC.Text.Trim()))
        {
            amountwopaFAC = Double.Parse(txtshrwopaFAC.Text.Trim());
        }

        total = amountBasic + amountFPU + amountSJ + amountADB + amountSpouse + amountCIC + amountTPDA + amountTPDS + amountPPDB + amountwops + amountwopa + amountBasicFAC + amountFPUFAC + amountSJFAC + amountADBFAC + amountSpouseFAC + amountCICFAC + amountTPDAFAC + amountTPDSFAC + amountPPDBFAC + amountwopsFAC + amountwopaFAC;
        txtshrTot.Text = total.ToString();
    }

    protected void txtshrwopa_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrBasicFac_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrFPUFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrSJFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrADBFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrSpouseFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrCICFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrTPDAFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrTPDSFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtShrPPDBFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtshrwopaFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }

    protected void txtshrwopsFAC_TextChanged(object sender, EventArgs e)
    {
        setTotal();
    }
}
