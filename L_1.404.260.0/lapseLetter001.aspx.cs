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

public partial class lapseLetter001 : System.Web.UI.Page
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
    private int clmno;

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
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            clmno = this.PreviousPage.Clmno;
        }
        dm = new DataManager();
        try
        {

            LANG = "E";
            AddressList1 = new ArrayList();
            AddressList2 = new ArrayList();
            AddressList3 = new ArrayList();
            CopyArray = new ArrayList();
           
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
                AGENCY = AGENTCode;
                dthintReader.Close();
                dthintReader.Dispose();
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


            this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
             
            #region //---- Name and Address ---
            this.litpolno.Text = clmno.ToString();
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
                this.litname.Text = name;
                this.litad1.Text = ad1;
                this.litad2.Text = ad2;
                this.litad3.Text = ad3;
                this.litad4.Text = ad4;
            }
            #endregion

            #region // ************** PHNAME  ******************************************************
            string phname = "";
            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, " +
                " phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            if (dm.existRecored(sql) != 0)
            {
                dm.readSql(sql);
                OracleDataReader oraDtReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraDtReader.Read())
                {
                    if ((!oraDtReader.IsDBNull(0)) && ((!oraDtReader.IsDBNull(1))) && ((!oraDtReader.IsDBNull(2))))
                    {
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                    }
                }
                oraDtReader.Close();
                oraDtReader.Dispose();
            }
            this.litlifeassured.Text = phname;
            this.litlifeassured2.Text = phname;

            #endregion

            this.litpolno.Text = polno.ToString();
            this.litpolno.Text = clmno.ToString();

            #region //----  lapse date ---
                       
            polMasRead polmasObj = new polMasRead((int)polno, dm);
            int due = polmasObj.DUE;
            int MOD = polmasObj.MOD;
            int com = polmasObj.COM;

            //string lapsedatesel = "select lpdue, lpmod, lpcom from lphs.liflaps where lppol= " + polno + "";
            //if (dm.existRecored(lapsedatesel) != 0) 
            //{
            //    dm.readSql(lapsedatesel);
            //    OracleDataReader oraDtReader = dm.oraComm.ExecuteReader();
            //    while (oraDtReader.Read()) 
            //    {
            //        if (!oraDtReader.IsDBNull(0)) { due = oraDtReader.GetInt32(0); } else { due = 0; }
            //        if (!oraDtReader.IsDBNull(1)) { MOD = oraDtReader.GetInt32(1); } else { MOD = 0; }
            //        if (!oraDtReader.IsDBNull(2)) { com = oraDtReader.GetInt32(2); } else { com = 0; }
            //    }
            //    oraDtReader.Close();

            //    if (due > 0) { this.lbllapseddate.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2) + "/" + com.ToString().Substring(6, 2); }
            //}

            this.litlapseddate.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2) + "/" + com.ToString().Substring(6, 2); 

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
