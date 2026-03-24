using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class EPage : System.Web.UI.Page
    {
        private string Message;
        private string[] msgParts;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message = Request.QueryString.Get("msg");
            msgParts = Message.Split('@');

            if (msgParts.Length > 0)
                this.lblMsg1.Text = msgParts[0];
            if (msgParts.Length > 1)
                this.lblMsg2.Text = msgParts[1];
        }
    }
}