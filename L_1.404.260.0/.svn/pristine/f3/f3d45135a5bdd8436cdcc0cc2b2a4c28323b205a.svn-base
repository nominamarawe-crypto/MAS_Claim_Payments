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
[Serializable ]

public partial class DthOldEntry : System.Web.UI.Page
{
    #region Variables
   
    //********************************************************
    private string memoApprv = "";
    DataManager dthpayObj;
    private ArrayList arr01;
    private ArrayList arr02;
    private string STA;
    private int countStatic;
    //************************************************************
    
    private int Polno;    private int BrCode;
    private int BRN = 0;    private string entEPF = "";
    private int ClaimNo;    private int PropNo;
    private string IDNo;    private int CommDate;
    private string mos;    private string name;
    private string EntryEpf;    private string EntryIP;
    private double SumAss;    private int DeathDate;
    private int InfDate;    private double Premium;
    private int Mode;    private int Nexteffdt;
    private int PACode;    private int AgtCode;
    private int OrgCode;    private int Tble;
    private int Term;    private string TraCode;
    private double Grossclm;    private double NetClm;
    private string reftable;    private string ISAuthOrize;
    private string PMCODE;    private string Claimsts;
    private string Fullname; private string Surname;
    private int Prtype; private int DOB;
    private string childfullname; private string childSurna;
    private int child_dob; private int ch_prtype;
    private int LoanNum;
    LoanBackCal loanbackobj; double loanCapital = 0;
    double loaninterest = 0; string bonsuryn;
    private int bonSurrYr; private double loanint_rate;
    private string lnGrntDate; private string polstat;
    private int polDuraYrs, polDuraMnths, polDuraDays;
    private int bonuscount; private double vestedBonus;
    private double interimbonus; private int interimBonStYR;
    double totsurrbonus = 0; private double surrrenderedbons;
    double totbonus = 0; private string civilorforces;
    int surrbonuscount; string incrementcountstr1;
    string incrementcountstrdclr1; private int CountbonYr;
    int intBonYrfrmtble;
    double intBonValfrmtble;
   
    #endregion

