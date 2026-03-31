using System;
using System.Data;
using System.Web.UI.WebControls;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    public partial class VoucherEdit : System.Web.UI.Page
    {
        private GetDBData dbObj = new GetDBData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
           
                if (Session["EPFNum"] == null)
                {
                    string msg = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + msg);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            pnlGrid.Visible = false;
            gvClaims.DataSource = null;
            gvClaims.DataBind();

            string nic = txtNIC.Text.Trim();
            if (string.IsNullOrEmpty(nic))
            {
                lblMessage.Text = "Please enter NIC.";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nic, @"^[0-9]{9}[VvXx]|[1-2][0-9]{11}$"))
            {
                lblMessage.Text = "Invalid NIC format.";
                return;
            }

            
            DataTable dtClaims = dbObj.GetEditableClaimsByNIC(nic);
            if (dtClaims.Rows.Count == 0)
            {
                lblMessage.Text = "No editable claims found for this NIC.";
            }
            else if (dtClaims.Rows.Count == 1)
            {

                string claimNo = dtClaims.Rows[0]["CLAIM_NO"].ToString();
                Response.Redirect("VoucherEditView.aspx?ClaimNo=" + claimNo);
            }
            else
            {
               
                gvClaims.DataSource = dtClaims;
                gvClaims.DataBind();
                pnlGrid.Visible = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtNIC.Text = "";
            lblMessage.Text = "";
            pnlGrid.Visible = false;
            gvClaims.DataSource = null;
            gvClaims.DataBind();
        }

        protected void gvClaims_SelectedIndexChanged(object sender, EventArgs e)
        {
            string claimNo = gvClaims.SelectedDataKey.Value.ToString();
            Response.Redirect("VoucherEditView.aspx?ClaimNo=" + claimNo);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherCreation.aspx");
        }
    }
}