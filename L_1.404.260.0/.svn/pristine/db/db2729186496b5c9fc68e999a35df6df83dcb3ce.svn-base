<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OldClaimMain.aspx.cs" Inherits="OldClaimMain" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>    
    <script type="text/javascript">
        
     function test(source, arguments)
    {
//    	 debugger   	
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
<link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
    <script src="JavaScript/CalendarControl.js"  language="javascript" type="text/javascript">
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <table style="font-size: 12pt; width: 493px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #ffffff">
                    <strong><span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span>Outstanding Death Claim Entry Module</strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 20px">
                </td>
                <td style="width: 115px; height: 20px; text-align: left">
                    <span style="font-size: 10pt"><strong>Policy Number</strong></span></td>
                <td colspan="2" style="height: 20px; text-align: left">
                    <span><strong></strong>
                        <asp:TextBox ID="txtpolno" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                            MaxLength="8" Width="107px" AutoPostBack="True" OnTextChanged="txtpolno_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                            Display="Dynamic" ErrorMessage="Please Give the Policy Number" Font-Bold="False"
                            Font-Size="10pt" Width="197px"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                            ControlToValidate="txtpolno" Display="Dynamic" ErrorMessage="Please Give a Numeric Policy Number"
                            Font-Bold="False" Font-Size="10pt" Width="237px"></asp:CustomValidator></span></td>
            </tr>
            <tr>
                <td style="width: 17px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="font-size: 10pt; width: 115px; height: 10px; background-color: #f0f0f0;
                    text-align: left">
                    <strong>Date of Death</strong></td>
                <td colspan="2" style="width: 250px; height: 10px; background-color: #f0f0f0; text-align: left; font-size: 10pt;">
                    <asp:TextBox ID="txtdthdt" runat="server" Height="15px" Width="93px"></asp:TextBox><asp:Image ID="Image3" runat="server" Height="17px" ImageUrl="~/Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('txtdthdt'));" Width="16px" />(YYYYMMDD)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdthdt"
                        ErrorMessage="Please Enter the Death Date" Width="204px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 17px; height: 18px; background-color: #ffffff">
                </td>
                <td style="width: 115px; height: 18px; background-color: #ffffff">
                </td>
                <td style="width: 220px; height: 18px; background-color: #ffffff; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" Text="Submit" Width="106px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" ForeColor="Blue" NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                <td style="width: 79px; height: 18px; background-color: #ffffff">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
