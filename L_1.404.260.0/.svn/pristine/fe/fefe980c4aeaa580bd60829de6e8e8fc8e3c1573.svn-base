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
using System.Collections.Generic;

public partial class UpdateChildProtPayments002 : System.Web.UI.Page
{
    public int polNo;
    public string mos;
    public int dueDate;
    public int dueYM;
    public string claimNo;
    public string vouNo1;
    public string vouNo2;
    public double paidAmount;
    public string clmType;
    public double dueAmount;
    public string isFinalPayment;
    public string epf;
    public string ipAdd; 

    DataManager dm = null;
    Childprotpay childProt = null;
    List<Childprotpay> manVouList = null;
    List<Childprotpay> manDueList = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        childProt = new Childprotpay();
        manVouList = new List<Childprotpay>();
        manDueList = new List<Childprotpay>();

        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
            ipAdd = Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        if (!Page.IsPostBack)
        {
            try
            {

                if (Request.QueryString["polino"] != null)
                {
                    ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polino"]));
                    polNo = int.Parse(Request.QueryString["polino"]);
                }
                if (Request.QueryString["mos"] != null)
                {
                    ViewState.Add("mosQstr", Request.QueryString["mos"].ToString());
                    mos = Request.QueryString["mos"].ToString();
                }
                if (Request.QueryString["due_date"] != null)
                {
                    ViewState.Add("due_dateQstr", int.Parse(Request.QueryString["due_date"]));
                    dueDate = int.Parse(Request.QueryString["due_date"]);
                }
                if (Request.QueryString["dueym"] != null)
                {
                    ViewState.Add("dueymQstr", int.Parse(Request.QueryString["dueym"]));
                    dueYM = int.Parse(Request.QueryString["dueym"]);
                }
                if (Request.QueryString["clmNo"] != null)
                {
                    ViewState.Add("clmNoQstr", Request.QueryString["clmNo"].ToString());
                    claimNo = Request.QueryString["clmNo"].ToString();
                }
                if (Request.QueryString["vono1"] != null)
                {
                    ViewState.Add("vonoQstr1", Request.QueryString["vono1"].ToString());
                    vouNo1 = Request.QueryString["vono1"];
                }
                if (Request.QueryString["vono2"] != null)
                {
                    ViewState.Add("vonoQstr2", Request.QueryString["vono2"].ToString());
                    vouNo2 = Request.QueryString["vono2"];
                }
                if (Request.QueryString["isfinalpay"] != null)
                {
                    ViewState.Add("isfinalpayQstr", Request.QueryString["isfinalpay"].ToString());
                    isFinalPayment = Request.QueryString["isfinalpay"].ToString();
                }

                this.lblpolno.Text = polNo.ToString();

                manVouList = childProt.FetchManualPaidVouchers(vouNo1, vouNo2);
                manDueList = childProt.FetchManualPaidDues(polNo, dueYM, mos);

                if (manVouList.Count > 0)
                {
                    gvManualVouchers.DataSource = manVouList;
                    gvManualVouchers.DataBind(); 

                    this.lblclmno.Text = manVouList[0].ClaimNo;
                }

                if (isFinalPayment == "Y")
                {
                    double tmpTot = 0.0;
                    paidAmount = manVouList[0].PaidAmount; 

                    for (int i = 0; i < manDueList.Count; i++)
                    {
                        if (i == manDueList.Count - 1)
                        {
                            manDueList[i].DueAmount = paidAmount - tmpTot;
                        }
                        tmpTot += manDueList[i].DueAmount;
                    }
                }

                ViewState["manVouList"] = manVouList;
                ViewState["manDueList"] = manDueList;

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
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polNo = (int)ViewState["polnoQstr"]; }
            if (ViewState["mosQstr"] != null) { mos = (string)ViewState["mosQstr"]; }
            if (ViewState["due_dateQstr"] != null) { dueDate = (int)ViewState["due_dateQstr"]; }
            if (ViewState["dueymQstr"] != null) { dueYM = (int)ViewState["dueymQstr"]; }
            if (ViewState["clmNoQstr"] != null) { claimNo = (string)ViewState["clmNoQstr"]; }
            if (ViewState["manVouList"] != null) { manVouList = (List<Childprotpay>)ViewState["manVouList"]; }
            if (ViewState["manDueList"] != null) { manDueList = (List<Childprotpay>)ViewState["manDueList"]; }
        }
    }

    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        int rowindex = ((GridViewRow)((Control)sender).Parent.Parent).DataItemIndex;

        for (int i = 0; i < gvManualVouchers.Rows.Count; i++)
        {
            if (i == rowindex)
            {
                ((CheckBox)gvManualVouchers.Rows[i].FindControl("chkSelect")).Enabled = true;

                if (((CheckBox)gvManualVouchers.Rows[rowindex].FindControl("chkSelect")).Checked)
                {
                    pnlPaidDue.Visible = true;

                    if (manDueList.Count > 0)
                    {
                        gvPaidDues.DataSource = manDueList;
                        gvPaidDues.DataBind();
                    }
                }
                else
                {
                    pnlPaidDue.Visible = false;
                }
            }
            else
            {
                if (((CheckBox)gvManualVouchers.Rows[rowindex].FindControl("chkSelect")).Checked)
                {
                    //((CheckBox)gvManualVouchers.Rows[i].FindControl("chkSelect")).Enabled = false;
                    pnlPaidDue.Visible = true;

                    if (manDueList.Count > 0)
                    {
                        gvPaidDues.DataSource = manDueList;
                        gvPaidDues.DataBind();
                    }
                }
                else
                {
                    ((CheckBox)gvManualVouchers.Rows[i].FindControl("chkSelect")).Enabled = true;
                    pnlPaidDue.Visible = false;
                }
            }
        }  
    }

    protected void chkSelectDue_CheckedChanged(object sender, EventArgs e)
    {
        int recCount = 0;
        for (int i = 0; i < gvPaidDues.Rows.Count; i++)
        {
            if (recCount == 0)
            {
                if (((CheckBox)gvPaidDues.Rows[i].FindControl("chkSelect")).Checked)
                {
                    pnlButton.Visible = true;
                    recCount++;
                }
                else
                {
                    pnlButton.Visible = false;
                }
            }            
        } 
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            dm.begintransaction();
            double duesTotal = 0.0;
            double vouchersTotal = 0.0;
            int count = 0;

            for (int i = 0; i < gvManualVouchers.Rows.Count; i++)
            {
                if (((CheckBox)gvManualVouchers.Rows[i].FindControl("chkSelect")).Checked)
                {
                    vouNo1 = ((Label)gvManualVouchers.Rows[i].FindControl("lblVouNo")).Text;
                    polNo = Convert.ToInt32(((Label)gvManualVouchers.Rows[i].FindControl("lblPolNo")).Text);
                    claimNo = ((Label)gvManualVouchers.Rows[i].FindControl("lblClmNo")).Text;
                    paidAmount = Convert.ToDouble(((Label)gvManualVouchers.Rows[i].FindControl("lblPaidAmt")).Text);

                    for (int j = 0; j < gvPaidDues.Rows.Count; j++)
                    {
                        if (((CheckBox)gvPaidDues.Rows[j].FindControl("chkSelect")).Checked)
                        {
                            dueYM = Convert.ToInt32(((Label)gvPaidDues.Rows[j].FindControl("lblPaymentDue")).Text);
                            clmType = ((HiddenField)gvPaidDues.Rows[j].FindControl("hdnClmTyp")).Value;
                            dueAmount = Convert.ToDouble(((HiddenField)gvPaidDues.Rows[j].FindControl("hdnDueAmt")).Value);
                             
                            if (count == 0)
                            {
                                string periobonupd = "update LCLM.PERIODIC_PAYDET set VONO='" + vouNo1 + "' where POLNO=" + polNo + " and CLMTYPE='" + clmType + "' and PAYMENT_DUE=" + dueYM + "";
                                dm.insertRecords(periobonupd);

                                string childprotSel = "select * from LCLM.CHILDPROT_MANUALUPDATE where POLICY_NO=" + polNo + " and PAYMENT_DUE=" + dueYM + "";

                                if (dm.existRecored(childprotSel) == 0)
                                {
                                    string childprotinsert = "insert into LCLM.CHILDPROT_MANUALUPDATE(POLICY_NO, CLAIM_NO, CLMTYPE, LIFE_TYP, PAYMENT_DUE, VONO, PAID_AMT, ENTRY_EPF,ENTRY_IP) values(" + polNo + ",'" + claimNo + "', '" + clmType + "','M', " + dueYM + ", '" + vouNo1 + "'," + dueAmount + ",'" + epf + "','" + ipAdd + "' )";
                                    dm.insertRecords(childprotinsert);
                                }
                                duesTotal += dueAmount;
                            }                            
                        } 
                    }
                    vouchersTotal += paidAmount;
                    count++;
                }
            }

            //if (duesTotal != vouchersTotal)
            //{
            //    throw new Exception("Selected Due/Dues amount not tally with the voucher amount! Please check selected Due/Dues.");
            //    //this.lblMessage1.Text = "Selected Due/Dues amount not tally with the voucher amount! Please check selected Due/Dues.";
            //    //return;
            //}

            this.lblmessage.Text = "Successfully updated!";
            this.btnUpdate.Enabled = false;

            dm.commit();
            dm.connClose(); 
        }
        catch (Exception Ex)
        {            
            dm.rollback();
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateChildProtPayments001.aspx");
    }
}
