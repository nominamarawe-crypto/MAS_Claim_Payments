<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouPrintMain.aspx.cs" Inherits="vouPrintMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <table style="width: 633px">
            <tr>
                <td style="width: 26px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 26px; height: 18px; text-align: center">
                </td>
                <td style="width: 160px; height: 18px; text-align: center">
                    <asp:HyperLink ID="linkvouprint" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" NavigateUrl="~/voucher/vouPrint001.aspx">Voucher Printing</asp:HyperLink></td>
                <td style="width: 160px; height: 18px; text-align: center">
                    <asp:HyperLink ID="linkVouReprint" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" NavigateUrl="~/voucher/vouReprint001.aspx">Voucher Repint</asp:HyperLink></td>
                <td style="width: 160px; height: 18px; text-align: center">
                    <asp:HyperLink ID="linkvouedit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" NavigateUrl="~/voucher/vouDetEdit001.aspx">Voucher Details Edit</asp:HyperLink></td>
                <td style="width: 160px; height: 18px; text-align: center">
                    <asp:HyperLink ID="linkvouauth" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" NavigateUrl="~/voucher/vouAuth001.aspx">Voucher Authorization</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 26px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 26px; height: 18px">
                </td>
                <td style="width: 160px; height: 18px">
                </td>
                <td style="width: 160px; height: 18px">
                </td>
                <td style="width: 160px; height: 18px">
                </td>
                <td style="width: 160px; height: 18px; text-align: right">
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
