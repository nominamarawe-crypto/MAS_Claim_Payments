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
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["MOS"] != null)
            {
                MOS = Session["MOS"].ToString();
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }
            if (Session["claimno"] != null)
            {
                ClaimNo = Int32.Parse(Session["claimno"].ToString());
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }
            if (Session["polno"] != null)
            {
                Polno = Int32.Parse(Session["polno"].ToString());
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }
          
            if (Session["EPFNum"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }
            else
            {
                Response.Redirect("SessionError.aspx");
            }

            if (MOS == "M")
                lbllMOS.Text = "Main Life";
            else if (MOS == "S")
                lbllMOS.Text = "Spouse";
            else if (MOS == "2")
                lbllMOS.Text = "Second Life";
            else if (MOS == "C")
                lbllMOS.Text = "Child";
            else
                lbllMOS.Text = "";

            lblPolNo.Text = polno.ToString();
            lblClaimNo.Text = ClaimNo.ToString();
            lblMOSShort.Text = MOS.ToString();
            lblEPF.Text = EPF.ToString();

        }
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        Server.Transfer("ManualCheckEntry.aspx");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        polno = int.Parse(this.lblPolNo.Text);
        MOS = this.lblMOSShort.Text;
        claimNo = int.Parse(this.lblClaimNo.Text);
        EPF = this.lblEPF.Text;
        lblMessage.Visible = false;
        btnsubmit.Enabled = true;
        Button1.Enabled = true;
        dm = new DataManager();
        try
        {
                string dthrefSel = "select POLICY_NO, POLICY_TYPE, CLAIM_NO from lphs.death_manual_master where POLICY_NO = " + polno + " and CLAIM_NO = '" + claimNo + "' and POLICY_TYPE = '" + MOS + "'  ";
                if (dm.existRecored(dthrefSel) == 0)
                {
                   // Insert Data in to lphs.DEATH_MANUAL_MASTER

                    string dthintupdate = "INSERT INTO lphs.death_manual_master (POLICY_NO, POLICY_TYPE, CLAIM_NO, EPFNO) VALUES (" + polno + ",'" + MOS + "','" + claimNo + "','" + EPF + "')";
                    dm.insertRecords(dthintupdate);

                    lblMessage.Text = "Record Inserted";
                    lblMessage.Visible = true;
                    
                    ViewState["polno"] = polno;
                    ViewState["MOS"] = MOS;
                    ViewState["claimno"] = claimNo;

                    btnsubmit.Enabled = false;
                    Button1.Enabled = false;
                }
                else
                {
                    dm.connclose();
                    lblMessage.Text = "There is already a record in DEATH_CLAIM_TABLE";
                    lblMessage.Visible = true;
                }
           
            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            //EPage.Messege = ex.Message;
            //Response.Redirect("~/EPage.aspx");
        }
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
