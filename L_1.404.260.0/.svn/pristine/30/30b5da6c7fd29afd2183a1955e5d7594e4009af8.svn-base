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
    NumberSeparate ns;
    General gg;

    private long polno;
    private string MOS;
    private string payee = "";
    private double amtOut;
    private long claimno;
    private string reason;

    private string vouno = "";
    private int voudate;
    private double share;
    private double exgrShare;
    private string propno;
    private int depacct = 0;

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
    private int slicflag;
    private double stagePayment;

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
                polno = long.Parse(Request.QueryString["polno"]);
                MOS = Request.QueryString["mos"].ToString();
                vouno = Request.QueryString["vouno"].ToString();
                payee = Request.QueryString["payee"].ToString();
                share = double.Parse(Request.QueryString["amount"]);
                claimno = long.Parse(Request.QueryString["clmno"]);
                exgrShare = double.Parse(Request.QueryString["exgrshare"]);
                slicflag = int.Parse(Request.QueryString["slicflag"]);

                ViewState.Add("polnoQstr", polno.ToString());
                ViewState.Add("MOSQstr", MOS);
                ViewState.Add("vounoQstr", vouno);
                ViewState.Add("payeeQstr", payee);
                ViewState.Add("shareQstr", share.ToString());
                ViewState.Add("clmno", claimno.ToString());
                ViewState.Add("exgrshareStr", exgrShare.ToString());
                ViewState.Add("slicflag", slicflag.ToString());

                #region-------------------Vou. Acct code---------22/04/2009 update------
                gg = new General();
                if (gg.IsVouAmtDeposit(dm, polno, MOS))
                {
                    //Apply the deposit account number
                    depacct = 1168;
                }
                else
                {
                    depacct = 2118;
                }
                this.lblPayac.Text = "00" + depacct.ToString();
                #endregion

                #region------------------------Check Repudiation--------------------
                string repudationsel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='" + MOS + "'";
                if ((dm.existRecored(repudationsel) != 0) && (depacct == 2118))
                {
                    exgrShare = share;
                    //share=0;
                }
                #endregion

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", share);
                //this.lblclmAmt.Text = String.Format("{0:N}", share);
                //if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                
                //Task 30080
                if ((share - exgrShare) > 0.5) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                 
                if ((share - exgrShare) <= 0.5)
                {
                    exgrShare = share;
                }
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);

                
                //if (share > 0)
                //{
                //    double share100 = (Math.Round(share, 2) * 100);
                //    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                //    readAmountFunction readamt = new readAmountFunction();
                //    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                //}
                //else { this.lblamtinwords.Text = ""; }

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round((share), 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                //Check SLIC Voucher or not------Editted by Dushan------
                if (slicflag == 1)
                {
                    this.lblPaytype.Text = "SLIC VOUCHER FOR DEATH CLAIMS";
                    this.lblProposal.Visible = true;
                    this.lblProposal1.Visible = true;
                    string propnosel = "select SVREASON from LPHS.SLICVOUCHERS where SVPOL=" + polno + " and SVCLMTYP='DTH' and SVMOS='" + MOS + "' and SVVOUNO='" + vouno + "'";
                    if (dm.existRecored(propnosel) != 0)
                    {
                        dm.readSql(propnosel);
                        OracleDataReader propnoread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (propnoread.Read())
                        {
                            if (!propnoread.IsDBNull(0)) { reason = propnoread.GetString(0); } else { reason = ""; }
                        }
                        propnoread.Close();
                        propnoread.Dispose();
                    }
                    ns = new NumberSeparate(reason.Trim());
                    propno = ns.Number;
                    this.lblProposal1.Text = ": " + propno.Trim();
                }
                //get claim no ----------------

                #region //--------------- CASHBOOK.PASSWORD select ---------------------------

                double AUTHLMT = 0;
                double AUTHLMTdbl = 0;
                string EPF1 = Convert.ToString(dm.EpfCode(EPF));
                string CASHBOOK_PASSWORD_select = "SELECT FINANTIAL_LIMIT FROM LPHS.DTH_ACCESS_CTRL WHERE (EPF ='" + EPF1.Trim() + "' and SYSTEM_ID='DTV')";
                if (dm.existRecored(CASHBOOK_PASSWORD_select) != 0)
                {
                    dm.readSql(CASHBOOK_PASSWORD_select);
                    OracleDataReader CASHBOOK_PASSWORDreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (CASHBOOK_PASSWORDreader.Read())
                    {
                        if (!CASHBOOK_PASSWORDreader.IsDBNull(0)) { AUTHLMT = CASHBOOK_PASSWORDreader.GetDouble(0); } else { AUTHLMT = 0; }
                    }
                    CASHBOOK_PASSWORDreader.Close();
                    CASHBOOK_PASSWORDreader.Dispose();

                    #region //--------------- TEMP_CB select -------------------------------------

                    string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                        "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd'))  " +
                        " from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and AUTHORIZED = 0 ";

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

                        this.lblacctno.Text = ACNO;
                        this.lblassuredname.Text = INSNAME;
                        //this.lblnameofpayee.Text = HNAME1;
                        //if (HNAME1.Equals(""))
                        HNAME1 = HNAME + " " + HNAME1;
                        this.lblad1.Text = ADD1;
                        this.lblad2.Text = ADD2;
                        this.lblad3.Text = ADD3;
                        if (voudate > 9999999)
                        {
                            this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                        }

                    }
                    else
                    {
                        dm.connclose();
                        throw new Exception("No Voucher Details Availbale or Voucher Already Authorized!");
                    }

                    //if ((AUTHLMT != null) && (!AUTHLMT.Equals("")))
                    //{
                    //    try
                    //    {
                    //        AUTHLMTdbl = double.Parse(AUTHLMT);
                    //    }
                    //    catch (Exception exp)
                    //    {
                    //        dm.connclose();
                    //        throw new Exception("Auth Limit is not Numeric" + exp);
                    //    }
                    //}

                    if (TOTAMOUNT > AUTHLMT) { throw new Exception("Exceeds Voucher Authorization Limit"); }

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
                            if (!voubankdetReader.IsDBNull(0)) { HNAME1 = voubankdetReader.GetString(0); } else { HNAME1 = ""; }
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

                    this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;
                    this.lblnameofpayee.Text = HNAME1;
                    this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lblcurrenttime.Text = this.setDate()[1];
                    this.lblacctno.Text = CUSTACCTNO;

                    #endregion
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Authority  Given for  Voucher Authorization");
                }

                #endregion  

                //Task 34965
                string vouStageDetails = "select sum(total) from CASHBOOK.TEMP_DETL where vouno='" + vouno + "' and ACCODE=2235";
                if (dm.existRecored(vouStageDetails) != 0)
                {
                    dm.readSql(vouStageDetails);
                    OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (voubankdetReader.Read())
                    {
                        if (!voubankdetReader.IsDBNull(0)) { stagePayment = voubankdetReader.GetDouble(0); } else { stagePayment = 0; }
                    }
                    voubankdetReader.Close();
                    voubankdetReader.Dispose();
                }
                if (stagePayment > 0)
                {
                    StagePayAccCode.Visible = true;
                    lblStageAmt.Text = String.Format("{0:N}", stagePayment);
                    ViewState["StagePayment"] = stagePayment;
                    if ((share - exgrShare - stagePayment) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare - stagePayment)); }
                }
                //

                //------------------------
                ViewState["amtOut"] = amtOut;

                ViewState["HNAME"] = HNAME;
                ViewState["HNAME1"] = HNAME1;
                ViewState["ACNO"] = ACNO;
                ViewState["ADD1"] = ADD1;
                ViewState["ADD2"] = ADD2;
                ViewState["ADD3"] = ADD3;
                ViewState["EPF"] = EPF;
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
                Response.Redirect("~/EPage.aspx");
            }

        }
        else 
        {
            polno = long.Parse(ViewState["polnoQstr"].ToString());
            MOS = ViewState["MOSQstr"].ToString();
            vouno = ViewState["vounoQstr"].ToString();
            payee = ViewState["payeeQstr"].ToString();
            share = double.Parse(ViewState["shareQstr"].ToString());
            claimno = long.Parse(ViewState["clmno"].ToString());
            exgrShare = double.Parse(ViewState["exgrshareStr"].ToString());

            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }

            if (ViewState["HNAME"] != null) { HNAME = ViewState["HNAME"].ToString(); }
            if (ViewState["HNAME1"] != null) { HNAME1 = ViewState["HNAME1"].ToString(); }
            if (ViewState["ACNO"] != null) { ACNO = ViewState["ACNO"].ToString(); }
            if (ViewState["ADD1"] != null) { ADD1 = ViewState["ADD1"].ToString(); }
            if (ViewState["ADD2"] != null) { ADD2 = ViewState["ADD2"].ToString(); }
            if (ViewState["ADD3"] != null) { ADD3 = ViewState["ADD3"].ToString(); }
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
            if (ViewState["INSNAME"] != null) { INSNAME = ViewState["INSNAME"].ToString(); }
            if (ViewState["RECIPIENT_NAME"] != null) { RECIPIENT_NAME = ViewState["RECIPIENT_NAME"].ToString(); }
            if (ViewState["TOTAMOUNT"] != null) { TOTAMOUNT = double.Parse(ViewState["TOTAMOUNT"].ToString()); }
            if (ViewState["BNKNAME"] != null) { BNKNAME = ViewState["BNKNAME"].ToString(); }
            if (ViewState["BNKBRNNAME"] != null) { BNKBRNNAME = ViewState["BNKBRNNAME"].ToString(); }
            if (ViewState["CUSTACCTNO"] != null) { CUSTACCTNO = ViewState["CUSTACCTNO"].ToString(); }
            if (ViewState["StagePayment"] != null) { stagePayment = double.Parse(ViewState["StagePayment"].ToString()); }
        }
    }

    protected void btnauthorize_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
          
            string authSelect = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and AUTHORIZED = 0 ";
            if (dm.existRecored(authSelect) != 0)
            {
                string authoizeUpdate = "UPDATE cashbook.TEMP_CB set status = 'Vou.Authorized', AUTHORIZED = 1, " +
                    " AUODATE = to_date('" + this.setDate()[0] + "', 'yyyymmdd'), AUTHOEPF='" + EPF + "'  where Vouno = '" + vouno + "' ";
                dm.insertRecords(authoizeUpdate);

                this.lblsuccess.Visible = true;
                this.btnauthorize.Enabled = false;
            }
            else
            {
                dm.connclose();
                throw new Exception("No Record in TEMP_CB To Authorize");
            }

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    
    protected void btnexit_Click(object sender, EventArgs e)
    {

    }
   
}
