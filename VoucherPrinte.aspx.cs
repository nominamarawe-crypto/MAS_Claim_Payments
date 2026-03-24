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
    public partial class VoucherPrint : System.Web.UI.Page
    {
        string claimNo, vouNo;
        private GetDBData dbGtObj;
        private FormatData frmtDtObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {
                    claimNo = Request.QueryString.Get("ClaimNo");                    

                    DataTable dtVouDetals = new DataTable();

                    dbGtObj = new GetDBData();
                    frmtDtObj = new FormatData();

                    vouNo = dbGtObj.getVouNo(claimNo);
                    dtVouDetals = dbGtObj.getVouDetails(vouNo);

                    this.lblPolicyNo2.Text = dtVouDetals.Rows[0][0].ToString();
                    this.lblInsuredName2.Text = dtVouDetals.Rows[0][12].ToString();
                    this.lblClaimNo2.Text = claimNo;

                    this.lblNetAmtPay2.Text = (double.Parse(dtVouDetals.Rows[0][6].ToString())).ToString("N2");
                    this.lblBankName2.Text = dtVouDetals.Rows[0][3].ToString();
                    this.lblBankBranch2.Text = dtVouDetals.Rows[0][4].ToString();
                    this.lblHeadOfAccount2.Text = dtVouDetals.Rows[0][5].ToString();
                    this.lblNICPassport2.Text = dtVouDetals.Rows[0][9].ToString();
                    this.lblNameOfPayee2.Text = dtVouDetals.Rows[0][7].ToString();
                    this.lblTel2.Text = dtVouDetals.Rows[0][10].ToString();                  
                    this.lblEpf.Text = dtVouDetals.Rows[0][16].ToString(); 
                    this.lblAnnDate.Text = dtVouDetals.Rows[0][1].ToString();
                    this.lblClmAmt2.Text = (double.Parse(dtVouDetals.Rows[0][6].ToString())).ToString("N2");
                    this.lblDate2.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    this.lblAccCod.Text = dtVouDetals.Rows[0][14].ToString();
                    this.lblAccAmount2.Text = (double.Parse(dtVouDetals.Rows[0][6].ToString())).ToString("N2");
                    this.lblDate4.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    this.lblTime.Text = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                    this.lblMachineIP.Text = Context.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    string message = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                }
            }
        }
    }
}