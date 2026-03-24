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

public partial class cvouAuth003 : System.Web.UI.Page
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
    private string ADD4 = "";
    private string INSNAME = "";
    private string RECIPIENT_NAME = "";
    private double TOTAMOUNT;
    private string BNKNAME = "";
    private string BNKBRNNAME = "";
    private string CUSTACCTNO = "";
    private string epf = "";
    private int accode;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //{
        //    polno = this.PreviousPage.Polno;
        //}

        

        if (!Page.IsPostBack)
        {
            if (Session["EPFNum"] != null || Session["brcode"] != null)
            {
                epf = Session["EPFNum"].ToString();
                //branch = Convert.ToInt32(Session["brcode"]);
            }
            else
            {
                Response.Redirect("SessionError.aspx", false);
            }
            dm = new DataManager();
            try
            {
                polno = long.Parse(Request.QueryString["polno"]);
                MOS = Request.QueryString["mos"].ToString();
                vouno = Request.QueryString["vouno"].ToString();
                payee = Request.QueryString["payee"].ToString();
                share = double.Parse(Request.QueryString["amount"]);
                //claimno = long.Parse(Request.QueryString["clmno"]);
                //exgrShare = double.Parse(Request.QueryString["exgrshare"]);

                ViewState.Add("polnoQstr", polno.ToString());
                ViewState.Add("MOSQstr", MOS);
                ViewState.Add("vounoQstr", vouno);
                ViewState.Add("payeeQstr", payee);
                ViewState.Add("shareQstr", share.ToString());
                //ViewState.Add("clmno", claimno.ToString());
                //ViewState.Add("exgrshareStr", exgrShare.ToString());

                General gg = new General();
                accode = gg.Account_code(polno, "CP", dm);

                #region ---------dthref--------------------------
                string dthsql = "";
                string dthrefsel = "select DRCLMNO from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOS + "'";
                string childprotoutsel = "select CLAIMNO from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + MOS + "'";
                if (dm.existRecored(dthrefsel) != 0 || dm.existRecored(childprotoutsel)!=0)
                {
                    if (dm.existRecored(dthrefsel) != 0) { dthsql = dthrefsel; }
                    else { dthsql = childprotoutsel; }
                    dm.readSql(dthsql);
                    OracleDataReader dthrefread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    dthrefread.Read();
                    if (!dthrefread.IsDBNull(0)) { claimno = dthrefread.GetInt64(0); } else { claimno = 0; }
                    dthrefread.Close();
                    dthrefread.Dispose();
                }
                #endregion

                #region
                string tempcbsel = "select POLNO from CASHBOOK.TEMP_CB where POLNO=" + polno + " and VOUNO='" + vouno + "' and VPDATE is null";
                if (dm.existRecored(tempcbsel) != 0)
                {
                    dm.oraConn.Dispose();
                    throw new Exception("No Printed Voucher Found!");
                }
                #endregion

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", share);
                if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);
                this.lblaccode.Text = "00" + accode.ToString();

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round((share + exgrShare), 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                #region //--------------- CASHBOOK.PASSWORD select ---------------------------

                double AUTHLMT = 0;
                double AUTHLMTdbl = 0;
                string EPF1 = Convert.ToString(dm.EpfCode(epf));
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
                        "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd')), ADD4 " +
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
                            if (!temp_cbReader.IsDBNull(12)) { ADD4 = temp_cbReader.GetString(12); } else { ADD4 = ""; }
                        }
                        temp_cbReader.Close();
                        temp_cbReader.Dispose();

                        this.lblacctno.Text = ACNO;
                        this.lblassuredname.Text = INSNAME.ToUpper();
                        
                        this.lblad1.Text = ADD1.ToUpper();
                        this.lblad2.Text = ADD2.ToUpper();
                        this.lblad3.Text = ADD3.ToUpper();
                        this.lblad4.Text = ADD4.ToUpper();
                        if (voudate > 9999999)
                        {
                            this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                        }

                    }
                    else 
                    {
                        dm.oraConn.Dispose();
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
                    //        dm.oraConn.Dispose();
                    //        throw new Exception("Auth Limit is not Numeric" + exp); 
                    //    }
                    //}

                    if (TOTAMOUNT > AUTHLMT) 
                    {
                        dm.oraConn.Dispose();
                        throw new Exception("Exceeds Voucher Authorization Limit"); 
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

                    this.lblbkbranch.Text = BNKNAME.ToUpper() + " " + BNKBRNNAME.ToUpper();
                    this.lblnameofpayee.Text = HNAME1.ToUpper();
                    this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lblcurrenttime.Text = this.setDate()[1];
                    this.lblacctno.Text = CUSTACCTNO;

                    #endregion
                }
                else 
                {
                    dm.oraConn.Dispose();
                    throw new Exception(" No Authority  Given for  Voucher Authorization"); 
                }

                #endregion

                //------------------------
                ViewState["amtOut"] = amtOut;
                ViewState["claimno"] = claimno;
                ViewState["HNAME"] = HNAME;
                ViewState["HNAME1"] = HNAME1;
                ViewState["ACNO"] = ACNO;
                ViewState["ADD1"] = ADD1;
                ViewState["ADD2"] = ADD2;
                ViewState["ADD3"] = ADD3;
                ViewState["ADD4"] = ADD4;
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
                dm.connclose();
                dm.oraConn.Dispose();
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
            //claimno = long.Parse(ViewState["clmno"].ToString());
            //exgrShare = long.Parse(ViewState["exgrshareStr"].ToString());

            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
            if (ViewState["claimno"] != null) { amtOut = int.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["HNAME"] != null) { HNAME = ViewState["HNAME"].ToString(); }
            if (ViewState["HNAME1"] != null) { HNAME1 = ViewState["HNAME1"].ToString(); }
            if (ViewState["ACNO"] != null) { ACNO = ViewState["ACNO"].ToString(); }
            if (ViewState["ADD1"] != null) { ADD1 = ViewState["ADD1"].ToString(); }
            if (ViewState["ADD2"] != null) { ADD2 = ViewState["ADD2"].ToString(); }
            if (ViewState["ADD3"] != null) { ADD3 = ViewState["ADD3"].ToString(); }
            if (ViewState["ADD4"] != null) { ADD4 = ViewState["ADD4"].ToString(); }
            if (ViewState["INSNAME"] != null) { INSNAME = ViewState["INSNAME"].ToString(); }
            if (ViewState["RECIPIENT_NAME"] != null) { RECIPIENT_NAME = ViewState["RECIPIENT_NAME"].ToString(); }
            if (ViewState["TOTAMOUNT"] != null) { TOTAMOUNT = double.Parse(ViewState["TOTAMOUNT"].ToString()); }
            if (ViewState["BNKNAME"] != null) { BNKNAME = ViewState["BNKNAME"].ToString(); }
            if (ViewState["BNKBRNNAME"] != null) { BNKBRNNAME = ViewState["BNKBRNNAME"].ToString(); }
            if (ViewState["CUSTACCTNO"] != null) { CUSTACCTNO = ViewState["CUSTACCTNO"].ToString(); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try 
        {

            string authSelect = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and AUTHORIZED = 0 ";
            if (dm.existRecored(authSelect) != 0)
            {
                string authoizeUpdate = "UPDATE cashbook.TEMP_CB set status = 'Vou. Authorized', AUTHORIZED = 1, " +
                    " AUODATE = to_date('" + this.setDate()[0] + "', 'yyyymmdd'), AUTHOEPF='" + epf + "'  where Vouno = '" + vouno + "' ";
                dm.insertRecords(authoizeUpdate);

                this.lblsuccess.Visible = true;
                this.btnauthorize.Enabled = false;
            }
            else 
            {
                dm.oraConn.Dispose();
                throw new Exception("No Record in TEMP_CB To Authorize"); 
            }

            dm.connclose();
            dm.oraConn.Dispose();

            //Server.Transfer("~/voucher/vouReprint004.aspx", true);
        }
        catch (Exception ex)
        {
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
    protected void btnexit_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Home.aspx",true);
    }
}
