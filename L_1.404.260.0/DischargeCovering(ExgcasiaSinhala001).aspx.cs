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

public partial class DischargeCovering_ExgcasiaSinhala_ : System.Web.UI.Page
{
    private int PolicyNo;
    private long ClaimNo;
    private string nameofdeceased;
    private string MOF;
    private int INDEX;
    private string LANG;
    public ArrayList Address1;
    public ArrayList AddressList1;
    public ArrayList AddressList2;
    public ArrayList AddressList3;
    public ArrayList CopyArray;
    private int AGENCY;
    private int AGENTCode;
    private string ReqType;
    private int FirSrReqDate;
    private int SecReqDate;
    private ArrayList AssuNameChng;
    private ArrayList NomineeNamChg;
    private ArrayList Ass_Nomihg;
    private ArrayList Ass_Nomihg1;
    private ArrayList ReqcodeList = new ArrayList();
    DataManager dm = new DataManager();
    private int ChechedBtn;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Polno"] != null)
            {
                PolicyNo = int.Parse(Session["Polno"].ToString());
                litpolno.Text = PolicyNo.ToString();
            }
            if (Session["ClmNo"] != null)
            {
                ClaimNo = int.Parse(Session["ClmNo"].ToString());
                litclmno.Text = ClaimNo.ToString();
            }

            this.litDate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            nameofdeceased = Session["NameDead"].ToString();
            litdthname.Text = nameofdeceased;

            if (Session["MOF"] != null)
            {
                MOF = Session["MOF"].ToString();
            }

            LANG = "E";
            Address1 = new ArrayList();
            AddressList1 = new ArrayList();
            AddressList2 = new ArrayList();
            AddressList3 = new ArrayList();
            CopyArray = new ArrayList();
            #region Load Claimnt Address

            //string nomiselect = "select nomnam, nomad1, nomad2 from lund.nominee where polno = " + PolicyNo + " ";
            //if (dm.existRecored(nomiselect) != 0)
            //{
            //    #region Get Nominee name and address
            //    dm.readSql(nomiselect);
            //    OracleDataReader nomireader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //    while (nomireader.Read())
            //    {
            //        if (!nomireader.IsDBNull(0)) { Address1.Add(nomireader.GetString(0)); } else { Address1.Add(""); }
            //        if (!nomireader.IsDBNull(1)) { Address1.Add(nomireader.GetString(1)); } else { Address1.Add(""); }
            //        if (!nomireader.IsDBNull(2)) { Address1.Add(nomireader.GetString(2)); } else { Address1.Add(""); }
            //        Address1.Add(""); Address1.Add(""); Address1.Add("Customer Copy");
            //    }
            //    nomireader.Close();
            //    nomireader.Dispose();


