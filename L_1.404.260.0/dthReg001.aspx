<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthReg001.aspx.cs" Inherits="dthReg001" %>
<%@ PreviousPageType VirtualPath="~/dthInt020.aspx"%>
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
        <span><span style="font-size: 14pt">
        </span></span>
        </strong></span>
        <table style="width: 603px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; background-color: #ffffff">
                    <strong><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Registration</span></strong></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 165px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px;">
                </td>
                <td style="width: 165px; text-align: left; height: 21px;">
                    <span><strong>Policy Number</strong></span></td>
                <td style="text-align: left; font-size: 10pt; height: 21px;" colspan="2">
                    <span><strong><span style="font-size: 12pt"></span></strong><asp:TextBox ID="txtpolno" runat="server" MaxLength="8" AutoPostBack="True" OnTextChanged="txtpolno_TextChanged" Font-Names="Trebuchet MS" Font-Size="10pt" Width="113px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Size="10pt" Width="181px" Font-Bold="False" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator></span></td>
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
                <td style="width: 165px; height: 21px; text-align: left">
                    <span><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"><strong></strong></span><asp:DropDownList ID="ddlMOS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMOS_SelectedIndexChanged" Font-Names="Trebuchet MS" Font-Size="10pt">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 21px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px;">
                </td>
                <td style="width: 165px; text-align: left; height: 21px;">
                    <span><strong>Date of Death</strong></span></td>
                <td style="text-align: left; height: 21px;" colspan="2">
                    <span><strong><span style="font-size: 12pt"></span></strong><asp:TextBox ID="txtdateofdeath" runat="server" MaxLength="8" Width="113px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>YYYYMMDD<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdateofdeath"
                        ErrorMessage="Please Give the Date of Death" Font-Bold="False" Font-Size="10pt"
                        Width="185px" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtdateofdeath" ErrorMessage="Please Give a Numeric Date of Death"
                        Font-Bold="False" Font-Size="10pt" Width="229px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px; ">
                </td>
                <td colspan="3" style="height: 21px; ; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td id="TD2" runat="server" style="width: 165px; height: 21px; text-align: left">
                </td>
                <td id="TD1" runat="server" colspan="2" style="height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click"
                        Text="--Submit--" Font-Bold="False" Font-Names="Trebuchet MS" Width="114px" Font-Size="10pt" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx" Font-Names="Trebuchet MS" Width="67px"><<--Back</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
