<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthPro002.aspx.cs" Inherits="dthPro002" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/dthPro001.aspx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
     <script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>

</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong><span
            style="font-size: 14pt">
        </span>
        </strong>
        </span>
            <table border="0" style="font-weight: bold; font-size: 10pt; width: 869px; font-family: 'Trebuchet MS';">
                <tr>
                    <td colspan="6" style="height: 21px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 21px; background-color: #ffffff; text-align: center">
                        <span style="font-size: 14pt">Sri Lanka Insurance<br />
                        </span><span style="font-size: 12pt">Death Claim Processing</span></td>
                </tr>
                <tr>
                    <td colspan="6" style="background-color: #f0f0f0; height: 21px;">
                        <span style="font-size: 12pt"><span style="color: #cc00cc">
                        <span>Policy No. :-</span> 
                        </span></span>
                        <asp:Label ID="lblpolno" runat="server" Font-Size="12pt" Width="73px" ForeColor="#CC00CC"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="lblMOS" runat="server" Font-Bold="True" Font-Size="12pt" Width="192px" ForeColor="#CC00CC"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 20px; background-color: #f0f0f0;">
                    </td>
                    <td colspan="4" style="background-color: #f0f0f0;">
                        <span style="font-family: Arial"></span>
                        <marquee style="font-family: Arial; width: 385px;"><FONT color=#0000ae 
      size=-1><STRONG><FONT color=#ff0000><SPAN style="COLOR: #00cc33">Please 
      Mark if the Following Documents are 
      Present</SPAN></FONT></STRONG></FONT></marquee>
                    </td>
                    <td style="background-color: #f0f0f0; width: 39px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 21px">
                    </td>
                    <td colspan="4" style="height: 21px; text-align: left">
                        Name of Insured :-
                        <asp:Label ID="lblnameofins" runat="server" Font-Bold="True" Font-Size="10pt" Width="466px"></asp:Label></td>
                    <td style="width: 39px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0;" colspan="6">
                        <asp:GridView ID="DataGrid1" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" GridLines="None" Width="778px" ForeColor="#333333">
                            <PagerSettings Visible="False" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <Columns><asp:TemplateField HeaderText="Recieved?">
                            <ItemTemplate>
                            <asp:CheckBox ID="ch" runat="server" />
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                                
                                <asp:BoundField DataField="REQ" HeaderText="Requirement" >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Remarks">
                                 <ItemTemplate>
                            <asp:TextBox ID="txt" runat="server" Text='<%# Bind("Remarks") %>' />
                            </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 22px">
                    </td>
                    <td style="height: 22px; text-align: left;" colspan="4">
                        <asp:Label ID="lblmessage" runat="server" ForeColor="#FF0033" Width="534px" Font-Bold="False"></asp:Label></td><td style="width: 39px; height: 22px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 20px; background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="text-align: left; background-color: #f0f0f0; height: 21px;" colspan="4">
                        <span style="font-size: 12pt; color: #000000">Recieved Requirements</span></td>
                    <td style="background-color: #f0f0f0; height: 21px; width: 39px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 21px">
                    </td>
                    <td style="height: 21px; text-align: left;" colspan="4">
                        <asp:Table ID="Table1" runat="server" BorderStyle="Double" BorderWidth="1px" HorizontalAlign="Left"
                            Width="700px">
                        </asp:Table>
                    </td>
                    <td style="width: 39px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 21px">
                    </td>
                    <td colspan="4" style="height: 21px; text-align: left">
                    </td>
                    <td style="width: 39px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 21px">
                    </td>
                    <td colspan="4" style="height: 21px; text-align: left">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="10pt" OnClick="LinkButton1_Click">Progress Letter(English)</asp:LinkButton>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="10pt" OnClick="LinkButton2_Click">Progress Letter(Sinhala)</asp:LinkButton></td>
                    <td style="width: 39px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="background-color: #f0f0f0; height: 21px;" colspan="3">
                    </td>
                    <td style="width: 199px; background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="background-color: #f0f0f0; height: 21px; width: 39px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 21px">
                        <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="--Submit--" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="104px" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20px; background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="width: 199px; background-color: #f0f0f0; height: 21px;">
                    </td>
                    <td style="background-color: #f0f0f0; height: 21px; width: 39px;">
                    </td>
                </tr>
            </table>
        </span>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='intOfDeath2501Eng.aspx';

}
</script>
</html>
