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

public partial class reminder003 : System.Web.UI.Page
{
    #region Private Variables
    private  long polno;   
    private  string MOF;
  
    public int sentDate;
    public int remindersentdate;
    public int secondremsentdt;

    private int reqcode;
    private string remarks;

    private string name;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;

    private string LANG = "";
    private int INDEX = 0;
//    private string NAME = "";
//    private string ADDRESS1 = "";
//    private string ADDRESS2 = "";
//    private string ADDRESS3 = "";
//    private string ADDRESS4 = "";
    private int DeathClaimNumber = 0;
    private string Lett_Type = "E";
    public  int Rem_no;
    public ArrayList Address1;
    public ArrayList AddressList1;
    public ArrayList AddressList2;
    public ArrayList AddressList3;
    public ArrayList AddressList4;
    public ArrayList AddressList5;
    public ArrayList CopyArray;
    private int AGENCY;
    private int AGENTCode;

    private ArrayList AssuNameChng;
    private ArrayList NomineeNamChg;
    private ArrayList Ass_Nomihg;
    private ArrayList Ass_Nomihg1;
    private ArrayList ReqcodeList = new ArrayList();
    private int ChechedBtn;
    public bool brcopy = false;
    public bool agcopy = false;
    public bool rgcod = false;
    public bool rgsm = false;
    #endregion

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

    DataManager reminderObj;
    ArrayList arr;

