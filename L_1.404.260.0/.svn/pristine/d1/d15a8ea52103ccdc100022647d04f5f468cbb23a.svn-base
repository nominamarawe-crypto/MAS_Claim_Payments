using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

public partial class ADBApproveMemo002 : System.Web.UI.Page
{
    private long polNo;
    private string mos;
    private long claimNo;
    private int tbl;
    private int trm;
    private int comDate;
    private string epf;
    private string ipAdd;
    private double adbAmount;
    private double adbPaidAmount;
    private double grossAmount;
    private double netAmount;
    private int deductId1;
    private string deductName1;
    private double deductAmt1;
    private int deductId2;
    private string deductName2;
    private double deductAmt2;
    private string minute;
    private int dateofDeath;
    private string preEpf;
    private string nameOfDeath;
    private string isExgracia;
    private double stamp_duty;
    private string status = "";
    public bool SignatureDisplay;

    DataManager dm = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
            ipAdd = Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        if (!Page.IsPostBack)
        {
            try
            {
                dm = new DataManager();

                if (Request.QueryString["polino"] != null)
                {
                    ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polino"]));
                    polNo = Convert.ToInt64(Request.QueryString["polino"]);
                }
                if (Request.QueryString["mos"] != null)
                {
                    ViewState.Add("mosQstr", Request.QueryString["mos"].ToString());
                    mos = Request.QueryString["mos"].ToString();
                }
                if (Request.QueryString["claim_no"] != null)
                {
                    ViewState.Add("clmnoQstr", Request.QueryString["claim_no"].ToString());
                    claimNo = Convert.ToInt64(Request.QueryString["claim_no"]);
                }
                if (Request.QueryString["status"] != null)
                {
                    ViewState.Add("status", Request.QueryString["status"].ToString());
                    status = Request.QueryString["status"].ToString();
                }

                #region ------------------ Policy History --------------------
                string lpolhisCheck = "select * from LPHS.LPOLHIS where PHPOL=" + polNo + " and phtyp = 'D' and phmos = '" + mos + "' ";

                if (dm.existRecored(lpolhisCheck) != 0)
                {
                    string lpolhisRead = "select  PHCOM, PHTBL, PHTRM from LPHS.LPOLHIS where PHPOL=" + polNo + " and phtyp = 'D' and phmos = '" + mos + "'  ";

                    dm.readSql(lpolhisRead);
                    OracleDataReader lpolhisReader = dm.oraComm.ExecuteReader();
                    while (lpolhisReader.Read())
                    {
                        if (!lpolhisReader.IsDBNull(0)) { comDate = lpolhisReader.GetInt32(0); } else { comDate = 0; }
                        if (!lpolhisReader.IsDBNull(1)) { tbl = lpolhisReader.GetInt32(1); } else { tbl = 0; }
                        if (!lpolhisReader.IsDBNull(2)) { trm = lpolhisReader.GetInt32(2); } else { trm = 0; }
                    }
                    lpolhisReader.Close();
                    lpolhisReader.Dispose();
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Terminated Policy Details Found!");
                }
                #endregion

                #region  -------------- Death INT ---------------------------------

                string dthintSelect = "select ddtofdth, dnod from lphs.dthint where dpolno=" + polNo + " and dmos='" + mos + "' and dsta=2  ";
                if (dm.existRecored(dthintSelect) == 0)
                {
                    dm.connclose();
                    throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                }
                else
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { dateofDeath = dthintReader.GetInt32(0); } else { dateofDeath = 0; }
                        if (!dthintReader.IsDBNull(1)) { nameOfDeath = dthintReader.GetString(1); } else { nameOfDeath = ""; } 
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                    this.lbldtofdth.Text = dateofDeath.ToString().Substring(0, 4) + "/" + dateofDeath.ToString().Substring(4, 2) + "/" + dateofDeath.ToString().Substring(6, 2);
                }

                #endregion

                #region --------------- ADB Payment Select --------------
                string dthadbSelect = "select ADB_AMOUNT, ADB_PAYAMOUNT, DEDUCT_ID1, DEDUCT_NAME1, DEDUCT_AMOUNT1, DEDUCT_ID2, DEDUCT_NAME2, DEDUCT_AMOUNT2, MINITES, MEMO_CREATED_EPF, IS_EXGRACIA " +
                                      "from LPHS.DTH_ADBPAYMENTS where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";

                if (dm.existRecored(dthadbSelect) != 0)
                {
                    dm.readSql(dthadbSelect);
                    OracleDataReader dthadbReader = dm.oraComm.ExecuteReader();
                    while (dthadbReader.Read())
                    {
                        if (!dthadbReader.IsDBNull(0)) { adbAmount = dthadbReader.GetDouble(0); } else { adbAmount = 0.0; }
                        if (!dthadbReader.IsDBNull(1)) { adbPaidAmount = dthadbReader.GetDouble(1); } else { adbPaidAmount = 0.0; }
                        if (!dthadbReader.IsDBNull(2)) { deductId1 = dthadbReader.GetInt32(2); } else { deductId1 = 0; }
                        if (!dthadbReader.IsDBNull(3)) { deductName1 = dthadbReader.GetString(3); } else { deductName1 = ""; }
                        if (!dthadbReader.IsDBNull(4)) { deductAmt1 = dthadbReader.GetDouble(4); } else { deductAmt1 = 0.0; }
                        if (!dthadbReader.IsDBNull(5)) { deductId2 = dthadbReader.GetInt32(5); } else { deductId2 = 0; }
                        if (!dthadbReader.IsDBNull(6)) { deductName2 = dthadbReader.GetString(6); } else { deductName2 = ""; }
                        if (!dthadbReader.IsDBNull(7)) { deductAmt2 = dthadbReader.GetDouble(7); } else { deductAmt2 = 0.0; }
                        if (!dthadbReader.IsDBNull(8)) { minute = dthadbReader.GetString(8); } else { minute = ""; }
                        if (!dthadbReader.IsDBNull(9)) { preEpf = dthadbReader.GetString(9); } else { preEpf = ""; }
                        if (!dthadbReader.IsDBNull(10)) { isExgracia = dthadbReader.GetString(10); } else { isExgracia = ""; }
                    }
                    dthadbReader.Close();
                    dthadbReader.Dispose();
                }
                #endregion

                #region  ----------------- Check Pending Requirements --------------------
                bool existflag = false;
                int reqCount = 0;
                string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + polNo + " and drtyp='" + mos + "' and DRSENTDT > 0 and (drrecdt = 0 or drrecdt is null) ";
                if (dm.existRecored(dreqSelect) != 0)
                {
                    dm.readSql(dreqSelect);
                    OracleDataReader dreqreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader.Read())
                    {
                        existflag = true; reqCount++;
                    }
                    dreqreader.Close();
                    dreqreader.Dispose();
                }
                if (existflag) 
                { 
                    this.lblmissingReq.Text = "There are " + reqCount.ToString() + " Requirement/s Not Yet Recieved";
                    this.lblmissingReq.Visible = true;
                    pnlRequirements.Visible = true;
                }
                #endregion

