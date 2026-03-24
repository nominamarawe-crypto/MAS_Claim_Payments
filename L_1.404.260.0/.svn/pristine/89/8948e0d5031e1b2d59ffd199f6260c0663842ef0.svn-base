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

public partial class YastiyaDischargeSin : System.Web.UI.Page
{
    private long POlno;
    private string MOF;
    private string DNOD;
    private long claimno;
    private int table;
    private double netclaim;
    private int deathdate;
    DataManager dm;
    private int commdate;
    public string recipient = "";
    public string low = "";
    public string recipient02 = "";
    public string low02 = "";
    public string adbLatepay;

    public double netClaim;
    public double exgraciaAmt;
    public int payAutDate;
    public int interimBonStYr;
    public int PayeeAge;
    public double amtComyr = 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        if (PreviousPage != null)
        {
            POlno = PreviousPage.Polno;
            litpolno.Text = POlno.ToString();
            MOF = PreviousPage.mOF;
            netclaim = PreviousPage.Netclm;
            litamt.Text = netclaim.ToString("N2");
            deathdate = PreviousPage.Dateofdeath;
            litDateofDeath.Text = deathdate.ToString().Substring(0, 4) + "/" + deathdate.ToString().Substring(4, 2) + "/" + deathdate.ToString().Substring(6, 2);
            commdate = PreviousPage.cOM;
            litcomdt.Text = commdate.ToString().Substring(0, 4) + "/" + commdate.ToString().Substring(4, 2) + "/" + commdate.ToString().Substring(6, 2);
        }
        polMasRead policymaster = new polMasRead(int.Parse(POlno.ToString()), dm);
        table = policymaster.TBL;

        double netclm100 = 0;
        if (netclaim < 0) { netclm100 = 0; }
        else { netclm100 = (Math.Round(netclaim, 2) * 100); }
        if (netclm100 != 0)
        {
            string netclminwords = netclm100.ToString().Substring(0, (netclm100.ToString().Length - 2)) + "." + netclm100.ToString().Substring((netclm100.ToString().Length - 2), 2);
            readAmountFunction readamt = new readAmountFunction();
            this.litamt_inword.Text = readamt.readAmountSinhala(netclminwords, "YS% ,xld remsh,a", "Y; ");
        }
        else
        {
            this.litamt_inword.Text = "ZERO SRI LANKAN RUPEES AND ZERO CENTS ONLY";
        }

        if (!Page.IsPostBack)
        {
            string dthintSelect = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + POlno + " and DMOS ='" + MOF + "' ";
            if (dm.existRecored(dthintSelect) != 0)
            {
                dm.readSql(dthintSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                    if (!dthintReader.IsDBNull(1)) { claimno = dthintReader.GetInt64(1); }
                }
                dthintReader.Close();
                dthintReader.Dispose();
            }
            this.litdeceaseName.Text = DNOD;
            this.litdeceasename2.Text = DNOD;
            this.litclm.Text = claimno.ToString();
        
        string GetMainlife = "select PNSTA ||''||PNSUR as NAME from lphs.phname where PNPOL=" + POlno + "";
        if (dm.existRecored(GetMainlife) != 0)
        {
            dm.readSql(GetMainlife);
            OracleDataReader red = dm.oraComm.ExecuteReader();
            while (red.Read())
            {
                if (!red.IsDBNull(0)) { litpayeename.Text = red.GetString(0); }
            }
            red.Close();
        }

        #region //------------ payee details ------------

        int autCount = 0;
        //            int payAutCount = 0;
        string dthrefSel = "select dlow, payee, DRNETCLM, PAYAUTDT, DISTN_AUT, EXGRACIA_AMOUNT, INTBONSTYR, adb_latepay from lphs.dthref where  DRPOLNO=" + POlno + " and DRMOS='" + MOF + "' and DISTN_AUT > 0 and (payee is not null)";
        if (dm.existRecored(dthrefSel) != 0)
        {
            dm.readSql(dthrefSel);
            OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dthrefReader.Read())
            {
                if (!dthrefReader.IsDBNull(0)) { low = dthrefReader.GetString(0); } else { low = ""; }
                if (!dthrefReader.IsDBNull(1)) { recipient = dthrefReader.GetString(1); } else { recipient = ""; }
                if (!dthrefReader.IsDBNull(2)) { netClaim = dthrefReader.GetDouble(2); } else { netClaim = 0; }
                if (!dthrefReader.IsDBNull(3)) { payAutDate = dthrefReader.GetInt32(3); } else { payAutDate = 0; }
                if (!dthrefReader.IsDBNull(4)) { autCount = dthrefReader.GetInt32(4); } else { autCount = 0; }
                if (!dthrefReader.IsDBNull(5)) { exgraciaAmt = dthrefReader.GetInt32(5); } else { exgraciaAmt = 0; }
                if (!dthrefReader.IsDBNull(6)) { interimBonStYr = dthrefReader.GetInt32(6); } else { interimBonStYr = 0; }
                if (!dthrefReader.IsDBNull(7)) { adbLatepay = dthrefReader.GetString(7); } else { adbLatepay = ""; }

            }
            dthrefReader.Close();
            dthrefReader.Dispose();
        }


