<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nomDetEnt02.aspx.cs" Inherits="nomDetEnt02" %>
<%@ PreviousPageType VirtualPath="~/nomDetEnt01.aspx"%>
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
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong>
        <span><span><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
        </span>Nominee Detail Update</span></span><br />
        </strong></span>
        <table style="width: 603px; font-size: 12pt; font-family: 'Trebuchet MS';">
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
                    <span><strong>Policy Number</strong></span></td>
                <td style="width: 220px; text-align: left">
                    <span><strong>:-&nbsp; </strong>
                        <asp:Label ID="lblpolno" runat="server" Width="130px" Font-Bold="True"></asp:Label></span></td>
                <td style="width: 79px; font-size: 12pt;">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 22px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 224px; height: 21px; text-align: left">
                    <span><strong>Nominee No.</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><strong>:-&nbsp; </strong>
                        <asp:TextBox ID="txtnomno" runat="server" MaxLength="2" Width="51px"></asp:TextBox></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 22px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnomno"
                        ErrorMessage="Please Enter the Nominee Number" Font-Bold="True" Font-Size="10pt"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtnomno" ErrorMessage="Please Enter a Numeric Nominee No."
                        Font-Bold="True" Font-Size="10pt"></asp:CustomValidator></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px">
                </td>
                <td colspan="2">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" PostBackUrl="~/nomDetEnt03.aspx"
                        Text="Update/Delete" Font-Bold="True" Font-Names="Trebuchet MS" />
                    <asp:Button ID="btnrest" runat="server" OnClick="btnrest_Click" Text="Reset" Font-Bold="True" Font-Names="Trebuchet MS" /></td>
                <td style="width: 79px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 224px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Blue"
                        NavigateUrl="~/nomDetEnt01.aspx">Back</asp:HyperLink></td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px">
                </td>
                <td style="width: 224px">
                </td>
                <td style="width: 220px">
                </td>
                <td style="width: 79px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 224px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
