<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cvouDelete003.aspx.cs" Inherits="cvouDelete003" %>
<%@ PreviousPageType VirtualPath="~/voucher/vouDelete002.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sri Lanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">

        function test(source, arguments) {

            if (!IsNumeric(arguments.Value))
            { arguments.IsValid = false; }

            else
            { arguments.IsValid = true; }
        }

        function MM_goToURL() { //v3.0
            var i, args = MM_goToURL.arguments; document.MM_returnValue = false;
            for (i = 0; i < (args.length - 1); i += 2) eval(args[i] + ".location='" + args[i + 1] + "'");
        }
        
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-weight: bold; font-size: 10pt; width: 685px; font-family: 'Trebuchet MS'">
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="2" rowspan="1" style="background-color: #f0f0f0; height: 21px;">
                    &nbsp;</td>
                <td style="font-size: 10pt; width: 20px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 18px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Voucher Delete</span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                        <asp:Label ID="lblsuccess" runat="server" Font-Size="10pt" ForeColor="#00CC33" Text="Successfully Deleted"
                            Visible="False" Width="409px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                </td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    Policy Number</td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    Life</td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblmos" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    Claim No.</td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblclaimno" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">Insured Name</span></td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    <span style="font-size: 11pt">: </span>
                    <asp:Label ID="lblphname" runat="server" Font-Bold="True" Font-Size="10pt" Width="348px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">Payee Name</span></td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    <span style="font-size: 11pt">: </span>
                    <asp:Label ID="lblPayeeName" runat="server" Font-Bold="True" Font-Size="10pt" Width="348px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 21px">
                </td>
                <td style="width: 179px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">Net Claim &nbsp;Amount</span></td>
                <td style="width: 378px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">: </span>
                    <asp:Label ID="lblnetamt" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="width: 20px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 21px">
                </td>
                <td style="width: 179px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">Voucher No</span></td>
                <td style="width: 378px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">: </span>
                    <asp:Label ID="lblVouNo" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="width: 20px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
                     
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 18px">
                    <asp:Button ID="btnDelete" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Delete--" Font-Size="10pt" onclick="btnDelete_Click" />
                    <asp:Button ID="btnexit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnexit_Click" OnClientClick="MM_goToURL('self','../Home.ASPX');return document.MM_returnValue"
                        Text="--Exit--" Width="84px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/voucher/vouPrintMain.aspx"><<--Back</asp:HyperLink></td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:Label ID="lblmessage" runat="server" Font-Bold="true" Font-Size="10pt" 
                        ForeColor="#FF3333" Text="Voucher already Authorized. Cannot Delete." Visible="False"></asp:Label></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px">
                </td>
                <td style="width: 179px">
                </td>
                <td style="width: 378px">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
        </table>
    
    <br />
    
    </div>
    </form>
</body>
</html>

