<%@ Page Language="C#" AutoEventWireup="true" CodeFile="repudiation001.aspx.cs" Inherits="repudiation001" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/dthPay020.aspx" %>
<%@ Reference Page="~/dthPro003.aspx" %>

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
        </span><table style="font-size: 10pt; width: 535px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Repudiation</span></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 12px; height: 21px;">
                </td>
                <td style="width: 127px; text-align: left; height: 21px;">
                    <span><strong>Policy Number</strong></span></td>
                <td style="font-size: 10pt; text-align: left; height: 21px;" colspan="2">
                    <span><strong><span style="font-size: 12pt"> </span></strong>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Width="117px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="False" Font-Size="10pt"
                        Width="197px" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="239px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 12px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 12px; height: 21px">
                </td>
                <td style="width: 127px; height: 21px; text-align: left">
                    <span><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"><strong> </strong></span>
                        <asp:DropDownList ID="ddlMOS" runat="server" AutoPostBack="True" Width="118px">
                        </asp:DropDownList></span></td>
                <td style="width: 57px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; text-align: center">
                    <asp:RadioButton ID="rbtrepu" runat="server" Checked="True" GroupName="gr1" Text="Repudiation"
                        Width="106px" />
                    <asp:RadioButton ID="rbtlapse" runat="server" GroupName="gr1" Text="Lapse" Width="122px" />
                    <asp:RadioButton ID="rbtNoContract" runat="server" GroupName="gr1" Text="No Contract" Width="126px" />
                    <asp:RadioButton ID="rbtSp" runat="server" GroupName="gr1" Text="Special Cases" Width="134px" /></td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 12px; height: 21px;">
                </td>
                <td style="width: 127px; height: 21px;">
                </td>
                <td style="width: 220px; height: 21px; text-align: left;">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" PostBackUrl="~/repudiation002.aspx" Text="--Submit--" Font-Size="10pt" Width="133px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                <td style="width: 57px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
        </table>
        </span></strong>
    
    </div>
    </form>
</body>
</html>
