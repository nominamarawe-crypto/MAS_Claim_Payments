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

public partial class Sundryrcpt001 : System.Web.UI.Page
{
    private long Polno;
    private string MOS;
    private string entEPF;
    private int BRN;
    DataManager dm;
    User_Authentication objUserAuthentication;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            entEPF = Session["EPFNum"].ToString();
            hdfepf.Value = entEPF;
            BRN = Convert.ToInt32(Session["brcode"]);
            hdfbrn.Value = BRN.ToString();
        }
        else
        {
            EPage.Messege = "Session Expired.Please log to the system again...";
            Response.Redirect("EPage.aspx");
        }
        if (!Page.IsPostBack)
        {
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
                this.ddlMOS.Items.Add(new ListItem("Child", "C"));
                
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
            if (txtpolno.Text != "")
            {
                Polno = long.Parse(txtpolno.Text.Trim());               
            }
            if (this.ddlMOS.SelectedIndex == 0)
            {
                MOS = "M";
            }
            else if (this.ddlMOS.SelectedIndex == 1)
            {
                MOS = "S";
            }
            else if (this.ddlMOS.SelectedIndex == 2)
            {
                MOS = "2";
            }
            else if (this.ddlMOS.SelectedIndex == 2)
            {
                MOS = "C";
            }
            Session["EPFNum"] = hdfepf.Value;
            Session["brcode"] = hdfbrn.Value;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        string seldthref = "select DRAGEADMIT from lphs.dthref where DRPOLNO=" + Polno + " and DRMOS='" + MOS + "' and DRAGEADMIT='Y' ";
        if (dm.existRecored(seldthref) != 0)
        {
            dm.connClose();
            Server.Transfer("Sundryrcpt002.aspx");
        }
        else
        {
            EPage.Messege = "Cannot issue a Sundry Receipt for this Policy..";
            Response.Redirect("EPage.aspx");
        }
    }
    public long POLNO
    {
        get { return Polno; }
        set { Polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }

    }
}
