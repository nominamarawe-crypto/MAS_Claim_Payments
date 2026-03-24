<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage1" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

<head>
<meta http-equiv="Content-Language" content="en-us">
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<body>

<p><font face="Trebuchet MS" size="2">

</font>
    <table style="width: 793px">
        <tr>
            <td style="width: 205px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink11" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/payeeInq001.aspx?sender=3" Target="MAIN" Width="150px">Intimation Deatil Inquiry</asp:HyperLink>
            </td>
            <td style="width: 128px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink12" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/payeeInq001.aspx?sender=4" Target="MAIN" Width="173px">Requirements Detail Inquiry</asp:HyperLink>
            </td>
            <td style="width: 141px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink10" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/payeeInq001.aspx?sender=2" Target="MAIN" Width="100px">Claim Inquiry</asp:HyperLink>
            </td>
            <td style="width: 203px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink9" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/payeeInq001.aspx?sender=1" Target="MAIN" Width="100px">Payee Inquiry</asp:HyperLink></td>
            <td style="width: 487px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink8" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/lnStat001.aspx" Target="MAIN" Width="127px">Statistics</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 205px; height: 18px; text-align: left">
                <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthOut001.aspx" Target="MAIN" Width="127px">Outstanding Claims</asp:HyperLink></td>
            <td style="width: 128px; height: 18px; text-align: left">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/Outstanding DeathReport/dthoutlist001.aspx" Target="MAIN"
                    Width="181px">Death Outstanding Reports</asp:HyperLink></td>
            <td style="width: 141px; height: 18px; text-align: left">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../DethIBSLreport/ibslRep001.aspx" Target="_blank" >IBSL Report</asp:HyperLink></td>
            <td style="height: 18px; text-align: left" >
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/DeathRegisterSelect.aspx" 
                    Target="_blank" Width="138px">Death Claim Register</asp:HyperLink></td>
            <td style="width: 487px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/DeathClaimReport.aspx" Target="MAIN" Width="127px"> Death Claim Period Report</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 205px; height: 17px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink13" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/FileScanningReport001.aspx" Target="MAIN" Width="127px"> File Scanning Requested Report</asp:HyperLink></td>
            <td style="width: 128px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
            <td style="width: 141px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
            <td style="width: 203px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
            <td style="width: 487px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
        </tr>
    </table>
       
<iframe name="MAIN" width="1000" height="1235" border="0" frameborder="0" style="width: 1000px; height: 895px">Your browser does not support inline frames or is currently configured not to display inline frames.</iframe>&nbsp;</p>

</body>
</html>
