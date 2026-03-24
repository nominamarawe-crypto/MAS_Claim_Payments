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

public partial class trnState001 : System.Web.UI.Page
{
    private int polno;
    private string MOS;
    private string EPF;
    private int claimNo;
    DataManager dm;
    User_Authentication objUserAuthentication; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
            if (Session["EPFNum"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }

            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));

            if (polno > 0)
            {
                this.txtpolno.Text = polno.ToString();
                if (MOS.Equals("M")) { this.ddlMOS.SelectedIndex = 0; }
                else if (MOS.Equals("S")) { this.ddlMOS.SelectedIndex = 1; }
                else if (MOS.Equals("2")) { this.ddlMOS.SelectedIndex = 2; }
                else if (MOS.Equals("C")) { this.ddlMOS.SelectedIndex = 3; }
            }
            else { this.txtpolno.Text = ""; }

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
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = int.Parse(this.txtpolno.Text);
        MOS = this.ddlMOS.SelectedItem.Value;
        claimNo = int.Parse(this.txtClaimNo.Text);
        lblMessage.Visible = false;
        dm = new DataManager();
        try
        {
            //if ((claimNo == null) || (claimNo.Equals("")))
            //{

                string dthrefSel = "select POLICY_NO, POLICY_TYPE, CLAIM_NO from lphs.death_manual_master where POLICY_NO = " + polno + " and CLAIM_NO = '" + claimNo + "' and POLICY_TYPE = '" + MOS + "'  ";
                if (dm.existRecored(dthrefSel) == 0)
                {
                    string dttempcbSel = "select POLNO, CLAIMNO from cashbook.temp_cb where POLNO = '" + polno + "' and CLAIMNO = '" + claimNo + "' -- and VOUTYP='Death' ";
                    if (dm.existRecored(dttempcbSel) != 0)
                    {


                        // Insert Data in to lphs.DEATH_MANUAL_MASTER
                        Session.Add("polno", polno);
                        Session.Add("MOS", MOS);
                        Session.Add("claimno", claimNo);


                        Server.Transfer("ManualCheckEntryConfirm.aspx");

                        //string dthintupdate = "INSERT INTO lphs.death_manual_master (POLICY_NO, POLICY_TYPE, CLAIM_NO) VALUES (" + polno + ",'" + MOS + "','" + claimNo + "')";
                        //dm.insertRecords(dthintupdate);

                        //lblMessage.Text = "Record Inserted";
                        //lblMessage.Visible = true;

                    }
                    else 
                    {
                        dm.connclose();
                        lblMessage.Text = "Manual Payment has not been done yet";
                        lblMessage.Visible = true;
                    }
                   
                }
                else
                {
                    dm.connclose();
                    lblMessage.Text = "There is already a manual entered record in DEATH_CLAIM_TABLE ";
                    lblMessage.Visible = true;
                }
            //}

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            //EPage.Messege = ex.Message;
            //Response.Redirect("~/EPage.aspx");
        }
    }

    protected void btnrest_Click(object sender, EventArgs e)
    {
        this.txtpolno.Text = "";
        this.txtpolno.Text = "";
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public int ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }
}
