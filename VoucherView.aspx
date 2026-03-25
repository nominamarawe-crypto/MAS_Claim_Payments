<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherView.aspx.cs" Inherits="MAS_Claim_Payments.VoucherView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style21
        {
            width: 100%;
        }
        .style22
        {
            text-align: left;
        }
        .style38
        {
            text-align: left;
        }
        .style47
        {
            text-align: left;
            height: 16px;
        }
        .auto-style1 {
        text-align: left;
        width: 136px;
    }
        .auto-style2 {
        text-align: left;
        height: 16px;
        width: 136px;
    }
        .auto-style3 {
        text-align: left;
        width: 437px;
    }
        .auto-style4 {
        text-align: left;
        height: 16px;
        width: 437px;
    }
        .auto-style5 {
            text-align: left;
            width: 136px;
            height: 24px;
        }
        .auto-style6 {
            text-align: left;
            width: 437px;
            height: 24px;
        }
        .auto-style7 {
            width: 823px;
        }
        .auto-style8 {
            text-align: center;
            height: 25px;
            font-size: small;
        }
    .auto-style9 {
        text-align: center;
    }
    .auto-style10 {
        text-align: left;
        width: 93px;
    }
    .auto-style11 {
        text-align: right;
    }
    .auto-style12 {
        height: 25px;
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style21">
        <tr>
            <td class="auto-style8" colspan="4" style="text-align: center; font-weight: 700; color: SteelBlue">
                VOUCHER CREATION</td>
        </tr>
        <tr>
            <td class="auto-style10">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="lblPolicyNo" runat="server" Font-Bold="True" Style="text-align: center" Text="Policy No"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:Label ID="lbl2" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="Smaller" Style="text-align: center" Text=":"></asp:Label>
                &nbsp;<asp:Label ID="lblPolicyNo2" runat="server" Font-Bold="True" Style="text-align: center"></asp:Label>
            </td>
            <td class="auto-style11">
                <asp:Label ID="lblClaimNo" runat="server" Font-Bold="True" Style="text-align: center">Claim No</asp:Label>
            </td>
            <td style="text-align: left">
                <asp:Label ID="lbl6" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="Smaller" Style="text-align: center" Text=":"></asp:Label>
                &nbsp;<asp:Label ID="lblClaimNo2" runat="server" Font-Bold="True" Style="text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="lblInsuredName" runat="server" Font-Bold="True" Style="text-align: center" Text="Insured Name"></asp:Label>
            </td>
            <td colspan="3" style="text-align: left">
                <asp:Label ID="lbl5" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="Smaller" Style="text-align: center" Text=":"></asp:Label>
                &nbsp;<asp:Label ID="lblInsuredName2" runat="server" Font-Bold="True" Style="text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">
                <table align="left" class="auto-style7" style="border: 1px solid #C0C0C0; border-collapse: collapse; ">
                    <tr>
                        <td class="auto-style1" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                            <asp:Label ID="lblAmount" runat="server" Font-Bold="False" style="text-align: center" Text="Amount"></asp:Label>
                        </td>
                        <td class="auto-style3" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                            <asp:Label ID="lblNetAmtPay2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                               
                                <tr>
                                    <td class="auto-style1" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        Bank</td>
                                    <td class="auto-style3" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblBank2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                    </tr>
                               
                                <tr>
                                    <td class="auto-style1" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        Branch</td>
                                    <td class="auto-style3" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblBranch2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                            <asp:Label ID="lblAccNo" runat="server" Font-Bold="False" style="text-align: center" Text="Account No"></asp:Label>
                        </td>
                        <td class="auto-style3" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                            <asp:Label ID="lblAccountNo2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                               
                                <tr>
                                    <td class="auto-style2" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblNICPassport" runat="server" Font-Bold="False" style="text-align: center" Text="NIC No"></asp:Label>
                                    </td>
                                    <td class="auto-style4" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblNICPassport2" runat="server" Font-Bold="False" style="text-align: center"></asp:Label>
                                    </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                            <asp:Label ID="lblPayeeName1" runat="server" Font-Bold="False" Style="text-align: center" Text="Payee Name"></asp:Label>
                        </td>
                        <td class="auto-style6" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                            <asp:Label ID="lblPayeeName2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                                
                                <tr>
                                    <td class="auto-style2" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">
                                        <asp:Label ID="lblTelephoneNo1" runat="server" Font-Bold="False" Style="text-align: center" Text="Contact No"></asp:Label>
                                    </td>
                                    <td class="auto-style4" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">
                                        <asp:Label ID="lblTelephoneNo2" runat="server" Font-Bold="False" Style="text-align: center"></asp:Label>
                                    </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;"><a name="pageup16">
                            <asp:Label ID="lblEmailAdrs1" runat="server" Font-Bold="False" Style="text-align: center; font-size: small;" Text="Email Address"></asp:Label>
                            </a></td>
                        <td class="auto-style4" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0"><a name="pageup19">
                            <asp:Label ID="lblEmailAdrs2" runat="server" Font-Bold="False" Style="text-align: center; font-size: small;"></asp:Label>
                            </a></td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">Claim Type</td>
                        <td class="auto-style4" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0"><a name="pageup20">
                            <asp:Label ID="lblClmType" runat="server" Font-Bold="False" Style="text-align: center; font-size: small;"></asp:Label>
                            </a></td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">Payment Type</td>
                        <td class="auto-style4" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0"><a name="pageup21">
                            <asp:Label ID="lblPaymntType" runat="server" Font-Bold="False" Style="text-align: center; font-size: small;"></asp:Label>
                            </a></td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">Claim Date</td>
                        <td class="auto-style4" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0"><a name="pageup22">
                            <asp:Label ID="lblClmDt" runat="server" Font-Bold="False" Style="text-align: center; font-size: small;"></asp:Label>
                            </a>&nbsp; </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style9">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Create Voucher" />                
                <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print" />
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style12"><asp:Label ID="lblSubmitError" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblSuccessMsg" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
