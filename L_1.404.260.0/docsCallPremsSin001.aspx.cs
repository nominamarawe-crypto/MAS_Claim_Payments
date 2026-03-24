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

public partial class docsCallPremsSin001 : System.Web.UI.Page
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
        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        return datetime;

    }

    private static int polno;
    private static string MOF;
    private static string dc;
   
    private long cliamNo;
    private string nod;
    private string soldierNo;
    private string regiment;
    private string placeOfDeath;
    private static string prem;
    private string gebasa;
    private static int DCO;
    private static int due;

    private string copy1;
    private string copy2;
    private string copy3;
    private string copy4;
    private string copy5;
    private string copy6;
    private string copy7;
    private string copy8;

    private string from1;
    private string from2;
    private string from3;
    private string from4;
    private string from5;

    private string to1;
    private string to2;
    private string to3;
    private string to4;
    private string to5;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;
        }

        if (!Page.IsPostBack)
        {
            try 
            {
                dm = new DataManager();

                this.lblpolno.Text = polno.ToString();

                string DNOD = "";
                int dateofdeath = 0;

                #region
                string dthintSelect = "select DNOD, DCLM, ddtofdth from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                        if (!dthintReader.IsDBNull(2)) { dateofdeath = dthintReader.GetInt32(2); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }
                #endregion

                #region

                string premSele = "select pmprm, pmcom, pmdue from lphs.premast where pmpol = " + polno + " ";
                if (dm.existRecored(premSele) != 0)
                {
                    dm.readSql(premSele);
                    OracleDataReader premreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (premreader.Read()) 
                    {
                        if (!premreader.IsDBNull(0)) { prem = premreader.GetDouble(0).ToString(); } else { prem = ""; }
                        if (!premreader.IsDBNull(1)) { DCO = premreader.GetInt32(1); } else { DCO = 0; }
                        if (!premreader.IsDBNull(2)) { due = premreader.GetInt32(2); } else { due = 0; }                    
                    }
                    premreader.Close();
                    premreader.Dispose();
                }
                else 
                {
                    string lapsSele = "select lpprm, lpcom, lpdue from lphs.liflaps where lppol = " + polno + " ";
                    if (dm.existRecored(lapsSele) != 0)
                    {
                        dm.readSql(lapsSele);
                        OracleDataReader lapseader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (lapseader.Read())
                        {
                            if (!lapseader.IsDBNull(0)) { prem = lapseader.GetDouble(0).ToString(); } else { prem = ""; }
                            if (!lapseader.IsDBNull(1)) { DCO = lapseader.GetInt32(1); } else { DCO = 0; }
                            if (!lapseader.IsDBNull(2)) { due = lapseader.GetInt32(2); } else { due = 0; }
                        }
                        lapseader.Close();
                        lapseader.Dispose();
                    }
                    else
                    {
                        dm.connclose();
                        throw new Exception("No Policy Details");
                    }
                }

                #endregion

                this.txtprm.Text = prem;
                this.lbldco.Text = DCO.ToString().Substring(0, 4) + "/" + DCO.ToString().Substring(4, 2) + "/" + DCO.ToString().Substring(6, 2);
                this.lblexitym.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2);
                this.lblourref.Text = cliamNo.ToString();

                if (dateofdeath > 0)
                {
                    this.lbdtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                }
                this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.txtnod.Text = DNOD;

                if (dc.Equals("Army"))
                {
                    this.lblname.Text = "wOHCI ^jegqma yd f,aLK&";
                    this.lblad1.Text = "hqo yuqod jegqma yd f,aLK ldhH_d,h";
                    this.lblad2.Text = "hqo yuqod ckmoh";
                    this.lblad3.Text = "mkdf.dv";
                    this.lblad4.Text = "fydaud.u";
                }
                else if (dc.Equals("Navy"))
                {
                    this.lblname.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
                    this.lblad1.Text = "kdjsl iqNidOl wOHCI fjkqjg";
                    this.lblad2.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
                    this.lblad3.Text = "fld<U";
                }

                dm.connclose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        nod = this.txtnod.Text.Trim();
        soldierNo = this.txtsoldierno.Text.Trim();
        placeOfDeath = this.txtplaceofdth.Text.Trim();
        prem = this.txtprm.Text.Trim();
        regiment = this.txtregiment.Text.Trim();
        gebasa = this.txtgebasa.Text.Trim();

        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
        copy5 = this.txtcopy5.Text.Trim();
        copy6 = this.txtcopy6.Text.Trim();
        copy7 = this.txtcopy7.Text.Trim();
        copy8 = this.txtcopy8.Text.Trim();

        from1 = this.txtfrom1.Text.Trim();
        from2 = this.txtfrom2.Text.Trim();
        from3 = this.txtfrom3.Text.Trim();
        from4 = this.txtfrom4.Text.Trim();
        from5 = this.txtfrom5.Text.Trim();

        to1 = this.txtTo1.Text.Trim();
        to2 = this.txtTo2.Text.Trim();
        to3 = this.txtTo3.Text.Trim();
        to4 = this.txtTo4.Text.Trim();
        to5 = this.txtTo5.Text.Trim();

    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public string CallDC
    {
        get { return dc; }
        set { dc = value; }
    }
    public string Nod
    {
        get { return nod; }
        set { nod = value; }
    }
    public string SoldierNo
    {
        get { return soldierNo; }
        set { soldierNo = value; }
    }

    public string Prem
    {
        get { return prem; }
        set { prem = value; }
    }
    public int dCO
    {
        get { return DCO; }
        set { DCO = value; }
    }
    public int Due
    {
        get { return due; }
        set { due = value; }
    }

    public string Regiment
    {
        get { return regiment; }
        set { regiment = value; }
    }
    public string PlaceOfDeath
    {
        get { return placeOfDeath; }
        set { placeOfDeath = value; }
    }
    public string Gebasa
    {
        get { return gebasa; }
        set { gebasa = value; }
    }
    public long CliamNo
    {
        get { return cliamNo; }
        set { cliamNo = value; }
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
    public string Copy5
    {
        get { return copy5; }
        set { copy5 = value; }
    }
    public string Copy6
    {
        get { return copy6; }
        set { copy6 = value; }
    }
    public string Copy7
    {
        get { return copy7; }
        set { copy7 = value; }
    }
    public string Copy8
    {
        get { return copy8; }
        set { copy8 = value; }
    }

    public string From1
    {
        get { return from1; }
        set { from1 = value; }
    }
    public string From2
    {
        get { return from2; }
        set { from2 = value; }
    }
    public string From3
    {
        get { return from3; }
        set { from3 = value; }
    }
    public string From4
    {
        get { return from4; }
        set { from4 = value; }
    }
    public string From5
    {
        get { return from5; }
        set { from5 = value; }
    }

    public string To1
    {
        get { return to1; }
        set { to1 = value; }
    }
    public string To2
    {
        get { return to2; }
        set { to2 = value; }
    }
    public string To3
    {
        get { return to3; }
        set { to3 = value; }
    }
    public string To4
    {
        get { return to4; }
        set { to4 = value; }
    }
    public string To5
    {
        get { return to5; }
        set { to5 = value; }
    }
}
