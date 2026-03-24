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
using System.Collections.Generic;

public partial class Lhupdate001 : System.Web.UI.Page
{
    private long polno;
    private string mos;
    int i;
    private int heireno;
    private string heirename;
    private string heiretype;
    private int dob;
    private string ad1, ad2, ad3, ad4;
    private string married;
    private double share;
    private double totamt;
    private double outamt;
    private long claimno;
    private int pageflag;
    private int dtofdth;

    DataManager dm;
    DataManager dmm;
    LHUpadate lhu;
    List<LHUpadate> legalhlist;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            mos = this.PreviousPage.mof;
            totamt = PreviousPage.Totamount;
            outamt = PreviousPage.OutAmt;
            claimno = PreviousPage.Claimno;
        }
        if (!Page.IsPostBack)
        {
            i = 0;
            dm = new DataManager();
            lhu = new LHUpadate();
            lhu.Fetch(polno, dm, mos);           
            legalhlist=lhu.Lhlist;

            this.ddlHeiretype.Items.Add("Father");
            this.ddlHeiretype.Items.Add("Mother");
            this.ddlHeiretype.Items.Add("Spouce");
            this.ddlHeiretype.Items.Add("Son");
            this.ddlHeiretype.Items.Add("Daughter");
            this.ddlHeiretype.Items.Add("Brother");
            this.ddlHeiretype.Items.Add("Sister");
            this.ddlHeiretype.Items.Add("Other");

            this.ddlMarried.Items.Add(new ListItem("Married", "M"));
            this.ddlMarried.Items.Add(new ListItem("Unmarried", "U"));
               
            ViewState["polno"] = polno;
            ViewState["mos"] = mos;
            ViewState["lhu"] = lhu;
            ViewState["lhulist"]=legalhlist;
            ViewState["count"] = i;
            ViewState["totamt"] = totamt;
            ViewState["outamt"] = outamt;
            ViewState["claimno"] = claimno;
            this.Setdata(i);

            this.cmdPrevious.Enabled = false;
        }
        else
        {
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
            if (ViewState["lhu"] != null) { lhu = (LHUpadate)ViewState["lhu"]; }
            if (ViewState["lhulist"] != null) { legalhlist = (List<LHUpadate>)ViewState["lhulist"]; }
            if (ViewState["count"] != null) { i = int.Parse(ViewState["count"].ToString()); }
            if (ViewState["totamt"] != null) { totamt = double.Parse(ViewState["totamt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
        }
        Label1.Visible = false;  
    }
    protected void cmdNext_Click(object sender, EventArgs e)
    {
        //i = int.Parse(ViewState["count"].ToString());
        i++;        
        ViewState["count"] = i;
        this.Setdata(i);
        if (legalhlist.Count == i + 1)
        {
            this.cmdNext.Enabled = false;
        }
        this.cmdPrevious.Enabled = true;
    }
    public void Setdata(int count)
    {
        if (count < legalhlist.Count)
        {
            txtAd1.Text = legalhlist[count].Address1.ToString();
            txtAd2.Text = legalhlist[count].Address2.ToString();
            txtAd3.Text = legalhlist[count].Address3.ToString();
            txtAd4.Text = legalhlist[count].Address4.ToString();
            txtName.Text = legalhlist[count].HireName.ToString();
            txtDob.Text = legalhlist[count].Dob.ToString();
            txtShare.Text = Convert.ToString(double.Parse(legalhlist[count].Share.ToString())*100);
            ddlHeiretype.SelectedValue = legalhlist[count].Hiretype.ToString();
            ddlMarried.SelectedValue = legalhlist[count].Married.ToString();
        }
        
    }
    protected void cmdPrevious_Click(object sender, EventArgs e)
    {
        i--;
        ViewState["count"] = i;
        this.Setdata(i);
        if (i==0)
        {
            this.cmdPrevious.Enabled = false;
        }
        cmdNext.Enabled = true;
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        double totshare, prevshare;
        try
        {
            heireno = int.Parse(legalhlist[i].Hireno.ToString());
            heiretype = this.ddlHeiretype.SelectedItem.Value;
            heirename = this.txtName.Text;
            ad1 = this.txtAd1.Text;
            ad2 = this.txtAd2.Text;
            ad3 = this.txtAd3.Text;
            ad4 = this.txtAd4.Text;
            dob = int.Parse(this.txtDob.Text.Trim());
            married = ddlMarried.SelectedItem.Value;
            share = double.Parse(this.txtShare.Text.Trim());
            prevshare = double.Parse(legalhlist[i].Share.ToString());

            lhu = new LHUpadate();
            dm = new DataManager();
            dmm = new DataManager();

            totshare = lhu.CheckBalance(polno, mos, dm) - prevshare + share / 100;
            if (totshare > 1) { throw new Exception("Share Percentage Exceeds 100%"); }
            lhu.Insert(polno, dmm, heireno, heiretype, heirename, ad1, ad2, ad3, ad4, dob, married, share);

            lhu.Fetch(polno, dm, mos);
            legalhlist = lhu.Lhlist;
            ViewState["lhulist"] = legalhlist;
            Label1.Visible = true;
            dm.connclose();
            dmm.connClose();
        }
        catch (Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&totamount=" + totamt + "&outAmt=" + outamt + "&claimno=" + claimno + "&theMof=" + mos + "&pageflag=" + pageflag + "&dtofdth");
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/leganHieresDelete.aspx?polno=" + polno + "&theMof=" + mos + "");
    }
}
