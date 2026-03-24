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

public partial class dthreq : System.Web.UI.Page
{
    private int polno;
    private string MOS = "";
    User_Authentication objUserAuthentication; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno01;
            MOS = this.PreviousPage.mos01;            
        }

        try
        {
            if (!Page.IsPostBack)
            {
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                if (polno > 0)
                {
                    this.txtpolno.Text = polno.ToString();
                }
                else 
                {
                    this.txtpolno.Text = "";
                }
                if (MOS.Equals("M")) {
                    this.ddlMOS.SelectedIndex = 0;
                }
                else if (MOS.Equals("S")) {
                    this.ddlMOS.SelectedIndex = 1;
                }
                else if (MOS.Equals("2")) {
                    this.ddlMOS.SelectedIndex = 2;
                }
                else if (MOS.Equals("C"))
                {
                    this.ddlMOS.SelectedIndex = 3;
                }
                //Change by Dulan Task 25215 - 2015-09-07 ********************************

                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC04"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion.

                //Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
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

        Server.Transfer("~/dthreq002.aspx", true);
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
