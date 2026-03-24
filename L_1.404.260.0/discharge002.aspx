<%@ Page Language="C#" AutoEventWireup="true" CodeFile="discharge002.aspx.cs" Inherits="discharge002" %>

<%@ PreviousPageType VirtualPath="~/dthPay002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="Style/Stylefont.css" /> 
    <style type="text/css">
     P.breakhere {page-break-before: always}
     @font-face {
            font-family: "Sandaya";
            src: url("fonts/SANDHYA.woff2") format("woff2"),
                 url("fonts/SANDHYA.woff") format("woff"),
                 url("fonts/SANDHYA.ttf") format("truetype"),
                 url("fonts/SANDHYA.eot") format("embedded-opentype"),
                 url("fonts/SANDHYA.svg#Sandaya") format("svg");
            font-weight: normal;
            font-style: normal;
    }
</style>
    <title>SriLanka Insurance - Death Claims</title>

    <script src="JavaScript/FormValidation.js" type="text/javascript" language="javascript"></script>

    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric(arguments.Value))
            {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
 
    </script>

   
</head>
<body style="text-align: center" onload="window.print()">
    <form id="form1" runat="server">
        <%
            try
            {
                string payeeName = "";
                string relationship = "";
                string reltype = "";
                double payeeAmt = 0;
                double percentage = 0;
                string affiNomiAssiLPTdat = "";
                int pno = 0;
                foreach (string[] payeedetArr in arrList)
                {
                    pno = 1;
                    //litno.Text = pno.ToString();
                    payeeName = payeedetArr[0];
                    relationship = payeedetArr[1];
                    if (relationship == "ML")
                    {
                        this.Litrel.Text = "m%Odk rCIs;hd";
                    }
                    else if (relationship == "SL")
                    {
                        this.Litrel.Text = "fojk rCIs;hd";
                    }
                    else if (relationship == "Nominee")
                    {
                        this.Litrel.Text = "kduSlhd";
                    }
                    reltype = payeedetArr[2];
                    payeeAmt = double.Parse(payeedetArr[3]);
                    percentage = double.Parse(payeedetArr[4]);
                    affiNomiAssiLPTdat = payeedetArr[5];

                    this.LitpayeeName.Text = payeeName;
                    if (relationship == "Son")
                    { this.Litrel.Text = "mq; d"; }
                    if (relationship == "Daughter")
                    { this.Litrel.Text = "oshKsh"; }
                    if (relationship == "Spouce")
                    { this.Litrel.Text = "iylre$ldrsh"; }
                    if (relationship == "Brother")
                    { this.Litrel.Text = "ifydaorhd"; }
                    if (relationship == "Sister")
                    { this.Litrel.Text = "ifydaorsh"; }
                    if (relationship == "Mother")
                    { this.Litrel.Text = "uj"; }
                    if (relationship == "Father")
                    { this.Litrel.Text = "mshd"; }

                    this.LitPayeeType.Text = reltype;

                    if (polstat.Trim() == "I")
                    {
                        if (TBL == 28 || TBL == 46)
                        {
                            litsumdes.Text = "oAjs;aj rlaIs; uqo,";
                        }
                        else if (TBL == 29)
                        {
                            if (MOF == "M")
                            {
                                litsumdes.Text = "jevsjQ rlaIs; uqof,a fo.+Kh";
                            }
                            else
                            {
                                litsumdes.Text = "rlaIs; uqo,";
                            }
                        }
                        else
                        {
                            litsumdes.Text = "rlaIs; uqo,";
                        }
                    }
                    else
                    {
                        if (TBL == 29)
                        {
                            if (MOF == "M")
                            {
                                litsumdes.Text = "jevsjQ rlaIs; uqo,g  f.jd kSuS w.h";
                            }
                            else
                            {
                                litsumdes.Text = "rlaIs; uqo,";
                            }
                        }
                        else
                        {
                            litsumdes.Text = "wvq rlaIs; uqo,g f.jd kSuS w.h";
                        }
                    }

                    this.lblpcntage.Text = String.Format("{0:N}", (double)(percentage * 100)) + "%";
                    // this.litshareamt.Text = String.Format("{0:N}", (double)payeeAmt);
                    this.litshareamt.Text = (Math.Truncate(Math.Round(payeeAmt * 100, 4)) / 100).ToString("N2");
                    double netclm100 = 0;
                    if (netclm < 0) { netclm100 = 0; }
                    else { netclm100 = (Math.Round(grossClm, 2) * 100); }
                    if (netclm100 != 0)
                    {
                        string netclminwords = netclm100.ToString().Substring(0, (netclm100.ToString().Length - 2)) + "." + netclm100.ToString().Substring((netclm100.ToString().Length - 2), 2);
                        readAmountFunction readamt = new readAmountFunction();
                        //this.LitSumInWords.Text = readamt.readAmountSinhala(netclminwords, "YS% ,xld remsh,a", "Y; ");
                        LitSumInWords.Text = readamt.readAmount(netclminwords, "SRI LANKAN RUPEES", "CENTS ");
                    }
                    else
                    {
                        this.LitSumInWords.Text = "ZERO SRI LANKAN RUPEES AND ZERO CENTS ONLY";
                    }
                    //==============================================================
                    string Fulname = "";
                    string status = "";
                    DataManager dthintobj = new DataManager();


                    string polpersonalSel = "";
                    polpersonalSel = "select fullname,STATUS,SURNAME from LUND.POLPERSONAL where polno = " + polno + " and PRPERTYPE = 1 ";
                    if (dthintobj.existRecored(polpersonalSel) != 0)
                    {
                        dthintobj.readSql(polpersonalSel);
                        System.Data.OracleClient.OracleDataReader polperReader = dthintobj.oraComm.ExecuteReader();
                        polperReader.Read();
                        {
                            if (!polperReader.IsDBNull(0)) { Fulname = polperReader.GetString(0).ToUpper().Trim(); } else { Fulname = ""; }
                            if (!polperReader.IsDBNull(1)) { status = polperReader.GetString(1).Trim(); } else { status = ""; }
                            if (Fulname.Contains("&"))
                            {
                                string namejoin = "";
                                string concatname = "";
                                string[] mnlifenm = Fulname.Split('.');
                                status = mnlifenm[0].ToString() + "." + mnlifenm[1].ToString() + ".";
                                for (int a = 2; a < mnlifenm.Length; a++)
                                {
                                    if (mnlifenm[a].ToString().Trim().Length == 1)
                                    {
                                        namejoin = mnlifenm[a].ToString().Trim() + ".";
                                    }
                                    else
                                    {
                                        namejoin = mnlifenm[a].ToString() + " ";
                                    }
                                    concatname = concatname + namejoin;
                                }
                                Fulname = concatname;
                            }

                            else if ((Fulname.Contains("MR.")) || (Fulname.Contains("MRS.")) || (Fulname.Contains("MISS.")) || (Fulname.Contains("DR.")) || (Fulname.Contains("REV.")) || (Fulname.Contains("PROF.")) || (Fulname.Contains("MS.")) || (Fulname.Contains("MASTER.")) || (Fulname.Contains("DR.")) || (Fulname.Contains("DR.(MRS)")) || (Fulname.Contains("DR.(MISS)")))
                            {
                                string namejoin_ = "";
                                string concatname_ = "";

                                string[] mnlifenm = Fulname.Split('.');
                                status = mnlifenm[0].ToString() + ".";
                                for (int a = 1; a < mnlifenm.Length; a++)
                                {
                                    if (mnlifenm[a].ToString().Trim().Length == 1)
                                    {
                                        namejoin_ = mnlifenm[a].ToString().Trim() + ".";
                                    }
                                    else
                                    {
                                        namejoin_ = mnlifenm[a].ToString() + " ";
                                    }
                                    concatname_ = concatname_ + namejoin_;
                                }
                                Fulname = concatname_;
                            }
                            if (status == "")
                            {
                                status = statusmn;
                            }
                        }
                        polperReader.Close();
                    }
                    if (Fulname == "")
                    {
                        status = "";
                        Fulname = phname;
                    }

                    //=============================================================== 


                    if (TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49)
                    {
                        //===============================================================
                        DataManager dm = new DataManager();
                        int cvrno = 0;
                        string ChildFname = "";
                        string ChildStts = "";
                        string SelectAllcvrs = "select PRPERTYPE,FULLNAME,STATUS from lund.polpersonal where POLNO=" + polno + "";
                        if (dm.existRecored(SelectAllcvrs) != 0)
                        {
                            dm.readSql(SelectAllcvrs);
                            System.Data.OracleClient.OracleDataReader rdchldcvr = dm.oraComm.ExecuteReader();
                            while (rdchldcvr.Read())
                            {
                                if (!rdchldcvr.IsDBNull(0)) { cvrno = rdchldcvr.GetInt32(0); } else { cvrno = 0; }
                                if (cvrno != 1 && cvrno != 2 && cvrno != 3)
                                {
                                    if (!rdchldcvr.IsDBNull(1)) { ChildFname = rdchldcvr.GetString(1).ToUpper().Trim(); } else { ChildFname = ""; }
                                    if (!rdchldcvr.IsDBNull(2)) { ChildStts = rdchldcvr.GetString(2).ToUpper().Trim(); } else { ChildStts = ""; }
                                    if ((ChildFname.Contains("MR.")) || (ChildFname.Contains("MRS.")) || (ChildFname.Contains("MISS.")) || (ChildFname.Contains("DR.")) || (ChildFname.Contains("REV.")) || (ChildFname.Contains("PROF.")) || (ChildFname.Contains("MS.")) || (ChildFname.Contains("MASTER.")) || (ChildFname.Contains("DR.")) || (ChildFname.Contains("DR.(MRS)")) || (ChildFname.Contains("DR.(MISS)")))
                                    {
                                        string[] chldnm = ChildFname.Split('.');
                                        ChildStts = chldnm[0].ToString() + ".";
                                        ChildFname = chldnm[1].ToString();
                                    }
                                }
                            }
                            rdchldcvr.Close();
                            this.litLifeassured.Text = status + Fulname + " & " + ChildStts + ChildFname;
                            dm.connClose();
                        }
                        else
                        {
                            this.litLifeassured.Text = status + Fulname;// +" & " + Fullname; ;
                        }
                    }
                    else
                    {
                        #region Check Whether Spouse Cover Found for the Given Policy
                        DataManager dm = new DataManager();
                        string Fullname = "";
                        string SpsStatus = "";
                        //string Selectcvr = "select FULLNAME,STATUS from lund.polpersonal where PRPERTYPE=2 and POLNO=" + polno + "";
                        string Selectcvr = "select FULLNAME,STATUS from lund.polpersonal where PRPERTYPE=2 and POLNO=" + polno + " union select FULLNAME,STATUS from LUND.POLPERSONAL_HISTORY where PRPERTYPE=2 and POLNO=" + polno + "";
                        //string ChkCvr_SP = "select RCOVR from lund.rcover where RPOL=" + polno + " and RCOVR=101";
                        string ChkCvr_SP = "select RCOVR from lund.rcover where RPOL=" + polno + " and RCOVR=101 union select RCOVR from LUND.RCOVER_HISTORY where RPOL=" + polno + " and RCOVR=101 and entry_date>to_date(" + dateofdeath + ",'yyyy/MM/dd')";
                        if (dm.existRecored(ChkCvr_SP) != 0)
                        {
                            if (dm.existRecored(Selectcvr) != 0)
                            {
                                dm.readSql(Selectcvr);
                                System.Data.OracleClient.OracleDataReader reder1 = dm.oraComm.ExecuteReader();
                                while (reder1.Read())
                                {
                                    if (!reder1.IsDBNull(0)) { Fullname = reder1.GetString(0).ToUpper().Trim(); } else { Fullname = ""; }
                                    if (!reder1.IsDBNull(1)) { SpsStatus = reder1.GetString(1).Trim(); } else { SpsStatus = ""; }
                                    if ((Fullname.Contains("MR.")) || (Fullname.Contains("MRS.")) || (Fullname.Contains("MISS.")) || (Fullname.Contains("DR.")) || (Fullname.Contains("REV.")) || (Fullname.Contains("PROF.")) || (Fullname.Contains("MS.")) || (Fullname.Contains("MASTER.")) || (Fullname.Contains("DR.")) || (Fullname.Contains("DR.(MRS)")) || (Fullname.Contains("DR.(MISS)")))
                                    {
                                        string[] mnlifenm = Fullname.Split('.');
                                        SpsStatus = mnlifenm[0].ToString() + ".";
                                        Fullname = mnlifenm[1].ToString();
                                    }

                                }
                                reder1.Close();
                                this.litLifeassured.Text = status + Fulname + " & " + SpsStatus + Fullname;
                                dm.connClose();
                            }
                        }
                        #endregion
                        else
                        {
                            this.litLifeassured.Text = status + Fulname;// +" & " + Fullname; ;
                        }
                    }

                    double ageUnderStAmt = 0;
                    double ageOverStAmt = 0;

                    if (ageStatus.Equals("O")) { ageOverStAmt = ageDiffAmt; }
                    else if (ageStatus.Equals("Y")) { ageUnderStAmt = ageDiffAmt; }

                    double AgediffIntest = 0.0;
                    string GetagediffInt = "select AGEDIFINRST from lphs.dthref where drpolno=" + polno + "";
                    dthintobj.readSql(GetagediffInt);
                    System.Data.OracleClient.OracleDataReader readint = dthintobj.oraComm.ExecuteReader();
                    while (readint.Read())
                    {
                        if (!readint.IsDBNull(0)) { AgediffIntest = readint.GetDouble(0); } else { AgediffIntest = 0.0; }
                    }
                    readint.Close();
                    if (AgediffIntest != 0.0 || ageUnderStAmt != 0.0)
                    {
                        double TotalAgeAmount = AgediffIntest + ageUnderStAmt;
                    }

                    this.litpolno.Text = polno.ToString();
                    this.lblpolno4.Text = polno.ToString();
                    this.LitDateOfDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                    this.LitIDCo.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                    this.litclmno.Text = claimno.ToString();
                    if (interimBonus != 0.00)
                    {
                    }

                    if (interimBonus != 0.00)
                    {
                        litrs3.Visible = true;
                        litbondes1.Visible = true;
                        litintdes2.Visible = true;
                        litintdes3.Visible = true;
                        Txtintbend.Visible = true;
                        int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                        int nxtbonyr = interimBonStYr;
                        int yeardiff = this.dateComparison(lstbondecyr, dateofdeath)[0];
                        for (int i = 0; i < yeardiff; i++)
                        {
                            nxtbonyr = nxtbonyr + 1;
                        }
                        this.Txtinbst.Text = interimBonStYr.ToString();
                        if (nxtbonyr != interimBonStYr)
                        {
                            //this.litintbend.Text = nxtbonyr.ToString();
                            Txtintbend.Text = nxtbonyr.ToString();
                        }
                        Txtinbst.Visible = true; litintbon.Visible = true;
                        string Getintbonyr = "select INTBONSTYR from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and DRCLMNO=" + claimno + "";
                        int interimbonusstyear = 0;
                        DataManager dm = new DataManager();

                        if (dm.existRecored(Getintbonyr) != 0)
                        {
                            dm.readSql(Getintbonyr);
                            System.Data.OracleClient.OracleDataReader dr = dm.oraComm.ExecuteReader();
                            while (dr.Read())
                            {
                                if (!dr.IsDBNull(0)) { interimbonusstyear = dr.GetInt32(0); }
                            }
                            dr.Close();
                        }
                        if (interimbonusstyear == 0 && interimBonus != 0.00)
                        {
                            string Updateintbonst = "update LPHS.DTHREF set INTBONSTYR=" + interimBonStYr + " where DRPOLNO=" + polno + " and DRMOS='" + MOF + "' and INTBONSTYR=0";
                            dm.insertRecords(Updateintbonst);
                        }
                        dm.connClose();
                    }
                    //this.litintbend.Text = polcompleYM.Substring(0, 4);

                    this.LitbonSt.Text = "m%ido uqo,";
                    LitbonSt.Visible = true;
                    if (vestedBonus != 0.00)
                    {
                        TxtbonSt.Visible = true;
                        litsita.Visible = true;
                        Txtbonend.Visible = true;
                        litbonend.Visible = true;
                    }
                    litvestbon.Visible = true;

                    if (vestedBonus != 0.00)
                    {
                        if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49)
                        {
                            this.LitbonSt.Text = "m%ido uqo,";
                            TxtbonSt.Text = COM.ToString().Substring(0, 4);
                            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }
                            this.Txtbonend.Text = interimBonStYr.ToString();
                            //  this.litlinbst.Text = interimBonStYr.ToString();
                            Txtinbst.Text = interimBonStYr.ToString();
                            int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                            lit2.Visible = true;
                            TxtbonSt.Visible = true;
                            litvestbon.Visible = true;
                            LitbonSt.Visible = true;
                            Txtbonend.Visible = true;
                            litsita.Visible = true;
                            litbonend.Visible = true; litrs3.Visible = true;
                        }
                        else if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL != 49) && (polstat.Trim() == "I"))
                        {
                            this.LitbonSt.Text = "";
                            TxtbonSt.Text = "";
                            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }
                            this.Txtbonend.Text = "";
                            //  this.litlinbst.Text = interimBonStYr.ToString();
                            Txtinbst.Text = "";
                            int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                            lit2.Visible = false;
                            TxtbonSt.Visible = false;
                            litvestbon.Visible = false;
                            LitbonSt.Visible = false;
                            Txtbonend.Visible = false;
                            litsita.Visible = false;
                            litbonend.Visible = false; litrs3.Visible = false;
                        }
                        else if ((TBL == 38) && (polstat.Trim() == "L"))
                        {
                            this.LitbonSt.Text = "";
                            TxtbonSt.Text = "";
                            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }
                            this.Txtbonend.Text = "";
                            //  this.litlinbst.Text = interimBonStYr.ToString();
                            Txtinbst.Text = "";
                            int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                            lit2.Visible = false;
                            TxtbonSt.Visible = false;
                            litvestbon.Visible = false;
                            LitbonSt.Visible = false;
                            Txtbonend.Visible = false;
                            litsita.Visible = false;
                            litbonend.Visible = false;
                            litrs3.Visible = false;
                        }
                    }

                    this.litageovest.Text = String.Format("{0:N}", ageOverStAmt);
                    this.litunderstated.Text = String.Format("{0:N}", (ageUnderStAmt + AgediffIntest));
                    this.txtComYr.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2);

                    if (polcompleYM != null)
                    {
                        this.txtendYr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2);
                    }
                    //double x = PRM * missingprems;
                    double x = amtComyr;
                    this.Litinstlments.Text = String.Format("{0:N}", x+deductAmount);
                    this.LitDeceasedName.Text = nameOfDead;
                    //this.litLifeassured.Text = phname;
                    this.litLifeAssured2.Text = nameOfDead;

                    if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.litvestbon.Text = String.Format("{0:N}", vestedBonus); this.litintbon.Text = String.Format("{0:N}", interimBonus); }
                    else
                    {
                        if (MOF == "2")
                        {
                            this.litvestbon.Text = String.Format("{0:N}", vestedBonus);
                            this.litintbon.Text = String.Format("{0:N}", interimBonus);
                            this.litLifeAssured2.Text = nameOfDead;
                            this.Txtbonend.Text = interimBonStYr.ToString();
                            this.Txtinbst.Text = interimBonStYr.ToString();
                            this.LitbonSt.Text = "m%ido uqo,";
                            LitbonSt.Visible = true;
                            TxtbonSt.Text = COM.ToString().Substring(0, 4);
                            TxtbonSt.Visible = true;
                            litsita.Visible = true;
                            litsita.Text = "isg";
                            Txtbonend.Visible = true;
                            litbonend.Visible = true;
                            litvestbon.Visible = true;
                            this.Txtinbst.Visible = true;

                        }
                        else if ((MOF == "M") && (recipient == "SL") && (polstat == "L"))//
                        {
                            //this.litvestbon.Text = String.Format("{0:N}", vestedBonus);
                            //this.litintbon.Text = String.Format("{0:N}", interimBonus);
                            this.litvestbon.Text = String.Format("{0:N}", 0);
                            this.litintbon.Text = String.Format("{0:N}", 0);
                        }
                        else
                        {
                            this.litvestbon.Text = "0.00"; this.litintbon.Text = "0.00";
                        }
                    }
                    if (TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49)
                    {
                        if ((MOF == "M" || MOF == "S") && (recipient == "SL"))
                        {
                            LitPayeeType.Text = "Proposal";
                        }
                        //if (TBL == 46 && MOF == "2" && recipient == "ML")
                        //{
                        //    LitPayeeType.Text = "Proposal"; 
                        //}
                        if ((MOF == "2" || MOF == "C") && recipient == "ML")
                        {
                            LitPayeeType.Text = "Proposal";
                        }
                    }
                    if (MOF == "S")
                    {
                        LitPayeeType.Text = "Proposal";
                    }
                    if (TBL == 14)
                    {
                        LitPayeeType.Text = "Proposal";
                    }
                    DataManager defObj = new DataManager();

                    if (LitPayeeType.Text.ToUpper() == "PROPOSAL")
                    {
                        string getpropdt = "select PRDATE from lund.promast where POLNO=" + polno + "";
                        if (defObj.existRecored(getpropdt) != 0)
                        {
                            System.Data.OracleClient.OracleDataReader drprodt = defObj.oraComm.ExecuteReader();
                            while (drprodt.Read())
                            {
                                if (!drprodt.IsDBNull(0)) { TxtDated.Text = drprodt.GetInt32(0).ToString().Substring(0, 4) + "/" + drprodt.GetInt32(0).ToString().Substring(4, 2) + "/" + drprodt.GetInt32(0).ToString().Substring(6, 2); }
                            }
                            drprodt.Close();
                        }
                    }
                    //if (ADB > 0) { this.lbladbStr.Visible = true; }
                    //if (FPU > 0) { this.lblfpustr.Visible = true; }
                    //if (FE > 0) { this.lblfestr.Visible = true; }
                    //if (SJ > 0) { this.lblsjstr.Visible = true; }
                    double riderbene = ADB;
                    //+ FE + SJ;
                    if (FPU > 0)
                    { this.litFPU.Text = String.Format("{0:N}", FPU); }
                    else { this.litFPU.Text = "0.00"; }
                    if (riderbene > 0) { this.LitAccBene.Text = String.Format("{0:N}", (double)riderbene); }
                    else { this.LitAccBene.Text = "0.00"; }
                    if (SJ > 0) { this.litsjamt.Text = String.Format("{0:N}", (double)SJ); }
                    else { this.litsjamt.Text = "0.00"; }
                    if (FE > 0) { this.litfeamt.Text = String.Format("{0:N}", (double)FE); }
                    else { this.litfeamt.Text = "0.00"; }

                    this.litLoanAmt.Text = String.Format("{0:N}", loancap);
                    this.litLoanInt.Text = String.Format("{0:N}", loanint);
                    if (demmands != 0.00)
                    {
                        this.LitDefPrem.Text = String.Format("{0:N}", demmands);
                        litdefprmsdes.Visible = true;
                        litrs_1.Visible = true;
                        LitDefPrem.Visible = true;
                        Table1.Visible = true;
                    }
                    else
                    {
                        litdefprmsdes.Visible = false;
                        litrs_1.Visible = false;
                        LitDefPrem.Visible = false;
                        Table1.Visible = false;
                    }
                    this.LitDefLatefee.Text = String.Format("{0:N}", defint);
                    this.litnet.Text = String.Format("{0:N}", netclm);
                    this.litSumInFigures.Text = String.Format("{0:N}", grossClm);
                    this.LitotherAdd.Text = String.Format("{0:N}", otheradd);
                    this.LitDeposit.Text = String.Format("{0:N}", deposit);//...Add on 2009/05/05 by buddhika...
                    this.LittotAdd.Text = String.Format("{0:N}", grossClm);
                    this.litStagePayment.Text = String.Format("{0:N}", stagepayment);
                    this.lblStageYearStr.InnerText = stagePaymentString;
                    if(polstat == "L")
                    {
                         this.LitOtherDed.Text = String.Format("{0:N}", otherdeuct - stagepaydeduction);
                         this.litStageDeduction.Text = String.Format("{0:N}",stagepaydeduction);
                    }
                    else
                    {
                         this.LitOtherDed.Text = String.Format("{0:N}", otherdeuct);
                         this.litStageDeduction.Text = String.Format("{0:N}",stagepaydeduction);
                    }
                    //this.litstamp.Text = string.Format("{0:N}", stampduty);
                    double lesstotal = demmands + defint + x + loancap + loanint + otherdeuct + (ageUnderStAmt + AgediffIntest)  + deductAmount;
                    this.litLessTot.Text = String.Format("{0:N}", lesstotal);
                    this.lblToday.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.litbalance.Text = String.Format("{0:N}", netclm);
                    this.LitSumassed.Text = String.Format("{0:N}", sumassured);
                    this.Litprm.Text = prmRefund.ToString("N2");
                    this.litpolno.Text = polno.ToString();
                    this.lblcurdate5.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lbltime5.Text = this.setDate()[1];
                    this.lblipaddr5.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    this.lblclmno2.Text = claimno.ToString();
                    //this.lblepf6.Text = epf;
                    if (int.Parse(affiNomiAssiLPTdat) > 9999999)
                    {
                        this.TxtDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                        // this.litDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                    }

                    string ChkDefPrms = "select PDDUE from LPHS.DEMAND  WHERE  ( PDCOD = 'D'  AND  PDPOL =" + polno + " )";
                    if (defObj.existRecored(ChkDefPrms) != 0)
                    {
                        Table1.Rows.Clear();
                        ArrayList DueyrmnArr = new ArrayList();
                        int Dueyrmn = 0;
                        defObj.readSql(ChkDefPrms);
                        System.Data.OracleClient.OracleDataReader drdef = defObj.oraComm.ExecuteReader();
                        while (drdef.Read())
                        {
                            if (!drdef.IsDBNull(0)) { Dueyrmn = drdef.GetInt32(0); } else { Dueyrmn = 0; }
                            if (Dueyrmn != 0)
                            {
                                DueyrmnArr.Add(Dueyrmn);
                            }
                        }
                        this.CreateDefPrmTble(DueyrmnArr);
                        drdef.Close();
                    }
                    defObj.connClose();

        %>
        <div style="page-break-after: always">
            <table style="width: 651px">
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 8px; font-size: 10pt; text-align: right;">
                        <span style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'">ysusluz wxlh(cS$ysusluz$1 $<span style="font-size: 10pt;
                                font-family: Trebuchet MS"><asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 7px; font-size: 10pt;">
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 7px; width: 105px;">
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 7px">
                    </td>
                    <td colspan="2" style="height: 7px; font-size: 10pt;">
                        <em><span style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'"><%--w.;s rys;hs--%></span><span style="font-size: 11pt;
                                font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA"> </span></em>
                    </td>
                </tr>
                <tr style="font-weight: bold; font-size: 16pt">
                    <td colspan="6" style="height: 8px; font-size: 10pt;">
                        <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                            <b style="mso-bidi-font-weight: normal"><span style="font-family: Sandaya"><span
                                style="font-size: 12pt">YS% ,xld<span style="mso-spacerun: yes"> </span>bkaIQjrkaia fldamfrAIka ,hs*a ,susgvz<?xml
                                    namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></b></p>
                    </td>
                </tr>
                <tr style="font-weight: bold; font-size: 16pt">
                    <td colspan="6" style="height: 9px; font-size: 10pt;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            <span style="font-size: 11pt; text-decoration: underline"></span><span style="font-size: 11pt">
                                <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; text-decoration: underline">
                                        <span style="font-family: Sandaya">wxl</span><asp:Literal ID="litpolno" runat="server"></asp:Literal>
                                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                            <span style="font-size: 11pt"><span style="text-decoration: underline">orK Tmamqj f.jd
                                                ksu lsrSu</span> </span></span></span></span></span></span></td>
                </tr>
                <tr style="font-size: 12pt; text-decoration: underline">
                    <td colspan="6" style="height: 9px; font-size: 10pt;">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            <span style="font-size: 11pt; font-family: Trebuchet MS;"></span><span style="font-size: 11pt">
                                <span style="font-family: Trebuchet MS">
                                    <asp:Literal ID="litLifeassured" runat="server"></asp:Literal>&nbsp; <span style="font-family: Sandaya">
                                        f.a</span></span></span></span><span style="mso-fareast-font-family: 'Times New Roman';
                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                            mso-bidi-font-family: 'Times New Roman'"><span><span style="font-size: 11pt"><span
                                                style="font-family: Trebuchet MS"><span style="font-family: Sandaya"> cSjs;h </span>
                                                <u><span style="font-family: Sandaya">ms&lt;sn|j</span><asp:Literal ID="LitIDCo"
                                                    runat="server"></asp:Literal>&nbsp; &nbsp;<span style="font-family: Sandaya"> <span
                                                        style="font-size: 11pt">osk orK Tmamqjhs</span></span> &nbsp;&nbsp; </u>
                                            </span></span></span></span>
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="6" style="height: 35px; font-size: 10pt; text-align: justify;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            by; ku i|yka <span style="font-family: Trebuchet MS">
                                <asp:Literal ID="LitDeceasedName" runat="server"></asp:Literal></span>&nbsp;
                            <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman';
                                font-weight: normal; font-size: 10pt;"><span style="font-family: Sandaya">uy;d$ush f.a</span>
                                <asp:Literal ID="Litrel" runat="server"></asp:Literal>
                                &nbsp;<span style="font-family: Sandaya">^ush.sh whg we;s kEluz fyda whs;sjdisluz i|yka
                                    lrkak</span><span style="font-family: Times New Roman">.</span><span style="font-family: 'Trebuchet MS';
                                        font-size: 10pt;"><span style="font-family: Sandaya">&amp; &nbsp; jk uu$wm</span>&nbsp;<asp:Literal
                                            ID="LitpayeeName" runat="server"></asp:Literal>
                                        &nbsp; &nbsp;<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                            mso-bidi-font-family: 'Times New Roman'">fj;&nbsp; ^iuzmQrAK ku i|yka lrkak<span
                                                style="font-family: Sandaya">&amp;<span style="font-size: 10pt; font-family: Trebuchet MS">
                                                    <asp:TextBox ID="TxtDated" runat="server" Height="13px" MaxLength="10" Visible="true"
                                                        Width="81px"></asp:TextBox>
                                                    <span style="font-family: 'Trebuchet MS'; font-size: 10pt;"><span style="font-family: Sandaya">
                                                        od;u hgf;a m%odkh lrk ,o</span> &nbsp;<span style="font-family: Trebuchet MS">
                                                            <asp:Literal ID="LitPayeeType" runat="server"></asp:Literal>
                                                            &nbsp; &nbsp;<span style="font-family: Sandaya">m%ldr mQrAfjdala;<span style="font-size: 11pt">&nbsp;
                                                                <span style="font-size: 10pt">Tmamqfjz ku i|ykaj <span style="font-family: 'Trebuchet MS';
                                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                    mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'; font-size: 10pt;">
                                                                    <span style="font-family: Sandaya">we;a;djqo&nbsp; </span>
                                                                    <asp:Literal ID="LitDateOfDeath" runat="server"></asp:Literal>&nbsp; <span style="font-family: 'Trebuchet MS';
                                                                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                        mso-bidi-language: AR-SA; mso-bidi-font-family: 'Sandya'; font-size: 10pt;"><span
                                                                            style="font-family: Sandaya">jeks osk ush.<u>s</u>hdjqo</span>&nbsp;
                                                                        <asp:Literal ID="litLifeAssured2" runat="server"></asp:Literal>
                                                                        <span style="font-size: 11pt; font-family: Sandaya;">f.a <span style="font-size: 10pt">
                                                                            cSjs;h ms&lt;sn| rC<b style="mso-bidi-font-weight: normal">I</b>K Tmamqj hgf;a<span
                                                                                style="mso-spacerun: yes">&nbsp;</span>ud$wm<span style="mso-spacerun: yes"> &nbsp;</span>i;=jk
                                                                            ishtZu ysusluzyd whs;sjdisluz<span style="font-size: 11pt"> <span><span style="font-size: 10pt">
                                                                                mrsmQrAK jk</span><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                    mso-bidi-font-family: 'Times New Roman'"><span style="font-size: 10pt">mrsoafoka m%ido
                                                                                        uqo, o<span style="mso-spacerun: yes"> </span>we;=<b style="mso-bidi-font-weight: normal">Ω</b>j&nbsp;<span
                                                                                            style="font-family: Trebuchet MS"><asp:Literal ID="LitSumInWords" runat="server"></asp:Literal></span>
                                                                                    </span><span style="font-size: 10pt; font-family: Trebuchet MS"><span style="font-size: 10pt">
                                                                                        ( <span style="font-family: Sandaya">re( <span style="font-family: Trebuchet MS">
                                                                                            <asp:Literal ID="litSumInFigures" runat="server"></asp:Literal>&nbsp;</span> </span>
                                                                                        ) &nbsp;<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                            mso-bidi-font-family: 'Times New Roman'">la <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                mso-bidi-font-family: 'Times New Roman'; line-height: 15pt;">jq uqo,la by; i|yka
                                                                                                ixia:dfjka ,nd .ekSug tlÛ jk nj fuhska m%ldY lrus<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                    mso-bidi-font-family: 'Times New Roman'">$lruq</span><span style="font-size: 11pt;
                                                                                                        font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                                                                        mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="font-size: 10pt">.</span><span
                                                                                                            style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                            mso-bidi-font-family: 'Times New Roman'"><span style="font-size: 10pt">;jo tu Tmamqj</span>&nbsp;
                                                                                                            <span style="font-size: 10pt">wj,x.= lsrSu i|yd by; i|yka rC<b style="mso-bidi-font-weight: normal">I</b>K
                                                                                                                iud.ug fuhska Ndr fous<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                                    mso-bidi-font-family: 'Times New Roman'">$fouq</span><span style="font-family: 'Times New Roman';
                                                                                                                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                                                                        mso-bidi-language: AR-SA; line-height: 15pt;">.</span></span></span></span></span></span></span></span></span></span></span><span
                                                                                                                            style="mso-spacerun: yes"></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify; font-family: Sandaya;">
                        <asp:Literal ID="litsumdes" runat="server" Text="rlaIs; uqo,$wvq rlaIs; uqo,"></asp:Literal>
                        <asp:Label ID="lblsumonexgr" runat="server" Font-Names="Sandaya" Font-Size="10pt"
                            Visible="False" Width="97px"> ohdkAjs; f.jSuS</asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span>
                        <asp:Literal ID="LitSumassed" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">
                            <asp:Literal ID="LtADBText" runat="server" Text="yosis wk;=re m%;ss,dN"></asp:Literal></span><asp:Label
                                ID="lbladbonexgr" runat="server" Font-Names="Sandaya" Font-Size="10pt" Visible="False"> ohdkAjs; f.jSuS</asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">
                            <asp:Literal ID="LtADB" runat="server" Text="re("></asp:Literal></span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span>
                        <asp:Literal ID="LitAccBene" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">mjq,a wdrla<b style="mso-bidi-font-weight: normal">I</b>K
                            tall</span></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span>
                        <asp:Literal ID="litFPU" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; font-family: Sandaya; height: 9px; text-align: justify">
                        <asp:Literal ID="litsj" runat="server" Text="iajrAK chka;s"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; font-family: Sandaya; height: 9px;
                        text-align: right">
                        <asp:Literal ID="lit1" runat="server" Text="re("></asp:Literal></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litsjamt" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; font-family: Sandaya; height: 9px; text-align: justify">
                        wjux.,H jshouz</td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right;
                        font-family: Sandaya;">
                        <asp:Literal ID="lit2" runat="server" Text="re(" Visible="False"></asp:Literal></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litfeamt" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span><span style="font-family: Sandaya">
                            <asp:Literal ID="LitbonSt" runat="server" Visible="False"></asp:Literal>
                        </span>
                        <!--<asp:TextBox ID="TxtbonSt" runat="server" Height="13px" MaxLength="4" Visible="False"
                            Width="41px"></asp:TextBox>&nbsp;<span style="font-family: Sandaya">
                                <asp:Literal ID="litsita" runat="server" Text="isg" Visible="False"></asp:Literal></span><span
                                    style="font-size: 10pt; font-family: 'Trebuchet MS'">&nbsp;<asp:TextBox ID="Txtbonend"
                                        runat="server" Height="13px" MaxLength="4" Visible="False" Width="41px"></asp:TextBox>
                                    <span style="font-size: 10pt"><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                        mso-bidi-font-family: 'Sandya'">
                                        <asp:Literal ID="litbonend" runat="server" Text="olajd" Visible="False"></asp:Literal></span></span></span>--></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litvestbon" runat="server"></asp:Literal></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">
                            <asp:Literal ID="litbondes1" runat="server" Text="w;=re m%ido uqo," Visible="False"></asp:Literal>
                        </span><span style="font-size: 10pt; font-family: Trebuchet MS">
                            <!--<asp:TextBox ID="Txtinbst" runat="server" Height="13px" MaxLength="4" Visible="False"
                                Width="41px"></asp:TextBox>&nbsp; <span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                                    <span style="font-family: Sandaya">
                                        <asp:Literal ID="litintdes2" runat="server" Text="isg" Visible="False"></asp:Literal></span>
                                    <asp:TextBox ID="Txtintbend" runat="server" Height="13px" MaxLength="4" Visible="False"
                                        Width="41px"></asp:TextBox>
                                    <span style="font-family: Sandaya">
                                        <asp:Literal ID="litintdes3" runat="server" Text="olajd" Visible="False"></asp:Literal></span>--></span></span></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">
                            <asp:Literal ID="litrs3" runat="server" Text="re(" Visible="False"></asp:Literal></span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litintbon" runat="server" Visible="False"></asp:Literal></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">jhi jevsfhka m%ldY lr ;snSu ksi d <span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'">jdrslfha jq fjki</span></span></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span>
                        <asp:Literal ID="litageovest" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">fjk;a tl;= lsrSu</span></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span><span style="font-size: 11pt"></span>
                        <asp:Literal ID="LitotherAdd" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">jdrsl wdmiq f.jSuz<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="Litprm" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                <span style="font-family: Sandaya">;ekam;a wdmiq f.jSuz<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><o:p></o:p></span></p>
                        </span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="LitDeposit" runat="server"></asp:Literal></td>
                </tr>
                
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                    <span style="font-family: Sandaya">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                <span style="font-family:Sandaya; font-size:10pt;">;s%jsO wjia:d ysuslu<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><o:p></o:p></span> (<span id="lblStageYearStr" runat="server"></span>)</p>
                        </span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span>
                        <asp:Literal ID="litStagePayment" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                    <span style="font-family: Sandaya">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                <span style="font-family: Sandaya">f.ùug ÿfnk uqtZ uqo,<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><o:p></o:p></span></p>
                        </span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <span style="font-family: Sandaya"></span>
                        <asp:Literal ID="LittotAdd" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 9px; text-align: justify">
                        <strong><span style="font-family: Sandaya">wvql,d( </span></strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">
                            <asp:Literal ID="litdefprmsdes" runat="server" Text="fkdf.jq jdrsl fldgi" Visible="False"></asp:Literal></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">
                            <asp:Literal ID="litrs_1" runat="server" Text="re(" Visible="False"></asp:Literal></span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="LitDefPrem" runat="server" Visible="False"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <asp:Table ID="Table1" runat="server" Style="text-align: center" Width="289px">
                        </asp:Table>
                    </td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">m%udo .dia;=</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="LitDefLatefee" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">Tmamq jrA<b style="mso-bidi-font-weight: normal">I</b>h
                            iuzmQrAKjSug f.jsh hq;= <span style="mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                mso-bidi-font-family: 'Times New Roman'; font-size: 10pt;"><span style="font-size: 10pt;">
                                    <span>jdrsl fldgia&nbsp;<span style="font-family: Trebuchet MS"><asp:TextBox ID="txtComYr"
                                        runat="server" Height="13px" MaxLength="7" Visible="true" Width="63px"></asp:TextBox><span
                                            style="font-family: Sandaya">&nbsp;</span><span style="font-size: 10pt; font-family: 'Trebuchet MS'"><span
                                                style="font-family: Sandaya">isg<asp:TextBox ID="txtendYr" runat="server" Height="13px"
                                                    MaxLength="7" Visible="true" Width="63px"></asp:TextBox>
                                                <span style="font-family: Trebuchet MS"></span></span><span style="font-family: Sandaya">
                                                    olajd</span></span></span></span></span></span></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="Litinstlments" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">Kh uqo,</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litLoanAmt" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">Khg fmd&lt;sh</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litLoanInt" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">jhi wvqfjka m%ldY lr ;snSu ksid<span style="mso-tab-count: 2">&nbsp;
                        </span></span><span><span style="font-size: 10pt"><span><span><span style="font-family: Sandaya">
                            jdrslh iy fmd&lt;Sh &nbsp;fyda rC<b style="mso-bidi-font-weight: normal">I</b>s; uqof,a fyda 
                            <br />
                            m%ido
                            uqof,a <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                fyda fjki</span></span></span></span></span></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litunderstated" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">fjk;a wvq lsrSu</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="LitOtherDed" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family:Sandaya;font-size:10pt;">f.jk ,o ;s%jsO wjia:d ysuslu</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litStageDeduction" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya;font-size:7.5pt; font-weight:bold">මුද්දර ගාස්තු</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litstamp" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify">
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: right; width: 105px;">
                        <span style="font-family: Sandaya">re( </span>
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litLessTot" runat="server"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: justify;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="litbalance" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">f.jsh hq;= b;srs ysusluz uqo,</span></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litnet" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">uqtZ uqo,ska f.jk udf.a$wmf.a fldgi</span><asp:Label
                            ID="lblpcntage" runat="server" Font-Names="Times New Roman" Width="70px" Font-Size="11pt"></asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                        <span style="font-family: Sandaya">re(</span></td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                        <asp:Literal ID="litshareamt" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 6px; text-align: left;" colspan="2">
                        <span style="font-size: 10pt; font-family: Sandaya">oskh </span>
                        <asp:Label ID="lblToday" runat="server" Width="108px" Font-Names="Times New Roman"
                            Font-Size="11pt"></asp:Label></td>
                    <td style="height: 6px; text-align: left;" colspan="4">
                        &nbsp;&nbsp; .......................................................................</td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 745px; height: 6px; font-size: 9pt; font-family: 'Trebuchet MS';
                        text-align: right;">
                    </td>
                    <td style="height: 6px; text-align: right;" colspan="5">
                        <span style="font-family: Sandaya"><span style="font-size: 10pt">^ysusluz lshkakdf.a
                            w;aik uqoaorh u; ;ensh hq;+hs&amp;</span></span></td>
                </tr>
            </table>
            <p class="break">
            </p>
        </div>
        <%
        
            }

        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        try
        {
            int pno1 = 0;
            foreach (string[] payeedetArr in arrList)
            {
                pno1 = 2;
                //  litno2.Text = pno1.ToString();
        %>
        <%--<p class="break"></p>--%>
        <div style="page-break-after: always">
            <table style="width: 651px; font-size: 10pt; height: 831px;">
                <tr>
                    <td style="width: 1093px; height: 10px" colspan="2">
                    </td>
                    <td style="width: 249px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 1093px; height: 10px" colspan="2">
                    </td>
                    <td style="width: 249px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 1093px; height: 10px" colspan="2">
                    </td>
                    <td style="width: 249px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 1093px; height: 10px" colspan="2">
                    </td>
                    <td style="width: 249px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 1093px; height: 10px" colspan="2">
                    </td>
                    <td style="width: 249px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 1093px; height: 10px" colspan="2">
                    </td>
                    <td style="width: 249px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 9px; text-align: justify; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            miq msfgys i|yka mdrAYjlre$lrejka jsiska ud&nbsp; bosrsfha w;aika$udmgeÛs,s i,l=K
                            ;nk ,o fuu f,aLKfhys wka;rA.; lreKq ujsiska tu mdrAYjlreg$lrejkag jsOs jq mrsos
                            mrsjrA;kh fldg $ f;areuz lrfok ,o nj iy;sl lrus<span style="font-family: 'Times New Roman';
                                mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                mso-bidi-language: AR-SA">. <span style="font-family: Sandaya">ujsiska tu mdrAYjlre
                                    $ lrejka y|qkd .kakd ,o nj iy;sl lrus<span style="font-family: 'Times New Roman';
                                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                        mso-bidi-language: AR-SA; line-height: 15pt;">.</span></span></span><?xml namespace=""
                                            ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></td>
                    <td colspan="1" style="height: 9px; text-align: left; width: 249px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 1093px; height: 10px; text-align: left">
                    </td>
                    <td colspan="1" style="width: 249px; height: 10px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 1093px; height: 10px; text-align: left">
                        <span style="font-family: Sandaya">idC<b style="mso-bidi-font-weight: normal">Is</b>
                            orK n,Odrshdf.a w;aik(</span></td>
                    <td colspan="1" style="width: 249px; font-family: Times New Roman; height: 10px;
                        text-align: left">
                        &nbsp; ..........................................................................................................</td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td colspan="2" style="width: 1093px; height: 10px; text-align: left">
                        .....................................................................................................</td>
                    <td colspan="1" style="width: 249px; height: 10px; text-align: left">
                        &nbsp;<span style="font-family: Sandaya"> ysusluz lshkakdf.a w;aik ^kej;&amp;</span></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td colspan="2" style="height: 10px; text-align: left; width: 1093px;">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        </span>
                    </td>
                    <td colspan="1" style="height: 10px; text-align: left; width: 249px;">
                        &nbsp;</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 6px; text-align: left; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            idC<b style="mso-bidi-font-weight: normal">Is</b> orK n,Odrshdf.a ku(</span></td>
                    <td colspan="1" style="height: 6px; text-align: left; width: 249px; font-family: Times New Roman;">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            &nbsp; ...........................................................................................................</span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman">
                    <td colspan="2" style="width: 1093px; height: 6px; text-align: left">
                        .....................................................................................................</td>
                    <td colspan="1" style="width: 249px; height: 6px; text-align: left">
                        <span style="font-family: Sandaya">ysusluz lshkakdf.a iuzmQrAK ku(</span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td colspan="2" style="height: 10px; text-align: left; width: 1093px;">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        </span>
                    </td>
                    <td colspan="1" style="height: 10px; text-align: left; width: 249px;">
                        &nbsp;</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 9px; text-align: left; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        </span>
                    </td>
                    <td colspan="1" style="height: 9px; text-align: left; width: 249px;">
                        <span style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'"></span>
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 10px; text-align: left; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            n,Odrshdf.a uq\%dj(</span></td>
                    <td colspan="1" style="height: 10px; text-align: left; width: 249px;">
                        <span style="font-family: Sandaya">,smskh(<span style="font-family: Times New Roman">.........................................................................................</span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td colspan="2" style="height: 6px; text-align: left; width: 1093px;">
                    </td>
                    <td colspan="1" style="height: 6px; text-align: left; width: 249px;">
                        &nbsp; &nbsp;..........................................................................................................</td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td colspan="2" style="height: 9px; text-align: left; width: 1093px;">
                    </td>
                    <td colspan="1" style="height: 9px; text-align: left; width: 249px;">
                        &nbsp;&nbsp; ..........................................................................................................</td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td colspan="2" style="height: 9px; text-align: left; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        </span>
                    </td>
                    <td colspan="1" style="height: 9px; text-align: left; width: 249px;">
                        &nbsp;&nbsp; ..........................................................................................................</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 10px; text-align: left; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        </span>
                    </td>
                    <td colspan="1" style="height: 10px; text-align: center; width: 249px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 9px; text-align: left; width: 1093px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        </span>
                    </td>
                    <td colspan="1" style="height: 9px; text-align: center; width: 249px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 9px; text-align: left; width: 1093px;">
                    </td>
                    <td colspan="1" style="height: 9px; text-align: center; width: 249px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 5px; text-align: left; width: 1093px;">
                    </td>
                    <td colspan="1" style="height: 5px; text-align: center; width: 249px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="2" style="height: 9px; text-align: left; width: 1093px;">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt">
                            <span style="font-family: Sandaya">ie(hq( jsia;r<o:p></o:p></span></p>
                    </td>
                    <td colspan="1" style="height: 9px; text-align: center; width: 249px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="3" style="height: 13px; text-align: left">
                        <ul style="margin-top: 0in" type="disc">
                            <li class="MsoNormal" style="margin: 0in 0in 0pt; tab-stops: list .5in; mso-list: l0 level1 lfo1;
                                text-align: justify; line-height: 15pt;"><span style="font-family: Sandaya">ixia:dfjka
                                    uqo,a f.jkqfha frALs; fplam;a uÛsks</span><span>.</span><span style="font-family: Sandaya"><span
                                        style="mso-spacerun: yes"> </span>tuksid fuz iuÛ tjd we;s</span><span>”</span><span
                                            style="font-family: Sandaya">jeo.;a ksfjzokh</span><span>”</span><span style="font-family: Sandaya">
                                                hk m;s%ldj lshjd ta wkqj ls%hd lrkak</span><span>.</span></li>
                        </ul>
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="3" style="height: 12px; text-align: left">
                        <ul style="margin-top: 0in" type="disc">
                            <li class="MsoNormal" style="margin: 0in 0in 0pt; tab-stops: list .5in; mso-list: l0 level1 lfo1;
                                text-align: justify; line-height: 15pt;"><span style="font-family: Sandaya">fuu f.jd
                                    ksu lsrSfuz f,aLKh rdcH ksfjzos; ks,Odrshl=</span><span>,</span><span style="font-family: Sandaya">fYa%<b
                                        style="mso-bidi-font-weight: normal">I</b>aGdOslrKfha kS;S{jrhl= iudodk jsksYaphldrhl=</span><span>,</span><span
                                            style="font-family: Sandaya">osjqreuz flduidrsia flfkl= fyda b,a,quzlre mosxps jifuys
                                            .%du ks,Odrsjrfhla bosrsfha w;aika l&lt; hq;=h</span><span>.</span><span style="font-size: 11pt;
                                                font-family: Sandaya"><o:p></o:p></span></li>
                        </ul>
                    </td>
                </tr>
                <tr style="font-style: italic; font-family: Sandaya; font-size: 10pt;">
                    <td colspan="3" style="height: 14px; text-align: left">
                        <ul style="margin-top: 0in" type="disc">
                            <li class="MsoNormal" style="margin: 0in 0in 0pt; tab-stops: list .5in; mso-list: l0 level1 lfo1;
                                text-align: justify; line-height: 15pt;"><span style="font-family: Sandaya">wl=re fkdo;a
                                    wh ;u udmgeÛZs,s i&lt;l=K ;ensh hq;= w;r</span><span style="font-family: Times New Roman">,</span><span
                                        style="font-family: Sandaya"> tu i&lt;l=K uqo,a b,a,kakdf.a udmg weÛs,s i,l+Ku njg
                                        fYa%<b style="mso-bidi-font-weight: normal">Ia</b>GdOslrKfha kS;S{jrhl= fyda iudodk
                                        jsksYaphlrejl= jsiska iy;sl l, hq;=uh</span><span style="font-family: Times New Roman">.</span><span
                                            style="font-size: 11pt; font-family: Sandaya"><o:p></o:p></span></li>
                        </ul>
                    </td>
                </tr>
                <tr style="font-size: 11pt; font-family: Sandaya;">
                    <td colspan="3" style="height: 7px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="2" style="height: 6px; text-align: left; width: 1093px;">
                    </td>
                    <td style="width: 249px; height: 6px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 8px; text-align: left; width: 1093px;" colspan="2">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; tab-stops: 131.25pt">
                            <span style="font-family: Sandaya"><span style="font-size: 10pt">fmdaru wxl 2509 <span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                                    <o:p></o:p>
                                </span></span></span></span>
                        </p>
                    </td>
                    <td style="width: 249px; height: 8px; text-align: left">
                    </td>
                </tr>
            </table>
        </div>
        <% 
            }


        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

        try
        {
            int pno2 = 0;
            foreach (string[] payeedetArr in arrList)
            {
                pno2 = 3;
                //  litno3.Text = pno2.ToString();
        %>
        <div style="page-break-after: always">
            <%-- <p class="break"></p>--%>
            <table style="width: 671px; height: 57px">
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                        <span style="font-family: Sandaya"><strong><span style="font-size: 11pt"></span></strong>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                        <strong><span style="border-right: black 1px solid; border-top: black 1px solid;
                            font-size: 11pt; border-left: black 1px solid; border-bottom: black 1px solid;
                            font-family: Sandaya">jeo.;a ksfõokhhs</span></strong></td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: justify">
                        <span style="font-size: 10pt; font-family: Sandaya; line-height: 15pt;">fï iuÛ tjd we;s
                            <span style="font-size: 10pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                mso-bidi-font-family: 'Times New Roman'">l=js;dkaisfha</span> i|yka uqo, Tng
                            f.jkq ,nkafka fplam;lsks' tu fplam; ;eme,a u.ska tjkq ,nk neúka fjk;a wh w;g m;aù
                            uqo,a lr .ekSu j,lajd,Sug Tnf.a nexl= .sKqula we;akï tu .sKqug ner msKsi fplam;
                            ilia lr,Su iqoqiqh' tneúka Tnf.a kñka Px.u fyda b;srs lsrSfï nexl= .sKqula we;akï
                            tys úia;r my; i|yka wxl 01 ,smsh u.ska wm fj; okajkak'</span></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: justify">
                        <span style="font-size: 10pt; font-family: Sandaya; line-height: 15pt;">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                                <span style="font-size: 10pt; font-family: Sandaya">Tnf.a kuska b;srs lsrSfuz .sKqula
                                    fyda fkdue;s kuz Tng myiq nexl= YdLdjlska b;srs lsrSfuz .sKqula jsjD; lr wod&lt;
                                    jsia;r wm fj; oekajSu Tnf.a uqo, iqrCIs;j ,nd .ekSug bjy,a jkjd we;<?xml namespace=""
                                        ns="urn:schemas-microsoft-com:office:office" prefix="o" ?>'</span></p>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px; text-align: left;" colspan="3">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                            <span style="font-size: 10pt; font-family: Sandaya">ie,lsh hq;=hs()<o:p></o:p></span></p>
                        <p class="MsoNormal" style="margin: 0in 0in 0pt 0.5in; text-indent: -0.25in; text-align: justify;
                            tab-stops: list .5in; mso-list: l0 level1 lfo1">
                            <span style="font-size: 11pt; font-family: 'Wingdings 2'; mso-fareast-font-family: 'Wingdings 2';
                                mso-bidi-font-family: 'Wingdings 2'"><span style="mso-list: Ignore">á<span style="font: 7pt 'Times New Roman'">
                                    &nbsp; &nbsp; </span></span></span><span style="font-size: 10pt; font-family: Sandaya">
                                        ysusluz lshkakd wl=re fkdo;a wfhl= kuz Tyqf.a fyda wehf.a w;aik fjkqjg udmge.Zs,s
                                        i,l=K ;ensh hq;= w;r tu i,l=K ysusluz lshkakdf.a we.Zs,s i,l=K njg iudodk jsksYaphldrjrfhl=
                                        jsiska fyda fYa%IaGdOslrKfha kS;S{jrfhl= jsiska iy;sl l,hq;=h</span><span style="font-size: 11pt">.</span><span
                                            style="font-size: 11pt; font-family: Sandaya"><o:p></o:p></span></p>
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px; text-align: left">
                        <span><span style="font-family: Sandaya"><span style="font-size: 10pt">wxl 1 ,smsh<o:p></o:p></span></span></span></td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px; text-align: left">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 150%; tab-stops: 327.0pt">
                                <span style="font-size: 10pt; line-height: 150%; font-family: Sandaya">cSjs;$m%dfoaYSh
                                    l&lt;uKdlre<o:p></o:p></span></p>
                        </span>
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 150%; tab-stops: 327.0pt">
                                <span style="font-size: 10pt; line-height: 150%; font-family: Sandaya">iSudiys; YS%
                                    ,xld bkaIqjria<o:p></o:p></span></p>
                        </span>
                    </td>
                    <td style="width: 1610px; height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya; border-top-width: 1px; border-left-width: 1px;
                            border-left-color: black; border-bottom-width: 1px; border-bottom-color: black;
                            border-top-color: black; border-right-width: 1px; border-right-color: black;">fhduqj(
                            PS ysñlï </span>
                        <asp:Label ID="lblclmno2" runat="server" Font-Names="Trebuchet MS" Width="88px" Font-Size="10pt"></asp:Label><?xml
                            namespace="" prefix="O" ?><o:p></o:p></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left;">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 150%; tab-stops: 327.0pt">
                            <span style="font-size: 10pt; line-height: 150%; font-family: Sandaya">fld&lt;U 02</span><span
                                style="font-size: 11pt; line-height: 150%">.<o:p></o:p></span></p>
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px">
                        <span style="font-size: 11pt; font-family: Sandaya; text-decoration: underline;"><strong>
                            rCIK T</strong></span><span style="font-size: 10pt"><span style="font-family: Sandaya"><span
                                style="font-size: 11pt"><span style="text-decoration: underline"><strong>mamq wxlh <span
                                    style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman';">
                                    (</span></strong></span></span></span><asp:Label ID="lblpolno4" runat="server" Font-Bold="True"
                                        Font-Names="Trebuchet MS" Font-Underline="True" Width="83px" Font-Size="11pt"></asp:Label></span></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: justify">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya; line-height: 15pt;">
                            by; i|yka rCIK Tmamqj hgf;a ud fj; ,eìh hq;= uqo, ioyd fplam; my; i|yka nexl= .sKqug
                            ner msKsi tjk fuka b,a,uq'<?xml namespace="" prefix="O" ?><o:p></o:p></span></span></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya"><strong>nexl= .sKqfï úia;r</strong></span></td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya">1' nexl=fõ ku yd ia:dkh
                            (</span><span style="font-family: Trebuchet MS"> ......................................................</span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya">2' nexl= .sKqfï wxlh(</span><span
                            style="font-family: Trebuchet MS">.............................................................</span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya">3' .sKqï ysñhdf.a ku(</span><span
                            style="font-family: Trebuchet MS">.............................................................</span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya">4' nexl= .sKqu Px.u
                            .sKqulao ke;fyd;a b;srs lsrSfïs.sKqula o hk j.(</span><span style="font-family: Trebuchet MS">...................</span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya">5' mdiafmd; ,nd .;af;a
                            ;eme,a y,lska kï tys k u</span><span style="font-family: Trebuchet MS">............................................</span></span></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya"></span>
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px; text-align: left" colspan="3">
                        <span style="font-size: 10pt; font-family: Sandaya"><strong>fplam; ;eme,a l&lt; hq;=
                            ,smskh(</strong></span></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya">&nbsp;ku(</span></td>
                    <td colspan="2" style="height: 10px; text-align: left">
                        ............................................................................................................</td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya">= ,smskh(</span></td>
                    <td colspan="2" style="height: 10px; text-align: left">
                        .............................................................................................................</td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                    </td>
                    <td colspan="2" style="height: 10px; text-align: left">
                        .............................................................................................................</td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                        <span><span><span style="font-family: Times New Roman"></span><span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-size: 10pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                mso-bidi-font-family: 'Times New Roman'">oqrl:k wxlh(</span></span></span></span></td>
                    <td style="width: 213px; height: 10px; text-align: left">
                        .........................................................</td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                        <span style="font-size: 10pt; font-family: Sandaya">oskh( <span style="font-family: Times New Roman">
                            ...................................................</span></span></td>
                    <td style="width: 213px; font-family: Times New Roman; height: 10px">
                    </td>
                    <td style="width: 1610px; font-family: Times New Roman; height: 10px">
                        &nbsp;<span style="font-family: 'Times New Roman'">.....................................</span></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                    </td>
                    <td style="width: 213px; height: 10px">
                    </td>
                    <td style="width: 1610px; height: 10px">
                        <span style="font-size: 10pt"><span style="font-family: Sandaya">w;aik<o:p></o:p></span></span></td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                    </td>
                    <td style="width: 213px; height: 10px; font-size: 9pt; font-family: 'Trebuchet MS';">
                    </td>
                    <td style="width: 1610px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 13482px; height: 10px; text-align: left">
                        <asp:Label ID="lblcurdate5" runat="server" Font-Size="10pt" Width="86px"></asp:Label>&nbsp;
                        <asp:Label ID="lbltime5" runat="server" Font-Size="10pt" Width="86px"></asp:Label></td>
                    <td style="width: 213px; height: 10px; text-align: left">
                        <asp:Label ID="lblepf6" runat="server" Font-Size="10pt" Width="86px"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Label ID="lblipaddr5" runat="server" Font-Size="10pt" Width="86px"></asp:Label></td>
                    <td style="width: 1610px; height: 10px; text-align: right">
                        <span style="font-size: 10pt">Form 2812</span></td>
                </tr>
            </table>
        </div>
        <%--<p class="break">
            &nbsp;</p> --%>
        <%
        
            }

        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }        
        %>
    </form>
</body>
</html>
