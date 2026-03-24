using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Execute_sql
/// </summary>
public class Execute_sql
{
    public string GetBranch(int brcode)
    {

        string sql = string.Empty;

        sql = "SELECT BRCOD, BRNAM, BRCOD||' - '||BRNAM AS ALLNAME FROM genpay.branch ";
        if (brcode == 10)
        {
            sql += "WHERE BRCOD != 0 ";
        }
        else
        {
            sql += "WHERE BRCOD = " + brcode + " ";
            sql += "AND BRCOD != 0 ";
        }
        sql += "GROUP BY BRCOD, BRNAM ";
        sql += "ORDER BY BRNAM ASC";
        return sql;
    }

    public string GetBranch()
    {

        string sql = string.Empty;

        sql = "SELECT BRCOD, BRNAM FROM genpay.branch ";
        sql += "WHERE BRCOD != 0 ";
        sql += "GROUP BY BRCOD, BRNAM ";
        sql += "ORDER BY BRNAM ASC";

        return sql;
    }

    public string GetYear()
    {
        string sql = string.Empty;

        sql = "select n as yearValId, n as yearVal ";
        sql += "from ";
        sql += "(select rownum n from dual connect by level <= to_number(to_char(sysdate, 'YYYY')) + 3) ";
        sql += "where n >= (to_number(to_char(sysdate, 'YYYY'))) ";
        sql += "order by yearValId asc";

        return sql;
    }

    public string GetDistrict()
    {
        string sql = string.Empty;
        sql = "select district_id, description from SLISCHOOL.District ";
        sql += "where is_active = 'Y' ";
        sql += "order by description asc";
        return sql;
    }

    public string GetMonth()
    {
        string sql = string.Empty;

        sql = "select to_char(add_months(trunc(sysdate, 'yyyy'), level - 1), 'MM') as mnVal, ";
        sql += "to_char(add_months(trunc(sysdate, 'yyyy'), level - 1), 'MONTH') as mnName ";
        sql += "from dual ";
        sql += "connect by level <= 12 ";
        sql += "order by mnVal asc";

        return sql;
    }  

    public string GetAgentDetails(int agentCode)
    {
        string sql = string.Empty;
        sql = "select trim(tb.agency) as agency, trim(tb.int) as inti, trim(tb.name) as name, trim(tb.status) as status, trim(tb.phmob) as phone, ";
        sql += "(trim(tb.status)||' ' ||trim(tb.int)||' '|| trim(tb.name)) as fullName ";
        sql += "from AGENT.AGENT tb ";
        sql += "where tb.agency = "+ agentCode + "";
    return sql;
    }    

    public string GetAuthorityLeval( string userId)
    {
        string sql = string.Empty;

        sql = "SELECT dh.usr_lvl_no ";
        sql += "FROM SLIC_PA.PA_DEPT_HIERARCHY dh ";
        sql += "where dh.usr_epf = '"+ userId + "' ";
        sql += "and dh.is_active = 'Y'";
        return sql;
    }

    public string GetLevalsComments(string refNo)
    {
        string sql = string.Empty;
        sql = "select jh.jh_pol_no, jh.jh_chk_leaval, jh.jh_comment, case jh.jh_action when 'F' then 'Forwarded to Review' ";
        sql += "when 'R' then 'Reverse to Review' ";
        sql += "when 'C' then 'Confirmed' ";
        sql += "end as lastStatus, ";
        sql += "jh.jh_main_leaval, to_char(jh.created_on,'dd/mm/yyyy') as createdDate, jh.created_by ";
        sql += "from SLIC_PA.JANA_CHECKING_HIST jh ";
        sql += "where jh.jh_ref = '"+ refNo + "' ";
        sql += "order by jh.jh_seq asc";
        return sql;
    }

