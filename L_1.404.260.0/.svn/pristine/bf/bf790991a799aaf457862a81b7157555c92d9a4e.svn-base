<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouPrint001.aspx.cs" Inherits="vouPrint001" %>
<%@ PreviousPageType VirtualPath="~/childProtPay002.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Policy Surrenders</title>
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
        </span>
        </span>
        <table style="font-weight: bold; font-size: 12pt; width: 501px; font-family: Trebuchet MS">
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span>Surrender Voucher Printing</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 1463px; height: 21px;">
                </td>
                <td style="width: 291px; text-align: left; height: 21px;">
                    <span style="font-weight: normal; font-size: 10pt">Policy Number</span></td>
                <td style="text-align: left; height: 21px;" colspan="2">
                    <span>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="False" Font-Size="10pt"
                        Width="209px" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="249px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 1463px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="2" style="height: 21px; background-color: #ffffff">
                </td>
                <td colspan="2" style="height: 21px; background-color: #ffffff; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" PostBackUrl="~/vouPrint010.aspx" Text="--Submit--" Font-Size="10pt" Width="114px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/vouMain.aspx" Font-Names="Trebuchet MS"><<--Back</asp:HyperLink></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 1463px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 291px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 21px; background-color: #f0f0f0; text-align: right">
                    </td>
                <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 1463px; height: 21px;">
                </td>
                <td colspan="2" style="height: 21px">
                    <asp:CustomValidator ID="cv1" runat="server" Font-Bold="False" ValidationGroup="sb"
                        Width="417px"></asp:CustomValidator></td>
                <td style="width: 79px; height: 21px;">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
