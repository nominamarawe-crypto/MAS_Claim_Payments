using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Web;

/// <summary>
/// Summary description for Covers
/// </summary>
/// 
[Serializable]
public class Covers
{
    private string covname;
    private int covid;
    private double sumass;
    public Covers()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string CoverName
    {
        get { return covname; }
        set { covname = value; }
    }
    public int CoverID
    {
        get { return covid; }
        set { covid = value; }
    }
    public double Sumass
    {
        get { return sumass; }
        set { sumass = value; }
    }

    public List<Covers> GetolicyCovers(string polno,DataManager dm)
    {
        List<Covers> coverlist = new List<Covers>();

        try
        {
            string coverselect = "select a.RCOVR,b.SHORT_NAME,a.RSUMAS from lund.rcover a left outer join " +
                "LUND.COVERNAME b on a.RCOVR=b.RCONUM where RPOL='"+polno+"' order by a.RCOVR";
            if (dm.existRecored(coverselect) != 0)
            {
                dm.readSql(coverselect);
                OracleDataReader coverReader = dm.oraComm.ExecuteReader();
               
                while (coverReader.Read())
                {
                    Covers cover = new Covers();
                    if (!coverReader.IsDBNull(0)) { cover.CoverID = coverReader.GetInt32(0); }
                    if (!coverReader.IsDBNull(1)) { cover.CoverName = coverReader.GetString(1)+" SA"; }
                    if (!coverReader.IsDBNull(2)) { cover.Sumass = coverReader.GetDouble(2); }
                    coverlist.Add(cover);
                }
                coverReader.Close();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

        return coverlist;
    }
}