<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBPaymentDistn002.aspx.cs"
    Inherits="ADBPaymentDistn002" %>

<%@ PreviousPageType VirtualPath="~/ADBPaymentDistn001.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sri Lanka Insurance</title>
    <script src="JavaScript/FormValidation.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric02(arguments.Value))
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
        <table style="width: 568px">
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td colspan="4" style="text-align: center">
                    <span style="font-family: Trebuchet MS"><strong>Add More ADB Payee</strong></span>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px" colspan="4">
                    
                    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                        Width="670px" Font-Bold="True" Style="text-align: left">
                    </asp:Table>
                </td>
                <td style="width: 19px; height: 21px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px" colspan="4">
                    
                    <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                        Width="670px" Font-Bold="True" Style="text-align: left">
                    </asp:Table>
                </td>
                <td style="width: 19px; height: 21px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="width: 19px; height: 21px">
                    &nbsp;
                </td>
            </tr>
           <%-- <tr>
                <td style="width: 16px">
                </td>
                <td colspan="4" style="text-align: center">
                    <strong style="border-right: fuchsia 1px solid; border-top: fuchsia 1px solid; border-left: fuchsia 1px solid;
                        border-bottom: fuchsia 1px solid"><span style="font-size: 10pt; font-family: Trebuchet MS">
                            <span style="color: #990099">Balance Share : </span>
                            <asp:Label ID="lblBalanceshare" runat="server" Text="20%" ForeColor="#C000C0"></asp:Label></span></strong>
                </td>
                <td style="width: 19px">
                </td>
            </tr>--%>
            <tr>
                <td style="width: 16px; height: 9px;">
                </td>
                <td style="height: 9px" colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        ForeColor="#00FF33" Text="Successfully Updated" Visible="False"></asp:Label>&nbsp;
                </td>
                <td style="width: 19px; height: 9px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 26px;">
                </td>
                <td style="height: 26px; text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Heire Type</span>
                </td>
                <td style="height: 26px; text-align: left;">
                    <asp:DropDownList ID="ddlHeiretype" runat="server" OnSelectedIndexChanged="ddlHeiretype_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="height: 26px; text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Share Amount</span>
                </td>
                <td style="height: 26px; text-align: left;">
                    <asp:TextBox ID="txtShare" runat="server" Width="89px"></asp:TextBox>
                </td>
                <td style="width: 19px; height: 26px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px">
                    &nbsp;
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px; text-align: left;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShare"
                        ErrorMessage="Please Enter Share Amount" Font-Bold="False"></asp:RequiredFieldValidator><br />
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShare" ErrorMessage="Invalid share amount" Font-Bold="False"></asp:CustomValidator>
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px; text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Date of Birth</span>
                </td>
                <td style="height: 21px; text-align: left;">
                    <asp:TextBox ID="txtDob" runat="server" MaxLength="8" Width="77px"></asp:TextBox>
                </td>
                <td style="height: 21px; text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Married/Unmarried</span>
                </td>
                <td style="height: 21px; text-align: left;">
                    <asp:DropDownList ID="ddlMarried" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left;" colspan="3">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">(yyyymmdd)
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                            ControlToValidate="txtDob" ErrorMessage="Invalid Date of Birth" Font-Bold="False"></asp:CustomValidator></span>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Name</span>
                </td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtName" runat="server" Width="430px"></asp:TextBox>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Address :</span>
                </td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd1" runat="server" Width="430px"></asp:TextBox>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span>
                </td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd2" runat="server" Width="430px"></asp:TextBox>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span>
                </td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd3" runat="server" Width="430px"></asp:TextBox>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right">
                </td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd4" runat="server" Width="430px"></asp:TextBox>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right">
                </td>
                <td colspan="3" style="text-align: left">
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                    &nbsp;
                </td>
                <td colspan="4" style="height: 21px; text-align: center;">
                    <asp:Label ID="lblMessage" runat="server" Text="Share Exceeds Balance!" Font-Bold="True"
                        Font-Names="Trebuchet MS" ForeColor="#FF3300" Visible="False"></asp:Label>
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 26px;">
                </td>
                <td style="height: 26px; text-align: center;" colspan="4">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                        <asp:Button ID="cmdOk" runat="server" Height="25px" Text="-OK-" Width="75px" OnClick="cmdOk_Click" />
                        <asp:Button ID="cmdMore" runat="server" Height="25px" Text="-More-" Width="75px"
                            Enabled="False" OnClick="cmdMore_Click" />
                        <%--<asp:Button ID="cmdNext" runat="server" Height="25px" Text="-Next-" Width="75px"
                            OnClick="cmdNext_Click" />--%>
                             &nbsp;</span>
                </td>
                <td style="width: 19px; height: 26px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px;">
                </td>
                <td style="height: 21px;">
                    &nbsp;
                </td>
                <td style="height: 21px;">
                </td>
                <td style="height: 21px;">
                </td>
                <td style="height: 21px;">
                </td>
                <td style="width: 19px; height: 21px;">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
