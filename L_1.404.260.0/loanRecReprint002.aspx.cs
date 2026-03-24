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

public partial class loanRecReprint002 : System.Web.UI.Page
{
    private int polno;
    private long LoanNum;
    private string rcptno;

    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private double LMNCP_LMCPY;
    private double LMIPY01;
    private string ttype;
    private int surrenderNo;

    DataManager dm;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            ttype = this.PreviousPage.Ttype;
        }
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
             

                string PRINT_EPF = ""; string PRINT_TIME = ""; string PRINT_IP = "";
                int PRINTDATE = 0; int BRANCH = 0;
                double CLAIMAMT = 0; double RECIEVEDAMT = 0;

                string loanrecieptReprintSel = "select LOANNO, RECIEPTNO, PRINTDATE, BRANCH, PAIDBY, AD1, AD2," +
                    " AD3, AD4, CAPITAL, INTEREST, CLAIMNO, CLAIMAMT, RECIEVEDAMT, PRINT_EPF, PRINT_TIME, PRINT_IP " +
                    " from LPHS.LOAN_RCIEPT_REPRINT where POLINO = " + polno + " and TYPE_OF_SETTLMNT = 'D' ";
                if (dm.existRecored(loanrecieptReprintSel) != 0)
                {
                    dm.readSql(loanrecieptReprintSel);
                    OracleDataReader loanrecieptReprintRdr = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (loanrecieptReprintRdr.Read())
                    {
                        #region -------------- get val --------------------

                        if (!loanrecieptReprintRdr.IsDBNull(0)) { LoanNum = loanrecieptReprintRdr.GetInt64(0); } else { LoanNum = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(1)) { rcptno = loanrecieptReprintRdr.GetString(1); } else { rcptno = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(2)) { PRINTDATE = loanrecieptReprintRdr.GetInt32(2); } else { PRINTDATE = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(3)) { BRANCH = loanrecieptReprintRdr.GetInt32(3); } else { BRANCH = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(4)) { phname = loanrecieptReprintRdr.GetString(4); } else { phname = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(5)) { ad1 = loanrecieptReprintRdr.GetString(5); } else { ad1 = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(6)) { ad2 = loanrecieptReprintRdr.GetString(6); } else { ad2 = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(7)) { ad3 = loanrecieptReprintRdr.GetString(7); } else { ad3 = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(8)) { ad4 = loanrecieptReprintRdr.GetString(8); } else { ad4 = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(9)) { LMNCP_LMCPY = loanrecieptReprintRdr.GetDouble(9); } else { LMNCP_LMCPY = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(10)) { LMIPY01 = loanrecieptReprintRdr.GetDouble(10); } else { LMIPY01 = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(11)) { surrenderNo = loanrecieptReprintRdr.GetInt32(11); } else { surrenderNo = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(11)) { CLAIMAMT = loanrecieptReprintRdr.GetDouble(12); } else { CLAIMAMT = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(11)) { RECIEVEDAMT = loanrecieptReprintRdr.GetDouble(13); } else { RECIEVEDAMT = 0; }
                        if (!loanrecieptReprintRdr.IsDBNull(14)) { PRINT_EPF = loanrecieptReprintRdr.GetString(14); } else { PRINT_EPF = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(15)) { PRINT_TIME = loanrecieptReprintRdr.GetString(15); } else { PRINT_TIME = ""; }
                        if (!loanrecieptReprintRdr.IsDBNull(16)) { PRINT_IP = loanrecieptReprintRdr.GetString(16); } else { PRINT_IP = ""; }

                        #endregion
                    }
                    loanrecieptReprintRdr.Close();
                    loanrecieptReprintRdr.Dispose();

                    #region ----------- lables -------------

                    this.lblbrn.Text = BRANCH.ToString();
                    this.lblrcptno.Text = rcptno;
                    this.lblloanno.Text = LoanNum.ToString();
                    this.lblname.Text = phname;
                    this.lblad1.Text = ad1;
                    this.lblad2.Text = ad2;
                    this.lblad3.Text = ad3;
                    this.lblad4.Text = ad4;
                    this.lblpolno.Text = polno.ToString();
                    this.lblcapamt.Text = String.Format("{0:N}", LMNCP_LMCPY);
                    this.lblintamt.Text = String.Format("{0:N}", LMIPY01);
                    this.lblclaimAmt.Text = String.Format("{0:N}", CLAIMAMT);
                    this.lblrecAmt.Text = String.Format("{0:N}", RECIEVEDAMT);
                    this.lblclaimno.Text = surrenderNo.ToString();

                    double surrval100 = (Math.Round((LMIPY01 + LMNCP_LMCPY), 2) * 100);

                    if (surrval100 != 0)
                    {
                        string surrvalinwords = surrval100.ToString().Substring(0, (surrval100.ToString().Length - 2)) + "." + surrval100.ToString().Substring((surrval100.ToString().Length - 2), 2);
                        readAmountFunction readamt = new readAmountFunction();
                        this.lblamtinwords.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                    }
                    else { this.lblamtinwords.Text = ""; }

                    if (PRINTDATE > 0)
                    {
                        this.lbldate.Text = PRINTDATE.ToString().Substring(0, 4) + "/" + PRINTDATE.ToString().Substring(4, 2) + "/" + PRINTDATE.ToString().Substring(6, 2);
                        this.lblcurrdate.Text = PRINTDATE.ToString().Substring(0, 4) + "/" + PRINTDATE.ToString().Substring(4, 2) + "/" + PRINTDATE.ToString().Substring(6, 2);
                    }

                    this.lbltime.Text = PRINT_TIME;
                    this.lblepf.Text = PRINT_EPF;
                    this.lblipaddr.Text = PRINT_IP;

                    #endregion
                }


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
}
