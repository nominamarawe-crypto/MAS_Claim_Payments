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

public partial class dthRev001 : System.Web.UI.Page
{

    private int polno;
    private string MOS;
    private int epf;
    User_Authentication objUserAuthentication; 

    public int EPF
    {
        get
        {
            return epf;
        }
        set { epf = value; }
    }
     
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                if (Session["EPFNum"] != null && Session["brcode"] != null)
                {
                    using (CommonFunctions cf = new CommonFunctions())
                    {
                        epf = int.Parse(cf.NumFilter(Session["EPFNum"].ToString()));
                        ViewState["EPF"] = epf;
                    }
                }
                else
                {
                    throw new Exception("Session Variable Expired..."); //Response.Redirect("~/SessionError.aspx");
                }
            }
            else
            {
                epf = int.Parse( ViewState["EPF"].ToString()) ;
            }
            //Change by Dulan Task 25215 - 2015-09-07 ********************************               
            #region -------------- Check Authority -----------------------

            objUserAuthentication = new User_Authentication();
            if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC02"))
            {
                throw new Exception("You have no Authority for this option");
            }

            #endregion.

            //Change by Dulan Task 25215 - 2015-09-07 ********************************
        }
        catch (Exception ex) {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = int.Parse(this.txtpolno.Text);
        MOS = this.ddlMOS.SelectedItem.Value;
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";
    }
    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }

    }
}
