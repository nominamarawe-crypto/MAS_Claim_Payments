<%@ Page Title="Edit Voucher" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherEdit.aspx.cs" Inherits="MAS_Claim_Payments.VoucherEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 { width: 65%; }
        .style23 { height: 22px; font-size: medium; width: 19px; }
        .style3 { height: 22px; font-size: medium; }
        .style27 { width: 19px; }
        .style25 { text-align: left; width: 19px; }
        .style6 { text-align: left; }
        .style16 { width: 214px; }
        .style10 { width: 240px; }
        .style30 { color: #0000FF; }
        .style5 { color: #0000FF; }
        .style33 { width: 133px; text-align: left; }
        .style26 { width: 19px; text-align: left; height: 17px; }
        .style13 { width: 133px; text-align: left; height: 17px; }
        .style29 { height: 2px; }
        .auto-style1 { font-size: small; }
        .auto-style2 { width: 19px; height: 49px; }
        .auto-style3 { height: 49px; }
        .auto-style4 { text-align: left; width: 19px; height: 25px; }
        .auto-style5 { text-align: left; height: 25px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" class="style1" style="font-family: 'Trebuchet MS'; font-size: small; color: #000000;">
        <tr>
            <td class="style23" style="text-align: center; font-weight: 700; color: SteelBlue">&nbsp;</td>
            <td class="style3" colspan="2" style="text-align: center; font-weight: 700; color: SteelBlue">EDIT VOUCHER</td>
        </tr>
        <tr>
            <td align="center" class="style27">&nbsp;</td>
            <td align="center" colspan="2" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="style26">&nbsp;</td>
            <td class="style13">NIC Number</td>
            <td class="style30" style="text-align: left">
                :<asp:TextBox ID="txtNIC" runat="server" MaxLength="12" Width="150px"></asp:TextBox>
                <span class="style30">
                    <asp:RequiredFieldValidator ID="rfvNIC" runat="server" ControlToValidate="txtNIC" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">&nbsp;</td>
            <td class="style16">
                <asp:RegularExpressionValidator ID="regExpValNIC" runat="server" ControlToValidate="txtNIC" ErrorMessage="Invalid NIC No Format" ForeColor="Red" ValidationExpression="[0-9]{9}[V|v|X|x]|[A-Z][0-9]*|[1-2][0-9]{11}|0"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" style="text-align: center"></td>
            <td colspan="3" style="text-align: center" class="auto-style3">
                <asp:Button ID="btnBack" runat="server" Text="Back to Voucher Creation" CausesValidation="False" CssClass="button button1" OnClick="btnBack_Click" />
                <asp:Button ID="btnSubmit" runat="server" CssClass="button button1" OnClick="btnSubmit_Click" Text="Edit" />
                <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="button button1" OnClick="btnReset_Click" Text="Reset" />
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

   
        <asp:Panel ID="pnlGrid" runat="server" Visible="false">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">
                    <asp:GridView ID="gvClaims" runat="server" CssClass="grid" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="gvClaims_SelectedIndexChanged" DataKeyNames="CLAIM_NO">
                        <Columns>
                            <asp:BoundField DataField="CLAIM_NO" HeaderText="Claim No" />
                            <asp:BoundField DataField="POL_NO" HeaderText="Policy No" />
                            <asp:BoundField DataField="INSURED_NAME" HeaderText="Insured Name" />
                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:N2}" />
                            <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </asp:Panel>
    </table>
</asp:Content>