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
    public partial class VoucherView : System.Web.UI.Page
    {
        string claimNo;
        private GetDBData dbGtObj;
        private FormatData frmtDtObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {
                    claimNo = Request.QueryString.Get("ClaimNo");

                    DataTable dtClmDetals = new DataTable();

                    dbGtObj = new GetDBData();
                    frmtDtObj = new FormatData();

                    dtClmDetals = dbGtObj.getClaimDetails(claimNo);

                    this.lblPolicyNo2.Text = dtClmDetals.Rows[0][0].ToString();
                    this.lblInsuredName2.Text = dtClmDetals.Rows[0][12].ToString();
                    this.lblClaimNo2.Text = claimNo;

                    this.lblNetAmtPay2.Text = (double.Parse(dtClmDetals.Rows[0][6].ToString())).ToString("N2");
                    this.lblBank2.Text = dtClmDetals.Rows[0][3].ToString();
                    this.lblBranch2.Text = dtClmDetals.Rows[0][4].ToString();
                    this.lblAccountNo2.Text = dtClmDetals.Rows[0][5].ToString();
                    this.lblNICPassport2.Text = dtClmDetals.Rows[0][9].ToString();
                    this.lblPayeeName2.Text = dtClmDetals.Rows[0][7].ToString();
                    this.lblTelephoneNo2.Text = dtClmDetals.Rows[0][10].ToString();
                    this.lblEmailAdrs2.Text = dtClmDetals.Rows[0][11].ToString();
                    this.lblClmType.Text = frmtDtObj.getClmType(dtClmDetals.Rows[0][2].ToString());
                    this.lblPaymntType.Text = frmtDtObj.getPaymntType(dtClmDetals.Rows[0][8].ToString());
                    this.lblClmDt.Text = dtClmDetals.Rows[0][1].ToString();

                    this.btnPrint.Visible = false;
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
            int branchCod = int.Parse(Session["brcode"].ToString());
            string epf = Session["EPFNum"].ToString();
            string ip = Context.Request.ServerVariables["REMOTE_ADDR"];

            UpdateDB dbUpdtObj = new UpdateDB();

            string vou = dbUpdtObj.createVou(this.lblClaimNo2.Text, branchCod, this.lblPolicyNo2.Text, epf, ip);

            if (!vou.Equals(""))
            {
                this.lblSuccessMsg.Text = "Data Entered successfully. (Voucher No:" + vou + ")";
                this.btnPrint.Visible = true;
                this.btnSubmit.Visible = false;
            }
            else
            {
                this.lblSubmitError.Text = "Data not entered succesfully.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherCreation.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherPrint.aspx?ClaimNo=" + this.lblClaimNo2.Text);
        }
    }
}