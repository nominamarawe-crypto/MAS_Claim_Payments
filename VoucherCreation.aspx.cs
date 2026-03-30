using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    public partial class VoucherCreation : System.Web.UI.Page
    {
        private Authentication objAuthentication = new Authentication();
        private Policy objPolicy = new Policy();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {

                    int epf = objPolicy.EpfCode(Session["EPFNum"].ToString());
                    if (objAuthentication.checkVouCreation(Session["UserId"].ToString()) == 0)
                    {

                        string message = "Sorry. @ You have no authority for this option.";
                        Response.Redirect("~/EPage.aspx?msg=" + message + "");
                    }
                    else
                    {
                        this.lblErrorMsg.Text = "";
                    this.RadioButtonList1.SelectedValue = "D";
                    }
                }

                else
                {
                    string message = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(this.RadioButtonList1.SelectedValue.Equals("D"))
            {
                GetDBData dbDtObj = new GetDBData();
                DataTable dt = new DataTable();
                int date = int.Parse(this.tbxDate.Text.Substring(0, 4) + this.tbxDate.Text.Substring(5, 2) + this.tbxDate.Text.Substring(8, 2));
                dt = dbDtObj.getClaimToCreateVousD(date);
                this.gvClaims.DataSource = dt;
                this.gvClaims.DataBind();

            }
            else
            {
                GetDBData dbDtObj = new GetDBData();

                int fromDate = int.Parse(this.tbxDateFrom.Text.Substring(0, 4) + this.tbxDateFrom.Text.Substring(5, 2) + this.tbxDateFrom.Text.Substring(8, 2));
                int toDate = int.Parse(this.tbxDateTo.Text.Substring(0, 4) + this.tbxDateTo.Text.Substring(5, 2) + this.tbxDateTo.Text.Substring(8, 2));
                DataTable dt = new DataTable();
                dt = dbDtObj.getClaimToCreateVousDR(fromDate, toDate);
                this.gvClaims.DataSource = dt;
                this.gvClaims.DataBind();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.lblErrorMsg.Text = "";
            this.tbxDate.Text = "";
            this.tbxDateFrom.Text = "";
            this.tbxDateTo.Text = "";
            this.gvClaims.DataSource = null;
            this.gvClaims.DataBind();
        }

        protected void gvClaims_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //if (this.gvClaims.SelectedIndex > -1)
            //{
            //    int index = this.gvClaims.SelectedIndex;
            //    string clmNum = this.gvClaims.Rows[index].Cells[1].ToString();
            //    Response.Redirect("VoucherView.aspx?ClaimNo=" + clmNum);
            //}
        }

        protected void gvClaims_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvClaims.SelectedIndex > -1)
            {
                int index = this.gvClaims.SelectedIndex;
                string clmNum = this.gvClaims.Rows[index].Cells[1].Text;
                Response.Redirect("VoucherView.aspx?ClaimNo=" + clmNum);
            }
        }

        protected void gvClaims_EditedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvClaims.SelectedIndex > -1)
            {
                int index = this.gvClaims.SelectedIndex;
                string clmNum = this.gvClaims.Rows[index].Cells[1].Text;
                // Redirect to VoucherEdit instead of VoucherView
                Response.Redirect("VoucherEdit.aspx?ClaimNo=" + clmNum);
            }
        }
    }
}