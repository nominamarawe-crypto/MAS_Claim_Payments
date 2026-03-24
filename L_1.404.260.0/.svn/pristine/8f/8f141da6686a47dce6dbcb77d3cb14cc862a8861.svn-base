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

public partial class DeathRegisterSelect : System.Web.UI.Page
{
    //private long fromDate;
    //private long toDate;
    //string query = "   select  DCONFDAT   as confirmed_date ,  DRCLMNO as Claim_No, DRPOLNO as Policy_No , DNOD  as Name, (PNAD1 ||  PNAD2 ||   PNAD3 ||   PNAD4) as address " +    //--4  
    //                    " , to_CHAR(  to_date(  PHCOM  , 'yyyy/mm/dd'  )  , 'yyyy/mm/dd') as COMMENCEMENT_DATE  , PHTBL as table_NO  " +            //--7 "
    //                    " , PHTRM as term, PHSUM as SumAssured , ADBPAYAMT as adb ,FPUPAYAMT as fpu ,SJPAYAMT as SJ , FEPAYAMT AS FE " +            //--13
    //                    " , DINFODAT AS INTIMATION_DATE  ,  DDTOFDTH AS date_of_death , CAUSEOFDEATHSTR as cause_of_death   " +                     //--17
    //                    " , DRVESTEDBON as vested_bonus ,  DRINTERIMBON as interim_bonus ,  DRDEPOSITS as DEPOSITS , DRGROSSCLM as gross_claim " + //--21 
    //                    " , DRDEFPREM as Default_premium , DRINT  as Default_Interest ,      POL_COMPLETED AS POLICY_COMPLETED,   DRLONCAP as Loan_Capital  , DRLOANINT as loan_interest  " +       //-- 26 
    //                    " , DEOTHERDEDUCT as other_deduction, DRNETCLM as net_claim , DRADMITNO as admit_no, DRPAIDNO as paid_no , PAYAUTDT as paid_date " +    //--31
    //                    " , REPU_DATE as Repudiated_Date , REPU_REASON as Repudiated_reason " +                 //--33
    //                    " , DECODE(DCOF,'A','ARMY','C','CIVIL','N','NAVY','G','AIR FORCE','','NOT DEFINE',DCOF) as Civil_status " +                             //--34
    //                    " , completed AS IS_COMPLETED  " +               // --35
    //                    "   FROM  LPHS.dth_register    ";
    //string subQuary = "";
    //bool isValidate = false;
    //DataSet ds = new DataSet();
    //DataManager dm = new DataManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.IsPostBack)
        //{

        //}
        //else
        //{
        //    //Panel1.Visible = true;
        //    //SetSubQuary();
        //    ////if (isValidate == true)
        //    ////{
        //    //    query = query + subQuary;
        //    //    BindDataGridView();
        //    ////}
        //}
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string type = "";
        type = ddlType.SelectedItem.Value.ToString();
        if (type == "ALL")
        {
            txtFromDate.Enabled = true;
            txtToDate.Enabled = true;
        }
        else if (type == "COMPLETED")
        {
            txtFromDate.Enabled = true;
            txtToDate.Enabled = true;
        }
        else if (type == "ALLWITHOUT")
        {
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         string type = "";
        type = ddlType.SelectedItem.Value.ToString();
        if (type == "ALL")
        {
           
            if (ValidateDateRange())
            {
                Response.Redirect("DeathRegisterAll.aspx?fromdate=" + txtFromDate.Text.ToString().Trim() + "&todate=" + txtToDate.Text.ToString().Trim() + "  ");
            }
        }
        else if (type == "COMPLETED")
        { 
            if(ValidateDateRange())
            {
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                Response.Redirect("DeathRegisterCompleted.aspx?fromdate="+ txtFromDate.Text.ToString().Trim() + "&todate="+ txtToDate.Text.ToString().Trim() +"  "); 
            }
        }
        else if (type == "ALLWITHOUT")
        {
            Server.Transfer("DeathRegisterWithoutRange.aspx");
        }
    }

