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

public partial class vouPrint002 : System.Web.UI.Page
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

    private int printButtonCount;
    private long polno;
    private long surrenderno;
    private string LSUVNO = "";
    private string epf = "";
    DataManager dm;

    private int lsuvdt;
    private int LSUSBR;
    private double LSUVAL;
    private long newLoanNum;
    private long LSULNO;
    private double LSULCA;
    private double LSULIN;
    private double LSUNET;
    private double LSUBON;

    private string HNAME = "";
    private string HNAME1 = "";
    private string ACNO = "";
    private string ADD1 = "";
    private string ADD2 = "";
    private string ADD3 = "";
    private string INSNAME = "";
    private string RECIPIENT_NAME = "";
    private double TOTAMOUNT;
    private string BNKNAME = "";
    private string BNKBRNNAME = "";
    private string CUSTACCTNO = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //{
        //    polno = this.PreviousPage.Polno;
        //}

        if (!Page.IsPostBack)
        {
            try
            {
                //lsuvdt = 0; LSUSBR = 0; LSUVAL = 0; newLoanNum = 0; surrenderno = 0;
                //LSULNO = 0; LSULCA = 0; LSULIN = 0; LSUNET = 0; LSUBON = 0;
                //HNAME = ""; HNAME1 = ""; ACNO = ""; ADD1 = ""; ADD2 = ""; ADD3 = ""; INSNAME = "";
                //RECIPIENT_NAME = ""; TOTAMOUNT = 0; BNKNAME = ""; BNKBRNNAME = ""; CUSTACCTNO = "";
                //printButtonCount = 0;
                //if (Session["epfnum"] != null) { epf = Session["epfnum"].ToString(); }
                //epf = Session["epfnum"].ToString();

                if (Session["EPFNum"] != null)
                {
                    epf = Session["EPFNum"].ToString();
                }
                else
                {
                    throw new Exception("Your Session Variable Expired Please Log on to the System!");
                }

                if (Request.QueryString["polino"] != null)
                {
                    polno = long.Parse(Request.QueryString["polino"].ToString());
                    ViewState.Add("polnoQstr", polno.ToString());
                }
                if (Request.QueryString["vno"] != null)
                {
                    LSUVNO = Request.QueryString["vno"].ToString();
                    ViewState.Add("vnoQstr", LSUVNO.ToString());
                }

                //epf = Session["EPFNUM"];
                dm = new DataManager();

                this.lblpolno.Text = polno.ToString();

                string lsuast = "";
                string lsuvst = "";

                int count = 0;

                #region //--------------- lsuref select ------------------------------------------------
                string lsurefSelect = "select LSUSTA, LSUSBR, LSUVAL, LSULNO, LSULCA, LSULIN, LSUDAT, " +
                    " LSUNET, LSUVNO, LSUTABLE, LSUTERM, LSUAGT, LSUBON, lsuast, lsuvst, lsuvdt, NEWSURRENDERNO from LPHS.LSUREF where lsupol = " + polno + " and lsutyp = 'S' and lsuast = 'Y' and lsuvst = 'Y' ";
                if (dm.existRecored(lsurefSelect) != 0)
                {
                    dm.readSql(lsurefSelect);
                    OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lsurefReader.Read())
                    {
                        count++;
                        if (!lsurefReader.IsDBNull(1)) { LSUSBR = lsurefReader.GetInt32(1); } else { LSUSBR = 0; }
                        if (!lsurefReader.IsDBNull(2)) { LSUVAL = lsurefReader.GetDouble(2); } else { LSUVAL = 0; }
                        if (!lsurefReader.IsDBNull(3)) { LSULNO = lsurefReader.GetInt64(3); } else { LSULNO = 0; }
                        if (!lsurefReader.IsDBNull(4)) { LSULCA = lsurefReader.GetDouble(4); } else { LSULCA = 0; }
                        if (!lsurefReader.IsDBNull(5)) { LSULIN = lsurefReader.GetDouble(5); } else { LSULIN = 0; }
                        if (!lsurefReader.IsDBNull(7)) { LSUNET = lsurefReader.GetDouble(7); } else { LSUNET = 0; }
                        //if (!lsurefReader.IsDBNull(8)) { LSUVNO = lsurefReader.GetString(8); } else { LSUVNO = ""; }
                        if (!lsurefReader.IsDBNull(12)) { LSUBON = lsurefReader.GetDouble(12); } else { LSUBON = 0; }

                        if (!lsurefReader.IsDBNull(13)) { lsuast = lsurefReader.GetString(13); } else { lsuast = ""; }
                        if (!lsurefReader.IsDBNull(14)) { lsuvst = lsurefReader.GetString(14); } else { lsuvst = ""; }
                        if (!lsurefReader.IsDBNull(15)) { lsuvdt = lsurefReader.GetInt32(15); } else { lsuvdt = 0; }
                        surrenderno = lsurefReader.GetInt64(16);

                        this.lblvouno.Text = LSUVNO;
                        this.lbldate.Text = lsuvdt.ToString().Substring(0, 4) + "/" + lsuvdt.ToString().Substring(4, 2) + "/" + lsuvdt.ToString().Substring(6, 2);
                        this.lblfullbons.Text = String.Format("{0:N}", LSUBON);
                        this.lblloanno.Text = surrenderno.ToString();
                        this.lblloanval.Text = String.Format("{0:N}", LSUVAL);
                        //this.lblamtinfigures.Text = String.Format("{0:N}", LSUNET);

                        //if (LSUNET > 0)
                        //{
                        //    double LSUNET100 = (Math.Round(LSUNET, 2) * 100);

                        //    string surrvalinwords = LSUNET100.ToString().Substring(0, (LSUNET100.ToString().Length - 2)) + "." + LSUNET100.ToString().Substring((LSUNET100.ToString().Length - 2), 2);
                        //    readAmountFunction readamt = new readAmountFunction();
                        //    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                        //}
                        //else { this.lblamtinwords.Text = ""; }

                        #region //--------------- temp_cb select -------------------------------------

                        string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                            "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GBROSS_AMOUNT " +
                            " from CASHBOOK.TEMP_CB where vouno = '" + LSUVNO + "' and (PRINT1 = 0 or PRINT1 is null)";

                        if (dm.existRecored(temp_cbSelect) != 0)
                        {
                            dm.readSql(temp_cbSelect);
                            OracleDataReader temp_cbReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (temp_cbReader.Read())
                            {
                                if (!temp_cbReader.IsDBNull(0)) { HNAME = temp_cbReader.GetString(0); } else { HNAME = ""; }
                                if (!temp_cbReader.IsDBNull(1)) { HNAME1 = temp_cbReader.GetString(1); } else { HNAME1 = ""; }
                                if (!temp_cbReader.IsDBNull(3)) { ACNO = temp_cbReader.GetString(3); } else { ACNO = ""; }
                                if (!temp_cbReader.IsDBNull(6)) { ADD1 = temp_cbReader.GetString(6); } else { ADD1 = ""; }
                                if (!temp_cbReader.IsDBNull(7)) { ADD2 = temp_cbReader.GetString(7); } else { ADD2 = ""; }
                                if (!temp_cbReader.IsDBNull(8)) { ADD3 = temp_cbReader.GetString(8); } else { ADD3 = ""; }
                                if (!temp_cbReader.IsDBNull(5)) { INSNAME = temp_cbReader.GetString(5); } else { INSNAME = ""; }
                                if (!temp_cbReader.IsDBNull(9)) { RECIPIENT_NAME = temp_cbReader.GetString(9); } else { RECIPIENT_NAME = ""; }
                                if (!temp_cbReader.IsDBNull(2)) { TOTAMOUNT = temp_cbReader.GetDouble(2); } else { TOTAMOUNT = 0; }
                            }
                            //temp_cbReader.Close();
                            //temp_cbReader.Dispose();

                            //this.lblbkbranch.Text = HNAME;
                            //this.lblacctno.Text = ACNO;
                            this.lblamtinfigures.Text = String.Format("{0:N}", (double)TOTAMOUNT);

                            if (TOTAMOUNT > 0)
                            {
                                double LSUNET100 = (Math.Round(TOTAMOUNT, 2) * 100);
                                string surrvalinwords = LSUNET100.ToString().Substring(0, (LSUNET100.ToString().Length - 2)) + "." + LSUNET100.ToString().Substring((LSUNET100.ToString().Length - 2), 2);
                                readAmountFunction readamt = new readAmountFunction();
                                this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                            }
                            else { this.lblamtinwords.Text = ""; }

                            this.lblassuredname.Text = INSNAME;
                            this.lblnameofpayee.Text = HNAME1;
                            this.lblad1.Text = ADD1;
                            this.lblad2.Text = ADD2;
                            this.lblad3.Text = ADD3;
                        }
                        else {  throw new Exception("No Voucher Details Availbale or Voucher Already Printed!"); }

                        #endregion

                        #region //--------------- voubankdet select -------------------------------------

                        string SLIACCTNO = "";

                        string voubankdetSel = "select PAYEENAME, BNKNAME, BNKBRNNAME, SLIACCTNO, CUSTACCTNO from LPHS.VOUBANKDET where POLICYNO = " + polno + " and VOUCHERNO = '" + LSUVNO + "' ";
                        if (dm.existRecored(voubankdetSel) != 0)
                        {
                            dm.readSql(voubankdetSel);
                            OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (voubankdetReader.Read())
                            {
                                if (!voubankdetReader.IsDBNull(1)) { BNKNAME = voubankdetReader.GetString(1); } else { BNKNAME = ""; }
                                if (!voubankdetReader.IsDBNull(2)) { BNKBRNNAME = voubankdetReader.GetString(2); } else { BNKBRNNAME = ""; }
                                if (!voubankdetReader.IsDBNull(3)) { SLIACCTNO = voubankdetReader.GetString(3); } else { SLIACCTNO = ""; }
                                if (!voubankdetReader.IsDBNull(4)) { CUSTACCTNO = voubankdetReader.GetString(4); } else { CUSTACCTNO = ""; }
                            }
                            //voubankdetReader.Close();
                            //voubankdetReader.Dispose();
                        }

                        this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;
                        this.lblacctno.Text = CUSTACCTNO;

                        #endregion

                    }
                    lsurefReader.Close();
                    lsurefReader.Dispose();

                    if (count > 1) { throw new Exception("2 Vouchers for this Policy Please Contact IT Division."); }
                    if (!lsuast.Equals("Y")) { dm.connclose(); throw new Exception("Request not yet Authgorized!"); }
                    if (!lsuvst.Equals("Y")) { dm.connclose(); throw new Exception("Voucher not yet Created!"); }
                }
                else { dm.connclose(); throw new Exception("No Appropriate Loan Reference Record!"); }

                #endregion

                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];

                if (LSULNO > 0)
                {
                    this.Label1.Visible = true;
                    this.Label2.Visible = true;
                    this.Label3.Visible = true;
                    this.lbloldloanNo.Visible = true;
                    this.lbloldLoanCapital.Visible = true;
                    this.lbloldLoanInterest.Visible = true;

                    this.lbloldloanNo.Text = ": " + LSULNO.ToString();
                    this.lbloldLoanCapital.Text = ": " + String.Format("{0:N}", LSULCA);
                    this.lbloldLoanInterest.Text = ": " + String.Format("{0:N}", LSULIN);
                }
                else
                {
                    this.Label1.Visible = false;
                    this.Label2.Visible = false;
                    this.Label3.Visible = false;
                    this.lbloldloanNo.Visible = false;
                    this.lbloldLoanCapital.Visible = false;
                    this.lbloldLoanInterest.Visible = false;
                }

                dm.connclose();

                //--------------- 
                ViewState["printButtonCount"] = printButtonCount;
                ViewState["polno"] = polno;
                ViewState["surrenderno"] = surrenderno;
                ViewState["LSUVNO"] = LSUVNO;
                ViewState["epf"] = epf;

                ViewState["lsuvdt"] = lsuvdt;
                ViewState["LSUSBR"] = LSUSBR;
                ViewState["LSUVAL"] = LSUVAL;
                ViewState["newLoanNum"] = newLoanNum;
                ViewState["LSULNO"] = LSULNO;
                ViewState["LSULCA"] = LSULCA;
                ViewState["LSULIN"] = LSULIN;
                ViewState["LSUNET"] = LSUNET;
                ViewState["LSUBON"] = LSUBON;

                ViewState["HNAME"] = HNAME;
                ViewState["HNAME1"] = HNAME1;
                ViewState["ACNO"] = ACNO;
                ViewState["ADD1"] = ADD1;
                ViewState["ADD2"] = ADD2;
                ViewState["ADD3"] = ADD3;
                ViewState["INSNAME"] = INSNAME;
                ViewState["RECIPIENT_NAME"] = RECIPIENT_NAME;
                ViewState["TOTAMOUNT"] = TOTAMOUNT;
                ViewState["BNKNAME"] = BNKNAME;
                ViewState["BNKBRNNAME"] = BNKBRNNAME;
                ViewState["CUSTACCTNO"] = CUSTACCTNO;

            }
            catch (Exception ex)
            {
                dm.connclose(); 
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else 
        {
            if (ViewState["printButtonCount"] != null) { printButtonCount = int.Parse(ViewState["printButtonCount"].ToString()); }
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["surrenderno"] != null) { surrenderno = long.Parse(ViewState["surrenderno"].ToString()); }
            if (ViewState["LSUVNO"] != null) { LSUVNO = ViewState["LSUVNO"].ToString(); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
            
            if (ViewState["lsuvdt"] != null) { lsuvdt = int.Parse(ViewState["lsuvdt"].ToString()); }
            if (ViewState["LSUSBR"] != null) { LSUSBR = int.Parse(ViewState["LSUSBR"].ToString()); }
            if (ViewState["LSUVAL"] != null) { LSUVAL = double.Parse(ViewState["LSUVAL"].ToString()); }
            if (ViewState["newLoanNum"] != null) { newLoanNum = long.Parse(ViewState["newLoanNum"].ToString()); }
            if (ViewState["LSULNO"] != null) { LSULNO = long.Parse(ViewState["LSULNO"].ToString()); }
            if (ViewState["LSULCA"] != null) { LSULCA = double.Parse(ViewState["LSULCA"].ToString()); }
            if (ViewState["LSULIN"] != null) { LSULIN = double.Parse(ViewState["LSULIN"].ToString()); }
            if (ViewState["LSUNET"] != null) { LSUNET = double.Parse(ViewState["LSUNET"].ToString()); }
            if (ViewState["LSUBON"] != null) { LSUBON = double.Parse(ViewState["LSUBON"].ToString()); }

            if (ViewState["HNAME"] != null) { HNAME = ViewState["HNAME"].ToString(); }
            if (ViewState["HNAME1"] != null) { HNAME1 = ViewState["HNAME1"].ToString(); }
            if (ViewState["ACNO"] != null) { ACNO = ViewState["ACNO"].ToString(); }
            if (ViewState["ADD1"] != null) { ADD1 = ViewState["ADD1"].ToString(); }
            if (ViewState["ADD2"] != null) { ADD2 = ViewState["ADD2"].ToString(); }
            if (ViewState["ADD3"] != null) { ADD3 = ViewState["ADD3"].ToString(); }
            if (ViewState["INSNAME"] != null) { INSNAME = ViewState["INSNAME"].ToString(); }
            if (ViewState["RECIPIENT_NAME"] != null) { RECIPIENT_NAME = ViewState["RECIPIENT_NAME"].ToString(); }
            if (ViewState["TOTAMOUNT"] != null) { TOTAMOUNT = double.Parse(ViewState["TOTAMOUNT"].ToString()); }
            if (ViewState["BNKNAME"] != null) { BNKNAME = ViewState["BNKNAME"].ToString(); }
            if (ViewState["BNKBRNNAME"] != null) { BNKBRNNAME = ViewState["BNKBRNNAME"].ToString(); }
            if (ViewState["CUSTACCTNO"] != null) { CUSTACCTNO = ViewState["CUSTACCTNO"].ToString(); }
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            printButtonCount++;

            if (printButtonCount == 1)
            {
                dm = new DataManager();
                string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                string temp_cbSelect = "select * from CASHBOOK.TEMP_CB where vouno = '" + LSUVNO + "' ";
                if (dm.existRecored(temp_cbSelect) != 0)
                {
                    string temp_cbUpdate = "UPDATE  cashbook.temp_cb set PRINT1 = 1, VPDATE = to_date('" + formattedToday + "', 'yyyy/mm/dd'), VPRINTEPF='" + epf + "' where Vouno ='" + LSUVNO + "' ";
                    dm.insertRecords(temp_cbUpdate);

                    string LSUVOUCHERSupdate = "UPDATE LPHS.LSUVOUCHERS SET PRINTEDYN = 'Y' WHERE lspolno = " + polno + " and lsvouno = '" + LSUVNO + "' ";
                    dm.insertRecords(LSUVOUCHERSupdate);
                }
                else {  throw new Exception("No Voucher Details"); }
                //this.btnprint.Enabled = false;
            }
            else {  throw new Exception("Voucher Once Printed"); }
        }
        catch (Exception ex)
        {
            dm.connclose(); 
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
   
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public int lSUSBR{
        get { return LSUSBR; }
        set { LSUSBR = value; }
    }
    public double lSUVAL
    {
        get { return LSUVAL; }
        set { LSUVAL = value; }
    }
    public long NewLoanNum
    {
        get { return newLoanNum; }
        set { newLoanNum = value; }
    }   
    public double lSUNET
    {
        get { return LSUNET; }
        set { LSUNET = value; }
    }
    public double lSUBON
    {
        get { return LSUBON; }
        set { LSUBON = value; }
    }

    public string hNAME
    {
        get { return HNAME; }
        set { HNAME = value; }
    }
    public string hNAME1
    {
        get { return HNAME1; }
        set { HNAME1 = value; }
    }
    public string aCNO
    {
        get { return ACNO; }
        set { ACNO = value; }
    }
    public string aDD1
    {
        get { return ADD1; }
        set { ADD1 = value; }
    }
    public string aDD2
    {
        get { return ADD2; }
        set { ADD2 = value; }
    }
    public string aDD3
    {
        get { return ADD3; }
        set { ADD3 = value; }
    }
    public string iNSNAME
    {
        get { return INSNAME; }
        set { INSNAME = value; }
    }
    public string rECIPIENT_NAME
    {
        get { return RECIPIENT_NAME; }
        set { RECIPIENT_NAME = value; }
    }
    public int Lsuvdt
    {
        get { return lsuvdt; }
        set { lsuvdt = value; }
    }
    public string lSUVNO
    {
        get { return LSUVNO; }
        set { LSUVNO = value; }
    }
    public string bNKNAME
    {
        get { return BNKNAME; }
        set { BNKNAME = value; }
    }
    public string bNKBRNNAME
    {
        get { return BNKBRNNAME; }
        set { BNKBRNNAME = value; }
    }
    public string cUSTACCTNO
    {
        get { return CUSTACCTNO; }
        set { CUSTACCTNO = value; }
    }
    public double tOTAMOUNT
    {
        get { return TOTAMOUNT; }
        set { TOTAMOUNT = value; }
    }

    public long lSULNO
    {
        get { return LSULNO; }
        set { LSULNO = value; }
    }
    public double lSULCA
    {
        get { return LSULCA; }
        set { LSULCA = value; }
    }
    public double lSULIN
    {
        get { return LSULIN; }
        set { LSULIN = value; }
    }
    public long Surrenderno
    {
        get { return surrenderno; }
        set { surrenderno = value; }
    }

}
