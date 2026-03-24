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

[Serializable()]
public class reminderDocset2
{
    private int rownum;
    private string reqdesc;
    private int sentdat;
    private string rema;
    private int ReqCode;
    DataManager reqlistobj = new DataManager();

	public reminderDocset2(int rowNumber, int reqCode, int sentDate, string remarks)
	{
        this.rownum = rowNumber;
        this.sentdat = sentDate;
        this.rema = remarks;
        this.ReqCode = reqCode;
        string dreqSelect = "select DREQDESCSIN from lphs.dreqdesc where dreqcode=" + reqCode + "  ";
        reqlistobj.readSql(dreqSelect);
        OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        while (dreqreader.Read()){
            if (!dreqreader.IsDBNull(0)) reqdesc = dreqreader.GetString(0);

        }
        dreqreader.Close();
        dreqreader.Dispose();
	}

    public int Rownum{
        get { return rownum; }
        set { rownum = value; }
    }
    public string Reqdesc{
        get { return reqdesc; }
        set { reqdesc = value; }
    }
    public int Sentdat{
        get { return sentdat; }
        set { sentdat = value; }
    }
    public string Rema {
        get { return rema; }
        set { rema = value; }    
    }
    public int REQCODE
    {
        get { return ReqCode; }
        set { ReqCode = value; }
    }
}