    public string getPaymentsToConfirm(string dateFrom, string dateTo)
    {
        string sql = string.Empty;
        sql = "select E.POLICY_NO, C.CORPORATE_NAME, E.CLAIM_REF_NO, E.EMP_ID, E.DEP_ID, to_char(E.AMOUNT, '99999999.99') AMOUNT ";
        sql += " from SLIC_CHP.PAYMENT_MAST E, SLIC_CHP.CORPORATE_MAST C ";
        sql += " where E.POLICY_NO = C.POLICY_NO ";        
        sql += " and to_number(to_char(E.ENTERED_DATE,'YYYYMMDD')) <= " + dateTo + "";
        sql += " and to_number(to_char(E.ENTERED_DATE,'YYYYMMDD')) >= " + dateFrom + "";
        sql += " and C.IS_ACTIVE = 'Y' ";
        sql += " and E.STATUS = 0 ";
        sql += " and E.PAYMENT_CONF_BY is null ";
        sql += " and E.PAYMENT_CONF_DATE is null ";
        sql += " order by E.POLICY_NO, C.CORPORATE_NAME, E.CLAIM_REF_NO";
        return sql;
    }

    public string getClaimDetailsToPayConfirm(string policyNo, string claimRefNo, string empID, string depID)
    {
        string sql = string.Empty;
        sql = "select CONCAT(CONCAT(E.EMP_TITLE,' '), E.EMP_FULLNAME) EMP_NAME, CONCAT(CONCAT(D.DEPENDANT_TITLE, ' '), D.DEPENDANT_NAME) DEP_NAME, D.RELATIONSHIP, P.AMOUNT, E.CONTACT_NO, E.EMAIL_ADDR ";
        sql += " from SLIC_CHP.PAYMENT_MAST P, SLIC_CHP.CORPORATE_MAST C, SLIC_CHP.EMP_MAST E, SLIC_CHP.DEPENDANTS_MAST D ";
        sql += " where P.POLICY_NO = C.POLICY_NO ";
        sql += " and P.POLICY_NO = E.POLICY_NO ";
        sql += " and P.EMP_ID = E.EMP_ID "; 
        sql += " and P.EMP_ID = D.EMP_ID ";
        sql += " and P.DEP_ID = to_char(D.DEPENDANT_NO) ";
        sql += " and P.POLICY_NO = '" + policyNo + "' ";
        sql += " and P.EMP_ID = '" + empID + "' ";
        sql += " and P.CLAIM_REF_NO = '" + claimRefNo + "'";
        sql += " and P.DEP_ID = '" + depID + "' ";
        sql += " and C.IS_ACTIVE = 'Y' ";
        sql += " and E.IS_ACTIVE = 'Y' ";
        sql += " and D.IS_ACT = 'Y' ";
        sql += " and P.ENTERED_BY is not null ";
        sql += " and P.ENTERED_DATE is not null ";
        sql += " and P.PAYMENT_CONF_BY is null " ;
        sql += " and P.PAYMENT_CONF_DATE is null" ;
        sql += " union all ";
        sql += " select CONCAT(CONCAT(E.EMP_TITLE,' '), E.EMP_FULLNAME) EMP_NAME, CONCAT(CONCAT(E.EMP_TITLE,' '), E.EMP_FULLNAME) DEP_NAME, 'Self' RELATIONSHIP, P.AMOUNT, E.CONTACT_NO, E.EMAIL_ADDR ";
        sql += " from SLIC_CHP.PAYMENT_MAST P, SLIC_CHP.CORPORATE_MAST C, SLIC_CHP.EMP_MAST E ";
        sql += " where P.POLICY_NO = C.POLICY_NO ";
        sql += " and P.POLICY_NO = E.POLICY_NO ";  
        sql += " and P.EMP_ID = E.EMP_ID "; 
        sql += " and P.POLICY_NO = '" + policyNo + "'";
        sql += " and P.EMP_ID = '" + empID + "'";
        sql += " and P.CLAIM_REF_NO = '" + claimRefNo + "'";
        sql += " and P.DEP_ID = '1'";
        sql += " and C.IS_ACTIVE = 'Y'";
        sql += " and E.IS_ACTIVE = 'Y'";
        sql += " and P.ENTERED_BY is not null ";
        sql += " and P.ENTERED_DATE is not null ";
        sql += " and P.PAYMENT_CONF_BY is null ";
        sql += " and P.PAYMENT_CONF_DATE is null";
        return sql;
    }

