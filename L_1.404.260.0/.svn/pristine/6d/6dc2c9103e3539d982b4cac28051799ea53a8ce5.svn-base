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

public partial class RepudiatePay004 : System.Web.UI.Page
{
    private long polno;
    private int claimno;
    private int com;
    private int dtofdth;
//    private string mos;
    private int table;
    private int term;
    private string polstatus;
    private string polstatStr;
    private double exgracia;
    private double clmamt;
    private double bonus;
    private double otheradds;
    private double defprem;
    private double defpremint;
    private double loan;
    private double loanint;
    private double amtcompolyr;
    private double otherdeduct;
    private double netclm;
    private double deposit;
    private string isFuturePayment;
    private string mos;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            #region-----------------------get values-------------------------
            polno = PreviousPage.Polno;
            claimno = PreviousPage.Claimno;
            com = PreviousPage.Com;
            dtofdth = PreviousPage.Dtofdth;
            table = PreviousPage.Table;
            term = PreviousPage.Term;
            polstatus = PreviousPage.Polstatus;
            exgracia = PreviousPage.Exgracia;
            clmamt = PreviousPage.Clmamt;
            bonus = PreviousPage.Bonus;
            otheradds = PreviousPage.Otheradds;
            defprem = PreviousPage.Defprem;
            defpremint = PreviousPage.Defpremint;
            loan = PreviousPage.Loan;
            loanint = PreviousPage.Loanint;
            amtcompolyr = PreviousPage.Amtpolcomyr;
            otherdeduct = PreviousPage.Otherdeduct;
            netclm = PreviousPage.Netclm;
            deposit = PreviousPage.Deposit;
            polstatus = PreviousPage.Polstatus;
            isFuturePayment = PreviousPage.IsFuturePayment;
            mos = PreviousPage.Mos;
            #endregion
        }
        if (polstatus.Equals("I")) { polstatStr = "Inforce"; }
        else if (polstatus.Equals("L")) { polstatStr = "Lapse"; }
        if (exgracia > 0) { lblHeading.Text = "Exgracia Payment for Repudiated Death Claims"; }
        else { lblHeading.Text = "Deposit Refund for Repudiated Death Claims"; }
        /*
        #region------------------Set values in the form--------------------
        if (exgracia > 0) { lblHeading.Text = "Exgracia Payment for Repudiated Death Claims"; }
        else { lblHeading.Text = "Deposit Refund for Repudiated Death Claims"; }
        this.lblpolno.Text = polno.ToString();
        this.lblclmno.Text = claimno.ToString();
        this.lbltab.Text = table.ToString();
        this.lblterm.Text = term.ToString();
        if (polstatus.Equals("I")) { polstatStr = "Inforce"; }
        else if (polstatus.Equals("L")) { polstatStr = "Lapse"; }
        this.lblpolstat.Text = polstatStr;
        this.lblCom.Text = com.ToString().Substring(0, 4) + "/" + com.ToString().Substring(4, 2) + "/" + com.ToString().Substring(6, 2);
        this.lbldtofdth.Text = dtofdth.ToString().Substring(0, 4) + "/" + dtofdth.ToString().Substring(4, 2) + "/" + dtofdth.ToString().Substring(6, 2); ;
        this.lblExclaim.Text = String.Format("{0:N}", exgracia);
        this.lblClaim.Text = String.Format("{0:N}", clmamt);
        this.lblBonus.Text = String.Format("{0:N}", bonus);
        this.lblOtheradds.Text = String.Format("{0:N}", otheradds);
        this.lblDefprem.Text = String.Format("{0:N}", defprem);
        this.lblPremint.Text = String.Format("{0:N}", defpremint);
        this.lblLoancap.Text = String.Format("{0:N}", loan);
        this.lblLoanint.Text = String.Format("{0:N}", loanint);
        this.lblComplyr.Text = String.Format("{0:N}", amtcompolyr);
        this.lblOtherdeduct.Text = String.Format("{0:N}", otherdeduct);
        this.lblDeposit.Text = String.Format("{0:N}", deposit);
        #endregion
        */
        #region------------------Set values in the form--------------------
        this.lblpolno.Text = polno.ToString();
        this.lblclmno.Text = claimno.ToString();
        this.lbltab.Text = table.ToString();
        this.lblterm.Text = term.ToString();
        this.lblpolstat.Text = polstatStr;
        this.lblCom.Text = com.ToString().Substring(0, 4) + "/" + com.ToString().Substring(4, 2) + "/" + com.ToString().Substring(6, 2);
        this.lbldtofdth.Text = dtofdth.ToString().Substring(0, 4) + "/" + dtofdth.ToString().Substring(4, 2) + "/" + dtofdth.ToString().Substring(6, 2); ;
        this.lblExclaim.Text = String.Format("{0:N}", exgracia);
        this.lblClaim.Text = String.Format("{0:N}", clmamt);
        this.lblBonus.Text = String.Format("{0:N}", bonus);
        this.lblOtheradds.Text = String.Format("{0:N}", otheradds);
        this.lblDefprem.Text = String.Format("{0:N}", defprem);
        this.lblPremint.Text = String.Format("{0:N}", defpremint);
        this.lblLoancap.Text = String.Format("{0:N}", loan);
        this.lblLoanint.Text = String.Format("{0:N}", loanint);
        this.lblComplyr.Text = String.Format("{0:N}", amtcompolyr);
        this.lblOtherdeduct.Text = String.Format("{0:N}", otherdeduct);
        this.lblTotal.Text = String.Format("{0:N}", netclm);
        this.lblDeposit.Text = String.Format("{0:N}", deposit);

        if (isFuturePayment == "N")
        {
            this.lblFuturePayment.Text = "No";
        }
        else
        {
            this.lblFuturePayment.Text = "Yes";
        }
        #endregion
    }

    public int Table
    {
        get { return table; }
        set { table = value; }
    }
    public string Mos
    {
        get { return mos; }
        set { mos = value; }
    }
}
