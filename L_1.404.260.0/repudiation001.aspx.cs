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

public partial class repudiation001 : System.Web.UI.Page
{
    private  long polno;
    private  string MOS;
    private string rOrl;
    User_Authentication objUserAuthentication; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                dthPay020 repObj = new dthPay020();                
                polno = repObj.Polno;
                MOS = repObj.MOF;

                if ((MOS == null) || (MOS.Equals("")))
                {
                    dthPro003 proObj = new dthPro003();
                    polno = proObj.Polno;
                    MOS = proObj.mOF;

                    if ((MOS == null) || (MOS.Equals("")))
                    {
                        this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                        this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                        this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                        this.ddlMOS.Items.Add(new ListItem("Child", "C"));
                    }
                    else 
                    {
                        this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                        this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                        this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                        this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                        this.txtpolno.Text = polno.ToString();
                        if (MOS.Equals("M")) { this.ddlMOS.SelectedIndex = 0; }
                        else if (MOS.Equals("S")) { this.ddlMOS.SelectedIndex = 1; }
                        else if (MOS.Equals("2")) { this.ddlMOS.SelectedIndex = 2; }
                        else if (MOS.Equals("C")) { this.ddlMOS.SelectedIndex = 3; }                    
                    }
                  
                }
                else 
                {
                    this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                    this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                    this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                    this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                    this.txtpolno.Text = polno.ToString();
                    if (MOS.Equals("M")) { this.ddlMOS.SelectedIndex = 0; }
                    else if (MOS.Equals("S")) { this.ddlMOS.SelectedIndex = 1; }
                    else if (MOS.Equals("2")) { this.ddlMOS.SelectedIndex = 2; }
                    else if (MOS.Equals("C")) { this.ddlMOS.SelectedIndex = 3; }
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
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            polno = int.Parse(this.txtpolno.Text);
            MOS = this.ddlMOS.SelectedItem.Value;

            if (this.rbtrepu.Checked) { rOrl = "R"; }
            if (this.rbtlapse.Checked) { rOrl = "L"; }
            if (this.rbtNoContract.Checked) { rOrl = "N"; }
            if (this.rbtSp.Checked) { rOrl = "S"; }
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";       
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public string ROrl
    {
        get { return rOrl; }
        set { rOrl = value; }
    }

    private bool dateValidation(string theDate)
    {
        bool valid = true;
        int year = int.Parse(theDate.Substring(0, 4));
        int month = int.Parse(theDate.Substring(4, 2));
        int day = int.Parse(theDate.Substring(6, 2));

        if ((year < 1965) || (year > 2100)) { valid = false; }
        if ((month <= 0) || (month > 12)) { valid = false; }
        if ((day <= 0) || (day > 31)) { valid = false; }

        if (((month == 2) || (month == 4) || (month == 6) || (month == 9) || (month == 11)) && (day == 31)) { valid = false; }

        else if ((month == 2) && (day == 30) || (day == 31)) { valid = false; }

        else if ((!((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))) && (month == 2) && (day == 29)) { valid = false; }

        return valid;
    }

}
