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
using System.Data.OracleClient;

public partial class docsCallPolnoArmySin001 : System.Web.UI.Page
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
   // private int  Polno;
//    private string MOF;
//    private string DNOD;
//    private int cliamNo;
   // private int dateofdeath;
    private string name;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private string deceasedName;
    private string soldierNo;
    private string leterdate;
    private string letterRef;
    private string epfNum = "";
//    private int PropNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtname.Text = "wOHCI";
            this.txtad1.Text = "hqo yuqod iQNidOl wOHCI uKav,h    ";
            this.txtad2.Text = "wxl 05  23 jk mgqu. ";
            this.txtad3.Text = "fld< U 03";
            this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            //this.lblourref.Text = epfNum;
            //hdfpolno.Value = this.PreviousPage.Polno.ToString();
           // Polno = this.PreviousPage.Polno;
           // MOF = this.PreviousPage.mos;
           // hdfpol.Value = Polno.ToString();
           // hdfmos.Value = MOF;
            /*

            #region
            DataManager dm = new DataManager();
            string dthintSelect = "select DNOD, DCLM, ddtofdth from LPHS.DTHINT where DPOLNO = " + Polno + " and DMOS ='" + MOF + "' ";
            if (dm.existRecored(dthintSelect) != 0)
            {
                dm.readSql(dthintSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                    if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt32(1); }
                    if (!dthintReader.IsDBNull(2)) { dateofdeath = dthintReader.GetInt32(2); }
                }
                dthintReader.Close();
                
            }
            #endregion
             * */
        }      
            
            
        
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        name = this.txtname.Text.Trim();
        ad1 = this.txtad1.Text.Trim();
        ad2 = this.txtad2.Text.Trim();
        ad3 = this.txtad3.Text.Trim();
        ad4 = this.txtad4.Text.Trim();
        deceasedName = this.txtdeceased.Text.Trim();
        soldierNo = this.txtsoldierNo.Text.Trim();
        leterdate = this.txtsendDate.Text.Trim();
        letterRef = this.txtletterRef.Text.Trim();
        //epfNum = this.lblourref.Text.Trim();
        //cliamNo =int.Parse( this.lblourref.Text);
        //if (TextBox2.Text != "")
        //{
        //    PropNo = int.Parse(TextBox2.Text.Trim());
        //}
        //Polno = int.Parse(this.hdfpol.Value);
        Server.Transfer("~/letters/docsCallPolnoArmySin002.aspx", true);
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
    public string SoldierNo
    {
        get { return soldierNo; }
        set { soldierNo = value; }
    }
    public string Leterdate
    {
        get { return leterdate; }
        set { leterdate = value; }
    }
    public string LetterRef
    {
        get { return letterRef; }
        set { letterRef = value; }
    }
    public string  YourRef
    {
        get { return epfNum; }
        set { epfNum = value; }
    }
    //public int PROPOSALNO
    //{
    //    get { return PropNo; }
    //    set { PropNo = value;}
    //}
    //public int POLICYNO
    //{
    //    get { return Polno; }
    //    set { Polno = value; }
    //}
    
}
