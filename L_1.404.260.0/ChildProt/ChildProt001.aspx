<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildProt001.aspx.cs" Inherits="vouPrint001" %>
<%@ Reference Page ="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/childProtVou/cvouMain.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Death Claims</title>
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
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span>
        <table style="font-size: 12pt; width: 603px; font-family: Trebuchet MS">
            <tr>
                <td style="height: 22px;" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td colspan="2" style="text-align: center">
                    <span style="font-size: 14pt"><strong><span style="font-size: 8pt; font-family: Tahoma">Sri Lanka
            Insurance - </span></strong>
                    </span><span style="font-size: 8pt; font-family: Tahoma">Child Protect Vouchers.</span></td>
                <td style="font-size: 12pt; width: 79px">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td style="width: 145px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma;">Policy Number</span></td>
                <td style="text-align: left" colspan="2">
                    <span>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Font-Names="Tahoma" Font-Size="8pt" Width="103px"></asp:TextBox></span></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please enter the Policy Number" Font-Bold="False" Font-Size="8pt"
                        Width="209px" Font-Names="Tahoma"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please enter a Numeric Policy Number"
                        Font-Bold="False" Font-Size="8pt" Width="249px" Font-Names="Tahoma"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 145px; height: 21px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma;">Main Life or Spouse</span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                        <asp:DropDownList ID="ddlMOS" runat="server" Font-Names="Tahoma" Font-Size="8pt" Width="108px" Enabled="False">
                        </asp:DropDownList></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 145px; height: 21px; text-align: left">
                </td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Tahoma"
                        OnClick="btnsubmit_Click" Text="--Submit--" Font-Size="8pt" Height="24px" Width="86px" /></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px;" colspan="4">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 18px;">
                </td>
                <td colspan="2" style="height: 18px">
                    &nbsp;<asp:CustomValidator ID="cv1" runat="server" Font-Bold="False" ValidationGroup="sb"
                        Width="417px" Font-Size="8pt" Font-Names="Tahoma"></asp:CustomValidator></td>
                <td style="width: 79px; height: 18px;">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="height: 22px;" colspan="4">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 22px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
