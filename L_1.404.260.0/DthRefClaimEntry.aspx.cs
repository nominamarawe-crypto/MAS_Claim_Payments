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
[Serializable]
public partial class DthRefClaimEntry : System.Web.UI.Page
{
    #region Variables
    private int PolNo;    private int ClaimNo;
    private int PropNo;     private string IDNo;
    private int CommDate;    private string mos;
    private string name;    private int CoverSt;
    private int CoverEnd;    private int skip;
    private double ADB;    private int CvrNo;
    private double[] Bonus;    private string EntryIP;
    private double Sumass;    private double VesBon;
    private double Interim;    private double surrbon;
    private double SJ;    private double FE;
    private double FPU;    private double Depsts;
    private double Otheradd;    private double Grossclm;
    private double Amtcompolyr;
    private double OthrDeduct;    private double DefPrm;
    private double Interest;    private double LnCptl;
    private double LnInterest;    private double NetClm;
    private int Csofdth;    private string Epf;
    private double ADBPay;    private double SJPay;
    private double FPUPay;    private double FEPay;
    private double Paidupval;    private double RefPrms;
    private double Outstanding;    private double Totpay;
    private double exgAmt; private double AgeAmt;
    private string Tracode;
    private string ISAuthOrize;
    private string reftable; private int Claimsts;
    private int tble; private int trm;
    private int mode; private int brcode;
    private int loannum; private string LngrantDate;
    private double LoanCaptl; private double LoanIntrst;
    private double totbon; private double loanint_rate;
    private double VestedBon; private double InterimBon;
    private double SurrenderBon; private int rcptno;
    private double LMNCP_LMCPY; private double LMIPY01;
    private int bonus_Surr_yr; private string AgeADMTYN;
    private int inter_bonSTyr;
    private double TotalPayAmount; public bool Isloansettle = false;
    private string phname; private string add1;
    private string add2;
    private string add3; private string add4;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        { 
            DataManager dm = new DataManager();
            BonusCal bonus = new BonusCal();

            #region Values assign from previous page
           
            PolNo = PreviousPage.POLNO;
            litpolno.Text = PolNo.ToString();
            ClaimNo = PreviousPage.CLMNO;
            litclm.Text = ClaimNo.ToString();
            PropNo = PreviousPage.PROPNO;
            litpropno.Text = PropNo.ToString();
            IDNo = PreviousPage.IDNO;
            CommDate = PreviousPage.COMMDATE;
            hdfcomdt.Value = CommDate.ToString();
            mos = PreviousPage.MOS;
            hdfmos.Value = mos;
            ViewState["mos"] = mos;
            name = PreviousPage.Name;
            litname.Text = name;
            Sumass = PreviousPage.SUMASS;
            txtsumass.Text = Sumass.ToString();
            if (mos == "M") { CoverSt = 1; CoverEnd = 14; skip = 9; }
            if (mos == "S") { CoverSt = 101; CoverEnd = 112; skip = 109; }
            if (mos == "2") { CoverSt = 201; CoverEnd = 212; skip = 209; }
            if (mos == "C") { CoverSt = 301; CoverEnd = 312; skip = 309; }
            Epf = PreviousPage.EPF;
            hdfepf.Value = Epf;
            Tracode = PreviousPage.TRACODE;
            ISAuthOrize = PreviousPage.AUTH;
            hdfauth.Value = ISAuthOrize;
            ViewState["Auth"] = ISAuthOrize;
            #endregion

            CHKeXGRA.Visible = false;

            #region gettracode
            string seltracode = "select TRANSCODE,PDAMT from lphs.dthout where POLNO=" + int.Parse(litpolno.Text) + "";
            if (dm.existRecored(seltracode) != 0)
            {
                OracleDataReader red_tra = dm.oraComm.ExecuteReader();
                while (red_tra.Read())
                {
                    if (!red_tra.IsDBNull(0)) { Tracode = red_tra.GetString(0); } else { Tracode = ""; }
                    if (!red_tra.IsDBNull(1)) { totalpdamt.Text = red_tra.GetDouble(1).ToString(); } else { totalpdamt.Text = "0"; }
                }
                red_tra.Close();
            }

            #endregion

            #region Values assign from previous page
            hdftracd.Value = Tracode;
            Grossclm = PreviousPage.GROSS;
            txtgross.Text = Grossclm.ToString();
            NetClm = PreviousPage.NET;
            txtntclm.Text = NetClm.ToString();
            tble = PreviousPage.TABLE;
            hdftbl.Value = tble.ToString();
            trm = PreviousPage.TERM;
            hdftrm.Value = trm.ToString();
            mode = PreviousPage.MODE;
            hdfmode.Value = mode.ToString();
            brcode = PreviousPage.BRCODE;
            hdfbr.Value = brcode.ToString();
            loannum = PreviousPage.LoanNumber;
            if (loannum == 0)
            {
                txtint4ln.ReadOnly = false;
                txtloan.ReadOnly = false;
            }
            else
            {
                txtint4ln.ReadOnly = true;
                txtloan.ReadOnly = true;
            }
            LngrantDate = PreviousPage.LoanGrantDate;

            LoanCaptl = PreviousPage.LoanCapital;
            txtloan.Text = LoanCaptl.ToString();

            LoanIntrst = PreviousPage.loanInterest;
            txtint4ln.Text = LoanIntrst.ToString() ;

            loanint_rate = PreviousPage.LoanINTRATE;
            litintrate.Text = loanint_rate.ToString();

            VestedBon = PreviousPage.VestedBon;
            txtvestedbns.Text = VestedBon.ToString("N2");

            InterimBon = PreviousPage.InterimBon;
            txtinterim.Text = InterimBon.ToString();

            SurrenderBon = PreviousPage.SuRRBON;
            txtsurrbns.Text = SurrenderBon.ToString();

            bonus_Surr_yr = PreviousPage.BONSURRYR;
            ViewState["SurrYR"] = bonus_Surr_yr;

            inter_bonSTyr = PreviousPage.InterBonStyr;
            ViewState["Interin_bonYr"] = inter_bonSTyr;
            hdfintbonst.Value = inter_bonSTyr.ToString();
            #endregion

            #region Get deposit amount from deposit table
            //--------------------------- Viewing Deposites ---------------------------------------------------
            #region
            
            string depositsql = "select DPTAM from lpay.deposit where DPPOL=" + PolNo + " and dpdel <> 1 and DPTAM>0 ";
            dm.readSql(depositsql);
            OracleDataReader depositreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            double tempDepo = 0;
            while (depositreader.Read())
            {
                double depamount = 0;
                if (!depositreader.IsDBNull(0)) { depamount = depositreader.GetDouble(0); }
                tempDepo += depamount;
            }
            depositreader.Close();
            depositreader.Dispose();
            Depsts = tempDepo;
            this.txtdep.Text = String.Format("{0:N}", Depsts);
            #endregion

            #endregion

            #region Display Covers for the Policy Number

            string CheckRCvr = "SELECT RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and rcovr between " + CoverSt + " and " + CoverEnd + " and rcovr<>" + skip + "";
            if (dm.existRecored(CheckRCvr) != 0)
            {
                dm.readSql(CheckRCvr);
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1)) { CvrNo = reader.GetInt32(1); }
                    if (!reader.IsDBNull(2)) { ADB = reader.GetDouble(2); }
                    if (CvrNo == 2) { txtadb.Text = ADB.ToString(); }
                    if (CvrNo == 4) { txtfpu.Text = ADB.ToString(); }
                    if (CvrNo == 10) { txtswjynthi.Text = ADB.ToString(); }
                    if (CvrNo == 11) { txtfe.Text = ADB.ToString(); }

                    if (CvrNo == 102) { txtadb.Text = ADB.ToString(); }
                    if (CvrNo == 110) { txtswjynthi.Text = ADB.ToString(); }
                    if (CvrNo == 111) { txtfe.Text = ADB.ToString(); }

