<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reminder003.aspx.cs" Inherits="reminder003" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/reminder002.aspx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style type="text/css">
     P.breakhere {page-break-before: always}
</style> 

    <title>SriLanka Insurance - Death Claims</title>
</head>
<body >
    <form id="form1" runat="server">   
       <%-- <% 
              if (Rem_no == 1)
                {
                    lblceo.Visible = false;
                    lblcopyto.Visible = false;                    
                }
                else
                {
                    lblceo.Visible = true;
                    lblcopyto.Visible = true;
                }
         %>
          --%>
        <div style="text-align: center">
        <span style="font-size: 24pt"></span>
        <table style="width: 637px; font-size: 12pt;">
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td style="width: 25px; height: 20px">
                </td>
                <td style="width: 256px; height: 20px">
                </td>
                <td style="width: 90px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal"><u><span><span style="font-family: Trebuchet MS">
                            <asp:Label ID="lbl_remindno" runat="server" Width="123px"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></u></b></p>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;"><span style="font-family: Trebuchet MS">
                        </span></span>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;">
                        <span style="font-family: Trebuchet MS">
                        Our Ref: Life/ Claims/B/</span><asp:Label ID="lblEPF" runat="server" Width="90px" Font-Names="Trebuchet MS"></asp:Label></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Times New Roman';">
                    <asp:Label ID="lbldate" runat="server" Width="90px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 17px">
                </td>
                <td colspan="3" style="height: 17px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litName" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd1" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 15px">
                </td>
                <td colspan="3" style="height: 15px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd2" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd3" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd4" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; font-size: 10pt; font-family: 'Times New Roman';">
                        <span style="font-family: Trebuchet MS">
                        Dear Sir/Madam,</span></p>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 7px">
                </td>
                <td colspan="3" style="height: 7px; vertical-align: top;">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Times New Roman'; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <strong><span><span style="font-family: Trebuchet MS">Policy No:
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></span></span></strong></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Times New Roman'; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <strong style="font-family: 'Trebuchet MS'"><span style="font-family: Trebuchet MS;">On the Life of&nbsp; </span>
                            <asp:Literal ID="litlifeassured" runat="server"></asp:Literal>&nbsp;<span
                                style="font-size: 14pt"></span></strong></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 13px">
                </td>
                <td colspan="3" style="height: 13px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify; font-size: 10pt; font-family: 'Trebuchet MS'; text-justify: auto;">
                        <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'">This refers to the death claim under the above policy</span>. <span style="font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                mso-bidi-font-family: 'Times New Roman'">We would like to draw your kind attention
                                to our letter dated </span>
                        <asp:Literal ID="litdated" runat="server"></asp:Literal>
                        <asp:Label ID="lblsubsequentrem" runat="server" Style="text-align: center"
                            Width="200px">and subsequent reminder/s dated </asp:Label>&nbsp;
                        <asp:Literal ID="litsubseqdt1" runat="server"></asp:Literal>
                        <asp:Literal ID="litsubseqdt2" runat="server"></asp:Literal>
                        .</p>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblforthirdreminders" runat="server" Style="text-align: left" Width="415px" Visible="False">and kindly request you to forward the following documents urgently.</asp:Label></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; text-justify: auto; text-align: justify;">
                        <span style="font-size: 10pt; font-family: Trebuchet MS; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'">
                        Please forward the following requirements
                            within 14 days to process this claim.</span></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 12px">
                </td>
                <td colspan="3" style="height: 12px; text-align: left">
                    <asp:Table ID="Table1" runat="server" HorizontalAlign="Justify" Width="614px" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: justify; font-size: 10pt; font-family: 'Trebuchet MS'; text-justify: auto;">
                    <asp:Literal ID="litreq21" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblforlastreminder" runat="server" Style="text-align: justify; text-justify: auto;" Width="613px" Visible="False">Also we would like to inform you that if we do not receive any respond from you for this letter within 14 days, we are compelled to treat this as an abandoned claim & close your claim.</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblforlastreminder2" runat="server" Style="text-align: justify; text-justify: auto;" Width="611px" Visible="False">We are looking forward to receipt the above documents urgently</asp:Label></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify; font-size: 10pt; font-family: 'Trebuchet MS';">
                        Thank you,</p>
                </td>
                <td style="width: 90px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; font-size: 10pt; font-family: 'Trebuchet MS';">
                        Yours truly,</p>
                </td>
                <td style="width: 90px; height: 16px; text-align: left; font-size: 12pt;">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 14px">
                </td>
                <td colspan="2" style="height: 14px; text-align: left; font-size: 11pt; font-family: 'Trebuchet MS';">
                    <span></span><span style="font-size: 10pt"><strong>SRI LANKA INSURANCE</strong></span></td>
                <td style="width: 90px; height: 14px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: left">
                    ..................................</td>
                <td style="width: 90px; height: 21px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS';">For Life Manager.<o:p></o:p></b></p>
                </td>
                <td style="width: 90px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left;">
                </td>
                <td style="width: 90px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 18px">
                </td>
                <td colspan="1" style="width: 25px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblcopyto" runat="server" Style="text-align: center" Width="63px">Copy To:</asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <asp:Literal ID="litceo" runat="server" Text="Chief Executive Officer - Life"></asp:Literal></span></td>
            </tr>
            <%if (brcopy)
              {
            %>
            <tr>
                <td style="width: 15px; height: 18px">
                </td>
                <td colspan="1" style="width: 25px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
                <td style="height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litbrname" runat="server"></asp:Literal><asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2" runat="server"></asp:Literal><asp:Literal
                            ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbrad4" runat="server"></asp:Literal></td>
            </tr>
            <%
                }
                if (agcopy)
                {
            %>
            <tr>
                <td style="width: 15px; height: 18px">
                </td>
                <td colspan="1" style="width: 25px; height: 18px; text-align: left">
                </td>
                <td style="height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litagname" runat="server"></asp:Literal><asp:Literal ID="litagad1" runat="server"></asp:Literal><asp:Literal ID="litagad2" runat="server"></asp:Literal><asp:Literal ID="litagad3" runat="server"></asp:Literal>
                    <asp:Literal ID="litagad4" runat="server"></asp:Literal>
                    <asp:Literal ID="litagad5" runat="server"></asp:Literal></td>
            </tr>
            <%
                }
                if (rgcod)
                {
            %>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="1" style="width: 25px; height: 16px; text-align: left">
                </td>
                <td style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litrgcdname" runat="server"></asp:Literal><asp:Literal ID="litrgcdad1" runat="server"></asp:Literal><asp:Literal ID="litrgcdad2" runat="server"></asp:Literal><asp:Literal ID="litrgcdad3" runat="server"></asp:Literal><asp:Literal ID="litrgcdad4" runat="server"></asp:Literal></td>
            </tr>
            <%
                }
                if(rgsm)
                {
            %>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="1" style="width: 25px; height: 8px; text-align: left">
                </td>
                <td style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litrgsmname" runat="server"></asp:Literal><asp:Literal ID="litrgsmad1" runat="server"></asp:Literal><asp:Literal ID="litrgsmad2" runat="server"></asp:Literal><asp:Literal ID="litrgsmad3" runat="server"></asp:Literal><asp:Literal ID="litrgsmad4" runat="server"></asp:Literal></td>
            </tr>
            <%} %>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="1" style="width: 25px; height: 8px; text-align: left">
                </td>
                <td style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="1" style="width: 25px; height: 8px; text-align: left">
                </td>
                <td style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                        </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lbllast" runat="server" Width="440px" Visible="False">(Please obtain above requirements and forward us as soon as possible.)</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    <strong><span style="font-size: 10pt"><span style="font-family: Trebuchet MS">Our contact
                        Nos. 2357247/2357225 /2357221/2357760/2357205<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><o:p></o:p></span></span></strong></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td style="width: 25px; height: 20px">
                </td>
                <td style="height: 20px" colspan="2">
                    <asp:Button ID="btn_print" runat="server" PostBackUrl="~/reminder003Print.aspx" Text="Print"
                        Width="107px" OnClick="btn_print_Click" Font-Bold="True" /><asp:Button ID="btnExit"
                            runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="10pt" Height="23px"
                            OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                            Text="  Exit  " Width="96px" /><asp:Button ID="btn_word" runat="server" Font-Bold="True"
                                Height="23px" OnClick="Button1_Click" Text="Get Word Document" Width="148px" PostBackUrl="~/reminder003Print.aspx" /></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                </td>
            </tr>
        </table>
    
    </div><p class="breakhere" />  
    </form>
</body>
</html>
