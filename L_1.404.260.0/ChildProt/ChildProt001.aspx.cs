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

public partial class vouPrint001 : System.Web.UI.Page
{
    private long polno;
    private string MOS;
    private int printflag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)
        {
            printflag = this.PreviousPage.Printflag;
            ViewState["printflag"] = printflag;
        }
        if (!Page.IsPostBack)
        {
            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));

            ViewState["printflag"] = printflag;
        }
        else
        {
            if (ViewState["printflag"] != null) { printflag = int.Parse(ViewState["printflag"].ToString()); }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    { 
        polno = long.Parse(this.txtpolno.Text);
        MOS = this.ddlMOS.SelectedItem.Value;
        Server.Transfer("~/ChildProt/ChildProt002.aspx",true);
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
    public int Printflag
    {
        get { return printflag; }
        set { printflag = value; }
    }
}
    