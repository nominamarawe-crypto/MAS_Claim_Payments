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

public partial class OldChildProt_ChildProtRev001 : System.Web.UI.Page
{
    private long polno;
    private string mos;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
        this.ddlMOS.Items.Add(new ListItem("Spouce", "S"));
        this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = long.Parse(this.txtpolno.Text.Trim());
        mos = this.ddlMOS.SelectedValue;
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Mos
    {
        get { return mos; }
        set { mos = value; }
    }
}
