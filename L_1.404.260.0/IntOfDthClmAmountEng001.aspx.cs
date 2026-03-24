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

public partial class discharge001 : System.Web.UI.Page
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
    public string adbLatepay;

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
    public DataManager dthReqObj;
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
    public int[] dateComparison(int startdate, int enddate)
    { //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
    } 
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

            
            polno =int.Parse( Session["Polno"].ToString());
            MOF = Session["MOF"].ToString();
            claimno =int.Parse( Session["ClmNo"].ToString());
            dateofdeath = int.Parse(Session["dateofdeath"].ToString());
            vestedBonus =int.Parse( Session["VestedBonus"].ToString());
            interimBonus = int.Parse(Session["interimBonus"].ToString());
            //nameOfDead = this.PreviousPage.NameOfDead;
            COM = int.Parse(Session["Comdate"].ToString());
            PRM = int.Parse(Session["TRM"].ToString());
            TBL = int.Parse(Session["TBL"].ToString());
            polcompleYM = Session["PolicyComYr"].ToString();
            missingprems = int.Parse(Session["missingprems"].ToString());
            ADB = Convert.ToDouble( Session["ADB"].ToString());
            FPU = Convert.ToDouble(Session["FPU"].ToString());
            SJ = Convert.ToDouble(Session["SJ"].ToString());
            FE = Convert.ToDouble(Session["FE"].ToString());



            sumassured = double.Parse(Session["sumassured"].ToString());
            deposit = double.Parse(Session["deposit"].ToString());
            demmands = double.Parse(Session["demmands"].ToString());
            defint = double.Parse(Session["defint"].ToString());
            loancap = double.Parse(Session["loancap"].ToString());
            loanint = double.Parse(Session["loanint"].ToString());
            otheradd = double.Parse(Session["otheradd"] .ToString());
            otherdeuct = double.Parse(Session["otherdeuct"].ToString());
            grossClm =double.Parse(Session["grossClm"].ToString());
            netclm = double.Parse(Session["netclm"].ToString());

            ageStatus = Session["ageStatus"].ToString();
            ageDiffAmt =double.Parse( Session["ageDiffAmt"].ToString());

            //totamount = this.PreviousPage.Totamount;

        }
        if (!Page.IsPostBack)
        {
            dthReqObj = new DataManager();
            try
            {
              

                //epf = Session["EPFNUM"].ToString();

                #region //------------ payee details ------------
                              
                int autCount = 0;
                //int payAutCount = 0;
                string dthrefSel = "select dlow, payee, DRNETCLM, PAYAUTDT, DISTN_AUT, EXGRACIA_AMOUNT, INTBONSTYR, adb_latepay from lphs.dthref where  DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and DISTN_AUT > 0 and (payee is not null)";
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
                        if (!dthrefReader.IsDBNull(6)) { adbLatepay = dthrefReader.GetString(7); } else { adbLatepay = ""; }

                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();
                }
                //else { throw new Exception("Please Confirm the Payment to a Certain Payee!"); }
                               
                string payeeName = "";
                string relationship = "";
                double payeeAmt = 0;
                int count = 0;
                double PER = 0;
                arrList = new ArrayList();

                int affiNomiAssiLPTdat = 0;
               
                if (recipient.Equals("LHI"))
                {
                    #region

                    double theShare = 0;

                    string heireSelect = "select lhhire, lhname, LHSHARE, LHAMOUNT, VOUSTA, AFFIDAVITDATE from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' and (lhpayst = 'OK'or lhpayst = 'PN') ";
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

                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = relationship;
                            payeeDetArray[2] = "Affidavit";
                            payeeDetArray[3] = netClaim.ToString();
                            payeeDetArray[4] = (theShare * 100).ToString();
                            payeeDetArray[5] = affiNomiAssiLPTdat.ToString();

                            arrList.Add(payeeDetArray);
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

                    string nomSelect = "select NOMNAM, NOMPER, NOMINATEDATE from LUND.NOMINEE where POLNO = " + polno + " and (PAYSTATUS = 'OK' or PAYSTATUS = 'PN') order by nomno ";
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
                                affiNomiAssiLPTdat = int.Parse(nomdt[2].ToString() + nomdt[0].ToString() + nomdt[1].ToString());
                            }
                            else { affiNomiAssiLPTdat = 0; }

                            payeeAmt = netClaim * PER / 100;
                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = "Nominee";
                            payeeDetArray[2] = "Nominate";
                            payeeDetArray[3] = payeeAmt.ToString();
                            PER /= 100;
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

                            payeeDetArray[0] = payeeName;
                            payeeDetArray[1] = "Living Partner";
                            payeeDetArray[2] = "Policy Partnership";
                            payeeDetArray[3] = netClaim.ToString();
                            PER /= 100;
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

               double SUMONEX=0; double ADBONEX=0; double FPUONEX=0; double FEONEX=0; double SJONEX=0; double OTHERADDONEX=0; double REFOFPRMONEX=0; 
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

                    if (SUMONEX > 0) { this.litsumonexgr.Text = "On Exgracia"; } // Change By Pathum 
                    if (ADBONEX > 0) { this.lbladbStr.Text = "ADB On Exgracia"; }
                    if (FPUONEX > 0) { this.lblfpustr.Text = "FPU On Exgracia"; }
                    if (FEONEX > 0) { this.lblfestr.Text = "FE On Exgracia"; }
                    if (SJONEX > 0) { this.lblsjstr.Text = "SJ On Exgracia"; }
                    if (OTHERADDONEX > 0) { this.lblothradonExg.Text = "On Exgracia"; }

                    exgrreader.Close();
                    exgrreader.Dispose();
                }

                #endregion
                
                #region // ************** PHNAME  ******************************************************
                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, "+
                    " phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
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

                #endregion
                string LANG = "E";
                int INDEX = 0;

                #region Load Claimnt Address(modified By Kumudu)
                string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX=" + INDEX + "";
                if (dthReqObj.existRecored(dclmAddressSelect) != 0)
                {
                    dthReqObj.readSql(dclmAddressSelect);
                    OracleDataReader dthintReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { litname.Text = dthintReader.GetString(0); }
                        else { litname.Text = ""; }
                        if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); }
                        else { litad1.Text = ""; }
                        if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); }
                        else { litad2.Text = ""; }
                        if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); }
                        else { litad3.Text = ""; }
                        if (!dthintReader.IsDBNull(4)) { litad4.Text =  dthintReader.GetString(4); }
                        else { litad4.Text = ""; }

                    }
                    dthintReader.Close();
                    dthintReader.Dispose();

                }

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
}
