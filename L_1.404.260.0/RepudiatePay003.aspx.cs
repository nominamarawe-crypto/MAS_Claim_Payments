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

//Last Updated By buddhika 2009/07/30
//Last Updated By Dushan 16/10/2009
public partial class RepudiatePay003 : System.Web.UI.Page
{    
    private long polno;
    private int claimno;
    private int com;
    private int dtofdth;
    private string mos, heading;
    private int table, branch;
    private int term;
    private string polstatus;
    private string polstatStr;
    private double exgracia;
    private double clmamt;
    private double bonus;
    private double otheradds;
    private double defprem;
    private double defpremint;
    private double loan;
    private double loanint;
    private double amtcompolyr;
    private double otherdeduct;
    private double netclm;
    private double outamt;
    private string EPF="";
    private string memeaprv = "";
    private double deposit;
    private string isFuturePayment;

    private string payee;
    DataManager dm;
    lpolhisread lpolobj;
    dthOutClms dtofdthobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        //EPF = Session["EPFNum"].ToString();

       
        try
        {
            if (Session["EPFNum"] != null || Session["brcode"] != null)
            {
                EPF = Session["EPFNum"].ToString();
                branch = Convert.ToInt32(Session["brcode"]);
            }
            else
            {
                throw new Exception("Your Session Variable Expired Please Log on to the System!");
            }


            dm = new DataManager();
            if (!Page.IsPostBack)
            {
                if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
                {
                    polno = this.PreviousPage.Polno;
                    mos = this.PreviousPage.Mos;
                    claimno = this.PreviousPage.Clmno;
                    table = this.PreviousPage.Table;
                    term = this.PreviousPage.Term;
                    polstatus = this.PreviousPage.Status;
                    if (polstatus.Equals("I")) { polstatStr = "Inforce"; }
                    else if (polstatus.Equals("L")) { polstatStr = "Lapse"; }
                    com = this.PreviousPage.Com;
                    dtofdth = this.PreviousPage.Dtofdth;
                    //deposit = this.PreviousPage.Deposit;
                    //EPF = this.PreviousPage.EPF;
                }
                if(polno==0)
                {
                    if (Request.QueryString["polno"] != null) { polno = long.Parse(Request.QueryString["polno"].ToString()); }
                    if (Request.QueryString["mos"] != null) { mos = Request.QueryString["mos"]; }
                    if (Request.QueryString["clmno"] != null) { claimno = int.Parse(Request.QueryString["clmno"].ToString()); }
                    lpolobj = new lpolhisread(polno);
                    table = lpolobj.Table;
                    term = lpolobj.Term;
                    polstatus = lpolobj.Status;
                    com = lpolobj.Commence;
                    dtofdthobj = new dthOutClms(polno, mos, long.Parse(claimno.ToString()), 0, 0, 0, 0, "", 0);
                    dtofdth = dtofdthobj.Dtofdth;
                    if (polstatus.Equals("I")) { polstatStr = "Inforce"; }
                    else if (polstatus.Equals("L")) { polstatStr = "Lapse"; }
                }
            }
            if (!Page.IsPostBack)
            {
                payee = "";

                string repudiatesel = "select POLICYNO, REPUOK from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='" + mos + "'";
                if (dm.existRecored(repudiatesel) == 0)
                {
                    throw new Exception("No Repudiated Policy Details Found!");
                }

                #region----------------------Dthref------------------------
                string dthrefsel = "select EXGRACIA_AMOUNT, DRDEPOSITS, DRVESTEDBON, DROTHERADITNS, DRDEFPREM, DRINT, DRLONCAP, DRLOANINT, AMT_TO_COMPLETE, DEOTHERDEDUCT, DRNETCLM,"+
                    " AMTOUT, MEMOAPRV, PAYEE, DRDEPOSITS, IS_FUTUER_PAYMENT from LPHS.DTHREF where DRPOLNO=" + polno + "";
                if (dm.existRecored(dthrefsel) != 0)
                {
                    dm.readSql(dthrefsel);
                    OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                    while (dthrefreader.Read())
                    {
                        if (!dthrefreader.IsDBNull(0)) { exgracia = dthrefreader.GetDouble(0); } else { exgracia = 0; }
                        if (!dthrefreader.IsDBNull(1)) { deposit = dthrefreader.GetDouble(1); } else { deposit = 0; }
                        if (!dthrefreader.IsDBNull(2)) { bonus = dthrefreader.GetDouble(2); } else { bonus = 0; }
                        if (!dthrefreader.IsDBNull(3)) { otheradds = dthrefreader.GetDouble(3); } else { otheradds = 0; }
                        if (!dthrefreader.IsDBNull(4)) { defprem = dthrefreader.GetDouble(4); } else { defprem = 0; }
                        if (!dthrefreader.IsDBNull(5)) { defpremint = dthrefreader.GetDouble(5); } else { defpremint = 0; }
                        if (!dthrefreader.IsDBNull(6)) { loan = dthrefreader.GetDouble(6); } else { loan = 0; }
                        if (!dthrefreader.IsDBNull(7)) { loanint = dthrefreader.GetDouble(7); } else { loanint = 0; }
                        if (!dthrefreader.IsDBNull(8)) { amtcompolyr = dthrefreader.GetDouble(8); } else { amtcompolyr = 0; }
                        if (!dthrefreader.IsDBNull(9)) { otherdeduct = dthrefreader.GetDouble(9); } else { otherdeduct = 0; }
                        if (!dthrefreader.IsDBNull(10)) { netclm = dthrefreader.GetDouble(10); } else { netclm = 0; }
                        if (!dthrefreader.IsDBNull(11)) { outamt = dthrefreader.GetDouble(11); } else { outamt = 0; }
                        if (!dthrefreader.IsDBNull(12)) { memeaprv = dthrefreader.GetString(12); } else { memeaprv = ""; }
                        if (!dthrefreader.IsDBNull(13)) { payee = dthrefreader.GetString(13); } else { payee = ""; }
                        //if (!dthrefreader.IsDBNull(14)) { deposit = dthrefreader.GetDouble(14); } else { deposit = 0; }
                        if (!dthrefreader.IsDBNull(15)) { isFuturePayment = dthrefreader.GetString(15); } else { isFuturePayment = "-1"; }
                    }
                    dthrefreader.Close();
                    //dthrefreader.Dispose();

                    if (exgracia > 0) { lblHeading.Text = "Exgracia Payment for Repudiated Death Claims"; }
                    else { lblHeading.Text = "Deposit Refund for Repudiated Death Claims"; }

                    this.ddlFuturePay.SelectedValue = isFuturePayment;
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Death Claims Processed for this Policy");
                }
                #endregion

                #region---------------------Viewstate----------------------
                ViewState["polno"] = polno;
                ViewState["mos"] = mos;
                ViewState["clmno"] = claimno;
                ViewState["table"] = table;
                ViewState["term"] = term;
                ViewState["polstatus"] = polstatus;
                ViewState["com"] = com;
                ViewState["dtofdth"] = dtofdth;
                ViewState["exgracia"] = exgracia;
                ViewState["clmamt"] = clmamt;
                ViewState["bonus"] = bonus;
                ViewState["otheradds"] = otheradds;
                ViewState["defprem"] = defprem;
                ViewState["defpremint"] = defpremint;
                ViewState["loan"] = loan;
                ViewState["loanint"] = loanint;
                ViewState["amtcompolyr"] = amtcompolyr;
                ViewState["otherdeduct"] = otherdeduct;
                ViewState["netclm"] = netclm;
                ViewState["outamt"] = outamt;
                ViewState["payee"] = payee;
                ViewState["deposit"] = deposit;
                ViewState["isFuturePayment"] = isFuturePayment;

                #endregion

                #region //************** finantial limit check ******************************************

                //long financialLimit = 0;
                string EPF1 = Convert.ToString(dm.EpfCode(EPF));
                string accssctrlSel = "select FINANTIAL_LIMIT from lphs.DTH_ACCESS_CTRL where epf = '" + EPF1.Trim() + "' and SYSTEM_ID = 'DTH' and FINANTIAL_LIMIT >= " + netclm + " ";
                if (dm.existRecored(accssctrlSel) == 0)
                {
                    //throw new Exception("This Claim Amount Exceeds Your Finantial Limit to Authorize");
                    if (this.btnAccept.Visible) { this.btnAccept.Enabled = false; }
                    this.Label1.Visible = true;
                }
                else { this.Label1.Visible = false; }

                #endregion
            }
            else
            {
                #region--------------------Viewstate-Else------------------
                if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
                if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
                if (ViewState["clmno"] != null) { claimno = int.Parse(ViewState["clmno"].ToString()); }
                if (ViewState["table"] != null) { table = int.Parse(ViewState["table"].ToString()); }
                if (ViewState["term"] != null) { term = int.Parse(ViewState["term"].ToString()); }
                if (ViewState["polstatus"] != null) { polstatus = ViewState["polstatus"].ToString(); }
                if (ViewState["com"] != null) { com = int.Parse(ViewState["com"].ToString()); }
                if (ViewState["dtofdth"] != null) { dtofdth = int.Parse(ViewState["dtofdth"].ToString()); }
                if (ViewState["exgracia"] != null) { exgracia = double.Parse(ViewState["exgracia"].ToString()); }
                if (ViewState["clmamt"] != null) { clmamt = double.Parse(ViewState["clmamt"].ToString()); }
                if (ViewState["bonus"] != null) { bonus = double.Parse(ViewState["bonus"].ToString()); }
                if (ViewState["otheradds"] != null) { otheradds = double.Parse(ViewState["otheradds"].ToString()); }
                if (ViewState["defprem"] != null) { defprem = double.Parse(ViewState["defprem"].ToString()); }
                if (ViewState["defpremint"] != null) { defpremint = double.Parse(ViewState["defpremint"].ToString()); }
                if (ViewState["loan"] != null) { loan = double.Parse(ViewState["loan"].ToString()); }
                if (ViewState["loanint"] != null) { loanint = double.Parse(ViewState["loanint"].ToString()); }
                if (ViewState["amtcompolyr"] != null) { amtcompolyr = double.Parse(ViewState["amtcompolyr"].ToString()); }
                if (ViewState["otherdeduct"] != null) { otherdeduct = double.Parse(ViewState["otherdeduct"].ToString()); }
                if (ViewState["netclm"] != null) { netclm = double.Parse(ViewState["netclm"].ToString()); }
                if (ViewState["outamt"] != null) { outamt = double.Parse(ViewState["outamt"].ToString()); }
                if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
                if (ViewState["deposit"] != null) { deposit = double.Parse(ViewState["deposit"].ToString()); }
                if (ViewState["isFuturePayment"] != null) { isFuturePayment = ViewState["isFuturePayment"].ToString(); }
                #endregion
            }
            if (memeaprv.Equals("Y"))
            {
                this.btnAccept.Enabled = false;
            }
        }
        catch (Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        #region------------------Set values in the form--------------------
        this.lblpolno.Text = polno.ToString();
        this.lblclmno.Text = claimno.ToString();
        this.lbltab.Text = table.ToString();
        this.lblterm.Text = term.ToString();
        this.lblpolstat.Text = polstatStr;
        this.lblCom.Text = com.ToString().Substring(0,4)+"/"+com.ToString().Substring(4,2)+"/"+com.ToString().Substring(6,2);
        this.lbldtofdth.Text = dtofdth.ToString().Substring(0, 4) + "/" + dtofdth.ToString().Substring(4, 2) + "/" + dtofdth.ToString().Substring(6, 2); ;
        this.lblExclaim.Text = String.Format("{0:N}", exgracia);
        this.lblClaim.Text = String.Format("{0:N}", clmamt);
        this.lblBonus.Text = String.Format("{0:N}", bonus);
        this.lblOtheradds.Text = String.Format("{0:N}", otheradds);
        this.lblDefprem.Text = String.Format("{0:N}", defprem);
        this.lblPremint.Text = String.Format("{0:N}", defpremint);
        this.lblLoancap.Text = String.Format("{0:N}", loan);
        this.lblLoanint.Text = String.Format("{0:N}", loanint);
        this.lblComplyr.Text = String.Format("{0:N}", amtcompolyr);
        this.lblOtherdeduct.Text = String.Format("{0:N}", otherdeduct);
        this.lblTotal.Text=String.Format("{0:N}", netclm);
        this.lblDeposit.Text = String.Format("{0:N}", deposit);
        if (payee.Equals(""))
        {
            this.cmdDiseng.Enabled = false;
            this.cmdDissin.Enabled = false;
        }
        #endregion
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Mos
    {
        get { return mos; }
        set { mos = value; }
    }
    public int Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public int Table
    {
        get { return table; }
        set { table = value; }
    }
    public int Term
    {
        get { return term; }
        set { term = value; }
    }
    public string Polstatus
    {
        get { return polstatus; }
        set { polstatus = value; }
    }
    public int Com
    {
        get { return com; }
        set { com = value; }
    }
    public int Dtofdth
    {
        get { return dtofdth; }
        set { dtofdth = value; }
    }
    public double Exgracia
    {
        get { return exgracia; }
        set { exgracia = value; }
    }
    public double Clmamt
    {
        get { return clmamt; }
        set { clmamt = value; }
    }
    public double Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }
    public double Otheradds
    {
        get { return otheradds; }
        set { otheradds = value; }
    }
    public double Defprem
    {
        get { return defprem; }
        set { defprem = value; }
    }
    public double Defpremint
    {
        get { return defpremint; }
        set { defpremint = value; }
    }
    public double Loan
    {
        get { return loan; }
        set { loan = value; }
    }
    public double Loanint
    {
        get { return loanint; }
        set { loanint = value; }
    }
    public double Amtpolcomyr
    {
        get { return amtcompolyr; }
        set { amtcompolyr = value; }
    }
    public double Otherdeduct
    {
        get { return otherdeduct; }
        set { otherdeduct = value; }
    }
    public double Netclm
    {
        get { return netclm; }
        set { netclm = value; }
    }
    public double Deposit
    {
        get { return deposit; }
        set { deposit = value; }
    }
    public string IsFuturePayment
    {
        get { return isFuturePayment; }
        set { isFuturePayment = value; }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&totamount=" + netclm + "&outAmt=" + outamt + "&claimno=" + claimno + "&theMof=" + mos + "&pageflag=1&dtofdth=" + dtofdth + "&tbl=" + table + "");
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        string Availability = "N";
        try
        {
            General gg = new General();

            dm = new DataManager();
            dm.begintransaction();

            if (deposit > 0)
            {
                gg.Write_Deposit_Adjestment(branch, polno, Context.Request.ServerVariables["REMOTE_ADDR"].ToString(), gg.StrToNumFilter(EPF), dm);
            }

            if ((table == 38 || table == 39 || table == 46 || table == 49 || table == 34) && mos == "M")
            {
                if (this.ddlFuturePay.SelectedValue == "-1")
                    throw new Exception("Please select future payment pay or not!");
                else
                    isFuturePayment = this.ddlFuturePay.SelectedValue;
            }
            else
            {
                isFuturePayment = "";
            }

            //string dthrefupd = "update LPHS.DTHREF set MEMOAPRV = 'Y', APRVDATE =to_char(sysdate,'yyyymmdd'), APRVEPF = '" + EPF + "', PAYAUTDT=0 where DRPOLNO=" + polno + "";
            string dthrefupd = "update LPHS.DTHREF set MEMOAPRV = 'Y', COMPLETED='Y', APRVDATE =to_char(sysdate,'yyyymmdd'), APRVEPF = '" + EPF + "', PAYAUTDT=0, IS_FUTUER_PAYMENT='" + isFuturePayment + "' where DRPOLNO=" + polno + "";
            dm.insertRecords(dthrefupd);                      

            #region ------------------Writing on lphs.Death_Sys_No File-----------------------------

            int maxAdmitNo = 0;
            int AdmitNo = 0;
            string dthSysSelect = "select POLICY_NO, CLAIM_NO from LPHS.DEATH_SYS_NO where POLICY_NO=" + polno + " and CLAIM_NO=" + Convert.ToInt32(ViewState["clmno"]) + "";

            if (dm.existRecored(dthSysSelect) == 0)
            {
                string dthSysCount = "select POLICY_NO from LPHS.DEATH_SYS_NO";

                if (dm.existRecored(dthSysCount) == 0)
                {
                    string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO) VALUES ( " + polno + " , " + Convert.ToInt32(ViewState["clmno"]) + ", '" + mos + "', " + 36100 + ")";
                    dm.insertRecords(dthSysNoInsert);
                }
                else
                {
                    string dthMaxAdmitNo = "SELECT MAX(ADMIT_NO) FROM LPHS.DEATH_SYS_NO";

                    dm.readSql(dthMaxAdmitNo);
                    OracleDataReader dthSysReader = dm.oraComm.ExecuteReader();
                    dthSysReader.Read();
                    if (!dthSysReader.IsDBNull(0)) { maxAdmitNo = dthSysReader.GetInt32(0); } else { maxAdmitNo = 0; }
                    dthSysReader.Close();
                    dthSysReader.Dispose();

                    AdmitNo = maxAdmitNo + 1;
                    string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO) VALUES ( " + polno + " , " + Convert.ToInt32(ViewState["clmno"]) + ", '" + mos + "', " + AdmitNo + ")";
                    dm.insertRecords(dthSysNoInsert);
                }
            }

