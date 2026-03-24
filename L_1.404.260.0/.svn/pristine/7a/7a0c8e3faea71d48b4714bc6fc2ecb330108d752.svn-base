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

public partial class nomDetEnt02 : System.Web.UI.Page
{
    private int polno;
    private int nomno;
    private int totPercentagest;

    private double totamount;
    private double outAmt;
    private long claimno;
    private string MOF, flag;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            totPercentagest = this.PreviousPage.TotPercentagest;

            totamount = this.PreviousPage.Totamount;
            outAmt = this.PreviousPage.OutAmt;
            claimno = this.PreviousPage.Claimno;
            MOF = this.PreviousPage.mOF;
            flag = this.PreviousPage.Flag;
        }
        if (!Page.IsPostBack)
        {
            try
            {
                this.lblpolno.Text = polno.ToString();

                ViewState["polno"] = polno;
                ViewState["nomnost"] = nomno;
                ViewState["totPercentagest"] = totPercentagest;

                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["MOF"] = MOF;
                ViewState["flag"] = flag;
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else 
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["nomnost"] != null) { nomno = int.Parse(ViewState["nomnost"].ToString()); }
            if (ViewState["totPercentagest"] != null) { totPercentagest = int.Parse(ViewState["totPercentagest"].ToString()); }

            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            nomno = int.Parse(this.txtnomno.Text);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }  
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtnomno.Text = "";
    }

    public int Polno {
        get { return polno; }
        set { polno = value; }
    }
    public int Nomno {
        get { return nomno; }
        set { nomno = value; }
    }
    public int TotPercentagest
    {
        get { return totPercentagest; }
        set { totPercentagest = value; }
    }

    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public double OutAmt
    {
        get { return outAmt; }
        set { outAmt = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public string mOF
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public string Flag
    {
        get { return flag; }
        set { flag = value; }
    }


}
