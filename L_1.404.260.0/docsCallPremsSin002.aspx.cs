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

public partial class docsCallPremsSin002 : System.Web.UI.Page
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
    private string prem;
    private string gebasa;
    private int DCO;
    private int due;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;

            nod = this.PreviousPage.Nod;
            soldierNo = this.PreviousPage.SoldierNo;
            regiment = this.PreviousPage.Regiment;
            placeOfDeath = this.PreviousPage.PlaceOfDeath;
            cliamNo = this.PreviousPage.CliamNo;
            prem = this.PreviousPage.Prem;
            DCO = this.PreviousPage.dCO;
            due = this.PreviousPage.Due;
            gebasa = this.PreviousPage.Gebasa;

            copy1 = this.PreviousPage.Copy1;
            copy2 = this.PreviousPage.Copy2;
            copy3 = this.PreviousPage.Copy3;
            copy4 = this.PreviousPage.Copy4;
            copy5 = this.PreviousPage.Copy5;
            copy6 = this.PreviousPage.Copy6;
            copy7 = this.PreviousPage.Copy7;
            copy8 = this.PreviousPage.Copy8;

            from1 = this.PreviousPage.From1;
            from2 = this.PreviousPage.From2;
            from3 = this.PreviousPage.From3;
            from4 = this.PreviousPage.From4;
            from5 = this.PreviousPage.From5;

            to1 = this.PreviousPage.To1;
            to2 = this.PreviousPage.To2;
            to3 = this.PreviousPage.To3;
            to4 = this.PreviousPage.To4;
            to5 = this.PreviousPage.To5;

        }

        this.lblourref.Text = cliamNo.ToString();
        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
        this.lblpolno.Text = polno.ToString();
        this.lblnod.Text = nod;
        this.lblsoldierno.Text = soldierNo;
        this.lblregiment.Text = regiment;
        this.lblplaceofdth.Text = placeOfDeath;
        this.lblgebasa.Text = gebasa;
        this.lblprem.Text = prem;
        this.lbldco.Text = DCO.ToString().Substring(0, 4) + "/" + DCO.ToString().Substring(4, 2) + "/" + DCO.ToString().Substring(6, 2);
        this.lblexitym.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2);

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
            this.lblad3.Text = "fld,U 03";
        }

        this.lblcopy1.Text = copy1;
        this.lblcopy2.Text = copy2;
        this.lblcopy3.Text = copy3;
        this.lblcopy4.Text = copy4;
        this.lblcopy5.Text = copy5;
        this.lblcopy6.Text = copy6;
        this.lblcopy7.Text = copy7;
        this.lblcopy8.Text = copy8;

        this.lblfrom1.Text = from1;
        this.lblfrom2.Text = from2;
        this.lblfrom3.Text = from3;
        this.lblfrom4.Text = from4;
        this.lblfrom5.Text = from5;

        this.lblto1.Text = to1;
        this.lblto2.Text = to2;
        this.lblto3.Text = to3;
        this.lblto4.Text = to4;
        this.lblto5.Text = to5;

    }
}