    protected bool ValidateDateRange()
    {
        if (this.txtFromDate.Text.ToString().Length ==0  || this.txtToDate.Text.ToString().Length == 0)
        {
            lblMassage.Text = " From Date  or To Date required";
            return false;
        }
        else
        {
            int fromDate = int.Parse(this.txtFromDate.Text.ToString());
            int toDate = int.Parse(this.txtToDate.Text.ToString());
            if (fromDate > toDate)
            {
                lblMassage.Text = " From Date  should be  greater than To Date ";
                return false;
            }
            else
            {
                return true;
            }


        }
    }

    //protected void SetSubQuary()
    //{        
    //    string type ="";
    //    type = ddlType.SelectedItem.Value.ToString();
    //    if(type == "ALL")
    //    {
    //        isValidate = true;
    //        subQuary = "  ORDER BY DRCLMNO  ";
    //    }
    //    else if (type == "COMPLETED")
    //    {
    //       // ValidateDateRange();
    //        subQuary = " where   (dconfdat between " + fromDate + " and  " + toDate + ") and (completed = 'Y' or completed = 'R' ) ORDER BY DRCLMNO ";
    //    }
    //    else if (type == "OUTSTANDING")
    //    {
    //        //ValidateDateRange();
    //        subQuary = " where  (dconfdat between " + fromDate + " and  " + toDate + ") and (completed != 'Y' or completed != 'R' ) ORDER BY DRCLMNO  ";
    //    }
    //}

    //protected void ValidateDateRange()
    //{       
    //    if (this.txtFromDate.Text.Equals(null) || this.txtToDate.Text.Equals(null))
    //    {
    //        lblMassage.Text = " FromDate  or ToDate required";
    //    }
    //    else
    //    {
    //        try
    //        {
    //            //DateTime dateTime = new DateTime(fromDate.ToString().Substring(0,4), fromDate.ToString().Substring(4,2), fromDate.ToString().Substring(6,2));
    //           // DateTime dateTime2 = new DateTime(toDate.ToString().Substring(0, 4), toDate.ToString().Substring(4, 2), toDate.ToString().Substring(6, 2));
    //            fromDate = long.Parse(this.txtFromDate.Text);
    //            toDate = long.Parse(this.txtToDate.Text);
    //            isValidate = true;
    //        }
    //        catch
    //        {
    //            lblMassage.Text = "Invalid FromDate or  ToDate ";
    //        }
    //    }

    //}

    //protected void BindDataGridView()
    //{
    //    try
    //    {
    //        dm.readSql(query);
    //        ds = dm.getrow(query);
    //        GridViewDeathRegisterView.DataSource = ds;
    //        GridViewDeathRegisterView.DataBind();
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            lblMassage.Text = "No Data Found";
    //        }
    //        else 
    //        {
    //            Panel1.Visible = false;
    //        }
    //    }
    //    catch(Exception  ex)
    //    {
    //        //lblMassage.Text = "Error Occured During Grid View Binding" ;
    //        throw ex;
    //    }
    //}
    //protected void GridViewDeathRegisterView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    //Panel1.Visible = false;
    //    //SetSubQuary();
        
    //    //if (isValidate == true)
    //    //{
    //    //    query = query + subQuary;
    //    //    BindDataGridView();
    //    //}
    //    //GridViewDeathRegisterView.PageIndex = e.NewPageIndex;
    //    //GridViewDeathRegisterView.DataBind();

    //    SetSubQuary();
    //    PopulateDataSet();
    //    GridViewDeathRegisterView.PageIndex = e.NewPageIndex;
    //    GridViewDeathRegisterView.DataSource = ds;
    //    GridViewDeathRegisterView.DataBind();
    //}


    //protected void PopulateDataSet()
    //{
    //    try
    //    {
    //        dm.readSql(query);
    //        ds = dm.getrow(query);            
           
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblMassage.Text = "Error Occured During Grid View Binding" ;
    //        throw ex;
    //    }
    //}

    //public void BindGridView()
    //{
    //    GridViewDeathRegisterView.DataSource = ds;
    //    GridViewDeathRegisterView.DataBind();
    //}
    
}
