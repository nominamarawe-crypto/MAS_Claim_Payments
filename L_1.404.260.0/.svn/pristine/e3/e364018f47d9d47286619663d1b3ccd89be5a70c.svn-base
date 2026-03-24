<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lnStatClmSetsum.aspx.cs" Inherits="lnStatClmSetsum" %>
<%@ PreviousPageType VirtualPath="~/lnStatClmSetsum010.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - New Loans</title>
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
        <strong><span style="font-size: 14pt; font-family: Trebuchet MS">
        </span></strong><span style="font-size: 12pt"><span style="font-family: Trebuchet MS">
            <strong><table style="font-size: 10pt;
                width: 659px; font-family: 'Trebuchet MS'">
                <tr>
                    <td colspan="5" style="height: 19px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 19px; background-color: #ffffff">
                        <span style="font-size: 14pt">Sri Lanka Insurance<br />
                        </span><span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong>Monthly Branchwise Claim Settlements Summary</strong></span></span></td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 19px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 20px">
                    </td>
                    <td style="width: 80px; height: 20px; text-align: left">
                        <span style="font-size: 10pt">From Date</span></td>
                    <td style="width: 92px; height: 20px; text-align: left">
                        <span style="font-size: 10pt">:</span><asp:Label ID="lblfromdate" runat="server" Font-Size="10pt"
                            Width="83px"></asp:Label></td>
                    <td style="width: 158px; height: 20px; text-align: left">
                        <span style="font-size: 10pt">To Date</span></td>
                    <td style="width: 158px; height: 20px; text-align: left">
                        :<asp:Label ID="lbltodate" runat="server" Font-Size="10pt" Width="83px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 80px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 92px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 20px">
                    </td>
                    <td colspan="4" style="height: 20px; text-align: left">
                        <asp:Table ID="Table1" runat="server" Font-Bold="False" Font-Size="12pt" Width="600px">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 80px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 92px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 20px">
                    </td>
                    <td colspan="4" style="height: 20px">
                        <asp:Label ID="lblmessage" runat="server" ForeColor="#CC0066" Width="431px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 80px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 92px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 20px">
                    </td>
                    <td style="width: 80px; height: 20px">
                    </td>
                    <td style="width: 92px; height: 20px">
                    </td>
                    <td style="width: 158px; height: 20px">
                    </td>
                    <td style="width: 158px; height: 20px; text-align: left">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                            NavigateUrl="~/lnStat001.aspx"><<--Back</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="height: 20px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 80px; height: 20px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 92px; height: 20px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 20px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 158px; height: 20px; background-color: #f0f0f0">
                    </td>
                </tr>
            </table>
            </strong></span></span>
    
    </div>
    </form>
</body>
</html>
