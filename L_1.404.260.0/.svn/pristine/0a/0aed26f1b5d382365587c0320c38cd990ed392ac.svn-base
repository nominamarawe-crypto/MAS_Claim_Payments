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

public partial class ADBApproveMemo003 : System.Web.UI.Page
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
    private string preName;
    private string preEpf;
    private string preDate;

    private bool signatureDisplay;

    DataManager dm = null;
    General gg = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
            ipAdd = Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            signatureDisplay = this.PreviousPage.SignatureDisplay;
        }

        #region Add signature 

        if (signatureDisplay)
        {
            if (epf != "")
            {
                SignatureData signatureData = new SignatureData();
                signatureData = signatureData.getSignature(epf);
                if (signatureData.Signature != null)
                {
                    lblSignature.Visible = true;
                    string ImageName = epf.PadLeft(5, '0') + "_sign.png";
                    System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                    SignatureImage.ImageUrl = "~/image/" + ImageName;

                    lblSignature.Visible = true;
                    lblName.Visible = true;
                    lblDesig.Visible = true;
                    lbldip.Visible = true;
                    lblComp.Visible = true;
                    litname.Visible = false;
                }
                //if (signatureData.Signature != null)
                //{
                //    this.lblSignature.Text = "<img style=\"width: 140px; height: 40px;\" src=\"data:image/bmp;base64," + signatureData.Signature + "\"  />";
                //}
                //else
                //{
                //    this.lblSignature.Text = "";
                //}
                this.lblName.Text = signatureData.UserName + " ";
                this.lbldip.Text = "Life Insurance Section";
                this.lblComp.Text = "Sri Lanka Insurance Corporation Life Ltd";

                if (signatureData.Role != null)
                {
                    this.lblDesig.Text = signatureData.Role;
                }
                else
                {
                    this.lblDesig.Text = "Authorized Officer";
                }
            }
        }
        #endregion

        if (!Page.IsPostBack)
        {
            try
            {
                dm = new DataManager();
                gg = new General();

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
                ViewState["signatureDisplay"] = signatureDisplay;

                preName = gg.getSurname(epf); 
  
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

                string dthintSelect = "select ddtofdth from lphs.dthint where dpolno=" + polNo + " and dmos='" + mos + "' and dsta=2  ";
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
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                    this.litdtofdth.Text = dateofDeath.ToString().Substring(0, 4) + "/" + dateofDeath.ToString().Substring(4, 2) + "/" + dateofDeath.ToString().Substring(6, 2);
                }

                #endregion

                #region --------------- ADB Payment Select --------------
                string dthadbSelect = "select ADB_AMOUNT, ADB_PAYAMOUNT, DEDUCT_ID1, DEDUCT_NAME1, DEDUCT_AMOUNT1, DEDUCT_ID2, DEDUCT_NAME2, DEDUCT_AMOUNT2, MINITES, MEMO_CREATED_EPF " +
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

                this.litpolno.Text = polNo.ToString();
                this.litclmno.Text = claimNo.ToString();
                this.lbltab.Text = tbl.ToString();
                this.lblterm.Text = trm.ToString();
                this.litDCO.Text = comDate.ToString().Substring(0, 4) + "/" + comDate.ToString().Substring(4, 2) + "/" + comDate.ToString().Substring(6, 2);

                this.litadb.Text = adbAmount.ToString("N");
                this.litgrossclm.Text = adbAmount.ToString("N");

                if (deductName1 != "" && deductName1 != null)
                {
                    this.litDeducDes1.Text = deductName1.ToString();
                    this.litDedcAmt1.Text = deductAmt1.ToString("N");

                    if (deductName2 != "" && deductName2 != null)
                    {
                        this.litDeducDes2.Text = deductName2.ToString();
                        this.litDedcAmt2.Text = deductAmt2.ToString("N");

                        pnlDeductions2.Visible = true;
                    }
                    pnlDeductions1.Visible = true;
                }
                else
                {
                    pnlDeductions1.Visible = false;
                    pnlDeductions2.Visible = false;
                }

                this.litNetAmt.Text = adbPaidAmount.ToString("N");
                this.litminutes.Text = minute.ToString();

                this.litname.Text = preName.ToString();
                this.litepf.Text = preEpf.ToString();
                this.litdate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");

                LtUserDetail.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now) + " " + String.Format("{0:hh:mm:ss}", DateTime.Now) + " , " + Session["EPFNum"].ToString() + " , " + Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
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
            if (ViewState["signatureDisplay"] != null) { signatureDisplay = bool.Parse(ViewState["signatureDisplay"].ToString()); }

        }
    }
}