    protected void Page_Load(object sender, EventArgs e)
    {
        int yeardiff = 0;
        int mnthdiff = 0;
        int dawasdiff = 0;

        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
            Session["polno"] = polno;
            Session["MOF"] = MOF;
        }
        if (!Page.IsPostBack)
        {
            reminderObj = new DataManager();            
            try
            {
                LANG = "E";
                Address1 = new ArrayList();
                AddressList1 = new ArrayList();
                AddressList2 = new ArrayList();
                AddressList3 = new ArrayList();
                AddressList4 = new ArrayList();
                AddressList5 = new ArrayList();

                CopyArray = new ArrayList();
                arr = new ArrayList();
                INDEX = 0;

                string nomiselect = "select nomnam, nomad1, nomad2,nomad3 from lund.nominee where polno = " + polno + " ";
                if (reminderObj.existRecored(nomiselect) != 0)
                {
                    #region get Nominee name and address

                    reminderObj.readSql(nomiselect);
                    OracleDataReader nomireader = reminderObj.oraComm.ExecuteReader();
                    while (nomireader.Read())
                    {                       
                        if (!nomireader.IsDBNull(0)) { Address1.Add(nomireader.GetString(0)); } else { Address1.Add(""); }
                        if (!nomireader.IsDBNull(1)) { Address1.Add(nomireader.GetString(1)); } else { Address1.Add(""); }
                        if (!nomireader.IsDBNull(2)) { Address1.Add(nomireader.GetString(2)); } else { Address1.Add(""); }
                        if (!nomireader.IsDBNull(3)) { Address1.Add(nomireader.GetString(3)); } else { Address1.Add(""); }
                    }
                    nomireader.Close();

                    this.litName.Text = Address1[0].ToString();
                    this.litAd1.Text = Address1[1].ToString();
                    this.litAd2.Text = Address1[2].ToString();
                    this.litAd3.Text = Address1[3].ToString();
                    #endregion
                }
                //else
                //{
                    #region Get Informer Address
                    string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
                    if (reminderObj.existRecored(dclmAddressSelect) != 0)
                    {

                        reminderObj.readSql(dclmAddressSelect);
                        OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { litName.Text = dthintReader.GetString(0); AddressList1.Add(dthintReader.GetString(0)); }
                            else { litName.Text = ""; AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { litAd1.Text = dthintReader.GetString(1); AddressList1.Add(dthintReader.GetString(1)); }
                            else { litAd1.Text = ""; AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { litAd2.Text = dthintReader.GetString(2); AddressList1.Add(dthintReader.GetString(2)); }
                            else { litAd2.Text = ""; AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { litAd3.Text = dthintReader.GetString(3); AddressList1.Add(dthintReader.GetString(3)); }
                            else { litAd3.Text = ""; AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { litAd4.Text = dthintReader.GetString(4); AddressList1.Add(dthintReader.GetString(4)); }
                            else { litAd4.Text = ""; AddressList1.Add(""); }
                            AddressList1.Add("");
                            AddressList1.Add(""); AddressList1.Add("");
                            if (AddressList1[0].ToString() != "")
                            {
                                CopyArray.Add(AddressList1);
                            }
                        }
                    }
                    #endregion

                    else
                    {
                       #region // ------ address details are not found on the dclm addresses table ----
                    string dthintSelect = "select diname, diad1, diad2, diad3, diad4,dclm from lphs.dthint where dpolno = " + polno + " and dmos='" + MOF + "'";
                    if (reminderObj.existRecored(dthintSelect) != 0)
                    {
                        reminderObj.readSql(dthintSelect);
                        OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { name = dthintReader.GetString(0); AddressList1.Add(dthintReader.GetString(0)); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { ad1 = dthintReader.GetString(1); AddressList1.Add(dthintReader.GetString(1)); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { ad2 = dthintReader.GetString(2); AddressList1.Add(dthintReader.GetString(2)); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { ad3 = dthintReader.GetString(3); AddressList1.Add(dthintReader.GetString(3)); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { ad4 = dthintReader.GetString(4); AddressList1.Add(dthintReader.GetString(4)); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(5)) { DeathClaimNumber = dthintReader.GetInt32(5); }
                        }
                        dthintReader.Close();


                        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                        this.litName.Text = name;
                        this.litAd1.Text = ad1;
                        this.litAd2.Text = ad2;
                        this.litAd3.Text = ad3;
                        this.litAd4.Text = ad4;
                        this.lblEPF.Text = DeathClaimNumber.ToString();
                        if (AddressList1[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList1);
                        }
                    }
                    #endregion
                    }

                //}
                #region Load Branch Administration Officers Address

                INDEX = 2;
                string BranchAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
                if (reminderObj.existRecored(BranchAddressSelect) != 0)
                {
                    reminderObj.readSql(BranchAddressSelect);
                    OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        brcopy = true;
                        if (!dthintReader.IsDBNull(0)) { AddressList2.Add(dthintReader.GetString(0)); litbrname.Text = dthintReader.GetString(0); }
                        else { AddressList2.Add(""); litbrname.Text = ""; }
                        if (!dthintReader.IsDBNull(1)) { AddressList2.Add(dthintReader.GetString(1)); litbrad1.Text = dthintReader.GetString(1); }
                        else { AddressList2.Add(""); litbrad1.Text = ""; }
                        if (!dthintReader.IsDBNull(2)) { AddressList2.Add(dthintReader.GetString(2)); litbrad2.Text = dthintReader.GetString(2); }
                        else { AddressList2.Add(""); litbrad2.Text = ""; }
                        if (!dthintReader.IsDBNull(3)) { AddressList2.Add(dthintReader.GetString(3)); litbrad3.Text = dthintReader.GetString(3); }
                        else { AddressList2.Add(""); litbrad3.Text = ""; }
                        if (!dthintReader.IsDBNull(4)) { AddressList2.Add(dthintReader.GetString(4)); litbrad4.Text = dthintReader.GetString(4); }
                        else { AddressList2.Add(""); litbrad4.Text = ""; }
                        AddressList2.Add(""); AddressList2.Add("");
                        if (AddressList2[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList2);
                        }
                    }
                }

                #endregion

                #region Load Agent Code


                string AgentCodeSelect = "select DRAGT from LPHS.DTHREF where DRPOLNO = " + polno + " ";
                if (reminderObj.existRecored(AgentCodeSelect) != 0)
                {
                    reminderObj.readSql(AgentCodeSelect);
                    OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { AGENTCode = dthintReader.GetInt32(0); }
                    }
                    AGENCY = AGENTCode;
                }

                #endregion

                #region Load Insurance Advisors Address


                if (AGENCY != 0)
                {
                    string InsuranceOffAddressSelect = "select STATUS ||''||INT||''||NAME as NAME,AD1,AD2,AD3,AD4,AD5 from AGENT.AGENT where AGENCY = " + AGENCY + " and STCD<>'5' and STCD<>'8' and STCD<>'9'";
                    #region If Agent Inforce
                    if (reminderObj.existRecored(InsuranceOffAddressSelect) != 0)
                    {
                        agcopy = true;
                        reminderObj.readSql(InsuranceOffAddressSelect);
                        OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { AddressList3.Add(dthintReader.GetString(0).Trim()); litagname.Text = dthintReader.GetString(0); }
                            else { AddressList3.Add(""); litagname.Text = ""; }
                            if (!dthintReader.IsDBNull(1)) { AddressList3.Add(dthintReader.GetString(1)); litagad1.Text = dthintReader.GetString(1); }
                            else { AddressList3.Add(""); litagad1.Text = ""; }
                            if (!dthintReader.IsDBNull(2)) { AddressList3.Add(dthintReader.GetString(2)); litagad2.Text = dthintReader.GetString(2); }
                            else { AddressList3.Add(""); litagad2.Text = ""; }
                            if (!dthintReader.IsDBNull(3)) { AddressList3.Add(dthintReader.GetString(3)); litagad3.Text = dthintReader.GetString(3); }
                            else { AddressList3.Add(""); litagad3.Text = ""; }
                            if (!dthintReader.IsDBNull(4)) { AddressList3.Add(dthintReader.GetString(4)); litagad4.Text = dthintReader.GetString(4); }
                            else { AddressList3.Add(""); litagad4.Text = ""; }
                            if (!dthintReader.IsDBNull(5)) { AddressList3.Add(dthintReader.GetString(5)); litagad5.Text = dthintReader.GetString(5); }
                            else { AddressList3.Add(""); litagad5.Text = ""; }
                            AddressList3.Add(AGENCY);
                            if (AddressList3[0].ToString() != "")
                            {
                                CopyArray.Add(AddressList3);
                            }
                        }
                    }
                    #endregion

                    #region If Agent Terminated Then Branch Sales Managers Address
                    else
                    {
                        INDEX = 4;
                        string Br_SM_Address = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
                        if (reminderObj.existRecored(Br_SM_Address) != 0)
                        {
                            agcopy = true;
                            OracleDataReader odr = reminderObj.oraComm.ExecuteReader();
                            while (odr.Read())
                            {
                                if (!odr.IsDBNull(0)) { AddressList3.Add(odr.GetString(0).Trim()); litagname.Text = odr.GetString(0); }
                                else { AddressList3.Add(""); litagname.Text = ""; }
                                if (!odr.IsDBNull(1)) { AddressList3.Add(odr.GetString(1)); litagad1.Text = odr.GetString(1); }
                                else { AddressList3.Add(""); litagad1.Text = ""; }
                                if (!odr.IsDBNull(2)) { AddressList3.Add(odr.GetString(2)); litagad2.Text = odr.GetString(2); }
                                else { AddressList3.Add(""); litagad2.Text = ""; }
                                if (!odr.IsDBNull(3)) { AddressList3.Add(odr.GetString(3)); litagad3.Text = odr.GetString(3); }
                                else { AddressList3.Add(""); litagad3.Text = ""; }
                                if (!odr.IsDBNull(4)) { AddressList3.Add(odr.GetString(4)); litagad4.Text = odr.GetString(4); }
                                else { AddressList3.Add(""); litagad4.Text =""; }
                                if (!odr.IsDBNull(5)) { AddressList3.Add(odr.GetString(5)); litagad5.Text = odr.GetString(5); }
                                else { AddressList3.Add(""); litagad4.Text =""; }
                                AddressList3.Add("");
                                if (AddressList3[0].ToString() != "")
                                {
                                    CopyArray.Add(AddressList3);
                                }
                            }
                        }
                    }
            
                    #endregion
                }

                #endregion                

                #region Load Reginal Cordinators Address

                INDEX = 5;
                string Region_Cor_Select = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
                if (reminderObj.existRecored(Region_Cor_Select) != 0)
                {
                    rgcod = true;
                    reminderObj.readSql(Region_Cor_Select);
                    OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { AddressList4.Add(dthintReader.GetString(0)); litrgcdname.Text = dthintReader.GetString(0); }
                        else { AddressList4.Add(""); litrgcdname.Text = ""; }
                        if (!dthintReader.IsDBNull(1)) { AddressList4.Add(dthintReader.GetString(1)); litrgcdad1.Text = dthintReader.GetString(1); }
                        else { AddressList4.Add(""); litrgcdad1.Text = ""; }
                        if (!dthintReader.IsDBNull(2)) { AddressList4.Add(dthintReader.GetString(2)); litrgcdad2.Text = dthintReader.GetString(2); }
                        else { AddressList4.Add(""); litrgcdad2.Text =""; }
                        if (!dthintReader.IsDBNull(3)) { AddressList4.Add(dthintReader.GetString(3)); litrgcdad3.Text = dthintReader.GetString(3); }
                        else { AddressList4.Add(""); litrgcdad3.Text =""; }
                        if (!dthintReader.IsDBNull(4)) { AddressList4.Add(dthintReader.GetString(4)); litrgcdad4.Text = dthintReader.GetString(4); }
                        else { AddressList4.Add(""); litrgcdad4.Text = ""; }
                        AddressList4.Add(""); AddressList4.Add("");
                        if (AddressList4[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList4);
                        }
                    }
                }

                #endregion

                #region Load Reginal Sales Managers Address

                INDEX = 6;
                string Region_Sm_Select = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
                if (reminderObj.existRecored(Region_Sm_Select) != 0)
                {
                    rgsm = true;
                    reminderObj.readSql(Region_Sm_Select);
                    OracleDataReader dthintReader = reminderObj.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { AddressList5.Add(dthintReader.GetString(0)); litrgsmname.Text = dthintReader.GetString(0); }
                        else { AddressList5.Add(""); litrgsmname.Text =""; }
                        if (!dthintReader.IsDBNull(1)) { AddressList5.Add(dthintReader.GetString(1)); litrgsmad1.Text = dthintReader.GetString(1); }
                        else { AddressList5.Add(""); litrgsmad1.Text = ""; }
                        if (!dthintReader.IsDBNull(2)) { AddressList5.Add(dthintReader.GetString(2)); litrgsmad2.Text = dthintReader.GetString(2); }
                        else { AddressList5.Add(""); litrgsmad2.Text = ""; }
                        if (!dthintReader.IsDBNull(3)) { AddressList5.Add(dthintReader.GetString(3)); litrgsmad3.Text = dthintReader.GetString(3); }
                        else { AddressList5.Add(""); litrgsmad3.Text = ""; }
                        if (!dthintReader.IsDBNull(4)) { AddressList5.Add(dthintReader.GetString(4)); litrgsmad4.Text = dthintReader.GetString(4); }
                        else { AddressList5.Add(""); litrgsmad4.Text = ""; }
                        AddressList5.Add(""); AddressList5.Add("");
                        if (AddressList5[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList5);
                        }
                    }
                }

                #endregion

                #region // ************** PHNAME  ******************************************************
                string phname = "";
                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, " +
                    " phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                reminderObj.readSql(sql);
                OracleDataReader oraDtReader = reminderObj.oraComm.ExecuteReader();

                while (oraDtReader.Read())
                {
                    if ((!oraDtReader.IsDBNull(0)) && ((!oraDtReader.IsDBNull(1))) && ((!oraDtReader.IsDBNull(2))))
                    {
                        phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                    }
                }
                oraDtReader.Close();

                #endregion

                #region // ------ Get the Claim Number ----
                string dthintSelect1 = "select dclm from lphs.dthint where dpolno = " + polno + " and dmos='" + MOF + "'";

                reminderObj.readSql(dthintSelect1);
                OracleDataReader dthintReader1 = reminderObj.oraComm.ExecuteReader();
                while (dthintReader1.Read())
                {
                    if (!dthintReader1.IsDBNull(0)) { DeathClaimNumber = dthintReader1.GetInt32(0); }
                }
                dthintReader1.Close();
                this.lblEPF.Text = DeathClaimNumber.ToString();
                #endregion

                this.litpolno.Text = polno.ToString();
                this.litlifeassured.Text = phname;

                int rowNum = 1;
                //bool existflag = false;
                string dreqSelect = "select drcovtyp, drrema, DRSENTDT from lphs.dreq " +
                    " where drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and DRSENTDT >0 and (REMINDERDT = 0 or REMINDERDT is null) ";
                if (reminderObj.existRecored(dreqSelect) != 0)
                {
                    #region ---- first reminder ----
                    Rem_no = 1;
                    reminderObj.readSql(dreqSelect);
                    OracleDataReader dreqreader = reminderObj.oraComm.ExecuteReader();
                    while (dreqreader.Read())
                    {
                        if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                        if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                        if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }
                        ReqcodeList.Add(reqcode);
                        yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                        mnthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                        dawasdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                        if (yeardiff > 0 || mnthdiff > 0 || dawasdiff > 14)
                        {
                            arr.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks, Lett_Type));
                            rowNum++;
                        }
                    }
                    litceo.Visible = false;
                    dreqreader.Close();
                    this.litdated.Text = sentDate.ToString().Substring(0, 4) + "/" + sentDate.ToString().Substring(4, 2) + "/" + sentDate.ToString().Substring(6, 2);
                    lblsubsequentrem.Visible = false;
                    #endregion
                }
                else
                {
                    #region ---- Second reminder ----
                    string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT, REMINDERDT from lphs.dreq where " +
                    " drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and  DRSENTDT >0 and REMINDERDT >0 and (SECOND_REMINDER_DT = 0 or SECOND_REMINDER_DT is null)";
                    if (reminderObj.existRecored(dreqSelect2) != 0)
                    {
                        Rem_no = 2;
                        reminderObj.readSql(dreqSelect2);
                        OracleDataReader dreqreader = reminderObj.oraComm.ExecuteReader();
                        while (dreqreader.Read())
                        {
                            if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                            if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                            if (!dreqreader.IsDBNull(3)) { remindersentdate = dreqreader.GetInt32(3); } else { remindersentdate = 0; }
                            if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }
                            ReqcodeList.Add(reqcode);
                            yeardiff = this.dateComparison(remindersentdate, int.Parse(this.setDate()[0]))[0];
                            mnthdiff = this.dateComparison(remindersentdate, int.Parse(this.setDate()[0]))[1];
                            dawasdiff = this.dateComparison(remindersentdate, int.Parse(this.setDate()[0]))[2];

                            if (yeardiff > 0 || mnthdiff > 0 || dawasdiff > 14)
                            {
                                arr.Add(new reminderDocset(rowNum, reqcode, remindersentdate, remarks, Lett_Type));
                                rowNum++;
                            }
                        }
                        litceo.Visible = true;
                        lblsubsequentrem.Visible = true;
                        dreqreader.Close();
                        this.litdated.Text = sentDate.ToString().Substring(0, 4) + "/" + sentDate.ToString().Substring(4, 2) + "/" + sentDate.ToString().Substring(6, 2);
                        this.litsubseqdt1.Text = remindersentdate.ToString().Substring(0, 4) + "/" + remindersentdate.ToString().Substring(4, 2) + "/" + remindersentdate.ToString().Substring(6, 2);
                    #endregion
                    }
                    else
                    {
                        #region ---- Third reminder ----
                        string dreqSelect3 = "select drcovtyp, drrema, DRSENTDT, REMINDERDT, SECOND_REMINDER_DT from lphs.dreq " +
                            " where drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and  DRSENTDT >0 and REMINDERDT >0 and SECOND_REMINDER_DT > 0 and (THIRD_REMINDER_DT = 0 or THIRD_REMINDER_DT is null)";
                        if (reminderObj.existRecored(dreqSelect3) != 0)
                        {
                            Rem_no = 3;
                            reminderObj.readSql(dreqSelect3);
                            OracleDataReader dreqreader = reminderObj.oraComm.ExecuteReader();
                            while (dreqreader.Read())
                            {
                                if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                                if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                                if (!dreqreader.IsDBNull(3)) { remindersentdate = dreqreader.GetInt32(3); } else { remindersentdate = 0; }
                                if (!dreqreader.IsDBNull(4)) { secondremsentdt = dreqreader.GetInt32(4); } else { secondremsentdt = 0; }
                                if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }
                                ReqcodeList.Add(reqcode);
                                yeardiff = this.dateComparison(secondremsentdt, int.Parse(this.setDate()[0]))[0];
                                mnthdiff = this.dateComparison(secondremsentdt, int.Parse(this.setDate()[0]))[1];
                                dawasdiff = this.dateComparison(secondremsentdt, int.Parse(this.setDate()[0]))[2];

                                if (yeardiff > 0 || mnthdiff >= 1)
                                {
                                    arr.Add(new reminderDocset(rowNum, reqcode, secondremsentdt, remarks, Lett_Type));
                                    rowNum++;
                                }
                            }
                            litceo.Visible = true;
                            dreqreader.Close();
                            this.litdated.Text = sentDate.ToString().Substring(0, 4) + "/" + sentDate.ToString().Substring(4, 2) + "/" + sentDate.ToString().Substring(6, 2);
                            this.litsubseqdt1.Text = remindersentdate.ToString().Substring(0, 4) + "/" + remindersentdate.ToString().Substring(4, 2) + "/" + remindersentdate.ToString().Substring(6, 2);
                            this.litsubseqdt1.Text = secondremsentdt.ToString().Substring(0, 4) + "/" + secondremsentdt.ToString().Substring(4, 2) + "/" + secondremsentdt.ToString().Substring(6, 2);
                        }
                        else { throw new Exception("No Requirement Details!"); }
                        #endregion
                    }

                }

                int count = 0;
                foreach (reminderDocset req in arr)
                {
                    count++;
                    createReqDescTable(count.ToString(), req.Reqdesc, (count - 1), req.REQCODE);
                }
                reminderObj.connclose();
            }
            catch (Exception ex)
            {
                reminderObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            arr = new ArrayList();
            polno = long.Parse(Session["polno"].ToString());
            MOF = Session["MOF"].ToString();
            reminderObj = new DataManager();
            int rowNum = 1;
            //bool existflag = false;
            string dreqSelect = "select drcovtyp, drrema, DRSENTDT from lphs.dreq " +
                " where drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and DRSENTDT >0 and (REMINDERDT = 0 or REMINDERDT is null) ";
            if (reminderObj.existRecored(dreqSelect) != 0)
            {
                #region ---- first reminder ----

                reminderObj.readSql(dreqSelect);
                OracleDataReader dreqreader = reminderObj.oraComm.ExecuteReader();
                while (dreqreader.Read())
                {
                    if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                    if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                    if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }
                    ReqcodeList.Add(reqcode);
                    yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                    mnthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                    dawasdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                    if (yeardiff > 0 || mnthdiff > 0 || dawasdiff > 14)
                    {
                        arr.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks, Lett_Type));
                        rowNum++;
                    }
                }
                dreqreader.Close();
                this.litdated.Text = sentDate.ToString().Substring(0, 4) + "/" + sentDate.ToString().Substring(4, 2) + "/" + sentDate.ToString().Substring(6, 2);

                #endregion
            }
            else
            {
                #region ---- Second reminder ----
                string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT, REMINDERDT from lphs.dreq where " +
                " drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and  DRSENTDT >0 and REMINDERDT >0 and (SECOND_REMINDER_DT = 0 or SECOND_REMINDER_DT is null)";
                if (reminderObj.existRecored(dreqSelect2) != 0)
                {
                    reminderObj.readSql(dreqSelect2);
                    OracleDataReader dreqreader = reminderObj.oraComm.ExecuteReader();
                    while (dreqreader.Read())
                    {
                        if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                        if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                        if (!dreqreader.IsDBNull(3)) { remindersentdate = dreqreader.GetInt32(3); } else { remindersentdate = 0; }
                        if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }
                        ReqcodeList.Add(reqcode);
                        yeardiff = this.dateComparison(remindersentdate, int.Parse(this.setDate()[0]))[0];
                        mnthdiff = this.dateComparison(remindersentdate, int.Parse(this.setDate()[0]))[1];
                        dawasdiff = this.dateComparison(remindersentdate, int.Parse(this.setDate()[0]))[2];

                        if (yeardiff > 0 || mnthdiff > 0 || dawasdiff > 14)
                        {
                            arr.Add(new reminderDocset(rowNum, reqcode, remindersentdate, remarks, Lett_Type));
                            rowNum++;
                        }
                    }
                    dreqreader.Close();
                    this.litdated.Text = sentDate.ToString().Substring(0, 4) + "/" + sentDate.ToString().Substring(4, 2) + "/" + sentDate.ToString().Substring(6, 2);
                    this.litsubseqdt1.Text = remindersentdate.ToString().Substring(0, 4) + "/" + remindersentdate.ToString().Substring(4, 2) + "/" + remindersentdate.ToString().Substring(6, 2);
                #endregion
                }
                else
                {
                    #region ---- Third reminder ----
                    string dreqSelect3 = "select drcovtyp, drrema, DRSENTDT, REMINDERDT, SECOND_REMINDER_DT from lphs.dreq " +
                        " where drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and  DRSENTDT >0 and REMINDERDT >0 and SECOND_REMINDER_DT > 0 and (THIRD_REMINDER_DT = 0 or THIRD_REMINDER_DT is null)";
                    if (reminderObj.existRecored(dreqSelect3) != 0)
                    {
                        reminderObj.readSql(dreqSelect3);
                        OracleDataReader dreqreader = reminderObj.oraComm.ExecuteReader();
                        while (dreqreader.Read())
                        {
                            if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                            if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                            if (!dreqreader.IsDBNull(3)) { remindersentdate = dreqreader.GetInt32(3); } else { remindersentdate = 0; }
                            if (!dreqreader.IsDBNull(4)) { secondremsentdt = dreqreader.GetInt32(4); } else { secondremsentdt = 0; }
                            if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }
                            ReqcodeList.Add(reqcode);
                            yeardiff = this.dateComparison(secondremsentdt, int.Parse(this.setDate()[0]))[0];
                            mnthdiff = this.dateComparison(secondremsentdt, int.Parse(this.setDate()[0]))[1];
                            dawasdiff = this.dateComparison(secondremsentdt, int.Parse(this.setDate()[0]))[2];

                            if (yeardiff > 0 || mnthdiff >= 1)
                            {
                                arr.Add(new reminderDocset(rowNum, reqcode, secondremsentdt, remarks, Lett_Type));
                                rowNum++;
                            }
                        }
                        dreqreader.Close();
                        this.litdated.Text = sentDate.ToString().Substring(0, 4) + "/" + sentDate.ToString().Substring(4, 2) + "/" + sentDate.ToString().Substring(6, 2);
                        this.litsubseqdt1.Text = remindersentdate.ToString().Substring(0, 4) + "/" + remindersentdate.ToString().Substring(4, 2) + "/" + remindersentdate.ToString().Substring(6, 2);
                        this.litsubseqdt1.Text = secondremsentdt.ToString().Substring(0, 4) + "/" + secondremsentdt.ToString().Substring(4, 2) + "/" + secondremsentdt.ToString().Substring(6, 2);
                    }
                    else { throw new Exception("No Requirement Details!"); }
                    #endregion
                }                
            }
            int count = 0;
            foreach (reminderDocset req in arr)
            {
                count++;
                createdynDescTable(count.ToString(), req.Reqdesc, (count - 1), req.REQCODE);
            }
            reminderObj.connclose();
        }
        if (Rem_no == 1)
        {
            lbl_remindno.Text = "1st Reminder";
        }
        if (Rem_no == 2)
        {
            lbl_remindno.Text = "2nd Reminder";
        }
        if (Rem_no == 3)
        {
            lbl_remindno.Text = "3rd Reminder";
        }
    }


    public int[] dateComparison(int startdate, int enddate)
    { //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
    }    
  
    private void createReqDescTable(string count, string reqDesc, int rowNumber,int RecordNumber)
    {
        if (RecordNumber != 24)
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            lbl1.ID = "Number" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
            lbl1.Text = count + ".";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";

            if (reqDesc.EndsWith("."))
            {
                lbl2.Text = reqDesc.Remove(reqDesc.Length - 1);
            }
            else
            {
                lbl2.Text = reqDesc;
            }
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";
            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            Table1.Rows.Add(trow);

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if (RecordNumber == 19 || RecordNumber == 20)
                {
                    for (int i = 0; i < 7; i++)
                    {

                        Table1.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                        Table1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                        Table1.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                        Table1.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                        TableRow tr = new TableRow();
                        Table1.Rows.Add(tr);

                        TableCell tc = new TableCell();
                        Label Dynlbl1 = new Label();
                        if (RecordNumber == 19)
                        {
                            Dynlbl1.ID = "Dynlbl9" + i.ToString();
                        }
                        if (RecordNumber == 20)
                        {
                            Dynlbl1.ID = "Dynlbl10" + i.ToString();
                        }

                        if (i == 0) { Dynlbl1.Text = "I."; }
                        if (i == 1) { Dynlbl1.Text = "II."; }
                        if (i == 2) { Dynlbl1.Text = "III."; }
                        if (i == 3) { Dynlbl1.Text = "IV."; }
                        if (i == 4) { Dynlbl1.Text = "V."; }
                        if (i == 5) { Dynlbl1.Text = "VI."; }
                        if (i == 6) { Dynlbl1.Text = "VII."; }

                        Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                        Dynlbl1.ControlStyle.Font.Size = 10;
                        Dynlbl1.Width = 10;
                        tc.Controls.Add(Dynlbl1);
                        tr.Cells.Add(tc);

                        TableCell tc1 = new TableCell();
                        TextBox DyTextBox = new TextBox();
                        if (RecordNumber == 19)
                        {
                            Session["ReqCode9"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox9" + i.ToString();
                        }
                        if (RecordNumber == 20)
                        {
                            Session["ReqCode10"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox10" + i.ToString();
                        }

                        DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                        DyTextBox.ControlStyle.Font.Size = 10;
                        DyTextBox.Width = 350;
                        tc1.Controls.Add(DyTextBox);
                        tr.Cells.Add(tc1);
                        Table1.Rows.Add(tr);
                        // tblDynamic.Rows.Add(tr);
                    }
                }
                if (RecordNumber == 21)
                {
                    ArrayList Changes = new ArrayList();
                    Changes.Add("Assignee Name Change");
                    Changes.Add("Beneficiarie Name Change");

                    for (int j = 0; j < 2; j++)
                    {
                        TableRow tr1 = new TableRow();

                        TableCell tchead = new TableCell();
                        TableCell tchead1 = new TableCell();

                        Label headlbl = new Label();
                        headlbl.Text = Changes[j].ToString();
                        headlbl.Font.Bold = true;
                        headlbl.Font.Underline = true;
                        headlbl.ControlStyle.Font.Name = "Trebuchet MS";
                        headlbl.ControlStyle.Font.Size = 10;
                        headlbl.Width = 200;

                        tchead1.Controls.Add(headlbl);
                        tr1.Cells.Add(tchead);
                        tr1.Cells.Add(tchead1);

                        Table1.Rows.Add(tr1);

                        for (int i = 0; i < 7; i++)
                        {
                            Table1.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            Table1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            Table1.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            Table1.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                            TableRow tr = new TableRow();
                            Table1.Rows.Add(tr);

                            TableCell tc = new TableCell();
                            Label Dynlbl1 = new Label();

                            Dynlbl1.ID = "Dynlbl20" + j.ToString() + i.ToString();

                            if (i == 0) { Dynlbl1.Text = "I."; }
                            if (i == 1) { Dynlbl1.Text = "II."; }
                            if (i == 2) { Dynlbl1.Text = "III."; }
                            if (i == 3) { Dynlbl1.Text = "IV."; }
                            if (i == 4) { Dynlbl1.Text = "V."; }
                            if (i == 5) { Dynlbl1.Text = "VI."; }
                            if (i == 6) { Dynlbl1.Text = "VII."; }

                            Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                            Dynlbl1.ControlStyle.Font.Size = 10;
                            Dynlbl1.Width = 10;
                            tc.Controls.Add(Dynlbl1);
                            tr.Cells.Add(tc);

                            TableCell tc1 = new TableCell();
                            TextBox DyTextBox = new TextBox();

                            if (RecordNumber == 21)
                            {
                                Session["ReqCode11"] = RecordNumber;
                                DyTextBox.ID = "DyTextBox20" + j.ToString() + i.ToString();
                            }

                            DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                            DyTextBox.ControlStyle.Font.Size = 10;
                            DyTextBox.Width = 350;
                            tc1.Controls.Add(DyTextBox);
                            tr.Cells.Add(tc1);
                            Table1.Rows.Add(tr);
                        }
                    }
                }

                TableRow trdes = new TableRow();
                Table1.Rows.Add(trdes);

                TableCell tc5 = new TableCell();

                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString(); 
                    Dynlbl2.Text = "If the above names were used to refer one and same person, please forwards us a Grama Niladhari certificate certifying the above difference counter signed by Divisional Secretary of the Area.";              
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString();
                    Dynlbl2.Text = "if the above names refer to the one and same person, please forward us a certified affidavit for that affect further please note that your signature should be placed on Rs. 25/- stamp and attested by a Justice of Peace";               
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                    Dynlbl2.Text = "If the above names were used to refer the life assured, please forwards us a Grama Niladhari certificate counter signed by Divisional Secretary of the Area for the effect of the differnt found in the life assured's name & an affidavit signed by you and attested by a justice of peace stating that the name difference found in your names were used to refer one and same person. Please note that your signature should be placed on Rs. 25/- stamp.";               
                }
                
                Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
                Dynlbl2.ControlStyle.Font.Size = 10;
                Dynlbl2.Width = 600;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);
            }

            Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;

        }
        else
        {
            if (Address1 != null)
            {
                if (Address1.Count != 0)
                {
                    string Nominees = "";
                    Nominees = Address1[0].ToString();
                    for (int i = 0; i < Address1.Count; i++)
                    {
                        if (i != 0)
                        {
                            Nominees = Nominees + "," + Address1[i].ToString();
                        }
                        i += 3;
                    }
                    litreq21.Text = reqDesc +"  "+ Nominees + "  the claim forms should be signed him/her. If the Nominee was minor, the claim forms should be signed by the legal guardian of the child.";
                }
            }        
        }
    }

    private void createdynDescTable(string count, string reqDesc, int rowNumber, int RecordNumber)
    {
        if (RecordNumber != 24)
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            lbl1.ID = "Number" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
            lbl1.Text = count + ".";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";

            if (reqDesc.EndsWith("."))
            {
                lbl2.Text = reqDesc.Remove(reqDesc.Length - 1);
            }
            else
            {
                lbl2.Text = reqDesc;
            }
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";
            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            Table1.Rows.Add(trow);

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if (RecordNumber == 19 || RecordNumber == 20)
                {
                    for (int i = 0; i < 7; i++)
                    {

                        Table1.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                        Table1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                        Table1.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                        Table1.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                        TableRow tr = new TableRow();
                        Table1.Rows.Add(tr);

                        TableCell tc = new TableCell();
                        Label Dynlbl1 = new Label();
                        if (RecordNumber == 19)
                        {
                            Dynlbl1.ID = "Dynlbl9" + i.ToString();
                        }
                        if (RecordNumber == 20)
                        {
                            Dynlbl1.ID = "Dynlbl10" + i.ToString();
                        }

                        if (i == 0) { Dynlbl1.Text = "I."; }
                        if (i == 1) { Dynlbl1.Text = "II."; }
                        if (i == 2) { Dynlbl1.Text = "III."; }
                        if (i == 3) { Dynlbl1.Text = "IV."; }
                        if (i == 4) { Dynlbl1.Text = "V."; }
                        if (i == 5) { Dynlbl1.Text = "VI."; }
                        if (i == 6) { Dynlbl1.Text = "VII."; }


                        Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                        Dynlbl1.ControlStyle.Font.Size = 10;
                        Dynlbl1.Width = 10;
                        tc.Controls.Add(Dynlbl1);
                        tr.Cells.Add(tc);

                        TableCell tc1 = new TableCell();
                        TextBox DyTextBox = new TextBox();
                        if (RecordNumber == 19)
                        {
                            Session["ReqCode9"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox9" + i.ToString();
                        }
                        if (RecordNumber == 20)
                        {
                            Session["ReqCode10"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox10" + i.ToString();
                        }

                        DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                        DyTextBox.ControlStyle.Font.Size = 10;
                        DyTextBox.Width = 350;
                        tc1.Controls.Add(DyTextBox);
                        tr.Cells.Add(tc1);
                        Table1.Rows.Add(tr);
                        // tblDynamic.Rows.Add(tr);
                    }
                }
                if (RecordNumber == 21)
                {
                    ArrayList Changes = new ArrayList();
                    Changes.Add("Assignee Name Change");
                    Changes.Add("Beneficiarie Name Change");

                    for (int j = 0; j < 2; j++)
                    {
                        TableRow tr1 = new TableRow();

                        TableCell tchead = new TableCell();
                        TableCell tchead1 = new TableCell();

                        Label headlbl = new Label();
                        headlbl.Text = Changes[j].ToString();
                        headlbl.Font.Bold = true;
                        headlbl.Font.Underline = true;
                        headlbl.ControlStyle.Font.Name = "Trebuchet MS";
                        headlbl.ControlStyle.Font.Size = 10;
                        headlbl.Width = 200;

                        tchead1.Controls.Add(headlbl);
                        tr1.Cells.Add(tchead);
                        tr1.Cells.Add(tchead1);

                        Table1.Rows.Add(tr1);

                        for (int i = 0; i < 7; i++)
                        {
                            Table1.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            Table1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            Table1.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            Table1.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                            TableRow tr = new TableRow();
                            Table1.Rows.Add(tr);

                            TableCell tc = new TableCell();
                            Label Dynlbl1 = new Label();

                            Dynlbl1.ID = "Dynlbl20" + j.ToString() + i.ToString();


                            if (i == 0) { Dynlbl1.Text = "I."; }
                            if (i == 1) { Dynlbl1.Text = "II."; }
                            if (i == 2) { Dynlbl1.Text = "III."; }
                            if (i == 3) { Dynlbl1.Text = "IV."; }
                            if (i == 4) { Dynlbl1.Text = "V."; }
                            if (i == 5) { Dynlbl1.Text = "VI."; }
                            if (i == 6) { Dynlbl1.Text = "VII."; }


                            Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                            Dynlbl1.ControlStyle.Font.Size = 10;
                            Dynlbl1.Width = 10;
                            tc.Controls.Add(Dynlbl1);
                            tr.Cells.Add(tc);



                            TableCell tc1 = new TableCell();
                            TextBox DyTextBox = new TextBox();

                            if (RecordNumber == 21)
                            {
                                Session["ReqCode11"] = RecordNumber;
                                DyTextBox.ID = "DyTextBox20" + j.ToString() + i.ToString();
                            }

                            DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                            DyTextBox.ControlStyle.Font.Size = 10;
                            DyTextBox.Width = 350;
                            tc1.Controls.Add(DyTextBox);
                            tr.Cells.Add(tc1);
                            Table1.Rows.Add(tr);
                        }
                    }
                }

                TableRow trdes = new TableRow();
                Table1.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString(); 
                    Dynlbl2.Text = "If the above names were used to refer one and same person, please forwards us a Grama Niladhari certificate certifying the above difference counter signed by Divisional Secretary of the Area.";                
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString(); 
                    Dynlbl2.Text = "if the above names refer to the one and same person, please forward us a certified affidavit for that affect further please note that your signature should be placed on Rs. 25/- stamp and attested by a Justice of Peace";               
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                    Dynlbl2.Text = "If the above names were used to refer the life assured, please forwards us a Grama Niladhari certificate counter signed by Divisional Secretary of the Area for the effect of the differnt found in the life assured's name & an affidavit signed by you and attested by a justice of peace stating that the name difference found in your names were used to refer one and same person. Please note that your signature should be placed on Rs. 25/- stamp.";              
                }

                Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
                Dynlbl2.ControlStyle.Font.Size = 10;
                Dynlbl2.Width = 600;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);
            }

            Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;

        }
        else
        {
            if (Address1 != null)
            {
                if (Address1.Count != 0)
                {
                    string Nominees = "";
                    Nominees = Address1[0].ToString();
                    for (int i = 0; i < Address1.Count; i++)
                    {
                        if (i != 0)
                        {
                            Nominees = Nominees + "," + Address1[i].ToString();
                        }
                        i += 3;
                    }
                    litreq21.Text = reqDesc +" "+ Nominees + " the claim forms should be signed him/her. If the Nominee was minor, the claim forms should be signed by the legal guardian of the child.";
                }
            }
        }
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
    
    protected void btn_print_Click(object sender, EventArgs e)
    {
        ChechedBtn = 1;
        NomineeNamChg = new ArrayList();
        AssuNameChng = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nomihg1 = new ArrayList();
        for (int a = 0; a < ReqcodeList.Count; a++)
        {
            if (int.Parse(ReqcodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)Table1.FindControl("DyTextBox9" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        AssuNameChng.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)Table1.FindControl("DyTextBox10" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        NomineeNamChg.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 21)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        TextBox txtname2 = new TextBox();
                        txtname2 = (TextBox)Table1.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nomihg1.Add(txtname2.Text);
                            }

                        }
                    }
                }
            }
        }

    }

    public ArrayList AssuNameChange
    {
        get { return AssuNameChng; }
        set { AssuNameChng = value; }
    }
    public ArrayList NomineeNameChange
    {
        get { return NomineeNamChg; }
        set { NomineeNamChg = value; }
    }
    public ArrayList AssureandNomineeChanged
    {
        get { return Ass_Nomihg; }
        set { Ass_Nomihg = value; }
    }
    public ArrayList AssureandNomineeChanged1
    {
        get { return Ass_Nomihg1; }
        set { Ass_Nomihg1 = value; }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ChechedBtn = 2;
        NomineeNamChg = new ArrayList();
        AssuNameChng = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nomihg1 = new ArrayList();
        for (int a = 0; a < ReqcodeList.Count; a++)
        {
            if (int.Parse(ReqcodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)Table1.FindControl("DyTextBox9" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        AssuNameChng.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)Table1.FindControl("DyTextBox10" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        NomineeNamChg.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 21)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        TextBox txtname2 = new TextBox();
                        txtname2 = (TextBox)Table1.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nomihg1.Add(txtname2.Text);
                            }

                        }
                    }
                }
            }
        }
    }
}
