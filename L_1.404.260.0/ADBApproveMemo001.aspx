<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBApproveMemo001.aspx.cs" Inherits="ADBApproveMemo001" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
        <span style="font-family: Trebuchet MS">
        <span><strong><span style="font-size: 14pt">
        </span></strong></span>
        </span>
        <table style="width: 603px; font-size: 12pt; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; background-color: #ffffff">
                    <strong><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span>Death Claim ADB Payment Memo and Distribution</strong></td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 26px;">
                </td>
                <td style="width: 190px; text-align: left; height: 26px;">
                    <span style="font-size: 10pt"><strong>Policy Number</strong></span></td>
                <td style="text-align: left; height: 26px;" colspan="2">
                    <span><strong></strong><asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt" Width="107px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Size="10pt" Width="197px" Font-Bold="False" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Size="10pt" Width="237px" Font-Bold="False" Display="Dynamic"></asp:CustomValidator></span></td>
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
                <td style="width: 190px; height: 21px; text-align: left">
                    <span style="font-size: 10pt"><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span style="font-size: 12pt"><strong></strong><asp:DropDownList ID="ddlMOS" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt" Width="100px">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                <asp:Label ID="lblmessage" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="#FF0033" Width="325px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #ffffff">
                </td>
                <td style="width: 190px; height: 22px; background-color: #ffffff">
                </td>
                <td style="width: 220px; height: 22px; background-color: #ffffff; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server"
                        Text="Submit" Font-Bold="True" Font-Names="Trebuchet MS" Width="106px" 
                        onclick="btnsubmit_Click"/>
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx" Font-Names="Trebuchet MS"><<--Back</asp:HyperLink></td>
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

