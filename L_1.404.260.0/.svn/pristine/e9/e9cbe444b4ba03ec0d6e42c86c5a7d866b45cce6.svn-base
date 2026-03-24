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

public partial class docsSinMain : System.Web.UI.Page
{
    private static int polno;
    private static string MOF;

    private string dc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
        }   
    }

    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        dc = "Air";
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        dc = "Army";
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        dc = "Navy";
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        dc = "SF";
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        dc = "Police";
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        dc = "Air";
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        dc = "Army";
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        dc = "Navy";
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        dc = "Army";
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        dc = "Navy";
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        dc = "Air";
    }
    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        dc = "Navy";
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        dc = "Army";
    }
    protected void LinkButton13_Click1(object sender, EventArgs e)
    {
        dc = "Air";
    }
    protected void LinkButton15_Click1(object sender, EventArgs e)
    {
        dc = "Army";
    }
    protected void LinkButton14_Click1(object sender, EventArgs e)
    {
        dc = "Navy";
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


    //protected void LinkButton16_Click(object sender, EventArgs e)
    //{
    //    dc = "SF";
    //}
}
