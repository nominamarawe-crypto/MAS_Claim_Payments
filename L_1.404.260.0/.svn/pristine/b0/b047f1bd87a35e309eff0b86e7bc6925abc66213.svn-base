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

public partial class docsCallSoldiernodiffSin001 : System.Web.UI.Page
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
    private int dateofdeath;
    private string blabla1;
    private string blabla2;
    private string soldierNo2;
    private string soldierNo3;

    private string copy1;
    private string copy2;
    private string copy3;
    private string copy4;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;
        }

        try 
        {
            dm = new DataManager();

            this.lblpolno.Text = polno.ToString();

            string DNOD = "";
            
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

            this.txtnod.Text = DNOD;
            this.lblourref.Text = cliamNo.ToString();
            this.lbldtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);

            if (dc.Equals("Army"))
            {
                this.lblname.Text = "wOHCI ^jegqma yd f,aLK&";
                this.lblad1.Text = "hqo yuqod jegqma yd f,aLK ldhH_d,h";
                this.lblad2.Text = "hqo yuqod ckmoh";
                this.lblad3.Text = "mkdf.dv";
                this.lblad4.Text = "fydaud.u";

                this.lblregiment.Visible = true;
                this.txtregiment.Visible = true;
            }
            else if (dc.Equals("Navy"))
            {
                this.lblname.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
                this.lblad1.Text = "kdjsl iqNidOl wOHCI fjkqjg";
                this.lblad2.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
                this.lblad3.Text = "fld,U 03";

                this.lblregiment.Visible = false;
                this.txtregiment.Visible = false;
            }
            else if (dc.Equals("Air"))
            {
                this.lblname.Text = "rlaIK wxYNdr ks,OdrS";
                this.lblad1.Text = "rlaIK wxYh";
                this.lblad2.Text = "YS% ,xld .=jkayuqod uQ,ia:dkh";
                this.lblad3.Text = "fld,U 02";

                this.lblregiment.Visible = false;
                this.txtregiment.Visible = false;
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

    protected void btnprint_Click(object sender, EventArgs e)
    {
        nod = this.txtnod.Text.Trim();
        soldierNo = this.txtsoldierno.Text.Trim();
        placeOfDeath = this.txtplaceofDth.Text.Trim();      
        regiment = this.txtregiment.Text.Trim();
        blabla1 = this.txtblabla.Text.Trim();
        blabla2 = this.txtblabla2.Text.Trim();
        soldierNo2 = this.txtsoldier2.Text.Trim();
        soldierNo3 = this.txtsoldier3.Text.Trim();   

        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
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
    public int Dateofdeath
    {
        get { return dateofdeath; }
        set { dateofdeath = value; }
    }
    public long CliamNo
    {
        get { return cliamNo; }
        set { cliamNo = value; }
    }
    public string Blabla1
    {
        get { return blabla1; }
        set { blabla1 = value; }
    }
    public string Blabla2
    {
        get { return blabla2; }
        set { blabla2 = value; }
    }
    public string SoldierNo2
    {
        get { return soldierNo2; }
        set { soldierNo2 = value; }
    }
    public string SoldierNo3
    {
        get { return soldierNo3; }
        set { soldierNo3 = value; }
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
   
}