                this.lblpolno.Text = polNo.ToString();
                this.lblclmno.Text = claimNo.ToString();
                this.lbltab.Text = tbl.ToString();
                this.lblterm.Text = trm.ToString();
                this.lblDCO.Text = comDate.ToString().Substring(0, 4) + "/" + comDate.ToString().Substring(4, 2) + "/" + comDate.ToString().Substring(6, 2);

                this.lblADBAmount.Text = adbAmount.ToString("N");
                this.lblgrossclaim.Text = adbAmount.ToString("N");

                if (deductName1 != "" && deductName1 != null)
                {
                    this.lblDeduction1.Text = deductName1.ToString();
                    this.lblDecucAmt1.Text = deductAmt1.ToString("N");

                    if (deductName2 != "" && deductName2 != null)
                    {
                        this.lblDeduction2.Text = deductName2.ToString();
                        this.lblDecucAmt2.Text = deductAmt2.ToString("N");

                        pnlDeductions2.Visible = true;
                    }
                    pnlDeductions1.Visible = true;
                }
                else
                {
                    pnlDeductions1.Visible = false;
                    pnlDeductions2.Visible = false;
                }

                netAmount = adbPaidAmount;
                this.lblNetAmt.Text = netAmount.ToString("N");
                this.txtminutes.Text = minute.ToString();

