<%@ Page Title="Reverse Voucher" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherReverse.aspx.cs" Inherits="MAS_Claim_Payments.VoucherReverse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 { width: 70%; }
        .style23 { height: 22px; font-size: medium; width: 19px; }
        .style3 { height: 22px; font-size: medium; }
        .style27 { width: 19px; }
        .style25 { text-align: left; width: 19px; }
        .style6 { text-align: left; }
        .style16 { width: 214px; }
        .style30 { color: #0000FF; }
        .style13 { width: 180px; text-align: left; height: 17px; }
        .style26 { width: 19px; text-align: left; height: 17px; }
        .auto-style1 { font-size: small; }
        .auto-style2 { width: 19px; height: 49px; }
        .auto-style3 { height: 49px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  
    <table align="center" class="style1" style="font-family: 'Trebuchet MS'; font-size: small; color: #000000;">

        <tr>
            <td class="style23" style="text-align: center; font-weight: 700; color: SteelBlue">
                &nbsp;
            </td>

            <td class="style3" colspan="2" style="text-align: center; font-weight: 700; color: SteelBlue">
                REVERSE VOUCHER
            </td>
        </tr>

        <tr>
            <td class="style27">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
        </tr>

        <tr>
            <td class="style26">&nbsp;</td>

            <td class="style13">
                Enter NIC 
            </td>

            <td class="style30" style="text-align: left">
                :
                <asp:TextBox ID="txtNIC" runat="server" Width="150px" MaxLength="12"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvNIC" runat="server"
                    ControlToValidate="txtNIC"
                    ErrorMessage="*"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="style25">&nbsp;</td>

            <td class="style6">&nbsp;</td>

            <td class="style16">
                <asp:RegularExpressionValidator ID="regExpValNIC" runat="server"
                    ControlToValidate="txtNIC"
                    ErrorMessage="Invalid NIC Format (e.g., 123456789V or 200012345678)"
                    ForeColor="Red"
                    ValidationExpression="^[0-9]{9}[VvXx]|[1-2][0-9]{11}$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style2"></td>

            <td colspan="2" class="auto-style3" style="text-align: center">

                <asp:Button ID="btnBackMain" runat="server"
                    Text="Back"
                    CssClass="button button1"
                    CausesValidation="False"
                    OnClick="btnBackMain_Click" />

                <asp:Button ID="btnSearch" runat="server"
                    Text="Search Vouchers"
                    CssClass="button button1"
                    OnClick="btnSearch_Click" />

                <asp:Button ID="btnReset" runat="server"
                    Text="Reset"
                    CssClass="button button1"
                    CausesValidation="False"
                    OnClick="btnReset_Click" />

            </td>
        </tr>

        <tr>
            <td class="style25">&nbsp;</td>

            <td class="style6" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

    </table>


    
    <asp:Panel ID="pnlVoucherGrid" runat="server" Visible="false">

        <table align="center" class="style1">

            <tr>
                <td class="auto-style1">&nbsp;</td>

                <td colspan="2">

                    <asp:GridView ID="gvVouchers" runat="server"
                        CssClass="grid"
                        AutoGenerateColumns="False"
                        DataKeyNames="VOU_NO"
                        OnSelectedIndexChanged="gvVouchers_SelectedIndexChanged">

                        <Columns>

                            <asp:BoundField DataField="VOU_NO" HeaderText="Voucher No" />

                            <asp:BoundField DataField="CLAIM_NO" HeaderText="Claim No" />

                            <asp:BoundField DataField="POL_NO" HeaderText="Policy No" />

                            <asp:BoundField DataField="PAYEE_NAME" HeaderText="Payee Name" />

                            <asp:BoundField DataField="AMOUNT"
                                HeaderText="Amount"
                                DataFormatString="{0:N2}" />

                            <asp:BoundField DataField="VOU_STATUS"
                                HeaderText="Voucher Status" />

                            <asp:CommandField ShowSelectButton="True"
                                SelectText="Select" />

                        </Columns>

                    </asp:GridView>

                </td>
            </tr>

        </table>

    </asp:Panel>


    <asp:Panel ID="pnlVoucherDetails" runat="server" Visible="false">

        <table align="center" class="style1"
            style="font-family: 'Trebuchet MS'; font-size: small; color: #000000;">

            <tr>
                <td colspan="3"
                    style="text-align: center; font-weight: 700; color: SteelBlue;">
                    VOUCHER DETAILS
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Voucher No</td>
                <td class="style30">:
                    <asp:Label ID="lblVouNum" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Claim No</td>
                <td class="style30">:
                    <asp:Label ID="lblClaimNo" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Policy No</td>
                <td class="style30">:
                    <asp:Label ID="lblPolicyNo" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Insured Name</td>
                <td class="style30">:
                    <asp:Label ID="lblInsuredName" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Net Amount</td>
                <td class="style30">:
                    <asp:Label ID="lblNetAmount" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Payee Name</td>
                <td class="style30">:
                    <asp:Label ID="lblPayeeName" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style26">&nbsp;</td>
                <td class="style13">Voucher Status</td>
                <td class="style30">:
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="3" style="text-align: center">&nbsp;</td>
            </tr>

            <tr>
                <td colspan="3" style="text-align: center">

                    <asp:Button ID="btnReverse" runat="server"
                        Text="Reverse Voucher"
                        CssClass="button button1"
                        OnClick="btnReverse_Click"
                        OnClientClick="return confirm('Are you sure you want to reverse this voucher?');" />

                    <asp:Button ID="btnBack" runat="server"
                        Text="Back"
                        CssClass="button button1"
                        CausesValidation="False"
                        OnClick="btnBack_Click" />

                </td>
            </tr>

        </table>

    </asp:Panel>

</asp:Content>