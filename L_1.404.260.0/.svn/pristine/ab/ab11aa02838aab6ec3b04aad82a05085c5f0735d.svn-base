using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

public partial class RefundOfMINISIN001 : System.Web.UI.Page
{
    private long POlno;
    private string MOF;
    private string DNOD;
    private long claimno;
    private int table;
    private double netclaim;
    DataManager dm;
    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        if (PreviousPage != null)
        {
            POlno = PreviousPage.Polno;
            litpolno.Text = POlno.ToString();
            MOF = PreviousPage.mOF;
            netclaim = PreviousPage.Netclm;
            litamt.Text = netclaim.ToString("N2");
        }
        polMasRead policymaster = new polMasRead(int.Parse(POlno.ToString()), dm);
        table = policymaster.TBL;

        double netclm100 = 0;
        if (netclaim < 0) { netclm100 = 0; }
        else { netclm100 = (Math.Round(netclaim, 2) * 100); }
        if (netclm100 != 0)
        {
            string netclminwords = netclm100.ToString().Substring(0, (netclm100.ToString().Length - 2)) + "." + netclm100.ToString().Substring((netclm100.ToString().Length - 2), 2);
            readAmountFunction readamt = new readAmountFunction();
            this.litamt_inword.Text = readamt.readAmountSinhala(netclminwords, "YS% ,xld remsh,a", "Y; ");
        }
        else
        {
            this.litamt_inword.Text = "ZERO SRI LANKAN RUPEES AND ZERO CENTS ONLY";
        }

        if ((table == 34 || table == 38 || table == 39 || table == 46 || table == 49) && (MOF == "2"))
        {
            if (!Page.IsPostBack)
            {
                string dthintSelect = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + POlno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { claimno = dthintReader.GetInt64(1); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }
                this.litnamedec.Text = DNOD;
                this.litclm.Text = claimno.ToString();
            }


            string GetMainlife = "select PNSTA ||''||PNSUR as NAME from lphs.phname where PNPOL=" + POlno + "";
            if (dm.existRecored(GetMainlife) != 0)
            {
                dm.readSql(GetMainlife);
                OracleDataReader red = dm.oraComm.ExecuteReader();
                while (red.Read())
                {
                    if (!red.IsDBNull(0)) { litnameass.Text = red.GetString(0); }
                }
                red.Close();
            }
        }
        else
        {
            Response.Redirect("dthPay002.aspx?err=true&pol=" + POlno + "&mof=" + MOF + "");
        } 
    }
}