                #region ---------------- Check ADB Memo is Approved ---------------
                string dthadbAprroveSelect = "select * from LPHS.DTH_ADBPAYMENTS " +
                                             "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + " and IS_MEMO_APPROVE='Y'";

                if (dm.existRecored(dthadbAprroveSelect) != 0)
                {
                    this.btnaccept.Enabled = false;
                    this.btnPayshare.Visible = true;
                }
                #endregion

                #region ---------------- Check financial limit ---------------------
                 
                string EPF1 = Convert.ToString(dm.EpfCode(epf));
                string accssctrlSel = "select FINANTIAL_LIMIT from lphs.DTH_ACCESS_CTRL where epf = '" + EPF1.Trim() + "' and SYSTEM_ID = 'DTH' and FINANTIAL_LIMIT >= " + adbPaidAmount + " ";
                if (dm.existRecored(accssctrlSel) == 0)
                { 
                    if (this.btnaccept.Visible) { this.btnaccept.Enabled = false; }
                    this.lblacceptRestrict.Visible = true;
                }
                else { this.lblacceptRestrict.Visible = false; }

                #endregion

                #region --------------- Authorization check -----------------------

                if (dm.EpfCode(epf) == dm.EpfCode(preEpf))
                {
                    if (this.btnaccept.Visible)
                    {
                        this.btnaccept.Enabled = false;
                        this.lblacceptRestrict.Text = "Same Person cannot Create & Authorize the Voucher";
                        this.lblacceptRestrict.Visible = true;
                    }
                }
                #endregion

                if (status == "1")
                {
                    this.lblsuccess.Text = "ADB Memo Accepted";
                    this.btnaccept.Enabled = false;
                    this.btnPayshare.Visible = true;
                }


