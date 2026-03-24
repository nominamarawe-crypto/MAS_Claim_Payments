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
using System.Drawing;
using System.Globalization;

public partial class dthPro003 : System.Web.UI.Page
{
    private long polno;
    private string MOF;

    private string EPF = "";

    private int infodat;
    private int dateofdeath;
    private string polstat = "";

    //--- policy details -----------------

    private string COD;
    private int COM;
    private int TBL;
    private int TRM;
    private long SUM;
    private int MOD;
    private double PRM;
    private int DUE;
    private int PAC;
    private string STA;
    private double sjamt;
    private double swarnajaya;
    private DateTime decisiondate;
    private DateTime adbDecisiondate;

    //--- variables to update DTHREF -----

    private string causeStr;
    private int causeCode;
    private string decision;
    private int countStatic;
    private string decisionDate;

    //Added by Rumesha
    private string adbDecisionDate;
    private int claimNo;

    DataManager dthpayObj;
    ArrayList arr;
    SwarnaJayanthi sjayanthi;
    polMasRead pmr;

    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            EPage.Messege = "Your Session Variable Expired Please Log on to the System!";
            Response.Redirect("EPage.aspx");
        }


        if (!Page.IsPostBack)
        {
            dthpayObj = new DataManager();
            try
            {
                if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
                {
                    polno = this.PreviousPage.Polno;
                    MOF = this.PreviousPage.mOF;
                }

                this.lblpolno.Text = polno.ToString();

                pmr = new polMasRead(int.Parse(polno.ToString()), dthpayObj);

                if (MOF.Equals("M")) { this.lbllifetype.Text = "Main Life"; }
                else if (MOF.Equals("S")) { this.lbllifetype.Text = "Spouce"; }
                else if (MOF.Equals("2")) { this.lbllifetype.Text = "Second Life"; }
                else { }
                // this.txtcauseStr.Text = this.DropDownList1.SelectedItem.Text;

                string dthintSelect = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=2  ";
                if (dthpayObj.existRecored(dthintSelect) == 0)
                {
                    throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                }
                else
                {
                    dthpayObj.readSql(dthintSelect);
                    OracleDataReader dthintREADER = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintREADER.Read())
                    {
                        if (!dthintREADER.IsDBNull(0)) { infodat = dthintREADER.GetInt32(0); } else { infodat = 0; }
                        if (!dthintREADER.IsDBNull(3)) { dateofdeath = dthintREADER.GetInt32(3); } else { dateofdeath = 0; }
                        if (!dthintREADER.IsDBNull(1)) { polstat = dthintREADER.GetString(1); } else { polstat = ""; }
                    }
                    dthintREADER.Close();
                    dthintREADER.Dispose();
                }

                if (polstat.Equals("I")) { this.lblpolstat.Text = "INFORCE"; }
                else if (polstat.Equals("L")) { this.lblpolstat.Text = "LAPSED"; }

                #region //---------- DTHREF -----------

                string DDECISION = "";
                string CAUSEOFDEATHSTR = "";
                string MEMOAPRV = "";
                //int PAYAUTDT = 0;
                string COMPLETED = "";

                string dthrefsel = "select DRDEFPREM, DRINT,  DDECISION, CAUSEOFDEATHSTR,  MEMOAPRV,  PAYAUTDT, COMPLETED, SJPAYAMT,DECISION_DATE from LPHS.DTHREF where drpolno  = " + polno + " and drmos = '" + MOF + "'";
                if (dthpayObj.existRecored(dthrefsel) != 0)
                {
                    dthpayObj.readSql(dthrefsel);
                    OracleDataReader dthrefReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(2)) { DDECISION = dthrefReader.GetString(2); } else { DDECISION = ""; }
                        if (!dthrefReader.IsDBNull(3)) { CAUSEOFDEATHSTR = dthrefReader.GetString(3); } else { CAUSEOFDEATHSTR = ""; }
                        if (!dthrefReader.IsDBNull(6)) { COMPLETED = dthrefReader.GetString(6); } else { COMPLETED = ""; }
                        if (!dthrefReader.IsDBNull(4)) { MEMOAPRV = dthrefReader.GetString(4); } else { MEMOAPRV = ""; }
                        if (!dthrefReader.IsDBNull(7)) { swarnajaya = dthrefReader.GetDouble(7); } else { swarnajaya = 0; }
                        if (!dthrefReader.IsDBNull(8)) { decisiondate = dthrefReader.GetDateTime(8); } else { DateTime? decisiondate = null; }

                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();
                }
                else
                {
                    dthpayObj.connclose();
                    throw new Exception("No Death Reference Details!");
                }

                if ((COMPLETED.Equals("Y")) || (COMPLETED.Equals("R"))) { this.btnok.Enabled = false; }
                if ((CAUSEOFDEATHSTR == null) || (CAUSEOFDEATHSTR.Equals(""))) { this.txtcauseStr.Text = "ACCIDENT"; } else { this.txtcauseStr.Text = CAUSEOFDEATHSTR; this.txtDecisonDate.Text = decisiondate.ToString("yyyyMMdd"); }
                this.txtdecision.Text = DDECISION;
                if (txtDecisonDate.Text == "00010101")
                {
                    this.txtDecisonDate.Text = "";
                }

                string adbPaymentsel = "select ADB_DECISION_DATE from LPHS.DTH_ADBPAYMENTS where policy_no=" + polno + " and mos='" + MOF + "'";
                if (dthpayObj.existRecored(adbPaymentsel) != 0)
                {
                    dthpayObj.readSql(adbPaymentsel);
                    OracleDataReader adbReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (adbReader.Read())
                    {
                        if (!adbReader.IsDBNull(0)) { adbDecisiondate = adbReader.GetDateTime(0); } else { DateTime? adbDecisiondate = null; }
                    }
                    adbReader.Close();
                    adbReader.Dispose();
                }

                if (adbDecisionDate != "0")
                {
                    txtADBDecisonDate.Text = adbDecisiondate.ToString("yyyyMMdd"); ;
                }

                if (txtADBDecisonDate.Text == "00010101")
                {
                    this.txtADBDecisonDate.Text = "";
                }
                //if ((MEMOAPRV.Equals("Y")) || (MEMOAPRV.Equals("R")))
                //{
                //    //this.txtDem01.ReadOnly = true;
                //this.txtDem02.ReadOnly = true;
                //this.txtDem03.ReadOnly = true;
                //this.txtDem04.ReadOnly = true;
                //this.txtDem05.ReadOnly = true;
                //this.txtDem06.ReadOnly = true;
                //this.txtDem07.ReadOnly = true;
                //this.txtDem08.ReadOnly = true;
                //this.txtDem09.ReadOnly = true;
                //this.txtDem10.ReadOnly = true;
                //this.txtDem11.ReadOnly = true;
                //this.txtDem12.ReadOnly = true;
                //}

                #endregion

                #region //****** Demmands ********
                COM = pmr.COM;
                DUE = pmr.DUE;
                STA = pmr.STATUS;
                //******** Showing Demmands ******
                int dateofdthYM = int.Parse(dateofdeath.ToString().Substring(0, 6));
                int demanddate = 0;
                int count = 0;

                arr = new ArrayList();
                string mydemandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' and ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue||'" + COM.ToString().Substring(6, 2) + "' <= " + dateofdeath + " order by pddue ";
                dthpayObj.readSql(mydemandsql);
                OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (mydemandreader01.Read())
                {
                    count++;
                    demanddate = mydemandreader01.GetInt32(1);
                    string[] demarr = new string[2];
                    demarr[0] = demanddate.ToString();
                    demarr[1] = count.ToString();
                    arr.Add(demarr);
                    this.createDemmandTable(demanddate.ToString(), count);


                    string ddeamndSel = "select DPDPOL, DPDDUE from LPHS.DDEMAND where DPDPOL = " + polno + " and DPDDUE = " + demanddate + " ";
                    if (dthpayObj.existRecored(ddeamndSel) == 0)
                    {
                        string ddemandInsert = "INSERT INTO LPHS.DDEMAND (DPDPOL ,DPDDUE, INSERT_TYPE, ENTEPF, ENTDATE ) VALUES ( " + polno + " , " + demanddate + ", 'OLD', '" + EPF + "', " + int.Parse(this.setDate()[0]) + " )";
                        dthpayObj.insertRecords(ddemandInsert);
                    }
                }
                countStatic = count;
                mydemandreader01.Close();
                mydemandreader01.Dispose();


                #endregion

                dthpayObj.connclose();

                //-------------------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["infodat"] = infodat;
                ViewState["dateofdeath"] = dateofdeath;

                ViewState["COD"] = COD;
                ViewState["COM"] = COM;
                ViewState["TBL"] = TBL;
                ViewState["TRM"] = TRM;
                ViewState["SUM"] = SUM;
                ViewState["MOD"] = MOD;
                ViewState["PRM"] = PRM;
                ViewState["DUE"] = DUE;
                ViewState["PAC"] = PAC;
                ViewState["STA"] = STA;
                ViewState["countStatic"] = countStatic;
                ViewState["arr"] = arr;
                ViewState["swarnajaya"] = swarnajaya;
            }
            catch (Exception ex)
            {
                dthpayObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["infodat"] != null) { infodat = int.Parse(ViewState["infodat"].ToString()); }
            if (ViewState["dateofdeath"] != null) { dateofdeath = int.Parse(ViewState["dateofdeath"].ToString()); }

            if (ViewState["COD"] != null) { COD = ViewState["COD"].ToString(); }
            if (ViewState["COM"] != null) { COM = int.Parse(ViewState["COM"].ToString()); }
            if (ViewState["TBL"] != null) { TBL = int.Parse(ViewState["TBL"].ToString()); }
            if (ViewState["TRM"] != null) { TRM = int.Parse(ViewState["TRM"].ToString()); }
            if (ViewState["SUM"] != null) { SUM = long.Parse(ViewState["SUM"].ToString()); }
            if (ViewState["MOD"] != null) { MOD = int.Parse(ViewState["MOD"].ToString()); }
            if (ViewState["PRM"] != null) { PRM = double.Parse(ViewState["PRM"].ToString()); }
            if (ViewState["DUE"] != null) { DUE = int.Parse(ViewState["DUE"].ToString()); }
            if (ViewState["PAC"] != null) { PAC = int.Parse(ViewState["PAC"].ToString()); }
            if (ViewState["STA"] != null) { STA = ViewState["STA"].ToString(); }
            if (ViewState["countStatic"] != null) { countStatic = int.Parse(ViewState["countStatic"].ToString()); }
            if (ViewState["arr"] != null) { arr = (ArrayList)ViewState["arr"]; }
            if (ViewState["swarnajaya"] != null) { swarnajaya = double.Parse(ViewState["swarnajaya"].ToString()); }

            foreach (string[] demarray in arr)
            {
                int demanddate = int.Parse(demarray[0]);
                int count = int.Parse(demarray[1]);

                this.createDemmandTable(demanddate.ToString(), count);
            }
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        try
        { 
            decisionDate = this.txtDecisonDate.Text;
            DateTime dt = DateTime.ParseExact(decisionDate, "yyyyMMdd", CultureInfo.InvariantCulture);

            dt.ToString("yyyyMMdd");

            lbldate.Text = string.Empty;

            if (int.Parse(decisionDate) < dateofdeath)
            {
                this.cv.IsValid = false;
                this.cv.ErrorMessage = "Check Decision Date! It cann't be less than date of death";
                return;
            }

            if (int.Parse(this.setDate()[0]) < int.Parse(decisionDate))
            {
                this.cv.IsValid = false;
                this.cv.ErrorMessage = "Check Decision Date! It cann't be future date";
                return;
            }

            //Added by Rumesha
            if (txtADBDecisonDate.Text != "")
            {
                adbDecisionDate = this.txtADBDecisonDate.Text;
                DateTime dtADB = DateTime.ParseExact(adbDecisionDate, "yyyyMMdd", CultureInfo.InvariantCulture); //Added by Rumesha
                dtADB.ToString("yyyyMMdd");

                lblADBDate.Text = string.Empty;

                if (int.Parse(adbDecisionDate) < dateofdeath)
                {
                    this.cv.IsValid = false;
                    this.cv.ErrorMessage = "Check Decision Date! It cann't be less than date of death";
                    return;
                }

                if (int.Parse(this.setDate()[0]) < int.Parse(adbDecisionDate))
                {
                    this.cv.IsValid = false;
                    this.cv.ErrorMessage = "Check Decision Date! It cann't be future date";
                    return;
                }
            }
            //--
            dthpayObj = new DataManager();
            try
            {

                #region //********* validations *****************

                //bool validate = false;
                //try { int.Parse(this.txtDem01.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem02.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem03.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem04.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem05.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem06.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem07.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem08.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem09.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem10.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem11.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //try { int.Parse(this.txtDem12.Text.ToString()); }
                //catch { validate = true; }
                //if (validate) { this.cv.IsValid = false; this.cv.ErrorMessage = "Non Numeric Demmand"; return; }

                //if ((this.txtDem01.Text.ToString().Length < 6) && (int.Parse(this.txtDem01.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem02.Text.ToString().Length < 6) && (int.Parse(this.txtDem02.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem03.Text.ToString().Length < 6) && (int.Parse(this.txtDem03.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem04.Text.ToString().Length < 6) && (int.Parse(this.txtDem04.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem05.Text.ToString().Length < 6) && (int.Parse(this.txtDem05.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem06.Text.ToString().Length < 6) && (int.Parse(this.txtDem06.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem07.Text.ToString().Length < 6) && (int.Parse(this.txtDem07.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem08.Text.ToString().Length < 6) && (int.Parse(this.txtDem08.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem09.Text.ToString().Length < 6) && (int.Parse(this.txtDem09.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem10.Text.ToString().Length < 6) && (int.Parse(this.txtDem10.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem11.Text.ToString().Length < 6) && (int.Parse(this.txtDem11.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }
                //if ((this.txtDem12.Text.ToString().Length < 6) && (int.Parse(this.txtDem12.Text.ToString()) > 0)) { this.cv.IsValid = false; this.cv.ErrorMessage = "Invalid Demmand"; return; }

                #endregion

                //int[] demmandsArr = new int[12];
                //if (!this.txtDem01.Text.Equals(null) && !this.txtDem01.Text.Equals("")) { demmandsArr[0] = int.Parse(this.txtDem01.Text); }
                //if (!this.txtDem02.Text.Equals(null) && !this.txtDem02.Text.Equals("")) { demmandsArr[1] = int.Parse(this.txtDem02.Text); }
                //if (!this.txtDem03.Text.Equals(null) && !this.txtDem03.Text.Equals("")) { demmandsArr[2] = int.Parse(this.txtDem03.Text); }
                //if (!this.txtDem04.Text.Equals(null) && !this.txtDem04.Text.Equals("")) { demmandsArr[3] = int.Parse(this.txtDem04.Text); }
                //if (!this.txtDem05.Text.Equals(null) && !this.txtDem05.Text.Equals("")) { demmandsArr[4] = int.Parse(this.txtDem05.Text); }
                //if (!this.txtDem06.Text.Equals(null) && !this.txtDem06.Text.Equals("")) { demmandsArr[5] = int.Parse(this.txtDem06.Text); }
                //if (!this.txtDem07.Text.Equals(null) && !this.txtDem07.Text.Equals("")) { demmandsArr[6] = int.Parse(this.txtDem07.Text); }
                //if (!this.txtDem08.Text.Equals(null) && !this.txtDem08.Text.Equals("")) { demmandsArr[7] = int.Parse(this.txtDem08.Text); }
                //if (!this.txtDem09.Text.Equals(null) && !this.txtDem09.Text.Equals("")) { demmandsArr[8] = int.Parse(this.txtDem09.Text); }
                //if (!this.txtDem10.Text.Equals(null) && !this.txtDem10.Text.Equals("")) { demmandsArr[9] = int.Parse(this.txtDem10.Text); }
                //if (!this.txtDem11.Text.Equals(null) && !this.txtDem11.Text.Equals("")) { demmandsArr[10] = int.Parse(this.txtDem11.Text); }
                //if (!this.txtDem12.Text.Equals(null) && !this.txtDem12.Text.Equals("")) { demmandsArr[11] = int.Parse(this.txtDem12.Text); }

                #region

                #endregion
                causeStr = this.txtcauseStr.Text.Trim();
                causeCode = int.Parse(this.DropDownList1.SelectedItem.Value);
                decision = this.txtdecision.Text.Trim();

                //string s = "UPDATE LPHS.DTHREF SET DROTHERADITNS = 12 , DEOTHERDEDUCT = 12 , REFUND_OF_PREMS = 12 WHERE";

                #region-----------Swarnajayanthi Calculation by Dushan---------------------------
                //string sjdatestr = txtSjdate.Text;
                string sjdatestr = "";
                int sjdate;
                double sjsumass;
                int inforceDuration = 0;
                int lapsedPayedYears = 0;
                double paidSJAmount = 0.0;

                if (swarnajaya == 0)
                {
                    if (!sjdatestr.Equals("")) { sjdate = int.Parse(sjdatestr); } else { sjdate = 0; }
                    //sjayanthi = new SwarnaJayanthi(polno, dateofdeath, MOF, sjdate);
                    //sjamt = sjayanthi.Sjamt;
                    //sjsumass = sjayanthi.Sumass;
                    //swarnajaya = sjamt + sjsumass;

                    SwarnaJayanthiCover ss = new SwarnaJayanthiCover(polno, dateofdeath, MOF, sjdate);
                    ss.SwarnaJayanthiCalculation();

                    if (STA == "I")
                    {
                        inforceDuration = this.dateComparison(COM, dateofdeath)[0];

                        if (inforceDuration >= 2)
                        {
                            swarnajaya = Math.Floor(Math.Round((ss.SJSumAssured + ss.RefundableAmount), 2));
                        }
                        else
                        {
                            swarnajaya = Math.Floor(Math.Round((ss.SJSumAssured), 2));
                        }
                    }
                    else if (STA == "L")
                    {
                        lapsedPayedYears = this.dateComparison(COM, int.Parse(DUE.ToString() + COM.ToString().Substring(6, 2)))[0];

                        if (lapsedPayedYears >= 2)
                        {
                            swarnajaya = Math.Floor(Math.Round((ss.RefundableAmount), 2));
                        }
                        else
                        {
                            swarnajaya = 0;
                        }
                    }
                }
                #endregion

                #region -------- Swarna Jayanthi Paid Amount ---------
                //string paidSJAmountSel = "select sum(TOTAMOUNT) from cashbook.temp_cb where POLNO = '" + polno + "' and VOUTYP='Swarna Jayanthi' and PRINT1=1 and STATUS='Paid'";
                string paidSJAmountSel = "select sum(TOTAMOUNT) from cashbook.temp_cb where POLNO = '" + polno + "' and (VOUTYP='Swarna Jayanthi' or vouno like 'SJ/%') and PRINT1=1 and STATUS='Paid'";
                dthpayObj.readSql(paidSJAmountSel);
                OracleDataReader paidSJAmountRead = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (paidSJAmountRead.Read())
                {
                    if (!paidSJAmountRead.IsDBNull(0)) { paidSJAmount = paidSJAmountRead.GetDouble(0); } else { paidSJAmount = 0; }
                }
                paidSJAmountRead.Close();
                paidSJAmountRead.Dispose();
                #endregion

                if (swarnajaya > 0 && paidSJAmount > 0)
                {
                    swarnajaya = swarnajaya - paidSJAmount;
                }

                string dthrefSelect = "select * from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                if (dthpayObj.existRecored(dthrefSelect) != 0)
                {
                    string dthrefUpdate = "UPDATE LPHS.DTHREF SET DCAUSEOFDTH = " + causeCode + " , DDECISION = '" + decision + "' ,";
                    dthrefUpdate += "CAUSEOFDEATHSTR = '" + causeStr + "', SJPAYAMT=" + swarnajaya + " ,DECISION_DATE= TO_DATE('" + decisionDate + "', 'YYYY/MM/DD'), DECISIONUSR='" + EPF + "' WHERE drpolno=" + polno + " and drmos='" + MOF + "'  ";

                    dthpayObj.insertRecords(dthrefUpdate);
                }
                else
                {
                    dthpayObj.connclose();
                    throw new Exception("No Death Reference Details!");
                }

                #region  //---------- demmand insert (commented) -------------
                //int demmandDue = 0;

                //for (int i = 0; i < demmandsArr.Length; i++)
                //{
                //    if (demmandsArr[i] > 0)
                //    {
                //        demmandDue = demmandsArr[i];
                //        string demmandSelect = "select * from lphs.demand where pdpol=" + polno + " and pddue=" + demmandDue + "  ";
                //        if (dthpayObj.existRecored(demmandSelect) == 0)
                //        {
                //            string demandInsert = "INSERT INTO LPHS.DEMAND (PDCOD ,PDPOL ,PDDUE ,PDPRM ,PDPAC ,PDTAB ,PDTER ,PDPDT ) ";
                //            demandInsert += " VALUES ('1' ," + polno + " ," + demmandDue + " ," + PRM + " ," + PAC + " ," + TBL + " ," + TRM + " ," + int.Parse(this.setDate()[0]) + "  )";
                //            dthpayObj.insertRecords(demandInsert);
                //        }

                //        string ddeamndSel = "select DPDPOL, DPDDUE from LPHS.DDEMAND where DPDPOL = " + polno + " and DPDDUE = " + demmandDue + " ";
                //        if (dthpayObj.existRecored(ddeamndSel) == 0)
                //        {
                //            string ddemandInsert = "INSERT INTO LPHS.DDEMAND (DPDPOL ,DPDDUE, INSERT_TYPE, ENTEPF, ENTDATE) VALUES ( " + polno + " , " + demmandDue + ", 'NEW', '" + EPF + "', " + int.Parse(this.setDate()[0]) + " )";
                //            dthpayObj.insertRecords(ddemandInsert);
                //        }
                //    }
                //}


                #endregion

                #region //---------- ADB Payment-------------

                string dthrefSelectADB = "select DRCLMNO from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                if (dthpayObj.existRecored(dthrefSelectADB) > 0)
                {
                    dthpayObj.readSql(dthrefSelectADB);
                    OracleDataReader dthintREADER = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintREADER.Read())
                    {
                        if (!dthintREADER.IsDBNull(0)) { claimNo = dthintREADER.GetInt32(0); } else { claimNo = 0; }
                    }
                    dthintREADER.Close();
                    dthintREADER.Dispose();
                }

                if (txtADBDecisonDate.Text != "")
                {
                    string adbPaymentSelect = "select * from LPHS.DTH_ADBPAYMENTS where policy_no=" + polno + " and mos='" + MOF + "' and claim_no=" + claimNo + "";
                    if (dthpayObj.existRecored(adbPaymentSelect) > 0)
                    {
                        string adbPaymentsUpdate = "update LPHS.DTH_ADBPAYMENTS set ADB_DECISION_DATE = TO_DATE('" + adbDecisionDate + "', 'YYYY/MM/DD') where policy_no=" + polno + " and mos='" + MOF + "' and claim_no=" + claimNo + "";
                        dthpayObj.insertRecords(adbPaymentsUpdate);
                    }
                    else
                    {
                        string adbPaymentInsert = "insert into LPHS.DTH_ADBPAYMENTS (POLICY_NO, MOS, CLAIM_NO, ADB_DECISION_DATE) " +
                                            "values (" + polno + ",'" + MOF + "'," + claimNo + ",TO_DATE('" + adbDecisionDate + "', 'YYYY/MM/DD'))";
                        dthpayObj.insertRecords(adbPaymentInsert);
                    }
                }
                #endregion


                this.lblsuccess.Visible = true;
                this.btnok.Enabled = false;
                this.lblsuccess.Text = "Record Updated Successfully";

                

                //dthpayObj.commit();
                dthpayObj.connclose();
            }
            catch (Exception ex)
            {
                dthpayObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        catch
        {
            lbldate.Text = "Invalid Date format";
            lbldate.ForeColor = Color.Red;
            lblADBDate.Text = "Invalid Date format";
            lbldate.ForeColor = Color.Red;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtcauseStr.Text = this.DropDownList1.SelectedItem.Text;
    }



    private void createDemmandTable(string due, int rowNumber)
    {
        try
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            Label lbl1 = new Label();

            lbl1.ID = "due" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "due" + rowNumber); //Text Value
            if (rowNumber == 0) { lbl1.Text = "Due"; }
            else { lbl1.Text = due; }

            tcell1.Controls.Add(lbl1);
            trow.Cells.Add(tcell1);
            Table1.Rows.Add(trow);
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public int[] dateComparison(int startdate, int enddate)
    { //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mOF
    {
        get { return MOF; }
        set { MOF = value; }
    }


    protected void btnnext_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/dthPay001.aspx", true);
    }
}
