using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Actuarial001 : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    DataManager dthintobj;
    private string EPF = "";
    private string PolNo = "";
    private string ClaimNo = "";
    private string ReInsAvailability = "";
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            Response.Redirect("SessionError.aspx");
        }

        if (!Page.IsPostBack)
        {
            try
            {
                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC09"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion

                
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if (ValidateSearhFields())
        {
            if(searchBy.SelectedValue == "P")
            {
                PolNo = txtpolno.Text.Trim();
                ClaimNo = drClaimList.SelectedValue.Trim();
            }
            else
            {
                ClaimNo = txtClaimNo.Text.Trim();
            }
            
            bool valid = true;
            //ReInsAvailability = ddlAvailbility.SelectedValue.Trim();

            int polno = 0;
            dthintobj = new DataManager();

            using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
            {
                try
                {
                    dal.OpenTransaction();

                    #region Check Email Sent or Not
                    string subsql = "";
                    if (PolNo != "")
                    {
                        subsql = " POLNO = '" + PolNo + "'";
                    }
                    if (ClaimNo != "")
                    {
                        if (subsql != "")
                        {
                            subsql += " and ";
                        }
                        subsql += " CLAIMNO = '" + ClaimNo + "' ";
                    }
                    string reinsemailcheck = "select POLNO from lphs.DTH_REINS_EMAIL_LOG where" + subsql;
                    
                    if (!dal.IsRecordExist(reinsemailcheck))
                    {

                        valid = false;
                    }
                    else
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(reinsemailcheck))
                        {
                            using (DataTableReader dthintREADER = dataTable.CreateDataReader())
                            {
                                while (dthintREADER.Read())
                                {
                                    if (!dthintREADER.IsDBNull(0)) { polno = Convert.ToInt32(dthintREADER[0]); } else { polno =0; }
                                }
                            }
                        }
                    }
                    #endregion
                    
                    dal.CommitTransaction();
                    dal.CloseDBConnection();



                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    dal.CloseDBConnection();
                    EPage.Messege = ex.Message.ToString();
                    Response.Redirect("EPage.aspx");
                }
            }
            hdnPolno.Value = polno.ToString();
            if (valid)
            {
                Server.Transfer("~/Actuarial002.aspx", false);
            }
            else
            {
                EPage.Messege = "Email Has Not Sent To Actuarial Department";
                Response.Redirect("EPage.aspx");
            }
        }

    }

    public bool ValidateSearhFields()
    {
        bool isValid = true;
        lblError.Visible = false;

        if (searchBy.SelectedValue == "P")
        {
            if (string.IsNullOrEmpty(txtpolno.Text)){
                isValid = false;
                lblError.Visible = true;
                lblError.Text = "Please eneter the Policy Number";
            }
            else
            {
                if (string.IsNullOrEmpty(drClaimList.SelectedValue))
                {
                    isValid = false;
                    lblError.Visible = true;
                    lblError.Text = "No Claims For this Policy";
                }
            }
        }
        else
        {
            if (string.IsNullOrEmpty(txtClaimNo.Text))
            {
                isValid = false;
                lblError.Visible = true;
                lblError.Text = "Please eneter the Claim Number";
            }
        }

        return isValid;
    }

    protected void searchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(searchBy.SelectedValue == "P")
        {
            rowPolNUmber.Visible = true;
            row2PolNUmber.Visible = true;
            trClaimDrop.Visible = true;
            trClaimDrop2.Visible = true;

            rowClaimNumber.Visible = false;
            row2ClaimNumber.Visible = false;
        }
        else
        {
            rowPolNUmber.Visible = false;
            row2PolNUmber.Visible = false;
            trClaimDrop.Visible = false;
            trClaimDrop2.Visible = false;

            rowClaimNumber.Visible = true;
            row2ClaimNumber.Visible = true;
        }
    }

    protected void txtpolno_TextChanged(object sender, EventArgs e)
    {
        string PolNO = txtpolno.Text.Trim();
        List<string> ClaimList = new List<string>();
        lblError.Visible = false;
        dthintobj = new DataManager();
        string climno = "";
        using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
        {
            try
            {
                dal.OpenTransaction();

                
                string claimListSelect = "select DISTINCT CLAIMNO from lphs.DTH_REINS_EMAIL_LOG where POLNO='"+PolNO+"'";
                if (!dal.IsRecordExist(claimListSelect))
                {
                    lblError.Visible = true;
                    lblError.Text = "No Claims for this Policy";
                }
                else
                {
                    using (DataTable dataTable = dal.ReadSQLtoDataTable(claimListSelect))
                    {
                        using (DataTableReader dthintREADER = dataTable.CreateDataReader())
                        {
                            while (dthintREADER.Read())
                            {
                                if (!dthintREADER.IsDBNull(0)) { ClaimNo = dthintREADER.GetString(0); } else { ClaimNo = ""; }
                                ClaimList.Add(ClaimNo);
                            }
                        }
                    }
                }

                dal.CommitTransaction();
                dal.CloseDBConnection();
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction();
                dal.CloseDBConnection();
                EPage.Messege = ex.Message.ToString();
                Response.Redirect("EPage.aspx");
            }
        }

        drClaimList.DataSource = ClaimList;
        drClaimList.DataBind();
    }
}
