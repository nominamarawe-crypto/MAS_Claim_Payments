<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cvouauth002.aspx.cs" Inherits="cvouauth002" %>
<%@ PreviousPageType VirtualPath ="~/ChildProt/cvouauth001.aspx" %>
<%@ Reference Page ="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Child Protection Vouchers</span></strong><br />
        <br />
        <asp:GridView ID="DataGrid1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge"
            BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Bold="False" GridLines="None"
            Style="font-size: 10pt; font-family: 'Trebuchet MS'" Width="618px" PageSize="100">
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <Columns>
                <asp:HyperLinkField DataTextField="vouno" HeaderText="Voucher No." />
                <asp:BoundField DataField="payee" HeaderText="Payee" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="amount" HeaderText="Voucher Amount" />
            </Columns>
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