        string payeeName = "";
        string relationship = "";
        double payeeAmt = 0;
        int count = 0;
        double PER = 0;
        int DOB = 0;
        
        int affiNomiAssiLPTdat = 0;

        if (recipient.Equals("LHI"))
        {
            #region

            double theShare = 0;

            string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE,LHDOB from lphs.legal_hires where lhpolno=" + POlno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
            if (dm.existRecored(heireSelect) != 0)
            {
                dm.readSql(heireSelect);
                OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (heireSelectReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!heireSelectReader.IsDBNull(0)) { relationship = heireSelectReader.GetString(0); } else { relationship = ""; }
                    if (!heireSelectReader.IsDBNull(1)) { payeeName = heireSelectReader.GetString(1); } else { payeeName = ""; }
                    if (!heireSelectReader.IsDBNull(2)) { theShare = heireSelectReader.GetDouble(2); } else { theShare = 0; }
                    if (!heireSelectReader.IsDBNull(3)) { payeeAmt = heireSelectReader.GetDouble(3); } else { payeeAmt = 0; }
                    if (!heireSelectReader.IsDBNull(5)) { affiNomiAssiLPTdat = heireSelectReader.GetInt32(5); } else { affiNomiAssiLPTdat = 0; }
                    if (!heireSelectReader.IsDBNull(6)) { DOB = heireSelectReader.GetInt32(6); } else { DOB = 0; }


                    if (DOB != 0)
                    {
                        string yr = DOB.ToString().Substring(0, 4);
                        string mn = DOB.ToString().Substring(4, 2);
                        string dt = DOB.ToString().Substring(6, 2);

                        DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                        DateTime today = DateTime.Now;
                        TimeSpan diff = today.Subtract(Bdate);
                        PayeeAge = (int)diff.TotalDays / 365;
                        if (PayeeAge > 18)
                        {
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = relationship;
                            payeeDetArray[2] = "Affidavit";
                            payeeDetArray[3] = payeeAmt.ToString();
                            payeeDetArray[4] = (theShare * 100).ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();
                        }
                    }
                    else
                    {
                        payeeDetArray[0] = payeeName;
                        payeeDetArray[1] = relationship;
                        payeeDetArray[2] = "Affidavit";
                        payeeDetArray[3] = payeeAmt.ToString();
                        payeeDetArray[4] = (theShare * 100).ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();
                    }
                }
                heireSelectReader.Close();
                heireSelectReader.Dispose();
            }
            else
            {
                dm.connclose();
                throw new Exception("Payment not Yet Authorized or No Liable Payments");
            }

