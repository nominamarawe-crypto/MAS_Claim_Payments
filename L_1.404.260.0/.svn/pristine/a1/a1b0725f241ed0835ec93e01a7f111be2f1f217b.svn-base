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

public partial class cvouReprint003 : System.Web.UI.Page
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
    private string INSNAME = "";
    private string RECIPIENT_NAME = "";
    private double TOTAMOUNT;
    private string BNKNAME = "";
    private string BNKBRNNAME = "";
    private string CUSTACCTNO = "";
    private string epf;
    //DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (!Page.IsPostBack)
        {
            try
            {
                //BNKNAME = ""; BNKBRNNAME = ""; CUSTACCTNO = "";
                //if (Session["epfnum"] != null) { epf = Session["epfnum"].ToString(); }
                //epf = Session["EPFNum"].ToString();

                if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
                {
                    #region --- getting ----
                    polno = this.PreviousPage.Polno;
                    MOS = this.PreviousPage.mos;
                    amtOut = this.PreviousPage.AmtOut;
                    claimno = this.PreviousPage.Claimno;

                    HNAME = this.PreviousPage.hNAME;
                    HNAME1 = this.PreviousPage.hNAME1;
                    ACNO = this.PreviousPage.aCNO;
                    ADD1 = this.PreviousPage.aDD1;
                    ADD2 = this.PreviousPage.aDD2;
                    ADD3 = this.PreviousPage.aDD3;
                    INSNAME = this.PreviousPage.iNSNAME;
                    RECIPIENT_NAME = this.PreviousPage.rECIPIENT_NAME;
                    TOTAMOUNT = this.PreviousPage.tOTAMOUNT;
                    BNKNAME = this.PreviousPage.bNKNAME;
                    BNKBRNNAME = this.PreviousPage.bNKBRNNAME;
                    CUSTACCTNO = this.PreviousPage.cUSTACCTNO;

                    vouno = this.PreviousPage.Vouno;
                    voudate = this.PreviousPage.Voudate;
                    share = this.PreviousPage.Share;
                    exgrShare = this.PreviousPage.ExgrShare;
                    #endregion
                }

                //dm = new DataManager();

                this.lblpolno.Text = polno.ToString();
                this.lblclaimno.Text = claimno.ToString();
                this.lblvouno.Text = vouno;
                this.lblamtinfigures.Text = String.Format("{0:N}", (share));
                if ((share - exgrShare) > 0) { this.lblclmAmt.Text = String.Format("{0:N}", (share - exgrShare)); }
                this.lblExgrAmt.Text = String.Format("{0:N}", exgrShare);

                if ((share + exgrShare) > 0)
                {
                    double share100 = (Math.Round((share + exgrShare), 2) * 100);

                    string surrvalinwords = share100.ToString().Substring(0, (share100.ToString().Length - 2)) + "." + share100.ToString().Substring((share100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                this.lblassuredname.Text = INSNAME;
                this.lblnameofpayee.Text = HNAME1;
                this.lblad1.Text = ADD1;
                this.lblad2.Text = ADD2;
                this.lblad3.Text = ADD3;
                if (voudate > 9999999)
                {
                    this.lbldate.Text = voudate.ToString().Substring(0, 4) + "/" + voudate.ToString().Substring(4, 2) + "/" + voudate.ToString().Substring(6, 2);
                }

                this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;
                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];
                this.lblacctno.Text = CUSTACCTNO;

            }
            catch (Exception ex) 
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx"); 
            }
        }
    }
}
