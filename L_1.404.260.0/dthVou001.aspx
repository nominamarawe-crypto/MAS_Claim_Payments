<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthVou001.aspx.cs" Inherits="dthVou001" %>
<%@ PreviousPageType VirtualPath="~/paymentDistn002.aspx"%>
<%@ Reference Page="~/dthPay002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span></strong>
        <table style="font-size: 12pt; width: 603px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: #ffffff" colspan="4">
                    <strong><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span>Death Claim Payment</strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td style="width: 178px; text-align: left">
                    <span style="font-size: 10pt"><strong>Policy Number</strong></span></td>
                <td style="text-align: left" colspan="2">
                    <span><strong> </strong>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="False" Font-Size="10pt"
                        Width="215px" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="237px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 22px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 178px; height: 21px; text-align: left">
                    <span style="font-size: 10pt"><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span style="font-size: 12pt"><strong> </strong>
                        <asp:DropDownList ID="ddlMOS" runat="server" Font-Names="Trebuchet MS" Font-Overline="True" Font-Size="10pt">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: white">
                </td>
                <td style="width: 178px; height: 22px; background-color: #ffffff">
                </td>
                <td style="width: 220px; height: 22px; background-color: #ffffff; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" PostBackUrl="~/dthVou002.aspx" Text="--Submit--" Font-Size="10pt" Width="98px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx" Font-Names="Trebuchet MS" Width="67px"><<--Back</asp:HyperLink></td>
                <td style="width: 79px; height: 22px; background-color: #ffffff">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
