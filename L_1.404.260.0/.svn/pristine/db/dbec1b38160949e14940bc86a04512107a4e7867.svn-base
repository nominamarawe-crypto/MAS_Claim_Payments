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

public partial class OldClaimsEdit002 : System.Web.UI.Page
{
    private long polno;
    private string mos;
    private int clmno;
    private int disType;
    private string intimno;
    private double dsum;
    private double payamt;
    private int paymode;
    private int npdue;
    private string paynam;
    private string bankname;
    private string branchname;
    private string acctno;
    private string ad1, ad2, ad3, ad4;
    private string clmstatus;
    private string slicacctno;
    private double paybal;
    private int entrytype;
    private int insertflag = 0;
    private int dtofacc;
    private int paystdt;
    private int payendt;
    private int matdate;
    private int com;
    private int term;
    
    DataManager dm;
    //diaMasRead dmr;
    //DissabilityTypesRead dtr;
    DateDifference dd;
    //polMasRead pmr;

    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    dm = new DataManager();            
        //    dtr = new DissabilityTypesRead();
        //    if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //    {
        //        polno = this.PreviousPage.Polno;
        //        mos = this.PreviousPage.mos;
        //        disType = int.Parse(this.PreviousPage.DisType);
        //        intimno = this.PreviousPage.Intimno;
        //    }
        //    if (!Page.IsPostBack)
        //    {
        //        this.ddlSlicacctno.Items.Add(new ListItem("1030001487", "1030001487"));
        //        this.ddlSlicacctno.Items.Add(new ListItem("1364403002", "1364403002"));

        //        this.ddlPaymode.Items.Add(new ListItem("Yearly", "1"));
        //        this.ddlPaymode.Items.Add(new ListItem("Half Yearly", "2"));
        //        this.ddlPaymode.Items.Add(new ListItem("Quarterly", "3"));
        //        this.ddlPaymode.Items.Add(new ListItem("Monthly", "4"));

        //        this.ddlMos.Items.Add(new ListItem("Main Life", "M"));
        //        this.ddlMos.Items.Add(new ListItem("Spuce", "S"));
        //        this.ddlMos.Items.Add(new ListItem("Second Life", "2"));
        //        this.ddlMos.Items.Add(new ListItem("Child", "C"));

        //        this.ddlClmstatus.Items.Add(new ListItem("Accepted", "ACCEPTED"));
        //        this.ddlClmstatus.Items.Add(new ListItem("Inforce", "INFORCE"));
        //        this.ddlClmstatus.Items.Add(new ListItem("Completed", "COMPLETED"));
        //        this.ddlClmstatus.Items.Add(new ListItem("Terminated", "TERMINATED"));

        //        dtr.Fetch(dm);
        //        this.ddlDistype.DataSource = dtr.DisabilityList;
        //        ddlDistype.DataBind();

        //        #region---------------Read Values-----------------------------
        //        string disamascount = "select POLICY_NO from LCLM.DISABLE_MAS where POLICY_NO=" + polno + " and MOS='" + mos + "' and INTIMNO='" + intimno + "'";
        //        if (dm.existRecored(disamascount) != 0)
        //        {
        //            insertflag = 1;
        //            dmr = new diaMasRead(int.Parse(polno.ToString()), disType.ToString(), mos, intimno, dm);
        //            //pmr = new polMasRead(int.Parse(polno.ToString()), dm);
        //            clmno = dmr.Claim_no;
        //            dsum = dmr.Dsum;
        //            payamt = dmr.Payamt;
        //            paymode = dmr.Paymode;
        //            npdue = dmr.Npdue;
        //            paynam = dmr.Payeename;
        //            bankname = dmr.Bnkname;
        //            branchname = dmr.Bnkbrn;
        //            acctno = dmr.Acctno;
        //            ad1 = dmr.Ad1;
        //            ad2 = dmr.Ad2;
        //            ad3 = dmr.Ad3;
        //            ad4 = dmr.Ad4;
        //            clmstatus = dmr.Clmstate;
        //            slicacctno = dmr.Slicacctno;
        //            paybal = dmr.Paybal;
        //            entrytype = dmr.Entrytype;
        //            dtofacc = dmr.Dtofaccident;
        //        }
        //        else
        //        {
        //            insertflag = 0;
        //            string premastsel = "select PMCOM, PMTRM  from LPHS.PREMAST where PMPOL=" + polno + " and PMCOD='F'";
        //            if (dm.existRecored(premastsel) != 0)
        //            {
        //                entrytype = 1;
        //                dm.readSql(premastsel);
        //                OracleDataReader premastreader = dm.oraComm.ExecuteReader();
        //                while (premastreader.Read())
        //                {
        //                    if (!premastreader.IsDBNull(0)) { com = premastreader.GetInt32(0); } else { com = 0; }
        //                    if (!premastreader.IsDBNull(1)) { term = premastreader.GetInt32(1); } else { term = 0; }
        //                }                        
        //                premastreader.Close();

