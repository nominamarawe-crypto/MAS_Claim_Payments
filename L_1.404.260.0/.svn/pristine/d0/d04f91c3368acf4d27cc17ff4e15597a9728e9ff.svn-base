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

public partial class loanReciept : System.Web.UI.Page
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

    private int polno;
    private int LoanNum;
    private int rcptno;

    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private double LMNCP_LMCPY;
    private double LMIPY01;
    private long claimNo;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        string epf = "";
        int branch = 0;



        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            LoanNum = this.PreviousPage.LOANNUM;
            rcptno = this.PreviousPage.Rcptno;
            phname = this.PreviousPage.Phname;
            ad1 = this.PreviousPage.Ad1;
            ad2 = this.PreviousPage.Ad2;
            ad3 = this.PreviousPage.Ad3;
            ad4 = this.PreviousPage.Ad4;
            LMNCP_LMCPY = this.PreviousPage.LMNCP_LMCPYprop;
            LMIPY01 = this.PreviousPage.LMIPY01prop;
            claimNo = this.PreviousPage.ClaimNo;
        }
        dm = new DataManager();
        try
        {
            if (Session["EPFNum"] != null || Session["brcode"] != null)
            {
                epf = Session["EPFNum"].ToString();
                branch = Convert.ToInt32(Session["brcode"]);
            }
            else
            {
                throw new Exception("Your Session Variable Expired Please Log on to the System!");
            }

            if (LMNCP_LMCPY == 0 || LMIPY01 == 0)
            {
                string dthrefsel = "select DRLONCAP, DRLOANINT from LPHS.DTHREF where DRPOLNO="+polno+"";
                if (dm.existRecored(dthrefsel) != 0)
                {
                    dm.readSql(dthrefsel);
                    OracleDataReader dthrefread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefread.Read())
                    {
                        if (!dthrefread.IsDBNull(0)) { LMNCP_LMCPY = dthrefread.GetDouble(0); } else { LMNCP_LMCPY = 0; }
                        if (!dthrefread.IsDBNull(1)) { LMIPY01 = dthrefread.GetDouble(1); } else { LMIPY01 = 0; }
                    }
                    dthrefread.Close();
                    dthrefread.Dispose();
                }
            }

            string rcptnostr = "";
            if (rcptno < 10) {
                rcptnostr = "00000" + rcptno.ToString();
            }
            else if (rcptno >= 10 && rcptno < 100)
            {
                rcptnostr = "0000" + rcptno.ToString();
            }
            else if (rcptno >= 100 && rcptno < 1000)
            {
                rcptnostr = "000" + rcptno.ToString();
            }
            else 
            {
                rcptnostr = "00" + rcptno.ToString();
            }

            #region --------------- lables -------------
            this.lblclaimno.Text = claimNo.ToString();
            string wholeRecieptNo = this.setDate()[0] + "/" + rcptnostr + "/DC";
            this.lblrcptno.Text = this.setDate()[0] + "/" + rcptnostr + "/DC";
            this.lblloanno.Text = LoanNum.ToString();
            this.lblname.Text = phname;
            this.lblad1.Text = ad1;
            this.lblad2.Text = ad2;
            this.lblad3.Text = ad3;
            this.lblad4.Text = ad4;
            this.lblpolno.Text = polno.ToString();
            this.lblcapamt.Text = String.Format("{0:N}", LMNCP_LMCPY);
            this.lblintamt.Text = String.Format("{0:N}", LMIPY01);
            this.lblclaimAmt.Text = String.Format("{0:N}", (LMIPY01 + LMNCP_LMCPY));
            this.lblrecAmt.Text = String.Format("{0:N}", (LMIPY01 + LMNCP_LMCPY));

            double surrval100 = (Math.Round((LMIPY01 + LMNCP_LMCPY), 2) * 100);

            if (surrval100 != 0)
            {
                string surrvalinwords = surrval100.ToString().Substring(0, (surrval100.ToString().Length - 2)) + "." + surrval100.ToString().Substring((surrval100.ToString().Length - 2), 2);
                readAmountFunction readamt = new readAmountFunction();
                this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
            }
            else
            {
                this.lblamtinwords.Text = "";

            }
            this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            this.lblcurrdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            this.lbltime.Text = this.setDate()[1];
           // this.lblepf.Text = Session["EPFNUM"];
            this.lblipaddr.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();

            #endregion

            #region -------------- writting into loan reciept reprint table ----------

            string lnRecRepSel = "select polino from LPHS.LOAN_RCIEPT_REPRINT where polino = " + polno + " and loanno = " + LoanNum + " and type_of_settlmnt = 'S' ";
            if (dm.existRecored(lnRecRepSel) == 0)
            {
                string lnRecRepInsert = "INSERT INTO LPHS.LOAN_RCIEPT_REPRINT (POLINO ,LOANNO ,RECIEPTNO ,PRINTDATE ,BRANCH ,PAIDBY ,AD1 ,AD2 ,AD3 ,AD4 ,CAPITAL ,INTEREST ," +
                    "CLAIMNO ,CLAIMAMT ,RECIEVEDAMT ,TYPE_OF_SETTLMNT, PRINT_EPF, PRINT_TIME, PRINT_IP )" +
                    "VALUES (" + polno + " ," + LoanNum + " ,'" + wholeRecieptNo + "' ," + int.Parse(this.setDate()[0]) + " ," + branch + " ,'" + phname + "' ,'" + ad1 + "' ,'" + ad2 + "' ," +
                    "'" + ad3 + "' ,'" + ad4 + "' ," + LMNCP_LMCPY + " ," + LMIPY01 + " ," + claimNo + " ," + (LMIPY01 + LMNCP_LMCPY) + " ," + (LMIPY01 + LMNCP_LMCPY) + " ,'D'," +
                    "'" + epf + "', '" + this.setDate()[1] + "', '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "'  )";
                dm.insertRecords(lnRecRepInsert);
            }

            #endregion

            dm.connclose();
        }
        catch (Exception ex) 
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");        
        }
    }
}
