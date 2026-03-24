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
using System.Text;

public partial class secondReq002Tam : System.Web.UI.Page
{
    #region Variables

    private int polno;
    private string NOD;
    private string MOF;
    private long cliamNo;
    private int reqCode;
    private string secReqDesc;
    private string reqDesc;

    DataManager formObj;
    protected ArrayList reqList;

    private string LANG = "";
    private int INDEX = 0;
    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    private string ADDRESS3 = "";
    private string ADDRESS4 = "";
    private string ADDRESS5 = "";
    private string DINAME = "";
    private string DIAD1 = "";
    private string DIAD2 = "";
    private string DIAD3 = "";
    private string DIAD4 = "";
    private int FirstReqDT = 0;
    private int NomCount = 0;

    public ArrayList Address1;
    public ArrayList Address2;
    public ArrayList Address3;
    public ArrayList Address4;
    public ArrayList Address5;
    public ArrayList Address6;
    public ArrayList Address7;
    public ArrayList Address8;
    public ArrayList CopyToArr;
    public ArrayList printToArr;
    int AGENTCode;
    int AGENCY;
    private ArrayList ReqCodeList = new ArrayList();
    private ArrayList AssuNameChng;
    private ArrayList NomineeNamChg;
    private ArrayList Ass_Nomihg;
    private ArrayList Ass_Nom_NameChng2;
    private ArrayList Nominee;

    public int ChechedBtn;
    private bool signatureDisplay;

    #endregion

    #region Method to set Date

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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        int rowNum = 0;
        formObj = new DataManager();
        string EPF = "";


