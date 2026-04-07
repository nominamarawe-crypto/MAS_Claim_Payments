using System;
using System.Data;
using System.Web.UI.WebControls;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    public partial class VoucherEditView : System.Web.UI.Page
    {
        private GetDBData dbGtObj;
        private FormatData frmtDtObj;
        private string vouNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbGtObj = new GetDBData();
            frmtDtObj = new FormatData();

            if (!IsPostBack)
            {
              
                if (Session["EPFNum"] == null)
                {
                    string msg = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + Server.UrlEncode(msg));
                    return;
                }


                vouNo = Request.QueryString["VOU_NO"];
                Session["VOU_NO"] = vouNo;
                if (string.IsNullOrEmpty(vouNo))
                {
                    Response.Redirect("VoucherEdit.aspx");
                    return;
                }

             
                DataTable dtEditDetails = null;
                try
                {
                    dtEditDetails = dbGtObj.EditClaimDetail(vouNo); // VOUCHER NO
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error loading claim details: " + ex.Message;
                    return;
                }

                if (dtEditDetails == null || dtEditDetails.Rows.Count == 0)
                {
                    lblMessage.Text = "Vou not found.";
                    return;
                }

                DataRow row = dtEditDetails.Rows[0];

            
                lblPolicyNo2.Text = row["POL_NO"]?.ToString().Trim() ?? "";
                lblInsuredName2.Text = row["INSURED_NAME"]?.ToString().Trim() ?? "";
                lblClaimNo2.Text = vouNo;
                lblVouNo.Text = row["VOU_NO"]?.ToString().Trim() ?? "";
                lblNICValue.Text = row["NIC"]?.ToString().Trim() ?? "";

                double amount = 0;
                double.TryParse(row["AMOUNT"]?.ToString(), out amount);
                lblAmountValue.Text = amount.ToString("N2");

                lblClaimDateValue.Text = row["DATE_OF_CLAIM"]?.ToString() ?? "";
                lblClaimTypeValue.Text = frmtDtObj.getClmType(row["CLAIM_TYPE"]?.ToString() ?? "");
                lblPaymentTypeValue.Text = frmtDtObj.getPaymntType(row["PAYMENT_TYPE"]?.ToString() ?? "");

            
                txtAccountNo.Text = row["ACC_NO"]?.ToString().Trim() ?? "";
                lblPayeeNameDisplay.Text = row["PAYEE_NAME"]?.ToString().Trim() ?? "";
                txtContactNo.Text = row["CONTACT_NO"]?.ToString().Trim() ?? "";
                txtEmail.Text = row["EMAIL_ADD"]?.ToString().Trim() ?? "";

            
                LoadBanks();

                int bankCode = 0, branchCode = 0;
                int.TryParse(row["BANK_CODE"]?.ToString(), out bankCode);
                int.TryParse(row["BANK_BRANCH_CODE"]?.ToString(), out branchCode);

                if (bankCode > 0 && ddlBank.Items.FindByValue(bankCode.ToString()) != null)
                {
                    ddlBank.SelectedValue = bankCode.ToString();
                    LoadBranches(bankCode);
                    if (branchCode > 0 && ddlBranch.Items.FindByValue(branchCode.ToString()) != null)
                    {
                        ddlBranch.SelectedValue = branchCode.ToString();
                    }
                }

               
                string existingVouNo = row["VOU_NO"]?.ToString();
                if (!string.IsNullOrEmpty(existingVouNo))
                {
                    string status = row["VOU_STATUS"]?.ToString() ?? "";
                    if (status == "Vou.Authorized")
                    {
                        lblMessage.Text = "This claim already has a authorized voucher. Cannot edit.";
                        btnSave.Enabled = false;
                        //btnPrint.Visible = true;
                    }
                }
            }
        }

        private void LoadBanks()
        {
            DataTable dtBanks = dbGtObj.GetBanks();
            ddlBank.Items.Clear();
            ddlBank.Items.Add(new ListItem("-- Select Bank --", "0"));
            foreach (DataRow row in dtBanks.Rows)
            {
                ddlBank.Items.Add(new ListItem(row["BANK_NAME"].ToString(), row["BANK_CODE"].ToString()));
            }
        }

        private void LoadBranches(int bankCode)
        {
            DataTable dtBranches = dbGtObj.GetBranches(bankCode);
            ddlBranch.Items.Clear();
            ddlBranch.Items.Add(new ListItem("-- Select Branch --", "0"));
            foreach (DataRow row in dtBranches.Rows)
            {
                ddlBranch.Items.Add(new ListItem(row["BRANCH_NAME"].ToString(), row["BRANCH_CODE"].ToString()));
            }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bankCode;
            if (int.TryParse(ddlBank.SelectedValue, out bankCode) && bankCode > 0)
            {
                LoadBranches(bankCode);
            }
            else
            {
                ddlBranch.Items.Clear();
                ddlBranch.Items.Add(new ListItem("-- Select Branch --", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            lblMessage.Text = "";
            lblSuccessMsg.Text = "";

            // ✅ Session validation
            string vouNo = Session["VOU_NO"]?.ToString();
            string editedBy = Session["EPFNum"]?.ToString();

            if (string.IsNullOrEmpty(vouNo) || string.IsNullOrEmpty(editedBy))
            {
                lblMessage.Text = "Session expired. Please login again.";
                return;
            }

            // ✅ Dropdown validation
            int bankCode, branchCode;

            if (!int.TryParse(ddlBank.SelectedValue, out bankCode) || bankCode <= 0)
            {
                lblMessage.Text = "Please select a valid bank.";
                return;
            }

            if (!int.TryParse(ddlBranch.SelectedValue, out branchCode) || branchCode <= 0)
            {
                lblMessage.Text = "Please select a valid branch.";
                return;
            }

            // ✅ Input validation
            string accountNo = txtAccountNo.Text.Trim();
            string contactNo = txtContactNo.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Account No validation
            if (string.IsNullOrEmpty(accountNo))
            {
                lblMessage.Text = "Account number is required.";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(accountNo, @"^[0-9]{6,20}$"))
            {
                lblMessage.Text = "Account number must be 6–20 digits.";
                return;
            }

            // Contact No validation (optional but strict if entered)
            if (!string.IsNullOrEmpty(contactNo) &&
                !System.Text.RegularExpressions.Regex.IsMatch(contactNo, @"^[0-9]{10}$"))
            {
                lblMessage.Text = "Contact number must be 10 digits.";
                return;
            }

            // Email validation (optional)
            if (!string.IsNullOrEmpty(email) &&
                !System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Invalid email format.";
                return;
            }

            // ✅ Business validation (IMPORTANT)
            FormatData fmt = new FormatData();

            if (!fmt.validateAccountNo(accountNo, bankCode, branchCode))
            {
                lblMessage.Text = "Account number does not match selected bank/branch.";
                return;
            }

            // ✅ IP Address
            string editedIP = Request.ServerVariables["REMOTE_ADDR"];

            // ✅ Update DB
            UpdateDB updateDB = new UpdateDB();
            string message;
            bool updated = false;

            try
            {
                updated = updateDB.UpdateClaimDetails(
                    vouNo,
                    bankCode,
                    branchCode,
                    accountNo,
                    contactNo,
                    email,
                    editedBy,
                    editedIP,
                    out message
                );
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Database error: " + ex.Message;
                return;
            }

            // ✅ Result handling
            if (updated)
            {
                if (message.Contains("No changes"))
                {
                    lblMessage.Text = message;
                }
                else
                {
                    lblSuccessMsg.Text = "Claim updated successfully.";
                    btnSave.Visible = false;
                }
            }
            else
            {
                lblMessage.Text = "Update failed: " + message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vouNo))
                Response.Redirect("VoucherView.aspx?VOU_NO=" + Server.UrlEncode(vouNo));
            else
                Response.Redirect("VoucherEdit.aspx");
        }

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("VoucherPrint.aspx?ClaimNo=" + Server.UrlEncode(claimNo));
        //}
    }
}