    #region Public Variables
    public int POLNO
    {
        get { return int.Parse(litpolno.Text);}// Polno;
        set { Polno = value; }
    }
    public int CLMNO
    {
        get { return ClaimNo; }
        set { ClaimNo = value; }
    }
    public int PROPNO
    {
        get { return PropNo; }
        set { PropNo = value; }
    }
    public string  IDNO
    {
        get { return IDNo; }
        set { IDNo = value; }
    }
    public int COMMDATE
    {
        get { return int.Parse(txtcomdat.Text); }
        set { CommDate = value; }
    }
    public string MOS
    {
        get { return mos; }
        set { mos = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public double SUMASS
    {
        get { return SumAss; }
        set { SumAss = value; }
    }
    public string EPF
    {
        get { return entEPF; }
        set { entEPF = value; }
    }
    public string TRACODE
    {
        get { return TraCode; }
        set { TraCode = value; }
    }
    public double GROSS
    {
        get { return Grossclm; }
        set { Grossclm = value; }
    }
    public double NET
    {
        get { return NetClm; }
        set { NetClm = value; }
    }
    public int TABLE
    {
        get { return int.Parse(txttbl.Text.Trim()); }
        set { Tble = value; }
    }
    public int TERM
    {
        get { return int.Parse(txttrm.Text.Trim()); }
        set { Term= value; }
    }
    public int MODE
    {
        get { return int.Parse(txtmod.Text.Trim()); }
        set { Mode = value; }
    }
    public int BRCODE
    {
        get { return BRN; }
        set { BRN = value; }
    }
    public int LoanNumber
    {
        get { return LoanNum; }
        set { LoanNum = value; }
    }
    public string  LoanGrantDate
    {
        get { return lngrndt.Value; }
        set { lngrndt.Value = value; }
    }
    public double LoanCapital
    {
        get { return loanCapital; }
        set { loanCapital = value; }
    }
    public double loanInterest
    {
        get { return loaninterest; }
        set { loaninterest = value; }
    }
    
    public double LoanINTRATE
    {
        get { return loanint_rate; }
        set { loanint_rate = value; }
    }
    public double VestedBon
    {
        get { return vestedBonus; }
        set { vestedBonus = value; }
    }
    public double InterimBon
    {
        get { return interimbonus; }
        set { interimbonus = value; }
    }
    public double SuRRBON
    {
        get { return surrrenderedbons; }
        set { surrrenderedbons = value; }
    }
    public int BONSURRYR
    {
        get { return bonSurrYr; }
        set { bonSurrYr = value; }
    }
    public int InterBonStyr
    {
        get { return interimBonStYR; }
        set { interimBonStYR = value; }
    }
    public string AUTH
    {
        get { return hdfauth.Value; }
        set { hdfauth.Value = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DataManager dm = new DataManager();
       
        if (Session["EPFNum"] != null)
        {
            entEPF = Session["EPFNum"].ToString();
            BRN = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            EPage.Messege = "Session Expired.Please log to the system again...";
            Response.Redirect("EPage.aspx");
        }
        if (!IsPostBack)
        {
            #region Get VAlues from Query String

            Polno = Convert.ToInt32(Request.QueryString.Get("pol"));
            TraCode = Request.QueryString.Get("TraCode");
            ISAuthOrize = Request.QueryString.Get("Isauth");
            hdfauth.Value = ISAuthOrize;
            string dthdt = Request.QueryString.Get("dthdt");
            #endregion

            #region Get Date of Death and Assign It
            btnsub.Visible = true;
            if (dthdt != null)
            {
                DeathDate = int.Parse(dthdt);
            }
            //ViewState["Auth"] = hdfauth.Value;
            if (ISAuthOrize == "true")
            {
                string Getdthdate = "select DTOFDTH from lphs.dthout_temp where POLNO=" + Polno + "";
                dm.readSql(Getdthdate);
                OracleDataReader red5 = dm.oraComm.ExecuteReader();
                while (red5.Read())
                {
                    if (!red5.IsDBNull(0))
                    {
                        DeathDate = red5.GetInt32(0);
                        hdfdthdt.Value = DeathDate.ToString();
                    }
                }
                red5.Close();
            }
            hdftrcode.Value = TraCode;
            ViewState["tracode"] = TraCode;
            hdfdthdt.Value = DeathDate.ToString();
            if (DeathDate != 0)
            {
                lbldtdt.Text = DeathDate.ToString().Substring(0, 4) + "/" + DeathDate.ToString().Substring(4, 2) + "/" + DeathDate.ToString().Substring(6, 2);
            }
            #endregion

            #region Check Policy Number
            string SelDthout = "select POLNO,CLMNO,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH from LPHS.DTHOUT where POLNO=" + Polno + "";
            string SetExittlb = "select EXTPOL,EXTCLM,EXTCOM,EXTTBL,EXTTRM,EXTSUM,EXTMD,EXTBR from lphs.exsurren where EXTPOL=" + Polno + "";

            if (dm.existRecored(SelDthout) != 0)
            {
                #region Get Data From DthOUT
                dm.readSql(SelDthout);
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) { litpolno.Text = reader.GetInt32(0).ToString(); }
                    if (!reader.IsDBNull(1))
                    {
                        long clmno = reader.GetInt64(1);
                        txtclmno.Text = clmno.ToString();
                        if (clmno > 0)
                        {
                            txtclmno.Enabled = false;
                        }
                        else
                        {
                            txtclmno.Enabled = true;
                        }
                    }
                    if (!reader.IsDBNull(2)) { txtcomdat.Text = reader.GetInt32(2).ToString(); }
                    if (!reader.IsDBNull(3)) { txttbl.Text = reader.GetInt32(3).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                    if (!reader.IsDBNull(4)) { txttrm.Text = reader.GetInt32(4).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                    if (!reader.IsDBNull(5)) { txtsumass.Text = reader.GetDouble(5).ToString("N0"); }
                    if (!reader.IsDBNull(6)) { txtmod.Text = reader.GetString(6); Mode = int.Parse(reader.GetString(6)); }
                    if (!reader.IsDBNull(7)) { txtgrsclm.Text = reader.GetDouble(7).ToString(); }
                    if (!reader.IsDBNull(8)) { txtnetclm.Text = reader.GetDouble(8).ToString(); }
                    if (!reader.IsDBNull(9)) { BrCode = reader.GetInt32(9); }
                }
                reftable = "D";
                ViewState["Reftbl"] = reftable;
                hdfbrn.Value = BrCode.ToString();
                reader.Close();
                #endregion
            }
            if (dm.existRecored(SelDthout) == 0)
            {
                #region Get Data From Exit Table
                if (dm.existRecored(SetExittlb) != 0)
                {
                    dm.readSql(SetExittlb);
                    OracleDataReader rd = dm.oraComm.ExecuteReader();
                    while (rd.Read())
                    {
                        if (!rd.IsDBNull(0)) { litpolno.Text = rd.GetInt32(0).ToString(); }
                        if (!rd.IsDBNull(1))
                        {
                            long clmno1 = long.Parse(rd.GetString(1));
                            txtclmno.Text = clmno1.ToString();
                            if (clmno1 > 0)
                            {
                                txtclmno.Enabled = false;
                            }
                            else
                            {
                                txtclmno.Enabled = true;
                            }
                        }
                        if (!rd.IsDBNull(2)) { txtcomdat.Text = rd.GetInt32(2).ToString(); }
                        if (!rd.IsDBNull(3)) { txttbl.Text = rd.GetInt32(3).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                        if (!rd.IsDBNull(4)) { txttrm.Text = rd.GetInt32(4).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                        if (!rd.IsDBNull(5)) { txtsumass.Text = rd.GetDouble(5).ToString("N0"); }
                        if (!rd.IsDBNull(6)) { txtmod.Text = rd.GetInt32(6).ToString(); Mode = rd.GetInt32(6); }
                        if (!rd.IsDBNull(7)) { BrCode = rd.GetInt32(7); }
                    }
                    reftable = "E";//exit
                    ViewState["Reftbl"] = reftable;
                    hdfbrn.Value = BrCode.ToString();
                    rd.Close();
                }
                #endregion
            }
            if ((dm.existRecored(SelDthout) == 0) && (dm.existRecored(SetExittlb) == 0))
            {
                string Selprem = "select PMPOL,PMCOM,PMTBL,PMTRM,PMSUM,PMMOD,PMBRN,PMDUE,PMCOD from lphs.premast where PMPOL=" + Polno + "";
                string SelLapse = "select LPPOL,LPCOM,LPTBL,LPTRM,LPSUM,LPMOD,LPBRN,LPDUE,LPCOD from lphs.liflaps where LPPOL=" + Polno + "";
                string Selmatutlb = "select LMPOL,LMCLM,LMCOM,LMTBL,LMTRM,LMSUM,LMMOD,LMBRN from lclm.lifmats where LMPOL=" + Polno + "";
                #region Check Premast Table
                if (dm.existRecored(Selprem) != 0)
                {
                    dm.readSql(Selprem);
                    OracleDataReader red1 = dm.oraComm.ExecuteReader();
                    while (red1.Read())
                    {
                        if (!red1.IsDBNull(0)) { litpolno.Text = red1.GetInt32(0).ToString(); }

                        if (!red1.IsDBNull(1)) { txtcomdat.Text = red1.GetInt32(1).ToString(); }
                        if (!red1.IsDBNull(2)) { txttbl.Text = red1.GetInt32(2).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                        if (!red1.IsDBNull(3)) { txttrm.Text = red1.GetInt32(3).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                        if (!red1.IsDBNull(4)) { txtsumass.Text = red1.GetDouble(4).ToString("N0"); }
                        if (!red1.IsDBNull(5)) { txtmod.Text = red1.GetInt32(5).ToString(); Mode = red1.GetInt32(5); }
                        if (!red1.IsDBNull(6)) { BrCode = red1.GetInt32(6); }
                        if (!red1.IsDBNull(7)) { /*txtnxteff.Text = red1.GetInt32(7).ToString();*/ }
                        if (!red1.IsDBNull(8))
                        {
                            PMCODE = red1.GetString(8);
                            if (PMCODE == "D")
                            {
                            }
                            else
                            {
                                Response.Redirect("dthInt010.aspx?dthout=true&pol=" + Polno + "");
                            }
                        }
                    }
                    reftable = "P";//premast
                    ViewState["Reftbl"] = reftable;
                    hdfbrn.Value = BrCode.ToString();
                    red1.Close();
                }
                #endregion

                #region Check Lapse
                else
                {
                    dm.readSql(SelLapse);
                    OracleDataReader red2 = dm.oraComm.ExecuteReader();
                    while (red2.Read())
                    {
                        if (!red2.IsDBNull(0)) { litpolno.Text = red2.GetInt32(0).ToString(); }

                        if (!red2.IsDBNull(1)) { txtcomdat.Text = red2.GetInt32(1).ToString(); }
                        if (!red2.IsDBNull(2)) { txttbl.Text = red2.GetInt32(2).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                        if (!red2.IsDBNull(3)) { txttrm.Text = red2.GetInt32(3).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                        if (!red2.IsDBNull(4)) { txtsumass.Text = red2.GetDouble(4).ToString("N0"); }
                        if (!red2.IsDBNull(5)) { txtmod.Text = red2.GetInt32(5).ToString(); Mode = red2.GetInt32(5); }
                        if (!red2.IsDBNull(6)) { BrCode = red2.GetInt32(6); }
                        if (!red2.IsDBNull(7)) { /*txtnxteff.Text = red2.GetInt32(7).ToString(); */ }
                        if (!red2.IsDBNull(8))
                        {
                            PMCODE = red2.GetString(8);
                            if (PMCODE == "D")
                            {
                            }
                            else
                            {
                                Response.Redirect("dthInt010.aspx?dthout=true&pol=" + Polno + "");
                            }
                        }
                    }
                    reftable = "L";//Lapse
                    ViewState["Reftbl"] = reftable;
                    hdfbrn.Value = BrCode.ToString();
                    red2.Close();
                }

                #endregion

                #region Check Maturity Table
                if (dm.existRecored(Selmatutlb) != 0)
                {
                    dm.readSql(Selmatutlb);
                    OracleDataReader red = dm.oraComm.ExecuteReader();
                    while (red.Read())
                    {
                        if (!red.IsDBNull(0)) { litpolno.Text = red.GetInt32(0).ToString(); }
                        if (!red.IsDBNull(1))
                        {
                            long clmno2 = long.Parse(red.GetString(1));
                            txtclmno.Text = clmno2.ToString();
                            if (clmno2 > 0)
                            {
                                txtclmno.Enabled = false;
                            }
                            else
                            {
                                txtclmno.Enabled = true;
                            }
                        }
                        if (!red.IsDBNull(2)) { txtcomdat.Text = red.GetInt32(2).ToString(); }
                        if (!red.IsDBNull(3)) { txttbl.Text = red.GetInt32(3).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                        if (!red.IsDBNull(4)) { txttrm.Text = red.GetInt32(4).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                        if (!red.IsDBNull(5)) { txtsumass.Text = red.GetDouble(5).ToString("N0"); }
                        if (!red.IsDBNull(6)) { txtmod.Text = red.GetInt32(6).ToString(); Mode = red.GetInt32(6); }
                        if (!red.IsDBNull(7)) { BrCode = red.GetInt32(7); }
                    }
                    reftable = "M";  //Maturity
                    ViewState["Reftbl"] = reftable;
                    hdfbrn.Value = BrCode.ToString();
                    red.Close();
                }
                #endregion
            }
            #endregion

            #region Get Branch NAme
            if (BrCode != 0)
            {
                DropDownList1.Text = dm.getBranchName(BrCode.ToString());
            }
            litpolno.Text = Polno.ToString();
            #endregion

            #region Get Name and Address
            string SelectPolDet = "select PNPOL,PNSTA,PNINT,PNSUR,PNAD1,PNAD2,PNAD3,PNAD4,PNPRO,PNIDN from lphs.phname where pnpol=" + Polno + "";
            if (dm.existRecored(SelectPolDet) != 0)
            {
                #region Get Data From PHNAME
                dm.readSql(SelectPolDet);
                OracleDataReader read = dm.oraComm.ExecuteReader();
                while (read.Read())
                {
                    if (!read.IsDBNull(1)) { txtst.Text = read.GetString(1); }
                    if (!read.IsDBNull(2)) { txtint.Text = read.GetString(2); }
                    if (!read.IsDBNull(3)) { txtsur.Text = read.GetString(3); }
                    if (!read.IsDBNull(4)) { txtadd1.Text = read.GetString(4); }
                    if (!read.IsDBNull(5)) { txtadd2.Text = read.GetString(5); }
                    if (!read.IsDBNull(6)) { txtadd3.Text = read.GetString(6); }
                    if (!read.IsDBNull(7)) { txtadd4.Text = read.GetString(7); }
                    if (!read.IsDBNull(8))
                    {
                        long Prop = read.GetInt64(8);
                        if (Prop > 0)
                        {
                            txtprop.Enabled = false;
                        }
                        else
                        {
                            txtprop.Enabled = true;
                        }
                        txtprop.Text = Prop.ToString();
                    }
                    if (!read.IsDBNull(9)) { txtid.Text = read.GetString(9); }
                }
                read.Close();
                #endregion
            }
            else
            {
                EPage.Messege = "Name and address not found.Please Go to Name & Address Change System and add Information ";
                Response.Redirect("EPage.aspx");
            }
            #endregion

            #region Get Policy Detials from lpolhis,exsurren,and Maturity tables
            string GetLpolData = "Select PHPRM,PHDUE,PHPAC,PHAGT,PHORG,PHTBL,PHTRM,PHCOM from lphs.lpolhis where PHPOL=" + int.Parse(litpolno.Text) + "";
            string GetExt = "select EXTPRM,EXTNXT,EXTPA,EXTAGT,EXTORG from lphs.exsurren where EXTPOL=" + Polno + "";
            if (dm.existRecored(GetLpolData) != 0)
            {
                #region Get Data From Lpolhis
                dm.readSql(GetLpolData);
                OracleDataReader red = dm.oraComm.ExecuteReader();
                while (red.Read())
                {
                    if (!red.IsDBNull(0)) { txtprm.Text = red.GetDouble(0).ToString(); }
                    if (!red.IsDBNull(1)) { /*txtnxteff.Text = red.GetInt32(1).ToString();*/ }
                    if (!red.IsDBNull(2)) { txtpacode.Text = red.GetInt32(2).ToString(); }
                    if (!red.IsDBNull(3)) { txtagtcd.Text = red.GetInt32(3).ToString(); }
                    if (!red.IsDBNull(4)) { txtorgcd.Text = red.GetInt32(4).ToString(); }
                    if (!red.IsDBNull(5)) { txttbl.Text = red.GetInt32(5).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                    if (!red.IsDBNull(6)) { txttrm.Text = red.GetInt32(6).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                    if (!red.IsDBNull(7)) { txtcomdat.Text = red.GetInt32(7).ToString(); }
                }
                red.Close();
                #endregion
            }
            else
            {
                if (dm.existRecored(GetExt) != 0)
                {
                    #region Get Data From Exit Table
                    dm.readSql(GetExt);
                    OracleDataReader rd = dm.oraComm.ExecuteReader();
                    while (rd.Read())
                    {
                        if (!rd.IsDBNull(0)) { txtprm.Text = rd.GetDouble(0).ToString(); }
                        if (!rd.IsDBNull(1)) { /*txtnxteff.Text = rd.GetInt32(1).ToString();*/ }
                        if (!rd.IsDBNull(2)) { txtpacode.Text = rd.GetInt32(2).ToString(); }
                        if (!rd.IsDBNull(3)) { txtagtcd.Text = rd.GetInt32(3).ToString(); }
                        if (!rd.IsDBNull(4)) { txtorgcd.Text = rd.GetInt32(4).ToString(); }
                    }
                    rd.Close();
                    #endregion
                }
            }
            if (dm.existRecored(GetExt) == 0)
            {
                #region Get Data From Maturity Table

                string Selmatutlb = "select LMPRM,LMDUE,LMPAC,LMAGT,LMORG from lclm.lifmats where LMPOL=" + Polno + "";
                if (dm.existRecored(Selmatutlb) != 0)
                {
                    dm.readSql(Selmatutlb);
                    OracleDataReader reader = dm.oraComm.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) { txtprm.Text = reader.GetDouble(0).ToString(); }
                        if (!reader.IsDBNull(1)) { /*txtnxteff.Text = reader.GetInt32(1).ToString();*/ }
                        if (!reader.IsDBNull(2)) { txtpacode.Text = reader.GetInt32(2).ToString(); }
                        if (!reader.IsDBNull(3)) { txtagtcd.Text = reader.GetInt32(3).ToString(); }
                        if (!reader.IsDBNull(4)) { txtorgcd.Text = reader.GetInt32(4).ToString(); }
                    }
                    reader.Close();
                }
                #endregion
            }
            #endregion

            #region Check whether loans available for the given policy number

            string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1  from lphs.lplmast where lmpol=" + Polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
            int caldate = int.Parse(this.setDate()[0]);
            dm.readSql(loansql);
            OracleDataReader myloanreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            int rows = 0;
            double loantotal = 0;
            double loaninttot = 0;

            while (myloanreader.Read())
            {
                double[] arr = new double[9];

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

                if (!myloanreader.IsDBNull(0)) { LoanNum = myloanreader.GetInt32(0); }
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
                if (!myloanreader.IsDBNull(15))
                {
                    lmset = myloanreader.GetString(15);
                }
                string lmcd1 = "";
                if (!myloanreader.IsDBNull(16))
                {
                    lmcd1 = myloanreader.GetString(16);
                }
                if (hdfdthdt.Value != null)
                {
                    DeathDate = int.Parse(hdfdthdt.Value);
                }
                if ((!lmset.Equals("Y")) && (!(lmcd1.Equals("D"))))
                {
                    this.Label1.Visible = true;
                    try
                    {
                        //arr = loanCalculation.calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, caldate);

                        //loantotal += arr[5];
                        //loaninttot += arr[8];

                        //loanCapital = arr[5];
                        //loaninterest = arr[8];
                        loanbackobj = new LoanBackCal(Polno, DeathDate, LoanNum);
                        loanCapital += loanbackobj.Loancap;
                        loaninterest += loanbackobj.Backinterest;
                        hdflncap.Value = loanCapital.ToString();
                        lnintrst.Value = loaninterest.ToString();
                        lngrndt.Value = lmcdt.ToString();
                    }
                    catch (Exception ex)
                    {
                        this.lblerr.Text = ex.Message.ToString();
                        loantotal = 0;
                        loaninttot = 0;
                    }

                    //------------- Back Calculation Algorithm Applied 20070802 ------------

                    //double temploanCapital = loanCapital;
                    //loanCapital = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, loanCapital, ((double)lmitr / 200), lmpdt, lmpit)[0];
                    //loaninterest = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, temploanCapital, ((double)lmitr / 200), lmpdt, lmpit)[1];
                    //temploanCapital = loanCapital - loaninterest;

                    rows++;
                    if (rows == 1)
                    {
                        this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", (rows - 1));
                        this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                    }
                    else
                    {
                        this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                    }
                }
            }
            myloanreader.Close();
            #endregion

            #region check Dthout_temp table
            string Select_epf = "select EPF,ENTDATE from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
            if (dm.existRecored(Select_epf) == 0)
            {
                btnsub.Text = "Submit";

                #region Check Whether Spouse Cover Found for the Given Policy
                string Selectcvr = "select PRPERTYPE,DOB,SURNAME,FULLNAME from lund.polpersonal where PRPERTYPE=2 and POLNO=" + int.Parse(litpolno.Text) + "";
                string ChkCvr_SP = "select RCOVR from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=101";
                if (dm.existRecored(Selectcvr) != 0)
                {
                    dm.readSql(Selectcvr);
                    OracleDataReader reder1 = dm.oraComm.ExecuteReader();
                    while (reder1.Read())
                    {
                        if (!reder1.IsDBNull(0)) { Prtype = reder1.GetInt32(0); } else { Prtype = 1; }
                        if (!reder1.IsDBNull(1)) { DOB = reder1.GetInt32(1); } else { DOB = 0; }
                        if (!reder1.IsDBNull(2)) { Surname = reder1.GetString(2); } else { Surname = ""; }
                        if (!reder1.IsDBNull(3)) { Fullname = reder1.GetString(3); } else { Fullname = ""; }
                    }
                    reder1.Close();
                    if ((Fullname != null && Fullname != "") || (Surname != null && Surname != ""))
                    {
                        if (Fullname.Length > Surname.Length)
                        {
                            string OtherName = Fullname.Remove((Fullname.Length - Surname.Length), Surname.Length);
                            txtothNames.Text = OtherName;
                            txtsurname.Text = Surname;
                        }
                        else
                        {
                            txtothNames.Text = Fullname + " " + Surname;
                        }
                    }
                    txtdob.Text = DOB.ToString();
                    pnl_spusedtl.Visible = true;
                    ddlSP_CVR.SelectedIndex = 1;
                }
                else if (dm.existRecored(ChkCvr_SP) != 0)
                {
                    pnl_spusedtl.Visible = true;
                    ddlSP_CVR.SelectedIndex = 1;
                }
                else
                {
                    pnl_spusedtl.Visible = false;
                    ddlSP_CVR.SelectedIndex = 2;
                }
                #endregion

                #region Check MINIMUTHI Policies
                if (Tble == 34 || Tble == 38 || Tble == 39 || Tble == 46 || Tble == 49)
                {
                    string Selectcvr1 = "select PRPERTYPE,DOB,SURNAME,FULLNAME from lund.polpersonal where PRPERTYPE=4 and POLNO=" + int.Parse(litpolno.Text) + "";
                    string ChkCvrSEC = "select RCOVR from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=201";
                    if (dm.existRecored(Selectcvr1) != 0)
                    {
                        dm.readSql(Selectcvr1);
                        OracleDataReader reder2 = dm.oraComm.ExecuteReader();
                        while (reder2.Read())
                        {
                            if (!reder2.IsDBNull(0)) { ch_prtype = reder2.GetInt32(0); } else { ch_prtype = 1; }
                            if (!reder2.IsDBNull(1)) { child_dob = reder2.GetInt32(1); } else { child_dob = 0; }
                            if (!reder2.IsDBNull(2)) { childSurna = reder2.GetString(2).Trim(); } else { childSurna = ""; }
                            if (!reder2.IsDBNull(3)) { childfullname = reder2.GetString(3).Trim(); } else { childfullname = ""; }
                        }
                        reder2.Close();
                        if ((childfullname != null && childfullname != "") || (childSurna != null && childSurna != ""))
                        {
                            if (childfullname.Length > childSurna.Length)
                            {
                                string OtherName = childfullname.Remove((childfullname.Length - childSurna.Length), childSurna.Length);
                                child1othrname.Text = OtherName;
                                child1surname.Text = childSurna;
                            }
                            else 
                            {
                                child1othrname.Text = childfullname + " " + childSurna;
                            }
                        }
                        child1dob.Text = child_dob.ToString();
                        pnl_chld.Visible = true;
                    }
                    else if (dm.existRecored(ChkCvrSEC) != 0)
                    {
                        pnl_chld.Visible = true;
                    }
                    pnl_chld.Visible = true;
                }
                else
                {
                    pnl_chld.Visible = false;
                }
                #endregion
            }
            else
            {
                #region Check Whether Spouse Cover Found for the Given Policy
                string Selectcvr = "select PRPERTYPE,DOB,SURNAME,FULLNAME from lund.polpersonal where PRPERTYPE=2 and POLNO=" + int.Parse(litpolno.Text) + "";
                string ChkCvr_SP = "select RCOVR from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=101";
                if (dm.existRecored(Selectcvr) != 0)
                {
                    dm.readSql(Selectcvr);
                    OracleDataReader reder1 = dm.oraComm.ExecuteReader();
                    while (reder1.Read())
                    {
                        if (!reder1.IsDBNull(0)) { Prtype = reder1.GetInt32(0); } else { Prtype = 1; }
                        if (!reder1.IsDBNull(1)) { DOB = reder1.GetInt32(1); } else { DOB = 0; }
                        if (!reder1.IsDBNull(2)) { Surname = reder1.GetString(2); } else { Surname = ""; }
                        if (!reder1.IsDBNull(3)) { Fullname = reder1.GetString(3); } else { Fullname = ""; }
                    }
                    reder1.Close();
                    if ((Fullname != null && Fullname != "") || (Surname != null && Surname != ""))
                    {
                        if (Fullname.Length > Surname.Length)
                        {
                            string OtherName = Fullname.Remove((Fullname.Length - Surname.Length), Surname.Length);
                            txtothNames.Text = OtherName;
                            txtsurname.Text = Surname;
                        }
                        else
                        {
                            txtothNames.Text = Fullname + " " + Surname;
                        }
                    }
                    txtdob.Text = DOB.ToString();
                    pnl_spusedtl.Visible = true;
                    ddlSP_CVR.SelectedIndex = 1;
                }
                else if (dm.existRecored(ChkCvr_SP) != 0)
                {
                    pnl_spusedtl.Visible = true;
                    ddlSP_CVR.SelectedIndex = 1;
                }
                else
                {
                    pnl_spusedtl.Visible = false;
                    ddlSP_CVR.SelectedIndex = 2;
                }
                #endregion

                #region Check MINIMUTHI Policies
                if (Tble == 34 || Tble == 38 || Tble == 39 || Tble == 46 || Tble == 49)
                {
                    string Selectcvr1 = "select PRPERTYPE,DOB,SURNAME,FULLNAME from lund.polpersonal where PRPERTYPE=4 and POLNO=" + int.Parse(litpolno.Text) + "";
                    string ChkCvrSEC = "select RCOVR from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=201";
                    if (dm.existRecored(Selectcvr1) != 0)
                    {
                        dm.readSql(Selectcvr1);
                        OracleDataReader reder2 = dm.oraComm.ExecuteReader();
                        while (reder2.Read())
                        {
                            if (!reder2.IsDBNull(0)) { ch_prtype = reder2.GetInt32(0); } else { ch_prtype = 1; }
                            if (!reder2.IsDBNull(1)) { child_dob = reder2.GetInt32(1); } else { child_dob = 0; }
                            if (!reder2.IsDBNull(2)) { childSurna = reder2.GetString(2).Trim(); } else { childSurna = ""; }
                            if (!reder2.IsDBNull(3)) { childfullname = reder2.GetString(3).Trim(); } else { childfullname = ""; }
                        }
                        reder2.Close();
                        if ((childfullname != null && childfullname != "") || (childSurna != null && childSurna != ""))
                        {
                            if (childfullname.Length > childSurna.Length)
                            {
                                string OtherName = childfullname.Remove((childfullname.Length - childSurna.Length), childSurna.Length);
                                child1othrname.Text = OtherName;
                                child1surname.Text = childSurna;
                            }
                            else
                            {
                                child1othrname.Text = childfullname + " " + childSurna;
                            }
                        }
                        child1dob.Text = child_dob.ToString();
                        pnl_chld.Visible = true;
                    }
                    else if (dm.existRecored(ChkCvrSEC) != 0)
                    {
                        pnl_chld.Visible = true;
                    }
                    pnl_chld.Visible = true;
                }
                else
                {
                    pnl_chld.Visible = false;
                }
                #endregion

                #region If only entering death claim
                if (ISAuthOrize == "false")
                {
                    btnsub.Text = "Update";
                    string Epf = "";
                    int Date = 0;
                    dm.readSql(Select_epf);
                    OracleDataReader rd = dm.oraComm.ExecuteReader();
                    while (rd.Read())
                    {
                        if (!rd.IsDBNull(0)) { Epf = rd.GetString(0); }
                        if (!rd.IsDBNull(1)) { Date = rd.GetInt32(1); }
                    }
                    rd.Dispose();
                    if (Epf != entEPF)
                    {
                        lblerr.Text = "This Policy had Updated by " + Epf + " on " + Date.ToString() + "";
                        btnsub.Enabled = false;
                    }
                    else
                    {
                        lblerr.Text = " ";
                        btnsub.Enabled = true;
                    }
                    ddllife.Enabled = true; ddlmethod.Enabled = true;
                    ddlpolst.Enabled = true; ddlcvofr.Enabled = true;
                }
                #endregion

                #region Authorizing Claim Entry
                if (ISAuthOrize == "true")
                {
                    #region Readonly text Boxes

                    btnsub.Text = "Authorize";
                    txtcomdat.ReadOnly = true;
                    txttbl.ReadOnly = true;
                    txttrm.ReadOnly = true;
                    txtsumass.ReadOnly = true;
                    txtmod.ReadOnly = true;
                    txtprm.ReadOnly = true;
                    txtnxteff.ReadOnly = true;
                    txtpacode.ReadOnly = true;
                    txtagtcd.ReadOnly = true;
                    txtorgcd.ReadOnly = true;
                    txtgrsclm.ReadOnly = true;
                    txtnetclm.ReadOnly = true;
                    txtinfdate.ReadOnly = true;
                    txtnetclm.ReadOnly = true;
                    txtinfdate.ReadOnly = true;
                    txtothNames.ReadOnly = true;
                    txtsurname.ReadOnly = true;
                    txtdob.ReadOnly = true;
                    child1othrname.ReadOnly = true;
                    child1surname.ReadOnly = true;
                    txtinfID.ReadOnly = true;
                    txtinftel.ReadOnly = true;
                    txtinfname.ReadOnly = true;
                    txtinfadd1.ReadOnly = true;
                    txtinfadd2.ReadOnly = true;
                    txtinfadd3.ReadOnly = true;
                    txtinfadd4.ReadOnly = true;
                    txtinfrel.ReadOnly = true;
                    txtbonsurryr.ReadOnly = true;
                    #endregion
                }
                #endregion

                #region Get Already inserted Data from dthout_temp table

                string GetTempData = "select POLNO,CLMNO,PROPNO,STA,INTIAL,SUR,AD1,AD2,AD3,AD4," +
                                   "IDN,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,MOS,INFODAT," +
                                   "POLST,DTOFDTH,MOINF,IID,INAME,IAD1,IAD2,IAD3,IAD4,ITEL,INFOREL,PRM,DUE," +
                                   "PAC,AGT,ORG,CLAIMST,SP_FULLNAME,SP_DOB,CHLD_FULLNAME,CHLD_DOB,SP_SURNAME," +
                                   "CHLD_SURNAME,LOANCAP,LOANINTST,BACKINTST,LOANNUM,LNGRANTDT,BONSURRYN,BONSURRYR," +
                                   "VESTEDBON,INTERIMBON,POLICYCATGRY from lphs.dthout_temp where POLNO=" + Polno + "";
                dm.readSql(GetTempData);
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) { litpolno.Text = reader.GetInt32(0).ToString(); }
                    if (!reader.IsDBNull(1)) { txtclmno.Text = reader.GetInt32(1).ToString(); }
                    if (!reader.IsDBNull(2)) { txtprop.Text = reader.GetInt32(2).ToString(); }
                    if (!reader.IsDBNull(3)) { txtst.Text = reader.GetString(3); }
                    if (!reader.IsDBNull(4)) { txtint.Text = reader.GetString(4); }
                    if (!reader.IsDBNull(5)) { txtsur.Text = reader.GetString(5); }
                    if (!reader.IsDBNull(6)) { txtadd1.Text = reader.GetString(6); }
                    if (!reader.IsDBNull(7)) { txtadd2.Text = reader.GetString(7); }
                    if (!reader.IsDBNull(8)) { txtadd3.Text = reader.GetString(8); }
                    if (!reader.IsDBNull(9)) { txtadd4.Text = reader.GetString(9); }
                    if (!reader.IsDBNull(10)) { txtid.Text = reader.GetString(10); }
                    if (!reader.IsDBNull(11)) { txtcomdat.Text = reader.GetInt32(11).ToString(); }
                    if (!reader.IsDBNull(12)) { txttbl.Text = reader.GetInt32(12).ToString(); Tble = int.Parse(txttbl.Text.Trim()); }
                    if (!reader.IsDBNull(13)) { txttrm.Text = reader.GetInt32(13).ToString(); Term = int.Parse(txttrm.Text.Trim()); }
                    if (!reader.IsDBNull(14)) { txtsumass.Text = reader.GetDouble(14).ToString(); }
                    if (!reader.IsDBNull(15)) { txtmod.Text = reader.GetString(15); Mode = int.Parse(txtmod.Text); }
                    if (!reader.IsDBNull(16)) { txtgrsclm.Text = reader.GetDouble(16).ToString(); }
                    if (!reader.IsDBNull(17)) { txtnetclm.Text = reader.GetDouble(17).ToString(); }
                    if (!reader.IsDBNull(18))
                    {
                        BrCode = reader.GetInt32(18);
                        if (BrCode != 0)
                        {
                            DropDownList1.Text = dm.getBranchName(BrCode.ToString());
                        }
                    }
                    if (!reader.IsDBNull(19))
                    {
                        mos = reader.GetString(19);
                        if (mos == "M") { ddllife.SelectedIndex = 1; }
                        if (mos == "S") { ddllife.SelectedIndex = 2; }
                        if (mos == "2") { ddllife.SelectedIndex = 3; }
                        if (mos == "C") { ddllife.SelectedIndex = 4; }
                    }
                    if (!reader.IsDBNull(20)) { txtinfdate.Text = reader.GetInt32(20).ToString(); }

                    if (!reader.IsDBNull(21))
                    {
                        polstat = reader.GetString(21);

                        if (polstat == "I")
                        { ddlpolst.SelectedIndex = 1; }
                        else { ddlpolst.SelectedIndex = 2; }
                    }
                    if (!reader.IsDBNull(22))
                    {
                        DeathDate = reader.GetInt32(22);
                    }
                    if (!reader.IsDBNull(23))
                    {
                        string Method_Inf = reader.GetString(23);
                        if (Method_Inf == "COUN") { ddlmethod.SelectedIndex = 1; }
                        if (Method_Inf == "MAIL") { ddlmethod.SelectedIndex = 2; }
                        if (Method_Inf == "CALL") { ddlmethod.SelectedIndex = 3; }
                    }
                    if (!reader.IsDBNull(24)) { txtinfID.Text = reader.GetString(24); }
                    if (!reader.IsDBNull(25)) { txtinfname.Text = reader.GetString(25); }
                    if (!reader.IsDBNull(26)) { txtinfadd1.Text = reader.GetString(26); }
                    if (!reader.IsDBNull(27)) { txtinfadd2.Text = reader.GetString(27); }
                    if (!reader.IsDBNull(28)) { txtinfadd3.Text = reader.GetString(28); }
                    if (!reader.IsDBNull(29)) { txtinfadd4.Text = reader.GetString(29); }
                    if (!reader.IsDBNull(30)) { txtinftel.Text = reader.GetString(30); }
                    if (!reader.IsDBNull(31)) { txtinfrel.Text = reader.GetString(31); }
                    if (!reader.IsDBNull(32)) { txtprm.Text = reader.GetDouble(32).ToString(); }
                    if (!reader.IsDBNull(33)) { txtnxteff.Text = reader.GetInt32(33).ToString(); }
                    if (!reader.IsDBNull(34)) { txtpacode.Text = reader.GetInt32(34).ToString(); }
                    if (!reader.IsDBNull(35)) { txtagtcd.Text = reader.GetInt32(35).ToString(); }
                    if (!reader.IsDBNull(36)) { txtorgcd.Text = reader.GetInt32(36).ToString(); }
                    if (!reader.IsDBNull(37))
                    {
                        int indx = reader.GetInt32(37);
                        if (indx == 0)
                        {
                            ddlyn.SelectedIndex = 0;
                        }
                        if (indx == 1)
                        {
                            ddlyn.SelectedIndex = 1;
                        }
                        if (indx == 2)
                        {
                            ddlyn.SelectedIndex = 2;
                        }
                    }
                    if (!reader.IsDBNull(38)) { Fullname = reader.GetString(38); } else { Fullname = ""; }
                    if (!reader.IsDBNull(39)) { DOB = reader.GetInt32(39); } else { DOB = 0; }
                    if (!reader.IsDBNull(40)) { childfullname = reader.GetString(40); } else { childfullname = ""; }
                    if (!reader.IsDBNull(41)) { child_dob = reader.GetInt32(41); } else { child_dob = 0; }
                    if (!reader.IsDBNull(42)) { Surname = reader.GetString(42); } else { Surname = ""; }
                    if (!reader.IsDBNull(43)) { childSurna = reader.GetString(43); } else { childSurna = ""; }
                    if (!reader.IsDBNull(44)) { loanCapital = reader.GetDouble(44); } else { loanCapital = 0.0; }
                    if (!reader.IsDBNull(45)) { loanint_rate = reader.GetDouble(45); } else { loanint_rate = 0.0; }
                    if (!reader.IsDBNull(46)) { loaninterest = reader.GetDouble(46); } else { loaninterest = 0.0; }
                    if (!reader.IsDBNull(47)) { LoanNum = reader.GetInt32(47); } else { LoanNum = 0; }
                    if (!reader.IsDBNull(48)) { lnGrntDate = reader.GetInt32(48).ToString(); } else { lnGrntDate = ""; }
                    if (!reader.IsDBNull(49)) { bonsuryn = reader.GetString(49); } else { bonsuryn = "N"; }
                    if (!reader.IsDBNull(50)) { bonSurrYr = reader.GetInt32(50); } else { bonSurrYr = 0; }
                    if (!reader.IsDBNull(51)) { vestedBonus = reader.GetDouble(51); } else { vestedBonus = 0.0; }
                    if (!reader.IsDBNull(52)) { interimbonus = reader.GetDouble(52); } else { interimbonus = 0.0; }

                    if (Fullname != "")
                    {
                        string Oth_Name = Fullname.Remove((Fullname.Length - Surname.Length), Surname.Length);
                        txtothNames.Text = Oth_Name;
                        txtsur.Text = Surname;
                    }
                    if (DOB != 0)
                    {
                        txtdob.Text = DOB.ToString();
                    }
                    if (childfullname != "")
                    {
                        string ch_Oth_Name = childfullname.Remove((childfullname.Length - childSurna.Length), childSurna.Length);
                        child1othrname.Text = ch_Oth_Name;
                        child1surname.Text = childSurna;
                    }
                    if (child_dob != 0)
                    {
                        child1dob.Text = child_dob.ToString();
                    }
                    if (bonsuryn.Trim() == "Y")
                    {
                        ddlbonsurrYN.SelectedIndex = 1;
                    }
                    else
                    {
                        ddlbonsurrYN.SelectedIndex = 0;
                    }
                    txtbonsurryr.Text = bonSurrYr.ToString();
                    if (!reader.IsDBNull(53)) { civilorforces = reader.GetString(53); } else { civilorforces = ""; }
                    if (civilorforces != "")
                    {
                        if (civilorforces.Trim() == "C") { ddlcvofr.SelectedIndex = 1; }
                        if (civilorforces.Trim() == "A") { ddlcvofr.SelectedIndex = 2; }
                        if (civilorforces.Trim() == "N") { ddlcvofr.SelectedIndex = 3; }
                        if (civilorforces.Trim() == "G") { ddlcvofr.SelectedIndex = 4; }
                        if (civilorforces.Trim() == "P") { ddlcvofr.SelectedIndex = 5; }
                        if (civilorforces.Trim() == "B") { ddlcvofr.SelectedIndex = 6; }
                    }

                }
                #endregion
            }
            #endregion

            if (ISAuthOrize == "true")
            {
                #region Display Check Boxes

                CkBx1.Visible = true;  //CkBx2.Visible = true;
                //CkBx3.Visible = true; CkBx4.Visible = true;
                CkBx5.Visible = true; CkBx6.Visible = true;
                CkBx7.Visible = true; CkBx8.Visible = true;

                CkBx9.Visible = true; CkBx10.Visible = true;
                CkBx11.Visible = true;
                //CkBx12.Visible = true;
                //CkBx13.Visible = true;
                CkBx14.Visible = true; CkBx15.Visible = true;
                //CkBx16.Visible = true;
                ChBx18.Visible = true;
                CkBx19.Visible = true; CkBx20.Visible = true;
                ddllife.Enabled = false; ddlmethod.Enabled = false;
                ddlpolst.Enabled = false; ddlcvofr.Enabled = false;
                string GetDthint1 = "select * from lphs.dthint where DPOLNO=" + int.Parse(litpolno.Text) + "";
                string GetLPOLHIS1 = "select * from lphs.LPOLHIS where PHPOL=" + int.Parse(litpolno.Text) + "";

                if ((dm.existRecored(GetDthint1) != 0) && (dm.existRecored(GetLPOLHIS1) != 0))
                {
                    CkBx1.Checked = true;
                    CkBx5.Checked = true; CkBx6.Checked = true;
                    CkBx7.Checked = true; CkBx8.Checked = true;

                    CkBx9.Checked = true; CkBx10.Checked = true;
                    CkBx11.Checked = true;
                    //CkBx12.Visible = true;
                    //CkBx13.Visible = true;
                    CkBx14.Checked = true; CkBx15.Checked = true;
                    //CkBx16.Visible = true;
                    ChBx18.Checked = true;
                    CkBx19.Checked = true; CkBx20.Checked = true;

                }
                #endregion

                #region Display Bonus Amount

                if (ddlpolst.SelectedIndex == 1)
                { polstat = "I"; }
                else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }
                else { polstat = ""; lblerr.Text = "Please Select the Policy Status"; }
                if (ddlbonsurrYN.SelectedIndex == 0)
                {
                    bonsuryn = "N";
                }
                else if (ddlbonsurrYN.SelectedIndex == 1)
                {
                    bonsuryn = "Y";
                }
                int lastpaymentY = 0;
                CommDate = int.Parse(txtcomdat.Text.Trim());
                DeathDate = int.Parse(hdfdthdt.Value);
                if (txtnxteff.Text.Trim() != "")
                {
                    Nexteffdt = int.Parse(txtnxteff.Text.Trim());
                }
                SumAss = double.Parse(txtsumass.Text.Trim());

                DateTime deathyrmn = DateTime.Parse(DeathDate.ToString().Substring(0, 4) + "/" + DeathDate.ToString().Substring(4, 2) + "/" + DeathDate.ToString().Substring(6, 2));
                DateTime nexteffectivedate = DateTime.Parse(Nexteffdt.ToString().Substring(0, 4) + "/" + Nexteffdt.ToString().Substring(4, 2) + "/" + CommDate.ToString().Substring(6, 2));
                TimeSpan diffmn = deathyrmn.Subtract(nexteffectivedate);
                int mn = diffmn.Days / 30;
                if (mn >= 6)
                {
                    polstat = "L";
                }
                else
                {
                    polstat = "I";
                }
                if (polstat.Equals("I"))
                {
                    polDuraYrs = this.dateComparison(CommDate, DeathDate)[0];
                    polDuraMnths = this.dateComparison(CommDate, DeathDate)[1];
                    polDuraDays = this.dateComparison(CommDate, DeathDate)[2];
                    if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }
                }
                else if (polstat.Equals(""))
                { }
                else
                {
                    //---------- include code to read the ledger table to get the last paymnet date
                    int lpasedate = 0;
                    string GetLpseDate = "select max(lldue) from lclm.ledger where llpol=" + Polno + "";
                    if (dm.existRecored(GetLpseDate) != 0)
                    {
                        dm.readSql(GetLpseDate);
                        OracleDataReader dr = dm.oraComm.ExecuteReader();
                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0)) { lpasedate = dr.GetInt32(0); } else { lpasedate = 0; }
                        }
                        dr.Close();
                    }
                    int dueYMD = int.Parse(Nexteffdt.ToString() + CommDate.ToString().Substring(6, 2));
                    if (lpasedate != 0)
                    {
                        lpasedate = int.Parse(lpasedate.ToString() + CommDate.ToString().Substring(6, 2));
                    }
                    else
                    {
                        lpasedate = dueYMD;
                    }
                    if (lpasedate < dueYMD)
                    {
                        polDuraYrs = this.dateComparison(CommDate, lpasedate)[0];
                        polDuraMnths = this.dateComparison(CommDate, lpasedate)[1];
                        polDuraDays = this.dateComparison(CommDate, lpasedate)[2];
                        if (Mode == 4)
                        {
                            polDuraMnths = polDuraMnths + 1;
                        }
                        else if (Mode == 3)
                        {
                            polDuraMnths = polDuraMnths + 3;
                        }
                        else if (Mode == 2)
                        {
                            polDuraMnths = polDuraMnths + 6;
                        }
                        else if (Mode == 1)
                        {
                            polDuraMnths = polDuraMnths + 12;
                        }
                        if (polDuraMnths >= 12)
                        {
                            polDuraYrs = polDuraYrs + 1;
                            polDuraMnths = polDuraMnths - 12;
                        }
                    }
                    else
                    {
                        polDuraYrs = this.dateComparison(CommDate, dueYMD)[0];
                        polDuraMnths = this.dateComparison(CommDate, dueYMD)[1];
                        polDuraDays = this.dateComparison(CommDate, dueYMD)[2];
                        polDuraMnths = polDuraMnths + 1;
                        if (polDuraMnths >= 12)
                        {
                            polDuraYrs = polDuraYrs + 1;
                            polDuraMnths = polDuraMnths - 12;
                        }
                    }

                    if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }
                    lastpaymentY = int.Parse(CommDate.ToString().Substring(0, 4)) + polDuraYrs - 1;
                    //-------- Check demands if Exists calculate total paid years -----
                    int dem_count = 0;
                    string checkdemands = "select count(pddue) from lphs.demand where PDPOL=" + Polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue<" + Nexteffdt + "";
                    if (dm.existRecored(checkdemands) != 0)
                    {
                        dm.readSql(checkdemands);
                        OracleDataReader dr1 = dm.oraComm.ExecuteReader();
                        while (dr1.Read())
                        {
                            if (!dr1.IsDBNull(0)) { dem_count = dr1.GetInt32(0); } else { dem_count = 0; }
                        }
                        dr1.Close();
                    }
                    if (Mode == 1) { dem_count = 12 * dem_count; }
                    else if (Mode == 2) { dem_count = 6 * dem_count; }
                    else if (Mode == 3) { dem_count = 3 * dem_count; }
                    else if (Mode == 4) { dem_count = dem_count; }

                    if (dem_count < polDuraMnths)
                    {
                        dem_count = polDuraMnths - dem_count;
                    }
                    else if (dem_count > polDuraMnths)
                    {
                        polDuraMnths = polDuraMnths + 12;
                        polDuraYrs = polDuraYrs - 1;
                        polDuraMnths = polDuraMnths - dem_count;
                    }
                }

                double totbonus = 0;
                int interimboncount = 0;
                int yeardiff = 0;
                int monthdiff = 0;

                int DCOym = int.Parse(Convert.ToString(CommDate).Substring(0, 4));
                if (polstat.Equals("I"))
                {
                    yeardiff = int.Parse(hdfdthdt.Value.Substring(0, 4)) - int.Parse(Convert.ToString(CommDate).Substring(0, 4));
                }
                else if (polstat.Equals("L"))
                {
                    int multiplier = 0;
                    if (Mode == 1) { multiplier = 12; }
                    else if (Mode == 2) { multiplier = 6; }
                    else if (Mode == 3) { multiplier = 3; }
                    else if (Mode == 4) { multiplier = 1; }


                }
                else { }
                bool flag = false;

                //----- excluding bonus not declared years ----

                //bonuscount = lastpaymentY - int.Parse(dateofComm.ToString().Substring(0, 4));

                if (polstat.Equals("I"))
                {
                    bonuscount = yeardiff;
                }
                else
                {
                    bonuscount = polDuraYrs;
                }
                if (polstat.Equals("L"))
                {
                    if (lastpaymentY == 1963 || lastpaymentY == 1967 || lastpaymentY == 1972 || lastpaymentY == 1974 || lastpaymentY == 1976 || lastpaymentY == 1981 || lastpaymentY == 1984 || lastpaymentY == 1986 || lastpaymentY == 1989 || lastpaymentY == 1991 || lastpaymentY == 1996)
                    {
                        if (int.Parse(Nexteffdt.ToString().Substring(0, 4)) < (int.Parse(CommDate.ToString().Substring(0, 4)) + polDuraYrs)) { bonuscount--; }
                    }
                    else if (lastpaymentY == 1964 || lastpaymentY == 1968 || lastpaymentY == 1977 || lastpaymentY == 1982 || lastpaymentY == 1987) { bonuscount -= 2; }
                    else if (lastpaymentY == 1965 || lastpaymentY == 1969 || lastpaymentY == 1978) { bonuscount -= 3; }
                    else if (lastpaymentY == 1970 || lastpaymentY == 1979) { bonuscount -= 4; }
                }

                string incrementcountstr = "";
                string incrementcountstrdclr = "";
                int i;
                double temp = 0;
                if (bonuscount > 0)
                {
                    #region Get Bonus field names
                    for (i = 1; i < (bonuscount + 1); i++)
                    {
                        if (i < 10)
                        {
                            incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                        }
                        else
                        {
                            incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                        }
                    }
                    incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));
                    #endregion

                    #region Get Bonus from Bonus Table
                    string bonsql = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + Tble + " ";
                    if (dm.existRecored(bonsql) != 0)
                    {
                        dm.readSql(bonsql);
                        OracleDataReader bonfilereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        CountbonYr = int.Parse(CommDate.ToString().Substring(0, 4));
                        string bonry = "";
                        while (bonfilereader.Read())
                        {
                            flag = true;

                            for (int j = 0; j < bonuscount; j++)
                            {
                                double annualbonus = 0;
                                if (!bonfilereader.IsDBNull(j)) { annualbonus = bonfilereader.GetDouble(j); }
                                if (j < 9)
                                {
                                    bonry = "BONY" + "0" + Convert.ToString(j + 1);
                                }
                                else
                                {
                                    bonry = "BONY" + Convert.ToString(j + 1);
                                }
                                int bonyrget = 0;
                                string Getbon = "select " + bonry + " from lphs.lplbons where bonyea = " + int.Parse(CommDate.ToString().Substring(0, 4)) + " and bontab=" + Tble + "";
                                if (dm.existRecored(Getbon) != 0)
                                {
                                    dm.readSql(Getbon);
                                    OracleDataReader dr2 = dm.oraComm.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        if (!dr2.IsDBNull(0)) { bonyrget = dr2.GetInt32(0); } else { bonyrget = 0; }
                                    }
                                    dr2.Close();
                                }
                                if (j == bonuscount - 1)
                                {
                                    if (CountbonYr == bonyrget)
                                    {
                                        totbonus = totbonus + annualbonus;
                                        interimBonStYR = CountbonYr;
                                    }
                                }
                                else
                                {
                                    totbonus = totbonus + annualbonus;
                                }
                                if (annualbonus == 0.0)
                                {
                                    if (bonyrget == 0 && annualbonus == 0.0)
                                    {
                                        int term = 0;
                                        int lastTerm = 0;
                                        string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                                        if (dm.existRecored(Getinterimbonamtandyr) != 0)
                                        {
                                            dm.readSql(Getinterimbonamtandyr);
                                            OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                                            while (drintbon.Read())
                                            {
                                                if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                                if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                                {
                                                    if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                    if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                }
                                                else if (bonuscount > term)
                                                {
                                                    if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                    if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                }
                                                lastTerm = term;
                                            }
                                            drintbon.Close();
                                        }
                                        else
                                        {
                                        }
                                    }
                                    interimboncount++;
                                    temp = intBonValfrmtble;
                                    break;
                                }
                                else { temp = annualbonus; }
                                CountbonYr = CountbonYr + 1;
                            }
                        }
                        bonfilereader.Close();
                        if (!flag)
                        { totbonus = 0; }
                    }
                    #endregion

                    #region If no value in bonus table
                    else
                    {
                        int term = 0;
                        int lastTerm = 0;
                        string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                        if (dm.existRecored(Getinterimbonamtandyr) != 0)
                        {
                            dm.readSql(Getinterimbonamtandyr);
                            OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                            while (drintbon.Read())
                            {
                                if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                {
                                    if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                    if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                }
                                else if (bonuscount > term)
                                {
                                    if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                    if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                }
                                lastTerm = term;
                            }
                            drintbon.Close();
                        }
                        interimboncount++;
                        temp = intBonValfrmtble;
                    }
                    if (dm.existRecored(bonsql) == 0)
                    {
                        if (intBonValfrmtble == 0.0)
                        {
                            string Getmxbonyr = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + (DCOym - 1) + " and lplbons.bontab=" + Tble + "";
                            if (dm.existRecored(Getmxbonyr) != 0)
                            {
                                #region Get Last Declared Bonus
                                dm.readSql(Getmxbonyr);
                                OracleDataReader bonfilereader1 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                CountbonYr = int.Parse(CommDate.ToString().Substring(0, 4));
                                string bonry1 = "";
                                while (bonfilereader1.Read())
                                {
                                    flag = true;

                                    for (int j = 0; j < bonuscount; j++)
                                    {
                                        double annualbonus = 0;
                                        if (!bonfilereader1.IsDBNull(j)) { annualbonus = bonfilereader1.GetDouble(j); }
                                        if (j < 9)
                                        {
                                            bonry1 = "BONY" + "0" + Convert.ToString(j + 1);
                                        }
                                        else
                                        {
                                            bonry1 = "BONY" + Convert.ToString(j + 1);
                                        }
                                        int bonyrget = 0;
                                        string Getbon = "select " + bonry1 + " from lphs.lplbons where bonyea = " + (DCOym - 1) + " and bontab=" + Tble + "";
                                        if (dm.existRecored(Getbon) != 0)
                                        {
                                            dm.readSql(Getbon);
                                            OracleDataReader dr2 = dm.oraComm.ExecuteReader();
                                            while (dr2.Read())
                                            {
                                                if (!dr2.IsDBNull(0)) { bonyrget = dr2.GetInt32(0); } else { bonyrget = 0; }
                                            }
                                            dr2.Close();
                                        }
                                        if (j == bonuscount - 1)
                                        {
                                            if ((CountbonYr) == bonyrget)
                                            {
                                                totbonus = totbonus + annualbonus;
                                                interimBonStYR = CountbonYr;
                                            }
                                        }
                                        else
                                        {
                                            totbonus = totbonus + annualbonus;
                                        }
                                        if (annualbonus == 0)
                                        {
                                            if (bonyrget == 0 && annualbonus == 0.0)
                                            {
                                                int term = 0;
                                                int lastTerm = 0;
                                                string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                                                if (dm.existRecored(Getinterimbonamtandyr) != 0)
                                                {
                                                    dm.readSql(Getinterimbonamtandyr);
                                                    OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                                                    while (drintbon.Read())
                                                    {
                                                        if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                                        if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                                        {
                                                            if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                            if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                        }
                                                        else if (bonuscount > term)
                                                        {
                                                            if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                            if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                        }
                                                        lastTerm = term;
                                                    }
                                                    drintbon.Close();
                                                }
                                                else
                                                {
                                                }
                                            }
                                            interimboncount++;
                                            temp = intBonValfrmtble;
                                            break;
                                        }
                                        else { temp = annualbonus; interimboncount++; interimBonStYR = CountbonYr - 1; }
                                        CountbonYr = CountbonYr + 1;
                                    }
                                }
                                bonfilereader1.Close();
                                //bonfilereader.Dispose();
                                if (!flag)
                                { totbonus = 0; }
                                #endregion
                            }
                            else
                            {
                                #region Get Last Declared Bonus

                                string Getmxbonyr1 = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + (DCOym - 2) + " and lplbons.bontab=" + Tble + "";

                                dm.readSql(Getmxbonyr1);
                                OracleDataReader bonfilereader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                CountbonYr = int.Parse(CommDate.ToString().Substring(0, 4));
                                string bonry3 = "";
                                while (bonfilereader2.Read())
                                {
                                    flag = true;

                                    for (int j = 0; j < bonuscount; j++)
                                    {
                                        double annualbonus = 0;
                                        if (!bonfilereader2.IsDBNull(j)) { annualbonus = bonfilereader2.GetDouble(j); }
                                        if (j < 9)
                                        {
                                            bonry3 = "BONY" + "0" + Convert.ToString(j + 1);
                                        }
                                        else
                                        {
                                            bonry3 = "BONY" + Convert.ToString(j + 1);
                                        }
                                        int bonyrget = 0;
                                        string Getbon = "select " + bonry3 + " from lphs.lplbons where bonyea = " + (DCOym - 2) + " and bontab=" + Tble + "";
                                        if (dm.existRecored(Getbon) != 0)
                                        {
                                            dm.readSql(Getbon);
                                            OracleDataReader dr2 = dm.oraComm.ExecuteReader();
                                            while (dr2.Read())
                                            {
                                                if (!dr2.IsDBNull(0)) { bonyrget = dr2.GetInt32(0); } else { bonyrget = 0; }
                                            }
                                            dr2.Close();
                                        }
                                        if (j == bonuscount - 1)
                                        {
                                            if (CountbonYr == bonyrget)
                                            {
                                                totbonus = totbonus + annualbonus;
                                                interimBonStYR = CountbonYr;
                                            }
                                        }
                                        else
                                        {
                                            totbonus = totbonus + annualbonus;
                                        }
                                        if (annualbonus == 0)
                                        {
                                            if (bonyrget == 0 && annualbonus == 0.0)
                                            {
                                                int term = 0;
                                                int lastTerm = 0;
                                                string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                                                if (dm.existRecored(Getinterimbonamtandyr) != 0)
                                                {
                                                    dm.readSql(Getinterimbonamtandyr);
                                                    OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                                                    while (drintbon.Read())
                                                    {
                                                        if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                                        if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                                        {
                                                            if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                            if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                        }
                                                        else if (bonuscount > term)
                                                        {
                                                            if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                            if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                        }
                                                        lastTerm = term;
                                                    }
                                                    drintbon.Close();
                                                }
                                                else
                                                {
                                                }
                                            }
                                            interimboncount++;
                                            temp = intBonValfrmtble;
                                            break;
                                        }
                                        else { temp = annualbonus; interimboncount++; interimBonStYR = CountbonYr - 2; }
                                        CountbonYr = CountbonYr + 1;
                                    }
                                }
                                bonfilereader2.Close();
                                //bonfilereader.Dispose();
                                if (!flag)
                                { totbonus = 0; }
                                #endregion
                            }
                        }
                    }
                    #endregion
                }

                vestedBonus = (totbonus * SumAss) / 1000;
                if (Tble == 34)
                { vestedBonus = totbonus; }

                if (interimboncount < 0) { interimboncount = 0; }
                if (interimboncount > 0)
                {
                    interimbonus = (temp * interimboncount * SumAss) / 1000;
                    if (Tble == 34)
                    { interimbonus = (temp * SumAss) / 1000; }
                    if (intBonYrfrmtble == 0)
                    {
                        interimBonStYR = CountbonYr - 1;
                    }
                    else
                    {
                        interimBonStYR = intBonYrfrmtble;
                    }
                }
                if (Tble == 4 || Tble == 2)
                {
                    vestedBonus = 0;
                    interimbonus = 0;
                    interimBonStYR = 0;
                }
                this.lbltotbons.Text = "Rs." + String.Format("{0:N}", (vestedBonus));
                lbltotbons.Visible = true;
                lbltotbondes.Visible = true;

                #endregion

                #region Surrender Bonus Amount

                DCOym = int.Parse(Convert.ToString(CommDate).Substring(0, 4));
                //*************************************** Bonus Logic ******************************************

                bonsuryn = bonsuryn;
                if ((this.txtbonsurryr.Text != null) && (bonsuryn.Equals("Y"))) { bonSurrYr = int.Parse(this.txtbonsurryr.Text); }
                else if (this.txtbonsurryr.Text == null) { throw new Exception("If You Want the Surrendered Bonus Please Give the Surrender Year!"); }

                //************** Inforce ***********************************************************

                if (polstat.Equals("I"))
                {
                    if (bonsuryn.Equals("N"))
                    {
                        #region CheckBox Maturity
                        if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                            string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                            if (dm.existRecored(check_SJCover) != 0)
                            {
                                dm.readSql(check_SJCover);
                                int polno = 0;
                                int cvrNo = 0;
                                double CVRAmount = 0.0;
                                OracleDataReader red = dm.oraComm.ExecuteReader();
                                while (red.Read())
                                {
                                    if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                    if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                    if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                    lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                                }
                                red.Close();
                            }
                            btnsub.Enabled = false;
                            CkBx21.Visible = false;
                            btn_Next.Enabled = false;
                        }
                        #endregion
                    }
                    //**************** Inforce and bonus surrendered ************************************

                    else
                    {
                        surrbonuscount = bonSurrYr - DCOym + 1;
                        string incrementcountstr1 = "";
                        string incrementcountstrdclr1 = "";
                        int k = 0;

                        #region Check Maturity
                        if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                            string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                            if (dm.existRecored(check_SJCover) != 0)
                            {
                                dm.readSql(check_SJCover);
                                int polno = 0;
                                int cvrNo = 0;
                                double CVRAmount = 0.0;
                                OracleDataReader red = dm.oraComm.ExecuteReader();
                                while (red.Read())
                                {
                                    if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                    if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                    if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                    lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                                }
                                red.Close();
                            }
                            btnsub.Enabled = false;
                            CkBx21.Visible = false;
                        }
                        #endregion

                        else
                        {
                            for (k = 1; k < (surrbonuscount + 1); k++)
                            {
                                if (k < 10)
                                {
                                    incrementcountstr1 = incrementcountstr1 + "BONB" + "0" + Convert.ToString(k) + ", ";
                                    incrementcountstrdclr1 = incrementcountstrdclr1 + "BONY" + "0" + Convert.ToString(k) + ", ";
                                }
                                else
                                {
                                    incrementcountstr1 = incrementcountstr1 + "BONB" + Convert.ToString(k) + ", ";
                                    incrementcountstrdclr1 = incrementcountstrdclr1 + "BONY" + Convert.ToString(k) + ", ";
                                }

                            }

                            incrementcountstr1 = incrementcountstr1.Substring(0, incrementcountstr1.LastIndexOf(","));
                            incrementcountstrdclr1 = incrementcountstrdclr1.Substring(0, incrementcountstrdclr1.LastIndexOf(","));

                            //string bonsqlinf = "select " + incrementcountstr + "," + incrementcountstrdclr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + TBL + " ";
                            string bonsqlinf = "select " + incrementcountstr1 + "," + incrementcountstrdclr1 + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + Tble + " ";

                            dm.readSql(bonsqlinf);
                            OracleDataReader bonfilereaderinf = dm.oraComm.ExecuteReader();

                            bool flag1 = false;
                            while (bonfilereaderinf.Read())
                            {
                                flag1 = true;
                                for (int j = 0; j < surrbonuscount; j++)
                                {
                                    double annualbonus = bonfilereaderinf.GetDouble(j);
                                    int bondeclaredyr = bonfilereaderinf.GetInt32(j + surrbonuscount);
                                    if (bondeclaredyr > bonSurrYr)
                                    { break; }
                                    else
                                    { totsurrbonus = totsurrbonus + annualbonus; }
                                }

                            }
                            bonfilereaderinf.Close();
                            surrrenderedbons = (totsurrbonus * SumAss) / 1000;
                            lblsurramt.Text = "Rs." + surrrenderedbons.ToString("N2");
                            //hdfsurrbon.Value = surrrenderedbons.ToString();
                            lblsurramt.Visible = true;
                            lblsurrbon.Visible = true;
                            CkBx21.Visible = true;
                        }
                    }
                }

                 //*************** policy lapsed *********************************************

                else if (polstat == "L")
                {
                    if (bonsuryn.Equals("N"))
                    {
                        #region Check Maturity
                        if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                            string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                            if (dm.existRecored(check_SJCover) != 0)
                            {
                                dm.readSql(check_SJCover);
                                int polno = 0;
                                int cvrNo = 0;
                                double CVRAmount = 0.0;
                                OracleDataReader red = dm.oraComm.ExecuteReader();
                                while (red.Read())
                                {
                                    if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                    if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                    if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                    lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                                }
                                red.Close();
                            }
                            btnsub.Enabled = false;
                            CkBx21.Visible = false;
                        }
                        #endregion
                    }
                    //*********** Lapse and bonus surrendered *****************************

                    else
                    {
                        btnsub.Enabled = true;
                        surrbonuscount = bonSurrYr - DCOym + 1;
                        string incrementcountstr2 = "";
                        string incrementcountstrdclr2 = "";
                        int l = 0;
                        #region Check Maturity
                        if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                        {
                            totbonus = 0;
                            this.testlbl.Visible = true;
                            this.testlbl.Text = "Policy Matured";
                            string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                            if (dm.existRecored(check_SJCover) != 0)
                            {
                                dm.readSql(check_SJCover);
                                int polno = 0;
                                int cvrNo = 0;
                                double CVRAmount = 0.0;
                                OracleDataReader red = dm.oraComm.ExecuteReader();
                                while (red.Read())
                                {
                                    if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                    if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                    if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                    lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                                }
                                red.Close();
                            }
                            btnsub.Enabled = false;
                            CkBx21.Visible = false;
                        }
                        #endregion
                        else
                        {

                            for (i = 1; i < (surrbonuscount + 1); i++)
                            {
                                if (i < 10)
                                {
                                    incrementcountstr2 = incrementcountstr2 + "BONB" + "0" + Convert.ToString(l) + ", ";
                                    incrementcountstrdclr2 = incrementcountstrdclr2 + "BONY" + "0" + Convert.ToString(l) + ", ";
                                }
                                else
                                {
                                    incrementcountstr2 = incrementcountstr2 + "BONB" + Convert.ToString(l) + ", ";
                                    incrementcountstrdclr2 = incrementcountstrdclr2 + "BONY" + Convert.ToString(l) + ", ";
                                }


                            }

                            incrementcountstrdclr2 = incrementcountstrdclr2.Substring(0, incrementcountstrdclr2.LastIndexOf(","));
                            incrementcountstr2 = incrementcountstr2.Substring(0, incrementcountstr2.LastIndexOf(","));


                            //string bonsqlapse = "select " + incrementcountstr + ", " + incrementcountstrdclr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + table + " ";
                            string bonsqlapse = "select " + incrementcountstr2 + ", " + incrementcountstrdclr2 + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + Tble + " ";

                            dm.readSql(bonsqlapse);
                            OracleDataReader bonfilereaderlapse = dm.oraComm.ExecuteReader();
                            bool flag3 = false;
                            while (bonfilereaderlapse.Read())
                            {
                                flag3 = true;
                                for (int j = 0; j < (surrbonuscount); j++)
                                {
                                    double annualbonus = bonfilereaderlapse.GetDouble(j);
                                    int bondeclaredyr = bonfilereaderlapse.GetInt32(j + surrbonuscount);
                                    if (bondeclaredyr > bonSurrYr)
                                    { break; }
                                    else
                                    { totsurrbonus = totsurrbonus + annualbonus; }
                                }
                            }
                            bonfilereaderlapse.Close();
                            surrrenderedbons = (totsurrbonus * SumAss) / 1000;
                            //hdfsurrbon.Value = surrrenderedbons.ToString();
                        }
                    }
                }
                else { }
                #endregion
            }
            else
            {
                #region Hide Check Boxes

                CkBx1.Visible = false;                //CkBx2.Visible = false;
                //CkBx3.Visible = false;                CkBx4.Visible = false;
                CkBx5.Visible = false; CkBx6.Visible = false;
                CkBx7.Visible = false; CkBx8.Visible = false;

                CkBx9.Visible = false; CkBx10.Visible = false;
                CkBx11.Visible = false;
                //CkBx12.Visible = false;
                //CkBx13.Visible = false;
                CkBx14.Visible = false; CkBx15.Visible = false;
                //CkBx16.Visible = false;
                ChBx18.Visible = false;
                CkBx19.Visible = false; CkBx20.Visible = false; CkBx21.Visible = false;
                #endregion
            }
            #region Check table exists
            if (ViewState["Reftbl"] != null)
            {
                reftable = ViewState["Reftbl"].ToString();
                if (reftable == "E" || reftable == "P" || reftable == "L" || reftable == "M")
                {
                    litclmst.Visible = true;
                    ddlyn.Visible = true;
                }
                else
                {
                    litclmst.Visible = false;
                    ddlyn.Visible = false;
                }
            }
            #endregion
        }
        else
        {
            #region Assign Values
            ISAuthOrize = hdfauth.Value;
            if (litpolno.Text != "") { Polno = int.Parse(litpolno.Text); }
            if (txtclmno.Text != "")
            {
                //string[] clm = litclm.Text.Split(' ');
                string clmnum = txtclmno.Text;
                ClaimNo = int.Parse(clmnum);
            }
            if (txtprop.Text != "") { PropNo = int.Parse(txtprop.Text); }
            if (txtid.Text != "") { IDNo = txtid.Text; }
            if (txtsur.Text != "") { name = txtst.Text + txtint.Text + txtsur.Text; }
            Mode = int.Parse(txtmod.Text.Trim());
            if (ddllife.SelectedIndex > 0)
            {
                if (ddllife.SelectedIndex == 1) { mos = "M"; }
                if (ddllife.SelectedIndex == 2) { mos = "S"; }
                if (ddllife.SelectedIndex == 3) { mos = "2"; }
                if (ddllife.SelectedIndex == 4) { mos = "C"; }
            }
            if (ddlcvofr.SelectedIndex > 0)
            {
                if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                if (ddlcvofr.SelectedIndex == 6) { civilorforces = "B"; }
            }

            if (txtsumass.Text != "") { SumAss = double.Parse(txtsumass.Text); }
            if (hdftrcode.Value != null) { TraCode = hdftrcode.Value; }

            Tble = int.Parse(txttbl.Text.Trim());
            Term = int.Parse(txttrm.Text.Trim());

            if (ddlyn.SelectedIndex == 1)
            {
                Claimsts = "Pending";
                TraCode = "A";
            }
            else if (ddlyn.SelectedIndex == 2)
            {
                Claimsts = "Admitted";
                TraCode = "B";
            }
            else if (ddlyn.SelectedIndex == 3)
            {
                Claimsts = "Part Pay";
                TraCode = "C";
            }
            #endregion

            #region Check whether loans available for the given policy number

            string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1  from lphs.lplmast where lmpol=" + Polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
            int caldate = int.Parse(this.setDate()[0]);
            dm.readSql(loansql);
            OracleDataReader myloanreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            int rows = 0;
            double loantotal = 0;
            double loaninttot = 0;

            while (myloanreader.Read())
            {
                double[] arr = new double[9];

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

                if (!myloanreader.IsDBNull(0)) { LoanNum = myloanreader.GetInt32(0); }
                if (!myloanreader.IsDBNull(1)) { lmpdt = myloanreader.GetInt32(1); }
                if (!myloanreader.IsDBNull(2)) { lmnid = myloanreader.GetInt32(2); }
                if (!myloanreader.IsDBNull(3)) { lmlrd = myloanreader.GetInt32(3); }
                if (!myloanreader.IsDBNull(4)) { lmpit = myloanreader.GetDouble(4); }
                if (!myloanreader.IsDBNull(5)) { lmnit = myloanreader.GetDouble(5); }
                if (!myloanreader.IsDBNull(6)) { lmpcp = myloanreader.GetDouble(6); }
                if (!myloanreader.IsDBNull(7)) { lmncp = myloanreader.GetDouble(7); }
                if (!myloanreader.IsDBNull(8)) { lmipy = myloanreader.GetDouble(8); }
                if (!myloanreader.IsDBNull(9)) { lmcpy = myloanreader.GetDouble(9); }
                if (!myloanreader.IsDBNull(10)) { lmitr = myloanreader.GetDouble(10); loanint_rate = lmitr; }
                if (!myloanreader.IsDBNull(11)) { lmcit = myloanreader.GetDouble(11); }
                if (!myloanreader.IsDBNull(12)) { lmccp = myloanreader.GetDouble(12); }
                if (!myloanreader.IsDBNull(13)) { lmcdt = myloanreader.GetInt32(13); }
                if (!myloanreader.IsDBNull(14)) { lmmdt = myloanreader.GetInt32(14); }

                string lmset = "";
                if (!myloanreader.IsDBNull(15))
                {
                    lmset = myloanreader.GetString(15);
                }
                string lmcd1 = "";
                if (!myloanreader.IsDBNull(16))
                {
                    lmcd1 = myloanreader.GetString(16);
                }
                if (hdfdthdt.Value != null)
                {
                    DeathDate = int.Parse(hdfdthdt.Value);
                }
                if ((!lmset.Equals("Y")) && (!(lmcd1.Equals("D"))))
                {
                    this.Label1.Visible = true;
                    try
                    {
                        //arr = loanCalculation.calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, caldate);

                        //loantotal += arr[5];
                        //loaninttot += arr[8];

                        //loanCapital = arr[5];
                        //loaninterest = arr[8];
                        loanbackobj = new LoanBackCal(Polno, DeathDate, LoanNum);
                        loanCapital += loanbackobj.Loancap;
                        loaninterest += loanbackobj.Backinterest;
                        hdflncap.Value = loanCapital.ToString();
                        lnintrst.Value = loaninterest.ToString();
                        lngrndt.Value = lmcdt.ToString();
                    }
                    catch (Exception ex)
                    {
                        this.lblerr.Text = ex.Message.ToString();
                        loantotal = 0;
                        loaninttot = 0;
                    }
                    //------------- Back Calculation Algorithm Applied 20070802 ------------

                    //double temploanCapital = loanCapital;
                    //loanCapital = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, loanCapital, ((double)lmitr / 200), lmpdt, lmpit)[0];
                    //loaninterest = this.backCalculationAlgorithm(lmcdt, dateofdeath, loaninterest, temploanCapital, ((double)lmitr / 200), lmpdt, lmpit)[1];
                    //temploanCapital = loanCapital - loaninterest;

                    rows++;
                    if (rows == 1)
                    {
                        this.createLoanTable("Loan No.", "Granted Date", "Loan Capital (Rs.)", "Interest (Rs.)", (rows - 1));
                        this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                    }
                    else
                    {
                        this.createLoanTable(Convert.ToString(LoanNum), (Convert.ToString(lmcdt).Substring(0, 4) + "/" + Convert.ToString(lmcdt).Substring(4, 2) + "/" + Convert.ToString(lmcdt).Substring(6, 2)), Convert.ToString(loanCapital), Convert.ToString(loaninterest), rows);
                    }
                }
            }
            myloanreader.Close();
            #endregion
            
            #region Display Bonus Amount

            if (ddlpolst.SelectedIndex == 1)
            { polstat = "I"; }
            else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }
            else { polstat = ""; lblerr.Text = "Please Select the Policy Status"; }
            if (ddlbonsurrYN.SelectedIndex == 0)
            {
                bonsuryn = "N";
            }
            else if (ddlbonsurrYN.SelectedIndex == 1)
            {
                bonsuryn = "Y";
            }
            int lastpaymentY = 0;
            CommDate = int.Parse(txtcomdat.Text.Trim());
            DeathDate = int.Parse(hdfdthdt.Value);
            if (txtnxteff.Text.Trim() != "")
            {
                Nexteffdt = int.Parse(txtnxteff.Text.Trim());
            }
            SumAss = double.Parse(txtsumass.Text.Trim());

            DateTime deathyrmn = DateTime.Parse(DeathDate.ToString().Substring(0, 4) + "/" + DeathDate.ToString().Substring(4, 2) + "/" + DeathDate.ToString().Substring(6, 2));
            DateTime nexteffectivedate = DateTime.Parse(Nexteffdt.ToString().Substring(0, 4) + "/" + Nexteffdt.ToString().Substring(4, 2) + "/" + CommDate.ToString().Substring(6, 2));
            TimeSpan diffmn = deathyrmn.Subtract(nexteffectivedate);
            int mn = diffmn.Days / 30;
            if (mn >= 6)
            {
                polstat = "L";
            }
            else
            {
                polstat = "I";
            }
            if (polstat.Equals("I"))
            {
                polDuraYrs = this.dateComparison(CommDate, DeathDate)[0];
                polDuraMnths = this.dateComparison(CommDate, DeathDate)[1];
                polDuraDays = this.dateComparison(CommDate, DeathDate)[2];
                if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }
            }
            else if (polstat.Equals(""))
            { }
            else
            {
                //---------- include code to read the ledger table to get the last paymnet date
                int lpasedate = 0;
                string GetLpseDate = "select max(lldue) from lclm.ledger where llpol=" + Polno + "";
                if (dm.existRecored(GetLpseDate) != 0)
                {
                    dm.readSql(GetLpseDate);
                    OracleDataReader dr = dm.oraComm.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0)) { lpasedate = dr.GetInt32(0); } else { lpasedate = 0; }
                    }
                    dr.Close();
                }
                int dueYMD = int.Parse(Nexteffdt.ToString() + CommDate.ToString().Substring(6, 2));
                if (lpasedate != 0)
                {
                    lpasedate = int.Parse(lpasedate.ToString() + CommDate.ToString().Substring(6, 2));
                }
                else
                {
                    lpasedate = dueYMD;
                }
                if (lpasedate < dueYMD)
                {
                    polDuraYrs = this.dateComparison(CommDate, lpasedate)[0];
                    polDuraMnths = this.dateComparison(CommDate, lpasedate)[1];
                    polDuraDays = this.dateComparison(CommDate, lpasedate)[2];
                    if (Mode == 4)
                    {
                        polDuraMnths = polDuraMnths + 1;
                    }
                    else if (Mode == 3)
                    {
                        polDuraMnths = polDuraMnths + 3;
                    }
                    else if (Mode == 2)
                    {
                        polDuraMnths = polDuraMnths + 6;
                    }
                    else if (Mode == 1)
                    {
                        polDuraMnths = polDuraMnths + 12;
                    }
                    if (polDuraMnths >= 12)
                    {
                        polDuraYrs = polDuraYrs + 1;
                        polDuraMnths = polDuraMnths - 12;
                    }
                }
                else
                {
                    polDuraYrs = this.dateComparison(CommDate, dueYMD)[0];
                    polDuraMnths = this.dateComparison(CommDate, dueYMD)[1];
                    polDuraDays = this.dateComparison(CommDate, dueYMD)[2];
                    polDuraMnths = polDuraMnths + 1;
                    if (polDuraMnths >= 12)
                    {
                        polDuraYrs = polDuraYrs + 1;
                        polDuraMnths = polDuraMnths - 12;
                    }
                }

                if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }
                lastpaymentY = int.Parse(CommDate.ToString().Substring(0, 4)) + polDuraYrs - 1;
                //-------- Check demands if Exists calculate total paid years -----
                int dem_count = 0;
                string checkdemands = "select count(pddue) from lphs.demand where PDPOL=" + Polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue<" + Nexteffdt + "";
                if (dm.existRecored(checkdemands) != 0)
                {
                    dm.readSql(checkdemands);
                    OracleDataReader dr1 = dm.oraComm.ExecuteReader();
                    while (dr1.Read())
                    {
                        if (!dr1.IsDBNull(0)) { dem_count = dr1.GetInt32(0); } else { dem_count = 0; }
                    }
                    dr1.Close();
                }
                if (Mode == 1) { dem_count = 12 * dem_count; }
                else if (Mode == 2) { dem_count = 6 * dem_count; }
                else if (Mode == 3) { dem_count = 3 * dem_count; }
                else if (Mode == 4) { dem_count = dem_count; }

                if (dem_count < polDuraMnths)
                {
                    dem_count = polDuraMnths - dem_count;
                }
                else if (dem_count > polDuraMnths)
                {
                    polDuraMnths = polDuraMnths + 12;
                    polDuraYrs = polDuraYrs - 1;
                    polDuraMnths = polDuraMnths - dem_count;

                }
            }

            double totbonus = 0;
            int interimboncount = 0;
            int yeardiff = 0;
            int monthdiff = 0;

            int DCOym = int.Parse(Convert.ToString(CommDate).Substring(0, 4));
            if (polstat.Equals("I"))
            {
                yeardiff = int.Parse(hdfdthdt.Value.Substring(0, 4)) - int.Parse(Convert.ToString(CommDate).Substring(0, 4));
            }
            else if (polstat.Equals("L"))
            {
                int multiplier = 0;
                if (Mode == 1) { multiplier = 12; }
                else if (Mode == 2) { multiplier = 6; }
                else if (Mode == 3) { multiplier = 3; }
                else if (Mode == 4) { multiplier = 1; }


            }
            else { }
            bool flag = false;

            //----- excluding bonus not declared years ----

            //bonuscount = lastpaymentY - int.Parse(dateofComm.ToString().Substring(0, 4));

            if (polstat.Equals("I"))
            {
                bonuscount = yeardiff;
            }
            else
            {
                bonuscount = polDuraYrs;
            }
            if (polstat.Equals("L"))
            {
                if (lastpaymentY == 1963 || lastpaymentY == 1967 || lastpaymentY == 1972 || lastpaymentY == 1974 || lastpaymentY == 1976 || lastpaymentY == 1981 || lastpaymentY == 1984 || lastpaymentY == 1986 || lastpaymentY == 1989 || lastpaymentY == 1991 || lastpaymentY == 1996)
                {
                    if (int.Parse(Nexteffdt.ToString().Substring(0, 4)) < (int.Parse(CommDate.ToString().Substring(0, 4)) + polDuraYrs)) { bonuscount--; }
                }
                else if (lastpaymentY == 1964 || lastpaymentY == 1968 || lastpaymentY == 1977 || lastpaymentY == 1982 || lastpaymentY == 1987) { bonuscount -= 2; }
                else if (lastpaymentY == 1965 || lastpaymentY == 1969 || lastpaymentY == 1978) { bonuscount -= 3; }
                else if (lastpaymentY == 1970 || lastpaymentY == 1979) { bonuscount -= 4; }
            }

            string incrementcountstr = "";
            string incrementcountstrdclr = "";
            int i;
            double temp = 0;
            if (bonuscount > 0)
            {
                #region Get Bonus field names
                for (i = 1; i < (bonuscount + 1); i++)
                {
                    if (i < 10)
                    {
                        incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                    }
                    else
                    {
                        incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                    }
                } 
                incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));
                #endregion

                #region Get Bonus from Bonus Table
                string bonsql = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + Tble + " ";
                if (dm.existRecored(bonsql) != 0)
                {
                    dm.readSql(bonsql);
                    OracleDataReader bonfilereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    CountbonYr = int.Parse(CommDate.ToString().Substring(0, 4));
                    string bonry = "";
                    while (bonfilereader.Read())
                    {
                        flag = true;

                        for (int j = 0; j < bonuscount; j++)
                        {
                            double annualbonus = 0;
                            if (!bonfilereader.IsDBNull(j)) { annualbonus = bonfilereader.GetDouble(j); }
                            if (j < 9)
                            {
                                bonry = "BONY" + "0" + Convert.ToString(j + 1);
                            }
                            else
                            {
                                bonry = "BONY" + Convert.ToString(j + 1);
                            }
                            int bonyrget = 0;
                            string Getbon = "select " + bonry + " from lphs.lplbons where bonyea = " + int.Parse(CommDate.ToString().Substring(0, 4)) + " and bontab=" + Tble + "";
                            if (dm.existRecored(Getbon) != 0)
                            {
                                dm.readSql(Getbon);
                                OracleDataReader dr2 = dm.oraComm.ExecuteReader();
                                while (dr2.Read())
                                {
                                    if (!dr2.IsDBNull(0)) { bonyrget = dr2.GetInt32(0); } else { bonyrget = 0; }
                                }
                                dr2.Close();                                
                            }
                            if (j == bonuscount - 1)
                            {
                                if (CountbonYr == bonyrget)
                                {
                                    totbonus = totbonus + annualbonus;
                                    interimBonStYR = CountbonYr;
                                }
                            }
                            else
                            {
                                totbonus = totbonus + annualbonus;
                            }
                            if (annualbonus == 0.0)
                            {
                                if (bonyrget == 0 && annualbonus == 0.0)
                                {
                                    int term = 0;
                                    int lastTerm = 0;
                                    string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                                    if (dm.existRecored(Getinterimbonamtandyr) != 0)
                                    {
                                        dm.readSql(Getinterimbonamtandyr);
                                        OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                                        while (drintbon.Read())
                                        {
                                            if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                            if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                            {
                                                if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                            }
                                            else if (bonuscount > term)
                                            {
                                                if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }                                         
                                            }
                                            lastTerm = term;
                                        }
                                        drintbon.Close();
                                    }
                                    else
                                    {                                        
                                    }
                                }
                                interimboncount++;
                                temp = intBonValfrmtble;
                                break;
                            }
                            else { temp = annualbonus; }
                            CountbonYr = CountbonYr + 1;
                        }
                    }
                    bonfilereader.Close();                 
                    if (!flag)
                    { totbonus = 0; }
                }