        if (PreviousPage != null)
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
            ChechedBtn = this.PreviousPage.CHECKEDBTN;
            AssuNameChng = this.PreviousPage.AssuNameChange;
            NomineeNamChg = this.PreviousPage.NomineeNameChange;
            Ass_Nomihg = this.PreviousPage.AssureandNomineeChanged;
            Ass_Nom_NameChng2 = this.PreviousPage.AssureandNomineeChanged1;
            signatureDisplay = this.PreviousPage.SIGNATUREDISPLAY;

        }

        #region Add signature 

        if (signatureDisplay)
        {
            lblSignature.Visible = true;
            lblSigName.Visible = true;
            lblepf.Visible = true;
            lblDesig.Visible = true;
            lbldip.Visible = true;
            lblComp.Visible = true;


            if (Session["EPFNum"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }

            else
            {
                Response.Redirect("SessionError.aspx");
            }

            if (EPF != "")
            {
                SignatureData signatureData = new SignatureData();
                signatureData = signatureData.getSignature(EPF);
                if (signatureData.Signature != null)
                {
                    lblSignature.Visible = true;
                    string ImageName = EPF.PadLeft(5, '0') + "_sign.png";
                    System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                    SignatureImage.ImageUrl = "~/image/" + ImageName;
                    if (ChechedBtn == 2)
                    {
                        SignatureImage.ImageUrl = signatureData.GetAbsoluteUrl(SignatureImage.ImageUrl, Request.Url.AbsoluteUri);
                    }
                }
                else
                {
                    lblSignature.Visible = false;
                }
                this.lblSigName.Text = signatureData.UserName + " ";
                this.lbldip.Text = "Life Insurance Section";
                this.lblComp.Text = "Sri Lanka Insurance Corporation Life Ltd";
                this.lblepf.Text = "( " + signatureData.EPF + " )";

                if (signatureData.Role != null)
                {
                    this.lblDesig.Text = signatureData.Role;
                }
                else
                {
                    this.lblDesig.Text = "Authorized Officer";
                }
            }
        }
        #endregion

        if (!IsPostBack)
        {
            Address1 = new ArrayList();
            Address2 = new ArrayList();
            Address3 = new ArrayList();
            Address4 = new ArrayList();
            Address5 = new ArrayList();
            Address6 = new ArrayList();
            Address7 = new ArrayList();
            Address8 = new ArrayList();
            CopyToArr = new ArrayList();
            printToArr = new ArrayList();
            Nominee = new ArrayList();

            try
            {
                string dthintSelect1 = "select DNOD, DCLM, DINAME, DIAD1, DIAD2, DIAD3, DIAD4 from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (formObj.existRecored(dthintSelect1) != 0)
                {
                    formObj.readSql(dthintSelect1);
                    OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { NOD = dthintReader.GetString(0); } else { NOD = ""; }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); } else { cliamNo = 0; }
                        if (!dthintReader.IsDBNull(2)) { DINAME = dthintReader.GetString(2); } else { DINAME = ""; }
                        if (!dthintReader.IsDBNull(3)) { DIAD1 = dthintReader.GetString(3); } else { DIAD1 = ""; }
                        if (!dthintReader.IsDBNull(4)) { DIAD2 = dthintReader.GetString(4); } else { DIAD2 = ""; }
                        if (!dthintReader.IsDBNull(5)) { DIAD3 = dthintReader.GetString(5); } else { DIAD3 = ""; }
                        if (!dthintReader.IsDBNull(6)) { DIAD4 = dthintReader.GetString(6); } else { DIAD4 = ""; }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }

                this.lblName.Text = DINAME;
                this.lblAdd1.Text = DIAD1;
                this.lblAdd2.Text = DIAD2;
                this.lblAdd3.Text = DIAD3;
                this.lblAdd4.Text = DIAD4;

                this.ltlClaimNo.Text = cliamNo.ToString();
                this.lblLetterDate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblNameofDeath.Text = NOD;
                this.lblPolNo.Text = polno.ToString();

                #region Get Date of first reqirement sent

                int recCout = 0;
                //string SelectFirstReqDate = "select min(DRSENTDT) from lphs.dreq where drpol=" + polno + " and DRTYP='" + MOF + "' and SYSTEM_TYPE='D'";
                string SelectFirstReqDate = "select DRSENTDT from lphs.dreq a where drpol=" + polno + " and DRTYP='" + MOF + "' and SYSTEM_TYPE='D'  group by DRSENTDT order by DRSENTDT DESC";
                if (formObj.existRecored(SelectFirstReqDate) != 0)
                {

                    formObj.readSql(SelectFirstReqDate);
                    OracleDataReader dthintReader2 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader2.Read())
                    {
                        recCout++;

                        if (recCout == 2)
                        {
                            if (!dthintReader2.IsDBNull(0)) { FirstReqDT = dthintReader2.GetInt32(0); }
                            else { FirstReqDT = 0; }
                        }
                    }

                    if (recCout == 1)
                    {
                        formObj.readSql(SelectFirstReqDate);
                        OracleDataReader dthintReader3 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader3.Read())
                        {
                            if (!dthintReader3.IsDBNull(0)) { FirstReqDT = dthintReader3.GetInt32(0); }
                            else { FirstReqDT = 0; }
                        }

                        dthintReader3.Close();
                        dthintReader3.Dispose();
                    }

                    dthintReader2.Close();
                    dthintReader2.Dispose();
                    lblFirstDate.Text = FirstReqDT.ToString().Substring(0, 4) + "/" + FirstReqDT.ToString().Substring(4, 2) + "/" + FirstReqDT.ToString().Substring(6, 2);
                }

                #endregion

                #region Get Nominee Details

                string nomiselect = "select nomnam, nomad1, nomad2,nomad3 from lund.nominee where polno = " + polno + " ";
                if (formObj.existRecored(nomiselect) != 0)
                {
                    formObj.readSql(nomiselect);
                    OracleDataReader nomireader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomireader.Read())
                    {
                        if (!nomireader.IsDBNull(0)) { NAME = nomireader.GetString(0); Address1.Add(nomireader.GetString(0)); } else { NAME = ""; Address1.Add(""); }
                        if (!nomireader.IsDBNull(1)) { ADDRESS1 = nomireader.GetString(1); Address1.Add(nomireader.GetString(1)); } else { ADDRESS1 = ""; Address1.Add(""); }
                        if (!nomireader.IsDBNull(2)) { ADDRESS2 = nomireader.GetString(2); Address1.Add(nomireader.GetString(2)); } else { ADDRESS2 = ""; Address1.Add(""); }
                        if (!nomireader.IsDBNull(3)) { ADDRESS3 = nomireader.GetString(3); Address1.Add(nomireader.GetString(3)); } else { ADDRESS3 = ""; Address1.Add(""); }
                        NomCount++;
                        Nominee.Add(NAME);
                    }
                    nomireader.Close();
                    nomireader.Dispose();
                }

                #endregion

                #region GetName and Address of Informer

                string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=0";
                if (formObj.existRecored(dclmaddressSelect) != 0)
                {
                    formObj.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); Address2.Add(dclmAdReader.GetString(0)); } else { LANG = ""; Address2.Add(""); }
                        if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); Address2.Add(dclmAdReader.GetInt32(1)); } else { INDEX = 0; Address2.Add(""); }
                        if (!dclmAdReader.IsDBNull(2)) { DINAME = dclmAdReader.GetString(2); Address2.Add(dclmAdReader.GetString(2)); } else { DINAME = ""; Address2.Add(""); }
                        if (!dclmAdReader.IsDBNull(3)) { DIAD1 = dclmAdReader.GetString(3); Address2.Add(dclmAdReader.GetString(3)); } else { DIAD1 = ""; Address2.Add(""); }
                        if (!dclmAdReader.IsDBNull(4)) { DIAD2 = dclmAdReader.GetString(4); Address2.Add(dclmAdReader.GetString(4)); } else { DIAD2 = ""; Address2.Add(""); }
                        if (!dclmAdReader.IsDBNull(5)) { DIAD3 = dclmAdReader.GetString(5); Address2.Add(dclmAdReader.GetString(5)); } else { DIAD3 = ""; Address2.Add(""); }
                        if (!dclmAdReader.IsDBNull(6)) { DIAD4 = dclmAdReader.GetString(6); Address2.Add(dclmAdReader.GetString(6)); } else { DIAD4 = ""; Address2.Add(""); }

                        if (INDEX == 0)
                        {
                            this.lblName.Text = Address2[2].ToString();
                            this.lblAdd1.Text = Address2[3].ToString();
                            this.lblAdd2.Text = Address2[4].ToString();
                            this.lblAdd3.Text = Address2[5].ToString();
                            this.lblAdd4.Text = Address2[6].ToString();
                        }
                        CopyToArr.Add(Address2);
                    }
                    dclmAdReader.Dispose();
                    dclmAdReader.Close();
                }

                #endregion
                 
                #region Get Name & Address of Branch Administrator

                string dclmaddressSelect1 = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=2";
                formObj.readSql(dclmaddressSelect1);
                OracleDataReader dclmAdReader1 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dclmAdReader1.Read())
                {
                    if (!dclmAdReader1.IsDBNull(0)) { LANG = dclmAdReader1.GetString(0); } else { LANG = ""; }
                    if (!dclmAdReader1.IsDBNull(1)) { INDEX = dclmAdReader1.GetInt32(1); } else { INDEX = 0; }
                    if (!dclmAdReader1.IsDBNull(2)) { NAME = dclmAdReader1.GetString(2); Address3.Add(dclmAdReader1.GetString(2)); } else { NAME = ""; Address3.Add(""); }
                    if (!dclmAdReader1.IsDBNull(3)) { ADDRESS1 = dclmAdReader1.GetString(3); Address3.Add(dclmAdReader1.GetString(3)); } else { ADDRESS1 = ""; Address3.Add(""); }
                    if (!dclmAdReader1.IsDBNull(4)) { ADDRESS2 = dclmAdReader1.GetString(4); Address3.Add(dclmAdReader1.GetString(4)); } else { ADDRESS2 = ""; Address3.Add(""); }
                    if (!dclmAdReader1.IsDBNull(5)) { ADDRESS3 = dclmAdReader1.GetString(5); Address3.Add(dclmAdReader1.GetString(5)); } else { ADDRESS3 = ""; Address3.Add(""); }
                    if (!dclmAdReader1.IsDBNull(6)) { ADDRESS4 = dclmAdReader1.GetString(6); Address3.Add(dclmAdReader1.GetString(6)); } else { ADDRESS4 = ""; Address3.Add(""); }


                    if (INDEX == 2)
                    {
                        Address3.Add("BRANCH  COPY");
                        if ((Address3[0] != null) && (!Address3[0].ToString().Equals("")))
                        {
                            CopyToArr.Add(Address3);
                            printToArr.Add(Address3);
                        }
                    }
                }
                dclmAdReader1.Dispose();
                dclmAdReader1.Close();

                #endregion

                #region Get Name & Address of Closer Branch Administrator

                string dclmaddressSelect2 = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=3";
                formObj.readSql(dclmaddressSelect2);
                OracleDataReader dclmAdReader2 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dclmAdReader2.Read())
                {
                    if (!dclmAdReader2.IsDBNull(0)) { LANG = dclmAdReader2.GetString(0); } else { LANG = ""; }
                    if (!dclmAdReader2.IsDBNull(1)) { INDEX = dclmAdReader2.GetInt32(1); } else { INDEX = 0; }
                    if (!dclmAdReader2.IsDBNull(2)) { Address4.Add(dclmAdReader2.GetString(2)); } else { Address4.Add(""); }
                    if (!dclmAdReader2.IsDBNull(3)) { Address4.Add(dclmAdReader2.GetString(3)); } else { Address4.Add(""); }
                    if (!dclmAdReader2.IsDBNull(4)) { Address4.Add(dclmAdReader2.GetString(4)); } else { Address4.Add(""); }
                    if (!dclmAdReader2.IsDBNull(5)) { Address4.Add(dclmAdReader2.GetString(5)); } else { Address4.Add(""); }
                    if (!dclmAdReader2.IsDBNull(6)) { Address4.Add(dclmAdReader2.GetString(6)); } else { Address4.Add(""); }

                    if (INDEX == 3)
                    {
                        Address4.Add("CLOSER BRANCH  COPY");
                        if ((Address4[0] != null) && (!Address4[0].ToString().Equals("")))
                        {
                            CopyToArr.Add(Address4);
                            printToArr.Add(Address4);
                        }
                    }

                }
                dclmAdReader2.Dispose();
                dclmAdReader2.Close();

                #endregion
                 
                #region Get Regonal Sales Manager

                string dclmaddressSelect4 = "select  LANG, INDX, NAME, ADDR1, ADDR2 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=6";
                formObj.readSql(dclmaddressSelect4);
                OracleDataReader dclmAdReader4 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dclmAdReader4.Read())
                {
                    if (!dclmAdReader4.IsDBNull(0)) { LANG = dclmAdReader4.GetString(0); } else { LANG = ""; }
                    if (!dclmAdReader4.IsDBNull(1)) { INDEX = dclmAdReader4.GetInt32(1); } else { INDEX = 0; }
                    if (!dclmAdReader4.IsDBNull(2)) { Address7.Add(dclmAdReader4.GetString(2)); } else { Address7.Add(""); }
                    Address7.Add("SRI LANKA INSURANCE, ");
                    if (!dclmAdReader4.IsDBNull(3)) { Address7.Add(dclmAdReader4.GetString(3)); } else { Address7.Add(""); }
                    if (!dclmAdReader4.IsDBNull(4)) { Address7.Add(dclmAdReader4.GetString(4)); } else { Address7.Add(""); }

                    if (INDEX == 6)
                    {
                        Address7.Add("REGIONAL SALES MANAGER COPY");
                        if ((Address7[0] != null) && (!Address7[0].ToString().Equals("")))
                        {
                            CopyToArr.Add(Address7);
                            printToArr.Add(Address7);
                        }
                    }

                }
                dclmAdReader4.Dispose();
                dclmAdReader4.Close();

                #endregion

                #region Get Sales Manager

                //string dclmaddressSelect3 = "select  LANG, INDX, NAME, ADDR1, ADDR2 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=4";
                //formObj.readSql(dclmaddressSelect3);
                //OracleDataReader dclmAdReader3 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //while (dclmAdReader3.Read())
                //{
                //    if (!dclmAdReader3.IsDBNull(0)) { LANG = dclmAdReader3.GetString(0); } else { LANG = ""; }
                //    if (!dclmAdReader3.IsDBNull(1)) { INDEX = dclmAdReader3.GetInt32(1); } else { INDEX = 0; }
                //    if (!dclmAdReader3.IsDBNull(2)) { Address6.Add(dclmAdReader3.GetString(2)); } else { Address6.Add(""); }
                //    if (!dclmAdReader3.IsDBNull(3)) { Address6.Add(dclmAdReader3.GetString(3)); } else { Address6.Add(""); }
                //    if (!dclmAdReader3.IsDBNull(4)) { Address6.Add(dclmAdReader3.GetString(4)); } else { Address6.Add(""); }

                //    if (INDEX == 4)
                //    {
                //        Address6.Add("SALES MANAGER COPY");
                //        if ((Address6[0] != null) && (!Address6[0].ToString().Equals("")))
                //        {
                //            CopyToArr.Add(Address6);
                //            printToArr.Add(Address6);
                //        }
                //    }

                //}
                //dclmAdReader3.Dispose();
                //dclmAdReader3.Close();

                #endregion

                #region Get Agent Code

                string AgentCodeSelect = "select DRAGT from LPHS.DTHREF where DRPOLNO = " + polno + " ";
                if (formObj.existRecored(AgentCodeSelect) != 0)
                {
                    formObj.readSql(AgentCodeSelect);
                    OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { AGENTCode = dthintReader.GetInt32(0); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                    AGENCY = AGENTCode;
                }

                #endregion

                #region Get Insurance Advisors Address

                if (AGENCY != 0)
                {
                    string InsuranceOffAddressSelect = "select STATUS ||''||INT||''||NAME as NAME,AD1,AD2,AD3,AD4,AD5 from AGENT.AGENT where AGENCY = " + AGENCY + " and STCD<>'5' and STCD<>'8' and STCD<>'9'";
                    if (formObj.existRecored(InsuranceOffAddressSelect) != 0)
                    {
                        formObj.readSql(InsuranceOffAddressSelect);
                        OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { NAME = dthintReader.GetString(0).Trim(); Address5.Add(dthintReader.GetString(0).Trim()); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { ADDRESS1 = dthintReader.GetString(1).Trim(); Address5.Add(dthintReader.GetString(1)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { ADDRESS2 = dthintReader.GetString(2).Trim(); Address5.Add(dthintReader.GetString(2)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { ADDRESS3 = dthintReader.GetString(3).Trim(); Address5.Add(dthintReader.GetString(3)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { ADDRESS4 = dthintReader.GetString(4).Trim(); Address5.Add(dthintReader.GetString(4)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(5)) { ADDRESS5 = dthintReader.GetString(5); Address5.Add(dthintReader.GetString(5)); }
                            else { Address5.Add(""); }
                            Address5.Add(AGENCY);
                            Address5.Add("INSURANCE ADVISORS'  COPY");
                            CopyToArr.Add(Address5);
                            printToArr.Add(Address5);
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();
                    }
                }
                #endregion

                if (CopyToArr.Count > 1)
                {
                    CopyToArr.Add(Address8);
                }

                #region  Get not received requirment

                reqList = new ArrayList();
                rowNum = 1;
                string LetterType = "T";
                bool penReqFound = false;
                bool secReqFound = false;
                bool isSecReqReceived = false;

                string dreqSelect2 = "select A.DRCOVTYP " +
                                     "from LPHS.DREQ a, LPHS.DREQDESC b " +
                                     "where A.DRCOVTYP=B.DREQCODE and A.DRPOL=" + polno + " and A.DRTYP='" + MOF + "' and (A.SECONDREQUESTYN = 'N' or A.SECONDREQUESTYN = 'Y') and SECONDREQUESTDATE>0 and (DRRECDT is null or DRRECDT=0)  order by B.ORDERNO asc";

                string dreqSelect3 = "select A.DRCOVTYP " +
                                     "from LPHS.DREQ a, LPHS.DREQDESC b " +
                                     "where A.DRCOVTYP=B.DREQCODE and A.DRPOL=" + polno + " and A.DRTYP='" + MOF + "' and A.SECONDREQUESTYN = 'Y' and SECONDREQUESTDATE=0 order by B.ORDERNO asc";

                if (formObj.existRecored(dreqSelect2) != 0)
                {
                    penReqFound = true;
                    formObj.readSql(dreqSelect2);
                    OracleDataReader dreqreader2 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader2.Read())
                    {
                        if (!dreqreader2.IsDBNull(0)) { reqCode = dreqreader2.GetInt32(0); }

                        reqList.Add(new reminderDocset(rowNum, reqCode, LetterType));
                        rowNum++;
                    }
                    dreqreader2.Close();
                    dreqreader2.Dispose();

                    int count = 1;
                    foreach (reminderDocset req in reqList)
                    {
                        //count++;
                        //createReqDescTable(count.ToString(), req.Reqdesc, (count - 1));
                        this.CreateDynTable(count.ToString(), req.Reqdesc, (count - 1), req.REQCODE);

                        //if (req.REQCODE != 22 && req.REQCODE != 23 && req.REQCODE != 24)
                        if (req.REQCODE != 23 && req.REQCODE != 24)
                        {
                            count++;
                        }
                    } 

                    pnlPendingReq.Visible = true;
                }
                else if (formObj.existRecored(dreqSelect3) == 0)
                {
                    formObj.connclose();
                    throw new Exception("No Second Requirement Details!");
                }

                if (formObj.existRecored(dreqSelect3) != 0)
                {
                    isSecReqReceived = true;
                }
                #endregion

                #region Get second requirment

                rowNum = 1;

                string secreqSelect = "select A.DRCOVTYP, B.DREQDESCTAM " +
                                      "from LPHS.DREQ a, LPHS.DREQDESC b " +
                                      "where A.DRCOVTYP=B.DREQCODE and A.DRPOL=" + polno + " and A.DRTYP='" + MOF + "' and A.SECONDREQUESTYN = 'Y' and (A.DRRECDT is null or A.DRRECDT = 0) and a.SECONDREQUESTDATE=0 order by B.ORDERNO asc";
                if (formObj.existRecored(secreqSelect) != 0)
                {
                    secReqFound = true;
                    formObj.readSql(secreqSelect);
                    OracleDataReader secreqreader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (secreqreader.Read())
                    {
                        if (!secreqreader.IsDBNull(0)) { reqCode = secreqreader.GetInt32(0); }
                        if (!secreqreader.IsDBNull(1)) { reqDesc = secreqreader.GetString(1); }

                        this.createDynamicTable(rowNum.ToString(), reqDesc, (rowNum - 1), reqCode);

                        //if (reqCode != 22 && reqCode != 23 && reqCode != 24)
                        if (reqCode != 23 && reqCode != 24)
                        {
                            //this.createDynamicTable(rowNum.ToString(), reqDesc, (rowNum - 1), reqCode);
                            rowNum++;
                        }
                    }

                    secReqDesc = "";
                    if (Session["Req22"] != null)
                    {
                        secReqDesc = Session["Req22"].ToString() + "<br />";
                    }
                    if (Session["Req23"] != null)
                    {
                        secReqDesc += Session["Req23"].ToString() + "<br />";
                    }
                    if (Session["Req21"] != null)
                    {
                        secReqDesc += Session["Req21"].ToString() + " " + Session["NomName"].ToString() + " " + Session["Req21_2"].ToString();
                    }

                    secreqreader.Close();
                    secreqreader.Dispose();

                    if (secReqDesc != "")
                    {
                        pnlNom.Visible = true;
                    }

                    if (isSecReqReceived && !penReqFound)
                    {
                        txtSecReqDescription.Text = ",t; chpikf;Nfhhpf;ifia eilKiwg;gLj;Jtjw;F> fPo; Nfhug;gLk; Mtzq;fis rkh;g;gpf;FkhW jq;fis gzpthf Ntz;Lfpd;Nwhk;.";
                    }
                    else if (secReqFound)
                    {
                        txtSecReqDescription.Text = "Nkw; Nfhug;gl;l Mtzq;fspw;F Nkyjpfkhf ehk; fPo; Nfhhpa Mtzq;fisAk; vkf;F je;JjTkhW Nfl;Lf;nfhs;fpd;Nwhk;.";
                    }

                    pnlSecReq.Visible = true;
                } 
                #endregion

                #region Print Copy

                if (printToArr.Count > 0)
                {
                    this.printCopy(printToArr);
                }

                #endregion

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                formObj.connclose();
            }
            catch (Exception ex)
            {
                formObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }

            rowNum = 1;

            string secreqSelect = "select A.DRCOVTYP, B.DREQDESCTAM " +
                                  "from LPHS.DREQ a, LPHS.DREQDESC b " +
                                  "where A.DRCOVTYP=B.DREQCODE and A.DRPOL=" + polno + " and A.DRTYP='" + MOF + "' and A.DRRECDT is null order by B.ORDERNO asc";
            if (formObj.existRecored(secreqSelect) != 0)
            {
                formObj.readSql(secreqSelect);
                OracleDataReader secreqreader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (secreqreader.Read())
                {
                    if (!secreqreader.IsDBNull(0)) { reqCode = secreqreader.GetInt32(0); }
                    if (!secreqreader.IsDBNull(1)) { reqDesc = secreqreader.GetString(1); }

                    this.CreateDynTable(rowNum.ToString(), reqDesc, (rowNum - 1), reqCode);

                    //if (reqCode != 22 && reqCode != 23 && reqCode != 24)
                    if (reqCode != 23 && reqCode != 24)
                    {
                        //this.CreateDynTable(rowNum.ToString(), reqDesc, (rowNum - 1), reqCode);
                        rowNum++;
                    }
                    secreqreader.Close();
                    secreqreader.Dispose();
                }

                secReqDesc = "";
                if (Session["Req22"] != null)
                {
                    secReqDesc = Session["Req22"].ToString() + "<br />";
                }
                if (Session["Req23"] != null)
                {
                    secReqDesc += Session["Req23"].ToString() + "<br />";
                }
                if (Session["Req21"] != null)
                {
                    secReqDesc += Session["Req21"].ToString() + " " + Session["NomName"].ToString() + " " + Session["Req21_2"].ToString();
                }
                secreqreader.Close();

                if (secReqDesc != "")
                {
                    pnlNom.Visible = true;
                }
                pnlSecReq.Visible = true;
            }
            //Session.Clear();
        }

        if (ChechedBtn == 2)
        {
            Response.Clear();
            Response.Buffer = true;
            Page.EnableViewState = false;
            Response.AddHeader("content-disposition", "attachment;filename=Second_Requirment_Letter_Tamil_" + polno + ".doc");
            Response.ContentType = "application/vnd.ms-word ";
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.RenderControl(hw);
            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();
        }
    }

    #region  Create Dynamic table
    private void CreateDynTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        //if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        //{
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            lbl1.ID = "Number" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
            lbl1.Text = reqcode + ".";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Style["text-align"] = "justify";
            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }

            if (RecordNumber == 31)
            {
                string frstReqDt = "";
                string nomCount = "";
                string nomName = "";

                if (FirstReqDT > 0)
                {
                    frstReqDt = FirstReqDT.ToString().Substring(0, 4) + "/" + FirstReqDT.ToString().Substring(4, 2) + "/" + FirstReqDT.ToString().Substring(6, 2);
                }

                if (NomCount == 1)
                {
                    nomCount = "gpd;DUj;jhspapdhy";
                }
                else if (NomCount > 1)
                {
                    nomCount = "gpd;DUj;jhspfspdhy;";
                }

                if (Nominee.Count > 0)
                {
                    for (int i = 0; i < Nominee.Count; i++)
                    {
                        if (i == 0)
                        {
                            nomName = Nominee[i].ToString().Trim();
                        }
                        else
                        {
                            nomName += ", " + Nominee[i].ToString().Trim();
                        }
                    }

                    nomName = "<span style='font-family:Kalaham; font-size:10pt;'>" + nomName + "</span>";
                }

                req = "<span style='font-family:Kalaham; font-size:10pt;'>" + frstReqDt + "</span>" + " " + req;
                req = req.Replace("gpd;DUj;jhspapdhy", nomCount);
                req = req.Replace("....", nomName);
                lbl2.Text = req;
            }

            if (RecordNumber != 23 && RecordNumber != 24)
            {
                tcell1.Controls.Add(lbl1);
                tcell1.Style["vertical-align"] = "text-top";
                tcell2.Style["padding-left"] = "5px";

                if (RecordNumber == 27)
                {
                    tcell2.Style["text-align"] = "left";
                }

                tcell2.Controls.Add(lbl2);
                trow.Cells.Add(tcell1);
                trow.Cells.Add(tcell2);
                tblFirstReq.Rows.Add(trow);
            }

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if (RecordNumber == 19)
                {
                    string lifeAssName = "";
                    for (int i = 0; i < 7; i++)
                    {
                        if (AssuNameChng.Count >= (i + 1))
                        {
                            lifeAssName = AssuNameChng[i].ToString();
                        }

                        if (lifeAssName != "")
                        {
                            tblFirstReq.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            tblFirstReq.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                            TableRow tr = new TableRow();
                            tblFirstReq.Rows.Add(tr);

                            TableCell tc = new TableCell();
                            Label Dynlbl1 = new Label();

                            Dynlbl1.ID = "Dynlbl9" + i.ToString();

                            if (i == 0) { Dynlbl1.Text = "I."; }
                            if (i == 1) { Dynlbl1.Text = "II."; }
                            if (i == 2) { Dynlbl1.Text = "III."; }
                            if (i == 3) { Dynlbl1.Text = "IV."; }
                            if (i == 4) { Dynlbl1.Text = "V."; }
                            if (i == 5) { Dynlbl1.Text = "VI."; }
                            if (i == 6) { Dynlbl1.Text = "VII."; }


                            //Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS"; 
                            Dynlbl1.ControlStyle.Font.Size = 10;
                            tc.Controls.Add(Dynlbl1);
                            tr.Cells.Add(tc);



                            TableCell tc1 = new TableCell();
                            Label Dylbel = new Label();

                            Dylbel.ID = "Dylbel9" + i.ToString();
                            Dylbel.Text = lifeAssName;

                            //Dylbel.ControlStyle.Font.Name = "Trebuchet MS";
                            Dylbel.ControlStyle.Font.Size = 10;
                            tc1.Controls.Add(Dylbel);
                            tr.Cells.Add(tc1);
                            tblFirstReq.Rows.Add(tr);
                            // tblDynamic.Rows.Add(tr);
                        }
                        lifeAssName = "";
                    }
                }

                if (RecordNumber == 20)
                {
                    string nomName = "";
                    for (int i = 0; i < 7; i++)
                    {
                        if (NomineeNameChange.Count >= (i + 1))
                        {
                            nomName = NomineeNameChange[i].ToString();
                        }

                        if (nomName != "")
                        {
                            tblFirstReq.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            tblFirstReq.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                            TableRow tr = new TableRow();
                            tblFirstReq.Rows.Add(tr);

                            TableCell tc = new TableCell();
                            Label Dynlbl1 = new Label();

                            Dynlbl1.ID = "Dynlbl10" + i.ToString();

                            if (i == 0) { Dynlbl1.Text = "I."; }
                            if (i == 1) { Dynlbl1.Text = "II."; }
                            if (i == 2) { Dynlbl1.Text = "III."; }
                            if (i == 3) { Dynlbl1.Text = "IV."; }
                            if (i == 4) { Dynlbl1.Text = "V."; }
                            if (i == 5) { Dynlbl1.Text = "VI."; }
                            if (i == 6) { Dynlbl1.Text = "VII."; }

                            //Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                            Dynlbl1.ControlStyle.CssClass = "marginLeft";
                            Dynlbl1.ControlStyle.Font.Size = 10;
                            tc.Controls.Add(Dynlbl1);
                            tr.Cells.Add(tc);



                            TableCell tc1 = new TableCell();
                            Label dynlabel = new Label();

                            dynlabel.ID = "dynlabel10" + i.ToString();
                            dynlabel.Text = nomName;

                            //dynlabel.ControlStyle.Font.Name = "Trebuchet MS";
                            dynlabel.ControlStyle.Font.Size = 10;
                            tc1.Controls.Add(dynlabel);
                            tr.Cells.Add(tc1);
                            tblFirstReq.Rows.Add(tr);
                            // tblDynamic.Rows.Add(tr);

                        }
                        nomName = "";
                    }
                }
                if (RecordNumber == 21)
                {
                    ArrayList Changes = new ArrayList();
                    Changes.Add("fhg;GWjpahsupd; ngau; tpj;jpahrk;");
                    Changes.Add("gpd;DUj;jhspapd; ngau; tpj;jpahrk;");
                     
                    for (int j = 0; j < 2; j++)
                    {
                        TableRow tr1 = new TableRow();

                        TableCell tchead = new TableCell();
                        TableCell tchead1 = new TableCell();

                        Label headlbl = new Label();
                        headlbl.Text = Changes[j].ToString();
                        headlbl.Font.Bold = true;
                        headlbl.Font.Underline = true;
                        headlbl.ControlStyle.Font.Name = "Kalaham";
                        headlbl.ControlStyle.Font.Size = 10;

                        tchead1.Controls.Add(headlbl);
                        tr1.Cells.Add(tchead);
                        tr1.Cells.Add(tchead1);

                        tblFirstReq.Rows.Add(tr1);

                        string lifeAssNom1Name = "";
                        for (int i = 0; i < 7; i++)
                        {
                            if (Ass_Nomihg.Count >= (i + 1))
                            {
                                lifeAssNom1Name = Ass_Nomihg[i].ToString();
                            }

                            if (lifeAssNom1Name != "")
                            {
                                tblFirstReq.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                                tblFirstReq.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                                tblFirstReq.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                                tblFirstReq.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                                TableRow tr = new TableRow();
                                tblFirstReq.Rows.Add(tr);

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
                                tc.Controls.Add(Dynlbl1);
                                tr.Cells.Add(tc);



                                TableCell tc1 = new TableCell();
                                TextBox DyTextBox = new TextBox();

                                if (RecordNumber == 21)
                                {
                                    Session["ReqCode11"] = RecordNumber;
                                    DyTextBox.ID = "DyTextBox20" + j.ToString() + i.ToString();
                                }

                                DyTextBox.ControlStyle.CssClass = "tamilWord";
                                DyTextBox.ControlStyle.Font.Size = 10;
                                tc1.Controls.Add(DyTextBox);
                                tr.Cells.Add(tc1);
                                tblFirstReq.Rows.Add(tr);
                            }
                            lifeAssNom1Name = "";
                        }
                    }
                }

                TableRow trdes = new TableRow();
                tblFirstReq.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString();
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString();
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                }

                if (RecordNumber == 19)
                {
                    Dynlbl2.Text = "NkNy Fwpg;gplg;gl;l ngah;fs; xNu egUf;Fhpanjdpd;, mtw;iw cWjpg;gLj;Jk; tifapy; fpuhk cj;jpNahfj;jhpdhy; cWjpg;gLj;jg;gl;L gpuNjr nrayhshpdhy; xg;gkplg;gl;l fbjk;";
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.Text = "NkNy Fwpg;gplg;gl;l ngah;fs; xNu egUf;Fhpanjdpd;, mtw;iw cWjpg;gLj;Jk; tifapy; xU rkhjhd ePjpthdpdhy; cWjpg;gLj;jg;gl;l xU rj;jpaf; fLjhrpia vkf;F mDg;gp itf;FkhW Nfl;Lf;nfhs;fpd;Nwhk;. Kf;fpakhf rj;jpaf; fLjhrpapy; &gh 25/- Kj;jpiuapd; Nky; jq;fsJ ifnahg;gk; ,lg;gl;bUj;jy; Ntz;Lk;.";
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.Text = "ush.sh rlaIs; uy;df.a by; oelafjk kuz  j,ska yoqkajkq ,nkafka tlu mqoa.,hl= njg m%dfoaYSh f,aluz wkq w;aik iys; .%du ks,OdrS iy;slhla ,ndf.k wm fj; tjkak by; ioyka mrsos Tnf.a kfuz fjkig wod,j tu kuz j,ska yoqkajkq ,nkafka tlu ;eke;af;;= njg iy;sl lrk ,o osjzreuz iy;slhla ,ndf.k wm fj; tjkak tu osjzreuz iy;slfha re( 25$- la jgskd uqoaorhla u; Tnf.a w;aik fhosh hq;= nj ldreKslj i,lkak";
                }
                Dynlbl2.ControlStyle.Font.Name = "Kalaham";
                Dynlbl2.ControlStyle.Font.Size = 10;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);
            }

            //Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            //Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;
        //}
        //if (RecordNumber == 22)
        //{
        //    Session["Req22"] = req;
        //}
        //if (RecordNumber == 23)
        //{
        //    Session["Req23"] = req;
        //}
        //if (RecordNumber == 24)
        //{
        //    if (Address1 != null)
        //    {
        //        if (Address1.Count != 0)
        //        {
        //            string Nominees = "";
        //            Nominees = Address1[0].ToString();
        //            for (int i = 0; i < Address1.Count; i++)
        //            {
        //                if (i != 0)
        //                {
        //                    Nominees = Nominees + "," + Address1[i].ToString();
        //                }
        //                i += 2;
        //            }
        //            Session["Req21"] = req + " ";
        //            Session["NomName"] = Nominees + " ";
        //            Session["Req21_2"] = "jsiska iuzmqrAK l,hq;=h'kdusl m%;s,dNshd nd,jhialdr wfhla kuz fuz iu. tjk ysusluz lshkakdf.a m%ldYkh Tyqf.a$wehf.a jevsysgs Ndrlrefjla jsiska iuzmQrAK l, hq;=h";
        //        }
        //    }
        //}
    }

    private void createDynamicTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        //if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        //{
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            lbl1.ID = "Number" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
            lbl1.Text = reqcode + ".";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Style["text-align"] = "justify";
            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }

            if (RecordNumber == 31)
            {
                string frstReqDt = "";
                string nomCount = "";
                string nomName = "";

                if (FirstReqDT > 0)
                {
                    frstReqDt = FirstReqDT.ToString().Substring(0, 4) + "/" + FirstReqDT.ToString().Substring(4, 2) + "/" + FirstReqDT.ToString().Substring(6, 2);
                }

                if (NomCount == 1)
                {
                    nomCount = "gpd;DUj;jhspapdhy";
                }
                else if (NomCount > 1)
                {
                    nomCount = "gpd;DUj;jhspfspdhy;";
                }

                if (Nominee.Count > 0)
                {
                    for (int i = 0; i < Nominee.Count; i++)
                    {
                        if (i == 0)
                        {
                            nomName = Nominee[i].ToString().Trim();
                        }
                        else
                        {
                            nomName += ", " + Nominee[i].ToString().Trim();
                        }
                    }

                    nomName = "<span style='font-family:Trebuchet MS; font-size:10pt;'>" + nomName + "</span>";
                }

                req = "<span style='font-family:Trebuchet MS; font-size:10pt;'>" + frstReqDt + "</span>" + " " + req;
                req = req.Replace("gpd;DUj;jhspapdhy", nomCount);
                req = req.Replace("....", nomName);
                lbl2.Text = req;
            }

            if (RecordNumber != 23)
            {
                tcell1.Controls.Add(lbl1);
                tcell1.Style["vertical-align"] = "text-top";
                tcell2.Style["padding-left"] = "5px";

                if (RecordNumber == 27)
                {
                    tcell2.Style["text-align"] = "left";
                }

                tcell2.Controls.Add(lbl2);
                trow.Cells.Add(tcell1);
                trow.Cells.Add(tcell2);
                tblSecReq.Rows.Add(trow);
            }

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if (RecordNumber == 19)
                {
                    string lifeAssName = "";
                    for (int i = 0; i < 7; i++)
                    {
                        if (AssuNameChng.Count >= (i + 1))
                        {
                            lifeAssName = AssuNameChng[i].ToString();
                        }

                        if (lifeAssName != "")
                        {
                            tblFirstReq.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            tblFirstReq.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                            TableRow tr = new TableRow();
                            tblSecReq.Rows.Add(tr);

                            TableCell tc = new TableCell();
                            Label Dynlbl1 = new Label();

                            Dynlbl1.ID = "Dynlbl9" + i.ToString();

                            if (i == 0) { Dynlbl1.Text = "I."; }
                            if (i == 1) { Dynlbl1.Text = "II."; }
                            if (i == 2) { Dynlbl1.Text = "III."; }
                            if (i == 3) { Dynlbl1.Text = "IV."; }
                            if (i == 4) { Dynlbl1.Text = "V."; }
                            if (i == 5) { Dynlbl1.Text = "VI."; }
                            if (i == 6) { Dynlbl1.Text = "VII."; }


                            //Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS"; 
                            Dynlbl1.ControlStyle.Font.Size = 10;
                            tc.Controls.Add(Dynlbl1);
                            tr.Cells.Add(tc);



                            TableCell tc1 = new TableCell();
                            Label Dylbel = new Label();

                            Dylbel.ID = "Dylbel9" + i.ToString();
                            Dylbel.Text = lifeAssName;

                            Dylbel.ControlStyle.Font.Name = "Kalaham";
                            Dylbel.ControlStyle.Font.Size = 10;
                            tc1.Controls.Add(Dylbel);
                            tr.Cells.Add(tc1);
                            tblSecReq.Rows.Add(tr);
                            // tblDynamic.Rows.Add(tr);
                        }
                        lifeAssName = "";
                    }
                }

                if (RecordNumber == 20)
                {
                    string nomName = "";
                    for (int i = 0; i < 7; i++)
                    {
                        if (NomineeNameChange.Count >= (i + 1))
                        {
                            nomName = NomineeNameChange[i].ToString();
                        }

                        if (nomName != "")
                        {
                            tblFirstReq.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            tblFirstReq.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            tblFirstReq.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;

                            TableRow tr = new TableRow();
                            tblFirstReq.Rows.Add(tr);

                            TableCell tc = new TableCell();
                            Label Dynlbl1 = new Label();

                            Dynlbl1.ID = "Dynlbl10" + i.ToString();

                            if (i == 0) { Dynlbl1.Text = "I."; }
                            if (i == 1) { Dynlbl1.Text = "II."; }
                            if (i == 2) { Dynlbl1.Text = "III."; }
                            if (i == 3) { Dynlbl1.Text = "IV."; }
                            if (i == 4) { Dynlbl1.Text = "V."; }
                            if (i == 5) { Dynlbl1.Text = "VI."; }
                            if (i == 6) { Dynlbl1.Text = "VII."; }

                            //Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                            Dynlbl1.ControlStyle.CssClass = "marginLeft";
                            Dynlbl1.ControlStyle.Font.Size = 10;
                            tc.Controls.Add(Dynlbl1);
                            tr.Cells.Add(tc);



                            TableCell tc1 = new TableCell();
                            Label dynlabel = new Label();

                            dynlabel.ID = "dynlabel10" + i.ToString();
                            dynlabel.Text = nomName;

                            dynlabel.ControlStyle.Font.Name = "Kalaham";
                            dynlabel.ControlStyle.Font.Size = 10;
                            tc1.Controls.Add(dynlabel);
                            tr.Cells.Add(tc1);
                            tblSecReq.Rows.Add(tr);
                            // tblDynamic.Rows.Add(tr);

                        }
                        nomName = "";
                    }
                }

                if (RecordNumber == 21)
                {
                    ArrayList Changes = new ArrayList();
                    Changes.Add("fhg;GWjpahsupd; ngau; tpj;jpahrk;");
                    Changes.Add("gpd;DUj;jhspapd; ngau; tpj;jpahrk;");

                    for (int j = 0; j < 2; j++)
                    {
                        TableRow tr1 = new TableRow();

                        TableCell tchead = new TableCell();
                        TableCell tchead1 = new TableCell();

                        Label headlbl = new Label();
                        headlbl.Text = Changes[j].ToString();
                        headlbl.Font.Bold = true;
                        headlbl.Font.Underline = true;
                        headlbl.ControlStyle.Font.Name = "Kalaham";
                        headlbl.ControlStyle.Font.Size = 10;

                        tchead1.Controls.Add(headlbl);
                        tr1.Cells.Add(tchead);
                        tr1.Cells.Add(tchead1);

                        tblSecReq.Rows.Add(tr1);

                        string lifeAssNom1Name = "";
                        for (int i = 0; i < 7; i++)
                        {
                            if (Ass_Nomihg.Count >= (i + 1))
                            {
                                lifeAssNom1Name = Ass_Nomihg[i].ToString();
                            }

                            if (lifeAssNom1Name != "")
                            {
                                tblSecReq.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                                tblSecReq.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                                tblSecReq.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                                tblSecReq.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                                TableRow tr = new TableRow();
                                tblSecReq.Rows.Add(tr);

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


                                Dynlbl1.ControlStyle.Font.Name = "Kalaham";
                                Dynlbl1.ControlStyle.Font.Size = 10;
                                tc.Controls.Add(Dynlbl1);
                                tr.Cells.Add(tc);



                                TableCell tc1 = new TableCell();
                                TextBox DyTextBox = new TextBox();

                                if (RecordNumber == 21)
                                {
                                    Session["ReqCode11"] = RecordNumber;
                                    DyTextBox.ID = "DyTextBox20" + j.ToString() + i.ToString();
                                }

                                DyTextBox.ControlStyle.Font.Name = "Kalaham";
                                DyTextBox.ControlStyle.Font.Size = 10;
                                tc1.Controls.Add(DyTextBox);
                                tr.Cells.Add(tc1);
                                tblSecReq.Rows.Add(tr);
                            }
                            lifeAssNom1Name = "";
                        }
                    }
                }

                TableRow trdes = new TableRow();
                tblSecReq.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString();
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString();
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                }

                if (RecordNumber == 19)
                {
                    Dynlbl2.Text = "NkNy Fwpg;gplg;gl;l ngah;fs; xNu egUf;Fhpanjdpd;, mtw;iw cWjpg;gLj;Jk; tifapy; fpuhk cj;jpNahfj;jhpdhy; cWjpg;gLj;jg;gl;L gpuNjr nrayhshpdhy; xg;gkplg;gl;l fbjk;";
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.Text = "NkNy Fwpg;gplg;gl;l ngah;fs; xNu egUf;Fhpanjdpd;, mtw;iw cWjpg;gLj;Jk; tifapy; xU rkhjhd ePjpthdpdhy; cWjpg;gLj;jg;gl;l xU rj;jpaf; fLjhrpia vkf;F mDg;gp itf;FkhW Nfl;Lf;nfhs;fpd;Nwhk;. Kf;fpakhf rj;jpaf; fLjhrpapy; &gh 25/- Kj;jpiuapd; Nky; jq;fsJ ifnahg;gk; ,lg;gl;bUj;jy; Ntz;Lk;.";
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.Text = "ush.sh rlaIs; uy;df.a by; oelafjk kuz  j,ska yoqkajkq ,nkafka tlu mqoa.,hl= njg m%dfoaYSh f,aluz wkq w;aik iys; .%du ks,OdrS iy;slhla ,ndf.k wm fj; tjkak by; ioyka mrsos Tnf.a kfuz fjkig wod,j tu kuz j,ska yoqkajkq ,nkafka tlu ;eke;af;;= njg iy;sl lrk ,o osjzreuz iy;slhla ,ndf.k wm fj; tjkak tu osjzreuz iy;slfha re( 25$- la jgskd uqoaorhla u; Tnf.a w;aik fhosh hq;= nj ldreKslj i,lkak";
                }
                Dynlbl2.ControlStyle.Font.Name = "Kalaham";
                Dynlbl2.ControlStyle.Font.Size = 10;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);


            }

            //Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            //Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;
        //}
        //if (RecordNumber == 22)
        //{
        //    Session["Req22"] = req;
        //}
        //if (RecordNumber == 23)
        //{
        //    Session["Req23"] = req;
        //}
        //if (RecordNumber == 24)
        //{
        //    if (Address1.Count != 0)
        //    {
        //        if (Address1.Count != 0)
        //        {
        //            string Nominees = "";
        //            Nominees = Address1[0].ToString();
        //            for (int i = 0; i < Address1.Count; i++)
        //            {
        //                if (i != 0)
        //                {
        //                    Nominees = Nominees + "," + Address1[i].ToString();
        //                }
        //                i += 2;


        //            }
        //            Session["Req21"] = req + " ";
        //            Session["NomName"] = Nominees + " ";
        //            Session["Req21_2"] = "jsiska iuzmqrAK l,hq;=h'kdusl m%;s,dNshd nd,jhialdr wfhla kuz fuz iu. tjk ysusluz lshkakdf.a m%ldYkh Tyqf.a$wehf.a jevsysgs Ndrlrefjla jsiska iuzmQrAK l, hq;=h";

        //        }
        //    }
        //}
    }
    #endregion

    private void createReqDescTable(string count, string reqDesc, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "count" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "count" + rowNumber); //Text Value
        lbl1.Text = count + ".";

        lbl2.ID = "reqDesc" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "reqDesc" + rowNumber); //Text Value
        if (reqDesc.EndsWith("."))
        {
            lbl2.Text = reqDesc.Remove(reqDesc.Length - 1);
        }
        else
        {
            lbl2.Text = reqDesc;
        }

        tcell1.Controls.Add(lbl1);
        tcell1.Style["VERTICAL-ALIGN"] = "top";

        tcell2.Controls.Add(lbl2);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        tblFirstReq.Rows.Add(trow);
    }

    private void printCopy(ArrayList prtCpy)
    {
        string printName = "";
        string printToName = "";
        int printCount = 0;

        foreach (ArrayList prtArr in prtCpy)
        {
            printCount++;
            if (prtArr.Count == 6)
            {
                if (prtArr[5].ToString() == "BRANCH  COPY")
                {
                    if (prtArr[0] != null && prtArr[0] != "") { printName = prtArr[0].ToString(); }
                    if (prtArr[1] != null && prtArr[1] != "") { printName += " " + prtArr[1].ToString(); }
                    if (prtArr[2] != null && prtArr[2] != "") { printName += " " + prtArr[2].ToString(); }
                    if (prtArr[3] != null && prtArr[3] != "") { printName += " " + prtArr[3].ToString(); }
                    if (prtArr[4] != null && prtArr[4] != "") { printName += " " + prtArr[4].ToString(); }
                }
                else if (prtArr[5].ToString() == "CLOSER BRANCH  COPY")
                {
                    if (prtArr[0] != null && prtArr[0] != "") { printName = prtArr[0].ToString() + " (Closer Branch)"; }
                    if (prtArr[1] != null && prtArr[1] != "") { printName += " " + prtArr[1].ToString(); }
                    if (prtArr[2] != null && prtArr[2] != "") { printName += " " + prtArr[2].ToString(); }
                    if (prtArr[3] != null && prtArr[3] != "") { printName += " " + prtArr[3].ToString(); }
                    if (prtArr[4] != null && prtArr[4] != "") { printName += " " + prtArr[4].ToString(); }
                }
            }
            if (prtArr.Count == 5)
            {
                if (prtArr[4].ToString() == "REGIONAL SALES MANAGER COPY")
                {
                    if (prtArr[0] != null && prtArr[0] != "") { printName = prtArr[0].ToString(); }
                    if (prtArr[1] != null && prtArr[1] != "") { printName += " " + prtArr[1].ToString(); }
                    if (prtArr[2] != null && prtArr[2] != "") { printName += " " + prtArr[2].ToString(); }
                    if (prtArr[3] != null && prtArr[3] != "") { printName += " " + prtArr[3].ToString(); }
                }
            }
            if (prtArr.Count == 4)
            {
                if (prtArr[3].ToString() == "SALES MANAGER COPY")
                {
                    if (prtArr[0] != null && prtArr[0] != "") { printName = prtArr[0].ToString(); }
                    if (prtArr[1] != null && prtArr[1] != "") { printName += " " + prtArr[1].ToString(); }
                    if (prtArr[2] != null && prtArr[2] != "") { printName += " " + prtArr[2].ToString(); }
                }
            }
            if (prtArr.Count == 8)
            {
                if (prtArr[7].ToString() == "INSURANCE ADVISORS'  COPY")
                {
                    if (prtArr[0] != null && prtArr[0] != "") { printName = prtArr[0].ToString() + " (Insurance Advisor)"; }
                    if (prtArr[1] != null && prtArr[1] != "") { printName += " " + prtArr[1].ToString(); }
                    if (prtArr[2] != null && prtArr[2] != "") { printName += " " + prtArr[2].ToString(); }
                    if (prtArr[3] != null && prtArr[3] != "") { printName += " " + prtArr[3].ToString(); }
                    if (prtArr[4] != null && prtArr[4] != "") { printName += " " + prtArr[4].ToString(); }
                    if (prtArr[5] != null && prtArr[5] != "") { printName += " " + prtArr[5].ToString(); }
                }
            }

            if (printCount == 1)
            {
                printToName = "<span style='margin-left:10px'>" + printName + "</span><br/>";
            }
            else
            {
                printToName += "<span style='margin-left:71px'>" + printName + "</span><br/>";
            }
            printName = "";
        }

        if (printToName != null || printToName != "")
        {
            lblPrintCopy.Text = printToName;
            pnlPrintCopy.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ChechedBtn = 1;
        //int NoofReqs = int.Parse(ViewState["row"].ToString());
        AssuNameChng = new ArrayList();
        NomineeNamChg = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nom_NameChng2 = new ArrayList();
        for (int a = 0; a < ReqCodeList.Count; a++)
        {
            if (int.Parse(ReqCodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblFirstReq.FindControl("DyTextBox9" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        AssuNameChng.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqCodeList[a].ToString()) == 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblFirstReq.FindControl("DyTextBox10" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        NomineeNamChg.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqCodeList[a].ToString()) == 21)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        TextBox txtname2 = new TextBox();
                        txtname2 = (TextBox)tblSecReq.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nom_NameChng2.Add(txtname2.Text);
                            }
                        }
                    }
                }
            }
        }
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }

    public string mof
    {
        get { return MOF; }
        set { MOF = value; }
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
        get { return Ass_Nom_NameChng2; }
        set { Ass_Nom_NameChng2 = value; }
    }

    public int CHECKEDBTN
    {
        get { return ChechedBtn; }
        set { ChechedBtn = value; }
    }

    protected void btn_word_Click(object sender, EventArgs e)
    {
        ChechedBtn = 2;
        AssuNameChng = new ArrayList();
        NomineeNamChg = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nom_NameChng2 = new ArrayList();
        for (int a = 0; a < ReqCodeList.Count; a++)
        {
            if (int.Parse(ReqCodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblFirstReq.FindControl("DyTextBox9" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        AssuNameChng.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqCodeList[a].ToString()) == 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblFirstReq.FindControl("DyTextBox10" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        NomineeNamChg.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqCodeList[a].ToString()) == 21)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        TextBox txtname2 = new TextBox();
                        txtname2 = (TextBox)tblSecReq.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nom_NameChng2.Add(txtname2.Text);
                            }
                        }
                    }
                }
            }
        }
    }
}
