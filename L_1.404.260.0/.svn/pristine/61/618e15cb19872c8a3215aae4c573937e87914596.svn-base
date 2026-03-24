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

/// <summary>
/// Summary description for SelectedReqList
/// </summary>
public class SelectedReqList
{

    private int reqId;
    private string reqdesc;
    private string remarks;
    private string notice;

    DataManager reqlistobj = new DataManager();
    public SelectedReqList(string reqNotice)
    {
      
        this.notice = reqNotice;

        //string dreqSelect = "select DREQCODE,DREQDESSHORT from lphs.dreqdesc where DREQCODE=" + requestId + "  ";
        //reqlistobj.readSql(dreqSelect);
        //OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //while (dreqreader.Read())
        //{
        //    if (!dreqreader.IsDBNull(0)) { reqId = dreqreader.GetInt32(0); }
        //    if (!dreqreader.IsDBNull(1)) { reqdesc = dreqreader.GetString(1); }
        //}
        //dreqreader.Close();
        //dreqreader.Dispose();
        
    }

    public SelectedReqList(int requestId, string requestDesc, string reqRemark)
    {
        this.reqId = requestId;
        this.reqdesc = requestDesc;
        this.remarks = reqRemark;

        string dreqSelect = "select DREQCODE,DREQDESSHORT from lphs.dreqdesc where DREQCODE=" + requestId + "  ";
        reqlistobj.readSql(dreqSelect);
        OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        while (dreqreader.Read())
        {
            if (!dreqreader.IsDBNull(0)) { reqId = dreqreader.GetInt32(0); }
            if (!dreqreader.IsDBNull(1)) { reqdesc = dreqreader.GetString(1); }
        }
        dreqreader.Close();
        dreqreader.Dispose();
    }


    public string ReqNotice
    {
        get { return notice; }
        set { notice = value; }
    }
    public string Remarks
    {
        get { return remarks; }
        set { remarks = value; }
    }
    public string Reqdesc
    {
        get { return reqdesc; }
        set { reqdesc = value; }
    }
    public int ReqId
    {
        get { return reqId; }
        set { reqId = value; }
    }
   
}