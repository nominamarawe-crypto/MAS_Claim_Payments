using System;
using System.Collections.Generic; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.IO;
using System.Drawing;

public partial class DeathClaimReport01 : System.Web.UI.Page
{
    private int fromdate, todate, policyno;
    private string criteria, searchby;
    private DataTable dt;
    DataManager dm;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            string sql1;
            string Sql2;
            searchby = this.PreviousPage.Searchby;
            if (searchby == "D")
            {
                fromdate = this.PreviousPage.Fromdate;
                todate = this.PreviousPage.Todate;
                //sql1 = "DECISION_DATE >= TO_DATE(" + fromdate + ",'YYYYMMDD') AND  DECISION_DATE <=TO_DATE(" + todate + ",'YYYYMMDD') ";
                //sql1 = "DECISION_DATE >= TO_DATE(" + fromdate + ",'YYYYMMDD') AND  DECISION_DATE <=TO_DATE(" + todate + ",'YYYYMMDD') and (a.drpolno in (select b.POLICYNO from  LPHS.DTH_REPUDIATION@live b inner join LPHS.EXGRACIA_AMTS@live c on b.POLICYNO=c.DPOLNUM and b.life_type=trim(c.mof)) or a.drpolno not in (select d.policyno from LPHS.DTH_REPUDIATION@live d where d.POLICYNO=A.DRPOLNO and d.LIFE_TYPE=A.DRMOS)) order by decision_date asc";
                sql1 = "DECISION_DATE >= TO_DATE(" + fromdate + ",'YYYYMMDD') AND  DECISION_DATE <=TO_DATE(" + todate + ",'YYYYMMDD') and a.MEMOAPRV is not null and (a.COMPLETED is null or a.COMPLETED = 'Y') order by decision_date asc";
            }
            else {
                policyno = this.PreviousPage.Policyno;
                //sql1 = " (a.drpolno in (select b.POLICYNO from  LPHS.DTH_REPUDIATION@live b inner join LPHS.EXGRACIA_AMTS@live c on b.POLICYNO=c.DPOLNUM and b.life_type=trim(c.mof)) or a.drpolno not in (select d.policyno from LPHS.DTH_REPUDIATION@live d where d.POLICYNO=A.DRPOLNO and d.LIFE_TYPE=A.DRMOS)) and a.drpolno = " + policyno;
                sql1 = " (a.COMPLETED is null or a.COMPLETED = 'Y') and a.MEMOAPRV is not null and a.drpolno = " + policyno;
            }

            criteria = this.PreviousPage.Criteria;

            //if (criteria == "D1") 
            //{
            //    Sql2 = " and  TO_DATE(APRVDATE,'YYYYMMDD') - DECISION_DATE > 0 order by decision_date asc";
            //}
            //else {
            //    Sql2 = " and TO_DATE(DISTN_AUTDATE,'YYYYMMDD') - DECISION_DATE > 0 order by decision_date asc";
            //}



            //string selQuery = "SELECT DRPOLNO ,DRCLMNO ,ADB_DECISION_DATE, MEMO_APPROVE_DATE,(case when DECISION_DATE is null then null else DECISION_DATE end ) as DECISION_DATE, " +
            //                  "(case when APRVDATE is null then null else TO_DATE(APRVDATE,'YYYYMMDD') end)  as APRVDATE, " +
            //                  "(case when DISTN_AUTDATE is null then null else TO_DATE(DISTN_AUTDATE,'YYYYMMDD') end) as DISTN_AUTDATE, " +
            //                  "(case when APRVDATE is null then 0 else TO_DATE(APRVDATE,'YYYYMMDD') - DECISION_DATE end)  as D1, " +
            //                  "(case when DISTN_AUTDATE is null then 0 else TO_DATE(DISTN_AUTDATE,'YYYYMMDD')- DECISION_DATE end)  as D2, " +
            //                  "(case when MEMO_APPROVE_DATE is null then 0 else round(MEMO_APPROVE_DATE - ADB_DECISION_DATE) end)  as D3 " +
            //                  "from LPHS.DTHREF a "+
            //                  "left join LPHS.DTH_ADBPAYMENTS b on b.POLICY_NO=a.DRPOLNO and b.MOS = a.DRMOS and b.CLAIM_NO=a.DRCLMNO " +
            //" where " + sql1 + "";

            string selQuery = "SELECT DRPOLNO ,DRCLMNO ,ADB_DECISION_DATE, MEMO_APPROVE_DATE,(case when DECISION_DATE is null then null else DECISION_DATE end ) as DECISION_DATE, " +
                              "(case when APRVDATE is null then null else TO_DATE(APRVDATE,'YYYYMMDD') end)  as APRVDATE, " +
                              "(case when DISTN_AUTDATE is null then null else TO_DATE(DISTN_AUTDATE,'YYYYMMDD') end) as DISTN_AUTDATE, " +
                              "(case when APRVDATE is null then 0 else lphs.num_business_days(DECISION_DATE,TO_DATE(APRVDATE,'YYYYMMDD')) end) as D1, " +
                              "(case when DISTN_AUTDATE is null then 0 else lphs.num_business_days(DECISION_DATE,TO_DATE(DISTN_AUTDATE,'YYYYMMDD')) end)  as D2, " +
                              "(case when MEMO_APPROVE_DATE is null then 0 else lphs.num_business_days(ADB_DECISION_DATE,MEMO_APPROVE_DATE)END) as D3 " +
                              "from LPHS.DTHREF a " +
                              "left join LPHS.DTH_ADBPAYMENTS b on b.POLICY_NO=a.DRPOLNO and b.MOS = a.DRMOS and b.CLAIM_NO=a.DRCLMNO " +
            " where " + sql1 + "";


            dm = new DataManager();
            dt = new DataTable();
            OracleDataAdapter dat = new OracleDataAdapter(selQuery, dm.oraConn);
            dat.Fill(dt);
            GridView1.DataSource = dt;
         
            if (criteria == "D2")
            {
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[5].Visible = false;



            }
            else if(criteria=="D3")
            {
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
            }
            else
            {

                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[5].Visible = false;
            }
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {

                btnPTint.Enabled = false;
                BtnExcell.Enabled = false;
                lblerror.Text = " No record found for this scenario";
            }
            else 
            { 
               lblerror.Text = "";
            }

            
        } 
        }
    protected void  btnPTint_Click(object sender, EventArgs e)
{
    btnExit.Visible = false;
    btnPTint.Visible = false;
    BtnExcell.Visible = false;
}

   
    public int Policyno
    {
        get { return policyno; }
        set { policyno = value; }
    }
    
    public DataTable Dt {
        get { return dt; }
        set { dt = value; }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void BtnExcell_Click(object sender, EventArgs e)
    {
       

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView1.AllowPaging = false;
            // this.BindGrid();

            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}
