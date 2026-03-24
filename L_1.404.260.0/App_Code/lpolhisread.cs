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
/// Summary description for lpolhisread
/// </summary>
public class lpolhisread
{
    private long polno;
    private int TBL;
    private int COM;
    private int term;
    private string status;
    private int due;

    DataManager dm;
    OldChildProtRead ocpr;
	public lpolhisread(long Thepolno)
	{
        polno=Thepolno;
        try
        {
            dm = new DataManager();
            string lpolhissel = "select PHTBL,PHCOM,PHTRM,PHSTA,PHDUE from LPHS.LPOLHIS where PHPOL=" + polno + "";
            if (dm.existRecored(lpolhissel) != 0)
            {
                dm.readSql(lpolhissel);
                OracleDataReader lpolreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                lpolreader.Read();
                if (!lpolreader.IsDBNull(0)) { TBL = lpolreader.GetInt32(0); } else { TBL = 0; }
                if (!lpolreader.IsDBNull(1)) { COM = lpolreader.GetInt32(1); } else { COM = 0; }
                if (!lpolreader.IsDBNull(2)) { term = lpolreader.GetInt32(2); } else { term = 0; }
                if (!lpolreader.IsDBNull(3)) { status = lpolreader.GetString(3); } else { status = ""; }
                if (!lpolreader.IsDBNull(4)) { due = lpolreader.GetInt32(4); } else { due = 0; }
                lpolreader.Close();
                lpolreader.Dispose();
            }
            else
            {
                ocpr = new OldChildProtRead(polno, dm);
                TBL = ocpr.Tbl;
                COM = ocpr.Com;
                term = ocpr.Trm;
            }      
            dm.connclose();
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw Ex;
        }
	}
    public int Table
    {
        get { return TBL; }
        set { TBL = value; }
    }
    public int Commence
    {
        get { return COM; }
        set { COM = value; }
    }
    public int Term
    {
        get { return term; }
        set { term = value; }
    }
    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    public int DUE
    {
        get { return due; }
        set { due = value; }
    }
}
