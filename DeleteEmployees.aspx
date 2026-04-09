<%@ Page Title="Delete Employee by NIC" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeBehind="DeleteEmployees.aspx.cs"
    Inherits="MAS_Claim_Payments.DeleteEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 65%;
        }
        .style23 {
            height: 22px;
            font-size: medium;
            width: 19px;
        }
        .style3 {
            height: 22px;
            font-size: medium;
        }
        .style27 {
            width: 19px;
        }
        .style25 {
            text-align: left;
            width: 19px;
        }
        .style6 {
            text-align: center;
        }
        .style10 {
            width: 240px;
        }
        .style30 {
            color: #0000FF;
        }
        .style5 {
            color: #0000FF;
        }
        .style33 {
            width: 133px;
            text-align: left;
        }
        .style26 {
            width: 19px;
            text-align: left;
            height: 17px;
        }
        .style13 {
            width: 133px;
            text-align: left;
            height: 17px;
        }
        .auto-style3 {
            width: 77%;
        }
        .auto-style4 {
            text-align: left;
        }
        .button {
            background-color: #008CBA;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
        .button1 {
            background-color: #008CBA;
        }
        .message-label {
            color: 
                
                ;
        }
        .details-panel {
            margin-top: 20px;
            border: 1px solid #ccc;
            padding: 15px;
            background-color: #f9f9f9;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            text-align: left;
        }
        .details-panel table {
            width: 100%;
            border-collapse: collapse;
        }
        .details-panel td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
        }
        .details-panel .label {
            font-weight: bold;
            width: 150px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" class="auto-style3" style="font-family: 'Trebuchet MS'; font-size: small; color: #000000;">
         <tr>
            <td class="style23" style="text-align: center; font-weight: 700; color: SteelBlue">&nbsp;</td>
            <td class="style3" colspan="2" style="text-align: center; font-weight: 700; color: SteelBlue">DELETE EMPLOYEE</td>
         </tr>
         <tr>
            <td align="center" class="style27">&nbsp;</td>
            <td align="center" colspan="2" style="text-align: left">&nbsp;</td>
         </tr>
         <tr>
            <td class="style26">&nbsp;</td>
            <td class="style13">Enter NIC</td>
            <td class="style30" style="text-align: left">:
                <asp:TextBox ID="txtNIC" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNIC" runat="server"
                    ControlToValidate="txtNIC" ErrorMessage="*"
                    ForeColor="Red" ValidationGroup="DeleteGroup" />
             </td>
         </tr>
         <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">&nbsp;</td>
            <td class="style16">&nbsp;</td>
         </tr>
         <tr>
            <td class="style27" style="text-align: center">&nbsp;</td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnView" runat="server" Text="View" 
                    CssClass="button button1" OnClick="btnView_Click" 
                    CausesValidation="false" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete"
                    CssClass="button button1" OnClick="btnDelete_Click"
                    ValidationGroup="DeleteGroup" />
                <asp:Button ID="btnReset" runat="server" Text="Reset"
                    CssClass="button button1" CausesValidation="false"
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

    <!-- Panel to display employee details -->
    <asp:Panel ID="pnlEmployeeDetails" runat="server" CssClass="details-panel" Visible="false">
        <h3>Employee Details</h3>
        <table>
            <tr><td class="label">SBU:</td><td><asp:Label ID="lblSBU" runat="server"></asp:Label></td></tr>
            <tr><td class="label">EPF:</td><td><asp:Label ID="lblEPF" runat="server"></asp:Label></td></tr>
            <tr><td class="label">Member Name:</td><td><asp:Label ID="lblMemberName" runat="server"></asp:Label></td></tr>
            <tr><td class="label">NIC:</td><td><asp:Label ID="lblDisplayNIC" runat="server"></asp:Label></td></tr>
            <tr><td class="label">Gender:</td><td><asp:Label ID="lblGender" runat="server"></asp:Label></td></tr>
            <tr><td class="label">Date of Birth:</td><td><asp:Label ID="lblDOB" runat="server"></asp:Label></td></tr>
            <tr><td class="label">Contact No:</td><td><asp:Label ID="lblContactNo" runat="server"></asp:Label></td></tr>
            <tr><td class="label">Email:</td><td><asp:Label ID="lblEmail" runat="server"></asp:Label></td></tr>
        </table>
    </asp:Panel>
</asp:Content>