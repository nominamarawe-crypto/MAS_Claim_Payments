<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthOut002.aspx.cs" Inherits="dthOut002" %>
<%@ PreviousPageType VirtualPath="~/dthOut001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
    .fixedHeader
    {
    overflow: auto;
    height:350px;    
    }

    table th
    {
    border-width: 4px;
    border-color: Black;
    background-color: Gray;
    position: relative;
    top: expression(this.parentNode.parentNode.
                   parentNode.scrollTop-1);
    }
</style>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric(arguments.Value))
            {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
    
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Death Claims Outstanding<br />
        </span></strong>
        <table style="font-weight: bold; font-size: 10pt; width: 887px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
                <td colspan="3" style="text-align: left">
                    <span style="color: #990066">Payment Memo (Status Report) Approved and Payment Distribution
                        Approved but not Yet Completed Claims</span></td>
            </tr>
        </table>
        <div class="fixedHeader">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="dtofint" HeaderText="Date of Intimation" />
                <asp:HyperLinkField DataTextField="polno" HeaderText="Policy Number" />
                <asp:BoundField DataField="clmno" HeaderText="Claim No." />
                <asp:BoundField DataField="dtofdth" HeaderText="Date of Death" />
                <asp:BoundField DataField="dtofcom" HeaderText="Date of Commencement" />
                <asp:BoundField DataField="bsum" HeaderText="Sum Assured" />
                <asp:BoundField DataField="tbl" HeaderText="Table" />
                <asp:BoundField DataField="trm" HeaderText="Term" />
                <asp:BoundField DataField="epf" HeaderText="EPF" />
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" />
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" />
                <asp:BoundField DataField="amtout" HeaderText="Amount Outstanding" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        <table style="font-weight: bold; font-size: 10pt; width: 887px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
                <td colspan="3" style="text-align: left; height: 20px;">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left">
                    <span style="color: #990066">Payment Memo (Status Report) Approved <span style="color: #ff0033">
                        And</span> Payment Distribution <span style="color: #ff0033">Not</span> Approved
                        Claims</span></td>
            </tr>
        </table>
        <div class="fixedHeader">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="dtofint" HeaderText="Date of Intimation" />
                <asp:HyperLinkField DataTextField="polno" HeaderText="Policy Number" />
                <asp:BoundField DataField="clmno" HeaderText="Claim No." />
                <asp:BoundField DataField="dtofdth" HeaderText="Date of Death" />
                <asp:BoundField DataField="dtofcom" HeaderText="Date of Commencement" />
                <asp:BoundField DataField="bsum" HeaderText="Sum Assured" />
                <asp:BoundField DataField="tbl" HeaderText="Table" />
                <asp:BoundField DataField="trm" HeaderText="Term" />
                <asp:BoundField DataField="epf" HeaderText="EPF" />
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" />
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" />
                <asp:BoundField DataField="amtout" HeaderText="Amount Outstanding" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        <table style="font-weight: bold; font-size: 10pt; width: 887px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
                <td colspan="3" style="text-align: left; height: 20px;">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left">
                    <span style="color: #990066">Payment Memo (Status Report) <span style="color: #ff0033">
                        Not</span> Approved <span style="color: #ff0033">And</span> Payment Distribution
                        <span style="color: #ff0033">Not</span> Approved Claims</span></td>
            </tr>
        </table>
        <div class="fixedHeader">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="dtofint" HeaderText="Date of Intimation" />
                <asp:HyperLinkField DataTextField="polno" HeaderText="Policy Number" />
                <asp:BoundField DataField="clmno" HeaderText="Claim No." />
                <asp:BoundField DataField="dtofdth" HeaderText="Date of Death" />
                <asp:BoundField DataField="dtofcom" HeaderText="Date of Commencement" />
                <asp:BoundField DataField="bsum" HeaderText="Sum Assured" />
                <asp:BoundField DataField="tbl" HeaderText="Table" />
                <asp:BoundField DataField="trm" HeaderText="Term" />
                <asp:BoundField DataField="epf" HeaderText="EPF" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        <table style="font-weight: bold; font-size: 10pt; width: 887px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
                <td colspan="3" style="text-align: left; height: 20px;">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left">
                    <span style="color: #990066">Intimated But not Yet Registered Intimations</span></td>
            </tr>
        </table>
        <div class="fixedHeader">
        <asp:GridView ID="GridView4" runat="server" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" Font-Names="Trebuchet MS" Font-Size="10pt"
            ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="GridView4_SelectedIndexChanged">
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="dpolno" HeaderText="Policy No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="dmos" HeaderText="MOS" />
                <asp:BoundField DataField="description" HeaderText="Life Type" />
                <asp:BoundField DataField="dinfodat" HeaderText="Intimation Date" />
                <asp:BoundField DataField="dpolst" HeaderText="Policy Status" />
                <asp:BoundField DataField="dnod" HeaderText="Name of Deceased" />
                <asp:BoundField DataField="ddtofdth" HeaderText="Date of Death" />
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
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="14pt" ForeColor="Blue" NavigateUrl="~/Home.aspx">Back</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
