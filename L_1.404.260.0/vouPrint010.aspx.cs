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

public partial class vouPrint010 : System.Web.UI.Page
{
    private long polno;
    private string vno;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
        }
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                DataTable dt = new DataTable();
                string vounoSel = "select LSSUFFIX, LSPOLNO, LSVOUNO, LSAMT, ENTDATE from LPHS.LSUVOUCHERS where LSPOLNO = " + polno + " and (PRINTEDYN is null or PRINTEDYN <> 'N') and LSTYPE = 'S' ";
                OracleDataAdapter dat = new OracleDataAdapter(vounoSel, dm.oraConn);
                dat.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                dm.connClose();
            }
            catch (Exception ex)
            {
                dm.connClose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            polno = long.Parse(GridView1.Rows[e.NewSelectedIndex].Cells[2].Text);
            vno = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
            Response.Redirect("vouPrint002.aspx?polino=" + polno.ToString() + "&vno=" + vno + "", false);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
