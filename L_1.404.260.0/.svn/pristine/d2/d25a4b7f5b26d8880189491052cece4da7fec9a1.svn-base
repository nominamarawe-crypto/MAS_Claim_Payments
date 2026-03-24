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

public partial class childProtPay002 : System.Web.UI.Page
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
    DataManager dm;
    private int polno;
    private int tbl;
    private int clmno;
    private int nextDue;
    private int paymntcnt;
    private string payee;
    private double payamt;
    private string phname;
    private string NOMNAME;
    private string NOMAD1;
    private string NOMAD2;
    private string EPF;
    private string vouno;
    private int branch;

    protected void Page_Load(object sender, EventArgs e)
    {
        //branch = 10;
        //branch = Convert.ToInt32(Session["brcode"]);
        if (Session["brcode"] != null && Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            branch = Convert.ToInt32(Session["brcode"]);
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                if (Request.QueryString["polino"] != null)
                {
                    polno = int.Parse(Request.QueryString["polino"].ToString());
                    ViewState.Add("polnoQstr", polno.ToString());
                }
                if (Request.QueryString["table"] != null)
                {
                    tbl = int.Parse(Request.QueryString["table"].ToString());
                    ViewState.Add("tblQstr", tbl.ToString());
                }

                this.lblpolno.Text = polno.ToString();

                #region // ************** PHNAME  **********************

                DataManager lsurefobj = new DataManager();

                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                lsurefobj.readSql(sql);
                OracleDataReader oraDtReader = lsurefobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                bool flag = false;

                while (oraDtReader.Read())
                {
                    if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                    {
                        flag = true;
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                    }
                    else { phname = ""; }

                }
                oraDtReader.Close();
                oraDtReader.Dispose();

                this.lblphname.Text = phname;
            
                #endregion

                string heireAd = "";
                string dthrefsel = "select payee, drclmno from lphs.dthref where drpolno = " + polno + "";
                if (dm.existRecored(dthrefsel) != 0)
                {
                    dm.readSql(dthrefsel);
                    OracleDataReader dthrefreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefreader.Read())
                    {
                        if (!dthrefreader.IsDBNull(0)) { payee = dthrefreader.GetString(0); } else { payee = ""; }
                        if (!dthrefreader.IsDBNull(1)) { clmno = dthrefreader.GetInt32(1); } else { clmno = 0; }
                    }
                    dthrefreader.Close();
                    dthrefreader.Dispose();
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Death Reference Record");
                }

                string child_masSel = "select pay_amt, nextdue, PAYMENT_COUNT from lclm.child_prot_mas where polno = " + polno + " and ptable = " + tbl + "";
                if (dm.existRecored(child_masSel) != 0)
                {
                    dm.readSql(child_masSel);
                    OracleDataReader child_masReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (child_masReader.Read())
                    {
                        if (!child_masReader.IsDBNull(0)) { payamt = child_masReader.GetDouble(0); } else { payamt = 0; }
                        if (!child_masReader.IsDBNull(1)) { nextDue = child_masReader.GetInt32(1); } else { nextDue = 0; }
                        if (!child_masReader.IsDBNull(2)) { paymntcnt = child_masReader.GetInt32(2); } else { paymntcnt = 0; }
                    }
                    child_masReader.Close();
                    child_masReader.Dispose();
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Child Protection Master Details");
                }
                int yymm = int.Parse(setDate()[0].ToString().Substring(0, 6));
                if (nextDue > yymm) { throw new Exception("No Existing Dues for This Policy!"); }
                this.txtnetClmAmt.Text = payamt.ToString();

                #region ----- payee -----
                if (payee.Equals("NOM"))
                {
                    string nomSelect = "select NOMNAM, NOMAD1, NOMAD2 from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";

                    if (dm.existRecored(nomSelect) != 0)
                    {
                        dm.readSql(nomSelect);
                        OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (nomineeReader.Read())
                        {
                            if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); } else { NOMNAME = ""; }
                            if (!nomineeReader.IsDBNull(1)) { NOMAD1 = nomineeReader.GetString(1); } else { NOMAD1 = ""; }
                            if (!nomineeReader.IsDBNull(2)) { NOMAD2 = nomineeReader.GetString(2); } else { NOMAD2 = ""; }

                        }
                        nomineeReader.Close();
                        nomineeReader.Dispose();
                    }
                }
                else if (payee.Equals("LHI"))
                {
                    string heireSelect = "select lhname, lhad1 from lphs.legal_hires where lhpolno=" + polno + " ";
                    if (dm.existRecored(heireSelect) != 0)
                    {
                        dm.readSql(heireSelect);
                        OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (heireSelectReader.Read())
                        {
                            if (!heireSelectReader.IsDBNull(3)) { NOMNAME = heireSelectReader.GetString(3); } else { NOMNAME = ""; }
                            if (!heireSelectReader.IsDBNull(4)) { heireAd = heireSelectReader.GetString(4); } else { heireAd = ""; }
                        }
                        heireSelectReader.Close();
                        heireSelectReader.Dispose();

                        if (heireAd.Length > 50) { NOMAD1 = heireAd.Substring(0, 50); NOMAD2 = heireAd.Substring(50, heireAd.Length - 50); }
                        else { NOMAD1 = heireAd; }
                    }
                }
                else if (payee.Equals("ASI"))
                {
                    string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, PAYSTATUS, VOUSTA from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
                    if (dm.existRecored(asiSelect) != 0)
                    {
                        dm.readSql(asiSelect);
                        OracleDataReader prassReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (prassReader.Read())
                        {
                            if (!prassReader.IsDBNull(3)) { NOMNAME = prassReader.GetString(3); }
                            if (!prassReader.IsDBNull(5)) { NOMAD1 = prassReader.GetString(5); }
                            if (!prassReader.IsDBNull(6)) { NOMAD2 = prassReader.GetString(6); }
                        }
                        prassReader.Close();
                        prassReader.Dispose();
                    }
                }
                else if (payee.Equals("LPT"))
                {
                    string living_prtSelect = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, PAYSTATUS, VOUSTA from LUND.LIVING_PRT where polno = " + polno + "  ";
                    if (dm.existRecored(living_prtSelect) != 0)
                    {
                        dm.readSql(living_prtSelect);
                        OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (nomineeReader.Read())
                        {
                            if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); } else { NOMNAME = ""; }
                            if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); } else { NOMAD1 = ""; }
                            if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); } else { NOMAD2 = ""; }                                     
                        }
                        nomineeReader.Close();
                        nomineeReader.Dispose();
                    }
                }
                #endregion

                this.txtpayeename.Text = NOMNAME;
                this.txtad1.Text = NOMAD1;
                this.txtad2.Text = NOMAD2;

                ViewState["nextDue"] = nextDue;
                ViewState["paymntcnt"] = paymntcnt;
                ViewState["clmno"] = clmno;
                dm.connClose();
            }
            catch (Exception ex)
            {
                dm.connClose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polno = int.Parse(ViewState["polnoQstr"].ToString()); }
            if (ViewState["tblQstr"] != null) { tbl = int.Parse(ViewState["tblQstr"].ToString()); }
            if (ViewState["nextDue"] != null) { nextDue = int.Parse(ViewState["nextDue"].ToString()); }
            if (ViewState["paymntcnt"] != null) { paymntcnt = int.Parse(ViewState["paymntcnt"].ToString()); }
            if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
            if (ViewState["payamt"] != null) { payamt = double.Parse(ViewState["payamt"].ToString()); }
            if (ViewState["vouno"] != null) { vouno = ViewState["vouno"].ToString(); } 
                  
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            dm.begintransaction();

            payamt = double.Parse(this.txtnetClmAmt.Text.Trim());
            NOMNAME = this.txtpayeename.Text.Trim();
            NOMAD1 = this.txtad1.Text.Trim();
            NOMAD2 = this.txtad2.Text.Trim();

            string ACNUM = this.txtcustAcct.Text.Trim();
            string BKNAM = this.txtbkname.Text.Trim();
            string BKBRN = this.txtbkbrnname.Text.Trim();
            string SLIAcctNo = this.ddlslicacctno.SelectedItem.Value.ToString();
            
            //---- creating voucher ---------------
            vouno = this.createVoucher(payamt, NOMNAME, NOMAD1, NOMAD2, ACNUM, BKNAM, BKBRN, SLIAcctNo, dm);

            //---- updating child_prot_mas --------
            paymntcnt++;
            int lastDue = nextDue;
            int yymm =  int.Parse (setDate()[0].ToString().Substring(0,6));
            //if (lastDue > yymm) { throw new Exception("No more dues for this policy!"); }            
            nextDue = int.Parse((int.Parse(nextDue.ToString().Substring(0, 4)) + 1).ToString() + nextDue.ToString().Substring(4, 2));
            string childprotmasUpd = "update lclm.child_prot_mas set LASTDUE = " + lastDue + ", NEXTDUE = " + nextDue + ", PAYMENT_COUNT = " + paymntcnt + " where polno = " + polno + " and ptable = " + tbl + "";
            dm.insertRecords(childprotmasUpd);

            //---- inserting into child_prot_pay --
            string protPaySel = "select polno from lclm.CHILD_PROT_PAY where polno = " + polno + " and PAYMENT_DUE = " + lastDue + " and ptable = " + tbl + " ";
            if (dm.existRecored(protPaySel) == 0)
            {
                int date = int.Parse(setDate()[0]);
                string childprotpayInsert = "INSERT INTO LCLM.CHILD_PROT_PAY (POLNO ,PAYMENT_DUE ,LAST_DUE ,NEXT_DUE ,VONO ,PAID_AMT ,PAYDATE ,PAYEPF ,PAYIP ,PTABLE, claimno ) " +
                    " VALUES (" + polno + " ," + lastDue + " ," + lastDue + " ," + nextDue + " ,'" + vouno + "' ," + payamt + " , " + date + " ,'" + EPF + "' ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "' , " + tbl + ", " + clmno + "  )";
                dm.insertRecords(childprotpayInsert);
            }

            //---insert to periodic Paydet---------
            string periodicpaysel = "select * from LCLM.PERIODIC_PAYDET where POLNO=" + polno + "and CLMTYPE='DTC' and PAYMENT_DUE=" + lastDue + "";
            if (dm.existRecored(periodicpaysel) != 0)
            {
                string periodicpayupd = "update LCLM.PERIODIC_PAYDET set VONO='" + vouno + "' where POLNO=" + polno + " and CLMTYPE='DTC' and PAYMENT_DUE=" + lastDue + "";
                dm.insertRecords(periodicpayupd);
            }
            this.lblsuccess.Visible = true;
            this.lblvouno.Text = "Voucher No. -: " + vouno;
            this.Button1.Enabled = false;
            dm.commit();
            dm.connClose();

            ViewState["payamt"] = payamt;
            ViewState["vouno"] = vouno;
        }
        catch (Exception ex)
        {
            dm.connClose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {

    }

    protected string createVoucher(double PAYVAL, string NAMEPAYEE1, string ADD1, string ADD2, string ACNUM, string BKNAM, string BKBRN, string SLIAcctNo, DataManager dmob)
    {
        //--------- generating voucher number --------------
        string vouno = "";

        try
        {
            vouno = dmob.voucher_numberCP(DateTime.Now.Year.ToString(), branch.ToString().Trim());
        }
        catch (Exception ex)
        {
            throw new Exception("Voucher Number Generating Failed! :" + ex.Message);
        }

        int ACCODE = 2118;          //one for deaths
        //int STATUS = 0;             //not deleted
        //string USERID = EPF;
        //EPF = Session["EPFNum"].ToString();
        int EXTDAT = int.Parse(setDate()[0]);
        string EXTTIM = DateTime.Now.ToString("HHmmss");
        string ADD3 = "";

        if ((BKNAM != null) && (!BKNAM.Equals("")))
        {
            BKNAM = BKNAM.Replace("'", " ");
            BKNAM = BKNAM.Trim();
        }
        if ((BKBRN != null) && (!BKBRN.Equals("")))
        {
            BKBRN = BKBRN.Replace('\'', ' ');
            BKBRN = BKBRN.Trim();
        }

        ADD1 = this.adressRefine(ADD1);
        ADD2 = this.adressRefine(ADD2);

        ADD1 = ADD1.Trim();
        ADD2 = ADD2.Trim();

        string hname = BKNAM + " " + BKBRN + " " + ACNUM;
        string totamountStr1 = PAYVAL.ToString();
        string totamountStr = "";
        string INSNAME = phname;

        //string sqllife_voudetl = "insert into cashbook.life_voudetl(VOUNO,POLNO,CLAIMNO,PAYVAL,ACCODE,NAMEPAYEE1,ADD1,ADD2,ADD3,ACNUM,STATUS," +
        //      "USERID,EXTDAT,EXTTIM,BKNAM,BKBRN,INSNAME) values ('" + vouno + "','" + polno + "','" + clmno + "'," + PAYVAL +
        //         "," + ACCODE + ",'" + NAMEPAYEE1 + "','" + ADD1 + "','" + ADD2 + "','" + ADD3 + "','" + ACNUM + "'," + STATUS + ",'" + USERID +
        //         "','" + EXTDAT + "','" + EXTTIM + "','" + BKNAM + "','" + BKBRN + "','" + phname + "' )";

        //dmob.insertRecords(sqllife_voudetl);

        for (int i = 0; i <= (21 - totamountStr1.Length); i++)
        {
            if (i == 1) { totamountStr = "*" + totamountStr1; }
            else { totamountStr = "*" + totamountStr; }
        }

        string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

        #region //------------ temp_cb -----------------------

        string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";
        if (dmob.existRecored(tempCB_select) == 0)
        {
            string tempCB_insert = "insert into cashbook.temp_cb(Class, busycode, Divcode, Bcode, Claimno, POLNO, HName, HName1, Totamount,  " +
            " Totamt, ACCode, Acno, VouNo, VOUDATE, BillDate, ClaimType, Addepf, Voutyp, Status, Print1, Authorized, Deleted, Chqcan, Payaut, Insname, Add1, Add2, Add3, Posted, Reprint, RECIPIENT_NAME, TRANSACTION_TYPE, GROSS_AMOUNT) " +
            " VALUES ('L', '3', 'L', '" + branch.ToString() + "', '" + clmno.ToString() + "', '" + polno.ToString() + "',  '" + hname + "', '" + NAMEPAYEE1 + "', " + PAYVAL + ", " +
            " '" + totamountStr1 + "', '" + ACCODE.ToString() + "', '" + ACNUM + "','" + vouno + "', sysdate, sysdate, 'A', '" + EPF + "', 'Death','Pending', 0, 0, 0, 0, 0, '" + INSNAME + "', " +
            " '" + ADD1 + "', '" + ADD2 + "', '" + ADD3 + "', 0, 0, '" + NAMEPAYEE1 + "', 'C', " + PAYVAL + "  )";
            dmob.insertRecords(tempCB_insert);
        }
        else
        {
            dm.connclose();
            throw new Exception("Voucher Already Created!");
        }

        #endregion

        #region //-------------- TEMP_DETL -------------------

        string temp_detl_select = "select * from  CASHBOOK.TEMP_DETL where vouno = '" + vouno + "' ";
        if (dmob.existRecored(temp_detl_select) == 0)
        {
            string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                "VALUES ('" + vouno + "' ,'" + ACCODE.ToString() + "' ,  " + PAYVAL + " ,0 ,0 ,  " + PAYVAL + " )";
            dmob.insertRecords(temp_detl_insert);
        }
        else
        {
            dm.connclose();
            throw new Exception("Already Existing Record in temp_detl Table");
        }

        #endregion

        #region //------------------ VOUBANKDET --------------

        string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
        if (dmob.existRecored(voubankdetSelect) == 0)
        {
            string voubankdetnsert = "INSERT INTO LPHS.VOUBANKDET (POLICYNO ,VOUCHERNO ,PAYEENAME ,BNKNAME ,BNKBRNNAME ,SLIACCTNO, CUSTACCTNO ) " +
                " VALUES (" + polno + " ,'" + vouno + "' ,'" + NAMEPAYEE1 + "' ,'" + BKNAM + "' ,'" + BKBRN + "' ,'" + SLIAcctNo + "', '" + ACNUM + "'  )";
            dmob.insertRecords(voubankdetnsert);
        }
        else
        {
            dm.connclose();
            throw new Exception("Already Exising Voucher Bank Details");
        }

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

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }  
    public string Payee
    {
        get { return payee; }
        set { payee = value; }
    }
    public int Clmno
    {
        get { return clmno; }
        set { clmno = value; }
    }
    public string Vouno
    {
        get { return vouno; }
        set { vouno = value; }
    }
    public double Payamt
    {
        get { return payamt; }
        set { payamt = value; }
    }
}
