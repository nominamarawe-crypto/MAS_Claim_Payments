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

public partial class ADBvouCreate001 : System.Web.UI.Page
{
    public string[] setDate()
    {
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

    private int branch = 0;      //session branch
    private string EPF;      //session epf
    private int clmno;
    private string phname = "";

    private int polno;
    private string MOS;

    private double totamount;
    private double amtOut;
    private string payee = "";
    private bool isExgracia = false;

    private int NOMNUM;
    private int heireNo;

    private string name = "";
    private string addr1 = "";
    private string addr2 = "";
    private string addr3 = "";
    private string addr4 = "";

    private string bankkname = "";
    private string bkBrn = "";
    private string acctNo = "";
    private string SLIAcctNo = "";

    DataManager dthpayObj;
    BankDetailsBreak bdb;

    private ArrayList arrListNom;
    private ArrayList arrListLHI;
    private ArrayList arrListADBPayee;
    private string[] ASIarr;
    private string[] LPTarr;
    private ArrayList vouIndexes;

    private int recCount;
    private int vouCountStatic;
    private int vouToBeCreatedCount;
    private bool isADBPayee = false;
    // if vouCountStatic + vouToBeCreatedCount = recCount that implies payment is completed


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null && Session["brcode"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            EPF = Session["EPFNum"].ToString();
            branch = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        //branch = Convert.ToInt32(Session["brcode"]);
        //EPF = Session["EPFNum"].ToString();

        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            #region //------------ getting values -------
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mOS;
            totamount = this.PreviousPage.Totamount;
            payee = this.PreviousPage.Payee;
            recCount = this.PreviousPage.RecCount;
            vouCountStatic = this.PreviousPage.VouCountStatic;
            vouToBeCreatedCount = this.PreviousPage.VouToBeCreatedCount;
            vouIndexes = this.PreviousPage.VouIndexes;
            arrListNom = this.PreviousPage.ArrListNom;
            arrListLHI = this.PreviousPage.ArrListLHI;
            arrListADBPayee = this.PreviousPage.ArrListADBPayee;
            ASIarr = this.PreviousPage.aSIarr;
            LPTarr = this.PreviousPage.lPTarr;
            amtOut = this.PreviousPage.AmtOut;
            isExgracia = this.PreviousPage.IsExgracia;
            isADBPayee = this.PreviousPage.IsADBPayee;
            #endregion
        }
        dthpayObj = new DataManager();
        try
        {
            #region --- view state ---
            if (Page.IsPostBack)
            {
                if (ViewState["branch"] != null) { branch = int.Parse(ViewState["branch"].ToString()); }
                if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
                if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
                if (ViewState["phname"] != null) { phname = ViewState["phname"].ToString(); }

                if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }

                if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
                if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
                if (ViewState["isExgracia"] != null) { isExgracia = bool.Parse(ViewState["isExgracia"].ToString()); }

                if (ViewState["arrListNom"] != null) { arrListNom = (ArrayList)ViewState["arrListNom"]; }
                if (ViewState["arrListLHI"] != null) { arrListLHI = (ArrayList)ViewState["arrListLHI"]; }
                if (ViewState["arrListADBPayee"] != null) { arrListADBPayee = (ArrayList)ViewState["arrListADBPayee"]; }
                if (ViewState["ASIarr"] != null) { ASIarr = (string[])ViewState["ASIarr"]; }
                if (ViewState["LPTarr"] != null) { LPTarr = (string[])ViewState["LPTarr"]; }
                if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState["vouIndexes"]; }

                if (ViewState["recCount"] != null) { recCount = int.Parse(ViewState["recCount"].ToString()); }
                if (ViewState["vouCountStatic"] != null) { vouCountStatic = int.Parse(ViewState["vouCountStatic"].ToString()); }
                if (ViewState["vouToBeCreatedCount"] != null) { vouToBeCreatedCount = int.Parse(ViewState["vouToBeCreatedCount"].ToString()); }

                if (ViewState["isADBPayee"] != null) { isADBPayee = bool.Parse(ViewState["isADBPayee"].ToString()); }
            }
            #endregion

