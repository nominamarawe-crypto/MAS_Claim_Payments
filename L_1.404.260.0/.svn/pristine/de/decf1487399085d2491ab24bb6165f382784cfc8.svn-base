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

public partial class MemoAprv001 : System.Web.UI.Page
{
    long polno, clmno;
    string mos, completed;
    User_Authentication objUserAuthentication; 
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
        this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
        this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
        this.ddlMOS.Items.Add(new ListItem("Child", "C"));

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
                Response.Redirect("EPage.aspx");
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataManager dm = new DataManager();
        try
        {
            completed = "";
            clmno = 0;
            polno = long.Parse(this.txtpolno.Text);
            mos = this.ddlMOS.SelectedValue;
            string dtherfsel = "select COMPLETED, DRCLMNO from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
            if (dm.existRecored(dtherfsel) != 0)
            {
                dm.readSql(dtherfsel);
                OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                while (dthrefreader.Read())
                {
                    if (!dthrefreader.IsDBNull(0)) { completed = dthrefreader.GetString(0); }
                    if (!dthrefreader.IsDBNull(1)) { clmno = dthrefreader.GetInt64(1); } 
                }
                dthrefreader.Close();
            }
        }
        catch(Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        if (completed.Equals("R"))
        {
            Response.Redirect("~/RepudiatePay003.aspx?polno=" + polno + "&mos=" + mos + "&clmno=" + clmno + "");
        }
        else
        {
            Response.Redirect("~/dthPay002.aspx?polno=" + polno + "&mos=" + mos + "");
        }
        
    }
}
