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
/// Summary description for Investment_Policies
/// </summary>
/// 
[Serializable()]
public class Investment_Policies
{
    private long polno;
    private bool ispolicyexist;
    private double sumass;
    private int term;
    private List<Investment_Policies> invpollist = new List<Investment_Policies>();
	public Investment_Policies()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void InvestmentPolicyFind(long polno, DataManager dm)
    {
        this.Ispolicyexist = false;
        string invpolsel = "select PMPOL, PMSUM, PMTRM from LPHS.PREMAST where PMPOL in(" +
            "select POLNO from LUND.POLPERSONAL A, (select NICNO from LUND.POLPERSONAL"+
            " where POLNO=" + polno + ") B where A.NICNO=B.NICNO and length(A.NICNO)>=10 and A.POLNO<>" + polno + " and A.NICNO<>'0000000000')"+
            " and PMTBL=51";
        if (dm.existRecored(invpolsel) != 0)
        {
            this.Ispolicyexist = true;
            dm.readSql(invpolsel);
            OracleDataReader invpolreader = dm.oraComm.ExecuteReader();
            while (invpolreader.Read())
            {
                Investment_Policies A = new Investment_Policies();
                if (!invpolreader.IsDBNull(0)) { A.Polno = invpolreader.GetInt64(0); }
                if (!invpolreader.IsDBNull(1)) { A.Sumass = invpolreader.GetDouble(1); }
                if (!invpolreader.IsDBNull(2)) { A.Term = invpolreader.GetInt32(2); }
                Invpollist.Add(A);
            }
        }
    }
    public List<Investment_Policies> Invpollist
    {
        get { return invpollist; }
        set { invpollist = value; }
    }
    public Boolean Ispolicyexist
    {
        get { return ispolicyexist; }
        set { ispolicyexist = value; }
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public double Sumass
    {
        get { return sumass; }
        set { sumass = value; }
    }
    public int Term
    {
        get { return term; }
        set { term = value; }
    }
}
