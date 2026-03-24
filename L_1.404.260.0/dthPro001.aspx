<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthPro001.aspx.cs" Inherits="dthPro001" %>
<%@ PreviousPageType VirtualPath="~/dthreq002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/trnState002.aspx" %>

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
        <span style="font-size: 12pt"><span style="font-size: 14pt;">
        </span>
        </span>
        </strong></span>
        <table style="width: 603px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="height: 21px;" colspan="4">
                    <strong><span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">
        Death Claim Processing</span></strong></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 161px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px">
                </td>
                <td style="width: 161px; text-align: left">
                    <span><strong>Policy Number</strong></span></td>
                <td style="text-align: left" colspan="2">
                    <span style="font-size: 16pt"><span style="font-size: 12pt"><strong></strong></span><asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt" Width="113px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Size="10pt" Width="195px" Font-Bold="False" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Size="10pt" Width="243px" Font-Bold="False" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 161px; height: 21px; text-align: left">
                    <span><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span style="font-size: 16pt"><span style="font-size: 12pt"><strong></strong></span><asp:DropDownList ID="ddlMOS" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt" Width="110px">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 161px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 20px; background-color: #ffffff">
                </td>
                <td style="width: 161px; height: 20px; background-color: #ffffff">
                </td>
                <td style="width: 220px; height: 20px; background-color: #ffffff; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click"
                        Text="--Submit--" Font-Bold="True" Font-Names="Trebuchet MS" Width="106px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx" Font-Names="Trebuchet MS" Width="69px"><<--Back</asp:HyperLink></td>
                <td style="width: 79px; height: 20px; background-color: #ffffff">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 161px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: right;">
                    </td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
