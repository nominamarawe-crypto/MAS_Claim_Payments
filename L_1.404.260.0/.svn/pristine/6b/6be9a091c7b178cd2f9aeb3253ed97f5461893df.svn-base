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

public partial class vouDetEdit002 : System.Web.UI.Page
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

    private string HNAME = "";
    private string HNAME1 = "";
    private string ACNO = "";
    private string ADD1 = "";
    private string ADD2 = "";
    private string ADD3 = "";
    private string INSNAME = "";
    private string RECIPIENT_NAME = "";
    private double TOTAMOUNT;
    private string custacct = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //{
        //    polno = this.PreviousPage.Polno;
        //}

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
            try
            {
                this.ddlslicacctno.Items.Add(new ListItem("1030001487", "1030001487"));
                this.ddlslicacctno.Items.Add(new ListItem("1364403002", "1364403002"));

                dm = new DataManager();

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

                //if (Session["epfnum"] != null) { }
                    //epf = Session["epfnum"].ToString(); 

                this.lblpolno.Text = polno.ToString();

                string lsuast = "";
                string lsuvst = "";
                int count = 0;

                string lsurefSelect = "select LSUVNO, lsuast, lsuvst from LPHS.LSUREF where lsupol = " + polno + " and lsutyp = 'S' and lsuast = 'Y' and lsuvst = 'Y' ";
                if (dm.existRecored(lsurefSelect) != 0)
                {
                    dm.readSql(lsurefSelect);
                    OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lsurefReader.Read())
                    {
                        count++;

                        //if (!lsurefReader.IsDBNull(0)) { LSUVNO = lsurefReader.GetString(0); } else { LSUVNO = ""; }
                        if (!lsurefReader.IsDBNull(1)) { lsuast = lsurefReader.GetString(1); } else { lsuast = ""; }
                        if (!lsurefReader.IsDBNull(2)) { lsuvst = lsurefReader.GetString(2); } else { lsuvst = ""; }

                        #region //--------------- temp_cb select -------------------------------------

                        string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                           " INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT " +
                           " from CASHBOOK.TEMP_CB where vouno = '" + LSUVNO + "' ";

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

                            this.lblphname.Text = INSNAME;
                            this.lblnetamt.Text = String.Format("{0:N}", TOTAMOUNT);
                            this.txtpayeename.Text = HNAME1;
                            this.txtad1.Text = ADD1;
                            this.txtad2.Text = ADD2;
                            this.txtad3.Text = ADD3;
                        }
                        else { dm.connclose(); throw new Exception("No Voucher Details Availbale or Voucher Not yet Printed!"); }

                        #endregion

                        #region //--------------- voubankdet select -------------------------------------

                        string BNKNAME = "", BNKBRNNAME = "", SLIACCTNO = "";

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
                                if (!voubankdetReader.IsDBNull(4)) { custacct = voubankdetReader.GetString(4); } else { custacct = ""; }
                            }
                            voubankdetReader.Close();
                            voubankdetReader.Dispose();
                        }

                        this.txtbkname.Text = BNKNAME;
                        this.txtbkbrnname.Text = BNKBRNNAME;
                        this.txtcustAcct.Text = custacct;

                        if (SLIACCTNO.Equals("1030001487")) { this.ddlslicacctno.SelectedIndex = 0; }
                        if (SLIACCTNO.Equals("1364403002")) { this.ddlslicacctno.SelectedIndex = 1; }

                        #endregion

                    }
                    lsurefReader.Close();
                    lsurefReader.Dispose();

                    if (count > 1) { dm.connclose(); throw new Exception("2 Vouchers for this Policy Please Contact IT Division."); }
                    if (!lsuast.Equals("Y")) { dm.connclose(); throw new Exception("Request not yet Authgorized!"); }
                    if (!lsuvst.Equals("Y")) { dm.connclose(); throw new Exception("Voucher not yet Created!"); }
                }
                else { dm.connclose(); throw new Exception("No Appropriate Loan Reference Record!"); }

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
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            dm.begintransaction();
            string NAMEPAYEE1 = this.txtpayeename.Text.ToString();
            string BKNAM = this.txtbkname.Text;
            string BKBRN = this.txtbkbrnname.Text;
            string ADD1 = this.txtad1.Text.ToString().Trim();
            string ADD2 = this.txtad2.Text.ToString().Trim();
            string ADD3 = this.txtad3.Text.ToString().Trim();
            string ACNUM = this.ddlslicacctno.SelectedItem.Value.ToString();
            string hname = BKNAM + " " + BKBRN + " " + ACNUM;

            #region //------------ TEMP_CB update ------------
            string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + LSUVNO + "' ";
            if (dm.existRecored(tempCB_select) != 0)
            {
                string TEMP_CBupdate = "update CASHBOOK.TEMP_CB set hname = '" + hname + "', hname1 = '" + NAMEPAYEE1 + "', add1 = '" + ADD1 + "', "+
                    " add2 = '" + ADD2 + "',add3 = '" + ADD3 + "'  where vouno = '" + LSUVNO + "' ";
                dm.insertRecords(TEMP_CBupdate);
            }
            else { dm.connclose(); throw new Exception("No Record to Update in TEMP_CB"); }

            #endregion

            #region //------------ VOUBANKDET update ----------
            string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + LSUVNO + "' ";
            if (dm.existRecored(voubankdetSelect) != 0)
            {
                string voubankdetUpdate = "update LPHS.VOUBANKDET set PAYEENAME = '" + NAMEPAYEE1 + "' , BNKNAME = '" + BKNAM + "' , BNKBRNNAME = '" + BKBRN + "' , "+
                    " SLIACCTNO = '" + ACNUM + "' where POLICYNO =" + polno + " and VOUCHERNO =  '" + LSUVNO + "' ";
                dm.insertRecords(voubankdetUpdate);
            }
            else { dm.connclose(); throw new Exception("No Record to Update in VOUBANKDET"); }
            #endregion

            #region //------------ VOUCHER_LOG_ENTRY insert ----------

              string VOUCHER_LOG_ENTRYinsert = "insert into cashbook.Voucher_Log_Entry(Voucher_No,Update_User,Update_Date) VALUES ('" + LSUVNO + "', '" + epf + "', to_date('" + this.setDate()[0] + "', 'yyyymmdd'))";
              dm.insertRecords(VOUCHER_LOG_ENTRYinsert);

              #endregion

            this.lblsuccess.Visible = true;

            dm.commit();
            dm.connclose();

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
