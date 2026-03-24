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

public partial class cvouPrint003 : System.Web.UI.Page
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
    private string MOS;
    private double amtOut;
    private long claimno;

//    private string name = "";
    private string vouno = "";
    private int voudate;
    private double share;

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
    private double exgrShare;
    private int accode;
    private bool signatureDisplay;

    private string epf = "", addepf="", authoepf="";
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["EPFNum"] != null)
        //{
        //    //branch = Convert.ToInt32(Session["brcode"]);
        //    epf = Session["EPFNum"].ToString();
        //}
        //else
        //{
        //    throw new Exception("Your Session Variable Expired Please Log on to the System!");
        //}

        if (!Page.IsPostBack) 
        {
            try
            {
                if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
                {
                    #region ------- getting -------------
                    polno = this.PreviousPage.Polno;
                    //polno = this.PreviousPage.Polno;
                    MOS = this.PreviousPage.mos;
                    amtOut = this.PreviousPage.AmtOut;
                    claimno = this.PreviousPage.Claimno;
                    addepf = this.PreviousPage.Addepf;
                    HNAME = this.PreviousPage.hNAME;
                    HNAME1 = this.PreviousPage.hNAME1;
                    ACNO = this.PreviousPage.aCNO;
                    ADD1 = this.PreviousPage.aDD1;
                    ADD2 = this.PreviousPage.aDD2;
                    ADD3 = this.PreviousPage.aDD3;
                    ADD4 = this.PreviousPage.aDD4;
                    INSNAME = this.PreviousPage.iNSNAME;
                    RECIPIENT_NAME = this.PreviousPage.rECIPIENT_NAME;
                    TOTAMOUNT = this.PreviousPage.tOTAMOUNT;
                    BNKNAME = this.PreviousPage.bNKNAME;
                    BNKBRNNAME = this.PreviousPage.bNKBRNNAME;
                    CUSTACCTNO = this.PreviousPage.cUSTACCTNO;
                    exgrShare = this.PreviousPage.ExgrShare;

                    vouno = this.PreviousPage.Vouno;
                    voudate = this.PreviousPage.Voudate;
                    share = this.PreviousPage.Share;
                    accode = this.PreviousPage.Accode;
                    addepf = this.PreviousPage.Addepf;
                    authoepf = this.PreviousPage.Authoepf;
                    signatureDisplay = this.PreviousPage.SignatureDisplay;
                    #endregion
                }

                dm = new DataManager();

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", (share));
                if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round(share, 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                this.lblassuredname.Text = INSNAME.ToUpper();
                this.lblnameofpayee.Text = HNAME1.ToUpper(); ;
                this.lblad1.Text = ADD1.ToUpper();
                this.lblad2.Text = ADD2.ToUpper();
                this.lblad3.Text = ADD3.ToUpper();
                this.lblad4.Text = ADD4.ToUpper();
                //lblAddepf.Text = addepf.ToString();
                if (voudate > 9999999)
                {
                    this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                }

                this.lblbkbranch.Text = BNKNAME.ToUpper() + " " + BNKBRNNAME.ToUpper();
                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];
                this.lblacctno.Text = CUSTACCTNO;
                this.lblaccode.Text = "00" + accode.ToString();

                #region //-------------- updating TEMP_CB ---------------

                string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                string temp_cbSelect = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' and (PRINT1 = 0 or PRINT1 is null) and VPDATE is not null ";
                if (dm.existRecored(temp_cbSelect) != 0)
                {
                    string temp_cbUpdate = "UPDATE  cashbook.temp_cb set VPDATE = to_date('" + formattedToday + "', 'yyyy/mm/dd'), VPRINTEPF='" + epf + "' where Vouno ='" + vouno + "' ";
                    dm.insertRecords(temp_cbUpdate);
                }
                else
                {
                    dm.oraConn.Dispose();
                    throw new Exception("No Printed Voucher Details Availbale!");
                }

                #endregion
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
            catch (Exception ex) 
            {
                dm.oraConn.Dispose();
                EPage.Messege = ex.Message;
                Response.Redirect("../EPage.aspx");            
            }        
        }
    }
}
