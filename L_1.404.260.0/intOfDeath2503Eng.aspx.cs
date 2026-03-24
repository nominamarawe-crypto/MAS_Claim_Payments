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
using System.Collections.Generic;

public partial class intOfDeath2501Eng : System.Web.UI.Page
{    
    private int polno;
    private string MOF;
    private long cliamNo;

    private string LANG = "";
    private int INDEX = 0;
    //private string NAME = "";
    //private string ADDRESS1 = "";
    //private string ADDRESS2 = "";
    //private string ADDRESS3 = "";
    //private string ADDRESS4 = "";

    private string poldocname;
    private string deathCertName;
    public ArrayList nom;
    public ArrayList Address1;
    public ArrayList Address2;
    public ArrayList Address3;
    public ArrayList Address4;
    public ArrayList Address5;
    public ArrayList Address6;
    public ArrayList Address7;
    public ArrayList Address8;
    public ArrayList CopyToArr;
    private int ChechedBtn;

    int AGENTCode;
    int AGENCY;
    private ArrayList AssuNameChng;
    private ArrayList NomineeNamChg;
    private ArrayList Ass_Nomihg;
    private ArrayList Ass_Nomihg2;
    int reqcode = 0;
    private ArrayList ReqcodeList=new ArrayList();
    private ArrayList ReqcodeListN = new ArrayList();
    private ArrayList ReqcodeListOther = new ArrayList();
    private bool signatureDisplay;

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
        if (day.Length < 2)   day = "0" + day;
    