            #endregion

            #region ------------------Writing on lphs.EXGRACIA_AMTS file----------------------------

            if (exgracia > 0)
            {
                string exgraciaSelect = "select dpolnum from lphs.exgracia_amts where dpolnum = " + polno + " and mof ='" + mos + "' ";

                if (dm.existRecored(exgraciaSelect) == 0)
                {
                    string exgraciaInsert = "INSERT INTO LPHS.EXGRACIA_AMTS (DPOLNUM ,MOF ,SUMONEX ,ADBONEX ,FPUONEX ,FEONEX ,SJONEX ,OTHERADDONEX ,REFOFPRMONEX )" +
                                " VALUES (" + polno + " ,'" + mos + "' ," + exgracia + " ," + 0 + " ," + 0 + " ," + 0 + " ," + 0 + " ," + 0 + " ," + 0 + "  )";
                    dm.insertRecords(exgraciaInsert);
                }
                else
                {
                    string exgraciaUpdate = "UPDATE LPHS.EXGRACIA_AMTS SET SUMONEX = " + exgracia + " WHERE DPOLNUM = " + polno + " and MOF = '" + mos + "' ";
                    dm.insertRecords(exgraciaUpdate);
                }
            }

            #endregion


            #region reinsure email

            string reinsurechck = "select AVAILABILITY from LPHS.DTH_REINSURANCE_DTL where CLAIMNO='" + claimno + "'";

