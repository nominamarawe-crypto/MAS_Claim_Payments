using System;
using System.Data;
using System.Data.OracleClient;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    public partial class DeleteEmployees : System.Web.UI.Page
    {
        private DataManager dManager;
        private GetDBData dbDataObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Optional session check – same as ClaimEntry
                if (Session["EPFNum"] == null)
                {
                    string message = "Your Session Variable Expired. Please log in again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message);
                }

                lblMessage.Text = "";
                pnlEmployeeDetails.Visible = false;
            }
        }

        // View button click – fetch and display employee details
        protected void btnView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            pnlEmployeeDetails.Visible = false;
            string nic = txtNIC.Text.Trim();

            if (string.IsNullOrEmpty(nic))
            {
                lblMessage.Text = "Please enter NIC.";
                return;
            }

            // Check if NIC exists using existing GetDBData method
            dbDataObj = new GetDBData();
            if (!dbDataObj.checkNICExists(nic))
            {
                lblMessage.Text = $"No employee found with NIC: {nic}";
                return;
            }

            // Retrieve employee details from GROUP_MASTER
            dManager = new DataManager();
            try
            {
                string selectQuery = @"
                    SELECT SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL
                    FROM SLIC_CHP.GROUP_MASTER
                    WHERE TRIM(NIC) = :NIC";

                dManager.readSql(selectQuery);
                dManager.oraComm.Parameters.Clear();
                dManager.oraComm.Parameters.Add("NIC", OracleType.VarChar).Value = nic;

                using (OracleDataReader reader = dManager.oraComm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate labels with data
                        lblSBU.Text = reader["SBU"]?.ToString() ?? "";
                        lblEPF.Text = reader["EPF"]?.ToString() ?? "";
                        lblMemberName.Text = reader["MEMBER_NAME"]?.ToString() ?? "";
                        lblDisplayNIC.Text = reader["NIC"]?.ToString() ?? "";
                        lblGender.Text = reader["GENDER"]?.ToString() ?? "";
                        lblContactNo.Text = reader["CONTACT_NO"]?.ToString() ?? "";
                        lblEmail.Text = reader["EMAIL"]?.ToString() ?? "";

                        // Format date if present
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
                        lblMessage.Text = $"No employee found with NIC: {nic}";
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

        // Delete button click – move to history and delete from master
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            pnlEmployeeDetails.Visible = false; // hide details panel
            string nic = txtNIC.Text.Trim();

            if (string.IsNullOrEmpty(nic))
            {
                lblMessage.Text = "Please enter NIC.";
                return;
            }

            // Check if NIC exists using existing GetDBData method
            dbDataObj = new GetDBData();
            if (!dbDataObj.checkNICExists(nic))
            {
                lblMessage.Text = $"No employee found with NIC: {nic}";
                return;
            }

            // Use DataManager for transactional operations
            dManager = new DataManager();

            try
            {
                // 1. Retrieve the employee record from GROUP_MASTER
                string selectQuery = @"
                    SELECT SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL
                    FROM SLIC_CHP.GROUP_MASTER
                    WHERE TRIM(NIC) = :NIC";

                dManager.readSql(selectQuery);
                dManager.oraComm.Parameters.Clear();
                dManager.oraComm.Parameters.Add("NIC", OracleType.VarChar).Value = nic;

                using (OracleDataReader reader = dManager.oraComm.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        lblMessage.Text = $"No employee found with NIC: {nic}";
                        return;
                    }

                    // Extract values safely
                    string sbu = reader["SBU"]?.ToString() ?? "";
                    string epf = reader["EPF"]?.ToString() ?? "";
                    string memberName = reader["MEMBER_NAME"]?.ToString() ?? "";
                    string gender = reader["GENDER"]?.ToString() ?? "";
                    string contactNo = reader["CONTACT_NO"]?.ToString() ?? "";
                    string email = reader["EMAIL"]?.ToString() ?? "";

                    DateTime? dob = null;
                    if (reader["DATE_OF_BIRTH"] != DBNull.Value)
                        dob = Convert.ToDateTime(reader["DATE_OF_BIRTH"]);

                    reader.Close();

                    // 2. Begin transaction
                    dManager.begintransaction();

                    // 3. Insert into GROUP_HISTORY (including DELETED_DATE and DELETED_BY)
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
                    dManager.oraComm.Parameters.Add("NIC", OracleType.VarChar).Value = nic;
                    dManager.oraComm.Parameters.Add("GENDER", OracleType.VarChar).Value = gender;
                    dManager.oraComm.Parameters.Add("DATE_OF_BIRTH", OracleType.DateTime).Value = dob ?? (object)DBNull.Value;
                    dManager.oraComm.Parameters.Add("CONTACT_NO", OracleType.VarChar).Value = contactNo;
                    dManager.oraComm.Parameters.Add("EMAIL", OracleType.VarChar).Value = email;

                    // Add audit fields
                    dManager.oraComm.Parameters.Add("DELETED_DATE", OracleType.DateTime).Value = DateTime.Now;
                    dManager.oraComm.Parameters.Add("DELETED_BY", OracleType.VarChar).Value =
                        Session["UserId"]?.ToString() ?? "Unknown";

                    dManager.insertRecords(insertQuery);

                    // 4. Delete from GROUP_MASTER
                    string deleteQuery = "DELETE FROM SLIC_CHP.GROUP_MASTER WHERE TRIM(NIC) = :NIC";
                    dManager.readSql(deleteQuery);
                    dManager.oraComm.Parameters.Clear();
                    dManager.oraComm.Parameters.Add("NIC", OracleType.VarChar).Value = nic;

                    int rowsDeleted = dManager.insertRecords(deleteQuery);

                    if (rowsDeleted > 0)
                    {
                        dManager.commit();
                        lblMessage.Text = $"Employee with NIC {nic} moved to history and deleted successfully.";
                        txtNIC.Text = "";
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

        // Reset button click – clear fields and hide panel
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtNIC.Text = "";
            lblMessage.Text = "";
            pnlEmployeeDetails.Visible = false;
        }
    }
}