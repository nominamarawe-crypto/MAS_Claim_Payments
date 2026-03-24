using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class VoucherReprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {

                }
                else
                {
                    string message = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                }
            }
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
                string claimNum = this.gvIndividualVous.Rows[index].Cells[1].Text;
                Response.Redirect("VoucherReprint2.aspx?ClaimNo=" + claimNum);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}