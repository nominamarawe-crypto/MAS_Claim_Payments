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
using System.Collections.Generic;

/// <summary>
/// Summary description for BenefitRead
/// </summary>
/// 
[Serializable]
public class BenefitRead
{
    private List<BenefitRead> datalist = new List<BenefitRead>();
    private int invbenyear;
    private double invbenamt, invbenrate;
    private string lifecov = "";

	public BenefitRead()
	{
		
	}
    public void Fetch(long polno, double sumass, int term, DataManager dm)
    {
        int invid = 0;
        
        try
        {
            invid = this.Investmentid(polno, dm);
            string invpoldetreadsel = "select INV_BEN_YR1, INV_BEN_AMT_YR1, INV_INT_RATE_YR1 from LPHS.LIFE_INVESTMENT_POL where (INV_SUMASS, INV_BEN_YR1) in"
                + "(select max(INV_SUMASS), INV_BEN_YR1 from LPHS.LIFE_INVESTMENT_POL where INV_TBL=51 and INV_SUMASS<=" + sumass + " and INV_ID=" + invid + " and INV_BEN_YR1=" + term + " group by INV_BEN_YR1)";
            if (dm.existRecored(invpoldetreadsel) != 0)
            {
                dm.readSql(invpoldetreadsel);
                OracleDataReader invpolreader = dm.oraComm.ExecuteReader();
                while (invpolreader.Read())
                {
                    //BenefitRead A = new BenefitRead();
                    if (!invpolreader.IsDBNull(0)) { this.Invbenyear = invpolreader.GetInt32(0); } else { this.Invbenyear = 0; }
                    if (!invpolreader.IsDBNull(1)) { this.Invbenamt = invpolreader.GetDouble(1); } else { this.Invbenamt = 0; }
                    if (!invpolreader.IsDBNull(2)) { this.Invbenrate = invpolreader.GetDouble(2); } else { this.Invbenrate = 0; }
                    //Datalist.Add(A);
                }
                invpolreader.Close();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    public int Investmentid(long polno, DataManager dm)
    {
        int invid = 0;
        try
        {
            string invidsel = "select INS_ID, LIFCOVER from LNB.INVEST_POLICY where POLNO=" + polno + "";
            if (dm.existRecored(invidsel) != 0)
            {
                dm.readSql(invidsel);
                OracleDataReader invidread = dm.oraComm.ExecuteReader();
                while (invidread.Read())
                {
                    if (!invidread.IsDBNull(0)) { invid = invidread.GetInt32(0); } else { invid = 0; }
                    if (!invidread.IsDBNull(1)) { this.Lifecov = invidread.GetString(1); } else { this.Lifecov = ""; }
                }
                invidread.Close();
            }
            else
            {
                throw new Exception("This plan has been closed");
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return invid;
    }
    public List<BenefitRead> Datalist
    {
        get { return datalist; }
        set { datalist = value; }
    }
    public int Invbenyear
    {
        get { return invbenyear; }
        set { invbenyear = value; }
    }
    public double Invbenamt
    {
        get { return invbenamt; }
        set { invbenamt = value; }
    }
    public double Invbenrate
    {
        get { return invbenrate; }
        set { invbenrate = value; }
    }
    public string Lifecov
    {
        get { return lifecov; }
        set { lifecov = value; }
    }
}
