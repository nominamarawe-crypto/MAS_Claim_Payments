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

public partial class dthReg001 : System.Web.UI.Page
{

    private int polno;
    private string MOS = "";
    private int dtaeofdeath;   
    DataManager firstPageObj;
    User_Authentication objUserAuthentication; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mOF;
        }

        if (!Page.IsPostBack)
        {
            //Change by Dulan Task 25215 - 2015-09-07 ********************************
            try
            {
                #region -------------- Check Authority -----------------------

                objUserAuthentication = new User_Authentication();
                if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC04"))
                {
                    throw new Exception("You have no Authority for this option");
                }

                #endregion

                // Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }

            firstPageObj = new DataManager();
            try
            {
                if (Request.QueryString["polNo"] != null)
                {
                    ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polNo"]));
                    polno = int.Parse(Request.QueryString["polNo"]);
                }
                if (Request.QueryString["mos"] != null)
                {
                    ViewState.Add("mosQstr", Request.QueryString["mos"].ToString());
                    MOS = Request.QueryString["mos"].ToString();
                }

                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));

                if (polno > 0)
                {
                    this.txtpolno.Text = polno.ToString();

                    if (MOS.Equals("M"))
                    {
                        this.ddlMOS.SelectedIndex = 0;
                    }
                    else if (MOS.Equals("S"))
                    {
                        this.ddlMOS.SelectedIndex = 1;
                    }
                    else if (MOS.Equals("2"))
                    {
                        this.ddlMOS.SelectedIndex = 2;
                    }
                    else if (MOS.Equals("C"))
                    {
                        this.ddlMOS.SelectedIndex = 3;
                    }

                    #region //------------- Getting Date of Death ----------------------
                    string confst = "";
                   
                    polno = int.Parse(this.txtpolno.Text);
                    MOS = this.ddlMOS.SelectedItem.Value;
                    string select01 = "select ddtofdth, dsta from lphs.dthint where dpolno=" + polno + " and dmos='" + MOS + "' ";
                    if (firstPageObj.existRecored(select01) != 0)
                    {
                        firstPageObj.readSql(select01);
                        OracleDataReader dthintreader = firstPageObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintreader.Read())
                        {
                            if (!dthintreader.IsDBNull(0)) { dtaeofdeath = dthintreader.GetInt32(0); }
                            if (!dthintreader.IsDBNull(1)) { confst = dthintreader.GetString(1); }
                        }
                        dthintreader.Close();
                        dthintreader.Dispose();

                        this.txtdateofdeath.Text = dtaeofdeath.ToString();
                        if (confst.Equals("2")) { this.txtdateofdeath.ReadOnly = true; }
                        else { this.txtdateofdeath.ReadOnly = false; }
                    }

                    firstPageObj.connclose();

                    #endregion

                }
                else { this.txtpolno.Text = ""; }

                ViewState["dtaeofdeath"] = dtaeofdeath;
            }
            catch (Exception ex)
            {
                firstPageObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else 
        {
            if (ViewState["polnoQstr"] != null) { polno = (int)ViewState["polnoQstr"]; }
            if (ViewState["mosQstr"] != null) { MOS = ViewState["mosQstr"].ToString(); }
            if (ViewState["dtaeofdeath"] != null) { dtaeofdeath = int.Parse(ViewState["dtaeofdeath"].ToString()); }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = int.Parse(this.txtpolno.Text);
        MOS = this.ddlMOS.SelectedItem.Value;
        dtaeofdeath = int.Parse(this.txtdateofdeath.Text);

        Server.Transfer("~/dthReg002.aspx", false);

    }
    protected void btnrest_Click(object sender, EventArgs e)
    {
        try
        {
            this.txtpolno.Text = "";
            this.txtdateofdeath.Text = "";
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    public int Polno {
        get { return polno; }
        set { polno = value; }
    }
    public string mos {
        get { return MOS; }
        set { MOS = value; }
    
    }
    public int Dtaeofdeath
    {
        get { return dtaeofdeath; }
        set { dtaeofdeath = value; }

    }
    protected void ddlMOS_SelectedIndexChanged(object sender, EventArgs e)
    {
        firstPageObj = new DataManager();
        try 
        {
            string confst = "";
          
            polno = int.Parse(this.txtpolno.Text);
            MOS = this.ddlMOS.SelectedItem.Value;
            string select01 = "select ddtofdth, dsta from lphs.dthint where dpolno=" + polno + " and dmos='" + MOS + "' ";
            if (firstPageObj.existRecored(select01) != 0)
            {
                firstPageObj.readSql(select01);
                OracleDataReader dthintreader = firstPageObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintreader.Read())
                {
                    if (!dthintreader.IsDBNull(0)) { dtaeofdeath = dthintreader.GetInt32(0); }
                    if (!dthintreader.IsDBNull(1)) { confst = dthintreader.GetString(1); }
                }
                dthintreader.Close();
                dthintreader.Dispose();
                this.txtdateofdeath.Text = dtaeofdeath.ToString();
                if (confst.Equals("2")) { this.txtdateofdeath.ReadOnly = true; }
                else { this.txtdateofdeath.ReadOnly = false; }
            }
            else {
                //errdesc = "Intimation Already Regitered or No Death Intimation Details!";
                //throw new Exception();
            }
            firstPageObj.connclose();
        }
        catch (Exception ex)
        {
            firstPageObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

       
    }
    protected void txtpolno_TextChanged(object sender, EventArgs e)
    {
        firstPageObj = new DataManager();
        try 
        {
            string confst = "";
           
            polno = int.Parse(this.txtpolno.Text);
            MOS = this.ddlMOS.SelectedItem.Value;
            string select02 = "select ddtofdth, dsta from lphs.dthint where dpolno=" + polno + " and dmos='" + MOS + "' ";
            if (firstPageObj.existRecored(select02) != 0)
            {
                firstPageObj.readSql(select02);
                OracleDataReader dthintreader = firstPageObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintreader.Read())
                {
                    if (!dthintreader.IsDBNull(0)) { dtaeofdeath = dthintreader.GetInt32(0); }
                    if (!dthintreader.IsDBNull(1)) { confst = dthintreader.GetString(1); }
                }
                dthintreader.Close();
                dthintreader.Dispose();
                this.txtdateofdeath.Text = dtaeofdeath.ToString();
                if (confst.Equals("2")) { this.txtdateofdeath.ReadOnly = true; }
                else { this.txtdateofdeath.ReadOnly = false; }
            }
            else 
            {               
                //errdesc = "Intimation Already Regitered or No Death Intimation Details!";
                //throw new Exception();
            }
            firstPageObj.connclose();
        }
        catch (Exception ex)
        {
            firstPageObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
       
    }
}
