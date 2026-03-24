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

public partial class DischargeDepositSinhala : System.Web.UI.Page
{
    public long polno;
    public string MOF;

    public int dateofdeath;
    public string nameOfDead = "";
    public string phname;
    public int COM;
    public double PRM;
    public int TBL;
    public int missingprems;
    public string polcompleYM;
    //******* variables for DTHREF ***************
    public double ADB;
    public double FPU;
    public double SJ;
    public double FE;

    public double vestedBonus;
    public double interimBonus;
    public double totbons;
    public double surrrenderedbons;
    public int bonussurrYr;
    public double netsurrAmt;
    public long claimno;
    public double deposit;
    public double demmands;
    public double defint;
    public double loancap;
    public double loanint;

    public double otheradd;
    public double otherdeuct;
    public double sumassured;
    public double grossClm;
    public double netclm;
    public double outAmt;

    public string ageStatus;
    public double ageDiffAmt;

    public double totamount;
    DataManager dthReqObj;
    lpolhisread lpolobj;

    public ArrayList arrList;

    public string recipient = "";
    public string low = "";
    public string recipient02 = "";
    public string low02 = "";

    public double netClaim;
    public double exgraciaAmt;
    public int payAutDate;
    //public string epf;
    public int interimBonStYr;
    public int PayeeAge;

