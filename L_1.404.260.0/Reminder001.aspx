<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reminder001.aspx.cs" Inherits="Reminder001" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/CalendarControl.js" type="text/jscript"></script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 525px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="3" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px">
                    <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
                        Insurance<br />
                    </span><span style="font-size: 12pt">Death Calim Reminders.</span></span></strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; text-align: center">
                    From Date</td>
                <td style="height: 21px; text-align: justify" colspan="2">
                    <asp:TextBox ID="TxtFrom" runat="server" Font-Names="Trebuchet MS" Width="99px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date??" ControlToValidate="TxtFrom" Display="Dynamic"></asp:RequiredFieldValidator>
                    <img src="Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('TxtFrom'));"/>
                    YYYYMMDD</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    To Date</td>
                <td style="height: 21px; text-align: justify;" colspan="2">
                    <asp:TextBox ID="TxtTo" runat="server" Font-Names="Trebuchet MS" Width="99px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTo"
                        Display="Dynamic" ErrorMessage="To Date??"></asp:RequiredFieldValidator>
                    <img src="Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('TxtTo'));"/>
                    YYYYMMDD</td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: whitesmoke;" colspan="3">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; text-align: justify;">
                </td>
                <td style="width: 100px; height: 21px; text-align: justify;">
                    <asp:Button ID="Button1" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Text="--Submit--" Width="103px" OnClick="Button1_Click" /></td>
                <td style="width: 100px; height: 21px; text-align: justify;">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
