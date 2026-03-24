<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBPaymentDistn001.aspx.cs" Inherits="ADBPaymentDistn001" %> 
<%@ PreviousPageType VirtualPath="~/ADBApproveMemo002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script language="JavaScript" type="text/JavaScript">
<!--
        function MM_goToURL() { //v3.0
            var i, args = MM_goToURL.arguments; document.MM_returnValue = false;
            for (i = 0; i < (args.length - 1); i += 2) eval(args[i] + ".location='" + args[i + 1] + "'");
        }
//-->
</script>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong>
            <table style="font-size: 10pt; width: 651px; font-family: 'Trebuchet MS';">
                <tr>
                    <td colspan="5" style="height: 20px; background-color: whitesmoke">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 20px">
                        <span style="font-size: 12pt"><span style="font-size: 14pt">Sri Lanka Insurance<br />
                        </span>Death Calim ADB Distribution</span></td>
                </tr>
                <tr>
                    <td style="height: 20px; background-color: #f0f0f0;" colspan="5">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px; text-align: left;" colspan="5">
                        <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px"
                            HorizontalAlign="Left" Width="670px" Font-Bold="True" style="text-align: left">
                        </asp:Table>
                    </td>
                </tr>
                 <tr>
                    <td style="height: 20px; text-align: left;" colspan="5">
                        <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="1px"
                            HorizontalAlign="Left" Width="670px" Font-Bold="True" style="text-align: left">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 96px; height: 20px; background-color: #f0f0f0; text-align: left;">
                        <asp:Label ID="lblReside" runat="server" Text="Residing At" Visible="False"></asp:Label></td>
                    <td colspan="2" style="height: 20px; background-color: #f0f0f0; text-align: left">
                        <asp:TextBox ID="txtReside" runat="server" Visible="False" Width="247px"></asp:TextBox></td>
                    <td style="width: 222px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 222px; height: 20px; background-color: #f0f0f0;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px" colspan="5">
                        <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="#00CC33"
                            Visible="False" Width="336px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px; background-color: #f0f0f0;" colspan="5">
                        <asp:Label ID="lblalert" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="#FF0033" Width="515px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px" colspan="5">
                        <asp:Button ID="cmdPayee" runat="server" Height="26px" Text="Change Payees" OnClick="cmdPayee_Click" />
                        <%--<asp:Button ID="btnOK" runat="server" Text="--OK--" OnClick="btnOK_Click" Font-Bold="False" Font-Names="Trebuchet MS" />--%>
                        <asp:Button ID="btnExit" runat="server" Text="--Exit-- " OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Font-Bold="False" Font-Names="Trebuchet MS"/>                        
                        <asp:Button ID="cmdApprove" runat="server" Height="25px" Visible="false" Text="--Approve--" Width="75px" onclick="cmdApprove_Click" />
                        <asp:Button ID="cmdReject" runat="server" Height="25px" Text="--Reject--" Width="75px" onclick="cmdReject_Click"/>
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" Font-Size="10pt" OnClick="LinkButton1_Click"><<--Go to Discharges</asp:LinkButton></td>
                </tr>
                <tr>
                    <td style="width: 96px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 222px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 222px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 222px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 222px; height: 20px; background-color: #f0f0f0;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px" colspan="5">
                        <asp:CustomValidator ID="cv" runat="server" Font-Bold="False" Font-Size="10pt" Width="425px"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="width: 96px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 206px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 206px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 206px; height: 20px; background-color: #f0f0f0;">
                    </td>
                    <td style="width: 206px; height: 20px; background-color: #f0f0f0;">
                    </td>
                </tr>
            </table>
        <br />
        </strong>
        </span>
        </span>
    
    </div>
    </form>
</body>
</html>
