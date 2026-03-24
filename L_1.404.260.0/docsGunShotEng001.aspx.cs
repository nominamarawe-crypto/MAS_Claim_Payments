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

public partial class docsGunShotEng001 : System.Web.UI.Page
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

    private static int polno;
    private static string MOF;
    private long cliamNo;

    private string LANG = "";
    private int INDEX = 0;
    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    private string ADDRESS3 = "";
    private string ADDRESS4 = "";

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
        }

        if (!Page.IsPostBack)
        {
            try
            {
                dm = new DataManager();

                this.lblpolno.Text = polno.ToString();

                #region  //********* Name & Address Select **************
                string DINAME = "";
                string DIAD1 = "";
                string DIAD2 = "";
                string DIAD3 = "";
                string DIAD4 = "";
                string DNOD = "";
                int DDTOFDTH = 0;

                string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' ";
                if (dm.existRecored(dclmaddressSelect) != 0)
                {
                    dm.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader.IsDBNull(2)) { NAME = dclmAdReader.GetString(2); } else { NAME = ""; }
                        if (!dclmAdReader.IsDBNull(3)) { ADDRESS1 = dclmAdReader.GetString(3); } else { ADDRESS1 = ""; }
                        if (!dclmAdReader.IsDBNull(4)) { ADDRESS2 = dclmAdReader.GetString(4); } else { ADDRESS2 = ""; }
                        if (!dclmAdReader.IsDBNull(5)) { ADDRESS3 = dclmAdReader.GetString(5); } else { ADDRESS3 = ""; }
                        if (!dclmAdReader.IsDBNull(6)) { ADDRESS4 = dclmAdReader.GetString(6); } else { ADDRESS4 = ""; }

                        if (INDEX == 0)
                        {
                            //this.lblname.Text = NAME;
                            this.lblad1.Text = ADDRESS1;
                            this.lblad2.Text = ADDRESS2;
                            this.lblad3.Text = ADDRESS3;
                            this.lblad4.Text = ADDRESS4;
                        }

                    }
                    dclmAdReader.Close();
                    dclmAdReader.Dispose();

                    string dthintSelect = "select DNOD, DCLM, DDTOFDTH from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect) != 0)
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                            if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                            if (!dthintReader.IsDBNull(2)) { DDTOFDTH = dthintReader.GetInt32(2); }
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();
                    }

                    this.lblnameofdead.Text = DNOD;
                    this.lblourref.Text = cliamNo.ToString();
                    //this.lblyrref.Text = epfStr;
                    this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lbldateofdeath.Text = DDTOFDTH.ToString().Substring(0, 4) + "/" + DDTOFDTH.ToString().Substring(4, 2) + "/" + DDTOFDTH.ToString().Substring(6, 2);
                }
                else
                {

                    string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM, DDTOFDTH from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect) != 0)
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { DINAME = dthintReader.GetString(0); }
                            if (!dthintReader.IsDBNull(1)) { DIAD1 = dthintReader.GetString(1); }
                            if (!dthintReader.IsDBNull(2)) { DIAD2 = dthintReader.GetString(2); }
                            if (!dthintReader.IsDBNull(3)) { DIAD3 = dthintReader.GetString(3); }
                            if (!dthintReader.IsDBNull(4)) { DIAD4 = dthintReader.GetString(4); }
                            if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5); }
                            if (!dthintReader.IsDBNull(6)) { cliamNo = dthintReader.GetInt64(6); }
                            if (!dthintReader.IsDBNull(7)) { DDTOFDTH = dthintReader.GetInt32(7); }
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();
                    }

                    //this.lblname.Text = DINAME;
                    this.lblad1.Text = DIAD1;
                    this.lblad2.Text = DIAD2;
                    this.lblad3.Text = DIAD3;
                    this.lblad4.Text = DIAD4;
                    this.lblnameofdead.Text = DNOD;
                    //this.lblyrref.Text = epfStr;
                    this.lblourref.Text = cliamNo.ToString();
                    this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lbldateofdeath.Text = DDTOFDTH.ToString().Substring(0, 4) + "/" + DDTOFDTH.ToString().Substring(4, 2) + "/" + DDTOFDTH.ToString().Substring(6, 2);
                }

                #endregion

                dm.connclose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        
        }
    }
}
