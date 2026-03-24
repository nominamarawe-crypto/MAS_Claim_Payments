using MAS_Claim_Payments.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class VoucherAuthorization2 : System.Web.UI.Page
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

                    DataTable dtVouDetals = new DataTable();

                    dbGtObj = new GetDBData();
                    frmtDtObj = new FormatData();
                    
                    dtVouDetals = dbGtObj.getVouDetails(vouNo);

                    this.lblPolicyNo2.Text = dtVouDetals.Rows[0][0].ToString();
                    this.lblInsuredName2.Text = dtVouDetals.Rows[0][12].ToString();
                    this.lblClaimNo2.Text = dtVouDetals.Rows[0][19].ToString();
                    this.lblVoucherNo2.Text = vouNo;

                    this.lblNetAmtPay2.Text = (double.Parse(dtVouDetals.Rows[0][6].ToString())).ToString("N2");
                    this.lblBank2.Text = dtVouDetals.Rows[0][3].ToString();
                    this.lblBranch2.Text = dtVouDetals.Rows[0][4].ToString();
                    this.lblNICPassport2.Text = dtVouDetals.Rows[0][9].ToString();
                    this.lblPayeeName2.Text = dtVouDetals.Rows[0][7].ToString();
                    this.lblMobileNo2.Text = dtVouDetals.Rows[0][10].ToString();                   
                    this.lblClmDate.Text = dtVouDetals.Rows[0][1].ToString();
                    this.lblNetAmtPay2.Text = (double.Parse(dtVouDetals.Rows[0][6].ToString())).ToString("N2");             
                    this.lblAccountNo2.Text = dtVouDetals.Rows[0][5].ToString();
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
            int retVal = 0;

            UpdateDB updtDBObj = new UpdateDB();

            retVal = updtDBObj.AuthorizeVoucher(this.lblVoucherNo2.Text, Session["EPFNum"].ToString().ToString(), Context.Request.ServerVariables["REMOTE_ADDR"]);

            if (retVal == 1)
            {
                this.lblMessage2.Text = "Voucher authorized successfully.";
                this.btnSubmit.Visible = false;
            }
            else
            {
                this.lblMessage.Text = "Voucher not authorized successfully.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherAuthorization.aspx")
;        }
    }
}