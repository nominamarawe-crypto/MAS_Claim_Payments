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

public partial class ADBDischargeEng001 : System.Web.UI.Page
{
    public long polNo;
    public string mos;
    public long claimNo;
    public string recipient = "";
    public string low = "";
    public int PayeeAge;
    public int tbl;
    public double netAmount;
    public string phname;
    public string statusmn;
    public int dateofdeath;
    public string nameOfDth;
    public string isExgracia;

    public ArrayList arrList;

    DataManager dm = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            if (PreviousPage != null) 
            {
                polNo = this.PreviousPage.PolNo;
                mos = this.PreviousPage.MOS;
                claimNo = this.PreviousPage.ClaimNo;
                tbl = this.PreviousPage.TBL;
                netAmount = this.PreviousPage.NetAmount;
                dateofdeath = this.PreviousPage.DateofDeath;
                nameOfDth = this.PreviousPage.NameOfDeath;
                isExgracia = this.PreviousPage.IsExgracia;
            }

            #region ------------ payee details ------------

            int autCount = 0; 
            string dthrefSel = "select payee from lphs.dthref where  DRPOLNO=" + polNo + " and DRMOS='" + mos + "' and DISTN_AUT > 0 and (payee is not null)";
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
            }
            else
            {
                dm.connclose();
                throw new Exception("Please Confirm the Payment to a Certain Payee!");
            } 

            string payeeName = "";
            string relationship = "";
            double payeeAmt = 0;
            int count = 0;
            double PER = 0;
            int DOB = 0;
            arrList = new ArrayList();
            bool isADBPayeeExist = false;


            int affiNomiAssiLPTdat = 0;

            #region ---------------ADB payee------------------
            string adbHeireSelect = "select NEW_PAYEE, PAYEENAME, PAYEESHARE, PAYEEAMOUNT, nvl(to_number(to_char(PAYEEAUTHDT,'yyyyMMdd')),0), PAYEEDOB from LPHS.DTH_ADBPAYMENT_DISTN where POLICY_NO=" + polNo + " and MOS='" + mos + "' and CLAIM_NO=" + claimNo + " and (ISPAYEEREJECT <> 'Y' or ISPAYEEREJECT is null) and payeepayst ='OK' ";

            if (dm.existRecored(adbHeireSelect) != 0)
            {
                double adbShare = 0;

                dm.readSql(adbHeireSelect);
                OracleDataReader adbSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (adbSelectReader.Read())
                {
                    string[] payeeDetArray = new string[6];
                    count++;
                    if (!adbSelectReader.IsDBNull(0)) { relationship = adbSelectReader.GetString(0); } else { relationship = ""; }
                    if (!adbSelectReader.IsDBNull(1)) { payeeName = adbSelectReader.GetString(1); } else { payeeName = ""; }
                    if (!adbSelectReader.IsDBNull(2)) { adbShare = adbSelectReader.GetDouble(2); } else { adbShare = 0; }
                    if (!adbSelectReader.IsDBNull(3)) { payeeAmt = adbSelectReader.GetDouble(3); } else { payeeAmt = 0; }
                    if (!adbSelectReader.IsDBNull(4)) { affiNomiAssiLPTdat = adbSelectReader.GetInt32(4); } else { affiNomiAssiLPTdat = 0; }
                    if (!adbSelectReader.IsDBNull(5)) { DOB = adbSelectReader.GetInt32(5); } else { DOB = 0; }

                    if (DOB != 0)
                    {
                        string yr = DOB.ToString().Substring(0, 4);
                        string mn = DOB.ToString().Substring(4, 2);
                        string dt = DOB.ToString().Substring(6, 2);

                        DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                        DateTime today = DateTime.Now;
                        TimeSpan diff = today.Subtract(Bdate);
                        PayeeAge = (int)diff.TotalDays / 365;
                        if (PayeeAge >= 18)
                        { 
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = relationship;
                            payeeDetArray[2] = "Affidavit";
                            payeeDetArray[3] = payeeAmt.ToString();
                            if (adbShare > 1)
                            {
                                adbShare /= 100;
                            }
                            payeeDetArray[4] = (adbShare).ToString();
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
                        if (adbShare > 1)
                        {
                            adbShare /= 100;
                        }
                        payeeDetArray[4] = (adbShare).ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        arrList.Add(payeeDetArray);
                    }
                }
                adbSelectReader.Close();
                adbSelectReader.Dispose();

                isADBPayeeExist = true;
            }
            #endregion

            if (recipient.Equals("LHI"))
            {
                #region

                double theShare = 0;

                string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + polNo + " and lhmof='" + mos + "' and (lhpayst = 'OK'or lhpayst = 'PN') and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null) ";
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
                            if (PayeeAge >= 18)
                            {
                                payeeAmt = netAmount * theShare;
                                payeeDetArray[0] = payeeName;
                                payeeDetArray[1] = relationship;
                                payeeDetArray[2] = "Affidavit";
                                payeeDetArray[3] = payeeAmt.ToString();
                                if (theShare > 1)
                                {
                                    theShare /= 100;
                                }
                                payeeDetArray[4] = (theShare).ToString();
                                payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                                arrList.Add(payeeDetArray);
                            }
                        }
                        else
                        {
                            payeeAmt = netAmount * theShare;
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = relationship;
                            payeeDetArray[2] = "Affidavit";
                            payeeDetArray[3] = payeeAmt.ToString();
                            if (theShare > 1)
                            {
                                theShare /= 100;
                            }
                            payeeDetArray[4] = (theShare).ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                            arrList.Add(payeeDetArray);
                        }
                    }
                    heireSelectReader.Close();
                    heireSelectReader.Dispose();
                }
                else if (!isADBPayeeExist)
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

                string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + polNo + " and lhmof='" + mos + "' and (lhpayst = 'OK'or lhpayst = 'PN') and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null) ";
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
                        if (tbl != 38 && tbl != 39)
                        {
                            payeeDetArray[2] = "Affidavit";
                        }
                        else
                        {
                            payeeDetArray[2] = "Proposal";
                        }
                        payeeDetArray[3] = payeeAmt.ToString();
                        if (theShare > 1)
                        {
                            theShare /= 100;
                        }
                        payeeDetArray[4] = (theShare).ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        arrList.Add(payeeDetArray);
                    }
                    heireSelectReader.Close();
                    heireSelectReader.Dispose();
                }
                #endregion
            }  
            if (recipient.Equals("SL"))
            {
                #region

                if ((recipient == "SL") && ((tbl == 38) || (tbl == 39)))
                {
                    String mosageselect = "select DOB from LUND.POLPERSONAL where POLNO= '" + polNo + "' and (PRPERTYPE=4 OR PRPERTYPE=3)";
                    if (dm.existRecored(mosageselect) != 0)
                    {
                        dm.readSql(mosageselect);
                        OracleDataReader mosageread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (mosageread.Read())
                        {
                            if (!mosageread.IsDBNull(0)) { DOB = mosageread.GetInt32(0); } else { DOB = 0; }
                        }
                        mosageread.Close();
                    }

                }

                double theShare = 0;
                string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE, LHDOB from lphs.legal_hires where lhpolno=" + polNo + " and lhmof='" + mos + "' and (lhpayst = 'OK'or lhpayst = 'PN') and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null)";
                if (dm.existRecored(heireSelect) != 0)
                {
                    dm.readSql(heireSelect);
                    OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    OracleDataReader mosageread;
                    while (heireSelectReader.Read())
                    {
                        string[] payeeDetArray = new string[6];
                        count++;
                        if (!heireSelectReader.IsDBNull(0)) { relationship = heireSelectReader.GetString(0); } else { relationship = ""; }
                        if (!heireSelectReader.IsDBNull(1)) { payeeName = heireSelectReader.GetString(1); } else { payeeName = ""; }
                        if (!heireSelectReader.IsDBNull(2)) { theShare = heireSelectReader.GetDouble(2); } else { theShare = 0; }
                        if (!heireSelectReader.IsDBNull(3)) { payeeAmt = heireSelectReader.GetDouble(3); } else { payeeAmt = 0; }
                        if (!heireSelectReader.IsDBNull(5)) { affiNomiAssiLPTdat = heireSelectReader.GetInt32(5); } else { affiNomiAssiLPTdat = 0; }
                        //  if (!heireSelectReader.IsDBNull(6)) { DOB = heireSelectReader.GetInt32(6); } else { DOB = 0; }                          


                        if (DOB != 0)
                        {
                            string yr = DOB.ToString().Substring(0, 4);
                            string mn = DOB.ToString().Substring(4, 2);
                            string dt = DOB.ToString().Substring(6, 2);

                            DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                            DateTime today = DateTime.Now;
                            TimeSpan diff = today.Subtract(Bdate);
                            PayeeAge = (int)diff.TotalDays / 365;

                            if (tbl == 38 || tbl == 39)
                            {
                                if (PayeeAge >= 18)
                                {
                                    payeeAmt = netAmount * theShare;
                                    payeeDetArray[0] = payeeName;
                                    payeeDetArray[1] = relationship;
                                    payeeDetArray[2] = "Proposal";
                                    payeeDetArray[3] = payeeAmt.ToString();
                                    if (theShare > 1)
                                    {
                                        theShare /= 100;
                                    }
                                    payeeDetArray[4] = (theShare).ToString();
                                    payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                                    arrList.Add(payeeDetArray);
                                }
                                else
                                {
                                    payeeAmt = netAmount * theShare;
                                    payeeDetArray[0] = payeeName;
                                    payeeDetArray[1] = relationship;
                                    payeeDetArray[2] = "Affidavit";
                                    payeeDetArray[3] = payeeAmt.ToString();
                                    if (theShare > 1)
                                    {
                                        theShare /= 100;
                                    }
                                    payeeDetArray[4] = (theShare).ToString();
                                    payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                                    arrList.Add(payeeDetArray);
                                }
                            }
                            else
                            {
                                payeeAmt = netAmount * theShare;
                                payeeDetArray[0] = payeeName;
                                payeeDetArray[1] = relationship;
                                payeeDetArray[2] = "Affidavit";
                                payeeDetArray[3] = payeeAmt.ToString();
                                if (theShare > 1)
                                {
                                    theShare /= 100;
                                }
                                payeeDetArray[4] = (theShare).ToString();
                                payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                                arrList.Add(payeeDetArray);
                            }
                        }
                        else
                        {
                            payeeAmt = netAmount * theShare;
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = relationship;
                            payeeDetArray[2] = "Affidavit";
                            payeeDetArray[3] = payeeAmt.ToString();
                            if (theShare > 1)
                            {
                                theShare /= 100;
                            }
                            payeeDetArray[4] = (theShare).ToString();
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
                string asiSelect = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASSIGNDATE from LUND.ASSIGNEE  where POLICY_NO = " + polNo + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null)";
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
                        payeeDetArray[3] = netAmount.ToString();
                        payeeDetArray[4] = "1";
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        arrList.Add(payeeDetArray);
                    }
                    prassReader.Close();
                    prassReader.Dispose();
                }
                else if (!isADBPayeeExist)
                {
                    dm.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }
                #endregion
            }
            else if (recipient.Equals("NOM"))
            {
                #region

                string nomSelect = "select NOMNAM, NOMPER, to_char(NOMINATEDATE,'mm/dd/yyyy'),NOMDOB from LUND.NOMINEE where POLNO = " + polNo + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null) order by nomno ";
                if (dm.existRecored(nomSelect) != 0)
                {
                    dm.readSql(nomSelect);
                    OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomineeReader.Read())
                    {
                        string[] payeeDetArray = new string[6];
                        count++;
                        if (!nomineeReader.IsDBNull(0)) { payeeName = nomineeReader.GetString(0); } else { payeeName = ""; }
                        if (!nomineeReader.IsDBNull(1)) { PER = nomineeReader.GetDouble(1); } else { PER = 0; }
                        if (!nomineeReader.IsDBNull(2))
                        {
                            string[] nomdt = nomineeReader.GetString(2).Split('/');
                            string dt = "";
                            string mnth = "";
                            if (nomdt[0].Length != 2) { mnth = "0" + nomdt[0].ToString(); } else { mnth = nomdt[0].ToString(); }
                            if (nomdt[1].Length != 2) { dt = "0" + nomdt[1].ToString(); } else { dt = nomdt[1].ToString(); }
                            affiNomiAssiLPTdat = int.Parse(nomdt[2].ToString() + mnth + dt);
                        }
                        else
                        {
                            affiNomiAssiLPTdat = 0;
                        }
                        if (!nomineeReader.IsDBNull(3)) { DOB = nomineeReader.GetInt32(3); } else { DOB = 0; }

                        if (DOB != 0)
                        {
                            string yr = DOB.ToString().Substring(0, 4);
                            string mn = DOB.ToString().Substring(4, 2);
                            string dt = DOB.ToString().Substring(6, 2);

                            DateTime Bdate = Convert.ToDateTime(mn + "/" + dt + "/" + yr);
                            DateTime today = DateTime.Now;
                            TimeSpan diff = today.Subtract(Bdate);
                            PayeeAge = (int)diff.TotalDays / 365;
                            if (PayeeAge >= 18)
                            {
                                payeeAmt = netAmount * PER / 100;
                                payeeDetArray[0] = payeeName;
                                payeeDetArray[1] = "Nominee";
                                payeeDetArray[2] = "Nomination";
                                payeeDetArray[3] = payeeAmt.ToString();
                                if (PER > 1)
                                {
                                    PER /= 100;
                                }
                                payeeDetArray[4] = PER.ToString();
                                payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                                arrList.Add(payeeDetArray);
                            }
                        }
                        else
                        {
                            payeeAmt = netAmount * PER / 100;
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = "Nominee";
                            payeeDetArray[2] = "Nomination";
                            payeeDetArray[3] = payeeAmt.ToString();
                            if (PER > 1)
                            {
                                PER /= 100;
                            }
                            payeeDetArray[4] = PER.ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                            arrList.Add(payeeDetArray);
                        }
                    }
                    nomineeReader.Close();
                    nomineeReader.Dispose();
                }
                else if (!isADBPayeeExist)
                {
                    dm.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }

                #endregion
            }
            else if (recipient.Equals("LPT"))
            {
                #region

                string living_prtSelect = "select NOMNAM, NOMPER, PRTNRSHIPDATE from LUND.LIVING_PRT where polno = " + polNo + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') and (IS_ADBREJECT <> 'Y' or IS_ADBREJECT is null)";
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

                        payeeDetArray[0] = payeeName;
                        payeeDetArray[1] = "Living Partner";
                        payeeDetArray[2] = "Policy Partnership";
                        payeeDetArray[3] = netAmount.ToString();
                        if (PER > 1)
                        {
                            PER /= 100;
                        }
                        payeeDetArray[4] = PER.ToString();
                        payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                        arrList.Add(payeeDetArray);
                    }
                    nomineeReader.Close();
                    nomineeReader.Dispose();
                }
                else if(!isADBPayeeExist)
                {
                    dm.connclose();
                    throw new Exception("Payment not Yet Authorized or No Liable Payments");
                }

                #endregion
            }

            #endregion

            #region ------------------ Select PHNAME ---------------------------
            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, " +
                " phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polNo + "'";
            dm.readSql(sql);
            OracleDataReader oraDtReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (oraDtReader.Read())
            {
                if ((!oraDtReader.IsDBNull(0)) && ((!oraDtReader.IsDBNull(1))) && ((!oraDtReader.IsDBNull(2))))
                {
                    phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                }
                if (!oraDtReader.IsDBNull(0)) { statusmn = oraDtReader.GetString(0).ToUpper(); } else { statusmn = ""; }
            }
            oraDtReader.Close();
            oraDtReader.Dispose();
            #endregion

            if (isExgracia == "Y")
            {
                lbladbStr.Visible = true;
            }

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
