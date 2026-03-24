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

public partial class voucher_vouDelete003 : System.Web.UI.Page
{
    private long polno;
    private string MOS;
    private string payee; 
    private long claimno;
    private string vouno;
    private string INSNAME;
    private double TOTAMOUNT;
    private string epf;
    private string brn;
    private string ip_add;
    private string payeeName;
    private int isAuthorized;
    private int isDeleted;
    private string vouType;
    private string deleteType;
    private double totPay_Amout;
    private double totOutstand_amount;

    DataManager dm;
    User_Authentication objUserAuthentication; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
            brn = Session["brcode"].ToString();
            ip_add = Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
        else
        {
            Response.Redirect("~/SessionError.aspx");
        }

        #region -------------- Check Authority -----------------------
        objUserAuthentication = new User_Authentication();
        if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC05"))
        {
            throw new Exception("You have no Authority for this option");
        }
        #endregion

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            { 
                polno = long.Parse(Request.QueryString["polno"]);
                MOS = Request.QueryString["mos"].ToString();
                vouno = Request.QueryString["vouno"].ToString();
                payee = Request.QueryString["payee"].ToString(); 
                claimno = long.Parse(Request.QueryString["clmno"]);

                //vouType = Request.QueryString["vouType"].ToString(); #42650 Raitha Lakshan
                if (Request.QueryString["vouType"] != null)
                {
                    vouType = Request.QueryString["vouType"].ToString();
                }

                if (Request.QueryString["delete_Type"] != null)
                {
                    deleteType = Request.QueryString["delete_Type"].ToString();
                }

                ViewState.Add("polnoQstr", polno.ToString());
                ViewState.Add("MOSQstr", MOS);
                ViewState.Add("vounoQstr", vouno);
                ViewState.Add("payeeQstr", payee); 
                ViewState.Add("clmno", claimno.ToString());

                //ViewState.Add("vouTypeQstr", vouType.ToString()); #42650 Raitha Lakshan
                if (Request.QueryString["vouType"] != null)
                {
                    ViewState.Add("vouTypeQstr", vouType.ToString());
                }

                if (Request.QueryString["delete_Type"] != null)
                {
                    ViewState.Add("delete_TypeQstr", deleteType.ToString());
                }

                this.lblpolno.Text = polno.ToString();
                if (MOS.Equals("M")) { this.lblmos.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lblmos.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lblmos.Text = "Second Life"; }
                this.lblclaimno.Text = claimno.ToString(); 

                #region //--------------- temp_cb select -------------------------------------

                string temp_cbSelect = "select INSNAME, TOTAMOUNT, AUTHORIZED, DELETED from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and STATUS='Pending' and AUTHORIZED=0";

                if (dm.existRecored(temp_cbSelect) != 0)
                {
                    dm.readSql(temp_cbSelect);
                    OracleDataReader temp_cbReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (temp_cbReader.Read())
                    { 
                        if (!temp_cbReader.IsDBNull(0)) { INSNAME = temp_cbReader.GetString(0); } else { INSNAME = ""; }
                        if (!temp_cbReader.IsDBNull(1)) { TOTAMOUNT = temp_cbReader.GetDouble(1); } else { TOTAMOUNT = 0.0; }
                        if (!temp_cbReader.IsDBNull(2)) { isAuthorized = temp_cbReader.GetInt32(2); } else { isAuthorized = 0; }
                        if (!temp_cbReader.IsDBNull(3)) { isDeleted = temp_cbReader.GetInt32(3); } else { isDeleted = 0; }
                    }
                    temp_cbReader.Close();
                    temp_cbReader.Dispose();

                    this.lblphname.Text = INSNAME; 
                    this.lblnetamt.Text = String.Format("{0:N}", TOTAMOUNT);
                    this.lblVouNo.Text = vouno.ToString();
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Voucher Details Availbale or Voucher Already Authorized!");
                }

                #endregion

                #region //--------------- dthref select -------------------------------------

                string dthref_Select = "select TOTPAYAMT, AMTOUT from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOS + "' and DRCLMNO=" + claimno + "";

                if (dm.existRecored(dthref_Select) != 0)
                {
                    dm.readSql(dthref_Select);
                    OracleDataReader dthref_Reader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthref_Reader.Read())
                    {
                        if (!dthref_Reader.IsDBNull(0)) { totPay_Amout = dthref_Reader.GetDouble(0); } else { totPay_Amout = 0.0; }
                        if (!dthref_Reader.IsDBNull(1)) { totOutstand_amount = dthref_Reader.GetDouble(1); } else { totOutstand_amount = 0.0; } 
                    }
                    dthref_Reader.Close();
                    dthref_Reader.Dispose(); 
                } 
                #endregion

