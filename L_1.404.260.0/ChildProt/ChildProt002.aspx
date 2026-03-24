<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildProt002.aspx.cs" Inherits="ChildProt_ChildProt002" %>
<%@ PreviousPageType VirtualPath ="~/ChildProt/ChildProt001.aspx" %>
<%@ Reference Page ="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Tahoma"><span style="font-size: 8pt"><span><span><strong>Sri Lanka
            Insurance -</strong>
        </span>Child Protection Vouchers</span><br />
        </span></span><span style="font-size: 8pt; font-family: Tahoma">
            <br />
            <asp:GridView ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="618px" 
            OnPageIndexChanging="DataGrid1_PageIndexChanging">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:HyperLinkField DataTextField="vouno" HeaderText="Voucher No." />
                    <asp:BoundField DataField="payee" HeaderText="Payee" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="amount" DataFormatString="{0:N}" HeaderText="Voucher Amount"
                        HtmlEncode="False" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblSlicvou" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Text="SLIC Vouchers" Visible="False" Font-Size="8pt"></asp:Label><br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging"
                Width="618px">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:HyperLinkField DataTextField="Url" HeaderText="Voucher No." />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Amount" HeaderText="Voucher Amount" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        <br />
        <br />
        </span>
        <br />
        <asp:CheckBox ID="Signature" OnCheckedChanged="ChkSig" runat="server" Text="Display Digital Signature" AutoPostBack="true"/>
        <br />
        <br />
        <br />
        <span style="font-size: 8pt; font-family: Tahoma"></span>
    
    </div>
    </form>
</body>
</html>
