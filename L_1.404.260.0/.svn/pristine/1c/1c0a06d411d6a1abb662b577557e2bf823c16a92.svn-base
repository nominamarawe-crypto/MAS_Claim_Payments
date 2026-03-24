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

public partial class docsCallDCSin002 : System.Web.UI.Page
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
        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        return datetime;

    }

    private  int polno;
    private  string MOF;
    private  string dc;
    private long cliamNo;

    private string nod;
    private string soldierNo;
    private string regiment;
    private string placeOfDeath;
    private string informer;
    private string letterDate;
    private string copy1;
    private string copy2;
    private string copy3;
    private string copy4;
    private string copy5;
    private string copy6;
    private string copy7;
    private string copy8;
    private string copy9;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;

            nod = this.PreviousPage.Nod;
            soldierNo = this.PreviousPage.SoldierNo;
            regiment = this.PreviousPage.Regiment;
            placeOfDeath = this.PreviousPage.PlaceOfDeath;
            informer = this.PreviousPage.Informer;
            letterDate = this.PreviousPage.LetterDate;
            copy1 = this.PreviousPage.Copy1;
            copy2 = this.PreviousPage.Copy2;
            copy3 = this.PreviousPage.Copy3;
            copy4 = this.PreviousPage.Copy4;
            copy5 = this.PreviousPage.Copy5;
            copy6 = this.PreviousPage.Copy6;
            copy7 = this.PreviousPage.Copy7;
            copy8 = this.PreviousPage.Copy8;
            copy9 = this.PreviousPage.Copy9;
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try 
            {
               
                string DNOD = "";
                int dateofdeath = 0;

                this.litnameOfDeath.Text = nod;
                this.litSoldierNo.Text = soldierNo;
                this.litPlaceOfDth.Text = placeOfDeath;
                this.litInformer.Text = informer;
                this.litdDate2.Text = letterDate;
                this.lblcopy1.Text = copy1; 
                this.lblcopy2.Text = copy2;
                this.lblcopy3.Text = copy3;
                this.lblcopy4.Text = copy4;
                this.lblcopy5.Text = copy5;
                this.lblcopy6.Text = copy6;
                this.lblcopy7.Text = copy7;
                this.lblcopy8.Text = copy8;
                this.lblcopy9.Text = copy9;
                this.litpoli_no.Text = polno.ToString();

                string dthintSelect = "select DNOD, DCLM, ddtofdth from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                        if (!dthintReader.IsDBNull(2)) { dateofdeath = dthintReader.GetInt32(2); }
                    }
                    dthintReader.Close();
                }

                this.lblourref.Text = cliamNo.ToString();
                this.litdDate1.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

                #region
                if (dc.Equals("Air"))
                {
                    this.litad1.Text = "rlaIK wxYNdr ks,OdrS";
                    this.litad2.Text = "rlaIK wxYh";
                    this.litad3.Text = "YS% ,xld .=jkayuqod uQ,ia:dkh";
                    this.litad4.Text = "02";

                    this.litslodiernoDesc.Text = ".=jkaNg wxlh(";
                    this.litslodiernoDesc.Visible = true;
                    this.litSoldierNo.Visible = true;

                    this.lblregimentDesc.Visible = false;
                    this.litRegiment.Visible = false;
                    this.litRegiment.Text = "";
                }
                else if (dc.Equals("Army"))
                {
                    this.litad1.Text = "wOHCI";
                    this.litad2.Text = "hqo yuqod iQNidOl wOHCI uKav,h";
                    this.litad3.Text = "wxl 05  23 jk mgqu.";
                    this.litad4.Text = "03";

                    this.litslodiernoDesc.Text = "fin, wxlh(";
                    this.litslodiernoDesc.Visible = true;
                    this.litSoldierNo.Visible = true;

                    this.lblregimentDesc.Visible = true;
                    this.litRegiment.Visible = true;
                    this.litRegiment.Text = regiment;
                }
                else if (dc.Equals("Navy"))
                {
                    this.litad1.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
                    this.litad2.Text = "kdjsl iqNidOl wOHCI fjkqjg";
                    this.litad3.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
                    this.litad4.Text = "";

                    this.litslodiernoDesc.Text = "fin, wxlh(";
                    this.litslodiernoDesc.Visible = true;
                    this.litSoldierNo.Visible = true;

                    this.lblregimentDesc.Visible = false;
                    this.litRegiment.Visible = false;
                    this.litRegiment.Text = "";
                }
                else if (dc.Equals("SF"))
                {
                    this.litad1.Text = "wOHCI";
                    this.litad2.Text = "jsfYaI ldhH_ n,ld uQ,ia:dkh";
                    this.litad3.Text = "223 fn!oaOdf,dal udj;";
                    this.litad4.Text = "07";

                    this.litslodiernoDesc.Visible = false;
                    this.litSoldierNo.Visible = false;
                    
                    this.lblregimentDesc.Visible = false;
                    this.litRegiment.Visible = false;
                    this.litRegiment.Text = "";
                }
                #endregion

                dm.connclose();
            
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        
        }

    }
}
