using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;
using System.Data.OracleClient;

/// <summary>
/// Summary description for authorize
/// </summary>
public class authorize

/// <summary>
/// Summary description for User_Authentication
/// </summary>

{
    public authorize()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public  bool IsUserAuthenticated(string pUserId,string pSystemCode , string pFunctionCode)
    {
        bool isUser = false;
        //==============uncomment this code when you put this in to live=============
        //OdbcConnection con = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");

        //========comment this when you put this in to live
        OdbcConnection con = new OdbcConnection("DSN=beegen;UID=lpay;PWD=lpay");
        //con.Driver = "SQORA32.DLL";
        //con.ServerVersion = "09.02.0070";
        try
        {
            if (con.State != ConnectionState.Open)
            {                
                con.Open();
            }
        }
        catch
        {
        }
        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Userid FROM INTRANET.USRAUTFUN WHERE Userid='" + pUserId + "' AND Syscod='" + pSystemCode + "' AND funcod='" + pFunctionCode + "'";
        try
        {
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                isUser = true;
            }
        }
        catch
        {
        }
        con.Close();
        return isUser;
    }


    public string[] checkAutority(int branch, int PayType, int EnterDate, string IsDelete, int payDate)
    {
        DataManager DBcon = new DataManager();
        string[] AutDetails = new string[6];
        try
        {
            OracleDataReader reader;
           // DBcon.con_Open();
            string sql = "SELECT PAREP,PAEDT,PAPDT,PADEL,PAENT,PAUPD FROM LPAY.PAYAUT WHERE PABRN=" + branch + " AND PATYP=" + PayType + " AND PAEDT=" + EnterDate + " AND PAPDT=" + payDate + "";
            DBcon.readSql(sql);
            reader = DBcon.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    AutDetails[0] = reader.GetString(0);
                if (!reader.IsDBNull(1))
                    AutDetails[1] = reader.GetInt32(1).ToString();
                if (!reader.IsDBNull(2))
                    AutDetails[2] = reader.GetInt32(2).ToString();
                if (!reader.IsDBNull(3))
                    AutDetails[3] = reader.GetString(3);
                if (!reader.IsDBNull(4))
                    AutDetails[4] = reader.GetString(4);
                if (!reader.IsDBNull(5))
                    AutDetails[5] = reader.GetString(5);
            }
            reader.Close();
        }

        catch (Exception exp)
        {
            DBcon.connClose();
            //EPage.Message = "Data Retrive Error LPAY.PAYAUT@" + exp.Message;
            //Response.Redirect("EPage.aspx", false);
        }
        
        return AutDetails;
    }
}

