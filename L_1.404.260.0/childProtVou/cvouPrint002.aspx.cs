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

public partial class cvouPrint002 : System.Web.UI.Page
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
    private long polno;
    private string MOS;
//    private string payee = "";
    private double amtOut;
    private long claimno;

    private string vouno = "";
    private int voudate;
    private double share;
    private double exgrShare;

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
    private string EPF = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (!Page.IsPostBack)
        {
            try
            {

                #region //----------- view state -------

                if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
                {
                    polno = this.PreviousPage.Polno;
                    claimno = this.PreviousPage.Clmno;
                    vouno = this.PreviousPage.Vouno;
                    share = this.PreviousPage.Payamt;
                }

                //ViewState.Add("polnoQstr", polno.ToString());
                //ViewState.Add("vounoQstr", vouno);
                //ViewState.Add("shareQstr", share.ToString());
                //ViewState.Add("clmno", claimno.ToString());


                #endregion

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", (share));
                if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round((share + exgrShare), 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                //get claim no ----------------
                dm = new DataManager();

                #region //--------------- temp_cb select -------------------------------------
                
                string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                    "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd')) " +
                    " from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and (PRINT1 = 0 or PRINT1 is null) and VPDATE is null";

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
                        if (!temp_cbReader.IsDBNull(11)) { voudate = temp_cbReader.GetInt32(11); } else { voudate = 0; }
                    }
                    temp_cbReader.Close();
                    temp_cbReader.Dispose();

                    this.lblassuredname.Text = INSNAME.ToUpper();
                    this.lblnameofpayee.Text = HNAME1.ToUpper();
                    this.lblad1.Text = ADD1.ToUpper();
                    this.lblad2.Text = ADD2.ToUpper();
                    this.lblad3.Text = ADD3.ToUpper();
                    if (voudate > 9999999)
                    {
                        this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                    }

                }
                else
                {
                    dm.oraConn.Dispose();
                    throw new Exception("No Voucher Details Availbale or Voucher Already Printed!");
                }

                #endregion

                #region //--------------- voubankdet select ----------------------------------

                string SLIACCTNO = "";

                string voubankdetSel = "select PAYEENAME, BNKNAME, BNKBRNNAME, SLIACCTNO, CUSTACCTNO from LPHS.VOUBANKDET where POLICYNO = " + polno + " and VOUCHERNO = '" + vouno + "' ";
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
                    voubankdetReader.Close();
                    voubankdetReader.Dispose();
                }
                else
                {
                    BNKNAME = "";
                    BNKBRNNAME = "";
                    SLIACCTNO = "";
                    CUSTACCTNO = "";
                }
                this.lblbkbranch.Text = BNKNAME.ToUpper() + " " + BNKBRNNAME.ToUpper();

                #endregion

                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];
                this.lblacctno.Text = CUSTACCTNO;

                dm.connclose();
                dm.oraConn.Close();
                //------------
                ViewState["share"] = share;
                ViewState["amtOut"] = amtOut;
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;
                ViewState["vouno"] = vouno;
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
                ViewState["EPF"] = EPF;
                ViewState["claimno"] = claimno;
            }
            catch (Exception ex)
            {
                dm.connclose();
                dm.oraConn.Dispose();
                EPage.Messege = ex.Message;
                Response.Redirect("../EPage.aspx");
            }
        }
        else
        {
            //polno = long.Parse(ViewState["polnoQstr"].ToString());
            //vouno = ViewState["vounoQstr"].ToString();
            //share = double.Parse(ViewState["shareQstr"].ToString());
            //claimno = long.Parse(ViewState["clmno"].ToString());

            if (ViewState["polno"] != null) { polno = int.Parse (ViewState["polno"].ToString()); }
            if (ViewState["vouno"] != null) { vouno = ViewState["vouno"].ToString(); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }
            if (ViewState["claimno"] != null) { polno = int.Parse (ViewState["claimno"].ToString()); }
            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
            if (ViewState["share"] !=null) { share=double.Parse (ViewState["share"].ToString());}
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
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }

        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/voucher/vouPrintMain.aspx", true);
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
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
    public double tOTAMOUNT
    {
        get { return TOTAMOUNT; }
        set { TOTAMOUNT = value; }
    }
    public double AmtOut
    {
        get { return amtOut; }
        set { amtOut = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public string Vouno
    {
        get { return vouno; }
        set { vouno = value; }
    }
    public int Voudate
    {
        get { return voudate; }
        set { voudate = value; }
    }
    public double Share
    {
        get { return share; }
        set { share = value; }
    }
    public string cUSTACCTNO
    {
        get { return CUSTACCTNO; }
        set { CUSTACCTNO = value; }
    }
    public double ExgrShare
    {
        get { return exgrShare; }
        set { exgrShare = value; }
    }
}
