using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Adapters;
using System.Data;
using MAS_Claim_Payments.App_Code;
using System.Drawing;
using System.Web.Services.Description;
using System.Configuration;
using System.Data.OracleClient;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace MAS_Claim_Payments
{
    public partial class ClaimReport : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
        private string POL_NO;
        private string NIC;
        private string Date_OF_Claim;
        private string frmD;
        private string frmT;
        private int frmDate;
        private int toDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlHistory.SelectedValue = "1";

                tbxPolNo.Enabled = true;
                tbxNIC.Enabled = false;
                tbxFromDate.Enabled = false;
                tbxToDate.Enabled = false;
            }
        }        

        protected void ddlHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxPolNo.Text = "";
            tbxNIC.Text = "";
            tbxFromDate.Text = "";
            tbxToDate.Text = "";

            if (ddlHistory.SelectedValue == "1")
            {
                tbxPolNo.Enabled = true;
                tbxToDate.Enabled = false;
                tbxFromDate.Enabled = false;
                tbxNIC.Enabled = false;
            }
            else if (ddlHistory.SelectedValue == "2")
            {
                tbxPolNo.Enabled = false;
                tbxToDate.Enabled = false;
                tbxFromDate.Enabled = false;
                tbxNIC.Enabled = true;

            }
            else if (ddlHistory.SelectedValue == "3")
            {
                tbxPolNo.Enabled = false;
                tbxToDate.Enabled = true;
                tbxFromDate.Enabled = true;
                tbxNIC.Enabled = false;
            }
            else
            {
                tbxPolNo.Enabled = false;
                tbxToDate.Enabled = false;
                tbxFromDate.Enabled = false;
                tbxNIC.Enabled = false;
            }     

        }

        protected void tbxToDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmitMain_Click(object sender, EventArgs e)
        {
            string Pol_No = tbxPolNo.Text;
            string NIC = tbxNIC.Text;
            string FromDate = tbxFromDate.Text;
            string ToDate = tbxToDate.Text;

            this.lblMessage.Text = "";

            if (ddlHistory.SelectedItem.Value.Equals("1"))
            {       

                if (!tbxPolNo.Text.Equals(""))
                {
                    con.Open();
                    string cmdtext1 = "SELECT * from SLIC_CHP.VOU_DETAILS_MAS WHERE  POL_NO = '" + tbxPolNo.Text + "'";

                    OracleCommand cmdData = new OracleCommand(cmdtext1, con);
                    OracleDataReader myReader = cmdData.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            tbxPolNo.Text = myReader["POL_NO"].ToString();
                        }
                        Response.Redirect("ClaimDetailesReport.aspx?POL_NO=" + tbxPolNo.Text + "&frmDate=&toDate=&NIC=");
                        //Response.Redirect("ReportDetails.aspx?POL_NO=" + tbxPolNo.Text + "&frmDate=&toDate=&NIC=");

                    }
                    else
                    {
                        lblMessage.Text = "Check the Policy No again";
                        con.Close();                        
                    }
                }
                else
                {
                    lblMessage.Text = "Please enter policy no";
                }
            }
            else if (ddlHistory.SelectedItem.Value.Equals("2"))
            {
                if (!tbxNIC.Text.Equals(""))
                {
                    con.Open();

                    string cmdtext2 = "SELECT * from SLIC_CHP.VOU_DETAILS_MAS WHERE  NIC = '" + tbxNIC.Text + "'";

                    OracleCommand cmdData1 = new OracleCommand(cmdtext2, con);
                    OracleDataReader myReader1 = cmdData1.ExecuteReader();
                    if (myReader1.HasRows)
                    {
                        while (myReader1.Read())
                        {
                            tbxNIC.Text = myReader1["NIC"].ToString();
                        }

                        this.lblMessage.Text = "";
                        Response.Redirect("ClaimDetailesReport.aspx?NIC=" + tbxNIC.Text + "&frmDate=&toDate=&POL_NO=");

                    }
                    else
                    {
                        lblMessage.Text = "Check the NIC again";
                        con.Close();
                    }
                }
                else
                {
                    lblMessage.Text = "Please enter NIC no";                    
                }

            }
            else if (ddlHistory.SelectedItem.Value.Equals("3"))
            {
                if (!tbxFromDate.Text.Equals("") && !tbxToDate.Text.Equals(""))
                {
                    con.Open();
                    string cmdtext3 = " SELECT POL_NO, CLAIM_NO,INSURED_NAME ,PAYEE_NAME , CLAIM_TYPE, BANK_NAME,BANK_BRANCH_NAME,DATE_OF_CLAIM,SBU,Status,CHQNO,CHQDATE,Payment_type, Relashionship,claimant_name From SLIC_CHP.VOU_DETAILS_MAS A  Join cashbook.temp_cb B   on A.VOU_NO=B.VOUNO Join slic_chp.group_Master C on A.NIC=C.NIC where A.nic='" + tbxNIC.Text + "' AND A.EPF=C.EPF ";

                    OracleCommand cmdData1 = new OracleCommand(cmdtext3, con);
                    OracleDataReader myReader1 = cmdData1.ExecuteReader();
                    frmD = tbxFromDate.Text.Substring(0, 4) + tbxFromDate.Text.Substring(5, 2) + tbxFromDate.Text.Substring(8, 2);
                    frmT = tbxToDate.Text.Substring(0, 4) + tbxToDate.Text.Substring(5, 2) + tbxToDate.Text.Substring(8, 2);
                    frmDate = int.Parse(frmD);
                    toDate = int.Parse(frmT);

                    if ((frmDate > toDate))
                    {
                        lblMessage.Text = "Check the Dates again";
                    }
                    else
                    {                        
                        con.Close();
                        this.lblMessage.Text = "";
                        Response.Redirect("ClaimDetailesReport.aspx?frmDate=" + tbxFromDate.Text + "&toDate=" + tbxToDate.Text + "&POL_NO=&NIC=");
                    }
                }
                else
                {
                    lblMessage.Text = "Please enter date range";                    
                }                
            }
            else
            {
                this.lblMessage.Text = "Please select an option.";
            }
        }



        protected void btnResetMain_Click(object sender, EventArgs e)
        {
            tbxPolNo.Text = "";
            tbxNIC.Text = "";
            tbxFromDate.Text = "";
            tbxToDate.Text = "";
            lblMessage.Text = "";
        }

        
    }






}
