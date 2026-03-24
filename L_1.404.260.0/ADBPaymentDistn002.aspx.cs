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
using System.Collections.Generic;

public partial class ADBPaymentDistn002 : System.Web.UI.Page
{
    private long polno;
    private long clmno;
    private string married;
    private string heirer;
    private string mos;
    private double totamount;
    private double share;
    private double totshare;
    private int dob;
    private string heirename;
    private string ad1, ad2, ad3, ad4;
    private string epf;
    private double shareamt;
    private double tmpshareamt;
    private string recipient;

    private int heireNo;
    private string heire;
    private string heireName;
    private string heireAd;
    private int heireDOB; 
    private double heireAmount;
    private string mst;

    private bool assiPresent;
    private bool LPTpresent; 

    private string NOMNAME;
    private int DOB;
    private string NIC;
    private double PER;
    private int NOMNUM;
    private int flag;
    private int count;

    private double totPercentage;
    private double adbPercentage;
    private bool isADBPayee;
    private int isADBPayeeAuthorized;
    private string isADBPayeeReject;
    private double rejectPercentage;
    private string adbVouStatus;

    DataManager dm;
    LegalHiere Lh;
    private ArrayList arr;
    private ArrayList arrList; 
     
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
                totamount = this.PreviousPage.Totamount;
                recipient = this.PreviousPage.Recipient;
                 
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
                ViewState["totshare"] = totamount;
                ViewState["epf"] = epf;
                ViewState["shareamt"] = shareamt;
                ViewState["recipient"] = recipient;
                ViewState["clmno"] = clmno;
            }
            else
            {
                polno = long.Parse(ViewState["polno"].ToString());
                mos = ViewState["mos"].ToString();
                Lh = (LegalHiere)ViewState["Lh"];
                totshare = double.Parse(ViewState["totshare"].ToString());
                epf = ViewState["epf"].ToString();
                recipient = ViewState["recipient"].ToString();
                if (ViewState["tmpshareamt"] != null) { tmpshareamt = double.Parse(ViewState["tmpshareamt"].ToString()); }
                if (ViewState["shareamt"] != null) { shareamt = double.Parse(ViewState["shareamt"].ToString()); }
                if (ViewState["count"] != null) { count = int.Parse(ViewState["count"].ToString()); }
                if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
                if (ViewState["totshare"] != null) { totamount = double.Parse(ViewState["totshare"].ToString()); }
            }

            if ((recipient != null) && (!recipient.Equals("")))
            {
                //*************** Distributing According to Recipient *************
                string paystatus = "";
                int okcount = 0;
                int recCount = 0;
                rejectPercentage = 0;
                isADBPayeeReject = "N";

                arr = new ArrayList();
                arrList = new ArrayList();

                if (recipient.Equals("LHI") || recipient.Equals("ML") || recipient.Equals("SL"))
                {
                    double shareamttmp;
                    double percentage;
                    #region
                    string heireSelect = "select lhhno, lhhire, lhmst, lhname, lhad1, lhdob, LHPAYST, lhshare, lhamount, IS_ADBREJECT, ADBVOUSTA from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + mos + "'  ";
                    if (dm.existRecored(heireSelect) != 0)
                    {
                        dm.readSql(heireSelect);
                        OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (heireSelectReader.Read())
                        {
                            string[] hireDet = new string[6];
                            string[] shareArray = new string[8];

                            heireNo = heireSelectReader.GetInt32(0);
                            if (!heireSelectReader.IsDBNull(1)) { heire = heireSelectReader.GetString(1); } else { heire = ""; }
                            if (!heireSelectReader.IsDBNull(2)) { mst = heireSelectReader.GetString(2); } else { mst = ""; }
                            if (!heireSelectReader.IsDBNull(3)) { heireName = heireSelectReader.GetString(3); } else { heireName = ""; }
                            if (!heireSelectReader.IsDBNull(4)) { heireAd = heireSelectReader.GetString(4); } else { heireAd = ""; }
                            if (!heireSelectReader.IsDBNull(5)) { heireDOB = heireSelectReader.GetInt32(5); } else { heireDOB = 0; }
                            if (!heireSelectReader.IsDBNull(6)) { paystatus = heireSelectReader.GetString(6); } else { paystatus = ""; }
                            if (!heireSelectReader.IsDBNull(7)) { share = heireSelectReader.GetDouble(7); } else { share = 0; }
                            if (!heireSelectReader.IsDBNull(8)) { heireAmount = heireSelectReader.GetDouble(8); } else { heireAmount = 0; }
                            if (!heireSelectReader.IsDBNull(9)) { isADBPayeeReject = heireSelectReader.GetString(9); } else { isADBPayeeReject = ""; }
                            if (!heireSelectReader.IsDBNull(10)) { adbVouStatus = heireSelectReader.GetString(10); } else { adbVouStatus = ""; }

                            #region------newly added by Dushan------
                            if (paystatus.Equals("OK")) { okcount++; }
                            recCount++;
                            totshare += share;
                            shareamttmp = Math.Truncate(Math.Round(share * totamount * 100, 4)) / 100;
                            percentage = share * 100;

                            string[] lhiArr = new string[6];
                            lhiArr[0] = heire;
                            lhiArr[1] = percentage.ToString();
                            lhiArr[2] = recCount.ToString();
                            lhiArr[3] = shareamttmp.ToString();
                            lhiArr[4] = heireNo.ToString();
                            lhiArr[5] = paystatus;

                            arr.Add(lhiArr);

                            createNomineeTable(heire, percentage.ToString(), recCount, heireNo, shareamttmp, paystatus, isADBPayee, isADBPayeeAuthorized, isADBPayeeReject, adbVouStatus);

                            #endregion

                            if (isADBPayeeReject == "Y")
                            {
                                rejectPercentage += percentage;
                            }
                        }
                        heireSelectReader.Close();
                        heireSelectReader.Dispose();
                        //if (totshare < 1 && 1-totshare>0.1)
                        //if (totshare < 1 && 1 - totshare > 0.01)
                        //{
                        //    this.cmdPayee.Visible = true;
                        //}
                    }
                    else
                    {
                        dm.connclose();
                        throw new Exception("No Heire Details!");
                    }
                    #endregion
                }
                else if (recipient.Equals("ASI"))
                {
                    #region

                    string ASS_STATUS = "";
                    string ASS_INITIAL = "";
                    string ASS_SURNAME = "";
                    string ASS_FULLNAME = "";
                    string ASS_SHORTNAME = "";
                    string ASS_AD1 = "";
                    string ASS_AD2 = "", ASS_AD3 = "";
                    long ACCT_NO = 0;
                    int rowNum = 0;

                    string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, PAYSTATUS, ASS_AD3, IS_ADBREJECT, ADBVOUSTA from LUND.ASSIGNEE  where POLICY_NO = " + polno + " ";
                    if (dm.existRecored(asiSelect) != 0)
                    {
                        assiPresent = true;
                        dm.readSql(asiSelect);
                        OracleDataReader prassReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (prassReader.Read())
                        {
                            rowNum++;
                            if (!prassReader.IsDBNull(0)) { ASS_STATUS = prassReader.GetString(0); } else { ASS_STATUS = ""; }
                            if (!prassReader.IsDBNull(1)) { ASS_INITIAL = prassReader.GetString(1); } else { ASS_INITIAL = ""; }
                            if (!prassReader.IsDBNull(2)) { ASS_SURNAME = prassReader.GetString(2); } else { ASS_SURNAME = ""; }
                            if (!prassReader.IsDBNull(3)) { ASS_FULLNAME = prassReader.GetString(3); } else { ASS_FULLNAME = ""; }
                            if (!prassReader.IsDBNull(4)) { ASS_SHORTNAME = prassReader.GetString(4); } else { ASS_SHORTNAME = ""; }
                            if (!prassReader.IsDBNull(5)) { ASS_AD1 = prassReader.GetString(5); } else { ASS_AD1 = ""; }
                            if (!prassReader.IsDBNull(6)) { ASS_AD2 = prassReader.GetString(6); } else { ASS_AD2 = ""; }
                            if (!prassReader.IsDBNull(7)) { ACCT_NO = prassReader.GetInt64(7); } else { ACCT_NO = 0; }
                            if (!prassReader.IsDBNull(8)) { paystatus = prassReader.GetString(8); } else { paystatus = ""; }
                            if (!prassReader.IsDBNull(9)) { ASS_AD3 = prassReader.GetString(9); } else { ASS_AD3 = ""; }
                            if (!prassReader.IsDBNull(10)) { isADBPayeeReject = prassReader.GetString(10); } else { isADBPayeeReject = ""; }
                            if (!prassReader.IsDBNull(11)) { adbVouStatus = prassReader.GetString(11); } else { adbVouStatus = ""; }

                            if (paystatus.Equals("OK")) { okcount++; }
                            recCount++;
                            string name01 = ASS_STATUS + " " + ASS_FULLNAME;
                            string addre = ASS_AD1 + " " + ASS_AD2;

                            this.createASItable(name01, ASS_FULLNAME, ASS_SHORTNAME, addre, ACCT_NO.ToString(), rowNum, paystatus, adbVouStatus);

                            if (isADBPayeeReject == "Y")
                            {
                                rejectPercentage = 100;
                            }
                        }
                        prassReader.Close();
                        prassReader.Dispose();

                    }

                    #endregion
                }
                else if (recipient.Equals("NOM"))
                {
                    #region

                    double nomiShare = 0;
                    string nomSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER, PAYSTATUS, IS_ADBREJECT, ADBVOUSTA from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                    if (dm.existRecored(nomSelect) != 0)
                    {
                        dm.readSql(nomSelect);
                        OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (nomineeReader.Read())
                        {
                            if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); } else { NOMNAME = ""; }
                            if (!nomineeReader.IsDBNull(2)) { DOB = nomineeReader.GetInt32(2); } else { DOB = 0; }
                            if (!nomineeReader.IsDBNull(3)) { NIC = nomineeReader.GetString(3); } else { NIC = ""; }
                            if (!nomineeReader.IsDBNull(4)) { PER = nomineeReader.GetDouble(4); } else { PER = 0.00; }
                            if (!nomineeReader.IsDBNull(5)) { paystatus = nomineeReader.GetString(5); } else { paystatus = ""; }
                            if (!nomineeReader.IsDBNull(6)) { isADBPayeeReject = nomineeReader.GetString(6); } else { isADBPayeeReject = ""; }
                            if (!nomineeReader.IsDBNull(7)) { adbVouStatus = nomineeReader.GetString(7); } else { adbVouStatus = ""; }
                            NOMNUM = nomineeReader.GetInt32(0);

                            if (paystatus.Equals("OK")) { okcount++; }
                            recCount++;
                            totPercentage += PER;

                            nomiShare = PER * totamount;
                            nomiShare = Math.Round(nomiShare, 4);
                            nomiShare = Math.Truncate(nomiShare);
                            nomiShare = nomiShare / 100;
                            string[] nomArr = new string[8];
                            nomArr[0] = NOMNAME;
                            nomArr[1] = DOB.ToString();
                            nomArr[2] = NIC;
                            nomArr[3] = PER.ToString();
                            nomArr[4] = NOMNUM.ToString();
                            nomArr[5] = nomiShare.ToString();
                            nomArr[6] = paystatus;
                            nomArr[7] = isADBPayeeReject;

                            arrList.Add(nomArr);
                            //createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM);
                        }
                        nomineeReader.Close();
                        nomineeReader.Dispose();

                        if (totPercentage > 100)
                        {
                            dm.connclose();
                            throw new Exception("Please Adjust the Nominee Percentages so that Total Equals 100%");
                        }
                        else if (totPercentage < 100) { this.lblMessage.Text = "Total Percentage doesn't Add Up to Make 100%"; }

                        int rows3 = 0;
                        foreach (string[] nomArr in arrList)
                        {
                            rows3++;

                            if (!nomArr[0].Equals(null) && !nomArr[0].Equals("")) { NOMNAME = nomArr[0]; }
                            if (!nomArr[1].Equals(null) && !nomArr[1].Equals("")) { DOB = int.Parse(nomArr[1]); }
                            if (!nomArr[2].Equals(null) && !nomArr[2].Equals("")) { NIC = nomArr[2]; }
                            if (!nomArr[3].Equals(null) && !nomArr[3].Equals("")) { PER = double.Parse(nomArr[3]); }
                            if (!nomArr[4].Equals(null) && !nomArr[4].Equals("")) { NOMNUM = int.Parse(nomArr[4]); }
                            if (!nomArr[5].Equals(null) && !nomArr[5].Equals("")) { nomiShare = double.Parse(nomArr[5]); }
                            if (!nomArr[6].Equals(null) && !nomArr[6].Equals("")) { paystatus = nomArr[6]; }
                            if (!nomArr[7].Equals(null) && !nomArr[7].Equals("")) { isADBPayeeReject = nomArr[7]; } else { isADBPayeeReject = "N"; }

                            createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM, nomiShare, paystatus, isADBPayee, isADBPayeeAuthorized, isADBPayeeReject, adbVouStatus);

                            if (isADBPayeeReject == "Y")
                            {
                                rejectPercentage += PER;
                            }
                        }                        
                    }
                    else
                    {

                    }

                    #endregion
                }
                else if (recipient.Equals("LPT"))
                {
                    #region
                    string NOMAD1 = "";
                    string NOMAD2 = "";
                    int incr = 0;

                    string living_prtSelect = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, PAYSTATUS, IS_ADBREJECT, ADBVOUSTA from LUND.LIVING_PRT where polno = " + polno + "  ";
                    if (dm.existRecored(living_prtSelect) != 0)
                    {
                        LPTpresent = true;
                        dm.readSql(living_prtSelect);
                        OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (nomineeReader.Read())
                        {
                            incr++;
                            if (!nomineeReader.IsDBNull(0)) { NOMNAME = nomineeReader.GetString(0); }
                            if (!nomineeReader.IsDBNull(1)) { DOB = nomineeReader.GetInt32(1); }
                            if (!nomineeReader.IsDBNull(2)) { NIC = nomineeReader.GetString(2); }
                            if (!nomineeReader.IsDBNull(3)) { PER = nomineeReader.GetInt32(3); }
                            if (!nomineeReader.IsDBNull(4)) { NOMAD1 = nomineeReader.GetString(4); }
                            if (!nomineeReader.IsDBNull(5)) { NOMAD2 = nomineeReader.GetString(5); }
                            if (!nomineeReader.IsDBNull(6)) { paystatus = nomineeReader.GetString(6); }
                            if (!nomineeReader.IsDBNull(7)) { isADBPayeeReject = nomineeReader.GetString(7); }
                            if (!nomineeReader.IsDBNull(8)) { adbVouStatus = nomineeReader.GetString(8); }

                            if (paystatus.Equals("OK")) { okcount++; }
                            recCount++;
                            string addr = NOMAD1 + " " + NOMAD2;

                            this.createLPTtable(NOMNAME, NIC, DOB, addr, incr, paystatus, isADBPayeeReject, adbVouStatus);

                            if (isADBPayeeReject == "Y")
                            {
                                rejectPercentage += PER;
                            }
                        }
                        nomineeReader.Close();
                        nomineeReader.Dispose();
                    }

                    #endregion
                }

                #region ---------------ADB payee------------------
                double heirePercentage;
                string adbHeireSelect = "select PAYEENO, NEW_PAYEE, PAYEENAME, PAYEEAD1, PAYEEDOB, PAYEEMST, PAYEESHARE, PAYEEAMOUNT, ISPAYEEAUTHO, ISPAYEEREJECT, VOUST from LPHS.DTH_ADBPAYMENT_DISTN where POLICY_NO=" + polno + " and MOS='" + mos + "' and CLAIM_NO=" + clmno + "  ";

                if (dm.existRecored(adbHeireSelect) != 0)
                {
                    isADBPayee = true;
                    dm.readSql(adbHeireSelect);
                    OracleDataReader adbheireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (adbheireSelectReader.Read())
                    {
                        string[] hireDet = new string[6];
                        string[] shareArray = new string[8];

                        heireNo = adbheireSelectReader.GetInt32(0);
                        if (!adbheireSelectReader.IsDBNull(1)) { heire = adbheireSelectReader.GetString(1); } else { heire = ""; }
                        if (!adbheireSelectReader.IsDBNull(2)) { heireName = adbheireSelectReader.GetString(2); } else { heireName = ""; }
                        if (!adbheireSelectReader.IsDBNull(3)) { heireAd = adbheireSelectReader.GetString(3); } else { heireAd = ""; }
                        if (!adbheireSelectReader.IsDBNull(4)) { heireDOB = adbheireSelectReader.GetInt32(4); } else { heireDOB = 0; }
                        if (!adbheireSelectReader.IsDBNull(5)) { paystatus = adbheireSelectReader.GetString(5); } else { paystatus = ""; }
                        if (!adbheireSelectReader.IsDBNull(6)) { share = adbheireSelectReader.GetDouble(6); } else { share = 0; }
                        if (!adbheireSelectReader.IsDBNull(7)) { heireAmount = adbheireSelectReader.GetDouble(7); } else { heireAmount = 0; }
                        if (!adbheireSelectReader.IsDBNull(8)) { isADBPayeeAuthorized = adbheireSelectReader.GetInt32(8); } else { isADBPayeeAuthorized = 0; }
                        if (!adbheireSelectReader.IsDBNull(9)) { isADBPayeeReject = adbheireSelectReader.GetString(9); } else { isADBPayeeReject = ""; }
                        if (!adbheireSelectReader.IsDBNull(10)) { adbVouStatus = adbheireSelectReader.GetString(10); } else { adbVouStatus = ""; }

                        heirePercentage = share * 100;
                        recCount++;

                        createADBPayeeTable(heire, heirePercentage.ToString(), recCount, heireNo, heireAmount, paystatus, isADBPayee, isADBPayeeAuthorized, isADBPayeeReject, adbVouStatus);

                        //if (isADBPayeeReject == "Y")
                        //{
                        //    rejectPercentage += heirePercentage;
                        //}
                        //else
                        //{
                        //    adbPercentage += heirePercentage;
                        //}
                        if (isADBPayeeReject == "N" || isADBPayeeReject == "")
                        {
                            adbPercentage += heirePercentage;
                        }
                    }
                    adbheireSelectReader.Close();
                    adbheireSelectReader.Dispose();
                }
                #endregion

                count = recCount;
            }

            //this.lblBalanceshare.Text = Convert.ToString((1 - totshare) * 100) + "% ";
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
        double percentage, shareAmt;
        share = double.Parse(this.txtShare.Text.Trim()) / 100;


        //if ((1 - (totshare + tmpshareamt)) < share)
        //{
        //    this.lblMessage.Visible = true;
        //    this.lblBalanceshare.Text = Convert.ToString((1 - totshare - tmpshareamt) * 100) + "% ";
        //}
        //else
        //{
            try
            {
                dm = new DataManager();
                dm.begintransaction();
                                
                isADBPayee = true;
                isADBPayeeReject = "N";
                adbVouStatus = "N";
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

                percentage = share * 100;
                shareAmt = totamount * share;

                Lh.ADBLegalHiere(polno, mos, dm);
                Lh.ADBLhinsert(polno, mos, clmno, recipient, heirer, heirename, ad1, ad2, ad3, ad4, dob, married, share, shareAmt, epf, ip, dm);
                //this.lblBalanceshare.Text = Convert.ToString((1 - totshare - tmpshareamt) * 100) + "% ";
                count++;
                createADBPayeeTable(heirer, percentage.ToString(), count, heireNo, shareAmt, "OK", isADBPayee, isADBPayeeAuthorized, isADBPayeeReject, adbVouStatus);
                adbPercentage += percentage;

                if ((tmpshareamt * 100) > rejectPercentage || (adbPercentage > rejectPercentage))
                {
                    dm.connclose();
                    throw new Exception("Please Adjust the Payee Percentages so that Total Equals 100%");
                }

                ViewState["tmpshareamt"] = tmpshareamt;
                ViewState["count"] = count;
                dm.commit();
                dm.connclose();
            }
            catch (Exception Ex)
            {
                dm.connClose();
                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        //}
    }
    protected void cmdMore_Click(object sender, EventArgs e)
    {
        //this.lblBalanceshare.Text = Convert.ToString((1 - totshare - tmpshareamt) * 100) + "% ";
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
        Response.Redirect("ADBPaymentDistn001.aspx?polno=" + polno + "&totamount=" + shareamt + "&claimno=" + clmno + "&theMof=" + mos + "");
    }
    protected void ddlHeiretype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlHeiretype.SelectedValue.Equals("Mother")) || (ddlHeiretype.SelectedValue.Equals("Father")) || (ddlHeiretype.SelectedValue.Equals("Spouce")))
        {
            this.ddlMarried.SelectedValue = "M";
            this.ddlMarried.Enabled = false;
        }
    }

    private void createNomineeTable(string nominee, string percentage, int rowNumber, int nomnum, double theShare, string payst, bool isadbPayee, int isadbPayeeAuthorized, string isadbPayeeReject, string adbVouSt)
    {
        TableRow trow = new TableRow();
        TableCell tcell0 = new TableCell();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        tcell5.Style["color"] = "red";
        tcell5.Style["font-weight"] = "bold";

        Label lbl0 = new Label();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
        CheckBox chk01 = new CheckBox();

        lbl0.ID = "nomnum" + rowNumber;
        lbl0.Attributes.Add("runat", "Server");
        lbl0.Attributes.Add("Name", "nomnum" + rowNumber); //Text Value
        lbl0.Text = nomnum.ToString();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "percentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
        lbl2.Text = percentage + "%";

        lbl3.ID = "theShare" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "theShare" + rowNumber); //Text Value
        lbl3.Text = String.Format("{0:N}", theShare);

        chk01.ID = "chk" + rowNumber;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + rowNumber); //Text Value      

        lbl4.ID = "isadbPayeeReject" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "isadbPayeeReject" + rowNumber); //Text Value

        if (payst.Equals("OK"))
        {
            chk01.Checked = true;
            //chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (isadbPayee && isadbPayeeAuthorized == 1)
        {
            chk01.Checked = true;
        }

        if (isadbPayeeReject.Equals("Y"))
        {
            chk01.Checked = false;
            chk01.Enabled = false;
            lbl4.Text = "Canceled";
        }

        if (adbVouSt.Equals("Y") && (isadbPayeeReject.Equals("N") || isadbPayeeReject.Equals("")))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }

        tcell0.Controls.Add(lbl0);
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(chk01);
        tcell5.Controls.Add(lbl4);

        trow.Cells.Add(tcell0);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);
        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell5);

        Table1.Rows.Add(trow);
    }

    private void createADBPayeeTable(string nominee, string percentage, int rowNumber, int nomnum, double theShare, string payst, bool isadbPayee, int isadbPayeeAuthorized, string isadbPayeeReject, string adbVouSt)
    {
        TableRow trow = new TableRow();
        TableCell tcell0 = new TableCell();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();
        tcell5.Style["color"] = "red";
        tcell5.Style["font-weight"] = "bold";

        Label lbl0 = new Label();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
        CheckBox chk01 = new CheckBox();

        lbl0.ID = "nomnum" + rowNumber;
        lbl0.Attributes.Add("runat", "Server");
        lbl0.Attributes.Add("Name", "nomnum" + rowNumber); //Text Value
        lbl0.Text = nomnum.ToString();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "percentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
        lbl2.Text = percentage + "%";

        lbl3.ID = "theShare" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "theShare" + rowNumber); //Text Value
        lbl3.Text = String.Format("{0:N}", theShare);

        chk01.ID = "chk" + rowNumber;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + rowNumber); //Text Value      

        lbl4.ID = "isadbPayeeReject" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "isadbPayeeReject" + rowNumber); //Text Value

        if (payst.Equals("OK"))
        {
            chk01.Checked = true;
            //chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (isadbPayee && isadbPayeeAuthorized == 1)
        {
            chk01.Checked = true;
        }

        if (isadbPayeeReject.Equals("Y"))
        {
            chk01.Checked = false;
            chk01.Enabled = false;
            lbl4.Text = "Canceled";
        }

        if (adbVouSt.Equals("Y") && (isadbPayeeReject.Equals("N") || isadbPayeeReject.Equals("")))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }

        tcell0.Controls.Add(lbl0);
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(chk01);
        tcell5.Controls.Add(lbl4);

        trow.Cells.Add(tcell0);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);
        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell5);

        Table2.Rows.Add(trow);
    }

    private void createLPTtable(string name, string nic, int dob, string ad, int count, string payst, string isadbPayeeReject, string adbVouSt)
    {
        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();
        TableRow trow06 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel21 = new TableCell();
        TableCell tcel22 = new TableCell();
        TableCell tcel31 = new TableCell();
        TableCell tcel32 = new TableCell();
        TableCell tcel41 = new TableCell();
        TableCell tcel42 = new TableCell();
        TableCell tcel51 = new TableCell();
        TableCell tcel52 = new TableCell();
        TableCell tcel61 = new TableCell();
        TableCell tcel62 = new TableCell();
        tcel62.Style["color"] = "red";
        tcel62.Style["font-weight"] = "bold";

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl32 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl61 = new Label();
        Label lbl62 = new Label();
        CheckBox chk01 = new CheckBox();
        chk01.ID = "chk0" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk0" + count); //Text Value  
        if (payst.Equals("OK") || adbVouSt.Equals("Y"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (isadbPayeeReject.Equals("Y"))
        {
            chk01.Checked = false;
            chk01.Enabled = false;
            lbl62.Text = "Canceled";
        }

        lbl11.ID = "nameDesc" + count;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "nameDesc" + count); //Text Value
        lbl11.Text = "Living Partner's Name : ";

        lbl12.ID = "name" + count;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "name" + count); //Text Value
        lbl12.Text = name;

        lbl21.ID = "nicDesc" + count;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "nicDesc" + count); //Text Value
        lbl21.Text = "NIC Number : ";

        lbl22.ID = "nic" + count;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "nic" + count); //Text Value
        lbl22.Text = nic;

        lbl31.ID = "dobDesc" + count;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "dobDesc" + count); //Text Value
        lbl31.Text = "Date of Birth : ";

        lbl32.ID = "dob" + count;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "dob" + count); //Text Value
        if (dob.ToString().Length == 8)
        {
            lbl32.Text = dob.ToString().Substring(0, 4) + "/" + dob.ToString().Substring(4, 2) + "/" + dob.ToString().Substring(6, 2);
        }

        lbl41.ID = "adddesc" + count;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "adddesc" + count); //Text Value
        lbl41.Text = "Address : ";

        lbl42.ID = "ad" + count;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "ad" + count); //Text Value
        lbl42.Text = ad;

        lbl51.ID = "payst" + count;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "payst" + count); //Text Value
        lbl51.Text = "Payment OK : ";

        lbl61.ID = "isadbPayeeReject" + count;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "isadbPayeeReject" + count); //Text Value
        lbl61.Text = "Status : ";

        lbl62.ID = "status" + count;
        lbl62.Attributes.Add("runat", "Server");
        lbl62.Attributes.Add("Name", "status" + count); //Text Value

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);
        tcel32.Controls.Add(lbl32);
        tcel41.Controls.Add(lbl41);
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);
        tcel52.Controls.Add(chk01);
        tcel61.Controls.Add(lbl61);
        tcel62.Controls.Add(lbl62);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow02.Cells.Add(tcel21);
        trow02.Cells.Add(tcel22);
        trow03.Cells.Add(tcel31);
        trow03.Cells.Add(tcel32);
        trow04.Cells.Add(tcel41);
        trow04.Cells.Add(tcel42);
        trow05.Cells.Add(tcel51);
        trow05.Cells.Add(tcel52);
        trow06.Cells.Add(tcel61);
        trow06.Cells.Add(tcel62);

        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
        Table1.Rows.Add(trow06);
    }

    private void createASItable(string name, string fullname, string shortname, string address, string acctno, int rowno, string payst, string adbVouSt)
    {
        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();
        TableRow trow06 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel21 = new TableCell();
        TableCell tcel22 = new TableCell();
        TableCell tcel31 = new TableCell();
        TableCell tcel32 = new TableCell();
        TableCell tcel41 = new TableCell();
        TableCell tcel42 = new TableCell();
        TableCell tcel51 = new TableCell();
        TableCell tcel52 = new TableCell();
        TableCell tcel61 = new TableCell();
        TableCell tcel62 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl32 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl52 = new Label();
        Label lbl61 = new Label();
        CheckBox chk01 = new CheckBox();
        chk01.ID = "chk0" + rowno;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk0" + rowno); //Text Value  
        if (payst.Equals("OK"))
        {
            chk01.Checked = true;
            //chk01.Enabled = false;
        }
        else
        {
            chk01.Checked = false;
            chk01.Enabled = true;
        }

        if (adbVouSt.Equals("Y"))
        {
            chk01.Checked = true;
            chk01.Enabled = false;
        }

        lbl11.ID = "nameDesc" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "nameDesc" + rowno); //Text Value
        lbl11.Text = "Assignee Name : ";

        lbl12.ID = "name" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "name" + rowno); //Text Value
        lbl12.Text = name;

        lbl21.ID = "fullnameDesc" + rowno;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "fullnameDesc" + rowno); //Text Value
        lbl21.Text = "Full Name : ";

        lbl22.ID = "fullname" + rowno;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "fullname" + rowno); //Text Value
        lbl22.Text = fullname;

        lbl31.ID = "shortnameDesc" + rowno;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "shortnameDesc" + rowno); //Text Value
        lbl31.Text = "Short Name : ";

        lbl32.ID = "shortname" + rowno;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "shortname" + rowno); //Text Value
        lbl32.Text = shortname;

        lbl41.ID = "adddesc" + rowno;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "adddesc" + rowno); //Text Value
        lbl41.Text = "Address : ";

        lbl42.ID = "address" + rowno;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "address" + rowno); //Text Value
        lbl42.Text = address;

        lbl51.ID = "acctnoDesc" + rowno;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "acctnoDesc" + rowno); //Text Value
        lbl51.Text = "Account No. : ";

        lbl52.ID = "acctno" + rowno;
        lbl52.Attributes.Add("runat", "Server");
        lbl52.Attributes.Add("Name", "acctno" + rowno); //Text Value
        lbl52.Text = acctno;

        lbl61.ID = "payst" + rowno;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "payst" + rowno); //Text Value
        lbl61.Text = "Payment OK : ";

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);
        tcel32.Controls.Add(lbl32);
        tcel41.Controls.Add(lbl41);
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);
        tcel52.Controls.Add(lbl52);
        tcel61.Controls.Add(lbl61);
        tcel62.Controls.Add(chk01);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow02.Cells.Add(tcel21);
        trow02.Cells.Add(tcel22);
        trow03.Cells.Add(tcel31);
        trow03.Cells.Add(tcel32);
        trow04.Cells.Add(tcel41);
        trow04.Cells.Add(tcel42);
        trow05.Cells.Add(tcel51);
        trow05.Cells.Add(tcel52);
        trow06.Cells.Add(tcel61);
        trow06.Cells.Add(tcel62);

        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
        Table1.Rows.Add(trow06);
    }
     
}
