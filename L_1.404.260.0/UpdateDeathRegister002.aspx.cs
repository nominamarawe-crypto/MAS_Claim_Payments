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
using System.Globalization;

public partial class UpdateDeathRegister002 : System.Web.UI.Page
{
    private int polNo = 0;
    private int claimNo = 0;
    private int table = 0;
    private int trm = 0;
    private int dateofComm = 0;
    private int due = 0;
    private int intiDate = 0;
    private int paidNo = 0;
    private int adminNo = 0;
    private int confDate = 0;
    private int repDate = 0;
    private int paidDate = 0;
    private int dateOfDth = 0;
    private int accountCode = 0;
    private int causeOfDthId = 0;
    private int payMod = 0;

    private string mos = "";
    private string epf = "";
    private string phname = "";
    private string ad1 = "";
    private string ad2 = "";
    private string ad3 = "";
    private string ad4 = "";
    private string repReason = "";
    private string dcof = "";
    private string polComplted = "";
    private string isExgracia = "";
    private string status = "";
    private string causeOfDthString = "";

    private double sumassured = 0.0;
    private double grossClm = 0.0;
    private double netClm = 0.0;
    private double adb = 0.0;
    private double fpu = 0.0;
    private double sj = 0.0;
    private double fe = 0.0;
    private double vestedBon = 0.0;
    private double interimBon = 0.0;
    private double deposit = 0.0;
    private double defaultPre = 0.0;
    private double defaultInt = 0.0;
    private double loanCap = 0.0;
    private double loanInt = 0.0;
    private double otherDeduc = 0.0;
    private double sumOnex = 0.0;

