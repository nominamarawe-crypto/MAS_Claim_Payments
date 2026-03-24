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

public partial class intOfDeath2503Sin002 : System.Web.UI.Page
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
        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        return datetime;

    }
    private  int polno;
    private  string MOF;
    //private string phname;
    private long cliamNo;

    DataManager formObj;
    public ArrayList nom;
    private string LANG = "";
    private int INDEX = 0;
    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    //private string ADDRESS3 = "";
    //private string ADDRESS4 = "";
    string DNOD = "";
    private string poldocname;
    private string deathCertName;
    public ArrayList Address1;
    public ArrayList Address2;
    public ArrayList Address3;
    public ArrayList Address4;
    public ArrayList Address5;
    public ArrayList Address6;
    public ArrayList Address7;
    public ArrayList Address8;
    public ArrayList CopyToArr;

    public ArrayList AssureChg;
    public ArrayList NomChg;
    public ArrayList AssNomChg;
    public ArrayList AssNomChg2;
    int AGENCY;
    int AGENTCode;
    public int Chckedbtn;

    private ArrayList ReqcodeListN = new ArrayList();
    private ArrayList ReqcodeListOther = new ArrayList();

    private bool signatureDisplay;

    protected void Page_Load(object sender, EventArgs e)
    {
        AssureChg = new ArrayList();
        NomChg = new ArrayList();
        AssNomChg = new ArrayList();

        String EPF = "";
        string dreqSelect = "";
        string reqdesc = "";
        string reqSrtdesc = "";
        int reqcode = 0;
        int rows = 0;


        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
            poldocname = this.PreviousPage.Poldocname;
            deathCertName = this.PreviousPage.DeathCertName;
            AssureChg = this.PreviousPage.AssuNameChange;
            NomChg = this.PreviousPage.NomineeNameChange;
            AssNomChg = this.PreviousPage.AssureandNomineeChanged;
            AssNomChg2 = this.PreviousPage.AssureandNomineeChanged1; 
            Chckedbtn = this.PreviousPage.CHECKEDBTN;
            signatureDisplay = this.PreviousPage.SIGNATUREDISPLAY;

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
                    if (Chckedbtn == 2)
                    {
                        SignatureImage.ImageUrl = signatureData.GetAbsoluteUrl(SignatureImage.ImageUrl, Request.Url.AbsoluteUri);
                    }
                }
                else
                {
                    lblSignature.Visible = false;
                }
                this.lblName.Text = signatureData.UserName + " ";
                this.lbldip.Text = "Life Insurance Section";
                this.lblComp.Text = "Sri Lanka Insurance Corporation Life Ltd ";
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

        formObj = new DataManager();
        if (!Page.IsPostBack)
        {
            try
            {
                nom = new ArrayList();
                Address1 = new ArrayList();
                Address2 = new ArrayList();
                Address3 = new ArrayList();
                Address4 = new ArrayList();
                Address5 = new ArrayList();
                Address6 = new ArrayList();
                Address7 = new ArrayList();
                Address8 = new ArrayList();
                CopyToArr = new ArrayList();
                //--- nomi read ---              
               
                string nomiselect = "select nomnam, nomad1, nomad2 from lund.nominee where polno = " + polno + " ";
                if (formObj.existRecored(nomiselect) != 0)
                {
                    formObj.readSql(nomiselect);
                    OracleDataReader nomireader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomireader.Read())
                    {
                        Address1.Clear();
                        if (!nomireader.IsDBNull(0)) { NAME = nomireader.GetString(0); Address1.Add(nomireader.GetString(0)); nom.Add(nomireader.GetString(0)); } else { NAME = ""; Address1.Add(""); nom.Add(""); }
                        if (!nomireader.IsDBNull(1)) { ADDRESS1 = nomireader.GetString(1); Address1.Add(nomireader.GetString(1)); nom.Add(nomireader.GetString(1)); } else { ADDRESS1 = ""; Address1.Add(""); nom.Add(""); }
                        if (!nomireader.IsDBNull(2)) { ADDRESS2 = nomireader.GetString(2); Address1.Add(nomireader.GetString(2)); nom.Add(nomireader.GetString(2)); } else { ADDRESS2 = ""; Address1.Add(""); nom.Add(""); }
                        Address1.Add(""); Address1.Add(""); Address1.Add("Customer Copy");
                    }
                    nomireader.Close();
                    nomireader.Dispose();

                    this.litname.Text = Address1[0].ToString();
                    this.litad1.Text = Address1[1].ToString();
                    this.litad2.Text = Address1[2].ToString();
                }
                //else
                //{*/
                #region  //********* Name & Address Select **************
                string DINAME = "";
                string DIAD1 = "";
                string DIAD2 = "";
                string DIAD3 = "";
                string DIAD4 = "";
                /*

                    string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=0 ";
                    if (formObj.existRecored(dclmaddressSelect) != 0)
                    {
                        formObj.readSql(dclmaddressSelect);
                        OracleDataReader dclmAdReader = formObj.oraComm.ExecuteReader();
                        while (dclmAdReader.Read())
                        {
                            if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0);  } else { LANG = "";  }
                            if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1);  } else { INDEX = 0;  }
                            if (!dclmAdReader.IsDBNull(2)) { DINAME = dclmAdReader.GetString(2); Address2.Add(dclmAdReader.GetString(2)); } else { DINAME = ""; Address2.Add(""); }
                            if (!dclmAdReader.IsDBNull(3)) { DIAD1 = dclmAdReader.GetString(3); Address2.Add(dclmAdReader.GetString(3)); } else { DIAD1 = ""; Address2.Add(""); }
                            if (!dclmAdReader.IsDBNull(4)) { DIAD2 = dclmAdReader.GetString(4); Address2.Add(dclmAdReader.GetString(4)); } else { DIAD2 = ""; Address2.Add(""); }
                            if (!dclmAdReader.IsDBNull(5)) { DIAD3 = dclmAdReader.GetString(5); Address2.Add(dclmAdReader.GetString(5)); } else { DIAD3 = ""; Address2.Add(""); }
                            if (!dclmAdReader.IsDBNull(6)) { DIAD4 = dclmAdReader.GetString(6); Address2.Add(dclmAdReader.GetString(6)); } else { DIAD4 = ""; Address2.Add(""); }
                            Address2.Add(""); Address2.Add("Customer Copy");
                            if (INDEX == 0)
                            {
                                this.litname.Text = Address2[0].ToString();
                                this.litad1.Text = Address2[1].ToString();
                                this.litad2.Text = Address2[2].ToString();
                                this.litad3.Text = Address2[3].ToString();
                                this.litad4.Text = Address2[4].ToString();
                            }
                            Address2.Add("CUSTOMER  COPY");
                        }
                        if (Address2[0].ToString() != "")
                        {
                            CopyToArr.Add(Address2);
                        }
                        dclmAdReader.Close();                       
                    }
                    else
                    {*/
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
                        if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5); Address2.Add(DNOD); } else { Address2.Add(""); }
                        if (!dthintReader.IsDBNull(6)) { cliamNo = dthintReader.GetInt64(6); Address2.Add(cliamNo); } else { Address2.Add(""); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                    Address2.Add("Customer Copy");
                    this.litname.Text = Address2[0].ToString();
                    this.litad1.Text = Address2[1].ToString();
                    this.litad2.Text = Address2[2].ToString();
                    this.litad3.Text = Address2[3].ToString();
                    this.litad4.Text = Address2[4].ToString();
                    this.litnameofdead.Text = Address2[5].ToString();
                    if (Address2[0].ToString() != "")
                    {
                        CopyToArr.Add(Address2);
                    }
                }
                this.litnameofdead.Text = DNOD;
                //   this.lblyrref.Text = epfStr;
                this.litorref.Text = cliamNo.ToString();
                //this.litorYourRef.Text = cliamNo.ToString();
                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                //}

                #endregion
                //}

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

                this.litnameofdead.Text = DNOD;
                //  this.lblyrref.Text = epfStr;
                this.litorref.Text = cliamNo.ToString();
                //this.litorYourRef.Text = cliamNo.ToString();
                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);


                this.litpolno.Text = polno.ToString();
                bool existflag = false;
                int mostype = 0;
                if (MOF == "M") { mostype = 1; } else if (MOF == "S") { mostype = 2; } else if (MOF == "2") { mostype = 3; } else if (MOF == "C") { mostype = 4; }
                dreqSelect = "select a.drcovtyp, a.drrema from lphs.dreq a left outer join LPHS.DREQDESC b on A.DRCOVTYP=B.DREQCODE where drpol=" + polno + " and drtyp='" + MOF + "' and (a.DRRECDT is null or a.DRRECDT=0) " +
                             "and a.drcovtyp not in (select distinct(to_number(DC_DOCCODE)) from   LPHS.DCT_DOCCOLLECT where DC_POLNO=" + polno + " and DC_LIFETYPE=" + mostype + " and DC_DOCCODE not like 'OT%') order by  B.ORDERNO";
                formObj.readSql(dreqSelect);
                OracleDataReader dreqreader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //int r_row = 1;
                //int other_row = 1;
                while (dreqreader.Read())
                {
                    existflag = true;
                    reqcode = dreqreader.GetInt32(0);

                    //dreqSelect = "select DREQDESCSIN,dreqdessrtsin from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
                    //formObj.readSql(dreqSelect);
                    //OracleDataReader dreqreader02 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    //while (dreqreader02.Read())
                    //{
                    //    if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); } else { reqdesc = ""; }
                    //    if (!dreqreader02.IsDBNull(1)) { reqSrtdesc = dreqreader02.GetString(1); } else { reqSrtdesc = ""; }
                    //    if (reqcode == 9)
                    //    {
                    //        if (reqdesc.Length > 97)
                    //        {
                    //            reqdesc = reqdesc.Substring(0, 51) + " " + deathCertName + " " + reqdesc.Substring(66, 19) + " " + poldocname + " " + reqdesc.Substring(97, (reqdesc.Length - 97));
                    //        }
                    //    }
                    //}
                    int row = rows + 1;

                    if (reqcode == 1 || reqcode == 2 || reqcode == 3 || reqcode == 14)
                    {
                        ReqcodeListN.Add(reqcode);
                    }
                    else
                    {
                        ReqcodeListOther.Add(reqcode);
                    }

                    if (reqcode != 22 && reqcode != 23 && reqcode != 24)
                    {
                        rows++;
                    }
                    //dreqreader02.Close();
                    //dreqreader02.Dispose();
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
                    dreqSelect = "select DREQDESCSIN,dreqdessrtsin from lphs.dreqdesc where dreqcode=" + rcode + "  ";
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
                    dreqSelect = "select DREQDESCSIN,dreqdessrtsin from lphs.dreqdesc where dreqcode=" + rcode + "  ";
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
                if (Session["Req22"] != null)
                {
                    litreq22.Text = Session["Req22"].ToString();
                    ReqId.Visible = true;
                }
                if (Session["Req23sin"] != null && Session["Req23sin_2"] != null)
                {
                    litreq23.Text = Session["Req23sin"].ToString();
                    //litreq23new.Text = "<li>m%Odk rlaIs;hd fy` l,;% wdjrKh mj;ajdf.k hdu ioyd ixfYdaOkh lrk ,o jdr uqo, csjs; Tmamq fiajd wxYh u.ska bosrsfhaos Tn fj; okajkq we;</li>";
                    litreq23new.Text = Session["Req23sin_2"].ToString();
                    litreq23new.Visible = true;
                    ReqId.Visible = true;
                    ReqNew.Visible = true;
                }
                if (Session["Req21"] != null)
                {
                    litreq21.Text = Session["Req21"].ToString();
                    litnomname.Text = Session["NomName"].ToString();
                    litreq2.Text = Session["Req21_2"].ToString();
                    ReqId.Visible = true;
                }
                dreqreader.Close();
                dreqreader.Dispose();
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

                        if (INDEX == 2)
                        {
                            Address3.Add(""); Address3.Add("BRANCH   COPY");
                            if ((Address3[0] != null) && (!Address3[0].ToString().Equals("")))
                            {
                                //this.lblcopy1desc.Visible = true;
                                //this.litcopy1.Visible = true;
                                CopyToArr.Add(Address3);
                                //this.litcopy1.Text = Address3[0].ToString() + ", " + Address3[1].ToString() + " " + Address3[2].ToString() + " " + Address3[3].ToString() + " " + Address3[4].ToString();
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

                        if (INDEX == 3)
                        {
                            Address4.Add("CLOSER BRANCH COPY");
                            if ((Address4[0] != null) && (!Address4[0].ToString().Equals("") && (!Address4[2].ToString().Trim().Equals(""))))
                            {
                                //this.lblcopy2desc.Visible = true;
                                //this.litcopy2.Visible = true;
                                //this.litcopy2.Text = Address4[0].ToString() + ", " + Address4[1].ToString() + " " + Address4[2].ToString() + " " + Address4[3].ToString() + " " + Address4[4].ToString();
                                CopyToArr.Add(Address4);
                            }
                        }
                    }
                    dclmAdReader2.Close();
                    dclmAdReader2.Dispose();
                }

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
                    dthintReader.Close();
                    dthintReader.Dispose();
                    AGENCY = AGENTCode;
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
                            if (!dthintReader.IsDBNull(0)) { Address6.Add(dthintReader.GetString(0).Trim()); }
                            else { Address6.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { Address6.Add(dthintReader.GetString(1)); }
                            else { Address6.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { Address6.Add(dthintReader.GetString(2)); }
                            else { Address6.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { Address6.Add(dthintReader.GetString(3)); }
                            else { Address6.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { Address6.Add(dthintReader.GetString(4)); }
                            else { Address6.Add(""); }
                            if (!dthintReader.IsDBNull(5)) { Address6.Add(dthintReader.GetString(5)); }
                            else { Address6.Add(""); }
                            Address6.Add(AGENCY);
                            Address6.Add("INSURANCE ADVISOR'S COPY");

                            if (Address6[0].ToString() != "")
                            {
                                CopyToArr.Add(Address6);
                            }
                            //  litcopy3.Text = AGENTCode.ToString() + Address6[0].ToString() + Address6[1].ToString() + Address6[2].ToString() + Address6[3].ToString() + Address6[4].ToString() + Address6[5].ToString();
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();

                    }
                }

                #region  //********* Regional Sales Manager **************

                string dclmaddressSelect3 = "select  LANG, INDX, NAME, ADDR1,ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=6";
                if (formObj.existRecored(dclmaddressSelect3) != 0)
                {
                    formObj.readSql(dclmaddressSelect3);
                    OracleDataReader dclmAdReader3 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader3.Read())
                    {
                        if (!dclmAdReader3.IsDBNull(0)) { LANG = dclmAdReader3.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader3.IsDBNull(1)) { INDEX = dclmAdReader3.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader3.IsDBNull(2)) { Address7.Add(dclmAdReader3.GetString(2).ToUpper()); } else { Address7.Add(""); }
                        Address7.Add("SRI LANKA INSURANCE, ");
                        if (!dclmAdReader3.IsDBNull(3)) { Address7.Add(dclmAdReader3.GetString(3)); } else { Address7.Add(""); }
                        if (!dclmAdReader3.IsDBNull(4)) { Address7.Add(dclmAdReader3.GetString(4)); } else { Address7.Add(""); }
                        if (!dclmAdReader3.IsDBNull(5)) { Address7.Add(dclmAdReader3.GetString(5)); } else { Address7.Add(""); }
                        if (!dclmAdReader3.IsDBNull(6)) { Address7.Add(dclmAdReader3.GetString(6)); } else { Address7.Add(""); }

                        if (INDEX == 6)
                        {
                            Address7.Add("REGIONAL SALES MANAGER COPY");
                            if ((Address7[0] != null) && (!Address7[0].ToString().Equals("")))
                            {
                                //this.lblcopy2desc.Visible = true;
                                //this.litcopy2.Visible = true;
                                //this.litcopy2.Text = Address4[0].ToString() + ", " + Address4[1].ToString() + " " + Address4[2].ToString() + " " + Address4[3].ToString() + " " + Address4[4].ToString();
                                CopyToArr.Add(Address7);
                            }
                        }
                    }
                    dclmAdReader3.Close();
                    dclmAdReader3.Dispose();
                }

                #endregion

                #region  //********* Sales Manager **************

                string dclmaddressSelect4 = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX=4";
                if (formObj.existRecored(dclmaddressSelect4) != 0)
                {
                    formObj.readSql(dclmaddressSelect4);
                    OracleDataReader dclmAdReader4 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader4.Read())
                    {
                        if (!dclmAdReader4.IsDBNull(0)) { LANG = dclmAdReader4.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader4.IsDBNull(1)) { INDEX = dclmAdReader4.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader4.IsDBNull(2)) { Address8.Add(dclmAdReader4.GetString(2)); } else { Address8.Add(""); }
                        if (!dclmAdReader4.IsDBNull(3)) { Address8.Add(dclmAdReader4.GetString(3)); } else { Address8.Add(""); }
                        if (!dclmAdReader4.IsDBNull(4)) { Address8.Add(dclmAdReader4.GetString(4)); } else { Address8.Add(""); }
                        if (!dclmAdReader4.IsDBNull(5)) { Address8.Add(dclmAdReader4.GetString(5)); } else { Address8.Add(""); }
                        if (!dclmAdReader4.IsDBNull(6)) { Address8.Add(dclmAdReader4.GetString(6)); } else { Address8.Add(""); }

                        if (INDEX == 4)
                        {
                            Address8.Add("SALES MANAGER COPY");
                            if ((Address8[0] != null) && (!Address8[0].ToString().Equals("") && (!Address8[2].ToString().Trim().Equals(""))))
                            {
                                //this.lblcopy2desc.Visible = true;
                                //this.litcopy2.Visible = true;
                                //this.litcopy2.Text = Address4[0].ToString() + ", " + Address4[1].ToString() + " " + Address4[2].ToString() + " " + Address4[3].ToString() + " " + Address4[4].ToString();
                                CopyToArr.Add(Address8);
                            }
                        }
                    }
                    dclmAdReader4.Close();
                    dclmAdReader4.Dispose();
                }

                #endregion

                //litreqAll.Text = "<li style='text-align:justify'>ie hq -fuh idujsksiqrejrfhl= idCIs orkafka kuz muKla ;u rnrA uqødfjys Tyqf.a$wehf.a ku ,smskh ,shdmosxps wxlh iy wod, wOslrK n, m%foaYh ioyka jsh hq;=h</li>";
                #endregion
                if (!existflag) { throw new Exception("No Requirement Details!"); }


                getNotices(polno, MOF);

                AutoReq autoReq = new AutoReq();
                if ((autoReq.getPolicyStatus(formObj, polno) == 2) || (autoReq.getPolicyStatus(formObj, polno) == 3 && MOF == "S"))
                {
                    desc1.Visible = false;
                    litreqAll.Text = "";

                    otherDesc.Visible = false;
                    otherDesc2.InnerText = "fuu cSjs; rlaIK Tmamqj hgf;a bosrs lghq;= lsrsu ioyd my; ioyka wjYH;d wm fj; tjk fuka ldreKslj okajd isgsuq";
                }
                else
                {
                    desc1.Visible = true;
                    litreqAll.Text = "<li style='text-align:justify'>ie hq -fuh idujsksiqrejrfhl= idCIs orkafka kuz muKla ;u rnrA uqødfjys Tyqf.a$wehf.a ku ,smskh ,shdmosxps wxlh iy wod, wOslrK n, m%foaYh ioyka jsh hq;=h</li>";

                    otherDesc.Visible = true;
                    otherDesc2.InnerText = "by; ioyka wlD;sm;% iu. my; ioyka wjYH;do wm fj; tjSug lghq;= lrkak'";
                }

                formObj.connclose();
            }
            catch (Exception ex)
            {
                formObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        if (Chckedbtn == 2)
        {
            Response.Clear();
            Response.Buffer = true;
            Page.EnableViewState = false;
            

            //Response.ContentType = "application/msword";
            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "attachment; filename=" + polno + "_requirements.doc");

            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            this.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
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
        lbl1.Text = reqcode + "'";
        lbl1.Style["text-align"] = "left";
        lbl1.Style["padding-left"] = "15px";

        lbl2.ID = "ReqName" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
        lbl2.Style["padding-left"] = "0px";

        if (req.EndsWith("."))
        {
            lbl2.Text = req.Remove(req.Length - 1);
        }
        else
        {
            lbl2.Text = req;
        }
        lbl2.Style["text-align"] = "justify";
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        tblClmForm.Rows.Add(trow);
    }

    private void createDynamicEnclosedTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "Number" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
        lbl1.Text = reqcode + "'";
        lbl1.Style["text-align"] = "left";
        lbl1.Style["padding-left"] = "15px";

        lbl2.ID = "ReqName" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
        lbl2.Style["padding-left"] = "0px";

        if (req.EndsWith("."))
        {
            lbl2.Text = req.Remove(req.Length - 1);
        }
        else
        {
            lbl2.Text = req;
        }
        lbl2.Style["text-align"] = "justify";
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        tblEnclose.Rows.Add(trow);
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
            lbl1.Text = reqcode + "'";
            lbl1.Style["text-align"] = "left";
            lbl1.Style["padding-left"] = "15px";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Style["padding-left"] = "0px";

            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }
            lbl2.Style["text-align"] = "justify";
            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            tblOtherDoc.Rows.Add(trow);

            if (RecordNumber == 19)
            {
                for (int i = 0; i < AssureChg.Count; i++)
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
                    Dynlbl1.Style["padding-left"] = "15px";
                    tc.Controls.Add(Dynlbl1);
                    tr.Cells.Add(tc);



                    TableCell tc1 = new TableCell();
                    Label Dylbel = new Label();
                    if (RecordNumber == 19)
                    {
                        Dylbel.ID = "Dylbel9" + i.ToString();
                        Dylbel.Text = AssureChg[i].ToString();
                    }

                    Dylbel.ControlStyle.Font.Name = "Sandaya";
                    Dylbel.ControlStyle.Font.Size = 11;
                    Dylbel.Style["padding-left"] = "15px";
                    tc1.Controls.Add(Dylbel);
                    tr.Cells.Add(tc1);
                    tblOtherDoc.Rows.Add(tr);
                    // tblDynamic.Rows.Add(tr);


                }


                TableRow trdes = new TableRow();
                tblOtherDoc.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString();
                    Dynlbl2.Text = "by; kuz Ndjs;d l, nj ;yjqre lsrSug ,sLs; idOl o  wm fj; ,ndoSug lghq;+ lr;a; ^Wod yeoqkquzmf;ys Pdhd msgm;la fyda Wmamekak iy;slfha iy;sl l, msgm;la wdosh&";
                }

                Dynlbl2.ControlStyle.Font.Name = "Sandaya";
                Dynlbl2.ControlStyle.Font.Size = 11;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);


            }

            if (RecordNumber == 20)
            {
                for (int i = 0; i < NomChg.Count; i++)
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
                    Dynlbl1.Style["padding-left"] = "15px";
                    tc.Controls.Add(Dynlbl1);
                    tr.Cells.Add(tc);



                    TableCell tc1 = new TableCell();
                    Label dynlabel = new Label();

                    if (RecordNumber == 20)
                    {
                        dynlabel.ID = "dynlabel10" + i.ToString();
                        dynlabel.Text = NomChg[i].ToString();
                    }


                    dynlabel.ControlStyle.Font.Name = "Sandaya";
                    dynlabel.ControlStyle.Font.Size = 11;
                    tc1.Controls.Add(dynlabel);
                    tr.Cells.Add(tc1);
                    tblOtherDoc.Rows.Add(tr);
                    // tblDynamic.Rows.Add(tr);


                }

                TableRow trdes = new TableRow();
                tblOtherDoc.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();

                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString();
                    Dynlbl2.Text = "by; kuz Ndjs;d l, nj ;yjqre lsrSug ,sLs; idOl o  wm fj; ,ndoSug lghq;+ lr;a; ^Wod yeoqkquzmf;ys Pdhd msgm;la fyda Wmamekak iy;slfha iy;sl l, msgm;la wdosh&";
                }

                Dynlbl2.ControlStyle.Font.Name = "Sandaya";
                Dynlbl2.ControlStyle.Font.Size = 11;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);


            }

            if (RecordNumber == 21)
            {
                TableRow tr1 = new TableRow();
                tblOtherDoc.Controls.Add(tr1);
                TableCell tchead = new TableCell();
                TableCell tchead1 = new TableCell();
                Label headlbl = new Label();
                if (AssNomChg.Count != 0)
                {
                    headlbl.Text = "rCIs;hdf.a ku fjkia jSu";
                    headlbl.ControlStyle.Font.Name = "Sandaya";
                    headlbl.ControlStyle.Font.Size = 11;
                    headlbl.Style["padding-left"] = "15px";
                    headlbl.Font.Bold = true;
                    headlbl.Font.Underline = true;
                    tchead1.Controls.Add(headlbl);
                    tr1.Cells.Add(tchead);
                    tr1.Cells.Add(tchead1);
                }

                for (int i = 0; i < AssNomChg.Count; i++)
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
                    Dynlbl1.Style["padding-left"] = "15px";
                    tc.Controls.Add(Dynlbl1);
                    tr.Cells.Add(tc);



                    TableCell tc1 = new TableCell();
                    Label Dylabel = new Label();

                    if (RecordNumber == 21)
                    {
                        Dylabel.ID = "Dylabel11" + i.ToString();
                        Dylabel.Text = AssNomChg[i].ToString();
                    }

                    Dylabel.ControlStyle.Font.Name = "Sandaya";
                    Dylabel.ControlStyle.Font.Size = 11;
                    tc1.Controls.Add(Dylabel);
                    tr.Cells.Add(tc1);
                    tblOtherDoc.Rows.Add(tr);
                    // tblDynamic.Rows.Add(tr);


                }
                TableRow tr2 = new TableRow();
                tblOtherDoc.Controls.Add(tr2);
                TableCell tchead2 = new TableCell();
                TableCell tchead3 = new TableCell();
                Label headlbl1 = new Label();
                if (AssNomChg2.Count != 0)
                {
                    headlbl1.Text = "kduslhdf.a ku fjkia jSu";
                    headlbl1.ControlStyle.Font.Name = "Sandaya";
                    headlbl1.ControlStyle.Font.Size = 11;
                    headlbl1.Style["padding-left"] = "15px";
                    headlbl1.Font.Bold = true;
                    headlbl1.Font.Underline = true;
                    tchead3.Controls.Add(headlbl1);
                    tr2.Cells.Add(tchead2);
                    tr2.Cells.Add(tchead3);
                }
                for (int i = 0; i < AssNomChg2.Count; i++)
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
                    Dynlbl1.Style["padding-left"] = "15px";
                    tc.Controls.Add(Dynlbl1);
                    tr.Cells.Add(tc);



                    TableCell tc1 = new TableCell();
                    Label Dylabel = new Label();

                    if (RecordNumber == 21)
                    {
                        Dylabel.ID = "Dylabel11" + i.ToString();
                        Dylabel.Text = AssNomChg2[i].ToString();
                    }

                    Dylabel.ControlStyle.Font.Name = "Sandaya";
                    Dylabel.ControlStyle.Font.Size = 11;
                    tc1.Controls.Add(Dylabel);
                    tr.Cells.Add(tc1);
                    tblOtherDoc.Rows.Add(tr);
                    // tblDynamic.Rows.Add(tr);


                }

                TableRow trdes = new TableRow();
                tblOtherDoc.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();

                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                    Dynlbl2.Text = "by; ioyka mrsos ush.sh rlaIs; uy;df.a kfuz fjkila mj;sk nejska tu kuz j,ska yoqkajkq ,nkafka ush.sh rlaIs; uy;du kuz ta njg iy;sl lrk ,o m%dfoaYSh f,aluzf.a wkq w;aik iys; .%du ks,OdrS iy;slhla iy Tnf.a kfuz fjki ioyd re 25/- la jgskd uqoaorhla u; Tn jsiska w;aika lrk ,o osjzreuz m%ldYkhla ,ndf.k wm fj; tjsh hq;= w;r tyso tu kuz j,ska yoqkajkq ,nkafka tlu mqoa.,hl= njg ;yjqre lr iy;sl lr ;snsh hq;=h";
                }
                Dynlbl2.ControlStyle.Font.Name = "Sandaya";
                Dynlbl2.ControlStyle.Font.Size = 11;
                Dynlbl2.Style["padding-left"] = "15px";
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);
            }
            //===========================================
            //Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            //Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            //Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;
        }
        if (RecordNumber == 22)
        {
            Session["Req22"] = req;
        }
        if (RecordNumber == 23)
        {
            Session["Req23sin"] = req;
            Session["Req23sin_2"] = "<li>m%Odk rlaIs;hd fy` l,;% wdjrKh mj;ajdf.k hdu ioyd ixfYdaOkh lrk ,o jdr uqo, csjs; Tmamq fiajd wxYh u.ska bosrsfhaos Tn fj; okajkq we;</li>";
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
                    Session["Req21"] = req + " ";
                    Session["NomName"] = Nominees + " ";
                    Session["Req21_2"] = "jsiska iuzmqrAK l,hq;=h'kdusl m%;s,dNshd nd,jhialdr wfhla kuz fuz iu. tjk ysusluz lshkakdf.a m%ldYkh Tyqf.a$wehf.a jevsysgs Ndrlrefjla jsiska iuzmQrAK l, hq;=h";
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
            noticeDisList = autoReq.getNotices(polno, MOF, dthReqObj,"si");

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
}
