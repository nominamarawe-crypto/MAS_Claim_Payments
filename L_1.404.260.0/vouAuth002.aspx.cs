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

public partial class vouAuth002 : System.Web.UI.Page
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
    private string LSUVNO = "";
    private string epf = "";
    DataManager dm;

    private int lsuvdt;
    private int LSUSBR;
    private double LSUVAL;
    private long newLoanNum;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
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
                    polno = long.Parse(Request.QueryString["polino"].ToString());
                    ViewState.Add("polnoQstr", polno.ToString());
                }
                if (Request.QueryString["vno"] != null)
                {
                    LSUVNO = Request.QueryString["vno"].ToString();
                    ViewState.Add("vnoQstr", LSUVNO.ToString());
                }
                this.lblpolno.Text = polno.ToString();

                string lsuast = "";
                string lsuvst = "";

                int count = 0;

                #region //--------------- lsuref select ------------------------------------------------

                string lsurefSelect = "select LSUSTA, LSUSBR, LSUVAL, LSULNO, LSULCA, LSULIN, LSUDAT, " +
                   " LSUNET, LSUVNO, LSUTABLE, LSUTERM, LSUAGT, LSUBON, lsuast, lsuvst, lsuvdt from LPHS.LSUREF where lsupol = " + polno + " and lsutyp = 'S' and lsuast = 'Y' and lsuvst = 'Y' ";
                if (dm.existRecored(lsurefSelect) != 0)
                {
                    dm.readSql(lsurefSelect);
                    OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lsurefReader.Read())
                    {
                        count++;
                        if (!lsurefReader.IsDBNull(1)) { LSUSBR = lsurefReader.GetInt32(1); } else { LSUSBR = 0; }
                        if (!lsurefReader.IsDBNull(2)) { LSUVAL = lsurefReader.GetDouble(2); } else { LSUVAL = 0; }
                        if (!lsurefReader.IsDBNull(4)) { LSULCA = lsurefReader.GetDouble(4); } else { LSULCA = 0; }
                        if (!lsurefReader.IsDBNull(5)) { LSULIN = lsurefReader.GetDouble(5); } else { LSULIN = 0; }
                        if (!lsurefReader.IsDBNull(7)) { LSUNET = lsurefReader.GetDouble(7); } else { LSUNET = 0; }
                        //if (!lsurefReader.IsDBNull(8)) { LSUVNO = lsurefReader.GetString(8); } else { LSUVNO = ""; }
                        if (!lsurefReader.IsDBNull(12)) { LSUBON = lsurefReader.GetDouble(12); } else { LSUBON = 0; }

                        if (!lsurefReader.IsDBNull(13)) { lsuast = lsurefReader.GetString(13); } else { lsuast = ""; }
                        if (!lsurefReader.IsDBNull(14)) { lsuvst = lsurefReader.GetString(14); } else { lsuvst = ""; }
                        if (!lsurefReader.IsDBNull(15)) { lsuvdt = lsurefReader.GetInt32(15); } else { lsuvdt = 0; }

                        this.lblvouno.Text = LSUVNO;
                        this.lbldate.Text = lsuvdt.ToString().Substring(0, 4) + "/" + lsuvdt.ToString().Substring(4, 2) + "/" + lsuvdt.ToString().Substring(6, 2);
                        this.lblfullbons.Text = String.Format("{0:N}", LSUBON);
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
                                "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT " +
                                " from CASHBOOK.TEMP_CB where vouno = '" + LSUVNO + "' and AUTHORIZED = 0 ";

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
                                temp_cbReader.Close();
                                temp_cbReader.Dispose();

                                //this.lblbkbranch.Text = HNAME;
                                this.lblamtinfigures.Text = String.Format("{0:N}", (double)TOTAMOUNT);

                                if (TOTAMOUNT > 0)
                                {
                                    double LSUNET100 = (Math.Round(TOTAMOUNT, 2) * 100);
                                    string surrvalinwords = LSUNET100.ToString().Substring(0, (LSUNET100.ToString().Length - 2)) + "." + LSUNET100.ToString().Substring((LSUNET100.ToString().Length - 2), 2);
                                    readAmountFunction readamt = new readAmountFunction();
                                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                                }
                                else { this.lblamtinwords.Text = ""; }

                                this.lblacctno.Text = ACNO;
                                this.lblassuredname.Text = INSNAME;
                                this.lblnameofpayee.Text = HNAME1;
                                this.lblad1.Text = ADD1;
                                this.lblad2.Text = ADD2;
                                this.lblad3.Text = ADD3;
                            }
                            else { dm.connclose(); throw new Exception("No Voucher Details Availbale or Voucher Already Authorized!"); }

                            //if ((AUTHLMT != null) && (!AUTHLMT.Equals("")))
                            //{
                            //    try
                            //    {
                            //        AUTHLMTdbl = double.Parse(AUTHLMT);
                            //    }
                            //    catch (Exception exp) { dm.connclose(); throw new Exception("Auth Limit is not Numeric" + exp); }
                            //}

                            if (TOTAMOUNT > AUTHLMT) { dm.connclose(); throw new Exception("Exceeds Voucher Authorization Limit"); }

                            #endregion

                            #region //--------------- voubankdet select -------------------------------------

                            string SLIACCTNO = "";

                            string voubankdetSel = "select PAYEENAME, BNKNAME, BNKBRNNAME, SLIACCTNO from LPHS.VOUBANKDET where POLICYNO = " + polno + " and VOUCHERNO = '" + LSUVNO + "' ";
                            if (dm.existRecored(voubankdetSel) != 0)
                            {
                                dm.readSql(voubankdetSel);
                                OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while (voubankdetReader.Read())
                                {
                                    if (!voubankdetReader.IsDBNull(1)) { BNKNAME = voubankdetReader.GetString(1); } else { BNKNAME = ""; }
                                    if (!voubankdetReader.IsDBNull(2)) { BNKBRNNAME = voubankdetReader.GetString(2); } else { BNKBRNNAME = ""; }
                                    if (!voubankdetReader.IsDBNull(3)) { SLIACCTNO = voubankdetReader.GetString(3); } else { SLIACCTNO = ""; }
                                }
                                voubankdetReader.Close();
                                voubankdetReader.Dispose();
                            }

                            this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;

                            #endregion
                        }
                        else { dm.connclose(); throw new Exception(" No Authority  Given for  Voucher Authorization"); }

                        #endregion
                    }
                    lsurefReader.Close();
                    lsurefReader.Dispose();

                    if (count > 1) { dm.connclose(); throw new Exception("2 Vouchers for this Policy Please Contact IT Division."); }
                    if (!lsuast.Equals("Y")) { dm.connclose(); throw new Exception("Request not yet Authgorized!"); }
                    if (!lsuvst.Equals("Y")) { dm.connclose(); throw new Exception("Voucher not yet Created!"); }
                }
                else
                {
                    dm.connclose(); 
                    throw new Exception("No Appropriate Loan Reference Record!");
                }

                #endregion

                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["LSUVNO"] = LSUVNO;
                ViewState["epf"] = epf;
    
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
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["LSUVNO"] != null) { LSUVNO = ViewState["LSUVNO"].ToString(); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try 
        {           
            string authSelect = "select * from CASHBOOK.TEMP_CB where vouno = '" + LSUVNO + "' and AUTHORIZED = 0 ";
            if (dm.existRecored(authSelect) != 0)
            {
                string authoizeUpdate = "UPDATE cashbook.TEMP_CB set status = 'Authorized', AUTHORIZED = 1, "+
                    " AUODATE = to_date('" + this.setDate()[0] + "', 'yyyymmdd'), AUTHOEPF='" + epf + "'  where Vouno = '" + LSUVNO + "' ";
                dm.insertRecords(authoizeUpdate);

                this.lblsuccess.Visible = true;
                this.btnok.Enabled = false;
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
}
