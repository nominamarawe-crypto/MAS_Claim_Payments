using MAS_Claim_Payments.App_Code;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class ReverseVoucherAuthorization2 : System.Web.UI.Page
    {
        private GetDBData dbGtObj;
        private FormatData frmtDtObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {
                    string vouNo = Request.QueryString.Get("VouNo");

                    if (!string.IsNullOrEmpty(vouNo))
                    {
                        LoadVoucherDetails(vouNo);
                    }
                    else
                    {
                        Response.Redirect("ReverseVoucherAuthorization.aspx");
                    }
                }
                else
                {
                    string message = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                }
            }
        }

        private void LoadVoucherDetails(string vouNo)
        {
            DataTable dtVouDetails = new DataTable();

            dbGtObj = new GetDBData();
            frmtDtObj = new FormatData();

            dtVouDetails = dbGtObj.getVoucherForReverse(vouNo);

            if (dtVouDetails.Rows.Count > 0)
            {
                this.lblPolicyNo2.Text = dtVouDetails.Rows[0][0].ToString();
                this.lblInsuredName2.Text = dtVouDetails.Rows[0][12].ToString();
                this.lblClaimNo2.Text = dtVouDetails.Rows[0][19].ToString();
                this.lblVoucherNo2.Text = vouNo;

                this.lblNetAmtPay2.Text = (double.Parse(dtVouDetails.Rows[0][6].ToString())).ToString("N2");
                this.lblBank2.Text = dtVouDetails.Rows[0][3].ToString();
                this.lblBranch2.Text = dtVouDetails.Rows[0][4].ToString();
                this.lblNICPassport2.Text = dtVouDetails.Rows[0][9].ToString();
                this.lblPayeeName2.Text = dtVouDetails.Rows[0][7].ToString();
                this.lblMobileNo2.Text = dtVouDetails.Rows[0][10].ToString();
                this.lblClmDate.Text = dtVouDetails.Rows[0][1].ToString();
                this.lblAccountNo2.Text = dtVouDetails.Rows[0][5].ToString();
                this.lblEmailAdrs2.Text = dtVouDetails.Rows[0][11].ToString();

                // Display authorization details
                this.lblVouStatus.Text = dtVouDetails.Rows[0]["VOU_STATUS"].ToString();
                this.lblAuthorizedBy.Text = dtVouDetails.Rows[0]["VOU_AUTHORIZED_BY"].ToString();
                this.lblAuthorizedDate.Text = Convert.ToDateTime(dtVouDetails.Rows[0]["VOU_AUTHORIZED_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                this.lblMessage.Text = "Voucher details not found or voucher is not in authorized state.";
                this.btnReverse.Visible = false;
            }
        }

        protected void btnReverse_Click(object sender, EventArgs e)
        {
            int retVal = 0;

            UpdateDB updtDBObj = new UpdateDB();

            retVal = updtDBObj.ReverseAuthorizeVoucher(
                this.lblVoucherNo2.Text,
                Session["EPFNum"].ToString(),
                Context.Request.ServerVariables["REMOTE_ADDR"],
                Session["UserId"] != null ? Session["UserId"].ToString() : Session["EPFNum"].ToString()
            );

            if (retVal == 1)
            {
                this.lblMessage2.Text = "Voucher authorization reversed successfully.";
                this.btnReverse.Visible = false;
            }
            else
            {
                this.lblMessage.Text = "Voucher authorization reversal failed. Please try again.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReverseVoucherAuthorization.aspx");
        }
    }
}