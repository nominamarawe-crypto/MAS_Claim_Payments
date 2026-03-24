<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildProtPay010.aspx.cs" Inherits="ChildProt_ChildProtPay010" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
<link href="JavaScript/BodyStyle.css" rel="stylesheet" type="text/css"/>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<script language="javascript" type="text/javascript" src="../JavaScript/CalendarControl.js"> function Reset1_onclick() {

}

</script>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table border="0" cellspacing="0" style="width: 460px; height: 60px">
            <tr>
                <td align="left" bgcolor="#e6e6e6" style="width: 71px; height: 21px">
                    &nbsp;</td>
                <th align="center" bgcolor="#f8f8ff" style="height: 21px; width: 329px;">
                    <span style="font-size: 12pt; font-family: Arial">
                    SRI LANKA INSURANCE</span></th>
                <th align="left" bgcolor="#e6e6e6" style="height: 21px" width="80">
                </th>
            </tr>
            <tr>
                <td align="left" bgcolor="#e6e6e6" style="width: 71px">
                    &nbsp;</td>
                <td align="center" bgcolor="#f8f8ff" style="width: 329px">
                    <strong>- Death Claims -</strong></td>
                <td align="left" bgcolor="#e6e6e6" width="80">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="#e6e6e6" style="width: 71px; height: 21px">
                    &nbsp;</td>
                <td align="center" bgcolor="#f8f8ff" style="height: 21px; width: 329px;">
                    <b>Child Protect Payments</b></td>
                <td align="left" bgcolor="#e6e6e6" style="height: 21px" width="80">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <table id="table2" border="0" cellspacing="0" style="text-align: center; width: 460px; height: 203px;">
            <tr>
                <td align="left" bgcolor="gainsboro" style="width: 238px; text-align: center">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 318px">
                    &nbsp;</td>
                <td align="left" bgcolor="gainsboro" style="width: 289px">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 630px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="ghostwhite" style="width: 238px; height: 22px">
                </td>
                <td align="left" bgcolor="ghostwhite" style="width: 318px; height: 22px">
                    &nbsp;From Date</td>
                <td align="left" bgcolor="ghostwhite" style="width: 289px; height: 22px; text-align: center;">
                    &nbsp;<asp:TextBox ID="txtFromDate" runat="server" MaxLength="8"></asp:TextBox>
                    <img onclick="showCalendarControl(document.getElementById('txtFromDate'),'');" src="../Image/SmallCalendar.gif" />
                    </td>
                <td align="left" bgcolor="ghostwhite" style="width: 630px; height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="gainsboro" style="width: 238px; height: 21px">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 318px; height: 21px">
                    &nbsp;</td>
                <td align="left" bgcolor="gainsboro" style="width: 289px; height: 21px; text-align: center;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate"
                        ErrorMessage="From Date Required" Width="133px"></asp:RequiredFieldValidator></td>
                <td align="left" bgcolor="gainsboro" style="width: 630px; height: 21px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="ghostwhite" style="width: 238px; height: 22px">
                </td>
                <td align="left" bgcolor="ghostwhite" style="width: 318px; height: 22px">
                    &nbsp;To Date</td>
                <td align="left" bgcolor="ghostwhite" style="width: 289px; height: 22px; text-align: center;">
                    &nbsp;<asp:TextBox ID="txtToDate" runat="server" MaxLength="8"></asp:TextBox>
                    <img onclick="showCalendarControl(document.getElementById('txtToDate'),'');" src="../Image/SmallCalendar.gif" />
                    </td>
                <td align="left" bgcolor="ghostwhite" style="width: 630px; height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="gainsboro" style="width: 238px; height: 21px;">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 318px; height: 21px;">
                    &nbsp;</td>
                <td align="left" bgcolor="gainsboro" style="width: 289px; height: 21px; text-align: center;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate"
                        ErrorMessage="To Date Required" Width="125px"></asp:RequiredFieldValidator></td>
                <td align="left" bgcolor="gainsboro" style="width: 630px; height: 21px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="ghostwhite" style="width: 238px; height: 22px">
                </td>
                <td align="left" bgcolor="ghostwhite" style="width: 318px; height: 22px">
                </td>
                <td align="left" bgcolor="ghostwhite" style="width: 289px; height: 22px; text-align: center;">
                    &nbsp;<asp:Button ID="cmdSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click" Width="73px" />
                    <input id="Reset1" onclick="return Reset1_onclick()" type="reset" value="Reset" style="width: 70px" /></td>
                <td align="left" bgcolor="ghostwhite" style="width: 630px; height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="gainsboro" style="width: 238px">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 318px">
                    &nbsp;</td>
                <td align="left" bgcolor="gainsboro" style="width: 289px">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 630px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="ghostwhite" style="width: 238px; height: 22px">
                </td>
                <td align="left" bgcolor="ghostwhite" style="height: 22px" colspan="2">
                    <asp:LinkButton ID="lnkSearch" runat="server" Font-Size="Smaller" PostBackUrl="~/ChildProt/ChildProtPayByPolicy001.aspx">Search By Policy Number</asp:LinkButton>&nbsp;
                </td>
                <td align="left" bgcolor="ghostwhite" style="width: 630px; height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="gainsboro" style="width: 238px">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 318px">
                    &nbsp;</td>
                <td align="left" bgcolor="gainsboro" style="width: 289px">
                </td>
                <td align="left" bgcolor="gainsboro" style="width: 630px">
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
