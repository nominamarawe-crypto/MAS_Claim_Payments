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

public partial class ADBPaymemtMemo002 : System.Web.UI.Page
{
    private long polNo;
    private string mos;
    private long claimNo;
    private string causeofDeath;
    private string decision;
    private double adb;
    private double adbPayAmount;
    private string minute;
    private int deductId1;
    private string deductName1;
    private double deductAmt1;
    private int deductId2;
    private string deductName2;
    private double deductAmt2;
    private string epf;
    private string ipAdd;
    private string isExgracia;
    private double amtOutstanding;
    private double adbCancelAmt;
    private int payOutsatndDate;
    private bool isCancel;
    private bool isADBLatePay;
    private string isCompleted;
    private string isADBReopen;

    DataManager dm;
    User_Authentication objUserAuthentication;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
            ipAdd = Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        if (!Page.IsPostBack)
        {
            try
            {
                dm = new DataManager();
                objUserAuthentication = new User_Authentication();

                if (Request.QueryString["polino"] != null)
                {
                    ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polino"]));
                    polNo = int.Parse(Request.QueryString["polino"]);
                }
                if (Request.QueryString["mos"] != null)
                {
                    ViewState.Add("mosQstr", Request.QueryString["mos"].ToString());
                    mos = Request.QueryString["mos"].ToString();
                }
                if (Request.QueryString["isCancel"] != null)
                {
                    ViewState.Add("isCancelQstr", Request.QueryString["isCancel"].ToString());
                    isCancel = bool.Parse(Request.QueryString["isCancel"]);
                }

                #region -------------- Death Ref Select -----------------
                string dthrefSelect = "select DRCLMNO, CAUSEOFDEATHSTR, DDECISION, DRACCBF, ADBPAYAMT, MINUTES, AMTOUT, PAYAUTDT, COMPLETED " +
                                      "from LPHS.DTHREF where drpolno=" + polNo + " and drmos='" + mos + "' and adb_latepay='Y'";

                if (dm.existRecored(dthrefSelect) != 0)
                {
                    dm.readSql(dthrefSelect);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader();
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { claimNo = dthrefReader.GetInt64(0); } else { claimNo = 0; }
                        if (!dthrefReader.IsDBNull(1)) { causeofDeath = dthrefReader.GetString(1); } else { causeofDeath = ""; }
                        if (!dthrefReader.IsDBNull(2)) { decision = dthrefReader.GetString(2); } else { decision = ""; }
                        if (!dthrefReader.IsDBNull(3)) { adb = dthrefReader.GetDouble(3); } else { adb = 0.0; }
                        if (!dthrefReader.IsDBNull(4)) { adbPayAmount = dthrefReader.GetDouble(4); } else { adbPayAmount = 0.0; }
                        if (!dthrefReader.IsDBNull(5)) { minute = dthrefReader.GetString(5); } else { minute = ""; }
                        if (!dthrefReader.IsDBNull(6)) { amtOutstanding = dthrefReader.GetDouble(6); } else { amtOutstanding = 0.0; }
                        if (!dthrefReader.IsDBNull(7)) { payOutsatndDate = dthrefReader.GetInt32(7); } else { payOutsatndDate = 0; }
                        if (!dthrefReader.IsDBNull(8)) { isCompleted = dthrefReader.GetString(8); } else { isCompleted = ""; }
                    }

                    dthrefReader.Close();
                    dthrefReader.Dispose();

                    isADBLatePay = true;
                }
                #endregion 

                if ((amtOutstanding <= 0 && !isADBLatePay) && !isCancel)
                {
                    dm.connclose();
                    throw new Exception("No Part Payments for this Policy!");
                }

                if ((payOutsatndDate == 0 || isADBLatePay) || isCancel)
                {
                    this.lblpolno.Text = polNo.ToString();
                    this.lblClaimNo.Text = claimNo.ToString();

                    if (mos.Equals("M")) { this.lbllifetype.Text = "Main Life"; }
                    else if (mos.Equals("S")) { this.lbllifetype.Text = "Spouce"; }
                    else if (mos.Equals("2")) { this.lbllifetype.Text = "Second Life"; }
                    else if (mos.Equals("C")) { this.lbllifetype.Text = "Child"; }
                    else { }

                    this.lblcauseOfDeath.Text = causeofDeath.ToString();
                    this.txtdecision.Text = decision.ToString();
                    this.txtADBAmt.Text = adb.ToString("N");
                    this.txtminutes.Text = minute.ToString();

                    #region --------------- ADB Payment Select --------------
                    string dthadbSelect = "select DEDUCT_ID1, DEDUCT_NAME1, DEDUCT_AMOUNT1, DEDUCT_ID2, DEDUCT_NAME2, DEDUCT_AMOUNT2, MINITES, IS_EXGRACIA, ADB_CANCEL_AMT, IS_ADB_REOPEN " +
                                          "from LPHS.DTH_ADBPAYMENTS where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";

                    if (dm.existRecored(dthadbSelect) != 0)
                    {
                        dm.readSql(dthadbSelect);
                        OracleDataReader dthadbReader = dm.oraComm.ExecuteReader();
                        while (dthadbReader.Read())
                        {
                            if (!dthadbReader.IsDBNull(0)) { deductId1 = dthadbReader.GetInt32(0); } else { deductId1 = 0; }
                            if (!dthadbReader.IsDBNull(1)) { deductName1 = dthadbReader.GetString(1); } else { deductName1 = ""; }
                            if (!dthadbReader.IsDBNull(2)) { deductAmt1 = dthadbReader.GetDouble(2); } else { deductAmt1 = 0.0; }
                            if (!dthadbReader.IsDBNull(3)) { deductId2 = dthadbReader.GetInt32(3); } else { deductId2 = 0; }
                            if (!dthadbReader.IsDBNull(4)) { deductName2 = dthadbReader.GetString(4); } else { deductName2 = ""; }
                            if (!dthadbReader.IsDBNull(5)) { deductAmt2 = dthadbReader.GetDouble(5); } else { deductAmt2 = 0.0; }
                            if (!dthadbReader.IsDBNull(6)) { minute = dthadbReader.GetString(6); } else { minute = ""; }
                            if (!dthadbReader.IsDBNull(7)) { isExgracia = dthadbReader.GetString(7); } else { isExgracia = ""; }
                            if (!dthadbReader.IsDBNull(8)) { adbCancelAmt = dthadbReader.GetDouble(8); } else { adbCancelAmt = 0.0; }
                            if (!dthadbReader.IsDBNull(9)) { isADBReopen = dthadbReader.GetString(9); } else { isADBReopen = ""; }
                        }

                        dthadbReader.Close();
                        dthadbReader.Dispose();
                    }
                    #endregion

                    if (deductName1 != null && deductName1 != "")
                    {
                        this.chkDeduct1.Checked = true;

                        this.txtOtherdeductDes1.Text = deductName1.ToString();
                        this.txtotherdeductAmt1.Text = deductAmt1.ToString("N");

                        this.txtOtherdeductDes1.Enabled = true;
                        this.txtotherdeductAmt1.Enabled = true;
                    }

                    if (deductName2 != null && deductName2 != "")
                    {
                        this.chkDeduct2.Checked = true;

                        this.txtOtherdeductDes2.Text = deductName2.ToString();
                        this.txtotherdeductAmt2.Text = deductAmt2.ToString("N");

                        this.txtOtherdeductDes2.Enabled = true;
                        this.txtotherdeductAmt2.Enabled = true;
                    }

                    if (isExgracia == "Y") { this.chkadbOnEx.Checked = true; } else { this.chkadbOnEx.Checked = false; }

                    #region ---------------- Check ADB Memo is Approved ---------------
                    string dthadbAprroveSelect = "select * from LPHS.DTH_ADBPAYMENTS " +
                                                 "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + " and IS_MEMO_APPROVE='Y'";

                    if (dm.existRecored(dthadbAprroveSelect) != 0 && isADBReopen != "Y")
                    {
                        this.btnok.Enabled = false;
                    }
                    #endregion

                    #region ---------------- Check Authority for ADB Reopen ---------------
                    if (objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC07") && isCancel)
                    {
                        this.btnReopen.Visible = true;
                        this.btnok.Visible = false;
                        this.btnSubmit.Visible = false;
                        this.btnCancel.Visible = false;
                        this.chkadbOnEx.Visible = false;
                    }
                    else
                    {
                        if (isCompleted == "Y" && isADBLatePay)
                        {
                            dm.connclose();
                            throw new Exception("ADB Payments Already Cancel!");
                        }
                        else
                        {
                            this.btnReopen.Visible = false;
                            this.btnok.Visible = true;
                            this.btnSubmit.Visible = true;
                            this.btnCancel.Visible = true;
                            this.chkadbOnEx.Visible = true;
                        }
                    }
                    #endregion

                    ViewState["claimNoQstr"] = claimNo;
                    ViewState["amtOutstanding"] = amtOutstanding;
                    ViewState["adbCancelAmt"] = adbCancelAmt;
                    dm.connClose();
                }
                else
                {
                    dm.connclose();
                    throw new Exception("Payments Already Completed!");
                }
            }
            catch (Exception Ex)
            {
                dm.connclose();
                dm.oraConn.Dispose();
                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polNo = Convert.ToInt64(ViewState["polnoQstr"].ToString()); }
            if (ViewState["mosQstr"] != null) { mos = (string)ViewState["mosQstr"]; }
            if (ViewState["claimNoQstr"] != null) { claimNo = Convert.ToInt64(ViewState["claimNoQstr"].ToString()); }
            if (ViewState["amtOutstanding"] != null) { amtOutstanding = Convert.ToDouble(ViewState["amtOutstanding"].ToString()); }
            if (ViewState["adbCancelAmt"] != null) { adbCancelAmt = Convert.ToDouble(ViewState["adbCancelAmt"].ToString()); }
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            adb = this.txtADBAmt.Text != null ? double.Parse(this.txtADBAmt.Text) : 0.0;
            
            deductName1 = this.txtOtherdeductDes1.Text != null && this.chkDeduct1.Checked != false ? this.txtOtherdeductDes1.Text : "";
            deductId1 = this.txtOtherdeductDes1.Text != null && this.txtOtherdeductDes1.Text != "" && this.chkDeduct1.Checked != false ? 1 : 0;
            deductAmt1 = this.txtotherdeductAmt1.Text != null && this.txtotherdeductAmt1.Text != "" && this.chkDeduct1.Checked != false ? double.Parse(this.txtotherdeductAmt1.Text) : 0.0;

            deductName2 = this.txtOtherdeductDes2.Text != null && this.chkDeduct2.Checked != false ? this.txtOtherdeductDes2.Text : "";
            deductId2 = this.txtOtherdeductDes2.Text != null && this.txtOtherdeductDes2.Text != "" && this.chkDeduct2.Checked != false ? 2 : 0;
            deductAmt2 = this.txtotherdeductAmt2.Text != null && this.txtotherdeductAmt2.Text != "" && this.chkDeduct1.Checked != false ? double.Parse(this.txtotherdeductAmt2.Text) : 0.0;

            minute = this.txtminutes.Text != null ? this.txtminutes.Text : "";

            adbPayAmount = adb - (deductAmt1 + deductAmt2);

            isExgracia = this.chkadbOnEx.Checked != false ? "Y" : "N";

            string adbPaymentSelect = "select * from LPHS.DTH_ADBPAYMENTS where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";

            if (dm.existRecored(adbPaymentSelect) == 0)
            {
                string adbPaymentInsert = "insert into LPHS.DTH_ADBPAYMENTS (POLICY_NO, MOS, CLAIM_NO, ADB_AMOUNT, ADB_PAYAMOUNT, " +
                                        "DEDUCT_ID1, DEDUCT_NAME1, DEDUCT_AMOUNT1, DEDUCT_ID2, DEDUCT_NAME2, DEDUCT_AMOUNT2, " +
                                        "MINITES, MEMO_CREATED_DATE, MEMO_CREATED_EPF, MEMO_CREATED_IP, IS_MEMO_APPROVE, IS_EXGRACIA) " +
                                        "values (" + polNo + ",'" + mos + "'," + claimNo + "," + adb + "," + adbPayAmount + "," + deductId1 + "," +
                                        "'" + deductName1 + "'," + deductAmt1 + "," + deductId2 + ",'" + deductName2 + "'," + deductAmt2 + "," +
                                        "'" + minute + "',sysdate,'" + epf + "','" + ipAdd + "','N', '" + isExgracia + "')";
                dm.insertRecords(adbPaymentInsert);
            }
            else
            {
                string adbPaymentsUpdate = "update LPHS.DTH_ADBPAYMENTS set ADB_AMOUNT=" + adb + ", ADB_PAYAMOUNT=" + adbPayAmount + ", DEDUCT_ID1=" + deductId1 + ", " +
                                           "DEDUCT_NAME1='" + deductName1 + "', DEDUCT_AMOUNT1=" + deductAmt1 + ", DEDUCT_ID2=" + deductId2 + ", " +
                                           "DEDUCT_NAME2='" + deductName2 + "', DEDUCT_AMOUNT2=" + deductAmt2 + ", MINITES='" + minute + "', " +
                                           "MEMO_CREATED_DATE=sysdate, MEMO_CREATED_EPF='" + epf + "', MEMO_CREATED_IP='" + ipAdd + "', IS_MEMO_APPROVE='N', IS_EXGRACIA='" + isExgracia + "' " +
                                           "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";
                dm.insertRecords(adbPaymentsUpdate);
            }

            if (isExgracia == "Y")
            {
                string exgraciaSelect = "select dpolnum from lphs.exgracia_amts where dpolnum = " + polNo + " and mof ='" + mos + "' ";
                if (dm.existRecored(exgraciaSelect) != 0)
                {
                    string exgraciaUpdate = "UPDATE LPHS.EXGRACIA_AMTS SET ADBONEX = " + adbPayAmount + " WHERE DPOLNUM = " + polNo + " and MOF = '" + mos + "' ";
                    dm.insertRecords(exgraciaUpdate);
                }
                else
                {
                    string exgraciaInsert = "INSERT INTO LPHS.EXGRACIA_AMTS (DPOLNUM ,MOF ,SUMONEX ,ADBONEX ,FPUONEX ,FEONEX ,SJONEX ,OTHERADDONEX ,REFOFPRMONEX )" +
                        " VALUES (" + polNo + " ,'" + mos + "' , 0," + adbPayAmount + " , 0 , 0, 0, 0, 0)";
                    dm.insertRecords(exgraciaInsert);
                }
            }
            else
            {
                string exgraciaSelect = "select dpolnum from lphs.exgracia_amts where dpolnum = " + polNo + " and mof ='" + mos + "' ";

                if (dm.existRecored(exgraciaSelect) != 0)
                {
                    string exgraciaUpdate = "UPDATE LPHS.EXGRACIA_AMTS SET ADBONEX = 0 WHERE DPOLNUM = " + polNo + " and MOF = '" + mos + "' ";
                    dm.insertRecords(exgraciaUpdate);
                }
            }

            this.lblsuccess.Text = "Record Updated Successfully";
            this.lblsuccess.Visible = true;
            this.btnok.Enabled = false;

            dm.commit();
            dm.connclose();
            dm.oraConn.Dispose();
        }
        catch (Exception Ex)
        {
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ADBApproveMemo002.aspx?polino=" + polNo + "&mos=" + mos + "&claim_no=" + claimNo + "");
    } 
     
