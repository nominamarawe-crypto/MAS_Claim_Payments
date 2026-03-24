using MAS_Claim_Payments.App_Code;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAS_Claim_Payments
{
    public partial class UploadData : System.Web.UI.Page
    {
        private Authentication objAuthentication = new Authentication();
        private Policy objPolicy = new Policy();

        public int selected { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {
                    int epf = objPolicy.EpfCode(Session["EPFNum"].ToString());
                    //if (objAuthentication.checkVouCreation(Session["UserId"].ToString()) == 0)
                    //{
                    //    string message = "Sorry. @ You have no authority for this option.";
                    //    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                    //}
                    //else
                    //{

                    //}
                }
                else
                {
                    string message = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblErrorMsg.Text = "";
            selected = 0;
            {
                if (FileUpload1.HasFile)
                {
                    selected = 1;
                    string connectionstring = "";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string fileextension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string filelocation = HostingEnvironment.ApplicationPhysicalPath + filename;
                    FileUpload1.SaveAs(filelocation);
                    
                    Execute_sql sqlObj = new Execute_sql();
                    Oracle_Transaction oraTrans = new Oracle_Transaction();

                    if (fileextension == ".xlsx")
                    {
                        connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=2\"";
                        OleDbConnection conn = new OleDbConnection(connectionstring);
                        conn.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        //Fetch the name of First Sheet
                        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        conn.Close();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "select * from  [" + SheetName + "]";
                        cmd.Connection = conn;
                        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        oleDbDataAdapter.Fill(dataTable);

                        #region Get all data from original

                        DataTable dt = new DataTable();
                       
                        dt.Columns.Add("SBU", typeof(string));
                        dt.Columns.Add("EPF", typeof(string));
                        dt.Columns.Add("MEMBER_NAME", typeof(string));
                        dt.Columns.Add("NIC", typeof(string));
                        dt.Columns.Add("GENDER", typeof(string));
                        dt.Columns.Add("DATE_OF_BIRTH", typeof(string));
                        dt.Columns.Add("CONTACT_NO", typeof(string));
                        dt.Columns.Add("EMAIL", typeof(string));

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            DataRow row = dt.NewRow();
                            row["SBU"] = dataTable.Rows[i].ItemArray[0].ToString();
                            row["EPF"] = dataTable.Rows[i].ItemArray[1].ToString();
                            row["MEMBER_NAME"] = dataTable.Rows[i].ItemArray[2].ToString();
                            row["NIC"] = dataTable.Rows[i].ItemArray[3].ToString();
                            row["GENDER"] = dataTable.Rows[i].ItemArray[4].ToString();
                            row["DATE_OF_BIRTH"] = dataTable.Rows[i].ItemArray[5].ToString();
                            row["CONTACT_NO"] = dataTable.Rows[i].ItemArray[6].ToString();
                            row["EMAIL"] = dataTable.Rows[i].ItemArray[7].ToString();

                            dt.Rows.Add(row);
                        }

                        this.gv1.DataSource = dt;
                        this.gv1.DataBind();

                        Session.Add("mySessionTableOriginal", dt);

                        #endregion
                        

                    }
                    else if (fileextension == ".xls")
                    {
                        string conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        DataTable dataTable2 = new DataTable();
                        conStr = String.Format(conStr, filelocation, "Yes");
                        OleDbConnection myExcelConn = new OleDbConnection(conStr);
                        OleDbCommand myExcelCmd = new OleDbCommand();
                        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
                        DataTable mydt = new DataTable();
                        myExcelCmd.Connection = myExcelConn;
                        myExcelConn.Open();

                        DataTable dtExcelSchema;
                        dtExcelSchema = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        //Fetch the name of First Sheet
                        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        myExcelConn.Close();

                        //Read Data from First Sheet
                        myExcelConn.Open();
                        myExcelCmd.CommandText = "SELECT * From [" + SheetName + "]";
                        myDataAdapter.SelectCommand = myExcelCmd;
                        myDataAdapter.Fill(mydt);
                        myExcelConn.Close();

                        #region Get all data from original

                        DataTable dt = new DataTable();

                        dt.Columns.Add("SBU", typeof(string));
                        dt.Columns.Add("EPF", typeof(string));
                        dt.Columns.Add("MEMBER_NAME", typeof(string));
                        dt.Columns.Add("NIC", typeof(string));
                        dt.Columns.Add("GENDER", typeof(string));
                        dt.Columns.Add("DATE_OF_BIRTH", typeof(string));
                        dt.Columns.Add("CONTACT_NO", typeof(string));
                        dt.Columns.Add("EMAIL", typeof(string));

                        for (int i = 0; i < mydt.Rows.Count; i++)
                        {
                            DataRow row = dt.NewRow();
                            row["SBU"] = mydt.Rows[i].ItemArray[0].ToString();
                            row["EPF"] = mydt.Rows[i].ItemArray[1].ToString();
                            row["MEMBER_NAME"] = mydt.Rows[i].ItemArray[2].ToString();
                            row["NIC"] = mydt.Rows[i].ItemArray[3].ToString();
                            row["GENDER"] = mydt.Rows[i].ItemArray[4].ToString();
                            row["DATE_OF_BIRTH"] = mydt.Rows[i].ItemArray[5].ToString();
                            row["CONTACT_NO"] = mydt.Rows[i].ItemArray[6].ToString();
                            row["EMAIL"] = mydt.Rows[i].ItemArray[7].ToString();
                            dt.Rows.Add(row);
                        }

                        this.gv1.DataSource = dt;
                        this.gv1.DataBind();

                        Session.Add("mySessionTableOriginal", dt);

                        #endregion

                        
                    }
                }
                else
                {
                    this.lblErrorMsg.Text = "Please select a file to upload";
                    this.gv1.DataSource = null;
                    this.gv1.DataBind();
                }
                FileUpload1.Attributes.Clear();
            }
        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            DataTable dtExistingRecords = new DataTable();

            dtExistingRecords.Columns.Add("SBU", typeof(string));
            dtExistingRecords.Columns.Add("EPF", typeof(string));
            dtExistingRecords.Columns.Add("MEMBER_NAME", typeof(string));
            dtExistingRecords.Columns.Add("NIC", typeof(string));
            dtExistingRecords.Columns.Add("GENDER", typeof(string));
            dtExistingRecords.Columns.Add("DATE_OF_BIRTH", typeof(string));
            dtExistingRecords.Columns.Add("CONTACT_NO", typeof(string));
            dtExistingRecords.Columns.Add("EMAIL", typeof(double));

            int uploadedRecs = 0;

            if (this.gv1.Rows.Count > 0)
            {
                UpdateDB updtDBObj = new UpdateDB();
                //int successCount = opdClmObj.insertOPDClaims((DataTable)Session["mySessionTable"], Session["UserId"].ToString(), out uploadedRecs, out dtExistingRecords);
                updtDBObj.uploadData((DataTable)Session["mySessionTableOriginal"], Session["EPFNum"].ToString(), out uploadedRecs, out dtExistingRecords);
                if (uploadedRecs > 0)
                {                   
                    this.lblRecCount.Text = uploadedRecs.ToString();
                    if (dtExistingRecords.Rows.Count > 0)
                    {
                        this.gv2.DataSource = dtExistingRecords;
                        this.gv2.DataBind();
                    }
                }
                else
                {
                    if (this.gv1.Rows.Count == dtExistingRecords.Rows.Count)
                    {
                        lblResultMsg.Text = "All the records are already uploaded.";
                        lblResultMsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblResultMsg.Text = "Data was not Uploaded Successfully.";
                        lblResultMsg.ForeColor = System.Drawing.Color.Red;
                    }
                    
                    this.lblRecCount.Text = "0";

                    if (dtExistingRecords.Rows.Count > 0)
                    {
                        this.gv2.DataSource = dtExistingRecords;
                        this.gv2.DataBind();
                    }
                }

            }
        }

    }
}