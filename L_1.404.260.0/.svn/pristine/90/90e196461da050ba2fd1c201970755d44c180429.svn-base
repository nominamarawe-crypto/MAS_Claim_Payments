<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdAdmitAndPaidNoControl.aspx.cs" Inherits="UpdAdmitAndPaidNoControl" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
<body>
<form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong><span style="font-size: 14pt">
        </span></strong>
            <table style="font-weight: bold; font-size: 12pt; width: 603px; font-family: Trebuchet MS">
                <tr>
                    <td style="width: 49px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 166px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px">
                        <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                        </span>Update Admit No & Paid No Control</td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px; background-color: whitesmoke">
                    </td>
                </tr>
                <tr>
                    <td style="width: 49px; height: 21px;">
                    </td>
                    <td style="width: 166px; text-align: left; height: 21px;">
                        <span style="font-weight: normal; font-size: 10pt">Old Admit Number</span></td>
                    <td style="text-align: left; height: 21px;" colspan="2">
                        <span>
                            <asp:TextBox ID="txtOldAdmitNo" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                        </span></td>
                </tr>
                
                <tr style="font-size: 12pt">
                    <td style="width: 49px; height: 21px"></td>
                    <td style="width: 166px; height: 21px; text-align: left"></td>
                    <td style="width: 220px; height: 21px; text-align: left"></td>
                    <td style="width: 79px; height: 21px"></td>
                </tr>
                 <tr>
                    <td style="width: 49px; height: 21px;">
                    </td>
                    <td style="width: 166px; text-align: left; height: 21px;">
                        <span style="font-weight: normal; font-size: 10pt">Old Paid Number</span></td>
                    <td style="text-align: left; height: 21px;" colspan="2">
                        <span>
                            <asp:TextBox ID="txtOldPaidNo" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                        </span></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px; background-color: whitesmoke">
                    </td>
                </tr>
                <tr>
                    <td style="width: 49px; height: 21px;">
                    </td>
                    <td style="width: 166px; text-align: left; height: 21px;">
                        <span style="font-weight: normal; font-size: 10pt">New Admit Number</span></td>
                    <td style="text-align: left; height: 21px;" colspan="2">
                        <span>
                            <asp:TextBox ID="txtNewAdmitNo" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewAdmitNo"
                            ErrorMessage="Please Give the Admit Number" Font-Bold="False" Font-Size="10pt"
                            Width="203px" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                            ControlToValidate="txtNewAdmitNo" ErrorMessage="Please Give a Numeric Admit Number"
                            Font-Bold="False" Font-Size="10pt" Width="253px" Display="Dynamic"></asp:CustomValidator></span></td>
                </tr>
                
                <tr style="font-size: 12pt">
                    <td style="width: 49px; height: 21px"></td>
                    <td style="width: 166px; height: 21px; text-align: left"></td>
                    <td style="width: 220px; height: 21px; text-align: left"></td>
                    <td style="width: 79px; height: 21px"></td>
                </tr>
                 <tr>
                    <td style="width: 49px; height: 21px;">
                    </td>
                    <td style="width: 166px; text-align: left; height: 21px;">
                        <span style="font-weight: normal; font-size: 10pt">New Paid Number</span></td>
                    <td style="text-align: left; height: 21px;" colspan="2">
                        <span>
                            <asp:TextBox ID="txtNewPaidNo" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNewPaidNo"
                            ErrorMessage="Please Enter a Paid Number" Font-Bold="False" Font-Size="10pt"
                            Width="203px" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="test"
                            ControlToValidate="txtNewPaidNo" ErrorMessage="Please Give a Numeric Paid Number"
                            Font-Bold="False" Font-Size="10pt" Width="253px" Display="Dynamic"></asp:CustomValidator></span></td>
                </tr>
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    <asp:Label ID="lblMessage" Visible="false" runat="server" ForeColor="Red" Font-Size="small" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 21px; background-color: #ffffff">
                    </td>
                    <td colspan="2" style="height: 21px; background-color: #ffffff; text-align: left">
                        <asp:Button ID="btnChange" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                            Text="--Change--" Width="98px" onclick="btnChange_Click" />
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                            NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                </tr>                
            </table>
        </span>
    
    </div>
    </form>
</body>
</html>