    protected void chkDeduct1_CheckedChanged(object sender, EventArgs e)
    {
        txtOtherdeductDes1.Enabled = true;
        txtotherdeductAmt1.Enabled = true;
    }

    protected void chkDeduct2_CheckedChanged(object sender, EventArgs e)
    {
        txtOtherdeductDes2.Enabled = true;
        txtotherdeductAmt2.Enabled = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            string dthRefSelect = "select * from lphs.dthref where DRPOLNO = " + polNo + " and DRMOS = '" + mos + "'";

            if (dm.existRecored(dthRefSelect) != 0)
            {
                string dthrefUpdate = "update lphs.dthref set amtout = 0, completed= 'Y', payautdt = " + int.Parse(this.setDate()[0]) + ", payautepf = '" + epf + "' where DRPOLNO = " + polNo + " and DRMOS = '" + mos + "' ";
                dm.insertRecords(dthrefUpdate);
            }

            string adbPaymentSelect = "select * from LPHS.DTH_ADBPAYMENTS where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";

            if (dm.existRecored(adbPaymentSelect) == 0)
            {
                string adbPaymentInsert = "insert into LPHS.DTH_ADBPAYMENTS (POLICY_NO, MOS, CLAIM_NO, ADB_AMOUNT, ADB_PAYAMOUNT, " +
                                        "IS_ADB_CANCEL, ADB_CANCEL_AMT, ADB_CANCEL_DATE, ADB_CANCEL_EPF, ADB_CANCEL_IP) " +
                                        "values (" + polNo + ",'" + mos + "'," + claimNo + "," + adb + "," + adbPayAmount + "," +
                                        "'Y', " + amtOutstanding + ", sysdate,'" + epf + "','" + ipAdd + "')";
                dm.insertRecords(adbPaymentInsert);
            }
            else
            {
                string adbPaymentsUpdate = "update LPHS.DTH_ADBPAYMENTS set IS_ADB_CANCEL='Y', ADB_CANCEL_AMT=" + amtOutstanding + ", IS_ADB_REOPEN='N', ADB_CANCEL_DATE=sysdate, ADB_CANCEL_EPF='" + epf + "', ADB_CANCEL_IP='" + ipAdd + "' " +
                                           "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";
                dm.insertRecords(adbPaymentsUpdate);
            }

            this.lblsuccess.Text = "ADB Payment Successfully Cancel!";
            this.lblsuccess.Visible = true;
            this.btnok.Enabled = false;
            this.btnSubmit.Enabled = false;
            this.btnCancel.Enabled = false;

            dm.commit();
            dm.connclose();
            dm.oraConn.Dispose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            #region ----------------- Update ADB -----------------
            string adbPaymentSelect = "select * from LPHS.DTH_ADBPAYMENTS where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";

            if (dm.existRecored(adbPaymentSelect) != 0)
            {
                string adbPaymentsUpdate = "update LPHS.DTH_ADBPAYMENTS set IS_ADB_CANCEL='N', IS_ADB_REOPEN='Y', ADB_REOPEN_DATE=sysdate, ADB_REOPEN_EPF='" + epf + "', ADB_REOPEN_IP='" + ipAdd + "' " +
                                           "where policy_no=" + polNo + " and mos='" + mos + "' and claim_no=" + claimNo + "";
                dm.insertRecords(adbPaymentsUpdate);
            }
            else
            {
                string adbPaymentInsert = "insert into LPHS.DTH_ADBPAYMENTS (POLICY_NO, MOS, CLAIM_NO, ADB_AMOUNT, ADB_PAYAMOUNT, " +
                                        "IS_ADB_CANCEL, ADB_CANCEL_AMT, IS_ADB_REOPEN, ADB_REOPEN_DATE, ADB_REOPEN_EPF, ADB_REOPEN_IP) " +
                                        "values (" + polNo + ",'" + mos + "'," + claimNo + "," + adb + "," + adbPayAmount + "," +
                                        "'N', " + amtOutstanding + ", 'Y', sysdate,'" + epf + "','" + ipAdd + "')";
                dm.insertRecords(adbPaymentInsert);
            }
            #endregion

            #region ----------------- Update Death Ref -----------------
            string dthRefSelect = "select * from lphs.dthref where DRPOLNO = " + polNo + " and DRMOS = '" + mos + "'";

            if (dm.existRecored(dthRefSelect) != 0)
            {
                string dthrefUpdate = "update lphs.dthref set amtout = "+adbCancelAmt+", completed= '', payautdt = '', payautepf = '' where DRPOLNO = " + polNo + " and DRMOS = '" + mos + "' ";
                dm.insertRecords(dthrefUpdate); 
            }
            #endregion

            this.lblsuccess.Text = "ADB Payment Successfully Re-open!";
            this.lblsuccess.Visible = true;
            this.btnReopen.Enabled = false;

            dm.commit();
            dm.connclose();
            dm.oraConn.Dispose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }

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
}
