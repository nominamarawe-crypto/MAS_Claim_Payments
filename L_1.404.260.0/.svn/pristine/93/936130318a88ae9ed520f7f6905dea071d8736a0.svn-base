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

public partial class lnStatClmSetsum010 : System.Web.UI.Page
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

    private int fromDate;
    private int toDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.txttodate.Text = this.setDate()[0];
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        fromDate = int.Parse(this.txtfromdate.Text);
        toDate = int.Parse(this.txttodate.Text);
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtfromdate.Text = "";
        this.txttodate.Text = "";
    }

    public int FromDate
    {
        get { return fromDate; }
        set { fromDate = value; }
    }
    public int ToDate
    {
        get { return toDate; }
        set { toDate = value; }
    }
}