            int index = 0;
            double amount = 0;
            foreach (string str in vouIndexes)
            {
                index = int.Parse(str);

                //*********** creating controls *************
                if (payee.Equals("NOM"))
                {
                    #region
                    double nomiShare = 0;
                    foreach (string[] strArr in arrListNom)
                    {
                        NOMNUM = int.Parse(strArr[4]);
                        if (index == NOMNUM)
                        {
                            name = strArr[0];
                            addr1 = strArr[1];
                            addr2 = strArr[2];
                            addr3 = strArr[7];
                            addr4 = strArr[8];
                            //PER = int.Parse(strArr[3]);
                            nomiShare = double.Parse(strArr[5]);
                            amount = this.Sliamount(polno, "NOM", MOS, NOMNUM, "PP");
                            nomiShare -= amount;
                            this.createVouDetTable(name, addr1, addr2, addr3, addr4, nomiShare, NOMNUM, "0", "Nominee");
                        }
                    }
                    #endregion
                }
                else if (payee.Equals("ASI") && !isADBPayee)
                {
                    #region
                    double asiamt = amtOut;
                    name = ASIarr[0];
                    addr1 = ASIarr[1];
                    addr2 = ASIarr[2];
                    addr3 = ASIarr[4];
                    addr4 = "";
                    acctNo = ASIarr[3];
                    amount = this.Sliamount(polno, "ASI", MOS, 1, "PP");
                    //amtOut -= amount;
                    asiamt -= amount;
                    //this.createVouDetTable(name, addr1, addr2, addr3, addr4, amtOut, index, acctNo.ToString(), "Assignee");
                    this.createVouDetTable(name, addr1, addr2, addr3, addr4, asiamt, index, acctNo.ToString(), "Assignee");
                    #endregion
                }
                else if (payee.Equals("LPT"))
                {
                    #region
                    double lptamt = amtOut;
                    name = LPTarr[0];
                    addr1 = LPTarr[1];
                    addr2 = LPTarr[2];
                    addr3 = LPTarr[3];
                    addr4 = LPTarr[4];
                    amount = this.Sliamount(polno, "LPT", MOS, 1, "PP");
                    //amtOut -= amount;
                    lptamt -= amount;
                    //this.createVouDetTable(name, addr1, addr2, addr3, addr4, amtOut, index, "0", "Living Partner");
                    this.createVouDetTable(name, addr1, addr2, addr3, addr4, lptamt, index, "0", "Living Partner");
                    #endregion
                }
                else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                {
                    #region
                    double heireShare = 0;
                    string theHeire = "";
                    foreach (string[] hd in arrListLHI)
                    {
                        heireNo = int.Parse(hd[4]);
                        if (index == heireNo)
                        {
                            theHeire = hd[0];
                            name = hd[1];
                            addr1 = hd[2];
                            addr2 = hd[3];
                            addr3 = hd[7];
                            addr4 = hd[8];
                            heireShare = double.Parse(hd[6]);
                            amount = this.Sliamount(polno, "LHI", MOS, heireNo, "PP");
                            heireShare -= amount;
                            this.createVouDetTable(name, addr1, addr2, addr3, addr4, heireShare, heireNo, "0", theHeire);
                        }
                    }
                    #endregion
                }

                #region ------------- ADB Payee -----------------
                if (arrListADBPayee.Count > 0)
                { 
                    double heireShare = 0;
                    string theHeire = "";
                    foreach (string[] adb in arrListADBPayee)
                    {
                        heireNo = int.Parse(adb[3]);
                        if (index == heireNo)
                        {
                            theHeire = adb[0];
                            name = adb[8];
                            addr1 = adb[4];
                            addr2 = adb[5];
                            addr3 = adb[6];
                            addr4 = adb[7];
                            heireShare = double.Parse(adb[9]);
                            amount = this.Sliamount(polno, "LHI", MOS, heireNo, "PP");
                            heireShare -= amount;
                            this.createVouDetTable(name, addr1, addr2, addr3, addr4, heireShare, heireNo, "0", theHeire);
                        }
                    }
                }
                #endregion

                if (index == 0) { this.btnOK.Enabled = false; }

                this.lblpolno.Text = polno.ToString();
                if (MOS.Equals("M")) { this.lblmof.Text = "Main LIfe"; }
                else if (MOS.Equals("S")) { this.lblmof.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lblmof.Text = "Second Life"; }

                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR  from LPHS.PHNAME where pnpol='" + polno + "'";
                dthpayObj.readSql(sql);
                OracleDataReader oraDtReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (oraDtReader.Read())
                {
                    if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                    {
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                    }
                    else { phname = ""; }
                }
                oraDtReader.Close();
                oraDtReader.Dispose();
                this.lblphname.Text = phname;               
            }
            dthpayObj.connclose();

