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
        private string claimNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbGtObj = new GetDBData();
            frmtDtObj = new FormatData();

            if (!IsPostBack)
            {
                // Session check
                if (Session["EPFNum"] == null)
                {
                    string msg = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + msg);
                }

                claimNo = Request.QueryString["ClaimNo"];
                if (string.IsNullOrEmpty(claimNo))
                {
                    Response.Redirect("VoucherEdit.aspx");
                    return;
                }

                // Load claim details
                DataTable dtClmDetails = dbGtObj.getClaimDetails(claimNo);
                if (dtClmDetails.Rows.Count == 0)
                {
                    Response.Redirect("VoucherEdit.aspx");
                    return;
                }

                DataRow row = dtClmDetails.Rows[0];

                // Read‑only fields
                lblPolicyNo2.Text = row["POL_NO"].ToString();
                lblInsuredName2.Text = row["INSURED_NAME"].ToString();
                lblClaimNo2.Text = claimNo;
                lblNICValue.Text = row["NIC"].ToString();
                lblAmountValue.Text = double.Parse(row["AMOUNT"].ToString()).ToString("N2");
                lblClaimDateValue.Text = row["DATE_OF_CLAIM"].ToString();
                lblClaimTypeValue.Text = frmtDtObj.getClmType(row["CLAIM_TYPE"].ToString());
                lblPaymentTypeValue.Text = frmtDtObj.getPaymntType(row["PAYMENT_TYPE"].ToString());

                // Editable fields
                txtAccountNo.Text = row["ACC_NO"].ToString();
                lblPayeeNameDisplay.Text = row["PAYEE_NAME"].ToString();   // display only
                txtContactNo.Text = row["CONTACT_NO"].ToString();
                txtEmail.Text = row["EMAIL_ADD"].ToString();

                // Load banks
                LoadBanks();

                // Select existing bank and branch
                int bankCode = 0, branchCode = 0;
                int.TryParse(row["BANK_CODE"].ToString(), out bankCode);
                int.TryParse(row["BANK_BRANCH_CODE"].ToString(), out branchCode);

                if (bankCode > 0 && ddlBank.Items.FindByValue(bankCode.ToString()) != null)
                {
                    ddlBank.SelectedValue = bankCode.ToString();
                    LoadBranches(bankCode);
                    if (branchCode > 0 && ddlBranch.Items.FindByValue(branchCode.ToString()) != null)
                    {
                        ddlBranch.SelectedValue = branchCode.ToString();
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
            int bankCode = int.Parse(ddlBank.SelectedValue);
            if (bankCode > 0)
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
            if (Page.IsValid)
            {
                try
                {
                    int bankCode = int.Parse(ddlBank.SelectedValue);
                    int branchCode = int.Parse(ddlBranch.SelectedValue);
                    string accountNo = txtAccountNo.Text.Trim();
                    string contactNo = txtContactNo.Text.Trim();
                    string email = txtEmail.Text.Trim();

                    // Get current user and IP
                    string editedBy = Session["EPFNum"]?.ToString() ?? "Unknown";
                    string editedIP = Context.Request.ServerVariables["REMOTE_ADDR"];

                    UpdateDB updateDB = new UpdateDB();
                    string message;
                    bool updated = updateDB.UpdateClaimDetails(claimNo, bankCode, branchCode, accountNo, contactNo, email, editedBy, editedIP, out message);

                    if (updated)
                    {
                        if (message.Contains("No changes"))
                            lblMessage.Text = message;
                        else
                            lblSuccessMsg.Text = message;

                        btnPrint.Visible = true;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Update failed: " + message;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Update failed: " + ex.Message;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(claimNo))
                Response.Redirect("VoucherView.aspx?ClaimNo=" + claimNo);
            else
                Response.Redirect("VoucherEdit.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherPrint.aspx?ClaimNo=" + claimNo);
        }
    }
}