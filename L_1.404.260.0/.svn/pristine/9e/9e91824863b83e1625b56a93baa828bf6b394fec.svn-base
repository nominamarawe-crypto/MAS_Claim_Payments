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

public partial class claimentStt2505Eng : System.Web.UI.Page
{
    private int polno;
    private string MOF;
    private string errdesc = "";
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
    DataManager clmsttmntObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
        }
        clmsttmntObj = new DataManager();
        try
        {

            this.litpolno.Text = polno.ToString();
            #region // ************** PHNAME  *******************************

            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            clmsttmntObj.readSql(sql);
            OracleDataReader oraDtReader = clmsttmntObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

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

            this.litname.Text = phname;

            #region //************** PREMAST *******************************
            long sumass = 0;
            string dthrefsel = "select pmsum from lphs.premast where pmpol = " + polno + "";
            if (clmsttmntObj.existRecored(dthrefsel) != 0)
            {
                clmsttmntObj.readSql(dthrefsel);
                OracleDataReader r1 = clmsttmntObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                r1.Read();
                sumass = r1.GetInt64(0);
                r1.Close();
                r1.Dispose();
            }
            else
            {
                string dthrefsel2 = "select lpsum from lphs.liflaps where lppol = " + polno + "";
                if (clmsttmntObj.existRecored(dthrefsel2) != 0)
                {
                    clmsttmntObj.readSql(dthrefsel2);
                    OracleDataReader r2 = clmsttmntObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    r2.Read();
                    sumass = r2.GetInt64(0);
                    r2.Close();
                    r2.Dispose();
                }
                else
                {
                    string dthrefsel3 = "select phsum from lphs.lpolhis where phpol = " + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                    if (clmsttmntObj.existRecored(dthrefsel3) != 0)
                    {
                        clmsttmntObj.readSql(dthrefsel3);
                        OracleDataReader r3 = clmsttmntObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        r3.Read();
                        sumass = r3.GetInt64(0);
                        r3.Close();
                        r3.Dispose();
                    }
                }
            }
            #endregion

            #region ---- claim no ----
            string DNOD = "";
            long cliamNo = 0;
            string dthintSelect = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
            if (clmsttmntObj.existRecored(dthintSelect) != 0)
            {
                clmsttmntObj.readSql(dthintSelect);
                OracleDataReader dthintReader = clmsttmntObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                    if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                }
                dthintReader.Close();
                dthintReader.Dispose();
            }
            this.litClmNo.Text = cliamNo.ToString();

            #endregion

            this.litsumassed.Text = String.Format("{0:N}", (double)sumass);

            clmsttmntObj.connclose();
        }
        catch (Exception ex)
        {
            clmsttmntObj.connclose();
            if (errdesc.Equals(null) || errdesc.Equals("")) EPage.Messege = ex.Message;

            else EPage.Messege = errdesc;

            Response.Redirect("EPage.aspx");
        }        
    }
}
