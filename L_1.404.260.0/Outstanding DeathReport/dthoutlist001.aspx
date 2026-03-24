<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthoutlist001.aspx.cs" Inherits="dthoutlist001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <link href="../JavaScript/CalendarControl.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/CalendarControl.js"  language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Death Claims&nbsp; Reports</span></strong><br />
        <table>
            <tr>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
                <td style="width: 138px" bgcolor="#c9dada">
                </td>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
                <td style="width: 100px" bgcolor="#c9dada">
                    <strong>Start Date</strong></td>
                <td style="width: 138px" bgcolor="#c9dada">
                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="8" Width="136px"></asp:TextBox></td>
                <td style="width: 100px" bgcolor="#c9dada">
                    <img id="Img1" align="left" alt="No Calander" onclick="showCalendarControl(document.getElementById('txtStartDate'));"
                        src="../Image/SmallCalendar.gif" style="width: 18px; height: 20px" /></td>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 138px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
                <td style="width: 100px" bgcolor="#c9dada">
                    <strong>End Date</strong></td>
                <td style="width: 138px" bgcolor="#c9dada">
                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="8" Width="135px"></asp:TextBox></td>
                <td style="width: 100px" bgcolor="#c9dada">
                    <img id="Img2" align="left" alt="No Calander" onclick="showCalendarControl(document.getElementById('txtEndDate'));"
                        src="../Image/SmallCalendar.gif" style="width: 18px; height: 20px" /></td>
                <td style="width: 100px" bgcolor="#c9dada">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 138px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 138px; height: 26px;">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                        Text="Submit" Width="100px" /></td>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