            #region --- add to view state ---
            if (!Page.IsPostBack)
            {
                ViewState["branch"] = branch;
                ViewState["EPF"] = EPF;
                ViewState["clmno"] = clmno;
                ViewState["phname"] = phname;

                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;

                ViewState["totamount"] = totamount;
                ViewState["amtOut"] = amtOut;
                ViewState["payee"] = payee;
                ViewState["isExgracia"] = isExgracia;

                ViewState["arrListNom"] = arrListNom;
                ViewState["arrListLHI"] = arrListLHI;
                ViewState["arrListADBPayee"] = arrListADBPayee;
                ViewState["ASIarr"] = ASIarr;
                ViewState["LPTarr"] = LPTarr;
                ViewState["vouIndexes"] = vouIndexes;

                ViewState["recCount"] = recCount;
                ViewState["vouCountStatic"] = vouCountStatic;
                ViewState["vouToBeCreatedCount"] = vouToBeCreatedCount;
                ViewState["isADBPayee"] = isADBPayee;
            }
            #endregion
        }
        catch (Exception ex)
        {
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

     

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        dthpayObj = new DataManager();
        try
        {
            string ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            dthpayObj.begintransaction();

            string clmnoSel = "select DRCLMNO from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "'";
            dthpayObj.readSql(clmnoSel);
            OracleDataReader clmnoReader = dthpayObj.oraComm.ExecuteReader();
            while (clmnoReader.Read())
            {
                if (!clmnoReader.IsDBNull(0)) { clmno = clmnoReader.GetInt32(0); } else { clmno = 0; }
            }
            clmnoReader.Close();
            //clmnoReader.Dispose();

            string vounum = "";
            int vouNoInqCount = 0;

            foreach (string strobj in vouIndexes)
            {

                int index = int.Parse(strobj);
                double amount = 0;
                string s1 = "bknametxt" + index.ToString();
                string s2 = "bkBrntxt" + index.ToString();
                string s3 = "acctNotxt" + index.ToString();
                string s4 = "slicAcctddl" + index.ToString();

                TextBox txtbkName = (TextBox)Table1.FindControl(s1);
                TextBox txtbkBrn = (TextBox)Table1.FindControl(s2);
                TextBox txtbkAcctNo = (TextBox)Table1.FindControl(s3);
                DropDownList ddlslicAcct = (DropDownList)Table1.FindControl(s4);

                if (!(txtbkName == null)) { bankkname = txtbkName.Text.Trim(); }
                if (!(txtbkBrn == null)) { bkBrn = txtbkBrn.Text.Trim(); }
                if (!(txtbkAcctNo == null)) { acctNo = txtbkAcctNo.Text.Trim(); }
                if (ddlslicAcct != null) { SLIAcctNo = ddlslicAcct.SelectedItem.Value; }

                //********* Update Payee Tables ***************************
                if (payee.Equals("NOM"))
                {
                    double nomiShare = 0;
                    foreach (string[] strArr in arrListNom)
                    {
                        NOMNUM = int.Parse(strArr[4]);
                        if (index == NOMNUM)
                        {
                            name = strArr[0];
                            addr1 = strArr[1];
                            addr2 = strArr[2];
                            addr3 = strArr[7];
                            addr4 = strArr[8];
                            nomiShare = double.Parse(strArr[5]);
                            amount = this.Sliamount(polno, "NOM", MOS, NOMNUM, "PP");
                            nomiShare -= amount;
                            vounum = this.createVoucher(nomiShare, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                            string nomsel = "select * from LUND.NOMINEE WHERE polno =" + polno + " and nomno = " + NOMNUM + " and ADBVOUNO is null";
                            if (dthpayObj.existRecored(nomsel) == 0)
                            {
                                //dthpayObj.connclose();
                                throw new Exception("This voucher has already created!");
                            }

                            string nomUpd = "UPDATE LUND.NOMINEE SET ADBVOUSTA = 'Y' , ADBVOUNO = '" + vounum + "', ADBVOUDATE=to_char(sysdate, 'yyyymmdd'),"+
                                "  ADBAUTDATE = " + int.Parse(this.setDate()[0]) + ", ADBAUTEPF ='" + EPF + "' WHERE polno =" + polno + " and nomno = " + NOMNUM + " ";
                            dthpayObj.insertRecords(nomUpd);
                            vouNoInqCount++;
                            this.createVouNoTable(name, nomiShare, vounum, vouNoInqCount);

                            #region   //----------- DTHREF outstanding amount update --------

                            double TOTPAYAMT = 0;
                            double AMTOUT = 0;
                            double newTOTPAYAMT = 0;
                            double newAMTOUT = 0;

                            string dhreftotamtSel = "select TOTPAYAMT, AMTOUT from lphs.dthref where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.readSql(dhreftotamtSel);
                            OracleDataReader totamtReader = dthpayObj.oraComm.ExecuteReader();
                            while (totamtReader.Read())
                            {
                                if (!totamtReader.IsDBNull(0)) { TOTPAYAMT = totamtReader.GetDouble(0); }
                                if (!totamtReader.IsDBNull(1)) { AMTOUT = totamtReader.GetDouble(1); }
                            }
                            totamtReader.Close();
                            //totamtReader.Dispose();

                            newTOTPAYAMT = TOTPAYAMT + nomiShare;
                            //newAMTOUT = AMTOUT - nomiShare;
                            newAMTOUT = AMTOUT - nomiShare - amount;

                            string totamtUPD = "update lphs.dthref set TOTPAYAMT = " + newTOTPAYAMT + ", AMTOUT =" + newAMTOUT + "  where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.insertRecords(totamtUPD);
                            #endregion
                        }
                    }
                }
                else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                {
                    double heireShare = 0;
                    string theHeire = "";
                    foreach (string[] hd in arrListLHI)
                    {
                        heireNo = int.Parse(hd[4]);
                        if (index == heireNo)
                        {
                            theHeire = hd[0];
                            name = hd[1];
                            addr1 = hd[2];
                            addr2 = hd[3];
                            addr3 = hd[7];
                            addr4 = hd[8];
                            heireShare = double.Parse(hd[6]);
                            amount = this.Sliamount(polno, "LHI", MOS, heireNo, "PP");
                            heireShare -= amount;
                            vounum = this.createVoucher(heireShare, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                            string lhisel = "select * from LPHS.LEGAL_HIRES where LHPOLNO = " + polno + " and LHMOF ='" + MOS + "' and LHHNO =" + heireNo + " and ADBVOUNO is null";
                            if (dthpayObj.existRecored(lhisel) == 0)
                            {
                                //dthpayObj.connclose();
                                throw new Exception("This voucher has already created!");
                            }

                            string LHUpd = "UPDATE LPHS.LEGAL_HIRES SET ADBVOUSTA = 'Y' , ADBVOUNO = '" + vounum + "', ADBVOUDATE=to_char(sysdate, 'yyyymmdd')," +
                                " ADBAMT = " + heireShare + ", ADBAUTDATE = " + int.Parse(this.setDate()[0]) + ", ADBAUTEPF ='" + EPF + "' "+
                                " WHERE LHPOLNO = " + polno + " and LHMOF ='" + MOS + "' and LHHNO =" + heireNo + " ";
                            dthpayObj.insertRecords(LHUpd);
                            vouNoInqCount++;
                            this.createVouNoTable(name, heireShare, vounum, vouNoInqCount);

                            #region   //----------- DTHREF outstanding amount update --------
                            double TOTPAYAMT = 0;
                            double AMTOUT = 0;
                            double newTOTPAYAMT = 0;
                            double newAMTOUT = 0;

                            string dhreftotamtSel = "select TOTPAYAMT, AMTOUT from lphs.dthref where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.readSql(dhreftotamtSel);
                            OracleDataReader totamtReader = dthpayObj.oraComm.ExecuteReader();
                            while (totamtReader.Read())
                            {
                                if (!totamtReader.IsDBNull(0)) { TOTPAYAMT = totamtReader.GetDouble(0); }
                                if (!totamtReader.IsDBNull(1)) { AMTOUT = totamtReader.GetDouble(1); }
                            }
                            totamtReader.Close();
                            //totamtReader.Dispose();

                            newTOTPAYAMT = TOTPAYAMT + heireShare;
                            //newAMTOUT = AMTOUT - heireShare;
                            newAMTOUT = AMTOUT - heireShare - amount;

                            string totamtUPD = "update lphs.dthref set TOTPAYAMT = " + newTOTPAYAMT + ", AMTOUT =" + newAMTOUT + "  where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.insertRecords(totamtUPD);
                            #endregion
                        }
                    }
                }
                else if (payee.Equals("ASI") && !isADBPayee)
                {
                    double asiamt = amtOut;
                    name = ASIarr[0];
                    addr1 = ASIarr[1];
                    addr2 = ASIarr[2];
                    addr3 = ASIarr[3];
                    addr4 = "";
                    amount = this.Sliamount(polno, "ASI", MOS, 1, "PP");
                    //amtOut -= amount;
                    asiamt -= amount;
                    string assigneesel = "select * from LUND.ASSIGNEE WHERE POLICY_NO = " + polno + " and ADBVOUNO is null";
                    if (dthpayObj.existRecored(assigneesel) == 0)
                    {
                        //dthpayObj.connclose();
                        throw new Exception("This voucher has already created!");
                    }
                    //vounum = this.createVoucher(amtOut, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                    vounum = this.createVoucher(asiamt, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                    string assigneeUpd = "UPDATE LUND.ASSIGNEE SET ADBVOUSTA = 'Y' , ADBVOUNO = '" + vounum + "', ADBAUTDATE = " + int.Parse(this.setDate()[0]) + ", ADBAUTEPF ='" + EPF + "', ADBVOUDATE=to_char(sysdate, 'yyyymmdd') WHERE POLICY_NO = " + polno + "";
                    dthpayObj.insertRecords(assigneeUpd);
                    vouNoInqCount++;
                    //this.createVouNoTable(name, amtOut, vounum, vouNoInqCount);
                    this.createVouNoTable(name, asiamt, vounum, vouNoInqCount);

                    #region   //----------- DTHREF outstanding amount update --------
                    double TOTPAYAMT = 0;
                    double AMTOUT = 0;
                    double newTOTPAYAMT = 0;
                    double newAMTOUT = 0;

                    string dhreftotamtSel = "select TOTPAYAMT, AMTOUT from lphs.dthref where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                    dthpayObj.readSql(dhreftotamtSel);
                    OracleDataReader totamtReader = dthpayObj.oraComm.ExecuteReader();
                    while (totamtReader.Read())
                    {
                        if (!totamtReader.IsDBNull(0)) { TOTPAYAMT = totamtReader.GetDouble(0); }
                        if (!totamtReader.IsDBNull(1)) { AMTOUT = totamtReader.GetDouble(1); }
                    }
                    totamtReader.Close();
                    //totamtReader.Dispose();

                    //newTOTPAYAMT = TOTPAYAMT + amtOut;
                    newTOTPAYAMT = TOTPAYAMT + asiamt;
                    //newAMTOUT = AMTOUT - amtOut;
                    //newAMTOUT = AMTOUT - amtOut - amount;
                    newAMTOUT = AMTOUT - asiamt - amount;

                    string totamtUPD = "update lphs.dthref set TOTPAYAMT = " + newTOTPAYAMT + ", AMTOUT =" + newAMTOUT + "  where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                    dthpayObj.insertRecords(totamtUPD);
                    #endregion

                }
                else if (payee.Equals("LPT"))
                {
                    double lptamt = amtOut;
                    name = LPTarr[0];
                    addr1 = LPTarr[1];
                    addr2 = LPTarr[2];
                    addr3 = LPTarr[3];
                    addr4 = LPTarr[4];
                    amount = this.Sliamount(polno, "ASI", MOS, 1, "PP");
                    //amtOut -= amount;
                    lptamt -= amount;
                    string assigneesel = "select * from LUND.LIVING_PRT WHERE POLNO = " + polno + " and ADBVOUNO is null";
                    if (dthpayObj.existRecored(assigneesel) == 0)
                    {
                        //dthpayObj.connclose();
                        throw new Exception("This voucher has already created!");
                    }
                    //vounum = this.createVoucher(amtOut, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                    vounum = this.createVoucher(lptamt, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                    string LPTUpd = "UPDATE LUND.LIVING_PRT SET ADBVOUSTA = 'Y' , ADBVOUNO = '" + vounum + "', ADBAUTDATE = " + int.Parse(this.setDate()[0]) + ", ADBAUTEPF ='" + EPF + "', ADBVOUDATE=to_char(sysdate, 'yyyymmdd')  WHERE POLNO = " + polno + "";
                    dthpayObj.insertRecords(LPTUpd);
                    vouNoInqCount++;
                    //this.createVouNoTable(name, amtOut, vounum, vouNoInqCount);
                    this.createVouNoTable(name, lptamt, vounum, vouNoInqCount);

                    #region   //----------- DTHREF outstanding amount update --------
                    double TOTPAYAMT = 0;
                    double AMTOUT = 0;
                    double newTOTPAYAMT = 0;
                    double newAMTOUT = 0;

                    string dhreftotamtSel = "select TOTPAYAMT, AMTOUT from lphs.dthref where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                    dthpayObj.readSql(dhreftotamtSel);
                    OracleDataReader totamtReader = dthpayObj.oraComm.ExecuteReader();
                    while (totamtReader.Read())
                    {
                        if (!totamtReader.IsDBNull(0)) { TOTPAYAMT = totamtReader.GetDouble(0); }
                        if (!totamtReader.IsDBNull(1)) { AMTOUT = totamtReader.GetDouble(1); }
                    }
                    totamtReader.Close();
                    //totamtReader.Dispose();

                    //newTOTPAYAMT = TOTPAYAMT + amtOut;
                    newTOTPAYAMT = TOTPAYAMT + lptamt;
                    //newAMTOUT = AMTOUT - amtOut;
                    //newAMTOUT = AMTOUT - amtOut - amount;
                    newAMTOUT = AMTOUT - lptamt - amount;

                    string totamtUPD = "update lphs.dthref set TOTPAYAMT = " + newTOTPAYAMT + ", AMTOUT =" + newAMTOUT + "  where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                    dthpayObj.insertRecords(totamtUPD);
                    #endregion

                }

                if (arrListADBPayee.Count > 0)
                {
                    double heireShare = 0;
                    string theHeire = "";
                    foreach (string[] adb in arrListADBPayee)
                    {
                        heireNo = int.Parse(adb[3]);
                        if (index == heireNo)
                        {
                            theHeire = adb[0];
                            name = adb[8];
                            addr1 = adb[4];
                            addr2 = adb[5];
                            addr3 = adb[6];
                            addr4 = adb[7];
                            heireShare = double.Parse(adb[9]);
                            amount = this.Sliamount(polno, "LHI", MOS, heireNo, "PP");
                            heireShare -= amount;
                            vounum = this.createVoucher(heireShare, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo);
                            string lhisel = "select * from LPHS.DTH_ADBPAYMENT_DISTN where POLICY_NO = " + polno + " and MOS ='" + MOS + "' and CLAIM_NO = " + clmno + " and PAYEENO =" + heireNo + " and VOUNO is null";
                            if (dthpayObj.existRecored(lhisel) == 0)
                            {
                                //dthpayObj.connclose();
                                throw new Exception("This voucher has already created!");
                            }

                            string LHUpd = "UPDATE LPHS.DTH_ADBPAYMENT_DISTN SET VOUST = 'Y' , VOUNO = '" + vounum + "', VOUENTDT=sysdate," +
                                " VOUENTEPF = '" + EPF + "', VOUENTIP = '" + ip + "' " +
                                " WHERE POLICY_NO = " + polno + " and MOS ='" + MOS + "' and CLAIM_NO = " + clmno + " and PAYEENO =" + heireNo + " ";
                            dthpayObj.insertRecords(LHUpd);
                            vouNoInqCount++;
                            this.createVouNoTable(name, heireShare, vounum, vouNoInqCount);

                            #region   //----------- DTHREF outstanding amount update --------
                            double TOTPAYAMT = 0;
                            double AMTOUT = 0;
                            double newTOTPAYAMT = 0;
                            double newAMTOUT = 0;

                            string dhreftotamtSel = "select TOTPAYAMT, AMTOUT from lphs.dthref where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.readSql(dhreftotamtSel);
                            OracleDataReader totamtReader = dthpayObj.oraComm.ExecuteReader();
                            while (totamtReader.Read())
                            {
                                if (!totamtReader.IsDBNull(0)) { TOTPAYAMT = totamtReader.GetDouble(0); }
                                if (!totamtReader.IsDBNull(1)) { AMTOUT = totamtReader.GetDouble(1); }
                            }
                            totamtReader.Close();
                            //totamtReader.Dispose();

                            newTOTPAYAMT = TOTPAYAMT + heireShare;
                            //newAMTOUT = AMTOUT - heireShare;
                            newAMTOUT = AMTOUT - heireShare - amount;

                            string totamtUPD = "update lphs.dthref set TOTPAYAMT = " + newTOTPAYAMT + ", AMTOUT =" + newAMTOUT + "  where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.insertRecords(totamtUPD);
                            #endregion
                        }
                    }
                }
            }
            // foreach end ***********

                            double TOTPAYAMT02 = 0;
                            double AMTOUT02 = 0;
                          
                            string dhreftotamtSel02 = "select TOTPAYAMT, AMTOUT from lphs.dthref where DRPOLNO =" + polno + " and DRMOS='" + MOS + "' ";
                            dthpayObj.readSql(dhreftotamtSel02);
                            OracleDataReader totamtReader02 = dthpayObj.oraComm.ExecuteReader();
                            while (totamtReader02.Read())
                            {
                                if (!totamtReader02.IsDBNull(0)) { TOTPAYAMT02 = totamtReader02.GetDouble(0); }
                                if (!totamtReader02.IsDBNull(1)) { AMTOUT02 = totamtReader02.GetDouble(1); }
                            }
                            totamtReader02.Close();
                            //totamtReader02.Dispose();

            if (((vouCountStatic + vouToBeCreatedCount) == recCount) && (AMTOUT02 <= 5))
            {
                //payment complete for total payment
                string dthrefUpd = "UPDATE LPHS.DTHREF SET COMPLETED = 'Y', PAYAUTDT = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '" + EPF + "'  WHERE DRPOLNO =" + polno + " and  DRMOS = '" + MOS + "' ";
                dthpayObj.insertRecords(dthrefUpd);
                string dreqUpd = "UPDATE LPHS.DREQ SET DRCMPLYN = 'Y' WHERE DRPOL =" + polno + " and  DRTYP = '" + MOS + "'";
                dthpayObj.insertRecords(dreqUpd);
                //this.btnOK.Enabled = false;
            }
            else { this.btnOK.Enabled = true; }
            this.lblsuccess.Text = "Vouchers Successfully Created";
            this.btnOK.Enabled = false;

            dthpayObj.commit();
            dthpayObj.connclose();
        }
        catch (Exception ex)
        {
            dthpayObj.rollback();
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

    }

    private void createVouDetTable(string name, string ad1, string ad2, string ad3, string ad4, double totamount, int rowno, string accctNo, string payee)
    {
        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();
        TableRow trow06 = new TableRow();
        TableRow trow07 = new TableRow();
        TableRow trow08 = new TableRow();
        TableRow trow09 = new TableRow();
        TableRow trow10 = new TableRow();
        TableRow trow11 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel21 = new TableCell();
        TableCell tcel22 = new TableCell();
        TableCell tcel31 = new TableCell();
        TableCell tcel32 = new TableCell();
        TableCell tcel41 = new TableCell();
        TableCell tcel42 = new TableCell();
        TableCell tcel51 = new TableCell();
        TableCell tcel52 = new TableCell();
        TableCell tcel61 = new TableCell();
        TableCell tcel62 = new TableCell();
        TableCell tcel71 = new TableCell();
        TableCell tcel72 = new TableCell();
        TableCell tcel81 = new TableCell();
        TableCell tcel82 = new TableCell();
        TableCell tcel91 = new TableCell();
        TableCell tcel92 = new TableCell();
        TableCell tcel101 = new TableCell();        
        TableCell tcel111 = new TableCell();
        TableCell tcel112 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl32 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl52 = new Label();
        Label lbl61 = new Label();
        Label lbl62 = new Label();
        Label lbl71 = new Label();
        Label lbl81 = new Label();
        TextBox txt01 = new TextBox();
        Label lbl91 = new Label();
        TextBox txt02 = new TextBox();
        Label lbl101 = new Label();
        TextBox txt03 = new TextBox();
        Label lbl111 = new Label();
        //TextBox txt04 = new TextBox();
        DropDownList ddl112 = new DropDownList();

        lbl11.ID = "totamontDesc" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "totamontDesc" + rowno); //Text Value
        lbl11.Text = "Voucher Amount : ";

        lbl12.ID = "totamont" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "totamont" + rowno); //Text Value
        lbl12.Text = String.Format("{0:N}", totamount);

        lbl21.ID = "fullnameDesc" + rowno;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "fullnameDesc" + rowno); //Text Value
        lbl21.Text = "Payee Name : ";

        lbl22.ID = "fullname" + rowno;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "fullname" + rowno); //Text Value
        lbl22.Text = name;

        lbl31.ID = "ad1Desc" + rowno;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "ad1Desc" + rowno); //Text Value
        lbl31.Text = "Address Part1 : ";

        lbl32.ID = "ad1" + rowno;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "ad1" + rowno); //Text Value
        lbl32.Text = ad1;

        lbl41.ID = "add2desc" + rowno;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "add2desc" + rowno); //Text Value
        lbl41.Text = "Address Part2 : ";

        lbl42.ID = "ad2" + rowno;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "ad2" + rowno); //Text Value
        lbl42.Text = ad2;

        lbl51.ID = "add3desc" + rowno;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "add3desc" + rowno); //Text Value
        lbl51.Text = "Address Part3 : ";

        lbl52.ID = "ad3" + rowno;
        lbl52.Attributes.Add("runat", "Server");
        lbl52.Attributes.Add("Name", "ad3" + rowno); //Text Value
        lbl52.Text = ad3;

        lbl61.ID = "add4desc" + rowno;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "add4desc" + rowno); //Text Value
        lbl61.Text = "Address Part4 : ";

        lbl62.ID = "ad4" + rowno;
        lbl62.Attributes.Add("runat", "Server");
        lbl62.Attributes.Add("Name", "ad4" + rowno); //Text Value
        lbl62.Text = ad4;

        lbl71.ID = "bkName" + rowno;
        lbl71.Attributes.Add("runat", "Server");
        lbl71.Attributes.Add("Name", "bkName" + rowno); //Text Value
        lbl71.Text = "Bank Name : ";

        lbl81.ID = "bkBrn" + rowno;
        lbl81.Attributes.Add("runat", "Server");
        lbl81.Attributes.Add("Name", "bkBrn" + rowno); //Text Value
        lbl81.Text = "Branch Name : ";

        lbl91.ID = "acctno" + rowno;
        lbl91.Attributes.Add("runat", "Server");
        lbl91.Attributes.Add("Name", "acctno" + rowno); //Text Value
        lbl91.Text = "Account Number : ";

        lbl101.ID = "payee" + rowno;
        lbl101.Attributes.Add("runat", "Server");
        lbl101.Attributes.Add("Name", "payee" + rowno); //Text Value
        lbl101.Text = "Payee : " + payee;

        lbl111.ID = "slicAcct" + rowno;
        lbl111.Attributes.Add("runat", "Server");
        lbl111.Attributes.Add("Name", "slicAcct" + rowno); //Text Value
        lbl111.Text = "SLI Account : ";

        //txt01.MaxLength = 28;
        txt01.ID = "bknametxt" + rowno;
        txt01.Attributes.Add("runat", "Server");
        txt01.Attributes.Add("Name", "bknametxt" + rowno);
        txt01.Style["width"] = "400px";

        //txt02.MaxLength = 20;
        txt02.ID = "bkBrntxt" + rowno;
        txt02.Attributes.Add("runat", "Server");
        txt02.Attributes.Add("Name", "bkBrntxt" + rowno);
        txt02.Style["width"] = "400px";

        //txt03.MaxLength = 20;
        txt03.ID = "acctNotxt" + rowno;
        txt03.Attributes.Add("runat", "Server");
        txt03.Attributes.Add("Name", "acctNotxt" + rowno);
        txt03.Style["width"] = "400px";
        if (long.Parse(accctNo) > 0) { txt03.Text = accctNo.ToString(); txt03.ReadOnly = true; }

        //txt04.MaxLength = 10;
        //txt04.ID = "txtSLIacctNo" + rowno;
        //txt04.Attributes.Add("runat", "Server");
        //txt04.Attributes.Add("Name", "txtSLIacctNotxt" + rowno);
        //txt04.Style["width"] = "400px";

        ddl112.ID = "slicAcctddl" + rowno;
        ddl112.Attributes.Add("runat", "Server");
        ddl112.Attributes.Add("Name", "slicAcctddl" + rowno); //Text Value
        ddl112.Items.Add(new ListItem("1030001487", "1030001487"));
        ddl112.Items.Add(new ListItem("1364403002", "1364403002"));
        ddl112.Items.Add(new ListItem("0001092995", "0001092995"));
        ddl112.Items.Add(new ListItem("000000000962", "000000000962"));
        ddl112.SelectedValue = "000000000962";

        tcel11.Controls.Add(lbl11);//Voucher amount
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);//Total Amount
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);//address1
        tcel32.Controls.Add(lbl32);
        tcel41.Controls.Add(lbl41);//address2
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);//address3
        tcel52.Controls.Add(lbl52);
        tcel61.Controls.Add(lbl61);//address4
        tcel62.Controls.Add(lbl62);
                
        tcel71.Controls.Add(lbl71);//Bank Name
        tcel72.Controls.Add(txt01);
        tcel81.Controls.Add(lbl81);//Bank Branch
        tcel82.Controls.Add(txt02);
        tcel91.Controls.Add(lbl91);//Account no
        tcel92.Controls.Add(txt03);

        tcel101.Controls.Add(lbl101);//Payee

        tcel111.Controls.Add(lbl111);//SLI AC no
        tcel112.Controls.Add(ddl112);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow02.Cells.Add(tcel21);
        trow02.Cells.Add(tcel22);
        trow03.Cells.Add(tcel31);
        trow03.Cells.Add(tcel32);
        trow04.Cells.Add(tcel41);
        trow04.Cells.Add(tcel42);
        trow05.Cells.Add(tcel51);
        trow05.Cells.Add(tcel52);
        trow06.Cells.Add(tcel61);
        trow06.Cells.Add(tcel62);

        trow07.Cells.Add(tcel71);
        trow07.Cells.Add(tcel72);
        trow08.Cells.Add(tcel81);
        trow08.Cells.Add(tcel82);

        trow09.Cells.Add(tcel91);
        trow09.Cells.Add(tcel92);

        trow10.Cells.Add(tcel101);

        trow11.Cells.Add(tcel111);
        trow11.Cells.Add(tcel112);
                
        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
        Table1.Rows.Add(trow06);
        Table1.Rows.Add(trow07);
        Table1.Rows.Add(trow08);
        Table1.Rows.Add(trow09);
        Table1.Rows.Add(trow10);
        Table1.Rows.Add(trow11);
    }

    private void createVouNoTable(string name, double totamount, string vounum, int rowno)
    {
        TableRow trow01 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel13 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl13 = new Label();

        lbl11.ID = "name" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "name" + rowno); //Text Value
        lbl11.Text = name;

        lbl12.ID = "totamontvno" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "totamontvno" + rowno); //Text Value
        lbl12.Text = String.Format("{0:N}", totamount);

        lbl13.ID = "vounum" + rowno;
        lbl13.Attributes.Add("runat", "Server");
        lbl13.Attributes.Add("Name", "vounum" + rowno); //Text Value
        lbl13.Text = vounum;

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel13.Controls.Add(lbl13);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow01.Cells.Add(tcel13);

        Table2.Rows.Add(trow01);
    }

    protected string createVoucher(double PAYVAL, string NAMEPAYEE1, string ADD1, string ADD2, string ADD3, string ADD4, string ACNUM, string BKNAM, string BKBRN, string SLIAcctNo)
    {
        //--------- generating voucher number --------------
        string vouno = "";
        int ACCODE;
        General gg = new General();

        try
        {
            //vouno = dthpayObj.voucher_number(DateTime.Now.Year.ToString(), branch.ToString().Trim());
            vouno = gg.voucher_number(DateTime.Now.Year.ToString(), branch.ToString(), "D", dthpayObj);
        }
        catch (Exception ex)
        {
            throw new Exception("Voucher Number Generating Failed! :" + ex.Message);
        }
        //if (!gg.IsAdbExgracia(polno, MOS, dthpayObj))
        //{
        //    ACCODE = 2118;          //one for deaths
        //}
        //else
        //{
        //    ACCODE = 2142;
        //}
        if (!isExgracia)
        {
            ACCODE = 2118;
        }
        else
        {
            ACCODE = 2142;
        }

        string USERID = EPF;
        int EXTDAT = int.Parse(setDate()[0]);
        string EXTTIM = DateTime.Now.ToString("HHmmss");
        //string ADD3 = "";

        BKNAM = BKNAM.Replace("'", " ");
        BKNAM = BKNAM.Trim();
        BKBRN = BKBRN.Replace('\'', ' ');
        BKBRN = BKBRN.Trim();

        ADD1 = this.adressRefine(ADD1);
        ADD2 = this.adressRefine(ADD2);
        ADD3 = this.adressRefine(ADD3);
        ADD4 = this.adressRefine(ADD4);

        ADD1 = ADD1.Trim();
        ADD2 = ADD2.Trim();
        ADD3 = ADD3.Trim();
        ADD4 = ADD4.Trim();

        //string hname = BKNAM + " " + BKBRN + " " + ACNUM;
        bdb = new BankDetailsBreak(BKNAM, BKBRN, ACNUM, NAMEPAYEE1);
        string hname = bdb.Hname1;
        string hname2 = bdb.Hname2;
        string totamountStr1 = PAYVAL.ToString();
        string totamountStr = "";
        string INSNAME = phname;

        for (int i = 0; i <= (21 - totamountStr1.Length); i++)
        {
            if (i == 1) { totamountStr = "*" + totamountStr1; }
            else { totamountStr = "*" + totamountStr; }
        }

        string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

        #region--------------------Branch no formating------------------
        string branchstr;
        if (branch.ToString().Length == 1) { branchstr = "00" + branch.ToString(); }
        else if (branch.ToString().Length == 2) { branchstr = "0" + branch.ToString(); }
        else { branchstr = branch.ToString(); }
        #endregion

        #region //------------ temp_cb -----------------------

        string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";
        if (dthpayObj.existRecored(tempCB_select) == 0)
        {
            string tempCB_insert = "insert into cashbook.temp_cb(Class, busycode, Divcode, Bcode, Claimno, POLNO, HName, HName1, Totamount,  " +
            " Totamt, ACCode, Acno, VouNo, VOUDATE, BillDate, ClaimType, Addepf, Voutyp, Status, Print1, Authorized, Deleted, Chqcan, Payaut, Insname, Add1, Add2, Add3, Add4, Posted, Reprint, RECIPIENT_NAME, TRANSACTION_TYPE, GROSS_AMOUNT) " +
            " VALUES ('L', '3', 'L', '" + branchstr + "', '" + clmno.ToString() + "', '" + polno.ToString() + "',  '" + hname + "', '" + hname2 + "', " + PAYVAL + ", " +
            " '" + String.Format("{0:N}", PAYVAL) + "', '" + ACCODE.ToString() + "', '" + SLIAcctNo + "','" + vouno + "', sysdate, sysdate, 'A', '" + EPF + "', 'Death','Pending', 0, 0, 0, 0, 0, '" + INSNAME + "', " +
            " '" + ADD1 + "', '" + ADD2 + "', '" + ADD3 + "', '" + ADD4 + "', 0, 0, '" + NAMEPAYEE1.Trim() + "', 'V', " + PAYVAL + "  )";
            dthpayObj.insertRecords(tempCB_insert);
        }
        else { throw new Exception("Voucher Already Created!"); }

        #endregion

        #region //-------------- TEMP_DETL -------------------

        string temp_detl_select = "select * from  CASHBOOK.TEMP_DETL where vouno = '" + vouno + "' ";
        if (dthpayObj.existRecored(temp_detl_select) == 0)
        {
            string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                "VALUES ('" + vouno + "' ,'" + ACCODE.ToString() + "' ,  " + PAYVAL + " ,0 ,0 ,  " + PAYVAL + " )";
            dthpayObj.insertRecords(temp_detl_insert);
        }
        else { throw new Exception("Already Existing Record in temp_detl Table"); }

        #endregion

        #region //------------------ VOUBANKDET --------------

        string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
        if (dthpayObj.existRecored(voubankdetSelect) == 0)
        {
            string voubankdetnsert = "INSERT INTO LPHS.VOUBANKDET (POLICYNO ,VOUCHERNO ,PAYEENAME ,BNKNAME ,BNKBRNNAME ,SLIACCTNO, CUSTACCTNO ) " +
                " VALUES (" + polno + " ,'" + vouno + "' ,'" + NAMEPAYEE1 + "' ,'" + BKNAM + "' ,'" + BKBRN + "' ,'" + SLIAcctNo + "', '" + ACNUM + "'  )";
            dthpayObj.insertRecords(voubankdetnsert);
        }
        else { throw new Exception("Already Exising Voucher Bank Details"); }

        #endregion

        return vouno;
    }

    private string adressRefine(string s)
    {
        string returnStr = "";
        string spChar = "";
        if ((s != null) && (!s.Equals("")))
        {
            for (int i = 0; i < s.Length; i++)
            {
                spChar = s.Substring(i, 1);
                if ((!spChar.Equals("'")) && (!spChar.Equals("\"")) && (!spChar.Equals("+")) && (!spChar.Equals("-")) && (!spChar.Equals(";")) && (!spChar.Equals(",")))
                {
                    returnStr += spChar;
                }
                else
                {
                    returnStr += " ";
                }
            }
        }
        return returnStr;
    }

    private double Sliamount(long polino, string svpayee, string svmos, int payeenum, string sysType)
    {
        double sliamt = 0;
        string balancesel = "select sum(SVAMT) from LPHS.SLICVOUCHERS where SVPOL=" + polino + " and SVPAYEE='" + payee + "' and SVMOS='" + svmos + "' and SVPAYNUM=" + payeenum + " and SYSTEM_TYPE = '" + sysType + "'";
        if (dthpayObj.existRecored(balancesel) != 0)
        {
            dthpayObj.readSql(balancesel);
            OracleDataReader balancereader = dthpayObj.oraComm.ExecuteReader();
            while (balancereader.Read())
            {
                if (!balancereader.IsDBNull(0)) { sliamt = balancereader.GetDouble(0); } else { sliamt = 0; }
            }
        }
        return sliamt;
    }

}
