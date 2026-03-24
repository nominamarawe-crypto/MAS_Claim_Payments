<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtPmnt002.aspx.cs" Inherits="prtPmnt002" %>
<%@ PreviousPageType VirtualPath="~/prtPmnt001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims, Part Payments</title>
</head>
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-weight: normal; font-size: 10pt; width: 699px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="height: 18px; background-color: white" colspan="5">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px">
                    <span style="font-size: 8pt"><strong>
                    <span><span style="font-family: Tahoma"></span>
                    </span><span style="font-family: Tahoma;">Death Claim Part Payments</span></strong></span></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: white">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 18px">
                </td>
                <td style="width: 154px; height: 18px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">
                    Policy No.</span></td>
                <td style="width: 127px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="105px" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
                <td style="width: 181px; height: 18px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">
                    Life Type</span></td>
                <td style="width: 159px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbllifeType" runat="server" Width="105px" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; background-color: white" colspan="5">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 18px">
                </td>
                <td style="width: 154px; height: 18px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">
                    Total Claim Payment</span></td>
                <td style="width: 127px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbltotclm" runat="server" Width="105px" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
                <td style="width: 181px; height: 18px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">
                    Payee</span></td>
                <td style="width: 159px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpayee" runat="server" Width="105px" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; background-color: white" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 22px; height: 16px">
                </td>
                <td style="width: 154px; height: 16px; text-align: left">
                    <asp:Label ID="lblAdbExgracia" runat="server" Width="105px" Font-Names="Tahoma" Font-Size="8pt">ADB on exgracia</asp:Label></td>
                <td style="width: 127px; height: 16px; text-align: left">
                    <asp:CheckBox ID="chkAdbexgracia" runat="server" Text="Yes" Font-Names="Tahoma" Font-Size="8pt" /></td>
                <td style="width: 181px; height: 16px; text-align: left">
                </td>
                <td style="width: 159px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px">
                    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" HorizontalAlign="Left" Width="640px" style="text-align: left" Font-Names="Tahoma" Font-Size="8pt">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="height: 18px; background-color: white" colspan="5">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px">
                    <asp:Button ID="btnCancelPayment" runat="server" Font-Bold="False" Font-Names="Tahoma"
                        OnClick="btnCancelPayment_Click" Text="Cancel Part Payments" Font-Size="8pt" Height="24px" />
                    <asp:Button ID="btnVouCr" runat="server" Font-Bold="False" Font-Names="Tahoma"
                        OnClick="btnVouCr_Click" PostBackUrl="~/ADBvouCreate001.aspx" Text="--Create Voucher--" Font-Size="8pt" Height="24px" />
                     <asp:Button ID="btnSlicVou" runat="server" Font-Bold="False" Font-Names="Tahoma"
                        PostBackUrl="~/prtPmntSlicVou001.aspx" Text="SLIC Voucher" Font-Size="8pt" 
                        Height="24px" onclick="btnSlicVou_Click" />
                </td>
            </tr>
            <tr>
                <td style="height: 18px; background-color: white" colspan="5">
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
