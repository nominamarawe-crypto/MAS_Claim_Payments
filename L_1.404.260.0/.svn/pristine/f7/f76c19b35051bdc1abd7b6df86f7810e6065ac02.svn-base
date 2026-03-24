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

public partial class docsCallPolnoSin001 : System.Web.UI.Page
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

    private string name;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private string deceasedName;
    private string docs01;
    private string docs02;
    private string docs03;


    protected void Page_Load(object sender, EventArgs e)
    {
        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
        //this.lblourref.Text = epfNum;
        this.lblourref.Text = Session["EPFNum"].ToString();
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        name = this.txtname.Text;
        ad1 = this.txtad1.Text;
        ad2 = this.txtad2.Text;
        ad3 = this.txtad3.Text;
        ad4 = this.txtad4.Text;       
        docs01 = this.txtdoc1.Text;
        docs02 = this.txtdoc2.Text;
        docs03 = this.txtdoc3.Text;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Ad1
    {
        get { return ad1; }
        set { ad1 = value; }
    }
    public string Ad2
    {
        get { return ad2; }
        set { ad2 = value; }
    }
    public string Ad3
    {
        get { return ad3; }
        set { ad3 = value; }
    }
    public string Ad4
    {
        get { return ad4; }
        set { ad4 = value; }
    }
    public string DeceasedName
    {
        get { return deceasedName; }
        set { deceasedName = value; }
    }
    public string Docs01
    {
        get { return docs01; }
        set { docs01 = value; }
    }
    public string Docs02
    {
        get { return docs02; }
        set { docs02 = value; }
    }
    public string Docs03
    {
        get { return docs03; }
        set { docs03 = value; }
    }

}
