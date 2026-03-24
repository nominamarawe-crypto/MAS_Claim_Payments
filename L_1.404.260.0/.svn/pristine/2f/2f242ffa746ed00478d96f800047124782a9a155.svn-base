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

public partial class payeeInq001 : System.Web.UI.Page
{
    private int polno;
    private string MOS;
    private int senderindex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            senderindex = 0;
            if (Request.QueryString["sender"] != null) { senderindex = int.Parse(Request.QueryString["sender"]); }
            ViewState.Add("sender", senderindex.ToString());

            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));

            ViewState["polno"] = polno;
            ViewState["MOF"] = MOS;
            ViewState["senderindex"] = senderindex;
        }
        else 
        {
            senderindex = int.Parse(ViewState["sender"].ToString());
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOS = ViewState["MOF"].ToString(); }
            if (ViewState["senderindex"] != null) { senderindex = int.Parse(ViewState["senderindex"].ToString()); }
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = int.Parse(this.txtpolno.Text);
        MOS = this.ddlMOS.SelectedItem.Value;

        if (senderindex == 1) { Response.Redirect("payeeInq002.aspx?polno=" + polno.ToString() + "&mos=" + MOS + ""); }
        else if (senderindex == 2) { Response.Redirect("claiminq001.aspx?polno=" + polno.ToString() + "&mos=" + MOS + ""); }
        else if (senderindex == 3) { Response.Redirect("intimdetInq001.aspx?polno=" + polno.ToString() + "&mos=" + MOS + ""); }
        else if (senderindex == 4) { Response.Redirect("reqInq001.aspx?polno=" + polno.ToString() + "&mos=" + MOS + ""); }
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
}
