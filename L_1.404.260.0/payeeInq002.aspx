<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payeeInq002.aspx.cs" Inherits="payeeInq002" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/payeeInq001.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
    
    
     function test(source, arguments)
    {
    	
     if (!IsNumeric(arguments.Value))
               {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
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
        </span>Payee Inquiry<br />
            <table style="font-weight: bold; font-size: 10pt; width: 579px; font-family: Trebuchet MS;
                background-color: #f0f0f0">
                <tr>
                    <td style="height: 20px; text-align: left">
                        Policy No</td>
                    <td style="height: 20px; text-align: left">
                        <asp:Label ID="lblpolno" runat="server" ForeColor="Blue" Width="138px"></asp:Label></td>
                    <td style="height: 20px; text-align: left">
                        Life Type</td>
                    <td style="height: 20px; text-align: left">
                        <asp:Label ID="lblmos" runat="server" ForeColor="Blue" Width="138px"></asp:Label></td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblassignee" runat="server" ForeColor="#0000FF" Text="Assignee" Width="138px"></asp:Label><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
                CellPadding="4" ForeColor="#333333" GridLines="None" Height="143px" HorizontalAlign="Center"
                Style="font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS'" Width="900px">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="ASS_STATUS" HeaderText="Status" ReadOnly="True" SortExpression="ASS_STATUS">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ASS_INITIAL" HeaderText="Initial" SortExpression="ASS_INITIAL">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ASS_SURNAME" HeaderText="Surname" SortExpression="ASS_SURNAME">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ASS_FULLNAME" HeaderText="Full Name" SortExpression="ASS_FULLNAME">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ASS_SHORTNAME" HeaderText="Short Name" SortExpression="ASS_SHORTNAME">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ASS_AD1" HeaderText="Address1" SortExpression="ASS_AD1">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ASS_AD1" HeaderText="Address2" SortExpression="ASS_AD1">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" VerticalAlign="Top" />
                <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Left" VerticalAlign="Top" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left"
                    VerticalAlign="Top" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </span></strong>
    
    </div>
        <br />
        <asp:Label ID="lblnom" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="12pt" ForeColor="Blue" Text="Nominee" Width="138px"></asp:Label><br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="143px" HorizontalAlign="Center"
            Style="font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS'" Width="900px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="nomno" HeaderText="Nominee No" SortExpression="nomno" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMNAM" HeaderText="Name" SortExpression="NOMNAM">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMDOB" HeaderText="Date of Birth" SortExpression="NOMDOB">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMNIC" HeaderText="Nominee NIC" SortExpression="NOMNIC">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMPER" HeaderText="Percenatage" SortExpression="NOMPER">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMAD1" HeaderText="Address1" SortExpression="NOMAD1">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMAD2" HeaderText="Address2" SortExpression="NOMAD2">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="vouno" HeaderText="Voucher No" SortExpression="vouno" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="adbvouno" HeaderText="ADB Voucher No." SortExpression="adbvouno" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nominatedate" HeaderText="Nominate Date" SortExpression="nominatedate" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" VerticalAlign="Top" />
            <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Left" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left"
                VerticalAlign="Top" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <asp:Label ID="lbllegheires" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="12pt" ForeColor="Blue" Text="Legal Heires" Width="138px"></asp:Label><br /><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="143px" HorizontalAlign="Center"
            Style="font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS'" Width="900px">
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <Columns>
                <asp:BoundField DataField="lhhno" HeaderText="Heire No" ReadOnly="True" SortExpression="lhhno">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lhhire" HeaderText="Heire" SortExpression="lhhire">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lhname" HeaderText="Name" SortExpression="lhname">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lhad1" HeaderText="Address" SortExpression="lhad1">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lhdob" HeaderText="DOB" SortExpression="lhdob">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lhmst" HeaderText="Maritial Status" SortExpression="lhmst">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lhremarks" HeaderText="Remarks" SortExpression="lhremarks">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
        <asp:BoundField DataField="lhshare" HeaderText="Share" SortExpression="lhshare" />
        <asp:BoundField DataField="lhamount" HeaderText="Amount" SortExpression="lhamount" />
        <asp:BoundField DataField="vouno" HeaderText="Voucher No" SortExpression="vouno" />
        <asp:BoundField DataField="adbvouno" HeaderText="ADB Voucher No" SortExpression="adbvouno" />
        <asp:BoundField DataField="adbamt" HeaderText="ADB Amount" SortExpression="adbamt" />
        <asp:BoundField DataField="affidavitdate" HeaderText="Affidavit Date" SortExpression="affidavitdate" />
    </Columns>
    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" VerticalAlign="Top" />
    <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Left" VerticalAlign="Top" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left"
                VerticalAlign="Top" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
        <br />
        <asp:Label ID="lbllprt" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="12pt" ForeColor="Blue" Text="Living Partner" Width="138px"></asp:Label><br />
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="143px" HorizontalAlign="Center"
            Style="font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS'" Width="900px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="NOMNAM" HeaderText="Name" SortExpression="NOMNAM">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMDOB" HeaderText="Date of Birth" SortExpression="NOMDOB">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMNIC" HeaderText="Nominee NIC" SortExpression="NOMNIC">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMPER" HeaderText="Percenatage" SortExpression="NOMPER">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMAD1" HeaderText="Address1" SortExpression="NOMAD1">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMAD2" HeaderText="Address2" SortExpression="NOMAD2">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="vouno" HeaderText="Voucher No" SortExpression="vouno" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="adbvouno" HeaderText="ADB Voucher No." SortExpression="adbvouno" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="prtnshipdate" HeaderText="Partnership Date" SortExpression="prtnshipdate" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" VerticalAlign="Top" />
            <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Left" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left"
                VerticalAlign="Top" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <asp:HyperLink ID="linkBack" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="14pt" ForeColor="#0000CC" NavigateUrl="~/Home.aspx">Back</asp:HyperLink>
    </form>
</body>
</html>
