using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReInsuranceInq001 : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    DataManager dthintobj;
    private string EPF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            Response.Redirect("SessionError.aspx");
        }
        if (!Page.IsPostBack)
        {
            try
            {
                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC08"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion


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
        string searchType = ddlSearchBy.SelectedValue;

        if(searchType == "2" && txtpolno.Text.Trim() == "")
        {
            lblErr.Text = "Please enter the Policy Number";
            lblErr.Visible = true;
        }
        else
        {
            Server.Transfer("~/ReInsuranceInq002.aspx?typ="+searchType+"", false);
        }
    }
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSearchBy.SelectedValue == "2")
        {
            secPOl.Visible = true;
        }
    }
}