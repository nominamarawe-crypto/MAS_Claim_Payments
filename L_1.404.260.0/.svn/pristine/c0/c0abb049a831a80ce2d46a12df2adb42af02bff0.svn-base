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
using System.Runtime.Serialization;

/// <summary>
/// Summary description for LegalHiere
/// </summary>
/// 
[Serializable()]
public class LegalHiere
{
    private int heiereno=0;
    private double totshare;
    private long polno;
    private string mos;
    private double shareamt;
    private double totshareamt;
    private double adbtotshare;
    private double adbshareamt;
    
    public LegalHiere(long thepolno, string themos, DataManager dm)
	{
        polno = thepolno;
        mos = themos;
        string maxnosel = "select max(LHHNO), sum(LHSHARE), sum(LHAMOUNT) from LPHS.LEGAL_HIRES where LHPOLNO=" + thepolno + " and LHMOF='" + themos + "'";
        if (dm.existRecored(maxnosel) != 0)
        {
            dm.readSql(maxnosel);
            OracleDataReader maxnoselread=dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (maxnoselread.Read())
            {
                if (!maxnoselread.IsDBNull(0)) { heiereno = maxnoselread.GetInt32(0); } else { heiereno = 0; }
                if (!maxnoselread.IsDBNull(1)) { totshare = maxnoselread.GetDouble(1); } else { totshare = 0; }
                if (!maxnoselread.IsDBNull(2)) { shareamt = maxnoselread.GetDouble(2); } else { shareamt = 0; }
            }
            maxnoselread.Close();
            maxnoselread.Dispose();
        }        
    }
    public void Lhinsert(string heire, double shareper, string name, string ad1, string ad2, string ad3, string ad4, int dob, string married, string epf, string ip, DataManager dm)
    {
        try
        {
            heiereno++;
            string lhinsert = "insert into LPHS.LEGAL_HIRES(LHPOLNO, LHMOF, LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHENTDT, LHENTEPF, LHENTIP, LHSHARE, LHAD2, LHAD3, LHAD4)";
            lhinsert += "values(" + polno + ", '" + mos + "', " + heiereno + ", '" + heire + "', '" + name + "', '" + ad1 + "', " + dob + ", '" + married + "', to_char(sysdate,'yyyymmdd'), '" + epf + "', '" + ip + "', " + shareper + ", " +
                "'" + ad2 + "', '" + ad3 + "', '" + ad4 + "')";
            dm.insertRecords(lhinsert);
        }
        catch(Exception Ex)
        {
            throw Ex;
        }

    }

    public void ADBLegalHiere(long thepolno, string themos, DataManager dm)
    {
        polno = thepolno;
        mos = themos;
        string maxnosel = "select sum(PAYEESHARE), sum(PAYEEAMOUNT), max(PAYEENO) from LPHS.DTH_ADBPAYMENT_DISTN where POLICY_NO=" + thepolno + " and MOS='" + themos + "'";
        if (dm.existRecored(maxnosel) != 0)
        {
            dm.readSql(maxnosel);
            OracleDataReader maxnoselread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (maxnoselread.Read())
            {
                if (!maxnoselread.IsDBNull(0)) { adbtotshare = maxnoselread.GetDouble(0); } else { adbtotshare = 0; }
                if (!maxnoselread.IsDBNull(1)) { adbshareamt = maxnoselread.GetDouble(1); } else { adbshareamt = 0; }
                if (!maxnoselread.IsDBNull(2)) { heiereno = maxnoselread.GetInt32(2); } else { heiereno = 0; }
            } 
        }
    }

    public void ADBLhinsert(long polno, string mos, long cliamno, string oldpayee, string newpayee, string name, string ad1, string ad2, string ad3, string ad4, int dob, string married, double share, double shareamt, string epf, string ip, DataManager dm)
    {
        try
        {
            heiereno++;
            string lhinsert = "insert into LPHS.DTH_ADBPAYMENT_DISTN(POLICY_NO, MOS, CLAIM_NO, OLD_PAYEE, NEW_PAYEE, PAYEENO, LHHIRE, PAYEENAME, PAYEEAD1, PAYEEAD2, PAYEEAD3, PAYEEAD4, PAYEEDOB, PAYEEMST, PAYEESHARE, PAYEEAMOUNT, PAYEEPAYST, PAYEEENTDT, PAYEEENTEPF, PAYEEENTIP)";
            lhinsert += "values(" + polno + ", '" + mos + "', " + cliamno + ", '" + oldpayee + "', '" + newpayee + "', " + heiereno + ",'LHI','" + name + "', '" + ad1 + "','" + ad2 + "','" + ad3 + "','" + ad4 + "', " + dob + ", '" + married + "'," + share + "," + shareamt + ", 'OK', sysdate, '" + epf + "', '" + ip + "')";
            dm.insertRecords(lhinsert);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

    }

    public double getShareTotAmount(long thepolno, string themos, DataManager dm)
    { 
        string dthrefSelect = "select drnetclm from lphs.dthref where drpolno=" + thepolno + " and drmos='" + themos + "'";
        if (dm.existRecored(dthrefSelect) != 0)
        {
            dm.readSql(dthrefSelect);
            OracleDataReader dthrefread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dthrefread.Read())
            {
                if (!dthrefread.IsDBNull(0)) { totshareamt = dthrefread.GetDouble(0); } else { totshareamt = 0.0; } 
            }
            dthrefread.Close();
            dthrefread.Dispose();
        }
        return totshareamt;
    }
    public int Maxheireno
    {
        get { return heiereno; }
        set { heiereno = value; }
    }
    public double Totshare
    {
        get { return totshare; }
        set { totshare = value; }
    }
    public double Totshareamt
    {
        get { return shareamt; }
        set { shareamt = value; }
    }

    public double ADBTotshare
    {
        get { return adbtotshare; }
        set { adbtotshare = value; }
    }
    public double ADBTotshareamt
    {
        get { return adbshareamt; }
        set { adbshareamt = value; }
    }

    public double TotalShareAmt
    {
        get { return totshareamt; }
        set { totshareamt = value; }
    }
}
