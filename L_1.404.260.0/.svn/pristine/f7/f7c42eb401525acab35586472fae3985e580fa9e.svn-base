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

public partial class vouAuth003 : System.Web.UI.Page
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

    DataManager dm = new DataManager();

    private long polno;
    private string MOS;
    private string payee = "";
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
    private string epf = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            try
            {
                //epf = Session["EPFNUM"].ToString();
                epf = "06664";
  
                polno = long.Parse(Request.QueryString["polno"]);
                MOS = Request.QueryString["mos"].ToString();
                vouno = Request.QueryString["vouno"].ToString();               
                share = double.Parse(Request.QueryString["amount"]);
                claimno = long.Parse(Request.QueryString["clmno"]);
                exgrShare = double.Parse(Request.QueryString["exgrshare"]);

                ViewState.Add("polnoQstr", polno.ToString());
                ViewState.Add("MOSQstr", MOS);
                ViewState.Add("vounoQstr", vouno);               
                ViewState.Add("shareQstr", share.ToString());
                ViewState.Add("clmno", claimno.ToString());
                ViewState.Add("exgrshareStr", exgrShare.ToString());

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                if (exgrShare > 0) { share = 0; } else { exgrShare = 0; }
                this.lblamtinfigures.Text = String.Format("{0:N}", (share + exgrShare));
                this.lblclmAmt.Text = String.Format("{0:N}", share);
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round((share + exgrShare), 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                #region //--------------- CASHBOOK.PASSWORD select ---------------------------

                string AUTHLMT = "";
                double AUTHLMTdbl = 0;

                string CASHBOOK_PASSWORD_select = "SELECT AUTHLMT FROM CASHBOOK.PASSWORD WHERE (EPF ='" + epf + "')";
                if (dm.existRecored(CASHBOOK_PASSWORD_select) != 0)
                {
                    dm.readSql(CASHBOOK_PASSWORD_select);
                    OracleDataReader CASHBOOK_PASSWORDreader = dm.oraComm.ExecuteReader();
                    while (CASHBOOK_PASSWORDreader.Read())
                    {
                        if (!CASHBOOK_PASSWORDreader.IsDBNull(0)) { AUTHLMT = CASHBOOK_PASSWORDreader.GetString(0); } else { AUTHLMT = ""; }
                    }
                    CASHBOOK_PASSWORDreader.Close();

                    #region //--------------- TEMP_CB select -------------------------------------

                    string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                        "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd'))  " +
                        " from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and AUTHORIZED = 0 ";

                    if (dm.existRecored(temp_cbSelect) != 0)
                    {
                        dm.readSql(temp_cbSelect);
                        OracleDataReader temp_cbReader = dm.oraComm.ExecuteReader();
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
                                              
                        this.lblacctno.Text = ACNO;
                        this.lblassuredname.Text = INSNAME;
                        this.lblnameofpayee.Text = HNAME1;
                        this.lblad1.Text = ADD1;
                        this.lblad2.Text = ADD2;
                        this.lblad3.Text = ADD3;
                        if (voudate > 9999999)
                        {
                            this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                        }

                    }
                    else { throw new Exception("No Voucher Details Availbale or Voucher Already Authorized!"); }

                    if ((AUTHLMT != null) && (!AUTHLMT.Equals("")))
                    {
                        try
                        {
                            AUTHLMTdbl = double.Parse(AUTHLMT);
                        }
                        catch (Exception exp) { throw new Exception("Auth Limit is not Numeric" + exp); }
                    }

                    if (TOTAMOUNT > AUTHLMTdbl) { throw new Exception("Exceeds Voucher Authorization Limit"); }

                    #endregion
                    
                    #region //--------------- voubankdet select ----------------------------------

                    string SLIACCTNO = "";

                    string voubankdetSel = "select PAYEENAME, BNKNAME, BNKBRNNAME, SLIACCTNO, CUSTACCTNO from LPHS.VOUBANKDET where POLICYNO = " + polno + " and VOUCHERNO = '" + vouno + "' ";
                    if (dm.existRecored(voubankdetSel) != 0)
                    {
                        dm.readSql(voubankdetSel);
                        OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader();
                        while (voubankdetReader.Read())
                        {
                            if (!voubankdetReader.IsDBNull(1)) { BNKNAME = voubankdetReader.GetString(1); } else { BNKNAME = ""; }
                            if (!voubankdetReader.IsDBNull(2)) { BNKBRNNAME = voubankdetReader.GetString(2); } else { BNKBRNNAME = ""; }
                            if (!voubankdetReader.IsDBNull(3)) { SLIACCTNO = voubankdetReader.GetString(3); } else { SLIACCTNO = ""; }
                            if (!voubankdetReader.IsDBNull(4)) { CUSTACCTNO = voubankdetReader.GetString(4); } else { CUSTACCTNO = ""; }                            
                        }
                        voubankdetReader.Close();
                    }
                    else
                    {
                        BNKNAME = "";
                        BNKBRNNAME = "";
                        SLIACCTNO = "";
                        CUSTACCTNO = "";
                    }

                    this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;

                    this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lblcurrenttime.Text = this.setDate()[1];
                    this.lblacctno.Text = CUSTACCTNO;     

                    #endregion
                }
                else { throw new Exception(" No Authority  Given for  Voucher Authorization"); }

                #endregion  

                dm.connClose();

                ViewState["payee"] = payee;
                ViewState["amtOut"] = amtOut;
                ViewState["voudate"] = voudate;

                ViewState["HNAME"] = HNAME;
                ViewState["HNAME1"] = HNAME1;
                ViewState["ACNO"] = ACNO;
                ViewState["ADD1"] = ADD1;
                ViewState["ADD1"] = ADD1;
                ViewState["ADD1"] = ADD1;
                ViewState["INSNAME"] = INSNAME;
                ViewState["RECIPIENT_NAME"] = RECIPIENT_NAME;
                ViewState["TOTAMOUNT"] = TOTAMOUNT;
                ViewState["BNKNAME"] = BNKNAME;
                ViewState["BNKBRNNAME"] = BNKBRNNAME;
                ViewState["CUSTACCTNO"] = CUSTACCTNO;
                ViewState["epf"] = epf; 
   
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
            polno = long.Parse(ViewState["polnoQstr"].ToString());
            MOS = ViewState["MOSQstr"].ToString();
            vouno = ViewState["vounoQstr"].ToString();            
            share = double.Parse(ViewState["shareQstr"].ToString());
            claimno = long.Parse(ViewState["clmno"].ToString());
            exgrShare = long.Parse(ViewState["exgrshareStr"].ToString());

            if (ViewState["payee"] != null) { payee = (ViewState["payee"].ToString()); }
            if (ViewState["amtOut"] != null) { amtOut = long.Parse(ViewState["amtOut"].ToString()); }
            if (ViewState["voudate"] != null) { voudate = int.Parse(ViewState["voudate"].ToString()); }

             if (ViewState["HNAME"] != null) { HNAME = (ViewState["HNAME"].ToString()); }
             if (ViewState["HNAME1"] != null) { HNAME1 = (ViewState["HNAME1"].ToString()); }
             if (ViewState["ACNO"] != null) { ACNO = (ViewState["ACNO"].ToString()); }
             if (ViewState["ADD1"] != null) { ADD1 = (ViewState["ADD1"].ToString()); }
             if (ViewState["ADD2"] != null) { ADD2 = (ViewState["ADD2"].ToString()); }
             if (ViewState["ADD3"] != null) { ADD3 = (ViewState["ADD3"].ToString()); }
             if (ViewState["INSNAME"] != null) { INSNAME = (ViewState["INSNAME"].ToString()); }
             if (ViewState["RECIPIENT_NAME"] != null) { RECIPIENT_NAME = (ViewState["RECIPIENT_NAME"].ToString()); }
             if (ViewState["TOTAMOUNT"] != null) { TOTAMOUNT = double.Parse(ViewState["TOTAMOUNT"].ToString()); }
             if (ViewState["BNKNAME"] != null) { BNKNAME = (ViewState["BNKNAME"].ToString()); }
             if (ViewState["BNKBRNNAME"] != null) { BNKBRNNAME = (ViewState["BNKBRNNAME"].ToString()); }
             if (ViewState["CUSTACCTNO"] != null) { CUSTACCTNO = (ViewState["CUSTACCTNO"].ToString()); }
             if (ViewState["epf"] != null) { epf = (ViewState["epf"].ToString()); } 
        }
    }

    protected void btnauthorize_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            string authSelect = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and AUTHORIZED = 0 ";
            if (dm.existRecored(authSelect) != 0)
            {
                string authoizeUpdate = "UPDATE cashbook.TEMP_CB set status = 'Vou. Authorized', AUTHORIZED = 1, " +
                    " AUODATE = to_date('" + this.setDate()[0] + "', 'yyyymmdd'), AUTHOEPF='" + epf + "'  where Vouno = '" + vouno + "' ";
                dm.insertRecords(authoizeUpdate);

                this.lblsuccess.Visible = true;
                this.btnauthorize.Enabled = false;
            }
            else { throw new Exception("No Record in TEMP_CB To Authorize"); }

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
    
    protected void btnexit_Click(object sender, EventArgs e)
    {

    }
   
}