                #region ---------------- Check Child protection annual payment ----------------

                if (vouType == "C")
                {
                    bool isRecFound = false;

                    string periodicSelect = "select * from LCLM.PERIODIC_PAYDET where vono = '" + vouno + "' and polno=" + polno + "";

                    if (dm.existRecored(periodicSelect) != 0)
                    {
                        dm.readSql(periodicSelect);
                        OracleDataReader periodic_paydetReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (periodic_paydetReader.Read())
                        {
                            isRecFound = true;
                        }
                        periodic_paydetReader.Close();
                        periodic_paydetReader.Dispose();
                    }

                    if (!isRecFound)
                    {
                        this.btnDelete.Enabled = false;
                        this.lblmessage.Text = "Child Protection Voucher not Available!.";
                        this.lblmessage.Visible = true;
                    } 
                }

                #endregion

                if (isAuthorized == 1)
                {
                    this.btnDelete.Enabled = false;
                    this.lblmessage.Visible = true;
                }

                if (isDeleted == 1)
                {
                    this.btnDelete.Enabled = false;
                    this.lblmessage.Text = "Voucher already Deleted.";
                    this.lblmessage.Visible = true;
                } 

                #region //--------------- voubankdet select ----------------------------------

                string voubankdetSel = "select PAYEENAME from LPHS.VOUBANKDET where POLICYNO = " + polno + " and VOUCHERNO = '" + vouno + "' ";
                if (dm.existRecored(voubankdetSel) != 0)
                {
                    dm.readSql(voubankdetSel);
                    OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader();
                    while (voubankdetReader.Read())
                    {
                        if (!voubankdetReader.IsDBNull(0)) { payeeName = voubankdetReader.GetString(0); } else { payeeName = ""; }
                    }
                    voubankdetReader.Close();

                    this.lblPayeeName.Text = payeeName;
                }

                #endregion
                 
