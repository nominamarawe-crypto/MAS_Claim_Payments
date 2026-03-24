<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeathRegisterSelect.aspx.cs" Inherits="DeathRegisterSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/CalendarControl.js"  language="javascript" type="text/javascript"></script>
    <style type="text/css">

tr
{
	
	padding-bottom:0px;
	padding-left:0px;
	padding-right: 0px;
	padding-top:0px;
	margin-bottom:0px;
	margin-left:0px;
	margin-right: 0px;
	margin-top:0px;
     border-style:none;
		
}
    </style>
</head>
<body>
     <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Death Claims&nbsp;Registration</span></strong><br />
         <center>
         <table>
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
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Label ID="lblType" runat="server" Text="Select Type"></asp:Label>
                </td>
                <td style="width: 138px">
                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                        <asp:ListItem Value="ALL" Text="All Policies" ></asp:ListItem>
                        <asp:ListItem Value="COMPLETED" Text="Completed Policies" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="ALLWITHOUT" Text="Without Range(All)"  ></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    From Date</td>
                <td style="width: 138px" bgcolor="#c9dada">
                    <asp:TextBox ID="txtFromDate" runat="server" MaxLength="8" Width="136px"></asp:TextBox></td>
                <td style="width: 100px">
                    <img id="Img1" align="left" alt="No Calander" onclick="showCalendarControl(document.getElementById('txtFromDate'));"
                        src="Image/SmallCalendar.gif" style="width: 18px; height: 20px" /></td>
                <td style="width: 100px">
                </td>
            </tr>
           
            <tr>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;">
                    To Date</td>
                <td style="width: 138px; height: 26px;" bgcolor="#c9dada">
                    <asp:TextBox ID="txtToDate" runat="server" MaxLength="8" Width="135px"></asp:TextBox></td>
                <td style="width: 100px; height: 26px;">
                    <img id="Img2" align="left" alt="No Calander" onclick="showCalendarControl(document.getElementById('txtToDate'));"
                        src="Image/SmallCalendar.gif" style="width: 18px; height: 20px" /></td>
                <td style="width: 100px; height: 26px;">
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
                    <asp:Button ID="btnSubmit" runat="server"
                        Text="Submit" Width="100px" onclick="btnSubmit_Click" /></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Label ID="lblMassage" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 100px; height: 26px;">
                </td>
            </tr>
        </table>
      </center>
        &nbsp;
       
 
    </div>
    </form>
<p style="text-align: center">
   
    
    &nbsp;</p>
</body>
</html>
