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
using System.Data.Odbc;

public partial class FileScanningReport002 : System.Web.UI.Page
{
    private int requestedDate;
    private int requestedBranch;
    private string branchName; 

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            requestedDate = this.PreviousPage.RequestedDate;
            requestedBranch = this.PreviousPage.RequestedBranch;
        }

        try
        {
            if (!Page.IsPostBack)
            {
                dm = new DataManager();
                string subQueary = "";

                this.lblRequestedDate.Text = requestedDate.ToString().Substring(0, 4) + "/" + requestedDate.ToString().Substring(4, 2) + "/" + requestedDate.ToString().Substring(6, 2);

                if (requestedBranch == 0)
                {
                    this.lblRequestedBranch.Text = "All";
                }
                else
                {
                    string brcodeSelect = "select BRNAM from  GENPAY.BRANCH where BRCOD = " + requestedBranch + "";

                    if (dm.existRecored(brcodeSelect) != 0)
                    {
                        dm.readSql(brcodeSelect);
                        OracleDataReader brcodeReader = dm.oraComm.ExecuteReader();
                        while (brcodeReader.Read())
                        {
                            branchName = brcodeReader.GetString(0);
                        }
                        brcodeReader.Close();
                        brcodeReader.Dispose();

                        this.lblRequestedBranch.Text = branchName;
                    }

                    subQueary = " and SEND_BRANCH = " + requestedBranch + "";
                }

                string sendEmailsSelect = "select * from  LPHS.DEATH_MAILSEND where EMAIL_STATUS='1' and to_char(SEND_DATE,'yyyyMMdd') = '" + requestedDate + "' " + subQueary + "";

                if (dm.existRecored(sendEmailsSelect) != 0)
                {
                    CreateScanFileTableHeader();
                    this.lblmessage.Text = "";
                    string policyNo = "";
                    string lifeType = "";
                    string claimNo = "";
                    string registeredBrn = "";
                    string tegisteredDate = "";
                    string requestedEpfNo = "";
                    string requestedEpfNoAndName = "";
                    string isFileAvailable = "";
                    int rowCount = 0;

                    string sendEmailsDetailsSelect = "select to_char(a.POLICY_NO),  decode(b.DRMOS,'M','Main Life','S','Spouse','2','Second Life','C','Child') as life_type, to_char(a.CLAIM_NO), c.BRCOD || ' - ' || c.BRNAM as reg_branch, TO_CHAR(a.SEND_DATE, 'YYYY-MM-DD - HH24:MI:SS') as reg_datetime, a.SEND_EPF, a.FILE_AVAILABLE " +
                                                     "from LPHS.DEATH_MAILSEND a inner join LPHS.DTHREF b on a.POLICY_NO = b.DRPOLNO and a.CLAIM_NO = b.DRCLMNO " +
                                                     "left outer join GENPAY.BRANCH c on a.SEND_BRANCH = c.BRCOD  " +
                                                     "where a.EMAIL_STATUS='1' and to_char(a.SEND_DATE,'yyyyMMdd') = '" + requestedDate + "' " + subQueary + " " +
                                                     "order by c.BRCOD, a.CLAIM_NO asc";

                    if (dm.existRecored(sendEmailsDetailsSelect) != 0)
                    {
                        dm.readSql(sendEmailsDetailsSelect);
                        OracleDataReader sendEmailDetailsReader = dm.oraComm.ExecuteReader();
                        while (sendEmailDetailsReader.Read())
                        {
                            if (!sendEmailDetailsReader.IsDBNull(0)) { policyNo = sendEmailDetailsReader.GetString(0); } else { policyNo = "-"; }
                            if (!sendEmailDetailsReader.IsDBNull(1)) { lifeType = sendEmailDetailsReader.GetString(1); } else { lifeType = "-"; }
                            if (!sendEmailDetailsReader.IsDBNull(2)) { claimNo = sendEmailDetailsReader.GetString(2); } else { claimNo = "-"; }
                            if (!sendEmailDetailsReader.IsDBNull(3)) { registeredBrn = sendEmailDetailsReader.GetString(3); } else { registeredBrn = "-"; }
                            if (!sendEmailDetailsReader.IsDBNull(4)) { tegisteredDate = sendEmailDetailsReader.GetString(4); } else { tegisteredDate = "-"; }
                            if (!sendEmailDetailsReader.IsDBNull(5)) { requestedEpfNo = sendEmailDetailsReader[5].ToString(); } else { requestedEpfNo = "-"; }
                            if (!sendEmailDetailsReader.IsDBNull(6)) { isFileAvailable = sendEmailDetailsReader.GetString(6); } else { isFileAvailable = "-"; }

                            requestedEpfNoAndName = this.getSacanningEPFANDName(requestedEpfNo);

                            this.createScanFileRequestedTable(policyNo, lifeType, claimNo, registeredBrn, tegisteredDate, requestedEpfNoAndName, isFileAvailable, rowCount);
                            rowCount++;
                        }
                        sendEmailDetailsReader.Close();
                        sendEmailDetailsReader.Dispose();
                    }
                }
                else
                {
                    this.lblmessage.Text = "No Records Found!";
                }
                dm.connClose();

                ViewState["requestedDate"] = requestedDate;
                ViewState["requestedBranch"] = requestedBranch;
            }
            else
            {
                if (ViewState["requestedDate"] != null) { requestedDate = int.Parse(ViewState["requestedDate"].ToString()); }
                if (ViewState["requestedBranch"] != null) { requestedBranch = int.Parse(ViewState["requestedBranch"].ToString()); }
            }
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    public string getSacanningEPFANDName(string epfno)
    {
        string epfAndName = "";
        OdbcConnection con = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");
        try
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

        }
        catch
        {
        }
        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT CONCAT(RTRIM(LTRIM(R.EPFNUM)), CONCAT(' - ', R.USRNAME)) AS USEREPF FROM INTRANET.INTUSR R WHERE trim(R.EPFNUM) = '" + epfno + "'";
        try
        {
            OdbcDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                epfAndName = dr[0].ToString();
            }
        }
        catch (Exception ex)
        {
        }
        con.Close();

        return epfAndName;
    }

    private void CreateScanFileTableHeader()
    {
        TableHeaderRow thRow = new TableHeaderRow();

        TableHeaderCell thc1 = new TableHeaderCell();
        TableHeaderCell thc2 = new TableHeaderCell();
        TableHeaderCell thc3 = new TableHeaderCell();
        TableHeaderCell thc4 = new TableHeaderCell();
        TableHeaderCell thc5 = new TableHeaderCell();
        TableHeaderCell thc6 = new TableHeaderCell();
        TableHeaderCell thc7 = new TableHeaderCell();

        thc1.Text = "Policy No";
        thc2.Text = "Life Type";
        thc3.Text = "Claim No";
        thc4.Text = "Claim Registered Branch";
        thc5.Text = "Claim Registered user and EPF";
        thc6.Text = "Requested Date / Time";        
        thc7.Text = "File Available";

        thRow.Cells.Add(thc1);
        thRow.Cells.Add(thc2);
        thRow.Cells.Add(thc3);
        thRow.Cells.Add(thc4);
        thRow.Cells.Add(thc5);
        thRow.Cells.Add(thc6);
        thRow.Cells.Add(thc7);
        tblScanRequestedFiles.Rows.Add(thRow);

    }

    private void createScanFileRequestedTable(string polNo, string lifeTyp, string clmNo, string regBrn, string regDateTime, string reqEpf, string isfileAvailable, int rowNumber)
    {
        TableRow trow = new TableRow();

        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        TableCell tcell6 = new TableCell();
        TableCell tcell7 = new TableCell();

        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
        Label lbl5 = new Label();
        Label lbl6 = new Label();
        Label lbl7 = new Label();

        lbl1.ID = "policyNo" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "policyNo" + rowNumber); //Text Value
        lbl1.Text = polNo;

        lbl2.ID = "lifeType" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "lifeType" + rowNumber); //Text Value
        lbl2.Text = lifeTyp;

        lbl3.ID = "claimNo" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "claimNo" + rowNumber); //Text Value
        lbl3.Text = clmNo;

        lbl4.ID = "registeredBranch" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "registeredBranch" + rowNumber); //Text Value
        lbl4.Text = regBrn;

        lbl5.ID = "registeredEpf" + rowNumber;
        lbl5.Attributes.Add("runat", "Server");
        lbl5.Attributes.Add("Name", "registeredEpf" + rowNumber); //Text Value
        lbl5.Text = reqEpf;

        lbl6.ID = "requestedDate" + rowNumber;
        lbl6.Attributes.Add("runat", "Server");
        lbl6.Attributes.Add("Name", "requestedDate" + rowNumber); //Text Value
        lbl6.Text = regDateTime;

        lbl7.ID = "isFileAvailable" + rowNumber;
        lbl7.Attributes.Add("runat", "Server");
        lbl7.Attributes.Add("Name", "isFileAvailable" + rowNumber); //Text Value
        lbl7.Text = isfileAvailable;

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(lbl4);
        tcell5.Controls.Add(lbl5);
        tcell6.Controls.Add(lbl6);
        tcell6.CssClass = "textAlign !important";
        tcell7.Controls.Add(lbl7);
        tcell7.CssClass = "textAlign";

        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);
        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell5);
        trow.Cells.Add(tcell6);
        trow.Cells.Add(tcell7);

        tblScanRequestedFiles.Rows.Add(trow);
        tblScanRequestedFiles.CssClass = "ScanFileDetails nom";
    } 

    public int RequestedDate
    {
        get { return requestedDate; }
        set { requestedDate = value; }
    }
    public int RequestedBranch
    {
        get { return requestedBranch; }
        set { requestedBranch = value; }
    }
}
