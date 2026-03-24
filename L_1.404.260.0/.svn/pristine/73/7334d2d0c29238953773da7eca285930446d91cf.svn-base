<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reqInq001.aspx.cs" Inherits="reqInq001" %>
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
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Requirements Inquiry<br />
        </span></strong>
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="143px" HorizontalAlign="Center"
            Style="font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS'" Width="900px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="DREQDSESCENG" HeaderText="Requirement" ReadOnly="True"
                    SortExpression="DREQDSESCENG">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DRSENTDT" HeaderText="Request Sent Date" SortExpression="DRSENTDT">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DRRECDT" HeaderText="Recieved Date">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DRREMA" HeaderText="Remarks">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="SECONDREQUESTYN" HeaderText="Second Request Y/N">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="REMINDERDT" HeaderText="Reminder1 Sent Date">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="SECOND_REMINDER_DT" HeaderText="Reminder2 Sent Date">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="THIRD_REMINDER_DT" HeaderText="Reminder3 Sent Date">
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
            Font-Size="10pt" ForeColor="#0000CC" NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
