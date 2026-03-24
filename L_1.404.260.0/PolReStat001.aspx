<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolReStat001.aspx.cs" Inherits="PolReStat001" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Death Claims-Policy Restate</title>
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
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-size: 14pt"><span style="font-family: Trebuchet MS"><strong>Sri Lanka
            Insurance<br />
        </strong><span style="font-size: 12pt"><strong>Death Claims - Policy Restate<br />
        </strong></span></span></span>
            <br />
            <table style="width: 506px; font-family: Times New Roman;">
                <tr>
                    <td style="width: 89px; height: 21px; background-color: #cccccc;">
                    </td>
                    <td style="height: 21px; background-color: #cccccc; text-align: center;" colspan="2">
                        <strong>Enter Policy Number and Date of Death</strong></td>
                    <td style="width: 89px; height: 21px; background-color: #cccccc;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 89px; height: 20px;">
                    </td>
                    <td style="text-align: center; height: 20px;" colspan="2">
                        <asp:CustomValidator ID="cv1" runat="server" Width="300px"></asp:CustomValidator></td>
                    <td style="width: 89px; height: 20px;">
                    </td>
                </tr>
            <tr>
                <td style="width: 89px; height: 20px; background-color: #cccccc;">
                </td>
                <td style="height: 20px; background-color: #cccccc; text-align: left;">
                    Policy Number</td>
                <td style="height: 20px; background-color: #cccccc; text-align: left; width: 279px;">
                    :<asp:TextBox ID="txtpolnum" runat="server"></asp:TextBox></td>
                <td style="width: 89px; height: 20px; background-color: #cccccc;">
                </td>
            </tr>
            <tr>
                <td style="width: 89px; height: 20px;">
                </td>
                <td style="text-align: left; height: 20px;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolnum"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="True" Font-Size="10pt"
                        Height="4px" Width="201px"></asp:RequiredFieldValidator></td>
                <td style="text-align: left; height: 20px; width: 279px;">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolnum" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="True" Font-Size="10pt" Width="233px"></asp:CustomValidator></td>
                <td style="width: 89px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 89px; height: 20px; background-color: #cccccc;">
                </td>
                <td style="height: 20px; background-color: #cccccc; text-align: left;">
                    Date of Death</td>
                <td style="height: 20px; background-color: #cccccc; text-align: left; width: 279px;">
                    :<asp:TextBox ID="txtDOD" runat="server"></asp:TextBox>&nbsp;<span style="font-size: 8pt;
                        color: #ff0033">(YYYYMMDD)</span></td>
                <td style="width: 89px; height: 20px; background-color: #cccccc;">
                </td>
            </tr>
            <tr>
                <td style="width: 89px; height: 20px;">
                </td>
                <td style="height: 20px;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOD"
                        ErrorMessage="Please Give the Date" Font-Bold="True" Font-Size="10pt" Height="4px"
                        Width="153px"></asp:RequiredFieldValidator></td>
                <td style="height: 20px; width: 279px;">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtDOD" ErrorMessage="Please Give a Numeric Date" Font-Bold="True"
                        Font-Size="10pt" Height="9px" Width="187px"></asp:CustomValidator></td>
                <td style="width: 89px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 89px; height: 20px; background-color: #cccccc;">
                </td>
                <td style="height: 20px; background-color: #cccccc;">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="123px" OnClick="btnsubmit_Click" /></td>
                <td style="height: 20px; background-color: #cccccc; width: 279px;">
                    <asp:Button ID="btnreset" runat="server" Text="Reset" Width="123px" OnClick="btnreset_Click" /></td>
                <td style="width: 89px; height: 20px; background-color: #cccccc;">
                </td>
            </tr>
        </table>
        
    
    </div>
        <asp:HiddenField ID="hdstat" runat="server" />
        &nbsp;
    </form>
</body>
</html>