    public string getClaimDetailsToCreateVous(string policyNo, string claimRefNo, string empID, string depID)
    {
        string sql = string.Empty;
        sql = "select CONCAT(CONCAT(E.EMP_TITLE,' '), E.EMP_FULLNAME) EMP_NAME, CONCAT(CONCAT(D.DEPENDANT_TITLE, ' '), D.DEPENDANT_NAME) DEP_NAME, D.RELATIONSHIP, P.AMOUNT, E.CONTACT_NO, ";
        sql += " E.EMAIL_ADDR, P.BANK_NAME, P.BANK_BRANCH_NAME, P.ACCOUNT_NO, P.BANK_CODE, P.BANK_BRANCH_CODE, P.PAYEE_NAME ";
        sql += " from SLIC_CHP.PAYMENT_MAST P, SLIC_CHP.CORPORATE_MAST C, SLIC_CHP.EMP_MAST E, SLIC_CHP.DEPENDANTS_MAST D ";
        sql += " where P.POLICY_NO = C.POLICY_NO ";
        sql += " and P.POLICY_NO = E.POLICY_NO ";
        sql += " and P.EMP_ID = E.EMP_ID ";
        sql += " and P.EMP_ID = D.EMP_ID ";
        sql += " and P.DEP_ID = to_char(D.DEPENDANT_NO) ";
        sql += " and P.POLICY_NO = '" + policyNo + "' ";
        sql += " and P.EMP_ID = '" + empID + "' ";
        sql += " and P.CLAIM_REF_NO = '" + claimRefNo + "'";
        sql += " and P.DEP_ID = '" + depID + "' ";
        sql += " and C.IS_ACTIVE = 'Y' ";
        sql += " and E.IS_ACTIVE = 'Y' ";
        sql += " and D.IS_ACT = 'Y' ";
        sql += " and P.ENTERED_BY is not null ";
        sql += " and P.ENTERED_DATE is not null ";
        sql += " and P.PAYMENT_CONF_BY is not null ";
        sql += " and P.PAYMENT_CONF_DATE is not null";
        sql += " union ";
        sql += " select distinct CONCAT(CONCAT(E.EMP_TITLE,' '), E.EMP_FULLNAME) EMP_NAME, CONCAT(CONCAT(E.EMP_TITLE,' '), E.EMP_FULLNAME) DEP_NAME, 'Self' RELATIONSHIP , P.AMOUNT, E.CONTACT_NO, ";
        sql += " E.EMAIL_ADDR, P.BANK_NAME, P.BANK_BRANCH_NAME, P.ACCOUNT_NO, P.BANK_CODE, P.BANK_BRANCH_CODE, P.PAYEE_NAME  ";
        sql += " from SLIC_CHP.PAYMENT_MAST P, SLIC_CHP.CORPORATE_MAST C, SLIC_CHP.EMP_MAST E ";
        sql += " where P.POLICY_NO = C.POLICY_NO  and P.POLICY_NO = E.POLICY_NO  and P.EMP_ID = E.EMP_ID ";        
        sql += " and P.POLICY_NO = '" + policyNo + "'";
        sql += " and P.EMP_ID = '" + empID + "' ";
        sql += " and P.CLAIM_REF_NO = '" + claimRefNo + "' ";
        sql += " and P.DEP_ID = '1' ";
        sql += " and C.IS_ACTIVE = 'Y'";
        sql += " and E.IS_ACTIVE = 'Y' ";        
        sql += " and P.ENTERED_BY is not null";
        sql += " and P.ENTERED_DATE is not null";
        sql += " and P.PAYMENT_CONF_BY is not null ";
        sql += " and P.PAYMENT_CONF_DATE is not null ";

        return sql;
    }

