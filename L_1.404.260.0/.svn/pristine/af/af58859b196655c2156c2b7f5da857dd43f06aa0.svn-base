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
/// Summary description for PeriodicPayDetSel
/// </summary>
public class PeriodicPayDetSel
{
    private int polno;
    private int clmno;
    private double payamt;
    private int paydue;

    DataManager dm;

	public PeriodicPayDetSel(int Thepolno, int Theclmno)
	{
        try
        {
            dm = new DataManager();
            this.polno = Thepolno;
            this.clmno = Theclmno;
            string periopaysel = "select PAYMENT_DUE,PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='" + clmno + "' and VONO='XXXX' ";
            if (dm.existRecored(periopaysel) != 0)
            {
                dm.readSql(periopaysel);
                OracleDataReader periopayread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                periopayread.Read();
                {
                    if (!periopayread.IsDBNull(0)) { paydue = periopayread.GetInt32(0); } else { paydue = 0; }
                    if (!periopayread.IsDBNull(1)) { payamt = periopayread.GetDouble(1); } else { payamt = 0; }

                }
                periopayread.Close();
                periopayread.Dispose();
            }
            //else { throw new Exception("Please Select Due"); }
            //string perioupdate = "update LCLM.PERIODIC_PAYDET set VONO='' where POLNO=" + polno + " and INTIMNO='" + clmno + "' and PAYMENT_DUE=" + paydue + "";
            //if (paydue != 0)
            //{
            //    dm.insertRecords(perioupdate);
            //}
        }
        catch(Exception Ex)
        {
            dm.rollback();
            
        }
	}
    public int Paydue
    {
        get { return paydue; }
        set { paydue = value; }
    }
    public double Payamt
    {
        get { return payamt; }
        set { payamt = value; }
    }
}
