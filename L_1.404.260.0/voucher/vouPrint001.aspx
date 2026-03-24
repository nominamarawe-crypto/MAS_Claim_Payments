<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouPrint001.aspx.cs" Inherits="vouPrint001" %>
<%@ PreviousPageType VirtualPath="~/vouCreate001.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>

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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Death Claim Voucher Printing</span></strong><br />
        <table style="font-weight: bold; font-size: 12pt; width: 603px; font-family: Trebuchet MS">
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
                    <span>Policy Number</span></td>
                <td style="width: 220px; text-align: left">
                    <span>:-&nbsp;
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8"></asp:TextBox></span></td>
                <td style="font-size: 12pt; width: 79px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 22px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="True" Font-Size="10pt"
                        Width="209px"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="True" Font-Size="10pt" Width="249px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 224px; height: 21px; text-align: left">
                    <span><strong>Main Life or Spouse</strong></span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span style="font-size: 12pt"><strong>:-&nbsp; </strong>
                        <asp:DropDownList ID="ddlMOS" runat="server">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
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
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 18px;">
                </td>
                <td colspan="2" style="height: 18px">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" PostBackUrl="~/voucher/vouPrint002.aspx" Text="Submit" />
                    <asp:Button ID="btnrest" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnrest_Click" Text="Reset" /></td>
                <td style="width: 79px; height: 18px;">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 224px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Blue"
                        NavigateUrl="~/voucher/vouPrintMain.aspx">Back</asp:HyperLink></td>
                <td style="width: 79px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px">
                </td>
                <td colspan="2">
                    <asp:CustomValidator ID="cv1" runat="server" Font-Bold="True" ValidationGroup="sb"
                        Width="417px"></asp:CustomValidator></td>
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
