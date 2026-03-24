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

public partial class reinsLetter002 : System.Web.UI.Page
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

    private  long polno;
    private  string MOF;

    private int infodat;
    private int dateofdeath;
    private string nameOfDead, causeofdth;

    private string name;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;

    private string LANG = "";
    private int INDEX = 0;
    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    private string ADDRESS3 = "";
    private string ADDRESS4 = "";
    private string liability, recovr, amtsto, copy1, copy2, copy3, copy4, gender, dob;
    private string recovrby, reinsperno, reinsshare;

    #region  //******* variables for DTHREF ***************
    private  double ADB;
    private double FPU;
    private double SJ;
    private double FE;
    private string FEearlyPay = "";
    private string ADBlatepay = "";

    private string ageAdmitYN;
    private string revivalsYN;
    private string assNomYN;
    private string reinsYN;
    private double vestedBonus;
    private double interimBonus;
    private double totbons;
    private double surrrenderedbons;
    private int bonussurrYr;
    private double netsurrAmt;
    private long claimno;
    private double deposit;
    private double demmands;
    private double defint;
    private double loancap;
    private double loanint;
    private int missingprems;
    private string polcompleYM;

    private double totamount;
    public string memoaccept = "";
    private string thePayee;

    private double otheradd;
    private double otherdeuct;
    private double refOfPrems;

    private double grossClm;
    private double netclm;
    private double outAmt;

    private  double sumassured;
    #endregion

    #region  //******* variables for LPOLHIS ***************
    private int PRM;
    private int COM;
    private int TBL;
    private int TRM;
    private int SUM;
    private int MOD;
    private int DUE;
    private string STA;

    #endregion

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
        }
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {


                #region //---- Name and Address ---

                string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and indx = 0 ";
                if (dm.existRecored(dclmaddressSelect) != 0)
                {
                    dm.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        if (!dclmAdReader.IsDBNull(2)) { NAME = dclmAdReader.GetString(2); } else { NAME = ""; }
                        if (!dclmAdReader.IsDBNull(3)) { ADDRESS1 = dclmAdReader.GetString(3); } else { ADDRESS1 = ""; }
                        if (!dclmAdReader.IsDBNull(4)) { ADDRESS2 = dclmAdReader.GetString(4); } else { ADDRESS2 = ""; }
                        if (!dclmAdReader.IsDBNull(5)) { ADDRESS3 = dclmAdReader.GetString(5); } else { ADDRESS3 = ""; }
                        if (!dclmAdReader.IsDBNull(6)) { ADDRESS4 = dclmAdReader.GetString(6); } else { ADDRESS4 = ""; }
                    }
                    dclmAdReader.Close();
                    dclmAdReader.Dispose();

                    this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lbldate2.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

                    this.lblName.Text = NAME;
                    this.lblAd1.Text = ADDRESS1;
                    this.lblAd2.Text = ADDRESS2;
                    this.lblAd3.Text = ADDRESS3;
                    this.lblAd4.Text = ADDRESS4;
                }
                else
                {
                    string dthintSelect = "select diname, diad1, diad2, diad3, diad4 from lphs.dthint where dpolno = " + polno + " and dmos='" + MOF + "'";
                    if (dm.existRecored(dthintSelect) == 0)
                    {
                        dm.connclose();
                        throw new Exception("No Death Intimation Details!");
                    }
                    else
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { name = dthintReader.GetString(0); }
                            if (!dthintReader.IsDBNull(1)) { ad1 = dthintReader.GetString(1); }
                            if (!dthintReader.IsDBNull(2)) { ad2 = dthintReader.GetString(2); }
                            if (!dthintReader.IsDBNull(3)) { ad3 = dthintReader.GetString(3); }
                            if (!dthintReader.IsDBNull(4)) { ad4 = dthintReader.GetString(4); }
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();
                    }

                    this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lbldate2.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lblName.Text = name;
                    this.lblAd1.Text = ad1;
                    this.lblAd2.Text = ad2;
                    this.lblAd3.Text = ad3;
                    this.lblAd4.Text = ad4;
                }
                #endregion

                #region // ************** PHNAME  *********************************
                string phname = "";
                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, " +
                    " phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                if (dm.existRecored(sql) != 0)
                {
                    dm.readSql(sql);
                    OracleDataReader oraDtReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (oraDtReader.Read())
                    {
                        if ((!oraDtReader.IsDBNull(0)) && ((!oraDtReader.IsDBNull(1))) && ((!oraDtReader.IsDBNull(2))))
                        {
                            phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                        }
                    }
                    oraDtReader.Close();
                    oraDtReader.Dispose();
                }
                #endregion

                #region //---------- viewing policy history.....

                string LPOLHIScheck = "select * from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";

                if (dm.existRecored(LPOLHIScheck) != 0)
                {
                    string LPOLHISread = "select  PHCOD, PHPOL, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where PHPOL=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "'  ";
                    dm.readSql(LPOLHISread);
                    OracleDataReader polhisReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (polhisReader.Read())
                    {
                        if (!polhisReader.IsDBNull(7)) { PRM = polhisReader.GetInt32(7); } else { PRM = 0; }
                        if (!polhisReader.IsDBNull(2)) { COM = polhisReader.GetInt32(2); } else { COM = 0; }
                        if (!polhisReader.IsDBNull(3)) { TBL = polhisReader.GetInt32(3); } else { TBL = 0; }
                        if (!polhisReader.IsDBNull(4)) { TRM = polhisReader.GetInt32(4); } else { TRM = 0; }
                        if (!polhisReader.IsDBNull(5)) { SUM = polhisReader.GetInt32(5); } else { SUM = 0; }
                        if (!polhisReader.IsDBNull(6)) { MOD = polhisReader.GetInt32(6); } else { MOD = 0; }
                        if (!polhisReader.IsDBNull(8)) { DUE = polhisReader.GetInt32(8); } else { DUE = 0; }
                        if (!polhisReader.IsDBNull(15)) { STA = polhisReader.GetString(15); } else { STA = ""; }
                    }
                    polhisReader.Close();
                    polhisReader.Dispose();
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Terminated Police Details Found!");
                }
                #endregion

                #region //************** dthref ***********************************

                string dthrefSelect = "select DRCLMNO ,DRACCBF ,DRAGEADMIT ,DRRINSYN ,DRREVIVALS ,DRASSIGNEENOM ,DRVESTEDBON ,DRINTERIMBON ,";
                dthrefSelect += "DRBONSURRAMT ,DRBONSURRYR ,DRSWARNAJAYA ,DRFUNERALEXP ,DRFPU ,DRDEPOSITS , DRDEFPREM ,DRINT ,DRLONCAP ,DRLOANINT ,";
                dthrefSelect += "DRNETCLM ,DRPAIDNO , DRNETSURR, ADBPAYAMT, SJPAYAMT, FPUPAYAMT, FEPAYAMT, SMASS_PVAL, DROTHERADITNS, DEOTHERDEDUCT,";
                dthrefSelect += " REFUND_OF_PREMS, MEMOAPRV, AMTOUT, FE_EARLYPAY, ADB_LATEPAY, AGE_STATUS, AGE_AMT, MINUTES, drnetclm, causeofdeathstr from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";

                if (dm.existRecored(dthrefSelect) != 0)
                {
                    dm.readSql(dthrefSelect);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { claimno = dthrefReader.GetInt64(0); } else { claimno = 0; }
                        if (!dthrefReader.IsDBNull(21)) { ADB = dthrefReader.GetDouble(21); } else { ADB = 0; }
                        if (!dthrefReader.IsDBNull(23)) { FPU = dthrefReader.GetDouble(23); } else { FPU = 0; }
                        if (!dthrefReader.IsDBNull(22)) { SJ = dthrefReader.GetDouble(22); } else { SJ = 0; }
                        if (!dthrefReader.IsDBNull(21)) { FE = dthrefReader.GetDouble(24); } else { FE = 0; }
                        if (!dthrefReader.IsDBNull(25)) { sumassured = dthrefReader.GetInt64(25); } else { sumassured = 0; }
                        if (!dthrefReader.IsDBNull(2)) { ageAdmitYN = dthrefReader.GetString(2); } else { ageAdmitYN = ""; }
                        if (!dthrefReader.IsDBNull(4)) { revivalsYN = dthrefReader.GetString(4); } else { revivalsYN = ""; }
                        if (!dthrefReader.IsDBNull(5)) { assNomYN = dthrefReader.GetString(5); } else { assNomYN = ""; }
                        if (!dthrefReader.IsDBNull(3)) { reinsYN = dthrefReader.GetString(3); } else { reinsYN = ""; }

                        if (!dthrefReader.IsDBNull(6)) { vestedBonus = dthrefReader.GetDouble(6); } else { vestedBonus = 0; }
                        if (!dthrefReader.IsDBNull(7)) { interimBonus = dthrefReader.GetDouble(7); } else { interimBonus = 0; }
                        if (!dthrefReader.IsDBNull(8)) { surrrenderedbons = dthrefReader.GetDouble(8); } else { surrrenderedbons = 0; }
                        if (!dthrefReader.IsDBNull(9)) { bonussurrYr = dthrefReader.GetInt32(9); } else { bonussurrYr = 0; }
                        if (!dthrefReader.IsDBNull(20)) { netsurrAmt = dthrefReader.GetDouble(20); } else { netsurrAmt = 0; }

                        if (!dthrefReader.IsDBNull(13)) { deposit = dthrefReader.GetDouble(13); } else { deposit = 0; }
                        if (!dthrefReader.IsDBNull(14)) { demmands = dthrefReader.GetDouble(14); } else { demmands = 0; }
                        if (!dthrefReader.IsDBNull(15)) { defint = dthrefReader.GetDouble(15); } else { defint = 0; }
                        if (!dthrefReader.IsDBNull(16)) { loancap = dthrefReader.GetDouble(16); } else { loancap = 0; }
                        if (!dthrefReader.IsDBNull(17)) { loanint = dthrefReader.GetDouble(17); } else { loanint = 0; }

                        if (!dthrefReader.IsDBNull(36)) { netclm = dthrefReader.GetDouble(36); } else { netclm = 0; }
                        if (!dthrefReader.IsDBNull(37)) { causeofdth = dthrefReader.GetString(37); } else { causeofdth = ""; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();

                    double ADB02 = 0;
                    double FPU02 = 0;

                    if (netclm == 0) { netclm = grossClm - (demmands + defint + loancap + loanint + surrrenderedbons + (missingprems * PRM)); }

                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Death Reference Details!");
                }

                #endregion

                #region  //************** dthint *************************

                string dthintSelect2 = "select dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1,diad2,diad3,diad4, ditel, dinforel from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta=2  ";
                if (dm.existRecored(dthintSelect2) == 0)
                {
                    dm.connclose();
                    throw new Exception("No Death Intimation Details or Death Intimation not Confirmed!");
                }
                else
                {
                    dm.readSql(dthintSelect2);
                    OracleDataReader dthintREADER = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintREADER.Read())
                    {
                        if (!dthintREADER.IsDBNull(0)) { infodat = dthintREADER.GetInt32(0); } else { infodat = 0; }
                        if (!dthintREADER.IsDBNull(2)) { nameOfDead = dthintREADER.GetString(2); } else { nameOfDead = ""; }
                        if (!dthintREADER.IsDBNull(3)) { dateofdeath = dthintREADER.GetInt32(3); } else { dateofdeath = 0; }
                    }
                    dthintREADER.Close();
                    dthintREADER.Dispose();
                }

                #endregion

                this.lblpolno.Text = polno.ToString();
                this.lblpolno2.Text = polno.ToString();
                this.lblLifeAssured.Text = phname;
                this.lblphname.Text = phname;
                this.lblclmno.Text = claimno.ToString();
                this.lblclmno2.Text = claimno.ToString();
                this.lblclmno3.Text = claimno.ToString();

                this.lblcom.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                this.lblclmamt.Text = String.Format("{0:N}", netclm);
                if (MOF.Equals("M")) { this.lblmos.Text = "Main LIfe"; }
                else if (MOF.Equals("S")) { this.lblmos.Text = "Spouce"; }
                else if (MOF.Equals("M")) { this.lblmos.Text = "Second LIfe"; }
                this.lbldtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                this.lblcause.Text = causeofdth.ToString();
                this.lbltotbons.Text = (vestedBonus + interimBonus - surrrenderedbons).ToString();
                if (STA.Equals("L")) { this.lbllapsedt.Text = DUE.ToString().Substring(0, 4) + "/" + DUE.ToString().Substring(4, 2); }

                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
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
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        liability = this.txtadmtdliability.Text.Trim();
        recovr = this.txtrecover.Text.Trim();
        amtsto = this.txtamtsto.Text.Trim();
        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
        gender = this.txtgender.Text.Trim();
        dob = this.txtdob.Text.Trim();
        recovrby = this.txtrecoverby.Text.Trim();
        reinsperno = this.txtreinsperson.Text.Trim();
        reinsshare = this.txtreinsshare.Text.Trim();
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOF; }
        set { MOF = value; }
    }

    public string Liability
    {
        get { return liability; }
        set { liability = value; }
    }
    public string Recovr
    {
        get { return recovr; }
        set { recovr = value; }
    }
    public string Copy1
    {
        get { return copy1; }
        set { copy1 = value; }
    }
    public string Copy2
    {
        get { return copy2; }
        set { copy2 = value; }
    }
    public string Copy3
    {
        get { return copy3; }
        set { copy3 = value; }
    }
    public string Copy4
    {
        get { return copy4; }
        set { copy4 = value; }
    }
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public string Dob
    {
        get { return dob; }
        set { dob = value; }
    }
    public string Amtsto
    {
        get { return amtsto; }
        set { amtsto = value; }
    }
    public string Recovrby
    {
        get { return recovrby; }
        set { recovrby = value; }
    }
    public string Reinsperno
    {
        get { return reinsperno; }
        set { reinsperno = value; }
    }
    public string Reinsshare
    {
        get { return reinsshare; }
        set { reinsshare = value; }
    }


}
