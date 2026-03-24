using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReInsuranceInq002 : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    DataManager dthintobj;
    private string EPF = "";
    private string PolNo = "";
    private string SearchType = "";
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

        if (Request.QueryString["typ"] != null)
        {
            SearchType = Request.QueryString["typ"].ToString();
        }

        if(SearchType == "2")
        {
            if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
            {
                PolNo = Convert.ToString(((TextBox)PreviousPage.FindControl("txtpolno")).Text);
            }
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
            List<ReInsurance> inqlist = new List<ReInsurance>();
            dthintobj = new DataManager();
            using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
            {
                try
                {
                    ReInsurance reinsurane = new ReInsurance();

                    

                    inqlist = reinsurane.GetInqList(SearchType,PolNo, dthintobj);
                    
                    inqGrid.DataSource = inqlist;
                    inqGrid.DataBind();

                }
                catch (Exception ex)
                {
                    EPage.Messege = ex.Message.ToString();
                    Response.Redirect("EPage.aspx");
                }
                finally
                { dal.CloseDBConnection(); }
            }
            if (inqlist.Count == 0)
            {
                EPage.Messege = "No Details Found..!";
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            
        }
    }

    protected void inqGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}