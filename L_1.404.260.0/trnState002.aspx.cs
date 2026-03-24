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

public partial class trnState002 : System.Web.UI.Page
{

    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2)
        {
            month = "0" + month;
        }
        if (day.Length < 2)
        {
            day = "0" + day;
        }

        ourDate = year + month + day;
        datetime[0] = ourDate;
        // return ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        // return y;
        return datetime;

    }

    private int polno;
    private string MOS;
    private int claimno;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mos;
        }
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                this.lblpolno.Text = polno.ToString();

                if (MOS.Equals("M")) { this.lbllifeType.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lbllifeType.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lbllifeType.Text = "Second Life"; }

              

                #region //------- Intimation and Registration -----
                string confst = "";

                string dthintDetails = "select dsta from lphs.dthint where dpolno=" + polno + " and dmos='" + MOS + "' ";
                if (dm.existRecored(dthintDetails) != 0)
                {
                    dm.readSql(dthintDetails);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { confst = dthintReader.GetString(0); } else { confst = ""; }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                    this.createTable("Intimation Ok", 1);

                    if (confst.Equals("2"))
                    {
                        this.createTable("Registration Ok", 2);
                    }
                    else { this.createTable("Death not Yet Registered", 2); }

                }
                else { this.createTable("No Intimation Details", 1); }

                #endregion

                #region //------- Requirements -----
                int sentDate = 0;
                int recievedDate = 0;
                int sentcount = 0;
                int recievedCount = 0;

                string dreqSelect2 = "select DRSENTDT, DRRECDT from lphs.dreq where drpol=" + polno + " and drtyp='" + MOS + "' ";
                if (dm.existRecored(dreqSelect2) != 0)
                {
                    dm.readSql(dreqSelect2);
                    OracleDataReader dreqreader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader2.Read())
                    {
                        if (!dreqreader2.IsDBNull(0)) { sentDate = dreqreader2.GetInt32(0); } else { sentDate = 0; }
                        if (!dreqreader2.IsDBNull(1)) { recievedDate = dreqreader2.GetInt32(1); } else { recievedDate = 0; }
                        if (sentDate > 0) { sentcount++; }
                        if (recievedDate > 0) { recievedCount++; }
                    }
                    dreqreader2.Close();
                    dreqreader2.Dispose();

                    this.createTable(sentcount.ToString() + " Requirements Called and " + recievedCount + " Requirements Recieved", 3);
                }
                else
                {
                    this.createTable("No Requirements Called", 3);
                }

                #endregion

                #region //------- Payment Memo -----
                double outstandingAmt = 0;
                double totpayAmt = 0;
                string memoapprv = "";
                string payee = "";
                string low = "";
                string payeeWho = "";
                int distnApproval = 0;
                string completed = "";
                string fe_earlypay = "";

                string dthrefSelect = "select amtout, totpayamt, MEMOAPRV, payee, dlow, distn_aut, completed, fe_earlypay from lphs.dthref where drpolno =" + polno + " and drmos ='" + MOS + "' ";
                if (dm.existRecored(dthrefSelect) != 0)
                {
                    dm.readSql(dthrefSelect);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { outstandingAmt = dthrefReader.GetDouble(0); } else { outstandingAmt = 0; }
                        if (!dthrefReader.IsDBNull(1)) { totpayAmt = dthrefReader.GetDouble(1); } else { totpayAmt = 0; }
                        if (!dthrefReader.IsDBNull(2)) { memoapprv = dthrefReader.GetString(2); } else { memoapprv = ""; }
                        if (!dthrefReader.IsDBNull(3)) { payee = dthrefReader.GetString(3); } else { payee = ""; }
                        if (!dthrefReader.IsDBNull(4)) { low = dthrefReader.GetString(4); } else { low = ""; }
                        if (!dthrefReader.IsDBNull(5)) { distnApproval = dthrefReader.GetInt32(5); } else { distnApproval = 0; }
                        if (!dthrefReader.IsDBNull(6)) { completed = dthrefReader.GetString(6); } else { completed = ""; }
                        if (!dthrefReader.IsDBNull(7)) { fe_earlypay = dthrefReader.GetString(7); } else { fe_earlypay = ""; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();

                    if (memoapprv.Equals("Y")) { this.createTable("Paymemnt Memo Approved for a Total Payment of Rs. " + String.Format("{0:N}", totpayAmt), 4); }
                    else { this.createTable("Payment Memo not yet Approved.", 4); }

                    if ((distnApproval > 0) && (payee.Equals("ASI") || payee.Equals("NOM") || payee.Equals("LHI") || payee.Equals("LPT")))
                    {
                        if (payee.Equals("ASI")) { payeeWho = "Assignee"; }
                        else if (payee.Equals("NOM")) { payeeWho = "Nominee"; }
                        else if (payee.Equals("LPT")) { payeeWho = "Living Partner"; }
                        else if (payee.Equals("LHI")) { payeeWho = "Legal Heires"; }

                        this.createTable("Payment Confirmed to Pay to " + payeeWho + " and it is Distributed Among " + distnApproval.ToString(), 5);
                    }
                    else
                    {
                        this.createTable("Payment Distribution not yet Authorized", 5);
                    }

                    if (outstandingAmt != 0) { this.createTable("This Calim Consists Part Payments.", 8); }
                    else { this.createTable("This Claim Doesn't Consist Part Payments", 8); }

                    if (fe_earlypay.Equals("Y")) { this.createTable("Funeral Expenses Paid Early", 11); }
                }

                #endregion

                #region //------- Payment Distribution and Voucher Status -----
                if (distnApproval > 0)
                {
                    //************* Getting Authorized Status **************************
                    int autCount = 0;
                    int vouCount = 0;
                    int okCount = 0;
                    int pendingCount = 0;
                    int cancelCount = 0;
                    int adbVouCount = 0;
                    string PAYSTATUS = "";
                    string vouStatus = "";
                    string ADBVOUSTA = "";

                    if (payee.Equals("LHI"))
                    {
                        string heireSelect = "select LHPAYST, VOUSTA, ADBVOUSTA from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOS + "'  ";
                        if (dm.existRecored(heireSelect) != 0)
                        {
                            dm.readSql(heireSelect);
                            OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (heireSelectReader.Read())
                            {
                                if (!heireSelectReader.IsDBNull(0)) { PAYSTATUS = heireSelectReader.GetString(0); } else { PAYSTATUS = ""; }
                                if (!heireSelectReader.IsDBNull(1)) { vouStatus = heireSelectReader.GetString(1); } else { vouStatus = ""; }
                                if (!heireSelectReader.IsDBNull(2)) { ADBVOUSTA = heireSelectReader.GetString(2); } else { ADBVOUSTA = ""; }
                                if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                                if (PAYSTATUS.Equals("OK")) { okCount++; }
                                else if (PAYSTATUS.Equals("PN")) { pendingCount++; }
                                else if (PAYSTATUS.Equals("NO")) { cancelCount++; }

                                if (vouStatus.Equals("Y")) { vouCount++; }
                                if (ADBVOUSTA.Equals("Y")) { adbVouCount++; }
                            }
                            heireSelectReader.Close();
                            heireSelectReader.Dispose();
                        }
                    }
                    else if (payee.Equals("ASI"))
                    {
                        string asiSelect = "select PAYSTATUS, VOUSTA, ADBVOUSTA from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
                        if (dm.existRecored(asiSelect) != 0)
                        {
                            dm.readSql(asiSelect);
                            OracleDataReader prassReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (prassReader.Read())
                            {
                                if (!prassReader.IsDBNull(0)) { PAYSTATUS = prassReader.GetString(0); } else { PAYSTATUS = ""; }
                                if (!prassReader.IsDBNull(1)) { vouStatus = prassReader.GetString(1); } else { vouStatus = ""; }
                                if (!prassReader.IsDBNull(2)) { ADBVOUSTA = prassReader.GetString(2); } else { ADBVOUSTA = ""; }
                                if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                                if (PAYSTATUS.Equals("OK")) { okCount++; }
                                else if (PAYSTATUS.Equals("PN")) { pendingCount++; }
                                else if (PAYSTATUS.Equals("NO")) { cancelCount++; }

                                if (vouStatus.Equals("Y")) { vouCount++; }
                                if (ADBVOUSTA.Equals("Y")) { adbVouCount++; }
                            }
                            prassReader.Close();
                            prassReader.Dispose();
                        }
                    }
                    else if (payee.Equals("LPT"))
                    {
                        string living_prtSelect = "select PAYSTATUS, VOUSTA, ADBVOUSTA from LUND.LIVING_PRT where polno = " + polno + "  ";
                        if (dm.existRecored(living_prtSelect) != 0)
                        {
                            dm.readSql(living_prtSelect);
                            OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                if (!nomineeReader.IsDBNull(0)) { PAYSTATUS = nomineeReader.GetString(0); } else { PAYSTATUS = ""; }
                                if (!nomineeReader.IsDBNull(1)) { vouStatus = nomineeReader.GetString(1); } else { vouStatus = ""; }
                                if (!nomineeReader.IsDBNull(2)) { ADBVOUSTA = nomineeReader.GetString(2); } else { ADBVOUSTA = ""; }
                                if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                                if (PAYSTATUS.Equals("OK")) { okCount++; }
                                else if (PAYSTATUS.Equals("PN")) { pendingCount++; }
                                else if (PAYSTATUS.Equals("NO")) { cancelCount++; }

                                if (vouStatus.Equals("Y")) { vouCount++; }
                                if (ADBVOUSTA.Equals("Y")) { adbVouCount++; }
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                        }
                    }
                    else if (payee.Equals("NOM"))
                    {
                        string nomSelect = "select PAYSTATUS, VOUSTA, ADBVOUSTA from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                        if (dm.existRecored(nomSelect) != 0)
                        {
                            dm.readSql(nomSelect);
                            OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomineeReader.Read())
                            {
                                if (!nomineeReader.IsDBNull(0)) { PAYSTATUS = nomineeReader.GetString(0); } else { PAYSTATUS = ""; }
                                if (!nomineeReader.IsDBNull(1)) { vouStatus = nomineeReader.GetString(1); } else { vouStatus = ""; }
                                if (!nomineeReader.IsDBNull(2)) { ADBVOUSTA = nomineeReader.GetString(2); } else { ADBVOUSTA = ""; }
                                if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                                if (PAYSTATUS.Equals("OK")) { okCount++; }
                                else if (PAYSTATUS.Equals("PN")) { pendingCount++; }
                                else if (PAYSTATUS.Equals("NO")) { cancelCount++; }

                                if (vouStatus.Equals("Y")) { vouCount++; }
                                if (ADBVOUSTA.Equals("Y")) { adbVouCount++; }
                            }
                            nomineeReader.Close();
                            nomineeReader.Dispose();
                        }
                    }

                    if (distnApproval != autCount) { Response.Write("The 2 Counts In DTHREF and Payee table Doesn't Match!"); }

                    this.createTable("Payment Distributed Among " + autCount.ToString() + " Payments. Vouchers Can be Created for " + okCount.ToString() + " Payments. " + cancelCount.ToString() + " Payments Cancelled. " + pendingCount.ToString() + " Payments Pending.", 6);

                    this.createTable(vouCount.ToString() + " Vouchers Created Among " + okCount.ToString() + " Eligible Payments for Voucher Creation.", 7);

                    if (outstandingAmt > 0) { this.createTable(adbVouCount.ToString() + " Part Payment Vouchers Created for this Claim", 9); }

                }
                #endregion

                #region//---------Claim no-------------------
                string claimnosel = "select DCLM from LPHS.DTHINT where DPOLNO=" + polno + "";
                if (dm.existRecored(claimnosel) != 0)
                {
                    dm.readSql(claimnosel);
                    OracleDataReader clmnoreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    clmnoreader.Read();
                    if (!clmnoreader.IsDBNull(0)) { claimno = clmnoreader.GetInt32(0); } else { claimno = 0; }
                    lblClmno.Text = claimno.ToString();
                    clmnoreader.Close();
                    clmnoreader.Dispose();
                }
                #endregion

                if (completed.Equals("Y")) { this.createTable("Payment Completed", 10); }
                else if (completed.Equals("R")) 
                {
                    this.createTable("Payment Repudiated", 10);

                    string REPU_REASON = ""; int REPU_DATE = 0;
                    string dthepuSel = "select REPU_REASON, REPU_DATE from LPHS.DTH_REPUDIATION where POLICYNO =" + polno + " and LIFE_TYPE = '" + MOS + "' ";
                    if (dm.existRecored(dthepuSel) != 0) 
                    {
                        dm.readSql(dthepuSel);
                        OracleDataReader dthepuReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthepuReader.Read())
                        {
                            if (!dthepuReader.IsDBNull(0)) { REPU_REASON = dthepuReader.GetString(0); } else { REPU_REASON = ""; }
                            if (!dthepuReader.IsDBNull(1)) { REPU_DATE = dthepuReader.GetInt32(1); } else { REPU_DATE = 0; }
                        }
                        dthepuReader.Close();
                        dthepuReader.Dispose();

                        this.createTable("Payment Repudiated Due to " + REPU_REASON + " on " + REPU_DATE.ToString(), 11);
                    }                    
                }

                dm.connclose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }

    private void createTable(string desc, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
      
        Label lbl1 = new Label();

        lbl1.ID = "desc" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "desc" + rowNumber); //Text Value
        lbl1.Text = desc.ToString();
       
        tcell1.Controls.Add(lbl1);
  
        trow.Cells.Add(tcell1);
     
        Table1.Rows.Add(trow);


        try
        {
            int.Parse(desc.Substring(0, 1));
            if ((rowNumber == 3) && (!desc.Equals("")) && (int.Parse(desc.Substring(0, 1)) > 0)) { this.linkbtnReq.Visible = true; }

            if ((rowNumber == 5) && (!desc.Equals("")) && (desc.Substring(0, 9).Equals("Payment C"))) { this.btnpaymemo.Visible = true; }
        
        }
        catch { }
            
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("dthPro001.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("dthPay001.aspx");
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
}
