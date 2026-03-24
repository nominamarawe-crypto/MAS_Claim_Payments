<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthOut001.aspx.cs" Inherits="dthOut001" %>
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

</script></head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-size: 10pt; width: 565px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 57px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 161px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 71px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #ffffff">
                    <strong><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claims Outstanding</span></strong></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 161px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 71px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 19px;">
                </td>
                <td style="width: 161px; text-align: left; height: 19px;">
                    <span><strong>Branch Code</strong></span></td>
                <td style="text-align: left; height: 19px;" colspan="2">
                    <span><span><strong></strong></span><asp:TextBox ID="txtbrn" runat="server" MaxLength="3" Width="101px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbrn"
                        ErrorMessage="Please Give the Branch Code" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="195px" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtbrn" ErrorMessage="Please Give a Numeric Branch Code "
                        Font-Bold="False" Font-Size="10pt" Width="243px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px;">
                </td>
                <td style="width: 161px; text-align: left; height: 20px;">
                    <span><strong> Start Date</strong></span></td>
                <td style="text-align: left; height: 20px;" colspan="2">
                    <span><span><strong></strong></span><asp:TextBox ID="txtStartDate" runat="server" MaxLength="8" Width="101px"></asp:TextBox>YYYYMMDD<asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtStartDate" ErrorMessage="Please Give a Numeric Start Date "
                        Font-Bold="False" Font-Size="10pt" Width="243px" Display="Dynamic"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStartDate"
                        ErrorMessage="Please Give the Start Date" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="195px" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px;">
                </td>
                <td style="width: 161px; text-align: left; height: 20px;">
                    <span><strong>End Date</strong></span></td>
                <td style="text-align: left; height: 20px;" colspan="2">
                    <span><span><strong></strong></span><asp:TextBox ID="txtEndDate" runat="server" MaxLength="8" Width="101px"></asp:TextBox>YYYYMMDD<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate"
                        ErrorMessage="Please Give the End Date" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="195px" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtEndDate" ErrorMessage="Please Give a End Numeric Date " Font-Bold="False"
                        Font-Size="10pt" Width="243px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 20px; background-color: whitesmoke">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px">
                </td>
                <td style="width: 161px; height: 20px; text-align: left">
                </td>
                <td style="width: 220px; height: 20px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" PostBackUrl="~/dthOut002.aspx" Text="--Submit--" Width="114px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx" Font-Names="Trebuchet MS" Width="95px"><<--Back</asp:HyperLink></td>
                <td style="width: 71px; height: 20px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        &nbsp;
    </form>
</body>
</html>