        //                matdate = int.Parse(Convert.ToString(int.Parse(com.ToString().Substring(0, 4)) + term) + com.ToString().Substring(4, 4));
        //                string phnamesel = "select PNSTA, PNINT, PNSUR, PNAD1, PNAD2, PNAD3, PNAD4 from LPHS.PHNAME where PNPOL="+polno+"";
        //                if (dm.existRecored(phnamesel) != 0)
        //                {
        //                    dm.readSql(phnamesel);
        //                    OracleDataReader phnamereader = dm.oraComm.ExecuteReader();
        //                    while (phnamereader.Read())
        //                    {
        //                        paynam = phnamereader.GetString(0) + phnamereader.GetString(1) + phnamereader.GetString(2);
        //                        if (!phnamereader.IsDBNull(3)) { ad1 = phnamereader.GetString(3); } else { ad1 = ""; }
        //                        if (!phnamereader.IsDBNull(4)) { ad2 = phnamereader.GetString(4); } else { ad2 = ""; }
        //                        if (!phnamereader.IsDBNull(5)) { ad3 = phnamereader.GetString(5); } else { ad3 = ""; }
        //                        if (!phnamereader.IsDBNull(6)) { ad4 = phnamereader.GetString(6); } else { ad4 = ""; }
        //                    }
        //                    phnamereader.Close();
        //                }
        //                #region--------------------Claim no--------------------
        //                string maxclmnosel = "select max(CLMSEQ) from LCLM.DISABILITY_SEQ_CTRL where DIS_TYP='TD'";
        //                dm.readSql(maxclmnosel);
        //                OracleDataReader maxnoreader = dm.oraComm.ExecuteReader();
        //                maxnoreader.Read();
        //                clmno = maxnoreader.GetInt32(0);
        //                clmno++;                        
        //                #endregion
        //            }
        //        }
        //        #endregion

        //        #region---------------Print Values-----------------
        //        this.lblPolno.Text = polno.ToString();
        //        //this.lblTbl.Text = pmr.TBL.ToString();
        //        //this.lblTerm.Text = pmr.TRM.ToString();
        //        //this.lblTbl.Text = "";
        //        //this.lblTerm.Text = "";
        //        this.txtDtofacc.Text = dtofacc.ToString();
        //        this.txtClmno.Text = clmno.ToString();
        //        this.txtAcctno.Text = acctno;
        //        this.txtAd1.Text = ad1;
        //        this.txtAd2.Text = ad2;
        //        this.txtAd3.Text = ad3;
        //        this.txtAd4.Text = ad4;
        //        this.txtBnkbr.Text = branchname;
        //        this.txtBnknam.Text = bankname;
        //        this.txtNpdue.Text = npdue.ToString();
        //        this.txtPayamt.Text = payamt.ToString();
        //        this.txtPaybal.Text = paybal.ToString();
        //        this.txtPaynam.Text = paynam;
        //        this.txtSumass.Text = dsum.ToString();
        //        this.ddlPaymode.SelectedValue = paymode.ToString();
        //        this.ddlClmstatus.SelectedValue = clmstatus;
        //        this.ddlMos.SelectedValue = mos;
        //        this.ddlSlicacctno.SelectedValue = slicacctno;
        //        this.ddlDistype.SelectedValue = disType.ToString();
        //        #endregion

        //        ViewState["polno"] = polno;
        //        //ViewState["clmno"] = clmno;
        //        ViewState["entrytype"] = entrytype;
        //        ViewState["intimno"] = intimno;
        //        ViewState["insertflag"] = insertflag;
        //        ViewState["mos"] = mos;
        //        ViewState["matdate"] = matdate;
        //    }
        //    else
        //    {
        //        #region----------------------viewstate--------------
        //        if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
        //        //if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
        //        if (ViewState["entrytype"] != null) { entrytype = int.Parse(ViewState["entrytype"].ToString()); }
        //        if (ViewState["intimno"] != null) { intimno = ViewState["intimno"].ToString(); }
        //        if (ViewState["insertflag"] != null) { insertflag = int.Parse(ViewState["insertflag"].ToString()); }
        //        if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
        //        if (ViewState["matdate"] != null) { matdate = int.Parse(ViewState["matdate"].ToString()); }
        //        #endregion
        //    }
        //    if (entrytype == 0) { this.btnSubmit.Enabled = false; }
            
        //    dm.connClose();
        //}
        //catch (Exception Ex)
        //{
        //    dm.connClose();
        //    EPage.Messege = Ex.Message;
        //    Response.Redirect("~/EPage.aspx");
        //}
        //
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            dsum = double.Parse(this.txtSumass.Text.Trim());
            dtofacc = int.Parse(txtDtofacc.Text.Trim());
            payamt = double.Parse(this.txtPayamt.Text.Trim());
            paymode = int.Parse(this.ddlPaymode.SelectedValue);
            npdue = int.Parse(this.txtNpdue.Text.Trim());
            paynam = this.Filter(this.txtPaynam.Text.Trim());
            branchname = this.Filter(this.txtBnkbr.Text.Trim());
            clmno = int.Parse(txtClmno.Text.Trim());
            bankname = this.Filter(this.txtBnknam.Text.Trim());
            paybal = double.Parse(txtPaybal.Text.Trim());
            acctno = this.Filter(this.txtAcctno.Text.Trim());
            ad1 = this.Filter(this.txtAd1.Text.Trim());
            ad2 = this.Filter(this.txtAd2.Text.Trim());
            ad3 = this.Filter(this.txtAd3.Text.Trim());
            ad4 = this.Filter(this.txtAd4.Text.Trim());
            mos = this.ddlMos.SelectedValue;
            clmstatus = this.ddlClmstatus.SelectedValue;
            slicacctno = this.ddlSlicacctno.SelectedValue;
            disType = int.Parse(this.ddlDistype.SelectedValue);

