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

public partial class cvouMain : System.Web.UI.Page
{
    private int printflag;
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

                #endregion

                // Change by Dulan Task 25215 - 2015-09-07 ********************************
            }

            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("../EPage.aspx");
            }
        }
    }
    public int Printflag
    {
        get { return printflag; }
        set { printflag = value; }
    }

    protected void linkvouprint_Click(object sender, EventArgs e)
    {
        printflag = 1;
    }
    
    protected void linkvouedit_Click(object sender, EventArgs e)
    {
        printflag = 3;
    }

    protected void linkvoureprint_Click(object sender, EventArgs e)
    {
        printflag = 2;
    }
    protected void linkvouauth_Click(object sender, EventArgs e)
    {
        printflag = 4;
    }
    protected void linkvoudelete_Click(object sender, EventArgs e)
    {
        printflag = 5;
    }
}
