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

public partial class DeathRegisterWithoutRange : System.Web.UI.Page
{

    //string query = "   select  DCONFDAT   as confirmed_date ,  DRCLMNO as Claim_No, DRPOLNO as Policy_No , DNOD  as Name, address " +    //--4  
    //                   " , COMMENCEMENT_DATE  , PHTBL as table_NO  " +            //--7 "
    //                   " , PHTRM as term, PHSUM as SumAssured , ADBPAYAMT as adb ,FPUPAYAMT as fpu ,SJPAYAMT as SJ , FEPAYAMT AS FE " +            //--13
    //                   " , DINFODAT AS INTIMATION_DATE  ,  DDTOFDTH AS date_of_death , CAUSEOFDEATHSTR as cause_of_death   " +                     //--17
    //                   " , DRVESTEDBON as vested_bonus ,  DRINTERIMBON as interim_bonus ,  DRDEPOSITS as DEPOSITS , DRGROSSCLM as gross_claim " + //--21 
    //                   " , DRDEFPREM as Default_premium , DRINT  as Default_Interest ,      POL_COMPLETED AS POLICY_COMPLETED,   DRLONCAP as Loan_Capital  , DRLOANINT as loan_interest  " +       //-- 26 
    //                   " , DEOTHERDEDUCT as other_deduction, DRNETCLM as net_claim , DRADMITNO as admit_no, PAYAUTDT as paid_date,drpaidno as Paid_No " +    //--31
    //                   " , REPU_DATE as Repudiated_Date , REPU_REASON as Repudiated_reason " +                 //--33
    //                   " , Civil_status " +                             //--34
    //                   " , completed AS IS_COMPLETED,STATUS,isexgracia as IS_EXGRACIA  " +               // --35
    //                   "   FROM  LPHS.dth_register    ORDER BY dconfdat ASC,DRCLMNO ASC   ";

    string query = "   select  DCONFDAT   as confirmed_date ,  DRCLMNO as Claim_No, DRPOLNO as Policy_No , DNOD  as Name, address " +    //--4  
                       " , COMMENCEMENT_DATE  , PHTBL as table_NO  " +            //--7 "
                       " , PHTRM as term, PHSUM as SumAssured , ADBPAYAMT as adb ,FPUPAYAMT as fpu ,SJPAYAMT as SJ , FEPAYAMT AS FE " +            //--13
                       " , DINFODAT AS INTIMATION_DATE  ,  DDTOFDTH AS date_of_death , CAUSEOFDEATHSTR as cause_of_death   " +                     //--17
                       " , DRVESTEDBON as vested_bonus ,  DRINTERIMBON as interim_bonus ,  DRDEPOSITS as DEPOSITS , DRGROSSCLM as gross_claim " + //--21 
                       " , DRDEFPREM as Default_premium , DRINT  as Default_Interest ,        DRLONCAP as Loan_Capital  , DRLOANINT as loan_interest  " +       //-- 26 
                       " , DEOTHERDEDUCT as other_deduction, DRNETCLM as net_claim , DRADMITNO as admit_no, PAYAUTDT as paid_date,drpaidno as Paid_No " +    //--31
                       " , REPU_DATE as Repudiated_Date , REPU_REASON as Repudiated_reason " +                 //--33
                       " , Civil_status " +                             //--34
                       " , completed AS IS_COMPLETED,STATUS,isexgracia as IS_EXGRACIA,repu_seq as REPUTED_SEQ  " +               // --35
                       "   FROM  LPHS.dth_register    ORDER BY dconfdat ASC,DRCLMNO ASC   ";
    DataSet ds = new DataSet();
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateDataSet();
        BindGridView();
    }
    protected void GridViewDeathRegisterView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }


    protected void PopulateDataSet()
    {
        try
        {
            dm = new DataManager();
            dm.readSql(query);
            ds = dm.getrow(query);

        }
        catch (Exception ex)
        {
            //lblMassage.Text = "Error Occured During Grid View Binding" ;
            throw ex;
        }
    }

    public void BindGridView()
    {
        GridViewDeathRegisterView.DataSource = ds;
        GridViewDeathRegisterView.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblMassage.Text = "No Data Found";
        }
        else
        {
            lblMassage.Text = "";
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataGrid dg = new DataGrid();
        dg.DataSource = ds;
        dg.DataBind();




        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Response.AddHeader("content-disposition", "attachment; filename=" + "Report.xls");
        Response.ClearContent();

        Response.AddHeader("content-disposition", "attachment");

        dg.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

        dg = null;
        dg.Dispose();
    }
}
