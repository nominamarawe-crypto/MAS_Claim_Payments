<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepudiatePay001.aspx.cs" Inherits="RepudiatePay001" %>
<%@ PreviousPageType VirtualPath="~/repudiation002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
        <table style="font-size: 10pt; width: 501px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 158px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; background-color: #ffffff; text-align: center">
                    <strong><span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Special Payments for Death Claims</span></strong></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 158px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px">
                </td>
                <td style="width: 158px; text-align: left">
                    <span><strong>Policy Number</strong></span></td>
                <td colspan="2" style="font-size: 10pt; text-align: left">
                    <span><strong><span style="font-size: 12pt"></span></strong>
                        <asp:TextBox ID="txtpolno" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                            MaxLength="8" Width="125px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                            Display="Dynamic" ErrorMessage="Please Give the Policy Number" Font-Bold="False"
                            Font-Size="10pt" Width="197px"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                            ControlToValidate="txtpolno" Display="Dynamic" ErrorMessage="Please Give a Numeric Policy Number"
                            Font-Bold="False" Font-Size="10pt" Width="239px"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 22px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 158px; height: 21px; text-align: left">
                    <span><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"><strong></strong></span>
                        <asp:DropDownList ID="ddlMOS" runat="server" AutoPostBack="True" Font-Names="Trebuchet MS"
                            Font-Size="10pt" Width="123px">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 158px; height: 21px; text-align: left">
                </td>
                <td style="width: 220px; height: 21px; text-align: left">
                </td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 158px; height: 21px; text-align: left">
                </td>
                <td colspan="2" style="height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" OnClick="btnsubmit_Click" PostBackUrl="~/RepudiatePay002.aspx" Text="--Submit--"
                        Width="98px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" ForeColor="Blue" NavigateUrl="~/Home.aspx" Width="99px"><<--Back</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 22px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
