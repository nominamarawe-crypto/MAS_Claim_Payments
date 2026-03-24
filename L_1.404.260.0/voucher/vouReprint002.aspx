<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouReprint002.aspx.cs" Inherits="vouReprint002" %>
<%@ PreviousPageType VirtualPath="~/voucher/vouReprint001.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Death Claims</title>
    
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Death Claim Voucher Reprint<br />
            <asp:GridView ID="DataGrid1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Bold="False" GridLines="None"
                Style="font-size: 10pt; font-family: 'Trebuchet MS'" Width="618px">
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
        </span></strong>
    
    </div>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Text="ADB Vouchers" Visible="False"></asp:Label><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge"
            BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Bold="False" GridLines="None"
            Style="font-size: 10pt; font-family: 'Trebuchet MS'" Width="618px">
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
        <br />
        <asp:Label ID="lblSlivou" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Text="SLIC Vouchers" Visible="False"></asp:Label>&nbsp;<br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge"
            BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Bold="False" GridLines="None"
            Style="font-size: 10pt; font-family: 'Trebuchet MS'" Width="618px">
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <Columns>
                <asp:HyperLinkField DataTextField="Url" HeaderText="Voucher No." />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Amount" HeaderText="Voucher Amount" />
            </Columns>
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        </asp:GridView>
        <br />
            <asp:CheckBox ID="Signature" OnCheckedChanged="ChkSig" runat="server" Text="Display Digital Signature" AutoPostBack="true"/>
        <br />
        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            ForeColor="#FF3333" Text="No Vouchers Created Yet!" Visible="False" Width="244px"></asp:Label><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="14pt" ForeColor="Blue" NavigateUrl="~/voucher/vouPrintMain.aspx">Back</asp:HyperLink>
    </form>
</body>
</html>
