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

public partial class dthoutreport : System.Web.UI.Page
{
    private int stdt;
    private int enddt;
    dthoutlistval dtoutlistobj = new dthoutlistval();
    Childprotpay childprotobj = new Childprotpay();
    Dthintout dthintoutobj = new Dthintout();
    DthLaps dthlapsobj = new DthLaps();
    DthPaid dthpaidobj = new DthPaid();
    DthRepudiated dthrepudiatedobj = new DthRepudiated();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            dtoutlistobj = PreviousPage.Dthout;
            childprotobj = PreviousPage.ChildPro;
            dthintoutobj = PreviousPage.DthInt;
            dthlapsobj = PreviousPage.DthLap;
            dthrepudiatedobj = PreviousPage.DthRep;
        }
       
        if (!Page.IsPostBack)
        {


            stdt = this.PreviousPage.Startdate1;
            enddt = this.PreviousPage.Enddate1;
            ViewState["itemlist2"] = dthintoutobj.DthIntListMake;
            ViewState["itemlist3"] = dthlapsobj.DthLapsListMake;
            ViewState["itemlist4"] = dthrepudiatedobj.DthRepudiatedListMake;

           
            //stdt = int.Parse(Request.QueryString["startDate"].ToString());
           
            dtoutlistobj.Fetch(stdt, enddt);
           // stdt=this.PreviousPage.start
           //lblFrom.Text = stdt.ToString().Substring(0, 4) + "/" + stdt.ToString().Substring(4, 2) + "/" + stdt.ToString().Substring(6, 2);
           //lblnoPaid.Text = dtoutlistobj.NoofPaidAmt.ToString();
           //lblPaid.Text = dtoutlistobj.TotPaidAmt.ToString("N2");
          
           //lblNet.Text = dtoutlistobj.TotNetClmAmt.ToString("N2");
          // lblOutstand.Text = dtoutlistobj.TotOutAmt.ToString("N2");
          // lblnoOutstand.Text = dtoutlistobj.NoofOutstandAmt.ToString();
          // lblChildPaid.Text = childprotobj.TotalPaidAmt.ToString("N2");
          // lblChildOutstand.Text = childprotobj.TotalUnpaidAmt.ToString("N2");
           //lblnoNet.Text = dtoutlistobj.NoofClaims.ToString();
           
           
        }
        else
        {
            if (ViewState["startdate"] != null) { stdt = int.Parse(ViewState["startdate"].ToString()); }
            if (ViewState["enddate"] != null) { enddt = int.Parse(ViewState["enddate"].ToString()); }
            if (ViewState["dtoutlistobj"] != null) { dtoutlistobj = (dthoutlistval)ViewState["dtoutlistobj"]; }
            if (ViewState["dthlapsobj"] != null) { dthlapsobj = (DthLaps)ViewState["dthlapsobj"]; }
            if (ViewState["dthrepudiatedobjj"] != null) { dthrepudiatedobj = (DthRepudiated)ViewState["dthrepudiatedobj"]; }

        }
        
        lblEndDate.Text = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
        lblPaid.Text = dthpaidobj.TOTLiabeAmt.ToString("N2");
        lblnoPaid.Text = dthpaidobj.NoofClaims.ToString();
        lblNoReciv.Text = dthintoutobj.NoofClaims.ToString();
        lblRecivAmt.Text = dthintoutobj.TOTLiabeAmt.ToString("N2");
        lblNoLaps.Text = dthlapsobj.NoofClaims.ToString();
        lblLapsAmt.Text = dthlapsobj.TOTLiabeAmt.ToString("N2");
        lblNoRejct.Text = dthrepudiatedobj.NoofClaims.ToString();
        lblRejctAmt.Text = dthrepudiatedobj.TOTLiabeAmt.ToString("N2");
        lblOutstdAmt.Text = dtoutlistobj.TotOutAmt.ToString("N2");
        //lblNoOustand.Text = dtoutlistobj.NoofOutstandAmt.ToString();

        lblCurrentDate.Text = setdate();
    }

    public string setdate()
    {
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

        ourDate = year + "/" + month + "/" + day;
        return ourDate;
    }
}
