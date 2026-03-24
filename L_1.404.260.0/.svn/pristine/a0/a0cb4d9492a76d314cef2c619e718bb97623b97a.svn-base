<%@ Page Language="C#" AutoEventWireup="true" CodeFile="discharge001.aspx.cs" Debug="true"
    Inherits="discharge001" %>

<%@ PreviousPageType VirtualPath="~/dthPay002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script>
    
    <style type="text/css" media="print">
    .notprint
    {
      display:none;
    }
</style>
<style type="text/css">
    .break{page-break-before:always}
    </style>
    <title>SriLanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>

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

    <style type="text/css">
        .style1
        {
            height: 13px;
        }
    </style>

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

                foreach (string[] payeedetArr in arrList)
                {
                    payeeName = payeedetArr[0];
                    relationship = payeedetArr[1];
                    if (relationship == "ML")
                    {
                        this.litrel.Text = "Main Life";
                    }
                    else if (relationship == "SL")
                    {
                        this.litrel.Text = "Second Life";
                    }
                    else if (relationship == "Nominee")
                    {
                        this.litrel.Text = "Nominee";
                    }
                    reltype = payeedetArr[2];
                    payeeAmt = double.Parse(payeedetArr[3]);
                    percentage = double.Parse(payeedetArr[4]);
                    affiNomiAssiLPTdat = payeedetArr[5];

                    this.litpayeename.Text = payeeName;

                    if (relationship == "Son")
                    { this.litrel.Text = "Son"; }
                    if (relationship == "Daughter")
                    { this.litrel.Text = "Daughter"; }
                    if (relationship == "Spouce")
                    { this.litrel.Text = "Spouce"; }
                    if (relationship == "Brother")
                    { this.litrel.Text = "Brother"; }
                    if (relationship == "Sister")
                    { this.litrel.Text = "Sister"; }
                    if (relationship == "Mother")
                    { this.litrel.Text = "Mother"; }
                    if (relationship == "Father")
                    { this.litrel.Text = "Father"; }

                    this.litpayeetype.Text = reltype;
                    //======================Sum Assured Type ==================
                    if (polstat.Trim() == "I")
                    {
                        if (TBL == 28 || TBL == 46)
                        {
                            litsumdes.Text = "Double the Sum Assured";
                        }
                        else if (TBL == 29)
                        {
                            if (MOF == "M")
                            {
                                litsumdes.Text = "Double the Increased Sum Assured";
                            }
                            else
                            {
                                litsumdes.Text = "Sum Assured"; 
                            }
                        }
                        else
                        {
                            litsumdes.Text = "Sum Assured";
                        }
                    }
                    else
                    {
                        if (TBL == 29)
                        {
                            if (MOF == "M")
                            {
                                litsumdes.Text = "Increased Paid Up Value";
                            }
                            else
                            {
                                litsumdes.Text = "Sum Assured";
                            }
                        }
                        else
                        {
                            litsumdes.Text = "Paid Up Value";
                        }
                    }

                    //==========================================================

                    this.lblpcntage.Text = String.Format("{0:N}", (double)(percentage * 100)) + "%";
                    //this.litshareamt.Text = String.Format("{0:N}", (double)payeeAmt);
                    //this.lblsharAmt.Text = String.Format("{0:N}", payeeAmt);
                    this.lblsharAmt.Text = (Math.Truncate(Math.Round(payeeAmt * 100, 4)) / 100).ToString("N2");
                    double netclm100 = 0;
                    if (netclm < 0) { netclm100 = 0; }
                    else { netclm100 = (Math.Round(grossClm, 2) * 100); }
                    if (netclm100 != 0)
                    {
                        string netclminwords = netclm100.ToString().Substring(0, (netclm100.ToString().Length - 2)) + "." + netclm100.ToString().Substring((netclm100.ToString().Length - 2), 2);
                        readAmountFunction readamt = new readAmountFunction();
                        this.litSumInWords.Text = readamt.readAmount(netclminwords, "SRI LANKAN RUPEES", "CENTS ");
                    }
                    else
                    {
                        this.litSumInWords.Text = "ZERO SRI LANKAN RUPEES AND ZERO CENTS ONLY";
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
                            this.litlifeAssured.Text = status + Fulname + " & " + ChildStts + ChildFname;
                            dm.connClose();
                        }

                        else
                        {
                            this.litlifeAssured.Text = status + Fulname;// +" & " + Fullname; ;
                        }

                        //===============================================================                    
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
                                this.litlifeAssured.Text = status + Fulname + " & " + SpsStatus + Fullname;
                                dm.connClose();
                            }
                        }
                        #endregion
                        else
                        {
                            this.litlifeAssured.Text = status + Fulname;// +" & " + Fullname; ;
                        }
                    }

                    double ageUnderStAmt = 0;
                    double ageOverStAmt = 0;

                    if (ageStatus != null && ageStatus.Equals("O")) { ageOverStAmt = ageDiffAmt; }
                    else if (ageStatus != null && ageStatus.Equals("Y")) { ageUnderStAmt = ageDiffAmt; }
                                        
                    double AgediffIntest = 0.0;
                    string GetagediffInt="select AGEDIFINRST from lphs.dthref where drpolno="+polno+"";
                    dthintobj.readSql(GetagediffInt);
                    System.Data.OracleClient.OracleDataReader readint = dthintobj.oraComm.ExecuteReader();
                    while (readint.Read())
                    {
                        if (!readint.IsDBNull(0)) { AgediffIntest = readint.GetDouble(0); } else { AgediffIntest = 0.0; }
                    }
                    readint.Close();
                    if(AgediffIntest!=0.0 ||ageUnderStAmt!=0.0)
                    {
                        double TotalAgeAmount = AgediffIntest + ageUnderStAmt;
                    }
                    
                    
                    this.litpolno.Text = polno.ToString();

                    this.litDateofDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                    this.litlDCO.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                    this.litclmno.Text = claimno.ToString();
                    litref.Text = claimno.ToString();
                    if (interimBonus != 0.00)
                    {  
                    }
                    
                    if (interimBonus != 0.00)
                    {
                        int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                        int nxtbonyr = interimBonStYr;
                        int yeardiff = this.dateComparison(lstbondecyr, dateofdeath)[0];
                        for (int i = 0; i < yeardiff; i++)
                        {
                            nxtbonyr = nxtbonyr + 1;
                        }
                        litinbst.Visible = false;
                        litintbend.Visible = false;
                        Txtinbst.Visible = true;
                        Txtintbend.Visible = true;

                        this.litinbst.Text = "Interim Bonus  ";
                        Txtinbst.Text = interimBonStYr.ToString();
                        if (nxtbonyr != interimBonStYr) { this.litintbend.Text = " to "; Txtintbend.Text = nxtbonyr.ToString(); }
                        litrs2.Visible = true;
                        litlintbon.Visible = true;
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
                    this.litbonSt.Text = "Bonus";
                    litbonSt.Visible = true;
                    if (vestedBonus != 0.00)
                    {
                        TxtbonSt.Visible = true;
                        litbonend.Visible = true;
                        Txtbonend.Visible = true;

                    }
                    litrs1.Visible = true;
                    litVestbon.Visible = true;

                    if (vestedBonus != 0.00)
                    {
                        if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49)
                        {
                            this.litbonSt.Text = "Bonus ";
                            TxtbonSt.Text = COM.ToString().Substring(0, 4);
                            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }               
                            this.litbonend.Text = " to ";
                            Txtbonend.Text = interimBonStYr.ToString();
                            litrs1.Visible = true;
                            litVestbon.Visible = true;
                            TxtbonSt.Visible = true;
                            Txtbonend.Visible = true;
                        }
                        else if ((TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL != 49) && (polstat.Trim() == "I"))
                        {
                        
                            this.litbonSt.Text = "";
                            TxtbonSt.Text = "";
                            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }               
                            this.litbonend.Text = "";
                            Txtbonend.Text = "";
                            litrs1.Visible = false;
                            litVestbon.Visible = false;
                            TxtbonSt.Visible = false;
                            Txtbonend.Visible = false;
                        }
                        else if ((TBL == 38) && (polstat.Trim() == "L"))
                        {
                            this.litbonSt.Text = "";
                            TxtbonSt.Text = "";
                            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }               
                            this.litbonend.Visible = false;
                            Txtbonend.Visible = false;
                            litrs1.Visible = false;
                            litVestbon.Visible = false;
                            TxtbonSt.Visible = false;
                            Txtbonend.Visible = false;
                        }

                    }

                    this.litageovst.Text = String.Format("{0:N}", ageOverStAmt);
                    this.litUnderstated.Text = String.Format("{0:N}", (ageUnderStAmt+AgediffIntest));
                    //this.litComYr.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2);
                    txtComYr.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2);
                    if (polcompleYM != null)
                    {
                        //this.litlendYr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2); 
                        txtendYr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2);
                    }
                    //double x = PRM * missingprems;
                    double x = amtComyr;
                    this.litInstlments.Text = String.Format("{0:N}", x+deductAmount);
                    this.litdeceaseName.Text = nameOfDead;
                    this.litdeceasename2.Text = nameOfDead;
                    // this.litlifeAssured.Text = phname;

                    if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) 
                    { 
                        this.litVestbon.Text = String.Format("{0:N}", vestedBonus); 
                        this.litlintbon.Text = String.Format("{0:N}", interimBonus); 
                    }
                    else
                    {
                        if (MOF == "2")
                        {
                            this.litVestbon.Text = String.Format("{0:N}", vestedBonus);
                            this.litlintbon.Text = String.Format("{0:N}", interimBonus);
                            this.litdeceasename2.Text = nameOfDead;
                            this.litbonSt.Text = "Bonus ";
                            TxtbonSt.Text = COM.ToString().Substring(0, 4);
                            this.litbonend.Text = " to ";
                            Txtbonend.Text = interimBonStYr.ToString();
                            litbonSt.Visible=true;
                            TxtbonSt.Visible=true;
                            litbonend.Visible=true;
                            Txtbonend.Visible=true;
                            litrs1.Visible=true;
                            litVestbon.Visible = true;
                            
                            
                        }
                        else if ((MOF == "M") && (recipient == "SL") && (polstat == "L"))//
                        {
                            ////this.litVestbon.Text = String.Format("{0:N}", vestedBonus);
                            ////this.litlintbon.Text = String.Format("{0:N}", interimBonus);
                            this.litVestbon.Text = String.Format("{0:N}", 0);
                            this.litlintbon.Text = String.Format("{0:N}", 0);
                        }
                        else
                        {
                            this.litVestbon.Text = "0.00"; this.litlintbon.Text = "0.00";
                        }
                    }
                    if (TBL == 34 || TBL == 38 || TBL == 39 || TBL == 46 || TBL == 49)
                    {
                        if ((MOF == "M" || MOF == "S") && (recipient == "SL"))
                        {
                            litpayeetype.Text = "Proposal";
                        }
                        //if (TBL == 46 && MOF == "2" && recipient == "ML")
                        //{
                        //    litpayeetype.Text = "Proposal";
                        //}
                        if ((MOF == "2" || MOF == "C") && recipient == "ML")
                        {
                            litpayeetype.Text = "Proposal";
                        }
                    }
                    if (MOF == "S")
                    {
                        litpayeetype.Text = "Proposal";
                    }

                    if (TBL == 14)
                    {
                        litpayeetype.Text = "Proposal";
                    }
                    DataManager defObj = new DataManager();

                    if (litpayeetype.Text.ToUpper() == "PROPOSAL")
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
                    if ((ADB > 0) && (!adbLatepay.Equals("Y"))) { this.lit1.Visible = true; this.lbladbStr.Visible = true; this.litAccBene.Visible = true; this.litAccBene.Text = String.Format("{0:N}", (double)ADB); }
                    else { this.lit1.Visible = false; this.lbladbStr.Visible = false; this.litAccBene.Visible = false; }
                    if (FPU > 0) { this.lit2.Visible = true; this.lblfpustr.Visible = true; this.litfpu.Visible = true; this.litfpu.Text = String.Format("{0:N}", (double)FPU); }
                    else { this.lit2.Visible = false; this.lblfpustr.Visible = false; this.litfpu.Visible = false; }
                    if (FE > 0) { this.lit4.Visible = true; this.lblfestr.Visible = true; this.litfe.Visible = true; this.litfe.Text = String.Format("{0:N}", (double)FE); }
                    else { this.lit4.Visible = false; this.lblfestr.Visible = false; this.litfe.Visible = false; }
                    if (SJ > 0) { this.lit3.Visible = true; this.lblsjstr.Visible = true; this.litsj.Visible = true; this.litsj.Text = String.Format("{0:N}", (double)SJ); }
                    else { this.lit3.Visible = false; this.lblsjstr.Visible = false; this.litsj.Visible = false; }
                    //double riderbene = ADB + FPU + FE + SJ;                

                    this.litLoanAmt.Text = String.Format("{0:N}", loancap);
                    this.litLoanIns.Text = String.Format("{0:N}", loanint);
                    if (demmands != 0.00)
                    {
                        this.litdefPrem.Text = String.Format("{0:N}", demmands);
                        litdefprmsdes.Visible = true;
                        litrs_1.Visible = true;
                        litdefPrem.Visible = true;
                        Table1.Visible = true;
                    }
                    else
                    {
                        litdefprmsdes.Visible = false;
                        litrs_1.Visible = false;
                        litdefPrem.Visible = false;
                        Table1.Visible = false;
                    }
                    //this.litdefPrem.Text = String.Format("{0:N}", demmands);
                    this.litdeflatefee.Text = String.Format("{0:N}", defint);
                    this.lblnet.Text = String.Format("{0:N}", netclm);
                    this.lblsuminFigures.Text = String.Format("{0:N}", grossClm);
                    this.litotheradd.Text = String.Format("{0:N}", otheradd);
                    this.LitDeposit.Text = String.Format("{0:N}", deposit);//...Add on 2009/05/05 by Buddhika..
                    this.littoadd.Text = String.Format("{0:N}", grossClm);
                    this.litStagePayment.Text = String.Format("{0:N}", stagepayment);
                    this.lblStageYearStr.InnerText = stagePaymentString;
                    if(polstat == "L")
                    {
                         this.litOtherDed.Text = String.Format("{0:N}", otherdeuct - stagepaydeduction);
                         this.litStageDeduction.Text = String.Format("{0:N}",stagepaydeduction);
                    }
                    else
                    {
                         this.litOtherDed.Text = String.Format("{0:N}", otherdeuct);
                         this.litStageDeduction.Text = String.Format("{0:N}",stagepaydeduction);
                    }
                   
                    double lesstotal = demmands + defint + x + loancap + loanint + otherdeuct + (ageUnderStAmt + AgediffIntest)  + deductAmount;
                    this.litLessTot.Text = String.Format("{0:N}", lesstotal);
                    this.lblToday.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.lblBalance.Text = String.Format("{0:N}", netclm);
                    this.litSumassrd.Text = String.Format("{0:N}", sumassured);
                    this.Litprm.Text = prmRefund.ToString("N2");
                    //this.litref.Text = epf;
                    this.litpolno4.Text = polno.ToString();
                    this.litcurdate5.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    this.littime5.Text = this.setDate()[1];
                    this.litipaddr5.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    //this.litepf6.Text = epf;
                    if (int.Parse(affiNomiAssiLPTdat) > 9999999)
                    {
                        TxtDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                        // this.litDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                    }
                    string ChkDefPrms = "select PDDUE from LPHS.DEMAND  WHERE  ( PDCOD = 'D'  AND  PDPOL =" + polno + " )";
                    if (defObj.existRecored(ChkDefPrms) != 0)
                    {
                        int Dueyrmn = 0;
                        ArrayList DueyrmnArr = new ArrayList();
                        defObj.readSql(ChkDefPrms);
                        System.Data.OracleClient.OracleDataReader drdef = defObj.oraComm.ExecuteReader();
                        Table1.Rows.Clear();
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
            <table style="width: 645px; font-size: 10pt; font-family: 'Trebuchet MS';">
                <tr>
                    <td style="width: 47px; height: 10px">
                    </td>
                    <td style="width: 453px; height: 10px">
                    </td>
                    <td style="width: 461px; height: 10px">
                    </td>
                    <td style="height: 10px; width: 61px;">
                    </td>
                    <td style="height: 10px; width: 78px;">
                    </td>
                    <td style="width: 64px; height: 10px">
                    </td>
                    <td style="width: 76px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 47px; height: 10px">
                    </td>
                    <td style="width: 453px; height: 10px">
                    </td>
                    <td style="width: 461px; height: 10px">
                    </td>
                    <td style="height: 10px; width: 61px;">
                    </td>
                    <td style="height: 10px; width: 78px;">
                    </td>
                    <td style="width: 64px; height: 10px">
                    </td>
                    <td style="width: 76px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 47px; height: 10px">
                    </td>
                    <td style="width: 453px; height: 10px">
                    </td>
                    <td style="width: 461px; height: 10px">
                    </td>
                    <td style="width: 61px; height: 10px; text-align: left">
                    </td>
                    <td style="width: 78px; height: 10px; text-align: left">
                    </td>
                    <td colspan="3" style="height: 10px; text-align: left">
                    LI/DC/FO/SE/08</td>
                </tr>
                <tr>
                    <td style="width: 47px; height: 10px">
                    </td>
                    <td style="width: 453px; height: 10px">
                    </td>
                    <td style="width: 461px; height: 10px">
                    </td>
                    <td style="width: 61px; height: 10px; text-align: left">
                    </td>
                    <td style="width: 78px; height: 10px; text-align: left">
                    </td>
                    <td colspan="3" style="height: 10px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 47px; height: 10px">
                    </td>
                    <td style="width: 453px; height: 10px">
                    </td>
                    <td style="width: 461px; height: 10px">
                    </td>
                    <td style="height: 10px; text-align: left; width: 61px;">
                    </td>
                    <td style="height: 10px; text-align: left; width: 78px;">
                    </td>
                    <td style="height: 10px; text-align: left" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 9px; text-align: left">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><strong><%--WITHOUT PREJUDICE--%></strong></span></td>
                    <td style="height: 9px; text-align: right" colspan="7">
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            &nbsp; &nbsp; <span>Claim No. L/Claims/1/<asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 8px" colspan="9">
                    </td>
                </tr>
                <tr>
                    <td style="height: 8px" colspan="9">
                        <strong><span style="font-size: 16pt">SRI LANKA INSURANCE CORPORATION LIFE LTD</span></strong></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 10px">
                        <span style="font-family: 'Trebuchet MS'; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt;">DISCHARGE OF POLICY NO.
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></span></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 9px; text-align: center;">
                        <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-size: 10pt; font-family: 'Trebuchet MS';">On the life of&nbsp;
                                <asp:Literal ID="litlifeAssured" runat="server"></asp:Literal></span>&nbsp;
                            <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                font-size: 10pt;"><span style="font-size: 10pt">Dated </span>
                                <asp:Literal ID="litlDCO" runat="server"></asp:Literal>&nbsp;</span></span></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 15px; text-align: left;">
                        <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="mso-spacerun: yes"><span style="font-size: 10pt"></span><span style="mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                <span style="font-size: 10pt; font-family: Trebuchet MS; text-justify: auto; text-align: justify;">
                                    I/We
                                    <asp:Literal ID="litpayeename" runat="server"></asp:Literal>
                                    being
                                    <asp:Literal ID="litrel" runat="server"></asp:Literal>
                                    of the above named
                                    <asp:Literal ID="litdeceaseName" runat="server"></asp:Literal>
                                    by virtue of a/an&nbsp;
                                    <asp:Literal ID="litpayeetype" runat="server"></asp:Literal>
                                    under date&nbsp;
                                    <asp:TextBox ID="TxtDated" runat="server" class="notprint" Height="13px" MaxLength="10"
                                        Visible="true" Width="81px"></asp:TextBox>
                                    hereby agree to accept from the above mentioned&nbsp; Corporation of the sum
                                    of
                                    <asp:Literal ID="litSumInWords" runat="server"></asp:Literal>(<strong>Rs.</strong><asp:Label
                                        ID="lblsuminFigures" runat="server" Font-Bold="True" Width="108px" Font-Size="10pt"></asp:Label>)</span></span></span></span></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 8px">
                        <strong><span style="font-size: 10pt"></span></strong>
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 18px; text-align: justify;">
                        <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-size: 10pt; font-family: 'Trebuchet MS';">Including the amount of
                                bonus in full satisfaction and discharge of all my/our claim and demands under the
                                above policy on the life of the there in mentioned
                                <asp:Literal ID="litdeceasename2" runat="server"></asp:Literal>
                                who died on
                                <asp:Literal ID="litDateofDeath" runat="server"></asp:Literal>
                                and which policy is hereby delivered up to the said Corporation to be cancelled.</span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 8px; text-align: left">
                    </td>
                    <td colspan="6" style="font-size: 10pt; height: 8px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 8px; width: 400px; text-align: left; font-size: 10pt;">
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt; direction: ltr; text-align: left;"><span style="font-family: Trebuchet MS;
                                text-align: left">
                                <asp:Literal ID="litsumdes" runat="server" Text="Sum Assured / Paid up Value-"></asp:Literal>
                                <asp:Literal ID="litsumonexgr" runat="server"></asp:Literal></span></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 8px; width: 64px; text-align: right">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 8px; width: 200; text-align: right">
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt;">
                            <asp:Literal ID="litSumassrd" runat="server"></asp:Literal></span></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 10px; text-align: left">
                        <span style="mso-spacerun: yes">
                            <asp:Literal ID="litbonSt" runat="server"></asp:Literal>
                            <!--<asp:TextBox ID="TxtbonSt" runat="server" Height="13px" Width="41px" Visible="False"
                                MaxLength="4"></asp:TextBox>
                            <asp:Literal ID="litbonend" runat="server"></asp:Literal>
                            <asp:TextBox ID="Txtbonend" runat="server" Height="13px" Width="41px" Visible="False"
                                MaxLength="4"></asp:TextBox><span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                    font-size: 10pt;"></span>--></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 10px; text-align: right; width: 64px;">
                        <asp:Literal ID="litrs1" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="4" style="font-size: 10pt; height: 10px; text-align: right">
                        <asp:Literal ID="litVestbon" runat="server" Visible="False"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 10px; text-align: left">
                        <!--<asp:Literal ID="litinbst" runat="server" Visible="False"></asp:Literal>
                        <asp:TextBox ID="Txtinbst" runat="server" Height="13px" Visible="False" Width="41px"
                            MaxLength="4"></asp:TextBox>&nbsp;<span style="mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                <asp:Literal ID="litintbend" runat="server" Visible="False"></asp:Literal>
                                <asp:TextBox ID="Txtintbend" runat="server" Height="13px" Visible="False" Width="41px"
                                    MaxLength="4"></asp:TextBox></span>--></td>
                    <td colspan="1" style="font-size: 10pt; height: 10px; text-align: right; width: 64px;">
                        <asp:Literal ID="litrs2" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="4" style="font-size: 10pt; height: 10px; text-align: right">
                        <asp:Literal ID="litlintbon" runat="server" Visible="False"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 10px; text-align: left">
                        Diff, of Prem. on account of age h<span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">aving
                            been overstated</span></td>
                    <td colspan="1" style="font-size: 10pt; height: 10px; text-align: right; width: 64px;">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 10px; text-align: right">
                        <asp:Literal ID="litageovst" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 10px; text-align: left">
                        <asp:Label ID="lbladbStr" runat="server" Text="ADB" Visible="False" Width="101px"
                            Font-Size="10pt"></asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; height: 10px; text-align: right; width: 64px;">
                        <asp:Literal ID="lit1" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="4" style="font-size: 10pt; height: 10px; text-align: right">
                        <asp:Literal ID="litAccBene" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 10px; text-align: left">
                        <asp:Label ID="lblfpustr" runat="server" Text="FPU" Visible="False" Width="100px"
                            Font-Size="10pt"></asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; height: 10px; text-align: right; width: 64px;">
                        <asp:Literal ID="lit2" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="4" style="font-size: 10pt; height: 10px; text-align: right">
                        <asp:Literal ID="litfpu" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 10px; text-align: left">
                        <asp:Label ID="lblsjstr" runat="server" Text="SJ" Visible="False" Width="100px" Font-Size="10pt"></asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; height: 10px; text-align: right; width: 64px;">
                        <asp:Literal ID="lit3" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="4" style="font-size: 10pt; height: 10px; text-align: right">
                        <asp:Literal ID="litsj" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        <asp:Label ID="lblfestr" runat="server" Text="FE" Visible="False" Width="100px" Font-Size="10pt"></asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 64px;">
                        <asp:Literal ID="lit4" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litfe" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        Other additions
                        <asp:Label ID="lblothradonExg" runat="server" Width="87px"></asp:Label></td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 64px;">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litotheradd" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        Premium Refund</td>
                    <td colspan="1" style="font-size: 10pt; width: 64px; height: 4px; text-align: right">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="Litprm" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        Deposit refund</td>
                    <td colspan="1" style="font-size: 10pt; width: 64px; height: 4px; text-align: right">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="LitDeposit" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        Unpaid Stage Payment Claim (<span id="lblStageYearStr" runat="server"></span>)</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 64px;">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litStagePayment" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        Gross Claim</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 64px;">
                        Rs.</td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="littoadd" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="9" style="font-size: 10pt; height: 4px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="font-size: 10pt; height: 4px; text-align: left">
                        <strong>Less:</strong></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        <asp:Literal ID="litdefprmsdes" runat="server" Text="Unpaid installment of premium"
                            Visible="False"></asp:Literal></td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        <asp:Literal ID="litrs_1" runat="server" Text="Rs." Visible="False"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litdefPrem" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        <asp:Table ID="Table1" runat="server" Width="173px" Style="text-align: center">
                        </asp:Table>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 61px; height: 4px; text-align: right">
                    </td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Late Fee on unpaid premium</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litdeflatefee" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Installments of premium due to complete <span style="font-family: Trebuchet MS">t</span><span
                            style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt;"><span style="font-family: Trebuchet MS">he</span> <span style="font-family: Trebuchet MS">
                                policy year from&nbsp;</span>
                            <asp:TextBox ID="txtComYr" runat="server" Height="13px" Visible="true" Width="63px"
                                MaxLength="7"></asp:TextBox><span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                    font-size: 10pt;"><span style="font-family: Trebuchet MS">to </span>
                                    <asp:TextBox ID="txtendYr" runat="server" Height="13px" Visible="true" Width="63px"
                                        MaxLength="7"></asp:TextBox></span></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litInstlments" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Loan</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litLoanAmt" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Interest on Loan</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litLoanIns" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Difference of Premium&nbsp; and Interest or Sum Assured <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt;">&amp; Bonus on account of age having been <span style="font-family: 'Trebuchet MS';
                                mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                mso-bidi-language: AR-SA; font-size: 10pt;">understated</span></span></td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litUnderstated" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Other Deductions</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litOtherDed" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Stage Payment Deductions</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litStageDeduction" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
               <%-- <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Stamp Duty</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litstampduty" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 4px; text-align: left">
                        Total Deductions</td>
                    <td colspan="1" style="font-size: 10pt; height: 4px; text-align: right; width: 61px;">
                        Rs.</td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                        <asp:Literal ID="litLessTot" runat="server"></asp:Literal></td>
                    <td colspan="3" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 64px; height: 4px; text-align: right">
                    </td>
                    <td colspan="4" style="font-size: 10pt; height: 4px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        &nbsp;</td>
                    <td colspan="1" style="font-size: 10pt; width: 64px; height: 4px; text-align: right">
                        Rs.</td>
                    <td style="font-size: 10pt; height: 4px; text-align: right" colspan="4">
                        <asp:Label ID="lblBalance" runat="server" Width="108px" Style="text-align: right"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        Net amount payable</td>
                    <td colspan="1" style="font-size: 10pt; width: 64px; height: 4px; text-align: right">
                        Rs.</td>
                    <td style="font-size: 10pt; height: 4px; text-align: right" colspan="4">
                        <asp:Label ID="lblnet" runat="server" Width="108px" Style="text-align: right"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="5" style="font-size: 10pt; height: 4px; text-align: left">
                        My/Our share being
                        <asp:Label ID="lblpcntage" runat="server" Width="64px" Font-Names="Trebuchet MS"
                            Font-Size="10pt"></asp:Label>
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt;">net amount payable i.e.</span></td>
                    <td colspan="1" style="font-size: 10pt; width: 64px; height: 4px; text-align: right">
                        Rs.</td>
                    <td style="font-size: 10pt; height: 4px; text-align: right" colspan="4">
                        <asp:Label ID="lblsharAmt" runat="server" Width="108px" Style="text-align: right"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="9" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 9px; text-align: left" colspan="3">
                        Date&nbsp;
                        <asp:Label ID="lblToday" runat="server" Width="108px"></asp:Label></td>
                    <td style="height: 9px; text-align: center" colspan="7">
                        ................................................. &nbsp;
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 47px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 453px; height: 8px">
                    </td>
                    <td colspan="1" style="width: 461px; height: 8px; text-align: right">
                    </td>
                    <td style="height: 8px; text-align: center" colspan="7">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">(Claimant’s Signature in
                            full)</span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 9px; text-align: left;" colspan="8">
                        <asp:Label ID="lblmessage" runat="server" Width="204px" ForeColor="#FF0033"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 9px; text-align: left;" colspan="2">
                        Form No. 2510</td>
                    <td style="width: 461px; height: 9px; text-align: left">
                    </td>
                    <td style="height: 9px; text-align: left; width: 61px;">
                    </td>
                    <td style="height: 9px; width: 78px;">
                    </td>
                    <td style="height: 9px; width: 64px;">
                    </td>
                    <td style="width: 76px; height: 9px">
                    </td>
                    <td style="width: 151px; height: 9px">
                    </td>
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
            foreach (string[] payeedetArr in arrList)
            {        
        %>
        <div style="page-break-after: always">
            <table style="width: 645px; font-size: 10pt;">
                <tr>
                    <td colspan="3" style="height: 10px">
                    </td>
                    <td colspan="2" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
                    </td>
                    <td colspan="2" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 12px" colspan="3">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                            <span style="font-family: Trebuchet MS">Signed/thumb impression affixed by the above
                                mentioned party/ies in my presence and certify that the contents were duly translated
                                and explained by me to the party/ies who has/ have being identified by me.</span></p>
                    </td>
                    <td style="height: 12px" colspan="2">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt">
                            <span></span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15px; height: 9px">
                    </td>
                    <td colspan="2" style="height: 9px; text-align: left">
                    </td>
                    <td style="width: 163px; height: 9px; text-align: right">
                    </td>
                    <td style="width: 109px; height: 9px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px" colspan="3">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left;">
                            <span style="font-family: Trebuchet MS">Signature of Attesting Authority</span></p>
                    </td>
                    <td style="height: 10px; text-align: left" colspan="2">
                        &nbsp; ..................................................................................................</td>
                </tr>
                <tr>
                    <td style="height: 9px; text-align: left;" colspan="3">
                        ............................................................................................................</td>
                    <td style="height: 9px; text-align: left" colspan="2">
                        <span style="font-family: Trebuchet MS">&nbsp; Specimen Signature of Claimant</span></td>
                </tr>
                <tr>
                    <td style="height: 10px; text-align: left;" colspan="3">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Name of Attesting Authority</span></td>
                    <td style="height: 10px; text-align: left" colspan="2">
                        <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            &nbsp;.<span style="font-size: 10pt">................................................................................................</span></span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 9px; text-align: left;" colspan="3">
                        .............................................................................................................</td>
                    <td style="height: 9px; text-align: left" colspan="2">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            &nbsp; Full Name of Claimant</span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 10px; text-align: left;" colspan="3">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Designation <span style="font-family: Times New Roman">.....................................................................................</span></span></td>
                    <td style="height: 10px; text-align: left; font-size: 10pt; font-family: Times New Roman;"
                        colspan="2">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 10px; text-align: left;" colspan="3">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Address &nbsp; &nbsp; <span style="font-family: Times New Roman">.......................................................................................</span></span></td>
                    <td style="height: 10px; text-align: left; font-family: Times New Roman;" colspan="2">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            &nbsp; Address of Claimant <span style="font-family: Times New Roman">........................................................</span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 9px; text-align: left;" colspan="3">
                        .............................................................................................................</td>
                    <td style="height: 9px; text-align: right" colspan="2">
                        ...............................................................................................</td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 7px; text-align: left;" colspan="3">
                        .............................................................................................................</td>
                    <td style="height: 7px; text-align: right" colspan="2">
                        ...............................................................................................</td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 9px" colspan="3">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        </span>
                    </td>
                    <td style="height: 9px; text-align: left" colspan="2">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 10px; text-align: left;" colspan="3">
                        <span style="font-family: Trebuchet MS">Official Seal <span style="font-family: Times New Roman">
                            ....................................................................................</span></span></td>
                    <td style="height: 10px; text-align: left; font-family: Times New Roman;" colspan="2">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman">
                    <td style="text-align: left;" colspan="5" class="style1">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <strong>Note:-</strong></span></td>
                </tr>

                <tr style="font-size: 10pt">
                    <td style="height: 12px; text-align: left;" colspan="5">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            1. *The Corporation make payments by crossing cheques. Therefore, please read the 
                            attached form of "Important Notice" and make arrangements accordingly.</span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 15px; height: 9px">
                    </td>
                    <td colspan="4" style="height: 9px; text-align: left">
                    </td>
                </tr>
                
                <tr style="font-size: 10pt">
                    <td style="height: 13px; text-align: left;" colspan="5">
                        <span><span></span><span><span style="font-family: Trebuchet MS"></span><span></span>
                            <span><span style="font-family: Trebuchet MS"><span style="mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;">
                                2. **This discharge must be signed before a gazetted Officer or Advocate or </span>
                                <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml namespace="" prefix="ST1" ?><?xml namespace="" prefix="ST1" ?><st1:place><st1:City><SPAN 
      style="FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Proctor</SPAN></st1:City><SPAN 
      style="FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"> 
      </SPAN><st1:State><SPAN 
      style="FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">S.C.</SPAN></st1:State></st1:place><st1:city></st1:city>
                                <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Proctor</span><span style="mso-fareast-font-family: 'Times New Roman';
                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                    </span>
                                <st1:state></st1:state>
                                <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                    <st1:city></st1:city>
                                    <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                        mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Proctor</span><span style="mso-fareast-font-family: 'Times New Roman';
                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                        </span><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="mso-fareast-font-family: 'Times New Roman';
                                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="mso-fareast-font-family: 'Times New Roman';
                                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="mso-fareast-font-family: 'Times New Roman';
                                                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;">
                                                                or N.P. or Justice of Peace, or a Commissioner of Oaths or Gramasevaka of the place
                                                                where the claimant resides.</span></span></span></span></span></span></span></span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 15px; height: 9px">
                    </td>
                    <td colspan="4" style="height: 9px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 12px; text-align: left;" colspan="5">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            3. ***Illiterate Persons must affix their thumb mark which should be identified by
                            a Proctor S.C. or N.P. or Justice of Peace, as that of the claimant’s.</span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 15px; height: 9px">
                    </td>
                    <td colspan="4" style="height: 9px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 15px; height: 8px">
                    </td>
                    <td style="width: 47px; height: 8px">
                    </td>
                    <td style="width: 124px; height: 8px">
                    </td>
                    <td style="width: 163px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 109px; height: 8px">
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
            foreach (string[] payeedetArr in arrList)
            {
        %>
        <div style="page-break-after: always">
            <table style="width: 644px; text-align: center; font-size: 10pt;">
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 130%;
                            text-align: center; tab-stops: 39.75pt 1.0in 1.5in 2.0in 2.5in 3.0in 3.5in 4.0in 4.5in 437.25pt">
                            <b style="mso-bidi-font-weight: normal"><span style="text-decoration: underline"><span
                                style="font-family: Trebuchet MS">IMPORTANT NOTICE<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><?xml
                                        namespace="" prefix="O" ?><o:p></o:p></span></span></b></p>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Arial Black">
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px">
                    </td>
                    <td style="width: 193px; height: 10px">
                    </td>
                    <td style="width: 341px; height: 10px; text-align: left">
                    </td>
                </tr>
                <tr style="font-family: Times New Roman; font-size: 10pt;">
                    <td style="width: 4px">
                    </td>
                    <td colspan="3" rowspan="3" style="text-align: justify">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;">
                            A cheque will be sent to you on receipt of the attached Discharge Receipt duly completed.
                            If you have a bank account, please let us know by Letter No. 1 given below to issue
                            the cheque payable to the credit of your Bank Account in order to avoid any third
                            party encashing the cheque if lost in the post.</span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 5px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 7px">
                    </td>
                    <td style="width: 53px; height: 7px; text-align: left">
                    </td>
                    <td style="width: 193px; height: 7px; text-align: left">
                    </td>
                    <td style="width: 341px; height: 7px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px">
                    </td>
                    <td colspan="3" rowspan="2" style="text-align: left">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 130%; text-align: justify;
                            tab-stops: 39.75pt 1.0in 1.5in 2.0in 2.5in 3.0in 3.5in 4.0in 4.5in 437.25pt">
                            <span style="font-family: Trebuchet MS">If you do not have at least a Savings Account,
                                we would advice you to open a Savings Account for the safe receipt of your money
                                and inform us by Letter No. 1 below:</span></p>
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 2px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 10px;">
                    </td>
                    <td colspan="3" style="border-bottom: black thin solid; text-align: left; height: 10px;">
                        <asp:Label ID="Label20" runat="server" Text="  " Width="33px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td style="width: 53px; height: 9px; text-align: left">
                    </td>
                    <td style="width: 193px; height: 9px; text-align: left">
                    </td>
                    <td style="width: 341px; height: 9px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 8px;">
                    </td>
                    <td colspan="2" style="text-align: left; height: 8px;">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 130%; tab-stops: 39.75pt 1.0in 1.5in 2.0in 2.5in 3.0in 3.5in 4.0in 4.5in 437.25pt">
                            <b style="mso-bidi-font-weight: normal"><span style="font-family: Trebuchet MS">LETTER
                                No. 1<o:p></o:p></span></b></p>
                    </td>
                    <td style="width: 341px; text-align: left; height: 8px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="2" style="height: 9px; text-align: left">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Life/Regional Manager,</span></td>
                    <td style="width: 341px; height: 9px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 9px;">
                    </td>
                    <td colspan="2" style="text-align: left; height: 9px;">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Sri Lanka Insurance Corporation Life Ltd.</span></td>
                    <td style="width: 341px; text-align: left; height: 9px;">
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;">
                            <span style="font-family: Trebuchet MS">Ref: L /PHS/</span>
                            <asp:Literal ID="litref" runat="server"></asp:Literal></span></td>
                </tr>
                <tr style="font-weight: bold; text-decoration: underline; font-size: 10pt;">
                    <td style="width: 4px; height: 2px;">
                    </td>
                    <td colspan="2" style="text-align: left; height: 2px;">
                    </td>
                    <td style="width: 341px; text-align: left; height: 2px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 7px;">
                    </td>
                    <td style="width: 53px; text-align: left; height: 7px;">
                    </td>
                    <td style="width: 193px; text-align: left; height: 7px;">
                    </td>
                    <td style="width: 341px; text-align: left; height: 7px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 10px; text-align: center">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-weight: bold;"><span style="text-decoration: underline"><span>POLICY NO:
                                <asp:Literal ID="litpolno4" runat="server"></asp:Literal></span></span></span></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 4px; height: 8px">
                    </td>
                    <td style="width: 53px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 193px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 341px; height: 8px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 4px; height: 19px">
                    </td>
                    <td colspan="3" rowspan="2" style="text-align: justify">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt;">Please send me a cheque by post drawn in favour of my Bank Account
                            detailed below in payment of the amount due to me under the above policy.</span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 6px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td style="width: 53px; height: 10px; text-align: left">
                    </td>
                    <td style="width: 193px; height: 10px; text-align: left">
                    </td>
                    <td style="width: 341px; height: 10px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 10px;">
                    </td>
                    <td colspan="2" style="text-align: left; height: 10px;">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; line-height: 130%; tab-stops: 39.75pt 1.0in 1.5in 2.0in 2.5in 3.0in 3.5in 4.0in 4.5in 437.25pt">
                            <b style="mso-bidi-font-weight: normal"><span><span><span style="font-family: Trebuchet MS">
                                Particulars of the bank Account:<o:p></o:p></span></span></span></b></p>
                    </td>
                    <td style="width: 341px; text-align: left; height: 10px; font-size: 12pt;">
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 8px">
                    </td>
                    <td style="width: 53px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 193px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 341px; height: 8px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-family: Trebuchet MS"><span style="font-family: Times New Roman;">
                                <span style="font-size: 10pt; font-family: Trebuchet MS">1. Name and Place of Bank:
                                    <span style="font-family: Times New Roman">...................................................................<span
                                        style="font-size: 12pt; font-family: 'Times New Roman'">.......</span>..................................................................................</span></span></span></span></span></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span><span><span style="font-family: Trebuchet MS">
                                <span style="font-size: 10pt"><span>2. Bank Account No: <span style="font-family: Times New Roman">
                                    ............................................................................................................................................................................</span></span></span></span></span></span></span></td>
                </tr>
                <tr style="font-weight: bold; font-size: 12pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-weight: normal;"><span
                                style="font-family: Trebuchet MS"><span><span><span style="font-size: 10pt">3. Name
                                    of Account Holder: <span style="font-family: Times New Roman">..............................................................................................................................................................</span></span></span></span></span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <strong style="font-weight: normal"><span style="font-family: Trebuchet MS"><span><span>
                                4. Whether Bank Account is a Current Account or a Savings Account:</span></span></span></strong><span
                                    style="font-family: Times New Roman;"> ..............................................................................</span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <span><span style="font-family: Trebuchet MS"><span>5. <span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span>State Place of Post Office, if pass book obtained from them : <span style="font-family: Times New Roman">
                                ..............................................................................</span></span><span
                                    style="font-family: Times New Roman">........</span></span></span></span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 5px;">
                    </td>
                    <td style="width: 53px; text-align: left; height: 5px;">
                    </td>
                    <td style="width: 193px; text-align: left; height: 5px;">
                    </td>
                    <td style="width: 341px; text-align: left; height: 5px;">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="2" style="height: 9px; text-align: left">
                        <span style="font-family: Trebuchet MS"><span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Cheque to be posted to:</span></span></td>
                    <td style="width: 341px; height: 9px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 10px;">
                    </td>
                    <td colspan="3" style="text-align: left; height: 10px;">
                        <span style="font-family: Trebuchet MS">Name &nbsp;&nbsp; :<span style="font-family: Times New Roman">...................................................................................................................................................................................................</span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 13px">
                    </td>
                    <td colspan="3" style="height: 13px; text-align: left">
                        <span style="font-family: Trebuchet MS">Address :<span style="font-family: Times New Roman">...................................................................................................................................................................................................</span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td colspan="3" style="height: 9px; text-align: left">
                        <span style="font-family: Trebuchet MS"><span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Telephone No : <span style="font-family: Times New Roman">......................................................................................................................................................................................</span></span></span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 4px">
                    </td>
                    <td style="width: 53px; height: 4px; text-align: left">
                    </td>
                    <td colspan="2" style="height: 4px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 7px;">
                    </td>
                    <td style="width: 53px; text-align: left; height: 7px;">
                        <span style="font-family: Trebuchet MS">Date :<span style="font-family: Times New Roman">........................................</span></span></td>
                    <td colspan="2" style="text-align: center; height: 7px; font-family: Times New Roman;">
                        <span>............................................................................</span></td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="width: 4px; height: 9px">
                    </td>
                    <td style="width: 53px; height: 9px; text-align: left">
                    </td>
                    <td colspan="2" style="height: 9px; text-align: center">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Signature</span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 4px; height: 7px;">
                    </td>
                    <td style="width: 53px; text-align: left; height: 7px;">
                    </td>
                    <td style="width: 193px; text-align: right; height: 7px;">
                        <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        </span>
                    </td>
                    <td style="width: 341px; text-align: left; height: 7px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 10px;">
                    </td>
                    <td style="width: 53px; text-align: left; height: 10px;">
                    </td>
                    <td style="width: 193px; text-align: right; height: 10px;">
                        <span style="font-size: 10pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        </span>
                    </td>
                    <td style="width: 341px; text-align: left; height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 4px; height: 17px">
                    </td>
                    <td colspan="3" style="height: 17px; text-align: center; font-size: 9pt; font-family: 'Trebuchet MS';">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp;</td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 4px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 10px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litcurdate5" runat="server"></asp:Literal>
                        &nbsp; &nbsp;<asp:Literal ID="littime5" runat="server"></asp:Literal>
                        &nbsp; &nbsp;<asp:Literal ID="litepf6" runat="server"></asp:Literal>
                        &nbsp; &nbsp;&nbsp;<asp:Literal ID="litipaddr5" runat="server"></asp:Literal>
                        &nbsp; &nbsp; &nbsp;<span style="font-size: 10pt">Form 2812</span></td>
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
        %>
    </form>
</body>
</html>
