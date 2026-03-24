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

public partial class trminList002 : System.Web.UI.Page
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
    private long polno;
    private string MOS;
    private string disType;
    private string disable;
    private string intimno;
    private string PAYEENAME, AD1, AD2, AD3, AD4;
    private int paymntDue;
    private double PAYAMT;
    private double TotAmt;
    private string epf;
    private int brn;
    private int maxDue;
    private int PAYMODE;
    private int claimNo;
    private string phname;
    private string EXGRYN;
    private string bnkname;
    private string brname;
    private string acctno, vouno;
    private double polcomyrbal;
    private ArrayList dueList;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                EXGRYN = "";
                brn = 10;  // hard coded brn code 
                epf = "MS0562"; // hard coded brn code 
                dm = new DataManager();
                dueList = new ArrayList();

                this.ddlslicacctno.Items.Add(new ListItem("1030001487", "1030001487"));
                this.ddlslicacctno.Items.Add(new ListItem("1364403002", "1364403002"));

                //initPay002 initPay002obj = new initPay002();
                //polno = initPay002obj.Polno;
                //MOS = initPay002obj.mos;
                //disType = initPay002obj.DisType;
                //intimno = initPay002obj.Intimno;
                //---- 20080201 -----
                if (Request.QueryString["polNo"] != null)
                {
                    ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polNo"]));
                    polno = int.Parse(Request.QueryString["polNo"]);
                }
                if (Request.QueryString["mos"] != null)
                {
                    ViewState.Add("mosQstr", Request.QueryString["mos"].ToString());
                    MOS = Request.QueryString["mos"].ToString();
                }
                if (Request.QueryString["disType"] != null)
                {
                    ViewState.Add("disTypeQstr", Request.QueryString["disType"].ToString());
                    disType = Request.QueryString["disType"].ToString();
                }
                if (Request.QueryString["intimno"] != null)
                {
                    ViewState.Add("intimnoQstr", Request.QueryString["intimno"].ToString());
                    intimno = Request.QueryString["intimno"].ToString();
                }

                DissabilityTypesRead disabletype = new DissabilityTypesRead();
                disable = disabletype.GetDisabilityTypes(int.Parse(disType));
                this.lblpolno.Text = polno.ToString();
                this.lbldisType.Text = disable;
                this.lblintimNo.Text = intimno;
                if (MOS.Equals("M")) { this.lblmof.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lblmof.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lblmof.Text = "Second Life"; }

                #region // ************** PHNAME  **********************

                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                if (dm.existRecored(sql) != 0)
                {
                    dm.readSql(sql);
                    OracleDataReader oraDtReader = dm.oraComm.ExecuteReader();
                    while (oraDtReader.Read())
                    {
                        if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                        {
                            phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                        }
                        else { phname = ""; }
                    }
                    oraDtReader.Close();
                }

                #endregion

                string disaMasSelect = "select PAYAMT, PAYMODE, PAYEENAME, AD1, AD2, AD3, AD4, GROSSCLM, NETCLM, EXGRYN, BNKNAME, BNKBRN, ACCTNO, PAYMENT_BAL, POLCOMYR_AMT_BAL, CLAIM_NO from LCLM.DISABLE_MAS where " +
                    " policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' and MGR_DECISION = 'Y' and clmstate = 'TERMINATED'";
                if (dm.existRecored(disaMasSelect) != 0)
                {
                    dm.readSql(disaMasSelect);
                    OracleDataReader disaMasReader = dm.oraComm.ExecuteReader();
                    while (disaMasReader.Read())
                    {
                        //if (!disaMasReader.IsDBNull(0)) { PAYAMT = disaMasReader.GetDouble(0); } else { PAYAMT = 0; }
                        //PAYAMT = PAYAMT / 120;
                        //if (!disaMasReader.IsDBNull(1)) { PAYMODE = disaMasReader.GetInt32(1); } else { PAYMODE = 0; }
                        if (!disaMasReader.IsDBNull(2)) { PAYEENAME = disaMasReader.GetString(2); } else { PAYEENAME = ""; }
                        if (!disaMasReader.IsDBNull(3)) { AD1 = disaMasReader.GetString(3); } else { AD1 = ""; }
                        if (!disaMasReader.IsDBNull(4)) { AD2 = disaMasReader.GetString(4); } else { AD2 = ""; }
                        if (!disaMasReader.IsDBNull(5)) { AD3 = disaMasReader.GetString(5); } else { AD3 = ""; }
                        if (!disaMasReader.IsDBNull(6)) { AD4 = disaMasReader.GetString(6); } else { AD4 = ""; }
                        if (!disaMasReader.IsDBNull(9)) { EXGRYN = disaMasReader.GetString(9); } else { EXGRYN = ""; }
                        if (!disaMasReader.IsDBNull(10)) { bnkname = disaMasReader.GetString(10); } else { bnkname = ""; }
                        if (!disaMasReader.IsDBNull(11)) { brname = disaMasReader.GetString(11); } else { brname = ""; }
                        if (!disaMasReader.IsDBNull(12)) { acctno = disaMasReader.GetString(12); } else { acctno = ""; }
                        if (!disaMasReader.IsDBNull(13)) { PAYAMT = disaMasReader.GetDouble(13); } else { PAYAMT = 0; }
                        if (!disaMasReader.IsDBNull(14)) { polcomyrbal = disaMasReader.GetDouble(14); } else { polcomyrbal = 0; }
                        if (!disaMasReader.IsDBNull(15)) { claimNo = disaMasReader.GetInt32(15); } else { claimNo = 0; }
                    }
                    disaMasReader.Close();

                    this.txtpayeename.Text = PAYEENAME;
                    this.txtad1.Text = AD1;
                    this.txtad2.Text = AD2;
                    this.txtad3.Text = AD3;
                    this.txtad4.Text = AD4;
                    this.txtbkname.Text = bnkname;
                    this.txtbkbrnname.Text = brname;
                    this.txtcustAcct.Text = acctno;
                }
                else { throw new Exception("No payments available!"); }
                //string disabilityterminatesel = "select OUTSTANDING_AMT from LCLM.DISABILITY_TERMINATE where POLNO=" + polno + " and MOS='" + MOS + "' and DISTYPE=" + disType + " and INTIMNO='" + intimno + "'";
                //if (dm.existRecored(disabilityterminatesel) != 0)
                //{
                //    dm.readSql(disabilityterminatesel);
                //    OracleDataReader disterreader = dm.oraComm.ExecuteReader();
                //    while (disterreader.Read())
                //    {
                //        if (!disterreader.IsDBNull(0)) { PAYAMT = disterreader.GetDouble(0); } else { PAYAMT = 0; }
                //        TotAmt += PAYAMT;
                //    }
                //    disterreader.Close();
                //}
                if (polcomyrbal < PAYAMT) { PAYAMT -= polcomyrbal; polcomyrbal = 0; }
                else { polcomyrbal -= PAYAMT; PAYAMT = 0; }

                #region------------------------DisableMasUpdate-----------------------
                string disablemasupd = "update LCLM.DISABLE_MAS set POLCOMYR_AMT_BAL=" + polcomyrbal + ", PAYMENT_BAL=" + PAYAMT + " where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
                dm.insertRecords(disablemasupd);
                #endregion

            }
            catch (Exception Ex)
            {
                //dm.rollback();
                dm.connclose();
                EPage.Messege = Ex.Message;
                Response.Redirect("EPage.aspx");
            }

            #region-----------------------------------viewstate-----------------------
            ViewState["TotAmt"] = TotAmt;
            ViewState["PAYAMT"] = PAYAMT;
            ViewState["epf"] = epf;
            ViewState["brn"] = brn;
            ViewState["phname"] = phname;
            ViewState["EXGRYN"] = EXGRYN;
            ViewState["vouno"] = "";
            ViewState["claimNo"] = claimNo;
            ViewState["intimno"] = intimno;
            #endregion
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polno = long.Parse(ViewState["polnoQstr"].ToString()); }
            if (ViewState["mosQstr"] != null) { MOS = (ViewState["mosQstr"].ToString()); }
            if (ViewState["disTypeQstr"] != null) { disType = (ViewState["disTypeQstr"].ToString()); }
            if (ViewState["intimnoQstr"] != null) { intimno = (ViewState["intimnoQstr"].ToString()); }
            if (ViewState["TotAmt"] != null) { TotAmt = double.Parse(ViewState["TotAmt"].ToString()); }
            if (ViewState["PAYAMT"] != null) { PAYAMT = double.Parse(ViewState["PAYAMT"].ToString()); }
            if (ViewState["epf"] != null) { epf = (ViewState["epf"].ToString()); }
            if (ViewState["brn"] != null) { brn = int.Parse(ViewState["brn"].ToString()); }
            if (ViewState["maxDue"] != null) { maxDue = int.Parse(ViewState["maxDue"].ToString()); }
            if (ViewState["PAYMODE"] != null) { PAYMODE = int.Parse(ViewState["PAYMODE"].ToString()); }
            if (ViewState["claimNo"] != null) { claimNo = int.Parse(ViewState["claimNo"].ToString()); }
            if (ViewState["phname"] != null) { phname = (ViewState["phname"].ToString()); }
            if (ViewState["EXGRYN"] != null) { EXGRYN = (ViewState["EXGRYN"].ToString()); }
            if (ViewState["dueList"] != null) { dueList = (ArrayList)(ViewState["dueList"]); }
            if (ViewState["vouno"] != null) { vouno = ViewState["vouno"].ToString(); }            
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("vouPrint003.aspx?polno=" + polno + "&mos=" + MOS + "&vouno=" + vouno + "&amount=" + PAYAMT + "&clmno=" + claimNo + "&exgrshare=0&intimno=" + intimno + "");

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            dm.begintransaction();
            string disaterminsel = "select * from LCLM.DISABILITY_TERMINATE where POLNO=" + polno + " and INTIMNO='" + intimno + "' and VOUCHERNO is null";
            if (dm.existRecored(disaterminsel) == 0)
            {
                throw new Exception("Voucher Already Created!");
            }
            vouno = "";
            string remarks = this.txtrema.Text;
            PAYEENAME = this.txtpayeename.Text;
            AD1 = this.txtad1.Text;
            AD2 = this.txtad2.Text;
            AD3 = this.txtad3.Text;
            AD4 = this.txtad4.Text;
            string clmstate = "";

            #region ------- voucher details -------
            int ACCODE = 0;
            if (EXGRYN.Equals("Y")) { ACCODE = 2142; } else { ACCODE = 2123; }
            string NAMEPAYEE1 = this.txtpayeename.Text.ToString();
            string BKNAM = this.txtbkname.Text;
            BKNAM = BKNAM.Replace("'", " ");
            BKNAM = BKNAM.Trim();
            string BKBRN = this.txtbkbrnname.Text;
            BKBRN = BKBRN.Replace('\'', ' ');
            BKBRN = BKBRN.Trim();
            string ADD1 = this.txtad1.Text.ToString();
            string ADD2 = this.txtad2.Text.ToString();
            string ADD3 = "";
            if (this.txtad3.Text.ToString().Length + this.txtad4.Text.ToString().Length <= 50)
            {
                ADD3 = this.txtad3.Text.ToString() + " " + this.txtad4.Text.ToString();
            }
            else { ADD3 = this.txtad3.Text.ToString(); }

            ADD1 = this.adressRefine(ADD1);
            ADD2 = this.adressRefine(ADD2);
            ADD3 = this.adressRefine(ADD3);
            ADD1 = ADD1.Trim();
            ADD2 = ADD2.Trim();
            ADD3 = ADD3.Trim();

            //string ACNUM = this.txtaccnum.Text.ToString();
            string ACNUM = this.ddlslicacctno.SelectedItem.Value.ToString();
            string custAcct = this.txtcustAcct.Text.ToString();
            string hname = BKNAM + " " + BKBRN + " " + custAcct;
            string totamountStr1 = TotAmt.ToString();
            //string totamountStr = "";
            string INSNAME = phname;
            
            string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

            #endregion

            

            #region ------- vouno -------

            try { vouno = dm.voucher_number(DateTime.Now.Year.ToString(), brn.ToString().Trim()); }
            catch { throw new Exception("Voucher Number Generating Failed!"); }
            ViewState["vouno"] = vouno;
            int incrementer = 0;

            #endregion

            #region ------- temp_cb -------

            string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";
            if (dm.existRecored(tempCB_select) == 0)
            {
                //----------- temp_cb code -------------
                string tempCB_insert = "insert into cashbook.temp_cb(Class, busycode, Divcode, Bcode, Claimno, POLNO, HName, HName1, Totamount,  " +
                " Totamt, ACCode, Acno, VouNo, VOUDATE, BillDate, ClaimType, Addepf, Voutyp, Status, Print1, Authorized, Deleted, Chqcan, Payaut, Insname, Add1, Add2, Add3, Posted, Reprint, RECIPIENT_NAME, TRANSACTION_TYPE, GROSS_AMOUNT) " +
                " VALUES ('L', '3', 'L', '" + brn.ToString() + "', '" + claimNo.ToString() + "', '" + polno.ToString() + "',  '" + hname + "', '" + NAMEPAYEE1 + "', " + PAYAMT + ", " +
                " '" + totamountStr1 + "', '" + ACCODE.ToString() + "', '" + ACNUM + "','" + vouno + "', sysdate, sysdate, 'C', '" + epf + "', 'DAT','Pending', 0, 0, 0, 0, 0, '" + INSNAME + "', " +
                " '" + ADD1 + "', '" + ADD2 + "', '" + ADD3 + "', 0, 0, '" + NAMEPAYEE1 + "', 'C', " + TotAmt + "  )";
                dm.insertRecords(tempCB_insert);
            }
            else { throw new Exception("Voucher Already Created!"); }

            #endregion

            #region ------- cashbook_temp_detl -------

            string temp_detl_select = "select * from  CASHBOOK.TEMP_DETL where vouno = '" + vouno + "' ";
            if (dm.existRecored(temp_detl_select) == 0)
            {
                string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                    "VALUES ('" + vouno + "' ,'" + ACCODE.ToString() + "' ,  " + PAYAMT + " ,0 ,0 ,  " + TotAmt + " )";
                dm.insertRecords(temp_detl_insert);
            }
            else { throw new Exception("Already Existing Record in temp_detl Table"); }

            #endregion

            #region ------- LPHS.VOUBANKDET  ---------

            string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
            if (dm.existRecored(voubankdetSelect) == 0)
            {
                string voubankdetnsert = "INSERT INTO LPHS.VOUBANKDET (POLICYNO ,VOUCHERNO ,PAYEENAME ,BNKNAME ,BNKBRNNAME ,SLIACCTNO, CUSTACCTNO ) " +
                    " VALUES (" + polno + " ,'" + vouno + "' ,'" + NAMEPAYEE1 + "' ,'" + BKNAM + "' ,'" + BKBRN + "' ,'" + ACNUM + "', '" + custAcct + "'  )";
                dm.insertRecords(voubankdetnsert);
            }
            else { throw new Exception("Already Exising Voucher Bank Details"); }

            #endregion

            #region------LCLM.DISABILITY_TERMINATE-------
            string updatedisterminate = "update LCLM.DISABILITY_TERMINATE set PAID_AMT=" + PAYAMT + ", VOUCHERNO='" + vouno + "', PAIDDATE=" + this.setDate()[0] + ", PAIDEPF='" + epf + "' where POLNO=" + polno + " and MOS='" + MOS + "' and DISTYPE='" + disType + "' and INTIMNO='" + intimno + "'";
            dm.insertRecords(updatedisterminate);
            #endregion

            this.createVouNoTable(PAYEENAME, PAYAMT, vouno);
            this.lblsuccess.Text = "Vouchers Created Successfully";
            //}          

            this.btnOK.Enabled = false;
            this.btnnext.Enabled = true;
            dm.commit();
            dm.connclose();
        }
        catch(Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    private void createVouNoTable(string name, double totamount, string vounum)// int rowno)
    {
        TableRow trow01 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel13 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl13 = new Label();

        lbl11.ID = "name"; //+ rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "name");//+ rowno); //Text Value
        lbl11.Text = name;

        lbl12.ID = "totamontvno";// +rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "totamontvno");// + rowno); //Text Value
        lbl12.Text = String.Format("{0:N}", totamount);

        lbl13.ID = "vounum";// +rowno;
        lbl13.Attributes.Add("runat", "Server");
        lbl13.Attributes.Add("Name", "vounum");// + rowno); //Text Value
        lbl13.Text = vounum;

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel13.Controls.Add(lbl13);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow01.Cells.Add(tcel13);

        Table2.Rows.Add(trow01);
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
}
