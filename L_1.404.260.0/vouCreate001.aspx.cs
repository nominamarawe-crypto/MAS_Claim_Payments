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

public partial class vouCreate001 : System.Web.UI.Page
{
    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;

    }

    private int branch = 0;      //session branch
    private string EPF;      //session epf
    private long clmno;
    private string phname = "";

    private long polno;
    private string MOS;

    private double totamount;
    private double amtOut, exgramt = 0;
    private string payee = "";

    private int NOMNUM;
    private int heireNo;

    private string name = "";
    private string addr1 = "";
    private string addr2 = "";
    private string addr3 = "";
    private string addr4 = "";
    private string bankkname = "", namewithins = "";
    private string bkBrn = "";
    private string acctNo = "";
    private string SLIAcctNo = "";
    private int dthdate, ACCODE = 2118;
    private string accCode = "";

    DataManager dthpayObj;
    BankDetailsBreak bdb;

    private ArrayList arrListNom;
    private ArrayList arrListLHI;
    private string[] ASIarr;
    private string[] LPTarr;
    private ArrayList vouIndexes;

    private int recCount;
    private int vouCountStatic;
    private int vouToBeCreatedCount;
    private string adblatepay;

    private double vouamount;
    private string isFuturePayment;
    General gg;
    //List<int> accCodeList = new List<int>();
    // if vouCountStatic + vouToBeCreatedCount = recCount that implies payment is completed



    protected void Page_Load(object sender, EventArgs e)
    {
        gg = new General();
        if (Session["EPFNum"] != null || Session["brcode"] != null)
        {
            EPF = Session["EPFNum"].ToString();
            branch = Convert.ToInt32(Session["brcode"]);
        }
        else
        {
            Response.Redirect("SessionError.aspx", false);
        }
        try
        {
            //throw new Exception("Your Session Variable Expired Please Log on to the System!");

            if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
            {
                #region
                polno = this.PreviousPage.Polno;
                MOS = this.PreviousPage.mOS;
                totamount = this.PreviousPage.Totamount;
                payee = this.PreviousPage.Payee;
                recCount = this.PreviousPage.RecCount;
                vouCountStatic = this.PreviousPage.VouCountStatic;
                vouToBeCreatedCount = this.PreviousPage.VouToBeCreatedCount;
                vouIndexes = this.PreviousPage.VouIndexes;
                arrListNom = this.PreviousPage.ArrListNom;
                arrListLHI = this.PreviousPage.ArrListLHI;
                ASIarr = this.PreviousPage.aSIarr;
                LPTarr = this.PreviousPage.lPTarr;
                amtOut = this.PreviousPage.AmtOut;
                #endregion

            }
            dthpayObj = new DataManager();

            #region ---------- view state --------
            if (!Page.IsPostBack)
            {
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;

                ViewState["totamount"] = totamount;
                ViewState["amtOut"] = amtOut;
                ViewState["payee"] = payee;
                ViewState["arrListNom"] = arrListNom;
                ViewState["arrListLHI"] = arrListLHI;
                ViewState["ASIarr"] = ASIarr;
                ViewState["LPTarr"] = LPTarr;
                ViewState["vouIndexes"] = vouIndexes;

                ViewState["recCount"] = recCount;
                ViewState["vouCountStatic"] = vouCountStatic;
                ViewState["vouToBeCreatedCount"] = vouToBeCreatedCount;

                ViewState["branch"] = branch;
                ViewState["EPF"] = EPF;
                ViewState["clmno"] = clmno;
                ViewState["phname"] = phname;

                Session["okCLicked"] = "0";
            }
            else
            {
                if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }

                if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
                if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
                if (ViewState["arrListNom"] != null) { arrListNom = (ArrayList)ViewState["arrListNom"]; }
                if (ViewState["arrListLHI"] != null) { arrListLHI = (ArrayList)ViewState["arrListLHI"]; }
                if (ViewState["ASIarr"] != null) { ASIarr = (string[])ViewState["ASIarr"]; }
                if (ViewState["LPTarr"] != null) { LPTarr = (string[])ViewState["LPTarr"]; }
                if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState["vouIndexes"]; }
                if (ViewState["recCount"] != null) { recCount = int.Parse(ViewState["recCount"].ToString()); }
                if (ViewState["vouCountStatic"] != null) { vouCountStatic = int.Parse(ViewState["vouCountStatic"].ToString()); }
                if (ViewState["vouToBeCreatedCount"] != null) { vouToBeCreatedCount = int.Parse(ViewState["vouToBeCreatedCount"].ToString()); }

                if (ViewState["branch"] != null) { branch = int.Parse(ViewState["branch"].ToString()); }
                if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
                if (ViewState["clmno"] != null) { clmno = long.Parse(ViewState["clmno"].ToString()); }
                if (ViewState["phname"] != null) { phname = ViewState["phname"].ToString(); }
            }
            #endregion

            //bool repud = false;

            //string dthrepusel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and REPUOK='OK'";
            //if (dthpayObj.existRecored(dthrepusel) != 0)
            //{
            //    repud = true;
            //}

            int index = 0;
            double amount = 0;
            foreach (string str in vouIndexes)
            {
                index = int.Parse(str);

                //*********** creating controls *************
                if (payee.Equals("NOM"))
                {
                    #region
                    double nomiShare = 0;
                    foreach (string[] strArr in arrListNom)
                    {
                        NOMNUM = int.Parse(strArr[4]);
                        if (index == NOMNUM)
                        {
                            name = strArr[0];
                            addr1 = strArr[1];
                            addr2 = strArr[2];
                            addr3 = strArr[7];
                            addr4 = strArr[8];
                            //PER = int.Parse(strArr[3]);
                            nomiShare = double.Parse(strArr[5]);
                            amount = this.Sliamount(polno, "NOM", MOS, NOMNUM, "NP");
                            nomiShare -= amount;
                            this.createVouDetTable(name, addr1, addr2, addr3, addr4, nomiShare, NOMNUM, "0", "Nominee");
                        }
                    }
                    #endregion
                }
                else if (payee.Equals("ASI"))
                {
                    #region
                    name = ASIarr[0];
                    addr1 = ASIarr[1];
                    addr2 = ASIarr[2];
                    addr3 = ASIarr[3];
                    addr4 = "";
                    acctNo = ASIarr[4];
                    amount = this.Sliamount(polno, "ASI", MOS, 1, "NP");
                    totamount -= amount;
                    this.createVouDetTable(name, addr1, addr2, addr3, addr4, totamount, index, acctNo.ToString(), "Assignee");
                    #endregion
                }
                else if (payee.Equals("LPT"))
                {
                    #region
                    name = LPTarr[0];
                    addr1 = LPTarr[1];
                    addr2 = LPTarr[2];
                    addr3 = LPTarr[3];
                    addr4 = LPTarr[4];
                    amount = this.Sliamount(polno, "LPT", MOS, 1, "NP");
                    totamount -= amount;
                    this.createVouDetTable(name, addr1, addr2, addr3, addr4, totamount, index, "0", "Living Partner");
                    #endregion
                }
                else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                {
                    #region
                    double heireShare = 0;
                    string theHeire = "";
                    foreach (string[] hd in arrListLHI)
                    {
                        heireNo = int.Parse(hd[4]);
                        if (index == heireNo)
                        {
                            theHeire = hd[0];
                            name = hd[1];
                            addr1 = hd[2];
                            addr2 = hd[3];
                            addr3 = hd[7];
                            addr4 = hd[8];
                            heireShare = double.Parse(hd[6]);
                            amount = this.Sliamount(polno, "LHI", MOS, heireNo, "NP");
                            heireShare -= amount;
                            this.createVouDetTable(name, addr1, addr2, addr3, addr4, heireShare, heireNo, "0", theHeire);
                        }
                    }
                    #endregion
                }
            }

            if (index == 0) { this.btnOK.Enabled = false; }

            this.lblpolno.Text = polno.ToString();
            if (MOS.Equals("M")) { this.lblmof.Text = "Main LIfe"; }
            else if (MOS.Equals("S")) { this.lblmof.Text = "Spouce"; }
            else if (MOS.Equals("2")) { this.lblmof.Text = "Second Life"; }

            #region //------------ PHNAME ---------------------
            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR  from LPHS.PHNAME where pnpol='" + polno + "'";
            dthpayObj.readSql(sql);
            OracleDataReader oraDtReader = dthpayObj.oraComm.ExecuteReader();
            while (oraDtReader.Read())
            {
                //Commented by Dushan 28/07/2009 - Phname is not available if no initials...
                /*
                if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                {
                    phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                }
                else { phname = ""; }
                */
                phname = "";
                if (!oraDtReader.IsDBNull(0)) { phname = oraDtReader.GetString(0); }
                if (!oraDtReader.IsDBNull(1)) { phname = phname + " " + oraDtReader.GetString(1); }
                if (!oraDtReader.IsDBNull(2)) { phname = phname + " " + oraDtReader.GetString(2); }
            }
            oraDtReader.Close();
            this.lblphname.Text = phname;

            #endregion

            dthpayObj.connclose();
        }
        catch (Exception ex)
        {
            dthpayObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        

        if(Session["okCLicked"].ToString() != "1")
        {
            Session["okCLicked"] = "1";
            #region---------------Check Made Payments-----------------
            #endregion

            dthpayObj = new DataManager();
            DataManager dm = new DataManager();
            try
            {
                int PAY_MODE = 1, LASTDUE = 0, NEXTDUE = 0, START_DATE = 0, PAYMENT_COUNT = 0, TOTAL_PYMNTS = 0; //END_DATE = 0,
                double PAY_AMT = 0, PREM = 0, GROSSCLM = 0, NETCLM = 0;

                dm.begintransaction();
                string clmnoSel = "select DRCLMNO, POL_COMPLETED, AMT_TO_COMPLETE, EXGRACIA_AMOUNT, ADB_LATEPAY, IS_FUTUER_PAYMENT from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";
                dthpayObj.readSql(clmnoSel);
                OracleDataReader clmnoReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (clmnoReader.Read())
                {
                    if (!clmnoReader.IsDBNull(0)) { clmno = clmnoReader.GetInt32(0); } else { clmno = 0; }
                    if (!clmnoReader.IsDBNull(1)) { START_DATE = clmnoReader.GetInt32(1); } else { START_DATE = 0; }
                    if (!clmnoReader.IsDBNull(3)) { exgramt = clmnoReader.GetDouble(3); } else { exgramt = 0; }
                    if (!clmnoReader.IsDBNull(4)) { adblatepay = clmnoReader.GetString(4); } else { adblatepay = "N"; }
                    if (!clmnoReader.IsDBNull(5)) { isFuturePayment = clmnoReader.GetString(5); } else { isFuturePayment = ""; }
                }
                clmnoReader.Close();
                //clmnoReader.Dispose();

                string vounum = "";
                int vouNoInqCount = 0;

                //??????????????????

                #region ---------- child protection -----

                int PHCOM = 0; int PHTBL = 0; int PHTRM = 0; int PHSUM = 0; int PHMOD = 0; double PHPRM = 0; string PHSTA = ""; int DUE = 0;
                string lpolhisSel = "select PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHSTA, PHDUE from LPHS.LPOLHIS where PHPOL = " + polno + " and phmos = '" + MOS + "' and phtyp = 'D' ";
                if (dthpayObj.existRecored(lpolhisSel) != 0)
                {
                    dthpayObj.readSql(lpolhisSel);
                    OracleDataReader lpolhisReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lpolhisReader.Read())
                    {
                        if (!lpolhisReader.IsDBNull(0)) { PHCOM = lpolhisReader.GetInt32(0); } else { PHCOM = 0; }
                        if (!lpolhisReader.IsDBNull(1)) { PHTBL = lpolhisReader.GetInt32(1); } else { PHTBL = 0; }
                        if (!lpolhisReader.IsDBNull(2)) { PHTRM = lpolhisReader.GetInt32(2); } else { PHTRM = 0; }
                        if (!lpolhisReader.IsDBNull(3)) { PHSUM = lpolhisReader.GetInt32(3); } else { PHSUM = 0; }
                        if (!lpolhisReader.IsDBNull(4)) { PHMOD = lpolhisReader.GetInt32(4); } else { PHMOD = 0; }
                        if (!lpolhisReader.IsDBNull(5)) { PHPRM = lpolhisReader.GetDouble(5); } else { PHPRM = 0; }
                        //if (!lpolhisReader.IsDBNull(6)) { PHSTA = lpolhisReader.GetString(6); } else { PHSTA = ""; }
                        if (!lpolhisReader.IsDBNull(7)) { DUE = lpolhisReader.GetInt32(7); } else { DUE = 0; }
                    }
                    lpolhisReader.Close();
                    //lpolhisReader.Dispose();
                }
                string dthintsel = "select DDTOFDTH, DPOLST from LPHS.DTHINT where DPOLNO=" + polno + " and DMOS='" + MOS + "'";
                if (dthpayObj.existRecored(dthintsel) != 0)
                {
                    dthpayObj.readSql(dthintsel);
                    OracleDataReader dthintreader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintreader.Read())
                    {
                        if (!dthintreader.IsDBNull(0)) { dthdate = dthintreader.GetInt32(0); } else { dthdate = 0; }
                        if (!dthintreader.IsDBNull(1)) { PHSTA = dthintreader.GetString(1); } else { PHSTA = ""; }
                    }
                    dthintreader.Close();
                    //dthintreader.Dispose();
                }

                int matdate = int.Parse((int.Parse(PHCOM.ToString().Substring(0, 4)) + PHTRM).ToString() + PHCOM.ToString().Substring(4, 4));


                //BonusCal dthbonus = new BonusCal();            
                //interimbonus = dthbonus.VestedBonus(polno, MOS)[0];
                //vestedbonus = dthbonus.VestedBonus(polno, MOS)[1];
                if (PHSTA.Equals("I"))
                {
                    #region
                    if ((PHTBL == 39 || PHTBL == 46 || PHTBL == 49 || PHTBL == 34) && MOS.Equals("M") && isFuturePayment != "N")
                    {
                        TOTAL_PYMNTS = int.Parse(matdate.ToString().Substring(0, 4)) - int.Parse(START_DATE.ToString().Substring(0, 4)) + 1;

                        //NEXTDUE = int.Parse(START_DATE.ToString().Substring(0, 6));
                        int dthmmdd, commmdd, dthyr, commm;
                        string comstr;
                        dthmmdd = int.Parse(dthdate.ToString().Substring(4, 4));
                        commmdd = int.Parse(PHCOM.ToString().Substring(4, 4));
                        dthyr = int.Parse(dthdate.ToString().Substring(0, 4));
                        commm = int.Parse(PHCOM.ToString().Substring(4, 2));

                        if (commm.ToString().Length < 2) { comstr = "0" + commm.ToString(); }
                        else { comstr = commm.ToString(); }
                        if (commmdd <= dthmmdd) { NEXTDUE = int.Parse(Convert.ToString(dthyr + 1) + comstr); }
                        else { NEXTDUE = int.Parse(dthyr.ToString() + comstr); }

                        if (PHTBL == 34)
                        {
                            string periodicpaydetinsert = "INSERT INTO LCLM.PERIODIC_PAYDET (POLNO,CLMTYPE, PAYMENT_DUE, PAID_AMT,DIS_CLM_TYP,LIFE_TYP, INTIMNO) VALUES (" + polno + ",'DTC'," + int.Parse(matdate.ToString().Substring(0, 6)) + ", 40000,'DTH','" + MOS + "'," + clmno + ")";
                            dm.insertRecords(periodicpaydetinsert);
                        }

                        //else if (PHTBL == 38) { }
                        if (PHTBL == 39 || PHTBL == 49)
                        {
                            PAY_AMT = PHSUM * .15; PREM = PAY_AMT; GROSSCLM = PAY_AMT * TOTAL_PYMNTS; NETCLM = GROSSCLM;

                            string periodicpaydetSel = "select POLNO from LCLM.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO = '" + clmno + "'";
                            if (dthpayObj.existRecored(periodicpaydetSel) == 0)
                            {
                                //string child_prot_mas_insert = "INSERT INTO LCLM.CHILD_PROT_MAS (POLNO ,PTABLE ,PAY_MODE ,LASTDUE ,NEXTDUE ,START_DATE ,END_DATE ,PAY_AMT ,PREM ,PAYMENT_COUNT ,TOTAL_PYMNTS ,GROSSCLM ,NETCLM, MATDATE, SUMASSURED_PVAL, CLAIMNO ) " +
                                //" VALUES (" + polno + " ," + PHTBL + " ," + PAY_MODE + " ," + LASTDUE + " ," + NEXTDUE + " ," + START_DATE + " ," + matdate + " ," + PAY_AMT + " ," + PREM + " ," + PAYMENT_COUNT + " ," + TOTAL_PYMNTS + " ," + GROSSCLM + " ," + NETCLM + ", " + matdate + ", " + PHSUM + ", " + clmno + " )";
                                //dthpayObj.insertRecords(child_prot_mas_insert);

                                while (int.Parse(NEXTDUE.ToString() + PHCOM.ToString().Substring(6, 2)) <= matdate)
                                {
                                    string periodicpaydetinsert = "INSERT INTO LCLM.PERIODIC_PAYDET (POLNO,CLMTYPE, PAYMENT_DUE, PAID_AMT,DIS_CLM_TYP,LIFE_TYP, INTIMNO) VALUES (" + polno + ",'DTC'," + NEXTDUE + "," + PAY_AMT + ",'DTH','" + MOS + "'," + clmno + ")";
                                    dm.insertRecords(periodicpaydetinsert);
                                    NEXTDUE = int.Parse(Convert.ToString(int.Parse(NEXTDUE.ToString().Substring(0, 4)) + 1) + NEXTDUE.ToString().Substring(4, 2));
                                }
                            }
                        }
                        else if (PHTBL == 46)
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                int pmntdate = int.Parse(matdate.ToString().Substring(0, 4)) + i;
                                PAY_AMT = PHSUM * .35;
                                NEXTDUE = int.Parse(pmntdate.ToString() + matdate.ToString().Substring(4, 2));
                                string periodicpaySel = "select POLNO from LCLM.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO = '" + clmno + "' and PAYMENT_DUE=" + NEXTDUE + "";
                                if (dthpayObj.existRecored(periodicpaySel) == 0)
                                {
                                    string periodicpaydetinsert = "INSERT INTO LCLM.PERIODIC_PAYDET (POLNO,CLMTYPE, PAYMENT_DUE, PAID_AMT,DIS_CLM_TYP,LIFE_TYP, INTIMNO) VALUES (" + polno + ",'DTC'," + NEXTDUE + "," + PAY_AMT + ",'DTH','" + MOS + "'," + clmno + ")";
                                    dm.insertRecords(periodicpaydetinsert);
                                }
                            }
                        }

                    }
                    if (PHTBL == 38 && MOS.Equals("M"))
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            int pmntdate = int.Parse(matdate.ToString().Substring(0, 4)) - i;
                            if (i == 0) { PAY_AMT = PHSUM * .4; }
                            else { PAY_AMT = PHSUM * .2; }
                            NEXTDUE = int.Parse(pmntdate.ToString() + matdate.ToString().Substring(4, 2));
                            string periodicpaySel = "select POLNO from LCLM.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO = '" + clmno + "' and PAYMENT_DUE=" + NEXTDUE + "";
                            if (dthpayObj.existRecored(periodicpaySel) == 0)
                            {
                                string periodicpaydetinsert = "INSERT INTO LCLM.PERIODIC_PAYDET (POLNO,CLMTYPE, PAYMENT_DUE, PAID_AMT,DIS_CLM_TYP,LIFE_TYP, INTIMNO) VALUES (" + polno + ",'DTC'," + NEXTDUE + "," + PAY_AMT + ",'DTH','" + MOS + "'," + clmno + ")";
                                dm.insertRecords(periodicpaydetinsert);
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    //General gg = new General();
                    if (PHTBL == 38 && MOS.Equals("M") && isFuturePayment != "N")
                    {
                        double payamount = gg.minumuthulapsepayment(polno, MOS, dthpayObj);
                        string periodicpaydetinsert = "INSERT INTO LCLM.PERIODIC_PAYDET (POLNO,CLMTYPE, PAYMENT_DUE, PAID_AMT,DIS_CLM_TYP,LIFE_TYP, INTIMNO) VALUES (" + polno + ",'DTC'," + int.Parse(matdate.ToString().Substring(0, 6)) + "," + payamount + ",'DTH','" + MOS + "'," + clmno + ")";
                        dm.insertRecords(periodicpaydetinsert);
                    }
                }

                #endregion

                #region------------Account Code----------
                string repupayok = "";

                string repudiatesel = "select POLICYNO, REPUOK from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='" + MOS + "'";

                if (dthpayObj.existRecored(repudiatesel) != 0)
                {
                    dthpayObj.readSql(repudiatesel);
                    OracleDataReader repupayread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (repupayread.Read())
                    {
                        if (!repupayread.IsDBNull(1)) { repupayok = repupayread.GetString(1); } else { repupayok = ""; }
                    }
                    repupayread.Close();
                }

                //if (repupayok.Equals("OK"))
                //{
                //    ACCODE = 2142;
                //}
                //else
                //{
                //    if (gg.IsVouAmtDeposit(dthpayObj, polno, MOS))
                //    {
                //        //Apply the deposit account number
                //        ACCODE = 1168;
                //    }
                //    else
                //    {
                //        ACCODE = 2118;
                //    }
                //}

                bool isdeposit = false;

                if (gg.IsVouAmtDeposit(dthpayObj, polno, MOS))
                {
                    //Apply the deposit account number
                    ACCODE = 1168;
                    isdeposit = true;
                }
                else
                {
                    ACCODE = 2118;
                }

                if (repupayok.Equals("OK") && !isdeposit)
                {
                    ACCODE = 2142;
                }
                #endregion

                foreach (string strobj in vouIndexes)
                {
                    double amount;
                    int index = int.Parse(strobj);
                    string s1 = "bknametxt" + index.ToString();
                    string s2 = "bkBrntxt" + index.ToString();
                    string s3 = "acctNotxt" + index.ToString();
                    string s4 = "slicAcctddl" + index.ToString();
                    string s5 = "txtInsname" + index.ToString();
                    //string s6 = "acctCodeddl" + index.ToString();

                    TextBox txtbkName = (TextBox)Table1.FindControl(s1);
                    TextBox txtbkBrn = (TextBox)Table1.FindControl(s2);
                    TextBox txtbkAcctNo = (TextBox)Table1.FindControl(s3);
                    DropDownList ddlslicAcct = (DropDownList)Table1.FindControl(s4);
                    TextBox txtNamewithins = (TextBox)Table1.FindControl(s5);
                    //DropDownList ddlaccCode = (DropDownList)Table1.FindControl(s6);

                    if (txtbkName != null) { bankkname = txtbkName.Text.Trim(); }
                    if (txtbkBrn != null) { bkBrn = txtbkBrn.Text.Trim(); }
                    if (txtbkAcctNo != null) { acctNo = txtbkAcctNo.Text.Trim(); }
                    if (ddlslicAcct != null) { SLIAcctNo = ddlslicAcct.SelectedItem.Value; }
                    if (txtNamewithins != null) { namewithins = txtNamewithins.Text; }
                    //if (ddlaccCode != null) { accCode = ddlaccCode.SelectedItem.Value; }

                    //ACCODE = int.Parse(accCode);
                    if ((acctNo == null) || (acctNo.Equals("")))
                    {

                        throw new Exception("Please Give the Customer Account No.");
                    }

                    //********* Update Payee Tables ***************************
                    if (payee.Equals("NOM"))
                    {
                        #region
                        double nomiShare = 0, nomexgr = 0;
                        foreach (string[] strArr in arrListNom)
                        {
                            NOMNUM = int.Parse(strArr[4]);
                            if (index == NOMNUM)
                            {
                                name = strArr[0];
                                addr1 = strArr[1];
                                addr2 = strArr[2];
                                addr3 = strArr[7];
                                addr4 = strArr[8];
                                nomiShare = double.Parse(strArr[5]);
                                amount = this.Sliamount(polno, "NOM", MOS, NOMNUM, "NP");
                                nomiShare -= amount;
                                vouamount = nomiShare;
                                nomexgr = gg.ExgraciaAmt(polno, MOS, adblatepay, exgramt, payee, NOMNUM, dm);
                                if (nomiShare - nomexgr < 0) { nomexgr += nomiShare - nomexgr; }
                                vounum = this.createVoucher(nomiShare, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo, nomexgr);
                                string nomUpd = "UPDATE LUND.NOMINEE SET VOUSTA = 'Y' , VOUNO = '" + vounum + "', voudate=to_char(sysdate, 'yyyymmdd'), NOMSHARE=" + nomiShare + " WHERE polno =" + polno + " and nomno = " + NOMNUM + "";
                                dm.insertRecords(nomUpd);
                                vouNoInqCount++;
                                this.createVouNoTable(name, nomiShare, vounum, vouNoInqCount);
                                if (amount > 0)
                                {
                                    this.slicvouupdate(vounum, NOMNUM, "NOM");
                                }
                                this.updatePaidNo(polno, clmno, MOS, vounum);
                            }
                        }
                        #endregion
                    }
                    else if (payee.Equals("LHI") || payee.Equals("ML") || payee.Equals("SL"))
                    {
                        #region
                        double hierexgr, heireShare = 0;
                        string theHeire = "";
                        foreach (string[] hd in arrListLHI)
                        {
                            heireNo = int.Parse(hd[4]);
                            if (index == heireNo)
                            {
                                theHeire = hd[0];
                                name = hd[1];
                                addr1 = hd[2];
                                addr2 = hd[3];
                                addr3 = hd[7];
                                addr4 = hd[8];
                                amount = this.Sliamount(polno, "LHI", MOS, heireNo, "NP");
                                heireShare = double.Parse(hd[6]);
                                heireShare -= amount;
                                vouamount = heireShare;
                                hierexgr = gg.ExgraciaAmt(polno, MOS, adblatepay, exgramt, "LHI", heireNo, dm);
                                if (heireShare - hierexgr < 0) { hierexgr += heireShare - hierexgr; }
                                vounum = this.createVoucher(heireShare, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo, hierexgr);
                                string LHUpd = "UPDATE LPHS.LEGAL_HIRES SET VOUSTA = 'Y' , VOUNO = '" + vounum + "', VOUDATE=to_char(sysdate, 'yyyymmdd') WHERE LHPOLNO = " + polno + " and LHMOF ='" + MOS + "' and LHHNO =" + heireNo + " ";
                                dm.insertRecords(LHUpd);
                                vouNoInqCount++;
                                this.createVouNoTable(name, heireShare, vounum, vouNoInqCount);
                                if (amount > 0)
                                {
                                    this.slicvouupdate(vounum, heireNo, "LHI");
                                }
                                this.updatePaidNo(polno, clmno, MOS, vounum);
                            }
                        }
                        #endregion
                    }
                    else if (payee.Equals("ASI"))
                    {
                        #region
                        double asiamt = totamount, asiexgr = 0;
                        name = ASIarr[0];
                        addr1 = ASIarr[1];
                        addr2 = ASIarr[2];
                        addr3 = ASIarr[3];
                        addr4 = "";
                        amount = this.Sliamount(polno, "ASI", MOS, 1, "NP");
                        asiamt -= amount;
                        vouamount = asiamt;
                        asiexgr = gg.ExgraciaAmt(polno, MOS, adblatepay, exgramt, payee, 1, dm);
                        if (asiamt - asiexgr < 0) { asiexgr += asiamt - asiexgr; }
                        vounum = this.createVoucher(asiamt, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo, asiexgr);
                        string assigneeUpd = "UPDATE LUND.ASSIGNEE SET VOUSTA = 'Y' , VOUNO = '" + vounum + "' WHERE POLICY_NO = " + polno + "";
                        dm.insertRecords(assigneeUpd);
                        vouNoInqCount++;
                        this.createVouNoTable(name, asiamt, vounum, vouNoInqCount);
                        if (amount > 0)
                        {
                            this.slicvouupdate(vounum, 1, "ASI");
                        }
                        this.updatePaidNo(polno, clmno, MOS, vounum);
                        #endregion
                    }
                    else if (payee.Equals("LPT"))
                    {
                        #region
                        double lptamt = 0, lptexgr;
                        name = LPTarr[0];
                        addr1 = LPTarr[1];
                        addr2 = LPTarr[2];
                        addr3 = LPTarr[3];
                        addr4 = LPTarr[4];
                        amount = this.Sliamount(polno, "LPT", MOS, 1, "NP");
                        lptamt = double.Parse(LPTarr[5]);
                        lptamt -= amount;
                        vouamount = lptamt;
                        lptexgr = gg.ExgraciaAmt(polno, MOS, adblatepay, exgramt, payee, 1, dm);
                        if (lptamt - lptexgr < 0) { lptexgr += lptamt - lptexgr; }
                        vounum = this.createVoucher(lptamt, name, addr1, addr2, addr3, addr4, acctNo, bankkname, bkBrn, SLIAcctNo, lptexgr);
                        string LPTUpd = "UPDATE LUND.LIVING_PRT SET VOUSTA = 'Y' , VOUNO = '" + vounum + "' WHERE POLNO = " + polno + "";
                        dm.insertRecords(LPTUpd);
                        vouNoInqCount++;
                        this.createVouNoTable(name, lptamt, vounum, vouNoInqCount);
                        if (amount > 0)
                        {
                            this.slicvouupdate(vounum, 1, "LPT");
                        }
                        this.updatePaidNo(polno, clmno, MOS, vounum);
                        #endregion
                    }

                }// foreach end ***********

                //------- removing unsettleable demands ??????? -----
                //string demsel = "select pdpol from lphs.demand where pdpol = " + polno + " and pdcod <> 'D' ";

                if (((vouCountStatic + vouToBeCreatedCount) == recCount) && (amtOut <= 5))
                {
                    //payment complete for total payment
                    string dthrefUpd = "UPDATE LPHS.DTHREF SET COMPLETED = 'Y', PAYAUTDT = " + int.Parse(this.setDate()[0]) + ", PAYAUTEPF = '" + EPF + "' WHERE DRPOLNO =" + polno + " and  DRMOS = '" + MOS + "' ";
                    dm.insertRecords(dthrefUpd);
                    string dreqUpd = "UPDATE LPHS.DREQ SET DRCMPLYN = 'Y' WHERE  DRPOL =" + polno + " and  DRTYP = '" + MOS + "'";
                    dm.insertRecords(dreqUpd);
                    //this.btnOK.Enabled = false;
                }
                //else { this.btnOK.Enabled = true; }

                //#region -----------------------Writing on lphs.Death_Sys_No File--------------------------------------

                ////int count = 0;
                ////int maxPaidNo = 0;
                ////int paidNo = 0;
                ////string dthSysSel = "select POLICY_NO, CLAIM_NO from LPHS.DEATH_SYS_NO where POLICY_NO=" + polno + " and CLAIM_NO=" + clmno + "";

                ////string dthSysCount = "select COUNT(POLICY_NO) from LPHS.DEATH_SYS_NO";
                ////dthpayObj.readSql(dthSysCount);
                ////OracleDataReader dthSysCountReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                ////dthSysCountReader.Read();
                ////if (!dthSysCountReader.IsDBNull(0)) { count = dthSysCountReader.GetInt32(0); } else { count = 0; }
                ////dthSysCountReader.Close();
                ////dthSysCountReader.Dispose();

                ////if (dthpayObj.existRecored(dthSysSel) != 0)
                ////{
                ////    if (count == 1)
                ////    {
                ////        string dthSysNoInsert = "UPDATE LPHS.DEATH_SYS_NO SET PAID_NO = 37500 where POLICY_NO=" + polno + " and CLAIM_NO=" + clmno + "";
                ////        dthpayObj.insertRecords(dthSysNoInsert);
                ////    }
                ////    else
                ////    {
                ////        string dthMaxPaidNo = "SELECT MAX(PAID_NO) FROM LPHS.DEATH_SYS_NO";

                ////        dthpayObj.readSql(dthMaxPaidNo);
                ////        OracleDataReader dthSysReader = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                ////        dthSysReader.Read();
                ////        if (!dthSysReader.IsDBNull(0)) { maxPaidNo = dthSysReader.GetInt32(0); } else { maxPaidNo = 0; }
                ////        dthSysReader.Close();
                ////        dthSysReader.Dispose();

                ////        paidNo = maxPaidNo + 1;
                ////        string dthSysNoInsert = "UPDATE LPHS.DEATH_SYS_NO SET PAID_NO = " + paidNo + " where POLICY_NO=" + polno + " and CLAIM_NO=" + clmno + "";
                ////        dthpayObj.insertRecords(dthSysNoInsert);
                ////    }
                ////}

                ////check old payment exist
                //string chkOldPayment = "select * from cashbook.temp_cb where polno='" + polno + "' and vouno<>'" + vounum + "' and claimno='" + clmno + "' and voutyp= 'Death' and accode > 0";

                //if (dthpayObj.existRecored(chkOldPayment) == 0)
                //{
                //    int paidNo = 0;
                //    string dthSysSel = "select POLICY_NO, CLAIM_NO from LPHS.DEATH_SYS_NO where POLICY_NO=" + polno + " and CLAIM_NO=" + clmno + " and P_TYPE='" + MOS + "'";

                //    string dthControlPaidNo = "SELECT PAID_NO FROM LPHS.DEATH_SYS_CONTROL";

                //    dthpayObj.readSql(dthControlPaidNo);
                //    OracleDataReader dthControlReader = dthpayObj.oraComm.ExecuteReader();
                //    dthControlReader.Read();
                //    if (!dthControlReader.IsDBNull(0)) { paidNo = dthControlReader.GetInt32(0); } else { paidNo = 0; }
                //    dthControlReader.Close();
                //    dthControlReader.Dispose();

                //    if (dthpayObj.existRecored(dthSysSel) == 0)
                //    {
                //        string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO, PAID_NO) VALUES ( " + polno + " , " + clmno + ", '" + MOS + "', '0' , " + paidNo + ")";
                //        dthpayObj.insertRecords(dthSysNoInsert);
                //    }
                //    else
                //    {
                //        string dthSysNoUpdate = "UPDATE LPHS.DEATH_SYS_NO SET PAID_NO = " + paidNo + " where POLICY_NO=" + polno + " and CLAIM_NO=" + clmno + "";
                //        dthpayObj.insertRecords(dthSysNoUpdate);
                //    }

                //    paidNo += 1;

                //    string dthControlUpdate = "UPDATE LPHS.DEATH_SYS_CONTROL SET PAID_NO=" + paidNo + "";
                //    dthpayObj.insertRecords(dthControlUpdate);
                //}
                //#endregion

                

                this.lblsuccess.Text = "Vouchers Successfully Created";
                this.btnOK.Enabled = false;

                dm.commit();
                dthpayObj.connclose();
                dm.connClose();
            }
            catch (Exception ex)
            {
                Session["okCLicked"] = "0";
                dm.rollback();
                dthpayObj.connclose();
                dm.connClose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
                
            }
        }

        
    }

    private void updatePaidNo(long polNo, long claimNo, string mof, string vouNum)
    {
        //check old payment exist
        string chkOldPayment = "select * from cashbook.temp_cb where polno='" + polNo + "' and vouno<>'" + vouNum + "' and claimno='" + claimNo + "' and voutyp= 'Death' and accode > '0' and vouno like ('T/%/%/DT%')";

        if (dthpayObj.existRecored(chkOldPayment) == 0)
        {
            int paidNo = 0;
            string dthSysSel = "select POLICY_NO, CLAIM_NO from LPHS.DEATH_SYS_NO where POLICY_NO=" + polNo + " and CLAIM_NO=" + claimNo + " and P_TYPE='" + mof + "'";

            string dthControlPaidNo = "SELECT PAID_NO FROM LPHS.DEATH_SYS_CONTROL";

            dthpayObj.readSql(dthControlPaidNo);
            OracleDataReader dthControlReader = dthpayObj.oraComm.ExecuteReader();
            dthControlReader.Read();
            if (!dthControlReader.IsDBNull(0)) { paidNo = dthControlReader.GetInt32(0); } else { paidNo = 0; }
            dthControlReader.Close();
            dthControlReader.Dispose();

            if (dthpayObj.existRecored(dthSysSel) == 0)
            {
                string dthSysNoInsert = "INSERT INTO LPHS.DEATH_SYS_NO (POLICY_NO ,CLAIM_NO, P_TYPE, ADMIT_NO, PAID_NO) VALUES ( " + polNo + " , " + claimNo + ", '" + mof + "', '0' , " + paidNo + ")";
                dthpayObj.insertRecords(dthSysNoInsert);
            }
            else
            {
                string dthSysNoUpdate = "UPDATE LPHS.DEATH_SYS_NO SET PAID_NO = " + paidNo + " where POLICY_NO=" + polNo + " and CLAIM_NO=" + claimNo + "";
                dthpayObj.insertRecords(dthSysNoUpdate);
            }

            paidNo += 1;

            string dthControlUpdate = "UPDATE LPHS.DEATH_SYS_CONTROL SET PAID_NO=" + paidNo + "";
            dthpayObj.insertRecords(dthControlUpdate);
        }
    }

    //private void createVouDetTable(string name, string ad1, string ad2, string ad3, string ad4, double totamount, int rowno, string accctNo, string payee, bool repudation)
    private void createVouDetTable(string name, string ad1, string ad2, string ad3, string ad4, double totamount, int rowno, string accctNo, string payee)
    {
        gg = new General();
        namewithins = gg.NameWithInitials(name.Trim());
        //accCodeList = gg.getAccountCodeList();

        TableRow trow01 = new TableRow();
        TableRow trow02 = new TableRow();
        TableRow trow03 = new TableRow();
        TableRow trow04 = new TableRow();
        TableRow trow05 = new TableRow();
        TableRow trow06 = new TableRow();
        TableRow trow07 = new TableRow();
        TableRow trow08 = new TableRow();
        TableRow trow09 = new TableRow();
        TableRow trow10 = new TableRow();
        TableRow trow11 = new TableRow();
        TableRow trow12 = new TableRow();
        //TableRow trow13 = new TableRow();

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
        TableCell tcel71 = new TableCell();
        TableCell tcel72 = new TableCell();
        TableCell tcel81 = new TableCell();
        TableCell tcel82 = new TableCell();
        TableCell tcel91 = new TableCell();
        TableCell tcel92 = new TableCell();
        TableCell tcel101 = new TableCell();
        TableCell tcel111 = new TableCell();
        TableCell tcel102 = new TableCell();
        TableCell tcel112 = new TableCell();
        TableCell tcel121 = new TableCell();
        TableCell tcel122 = new TableCell();
        //TableCell tcel131 = new TableCell();
        //TableCell tcel132 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl21 = new Label();
        Label lbl22 = new Label();
        Label lbl31 = new Label();
        Label lbl41 = new Label();
        Label lbl42 = new Label();
        Label lbl51 = new Label();
        Label lbl52 = new Label();
        Label lbl61 = new Label();
        Label lbl62 = new Label();
        Label lbl71 = new Label();
        Label lbl72 = new Label();
        Label lbl81 = new Label();
        Label lbl111 = new Label();
        TextBox txt01 = new TextBox();
        Label lbl91 = new Label();
        TextBox txt02 = new TextBox();
        Label lbl101 = new Label();
        TextBox txt03 = new TextBox();
        Label lbl121 = new Label();
        TextBox txt04 = new TextBox();
        //Label lbl131 = new Label();
        //TextBox txt04 = new TextBox();
        DropDownList ddl122 = new DropDownList();
        //DropDownList ddl132 = new DropDownList();

        lbl11.ID = "totamontDesc" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "totamontDesc" + rowno); //Text Value
        lbl11.Text = "Voucher Amount : ";

        lbl12.ID = "totamont" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "totamont" + rowno); //Text Value
        lbl12.Text = String.Format("{0:N}", totamount);

        lbl21.ID = "fullnameDesc" + rowno;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "fullnameDesc" + rowno); //Text Value
        lbl21.Text = "Payee Name : ";

        lbl22.ID = "fullname" + rowno;
        lbl22.Attributes.Add("runat", "Server");
        lbl22.Attributes.Add("Name", "fullname" + rowno); //Text Value
        lbl22.Text = name;

        lbl31.ID = "insName" + rowno;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "insName" + rowno); //Text Value
        lbl31.Text = "Name with Initials : ";

        lbl41.ID = "ad1Desc" + rowno;
        lbl41.Attributes.Add("runat", "Server");
        lbl41.Attributes.Add("Name", "ad1Desc" + rowno); //Text Value
        lbl41.Text = "Address Part1 : ";

        lbl42.ID = "ad1" + rowno;
        lbl42.Attributes.Add("runat", "Server");
        lbl42.Attributes.Add("Name", "ad1" + rowno); //Text Value
        lbl42.Text = ad1;

        lbl51.ID = "add2desc" + rowno;
        lbl51.Attributes.Add("runat", "Server");
        lbl51.Attributes.Add("Name", "add2desc" + rowno); //Text Value
        lbl51.Text = "Address Part2 : ";

        lbl52.ID = "ad2" + rowno;
        lbl52.Attributes.Add("runat", "Server");
        lbl52.Attributes.Add("Name", "ad2" + rowno); //Text Value
        lbl52.Text = ad2;

        lbl61.ID = "add3desc" + rowno;
        lbl61.Attributes.Add("runat", "Server");
        lbl61.Attributes.Add("Name", "add3desc" + rowno); //Text Value
        lbl61.Text = "Address Part3 : ";

        lbl62.ID = "ad3" + rowno;
        lbl62.Attributes.Add("runat", "Server");
        lbl62.Attributes.Add("Name", "ad3" + rowno); //Text Value
        lbl62.Text = ad3;

        lbl71.ID = "add4desc" + rowno;
        lbl71.Attributes.Add("runat", "Server");
        lbl71.Attributes.Add("Name", "add4desc" + rowno); //Text Value
        lbl71.Text = "Address Part4 : ";

        lbl72.ID = "ad4" + rowno;
        lbl72.Attributes.Add("runat", "Server");
        lbl72.Attributes.Add("Name", "ad5" + rowno); //Text Value
        lbl72.Text = ad4;

        lbl81.ID = "bkName" + rowno;
        lbl81.Attributes.Add("runat", "Server");
        lbl81.Attributes.Add("Name", "bkName" + rowno); //Text Value
        lbl81.Text = "Bank Name : ";

        lbl91.ID = "bkBrn" + rowno;
        lbl91.Attributes.Add("runat", "Server");
        lbl91.Attributes.Add("Name", "bkBrn" + rowno); //Text Value
        lbl91.Text = "Branch Name : ";

        lbl101.ID = "acctno" + rowno;
        lbl101.Attributes.Add("runat", "Server");
        lbl101.Attributes.Add("Name", "acctno" + rowno); //Text Value
        lbl101.Text = "Account Number : ";

        lbl111.ID = "payee" + rowno;
        lbl111.Attributes.Add("runat", "Server");
        lbl111.Attributes.Add("Name", "payee" + rowno); //Text Value
        lbl111.Text = "Payee : " + payee;

        lbl121.ID = "slicAcct" + rowno;
        lbl121.Attributes.Add("runat", "Server");
        lbl121.Attributes.Add("Name", "slicAcct" + rowno); //Text Value
        lbl121.Text = "SLI Account : ";

        //lbl131.ID = "acctCode" + rowno;
        //lbl131.Attributes.Add("runat", "Server");
        //lbl131.Attributes.Add("Name", "acctCode" + rowno); //Text Value
        //lbl131.Text = "Account Code : ";

        //txt01.MaxLength = 28;
        txt01.ID = "bknametxt" + rowno;
        txt01.Attributes.Add("runat", "Server");
        txt01.Attributes.Add("Name", "bknametxt" + rowno);
        txt01.Style["width"] = "400px";

        //txt02.MaxLength = 20;
        txt02.ID = "bkBrntxt" + rowno;
        txt02.Attributes.Add("runat", "Server");
        txt02.Attributes.Add("Name", "bkBrntxt" + rowno);
        txt02.Style["width"] = "400px";

        //txt03.MaxLength = 20;
        txt03.ID = "acctNotxt" + rowno;
        txt03.Attributes.Add("runat", "Server");
        txt03.Attributes.Add("Name", "acctNotxt" + rowno);
        txt03.Style["width"] = "400px";
        if (long.Parse(accctNo) > 0) { txt03.Text = accctNo.ToString(); txt03.ReadOnly = true; }

        txt04.ID = "txtInsname" + rowno;
        txt04.Attributes.Add("runat", "Server");
        txt04.Attributes.Add("Name", "txtInsname" + rowno);
        txt04.Style["width"] = "400px";
        txt04.Text = namewithins;

        //txt04.MaxLength = 10;
        //txt04.ID = "txtSLIacctNo" + rowno;
        //txt04.Attributes.Add("runat", "Server");
        //txt04.Attributes.Add("Name", "txtSLIacctNotxt" + rowno);
        //txt04.Style["width"] = "400px";

        ddl122.ID = "slicAcctddl" + rowno;
        ddl122.Attributes.Add("runat", "Server");
        ddl122.Attributes.Add("Name", "slicAcctddl" + rowno); //Text Value
        ddl122.Items.Add(new ListItem("1030001487", "1030001487"));
        ddl122.Items.Add(new ListItem("1364403002", "1364403002"));
        ddl122.Items.Add(new ListItem("0001092995", "0001092995"));
        ddl122.Items.Add(new ListItem("000000000962", "000000000962"));
        ddl122.SelectedValue = "000000000962";

        //ddl132.ID = "acctCodeddl" + rowno;
        //ddl132.Attributes.Add("runat", "Server");
        //ddl132.Attributes.Add("Name", "acctCodeddl" + rowno); //Text Value
        //ddl132.DataSource = accCodeList;
        //ddl132.DataBind();        

        //if (repudation == true)
        //{
        //    ddl132.ID = "acctCodeddl" + rowno;
        //    ddl132.Attributes.Add("runat", "Server");
        //    ddl132.Attributes.Add("Name", "acctCodeddl" + rowno); //Text Value
        //    ddl132.Items.Add(new ListItem("2142", "2142"));
        //    ddl132.Items.Add(new ListItem("2118", "2118"));
        //    ddl132.SelectedValue = "2142";
        //}
        //else
        //{
        //    ddl132.ID = "acctCodeddl" + rowno;
        //    ddl132.Attributes.Add("runat", "Server");
        //    ddl132.Attributes.Add("Name", "acctCodeddl" + rowno); //Text Value
        //    ddl132.Items.Add(new ListItem("2118", "2118"));
        //    ddl132.Items.Add(new ListItem("2142", "2142"));
        //    ddl132.SelectedValue = "2118";
        //}

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel21.Controls.Add(lbl21);
        tcel22.Controls.Add(lbl22);
        tcel31.Controls.Add(lbl31);
        tcel32.Controls.Add(txt04);
        tcel41.Controls.Add(lbl41);
        tcel42.Controls.Add(lbl42);
        tcel51.Controls.Add(lbl51);
        tcel52.Controls.Add(lbl52);
        tcel61.Controls.Add(lbl61);
        tcel62.Controls.Add(lbl62);
        tcel71.Controls.Add(lbl71);
        tcel72.Controls.Add(lbl72);
        tcel81.Controls.Add(lbl81);
        tcel82.Controls.Add(txt01);
        tcel91.Controls.Add(lbl91);
        tcel92.Controls.Add(txt02);
        tcel101.Controls.Add(lbl101);
        tcel102.Controls.Add(txt03);
        tcel111.Controls.Add(lbl111);
        tcel121.Controls.Add(lbl121);
        tcel122.Controls.Add(ddl122);
        //tcel131.Controls.Add(lbl131);
        //tcel132.Controls.Add(ddl132);

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
        trow07.Cells.Add(tcel71);
        trow07.Cells.Add(tcel72);
        trow08.Cells.Add(tcel81);
        trow08.Cells.Add(tcel82);
        trow09.Cells.Add(tcel91);
        trow09.Cells.Add(tcel92);
        trow10.Cells.Add(tcel101);
        trow10.Cells.Add(tcel102);
        trow11.Cells.Add(tcel111);

        trow12.Cells.Add(tcel121);
        trow12.Cells.Add(tcel122);

        //trow13.Cells.Add(tcel131);
        //trow13.Cells.Add(tcel132);

        Table1.Rows.Add(trow01);
        Table1.Rows.Add(trow02);
        Table1.Rows.Add(trow03);
        Table1.Rows.Add(trow04);
        Table1.Rows.Add(trow05);
        Table1.Rows.Add(trow06);
        Table1.Rows.Add(trow07);
        Table1.Rows.Add(trow08);
        Table1.Rows.Add(trow09);
        Table1.Rows.Add(trow10);
        Table1.Rows.Add(trow11);
        Table1.Rows.Add(trow12);
        //Table1.Rows.Add(trow13);
    }

    protected string createVoucher(double PAYVAL, string NAMEPAYEE1, string ADD1, string ADD2, string ADD3, string ADD4, string ACNUM, string BKNAM, string BKBRN, string SLIAcctNo, double exgramt)
    {
        try
        {
            General gg = new General();
            //int depacct;
            //--------- generating voucher number --------------
            string vouno = "";

            try
            {
                //vouno = dthpayObj.voucher_number(DateTime.Now.Year.ToString(), branch.ToString().Trim());
                vouno = gg.voucher_number(DateTime.Now.Year.ToString(), branch.ToString().Trim(), "D", dthpayObj);
            }
            catch (Exception ex)
            {
                throw new Exception("Voucher Number Generating Failed! :" + ex.Message);
            }

            //int ACCODE = 2118;          //one for deaths
            //int STATUS = 0;             //not deleted
            string USERID = EPF;
            int EXTDAT = int.Parse(setDate()[0]);
            string EXTTIM = DateTime.Now.ToString("HHmmss");
            //string ADD3 = "";

            if ((BKNAM != null) && (!BKNAM.Equals("")))
            {
                BKNAM = BKNAM.Replace("'", " ");
                BKNAM = BKNAM.Trim();
            }
            if ((BKBRN != null) && (!BKBRN.Equals("")))
            {
                BKBRN = BKBRN.Replace('\'', ' ');
                BKBRN = BKBRN.Trim();
            }

            ADD1 = this.adressRefine(ADD1);
            ADD2 = this.adressRefine(ADD2);
            ADD3 = this.adressRefine(ADD3);
            ADD4 = this.adressRefine(ADD4);

            ADD1 = ADD1.Trim();
            ADD2 = ADD2.Trim();
            ADD3 = ADD3.Trim();
            ADD4 = ADD4.Trim();

            //General gg = new General();   

            //string hname = BKNAM + " " + BKBRN + " " + ACNUM;
            bdb = new BankDetailsBreak(BKNAM, BKBRN, ACNUM, NAMEPAYEE1); //Editted By Dushan 05/02/2009 As Space for Bank Details are not enough as
            string hname = bdb.Hname1;                                   // Life Dept Requests.
            string hname2 = bdb.Hname2;
            string INSNAME = phname;

            string totamountStr1 = PAYVAL.ToString();
            string totamountStr = "";
            //string INSNAME = phname;

            //string sqllife_voudetl = "insert into cashbook.life_voudetl(VOUNO,POLNO,CLAIMNO,PAYVAL,ACCODE,NAMEPAYEE1,ADD1,ADD2,ADD3,ACNUM,STATUS," +
            //      "USERID,EXTDAT,EXTTIM,BKNAM,BKBRN,INSNAME) values ('" + vouno + "','" + polno + "','" + clmno + "'," + PAYVAL +
            //         "," + ACCODE + ",'" + NAMEPAYEE1 + "','" + ADD1 + "','" + ADD2 + "','" + ADD3 + "','" + ACNUM + "'," + STATUS + ",'" + USERID +
            //         "','" + EXTDAT + "','" + EXTTIM + "','" + BKNAM + "','" + BKBRN + "','" + phname + "' )";

            //dthpayObj.insertRecords(sqllife_voudetl);

            //for (int i = 0; i <= (21 - totamountStr1.Length); i++)
            //{
            //    if (i == 1) { totamountStr = "*" + totamountStr1; }
            //    else { totamountStr = "*" + totamountStr; }
            //}

            string formattedToday = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);

            #region //------------ temp_cb -----------------------

            string tempCB_select = "select * from CASHBOOK.TEMP_CB where vouno = '" + vouno + "' ";

            #region--------------------Branch no formating------------------
            string branchstr;
            if (branch.ToString().Length == 1) { branchstr = "00" + branch.ToString(); }
            else if (branch.ToString().Length == 2) { branchstr = "0" + branch.ToString(); }
            else { branchstr = branch.ToString(); }
            #endregion
            //if (payee.Equals("NOM")||payee.Equals("LHI")) 
            //{             
            //    NAMEPAYEE1 = gg.NameWithInitials(NAMEPAYEE1.Trim());
            //}

            if (dthpayObj.existRecored(tempCB_select) == 0)
            {
                PAYVAL = Math.Round(PAYVAL, 2);
                string tempCB_insert = "insert into cashbook.temp_cb(Class, busycode, Divcode, Bcode, Claimno, POLNO, HName, HName1, Totamount,  " +
                " Totamt, ACCode, Acno, VouNo, VOUDATE, BillDate, ClaimType, Addepf, Voutyp, Status, Print1, Authorized, Deleted, Chqcan, Payaut, Insname, Add1, Add2, Add3, Posted, Reprint, RECIPIENT_NAME, TRANSACTION_TYPE, GROSS_AMOUNT, ADD4) " +
                " VALUES ('L', '3', 'L', '" + branchstr + "', '" + clmno.ToString() + "', '" + polno.ToString() + "',  '" + hname + "', '" + hname2 + "', " + PAYVAL + ", " +
                " '" + String.Format("{0:N}", PAYVAL) + "', '" + ACCODE.ToString() + "', '" + SLIAcctNo + "','" + vouno + "', sysdate, sysdate, 'A', '" + EPF + "', 'Death','Pending', 0, 0, 0, 0, 0, '" + INSNAME + "', " +
                " '" + ADD1 + "', '" + ADD2 + "', '" + ADD3 + "', 0, 0, '" + namewithins + "', 'C', " + PAYVAL + ", '" + ADD4 + "')";
                dthpayObj.insertRecords(tempCB_insert);
            }
            else { throw new Exception("Voucher Already Created!"); }

            #endregion

            #region //-------------- TEMP_DETL -------------------

            #region------------------------Check Repudiation--------------------
            string repudationsel = "select * from LPHS.DTH_REPUDIATION where POLICYNO=" + polno + " and LIFE_TYPE='" + MOS + "'";
            if ((dthpayObj.existRecored(repudationsel) != 0) && (ACCODE == 2118))
            {
                exgramt = PAYVAL;
            }
            #endregion

            PAYVAL -= exgramt;
            PAYVAL = Math.Round(PAYVAL, 2);

            #region Task 34965

            int stagepayment = 0;
            string stagePaysql = "select STAGE_PAYMENT from lphs.dthref where DRPOLNO = " + polno + " and DRMOS = '" + MOS + "' ";

            if (dthpayObj.existRecored(stagePaysql) != 0)
            {
                dthpayObj.readSql(stagePaysql);
                OracleDataReader stageread = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (stageread.Read())
                {
                    if (!stageread.IsDBNull(0)) { stagepayment = stageread.GetInt32(0); } else { stagepayment = 0; }
                }
                stageread.Close();
            }

            PAYVAL -= stagepayment;
            PAYVAL = Math.Round(PAYVAL, 2);
            if (stagepayment > 0)
            {
                string lclmmastSel = "select pvouno, pvoudat, pdocno,PPAYAMT from lclm.lcmmast where ptyp = 2 and ppolno = " + polno + " ";
                if (dthpayObj.existRecored(lclmmastSel) != 0)
                {
                    string stagePayUpdate = "UPDATE lclm.lcmmast SET pvouno ='" + vouno + "',pvoudat=to_number(to_char(sysdate,'yyyyMMdd')) where ptyp = 2 and ppolno = " + polno + " and pvoudat=0";
                    dthpayObj.insertRecords(stagePayUpdate);
                }

                //Acount Code for stage payment 2235
                string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                        "VALUES ('" + vouno + "' ,'2235' ,  " + stagepayment + " ,0 ,0 ,  " + stagepayment + " )";
                dthpayObj.insertRecords(temp_detl_insert);
            }

            #endregion

            string temp_detl_select = "select * from CASHBOOK.TEMP_DETL where vouno = '" + vouno + "' and ACCODE=" + ACCODE + "";

            if (dthpayObj.existRecored(temp_detl_select) == 0)
            {
                if (PAYVAL > 0)
                {
                    if (ACCODE.ToString() == "2142")
                    {
                        PAYVAL = PAYVAL + exgramt;
                    }
                    string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                        "VALUES ('" + vouno + "' ,'" + ACCODE.ToString() + "' ,  " + PAYVAL + " ,0 ,0 ,  " + PAYVAL + " )";
                    dthpayObj.insertRecords(temp_detl_insert);
                }else if (exgramt > 0)
                {
                    if (ACCODE.ToString() == "2142")
                    {
                        string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                        "VALUES ('" + vouno + "' ,'" + ACCODE.ToString() + "' ,  " + exgramt + " ,0 ,0 ,  " + exgramt + " )";
                        dthpayObj.insertRecords(temp_detl_insert);
                    }
                    
                }
            }
            else { throw new Exception("Already Existing Record in temp_detl Table"); }
            if (exgramt > 0 && ACCODE.ToString() != "2142")
            {
                string temp_detl_insert = "INSERT INTO CASHBOOK.TEMP_DETL (VOUNO ,ACCODE ,AMOUNT ,VATGEN ,VATLIFE ,TOTAL )" +
                    "VALUES ('" + vouno + "' ,'2142' ,  " + exgramt + " ,0 ,0 ,  " + exgramt + " )";
                dthpayObj.insertRecords(temp_detl_insert);
            }

            #endregion

            #region //------------------ VOUBANKDET --------------

            string voubankdetSelect = "select * from LPHS.VOUBANKDET where POLICYNO =" + polno + " and VOUCHERNO =  '" + vouno + "' ";
            if (dthpayObj.existRecored(voubankdetSelect) == 0)
            {
                string voubankdetnsert = "INSERT INTO LPHS.VOUBANKDET (POLICYNO ,VOUCHERNO ,PAYEENAME ,BNKNAME ,BNKBRNNAME ,SLIACCTNO, CUSTACCTNO ) " +
                    " VALUES (" + polno + " ,'" + vouno + "' ,'" + NAMEPAYEE1 + "' ,'" + BKNAM + "' ,'" + BKBRN + "' ,'" + SLIAcctNo + "', '" + ACNUM + "'  )";
                dthpayObj.insertRecords(voubankdetnsert);
            }
            else { throw new Exception("Already Exising Voucher Bank Details"); }

            #endregion

            #region-------------PaidNo------------------
            gg.PaidNo(polno, "DRPAIDNO", MOS, dthpayObj);
            #endregion

            return vouno;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    private void createVouNoTable(string name, double totamount, string vounum, int rowno)
    {
        TableRow trow01 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel13 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        Label lbl13 = new Label();

        lbl11.ID = "name" + rowno;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "name" + rowno); //Text Value
        lbl11.Text = name;

        lbl12.ID = "totamontvno" + rowno;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "totamontvno" + rowno); //Text Value
        lbl12.Text = String.Format("{0:N}", totamount);

        lbl13.ID = "vounum" + rowno;
        lbl13.Attributes.Add("runat", "Server");
        lbl13.Attributes.Add("Name", "vounum" + rowno); //Text Value
        lbl13.Text = vounum;

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        tcel13.Controls.Add(lbl13);

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow01.Cells.Add(tcel13);

        Table2.Rows.Add(trow01);
    }

    private string adressRefine(string s)
    {
        string returnStr = "";
        string spChar = "";
        if ((s != null) && (!s.Equals("")))
        {
            for (int i = 0; i < s.Length; i++)
            {
                spChar = s.Substring(i, 1);
                if ((!spChar.Equals("'")) && (!spChar.Equals("\"")) && (!spChar.Equals("+")) && (!spChar.Equals("-")) && (!spChar.Equals(";")) && (!spChar.Equals(",")))
                {
                    returnStr += spChar;
                }
                else
                {
                    returnStr += " ";
                }
            }
        }
        return returnStr;
    }

    private double Sliamount(long polino, string svpayee, string svmos, int payeenum, string sysType)
    {
        double sliamt = 0;
        string balancesel = "select sum(SVAMT) from LPHS.SLICVOUCHERS where SVPOL=" + polino + " and SVPAYEE='" + payee + "' and SVMOS='" + svmos + "' and SVPAYNUM=" + payeenum + " and SYSTEM_TYPE = '" + sysType + "'";
        if (dthpayObj.existRecored(balancesel) != 0)
        {
            dthpayObj.readSql(balancesel);
            OracleDataReader balancereader = dthpayObj.oraComm.ExecuteReader();
            while (balancereader.Read())
            {
                if (!balancereader.IsDBNull(0)) { sliamt = balancereader.GetDouble(0); } else { sliamt = 0; }
            }
        }
        return sliamt;
    }

    private void slicvouupdate(string vouno, int paynum, string payee)
    {
        string slicupd = "update LPHS.SLICVOUCHERS set SVPAYVOU='" + vouno + "' where SVPOL=" + polno + " and SVPAYEE='" + payee + "' and SVPAYNUM=" + paynum + "";
        dthpayObj.insertRecords(slicupd);
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }

    public string mOS
    {
        get { return MOS; }
        set { MOS = value; }
    }

    public string Payee
    {
        get { return payee; }
        set { payee = value; }
    }

    public long Clmno
    {
        get { return clmno; }
        set { clmno = value; }
    }


    protected void btnnext_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/voucher/vouPrint001.aspx", true);
    }
}
