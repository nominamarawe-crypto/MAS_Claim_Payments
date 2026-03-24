using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UpdAdmitAndPaidNoControl : System.Web.UI.Page
{
    private int oldAdmitNo = 0;
    private int oldPaidNo = 0;
    private int newAdmitNo = 0;
    private int newPaidNo = 0;
    User_Authentication objUserAuthentication; 

    public int OldAdmitNo
    {
        get { return oldAdmitNo; }
        set { oldAdmitNo = value; }
    }

    public int OldPaidNo
    {
        get { return oldPaidNo; }
        set { oldPaidNo = value; }
    }

    public int NewAdmitNo
    {
        get { return newAdmitNo; }
        set { newAdmitNo = value; }
    }

    public int NewPaidNo
    {
        get { return newPaidNo; }
        set { newPaidNo = value; }
    }
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dm = new DataManager();

            string dthSysConSelect = "SELECT ADMIT_NO, PAID_NO FROM LPHS.DEATH_SYS_CONTROL";

            if (dm.existRecored(dthSysConSelect) != 0)
            {
                dm.readSql(dthSysConSelect);
                OracleDataReader dthSysConReader = dm.oraComm.ExecuteReader();

                while (dthSysConReader.Read())
                {
                    if (!dthSysConReader.IsDBNull(0)) { oldAdmitNo = dthSysConReader.GetInt32(0); } else { oldAdmitNo = 0; }
                    if (!dthSysConReader.IsDBNull(1)) { oldPaidNo = dthSysConReader.GetInt32(1); } else { oldPaidNo = 0; }
                }
            }
            txtOldAdmitNo.Text = oldAdmitNo.ToString();
            txtOldAdmitNo.Enabled = false;
            txtOldPaidNo.Text = oldPaidNo.ToString();
            txtOldPaidNo.Enabled = false;
            txtNewAdmitNo.Text = "";
            txtNewPaidNo.Text = "";


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

                //Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        dm = new DataManager();

        try
        {
            newAdmitNo = int.Parse(txtNewAdmitNo.Text);
            newPaidNo = int.Parse(txtNewPaidNo.Text);

            string dthSysConSelect = "SELECT ADMIT_NO, PAID_NO FROM LPHS.DEATH_SYS_CONTROL";

            if (dm.existRecored(dthSysConSelect) == 0)
            {
                string dthSysConInsert = "INSERT INTO LPHS.DEATH_SYS_CONTROL(ADMIT_NO, PAID_NO) VALUES(" + newAdmitNo + "," + newPaidNo + ")";
                dm.insertRecords(dthSysConInsert);
            }
            else
            {
                string dthSysConUpdate = "UPDATE LPHS.DEATH_SYS_CONTROL SET ADMIT_NO=" + newAdmitNo + ",PAID_NO=" + newPaidNo + "";
                dm.insertRecords(dthSysConUpdate);
            }
            lblMessage.Text = "Successfully Changed!";
            lblMessage.Visible = true;
            btnChange.Enabled = false;
            dm.connClose();
        }
        catch (Exception exp)
        {
            dm.rollback();
            dm.connClose();
            EPage.Messege = exp.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
