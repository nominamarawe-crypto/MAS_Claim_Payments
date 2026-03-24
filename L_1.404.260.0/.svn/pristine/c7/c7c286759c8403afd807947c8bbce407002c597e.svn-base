<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthVou002.aspx.cs" Inherits="dthVou002" %>
<%@ PreviousPageType VirtualPath="~/dthVou001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
      <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric02(arguments.Value))
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
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span>
        </span></strong>
        <table style="font-weight: bold; font-size: 10pt; width: 699px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="5">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Payments</span></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px">
                </td>
                <td style="width: 154px; height: 21px; text-align: left">
                    Policy No.</td>
                <td style="width: 127px; height: 21px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="105px"></asp:Label></td>
                <td style="width: 181px; height: 21px; text-align: left">
                    Life Type</td>
                <td style="width: 159px; height: 21px; text-align: left">
                    :
                    <asp:Label ID="lbllifeType" runat="server" Width="105px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 154px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 181px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 159px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px">
                </td>
                <td style="width: 154px; height: 21px; text-align: left">
                    Total Claim Payment</td>
                <td style="width: 127px; height: 21px; text-align: left">
                    :
                    <asp:Label ID="lbltotclm" runat="server" Width="105px"></asp:Label></td>
                <td style="width: 181px; height: 21px; text-align: left">
                    Payee</td>
                <td style="width: 159px; height: 21px; text-align: left">
                    :
                    <asp:Label ID="lblpayee" runat="server" Width="105px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 154px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 181px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 159px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px">
                </td>
                <td style="height: 21px" colspan="4">
                    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Left" Width="640px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 154px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 181px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 159px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px">
                </td>
                <td style="height: 21px" colspan="4">
                    <asp:Label ID="lblAMLDesignatedPersons" runat="server" Visible="false" ForeColor="#FF3300"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px">
                </td>
                <td style="height: 21px" colspan="4">
                    <asp:Label ID="lblmessage" runat="server" ForeColor="#3300FF" Width="455px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 154px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 181px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 159px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px">
                </td>
                <td style="height: 21px" colspan="4">
                    <asp:Button ID="btnSlivou" runat="server" Font-Bold="True" Height="27px" Text="SLIC Voucher"
                        Width="161px" OnClick="btnSlivou_Click" PostBackUrl="~/Slicvou001.aspx" />
                    <asp:Button ID="btnVouCr" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Create Voucher" OnClick="btnVouCr_Click" PostBackUrl="~/vouCreate001.aspx" />

                    <%--Rajitha Lakshan #42650--%>
                    <asp:Button ID="btnVouEdit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Edit Voucher" OnClick="btnVouEdit_Click" PostBackUrl="~/voucher/vouDetEdit001.aspx" />
                    <asp:Button ID="btnVouDelete" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Delete Voucher" OnClick="btnVouDelete_Click" PostBackUrl="~/voucher/vouDelete001.aspx" />


                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" ForeColor="Blue" NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 22px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 154px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 181px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 159px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
