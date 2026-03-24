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

public partial class letters_PregressSin001 : System.Web.UI.Page
{

    private int polno;
    private string MOF;
    private long cliamNo;
    private string LANG = "";
    private int INDEX = 0;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = Convert.ToInt32(this.PreviousPage.Polno);
            MOF = this.PreviousPage.mOF;
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                this.litpolno.Text = polno.ToString();

                #region  //********* Name & Address Select *****************


                string dclmaddressSelect = "SELECT  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES WHERE POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX = 0 ";
                if (dm.existRecored(dclmaddressSelect) != 0)
                {
                    dm.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader.IsDBNull(2)) { litname.Text = dclmAdReader.GetString(2); } else { litname.Text = ""; }
                        if (!dclmAdReader.IsDBNull(3)) { litad1.Text = dclmAdReader.GetString(3); } else { litad1.Text = ""; }
                        if (!dclmAdReader.IsDBNull(4)) { litad2.Text = dclmAdReader.GetString(4); } else { litad2.Text = ""; }
                        if (!dclmAdReader.IsDBNull(5)) { litad3.Text = dclmAdReader.GetString(5); } else { litad3.Text = ""; }
                        if (!dclmAdReader.IsDBNull(6)) { litad4.Text = dclmAdReader.GetString(6); } else { litad4.Text = ""; }

                    }
                    dclmAdReader.Close();

                    string dthintSelect = "select DNOD, DCLM, DDTOFDTH,DINAME,DNOD from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect) != 0)
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            //if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                            if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                            if (!dthintReader.IsDBNull(3)) { litnameofdead.Text = dthintReader.GetString(3); }
                            if (!dthintReader.IsDBNull(4)) { litnameofdead.Text = dthintReader.GetString(4); }
                        }
                        dthintReader.Close();
                    }

                    //this.lblnameofdead.Text = DNOD;
                    this.LtClmno.Text = cliamNo.ToString();
                    //this.lblyrref.Text = epfStr;
                    //this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lbldate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    //this.lbldateofdeath.Text = DDTOFDTH.ToString().Substring(0, 4) + "/" + DDTOFDTH.ToString().Substring(4, 2) + "/" + DDTOFDTH.ToString().Substring(6, 2);
                }
                else
                {

                    string dthintSelect = "SELECT DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM, DDTOFDTH FROM LPHS.DTHINT WHERE DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect) != 0)
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { litname.Text = dthintReader.GetString(0); }
                            if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); }
                            if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); }
                            if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); }
                            if (!dthintReader.IsDBNull(4)) { litad4.Text = dthintReader.GetString(4); }
                            //if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5); }
                            if (!dthintReader.IsDBNull(6)) { cliamNo = dthintReader.GetInt64(6); }
                            //if (!dthintReader.IsDBNull(7)) { DDTOFDTH = dthintReader.GetInt32(7); }
                        }
                        dthintReader.Close();
                    }

                    //this.lblname.Text = DINAME;
                    //this.lblad1.Text = DIAD1;
                    //this.lblad2.Text = DIAD2;
                    //this.lblad3.Text = DIAD3;
                    //this.lblad4.Text = DIAD4;
                    //this.lblnameofdead.Text = DNOD;
                    //this.lblyrref.Text = epfStr;
                    this.LtClmno.Text = cliamNo.ToString();
                    //this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    //this.lbldateofdeath.Text = DDTOFDTH.ToString().Substring(0, 4) + "/" + DDTOFDTH.ToString().Substring(4, 2) + "/" + DDTOFDTH.ToString().Substring(6, 2);
                    this.lbldate.Text = DateTime.Now.ToString("yyyy/MM/dd");
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
