using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ReadTables
/// </summary>
public class ReadTables
{
    private int comDat;
    private int table;
    private int term;
    private double sumass; 
    private int mode;
    private double prem;
    private int due;
    private int pacode;
    private int agtcode;
    private int orgcode;
    private int Branch;
    private int oribrn;
    private int matdt;
    private string status;

    public ReadTables(long polno,string state,DataManager dm)
	{
        string Read = "";
        if (state == "INF")
        {
            Read = "select PMCOM,PMTBL,PMTRM,PMSUM,PMMOD,PMPRM,PMDUE,PMPAC,PMAGT,PMORG,PMBRN,PMOBR,to_char(add_months(to_date(PMCOM,'yyyymmdd'),(PMTRM*12)),'yyyymmdd')  from LPHS.PREMAST where PMPOL=" + polno + "";
            status = "Inforce";
        }
        else if (state == "LPS")
        {
            Read = "select LPCOM,LPTBL,LPTRM,LPSUM,LPMOD,LPPRM,LPDUE,LPPAC,LPAGT,LPORG,LPBRN,LPOBR,to_char(add_months(to_date(LPCOM,'yyyymmdd'),(LPTRM*12)),'yyyymmdd')  from LPHS.LIFLAPS where LPPOL=" + polno + "";
            status = "Lapse";
        }
        else if (state == "MAT")
        {
            Read = "select LMCOM,LMTBL,LMTRM,LMSUM,LMMOD,LMPRM,LMDUE,LMPAC,LMAGT,LMORG,LMBRN,LMOBR,to_char(add_months(to_date(LMCOM,'yyyymmdd'),(LMTRM*12)),'yyyymmdd')  from LCLM.LIFMATS where LMPOL=" + polno + "";
            status = "Maturity";
        }
        else if (state == "CLM")
        {
            Read = "select PDCOM,PTABLE,PTERM,PSUM,0,0,0,PPACODE,0,0,0,0,to_char(add_months(to_date(PDCOM,'yyyymmdd'),(PTERM*12)),'yyyymmdd')  from LCLM.LCMMAST where PPOLNO=" + polno + "";
            status = "Claim Master";
        }

        if (dm.existRecored(Read) != 0)
        {
            dm.readSql(Read);
            OracleDataReader reader = dm.oraComm.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { comDat = reader.GetInt32(0); } else { comDat = 0; }
                if (!reader.IsDBNull(1)) { table = reader.GetInt32(1); } else { table = 0; }
                if (!reader.IsDBNull(2)) { term = reader.GetInt32(2); } else { term = 0; }
                if (!reader.IsDBNull(3)) { sumass = reader.GetInt32(3); } else { sumass = 0; }
                if (!reader.IsDBNull(4)) { mode = reader.GetInt32(4); } else { mode = 0; }
                if (!reader.IsDBNull(5)) { prem = reader.GetDouble(5); } else { prem = 0; }
                if (!reader.IsDBNull(6)) { due = reader.GetInt32(6); } else { due = 0; }
                if (!reader.IsDBNull(7)) { pacode = reader.GetInt32(7); } else { pacode = 0; }
                if (!reader.IsDBNull(8)) { agtcode = reader.GetInt32(8); } else { agtcode = 0; }
                if (!reader.IsDBNull(9)) { orgcode = reader.GetInt32(9); } else { orgcode = 0; }
                if (!reader.IsDBNull(10)) { Branch = reader.GetInt32(10); } else { Branch = 0; }
                if (!reader.IsDBNull(11)) {oribrn=reader.GetInt32(11);} else{oribrn=0;}
                if (!reader.IsDBNull(12)) { matdt = int.Parse(reader.GetString(12)); } else { matdt = 0; }

            }
            reader.Close();
        }
           
    }
    public int ComDat
    {
        get { return comDat; }
        set { comDat = value; }
    }
    public int Table
    {
        get { return table; }
        set { table = value; }
    }
    public int Term
    {
        get { return term; }
        set { term = value; }
    }
    public double SumAss
    {
        get { return sumass; }
        set { sumass = value; }
    }
    public int Mode
    {
        get { return mode; }
        set { mode = value; }
    }
    public double Prem
    {
        get { return prem; }
        set { prem = value; }
    }
    public int Due
    {
        get { return due; }
        set { due = value; }
    }
    public int PACod
    {
        get { return pacode; }
        set { pacode = value; }
    }
    public int AgtCod
    {
        get { return agtcode; }
        set { agtcode = value; }
    }
    public int OrgCod
    {
        get { return orgcode; }
        set { orgcode = value; }
    }
    public int SBranch
    {
        get { return Branch; }
        set { Branch = value; }
    }
    public int OriBrn
    {
        get { return oribrn; }
        set { oribrn=value;}
    }
    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    public int MatDat
    {
        get { return matdt; }
        set { matdt = value; }
    }
}