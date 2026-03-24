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

public partial class docsIntimation001 : System.Web.UI.Page
{
    private int polno;
    private string MOS;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));

            dthreq002 reqObj = new dthreq002();
            polno = reqObj.Polno;
            mos = reqObj.mof;

            if (polno > 0)
            {
                this.txtpolno.Text = polno.ToString();
                if (MOS.Equals("M")) { this.ddlMOS.SelectedIndex = 0; }
                else if (MOS.Equals("S")) { this.ddlMOS.SelectedIndex = 1; }
                else if (MOS.Equals("2")) { this.ddlMOS.SelectedIndex = 2; }
                else if (MOS.Equals("C")) { this.ddlMOS.SelectedIndex = 3; }
            }

            ViewState["polno"] = polno;
            ViewState["MOF"] = MOS;
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOS = ViewState["MOF"].ToString(); }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = Convert.ToInt32(this.txtpolno.Text.Trim());
        MOS = this.ddlMOS.SelectedItem.Value;

        Server.Transfer("~/letters/docsIntMain.aspx", true);
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
