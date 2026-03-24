<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payeeInq001.aspx.cs" Inherits="payeeInq001" %>
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
        </span>Payee Inquiry<table style="font-size: 10pt; width: 501px; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 224px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td style="width: 224px; text-align: left">
                    <span style="font-size: 12pt"><strong>Policy Number</strong></span></td>
                <td style="font-size: 10pt; width: 220px; text-align: left">
                    <span><strong><span style="font-size: 12pt">:-&nbsp; </span></strong>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8"></asp:TextBox></span></td>
                <td style="font-size: 10pt; width: 79px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 22px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="True" Font-Size="10pt"
                        Width="197px"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="True" Font-Size="10pt" Width="239px"></asp:CustomValidator></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 224px; height: 21px; text-align: left">
                    <span style="font-size: 12pt"><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"><strong>:-&nbsp; </strong></span>
                        <asp:DropDownList ID="ddlMOS" runat="server" AutoPostBack="True">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 22px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td colspan="2">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" Text="Submit" />
                    <asp:Button ID="btnrest" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnrest_Click" Text=" Reset " /></td>
                <td style="width: 79px">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 224px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0000FF"
                        NavigateUrl="~/Home.aspx">Back</asp:HyperLink></td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td style="width: 224px">
                </td>
                <td style="width: 220px">
                </td>
                <td style="width: 79px">
                </td>
            </tr>
        </table>
        </span></strong>
    
    </div>
    </form>
</body>
</html>
