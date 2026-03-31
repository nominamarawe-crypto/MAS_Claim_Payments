<%@ Page Title="Edit Claim" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherEditView.aspx.cs" Inherits="MAS_Claim_Payments.VoucherEditView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 { width: 100%; }
        .auto-style2 { text-align: center; font-weight: 700; color: SteelBlue; }
        .edit-table { width: 80%; margin: 0 auto; border-collapse: collapse; }
        .edit-table td { padding: 8px; vertical-align: top; }
        .label { font-weight: bold; width: 150px; }
        .button { background-color: #008CBA; color: white; padding: 5px 10px; border: none; cursor: pointer; margin: 5px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="2">EDIT CLAIM DETAILS</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblSuccessMsg" runat="server" ForeColor="Green"></asp:Label>
            </td>
        </tr>
    </table>

    <table class="edit-table">
        <tr>
            <td class="label">Policy No:</td>
            <td><asp:Label ID="lblPolicyNo2" runat="server"></asp:Label></td>
            <td class="label">Claim No:</td>
            <td><asp:Label ID="lblClaimNo2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Insured Name:</td>
            <td><asp:Label ID="lblInsuredName2" runat="server"></asp:Label></td>
            <td class="label">NIC:</td>
            <td><asp:Label ID="lblNICValue" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Claim Amount:</td>
            <td><asp:Label ID="lblAmountValue" runat="server"></asp:Label></td>
            <td class="label">Claim Date:</td>
            <td><asp:Label ID="lblClaimDateValue" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Claim Type:</td>
            <td><asp:Label ID="lblClaimTypeValue" runat="server"></asp:Label></td>
            <td class="label">Payment Type:</td>
            <td><asp:Label ID="lblPaymentTypeValue" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Payee Name:</td>
            <td colspan="3">
                <asp:Label ID="lblPayeeNameDisplay" runat="server" Font-Bold="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label">Bank:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" />
                <asp:RequiredFieldValidator ID="rfvBank" runat="server" ControlToValidate="ddlBank" InitialValue="0" ErrorMessage="*" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td class="label">Branch:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlBranch" runat="server" />
                <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="ddlBranch" InitialValue="0" ErrorMessage="*" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td class="label">Account No:</td>
            <td colspan="3">
                <asp:TextBox ID="txtAccountNo" runat="server" Width="250px" />
                <asp:RequiredFieldValidator ID="rfvAccount" runat="server" ControlToValidate="txtAccountNo" ErrorMessage="*" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revAccount" runat="server" ControlToValidate="txtAccountNo" ErrorMessage="Only numbers allowed" ForeColor="Red" ValidationExpression="[0-9]*" />
            </td>
        </tr>
        <tr>
            <td class="label">Contact No:</td>
            <td colspan="3">
                <asp:TextBox ID="txtContactNo" runat="server" Width="200px" />
                <asp:RegularExpressionValidator ID="revContact" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Invalid phone number" ForeColor="Red" ValidationExpression="[0-9]{10}" />
            </td>
        </tr>
        <tr>
            <td class="label">Email:</td>
            <td colspan="3">
                <asp:TextBox ID="txtEmail" runat="server" Width="300px" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="button" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" CausesValidation="False" />
                <asp:Button ID="btnPrint" runat="server" Text="Print Voucher" CssClass="button" OnClick="btnPrint_Click" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>