    public string getBankDetails(string policyNo, string empID)
    {
        string sql = string.Empty;
        sql = "select BANK_NAME,  BANK_CODE , BRN_NAME, BRN_CODE, ACC_NO ";
        sql += " from SLIC_CHP.ACCOUNTS_MAST A, SLIC_CHP.EMP_MAST E ";
        sql += " where A.EMP_ID = E.EMP_ID ";
        sql += " and A.EMP_ID = '" + empID + "' ";
        sql += " and E.POLICY_NO = '" + policyNo + "' ";
        return sql;
    }

    public string getHospitalDetails(string claimNo)
    {
        string sql = string.Empty;
        sql = "select HOS_NAME ";
        sql += " from slic_chp.call_center_claim_intimation C , LCLM.AROGYA_HOSPITAL A ";
        sql += " where c.h_id = a.hos_id ";
        sql += " and c.h_type = a.hos_type ";
        sql += " and c.intim_id = '" + claimNo + "'";
        return sql;
    }

    public string getNIC(string policyNo, string empID)
    {
        string sql = string.Empty;
        sql = "select CONCAT(CONCAT(BANK_NAME, ' - '), BANK_CODE) BANK, CONCAT(CONCAT(BRN_NAME, ' - '), BRN_CODE) BRANCH, ACC_NO ";
        sql += " from SLIC_CHP.ACCOUNTS_MAST A, SLIC_CHP.EMP_MAST E ";
        sql += " where A.EMP_ID = E.EMP_ID ";
        sql += " and A.EMP_ID = '" + empID + "' ";
        sql += " and E.POLICY_NO = '" + policyNo + "' ";
        return sql;
    }

    public string getEmpNIC(string policyNo, string empID)
    {
        string sql = string.Empty;
        sql = "select EMP_NIC from SLIC_CHP.EMP_MAST ";
        sql += " where POLICY_NO = '" + policyNo + "' ";
        sql += " and EMP_ID = '" + empID + "'";
        return sql;
    }

    public string getBankCode(string bankName)
    {
        string sql = string.Empty;
        sql = "select distinct BCODE ";
        sql += " from genpay.bnkbrn ";
        sql += " where UPPER(BBNAM) = '" + bankName.ToUpper() + "'";
        return sql;
    }

    public string getBankBranchCode(string bankName, string branchName)
    {
        string sql = string.Empty;
        sql = "select BRCODE ";
        sql += " from genpay.bnkbrn ";
        sql += " where UPPER(BBNAM) = '" + bankName.ToUpper() + "'";
        sql += " and UPPER(BBRNCH) = '" + branchName.ToUpper() + "'";
        return sql;
    }

    public string getClaimsForIndiVouchers(string dateFrom, string dateTo)
    {
        string sql = string.Empty;
        sql = "select POLICY_NO, CLAIM_REF_NO, EMP_ID, DEP_ID, to_char(AMOUNT, '9999999.99') AMOUNT ";
        sql += " from slic_chp.payment_mast ";
        sql += " where payment_conf_by is not null ";
        sql += " and payment_conf_date is not null ";
        sql += " and to_char(PAYMENT_CONF_DATE, 'YYYYMMDD') >= " + dateFrom;
        sql += " and to_char(PAYMENT_CONF_DATE, 'YYYYMMDD') <= " + dateTo;        
        sql += " and indiv_vou_no is null ";
        sql += " and (bank_code is null or bank_code = '0') ";
        sql += " and (bank_branch_code is null or bank_branch_code = '0')";
        return sql;
    }

    public string getIndiVousToAuthorize(string dateFrom, string dateTo)
    {
        string sql = string.Empty;
        //sql = "select POLICY_NO, CLAIM_REF_NO, EMP_ID, DEP_ID, to_char(AMOUNT, '9999999.99') AMOUNT, INDIV_VOU_NO ";
        sql = "select POLICY_NO as \"Policy No\", CLAIM_REF_NO as \"Claim No\", EMP_ID as \"Employee Id\", DEP_ID as \"Claimant Id\", to_char(AMOUNT, '9999999.99') as \"Amount\", INDIV_VOU_NO as \"Voucher No\"";
        sql += " from slic_chp.payment_mast ";
        sql += " where vou_printed_by is not null ";
        sql += " and vou_printed_date is not null ";
        sql += " and to_char(VOU_CREATED_DATE, 'YYYYMMDD') >= " + dateFrom;
        sql += " and to_char(VOU_CREATED_DATE, 'YYYYMMDD') <= " + dateTo;
        sql += " and indiv_vou_no is not null ";
        sql += " and payment_mode = 'C' and VOU_AUTH_BY is null and VOU_AUTH_DATE is null";
        return sql;
    }

