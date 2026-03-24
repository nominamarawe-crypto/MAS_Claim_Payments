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

public partial class UpdateChildProtPayments001 : System.Web.UI.Page
{
    public int polNo;
    public string mos;
    public int dueYM;
    public int dueDate;
    public bool isPeriodRecFound;
    public bool isCashbookRecFound;
    public bool isChildProtRecFound;
    public string claimNo;
    public string vouNo1;
    public string vouNo2;
    public double vouAmt;
    public string isFinalPayment;
    User_Authentication objUserAuthentication;
    
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));

            this.ddlFinalPaid.Items.Add(new ListItem("No", "N"));
            this.ddlFinalPaid.Items.Add(new ListItem("Yes", "Y"));

            try{
                //Change by Dulan Task 25215 - 2015-09-07 ********************************               
                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC05"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion

                //Change by Dulan Task 25215 - 2015-09-07 ********************************
               }
            catch (Exception Ex)
            { 

                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }

        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager(); 

            polNo = this.txtpolno.Text != null ? int.Parse(this.txtpolno.Text) : 0;
            mos = this.ddlMOS.SelectedValue;
            dueDate = this.txtFromDate.Text != null ? int.Parse(this.txtFromDate.Text) : 0;
            vouNo1 = this.txtVouNo1.Text != null ? this.txtVouNo1.Text : "";
            vouNo2 = this.txtVouNo2.Text != null ? this.txtVouNo2.Text : "";
            vouAmt = this.txtVouAmt.Text != null ? double.Parse(this.txtVouAmt.Text) : 0.0;
            isFinalPayment = this.ddlFinalPaid.SelectedValue;

            if (dueDate != 0)
            {
                dueYM = int.Parse(dueDate.ToString().Substring(0, 6));
            }

            string childProtSel = "select * " +
                                 "from LCLM.CHILDPROT_MANUALUPDATE a " +
                                 "where (A.VONO ='" + vouNo1 + "' or A.VONO ='" + vouNo2 + "')";

            if (dm.existRecored(childProtSel) != 0)
            {
                dm.readSql(childProtSel);
                OracleDataReader childProtReader = dm.oraComm.ExecuteReader();
                while (childProtReader.Read())
                { 
                    isChildProtRecFound = true;
                }
            }

            string periodicSel = "select A.POLNO, A.INTIMNO " +
                                 "from LCLM.PERIODIC_PAYDET a " +
                                 "where (A.VONO is null or A.VONO = 'XXXX') and A.LIFE_TYP='" + mos + "' and A.PAYMENT_DUE<=" + dueYM + " and A.POLNO=" + polNo + " order by A.VONO";

            if (dm.existRecored(periodicSel) != 0)
            {
                dm.readSql(periodicSel);
                OracleDataReader periodicReader = dm.oraComm.ExecuteReader();
                while (periodicReader.Read())
                {
                    if (!periodicReader.IsDBNull(1)) { claimNo = periodicReader.GetString(1); } else { claimNo = ""; }
                    isPeriodRecFound = true;
                }
            }

            //string cashbookSel = "select A.VOUNO, A.TOTAMOUNT " +
            //                     "from CASHBOOK.TEMP_CB a " +
            //                     "where (A.VOUNO = '" + vouNo1 + "' or A.VOUNO = '" + vouNo2 + "') and A.POLNO='" + polNo + "' and A.TOTAMOUNT=" + vouAmt + "";

            string cashbookSel = "select A.VOUNO, A.TOTAMOUNT " +
                                 "from CASHBOOK.TEMP_CB a " +
                                 "where (A.VOUNO = '" + vouNo1 + "' or A.VOUNO = '" + vouNo2 + "') and A.POLNO='" + polNo + "'";

            if (dm.existRecored(cashbookSel) != 0)
            {
                dm.readSql(cashbookSel);
                OracleDataReader cashbookReader = dm.oraComm.ExecuteReader();
                while (cashbookReader.Read())
                { 
                    isCashbookRecFound = true;
                }
            }

            dm.connclose();
            dm.oraConn.Dispose();
        }
        catch (Exception Ex)
        {
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }

        if (isPeriodRecFound && isCashbookRecFound && !isChildProtRecFound)
        {
            Response.Redirect("~/UpdateChildProtPayments002.aspx?polino=" + polNo + "&mos=" + mos + "&due_date=" + dueDate + "&dueym=" + dueYM + "&clmNo=" + claimNo + "&vono1=" + vouNo1 + "&vono2=" + vouNo2 + "&isfinalpay=" + isFinalPayment + "");
        }
        else if (isChildProtRecFound)
        {
            this.lblmessage.Text = "This Voucher Already Updated";
        }
        else if(!isPeriodRecFound)
        {
            this.lblmessage.Text = "Voucher Already Created or no such Dues";
        }
        else if (!isCashbookRecFound)
        {
            this.lblmessage.Text = "Check Voucher No. or Voucher Amount";
        }
    }
}
