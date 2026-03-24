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

public partial class PolCont001 : System.Web.UI.Page
{
    private long Polno;
    private string MOS;
    private string entEPF;
    private int BRN;
    DataManager dm;
    private int tble;
    private string tblmos;
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

        string sellpolhis = "select PHPOL,PHTBL,PHMOS from lphs.lpolhis where PHPOL=" + Polno + " and PHMOS='" + MOS + "' and PHTYP='D'";
        if (dm.existRecored(sellpolhis) != 0)
        {
            dm.readSql(sellpolhis);
            OracleDataReader red_2 = dm.oraComm.ExecuteReader();
            while (red_2.Read())
            {
                if (!red_2.IsDBNull(1)) { tble = red_2.GetInt32(1); } else { tble = 0; }
                if (!red_2.IsDBNull(2)) { tblmos = red_2.GetString(2); } else { tblmos =""; }
            }
            red_2.Close();
            
                if (tble != 38 || tble != 39 || tble != 46 || tble != 49 || tble != 14 || tble != 22)
                {
                    if (mos == "M")
                    {
                        string CheckspCvr = "select PRPERTYPE from lund.polpersonal where POLNO=" + Polno + " and PRPERTYPE=2";
                        if (dm.existRecored(CheckspCvr) != 0)
                        {
                            Server.Transfer("PolCont002.aspx");
                        }
                        else
                        {
                            EPage.Messege = "This Policy Number Doesn't Contains a Spouse Cover..";
                            Response.Redirect("EPage.aspx");
                        }
                    }
                    else if (mos == "S")
                    {
                        string CheckspCvr = "select PRPERTYPE from lund.polpersonal where POLNO=" + Polno + " and PRPERTYPE=2";
                        if (dm.existRecored(CheckspCvr) != 0)
                        {
                            Server.Transfer("PolCont002.aspx");
                        }
                        else
                        {
                            EPage.Messege = "This Policy Number Doesn't Contains a Spouse Cover..";
                            Response.Redirect("EPage.aspx");
                        }
                    }
                }            
            dm.connClose();
            
        }
        else
        {
           
            EPage.Messege = "This Policy Number Doesn't register as a Death..";
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
