<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Oldchildprot002.aspx.cs" Inherits="OldChildProt_Oldchildprot002" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ PreviousPageType VirtualPath="~/OldChildProt/Oldchildprot001.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<link href="../JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
<link href="../JavaScript/BodyStyle.css" rel="stylesheet" type="text/css"/>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<script language="javascript" type="text/javascript" src="../JavaScript/CalendarControl.js">
</script>
<body style="font-size: 10pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 735px; height: 744px; background-color: silver;">
            <tr>
                <td style="width: 173px; height: 12px;">
                </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 40px;">
                </td>
                <td colspan="5" style="text-align: center; height: 40px;">
                    <strong><span style="font-family: Tahoma; font-size: 8pt;">Sri Lanka Insurance<br />
                        Old Death Claims - Child Protection</span></strong></td>
                <td style="width: 47px; height: 40px;">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 17px;">
                </td>
                <td style="width: 1222px; text-align: left; height: 17px;">
                    <span style="font-size: 8pt; font-family: Tahoma">Policy No</span></td>
                <td style="width: 239px; text-align: left; height: 17px;">
                    <asp:Label ID="lblPolno" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
                <td style="width: 37px; height: 17px;">
                </td>
                <td style="width: 197px; text-align: left; height: 17px;">
                    <span><span style="font-family: Tahoma"><span style="font-size: 8pt">Claim No <span style="color: #ff3333">
                        *</span></span></span></span></td>
                <td style="width: 497px; text-align: left; height: 17px;">
                    :<asp:TextBox ID="txtClmno" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 17px;">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 14px;">
                </td>
                <td style="width: 1222px; text-align: left; height: 14px;">
                    <span><span style="font-family: Tahoma"><span style="font-size: 8pt">Date of Death <span style="color: #ff3300">
                        *</span></span></span></span></td>
                <td style="width: 239px; text-align: left; height: 14px;">
                    :<asp:TextBox ID="txtDtofdth" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                    <img onclick="showCalendarControl(document.getElementById('txtDtofdth'),'');" src="../Image/SmallCalendar.gif" /></td>
                <td style="width: 37px; height: 14px;">
                </td>
                <td style="width: 197px; text-align: left; height: 14px;">
                    <span style="font-size: 8pt; font-family: Tahoma">Life Type</span></td>
                <td style="width: 497px; text-align: left; height: 14px;">
                    :<asp:DropDownList ID="ddlMos" runat="server" Font-Names="Tahoma" Font-Size="8pt">
                    </asp:DropDownList></td>
                <td style="width: 47px; height: 14px;">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 21px">
                </td>
                <td style="width: 1222px; height: 21px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"><span style="font-family: Tahoma">
                        <span style="font-size: 8pt">Date of Commencement <span style="color: #ff3300">
                        *</span></span></span>&nbsp;</span></td>
                <td style="width: 239px; height: 21px; text-align: left;">
                    :<asp:TextBox ID="txtCom" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                    <img onclick="showCalendarControl(document.getElementById('txtCom'),'');" src="../Image/SmallCalendar.gif" /></td>
                <td style="width: 37px; height: 21px">
                </td>
                <td style="width: 197px; height: 21px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"><span style="font-size: 8pt;
                        font-family: Tahoma">Sum Assured</span> <span style="color: #ff3300">
                        *</span></span></td>
                <td style="width: 497px; height: 21px; text-align: left;">
                    :<asp:TextBox ID="txtSumass" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 21px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 24px">
                </td>
                <td style="width: 1222px; height: 24px; text-align: left">
                    <span><span style="font-family: Tahoma"><span style="font-size: 8pt">Child Protection Next Due <span style="color: #ff3300">*</span></span></span></span></td>
                <td style="width: 239px; height: 24px; text-align: left">
                    :<asp:TextBox ID="txtNpdue" runat="server" MaxLength="6" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 37px; height: 24px">
                </td>
                <td style="width: 197px; height: 24px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span></td>
                <td style="width: 497px; height: 24px; text-align: left">
                    &nbsp;</td>
                <td style="width: 47px; height: 24px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 14px">
                </td>
                <td style="width: 1222px; height: 14px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">Table</span></td>
                <td style="width: 239px; height: 14px; text-align: left;">
                    :<asp:DropDownList ID="ddlTable" runat="server" Font-Names="Tahoma" Font-Size="8pt" Enabled="False">
                    </asp:DropDownList></td>
                <td style="width: 37px; height: 14px">
                </td>
                <td style="width: 197px; height: 14px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">Term</span></td>
                <td style="width: 497px; height: 14px; text-align: left;">
                    :<asp:TextBox ID="txtTerm" runat="server" MaxLength="2" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 14px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span style="font-size: 8pt;
                        color: #ff3300; font-family: Tahoma">
                        <asp:Label ID="lblError" runat="server" Font-Names="Tahoma" Font-Size="8pt" Visible="False"> Table might not correct. Please check. Cannot be corrected once submitted!</asp:Label></span></td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px">
                </td>
                <td style="width: 1222px; text-align: left;">
                    <span style="font-size: 8pt; font-family: Tahoma">Name of Insured</span></td>
                <td style="text-align: left;" colspan="4">
                    :<asp:DropDownList ID="ddlPhsta" runat="server" Font-Names="Tahoma" Font-Size="8pt">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtPhint" runat="server" Width="123px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                    <asp:TextBox ID="txtPhname" runat="server" Width="307px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px">
                </td>
                <td style="width: 1222px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">
                    Full Name of Insured</span></td>
                <td colspan="4" style="text-align: left">
                    :<asp:TextBox ID="txtPhfullnam" runat="server" Width="507px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 26px;">
                </td>
                <td style="width: 1222px; text-align: left; height: 26px;">
                    <span style="font-size: 8pt; font-family: Tahoma">Nominee Name</span></td>
                <td style="text-align: left; height: 26px;" colspan="4">
                    :<asp:DropDownList ID="ddlpaysta" runat="server" Font-Names="Tahoma" Font-Size="8pt">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtInit" runat="server" Width="123px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                    <asp:TextBox ID="txtPaynam" runat="server" Width="307px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 26px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 12px;">
                </td>
                <td colspan="5" style="height: 12px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span style="font-size: 8pt;
                        font-family: Tahoma">(Initials) </span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span style="font-size: 8pt; font-family: Tahoma">
                        (Surname)</span></td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 6px;">
                </td>
                <td style="width: 1222px; height: 6px; text-align: left;">
                    <span><span style="font-family: Tahoma"><span style="font-size: 8pt">Name of Second Life <span style="color: #ff3300">*</span></span></span></span></td>
                <td style="height: 6px;" colspan="4">
                    :<asp:DropDownList ID="ddlSlnam" runat="server" Font-Names="Tahoma" Font-Size="8pt">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtslsurnam" runat="server" Width="123px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                    <asp:TextBox ID="txtslfullnam" runat="server" Width="307px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 6px;">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td colspan="5" style="height: 12px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span style="font-size: 8pt;
                        font-family: Tahoma">(Surname)</span> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; <span style="font-size: 8pt; font-family: Tahoma">(Fullname)</span></td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px">
                </td>
                <td style="width: 1222px">
                    <span style="font-family: Tahoma"><span style="font-size: 8pt">
                    Second Life DOB <span style="color: #ff3300">*</span></span></span></td>
                <td colspan="3">
                    <asp:TextBox ID="txtDob" runat="server" MaxLength="8" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                    <img onclick="showCalendarControl(document.getElementById('txtDob'),'');" src="../Image/SmallCalendar.gif" /></td>
                <td style="width: 497px">
                </td>
                <td style="width: 47px">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 12px;">
                </td>
                <td colspan="5" style="height: 12px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <span style="font-size: 8pt;
                        font-family: Tahoma">(YYYYMMDD)</span></td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 17px">
                </td>
                <td style="width: 1222px; height: 17px; text-align: left">
                    <span style="font-size: 8pt; font-family: Tahoma">Address</span></td>
                <td colspan="4" style="height: 17px; text-align: left">
                    :<asp:TextBox ID="txtAd1" runat="server" Width="367px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 11px;">
                </td>
                <td style="width: 1222px; height: 11px; text-align: left;">
                    &nbsp;</td>
                <td colspan="4" style="height: 11px; text-align: left">
                    :<asp:TextBox ID="txtAd2" runat="server" Width="367px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 11px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 11px;">
            </td>
                <td style="width: 1222px; height: 11px; text-align: left;">
                    &nbsp;</td>
                <td colspan="4" style="height: 13px; text-align: left">
                    :<asp:TextBox ID="txtAd3" runat="server" Width="367px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 13px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 11px;">
            </td>
                <td style="width: 1222px; height: 11px; text-align: left;">
                    &nbsp;</td>
                <td colspan="4" style="height: 10px; text-align: left">
                    :<asp:TextBox ID="txtAd4" runat="server" Width="367px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
                <td style="width: 47px; height: 10px">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: left; height: 12px;" colspan="5">
                    &nbsp;</td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 1px;">
                </td>
                <td style="text-align: center; height: 1px;" colspan="5">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="Update Second Life and Nominee"
                        Height="50px" Width="241px" BackColor="White" BorderColor="Black" Font-Names="Tahoma" Font-Size="8pt" style="color: black; background-color: silver" ForeColor="#000000">
                        <asp:Button ID="btnUpdsl" runat="server" Font-Bold="True"
                        Text="Update" Width="81px" OnClick="btnUpdsl_Click" /></asp:Panel>
                    </td>
                <td style="width: 47px; height: 1px;">
                </td>
            </tr>
            <tr><td style="width: 173px; height: 12px;">
            </td>
                <td style="text-align: center; height: 12px;" colspan="5">
                    <span style="font-size: 8pt; font-family: Tahoma">&nbsp;</span><asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        ForeColor="#006633" Text="Successfully Updated!" Visible="False" Font-Size="8pt"></asp:Label></td>
                <td style="width: 47px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px; height: 21px;">
                </td>
                <td colspan="5" style="text-align: center; height: 21px;">
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" OnClick="btnSubmit_Click"
                        Text="Submit" Width="71px" Visible="False" />
                    <asp:Button ID="btnEdit" runat="server" Font-Bold="True"
                        Text="Edit" Width="71px" Visible="False" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnNext" runat="server" Font-Bold="True" Text="Next" Width="70px" PostBackUrl="~/OldChildProt/Oldchildprot003.aspx" Enabled="False" />
                    <asp:Button ID="btnMore" runat="server" Font-Bold="True"
                        Text="More>>" Width="71px" PostBackUrl="~/OldChildProt/Oldchildprot001.aspx" /></td>
                <td style="width: 47px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 173px;">
                </td>
                <td style="text-align: left;" colspan="5">
                    &nbsp;<span style="color: #ff3300"><span style="font-family: Tahoma"><span style="font-size: 8pt">* <span style="color: #000000">Required Fields</span></span></span></span></td>
                <td style="width: 47px; color: #000000;">
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 173px; height: 21px;">
                </td>
                <td style="width: 1222px; height: 21px;">
                </td>
                <td style="width: 239px; height: 21px;">
                </td>
                <td style="width: 37px; height: 21px;">
                </td>
                <td style="width: 197px; height: 21px;">
                </td>
                <td style="width: 497px; height: 21px;">
                </td>
                <td style="width: 47px; height: 21px;">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
