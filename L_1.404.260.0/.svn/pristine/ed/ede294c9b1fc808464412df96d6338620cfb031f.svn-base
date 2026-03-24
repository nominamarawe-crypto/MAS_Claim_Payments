using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class FileScanningReport001 : System.Web.UI.Page
{
    private int requestedDate;
    private int requestedBranch;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.txtRequestedDate.Text = this.setDate()[0];
        }
    }

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
        
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        requestedDate = this.txtRequestedDate.Text != null ? int.Parse(this.txtRequestedDate.Text) : 0;
        requestedBranch = int.Parse(this.ddlBrcod.SelectedValue);

        if (requestedDate == 0 || requestedDate.ToString().Length != 8 || requestedDate > int.Parse(this.setDate()[0]))
        {
            this.cv.IsValid = false;
            this.cv.ErrorMessage = "Check Requested Date!";
            return;
        }
        else
        {
            Server.Transfer("~/FileScanningReport002.aspx", false);
        }
    }

    public int RequestedDate
    {
        get { return requestedDate; }
        set { requestedDate = value; }
    }
    public int RequestedBranch
    {
        get { return requestedBranch; }
        set { requestedBranch = value; }
    }
}