                ViewState["INSNAME"] = INSNAME; 
                ViewState["TOTAMOUNT"] = TOTAMOUNT;
                ViewState["totPay_Amout"] = totPay_Amout;
                ViewState["totOutstand_amount"] = totOutstand_amount; 
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        }
        else
        {
            polno = long.Parse(ViewState["polnoQstr"].ToString());
            MOS = ViewState["MOSQstr"].ToString();
            vouno = ViewState["vounoQstr"].ToString();
            payee = ViewState["payeeQstr"].ToString(); 
            claimno = long.Parse(ViewState["clmno"].ToString()); 
            if (ViewState["INSNAME"] != null) { INSNAME = ViewState["INSNAME"].ToString(); } 
            if (ViewState["TOTAMOUNT"] != null) { TOTAMOUNT = double.Parse(ViewState["TOTAMOUNT"].ToString()); }
            if (ViewState["vouTypeQstr"] != null) { vouType = ViewState["vouTypeQstr"].ToString(); }
            if (ViewState["delete_TypeQstr"] != null) { deleteType = ViewState["delete_TypeQstr"].ToString(); }
            if (ViewState["totPay_Amout"] != null) { totPay_Amout = double.Parse(ViewState["totPay_Amout"].ToString()); }
            if (ViewState["totOutstand_amount"] != null) { totOutstand_amount = double.Parse(ViewState["totOutstand_amount"].ToString()); }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            dm.begintransaction();
            #region ------------ Delete tag in Temp_cb ------------------

            string temp_cbSelect = "select INSNAME, TOTAMOUNT from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and STATUS='Pending' and AUTHORIZED=0";
            if (dm.existRecored(temp_cbSelect) != 0)
            {
                string TEMP_CBupdate = "update CASHBOOK.TEMP_CB set status = 'Cancelled', deleted = 1, chqcan = 1 where vouno = '" + vouno + "' ";
                dm.insertRecords(TEMP_CBupdate);
            }
            else
            {
                dm.connclose();
                throw new Exception("No Voucher Details Availbale or Voucher Already Authorized!");
            }

            #endregion

            if (deleteType == "Dth")
            {
                if (payee.Equals("Nominee"))
                {
                    string nominee_update = "update LUND.NOMINEE set VOUSTA = '', VOUNO = '', voudate='' where polno=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(nominee_update);
                }
                else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                {
                    string legalhir_update = "update lphs.legal_hires set VOUSTA = '', VOUNO = '', voudate='' where LHPOLNO=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(legalhir_update);
                }
                else if (payee.Equals("Assignee"))
                {
                    string assignee_update = "update LUND.ASSIGNEE set VOUSTA = '', VOUNO = '', voudate='' where POLICY_NO=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(assignee_update);
                }
                else if (payee.Equals("Living_Partner"))
                {
                    string livptr_update = "update LUND.LIVING_PRT set VOUSTA = '', VOUNO = '', voudate='' where POLNO=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(livptr_update);
                }

                string dthref_update = "update LPHS.DTHREF set COMPLETED = '', PAYAUTDT = '', PAYAUTEPF='' where DRPOLNO=" + polno + " and DRMOS = '" + MOS + "' ";
                dm.insertRecords(dthref_update);
            }
            else if (deleteType == "ADB")
            {
                double newtotpay_amt = 0.0;
                double newtotout_amt = 0.0;

                if (payee.Equals("Nominee"))
                {
                    string nominee_update = "update LUND.NOMINEE set ADBVOUSTA = '', ADBVOUNO = '', ADBVOUDATE='', ADBAUTDATE='', ADBAUTEPF='' where polno=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(nominee_update);
                }
                else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                {
                    string legalhir_update = "update lphs.legal_hires set ADBVOUSTA = '', ADBVOUNO = '', ADBVOUDATE='', ADBAMT='', ADBAUTDATE='', ADBAUTEPF='' where LHPOLNO=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(legalhir_update);
                }
                else if (payee.Equals("Assignee"))
                {
                    string assignee_update = "update LUND.ASSIGNEE set ADBVOUSTA = '', ADBVOUNO = '', ADBAUTDATE='', ADBAUTEPF='', ADBVOUDATE=''  where POLICY_NO=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(assignee_update);
                }
                else if (payee.Equals("Living_Partner"))
                {
                    string livptr_update = "update LUND.LIVING_PRT set ADBVOUSTA = '', ADBVOUNO = '', ADBAUTDATE='', ADBAUTEPF='', ADBVOUDATE='' where POLNO=" + polno + " and VOUNO = '" + vouno + "' ";
                    dm.insertRecords(livptr_update);
                }

                newtotpay_amt = totPay_Amout - TOTAMOUNT;
                newtotout_amt = totOutstand_amount + TOTAMOUNT;

                string dthref_update = "update LPHS.DTHREF set TOTPAYAMT=" + newtotpay_amt + ", AMTOUT=" + newtotout_amt + ", COMPLETED = '', PAYAUTDT = '', PAYAUTEPF='' where DRPOLNO=" + polno + " and DRMOS = '" + MOS + "' ";
                dm.insertRecords(dthref_update);
            }
            else if (deleteType == "" || deleteType == null)  //else if (deleteType == "SLIC") #42650 Rajita Lakshan
            {
                string slicVou_delete = "delete LPHS.SLICVOUCHERS Where  SVVOUNO = '" + vouno + "' and SVPOL=" + polno + "";
                dm.insertRecords(slicVou_delete);
            }

            #region ------------------- Update Child protection Voucher Deletion ---------
            
            if (vouType == "C")
            {
                string periodicpaysel = "select * from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and VONO='" + vouno + "'";
                if (dm.existRecored(periodicpaysel) != 0)
                {
                    //string deletePeriodic = "delete from LCLM.PERIODIC_PAYDET  where POLNO=" + polno + " and VONO='" + vouno + "'";
                    string periodicpayupd = "update LCLM.PERIODIC_PAYDET set VONO='XXXX', PAYDATE='', PAYEPF='', PAYIP='' where POLNO=" + polno + " and VONO='" + vouno + "'";
                    dm.insertRecords(periodicpayupd);
                }
            }

            #endregion

            #region ------------------- insert Voucher Delete log ------------------------

            string voudeletelog_insert = "insert into LPHS.VOUCHERDELETE_LOG(VOUNO, DELETE_DATE, DELETE_EPF, DELETE_IP, DELETE_BRN) " +
                                       "values ('" + vouno + "',sysdate,'" + epf + "','" + ip_add + "','" + brn + "')";
            dm.insertRecords(voudeletelog_insert);

            #endregion

            #region 34965 StagePayment Reverse
            string lcmmastrevsql = "insert into lclm.lcmmast_rev (PTYP,PCLAIMNO,PPOLNO,PTABLE,PTERM,PDCOM,PSUM,PPAYAMT," +
                "PADSUM,PADSJA,PAOAD1,PAOAD2,POBRN,PSTNO,PPPSTAT,PEEPF,PEDAT,PPACODE,PAADD,PASCD,PELPRM,PELDEP,PLONNO,PLONCAP," +
                "PLONINT,PDEFPRM,PDEFINT,PDIFFPR,PDIFFIN,PDEDRS1,PDEDAM1,PDEDRS2,PDEDAM2,PBONUS,PSBONUY,PSBONUS,PVBONUS,PIBONUS," +
                "PVOUNO,PVOUDAT,PDOCNO,PCONNO,PNPSTAT,PCODE1,PCODE2,PCODE3,PCODE4,PCODE5,PCODE6,PCODE7,PCODE8,PCODE9,PCODE10," +
                "PCCOD,PUEPF,PUDAT,PCEPF,PCDAT,PLCON,PLEPF,PLDAT,PDELT,POSAM,PASNA,PEXY,PEXM,PNPYE,PNPMO,PLONCAP2,PLONINT2,PCONNO2," +
                "PXXXX,PNTABLE,PAGE,COUNT,PLONWRT,PAGNO,PDOCNO1,PMATDATE,TERM1,PTAB38,OTHER_ADDITION_REASON,OTHER_ADDITION_AMOUNT," +
                "STAGE_DATE,LANGUAGE,BELOW_18,CHILD_NAME,MANUAL,PXXX2,PXXX1,JCODE,JGROSS,JNET,JDATE,STAMP_FEE,PARENT_CONCENT," +
                "DELETE_DATE,DELETE_EPF) select PTYP, PCLAIMNO, PPOLNO, PTABLE, PTERM, PDCOM, PSUM,PPAYAMT, PADSUM, PADSJA, PAOAD1," +
                " PAOAD2, POBRN, PSTNO, PPPSTAT, PEEPF, PEDAT, PPACODE, PAADD, PASCD, PELPRM, PELDEP,PLONNO, PLONCAP, PLONINT, " +
                "PDEFPRM, PDEFINT, PDIFFPR, PDIFFIN, PDEDRS1, PDEDAM1, PDEDRS2, PDEDAM2, PBONUS, PSBONUY,PSBONUS, PVBONUS, PIBONUS," +
                " PVOUNO, PVOUDAT, PDOCNO, PCONNO, PNPSTAT, PCODE1, PCODE2, PCODE3, PCODE4, PCODE5, PCODE6,PCODE7, PCODE8, PCODE9," +
                " PCODE10, PCCOD, PUEPF, PUDAT, PCEPF, PCDAT, PLCON, PLEPF, PLDAT, PDELT, POSAM, PASNA, PEXY,PEXM, PNPYE, PNPMO," +
                " PLONCAP2, PLONINT2, PCONNO2, PXXXX, PNTABLE, PAGE, COUNT, PLONWRT, PAGNO, PDOCNO1, PMATDATE,TERM1, PTAB38, " +
                "OTHER_ADDITION_REASON, OTHER_ADDITION_AMOUNT, STAGE_DATE, LANGUAGE, BELOW_18, CHILD_NAME,MANUAL, PXXX2, PXXX1," +
                " JCODE, JGROSS, JNET, JDATE, STAMP_FEE, PARENT_CONCENT, sysdate,'"+ epf + "' from lclm.lcmmast " +
                "where pvouno = '"+vouno+"' and ptyp = 2";
            dm.insertRecords(lcmmastrevsql);

            string updatestagepayment = "update lclm.lcmmast set pvoudat='0',pvouno='' where pvouno = '" + vouno + "' and ptyp = 2";
            dm.insertRecords(updatestagepayment);
            #endregion

            this.lblsuccess.Visible = true;
            this.btnDelete.Enabled = false;

            dm.commit();
            dm.connclose();
        }
        catch (Exception exp)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = exp.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    protected void btnexit_Click(object sender, EventArgs e)
    {

    }
}
