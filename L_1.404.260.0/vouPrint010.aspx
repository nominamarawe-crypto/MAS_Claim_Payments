<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouPrint010.aspx.cs" Inherits="vouPrint010" %>
<%@ PreviousPageType VirtualPath="~/vouPrint001.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Policy Surrenders</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript">
    
    
  function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
</script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Surrender Voucher Printing</span></strong><br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt"
            ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="GridView1_SelectedIndexChanged"
            Width="650px">
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="LSSUFFIX" HeaderText="Ref. No." />
                <asp:BoundField DataField="LSPOLNO" HeaderText="Policy No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="LSVOUNO" HeaderText="Voucher No" />
                <asp:BoundField DataField="ENTDATE" HeaderText="Voucher Date" />
                <asp:BoundField DataField="LSAMT" HeaderText="Total Amount" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </div>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
            Font-Size="10pt" ForeColor="Blue" NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink>
    </form>
</body>
</html>
