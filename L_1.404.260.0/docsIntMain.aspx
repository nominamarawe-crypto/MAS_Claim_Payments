<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docsIntMain.aspx.cs" Inherits="docsIntMain" %>
<%@ PreviousPageType VirtualPath="~/docsIntimation001.aspx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Intimation Stage Documents</span></strong><br />
        <table style="width: 531px">
            <tr>
                <td colspan="3" style="width: 371px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td colspan="2" style="width: 246px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 371px; height: 18px; text-align: center">
                    <asp:LinkButton ID="linkEngDocMain" runat="server" PostBackUrl="~/docsSinMain.aspx">Sinhala Documents</asp:LinkButton></td>
                <td colspan="2" style="width: 246px; height: 18px; text-align: center">
                    <asp:LinkButton ID="linkEngMain" runat="server" OnClick="linkEngMain_Click" PostBackUrl="~/docsEngMain.aspx">English Documents</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 371px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td colspan="2" style="width: 246px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 371px; height: 15px; text-align: center;">
                    &nbsp;</td>
                <td colspan="2" style="width: 246px; height: 15px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="14pt" ForeColor="Blue" NavigateUrl="~/Home.aspx">Back</asp:HyperLink></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
