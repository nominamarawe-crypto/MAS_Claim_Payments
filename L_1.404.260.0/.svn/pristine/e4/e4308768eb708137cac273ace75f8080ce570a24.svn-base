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

public partial class SessionTrans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["EPFNum"] = "MS0674";
        //Session["brcode"] = "010";
        //Session["UserId"] = "SEC0674";
        //Session["SurName"] = "Kodikara";

        for (int i = 0; i < Request.Form.Count; i++)
        {
            Session[Request.Form.GetKey(i)] = Request.Form[i].ToString();
            
        }
        for (int i = 0; i < Session.Count;i++ )
        {
            Response.Write(Session[i]);
            Response.Write("<br>");
        }
        if (Request.Form.Count == 0)
        {
            Response.Write("No val");
        }

        Response.Redirect("Main.aspx", false);
         
    }
}
