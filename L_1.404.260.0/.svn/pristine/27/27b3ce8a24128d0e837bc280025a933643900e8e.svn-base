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

public partial class affidavitTam : System.Web.UI.Page
{
    private int polno;
    private string MOF;
    //    private string errdesc = "";
    private string phname;
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
    DataManager affidaviObj = new DataManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;

            #region // ************** PHNAME  ********************************************************************

            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            affidaviObj.readSql(sql);
            OracleDataReader oraDtReader = affidaviObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (oraDtReader.Read())
            {
                if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(2)) && (!oraDtReader.IsDBNull(2)))
                {
                    phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                }
            }
            oraDtReader.Close();
            oraDtReader.Dispose();
            #endregion

            #region ---- claim no ----
            string DNOD = "";
            long cliamNo = 0;
            string dthintSelect = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
            if (affidaviObj.existRecored(dthintSelect) != 0)
            {
                affidaviObj.readSql(dthintSelect);
                OracleDataReader dthintReader = affidaviObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                    if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                }
                dthintReader.Close();
                dthintReader.Dispose();
            }
            this.litClmno.Text = cliamNo.ToString();

            #endregion

            this.littpolno.Text = polno.ToString();
            this.litName.Text = phname;
        }
        try
        {
            this.litpolno.Text = polno.ToString();
        }
        catch (Exception ex)
        {
            //if (errdesc.Equals(null) || errdesc.Equals("")) EPage.Messege = ex.Message;
            //else EPage.Messege = errdesc;
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
