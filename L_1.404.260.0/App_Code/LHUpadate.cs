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
using System.Runtime.Serialization;

/// <summary>
/// Summary description for LHUpadate
/// </summary>
/// 
[Serializable()]
public class LHUpadate
{
    List<LHUpadate> legalHirelist=new List<LHUpadate>();
    private int hireno;
    private string hiretype;
    private string hirename;
    private string add1, add2, add3, add4;
    private int dob;
    private string married;
    private double share;
    private double totshare;

    public void Fetch(long polno, DataManager dm, string mos)
    {
        string legalhiresel = "select LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHSHARE, LHAD2, LHAD3, LHAD4 from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + mos + "'";
        if (dm.existRecored(legalhiresel) != 0)
        {
            dm.readSql(legalhiresel);
            OracleDataReader leagalhirereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (leagalhirereader.Read())
            {
                LHUpadate A = new LHUpadate();
                if (!leagalhirereader.IsDBNull(0)) { A.Hireno = leagalhirereader.GetInt32(0); } else { A.Hireno = 0; }
                if (!leagalhirereader.IsDBNull(1)) { A.Hiretype = leagalhirereader.GetString(1); } else { A.Hiretype = ""; }
                if (!leagalhirereader.IsDBNull(2)) { A.HireName = leagalhirereader.GetString(2); } else { A.HireName = ""; }
                if (!leagalhirereader.IsDBNull(3)) { A.Address1 = leagalhirereader.GetString(3); } else { A.Address1 = ""; }
                if (!leagalhirereader.IsDBNull(4)) { A.Dob = leagalhirereader.GetInt32(4); } else { A.Dob = 0; }
                if (!leagalhirereader.IsDBNull(5)) { A.Married = leagalhirereader.GetString(5); } else { A.Married = ""; }
                if (!leagalhirereader.IsDBNull(6)) { A.Share = leagalhirereader.GetDouble(6); } else { A.Share = 0; }
                if (!leagalhirereader.IsDBNull(7)) { A.Address2 = leagalhirereader.GetString(7); } else { A.Address2 = ""; }
                if (!leagalhirereader.IsDBNull(8)) { A.Address3 = leagalhirereader.GetString(8); } else { A.Address3 = ""; }
                if (!leagalhirereader.IsDBNull(9)) { A.Address4 = leagalhirereader.GetString(9); } else { A.Address4 = ""; }
                Lhlist.Add(A);
            }
            leagalhirereader.Close();
            leagalhirereader.Dispose();
        }
    }

    public void Insert(long polno, DataManager dm, int heireno, string heiretype, string heirename, string address1, string address2, string address3, string address4, int dob, string married, double share)
    {
        try
        {
            dm.begintransaction();
            share = share / 100;
            string lhuupdate = "update LPHS.LEGAL_HIRES set LHHIRE='" + heiretype + "', LHNAME='" + heirename + "', LHAD1='" + address1 + "', LHAD2='" + address2 + "', LHAD3='" + address3 + "', LHAD4='" + address4 + "', LHDOB=" + dob + ", LHMST='" + married + "', LHSHARE=" + share + "" +
                " where LHPOLNO=" + polno + " and LHHNO=" + heireno + "";
            dm.insertRecords(lhuupdate);
            dm.commit();
        }
        catch(Exception Ex)
        {
            dm.rollback();
            throw Ex;
        }
    }
    public double CheckBalance(long polno, string mos, DataManager dm)
    {
        double tshare=0;
        try
        {
            string balcheck = "select sum(LHSHARE) from LPHS.LEGAL_HIRES where LHPOLNO=" + polno + " and LHMOF='" + mos + "'";
            if (dm.existRecored(balcheck) != 0)
            {
                dm.readSql(balcheck);
                OracleDataReader balreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                balreader.Read();
                if (!balreader.IsDBNull(0)) { tshare = balreader.GetDouble(0); } else { share = 0; }
                balreader.Close();
                balreader.Dispose();
            }
            return tshare;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public List<LHUpadate> Lhlist
    {
        get { return legalHirelist; }
        set { legalHirelist = value; }
    }
    public int Hireno
    {
        get { return hireno; }
        set { hireno = value; }
    }
    public string Hiretype
    {
        get { return hiretype; }
        set { hiretype = value; }
    }
    public string HireName
    {
        get { return hirename; }
        set { hirename = value; }
    }
    public string Address1
    {
        get { return add1; }
        set { add1 = value; }
    }
    public string Address2
    {
        get { return add2; }
        set { add2 = value; }
    }
    public string Address3
    {
        get { return add3; }
        set { add3 = value; }
    }
    public string Address4
    {
        get { return add4; }
        set { add4 = value; }
    }
    public int Dob
    {
        get { return dob; }
        set { dob = value; }
    }
    public string Married
    {
        get { return married; }
        set { married = value; }
    }
    public double Share
    {
        get { return share; }
        set { share = value; }
    }
}
