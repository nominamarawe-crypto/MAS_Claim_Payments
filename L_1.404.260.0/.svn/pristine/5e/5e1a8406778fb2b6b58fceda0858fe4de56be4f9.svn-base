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


public partial class dthPro002 : System.Web.UI.Page {
    private long polno;
    private string MOF;
    private int reqcode;
    private string remarks;
    private string phname;
    private int sentDate;

    private string COMPLETED = "";

    public string[] setDate() {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;
    }

    protected ArrayList arr;
    protected ArrayList arr2;
    DataManager reqlistobj;

    protected void Page_Load(object sender, EventArgs e) {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
        }

        if (!Page.IsPostBack) {
            reqlistobj = new DataManager();
            try {
                reqcode = 0;
                COMPLETED = "";

                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblMOS.Text = "Main Life"; } else if (MOF.Equals("S")) { this.lblMOS.Text = "Spouce"; } else if (MOF.Equals("2")) { this.lblMOS.Text = "Second Life"; } else this.lblMOS.Text = "Second Life";

                #region // ************** PHNAME  ***********************************


                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                reqlistobj.readSql(sql);
                OracleDataReader oraDtReader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraDtReader.Read()) {
                    if (!oraDtReader.IsDBNull(0))
                        phname = oraDtReader.GetString(0);
                    if (!oraDtReader.IsDBNull(1))
                        phname = phname + "" + oraDtReader.GetString(1);
                    if (!oraDtReader.IsDBNull(2))
                        phname = phname + "" + oraDtReader.GetString(2);
                }
                oraDtReader.Close();
                oraDtReader.Dispose();

                this.lblnameofins.Text = phname;
                #endregion

                #region //---------- DTHREF -----------

