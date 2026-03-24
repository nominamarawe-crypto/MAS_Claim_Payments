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

public partial class voucher_vouDelete001 : System.Web.UI.Page
{
    private long polno;
    private string MOS;
    private string payee = "";
    private double totamount;
    private double amtOut;
    private long claimno;
    private double exgraciaAmt;
    private double ADBONEX;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            { 
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                if (polno > 0) { this.txtpolno.Text = polno.ToString(); }
                else { this.txtpolno.Text = ""; }
                if ((MOS != null) && (!MOS.Equals("")))
                {
                    if (MOS.Equals("M")) { this.ddlMOS.SelectedIndex = 0; }
                    else if (MOS.Equals("S")) { this.ddlMOS.SelectedIndex = 1; }
                    else if (MOS.Equals("2")) { this.ddlMOS.SelectedIndex = 2; }
                    else if (MOS.Equals("C")) { this.ddlMOS.SelectedIndex = 3; }
                }

            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }

            if (ViewState["totamount"] != null) { totamount = int.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["amtOut"] != null) { amtOut = int.Parse(ViewState["amtOut"].ToString()); }
            if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
            if (ViewState["claimno"] != null) { claimno = int.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["exgraciaAmt"] != null) { exgraciaAmt = double.Parse(ViewState["exgraciaAmt"].ToString()); }
            if (ViewState["ADBONEX"] != null) { ADBONEX = double.Parse(ViewState["ADBONEX"].ToString()); }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            polno = long.Parse(this.txtpolno.Text);
            MOS = this.ddlMOS.SelectedItem.Value;
            string ADB_LATEPAY = "";

            string dthrefSel = "select PAYEE, DRNETCLM, ADBPAYAMT, drclmno, EXGRACIA_AMOUNT, ADB_LATEPAY from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";
            if (dm.existRecored(dthrefSel) != 0)
            {
                dm.readSql(dthrefSel);
                OracleDataReader drefrd = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (drefrd.Read())
                {
                    if (!drefrd.IsDBNull(0)) { payee = drefrd.GetString(0); } else { payee = ""; }
                    if (!drefrd.IsDBNull(1)) { totamount = drefrd.GetDouble(1); } else { totamount = 0; }
                    if (!drefrd.IsDBNull(2)) { amtOut = drefrd.GetDouble(2); } else { amtOut = 0; }
                    if (!drefrd.IsDBNull(3)) { claimno = drefrd.GetInt64(3); } else { claimno = 0; }
                    if (!drefrd.IsDBNull(4)) { exgraciaAmt = drefrd.GetDouble(4); } else { exgraciaAmt = 0; }
                    if (!drefrd.IsDBNull(5)) { ADB_LATEPAY = drefrd.GetString(5); } else { ADB_LATEPAY = ""; }
                }
                drefrd.Close();
                drefrd.Dispose();

                if (exgraciaAmt > 0)
                {
                    double SUMONEX = 0.0;
                    string exgrAmtsSel = "select SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF ='" + MOS + "' ";
                    dm.readSql(exgrAmtsSel);
                    OracleDataReader exgrAmtsRead = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (exgrAmtsRead.Read())
                    {
                        if (!exgrAmtsRead.IsDBNull(0)) { SUMONEX = exgrAmtsRead.GetDouble(0); } else { SUMONEX = 0; }
                        if (!exgrAmtsRead.IsDBNull(1)) { ADBONEX = exgrAmtsRead.GetDouble(1); } else { ADBONEX = 0; }
                    }
                    exgrAmtsRead.Close();
                    exgrAmtsRead.Dispose();
                }

                if (ADB_LATEPAY.Equals("Y")) { exgraciaAmt -= ADBONEX; }
                if (exgraciaAmt > totamount) { exgraciaAmt = totamount; } 
                
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;
                ViewState["totamount"] = totamount;
                ViewState["amtOut"] = amtOut;
                ViewState["payee"] = payee;
                ViewState["claimno"] = claimno;
                ViewState["exgraciaAmt"] = exgraciaAmt;
                ViewState["ADBONEX"] = ADBONEX;
            }
            else
            {
                dm.connclose();
                throw new Exception("No Payee Details in DTHREF");
            }
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }

    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public string Payee
    {
        get { return payee; }
        set { payee = value; }
    }
    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public double AmtOut
    {
        get { return amtOut; }
        set { amtOut = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public double ExgraciaAmt
    {
        get { return exgraciaAmt; }
        set { exgraciaAmt = value; }
    }
    public double aDBONEX
    {
        get { return ADBONEX; }
        set { ADBONEX = value; }
    }
}
