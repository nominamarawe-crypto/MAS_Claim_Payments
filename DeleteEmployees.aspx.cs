using System;
using System.Data;
using System.Data.OracleClient;
using System.Text.RegularExpressions;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    public partial class DeleteEmployees : System.Web.UI.Page
    {
        private DataManager dManager;
        private GetDBData dbDataObj;

        // Helper: Normalise NIC – remove all non‑digit characters
        private string NormaliseNIC(string nic)
        {
            if (string.IsNullOrWhiteSpace(nic)) return "";
            return Regex.Replace(nic.Trim(), @"\D", ""); // keep only digits
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] == null)
                {
                    string message = "Your Session Variable Expired. Please log in again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message);
                }

                lblMessage.Text = "";
                pnlEmployeeDetails.Visible = false;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            pnlEmployeeDetails.Visible = false;
            string rawNic = txtNIC.Text.Trim();

            if (string.IsNullOrEmpty(rawNic))
            {
                lblMessage.Text = "Please enter NIC.";
                return;
            }

            string normalisedNic = NormaliseNIC(rawNic);
            if (string.IsNullOrEmpty(normalisedNic))
            {
                lblMessage.Text = "Invalid NIC format (no digits found).";
                return;
            }

            dbDataObj = new GetDBData();
            if (!dbDataObj.checkNICExists(normalisedNic))   // You must update checkNICExists to use normalised comparison
            {
                lblMessage.Text = $"No employee found with NIC: {rawNic}";
                return;
            }

            dManager = new DataManager();
            try
            {
                // Query using normalised comparison (remove non‑digits from DB column)
                string selectQuery = @"
                    SELECT SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL
                    FROM SLIC_CHP.GROUP_MASTER
                    WHERE REGEXP_REPLACE(NIC, '[^0-9]', '') = :NormalisedNIC";

                dManager.readSql(selectQuery);
                dManager.oraComm.Parameters.Clear();
                dManager.oraComm.Parameters.Add("NormalisedNIC", OracleType.VarChar).Value = normalisedNic;

                using (OracleDataReader reader = dManager.oraComm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblSBU.Text = reader["SBU"]?.ToString() ?? "";
                        lblEPF.Text = reader["EPF"]?.ToString() ?? "";
                        lblMemberName.Text = reader["MEMBER_NAME"]?.ToString() ?? "";
                        lblDisplayNIC.Text = reader["NIC"]?.ToString() ?? ""; // show original NIC
                        lblGender.Text = reader["GENDER"]?.ToString() ?? "";
                        lblContactNo.Text = reader["CONTACT_NO"]?.ToString() ?? "";
                        lblEmail.Text = reader["EMAIL"]?.ToString() ?? "";

                        if (reader["DATE_OF_BIRTH"] != DBNull.Value)
                        {
                            DateTime dob = Convert.ToDateTime(reader["DATE_OF_BIRTH"]);
                            lblDOB.Text = dob.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            lblDOB.Text = "";
                        }

                        pnlEmployeeDetails.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = $"No employee found with NIC: {rawNic}";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error retrieving employee details: " + ex.Message;
            }
            finally
            {
                dManager.connclose();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            pnlEmployeeDetails.Visible = false;
            string rawNic = txtNIC.Text.Trim();

            if (string.IsNullOrEmpty(rawNic))
            {
                lblMessage.Text = "Please enter NIC.";
                return;
            }

            string normalisedNic = NormaliseNIC(rawNic);
            if (string.IsNullOrEmpty(normalisedNic))
            {
                lblMessage.Text = "Invalid NIC format (no digits found).";
                return;
            }

            dbDataObj = new GetDBData();
            if (!dbDataObj.checkNICExists(normalisedNic))
            {
                lblMessage.Text = $"No employee found with NIC: {rawNic}";
                return;
            }

            dManager = new DataManager();
            try
            {
                // First retrieve full record using normalised NIC
                string selectQuery = @"
                    SELECT SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL
                    FROM SLIC_CHP.GROUP_MASTER
                    WHERE REGEXP_REPLACE(NIC, '[^0-9]', '') = :NormalisedNIC";

                dManager.readSql(selectQuery);
                dManager.oraComm.Parameters.Clear();
                dManager.oraComm.Parameters.Add("NormalisedNIC", OracleType.VarChar).Value = normalisedNic;

                using (OracleDataReader reader = dManager.oraComm.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        lblMessage.Text = $"No employee found with NIC: {rawNic}";
                        return;
                    }

                    string sbu = reader["SBU"]?.ToString() ?? "";
                    string epf = reader["EPF"]?.ToString() ?? "";
                    string memberName = reader["MEMBER_NAME"]?.ToString() ?? "";
                    string originalNIC = reader["NIC"]?.ToString() ?? "";
                    string gender = reader["GENDER"]?.ToString() ?? "";
                    string contactNo = reader["CONTACT_NO"]?.ToString() ?? "";
                    string email = reader["EMAIL"]?.ToString() ?? "";

                    DateTime? dob = null;
                    if (reader["DATE_OF_BIRTH"] != DBNull.Value)
                        dob = Convert.ToDateTime(reader["DATE_OF_BIRTH"]);

                    reader.Close();

                    // Begin transaction
                    dManager.begintransaction();

                    // Insert into history table
                    string insertQuery = @"
                        INSERT INTO SLIC_CHP.GROUP_HISTORY
                        (SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL,
                         DELETED_DATE, DELETED_BY)
                        VALUES
                        (:SBU, :EPF, :MEMBER_NAME, :NIC, :GENDER, :DATE_OF_BIRTH, :CONTACT_NO, :EMAIL,
                         :DELETED_DATE, :DELETED_BY)";

                    dManager.readSql(insertQuery);
                    dManager.oraComm.Parameters.Clear();
                    dManager.oraComm.Parameters.Add("SBU", OracleType.VarChar).Value = sbu;
                    dManager.oraComm.Parameters.Add("EPF", OracleType.VarChar).Value = epf;
                    dManager.oraComm.Parameters.Add("MEMBER_NAME", OracleType.VarChar).Value = memberName;
                    dManager.oraComm.Parameters.Add("NIC", OracleType.VarChar).Value = originalNIC; // store original NIC
                    dManager.oraComm.Parameters.Add("GENDER", OracleType.VarChar).Value = gender;
                    dManager.oraComm.Parameters.Add("DATE_OF_BIRTH", OracleType.DateTime).Value = dob ?? (object)DBNull.Value;
                    dManager.oraComm.Parameters.Add("CONTACT_NO", OracleType.VarChar).Value = contactNo;
                    dManager.oraComm.Parameters.Add("EMAIL", OracleType.VarChar).Value = email;
                    dManager.oraComm.Parameters.Add("DELETED_DATE", OracleType.DateTime).Value = DateTime.Now;
                    dManager.oraComm.Parameters.Add("DELETED_BY", OracleType.VarChar).Value =
                        Session["UserId"]?.ToString() ?? Session["EPFNum"]?.ToString() ?? "Unknown";

                    dManager.insertRecords(insertQuery);

                    // Delete from main table using original NIC (or normalised condition)
                    string deleteQuery = @"
                        DELETE FROM SLIC_CHP.GROUP_MASTER
                        WHERE REGEXP_REPLACE(NIC, '[^0-9]', '') = :NormalisedNIC";

                    dManager.readSql(deleteQuery);
                    dManager.oraComm.Parameters.Clear();
                    dManager.oraComm.Parameters.Add("NormalisedNIC", OracleType.VarChar).Value = normalisedNic;

                    int rowsDeleted = dManager.insertRecords(deleteQuery);

                    if (rowsDeleted > 0)
                    {
                        dManager.commit();
                        lblMessage.Text = $"Employee with NIC {originalNIC} moved to history and deleted successfully.";
                        txtNIC.Text = "";
                        pnlEmployeeDetails.Visible = false;
                    }
                    else
                    {
                        dManager.rollback();
                        lblMessage.Text = "Delete failed – record not found in master table.";
                    }
                }
            }
            catch (Exception ex)
            {
                dManager.rollback();
                lblMessage.Text = "Database error: " + ex.Message;
            }
            finally
            {
                dManager.connclose();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtNIC.Text = "";
            lblMessage.Text = "";
            pnlEmployeeDetails.Visible = false;
        }
    }
}