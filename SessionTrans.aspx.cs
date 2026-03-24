using MAS_Claim_Payments.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class SessionTrans : System.Web.UI.Page
    {
        private Authentication objAuthentication = new Authentication();
        private Policy objPolicy = new Policy();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["EPFNum"] = "7838";
            Session["brcode"] = "010";
            Session["UserId"] = "SEC7838";

            //Session["EPFNum"] = "6408";
            //Session["brcode"] = "010";
            //Session["UserId"] = "SEC6408";

            //for (int i = 0; i < Request.Form.Count; i++)
            //{
            //    Session[Request.Form.GetKey(i)] = Request.Form[i].ToString();
            //}

            int epf = objPolicy.EpfCode(Session["EPFNum"].ToString());
            this.Label1.Text = epf + " AAA " + Session["UserId"].ToString();
            if (objAuthentication.checkModuleAccess(Session["UserId"].ToString()) == 0)
            {
                Response.Redirect("NoAuthority.aspx");
            }
            else
            {
                Response.Redirect("Home.aspx");
            }

        }
    }
}