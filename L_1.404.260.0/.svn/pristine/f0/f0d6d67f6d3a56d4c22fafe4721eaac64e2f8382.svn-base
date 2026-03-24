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

public partial class RepudiatnLetter002 : System.Web.UI.Page
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
    private string MOF;

    private string name;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;

    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    private string ADDRESS3 = "";
    private string ADDRESS4 = "";
    private int INDEX;
    private string LANG;
    public ArrayList AddressList1;
    public ArrayList AddressList2;
    public ArrayList AddressList3;
    public ArrayList CopyArray;
    private int AGENCY;
    private int AGENTCode;
    private int ClmNo;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            ClmNo = this.PreviousPage.Clmno;
        }
        dm = new DataManager();
        try
        {
            LANG = "E";
            AddressList1 = new ArrayList();
            AddressList2 = new ArrayList();
            AddressList3 = new ArrayList();
            CopyArray = new ArrayList();
            litclmno.Text = ClmNo.ToString();
            this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);


            #region Load Claimnt Address
            dm = new DataManager();
            INDEX = 0;
            string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
            if (dm.existRecored(dclmAddressSelect) != 0)
            {

                dm.readSql(dclmAddressSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { AddressList1.Add(dthintReader.GetString(0)); }
                    else { AddressList1.Add(""); }
                    if (!dthintReader.IsDBNull(1)) { AddressList1.Add(dthintReader.GetString(1)); }
                    else { AddressList1.Add(""); }
                    if (!dthintReader.IsDBNull(2)) { AddressList1.Add(dthintReader.GetString(2)); }
                    else { AddressList1.Add(""); }
                    if (!dthintReader.IsDBNull(3)) { AddressList1.Add(dthintReader.GetString(3)); }
                    else { AddressList1.Add(""); }
                    if (!dthintReader.IsDBNull(4)) { AddressList1.Add(dthintReader.GetString(4)); }
                    else { AddressList1.Add(""); }
                    AddressList1.Add("");
                    AddressList1.Add(""); AddressList1.Add("");
                    CopyArray.Add(AddressList1);

                }
                dthintReader.Close();
                dthintReader.Dispose();

            }

            else
            {
                #region //---- Name and Address ---

                string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and indx = 0 ";
                if (dm.existRecored(dclmaddressSelect) != 0)
                {
                    dm.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        if (!dclmAdReader.IsDBNull(2)) { NAME = dclmAdReader.GetString(2); AddressList1.Add(NAME); } else { NAME = ""; AddressList1.Add(""); }
                        if (!dclmAdReader.IsDBNull(3)) { ADDRESS1 = dclmAdReader.GetString(3); AddressList1.Add(ADDRESS1); } else { ADDRESS1 = ""; AddressList1.Add(""); }
                        if (!dclmAdReader.IsDBNull(4)) { ADDRESS2 = dclmAdReader.GetString(4); AddressList1.Add(ADDRESS2); } else { ADDRESS2 = ""; AddressList1.Add(""); }
                        if (!dclmAdReader.IsDBNull(5)) { ADDRESS3 = dclmAdReader.GetString(5); AddressList1.Add(ADDRESS3); } else { ADDRESS3 = ""; AddressList1.Add(""); }
                        if (!dclmAdReader.IsDBNull(6)) { ADDRESS4 = dclmAdReader.GetString(6); AddressList1.Add(ADDRESS4); } else { ADDRESS4 = ""; AddressList1.Add(""); }
                        AddressList1.Add("");
                        AddressList1.Add(""); AddressList1.Add("");
                        CopyArray.Add(AddressList1);
                    }
                    dclmAdReader.Close();
                    dclmAdReader.Dispose();

                    this.litname.Text = NAME;
                    this.litad1.Text = ADDRESS1;
                    this.litad2.Text = ADDRESS2;
                    this.litad3.Text = ADDRESS3;
                    this.litad4.Text = ADDRESS4;
                }
                else
                {
                    string dthintSelect = "select diname, diad1, diad2, diad3, diad4 from lphs.dthint where dpolno = " + polno + " and dmos='" + MOF + "'";
                    if (dm.existRecored(dthintSelect) == 0)
                    {
                        dm.connclose();
                        throw new Exception("No Death Intimation Details!");
                    }
                    else
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { name = dthintReader.GetString(0); AddressList1.Add(name); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { ad1 = dthintReader.GetString(1); AddressList1.Add(ad1); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { ad2 = dthintReader.GetString(2); AddressList1.Add(ad2); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { ad3 = dthintReader.GetString(3); AddressList1.Add(ad3); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { ad4 = dthintReader.GetString(4); AddressList1.Add(ad4); } else { AddressList1.Add(""); }
                            AddressList1.Add("");
                            AddressList1.Add(""); AddressList1.Add("");
                            CopyArray.Add(AddressList1);
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();
                    }

                    this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.litname.Text = name;
                    this.litad1.Text = ad1;
                    this.litad2.Text = ad2;
                    this.litad3.Text = ad3;
                    this.litad4.Text = ad4;
                }
                #endregion
            }

            #endregion

            #region Load Branch Administration Officers Address

            INDEX = 3;
            string BranchAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
            if (dm.existRecored(BranchAddressSelect) != 0)
            {

                dm.readSql(BranchAddressSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { AddressList2.Add(dthintReader.GetString(0)); }
                    else { AddressList2.Add(""); }
                    if (!dthintReader.IsDBNull(1)) { AddressList2.Add(dthintReader.GetString(1)); }
                    else { AddressList2.Add(""); }
                    if (!dthintReader.IsDBNull(2)) { AddressList2.Add(dthintReader.GetString(2)); }
                    else { AddressList2.Add(""); }

                    if (!dthintReader.IsDBNull(3)) { AddressList2.Add(dthintReader.GetString(3)); }
                    else { AddressList2.Add(""); }
                    if (!dthintReader.IsDBNull(4)) { AddressList2.Add(dthintReader.GetString(4)); }
                    else { AddressList2.Add(""); }
                    AddressList2.Add(""); AddressList2.Add("");
                    CopyArray.Add(AddressList2);

                }
                dthintReader.Close();
                dthintReader.Dispose();

            }

            #endregion

            #region Load Agent Code


            string AgentCodeSelect = "select DRAGT from LPHS.DTHREF where DRPOLNO = " + polno + " ";
            if (dm.existRecored(AgentCodeSelect) != 0)
            {
                dm.readSql(AgentCodeSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { AGENTCode = dthintReader.GetInt32(0); }
                }
                dthintReader.Close();
                dthintReader.Dispose();
                AGENCY = AGENTCode;
            }

            #endregion

            #region Load Insurance Advisors Address


            if (AGENCY != 0)
            {
                string InsuranceOffAddressSelect = "select STATUS ||''||INT||''||NAME as NAME,AD1,AD2,AD3,AD4,AD5 from AGENT.AGENT where AGENCY = " + AGENCY + " and STCD<>'5' and STCD<>'8' and STCD<>'9'";
                if (dm.existRecored(InsuranceOffAddressSelect) != 0)
                {
                    dm.readSql(InsuranceOffAddressSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { AddressList3.Add(dthintReader.GetString(0).Trim()); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(1)) { AddressList3.Add(dthintReader.GetString(1)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(2)) { AddressList3.Add(dthintReader.GetString(2)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(3)) { AddressList3.Add(dthintReader.GetString(3)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(4)) { AddressList3.Add(dthintReader.GetString(4)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(5)) { AddressList3.Add(dthintReader.GetString(5)); }
                        else { AddressList3.Add(""); }
                        AddressList3.Add(AGENCY);
                        CopyArray.Add(AddressList3);

                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                }
            }

            #endregion

            #region //---- Name and Address ---

            string dclmaddressSelect1 = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and indx = 0 ";
            if (dm.existRecored(dclmaddressSelect1) != 0)
            {
                dm.readSql(dclmaddressSelect1);
                OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dclmAdReader.Read())
                {
                    if (!dclmAdReader.IsDBNull(2)) { NAME = dclmAdReader.GetString(2); } else { NAME = ""; }
                    if (!dclmAdReader.IsDBNull(3)) { ADDRESS1 = dclmAdReader.GetString(3); } else { ADDRESS1 = ""; }
                    if (!dclmAdReader.IsDBNull(4)) { ADDRESS2 = dclmAdReader.GetString(4); } else { ADDRESS2 = ""; }
                    if (!dclmAdReader.IsDBNull(5)) { ADDRESS3 = dclmAdReader.GetString(5); } else { ADDRESS3 = ""; }
                    if (!dclmAdReader.IsDBNull(6)) { ADDRESS4 = dclmAdReader.GetString(6); } else { ADDRESS4 = ""; }
                }
                dclmAdReader.Close();
                dclmAdReader.Dispose();

                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.litname.Text = NAME;
                this.litad1.Text = ADDRESS1;
                this.litad2.Text = ADDRESS2;
                this.litad3.Text = ADDRESS3;
                this.litad4.Text = ADDRESS4;
            }
            else
            {
                string dthintSelect = "select diname, diad1, diad2, diad3, diad4 from lphs.dthint where dpolno = " + polno + " and dmos='" + MOF + "'";
                if (dm.existRecored(dthintSelect) == 0)
                {
                    dm.connclose();
                    throw new Exception("No Death Intimation Details!");
                }
                else
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { name = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { ad1 = dthintReader.GetString(1); }
                        if (!dthintReader.IsDBNull(2)) { ad2 = dthintReader.GetString(2); }
                        if (!dthintReader.IsDBNull(3)) { ad3 = dthintReader.GetString(3); }
                        if (!dthintReader.IsDBNull(4)) { ad4 = dthintReader.GetString(4); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }

                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.litad4.Text = name;
                this.litad1.Text = ad1;
                this.litad2.Text = ad2;
                this.litad3.Text = ad3;
                this.litad4.Text = ad4;
            }
            #endregion

            string status = "";
            string phname = "";
            string sql = "";
            string sql2 = "";
            string sql3 = "";

            sql = "select  STATUS, FULLNAME from LUND.POLPERSONAL where POLNO='" + polno + "' and PRPERTYPE=(SELECT DECODE('" + MOF + "', 'M', '1','S','2','2', '3') result from dual)";
            sql2 = "select  STATUS, FULLNAME from LUND.POLPERSONAL_HISTORY where POLNO='" + polno + "' and PRPERTYPE=(SELECT DECODE('" + MOF + "', 'M', '1','S','2','2', '3') result from dual)";

            if (dm.existRecored(sql) != 0)
            {
                dm.readSql(sql);
                OracleDataReader oraPolDetailsReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraPolDetailsReader.Read())
                {
                    if (!oraPolDetailsReader.IsDBNull(0)) { status = oraPolDetailsReader.GetString(0); }
                    if (!oraPolDetailsReader.IsDBNull(1)) { phname = oraPolDetailsReader.GetString(1); }
                }
                oraPolDetailsReader.Close();
            }
            else if (dm.existRecored(sql2) != 0)
            {
                dm.readSql(sql2);
                OracleDataReader oraPolHisDetailsReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraPolHisDetailsReader.Read())
                {
                    if (!oraPolHisDetailsReader.IsDBNull(0)) { status = oraPolHisDetailsReader.GetString(0); }
                    if (!oraPolHisDetailsReader.IsDBNull(1)) { phname = oraPolHisDetailsReader.GetString(1); }
                }
                oraPolHisDetailsReader.Close();
            }

            if (phname != null && phname != "")
            {
                sql3 = "select lphs.GET_NAMEWITHINITIALS('" + phname + "') from dual";
                if (dm.existRecored(sql3) != 0)
                {
                    dm.readSql(sql3);
                    OracleDataReader oraDtReaderName = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (oraDtReaderName.Read())
                    {
                        if (!oraDtReaderName.IsDBNull(0))
                        {
                            phname = status + " " + oraDtReaderName.GetString(0);
                        }
                    }
                    oraDtReaderName.Close();
                }
            }

            #region //---- Repudiation Reason ---

            string REPU_REASON = "";
            string REPU_REASON_SIN = "";
            string repusel = "select REPU_REASON, REPU_REASON_SIN from LPHS.DTH_REPUDIATION where POLICYNO = " + polno + " and LIFE_TYPE = '" + MOF + "' ";
            if (dm.existRecored(repusel) != 0)
            {
                dm.readSql(repusel);
                OracleDataReader repuReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (repuReader.Read())
                {
                    if (!repuReader.IsDBNull(0)) { REPU_REASON = repuReader.GetString(0); } else { REPU_REASON = ""; }
                    if (!repuReader.IsDBNull(1)) { REPU_REASON_SIN = repuReader.GetString(1); } else { REPU_REASON_SIN = ""; }
                }
                repuReader.Close();
                repuReader.Dispose();
            }

            #endregion

            this.Litrepureason.Text = REPU_REASON_SIN;
            this.litpolno.Text = polno.ToString();
            this.litlifeassured.Text = phname;

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
