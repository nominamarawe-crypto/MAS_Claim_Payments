using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.IO;
using System.Configuration;
using System.Data;

namespace MAS_Claim_Payments
{
    public partial class ReportDetails : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
        private string FromDate;
        private string ToDate;
        private string POL_NO;
        private string NIC;

        protected void Page_Load(object sender, EventArgs e)
        {
            FromDate = Request.QueryString["frmDate"].ToString();
            ToDate = Request.QueryString["toDate"].ToString();
            POL_NO = Request.QueryString["POL_NO"].ToString();
            NIC = Request.QueryString["NIC"].ToString();

            this.hdfPolNo.Value = POL_NO;
            this.hdfNIC.Value = NIC;
            this.hdfFrm.Value = FromDate;
            this.hdfTo.Value = ToDate;

            string sql = "";

            if (!hdfPolNo.Value.Equals(""))
            {
                DataTable dataTable1 = new DataTable();
                con.Open();

                sql = "SELECT NUM,POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME, CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,DATE_OF_CLAIM,SBU,nvl(Status,'Claim Entered') status , CHQNO, CHQDATE, Payment_type,Relashionship,claimant_name,Amount from ( " +
                    "SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    "'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU,Status," +
                    "CHQNO,to_char(CHQDATE,'YYYY-MM-DD') CHQDATE,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type,Relashionship,claimant_name,Amount" +
                    " From SLIC_CHP.VOU_DETAILS_MAS A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A. NIC=C.NIC" +
                    " where A.pol_no='" + POL_NO + "' AND A.EPF=C.EPF union all " +
                    " SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU,vou_Status status, " +
                    "null CHQNO,null CHQDATE ,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type," +
                    " Relashionship,claimant_name,Amount From SLIC_CHP.VOU_DETAILS_MAS A  Join slic_chp.group_Master C on A. NIC = C.NIC " +
                    "and(VOU_STATUS = 'Vou.Created' or VOU_STATUS = 'Vou.Printed' or vou_status is null) and A.pol_no='" + POL_NO + "' AND A.EPF = C.EPF) order by CLAIM_NO";

                OracleCommand cmd = new OracleCommand(sql, con);
                {
                    OracleDataReader reader = cmd.ExecuteReader();
                    {
                        dataTable1.Load(reader);
                    }
                    con.Close();
                }
                GridView2.DataSource = dataTable1;
                GridView2.DataBind();
            }
            else if (!hdfNIC.Value.Equals(""))
            {
                con.Open();
                DataTable dataTable = new DataTable();
                sql = "SELECT NUM,POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME, CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,DATE_OF_CLAIM,SBU,nvl(Status,'Claim Entered') status , CHQNO, CHQDATE, Payment_type,Relashionship,claimant_name,Amount from ( " +
                    "SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis'," +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU," +
                    "Status,CHQNO,to_char(CHQDATE,'YYYY-MM-DD') CHQDATE,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type,Relashionship,claimant_name,Amount " +
                    "From SLIC_CHP.VOU_DETAILS_MAS   A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A. NIC=C.NIC where A.NIC='" + hdfNIC.Value + "' AND A.EPF=C.EPF " +
                    " union all " +
                    " SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU,vou_Status status, " +
                    "null CHQNO,null CHQDATE ,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type," +
                    " Relashionship,claimant_name,Amount From SLIC_CHP.VOU_DETAILS_MAS A  Join slic_chp.group_Master C on A. NIC = C.NIC " +
                    "and(VOU_STATUS = 'Vou.Created' or VOU_STATUS = 'Vou.Printed' or vou_status is null) and A.NIC='" + hdfNIC.Value + "' AND A.EPF = C.EPF) order by CLAIM_NO";
                OracleCommand cmd = new OracleCommand(sql, con);
                {
                    OracleDataReader reader1 = cmd.ExecuteReader();
                    {
                        dataTable.Load(reader1);
                    }
                    con.Close();
                }

                GridView2.DataSource = dataTable;
                GridView2.DataBind();

            }
            else if (!hdfFrm.Value.Equals("") && (!hdfTo.Value.Equals("")))
            {
                con.Open();
                DataTable dataTable2 = new DataTable();
                sql = "SELECT NUM,POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME, CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,DATE_OF_CLAIM,SBU,nvl(Status,'Claim Entered') status , CHQNO, CHQDATE, Payment_type,Relashionship,claimant_name,Amount from ( " +
                    "SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU," +
                    " Status,CHQNO,to_char(CHQDATE,'YYYY-MM-DD') CHQDATE,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type,Relashionship,claimant_name,Amount " +
                    " From SLIC_CHP.VOU_DETAILS_MAS   A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A. NIC=C.NIC where to_char(DATE_OF_CLAIM,'YYYY-MM-DD')  " +
                    " BETWEEN '" + hdfFrm.Value + "'  AND  '" + hdfTo.Value + "' AND A.EPF=C.EPF " +
                    " union all" +
                    " SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM," +
                    " SBU,vou_Status status, " +
                    "null CHQNO,null CHQDATE ,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type," +
                    " Relashionship,claimant_name,Amount From SLIC_CHP.VOU_DETAILS_MAS A  Join slic_chp.group_Master C on A. NIC = C.NIC " +
                    "and(VOU_STATUS = 'Vou.Created' or VOU_STATUS = 'Vou.Printed' or vou_status is null) and to_char(DATE_OF_CLAIM,'YYYY-MM-DD')  BETWEEN '" + hdfFrm.Value + "'  AND  '" + hdfTo.Value + "' AND A.EPF = C.EPF) order by CLAIM_NO";
                OracleCommand cmd = new OracleCommand(sql, con);
                {
                    OracleDataReader reader = cmd.ExecuteReader();
                    {
                        dataTable2.Load(reader);
                    }
                    con.Close();
                }
                GridView2.DataSource = dataTable2;
                GridView2.DataBind();
            }
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=ExportGridData.xls");
            //Response.ContentType = "File/Data.xls";
            //StringWriter StringWriter = new System.IO.StringWriter();
            //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            //Form.RenderControl(HtmlTextWriter);
            //Response.Write(StringWriter.ToString());
            //Response.End();

            Response.Clear();
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            Page.EnableViewState = false;
            Response.AddHeader("Content-Disposition", "attachment; filename=MAS Claims report.xls");

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            //////////////////////

            string sql = "";
            if (!hdfPolNo.Value.Equals(""))
            {
                DataTable dataTable1 = new DataTable();
                con.Open();

                sql = "SELECT NUM,POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME, CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,DATE_OF_CLAIM,SBU,nvl(Status,'Claim Entered') status , CHQNO, CHQDATE, Payment_type,Relashionship,claimant_name,Amount from ( " +
                    "SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    "'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU,Status," +
                    "CHQNO,to_char(CHQDATE,'YYYY-MM-DD') CHQDATE,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type,Relashionship,claimant_name,Amount" +
                    " From SLIC_CHP.VOU_DETAILS_MAS A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A. NIC=C.NIC" +
                    " where A.pol_no='" + POL_NO + "' AND A.EPF=C.EPF union all " +
                    " SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU,vou_Status status, " +
                    "null CHQNO,null CHQDATE ,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type," +
                    " Relashionship,claimant_name,Amount From SLIC_CHP.VOU_DETAILS_MAS A  Join slic_chp.group_Master C on A. NIC = C.NIC " +
                    "and(VOU_STATUS = 'Vou.Created' or VOU_STATUS = 'Vou.Printed' or vou_status is null) and A.pol_no='" + POL_NO + "' AND A.EPF = C.EPF) order by CLAIM_NO";

                OracleCommand cmd = new OracleCommand(sql, con);
                {
                    OracleDataReader reader = cmd.ExecuteReader();
                    {
                        dataTable1.Load(reader);
                    }
                    con.Close();
                }
                GridView2.DataSource = dataTable1;
                GridView2.DataBind();
            }
            else if (!hdfNIC.Value.Equals(""))
            {
                con.Open();
                DataTable dataTable = new DataTable();
                sql = "SELECT NUM,POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME, CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,DATE_OF_CLAIM,SBU,nvl(Status,'Claim Entered') status , CHQNO, CHQDATE, Payment_type,Relashionship,claimant_name,Amount from ( " +
                    "SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis'," +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU," +
                    "Status,CHQNO,to_char(CHQDATE,'YYYY-MM-DD') CHQDATE,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type,Relashionship,claimant_name,Amount " +
                    "From SLIC_CHP.VOU_DETAILS_MAS   A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A. NIC=C.NIC where A.NIC='" + hdfNIC.Value + "' AND A.EPF=C.EPF " +
                    " union all " +
                    " SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU,vou_Status status, " +
                    "null CHQNO,null CHQDATE ,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type," +
                    " Relashionship,claimant_name,Amount From SLIC_CHP.VOU_DETAILS_MAS A  Join slic_chp.group_Master C on A. NIC = C.NIC " +
                    "and(VOU_STATUS = 'Vou.Created' or VOU_STATUS = 'Vou.Printed' or vou_status is null) and A.NIC='" + hdfNIC.Value + "' AND A.EPF = C.EPF) order by CLAIM_NO";
                OracleCommand cmd = new OracleCommand(sql, con);
                {
                    OracleDataReader reader1 = cmd.ExecuteReader();
                    {
                        dataTable.Load(reader1);
                    }
                    con.Close();
                }

                GridView2.DataSource = dataTable;
                GridView2.DataBind();

            }
            else if (!hdfFrm.Value.Equals("") && (!hdfTo.Value.Equals("")))
            {
                con.Open();
                DataTable dataTable2 = new DataTable();
                sql = "SELECT NUM,POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME, CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,DATE_OF_CLAIM,SBU,nvl(Status,'Claim Entered') status , CHQNO, CHQDATE, Payment_type,Relashionship,claimant_name,Amount from ( " +
                    "SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM,SBU," +
                    " Status,CHQNO,to_char(CHQDATE,'YYYY-MM-DD') CHQDATE,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type,Relashionship,claimant_name,Amount " +
                    " From SLIC_CHP.VOU_DETAILS_MAS   A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A. NIC=C.NIC where to_char(DATE_OF_CLAIM,'YYYY-MM-DD')  " +
                    " BETWEEN '" + hdfFrm.Value + "'  AND  '" + hdfTo.Value + "' AND A.EPF=C.EPF " +
                    " union all" +
                    " SELECT 1 NUM, POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , DECODE(CLAIM_TYPE, 'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun', 'Funeral Expenses', 'ED', 'Ex-gratia Death', 'EDis', " +
                    " 'Exgratia Disability',   'EHos', 'Ex-gratia Hospital Cash', 'EFun', 'Ex-gratia Funeral Expenses') CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,ACC_NO,to_char(DATE_OF_CLAIM,'YYYY-MM-DD') DATE_OF_CLAIM," +
                    " SBU,vou_Status status, " +
                    "null CHQNO,null CHQDATE ,DECODE(Payment_type, 'N', 'Normal', 'E', 'Ex-gratia') Payment_type," +
                    " Relashionship,claimant_name,Amount From SLIC_CHP.VOU_DETAILS_MAS A  Join slic_chp.group_Master C on A. NIC = C.NIC " +
                    "and(VOU_STATUS = 'Vou.Created' or VOU_STATUS = 'Vou.Printed' or vou_status is null) and to_char(DATE_OF_CLAIM,'YYYY-MM-DD')  BETWEEN '" + hdfFrm.Value + "'  AND  '" + hdfTo.Value + "' AND A.EPF = C.EPF) order by CLAIM_NO";
                OracleCommand cmd = new OracleCommand(sql, con);
                {
                    OracleDataReader reader = cmd.ExecuteReader();
                    {
                        dataTable2.Load(reader);
                    }
                    con.Close();
                }
                GridView2.DataSource = dataTable2;
                GridView2.DataBind();
            }



            //////////////////////


            //this.createTable(int.Parse(this.hdfFromDate.Value), int.Parse(this.hdfToDate.Value));
            //this.tblValuationReport.Font.Size = new FontUnit(9.0);

            //hw.Write("<br>");
            //hw.Write(this.lblTopic.Text);
            //hw.Write("<br>");
            //hw.Write("<br>");
            //hw.Write(this.lblTopic2.Text);
            //hw.Write("<br>");
            //hw.Write("<br>");

            this.GridView2.RenderControl(hw);

            Response.Write(tw.ToString());
            Response.End();


        }

        protected void GridView2_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClaimReport.aspx");
        }
    }
}