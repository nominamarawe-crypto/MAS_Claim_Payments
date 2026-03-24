<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DischargeDeposit.aspx.cs" Inherits="Discharge2511_English" %>

<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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

                this.litpayeename.Text = payeeName;
                //this.litrel.Text = relationship;
                //this.litpayeetype.Text = reltype;

                //this.lblpcntage.Text = String.Format("{0:N}", (double)(percentage)) + "%";
               // this.lblsharAmt.Text = String.Format("{0:N}", payeeAmt);
                    
                double netclm100 = 0;
                if (netclm < 0) { netclm100 = 0; }
                else { netclm100 = (Math.Round(deposit, 2) * 100); }
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

                if (ageStatus!=null && ageStatus.Equals("O")) { ageOverStAmt = ageDiffAmt; }
                else if (ageStatus != null && ageStatus.Equals("U")) { ageUnderStAmt = ageDiffAmt; }

                this.litpolno.Text = polno.ToString();
                
                //this.litDateofDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                //this.litlDCO.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                this.litclmno.Text = claimno.ToString();
                //litref.Text = claimno.ToString();
                //this.litbonSt.Text = COM.ToString().Substring(0, 4);
                //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }               
                //this.litbonend.Text = interimBonStYr.ToString();
                //this.litinbst.Text = interimBonStYr.ToString();
               // if (polcompleYM != null) { this.litintbend.Text = polcompleYM.Substring(0, 4); }
                //this.litageovst.Text = String.Format("{0:N}", ageOverStAmt);
                //this.litUnderstated.Text = String.Format("{0:N}", ageUnderStAmt);
                //this.litComYr.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2);
                //if (polcompleYM != null) { this.litlendYr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2); }
                double x = PRM * missingprems;
                //this.litInstlments.Text = String.Format("{0:N}", x);
                this.litdeceaseName.Text = nameOfDead;
                this.litdeceasename2.Text = nameOfDead;
                this.litlifeAssured.Text = phname;

                //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.litVestbon.Text = String.Format("{0:N}", vestedBonus); this.litlintbon.Text = String.Format("{0:N}", interimBonus); }
                //else { this.litVestbon.Text = "0.00"; this.litlintbon.Text = "0.00"; }
                //if ((ADB > 0) && (!adbLatepay.Equals("Y"))) { this.lit1.Visible = true; this.lbladbStr.Visible = true; this.litAccBene.Visible = true; this.litAccBene.Text = String.Format("{0:N}", (double)ADB); }
                //else { this.lit1.Visible = false; this.lbladbStr.Visible = false; this.litAccBene.Visible = false; }
                //if (FPU > 0) { this.lit2.Visible = true; this.lblfpustr.Visible = true; this.litfpu.Visible = true; this.litfpu.Text =  String.Format("{0:N}", (double)FPU); }
                //else { this.lit2.Visible = false; this.lblfpustr.Visible = false; this.litfpu.Visible = false; }
                //if (FE > 0) { this.lit4.Visible = true; this.lblfestr.Visible = true; this.litfe.Visible = true; this.litfe.Text =String.Format("{0:N}", (double)FE); }
                //else { this.lit4.Visible = false; this.lblfestr.Visible = false; this.litfe.Visible = false; }
                //if (SJ > 0) { this.lit3.Visible = true; this.lblsjstr.Visible = true; this.litsj.Visible = true; this.litsj.Text =String.Format("{0:N}", (double)SJ); }
                //else { this.lit3.Visible = false; this.lblsjstr.Visible = false; this.litsj.Visible = false; }
                //double riderbene = ADB + FPU + FE + SJ;                
                
                //this.litLoanAmt.Text = String.Format("{0:N}", loancap);
                //this.litLoanIns.Text = String.Format("{0:N}", loanint);
                //this.litdefPrem.Text = String.Format("{0:N}", demmands);
               // this.litdeflatefee.Text = String.Format("{0:N}", defint);
               // this.lblnet.Text = String.Format("{0:N}", netclm);
                this.lblsuminFigures.Text = "(Rs." + String.Format("{0:N}", deposit) + ")";
               // this.litotheradd.Text = String.Format("{0:N}", otheradd);
               // this.littoadd.Text = String.Format("{0:N}", grossClm);
               // this.litOtherDed.Text = String.Format("{0:N}", otherdeuct);
                //double lesstotal = demmands + defint + x + loancap + loanint;
               // this.litLessTot.Text = String.Format("{0:N}", lesstotal);
              //  this.lblToday.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
               // this.lblBalance.Text = String.Format("{0:N}", netclm);
               // this.litSumassrd.Text = String.Format("{0:N}", sumassured);

                //this.litref.Text = epf;
                //this.litpolno4.Text = polno.ToString();
                //this.litcurdate5.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                //this.littime5.Text = this.setDate()[1];
                //this.litipaddr5.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                //this.litepf6.Text = epf;
                //if (int.Parse(affiNomiAssiLPTdat) > 9999999)
                //{
                //    this.litDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                //}
                
         %>    
    <div>
        <table style="width: 661px">
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'">LI/DC/FO/SE/16<?xml namespace=""
                            ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></p>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: center">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="3" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <b style="mso-bidi-font-weight: normal"><u><span style="font-size: 13pt; font-family: 'Trebuchet MS'">
                            DEPOSIT REFUND</span></u></b></p>
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; text-align: left;">
                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Our Ref: L/Claims/1/<asp:Literal ID="litclmno" runat="server"></asp:Literal></span></td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; text-align: left;">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <strong style="font-size: 10pt; font-family: 'Trebuchet MS'">Discharge of Policy No
                            :
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></strong></span></td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; text-align: left;">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <strong style="font-size: 10pt; font-family: 'Trebuchet MS'">On the life of :
                            <asp:Literal ID="litdeceaseName" runat="server"></asp:Literal></strong></span></td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="8" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 22px;
                    text-align: justify">
                    <span style="font-family: Trebuchet MS">
                    I, </span>
                    <asp:Literal ID="litpayeename" runat="server"></asp:Literal><span style="font-family: Trebuchet MS">
                    , </span><span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="font-family: Trebuchet MS">
                        widow of the life assured </span>
                        <asp:Literal ID="litlifeAssured" runat="server"></asp:Literal><span style="font-family: Trebuchet MS">
                            </span>
                        <span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; line-height: 20pt; text-align: justify;">
                            <span style="font-family: Trebuchet MS">
                            do hereby acknowledge receipt from the above named corporation, the sum of Rupees </span>
                            <asp:Literal ID="litSumInWords" runat="server"></asp:Literal><span style="font-family: Trebuchet MS">
                            <span></span></span>
                            <asp:Label
                                ID="lblsuminFigures" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                                Font-Size="10pt" Width="108px"></asp:Label><span style="font-family: Trebuchet MS">
                                </span><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                    mso-bidi-language: AR-SA; line-height: 16pt; text-align: justify;">
                                    <span style="font-family: Trebuchet MS">being the amount in deposit of the above mentioned policy
                                    in full satisfaction and discharge of all my claims and demands under the above
                                    policy on the life of therein mentioned </span>
                                    <asp:Literal ID="litdeceasename2" runat="server"></asp:Literal><span style="font-family: Trebuchet MS">
                                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; line-height: 20pt; text-align: justify;">
                                        and which policy is hereby delivered up to the said Corporation to be cancelled.</span></span></span></span></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="8" style="height: 20px; text-align: left;">
                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Dated at......................this.......................day of.....................20..................</span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: right; font-size: 10pt; font-family: 'Trebuchet MS';">
                    ...........................</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td colspan="2" style="height: 19px; text-align: right; font-size: 10pt; font-family: 'Trebuchet MS';">
                    Signature of Declaring</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 139px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="8" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                        Signature of Justice of peace/Magistrate/Commissioner of Oaths</p>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="8" style="height: 21px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    Name.................................................................................</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 139px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="8" style="height: 21px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    Address..............................................................................</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: right; font-size: 10pt; font-family: 'Trebuchet MS';">
                    ...................</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: right; font-size: 10pt; font-family: 'Trebuchet MS';">
                    Official Seal</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 139px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
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
        
        
         %>
    </form>
</body>
</html>
