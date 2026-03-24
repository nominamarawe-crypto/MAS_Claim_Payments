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

public partial class dthOut001 : System.Web.UI.Page
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

    private int startdate;   
    private int enddate;   
    private int brCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            this.txtEndDate.Text = this.setDate()[0];
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        brCode = int.Parse(this.txtbrn.Text);
        startdate = int.Parse(this.txtStartDate.Text);
        enddate = int.Parse(this.txtEndDate.Text);      
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtbrn.Text = "";
        this.txtStartDate.Text = "";
        this.txtEndDate.Text = "";     
    }

    public int Startdate
    {
        get { return startdate; }
        set { startdate = value; }
    }
    public int Enddate
    {
        get { return enddate; }
        set { enddate = value; }
    }
    public int BrCode
    {
        get { return brCode; }
        set { brCode = value; }
    }

}
