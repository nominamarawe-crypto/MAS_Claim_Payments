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

public partial class vouReprint004 : System.Web.UI.Page
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
    private long surrenderno;
    private string LSUVNO = "";
    private string epf = "";
    private int lsuvdt;
    private int LSUSBR;
    private double LSUVAL;
    private long newLoanNum;

    private long LSULNO;
    private double LSULCA;
    private double LSULIN;

    private double LSUNET;
    private double LSUBON;

    private string HNAME = "";
    private string HNAME1 = "";
    private string ACNO = "";
    private string ADD1 = "";
    private string ADD2 = "";
    private string ADD3 = "";
    private string INSNAME = "";
    private double TOTAMOUNT;
    private string RECIPIENT_NAME = "";

    private string BNKNAME = "";
    private string BNKBRNNAME = "";
    private string CUSTACCTNO = "";

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {

        
    }
}
