<%@ Page Title="Reverse Voucher" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherReverse.aspx.cs" Inherits="MAS_Claim_Payments.VoucherReverse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .container { max-width: 900px; margin: 20px auto; padding: 20px; border: 1px solid #ccc; border-radius: 8px; }
        .search-panel { background: #f9f9f9; padding: 15px; margin-bottom: 20px; border-radius: 5px; }
        .field-row { margin-bottom: 12px; }
        .field-label { display: inline-block; width: 150px; font-weight: bold; }
        .field-value { display: inline-block; }
        .button-panel { margin-top: 20px; text-align: center; }
        .message { margin-top: 20px; color: red; font-weight: bold; text-align: center; }
        .voucher-grid { margin-top: 20px; margin-bottom: 20px; }
        .voucher-grid table { width: 100%; border-collapse: collapse; }
        .voucher-grid th, .voucher-grid td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .voucher-grid th { background-color: #f2f2f2; }
        .selected-row { background-color: #cce5ff; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Voucher Reversal</h2>

      
        <div class="search-panel">
            <div class="field-row">
                <span class="field-label">NIC Number:</span>
                <asp:TextBox ID="txtNIC" runat="server" Width="200px" />
                <asp:Button ID="btnSearch" runat="server" Text="Search Vouchers" OnClick="btnSearch_Click" />
            </div>
        </div>

        <asp:Panel ID="pnlVoucherGrid" runat="server" Visible="false" CssClass="voucher-grid">
            <h3>Select a Voucher to Reverse</h3>
          <asp:GridView ID="gvVouchers" runat="server" AutoGenerateColumns="False" 
    OnSelectedIndexChanged="gvVouchers_SelectedIndexChanged" DataKeyNames="VOU_NO"
    CssClass="gridview" GridLines="Both" CellPadding="4" ForeColor="#333333">
    <Columns>
        <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
        <asp:BoundField DataField="VOU_NO" HeaderText="Voucher No" />
        <asp:BoundField DataField="CLAIM_NO" HeaderText="Claim No" />
        <asp:BoundField DataField="POL_NO" HeaderText="Policy No" />
        <asp:BoundField DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="VOU_STATUS" HeaderText="Status" />
        <asp:BoundField DataField="PAYEE_NAME" HeaderText="Payee" />
    </Columns>
    <SelectedRowStyle BackColor="#cce5ff" />
</asp:GridView>
        </asp:Panel>

       
        <asp:Panel ID="pnlVoucherDetails" runat="server" Visible="false">
            <hr />
            <div class="field-row"><span class="field-label">Voucher No:</span><asp:Label ID="lblVouNum" runat="server" CssClass="field-value" /></div>
            <div class="field-row"><span class="field-label">Claim No:</span><asp:Label ID="lblClaimNo" runat="server" CssClass="field-value" /></div>
            <div class="field-row"><span class="field-label">Policy No:</span><asp:Label ID="lblPolicyNo" runat="server" CssClass="field-value" /></div>
            <div class="field-row"><span class="field-label">Insured Name:</span><asp:Label ID="lblInsuredName" runat="server" CssClass="field-value" /></div>
            <div class="field-row"><span class="field-label">Net Payable:</span><asp:Label ID="lblNetAmount" runat="server" CssClass="field-value" /></div>
            <div class="field-row"><span class="field-label">Payee Name:</span><asp:Label ID="lblPayeeName" runat="server" CssClass="field-value" /></div>
            <div class="field-row"><span class="field-label">Voucher Status:</span><asp:Label ID="lblStatus" runat="server" CssClass="field-value" /></div>
            <div class="button-panel">
                <asp:Button ID="btnReverse" runat="server" Text="Reverse Voucher" OnClick="btnReverse_Click" OnClientClick="return confirm('Are you sure you want to reverse this voucher?');" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>
        </asp:Panel>

        <div class="message"><asp:Label ID="lblMessage" runat="server" /></div>
    </div>
</asp:Content>