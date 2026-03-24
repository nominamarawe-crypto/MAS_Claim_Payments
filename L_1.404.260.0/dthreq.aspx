<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthreq.aspx.cs" Inherits="dthreq" %>
<%@ PreviousPageType VirtualPath="~/dthReg002.aspx"%>
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
        </strong></span>
        <table style="width: 603px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="height: 21px;" colspan="4">
                    <strong><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Requirments</span></strong></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 189px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px;">
                </td>
                <td style="width: 189px; text-align: left; height: 21px;">
                    <span><strong>Policy Number</strong></span></td>
                <td style="width: 220px; text-align: left; height: 21px;">
                    <span><span style="font-size: 12pt"><strong> </strong></span>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Width="115px"></asp:TextBox></span></td>
                <td style="width: 79px; font-size: 10pt; height: 21px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Size="10pt" Width="231px" Font-Bold="False" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Size="10pt" Width="237px" Font-Bold="False" Display="Dynamic"></asp:CustomValidator></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 189px; height: 21px; text-align: left">
                    <span><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"><strong> </strong></span>
                        <asp:DropDownList ID="ddlMOS" runat="server" Width="100px">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 189px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px; background-color: #ffffff">
                </td>
                <td style="width: 189px; height: 21px; background-color: #ffffff">
                </td>
                <td style="width: 220px; height: 21px; background-color: #ffffff; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click"
                        Text="--Submit--" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="102px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Main.aspx"><<--Back</asp:HyperLink></td>
                <td style="width: 79px; height: 21px; background-color: #ffffff">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: whitesmoke;" colspan="4">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
