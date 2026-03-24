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

public partial class letters_minimuthusin001 : System.Web.UI.Page
{
    private int polno;
    private int clmno;
    private int due;
    private int COM;
    private int Tbl;

    private string seclife;

    private double dueamt;

    PeriodicPayDetSel periosel;
    lpolhisread lpolread;
    polpersonalread polperobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            polno = this.PreviousPage.Polno;
            clmno = this.PreviousPage.Claimno;
        }
        string blank = "....................................................................................";
        try
        {
            periosel = new PeriodicPayDetSel(polno, clmno);
            lpolread = new lpolhisread(polno);
            polperobj = new polpersonalread(polno);

            due = periosel.Paydue;
            if (due == 0) { throw new Exception("Please Select Due!"); }
            dueamt = periosel.Payamt;
            COM = lpolread.Commence;
            Tbl = lpolread.Table;
            seclife = polperobj.Seclife;
            if (seclife == null) { seclife = blank; }

            this.lblClmno.Text = clmno.ToString();
            this.lblDue.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
            //this.lblDueamt.Text = String.Format("{0:N}", dueamt);
            if (Tbl == 39)
                this.lblDueamt.Text = "15%";
            if (Tbl == 38)
                this.lblDueamt.Text = "20%";
            this.lblPolno.Text = polno.ToString();

            this.lblSeclife.Text = seclife.ToString();
        }
        catch (Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
}