            #endregion
        }
        if (recipient.Equals("ML"))
        {
            #region

            double theShare = 0;

            string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + POlno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
            if (dm.existRecored(heireSelect) != 0)
            {
                dm.readSql(heireSelect);
                OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (heireSelectReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!heireSelectReader.IsDBNull(0)) { relationship = heireSelectReader.GetString(0); } else { relationship = ""; }
                    if (!heireSelectReader.IsDBNull(1)) { payeeName = heireSelectReader.GetString(1); } else { payeeName = ""; }
                    if (!heireSelectReader.IsDBNull(2)) { theShare = heireSelectReader.GetDouble(2); } else { theShare = 0; }
                    if (!heireSelectReader.IsDBNull(3)) { payeeAmt = heireSelectReader.GetDouble(3); } else { payeeAmt = 0; }
                    if (!heireSelectReader.IsDBNull(5)) { affiNomiAssiLPTdat = heireSelectReader.GetInt32(5); } else { affiNomiAssiLPTdat = 0; }
                    if (!heireSelectReader.IsDBNull(6)) { DOB = heireSelectReader.GetInt32(6); } else { DOB = 0; }

                    payeeDetArray[0] = payeeName;
                    payeeDetArray[1] = relationship;
                    payeeDetArray[2] = "Affidavit";
                    payeeDetArray[3] = payeeAmt.ToString();
                    payeeDetArray[4] = (theShare * 100).ToString();
                    payeeDetArray[5] = affiNomiAssiLPTdat.ToString();
                    
                }
                heireSelectReader.Close();
                heireSelectReader.Dispose();
            }
        }
            #endregion

        if (recipient.Equals("SL"))
        {
            #region
            double theShare = 0;
            string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + POlno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
            if (dm.existRecored(heireSelect) != 0)
            {
                dm.readSql(heireSelect);
                OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (heireSelectReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!heireSelectReader.IsDBNull(0)) { relationship = heireSelectReader.GetString(0); } else { relationship = ""; }
                    if (!heireSelectReader.IsDBNull(1)) { payeeName = heireSelectReader.GetString(1); } else { payeeName = ""; }
                    if (!heireSelectReader.IsDBNull(2)) { theShare = heireSelectReader.GetDouble(2); } else { theShare = 0; }
                    if (!heireSelectReader.IsDBNull(3)) { payeeAmt = heireSelectReader.GetDouble(3); } else { payeeAmt = 0; }
                    if (!heireSelectReader.IsDBNull(5)) { affiNomiAssiLPTdat = heireSelectReader.GetInt32(5); } else { affiNomiAssiLPTdat = 0; }
                    if (!heireSelectReader.IsDBNull(6)) { DOB = heireSelectReader.GetInt32(6); } else { DOB = 0; }

                    if (DOB != 0)
                    {
                        string yr = DOB.ToString().Substring(0, 4);
                        string mn = DOB.ToString().Substring(4, 2);
                        string dt = DOB.ToString().Substring(6, 2);

                        DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                        DateTime today = DateTime.Now;
                        TimeSpan diff = today.Subtract(Bdate);
                        PayeeAge = (int)diff.TotalDays / 365;

                        payeeDetArray[0] = payeeName;
                        payeeDetArray[1] = relationship;
                        payeeDetArray[2] = "Affidavit";
                        payeeDetArray[3] = payeeAmt.ToString();
                        payeeDetArray[4] = (theShare * 100).ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                       
                    }
                    else
                    {
                        payeeDetArray[0] = payeeName;
                        payeeDetArray[1] = relationship;
                        payeeDetArray[2] = "Affidavit";
                        payeeDetArray[3] = payeeAmt.ToString();
                        payeeDetArray[4] = (theShare * 100).ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        
                    }
                }

                heireSelectReader.Close();
                heireSelectReader.Dispose();
            }
            #endregion
        }

        else if (recipient.Equals("ASI"))
        {
            #region
            string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASSIGNDATE from LUND.ASSIGNEE  where POLICY_NO = " + POlno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') ";
            if (dm.existRecored(asiSelect) != 0)
            {
                dm.readSql(asiSelect);
                OracleDataReader prassReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (prassReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!prassReader.IsDBNull(2)) { payeeName = prassReader.GetString(3); } else { payeeName = ""; }
                    if (!prassReader.IsDBNull(5)) { affiNomiAssiLPTdat = prassReader.GetInt32(5); } else { affiNomiAssiLPTdat = 0; }
                    //if (!prassReader.IsDBNull(3)) { payeeAmt = prassReader.GetDouble(3); } else { payeeAmt = 0; }

                    payeeDetArray[0] = payeeName;
                    payeeDetArray[1] = "Assignee";
                    payeeDetArray[2] = "Assignment";
                    payeeDetArray[3] = netclaim.ToString();
                    payeeDetArray[4] = "1";
                    payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

               
                }
                prassReader.Close();
                prassReader.Dispose();
            }
            else
            {
                dm.connclose();
                throw new Exception("Payment not Yet Authorized or No Liable Payments");
            }
            #endregion
        }
        else if (recipient.Equals("NOM"))
        {
            #region

            string nomSelect = "select NOMNAM, NOMPER, NOMINATEDATE,NOMDOB from LUND.NOMINEE where POLNO = " + POlno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') order by nomno ";
            if (dm.existRecored(nomSelect) != 0)
            {
                dm.readSql(nomSelect);
                OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (nomineeReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!nomineeReader.IsDBNull(0)) { payeeName = nomineeReader.GetString(0); } else { payeeName = ""; }
                    if (!nomineeReader.IsDBNull(1)) { PER = nomineeReader.GetInt32(1); } else { PER = 0; }
                    if (!nomineeReader.IsDBNull(2)) { affiNomiAssiLPTdat = nomineeReader.GetInt32(2); } else { affiNomiAssiLPTdat = 0; }
                    if (!nomineeReader.IsDBNull(3)) { DOB = nomineeReader.GetInt32(2); } else { DOB = 0; }

                    if (DOB != 0)
                    {
                        string yr = DOB.ToString().Substring(0, 4);
                        string mn = DOB.ToString().Substring(4, 2);
                        string dt = DOB.ToString().Substring(6, 2);

                        DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                        DateTime today = DateTime.Now;
                        TimeSpan diff = today.Subtract(Bdate);
                        PayeeAge = (int)diff.TotalDays / 365;
                        if (PayeeAge > 18)
                        {
                            PER /= 100;
                            payeeAmt = netclaim * PER;
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = "Nominee";
                            payeeDetArray[2] = "Nominate";
                            payeeDetArray[3] = payeeAmt.ToString();
                            payeeDetArray[4] = PER.ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();
                           
                        }
                    }
                    else
                    {
                        PER /= 100;
                        payeeAmt = netclaim * PER;
                        payeeDetArray[0] = payeeName;
                        payeeDetArray[1] = "Nominee";
                        payeeDetArray[2] = "Nominate";
                        payeeDetArray[3] = payeeAmt.ToString();
                        payeeDetArray[4] = PER.ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();                       
                    }

                }
                nomineeReader.Close();
                nomineeReader.Dispose();
            }
            else
            {
                dm.connclose();
                throw new Exception("Payment not Yet Authorized or No Liable Payments");
            }

            #endregion
        }
        else if (recipient.Equals("LPT"))
        {
            #region

            string living_prtSelect = "select NOMNAM, NOMPER, PRTNRSHIPDATE from LUND.LIVING_PRT where polno = " + POlno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') ";
            if (dm.existRecored(living_prtSelect) != 0)
            {
                dm.readSql(living_prtSelect);
                OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (nomineeReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!nomineeReader.IsDBNull(0)) { payeeName = nomineeReader.GetString(0); } else { payeeName = ""; }
                    if (!nomineeReader.IsDBNull(1)) { PER = nomineeReader.GetInt32(1); } else { PER = 0; }
                    if (!nomineeReader.IsDBNull(2)) { affiNomiAssiLPTdat = nomineeReader.GetInt32(2); } else { affiNomiAssiLPTdat = 0; }

                    PER /= 100;
                    payeeDetArray[0] = payeeName;
                    payeeDetArray[1] = "Living Partner";
                    payeeDetArray[2] = "Policy Partnership";
                    payeeDetArray[3] = netclaim.ToString();
                    payeeDetArray[4] = PER.ToString();
                    payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                    
                }
                nomineeReader.Close();
                nomineeReader.Dispose();
            }
            else
            {
                dm.connclose();
                throw new Exception("Payment not Yet Authorized or No Liable Payments");
            }

            #endregion
        }


        #endregion

        if (relationship == "Son")
        {
            this.litrel.Text = "mq; d";
        }
        if (relationship == "Daughter")
        {
            this.litrel.Text = "oshKsh";
        }
        if (relationship == "Spouce")
        {
            this.litrel.Text = "iylre$ldrsh";
        }
        if (relationship == "Brother")
        {
            this.litrel.Text = "ifydaorhd";
        }
        if (relationship == "Sister")
        {
            this.litrel.Text = "ifydaorsh";
        }
        if (relationship == "Mother")
        {
            this.litrel.Text = "uj";
        }
        if (relationship == "Father")
        {
            this.litrel.Text = "mshd";
        }
        }
    }
}
