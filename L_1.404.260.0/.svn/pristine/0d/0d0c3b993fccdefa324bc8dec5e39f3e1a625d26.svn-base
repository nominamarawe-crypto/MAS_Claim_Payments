<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpouseCVREntry.aspx.cs" Inherits="SpouseCVREntry" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Spouse Cover Entry</title>
    <link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
    <script src="JavaScript/CalendarControl.js"  language="javascript" type="text/javascript">
</script>
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
function btnback_onclick() {
history.back();

}
function back() {
history.back();
}


//-->    
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 700px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 10px; text-align: center">
                    <span style="font-size: 14pt"><strong>Spouse Cover Entry</strong></span></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                    Policy Number</td>
                <td style="height: 10px" colspan="2">
                    <asp:TextBox ID="txtpolno" runat="server" Height="19px" MaxLength="8" Width="145px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        Display="Dynamic" ErrorMessage="Please Give the Policy Number" Font-Bold="False"
                        Font-Size="10pt" Width="197px"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Invalid Policy Number" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                    </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                    Date of Commencement</td>
                <td colspan="2" style="height: 10px">
                    <asp:TextBox ID="txtcomdt" runat="server" Height="19px" Width="120px"></asp:TextBox>
                    <asp:Image
                        ID="Image1" runat="server" Height="20px" ImageUrl="~/Image/SmallCalendar.gif"
                        onclick="showCalendarControl(document.getElementById('txtcomdt'));" Style="background-image: url(Image/SmallCalendar.gif)"
                        Width="18px" />(YYYYMMDD)<asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                            runat="server" ControlToValidate="txtcomdt" ErrorMessage="Invalid Date Format"
                            ValidationExpression="\d{8}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcomdt"
                        ErrorMessage="Enter Commencement Date"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                    Spouse Name</td>
                <td style="width: 76px; height: 10px">
                    <asp:TextBox ID="txtothNames" runat="server" Height="17px" Width="248px"></asp:TextBox></td>
                <td style="width: 100px; height: 10px">
                    <asp:TextBox ID="txtsurname" runat="server" Height="17px" Width="278px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0; text-align: center">
                    Other Names</td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0; text-align: center">
                    Surname</td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtothNames"
                        ErrorMessage="Invalid Name" ValidationExpression="^[a-zA-Z''-'\s\.]{1,40}$" Width="160px"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtothNames"
                        ErrorMessage="Enter First NAme"></asp:RequiredFieldValidator>&nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        runat="server" ControlToValidate="txtsurname" ErrorMessage="Invalid Name" ValidationExpression="^[a-zA-Z''-'\s\.]{1,40}$"
                        Width="139px"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsurname"
                        ErrorMessage="Enter Surname" Width="100px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                    Spouse Date of Birth</td>
                <td style="height: 10px" colspan="2">
                    <asp:TextBox ID="txtdob" runat="server" Height="19px" Width="120px"></asp:TextBox><asp:Image
                        ID="Image4" runat="server" Height="20px" ImageUrl="~/Image/SmallCalendar.gif"
                        onclick="showCalendarControl(document.getElementById('txtdob'));" Style="background-image: url(Image/SmallCalendar.gif)"
                        Width="18px" />
                    (YYYYMMDD)
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtdob"
                        ErrorMessage="Invalid Date Format" ValidationExpression="\d{8}"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                </td>
                <td style="height: 10px; text-align: left" colspan="2">
                    &nbsp;
                    <asp:Button ID="btn_sub" runat="server" Height="23px" Text="Submit" Width="90px" OnClick="btn_sub_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btn_back" runat="server" Height="24px" Text="Back" Width="102px" OnClick="btn_back_Click" />&nbsp;<asp:Button
                        ID="Btn_back1" runat="server" Text="Back" Width="87px" OnClick="Btn_back1_Click" Visible="False" /></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                </td>
                <td style="height: 10px" colspan="2">
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#00C000" Width="424px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                </td>
                <td style="width: 76px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 76px; height: 10px; background-color: #f0f0f0">
                </td>
                <td style="width: 100px; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 294px; height: 10px">
                </td>
                <td style="width: 76px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hdfdthdt" runat="server" />
    </form>
</body>
</html>
