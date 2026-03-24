<%@ Page Title="Delete Employee by NIC" Language="C#" MasterPageFile="~/Site1.Master"
AutoEventWireup="true" CodeBehind="DeleteEmployees.aspx.cs"
Inherits="MAS_Claim_Payments.DeleteEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .delete-table {
            width: 65%;
            margin: 0 auto;
            border-collapse: collapse;
        }
        .delete-table td {
            padding: 8px;
        }
        .header-cell {
            text-align: center;
            font-weight: 700;
            color: SteelBlue;
        }
        .separator {
            background-color: #D8E4F8;
            height: 5px;
        }
        .button {
            background-color: #008CBA;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
        .message-label {
            color: red;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table class="delete-table">
    <tr>
        <td class="header-cell" colspan="4">DELETE EMPLOYEE</td>
    </tr>

    <tr><td colspan="4" class="separator"></td></tr>

    <tr>
        <td></td>
        <td>Enter NIC</td>
        <td colspan="2">
            <asp:TextBox ID="txtNIC" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNIC" runat="server"
                ControlToValidate="txtNIC" ErrorMessage="*"
                ForeColor="Red" ValidationGroup="DeleteGroup" />
        </td>
    </tr>

    <tr><td colspan="4" class="separator"></td></tr>

    <tr>
        <td></td>
        <td colspan="3" align="center">
            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                CssClass="button" OnClick="btnDelete_Click"
                ValidationGroup="DeleteGroup" />

            <asp:Button ID="btnReset" runat="server" Text="Reset"
                CssClass="button" CausesValidation="false"
                OnClick="btnReset_Click" />
        </td>
    </tr>

    <tr>
        <td></td>
        <td colspan="3">
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
        </td>
    </tr>
</table>

</asp:Content>