#endregion

                #region If no value in bonus table
                else
                {
                    int term = 0;
                    int lastTerm = 0;
                    string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                    if (dm.existRecored(Getinterimbonamtandyr) != 0)
                    {
                        dm.readSql(Getinterimbonamtandyr);
                        OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                        while (drintbon.Read())
                        {
                            if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                            if ((bonuscount <= term) && (bonuscount >= lastTerm))
                            {
                                if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                            }
                            else if (bonuscount > term)
                            {
                                if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                            }
                            lastTerm = term;
                        }
                        drintbon.Close();
                    }
                    interimboncount++;
                    temp = intBonValfrmtble;                    
                }

                if (dm.existRecored(bonsql) == 0)
                {
                    if (intBonValfrmtble == 0.0)
                    {
                        string Getmxbonyr = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + (DCOym - 1) + " and lplbons.bontab=" + Tble + "";
                        if (dm.existRecored(Getmxbonyr) != 0)
                        {
                            #region Get Last Declared Bonus
                            dm.readSql(Getmxbonyr);
                            OracleDataReader bonfilereader1 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            CountbonYr = int.Parse(CommDate.ToString().Substring(0, 4));
                            string bonry1 = "";
                            while (bonfilereader1.Read())
                            {
                                flag = true;

                                for (int j = 0; j < bonuscount; j++)
                                {
                                    double annualbonus = 0;
                                    if (!bonfilereader1.IsDBNull(j)) { annualbonus = bonfilereader1.GetDouble(j); }
                                    if (j < 9)
                                    {
                                        bonry1 = "BONY" + "0" + Convert.ToString(j + 1);
                                    }
                                    else
                                    {
                                        bonry1 = "BONY" + Convert.ToString(j + 1);
                                    }
                                    int bonyrget = 0;
                                    string Getbon = "select " + bonry1 + " from lphs.lplbons where bonyea = " + (DCOym - 1) + " and bontab=" + Tble + "";
                                    if (dm.existRecored(Getbon) != 0)
                                    {
                                        dm.readSql(Getbon);
                                        OracleDataReader dr2 = dm.oraComm.ExecuteReader();
                                        while (dr2.Read())
                                        {
                                            if (!dr2.IsDBNull(0)) { bonyrget = dr2.GetInt32(0); } else { bonyrget = 0; }
                                        }
                                        dr2.Close();
                                    }
                                    if (j == bonuscount - 1)
                                    {
                                        if ((CountbonYr) == bonyrget)
                                        {
                                            totbonus = totbonus + annualbonus;
                                            interimBonStYR = CountbonYr;
                                        }
                                    }
                                    else
                                    {
                                        totbonus = totbonus + annualbonus;
                                    }
                                    if (annualbonus == 0)
                                    {
                                        if (bonyrget == 0 && annualbonus == 0.0)
                                        {
                                            int term = 0;
                                            int lastTerm = 0;
                                            string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                                            if (dm.existRecored(Getinterimbonamtandyr) != 0)
                                            {
                                                dm.readSql(Getinterimbonamtandyr);
                                                OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                                                while (drintbon.Read())
                                                {
                                                    if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                                    if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                                    {
                                                        if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                        if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                    }
                                                    else if (bonuscount > term)
                                                    {
                                                        if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                        if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                    }
                                                    lastTerm = term;
                                                }
                                                drintbon.Close();
                                            }
                                            else
                                            {
                                            }
                                        }
                                        interimboncount++;
                                        temp = intBonValfrmtble;
                                        break;
                                    }
                                    else { temp = annualbonus; interimboncount++; interimBonStYR = CountbonYr - 1; }
                                    CountbonYr = CountbonYr + 1;
                                }
                            }
                            bonfilereader1.Close();
                            //bonfilereader.Dispose();
                            if (!flag)
                            { totbonus = 0; }
                            #endregion
                        }
                        else
                        {
                            #region Get Last Declared Bonus

                            string Getmxbonyr1 = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + (DCOym - 2) + " and lplbons.bontab=" + Tble + "";

                            dm.readSql(Getmxbonyr1);
                            OracleDataReader bonfilereader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            CountbonYr = int.Parse(CommDate.ToString().Substring(0, 4));
                            string bonry3 = "";
                            while (bonfilereader2.Read())
                            {
                                flag = true;

                                for (int j = 0; j < bonuscount; j++)
                                {
                                    double annualbonus = 0;
                                    if (!bonfilereader2.IsDBNull(j)) { annualbonus = bonfilereader2.GetDouble(j); }
                                    if (j < 9)
                                    {
                                        bonry3 = "BONY" + "0" + Convert.ToString(j + 1);
                                    }
                                    else
                                    {
                                        bonry3 = "BONY" + Convert.ToString(j + 1);
                                    }
                                    int bonyrget = 0;
                                    string Getbon = "select " + bonry3 + " from lphs.lplbons where bonyea = " + (DCOym - 2) + " and bontab=" + Tble + "";
                                    if (dm.existRecored(Getbon) != 0)
                                    {
                                        dm.readSql(Getbon);
                                        OracleDataReader dr2 = dm.oraComm.ExecuteReader();
                                        while (dr2.Read())
                                        {
                                            if (!dr2.IsDBNull(0)) { bonyrget = dr2.GetInt32(0); } else { bonyrget = 0; }
                                        }
                                        dr2.Close();
                                    }
                                    if (j == bonuscount - 1)
                                    {
                                        if (CountbonYr == bonyrget)
                                        {
                                            totbonus = totbonus + annualbonus;
                                            interimBonStYR = CountbonYr;
                                        }
                                    }
                                    else
                                    {
                                        totbonus = totbonus + annualbonus;
                                    }
                                    if (annualbonus == 0)
                                    {
                                        if (bonyrget == 0 && annualbonus == 0.0)
                                        {
                                            int term = 0;
                                            int lastTerm = 0;
                                            string Getinterimbonamtandyr = "select BON_TRM,BON_YEAR,BON_VAL  from LPHS.LIFE_INTERIM_BON  WHERE BON_TBL = " + Tble + " ";//and  BON_TRM="+Term+"
                                            if (dm.existRecored(Getinterimbonamtandyr) != 0)
                                            {
                                                dm.readSql(Getinterimbonamtandyr);
                                                OracleDataReader drintbon = dm.oraComm.ExecuteReader();
                                                while (drintbon.Read())
                                                {
                                                    if (!drintbon.IsDBNull(0)) { term = drintbon.GetInt32(0); } else { term = 0; }
                                                    if ((bonuscount <= term) && (bonuscount >= lastTerm))
                                                    {
                                                        if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                        if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                    }
                                                    else if (bonuscount > term)
                                                    {
                                                        if (!drintbon.IsDBNull(1)) { intBonYrfrmtble = drintbon.GetInt32(1); } else { intBonYrfrmtble = 0; }
                                                        if (!drintbon.IsDBNull(2)) { intBonValfrmtble = drintbon.GetDouble(2); } else { intBonValfrmtble = 0.0; }
                                                    }
                                                    lastTerm = term;
                                                }
                                                drintbon.Close();
                                            }
                                            else
                                            {
                                            }
                                        }
                                        interimboncount++;
                                        temp = intBonValfrmtble;
                                        break;
                                    }
                                    else { temp = annualbonus; interimboncount++; interimBonStYR = CountbonYr - 2; }
                                    CountbonYr = CountbonYr + 1;
                                }
                            }
                            bonfilereader2.Close();
                            //bonfilereader.Dispose();
                            if (!flag)
                            { totbonus = 0; }
                            #endregion
                        }
                    }
                }
            #endregion
            }           

            vestedBonus = (totbonus * SumAss) / 1000;
            if (Tble == 34)
            { vestedBonus = totbonus; }
          
            if (interimboncount < 0) { interimboncount = 0; }
            if (interimboncount > 0)
            {
                interimbonus = (temp * interimboncount * SumAss) / 1000;
                if (Tble == 34)
                { interimbonus = (temp* SumAss)/1000; }
                if (intBonYrfrmtble == 0)
                {
                    interimBonStYR = CountbonYr - 1;
                }
                else
                {
                    interimBonStYR = intBonYrfrmtble;
                }
            }
            if (Tble == 4 || Tble == 2)
            {
                vestedBonus = 0;
                interimbonus = 0;
                interimBonStYR = 0;
            }
            this.lbltotbons.Text = "Rs." + String.Format("{0:N}", (vestedBonus));
            lbltotbons.Visible = true;
            lbltotbondes.Visible = true;
           
            #endregion

            #region Surrender Bonus Amount

            DCOym = int.Parse(Convert.ToString(CommDate).Substring(0, 4));
            //*************************************** Bonus Logic ******************************************

            bonsuryn = bonsuryn;
            if ((this.txtbonsurryr.Text != null) && (bonsuryn.Equals("Y"))) { bonSurrYr = int.Parse(this.txtbonsurryr.Text); }
            else if (this.txtbonsurryr.Text == null) { throw new Exception("If You Want the Surrendered Bonus Please Give the Surrender Year!"); }

            //************** Inforce ***************************************************

            if (polstat.Equals("I"))
            {
                if (bonsuryn.Equals("N"))
                {
                    #region CheckBox Maturity

                    if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                    {
                        totbonus = 0;
                        this.testlbl.Visible = true;
                        this.testlbl.Text = "Policy Matured";
                        string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                        if (dm.existRecored(check_SJCover) != 0)
                        {
                            dm.readSql(check_SJCover);
                            int polno = 0;
                            int cvrNo = 0;
                            double CVRAmount = 0.0;
                            OracleDataReader red = dm.oraComm.ExecuteReader();
                            while (red.Read())
                            {
                                if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                            }
                            red.Close();
                        }
                        btnsub.Enabled = false;
                        CkBx21.Visible = false;
                    }
                    #endregion
                }

             //**************** Inforce and bonus surrendered ************************************

                else
                {
                    surrbonuscount = bonSurrYr - DCOym + 1;
                    incrementcountstr1 = "";
                    incrementcountstrdclr1 = "";
                    int k = 0;
                    #region Check Maturity

                    if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                    {
                        totbonus = 0;
                        this.testlbl.Visible = true;
                        this.testlbl.Text = "Policy Matured";
                        string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                        if (dm.existRecored(check_SJCover) != 0)
                        {
                            dm.readSql(check_SJCover);
                            int polno = 0;
                            int cvrNo = 0;
                            double CVRAmount = 0.0;
                            OracleDataReader red = dm.oraComm.ExecuteReader();
                            while (red.Read())
                            {
                                if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                            }
                            red.Close();
                        }
                        btnsub.Enabled = false;
                        CkBx21.Visible = false;
                    }
                    #endregion
                    else
                    {

                        for (k = 1; k < (surrbonuscount + 1); k++)
                        {
                            if (k < 10)
                            {
                                incrementcountstr1 = incrementcountstr1 + "BONB" + "0" + Convert.ToString(k) + ", ";
                                incrementcountstrdclr1 = incrementcountstrdclr1 + "BONY" + "0" + Convert.ToString(k) + ", ";
                            }
                            else
                            {
                                incrementcountstr1 = incrementcountstr1 + "BONB" + Convert.ToString(k) + ", ";
                                incrementcountstrdclr1 = incrementcountstrdclr1 + "BONY" + Convert.ToString(k) + ", ";
                            }

                        }

                        incrementcountstr1 = incrementcountstr1.Substring(0, incrementcountstr1.LastIndexOf(","));
                        incrementcountstrdclr1 = incrementcountstrdclr1.Substring(0, incrementcountstrdclr1.LastIndexOf(","));

                        //string bonsqlinf = "select " + incrementcountstr + "," + incrementcountstrdclr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + TBL + " ";
                        string bonsqlinf = "select " + incrementcountstr1 + "," + incrementcountstrdclr1 + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + Tble + " ";

                        dm.readSql(bonsqlinf);
                        OracleDataReader bonfilereaderinf = dm.oraComm.ExecuteReader();

                        bool flag1 = false;
                        while (bonfilereaderinf.Read())
                        {
                            flag1 = true;
                            for (int j = 0; j < surrbonuscount; j++)
                            {
                                double annualbonus = bonfilereaderinf.GetDouble(j);
                                int bondeclaredyr = bonfilereaderinf.GetInt32(j + surrbonuscount);
                                if (bondeclaredyr > bonSurrYr)
                                { break; }
                                else
                                { totsurrbonus = totsurrbonus + annualbonus; }
                            }

                        }
                        bonfilereaderinf.Close();
                        surrrenderedbons = (totsurrbonus * SumAss) / 1000;
                        //hdfsurrbon.Value = surrrenderedbons.ToString();
                        lblsurramt.Text = "Rs." + surrrenderedbons.ToString("N2");
                        lblsurramt.Visible = true;
                        lblsurrbon.Visible = true;
                        CkBx21.Visible = true;
                    }
                }
            }

             //*************** policy lapsed *********************************************

            else if (polstat.Equals("L"))
            {
                if (bonsuryn.Equals("N"))
                {
                    #region Check MAturity
                    if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                    {
                        totbonus = 0;
                        this.testlbl.Visible = true;
                        this.testlbl.Text = "Policy Matured";
                        string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                        if (dm.existRecored(check_SJCover) != 0)
                        {
                            dm.readSql(check_SJCover);
                            int polno = 0;
                            int cvrNo = 0;
                            double CVRAmount = 0.0;
                            OracleDataReader red = dm.oraComm.ExecuteReader();
                            while (red.Read())
                            {
                                if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                            }
                            red.Close();
                        }
                        btnsub.Enabled = false;
                        CkBx21.Visible = false;
                    }
                    #endregion
                }

                 //*********** Lapse and bonus surrendered *****************************

                else
                {
                    btnsub.Enabled = true;
                    surrbonuscount = bonSurrYr - DCOym + 1;
                    string incrementcountstr2 = "";
                    string incrementcountstrdclr2 = "";
                    int l = 0;

                    #region Check MAturity
                    if ((Term < bonuscount) && Tble != 12 && Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                    {
                        totbonus = 0;
                        this.testlbl.Visible = true;
                        this.testlbl.Text = "Policy Matured";
                        string check_SJCover = "select RPOL,RCOVR,RSUMAS from lund.rcover where RPOL=" + int.Parse(litpolno.Text) + " and RCOVR=10";
                        if (dm.existRecored(check_SJCover) != 0)
                        {
                            dm.readSql(check_SJCover);
                            int polno = 0;
                            int cvrNo = 0;
                            double CVRAmount = 0.0;
                            OracleDataReader red = dm.oraComm.ExecuteReader();
                            while (red.Read())
                            {
                                if (!red.IsDBNull(0)) { polno = red.GetInt32(0); }
                                if (!red.IsDBNull(1)) { cvrNo = red.GetInt32(1); }
                                if (!red.IsDBNull(2)) { CVRAmount = red.GetDouble(2); }

                                lblsuc.Text = "This Policy Has Swarnajayanthi Cover Amount of:" + CVRAmount;
                            }
                            red.Close();
                        }
                        btnsub.Enabled = false;
                        CkBx21.Visible = false;
                    }
                    #endregion

                    else
                    {

                        for (i = 1; i < (surrbonuscount + 1); i++)
                        {
                            if (i < 10)
                            {
                                incrementcountstr2 = incrementcountstr2 + "BONB" + "0" + Convert.ToString(l) + ", ";
                                incrementcountstrdclr2 = incrementcountstrdclr2 + "BONY" + "0" + Convert.ToString(l) + ", ";
                            }
                            else
                            {
                                incrementcountstr2 = incrementcountstr2 + "BONB" + Convert.ToString(l) + ", ";
                                incrementcountstrdclr2 = incrementcountstrdclr2 + "BONY" + Convert.ToString(l) + ", ";
                            }


                        }

                        incrementcountstrdclr2 = incrementcountstrdclr2.Substring(0, incrementcountstrdclr2.LastIndexOf(","));
                        incrementcountstr2 = incrementcountstr2.Substring(0, incrementcountstr2.LastIndexOf(","));


                        //string bonsqlapse = "select " + incrementcountstr + ", " + incrementcountstrdclr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + table + " ";
                        string bonsqlapse = "select " + incrementcountstr2 + ", " + incrementcountstrdclr2 + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + Tble + " ";

                        dm.readSql(bonsqlapse);
                        OracleDataReader bonfilereaderlapse = dm.oraComm.ExecuteReader();
                        bool flag3 = false;
                        while (bonfilereaderlapse.Read())
                        {
                            flag3 = true;
                            for (int j = 0; j < (surrbonuscount); j++)
                            {
                                double annualbonus = bonfilereaderlapse.GetDouble(j);
                                int bondeclaredyr = bonfilereaderlapse.GetInt32(j + surrbonuscount);
                                if (bondeclaredyr > bonSurrYr)
                                { break; }
                                else
                                { totsurrbonus = totsurrbonus + annualbonus; }
                            }
                        }
                        bonfilereaderlapse.Close();
                        surrrenderedbons = (totsurrbonus * SumAss) / 1000;
                    }
                }
            }
            else { }
            #endregion
            
            if (BrCode != 0)
            {
                DropDownList1.Text = dm.getBranchName(BrCode.ToString());
            }
            BrCode = dm.getBranchcode(DropDownList1.Text);
            hdfbrn.Value = BrCode.ToString();
            ISAuthOrize = hdfauth.Value;           
        }
        
            
    }
   
    protected void btnsub_Click(object sender, EventArgs e)
    {
        lblerr.Text = "";
       int yeardiffe=0;
        lblsuc.Text = "";
        DataManager dm = new DataManager();
        //string Status = "";
        bool IsTermPos = false;
        #region Database Values
       // string Polstatus = "";
        string Nod = txtst.Text + txtint.Text + txtsur.Text;
        string EntryDate = DateTime.Now.ToString("yyyyMMdd");
        EntryIP = Request.ServerVariables.Get("REMOTE_ADDR");
        EntryEpf = entEPF;
        string MOS = "";
        string MethodInf="";
        //if (ViewState["Auth"] != null)
        //{
        //    Auth = ViewState["Auth"].ToString();
        //}
        ISAuthOrize = hdfauth.Value;
        if (ViewState["Reftbl"] != null)
        {
            reftable = ViewState["Reftbl"].ToString();
        }        
        if (litpolno.Text != ""){Polno = int.Parse(litpolno.Text.Trim()); }
        if (txtprop.Text != "") { PropNo = int.Parse(txtprop.Text.Trim()); }
        if (txtclmno.Text != "")
        {
            //string[] clm = litclm.Text.Split(' ');
            string clmnum = txtclmno.Text;            
            ClaimNo = Convert.ToInt32(clmnum);
        }
        if (hdfdthdt.Value != null) { DeathDate = int.Parse(hdfdthdt.Value); }
        if (txtinfdate.Text != "") { InfDate = int.Parse(txtinfdate.Text.Trim()); }
        if (txtprm.Text != "") { Premium = double.Parse(txtprm.Text.Trim()); }
        if (txtmod.Text != "") { Mode = int.Parse(txtmod.Text.Trim()); }
        if (txtnxteff.Text != "") { Nexteffdt = int.Parse(txtnxteff.Text.Trim()); }
        if (txtpacode.Text != "") { PACode = int.Parse(txtpacode.Text.Trim()); }
        if (txtagtcd.Text != "") { AgtCode = int.Parse(txtagtcd.Text.Trim()); }
        if (txtorgcd.Text != "") { OrgCode = int.Parse(txtorgcd.Text.Trim()); }
        if (txtsumass.Text != "") { SumAss = double.Parse(txtsumass.Text.Trim()); }
        if (txttbl.Text != "") { Tble = int.Parse(txttbl.Text.Trim()); }
        if (txttrm.Text != "") { Term = int.Parse(txttrm.Text.Trim()); }
        if (txtcomdat.Text != "") { CommDate = int.Parse(txtcomdat.Text.Trim()); }
        if (txtgrsclm.Text != "") { Grossclm = double.Parse(txtgrsclm.Text.Trim()); }
        if (txtnetclm.Text != "") { NetClm = double.Parse(txtnetclm.Text.Trim()); }
        if (child1othrname.Text != "" || child1surname.Text != "")
        {
            childfullname = child1othrname.Text+" "+ child1surname.Text.Trim();            
            childSurna = child1surname.Text.Trim();
            childfullname = childfullname.ToUpper();
            childSurna = childSurna.ToUpper();
        }
        if (child1dob.Text != "")
        {
            child_dob = int.Parse(child1dob.Text);
        }
        if (txtothNames.Text != "" || txtsurname.Text != "")
        {
            Fullname = txtothNames.Text+" "+ txtsurname.Text.Trim();
            Fullname = Fullname.ToUpper();
            Surname = txtsurname.Text.Trim();
            Surname = Surname.ToUpper();
        }
        if (txtdob.Text != "")
        {
            DOB = int.Parse(txtdob.Text);
        }
        if (polstat == "I")
        {
            yeardiffe = int.Parse(hdfdthdt.Value.Substring(0, 4)) - int.Parse(Convert.ToString(CommDate).Substring(0, 4));
        }
        else 
        {
            yeardiffe = polDuraYrs;
        }
#endregion

        int defprms = 0;
        if (TraCode.Trim() == "C")
        {
            defprms = this.DefPremiums(DeathDate, Polno, CommDate);
        }
        if (ISAuthOrize != null && ISAuthOrize !="")
        {
            if (Tble != 12)
            {
                if (Tble != 3 && Tble != 4 && Tble != 1 && Tble != 2)
                {
                    if (Term >= yeardiffe && (ddllife.SelectedIndex > 0) && (ddlmethod.SelectedIndex > 0) && (ddlpolst.SelectedIndex > 0) & (ddlcvofr.SelectedIndex > 0))
                    {
                        if (ISAuthOrize == "false")
                        {
                            #region --------------------Insert Data before Authorize-------------

                            if (txtcomdat.Text.Length == 8 && SumAss > 0 && Premium > 0 && Tble > 0 && Term > 0 && CommDate > 0 && DeathDate > 0 && Nexteffdt > 0)
                            {
                                try
                                {
                                    if (ddlpolst.SelectedIndex == 1)
                                    { polstat = "I"; }
                                    else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }

                                    if (ddllife.SelectedIndex == 1) { MOS = "M"; }
                                    if (ddllife.SelectedIndex == 2) { MOS = "S"; }
                                    if (ddllife.SelectedIndex == 3) { MOS = "2"; }
                                    if (ddllife.SelectedIndex == 4) { MOS = "C"; }

                                    if (ddlmethod.SelectedIndex == 1) { MethodInf = "COUN"; }
                                    if (ddlmethod.SelectedIndex == 2) { MethodInf = "MAIL"; }
                                    if (ddlmethod.SelectedIndex == 3) { MethodInf = "CALL"; }

                                    if (ddlcvofr.SelectedIndex > 0)
                                    {
                                        if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                                        if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                                        if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                                        if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                                        if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                                        if (ddlcvofr.SelectedIndex == 6) { civilorforces = "B"; }
                                    }
                                    string loansql = "select lmlon as Loan_Number,lmitr from lphs.lplmast where lmpol=" + Polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                                    if (dm.existRecored(loansql) != 0)
                                    {
                                        dm.readSql(loansql);
                                        OracleDataReader rd1 = dm.oraComm.ExecuteReader();
                                        while (rd1.Read())
                                        {
                                            if (!rd1.IsDBNull(0)) { LoanNum = rd1.GetInt32(0); } else { LoanNum = 0; }
                                            if (!rd1.IsDBNull(0)) { loanint_rate = rd1.GetDouble(1); } else { loanint_rate = 0.0; }
                                        }
                                        rd1.Close();
                                        loanCapital = double.Parse(hdflncap.Value);
                                        loaninterest = double.Parse(lnintrst.Value);
                                        lnGrntDate = lngrndt.Value;
                                    }
                                    lnGrntDate = "0";

                                    dm.begintransaction();

                                    #region Insert to dthout Temp table
                                    string Getdthtemp = "select * from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                                    if (dm.existRecored(Getdthtemp) == 0)
                                    {
                                        string InsertToDthoutTemp = "INSERT INTO LPHS.dthout_temp(POLNO,CLMNO,PCODE,PROPNO,STA,INTIAL,SUR,AD1,AD2,AD3,AD4," +
                                                                "IDN,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,MOS,INFODAT," +
                                                                "POLST,NOD,DTOFDTH,MOINF,IID,INAME,IAD1,IAD2,IAD3,IAD4,ITEL,INFOREL,EPF,ENTDATE,ENRTYIP,REF_TBL,PRM,DUE," +
                                                                "PAC,AGT,ORG,PHTYPE,SP_FULLNAME,SP_DOB,CHLD_FULLNAME,CHLD_DOB,SP_SURNAME,CHLD_SURNAME,LOANCAP,LOANINTST," +
                                                                "BACKINTST,LOANNUM,LNGRANTDT,BONSURRYN,BONSURRYR,POLICYCATGRY)" +
                                                                "VALUES (" + Polno + "," + ClaimNo + ",'P'," + PropNo + ",'" + txtst.Text + "','" + txtint.Text + "'" +
                                                                ",'" + txtsur.Text + "','" + PrepareApostrophe(txtadd1.Text) + "','" + PrepareApostrophe(txtadd2.Text) + "','" + PrepareApostrophe(txtadd3.Text) + "','" + PrepareApostrophe(txtadd4.Text) + "','" + txtid.Text + "'" +
                                                                "," + CommDate + "," + Tble + "," + Term + "," + SumAss + "," + Mode + "," + Grossclm + "," + NetClm + "," + int.Parse(hdfbrn.Value) + "," +
                                                                "'" + TraCode + "','" + mos + "'," + InfDate + ",'" + polstat + "','" + Nod + "'," + DeathDate + ",'" + MethodInf + "'," +
                                                                "'" + txtinfID.Text + "','" + txtinfname.Text + "','" + PrepareApostrophe(txtinfadd1.Text) + "','" + PrepareApostrophe(txtinfadd2.Text) + "','" + PrepareApostrophe(txtinfadd3.Text) + "'," +
                                                                "'" + PrepareApostrophe(txtinfadd4.Text) + "','" + txtinftel.Text + "','" + txtinfrel.Text + "','" + entEPF + "'," + int.Parse(EntryDate) + ",'" + EntryIP + "'," +
                                                                "'" + ViewState["Reftbl"].ToString() + "'," + Premium + "," + Nexteffdt + "," + PACode + "," + AgtCode + "," + OrgCode + ",'D','" + Fullname + "'," + DOB + "," +
                                                                "'" + childfullname + "'," + child_dob + ",'" + Surname + "','" + childSurna + "'," + loanCapital + "," + loanint_rate + "," + loaninterest + "," + LoanNum + "," + int.Parse(lnGrntDate) + "," +
                                                                "'" + bonsuryn + "'," + bonSurrYr + ",'" + civilorforces.Trim() + "')";
                                        dm.insertRecords(InsertToDthoutTemp);
                                    }
                                    else
                                    {

                                        string UpdateDthoutTemp = "Update LPHS.dthout_temp set PROPNO=" + PropNo + ",CLMNO=" + ClaimNo + ",IDN='" + txtid.Text + "',COMDATE=" + CommDate + ",TBL=" + Tble + ",TRM=" + Term + "" +
                                                                  ",SUMASS=" + SumAss + ",LMODE=" + Mode + ",GROSSCLM=" + Grossclm + ",NETCLM=" + NetClm + ",BRANCH=" + int.Parse(hdfbrn.Value) + "," +
                                                                  "MOS='" + mos + "',INFODAT=" + InfDate + ",POLST='" + polstat + "',DTOFDTH=" + DeathDate + ",MOINF='" + MethodInf + "',IID='" + txtinfID.Text + "'" +
                                                                  ",INAME='" + txtinfname.Text + "',IAD1='" + PrepareApostrophe(txtinfadd1.Text) + "',IAD2='" + PrepareApostrophe(txtinfadd2.Text) + "',IAD3='" + PrepareApostrophe(txtinfadd3.Text) + "'" +
                                                                  ",IAD4='" + PrepareApostrophe(txtinfadd4.Text) + "',ITEL='" + txtinftel.Text + "',INFOREL='" + txtinfrel.Text + "',ENTDATE=" + int.Parse(EntryDate) + "" +
                                                                  ",PRM=" + Premium + ",DUE=" + Nexteffdt + ",PAC=" + PACode + ",AGT=" + AgtCode + ",ORG=" + OrgCode + ",SP_FULLNAME='" + Fullname + "',SP_DOB=" + DOB + "," +
                                                                  "CHLD_FULLNAME='" + childfullname + "',CHLD_DOB=" + child_dob + ",SP_SURNAME='" + Surname + "',CHLD_SURNAME='" + childSurna + "'," +
                                                                  "LOANCAP=" + loanCapital + ",LOANINTST=" + loanint_rate + ",BACKINTST=" + loaninterest + ",LOANNUM=" + LoanNum + ",LNGRANTDT=" + int.Parse(lnGrntDate) + "," +
                                                                  "BONSURRYN='" + bonsuryn + "',BONSURRYR=" + bonSurrYr + " ,POLICYCATGRY='" + civilorforces.Trim() + "' where POLNO=" + Polno + " ";
                                        dm.insertRecords(UpdateDthoutTemp);
                                    }
                                    #endregion
                                    dm.commit();
                                    dm.connClose();
                                    lblsuc.Text = "Successfully Updated ....";
                                    btn_Next.Visible = true;
                                    btnsub.Visible = false;
                                }
                                catch (Exception exc)
                                {
                                    dm.rollback();
                                    if (ddllife.SelectedIndex == 0)
                                    {
                                        lblerr.Text = "Please Select the Type of Life..";
                                    }
                                    else if (ddlmethod.SelectedIndex == 0)
                                    {
                                        lblerr.Text = "Please Select the Method of Inform..";
                                    }
                                    else if (ddlpolst.SelectedIndex == 0)
                                    {
                                        lblerr.Text = "Please Select the Policy Status..";
                                    }
                                    else
                                    {
                                        lblerr.Text = "Error Occured while inserting to Temporary Table..";
                                    }
                                    dm.connClose();
                                }
                            }
                            else
                            {
                                lblerr.Text = "Please Fill the Relevant Fileds Before Submit !!";
                                dm.connClose();
                            }
                            #endregion
                        }
                        if (ISAuthOrize == "true")
                        {
                            #region -----------Insert Data After Authorize---------------

                            string GetTracode = "select trim(TRANSCODE),trim(REF_TBL) from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                            if (dm.existRecored(GetTracode) != 0)
                            {
                                dm.readSql(GetTracode);
                                OracleDataReader reader1 = dm.oraComm.ExecuteReader();
                                while (reader1.Read())
                                {
                                    if (!reader1.IsDBNull(0)) { TraCode = reader1.GetString(0); }
                                    if (!reader1.IsDBNull(1)) { reftable = reader1.GetString(1); }

                                }
                            }
                            if ((CkBx1.Checked) && (CkBx5.Checked) && (CkBx6.Checked) && (CkBx7.Checked) && (CkBx8.Checked) && (CkBx9.Checked) && (CkBx10.Checked) && (CkBx11.Checked) && (CkBx14.Checked) && (CkBx15.Checked) && (ChBx18.Checked))
                            {
                                dm.begintransaction();
                                try
                                {
                                    //if ((reftable == "D") && ((TraCode == "A") ||( TraCode == "B")||(TraCode=="C")))
                                    //{

                                    #region Insert Into DTHINT
                                    if (ddlpolst.SelectedIndex == 1)
                                    { polstat = "I"; }
                                    else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }

                                    if (ddllife.SelectedIndex == 1) { MOS = "M"; }
                                    if (ddllife.SelectedIndex == 2) { MOS = "S"; }
                                    if (ddllife.SelectedIndex == 3) { MOS = "2"; }
                                    if (ddllife.SelectedIndex == 4) { MOS = "C"; }

                                    if (ddlmethod.SelectedIndex == 1) { MethodInf = "COUN"; }
                                    if (ddlmethod.SelectedIndex == 2) { MethodInf = "MAIL"; }
                                    if (ddlmethod.SelectedIndex == 3) { MethodInf = "CALL"; }

                                    if (ddlcvofr.SelectedIndex > 0)
                                    {
                                        if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                                        if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                                        if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                                        if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                                        if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                                        if (ddlcvofr.SelectedIndex == 6) { civilorforces = "B"; }
                                    }
                                    string GetDthint = "select * from lphs.dthint where DPOLNO=" + int.Parse(litpolno.Text) + "  and DMOS='" + MOS + "'";
                                    if (dm.existRecored(GetDthint) == 0)
                                    {
                                        string InsertToDTHINT = "INSERT INTO LPHS.DTHINT(DPOLNO,DMOS,DCLM,DINFODAT,DPOLST,DNOD,DDTOFDTH,DMOINF,DIID,DINAME,DIAD1,DIAD2,DIAD3,DIAD4" +
                                                                ",DITEL,DUPDEPF,DUPDBRN,DUPDDATE,DINFOREL,DCONFST,DSTA,DCONFDAT,DCONFIP,DCONFBR,DCONFTIME,DCOF)" +
                                                                "VALUES (" + Polno + ",'" + MOS + "'," + ClaimNo + "," + InfDate + ",'" + polstat + "','" + Nod + "'" +
                                                                "," + DeathDate + ",'" + MethodInf + "','" + txtinfID.Text + "','" + txtinfname.Text + "','" + PrepareApostrophe(txtinfadd1.Text) + "','" + PrepareApostrophe(txtinfadd2.Text) + "'," +
                                                                "'" + PrepareApostrophe(txtinfadd3.Text) + "','" + PrepareApostrophe(txtinfadd4.Text) + "','" + txtinftel.Text + "','" + entEPF + "'," +
                                                                "" + BRN + "," + int.Parse(EntryDate) + ",'" + txtinfrel.Text + "','Y','2'," + setDate()[0] + ",'" + EntryIP + "'," + BRN + "," +
                                                                "'" + setDate()[1] + "','" + civilorforces.Trim() + "')";
                                        dm.insertRecords(InsertToDTHINT);
                                    }
                                    else
                                    {
                                        string UpdateDthInt = "Update lphs.dthint set DINFODAT=" + InfDate + ",DPOLST='" + polstat + "',DNOD='" + Nod + "',DDTOFDTH=" + DeathDate + "" +
                                                              ",DMOINF='" + MethodInf + "',DIID='" + txtinfID.Text + "',DINAME='" + txtinfname.Text + "',DIAD1='" + PrepareApostrophe(txtinfadd1.Text) + "'" +
                                                              ",DIAD2='" + PrepareApostrophe(txtinfadd2.Text) + "',DIAD3='" + PrepareApostrophe(txtinfadd3.Text) + "',DIAD4='" + PrepareApostrophe(txtinfadd4.Text) + "'" +
                                                              ",DITEL='" + txtinftel.Text + "',DINFOREL='" + txtinfrel.Text + "',DSTA=2,DCONFST='Y',DCONFDAT=" + setDate()[0] + ",DCONFIP='" + EntryIP + "'," +
                                                              "DCONFBR=" + BRN + ",DCONFTIME='" + setDate()[1] + "' where DPOLNO=" + int.Parse(litpolno.Text) + " ";
                                        dm.insertRecords(UpdateDthInt);
                                    }
                                    #endregion

                                    #region INSERT INTO LPOLHIS TABLE

                                    string GetLPOLHIS = "select * from lphs.LPOLHIS where PHPOL=" + int.Parse(litpolno.Text) + "";
                                    if (dm.existRecored(GetLPOLHIS) == 0)
                                    {
                                        string InsertToLPOLHIS = "INSERT INTO LPHS.LPOLHIS(PHCOD,PHPOL,PHCOM,PHTBL,PHTRM,PHSUM,PHMOD,PHPRM,PHDUE,PHPAC,PHAGT,PHORG,PHBRN,PHTYP" +
                                                                ",PHENT,PHEPF,PHIP,PHSTA,PHMOS,PHDATEOFINTIM,PHCLAIM)" +
                                                                "VALUES ('P'," + Polno + "," + CommDate + "," + Tble + "," + Term + "," + SumAss + "" +
                                                                "," + Mode + "," + Premium + "," + Nexteffdt + "," + PACode + "," + AgtCode + "," + OrgCode + "," +
                                                                "" + int.Parse(hdfbrn.Value) + ",'D'," + int.Parse(EntryDate) + ",'" + entEPF + "','" + EntryIP + "','" + polstat + "','" + MOS + "'," + InfDate + ",'" + ClaimNo + "')";
                                        dm.insertRecords(InsertToLPOLHIS);

                                    }
                                    #endregion



                                    if (Tble == 34 || Tble == 38 || Tble == 39 || Tble == 46 || Tble == 49)
                                    {
                                        #region Update Polpersonal Table
                                        string Updatepolpersonal = "";
                                        string CheckChldcvr = "select * from lund.polpersonal where PRPERTYPE=4 and POLNO=" + Polno + "";
                                        if (dm.existRecored(CheckChldcvr) != 0)
                                        {
                                            Updatepolpersonal = "update lund.polpersonal set SURNAME='" + childSurna + "',FULLNAME='" + childfullname + "',DOB=" + child_dob + ", ENTERED_MODE=9 where PRPERTYPE=4 and POLNO=" + Polno + " ";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        else
                                        {
                                            Updatepolpersonal = "insert into lund.polpersonal(PRPERTYPE,POLNO,SURNAME,FULLNAME,DOB,ENTERED_MODE) values(4," + Polno + ",'" + childSurna + "','" + childfullname + "'," + child_dob + ",9)";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        string Checkspousecvr = "select * from lund.rcover where RCOVR=4 and RPOL=" + Polno + "";
                                        if (dm.existRecored(Checkspousecvr) != 0)
                                        {
                                            Updatepolpersonal = "update lund.rcover set RCOMDAT=" + CommDate + " where RCOVR=4 and RPOL=" + Polno + " ";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        else
                                        {
                                            Updatepolpersonal = "insert into lund.rcover(RPOL,RCOVR,RCOMDAT,RSUMAS,RMODE,RTERM,RPRM,RRATE,ROEX,RHEX,RDISCON,ENTERED_MODE)" +
                                                                " values(" + Polno + ",4," + CommDate + ","+SumAss+","+Mode+","+Term+",0,'N','N','N','N',9) ";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        #endregion
                                    }

                                    #region Delete record from Premast/Lapse
                                    string Checkpremas = "select * from lphs.premast where pmpol=" + int.Parse(litpolno.Text) + "";
                                    string CheckLapse = "select * from lphs.liflaps where  LPPOL=" + int.Parse(litpolno.Text) + "";
                                    if (dm.existRecored(Checkpremas) != 0)
                                    {
                                        string DelTemp = "delete from lphs.premast where pmpol=" + int.Parse(litpolno.Text) + "";
                                        dm.DeleteRecords(DelTemp);
                                    }
                                    else if (dm.existRecored(CheckLapse) != 0)
                                    {
                                        string DelTemp = "delete from lphs.liflaps where LPPOL=" + int.Parse(litpolno.Text) + "";
                                        dm.DeleteRecords(DelTemp);
                                    }
                                    #endregion
                                    //}              
                                    dm.commit(); //UNCOMMENT BY chandana 2012906
                                    //dm.rollback();
                                    dm.oraComm.Connection.Close();
                                    lblsuc.Text = "Successfully Updated Authorized Data....";
                                    btnsub.Enabled = false;
                                    btn_Next.Visible = true;
                                }
                                catch
                                {
                                    lblerr.Text = "Error while inserting Data into Database...";
                                    dm.rollback();
                                    dm.oraComm.Connection.Close();
                                }
                            }
                            else
                            {
                                lblerr.Text = "Please Check Data Before Submitting..";
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        if (defprms != 0)
                        {
                            lblerr.Text = "This Policy remains the above demands.Please Settle It....";
                        }
                        if (ddllife.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please Select the Type of Life..";
                        }
                        else if (ddlmethod.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please Select the Method of Inform..";
                        }
                        else if (ddlpolst.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please Select the Policy Status..";
                        }
                        else if (ddlcvofr.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please select whether the policy belonging to Civil or Forces..";
                        }
                    }
                }
                else
                {
                    if ( (ddllife.SelectedIndex > 0) && (ddlmethod.SelectedIndex > 0) && (ddlpolst.SelectedIndex > 0) & (ddlcvofr.SelectedIndex > 0))
                    {
                        if (ISAuthOrize == "false")
                        {
                            #region --------------------Insert Data before Authorize-------------

                            if (txtcomdat.Text.Length == 8 && SumAss > 0 && Premium > 0 && Tble > 0  && CommDate > 0 && DeathDate > 0 && Nexteffdt > 0)//&& Term > 0
                            {
                                try
                                {
                                    if (ddlpolst.SelectedIndex == 1)
                                    { polstat = "I"; }
                                    else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }

                                    if (ddllife.SelectedIndex == 1) { MOS = "M"; }
                                    if (ddllife.SelectedIndex == 2) { MOS = "S"; }
                                    if (ddllife.SelectedIndex == 3) { MOS = "2"; }
                                    if (ddllife.SelectedIndex == 4) { MOS = "C"; }

                                    if (ddlmethod.SelectedIndex == 1) { MethodInf = "COUN"; }
                                    if (ddlmethod.SelectedIndex == 2) { MethodInf = "MAIL"; }
                                    if (ddlmethod.SelectedIndex == 3) { MethodInf = "CALL"; }

                                    if (ddlcvofr.SelectedIndex > 0)
                                    {
                                        if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                                        if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                                        if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                                        if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                                        if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                                        if (ddlcvofr.SelectedIndex == 6) { civilorforces = "B"; }
                                    }
                                    string loansql = "select lmlon as Loan_Number,lmitr from lphs.lplmast where lmpol=" + Polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                                    if (dm.existRecored(loansql) != 0)
                                    {
                                        dm.readSql(loansql);
                                        OracleDataReader rd1 = dm.oraComm.ExecuteReader();
                                        while (rd1.Read())
                                        {
                                            if (!rd1.IsDBNull(0)) { LoanNum = rd1.GetInt32(0); } else { LoanNum = 0; }
                                            if (!rd1.IsDBNull(0)) { loanint_rate = rd1.GetDouble(1); } else { loanint_rate = 0.0; }
                                        }
                                        rd1.Close();
                                        loanCapital = double.Parse(hdflncap.Value);
                                        loaninterest = double.Parse(lnintrst.Value);
                                        lnGrntDate = lngrndt.Value;
                                    }
                                    lnGrntDate = "0";

                                    dm.begintransaction();

                                    #region Insert to dthout Temp table
                                    string Getdthtemp = "select * from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                                    if (dm.existRecored(Getdthtemp) == 0)
                                    {
                                        string InsertToDthoutTemp = "INSERT INTO LPHS.dthout_temp(POLNO,CLMNO,PCODE,PROPNO,STA,INTIAL,SUR,AD1,AD2,AD3,AD4," +
                                                                "IDN,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,MOS,INFODAT," +
                                                                "POLST,NOD,DTOFDTH,MOINF,IID,INAME,IAD1,IAD2,IAD3,IAD4,ITEL,INFOREL,EPF,ENTDATE,ENRTYIP,REF_TBL,PRM,DUE," +
                                                                "PAC,AGT,ORG,PHTYPE,SP_FULLNAME,SP_DOB,CHLD_FULLNAME,CHLD_DOB,SP_SURNAME,CHLD_SURNAME,LOANCAP,LOANINTST," +
                                                                "BACKINTST,LOANNUM,LNGRANTDT,BONSURRYN,BONSURRYR,POLICYCATGRY)" +
                                                                "VALUES (" + Polno + "," + ClaimNo + ",'P'," + PropNo + ",'" + txtst.Text + "','" + txtint.Text + "'" +
                                                                ",'" + txtsur.Text + "','" + PrepareApostrophe(txtadd1.Text) + "','" + PrepareApostrophe(txtadd2.Text) + "','" + PrepareApostrophe(txtadd3.Text) + "','" + PrepareApostrophe(txtadd4.Text) + "','" + txtid.Text + "'" +
                                                                "," + CommDate + "," + Tble + "," + Term + "," + SumAss + "," + Mode + "," + Grossclm + "," + NetClm + "," + int.Parse(hdfbrn.Value) + "," +
                                                                "'" + TraCode + "','" + mos + "'," + InfDate + ",'" + polstat + "','" + Nod + "'," + DeathDate + ",'" + MethodInf + "'," +
                                                                "'" + txtinfID.Text + "','" + txtinfname.Text + "','" + PrepareApostrophe(txtinfadd1.Text) + "','" + PrepareApostrophe(txtinfadd2.Text) + "','" + PrepareApostrophe(txtinfadd3.Text) + "'," +
                                                                "'" + PrepareApostrophe(txtinfadd4.Text) + "','" + txtinftel.Text + "','" + txtinfrel.Text + "','" + entEPF + "'," + int.Parse(EntryDate) + ",'" + EntryIP + "'," +
                                                                "'" + ViewState["Reftbl"].ToString() + "'," + Premium + "," + Nexteffdt + "," + PACode + "," + AgtCode + "," + OrgCode + ",'D','" + Fullname + "'," + DOB + "," +
                                                                "'" + childfullname + "'," + child_dob + ",'" + Surname + "','" + childSurna + "'," + loanCapital + "," + loanint_rate + "," + loaninterest + "," + LoanNum + "," + int.Parse(lnGrntDate) + "," +
                                                                "'" + bonsuryn + "'," + bonSurrYr + ",'" + civilorforces.Trim() + "')";
                                        dm.insertRecords(InsertToDthoutTemp);
                                    }
                                    else
                                    {

                                        string UpdateDthoutTemp = "Update LPHS.dthout_temp set PROPNO=" + PropNo + ",CLMNO=" + ClaimNo + ",IDN='" + txtid.Text + "',COMDATE=" + CommDate + ",TBL=" + Tble + ",TRM=" + Term + "" +
                                                                  ",SUMASS=" + SumAss + ",LMODE=" + Mode + ",GROSSCLM=" + Grossclm + ",NETCLM=" + NetClm + ",BRANCH=" + int.Parse(hdfbrn.Value) + "," +
                                                                  "MOS='" + mos + "',INFODAT=" + InfDate + ",POLST='" + polstat + "',DTOFDTH=" + DeathDate + ",MOINF='" + MethodInf + "',IID='" + txtinfID.Text + "'" +
                                                                  ",INAME='" + txtinfname.Text + "',IAD1='" + PrepareApostrophe(txtinfadd1.Text) + "',IAD2='" + PrepareApostrophe(txtinfadd2.Text) + "',IAD3='" + PrepareApostrophe(txtinfadd3.Text) + "'" +
                                                                  ",IAD4='" + PrepareApostrophe(txtinfadd4.Text) + "',ITEL='" + txtinftel.Text + "',INFOREL='" + txtinfrel.Text + "',ENTDATE=" + int.Parse(EntryDate) + "" +
                                                                  ",PRM=" + Premium + ",DUE=" + Nexteffdt + ",PAC=" + PACode + ",AGT=" + AgtCode + ",ORG=" + OrgCode + ",SP_FULLNAME='" + Fullname + "',SP_DOB=" + DOB + "," +
                                                                  "CHLD_FULLNAME='" + childfullname + "',CHLD_DOB=" + child_dob + ",SP_SURNAME='" + Surname + "',CHLD_SURNAME='" + childSurna + "'," +
                                                                  "LOANCAP=" + loanCapital + ",LOANINTST=" + loanint_rate + ",BACKINTST=" + loaninterest + ",LOANNUM=" + LoanNum + ",LNGRANTDT=" + int.Parse(lnGrntDate) + "," +
                                                                  "BONSURRYN='" + bonsuryn + "',BONSURRYR=" + bonSurrYr + " ,POLICYCATGRY='" + civilorforces.Trim() + "' where POLNO=" + Polno + " ";
                                        dm.insertRecords(UpdateDthoutTemp);
                                    }
                                    #endregion
                                    dm.commit();
                                    dm.connClose();
                                    lblsuc.Text = "Successfully Updated ....";
                                    btn_Next.Visible = true;
                                    btnsub.Visible = false;
                                }
                                catch (Exception exc)
                                {
                                    dm.rollback();
                                    if (ddllife.SelectedIndex == 0)
                                    {
                                        lblerr.Text = "Please Select the Type of Life..";
                                    }
                                    else if (ddlmethod.SelectedIndex == 0)
                                    {
                                        lblerr.Text = "Please Select the Method of Inform..";
                                    }
                                    else if (ddlpolst.SelectedIndex == 0)
                                    {
                                        lblerr.Text = "Please Select the Policy Status..";
                                    }
                                    else
                                    {
                                        lblerr.Text = "Error Occured while inserting to Temporary Table..";
                                    }
                                    dm.connClose();
                                }
                            }
                            else
                            {
                                lblerr.Text = "Please Fill the Relevant Fileds Before Submit !!";
                                dm.connClose();
                            }
                            #endregion
                        }
                        if (ISAuthOrize == "true")
                        {
                            #region -----------Insert Data After Authorize---------------

                            string GetTracode = "select trim(TRANSCODE),trim(REF_TBL) from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                            if (dm.existRecored(GetTracode) != 0)
                            {
                                dm.readSql(GetTracode);
                                OracleDataReader reader1 = dm.oraComm.ExecuteReader();
                                while (reader1.Read())
                                {
                                    if (!reader1.IsDBNull(0)) { TraCode = reader1.GetString(0); }
                                    if (!reader1.IsDBNull(1)) { reftable = reader1.GetString(1); }

                                }
                            }
                            if ((CkBx1.Checked) && (CkBx5.Checked) && (CkBx6.Checked) && (CkBx7.Checked) && (CkBx8.Checked) && (CkBx9.Checked) && (CkBx10.Checked) && (CkBx11.Checked) && (CkBx14.Checked) && (CkBx15.Checked) && (ChBx18.Checked))
                            {
                                dm.begintransaction();
                                try
                                {
                                    //if ((reftable == "D") && ((TraCode == "A") ||( TraCode == "B")||(TraCode=="C")))
                                    //{

                                    #region Insert Into DTHINT
                                    if (ddlpolst.SelectedIndex == 1)
                                    { polstat = "I"; }
                                    else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }

                                    if (ddllife.SelectedIndex == 1) { MOS = "M"; }
                                    if (ddllife.SelectedIndex == 2) { MOS = "S"; }
                                    if (ddllife.SelectedIndex == 3) { MOS = "2"; }
                                    if (ddllife.SelectedIndex == 4) { MOS = "C"; }

                                    if (ddlmethod.SelectedIndex == 1) { MethodInf = "COUN"; }
                                    if (ddlmethod.SelectedIndex == 2) { MethodInf = "MAIL"; }
                                    if (ddlmethod.SelectedIndex == 3) { MethodInf = "CALL"; }

                                    if (ddlcvofr.SelectedIndex > 0)
                                    {
                                        if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                                        if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                                        if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                                        if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                                        if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                                        if (ddlcvofr.SelectedIndex == 4) { civilorforces = "B"; }

                                    }
                                    string GetDthint = "select * from lphs.dthint where DPOLNO=" + int.Parse(litpolno.Text) + "  and DMOS='" + MOS + "'";
                                    if (dm.existRecored(GetDthint) == 0)
                                    {
                                        string InsertToDTHINT = "INSERT INTO LPHS.DTHINT(DPOLNO,DMOS,DCLM,DINFODAT,DPOLST,DNOD,DDTOFDTH,DMOINF,DIID,DINAME,DIAD1,DIAD2,DIAD3,DIAD4" +
                                                                ",DITEL,DUPDEPF,DUPDBRN,DUPDDATE,DINFOREL,DCONFST,DSTA,DCONFDAT,DCONFIP,DCONFBR,DCONFTIME,DCOF)" +
                                                                "VALUES (" + Polno + ",'" + MOS + "'," + ClaimNo + "," + InfDate + ",'" + polstat + "','" + Nod + "'" +
                                                                "," + DeathDate + ",'" + MethodInf + "','" + txtinfID.Text + "','" + txtinfname.Text + "','" + PrepareApostrophe(txtinfadd1.Text) + "','" + PrepareApostrophe(txtinfadd2.Text) + "'," +
                                                                "'" + PrepareApostrophe(txtinfadd3.Text) + "','" + PrepareApostrophe(txtinfadd4.Text) + "','" + txtinftel.Text + "','" + entEPF + "'," +
                                                                "" + BRN + "," + int.Parse(EntryDate) + ",'" + txtinfrel.Text + "','Y','2'," + setDate()[0] + ",'" + EntryIP + "'," + BRN + "," +
                                                                "'" + setDate()[1] + "','" + civilorforces.Trim() + "')";
                                        dm.insertRecords(InsertToDTHINT);
                                    }
                                    else
                                    {
                                        string UpdateDthInt = "Update lphs.dthint set DINFODAT=" + InfDate + ",DPOLST='" + polstat + "',DNOD='" + Nod + "',DDTOFDTH=" + DeathDate + "" +
                                                              ",DMOINF='" + MethodInf + "',DIID='" + txtinfID.Text + "',DINAME='" + txtinfname.Text + "',DIAD1='" + PrepareApostrophe(txtinfadd1.Text) + "'" +
                                                              ",DIAD2='" + PrepareApostrophe(txtinfadd2.Text) + "',DIAD3='" + PrepareApostrophe(txtinfadd3.Text) + "',DIAD4='" + PrepareApostrophe(txtinfadd4.Text) + "'" +
                                                              ",DITEL='" + txtinftel.Text + "',DINFOREL='" + txtinfrel.Text + "',DSTA=2,DCONFST='Y',DCONFDAT=" + setDate()[0] + ",DCONFIP='" + EntryIP + "'," +
                                                              "DCONFBR=" + BRN + ",DCONFTIME='" + setDate()[1] + "' where DPOLNO=" + int.Parse(litpolno.Text) + " ";
                                        dm.insertRecords(UpdateDthInt);
                                    }
                                    #endregion

                                    #region INSERT INTO LPOLHIS TABLE

                                    string GetLPOLHIS = "select * from lphs.LPOLHIS where PHPOL=" + int.Parse(litpolno.Text) + "";
                                    if (dm.existRecored(GetLPOLHIS) == 0)
                                    {
                                        string InsertToLPOLHIS = "INSERT INTO LPHS.LPOLHIS(PHCOD,PHPOL,PHCOM,PHTBL,PHTRM,PHSUM,PHMOD,PHPRM,PHDUE,PHPAC,PHAGT,PHORG,PHBRN,PHTYP" +
                                                                ",PHENT,PHEPF,PHIP,PHSTA,PHMOS,PHDATEOFINTIM,PHCLAIM)" +
                                                                "VALUES ('P'," + Polno + "," + CommDate + "," + Tble + "," + Term + "," + SumAss + "" +
                                                                "," + Mode + "," + Premium + "," + Nexteffdt + "," + PACode + "," + AgtCode + "," + OrgCode + "," +
                                                                "" + int.Parse(hdfbrn.Value) + ",'D'," + int.Parse(EntryDate) + ",'" + entEPF + "','" + EntryIP + "','" + polstat + "','" + MOS + "'," + InfDate + ",'" + ClaimNo + "')";
                                        dm.insertRecords(InsertToLPOLHIS);

                                    }
                                    #endregion



                                    if (Tble == 34 || Tble == 38 || Tble == 39 || Tble == 46 || Tble == 49)
                                    {
                                        #region Update Polpersonal Table
                                        string Updatepolpersonal = "";
                                        string CheckChldcvr = "select * from lund.polpersonal where PRPERTYPE=4 and POLNO=" + Polno + "";
                                        if (dm.existRecored(CheckChldcvr) != 0)
                                        {
                                            Updatepolpersonal = "update lund.polpersonal set SURNAME='" + childSurna + "',FULLNAME='" + childfullname + "',DOB=" + child_dob + ", ENTERED_MODE=9 where PRPERTYPE=4 and POLNO=" + Polno + " ";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        else
                                        {
                                            Updatepolpersonal = "insert into lund.polpersonal(PRPERTYPE,POLNO,SURNAME,FULLNAME,DOB,ENTERED_MODE) values(4," + Polno + ",'" + childSurna + "','" + childfullname + "'," + child_dob + ",9)";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        string Checkspousecvr = "select * from lund.rcover where RCOVR=4 and RPOL=" + Polno + "";
                                        if (dm.existRecored(Checkspousecvr) != 0)
                                        {
                                            Updatepolpersonal = "update lund.rcover set RCOMDAT=" + CommDate + " where RCOVR=4 and RPOL=" + Polno + " ";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        else
                                        {
                                            Updatepolpersonal = "insert into lund.rcover(RPOL,RCOVR,RCOMDAT,ENTERED_MODE)values(" + Polno + ",4," + CommDate + ",9) ";
                                            dm.insertRecords(Updatepolpersonal);
                                        }
                                        #endregion
                                    }

                                    #region Delete record from Premast/Lapse
                                    string Checkpremas = "select * from lphs.premast where pmpol=" + int.Parse(litpolno.Text) + "";
                                    string CheckLapse = "select * from lphs.liflaps where  LPPOL=" + int.Parse(litpolno.Text) + "";
                                    if (dm.existRecored(Checkpremas) != 0)
                                    {
                                        string DelTemp = "delete from lphs.premast where pmpol=" + int.Parse(litpolno.Text) + "";
                                        dm.DeleteRecords(DelTemp);
                                    }
                                    else if (dm.existRecored(CheckLapse) != 0)
                                    {
                                        string DelTemp = "delete from lphs.liflaps where LPPOL=" + int.Parse(litpolno.Text) + "";
                                        dm.DeleteRecords(DelTemp);
                                    }
                                    #endregion
                                    //}              
                                    dm.commit();
                                    dm.oraComm.Connection.Close();
                                    lblsuc.Text = "Successfully Updated Authorized Data....";
                                    btnsub.Enabled = false;
                                    btn_Next.Visible = true;
                                }
                                catch
                                {
                                    lblerr.Text = "Error while inserting Data into Database...";
                                    dm.rollback();
                                    dm.oraComm.Connection.Close();
                                }
                            }
                            else
                            {
                                lblerr.Text = "Please Check Data Before Submitting..";
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        if (defprms != 0)
                        {
                            lblerr.Text = "This Policy remains the above demands.Please Settle It....";
                        }
                        if (ddllife.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please Select the Type of Life..";
                        }
                        else if (ddlmethod.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please Select the Method of Inform..";
                        }
                        else if (ddlpolst.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please Select the Policy Status..";
                        }
                        else if (ddlcvofr.SelectedIndex == 0)
                        {
                            lblerr.Text = "Please select whether the policy belonging to Civil or Forces..";
                        }
                    }
                }
            }
            else if (Tble == 12 )
            {
                if ((ddllife.SelectedIndex > 0) && (ddlmethod.SelectedIndex > 0) && (ddlpolst.SelectedIndex > 0) & (ddlcvofr.SelectedIndex > 0))
                {
                    if (ISAuthOrize == "false")
                    {
                        #region --------------------Insert Data before Authorize-------------

                        if (txtcomdat.Text.Length == 8 && SumAss > 0 && Premium > 0 && Tble > 0 && CommDate > 0 && DeathDate > 0 && Nexteffdt > 0)
                        {
                            try
                            {
                                if (ddlpolst.SelectedIndex == 1)
                                { polstat = "I"; }
                                else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }

                                if (ddllife.SelectedIndex == 1) { MOS = "M"; }
                                if (ddllife.SelectedIndex == 2) { MOS = "S"; }
                                if (ddllife.SelectedIndex == 3) { MOS = "2"; }
                                if (ddllife.SelectedIndex == 4) { MOS = "C"; }

                                if (ddlmethod.SelectedIndex == 1) { MethodInf = "COUN"; }
                                if (ddlmethod.SelectedIndex == 2) { MethodInf = "MAIL"; }
                                if (ddlmethod.SelectedIndex == 3) { MethodInf = "CALL"; }

                                if (ddlcvofr.SelectedIndex > 0)
                                {
                                    if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                                    if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                                    if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                                    if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                                    if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                                    if (ddlcvofr.SelectedIndex == 6) { civilorforces = "B"; }

                                }
                                string loansql = "select lmlon as Loan_Number,lmitr from lphs.lplmast where lmpol=" + Polno + " and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                                if (dm.existRecored(loansql) != 0)
                                {
                                    dm.readSql(loansql);
                                    OracleDataReader rd1 = dm.oraComm.ExecuteReader();
                                    while (rd1.Read())
                                    {
                                        if (!rd1.IsDBNull(0)) { LoanNum = rd1.GetInt32(0); } else { LoanNum = 0; }
                                        if (!rd1.IsDBNull(0)) { loanint_rate = rd1.GetDouble(1); } else { loanint_rate = 0.0; }
                                    }
                                    rd1.Close();
                                    loanCapital = double.Parse(hdflncap.Value);
                                    loaninterest = double.Parse(lnintrst.Value);
                                    lnGrntDate = lngrndt.Value;
                                }
                                lnGrntDate = "0";

                                dm.begintransaction();

                                #region Insert to dthout Temp table
                                string Getdthtemp = "select * from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(Getdthtemp) == 0)
                                {
                                    string InsertToDthoutTemp = "INSERT INTO LPHS.dthout_temp(POLNO,CLMNO,PCODE,PROPNO,STA,INTIAL,SUR,AD1,AD2,AD3,AD4," +
                                                            "IDN,COMDATE,TBL,TRM,SUMASS,LMODE,GROSSCLM,NETCLM,BRANCH,TRANSCODE,MOS,INFODAT," +
                                                            "POLST,NOD,DTOFDTH,MOINF,IID,INAME,IAD1,IAD2,IAD3,IAD4,ITEL,INFOREL,EPF,ENTDATE,ENRTYIP,REF_TBL,PRM,DUE," +
                                                            "PAC,AGT,ORG,PHTYPE,SP_FULLNAME,SP_DOB,CHLD_FULLNAME,CHLD_DOB,SP_SURNAME,CHLD_SURNAME,LOANCAP,LOANINTST," +
                                                            "BACKINTST,LOANNUM,LNGRANTDT,BONSURRYN,BONSURRYR,POLICYCATGRY)" +
                                                            "VALUES (" + Polno + "," + ClaimNo + ",'P'," + PropNo + ",'" + txtst.Text + "','" + txtint.Text + "'" +
                                                            ",'" + txtsur.Text + "','" + PrepareApostrophe(txtadd1.Text) + "','" + PrepareApostrophe(txtadd2.Text) + "','" + PrepareApostrophe(txtadd3.Text) + "','" + PrepareApostrophe(txtadd4.Text) + "','" + txtid.Text + "'" +
                                                            "," + CommDate + "," + Tble + "," + Term + "," + SumAss + "," + Mode + "," + Grossclm + "," + NetClm + "," + int.Parse(hdfbrn.Value) + "," +
                                                            "'" + TraCode + "','" + mos + "'," + InfDate + ",'" + polstat + "','" + Nod + "'," + DeathDate + ",'" + MethodInf + "'," +
                                                            "'" + txtinfID.Text + "','" + txtinfname.Text + "','" + PrepareApostrophe(txtinfadd1.Text) + "','" + PrepareApostrophe(txtinfadd2.Text) + "','" + PrepareApostrophe(txtinfadd3.Text) + "'," +
                                                            "'" + PrepareApostrophe(txtinfadd4.Text) + "','" + txtinftel.Text + "','" + txtinfrel.Text + "','" + entEPF + "'," + int.Parse(EntryDate) + ",'" + EntryIP + "'," +
                                                            "'" + ViewState["Reftbl"].ToString() + "'," + Premium + "," + Nexteffdt + "," + PACode + "," + AgtCode + "," + OrgCode + ",'D','" + Fullname + "'," + DOB + "," +
                                                            "'" + childfullname + "'," + child_dob + ",'" + Surname + "','" + childSurna + "'," + loanCapital + "," + loanint_rate + "," + loaninterest + "," + LoanNum + "," + int.Parse(lnGrntDate) + "," +
                                                            "'" + bonsuryn + "'," + bonSurrYr + ",'" + civilorforces.Trim() + "')";
                                    dm.insertRecords(InsertToDthoutTemp);
                                }
                                else
                                {

                                    string UpdateDthoutTemp = "Update LPHS.dthout_temp set PROPNO=" + PropNo + ",CLMNO=" + ClaimNo + ",IDN='" + txtid.Text + "',COMDATE=" + CommDate + ",TBL=" + Tble + ",TRM=" + Term + "" +
                                                              ",SUMASS=" + SumAss + ",LMODE=" + Mode + ",GROSSCLM=" + Grossclm + ",NETCLM=" + NetClm + ",BRANCH=" + int.Parse(hdfbrn.Value) + "," +
                                                              "MOS='" + mos + "',INFODAT=" + InfDate + ",POLST='" + polstat + "',DTOFDTH=" + DeathDate + ",MOINF='" + MethodInf + "',IID='" + txtinfID.Text + "'" +
                                                              ",INAME='" + txtinfname.Text + "',IAD1='" + PrepareApostrophe(txtinfadd1.Text) + "',IAD2='" + PrepareApostrophe(txtinfadd2.Text) + "',IAD3='" + PrepareApostrophe(txtinfadd3.Text) + "'" +
                                                              ",IAD4='" + PrepareApostrophe(txtinfadd4.Text) + "',ITEL='" + txtinftel.Text + "',INFOREL='" + txtinfrel.Text + "',ENTDATE=" + int.Parse(EntryDate) + "" +
                                                              ",PRM=" + Premium + ",DUE=" + Nexteffdt + ",PAC=" + PACode + ",AGT=" + AgtCode + ",ORG=" + OrgCode + ",SP_FULLNAME='" + Fullname + "',SP_DOB=" + DOB + "," +
                                                              "CHLD_FULLNAME='" + childfullname + "',CHLD_DOB=" + child_dob + ",SP_SURNAME='" + Surname + "',CHLD_SURNAME='" + childSurna + "'," +
                                                              "LOANCAP=" + loanCapital + ",LOANINTST=" + loanint_rate + ",BACKINTST=" + loaninterest + ",LOANNUM=" + LoanNum + ",LNGRANTDT=" + int.Parse(lnGrntDate) + "," +
                                                              "BONSURRYN='" + bonsuryn + "',BONSURRYR=" + bonSurrYr + " ,POLICYCATGRY='" + civilorforces.Trim() + "' where POLNO=" + Polno + " ";
                                    dm.insertRecords(UpdateDthoutTemp);
                                }
                                #endregion
                                dm.commit();
                                dm.connClose();
                                lblsuc.Text = "Successfully Updated ....";
                                btn_Next.Visible = true;
                                btnsub.Visible = false;
                            }
                            catch (Exception exc)
                            {
                                dm.rollback();
                                if (ddllife.SelectedIndex == 0)
                                {
                                    lblerr.Text = "Please Select the Type of Life..";
                                }
                                else if (ddlmethod.SelectedIndex == 0)
                                {
                                    lblerr.Text = "Please Select the Method of Inform..";
                                }
                                else if (ddlpolst.SelectedIndex == 0)
                                {
                                    lblerr.Text = "Please Select the Policy Status..";
                                }
                                else
                                {
                                    lblerr.Text = "Error Occured while inserting to Temporary Table..";
                                }
                                dm.connClose();
                            }
                        }
                        else
                        {
                            lblerr.Text = "Please Fill the Relevant Fileds Before Submit !!";
                            dm.connClose();
                        }
                        #endregion
                    }
                    if (ISAuthOrize == "true")
                    {
                        #region -----------Insert Data After Authorize---------------

                        string GetTracode = "select trim(TRANSCODE),trim(REF_TBL) from lphs.dthout_temp where POLNO=" + int.Parse(litpolno.Text) + "";
                        if (dm.existRecored(GetTracode) != 0)
                        {
                            dm.readSql(GetTracode);
                            OracleDataReader reader1 = dm.oraComm.ExecuteReader();
                            while (reader1.Read())
                            {
                                if (!reader1.IsDBNull(0)) { TraCode = reader1.GetString(0); }
                                if (!reader1.IsDBNull(1)) { reftable = reader1.GetString(1); }

                            }
                        }
                        if ((CkBx1.Checked) && (CkBx5.Checked) && (CkBx6.Checked) && (CkBx7.Checked) && (CkBx8.Checked) && (CkBx9.Checked) && (CkBx10.Checked) && (CkBx11.Checked) && (CkBx14.Checked) && (CkBx15.Checked) && (ChBx18.Checked))
                        {
                            dm.begintransaction();
                            try
                            {
                                //if ((reftable == "D") && ((TraCode == "A") ||( TraCode == "B")||(TraCode=="C")))
                                //{

                                #region Insert Into DTHINT
                                if (ddlpolst.SelectedIndex == 1)
                                { polstat = "I"; }
                                else if (ddlpolst.SelectedIndex == 2) { polstat = "L"; }

                                if (ddllife.SelectedIndex == 1) { MOS = "M"; }
                                if (ddllife.SelectedIndex == 2) { MOS = "S"; }
                                if (ddllife.SelectedIndex == 3) { MOS = "2"; }
                                if (ddllife.SelectedIndex == 4) { MOS = "C"; }

                                if (ddlmethod.SelectedIndex == 1) { MethodInf = "COUN"; }
                                if (ddlmethod.SelectedIndex == 2) { MethodInf = "MAIL"; }
                                if (ddlmethod.SelectedIndex == 3) { MethodInf = "CALL"; }

                                if (ddlcvofr.SelectedIndex > 0)
                                {
                                    if (ddlcvofr.SelectedIndex == 1) { civilorforces = "C"; }
                                    if (ddlcvofr.SelectedIndex == 2) { civilorforces = "A"; }
                                    if (ddlcvofr.SelectedIndex == 3) { civilorforces = "N"; }
                                    if (ddlcvofr.SelectedIndex == 4) { civilorforces = "G"; }
                                    if (ddlcvofr.SelectedIndex == 5) { civilorforces = "P"; }
                                    if (ddlcvofr.SelectedIndex == 6) { civilorforces = "B"; }

                                }
                                string GetDthint = "select * from lphs.dthint where DPOLNO=" + int.Parse(litpolno.Text) + "  and DMOS='" + MOS + "'";
                                if (dm.existRecored(GetDthint) == 0)
                                {
                                    string InsertToDTHINT = "INSERT INTO LPHS.DTHINT(DPOLNO,DMOS,DCLM,DINFODAT,DPOLST,DNOD,DDTOFDTH,DMOINF,DIID,DINAME,DIAD1,DIAD2,DIAD3,DIAD4" +
                                                            ",DITEL,DUPDEPF,DUPDBRN,DUPDDATE,DINFOREL,DCONFST,DSTA,DCONFDAT,DCONFIP,DCONFBR,DCONFTIME,DCOF)" +
                                                            "VALUES (" + Polno + ",'" + MOS + "'," + ClaimNo + "," + InfDate + ",'" + polstat + "','" + Nod + "'" +
                                                            "," + DeathDate + ",'" + MethodInf + "','" + txtinfID.Text + "','" + txtinfname.Text + "','" + PrepareApostrophe(txtinfadd1.Text) + "','" + PrepareApostrophe(txtinfadd2.Text) + "'," +
                                                            "'" + PrepareApostrophe(txtinfadd3.Text) + "','" + PrepareApostrophe(txtinfadd4.Text) + "','" + txtinftel.Text + "','" + entEPF + "'," +
                                                            "" + BRN + "," + int.Parse(EntryDate) + ",'" + txtinfrel.Text + "','Y','2'," + setDate()[0] + ",'" + EntryIP + "'," + BRN + "," +
                                                            "'" + setDate()[1] + "','" + civilorforces.Trim() + "')";
                                    dm.insertRecords(InsertToDTHINT);
                                }
                                else
                                {
                                    string UpdateDthInt = "Update lphs.dthint set DINFODAT=" + InfDate + ",DPOLST='" + polstat + "',DNOD='" + Nod + "',DDTOFDTH=" + DeathDate + "" +
                                                          ",DMOINF='" + MethodInf + "',DIID='" + txtinfID.Text + "',DINAME='" + txtinfname.Text + "',DIAD1='" + PrepareApostrophe(txtinfadd1.Text) + "'" +
                                                          ",DIAD2='" + PrepareApostrophe(txtinfadd2.Text) + "',DIAD3='" + PrepareApostrophe(txtinfadd3.Text) + "',DIAD4='" + PrepareApostrophe(txtinfadd4.Text) + "'" +
                                                          ",DITEL='" + txtinftel.Text + "',DINFOREL='" + txtinfrel.Text + "',DSTA=2,DCONFST='Y',DCONFDAT=" + setDate()[0] + ",DCONFIP='" + EntryIP + "'," +
                                                          "DCONFBR=" + BRN + ",DCONFTIME='" + setDate()[1] + "' where DPOLNO=" + int.Parse(litpolno.Text) + " ";
                                    dm.insertRecords(UpdateDthInt);
                                }
                                #endregion

                                #region INSERT INTO LPOLHIS TABLE

                                string GetLPOLHIS = "select * from lphs.LPOLHIS where PHPOL=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(GetLPOLHIS) == 0)
                                {
                                    string InsertToLPOLHIS = "INSERT INTO LPHS.LPOLHIS(PHCOD,PHPOL,PHCOM,PHTBL,PHTRM,PHSUM,PHMOD,PHPRM,PHDUE,PHPAC,PHAGT,PHORG,PHBRN,PHTYP" +
                                                            ",PHENT,PHEPF,PHIP,PHSTA,PHMOS,PHDATEOFINTIM,PHCLAIM)" +
                                                            "VALUES ('P'," + Polno + "," + CommDate + "," + Tble + "," + Term + "," + SumAss + "" +
                                                            "," + Mode + "," + Premium + "," + Nexteffdt + "," + PACode + "," + AgtCode + "," + OrgCode + "," +
                                                            "" + int.Parse(hdfbrn.Value) + ",'D'," + int.Parse(EntryDate) + ",'" + entEPF + "','" + EntryIP + "'," +
                                                            "'" + polstat + "','" + MOS + "'," + InfDate + ",'" + ClaimNo + "')";
                                    dm.insertRecords(InsertToLPOLHIS);

                                }
                                #endregion



                                if (Tble == 34 || Tble == 38 || Tble == 39 || Tble == 46 || Tble == 49)
                                {
                                    #region Update Polpersonal Table
                                    string Updatepolpersonal = "";
                                    string CheckChldcvr = "select * from lund.polpersonal where PRPERTYPE=4 and POLNO=" + Polno + "";
                                    if (dm.existRecored(CheckChldcvr) != 0)
                                    {
                                        Updatepolpersonal = "update lund.polpersonal set SURNAME='" + childSurna + "',FULLNAME='" + childfullname + "',DOB=" + child_dob + ", ENTERED_MODE=9 where PRPERTYPE=4 and POLNO=" + Polno + " ";
                                        dm.insertRecords(Updatepolpersonal);
                                    }
                                    else
                                    {
                                        Updatepolpersonal = "insert into lund.polpersonal(PRPERTYPE,POLNO,SURNAME,FULLNAME,DOB,ENTERED_MODE) values(4," + Polno + ",'" + childSurna + "','" + childfullname + "'," + child_dob + ",9)";
                                        dm.insertRecords(Updatepolpersonal);
                                    }
                                    string Checkspousecvr = "select * from lund.rcover where RCOVR=4 and RPOL=" + Polno + "";
                                    if (dm.existRecored(Checkspousecvr) != 0)
                                    {
                                        Updatepolpersonal = "update lund.rcover set RCOMDAT=" + CommDate + " where RCOVR=4 and RPOL=" + Polno + " ";
                                        dm.insertRecords(Updatepolpersonal);
                                    }
                                    else
                                    {
                                        Updatepolpersonal = "insert into lund.rcover(RPOL,RCOVR,RCOMDAT,ENTERED_MODE)values(" + Polno + ",4," + CommDate + ",9) ";
                                        dm.insertRecords(Updatepolpersonal);
                                    }
                                    #endregion
                                }

                                #region Delete record from Premast/Lapse
                                string Checkpremas = "select * from lphs.premast where pmpol=" + int.Parse(litpolno.Text) + "";
                                string CheckLapse = "select * from lphs.liflaps where  LPPOL=" + int.Parse(litpolno.Text) + "";
                                if (dm.existRecored(Checkpremas) != 0)
                                {
                                    string DelTemp = "delete from lphs.premast where pmpol=" + int.Parse(litpolno.Text) + "";
                                    dm.DeleteRecords(DelTemp);
                                }
                                else if (dm.existRecored(CheckLapse) != 0)
                                {
                                    string DelTemp = "delete from lphs.liflaps where LPPOL=" + int.Parse(litpolno.Text) + "";
                                    dm.DeleteRecords(DelTemp);
                                }
                                #endregion
                                //}              
                                dm.commit();
                                dm.oraComm.Connection.Close();
                                lblsuc.Text = "Successfully Updated Authorized Data....";
                                btnsub.Enabled = false;
                                btn_Next.Visible = true;
                            }
                            catch
                            {
                                lblerr.Text = "Error while inserting Data into Database...";
                                dm.rollback();
                                dm.oraComm.Connection.Close();
                            }
                        }
                        else
                        {
                            lblerr.Text = "Please Check Data Before Submitting..";
                        }
                        #endregion
                    }
                }
                else
                {
                    if (defprms != 0)
                    {
                        lblerr.Text = "This Policy remains the above demands.Please Settle It....";
                    }
                    if (ddllife.SelectedIndex == 0)
                    {
                        lblerr.Text = "Please Select the Type of Life..";
                    }
                    else if (ddlmethod.SelectedIndex == 0)
                    {
                        lblerr.Text = "Please Select the Method of Inform..";
                    }
                    else if (ddlpolst.SelectedIndex == 0)
                    {
                        lblerr.Text = "Please Select the Policy Status..";
                    }
                    else if (ddlcvofr.SelectedIndex == 0)
                    {
                        lblerr.Text = "Please select whether the policy belonging to Civil or Forces..";
                    }
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
        if (DropDownList1.SelectedIndex >= 0)
        {
            DataManager dm = new DataManager();
            BrCode=dm.getBranchcode(DropDownList1.Text);
            hdfbrn.Value = BrCode.ToString();
        }
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

    public int DefPremiums(int dateofdeath, int polno, int COM)
    {
        #region //****** Demmands ********

        //******** Showing Demmands ******
        int dateofdthYM = int.Parse(dateofdeath.ToString().Substring(0, 6));
        int demanddate = 0;
        double demandPrem = 0.0;
        memoApprv = "N";

        int count = 0;
        arr01 = new ArrayList();
        arr02 = new ArrayList();
        dthpayObj = new DataManager();
        string mydemandsql = "select pdcod, pddue, pdprm from LPHS.DEMAND where pdpol='" + polno + "' and " +
            "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";
        if (dthpayObj.existRecored(mydemandsql) != 0)
        {
            dthpayObj.readSql(mydemandsql);
            OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (mydemandreader01.Read())
            {
                count++;
                demanddate = mydemandreader01.GetInt32(1);
                demandPrem = mydemandreader01.GetDouble(2);
                int demanddateYMD = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2));
                if (demanddateYMD < dateofdeath)
                {
                    arr01.Add(demanddate.ToString());
                    arr02.Add(demandPrem.ToString());
                    if (count == 1)
                    {
                        this.createDemmandTable(demanddate.ToString(), count - 1, memoApprv, STA);
                        this.createDemmandTable(demanddate.ToString(), count, memoApprv, STA);
                    }
                    else { this.createDemmandTable(demanddate.ToString(), count, memoApprv, STA); }
                }
            }
            countStatic = count;
            mydemandreader01.Close();
            mydemandreader01.Dispose();
        }
        return count;

        #endregion
    }

    private void createDemmandTable(string due, int rowNumber, string payst, string polst)
    {
        try
        {
            //Table Table1 = new Table();
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            CheckBox chk01 = new CheckBox();

            lbl1.ID = "due" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "due" + rowNumber); //Text Value
            if (rowNumber == 0) { lbl1.Text = "Due"; }
            else { lbl1.Text = due; }

            //lbl2.ID = "LoanNumber" + rowNumber;
            //lbl2.Attributes.Add("runat", "Server");
            //lbl2.Attributes.Add("Name", "due" + rowNumber); //Text Value
            //lbl2.Text = "Wave Demmands?";

            //chk01.ID = "chk" + rowNumber;
            //chk01.Attributes.Add("runat", "Server");
            //chk01.Attributes.Add("Name", "chk" + rowNumber); //Text Value         
            ////if (payst.Equals("Y") || polst.Equals("L")) { chk01.Enabled = false; }
            //else { chk01.Enabled = true; }

            tcell1.Controls.Add(lbl1);
           // if (rowNumber == 0) { tcell2.Controls.Add(lbl2); }
           // else { tcell2.Controls.Add(chk01); }
            trow.Cells.Add(tcell1);
           // trow.Cells.Add(tcell2);
            Table1.Rows.Add(trow);
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

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

    protected void ddlyn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyn.SelectedIndex == 1)
        {
            Claimsts = "Pending";
            TraCode = "A";
        }
        else if (ddlyn.SelectedIndex ==2)
        {
            Claimsts = "Admitted";
            TraCode = "B";
        }
        else if (ddlyn.SelectedIndex == 3)
        {
            Claimsts = "Part Pay";
            TraCode = "C";
        }
    }

    private void createLoanTable(string LoanNumber, string lmcdt, string lmccp, string arr8, int rowNumber)
    {
        try
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            TableCell tcell3 = new TableCell();
            TableCell tcell4 = new TableCell();
            tcell1.BorderWidth = 1;
            tcell2.BorderWidth = 1;
            tcell3.BorderWidth = 1;
            tcell4.BorderWidth = 1;

            Label lbl1 = new Label();
            Label lbl2 = new Label();
            Label lbl3 = new Label();
            Label lbl4 = new Label();
            

            lbl1.ID = "LoanNumber" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "LoanNumber" + rowNumber); //Text Value
            lbl1.Text = LoanNumber;

            lbl2.ID = "lmcdt" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "lmcdt" + rowNumber); //Text Value
            lbl2.Text = lmcdt;

            lbl3.ID = "lmccp" + rowNumber;
            lbl3.Attributes.Add("runat", "Server");
            lbl3.Attributes.Add("Name", "lmccp" + rowNumber); //Text Value
            if (!lmccp.Equals("Loan Capital (Rs.)"))
            {
                lbl3.Text = String.Format("{0:N}", Convert.ToDouble(lmccp));
            }
            else
            {
                lbl3.Text = lmccp;
            }

            lbl4.ID = "lmnit" + rowNumber;
            lbl4.Attributes.Add("runat", "Server");
            lbl4.Attributes.Add("Name", "arr8" + rowNumber); //Text Value
            if (!arr8.Equals("Interest (Rs.)"))
            {
                lbl4.Text = String.Format("{0:N}", Convert.ToDouble(arr8));
            }
            else
            {
                lbl4.Text = arr8;
            }
            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            tcell3.Controls.Add(lbl3);
            tcell4.Controls.Add(lbl4);

            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            trow.Cells.Add(tcell3);
            trow.Cells.Add(tcell4);

            Table2.Rows.Add(trow);


        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public int[] dateComparison(int startdate, int enddate)
    {
        //end date is today, startdate, enddate should be yyyymmdd format
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

    protected void btn_Next_Click(object sender, EventArgs e)
    {

    }

    protected void ddlSP_CVR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlSP_CVR.SelectedIndex > 0 && ddlSP_CVR.SelectedIndex == 1 )&& (Tble != 34) &&(Tble != 38 )&&( Tble != 39 )&&( Tble != 46 )&&( Tble != 49))
        {
            Button1.Visible = true;
            Label2.Text = "";
        }
        else if (ddlSP_CVR.SelectedIndex > 0 && ddlSP_CVR.SelectedIndex == 2)
        {
            Button1.Visible = false;
            Label2.Text = "";
        }
        else
        {
            Button1.Visible = false;
            Label2.Text = "You cannot add Spouse for This Policy. Table" + Tble.ToString();
        }
    }

    protected void lnkbtn_spcvr_Click(object sender, EventArgs e)
    {
        
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Polno = int.Parse(litpolno.Text);
        CommDate = int.Parse(txtcomdat.Text);
        string[] ddate = lbldtdt.Text.Split('/');
        DeathDate = int.Parse(ddate[0].ToString() + ddate[1].ToString() + ddate[2].ToString());
        Response.Redirect("SpouseCVREntry.aspx?polno=" + Polno + "&comdt=" + CommDate + "&dthdate=" + DeathDate + "");
    }
}
