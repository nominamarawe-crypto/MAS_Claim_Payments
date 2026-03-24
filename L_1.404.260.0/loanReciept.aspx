<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loanReciept.aspx.cs" Inherits="loanReciept" %>
<%@ PreviousPageType VirtualPath="~/dthReg002.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Loan Reciept</title>
</head>
<body onload ="window.print()" style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <br />
        <table style="width: 695px">
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td colspan="3" style="height: 22px">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td colspan="3" style="height: 22px">
                    <strong>SRI LANKA INSURANCE - LOAN RECIEPT</strong></td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td colspan="3" style="height: 22px">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 23px;">
                </td>
                <td colspan="3" style="height: 23px">
                    <asp:Label ID="lblbrn" runat="server" Width="162px"></asp:Label></td>
                <td style="width: 29px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                    LIFE POLICY LOANS</td>
                <td colspan="2" style="text-align: right; height: 22px;">
                    LOAN SETTLEMENT FROM DEATH&nbsp; CLAIMS</td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; border-bottom: black thin dashed;" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px">
                </td>
                <td style="width: 174px; height: 21px; text-align: left">
                    &nbsp; &nbsp; RECIEPT NO.</td>
                <td style="width: 198px; height: 21px; text-align: left">
                    :<asp:Label ID="lblrcptno" runat="server" Width="174px"></asp:Label></td>
                <td style="width: 185px; height: 21px; text-align: left">
                    DATE&nbsp; :<asp:Label ID="lbldate" runat="server" Width="88px"></asp:Label></td>
                <td style="width: 29px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; text-align: left; height: 22px;">
                    &nbsp; &nbsp;
                </td>
                <td style="width: 198px; text-align: left; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="width: 174px; text-align: left; height: 21px;">
                    &nbsp; &nbsp; POLICY NO.</td>
                <td style="width: 198px; text-align: left; height: 21px;">
                    :<asp:Label ID="lblpolno" runat="server" Width="174px"></asp:Label></td>
                <td style="width: 185px; height: 21px;">
                </td>
                <td style="width: 29px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; text-align: left; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="width: 174px; text-align: left; height: 21px;">
                    &nbsp; &nbsp; LOAN NO.</td>
                <td style="width: 198px; text-align: left; height: 21px;">
                    :<asp:Label ID="lblloanno" runat="server" Width="174px"></asp:Label></td>
                <td style="width: 185px; height: 21px;">
                </td>
                <td style="width: 29px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="width: 174px; text-align: left; height: 21px;">
                    &nbsp; &nbsp;&nbsp; PAID BY</td>
                <td colspan="2" style="text-align: left; height: 21px;">
                    :
                    <asp:Label ID="lblname" runat="server" Width="416px"></asp:Label></td>
                <td style="width: 29px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 20px;">
                </td>
                <td style="width: 174px; text-align: left; height: 20px;">
                    &nbsp; &nbsp; &nbsp;ADDRESS</td>
                <td colspan="2" style="text-align: left; height: 20px;">
                    :<asp:Label ID="lblad1" runat="server" Width="416px"></asp:Label></td>
                <td style="width: 29px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 20px">
                </td>
                <td style="width: 174px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    &nbsp;<asp:Label ID="lblad2" runat="server" Width="416px"></asp:Label></td>
                <td style="width: 29px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 20px;">
                </td>
                <td style="width: 174px; height: 20px;">
                </td>
                <td colspan="2" style="text-align: left; height: 20px;">
                    &nbsp;<asp:Label ID="lblad3" runat="server" Width="416px"></asp:Label></td>
                <td style="width: 29px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 20px;">
                </td>
                <td style="width: 174px; height: 20px;">
                </td>
                <td colspan="2" style="text-align: left; height: 20px;">
                    &nbsp;<asp:Label ID="lblad4" runat="server" Width="416px"></asp:Label></td>
                <td style="width: 29px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; border-bottom: black thin dashed;" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; text-align: left; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px">
                </td>
                <td style="width: 174px; height: 21px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; CAPITAL</td>
                <td style="width: 198px; height: 21px">
                </td>
                <td style="width: 185px; height: 21px; text-align: left">
                    RS.<asp:Label ID="lblcapamt" runat="server" Width="114px"></asp:Label></td>
                <td style="width: 29px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; text-align: left; height: 22px;">
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; INTEREST</td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; text-align: left; height: 22px;">
                    RS.<asp:Label ID="lblintamt" runat="server" Width="114px"></asp:Label></td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; border-bottom: black thin dashed;" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="width: 174px; text-align: left; height: 21px;">
                    &nbsp; &nbsp; &nbsp;CLAIM AMOUNT</td>
                <td style="width: 198px; text-align: left; height: 21px;">
                    :<asp:Label ID="lblclaimno" runat="server" Width="174px"></asp:Label></td>
                <td style="width: 185px; text-align: left; height: 21px;">
                    RS.<asp:Label ID="lblclaimAmt" runat="server" Width="114px"></asp:Label></td>
                <td style="width: 29px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="width: 174px; text-align: left; height: 21px;">
                    &nbsp; &nbsp; &nbsp;AMOUNT RECIEVED</td>
                <td style="width: 198px; text-align: left; height: 21px;">
                    :</td>
                <td style="width: 185px; text-align: left; height: 21px;">
                    RS.<asp:Label ID="lblrecAmt" runat="server" Width="114px"></asp:Label></td>
                <td style="width: 29px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; text-align: left; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td colspan="3" style="height: 22px">
                    <asp:Label ID="lblamtinwords" runat="server" Width="492px"></asp:Label></td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 23px;">
                </td>
                <td style="width: 174px; height: 23px;">
                </td>
                <td style="width: 198px; height: 23px;">
                </td>
                <td style="width: 185px; height: 23px;">
                </td>
                <td style="width: 29px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px">
                    ................................................</td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px">
                    CASHIER</td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblcurrdate"
                        runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label
                        ID="lbltime" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblepf" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblipaddr" runat="server"></asp:Label></td>
                <td style="width: 29px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; height: 22px;">
                </td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="width: 174px; text-align: left; height: 22px;">
                    <span style="font-size: 8pt">Form No. 7124</span></td>
                <td style="width: 198px; height: 22px;">
                </td>
                <td style="width: 185px; height: 22px;">
                </td>
                <td style="width: 29px; height: 22px;">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
