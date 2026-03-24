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

public partial class paymentDistn001 : System.Web.UI.Page
{
    private long polno;
    private string MOF;
    private long claimno;

    private string recipient = "";
    private string low = "";
    private string recipient02 = "";
    private string low02 = "";

    private double totamount;
    private double netClaim;
    private double outAmt;
    private double exgraciaAmt;
    //private int flag;
    private int pageflag;
    private int dtofdth;
    private int tbl;

    private int payAutDate;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mOF;
            claimno = this.PreviousPage.Claimno;
            totamount = this.PreviousPage.Totamount;
            outAmt = this.PreviousPage.OutAmt;
            tbl = this.PreviousPage.tBL;
        }
        else 
        {            
            if (Request.QueryString["polno"] != null) { polno = int.Parse(Request.QueryString["polno"]); }
            if (Request.QueryString["totamount"] != null) { totamount = double.Parse(Request.QueryString["totamount"].ToString()); }
            if (Request.QueryString["outAmt"] != null) { outAmt = double.Parse(Request.QueryString["outAmt"].ToString()); }
            if (Request.QueryString["claimno"] != null) { claimno = long.Parse(Request.QueryString["claimno"].ToString()); }
            if (Request.QueryString["theMof"] != null) { MOF = Request.QueryString["theMof"].ToString(); }
            if (Request.QueryString["pageflag"] != null) { pageflag = int.Parse(Request.QueryString["pageflag"].ToString()); }
            if (Request.QueryString["dtofdth"] != null) { dtofdth = int.Parse(Request.QueryString["dtofdth"].ToString()); }
            if (Request.QueryString["tbl"] != null) { tbl = int.Parse(Request.QueryString["tbl"].ToString()); }
        }

        if (!Page.IsPostBack)
        {
            ViewState.Add("polnoint", polno);
            ViewState.Add("MOFstr", MOF);
            dm = new DataManager();
            try
            {               
                this.lblpolno.Text = polno.ToString();
                this.lblclmno.Text = claimno.ToString();

                this.ddlReciepients.Items.Add(new ListItem("Legal Heire", "LHI"));
                this.ddlReciepients.Items.Add(new ListItem("Nominee", "NOM"));
                this.ddlReciepients.Items.Add(new ListItem("Assignee", "ASI"));
                this.ddlReciepients.Items.Add(new ListItem("Partner", "LPT"));
                this.ddlReciepients.Items.Add(new ListItem("Main Life", "ML"));
                this.ddlReciepients.Items.Add(new ListItem("Second Life", "SL"));

                //this.ddlLow.Items.Add(new ListItem("General Low", "General"));
                //this.ddlLow.Items.Add(new ListItem("Upcountry Low", "Upcountry"));
                //this.ddlLow.Items.Add(new ListItem("Moore Law", "Moore"));
                //this.ddlLow.Items.Add(new ListItem("Thesawalaamei Law", "Thesawalaamei"));
                //this.ddlLow.Items.Add(new ListItem("Payment To Court", "Payment_To_Court"));
                ////this.ddlLow.Items.Add(new ListItem("Assignee/Nominee", "Assignee_Nominee"));
                //this.ddlLow.Items.Add(new ListItem("Pay To Individual", "Pay_To_Individual"));

                //this.txttotPay.Text = totamount.ToString();
                
                #region ------ Dispalying Details....

                int autCount = 0;
                string dthrefSel = "select dlow, payee, DRNETCLM, PAYAUTDT, DISTN_AUT, EXGRACIA_AMOUNT from lphs.dthref where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                if (dm.existRecored(dthrefSel) != 0)
                {
                    dm.readSql(dthrefSel);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        //if (!dthrefReader.IsDBNull(0)) { low = dthrefReader.GetString(0); } else { low = ""; }
                        if (!dthrefReader.IsDBNull(1)) { recipient = dthrefReader.GetString(1); } else { recipient = ""; }
                        if (!dthrefReader.IsDBNull(2)) { netClaim = dthrefReader.GetDouble(2); } else { netClaim = 0; }
                        if (!dthrefReader.IsDBNull(3)) { payAutDate = dthrefReader.GetInt32(3); } else { payAutDate = 0; }
                        if (!dthrefReader.IsDBNull(4)) { autCount = dthrefReader.GetInt32(4); } else { autCount = 0; }
                        if (!dthrefReader.IsDBNull(5)) { exgraciaAmt = dthrefReader.GetInt32(5); } else { exgraciaAmt = 0; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();
                }

                //totamount -= exgraciaAmt;                     //20070802 update
                this.txttotPay.Text = totamount.ToString();
                this.txtexpay.Text = exgraciaAmt.ToString();

                #region  //************* Getting Authorized Status (commented) **************************
                              
                //string PAYSTATUS = "";
                //if (recipient.Equals("LHI"))
                //{
                //    string heireSelect = "select LHPAYST, VOUSTA from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "'  ";
                //    if (dm.existRecored(heireSelect) != 0)
                //    {
                //        dm.readSql(heireSelect);
                //        OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader();
                //        while (heireSelectReader.Read())
                //        {
                //            if (!heireSelectReader.IsDBNull(0)) { PAYSTATUS = heireSelectReader.GetString(0); }
                //            if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                //        }
                //        heireSelectReader.Close();
                //    }
                //}
                //else if (recipient.Equals("ASI"))
                //{
                //    string asiSelect = "select PAYSTATUS, VOUSTA from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
                //    if (dm.existRecored(asiSelect) != 0)
                //    {
                //        dm.readSql(asiSelect);
                //        OracleDataReader prassReader = dm.oraComm.ExecuteReader();
                //        while (prassReader.Read())
                //        {
                //            if (!prassReader.IsDBNull(0)) { PAYSTATUS = prassReader.GetString(0); }
                //            if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                //        }
                //        prassReader.Close();
                //    }

                //}
                //else if (recipient.Equals("LPT"))
                //{
                //    string living_prtSelect = "select PAYSTATUS, VOUSTA from LUND.LIVING_PRT where polno = " + polno + "  ";
                //    if (dm.existRecored(living_prtSelect) != 0)
                //    {
                //        dm.readSql(living_prtSelect);
                //        OracleDataReader nomineeReader = dm.oraComm.ExecuteReader();
                //        while (nomineeReader.Read())
                //        {
                //            if (!nomineeReader.IsDBNull(0)) { PAYSTATUS = nomineeReader.GetString(0); }
                //            if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                //        }
                //        nomineeReader.Close();
                //    }
                //}
                //else if (recipient.Equals("NOM"))
                //{
                //    string nomSelect = "select PAYSTATUS, VOUSTA from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                //    if (dm.existRecored(nomSelect) != 0)
                //    {
                //        dm.readSql(nomSelect);
                //        OracleDataReader nomineeReader = dm.oraComm.ExecuteReader();
                //        while (nomineeReader.Read())
                //        {
                //            if (!nomineeReader.IsDBNull(0)) { PAYSTATUS = nomineeReader.GetString(0); }
                //            if ((PAYSTATUS.Equals("OK")) || (PAYSTATUS.Equals("PN")) || (PAYSTATUS.Equals("NO"))) { autCount++; }
                //        }
                //        nomineeReader.Close();

                //    }
                //}
                #endregion
                                       
                if ((recipient == null) || (recipient.Equals("")))
                {
                    this.btnConf.Visible = true;
                    this.btnReject.Visible = false;
                }
                else 
                {
                    this.ddlReciepients.SelectedIndex = this.index(recipient);
                    //this.ddlLow.SelectedIndex = this.lowindex(low);

                    this.btnConf.Visible = false;
                    this.btnReject.Visible = true;
                }

                    //if (this.ddlReciepients.SelectedItem.Value.Equals("LHI"))
                    //{
                    //    this.ddlLow.Enabled = true;
                    //}
                    //else
                    //{
                    //    this.ddlLow.Enabled = false;
                    //}

                            if (payAutDate > 0)
                            {
                                this.btnConf.Enabled = false;
                                this.btnReject.Enabled = false;
                            }                            
                            else if (autCount > 0)
                            {
                                this.btnConf.Enabled = false;
                                this.btnReject.Enabled = false;
                            }
                            else
                            {
                                this.btnConf.Enabled = true;
                                this.btnReject.Enabled = true;
                            }

                #endregion

                dm.connclose();

                ViewState["claimno"] = claimno;
                ViewState["recipient"] = recipient;
                ViewState["low"] = low;
                ViewState["recipient02"] = recipient02;
                ViewState["low02"] = low02;
                ViewState["totamount"] = totamount;
                ViewState["netClaim"] = netClaim;
                ViewState["outAmt"] = outAmt;
                ViewState["exgraciaAmt"] = exgraciaAmt;
                ViewState["payAutDate"] = payAutDate;
                ViewState["dtofdth"] = dtofdth;
                ViewState["pageflag"] = pageflag;
                ViewState["tbl"] = tbl;
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {            
            polno = (long)ViewState["polnoint"];
            MOF = (string)ViewState["MOFstr"];
            //this.displayMeth(polno, MOF);   

            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["recipient"] != null) { recipient = ViewState["recipient"].ToString(); }
            if (ViewState["recipient02"] != null) { recipient02 = ViewState["recipient02"].ToString(); }
            //if (ViewState["low"] != null) { low = ViewState["low"].ToString(); }
            //if (ViewState["low02"] != null) { low02 = ViewState["low02"].ToString(); }
            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["netClaim"] != null) { netClaim = double.Parse(ViewState["netClaim"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["exgraciaAmt"] != null) { exgraciaAmt = double.Parse(ViewState["exgraciaAmt"].ToString()); }
            if (ViewState["payAutDate"] != null) { payAutDate = int.Parse(ViewState["payAutDate"].ToString()); }
            if (ViewState["dtofdth"] != null) { dtofdth = int.Parse(ViewState["dtofdth"].ToString()); }
            if (ViewState["pageflag"] != null) { pageflag = int.Parse(ViewState["pageflag"].ToString()); }
            if (ViewState["tbl"] != null) { tbl = int.Parse(ViewState["tbl"].ToString()); }
        }
        
    }

    protected void ddlReciepients_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (this.ddlReciepients.SelectedItem.Value.Equals("LHI"))
        //{
        //    this.ddlLow.Enabled = true;
        //}
        //else
        //{
        //    this.ddlLow.Enabled = false;
        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {           
            recipient02 = this.ddlReciepients.SelectedItem.Value;
            //low02 = this.ddlLow.SelectedItem.Value;
            if ((this.txttotPay.Text != null) && (!this.txttotPay.Text.Equals(""))) { totamount = double.Parse(this.txttotPay.Text); } else { totamount = 0; }
            if ((this.txtexpay.Text != null) && (!this.txtexpay.Text.Equals(""))) { exgraciaAmt = double.Parse(this.txtexpay.Text); } else { exgraciaAmt = 0; }

            //Server.Transfer("", true);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnConf_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        bool b = false;
        try
        {           
            if (payAutDate == 0)
            {               
                dm.begintransaction();
                string dthrefSel = "select PAYEE from lphs.dthref where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                if (dm.existRecored(dthrefSel) != 0)
                {
                    dm.readSql(dthrefSel);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { recipient = dthrefReader.GetString(0); } else { recipient = ""; }
                    }
                    //dthrefReader.Close();
                    //dthrefReader.Dispose();

                    if ((recipient == null) || (recipient.Equals("")))
                    {
                        b = this.checkDetailAvailability(recipient);
                        this.btnConf.Visible = false;
                        this.btnReject.Visible = true;

                        recipient = this.ddlReciepients.SelectedItem.Value;
                        //low = this.ddlLow.SelectedItem.Value;
                        totamount = double.Parse(this.txttotPay.Text);

                        //----------------- comparing net claim with total pay amount ------------

                        if (totamount > netClaim)
                        {
                            //???????????????????????
                            this.lblalert.Text = "Total Amount Greater than Net Claim ";
                        }
                        else { outAmt += (netClaim - totamount); }

                        string dthrefUPD = "update lphs.dthref set PAYEE ='" + recipient + "', DLOW = '" + low + "', TOTPAYAMT =" + totamount + ", AMTOUT = " + outAmt + " where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                        dm.insertRecords(dthrefUPD);
                        this.lblsuccess.Text = "Details Confirmed!";

                    }
                    else
                    {
                        string recipient2 = this.ddlReciepients.SelectedItem.Value;
                        b = this.checkDetailAvailability(recipient2);

                        if (!recipient2.Equals(recipient))
                        {
                            //low = this.ddlLow.SelectedItem.Value;
                            totamount = double.Parse(this.txttotPay.Text);
                            if (totamount > netClaim) { this.lblalert.Text = "Total Amount Greater than Net Claim "; }
                            else { outAmt += (netClaim - totamount); }
                            string dthrefUPD = "update lphs.dthref set PAYEE ='" + recipient2 + "', DLOW = '" + low + "', TOTPAYAMT =" + totamount + ", AMTOUT = " + outAmt + " where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                            dm.insertRecords(dthrefUPD);
                            this.lblsuccess.Text = "Details Confirmed!";
                        }

                        this.btnConf.Visible = false;
                        this.btnReject.Visible = true;
                    }

                    if (!b) { recipient = this.ddlReciepients.SelectedItem.Value; }
                }
                else
                {
                   // dm.rollback();
                    //dm.connClose();
                    throw new Exception("No Such DTHREF Record!");
                }
                dm.commit();
                dm.connClose();
            }
            else 
            {
                this.cv.IsValid = false;
                this.cv.Text = "Payment Already Authorized. Cannot Alter!";
            }           
        }
        catch (Exception ex)
        {
            dm.rollback();
            dm.connClose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        //--------- Redirecting to proper entry modules -----------

        dm.connclose();

       
        if (!b && recipient.Equals("LHI"))
        {
            Response.Redirect("legalHieres001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "&flag=PD&pageflag=1");
        }
        //..............Commet on 2008/07/18........Buddhika
        //else if (!b && recipient.Equals("ASI"))
        //{
        //    Response.Redirect("assignee001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "&flag=PD");
        //}
        //else if (!b && recipient.Equals("NOM"))
        //{
        //    Response.Redirect("nomDetEnt01.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "&flag=PD");
        //    //Response.Redirect("nomDetEnt01.aspx?polno="+polno);
        //}
        else if (!b && recipient.Equals("LPT"))
        {
            Response.Redirect("livingPrt001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "&flag=PD");
        }
        else { }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            if (payAutDate == 0)
            {
                
                //recipient = this.ddlReciepients.SelectedItem.Value;
                //low = this.ddlLow.SelectedItem.Value;
                //totamount = double.Parse(this.txttotPay.Text);

                string dthrefSel = "select PAYEE from lphs.dthref where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                if (dm.existRecored(dthrefSel) != 0)
                {
                    dm.readSql(dthrefSel);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { recipient = dthrefReader.GetString(0); } else { recipient = ""; }
                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();

                    if ((recipient == null) || (recipient.Equals("")))
                    {
                        this.btnConf.Visible = true;
                        this.btnReject.Visible = false;
                    }
                    else
                    {
                        string dthrefUpd = "update lphs.dthref set PAYEE ='', DLOW = '', TOTPAYAMT = 0, AMTOUT = 0  where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
                        dm.insertRecords(dthrefUpd);
                        this.lblsuccess.Text = "Details Rejected!";
                        this.btnConf.Visible = true;
                        this.btnReject.Visible = false;
                    }
                }
                else
                {
                    dm.connclose();
                    throw new Exception("No Such DTHREF Record!");
                }

                dm.connclose();
            }
            else {
                this.cv.IsValid = false;
                this.cv.Text = "Payment Already Authorized. Cannot Alter!";
            }
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

    }

    public long Polno {
        get { return polno; }
        set { polno = value; }
    }
    public string mof {
        get { return MOF; }
        set { MOF = value; }
    }
    public string Recipient {
        get { return recipient; }
        set { recipient = value; }
    }
    public string Low {
        get { return low; }
        set { low = value; }
    }
    public string Recipient02
    {
        get { return recipient02; }
        set { recipient02 = value; }
    }
    public string Low02
    {
        get { return low02; }
        set { low02 = value; }
    }
    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public double ExgraciaAmt
    {
        get { return exgraciaAmt; }
        set { exgraciaAmt = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public int TBL
    {
        get { return tbl; }
        set { tbl = value; }
    }
    protected int index(string s) {
        int inde = 0;
        if (s.Equals("LHI")) 
        {
            inde = 0;
        }
        else if (s.Equals("NOM"))
        {
            inde = 1;
        }
        else if (s.Equals("ASI"))
        {
            inde = 2;
        }
        else if (s.Equals("LPT"))
        {
            inde = 3;
        }
        else { }

        return inde;
    }

    protected int lowindex(string ss) {
        int inde = 0;
        if (ss.Equals("General"))
        {
            inde = 0;
        }
        else if (ss.Equals("Upcountry"))
        {
            inde = 1;
        }
        else if (ss.Equals("Moore"))
        {
            inde = 2;
        }
        else if (ss.Equals("Thesawalaamei"))
        {
            inde = 3;
        }
        else if (ss.Equals("Payment_To_Court"))
        {
            inde = 4;
        }
        else if (ss.Equals("Pay_To_Individual"))
        {
            inde = 5;
        }
        else { }

        return inde;
       
    }
    public int Pageflag
    {
        get { return pageflag; }
        set { pageflag = value; }
    }
    public int Dtofdth
    {
        get { return dtofdth; }
        set { dtofdth = value; }
    }

    protected bool checkDetailAvailability(string s) {
        bool boo = false;
        //dm = new DataManager();
        if (s.Equals("LHI"))
        {
            string LHIselect = "select * from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "'";
            if (dm.existRecored(LHIselect) != 0) { boo = true; }
        }
        else if (s.Equals("NOM"))
        {
            string NOMselect = "select * from lund.nominee where polno=" + polno + " ";
            if (dm.existRecored(NOMselect) != 0) { boo = true; }
        }
        else if (s.Equals("ASI"))
        {
            string ASIselect = "select * from LUND.ASSIGNEE where POLICY_NO =" + polno + " ";
            if (dm.existRecored(ASIselect) != 0) { boo = true; }
        }
        else if (s.Equals("LPT"))
        {
            string LPTselect = "select * from LUND.LIVING_PRT where POLNO = " + polno + " ";
            if (dm.existRecored(LPTselect) != 0) { boo = true; }
        }
      
        //dm.connclose();
        return boo;
    }

    protected void displayMeth(int pol, string MOFthing) {
        dm = new DataManager();
        string dthrefSel = "select dlow, payee, DRNETCLM from lphs.dthref where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' ";
        if (dm.existRecored(dthrefSel) != 0)
        {
            dm.readSql(dthrefSel);
            OracleDataReader dthrefReader = dm.oraComm.ExecuteReader();
            while (dthrefReader.Read())
            {
                if (!dthrefReader.IsDBNull(0)) { low = dthrefReader.GetString(0); }
                if (!dthrefReader.IsDBNull(1)) { recipient = dthrefReader.GetString(1); }
                if (!dthrefReader.IsDBNull(2)) { netClaim = dthrefReader.GetDouble(2); }
            }
            dthrefReader.Close();
        }       

        if ((recipient == null) || (recipient.Equals("")))
        {
            this.btnConf.Visible = true;
            this.btnReject.Visible = false;
        }
        else
        {
            this.ddlReciepients.SelectedIndex = this.index(recipient);
            //this.ddlLow.SelectedIndex = this.lowindex(low);

            this.btnConf.Visible = false;
            this.btnReject.Visible = true;
        }
        dm.connclose();    
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
}
