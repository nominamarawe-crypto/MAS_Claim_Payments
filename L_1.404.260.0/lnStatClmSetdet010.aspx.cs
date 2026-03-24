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

public partial class lnStatClmSetdet010 : System.Web.UI.Page
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

    //private int yearMonth;
    private int fromDate;
    private int toDate;
    private int brcode;

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
        brcode = int.Parse(this.txtbrn.Text);
    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtfromdate.Text = "";
        this.txttodate.Text = "";
        this.txtbrn.Text = "";
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
    public int Brcode
    {
        get { return brcode; }
        set { brcode = value; }
    }

    protected bool brCodeComparison(string sessionBrn, string ipaddr)
    {
        // sessionBrn is the branch cde retrieved from the session
        // pass the ipaddress into the method converted into a string
        // returns a boolean value depending on the result of comparison

        bool valid = false;
        // if (ipaddr.Equals("127.0.0.1")) { ipaddr = "10.1.17.5"; }
        // above is your IP


        string[] arr = ipaddr.Split('.');
        DataManager dm = new DataManager();

        int dbBrcode = 0;
        int brcode = 0;

        string brnIPselect = "select brncd from genpay.branchip where brnip='" + ipaddr + "'";
        if (dm.existRecored(brnIPselect) != 0)
        {
            dm.readSql(brnIPselect);
            OracleDataReader brcodeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (brcodeReader.Read())
            {
                if (!brcodeReader.IsDBNull(0)) { dbBrcode = brcodeReader.GetInt32(0); }
            }
            brcodeReader.Close();
            brcodeReader.Dispose();

            if (arr[1].Equals("216")) { brcode = 16; } else { brcode = dbBrcode; }
        }
        else
        {
            brcode = int.Parse(arr[1]);
            if (brcode == 1) { brcode = 10; }
            else if (brcode == 216) { brcode = 16; }
        }

        if (int.Parse(sessionBrn) != brcode) { valid = false; } else { valid = true; }

        dm.connclose();
        return valid;
    }

}
