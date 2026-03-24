<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntOfDthClmAmountEng001.aspx.cs"  Debug ="true" Inherits="discharge001" %>
<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style type="text/css">
     P.breakhere {page-break-before: always}
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
<body style="text-align: center" onload = "window.print()">
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
                reltype = payeedetArr[2];
                payeeAmt = double.Parse(payeedetArr[3]);
                percentage = double.Parse(payeedetArr[4]);
                affiNomiAssiLPTdat = payeedetArr[5];

             //   this.litpayeename.Text = payeeName;
             //   this.litrel.Text = relationship;
              //  this.litpayeetype.Text = reltype;

              //  this.lblpcntage.Text = String.Format("{0:N}", (double)(percentage * 100)) + "%";
              //  this.lblsharAmt.Text = String.Format("{0:N}", payeeAmt);
                    
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


                this.litlifeAssured.Text = phname;

                double ageUnderStAmt = 0;
                double ageOverStAmt = 0;

                if (ageStatus.Equals("O")) { ageOverStAmt = ageDiffAmt; }
                else if (ageStatus.Equals("U")) { ageUnderStAmt = ageDiffAmt; }

                this.litpolno.Text = polno.ToString();
                
               // this.litDateofDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
               string ComDate = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                this.litclmno.Text = claimno.ToString();
                this.litbonSt.Text = COM.ToString().Substring(0, 4);
              //  if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }               
                this.litbonend.Text = interimBonStYr.ToString();


                int lstbondecyr = int.Parse(interimBonStYr.ToString() + "1231");
                int nxtbonyr = interimBonStYr;
                int yeardiff = this.dateComparison(lstbondecyr, dateofdeath)[0];
                for (int i = 0; i < yeardiff; i++)
                {
                    nxtbonyr = nxtbonyr + 1;
                }
                this.litinbst.Text = interimBonStYr.ToString();
                if (nxtbonyr != interimBonStYr) { this.litintbend.Text = nxtbonyr.ToString(); }
                
                //this.litinbst.Text = interimBonStYr.ToString(); 
                //this.litintbend.Text = polcompleYM.Substring(0, 4);
                this.litageovst.Text = String.Format("{0:N}", ageOverStAmt);
                this.litUnderstated.Text = String.Format("{0:N}", ageUnderStAmt);
                this.litComYr.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2);
                this.litlendYr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2);
                double x = PRM * missingprems;
                this.litInstlments.Text = String.Format("{0:N}", x);
              //  this.litdeceaseName.Text = nameOfDead;
              //  this.litdeceasename2.Text = nameOfDead;
                this.litlifeAssured.Text = phname;

                if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.litVestbon.Text = String.Format("{0:N}", vestedBonus); this.litlintbon.Text = String.Format("{0:N}", interimBonus); }
                else { this.litVestbon.Text = "0.00"; this.litlintbon.Text = "0.00"; }
                if ((ADB > 0) && (!adbLatepay.Equals("Y"))) { this.lbladbStr.Visible = true; this.litAccBene.Visible = true; this.litAccBene.Text = "Rs. " + String.Format("{0:N}", (double)ADB); }
                else { this.lbladbStr.Visible = false; this.litAccBene.Visible = false; }
                if (FPU > 0) { this.lblfpustr.Visible = true; this.litfpu.Visible = true; this.litfpu.Text = "Rs. " + String.Format("{0:N}", (double)FPU); }
                else { this.lblfpustr.Visible = false; this.litfpu.Visible = false; }
                if (FE > 0) { this.lblfestr.Visible = true; this.litfe.Visible = true; this.litfe.Text = "Rs. " + String.Format("{0:N}", (double)FE); }
                else { this.lblfestr.Visible = false; this.litfe.Visible = false; }
                if (SJ > 0) { this.lblsjstr.Visible = true; this.litsj.Visible = true; this.litsj.Text = "Rs. " + String.Format("{0:N}", (double)SJ);  }
                else { this.lblsjstr.Visible = false; this.litsj.Visible = false; }
                //double riderbene = ADB + FPU + FE + SJ;                
                
                this.litLoanAmt.Text = String.Format("{0:N}", loancap);
                this.litLoanIns.Text = String.Format("{0:N}", loanint);
                this.litdefPrem.Text = String.Format("{0:N}", demmands);
                this.litdeflatefee.Text = String.Format("{0:N}", defint);
                this.lblnet.Text = String.Format("{0:N}", netclm);
                this.lblsuminFigures.Text = String.Format("{0:N}", grossClm);
                this.litotheradd.Text = String.Format("{0:N}", otheradd+deposit);
                this.littoadd.Text = String.Format("{0:N}", grossClm);
                this.litOtherDed.Text = String.Format("{0:N}", otherdeuct);
                double lesstotal = demmands + defint + x + loancap + loanint;
                this.litLessTot.Text = String.Format("{0:N}", lesstotal);
              //  this.lblToday.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                this.lblBalance.Text = String.Format("{0:N}", netclm);
                this.litSumassrd.Text = String.Format("{0:N}", sumassured);
              
               
                
         %>    
    <div style="text-align: left">
        <table style="width: 701px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="width: 47px; height: 7px">
                </td>
                <td style="width: 139px; height: 7px">
                </td>
                <td style="width: 43px; height: 7px">
                </td>
                <td style="width: 146px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 47px; height: 6px">
                </td>
                <td style="width: 139px; height: 6px">
                </td>
                <td style="width: 43px; height: 6px">
                </td>
                <td style="width: 146px; height: 6px">
                </td>
            </tr>
            <tr>
                <td style="width: 47px; height: 5px">
                </td>
                <td style="height: 5px; text-align: right;" colspan="2">
                    <strong><span style="font-size: 12pt; font-family: Times New Roman">WITHOUT PREJUDICE
                        &nbsp; </span></strong>
                </td>
                <td style="width: 146px; height: 5px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 8px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="height: 6px; text-align: center;" colspan="4">
                    <strong><span style="font-size: 11pt">Form Of Intimation of Death Claim Amount</span></strong></td>
            </tr>
            <tr>
                <td style="width: 47px; height: 5px">
                </td>
                <td style="width: 139px; height: 5px">
                </td>
                <td style="width: 43px; height: 5px">
                </td>
                <td style="width: 146px; height: 5px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 47px; height: 5px">
                </td>
                <td colspan="2" style="height: 5px; text-align: right">
                    &nbsp;<span style="font-size: 10pt">Claim No. L/Claims/1/<asp:Literal ID="litclmno"
                            runat="server"></asp:Literal>&nbsp; &nbsp; </span>
                </td>
                <td style="width: 146px; height: 5px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 47px; height: 5px">
                </td>
                <td colspan="2" style="height: 5px; text-align: right">
                    &nbsp;Date<asp:Literal ID="litdate" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;</td>
                <td style="width: 146px; height: 5px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="height: 6px; text-align: left;" colspan="2">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 43px; height: 6px">
                </td>
                <td style="width: 146px; height: 6px">
                </td>
            </tr>
            <tr>
                <td style="height: 5px; text-align: left;" colspan="2">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal>
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 43px; height: 5px">
                </td>
                <td style="width: 146px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="height: 5px; text-align: left;" colspan="2">
                    &nbsp;<asp:Literal ID="litad3" runat="server"></asp:Literal>
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 43px; height: 5px">
                </td>
                <td style="width: 146px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="height: 3px; text-align: left;" colspan="2">
                    </td>
                <td style="width: 43px; height: 3px">
                </td>
                <td style="width: 146px; height: 3px">
                </td>
            </tr>
            <tr>
                <td style="height: 4px; text-align: left;" colspan="2">
                    Dear Sir/Madom,</td>
                <td style="width: 43px; height: 4px">
                </td>
                <td style="width: 146px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 47px; height: 2px">
                </td>
                <td style="width: 139px; height: 2px">
                </td>
                <td style="width: 43px; height: 2px">
                </td>
                <td style="width: 146px; height: 2px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 5px; text-align: left;">
                    <span style="font-family: 'Trebuchet MS'; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt; font-weight: bold;">
                        Claim Under Policy No:
                        <asp:Literal ID="litpolno" runat="server"></asp:Literal></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 5px; text-align: left;">
                    <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'; font-weight: bold; text-decoration: underline;">
                        On the life of&nbsp; 
                            <asp:Literal ID="litlifeAssured" runat="server"></asp:Literal>
                            (Deceased)</span></span></td>
            </tr>
            <tr>
                <td style="height: 9px; text-align: justify;" colspan="3">
                We have pleasure in advising
                                you that liability under the above policy had been admitted.Particulars of the
                                amount due are &nbsp;set out &nbsp;below&nbsp; and the sum&nbsp; of
                                <asp:Literal ID="litSumInWords" runat="server"></asp:Literal>(<strong>Rs.</strong><asp:Label ID="lblsuminFigures" runat="server" Font-Bold="True" Width="108px" Font-Size="10pt"></asp:Label>)
                                will be payable to the Nominee/Assignee/Legal hiers.Kindly return the enclosed Discharge Receipt/Affidavit duly perfected.Certificate of clearance of estate duty will be necessary if death had occured prior
                                to November,1985.</td>
                <td style="width: 146px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 5px; text-align: left; font-size: 10pt;">
                    <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        </span><span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;">
                            <table style="width: 602px; font-size: 9pt;">
                                <tr>
                                    <td style="width: 224px; height: 5px;">
                        Sum Assured/Paid up Value-<asp:Literal ID="litsumonexgr" runat="server"></asp:Literal></td>
                                    <td style="width: 5px; text-align: right; height: 5px;">
                                        Rs.</td>
                                    <td style="width: 100px; text-align: right; height: 5px;">
                                        &nbsp;<asp:Literal ID="litSumassrd" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 6px;">
                        Bonus <span style="mso-spacerun: yes">
                           <!-- <asp:Literal ID="litbonSt" runat="server"></asp:Literal>-->
                            <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;">
                                <!--to
                                <asp:Literal ID="litbonend" runat="server"></asp:Literal>--></span></span></td>
                                    <td style="width: 5px; text-align: right; height: 6px;">
                                        Rs.</td>
                                    <td style="width: 100px; text-align: right; height: 6px;">
                                        &nbsp;<asp:Literal ID="litVestbon" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 6px;">
                        Interim Bonus &nbsp;
                    <!--<asp:Literal ID="litinbst" runat="server"></asp:Literal>-->
                                        <span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-family: Trebuchet MS"><!--to--> </span>
                        <!--<asp:Literal ID="litintbend" runat="server"></asp:Literal>--></span></td>
                                    <td style="width: 5px; text-align: right; height: 6px;">
                                        Rs.</td>
                                    <td style="width: 100px; text-align: right; height: 6px;">
                                        &nbsp;
                                        <asp:Literal ID="litlintbon" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 6px">
                        Diff, of Prem. on account of age h<span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA">aving been overstated</span></td>
                                    <td style="width: 5px; height: 6px; text-align: right">
                                        Rs.</td>
                                    <td style="width: 100px; height: 6px; text-align: right">
                                        &nbsp;
                                        <asp:Literal ID="litageovst" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 6px; font-size: 9pt;">
                        <asp:Label ID="lbladbStr" runat="server" Text="Accidental Death Benefits" Visible="False" Width="189px" Font-Size="9pt"></asp:Label></td>
                                    <td style="width: 5px; height: 6px;">
                                    </td>
                                    <td style="width: 100px; text-align: right; height: 6px;">
                                        &nbsp;<asp:Literal ID="litAccBene" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 6px;">
                        <asp:Label ID="lblfpustr" runat="server" Text="Family Protection Units" Visible="False" Width="190px" Font-Size="9pt"></asp:Label></td>
                                    <td style="width: 5px; height: 6px;">
                                    </td>
                                    <td style="width: 100px; text-align: right; height: 6px;">
                                        &nbsp;<asp:Literal ID="litfpu" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 6px;">
                        <asp:Label ID="lblsjstr" runat="server" Text="Swarna Jayanthi Benefits" Visible="False" Width="188px" Font-Size="9pt"></asp:Label></td>
                                    <td style="width: 5px; height: 6px;">
                                    </td>
                                    <td style="width: 100px; text-align: right; height: 6px;">
                                        &nbsp;
                        <asp:Literal ID="litsj" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 4px;">
                        <asp:Label ID="lblfestr" runat="server" Text="Funaral Expenses" Visible="False" Width="184px" Font-Size="9pt"></asp:Label></td>
                                    <td style="width: 5px; height: 4px;">
                                    </td>
                                    <td style="width: 100px; text-align: right; height: 4px;">
                                        &nbsp;<asp:Literal ID="litfe" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 5px; font-size: 9pt;">
                        Other additions 
                        <asp:Label ID="lblothradonExg" runat="server" Width="87px"></asp:Label></td>
                                    <td style="width: 5px; text-align: right; height: 5px;">
                                        Rs.</td>
                                    <td style="width: 100px; text-align: right; height: 5px;">
                                        &nbsp;<asp:Literal ID="litotheradd" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td style="width: 224px; height: 5px;">
                    Gross Claim</td>
                                    <td style="width: 5px; text-align: right; height: 5px;">
                                        Rs.</td>
                                    <td style="width: 100px; text-align: right; height: 5px;">
                                        &nbsp;<asp:Literal ID="littoadd" runat="server"></asp:Literal></td>
                                </tr>
                            </table>
                        </span>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="3" style="height: 2px; text-align: left;">
                    <strong style="font-size: 9pt">Less:</strong></td>
                <td style="width: 146px; height: 2px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 15px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <table style="width: 603px; font-size: 9pt;">
                        <tr>
                            <td style="width: 165px; height: 6px;">
                    Unpaid installment of premium</td>
                            <td style="width: 12px; text-align: right; height: 6px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 6px;">
                                &nbsp;<asp:Literal ID="litdefPrem" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 6px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 6px;">
                    Late Fee on unpaid premium</td>
                            <td style="width: 12px; text-align: right; height: 6px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 6px;">
                                &nbsp;
                                <asp:Literal ID="litdeflatefee" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 6px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 9px;">
                    Installments of premium due to complete <span style="font-family: Trebuchet MS">t</span><span style="font-family: 'Trebuchet MS';
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA; font-size: 10pt;"><span
                            style="font-family: Trebuchet MS">he</span> <span style="font-family: Trebuchet MS">
                                policy year from
                                <asp:Literal ID="litComYr" runat="server"></asp:Literal></span>
                        <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;">
                            <span style="font-family: Trebuchet MS">to </span>
                            <asp:Literal ID="litlendYr" runat="server"></asp:Literal></span></span></td>
                            <td style="width: 12px; text-align: right; height: 9px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 9px;">
                                &nbsp;
                                <asp:Literal ID="litInstlments" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 9px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 5px;">
                                Loan</td>
                            <td style="width: 12px; text-align: right; height: 5px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 5px;">
                                &nbsp;<asp:Literal ID="litLoanAmt" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 3px;">
                    Interest on Loan</td>
                            <td style="width: 12px; text-align: right; height: 3px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 3px;">
                                &nbsp;<asp:Literal ID="litLoanIns" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 3px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 10px;">
                    Difference of Premium or Sum Assured <span style="font-family: 'Trebuchet MS';
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA; font-size: 10pt;">&amp; Bonus on account of age having been <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;">understated</span></span></td>
                            <td style="width: 12px; text-align: right; height: 10px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 10px;">
                                &nbsp;<asp:Literal ID="litUnderstated" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 4px;">
                                Other Deductions</td>
                            <td style="width: 12px; text-align: right; height: 4px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 4px;">
                                &nbsp;
                                <asp:Literal ID="litOtherDed" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 4px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 165px; height: 4px;">
                    Total Deductions</td>
                            <td style="width: 12px; text-align: right; height: 4px;">
                                Rs.</td>
                            <td style="width: 96px; text-align: right; height: 4px;">
                                &nbsp;<asp:Literal ID="litLessTot" runat="server"></asp:Literal></td>
                            <td style="width: 100px; height: 4px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 601px">
                        <tr>
                            <td style="height: 3px;" colspan="2">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Rs.&nbsp;</td>
                            <td style="width: 100px; text-align: left; height: 3px;">
                                &nbsp;
                                <asp:Label ID="lblBalance" runat="server" Width="108px" style="text-align: left"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 5px; direction: ltr; text-align: left;" colspan="2">
                                <asp:Literal ID="Literal1" runat="server" Text="Net Amount payable"></asp:Literal>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; Rs.</td>
                            <td style="width: 42px; text-align: left; height: 5px; text-decoration: underline overline;">
                                &nbsp;
                    <asp:Label ID="lblnet" runat="server" Width="108px" style="text-align: left"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="height: 5px; text-align: left" colspan="2">
                    Your's faithfully,</td>
                <td style="height: 5px; text-align: left" colspan="2">
                    </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="height: 5px; text-align: left" colspan="2">
                    ................................</td>
                <td colspan="2" style="height: 5px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="height: 5px; text-align: left" colspan="2">
                    <strong>For Life Manager</strong></td>
                <td style="height: 5px; text-align: left" colspan="2">
                    <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        </span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="height: 5px; text-align: left;" colspan="2">
                        <asp:Label ID="lblmessage" runat="server" Width="204px" ForeColor="#FF0033"></asp:Label></td>
                <td style="width: 43px; height: 5px; text-align: left">
                </td>
                <td style="width: 146px; height: 5px">
                </td>
            </tr>
        </table>
    <%
        
        }
        
            
        }
        catch (Exception ex) 
        {            
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        if (arrList.Count == 0)
        {
            EPage.Messege = "Please Confirm the payment for a certain payee";
            Response.Redirect("EPage.aspx");
        }
        
         %>
    
    </div>
    </form>
</body>
</html>
