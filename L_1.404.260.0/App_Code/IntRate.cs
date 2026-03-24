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
/// Summary description for IntRate
/// </summary>
public class IntRate
{
    private int year;
    private double rate;

    DataManager dm;

	public IntRate(int Theyear)
	{
        year = Theyear;
        try
        {
            dm = new DataManager();
            string intsel = "select RATE from LPHS.SJ_INTEREST_RATES where YEAR=" + year + " ";
            if (dm.existRecored(intsel) != 0)
            {
                dm.readSql(intsel);
                OracleDataReader interestreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                interestreader.Read();
                if (!interestreader.IsDBNull(0)) { rate = interestreader.GetDouble(0); } else { rate = 0; }
                interestreader.Close();
                interestreader.Dispose();
            }
            else
            {
                rate = 0;
            }
                
        }
        catch(Exception Ex)
        {
            throw (Ex);
        }

	}
    public double Rate
    {
        get { return rate; }
        set { rate = value; }
    }
}
