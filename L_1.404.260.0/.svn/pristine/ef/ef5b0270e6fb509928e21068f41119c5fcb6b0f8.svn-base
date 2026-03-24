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
using Org.BouncyCastle.Bcpg;
using System.Drawing;
using Org.BouncyCastle.Bcpg.OpenPgp;

public partial class SlicvouEdit001 : System.Web.UI.Page
{
    private ArrayList vouIndexes;
    private ArrayList arrListNom;
    private ArrayList arrListLHI;
    private string[] ASIarr;
    private string[] LPTarr;

    private string payee;
    private string payname;

    //private int count;
    private int NOMNUM;
    private int LHNUM;
    
    private double shareamt;
    
    private string EPF;
    private string MOS;
    private int Branch;
    private long claimno;
    private string accountno;
    private string hname;
    private string insname;
    private int slivoutyp = 0;

    private string accode;
    private string vouno;
    private string pname;
    private string reason;
    private string completed;
    private double amtOut;
    private double totamount;
    private double amtout;
    private int polno;
    private double vouTot;


    DataManager dm;
    CompanyVouFields cvf;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null || Session["brcode"] != null)
        {
            //EPF = Session["EPFNum"].ToString();
            Branch = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            Response.Redirect("SessionError.aspx", false);
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                vouno = Request.QueryString["vouno"].ToString();

                GetData();
                ChechAmount();
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
            }
        else
        {
            
            
        }
       

    }

    private void GetData()
    {
        try
        {
            string querystring = "select * from  CASHBOOK.TEMP_CB where vouno= '" + vouno + "' and (authorized =1 or deleted = 1)";
            if (dm.existRecored(querystring) == 0)
            {
                string getstring = "SELECT AQ.SVPAYEENAM, AQ.SVREASON, AQ.SVAMT,  BQ.ACNO FROM LPHS.SLICVOUCHERS  AQ INNER JOIN CASHBOOK.TEMP_CB  BQ ON AQ.SVVOUNO = BQ.VOUNO WHERE AQ.SVVOUNO = '" + vouno + "'";
                if (dm.existRecored(getstring) != 0)
                {
                    double TAmount = 0;
                    dm.readSql(getstring);
                    OracleDataReader periodicreader = dm.oraComm.ExecuteReader();
                    while (periodicreader.Read())
                    {
                        if (!periodicreader.IsDBNull(0)) { pname = periodicreader.GetString(0); } else { pname = ""; }
                        if (!periodicreader.IsDBNull(1)) { reason = periodicreader.GetString(1); } else { reason = ""; }
                        if (!periodicreader.IsDBNull(2)) { TAmount = periodicreader.GetDouble(2); } else { TAmount = 0; }
                        if (!periodicreader.IsDBNull(3)) { accode = periodicreader.GetString(3); } else { accode = ""; }
                    }
                    txtPayer.Text = pname;
                    txtAmount.Text = Convert.ToString(TAmount);
                    txtReason.Text = reason;
                    LisAccNo.SelectedValue = accode;
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "No voucher Found!";
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Voucher Authorized or Deleted!";
            }



        }
        catch (Exception Ex)
        {
            //dm.connclose();
            throw Ex;
        }
    }



    protected void ChechAmount()
    {
        dm = new DataManager();
        vouno = Request.QueryString["vouno"].ToString();

        string vouPolicy = "select SVPOL from LPHS.SLICVOUCHERS where svvouno = '" + vouno + "'";
        if (dm.existRecored(vouPolicy) != 0)
        {
            long polValue = 0; 
            dm.readSql(vouPolicy);
            OracleDataReader Vpoli = dm.oraComm.ExecuteReader();
            while (Vpoli.Read())
            {
                if (!Vpoli.IsDBNull(0)) { polValue = Vpoli.GetInt64(0); } else { polValue = 0; }
            }
            polno = Convert.ToInt32(polValue);


            dm = new DataManager();
            string dthrefSel = "select  DRNETCLM, AMTOUT, completed from lphs.dthref where DRPOLNO = " + polno + "";
            if (dm.existRecored(dthrefSel) != 0)
            {
                dm.readSql(dthrefSel);
                OracleDataReader drefrd = dm.oraComm.ExecuteReader();
                while (drefrd.Read())
                {
                    if (!drefrd.IsDBNull(0)) { totamount = drefrd.GetDouble(0); } else { totamount = 0; } //total claim amountt
                    if (!drefrd.IsDBNull(1)) { amtOut = drefrd.GetDouble(1); } else { amtOut = 0; }
                    if (!drefrd.IsDBNull(2)) { completed = drefrd.GetString(2); } else { completed = ""; }
                }
            }


            string totVOuAmt = "select totamount from  CASHBOOK.TEMP_CB where polno= '" + polno + "' and  vouno!= '" + vouno + "' and (deleted!= 1)";
            if (dm.existRecored(totVOuAmt) != 0)
            {
                dm.readSql(totVOuAmt);
                OracleDataReader drefrd = dm.oraComm.ExecuteReader();
                while (drefrd.Read())
                {
                    if (!drefrd.IsDBNull(0)) { vouTot = drefrd.GetDouble(0); } else { vouTot = 0; }  //get total amount of already created vouchers
                }
            }



        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Record not found!!";
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;

        ChechAmount();
        Double TotalClaimAmount = totamount;
        Double TotalvoucersAmount = vouTot;

        string NAmmount = txtAmount.Text;
        string NReason = txtReason.Text;
        string NAccNo = LisAccNo.SelectedValue;
        vouno = Request.QueryString["vouno"].ToString();

        double voucherMount = Convert.ToDouble(NAmmount);

        NumberSeparate ns = new NumberSeparate(NReason);
        string propno = "";

        if (ns.Number != null)
        {
            propno = " PROP. NO: " + ns.Number.ToString();
        }

        hname = "SRI LANKA INSURANCE CORPORATION LIFE LTD.";

        string Rea = hname + propno;

            if (voucherMount > TotalClaimAmount)
            {
            
                Label1.Visible = true;
                Label1.Text = "Amount larger than the total claim amount!";
            }
            else
            {
                if (voucherMount > (TotalClaimAmount - TotalvoucersAmount))
                {
                    
                    Label1.Visible = true;
                    Label1.Text = "Amount too larger to create a voucher!";
                }
                else
                {
                    dm = new DataManager();
                    dm.begintransaction();
                    try
                    {
                        bool flag1 = false;
                        bool flag2 = false;
                        bool flag3 = false;

                        string stringcashbooktemp = "select * from  CASHBOOK.TEMP_CB where vouno= '" + vouno + "'";
                        if (dm.existRecored(stringcashbooktemp) != 0)
                        {
                            string cashbooktempUpdate = "update CASHBOOK.TEMP_CB set TOTAMOUNT = '" + NAmmount + "',  TOTAMT = '" + String.Format("{0:N}", NAmmount) + "' , ACNO = '" + NAccNo + "' ,GROSS_AMOUNT = '" + NAmmount + "',HNAME = '" + Rea + "'  where vouno= '" + vouno + "'";
                            dm.insertRecords(cashbooktempUpdate);
                            flag1 = true;
                        }

                        string stringslicvouchers = "select * from LPHS.SLICVOUCHERS where svvouno= '" + vouno + "'";
                        if (dm.existRecored(stringslicvouchers) != 0)
                        {
                            string slicvouchersUpdate = "update LPHS.SLICVOUCHERS set SVREASON = '" + NReason + "',  SVAMT = '" + NAmmount + "' where svvouno = '" + vouno + "'";
                            dm.insertRecords(slicvouchersUpdate);
                            flag2 = true;
                        }

                        string stringcashbooktempdetl = "select * from CASHBOOK.TEMP_DETL where vouno= '" + vouno + "'";
                        if (dm.existRecored(stringcashbooktempdetl) != 0)
                        {
                            string cashbooktempdetlUpdate = "update CASHBOOK.TEMP_DETL set AMOUNT = '" + NAmmount + "',  TOTAL = '" + NAmmount + "' where vouno = '" + vouno + "'";
                            dm.insertRecords(cashbooktempdetlUpdate);

                            flag3 = true;
                        }

                        if (flag1 == true && flag2 == true && flag3 == true)
                        {
                            dm.commit();
                            dm.connClose();
                            this.lblsuccess.Visible = true;
                        }
                        else
                        {
                            dm.rollback();
                            dm.connClose();
                            this.Labelfail.Visible = true;
                        }


                    }
                    catch (Exception Ex)
                    {
                        dm.rollback();
                        dm.connClose();
                        EPage.Messege = Ex.Message;
                        Response.Redirect("~/EPage.aspx");
                    }
                }

            }
       




    }
   
}