            if (dm.existRecored(reinsurechck) != 0)
            {
                dm.readSql(reinsurechck);
                OracleDataReader dthControlReader = dm.oraComm.ExecuteReader();
                dthControlReader.Read();
                if (!dthControlReader.IsDBNull(0)) { Availability = dthControlReader.GetString(0); }
                dthControlReader.Close();
                dthControlReader.Dispose();
            }
            if (Availability == "Y")
            {
                string checckmail = "SELECT * FROM LPHS.DTH_REINS_EMAIL_LOG WHERE  POLNO='" + polno + "' and CLAIMNO='" + claimno + "' and TYPE='PAYMENT'";
                if (dm.existRecored(checckmail) == 0)
                {
                    string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                            (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                             VALUES ('" + polno + "','" + claimno + "' , sysdate, '" + EPF + "','PAYMENT')";
                    dm.insertRecords(insertEmaillog);

                    string updatePayment = "UPDATE LPHS.DTH_REINSURANCE_DTL set PAYMENT_DETAIL_SENT='Y'," +
                                "PAYMENT_DETAIL_SENT_DATE=sysdate,RE_INS_STATUS='COMPLETED' where CLAIMNO='" + claimno + "'";
                    dm.insertRecords(updatePayment);
                }
            }
            #endregion

            dm.commit();
            dm.connclose();
            btnAccept.Enabled = false;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        btnAccept.Enabled = false;

        if (Availability == "Y")
        {
            Response.Redirect("PaymentForm.aspx?pState=2&clmno=" + claimno + "&polno=" + polno + "&mos=" + mos + "");
        }
    }
    protected void cmdDissin_Click(object sender, EventArgs e)
    {
        Response.Redirect("discharge002.aspx?polno=" + polno + "&mos=" + mos + "&clmno=" + claimno + "&dtofdth=" + dtofdth + "");
    }
    protected void cmdDiseng_Click(object sender, EventArgs e)
    {
        Response.Redirect("discharge001.aspx?polno=" + polno + "&mos=" + mos + "&clmno=" + claimno + "&dtofdth=" + dtofdth + "");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}