    public string getBulkVousToAuthorize(string dateFrom, string dateTo)
    {
        string sql = string.Empty;
        sql = "select distinct BULK_VOU_NO as \"Bulk Voucher No\" ";
        sql += " from slic_chp.payment_mast ";
        sql += " where vou_printed_by is not null ";
        sql += " and vou_printed_date is not null ";
        sql += " and to_char(VOU_CREATED_DATE, 'YYYYMMDD') >= " + dateFrom;
        sql += " and to_char(VOU_CREATED_DATE, 'YYYYMMDD') <= " + dateTo;
        sql += " and bulk_vou_no is not null ";
        sql += " and payment_mode = 'D' and VOU_AUTH_BY is null and VOU_AUTH_DATE is null";
        return sql;
    }

    public string getClaimsForSLIPVouchers(string dateFrom, string dateTo)
    {
        string sql = string.Empty;
        sql = "select POLICY_NO, CLAIM_REF_NO, EMP_ID, DEP_ID, to_char(AMOUNT, '9999999.99') AMOUNT ";
        sql += " from slic_chp.payment_mast ";
        sql += " where payment_conf_by is not null ";
        sql += " and payment_conf_date is not null ";
        sql += " and indiv_vou_no is null ";
        sql += " and bank_code is not null ";
        sql += " and bank_branch_code is not null";
        sql += " and to_char(PAYMENT_CONF_DATE, 'YYYYMMDD') >= " + dateFrom;
        sql += " and to_char(PAYMENT_CONF_DATE, 'YYYYMMDD') <= " + dateTo;
        return sql;
    }

    public string getMaxVouSeqNo(string branch)
    {
        string sql = string.Empty;
        sql = "select to_char(VOUNO1) ";
        sql += " from LCLM.VOUNO ";
        sql += " where VUBRNO = " + int.Parse(branch);
        sql += " and VUYEAR = " + DateTime.Today.Year.ToString();
        sql += " and VUTYPE = 'W'";
        return sql;
    }

    public string getChequeVouchersToPrint(string claimNo)
    {
        string sql = string.Empty;
        sql += "select indiv_vou_no from slic_chp.payment_mast ";
        sql += " where CLAIM_REF_NO = '" + claimNo;
        sql += "' and payment_mode = 'C' ";
        sql += " and indiv_vou_no is not null  ";
        sql += " and VOU_PRINTED_BY is null ";
        sql += " and VOU_PRINTED_DATE is null ";
        return sql;
    }

    public string getChequeVouchersToAuthReverse(string claimNo)
    {
        string sql = string.Empty;
        sql += "select P.POLICY_NO, P.CLAIM_REF_NO, P.EMP_ID, P.DEP_ID, P.AMOUNT, P.indiv_vou_no "; //POLICY_NO, CLAIM_REF_NO, EMP_ID, DEP_ID, AMOUNT, INDIV_VOU_NO
        sql += "from slic_chp.payment_mast P, CASHBOOK.TEMP_CB T ";
        sql += " where P.INDIV_VOU_NO = T.VOUNO and P.CLAIM_REF_NO = T.CLAIMNO and P.CLAIM_REF_NO = '" + claimNo;
        sql += "' and P.payment_mode = 'C' and T.STATUS = 'Vou Authorized' and T.authorized = 1  ";
        sql += " and P.indiv_vou_no is not null ";
        sql += " and P.VOU_PRINTED_BY is not null ";
        sql += " and P.VOU_AUTH_DATE is not null ";
        return sql;
    }

