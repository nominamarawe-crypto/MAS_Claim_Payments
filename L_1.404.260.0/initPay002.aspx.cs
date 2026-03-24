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

public partial class initPay002 : System.Web.UI.Page
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
    private string disType;
    private string disable;
    private string intimno;

    private double PAYAMT;
    private double netclm;
    private double balamt;
    private double dsum;
    private int TBL;
    private int COM;
    private double polcomyramt;

    private int lastpaydt;
    private int paymode;
    private int dtofaccident, pymnt_end_dt, mat_date;     //static
    private int paymntDue;
    private int nextdue;
    private int dateofacc;
    private string ppdbvouno="";
    private string voutype = "";
    private int polcom = 0;
    private int paydue;

    bool balanceflag;


    private string epf="06664";        //static
    private int statCount;       //static
    private ArrayList vouIndexes;        //static
    DataManager dm;
    AmtPolComyear apcy;

    protected void Page_Load(object sender, EventArgs e)
    {
        balanceflag = false;
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mos;
            disType = this.PreviousPage.DisType;
            intimno = this.PreviousPage.Intimno;
        }         
        try
        {
            dm = new DataManager();
            vouIndexes = new ArrayList();
            dm.begintransaction();
          if(!Page.IsPostBack)
          {
                netclm = 0; pymnt_end_dt = 0;
                //dm = new DataManager();
                //vouIndexes = new ArrayList();
                
                DissabilityTypesRead disabletype = new DissabilityTypesRead();
                
                disable = disabletype.GetDisabilityTypes(int.Parse(disType));
                this.lblpolno.Text = polno.ToString();
                this.lbldisType.Text = disable;
                this.lblintimNo.Text = intimno;
                if (MOS.Equals("M")) { this.lbllifeType.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lbllifeType.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lbllifeType.Text = "Second Life"; }
                

                #region ------- disable_mas -------
                string disaMasSelect = "select PAYAMT, paymode, dtofaccident, NETCLM, pymnt_end_dt, mat_date, DTOFACCIDENT, NPDUE, PAYMENT_BAL, DSUM, PPDBVOUNO, POLCOMYR_AMT_BAL, NPDUE FROM LCLM.DISABLE_MAS WHERE policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' and MGR_DECISION = 'Y' and (clmstate = 'ACCEPTED' or clmstate = 'INFORCE') ";
                if (dm.existRecored(disaMasSelect) != 0)
                {
                    dm.readSql(disaMasSelect);
                    OracleDataReader disaMasReader = dm.oraComm.ExecuteReader();
                    while (disaMasReader.Read())
                    {
                        if (!disaMasReader.IsDBNull(0)) { PAYAMT = disaMasReader.GetDouble(0); } else { PAYAMT = 0; }
                        //PAYAMT = PAYAMT / 120;
                        if (!disaMasReader.IsDBNull(1)) { paymode = disaMasReader.GetInt32(1); } else { paymode = 0; }
                        if (!disaMasReader.IsDBNull(2)) { dtofaccident = disaMasReader.GetInt32(2); } else { dtofaccident = 0; }
                        if (!disaMasReader.IsDBNull(3)) { netclm = disaMasReader.GetDouble(3); } else { netclm = 0; }
                        if (!disaMasReader.IsDBNull(4)) { pymnt_end_dt = disaMasReader.GetInt32(4); } else { pymnt_end_dt = 0; }
                        if (!disaMasReader.IsDBNull(5)) { mat_date = disaMasReader.GetInt32(5); } else { mat_date = 0; }
                        if (!disaMasReader.IsDBNull(6)) { dateofacc = disaMasReader.GetInt32(6); } else { dateofacc = 0; }
                        if (!disaMasReader.IsDBNull(7)) { paymntDue = disaMasReader.GetInt32(7); } else { paymntDue = 0; }
                        if (!disaMasReader.IsDBNull(8)) { balamt = disaMasReader.GetDouble(8); } else { balamt = 0; }
                        if (!disaMasReader.IsDBNull(9)) { dsum = disaMasReader.GetDouble(9); } else { dsum = 0; }
                        if (!disaMasReader.IsDBNull(10)) { ppdbvouno = disaMasReader.GetString(10); } else { ppdbvouno = ""; }
                        if (!disaMasReader.IsDBNull(11)) { polcomyramt = disaMasReader.GetDouble(11); } else { polcomyramt = 0; }
                        if (!disaMasReader.IsDBNull(3)) { paydue = disaMasReader.GetInt32(3); } else { paydue = 0; }
                    }
                    disaMasReader.Close();

                    //-------------Policy Complete year Amount----------------
                    //apcy = new AmtPolComyear(polno, dateofacc, dm);
                    //polcomyramt = apcy.Polcomamt;
                    if (polcomyramt > 0) 
                    { 
                        chkpolcom.Visible = true; 
                        chkpolcom.Checked = true;
                        lblPolcom.Visible = true;
                        lblPolcomamt.Visible = true;
                        lblPolcomamt.Text=String.Format("{0:N}", polcomyramt);
                    }
                    //----------------------------------

                    ///string disablemasupd = "update LCLM.DISABLE_MAS set POLCOMYR_AMT=" + polcomyramt + ", POLCOMYR_AMT_BAL=" + polcomyramt + " where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
                    //dm.insertRecords(disablemasupd);
                    if (balamt == 0 && !disType.Equals("2"))
                    {
                        balamt = this.Balamt(paymntDue, dateofacc, dsum, paymode);
                        string balamtinsert = "update LCLM.DISABLE_MAS set PAYMENT_BAL=" + balamt + " where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
                        dm.insertRecords(balamtinsert);
                    }
                    switch (paymode)
                    {
                        case 1: this.lblpaymode.Text = "Annually"; break;
                        case 2: this.lblpaymode.Text = "Half Yearly"; break;
                        case 3: this.lblpaymode.Text = "Quarterly"; break;
                        case 4: this.lblpaymode.Text = "Monthly"; break;
                        default: break;
                    }
                    this.lbltotclm.Text = String.Format("{0:N}", netclm);
                    if (dtofaccident != 0 && dtofaccident.ToString().Length == 8) { this.lbldtofaccident.Text = dtofaccident.ToString().Substring(0, 4) + "/" + dtofaccident.ToString().Substring(4, 2) + "/" + dtofaccident.ToString().Substring(6, 2); }
                    else { throw new Exception("Accident Date not Found!"); }
                }
                else if (disType.Equals("2"))
                {
                    throw new Exception("No Such Intimation or Claim not yet Accepted or Claim Rejected or Payment Completed!");
                }
                else { throw new Exception("No Such Intimation or Claim not yet Accepted or Claim Rejected"); }
                #endregion

                #region---------------Premast-----------------------
                string premastsel = "select PMTBL, PMCOM from LPHS.PREMAST where PMPOL=" + polno + "";
                if (dm.existRecored(premastsel) != 0)
                {
                    dm.readSql(premastsel);
                    OracleDataReader premastreader = dm.oraComm.ExecuteReader();
                    premastreader.Read();
                    if (!premastreader.IsDBNull(0)) { TBL = premastreader.GetInt32(0); } else { TBL = 0; }
                    if (!premastreader.IsDBNull(1)) { COM = premastreader.GetInt32(1); } else { COM = 0; }
                }
                #endregion

           }
           else
           {
               if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
               if (ViewState["MOF"] != null) { MOS = ViewState["MOF"].ToString(); }
               if (ViewState["disType"] != null) { disType = ViewState["disType"].ToString(); }
               if (ViewState["intimno"] != null) { intimno = ViewState["intimno"].ToString(); }
               //if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState[" vouIndexes"]; }
               if (ViewState["TBL"] != null) { TBL = int.Parse(ViewState["TBL"].ToString()); }
               if (ViewState["matdate"] != null) { mat_date = int.Parse(ViewState["matdate"].ToString()); }
               if (ViewState["payenddate"] != null) { pymnt_end_dt = int.Parse(ViewState["payenddate"].ToString()); }
               if (ViewState["dtofaccident"] != null) { dtofaccident = int.Parse(ViewState["dtofaccident"].ToString()); }
               if (ViewState["dsum"] != null) { dsum = double.Parse(ViewState["dsum"].ToString()); }
               if (ViewState["PAYAMT"] != null) { PAYAMT = double.Parse(ViewState["PAYAMT"].ToString()); }
               if (ViewState["paymntDue"] != null) { paymntDue = int.Parse(ViewState["paymntDue"].ToString()); }
               if (ViewState["polcomyramt"] != null) { polcomyramt = double.Parse(ViewState["polcomyramt"].ToString()); }
           }

                if (TBL != 38 && TBL != 39 && TBL != 46)
                 {
                    #region ------- periodic_pay_det ------Editted By Dushan-----------

                    //if (disType.Equals("2")) { throw new Exception("Partial Disability Claim. Please use PPDB Payments Option!"); }
                    int count = 0;
                    int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
                    double paymt=0;

                    #region--------This part added for the purpose of Payment System.-----------
                    if (!Page.IsPostBack)
                    {
                        if (!disType.Equals("2"))
                        {
                            string periodisasel = "select PAYMENT_DUE from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and intimno = '" + intimno + "'";
                            if (dm.existRecored(periodisasel) == 0)
                            {
                                nextdue = paymntDue;
                                while (nextdue <= int.Parse(this.setDate()[0].ToString().Substring(0, 6)) && nextdue <= int.Parse(pymnt_end_dt.ToString().Substring(0, 6)) && nextdue <= int.Parse(mat_date.ToString().Substring(0, 6)))
                                {
                                    nextdue = this.Createnextdue(nextdue, paymode);
                                    paymt = this.PaymentAmount(paymode, PAYAMT);
                                    string insertperiodic = "insert into lclm.PERIODIC_PAYDET(POLNO, CLMTYPE, PAYMENT_DUE, NEXT_DUE, DIS_CLM_TYP, LIFE_TYP, INTIMNO, PAID_AMT) values(" + polno + ", 'D', " + paymntDue + ", " + nextdue + ", " + disType + ", '" + MOS + "', '" + intimno + "', " + paymt + ")";
                                    dm.insertRecords(insertperiodic);
                                    paymntDue = nextdue;
                                }
                                if (nextdue >= int.Parse(mat_date.ToString().Substring(0,6)))
                                {
                                    this.termin_handle("MATURITY");
                                    polcom = 1;
                                    this.btnVouCr.Enabled = false;
                                    this.lblmat.Text = "Policy Matured! Please use Terminated List.";
                                    this.lblmat.Visible = true;
                                }
                            }
                            else 
                            {
                                string chkpaysel = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and intimno = '" + intimno + "' and (vono is null or vono = '' or vono = 'XXXX')";
                                if (dm.existRecored(chkpaysel) == 0)
                                {
                                    throw new Exception("Initial Payment have already completed. Please use Part Settlements option!");
                                }
                            }
                        }
                    }
                    #endregion

                    string paydetSel = "select PAYMENT_DUE from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and intimno = '" + intimno + "' and (vono is null or vono = '' or vono = 'XXXX') ";
                    if (dm.existRecored(paydetSel) != 0)
                    {
                        dm.readSql(paydetSel);
                        OracleDataReader paydetReader = dm.oraComm.ExecuteReader();
                        while (paydetReader.Read())
                        {
                            double amount;
                            int due;
                            amount = this.PaymentAmount(paymode, PAYAMT);

                            #region-----------------Checking of Payment outstanding----------
                            if (balamt < 0) { balamt = 0; }
                            if (balamt < amount) { amount = balamt; }
                            balamt -= amount;
                            if (amount > 0) { balanceflag = true; }
                            #endregion

                            if (count == 0) { this.createDuesTable(paymntDue, amount, count); }
                            if (!paydetReader.IsDBNull(0)) { paymntDue = paydetReader.GetInt32(0); } else { paymntDue = 0; }
                            due = int.Parse(paymntDue.ToString() + dtofaccident.ToString().Substring(6, 2));
                            if (due < int.Parse(this.setDate()[0]))
                            {
                                count++;
                                this.createDuesTable(paymntDue, amount, count);
                                vouIndexes.Add(paymntDue.ToString());
                            }
                        }
                        paydetReader.Close();

                        statCount = count;
                        if (!balanceflag) { btnVouCr.Enabled = false; }
                    }
                    else if (disType.Equals("2"))
                    {
                        double amount = PAYAMT;
                        int due;
                        if (!ppdbvouno.Equals("")) { throw new Exception("PPDB Payment Already Completed!"); }
                        if (count == 0) { this.createDuesTable(paymntDue, amount, count); }
                        due = int.Parse(paymntDue.ToString() + dtofaccident.ToString().Substring(6, 2));
                        if (due < int.Parse(this.setDate()[0]))
                        {
                            count++;
                            this.createDuesTable(paymntDue, amount, count);
                            vouIndexes.Add(paymntDue.ToString());
                            if (amount <= 0)
                            {
                                btnVouCr.Enabled = false;
                            }
                        }
                    }
                    else if (polcom == 0) { throw new Exception("Voucher/s Already Created or no such Dues or Payments completed!"); }

                    #endregion

                    #region ------------ grid -------------
                    DataManager dma=new DataManager();
                    DataTable dt = new DataTable();
                    string minuteSel = "select MINUTE_COUNT, MINUTE from LCLM.DISABILITY_MINUTES where POLICY_NO= " + polno + " and MOS= '" + MOS + "' and DIS_TYPE= '" + disType + "' and INTIMNO= '" + intimno + "' ";
                    OracleDataAdapter dat = new OracleDataAdapter(minuteSel, dma.oraConn);
                    dat.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    dma.connClose();
                    #endregion
                }
                else if (TBL == 39 && !disType.Equals("2"))//-------------Child Protection Payments------------------
                {
                    PAYAMT = dsum * 0.15;

                    #region---------------------------Child Protection Payments-------------
                    if (!Page.IsPostBack)
                    {
                        int dueym = int.Parse(COM.ToString().Substring(4, 4));
                        int dueyr = int.Parse(dtofaccident.ToString().Substring(0, 4));
                        if (dueym > int.Parse(dtofaccident.ToString().Substring(4, 4)))
                        {
                            paymntDue = int.Parse(dueyr.ToString() + COM.ToString().Substring(4, 2));
                        }
                        else
                        {
                            dueyr++;
                            paymntDue = int.Parse(dueyr.ToString() + COM.ToString().Substring(4, 2));
                        }

                        string periodisasel = "select PAYMENT_DUE from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'DIC' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and intimno = '" + intimno + "'";
                        if (dm.existRecored(periodisasel) == 0)
                        {
                            nextdue = paymntDue;
                            while (nextdue <= int.Parse(this.setDate()[0].ToString().Substring(0, 6)) && nextdue < int.Parse(mat_date.ToString().Substring(0, 6)))
                            {
                                nextdue = this.Createnextdue(nextdue, 1);
                                string insertperiodic = "insert into lclm.PERIODIC_PAYDET(POLNO, CLMTYPE, PAYMENT_DUE, NEXT_DUE, DIS_CLM_TYP, LIFE_TYP, INTIMNO, PAID_AMT) values(" + polno + ", 'DIC', " + paymntDue + ", " + nextdue + ", " + disType + ", '" + MOS + "', '" + intimno + "', " + PAYAMT + ")";
                                dm.insertRecords(insertperiodic);
                                paymntDue = nextdue;
                            }                            
                        }
                        else { throw new Exception("Initial Payment have already completed. Please use Child Protect Payment option!"); }
                    }

                    string paydetSel = "select PAYMENT_DUE from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'DIC' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and intimno = '" + intimno + "' and (vono is null or vono = '' or vono = 'XXXX') ";
                    if (dm.existRecored(paydetSel) != 0)
                    {
                        int count = 0;
                        dm.readSql(paydetSel);
                        OracleDataReader paydetReader = dm.oraComm.ExecuteReader();
                        while (paydetReader.Read())
                        {
                            double amount;
                            int due;
                            amount = PAYAMT;

                            if (count == 0) { this.createDuesTable(paymntDue, amount, count); }
                            if (!paydetReader.IsDBNull(0)) { paymntDue = paydetReader.GetInt32(0); } else { paymntDue = 0; }
                            due = int.Parse(paymntDue.ToString() + dtofaccident.ToString().Substring(6, 2));
                            if (due < int.Parse(this.setDate()[0]))
                            {
                                count++;
                                this.createDuesTable(paymntDue, amount, count);
                                vouIndexes.Add(paymntDue.ToString());
                            }
                        }
                        paydetReader.Close();

                        statCount = count;
                        if (count == 0) { btnVouCr.Enabled = false; }
                    }
                    #endregion
                }
                else if (TBL == 38 || TBL == 46)
                {
                    throw new Exception("No Disability Payments Available for this Policy. (Table " + TBL + ")");
                }
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
        if(!Page.IsPostBack) 
        {
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOS;
                ViewState["disType"] = disType;
                ViewState["intimno"] = intimno;
                //ViewState["vouIndexes"] = vouIndexes;
                ViewState["TBL"] = TBL;
                ViewState["payenddate"] = pymnt_end_dt;
                ViewState["matdate"] = mat_date;
                ViewState["dtofaccident"] = dtofaccident;
                ViewState["dsum"] = dsum;
                ViewState["PAYAMT"] = PAYAMT;
                ViewState["paymntDue"] = paymntDue;
                ViewState["polcomyramt"] = polcomyramt;
        }        
    }

    protected void btnVouCr_Click(object sender, EventArgs e)
    {
        voutype = "D";
        bool terminateFlag = false;
        try
        {
            dm = new DataManager();
            dm.begintransaction();
            string terminateReason = "";    
            double outAmt = 0;
            int temp1 = 0; int temp2 = 0;
            double amt = 0, totamt=0, polcomyearbal;
            polcomyearbal=polcomyramt;
            for (int i1 = 0; i1 < vouIndexes.Count; i1++)
            {
                temp1 = int.Parse(vouIndexes[i1].ToString());
                if (temp1 > temp2) { temp2 = temp1; }

                
            }

            int dueYM = temp2;          // maximum next due
            
            if (!disType.Equals("2") && TBL!=38 && TBL!=39 && TBL!=46)
            {

                #region //----------- check COMPLETION -----
                if (pymnt_end_dt == 0) { pymnt_end_dt = int.Parse(Convert.ToString(int.Parse(dtofaccident.ToString().Substring(0,4))+10)+dtofaccident.ToString().Substring(4,4)); }
                if (int.Parse(pymnt_end_dt.ToString().Substring(0, 6)) < dueYM)
                {
                    terminateFlag = true;
                    this.lblterminatnMsg.Text = "Total Payments will be Completed";
                    //------------ code to handle the completion 
                    terminateReason = "COMPLETED";
                    this.termin_handle(terminateReason);
                }

                #endregion

                #region //----------- check MATURITY -----

                if (int.Parse(mat_date.ToString().Substring(0, 6)) <= dueYM)
                {
                    terminateFlag = true;
                    this.lblmat.Text = "Policy Matured! Please Check the Termination List";
                    //------------ code to handle the termination 
                    terminateReason = "MATURITY";
                    this.termin_handle(terminateReason);
                }

                #endregion

                #region //----------- check DTHREF -------
                string memoaprv = "";
                string dthsel = "select memoaprv from lphs.dthref where drpolno = " + polno + " and drmos = '" + MOS + "' ";
                if (dm.existRecored(dthsel) != 0)
                {
                    dm.readSql(dthsel);
                    OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                    while (dthrefreader.Read())
                    {
                        if (!dthrefreader.IsDBNull(0)) { memoaprv = dthrefreader.GetString(0); } else { memoaprv = ""; }
                    }
                    dthrefreader.Close();

                    if (memoaprv.Equals("Y"))
                    {
                        terminateFlag = true;
                        this.lbldth.Text = "There is a Death Claim Regarding this policy.";
                        //------------ code to handle the termination
                        terminateReason = "DEATH";
                        this.termin_handle(terminateReason);
                    }
                    else { this.lbldth.Text = "There is a Registered Death Intimation Regarding this policy."; }
                }

                #endregion

                #region  //----------- check LSUREF -------
                string lsuast = "", lsuvst = "";
                string LSUREFsel = "select lsuast, lsuvst from lphs.lsuref where lsupol = " + polno + " and lsutyp = 'S' ";
                if (dm.existRecored(LSUREFsel) != 0)
                {
                    dm.readSql(LSUREFsel);
                    OracleDataReader LSUREFreader = dm.oraComm.ExecuteReader();
                    while (LSUREFreader.Read())
                    {
                        if (!LSUREFreader.IsDBNull(0)) { lsuast = LSUREFreader.GetString(0); } else { lsuast = ""; }
                        if (!LSUREFreader.IsDBNull(1)) { lsuvst = LSUREFreader.GetString(1); } else { lsuvst = ""; }
                    }
                    LSUREFreader.Close();
                }

                if (lsuast.Equals("Y")) { this.lblsurrender.Text = "There is an Authorized Surrender Request for this Policy."; }
                if (lsuvst.Equals("Y"))
                {
                    terminateFlag = true;
                    this.lblsurrender.Text = "Policy Surrendered. Please Check the Termination List";
                    terminateReason = "SURRENDER";
                    //------------ code to handle the termination
                    this.termin_handle(terminateReason);
                }
                #endregion

            }
                     
            if (terminateFlag)
            {
                #region // ------- outstanding Amount -------
                //total paid amount
                double totpayamt = 0;
                string totPaidamtSel = "select PAYMENT_BAL from lclm.DISABLE_MAS " +
                    "where POLICY_NO = " + polno + " and INTIMNO='" + intimno + "'";
                if (dm.existRecored(totPaidamtSel) != 0)
                {
                    dm.readSql(totPaidamtSel);
                    OracleDataReader paydetReader2 = dm.oraComm.ExecuteReader();
                    while (paydetReader2.Read())
                    {
                        if (!paydetReader2.IsDBNull(0)) { totpayamt = paydetReader2.GetDouble(0); } else { totpayamt = 0; }
                    }
                    paydetReader2.Close();
                }

                outAmt = totpayamt;
                if (outAmt < 0) { outAmt = 0; }
                string terminatnUpd = "update lclm.DISABILITY_TERMINATE set outstanding_amt = " + outAmt + " " +
                    " where POLNO =" + polno + " and MOS ='" + MOS + "' and DISTYPE='" + disType + "' ";
                dm.insertRecords(terminatnUpd);

                this.btnVouCr.Enabled = false;
                
                #endregion
            }
            else //if (TBL!=38 && TBL!=46)
            {
                #region // ------- if not terminated -------                
                if (TBL == 39) { voutype = "DIC"; }
                //else { voutype = "D"; }
                int i = 0;
                foreach (string vouindex in vouIndexes)
                {
                    i++;
                    paymntDue = int.Parse(vouindex);
                    string chk = "chk" + i;
                    CheckBox chkVouOK = new CheckBox();
                    chkVouOK = (CheckBox)Table1.FindControl(chk);

                    #region-----------Update for Pol. Com. Year---------------
                    if ((chkpolcom.Checked) && (chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                    {
                        string perioamtsel = "select PAID_AMT from LCLM.PERIODIC_PAYDET where PAYMENT_DUE=" + temp1 + " and POLNO=" + polno + " and INTIMNO='" + intimno + "'";
                        dm.readSql(perioamtsel);
                        OracleDataReader perioamtreader = dm.oraComm.ExecuteReader();
                        while (perioamtreader.Read())
                        {
                            if (!perioamtreader.IsDBNull(0)) { amt = perioamtreader.GetDouble(0); } else { amt = 0; }
                        }
                        if (amt < polcomyearbal) { totamt += amt; polcomyearbal -= amt; amt = 0; }
                        else { amt -= polcomyearbal; totamt += polcomyearbal; polcomyearbal = 0; }
                        string periopayupd = "update LCLM.PERIODIC_PAYDET set PAID_AMT=" + amt + " where PAYMENT_DUE=" + vouindex + " and POLNO=" + polno + " and INTIMNO='" + intimno + "'";
                        dm.insertRecords(periopayupd);
                    }
                    #endregion

                    //CheckBox chkVouOK = (CheckBox)Table1.FindControl(chk.Trim());
                    if ((chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                    {
                        if (!disType.Equals("2"))
                        {
                            string paydetUpd = "update LCLM.PERIODIC_PAYDET set vono = 'XXXX' where POLNO = " + polno + " and clmtype = '"+voutype+"' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and PAYMENT_DUE = " + paymntDue + " and (vono is null or vono = '') ";
                            dm.insertRecords(paydetUpd);
                        }                        
                    }                    
                }
                string disamasupd = "update LCLM.DISABLE_MAS set POLCOMYR_AMT_BAL=" + (polcomyramt - totamt) + " where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
                dm.insertRecords(disamasupd);
                //this.btnVouCr.Enabled = true;
                #endregion
            }
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

        if (!terminateFlag) { Response.Redirect("vouCreate001.aspx?polNo=" + polno + "&mos=" + MOS + "&disType=" + disType + "&intimno=" + intimno + "&voutype="+voutype+""); }
    }
        
    private void createDuesTable(int Due, double payamt, int count)
    {
        TableRow trow01 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel13 = new TableCell();
     
        Label lbl11 = new Label();
        Label lbl12 = new Label();      
        CheckBox chk01 = new CheckBox();       

        chk01.ID = "chk" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + count); //Text Value
        //ViewState.Add("check" + count.ToString(), "chk" + count);

        lbl11.ID = "due" + count;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "due" + count); //Text Value
        if (count == 0) { lbl11.Text = "Due"; }
        else { lbl11.Text = Due.ToString().Substring(0, 4) + "/" + Due.ToString().Substring(4, 2); }

        lbl12.ID = "payamt" + count;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "payamt" + count); //Text Value
        if (count == 0) { lbl12.Text = "Pay Amount"; }
        else { lbl12.Text = String.Format("{0:N}", payamt); }
      
        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        if (count > 0) { tcel13.Controls.Add(chk01); }
      
        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow01.Cells.Add(tcel13);
       
        Table1.Rows.Add(trow01);
        
    }

    protected void termin_handle(string terminReson)
    {
        if (terminReson.Equals("COMPLETED"))
        {
            string dis_masUpd = "update lclm.disable_mas set clmstate = 'COMPLETED' where policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' ";
            dm.insertRecords(dis_masUpd);
            string dreqUpd = "update lclm.pdbreq set DRCLMSTATE = 'COMPLETED' where DRPOL = " + polno + " and DRTYP = '" + disType + "' and LIFE_TYPE = '" + MOS + "' and intimno = '" + intimno + "' and " +
                      " APPEAL_CNT = 0 and DRCLMSTATE = 'ACCEPTED' ";
            dm.insertRecords(dreqUpd);
        }
        else
        {
            string disTermSel = "select POLNO from LCLM.DISABILITY_TERMINATE where POLNO =" + polno + " and MOS ='" + MOS + "' and DISTYPE='" + disType + "'  ";
            if (dm.existRecored(disTermSel) == 0)
            {
                string dis_ter_insert = "INSERT INTO LCLM.DISABILITY_TERMINATE (POLNO ,MOS ,DISTYPE ,TRMNT_REASON ,ENTRYDATE ,ENTRYIP, ENTRYEPF, INTIMNO)" +
                                  " VALUES (" + polno + " ,'" + MOS + "' ,'" + disType + "' ,'" + terminReson + "' ," + int.Parse(this.setDate()[0]) + " ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', '" + epf + "', '"+intimno+"')";
                dm.insertRecords(dis_ter_insert);

                string dis_masUpd = "update lclm.disable_mas set clmstate = 'TERMINATED' where policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' ";
                dm.insertRecords(dis_masUpd);

                string dreqUpd = "update lclm.pdbreq set DRCLMSTATE = 'TERMINATED' where DRPOL = " + polno + " and DRTYP = '" + disType + "' and LIFE_TYPE = '" + MOS + "' and intimno = '" + intimno + "' and " +
                       " APPEAL_CNT = 0 and DRCLMSTATE = 'ACCEPTED' ";
                dm.insertRecords(dreqUpd);
            }
        }
    }
    public double PaymentAmount(int mode, double amt)
    {
        int multilier;
        double amount;
        if (mode == 1) { multilier = 12; }
        else if (mode == 2) { multilier = 6; }
        else if (mode == 3) { multilier = 3; }
        else multilier = 1; 
        amount = amt * multilier;
        //add option to check this amount

        return Math.Round(amount,2);
    }

    public int Createnextdue(int lastdate, int mode)
    {
        int yr, mn, dt;
        string mnstr;
        yr = int.Parse(lastdate.ToString().Substring(0,4));
        mn = int.Parse(lastdate.ToString().Substring(4,2));
        //dd = int.Parse(lastdate.ToString().Substring(6,2));
        if (mode == 1) { yr ++; }
        else if (mode == 2) {mn += 6;}
        else if (mode == 3) { mn += 3; }
        else { mn++; }
        if (mn > 12) { mn -= 12; yr++; }
        if (mn < 10) { mnstr = "0" + mn.ToString(); }
        else { mnstr = mn.ToString(); }
        dt=int.Parse(yr.ToString()+mnstr);
        return dt;        
    }
    public double Balamt(int npdt, int dtofacc, double dsum, int paymode)
    {
        int lpaydt,yyyy,mm,dd,noyrs,nomons;
        string mmstr,ddstr;
        double balance;

        try
        {
            yyyy = int.Parse(npdt.ToString().Substring(0, 4));
            mm = int.Parse(npdt.ToString().Substring(4, 2));
            dd = int.Parse(dtofacc.ToString().Substring(6, 2));
            if (paymode == 1) { yyyy -= 1; ; }
            else if (paymode == 2) { mm -= 6; }
            else if (paymode == 3) { mm -= 3; }
            else { mm--; }
            if (mm < 1) { mm += 12; yyyy--; }
            if (mm < 10) { mmstr = "0" + mm.ToString(); }            
            else { mmstr = mm.ToString(); }
            if (dd < 10) { ddstr = "0" + dd.ToString(); }
            else { ddstr = dd.ToString(); }
            lpaydt = int.Parse(yyyy.ToString() + mmstr + ddstr);

            DateDifference dtdiffobj = new DateDifference(dtofacc, lpaydt);
            noyrs = dtdiffobj.Years;
            nomons = dtdiffobj.Months;
            balance = dsum - ((dsum * noyrs / 10) + (dsum * nomons / 120));
            return balance;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
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
    public string DisType
    {
        get { return disType; }
        set { disType = value; }
    }
    public string Intimno
    {
        get { return intimno; }
        set { intimno = value; }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("minute001.aspx?polNo=" + polno + "&mos=" + MOS + "&disType=" + disType + "&intimno=" + intimno + "&voutype="+voutype+"");
    }
}
