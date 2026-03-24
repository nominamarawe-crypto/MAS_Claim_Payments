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

public partial class form2501 : System.Web.UI.Page
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

    private string MOF;
    private int polno;
    private int clm;
    private string NOD;
    private int infodat;

    //private string epf;
    private string infoname;
    private string infoad1;
    private string infoad2;
    private string infoad3;
    private string infoad4;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mOF;
            clm = this.PreviousPage.Clm;
            NOD = this.PreviousPage.nOD;
            infodat = this.PreviousPage.Infodat;

            infoname = this.PreviousPage.Infoname;
            infoad1 = this.PreviousPage.Infoad1;
            infoad2 = this.PreviousPage.Infoad2;
            infoad3 = this.PreviousPage.Infoad3;
            infoad4 = this.PreviousPage.Infoad4;
            
        }
        if (!Page.IsPostBack)
        {
            try 
            {
                //epf = Session["epfNum"].ToString();
                this.litpolno.Text = polno.ToString();
                this.lblpolno2.Text = polno.ToString();
                //this.litcalimno.Text = clm.ToString();
                //this.Literal4.Text = clm.ToString();
                this.litdeceasename.Text = NOD;
              //  if (infodat > 0) { this.lbldateofinti.Text = infodat.ToString().Substring(0, 4) + "/" + infodat.ToString().Substring(4, 2) + "/" + infodat.ToString().Substring(6, 2); }
                this.litcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

                this.litname.Text = infoname;
                this.litad1.Text = infoad1;
                this.litad2.Text = infoad2;
                this.litad3.Text = infoad3;
                this.litad4.Text = infoad4;
                //this.litEPF.Text = epf;

                //affidaviObj = new DataManager();

                //#region // ************** name  ********************************************************************

                //string phname = "";
                //int dateofDth = 0;

                //string sql = "select  dinfodat, dnod from LPHS.dthint where dpolno='" + polno + "'";
                //if (affidaviObj.existRecored(sql) != 0)
                //{
                //    affidaviObj.readSql(sql);
                //    OracleDataReader oraDtReader = affidaviObj.oraComm.ExecuteReader();
                //    while (oraDtReader.Read())
                //    {
                //        if (!oraDtReader.IsDBNull(0)) { phname = oraDtReader.GetString(0); } else { phname = ""; }
                //        if (!oraDtReader.IsDBNull(1)) { dateofDth = oraDtReader.GetInt32(1); } else { dateofDth = 0; }

                //    }
                //    oraDtReader.Close();
                //}
                //#endregion

                //affidaviObj.connclose();
            }
            catch (Exception ex)
            {
                //affidaviObj.connclose();         
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }
}
