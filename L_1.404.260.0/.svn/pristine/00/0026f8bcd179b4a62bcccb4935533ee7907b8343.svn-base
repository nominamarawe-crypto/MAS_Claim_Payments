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

public partial class ADBPaymemtReopen001 : System.Web.UI.Page
{
    private long polNo;
    private string mos;
    private bool isRecFound;
    private bool isADBLatePay;
    private string isCompleted;
    private int payOutsatndDate;
    private double amtOutstanding;
    private string isADBReopen;
    private string isCancel;

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
                 
                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC07"))
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
        try
        {
            dm = new DataManager();

            polNo = this.txtpolno.Text != null ? Convert.ToInt64(this.txtpolno.Text) : 0;
            mos = this.ddlMOS.SelectedValue;

            #region -------------- Check ADB Payment ---------------------
            string adbReopenSelect = "select IS_ADB_REOPEN, IS_ADB_CANCEL from LPHS.DTH_ADBPAYMENTS where policy_no=" + polNo + " and mos='" + mos + "'";

            if (dm.existRecored(adbReopenSelect) != 0)
            {
                dm.readSql(adbReopenSelect);
                OracleDataReader dthrefReader = dm.oraComm.ExecuteReader();
                while (dthrefReader.Read())
                {
                    if (!dthrefReader.IsDBNull(0)) { isADBReopen = dthrefReader.GetString(0); } else { isADBReopen = ""; }
                    if (!dthrefReader.IsDBNull(1)) { isCancel = dthrefReader.GetString(1); } else { isCancel = ""; }
                }

                dthrefReader.Close();
                dthrefReader.Dispose();
            }
            #endregion

            if (isCancel == "Y")
            {
                isRecFound = true;
            }

            #region -------------- Check DthRef ---------------------
            string dthrefSelect = "select AMTOUT, PAYAUTDT, COMPLETED " +
                                      "from LPHS.DTHREF where drpolno=" + polNo + " and drmos='" + mos + "' and adb_latepay='Y'";

            if (dm.existRecored(dthrefSelect) != 0)
            {
                dm.readSql(dthrefSelect);
                OracleDataReader dthrefReader = dm.oraComm.ExecuteReader();
                while (dthrefReader.Read())
                { 
                    if (!dthrefReader.IsDBNull(0)) { amtOutstanding = dthrefReader.GetDouble(0); } else { amtOutstanding = 0.0; }
                    if (!dthrefReader.IsDBNull(1)) { payOutsatndDate = dthrefReader.GetInt32(1); } else { payOutsatndDate = 0; }
                    if (!dthrefReader.IsDBNull(2)) { isCompleted = dthrefReader.GetString(2); } else { isCompleted = ""; }
                }

                dthrefReader.Close();
                dthrefReader.Dispose();

                isADBLatePay = true; 
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
            isRecFound = true;
        }

        if (isADBReopen == "Y")
        {
            this.lblmessage.Text = "ADB Payments Already Reopen!";
        }
        else
        {
            if (isRecFound || (isADBLatePay && isCompleted == "Y" && amtOutstanding == 0))
            {                
                Response.Redirect("~/ADBPaymemtMemo002.aspx?polino=" + polNo + "&mos=" + mos + "&isCancel=" + isRecFound + "");
            }
            else
            {
                this.lblmessage.Text = "No ADB Cancel Payments for this Policy!";
            }
        }
    }
}
