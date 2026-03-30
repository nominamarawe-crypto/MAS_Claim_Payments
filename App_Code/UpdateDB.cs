using System;
using System.Collections.Generic;

using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace MAS_Claim_Payments.App_Code
{
    public class UpdateDB
    {
        private DataManager dMngrr;
        private GetDBData getDBDtObj;
        public string InsertEntryRec(string nic, string polNo, string clmDt, string clmTyp, int bnkCod,
            int brnchCod, string accNum, double amt, string payeeNm, string payType, string insuredName,
            string epf, string acccCod, string userId, string clmntName, string relashionship, string mobile, string email)
        {
            dMngrr = new DataManager();
            bool ok = false;
            getDBDtObj = new GetDBData();

            string bankName = getDBDtObj.getBankName(bnkCod);
            string branchName = getDBDtObj.getBankBranchName(brnchCod, bnkCod);
            int currentSeqNo = getDBDtObj.getMaxSeq(polNo);

            string claimNo = polNo.Substring(5) + "/" + DateTime.Today.Year.ToString().Substring(2) + "/3/" + (currentSeqNo + 1).ToString().PadLeft(6, '0');

            try
            {
                dMngrr.begintransaction();

                if (currentSeqNo == 0)
                {
                    string insertSeq = "insert into SLIC_CHP.CLAIM_NO_SEQ (GROUP_POLICY_NO, YEAR, CLAIM_TYPE, SEQ_NO) values" +
                        " ('" + polNo.Substring(5) + "', " + DateTime.Today.Year + ", '3'," + (currentSeqNo + 1).ToString() + ")";
                    dMngrr.insertRecords(insertSeq);
                }
                else
                {
                    string updateSeq = "update SLIC_CHP.CLAIM_NO_SEQ set SEQ_NO = " + (currentSeqNo + 1).ToString() +
                        " where GROUP_POLICY_NO = '" + polNo.Substring(5) + "' and YEAR = " + DateTime.Today.Year + " and CLAIM_TYPE = '3'";
                    dMngrr.insertRecords(updateSeq);
                }

                string insertRec = "insert into SLIC_CHP.VOU_DETAILS_MAS (CLAIM_NO, NIC, POL_NO, DATE_OF_CLAIM, CLAIM_TYPE, BANK_NAME, " +
                                    " BANK_CODE, BANK_BRANCH_NAME, BANK_BRANCH_CODE, ACC_NO, AMOUNT, PAYEE_NAME, PAYMENT_TYPE, INSURED_NAME, " +
                                    " EPF, ACC_CODE, DATA_ENTERED_BY, DATA_ENTERED_DATE, CLAIMANT_NAME, RELASHIONSHIP, CONTACT_NO, EMAIL_ADD) values ('" + claimNo + "', '" + nic + "', '" +
                                    polNo + "', to_date('" + clmDt + "', 'YYYY-MM-DD'), '" + clmTyp + "', '" + bankName + "', " + bnkCod + ",'" +
                                    branchName + "', " + brnchCod + ", '" + accNum + "', " + amt + ", '" + payeeNm + "', '" + payType + "', '" +
                                    insuredName + "', '" + epf + "', '" + acccCod + "', '" + userId + "', sysdate, '" + clmntName + "', '" + relashionship + "','" + mobile + "','" + email + "')";
                dMngrr.insertRecords(insertRec);

                dMngrr.commit();
                ok = true;

            }
            catch (Exception ex)
            {
                dMngrr.rollback();
                dMngrr.connClose();
                throw ex;
            }

            dMngrr.connClose();
            string retVal = "";

            if (ok)
            {
                retVal = claimNo;
            }

            return retVal;
        }

        public string createVou(string claimNo, int branchCod, string policyNo, string epf, string machineIp)
        {
            string retVal = "";
            bool ok = false;
            getDBDtObj = new GetDBData();
            int curntVouSeqNo = getDBDtObj.getMaxVouSeq(branchCod);

            string vouNo = branchCod.ToString().PadLeft(3, '0') + "/" + policyNo.Substring(5) + "/" + DateTime.Today.ToString("yyyyMMdd") + (curntVouSeqNo + 1).ToString().PadLeft(5, '0');

            dMngrr = new DataManager();

            try
            {
                dMngrr.begintransaction();

                if (curntVouSeqNo == 0)
                {
                    string insertSeqNo = "insert into LCLM.VOUNO (VUBRNO, VUYEAR, VUTYPE, VOUNO1) values (" + branchCod + ", " + DateTime.Today.Year.ToString() + ", 'W', 1)";
                    dMngrr.insertRecords(insertSeqNo);
                }
                else
                {
                    string updateSeqNo = "update LCLM.VOUNO set VOUNO1 = " + (curntVouSeqNo + 1).ToString() + " where VUBRNO = " + branchCod +
                                        " and VUYEAR = " + DateTime.Today.Year.ToString() + " and VUTYPE = 'W' ";
                    dMngrr.insertRecords(updateSeqNo);
                }


                string updateVouDetails = "update SLIC_CHP.VOU_DETAILS_MAS set VOU_NO = '" + vouNo + "', VOU_CREATED_BY = '" + epf + "', VOU_CREATED_DATE = sysdate, " +
                                        " VOU_CREATED_IP = '" + machineIp + "', VOU_STATUS = 'Vou.Created' where CLAIM_NO = '" + claimNo + "'";
                dMngrr.insertRecords(updateVouDetails);

                dMngrr.commit();
                ok = true;
            }
            catch (Exception ex)
            {
                dMngrr.rollback();
                dMngrr.connClose();
                throw ex;
            }

            if (ok) { retVal = vouNo; }

            dMngrr.connClose();
            return retVal;
        }

        public int update_voucherPrint(string vouNo, string epf, string ip)
        {
            int retVal = 0;
            DataManager dManager = new DataManager();
            string selectSql = "", updateSql = "";

            try
            {
                dManager.begintransaction();

                selectSql = "select * from SLIC_CHP.VOU_DETAILS_MAS where VOU_NO = '" + vouNo +
                            "' and VOU_PRINTED_BY is null and VOU_PRINTED_DATE is null";

                if (dManager.existRecored(selectSql) != 0)
                {
                    updateSql = "update SLIC_CHP.VOU_DETAILS_MAS set VOU_STATUS = 'Vou.Printed', VOU_PRINTED_BY = '" + epf +
                                "' , VOU_PRINTED_DATE = sysdate, VOU_PRINTED_IP = '" + ip + "' where VOU_NO = '" + vouNo +
                                "' and VOU_PRINTED_BY is null and VOU_PRINTED_DATE is null";
                    dManager.insertRecords(updateSql);
                }

                dManager.commit();
                retVal = 1;
            }
            catch (Exception ex)
            {
                dManager.rollback();
                dManager.connclose();
                retVal = 0;
            }

            dManager.connclose();

            return retVal;
        }

        public int AuthorizeVoucher(string vouNo, string epf, string machineIp)
        {
            int retVal = 0;

            string insertToCashBook = "", getAcNo = "", updateVouDetails = "", insertToVouBankDet = "", insertToTempDetl = "", insertToLifeVouDetl = "";
            string vPayMode = "", bankName = "", branchName = "";
            string acNo = "", payMode = "", hName = "", nic_ppt = "", hName1 = "", totAmountStr = "", accode = "", vouAddEPF = "", billDate = "";
            string vouType = "", status = "", insuredName = "", adrs1 = "", adrs2 = "", adrs3 = "", adrs4 = "", recipient = "", paymntMode = "", brCode = "";
            double totAmount = 0, grossAmount = 0;
            string nic = "", passportNo = "", phoneNo = "", vouDate = "", vouPrintDate = "", vouPrintEPF = "";

            GetDBData dbGtObj = new GetDBData();
            FormatData frmtDt = new FormatData();

            DataManager dManager = new DataManager();
            DataTable dtVouDetals = dbGtObj.getVouDetails(vouNo);

            if (dtVouDetals.Rows.Count > 0)
            {
                try
                {
                    dManager.begintransaction();

                    #region CASHBOOK.TEMP_CB 

                    payMode = "D";
                    vPayMode = "SLIP";

                    getAcNo = "select ACC_NO from SLIFCLM.LIFE_ACC_DETAILS where PAY_MODE = '" + vPayMode + "'";
                    if (dManager.existRecored(getAcNo) > 0)
                    {
                        dManager.readSql(getAcNo);
                        OracleDataReader odr = dManager.oraComm.ExecuteReader();
                        while (odr.Read())
                        {
                            if (!odr.IsDBNull(0)) { acNo = odr.GetString(0); }
                        }
                        odr.Close();
                    }

                    bankName = dtVouDetals.Rows[0][3].ToString();
                    branchName = dtVouDetals.Rows[0][4].ToString();


                    hName = bankName + " " + branchName + " A/C-NO " + dtVouDetals.Rows[0][5].ToString();
                    if (hName.Length > 71)
                    {
                        hName = frmtDt.format_hname(hName);
                    }

                    hName1 = dtVouDetals.Rows[0][7].ToString();
                    if (hName1.Length > 65)
                    {
                        hName1 = hName1.Substring(0, 65);
                    }

                    hName = hName.ToUpper();

                    nic = dtVouDetals.Rows[0][9].ToString();

                    brCode = int.Parse(vouNo.Substring(0, 3)).ToString();
                    totAmount = double.Parse(dtVouDetals.Rows[0][6].ToString());
                    //totAmountStr = dsVouDetails.Tables[0].Rows[0]["VOU_AMOUNT"].ToString().PadLeft(21, '*');
                    totAmountStr = (double.Parse(dtVouDetals.Rows[0][6].ToString()).ToString("F")).PadLeft(21, '*');
                    accode = dtVouDetals.Rows[0][26].ToString();
                    vouDate = (Convert.ToDateTime(dtVouDetals.Rows[0][17].ToString())).ToString("yyyyMMdd");
                    vouAddEPF = dtVouDetals.Rows[0][16].ToString();
                    vouType = "MAS";
                    status = "Vou Authorized";
                    insuredName = dtVouDetals.Rows[0][20].ToString();
                    recipient = dtVouDetals.Rows[0][7].ToString();
                    grossAmount = totAmount;
                    paymntMode = "D";
                    vouPrintDate = (Convert.ToDateTime(dtVouDetals.Rows[0][22].ToString())).ToString("yyyyMMdd");
                    vouPrintEPF = dtVouDetals.Rows[0][21].ToString();
                    billDate = dtVouDetals.Rows[0][1].ToString();

                    insertToCashBook = "insert into CASHBOOK.TEMP_CB (CLASS,BUSYCODE,DIVCODE,BCODE,CLAIMNO,POLNO,HNAME,HNAME1," +
                                       "TOTAMOUNT,TOTAMT, ACCODE,ACNO,VOUNO,VOUDATE,BILLDATE,CLAIMTYPE,ADDEPF,VOUTYP,STATUS," +
                                       "PRINT1,AUTHORIZED,DELETED,CHQCAN,PAYAUT, INSNAME,ADD1,ADD2,ADD3,POSTED,REPRINT," +
                                       "VOU_LEVEL,RECIPIENT_NAME,TRANSACTION_TYPE,GROSS_AMOUNT,ADD4," +
                                       "MODE_OF_PAYMENT,AUTHOEPF,AUODATE,VPDATE,VPRINTEPF) " +
                                       "VALUES ('L',3,'L','" + brCode.PadLeft(3, '0') + "','" + dtVouDetals.Rows[0][19].ToString() +
                                       "','" + dtVouDetals.Rows[0][0].ToString() + "','" +
                                       frmtDt.replaceQuote(frmtDt.PrepareApostrophe(hName)) + "','" +
                                       hName1 + "'," + totAmount + ",'" + totAmountStr + "','" + accode + "','" + acNo +
                                       "','" + vouNo + "',to_date('" + vouDate + "','YYYYMMDD'), to_date('" + billDate + "','YYYY-MM-DD'), 'A', '" +
                                       vouAddEPF + "','" + vouType + "','" + status + "',0, 1,0,0,0,'" + insuredName +
                                       "','','','',0,0,'N','" +
                                       recipient + "','A', " + grossAmount + ",'', '" + paymntMode + "','" + epf + "',sysdate,to_date('" +
                                       vouPrintDate + "','YYYYMMDD'),'" + vouPrintEPF + "')";
                    dManager.insertRecords(insertToCashBook);

                    #endregion

                    #region SLIFCLM.FREDM_VOU_DETAILS                    

                    updateVouDetails = "update SLIC_CHP.VOU_DETAILS_MAS set VOU_AUTHORIZED_BY = '" + epf +
                                       "', VOU_AUTHORIZED_DATE = sysdate, VOU_AUTHORIZED_IP = '" + machineIp + "', VOU_STATUS = '" + status +
                                       "', VOU_AUTH_REVS_BY = null, VOU_AUTH_REVS_DATE = null " +
                                       " where VOU_NO = '" + vouNo +
                                       "' and VOU_AUTHORIZED_BY is null and VOU_AUTHORIZED_DATE is null";
                    dManager.insertRecords(updateVouDetails);

                    #endregion

                    #region LPHS.VOUBANKDET

                    phoneNo = dtVouDetals.Rows[0][10].ToString();

                    if (!phoneNo.Equals(""))
                    {
                        insertToVouBankDet = "insert into LPHS.VOUBANKDET (POLICYNO,VOUCHERNO,PAYEENAME,BNKNAME,BNKBRNNAME,SLIACCTNO," +
                                              "CUSTACCTNO,PHONE_NO,BANK_CODE,BANK_BRANCH_CODE,NIC_NO, PASSPORT_NO) VALUES ('" +
                                              dtVouDetals.Rows[0][0].ToString().Substring(5) + "','" + vouNo + "','" +
                                              dtVouDetals.Rows[0][7].ToString() + "','" + frmtDt.replaceQuote(frmtDt.PrepareApostrophe(bankName)) + "','" +
                                              frmtDt.replaceQuote(frmtDt.PrepareApostrophe(branchName)) + "','" + acNo + "','" + dtVouDetals.Rows[0][5].ToString() +
                                              "','" + phoneNo + "','" + dtVouDetals.Rows[0][24].ToString() +
                                              "','" + dtVouDetals.Rows[0][25].ToString() +
                                              "','" + nic + "','" + passportNo + "')";
                    }
                    else
                    {
                        insertToVouBankDet = "insert into LPHS.VOUBANKDET (POLICYNO,VOUCHERNO,PAYEENAME,BNKNAME,BNKBRNNAME,SLIACCTNO," +
                                              "CUSTACCTNO,BANK_CODE,BANK_BRANCH_CODE,NIC_NO, PASSPORT_NO) VALUES ('" +
                                              dtVouDetals.Rows[0][0].ToString().Substring(5) + "','" + vouNo + "','" +
                                              dtVouDetals.Rows[0][7].ToString() + "','" + frmtDt.replaceQuote(frmtDt.PrepareApostrophe(bankName)) + "','" +
                                              frmtDt.replaceQuote(frmtDt.PrepareApostrophe(branchName)) + "','" + acNo + "','" + dtVouDetals.Rows[0][5].ToString() +
                                              "','" + dtVouDetals.Rows[0][24].ToString() +
                                              "','" + dtVouDetals.Rows[0][25].ToString() +
                                              "','" + nic + "','" + passportNo + "')";
                    }

                    dManager.insertRecords(insertToVouBankDet);

                    #endregion

                    #region CASHBOOK.TEMP_DETL

                    insertToTempDetl = "insert into CASHBOOK.TEMP_DETL (VOUNO,ACCODE,AMOUNT,VATGEN,VATLIFE,TOTAL,BRANCH_CODE,ACCOUNT_DATE) " +
                                       "VALUES ('" + vouNo + "','" + accode + "'," + totAmount + ",0,0," + totAmount + "," +
                                       int.Parse(brCode) + ",sysdate)";
                    dManager.insertRecords(insertToTempDetl);

                    #endregion                    

                    if (payMode.Equals("D"))
                    {

                        string annNum = "0";

                        string insertToSlipDetails = "insert into LCLM.CLAIM_SLIP_DETAILS (CLAIM_TYPE,POLICY_NO,VOUCHER_NO,BANK_CODE," +
                                "BANK_BRANCH,ACCOUNT_NO,PAY_TYPE,BRANCH,VOUCHER_CRET_EPF,NAME,MOBILE_NO,NIC,ANNUITY_NO, CLM_AMTAT_EXTRACT, ACCOUNT_NO_STRING) VALUES " + "('W'," +
                                int.Parse(dtVouDetals.Rows[0][0].ToString().Substring(5)) + ",'" + vouNo + "','" +
                                dtVouDetals.Rows[0][24].ToString() + "','" +
                                dtVouDetals.Rows[0][25].ToString() + "','" +
                                dtVouDetals.Rows[0][5].ToString() + "','D'," +
                                int.Parse(brCode) + ",'" +
                                vouAddEPF + "','" + hName1 + "','" + dtVouDetals.Rows[0][10].ToString() +
                                "','" + nic + "'," + int.Parse(annNum) + "," + totAmount + ",'" + dtVouDetals.Rows[0][5].ToString() + "')";
                        dManager.insertRecords(insertToSlipDetails);
                    }

                    retVal = 1;
                    dManager.commit();
                }
                catch (Exception ex)
                {
                    dManager.rollback();
                    dManager.connclose();
                    retVal = 0;
                }
            }
            else
            {
                retVal = 0;
            }

            dManager.connclose();
            return retVal;
        }

        public int uploadData(DataTable dt, string userId, out int sucsCount, out DataTable dtExistingRecords)
        {
            int retVal = 0;
            sucsCount = 0;

            DataTable dtExRecords = new DataTable();
            dtExRecords.Columns.Add("SBU", typeof(string));
            dtExRecords.Columns.Add("EPF", typeof(string));
            dtExRecords.Columns.Add("MEMBER_NAME", typeof(string));
            dtExRecords.Columns.Add("NIC", typeof(string));
            dtExRecords.Columns.Add("GENDER", typeof(string));
            dtExRecords.Columns.Add("DATE_OF_BIRTH", typeof(string));
            dtExRecords.Columns.Add("CONTACT_NO", typeof(string));
            dtExRecords.Columns.Add("EMAIL", typeof(string));

            DataManager dmngr = new DataManager();

            try
            {
                if (dt.Rows.Count > 0)
                {
                    dmngr.begintransaction();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int dateStringLength = dt.Rows[i].ItemArray[5].ToString().Length;
                        int firstStrokeIndex = dt.Rows[i].ItemArray[5].ToString().IndexOf("/");
                        string monthString = dt.Rows[i].ItemArray[5].ToString().Substring(0, firstStrokeIndex);

                        int secondStrokeIndex = dt.Rows[i].ItemArray[5].ToString().Substring(firstStrokeIndex + 1).IndexOf("/");
                        string dayString = dt.Rows[i].ItemArray[5].ToString().Substring(firstStrokeIndex + 1).Substring(0, secondStrokeIndex);

                        string yearString = dt.Rows[i].ItemArray[5].ToString().Substring(firstStrokeIndex + 1).Substring(secondStrokeIndex + 1, 4);

                        string dateToSave = yearString + "-" + monthString.PadLeft(2, '0') + "-" + dayString.PadLeft(2, '0');

                        string checkExists = "";

                        if (dt.Rows[i].ItemArray[6].ToString() != "" && dt.Rows[i].ItemArray[7].ToString() != "")
                        {
                            checkExists = "select * from slic_chp.group_master " +
                                " where SBU = '" + dt.Rows[i].ItemArray[0].ToString() + "' " +
                                " and EPF = '" + dt.Rows[i].ItemArray[1].ToString() + "'" +
                                " and MEMBER_NAME = '" + dt.Rows[i].ItemArray[2].ToString() + "'" +
                                " and NIC = '" + dt.Rows[i].ItemArray[3].ToString() + "'" +
                                " and GENDER = '" + dt.Rows[i].ItemArray[4].ToString() + "'" +
                                " and DATE_OF_BIRTH = '" + dateToSave + "'" +
                                " and CONTACT_NO = '" + dt.Rows[i].ItemArray[6].ToString() + "'" +
                                " and EMAIL = '" + dt.Rows[i].ItemArray[7].ToString() + "'";
                        }
                        else if (dt.Rows[i].ItemArray[6].ToString() == "" && dt.Rows[i].ItemArray[7].ToString() != "")
                        {
                            checkExists = "select * from slic_chp.group_master " +
                                " where SBU = '" + dt.Rows[i].ItemArray[0].ToString() + "' " +
                                " and EPF = '" + dt.Rows[i].ItemArray[1].ToString() + "'" +
                                " and MEMBER_NAME = '" + dt.Rows[i].ItemArray[2].ToString() + "'" +
                                " and NIC = '" + dt.Rows[i].ItemArray[3].ToString() + "'" +
                                " and GENDER = '" + dt.Rows[i].ItemArray[4].ToString() + "'" +
                                " and DATE_OF_BIRTH = '" + dateToSave + "'" +
                                " and CONTACT_NO  is null " +
                                " and EMAIL = '" + dt.Rows[i].ItemArray[7].ToString() + "'";
                        }
                        else if (dt.Rows[i].ItemArray[6].ToString() != "" && dt.Rows[i].ItemArray[7].ToString() == "")
                        {
                            checkExists = "select * from slic_chp.group_master " +
                                " where SBU = '" + dt.Rows[i].ItemArray[0].ToString() + "' " +
                                " and EPF = '" + dt.Rows[i].ItemArray[1].ToString() + "'" +
                                " and MEMBER_NAME = '" + dt.Rows[i].ItemArray[2].ToString() + "'" +
                                " and NIC = '" + dt.Rows[i].ItemArray[3].ToString() + "'" +
                                " and GENDER = '" + dt.Rows[i].ItemArray[4].ToString() + "'" +
                                " and DATE_OF_BIRTH = '" + dateToSave + "'" +
                                " and CONTACT_NO = '" + dt.Rows[i].ItemArray[6].ToString() + "'" +
                                " and EMAIL is null ";
                        }
                        else
                        {
                            checkExists = "select * from slic_chp.group_master " +
                                " where SBU = '" + dt.Rows[i].ItemArray[0].ToString() + "' " +
                                " and EPF = '" + dt.Rows[i].ItemArray[1].ToString() + "'" +
                                " and MEMBER_NAME = '" + dt.Rows[i].ItemArray[2].ToString() + "'" +
                                " and NIC = '" + dt.Rows[i].ItemArray[3].ToString() + "'" +
                                " and GENDER = '" + dt.Rows[i].ItemArray[4].ToString() + "'" +
                                " and DATE_OF_BIRTH = '" + dateToSave + "'" +
                                " and CONTACT_NO is null " +
                                " and EMAIL is null ";
                        }


                        if (dmngr.existRecored(checkExists) > 0)
                        {
                            dtExRecords.Rows.Add(dt.Rows[i].ItemArray[0].ToString().ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(),
                                    dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dateToSave, dt.Rows[i].ItemArray[6].ToString(),
                                    dt.Rows[i].ItemArray[7].ToString());
                        }
                        else
                        {
                            string insertRecord = "insert into slic_chp.group_master (SBU, EPF, MEMBER_NAME, NIC, GENDER, DATE_OF_BIRTH, CONTACT_NO, EMAIL) values ('" +
                                                    dt.Rows[i].ItemArray[0].ToString().ToString() + "','" + dt.Rows[i].ItemArray[1].ToString() + "','" +
                                                    dt.Rows[i].ItemArray[2].ToString() + "','" + dt.Rows[i].ItemArray[3].ToString() + "','" +
                                                    dt.Rows[i].ItemArray[4].ToString() + "','" + dateToSave + "','" +
                                                    dt.Rows[i].ItemArray[6].ToString() + "','" + dt.Rows[i].ItemArray[7].ToString() + "')";
                            dmngr.insertRecords(insertRecord);

                            sucsCount = sucsCount + 1;
                        }
                    }
                    dmngr.commit();
                    retVal = 1;
                }
            }
            catch (Exception ex)
            {
                dmngr.rollback();
                dmngr.connClose();
                retVal = 0;
            }

            dmngr.connClose();

            dtExistingRecords = dtExRecords;
            return retVal;
        }

        public bool UpdateClaimDetails(string claimNo, int bankCode, int branchCode, string accountNo, string contactNo, string email, string editedBy, string editedIP, out string message)
        {
            bool success = false;
            message = "";
            DataManager dm = new DataManager();
            GetDBData dbGt = new GetDBData();

            try
            {
                // 1. Verify the claim exists
                string checkSql = "SELECT COUNT(*) FROM SLIC_CHP.VOU_DETAILS_MAS WHERE CLAIM_NO = :claimNo";
                dm.readSql(checkSql);
                dm.oraComm.Parameters.Clear();
                dm.oraComm.Parameters.Add("claimNo", OracleType.VarChar).Value = claimNo;
                int count = Convert.ToInt32(dm.oraComm.ExecuteScalar());
                if (count == 0)
                {
                    message = "Claim number not found.";
                    return false;
                }

                // 2. Fetch current record for archiving
                string selectSql = @"SELECT VOU_NO, POL_NO, CLAIM_NO, DATE_OF_CLAIM, CLAIM_TYPE, BANK_NAME, BANK_CODE,
                             BANK_BRANCH_NAME, BANK_BRANCH_CODE, ACC_NO, AMOUNT, PAYEE_NAME, PAYMENT_TYPE, NIC,
                             CONTACT_NO, EMAIL_ADD, VOU_CREATED_BY, VOU_CREATED_DATE, VOU_CREATED_IP,
                             VOU_PRINTED_BY, VOU_PRINTED_DATE, VOU_PRINTED_IP, VOU_AUTHORIZED_BY, VOU_AUTHORIZED_DATE,
                             VOU_AUTHORIZED_IP, INSURED_NAME, VOU_REVERSED_BY, VOU_REVERSED_DATE, VOU_REVERSED_IP,
                             EPF, ACC_CODE, VOU_STATUS, DATA_ENTERED_BY, DATA_ENTERED_DATE, VOU_AUTH_REVS_BY,
                             VOU_AUTH_REVS_DATE, CLAIMANT_NAME, RELASHIONSHIP
                      FROM SLIC_CHP.VOU_DETAILS_MAS
                      WHERE CLAIM_NO = :claimNo";

                dm.readSql(selectSql);
                dm.oraComm.Parameters.Clear();
                dm.oraComm.Parameters.Add("claimNo", OracleType.VarChar).Value = claimNo;
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    message = "Could not retrieve current record.";
                    return false;
                }

                // 3. Build insert into history table
                string insertHistSql = @"
            INSERT INTO SLIC_CHP.VOU_DETAILS_MAS_HIST
            (VOU_NO, POL_NO, CLAIM_NO, DATE_OF_CLAIM, CLAIM_TYPE, BANK_NAME, BANK_CODE,
             BANK_BRANCH_NAME, BANK_BRANCH_CODE, ACC_NO, AMOUNT, PAYEE_NAME, PAYMENT_TYPE, NIC,
             CONTACT_NO, EMAIL_ADD, VOU_CREATED_BY, VOU_CREATED_DATE, VOU_CREATED_IP,
             VOU_PRINTED_BY, VOU_PRINTED_DATE, VOU_PRINTED_IP, VOU_AUTHORIZED_BY, VOU_AUTHORIZED_DATE,
             VOU_AUTHORIZED_IP, INSURED_NAME, VOU_REVERSED_BY, VOU_REVERSED_DATE, VOU_REVERSED_IP,
             EPF, ACC_CODE, VOU_STATUS, DATA_ENTERED_BY, DATA_ENTERED_DATE, VOU_AUTH_REVS_BY,
             VOU_AUTH_REVS_DATE, CLAIMANT_NAME, RELASHIONSHIP,
             VOU_EDITED_BY, VOU_EDITED_DATE, VOU_EDITED_IP)
            VALUES
            (:VOU_NO, :POL_NO, :CLAIM_NO, :DATE_OF_CLAIM, :CLAIM_TYPE, :BANK_NAME, :BANK_CODE,
             :BANK_BRANCH_NAME, :BANK_BRANCH_CODE, :ACC_NO, :AMOUNT, :PAYEE_NAME, :PAYMENT_TYPE, :NIC,
             :CONTACT_NO, :EMAIL_ADD, :VOU_CREATED_BY, :VOU_CREATED_DATE, :VOU_CREATED_IP,
             :VOU_PRINTED_BY, :VOU_PRINTED_DATE, :VOU_PRINTED_IP, :VOU_AUTHORIZED_BY, :VOU_AUTHORIZED_DATE,
             :VOU_AUTHORIZED_IP, :INSURED_NAME, :VOU_REVERSED_BY, :VOU_REVERSED_DATE, :VOU_REVERSED_IP,
             :EPF, :ACC_CODE, :VOU_STATUS, :DATA_ENTERED_BY, :DATA_ENTERED_DATE, :VOU_AUTH_REVS_BY,
             :VOU_AUTH_REVS_DATE, :CLAIMANT_NAME, :RELASHIONSHIP,
             :VOU_EDITED_BY, :VOU_EDITED_DATE, :VOU_EDITED_IP)";

                // Get bank and branch names for update (will also be used for the updated record)
                string bankName = dbGt.getBankName(bankCode);
                string branchName = dbGt.getBankBranchName(branchCode, bankCode);

                // Start transaction
                dm.begintransaction();

                // Insert into history
                using (OracleCommand cmdHist = new OracleCommand(insertHistSql, dm.oraConn))
                {
                    cmdHist.Transaction = dm.oraTrans;

                    // Map current values from reader
                    cmdHist.Parameters.Add("VOU_NO", OracleType.VarChar).Value = reader["VOU_NO"];
                    cmdHist.Parameters.Add("POL_NO", OracleType.VarChar).Value = reader["POL_NO"];
                    cmdHist.Parameters.Add("CLAIM_NO", OracleType.VarChar).Value = reader["CLAIM_NO"];
                    cmdHist.Parameters.Add("DATE_OF_CLAIM", OracleType.DateTime).Value = reader["DATE_OF_CLAIM"];
                    cmdHist.Parameters.Add("CLAIM_TYPE", OracleType.VarChar).Value = reader["CLAIM_TYPE"];
                    cmdHist.Parameters.Add("BANK_NAME", OracleType.VarChar).Value = reader["BANK_NAME"];
                    cmdHist.Parameters.Add("BANK_CODE", OracleType.Number).Value = reader["BANK_CODE"];
                    cmdHist.Parameters.Add("BANK_BRANCH_NAME", OracleType.VarChar).Value = reader["BANK_BRANCH_NAME"];
                    cmdHist.Parameters.Add("BANK_BRANCH_CODE", OracleType.Number).Value = reader["BANK_BRANCH_CODE"];
                    cmdHist.Parameters.Add("ACC_NO", OracleType.VarChar).Value = reader["ACC_NO"];
                    cmdHist.Parameters.Add("AMOUNT", OracleType.VarChar).Value = reader["AMOUNT"];  // keep as string from DB
                    cmdHist.Parameters.Add("PAYEE_NAME", OracleType.VarChar).Value = reader["PAYEE_NAME"];
                    cmdHist.Parameters.Add("PAYMENT_TYPE", OracleType.VarChar).Value = reader["PAYMENT_TYPE"];
                    cmdHist.Parameters.Add("NIC", OracleType.VarChar).Value = reader["NIC"];
                    cmdHist.Parameters.Add("CONTACT_NO", OracleType.VarChar).Value = reader["CONTACT_NO"];
                    cmdHist.Parameters.Add("EMAIL_ADD", OracleType.VarChar).Value = reader["EMAIL_ADD"];
                    cmdHist.Parameters.Add("VOU_CREATED_BY", OracleType.VarChar).Value = reader["VOU_CREATED_BY"];
                    cmdHist.Parameters.Add("VOU_CREATED_DATE", OracleType.DateTime).Value = reader["VOU_CREATED_DATE"];
                    cmdHist.Parameters.Add("VOU_CREATED_IP", OracleType.VarChar).Value = reader["VOU_CREATED_IP"];
                    cmdHist.Parameters.Add("VOU_PRINTED_BY", OracleType.VarChar).Value = reader["VOU_PRINTED_BY"];
                    cmdHist.Parameters.Add("VOU_PRINTED_DATE", OracleType.DateTime).Value = reader["VOU_PRINTED_DATE"];
                    cmdHist.Parameters.Add("VOU_PRINTED_IP", OracleType.VarChar).Value = reader["VOU_PRINTED_IP"];
                    cmdHist.Parameters.Add("VOU_AUTHORIZED_BY", OracleType.VarChar).Value = reader["VOU_AUTHORIZED_BY"];
                    cmdHist.Parameters.Add("VOU_AUTHORIZED_DATE", OracleType.DateTime).Value = reader["VOU_AUTHORIZED_DATE"];
                    cmdHist.Parameters.Add("VOU_AUTHORIZED_IP", OracleType.VarChar).Value = reader["VOU_AUTHORIZED_IP"];
                    cmdHist.Parameters.Add("INSURED_NAME", OracleType.VarChar).Value = reader["INSURED_NAME"];
                    cmdHist.Parameters.Add("VOU_REVERSED_BY", OracleType.VarChar).Value = reader["VOU_REVERSED_BY"];
                    cmdHist.Parameters.Add("VOU_REVERSED_DATE", OracleType.DateTime).Value = reader["VOU_REVERSED_DATE"];
                    cmdHist.Parameters.Add("VOU_REVERSED_IP", OracleType.VarChar).Value = reader["VOU_REVERSED_IP"];
                    cmdHist.Parameters.Add("EPF", OracleType.VarChar).Value = reader["EPF"];
                    cmdHist.Parameters.Add("ACC_CODE", OracleType.VarChar).Value = reader["ACC_CODE"];
                    cmdHist.Parameters.Add("VOU_STATUS", OracleType.VarChar).Value = reader["VOU_STATUS"];
                    cmdHist.Parameters.Add("DATA_ENTERED_BY", OracleType.VarChar).Value = reader["DATA_ENTERED_BY"];
                    cmdHist.Parameters.Add("DATA_ENTERED_DATE", OracleType.DateTime).Value = reader["DATA_ENTERED_DATE"];
                    cmdHist.Parameters.Add("VOU_AUTH_REVS_BY", OracleType.VarChar).Value = reader["VOU_AUTH_REVS_BY"];
                    cmdHist.Parameters.Add("VOU_AUTH_REVS_DATE", OracleType.DateTime).Value = reader["VOU_AUTH_REVS_DATE"];
                    cmdHist.Parameters.Add("CLAIMANT_NAME", OracleType.VarChar).Value = reader["CLAIMANT_NAME"];
                    cmdHist.Parameters.Add("RELASHIONSHIP", OracleType.VarChar).Value = reader["RELASHIONSHIP"];

                    // Audit fields for edit
                    cmdHist.Parameters.Add("VOU_EDITED_BY", OracleType.VarChar).Value = editedBy;
                    cmdHist.Parameters.Add("VOU_EDITED_DATE", OracleType.DateTime).Value = DateTime.Now;
                    cmdHist.Parameters.Add("VOU_EDITED_IP", OracleType.VarChar).Value = editedIP;

                    cmdHist.ExecuteNonQuery();
                }

                reader.Close();

                // 4. Update the main table with new values
                string updateSql = @"UPDATE SLIC_CHP.VOU_DETAILS_MAS 
                             SET BANK_NAME = :bankName,
                                 BANK_CODE = :bankCode,
                                 BANK_BRANCH_NAME = :branchName,
                                 BANK_BRANCH_CODE = :branchCode,
                                 ACC_NO = :accountNo,
                                 CONTACT_NO = :contactNo,
                                 EMAIL_ADD = :email
                             WHERE CLAIM_NO = :claimNo";

                using (OracleCommand cmdUpdate = new OracleCommand(updateSql, dm.oraConn))
                {
                    cmdUpdate.Transaction = dm.oraTrans;
                    cmdUpdate.Parameters.AddWithValue(":bankName", bankName);
                    cmdUpdate.Parameters.AddWithValue(":bankCode", bankCode);
                    cmdUpdate.Parameters.AddWithValue(":branchName", branchName);
                    cmdUpdate.Parameters.AddWithValue(":branchCode", branchCode);
                    cmdUpdate.Parameters.AddWithValue(":accountNo", accountNo);
                    cmdUpdate.Parameters.AddWithValue(":contactNo", contactNo);
                    cmdUpdate.Parameters.AddWithValue(":email", email);
                    cmdUpdate.Parameters.AddWithValue(":claimNo", claimNo);

                    int rowsAffected = cmdUpdate.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                        message = "Updated successfully.";
                    }
                    else
                    {
                        // Claim exists but no rows updated – all values were already the same
                        success = true;
                        message = "No changes detected; claim data is already up-to-date.";
                    }
                }

                dm.commit();
            }
            catch (Exception ex)
            {
                dm.rollback();
                success = false;
                message = "Database error: " + ex.Message;
            }
            finally
            {
                dm.connclose();
            }
            return success;
        }
    }
}