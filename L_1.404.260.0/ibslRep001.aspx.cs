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

public partial class ibslRep001 : System.Web.UI.Page
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

    private int fromdate, todate, brcode, criteria;   
    //private double sumfrom, sumto;
    private string cause, polstat, cof;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            this.txttodate.Text = this.setDate()[0];

            //this.ddlcause.Items.Add(new ListItem("All", "*"));
            //this.ddlbrn.Items.Add(new ListItem("All", "*"));
        }
    }
    //protected void btnrest_Click(object sender, EventArgs e)
    //{
    //    this.txtbrcode.Text = "";
    //    this.txtfromdate.Text = "";
    //    //this.txtsumrangefrom.Text = "";
    //    //this.txtsumrangeto.Text = "";
    //    this.txttodate.Text = "";
        
    //}
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        fromdate = int.Parse(this.txtfromdate.Text);
        todate = int.Parse(this.txttodate.Text);
        if (this.ddlbrnall.SelectedIndex == 0) { brcode = 0; }
        else { brcode = int.Parse(this.txtbrcode.Text); }
        //sumfrom = double.Parse(this.txtsumrangefrom.Text);
        //sumto = double.Parse(this.txtsumrangeto.Text);
        if (this.ddlcauseall.SelectedIndex == 0) { cause = "*"; }
        else { cause = this.ddlcause.SelectedItem.Value; }
        polstat = this.ddliol.SelectedItem.Value;
        cof = this.ddlcof.SelectedItem.Value;
        criteria = int.Parse(this.ddlcriteria.SelectedItem.Value);
    }

    public int Fromdate {
        get { return fromdate; }
        set { fromdate = value; }
    }
    public int Todate
    {
        get { return todate; }
        set { todate = value; }
    }
    public int Brcode
    {
        get { return brcode; }
        set { brcode = value; }
    }
    public int Criteria
    {
        get { return criteria; }
        set { criteria = value; }
    }
    //public double Sumfrom
    //{
    //    get { return sumfrom; }
    //    set { sumfrom = value; }
    //}
    //public double Sumto
    //{
    //    get { return sumto; }
    //    set { sumto = value; }
    //}
    public string Cause
    {
        get { return cause; }
        set { cause = value; }
    }
    public string Polstat
    {
        get { return polstat; }
        set { polstat = value; }
    }
    public string Cof
    {
        get { return cof; }
        set { cof = value; }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtbrcode.Text = this.ddlbrn.SelectedItem.Value.ToString();
    }
    protected void ddlbrnall_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlbrnall.SelectedIndex == 0) { this.ddlbrn.Enabled = false; this.txtbrcode.Text = "0"; }
        else { this.ddlbrn.Enabled = true; }
    }
    protected void ddlcauseall_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlcauseall.SelectedIndex == 0) { this.ddlcause.Enabled = false; }
        else { this.ddlcause.Enabled = true; }
    }
}
