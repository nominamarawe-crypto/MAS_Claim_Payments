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

    private  int polno;
    private  string MOF;
    private  string dc;

    private long cliamNo;
    private string nod;
    private string soldierNo;
    private string regiment;
    private int Dateof_death;
    private string placeOfDeath;
    private string prem;
    private string gebasa;
    private int DCO;
    private int due;
    private string LpayDate;

    private string copy1;
    private string copy2;
    private string copy3;
    private string copy4;
    private string copy5;
    private string copy6;
    private string copy7;
    //private string copy8;

    private ArrayList Monthly_Ins;

    


    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (PreviousPage != null) //&& PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;

            nod = this.PreviousPage.Nod;
            soldierNo = this.PreviousPage.SoldierNo;
            regiment = this.PreviousPage.Regiment;
            placeOfDeath = this.PreviousPage.PlaceOfDeath;
            Dateof_death = this.PreviousPage.DateofDeath;
            cliamNo = this.PreviousPage.CliamNo;
            prem = this.PreviousPage.Prem;
            DCO = this.PreviousPage.dCO;
            due = this.PreviousPage.Due;
            LpayDate = this.PreviousPage.LastPayDate;
          

            gebasa = this.PreviousPage.Gebasa;

            copy1 = this.PreviousPage.Copy1;
            copy2 = this.PreviousPage.Copy2;
            copy3 = this.PreviousPage.Copy3;
            copy4 = this.PreviousPage.Copy4;
            copy5 = this.PreviousPage.Copy5;
            copy6 = this.PreviousPage.Copy6;
            copy7 = this.PreviousPage.Copy7;
            //copy8 = this.PreviousPage.Copy8;

            Monthly_Ins = new ArrayList();
            Monthly_Ins = this.PreviousPage.MONTHLYINST;
            if (Monthly_Ins !=null)
            {
                CreateDynTextBox(Monthly_Ins);
            }
        }

        this.lblourref.Text = cliamNo.ToString();
        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
        this.litpolno.Text = polno.ToString();
        this.litNameofDth.Text = nod;
        this.litsoldierNo.Text = soldierNo;
        this.litRegiName.Text = regiment;
        this.litplaceofdt.Text = placeOfDeath;
        this.litdtofdeath.Text = Dateof_death.ToString().Substring(0,4)+"/"+Dateof_death.ToString().Substring(4,2)+"/"+Dateof_death.ToString().Substring(6,2);
        this.litgebasa.Text = gebasa;
        this.litprem.Text = prem;
        this.lbldco.Text = DCO.ToString().Substring(0, 4) + "/" + DCO.ToString().Substring(4, 2) + "/" + DCO.ToString().Substring(6, 2);
        this.lblexitym.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2);
        this.lblLpayDate.Text = LpayDate.ToString().Substring(0,4)+"/"+LpayDate.ToString().Substring(4,2)+"/"+LpayDate.ToString().Substring(6,2);

        if (dc.Equals("Army"))
        {
            this.litname.Text = "wOHCI ^jegqma yd f,aLK&";
            this.litad1.Text = "hqo yuqod jegqma yd f,aLK ldhH_d,h";
            this.litad2.Text = "hqo yuqod ckmoh";
            this.litad3.Text = "mkdf.dv";
            this.litad4.Text = "fydaud.u";

            litDir.Visible = true;
            Literal1.Visible=true;
            litSubasadaka.Visible=true;
            litadd.Visible = true;
            Literal2.Visible = true;
            Ltadd2.Visible = true;
            lblcopy6.Visible = true;

        }
        else if (dc.Equals("Navy"))
        {
            this.litname.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
            this.litad1.Text = "kdjsl iqNidOl wOHCI fjkqjg";
            this.litad2.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
            this.litCol.Visible = true;
            this.litad3.Text = " ";
        }

        else if (dc.Equals("Air"))
        {
            this.litname.Text = "rlaIK wxYNdr ks,Odrs";
            this.litad1.Text = "rlaIK wxYh";
            this.litad2.Text = "Y%S ,xld .+jkayuqod uQ,ia:dkh";
            this.litCol.Visible = true;
            this.litad3.Text = " ";
        }
        this.lblcopy1.Text = copy1;
        this.lblcopy2.Text = copy2;
        this.lblcopy3.Text = copy3;
        this.lblcopy4.Text = copy4;
        this.lblcopy5.Text = copy5;
        this.Lbtext.Text = copy6;
        this.lblcopy6.Text = copy7;
        //this.lblcopy8.Text = copy8;

        if (PreviousPage.State == 1)
        {
            Response.Clear();
            Response.Buffer = true;
            Page.EnableViewState = false;
            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "attachment; filename=" + polno + "_callprems.doc");
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            this.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

    }

    #region Generate Text Boxes for Defauul Prem1ums
    public void CreateDynTextBox(ArrayList MonIns)
    {
        for (int i = 0; i < (MonIns.Count); i++)
        {

            TableRow tr = new TableRow();
            tblMonthsToPay.Rows.Add(tr);

            TableCell tc1 = new TableCell();
            Label Dynlbl = new Label();
            Dynlbl.ID = "Dynlbl" + i.ToString();
            Dynlbl.Text = MonIns[i].ToString();
            Dynlbl.ControlStyle.Font.Name = "Trebuchet MS";
            Dynlbl.ControlStyle.Font.Size = 11;
            Dynlbl.Width = 50;
            tc1.HorizontalAlign = HorizontalAlign.Center;
            tc1.Controls.Add(Dynlbl);
            tr.Cells.Add(tc1);    

            TableCell tc2 = new TableCell();
            Label Dynlbl1 = new Label();
            Dynlbl1.ID = "Dynlbl1" + i.ToString();
            Dynlbl1.Text = "isg";
            Dynlbl1.ControlStyle.Font.Name = "Sandaya";
            Dynlbl1.ControlStyle.Font.Size = 11;
            Dynlbl1.Width = 50;
            tc2.HorizontalAlign = HorizontalAlign.Center;
            tc2.Controls.Add(Dynlbl1);
            tr.Cells.Add(tc2);

            TableCell tc3 = new TableCell();
            Label Dynlbl2 = new Label();
            Dynlbl2.ID = "Dynlbl2" + i.ToString();
            Dynlbl2.Text = MonIns[i + 1].ToString();
            Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
            Dynlbl2.ControlStyle.Font.Size = 11;
            Dynlbl2.Width = 50;
            tc3.HorizontalAlign = HorizontalAlign.Center;
            tc3.Controls.Add(Dynlbl2);
            tr.Cells.Add(tc3);    


            TableCell tc4 = new TableCell();
            Label Dynlbl3 = new Label();
            Dynlbl3.ID = "Dynlbl13" + i.ToString();
            Dynlbl3.Text = "olajd";
            Dynlbl3.ControlStyle.Font.Name = "Sandaya";
            Dynlbl3.ControlStyle.Font.Size = 11;
            Dynlbl3.Width = 50;
            tc4.HorizontalAlign = HorizontalAlign.Center;
            tc4.Controls.Add(Dynlbl3);
            tr.Cells.Add(tc4);

            tblMonthsToPay.Rows.Add(tr);
            // tblDynamic.Rows.Add(tr);
            i++;

        }
    }
    #endregion
}
