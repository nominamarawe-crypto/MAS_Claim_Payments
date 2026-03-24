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

public partial class ChildProt_ChildProtPay002 : System.Web.UI.Page
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

    private int dueYM;
    private int polno;
    private int maxPaymntdue;
    private int maxNextdue;
    private int mat_date;
    private string maturity;
    //int pymnt_end_dt;
    private int paymntDue;
    private double PAYAMT;
    private double BONUS;
    private double PAYAMT1;
    private string lifeType, clmtyp = "DTC";
    private ArrayList vouIndexes;
    private int clmno;
    private int dateofdth;
    private int COM;
    private int TBL;
    private string STA;
    private double paidUpValue;
    private double totAmount;
    private int memoAprvDate;
    private int MOD;
    private double SUM;
    private double vestedbonus;
    private double interimbonus;
    private bool isFinalPay = false;
    private string isFuturePayment;
    public bool SignatureDisplay;

    //private double dueamt;

    DataManager dm;
    lpolhisread lpolobj;
    BonusCal bcal;
    //DataManager dthpayObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["polNo"] != null)
            {
                ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polNo"]));
                polno = int.Parse(Request.QueryString["polNo"]);

            }
            if (Request.QueryString["maturityDt"] != null)
            {
                ViewState.Add("maturitydtQstr", Request.QueryString["maturityDt"].ToString());
                maturity = Request.QueryString["maturityDt"].ToString();

            }
            if (Request.QueryString["dueYm"] != null)
            {
                ViewState.Add("dueymQstr", int.Parse(Request.QueryString["dueYm"]));
                dueYM = int.Parse(Request.QueryString["dueYm"]);
               
                
            }
            if (Request.QueryString["clmtyp"] != null)
            {
                //ViewState.Add("clmtyp", Request.QueryString["clmtyp"].ToString());
                clmtyp = Request.QueryString["clmtyp"].ToString();
            }
            //if (Request.QueryString["payAmt"] != null)
            //{
            //    ViewState.Add("payamtQstr", double.Parse(Request.QueryString["payAmt"]));
            //    PAYAMT = double.Parse(Request.QueryString["payAmt"]);
            //}
            //if (Request.QueryString["lifeType"] != null)
            //{
            //    ViewState.Add("lifetypeQstr", int.Parse(Request.QueryString["lifeType"]));
            //    lifeType = Request.QueryString["lifeType"];
            //}
            ViewState["clmtyp"] = clmtyp;
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polno = (int)ViewState["polnoQstr"]; }
            if (ViewState["maturitydtQstr"] != null) { maturity = (string)ViewState["maturitydtQstr"]; }
            if (ViewState["dueymQstr"] != null) { dueYM = (int)ViewState["dueymQstr"]; }
            if (ViewState["clmtyp"] != null) { clmtyp = ViewState["clmtyp"].ToString(); }
            //if (ViewState["payamtQstr"] != null) { PAYAMT = (double)ViewState["payamtQstr"]; }
            //if (ViewState["lifetypeQstr"] != null) { lifeType = (string)ViewState["lifetypeQstr"]; }
            if (ViewState["memoAprvDateQstr"] != null) { memoAprvDate = (int)ViewState["memoAprvDateQstr"]; }
            if (ViewState["payMod"] != null) { MOD = (int)ViewState["payMod"]; }
            if (ViewState["sumAss"] != null) { SUM = (double)ViewState["sumAss"]; }
        }
        mat_date = int.Parse(maturity.Replace("/", ""));
        try
        {
            dm = new DataManager();
            int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
            if (dueYM > 0) { this.lbldue.Text = dueYM.ToString().Substring(0, 4) + "/" + dueYM.ToString().Substring(4, 2); }

            int showdate;
            int showdate1;
            if (currentYM.ToString().Substring(4, 2) == "11")
            {
                showdate1 = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "01");
            }
            else if (currentYM.ToString().Substring(4, 2) == "12")
            {
                showdate1 = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "02");
            }
            else
            {
                showdate1 = currentYM + 2;
            }

            if (dueYM.ToString().Substring(4, 2) == "11")
            {
                showdate = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "01");
            }
            else if (dueYM.ToString().Substring(4, 2) == "12")
            {
                showdate = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "02");
            }
            else
            {
                showdate = dueYM + 2;
            }

            if (clmtyp == "DOC")
            {
                string exsurenSel = "select EXTTBL,EXTCOM,EXTMD,EXTSUM from LPHS.EXSURREN where EXTPOL=" + polno + "";
                if (dm.existRecored(exsurenSel) != 0)
                {
                    dm.readSql(exsurenSel);
                    OracleDataReader exsurenReader = dm.oraComm.ExecuteReader();
                    while (exsurenReader.Read())
                    { 
                        if (!exsurenReader.IsDBNull(0)) { TBL = exsurenReader.GetInt32(0); } else { TBL = 0; }
                        if (!exsurenReader.IsDBNull(1)) { COM = exsurenReader.GetInt32(1); } else { COM = 0; }
                        if (!exsurenReader.IsDBNull(2)) { MOD = exsurenReader.GetInt32(2); } else { MOD = 0; }
                        if (!exsurenReader.IsDBNull(3)) { SUM = exsurenReader.GetDouble(3); } else { SUM = 0; }
                    }
                }
            }

            string lpolhisSel = "select phsta,phtbl,PHCOM,PHMOD,PHSUM from lphs.lpolhis where phpol=" + polno + " and phtyp='D' and phmos='M'";
            if (dm.existRecored(lpolhisSel) != 0)
            {
                dm.readSql(lpolhisSel);
                OracleDataReader lpolhisReader = dm.oraComm.ExecuteReader();
                while (lpolhisReader.Read())
                {
                    if (!lpolhisReader.IsDBNull(0)) { STA = lpolhisReader.GetString(0); } else { STA = ""; }
                    if (!lpolhisReader.IsDBNull(1)) { TBL = lpolhisReader.GetInt32(1); } else { TBL = 0; }
                    if (!lpolhisReader.IsDBNull(2)) { COM = lpolhisReader.GetInt32(2); } else { COM = 0; }
                    if (!lpolhisReader.IsDBNull(3)) { MOD = lpolhisReader.GetInt32(3); } else { MOD = 0; }
                    if (!lpolhisReader.IsDBNull(4)) { SUM = lpolhisReader.GetDouble(4); } else { SUM = 0; }
                }
            }

            #region ------- Create non existing liable dues -------


            string dthrefsel = "select SMASS_PVAL, DRCLMNO, APRVDATE, IS_FUTUER_PAYMENT from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='M'";
            if (dm.existRecored(dthrefsel) != 0)
            {
                dm.readSql(dthrefsel);
                OracleDataReader dthRefReader = dm.oraComm.ExecuteReader();
                while (dthRefReader.Read())
                {
                    if (!dthRefReader.IsDBNull(0)) { paidUpValue = dthRefReader.GetDouble(0); } else { paidUpValue = 0.0; }
                    if (!dthRefReader.IsDBNull(1)) { clmno = dthRefReader.GetInt32(1); } else { clmno = 0; }
                    if (!dthRefReader.IsDBNull(2)) { memoAprvDate = dthRefReader.GetInt32(2); } else { memoAprvDate = 0; }
                    if (!dthRefReader.IsDBNull(3)) { isFuturePayment = dthRefReader.GetString(3); } else { isFuturePayment = ""; }
                }
            }

            //Task 30176 - Restric the table 46 also.
            //if (TBL == 38)
            //{
            //    throw new Exception("Table 38 payment cann't done this system! Please contact Maturity Department.");
            //}
            if (TBL == 38 || TBL == 46)
            {
                throw new Exception("Table " + TBL + " payment cann't done this system! Please contact Maturity Department.");
            }

            if (isFuturePayment == "N")
            {
                dm.oraConn.Dispose();
                throw new Exception("No future Payment for this policy!");
            }
            else
            {
                if (STA == "L" && (TBL == 39 || TBL == 49) && memoAprvDate > 20130327) //Table 39 and 49 paid up values
                {
                    lpolobj = new lpolhisread(polno);
                    COM = lpolobj.Commence;

                    string dthintsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DMOS='M'";
                    if (dm.existRecored(dthintsel) != 0)
                    {
                        dm.readSql(dthintsel);
                        OracleDataReader dthIntReader = dm.oraComm.ExecuteReader();
                        while (dthIntReader.Read())
                        {
                            if (!dthIntReader.IsDBNull(0)) { dateofdth = dthIntReader.GetInt32(0); } else { dateofdth = 0; }
                        }
                    }

                    PAYAMT = paidUpValue * .15;

                    int maturtyYM = int.Parse(maturity.Substring(0, 6));
                    int dateOfDthYM = int.Parse(dateofdth.ToString().Substring(0, 6));
                    int nextDue = this.nextDuelaps(dateofdth, COM);

                    #region ------- Create non existing liable dues -------
                    string maxNextDueSel = "select max(payment_due), max(next_due),INTIMNO, LIFE_TYP from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' group by INTIMNO, LIFE_TYP";
                    string s2 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO='" + clmno + "' and CLMTYPE = '" + clmtyp + "' and LIFE_TYP = 'M' and PAYMENT_DUE=" + nextDue + "";

                    if (showdate1 < dueYM) { throw new Exception("Cannot Create Future Dues! Please Enter Current or Past Due YM."); } // if not a future due
                    else
                    {
                        if (dm.existRecored(maxNextDueSel) != 0)
                        {
                            dm.readSql(maxNextDueSel);
                            OracleDataReader dueReader = dm.oraComm.ExecuteReader();
                            while (dueReader.Read())
                            {
                                if (!dueReader.IsDBNull(0)) { maxPaymntdue = dueReader.GetInt32(0); } else { maxPaymntdue = 0; }
                                if (!dueReader.IsDBNull(1)) { maxNextdue = dueReader.GetInt32(1); } else { maxNextdue = 0; }
                                if (!dueReader.IsDBNull(2)) { clmno = int.Parse(dueReader.GetString(2)); } else { clmno = 0; }
                                if (!dueReader.IsDBNull(3)) { lifeType = dueReader.GetString(3); } else { lifeType = ""; }
                            }
                            dueReader.Close();
                        }

                        if (dm.existRecored(s2) == 0)
                        {
                            while (int.Parse(maxPaymntdue.ToString()) <= showdate1)
                            {
                                if (maturtyYM < maxPaymntdue) { break; }

                                //yyyy
                                
                                int dthYear= int.Parse(dateofdth.ToString().Substring(0, 4));
                                int dthMonth = int.Parse(dateofdth.ToString().Substring(4, 2));
                                int dthDate = int.Parse(dateofdth.ToString().Substring(6, 2));
                               
                                int comYear = int.Parse(COM.ToString().Substring(0, 4));
                                int comMonth = int.Parse(COM.ToString().Substring(4, 2));
                                int comDate = int.Parse(COM.ToString().Substring(6, 2));

                                string s1 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO='" + clmno + "' and CLMTYPE = '" + clmtyp + "' and LIFE_TYP = 'M' and PAYMENT_DUE=" + nextDue + "";
                                if (dm.existRecored(s1) == 0)
                                {
                                    if (dthMonth == comMonth)
                                    {

                                        if (dthDate <= comDate)
                                        {
                                            string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + nextDue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                            dm.insertRecords(periodicinsert);
                                        }
                                        else if (maturtyYM >= nextDue)
                                        {
                                            string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + nextDue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                            dm.insertRecords(periodicinsert);
                                        }
                                    }
                                    else
                                    {

                                        string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + nextDue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                        dm.insertRecords(periodicinsert);

                                    }
                                }
                                //--yyyy

                                //periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + nextDue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";

                                //dm.insertRecords(periodicinsert);

                                maxPaymntdue = this.nextDue(1, nextDue, 1);
                                nextDue = maxPaymntdue;

                                //if (nextDue == maturtyYM)
                                //{
                                //    //BonusCal totalBonus = new BonusCal();
                                //    //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                                //    General gg = new General();
                                //    gg.minumuthulapsepayment(polno, "M", dm);
                                //    double totbonus = gg.Bonus;
                                //    PAYAMT = PAYAMT + totbonus;
                                //    //------------------------------------
                                //    //???????????add calculated value for paid amount.
                                //    //------------------------------------------                            
                                //}
                            }
                        }

                        while (int.Parse(maxPaymntdue.ToString()) <= showdate1)
                        {
                            string s1 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO='" + clmno + "' and CLMTYPE = '" + clmtyp + "' and LIFE_TYP = 'M' and PAYMENT_DUE=" + maxPaymntdue + "";
                            if (maturtyYM < maxPaymntdue) { break; }
                            if (dm.existRecored(s1) == 0)
                            {
                                string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + maxPaymntdue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                dm.insertRecords(periodicinsert);
                            }
                            maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);
                            //nextDue = maxPaymntdue;

                            //if (nextDue == maturtyYM)
                            //{
                            //    //BonusCal totalBonus = new BonusCal();
                            //    //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                            //    General gg = new General();
                            //    gg.minumuthulapsepayment(polno, "M", dm);
                            //    double totbonus = gg.Bonus;
                            //    PAYAMT = PAYAMT + totbonus;
                            //    //------------------------------------
                            //    //???????????add calculated value for paid amount.
                            //    //------------------------------------------                            
                            //}
                        }

                    }
                    #endregion
                    //if (STA == "L" && (TBL == 39 || TBL == 49) && memoAprvDate > 20130327) //Table 39 and 49 paid up values
                    //{
                    #region--------- Paydet Select --------------------------
                    int count = 0;

                    //int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
                    string paydetSel = "select PAYMENT_DUE, PAID_AMT from lclm.PERIODIC_PAYDET where POLNO = " + polno + "  and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE <= " + showdate + " and (vono is null or vono = '' or vono = 'XXXX') ";
                    if (dm.existRecored(paydetSel) != 0)
                    {
                        vouIndexes = new ArrayList();
                        dm.readSql(paydetSel);
                        OracleDataReader paydetReader = dm.oraComm.ExecuteReader();
                        int matdate = int.Parse(mat_date.ToString().Substring(0, 6));
                        while (paydetReader.Read())
                        {
                            if (count == 0) { this.createDuesTable(paymntDue, PAYAMT, count,BONUS,PAYAMT1); }
                            count++;
                            if (!paydetReader.IsDBNull(0))
                            {
                                paymntDue = paydetReader.GetInt32(0);
                               
                            }
                            else {
                                paymntDue = 0;
                            }
                            if (!paydetReader.IsDBNull(1)) { PAYAMT = paydetReader.GetDouble(1); }
                            PAYAMT1 = PAYAMT;
                            if (paymntDue == matdate)
                            {
                                //BonusCal totalBonus = new BonusCal();
                                //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                                //General gg = new General();
                                //gg.minumuthulapsepayment(polno, "M", dm);
                                //double totbonus = gg.Bonus;
                                bcal = new BonusCal();
                                double totbonus = bcal.MinimuthuBonusCal(mat_date, COM, MOD, "L", TBL, SUM, polno)[2];
                                PAYAMT1 = PAYAMT;
                                PAYAMT = PAYAMT + totbonus;
                                BONUS = totbonus;
                                
                                //------------------------------------
                                //???????????add calculated value for paid amount.
                                //------------------------------------------                            
                            }
                            
                            this.createDuesTable(paymntDue, PAYAMT, count, BONUS, PAYAMT1);
                            vouIndexes.Add(paymntDue.ToString());
                        }
                        paydetReader.Close();
                    }
                    
                    //yyyy
                    else
                    {
                        dm.oraConn.Dispose();
                        throw new Exception("Voucher/s Already Created or no such Dues");
                    }
                    //--yyyy
                    
                    #endregion

                }
                else
                {
                    string maxNextDueSel1 = "select max(payment_due), max(next_due),INTIMNO, LIFE_TYP from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' group by INTIMNO, LIFE_TYP";
                    if (dm.existRecored(maxNextDueSel1) != 0)
                    {
                        dm.readSql(maxNextDueSel1);
                        OracleDataReader dueReader = dm.oraComm.ExecuteReader();
                        while (dueReader.Read())
                        {
                            if (!dueReader.IsDBNull(0)) { maxPaymntdue = dueReader.GetInt32(0); } else { maxPaymntdue = 0; }
                            if (!dueReader.IsDBNull(1)) { maxNextdue = dueReader.GetInt32(1); } else { maxNextdue = 0; }
                            if (!dueReader.IsDBNull(2)) { clmno = int.Parse(dueReader.GetString(2)); } else { clmno = 0; }
                            if (!dueReader.IsDBNull(3)) { lifeType = dueReader.GetString(3); } else { lifeType = ""; }
                        }
                        dueReader.Close();
                        //dueReader.Dispose();
                        //string poldetlSel = "select INTIMNO, LIFE_TYP from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = 'DTC'";
                        //dm.readSql(poldetlSel);
                        //OracleDataReader poldetReader = dm.oraComm.ExecuteReader();
                        //while (poldetReader.Read())
                        //{
                        //    if (!dueReader.IsDBNull(0)) { clmno = dueReader.GetInt32(0); } else { clmno = 0; }
                        //    if (!dueReader.IsDBNull(1)) { lifeType = dueReader.GetString(1); } else { lifeType = ""; }
                        //}
                        //poldetReader.Close();

                        if (maxPaymntdue <= showdate1)//maxPaymntdue))
                        {
                            if (showdate1 < dueYM) { throw new Exception("Cannot Create Future Dues! Please Enter Current or Past Due YM."); } // if not a future due
                            else
                            {
                            a:
                                //maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);

                                //while (int.Parse (maxPaymntdue.ToString()+mat_date.ToString ().Substring(6,2)) <= int.Parse (this.setDate()[0]))
                                while (int.Parse(maxPaymntdue.ToString()) <= showdate1)
                                {
                                    string s1 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE=" + maxPaymntdue + "";
                                    string payamountsel = "select distinct PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='" + clmno + "' and CLMTYPE='" + clmtyp + "'";
                                    if (dm.existRecored(payamountsel) != 0)
                                    {
                                        OracleDataReader periodicpayreader = dm.oraComm.ExecuteReader();
                                        periodicpayreader.Read();
                                        if (!periodicpayreader.IsDBNull(0)) { PAYAMT = periodicpayreader.GetDouble(0); } else { PAYAMT = 0; }
                                        periodicpayreader.Close();
                                        //periodicpayreader.Dispose();
                                    }

                                    //string deletedues="delete from 
                                    //maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);
                                    // maturity check 
                                    int matdateYM = int.Parse(mat_date.ToString().Substring(0, 6));
                                    if (matdateYM < maxPaymntdue) { break; }
                                    if (dm.existRecored(s1) == 0)
                                    {
                                        string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + maxPaymntdue + ", " + PAYAMT + ",'DTH','" + lifeType + "','" + clmno + "' )";
                                        dm.insertRecords(periodicinsert);
                                    }
                                    maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);
                                    //if (matdateYM < maxNextdue) { this.lblmessage.Text = "Policy will be Matured by the Next Due"; break; }

                                    // completion check
                                    //int pymnt_end_dtYM = matdateYM;//int.Parse(pymnt_end_dt.ToString().Substring(0, 6));
                                    //if (pymnt_end_dtYM == maxNextdue) { break; }
                                    //if (pymnt_end_dtYM < maxNextdue) { this.lblmessage.Text = "Part Settlements will be Completed by the Next Due"; break; }
                                }
                            }
                        }
                    }
            #endregion

                    #region ------- periodic_pay_det -------

                    //Dues table should be created before one month of due date.
                    int count = 0;

                    //int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
                    string paydetSel = "select PAYMENT_DUE, PAID_AMT from lclm.PERIODIC_PAYDET where POLNO = " + polno + "  and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE <= " + showdate + " and (vono is null or vono = '' or vono = 'XXXX') ";
                    if (dm.existRecored(paydetSel) != 0)
                    {
                        vouIndexes = new ArrayList();
                        dm.readSql(paydetSel);
                        OracleDataReader paydetReader = dm.oraComm.ExecuteReader();
                        int matdate = int.Parse(mat_date.ToString().Substring(0, 6));
                        while (paydetReader.Read())
                        {
                            if (count == 0) { this.createDuesTable(paymntDue, PAYAMT, count,BONUS,PAYAMT1); }
                            count++;
                            if (!paydetReader.IsDBNull(0)) { paymntDue = paydetReader.GetInt32(0); } else { paymntDue = 0; }
                            if (!paydetReader.IsDBNull(1)) { PAYAMT = paydetReader.GetInt32(1); }
                            PAYAMT1 = PAYAMT;
                            if (paymntDue == matdate)
                            {
                                isFinalPay = true;
                                //BonusCal totalBonus = new BonusCal();
                                //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                                General gg = new General();

                                if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49) && (memoAprvDate > 20140410 || mat_date > 20140410))//Task 22225
                                {
                                    bcal = new BonusCal();

                                    interimbonus = bcal.MinimuthuBonusCal(mat_date, COM, MOD, "I", TBL, SUM, polno)[0];
                                    vestedbonus = bcal.MinimuthuBonusCal(mat_date, COM, MOD, "I", TBL, SUM, polno)[1];
                                    double totbonus = bcal.MinimuthuBonusCal(mat_date, COM, MOD, "I", TBL, SUM, polno)[2];
                                    PAYAMT1 = PAYAMT;
                                    PAYAMT = PAYAMT + totbonus;
                                    BONUS = totbonus;
                                }
                                else
                                {
                                    gg.minumuthulapsepayment(polno, "M", dm);
                                    double totbonus = gg.Bonus;
                                    PAYAMT1 = PAYAMT;
                                    PAYAMT = PAYAMT + totbonus;
                                    BONUS = totbonus;
                                }
                               
                                //------------------------------------
                                //???????????add calculated value for paid amount.
                                //------------------------------------------                            
                            }
                            this.createDuesTable(paymntDue, PAYAMT, count, BONUS, PAYAMT1);
                            vouIndexes.Add(paymntDue.ToString());
                        }
                        paydetReader.Close();
                        //paydetReader.Dispose();

                        //statCount = count;
                    }
                    else
                    {
                        dm.oraConn.Dispose();
                        throw new Exception("Voucher/s Already Created or no such Dues");
                    }
                }
            }
            #endregion

            #region -----------------Date of Death--------------------
            string dateofdeathsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DCLM=" + clmno + "";
            if (dm.existRecored(dateofdeathsel) != 0)
            {
                OracleDataReader dthintread = dm.oraComm.ExecuteReader();
                while (dthintread.Read())
                {
                    if (!dthintread.IsDBNull(0)) { dateofdth = dthintread.GetInt32(0); } else { dateofdth = 0; }
                }
                dthintread.Close();
                //dthintread.Dispose();
            }
            else
            {
                string dateofdeathse2 = "Select DTOFDTH from LPHS.DTH_CHILDPROT_OUT WHERE POLNO=" + polno + "";// AND CLAIMNO=" + clmno + "
                if (dm.existRecored(dateofdeathse2) != 0)
                {
                    OracleDataReader dthintread = dm.oraComm.ExecuteReader();
                    while (dthintread.Read())
                    {
                        if (!dthintread.IsDBNull(0)) { dateofdth = dthintread.GetInt32(0); } else { dateofdth = 0; }
                    }
                    dthintread.Close();
                    //dthintread.Dispose();
                }
            }
            #endregion

            #region------------Print values on lables---------

            this.lblpolno.Text = polno.ToString();
            this.lblmatdate.Text = mat_date.ToString().Substring(0, 4) + "/" + mat_date.ToString().Substring(4, 2) + "/" + mat_date.ToString().Substring(6, 2);
            this.lblclmno.Text = clmno.ToString();
            this.lbldtofdeath.Text = dateofdth.ToString().Substring(0, 4) + "/" + dateofdth.ToString().Substring(4, 2) + "/" + dateofdth.ToString().Substring(6, 2);

            #endregion

            ViewState["memoAprvDateQstr"] = memoAprvDate; 
            ViewState["payMod"] = MOD;
            ViewState["sumAss"] = SUM;
        }
        catch (Exception ex)
        {
            //dm.rollback();
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }

    protected void btnVouCr_Click(object sender, EventArgs e)
    {
        lpolobj = new lpolhisread(polno);
        COM = lpolobj.Commence;
        int flag = 0;
        try
        {
            int i = 0;
            foreach (string vouindex in vouIndexes)
            {
                string xx;
                i++;
                paymntDue = int.Parse(vouindex);
                string chk = "chk" + i;
                CheckBox chkVouOK = new CheckBox();
                chkVouOK = (CheckBox)Table1.FindControl(chk);
                if ((chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                {
                    xx = "XXXX";
                }
                else
                {
                    xx = "";
                }
                string paydetUpd = "update LCLM.PERIODIC_PAYDET set vono = '" + xx + "' where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE = " + paymntDue + " and (vono is null or vono = '' or vono='XXXX') ";
                dm.insertRecords(paydetUpd);                
            }

            if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49) && memoAprvDate > 20140410 && isFinalPay)//Task 22225
            {
                string updateDthRef = "update LPHS.DTHREF set DRVESTEDBON=" + vestedbonus + " , DRINTERIMBON=" + interimbonus + " where DRPOLNO=" + polno + " and DRCLMNO=" + clmno + " ";
                dm.insertRecords(updateDthRef);
            }


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
        if (flag != 1)
        {
            int matdate = int.Parse(mat_date.ToString().Substring(0, 6));
            Response.Redirect("~/ChildProt/childProtPay003.aspx?polino=" + polno + "&maturity=" + matdate + "&matu_date=" + mat_date + "&com=" + COM + "&tbl=" + TBL + "&memoAprvDate=" + memoAprvDate + "&vestedbonus=" + vestedbonus + "&interimbonus=" + interimbonus + "&sta=" + STA + "");
        }
    }
    private void createDuesTable(int Due, double payamt, int count,double bonus,double amt)
    {
        TableRow trow01 = new TableRow();
        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel13 = new TableCell();
        TableCell tcel14 = new TableCell();
        TableCell tcel15 = new TableCell();
        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl14 = new Label();
        Label lbl15 = new Label();
        CheckBox chk01 = new CheckBox();

        chk01.ID = "chk" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + count); //Text Value

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

        lbl14.ID = "bonus" + count;
        lbl14.Attributes.Add("runat", "Server");
        lbl14.Attributes.Add("Name", "bonus" + count); //Text Value
        if (count == 0) { lbl14.Text = "Bonus"; }
        else { lbl14.Text = String.Format("{0:N}", bonus); }

        lbl15.ID = "amt" + count;
        lbl15.Attributes.Add("runat", "Server");
        lbl15.Attributes.Add("Name", "amt" + count); //Text Value
        if (count == 0) { lbl15.Text = "Amount"; }
        else { lbl15.Text = String.Format("{0:N}", amt); }

        tcel11.Controls.Add(lbl11);
        tcel15.Controls.Add(lbl15);
        tcel14.Controls.Add(lbl14);
        tcel12.Controls.Add(lbl12);
        if (count > 0) { tcel13.Controls.Add(chk01); }

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel15);
        trow01.Cells.Add(tcel14);
        trow01.Cells.Add(tcel12);
        trow01.Cells.Add(tcel13);

        Table1.Rows.Add(trow01);

    }
    protected int nextDue(int mod, int lastDue, int premCount)
    {
        int lastDueYear = int.Parse(lastDue.ToString().Substring(0, 4));
        int lastDueMonth = int.Parse(lastDue.ToString().Substring(4, 2));
        int nextDueYear = 0;
        int nextDueMonth = 0;
        int nextDueYM = 0;
        int x = 0;

        x = 12;


        int monthCount = premCount * x;
        if (monthCount >= 12)
        {
            int years = (int)Math.Floor((decimal)(monthCount / 12));
            int months = monthCount % 12;

            nextDueMonth = lastDueMonth + months;
            nextDueYear = lastDueYear + years;
            if (nextDueMonth > 12)
            {
                nextDueMonth -= 12;
                nextDueYear++;
            }
            if (nextDueMonth < 10)
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + "0" + nextDueMonth.ToString());
            }
            else
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + nextDueMonth.ToString());
            }
        }
        else
        {
            nextDueMonth = lastDueMonth + monthCount;
            nextDueYear = lastDueYear;
            if (nextDueMonth > 12)
            {
                nextDueMonth -= 12;
                nextDueYear++;
            }
            if (nextDueMonth < 10)
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + "0" + nextDueMonth.ToString());
            }
            else
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + nextDueMonth.ToString());
            }
        }


        return nextDueYM;
    }

    protected int nextDuelaps(int dateOfDth, int polComDate)
    {
        int dthYear = int.Parse(dateOfDth.ToString().Substring(0, 4));
        int dthMonth = int.Parse(dateOfDth.ToString().Substring(4, 2));
        int dthDay = int.Parse(dateOfDth.ToString().Substring(6, 2));

        int comYear = int.Parse(polComDate.ToString().Substring(0, 4));
        int comMonth = int.Parse(polComDate.ToString().Substring(4, 2));
        int comDay = int.Parse(polComDate.ToString().Substring(6, 2));

        int nextDueYr = 0;
        int nextDueMth = 0; 

        int nextDuYM = 0;

        if (dthMonth < comMonth || ((dthMonth == comMonth) && (dthDay <= comDay)))
        {
            nextDueYr = dthYear;
            nextDueMth = comMonth;

            if (nextDueMth < 10)
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + "0" + nextDueMth.ToString());
            }
            else
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + nextDueMth.ToString());
            }


            

            //if (nextDueMth < 10)
            //{
            //    nextDuYM = int.Parse(nextDueYr.ToString() + "0" + nextDueMth.ToString());
            //}
            //else
            //{
            //    nextDuYM = int.Parse(nextDueYr.ToString() + nextDueMth.ToString());
            //}
        }
        else
        {
            dthYear++;
            nextDueYr = dthYear;
            nextDueMth = comMonth;

            if (nextDueMth < 10)
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + "0" + nextDueMth.ToString());
            }
            else
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + nextDueMth.ToString());
            }
        }
        return nextDuYM;
    }

    public void Dueselect(int polno)
    {
        try
        {

            int i = 0;
            string xx = "";
            foreach (string vouindex in vouIndexes)
            {
                i++;
                paymntDue = int.Parse(vouindex);
                string chk = "chk" + i;
                CheckBox chkVouOK = new CheckBox();
                chkVouOK = (CheckBox)Table1.FindControl(chk);
                if ((chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                {
                    xx = "XXXX";
                }
                string paydetUpd = "update LCLM.PERIODIC_PAYDET set vono = '" + xx + "' where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE = " + paymntDue + " and (vono is null or vono = '') ";
                dm.insertRecords(paydetUpd);
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


    public void discharge(int polno)
    {
        dm = new DataManager();
        try
        {

            int i = 0;
            foreach (string vouindex in vouIndexes)
            {
                i++;
                paymntDue = int.Parse(vouindex);
                string chk = "chk" + i;
                CheckBox chkVouOK = new CheckBox();
                chkVouOK = (CheckBox)Table1.FindControl(chk);
                if ((chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                {
                    string paydetUpd2 = "update LCLM.PERIODIC_PAYDET set DISCHARGE = 1 where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE = " + paymntDue + " ";
                    dm.insertRecords(paydetUpd2);
                }
                
                
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



    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }

    public int Claimno
    {
        get { return clmno; }
        set { clmno = value; }
    } 

    public int MemAprDate
    {
        get { return memoAprvDate; }
        set { memoAprvDate = value; }
    }

    public int PayMod
    {
        get { return MOD; }
        set { clmno = value; }
    }

    public double SumAss
    {
        get { return SUM; }
        set { SUM = value; }
    }

    public double TotAmount
    {
        get { return totAmount; }
        set { totAmount = value; }
    }
    protected void btnDischgsin_Click(object sender, EventArgs e)
    {
        Dueselect(polno);
        //discharge(polno);
        //Server.Transfer("",true);
    }

    protected void btnDischgeng_Click(object sender, EventArgs e)
    {
        Dueselect(polno);
        //discharge(polno);
        //Server.Transfer("",true);
    }

    protected void btnCerressin_Click(object sender, EventArgs e)
    {
        Dueselect(polno);
        //Server.Transfer("",true);
    }
    protected void btnCerreseng_Click(object sender, EventArgs e)
    {
        Dueselect(polno);
        //Response.Redirect("~/letters/minimuthueng001.aspx?polino=" + polno + "&lifeType=" + lifeType + "", false);
        //Server.Transfer("",true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        discharge(polno);
        Response.Redirect("~/letters/CoveringLetter-MiniuthuSinhala001.aspx?polino=" + polno + "&lifeType=" + lifeType + "&SignatureDisplay=" + SignatureDisplay + "", false);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        discharge(polno);
        Response.Redirect("~/letters/CoveringLetter-MinimuthuEnglish001.aspx?polino=" + polno + "&lifeType=" + lifeType + " &SignatureDisplay=" + SignatureDisplay +"", false);
    }

    protected void ChkSig(object sender, EventArgs e)
    {
        if (Signature.Checked)
        {
            SignatureDisplay = true;
        }
    }
}
