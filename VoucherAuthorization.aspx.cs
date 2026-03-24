using MAS_Claim_Payments.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class VoucherAuthorization : System.Web.UI.Page
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
            //this.gvIndividualVous.DataSource = this.sqlDSIndiVouchers;
            //this.gvIndividualVous.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.tbxNic.Text = "";
            this.gvIndividualVous.DataSource = null;
            this.gvIndividualVous.DataBind();
            this.lblError1.Text = "";
            this.lblErrorMsg.Text = "";
        }

        protected void gvIndividualVous_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvIndividualVous.SelectedIndex > -1)
            {
                int index = this.gvIndividualVous.SelectedIndex;
                string vouNum = this.gvIndividualVous.Rows[index].Cells[2].Text;
                Response.Redirect("VoucherAuthorization2.aspx?VouNo=" + vouNum);
            }
        }
    }
}