    public string getChequeVouchersToReverse(string claimNo)
    {
        string sql = string.Empty;
        sql = "select POLICY_NO, CLAIM_REF_NO, EMP_ID, DEP_ID, AMOUNT, indiv_vou_no " +
                " from slic_chp.payment_mast " +
                " where claim_ref_no = '" + claimNo +
                "' and status = 3 and payment_mode = 'C'" +
                " and indiv_vou_no is not null " +
                " and bulk_vou_no is null " +
                " and vou_created_by is not null " +
                " and ( (VOU_AUTH_REV_BY is not null and VOU_REV_BY is null) " +
                " or (VOU_AUTH_REV_BY is null and VOU_REV_BY is null))";
        return sql;
    }

    public string getBulkVouchersToAuthReverse(string claimNo)
    {
        string sql = string.Empty;
        sql += "select P.BULK_vou_no from slic_chp.payment_mast P, CASHBOOK.TEMP_CB T ";
        sql += " where P.INDIV_VOU_NO = T.VOUNO and P.CLAIM_REF_NO = T.CLAIMNO and P.CLAIM_REF_NO = '" + claimNo;
        sql += "' and P.payment_mode = 'D' and T.STATUS = 'Vou Authorized' and T.authorized = 1  ";
        sql += " and P.bulk_vou_no is not null  ";
        sql += " and P.VOU_PRINTED_BY is not null ";
        sql += " and P.VOU_AUTH_DATE is not null ";
        return sql;
    }

    public string getBulkVouchersToReverse(string claimNo)
    {
        string sql = string.Empty;
        sql = "select bulk_vou_no " +
                " from slic_chp.payment_mast " +
                " where claim_ref_no = '" + claimNo +
                "' and status = 3 and payment_mode = 'D' " +
                " and indiv_vou_no is not null " +
                " and bulk_vou_no is not null " +
                " and vou_created_by is not null " +
                " and ( (VOU_AUTH_REV_BY is not null and VOU_REV_BY is null) " +
                " or (VOU_AUTH_REV_BY is null and VOU_REV_BY is null))";
        return sql;
    }

    public string getChequeVouchersToReprint(string claimNo)
    {
        string sql = string.Empty;
        sql += "select indiv_vou_no from slic_chp.payment_mast ";
        sql += " where CLAIM_REF_NO = '" + claimNo;
        sql += "' and payment_mode = 'C' ";
        sql += " and indiv_vou_no is not null  ";
        sql += " and VOU_PRINTED_BY is not null ";
        sql += " and VOU_PRINTED_DATE is not null ";
        return sql;
    }

    public string getBulkVouchersToPrint(string claimNo)
    {
        string sql = string.Empty;
        sql += "select bulk_vou_no from slic_chp.payment_mast ";
        sql += " where CLAIM_REF_NO = '" + claimNo;
        sql += "' and payment_mode = 'D' ";
        sql += " and indiv_vou_no is not null  ";
        sql += " and bulk_vou_no is not null";
        sql += " and VOU_PRINTED_BY is null ";
        sql += " and VOU_PRINTED_DATE is null ";
        return sql;
    }

    public string getBulkVouchersToReprint(string claimNo)
    {
        string sql = string.Empty;
        sql += "select bulk_vou_no from slic_chp.payment_mast ";
        sql += " where CLAIM_REF_NO = '" + claimNo;
        sql += "' and payment_mode = 'D' ";
        sql += " and indiv_vou_no is not null  ";
        sql += " and bulk_vou_no is not null";
        sql += " and VOU_PRINTED_BY is not null ";
        sql += " and VOU_PRINTED_DATE is not null ";
        return sql;
    }

    public string getVouDetailsToPrint(string vouNo)
    {
        string sql = string.Empty;
        sql = "select CLAIM_REF_NO, AMOUNT, PAYEE_NAME, ACCOUNT_NO, SLIC_ACCOUNT_NO, BANK_NAME, BANK_BRANCH_NAME, "; //6
        sql += " NIC_PPT_NO, CONTACT_NO, EMAIL_ADDRESS, POLICY_NO, FULL_NAME_FOR_CHEQUE, BRANCH, VOU_CREATED_BY, VOU_CREATED_DATE, BANK_CODE, BANK_BRANCH_CODE "; // 16
        sql += " from slic_chp.payment_mast ";
        sql += " where indiv_vou_no = '" + vouNo + "'";
        sql += " and payment_mode = 'C'";
        return sql;
    }

