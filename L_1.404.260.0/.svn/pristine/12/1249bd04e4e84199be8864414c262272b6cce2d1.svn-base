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
using System.Runtime.Serialization;  

[Serializable()]
public class ReqList
{
    private int reqno;
    private int reqcode;
    private string reqdesc;
    private string remarks;

    DataManager reqlistobj = new DataManager();
  
	public ReqList(int reqcodeeka, string rema)
	{
        this.reqcode = reqcodeeka;
        this.remarks = rema;
        string dreqSelect = "select dreqdsesceng from lphs.dreqdesc where dreqcode=" + reqcodeeka + "  ";
        reqlistobj.readSql(dreqSelect);
        OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        while (dreqreader.Read())
        {
            if (!dreqreader.IsDBNull(0)) { reqdesc = dreqreader.GetString(0); }        
        }
        dreqreader.Close();
        dreqreader.Dispose();
	}
    public string Reqsesc {
        get { return reqdesc; }
        set { reqdesc = value; }
    }
    public int Reqcode{
        get { return reqcode; }
        set { reqcode = value; }
    }
    public string Remarks {
        get { return remarks; }
        set { remarks = value; }
    }


    
}
