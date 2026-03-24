<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docsOriginalPolEng001.aspx.cs" Inherits="docsOriginalPolEng001" %>
<%@ PreviousPageType VirtualPath="~/docsEngMain.aspx"%>
<%@ Reference Page="~/ePage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 637px">
            <tr>
                <td style="width: 20px; height: 15px">
                </td>
                <td colspan="4" style="height: 15px">
                </td>
                <td style="width: 20px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td colspan="4" style="height: 5px; text-align: left">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    </span>
                </td>
                <td style="width: 20px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: left">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td colspan="4" style="height: 5px; text-align: left;">
                    Our Ref:l/Claims/1/DC/<asp:Label ID="lblourref" runat="server" Width="75px"></asp:Label></td>
                <td style="width: 20px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: left">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: left">
                    Date:
                    <asp:Label ID="lbldate" runat="server" Width="75px"></asp:Label>&nbsp;</td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: left">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 12px">
                </td>
                <td colspan="4" style="height: 12px; text-align: left;">
                    <asp:Label ID="lblname" runat="server" Width="498px"></asp:Label></td>
                <td style="width: 20px; height: 12px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td colspan="4" style="height: 5px; text-align: left;">
                    <asp:Label ID="lblad1" runat="server" Width="498px"></asp:Label></td>
                <td style="width: 20px; height: 5px">
                </td>
            </tr>
            <tr>
                <td align="left" style="font-weight: normal; height: 20px; width: 20px;">
                </td>
                <td align="left" colspan="4" style="font-weight: normal; height: 20px; text-align: left">
                    <asp:Label ID="lblad2" runat="server" Width="498px"></asp:Label></td>
                <td align="left" style="font-weight: normal; font-size: 10pt; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                    <asp:Label ID="lblad3" runat="server" Font-Size="12pt" Width="498px"></asp:Label></td>
                <td style="width: 20px; height: 20px; text-decoration: underline">
                </td>
            </tr>
            <tr style="font-size: 12pt; text-decoration: underline">
                <td style="width: 20px; height: 20px; font-weight: normal; text-decoration: none;">
                </td>
                <td colspan="4" style="height: 20px; text-align: left; font-weight: normal; width: 20px; text-decoration: none;">
                    <asp:Label ID="lblad4" runat="server" Font-Size="12pt" Font-Underline="False" Width="498px"></asp:Label></td>
                <td style="font-weight: normal; width: 20px; height: 20px; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt">
                <td style="width: 20px; height: 8px">
                </td>
                <td colspan="4" style="height: 8px; text-align: left">
                </td>
                <td style="width: 20px; height: 8px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left;">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Dear Sir/Madam,</span></td>
                <td style="font-weight: bold; width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 8px">
                </td>
                <td colspan="4" style="height: 8px; text-align: left;">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; text-decoration: underline;
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA"><strong>Policy No.
                            <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Font-Size="12pt" Font-Underline="True"
                                Width="62px"></asp:Label></strong></span></td>
                <td style="width: 20px; height: 8px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; text-decoration: underline;
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA"><strong>On the Life of Mr. /Mrs.
                            <asp:Label ID="lblnameofdead" runat="server" Font-Size="11pt" Font-Underline="True"
                                Width="279px"></asp:Label><span style="font-size: 12pt; font-family: 'Times New Roman';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                    mso-bidi-language: AR-SA">(decd)</span></strong></span></td>
                <td style="font-size: 12pt; width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="font-size: 12pt; width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        We refer to your claim consequent on the death of the Life Assured under the above
                        policy.</span></td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px">
                </td>
                <td style="font-size: 12pt; width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 8px">
                </td>
                <td colspan="4" style="height: 8px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left">
                        Please forward us the Original Policy Document.</p>
                </td>
                <td style="width: 20px; height: 8px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        If it was misplaced, please forward us names of two persons of sound financial standing
                        giving their consent to act as sureties for an Indemnity Bond.<span style="mso-spacerun: yes">&nbsp;
                        </span>Their full names, addresses and designations should be stated in the attached
                        form.<span style="mso-spacerun: yes">&nbsp; </span>On completion of the above requirements
                        steps will be taken for the settlement of the claim.</p>
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        Thanking you</p>
                </td>
                <td style="font-weight: bold; width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px; text-align: center">
                </td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        Yours faithfully</p>
                </td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><st1:country-region><st1:place><B 
      style="mso-bidi-font-weight: normal">SRI 
      LANKA</B></st1:place></st1:country-region><b style="mso-bidi-font-weight: normal">INSURANCE<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><o:p></o:p></b></p>
                </td>
                <td style="font-weight: bold; width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        For Life Manager</p>
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt">
                <td style="width: 20px; height: 5px">
                </td>
                <td colspan="4" style="height: 5px; text-align: left">
                </td>
                <td style="width: 20px; height: 5px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="5" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; vertical-align: top; text-align: left;">
                        Copy:-<asp:Label ID="lblcopy1" runat="server" Visible="False" Width="554px"></asp:Label></p>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: left">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
