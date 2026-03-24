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
/// Summary description for Policy
/// </summary>
public class Policy
{
	public Policy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public bool validatePolicy(long polno)
    {
       // string polstat = "";
        int dateofComm = 0;
        DBConnetion dbConnetion = new DBConnetion();
        string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom from lphs.premast where pmpol=" + polno + " ";
        string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom from lphs.liflaps where lppol=" + polno + " ";
        string dthintSelect = "select * from lphs.dthint where dpolno = " + polno + "";

        if (dbConnetion.existRecored(premastSelect) != 0)
        {
            dbConnetion.ReadSql(premastSelect);
            OracleDataReader premReader = dbConnetion.cmd.ExecuteReader();
            premReader.Read();
            //  dateofComm = premReader.GetInt32(3);
            dateofComm = Int32.Parse(premReader.GetOracleValue(3).ToString());
            //polstat = "I";
            //this.lblpolstat.Text = "INFORCE";
            premReader.Close();
            dbConnetion.ConnClose();
            return true;
        }
        else if (dbConnetion.existRecored(liflapsSelect) != 0)
        {
            dbConnetion.ReadSql(liflapsSelect);
            OracleDataReader lapsReader = dbConnetion.cmd.ExecuteReader();
            lapsReader.Read();
            dateofComm = lapsReader.GetInt32(3);
           // polstat = "L";
            //this.lblpolstat.Text = "LAPSE";
            lapsReader.Close();
            dbConnetion.ConnClose();
            return true;
        }
        else if (dbConnetion.existRecored(dthintSelect) != 0)
        {
            dbConnetion.ReadSql(dthintSelect);
            OracleDataReader dethReader = dbConnetion.cmd.ExecuteReader();
            dethReader.Read();
         //   dateofComm = lapsReader.GetInt32(3);
            // polstat = "L";
            //this.lblpolstat.Text = "LAPSE";
            dethReader.Close();
            dbConnetion.ConnClose();
            return true;
        }
        else
        {

            // string lsurefcheck = "select * from lphs.dthref where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";
            // if (dbConnetion.existRecored(lsurefcheck) == 0)
            //  {
            //      throw new Exception("No Policy Details!");
            //  }
            //  else
            // {
            //     throw new Exception("Policy Registered! Cannot Alter.");
            //  }
            dbConnetion.ConnClose();
            return false;
        }
        //dbConnetion.ConnClose();
    }

    public int EpfCode(string epf)
    {
        string inte = "0";
        char temp;
        char[] validchar ={ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        for (int i = 0; i < epf.Length; i++)
        {
            temp = char.Parse(epf.Substring(i, 1));
            for (int n = 0; n < 10; n++)
            {
                if (validchar[n] == temp)
                {
                    inte += temp;
                }
            }
        }
        return int.Parse(inte);
    }
}
