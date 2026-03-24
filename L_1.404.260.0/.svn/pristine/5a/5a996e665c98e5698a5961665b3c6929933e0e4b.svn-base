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

public partial class RepudiatePay001 : System.Web.UI.Page
{
    public long polno;
    public string mos="";
    public int clmno;
    public int dtofdth;
    User_Authentication objUserAuthentication; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = PreviousPage.Polno;
            mos = PreviousPage.mos;
            clmno = PreviousPage.Clmno;            
        }
        if (!Page.IsPostBack)
        {
            try
            {
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                if (!mos.Equals(""))
                {
                    this.txtpolno.Text = polno.ToString();
                    this.ddlMOS.SelectedItem.Value = mos;
                }

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
            catch (Exception Ex)
            {
                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
            ViewState["polno"] = polno;
            ViewState["mos"] = mos;
            ViewState["clmno"] = clmno;
        }
        else
        {
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
            if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
        }

    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Mos
    {
        get { return mos; }
        set { mos = value; }
    }
    public int Clmno
    {
        get { return clmno; }
        set { clmno = value; }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = long.Parse(this.txtpolno.Text.Trim());
        mos = this.ddlMOS.SelectedItem.Value;
    }
}