    public string getVouDetailsToAuth(string vouNo)
    {
        string sql = string.Empty;
        sql = "select CLAIM_REF_NO, AMOUNT, PAYEE_NAME, ACCOUNT_NO, SLIC_ACCOUNT_NO, BANK_NAME, BANK_BRANCH_NAME, "; //6
        sql += " NIC_PPT_NO, CONTACT_NO, EMAIL_ADDRESS, POLICY_NO, FULL_NAME_FOR_CHEQUE, BRANCH, VOU_CREATED_BY, VOU_CREATED_DATE, BANK_CODE, BANK_BRANCH_CODE "; // 16
        sql += " from slic_chp.payment_mast ";
        sql += " where indiv_vou_no = '" + vouNo + "'";
        sql += " and payment_mode = 'D'";
        return sql;
    }

    public string getIndivVousofBulkVou(string bulkVou)
    {
        string sql = string.Empty;
        sql = "select INDIV_VOU_NO " +
                " from slic_chp.payment_mast " +
                " where BULK_VOU_NO = '" + bulkVou + "'";
        return sql;
    }

    public string getBranchName(int brCode)
    {
        string sql = string.Empty;
        sql = "select BRNAM ";
        sql += " from GENPAY.BRANCH "; 
        sql += " where BRCOD = " + brCode.ToString();
        return sql;
    }

    public string getClmDate(string clmNo)
    {
        string sql = string.Empty;

        if (clmNo.Substring(8, 1).Equals("2"))
        {
            sql = "select to_char(BILL_DATE,'YYYY-MM-DD') ";
            sql += " slic_chp.opd_claims_recvd  ";
            sql += " where CLAIM_NO = '" + clmNo + "'";
        }
        else //if (clmNo.Substring(8, 1).Equals("1"))
        {
            sql = "select to_char(D_DATE, 'YYYY-MM-DD') ";
            sql += " from slic_chp.CALL_CENTER_CLAIM_DISCHARGE ";
            sql += " where INTIM_ID = '" + clmNo + "'";
        }
        return sql;
    }

    public string getBulkTotalAmount(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select sum(AMOUNT)" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo +"'";
        return sql;
    }

    public string getBulkMinVouNo(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select min(INDIV_VOU_NO)" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo + "'";
        return sql;
    }

    public string getBulkMaxVouNo(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select max(INDIV_VOU_NO)" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo + "'";
        return sql;
    }

    public string getBulkIndivVousCount(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select count(INDIV_VOU_NO)" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo + "'";
        return sql;
    }

    public string getBulkVouBranch(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select distinct BRANCH" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo + "'";
        return sql;
    }

    public string getBulkVouCretaedDate(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select distinct to_char(VOU_CREATED_DATE,'YYYY-MM-DD')" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo + "'";
        return sql;
    }

    public string getBulkVouCreatedBy(string bulkVouNo)
    {
        string sql = String.Empty;
        sql = "select distinct VOU_CREATED_BY" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no = '" + bulkVouNo + "'";
        return sql;
    }

    public string getBukIndiVouchers(string bulkVouNo)
    {
        string sql = "select POLICY_NO, CLAIM_REF_NO, INDIV_VOU_NO, BANK_NAME, BANK_BRANCH_NAME, ACCOUNT_NO, PAYEE_NAME, to_char(AMOUNT, '99999999.99') AMOUNT" +
            " from slic_chp.payment_mast " +
            " where bulk_vou_no is not null " +
            " and BULK_VOU_NO = '" + bulkVouNo + "'" +
            " order by POLICY_NO, CLAIM_REF_NO";
        return sql;
    }