                string dthrefsel = "select COMPLETED from LPHS.DTHREF where drpolno  = " + polno + " and drmos = '" + MOF + "'";
                if (reqlistobj.existRecored(dthrefsel) != 0) {
                    reqlistobj.readSql(dthrefsel);
                    OracleDataReader dthrefReader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read()) {
                        if (!dthrefReader.IsDBNull(0)) { COMPLETED = dthrefReader.GetString(0); } else { COMPLETED = ""; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();
                } else {
                    reqlistobj.connclose();
                    throw new Exception("No Death Reference Details!");
                }

                if ((COMPLETED.Equals("Y")) || (COMPLETED.Equals("R"))) {
                    reqlistobj.connclose();
                    this.lblmessage.Text = "Payment Complted or Repudiated. Details Will not be Updated.";
                }

                #endregion

                arr = new ArrayList();
                arr2 = new ArrayList();
                bool existflag = false;
                string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0 and (drrecdt = 0 or drrecdt is null) ";     //and drrecdt>0 , and (drrecdt = 0 or drrecdt is null)
                reqlistobj.readSql(dreqSelect);
                OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader.Read()) {
                    existflag = true;
                    reqcode = dreqreader.GetInt32(0);
                    if (reqcode != 24) {
                        if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); }
                        arr.Add(new ReqList(reqcode, remarks));
                    }

                }
                dreqreader.Close();
                dreqreader.Dispose();

                if (!existflag) {
                    this.lblmessage.Text = "All the Sent Requirements had been Recieved or No Requirements Called!";
                }
                DataGrid1.DataSource = CreateDataSource();
                DataGrid1.DataBind();

                #region //--------------------------- Recieved Records ---------------------------------------

                int rowNum = 1;
                bool existflag2 = false;
                string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and drrecdt > 0  ";
                reqlistobj.readSql(dreqSelect2);
                OracleDataReader dreqreader2 = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                string LettType = "O";
                while (dreqreader2.Read()) {
                    existflag2 = true;
                    reqcode = dreqreader2.GetInt32(0);
                    if (!dreqreader2.IsDBNull(2)) { sentDate = dreqreader2.GetInt32(2); } else { sentDate = 0; }
                    if (!dreqreader2.IsDBNull(1)) { remarks = dreqreader2.GetString(1); } else { remarks = ""; }

                    arr2.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks, LettType));
                    rowNum++;

                }
                dreqreader2.Close();
                dreqreader2.Dispose();

                if (existflag2) {
                    int count = 0;
                    foreach (reminderDocset req in arr2) {
                        count++;
                        createReqDescTable(count.ToString(), req.Reqdesc, req.Rema, (count - 1));
                    }
                }

                #endregion

                reqlistobj.connclose();

                //---------------------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["reqcode"] = reqcode;
                ViewState["COMPLETED"] = COMPLETED;

                ViewState["arr"] = arr;
                ViewState["arr2"] = arr2;

            } catch (Exception ex) {
                reqlistobj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        } else {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["reqcode"] != null) { reqcode = int.Parse(ViewState["reqcode"].ToString()); }
            if (ViewState["COMPLETED"] != null) { COMPLETED = ViewState["COMPLETED"].ToString(); }

            if (ViewState["arr"] != null) { arr = (ArrayList)ViewState["arr"]; }
            if (ViewState["arr2"] != null) { arr2 = (ArrayList)ViewState["arr2"]; }
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e) {
        int reqno = 0;
        int reqno2 = 0;
        string rema = "";
        int recievedDate = 0;
        string labeltext = "";
        reqlistobj = new DataManager();

        if (!COMPLETED.Equals("Y") && !COMPLETED.Equals("R")) {
            for (int i = 0; i < DataGrid1.Rows.Count; i++) {
                CheckBox cb = new CheckBox();
                cb = (CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("ch");
                TextBox txt = new TextBox();
                txt = (TextBox)DataGrid1.Rows[i].Cells[2].FindControl("txt");
                rema = txt.Text.ToString();

                ReqList req01 = (ReqList)arr[i];
                reqno = req01.Reqcode;
                reqlistobj.begintransaction();
                if (cb.Checked) {
                    string dreqUpdate01 = "update lphs.dreq set drrecdt=" + int.Parse(this.setDate()[0]) + " where drpol=" + polno + " and drtyp='" + MOF + "' and drcovtyp=" + reqno + "  ";
                    reqlistobj.insertRecords(dreqUpdate01);
                }
                string dreqUpdate02 = "update lphs.dreq set drrema='" + rema + "' where drpol=" + polno + " and drtyp='" + MOF + "' and drcovtyp=" + reqno + " and drrema is null  ";
                reqlistobj.insertRecords(dreqUpdate02);
                reqlistobj.commit();
            }
        }

        string mandetoryCheck = "select drcovtyp, drrecdt from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and drmoo='Y'  ";
        reqlistobj.readSql(mandetoryCheck);
        OracleDataReader dreqreader01 = reqlistobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        while (dreqreader01.Read()) {
            reqno2 = dreqreader01.GetInt32(0);
            if (!dreqreader01.IsDBNull(1)) { recievedDate = dreqreader01.GetInt32(1); } else { recievedDate = 0; }
            if (recievedDate == 0) {
                labeltext += "Mandetory Requirement No. " + reqno2 + " Missing";
            }

        }
        dreqreader01.Close();
        dreqreader01.Dispose();
        this.lblmessage.Text = labeltext;
        reqlistobj.connclose();

        Server.Transfer("~/dthPro003.aspx", true);
    }

    public ICollection CreateDataSource() {
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("REQ", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

        foreach (ReqList req in arr) {
            dr = dt.NewRow();
            dr[0] = req.Reqsesc;
            dr[1] = req.Remarks;
            dt.Rows.Add(dr);
        }

        DataView dv = new DataView(dt);
        return dv;
    }

    private void createReqDescTable(string count, string reqDesc, string remks, int rowNumber) {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();

        lbl1.ID = "count" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "count" + rowNumber); //Text Value
        lbl1.Text = count + ".";

        lbl2.ID = "reqDesc" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "reqDesc" + rowNumber); //Text Value
        lbl2.Text = reqDesc;

        lbl3.ID = "remaks" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "remaks" + rowNumber); //Text Value
        lbl3.Text = remks;

        tcell1.Controls.Add(lbl1);
        tcell1.Style["VERTICAL-ALIGN"] = "top";
        tcell2.Controls.Add(lbl2);
        tcell3.Style["VERTICAL-ALIGN"] = "top";
        tcell3.Controls.Add(lbl3);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);
        Table1.Rows.Add(trow);
    }

    public long Polno {
        get { return polno; }
        set { polno = value; }
    }

    public string mOF {
        get { return MOF; }
        set { MOF = value; }
    }


    protected void LinkButton1_Click(object sender, EventArgs e) {
        Server.Transfer("~/letters/ProgressEngish001.aspx", true);
    }
    protected void LinkButton2_Click(object sender, EventArgs e) {
        Server.Transfer("~/letters/PregressSin001.aspx", true);
    }
}
