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

public partial class docsCallSoldiernodiffSin002 : System.Web.UI.Page
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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;

            cliamNo = this.PreviousPage.CliamNo;
            nod = this.PreviousPage.Nod;
            soldierNo = this.PreviousPage.SoldierNo;
            regiment = this.PreviousPage.Regiment;
            placeOfDeath = this.PreviousPage.PlaceOfDeath;
            dateofdeath = this.PreviousPage.Dateofdeath;
            blabla1 = this.PreviousPage.Blabla1;
            blabla2 = this.PreviousPage.Blabla2;
            soldierNo2 = this.PreviousPage.SoldierNo2;
            soldierNo3 = this.PreviousPage.SoldierNo3;

            copy1 = this.PreviousPage.Copy1;
            copy2 = this.PreviousPage.Copy2;
            copy3 = this.PreviousPage.Copy3;
            copy4 = this.PreviousPage.Copy4;        
        
        }

        this.lblourref.Text = cliamNo.ToString();
        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
        this.lblpolno.Text = polno.ToString();
        this.lblnod.Text = nod;
        this.lblsoldierno.Text = soldierNo;
        this.lblregiment.Text = regiment;
        this.lblplaceofdth.Text = placeOfDeath;
        this.lbldtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);

        this.lblblabla.Text = blabla1;
        this.lblblabla2.Text = blabla2;
        this.lblsoldier1.Text = soldierNo2;
        this.lblsoldier2.Text = soldierNo2;

        if (dc.Equals("Army"))
        {
            this.lblname.Text = "wOHCI ^jegqma yd f,aLK&";
            this.lblad1.Text = "hqo yuqod jegqma yd f,aLK ldhH_d,h";
            this.lblad2.Text = "hqo yuqod ckmoh";
            this.lblad3.Text = "mkdf.dv";
            this.lblad4.Text = "fydaud.u";

            this.lblregimentDESC.Visible = true;
            this.lblregiment.Visible = true;
        }
        else if (dc.Equals("Navy"))
        {
            this.lblname.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
            this.lblad1.Text = "kdjsl iqNidOl wOHCI fjkqjg";
            this.lblad2.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
            this.lblad3.Text = "fld,U 03";

            this.lblregimentDESC.Visible = false;
            this.lblregiment.Visible = false;
        }
        else if (dc.Equals("Air"))
        {
            this.lblname.Text = "rlaIK wxYNdr ks,OdrS";
            this.lblad1.Text = "rlaIK wxYh";
            this.lblad2.Text = "YS% ,xld .=jkayuqod uQ,ia:dkh";
            this.lblad3.Text = "fld,U 02";

            this.lblregimentDESC.Visible = false;
            this.lblregiment.Visible = false;
        }

        this.lblcopy1.Text = copy1;
        this.lblcopy2.Text = copy2;
        this.lblcopy3.Text = copy3;
        this.lblcopy4.Text = copy4;




    }
}
