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

public partial class cvouPrint001 : System.Web.UI.Page
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
    
    private long polno;
    private int clmno;
    private string vouno;
    private double payamt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            clmno = this.PreviousPage.Clmno;
            vouno = this.PreviousPage.Vouno;
            payamt = this.PreviousPage.Payamt;
        }

        if (!Page.IsPostBack)
        {
            try
            {
                if (polno > 0) { this.txtpolno.Text = polno.ToString(); }
                else { this.txtpolno.Text = ""; }

                ViewState["polno"] = polno;
                ViewState["clmno"] = clmno;
                ViewState["payamt"] = payamt;
                ViewState["vouno"] = vouno;
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("../EPage.aspx");
            }
        }
        else 
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
            if (ViewState["payamt"] != null) { payamt = double.Parse(ViewState["payamt"].ToString()); }
            if (ViewState["vouno"] != null) { vouno = ViewState["vouno"].ToString(); }         
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = long.Parse(this.txtpolno.Text);
        Server.Transfer("~/childProtVou/cvouPrint002.aspx",true);

    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";
    }

    public long Polno 
    {
        get { return polno; }
        set { polno = value; }
    }
    public int Clmno
    {
        get { return clmno; }
        set { clmno = value; }
    }
    public string Vouno
    {
        get { return vouno; }
        set { vouno = value; }
    }
    public double Payamt
    {
        get { return payamt; }
        set { payamt = value; }
    }


}
