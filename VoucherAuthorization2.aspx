<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherAuthorization2.aspx.cs" Inherits="MAS_Claim_Payments.VoucherAuthorization2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 197px;
        }
        .auto-style2 {
            width: 557px;
        }
        .auto-style3 {
            width: 631px;
        }
        .auto-style4 {
            width: 237px;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1" style="font-family: 'Trebuchet MS'; font-size: 11pt">
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="auto-style5" style="text-align: center; font-weight: 700; color: SteelBlue">
                VOUCHER AUTHORIZATION</td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" class="style16">
                &nbsp;</td>
            <td style="text-align: center">
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="lblPolicyNo" runat="server" Font-Bold="False" Style="text-align: center" 
                    Text="Policy No"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lbl2" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" 
                    Font-Size="Smaller" Style="text-align: center" Text=":"></asp:Label>
&nbsp;<asp:Label ID="lblPolicyNo2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblClaimNo" runat="server" Font-Bold="False" Style="text-align: center">Claim No</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lbl6" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" 
                    Font-Size="Smaller" Style="text-align: center" Text=":"></asp:Label>
&nbsp;<asp:Label ID="lblClaimNo2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="lblInsuredName" runat="server" Font-Bold="False" Style="text-align: center" 
                    Text="Insured Name"></asp:Label>
                        </td>
                        <td colspan="3" style="text-align: left">
                            <asp:Label ID="lbl5" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" 
                    Font-Size="Smaller" Style="text-align: center" Text=":"></asp:Label>
&nbsp;<asp:Label ID="lblInsuredName2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: left">
                            <table align="left" class="style31" 
                                style="border: 1px solid #C0C0C0; border-collapse: collapse; ">
                                <tr style="background-color: #f6f6f6">
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblVouNo1" runat="server" Font-Bold="False" style="text-align: center" Text="Voucher No"></asp:Label>
                                    </td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblVoucherNo2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblAmount" runat="server" Font-Bold="False" style="text-align: center" Text="Amount"></asp:Label>
                                    </td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblNetAmtPay2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        Claim date</td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblClmDate" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        Bank</td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblBank2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                        <asp:Label ID="lblComma" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" 
                                            Font-Size="Smaller" style="text-align: center">,</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        Branch</td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblBranch2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblAccNo" runat="server" Font-Bold="False" style="text-align: center" Text="Account No"></asp:Label>
                                    </td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblAccountNo2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblNICPassport" runat="server" Font-Bold="False" style="text-align: center" 
                                            Text="NIC No"></asp:Label>
                                    </td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblNICPassport2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" 
                                        
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblPayeeName1" runat="server" Font-Bold="False" Style="text-align: center" 
                        Text="Payee Name"></asp:Label>
                                    </td>
                                    <td class="auto-style2" 
                                        
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblPayeeName2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                                    </td>
                                </tr>
                                

                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <a name="pageup15">
                                        <asp:Label ID="lblMobileNo1" runat="server" Font-Bold="False" Style="text-align: center" 
                    Text="Mobile No"></asp:Label>
                                        </a>
                                    </td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <a name="pageup18">
                                        <asp:Label ID="lblMobileNo2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" 
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <a name="pageup16">
                                        <asp:Label ID="lblEmailAdrs1" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="Smaller" Style="text-align: center; font-size: small;" 
                    Text="Email Address"></asp:Label>
                                        </a>
                                    </td>
                                    <td class="auto-style2" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <a name="pageup19">
                                        <asp:Label ID="lblEmailAdrs2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="Smaller" Style="text-align: center; font-size: small;"></asp:Label>
                                        </a>
                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: left">
                            &nbsp; &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td style="text-align: center" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" class="style16">
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnSubmit" class="button button1" runat="server" OnClick="btnSubmit_Click" Text="Authorize" />
                <asp:Button ID="btnBack" class="button button1" runat="server" CausesValidation="False" OnClick="btnBack_Click" Text="Back" />
            </td>
            <td style="text-align: center" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left" class="style16">
                &nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="False" ForeColor="Red" 
                    Style="text-align: center"></asp:Label>
                <asp:Label ID="lblMessage2" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Style="text-align: center"></asp:Label>
                &nbsp;
            </td>
            <td style="text-align: left" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="style16">
                &nbsp;</td>
            <td style="text-align: right">
                &nbsp;</td>
            <td style="text-align: right" class="auto-style1">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
