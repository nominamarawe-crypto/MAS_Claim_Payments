<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouReprint003.aspx.cs" Inherits="vouReprint003" %>
<%@ PreviousPageType VirtualPath="~/vouReprint002.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Policy Surrenders</title>
</head>
<body onload = "window.print()" style="text-align: center" >
    <form id="form1" runat="server">
  
        <table style="font-size: 9pt; width: 661px; font-family: Arial; font-variant: normal">
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 520px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 520px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 520px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                    &nbsp;</td>
                <td colspan="4" style="height: 18px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        VOUCHER FOR PAYMENT OF POLICY SURRENDER</p>
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 6px">
                </td>
                <td style="width: 520px; height: 6px; text-align: left">
                </td>
                <td style="width: 161px; height: 6px; text-align: left">
                </td>
                <td style="width: 152px; height: 6px; text-align: left">
                </td>
                <td style="width: 134px; height: 6px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 11px">
                </td>
                <td style="width: 520px; height: 11px; text-align: left">
                    PAYMENT VOUCHER NO.</td>
                <td style="width: 161px; height: 11px; text-align: left">
                    :
                    <asp:Label ID="lblvouno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 11px; text-align: left">
                    DATE</td>
                <td style="width: 134px; height: 11px; text-align: left">
                    :
                    <asp:Label ID="lbldate" runat="server" Width="108px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    ASSURED'S NAME</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblassuredname" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    POLICY NO.</td>
                <td style="width: 161px; height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    CLASS OF INSURANCE</td>
                <td style="width: 161px; height: 12px; text-align: left">
                    : LIFE</td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    FULL AMT. OF BONUS RS.</td>
                <td style="width: 161px; height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblfullbons" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px;">
                </td>
                <td style="width: 511px; text-align: left; height: 12px;">
                    <asp:Label ID="Label1" runat="server" Visible="False" Width="140px">OLD LOAN NO.</asp:Label></td>
                <td style="width: 161px; text-align: left; height: 12px;">
                    <asp:Label ID="lbloldloanNo" runat="server" Visible="False" Width="140px"></asp:Label></td>
                <td style="width: 152px; text-align: left; height: 12px;">
                </td>
                <td style="width: 134px; text-align: left; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px;">
                </td>
                <td style="width: 511px; text-align: left; height: 12px;">
                    <asp:Label ID="Label2" runat="server" Visible="False" Width="140px">OLD LOAN CAPITAL</asp:Label></td>
                <td style="width: 161px; text-align: left; height: 12px;">
                    <asp:Label ID="lbloldLoanCapital" runat="server" Visible="False" Width="140px"></asp:Label></td>
                <td style="width: 152px; text-align: left; height: 12px;">
                </td>
                <td style="width: 134px; text-align: left; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px;">
                </td>
                <td style="width: 511px; text-align: left; height: 12px;">
                    <asp:Label ID="Label3" runat="server" Visible="False" Width="140px">OLD LOAN INTEREST</asp:Label></td>
                <td style="width: 161px; text-align: left; height: 12px;">
                    <asp:Label ID="lbloldLoanInterest" runat="server" Visible="False" Width="140px"></asp:Label></td>
                <td style="width: 152px; text-align: left; height: 12px;">
                </td>
                <td style="width: 134px; text-align: left; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    SURRENDER NO.</td>
                <td style="width: 161px; height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblloanno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    SURRENDER VALUE RS.</td>
                <td style="width: 161px; height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblloanval" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 6px">
                </td>
                <td style="width: 520px; height: 6px; text-align: left">
                </td>
                <td colspan="3" style="height: 6px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    NET AMOUNT PAYABLE RS.</td>
                <td style="width: 161px; height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblamtinfigures" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    NET AMOUNT PAYABLE</td>
                <td colspan="3" style="vertical-align: top; height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblamtinwords" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: center">
                    (IN WORDS)</td>
                <td style="width: 161px; height: 12px; text-align: left">
                </td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    NAME OF BANK, BRANCH</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblbkbranch" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    BANK ACCOUNT NO.</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblacctno" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    NAME OF PAYEE</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblnameofpayee" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    NIC NO. /PASSPORT NO.</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    :
                    <asp:Label ID="lblnicorpassport" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 6px">
                </td>
                <td style="width: 520px; height: 6px; text-align: left">
                </td>
                <td style="width: 161px; height: 6px; text-align: left">
                </td>
                <td style="width: 152px; height: 6px; text-align: left">
                </td>
                <td style="width: 134px; height: 6px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                </td>
                <td style="width: 161px; height: 12px; text-align: center">
                    ................................</td>
                <td colspan="2" style="height: 12px; text-align: center">
                    .......................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                </td>
                <td style="width: 161px; height: 12px; text-align: center">
                    PREPARED BY</td>
                <td colspan="2" style="height: 12px; text-align: center">
                    CHECKED BY</td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 10px; height: 12px; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 520px; height: 12px; text-align: left">
                    <span style="font-size: 8pt">DATE</span></td>
                <td style="font-size: 10pt; width: 161px; height: 12px; text-align: left">
                    <span style="font-size: 8pt">: </span>
                    <asp:Label ID="lblcurrentdate" runat="server" Font-Names="Arial" Font-Size="8pt"
                        Width="108px"></asp:Label></td>
                <td style="font-size: 10pt; width: 152px; height: 12px; text-align: left">
                    <span style="font-size: 8pt">: </span>
                    <asp:Label ID="lblcurrenttime" runat="server" Font-Size="8pt" Width="108px"></asp:Label></td>
                <td style="font-size: 10pt; width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                </td>
                <td style="width: 161px; height: 12px; text-align: left">
                </td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px; text-align: justify">
                    DECLARATION : I CERTIFY TO MY PERSONAL KNOWLEDGE/ON CERTIFICATES/DOCUMENTS IN THE
                    RELEVANT FILE THAT THE ABOVE MENTIONED TRANSACTION WAS DULY APPROVED AND THAT THE
                    PAYMENT OF THE AMOUNT STATED IN THIS VOUCHER IN WORDS AND FIGURES TO THE PAYEE SHOWN
                    HEREIN IS IN ACCORDANCE WITH THE CONTRACT REGULATIONS AND THAT ALL SUPPLIES/SERVICES
                    HAS BEEN DULY PERFORMED/RENDERED.<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                        prefix="o" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><?xml
                            namespace="" prefix="O" ?><o:p></o:p></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                </td>
                <td style="width: 161px; height: 12px; text-align: left">
                </td>
                <td style="width: 152px; height: 12px; text-align: left">
                </td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    CERTIFYING OFFICER</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    DESIGNATION</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    SIGNATURE</td>
                <td colspan="3" style="height: 12px; text-align: left">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 6px">
                </td>
                <td style="width: 520px; height: 6px; text-align: left">
                </td>
                <td style="width: 161px; height: 6px; text-align: left">
                </td>
                <td style="width: 152px; height: 6px; text-align: left">
                </td>
                <td style="width: 134px; height: 6px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    DATE OF CHEQUE</td>
                <td colspan="2" style="height: 12px; text-align: left">
                    : ...............................................</td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    CHEQUE NUMBER</td>
                <td colspan="2" style="height: 12px; text-align: left">
                    : ...............................................</td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    ACOUNT CODE</td>
                <td colspan="2" style="height: 12px; text-align: left">
                    : 002392</td>
                <td style="width: 134px; height: 12px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 7px">
                </td>
                <td style="width: 520px; height: 7px; text-align: left">
                </td>
                <td style="width: 161px; height: 7px; text-align: left">
                </td>
                <td style="width: 152px; height: 7px; text-align: left">
                </td>
                <td style="width: 134px; height: 7px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        CHEQUE TO BE POSTED TO<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><o:p></o:p></p>
                </td>
                <td colspan="3" style="height: 12px; text-align: left">
                    <asp:Label ID="lblad1" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                </td>
                <td colspan="3" style="height: 12px; text-align: left">
                    <asp:Label ID="lblad2" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 12px">
                </td>
                <td style="width: 520px; height: 12px; text-align: left">
                </td>
                <td colspan="3" style="height: 12px; text-align: left">
                    <asp:Label ID="lblad3" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 6px">
                    <span style="font-family: Courier New">&nbsp;</span></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px; text-align: left">
                    <span style="font-family: Courier New">
                        <asp:Label ID="lblcurrentdate2" runat="server" Font-Names="Arial" Font-Size="8pt"
                            Width="108px"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Label ID="lblcurrenttime2" runat="server" Font-Names="Arial" Font-Size="8pt"
                            Width="108px"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Label ID="lblipaddr" runat="server" Font-Names="Arial" Font-Size="8pt" Width="108px"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Label ID="lblepf" runat="server" Font-Names="Arial" Font-Size="8pt" Width="108px"></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 520px; height: 18px; text-align: left">
                    <span style="font-family: Courier New"></span>
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                    <strong>Reprint</strong></td>
            </tr>
        </table>
    
   
    </form>
</body>
</html>
