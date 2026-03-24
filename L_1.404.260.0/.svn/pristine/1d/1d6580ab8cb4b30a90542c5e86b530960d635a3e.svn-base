<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reinsLetter001.aspx.cs" Inherits="reinsLetter001" %>
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
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span><table style="font-weight: bold; font-size: 10pt;
            width: 543px; font-family: Trebuchet MS">
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Reinsurance Letter</span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px;">
                </td>
                <td style="width: 102px; text-align: left; height: 21px;">
                    <span>Policy Number</span></td>
                <td style="font-size: 10pt; text-align: left; height: 21px;" colspan="1">
                    <span><span style="font-size: 12pt"> </span>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Width="111px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="197px" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="239px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="height: 21px; background-color: #f0f0f0" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 102px; height: 21px; text-align: left">
                    <span>Main Life or Spouse</span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"> </span>
                        <asp:DropDownList ID="ddlMOS" runat="server" AutoPostBack="True" Width="106px">
                        </asp:DropDownList></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="3" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 102px; height: 21px; text-align: left">
                </td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" PostBackUrl="~/reinsLetter002.aspx" Text="--Submit--" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="3">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
