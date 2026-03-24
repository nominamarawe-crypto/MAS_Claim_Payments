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

/// <summary>
/// Summary description for User_Authentication
/// </summary>
public class User_Authentication
{
	public User_Authentication()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool IsUserAuthenticated(string pUserId, string pSystemCode, string pFunctionCode)
    {
        bool isUser = false;
        OdbcConnection con = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");
        try
        {
            con.Open();
        }
        catch
        {
        }
        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM INTRANET.USRAUTFUN WHERE Userid='" + pUserId + "' AND Syscod='" + pSystemCode + "' AND funcod='" + pFunctionCode + "'";
        try
        {
            OdbcDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                isUser = true;
            }
        }
        catch
        {
        }
        con.Dispose();
        return isUser;
    }
}
