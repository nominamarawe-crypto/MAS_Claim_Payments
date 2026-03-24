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

public partial class vouReprint003 : System.Web.UI.Page
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

    DataManager dm = new DataManager();
    NumberSeparate ns;
    General gg;

    private long polno;
    private string MOS;
    private string payee = "";
    //private  double totamount;
    private double amtOut;
    private long claimno;

    private string vouno = "";
    private int voudate;
    private double share;
    private double exgrShare;
    private double slicAmt;
    private int slicflag;
    private string reason;
    private string propno;

    private string HNAME = "";
    private string HNAME1 = "";
    private string ACNO = "";
    private string ADD1 = "";
    private string ADD2 = "";
    private string ADD3 = "";
    private string ADD4 = "";
    private string INSNAME = "";
    private string RECIPIENT_NAME = "";
    private double TOTAMOUNT;
    private string BNKNAME = "";
    private string BNKBRNNAME = "";
    private string CUSTACCTNO = "";
    private int depacct = 0;
    private string addepf, authoepf;
    private double stagePayment;
    private bool signatureDisplay;
    private double PER; //Sanjana 34965

    protected void Page_Load(object sender, EventArgs e)
    {
 
        if (!Page.IsPostBack)
        {
            if (Session["signatureDisplay"] != null)
            {
                signatureDisplay = bool.Parse(Session["signatureDisplay"].ToString());
            }
            dm = new DataManager();
            try
            {
               
                #region //------------- view state ------------
                polno = long.Parse(Request.QueryString["polno"]);
                MOS = Request.QueryString["mos"].ToString();
                vouno = Request.QueryString["vouno"].ToString();
                payee = Request.QueryString["payee"].ToString();
                share = double.Parse(Request.QueryString["amount"]);
                claimno = long.Parse(Request.QueryString["clmno"]);
                exgrShare = double.Parse(Request.QueryString["exgrshare"]);
                slicflag = int.Parse(Request.QueryString["slicflag"].ToString());

                ViewState.Add("polnoQstr", polno.ToString());
                ViewState.Add("MOSQstr", MOS);
                ViewState.Add("vounoQstr", vouno);
                ViewState.Add("payeeQstr", payee);                
                ViewState.Add("clmno", claimno.ToString());                
                ViewState.Add("slicflag", slicflag.ToString());

                #endregion

                #region-------------------Vou. Acct code---------22/04/2009 update------
                gg = new General();
                if (gg.IsVouAmtDeposit(dm, polno, MOS))
                {
                    //Apply the deposit account number
                    depacct = 1168;
                }
                else
                {
                    depacct = 2118;
                }
                this.lblPayac.Text = "00" + depacct.ToString();
                #endregion

                #region------------------------Check Repudiation--------------------
                string repudationsel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='" + MOS + "'";
                if ((dm.existRecored(repudationsel) != 0) && (depacct == 2118))
                {
                    exgrShare = share;
                    //share=0;
                }
                #endregion

                ViewState.Add("exgrshareStr", exgrShare.ToString());
                ViewState.Add("shareQstr", share.ToString());

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", (share));
                //if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                if ((share - exgrShare) > 0.5) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                slicAmt = this.Sliamount(polno, MOS, dm);

                //string slicVouSel = "select * from LPHS.SLICVOUCHERS where SVPOL=" + polno + " and SVVOUNO='" + vouno + "' and SVMOS='" + MOS + "'";
                //if (dm.existRecored(slicVouSel) != 0)
                //{
                //    this.lblExgrAmt.Text = String.Format("{0:N}", slicAmt);
                //}
                //else
                //{
                //    this.lblExgrAmt.Text = String.Format("{0:N}", (exgrShare - slicAmt)); 
                //}

                //Task 30080
                if ((share - exgrShare) <= 0.5)
                {
                    exgrShare = share;
                }

                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);

                //string accCode = "";
                ////string accCodeSel = "select B.ACCODE from LPHS.SLICVOUCHERS a, CASHBOOK.TEMP_CB b where A.SVVOUNO=B.VOUNO and A.SVPOL=B.POLNO and A.SVPOL=" + polno + "";
                //string accCodeSel = "select ACCODE from CASHBOOK.TEMP_CB where VOUNO ='" + vouno + "'";
                //if (dm.existRecored(accCodeSel) != 0)
                //{
                //    dm.readSql(accCodeSel);
                //    OracleDataReader accCodeRead = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                //    while (accCodeRead.Read())
                //    {
                //        if (!accCodeRead.IsDBNull(0)) { accCode = accCodeRead.GetString(0); } else { accCode = ""; }
                //    }
                //    accCodeRead.Close();
                //    accCodeRead.Dispose();
                //}

                //if (accCode == "2118")
                //{
                //    //this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);
                //    this.lblclmAmt.Text = String.Format("{0:N}", share);
                //}
                //else
                //{
                //    string slicVouSel = "select * from LPHS.SLICVOUCHERS where SVPOL=" + polno + " and SVVOUNO='" + vouno + "' and SVMOS='" + MOS + "'";
                //    if (dm.existRecored(slicVouSel) != 0)
                //    {
                //        this.lblExgrAmt.Text = String.Format("{0:N}", slicAmt);
                //    }
                //    else
                //    {
                //        this.lblExgrAmt.Text = String.Format("{0:N}", (exgrShare - slicAmt));
                //    }
                //}

                ViewState.Add("slicAmtStr", slicAmt.ToString());
                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round((share), 2) * 100);// + exgrShare

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                
                //Check SLIC Voucher or not------Editted by Dushan------
                if (slicflag == 1)
                {
                    this.lblPaytype.Text = "SLIC VOUCHER FOR DEATH CLAIMS";
                    this.lblProposal.Visible = true;
                    this.lblProposal1.Visible = true;
                    string propnosel = "select SVREASON from LPHS.SLICVOUCHERS where SVPOL=" + polno + " and SVCLMTYP='DTH' and SVMOS='" + MOS + "' and SVVOUNO='" + vouno + "'";
                    if (dm.existRecored(propnosel) != 0)
                    {
                        dm.readSql(propnosel);
                        OracleDataReader propnoread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (propnoread.Read())
                        {
                            if (!propnoread.IsDBNull(0)) { reason = propnoread.GetString(0); } else { reason = ""; }
                        }
                        propnoread.Dispose();
                    }
                    ns = new NumberSeparate(reason.Trim());
                    propno = ns.Number;
                    this.lblProposal1.Text = ": " + propno.Trim();
                }
                //get claim no ----------------

                #region //--------------- temp_cb select -------------------------------------

                string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, VOUDATE, " +
                    "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd')), ADD4, ADDEPF, AUTHOEPF" +
                    " from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and PRINT1 <> 1 and VPDATE is not null";

                if (dm.existRecored(temp_cbSelect) != 0)
                {
                    dm.readSql(temp_cbSelect);
                    OracleDataReader temp_cbReader = dm.oraComm.ExecuteReader();
                    while (temp_cbReader.Read())
                    {
                        if (!temp_cbReader.IsDBNull(0)) { HNAME = temp_cbReader.GetString(0); } else { HNAME = ""; }
                        if (!temp_cbReader.IsDBNull(1)) { HNAME1 = temp_cbReader.GetString(1); } else { HNAME1 = ""; }
                        if (!temp_cbReader.IsDBNull(3)) { ACNO = temp_cbReader.GetString(3); } else { ACNO = ""; }
                        if (!temp_cbReader.IsDBNull(6)) { ADD1 = temp_cbReader.GetString(6); } else { ADD1 = ""; }
                        if (!temp_cbReader.IsDBNull(7)) { ADD2 = temp_cbReader.GetString(7); } else { ADD2 = ""; }
                        if (!temp_cbReader.IsDBNull(8)) { ADD3 = temp_cbReader.GetString(8); } else { ADD3 = ""; }
                        if (!temp_cbReader.IsDBNull(5)) { INSNAME = temp_cbReader.GetString(5); } else { INSNAME = ""; }
                        if (!temp_cbReader.IsDBNull(9)) { RECIPIENT_NAME = temp_cbReader.GetString(9); } else { RECIPIENT_NAME = ""; }
                        if (!temp_cbReader.IsDBNull(2)) { TOTAMOUNT = temp_cbReader.GetDouble(2); } else { TOTAMOUNT = 0; }
                        if (!temp_cbReader.IsDBNull(11)) { voudate = temp_cbReader.GetInt32(11); } else { voudate = 0; }
                        if (!temp_cbReader.IsDBNull(12)) { ADD4 = temp_cbReader.GetString(12); } else { ADD4 = ""; }
                        if (!temp_cbReader.IsDBNull(13)) { addepf = temp_cbReader.GetString(13); } else { addepf = ""; }
                        if (!temp_cbReader.IsDBNull(14)) { authoepf = temp_cbReader.GetString(14); } else { authoepf = ""; }
                    }
                    temp_cbReader.Close();
                    temp_cbReader.Dispose();

                    this.lblassuredname.Text = INSNAME.ToUpper() ;
                    //if (HNAME1.Equals(""))
                    HNAME1 = HNAME + " " + HNAME1;
                    //this.lblnameofpayee.Text = HNAME1.ToUpper();
                    this.lblad1.Text = ADD1.ToUpper();
                    this.lblad2.Text = ADD2.ToUpper();
                    this.lblad3.Text = ADD3.ToUpper();
                    this.lblAd4.Text = ADD4.ToUpper();
                    if (voudate > 9999999)
                    {
                        this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                    }

                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Voucher Details Availbale or Cheque Already Printed or No Voucher Printed!");
                }

                #endregion

                #region //--------------- voubankdet select -------------------------------------

                string SLIACCTNO = "";

                string voubankdetSel = "select PAYEENAME, BNKNAME, BNKBRNNAME, SLIACCTNO, CUSTACCTNO from LPHS.VOUBANKDET where POLICYNO = " + polno + " and VOUCHERNO = '" + vouno + "' ";
                if (dm.existRecored(voubankdetSel) != 0)
                {
                    dm.readSql(voubankdetSel);
                    OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (voubankdetReader.Read())
                    {
                        if (!voubankdetReader.IsDBNull(0)) { HNAME1 = voubankdetReader.GetString(0); } else { HNAME1 = ""; }
                        if (!voubankdetReader.IsDBNull(1)) { BNKNAME = voubankdetReader.GetString(1); } else { BNKNAME = ""; }
                        if (!voubankdetReader.IsDBNull(2)) { BNKBRNNAME = voubankdetReader.GetString(2); } else { BNKBRNNAME = ""; }
                        if (!voubankdetReader.IsDBNull(3)) { SLIACCTNO = voubankdetReader.GetString(3); } else { SLIACCTNO = ""; }
                        if (!voubankdetReader.IsDBNull(4)) { CUSTACCTNO = voubankdetReader.GetString(4); } else { CUSTACCTNO = ""; }
                    }
                    voubankdetReader.Close();
                    voubankdetReader.Dispose();
                }
                else
                {
                    BNKNAME = "";
                    BNKBRNNAME = "";
                    SLIACCTNO = "";
                    CUSTACCTNO = "";
                    //HNAME1 = HNAME;
                }
                this.lblbkbranch.Text = BNKNAME.ToUpper() + " " + BNKBRNNAME.ToUpper();

                #endregion
                this.lblnameofpayee.Text = HNAME1;
                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];
                this.lblacctno.Text = CUSTACCTNO;

                //Task 34965
                string vouStageDetails = "select sum(total) from CASHBOOK.TEMP_DETL where vouno='" + vouno + "' and ACCODE=2235";
                if (dm.existRecored(vouStageDetails) != 0)
                {
                    dm.readSql(vouStageDetails);
                    OracleDataReader voubankdetReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (voubankdetReader.Read())
                    {
                        //Sanjana 34965----------
                        string percentage = "select NOMPER from LUND.NOMINEE where POLNO=" + polno + " and VOUNO='" + vouno + "'";
                        if (dm.existRecored(percentage) != 0)
                        {
                            dm.readSql(percentage);
                            OracleDataReader percntReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            percntReader.Read();

                            if (!percntReader.IsDBNull(0)) { PER = percntReader.GetDouble(0); }
                        }
                        //-----------------
                        if (!voubankdetReader.IsDBNull(0)) { StagePayment = (voubankdetReader.GetDouble(0) * PER)/ 100; } else { StagePayment = 0; } //Sanjana 34965
                    }
                    voubankdetReader.Close();
                    voubankdetReader.Dispose();
                }
                if (StagePayment > 0)
                {
                    StagePayAccCode.Visible = true;
                    lblStageAmt.Text = String.Format("{0:N}", StagePayment);
                    ViewState["StagePayment"] = StagePayment;
                    if ((share - exgrShare - stagePayment) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare - stagePayment)); }
                }
                //

                dm.connclose();

                //-------------
                         
                ViewState["amtOut"] = amtOut;
                ViewState["voudate"] = voudate;

                ViewState["HNAME"] = HNAME;
                ViewState["HNAME1"] = HNAME1;
                ViewState["ACNO"] = ACNO;
                ViewState["ADD1"] = ADD1;
                ViewState["ADD2"] = ADD2;
                ViewState["ADD3"] = ADD3;
                ViewState["ADD4"] = ADD4;
                ViewState["INSNAME"] = INSNAME;
                ViewState["RECIPIENT_NAME"] = RECIPIENT_NAME;
                ViewState["TOTAMOUNT"] = TOTAMOUNT;
                ViewState["BNKNAME"] = BNKNAME;
                ViewState["BNKBRNNAME"] = BNKBRNNAME;
                ViewState["CUSTACCTNO"] = CUSTACCTNO;
                ViewState["propno"] = propno;
                ViewState["depacct"] = depacct;
                ViewState["addepf"] = addepf;
                ViewState["authoepf"] = authoepf;
                ViewState["SlicAmt"] = slicAmt;
                ViewState["signatureDisplay"] = signatureDisplay;
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }

        }
        else 
        {
    
            polno = long.Parse(ViewState["polnoQstr"].ToString());
            MOS = ViewState["MOSQstr"].ToString();
            vouno = ViewState["vounoQstr"].ToString();
            voudate = int.Parse(ViewState["voudate"].ToString());
            payee = ViewState["payeeQstr"].ToString();        
            share = double.Parse(ViewState["shareQstr"].ToString());
            claimno = long.Parse(ViewState["clmno"].ToString());
            slicAmt = double.Parse(ViewState["slicAmtStr"].ToString());
            exgrShare = double.Parse(ViewState["exgrshareStr"].ToString());
            slicflag = int.Parse(ViewState["slicflag"].ToString());

            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }

            if (ViewState["HNAME"] != null) { HNAME = ViewState["HNAME"].ToString(); }
            if (ViewState["HNAME1"] != null) { HNAME1 = ViewState["HNAME1"].ToString(); }
            if (ViewState["ACNO"] != null) { ACNO = ViewState["ACNO"].ToString(); }
            if (ViewState["ADD1"] != null) { ADD1 = ViewState["ADD1"].ToString(); }
            if (ViewState["ADD2"] != null) { ADD2 = ViewState["ADD2"].ToString(); }
            if (ViewState["ADD3"] != null) { ADD3 = ViewState["ADD3"].ToString(); }
            if (ViewState["ADD4"] != null) { ADD4 = ViewState["ADD4"].ToString(); }
            if (ViewState["INSNAME"] != null) { INSNAME = ViewState["INSNAME"].ToString(); }
            if (ViewState["RECIPIENT_NAME"] != null) { RECIPIENT_NAME = ViewState["RECIPIENT_NAME"].ToString(); }
            if (ViewState["TOTAMOUNT"] != null) { TOTAMOUNT = double.Parse(ViewState["TOTAMOUNT"].ToString()); }
            if (ViewState["BNKNAME"] != null) { BNKNAME = ViewState["BNKNAME"].ToString(); }
            if (ViewState["BNKBRNNAME"] != null) { BNKBRNNAME = ViewState["BNKBRNNAME"].ToString(); }
            if (ViewState["CUSTACCTNO"] != null) { CUSTACCTNO = ViewState["CUSTACCTNO"].ToString(); }
            if (ViewState["propno"] != null) { propno = ViewState["propno"].ToString(); }
            if (ViewState["depacct"] != null) { depacct = int.Parse(ViewState["depacct"].ToString()); }
            if (ViewState["addepf"] != null) { addepf = ViewState["addepf"].ToString(); }
            if (ViewState["authoepf"] != null) { authoepf = ViewState["authoepf"].ToString(); }
            if (ViewState["StagePayment"] != null) { StagePayment = double.Parse(ViewState["StagePayment"].ToString()); }
            if (ViewState["signatureDisplay"] != null) { signatureDisplay = bool.Parse(ViewState["signatureDisplay"].ToString()); }

        }
        #region Add signature

        if (signatureDisplay)
        {
            #region Add signature to addepf
            if (addepf != "")
            {
                SignatureData signatureData = new SignatureData();
                signatureData = signatureData.getSignature(addepf);
                if (signatureData.Signature != null)
                {
                    lblSignature.Visible = true;
                    lbladdName.Visible = true;
                    lbladdepf.Visible = true;
                    lbladdDesig.Visible = true;
                    lbladddip.Visible = true;
                    lbladdComp.Visible = true;

                    string ImageName = addepf.PadLeft(5, '0') + "_sign.png";
                    System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                    SignatureImage.ImageUrl = "~/image/" + ImageName;
                    this.lbladdName.Text = signatureData.UserName + " ";
                    this.lbladddip.Text = "Life Insurance Section";
                    this.lbladdComp.Text = "Sri Lanka Insurance Corporation Life Ltd";
                    this.lbladdepf.Text = "( " + signatureData.EPF + " )";

                    if (signatureData.Role != null)
                    {
                        this.lbladdDesig.Text = signatureData.Role;
                    }
                    else
                    {
                        this.lbladdDesig.Text = "Authorized Officer";
                    }

                }
                else
                {
                    lblSignature.Visible = false;
                }
            }
            #endregion

            #region Add signature to authoepf
            if (authoepf != "")
            {
                SignatureData signatureData = new SignatureData();
                signatureData = signatureData.getSignature(authoepf);
                if (signatureData.Signature != null)
                {
                    lblSignature1.Visible = true;
                    lblauthoName.Visible = true;
                    lblauthoepf.Visible = true;
                    lblauthoDesig.Visible = true;
                    dot1.Visible = false;
                    dot2.Visible = false;
                    dot3.Visible = false;

                    string ImageName = authoepf.PadLeft(5, '0') + "_sign.png";
                    System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                    SignatureImage1.ImageUrl = "~/image/" + ImageName;
                    this.lblauthoName.Text = signatureData.UserName + " ";
                    this.lblauthoepf.Text = "( " + signatureData.EPF + " )";

                    if (signatureData.Role != null)
                    {
                        this.lblauthoDesig.Text = signatureData.Role;
                    }
                    else
                    {
                        this.lblauthoDesig.Text = "Authorized Officer";
                    }

                }
                else
                {
                    lblSignature.Visible = false;
                }
            }

            #endregion

        }
        ViewState["signatureDisplay"] = signatureDisplay;

        #endregion
        
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {

    }
    protected void btnexit_Click(object sender, EventArgs e)
    {

    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public string hNAME
    {
        get { return HNAME; }
        set { HNAME = value; }
    }
    public string hNAME1
    {
        get { return HNAME1; }
        set { HNAME1 = value; }
    }
    public string aCNO
    {
        get { return ACNO; }
        set { ACNO = value; }
    }
    public string aDD1
    {
        get { return ADD1; }
        set { ADD1 = value; }
    }
    public string aDD2
    {
        get { return ADD2; }
        set { ADD2 = value; }
    }
    public string aDD3
    {
        get { return ADD3; }
        set { ADD3 = value; }
    }
    public string aDD4
    {
        get { return ADD4; }
        set { ADD4 = value; }
    }
    public string iNSNAME
    {
        get { return INSNAME; }
        set { INSNAME = value; }
    }
    public string rECIPIENT_NAME
    {
        get { return RECIPIENT_NAME; }
        set { RECIPIENT_NAME = value; }
    }

    public string bNKNAME
    {
        get { return BNKNAME; }
        set { BNKNAME = value; }
    }
    public string bNKBRNNAME
    {
        get { return BNKBRNNAME; }
        set { BNKBRNNAME = value; }
    }
    public double tOTAMOUNT
    {
        get { return TOTAMOUNT; }
        set { TOTAMOUNT = value; }
    }
    public double AmtOut
    {
        get { return amtOut; }
        set { amtOut = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public string Vouno
    {
        get { return vouno; }
        set { vouno = value; }
    }
    public int Voudate
    {
        get { return voudate; }
        set { voudate = value; }
    }
    public double Share
    {
        get { return share; }
        set { share = value; }
    }
    public string cUSTACCTNO
    {
        get { return CUSTACCTNO; }
        set { CUSTACCTNO = value; }
    }
    public double ExgrShare
    {
        get { return exgrShare; }
        set { exgrShare = value; }
    }
    public double SlicAmt
    {
        get { return slicAmt; }
        set { slicAmt = value; }
    }
    public int Slicflag
    {
        get { return slicflag; }
        set { slicflag = value; }
    }
    public string Propno
    {
        get { return propno; }
        set { propno = value; }
    }
    public int Depacct
    {
        get { return depacct; }
        set { depacct = value; }
    }
    public string Addepf
    {
        get { return addepf; }
        set { addepf = value; }
    }

    public string Authoepf
    {
        get { return authoepf; }
        set { authoepf = value; }
    }
    public double StagePayment
    {
        get { return stagePayment; }
        set { stagePayment = value; }
    }
    public bool SignatureDisplay
    {
        get { return signatureDisplay; }
        set { signatureDisplay = value; }
    }


    private double Sliamount(long polino, string svmos, DataManager dm)
    {
        double sliamt = 0;
        string balancesel = "select sum(SVAMT) from LPHS.SLICVOUCHERS where SVPOL=" + polino + " and SVMOS='" + svmos + "' and SYSTEM_TYPE='PP'";
        if (dm.existRecored(balancesel) != 0)
        {
            dm.readSql(balancesel);
            OracleDataReader balancereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (balancereader.Read())
            {
                if (!balancereader.IsDBNull(0)) { sliamt = balancereader.GetDouble(0); } else { sliamt = 0; }
            }
            //balancereader.Close();
            //balancereader.Dispose();
        }
        return sliamt;
    }
}
