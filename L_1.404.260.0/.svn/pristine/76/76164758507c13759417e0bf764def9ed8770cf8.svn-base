<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lnStatClmSetdet.aspx.cs" Inherits="lnStatClmSetdet" %>
<%@ PreviousPageType VirtualPath="~/lnStatClmSetdet010.aspx"%>
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
        <strong><span style="font-size: 14pt; font-family: Trebuchet MS"><span style="font-size: 12pt">
            <span style="font-family: Trebuchet MS"><strong><table style="font-size: 10pt; width: 659px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="5" style="height: 19px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 19px; background-color: #ffffff">
                    <span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span>
            <span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong>Monthly
                Branchwise Claim Settlement Details</strong></span></span></td>
            </tr>
                    <tr>
                        <td colspan="5" style="height: 19px; background-color: #f0f0f0">
                            <asp:Label ID="lblbrname" runat="server" Font-Size="10pt" ForeColor="#660066" Width="345px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td style="width: 49px; height: 20px; text-align: left">
                            <span style="font-size: 10pt">Branch</span></td>
                        <td style="width: 92px; height: 20px; text-align: left">
                            <span style="font-size: 10pt">:<asp:Label ID="lblbrcode" runat="server" Font-Size="10pt" Width="83px"></asp:Label></span></td>
                        <td style="height: 20px; text-align: left" colspan="2">
                            <span style="font-size: 10pt">Date Range From
                                <asp:Label ID="lblfromdate" runat="server" Font-Size="10pt" Width="83px"></asp:Label>
                                To
                                <asp:Label ID="lbltodate" runat="server" Font-Size="10pt" Width="83px"></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td style="height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 92px; height: 19px; background-color: #f0f0f0; text-align: left;">
                        </td>
                        <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 158px; height: 19px; background-color: #f0f0f0">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td style="width: 49px; height: 20px; text-align: left">
                            Type</td>
                        <td style="width: 92px; height: 20px; text-align: left">
                            : Deaths</td>
                        <td style="width: 158px; height: 20px">
                        </td>
                        <td style="width: 158px; height: 20px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td colspan="4" style="height: 20px; text-align: left">
                            <asp:Table ID="Table1" runat="server" Font-Bold="False" Font-Size="10pt" Width="600px" Font-Names="Trebuchet MS">
                            </asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
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
                        <td style="width: 49px; height: 20px; text-align: left">
                            Type</td>
                        <td style="width: 92px; height: 20px; text-align: left">
                            : Maturity</td>
                        <td style="width: 158px; height: 20px">
                        </td>
                        <td style="width: 158px; height: 20px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td colspan="4" style="height: 20px; text-align: left">
                            <asp:Table ID="Table2" runat="server" Font-Bold="False" Font-Size="10pt" Width="600px" Font-Names="Trebuchet MS">
                            </asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
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
                        <td style="width: 49px; height: 20px; text-align: left">
                            Type</td>
                        <td style="width: 92px; height: 20px; text-align: left">
                            : Surrenders</td>
                        <td style="width: 158px; height: 20px">
                        </td>
                        <td style="width: 158px; height: 20px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td colspan="4" style="height: 20px; text-align: left">
                            <asp:Table ID="Table3" runat="server" Font-Bold="False" Font-Size="10pt" Width="600px" Font-Names="Trebuchet MS">
                            </asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
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
                        <td style="width: 49px; height: 20px; text-align: left">
                            Type</td>
                        <td style="height: 20px; text-align: left" colspan="2">
                            : Stage Payments</td>
                        <td style="width: 158px; height: 20px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td colspan="4" style="height: 20px; text-align: left">
                            <asp:Table ID="Table4" runat="server" Font-Bold="False" Font-Size="10pt" Width="600px" Font-Names="Trebuchet MS">
                            </asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
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
                        <td style="width: 49px; height: 20px; text-align: left">
                            Type</td>
                        <td colspan="2" style="height: 20px; text-align: left">
                            : Previous Loan Settlements</td>
                        <td style="width: 158px; height: 20px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; height: 20px">
                        </td>
                        <td colspan="4" style="height: 20px; text-align: left">
                            <asp:Table ID="Table5" runat="server" Font-Bold="False" Font-Size="10pt" Width="600px" Font-Names="Trebuchet MS">
                            </asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 19px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
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
                        <td style="width: 49px; height: 19px; background-color: #f0f0f0">
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
                        <td style="width: 49px; height: 20px">
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
                        <td style="width: 49px; height: 20px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 92px; height: 20px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 158px; height: 20px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 158px; height: 20px; background-color: #f0f0f0">
                        </td>
                    </tr>
                </table>
            </strong></span></span></span></strong></div>
    </form>
</body>
</html>
