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

    private long polno;
    private long surrenderno;
    private string LSUVNO = "";
    private string epf = "";
    private int lsuvdt;
    private int LSUSBR;
    private double LSUVAL;
    private long newLoanNum;

    private long LSULNO;
    private double LSULCA;
    private double LSULIN;

    private double LSUNET;
    private double LSUBON;

    private string HNAME = "";
    private string HNAME1 = "";
    private string ACNO = "";
    private string ADD1 = "";
    private string ADD2 = "";
    private string ADD3 = "";
    private string INSNAME = "";
    private double TOTAMOUNT;
    private string RECIPIENT_NAME = "";

    private string BNKNAME = "";
    private string BNKBRNNAME = "";
    private string CUSTACCTNO = "";

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["EPFNum"] != null)
        {
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
                    LSUVNO = this.PreviousPage.lSUVNO;
                    LSUSBR = this.PreviousPage.lSUSBR;
                    LSUVAL = this.PreviousPage.lSUVAL;
                    newLoanNum = this.PreviousPage.NewLoanNum;

                    LSUNET = this.PreviousPage.lSUNET;
                    LSUBON = this.PreviousPage.lSUBON;

                    HNAME = this.PreviousPage.hNAME;
                    HNAME1 = this.PreviousPage.hNAME1;
                    ACNO = this.PreviousPage.aCNO;
                    ADD1 = this.PreviousPage.aDD1;
                    ADD2 = this.PreviousPage.aDD2;
                    ADD3 = this.PreviousPage.aDD3;
                    INSNAME = this.PreviousPage.iNSNAME;
                    TOTAMOUNT = this.PreviousPage.tOTAMOUNT;
                    RECIPIENT_NAME = this.PreviousPage.rECIPIENT_NAME;
                    lsuvdt = this.PreviousPage.Lsuvdt;

                    BNKNAME = this.PreviousPage.bNKNAME;
                    BNKBRNNAME = this.PreviousPage.bNKBRNNAME;
                    CUSTACCTNO = this.PreviousPage.cUSTACCTNO;

                    LSULNO = this.PreviousPage.lSULNO;
                    LSULCA = this.PreviousPage.lSULCA;
                    LSULIN = this.PreviousPage.lSULIN;
                    surrenderno = this.PreviousPage.Surrenderno;
                    #endregion
                }

                dm = new DataManager();

                this.lblpolno.Text = polno.ToString();

                this.lblvouno.Text = LSUVNO;
                this.lbldate.Text = lsuvdt.ToString().Substring(0, 4) + "/" + lsuvdt.ToString().Substring(4, 2) + "/" + lsuvdt.ToString().Substring(6, 2);
                this.lblfullbons.Text = String.Format("{0:N}", LSUBON);
                this.lblloanval.Text = String.Format("{0:N}", LSUVAL);
                this.lblamtinfigures.Text = String.Format("{0:N}", TOTAMOUNT);
                if (TOTAMOUNT > 0)
                {
                    double LSUNET100 = (Math.Round(TOTAMOUNT, 2) * 100);

                    string surrvalinwords = LSUNET100.ToString().Substring(0, (LSUNET100.ToString().Length - 2)) + "." + LSUNET100.ToString().Substring((LSUNET100.ToString().Length - 2), 2);
                    readAmountFunction readamt = new readAmountFunction();
                    this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                }
                else { this.lblamtinwords.Text = ""; }

                this.lblloanno.Text = newLoanNum.ToString();

                //this.lblbkbranch.Text = HNAME;
                this.lblloanno.Text = surrenderno.ToString();
                this.lblacctno.Text = CUSTACCTNO;
                this.lblassuredname.Text = INSNAME;
                this.lblnameofpayee.Text = HNAME1;
                this.lblad1.Text = ADD1;
                this.lblad2.Text = ADD2;
                this.lblad3.Text = ADD3;
                this.lblbkbranch.Text = BNKNAME + " " + BNKBRNNAME;

                this.lblcurrentdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime.Text = this.setDate()[1];
                this.lblcurrentdate2.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblcurrenttime2.Text = this.setDate()[1];
                this.lblipaddr.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                this.lblepf.Text = epf.ToString();

                if (LSULNO > 0)
                {
                    this.Label1.Visible = true;
                    this.Label2.Visible = true;
                    this.Label3.Visible = true;
                    this.lbloldloanNo.Visible = true;
                    this.lbloldLoanCapital.Visible = true;
                    this.lbloldLoanInterest.Visible = true;

                    this.lbloldloanNo.Text = ": " + LSULNO.ToString();
                    this.lbloldLoanCapital.Text = ": " + String.Format("{0:N}", LSULCA);
                    this.lbloldLoanInterest.Text = ": " + String.Format("{0:N}", LSULIN);
                }
                else
                {
                    this.Label1.Visible = false;
                    this.Label2.Visible = false;
                    this.Label3.Visible = false;
                    this.lbloldloanNo.Visible = false;
                    this.lbloldLoanCapital.Visible = false;
                    this.lbloldLoanInterest.Visible = false;
                }

            }
            catch (Exception ex) 
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx"); 
            }
        }
    }
}