                    if (CvrNo == 202) { txtadb.Text = ADB.ToString(); }
                    if (CvrNo == 204) { txtfpu.Text = ADB.ToString(); }
                    if (CvrNo == 210) { txtswjynthi.Text = ADB.ToString(); }
                    if (CvrNo == 211) { txtfe.Text = ADB.ToString(); }
                }
            }
            else
            {
                txtadb.Text = "0"; txtfpu.Text = "0"; txtswjynthi.Text = "0"; txtfe.Text = "0";
            }
            #endregion

            #region Read Lpolhis
            string SelectPrm = "SELECT * FROM LPHS.LPOLHIS WHERE PHPOL=" + int.Parse(litpolno.Text) + "";
            if (dm.existRecored(SelectPrm) != 0)
            {
                //Bonus = bonus.VestedBonus(long.Parse(litpolno.Text), mos);
                //txtinterim.Text = Bonus[0].ToString();
                //txtvestedbns.Text = Bonus[1].ToString();
            }
            #endregion

            #region Check Trans code
            if (Tracode.Trim() == "A")
            {
                txtgross.Enabled = false;
                txtntclm.Enabled = true;
                totalpdamt.Enabled = false;
                txtoutamt.Enabled = false;
            }
            else if (Tracode.Trim() == "B" ) 
            {
                txtgross.Enabled = false;               
                txtoutamt.Enabled = false;
                totalpdamt.Enabled = false;
            }
            else if (Tracode.Trim() == "C")
            {
                txtgross.Enabled = false;
                txtntclm.Enabled = false;
                txtoutamt.Enabled = true;
                totalpdamt.Enabled = true;
            }
            #endregion

            string Select_epf = "select EPF,ENTDATE from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
            if (dm.existRecored(Select_epf) == 0)
            {
                btnsub.Text = "Submit";
            }
            else
            {
                if (ISAuthOrize == "false")
                {
                    CHKeXGRA.Visible = false;
                    btnsub.Text = "Update";
                    string Ent_Epf = "";
                    int Date = 0;
                    dm.readSql(Select_epf);
                    OracleDataReader rd = dm.oraComm.ExecuteReader();
                    while (rd.Read())
                    {
                        if (!rd.IsDBNull(0)) { Ent_Epf = rd.GetString(0); }
                        if (!rd.IsDBNull(1)) { Date = rd.GetInt32(1); }
                    }
                    rd.Close();                    
                }
                if (ISAuthOrize == "true")
                {
                    btnsub.Text = "Authorize";
                    txtint4ln.ReadOnly = true;
                    txtloan.ReadOnly = true;
                    CHKeXGRA.Visible = true;
                }                
            }

            #region Get Already filled Data

            string GetTempData = "select POLNO,CLMNO,PROPNO,STA||''||INTIAL ||''||SUR,SUMASS,GROSSCLM," +
                                 "NETCLM,ACCBF,VESTEDBON,INTERIMBON,BONSURRAMT,SWARNAJAYA,FUNERALEXP,FPU," +
                                 "DEPOSITS,OTHERADITNS,OTHERDEDUCT,DEFPREM,INTRST,LONCAP,LOANINT,CAUSEOFDTH," +
                                 "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT," +
                                 "TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,AMT_TO_COMPLETE,CLAIMST,AGEADMITYN from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
            dm.readSql(GetTempData);
            OracleDataReader reader1 = dm.oraComm.ExecuteReader();
            while (reader1.Read())
            {
                if (!reader1.IsDBNull(0)) { litpolno.Text = reader1.GetInt64(0).ToString(); }
                if (!reader1.IsDBNull(1)) { litclm.Text = reader1.GetInt64(1).ToString(); }
                if (!reader1.IsDBNull(2)) { litpropno.Text = reader1.GetInt64(2).ToString(); }
                if (!reader1.IsDBNull(3)) { litname.Text = reader1.GetString(3); }
                if (!reader1.IsDBNull(4)) { txtsumass.Text = reader1.GetDouble(4).ToString(); }
                if (!reader1.IsDBNull(5)) { txtgross.Text = reader1.GetDouble(5).ToString(); }
                if (!reader1.IsDBNull(6)) { txtntclm.Text = reader1.GetDouble(6).ToString(); }
                if (!reader1.IsDBNull(7)) { txtadb.Text = reader1.GetDouble(7).ToString(); }
                if (!reader1.IsDBNull(8)) { txtvestedbns.Text = reader1.GetDouble(8).ToString(); }
                if (!reader1.IsDBNull(9)) { txtinterim.Text = reader1.GetDouble(9).ToString(); }
                if (!reader1.IsDBNull(10)) { txtsurrbns.Text = reader1.GetDouble(10).ToString(); }
                if (!reader1.IsDBNull(11)) { txtswjynthi.Text = reader1.GetDouble(11).ToString(); }
                if (!reader1.IsDBNull(12)) { txtfe.Text = reader1.GetDouble(12).ToString(); }
                if (!reader1.IsDBNull(13)) { txtfpu.Text = reader1.GetDouble(13).ToString(); }
                if (!reader1.IsDBNull(14)) { txtdep.Text = reader1.GetDouble(14).ToString(); }
                if (!reader1.IsDBNull(15)) { txtadd.Text = reader1.GetDouble(15).ToString(); }
                if (!reader1.IsDBNull(16)) { txtdedu.Text = reader1.GetDouble(16).ToString(); }
                if (!reader1.IsDBNull(17)) { txtdefprm.Text = reader1.GetDouble(17).ToString(); }
                if (!reader1.IsDBNull(18)) { litintrate.Text = reader1.GetDouble(18).ToString(); }
                if (!reader1.IsDBNull(19)) { txtloan.Text = reader1.GetDouble(19).ToString(); }
                if (!reader1.IsDBNull(20)) { txtint4ln.Text = reader1.GetDouble(20).ToString(); }
                if (!reader1.IsDBNull(21)) { DropDownList1.SelectedValue = reader1.GetInt32(21).ToString(); }
                if (!reader1.IsDBNull(22)) { abdpay.Text = reader1.GetDouble(22).ToString(); }
                if (!reader1.IsDBNull(23)) { sjpay.Text = reader1.GetDouble(23).ToString(); }
                if (!reader1.IsDBNull(24)) { fpupay.Text = reader1.GetDouble(24).ToString(); }
                if (!reader1.IsDBNull(25)) { fepay.Text = reader1.GetDouble(25).ToString(); }
                if (!reader1.IsDBNull(26)) { paidupval.Text = reader1.GetDouble(26).ToString(); }
                if (!reader1.IsDBNull(27)) { txtrefprms.Text = reader1.GetDouble(27).ToString(); }
                if (!reader1.IsDBNull(28)) { txtoutamt.Text = reader1.GetDouble(28).ToString(); }
                if (!reader1.IsDBNull(29)) { totalpdamt.Text = reader1.GetDouble(29).ToString(); }
                if (!reader1.IsDBNull(30)) { txtexgamt.Text = reader1.GetDouble(30).ToString(); }
                if (!reader1.IsDBNull(31)) { txtageamt.Text = reader1.GetDouble(31).ToString(); }
                if (!reader1.IsDBNull(32)) { txtamtcompolyr.Text = reader1.GetDouble(32).ToString(); }
                if (!reader1.IsDBNull(33)) { int indx = reader1.GetInt32(33); }
                if (!reader1.IsDBNull(34)) { AgeADMTYN = reader1.GetString(34); }
                if (AgeADMTYN == "Y")
                {
                    ddl_ageadmityn.SelectedIndex = 1;
                }
                else if (AgeADMTYN == "N")
                {
                    ddl_ageadmityn.SelectedIndex = 2;
                }
                else
                {
                    ddl_ageadmityn.SelectedIndex = 0;
                }
          
            }
            #endregion

            //if (ViewState["Auth"] != null)
            //{
            ISAuthOrize=hdfauth.Value;
            //}
            if (ISAuthOrize == "true")
            {
                CHKeXGRA.Visible = true;
                #region Visible Check boxes when auth
                
                chk1.Visible = true; chk14.Visible = true;
                chk2.Visible = true; chk15.Visible = true;
                chk3.Visible = true; chk16.Visible = true;
                chk4.Visible = true; chk17.Visible = true;
                chk5.Visible = true; chk18.Visible = true;
                chk6.Visible = true; chk19.Visible = true;
                chk7.Visible = true; chk20.Visible = true;
                chk8.Visible = true; chk21.Visible = true;
                chk9.Visible = true; chk22.Visible = true;
                chk10.Visible = true; 
                chk11.Visible = true; chk24.Visible = true;
                chk12.Visible = true; chk25.Visible = true;
                chk13.Visible = true; chk26.Visible = true;
                chk27.Visible = true; chk28.Visible = true;
                chk29.Visible = true;
                #endregion

                #region Set Readonly when Auth
                txtsumass.ReadOnly=true;
                txtadb.ReadOnly=true;
                txtvestedbns.ReadOnly=true;
                txtsurrbns.ReadOnly=true;
                txtfe.ReadOnly=true;
                txtdep.ReadOnly=true;
                txtgross.ReadOnly=true;
                txtamtcompolyr.ReadOnly=true;
                txtdedu.ReadOnly=true;
                txtloan.ReadOnly=true;
                txtntclm.ReadOnly=true;
                sjpay.ReadOnly=true;
                fepay.ReadOnly=true;
                txtrefprms.ReadOnly=true;
                totalpdamt.ReadOnly=true;
                txtexgamt.ReadOnly=true;               
                txtinterim.ReadOnly=true;
                txtswjynthi.ReadOnly=true;
                txtfpu.ReadOnly=true;
                txtadd.ReadOnly=true;
                txtdefprm.ReadOnly=true;
                txtint4ln.ReadOnly=true;
                abdpay.ReadOnly=true;
                fpupay.ReadOnly=true;
                paidupval.ReadOnly=true;
                txtoutamt.ReadOnly=true;
                txtageamt.ReadOnly = true;
                #endregion                
            }
            else if (ISAuthOrize == "false")
            {
                #region Invisible Check boxes whe=n Change
                chk1.Visible = false; chk14.Visible = false;
                chk2.Visible = false; chk15.Visible = false;
                chk3.Visible = false; chk16.Visible = false;
                chk4.Visible = false; chk17.Visible = false;
                chk5.Visible = false; chk18.Visible = false;
                chk6.Visible = false; chk19.Visible = false;
                chk7.Visible = false; chk20.Visible = false;
                chk8.Visible = false; chk21.Visible = false;
                chk9.Visible = false; chk22.Visible = false;
                chk10.Visible = false; 
                chk11.Visible = false; chk24.Visible = false;
                chk12.Visible = false; chk25.Visible = false;
                chk13.Visible = false; chk26.Visible = false;
                chk27.Visible = false; chk28.Visible = false;
                chk29.Visible = false;
                #endregion
                               
            }
            bonus_Surr_yr = int.Parse(ViewState["SurrYR"].ToString());
            inter_bonSTyr = int.Parse(ViewState["Interin_bonYr"].ToString());
            inter_bonSTyr = int.Parse(hdfintbonst.Value);
            mos = ViewState["mos"].ToString();
        }
        else
        {
            #region
            if (hdftracd.Value == "A") { Claimsts = 0; }
            if (hdftracd.Value == "B") { Claimsts = 1; }
            if (hdftracd.Value == "C") { Claimsts = 2; }
            ISAuthOrize =hdfauth.Value;
            Tracode = hdftracd.Value;
            brcode =int.Parse( hdfbr.Value);

            if (ddl_ageadmityn.SelectedIndex == 0)
            {
                AgeADMTYN = "";
            }
            else if (ddl_ageadmityn.SelectedIndex == 1)
            {
                AgeADMTYN = "Y";
            }
            else
            {
                AgeADMTYN = "N";
            }
            bonus_Surr_yr = int.Parse(ViewState["SurrYR"].ToString());
            inter_bonSTyr=int.Parse( ViewState["Interin_bonYr"].ToString()) ;
            inter_bonSTyr = int.Parse(hdfintbonst.Value);
            mos = hdfmos.Value; ;
        #endregion
        }
    }
    protected void btnsub_Click(object sender, EventArgs e)
    {
        Tracode = hdftracd.Value;
        lblerr.Text = "";
        lblerr2.Text = "";
        lblsuc.Text = "";
        DataManager dm = new DataManager();
        string EntryDate = DateTime.Now.ToString("yyyyMMdd");
        string ISYes = "";
        string DthPro = "Y";
        string Pol_Compl_YN = "";
        double GrsClam = 0.0;
        //if (ViewState["Auth"] != null)
        //{
            ISAuthOrize =hdfauth.Value;
        //}
        if (txtadb.Text != "0" && txtadb.Text != "") { ADB =double.Parse(txtadb.Text) ; }
        if (txtvestedbns.Text != "0" && txtvestedbns.Text != "") { VesBon = double.Parse(txtvestedbns.Text); }
        if (txtinterim.Text != "0" && txtinterim.Text != "") { Interim = double.Parse(txtinterim.Text); }
        if (txtsurrbns.Text != "0" && txtsurrbns.Text != "") { surrbon = double.Parse(txtsurrbns.Text); }
        if (txtswjynthi.Text != "0" && txtswjynthi.Text != "") { SJ = double.Parse(txtswjynthi.Text); }
        if (txtfe.Text != "0" && txtfe.Text != "") { FE = double.Parse(txtfe.Text); }
        if (txtfpu.Text != "0" && txtfpu.Text != "") { FPU = double.Parse(txtfpu.Text); }
        if (txtdep.Text != "0" && txtdep.Text != "") { Depsts = double.Parse(txtdep.Text); }
        if(txtadd.Text != "0" && txtadd.Text != ""){Otheradd=double.Parse(txtadd.Text);}
        if (txtgross.Text != "0" && txtgross.Text != "") { Grossclm = double.Parse(txtgross.Text); }
        if (txtamtcompolyr.Text != "0" && txtamtcompolyr.Text != "") { Amtcompolyr = double.Parse(txtamtcompolyr.Text); }
        if (txtdedu.Text != "0" && txtdedu.Text != "") { OthrDeduct = double.Parse(txtdedu.Text); }
        if (txtdefprm.Text != "0" && txtdefprm.Text != "") { DefPrm = double.Parse(txtdefprm.Text); }
        if (litintrate.Text != "0" && litintrate.Text != "") { Interest = double.Parse(litintrate.Text); }
        if (txtloan.Text != "0" && txtloan.Text != "") { LnCptl = double.Parse(txtloan.Text); }
        if (txtint4ln.Text != "0" && txtint4ln.Text != "") { LnInterest = double.Parse(txtint4ln.Text); }
        if(txtntclm.Text!="0" && txtntclm.Text!=""){NetClm=double.Parse(txtntclm.Text);}
        if (abdpay.Text != "0" && abdpay.Text != "") { ADBPay = double.Parse(abdpay.Text); }
        if(sjpay.Text!="0" && sjpay.Text!=""){SJPay=double.Parse(sjpay.Text);}
        if(fpupay.Text!="0" && fpupay.Text!=""){FPUPay=double.Parse(fpupay.Text);}
        if (fepay.Text != "0" && fepay.Text != "") { FEPay = double.Parse(fepay.Text); }
        if (paidupval.Text != "0" && paidupval.Text != "") { Paidupval = double.Parse(paidupval.Text); }
       
        if (txtrefprms.Text != "0" && txtrefprms.Text != "") { RefPrms = double.Parse(txtrefprms.Text); }
        if (txtoutamt.Text != "0" && txtoutamt.Text != "") { Outstanding = double.Parse(txtoutamt.Text); }
        if (totalpdamt.Text != "0" && totalpdamt.Text != "") { Totpay = double.Parse(totalpdamt.Text); }
        if (txtexgamt.Text != "0" && txtexgamt.Text != "") { exgAmt = double.Parse(txtexgamt.Text); }
        if (txtageamt.Text != "0" && txtageamt.Text != "") { AgeAmt = double.Parse(txtageamt.Text); }
        if (hdfmos.Value != null) { mos = hdfmos.Value; }
        if (hdfepf.Value != null) { Epf = hdfepf.Value; }
        if (hdftracd.Value != null) { Tracode = hdftracd.Value; }
       
        double SumAss = double.Parse(txtsumass.Text);
        //double GrossClaim = SumAss + ADB + VesBon + Interim + surrbon + SJ + FE + FPU + Depsts + Otheradd;
        double GrossClaim = double.Parse(txtgross.Text);
        double NetClaim = 0.0;        
        NetClaim=GrossClaim - (OthrDeduct + DefPrm + Interest + LnCptl + LnInterest + Amtcompolyr);
              
        if (DropDownList1.SelectedIndex >= 0)
        {
            Csofdth =int.Parse(DropDownList1.SelectedValue);            
        }
        else
        {
            //Csofdth = txtcsofdth.Text;
        }
        if (Tracode.Trim() == "C")
        {
            NetClaim = double.Parse(txtntclm.Text.Trim());
            //TotalPayAmount = NetClm - Totpay + exgAmt;
            if (CHKeXGRA.Checked)
            {
                TotalPayAmount = NetClm;
            }
            else
            {
                TotalPayAmount = NetClm + exgAmt;
            }
        }
        else
        {
            TotalPayAmount = NetClm;
        }
        ViewState["TOTAMT"] = TotalPayAmount;
        EntryIP = Request.ServerVariables.Get("REMOTE_ADDR");
        if (ddl_ageadmityn.SelectedIndex == 0)
        {
            AgeADMTYN = "N";
        }
        else if (ddl_ageadmityn.SelectedIndex == 1)
        {
            AgeADMTYN = "Y";
        }
        else
        {
            AgeADMTYN = "N";
        }
        if (ISAuthOrize != null && ISAuthOrize!="")
        {
            if (ISAuthOrize == "false")
            {
                if ((Tracode.Trim() != "C" && NetClm > 0) || Tracode.Trim() == "C")
                {
                    try
                    {
                        if (Tracode.Trim() == "A" || Tracode.Trim() == "B")
                        {
                            ISYes = "N";
                            Pol_Compl_YN = "N";
                        }
                        else
                        {
                            ISYes = "N";
                            Pol_Compl_YN = "";
                        }
                        dm.begintransaction();
                        string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                        if (dm.existRecored(SelectDthref) == 0)
                        {

                            string UpdateTemp = "Update LPHS.dthout_temp set GROSSCLM=" + Grossclm + ",NETCLM=" + NetClm + ",ACCBF=" + ADB + ",VESTEDBON=" + VesBon + ",INTERIMBON=" + Interim + ",BONSURRAMT=" + surrbon + "" +
                                            ",SWARNAJAYA=" + SJ + ",FUNERALEXP=" + FE + ",FPU=" + FPU + ",DEPOSITS=" + Depsts + ",OTHERADITNS=" + Otheradd + "" +
                                            ",OTHERDEDUCT=" + OthrDeduct + ",DEFPREM=" + DefPrm + ",INTRST=" + Interest + ",LONCAP=" + LnCptl + "" +
                                            ",LOANINT=" + LnInterest + ",CAUSEOFDTH=" + Csofdth + ",ADBPAYAMT=" + ADBPay + ",SJPAYAMT=" + SJPay + "" +
                                            ",FPUPAYAMT=" + FPUPay + ",FEPAYAMT=" + FEPay + ",SMASS_PVAL=" + Paidupval + ",REFUND_OF_PREMS=" + RefPrms + "," +
                                            "AMTOUT=" + Outstanding + ",TOTPAYAMT=" + Totpay + ",EXGRACIA_AMOUNT=" + exgAmt + ",AGE_AMT=" + AgeAmt + "," +
                                            "AMT_TO_COMPLETE=" + Amtcompolyr + ",CLAIMST=" + Claimsts + ",AGEADMITYN='" + AgeADMTYN + "' where POLNO=" + int.Parse(litpolno.Text) + " ";
                            dm.insertRecords(UpdateTemp);


                            dm.commit();
                            // dm.rollback();
                            dm.connclose();
                            lblsuc.Text = "Successfully Updated.. !!";
                        }
                        else
                        {
                            lblerr.Text = "This Policy Number has been Already inserted!!";
                        }
                    }
                    catch
                    {
                        dm.rollback();
                        lblerr.Text = "Error while Inserting Data to Database.Please Check the Values Again !!";
                    }
                }
                else
                {
                    lblerr.Text = "Please enter the NetClaim amount before Proceeds..";
                }
            }

            if (ISAuthOrize == "true")
            {
                lblerr.Text = "";
                string GetTracode = "select trim(TRANSCODE),trim(REF_TBL),MOS from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                if (dm.existRecored(GetTracode) != 0)
                {
                    dm.readSql(GetTracode);
                    OracleDataReader reader1 = dm.oraComm.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (!reader1.IsDBNull(0)) { Tracode = reader1.GetString(0); }
                        if (!reader1.IsDBNull(1)) { reftable = reader1.GetString(1); }
                        if (!reader1.IsDBNull(2)) { mos = reader1.GetString(2); }
                    }
                }

                if ((chk1.Checked) && (chk2.Checked) && (chk3.Checked) && (chk4.Checked) && (chk5.Checked) && (chk6.Checked) && (chk7.Checked) && (chk8.Checked) && (chk9.Checked) && (chk10.Checked) && (chk11.Checked) && (chk14.Checked) && (chk15.Checked) && (chk17.Checked) && (chk18.Checked) && (chk19.Checked) && (chk20.Checked) && (chk21.Checked) && (chk22.Checked) && (chk24.Checked) && (chk25.Checked) && (chk26.Checked) && (chk27.Checked) && (chk28.Checked) && (chk29.Checked))
                {
                    dm.begintransaction();
                    try
                    {
                        if (Tracode.Trim() == "A" || Tracode.Trim() == "B")
                        {
                            #region Loan Settlement
                            rcptno = 0;

                            try
                            {
                                string loansql = "select lmlon, lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1, lmebr, lmsbr, lmpty, lmlsuf, lmrnb  from lphs.lplmast " +
                                    " where lmpol=" + int.Parse(litpolno.Text) + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null) ";
                                if (dm.existRecored(loansql) != 0)
                                {
                                    dm.readSql(loansql);
                                    OracleDataReader myloanreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    while (myloanreader.Read())
                                    {
                                        this.btnloanreciept.Visible = true;

                                        int lmpdt = 0;
                                        int lmnid = 0;
                                        int lmlrd = 0;
                                        double lmpit = 0;
                                        double lmnit = 0;
                                        double lmpcp = 0;
                                        double lmncp = 0;
                                        double lmipy = 0;
                                        double lmcpy = 0;
                                        double lmitr = 0;
                                        double lmcit = 0;
                                        double lmccp = 0;
                                        int lmcdt = 0;
                                        int lmmdt = 0;

                                        loannum = myloanreader.GetInt32(0);
                                        if (!myloanreader.IsDBNull(1)) { lmpdt = myloanreader.GetInt32(1); }
                                        if (!myloanreader.IsDBNull(2)) { lmnid = myloanreader.GetInt32(2); }
                                        if (!myloanreader.IsDBNull(3)) { lmlrd = myloanreader.GetInt32(3); }
                                        if (!myloanreader.IsDBNull(4)) { lmpit = myloanreader.GetDouble(4); }
                                        if (!myloanreader.IsDBNull(5)) { lmnit = myloanreader.GetDouble(5); }
                                        if (!myloanreader.IsDBNull(6)) { lmpcp = myloanreader.GetDouble(6); }
                                        if (!myloanreader.IsDBNull(7)) { lmncp = myloanreader.GetDouble(7); }
                                        if (!myloanreader.IsDBNull(8)) { lmipy = myloanreader.GetDouble(8); }
                                        if (!myloanreader.IsDBNull(9)) { lmcpy = myloanreader.GetDouble(9); }
                                        if (!myloanreader.IsDBNull(10)) { lmitr = myloanreader.GetDouble(10); }
                                        if (!myloanreader.IsDBNull(11)) { lmcit = myloanreader.GetDouble(11); }
                                        if (!myloanreader.IsDBNull(12)) { lmccp = myloanreader.GetDouble(12); }
                                        if (!myloanreader.IsDBNull(13)) { lmcdt = myloanreader.GetInt32(13); }
                                        if (!myloanreader.IsDBNull(14)) { lmmdt = myloanreader.GetInt32(14); }
                                        string lmset = "";
                                        if (!myloanreader.IsDBNull(15)) { lmset = myloanreader.GetString(15); }
                                        string lmcd1 = "";
                                        if (!myloanreader.IsDBNull(16)) { lmcd1 = myloanreader.GetString(16); }
                                        int lmebr = myloanreader.GetInt32(17);
                                        int lmsbr = myloanreader.GetInt32(18);
                                        int lmpty = 0;
                                        if (!myloanreader.IsDBNull(19)) { lmpty = myloanreader.GetInt32(19); }
                                        int lmlsuf = 0;
                                        if (!myloanreader.IsDBNull(20)) { lmlsuf = myloanreader.GetInt32(20); }
                                        int lmrnb = 0;
                                        if (!myloanreader.IsDBNull(21)) { lmrnb = myloanreader.GetInt32(21); }

                                        lmlsuf++;

                                        if (!lmset.Equals("Y") && (!(lmcd1.Equals("D"))))
                                        {
                                            int newsurryear = int.Parse(setDate()[0].Substring(0, 4));

                                            string rcptnoquery = "SELECT RCNO FROM  LPAY.RCPTNO WHERE (RCBRNO = " + brcode + ") AND (RCYEAR = " + newsurryear + ") AND (RCTYPE = 10)";
                                            dm.readSql(rcptnoquery);
                                            OracleDataReader rcptReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                            if (rcptReader.Read())
                                            {
                                                rcptno = rcptReader.GetInt32(0);
                                                rcptno++;
                                            }
                                            else
                                            {
                                                rcptno = 1;
                                            }

                                            if (dm.existRecored(rcptnoquery) == 0)
                                            {
                                                string inertRcptnoquery = "insert into LPAY.RCPTNO (RCBRNO, RCYEAR, RCTYPE, RCNO) values(" + brcode + "," + newsurryear + ",10," + rcptno + " )";
                                                dm.insertRecords(inertRcptnoquery);
                                            }
                                            else
                                            {
                                                string updRcptnoquery = "update LPAY.RCPTNO set RCNO=" + rcptno + " where RCBRNO=" + brcode + " and RCYEAR=" + newsurryear + "  and RCTYPE= 10 ";
                                                dm.insertRecords(updRcptnoquery);
                                            }

                                            double LMPDT01 = 0;
                                            double LMNID01 = 0;
                                            double LMPIT01 = 0;
                                            double LMNIT01 = 0;
                                            double LMPCP01 = 0;
                                            LMNCP_LMCPY = 0;
                                            double LMCIT01 = 0;
                                            double LMCCP01 = 0;
                                            LMIPY01 = 0;

                                            try
                                            {
                                                double[] arr = new double[9];
                                                try
                                                {
                                                    int dateofdeath = 0;
                                                    string Getdthdt = "select DDTOFDTH from lphs.dthint where DPOLNO=" + int.Parse(litpolno.Text) + "";
                                                    if (dm.existRecored(Getdthdt) != 0)
                                                    {
                                                        dm.readSql(Getdthdt);
                                                        OracleDataReader dr = dm.oraComm.ExecuteReader();
                                                        while (dr.Read())
                                                        {
                                                            if (!dr.IsDBNull(0)) { dateofdeath = dr.GetInt32(0); }
                                                        }
                                                        dr.Close();
                                                    }
                                                    arr = loanCalculation.calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, int.Parse(setDate()[0]));

                                                    LMPDT01 = arr[0];
                                                    LMNID01 = arr[1];
                                                    LMPIT01 = arr[2];
                                                    LMNIT01 = arr[3];
                                                    LMPCP01 = arr[4];
                                                    //LMNCP_LMCPY = lmpcp;
                                                    LMCIT01 = arr[6];
                                                    LMCCP01 = arr[7];
                                                    //LMIPY01 = LnInterest;
                                                    LoanBackCal loanbackobj = new LoanBackCal(int.Parse(litpolno.Text), dateofdeath, loannum);
                                        
                                                    LMNCP_LMCPY += loanbackobj.Loancap;
                                                    LMIPY01 += loanbackobj.Backinterest;                                                    

                                                    string updateLPLMAST = "update lphs.lplmast set  lmpdt=" + LMPDT01 + ", lmpcp=" + LMPCP01 + ", lmpit=" + LMPIT01 + ", lmnid=" + LMNID01 + "," +
                                                        "lmncp=" + LMNCP_LMCPY + ", lmnit=" + LMNIT01 + ", lmebr=" + brcode + ", lmlrd=" + int.Parse(setDate()[0]) + ", lmsbr=" + brcode + ", lmpty = 2, " +
                                                        "lmrnb=" + rcptno + ",   lmcpy=" + LMNCP_LMCPY + ", lmipy=" + LMIPY01 + ", lmccp=" + LMCCP01 + ", lmcit=" + LMCIT01 + ", lmepf=" + int.Parse(Epf) + ", lmedt=" + int.Parse(setDate()[0]) + ", lmlsuf=" + lmlsuf + ", lmset='Y' where lmlon=" + loannum + " ";

                                                    dm.insertRecords(updateLPLMAST);
                                                }
                                                catch (Exception ex)
                                                { throw ex; }

                                            }
                                            catch (Exception ex)
                                            {
                                                throw new Exception("Loan Master file update Failed! " + ex.Message.ToString());
                                            }

                                            #region //--------- writting into LPAYTRN ------------

                                            string insertLPAYRTN = "insert into lpay.lpaytrn (LTLON, LTPDT, LTPCP, LTPIT, LTNID, LTNCP, LTNIT, LTEBR, LTLRD, LTSBR, LTPTY, LTRNB, LTCPY, LTIPY, LTCCP, LTCIT, ";
                                            insertLPAYRTN += " LTEPF, LTEDT, LTEBRC, LTLRDC, LTPTYC, LTRNBC, LTLSUF) values(" + loannum + "," + lmpdt + "," + lmpcp + "," + lmpit + "," + lmnid + "," + lmncp + "," + lmnit + "," + lmebr + "," + lmlrd + "," + lmsbr + "," + lmpty + "," + lmrnb + ",";
                                            insertLPAYRTN += " " + lmcpy + "," + lmipy + "," + lmccp + "," + lmcit + "," + Epf + "," + int.Parse(setDate()[0]) + "," + brcode + "," + int.Parse(setDate()[0]) + ", 10 , " + rcptno + ", " + lmlsuf + " )";

                                            dm.insertRecords(insertLPAYRTN);

                                            #endregion

                                            #region //------------ updating LPAY.LPLLEDG file -------------
                                            try
                                            {
                                                string loanLedgInsert = "insert into lpay.lplledg (llon, lsuf, lpol, lrec, lpdt, lptp,lpbr, lcap, lint, ltag,ltyp1, lamt1, lmptp2 ) values (" + loannum + ", " + lmlsuf + "," + int.Parse(litpolno.Text) + "," + rcptno + "," + int.Parse(setDate()[0]) + ",'10'," + brcode + "," + LMNCP_LMCPY + ", " + LMIPY01 + ",'0', 'D', " + (LMNCP_LMCPY + LMIPY01) + " , 'D' ) ";
                                                dm.insertRecords(loanLedgInsert);
                                                //dthRegObj.insertRecords(loanLedgUpd);

                                            }
                                            catch
                                            {
                                                throw new Exception("Ledger File Update Failed!");
                                            }

                                            #endregion

                                            #region //------------ inserting into LPAY.LPAYMAS TABLE ------------
                                            try
                                            {
                                                string lpaymasInsertSQL = "insert into lpay.lpaymas (lpbrn, lpptd, lpbtp, lprec, lpboc, lppol, lpptp, lpmd1, lpam1, lpca1, lpca2, lpsbr, lpedt, lptim, lpipa, lpacd, lpopr, lpcur, lpcrt) values(" + brcode
                                                    + ", " + int.Parse(setDate()[0]) + ", 10, " + rcptno + ", " + loannum + ", " + int.Parse(litpolno.Text) + ", 'D', '5', " + (LMNCP_LMCPY + LMIPY01) + ", " + LMNCP_LMCPY + ", " + LMIPY01 + ", " + brcode + ", " + int.Parse(setDate()[0])
                                                    + ", '" + DateTime.Now.ToLongTimeString() + "',  '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', 2392, " + Epf + ", 'LKR', 1 )";
                                                dm.insertRecords(lpaymasInsertSQL);

                                            }
                                            catch
                                            {
                                                throw new Exception("Payment Master File Update Failed!");
                                            }

                                            #endregion

                                            #region -------------- writting into loan reciept reprint table ----------

                                            #region Generate Receipt Number

                                            string rcptnostr = "";
                                            if (rcptno < 10)
                                            {
                                                rcptnostr = "00000" + rcptno.ToString();
                                            }
                                            else if (rcptno >= 10 && rcptno < 100)
                                            {
                                                rcptnostr = "0000" + rcptno.ToString();
                                            }
                                            else if (rcptno >= 100 && rcptno < 1000)
                                            {
                                                rcptnostr = "000" + rcptno.ToString();
                                            }
                                            else
                                            {
                                                rcptnostr = "00" + rcptno.ToString();
                                            }
                                            string wholeRecieptNo = this.setDate()[0] + "/" + rcptnostr + "/DC";

                                            #endregion

                                            #region Get Name And Address
                                            string sql = "select  pnsta||''|| pnint||''||PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + int.Parse(litpolno.Text) + "'";
                                            if (dm.existRecored(sql) != 0)
                                            {
                                                dm.readSql(sql);
                                                OracleDataReader oraDtReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                                                while (oraDtReader.Read())
                                                {
                                                    if (!oraDtReader.IsDBNull(0))
                                                    {
                                                        phname = oraDtReader.GetString(0);
                                                    }
                                                    if (!oraDtReader.IsDBNull(1)) { add1 = (oraDtReader.GetString(1)); } else { add1 = ""; }
                                                    if (!oraDtReader.IsDBNull(2)) { add2 = (oraDtReader.GetString(2)); } else { add2 = ""; }
                                                    if (!oraDtReader.IsDBNull(3)) { add3 = (oraDtReader.GetString(3)); } else { add3 = ""; }
                                                    if (!oraDtReader.IsDBNull(4)) { add4 = (oraDtReader.GetString(4)); } else { add4 = ""; }
                                                }
                                            }
                                            else
                                            {
                                                phname = ""; add1 = ""; add2 = ""; add3 = ""; add4 = "";
                                            }
                                            #endregion

                                            string lnRecRepSel = "select polino from LPHS.LOAN_RCIEPT_REPRINT where polino = " + int.Parse(litpolno.Text) + " and loanno = " + loannum + " and type_of_settlmnt = 'S' ";
                                            if (dm.existRecored(lnRecRepSel) == 0)
                                            {
                                                string lnRecRepInsert = "INSERT INTO LPHS.LOAN_RCIEPT_REPRINT (POLINO ,LOANNO ,RECIEPTNO ,PRINTDATE ,BRANCH ,PAIDBY ,AD1 ,AD2 ,AD3 ,AD4 ,CAPITAL ,INTEREST ," +
                                                    "CLAIMNO ,CLAIMAMT ,RECIEVEDAMT ,TYPE_OF_SETTLMNT, PRINT_EPF, PRINT_TIME, PRINT_IP )" +
                                                    "VALUES (" + int.Parse(litpolno.Text) + " ," + loannum + " ,'" + wholeRecieptNo + "' ," + int.Parse(this.setDate()[0]) + " ," + brcode + " ,'" + phname + "' ,'" + PrepareApostrophe(add1) + "' ,'" + PrepareApostrophe(add2) + "' ," +
                                                    "'" + PrepareApostrophe(add3) + "' ,'" + PrepareApostrophe(add4) + "' ," + LMNCP_LMCPY + " ," + LMIPY01 + " ," + int.Parse(litclm.Text) + " ," + (LMIPY01 + LMNCP_LMCPY) + " ," + (LMIPY01 + LMNCP_LMCPY) + " ,'D'," +
                                                    "'" + Epf + "', '" + this.setDate()[1] + "', '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "'  )";
                                                dm.insertRecords(lnRecRepInsert);
                                            }

                                            #endregion
                                        }
                                    }

                                }
                                else { loannum = 0; LMNCP_LMCPY = 0; LMIPY01 = 0; }
                            }
                            catch
                            {
                                throw new Exception("Loan Settlement Failed!Please Settle That Manually..");
                            }
                            #endregion
                        }

                        if ((reftable == "D") && ((Tracode == "A") || Tracode == "B"))
                        {
                            #region If Pol Number found in Dthout and Transaction code A or B
                            string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                            if (dm.existRecored(SelectDthref) == 0)
                            {
                                string InsertToDthRef = "INSERT INTO LPHS.DTHREF(DRPOLNO,DRMOS,DRCLMNO,DRACCBF,DRVESTEDBON,DRINTERIMBON," +
                                                             "DRBONSURRAMT,DRSWARNAJAYA,DRFUNERALEXP,DRFPU,DRDEPOSITS,DROTHERADITNS,DRGROSSCLM," +
                                                             "DEOTHERDEDUCT,DRDEFPREM,DRLONCAP,DRLOANINT,DRNETCLM,DCAUSEOFDTH,DENTDT,DENTEPF," +
                                                             "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT,TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,MEMOAPRV" +
                                                             ",POL_COMPL_YN,AMT_TO_COMPLETE,DRBONSURRYR,DRAGEADMIT,INTBONSTYR,branch)VALUES " +
                                                             "(" + int.Parse(litpolno.Text) + ",'" + mos + "'," + int.Parse(litclm.Text) + "," + ADB + "," +
                                                             "" + VesBon + "," + Interim + "," + surrbon + "," + SJ + "," + FE + "," + FPU + "," + Depsts + "" +
                                                             "," + Otheradd + "," + Grossclm + "," + OthrDeduct + "," + DefPrm + "," + LnCptl + "" +
                                                             "," + LnInterest + "," + TotalPayAmount + "," + Csofdth + "," + int.Parse(EntryDate) + ",'" + Epf + "'" +
                                                             "," + ADBPay + "," + SJPay + "," + FPUPay + "," + FEPay + "," + Paidupval + "," + RefPrms + "" +
                                                             "," + Outstanding + "," + Totpay + "," + exgAmt + "," + AgeAmt + ",'" + ISYes + "','" + Pol_Compl_YN + "'," +
                                                             "" + Amtcompolyr + "," + bonus_Surr_yr + ",'" + AgeADMTYN + "'," + inter_bonSTyr + "," + brcode + ")";
                                dm.insertRecords(InsertToDthRef);

                                string UpdateDthout = "update lphs.dthout set EPF='" + Epf + "',DTHPRO='" + DthPro + "',PRODATE=" + int.Parse(EntryDate) + " where POLNO=" + int.Parse(litpolno.Text) + "";
                                dm.insertRecords(UpdateDthout);
                                string Deletetemp = "delete from lphs.dthout_temp where polno=" + int.Parse(litpolno.Text) + "";
                                dm.DeleteRecords(Deletetemp);
                            }
                            #endregion
                            lblsuc.Text = "Record Updates SuccessFully......";
                        }
                        if ((reftable == "D") && (Tracode == "C"))
                        {
                            // TotalPayAmount=Outstanding;
                            #region If Pol number in Dthout and Partly Paid
                            string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                            if (dm.existRecored(SelectDthref) == 0)
                            {
                                string InsertToDthRef = "INSERT INTO LPHS.DTHREF(DRPOLNO,DRMOS,DRCLMNO,DRACCBF,DRVESTEDBON,DRINTERIMBON," +
                                                             "DRBONSURRAMT,DRSWARNAJAYA,DRFUNERALEXP,DRFPU,DRDEPOSITS,DROTHERADITNS,DRGROSSCLM," +
                                                             "DEOTHERDEDUCT,DRDEFPREM,DRLONCAP,DRLOANINT,DRNETCLM,DCAUSEOFDTH,DENTDT,DENTEPF," +
                                                             "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT,TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,MEMOAPRV" +
                                                             ",POL_COMPL_YN,AMT_TO_COMPLETE)VALUES " +
                                                             "(" + int.Parse(litpolno.Text) + ",'" + mos + "'," + int.Parse(litclm.Text) + "," + ADB + "," +
                                                             "" + VesBon + "," + Interim + "," + surrbon + "," + SJ + "," + FE + "," + FPU + "," + Depsts + "" +
                                                             "," + Otheradd + "," + Grossclm + "," + OthrDeduct + "," + DefPrm + "," + LnCptl + "" +
                                                             "," + LnInterest + "," + TotalPayAmount + "," + Csofdth + "," + int.Parse(EntryDate) + ",'" + Epf + "'" +
                                                             "," + ADBPay + "," + SJPay + "," + FPUPay + "," + FEPay + "," + Paidupval + "," + RefPrms + "" +
                                                             "," + Outstanding + "," + Totpay + "," + exgAmt + "," + AgeAmt + ",'Y','" + Pol_Compl_YN + "'," + Amtcompolyr + ")";
                                dm.insertRecords(InsertToDthRef);

                                string UpdateDthout = "update lphs.dthout set EPF='" + Epf + "',DTHPRO='" + DthPro + "',PRODATE=" + int.Parse(EntryDate) + " where POLNO=" + int.Parse(litpolno.Text) + "";
                                dm.insertRecords(UpdateDthout);
                                string Deletetemp = "delete from lphs.dthout_temp where polno=" + int.Parse(litpolno.Text) + "";
                                dm.DeleteRecords(Deletetemp);
                            }
                            #endregion
                            lblsuc.Text = "Record Updates SuccessFully......";
                        }
                        if (reftable == "E")
                        {
                            string seldthout = "select * from lphs.dthout where POLNO=" + int.Parse(litpolno.Text) + "";

                            if ((Claimsts == 0) || (Claimsts == 1))
                            {
                                if (dm.existRecored(seldthout) == 0)
                                {
                                    string WritetoDthout = "insert into lphs.dthout (POLNO,CLMNO,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,EPF)" +
                                                           "values(" + int.Parse(litpolno.Text) + "," + int.Parse(litclm.Text) + "," + int.Parse(hdfcomdt.Value) + "," + int.Parse(hdftbl.Value) + "," +
                                                           "" + int.Parse(hdftrm.Value) + "," + double.Parse(txtsumass.Text) + "," + int.Parse(hdfmode.Value) + "," +
                                                           "" + double.Parse(txtgross.Text) + "," + double.Parse(txtntclm.Text) + "," + int.Parse(hdfbr.Value) + ",'" + Tracode + "','" + hdfepf.Value + "')";
                                    dm.insertRecords(WritetoDthout);
                                }

                                #region If Pol Number found in Exit Table and Claim Status Pending or Admitted
                                string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(SelectDthref) == 0)
                                {
                                    string InsertToDthRef = "INSERT INTO LPHS.DTHREF(DRPOLNO,DRMOS,DRCLMNO,DRACCBF,DRVESTEDBON,DRINTERIMBON," +
                                                                 "DRBONSURRAMT,DRSWARNAJAYA,DRFUNERALEXP,DRFPU,DRDEPOSITS,DROTHERADITNS,DRGROSSCLM," +
                                                                 "DEOTHERDEDUCT,DRDEFPREM,DRLONCAP,DRLOANINT,DRNETCLM,DCAUSEOFDTH,DENTDT,DENTEPF," +
                                                                 "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT,TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,MEMOAPRV" +
                                                                 ",POL_COMPL_YN,AMT_TO_COMPLETE)VALUES " +
                                                                 "(" + int.Parse(litpolno.Text) + ",'" + mos + "'," + int.Parse(litclm.Text) + "," + ADB + "," +
                                                                 "" + VesBon + "," + Interim + "," + surrbon + "," + SJ + "," + FE + "," + FPU + "," + Depsts + "" +
                                                                 "," + Otheradd + "," + Grossclm + "," + OthrDeduct + "," + DefPrm + "," + LnCptl + "" +
                                                                 "," + LnInterest + "," + TotalPayAmount + "," + Csofdth + "," + int.Parse(EntryDate) + ",'" + Epf + "'" +
                                                                 "," + ADBPay + "," + SJPay + "," + FPUPay + "," + FEPay + "," + Paidupval + "," + RefPrms + "" +
                                                                 "," + Outstanding + "," + Totpay + "," + exgAmt + "," + AgeAmt + ",'" + ISYes + "','" + Pol_Compl_YN + "'," + Amtcompolyr + ")";
                                    dm.insertRecords(InsertToDthRef);

                                    string UpdateDthout = "update lphs.dthout set EPF='" + Epf + "',DTHPRO='" + DthPro + "',PRODATE=" + int.Parse(EntryDate) + " where POLNO=" + int.Parse(litpolno.Text) + "";
                                    dm.insertRecords(UpdateDthout);
                                    string Deletetemp = "delete from lphs.dthout_temp where polno=" + int.Parse(litpolno.Text) + "";
                                    dm.DeleteRecords(Deletetemp);
                                }
                                #endregion

                            }
                            if (Claimsts == 2)
                            {
                                if (dm.existRecored(seldthout) == 0)
                                {
                                    string WritetoDthout = "insert into lphs.dthout (POLNO,CLMNO,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,EPF)" +
                                                               "values(" + int.Parse(litpolno.Text) + "," + int.Parse(litclm.Text) + "," + int.Parse(hdfcomdt.Value) + "," + int.Parse(hdftbl.Value) + "," +
                                                               "" + int.Parse(hdftrm.Value) + "," + double.Parse(txtsumass.Text) + "," + int.Parse(hdfmode.Value) + "," +
                                                               "" + double.Parse(txtgross.Text) + "," + double.Parse(txtntclm.Text) + "," + int.Parse(hdfbr.Value) + ",'" + Tracode + "','" + hdfepf.Value + "')";
                                    dm.insertRecords(WritetoDthout);
                                }

                                #region If Pol Number found in Exit Table and Claim Status Partly Paid
                                string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(SelectDthref) == 0)
                                {
                                    // TotalPayAmount = Outstanding;
                                    string InsertToDthRef = "INSERT INTO LPHS.DTHREF(DRPOLNO,DRMOS,DRCLMNO,DRACCBF,DRVESTEDBON,DRINTERIMBON," +
                                                                 "DRBONSURRAMT,DRSWARNAJAYA,DRFUNERALEXP,DRFPU,DRDEPOSITS,DROTHERADITNS,DRGROSSCLM," +
                                                                 "DEOTHERDEDUCT,DRDEFPREM,DRLONCAP,DRLOANINT,DRNETCLM,DCAUSEOFDTH,DENTDT,DENTEPF," +
                                                                 "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT,TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,MEMOAPRV" +
                                                                 ",POL_COMPL_YN,AMT_TO_COMPLETE)VALUES " +
                                                                 "(" + int.Parse(litpolno.Text) + ",'" + mos + "'," + int.Parse(litclm.Text) + "," + ADB + "," +
                                                                 "" + VesBon + "," + Interim + "," + surrbon + "," + SJ + "," + FE + "," + FPU + "," + Depsts + "" +
                                                                 "," + Otheradd + "," + Grossclm + "," + OthrDeduct + "," + DefPrm + "," + LnCptl + "" +
                                                                 "," + LnInterest + "," + TotalPayAmount + "," + Csofdth + "," + int.Parse(EntryDate) + ",'" + Epf + "'" +
                                                                 "," + ADBPay + "," + SJPay + "," + FPUPay + "," + FEPay + "," + Paidupval + "," + RefPrms + "" +
                                                                 "," + Outstanding + "," + Totpay + "," + exgAmt + "," + AgeAmt + ",'Y','" + Pol_Compl_YN + "'," + Amtcompolyr + ")";
                                    dm.insertRecords(InsertToDthRef);

                                    string UpdateDthout = "update lphs.dthout set EPF='" + Epf + "',DTHPRO='" + DthPro + "',PRODATE=" + int.Parse(EntryDate) + " where POLNO=" + int.Parse(litpolno.Text) + "";
                                    dm.insertRecords(UpdateDthout);
                                    string Deletetemp = "delete from lphs.dthout_temp where polno=" + int.Parse(litpolno.Text) + "";
                                    dm.DeleteRecords(Deletetemp);
                                }
                                #endregion
                            }
                            lblsuc.Text = "Record Updates SuccessFully......";
                        }
                        if (reftable == "P" || reftable == "L" || reftable == "M")
                        {
                            string seldthout = "select * from lphs.dthout where POLNO=" + int.Parse(litpolno.Text) + "";

                            if ((Claimsts == 0) || (Claimsts == 1))
                            {
                                if (dm.existRecored(seldthout) == 0)
                                {
                                    string WritetoDthout = "insert into lphs.dthout (POLNO,CLMNO,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,EPF)" +
                                                           "values(" + int.Parse(litpolno.Text) + "," + int.Parse(litclm.Text) + "," + int.Parse(hdfcomdt.Value) + "," + int.Parse(hdftbl.Value) + "," +
                                                           "" + int.Parse(hdftrm.Value) + "," + double.Parse(txtsumass.Text) + "," + int.Parse(hdfmode.Value) + "," +
                                                           "" + double.Parse(txtgross.Text) + "," + double.Parse(txtntclm.Text) + "," + int.Parse(hdfbr.Value) + ",'" + Tracode + "','" + hdfepf.Value + "')";
                                    dm.insertRecords(WritetoDthout);
                                }

                                #region If Pol Number found in Premast or Lapse Tables and Claim Status Pending or Admitted
                                string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(SelectDthref) == 0)
                                {
                                    string InsertToDthRef = "INSERT INTO LPHS.DTHREF(DRPOLNO,DRMOS,DRCLMNO,DRACCBF,DRVESTEDBON,DRINTERIMBON," +
                                                                 "DRBONSURRAMT,DRSWARNAJAYA,DRFUNERALEXP,DRFPU,DRDEPOSITS,DROTHERADITNS,DRGROSSCLM," +
                                                                 "DEOTHERDEDUCT,DRDEFPREM,DRLONCAP,DRLOANINT,DRNETCLM,DCAUSEOFDTH,DENTDT,DENTEPF," +
                                                                 "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT,TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,MEMOAPRV" +
                                                                 ",POL_COMPL_YN,AMT_TO_COMPLETE)VALUES " +
                                                                 "(" + int.Parse(litpolno.Text) + ",'" + mos + "'," + int.Parse(litclm.Text) + "," + ADB + "," +
                                                                 "" + VesBon + "," + Interim + "," + surrbon + "," + SJ + "," + FE + "," + FPU + "," + Depsts + "" +
                                                                 "," + Otheradd + "," + Grossclm + "," + OthrDeduct + "," + DefPrm + "," + LnCptl + "" +
                                                                 "," + LnInterest + "," + TotalPayAmount + "," + Csofdth + "," + int.Parse(EntryDate) + ",'" + Epf + "'" +
                                                                 "," + ADBPay + "," + SJPay + "," + FPUPay + "," + FEPay + "," + Paidupval + "," + RefPrms + "" +
                                                                 "," + Outstanding + "," + Totpay + "," + exgAmt + "," + AgeAmt + ",'" + ISYes + "','" + Pol_Compl_YN + "'," + Amtcompolyr + ")";
                                    dm.insertRecords(InsertToDthRef);

                                    string UpdateDthout = "update lphs.dthout set EPF='" + Epf + "',DTHPRO='" + DthPro + "',PRODATE=" + int.Parse(EntryDate) + " where POLNO=" + int.Parse(litpolno.Text) + "";
                                    dm.insertRecords(UpdateDthout);
                                    string Deletetemp = "delete from lphs.dthout_temp where polno=" + int.Parse(litpolno.Text) + "";
                                    dm.DeleteRecords(Deletetemp);
                                }
                                #endregion
                            }
                            if (Claimsts == 2)
                            {
                                if (dm.existRecored(seldthout) == 0)
                                {
                                    string WritetoDthout = "insert into lphs.dthout (POLNO,CLMNO,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,EPF)" +
                                                               "values(" + int.Parse(litpolno.Text) + "," + int.Parse(litclm.Text) + "," + int.Parse(hdfcomdt.Value) + "," + int.Parse(hdftbl.Value) + "," +
                                                               "" + int.Parse(hdftrm.Value) + "," + double.Parse(txtsumass.Text) + "," + int.Parse(hdfmode.Value) + "," +
                                                               "" + double.Parse(txtgross.Text) + "," + double.Parse(txtntclm.Text) + "," + int.Parse(hdfbr.Value) + ",'" + Tracode + "','" + hdfepf.Value + "')";
                                    dm.insertRecords(WritetoDthout);
                                }

                                #region If Pol Number found in Premast or Lapse Tables and Claim Status Partly Paid
                                //TotalPayAmount = Outstanding;

                                string SelectDthref = "select * from lphs.dthref where DRPOLNO=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(SelectDthref) == 0)
                                {
                                    string InsertToDthRef = "INSERT INTO LPHS.DTHREF(DRPOLNO,DRMOS,DRCLMNO,DRACCBF,DRVESTEDBON,DRINTERIMBON," +
                                                                 "DRBONSURRAMT,DRSWARNAJAYA,DRFUNERALEXP,DRFPU,DRDEPOSITS,DROTHERADITNS,DRGROSSCLM," +
                                                                 "DEOTHERDEDUCT,DRDEFPREM,DRLONCAP,DRLOANINT,DRNETCLM,DCAUSEOFDTH,DENTDT,DENTEPF," +
                                                                 "ADBPAYAMT,SJPAYAMT,FPUPAYAMT,FEPAYAMT,SMASS_PVAL,REFUND_OF_PREMS,AMTOUT,TOTPAYAMT,EXGRACIA_AMOUNT,AGE_AMT,MEMOAPRV" +
                                                                 ",POL_COMPL_YN,AMT_TO_COMPLETE)VALUES " +
                                                                 "(" + int.Parse(litpolno.Text) + ",'" + mos + "'," + int.Parse(litclm.Text) + "," + ADB + "," +
                                                                 "" + VesBon + "," + Interim + "," + surrbon + "," + SJ + "," + FE + "," + FPU + "," + Depsts + "" +
                                                                 "," + Otheradd + "," + Grossclm + "," + OthrDeduct + "," + DefPrm + "," + LnCptl + "" +
                                                                 "," + LnInterest + "," + TotalPayAmount + "," + Csofdth + "," + int.Parse(EntryDate) + ",'" + Epf + "'" +
                                                                 "," + ADBPay + "," + SJPay + "," + FPUPay + "," + FEPay + "," + Paidupval + "," + RefPrms + "" +
                                                                 "," + Outstanding + "," + Totpay + "," + exgAmt + "," + AgeAmt + ",'Y','" + Pol_Compl_YN + "'," + Amtcompolyr + ")";
                                    dm.insertRecords(InsertToDthRef);

                                    string UpdateDthout = "update lphs.dthout set EPF='" + Epf + "',DTHPRO='" + DthPro + "',PRODATE=" + int.Parse(EntryDate) + " where POLNO=" + int.Parse(litpolno.Text) + "";
                                    dm.insertRecords(UpdateDthout);
                                    string Deletetemp = "delete from lphs.dthout_temp where polno=" + int.Parse(litpolno.Text) + "";
                                    dm.DeleteRecords(Deletetemp);

                                }
                                #endregion
                            }
                            lblsuc.Text = "Record Updates SuccessFully......";
                        }
                        dm.commit();
                        btnloanreciept.Visible = true;
                        // dm.rollback();
                        dm.oraComm.Connection.Close();
                        btnsub.Enabled = false;
                        if (Tracode.ToUpper() == "C")
                        {
                            btn_next.Visible = true;
                            btn_memo.Visible = false;
                        }
                        else
                        {
                            btn_next.Visible = false;
                            btn_memo.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.rollback();
                        dm.oraComm.Connection.Close();
                        lblerr2.Text = ex.Message;
                    }
                }
                else
                {
                    lblerr2.Text = "Please Check every field before Submit...";
                }
            }
        }
        else
        {
            EPage.Messege = "Session Expired.Please log to the system again...";
            Response.Redirect("EPage.aspx");
        }
      
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("DthOldEntry.aspx?pol=" + litpolno.Text + " & TraCode = " + hdftracd.Value + "");
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
       
        //loannum = this.PreviousPage.LOANNUM;
        //rcptno = this.PreviousPage.Rcptno;
        //phname = this.PreviousPage.Phname;
        //ad1 = this.PreviousPage.Ad1;
        //ad2 = this.PreviousPage.Ad2;
        //ad3 = this.PreviousPage.Ad3;
        //ad4 = this.PreviousPage.Ad4;
        //LMNCP_LMCPY = this.PreviousPage.LMNCP_LMCPYprop;
        //LMIPY01 = this.PreviousPage.LMIPY01prop;
        
    }
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
    protected void ddl_ageadmityn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_ageadmityn.SelectedIndex == 0)
        {
            AgeADMTYN = "N";
        }
        else if (ddl_ageadmityn.SelectedIndex == 1)
        {
            AgeADMTYN = "Y";
        }
        else
        {
            AgeADMTYN = "N";
        }
    }
    protected void btn_next_Click(object sender, EventArgs e)
    {
        DataManager dm = new DataManager();
        NetClm = double.Parse(ViewState["TOTAMT"].ToString());
        Outstanding = double.Parse(txtoutamt.Text.Trim());
        ClaimNo = int.Parse(litclm.Text);

        int dthdate = 0;
        string getdtdate = "select DDTOFDTH from lphs.dthint where DPOLNO=" + int.Parse(litpolno.Text) + " and DMOS='"+mos+"'";
        if (dm.existRecored(getdtdate) != 0)
        {
            dm.readSql(getdtdate);
            OracleDataReader orared = dm.oraComm.ExecuteReader();
            while (orared.Read())
            {
                if (!orared.IsDBNull(0)) { dthdate = orared.GetInt32(0); } else { dthdate = 0; }
            }
        }        
        Response.Redirect("paymentDistn001.aspx?polno=" + int.Parse(litpolno.Text) + "&totamount=" + NetClm + "&outAmt=" + Outstanding + "&claimno=" + ClaimNo + "&theMof=" + mos + "&dtofdth=" +dthdate+ "");
    }
    protected void btn_memo_Click(object sender, EventArgs e)
    {
        Response.Redirect("dthPay001.aspx?polno=" + int.Parse(litpolno.Text) + "&theMof=" + mos + "");
    }

    #region Prepare Apostrophy
    public string PrepareApostrophe(string str)
    {
        string newStr = "";
        bool pZero = false, pEnd = false, pMiddle = false;

        if (str.IndexOf("'") < 0) return str;


        pZero = str.IndexOf("'") == 0 ? true : false;
        pEnd = str.LastIndexOf("'") + 1 == str.Length ? true : false;
        pMiddle = str.Substring(1, str.Length - 2).LastIndexOf("'") > 0 ? true : false;


        newStr = pZero && pMiddle && pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 2).Replace("'", "'||chr(39)||'") + "'||chr(39)|| '"
            : !pZero && pMiddle && pEnd ? str.Substring(0, (str.Length - 1)).Replace("'", "'||chr(39)||'") + "'||chr(39)|| '"
            : pZero && !pMiddle && pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 2) + "'||chr(39)|| '"
            : pZero && pMiddle && !pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 1).Replace("'", "'||chr(39)||'")
            : pZero && !pMiddle && !pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 1)
            : !pZero && !pMiddle && pEnd ? str.Substring(0, str.Length - 1) + "'||chr(39)|| '"
            : !pZero && pMiddle && !pEnd ? str.Substring(0, str.Length).Replace("'", "'||chr(39)||'")
            : str;

        return newStr;
    }
    #endregion

    public int Polno
    {
        get { return PolNo; }
        set { PolNo = value; }
    }
    public string Phname
    {
        get { return phname; }
        set { phname = value; }
    }
    public string Ad1
    {
        get { return add1; }
        set { add1 = value; }
    }
    public string Ad2
    {
        get { return add2; }
        set { add2 = value; }
    }
    public string Ad3
    {
        get { return add3; }
        set { add3 = value; }
    }
    public string Ad4
    {
        get { return add4; }
        set { add4 = value; }
    }
    public int LOANNUM
    {
        get { return loannum; }
        set { loannum = value; }
    }
    public int Rcptno
    {
        get { return rcptno; }
        set { rcptno = value; }
    }
    public double LMNCP_LMCPYprop
    {
        get { return LMNCP_LMCPY; }
        set { LMNCP_LMCPY = value; }
    }
    public double LMIPY01prop
    {
        get { return LMIPY01; }
        set { LMIPY01 = value; }
    }
    public int Claim_No
    {
        get { return ClaimNo; }
        set { ClaimNo = value; }
    }
    protected void btnloanreciept_Click(object sender, EventArgs e)
    {
        PolNo = int.Parse(litpolno.Text);
        ClaimNo = int.Parse(litclm.Text);

        Server.Transfer("DthOutLnRecptprint001.aspx");
    }
}
