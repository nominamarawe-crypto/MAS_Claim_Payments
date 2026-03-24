<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DthOldEntry.aspx.cs" Inherits="DthOldEntry" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
    <script src="JavaScript/CalendarControl.js"  language="javascript" type="text/javascript">
</script>
<script src="JavaScript/OldEntry.js" language="javascript" type="text/javascript"></script>
<script src="JavaScript/ValidateNumeric.js" language="javascript" type="text/javascript"></script>
<script src="JavaScript/Validation.js" language="javascript" type="text/javascript"></script>
<script language="javascript" type="text/javascript" >

function CheckSurryear(textbox)
{
var a=document.getElementById(textbox).value;  
var yeara=a;
if(parseInt(a)<1950)
{
alert('Bonus surrender Year should greater than 1950');
return false;
}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <table style="width: 842px; height: 347px">
            <tr>
                <td colspan="6" style="height: 10px">
                    <span style="font-size: 14pt; font-family: Trebuchet MS"><strong>Outstanding Death Claim Entry</strong></span></td>
                <td colspan="1" style="height: 10px; width: 1549px;">
                </td>
            </tr>
            <tr>
                <td style="width: 110620px; height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="height: 5px; background-color: #f0f0f0; text-align: left; width: 20541px;">
                </td>
                <td style="height: 5px; background-color: #f0f0f0; text-align: left; width: 25373px;">
                </td>
                <td style="width: 30514px; height: 5px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 21864px; height: 5px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 23px; height: 5px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 1549px; height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white;">
                    Policy Number</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white; width: 20541px;">
                    <asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 25373px;">
                </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white;">
                    Claim Number</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; width: 220px; background-color: white;" colspan="2">
                    <asp:TextBox ID="txtclmno" runat="server" Width="121px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left"><asp:CheckBox ID="ChBx18" runat="server" Visible="False" style="color: #000000" Font-Bold="True" Text="Correct" /></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Proposal Number</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 20541px;">
                    <asp:TextBox ID="txtprop" runat="server" Height="15px" Width="141px" ReadOnly="True"></asp:TextBox></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                    <asp:CheckBox ID="CkBx1" runat="server" Visible="False" Width="72px" Text="Correct" style="font-weight: bold; color: #000000" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    ID No.</td>
                <td colspan="2" style="font-size: 10pt; width: 10961px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="txtid" runat="server" Height="15px" Width="83px"  MaxLength="10"></asp:TextBox><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtid" ErrorMessage="Invalid NIC"
                        ValidationExpression="\d{9}[\sX|x|V|v]" Width="69px"></asp:RegularExpressionValidator></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="width: 110620px; height: 5px; background-color: white; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    Name</td>
                <td style="height: 5px; background-color: white; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS'; width: 20541px;">
                    <asp:TextBox ID="txtst" runat="server" Height="15px" MaxLength="13" Width="50px" ReadOnly="True"></asp:TextBox><asp:TextBox ID="txtint" runat="server" Height="15px" MaxLength="20" Width="130px" ReadOnly="True"></asp:TextBox></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 25373px;">
                </td>
                <td style="width: 13010px; height: 5px; background-color: white; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="3"><asp:TextBox ID="txtsur" runat="server" Height="15px" MaxLength="40" Width="279px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 20541px;">
                    Status &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;Initials</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                </td>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 10961px;">
                    Surname</td>
                <td colspan="1" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 23px;">
                </td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Address</td>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="txtadd1" runat="server" Height="15px" Width="229px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="3" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="txtadd2" runat="server" Height="15px" Width="271px" ReadOnly="True"></asp:TextBox></td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white;">
                </td>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    <asp:TextBox ID="txtadd3" runat="server" Height="15px" Width="227px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="3" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    <asp:TextBox ID="txtadd4" runat="server" Height="15px" Width="271px" ReadOnly="True"></asp:TextBox></td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    Commenecement Date</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0; width: 20541px;">
                    <asp:TextBox ID="txtcomdat" runat="server" Height="15px" Width="95px" MaxLength="8" ></asp:TextBox><asp:Image ID="Image1" runat="server" onclick="showCalendarControl(document.getElementById('txtcomdat'));" Height="17px" ImageUrl="~/Image/SmallCalendar.gif"
                        Width="16px" />
                    (yyyymmdd)<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                        ControlToValidate="txtcomdat" ErrorMessage="Date Should Have 8 Digits" ValidationExpression="\d{8}"
                        Width="164px"></asp:RegularExpressionValidator></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                    <asp:CheckBox ID="CkBx5" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    Table/Term</td>
                <td style="font-size: 10pt; width: 21864px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    <asp:TextBox ID="txttbl" runat="server" Width="43px" MaxLength="3" Height="15px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txttbl"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
                <td style="font-size: 10pt; width: 23px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    <asp:TextBox ID="txttrm" runat="server" Height="15px" Width="31px" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttrm"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="CkBx6" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white;">
                    Sum Assured Amount</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white; width: 20541px;">
                    <asp:TextBox ID="txtsumass" runat="server" Height="15px" Width="139px" MaxLength="12" onblur="checkNumeric(this,'.');"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsumass"
                        ErrorMessage="*" Font-Bold="True" Width="11px"></asp:RequiredFieldValidator></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 25373px;">
                    <asp:CheckBox ID="CkBx7" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white;">
                    Payment Mode</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; width: 220px; background-color: white;" colspan="2">
                    <asp:TextBox ID="txtmod" runat="server" Height="15px" Width="51px" MaxLength="1"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmod" ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                    <asp:CheckBox ID="CkBx8" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Premium</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 20541px;">
                    <asp:TextBox ID="txtprm" runat="server" Height="15px" Width="139px" MaxLength="12" onblur="checkNumeric(this,'.');"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtprm"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                    <asp:CheckBox ID="CkBx9" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Next Effecting Date</td>
                <td colspan="2" style="font-size: 10pt; width: 10961px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="txtnxteff" runat="server" Width="91px" MaxLength="6" ></asp:TextBox>(yyyymm)<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtnxteff" ErrorMessage="Enter Next Effecting Date"
                        Font-Bold="True" Width="176px"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="CkBx10" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    PA Code</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left; width: 20541px;">
                    <asp:TextBox ID="txtpacode" runat="server" Height="15px" Width="139px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpacode"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 25373px;">
                    <asp:CheckBox ID="CkBx11" runat="server" Visible="False" Width="55px" Text="Correct" style="font-weight: bold; color: #000000" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    Agent Code</td>
                <td colspan="2" style="font-size: 10pt; width: 2319px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                    <asp:TextBox ID="txtagtcd" runat="server" Height="15px" Width="139px" MaxLength="8"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Organizer Code</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 20541px;">
                    <asp:TextBox ID="txtorgcd" runat="server" Height="15px" Width="139px" MaxLength="5"></asp:TextBox></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                    </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; width: 10961px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    Gross Claim</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0; width: 20541px;">
                    <asp:TextBox ID="txtgrsclm" runat="server" Height="15px" Width="139px" onblur="checkNumeric(this,'.');"></asp:TextBox></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                    <asp:CheckBox ID="CkBx14" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    Net Claim</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; width: 10961px; background-color: #f0f0f0;" colspan="2">
                    <asp:TextBox ID="txtnetclm" runat="server" Height="15px" Width="131px" MaxLength="8" onblur="checkNumeric(this,'.');"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="CkBx15" runat="server" Visible="False" Text="Correct" style="font-weight: bold; color: #000000" /></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white;">
                    Branch</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: white; width: 20541px;">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="BRNAM" DataValueField="BRNAM" Width="142px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 25373px;">
                </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px; text-align: left; background-color: white;">
                    Main Life/Spouse</td>
                <td style="font-size: 10pt; width: 220px; font-family: 'Trebuchet MS'; height: 5px; text-align: left; background-color: white;" colspan="2">
                    <asp:DropDownList ID="ddllife" runat="server" Width="118px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Main Life</asp:ListItem>
                        <asp:ListItem>Spouse</asp:ListItem>
                        <asp:ListItem>Second Life</asp:ListItem>
                        <asp:ListItem>Child</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Informed Date</td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
               <asp:TextBox ID="txtinfdate" runat="server" Height="15px" Width="99px"></asp:TextBox><asp:Image ID="Image2" runat="server" onclick="showCalendarControl(document.getElementById('txtinfdate'));" Height="17px" ImageUrl="~/Image/SmallCalendar.gif" Width="16px" /></td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Method of Inform</td>
                <td colspan="2" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    <asp:DropDownList ID="ddlmethod" runat="server" Width="118px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Counter</asp:ListItem>
                        <asp:ListItem>Mail</asp:ListItem>
                        <asp:ListItem>Call</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    <asp:Literal ID="litclmst" runat="server" Text="Claim Status" Visible="False"></asp:Literal></td>
                <td style="font-size: 10pt; width: 20541px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    <asp:DropDownList ID="ddlyn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlyn_SelectedIndexChanged"
                        Width="126px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>Admitted</asp:ListItem>
                        <asp:ListItem>Partly Paid</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    Policy Status</td>
                <td colspan="2" style="font-size: 10pt; width: 220px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                    <asp:DropDownList ID="ddlpolst" runat="server" Width="118px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Inforce</asp:ListItem>
                        <asp:ListItem>Lapse</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    Death Date</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left; width: 30514px;" colspan="2">
                    <asp:Label ID="lbldtdt" runat="server" Width="123px"></asp:Label></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    civil/Forces</td>
                <td colspan="2" style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left"><asp:DropDownList ID="ddlcvofr" runat="server" Width="118px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Civil</asp:ListItem>
                        <asp:ListItem>Army</asp:ListItem>
                        <asp:ListItem>Navy</asp:ListItem>
                        <asp:ListItem>Air Force</asp:ListItem>
                        <asp:ListItem>Police</asp:ListItem>
                        <asp:ListItem>Buddhist Clergy</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS';
                    height: 5px; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS';
                    height: 5px; text-align: left">
                </td>
                <td colspan="1" style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS';
                    height: 5px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                                    Exists Spouse Cover</td>
                <td colspan="6" style="font-size: 10pt; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                                    <asp:DropDownList ID="ddlSP_CVR" runat="server" Width="101px" AutoPostBack="True" OnSelectedIndexChanged="ddlSP_CVR_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>   Yes</asp:ListItem>
                                        <asp:ListItem>   No</asp:ListItem>
                                    </asp:DropDownList>&nbsp;<asp:Button ID="Button1" runat="server" Height="22px" OnClick="Button1_Click"
                                        Text="Add Spouse Cover" Width="117px" Visible="False" />
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Width="389px"></asp:Label></td>
            </tr>
             <tr>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left" colspan="7">
                    <asp:Panel ID="pnl_spusedtl" runat="server" Height="50px" Width="125px" Wrap="False">
                        <table style="width: 766px">
                            <tr>
                                <td colspan="5" style="text-align: center; height: 10px;">
                                    <strong>Spouse Details</strong></td>
                            </tr>
                            <tr>
                                <td style="width: 250px; height: 10px; background-color: #f0f0f0;">
                                    Spouse Name</td>
                                <td style="width: 100px; height: 10px; background-color: #f0f0f0;">
                                    <asp:TextBox ID="txtothNames" runat="server" Height="17px" Width="259px" ReadOnly="True"></asp:TextBox></td>
                                <td colspan="2" style="height: 10px; width: 100px; background-color: #f0f0f0;">
                                    <asp:TextBox ID="txtsurname" runat="server" Height="17px" Width="278px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 100px; height: 10px; background-color: #f0f0f0;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 250px; height: 10px">
                                </td>
                                <td style="width: 100px; height: 10px; text-align: center">
                                    Other Names</td>
                                <td colspan="2" style="height: 10px; text-align: center">
                                    Surname</td>
                                <td style="width: 100px; height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #f0f0f0; width: 250px; height: 10px;">
                                    Spouse Date of Birth</td>
                                <td style="background-color: #f0f0f0; height: 10px;" colspan="2">
                                    <asp:TextBox ID="txtdob" runat="server" Height="19px" Width="120px" ReadOnly="True"></asp:TextBox>
                                    <asp:Image ID="Image4" runat="server" Height="20px" ImageUrl="~/Image/SmallCalendar.gif"
                                        onclick="showCalendarControl(document.getElementById('txtdob'));" Style="background-image: url(Image/SmallCalendar.gif)"
                                        Width="18px" Visible="False" /></td>
                                <td style="background-color: #f0f0f0; height: 10px;">
                                </td>
                                <td style="background-color: #f0f0f0; height: 10px;">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left" colspan="7"><asp:Panel ID="pnl_chld" runat="server" Height="50px" Width="125px" Wrap="False" Visible="False">
                        <table style="width: 766px">
                            <tr>
                                <td colspan="5" style="text-align: center; height: 10px;">
                                    <strong>
                                    Children &nbsp;Details</strong></td>
                            </tr>
                            <tr>
                                <td style="width: 253px; height: 10px; background-color: #f0f0f0;">
                                    Child &nbsp;Name</td>
                                <td style="width: 100px; height: 10px; background-color: #f0f0f0;">
                                    <asp:TextBox ID="child1othrname" runat="server" Width="262px" Height="17px"></asp:TextBox></td>
                                <td colspan="2" style="height: 10px; width: 100px; background-color: #f0f0f0;">
                                    <asp:TextBox ID="child1surname" runat="server" Width="238px" Height="17px"></asp:TextBox></td>
                                <td style="width: 100px; height: 10px; background-color: #f0f0f0;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 253px; height: 10px">
                                </td>
                                <td style="width: 100px; height: 10px; text-align: center">
                                    Other Names</td>
                                <td colspan="2" style="height: 10px; text-align: center">
                                    Surname</td>
                                <td style="width: 100px; height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #f0f0f0; width: 253px; height: 10px;">
                                    Child Date of Birth</td>
                                <td style="background-color: #f0f0f0; height: 10px;" colspan="2">
                                    <asp:TextBox ID="child1dob" runat="server" Width="139px" Height="17px"></asp:TextBox>
                                    <asp:Image ID="Image5" runat="server" onclick="showCalendarControl(document.getElementById('child1dob'));" Height="18px" ImageUrl="~/Image/SmallCalendar.gif" Width="18px" style="background-image: url(Image/SmallCalendar.gif)" /></td>
                                <td style="background-color: #f0f0f0; height: 10px;">
                                </td>
                                <td style="background-color: #f0f0f0; height: 10px;">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left">
                    Informer ID</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left; width: 20541px;">
                    <asp:TextBox ID="txtinfID" runat="server" MaxLength="10" Width="123px" Height="17px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtinfID"
                        ErrorMessage="Invalid ID" ValidationExpression="\d{9}[\sX|x|V|v]"></asp:RegularExpressionValidator></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 10px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                    </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left">
                    Informer Tel:</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left" colspan="3">
                    <asp:TextBox ID="txtinftel" runat="server" MaxLength="10" Width="103px" Height="17px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtinftel"
                        ErrorMessage="invalid TP No" ValidationExpression="\d{10}"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    Informers Name</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left" colspan="5">
                    <asp:TextBox ID="txtinfname" runat="server" Height="15px" Width="501px"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left; width: 1549px;">
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left">
                    Informers Address</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left" colspan="5">
                    <asp:TextBox ID="txtinfadd1" runat="server" Height="15px" Width="193px"></asp:TextBox>
                    <asp:TextBox ID="txtinfadd2" runat="server" Height="15px" Width="215px"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 10px;
                    background-color: #f0f0f0; text-align: left; width: 1549px;">
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                </td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left" colspan="5">
                    <asp:TextBox ID="txtinfadd3" runat="server" Height="15px" Width="193px"></asp:TextBox>
                    <asp:TextBox ID="txtinfadd4" runat="server" Height="15px" Width="215px"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left; width: 1549px;">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                    Informer Relationship</td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0; width: 20541px;">
                    <asp:TextBox ID="txtinfrel" runat="server"></asp:TextBox></td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: left; width: 25373px;">
                </td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                </td>
                <td style="font-size: 10pt; width: 21864px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                </td>
                <td style="font-size: 10pt; width: 23px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left; background-color: #f0f0f0;">
                </td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; vertical-align: top; width: 110620px;">
                    <asp:Literal ID="Literal1" runat="server" Text="Existing Demands"></asp:Literal></td>
                <td colspan="3" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: white; text-align: left">
                    <asp:Table ID="Table1" runat="server" Height="1px" Style="text-align: center" Width="400px">
                    </asp:Table>
                </td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 21864px;">
                </td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 23px;">
                </td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: white;
                    text-align: left; width: 1549px;">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px; background-color: #f0f0f0;
                    text-align: center;" colspan="3">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="10pt" Font-Underline="True"
                        Text="Previous Loans" Visible="False" Width="215px"></asp:Label></td>
                <td style="font-size: 10pt; width: 21864px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 23px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
                <td colspan="5" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                    <asp:Table ID="Table2" runat="server" Height="1px" Style="text-align: center" Width="562px">
                    </asp:Table>
                </td>
                <td style="font-size: 10pt; width: 23px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 4px;
                    background-color: #f0f0f0; text-align: left">
                    Bonus Surrenders</td>
                <td style="font-size: 10pt; width: 20541px; font-family: 'Trebuchet MS'; height: 4px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:DropDownList ID="ddlbonsurrYN" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="75px" Height="15px">
                        <asp:ListItem Value="N">No</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                    </asp:DropDownList></td>
                                    <td colspan="4" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 4px;
                    background-color: #f0f0f0; text-align: left">
                    Surrendered Year &nbsp;
                    <asp:TextBox ID="txtbonsurryr" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Height="15px" MaxLength="4" Width="69px" onblur="CheckSurryear('txtbonsurryr');"></asp:TextBox>
                    &nbsp;
                    <asp:CheckBox ID="CkBx19" runat="server" Style="font-weight: bold" Text="Correct"
                        Visible="False" /></td>
                <td style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS'; height: 4px;
                    background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 110620px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                    <asp:Label ID="lbltotbondes" runat="server" Style="font-weight: bold" Text="Total Bonus"
                        Visible="False" Width="98px"></asp:Label></td>
                <td style="font-size: 10pt; width: 20541px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                    <asp:Label ID="lbltotbons" runat="server" Font-Bold="True" Width="122px" Visible="False"></asp:Label></td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                    <asp:CheckBox ID="CkBx20" runat="server" Style="font-weight: bold" Text="Correct"
                        Visible="False" /></td>
                <td style="font-size: 10pt; width: 30514px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
                <td style="font-size: 10pt; width: 21864px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
                <td style="font-size: 10pt; width: 22937px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
                <td style="font-size: 10pt; width: 22937px; font-family: 'Trebuchet MS'; height: 5px;
                    text-align: left">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="lblsurrbon" runat="server" Style="font-weight: bold" Text="Surrender Bonus"
                        Visible="False" Width="104px"></asp:Label></td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="lblsurramt" runat="server" Font-Bold="True" Visible="False" Width="122px"></asp:Label></td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="CkBx21" runat="server" Style="font-weight: bold" Text="Correct"
                        Visible="False" /></td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 21864px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 25373px; font-family: 'Trebuchet MS'; height: 5px;
                    background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="height: 10px; background-color: white; text-align: left;" colspan="6">
                    <asp:Label ID="lblerr" runat="server" Font-Bold="True" ForeColor="Red" Width="616px"></asp:Label></td>
                <td colspan="1" style="height: 10px; background-color: white; text-align: left; width: 1549px;">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="font-size: 10pt; width: 220px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="testlbl" runat="server" Font-Bold="True" ForeColor="#FF0033" Visible="False"
                        Width="568px"></asp:Label></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 220px; height: 5px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS'; background-color: #f0f0f0;" colspan="6">
                    <asp:Label ID="lblsuc" runat="server" Font-Bold="True" ForeColor="Green" Width="616px"></asp:Label></td>
                <td colspan="1" style="font-size: 10pt; width: 1549px; font-family: 'Trebuchet MS';
                    height: 5px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 110620px; height: 10px; text-align: left">
                </td>
                <td style="height: 10px; text-align: left;" colspan="3">
                    <asp:Button ID="btnsub" runat="server" Font-Bold="True" Height="23px" Text="Submit"
                        Width="99px" OnClick="btnsub_Click" /><asp:Button ID="btncancel" runat="server" Font-Bold="True" Height="23px"
                            Text="Cancel" Width="99px" /><asp:Button ID="btn_Next" runat="server" Font-Bold="True" Height="23px"
                        Text="Next" Width="99px" PostBackUrl="~/DthRefClaimEntry.aspx" Visible="False" OnClick="btn_Next_Click" /></td>
                <td style="width: 21864px; height: 10px; text-align: left">
                </td>
                <td style="width: 23px; height: 10px; text-align: left">
                </td>
                <td style="width: 1549px; height: 10px; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 10px; text-align: left">
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdfbrn" runat="server" />
        <asp:HiddenField ID="hdftrcode" runat="server" />
        <asp:HiddenField ID="hdfdthdt" runat="server" />
        <br />
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select BRNAM, brcod from genpay.branch order by BRNAM">
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdflncap" runat="server" />
        <asp:HiddenField ID="lngrndt" runat="server" />
        <asp:HiddenField ID="lnintrst" runat="server" />
        <asp:HiddenField ID="hdfauth" runat="server" />
    </form>
</body>
</html>
