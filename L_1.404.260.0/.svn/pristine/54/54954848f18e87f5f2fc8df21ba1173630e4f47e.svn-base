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
using System.Collections.Generic;
public partial class dthoutlist002 : System.Web.UI.Page
{
    private int stdt;
    private int enddt;

    dthoutlistval dtoutlistobj = new dthoutlistval();
    Childprotpay childprotobj = new Childprotpay();
    Dthintout dtintoutobj = new Dthintout();
    DthPaid dtpaidobj = new DthPaid();
    DthAdmitted dtadmitobj = new DthAdmitted();
    DthRepudiated dtrepudobj= new DthRepudiated();
    DthLaps dtlapsobj = new DthLaps();
    DthRegOut dtregoutobj = new DthRegOut();
    DthAdmittedOut dtadmitoutobj = new DthAdmittedOut();
    DthPartPaid dtpartpaidobj = new DthPartPaid();
    protected void Page_Load(object sender, EventArgs e)
     {
        try
        {
            if (!Page.IsPostBack)
            {
                stdt = int.Parse(Request.QueryString["startDate"].ToString());
                enddt = int.Parse(Request.QueryString["endDate"].ToString());
                dtoutlistobj.Fetch(stdt, enddt);
                childprotobj.Fetch(stdt, enddt);
                dtintoutobj.Fetch(stdt, enddt);
                dtpaidobj.Fetch(stdt, enddt);
                dtadmitobj.Fetch(stdt, enddt);
                dtrepudobj.Fetch(stdt, enddt);
                dtlapsobj.Fetch(stdt, enddt);
                dtregoutobj.Fetch(stdt, enddt);
                dtadmitoutobj.Fetch(stdt, enddt);
                dtpartpaidobj.Fetch(stdt, enddt);
                ViewState["stdt"] = stdt;
                ViewState["enddt"] = enddt;
                ViewState["itemlist1"] = childprotobj.ChildprotecList;
                ViewState["childprotobj"] = childprotobj;
                ViewState["itemlist"] = dtoutlistobj.DthoutlistMaker;
                ViewState["dtoutlistobj"] = dtoutlistobj;
                ViewState["Itemlist2"] = dtintoutobj.DthIntListMake;
                ViewState["dthintoutobj"] = dtintoutobj;
                ViewState["dtpaidobj"] = dtpaidobj;
                ViewState["dtadmitobj"] =dtadmitobj;
                ViewState["dtrepudobj"] = dtrepudobj;
                ViewState["dtregoutobj"] = dtregoutobj;
                ViewState["dtadmitoutobj"] = dtadmitoutobj;
                ViewState[" dtpartpaidobj"] = dtpartpaidobj;
                ViewState["dtlapsobj "] = dtlapsobj;

               
                lblFrom.Text = stdt.ToString().Substring(0, 4) + "/" + stdt.ToString().Substring(4, 2) + "/" + stdt.ToString().Substring(6, 2);
                lblTo.Text = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                lblNoofClaimRes.Text = dtintoutobj.NoofClaims.ToString();
                lblAmountRes.Text = dtintoutobj.TOTLiabeAmt.ToString("N2");
                lblReGorss.Text = dtintoutobj.TOTGrossAmt.ToString("N2");
                lblReNet.Text = dtintoutobj.TOTNetAmt.ToString("N2");


                lblNoofPaid.Text = dtpaidobj.NoofClaims.ToString();
                lblAmountPaid.Text = dtpaidobj.TOTLiabeAmt.ToString("N2");
                lblPaidGross.Text = dtpaidobj.TOTGrossAmt.ToString("N2");
                lblPaidNet.Text = dtpaidobj.TOTNetAmt.ToString("N2");


                lblNoofAdmitted.Text = dtadmitobj.NoofClaims.ToString();
                lblAmountofAdmitted.Text = dtadmitobj.TOTLiabeAmt.ToString("N2");
                lblAdGrossAmount.Text = dtadmitobj.TOTGrossAmt.ToString("N2");
                lblAdNetAmount.Text = dtadmitobj.TOTNetAmt.ToString("N2");
                
                lblNoofRep.Text = dtrepudobj.NoofClaims.ToString();
                lblAmountofRep.Text = dtrepudobj.TOTLiabeAmt.ToString("N2");
                lblRepGross.Text = dtrepudobj.TOTGrossAmt.ToString("N2");
                lblRepNet.Text = dtrepudobj.TOTNetAmt.ToString("N2");
                lblExgraciaAmt.Text = dtrepudobj.TOTExgraciaAmt.ToString("N2");

                lblNoofLaps.Text = dtlapsobj.NoofClaims.ToString();
                lblAmountofLaps.Text = dtlapsobj.TOTLiabeAmt.ToString("N2");
                lblLapsGross.Text = dtlapsobj.TOTGrossAmt.ToString("N2");
                lblLapsNet.Text = dtlapsobj.TOTNetAmt.ToString("N2");

                lblNoofRegis.Text = dtregoutobj.NoofClaims.ToString();
                lblAmountofReg.Text = dtregoutobj.TOTLiabeAmt.ToString("N2");
                lblRegGross.Text = dtregoutobj.TOTGrossAmt.ToString("N2");
                lblRegNet.Text = dtregoutobj.TOTNetAmt.ToString("N2");

                lblNoofAdOut.Text = dtadmitoutobj.NoofClaims.ToString();
                lblAmountOfAdOut.Text = dtadmitoutobj.TOTLiabeAmt.ToString("N2");
                lblAdOutNet.Text = dtadmitoutobj.TOTNetAmt.ToString("N2");
                lblAdOutstanding.Text = dtadmitoutobj.TOTOutAmt.ToString("N2");

                
                lblBasicCover.Text = dtintoutobj.TOTBasic.ToString("N2");
                lblSjCover.Text = dtintoutobj.TOTSj.ToString("N2");
                lblAdbCover.Text = dtintoutobj.TOTAdb.ToString("N2");
                lblFECover.Text = dtintoutobj.TOTFe.ToString("N2");
                lblFPUCover.Text = dtintoutobj.TOTFpu.ToString("N2");

                lblBasicCoverAd.Text = dtadmitobj.TOTBasic.ToString("N2");
                lblSjAd.Text = dtadmitobj.TOTSj.ToString("N2");
                lblADBAd.Text = dtadmitobj.TOTAdb.ToString("N2");
                lblFeAd.Text = dtadmitobj.TOTFe.ToString("N2");
                lblFpuAd.Text = dtadmitobj.TOTFpu.ToString("N2");

                lblBasicCoverPd.Text = dtpaidobj.TOTBasic.ToString("N2");
                lblSjPd.Text = dtpaidobj.TOTSj.ToString("N2");
                lblADBPd.Text = dtpaidobj.TOTAdb.ToString("N2");
                lblFePd.Text = dtpaidobj.TOTFe.ToString("N2");
                lblFpuPd.Text = dtpaidobj.TOTFpu.ToString("N2");

                lblBasicCoverRep.Text = dtrepudobj.TOTBasic.ToString("N2");
                lblSjRep.Text = dtrepudobj.TOTSj.ToString("N2");
                lblADBRep.Text = dtrepudobj.TOTAdb.ToString("N2");
                lblFeRep.Text = dtrepudobj.TOTFe.ToString("N2");
                lblFpuRep.Text = dtrepudobj.TOTFpu.ToString("N2");

                lblBasicCoverLap.Text = dtlapsobj.TOTBasic.ToString("N2");
                lblSjLap.Text = dtlapsobj.TOTSj.ToString("N2");
                lblADBLap.Text = dtlapsobj.TOTAdb.ToString("N2");
                lblFeLap.Text = dtlapsobj.TOTFe.ToString("N2");
                lblFpuLap.Text = dtlapsobj.TOTFpu.ToString("N2");

                lblBasicCoverReg.Text =dtregoutobj.TOTBasic.ToString("N2");
                lblSjReg.Text = dtregoutobj.TOTSj.ToString("N2");
                lblADBReg.Text = dtregoutobj.TOTAdb.ToString("N2");
                lblFeReg.Text = dtregoutobj.TOTFe.ToString("N2");
                lblFpuReg.Text = dtregoutobj.TOTFpu.ToString("N2");

                lblBasicCoverReg.Text = dtregoutobj.TOTBasic.ToString("N2");
                lblSjReg.Text = dtregoutobj.TOTSj.ToString("N2");
                lblADBReg.Text = dtregoutobj.TOTAdb.ToString("N2");
                lblFeReg.Text = dtregoutobj.TOTFe.ToString("N2");
                lblFpuReg.Text = dtregoutobj.TOTFpu.ToString("N2");

                lblBasicCoverReg.Text = dtregoutobj.TOTBasic.ToString("N2");
                lblSjReg.Text = dtregoutobj.TOTSj.ToString("N2");
                lblADBReg.Text = dtregoutobj.TOTAdb.ToString("N2");
                lblFeReg.Text = dtregoutobj.TOTFe.ToString("N2");
                lblFpuReg.Text = dtregoutobj.TOTFpu.ToString("N2");

                lblBaiscCoverAdOut.Text = dtadmitoutobj.TOTBasic.ToString("N2");
                lblSjAdOut.Text = dtadmitoutobj.TOTSj.ToString("N2");
                lblADBAdOut.Text = dtadmitoutobj.TOTAdb.ToString("N2");
                lblFeAdOut.Text = dtadmitoutobj.TOTFe.ToString("N2");
                lblFpuAdOut.Text = dtadmitoutobj.TOTFpu.ToString("N2");


                Label1.Text = dtpartpaidobj.NoofClaims.ToString();
                Label2.Text = dtpartpaidobj.TOTOutAmt.ToString("N2");
                //LabelBasic.Text = dtintoutobj.TOTBasic.ToString("N2");
                //LabeADB.Text = dtintoutobj.TOTAdb.ToString("N2");
                //LabelSJ.Text = dtintoutobj.TOTSj.ToString("N2");
                //LabelFE.Text = dtintoutobj.TOTFe.ToString("N2");
                //LabelTotal.Text = dtintoutobj.TOTLiabeAmt.ToString("N2");
                //LabelNoofClaims.Text = dtintoutobj.NoofClaims.ToString();


               // GridViewdthoutlist.DataSource = dtoutlistobj.DthoutlistMaker;
               // GridViewdthoutlist.DataBind();
               // GridViewchidpro.DataSource = childprotobj.ChildprotecList;
                //GridViewchidpro.DataBind();
                //GridViewDthIntimation.DataBind();

               
             }
            else
            {
                if (ViewState["stdt"] != null) { stdt = int.Parse(ViewState["stdt"].ToString()); }
                if (ViewState["enddt"] != null) {enddt = int.Parse(ViewState["enddt"].ToString()); }

                if (ViewState["dtoutlistobj"] != null) { dtoutlistobj = (dthoutlistval)ViewState["dtoutlistobj"]; }
                if (ViewState["childprotobj"] != null) { childprotobj = (Childprotpay)ViewState["childprotobj"]; }
                if (ViewState["dthintoutobj"] != null) { dtintoutobj = (Dthintout)ViewState["dthintoutobj"]; }
                if (ViewState["dthintoutobj"] != null) { dtpaidobj = (DthPaid)ViewState["dtpaidobj"]; }
                if (ViewState["dthintoutobj"] != null) { dtadmitobj = (DthAdmitted)ViewState["dtadmitobj"]; }
                if (ViewState["dtrepudobj"] != null) { dtrepudobj = (DthRepudiated)ViewState["dtrepudobj"]; }
                if (ViewState["dtlapsobj "] != null) { dtlapsobj = (DthLaps)ViewState["dtlapsobj "]; }

            }
        }
        catch(Exception Ex)
        {
            //Response.Write(Ex.ToString());
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // Response.Redirect("dthoutreport.aspx?startdate="+stdt+"&enddate="+enddt+""); 
    }

    public int Startdate1
    {
        get { return stdt; }
        set { stdt = value; }
    }
    public int Enddate1
    {
        get { return enddt; }
        set { enddt = value; }
    }
    public dthoutlistval Dthout
    {
        get { return dtoutlistobj; }
        set { dtoutlistobj = value; }
    }
    public Childprotpay ChildPro
    {
        get { return childprotobj; }
        set { childprotobj = value; }
    }

    public Dthintout DthInt
    {
        get { return dtintoutobj; }
        set { dtintoutobj = value; }
    }
    public DthLaps DthLap
    {
        get { return dtlapsobj; }
        set { dtlapsobj = value; }
    }
    public DthRepudiated DthRep
    {
        get { return dtrepudobj; }
        set { dtrepudobj = value; }
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void GridViewDthIntimation_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
