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

public partial class OldChildProt_Oldchildprot003 : System.Web.UI.Page
{
    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2)
        {
            month = "0" + month;
        }
        if (day.Length < 2)
        {
            day = "0" + day;
        }

        ourDate = year + month + day;
        datetime[0] = ourDate;
        // return ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        // return y;
        return datetime;
    }

    public long polno;
    public string mos;
    private int matdate, dueym;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            mos = this.PreviousPage.Mos;
        }
        if (!Page.IsPostBack)
        {
            this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
            this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
            this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));
            this.ddlMOS.Items.Add(new ListItem("Child", "C"));

            if (polno > 0)
            {
                this.txtpolno.Text = polno.ToString();
                this.ddlMOS.SelectedValue = mos;
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            polno = long.Parse(txtpolno.Text.Trim());
            mos = this.ddlMOS.SelectedValue;
            dm = new DataManager();
            #region---------------ChildProtOut----------------
            string childprotsel = "select MATDATE from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + mos + "'";
            if (dm.existRecored(childprotsel) != 0)
            {
                dm.readSql(childprotsel);
                OracleDataReader childprotreader = dm.oraComm.ExecuteReader();
                while (childprotreader.Read())
                {
                    if (!childprotreader.IsDBNull(0)) { matdate = childprotreader.GetInt32(0); } else { matdate = 0; }
                }
                childprotreader.Close();
            }
            #endregion

            dueym = int.Parse(this.setDate()[0].Substring(0, 6));
            dm.connclose();
        }
        catch (Exception Ex)
        {
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        Response.Redirect("~/ChildProt/ChildProtPay002.aspx?polNo=" + polno + "&maturityDt=" + matdate + "&dueYm=" + dueym + "&clmtyp=DOC");    
    }
}
