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

public partial class UpdateDeathRegister001 : System.Web.UI.Page
{
    #region -------Variables-----------

    private int polNo = 0;
    private int claimNo = 0;
    private string mos = "";
    private string epf = "";
    User_Authentication objUserAuthentication;
    #endregion

    #region ---------Properties--------
    public int PolNo
    {
        get { return polNo; }
        set { polNo = value; }
    }

    public int ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }

    public string MOS
    {
        get { return mos; }
        set { mos = value; }
    }

    public string EPF
    {
        get { return epf; }
        set { epf = value; }
    }
    #endregion

    DataManager dm = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["EPFNum"] != null)
            {
                epf = Session["EPFNum"].ToString();
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }

            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));

            ViewState["polNo"] = polNo;
            ViewState["mos"] = mos;
            ViewState["claimNo"] = claimNo;
            ViewState["epf"] = epf;

            try
            {
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
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            lblMessage.Text = "";

            if (ViewState["polNo"] != null) { polNo = int.Parse(ViewState["polNo"].ToString()); }
            if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
            if (ViewState["claimNo"] != null) { claimNo = int.Parse(ViewState["claimNo"].ToString()); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();

        bool flag = false;
        bool recFoundDthref = false;
        bool recFoundSurren = false;
        bool recFound = false;
        string dthMos = "";
        lblMessage.Visible = false;
        using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
        {
            try
            {
                polNo = int.Parse(txtpolno.Text);
                mos = ddlMOS.SelectedValue;
                claimNo = int.Parse(txtClaimNo.Text);

                string clmNo = claimNo.ToString().PadLeft(10, '0');

                //string dthRefSel = "select * from lphs.dthref where drpolno=" + polNo + " and drmos='" + mos + "' and drclmno=" + claimNo + "";
                string dthRefSel = "select * from lphs.dthref where drpolno=" + polNo + " and drclmno=" + claimNo + "";
                string dthExsurrenSel = "select * from LPHS.EXSURREN where extpol='" + polNo + "' and extclm='" + clmNo + "'";

                if (dm.existRecored(dthRefSel) != 0)
                {
                    recFoundDthref = true;
                    recFound = true;
                }
                
                if (dm.existRecored(dthExsurrenSel) != 0)
                {
                    recFoundSurren = true;
                    recFound = true;
                }

                if (recFoundDthref || recFoundSurren)
                {
                    string dthRefSelect = "select drmos from lphs.dthref where drpolno=" + polNo + " and drclmno=" + claimNo + "";
                    if (dm.existRecored(dthRefSelect) != 0)
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthRefSelect))
                        {
                            using (DataTableReader dthrefreader = dataTable.CreateDataReader())
                            {
                                while (dthrefreader.Read())
                                {
                                    if (!dthrefreader.IsDBNull(0)) { dthMos = dthrefreader.GetString(0); } else { dthMos = ""; }  
                                }
                            }
                        }
                    }

                    if (dthMos != mos && dthMos != "" && dthMos !=null)
                    {
                        recFound = false;
                    }
                }

                if (recFound)
                {
                    //string dthManualSel = "select * from lphs.death_manual_master where POLICY_NO = " + polNo + " and CLAIM_NO = '" + claimNo + "' and POLICY_TYPE = '" + MOS + "'  ";
                    string dthManualSel = "select * from CASHBOOK.TEMP_CB a where a.polno='" + polNo + "' and A.TRANSACTION_TYPE='X' and A.VOUNO like 'DC%'";

                    if (dm.existRecored(dthManualSel) != 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        lblMessage.Text = "Manual payment not found!";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Search claim record not found!";
                    lblMessage.Visible = true;
                }
                dm.connclose();
            }
            catch (Exception exp)
            {
                dm.connclose();
                EPage.Messege = exp.Message;
                Response.Redirect("~/EPage.aspx");
            }
        }

        if (flag == true)
        {
            Server.Transfer("~/UpdateDeathRegister002.aspx", false);
        }

    }
}