            if (insertflag == 1)
            {
                string disablemsaupd = "update LCLM.DISABLE_MAS set DSUM=" + dsum + ", PAYAMT=" + payamt + ", PAYMODE=" + paymode + ", NPDUE=" + npdue + ", " +
                    "PAYEENAME='" + paynam + "', BNKBRN='" + branchname + "', BNKNAME='" + bankname + "', PAYMENT_BAL=" + paybal + ", ACCTNO='" + acctno + "', DTOFACCIDENT=" + dtofacc + ", "+
                    "AD1='" + ad1 + "', AD2='" + ad2 + "', AD3='" + ad3 + "', AD4='" + ad4 + "', MOS='" + mos + "', CLMSTATE='" + clmstatus + "', SLICACCTNO='" + slicacctno + "', " +
                    "DISABILITY_TYPE=" + disType + " where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
                dm.insertRecords(disablemsaupd);

                string periodicpaydel = "delete from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='" + intimno + "' and CLMTYPE='D' and (VONO is null or VONO='XXXX')";
                dm.insertRecords(periodicpaydel);
            }
            else
            {
                payendt = this.Payenddate(dtofacc);
                paystdt = this.Paystdate(dtofacc);

                string disamasinsert = "insert into LCLM.DISABLE_MAS(POLICY_NO, CLAIM_NO, PYMNT_ST_DT, DSUM, PAYAMT, PAYMODE, NPDUE, AD1, AD2, AD3, AD4, " +
                    "PAYEENAME, BNKBRN, BNKNAME, PAYMENT_BAL, ACCTNO, DISABILITY_TYPE, DTOFACCIDENT, PYMNT_END_DT, CLMSTATE, ENTRY_TYPE, MOS, INTIMNO, MGR_DECISION, MAT_DATE)" +
                    "values(" + polno + ", " + clmno + ", " + paystdt + ", " + dsum + ", " + payamt + ", " + paymode + ", " + npdue + ", '" + ad1 + "', '" + ad2 + "', '" + ad3 + "', '" + ad4 + "', " +
                    "'" + paynam + "', '" + branchname + "', '" + bankname + "', " + paybal + ", '" + acctno + "', " + disType + ", " +
                    "" + dtofacc + ", " + payendt + ", '" + clmstatus + "', 1, '" + mos + "', " + clmno + ", 'Y', " + matdate + ")";
                    
                dm.insertRecords(disamasinsert);

                string maxclmupd = "update LCLM.DISABILITY_SEQ_CTRL set CLMSEQ=" + clmno + " where DIS_TYP='TD'";
                dm.insertRecords(maxclmupd);
            }
            dm.commit();
            dm.connClose();
            this.btnSubmit.Enabled = false;
            Label1.Visible = true;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connClose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    public int Paystdate(int date)
    {
        int nextyr, nextmn;
        string mnthstr;
        nextyr = int.Parse(date.ToString().Substring(0, 4));
        nextmn = int.Parse(date.ToString().Substring(4, 2));
        nextmn++;
        if (nextmn == 13) { nextmn = 1; nextyr++; }
        if (nextmn < 10) { mnthstr = "0" + nextmn; }
        else { mnthstr = nextmn.ToString(); }
        return int.Parse(nextyr.ToString() + mnthstr + date.ToString().Substring(6, 2));
    }

    public int Payenddate(int date)
    {
        int nextyr;
        nextyr = int.Parse(date.ToString().Substring(0, 4));
        nextyr += 10;
        return int.Parse(nextyr.ToString() + date.ToString().Substring(4, 4));
    }
    public string Filter(string word)
    {
        word = word.Replace("'", " ");
        return word;
    }

    protected void btnCal_Click(object sender, EventArgs e)
    {
        int months, suffix;
        npdue = int.Parse(txtNpdue.Text.Trim());
        payamt = double.Parse(txtPayamt.Text.Trim());
        dtofacc = int.Parse(txtDtofacc.Text.Trim());
        payendt = this.Payenddate(dtofacc);
        paymode = int.Parse(this.ddlPaymode.SelectedValue);
        npdue=int.Parse(npdue.ToString()+dtofacc.ToString().Substring(6,2));
        dd = new DateDifference(npdue, payendt);
        months = dd.totMonths;
        if (paymode == 1) { suffix = 12; }
        else if (paymode == 2) { suffix = 6; }
        else if (paymode == 3) { suffix = 3; }
        else { suffix = 1; }
        months += suffix;
        paybal = payamt * months;
        this.txtPaybal.Text = paybal.ToString();
    }
}
