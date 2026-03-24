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

public partial class vouAuth001 : System.Web.UI.Page
{
    private long polno;

    protected void Page_Load(object sender, EventArgs e)
    {

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
}