    private DateTime PaidDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            Response.Redirect("SessionError.aspx");
        }

        if (PreviousPage != null)
        {
            polNo = this.PreviousPage.PolNo;
            mos = this.PreviousPage.MOS;
            claimNo = this.PreviousPage.ClaimNo;
        }

        if (!Page.IsPostBack)
        {
            using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
            {
                try
                {
                    this.lblpolno.Text = polNo.ToString();
                    this.lblmof.Text = LIFEtype(mos);
                    this.lblClaimNo.Text = claimNo.ToString();

                    #region ----------- Repudation --------------------------------------
                    string repSel = @"select repu_reason, repu_date from lphs.dth_repudiation 
                                    where policyno=" + polNo + " and life_type='" + mos + "' and repuok='OK'";

                    if (dal.IsRecordExist(repSel))
                    {
                        rblIsRep.SelectedValue = "Y";
                    }

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(repSel))
                    {
                        using (DataTableReader repReader = dataTable.CreateDataReader())
                        {
                            while (repReader.Read())
                            {
                                if (!repReader.IsDBNull(0)) { repReason = repReader.GetString(0); } else { repReason = ""; }
                                if (!repReader.IsDBNull(0)) { repDate = Convert.ToInt32(repReader[1]); } else { repDate = 0; }
                            }
                        }
                    }

                    this.txtRepReason.Text = repReason.ToString();
                    this.txtRepDate.Text = repDate.ToString();

                    #endregion

                    #region------------- DTHINT - Read Death intimation details ----------------
                    //string dthintSelect = @"select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4,
                           // ditel, dinforel, dclm, dsta, dconfst, dcof,to_char(DENTDATE,'yyyyMMdd') from lphs.dthint where dpolno=" + polNo + " and dmos='" + mos + "'  ";
                    string dthintSelect = @"select to_char(DENTDATE,'yyyyMMdd'), dconfdat, ddtofdth, dcof from lphs.dthint
                                          where dpolno=" + polNo + " and dmos='" + mos + "'  ";
                    //if (!dal.IsRecordExist(dthintSelect))
                    //{
                    //    throw new Exception("No Death Intimation Details!");
                    //}
                    //else
                    //{
                    if (dal.IsRecordExist(dthintSelect))
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthintSelect))
                        {
                            using (DataTableReader dthintREADER = dataTable.CreateDataReader())
                            {
                                while (dthintREADER.Read())
                                {
                                    if (!dthintREADER.IsDBNull(0)) { intiDate = Convert.ToInt32(dthintREADER[0]); } else { intiDate = 0; }
                                    if (!dthintREADER.IsDBNull(1)) { confDate = Convert.ToInt32(dthintREADER[1]); } else { confDate = 0; }
                                    if (!dthintREADER.IsDBNull(2)) { dateOfDth = Convert.ToInt32(dthintREADER[2]); } else { dateOfDth = 0; }
                                    if (!dthintREADER.IsDBNull(3)) { dcof = dthintREADER.GetString(3); } else { dcof = ""; }                                    
                                }
                            }
                        }
                    }

                    if (confDate == 0)
                    {
                        this.txtIntiDate.Text = intiDate.ToString();
                        this.txtIntiDate.Enabled = true;
                    }
                    else
                    {
                        this.txtIntiDate.Text = intiDate.ToString();
                        this.txtIntiDate.Enabled = false;
                    }

                    if (confDate == 0)
                    {
                        this.txtConfDate.Text = confDate.ToString();
                        this.txtConfDate.Enabled = true;
                    }
                    else
                    {
                        this.txtConfDate.Text = confDate.ToString();
                        this.txtConfDate.Enabled = false;
                    }

                    if (dateOfDth == 0)
                    {
                        this.txtDtOfDth.Text = dateOfDth.ToString();
                        this.txtDtOfDth.Enabled = true;
                    }
                    else
                    {
                        this.txtDtOfDth.Text = dateOfDth.ToString();
                        this.txtDtOfDth.Enabled = false;
                    }

                    this.ddlcof.SelectedValue = dcof;
                    this.ddlcof.Enabled = false;
                    
                    #endregion

                    #region--------------------------- DTHREF Details -------------------------------------------------------------

                    string dthrefSel = "select drgrossclm, drnetclm, draccbf, drfpu, drswarnajaya, drfuneralexp, drvestedbon," +
                                       " drinterimbon, drdeposits, drdefprem, drint, drloncap, drloanint, deotherdeduct, completed, " +
                                       " (select decode(nvl(LPHS.EXGRACIA_AMTS.DPOLNUM,0),0,'N','Y') from LPHS.EXGRACIA_AMTS where DPOLNUM=" + polNo + "), " +
                                       " (select  dsta from lphs.dthint where DPOLNO=" + polNo + "),DCAUSEOFDTH,CAUSEOFDEATHSTR" +
                                       " from lphs.dthref where drpolno=" + polNo + " and drclmno=" + claimNo + " and drmos='" + mos + "'";
                    if (dal.IsRecordExist(dthrefSel))
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrefSel))
                        {
                            using (DataTableReader dthrefreader = dataTable.CreateDataReader())
                            {
                                while (dthrefreader.Read())
                                {
                                    if (!dthrefreader.IsDBNull(0)) { grossClm = Convert.ToDouble(dthrefreader[0]); } else { grossClm = 0.0; }
                                    if (!dthrefreader.IsDBNull(1)) { netClm = Convert.ToDouble(dthrefreader[1]); } else { netClm = 0.0; }
                                    if (!dthrefreader.IsDBNull(2)) { adb = Convert.ToDouble(dthrefreader[2]); } else { adb = 0.0; }
                                    if (!dthrefreader.IsDBNull(3)) { fpu = Convert.ToDouble(dthrefreader[3]); } else { fpu = 0.0; }
                                    if (!dthrefreader.IsDBNull(4)) { sj = Convert.ToDouble(dthrefreader[4]); } else { sj = 0.0; }
                                    if (!dthrefreader.IsDBNull(5)) { fe = Convert.ToDouble(dthrefreader[5]); } else { fe = 0.0; }
                                    if (!dthrefreader.IsDBNull(6)) { vestedBon = Convert.ToDouble(dthrefreader[6]); } else { vestedBon = 0.0; }
                                    if (!dthrefreader.IsDBNull(7)) { interimBon = Convert.ToDouble(dthrefreader[7]); } else { interimBon = 0.0; }
                                    if (!dthrefreader.IsDBNull(8)) { deposit = Convert.ToDouble(dthrefreader[8]); } else { deposit = 0.0; }
                                    if (!dthrefreader.IsDBNull(9)) { defaultPre = Convert.ToDouble(dthrefreader[9]); } else { defaultPre = 0.0; }
                                    if (!dthrefreader.IsDBNull(10)) { defaultInt = Convert.ToDouble(dthrefreader[10]); } else { defaultInt = 0.0; }
                                    if (!dthrefreader.IsDBNull(11)) { loanCap = Convert.ToDouble(dthrefreader[11]); } else { loanCap = 0.0; }
                                    if (!dthrefreader.IsDBNull(12)) { loanInt = Convert.ToDouble(dthrefreader[12]); } else { loanInt = 0.0; }
                                    if (!dthrefreader.IsDBNull(13)) { otherDeduc = Convert.ToInt32(dthrefreader[13]); } else { otherDeduc = 0; }
                                    if (!dthrefreader.IsDBNull(14)) { polComplted = dthrefreader.GetString(14); } else { polComplted = ""; }
                                    if (!dthrefreader.IsDBNull(15)) { isExgracia = dthrefreader.GetString(15); } else { isExgracia = ""; }
                                    if (!dthrefreader.IsDBNull(16)) { status = dthrefreader.GetString(16); } else { status = ""; }
                                    if (!dthrefreader.IsDBNull(17)) { causeOfDthId = Convert.ToInt32(dthrefreader[17]); } else { causeOfDthId = 0; }
                                    if (!dthrefreader.IsDBNull(18)) { causeOfDthString = dthrefreader.GetString(18); } else { causeOfDthString = ""; }
                                }
                            }
                        }
                    }

                    #region ------------ Exgracia Details ------------------------

                    if (isExgracia == "Y")
                    {
                        string exgSelect = "select sumonex, adbonex, fpuonex, feonex, sjonex from lphs.exgracia_amts where dpolnum=" + polNo + " and mof='" + mos + "'";

                        if (dal.IsRecordExist(exgSelect))
                        {
                            using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrefSel))
                            {
                                using (DataTableReader dthExgreader = dataTable.CreateDataReader())
                                {
                                    while (dthExgreader.Read())
                                    {
                                        //if (!dthExgreader.IsDBNull(1)) { sumOnex = Convert.ToDouble(dthExgreader[1]); } else { sumOnex = 0.0; }
                                        if (!dthExgreader.IsDBNull(2)) { adb = Convert.ToDouble(dthExgreader[2]); } else { adb = 0.0; }
                                        if (!dthExgreader.IsDBNull(3)) { fpu = Convert.ToDouble(dthExgreader[3]); } else { fpu = 0.0; }
                                        if (!dthExgreader.IsDBNull(4)) { fe = Convert.ToDouble(dthExgreader[4]); } else { fe = 0.0; }
                                        if (!dthExgreader.IsDBNull(5)) { sj = Convert.ToDouble(dthExgreader[5]); } else { sj = 0.0; }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    this.txtGrossClaim.Text = String.Format("{0:N}", grossClm);
                    this.txtNetClaim.Text = String.Format("{0:N}", netClm);
                    //this.txtSumAssuredOnEx.Text = String.Format("{0:N}", sumOnex);
                    this.txtADB.Text = String.Format("{0:N}", adb);
                    this.txtFPU.Text = String.Format("{0:N}", fpu);
                    this.txtSJ.Text = String.Format("{0:N}", sj);
                    this.txtFE.Text = String.Format("{0:N}", fe);
                    this.txtVestedBon.Text = String.Format("{0:N}", vestedBon);
                    this.txtIntiBon.Text = String.Format("{0:N}", interimBon);
                    this.txtDeposit.Text = String.Format("{0:N}", deposit);
                    this.txtDefPre.Text = String.Format("{0:N}", defaultPre);
                    this.txtDefInt.Text = String.Format("{0:N}", defaultInt);
                    this.txtLoanCap.Text = String.Format("{0:N}", loanCap);
                    this.txtLoanInt.Text = String.Format("{0:N}", loanInt);
                    this.txtOthDeduc.Text = String.Format("{0:N}", otherDeduc);
                    this.ddlPolComplete.SelectedValue = polComplted;
                    this.ddlIsExgracia.SelectedValue = isExgracia;
                    this.ddlPolStatus.SelectedValue = status;

                    if (causeOfDthId != 0)
                    {
                        this.ddlDeathCause.SelectedValue = causeOfDthId.ToString();
                    }
                    
                    #endregion                    

                    #region ------------ PHNAME - REad policy Holreds name and address ---------
                    string phname1 = "", phname2 = "", phname3 = "";
                    string sql = @"select  pnsta, pnint, PNSUR, pnad1, pnad2, pnad3, pnad4  from LPHS.PHNAME 
                                 where pnpol='" + polNo + "'";

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

                    #region--------------------------- Policy History ----------------------------------------------------------
                    string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue, PMMOD, PMPRM, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR from lphs.premast where pmpol=" + polNo + " ";
                    string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, LPMOD, LPPRM, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR from lphs.liflaps where lppol=" + polNo + " ";
                    string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, PHMOD, PHPRM, PHPAC, PHAGT, PHORG, PHBRN,PHOBR, PHPTR from lphs.lpolhis where phpol=" + polNo + " and phtyp = 'D' and phmos = '" + mos + "' ";
                    string exSerenSelect = "select EXTSUM,EXTTBL,EXTTRM,EXTCOM,EXTNXT,EXTMD,EXTPRM,EXTPA,EXTAGT,EXTORG,EXTBR from lphs.EXSURREN where EXTPOL=" + polNo + " ";

                    string query = "";
                    if (dal.IsRecordExist(premastSelect))
                    { query = premastSelect; }
                    else if (dal.IsRecordExist(liflapsSelect))
                    { query = liflapsSelect; }
                    else if (dal.IsRecordExist(polhisSelect))
                    { query = polhisSelect; }
                    else if (dal.IsRecordExist(exSerenSelect))
                    { query = exSerenSelect; }
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
                                if (!premReader.IsDBNull(2)) { trm = Convert.ToInt32(premReader[2]); } else { trm = 0; }
                                if (!premReader.IsDBNull(3)) { dateofComm = Convert.ToInt32(premReader[3]); } else { dateofComm = 0; }
                                if (!premReader.IsDBNull(4)) { due = Convert.ToInt32(premReader[4]); } else { due = 0; }
                                if (!premReader.IsDBNull(5)) { payMod = Convert.ToInt32(premReader[5]); } else { payMod = 0; }
                            }
                        }
                    }

                    this.lblsumassured.Text = "Rs." + String.Format("{0:N}", sumassured);
                    this.lbltab.Text = table.ToString();
                    this.lblterm.Text = trm.ToString();
                    this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);
                    this.lbldtofexit.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);
                    #endregion

                    #region ----------- Paid No & Amin No -------------------------------

                    string dthSysNoSel = @"select admit_no, paid_no from lphs.death_sys_no 
                                         where policy_no=" + polNo + "and claim_no=" + claimNo + " and p_type='" + mos + "'";

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(dthSysNoSel))
                    {
                        using (DataTableReader dtReader = dataTable.CreateDataReader())
                        {
                            while (dtReader.Read())
                            {
                                if (!dtReader.IsDBNull(0)) { adminNo = Convert.ToInt32(dtReader[0]); } else { adminNo = 0; }
                                if (!dtReader.IsDBNull(1)) { paidNo = Convert.ToInt32(dtReader[1]); } else { paidNo = 0; }
                            }
                        }
                    }

                    this.txtAdminNo.Text = adminNo.ToString();
                    this.txtPaidNo.Text = paidNo.ToString();
                    #endregion

                    #region --------------- Paid Date ---------------------------

                    string cashbookSel = @"select min(to_char(chqdate,'yyyyMMdd')) from cashbook.temp_cb 
                                         where polno='" + polNo + "' and claimno='" + claimNo + "' and class='L' and divcode='L' AND VOUTYP='Death' and status='Paid'";

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(cashbookSel))
                    {
                        using (DataTableReader cashbookReader = dataTable.CreateDataReader())
                        {
                            while (cashbookReader.Read())
                            {
                                if (!cashbookReader.IsDBNull(0)) { paidDate = Convert.ToInt32(cashbookReader[0]); } else { paidDate = 0; }
                            }
                        }
                    }

                    this.txtPaidDate.Text = paidDate.ToString();
                    #endregion

                    #region ------------- View State --------------------

                    ViewState["polNo"] = polNo;
                    ViewState["mos"] = mos;
                    ViewState["claimNo"] = claimNo;

                    ViewState["sumassured"] = sumassured;

                    ViewState["repReason"] = repReason;
                    ViewState["repDate"] = repDate;

                    ViewState["intiDate"] = intiDate;
                    ViewState["confDate"] = confDate;
                    ViewState["dateOfDth"] = dateOfDth;
                    ViewState["dcof"] = dcof;

                    ViewState["grossClm"] = grossClm;
                    ViewState["netClm"] = netClm;
                    ViewState["adb"] = adb;
                    ViewState["sumOnex"] = sumOnex;
                    ViewState["fpu"] = fpu;
                    ViewState["sj"] = sj;
                    ViewState["fe"] = fe;
                    ViewState["vestedBon"] = vestedBon;
                    ViewState["interimBon"] = interimBon;
                    ViewState["deposit"] = deposit;
                    ViewState["defaultPre"] = defaultPre;
                    ViewState["defaultInt"] = defaultInt;
                    ViewState["loanCap"] = loanCap;
                    ViewState["loanInt"] = loanInt;
                    ViewState["otherDeduc"] = otherDeduc;
                    ViewState["polComplted"] = polComplted;
                    ViewState["isExgracia"] = isExgracia;
                    ViewState["status"] = status;
                    ViewState["paidNo"] = paidNo;
                    ViewState["adminNo"] = adminNo;
                    ViewState["paidDate"] = paidDate;
                    ViewState["table"] = table;
                    ViewState["trm"] = trm;
                    ViewState["dateofComm"] = dateofComm;
                    ViewState["due"] = due;
                    ViewState["payMod"] = payMod;
                    ViewState["phname"] = phname;

                    #endregion                    
                }
                catch (Exception ex)
                {
                    EPage.Messege = ex.ToString();
                    Response.Redirect("EPage.aspx");
                }
                finally
                { dal.CloseDBConnection(); }
            }
        }
        else
        {
            #region ------------- get Data from view State ------------------

            if (ViewState["polNo"] != null) { polNo = int.Parse(ViewState["polNo"].ToString()); }
            if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
            if (ViewState["claimNo"] != null) { claimNo = int.Parse(ViewState["claimNo"].ToString()); }
            if (ViewState["sumassured"] != null) { sumassured = double.Parse(ViewState["sumassured"].ToString()); }            
            if (ViewState["intiDate"] != null) { intiDate = int.Parse(ViewState["intiDate"].ToString()); }
            if (ViewState["table"] != null) { table = int.Parse(ViewState["table"].ToString()); }
            if (ViewState["trm"] != null) { trm = int.Parse(ViewState["trm"].ToString()); }
            if (ViewState["dateofComm"] != null) { dateofComm = int.Parse(ViewState["dateofComm"].ToString()); }
            if (ViewState["due"] != null) { due = int.Parse(ViewState["due"].ToString()); }
            if (ViewState["payMod"] != null) { payMod = int.Parse(ViewState["payMod"].ToString()); }
            if (ViewState["phname"] != null) { phname = ViewState["phname"].ToString(); }  

            #endregion
        }
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
        else if (mainorspouse.Equals("2"))
        {
            lifetype = "Second Life";
        }
        else { lifetype = "Child"; }
        return lifetype;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string ipADDR = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();

        using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
        {
            try
            {
                dal.OpenTransaction();

                dateOfDth = txtDtOfDth.Text != null ? int.Parse(txtDtOfDth.Text) : 0;
                intiDate = txtIntiDate.Text != null ? int.Parse(txtIntiDate.Text) : 0;
                confDate = txtConfDate.Text != null ? int.Parse(txtConfDate.Text) : 0; 
                dcof = ddlcof.SelectedValue;
                status = ddlPolStatus.SelectedValue;

                string dthintSelect = "select * from lphs.dthint where dpolno=" + polNo + " and dmos='" + mos + "'";
                if (!dal.IsRecordExist(dthintSelect))
                {
                    string dthIntInsert = @"insert into lphs.dthint (dpolno, dmos, dclm, dinfodat , ddtofdth, dconfdat, dcof, dnod, dsta)" +
                                           "values(" + polNo + ",'" + mos + "'," + claimNo + ", " + intiDate + ", " + dateOfDth + ", " + confDate + ",'" + dcof + "','" + phname + "','" + status + "')";
                    dal.ExecuteTableUpdateQuery(dthIntInsert);
                }
                else
                {
                    #region ------------ Update dthInt Table --------------

                    string dthIntUpdate = "update lphs.dthint set ddtofdth=" + dateOfDth + ", dcof='" + dcof + "', dsta=" + status + ", dconfdat=" + confDate + " where dpolno=" + polNo + " and dmos='" + mos + "'";
                    dal.ExecuteTableUpdateQuery(dthIntUpdate);
                }

                    #endregion

                #region -------- Update Repudation Tabel --------------

                if (rblIsRep.SelectedValue == "Y")
                {
                    repReason = txtRepReason.Text != null ? txtRepReason.Text : "";
                    repDate = txtRepDate.Text != null ? int.Parse(txtRepDate.Text) : 0;

                    string dthRepSelect = @"select * from lphs.dth_repudiation 
                                            where policyno=" + polNo + " and life_type='" + mos + "'";

                    if (dal.IsRecordExist(dthRepSelect))
                    {
                        string dthRepUpdate = @"update lphs.dth_repudiation set repu_reason='" + repReason + "', repu_date=" + repDate + " where policyno=" + polNo + " and life_type='" + mos + "'";
                        dal.ExecuteTableUpdateQuery(dthRepUpdate);
                    }
                    else
                    {
                        string SEQ = "";
                        string RorL = "R";
                        if (RorL.Equals("L") || RorL.Equals("R"))
                        {
                            string sql3 = "";
                            if (RorL.Equals("L"))
                            {
                                sql3 = "select LAPS_PREFIX || '/' || lpad((LAPS_SEQ + 1),6,'0') from LPHS.DTH_REPUDIATION_SEQ";
                            }
                            else if (RorL.Equals("R"))
                            {
                                sql3 = "select REPU_PREFIX || '/' || lpad((REPU_SEQ + 1),6,'0') from LPHS.DTH_REPUDIATION_SEQ";
                            }
                            if (dal.IsRecordExist(sql3))
                            {
                                using (DataTable dataTable = dal.ReadSQLtoDataTable(sql3))
                                {
                                    using (DataTableReader dtReader = dataTable.CreateDataReader())
                                    {
                                        while (dtReader.Read())
                                        {
                                            if (!dtReader.IsDBNull(0)) { SEQ = dtReader[0].ToString(); } else { SEQ = ""; }
                                        }
                                    }
                                }
                            }
                        }
                        string dthRepInsert = @"insert into lphs.dth_repudiation (REPU_SEQ,policyno, life_type, repu_reason, repu_date, entdate, entepf, repu_reason_sin, repuok)
                                                values('"+ SEQ + "'," + polNo + ", '" + mos + "','" + repReason + "', " + repDate + ", " + int.Parse(this.setDate()[0]) + ", '" + epf + "','','OK')";
                        dal.ExecuteTableUpdateQuery(dthRepInsert);

                        if (RorL.Equals("L") || RorL.Equals("R"))
                        {
                            string sql3 = "";
                            if (RorL.Equals("L"))
                            {
                                sql3 = "update LPHS.DTH_REPUDIATION_SEQ set LAPS_SEQ=LAPS_SEQ+1";
                            }
                            else if (RorL.Equals("R"))
                            {
                                sql3 = "update LPHS.DTH_REPUDIATION_SEQ set REPU_SEQ=REPU_SEQ+1";
                            }
                            dal.ExecuteTableUpdateQuery(sql3);
                        }
                    }
                }
                else if (rblIsRep.SelectedValue == "N")
                {
                    string dthRepSelect = @"select * from lphs.dth_repudiation 
                                            where policyno=" + polNo + " and life_type='" + mos + "'";

                    if (dal.IsRecordExist(dthRepSelect))
                    {
                        string dthRepUpdate = @"delete from lphs.dth_repudiation where policyno=" + polNo + " and life_type='" + mos + "'";
                        dal.ExecuteTableUpdateQuery(dthRepUpdate);
                    }
                }

                #endregion

                #region ------------ Update dthRef Table --------------

                grossClm = txtGrossClaim.Text != null ? double.Parse(txtGrossClaim.Text) : 0.0;
                netClm = txtNetClaim.Text != null ? double.Parse(txtNetClaim.Text) : 0.0;
                //sumOnex = txtSumAssuredOnEx.Text != null ? double.Parse(txtSumAssuredOnEx.Text) : 0.0;
                adb = txtADB.Text != null ? double.Parse(txtADB.Text) : 0.0;
                fpu = txtFPU.Text != null ? double.Parse(txtFPU.Text) : 0.0;
                sj = txtSJ.Text != null ? double.Parse(txtSJ.Text) : 0.0;
                fe = txtFE.Text != null ? double.Parse(txtFE.Text) : 0.0;
                vestedBon = txtVestedBon.Text != null ? double.Parse(txtVestedBon.Text) : 0.0;
                interimBon = txtIntiBon.Text != null ? double.Parse(txtIntiBon.Text) : 0.0;
                deposit = txtDeposit.Text != null ? double.Parse(txtDeposit.Text) : 0.0;
                defaultPre = txtDefPre.Text != null ? double.Parse(txtDefPre.Text) : 0.0;
                defaultInt = txtDefInt.Text != null ? double.Parse(txtDefInt.Text) : 0.0;
                loanCap = txtLoanCap.Text != null ? double.Parse(txtLoanCap.Text) : 0;
                loanInt = txtLoanInt.Text != null ? double.Parse(txtLoanInt.Text) : 0;
                otherDeduc = txtOthDeduc.Text != null ? double.Parse(txtOthDeduc.Text) : 0;
                polComplted = ddlPolComplete.SelectedValue;
                causeOfDthId = Convert.ToInt32(ddlDeathCause.SelectedValue);
                causeOfDthString = ddlDeathCause.SelectedItem.ToString();

                string dthRefSelect = "Select * from lphs.dthref where drpolno=" + polNo + " and drclmno=" + claimNo + " and drmos='" + mos + "'";

                if (dal.IsRecordExist(dthRefSelect))
                {
                    string dthRefUpdate = @"update lphs.dthref set drgrossclm = " + grossClm + "  , drnetclm=" + netClm + "," +
                                           "draccbf=" + adb + ", drfpu=" + fpu + ", drswarnajaya=" + sj + ", drfuneralexp=" + fe + "," +
                                           "drvestedbon=" + vestedBon + ", drinterimbon=" + interimBon + ", drdeposits=" + deposit + "," +
                                           "drdefprem=" + defaultPre + ", drint=" + defaultInt + ", drloncap=" + loanCap + ", drloanint=" + loanInt + "," +
                                           "deotherdeduct=" + otherDeduc + ", completed='" + polComplted + "', DCAUSEOFDTH=" + causeOfDthId + ", CAUSEOFDEATHSTR='" + causeOfDthString + "' " +
                                           "where drpolno=" + polNo + " and drmos='" + mos + "'";
                    dal.ExecuteTableUpdateQuery(dthRefUpdate);
                }
                else
                {
                    string dthRefInsert = @"insert into lphs.dthref (drpolno, drmos, drclmno, draccbf , drageadmit, drrinsyn, drrevivals, " +
                                           "drassigneenom, drvestedbon, drinterimbon, drbonsurramt, drbonsurryr, drswarnajaya, drfuneralexp, " +
                                           "drfpu, drdeposits, drdefprem, drint, drloncap, drloanint, drnetclm,drgrossclm, drpaidno," +
                                           "dragt, drnetsurr, dentdt, dentepf, age_amt, intbonstyr, branch, agedifinrst,DCAUSEOFDTH,CAUSEOFDEATHSTR,completed)" +
                                           "values(" + polNo + ",'" + mos + "'," + claimNo + ", " + adb + ", '', '', '',''," + vestedBon + "," + interimBon + ",'',''," +
                                           "" + sj + "," + fe + "," + fpu + "," + deposit + "," + defaultPre + "," + defaultInt + ", " + loanCap + "," +
                                           "" + loanInt + "," + netClm + "," + grossClm + ",'','',''," + int.Parse(this.setDate()[0]) + ",'" + epf + "',''," +
                                           "'','',''," + causeOfDthId + ",'" + causeOfDthString + "','" + polComplted + "')";
                    dal.ExecuteTableUpdateQuery(dthRefInsert);
                }

                #endregion

                #region ------------ Update Exgracia table ------------

                if (ddlIsExgracia.SelectedValue == "Y")
                {
                    string exgSelect = "select * from lphs.exgracia_amts where dpolnum=" + polNo + " and mof='" + mos + "'";

                    if (dal.IsRecordExist(exgSelect))
                    {
                        string exgUpdate = @"update lphs.exgracia_amts set sumonex=" + grossClm + ", adbonex=" + adb + ",fpuonex=" + fpu + "," +
                                            "feonex=" + fe + ",sjonex=" + sj + " where dpolnum=" + polNo + " and mof='" + mos + "'";
                        dal.ExecuteTableUpdateQuery(exgUpdate);
                    }
                    else
                    {
                        string exgInsert = @"insert into lphs.exgracia_amts (dpolnum, mof, sumonex, adbonex, fpuonex, feonex, sjonex, otheraddonex, refofprmonex)
                                             values (" + polNo + ", '" + mos + "', " + grossClm + ", " + adb + "," + fpu + "," + fe + "," + sj + ", 0, 0)";
                        dal.ExecuteTableUpdateQuery(exgInsert);
                    }
                }
                else if (ddlIsExgracia.SelectedValue == "N")
                {
                    string exgSelect1 = "select * from lphs.exgracia_amts where dpolnum=" + polNo + " and mof='" + mos + "'";
                    if (dal.IsRecordExist(exgSelect1))
                    {
                        string exgdelete = @"delete from lphs.exgracia_amts where dpolnum=" + polNo + " and mof='" + mos + "'";
                        dal.ExecuteTableUpdateQuery(exgdelete);
                    }
                }
                #endregion

                #region ---------- Update Paid No & Admin No ----------

                adminNo = txtAdminNo.Text != null ? int.Parse(txtAdminNo.Text) : 0;
                paidNo = txtPaidNo.Text != null ? int.Parse(txtPaidNo.Text) : 0;

                string dthSysNoSelect = "select * from lphs.death_sys_no where policy_no=" + polNo + " and claim_no=" + claimNo + " and p_type='" + mos + "'";

                if (dal.IsRecordExist(dthSysNoSelect))
                {
                    string dthSysNoUpdate = @"update lphs.death_sys_no set admit_no=" + adminNo + ", paid_no=" + paidNo + " " +
                                             "where policy_no=" + polNo + " and claim_no=" + claimNo + " and p_type='" + mos + "'";
                    dal.ExecuteTableUpdateQuery(dthSysNoUpdate);
                }
                else
                {
                    string dthSysNoInsert = @"insert into lphs.death_sys_no (policy_no, claim_no, p_type, admit_no, paid_no) 
                                                  values (" + polNo + "," + claimNo + ",'" + mos + "'," + adminNo + "," + paidNo + ")";
                    dal.ExecuteTableUpdateQuery(dthSysNoInsert);
                }

                #endregion

                #region ---- Insert Record Death_Reg_Manual_Update ----

                int updateSeq = 0;
                int maxUpdateSeq = 0;
                string dthRegManRecExist = "select * from lphs.death_reg_manual_update";

                if (!dal.IsRecordExist(dthRegManRecExist))
                {
                    updateSeq = 1;
                }
                else
                {
                    string dthRegManSeqMax = "select max(update_seq) from lphs.death_reg_manual_update";

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(dthRegManSeqMax))
                    {
                        using (DataTableReader dtReader = dataTable.CreateDataReader())
                        {
                            while (dtReader.Read())
                            {
                                if (!dtReader.IsDBNull(0)) { maxUpdateSeq = Convert.ToInt32(dtReader[0]); } else { maxUpdateSeq = 0; }
                            }
                        }
                    }

                    updateSeq = maxUpdateSeq + 1;
                }

                string dthRegManInsert = "insert into lphs.death_reg_manual_update (policy_no, claim_no, mos, update_seq, ip_address, epf_no, entered_date) " +
                                         "values(" + polNo + "," + claimNo + ",'" + mos + "', " + updateSeq + ", '" + ipADDR + "','" + epf + "'," + int.Parse(this.setDate()[0]) + ")";
                dal.ExecuteTableUpdateQuery(dthRegManInsert);

                #endregion

                #region ------- Upade paid Date & Account Code ----
                paidDate = txtPaidDate.Text != null ? int.Parse(txtPaidDate.Text) : 0;

                if (paidDate != 0)
                {
                    PaidDate = DateTime.ParseExact(paidDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                }

                if (isExgracia == "Y")
                {
                    accountCode = 2142;
                }
                else
                {
                    accountCode = 2118;
                }

                string cashBookPdateUpdate = @"update cashbook.temp_cb set accode=" + accountCode + ", chqdate=to_date('" + paidDate + "','YYYY-MM-DD HH24:Mi:SS') " +
                                            "where polno='" + polNo + "' and claimno='" + claimNo + "' and class='L' and divcode='L' AND VOUTYP='Death' and status='Paid'";
                dal.ExecuteTableUpdateQuery(cashBookPdateUpdate);

                #endregion

                #region ------- Update LPOLHIS Table ----
                string dthHisSelect = "select * from LPHS.LPOLHIS where phpol=" + polNo + " and phclaim=" + claimNo + " and PHMOS='" + mos + "'";

                if (!dal.IsRecordExist(dthHisSelect))
                {
                    string dthHisInsert = @"insert into LPHS.LPOLHIS (PHCOD,PHPOL,PHCOM,PHTBL,PHTRM,PHSUM,PHDUE,PHMOS,PHCLAIM,PHMOD, " +
                                           "PHPRM, PHPAC, PHAGT, PHORG, PHBRN,PHOBR, PHPTR, PHTYP, PHENT, PHEPF, PHIP, PHDATEOFINTIM) " +
                                           "values ('D'," + polNo + "," + dateofComm + "," + table + "," + trm + "," + sumassured + "," + due + ", " +
                                           "'" + mos + "'," + claimNo + "," + payMod + ",0,0,0,0,0,0,0,'D',0,'0','0'," + intiDate + ")";
                    dal.ExecuteTableUpdateQuery(dthHisInsert);
                }
                #endregion

                lblsucess.Visible = true;
                btnUpdate.Enabled = false;


                dal.CommitTransaction();
                dal.CloseDBConnection();
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction();
                dal.CloseDBConnection();
                EPage.Messege = ex.ToString();
                Response.Redirect("EPage.aspx");
            }
        }
    }

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
}
