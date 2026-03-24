using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

public partial class prtPmntSlicVou001 : System.Web.UI.Page
{
    private ArrayList vouIndexes;
    private ArrayList arrListNom;
    private ArrayList arrListLHI;
    private ArrayList arrListADBPayee;
    private string[] ASIarr;
    private string[] LPTarr;

    private string payee;
    private bool isExgracia = false;
    private string payname;

    //private int count;
    private int NOMNUM;
    private int LHNUM;
    private long polno;
    private double totamount;
    private double shareamt;
    private string vouno;
    //private string payeenam;
    //    private int paynum;
    private string EPF;
    private string MOS;
    private int Branch;
    private int claimno;
    private string accountno;
    private string hname;
    private string insname;
    private int slivoutyp = 0;
    private double amtOut = 0.0;

    DataManager dm;
    CompanyVouFields cvf;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null || Session["brcode"] != null)
        {
            EPF = Session["EPFNum"].ToString();
            Branch = Convert.ToInt32(Session["brcode"]);
        }
        //else
        //{
        //    Response.Redirect("SessionError.aspx", false);
        //}

        if (!Page.IsPostBack)
        {
            #region-------get values from previous page---------
            if (PreviousPage != null)
            {
                polno = PreviousPage.Polno;
                vouIndexes = PreviousPage.SlicVou;
                arrListNom = PreviousPage.ArrListNom;
                arrListLHI = PreviousPage.ArrListLHI;
                arrListLHI = PreviousPage.ArrListADBPayee;
                arrListADBPayee = PreviousPage.ArrListADBPayee;
                ASIarr = PreviousPage.aSIarr;
                LPTarr = PreviousPage.lPTarr;
                payee = PreviousPage.Payee;
                totamount = PreviousPage.Totamount;
                EPF = PreviousPage.EPF;
                MOS = PreviousPage.mOS;
                isExgracia = PreviousPage.IsExgracia;
                amtOut = PreviousPage.AmtOut;
            }
            else
            {
                vouIndexes = new ArrayList();
                vouIndexes.Add("1");
                slivoutyp = 1;
                cvf = childProtPay002.Objcvf;
                polno = cvf.Polno;

            }
            //insname=PreviousPage.
            #endregion

            #region---------View State---------
            ViewState["polno"] = polno;
            ViewState["vouIndexes"] = vouIndexes;
            ViewState["arrListNom"] = arrListNom;
            ViewState["arrListLHI"] = arrListLHI;
            ViewState["arrListADBPayee"] = arrListADBPayee;
            ViewState["ASIarr"] = ASIarr;
            ViewState["LPTarr"] = LPTarr;
            ViewState["payee"] = payee;
            ViewState["totAmount"] = totamount;
            ViewState["EPF"] = EPF;
            ViewState["MOS"] = MOS;
            ViewState["Branch"] = Branch;
            ViewState["cvf"] = cvf;
            ViewState["slivoutyp"] = slivoutyp;
            ViewState["isExgracia"] = isExgracia;
            ViewState["amtOut"] = amtOut;
            #endregion
        }
        else
        {
            #region----------view State------------------
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState["vouIndexes"]; }
            if (ViewState["arrListNom"] != null) { arrListNom = (ArrayList)ViewState["arrListNom"]; }
            if (ViewState["arrListLHI"] != null) { arrListLHI = (ArrayList)ViewState["arrListLHI"]; }
            if (ViewState["arrListADBPayee"] != null) { arrListADBPayee = (ArrayList)ViewState["arrListADBPayee"]; }
            if (ViewState["ASIarr"] != null) { ASIarr = (string[])ViewState["ASIarr"]; }
            if (ViewState["LPTarr"] != null) { LPTarr = (string[])ViewState["LPTarr"]; }
            if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
            if (ViewState["totAmount"] != null) { totamount = double.Parse(ViewState["totAmount"].ToString()); }
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }
            if (ViewState["Branch"] != null) { Branch = int.Parse(ViewState["Branch"].ToString()); }
            if (ViewState["cvf"] != null) { cvf = (CompanyVouFields)ViewState["cvf"]; }
            if (ViewState["slivoutyp"] != null) { slivoutyp = int.Parse(ViewState["slivoutyp"].ToString()); }
            if (ViewState["isExgracia"] != null) { isExgracia = bool.Parse(ViewState["isExgracia"].ToString()); }
            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
            #endregion
        }
        if (slivoutyp == 0)
        {
            #region---------------create payee table---------------
            int index = 0;

            foreach (string str in vouIndexes)
            {
                index = int.Parse(str);
                if (payee.Equals("NOM"))
                {
                    foreach (string[] nomstr in arrListNom)
                    {
                        NOMNUM = int.Parse(nomstr[4]);
                        if (NOMNUM == index)
                        {
                            payname = nomstr[0];
                            createVouDetTable(index, payname);

                        }
                    }
                }
                else if (payee.Equals("ASI"))
                {
                    payname = ASIarr[0];
                    createVouDetTable(index, payname);
                }
                else if (payee.Equals("LPT"))
                {
                    payname = LPTarr[0];
                    createVouDetTable(index, payname);
                }
                else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                {
                    foreach (string[] lhirstr in arrListLHI)
                    {
                        LHNUM = int.Parse(lhirstr[4]);
                        if (LHNUM == index)
                        {
                            payname = lhirstr[1];

                            createVouDetTable(index, payname);
                        }
                    }

                }
                else
                {
                    throw new Exception("Cannot Create SLIC voucher for this Recepient!");
                }

                if (arrListADBPayee.Count > 0)
                {
                    index = 0;
                    foreach (string[] adbstr in arrListADBPayee)
                    {
                        LHNUM = int.Parse(adbstr[3]);
                        if (LHNUM == index)
                        {
                            payname = adbstr[8];

                            createVouDetTable(index, payname);
                        }
                    }
                }
            }
            #endregion

            if (vouIndexes.Count == 0) { btnCreate.Enabled = false; }
        }
        else
        {
            createVouDetTable(1, cvf.Payeenam);
        }

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        double amount;
        string reason;
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            foreach (string strobj in vouIndexes)
            {
                int index = int.Parse(strobj);
                string amtstr = "txtAmount" + index;
                string reasonstr = "txtreason" + index;
                string acctstr = "ddlAcctno" + index;

                TextBox txtAmt = (TextBox)Table1.FindControl(amtstr);
                TextBox txtReason = (TextBox)Table1.FindControl(reasonstr);
                DropDownList ddlAccount = (DropDownList)Table1.FindControl(acctstr);

                if (txtAmt.Text != null) { amount = double.Parse(txtAmt.Text.Trim()); } else { amount = 0; }
                if (txtReason.Text != null) { reason = txtReason.Text.Trim(); } else { reason = ""; }
                accountno = ddlAccount.SelectedItem.Value;

                if (slivoutyp == 0)
                {
                    if (payee.Equals("NOM"))
                    {
                        foreach (string[] nomstr in arrListNom)
                        {
                            NOMNUM = int.Parse(nomstr[4]);
                            if (NOMNUM == index)
                            {
                                shareamt = double.Parse(nomstr[5]);
                                payname = nomstr[0];
                            }
                        }
                    }
                    else if (payee.Equals("ASI"))
                    {
                        shareamt = amtOut;
                        payname = ASIarr[0];
                    }
                    else if (payee.Equals("LPT"))
                    {
                        shareamt = amtOut;
                        payname = LPTarr[0];
                    }
                    else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                    {
                        foreach (string[] lhirstr in arrListLHI)
                        {
                            LHNUM = int.Parse(lhirstr[4]);
                            if (LHNUM == index)
                            {
                                shareamt = double.Parse(lhirstr[6]);
                                payname = lhirstr[1];
                            }
                        }
                    }
                }
                else
                {
                    //------Update amount in periodic_paydet table-----------                                        
                    shareamt = cvf.Share;
                    payname = cvf.Payeenam;
                    MOS = cvf.Mos;
                }
                if (shareamt - amount < 0) { throw new Exception("Your Voucher Amount Exceeds Share Amount!"); }
                else
                {
                    if (slivoutyp == 1)
                    {
                        this.PayAmountAdjustment(polno, amount, cvf.Clmtyp, dm);
                        payee = cvf.Clmtyp;
                    }
                    vouno = dm.voucher_numberSL(DateTime.Now.ToString("yyyyMMdd").Substring(0, 4), Branch.ToString());

                    #region //------------ PHNAME ---------------------
                    string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR  from LPHS.PHNAME where pnpol='" + polno + "'";
                    dm.readSql(sql);
                    OracleDataReader oraDtReader = dm.oraComm.ExecuteReader();
                    while (oraDtReader.Read())
                    {
                        if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                        {
                            insname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                        }
                        else { insname = ""; }
                    }
                    oraDtReader.Close();
                    //oraDtReader.Dispose();
                    #endregion

                    detinsert(amount, reason, shareamt, payee, vouno, index, payname);
                }
            }
            dm.commit();
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connClose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        this.lblsuccess.Text = "Vouchers Successfully Created";
        btnCreate.Enabled = false;

    }

    private void createVouDetTable(int rowno, string payee)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();
        TableRow namerow = new TableRow();
        TableRow trowspace = new TableRow();

        TableCell tcell11 = new TableCell();
        TableCell tcell12 = new TableCell();
        tcell12.Style["text-align"] = "Left";
        TableCell tcell13 = new TableCell();
        tcell13.Style["text-align"] = "Left";
        TableCell tcell21 = new TableCell();
        TableCell tcell22 = new TableCell();
        TableCell namecell1 = new TableCell();
        namecell1.Style["text-align"] = "Right";
        TableCell namecell2 = new TableCell();
        namecell2.Style["text-align"] = "Left";
        TableCell tcell31 = new TableCell();
        tcell31.Style["text-align"] = "Left";
        TableCell tcell32 = new TableCell();
        tcell32.Style["text-align"] = "Left";

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lblname1 = new Label();
        Label lblname2 = new Label();
        Label lblacctno31 = new Label();

        TextBox txt11 = new TextBox();
        TextBox txt21 = new TextBox();

        DropDownList ddlacctno31 = new DropDownList();

        lbl11.ID = "lblAmount" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "lblAmount" + rowno);
        lbl11.Text = "Amount :";

        txt11.ID = "txtAmount" + rowno;
        txt11.Attributes.Add("runat", "Server");
        txt11.Attributes.Add("Name", "txtAmount" + rowno);
        txt11.Style["width"] = "100px";

        lbl12.ID = "lblAcctno" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "lblAcctno" + rowno);
        lbl12.Text = "SLIC A/C No. :";

        ddlacctno31.ID = "ddlAcctno" + rowno;
        ddlacctno31.Attributes.Add("runat", "Server");
        ddlacctno31.Attributes.Add("Name", "ddlAcctno" + rowno);
        ddlacctno31.Items.Add(new ListItem("1030001487", "1030001487"));
        ddlacctno31.Items.Add(new ListItem("1364403002", "1364403002"));
        ddlacctno31.Items.Add(new ListItem("0001092995", "0001092995"));
        ddlacctno31.Items.Add(new ListItem("000000000962", "000000000962"));

        ddlacctno31.SelectedValue = "000000000962";

        lblacctno31.ID = "acctno" + rowno;
        lblacctno31.Attributes.Add("runat", "Server");
        lblacctno31.Attributes.Add("Name", "acctno" + rowno);
        lblacctno31.Text = "Account No";

        lbl21.ID = "lblReason" + rowno;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "lblReason" + rowno);
        lbl21.Text = "Reason :";

        txt21.ID = "txtReason" + rowno;
        txt21.Attributes.Add("runat", "Server");
        txt21.Attributes.Add("Name", "txtreason" + rowno);
        txt21.Style["width"] = "400px";

        lblname1.ID = "lblname1" + rowno;
        lblname1.Attributes.Add("runat", "Server");
        lblname1.Attributes.Add("Name", "txtname1" + rowno);
        lblname1.Text = "Payer :";

        lblname2.ID = "lblname2" + rowno;
        lblname2.Attributes.Add("runat", "Server");
        lblname2.Attributes.Add("Name", "lblname2" + rowno);
        lblname2.Text = payee;

        namecell1.Controls.Add(lblname1);
        namecell2.Controls.Add(lblname2);
        tcell11.Controls.Add(lbl11);
        tcell12.Controls.Add(txt11);
        tcell21.Controls.Add(lbl21);
        tcell22.Controls.Add(txt21);
        tcell31.Controls.Add(lblacctno31);
        tcell32.Controls.Add(ddlacctno31);

        namerow.Cells.Add(namecell1);
        namerow.Cells.Add(namecell2);
        trow1.Cells.Add(tcell11);
        trow1.Cells.Add(tcell12);
        trow2.Cells.Add(tcell21);
        trow2.Cells.Add(tcell22);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);

        Table1.Rows.Add(namerow);
        Table1.Rows.Add(trow1);
        Table1.Rows.Add(trow2);
        Table1.Rows.Add(trow3);
        Table1.Rows.Add(trowspace);
    }

    public void detinsert(double amt, string reas, double share, string paydet, string vou, int paynum, string payeenam)
    {
        //int ACCODE = 2118;
        int ACCODE = 0;
        if (!isExgracia)
        {
            ACCODE = 2118;
        }
        else
        {
            ACCODE = 2142;
        }
        NumberSeparate ns = new NumberSeparate(reas);
        BankDetailsBreak bdb;
        string propno = "", hname1 = "", hname2 = "";
        if (ns.Number != null)
        {
            propno = " PROP. NO: " + ns.Number.ToString();
        }
        try
        {
            hname = "SRI LANKA INSURANCE CORPORATION LIFE LTD.";
            bdb = new BankDetailsBreak("", "", "", hname + propno);
            hname1 = bdb.Hname1;
            hname2 = bdb.Hname2;
            string payadd1 = "NO.21,";
            string payadd2 = "VAUXHALL STREET,";
            string payadd3 = "COLOMBO 02.";
            //string payadd = "";//hname;

            int today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //--------Slic vouchers------
            string slicvousel = "select * from LPHS.SLICVOUCHERS where SVPOL=" + polno + " and SVCLMTYP='DTH' and SYSTEM_TYPE='PP' and SVPAYEE='" + paydet + "' and SVPAYNUM=" + paynum + "";
            if (dm.existRecored(slicvousel) == 0)
            {
                string slicvouinsert = "insert into LPHS.SLICVOUCHERS(SVPOL, SVCLMTYP, SVVOUNO, SVDATE, SVREASON, SVPAYEE, SVMOS, SVEPF, SVAMT, SVPAYEENAM, SVPAYNUM, SYSTEM_TYPE) values(" + polno + ", 'DTH', '" + vou + "', " + today + ", '" + reas + "', '" + paydet + "', '" + MOS + "', '" + EPF + "', " + amt + ", '" + payeenam + "', " + paynum + " , 'PP')";
                dm.insertRecords(slicvouinsert);

                //--------Temp_cb---------
                #region--------------------Branch no formating------------------
                string branchstr;
                if (Branch.ToString().Length == 1) { branchstr = "00" + Branch.ToString(); }
                else if (Branch.ToString().Length == 2) { branchstr = "0" + Branch.ToString(); }
                else { branchstr = Branch.ToString(); }
                #endregion

                string cashbooksel = "select * from CASHBOOK.TEMP_CB where POLNO=" + polno + " and VOUNO='" + vou + "'";
                if (dm.existRecored(cashbooksel) == 0)
                {
                    string tempcbinsert = "insert into CASHBOOK.TEMP_CB(CLASS, BUSYCODE, DIVCODE, BCODE, CLAIMNO, POLNO, HNAME, HNAME1, TOTAMOUNT, TOTAMT, ACCODE, ACNO, VOUNO, VOUDATE, BILLDATE, CLAIMTYPE, ADDEPF, VOUTYP, STATUS, PRINT1, AUTHORIZED, DELETED, CHQCAN, PAYAUT, INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, TRANSACTION_TYPE, GROSS_AMOUNT)";
                    tempcbinsert += "values('L', '3', 'L', '" + branchstr + "'," + claimno + ", " + polno + ", '" + hname1 + "', '" + hname2 + "', " + amt + ", '" + String.Format("{0:N}", amt) + "', " + ACCODE + ", '" + accountno + "', '" + vou + "', sysdate, sysdate, 'A', '" + EPF + "', 'Death', 'Pending', 0, 0, 0, 0, 0, '" + insname + "', '" + payadd1
                        + "', '" + payadd2 + "', '" + payadd3 + "', '" + hname + "', 'C', " + amt + ")";
                    dm.insertRecords(tempcbinsert);

                    string tempdetailinsert = "insert into CASHBOOK.TEMP_DETL(VOUNO, ACCODE, AMOUNT, TOTAL, BRANCH_CODE, ACCOUNT_DATE) values('" + vou + "', '" + ACCODE.ToString() + "', " + amt + ", " + amt + ", " + Branch + ", sysdate)";
                    dm.insertRecords(tempdetailinsert);
                }
            }
            else
            { //dm.connclose(); 
                throw new Exception("This Voucher is Already Created!");
            }
        }
        catch (Exception Ex)
        {
            //dm.connclose();
            throw Ex;
        }
    }
    public void PayAmountAdjustment(long polno, double amount, string clmtyp, DataManager dm)
    {
        double amt;
        int paydue;

        try
        {
            string periodicpaysel = "select PAID_AMT, PAYMENT_DUE from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and VONO='XXXX' ";
            if (dm.existRecored(periodicpaysel) != 0)
            {
                dm.readSql(periodicpaysel);
                OracleDataReader periodicreader = dm.oraComm.ExecuteReader();
                while (periodicreader.Read())
                {
                    if (!periodicreader.IsDBNull(0)) { amt = periodicreader.GetDouble(0); } else { amt = 0; }
                    if (!periodicreader.IsDBNull(1)) { paydue = periodicreader.GetInt32(1); } else { paydue = 0; }

                    if (amt <= amount)
                    {
                        amount -= amt;
                        amt = 0;
                    }
                    else
                    {
                        amt -= amount;
                        amount = 0;
                    }
                    string periodicpaydetupd = "update LCLM.PERIODIC_PAYDET set PAID_AMT=" + amt + " where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and PAYMENT_DUE=" + paydue + "";
                    dm.insertRecords(periodicpaydetupd);
                }
                periodicreader.Close();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

    }
}
