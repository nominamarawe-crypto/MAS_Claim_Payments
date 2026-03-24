using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using MAS_Claim_Payments.App_Code;

namespace MAS_Claim_Payments
{
    
    public partial class ClaimEntry : System.Web.UI.Page
    {

        private ArrayList bankCodes;
        private List<Banks> banksList = new List<Banks>();
        private DataManager dManager;
        private OracleDataReader odr;
        private int bankCode, bankCode2;
        private string bankname, getBankCodes, getBankNames;
        private GetDBData dbDataObj;

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.lblNICError.Text = "";
            this.lblSuccessMsg.Text = "";
            this.lblSubmitError.Text = "";

            this.tbxInsuredName.Text = "";
            this.ddlBanks.SelectedValue = "-1";
            this.ddlBranches.SelectedValue = "-1";
            this.ddlClmType.SelectedValue = "S";
            this.ddlPayType.SelectedValue = "S";
            this.tbxNIC.Text = "";
            this.tbxPayeeName.Text = "";
            this.tbxMobile.Text = "";
            this.tbxEmail.Text = "";
            this.tbxClaimdt.Text = "";
            this.tbxAmount.Text = "";
            this.tbxAccNo.Text = "";
            this.tbxPolNo.Text = "";
            this.tbxRelationShip.Text = "";
            this.ltrAccCode.Text = "";
            this.tbxClaimantName.Text = "";
            this.tbxEPF.Text = "";

            this.tbxInsuredName.Enabled = true;
            this.ddlBanks.Enabled = true;
            this.ddlBranches.Enabled = true;
            this.ddlClmType.Enabled = true;
            this.ddlPayType.Enabled = true;
            this.tbxNIC.Enabled = true; ;
            this.tbxPayeeName.Enabled = true;
            this.tbxMobile.Enabled = true;
            this.tbxEmail.Enabled = true;
            this.tbxClaimdt.Enabled = true;
            this.tbxAmount.Enabled = true;
            this.tbxAccNo.Enabled = true;
            this.tbxPolNo.Enabled = true;
            this.tbxRelationShip.Enabled = true;            
            this.tbxClaimantName.Enabled = true;
            this.tbxEPF.Enabled = true;

            this.btnSubmit.Enabled = true;
        }

