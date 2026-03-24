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

public partial class moreLegalHires001 : System.Web.UI.Page
{
    private long polno;
    private long clmno;
    private string married;
    private string heirer;
    private string mos;
    private double totshare;
    private double share;
    private int dob;
    private string heirename;
    private string ad1, ad2, ad3, ad4;
    private string epf;
    private double shareamt;
    private double tmpshareamt;

    DataManager dm;
    LegalHiere Lh; 

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            if (!Page.IsPostBack)
            {
                polno = this.PreviousPage.Polno;
                mos = this.PreviousPage.mOF;
                epf = this.PreviousPage.Epf;
                clmno = this.PreviousPage.Claimno;
                Lh = new LegalHiere(polno, mos, dm); 
                totshare = Lh.Totshare;
                shareamt = Lh.getShareTotAmount(polno, mos, dm);

                //this.ddlHeiretype.Items.Add("Brother");
                //this.ddlHeiretype.Items.Add("Sister");
                //this.ddlHeiretype.Items.Add("Son");
                //this.ddlHeiretype.Items.Add("Daughter");
                //this.ddlHeiretype.Items.Add("Mother");
                //this.ddlHeiretype.Items.Add("Father");
                this.ddlHeiretype.Items.Add("Father");
                this.ddlHeiretype.Items.Add("Mother");
                this.ddlHeiretype.Items.Add("Spouce");
                this.ddlHeiretype.Items.Add("Son");
                this.ddlHeiretype.Items.Add("Daughter");
                this.ddlHeiretype.Items.Add("Brother");
                this.ddlHeiretype.Items.Add("Sister");
                this.ddlMarried.Items.Add(new ListItem("Married", "M"));
                this.ddlMarried.Items.Add(new ListItem("Unmarried", "U"));

                ViewState["polno"] = polno;
                ViewState["mos"] = mos;
                ViewState["Lh"] = Lh;
                ViewState["totshare"] = totshare;
                ViewState["epf"] = epf;
                ViewState["shareamt"] = shareamt;
            }
            else
            {
                polno = long.Parse(ViewState["polno"].ToString());
                mos = ViewState["mos"].ToString();
                Lh = (LegalHiere)ViewState["Lh"];
                totshare = double.Parse(ViewState["totshare"].ToString());
                epf = ViewState["epf"].ToString();
                if (ViewState["tmpshareamt"] != null) { tmpshareamt = double.Parse(ViewState["tmpshareamt"].ToString()); }
                if (ViewState["shareamt"] != null) { shareamt = double.Parse(ViewState["shareamt"].ToString()); }
            }            
            this.lblBalanceshare.Text = Convert.ToString((1 - totshare) * 100)+"% ";
            dm.connclose();
        }
        catch (Exception Ex)
        {
            dm.connClose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    protected void cmdOk_Click(object sender, EventArgs e)
    {
        string ip;
        share = double.Parse(this.txtShare.Text.Trim())/100;


        if ((1 - (totshare + tmpshareamt)) < share)
        {
            this.lblMessage.Visible = true;
            this.lblBalanceshare.Text = Convert.ToString((1 - totshare - tmpshareamt) * 100) + "% ";
        }
        else
        {
            try
            {
                dm = new DataManager();
                dm.begintransaction();

                tmpshareamt += share;
                married = this.ddlMarried.SelectedItem.Value;
                heirer = this.ddlHeiretype.SelectedItem.Value;
                if (txtDob.Text != null) { dob = int.Parse(txtDob.Text.Trim()); }
                heirename = txtName.Text;
                ad1 = txtAd1.Text;
                ad2 = txtAd2.Text;
                ad3 = txtAd3.Text;
                ad4 = txtAd4.Text;
                cmdOk.Enabled = false;
                cmdMore.Enabled = true;
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Lh.Lhinsert(heirer, share, heirename, ad1, ad2, ad3, ad4, dob, married, epf, ip, dm);
                this.lblBalanceshare.Text = Convert.ToString((1 - totshare - tmpshareamt) * 100) + "% ";

                ViewState["tmpshareamt"] = tmpshareamt;
                dm.commit();
                dm.connclose();
            }
            catch (Exception Ex)
            {
                dm.connClose();
                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        }
    }
    protected void cmdMore_Click(object sender, EventArgs e)
    {
        this.lblBalanceshare.Text = Convert.ToString((1 - totshare - tmpshareamt) * 100) + "% ";
        this.txtName.Text = "";
        this.txtShare.Text = "";
        this.txtAd1.Text = "";
        this.txtAd2.Text = "";
        this.txtAd3.Text = "";
        this.txtAd4.Text = "";
        this.txtDob.Text = "";
        cmdOk.Enabled = true;
    }
    protected void cmdNext_Click(object sender, EventArgs e)
    {
        //shareamt = Lh.Totshareamt;
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&totamount=" + shareamt + "&claimno=" + clmno + "&theMof=" + mos + "");
    }
    protected void ddlHeiretype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlHeiretype.SelectedValue.Equals("Mother")) || (ddlHeiretype.SelectedValue.Equals("Father")) || (ddlHeiretype.SelectedValue.Equals("Spouce")))
        {
            this.ddlMarried.SelectedValue = "M";
            this.ddlMarried.Enabled = false;
        }
    }
}
