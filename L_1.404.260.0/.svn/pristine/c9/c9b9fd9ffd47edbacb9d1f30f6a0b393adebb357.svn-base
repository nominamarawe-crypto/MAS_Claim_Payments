<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBDischargeEng001.aspx.cs" Inherits="ADBDischargeEng001" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/ADBApproveMemo002.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

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
                     
 
                     
                    double netclm100 = 0;
                    if (payeeAmt < 0) { netclm100 = 0; }
                    else { netclm100 = (Math.Round(payeeAmt, 2) * 100); }
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
                    this.lblsuminFigures.Text = String.Format("{0:N}", payeeAmt);
                    //==============================================================
                    string Fulname = "";
                    string status = "";
                    DataManager dthintobj = new DataManager();


                    string polpersonalSel = "";
                    polpersonalSel = "select fullname,STATUS,SURNAME from LUND.POLPERSONAL where polno = " + polNo + " and PRPERTYPE = 1 ";
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

                    if (tbl == 34 || tbl == 38 || tbl == 39 || tbl == 46 || tbl == 49)
                    {
                        //===============================================================
                        DataManager dm = new DataManager();
                        int cvrno = 0;
                        string ChildFname = "";
                        string ChildStts = "";
                        string SelectAllcvrs = "select PRPERTYPE,FULLNAME,STATUS from lund.polpersonal where POLNO=" + polNo + "";
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
                        string Selectcvr = "select FULLNAME,STATUS from lund.polpersonal where PRPERTYPE=2 and POLNO=" + polNo + "";
                        string ChkCvr_SP = "select RCOVR from lund.rcover where RPOL=" + polNo + " and RCOVR=101";
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
                        #endregion
                        else
                        {
                            this.litlifeAssured.Text = status + Fulname;// +" & " + Fullname; ;
                        }
                    } 

                    this.litclmno.Text = claimNo.ToString();
                    this.litpolno.Text = polNo.ToString();

                    this.litDateofDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);

                    this.litdeceaseName.Text = nameOfDth;
                    this.litdeceasename2.Text = nameOfDth;
                    
                    if (tbl == 34 || tbl == 38 || tbl == 39 || tbl == 46 || tbl == 49)
                    {
                        if (mos == "2")
                        {
                            this.litdeceasename2.Text = nameOfDth;
                        }
                        
                        if ((mos == "M" || mos == "S") && (recipient == "SL"))
                        {
                            litpayeetype.Text = "Proposal";
                        }

                    }
                    if (mos == "S")
                    {
                        litpayeetype.Text = "Proposal";
                    }

                    if (tbl == 14)
                    {
                        litpayeetype.Text = "Proposal";
                    }
                    DataManager defObj = new DataManager();

                    if (litpayeetype.Text.ToUpper() == "PROPOSAL")
                    {
                        string getpropdt = "select PRDATE from lund.promast where POLNO=" + polNo + "";
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
                     
                     
                    if (int.Parse(affiNomiAssiLPTdat) > 9999999)
                    {
                        TxtDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                        // this.litDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
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
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"></span></td>
                    <td style="height: 9px; text-align: right" colspan="7">
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            &nbsp; &nbsp; <span>Our Ref: L/Claims/1/<asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 8px" colspan="9">
                    </td>
                </tr>
                
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 10px; text-align:left">
                        <span style="font-family: 'Trebuchet MS'; text-decoration: underline; mso-fareast-font-family: 'Trebuchet MS';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            font-size: 10pt; font-weight:bold;">DISCHARGE OF POLICY NO.
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></span></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 9px; text-align: left;">
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Trebuchet MS'; font-size: 11pt; text-decoration:underline; font-weight:bold;
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-size: 10pt; font-family: 'Trebuchet MS'; ">On the life of&nbsp;
                                <asp:Literal ID="litlifeAssured" runat="server"></asp:Literal></span>&nbsp;
                            <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                font-size: 10pt;"><span style="font-size: 10pt">(Deceased)</span>
                                <%--<asp:Literal ID="litlDCO" runat="server"></asp:Literal>--%> </span></span></td>
                </tr>
                 <tr style="font-size: 10pt">
                    <td style="height: 8px" colspan="9">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="9" style="height: 15px; text-align: justify;  line-height:22px; padding-top:15px;">
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
                                        Visible="true" Width="81px"></asp:TextBox>. Do
                                    hereby acknowledge receipt from the above mentioned Company of the sum
                                    of
                                    <asp:Literal ID="litSumInWords" runat="server"></asp:Literal>(<strong>Rs.</strong><asp:Label
                                        ID="lblsuminFigures" runat="server" Font-Bold="True" Font-Size="10pt"></asp:Label>)
                                        being <span style="font-size: 10pt; font-weight:bold; font-family: 'Trebuchet MS';">Accidental Death Benefit</span> <asp:Label ID="lbladbStr" runat="server" Text="on exgratia basis " Visible="false" Font-Size="10pt"></asp:Label> under the above-mentioned policy  in full satisfaction  
                                        and discharge of all my claims and demands under the above
                                        policy on the life of therein mentioned
                                <asp:Literal ID="litdeceasename2" runat="server"></asp:Literal>
                                who died on
                                <asp:Literal ID="litDateofDeath" runat="server"></asp:Literal>
                                and which policy is hereby delivered up to the said Company to be cancelled.</span></span></span></span></td>
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
                            <span style="font-size: 10pt; font-family: 'Trebuchet MS';">Dated at
                                .................. this ..............day of .............. 20..........</span></span></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; width: 400px; height: 8px; text-align: left">
                    </td>
                    <td colspan="6" style="font-size: 10pt; height: 8px; text-align: right">
                    </td>
                </tr>
                     
                <tr style="font-size: 10pt">
                    <td colspan="9" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 9px; text-align: left" colspan="3">
                        </td>
                    <td style="height: 9px; text-align: center" colspan="7">
                        ................................................. &nbsp;
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 47px; height: 8px; text-align: left">
                    </td>
                    <td style="width: 453px; height: 8px">
                    </td>
                    <td style="width: 461px; height: 8px; text-align: right">
                    </td>
                    <td style="height: 8px; text-align: center" colspan="6">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"> Signature of Claimant</span></td>
                </tr>
                 <tr style="font-size: 10pt">
                    <td colspan="9" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                 <tr style="font-size: 10pt">
                    <td colspan="9" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                   <tr>
                    <td style="height: 10px" colspan="5">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center; width:275px">
                            <span style="font-family: Trebuchet MS"><span style="width:75px"> Signature of Justice of Peace/Magistrate/
              Commissioner of oaths</span>
</span></p>
                    </td>
                    <td style="height: 10px; text-align: left" colspan="4">
                        &nbsp; </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td colspan="9" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 10px; text-align: left;" colspan="5">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Name <span style="font-family: Times New Roman">.....................................................................................</span></span></td>
                    <td style="height: 10px; text-align: left; font-size: 10pt; font-family: Times New Roman;"
                        colspan="4">
                    </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 10px; text-align: left;" colspan="5">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Address &nbsp; &nbsp; <span style="font-family: Times New Roman">.......................................................................................</span></span></td>
                    <td style="height: 10px; text-align: left; font-family: Times New Roman;" colspan="4">
                         </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 9px; text-align: left;" colspan="5">
                        .............................................................................................................</td>
                    <td style="height: 9px; text-align: right" colspan="4">
                       </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 7px; text-align: left;" colspan="5">
                        .............................................................................................................</td>
                    <td style="height: 7px; text-align: right" colspan="4">
                        </td>
                </tr>
                <tr style="font-size: 10pt; font-family: Times New Roman;">
                    <td style="height: 9px" colspan="5">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        </span>
                    </td>
                    <td style="height: 9px; text-align: left" colspan="4">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="height: 10px; text-align: left;" colspan="5">
                        <span style="font-family: Trebuchet MS">Official Seal <span style="font-family: Times New Roman">
                            ....................................................................................</span></span></td>
                    <td style="height: 10px; text-align: left; font-family: Times New Roman;" colspan="4">
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
                
        %>
    </form>
</body>
</html>