        protected void ddlClmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ddlClmType.SelectedValue.Equals("D"))
            {
                this.ltrAccCode.Text = "2164";
            }
            else if (this.ddlClmType.SelectedValue.Equals("Dis"))
            {
                this.ltrAccCode.Text = "2123";
            }
            else if (this.ddlClmType.SelectedValue.Equals("Hos"))
            {
                this.ltrAccCode.Text = "2125";
            }
            else if (this.ddlClmType.SelectedValue.Equals("Fun"))
            {
                this.ltrAccCode.Text = "4521";
            }
            else if (this.ddlClmType.SelectedValue.Equals("ED"))
            {
                this.ltrAccCode.Text = "2142";
            }
            else if (this.ddlClmType.SelectedValue.Equals("EDis"))
            {
                this.ltrAccCode.Text = "2142";
            }
            else if (this.ddlClmType.SelectedValue.Equals("EHos"))
            {
                this.ltrAccCode.Text = "2142";
            }
            else if (this.ddlClmType.SelectedValue.Equals("EFun"))
            {
                this.ltrAccCode.Text = "2142";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EPFNum"] != null)
                {
                    dManager = new DataManager();                    

                    #region Load bank data                

                    bankCodes = new ArrayList();
                    getBankCodes = "select distinct(bcode) from genpay.bnkbrn where bcode is not null order by bcode";
                    dManager.readSql(getBankCodes);
                    odr = dManager.oraComm.ExecuteReader();
                    while (odr.Read())
                    {
                        if (!odr.IsDBNull(0))
                        {
                            bankCode = odr.GetInt32(0);
                            bankCodes.Add(bankCode);
                        }
                    }
                    odr.Close();

                    for (int j = 0; j < bankCodes.Count; j++)
                    {
                        getBankNames = "select '.' as bbnam,0000 as bcode from dual union select bbnam, bcode from genpay.bnkbrn where bcode = " + int.Parse(bankCodes[j].ToString()) + "";

                        dManager.readSql(getBankNames);
                        odr = dManager.oraComm.ExecuteReader();
                        while (odr.Read())
                        {
                            if (!odr.IsDBNull(0))
                            {
                                bankname = odr.GetString(0);
                            }
                            if (!odr.IsDBNull(1))
                            {
                                bankCode2 = odr.GetInt32(1);
                            }
                        }
                        odr.Close();

                        Banks banks = new Banks();
                        banks.BankCode = bankCode2;
                        banks.BankName = bankname;
                        banksList.Add(banks);

                        ddlBanks.DataSource = banksList;
                        ddlBanks.DataTextField = "BankName";
                        ddlBanks.DataValueField = "BankCode";
                        ddlBanks.DataBind();
                    }

                    ddlBanks.Items.Add(new ListItem("-Select Bank-", "-1"));
                    //ddlBanks.Items.Add(new ListItem("Other Banks", "1"));
                    //ddlBanks.Items.Add(new ListItem("Full Name", "2"));
                    ddlBanks.SelectedValue = "-1";
                    //ddlBanks.SelectedValue = "-1";

                    #endregion

                    dManager.connclose();

                    
                }
                else
                {
                    string message = "Your Session Variable Expired. @ Please Log to the system again.";
                    Response.Redirect("~/EPage.aspx?msg=" + message + "");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblSuccessMsg.Text = "";
            this.lblSubmitError.Text = "";

            FormatData fmtDtObj = new FormatData();

            int clmDt = int.Parse(this.tbxClaimdt.Text.Substring(0, 4) + this.tbxClaimdt.Text.Substring(5, 2) + this.tbxClaimdt.Text.Substring(8, 2));
            int todayDt = int.Parse(DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0'));

            dbDataObj = new GetDBData();

            if (this.lblNICError.Text.Equals(""))
            {
                if (!dbDataObj.checkNICExists(this.tbxNIC.Text))
                {
                    this.lblSubmitError.Text = "No insured person with this NIC no.";
                }
                else if (this.ddlPayType.SelectedValue.Equals("S"))
                {
                    this.lblSubmitError.Text = "Please select payment type";
                }
                else if (this.ddlClmType.SelectedValue.Equals("S"))
                {
                    this.lblSubmitError.Text = "Please select claim type";
                }                
                else if (this.ddlBanks.SelectedValue.Equals("-1"))
                {
                    this.lblSubmitError.Text = "Please select bank";
                }
                else if (this.ddlBranches.SelectedValue.Equals("-1"))
                {
                    this.lblSubmitError.Text = "Please select branch";
                }
                else if (clmDt > todayDt)
                {
                    this.lblSubmitError.Text = "Claim date cannot be a future date";
                }
                else if (!fmtDtObj.validateAccountNo(this.tbxAccNo.Text, int.Parse(this.ddlBanks.SelectedValue), int.Parse(this.ddlBranches.SelectedValue)))
                {
                    this.lblSubmitError.Text = "Account details are invalid for making a SLIP payment.";
                }
                else
                {
                    UpdateDB updtDBObj = new UpdateDB();
                    dbDataObj = new GetDBData();

                    //string epf = dbDataObj.getEPF(this.tbxNIC.Text);

                    string claimNo = updtDBObj.InsertEntryRec(this.tbxNIC.Text, this.tbxPolNo.Text, this.tbxClaimdt.Text, this.ddlClmType.SelectedValue,
                        int.Parse(this.ddlBanks.SelectedValue), int.Parse(this.ddlBranches.SelectedValue), this.tbxAccNo.Text, double.Parse(this.tbxAmount.Text),
                        this.tbxPayeeName.Text, this.ddlPayType.SelectedValue, this.tbxInsuredName.Text, this.tbxEPF.Text, this.ltrAccCode.Text, Session["EPFNum"].ToString(), 
                        this.tbxClaimantName.Text, this.tbxRelationShip.Text, this.tbxMobile.Text, this.tbxEmail.Text);

                    if (!claimNo.Equals(""))
                    {
                        this.lblSuccessMsg.Text = "Data Entered successfully. (Claim No:" + claimNo + ")";

                        this.tbxInsuredName.Enabled = false;
                        this.ddlBanks.Enabled = false;
                        this.ddlBranches.Enabled = false;
                        this.ddlClmType.Enabled = false;
                        this.ddlPayType.Enabled = false;
                        this.tbxNIC.Enabled = false; ;
                        this.tbxPayeeName.Enabled = false;
                        this.tbxMobile.Enabled = false;
                        this.tbxEmail.Enabled = false;
                        this.tbxClaimdt.Enabled = false;
                        this.tbxAmount.Enabled = false;
                        this.tbxAccNo.Enabled = false;
                        this.tbxPolNo.Enabled = false;
                        this.tbxRelationShip.Enabled = false;                        
                        this.tbxClaimantName.Enabled = false;
                        this.tbxEPF.Enabled = false;

                        this.btnSubmit.Enabled = false;
                    }
                    else
                    {
                        this.lblSubmitError.Text = "Data not entered succesfully.";
                    }
                }
            }
        }        

        protected void tbxNIC_TextChanged(object sender, EventArgs e)
        {
            this.lblNICError.Text = "";

            if (!tbxNIC.Text.Equals(""))
            {
                string nic = this.tbxNIC.Text;

                dbDataObj = new GetDBData();

                if (dbDataObj.checkNICExists(nic))
                {
                    this.tbxInsuredName.Text = dbDataObj.getInsuredName(nic);
                    this.tbxMobile.Text = dbDataObj.getContactNo(nic);
                    this.tbxEmail.Text = dbDataObj.getEmail(nic);
                    this.tbxEPF.Text = dbDataObj.getEPF(nic);
                }
                else
                {                   
                    this.lblNICError.Text = "No insured person with this NIC no.";                    
                }
            }
        }
    }


    
}