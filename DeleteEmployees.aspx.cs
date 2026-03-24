using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace MAS_Claim_Payments
{
    public partial class DeleteEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string nic = txtNIC.Text.Trim();

            if (string.IsNullOrEmpty(nic))
            {
                ShowMessage("Please enter NIC.");
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString;

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                // STEP 1: GET DATA
                string selectQuery = @"SELECT SBU, EPF, MEMBER_NAME, NIC, GENDER,
                                       DATE_OF_BIRTH, CONTACT_NO, EMAIL
                                       FROM SLIC_CHP.GROUP_MASTER
                                       WHERE NIC = :NIC";

                OracleCommand selectCmd = new OracleCommand(selectQuery, conn);
                selectCmd.Parameters.Add("NIC", OracleDbType.Varchar2).Value = nic;

                OracleDataReader reader = selectCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    ShowMessage("No employee found.");
                    reader.Close();
                    return;
                }

                reader.Read();

                string sbu = reader["SBU"].ToString();
                string epf = reader["EPF"].ToString();
                string memberName = reader["MEMBER_NAME"].ToString();
                string gender = reader["GENDER"].ToString();
                string contactNo = reader["CONTACT_NO"].ToString();
                string email = reader["EMAIL"].ToString();

                DateTime dob = DateTime.MinValue;
                if (reader["DATE_OF_BIRTH"] != DBNull.Value)
                {
                    dob = Convert.ToDateTime(reader["DATE_OF_BIRTH"]);
                }

                reader.Close();

                // STEP 2: TRANSACTION
                OracleTransaction transaction = conn.BeginTransaction();

                try
                {
                    // INSERT INTO HISTORY
                    string insertQuery = @"INSERT INTO SLIC_CHP.GROUP_HISTORY
                        (SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL)
                        VALUES (:SBU, :EPF, :MEMBER_NAME, :NIC, :GENDER, :DATE_OF_BIRTH, :CONTACT_NO, :EMAIL)";

                    OracleCommand insertCmd = new OracleCommand(insertQuery, conn);
                    insertCmd.Transaction = transaction;

                    insertCmd.Parameters.Add("SBU", OracleDbType.Varchar2).Value = sbu;
                    insertCmd.Parameters.Add("EPF", OracleDbType.Varchar2).Value = epf;
                    insertCmd.Parameters.Add("MEMBER_NAME", OracleDbType.Varchar2).Value = memberName;
                    insertCmd.Parameters.Add("NIC", OracleDbType.Varchar2).Value = nic;
                    insertCmd.Parameters.Add("GENDER", OracleDbType.Varchar2).Value = gender;
                    insertCmd.Parameters.Add("DATE_OF_BIRTH", OracleDbType.Date).Value = dob;
                    insertCmd.Parameters.Add("CONTACT_NO", OracleDbType.Varchar2).Value = contactNo;
                    insertCmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = email;

                    insertCmd.ExecuteNonQuery();

                    // DELETE FROM MASTER
                    string deleteQuery = "DELETE FROM SLIC_CHP.GROUP_MASTER WHERE NIC = :NIC";

                    OracleCommand deleteCmd = new OracleCommand(deleteQuery, conn);
                    deleteCmd.Transaction = transaction;

                    deleteCmd.Parameters.Add("NIC", OracleDbType.Varchar2).Value = nic;

                    int rows = deleteCmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        transaction.Commit();
                        ShowMessage("Employee moved to history and deleted successfully.");
                        txtNIC.Text = "";
                    }
                    else
                    {
                        transaction.Rollback();
                        ShowMessage("Delete failed.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ShowMessage("Error: " + ex.Message);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtNIC.Text = "";
            lblMessage.Text = "";
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }
    }
}