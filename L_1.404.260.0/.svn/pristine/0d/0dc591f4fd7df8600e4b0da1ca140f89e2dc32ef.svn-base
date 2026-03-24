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
/// Summary description for OldChildProtRead
/// </summary>
/// 
[Serializable()]
public class OldChildProtRead
{
    private long polno;
    private string mos,ad1,ad2,ad3,ad4,status,initial,name,Name;
    private int clmno, dtofdth, tbl, trm, npdue, matdate, com, exist = 0;
    private double sumass;

	public OldChildProtRead(long polno, DataManager dm)
	{
        try
        {
            string oldchildprotread = "select CLAIMNO, DTOFDTH, TBL, TERM, SUMASS, NPDUE, MATDATE, COM, AD1, AD2, AD3, AD4, NOMSTA, NOMINT, NOMNAME from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + "";
            if (dm.existRecored(oldchildprotread) != 0)
            {
                exist = 1;
                dm.readSql(oldchildprotread);
                OracleDataReader oldchildprotreader = dm.oraComm.ExecuteReader();
                while (oldchildprotreader.Read())
                {
                    if (!oldchildprotreader.IsDBNull(0)) { clmno = oldchildprotreader.GetInt32(0); } else { clmno = 0; }
                    if (!oldchildprotreader.IsDBNull(1)) { dtofdth = oldchildprotreader.GetInt32(1); } else { dtofdth = 0; }
                    if (!oldchildprotreader.IsDBNull(2)) { tbl = oldchildprotreader.GetInt32(2); } else { tbl = 0; }
                    if (!oldchildprotreader.IsDBNull(3)) { trm = oldchildprotreader.GetInt32(3); } else { trm = 0; }
                    if (!oldchildprotreader.IsDBNull(4)) { sumass = oldchildprotreader.GetDouble(4); } else { sumass = 0; }
                    if (!oldchildprotreader.IsDBNull(5)) { npdue = oldchildprotreader.GetInt32(5); } else { npdue = 0; }
                    if (!oldchildprotreader.IsDBNull(6)) { matdate = oldchildprotreader.GetInt32(6); } else { matdate = 0; }
                    if (!oldchildprotreader.IsDBNull(7)) { com = oldchildprotreader.GetInt32(7); } else { com = 0; }
                    if (!oldchildprotreader.IsDBNull(8)) { ad1 = oldchildprotreader.GetString(8); } else { ad1 = ""; }
                    if (!oldchildprotreader.IsDBNull(9)) { ad2 = oldchildprotreader.GetString(9); } else { ad2 = ""; }
                    if (!oldchildprotreader.IsDBNull(10)) { ad3 = oldchildprotreader.GetString(10); } else { ad3 = ""; }
                    if (!oldchildprotreader.IsDBNull(11)) { ad4 = oldchildprotreader.GetString(11); } else { ad4 = ""; }
                    if (!oldchildprotreader.IsDBNull(12)) { status = oldchildprotreader.GetString(12); } else { status = ""; }
                    if (!oldchildprotreader.IsDBNull(13)) { initial = oldchildprotreader.GetString(13); } else { initial = ""; }
                    if (!oldchildprotreader.IsDBNull(14)) { name = oldchildprotreader.GetString(14); } else { name = ""; }
                    Name = status + "" + initial + "" + name;
                }
                oldchildprotreader.Close();
                //oldchildprotreader.Dispose();
            }            
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
	}
    public void Addressfetch(long polno, int index, DataManager dm)
    {
        string addresssel = "select name, addr1, addr2, addr3, addr4 from lphs.dclmaddresses where polno=" + polno + " and indx=" + index + "";
        if (dm.existRecored(addresssel) != 0)
        {
            dm.readSql(addresssel);
            OracleDataReader addressreader = dm.oraComm.ExecuteReader();
            while (addressreader.Read())
            {
                if (!addressreader.IsDBNull(0)) { Name = addressreader.GetString(0); } else { name = ""; }
                if (!addressreader.IsDBNull(1)) { ad1 = addressreader.GetString(1); } else { ad1 = ""; }
                if (!addressreader.IsDBNull(2)) { ad2 = addressreader.GetString(2); } else { ad2 = ""; }
                if (!addressreader.IsDBNull(3)) { ad3 = addressreader.GetString(3); } else { ad3 = ""; }
                if (!addressreader.IsDBNull(4)) { ad4 = addressreader.GetString(4); } else { ad4 = ""; }
            }
            addressreader.Read();
        }
    }
    public int Exist
    {
        get { return exist; }
        set { exist = value; }
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Mos
    {
        get { return mos; }
        set { mos = value; }
    }
    public int Clmno
    {
        get { return clmno; }
        set { clmno = value; }
    }
    public int Dtofdth
    {
        get { return dtofdth; }
        set { dtofdth = value; }
    }
    public int Tbl
    {
        get { return tbl; }
        set { tbl = value; }
    }
    public int Trm
    {
        get { return trm; }
        set { trm = value; }
    }
    public double Sumass
    {
        get { return sumass; }
        set { sumass = value; }
    }
    public int Npdue
    {
        get { return npdue; }
        set { npdue = value; }
    }
    public int Matdate
    {
        get { return matdate; }
        set { matdate = value; }
    }
    public int Com
    {
        get { return com; }
        set { com = value; }
    }

    public string Ad1
    {
        get { return ad1; }
        set { ad1 = value; }
    }

    public string Ad2
    {
        get { return ad2; }
        set { ad2 = value; }
    }

    public string Ad3
    {
        get { return ad3; }
        set { ad3 = value; }
    }

    public string Ad4
    {
        get { return ad4; }
        set { ad4 = value; }
    }
    public string NAME
    {
        get { return Name; }
        set { Name = value; }
    }
}
