<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reinsLetter003.aspx.cs" Inherits="reinsLetter003" %>
<%@ PreviousPageType VirtualPath="~/reinsLetter002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

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
    
  function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}    
</script>
</head>
<body style="text-align: center" onload = "window.print()" >
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 637px">
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td style="width: 74px; height: 20px">
                </td>
                <td style="width: 256px; height: 20px">
                </td>
                <td style="width: 84px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Registered Post</span></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Our Ref: Life/Claim/1/<asp:Label ID="lblclmno" runat="server" Font-Bold="False" Font-Size="12pt"
                            Font-Underline="False" Width="90px"></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; text-decoration: none">
                    <asp:Label ID="lbldate" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="90px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; text-decoration: none">
                    <asp:Label ID="lblName" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="302px"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: normal; font-size: 11pt; width: 15px; height: 16px; text-decoration: none">
                </td>
                <td colspan="3" style="font-weight: normal; font-size: 11pt; width: 15px; height: 16px;
                    text-align: left; text-decoration: none">
                    <asp:Label ID="lblAd1" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="302px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 15px">
                </td>
                <td colspan="3" style="height: 15px; text-align: left">
                    <asp:Label ID="lblAd2" runat="server" Width="302px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <asp:Label ID="lblAd3" runat="server" Width="302px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <asp:Label ID="lblAd4" runat="server" Width="302px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        Dear Sir/Madam,</p>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 7px">
                </td>
                <td colspan="3" style="vertical-align: top; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <span style="text-decoration: underline"><strong>Policy No: </strong></span>
                        <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Font-Size="12pt" Width="90px"></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                    <strong><span style="text-decoration: underline"><span style="font-size: 12pt; font-family: 'Times New Roman';
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">Sum Assured : </span></span></strong>
                    <asp:Label ID="lblsumassured" runat="server" Font-Bold="True" Font-Size="12pt" Width="90px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <span style="text-decoration: underline"><strong><span style="font-size: 12pt; font-family: 'Times New Roman';
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA">Life Assured : </span></strong></span>
                        <asp:Label ID="lblLifeAssured" runat="server" Font-Bold="True" Font-Size="12pt" Width="302px"></asp:Label><span
                            style="font-size: 12pt; font-family: 'Times New Roman'; text-decoration: underline;
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA"><strong>(Decd)</strong></span></span></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: justify">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        Consequent<span style="mso-spacerun: yes">&nbsp; </span>of the death of the above
                        life assured on
                        <asp:Label ID="lbldtofdth" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                            Width="90px"></asp:Label>
                        We have admitted liability for
                        <asp:Label ID="lblliability" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                            Width="90px"></asp:Label>
                        amounting Rs.
                        <asp:Label ID="lblnetclm" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                            Width="90px"></asp:Label>
                        under the above policy.</p>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 12px">
                </td>
                <td colspan="3" style="height: 12px; text-align: justify">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        The amount recoverable under the
                        <asp:Label ID="lblrecover" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                            Width="90px"></asp:Label>
                        in this connection amounts to Rs.<asp:Label ID="lblamtsto" runat="server" Font-Bold="False"
                            Font-Size="12pt" Font-Underline="False" Width="90px"></asp:Label>
                        Our Actuarial Department will recover this amount from you by 
                        <asp:Label ID="lblrecoverby" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                            Width="90px"></asp:Label>
                        accounts statement and will send you in due course.</span></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: justify">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        Certified copies of the following documents are sent herewith for your information.</p>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                    &nbsp; &nbsp; &nbsp; 1.
                    <asp:Label ID="lblcopy1" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="300px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: justify">
                    &nbsp; &nbsp; &nbsp; 2.
                    <asp:Label ID="lblcopy2" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="300px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                    &nbsp; &nbsp; &nbsp; 3.
                    <asp:Label ID="lblcopy3" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="300px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                    &nbsp; &nbsp; &nbsp; 4.
                    <asp:Label ID="lblcopy4" runat="server" Font-Bold="False" Font-Size="12pt" Font-Underline="False"
                        Width="300px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            Thanking you</span>,</p>
                </td>
                <td style="width: 84px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        Yours <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            faithfully</span>,</p>
                </td>
                <td style="width: 84px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left">
                </td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <?xml namespace="" prefix="ST1" ?><?xml namespace="" prefix="ST1" ?><st1:country-region></st1:country-region><st1:place></st1:place><b style="mso-bidi-font-weight: normal"><span style="font-size: 14pt">Sri Lanka</span></b>
                        <b style="mso-bidi-font-weight: normal"><span style="font-size: 14pt">Insurance Corporation Life Ltd</span></b>
                        ,</p>
                </td>
                <td style="width: 84px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left">
                </td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left">
                </td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal">For Life Manager.<?xml namespace="" prefix="O" ?><o:p></o:p></b></p>
                </td>
                <td style="width: 84px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px">
                </td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 18px">
                </td>
                <td colspan="1" style="width: 74px; height: 18px; text-align: left">
                </td>
                <td colspan="2" style="height: 18px; text-align: left">
                </td>
            </tr>
        </table>
    
    </div>
        <br /><p class="breakhere" />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 491pt; border-collapse: collapse"
            width="654" x:str="">
            <tr>
                <td class="xl22" colspan="4" height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    width: 369pt; border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent;
                    text-align: right; border-right-color: #d4d0c8" width="492">
                    <span style="font-size: 10pt; font-family: Arial">Our Ref:</span></td>
                <td style="font-size: 10pt; border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    width: 48pt; border-top-color: #d4d0c8; font-family: Arial; background-color: transparent;
                    border-right-color: #d4d0c8" width="64">
                    <asp:Label ID="lblclmno2" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="90px"></asp:Label></td>
                <td style="font-size: 10pt; border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    width: 74pt; border-top-color: #d4d0c8; font-family: Arial; background-color: transparent;
                    border-right-color: #d4d0c8" width="98">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl22" height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: right;
                    border-right-color: #d4d0c8">
                    Date:</td>
                <td align="right" class="xl30" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; background-color: transparent; text-align: center;
                    border-right-color: #d4d0c8" x:num="39336">
                    <asp:Label ID="lbldate2" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="90px"></asp:Label></td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    Actuarial Department</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl62" colspan="6" height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                    <strong><span style="text-decoration: underline">REINSURANCE</span></strong></td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl58" colspan="6" height="17" style="font-weight: normal; border-left-color: #d4d0c8;
                    border-bottom-color: #d4d0c8; border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent;
                    text-align: left; text-decoration: none; border-right-color: #d4d0c8">
                    We give below the informantion regarding reinsurance and shall thank you to let
                    us know the reinsurance's</td>
            </tr>
            <tr>
                <td class="xl58" colspan="6" height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    share of liability and the name of Reinsurer. You may retain the copy in your file.</td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl24" height="17" style="border-right: windowtext 0.5pt dotted; border-top: windowtext 0.5pt solid;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt dotted;
                    height: 12.75pt; background-color: transparent; text-align: left">
                    1. Claim No</td>
                <td class="xl33" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt solid;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent"
                    x:num="">
                    <asp:Label ID="lblclmno3" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl33" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt solid;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    2. Policy No</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent"
                    x:num="">
                    <asp:Label ID="lblpolno2" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    3. DOC of the policy</td>
                <td class="xl47" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent"
                    x:num="38072">
                    <asp:Label ID="lblcom" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl26" height="17" style="border-right: windowtext 0.5pt dotted; border-bottom-color: #d4d0c8;
                    border-left: windowtext 0.5pt solid; border-top-color: windowtext; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    4. Name of the Assured:</td>
                <td class="xl39" colspan="5" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom-color: #d4d0c8; background-color: transparent;
                    text-align: center">
                    <asp:Label ID="lblphname" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="200px"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td class="xl27" style="border-right: windowtext 0.5pt dotted; border-bottom-color: #d4d0c8;
                    border-left: windowtext 0.5pt solid; border-top-color: #d4d0c8; height: 19px;
                    background-color: transparent; text-align: left">
                    <span style="mso-spacerun: yes">&nbsp; &nbsp; </span>Gender (Male/Female):</td>
                <td class="xl37" colspan="3" style="border-right: black 0.5pt dotted; border-left-color: windowtext;
                    border-bottom-color: #d4d0c8; border-top-color: #d4d0c8; background-color: transparent; height: 19px;">
                    <asp:Label ID="lblgender" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl37" colspan="2" style="border-right: black 0.5pt solid; border-left-color: windowtext;
                    border-bottom-color: #d4d0c8; border-top-color: #d4d0c8; background-color: transparent; height: 19px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl28" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left" x:str="    Date of Birth ">
                    <span style="mso-spacerun: yes">&nbsp; &nbsp; </span>Date of Birth<span style="mso-spacerun: yes">&nbsp;</span></td>
                <td class="xl35" colspan="3" style="border-right: black 0.5pt dotted; border-left-color: windowtext;
                    border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;<asp:Label ID="lbldob" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl35" colspan="2" style="border-right: black 0.5pt solid; border-left-color: windowtext;
                    border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    &nbsp;</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    &nbsp;</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl26" height="17" style="border-right: windowtext 0.5pt dotted; border-bottom-color: #d4d0c8;
                    border-left: windowtext 0.5pt solid; border-top-color: windowtext; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    5. Claim amount(for death:</td>
                <td class="xl49" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom-color: #d4d0c8; background-color: transparent"
                    x:num="650000">
                    <asp:Label ID="lblclmamt" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl39" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom-color: #d4d0c8; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl27" height="17" style="border-right: windowtext 0.5pt dotted; border-bottom-color: #d4d0c8;
                    border-left: windowtext 0.5pt solid; border-top-color: #d4d0c8; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    <span style="mso-spacerun: yes">&nbsp; &nbsp; </span>SA+FPU+SJ+ADB if appicable)</td>
                <td class="xl37" colspan="3" style="border-right: black 0.5pt dotted; border-left-color: windowtext;
                    border-bottom-color: #d4d0c8; border-top-color: #d4d0c8; background-color: transparent">
                    <asp:Label ID="lblriderbene" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl37" colspan="2" style="border-right: black 0.5pt solid; border-left-color: windowtext;
                    border-bottom-color: #d4d0c8; border-top-color: #d4d0c8; background-color: transparent">
                    </td>
            </tr>
            <tr>
                <td class="xl28" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    <span style="mso-spacerun: yes">&nbsp; &nbsp; </span>of (for CIC : CIC SA)</td>
                <td class="xl35" colspan="3" style="border-right: black 0.5pt dotted; border-left-color: windowtext;
                    border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
                <td class="xl35" colspan="2" style="border-right: black 0.5pt solid; border-left-color: windowtext;
                    border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    6. If policy is lapsed then date of lapsed</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;<asp:Label ID="lbllapsedt" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    7. Whether the deceased is Main life, Spouse of Child</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    <asp:Label ID="lblmos" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    8. Date of death</td>
                <td class="xl47" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent"
                    x:num="39316">
                    <asp:Label ID="lbldtofdth2" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl39" colspan="2" rowspan="2" style="border-right: black 0.5pt solid;
                    border-top: windowtext 0.5pt dotted; border-left: windowtext 0.5pt dotted; border-bottom: black 0.5pt dotted;
                    background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    9. Caused of Death</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    <asp:Label ID="lblcause" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
            </tr>
            <tr>
                <td class="xl25" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 13pt;
                    background-color: transparent; text-align: left">
                    10. Total bouns entitled to the policy as at date of Death</td>
                <td class="xl48" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 13pt;
                    background-color: transparent" x:num="42250">
                    <asp:Label ID="lbltotbons" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Font-Size="12pt" Font-Underline="False" Width="101px"></asp:Label></td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 13pt;
                    background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl25" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt dotted; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    11. Reinsurance Person no</td>
                <td class="xl31" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
                <td class="xl31" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt dotted; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl29" height="17" style="border-right: windowtext 0.5pt dotted; border-left: windowtext 0.5pt solid;
                    border-top-color: windowtext; border-bottom: windowtext 0.5pt solid; height: 12.75pt;
                    background-color: transparent; text-align: left">
                    12. Reinsuranche share</td>
                <td class="xl43" colspan="3" style="border-right: black 0.5pt dotted; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    &nbsp;</td>
                <td class="xl43" colspan="2" style="border-right: black 0.5pt solid; border-top: windowtext 0.5pt dotted;
                    border-left-color: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="xl59" colspan="6" height="17" style="border-right: black 0.5pt solid;
                    border-left: windowtext 0.5pt solid; border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt solid;
                    height: 12.75pt; background-color: transparent">
                    <strong>See below in detail</strong></td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl22" colspan="5" height="17" style="font-weight: normal; border-left-color: #d4d0c8;
                    border-bottom-color: #d4d0c8; border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent;
                    text-align: right; border-right-color: #d4d0c8">
                    Yours truly</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl23" height="17" style="border-left-color: #d4d0c8; border-top-color: #d4d0c8;
                    border-bottom: windowtext 0.5pt solid; height: 12.75pt; background-color: transparent;
                    border-right-color: #d4d0c8">
                    &nbsp;</td>
                <td class="xl23" style="border-left-color: #d4d0c8; border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt solid;
                    background-color: transparent; border-right-color: #d4d0c8">
                    &nbsp;</td>
                <td class="xl23" style="border-left-color: #d4d0c8; border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt solid;
                    background-color: transparent; border-right-color: #d4d0c8">
                    &nbsp;</td>
                <td class="xl23" style="border-left-color: #d4d0c8; border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt solid;
                    background-color: transparent; border-right-color: #d4d0c8">
                    &nbsp;</td>
                <td class="xl23" style="border-left-color: #d4d0c8; border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt solid;
                    background-color: transparent; border-right-color: #d4d0c8">
                    &nbsp;</td>
                <td class="xl23" style="border-left-color: #d4d0c8; border-top-color: #d4d0c8; border-bottom: windowtext 0.5pt solid;
                    background-color: transparent; border-right-color: #d4d0c8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td class="xl58" colspan="6" height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    To Life Claims/………………………Regional/Branch office</td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    1. Reinsurer share of Liability</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    2. In word</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    3. Name of Reinsure</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    Actuarial Department</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; text-align: left;
                    border-right-color: #d4d0c8">
                    Date:</td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td class="xl58" colspan="3" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; background-color: transparent; border-right-color: #d4d0c8">
                    For Manager / Actuaril<span style="mso-spacerun: yes">&nbsp; </span>Dept</td>
            </tr>
            <tr>
                <td height="17" style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8;
                    border-top-color: #d4d0c8; height: 12.75pt; background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
                <td style="border-left-color: #d4d0c8; border-bottom-color: #d4d0c8; border-top-color: #d4d0c8;
                    background-color: transparent; border-right-color: #d4d0c8">
                </td>
            </tr>
        </table>
    </form>
</body>


</html>
