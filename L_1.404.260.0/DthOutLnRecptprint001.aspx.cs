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

public partial class DthOutLnRecptprint001 : System.Web.UI.Page
{
    #region Define Variables
    private int polno;
    private string Ttype;
    private long LoanNum;
    private string rcptno;
    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private double LMNCP_LMCPY;
    private double LMIPY01;
    private int claimNo;
    DataManager dm;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (PreviousPage != null)
            {
                polno = PreviousPage.Polno;
                Ttype = "D";

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
                            if (!loanrecieptReprintRdr.IsDBNull(11)) { claimNo = loanrecieptReprintRdr.GetInt32(11); } else { claimNo = 0; }
                            if (!loanrecieptReprintRdr.IsDBNull(11)) { CLAIMAMT = loanrecieptReprintRdr.GetDouble(12); } else { CLAIMAMT = 0; }
                            if (!loanrecieptReprintRdr.IsDBNull(11)) { RECIEVEDAMT = loanrecieptReprintRdr.GetDouble(13); } else { RECIEVEDAMT = 0; }
                            if (!loanrecieptReprintRdr.IsDBNull(14)) { PRINT_EPF = loanrecieptReprintRdr.GetString(14); } else { PRINT_EPF = ""; }
                            if (!loanrecieptReprintRdr.IsDBNull(15)) { PRINT_TIME = loanrecieptReprintRdr.GetString(15); } else { PRINT_TIME = ""; }
                            if (!loanrecieptReprintRdr.IsDBNull(16)) { PRINT_IP = loanrecieptReprintRdr.GetString(16); } else { PRINT_IP = ""; }

                            #endregion
                        }
                        loanrecieptReprintRdr.Close();
                        loanrecieptReprintRdr.Dispose();

                        
                    }

                    #region ----------- lables -------------

                    this.lblbrn.Text = BRANCH.ToString();
                    this.Litrcptno.Text = rcptno;
                    this.litlnnum.Text = LoanNum.ToString();
                    this.litname.Text = phname;
                    this.litad1.Text = ad1;
                    this.litad2.Text = ad2;
                    this.litad3.Text = ad3;
                    this.litad4.Text = ad4;
                    this.litpolno.Text = polno.ToString();
                    this.litcptl.Text = String.Format("{0:N}", LMNCP_LMCPY);
                    this.litint.Text = String.Format("{0:N}", LMIPY01);
                    this.littotamt.Text = String.Format("{0:N}", CLAIMAMT);
                    this.litrcvdamt.Text = String.Format("{0:N}", RECIEVEDAMT);
                    this.litclmno.Text = claimNo.ToString();

                    double surrval100 = (Math.Round((LMIPY01 + LMNCP_LMCPY), 2) * 100);

                    if (surrval100 != 0)
                    {
                        string surrvalinwords = surrval100.ToString().Substring(0, (surrval100.ToString().Length - 2)) + "." + surrval100.ToString().Substring((surrval100.ToString().Length - 2), 2);
                        readAmountFunction readamt = new readAmountFunction();
                        this.litamtinword.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
                    }
                    else { this.litamtinword.Text = ""; }

                    if (PRINTDATE > 0)
                    {
                        this.litdate.Text = PRINTDATE.ToString().Substring(0, 4) + "/" + PRINTDATE.ToString().Substring(4, 2) + "/" + PRINTDATE.ToString().Substring(6, 2);
                        this.lblcurrdate.Text = PRINTDATE.ToString().Substring(0, 4) + "/" + PRINTDATE.ToString().Substring(4, 2) + "/" + PRINTDATE.ToString().Substring(6, 2);
                    }

                    this.lbltime.Text = PRINT_TIME;
                    this.lblepf.Text = PRINT_EPF;
                    this.lblipaddr.Text = PRINT_IP;

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

            

            //litpolno.Text = polno.ToString();
            //this.Litrcptno.Text = this.setDate()[0] + "/" + rcptno + "/DC";
            //this.litname.Text = phname;
            //this.litad1.Text = ad1;
            //this.litad2.Text = ad2;
            //this.litad3.Text = ad3;
            //this.litad4.Text = ad4;
            //this.litlnnum.Text = LoanNum.ToString();
            //this.litcptl.Text = String.Format("{0:N}", LMNCP_LMCPY);
            //this.litclmno.Text = claimNo.ToString();
            //this.litint.Text = String.Format("{0:N}", LMIPY01);
            //this.littotamt.Text = String.Format("{0:N}", (LMIPY01 + LMNCP_LMCPY));
            //this.litrcvdamt.Text = String.Format("{0:N}", (LMIPY01 + LMNCP_LMCPY));
            
            //double surrval100 = (Math.Round((LMIPY01 + LMNCP_LMCPY), 2) * 100);

            //if (surrval100 != 0)
            //{
            //    string surrvalinwords = surrval100.ToString().Substring(0, (surrval100.ToString().Length - 2)) + "." + surrval100.ToString().Substring((surrval100.ToString().Length - 2), 2);
            //    readAmountFunction readamt = new readAmountFunction();
            //    this.litamtinword.Text = readamt.readAmount(surrvalinwords, "SRI LANKAN RUPEES", "CENTS ");
            //}
            //else
            //{
            //    this.litamtinword.Text = "";
            //}
            //this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            //this.lblcurrdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            //this.lbltime.Text = this.setDate()[1];
            //this.lblepf.Text = Session["EPFNUM"].ToString();
            //this.lblipaddr.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();

        }
    }

    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;
    }

}