                ViewState["tbl"] = tbl;
                ViewState["netClm"] = netAmount;
                ViewState["dateofDeath"] = dateofDeath;
                ViewState["comDate"] = comDate;
                ViewState["nameOfDeath"] = nameOfDeath;
                ViewState["isExgracia"] = isExgracia;
                dm.connclose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polNo = Convert.ToInt64(ViewState["polnoQstr"].ToString()); }
            if (ViewState["mosQstr"] != null) { mos = (string)ViewState["mosQstr"]; }
            if (ViewState["clmnoQstr"] != null) { claimNo = Convert.ToInt64(ViewState["clmnoQstr"].ToString()); }
            if (ViewState["tbl"] != null) { tbl = (int)ViewState["tbl"]; }
            if (ViewState["netClm"] != null) { netAmount = Convert.ToDouble(ViewState["netClm"].ToString()); }
            if (ViewState["dateofDeath"] != null) { dateofDeath = (int)ViewState["dateofDeath"]; }
            if (ViewState["comDate"] != null) { comDate = (int)ViewState["comDate"]; }
            if (ViewState["nameOfDeath"] != null) { nameOfDeath = (string)ViewState["nameOfDeath"]; }
            if (ViewState["isExgracia"] != null) { isExgracia = (string)ViewState["isExgracia"]; }
        }
    }
    protected void btnaccept_Click(object sender, EventArgs e)
    {
        string Availability = "N";
        double shradb = 0;
        double shradbfac = 0;
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            minute = this.txtminutes.Text;
            netAmount = double.Parse(this.lblNetAmt.Text);

            #region ------------ ADB Payments table update -----------------------
            string dthadbUpdate = "update LPHS.DTH_ADBPAYMENTS set IS_MEMO_APPROVE = 'Y', MEMO_APPROVE_DATE=sysdate, " +
                                  "MEMO_APPROVE_EPF='" + epf + "', MEMO_APPROVE_IP='" + ipAdd + "', MINITES='" + minute + "' " +
                                  "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";
            dm.insertRecords(dthadbUpdate);
            #endregion

            #region ------------ Death Ref table update -----------------------
            string dthRefUpdate = "update lphs.dthref set AMTOUT = " + netAmount + ", ADBPAYAMT=" + netAmount + "" +
                                  "where DRPOLNO = " + polNo + " and DRMOS = '" + mos + "'";
            dm.insertRecords(dthRefUpdate);
            #endregion

            this.lblsuccess.Text = "ADB Memo Accepted";
            this.btnaccept.Enabled = false;
            this.btnPayshare.Visible = true;

            #region reinsure email

            string reinsurechck = "select AVAILABILITY,RE_INS_ADB,RE_INS_ADB_FAC from LPHS.DTH_REINSURANCE_DTL where CLAIMNO='" + claimNo + "'";


            if (dm.existRecored(reinsurechck) != 0)
            {
                dm.readSql(reinsurechck);
                OracleDataReader dthControlReader = dm.oraComm.ExecuteReader();
                dthControlReader.Read();
                if (!dthControlReader.IsDBNull(0)) { Availability = dthControlReader.GetString(0); }
                if (!dthControlReader.IsDBNull(1)) { shradb = dthControlReader.GetDouble(1); }
                if (!dthControlReader.IsDBNull(2)) { shradbfac = dthControlReader.GetDouble(2); }
                dthControlReader.Close();
                dthControlReader.Dispose();
            }
            if (Availability == "Y" && (shradb + shradbfac) > 0)
            {
                string checckmail = "SELECT * FROM LPHS.DTH_REINS_EMAIL_LOG WHERE  POLNO='" + polNo + "' and CLAIMNO='" + claimNo + "' and TYPE='PAYMENT'";
                if (dm.existRecored(checckmail) == 0)
                {
                    string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                            (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                             VALUES ('" + polNo + "','" + claimNo + "' , sysdate, '" + epf + "','ADB PAYMENT')";
                    dm.insertRecords(insertEmaillog);

                    string updatePayment = "UPDATE LPHS.DTH_REINSURANCE_DTL set ADB_PAYMENT_SENT=sysdate ,ADB_DETAIL_SENT='Y' " +
                                    " where CLAIMNO='" + claimNo + "'";
                    dm.insertRecords(updatePayment);
                }
            }
            #endregion

            dm.commit();
            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

        if (Availability == "Y" && (shradb + shradbfac) > 0)
        {
            Response.Redirect("PaymentForm.aspx?pState=2&clmno=" + claimNo + "&polno=" + polNo + "&mos=" + MOS + "&adb=1");
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/ADBApproveMemo003.aspx?polino=" + polNo + "&mos=" + mos + "&claim_no=" + claimNo + "");
        string url = "<script type='text/javascript'>window.open('ADBApproveMemo003.aspx?polino=" + polNo + "&mos=" + mos + "&claim_no=" + claimNo + "','_blank');</script>";
        Response.Write(url);
    }

    public long PolNo
    {
        get { return polNo; }
        set { polNo = value; }
    }

    public string MOS
    {
        get { return mos; }
        set { mos = value; }
    }

    public long ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }

    public int TBL
    {
        get { return tbl; }
        set { tbl = value; }
    }

    public double NetAmount
    {
        get { return netAmount; }
        set { netAmount = value; }
    }

    public int DateofDeath
    {
        get { return dateofDeath; }
        set { dateofDeath = value; }
    }

    public int CommDate
    {
        get { return comDate; }
        set { comDate = value; }
    }

    public string NameOfDeath
    {
        get { return nameOfDeath; }
        set { nameOfDeath = value; }
    }

    public string IsExgracia
    {
        get { return isExgracia; }
        set { isExgracia = value; }
    }

    public double StampDuty
    {
        get { return stamp_duty; }
        set { stamp_duty = value; }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("prtPmnt001.aspx?polno=" + polNo.ToString() + "&mos=" + mos + "");
    }

    protected void btnPayshare_Click(object sender, EventArgs e)
    {
        if (!this.lblNetAmt.Text.ToString().Equals(null) && !this.lblNetAmt.Text.ToString().Equals(""))
        {
            NetAmount = double.Parse(this.lblNetAmt.Text.ToString());
        }
        Server.Transfer("~/ADBPaymentDistn001.aspx", true);
    }

    protected void ChkSig(object sender, EventArgs e)
    {
        if (Signature.Checked)
        {
            SignatureDisplay = true;
        }
    }
}
