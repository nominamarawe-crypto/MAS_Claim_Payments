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

public partial class docsIntMain : System.Web.UI.Page
{
    private int polno;
    private string MOF;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            hdfpol.Value =polno.ToString();
            hdfmos.Value = MOF;
        }
        if (!Page.IsPostBack)
        {
            ViewState["polno"] = polno;
            ViewState["MOF"] = MOF;
            hdfpol.Value = polno.ToString();
            hdfmos.Value = MOF;
        }
        else 
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            hdfpol.Value = polno.ToString();
            hdfmos.Value = MOF;
        }

    }

    protected void linkEngMain_Click(object sender, EventArgs e)
    {
      
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOF; }
        set { MOF = value; }
    }
}
