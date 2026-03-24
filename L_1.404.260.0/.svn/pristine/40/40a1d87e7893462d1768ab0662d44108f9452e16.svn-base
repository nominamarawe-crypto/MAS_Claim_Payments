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

public partial class Main : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    CheckBranch Branch;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["EPFNum"] = "MS0674";
        //Session["brcode"] = "010";
        //Session["UserId"] = "SEC0674";
        //Session["SurName"] = "Kodikara";

        try
        {
            if (Session["EPFNum"] == null || Session["brcode"] == null || Session["UserId"] == null)
            {
                //EPage.Message = "Your Session Variable Expired@ Please Log to the system again";
                //Response.Redirect("EPage.aspx", false);
                //return;
                throw new Exception("Your Session Variable Expired Please Log on to the System!");
            }

            objUserAuthentication = new User_Authentication();
            if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC01"))
            {
                throw new Exception("You have no Authority for this option");
            }

            //Branch = new CheckBranch();
            //string ipaddr = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            ////string[] arr = ipaddr.Split('.');
            //string brcodeStr = Session["BRCODE"].ToString();
            //if (Branch.brCodeComparison(brcodeStr, ipaddr) == false)
            //{
            //    EPage.Message = "Sorry @You have no Authorised to work this Branch";
            //    Response.Redirect("EPage.aspx", false);
            //    return;
            //} 
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
