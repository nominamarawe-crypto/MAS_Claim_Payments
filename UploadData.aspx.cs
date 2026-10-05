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
                    // if (objAuthentication.checkVouCreation(Session["UserId"].ToString()) == 0)
                    // {
                    //     string message = "Sorry. @ You have no authority for this option.";
                    //     Response.Redirect("~/EPage.aspx?msg=" + message + "");
                    // }
                    // else
                    // {
                    // }
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
            this.lblResultMsg.Text = "";
            this.lblRecCount.Text = "";
            selected = 0;

            if (!FileUpload1.HasFile)
            {
                this.lblErrorMsg.Text = "Please select a file to upload";
                this.gv1.DataSource = null;
                this.gv1.DataBind();
                return;
            }

            selected = 1;
            string originalName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string fileextension = Path.GetExtension(originalName).ToLowerInvariant();

            // Unique name to avoid collisions between concurrent uploads
            string uniqueName = Guid.NewGuid().ToString("N") + fileextension;
            string uploadsFolder = HostingEnvironment.MapPath("~/App_Data/Uploads/");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string filelocation = Path.Combine(uploadsFolder, uniqueName);

            try
            {
                FileUpload1.SaveAs(filelocation);

                DataTable dt = new DataTable();
                dt.Columns.Add("SBU", typeof(string));
                dt.Columns.Add("EMP_ID_NUM", typeof(string));
                dt.Columns.Add("EPF", typeof(string));
                dt.Columns.Add("MEMBER_NAME", typeof(string));
                dt.Columns.Add("NIC", typeof(string));
                dt.Columns.Add("GENDER", typeof(string));
                dt.Columns.Add("DATE_OF_BIRTH", typeof(string));
                dt.Columns.Add("CONTACT_NO", typeof(string));
                dt.Columns.Add("EMAIL", typeof(string));

                if (fileextension == ".xlsx")
                {
                    string connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                              filelocation +
                                              ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=2\"";

                    using (OleDbConnection conn = new OleDbConnection(connectionstring))
                    {
                        conn.Open();
                        DataTable dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + SheetName + "]", conn))
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                DataRow src = dataTable.Rows[i];

                                // Skip fully blank rows
                                if (src.ItemArray.All(x => x == null || string.IsNullOrWhiteSpace(x.ToString())))
                                    continue;

                                DataRow row = dt.NewRow();
                                row["SBU"] = src.ItemArray.Length > 0 ? src.ItemArray[0].ToString().Trim() : "";
                                row["EMP_ID_NUM"] = src.ItemArray.Length > 1 ? src.ItemArray[1].ToString().Trim() : "";
                                row["EPF"] = src.ItemArray.Length > 2 ? src.ItemArray[2].ToString().Trim() : "";
                                row["MEMBER_NAME"] = src.ItemArray.Length > 3 ? src.ItemArray[3].ToString().Trim() : "";
                                row["NIC"] = src.ItemArray.Length > 4 ? src.ItemArray[4].ToString().Trim() : "";
                                row["GENDER"] = src.ItemArray.Length > 5 ? src.ItemArray[5].ToString().Trim() : "";
                                row["DATE_OF_BIRTH"] = src.ItemArray.Length > 6 ? src.ItemArray[6].ToString().Trim() : "";
                                row["CONTACT_NO"] = src.ItemArray.Length > 7 ? src.ItemArray[7].ToString().Trim() : "";
                                row["EMAIL"] = src.ItemArray.Length > 8 ? src.ItemArray[8].ToString().Trim() : "";
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                else if (fileextension == ".xls")
                {
                    string conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    conStr = String.Format(conStr, filelocation, "Yes");

                    using (OleDbConnection myExcelConn = new OleDbConnection(conStr))
                    {
                        myExcelConn.Open();
                        DataTable dtExcelSchema = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                        using (OleDbCommand myExcelCmd = new OleDbCommand("SELECT * FROM [" + SheetName + "]", myExcelConn))
                        using (OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myExcelCmd))
                        {
                            DataTable mydt = new DataTable();
                            myDataAdapter.Fill(mydt);

                            for (int i = 0; i < mydt.Rows.Count; i++)
                            {
                                DataRow src = mydt.Rows[i];

                                if (src.ItemArray.All(x => x == null || string.IsNullOrWhiteSpace(x.ToString())))
                                    continue;

                                DataRow row = dt.NewRow();
                                row["SBU"] = src.ItemArray.Length > 0 ? src.ItemArray[0].ToString().Trim() : "";
                                row["EMP_ID_NUM"] = src.ItemArray.Length > 1 ? src.ItemArray[1].ToString().Trim() : "";
                                row["EPF"] = src.ItemArray.Length > 2 ? src.ItemArray[2].ToString().Trim() : "";
                                row["MEMBER_NAME"] = src.ItemArray.Length > 3 ? src.ItemArray[3].ToString().Trim() : "";
                                row["NIC"] = src.ItemArray.Length > 4 ? src.ItemArray[4].ToString().Trim() : "";
                                row["GENDER"] = src.ItemArray.Length > 5 ? src.ItemArray[5].ToString().Trim() : "";
                                row["DATE_OF_BIRTH"] = src.ItemArray.Length > 6 ? src.ItemArray[6].ToString().Trim() : "";
                                row["CONTACT_NO"] = src.ItemArray.Length > 7 ? src.ItemArray[7].ToString().Trim() : "";
                                row["EMAIL"] = src.ItemArray.Length > 8 ? src.ItemArray[8].ToString().Trim() : "";
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                else
                {
                    this.lblErrorMsg.Text = "Only .xls and .xlsx files are supported.";
                    return;
                }

                if (dt.Rows.Count == 0)
                {
                    this.lblErrorMsg.Text = "The selected file contains no data rows.";
                    this.gv1.DataSource = null;
                    this.gv1.DataBind();
                    return;
                }

                this.gv1.DataSource = dt;
                this.gv1.DataBind();

                Session["mySessionTableOriginal"] = dt;
            }
            catch (Exception ex)
            {
                this.lblErrorMsg.Text = "Error reading file: " + ex.Message;
            }
            finally
            {
                // Clean up the temporary uploaded file
                try { if (File.Exists(filelocation)) File.Delete(filelocation); } catch { }
                FileUpload1.Attributes.Clear();
            }
        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            lblResultMsg.Text = "";
            lblRecCount.Text = "";

            // 1) Guard: must have data from View Data step
            DataTable sourceTable = Session["mySessionTableOriginal"] as DataTable;
            if (sourceTable == null || sourceTable.Rows.Count == 0)
            {
                lblResultMsg.ForeColor = System.Drawing.Color.Red;
                lblResultMsg.Text = "No data to save. Please upload a file and click View Data first.";
                return;
            }

            // 2) Guard: EPF session
            if (Session["EPFNum"] == null)
            {
                string message = "Your Session Variable Expired. @ Please Log to the system again.";
                Response.Redirect("~/EPage.aspx?msg=" + message + "");
                return;
            }

            DataTable dtExistingRecords = new DataTable();
            dtExistingRecords.Columns.Add("SBU", typeof(string));
            dtExistingRecords.Columns.Add("EMP_ID_NUM", typeof(string));
            dtExistingRecords.Columns.Add("EPF", typeof(string));
            dtExistingRecords.Columns.Add("MEMBER_NAME", typeof(string));
            dtExistingRecords.Columns.Add("NIC", typeof(string));
            dtExistingRecords.Columns.Add("GENDER", typeof(string));
            dtExistingRecords.Columns.Add("DATE_OF_BIRTH", typeof(string));
            dtExistingRecords.Columns.Add("CONTACT_NO", typeof(string));
            dtExistingRecords.Columns.Add("EMAIL", typeof(string)); // <-- FIXED: was typeof(double)

            int uploadedRecs = 0;

            try
            {
                UpdateDB updtDBObj = new UpdateDB();
                updtDBObj.uploadData(
                    sourceTable,
                    Session["EPFNum"].ToString(),
                    out uploadedRecs,
                    out dtExistingRecords);

                lblRecCount.Text = uploadedRecs.ToString();

                if (uploadedRecs > 0)
                {
                    lblResultMsg.ForeColor = System.Drawing.Color.Green;
                    lblResultMsg.Text = "Data uploaded successfully.";

                    if (dtExistingRecords.Rows.Count > 0)
                    {
                        gv2.DataSource = dtExistingRecords;
                        gv2.DataBind();
                    }
                }
                else
                {
                    if (sourceTable.Rows.Count == dtExistingRecords.Rows.Count)
                    {
                        lblResultMsg.Text = "All the records are already uploaded.";
                        lblResultMsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblResultMsg.Text = "Data was not Uploaded Successfully.";
                        lblResultMsg.ForeColor = System.Drawing.Color.Red;
                    }

                    if (dtExistingRecords.Rows.Count > 0)
                    {
                        gv2.DataSource = dtExistingRecords;
                        gv2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblResultMsg.ForeColor = System.Drawing.Color.Red;
                lblResultMsg.Text = "Error: " + ex.Message;
            }
        }
    }
}