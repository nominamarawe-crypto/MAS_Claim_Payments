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

public partial class docsCallPolnoArmySin002 : System.Web.UI.Page
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
    private string soldierNo;
    private string leterdate;
    private string letterRef;
    private string epfNum;
    //private int Claim_No;
    //private int ProposalNo;
    //private int PolNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            name = this.PreviousPage.Name;
            ad1 = this.PreviousPage.Ad1;
            ad2 = this.PreviousPage.Ad2;
            ad3 = this.PreviousPage.Ad3;
            ad4 = this.PreviousPage.Ad4;
            deceasedName = this.PreviousPage.DeceasedName;
            soldierNo = this.PreviousPage.SoldierNo;
            leterdate = this.PreviousPage.Leterdate;
            letterRef = this.PreviousPage.LetterRef;
            epfNum = this.PreviousPage.YourRef;
            //ProposalNo = this.PreviousPage.PROPOSALNO;
            //PolNo = this.PreviousPage.POLICYNO;
        }

        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
        this.lblourref.Text = epfNum;

        this.litname.Text = name;
        this.litad1.Text = ad1;
        this.litad2.Text = ad2;
        this.litad3.Text = ad3;
        this.litad4.Text = ad4;
        this.litdeceasename.Text = deceasedName;
        this.litSoldierNo.Text = soldierNo;
        this.litdate.Text = leterdate;
        this.litltrref.Text = letterRef;
        this.lblourref.Text = epfNum;
        //this.litpolno.Text = PolNo.ToString();
        //this.litprop.Text = ProposalNo.ToString();
    }
}