            //    #endregion
            //}
            //else
            //{
            INDEX = 0;
            string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + PolicyNo + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=0";
            if (dm.existRecored(dclmAddressSelect) != 0)
            {
                dm.readSql(dclmAddressSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { litname.Text = dthintReader.GetString(0); AddressList1.Add(dthintReader.GetString(0)); }
                    else { litname.Text = ""; }
                    if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); AddressList1.Add(dthintReader.GetString(1)); }
                    else { litad1.Text = ""; }
                    if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); AddressList1.Add(dthintReader.GetString(2)); }
                    else { litad2.Text = ""; }
                    if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); AddressList1.Add(dthintReader.GetString(3)); }
                    else { litad3.Text = ""; }
                    if (!dthintReader.IsDBNull(4)) { litad3.Text = dthintReader.GetString(4); AddressList1.Add(dthintReader.GetString(4)); }
                    else { litad4.Text = ""; }
                    AddressList1.Add("");
                    AddressList1.Add(""); AddressList1.Add("Customer Copy");
                    if (AddressList1[0].ToString() != "")
                    {
                        CopyArray.Add(AddressList1);
                    }
                }
                dthintReader.Dispose();

            }
            else
            {
                #region //**********Get Informer name from DthInt Table if that not exist in Devlaimeraddress Table

                string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + PolicyNo + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { litname.Text = dthintReader.GetString(0); AddressList1.Add(litname.Text); } else { AddressList1.Add(""); }
                        if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); AddressList1.Add(litad1.Text); } else { AddressList1.Add(""); }
                        if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); AddressList1.Add(litad2.Text); } else { AddressList1.Add(""); }
                        if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); AddressList1.Add(litad3.Text); } else { AddressList1.Add(""); }
                        if (!dthintReader.IsDBNull(4)) { litad4.Text = dthintReader.GetString(4); AddressList1.Add(litad4.Text); } else { AddressList1.Add(""); }
                        //if (!dthintReader.IsDBNull(5)) { this.lblyrref.Text = dthintReader.GetString(5); AddressList1.Add(lblyrref.Text); } else { AddressList1.Add(""); }
                        //if (!dthintReader.IsDBNull(6)) { this.litorref.Text = dthintReader.GetInt64(6); }
                    }
                    dthintReader.Close();
                    AddressList1.Add("");
                    AddressList1.Add(""); AddressList1.Add("Customer Copy");
                    this.litname.Text = AddressList1[0].ToString();
                    this.litad1.Text = AddressList1[1].ToString();
                    this.litad2.Text = AddressList1[2].ToString();
                    this.litad3.Text = AddressList1[3].ToString();
                    this.litad4.Text = AddressList1[4].ToString();
                    //this.litnameofdead.Text = DNOD;
                    // this.lblyrref.Text = epfStr;
                    //this.litorref.Text = cliamNo.ToString();
                    // this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    if (AddressList1[0].ToString() != "")
                    {
                        CopyArray.Add(AddressList1);
                    }
                //}
                #endregion
            }
            }

            #endregion

            #region Load Branch Administration Officers Address

            INDEX = 2;
            string BranchAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + PolicyNo + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=2";
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
                    AddressList2.Add(""); AddressList2.Add(""); AddressList2.Add("BRANCH   COPY");
                    if (AddressList2[0].ToString() != "")
                    {
                        CopyArray.Add(AddressList2);
                    }
                }
                dthintReader.Dispose();

            }

            #endregion

            #region Load Agent Code


            string AgentCodeSelect = "select DRAGT from LPHS.DTHREF where DRPOLNO = " + PolicyNo + " ";
            if (dm.existRecored(AgentCodeSelect) != 0)
            {
                dm.readSql(AgentCodeSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { AGENTCode = dthintReader.GetInt32(0); }
                }
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
                        AddressList3.Add("INSURANCE  ADVISOR'S  COPY");
                        if (AddressList3[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList3);
                        }

                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }
            }

            #endregion

            //#region Get the Requiements which has not received yet

            //int reqcode;
            //string reqdesc = "";
            //int rows = 0;
            //string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + PolicyNo + " and drtyp='" + MOF + "' and (drrecdt is null or drrecdt = 0) ";
            //dm.readSql(dreqSelect);
            //OracleDataReader dreqreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //while (dreqreader.Read())
            //{
            //    reqcode = dreqreader.GetInt32(0);
            //    dreqSelect = "select DREQDESCSIN from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
            //    dm.readSql(dreqSelect);
            //    OracleDataReader dreqreader02 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //    while (dreqreader02.Read())
            //    {
            //        if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); }
            //    }
            //    dreqreader02.Close();
            //    dreqreader02.Dispose();
            //    int row = rows + 1;
            //    this.createDynamicTable(row.ToString(), reqdesc, rows, reqcode);
            //    if (reqcode != 22 && reqcode != 23 && reqcode != 24)
            //    {
            //        rows++;
            //    }
            //}
            //dreqreader.Close();
            //dreqreader.Dispose();

            //if (Session["Req22"] != null)
            //{
            //    litreq22.Text = Session["Req22"].ToString();
            //}
            //if (Session["Req23"] != null)
            //{
            //    litreq23.Text = Session["Req23"].ToString();
            //}
            //if (Session["Req21"] != null)
            //{
            //    litreq21.Text = Session["Req21"].ToString();
            //    litnomname.Text = Session["NomName"].ToString();
            //    litreq2.Text = Session["Req21_2"].ToString();
            //}
            ////dreqreader.Close();
            //#endregion

            //#region get Date of reqirement sent
            //string SelectSecondReqDate = "select SECONDREQUESTYN,DRSENTDT,SECONDREQUESTDATE from lphs.dreq where drpol=" + PolicyNo + "";
            //if (dm.existRecored(SelectSecondReqDate) != 0)
            //{

            //    dm.readSql(SelectSecondReqDate);
            //    OracleDataReader dthintReader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //    while (dthintReader2.Read())
            //    {
            //        if (!dthintReader2.IsDBNull(0)) { ReqType = dthintReader2.GetString(0); }
            //        else { ReqType = ""; }
            //        if (!dthintReader2.IsDBNull(1)) { FirSrReqDate = dthintReader2.GetInt32(1); }
            //        else { FirSrReqDate = 0; }
            //        if (!dthintReader2.IsDBNull(2)) { SecReqDate = dthintReader2.GetInt32(2); }
            //        else { SecReqDate = 0; }

            //    }
            //    dthintReader2.Close();
            //    dthintReader2.Dispose();

            //    if (ReqType == "N")
            //    {
            //        //   litletterdated.Text = FirSrReqDate.ToString().Substring(0, 4) + "/" + FirSrReqDate.ToString().Substring(4, 2) + "/" + FirSrReqDate.ToString().Substring(6, 2);
            //    }
            //    else
            //    {
            //        //  litletterdated.Text = SecReqDate.ToString().Substring(0, 4) + "/" + SecReqDate.ToString().Substring(4, 2) + "/" + SecReqDate.ToString().Substring(6, 2);
            //    }
            //}
            //#endregion
        }
        //else
        //{
        //    #region Get the Requiements which has not received yet
        //    PolicyNo = int.Parse(Session["Polno"].ToString());
        //    MOF = Session["MOF"].ToString();
        //    dm = new DataManager();
        //    int reqcode;
        //    string reqdesc = "";
        //    int rows = 0;
        //    string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + PolicyNo + " and drtyp='" + MOF + "' and (drrecdt is null or drrecdt = 0) ";
        //    dm.readSql(dreqSelect);
        //    OracleDataReader dreqreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (dreqreader.Read())
        //    {

        //        reqcode = dreqreader.GetInt32(0);
        //        ReqcodeList.Add(reqcode);
        //        dreqSelect = "select DREQDESCSIN from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
        //        dm.readSql(dreqSelect);
        //        OracleDataReader dreqreader02 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //        while (dreqreader02.Read())
        //        {
        //            if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); }
        //        }
        //        dreqreader02.Close();
        //        dreqreader02.Dispose();
        //        int row = rows + 1;
        //        this.createDynamicTable(row.ToString(), reqdesc, rows, reqcode);
        //        if (reqcode != 22 && reqcode != 23 && reqcode != 24)
        //        {
        //            rows++;
        //        }

        //    }
            //if (Session["Req22"] != null)
            //{
            //    litreq22.Text = Session["Req22"].ToString();
            //}
            //if (Session["Req23"] != null)
            //{
            //    litreq23.Text = Session["Req23"].ToString();
            //}
            //if (Session["Req21"] != null)
            //{
            //    litreq21.Text = Session["Req21"].ToString();
            //    litnomname.Text = Session["NomName"].ToString();
            //    litreq2.Text = Session["Req21_2"].ToString();
            //}
        //    dreqreader.Close();
        //    dreqreader.Dispose();



        //    #endregion

        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {

    }
}
