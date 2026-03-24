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

public partial class ChildProt_ChildProtPayByPolicy001 : System.Web.UI.Page
{
    private long polno;
    DataManager dm;
    private int matdate, dueym;
    private string duemonthstr;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            polno = long.Parse(this.txtpolno.Text);
            polMasRead pmr = new polMasRead(int.Parse(polno.ToString()), dm);
            matdate = pmr.COM + (pmr.TRM * 10000);
            if (DateTime.Today.Month < 10) { duemonthstr = "0" + DateTime.Today.Month.ToString(); }
            else { duemonthstr = DateTime.Today.Month.ToString(); }
            dueym = int.Parse(DateTime.Today.Year.ToString() + duemonthstr);
        }
        catch (Exception Ex)
        {
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        Server.Transfer("ChildProtPay002.aspx?polNo=" + polno + "&maturityDt=" + matdate + "&dueYm=" + dueym + "");

    }
}
