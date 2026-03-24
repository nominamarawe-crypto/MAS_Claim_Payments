<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildProtPay001.aspx.cs" Inherits="ChildProt_ChildProtPay001" %>
<%@ PreviousPageType VirtualPath ="~/ChildProt/ChildProtPay010.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
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
        </span>Child Protection Periodic Claims Due From
            <asp:Label ID="lblFrom" runat="server" Text="Label" Width="84px"></asp:Label>
            to
            <asp:Label ID="lblTo" runat="server" Text="Label" Width="72px"></asp:Label><br />
        </span></strong>
        <br />
        
        <asp:Label  ID="RNotPrinted" runat="server" Text="Discharge Receipt Not Printed" Style="font-weight:bold" Visible="false"> </asp:Label>
        <br />
        <br />
        <asp:GridView ID="DataGrid1" runat="server" AllowPaging="False" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge"
            BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Bold="False" GridLines="None"
            Style="font-size: 10pt;
            font-family: 'Trebuchet MS'" Width="618px" >
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <Columns>
                <asp:HyperLinkField DataTextField="polNo" HeaderText="Policy No" />
                <asp:BoundField DataField="table" HeaderText="Table" />
                <asp:BoundField DataField="startDt" HeaderText="Start Date" />
                <asp:BoundField DataField="enddate" HeaderText="End Date" />
                <asp:BoundField DataField="maturityDt" HeaderText="Maturity Date" />
            </Columns>
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        </asp:GridView>

        <br />
        <br />
            <asp:Label  ID="RPrinted" runat="server" Text="Discharge Receipt Printed" Style="font-weight:bold" Visible="false"> </asp:Label>
        <br />
        <br />
            <asp:GridView ID="DataGrid2" runat="server" AllowPaging="False" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge"
            BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Bold="False" GridLines="None"
            Style="font-size: 10pt;
            font-family: 'Trebuchet MS'" Width="618px" >
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <Columns>
                <asp:HyperLinkField DataTextField="polNo" HeaderText="Policy No" />
                <asp:BoundField DataField="table" HeaderText="Table" />
                <asp:BoundField DataField="startDt" HeaderText="Start Date" />
                <asp:BoundField DataField="enddate" HeaderText="End Date" />
                <asp:BoundField DataField="maturityDt" HeaderText="Maturity Date" />
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
