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

public partial class childProtPay002 : System.Web.UI.Page
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
    BonusCal bonuscalc;
    BankDetailsBreak bdb;

    private int polno;
    private int tbl;
    private int clmno;
    private int nextDue;
    private int paymntcnt;
    private string payee;
    private double payamt;
    private double amt;
    private double bonus = 0;
    private string phname;
    private string NOMNAME;
    private string NOMAD1;
    private string NOMAD2, NOMAD3, NOMAD4;
    private string EPF;
    private string vouno, clmtyp;
    private int branch;
    private int mat_date;
    private int payDue;
    private int COM;
    private int memoApprDate;
    private int MOD;
    private double SUM;
    private int matDate;
    private string namewithins;
    private int nomineeCount;
    private int NOMNUM = 0;
    public string STA;
    private int childDOB;
    private int nomNo = 0;
    private int childNomAge = 0;
    private bool ischildNomAge = false;

    private static CompanyVouFields cvf = new CompanyVouFields();
    private ArrayList arrList;

    BonusCal bcal;
    General gg;

    protected void Page_Load(object sender, EventArgs e)
    {
        //branch = 10;
        //EPF = "06664";
        if (Session["EPFNum"] != null || Session["brcode"] != null)
        {
            EPF = Session["EPFNum"].ToString();
            branch = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            Response.Redirect("~/SessionError.aspx", false);
        }


        try
        {

        string heireAd = "";
        dm = new DataManager();
        if (!Page.IsPostBack)
        {

            //try
            //{
            if (Request.QueryString["polino"] != null)
            {
                polno = int.Parse(Request.QueryString["polino"].ToString());
                ViewState.Add("polnoQstr", polno.ToString());
            }
            if (Request.QueryString["maturity"] != null)
            {
                mat_date = int.Parse(Request.QueryString["maturity"].ToString());
                ViewState.Add("maturityQstr", mat_date.ToString());
            }
            if (Request.QueryString["com"] != null)
            {
                COM = int.Parse(Request.QueryString["com"].ToString());
                ViewState.Add("comQstr", COM.ToString());
            }
            if (Request.QueryString["sta"] != null)
            {
                STA = Request.QueryString["sta"].ToString();
            }
            clmtyp = "DTC";
            //if (Request.QueryString["table"] != null)
            //{
            //    tbl = int.Parse(Request.QueryString["table"].ToString());
            //    ViewState.Add("tblQstr", tbl.ToString());
            //}
            if (Request.QueryString["memoAprvDate"] != null)
            {
                memoApprDate = int.Parse(Request.QueryString["memoAprvDate"].ToString());
                ViewState.Add("memoAprvDateQstr", memoApprDate.ToString());
            }
            if (Request.QueryString["matu_date"] != null)
            {
                matDate = int.Parse(Request.QueryString["matu_date"].ToString());
                ViewState.Add("matDateQstr", matDate.ToString());
            }
            this.lblpolno.Text = polno.ToString();

            #region // ************** PHNAME  **********************

            DataManager lsurefobj = new DataManager();

            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            lsurefobj.readSql(sql);
            OracleDataReader oraDtReader = lsurefobj.oraComm.ExecuteReader();

            bool flag = false;

            while (oraDtReader.Read())
            {
                //if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(2)))
                {
                    flag = true;
                    if (oraDtReader.IsDBNull(1))
                    {
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(2);
                    }
                    else
                    {
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                    }
                }
                else { phname = ""; }

            }
            oraDtReader.Close();

            this.lblphname.Text = phname;

            #endregion


            string dthrefsel = "select payee, drclmno from lphs.dthref where drpolno = " + polno + "";
            string childprotoutsel = "select CLAIMNO, PAYNAM, AD1, AD2, AD3, AD4 from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + "";
            if (dm.existRecored(dthrefsel) != 0)
            {
                dm.readSql(dthrefsel);
                OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                while (dthrefreader.Read())
                {
                    if (!dthrefreader.IsDBNull(0)) { payee = dthrefreader.GetString(0); } else { payee = ""; }
                    if (!dthrefreader.IsDBNull(1)) { clmno = dthrefreader.GetInt32(1); } else { clmno = 0; }
                }
                dthrefreader.Close();
            }
            else if (dm.existRecored(childprotoutsel) != 0)
            {
                dm.readSql(childprotoutsel);
                OracleDataReader childprotreader = dm.oraComm.ExecuteReader();
                while (childprotreader.Read())
                {
                    if (!childprotreader.IsDBNull(0)) { clmno = childprotreader.GetInt32(0); } else { clmno = 0; }
                    if (!childprotreader.IsDBNull(1)) { NOMNAME = childprotreader.GetString(1); } else { NOMNAME = ""; }
                    if (!childprotreader.IsDBNull(2)) { NOMAD1 = childprotreader.GetString(2); } else { NOMAD1 = ""; }
                    if (!childprotreader.IsDBNull(3)) { NOMAD2 = childprotreader.GetString(3); } else { NOMAD2 = ""; }
                    if (!childprotreader.IsDBNull(4)) { NOMAD3 = childprotreader.GetString(4); } else { NOMAD3 = ""; }
                    if (!childprotreader.IsDBNull(5)) { NOMAD4 = childprotreader.GetString(5); } else { NOMAD4 = ""; }
                    payee = "OUT";
                    clmtyp = "DOC";
                }
                childprotreader.Close();
            }

            else { throw new Exception("No Death Reference Record"); }

            if (clmtyp == "DOC")
            {
                string exsurenSel = "select EXTTBL,EXTCOM,EXTMD,EXTSUM from LPHS.EXSURREN where EXTPOL=" + polno + "";
                if (dm.existRecored(exsurenSel) != 0)
                {
                    dm.readSql(exsurenSel);
                    OracleDataReader exsurenReader = dm.oraComm.ExecuteReader();
                    while (exsurenReader.Read())
                    {
                        if (!exsurenReader.IsDBNull(0)) { tbl = exsurenReader.GetInt32(0); } else { tbl = 0; }
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
                    if (!lpolhisReader.IsDBNull(1)) { tbl = lpolhisReader.GetInt32(1); } else { tbl = 0; }
                    if (!lpolhisReader.IsDBNull(2)) { COM = lpolhisReader.GetInt32(2); } else { COM = 0; }
                    if (!lpolhisReader.IsDBNull(3)) { MOD = lpolhisReader.GetInt32(3); } else { MOD = 0; }
                    if (!lpolhisReader.IsDBNull(4)) { SUM = lpolhisReader.GetDouble(4); } else { SUM = 0; }
                }
            }
            //string child_masSel = "select pay_amt, nextdue, PAYMENT_COUNT from lclm.child_prot_mas where polno = " + polno + " and ptable = " + tbl + "";
            //if (dm.existRecored(child_masSel) != 0)
            //{
            //    dm.readSql(child_masSel);
            //    OracleDataReader child_masReader = dm.oraComm.ExecuteReader();
            //    while (child_masReader.Read())
            //    {
            //        if (!child_masReader.IsDBNull(0)) { payamt = child_masReader.GetDouble(0); } else { payamt = 0; }
            //        if (!child_masReader.IsDBNull(1)) { nextDue = child_masReader.GetInt32(1); } else { nextDue = 0; }
            //        if (!child_masReader.IsDBNull(2)) { paymntcnt = child_masReader.GetInt32(2); } else { paymntcnt = 0; }
            //    }
            //    child_masReader.Close();
            //}
            //else { throw new Exception("No Child Protection Master Details"); }

            #region------------------read selected dues from Periodic_paydet-----------
            string periodicpaydetsel = "select PAID_AMT, PAYMENT_DUE from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and VONO='XXXX'";
            if (dm.existRecored(periodicpaydetsel) != 0)
            {
                dm.readSql(periodicpaydetsel);
                OracleDataReader periodicpaydetread = dm.oraComm.ExecuteReader();
                payamt = 0;
                while (periodicpaydetread.Read())
                {
                    //if (!periodicpaydetread.IsDBNull(0)) { nextDue = periodicpaydetread.GetInt32(0); } else { nextDue = 0; }
                    if (!periodicpaydetread.IsDBNull(0)) { amt = periodicpaydetread.GetDouble(0); } else { amt = 0; }
                    if (!periodicpaydetread.IsDBNull(1)) { payDue = periodicpaydetread.GetInt32(1); } else { nextDue = 0; }
                    if (int.Parse(payDue.ToString() + COM.ToString().Substring(6, 2)) > int.Parse(this.setDate()[0]))
                    {
                        throw new Exception("Voucher cannot create for future dues!");
                    }
                    payamt += amt;
                    if (payDue == int.Parse(mat_date.ToString().Substring(0, 6)))
                    {
                        //bonuscalc = new BonusCal();
                        //bonus = bonuscalc.VestedBonus(polno, "M")[2];
                        if (STA == "L" && (tbl == 39 || tbl == 49) && memoApprDate > 20130327) //Table 39 and 49 paid up values
                        {
                            //General gg = new General();
                            //gg.minumuthulapsepayment(polno, "M", dm);
                            bcal = new BonusCal();
                            bonus = bcal.MinimuthuBonusCal(mat_date, COM, MOD, "L", tbl, SUM, polno)[2];
                            //bonus = gg.Bonus;
                            payamt += bonus;
                        }
                        else
                        {
                            if ((tbl == 34 || tbl == 38 || tbl == 39 || tbl == 46 || tbl == 49) && (memoApprDate > 20140410 || matDate > 20140410))//Task 22225
                            {
                                bcal = new BonusCal();

                                //if (clmtyp == "DOC")
                                //{
                                //    double totbonus = bcal.MinimuthuBonusCal(matDate, COM, MOD, "I", tbl, SUM, polno)[2];
                                //    payamt = payamt + totbonus;
                                //    bonus = totbonus;
                                //}
                                double totbonus = bcal.MinimuthuBonusCal(matDate, COM, MOD, "I", tbl, SUM, polno)[2];
                                payamt = payamt + totbonus;
                                bonus = totbonus;
                            }
                            else
                            {
                                General gg = new General();
                                gg.minumuthulapsepayment(polno, "M", dm);
                                bonus = gg.Bonus;
                                payamt += bonus;
                            }
                        }
                    }
                }
            }
            else { throw new Exception("Please Select Payment Due(s) Before Create Voucher!"); }
            #endregion
            #region -----check maturity--------------

            #endregion

            int yymm = int.Parse(setDate()[0].ToString().Substring(0, 6));
            //if (nextDue > yymm) { throw new Exception("No Existing Dues for This Policy!"); }
            this.txtnetClmAmt.Text = payamt.ToString();

            //ViewState["nextDue"] = nextDue;
            //ViewState["paymntcnt"] = paymntcnt;
            ViewState["clmno"] = clmno;
            ViewState["payamt"] = payamt;
            ViewState["vouno"] = vouno;
            ViewState["bonus"] = bonus;
            ViewState["phname"] = phname;
            ViewState["clmtyp"] = clmtyp;
            ViewState["EPF"] = EPF;
            ViewState["branch"] = branch;
            ViewState["nomineeCount"] = nomineeCount;
            ViewState["arrList"] = arrList;
            ViewState["payee"] = payee;
            ViewState["payDue"] = payDue;
            ViewState["nomnum"] = NOMNUM;
            ViewState["tbl"] = tbl;

            this.txtpayeename.Text = NOMNAME;
            this.txtad1.Text = NOMAD1;
            this.txtad2.Text = NOMAD2;
            this.txtad3.Text = NOMAD3;
            this.txtad4.Text = NOMAD4;

            //}
            //catch (Exception ex)
            //{
            //    dm.connClose();
            //    EPage.Messege = ex.Message;
            //    Response.Redirect("~/EPage.aspx");
            //}
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polno = int.Parse(ViewState["polnoQstr"].ToString()); }
            if (ViewState["maturityQstr"] != null) { mat_date = int.Parse(ViewState["maturityQstr"].ToString()); }
            //if (ViewState["tblQstr"] != null) { tbl = int.Parse(ViewState["tblQstr"].ToString()); }
            //if (ViewState["nextDue"] != null) { nextDue = int.Parse(ViewState["nextDue"].ToString()); }
            //if (ViewState["paymntcnt"] != null) { paymntcnt = int.Parse(ViewState["paymntcnt"].ToString()); }
            if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
            if (ViewState["payamt"] != null) { payamt = double.Parse(ViewState["payamt"].ToString()); }
            if (ViewState["vouno"] != null) { vouno = ViewState["vouno"].ToString(); }
            if (ViewState["bonus"] != null) { bonus = double.Parse(ViewState["bonus"].ToString()); }
            if (ViewState["phname"] != null) { phname = ViewState["phname"].ToString(); }
            if (ViewState["comQstr"] != null) { COM = int.Parse(ViewState["comQstr"].ToString()); }
            if (ViewState["clmtyp"] != null) { clmtyp = ViewState["clmtyp"].ToString(); }
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
            if (ViewState["branch"] != null) { branch = int.Parse(ViewState["branch"].ToString()); }
            if (ViewState["nomineeCount"] != null) { nomineeCount = int.Parse(ViewState["nomineeCount"].ToString()); }
            if (ViewState["arrList"] != null) { arrList = (ArrayList)ViewState["arrList"]; }
            if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
            if (ViewState["payDue"] != null) { payDue = int.Parse(ViewState["payDue"].ToString()); }
            if (ViewState["nomnum"] != null) { NOMNUM = int.Parse(ViewState["nomnum"].ToString()); }
            if (ViewState["tbl"] != null) { tbl = int.Parse(ViewState["tbl"].ToString()); }
        }

        #region ----- Nominee Count -------
        string nomCount = "select count(distinct(nomnam)) from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
        if (dm.existRecored(nomCount) != 0)
        {
            dm.readSql(nomCount);
            OracleDataReader nomineeCountReader = dm.oraComm.ExecuteReader();
            while (nomineeCountReader.Read())
            {
                if (!nomineeCountReader.IsDBNull(0)) { nomineeCount = nomineeCountReader.GetInt32(0); } else { nomineeCount = 0; }
            }
            nomineeCountReader.Close();
        }
        #endregion 

        #region ----- Task 26230 -------
        if (nomineeCount > 1 && ((!payee.Equals("OUT")) || tbl == 49))
        {
            string childDOBSelect = "select nomno,nomdob from LUND.NOMINEE  Where  POLNO =" + polno + " and nomdob in (select dob from LUND.POLPERSONAL where polno=" + polno + " and prpertype=4)";
            if (dm.existRecored(childDOBSelect) != 0)
            {
                dm.readSql(childDOBSelect);
                OracleDataReader childReader = dm.oraComm.ExecuteReader();
                while (childReader.Read())
                {
                    if (!childReader.IsDBNull(0)) { nomNo = childReader.GetInt32(0); } else { nomNo = 0; }
                    if (!childReader.IsDBNull(1)) { childDOB = childReader.GetInt32(1); } else { childDOB = 0; }
                }
                childReader.Close();
            } 

            if (childDOB > 0)
            {
                string yr = childDOB.ToString().Substring(0, 4);
                string mn = childDOB.ToString().Substring(4, 2);
                string dt = childDOB.ToString().Substring(6, 2);

                DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                DateTime today = DateTime.Now;
                TimeSpan diff = today.Subtract(Bdate);
                childNomAge = (int)diff.TotalDays / 365;

                if (childNomAge >= 18)
                {
                    ischildNomAge = true;
                }
            }
        }
        #endregion

        #region ----- payee -----
        //if (payee.Equals("NOM") || (payee.Equals("OUT") && nomineeCount > 1))
        //if (payee.Equals("NOM"))
        if (payee.Equals("NOM") || (nomineeCount > 1 && tbl==49))
        {
            double nomiShare = .0;
            double PER = 0.0;
            double totPercentage = 0.0;
            string paystatus = "";
            int recCount = 0;
            int okcount = 0;
            arrList = new ArrayList();

            //string nomCount = "select count(*) from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
            //string nomCount = "select count(distinct(nomnam)) from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
            //if (dm.existRecored(nomCount) != 0)
            //{
            //    dm.readSql(nomCount);
            //    OracleDataReader nomineeCountReader = dm.oraComm.ExecuteReader();
            //    while (nomineeCountReader.Read())
            //    {
            //        if (!nomineeCountReader.IsDBNull(0)) { nomineeCount = nomineeCountReader.GetInt32(0); } else { nomineeCount = 0; }
            //    }
            //    nomineeCountReader.Close();
            //}

            if (nomineeCount > 1)
            {
                //Task 26230
                //string nomSelect = "select NOMNO, NOMNAM, NOMPER, PAYSTATUS,NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                string nomSelect = "";
                if (ischildNomAge)
                {
                    nomSelect = "select NOMNO, NOMNAM, NOMPER, PAYSTATUS,NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.NOMINEE where POLNO = " + polno + " and nomdob = " + childDOB + " order by nomno ";
                }
                else
                {
                    nomSelect = "select NOMNO, NOMNAM, NOMPER, PAYSTATUS,NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                }

                if (dm.existRecored(nomSelect) != 0)
                {
                    dm.readSql(nomSelect);
                    OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomineeReader.Read())
                    {
                        if (!nomineeReader.IsDBNull(0)) { NOMNUM = nomineeReader.GetInt32(0); } else { NOMNUM = 0; }
                        if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); } else { NOMNAME = ""; }
                        if (!nomineeReader.IsDBNull(2)) { PER = nomineeReader.GetDouble(2); } else { PER = 0.00; }
                        if (!nomineeReader.IsDBNull(3)) { paystatus = nomineeReader.GetString(3); } else { paystatus = ""; }
                        if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); } else { NOMAD1 = ""; }
                        if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); } else { NOMAD2 = ""; }
                        if (!nomineeReader.IsDBNull(6)) { NOMAD3 = nomineeReader.GetString(6); } else { NOMAD3 = ""; }
                        if (!nomineeReader.IsDBNull(7)) { NOMAD4 = nomineeReader.GetString(7); } else { NOMAD4 = ""; }
                        NOMNUM = nomineeReader.GetInt32(0);

                        if (paystatus.Equals("OK")) { okcount++; }
                        recCount++;

                        //Task 26230
                        //totPercentage += PER;

                        //nomiShare = PER * payamt;

                        if (ischildNomAge)
                        {
                            PER = 100;
                            totPercentage = PER;
                            nomiShare = PER * payamt;
                        }
                        else
                        {
                            totPercentage += PER;
                            nomiShare = PER * payamt;
                        }

                        nomiShare = Math.Round(nomiShare, 4);
                        nomiShare = Math.Truncate(nomiShare);
                        nomiShare = nomiShare / 100;
                        string[] nomArr = new string[9];
                        nomArr[0] = NOMNAME;
                        nomArr[1] = PER.ToString();
                        nomArr[2] = NOMNUM.ToString();
                        nomArr[3] = nomiShare.ToString();
                        nomArr[4] = paystatus;
                        nomArr[5] = NOMAD1;
                        nomArr[6] = NOMAD2;
                        nomArr[7] = NOMAD3;
                        nomArr[8] = NOMAD4;

                        arrList.Add(nomArr);
                        //createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM);
                    }
                    nomineeReader.Close();
                    nomineeReader.Dispose();

                    if (totPercentage > 100)
                    {
                        dm.connclose();
                        throw new Exception("Please Adjust the Nominee Percentages so that Total Equals 100%");
                    }
                    else if (totPercentage < 100) { this.lblMessage.Text = "Total Percentage doesn't Add Up to Make 100%"; }

                    int rows3 = 0;
                    foreach (string[] nomArr in arrList)
                    {
                        rows3++;

                        if (!nomArr[0].Equals(null) && !nomArr[0].Equals("")) { NOMNAME = nomArr[0]; }
                        if (!nomArr[1].Equals(null) && !nomArr[1].Equals("")) { PER = double.Parse(nomArr[1]); }
                        if (!nomArr[2].Equals(null) && !nomArr[2].Equals("")) { NOMNUM = int.Parse(nomArr[2]); }
                        if (!nomArr[3].Equals(null) && !nomArr[3].Equals("")) { nomiShare = double.Parse(nomArr[3]); }
                        if (!nomArr[4].Equals(null) && !nomArr[4].Equals("")) { paystatus = nomArr[4]; }
                        if (!nomArr[5].Equals(null) && !nomArr[5].Equals("")) { NOMAD1 = nomArr[5]; }
                        if (!nomArr[6].Equals(null) && !nomArr[6].Equals("")) { NOMAD2 = nomArr[6]; }
                        if (!nomArr[7].Equals(null) && !nomArr[7].Equals("")) { NOMAD3 = nomArr[7]; }
                        if (!nomArr[8].Equals(null) && !nomArr[8].Equals("")) { NOMAD4 = nomArr[8]; }

                        this.createVouDetTable(NOMNAME, NOMAD1, NOMAD2, NOMAD3, NOMAD4, nomiShare, NOMNUM, "0", "Nominee");

                        string nomperiodicpaysel = "select * from LCLM.NOM_PERIODIC_PAYDET where NOM_NO=" + NOMNUM + " and POLICY_NO=" + polno + " and CLAIM_TYPE='" + clmtyp + "' and PAYMENT_DUE=" + payDue + "";
                        if (dm.existRecored(nomperiodicpaysel) == 0)
                        {
                            string periodicpayupd = "insert into LCLM.NOM_PERIODIC_PAYDET (NOM_NO, POLICY_NO, CLAIM_TYPE, PAYMENT_DUE," +
                                                    "DIS_CLM_TYPE, LIFE_TYPE, INTI_NO,VOU_NO,PAID_AMT) " +
                                                    "values (" + NOMNUM + "," + polno + ",'" + clmtyp + "'," + payDue + "," +
                                                    "'DTH','M','" + clmno + "','XXXX'," + nomiShare + ")";
                            dm.insertRecords(periodicpayupd);
                        }
                    }
                }
            }
            else
            {
                string nomSelect = "select NOMNAM, NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";

                if (dm.existRecored(nomSelect) != 0)
                {
                    dm.readSql(nomSelect);
                    OracleDataReader nomineeReader = dm.oraComm.ExecuteReader();
                    while (nomineeReader.Read())
                    {
                        if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); } else { NOMNAME = ""; }
                        if (!nomineeReader.IsDBNull(1)) { NOMAD1 = nomineeReader.GetString(1); } else { NOMAD1 = ""; }
                        if (!nomineeReader.IsDBNull(2)) { NOMAD2 = nomineeReader.GetString(2); } else { NOMAD2 = ""; }
                        if (!nomineeReader.IsDBNull(3)) { NOMAD3 = nomineeReader.GetString(3); } else { NOMAD3 = ""; }
                        if (!nomineeReader.IsDBNull(4)) { NOMAD4 = nomineeReader.GetString(4); } else { NOMAD4 = ""; }
                    }
                    nomineeReader.Close();
                }
            }
        }
        else if (payee.Equals("LHI"))
        {
            string heireSelect = "select lhname, lhad1, lhad2, lhad3, lhad4 from lphs.legal_hires where lhpolno=" + polno + " ";
            if (dm.existRecored(heireSelect) != 0)
            {
                dm.readSql(heireSelect);
                OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader();
                while (heireSelectReader.Read())
                {
                    if (!heireSelectReader.IsDBNull(0)) { NOMNAME = heireSelectReader.GetString(0); } else { NOMNAME = ""; }
                    if (!heireSelectReader.IsDBNull(1)) { NOMAD1 = heireSelectReader.GetString(1); } else { heireAd = ""; }
                    if (!heireSelectReader.IsDBNull(2)) { NOMAD2 = heireSelectReader.GetString(2); } else { NOMAD2 = ""; }
                    if (!heireSelectReader.IsDBNull(3)) { NOMAD3 = heireSelectReader.GetString(3); } else { NOMAD3 = ""; }
                    if (!heireSelectReader.IsDBNull(4)) { NOMAD4 = heireSelectReader.GetString(4); } else { NOMAD4 = ""; }
                }
                heireSelectReader.Close();
                //NOMAD2 = NOMAD2 + " " + NOMAD3;
                //if (heireAd.Length > 50) { NOMAD1 = heireAd.Substring(0, 50); NOMAD2 = heireAd.Substring(50, heireAd.Length - 50); }
                //else { NOMAD1 = heireAd; }
            }
        }
        else if (payee.Equals("ASI"))
        {
            string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, PAYSTATUS, VOUSTA, ASS_AD3 from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
            if (dm.existRecored(asiSelect) != 0)
            {
                dm.readSql(asiSelect);
                OracleDataReader prassReader = dm.oraComm.ExecuteReader();
                while (prassReader.Read())
                {
                    if (!prassReader.IsDBNull(3)) { NOMNAME = prassReader.GetString(3); }
                    if (!prassReader.IsDBNull(5)) { NOMAD1 = prassReader.GetString(5); }
                    if (!prassReader.IsDBNull(6)) { NOMAD2 = prassReader.GetString(6); }
                    if (!prassReader.IsDBNull(7)) { NOMAD3 = prassReader.GetString(7); }
                    //NOMAD2 = NOMAD2 + " " + NOMAD3;
                }
                prassReader.Close();
            }
        }
        else if (payee.Equals("LPT"))
        {
            string living_prtSelect = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, PAYSTATUS, VOUSTA from LUND.LIVING_PRT where polno = " + polno + "  ";
            if (dm.existRecored(living_prtSelect) != 0)
            {
                dm.readSql(living_prtSelect);
                OracleDataReader nomineeReader = dm.oraComm.ExecuteReader();
                while (nomineeReader.Read())
                {
                    if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); } else { NOMNAME = ""; }
                    if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); } else { NOMAD1 = ""; }
                    if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); } else { NOMAD2 = ""; }
                }
                nomineeReader.Close();
            }
        }
        else if (payee.Equals("OUT"))
        {
            //string childprotoutsel = "select PAYNAM, AD1, AD2, AD3, AD4 from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + "";
            //dm.readSql()
        }
        #endregion 

        dm.connClose();
        }
        catch (Exception ex)
        {
            dm.connClose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        //DataManager dmob = new DataManager();

        try
        {
            dm.begintransaction();
            string ACNUM = "";
            string BKNAM = "";
            string BKBRN = "";
            string SLIAcctNo = "";
            int count = 0;

            //if (nomineeCount > 1)
            if ((nomineeCount > 1) && (!payee.Equals("OUT") || tbl == 49))
            {
                foreach (string[] strArr in arrList)
                {
                    NOMNUM = int.Parse(strArr[2]);

                    string s1 = "bknametxt" + NOMNUM.ToString();
                    string s2 = "bkBrntxt" + NOMNUM.ToString();
                    string s3 = "acctNotxt" + NOMNUM.ToString();
                    string s4 = "slicAcctddl" + NOMNUM.ToString();
                    string s5 = "txtInsname" + NOMNUM.ToString();
                    //string s6 = "acctCodeddl" + index.ToString();

                    TextBox txtbkName = (TextBox)Table1.FindControl(s1);
                    TextBox txtbkBrn = (TextBox)Table1.FindControl(s2);
                    TextBox txtbkAcctNo = (TextBox)Table1.FindControl(s3);
                    DropDownList ddlslicAcct = (DropDownList)Table1.FindControl(s4);
                    TextBox txtNamewithins = (TextBox)Table1.FindControl(s5);
                    //DropDownList ddlaccCode = (DropDownList)Table1.FindControl(s6);

                    if (txtbkName != null) { BKNAM = txtbkName.Text.Trim(); }
                    if (txtbkBrn != null) { BKBRN = txtbkBrn.Text.Trim(); }
                    if (txtbkAcctNo != null) { ACNUM = txtbkAcctNo.Text.Trim(); }
                    if (ddlslicAcct != null) { SLIAcctNo = ddlslicAcct.SelectedItem.Value; }
                    if (txtNamewithins != null) { namewithins = txtNamewithins.Text; }

                    payamt = double.Parse(strArr[3]);
                    NOMNAME = strArr[0];
                    NOMAD1 = strArr[5];
                    NOMAD2 = strArr[6];
                    NOMAD3 = strArr[7];
                    NOMAD4 = strArr[8];

                    vouno = this.createVoucher(payamt, NOMNAME, NOMAD1, NOMAD2, NOMAD3, NOMAD4, ACNUM, BKNAM, BKBRN, SLIAcctNo, dm);

                    //---- updating child_prot_mas --------
                    paymntcnt++;
                    int lastDue = nextDue;
                    int yymm = int.Parse(setDate()[0].ToString().Substring(0, 6));

                    //---insert to periodic Paydet---------
                    if (count == 0)
                    {
                        string periodicpaysel = "select * from LCLM.PERIODIC_PAYDET where POLNO=" + polno + "and CLMTYPE='" + clmtyp + "' and VONO='XXXX'";
                        if (dm.existRecored(periodicpaysel) != 0)
                        {
                            string periodicpayupd = "update LCLM.PERIODIC_PAYDET set VONO='" + vouno + "' where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and VONO='XXXX'";
                            dm.insertRecords(periodicpayupd);
                        }
                        else
                        {
                            throw new Exception("Voucher Already Created!");
                        }
                        count++;
                    }

                    int matym = int.Parse(mat_date.ToString().Substring(0, 6));
                    string periobonussel = "select PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and PAYMENT_DUE= " + matym + " ";
                    if (dm.existRecored(periobonussel) != 0)
                    {
                        double value;
                        double totalval;
                        OracleDataReader periopayreader = dm.oraComm.ExecuteReader();
                        periopayreader.Read();
                        if (!periopayreader.IsDBNull(0)) { value = periopayreader.GetDouble(0); } else { value = 0; }
                        totalval = value + bonus;
                        string periobonupd = "update LCLM.PERIODIC_PAYDET set PAID_AMT=" + totalval + " where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and PAYMENT_DUE=" + matym + "";
                        dm.insertRecords(periobonupd);
                    }

                    string nomperiodicpaysel = "select * from LCLM.NOM_PERIODIC_PAYDET where NOM_NO=" + NOMNUM + " and POLICY_NO=" + polno + " and CLAIM_TYPE='" + clmtyp + "' and VOU_NO='XXXX'";
                    if (dm.existRecored(nomperiodicpaysel) != 0)
                    {
                        //string nomperiodicpayupd = "update LCLM.NOM_PERIODIC_PAYDET set VOU_NO='" + vouno + "',PAY_DATE=" + int.Parse(this.setDate()[0]) + ",PAY_EPF='" + EPF + "',PAY_IP='" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "' " +
                        //                         "where NOM_NO=" + NOMNUM + " and POLICY_NO=" + polno + "and CLAIM_TYPE='" + clmtyp + "' and VOU_NO='XXXX'";
                        string nomperiodicpayupd = "";

                        if (ischildNomAge)
                        {
                            nomperiodicpayupd = "update LCLM.NOM_PERIODIC_PAYDET set PAID_AMT=" + payamt + ", VOU_NO='" + vouno + "',PAY_DATE=" + int.Parse(this.setDate()[0]) + ",PAY_EPF='" + EPF + "',PAY_IP='" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "' " +
                                                     "where NOM_NO=" + NOMNUM + " and POLICY_NO=" + polno + "and CLAIM_TYPE='" + clmtyp + "' and VOU_NO='XXXX'";
                        }
                        else
                        {
                            nomperiodicpayupd = "update LCLM.NOM_PERIODIC_PAYDET set VOU_NO='" + vouno + "',PAY_DATE=" + int.Parse(this.setDate()[0]) + ",PAY_EPF='" + EPF + "',PAY_IP='" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "' " +
                                                     "where NOM_NO=" + NOMNUM + " and POLICY_NO=" + polno + "and CLAIM_TYPE='" + clmtyp + "' and VOU_NO='XXXX'";
                        }

                        dm.insertRecords(nomperiodicpayupd);
                    }
                    else
                    {
                        throw new Exception("Voucher Already Created!");
                    }
                    this.lblsuccess.Visible = true;
                    this.lblvouno.Text = "Vouchers Successfully Created";
                }
            }
            else
            {
                payamt = double.Parse(this.txtnetClmAmt.Text.Trim());
                NOMNAME = this.txtpayeename.Text.Trim();
                NOMAD1 = this.txtad1.Text.Trim();
                NOMAD2 = this.txtad2.Text.Trim();
                NOMAD3 = this.txtad3.Text.Trim();
                NOMAD4 = this.txtad4.Text.Trim();

                ACNUM = this.txtcustAcct.Text.Trim();
                BKNAM = this.txtbkname.Text.Trim();
                BKBRN = this.txtbkbrnname.Text.Trim();
                SLIAcctNo = this.ddlslicacctno.SelectedItem.Value.ToString();

                //Check Payment availability..................

                //---- creating voucher ---------------
                vouno = this.createVoucher(payamt, NOMNAME, NOMAD1, NOMAD2, NOMAD3, NOMAD4, ACNUM, BKNAM, BKBRN, SLIAcctNo, dm);

                //---- updating child_prot_mas --------
                paymntcnt++;
                int lastDue = nextDue;
                int yymm = int.Parse(setDate()[0].ToString().Substring(0, 6));
                //if (lastDue > yymm) { throw new Exception("No more dues for this policy!"); }            
                //nextDue = int.Parse((int.Parse(nextDue.ToString().Substring(0, 4)) + 1).ToString() + nextDue.ToString().Substring(4, 2));

                //commented by Dushan
                //string childprotmasUpd = "update lclm.child_prot_mas set LASTDUE = " + lastDue + ", NEXTDUE = " + nextDue + ", PAYMENT_COUNT = " + paymntcnt + " where polno = " + polno + " and ptable = " + tbl + "";
                //dm.insertRecords(childprotmasUpd);

                //---- inserting into child_prot_pay --
                //string protPaySel = "select polno from lclm.CHILD_PROT_PAY where polno = " + polno + " and PAYMENT_DUE = " + lastDue + " and ptable = " + tbl + " ";
                //if (dm.existRecored(protPaySel) == 0)
                //{
                //    int date = int.Parse(setDate()[0]);
                //    string childprotpayInsert = "INSERT INTO LCLM.CHILD_PROT_PAY (POLNO ,PAYMENT_DUE ,LAST_DUE ,NEXT_DUE ,VONO ,PAID_AMT ,PAYDATE ,PAYEPF ,PAYIP ,PTABLE, claimno ) " +
                //        " VALUES (" + polno + " ," + lastDue + " ," + lastDue + " ," + nextDue + " ,'" + vouno + "' ," + payamt + " , " + date + " ,'" + EPF + "' ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "' , " + tbl + ", " + clmno + "  )";
                //    dm.insertRecords(childprotpayInsert);
                //}

                //---insert to periodic Paydet---------
                string periodicpaysel = "select * from LCLM.PERIODIC_PAYDET where POLNO=" + polno + "and CLMTYPE='" + clmtyp + "' and VONO='XXXX'";
                if (dm.existRecored(periodicpaysel) != 0)
                {
                    string periodicpayupd = "update LCLM.PERIODIC_PAYDET set VONO='" + vouno + "' where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and VONO='XXXX'";
                    dm.insertRecords(periodicpayupd);
                }
                else
                {
                    throw new Exception("Voucher Already Created!");
                }
                int matym = int.Parse(mat_date.ToString().Substring(0, 6));
                string periobonussel = "select PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and PAYMENT_DUE= " + matym + " ";
                if (dm.existRecored(periobonussel) != 0)
                {
                    double value;
                    double totalval;
                    OracleDataReader periopayreader = dm.oraComm.ExecuteReader();
                    periopayreader.Read();
                    if (!periopayreader.IsDBNull(0)) { value = periopayreader.GetDouble(0); } else { value = 0; }
                    totalval = value + bonus;
                    string periobonupd = "update LCLM.PERIODIC_PAYDET set PAID_AMT=" + totalval + "where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and PAYMENT_DUE=" + matym + "";
                    dm.insertRecords(periobonupd);
                }
                this.lblsuccess.Visible = true;
                this.lblvouno.Text = "Voucher No. -: " + vouno;
            }
            this.Button1.Enabled = false;
            dm.commit();
            dm.connClose();
            //dmob.connClose();
            //ViewState["payamt"] = payamt;
            ViewState["vouno"] = vouno;
        }
        catch (Exception ex)
        {
            dm.rollback();
            //dmob.connClose();
            dm.connClose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChildProt/ChildProt002.aspx?polino=" + polno + "&mos=M&nomCount=" + nomineeCount + "");
    }

    protected string createVoucher(double PAYVAL, string NAMEPAYEE1, string ADD1, string ADD2, string ADD3, string ADD4, string ACNUM, string BKNAM, string BKBRN, string SLIAcctNo, DataManager dm)
    {
        //--------- generating voucher number --------------
        string vouno = "";
        General gg = new General();
        try
        {
            vouno = gg.voucher_number(DateTime.Now.Year.ToString(), branch.ToString().Trim(), "C", dm);
        }
        catch (Exception ex)
        {
            throw new Exception("Voucher Number Generating Failed! :" + ex.Message);
        }

        int ACCODE = gg.Account_code(polno, "CP", dm);         //one for deaths
        //int STATUS = 0;             //not deleted
        string USERID = EPF;
        int EXTDAT = int.Parse(setDate()[0]);
        string EXTTIM = DateTime.Now.ToString("HHmmss");
        //string ADD3 = "";

        if ((BKNAM != null) && (!BKNAM.Equals("")))
        {
            BKNAM = BKNAM.Replace("'", " ");
            BKNAM = BKNAM.Trim();
        }
        if ((BKBRN != null) && (!BKBRN.Equals("")))
        {
            BKBRN = BKBRN.Replace('\'', ' ');
            BKBRN = BKBRN.Trim();
        }

        ADD1 = this.adressRefine(ADD1);
        ADD2 = this.adressRefine(ADD2);
        ADD3 = this.adressRefine(ADD3);
        ADD4 = this.adressRefine(ADD4);

        ADD1 = ADD1.Trim();
        ADD2 = ADD2.Trim();
        ADD3 = ADD3.Trim();
        ADD4 = ADD4.Trim();

        bdb = new BankDetailsBreak(BKNAM, BKBRN, ACNUM, NAMEPAYEE1); //Editted By Dushan on 05/02/2009
        string hname = bdb.Hname1;
        string hname2 = bdb.Hname2;
        //string hname = BKNAM + " " + BKBRN + " " + ACNUM;
        string totamountStr1 = PAYVAL.ToString();
        //string totamountStr = "";
        string INSNAME = phname;

        //string sqllife_voudetl = "insert into cashbook.life_voudetl(VOUNO,POLNO,CLAIMNO,PAYVAL,ACCODE,NAMEPAYEE1,ADD1,ADD2,ADD3,ACNUM,STATUS," +
        //      "USERID,EXTDAT,EXTTIM,BKNAM,BKBRN,INSNAME) values ('" + vouno + "','" + polno + "','" + clmno + "'," + PAYVAL +
        //         "," + ACCODE + ",'" + NAMEPAYEE1 + "','" + ADD1 + "','" + ADD2 + "','" + ADD3 + "','" + ACNUM + "'," + STATUS + ",'" + USERID +
        //         "','" + EXTDAT + "','" + EXTTIM + "','" + BKNAM + "','" + BKBRN + "','" + phname + "' )";

        //dmob.insertRecords(sqllife_voudetl);

        //for (int i = 0; i <= (21 - totamountStr1.Length); i++)
        //{
        //    if (i == 1) { totamountStr = "*" + totamountStr1; }
        //    else { totamountStr = "*" + totamountStr; }
        //}

        string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

        #region--------------------Branch no formating------------------
        string branchstr;
        if (branch.ToString().Length == 1) { branchstr = "00" + branch.ToString(); }
        else if (branch.ToString().Length == 2) { branchstr = "0" + branch.ToString(); }
        else { branchstr = branch.ToString(); }
        #endregion

        #region //------------ temp_cb -----------------------

        string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";
        if (dm.existRecored(tempCB_select) == 0)
        {
            string tempCB_insert = "insert into cashbook.temp_cb(Class, busycode, Divcode, Bcode, Claimno, POLNO, HName, HName1, Totamount,  " +
            " Totamt, ACCode, Acno, VouNo, VOUDATE, BillDate, ClaimType, Addepf, Voutyp, Status, Print1, Authorized, Deleted, Chqcan, Payaut, Insname, Add1, Add2, Add3, add4, Posted, Reprint, RECIPIENT_NAME, TRANSACTION_TYPE, GROSS_AMOUNT) " +
            " VALUES ('L', '3', 'L', '" + branchstr + "', '" + clmno.ToString() + "', '" + polno.ToString() + "',  '" + hname + "', '" + hname2 + "', " + PAYVAL + ", " +
            " '" + String.Format("{0:N}", PAYVAL) + "', '" + ACCODE.ToString() + "', '" + SLIAcctNo + "','" + vouno + "', sysdate, sysdate, 'A', '" + EPF + "', 'Death','Pending', 0, 0, 0, 0, 0, '" + INSNAME + "', " +
            " '" + ADD1 + "', '" + ADD2 + "', '" + ADD3 + "', '" + ADD4 + "', 0, 0, '" + NAMEPAYEE1 + "', 'C', " + PAYVAL + "  )";
            dm.insertRecords(tempCB_insert);
        }
        else { throw new Exception("Voucher " + vouno + " Already Created!"); }

        #endregion

        #region //-------------- TEMP_DETL -------------------

        string temp_detl_select = "select * from  CASHBOOK.TEMP_DETL where vouno = '" + vouno + "' ";
        if (dm.existRecored(temp_detl_select) == 0)
        {
            string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                "VALUES ('" + vouno + "' ,'" + ACCODE.ToString() + "' ,  " + PAYVAL + " ,0 ,0 ,  " + PAYVAL + " )";
            dm.insertRecords(temp_detl_insert);
        }
        else { throw new Exception("Already Existing Record in temp_detl Table"); }

        #endregion

        #region //------------------ VOUBANKDET --------------

        string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
        if (dm.existRecored(voubankdetSelect) == 0)
        {
            string voubankdetnsert = "INSERT INTO LPHS.VOUBANKDET (POLICYNO ,VOUCHERNO ,PAYEENAME ,BNKNAME ,BNKBRNNAME ,SLIACCTNO, CUSTACCTNO ) " +
                " VALUES (" + polno + " ,'" + vouno + "' ,'" + NAMEPAYEE1 + "' ,'" + BKNAM + "' ,'" + BKBRN + "' ,'" + SLIAcctNo + "', '" + ACNUM + "'  )";
            dm.insertRecords(voubankdetnsert);
        }
        else { throw new Exception("Already Exising Voucher Bank Details"); }

        #endregion

        return vouno;
    }

    private string adressRefine(string s)
    {
        string returnStr = "";
        string spChar = "";
        if ((s != null) && (!s.Equals("")))
        {
            for (int i = 0; i < s.Length; i++)
            {
                spChar = s.Substring(i, 1);
                if ((!spChar.Equals("'")) && (!spChar.Equals("\"")) && (!spChar.Equals("+")) && (!spChar.Equals("-")) && (!spChar.Equals(";")) && (!spChar.Equals(",")))
                {
                    returnStr += spChar;
                }
                else
                {
                    returnStr += " ";
                }
            }
        }
        return returnStr;
    }

    private Boolean Checkavailability(long policy, string claim, DataManager dmm)
    {
        string periodicpaydetsel = "select PAID_AMT, PAYMENT_DUE from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='" + clmtyp + "' and VONO='XXXX'";
        if (dmm.existRecored(periodicpaydetsel) == 0)
        {
            return false;
        }
        return true;
    }

    private void createVouDetTable(string name, string ad1, string ad2, string ad3, string ad4, double totamount, int rowno, string accctNo, string payee)
    {
        gg = new General();
        namewithins = gg.NameWithInitials(name.Trim());
        //accCodeList = gg.getAccountCodeList();

        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();
        TableRow trow06 = new TableRow();
        TableRow trow07 = new TableRow();
        TableRow trow08 = new TableRow();
        TableRow trow09 = new TableRow();
        TableRow trow10 = new TableRow();
        TableRow trow11 = new TableRow();
        TableRow trow12 = new TableRow();
        //TableRow trow13 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel21 = new TableCell();
        TableCell tcel22 = new TableCell();
        TableCell tcel31 = new TableCell();
        TableCell tcel32 = new TableCell();
        TableCell tcel41 = new TableCell();
        TableCell tcel42 = new TableCell();
        TableCell tcel51 = new TableCell();
        TableCell tcel52 = new TableCell();
        TableCell tcel61 = new TableCell();
        TableCell tcel62 = new TableCell();
        TableCell tcel71 = new TableCell();
        TableCell tcel72 = new TableCell();
        TableCell tcel81 = new TableCell();
        TableCell tcel82 = new TableCell();
        TableCell tcel91 = new TableCell();
        TableCell tcel92 = new TableCell();
        TableCell tcel101 = new TableCell();
        TableCell tcel111 = new TableCell();
        TableCell tcel102 = new TableCell();
        TableCell tcel112 = new TableCell();
        TableCell tcel121 = new TableCell();
        TableCell tcel122 = new TableCell();
        //TableCell tcel131 = new TableCell();
        //TableCell tcel132 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl52 = new Label();
        Label lbl61 = new Label();
        Label lbl62 = new Label();
        Label lbl71 = new Label();
        Label lbl72 = new Label();
        Label lbl81 = new Label();
        Label lbl111 = new Label();
        TextBox txt01 = new TextBox();
        Label lbl91 = new Label();
        TextBox txt02 = new TextBox();
        Label lbl101 = new Label();
        TextBox txt03 = new TextBox();
        Label lbl121 = new Label();
        TextBox txt04 = new TextBox();
        //Label lbl131 = new Label();
        //TextBox txt04 = new TextBox();
        DropDownList ddl122 = new DropDownList();
        //DropDownList ddl132 = new DropDownList();

        lbl11.ID = "totamontDesc" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "totamontDesc" + rowno); //Text Value
        lbl11.Text = "Voucher Amount : ";

        lbl12.ID = "totamont" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "totamont" + rowno); //Text Value
        lbl12.Text = String.Format("{0:N}", totamount);

        lbl21.ID = "fullnameDesc" + rowno;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "fullnameDesc" + rowno); //Text Value
        lbl21.Text = "Payee Name : ";

        lbl22.ID = "fullname" + rowno;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "fullname" + rowno); //Text Value
        lbl22.Text = name;

        lbl31.ID = "insName" + rowno;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "insName" + rowno); //Text Value
        lbl31.Text = "Name with Initials : ";

        lbl41.ID = "ad1Desc" + rowno;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "ad1Desc" + rowno); //Text Value
        lbl41.Text = "Address Part1 : ";

        lbl42.ID = "ad1" + rowno;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "ad1" + rowno); //Text Value
        lbl42.Text = ad1;

        lbl51.ID = "add2desc" + rowno;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "add2desc" + rowno); //Text Value
        lbl51.Text = "Address Part2 : ";

        lbl52.ID = "ad2" + rowno;
        lbl52.Attributes.Add("runat", "Server");
        lbl52.Attributes.Add("Name", "ad2" + rowno); //Text Value
        lbl52.Text = ad2;

        lbl61.ID = "add3desc" + rowno;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "add3desc" + rowno); //Text Value
        lbl61.Text = "Address Part3 : ";

        lbl62.ID = "ad3" + rowno;
        lbl62.Attributes.Add("runat", "Server");
        lbl62.Attributes.Add("Name", "ad3" + rowno); //Text Value
        lbl62.Text = ad3;

        lbl71.ID = "add4desc" + rowno;
        lbl71.Attributes.Add("runat", "Server");
        lbl71.Attributes.Add("Name", "add4desc" + rowno); //Text Value
        lbl71.Text = "Address Part4 : ";

        lbl72.ID = "ad4" + rowno;
        lbl72.Attributes.Add("runat", "Server");
        lbl72.Attributes.Add("Name", "ad5" + rowno); //Text Value
        lbl72.Text = ad4;

        lbl81.ID = "bkName" + rowno;
        lbl81.Attributes.Add("runat", "Server");
        lbl81.Attributes.Add("Name", "bkName" + rowno); //Text Value
        lbl81.Text = "Bank Name : ";

        lbl91.ID = "bkBrn" + rowno;
        lbl91.Attributes.Add("runat", "Server");
        lbl91.Attributes.Add("Name", "bkBrn" + rowno); //Text Value
        lbl91.Text = "Branch Name : ";

        lbl101.ID = "acctno" + rowno;
        lbl101.Attributes.Add("runat", "Server");
        lbl101.Attributes.Add("Name", "acctno" + rowno); //Text Value
        lbl101.Text = "Account Number : ";

        lbl111.ID = "payee" + rowno;
        lbl111.Attributes.Add("runat", "Server");
        lbl111.Attributes.Add("Name", "payee" + rowno); //Text Value
        lbl111.Text = "Payee : " + payee;

        lbl121.ID = "slicAcct" + rowno;
        lbl121.Attributes.Add("runat", "Server");
        lbl121.Attributes.Add("Name", "slicAcct" + rowno); //Text Value
        lbl121.Text = "SLI Account : ";

        //lbl131.ID = "acctCode" + rowno;
        //lbl131.Attributes.Add("runat", "Server");
        //lbl131.Attributes.Add("Name", "acctCode" + rowno); //Text Value
        //lbl131.Text = "Account Code : ";

        //txt01.MaxLength = 28;
        txt01.ID = "bknametxt" + rowno;
        txt01.Attributes.Add("runat", "Server");
        txt01.Attributes.Add("Name", "bknametxt" + rowno);
        txt01.Style["width"] = "400px";

        //txt02.MaxLength = 20;
        txt02.ID = "bkBrntxt" + rowno;
        txt02.Attributes.Add("runat", "Server");
        txt02.Attributes.Add("Name", "bkBrntxt" + rowno);
        txt02.Style["width"] = "400px";

        //txt03.MaxLength = 20;
        txt03.ID = "acctNotxt" + rowno;
        txt03.Attributes.Add("runat", "Server");
        txt03.Attributes.Add("Name", "acctNotxt" + rowno);
        txt03.Style["width"] = "400px";
        if (long.Parse(accctNo) > 0) { txt03.Text = accctNo.ToString(); txt03.ReadOnly = true; }

        txt04.ID = "txtInsname" + rowno;
        txt04.Attributes.Add("runat", "Server");
        txt04.Attributes.Add("Name", "txtInsname" + rowno);
        txt04.Style["width"] = "400px";
        txt04.Text = namewithins; 

        ddl122.ID = "slicAcctddl" + rowno;
        ddl122.Attributes.Add("runat", "Server");
        ddl122.Attributes.Add("Name", "slicAcctddl" + rowno); //Text Value
        ddl122.Items.Add(new ListItem("1030001487", "1030001487"));
        ddl122.Items.Add(new ListItem("1364403002", "1364403002"));
        ddl122.Items.Add(new ListItem("0001092995", "0001092995"));
        ddl122.Items.Add(new ListItem("000000000962", "000000000962"));
        ddl122.SelectedValue = "000000000962";
         
        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);
        tcel32.Controls.Add(txt04);
        tcel41.Controls.Add(lbl41);
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);
        tcel52.Controls.Add(lbl52);
        tcel61.Controls.Add(lbl61);
        tcel62.Controls.Add(lbl62);
        tcel71.Controls.Add(lbl71);
        tcel72.Controls.Add(lbl72);
        tcel81.Controls.Add(lbl81);
        tcel82.Controls.Add(txt01);
        tcel91.Controls.Add(lbl91);
        tcel92.Controls.Add(txt02);
        tcel101.Controls.Add(lbl101);
        tcel102.Controls.Add(txt03);
        tcel111.Controls.Add(lbl111);
        tcel121.Controls.Add(lbl121);
        tcel122.Controls.Add(ddl122); 

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow02.Cells.Add(tcel21);
        trow02.Cells.Add(tcel22);
        trow03.Cells.Add(tcel31);
        trow03.Cells.Add(tcel32);
        trow04.Cells.Add(tcel41);
        trow04.Cells.Add(tcel42);
        trow05.Cells.Add(tcel51);
        trow05.Cells.Add(tcel52);
        trow06.Cells.Add(tcel61);
        trow06.Cells.Add(tcel62);
        trow07.Cells.Add(tcel71);
        trow07.Cells.Add(tcel72);
        trow08.Cells.Add(tcel81);
        trow08.Cells.Add(tcel82);
        trow09.Cells.Add(tcel91);
        trow09.Cells.Add(tcel92);
        trow10.Cells.Add(tcel101);
        trow10.Cells.Add(tcel102);
        trow11.Cells.Add(tcel111);

        trow12.Cells.Add(tcel121);
        trow12.Cells.Add(tcel122);

        //trow13.Cells.Add(tcel131);
        //trow13.Cells.Add(tcel132);

        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
        Table1.Rows.Add(trow06);
        Table1.Rows.Add(trow07);
        Table1.Rows.Add(trow08);
        Table1.Rows.Add(trow09);
        Table1.Rows.Add(trow10);
        Table1.Rows.Add(trow11);
        Table1.Rows.Add(trow12);
        //Table1.Rows.Add(trow13);
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Payee
    {
        get { return payee; }
        set { payee = value; }
    }
    public int Clmno
    {
        get { return clmno; }
        set { clmno = value; }
    }
    public string Vouno
    {
        get { return vouno; }
        set { vouno = value; }
    }
    public double Payamt
    {
        get { return payamt; }
        set { payamt = value; }
    }
    public int NomineeCount
    {
        get { return nomineeCount; }
        set { nomineeCount = value; }
    }
    public bool IschildNomAge
    {
        get { return ischildNomAge; }
        set { ischildNomAge = value; }
    }
    public static CompanyVouFields Objcvf
    {
        get { return cvf; }
        set { cvf = value; }
    }
    public int TBL
    {
        get { return tbl; }
        set { tbl = value; }
    }
    protected void btnSlivou_Click(object sender, EventArgs e)
    {
        NOMNAME = this.txtpayeename.Text.Trim();
        payamt = double.Parse(this.txtnetClmAmt.Text.Trim());
        cvf.Polno = polno;
        cvf.Payeenam = NOMNAME;
        cvf.Share = payamt;
        cvf.Clmtyp = clmtyp;
        cvf.Mos = "M";
        Response.Redirect("~/Slicvou001.aspx", false);
    }
}
