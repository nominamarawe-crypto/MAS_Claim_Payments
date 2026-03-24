using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Summary description for EMailData
/// </summary>
[Serializable()]
public class EMailData
{
    public string ToWhome;
    public string BodyContent;
    public string Regards;
    public string CompanyName;
    public string DeptName;
    public string SecName;
    public string AddrLine1;
    public string AddrLine2;
    public string TeleNo;
    public string FaxNo;
    public string EmailAddr;

    DataManager dm;

	public EMailData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string getEmailIDForDeathTO(String Dep, string Type, int claimType)
    {
        dm = new DataManager();
        string emailTo = "";
        
        string emailSelect = " SELECT  EMAILID FROM LCLM.CIC_MAIL_LIST where DEP ='" + Dep + "'AND  TYPE='" + Type + "' AND CLAIM_TYPE="+ claimType + " AND rownum = 1 ";

        if (dm.existRecored(emailSelect) != 0)
        {
            dm.readSql(emailSelect);
            OracleDataReader emailreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (emailreader.Read())
            {
                if (!emailreader.IsDBNull(0)) { emailTo = emailreader.GetString(0); }

            }
            emailreader.Close();
            emailreader.Dispose();
        }
        return emailTo;
    }

    public List<string> getEmailIDForDeath(String Dep, string Type, int claimType)
    {
        dm = new DataManager();
        string emailAdd = "";
        List<string> emailAddList = new List<string>();
        
        string emailListSelect = " SELECT  EMAILID FROM LCLM.CIC_MAIL_LIST where DEP ='" + Dep + "'AND  TYPE='" + Type + "' AND CLAIM_TYPE=" + claimType + "  ";

        if (dm.existRecored(emailListSelect) != 0)
        {
            dm.readSql(emailListSelect);
            OracleDataReader emailreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (emailreader.Read())
            {
                if (!emailreader.IsDBNull(0)) { emailAdd = emailreader.GetString(0); }
                emailAddList.Add(emailAdd);
            }
            emailreader.Close();
            emailreader.Dispose();
        }  
        return emailAddList;
    }

    public void getEmailBodyDetails(int plan_id, int cont_type)
    {
        string emailBodySelect = " SELECT TO_WHOME, BODY_CONTENT,REGARDS, COMPANY_NAME, DEPT_NAME, SEC_NAME, ADDR_LINE1, ADDR_LINE2, TELE_NO FROM SLQTDATA.EMAIL_CONTENT WHERE PLAN_ID = '" + plan_id + "' AND CONTENT_TYPE = '" + cont_type + "' AND EFF_DATE = (SELECT MAX(EFF_DATE) FROM SLQTDATA.EMAIL_CONTENT WHERE PLAN_ID = '" + plan_id + "' AND CONTENT_TYPE = '" + cont_type + "' AND EFF_DATE <= SYSDATE )";

        if (dm.existRecored(emailBodySelect) != 0)
        {
            dm.readSql(emailBodySelect);
            OracleDataReader emailBodyreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (emailBodyreader.Read())
            {
                if (!emailBodyreader.IsDBNull(0)) ToWhome = emailBodyreader.GetString(0);
                if (!emailBodyreader.IsDBNull(1)) BodyContent = emailBodyreader.GetString(1);
                if (!emailBodyreader.IsDBNull(2)) Regards = emailBodyreader.GetString(2);
                if (!emailBodyreader.IsDBNull(3)) CompanyName = emailBodyreader.GetString(3);
                if (!emailBodyreader.IsDBNull(4)) DeptName = emailBodyreader.GetString(4);
                if (!emailBodyreader.IsDBNull(5)) SecName = emailBodyreader.GetString(5);
                if (!emailBodyreader.IsDBNull(6)) AddrLine1 = emailBodyreader.GetString(6);
                if (!emailBodyreader.IsDBNull(7)) AddrLine2 = emailBodyreader.GetString(7);
                if (!emailBodyreader.IsDBNull(8)) TeleNo = emailBodyreader.GetString(8);
            }
            emailBodyreader.Close();
            emailBodyreader.Dispose();
        }   
    } 
}
