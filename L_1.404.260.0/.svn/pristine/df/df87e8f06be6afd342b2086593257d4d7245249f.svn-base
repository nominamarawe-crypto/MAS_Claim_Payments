<%@ Page Language="C#" AutoEventWireup="true" CodeFile="intimdetInq001.aspx.cs" Inherits="intimdetInq001" %>
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
        </span>Death Intimation Detail Inquiry<br />
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
        </span></strong>
    
    </div>
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" CellPadding="4"
            EnablePagingCallbacks="True" Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333"
            GridLines="None" Height="50px" Width="583px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <InsertRowStyle HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:DetailsView>
        <br />
        <asp:HyperLink ID="linkBack" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
            Font-Size="10pt" ForeColor="#0000CC" NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink>
    </form>
</body>
</html>
