using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Web.Configuration;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Odbc;

public partial class checkSelectedReq : System.Web.UI.Page
{
    private int reqId;
    private string desc;

    private int polno;
    private string MOF;
    private string epf;


    DataManager dm;
    DatabaseAccessLayer dal = new DatabaseTransactionLayer();

    List<int> ruleList = new List<int>();
    List<int> noticeIdList = new List<int>();
    List<string> noticeDescList = new List<string>();
    private string notice = "";

    protected ArrayList arr;
    protected ArrayList arr2;
    DataManager reqlistobj;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.polno1;
            MOF = this.PreviousPage.MOF1;

            ruleList = this.PreviousPage.rule;
            //ruleList = this.PreviousPage.checkedReq;
            noticeIdList = this.PreviousPage.noticeId;

            
        }
        //ArrayList reqList = new ArrayList();
        //dm = new DataManager();
        //reqList = GetData(dm, ruleList);
        //grdViewSelected.DataSource = reqList;
        //grdViewSelected.DataBind();

        grdViewSelected.DataSource = CreateDataSource();
        grdViewSelected.DataBind();

        gvNotices.DataSource = CreateNoticeDataSource();
        gvNotices.DataBind();

    }


    public ICollection CreateDataSource()
    {
        reqlistobj = new DataManager();

        arr = new ArrayList();
        arr2 = new ArrayList();


        //foreach (int rec in ruleList)
        //{

        //    string dreqSelect = "select DREQCODE,DREQDESSHORT from lphs.dreqdesc where DREQCODE=" + rec + "  ";
        //    reqlistobj.readSql(dreqSelect);
        //    OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (dreqreader.Read())
        //    {

        //        reqId = dreqreader.GetInt32(0);

        //            if (!dreqreader.IsDBNull(1)) { desc = dreqreader.GetString(1); }
        //            arr.Add(new SelectedReqList(reqId, desc,alreadyRecRemark));

        //    }
        //    dreqreader.Close();
        //    dreqreader.Dispose();
        //}

        //foreach (int ntc in noticeIdList)
        //{
        //    string noticeSelect = "select NOTICE_NAME FROM LCLM.DTH_NOTICES WHERE NOTICE_ID=" + ntc + "  ";
        //    reqlistobj.readSql(noticeSelect);
        //    OracleDataReader noticeReader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (noticeReader.Read())
        //    {
        //        if (!noticeReader.IsDBNull(0)) { notice = noticeReader.GetString(0); }
        //        noticeDescList.Add(notice);

        //    }
        //    noticeReader.Close();
        //    noticeReader.Dispose();
        //}

        if (PreviousPage != null)
        {
            arr = this.PreviousPage.checkedReqList;
        }
        

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("REQID", typeof(string)));
        dt.Columns.Add(new DataColumn("REQDESC", typeof(string)));
        dt.Columns.Add(new DataColumn("REQREMARK", typeof(string)));

        

        foreach (SelectedReqList req in arr)
        {
           

            dr = dt.NewRow();
            dr[0] = req.ReqId;
            dr[1] = req.Reqdesc;
            dr[2] = req.Remarks;
         

            dt.Rows.Add(dr);
            
        }
        int k = 1;
        //foreach (string ntc in noticeDescList)
        //{


        //    dr = dt.NewRow();
        //    dr[0] = k;
        //    dr[1] = ntc;
        //    dr[2] = "";


        //    dt.Rows.Add(dr);
        //    k++;
        //}
        if (dt.Rows.Count == 0)
        {
            lblNoReq.Visible = true;
        }
        DataView dv = new DataView(dt);
        return dv;
    }

    public ICollection CreateNoticeDataSource()
    {
        reqlistobj = new DataManager();

        arr = new ArrayList();
        arr2 = new ArrayList();


        //foreach (int rec in ruleList)
        //{

        //    string dreqSelect = "select DREQCODE,DREQDESSHORT from lphs.dreqdesc where DREQCODE=" + rec + "  ";
        //    reqlistobj.readSql(dreqSelect);
        //    OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (dreqreader.Read())
        //    {

        //        reqId = dreqreader.GetInt32(0);

        //            if (!dreqreader.IsDBNull(1)) { desc = dreqreader.GetString(1); }
        //            arr.Add(new SelectedReqList(reqId, desc,alreadyRecRemark));

        //    }
        //    dreqreader.Close();
        //    dreqreader.Dispose();
        //}

        foreach (int ntc in noticeIdList)
        {
            string noticeSelect = "select NOTICE_NAME FROM LCLM.DTH_NOTICES WHERE NOTICE_ID=" + ntc + "  ";
            reqlistobj.readSql(noticeSelect);
            OracleDataReader noticeReader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (noticeReader.Read())
            {
                if (!noticeReader.IsDBNull(0)) { notice = noticeReader.GetString(0); }
                noticeDescList.Add(notice);

            }
            noticeReader.Close();
            noticeReader.Dispose();
        }

        //if (PreviousPage != null)
        //{
        //    arr = this.PreviousPage.checkedReqList;
        //}


        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("REQID", typeof(string)));
        dt.Columns.Add(new DataColumn("REQDESC", typeof(string)));
        dt.Columns.Add(new DataColumn("REQREMARK", typeof(string)));



        //foreach (SelectedReqList req in arr)
        //{


        //    dr = dt.NewRow();
        //    dr[0] = req.ReqId;
        //    dr[1] = req.Reqdesc;
        //    dr[2] = req.Remarks;


        //    dt.Rows.Add(dr);

        //}
        int k = 1;
        foreach (string ntc in noticeDescList)
        {


            dr = dt.NewRow();
            dr[0] = k;
            dr[1] = ntc;
            dr[2] = "";


            dt.Rows.Add(dr);
            k++;
        }

        if(dt.Rows.Count == 0)
        {
            lblNoNotices.Visible = true;
        }

        DataView dv = new DataView(dt);
        return dv;
    }
















    //public ArrayList GetData(DataManager dm, List<int> rules)
    //{
    //    ArrayList RequirementSet = new ArrayList();

    //    foreach (int ruleid in rules)
    //    {
    //        string dreqSelect2 = "select DREQCODE,DREQDESSHORT from LPHS.DREQDESC where DREQCODE=" + ruleid + "";
    //        if (dm.existRecored(dreqSelect2) != 0)
    //        {
    //            dm.readSql(dreqSelect2);
    //            OracleDataReader dreqreader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //            while (dreqreader2.Read())
    //            {
    //                if (!dreqreader2.IsDBNull(0)) { reqId = dreqreader2.GetInt32(0); }
    //                if (!dreqreader2.IsDBNull(1)) { desc = dreqreader2.GetString(1); }

    //                RequirementSet.Add(reqId);
    //                RequirementSet.Add(desc);

    //            }
    //            dreqreader2.Close();
    //            dreqreader2.Dispose();

    //        }



    //    }
    //    return RequirementSet;
    //}


    //public int ReqID
    //{
    //    get { return reqId; }
    //    set { reqId = value; }

    //}
    //public string Desc
    //{
    //    get { return desc; }
    //    set { desc = value; }
    //}
}