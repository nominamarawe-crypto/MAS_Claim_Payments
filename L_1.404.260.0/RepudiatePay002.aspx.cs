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

//Last updated Dushan 16/10/2009
public partial class RepudiatePay002 : System.Web.UI.Page
{
    private long polno;
    private string mos;
    private double examt;
    private double clmamt;
    private double bonus;
    private double otheradds;
    private double defprem;
    private double defpremint;
    private double polcom;
    private double loancap;
    private double loanint;

    private double otherdeduct;
    private int table;
    private int term;
    private int com;
    private int clmno, branch;
    private int dtofdth = 0;
    private string polstatus, EPF;
    private double grossclm;
    private double netclm;
    private double interimbon;
    private double totbonus;
    private int polcomdt;
    private double deposit;
    private string isFuturePayment;
    
    lpolhisread lpolhisobj;
    BonusCal bonuscalobj;
    LoanBackCal loanbackobj;
    General gg;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        string repupayok="";
        string memeaprv = "";
             
        if (!Page.IsPostBack)
        {
            polno = PreviousPage.Polno;
            mos = PreviousPage.Mos;
            if (Session["EPFNum"] != null || Session["brcode"] != null)
            {
                EPF = Session["EPFNum"].ToString();
                branch = Convert.ToInt32(Session["brcode"]);
            }
            else
            {
                Response.Redirect("SessionError.aspx", false);
            }
            try
            {
                dm=new DataManager();

                #region---------------------Dthint------------------------
                string dthintsel = "select DDTOFDTH, DCLM, DPOLST from LPHS.DTHINT where DPOLNO=" + polno + "";
                dm.readSql(dthintsel);
                OracleDataReader dthintreader = dm.oraComm.ExecuteReader();
                while (dthintreader.Read())
                {
                    if (!dthintreader.IsDBNull(0)) { dtofdth = dthintreader.GetInt32(0); } else { dtofdth = 0; }
                    if (!dthintreader.IsDBNull(1)) { clmno = dthintreader.GetInt32(1); } else { clmno = 0; }
                    if (!dthintreader.IsDBNull(2)) { polstatus = dthintreader.GetString(2); } else { polstatus = ""; }
                }
                #endregion

                #region--------------Check Repudiation--------------------
                string repudiatesel = "select POLICYNO, REPUOK from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='" + mos + "'";
                if (dm.existRecored(repudiatesel) == 0)
                {
                    throw new Exception("No Repudiated Policy Details Found!");
                }
                else
                {
                    dm.readSql(repudiatesel);
                    OracleDataReader repupayread = dm.oraComm.ExecuteReader();
                    while (repupayread.Read())
                    {
                        if (!repupayread.IsDBNull(1)) { repupayok = repupayread.GetString(1); } else { repupayok = ""; }
                    }
                    if (repupayok.Equals("OK"))
                    {
                        string dthrefread = "select DRVESTEDBON, DRDEPOSITS, DROTHERADITNS, DEOTHERDEDUCT, DRDEFPREM, DRINT, DRLONCAP, DRLOANINT, EXGRACIA_AMOUNT, AMT_TO_COMPLETE, MEMOAPRV, DRINTERIMBON, IS_FUTUER_PAYMENT from LPHS.DTHREF where DRPOLNO=" + polno + "";
                        if (dm.existRecored(dthrefread) != 0)
                        {
                            dm.readSql(dthrefread);
                            OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                            while (dthrefreader.Read())
                            {
                                if (!dthrefreader.IsDBNull(0)) { bonus = dthrefreader.GetDouble(0); } else { bonus = 0; }
                                if (!dthrefreader.IsDBNull(1)) { deposit = dthrefreader.GetDouble(1); } else { deposit = 0; }
                                if (!dthrefreader.IsDBNull(2)) { otheradds = dthrefreader.GetDouble(2); } else { otheradds = 0; }
                                if (!dthrefreader.IsDBNull(3)) { otherdeduct = dthrefreader.GetDouble(3); } else { otherdeduct = 0; }
                                if (!dthrefreader.IsDBNull(4)) { defprem = dthrefreader.GetDouble(4); } else { defprem = 0; }
                                if (!dthrefreader.IsDBNull(5)) { defpremint = dthrefreader.GetDouble(5); } else { defpremint = 0; }
                                if (!dthrefreader.IsDBNull(6)) { loancap = dthrefreader.GetDouble(6); } else { loancap = 0; }
                                if (!dthrefreader.IsDBNull(7)) { loanint = dthrefreader.GetDouble(7); } else { loanint = 0; }
                                if (!dthrefreader.IsDBNull(8)) { examt = dthrefreader.GetDouble(8); } else { examt = 0; }
                                if (!dthrefreader.IsDBNull(9)) { polcom = dthrefreader.GetDouble(9); } else { polcom = 0; }
                                if (!dthrefreader.IsDBNull(10)) { memeaprv = dthrefreader.GetString(10); } else { memeaprv = ""; }
                                if (!dthrefreader.IsDBNull(11)) { interimbon = dthrefreader.GetDouble(11); } else { interimbon = 0; }
                                if (!dthrefreader.IsDBNull(12)) { isFuturePayment = dthrefreader.GetString(12); } else { isFuturePayment = "-1"; }
                            }
                            dthrefreader.Close();
                            this.txtBonus.Text = bonus.ToString();
                            //this.txtClmamt.Text = clmamt.ToString();
                            this.txtOtheradds.Text = otheradds.ToString();
                            this.txtOtherdeduct.Text = otherdeduct.ToString();
                            this.txtDefprem.Text = defprem.ToString();
                            this.txtDefpremint.Text = defpremint.ToString();
                            this.txtLoancap.Text = loancap.ToString();
                            this.txtLoanint.Text = loanint.ToString();
                            this.txtAmount.Text = examt.ToString();
                            this.txtAmtcompolyr.Text = polcom.ToString();
                            this.txtInterimbon.Text = interimbon.ToString();
                            this.ddlFuturePay.SelectedValue = isFuturePayment;

                            if (memeaprv.Equals("Y"))
                            {
                                this.txtBonus.ReadOnly = true;
                                //this.txtClmamt.ReadOnly = true;
                                this.txtOtheradds.ReadOnly = true;
                                this.txtOtherdeduct.ReadOnly = true;
                                this.txtDefprem.ReadOnly = true;
                                this.txtDefpremint.ReadOnly = true;
                                this.txtLoancap.ReadOnly = true;
                                this.txtLoanint.ReadOnly = true;
                                this.txtAmount.ReadOnly = true;
                                this.txtAmtcompolyr.ReadOnly = true;
                                this.cmdNext.Enabled = true;
                                this.cmdSubmit.Enabled = false;
                                this.txtInterimbon.ReadOnly = false;
                                this.chkPaydeposit.Enabled = false;
                                this.ddlFuturePay.Enabled = false;
                            }
                        }
                        else
                        {
                            throw new Exception("No Death Reference Details Found!");
                        }
                    }
                    else
                    {
                        #region.......Deposit Read......cnange by buddhika 2009/04/17
                        string dthrefread = "select DRVESTEDBON, DRDEPOSITS, DROTHERADITNS, DEOTHERDEDUCT, DRDEFPREM, DRINT, DRLONCAP, DRLOANINT, EXGRACIA_AMOUNT, AMT_TO_COMPLETE, MEMOAPRV, DRINTERIMBON, IS_FUTUER_PAYMENT from LPHS.DTHREF where DRPOLNO=" + polno + "";
                        if (dm.existRecored(dthrefread) != 0)
                        {
                            dm.readSql(dthrefread);
                            OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                            while (dthrefreader.Read())
                            {
                                //if (!dthrefreader.IsDBNull(0)) { bonus = dthrefreader.GetDouble(0); } else { bonus = 0; }
                                if (!dthrefreader.IsDBNull(1)) { deposit = dthrefreader.GetDouble(1); } else { deposit = 0; }
                                //if (!dthrefreader.IsDBNull(2)) { otheradds = dthrefreader.GetDouble(2); } else { otheradds = 0; }
                                //if (!dthrefreader.IsDBNull(3)) { otherdeduct = dthrefreader.GetDouble(3); } else { otherdeduct = 0; }
                                //if (!dthrefreader.IsDBNull(4)) { defprem = dthrefreader.GetDouble(4); } else { defprem = 0; }
                                //if (!dthrefreader.IsDBNull(5)) { defpremint = dthrefreader.GetDouble(5); } else { defpremint = 0; }
                                //if (!dthrefreader.IsDBNull(6)) { loancap = dthrefreader.GetDouble(6); } else { loancap = 0; }
                                //if (!dthrefreader.IsDBNull(7)) { loanint = dthrefreader.GetDouble(7); } else { loanint = 0; }
                                //if (!dthrefreader.IsDBNull(8)) { examt = dthrefreader.GetDouble(8); } else { examt = 0; }
                                //if (!dthrefreader.IsDBNull(9)) { polcom = dthrefreader.GetDouble(9); } else { polcom = 0; }
                                //if (!dthrefreader.IsDBNull(10)) { memeaprv = dthrefreader.GetString(10); } else { memeaprv = ""; }
                                //if (!dthrefreader.IsDBNull(11)) { interimbon = dthrefreader.GetDouble(11); } else { interimbon = 0; }
                            }
                            dthrefreader.Close();
                        }
                            //this.txtBonus.Text = bonus.ToString();
                            //this.txtClmamt.Text = clmamt.ToString();
                            //this.txtOtheradds.Text = otheradds.ToString();
                            //this.txtOtherdeduct.Text = otherdeduct.ToString();
                            //this.txtDefprem.Text = defprem.ToString();
                            //this.txtDefpremint.Text = defpremint.ToString();
                            //this.txtLoancap.Text = loancap.ToString();
                            //this.txtLoanint.Text = loanint.ToString();
                            //this.txtAmount.Text = examt.ToString();
                            //this.txtAmtcompolyr.Text = polcom.ToString();
                            //this.txtInterimbon.Text = interimbon.ToString();

                        #endregion
                        #region--------------------------Bonus--------------------
                        bonuscalobj = new BonusCal();
                        bonus = bonuscalobj.VestedBonus(polno, mos)[1];
                        interimbon = bonuscalobj.VestedBonus(polno, mos)[0];
                        totbonus = bonus + interimbon;
                        #endregion

                        #region--------------------------Loan---------------------
                        int loanno;
                        string loannosel = "select LMLON from LPHS.LPLMAST where LMPOL=" + polno + "";
                        if (dm.existRecored(loannosel) != 0)
                        {
                            dm.readSql(loannosel);
                            OracleDataReader loannoreader = dm.oraComm.ExecuteReader();
                            while (loannoreader.Read())
                            {
                                if (!loannoreader.IsDBNull(0)) { loanno = loannoreader.GetInt32(0); } else { loanno = 0; }
                                loanbackobj = new LoanBackCal(int.Parse(polno.ToString()), dtofdth, loanno);
                                loancap += loanbackobj.Loancap;
                                loanint += loanbackobj.Backinterest;
                            }
                            loannoreader.Close();
                        }
                        #endregion

                    }
                }
                #endregion                               
               

                #region---------------Deposit-----------------------------
                gg = new General();
                //deposit = gg.Deposit(polno, dm);
                if (deposit == 0)
                {
                    string deptempSelect = "SELECT DPDEPAMT FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO=" + polno + " AND DPMOS='" + mos + "'";
                    if (dm.existRecored(deptempSelect) != 0)
                    {
                        dm.readSql(deptempSelect);
                        OracleDataReader demreader = dm.oraComm.ExecuteReader();
                        while (demreader.Read())
                        {
                            if (!demreader.IsDBNull(0)) { deposit = demreader.GetDouble(0); } else { deposit = 0; }
                        }
                        demreader.Close();
                        chkPaydeposit.Checked = false;
                    }
                }
                #endregion

                #region-----------Display Values in the Form--------------
                //txtBonus.Text = String.Format("{0:n}", bonus);
                //txtInterimbon.Text = String.Format("{0:n}",interimbon);
                //txtLoancap.Text = String.Format("{0:n}",loancap);
                //txtLoanint.Text = String.Format("{0:n}",loanint);
                //txtDeposit.Text = String.Format("{0:n}",deposit);

                txtBonus.Text =  bonus.ToString();
                txtInterimbon.Text =interimbon.ToString();
                txtLoancap.Text =  loancap.ToString();
                txtLoanint.Text =  loanint.ToString();
                txtDeposit.Text = deposit.ToString();
                #endregion

                lpolhisobj = new lpolhisread(polno);
                                
                table = lpolhisobj.Table;
                term = lpolhisobj.Term;
                com = lpolhisobj.Commence;
                //polstatus = lpolhisobj.Status;
                
                dm.connclose();
            }

            catch (Exception Ex)
            {
                dm.connclose();
                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }

            #region--------------viewstate----------------
            ViewState["polno"] = polno;
            ViewState["mos"] = mos;
            ViewState.Add("dtofdth", dtofdth);
            ViewState.Add("clmno", clmno);
            ViewState["examt"] = examt;
            ViewState["clmamt"] = clmamt;
            ViewState["totbonus"] = totbonus;
            ViewState["otheradds"] = otheradds;
            ViewState["table"] = table;
            ViewState["term"] = term;
            ViewState["polstatus"] = polstatus;
            ViewState["com"] = com;
            ViewState["dtofdth"] = dtofdth;
            ViewState["deposit"] = deposit;
            ViewState["branch"] = branch;
            ViewState["EPF"] = EPF;
            
            #endregion
        }
        else
        {
            polno = long.Parse(ViewState["polno"].ToString());
            mos = ViewState["mos"].ToString();
            clmno = int.Parse(ViewState["clmno"].ToString());
            dtofdth = int.Parse(ViewState["dtofdth"].ToString());
            examt = double.Parse(ViewState["examt"].ToString());
            clmamt = double.Parse(ViewState["clmamt"].ToString());
            totbonus = double.Parse(ViewState["totbonus"].ToString());
            otheradds = double.Parse(ViewState["otheradds"].ToString());
            table = int.Parse(ViewState["table"].ToString());
            term = int.Parse(ViewState["term"].ToString());
            polstatus = ViewState["polstatus"].ToString();
            com = int.Parse(ViewState["com"].ToString());
            dtofdth = int.Parse(ViewState["dtofdth"].ToString());
            deposit = double.Parse(ViewState["deposit"].ToString());
            branch = int.Parse(ViewState["branch"].ToString());
            EPF = ViewState["EPF"].ToString();
        }
    }
    
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            //if (deposit > 0)
            //{
            //    gg = new General();
            //    gg.Write_Deposit_Adjestment(branch, polno, Context.Request.ServerVariables["REMOTE_ADDR"].ToString(), gg.StrToNumFilter(EPF), dm);
            //}

            dm.begintransaction();
            if (this.txtAmount.Text.Trim() == "")
                examt = 0;
            else
                examt = double.Parse(this.txtAmount.Text.Trim());
            //clmamt = double.Parse(this.txtClmamt.Text.Trim());
            if (this.txtBonus.Text.Trim() == "")
                bonus = 0;
            else
                bonus = double.Parse(this.txtBonus.Text.Trim());
            if (this.txtInterimbon.Text.Trim() == "")
                interimbon = 0;
            else
                interimbon = double.Parse(this.txtInterimbon.Text.Trim());
            if (this.txtOtheradds.Text.Trim() == "")
                otheradds = 0;
            else
                otheradds = double.Parse(this.txtOtheradds.Text.Trim());
            if (this.txtDefprem.Text.Trim() == "")
                defprem = 0;
            else
                defprem = double.Parse(this.txtDefprem.Text.Trim());
            if (this.txtDefpremint.Text.Trim() == "")
                defpremint = 0;
            else
                defpremint = double.Parse(this.txtDefpremint.Text.Trim());
            if (this.txtLoancap.Text.Trim() == "")
                loancap = 0;
            else
                loancap = double.Parse(this.txtLoancap.Text.Trim());
            if (this.txtLoanint.Text.Trim() == "")
                loanint = 0;
            else
                loanint = double.Parse(this.txtLoanint.Text.Trim());
            if (this.txtOtherdeduct.Text.Trim() == "")
                otherdeduct = 0;
            else
                otherdeduct = double.Parse(this.txtOtherdeduct.Text.Trim());

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

            if (!chkPaydeposit.Checked)
            {
                string deptempSelect = "SELECT * FROM LPHS.DEPOSITE_TEMP WHERE DPPOLNO=" + polno + " AND DPMOS='" + mos + "'";
                if (dm.existRecored(deptempSelect) == 0)
                {
                    string deptempinsert = "insert into LPHS.DEPOSITE_TEMP(DPPOLNO, DPMOS, DPCLMNO, DPDEPAMT, DPENTEPF) values(" + polno + ", '" + mos + "', " + clmno + ", " + deposit + ", '" + EPF + "')";
                    dm.insertRecords(deptempinsert);
                }
                deposit = 0;
                //---Reverse Deposit Settlement----
            }
            else
            {
                string deptempdelete = "delete from LPHS.DEPOSITE_TEMP where DPPOLNO=" + polno + " AND DPMOS='" + mos + "'";
                dm.insertRecords(deptempdelete);
            }

            polcom = double.Parse(this.txtAmtcompolyr.Text.Trim());            
            totbonus = bonus + interimbon;
            grossclm = examt + clmamt + bonus + otheradds + interimbon + deposit;
            netclm = grossclm - (defprem + defpremint + loancap + loanint + otherdeduct + polcom);
            if (netclm < 0) { throw new Exception("Net Claim amount cannot have a negative value!"); }

            #region-------------Calculate Pol. Complete--------------------
            int commdd;
            int dthmmdd;
            int comyr;
            commdd=int.Parse(com.ToString().Substring(4,4));
            dthmmdd=int.Parse(dtofdth.ToString().Substring(4,4));
            if (commdd < dthmmdd) { comyr = int.Parse(dtofdth.ToString().Substring(0, 4)) + 1; }
            else { comyr = int.Parse(dtofdth.ToString().Substring(0, 4)); }
            polcomdt = int.Parse(comyr.ToString() + com.ToString().Substring(4, 4));
            
            #endregion

            #region---------------------Dthref----------------------
            string dthrefsel = "select * from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='"+mos+"'";
            if (dm.existRecored(dthrefsel) != 0)
            {
                string dthrefupdt = "update LPHS.DTHREF set DRVESTEDBON=" + bonus + ", DRINTERIMBON=" + interimbon + ", DRBONSURRAMT=0, DRSWARNAJAYA=0, DRFUNERALEXP=0, DRFPU=0, DRDEPOSITS=" + deposit + ", DROTHERADITNS=" + otheradds + ", " +
                    "DRGROSSCLM=" + grossclm + ", DEOTHERDEDUCT=" + otherdeduct + ", DRDEFPREM=" + defprem + ", DRINT=" + defpremint + ", DRLONCAP=" + loancap + ", DRLOANINT=" + loanint + ", " +
                    "DRNETCLM=" + netclm + ", ADBPAYAMT=0, SJPAYAMT=0, FPUPAYAMT=0, FEPAYAMT=0, SMASS_PVAL=0, REFUND_OF_PREMS=0, EXGRACIA_AMOUNT=" + examt + ", TOTPAYAMT=" + netclm + ", AMT_TO_COMPLETE=" + polcom + ", POL_COMPLETED=" + polcomdt + ", IS_FUTUER_PAYMENT='" + isFuturePayment + "' " +
                    "where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
                dm.insertRecords(dthrefupdt);
            }
            else
            {
                throw new Exception("The Claim not Processed Yet. Please Check!");
            }
            #endregion

            #region----------------dth_Repudiation------------------
            string dthrepusel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + "";
            if (dm.existRecored(dthrepusel) != 0)
            {
                string dthrepuupdt = "update LPHS.DTH_REPUDIATION set REPUOK='OK'";
                dm.insertRecords(dthrepuupdt);
            }
            else
            {
                throw new Exception("No Repudiated Claims Found!");
            }
            #endregion

            dm.commit();
            dm.connclose();
            cmdSubmit.Enabled = false;
            cmdNext.Enabled = true;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
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
    public double Examt
    {
        get { return examt; }
        set { examt = value; }
    }
    public double Clmamt
    {
        get { return clmamt; }
        set { clmamt = value; }
    }
    public double Bonus
    {
        get { return totbonus; }
        set { totbonus = value; }
    }
    public double Otheradds
    {
        get { return otheradds; }
        set { otheradds = value; }
    }
    public int Clmno
    {
        get { return clmno; }
        set { clmno = value; }
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
    public string Status
    {
        get { return polstatus; }
        set { polstatus = value; }
    }
    public int Com
    {
        get { return com; }
        set { com = value; }
    }
    //public int Deposit
    //{
    //    get { return deposit; }
    //    set { deposit = value; }
    //}
    public int Dtofdth
    {
        get { return dtofdth; }
        set { dtofdth = value; }
    }
    public double Deposit
    {
        get { return deposit; }
        set { deposit = value; }
    }
    protected void cmdNext_Click(object sender, EventArgs e)
    {

    }
}
