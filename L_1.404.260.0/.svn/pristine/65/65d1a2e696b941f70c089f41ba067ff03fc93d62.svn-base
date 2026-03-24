<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cvouAuth001.aspx.cs" Inherits="cvouAuth001" %>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - New Loans</title>
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
        </span></span><table style="font-weight: bold; font-size: 12pt; width: 501px; font-family: Trebuchet MS">
            <tr>
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span>Child Protection Annual Payment Voucher</td>
            </tr>
            <tr>
                <td colspan="4" style="background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 102px">
                </td>
                <td style="width: 126px; text-align: left">
                    <span style="font-weight: normal; font-size: 10pt">Policy Number</span></td>
                <td style="text-align: left" colspan="2">
                    <span>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Width="127px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="False" Font-Size="10pt"
                        Width="209px" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="249px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr>
                <td colspan="4" style="background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 102px">
                </td>
                <td style="width: 126px; text-align: left">
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" Text="--Submit--" Width="112px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/vouMain.aspx" Width="55px"><<--Back</asp:HyperLink></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                &nbsp;</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 102px">
                </td>
                <td colspan="3">
                    <asp:CustomValidator ID="cv1" runat="server" Font-Bold="False" ValidationGroup="sb"
                        Width="417px"></asp:CustomValidator></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
