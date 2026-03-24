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

public partial class intimdetInq001 : System.Web.UI.Page
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
                string sql = "select DPOLNO as POLICY_NO, DMOS AS LIFE_TYPE, DCLM AS CLAIM_NO, DINFODAT AS INTIMATION_DATE, DPOLST AS POLICY_STATUS, DNOD AS NAME_OF_DECEASED, DDTOFDTH AS DATE_OF_DEATH, DMOINF AS METHOD_OF_INTIMATION, DIID AS INFORMERS_ID, DINAME INFORMERS_NAME,"+
                    "DIAD1 AS INFROMERS_ADDRESS1, DIAD2 AS INFROMERS_ADDRESS2, DIAD3 AS INFROMERS_ADDRESS3, DIAD4 AS INFROMERS_ADDRESS4, DITEL AS INFORMERS_TEL_NO, DRECBRN AS INTIMATION_RECIEVING_BRANCH, DENTEPF AS ENTERED_EPF, DENTTIM ENTERED_TIME, DCONFDAT AS CONFIRMATION_DATE," +
                    "DCONFEPF AS CONFIRMING_EPF, DCONFBR AS CONFIRMING_BRANCH, DCONFTIME AS CONFIRMING_TIME, DINFOREL AS INFORMERS_RELATIONSHIP, " +
                    "DCOF AS CIVIL_OR_FORCES, DPOLBRN AS POLICY_BRANCH from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS = '" + MOF + "' ";

                OracleDataAdapter dat = new OracleDataAdapter(sql, dm.oraConn);
                dat.Fill(dt);
                DetailsView1.DataSource = dt;
                DetailsView1.DataBind();   

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
