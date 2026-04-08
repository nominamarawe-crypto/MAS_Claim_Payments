using System;
using System.Data;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    public partial class VoucherReverse : System.Web.UI.Page
    {
        private GetDBData dbGet;

       
        private string SelectedVouNo
        {
            get { return ViewState["SelectedVouNo"] as string; }
            set { ViewState["SelectedVouNo"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EPFNum"] == null)
            {
                Response.Redirect("~/EPage.aspx?msg=" + Server.UrlEncode("Session expired. Please log in again."));
                return;
            }

            if (!IsPostBack)
            {
                pnlVoucherGrid.Visible = false;
                pnlVoucherDetails.Visible = false;
                txtNIC.Text = "";
                SelectedVouNo = null;
            }
        }

        private bool ValidateDataTableColumns(DataTable dt, string[] requiredColumns)
        {
            foreach (string col in requiredColumns)
                if (!dt.Columns.Contains(col))
                    return false;
            return true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string nic = txtNIC.Text.Trim();
            if (string.IsNullOrEmpty(nic))
            {
                lblMessage.Text = "Please enter an NIC number.";
                return;
            }

            dbGet = new GetDBData();
            DataTable dt = dbGet.GetVouchersByNIC(nic);

            if (dt == null || dt.Rows.Count == 0)
            {
                lblMessage.Text = "No eligible vouchers found for this NIC (only Authorized/Printed vouchers not yet reversed).";
                pnlVoucherGrid.Visible = false;
                pnlVoucherDetails.Visible = false;
                return;
            }

            string[] required = { "VOU_NO", "CLAIM_NO", "POL_NO", "AMOUNT", "VOU_STATUS", "PAYEE_NAME" };
            if (!ValidateDataTableColumns(dt, required))
            {
                lblMessage.Text = "Data error: missing columns. Please contact support.";
                pnlVoucherGrid.Visible = false;
                return;
            }

            gvVouchers.DataSource = dt;
            gvVouchers.DataBind();
            pnlVoucherGrid.Visible = true;
            pnlVoucherDetails.Visible = false;
            lblMessage.Text = "";
            SelectedVouNo = null; 
        }

        protected void gvVouchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vouNo = gvVouchers.SelectedDataKey?.Value?.ToString();
            if (string.IsNullOrEmpty(vouNo))
            {
                lblMessage.Text = "Could not retrieve selected voucher number.";
                return;
            }

            SelectedVouNo = vouNo;
            LoadVoucherDetails(vouNo);
            pnlVoucherDetails.Visible = true;
        }

        private void LoadVoucherDetails(string vouNo)
        {
            try
            {
                dbGet = new GetDBData();
                DataTable dt = dbGet.getVouDetails(vouNo);
                if (dt.Rows.Count == 0)
                {
                    lblMessage.Text = "Voucher details not found.";
                    btnReverse.Enabled = false;
                    return;
                }

                DataRow row = dt.Rows[0];
                lblVouNum.Text = vouNo;
                lblClaimNo.Text = row["CLAIM_NO"].ToString();
                lblPolicyNo.Text = row["POL_NO"].ToString();
                lblInsuredName.Text = row["INSURED_NAME"].ToString();
                lblNetAmount.Text = Convert.ToDouble(row["AMOUNT"]).ToString("N2");
                lblPayeeName.Text = row["PAYEE_NAME"].ToString();

                string status = dt.Columns.Contains("VOU_STATUS") ? row["VOU_STATUS"]?.ToString() : null;
                lblStatus.Text = status ?? "Unknown";

                if (status == "Vou.Reversed")
                {
                    lblMessage.Text = "This voucher has already been reversed.";
                    btnReverse.Enabled = false;
                }
                else if (status != "Vou.Created" && status != "Vou.Printed" && status != "Vou.Edited" )
                {
                    lblMessage.Text = "vouchers can be reversed.";
                    btnReverse.Enabled = false;
                }
                else
                {
                    btnReverse.Enabled = true;
                    lblMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading details: " + ex.Message;
                btnReverse.Enabled = false;
            }
        }

        protected void btnReverse_Click(object sender, EventArgs e)
        {
            string vouNo = SelectedVouNo;
            if (string.IsNullOrEmpty(vouNo))
            {
                lblMessage.Text = "No voucher selected. Please select a voucher from the list.";
                return;
            }

            try
            {
                dbGet = new GetDBData();
                DataTable dt = dbGet.getVouDetails(vouNo);
                if (dt.Rows.Count == 0)
                {
                    lblMessage.Text = "Cannot reverse – voucher details missing.";
                    return;
                }

                DataRow row = dt.Rows[0];
                string policyNo = row["POL_NO"].ToString();
                int branchCode = Convert.ToInt32(Session["brcode"]);
                string epf = Session["EPFNum"].ToString();
                string machineIp = Request.ServerVariables["REMOTE_ADDR"];

                UpdateDB updater = new UpdateDB();
                string reverseVouNo = updater.ReverseVou(vouNo, branchCode, policyNo, epf, machineIp);

                if (!string.IsNullOrEmpty(reverseVouNo))
                {
                    lblMessage.Text = $"Voucher reversed successfully. Reverse Voucher No: {reverseVouNo}";
                    lblStatus.Text = "Vou.Reversed";
                    btnReverse.Enabled = false;
                 
                    btnSearch_Click(sender, e);
                   
                    SelectedVouNo = null;
                    pnlVoucherDetails.Visible = false;
                }
                else
                {
                    lblMessage.Text = "Reversal failed – no reverse voucher number generated.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error during reversal: " + ex.Message;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherReverse.aspx");
        }
    }
}