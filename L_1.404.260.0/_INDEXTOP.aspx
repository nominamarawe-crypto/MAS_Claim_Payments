<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_INDEXTOP.aspx.cs" Inherits="_INDEXTOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <table style="width: 898px; height:auto;">
        <tr>
            <td style="width: 275px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/dthInt010.aspx" Target="MAIN">Death Intimation</asp:HyperLink></td>
            <td style="width: 187px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="linkdthReg" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthReg001.aspx" Target="MAIN">Registration</asp:HyperLink></td>
            <td style="width: 185px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="linkreq" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthreq.aspx" Target="MAIN">Requirements</asp:HyperLink></td>
            <td style="width: 392px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="linkprocess" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthPro001.aspx" Target="MAIN">Processing</asp:HyperLink></td>
            <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="linkPayment" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthPay001.aspx" Target="MAIN" Width="177px">Payment Memo & Distribution</asp:HyperLink></td>
            <td style="width: 567px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink15" runat="server" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/MemoAprv001.aspx" Target="MAIN" Width="122px">Approve Memo</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 275px; height: 18px; text-align: left">
                <asp:HyperLink ID="linkpaymentcomplete" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthVou001.aspx" Target="MAIN">Payment</asp:HyperLink></td>
            <td style="width: 187px; height: 18px; text-align: left">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/prtPmnt001.aspx" Target="MAIN" Width="88px">Part Payments</asp:HyperLink></td>
            <td style="width: 185px; height: 18px; text-align: left">
                <asp:HyperLink ID="linkTrnState" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/trnState001.aspx" Target="MAIN" Width="123px">State of Transaction</asp:HyperLink></td>
            <td style="width: 392px; height: 18px; text-align: left">
                <asp:HyperLink ID="linkRev" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/dthRev001.aspx" Target="MAIN">Death Claim Reverse</asp:HyperLink></td>
            <td style="width: 410px; height: 18px; text-align: left">
                <asp:HyperLink ID="linkVouPrint" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/voucher/vouPrintMain.aspx"  Target="MAIN" Width="98px">Voucher Printing</asp:HyperLink></td>
            <td style="width: 567px; height: 18px; text-align: left">
                <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/repudiation001.aspx" Target="MAIN" Width="100px">Repudiation</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 275px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink6" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/reinsLetter001.aspx" Target="MAIN" Width="112px">Reinsurance Letter</asp:HyperLink></td>
            <td style="width: 187px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink4" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/letters/docsIntimation001.aspx" Target="MAIN" Width="167px">Intimation Stage Documents</asp:HyperLink></td>
            <td style="width: 185px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink7" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/loanRecReprint001.aspx" Target="MAIN">Loan Reciept Reprint</asp:HyperLink></td>
            <td style="width: 392px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink14" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/childProtVou/cvouMain.aspx" Target="MAIN" Width="150px">Child Protection Vouchers</asp:HyperLink></td>
            <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/MainPage.aspx" Target="MAIN">Death Inquiry</asp:HyperLink></td>
            <td style="width: 567px; height: 18px; background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink17" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/RepudiatePay001.aspx" Target="MAIN" Width="115px">Special Payments</asp:HyperLink></td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #f0f0f0; height: 18px;  text-align: left">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/OldClaimMain.aspx" Target="MAIN" Width="160px" style="font-size: 10pt; font-family: 'Trebuchet MS'">Outstanding Claims Entry</asp:HyperLink></td>
            <td style="width: 185px; background-color: #f0f0f0; height: 18px;  text-align: left">
                <asp:HyperLink ID="HyperLink10" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/EntryList.aspx" Target="MAIN" Width="142px">Old Claim Authorization</asp:HyperLink></td>
            <td style="width: 392px; background-color: #f0f0f0; height: 18px;  text-align: left">
                <asp:HyperLink ID="HyperLink9" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/OldChildProt/OldChildProtMain.aspx" Target="MAIN">Old Child Protection</asp:HyperLink></td>
            <td style="width: 410px; height: 18px;  background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="HyperLink11" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/ChildProt/ChildProtPay010.aspx" Target="MAIN" Width="97px">Child Protection</asp:HyperLink></td>
            <td style="width: 567px; height: 18px;  background-color: #f0f0f0; text-align: left">
                <asp:HyperLink ID="linkreminders" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/Reminder001.aspx" Target="MAIN">Reminders</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="background-color: #f0f0f0; height: 18px;  text-align: left; ">
                <asp:HyperLink ID="HyperLink13" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/SpouseCVREntry.aspx" Target="MAIN">Spouse Cover Entry</asp:HyperLink></td>
            <td style="width: 185px; height: 18px;  background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink12" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt" Width="191px" NavigateUrl="~/OldClmPymnt_Distribution.aspx" Target="MAIN">Old Claim Payment Distribution</asp:HyperLink></td>
            <td style="width: 392px; height: 18px;  background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink8" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/PolReStat001.aspx" Target="MAIN">Policy Re-State</asp:HyperLink></td>
            <td style="width: 410px; height: 18px;  background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink18" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/Sundryrcpt001.aspx" Target="MAIN">Sundry Receipt</asp:HyperLink></td>
            <td style="width: 567px; height: 18px;  background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink19" runat="server" Font-Names="Trebuchet MS" Font-Size="8pt"
                    NavigateUrl="~/SwarnaJayanthiEnqueryPage.aspx" Target="MAIN">SJ Calculation</asp:HyperLink>
            </td>
            
            <td style="width: 410px; height: 18px;  background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink20" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/ManualCheckEntry.aspx" Target="MAIN">Manual Check Entry</asp:HyperLink></td>
        </tr>

        <tr>
            <%--<td style="background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink21" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/ManualAdmitAndPaidNoEntry.aspx" Target="MAIN">Manual Admit No/Paid No Entry</asp:HyperLink></td>--%>
			<td style="background-color: #f0f0f0; height: 18px;  text-align: left; ">
                <asp:HyperLink ID="HyperLink22" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/UpdAdmitAndPaidNoControl.aspx" Target="MAIN">Update Admit No/Paid No Control</asp:HyperLink></td>
            <td style="width: 185px; background-color: #f0f0f0; height: 18px; text-align: left; ">
                <asp:HyperLink ID="HyperLink23" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/UpdateDeathRegister001.aspx" Target="MAIN">Update Death Claim Register Manually</asp:HyperLink></td>
            <td style="width: 392px; background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink21" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/UpdateChildProtPayments001.aspx" Target="MAIN">Update Child Protection Payments Manually</asp:HyperLink></td>
            <td style="width: 410px; background-color: #f0f0f0; text-align: left; ">
            <asp:HyperLink ID="HyperLink24" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/ADBPaymemtMemo001.aspx" Target="MAIN" Width="177px">ADB Payment Memo & Distribution</asp:HyperLink></td>
            <td style="width: 567px; background-color: #f0f0f0; text-align: left; ">
            <asp:HyperLink ID="HyperLink25" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/ADBApproveMemo001.aspx" Target="MAIN" Width="177px">Approve ADB Memo</asp:HyperLink></td>            
            <td style="width: 410px; background-color: #f0f0f0; text-align: left; ">
            <asp:HyperLink ID="HyperLink26" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                    Font-Size="10pt" NavigateUrl="~/ADBPaymemtReopen001.aspx" Target="MAIN" Width="177px">Re-open ADB Payment</asp:HyperLink></td>
        </tr>
        <tr> 
			<td style="background-color: #f0f0f0; height: 18px;  text-align: left; ">
                <asp:HyperLink ID="HyperLink27" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/TerroristList001.aspx" Target="MAIN">AML Designated Persons</asp:HyperLink></td>
            <td style="width: 185px; background-color: #f0f0f0; height: 18px; text-align: left; ">
                <asp:HyperLink ID="HyperLink28" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/Actuarial001.aspx" Target="MAIN">Actuarial</asp:HyperLink></td>
            <td style="width: 392px; background-color: #f0f0f0; text-align: left; ">
                 <asp:HyperLink ID="HyperLink29" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="~/ReInsuranceInq001.aspx" Target="MAIN">Re-Insurance Inquiry</asp:HyperLink></td>
            <td style="width: 410px; background-color: #f0f0f0; text-align: left; ">
                <asp:HyperLink ID="HyperLink30" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                    NavigateUrl="http://172.24.80.98:8082/SessionTrans.aspx" Target="_blank">View Death Registry</asp:HyperLink></td>
            <td style="width: 567px; background-color: #f0f0f0; text-align: left; ">
                </td>            
            <td style="width: 410px; background-color: #f0f0f0; text-align: left; ">
                </td>
        </tr>
        
    </table>
</body>
</html>
