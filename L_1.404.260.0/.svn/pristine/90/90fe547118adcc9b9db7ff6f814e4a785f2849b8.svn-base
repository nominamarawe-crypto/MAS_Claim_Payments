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

public partial class OldClmPymnt_Distribution : System.Web.UI.Page
{
    private double NetClm;
    private double Outstanding;
    private int ClaimNo;
    private string mos;
    private string Tracode="";
    User_Authentication objUserAuthentication;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));
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
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataManager dm = new DataManager();

        mos = ddlMOS.SelectedValue;
        int dthdate = 0;
        #region Get Death Date
        string getdtdate = "select DDTOFDTH from lphs.dthint where DPOLNO=" + int.Parse(txtpolno.Text.Trim()) + " and DMOS='" + mos + "'";
        if (dm.existRecored(getdtdate) != 0)
        {
            dm.readSql(getdtdate);
            OracleDataReader orared = dm.oraComm.ExecuteReader();
            while (orared.Read())
            {
                if (!orared.IsDBNull(0)) { dthdate = orared.GetInt32(0); } else { dthdate = 0; }
            }
            orared.Close();
        }
        #endregion

        #region Get Other Details
        string GetDthref = "select DRPOLNO,DRMOS,DRCLMNO,TOTPAYAMT,DRNETCLM from lphs.dthref where DRPOLNO=" + int.Parse(txtpolno.Text.Trim()) + " and DRMOS='" + mos + "'";
        if (dm.existRecored(GetDthref) != 0)
        {
            dm.readSql(GetDthref);
            OracleDataReader orared1 = dm.oraComm.ExecuteReader();
            while (orared1.Read())
            {
                if (!orared1.IsDBNull(1)) { mos = orared1.GetString(1); } else { mos = ""; }
                if (!orared1.IsDBNull(2)) { ClaimNo = orared1.GetInt32(2); }else{ClaimNo=0;}
                if (!orared1.IsDBNull(3)) { Outstanding = orared1.GetDouble(3); }else {Outstanding =0.0;}
                if (!orared1.IsDBNull(4)) { NetClm = orared1.GetDouble(4); } else { NetClm = 0.0; }           
            }
            orared1.Close();
        }
        #endregion

        #region Get Transaction Code from Dthout
        string GetDthout = "select TRANSCODE from lphs.dthout where POLNO=" + int.Parse(txtpolno.Text.Trim()) + "";
        if (dm.existRecored(GetDthout) != 0)
        {
            dm.readSql(GetDthout);
            OracleDataReader orared2 = dm.oraComm.ExecuteReader();
            while (orared2.Read())
            {
                if (!orared2.IsDBNull(0)) { Tracode = orared2.GetString(0); } else { Tracode = ""; }
            }
            orared2.Close();
        }
        #endregion
        if (Tracode.Trim() == "C" && Tracode != null && ClaimNo!=0)
        {
            Response.Redirect("paymentDistn001.aspx?polno=" + int.Parse(txtpolno.Text.Trim()) + "&totamount=" + NetClm + "&outAmt=" + Outstanding + "&claimno=" + ClaimNo + "&theMof=" + mos + "&dtofdth=" + dthdate + "");
        }
        else if (Tracode.Trim() == "C" && Tracode != null && ClaimNo == 0)
        {
            Label1.Text = "Policy number was not registered as a Death Claim Yet...Authorize the Claim First..";
        }
        else
        {
            Label1.Text = "This is not a Partly Paid Policy.Please Go to Payment Memo and Distribution link";
        }
    }
}
