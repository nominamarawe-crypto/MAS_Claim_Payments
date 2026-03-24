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

/// <summary>
/// Summary description for CheckBranch
/// </summary>
public class CheckBranch
{
    //DataManager dm;
		 
    public bool brCodeComparison(string sessionBrn, string ipaddr) 
    {
        // sessionBrn is the branch cde retrieved from the session
        // pass the ipaddress into the method converted into a string
	// this method returns a boolean value
	
        bool valid = false;
        string[] arr = ipaddr.Split('.');
        DataManager dm = new DataManager();
      
        int dbBrcode = 0;
        int brcode = 0;

        string brnIPselect = "select brncd from genpay.branchip where brnip='" + ipaddr + "'";
        dm.connclose();
        if (dm.existRecored(brnIPselect) != 0)
        {
            dm.readSql(brnIPselect);
            OracleDataReader brcodeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (brcodeReader.Read()) 
            {
                if (!brcodeReader.IsDBNull(0)) { dbBrcode = brcodeReader.GetInt32(0); }
            }
            brcodeReader.Close();
            brcodeReader.Dispose();


            if (arr[1].Equals("216")) { brcode = 16; } else { brcode = dbBrcode; }
        }
        else 
        {
            brcode = int.Parse(arr[1]);
            if (brcode == 1) { brcode = 10; }
            else if (brcode == 216) { brcode = 16; }
        }

        if (int.Parse(sessionBrn) != brcode) { valid = false; } else { valid = true; }

        dm.connclose();
        return valid;
    }



 #region //---- test code ----
            //string brcodeStr = "";
            ////if (Session["BRCODE"].ToString() != null) { brcodeStr = Session["BRCODE"].ToString(); }
            //brcodeStr = "10";
            //string ipaddr = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            ////string[] arr = ipaddr.Split('.');
            ////ipaddr = "192.192.194.1";
    //Response.Write(this.brCodeComparison(brcodeStr, ipaddr).ToString());

 #endregion
}


