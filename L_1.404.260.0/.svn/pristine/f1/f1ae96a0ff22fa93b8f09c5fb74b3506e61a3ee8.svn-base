<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lhupdate001.aspx.cs" Inherits="Lhupdate001" %>
<%@ Reference  Page="~/EPage.aspx"%>
<%@ PreviousPageType VirtualPath="~/legalHieres001.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
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
        <br />
        <table style="width: 584px">
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px; width: 111px;">
                    &nbsp;</td>
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
                    <span style="font-family: Trebuchet MS"><strong>Legal Hires Update</strong></span></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px; width: 111px;">
                    &nbsp;</td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 16px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        ForeColor="#00FF33" Text="Successfully Updated" Visible="False"></asp:Label>&nbsp;</td>
                <td style="width: 19px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 26px">
                </td>
                <td style="height: 26px; text-align: right; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Heire Type</span></td>
                <td style="height: 26px; text-align: left">
                    <asp:DropDownList ID="ddlHeiretype" runat="server">
                    </asp:DropDownList></td>
                <td style="height: 26px; text-align: right">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Share Percentage (%)</span></td>
                <td style="height: 26px; text-align: left">
                    <asp:TextBox ID="txtShare" runat="server" Width="89px"></asp:TextBox></td>
                <td style="width: 19px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">&nbsp;</span></td>
                <td style="font-size: 10pt; font-family: Trebuchet MS; height: 21px">
                </td>
                <td style="font-size: 10pt; font-family: Trebuchet MS; height: 21px">
                </td>
                <td style="font-size: 10pt; font-family: Trebuchet MS; height: 21px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShare" ErrorMessage="Invalid share amount" Font-Bold="False"></asp:CustomValidator></td>
                <td style="font-size: 10pt; width: 19px; color: #000000; font-family: Trebuchet MS;
                    height: 21px">
                </td>
            </tr>
            <tr style="font-size: 10pt; color: #000000; font-family: Trebuchet MS">
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px; text-align: right; width: 111px;">
                    <span>Date of Bi<span
                        style="font-size: 12pt; font-family: Times New Roman">r</span>th:</span></td>
                <td style="height: 21px; text-align: left">
                    <asp:TextBox ID="txtDob" runat="server" MaxLength="8" Width="77px"></asp:TextBox></td>
                <td style="height: 21px; text-align: right">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Married/Unmarried</span></td>
                <td style="height: 21px; text-align: left">
                    <asp:DropDownList ID="ddlMarried" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 111px">
                    &nbsp;</td>
                <td colspan="3" style="text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">(yyyymmdd)
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                            ControlToValidate="txtDob" ErrorMessage="Invalid Date of Birth" Font-Bold="False"></asp:CustomValidator></span></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Name:</span></td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtName" runat="server" Width="430px" TextMode="MultiLine"></asp:TextBox></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 111px">
                    &nbsp;</td>
                <td colspan="3">
                    <asp:RegularExpressionValidator runat="server" ID="valInput" ControlToValidate="txtName"
                    ValidationExpression="^[\s\S]{0,100}$" ErrorMessage="*"
                    Display="Dynamic">*Please enter a maximum of 100 characters to Name</asp:RegularExpressionValidator>
                </td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Address :</span></td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd1" runat="server" Width="430px"></asp:TextBox></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr><td style="width: 16px">
            </td>
                <td style="text-align: right; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span></td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd2" runat="server" Width="430px"></asp:TextBox></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span></td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd3" runat="server" Width="430px"></asp:TextBox></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="text-align: right; width: 111px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span>
                </td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtAd4" runat="server" Width="430px"></asp:TextBox></td>
                <td style="width: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td colspan="4" style="height: 21px; text-align: center">
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td colspan="4" style="height: 21px; text-align: center">
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td colspan="4" style="height: 21px; text-align: center">
                    <asp:Label ID="lblEndmes" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" ForeColor="#FF3333" Visible="False"></asp:Label></td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 26px">
                </td>
                <td colspan="4" style="height: 26px; text-align: center">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                        <asp:Button ID="cmdPrevious" runat="server" Font-Bold="True" Text="Previous" Width="75px" OnClick="cmdPrevious_Click" />
                        <asp:Button ID="cmdUpdate" runat="server" Text="Update" Font-Bold="True" Width="75px" OnClick="cmdUpdate_Click" />&nbsp;<asp:Button ID="cmdNext"
                            runat="server" Text="Next" Font-Bold="True" Width="75px" OnClick="cmdNext_Click" />
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click"
                            Text="Shares" />&nbsp;<asp:Button ID="btnDel" runat="server" Font-Bold="True" Height="25px"
                                Text="Delete" Width="75px" OnClick="btnDel_Click" /></span></td>
                <td style="width: 19px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 21px">
                </td>
                <td style="height: 21px; width: 111px;">
                    &nbsp;</td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="width: 19px; height: 21px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
