using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace MAS_Claim_Payments.App_Code
{
    public class GetDBData
    {
        public OracleDataReader odrr;
        public DataManager dMngr;
        public bool checkNICExists(string nic)
        {
            bool exists = false;
            dMngr = new DataManager();

            string sql = "select * from SLIC_CHP.GROUP_MASTER where NIC = '" + nic + "'";

            if (dMngr.existRecored(sql) != 0)
            {
                exists = true;
            }

            dMngr.connClose();
            return exists;
        }

        public string getInsuredName(string nic)
        {
            dMngr = new DataManager();
            string name = "";

            string sql = "select MEMBER_NAME from SLIC_CHP.GROUP_MASTER where NIC = '" + nic + "'";

            if (dMngr.existRecored(sql) != 0)
            {
                dMngr.readSql(sql);
                odrr = dMngr.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { name = odrr.GetString(0); }
                }
                odrr.Close();
            }

            dMngr.connClose();
            return name;
        }

        public string getContactNo(string nic)
        {
            dMngr = new DataManager();
            string contactNo = "";

            string sql = "select CONTACT_NO from SLIC_CHP.GROUP_MASTER where NIC = '" + nic + "'";

            if (dMngr.existRecored(sql) != 0)
            {
                dMngr.readSql(sql);
                odrr = dMngr.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { contactNo = odrr.GetString(0); }
                }
                odrr.Close();
            }

            dMngr.connClose();
            return contactNo;
        }


        public string getEmail(string nic)
        {
            dMngr = new DataManager();
            string email = "";

            string sql = "select EMAIL from SLIC_CHP.GROUP_MASTER where NIC = '" + nic + "'";

            if (dMngr.existRecored(sql) != 0)
            {
                dMngr.readSql(sql);
                odrr = dMngr.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { email = odrr.GetString(0); }
                }
                odrr.Close();
            }

            dMngr.connClose();
            return email;
        }

        public string getEPF(string nic)
        {
            dMngr = new DataManager();
            string epf = "";

            string sql = "select EPF from SLIC_CHP.GROUP_MASTER where NIC = '" + nic + "'";

            if (dMngr.existRecored(sql) != 0)
            {
                dMngr.readSql(sql);
                odrr = dMngr.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { epf = odrr.GetString(0); }
                }
                odrr.Close();
            }

            dMngr.connClose();
            return epf;
        }

        public int getMaxSeq(string polNo)
        {
            dMngr = new DataManager();
            int seqNo = 0;

            string sql = "select SEQ_NO from SLIC_CHP.CLAIM_NO_SEQ where YEAR =" + DateTime.Today.Year.ToString() +
                        " and GROUP_POLICY_NO ='" + polNo.Substring(5) + "' and CLAIM_TYPE = '3'";

            if (dMngr.existRecored(sql) != 0)
            {
                dMngr.readSql(sql);
                odrr = dMngr.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { seqNo = odrr.GetInt32(0); }
                }
                odrr.Close();
            }

            dMngr.connClose();
            return seqNo;
        }

        public int getMaxVouSeq(int brnchCode)
        {
            dMngr = new DataManager();
            int seqNo = 0;

            string sql = "select VOUNO1 from LCLM.VOUNO where VUBRNO =" + brnchCode + " and VUYEAR = " + DateTime.Today.Year.ToString() + " and VUTYPE = 'W'";

            if (dMngr.existRecored(sql) != 0)
            {
                dMngr.readSql(sql);
                odrr = dMngr.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { seqNo = odrr.GetInt32(0); }
                }
                odrr.Close();
            }

            dMngr.connClose();
            return seqNo;
        }

        public string getBankName(int bankCode)
        {
            DataManager dm = new DataManager();
            string bankName = "";
            string getBankName = "select '.' as bbnam,0000 as bcode from dual union select bbnam, bcode from genpay.bnkbrn where bcode = " + bankCode;
            dm.readSql(getBankName);
            odrr = dm.oraComm.ExecuteReader();
            while (odrr.Read())
            {
                if (!odrr.IsDBNull(0))
                    bankName = odrr.GetString(0);
                else
                    bankName = "";
            }
            odrr.Close();
            dm.connclose();
            return bankName;  // never null
        }

        public string getBankBranchName(int branchCode, int bankCode)
        {
            DataManager dm = new DataManager();
            string bankBranchName = "";

            string getBranchName = "select BBRNCH from GENPAY.BNKBRN where BRCODE = " + branchCode + " and BCODE = " + bankCode + "";
            dm.readSql(getBranchName);
            odrr = dm.oraComm.ExecuteReader();
            while (odrr.Read())
            {
                if (!odrr.IsDBNull(0)) { bankBranchName = odrr.GetString(0); } else { bankBranchName = ""; }
            }
            odrr.Close();
            dm.connclose();
            bankBranchName = bankBranchName.ToUpper();
            return bankBranchName;
        }

        public int getBankBranchCode(string branchName, int bankCode)
        {
            DataManager dm = new DataManager();
            int branchCode = 0;

            string getBranchName = "select BRCODE from GENPAY.BNKBRN where BCODE = " + bankCode + " and UPPER(BBRNCH) = '" + branchName.ToUpper() + "'";
            dm.readSql(getBranchName);
            odrr = dm.oraComm.ExecuteReader();
            while (odrr.Read())
            {
                if (!odrr.IsDBNull(0)) { branchCode = odrr.GetInt32(0); } else { branchCode = 0; }
            }
            odrr.Close();
            dm.connclose();
            return branchCode;
        }

        public DataTable getClaimToCreateVousDR(int fromDate, int toDate)
        {
            DataManager dm = new DataManager();

            DataTable dt = new DataTable();
            dt.Columns.Add("CLAIM_NO", typeof(string));
            dt.Columns.Add("NIC", typeof(string));
            dt.Columns.Add("DATE_OF_CLAIM", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Columns.Add("PAYEE_NAME", typeof(string));

            string getClms = "select CLAIM_NO, NIC, to_char(DATE_OF_CLAIM, 'YYYY-MM-DD') DATE_OF_CLAIM, " +
                                    " to_char(AMOUNT, '99999999.99') AMOUNT, PAYEE_NAME " +
                                    " from SLIC_CHP.VOU_DETAILS_MAS where to_char(DATE_OF_CLAIM, 'YYYYMMDD') < " + toDate +
                                    " and to_char(DATE_OF_CLAIM, 'YYYYMMDD') > " + fromDate + " and VOU_NO is null";
            dm.readSql(getClms);
            odrr = dm.oraComm.ExecuteReader();
            while (odrr.Read())
            {
                if (!odrr.IsDBNull(0)) { dt.Rows.Add(odrr.GetString(0), odrr.GetString(1), odrr.GetString(2), odrr.GetString(3), odrr.GetString(4)); }
            }
            odrr.Close();
            dm.connclose();
            return dt;
        }

        public DataTable getClaimToCreateVousD(int date)
        {
            DataManager dm = new DataManager();

            DataTable dt = new DataTable();
            dt.Columns.Add("CLAIM_NO", typeof(string));
            dt.Columns.Add("NIC", typeof(string));
            dt.Columns.Add("DATE_OF_CLAIM", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Columns.Add("PAYEE_NAME", typeof(string));

            string getClms = "select CLAIM_NO, NIC, to_char(DATE_OF_CLAIM, 'YYYY-MM-DD') DATE_OF_CLAIM, " +
                                    " to_char(AMOUNT, '99999999.99') AMOUNT, PAYEE_NAME " +
                                    " from SLIC_CHP.VOU_DETAILS_MAS where to_char(DATE_OF_CLAIM, 'YYYYMMDD') < " +
                                    date + " and VOU_NO is null";

            dm.readSql(getClms);
            odrr = dm.oraComm.ExecuteReader();
            while (odrr.Read())
            {
                if (!odrr.IsDBNull(0)) { dt.Rows.Add(odrr.GetString(0), odrr.GetString(1), odrr.GetString(2), odrr.GetString(3), odrr.GetString(4)); }
            }
            odrr.Close();
            dm.connclose();
            return dt;
        }

        public DataTable getExgratiaPaymentsD(int date, string clmType)
        {
            DataManager dm = new DataManager();

            DataTable dt = new DataTable();
            dt.Columns.Add("CLAIM_NO", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Columns.Add("INSURED_NAME", typeof(string));
            dt.Columns.Add("NIC", typeof(string));

            string getClms = "";

            if (clmType.Equals("") || clmType.Equals("S"))
            {
                dt.Columns.Add("CLAIM_TYPE", typeof(string));

                getClms = "select CLAIM_NO, TO_CHAR(AMOUNT,'99999999.99') AMOUNT, INSURED_NAME, NIC , DECODE(CLAIM_TYPE,'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun','Fueneral Expenses','ExD', 'Ex-Gratia Death', " +
                            "'EDis', 'Ex-Gratia Disability', 'EHos', 'Ex-Gratia Hospital Cash', 'EFun', 'Ex-Gratia Funeral Expenses') CLAIM_TYPE " +
                            "from slic_chp.vou_details_mas " +
                            "where to_char(DATE_OF_CLAIM, 'YYYYMMDD') < " + date + "";

                dm.readSql(getClms);
                odrr = dm.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { dt.Rows.Add(odrr.GetString(0), odrr.GetString(1), odrr.GetString(2), odrr.GetString(3), odrr.GetString(4)); }
                }
                odrr.Close();
            }

            if (clmType != "" && !clmType.Equals("S"))
            {
                getClms = "select CLAIM_NO, AMOUNT, INSURED_NAME, NIC " +
                            "from slic_chp.vou_details_mas " +
                            "where to_char(DATE_OF_CLAIM, 'YYYYMMDD') < " + date + " and CLAIM_TYPE = '" + clmType + "'";

                dm.readSql(getClms);
                odrr = dm.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { dt.Rows.Add(odrr.GetString(0), odrr.GetString(1), odrr.GetString(2), odrr.GetString(3)); }
                }
                odrr.Close();
            }


            dm.connclose();
            return dt;
        }

        public DataTable getExgratiaPaymentsDR(int dateFrom, int dateTo, string clmType)
        {
            DataManager dm = new DataManager();

            DataTable dt = new DataTable();
            dt.Columns.Add("CLAIM_NO", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Columns.Add("INSURED_NAME", typeof(string));
            dt.Columns.Add("NIC", typeof(string));

            string getClms = "";

            if (clmType.Equals("") || clmType.Equals("S"))
            {
                dt.Columns.Add("CLAIM_TYPE", typeof(string));

                getClms = "select CLAIM_NO, TO_CHAR(AMOUNT,'99999999.99') AMOUNT, INSURED_NAME, NIC , DECODE(CLAIM_TYPE,'D', 'Death', 'Dis', 'Disability', 'Hos', 'Hospital Cash', 'Fun','Fueneral Expenses','ExD', 'Ex-Gratia Death', " +
                            "'EDis', 'Ex-Gratia Disability', 'EHos', 'Ex-Gratia Hospital Cash', 'EFun', 'Ex-Gratia Funeral Expenses') CLAIM_TYPE " +
                            "from slic_chp.vou_details_mas " +
                            "where to_char(DATE_OF_CLAIM, 'YYYYMMDD') < " + dateTo +
                            " and to_char(DATE_OF_CLAIM, 'YYYYMMDD') > " + dateFrom + "";

                dm.readSql(getClms);
                odrr = dm.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { dt.Rows.Add(odrr.GetString(0), odrr.GetString(1), odrr.GetString(2), odrr.GetString(3), odrr.GetString(4)); }
                }
                odrr.Close();
            }

            if (clmType != "" && !clmType.Equals("S"))
            {
                getClms = "select CLAIM_NO, AMOUNT, INSURED_NAME, NIC " +
                            "from slic_chp.vou_details_mas " +
                            "where to_char(DATE_OF_CLAIM, 'YYYYMMDD') < " + dateTo +
                            " and to_char(DATE_OF_CLAIM, 'YYYYMMDD') > " + dateFrom +
                            " and CLAIM_TYPE = '" + clmType + "'";

                dm.readSql(getClms);
                odrr = dm.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { dt.Rows.Add(odrr.GetString(0), odrr.GetString(1), odrr.GetString(2), odrr.GetString(3)); }
                }
                odrr.Close();
            }


            dm.connclose();
            return dt;
        }

        public DataTable getClaimDetails(string claimNo)
        {
            DataTable dtClmDetails = new DataTable();
            DataManager dm = new DataManager();
            string claimDetails = @"SELECT POL_NO, 
                                   TO_CHAR(DATE_OF_CLAIM, 'YYYY-MM-DD') AS DATE_OF_CLAIM,
                                   CLAIM_TYPE, 
                                   BANK_NAME,
                                   BANK_CODE,
                                   BANK_BRANCH_NAME,
                                   BANK_BRANCH_CODE,
                                   ACC_NO, 
                                   AMOUNT,
                                   PAYEE_NAME, 
                                   PAYMENT_TYPE, 
                                   NIC, 
                                   CONTACT_NO, 
                                   EMAIL_ADD, 
                                   INSURED_NAME, 
                                   EPF, 
                                   ACC_CODE,
                                   VOU_NO,
                                   VOU_STATUS
                            FROM SLIC_CHP.VOU_DETAILS_MAS 
                            WHERE CLAIM_NO = '" + claimNo.Replace("'", "''") + "'";
            dm.readSql(claimDetails);
            DataSet ds = dm.getrow(claimDetails);
            if (ds.Tables.Count > 0)
                dtClmDetails = ds.Tables[0];
            dm.connclose();
            return dtClmDetails;
        }
        public DataTable EditClaimDetail(string vouNo)
        {
            DataTable dtEditDetails = new DataTable();
            DataManager dm = new DataManager();

            string editDetails = @"SELECT POL_NO, 
                                   TO_CHAR(DATE_OF_CLAIM, 'YYYY-MM-DD') AS DATE_OF_CLAIM,
                                   CLAIM_TYPE, 
                                   BANK_NAME,
                                   BANK_CODE,
                                   BANK_BRANCH_NAME,
                                   BANK_BRANCH_CODE,
                                   ACC_NO, 
                                   AMOUNT,
                                   PAYEE_NAME, 
                                   PAYMENT_TYPE, 
                                   NIC, 
                                   CONTACT_NO, 
                                   EMAIL_ADD, 
                                   INSURED_NAME, 
                                   EPF, 
                                   ACC_CODE,
                                   VOU_NO,
                                   VOU_STATUS
                            FROM SLIC_CHP.VOU_DETAILS_MAS 
        WHERE VOU_NO = '" + vouNo.Replace("'", "''") + "'";

            dm.readSql(editDetails);
            DataSet ds = dm.getrow(editDetails);
            if (ds.Tables.Count > 0)
                dtEditDetails = ds.Tables[0];
            dm.connclose();
            return dtEditDetails;
        }
        public string getVouNo(string claimNo)
        {
            string vouNo = "";
            DataManager dm = new DataManager();

            string getVouNo = "select VOU_NO from slic_chp.vou_details_mas where CLAIM_NO = '" + claimNo + "'";
            dm.readSql(getVouNo);
            odrr = dm.oraComm.ExecuteReader();
            while (odrr.Read())
            {
                if (!odrr.IsDBNull(0)) { vouNo = odrr.GetString(0); }
            }
            odrr.Close();
            dm.connclose();
            return vouNo;
        }

        public DataTable getVouDetails(string vouNo)
        {
            DataTable dtClmDetails = new DataTable();
            DataManager dm = new DataManager();

            string claimDetails = @"SELECT POL_NO, 
                                   TO_CHAR(DATE_OF_CLAIM, 'YYYY-MM-DD') AS DATE_OF_CLAIM,
                                   CLAIM_TYPE, 
                                   BANK_NAME, 
                                   BANK_BRANCH_NAME, 
                                   ACC_NO, 
                                   AMOUNT,
                                   PAYEE_NAME, 
                                   PAYMENT_TYPE, 
                                   NIC, 
                                   CONTACT_NO, 
                                   EMAIL_ADD, 
                                   INSURED_NAME, 
                                   EPF, 
                                   ACC_CODE, 
                                   CLAIM_NO,
                                   VOU_CREATED_BY, 
                                   VOU_CREATED_DATE, 
                                   VOU_CREATED_IP, 
                                   INSURED_NAME, 
                                   VOU_PRINTED_BY, 
                                   VOU_PRINTED_DATE, 
                                   VOU_PRINTED_IP,
                                   BANK_CODE, 
                                   BANK_BRANCH_CODE, 
                                   ACC_CODE 
                            FROM SLIC_CHP.VOU_DETAILS_MAS 
                            WHERE VOU_NO = '" + vouNo.Replace("'", "''") + "'";

            dm.readSql(claimDetails);
            DataSet ds = dm.getrow(claimDetails);
            if (ds.Tables.Count > 0)
                dtClmDetails = ds.Tables[0];
            dm.connclose();
            return dtClmDetails;
        }

        public string get_branchName(int branchCode)
        {
            DataManager dm = new DataManager();
            string getVouBranchName = "select BRNAM from GENPAY.BRANCH where BRCOD = " + branchCode + "";
            string branchName = "";
            if (dm.existRecored(getVouBranchName) != 0)
            {
                dm.readSql(getVouBranchName);
                odrr = dm.oraComm.ExecuteReader();
                while (odrr.Read())
                {
                    if (!odrr.IsDBNull(0)) { branchName = odrr.GetString(0); } else { branchName = ""; }
                }
                odrr.Close();
            }
            dm.connclose();
            return branchName;
        }
        /// <summary>
        /// Retrieves all claims for a given NIC that are still editable (voucher not created, or created but not printed/authorized).
        /// </summary>
        public DataTable GetEditableClaimsByNIC(string nic)
        {
            DataTable dt = new DataTable();
            DataManager dm = new DataManager();

            string sql = @"
        SELECT VOU_NO, CLAIM_NO, POL_NO, INSURED_NAME, AMOUNT,PAYEE_NAME,DATE_OF_CLAIM
        FROM SLIC_CHP.VOU_DETAILS_MAS
        WHERE NIC = '" + nic.Replace("'", "''") + @"'
          AND (VOU_STATUS NOT IN ('Vou.Authorized')                   
                   AND VOU_AUTHORIZED_BY IS NULL)
        ORDER BY DATE_OF_CLAIM DESC";

            try
            {
                dm.readSql(sql);
                DataSet ds = dm.getrow(sql);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                dm.connclose();
            }
            return dt;
        }



        /// <summary>
        /// Gets distinct bank list from GENPAY.BNKBRN.
        /// </summary>
        public DataTable GetBanks()
        {
            DataTable dt = new DataTable();
            DataManager dm = new DataManager();
            string sql = "SELECT DISTINCT BCODE AS BANK_CODE, BBNAM AS BANK_NAME FROM GENPAY.BNKBRN ORDER BY BBNAM";
            try
            {
                dm.readSql(sql);
                DataSet ds = dm.getrow(sql);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                dm.connclose();
            }
            return dt;
        }

        /// <summary>
        /// Gets branches for a given bank code.
        /// </summary>
        public DataTable GetBranches(int bankCode)
        {
            DataTable dt = new DataTable();
            DataManager dm = new DataManager();
            string sql = "SELECT BRCODE AS BRANCH_CODE, BBRNCH AS BRANCH_NAME FROM GENPAY.BNKBRN WHERE BCODE = " + bankCode + " ORDER BY BBRNCH";
            try
            {
                dm.readSql(sql);
                DataSet ds = dm.getrow(sql);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                dm.connclose();
            }
            return dt;
        }
    }
}