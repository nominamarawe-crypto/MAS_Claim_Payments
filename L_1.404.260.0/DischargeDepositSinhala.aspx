<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DischargeDepositSinhala.aspx.cs" Inherits="DischargeDepositSinhala" %>

<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <style type="text/css">
     P.breakhere {page-break-before: always}
     @font-face {
    font-family: "Sandaya";
    src: url("fonts/SANDHYA.woff2");
    src: local("Sandaya"),url("fonts/SANDHYA.woff2"),url("fonts/SANDHYA.ttf"),url("fonts/SANDHYA.woff"),url("fonts/SANDHYA.eot"),url("fonts/SANDHYA.svg");
    font-weight: normal;
    font-style: normal;
}
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
    .break{page-break-before:always}
    </style>
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
            
            this.LitpayeeName.Text = payeeName;
            if (relationship == "Son")
            {
                this.Litrel.Text = "mq; d";
            }
            if (relationship == "Daughter")
            {
                this.Litrel.Text = "oshKsh";
            }
            if (relationship == "Spouce")
            {
                this.Litrel.Text = "iylre$ldrsh";
            }
            if (relationship == "Brother")
            {
                this.Litrel.Text = "ifydaorhd";
            }
            if (relationship == "Sister")
            {
                this.Litrel.Text = "ifydaorsh";
            }
            if (relationship == "Mother")
            {
                this.Litrel.Text = "uj";
            }
            if (relationship == "Father")
            {
                this.Litrel.Text = "mshd";
            }
            this.LitPayeeType.Text = reltype;

            //this.lblpcntage.Text = String.Format("{0:N}", (double)(percentage )) + "%";
            //this.litshareamt.Text = String.Format("{0:N}", (double)payeeAmt);
            
            double netclm100 = 0;
            if (netclm < 0) { netclm100 = 0; }
            else { netclm100 = (Math.Round(deposit, 2) * 100); }
            if (netclm100 != 0)
            {
                string netclminwords = netclm100.ToString().Substring(0, (netclm100.ToString().Length - 2)) + "." + netclm100.ToString().Substring((netclm100.ToString().Length - 2), 2);
                readAmountFunction readamt = new readAmountFunction();
                this.LitSumInWords.Text = readamt.readAmountSinhala(netclminwords, "YS% ,xld remsh,a", "Y; ");
            }
            else
            {
                this.LitSumInWords.Text = "ZERO SRI LANKAN RUPEES AND ZERO CENTS ONLY";
            }

            this.litLifeassured.Text = phname;

            double ageUnderStAmt = 0;
            double ageOverStAmt = 0;

            if (ageStatus.Equals("O")) { ageOverStAmt = ageDiffAmt; }
            else if (ageStatus.Equals("U")) { ageUnderStAmt = ageDiffAmt; }
            
            this.litpolno.Text = polno.ToString();
            Ltpolno.Text = polno.ToString();
            //this.lblpolno4.Text = polno.ToString();
            this.LitDateOfDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
            this.LitIDCo.Text = COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
            this.litclmno.Text = claimno.ToString();
            //this.LitbonSt.Text = COM.ToString().Substring(0, 4);
            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.lblbonend.Text = interimBonStYr.ToString(); this.lblinbst.Text = interimBonStYr.ToString(); }
            //this.litbonend.Text = interimBonStYr.ToString();
            //this.litlinbst.Text = interimBonStYr.ToString();
            //this.litintbend.Text = polcompleYM.Substring(0, 4);
            //this.litageovest.Text = String.Format("{0:N}", ageOverStAmt);
            //this.litunderstated.Text = String.Format("{0:N}", ageUnderStAmt);
            //this.litComYr.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2);
            //this.litendYr.Text = polcompleYM.Substring(0, 4) + "/" + polcompleYM.Substring(4, 2);
            double x = PRM * missingprems;
            //this.Litinstlments.Text = String.Format("{0:N}", x);
            this.LitDeceasedName.Text = nameOfDead;
            this.litLifeassured.Text = phname;
            //this.litLifeAssured2.Text = phname;

            //if (TBL != 34 && TBL != 38 && TBL != 39 && TBL != 46 && TBL != 49) { this.litvestbon.Text = String.Format("{0:N}", vestedBonus); this.litintbon.Text = String.Format("{0:N}", interimBonus); }
            //else { this.litvestbon.Text = "0.00"; this.litintbon.Text = "0.00"; }
            //if (ADB > 0) { this.lbladbStr.Visible = true; }
            //if (FPU > 0) { this.lblfpustr.Visible = true; }
            //if (FE > 0) { this.lblfestr.Visible = true; }
            //if (SJ > 0) { this.lblsjstr.Visible = true; }
            double riderbene = ADB;    
            //+ FE + SJ;
            //if (FPU > 0)
            //{ this.litFPU.Text = String.Format("{0:N}", FPU);}
            //else { this.litFPU.Text = "0.00"; }
            //if (riderbene > 0) { this.LitAccBene.Text = String.Format("{0:N}", (double)riderbene); }
            //else { this.LitAccBene.Text = "0.00"; }
            //if (SJ > 0) { this.litsjamt.Text = String.Format("{0:N}", (double)SJ); }
            //else { this.litsjamt.Text = "0.00"; }
            //if (FE > 0) { this.litfeamt.Text = String.Format("{0:N}", (double)FE); }
            //else { this.litfeamt.Text = "0.00"; }
          
            //this.litLoanAmt.Text = String.Format("{0:N}", loancap);
            //this.litLoanInt.Text = String.Format("{0:N}", loanint);
            //this.LitDefPrem.Text = String.Format("{0:N}", demmands);
            //this.LitDefLatefee.Text = String.Format("{0:N}", defint);
            //this.litnet.Text = String.Format("{0:N}", netclm);
            this.litSumInFigures.Text = String.Format("{0:N}", deposit);
            //this.LitotherAdd.Text = String.Format("{0:N}", otheradd);
            //this.LittotAdd.Text = String.Format("{0:N}", grossClm);
            //this.LitOtherDed.Text = String.Format("{0:N}", otherdeuct);
            double lesstotal = demmands + defint + x + loancap + loanint;
            //this.litLessTot.Text = String.Format("{0:N}", lesstotal);
            //this.lblToday.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            //this.litbalance.Text = String.Format("{0:N}", netclm);
            //this.LitSumassed.Text = String.Format("{0:N}", sumassured);

            this.litpolno.Text = polno.ToString();
            //this.lblcurdate5.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            //this.lbltime5.Text = this.setDate()[1];
            //this.lblipaddr5.Text = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            //this.lblclmno2.Text = claimno.ToString();
            //this.lblepf6.Text = epf;
            if (int.Parse(affiNomiAssiLPTdat) > 9999999)
            {
                this.litDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
            }
         %>
         
    <div>
        <table style="width: 664px">
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
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                        <span style="font-size: 10pt; font-family: Trebuchet MS; text-align: right;"></span></p>
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
                <td style="width: 100px; height: 21px; text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">&nbsp;LI/DC/FO/SE/16</span></td>
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
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="5" style="height: 21px">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center;
                        tab-stops: 120.75pt">
                        <b style="mso-bidi-font-weight: normal"><u><span style="font-family: Trebuchet MS">
                            <span style="font-family: Sandaya">wxl</span> </span>
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal><span style="font-family: Trebuchet MS"> </span></u></b><b style="mso-bidi-font-weight: normal"><u>
                                    <span style="font-family: Sandaya"><span>orK Tmamqfjz ;ekam;a
                                        .sKqfuz we;s uqo,a wdmiq f.jSu<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                            prefix="o" ?><o:p></o:p></span></span></u></b></p>
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
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: right">
                    <span style="font-size: 11pt; font-family: Sandaya; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'">wfma fhduqj(cS$ys$1$<span style="font-size: 10pt;
                            font-family: Trebuchet MS"><asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></td>
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
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="5" style="height: 20px; text-align: center">
                    <span style="font-family: Trebuchet MS"><span style="font-size: 11pt">&nbsp;<span
                        style="text-decoration: underline">
                        <asp:Literal ID="litLifeassured" runat="server"></asp:Literal></span></span></span><span
                            style="text-decoration: underline"><span style="font-family: Trebuchet MS"> </span>
                            <span style="font-family: Sandaya">f.a</span></span><span style="mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                mso-bidi-font-family: 'Times New Roman'"><span><span style="font-size: 11pt"><span
                                    style="font-family: Trebuchet MS"><span style="font-family: Sandaya; text-decoration: underline">
                                        cSjs;h </span><u><span style="font-family: Sandaya">ms&lt;sn|j</span><asp:Literal
                                            ID="LitIDCo" runat="server"></asp:Literal>&nbsp; &nbsp;<span style="font-family: Sandaya">
                                                <span style="font-size: 11pt">osk orK Tmamqjhs</span></span> &nbsp;&nbsp; </u>
                                </span></span></span></span>
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
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="5" style="font-size: 10pt; height: 21px; text-align: justify;">
                    <span style="line-height: 20pt; font-family: Sandaya; text-align: justify">by; ku i|yka<span
                        style="font-size: 10pt; font-family: Trebuchet MS">&nbsp;
                        <asp:Literal ID="LitDeceasedName" runat="server"></asp:Literal>&nbsp; <span style="font-size: 10pt;
                            font-family: Sandaya">^ush.sh whf.a iuzmQrAK ku&amp;
                            <asp:Literal ID="Litrel" runat="server"></asp:Literal>&nbsp; <span style="font-size: 10pt;
                                line-height: 20pt; font-family: Sandaya; text-align: justify">^ush.sh whg we;s kEluz
                                fyda whs;sjdisluz i|yka lrkak</span><span style="font-family: Times New Roman">.</span><span
                                    style="font-size: 10pt; font-family: 'Trebuchet MS'"><span style="font-size: 10pt;
                                        font-family: 'Trebuchet MS'"><span style="font-family: Sandaya">&amp; &nbsp; jk uu</span><asp:Literal
                                            ID="LitpayeeName" runat="server"></asp:Literal>
                                        &nbsp;&nbsp;<span style="font-family: Sandaya">^iuzmQrAK ku i|yka lrkak<span>&amp;
                                            <span style="font-size: 10pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                mso-bidi-font-family: 'Times New Roman'">fj;<span style="font-size: 10pt; line-height: 20pt;
                                                    font-family: Trebuchet MS; text-align: justify">
                                                    <asp:Literal ID="litDated" runat="server"></asp:Literal>
                                                    <span style="font-size: 10pt; font-family: Sandaya">od;u hgf;a m%odkh lrk ,o<span
                                                        style="font-size: 10pt; font-family: Trebuchet MS">
                                                        <asp:Literal ID="LitPayeeType" runat="server"></asp:Literal>
                                                        <span style="font-family: Sandaya">m%ldr mQrAfjdala;<span style="font-size: 11pt">&nbsp;
                                                            <span style="font-size: 10pt; text-align: justify">Tmamqfjz ku i|ykaj <span style="font-size: 10pt;
                                                                font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                                                <span style="font-family: Sandaya">we;a;djqo <span style="font-size: 10pt; font-family: Trebuchet MS">
                                                                    <asp:Literal ID="LitDateOfDeath" runat="server"></asp:Literal>&nbsp; <span style="font-family: Sandaya">
                                                                        jeks osk ush.<u>s</u>hdjqo<span style="font-family: Trebuchet MS"> </span><span style="font-size: 11pt"> <span style="font-size: 10pt">
                                                                            wxl </span><span style="font-family: Trebuchet MS">
                                                                                <asp:Literal ID="Ltpolno" runat="server"></asp:Literal><span style="font-size: 10pt">
                                                                                    &nbsp; &nbsp;<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                        mso-bidi-font-family: 'Times New Roman'">o</span><span style="font-size: 10pt; font-family: Sandaya;
                                                                                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                                            mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">rK rl<b style="mso-bidi-font-weight: normal">aI</b>K
                                                                                            Tmamqj hgf;a ;ekam;a .sKqfuz we;s iuzmQrAK uqo, jq<asp:Literal ID="LitSumInWords"
                                                                                                runat="server"></asp:Literal>
                                                                                            &nbsp; &nbsp; &nbsp; <span style="font-family: Trebuchet MS">( </span>
                                                                                            <span style="font-size: 10pt; font-family: Sandaya">re(<span style="font-size: 10pt;
                                                                                                font-family: Trebuchet MS"><asp:Literal ID="litSumInFigures" runat="server"></asp:Literal>
                                                                                                &nbsp; </span><span style="font-size: 10pt; font-family: Trebuchet MS">)
                                                                                                    &nbsp;</span><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                        mso-bidi-font-family: 'Times New Roman'">la <span style="line-height: 15pt; font-family: Sandaya;
                                                                                                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                                                            mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">jq <span style="font-size: 10pt;
                                                                                                                font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                                                                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                                                                                                uqo,la YS% ,xld bkaIqjrkaia fldamfrAIka ,hs*a ,susgvz fj;ska <span style="mso-spacerun: yes">&nbsp;</span>,nd.;a
                                                                                                                nj fuhska m%ldY lrus</span><span style="font-size: 11pt; line-height: 20pt; font-family: 'Times New Roman';
                                                                                                                    text-align: justify; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                                                                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA">.</span></span></span><span
                                                                                                                        style="mso-spacerun: yes"></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="font-size: 10pt; width: 100px; font-family: 'Trebuchet MS'; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
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
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: center">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">.............................</span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td colspan="3" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right; tab-stops: 241.5pt">
                        <span style="font-size: 10pt; font-family: Sandaya">^ysusluz lshkakd$lshkakshf.a f.a
                            w;aik uqoaorh u; ;ensh hq;=hs&amp;</span></p>
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
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="5" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left;">
                        <span style="font-size: 10pt; font-family: Sandaya">iudodk jsksYajhldr;=udf.a$ufyaia;%d;a;=udf.a
                        </span><span style="font-size: 10pt; font-family: Sandaya">osjzreuz flduidrsia;=udf.a
                            w;aik<o:p></o:p></span></p>
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
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'">ku</span></td>
                <td colspan="4" style="font-size: 12pt; height: 21px; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">:................................................................................................</span></td>
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
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px; text-align: left;">
                    <span style="font-size: 10pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'">,smskh</span></td>
                <td colspan="4" style="height: 21px; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">:.................................................................................................</span></td>
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
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 21px; text-align: left;">
                    <span style="font-size: 10pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'">oskh</span></td>
                <td colspan="2" style="font-size: 12pt; font-family: 'Trebuchet MS'; height: 21px; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">:................</span></td>
                <td style="font-size: 12pt; width: 100px; height: 21px">
                </td>
                <td style="font-size: 12pt; width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="font-size: 10pt; width: 100px; font-family: 'Trebuchet MS'; height: 17px;
                    text-align: center">
                    <span style="font-family: Trebuchet MS">....................</span></td>
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
                <td style="width: 100px; height: 21px; text-align: center">
                    <span style="font-size: 10pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'">ks,uq\%dj</span></td>
            </tr>
        </table>
         <p class="break"></p> 
        
        <%
        
        }
        
        }
         catch (Exception ex) 
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        
         %>
    
    </div>
    </form>
</body>
</html>
