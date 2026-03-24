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

public partial class letters_DischargeCvrLetter : System.Web.UI.Page
{
    private long polno;
    private string CurrDate;
    private string MOF;
    private int INDEX;
    private string LANG;
    private string NAME;
    private string ADDRESS1;
    private string ADDRESS2;
    private string ADDRESS3;
    private string ADDRESS4;
    private long claimno;
    private int AGENCY;
    private int AGENTCode;
    private ArrayList Address;
    private int ChechedBtn;
    DataManager dm;
    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        CurrDate = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        litdt.Text = CurrDate;
        if (PreviousPage != null)
        {
            polno = PreviousPage.Polno;
            litpolno.Text = polno.ToString();
            MOF = PreviousPage.mOF;
            hdfmof.Value = MOF;
        }

        if (!IsPostBack)
        {
            #region  //********* Name & Address Select **************
            string DINAME = "";
            string DIAD1 = "";
            string DIAD2 = "";
            string DIAD3 = "";
            string DIAD4 = "";
            string DNOD = "";

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
                        this.litname.Text = NAME;
                        this.litad1.Text = ADDRESS1;
                        this.litad2.Text = ADDRESS2;
                        this.litad3.Text = ADDRESS3;
                        this.litad4.Text = ADDRESS4;
                    }
                    else if (INDEX == 2)
                    {
                        if ((NAME != null) && (!NAME.Equals(""))) { this.litcopydes.Visible = true; this.litcopyto.Visible = true; }

                        this.litcopydes.Text = NAME + ", " + ADDRESS1 + " " + ADDRESS2 + " " + ADDRESS3 + " " + ADDRESS4;
                    }
                }
                dclmAdReader.Close();
                dclmAdReader.Dispose();

                string dthintSelect = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { claimno = dthintReader.GetInt64(1); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }

                this.litdesname.Text = DNOD;
                this.litclm.Text = claimno.ToString();
                //this.lblyrref.Text = epfStr;            
            }
            else
            {

                string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
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
                        if (!dthintReader.IsDBNull(6)) { claimno = dthintReader.GetInt64(6); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }

                this.litname.Text = DINAME;
                this.litad1.Text = DIAD1;
                this.litad2.Text = DIAD2;
                this.litad3.Text = DIAD3;
                this.litad4.Text = DIAD4;
                this.litdesname.Text = DNOD;
                //this.lblyrref.Text = epfStr;
                this.litclm.Text = claimno.ToString();
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

            Address = new ArrayList();
            if (AGENCY != 0)
            {
                string InsuranceOffAddressSelect = "select STATUS ||''||INT||''||NAME as NAME,AD1,AD2,AD3,AD4,AD5 from AGENT.AGENT where AGENCY = " + AGENCY + " and STCD<>'5' and STCD<>'8' and STCD<>'9'";
                if (dm.existRecored(InsuranceOffAddressSelect) != 0)
                {
                    dm.readSql(InsuranceOffAddressSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { Address.Add(dthintReader.GetString(0).Trim()); }
                        else { Address.Add(""); }
                        if (!dthintReader.IsDBNull(1)) { Address.Add(dthintReader.GetString(1)); }
                        else { Address.Add(""); }
                        if (!dthintReader.IsDBNull(2)) { Address.Add(dthintReader.GetString(2)); }
                        else { Address.Add(""); }
                        if (!dthintReader.IsDBNull(3)) { Address.Add(dthintReader.GetString(3)); }
                        else { Address.Add(""); }
                        if (!dthintReader.IsDBNull(4)) { Address.Add(dthintReader.GetString(4)); }
                        else { Address.Add(""); }
                        if (!dthintReader.IsDBNull(5)) { Address.Add(dthintReader.GetString(5)); }
                        else { Address.Add(""); }
                        Address.Add(AGENCY);


                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                    this.litcopydes1.Text = Address[0].ToString() + ", " + Address[1].ToString() + ", " + Address[2].ToString() + ", " + Address[3].ToString() + ", " + Address[4].ToString() + ", " + Address[5].ToString();


                }
            }

            #endregion
        }
        else
        {
            polno = int.Parse(litpolno.Text);
            MOF = hdfmof.Value;
        }

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        ChechedBtn = 1;
    }
    protected void btn_word_Click(object sender, EventArgs e)
    {
        ChechedBtn = 2;
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mof
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public int CHECKEDBTN
    {
        get { return ChechedBtn; }
        set { ChechedBtn = value; }
    }
}
