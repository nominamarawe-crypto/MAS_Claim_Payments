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

    private int polno;
    private string MOF;
    private string dc;

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
    private string copy5;
    private string copy6;
    private string copy7;
    private string copy8;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
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
            copy5 = this.PreviousPage.Copy5;
            copy6 = this.PreviousPage.Copy6;
            copy7 = this.PreviousPage.Copy7;
            copy8 = this.PreviousPage.Copy8;
        }

        this.lblourref.Text = cliamNo.ToString();
        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
        this.lblpolno.Text = polno.ToString();
        this.litname.Text = nod;
        this.litsoldierno.Text = soldierNo;
        this.litregiment.Text = regiment;
        this.lblplaceofdth.Text = placeOfDeath;
        this.litdtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
        this.litblabla1.Text = blabla1;
        this.litblabla2.Text = blabla2;
        this.litsoldier1.Text = soldierNo2;
        this.litsoldieno2.Text = soldierNo2;

        if (dc.Equals("Army"))
        {
            this.litname1.Text = "wOHCI ^jegqma yd f,aLK&";
            this.litad1.Text = "hqo yuqod jegqma yd f,aLK ldhH_d,h";
            this.litad2.Text = "hqo yuqod ckmoh";
            this.litad3.Text = "mkdf.dv";
            this.litad4.Text = "fydaud.u";

            this.litregidesc.Visible = true;
            this.litregiment.Visible = true;

            litcopyAr.Visible = true;
            litcopyAr1.Visible = true;
            litcopyAr2.Visible = true;
            litcopyAr3.Visible = true;
            litcopyAr4.Visible = true;
        }
        else if (dc.Equals("Navy"))
        {
            this.litname1.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
            this.litad1.Text = "kdjsl iqNidOl wOHCI fjkqjg";
            this.litad2.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
            this.litad3.Text = "fld,U 03";

            this.litregidesc.Visible = false;
            this.litregiment.Visible = false;
        }
        else if (dc.Equals("Air"))
        {
            this.litname1.Text = "rlaIK wxYNdr ks,OdrS";
            this.litad1.Text = "rlaIK wxYh";
            this.litad2.Text = "YS% ,xld .=jkayuqod uQ,ia:dkh";
            this.litad3.Text = "fld,U 02";

            this.litregidesc.Visible = false;
            this.litregiment.Visible = false;
        }

        this.lblcopy1.Text = copy1;
        this.lblcopy2.Text = copy2;
        this.lblcopy3.Text = copy3;
        this.lblcopy4.Text = copy4;
        this.lblcopy5.Text = copy5;
        this.lblcopy6.Text = copy6;
        this.lblcopy7.Text = copy7;
        this.lblcopy8.Text = copy8;

        if (PreviousPage.Status == 1)
        {
            Response.Clear();
            Response.Buffer = true;
            Page.EnableViewState = false;
            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "attachment; filename=" + polno + "_calldoldierno.doc");
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            this.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

    }
}