    protected void Page_Load(object sender, EventArgs e)
    {
        dthReqObj = new DataManager();
        try
        {
            if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
            {
                polno = this.PreviousPage.Polno;
                MOF = this.PreviousPage.mOF;
                claimno = this.PreviousPage.Claimno;
                dateofdeath = this.PreviousPage.Dateofdeath;
                vestedBonus = this.PreviousPage.VestedBonus;
                interimBonus = this.PreviousPage.InterimBonus;
                nameOfDead = this.PreviousPage.NameOfDead;
                COM = this.PreviousPage.cOM;
                PRM = this.PreviousPage.pRM;
                TBL = this.PreviousPage.tBL;
                polcompleYM = this.PreviousPage.PolcompleYM;
                missingprems = this.PreviousPage.Missingprems;
                ADB = this.PreviousPage.aDB;
                FPU = this.PreviousPage.fPU;
                SJ = this.PreviousPage.sJ;
                FE = this.PreviousPage.fE;

                sumassured = this.PreviousPage.Sumassured;
                deposit = this.PreviousPage.Deposit;
                demmands = this.PreviousPage.Demmands;
                defint = this.PreviousPage.Defint;
                loancap = this.PreviousPage.Loancap;
                loanint = this.PreviousPage.Loanint;
                otheradd = this.PreviousPage.Otheradd;
                otherdeuct = this.PreviousPage.Otherdeuct;
                grossClm = this.PreviousPage.GrossClm;
                netclm = this.PreviousPage.Netclm;

                ageStatus = this.PreviousPage.AgeStatus;
                ageDiffAmt = this.PreviousPage.AgeDiffAmt;
                totamount = this.PreviousPage.Totamount;
            }
            else
            {
                polno = long.Parse(Request.QueryString["polno"]);
                MOF = Request.QueryString["mos"];
                claimno = int.Parse(Request.QueryString["clmno"]);
                dateofdeath = int.Parse(Request.QueryString["dtofdth"]);

                #region---------------------Dthref-----------------------
                string dthrefsel = "select DRVESTEDBON, DRINTERIMBON, DRDEFPREM, DRINT, DRLONCAP, DRLOANINT, DRNETCLM from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and DRCLMNO=" + claimno + "";
                if (dthReqObj.existRecored(dthrefsel) != 0)
                {
                    dthReqObj.readSql(dthrefsel);
                    OracleDataReader dthrefreader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefreader.Read())
                    {
                        if (!dthrefreader.IsDBNull(0)) { vestedBonus = dthrefreader.GetDouble(0); } else { vestedBonus = 0; }
                        if (!dthrefreader.IsDBNull(1)) { interimBonus = dthrefreader.GetDouble(1); } else { interimBonus = 0; }
                        if (!dthrefreader.IsDBNull(2)) { demmands = dthrefreader.GetDouble(2); } else { demmands = 0; }
                        if (!dthrefreader.IsDBNull(3)) { defint = dthrefreader.GetDouble(3); } else { defint = 0; }
                        if (!dthrefreader.IsDBNull(4)) { loancap = dthrefreader.GetDouble(4); } else { loancap = 0; }
                        if (!dthrefreader.IsDBNull(5)) { loanint = dthrefreader.GetDouble(5); } else { loanint = 0; }
                        if (!dthrefreader.IsDBNull(6)) { netClaim = dthrefreader.GetDouble(6); } else { netClaim = 0; }
                    }
                    dthrefreader.Close();
                    dthrefreader.Dispose();
                }
                #endregion

                lpolobj = new lpolhisread(polno);
                COM = lpolobj.Commence;
                TBL = lpolobj.Table;
            }
            //epf = Session["EPFNUM"].ToString();

            #region //------------ payee details ------------

            int autCount = 0;
//            int payAutCount = 0;
            string dthrefSel = "select dlow, payee, DRNETCLM, PAYAUTDT, DISTN_AUT, EXGRACIA_AMOUNT, INTBONSTYR from lphs.dthref where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and DISTN_AUT > 0 and (payee is not null)";
            if (dthReqObj.existRecored(dthrefSel) != 0)
            {
                dthReqObj.readSql(dthrefSel);
                OracleDataReader dthrefReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthrefReader.Read())
                {
                    if (!dthrefReader.IsDBNull(0)) { low = dthrefReader.GetString(0); } else { low = ""; }
                    if (!dthrefReader.IsDBNull(1)) { recipient = dthrefReader.GetString(1); } else { recipient = ""; }
                    if (!dthrefReader.IsDBNull(2)) { netClaim = dthrefReader.GetDouble(2); } else { netClaim = 0; }
                    if (!dthrefReader.IsDBNull(3)) { payAutDate = dthrefReader.GetInt32(3); } else { payAutDate = 0; }
                    if (!dthrefReader.IsDBNull(4)) { autCount = dthrefReader.GetInt32(4); } else { autCount = 0; }
                    if (!dthrefReader.IsDBNull(5)) { exgraciaAmt = dthrefReader.GetInt32(5); } else { exgraciaAmt = 0; }
                    if (!dthrefReader.IsDBNull(6)) { interimBonStYr = dthrefReader.GetInt32(6); } else { interimBonStYr = 0; }
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
            arrList = new ArrayList();
            int affiNomiAssiLPTdat = 0;

            if (recipient.Equals("LHI"))
            {
                #region

                double theShare = 0;

                string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE,LHDOB from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
                if (dthReqObj.existRecored(heireSelect) != 0)
                {
                    dthReqObj.readSql(heireSelect);
                    OracleDataReader heireSelectReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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

                                arrList.Add(payeeDetArray);
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

                            arrList.Add(payeeDetArray);
                        }
                    }
                    heireSelectReader.Close();
                    heireSelectReader.Dispose();
                }
                else
                {
                    dthReqObj.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }

                #endregion
            }
            if (recipient.Equals("ML"))
            {
                #region

                double theShare = 0;

                string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
                if (dthReqObj.existRecored(heireSelect) != 0)
                {
                    dthReqObj.readSql(heireSelect);
                    OracleDataReader heireSelectReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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
                        arrList.Add(payeeDetArray);
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
                string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
                if (dthReqObj.existRecored(heireSelect) != 0)
                {
                    dthReqObj.readSql(heireSelect);
                    OracleDataReader heireSelectReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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

                            arrList.Add(payeeDetArray);
                        }
                        else
                        {
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = relationship;
                            payeeDetArray[2] = "Affidavit";
                            payeeDetArray[3] = payeeAmt.ToString();
                            payeeDetArray[4] = (theShare * 100).ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                            arrList.Add(payeeDetArray);
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
                string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASSIGNDATE from LUND.ASSIGNEE  where POLICY_NO = " + polno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') ";
                if (dthReqObj.existRecored(asiSelect) != 0)
                {
                    dthReqObj.readSql(asiSelect);
                    OracleDataReader prassReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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
                        payeeDetArray[3] = netClaim.ToString();
                        payeeDetArray[4] = "1";
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        arrList.Add(payeeDetArray);
                    }
                    prassReader.Close();
                    prassReader.Dispose();
                }
                else
                {
                    dthReqObj.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }
                #endregion
            }
            else if (recipient.Equals("NOM"))
            {
                #region

                string nomSelect = "select NOMNAM, NOMPER, NOMINATEDATE,NOMDOB from LUND.NOMINEE where POLNO = " + polno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') order by nomno ";
                if (dthReqObj.existRecored(nomSelect) != 0)
                {
                    dthReqObj.readSql(nomSelect);
                    OracleDataReader nomineeReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomineeReader.Read())
                    {
                        string[] payeeDetArray = new string[6];
                        count++;
                        if (!nomineeReader.IsDBNull(0)) { payeeName = nomineeReader.GetString(0); } else { payeeName = ""; }
                        if (!nomineeReader.IsDBNull(1)) { PER = nomineeReader.GetInt32(1); } else { PER = 0; }
                        if (!nomineeReader.IsDBNull(2))
                        {
                            string[] nomdt = nomineeReader.GetDateTime(2).ToShortDateString().Split('/');
                            string dt = "";
                            string mnth = "";
                            if (nomdt[0].Length != 2) { mnth = "0" + nomdt[0].ToString(); } else { mnth = nomdt[0].ToString(); }
                            if (nomdt[1].Length != 2) { dt = "0" + nomdt[1].ToString(); } else { dt = nomdt[1].ToString(); }
                            affiNomiAssiLPTdat = int.Parse(nomdt[2].ToString() + mnth + dt);
                        }
                        else { affiNomiAssiLPTdat = 0; }
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
                                payeeAmt = netClaim * PER;
                                payeeDetArray[0] = payeeName;
                                payeeDetArray[1] = "Nominee";
                                payeeDetArray[2] = "Nominate";
                                payeeDetArray[3] = payeeAmt.ToString();
                                payeeDetArray[4] = PER.ToString();
                                payeeDetArray[5] = affiNomiAssiLPTdat.ToString();
                                arrList.Add(payeeDetArray);
                            }
                        }
                        else
                        {
                            PER /= 100;
                            payeeAmt = netClaim * PER;
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = "Nominee";
                            payeeDetArray[2] = "Nominate";
                            payeeDetArray[3] = payeeAmt.ToString();
                            payeeDetArray[4] = PER.ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();
                            arrList.Add(payeeDetArray);
                        }

                    }
                    nomineeReader.Close();
                    nomineeReader.Dispose();
                }
                else
                {
                    dthReqObj.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }

                #endregion
            }
            else if (recipient.Equals("LPT"))
            {
                #region

                string living_prtSelect = "select NOMNAM, NOMPER, PRTNRSHIPDATE from LUND.LIVING_PRT where polno = " + polno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') ";
                if (dthReqObj.existRecored(living_prtSelect) != 0)
                {
                    dthReqObj.readSql(living_prtSelect);
                    OracleDataReader nomineeReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
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
                        payeeDetArray[3] = netClaim.ToString();
                        payeeDetArray[4] = PER.ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        arrList.Add(payeeDetArray);
                    }
                    nomineeReader.Close();
                    nomineeReader.Dispose();
                }
                else
                {
                    dthReqObj.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }

                #endregion
            }


            #endregion

            #region -------------- exgracia details -------------

            double SUMONEX = 0; double ADBONEX = 0; double FPUONEX = 0; double FEONEX = 0; double SJONEX = 0; double OTHERADDONEX = 0; double REFOFPRMONEX = 0;
            string exgrSel = "select SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF  ='" + MOF + "' ";
            if (dthReqObj.existRecored(exgrSel) != 0)
            {
                dthReqObj.readSql(exgrSel);
                OracleDataReader exgrreader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                exgrreader.Read();
                if (!exgrreader.IsDBNull(0)) { SUMONEX = exgrreader.GetDouble(0); } else { SUMONEX = 0; }
                if (!exgrreader.IsDBNull(1)) { ADBONEX = exgrreader.GetDouble(1); } else { ADBONEX = 0; }
                if (!exgrreader.IsDBNull(2)) { FPUONEX = exgrreader.GetDouble(2); } else { FPUONEX = 0; }
                if (!exgrreader.IsDBNull(3)) { FEONEX = exgrreader.GetDouble(3); } else { FEONEX = 0; }
                if (!exgrreader.IsDBNull(4)) { SJONEX = exgrreader.GetDouble(4); } else { SJONEX = 0; }
                if (!exgrreader.IsDBNull(5)) { OTHERADDONEX = exgrreader.GetDouble(5); } else { OTHERADDONEX = 0; }
                if (!exgrreader.IsDBNull(6)) { REFOFPRMONEX = exgrreader.GetDouble(6); } else { REFOFPRMONEX = 0; }

                exgrreader.Close();
                exgrreader.Dispose();
            }

            #endregion

            #region // ************** PHNAME  ********************************************
            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, " +
            " phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            dthReqObj.readSql(sql);
            OracleDataReader oraDtReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (oraDtReader.Read())
            {
                if ((!oraDtReader.IsDBNull(0)) && ((!oraDtReader.IsDBNull(1))) && ((!oraDtReader.IsDBNull(2))))
                {
                    phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                }
            }
            oraDtReader.Close();
            oraDtReader.Dispose();
            // this.litLifeassured.Text = phname;

            #endregion

            dthReqObj.connclose();
        }
        catch (Exception ex)
        {
            dthReqObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

    }
}
