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
using System.Collections.Generic;
public partial class dthintoutstand : System.Web.UI.Page
{
    private int stdt;
    private int enddt;
    Dthintout dthintoutobj = new Dthintout();
    protected void Page_Load(object sender, EventArgs e)
    {     
        
        
        try
        { 
             if (!Page.IsPostBack)
              {
                stdt = int.Parse(Request.QueryString["startDate"].ToString());
                enddt = int.Parse(Request.QueryString["endDate"].ToString());
                dthintoutobj.Fetch(stdt, enddt);
             }
             else
               {
                   if (ViewState["stdt"] != null) { stdt = int.Parse(ViewState["stdt"].ToString()); }
                   if (ViewState["enddt"] != null) { enddt = int.Parse(ViewState["enddt"].ToString()); }
               }
        }
        catch (Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
}
