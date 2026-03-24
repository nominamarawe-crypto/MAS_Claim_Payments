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

public partial class ADBApproveMemo001 : System.Web.UI.Page
{
    private long polNo;
    private string mos;
    private long claimNo;
    private bool isRecFound;
    private bool isADBLatePay;
    private string isCompleted;
    private int payOutsatndDate;
    private double amtOutstanding;
    User_Authentication objUserAuthentication;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));

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
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();

            polNo = this.txtpolno.Text != null ? Convert.ToInt64(this.txtpolno.Text) : 0;
            mos = this.ddlMOS.SelectedValue;

            #region -------------- Death Ref Select ----------------------- 
            string dthrefSelect = "select DRCLMNO, AMTOUT, PAYAUTDT, COMPLETED from LPHS.DTHREF where drpolno=" + polNo + " and drmos='" + mos + "' and adb_latepay='Y'";

            if (dm.existRecored(dthrefSelect) != 0)
            {
                dm.readSql(dthrefSelect);
                OracleDataReader dthrefReader = dm.oraComm.ExecuteReader();
                while (dthrefReader.Read())
                {
                    if (!dthrefReader.IsDBNull(0)) { claimNo = dthrefReader.GetInt64(0); } else { claimNo = 0; }
                    if (!dthrefReader.IsDBNull(1)) { amtOutstanding = dthrefReader.GetDouble(1); } else { amtOutstanding = 0.0; }
                    if (!dthrefReader.IsDBNull(2)) { payOutsatndDate = dthrefReader.GetInt32(2); } else { payOutsatndDate = 0; }
                    if (!dthrefReader.IsDBNull(3)) { isCompleted = dthrefReader.GetString(3); } else { isCompleted = ""; }
                }
                dthrefReader.Close();
                dthrefReader.Dispose();
                
                isADBLatePay = true;
            }
            #endregion
             
            #region ---------------- Check ADB Memo is Approved ---------------
            string dthadbAprroveSelect = "select * from LPHS.DTH_ADBPAYMENTS " +
                                         "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + " and IS_ADB_CANCEL<>'Y' and MEMO_CREATED_DATE is not null";

            if (dm.existRecored(dthadbAprroveSelect) != 0)
            {
                isRecFound = true;
            }
            #endregion 

            dm.connclose();
            dm.oraConn.Dispose();
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

        if (isADBLatePay && isCompleted == "Y" && amtOutstanding == 0)
        {
            this.lblmessage.Text = "ADB payment Already Cancel!";
        }
        else
        {
            if (isRecFound)
            {
                Response.Redirect("~/ADBApproveMemo002.aspx?polino=" + polNo + "&mos=" + mos + "&claim_no=" + claimNo + "");
            }
            else
            {
                this.lblmessage.Text = "Please create ADB payment memo for this Policy";
            }
        }
    }
}
