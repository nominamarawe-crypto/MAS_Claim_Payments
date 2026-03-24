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

public partial class letters_minimuthudischgsin002 : System.Web.UI.Page
{
    private int polno;
    private int clmno;
    private int paydue;
    private int table;
    private int term;
    private int COM;
    private int matdate;
    private int percentage;

    private double dueamt;
    private double amtconv;

    private string amtwords;
    private string amtsin;
    private string flife;
    private string seclife;
    private string child;
    private string nomname, blank;
    private int dob;
    private int age;

    private int memoAprvDate;
    private int payMod;
    private double sumAss;

    PeriodicPayDetSel perioobj;
    lpolhisread tableobj;
    polpersonalread polperobj;
    DateDifference datediffobj;
    BonusCal bonuscalobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        blank = "....................................................................";
        if (!IsPostBack)
        {
            polno = this.PreviousPage.Polno;
            clmno = this.PreviousPage.Claimno;
            memoAprvDate = this.PreviousPage.MemAprDate;
            payMod = this.PreviousPage.PayMod;
            sumAss = this.PreviousPage.SumAss; 
        }
        try
        {
            if (polno != 0 && clmno != 0)
            {
                

                perioobj = new PeriodicPayDetSel(polno, clmno);
                tableobj = new lpolhisread(polno);
                polperobj = new polpersonalread(polno);
                bonuscalobj = new BonusCal();

                paydue = perioobj.Paydue;
                dueamt = perioobj.Payamt;
                table = tableobj.Table;
                COM=tableobj.Commence;
                term = tableobj.Term;
                flife = polperobj.Firstlife;
                seclife = polperobj.Seclife;
                child = polperobj.Child;
                nomname = polperobj.Nomname;
                dob = polperobj.Secdob;
                
                if (flife == null) { flife = blank; }
                if (seclife == null) { seclife = blank; }
                if (child == null) { child = seclife; }
                if (dob != 0)
                {
                    datediffobj = new DateDifference(dob,0);
                    age = datediffobj.Years;
                }
                matdate = int.Parse(Convert.ToString(int.Parse(COM.ToString().Substring(0, 4)) + term) + COM.ToString().Substring(4, 2));
                if (paydue == matdate)
                {
                    int mat_date = int.Parse(matdate.ToString() + COM.ToString().Substring(6, 2));

                    if ((table == 34 || table == 38 || table == 39 || table == 46 || table == 49) && (memoAprvDate > 20140410 || mat_date > 20140410))//Task 22225
                    {
                        double bonus = bonuscalobj.MinimuthuBonusCal(mat_date, COM, payMod, "I", table, sumAss, polno)[2];
                        dueamt += bonus;
                    }
                    else
                    {
                        double bonus = bonuscalobj.VestedBonus(polno, "M")[2];
                        dueamt += bonus;
                    }
                    lblBonus.Visible = true;
                }

                readAmountFunction readamtsinobj = new readAmountFunction();
                amtconv = dueamt*100;
                amtwords = amtconv.ToString().Substring(0, (amtconv.ToString().Length - 2))+"."+amtconv.ToString().Substring((amtconv.ToString().Length-2),2);
                amtsin = readamtsinobj.readAmount(amtwords, "SRI LANKAN RUPEES", "CENTS");   
                if  (table==39||table==49)
                {
                    percentage=15;
                }
                else if (table==46)
                {
                    percentage = 35;
                }
                else if (table==38)
                {
                    if (paydue == matdate) { percentage = 40; } else { percentage = 20; }                    
                }
            }
            else
            {
                throw new Exception("Cannot Create Discharge Letter!");
            }
        }
        catch (Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        this.lblPolno.Text = polno.ToString();
        this.Lblclmno.Text = clmno.ToString();
        this.lblPercentage.Text = percentage.ToString() + " %";
        this.lblDueamt.Text = String.Format("{0:N}", dueamt);
        this.lbldue.Text = paydue.ToString().Substring(0,4)+"/"+paydue.ToString().Substring(4,2)+"/"+COM.ToString().Substring(6,2);
        this.lblAmtwords.Text = amtsin.ToString();
        this.lblFirstlife.Text = flife.ToString();
        this.lblSecondlife.Text = child.ToString();
        if (age >= 18 && seclife!=null) { this.lblNomname.Text = child.ToString(); }
        else if (nomname != null) { this.lblNomname.Text = nomname.ToString(); }
        else { this.lblNomname.Text = blank; }
    }
 
}
