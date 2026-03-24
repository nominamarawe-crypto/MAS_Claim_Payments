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

public partial class docsCallDutySin001 : System.Web.UI.Page
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

    private int polno;
    private string MOF;
    private string dc;
    private long cliamNo;

    private string nod;
    private string soldierNo;
    private string regiment;
    private string placeOfDeath;
    private string informer;
    private string reason;
    private string policeAd;

    private string copy1;
    private string copy2;
    private string copy3;
    private string copy4;
    private string copy5;
    private string copy6;
    private string copy7;
    private string copy8;

    DataManager dm;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {

                this.lblpolno.Text = polno.ToString();

                string DNOD = "";
                int dateofdeath = 0;
                string LANG = "S";
                int INDEX = 0;
                string dthintSelect = "select DNOD, DCLM, ddtofdth from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                        if (!dthintReader.IsDBNull(2)) { dateofdeath = dthintReader.GetInt32(2); }
                    }
                    dthintReader.Close();
                }

                this.lblourref.Text = cliamNo.ToString();

                this.lbdtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
              //  this.txtnod.Text = DNOD;

                #region Load Claimnt Address (Modified by Kumudu)
                string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX=" + INDEX + "";
                if (dm.existRecored(dclmAddressSelect) != 0)
                {
                    txtcopy1.Text = "oekquz  fokakd";
                    dm.readSql(dclmAddressSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { txtcopy5.Text = dthintReader.GetString(0); }
                        else { txtcopy5.Text = ""; }
                        if (!dthintReader.IsDBNull(1)) { txtcopy6.Text = dthintReader.GetString(1); }
                        else { txtcopy6.Text = ""; }
                        if (!dthintReader.IsDBNull(2)) { txtcopy7.Text = dthintReader.GetString(2); }
                        else { txtcopy7.Text = ""; }
                        if (!dthintReader.IsDBNull(3)) { txtcopy8.Text = dthintReader.GetString(3); }
                        else { txtcopy8.Text = ""; }
                        if (!dthintReader.IsDBNull(4)) { txtcopy8.Text = dthintReader.GetString(3) + dthintReader.GetString(4); }
                        else { txtcopy8.Text = dthintReader.GetString(3); }

                    }

                }

                #endregion

                #region Load relevant Security Data (Modified by Kumudu)
                if (dc.Equals("Air"))
                {

                    this.litad1.Text = "rlaIK wxYNdr ks,OdrS";
                    this.litad2.Text = "rlaIK wxYh";
                    this.litad3.Text = "YS% ,xld .=jkayuqod uQ,ia:dkh";
                    this.litad4.Text = "02";

                    this.litSoldierNo.Text = ".=jkaNg wxlh(";
                   // this.txtpoliceadd.Visible = false;
                    this.lblregiment.Visible = false;
                    this.txtregiment.Visible = false;
                }
                else if (dc.Equals("Army"))
                {

                    this.litad1.Text = "wOHCI";
                    this.litad2.Text = "hqo yuqod iQNidOl wOHCI uKav,h";
                    this.litad3.Text = "wxl 05  23 jk mgqu.";
                    this.litad4.Text = "03";

                    this.litSoldierNo.Text = "fin, wxlh(";
                   // this.txtpoliceadd.Visible = false;
                    this.lblregiment.Visible = true;
                    this.txtregiment.Visible = true;
                }
                else if (dc.Equals("Navy"))
                {

                    this.litad1.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
                    this.litad2.Text = "kdjsl iqNidOl wOHCI fjkqjg";
                    this.litad3.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
                    this.litad4.Text = "";

                    this.litSoldierNo.Text = "fin, wxlh(";

                   // this.txtpoliceadd.Visible = false;
                    this.lblregiment.Visible = false;
                    this.txtregiment.Visible = false;
                }
                else if (dc.Equals("Police"))
                {

                    this.litad1.Text = "iyldr fmd,sia wOsldrS";
                    this.litad2.Text = "fmd,sia iqNidOl fldgzGdYh";
                    this.litad3.Text = "f;jk uy, 'uOHu iqNidOl uOHia:dk f.dvke.s,a,";
                    this.litad4.Text = "wxl 331 Tz,algz udj;";
                    litno.Text = "01";

                    this.litSoldierNo.Text = "fmd,sia fldia;dm,a  wxlh(";

                  //  this.txtpoliceadd.Visible = true;

                    this.lblregiment.Visible = false;
                    this.txtregiment.Visible = false;
                }
                else if (dc.Equals("SF"))
                {

                    this.litad1.Text = "wOHCI";
                    this.litad2.Text = "jsfYaI ldhH_ n,ld uQ,ia:dkh";
                    this.litad3.Text = "223 fn!oaOdf,dal udj;";
                    this.litad4.Text = "07";

                    this.litSoldierNo.Visible = false;
                    this.txtsoldierno.Visible = false;

                    this.lblregiment.Visible = false;
                    this.txtregiment.Visible = false;
                }
                #endregion

                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["dc"] = dc;
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }

        }
        else 
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["dc"] != null) { dc = ViewState["dc"].ToString(); }
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        nod = this.txtnod.Text.Trim();
        soldierNo = this.txtsoldierno.Text.Trim();
        placeOfDeath = this.txtplaceofdth.Text.Trim();
        informer = this.txtinformer.Text.Trim();
        reason = this.txtreason.Text.Trim();
       // policeAd = this.txtpoliceadd.Text.Trim();

        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
        copy5 = this.txtcopy5.Text.Trim();
        copy6 = this.txtcopy6.Text.Trim();
        copy7 = this.txtcopy7.Text.Trim();
        copy8 = this.txtcopy8.Text.Trim();
        regiment = this.txtregiment.Text.Trim();

        Server.Transfer("~/letters/docsCallDutySin002.aspx",true);
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
    public string Informer
    {
        get { return informer; }
        set { informer = value; }
    }
    public string Reason
    {
        get { return reason; }
        set { reason = value; }
    }
    public string PoliceAd
    {
        get { return policeAd; }
        set { policeAd = value; }
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

    private int status=0;

    public int Status
    {
        get { return status; }
        set { status = value; }
    }


    protected void txtinformer_TextChanged(object sender, EventArgs e)
    {
        litInformer2.Text = txtinformer.Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        status = 1;
        nod = this.txtnod.Text.Trim();
        soldierNo = this.txtsoldierno.Text.Trim();
        placeOfDeath = this.txtplaceofdth.Text.Trim();
        informer = this.txtinformer.Text.Trim();
        reason = this.txtreason.Text.Trim();
        // policeAd = this.txtpoliceadd.Text.Trim();

        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
        copy5 = this.txtcopy5.Text.Trim();
        copy6 = this.txtcopy6.Text.Trim();
        copy7 = this.txtcopy7.Text.Trim();
        copy8 = this.txtcopy8.Text.Trim();
        regiment = this.txtregiment.Text.Trim();
    }
}
