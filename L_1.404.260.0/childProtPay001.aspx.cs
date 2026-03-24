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

public partial class chuldProtPay001 : System.Web.UI.Page
{
    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2)
        {
            month = "0" + month;
        }
        if (day.Length < 2)
        {
            day = "0" + day;
        }

        ourDate = year + month + day;
        datetime[0] = ourDate;
        // return ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        // return y;
        return datetime;
    }

    private int polno;
    private int table;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        try 
        {
            DataTable dt = new DataTable();
            if (!Page.IsPostBack) { this.txtdue.Text = this.setDate()[0]; }

            //string protmasSel = "select POLNO, TABLE, PAY_MODE, LASTDUE, NEXTDUE, START_DATE, END_DATE, PAY_AMT, PREM, PAYMENT_COUNT, TOTAL_PYMNTS, GROSSCLM, NETCLM, MATDATE, SUMASSURED_PVAL from LCLM.CHILD_PROT_MAS ";
            string protmasSel = "select POLNO, PTABLE, LASTDUE, NEXTDUE, START_DATE, END_DATE, PAY_AMT, PAYMENT_COUNT, TOTAL_PYMNTS, MATDATE, SUMASSURED_PVAL from LCLM.CHILD_PROT_MAS " +
                " where (NEXTDUE = 0) or (NEXTDUE > 0 and NEXTDUE <= " + int.Parse(this.setDate()[0]) + ") ";           
            OracleDataAdapter dat = new OracleDataAdapter(protmasSel, dm.oraConn);
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

    protected void txtdue_TextChanged(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            DataTable dt = new DataTable();
            int duedat = int.Parse(this.txtdue.Text);
            string protmasSel = "select POLNO, PTABLE, LASTDUE, NEXTDUE, START_DATE, END_DATE, PAY_AMT, PAYMENT_COUNT, TOTAL_PYMNTS, MATDATE, SUMASSURED_PVAL from LCLM.CHILD_PROT_MAS " +
                " where (NEXTDUE = 0) or (NEXTDUE > 0 and NEXTDUE <= " + duedat + ") ";
            OracleDataAdapter dat = new OracleDataAdapter(protmasSel, dm.oraConn);
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
    protected void GridView1_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        try 
        {
            polno = int.Parse(GridView1.Rows[e.NewSelectedIndex].Cells[1].Text);
            table = int.Parse(GridView1.Rows[e.NewSelectedIndex].Cells[2].Text);
            Response.Redirect("childProtPay002.aspx?polino=" + polno.ToString() + "&table=" + table + "", false);
        
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