        ourDate = year + month + day;
        datetime[0] = ourDate;
     
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        return datetime;

    }
    DataManager formObj;
    DataManager formObjReqLtr;


    protected void Page_Load(object sender, EventArgs e)
    {
        string EPF = "";
        string dreqSelect = "";
        string reqdesc = "";
        string reqSrtdesc = "";
       
        int rows = 0;
        string DNOD = "";

        

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
            signatureDisplay = this.PreviousPage.SignatureDisplay;
        }

    #region Add signature 

        if (signatureDisplay)
        {
            lblSignature.Visible = true;
            lblName.Visible = true;
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
                //if (signatureData.Signature != null)
                //{
                //    this.lblSignature.Text = "<img style=\"width: 140px; height: 40px;\" src=\"data:image/bmp;base64," + signatureData.Signature + "\"  />";
                //}
                //else
                //{
                //    this.lblSignature.Text = "";
                //}
                this.lblName.Text = signatureData.UserName + " ";
                this.lbldip.Text = "Life Insurance Section";
                this.lblComp.Text = "Sri Lanka Insurance Corporation Life Ltd";
                this.lblepf.Text = "( " + signatureData.EPF +" )";

                if(signatureData.Role != null)
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

        formObj = new DataManager();
        if (!Page.IsPostBack)
        {
            try
            {
                //--- nomi read ---   
                nom = new ArrayList();
                CopyToArr = new ArrayList();
                Address1 = new ArrayList();
                Address3 = new ArrayList();
                Address4 = new ArrayList();
                Address5 = new ArrayList();
                Address7 = new ArrayList();
                Address8 = new ArrayList();
                this.litpolno.Text = polno.ToString();
                
                string nomiselect = "select nomnam, nomad1, nomad2 from lund.nominee where polno = " + polno + " ";
                if (formObj.existRecored(nomiselect) != 0)
                {
                    #region get Nominee name and address

                    formObj.readSql(nomiselect);
                    OracleDataReader nomireader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomireader.Read())
                    {

                        if (!nomireader.IsDBNull(0)) { Address1.Add(nomireader.GetString(0)); nom.Add(nomireader.GetString(0)); } else { Address1.Add(""); nom.Add(""); }
                        if (!nomireader.IsDBNull(1)) { Address1.Add(nomireader.GetString(1)); nom.Add(nomireader.GetString(1)); } else { Address1.Add(""); nom.Add(""); }
                        if (!nomireader.IsDBNull(2)) { Address1.Add(nomireader.GetString(2)); nom.Add(nomireader.GetString(2)); } else { Address1.Add(""); nom.Add(""); }
                        Address1.Add(""); Address1.Add(""); Address1.Add("Customer Copy");
                    }
                    nomireader.Close();
                    nomireader.Dispose();

                    #endregion
                }
                    string DINAME = "";
                    string DIAD1 = "";
                    string DIAD2 = "";
                    string DIAD3 = "";
                    string DIAD4 = "";
                    Address2 = new ArrayList();
                
                /*                  
                    string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=0";
                    if (formObj.existRecored(dclmaddressSelect) != 0)
                    {
                        #region  //********* Name & Address of Informer **************
                        
                        formObj.readSql(dclmaddressSelect);
                        OracleDataReader dclmAdReader = formObj.oraComm.ExecuteReader();
                        while (dclmAdReader.Read())
                        {
                            if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
                            if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
                            if (!dclmAdReader.IsDBNull(2)) {Address2.Add( dclmAdReader.GetString(2)); } else {Address2.Add(""); }
                            if (!dclmAdReader.IsDBNull(3)) { Address2.Add( dclmAdReader.GetString(3)); } else {Address2.Add(  ""); }
                            if (!dclmAdReader.IsDBNull(4)) {Address2.Add( dclmAdReader.GetString(4)); } else {Address2.Add(  ""); }
                            if (!dclmAdReader.IsDBNull(5)) {Address2.Add( dclmAdReader.GetString(5)); } else { Address2.Add(  ""); }
                            if (!dclmAdReader.IsDBNull(6)) { Address2.Add( dclmAdReader.GetString(6)); } else { Address2.Add(  ""); }
                            Address2.Add("");
                            Address2.Add(""); Address2.Add("Customer Copy");
                            if (INDEX == 0)
                            {
                                this.litname.Text = Address2[0].ToString();
                                this.litad1.Text = Address2[1].ToString();
                                this.litad2.Text = Address2[2].ToString();
                                this.litad3.Text = Address2[3].ToString();
                                this.litad4.Text = Address2[4].ToString();
                                if (Address2[0].ToString() != "")
                                {
                                    CopyToArr.Add(Address2);
                                }
                            }
                        }
                        dclmAdReader.Close();
                    
                     #endregion
                    }
                    */
                    //else
                    //{
                       #region //**********Get Informer name from DthInt Table if that not exist in Devlaimeraddress Table

                        string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                        if (formObj.existRecored(dthintSelect) != 0)
                        {
                            formObj.readSql(dthintSelect);
                            OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (dthintReader.Read())
                            {
                                if (!dthintReader.IsDBNull(0)) { DINAME = dthintReader.GetString(0); Address2.Add(DINAME); } else { Address2.Add(""); }
                                if (!dthintReader.IsDBNull(1)) { DIAD1 = dthintReader.GetString(1); Address2.Add(DIAD1); } else { Address2.Add(""); }
                                if (!dthintReader.IsDBNull(2)) { DIAD2 = dthintReader.GetString(2); Address2.Add(DIAD2); } else { Address2.Add(""); }
                                if (!dthintReader.IsDBNull(3)) { DIAD3 = dthintReader.GetString(3); Address2.Add(DIAD3); } else { Address2.Add(""); }
                                if (!dthintReader.IsDBNull(4)) { DIAD4 = dthintReader.GetString(4); Address2.Add(DIAD4); } else { Address2.Add(""); }
                                if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5);  } else { Address2.Add(""); }
                                if (!dthintReader.IsDBNull(6)) { cliamNo = dthintReader.GetInt64(6); }
                            }
                            dthintReader.Close();
                            dthintReader.Dispose();
                            Address2.Add("");
                            Address2.Add(""); Address2.Add("Customer Copy");
                        this.litname.Text = Address2[0].ToString();
                        this.litad1.Text = Address2[1].ToString();
                        this.litad2.Text = Address2[2].ToString();
                        this.litad3.Text = Address2[3].ToString();
                        this.litad4.Text = Address2[4].ToString();
                        this.litnameofdead.Text = DNOD;
                       // this.lblyrref.Text = epfStr;
                        this.litorref.Text = cliamNo.ToString();
                        this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                        if (Address2[0].ToString() != "")
                        {
                            CopyToArr.Add(Address2);
                        }
                        }
                        #endregion
                    //}
                   
                //}
                #region  //********* Name & Address of Branch Administrator **************
              
                string dclmaddressSelect1 = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=2";
                if (formObj.existRecored(dclmaddressSelect1) != 0)
                {
                    formObj.readSql(dclmaddressSelect1);
                    OracleDataReader dclmAdReader1 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader1.Read())
                    {
                        if (!dclmAdReader1.IsDBNull(0)) { LANG = dclmAdReader1.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader1.IsDBNull(1)) { INDEX = dclmAdReader1.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader1.IsDBNull(2)) { Address3.Add(dclmAdReader1.GetString(2)); } else { Address3.Add(""); }
                        if (!dclmAdReader1.IsDBNull(3)) { Address3.Add(dclmAdReader1.GetString(3)); } else { Address3.Add(""); }
                        if (!dclmAdReader1.IsDBNull(4)) { Address3.Add(dclmAdReader1.GetString(4)); } else { Address3.Add(""); }
                        if (!dclmAdReader1.IsDBNull(5)) { Address3.Add(dclmAdReader1.GetString(5)); } else { Address3.Add(""); }
                        if (!dclmAdReader1.IsDBNull(6)) { Address3.Add(dclmAdReader1.GetString(6)); } else { Address3.Add(""); }
                        Address3.Add(""); Address3.Add(""); Address3.Add("BRANCH   COPY");
                 
                        if (INDEX == 2)
                        {
                            if ((Address3[0] != null) && (!Address3[0].ToString().Equals("")))
                            {
                                this.lblcopy1desc.Visible = true;
                                this.litcopy1.Visible = true;
                                this.litcopy1.Text = Address3[0].ToString() + ", " + Address3[1].ToString() + " " + Address3[2].ToString() + " " + Address3[3].ToString() + " " + Address3[4].ToString();
                                CopyToArr.Add(Address3);
                            }
                        }
                    }
                    dclmAdReader1.Close();
                    dclmAdReader1.Dispose();
                }

                #endregion

               
                #region  //********* Name & Address of Closer Branch Administrator **************

                string dclmaddressSelect2 = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=3";
                if (formObj.existRecored(dclmaddressSelect2) != 0)
                {
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
                        Address4.Add(""); Address4.Add(""); Address4.Add("CLOSER BRANCH COPY");
                 
                        if (INDEX == 3)
                        {
                            if ((Address4[0] != null) && (!Address4[0].ToString().Equals("") && (!Address4[2].ToString().Trim().Equals(""))))
                            {
                                this.litcopy2.Visible = true;
                                this.litcopy2.Text = Address4[0].ToString() + ", " + Address4[1].ToString() + " " + Address4[2].ToString() + " " + Address4[3].ToString() + " " + Address4[4].ToString();
                                CopyToArr.Add(Address4);
                            }
                        }
                    }
                    dclmAdReader2.Close();
                    dclmAdReader2.Dispose();
                }

                #endregion

                #region  //********* Regional Sales Manager **************

                string dclmaddressSelect3 = "select  LANG, INDX, NAME, ADDR1, ADDR2 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=6";
                if (formObj.existRecored(dclmaddressSelect3) != 0)
                {
                    formObj.readSql(dclmaddressSelect3);
                    OracleDataReader dclmAdReader3 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader3.Read())
                    {
                        if (!dclmAdReader3.IsDBNull(0)) { LANG = dclmAdReader3.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader3.IsDBNull(1)) { INDEX = dclmAdReader3.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader3.IsDBNull(2)) { Address7.Add(dclmAdReader3.GetString(2)); } else { Address7.Add(""); }
                        Address7.Add("SRI LANKA INSURANCE, ");
                        if (!dclmAdReader3.IsDBNull(3)) { Address7.Add(dclmAdReader3.GetString(3)); } else { Address7.Add(""); }
                        if (!dclmAdReader3.IsDBNull(4)) { Address7.Add(dclmAdReader3.GetString(4)); } else { Address7.Add(""); }

                        if (INDEX == 6)
                        {
                            if ((Address7[0] != null) && (!Address7[0].ToString().Equals("")))
                            {
                                this.litcopy4.Visible = true;
                                this.litcopy4.Text = Address7[0].ToString().ToUpper() + " " + Address7[1].ToString() + " " + Address7[2].ToString();
                                CopyToArr.Add(Address7);
                            }
                        }
                    }
                    dclmAdReader3.Close();
                }

                #endregion

                #region  //********* Sales Manager **************

                //string dclmaddressSelect4 = "select  LANG, INDX, NAME, ADDR1, ADDR2 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=4";
                //if (formObj.existRecored(dclmaddressSelect4) != 0)
                //{
                //    formObj.readSql(dclmaddressSelect4);
                //    OracleDataReader dclmAdReader4 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    while (dclmAdReader4.Read())
                //    {
                //        if (!dclmAdReader4.IsDBNull(0)) { LANG = dclmAdReader4.GetString(0); } else { LANG = ""; }
                //        if (!dclmAdReader4.IsDBNull(1)) { INDEX = dclmAdReader4.GetInt32(1); } else { INDEX = 0; }
                //        if (!dclmAdReader4.IsDBNull(2)) { Address8.Add(dclmAdReader4.GetString(2)); } else { Address8.Add(""); }
                //        if (!dclmAdReader4.IsDBNull(3)) { Address8.Add(dclmAdReader4.GetString(3)); } else { Address8.Add(""); }
                //        if (!dclmAdReader4.IsDBNull(4)) { Address8.Add(dclmAdReader4.GetString(4)); } else { Address8.Add(""); }

                //        if (INDEX == 4)
                //        {
                //            if ((Address8[0] != null) && (!Address8[0].ToString().Equals("")))
                //            {
                //                this.litcopy5.Visible = true;
                //                this.litcopy5.Text = Address8[0].ToString() + " " + Address8[1].ToString() + " " + Address8[2].ToString();
                //                CopyToArr.Add(Address8);
                //            }
                //        }
                //    }
                //    dclmAdReader4.Close();
                //}

                #endregion

                #region Load Agent Code

                string AgentCodeSelect = "select DRAGT from LPHS.DTHREF where DRPOLNO = " + polno + " ";
                if (formObj.existRecored(AgentCodeSelect) != 0)
                {
                    formObj.readSql(AgentCodeSelect);
                    OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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

                Address6 = new ArrayList();
                if (AGENCY != 0)
                {
                    string InsuranceOffAddressSelect = "select STATUS ||''||INT||''||NAME as NAME,AD1,AD2,AD3,AD4,AD5 from AGENT.AGENT where AGENCY = " + AGENCY + " and STCD<>'5' and STCD<>'8' and STCD<>'9'";
                    if (formObj.existRecored(InsuranceOffAddressSelect) != 0)
                    {
                        formObj.readSql(InsuranceOffAddressSelect);
                        OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { Address5.Add(dthintReader.GetString(0).Trim()); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { Address5.Add(dthintReader.GetString(1)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { Address5.Add(dthintReader.GetString(2)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { Address5.Add(dthintReader.GetString(3)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { Address5.Add(dthintReader.GetString(4)); }
                            else { Address5.Add(""); }
                            if (!dthintReader.IsDBNull(5)) { Address5.Add(dthintReader.GetString(5)); }
                            else { Address5.Add(""); }
                            Address5.Add(AGENCY);
                            if (Address5[0].ToString() != "")
                            {
                                CopyToArr.Add(Address5);
                            }

                        }
                        dthintReader.Close();
                        dthintReader.Dispose();
                        this.litcopy3.Text =Address5[0].ToString() + ", " + Address5[1].ToString() + ", " + Address5[2].ToString() + ", " + Address5[3].ToString() + ", " + Address5[4].ToString() + ", "+Address5[5].ToString();
                        this.litcopy3.Visible = true;

                    }
                      }

                #endregion

                string dthintSelect1 = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (formObj.existRecored(dthintSelect1) != 0)
                {
                    formObj.readSql(dthintSelect1);
                    OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }
                this.litorref.Text = cliamNo.ToString();
            
                //  this.lblyrref.Text = epfStr;
                //this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lbldate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                this.litnameofdead.Text = DNOD;
               
                bool existflag = false;
                int mostype = 0;
                if (MOF == "M") { mostype = 1; } else if (MOF == "S") { mostype = 2; } else if (MOF == "2") { mostype = 3; } else if (MOF == "C") { mostype = 4; }
                dreqSelect = "select a.drcovtyp, a.drrema from lphs.dreq a left outer join LPHS.DREQDESC b on A.DRCOVTYP=B.DREQCODE where drpol=" + polno + " and drtyp='" + MOF + "' and (a.DRRECDT is null or a.DRRECDT=0) " +
                             "and a.drcovtyp not in (select distinct(to_number(DC_DOCCODE)) from   LPHS.DCT_DOCCOLLECT where DC_POLNO=" + polno + " and DC_LIFETYPE=" + mostype + " and DC_DOCCODE not like 'OT%') order by  B.ORDERNO";
                formObj.readSql(dreqSelect);
                OracleDataReader dreqreader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader.Read())
                {
                    existflag = true;
                    reqcode = dreqreader.GetInt32(0);
                    ReqcodeList.Add(reqcode);
                    //dreqSelect = "select dreqdsesceng,dreqdessrten from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
                    //formObj.readSql(dreqSelect);
                    //OracleDataReader dreqreader02 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //while (dreqreader02.Read())
                    //{
                    //    if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); } else { reqdesc = ""; }
                    //    if (!dreqreader02.IsDBNull(1)) { reqSrtdesc = dreqreader02.GetString(1); } else { reqSrtdesc = ""; }
                    //}
                    //dreqreader02.Close();
                    //dreqreader02.Dispose();
                    
                    int row = rows + 1;

                    if (reqcode == 1 || reqcode == 2 || reqcode == 3 || reqcode == 14)
                    {
                        ReqcodeListN.Add(reqcode);
                    }
                    else
                    {
                        ReqcodeListOther.Add(reqcode);
                    }

                    if (reqcode != 22 && reqcode != 23 &&reqcode != 24 )
                    {
                        rows++;
                    }
                }
                Session["Req21"] = null;
                Session["Req22"] = null;
                Session["Req23"] = null;
                Session["Req23_2"] = null;
                Session["ReqCode9"] = null;
                Session["ReqCode10"] = null;
                Session["ReqCode11"] = null;

                int r_row = 1;
                foreach (int rcode in ReqcodeListN)
                {
                    dreqSelect = "select dreqdsesceng,dreqdessrten from lphs.dreqdesc where dreqcode=" + rcode + "  ";
                    formObj.readSql(dreqSelect);
                    OracleDataReader dreqreader02 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader02.Read())
                    {
                        if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); } else { reqdesc = ""; }
                        if (!dreqreader02.IsDBNull(1)) { reqSrtdesc = dreqreader02.GetString(1); } else { reqSrtdesc = ""; }
                    }
                    dreqreader02.Close();
                    this.createDynamicClmFormTable(r_row.ToString(), reqdesc, r_row, rcode);
                    this.createDynamicEnclosedTable(r_row.ToString(), reqSrtdesc, r_row, rcode);
                    r_row++;
                    litrClmFrom.Visible = true;
                    litrEnclose.Visible = true;
                }
                foreach (int rcode in ReqcodeListOther)
                {
                    dreqSelect = "select dreqdsesceng,dreqdessrten from lphs.dreqdesc where dreqcode=" + rcode + "  ";
                    formObj.readSql(dreqSelect);
                    OracleDataReader dreqreader02 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader02.Read())
                    {
                        if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); } else { reqdesc = ""; }
                        if (!dreqreader02.IsDBNull(1)) { reqSrtdesc = dreqreader02.GetString(1); } else { reqSrtdesc = ""; }
                    }
                    dreqreader02.Close();

                    this.createDynamicOthDocTable(r_row.ToString(), reqdesc, r_row, rcode);
                    r_row++;
                }
                if (Session["Req21"] != null)
                { litreq24.Text = Session["Req21"].ToString(); }
                if (Session["Req22"] != null)
                { litreq22.Text = Session["Req22"].ToString(); }
                if (Session["Req23"] != null && Session["Req23_2"] != null)
                {
                    litreq23.Text = Session["Req23"].ToString();
                    litreq23new.Text = Session["Req23_2"].ToString();
                    litreq23new.Visible = true;
                }
                dreqreader.Close();

                //litreqAll.Text = "<li  style='text-align:justify'>If this document is certified by a Justice of peace, his/her official seal should bear the name, address, registration number and Judicial area</li>";

                if (!existflag)
                {
                    formObj.connclose();
                    throw new Exception("No Requirement Details!");
                }

                //32340 ==================
                getNotices(polno,MOF);
                AutoReq autoReq = new AutoReq();
                if ((autoReq.getPolicyStatus(formObj, polno) == 2) || (autoReq.getPolicyStatus(formObj, polno) == 3 && MOF == "S"))
                {
                    desc1.Visible = false;
                    litreqAll.Text = "";

                    otherDesc.Visible = false;
                    otherDesc2.InnerText = "In order to process this claim please forward us the following requirements.";
                }
                else
                {
                    desc1.Visible = true;
                    litreqAll.Text = "<li  style='text-align:justify'>If this document is certified by a Justice of peace, his/her official seal should bear the name, address, registration number and Judicial area</li>";

                    otherDesc.Visible = true;
                    otherDesc2.InnerText = "OTHER DOCUMENTS. Original (Photocopies of these certificates are not acceptable)";
                }
                //=========================

                //-----------------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["signatureDisplay"] = signatureDisplay;


                

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
            if (ViewState["signatureDisplay"] != null) { signatureDisplay = bool.Parse(ViewState["signatureDisplay"].ToString()); }
            
            this.litpolno.Text = polno.ToString();
            bool existflag = false;
            dreqSelect = "select drcovtyp,drrema from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "'  ";
            formObj.readSql(dreqSelect);
            OracleDataReader dreqreader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dreqreader.Read())
            {
                existflag = true;
                reqcode = dreqreader.GetInt32(0);
                ReqcodeList.Add(reqcode);
                dreqSelect = "select dreqdsesceng,dreqdessrten from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
                formObj.readSql(dreqSelect);
                OracleDataReader dreqreader02 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader02.Read())
                {

                    if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); } else { reqdesc = ""; }
                    if (!dreqreader02.IsDBNull(1)) { reqSrtdesc = dreqreader02.GetString(1); } else { reqSrtdesc = ""; }
                }
                int row = rows + 1;

                if (reqcode == 1 || reqcode == 2 || reqcode == 3 || reqcode == 14)
                {
                    this.CreateDynClmFrmTable(row.ToString(), reqdesc, rows, reqcode);
                    //this.createDynamicEnclosedTable(row.ToString(), reqSrtdesc, rows, reqcode);
                    litrClmFrom.Visible = true;
                    litrEnclose.Visible = true;
                }
                else
                {
                    this.CreateDynOthDocTable(row.ToString(), reqdesc, rows, reqcode);
                }

                if (reqcode != 22 && reqcode!=23 && reqcode!=24)
                {
                    rows++;
                }
                //dreqreader02.Close();
                //dreqreader02.Dispose();
                ViewState["row"] = row;
            }
            dreqreader.Close();
            dreqreader.Dispose();

            if (Session["Req21"] != null)
            { litreq24.Text = Session["Req21"].ToString(); }
            if (Session["Req22"] != null)
            { litreq22.Text = Session["Req22"].ToString(); }
            if (Session["Req23"] != null && Session["Req23_2"] != null)
            { 
                litreq23.Text = Session["Req23"].ToString();
                litreq23new.Text = Session["Req23_2"].ToString();
                litreq23new.Visible = true;
            }
            dreqreader.Close();

            litreqAll.Text = "<li  style='text-align:justify'>If this document is certified by a Justice of peace, his/her official seal should bear the name, address, registration number and Judicial area</li>";
        }
        //Session.Clear();
        try
        {
            formObjReqLtr = new DataManager();
            string query = "update lphs.dreq set REQCALLUSR='" + Session["EPFNum"].ToString() + "',REQCALLDATE=sysdate  where drpol=" + polno + " and drtyp='" + MOF + "'  ";
            formObjReqLtr.addRecored(query);
        }
        catch (Exception ex)
        {
            formObjReqLtr.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

    }

    private void createDynamicClmFormTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
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

        if (req.EndsWith("."))
        {
            lbl2.Text = req.Remove(req.Length - 1);
        }
        else
        {
            lbl2.Text = req;
        }

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        tblClmForm.Rows.Add(trow);
    } 

    private void CreateDynClmFrmTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        {
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

            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }

            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            tblClmForm.Rows.Add(trow);
        }
    }

    private void createDynamicEnclosedTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        TableRow trow1 = new TableRow();
        TableCell tcell11 = new TableCell();
        TableCell tcell21 = new TableCell();
        Label lbl11 = new Label();
        Label lbl21 = new Label();

        lbl11.ID = "Number" + rowNumber;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
        lbl11.Text = reqcode + "."; 

        lbl21.ID = "ReqName" + rowNumber;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "req" + rowNumber); //Text Value 

        if (req.EndsWith("."))
        {
            lbl21.Text = req.Remove(req.Length - 1);
        }
        else
        {
            lbl21.Text = req;
        }

        tcell11.Controls.Add(lbl11);
        tcell21.Controls.Add(lbl21);
        trow1.Cells.Add(tcell11);
        trow1.Cells.Add(tcell21);
        tblEnclose.Rows.Add(trow1);
    }

    private void createDynamicOthDocTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        {
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

            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }

            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            tblOtherDoc.Rows.Add(trow);

            //Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            //Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if (RecordNumber == 19 || RecordNumber == 20)
                {
                    for (int i = 0; i < 7; i++)
                    {

                        tblOtherDoc.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                        tblOtherDoc.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                        tblOtherDoc.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                        tblOtherDoc.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                        TableRow tr = new TableRow();
                        tblOtherDoc.Rows.Add(tr);

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
                        if (RecordNumber == 21)
                        {
                            Dynlbl1.ID = "Dynlbl11" + i.ToString();
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
                        if (RecordNumber == 21)
                        {
                            Session["ReqCode11"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox11" + i.ToString();
                        }

                        DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                        DyTextBox.ControlStyle.Font.Size = 10;
                        DyTextBox.Width = 350;
                        tc1.Controls.Add(DyTextBox);
                        tr.Cells.Add(tc1);
                        tblOtherDoc.Rows.Add(tr);
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

                        tblOtherDoc.Rows.Add(tr1);

                        for (int i = 0; i < 7; i++)
                        {
                            tblOtherDoc.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            tblOtherDoc.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            tblOtherDoc.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            tblOtherDoc.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                            TableRow tr = new TableRow();
                            tblOtherDoc.Rows.Add(tr);

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
                            tblOtherDoc.Rows.Add(tr);
                        }
                    }
                }

                TableRow trdes = new TableRow();
                tblOtherDoc.Rows.Add(trdes);

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
                    Dynlbl2.Text = "If the above names were used to refer one and same person, please forwards us a Grama Niladhari certificate certifying the above difference counter signed by Divisional Secretary of the Area.";
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.Text = "if the above names refer to the one and same person, please forward us a certified affidavit for that affect further please note that your signature should be placed on Rs. 25/- stamp and attested by a Justice of Peace";
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.Text = "If the above names were used to refer the life assured, please forwards us a Grama Niladhari certificate counter signed by Divisional Secretary of the Area for the effect of the differnt found in the life assured's name & an affidavit signed by you and attested by a justice of peace stating that the name difference found in your names were used to refer one and same person. Please note that your signature should be placed on Rs. 25/- stamp.";
                }
                Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
                Dynlbl2.ControlStyle.Font.Size = 10;
                Dynlbl2.Width = 631; 
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);
            }
        }
        if (RecordNumber == 22)
        {
            Session["Req22"] = req;
        }
        if (RecordNumber == 23)
        {
            Session["Req23"] = req;
            //litreq23new.Text = "<li>The revised insurance premium applicable to continue the spouse cover will be informed to you from our policy holder’s service section in due course.</li>";
            //litreq23new.Visible = true;
            Session["Req23_2"] = "<li>The revised insurance premium applicable to continue the spouse cover will be informed to you from our policy holder’s service section in due course.</li>";
        }
        if (RecordNumber == 24)
        {
            if (nom != null)
            {
                if (nom.Count != 0)
                {
                    string Nominees = "";
                    Nominees = nom[0].ToString();
                    for (int i = 0; i < nom.Count; i++)
                    {
                        if (i != 0)
                        {
                            Nominees = Nominees + "," + nom[i].ToString();
                        }
                        i += 2;
                    }

                    Session["Req21"] = req + "  " + Nominees + " the claim forms should be signed by him/her/them.If the Nominee was minor, the claim forms should be signed by the legal guardian of the child ";
                }
            }
        }

    }


    private void CreateNoticeTable(int rowNumber, string Notice)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        Label lbl1 = new Label();
        TableCell tcell2 = new TableCell();
        Label lbl2 = new Label();

        lbl2.ID = "Number" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "noticeid" + rowNumber); //Text Value
        lbl2.Text = "<ul style='margin-top:0px;'><li></li></ul>";
        tcell2.Style.Add("vertical-align", "top");

        lbl1.ID = "Notice" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "noticeno" + rowNumber); //Text Value
        lbl1.Text = Notice;

        tcell2.Controls.Add(lbl2);
        tcell1.Controls.Add(lbl1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell1);
       
        tblNotices.Rows.Add(trow);
    }

    private void CreateDynOthDocTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        {
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

            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }

            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            tblOtherDoc.Rows.Add(trow);

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if (RecordNumber == 19 || RecordNumber == 20)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        tblOtherDoc.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                        tblOtherDoc.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                        tblOtherDoc.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                        tblOtherDoc.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                        TableRow tr = new TableRow();
                        tblOtherDoc.Rows.Add(tr);

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
                        tblOtherDoc.Rows.Add(tr);
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
                        headlbl.ControlStyle.Font.Name = "Trebuchet MS";
                        headlbl.ControlStyle.Font.Size = 10;
                        headlbl.Width = 10;

                        tchead.Controls.Add(headlbl);
                        tr1.Cells.Add(tchead);
                        tr1.Cells.Add(tchead1);

                        tblOtherDoc.Rows.Add(tr1);

                        for (int i = 0; i < 7; i++)
                        {
                            tblOtherDoc.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                            tblOtherDoc.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                            tblOtherDoc.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                            tblOtherDoc.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                            TableRow tr = new TableRow();
                            tblOtherDoc.Rows.Add(tr);

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
                            tblOtherDoc.Rows.Add(tr);
                        }
                    }
                }

                TableRow trdes = new TableRow();
                tblOtherDoc.Rows.Add(trdes);

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
                    Dynlbl2.Text = "If the above names were used to refer one and same person, please forwards us a Grama Niladhari certificate certifying the above difference counter signed by Divisional Secretary of the Area.";
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.Text = "if the above names refer to the one and same person, please forward us a certified affidavit for that affect further please note that your signature should be placed on Rs. 25/- stamp and attested by a Justice of Peace";
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.Text = "If the above names were used to refer the life assured, please forwards us a Grama Niladhari certificate counter signed by Divisional Secretary of the Area for the effect of the differnt found in the life assured's name & an affidavit signed by you and attested by a justice of peace stating that the name difference found in your names were used to refer one and same person. Please note that your signature should be placed on Rs. 25/- stamp.";
                }
                Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
                Dynlbl2.ControlStyle.Font.Size = 10;
                Dynlbl2.Width = 631;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);

            }
        }
        if (RecordNumber == 22)
        {
            Session["Req22"] = req;
        }
        if (RecordNumber == 23)
        {
            Session["Req23"] = req;
            //litreq23new.Text = "<li>The revised insurance premium applicable to continue the spouse cover will be informed to you from our policy holder’s service section in due course.</li>";
            //litreq23new.Visible = true;
            Session["Req23_2"] = "<li>The revised insurance premium applicable to continue the spouse cover will be informed to you from our policy holder’s service section in due course.</li>";
        }
        if (RecordNumber == 24)
        {

            if (nom != null)
            {
                if (nom.Count != 0)
                {
                    string Nominees = "";
                    Nominees = nom[0].ToString();
                    for (int i = 0; i < nom.Count; i++)
                    {
                        if (i != 0)
                        {
                            Nominees = Nominees + "," + nom[i].ToString();
                        }
                        i += 2;
                    }
                    Session["Req21"] = req + "  " + Nominees + " the claim forms should be signed by him/her/them. If the Nominee was minor, the claim forms should be signed by the legal guardian of the child ";
                }
            }
        }
    }
   
    protected void btnprint_Click(object sender, EventArgs e)
    {
        ChechedBtn = 1;
        int NoofReqs = int.Parse(ViewState["row"].ToString());
        AssuNameChng = new ArrayList();
        NomineeNamChg = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nomihg2 = new ArrayList();
        for (int a = 0; a < ReqcodeList.Count; a++)
        {
            if (int.Parse(ReqcodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblOtherDoc.FindControl("DyTextBox9" + i.ToString());
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
                    txtname2 = (TextBox)tblOtherDoc.FindControl("DyTextBox10" + i.ToString());
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
                        txtname2 = (TextBox)tblOtherDoc.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nomihg2.Add(txtname2.Text);
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
    public string Poldocname
    {
        get { return poldocname; }
        set { poldocname = value; }
    }
    public string DeathCertName
    {
        get { return deathCertName; }
        set { deathCertName = value; }
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
    public ArrayList AssureandNomineeChanged2
    {
        get { return Ass_Nomihg2; }
        set { Ass_Nomihg2 = value; }
    }
    public ArrayList REQUIREMENTLIST
    {
        get { return ReqcodeList; }
        set { ReqcodeList = value; }
    }
    public int CHECKEDBTN
    {
        get { return ChechedBtn; }
        set { ChechedBtn = value; }
    }
    public bool SIGNATUREDISPLAY
    {
        get { return signatureDisplay; }
        set { signatureDisplay = value; }
    }
    
    protected void btn_word_Click(object sender, EventArgs e)
    {
        ChechedBtn = 2;
        int NoofReqs = int.Parse(ViewState["row"].ToString());
        AssuNameChng = new ArrayList();
        NomineeNamChg = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nomihg2 = new ArrayList();
        for (int a = 0; a < ReqcodeList.Count; a++)
        {
            if (int.Parse(ReqcodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblOtherDoc.FindControl("DyTextBox9" + i.ToString());
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
                    txtname2 = (TextBox)tblOtherDoc.FindControl("DyTextBox10" + i.ToString());
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
                        txtname2 = (TextBox)tblOtherDoc.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nomihg2.Add(txtname2.Text);
                            }
                        }
                    }
                }
            }
        }
    }



    public void getNotices(int polno, string MOF)
    {
        try
        {

            DataManager dthReqObj = new DataManager();

            AutoReq autoReq = new AutoReq();

            List<string> noticeDisList = new List<string>();
            noticeDisList = autoReq.getNotices(polno, MOF, dthReqObj,"en");

            int row = 0;
            foreach (string desc in noticeDisList)
            {
                row++;
                this.CreateNoticeTable(row, desc);
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

    }



}
