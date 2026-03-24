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

public partial class RefundMiniDthChld : System.Web.UI.Page
{
    private long POlno;
    private string MOF;
    private string DNOD;
    private long claimno;
    private int table;
    DataManager dm;
    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        if (PreviousPage != null)
        {
            POlno = PreviousPage.Polno;
            litpolno.Text = POlno.ToString();
            MOF = PreviousPage.mOF;
        }
        polMasRead policymaster = new polMasRead(int.Parse(POlno.ToString()), dm);
        table = policymaster.TBL;

        if (table == 34 || table == 38 || table == 39 || table == 46 || table == 49)
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
        }
        else
        {
            Response.Redirect("dthPay002.aspx?err=true&pol=" + POlno + "&mof=" + MOF + "");
        }
    }
}
