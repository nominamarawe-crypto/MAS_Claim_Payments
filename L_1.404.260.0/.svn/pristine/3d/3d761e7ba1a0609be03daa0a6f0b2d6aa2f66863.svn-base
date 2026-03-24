using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class reqInq001 : System.Web.UI.Page
{
    private int polno;
    private string MOF;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try 
            {
                //payeeInq001 payeeInq001obj = new payeeInq001();
                //polno = payeeInq001obj.Polno;
                //MOF = payeeInq001obj.mos;

                if (Request.QueryString["polno"] != null) { polno = int.Parse(Request.QueryString["polno"]); }
                if (Request.QueryString["mos"] != null) { MOF = Request.QueryString["mos"].ToString(); }

                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblmos.Text = "Main Life"; }
                else if (MOF.Equals("S")) { this.lblmos.Text = "Spouce"; }
                else if (MOF.Equals("2")) { this.lblmos.Text = "Second Life"; }

              
                DataTable dt = new DataTable();
                string reqSel = "select b.DREQDSESCENG, a.DRSENTDT, a.DRRECDT, a.DRREMA, a.REMINDERDT, a.SECONDREQUESTYN, a.SECOND_REMINDER_DT,"+
                    " a.THIRD_REMINDER_DT from LPHS.DREQ a, lphs.dreqdesc b where a.drcovtyp = b.DREQCODE and  a.DRPOL = " + polno + " and a.DRTYP = '" + MOF + "' ";
                OracleDataAdapter dat = new OracleDataAdapter(reqSel, dm.oraConn);
                dat.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                dm.connClose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
                
        }
    }
}
