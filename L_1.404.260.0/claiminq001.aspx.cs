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

public partial class claiminq001 : System.Web.UI.Page
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
                string sql = "select DRPOLNO as POLICY_NO, DRMOS AS LIFE_TYPE, DRCLMNO AS CLAIM_NO, DRAGEADMIT AS AGE_ADMIT, DRRINSYN AS REINSURANCE, DRREVIVALS AS REVIVALS, DRASSIGNEENOM AS ASSIGNEE_NOMINEE," +
                    "DRVESTEDBON AS VESTED_BONUS, DRINTERIMBON AS INTERIM_BONUS, DRBONSURRAMT AS BONUS_SURRENDER_AMT, DRBONSURRYR AS BONUS_SURRENDER_YEAR, DRACCBF AS ADB_COVER_AMOUNT, DRSWARNAJAYA AS SJ_COVER_AMT, DRFUNERALEXP AS FE_COVER_AMT, DRFPU AS FPU_COVER_AMT, " +
                    "DRDEPOSITS AS DEPOSITS, DROTHERADITNS AS OTHER_ADDITIONS, DEOTHERDEDUCT AS OTHER_DEDUCTIONS, DRGROSSCLM AS GROSS_CLAIM, DRDEFPREM AS DEFAULT_PREMIUM, DRINT AS DEFUALT_INTEREST, DRLONCAP AS LOAN_CAPITAL, DRLOANINT AS LOAN_INTEREST," +
                    "DRNETCLM AS NET_CALIM, DRAGT AS AGENT_CODE, DRNETSURR AS NET_SURRENDER_AMT, DDECISION AS DECISION, DLOW AS LOW, DENTDT AS CONFIRMED_DATE, DENTEPF AS CONFIRMED_EPF, ADBPAYAMT AS ADB_PAY_AMT," +
                    "SJPAYAMT AS SJ_PAY_AMT, FPUPAYAMT AS FPU_PAY_AMT, FEPAYAMT AS FE_PAY_AMT, CAUSEOFDEATHSTR AS CAUSE_OF_DEATH, SMASS_PVAL AS SUMASSURED_OR_PAID_UP_VAL, REFUND_OF_PREMS AS REFUND_OF_PREMIUMS, AMTOUT AS OUTSTANDING_AMT, MEMOAPRV AS MEMO_APPROVED," +
                    "APRVDATE AS APPROVED_DATE, APRVEPF AS APPROVED_EPF, PAYEE, TOTPAYAMT AS TOTAL_PAYMENT, COMPLETED, PAYAUTDT AS PAYMENT_COMPLETED_DATE, PAYAUTEPF AS PAYMENT_COMPLETED_EPF, FE_EARLYPAY, ADB_LATEPAY," +
                    "DISTN_AUT AS DISTRIBUTION_AUTHORIZED_FOR, DISTN_AUTDATE AS DISTRIBUTION_AUTHORIZED_DATE, DISTN_AUTEPF AS DISTRIBUTION_AUTHORIZED_EPF, EXGRACIA_AMOUNT, AGE_STATUS, AGE_AMT, INTBONSTYR AS INTERIM_BONUS_STARTING_YEAR, " +
                    "MINUTES, BRANCH from LPHS.DTHREF where drpolno = " + polno + " and drmos = '" + MOF + "'";

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
