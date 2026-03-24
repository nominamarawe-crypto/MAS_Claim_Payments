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

public partial class legalHieres001 : System.Web.UI.Page
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
    private string MOF, flag;

    private bool nomiLives;
    private bool married;
    private bool spouceAilve;
    private bool motherAlive;
    private bool fatherAlive;
    private bool livingChildren;
    private int numOfchildren;
    private bool livingBroSis;
    private int numOfBroSis;

    private bool valid;
    DataManager dm;

    private double totamount;
    private double outAmt;
    private long claimno;
    private int pageflag=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string test = Request.QueryString["polno"];
        
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            mof = this.PreviousPage.mos01;

        }
        else if ((test != null) && (!test.Equals("")))
        {
            polno = int.Parse(Request.QueryString["polno"]);
            if (Request.QueryString["theMof"] != null) { MOF = (string)Request.QueryString["theMof"]; }
            if (Request.QueryString["pageflag"] != null) { pageflag = int.Parse(Request.QueryString["pageflag"].ToString()); }
            if (Request.QueryString["flag"] != null) { flag = Request.QueryString["flag"].ToString(); }
            if (Request.QueryString["totamount"] != null) { totamount = double.Parse(Request.QueryString["totamount"].ToString()); }
            if (Request.QueryString["outAmt"] != null) { outAmt = double.Parse(Request.QueryString["outAmt"].ToString()); }
            if (Request.QueryString["claimno"] != null) { claimno = long.Parse(Request.QueryString["claimno"].ToString()); }
         
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                if (flag != null && !flag.Equals("")) { this.btnexit.Visible = false; }
                else { this.btnexit.Visible = true; }

                string lhSelect = "select * from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' ";
                if (dm.existRecored(lhSelect) != 0)
                {
                    valid = true;
                }
                else { valid = false; }

                if (valid) { this.btnUpd.Visible = true; }
                else { this.btnUpd.Visible = false; }

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["flag"] = flag;
                ViewState["pageflag"] = pageflag;
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
            //if (valid) { Response.Redirect("legalHieres003.aspx?polno="+polno+"&theMof="+MOF); }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["pageflag"] != null) { pageflag = int.Parse(ViewState["pageflag"].ToString()); }
        }
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.chkNomLive.Checked) { nomiLives = true; }
            if (this.chkMarried.Checked) { married = true; }
            if (this.chkSpAl.Checked) { spouceAilve = true; }
            if (this.chkMthAl.Checked) { motherAlive = true; }
            if (this.chkFthAl.Checked) { fatherAlive = true; }
            if (this.chkChildYN.Checked) { LivingChildren = true; }
            if (this.chkBroYn.Checked) { livingBroSis = true; }

            numOfchildren = int.Parse(this.txtChildrenNum.Text.Trim());
            numOfBroSis = int.Parse(this.txtBroSysNum.Text.Trim());

            if (!LivingChildren && (numOfchildren > 0)) {
                this.CV.IsValid = false;
                CV.ErrorMessage = "Please Check the Living Children Yes No Option.";
            }
            if (LivingChildren && (numOfchildren == 0))
            {
                this.CV.IsValid = false;
                CV.ErrorMessage = "Please Check the Living Children Yes No Option.";
            }

            if (!livingBroSis && (numOfBroSis > 0))
            {
                this.CV.IsValid = false;
                CV.ErrorMessage = "Please Check the Living Brothers/Sisters Yes No Option.";
            }
            if (livingBroSis && (numOfBroSis == 0))
            {
                this.CV.IsValid = false;
                CV.ErrorMessage = "Please Check the Living Brothers/Sisters Yes No Option.";
            }
            
        }
        catch (Exception ex) {

            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }


    }

    public bool NomiLives{
        get { return nomiLives; }
        set { nomiLives = value; }
    }
    public bool Married
    {
        get { return married; }
        set { married = value; }
    }
    public bool SpouceAilve
    {
        get { return spouceAilve; }
        set { spouceAilve = value; }
    }
    public bool MotherAlive
    {
        get { return motherAlive; }
        set { motherAlive = value; }
    }
    public bool FatherAlive
    {
        get { return fatherAlive; }
        set { fatherAlive = value; }
    }
    public bool LivingChildren
    {
        get { return livingChildren; }
        set { livingChildren = value; }
    }
    public int NumOfchildren
    {
        get { return numOfchildren; }
        set { numOfchildren = value; }
    }
    public bool LivingBroSis
    {
        get { return livingBroSis; }
        set { livingBroSis = value; }
    }
    public int NumOfBroSis
    {
        get { return numOfBroSis; }
        set { numOfBroSis = value; }
    }   

    public int Polno {
        get { return polno; }
        set { polno = value; }
    }
    public string mof {
        get { return MOF; }
        set { MOF = value; }
    }
    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public double OutAmt
    {
        get { return outAmt; }
        set { outAmt = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }  
    public string Flag
    {
        get { return flag; }
        set { flag = value; }
    }
    public int Pageflag
    {
        get { return pageflag; }
        set { pageflag = value; }
    }


    protected void btnUpd_Click(object sender, EventArgs e)
    {

    }
}
