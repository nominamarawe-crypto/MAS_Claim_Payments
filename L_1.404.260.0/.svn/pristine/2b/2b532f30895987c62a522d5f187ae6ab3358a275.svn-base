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
using System.Data.OracleClient;

public partial class dthInt010 : System.Web.UI.Page
{
    private int polno;
    private string MOS;
    User_Authentication objUserAuthentication; 
    DataManager dthintobj;

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
                string dthout = Request.QueryString.Get("dthout");
                if (dthout == "true")
                {
                    txtpolno.Text = Request.QueryString.Get("pol").ToString();
                }
                //Change by Dulan Task 25215 - 2015-09-07 ********************************

                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC04"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion

                // Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            polno = int.Parse(this.txtpolno.Text);
            MOS = this.ddlMOS.SelectedItem.Value;

            dthintobj = new DataManager();

            string CheckDthout = "SELECT DTHPRO FROM LPHS.DTHOUT WHERE POLNO = " + polno + "  and  ( Trim(TRANSCODE)='B' or Trim(TRANSCODE)='A')";
            string DthPro = "";
            if (dthintobj.existRecored(CheckDthout) != 0)
            {
                dthintobj.readSql(CheckDthout);
                OracleDataReader reader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) { DthPro = reader.GetString(0); }
                }
                reader.Close();
                reader.Dispose();

                if (DthPro.Trim() == "Y")
                {
                    dthintobj.connclose();
                    throw new Exception("You Have Already Process This Death Claim..");
                }
                if (DthPro.Trim() == "N")
                {
                    dthintobj.connclose();
                    throw new Exception("Please Go to Outstanding Claims Entry Link to Process the Death Claim..");
                }
            }
            dthintobj.connclose();
            
        }
        catch (Exception ex)
        {
            dthintobj.connclose();
            dthintobj.oraConn.Dispose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        Server.Transfer("~/dthInt020.aspx");
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
