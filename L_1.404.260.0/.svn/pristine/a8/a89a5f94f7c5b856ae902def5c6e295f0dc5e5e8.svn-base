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

public partial class ChildProt_ChildProtPay010 : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //Change by Dulan Task 25215 - 2015-09-07 ********************************               
                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC05"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion.

                //Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("../EPage.aspx");
            }
        }
    }
    public string FromDate
    {
        get { return txtFromDate.Text; }
    }

    public string ToDate
    {
        get { return txtToDate.Text; }
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/ChildProt/ChildProtPay001.aspx",false);
    }
}