    public string getInsuredName(string indivVouNo)
    {
        string sql = string.Empty;
        sql = "select CONCAT(CONCAT(EMP_TITLE, ' ' ), EMP_FULLNAME ) " +
                " from slic_chp.emp_mast E, slic_chp.payment_mast P " +
                " where e.emp_id = p.emp_id " +
                " and e.policy_no = p.policy_no " +
                " and p.indiv_vou_no = '" + indivVouNo + "'";
        return sql;
    }

    public string getVouPrintDt(string vouNo)
    {
        string sql = String.Empty;
        sql = "select to_char(VOU_PRINTED_DATE, 'YYYY-MM-DD')" +
            " from slic_chp.payment_mast " +
            " where indiv_vou_no = '" + vouNo + "'";
        return sql;
    }

    public string getVouPrintBy(string vouNo)
    {
        string sql = String.Empty;
        sql = "select VOU_PRINTED_BY" +
            " from slic_chp.payment_mast " +
            " where indiv_vou_no = '" + vouNo + "'";
        return sql;
    }

    public string getAdress(string vouNo)
    {
        string sql = String.Empty;
        sql = "select E.EMP_ADDRESS " +
            " from slic_chp.emp_mast E, slic_chp.payment_mast P " +
            " where e.emp_id = p.emp_id " +
            " and e.policy_no = p.policy_no " +
            " and p.indiv_vou_no = '" + vouNo + "'";
        return sql;
    }

    public string getNameStatus(string vouNo)
    {
        string sql = String.Empty;
        sql = "select E.EMP_TITLE " +
            " from slic_chp.emp_mast E, slic_chp.payment_mast P " +
            " where e.emp_id = p.emp_id " +
            " and e.policy_no = p.policy_no " +
            " and p.indiv_vou_no = '" + vouNo + "'";
        return sql;
    }

    public string getDepID(string empId, string relationShip)
    {
        relationShip = relationShip.ToUpper();
        string sql = String.Empty;
        sql = "select DEPENDANT_NO " +
               " from slic_chp.dependants_mast " +
               " where emp_id = '" + empId + "' " +
               " and upper(relationship) = '" + relationShip + "'";
        return sql;
    }

    public string getClaimDetails(string claimNo, string polNo, string empId)
    {
        string sql = String.Empty;
        sql = "select p.claim_ref_no as \"Claim No\", p.policy_no as \"Policy No\", p.emp_id as \"Employee Id\", p.dep_id as \"Dependent Id\", p.indiv_vou_no as \"Voucher No\", to_char(p.amount, '99999999.99') as \"Amount\", upper(t.status) as \"Status\" " +
                " from slic_chp.payment_mast P, Cashbook.temp_cb T where p.claim_ref_no = t.claimno and p.policy_no = t.polno and deleted = 0 ";

        if (!claimNo.Equals(""))
        {
            sql += " and p.claim_ref_no = '" + claimNo + "'";
        }
        if (!polNo.Equals(""))
        {
            sql += " and p.policy_no = '" + polNo + "'";
        }
        if (!empId.Equals(""))
        {
            sql += " and p.emp_id = '" + empId + "'";
        }
        sql += " and t.voutyp = 'CO_HEALTH' ";
        sql += " UNION ALL ";
        sql += " select claim_ref_no as \"Claim No\", policy_no as \"Policy No\", emp_id as \"Employee Id\", dep_id as \"Dependent Id\", indiv_vou_no as \"Voucher No\", to_char(amount, '99999999.99') as \"Amount\", decode(status, 0, 'PENDING', 1, 'PAYMENT CONFIRMED', 2, 'VOUCHER CREATED', 3, 'VOUCHER PRINTED') as \"Status\" ";
        sql += " from slic_chp.payment_mast where claim_ref_no is not null and status < 4 ";
        if (!claimNo.Equals(""))
        {
            sql += " and claim_ref_no = '" + claimNo + "'";
        }
        if (!polNo.Equals(""))
        {
            sql += " and policy_no = '" + polNo + "'";
                }
        if (!empId.Equals(""))
        {
            sql += " and emp_id = '" + empId + "'";
                }
        sql += " order by \"Claim No\" ";

        return sql;
    }



}