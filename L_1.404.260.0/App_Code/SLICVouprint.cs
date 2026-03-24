using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.OracleClient;

/// <summary>
/// Summary description for SLICVouprint
/// </summary>
[Serializable()]
public class SLICVouprint
{
    List<SLICVouprint> voulist = new List<SLICVouprint>();
    private string vouno;
    private string payeenam;
    public double amt;
    //public string mos;
    public string mof;
    public string url;
    
	public SLICVouprint()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Fetch(long polno, DataManager dm, long clmno, string link, string mos)
    {
        string slivousel = "select SVMOS, SVVOUNO, SVPAYEENAM, SVAMT from LPHS.SLICVOUCHERS where SVPOL=" + polno + " and SVMOS='"+mos+"'";
        if (dm.existRecored(slivousel) != 0)
        {
            dm.readSql(slivousel);
            OracleDataReader slivoureader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (slivoureader.Read())
            {
                SLICVouprint A = new SLICVouprint();
                if (!slivoureader.IsDBNull(0)) { A.Mos = slivoureader.GetString(0); } else { A.Mos = ""; }
                if (!slivoureader.IsDBNull(1)) { A.Vouno = slivoureader.GetString(1); } else { A.Vouno = ""; }
                if (!slivoureader.IsDBNull(2)) { A.Name = slivoureader.GetString(2); } else { A.Name = ""; }
                if (!slivoureader.IsDBNull(3)) { A.Amount = slivoureader.GetDouble(3); } else { A.Amount = 0; }
                
                mof=mos;
                A.Url = "<a  href=" + link + "?vouno=" + A.Vouno + "&payee=SLIC&amount=" + A.Amount + "&polno=" + polno.ToString() + "&mos=" + mos + "&clmno=" + clmno + "&exgrshare=0&slicflag=1>" + A.Vouno + "</a>";
                Voulist.Add(A);
            }
            slivoureader.Close();
            slivoureader.Dispose();
        }

    }
    public List<SLICVouprint> Voulist
    {
        get { return voulist; }
        set { voulist = value; }
    }

    public string Vouno
    {
        get { return vouno; }
        set { vouno = value; }
    }

    public string Name
    {
        get { return payeenam; }
        set { payeenam = value; }
    }

    public double Amount
    {
        get { return amt; }
        set { amt = value; }
    }

    public string Mos
    {
        get { return mof; }
        set { mof = value; }
    }

    public string Url
    {
        get { return url; }
        set { url = value; }
    }
}
