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

public partial class cvouDetEdit002 : System.Web.UI.Page
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
    private string payee = "";
    private double amtOut;
    private long claimno;

    private string vouno = "";
    private int voudate;
    private double share;

    DataManager dm;

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
        //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //{
        //    polno = this.PreviousPage.Polno;
        //}
        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }
        //epf = Session["EPFNum"].ToString();

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

                ViewState.Add("polnoQstr", polno.ToString());
                ViewState.Add("MOSQstr", MOS);
                ViewState.Add("vounoQstr", vouno);
                ViewState.Add("payeeQstr", payee);
                ViewState.Add("shareQstr", share.ToString());
                ViewState.Add("clmno", claimno.ToString());

                this.ddlslicacctno.Items.Add(new ListItem("1030001487", "1030001487"));
                this.ddlslicacctno.Items.Add(new ListItem("1364403002", "1364403002"));

                this.lblpolno.Text = polno.ToString();
                //if (MOS.Equals("M")) { this.lblmos.Text = "Main Life"; }
                //else if (MOS.Equals("S")) { this.lblmos.Text = "Second Life"; }
                //else if (MOS.Equals("2")) { this.lblmos.Text = "Spouce"; }
                //this.lblclaimno.Text = claimno.ToString();

                #region //--------------- temp_cb select -------------------------------------

                string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                    "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd')) " +
                    " from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";

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
                    temp_cbReader.Dispose();

                    this.lblphname.Text = INSNAME;
                    this.txtnetClmAmt.Text = String.Format("{0:N}", TOTAMOUNT);
                    this.txtpayeename.Text = HNAME1;
                    this.txtad1.Text = ADD1;
                    this.txtad2.Text = ADD2;
                   
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
                    OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader();
                    while (voubankdetReader.Read())
                    {
                        if (!voubankdetReader.IsDBNull(1)) { BNKNAME = voubankdetReader.GetString(1); } else { BNKNAME = ""; }
                        if (!voubankdetReader.IsDBNull(2)) { BNKBRNNAME = voubankdetReader.GetString(2); } else { BNKBRNNAME = ""; }
                        if (!voubankdetReader.IsDBNull(3)) { SLIACCTNO = voubankdetReader.GetString(3); } else { SLIACCTNO = ""; }
                        if (!voubankdetReader.IsDBNull(4)) { CUSTACCTNO = voubankdetReader.GetString(4); } else { CUSTACCTNO = ""; }
                    }
                    voubankdetReader.Close();
                    voubankdetReader.Dispose();

                    this.txtbkname.Text = BNKNAME;
                    this.txtbkbrnname.Text = BNKBRNNAME;
                    this.txtcustAcct.Text = CUSTACCTNO;

                    if (SLIACCTNO.Equals("1030001487")) { this.ddlslicacctno.SelectedIndex = 0; }
                    if (SLIACCTNO.Equals("1364403002")) { this.ddlslicacctno.SelectedIndex = 1; }
                }
                else
                {
                    BNKNAME = "";
                    BNKBRNNAME = "";
                    SLIACCTNO = "";
                    CUSTACCTNO = "";
                }

                #endregion

                //-------------

                ViewState["amtOut"] = amtOut;

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
                dm.oraConn.Dispose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
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

            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }

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
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            dm.begintransaction();
            dm.begintransaction();
            string NAMEPAYEE1 = this.txtpayeename.Text.ToString();
            string BKNAM = this.txtbkname.Text;
            string BKBRN = this.txtbkbrnname.Text;
            string ADD1 = this.txtad1.Text.ToString().Trim();
            string ADD2 = this.txtad2.Text.ToString().Trim();
         
            string ACNUM = this.ddlslicacctno.SelectedItem.Value.ToString();
            CUSTACCTNO = this.txtcustAcct.Text;
            string hname = BKNAM + " " + BKBRN + " " + CUSTACCTNO;

            #region //------------ TEMP_CB update -------------
            string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";
            if (dm.existRecored(tempCB_select) != 0)
            {
                string TEMP_CBupdate = "update CASHBOOK.TEMP_CB set hname = '" + hname + "', hname1 = '" + NAMEPAYEE1 + "', add1 = '" + ADD1 + "', " +
                    " add2 = '" + ADD2 + "',add3 = '" + ADD3 + "'  where vouno = '" + vouno + "' ";
                dm.insertRecords(TEMP_CBupdate);
            }
            else
            {
                dm.connclose();
                dm.oraConn.Dispose();
                throw new Exception("No Record to Update in TEMP_CB");
            }

            #endregion

            #region //------------ VOUBANKDET update ----------
            string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
            if (dm.existRecored(voubankdetSelect) != 0)
            {
                string voubankdetUpdate = "update LPHS.VOUBANKDET set PAYEENAME = '" + NAMEPAYEE1 + "' , BNKNAME = '" + BKNAM + "' , BNKBRNNAME = '" + BKBRN + "' , " +
                    " SLIACCTNO = '" + ACNUM + "', CUSTACCTNO = '" + CUSTACCTNO + "' where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
                dm.insertRecords(voubankdetUpdate);
            }
            else
            {
                dm.connclose();
                dm.oraConn.Dispose();
                throw new Exception("No Record to Update in VOUBANKDET");
            }
            #endregion

            #region //------------ VOUCHER_LOG_ENTRY insert ----------

            string VOUCHER_LOG_ENTRYinsert = "insert into cashbook.Voucher_Log_Entry(Voucher_No,Update_User,Update_Date) VALUES ('" + vouno + "', '" + epf + "', to_date('" + this.setDate()[0] + "', 'yyyymmdd'))";
            dm.insertRecords(VOUCHER_LOG_ENTRYinsert);

            #endregion

            this.lblsuccess.Visible = true;

            dm.commit();
            dm.connclose();
            dm.oraConn.Dispose();

        }
        catch (Exception ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
    protected void btnexit_Click(object sender, EventArgs e)
    {

    }
}
