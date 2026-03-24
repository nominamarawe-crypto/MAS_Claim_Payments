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

public partial class leganHieresDelete : System.Web.UI.Page
{
    DataManager Database;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        if (!IsPostBack)
        {
            Database = new DataManager();

            string sql = "SELECT LHPOLNO, LHMOF, LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHREMARKS,  " +
                         "  LHSHARE, LHAMOUNT FROM LPHS.LEGAL_HIRES WHERE " +
                         " (LHPOLNO =" + Convert.ToInt32(Request.QueryString["polno"]) + ") AND (LHMOF = '"
                         + Convert.ToString(Request.QueryString["theMof"]) + "')AND (VOUSTA is  null OR ADBVOUSTA is null) ORDER BY LHHNO";

            OracleDataAdapter dat = new OracleDataAdapter(sql, Database.oraConn);
            dat.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Database.connClose();
        }
    }


    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        DataTable dt = new DataTable();
        Database = new DataManager();
        Database.begintransaction();

        string delsql = "DELETE FROM LPHS.LEGAL_HIRES WHERE (LHPOLNO = " + Convert.ToInt32(Request.QueryString["polno"])
                        + ") AND (LHMOF = '" + Convert.ToString(Request.QueryString["theMof"])
                        + "') AND ((VOUSTA IS NULL)  OR (ADBVOUSTA IS NULL)) AND (LHHNO = "
                        + Convert.ToInt32(GridView1.Rows[e.NewSelectedIndex].Cells[3].Text.Trim()) + ")";

        Database.insertRecords(delsql);
        Database.commit();

        string sql = "SELECT LHPOLNO, LHMOF, LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHREMARKS, " +
                         " LHSHARE, LHAMOUNT FROM LPHS.LEGAL_HIRES WHERE " +
                         " (LHPOLNO =" + Convert.ToInt32(Request.QueryString["polno"]) + ") AND (LHMOF = '"
                         + Convert.ToString(Request.QueryString["theMof"]) + "')AND (VOUSTA is  null OR ADBVOUSTA is null) ORDER BY LHHNO";

        OracleDataAdapter dat = new OracleDataAdapter(sql, Database.oraConn);
        dat.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Database.connClose();
    }
}
