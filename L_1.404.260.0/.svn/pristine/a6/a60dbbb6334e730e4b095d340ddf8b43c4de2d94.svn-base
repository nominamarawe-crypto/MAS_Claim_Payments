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

public partial class cvouPrint002 : System.Web.UI.Page
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
    
    DataManager dm;
    private long polno;
    private string MOS;
    private string payee = "", voudatestr = "";
    private double amtOut;
    private long claimno;

    private string vouno = "";
    private int voudate;
    private double share;
    private double exgrShare;

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
    private string EPF = "";
    private string addepf = "";
    private string authoepf = "";
    private int accode;
    private bool signatureDisplay;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            Response.Redirect("~/SessionError.aspx");
        }

        if (Session["signatureDisplay"] != null)
        {
            signatureDisplay = bool.Parse(Session["signatureDisplay"].ToString());
        }

        if (!Page.IsPostBack)
        {
            try
            {
                
                #region //----------- view state -------

                //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
                //{
                //    polno = this.PreviousPage.Polno;
                //    claimno = this.PreviousPage.Clmno;
                //    vouno = this.PreviousPage.Vouno;
                //    share = this.PreviousPage.Payamt;
                //}
                //else
                {
                    vouno = Request.QueryString["vouno"].ToString();
                    payee = Request.QueryString["payee"].ToString();
                    share = double.Parse(Request.QueryString["amount"]);
                    polno = long.Parse(Request.QueryString["polno"]);
                    MOS = Request.QueryString["mos"].ToString();
                }
                dm = new DataManager();

                #region ---------dthref--------------------------
                string dthrefsel = "select DRCLMNO from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOS + "'";
                string cprotoutsel = "select CLAIMNO from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + mos + "'";

                if (dm.existRecored(dthrefsel) != 0)
                {
                    dm.readSql(dthrefsel);
                    OracleDataReader dthrefread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    dthrefread.Read();
                    if (!dthrefread.IsDBNull(0)) { claimno = dthrefread.GetInt64(0); } else { claimno = 0; }
                    dthrefread.Close();
                    dthrefread.Dispose();
                }
                else if (dm.existRecored(cprotoutsel) != 0)
                {
                    dm.readSql(cprotoutsel);
                    OracleDataReader cprotoutread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    cprotoutread.Read();
                    if (!cprotoutread.IsDBNull(0)) { claimno = cprotoutread.GetInt32(0); } else { claimno = 0; }
                    cprotoutread.Close();
                    cprotoutread.Dispose();
                }
                #endregion
                //ViewState.Add("polnoQstr", polno.ToString());
                //ViewState.Add("vounoQstr", vouno);
                //ViewState.Add("shareQstr", share.ToString());
                //ViewState.Add("clmno", claimno.ToString());


                #endregion

                

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round(share, 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                //get claim no ----------------

                //Accode---------------
                General gg = new General();
                accode = gg.Account_code(polno, "CP", dm);

                #region //--------------- temp_cb select -------------------------------------
                
                string temp_cbSelect = "select HNAME, HNAME1, TOTAMOUNT, ACNO, to_char(VOUDATE, 'yyyy/mm/dd'), " +
                    "INSNAME, ADD1, ADD2, ADD3, RECIPIENT_NAME, GROSS_AMOUNT, to_number(to_char(voudate, 'yyyymmdd')), ADD4, ADDEPF,AUTHOEPF " +
                    " from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and (PRINT1 = 0 or PRINT1 is null) and VPDATE is not null";

                if (dm.existRecored(temp_cbSelect) != 0)
                {
                    dm.readSql(temp_cbSelect);
                    OracleDataReader temp_cbReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (temp_cbReader.Read())
                    {
                        if (!temp_cbReader.IsDBNull(0)) { HNAME = temp_cbReader.GetString(0); } else { HNAME = ""; }
                        if (!temp_cbReader.IsDBNull(1)) { HNAME1 = temp_cbReader.GetString(1); } else { HNAME1 = ""; }
                        if (!temp_cbReader.IsDBNull(3)) { ACNO = temp_cbReader.GetString(3); } else { ACNO = ""; }
                        if (!temp_cbReader.IsDBNull(4)) { voudatestr = temp_cbReader.GetString(4); } else { voudatestr = ""; }
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

                }
                else
                {
                    dm.oraConn.Dispose();
                    throw new Exception("No Printed Voucher Details Availbale!");
                }

                #endregion

                #region //--------------- voubankdet select ----------------------------------

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
                }
                this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;

                #endregion

                #region-------------Print Values in the form----------
                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", (share));
                if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);
                this.lblassuredname.Text = INSNAME;
                this.lblnameofpayee.Text = HNAME1.ToUpper();
                this.lblad1.Text = ADD1;
                this.lblad2.Text = ADD2;
                this.lblad3.Text = ADD3;
                this.lblad4.Text = ADD4;
                //this.lblAddepf.Text = addepf;
                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];
                this.lblacctno.Text = CUSTACCTNO;
                this.lbldate.Text = voudatestr;
                this.lblaccode.Text = accode.ToString();
                #endregion

                dm.connclose();
                //------------
                ViewState["share"] = share;
                ViewState["amtOut"] = amtOut;
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;
                ViewState["vouno"] = vouno;
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
                ViewState["EPF"] = EPF;
                ViewState["claimno"] = claimno;
                ViewState["voudate"] = voudate;
                ViewState["addepf"] = addepf;
                ViewState["authoepf"] = authoepf;
                ViewState["accode"] = accode;
                ViewState["signatureDisplay"] = signatureDisplay;
            }
            catch (Exception ex)
            {
                dm.oraConn.Dispose();
                EPage.Messege = ex.Message;
                Response.Redirect("../EPage.aspx");
            }
        }
        else
        {
            //polno = long.Parse(ViewState["polnoQstr"].ToString());
            //vouno = ViewState["vounoQstr"].ToString();
            //share = double.Parse(ViewState["shareQstr"].ToString());
            //claimno = long.Parse(ViewState["clmno"].ToString());

            if (ViewState["polno"] != null) { polno = int.Parse (ViewState["polno"].ToString()); }
            if (ViewState["vouno"] != null) { vouno = ViewState["vouno"].ToString(); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }
            if (ViewState["claimno"] != null) { claimno = int.Parse (ViewState["claimno"].ToString()); }
            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
            if (ViewState["share"] !=null) { share=double.Parse (ViewState["share"].ToString());}
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
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
            if (ViewState["voudate"] != null) { voudate = int.Parse (ViewState["voudate"].ToString()); }
            if (ViewState["addepf"] != null) { addepf = ViewState["addepf"].ToString(); }
            if (ViewState["authoepf"] != null) { authoepf = ViewState["authoepf"].ToString(); }
            if (ViewState["accode"] != null) { accode = int.Parse(ViewState["accode"].ToString()); }
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
        //Server.Transfer("~/voucher/vouPrintMain.aspx",true);
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
    public int Accode
    {
        get { return accode; }
        set { accode = value; }
    }

    public bool SignatureDisplay
    {
        get { return signatureDisplay; }
        set { signatureDisplay = value; }
    }
}
