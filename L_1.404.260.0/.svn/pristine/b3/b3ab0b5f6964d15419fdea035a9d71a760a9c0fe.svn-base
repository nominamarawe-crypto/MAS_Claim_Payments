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

public partial class loanRecReprint001 : System.Web.UI.Page
{
    private int polno;
    private string ttype;
    User_Authentication objUserAuthentication;
    public int Polno 
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Ttype
    {
        get { return ttype; }
        set { ttype = value; }
    }

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
                Response.Redirect("EPage.aspx");
            }
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        this.polno = int.Parse(this.txtpolno.Text); 
        this.ttype = "D";
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";
    }

    
}
