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

public partial class Invest_Pol_Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Investment_Policies invpol=new Investment_Policies();
        if (!Page.IsPostBack)
        {
            if (PreviousPage != null)
            {
                invpol = this.PreviousPage.Invpol;
            }
        }
        this.GridView1.DataSource = invpol.Invpollist;
        this.GridView1.DataBind();
    }
}
