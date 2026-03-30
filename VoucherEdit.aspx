<%@ Page Title="Edit Voucher" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherEdit.aspx.cs" Inherits="MAS_Claim_Payments.VoucherEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 { width: 65%; }
        .style23 { height: 22px; font-size: medium; width: 19px; }
        .style3 { height: 22px; font-size: medium; }
        .style27 { width: 19px; }
        .style26 { width: 19px; text-align: left; height: 17px; }
        .style13 { width: 133px; text-align: left; height: 17px; }
        .style30 { color: #0000FF; }
        .style25 { text-align: left; width: 19px; }
        .style6 { text-align: center; }
        .auto-style1 { text-align: left; width: 19px; height: 229px; }
        .auto-style2 { text-align: center; height: 229px; }
        .auto-style3 { width: 19px; height: 49px; }
        .auto-style4 { height: 49px; }
        .button { background-color: #008CBA; color: white; padding: 5px 10px; border: none; cursor: pointer; }
        .grid { width: 100%; margin-top: 20px; border-collapse: collapse; }
        .grid th, .grid td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .grid th { background-color: #4A3C8C; color: white; }
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
            <td class="auto-style3" style="text-align: center"></td>
            <td colspan="2" style="text-align: center" class="auto-style4">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" OnClick="btnReset_Click" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <%-- Grid for multiple claims --%>
        <asp:Panel ID="pnlGrid" runat="server" Visible="false">
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style2" colspan="2">
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

        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Button ID="btnBack" runat="server" Text="Back to Voucher Creation" CausesValidation="False" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>