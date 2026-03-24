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

public partial class dthInt020 : System.Web.UI.Page
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

    private int polno;
    private string MOF;
    private int infodat;
    public int Infodat
    {
        get { return infodat; }
        set { infodat = value; }
    }

    private int dateofDeath;
    private int clm;
    public int Clm
    {
        get { return clm; }
        set { clm = value; }
    }
    public string nOD
    {
        get { return NOD; }
        set { NOD = value; }
    }
    private string methOfInfo;
    private string infoID;
    private string polstat;
    private string NOD;

    private string infoname;
    private string infoad1;
    private string infoad2;
    private string infoad3;
    private string infoad4;
    private string inforel;
    private long infotel = 0;
    private int BRN = 0;
    private string entEPF = "";

    private double sumassured;
    private int table;
    private int term;
    private int dateofComm;
    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private string cof;
    private int benefitPeriod;
    DataManager dthintobj;
    Investment_Policies invpol;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["brcode"] != null && Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            entEPF = Session["EPFNum"].ToString();
            BRN = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;           
        }
        if (!Page.IsPostBack)
        {
            dthintobj = new DataManager();
            invpol = new Investment_Policies();
            try
            {

                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblmof.Text = "Main Life"; }
                else if (MOF.Equals("S")) { this.lblmof.Text = "Spouse"; }
                else if (MOF.Equals("2")) { this.lblmof.Text = "Second Life"; }
                else if (MOF.Equals("C")) { this.lblmof.Text = "Child"; }

                this.ddlinfometh.Items.Add(new ListItem("Counter", "COUN"));
                this.ddlinfometh.Items.Add(new ListItem("Mail", "MAIL"));
                this.ddlinfometh.Items.Add(new ListItem("Call", "CALL"));

                #region //----- Policy Details ------
                string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom from lphs.premast where pmpol=" + polno + " ";
                string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom from lphs.liflaps where lppol=" + polno + " ";
                string polhisSelect = "select phsum, phtbl, phtrm, phcom,PHSTA from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = 'M' ";

                if (dthintobj.existRecored(premastSelect) != 0)
                {
                    dthintobj.readSql(premastSelect);
                    OracleDataReader premReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    premReader.Read();
                    sumassured = premReader.GetDouble(0);
                    table = premReader.GetInt32(1);
                    term = premReader.GetInt32(2);
                    dateofComm = premReader.GetInt32(3);
                    polstat = "I";
                    premReader.Close();
                    premReader.Dispose();
                }
                else if (dthintobj.existRecored(liflapsSelect) != 0)
                {
                    dthintobj.readSql(liflapsSelect);
                    OracleDataReader lapsReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    lapsReader.Read();
                    sumassured = lapsReader.GetDouble(0);
                    table = lapsReader.GetInt32(1);
                    term = lapsReader.GetInt32(2);
                    dateofComm = lapsReader.GetInt32(3);
                    polstat = "L";
                    lapsReader.Close();
                    lapsReader.Dispose();
                }
                else if (dthintobj.existRecored(polhisSelect) != 0 && (MOF.Equals("S") || MOF.Equals("2")))
                {
                    dthintobj.readSql(polhisSelect);
                    OracleDataReader lpolhisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    lpolhisReader.Read();
                    sumassured = lpolhisReader.GetDouble(0);
                    table = lpolhisReader.GetInt32(1);
                    term = lpolhisReader.GetInt32(2);
                    dateofComm = lpolhisReader.GetInt32(3);
                    polstat = lpolhisReader.GetString(4);
                    lpolhisReader.Close();
                    lpolhisReader.Dispose();
                }
                else
                {
                    string lsurefcheck = "select * from lphs.dthref where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";
                    if (dthintobj.existRecored(lsurefcheck) == 0)
                    {
                        dthintobj.connclose();
                        throw new Exception("No Policy Details!");
                    }
                    else
                    {
                        dthintobj.connclose();
                        throw new Exception("Policy Registered! Cannot Alter.");
                    }
                }

                if (table == 55 && (!MOF.Equals("M") && !MOF.Equals("S")))
                {
                    dthintobj.connclose();
                    throw new Exception("Cannot Intimation!");
                }

                #region ------------- Health Product Changes ------------
                if (table == 64)
                {
                    string tab = "";
                    string lpolhisSelect = "select PHMOS from lphs.lpolhis where phpol=" + polno + " ";

                    if (dthintobj.existRecored(lpolhisSelect) != 0)
                    {
                        dthintobj.readSql(lpolhisSelect);
                        OracleDataReader lpolhisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        lpolhisReader.Read();
                        tab = lpolhisReader.GetString(0);
                        lpolhisReader.Close();
                        lpolhisReader.Dispose();
                    }
                    if (tab == "M")
                    {
                        string lpolhisSelectTable = "select PHTBL from lphs.lpolhis where phpol=" + polno + " ";

                        if (dthintobj.existRecored(lpolhisSelectTable) != 0)
                        {
                            dthintobj.readSql(lpolhisSelectTable);
                            OracleDataReader lpolhisTableReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            lpolhisTableReader.Read();
                            table = lpolhisTableReader.GetInt32(0);
                            lpolhisTableReader.Close();
                            lpolhisTableReader.Dispose();
                        }
                    }
                }
                if (table == 55)
                {
                    #region  ------------- RCover - SA, COM DATE & Term details ----------------
                    int rcov = 0;
                    if (MOF == "M")
                    {
                        rcov = 1;
                    }
                    else if (MOF == "S")
                    {
                        rcov = 101;
                    }
                    string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                    if (dthintobj.existRecored(rcovSelect) != 0)
                    {
                        dthintobj.readSql(rcovSelect);
                        OracleDataReader rcovReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        rcovReader.Read();
                        sumassured = rcovReader.GetDouble(0);
                        dateofComm = rcovReader.GetInt32(1);
                        term = rcovReader.GetInt32(2);
                        rcovReader.Close();
                        rcovReader.Dispose();
                    }
                    #endregion
                }
                else
                {
                    #region  ------------- RCover - SA, COM DATE & Term details ----------------
                    int rcov = 0;
                    if (MOF == "S")
                    {
                        rcov = 101;
                    }
                    else
                    {
                        rcov = 1;
                    }
                    string rcovSelect = @"select A.RSUMAS,A.RCOMDAT,A.RTERM from LUND.RCOVER a where A.RPOL=" + polno + " and A.RCOVR=" + rcov + "";
                    string rcovHisSelect = @"select rsumas, rcomdat,rterm from LUND.RCOVER_HISTORY where rpol=" + polno + " and rcovr=" + rcov + "";
                    if (dthintobj.existRecored(rcovSelect) != 0)
                    {
                        dthintobj.readSql(rcovSelect);
                        OracleDataReader rcovReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        rcovReader.Read();
                        sumassured = rcovReader.GetDouble(0); 
                        rcovReader.Close();
                        rcovReader.Dispose();
                    }
                    else if (dthintobj.existRecored(rcovHisSelect) != 0)
                    {
                        dthintobj.readSql(rcovHisSelect);
                        OracleDataReader rcovHisReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        rcovHisReader.Read();
                        sumassured = rcovHisReader.GetDouble(0);
                        rcovHisReader.Close();
                        rcovHisReader.Dispose();
                    }
                    #endregion
                }
                #endregion

                this.lblsumassured.Text = "Rs."+String.Format("{0:N}", sumassured);
                this.lbltab.Text = table.ToString();
                this.lblterm.Text = term.ToString();
                this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);
                this.lblpolstat.Text = polstatselect(polstat);

                #endregion

                string phname1 = "", phname2 = "", phname3 = "";

                #region  // ************** PHNAME  ************************************

                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                dthintobj.readSql(sql);
                OracleDataReader oraDtReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraDtReader.Read())
                {
                    if (!oraDtReader.IsDBNull(0))
                    {
                        phname1 = oraDtReader.GetString(0); 
                    }
                    if (!oraDtReader.IsDBNull(1))
                    {
                        phname2 =  oraDtReader.GetString(1);
                    }
                    if (!oraDtReader.IsDBNull(2))
                    {
                        phname3 = oraDtReader.GetString(2);
                    }
                    phname = phname1 + "" + phname2 + "" + phname3;

                    if (!oraDtReader.IsDBNull(3)) { ad1 = (oraDtReader.GetString(3)); }
                    if (!oraDtReader.IsDBNull(4)) { ad2 = (oraDtReader.GetString(4)); }
                    if (!oraDtReader.IsDBNull(5)) { ad3 = (oraDtReader.GetString(5)); }
                    if (!oraDtReader.IsDBNull(6)) { ad4 = (oraDtReader.GetString(6)); }

                }
                oraDtReader.Close();
                oraDtReader.Dispose();

                this.lblnameofInsured.Text = phname;
                if (MOF.Equals("M"))
                {
                    this.txtnameofdd.Text = phname;
                }
                this.lblassuredad1.Text = ad1 + " " + ad2;
                this.lblassuredad2.Text = ad3 + " " + ad4;

                #endregion

                #region //************* POLPERSONAL *************************

                string spouceName = "";
                if (MOF.Equals("S") || MOF.Equals("C") || MOF.Equals("2"))
                {
                    string polpersonalSel = "";
                    if (MOF.Equals("S"))
                        polpersonalSel = "select fullname from LUND.POLPERSONAL where polno = " + polno + " and PRPERTYPE = 2 ";
                    if (MOF.Equals("C"))
                        polpersonalSel = "select fullname from LUND.POLPERSONAL where polno = " + polno + " and PRPERTYPE = 4 ";
                    if (MOF.Equals("2"))
                        polpersonalSel = "select fullname from LUND.POLPERSONAL where polno = " + polno + " and PRPERTYPE = 3 ";
                    if (dthintobj.existRecored(polpersonalSel) != 0)
                    {
                        dthintobj.readSql(polpersonalSel);
                        OracleDataReader polperReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        polperReader.Read();
                        if (!polperReader.IsDBNull(0)) { spouceName = polperReader.GetString(0); } else { spouceName = ""; }
                        polperReader.Close();
                        polperReader.Dispose();
                    }
                    this.txtnameofdd.Text = spouceName;
                }


                #endregion

                string confst = "";
                //string dthintCheck = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";
                string dthintDetails = "select dclm, dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1, diad2, diad3, diad4, ditel, dinforel, dsta, dcof from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";
                if (dthintobj.existRecored(dthintDetails) != 0)
                {
                    #region ------ While loop ------

                    dthintobj.readSql(dthintDetails);
                    OracleDataReader dthintReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        clm = dthintReader.GetInt32(0);
                        infodat = dthintReader.GetInt32(1);
                        dateofDeath = dthintReader.GetInt32(4);
                        if (!dthintReader.IsDBNull(3)) { NOD = dthintReader.GetString(3); } else { NOD = ""; }
                        if (!dthintReader.IsDBNull(5)) { methOfInfo = dthintReader.GetString(5); } else { methOfInfo = ""; }
                        if (!dthintReader.IsDBNull(6)) { infoID = dthintReader.GetString(6); } else { infoID = ""; }
                        if (!dthintReader.IsDBNull(7)) { infoname = dthintReader.GetString(7); } else { infoname = ""; }
                        if (!dthintReader.IsDBNull(8)) { infoad1 = dthintReader.GetString(8); } else { infoad1 = ""; }
                        if (!dthintReader.IsDBNull(9)) { infoad2 = dthintReader.GetString(9); } else { infoad2 = ""; }
                        if (!dthintReader.IsDBNull(10)) { infoad3 = dthintReader.GetString(10); } else { infoad3 = ""; }
                        if (!dthintReader.IsDBNull(11)) { infoad4 = dthintReader.GetString(11); } else { infoad4 = ""; }
                        if (!dthintReader.IsDBNull(12)) { infotel = dthintReader.GetInt64(12); } else { infotel = 0; }
                        if (!dthintReader.IsDBNull(13)) { inforel = dthintReader.GetString(13); } else { inforel = ""; }
                        if (!dthintReader.IsDBNull(14)) { confst = dthintReader.GetString(14); } else { confst = ""; }
                        if (!dthintReader.IsDBNull(15)) { cof = dthintReader.GetString(15); } else { cof = ""; }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                    this.txtnameofdd.Text = NOD;
                    this.txtdtofinfo.Text = infodat.ToString();
                    this.txtdtofdth.Text = dateofDeath.ToString();
                    this.txtinfoname.Text = infoname;
                    this.txtinfoad1.Text = infoad1;
                    this.txtinfoad2.Text = infoad2;
                    this.txtinfoad3.Text = infoad3;
                    this.txtinfoad4.Text = infoad4;
                    this.txtinfoid.Text = infoID;
                    this.txtinfotel.Text = infotel.ToString();
                    this.txtinforel.Text = inforel;
                    this.lblpolstat.Text = polstatselect(polstat);
                    this.ddlinfometh.SelectedIndex = infomethselect(methOfInfo);
                    if (cof.Equals("C")) { this.ddlcof.SelectedIndex = 0; }
                    else if (cof.Equals("A")) { this.ddlcof.SelectedIndex = 1; }
                    else if (cof.Equals("N")) { this.ddlcof.SelectedIndex = 2; }
                    else if (cof.Equals("G")) { this.ddlcof.SelectedIndex = 3; }
                    if (confst.Equals("2") || confst.Equals("1")) { this.btnSubmit.Enabled = false; this.btnDel.Enabled = false; }
                    else { this.btnSubmit.Enabled = true; this.btnDel.Enabled = true; }
                    #endregion
                }
                else
                {
                    this.txtdtofinfo.Text = this.setDate()[0];
                    this.btnSubmit.Enabled = true;
                    this.btnDel.Enabled = false;
                }                
                //Investment Policies
                invpol.InvestmentPolicyFind(polno, dthintobj);
                if (invpol.Ispolicyexist)
                {
                    this.lblInvmsg.Visible = true;
                    this.hlInvpol.Visible = true;
                }
                dthintobj.connclose();

                //-------------------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["infodat"] = infodat;
                ViewState["clm"] = clm;

                ViewState["polstat"] = polstat;
                ViewState["NOD"] = NOD;

                ViewState["infoname"] = infoname;
                ViewState["infoad1"] = infoad1;
                ViewState["infoad2"] = infoad2;
                ViewState["infoad3"] = infoad3;
                ViewState["infoad4"] = infoad4;
                ViewState["invpol"] = invpol;
                ViewState["table"] = table;
            }
            catch (Exception ex)
            {
                dthintobj.connclose();  
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else 
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["infodat"] != null) { infodat = int.Parse(ViewState["infodat"].ToString()); }
            if (ViewState["clm"] != null) { clm = int.Parse(ViewState["clm"].ToString()); }

            if (ViewState["polstat"] != null) { polstat = ViewState["polstat"].ToString(); }
            if (ViewState["NOD"] != null) { NOD = ViewState["NOD"].ToString(); }
            if (ViewState["infoname"] != null) { infoname = ViewState["infoname"].ToString(); }
            if (ViewState["infoad1"] != null) { infoad1 = ViewState["infoad1"].ToString(); }
            if (ViewState["infoad2"] != null) { infoad2 = ViewState["infoad2"].ToString(); }
            if (ViewState["infoad2"] != null) { infoad3 = ViewState["infoad3"].ToString(); }
            if (ViewState["infoad4"] != null) { infoad4 = ViewState["infoad4"].ToString(); }
            if (ViewState["invpol"] != null) { invpol = (Investment_Policies)ViewState["invpol"]; }
            if (ViewState["table"] != null) { table = int.Parse(ViewState["table"].ToString()); }
        }
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        dthintobj = new DataManager();
        try
        {           
            string dthintUPDSQL = "update lphs.dthint set dsta = '1' where dpolno=" + polno + " and dmos='" + MOF + "' ";
            dthintobj.insertRecords(dthintUPDSQL);
            dthintobj.connclose();
        }
        catch (Exception ex)
        {
            dthintobj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        this.ddlinfometh.SelectedIndex = infomethselect("COUN");
        this.txtdtofinfo.Text = setDate()[0];
        this.txtdtofdth.Text = "";
        this.txtinforel.Text = "";
        this.txtinfoad1.Text = "";
        this.txtinfoad2.Text = "";
        this.txtinfoad3.Text = "";
        this.txtinfoad4.Text = "";
        this.txtinfoid.Text = "";
        this.txtinfotel.Text = "";
        this.txtinfoname.Text = "";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dthintobj = new DataManager();
        try
        {       
            if ((this.txtdtofinfo.Text != null) && (this.txtdtofinfo.Text.Length == 8)) { infodat = int.Parse(this.txtdtofinfo.Text.Trim()); }
            if ((this.txtdtofdth.Text != null) && (this.txtdtofdth.Text.Length == 8)) { dateofDeath = int.Parse(this.txtdtofdth.Text.Trim()); }
            else if ((dateofDeath > 0) && (dateofDeath.ToString().Length < 8))
            {
                this.cv1.IsValid = false;
                this.cv1.Text = "Please Enter an 8 digit Date of Death!";
                return;
            }

            if ((dateofDeath > 0) && (dateofDeath > int.Parse(this.setDate()[0]))) 
            {
                this.cv1.IsValid = false;
                this.cv1.Text = "Date of Death cannot come After Today!";
                return;
            }
                                if (!this.dateValidation(infodat.ToString()))
                                {
                                    this.cv1.IsValid = false;
                                    this.cv1.Text = "Invalid Date of Intimation";
                                    return;
                                }
                                if (!(dateofDeath == 0) && (!this.dateValidation(dateofDeath.ToString())))
                                {
                                    this.cv1.IsValid = false;
                                    this.cv1.Text = "Invalid Date of Death";
                                    return;
                                }

            if (dateofDeath > int.Parse(this.setDate()[0])) { throw new Exception("Invalid Date of Death"); }


            string[] ComDate = lbldtofcomm.Text.Split('/');
            string ComDate2 = "";
            foreach (string s in ComDate)
            {
                ComDate2 = ComDate2 + s;
            }

            //Table 56 changes
            string planDetails = "select BENEFIT_PERIOD from lund.tabnam where tdtabl=" + table + "";
            if (dthintobj.existRecored(planDetails) != 0)
            {
                dthintobj.readSql(planDetails);
                OracleDataReader planReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (planReader.Read())
                {
                    if (!planReader.IsDBNull(0)) { benefitPeriod = planReader.GetInt32(0); } else { benefitPeriod = 0; }
                }
                planReader.Close();
                planReader.Dispose();
            }
            
            if (table == 56)
            {
                if (dateofDeath > (Convert.ToInt32(ComDate2) + ((Convert.ToInt32(lblterm.Text) + benefitPeriod) * 10000))) { throw new Exception("Date of Death Exceeds Benefit Period of Policy!"); }
            }
            else
            {
                //valdiation added by Dulan task 25312
                //if (dateofDeath > (Convert.ToInt32(ComDate2) + (Convert.ToInt32(lblterm.Text) * 10000))) { throw new Exception("Date of Death Exceeds Matuarity Date of Policy!"); }
                //valdiation added by Dulan task 25312

                //Task 31667 
                if (table != 3)
                {
                    if (dateofDeath > (Convert.ToInt32(ComDate2) + (Convert.ToInt32(lblterm.Text) * 10000))) { throw new Exception("Date of Death Exceeds Matuarity Date of Policy!"); }
                }
            }

            NOD = this.txtnameofdd.Text.Trim();
            methOfInfo = this.ddlinfometh.Text.Trim();
            infoID = this.txtinfoid.Text.Trim();
            infoname = this.txtinfoname.Text.Trim();
            infoad1 = this.txtinfoad1.Text.Trim();
            infoad2 = this.txtinfoad2.Text.Trim();
            infoad3 = this.txtinfoad3.Text.Trim();
            infoad4 = this.txtinfoad4.Text.Trim();

            NOD = NOD.Replace('\'', ' ');

            infoID = infoID.Replace('\'', ' ');
            infoname = infoname.Replace('\'', ' ');
            infoad1 = infoad1.Replace('\'', ' ');
            infoad2 = infoad2.Replace('\'', ' ');
            infoad3 = infoad3.Replace('\'', ' ');
            infoad4 = infoad4.Replace('\'', ' ');
            cof = this.ddlcof.SelectedItem.Value;

            ViewState["infodat"] = infodat;
            ViewState["NOD"] = NOD;
            ViewState["infoname"] = infoname;
            ViewState["infoad1"] = infoad1;
            ViewState["infoad2"] = infoad2;
            ViewState["infoad3"] = infoad3;
            ViewState["infoad4"] = infoad4;
           
            if (!(this.txtinfotel.Text.Equals(null)) && !(this.txtinfotel.Text.Equals("")))
            {
                infotel = Convert.ToInt64(this.txtinfotel.Text);
            }
            inforel = this.txtinforel.Text;
            
            string dthintCheck = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";

            if (dthintobj.existRecored(dthintCheck) == 0)
            {
                string dthintInsertSQL = "insert into lphs.dthint (dpolno, dmos, dclm, dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1, diad2, diad3, diad4, ditel, drecbrn, dentepf, denttim, dentip, dinforel, dcof) ";
                dthintInsertSQL += " values (" + polno + ", '" + MOF + "', " + clm + ", " + infodat + ", '" + polstat + "', '" + NOD + "', " + dateofDeath + ", '" + methOfInfo + "', '" + infoID + "', '" + infoname + "',";
                dthintInsertSQL += " '" + infoad1 + "','" + infoad2 + "','" + infoad3 + "','" + infoad4 + "'," + infotel + "," + BRN + ", '" + entEPF + "', '" + setDate()[1] + "', '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', '" + inforel + "', '" + cof + "' ) ";
                dthintobj.insertRecords(dthintInsertSQL);
            }
            else 
            {
                string dthintUPDSQL = "update lphs.dthint set dclm=" + clm + ",  dinfodat= " + infodat + ", dpolst='" + polstat + "', dnod='" + NOD + "', ddtofdth=" + dateofDeath + ", dmoinf='" + methOfInfo + "',";
                dthintUPDSQL += "diid='" + infoID + "', diname='" + infoname + "', diad1= '" + infoad1 + "', diad2= '" + infoad2 + "', diad3= '" + infoad3 + "', diad4= '" + infoad4 + "', ditel=" + infotel + ",";
                dthintUPDSQL += "dupdepf='" + entEPF + "', dupdbrn=" + BRN + ", dupddate=" + int.Parse(setDate()[0]) + ", dinforel='" + inforel + "', dcof = '" + cof + "' where dpolno=" + polno + " and dmos='" + MOF + "' and dsta='0' and dconfst is null";
                dthintobj.insertRecords(dthintUPDSQL);
            }

            this.lblsuccess.Visible = true;
            this.lblsuccess.Text = "Record Updated Successfully!";

            ViewState["infoname"] = infoname;
            ViewState["infoad1"] = infoad1;
            ViewState["infoad2"] = infoad2;
            ViewState["infoad3"] = infoad3;
            ViewState["infoad4"] = infoad4;

            dthintobj.connclose();
        }
        catch (Exception ex)
        {
            dthintobj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
       
    }
    
    private string polstatselect(string polstat)
    {
        string i = "";

        if (polstat.Equals("L"))
        {
            i = "LAPSED";
        }
        else
        {
            i = "INFORCED";
        }
        return i;

    }

    private int infomethselect(string infometh)
    {

        int j = 0;
        if (infometh.Equals("MAIL"))
        {
            j = 1;
        }
        if (infometh.Equals("CALL"))
        {
            j = 2;
        }

        return j;
    }

    private bool dateValidation(string theDate) 
    {
        bool valid = true;
        int year = int.Parse(theDate.Substring(0, 4));
        int month = int.Parse(theDate.Substring(4, 2));
        int day = int.Parse(theDate.Substring(6, 2));

        if ((year < 1965) || (year > 2100)) { valid = false; }
        if ((month <= 0) || (month > 12)) { valid = false; }
        if ((day <= 0) || (day > 31)) { valid = false; }

        if (((month == 2) || (month == 4) || (month == 6) || (month == 9) || (month == 11)) && (day == 31)) { valid = false; }

        else if ((month == 2) && ((day == 30) || (day == 31))) { valid = false; }

        else if ((!((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))) && (month == 2) && (day == 29)) { valid = false; }

        return valid;
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


    public int Polno 
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mOF 
    {
        get { return MOF; }
        set { MOF = value; }
    }

    public string Infoname
    {
        get { return infoname; }
        set { infoname = value; }
    }
    public string Infoad1
    {
        get { return infoad1; }
        set { infoad1 = value; }
    }
    public string Infoad2
    {
        get { return infoad2; }
        set { infoad2 = value; }
    }
    public string Infoad3
    {
        get { return infoad3; }
        set { infoad3 = value; }
    }
    public string Infoad4
    {
        get { return infoad4; }
        set { infoad4 = value; }
    }
    public Investment_Policies Invpol
    {
        get { return invpol; }
        set { invpol = value; }
    }

}
