<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgressEngish001.aspx.cs" Inherits="letters_ProgressEngish" %>

<%@ PreviousPageType VirtualPath="~/dthPro002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
    <script language="javascript" type="text/JavaScript">
    function textDisplay()
    {
        var CkValue = document.getElementById('CheckBox1').checked;
        
        if(CkValue == true)
        {
            document.getElementById('LbText').style.display = '';
        }
        else
        {
            document.getElementById('LbText').style.display = 'none';
        }
    }
        
    </script>
    
    <style type="text/css" media="print">
.BTN
{
	display:none;
	visibility:hidden;
	NoNavButtons:Disables; 
}
</style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 565px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                    <strong>WITHOUT PREJUDICE</strong></td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Our Ref:l/Claims/1/<asp:Literal ID="LtClmno" runat="server"></asp:Literal></span></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                    <asp:Label ID="lbldate" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Width="125px"></asp:Label></td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    Dear Sir/Madam,</td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold; height: 21px; text-decoration: underline" colspan="2">
                    Policy No.
                    <asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-weight: bold; height: 21px; text-decoration: underline">
                    On the life of
                    <asp:Literal ID="litnameofdead" runat="server"></asp:Literal>
                    (Deceased)</td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'">We acknowledge the receipt
                            of the documents forwarded under the above numbered policy.</span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 12pt; font-family: Times New Roman"></span>
                        <span style="font-size: 12pt; font-family: Times New Roman">
                            <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            </span></span>&nbsp;</p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        &nbsp;</p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 12pt; font-family: Times New Roman"><span style="font-size: 10pt;
                            font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">We have taken steps to proceed
                            further and will be informed in due course.</span></span></p>
                    <span style="font-size: 12pt; font-family: Times New Roman"><span style="font-size: 12pt;
                        font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                        mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                            &nbsp;</p>
                        <p class="MsoNormal" style="font-size: 10pt; margin: 0in 0in 0pt; font-family: 'Trebuchet MS';
                            text-align: justify">
                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="BTN" onclick="textDisplay()" />
                            <asp:Label ID="LbText" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                                Width="426px">Further  we have return the original death certificate attached herewith.</asp:Label></p>
                    </span></span>
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'">Thanking you</span></p>
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Yours faithfully</span></td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 12pt"><span style="font-family: Times New Roman">
                            <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><st1:country-region w:st="on"><st1:place w:st="on"><B 
      style="FONT-SIZE: 10pt; FONT-FAMILY: 'Trebuchet MS'; mso-bidi-font-weight: normal">SRI 
      LANKA</B></st1:place></st1:country-region></span></span><b> INSURANCE CORPORATION LIFE LTD</b></p>
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'">For Life Manager</span></p>
                </td>
                <td style="width: 129px; height: 21px">
                </td>
                <td style="width: 130px; height: 21px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
