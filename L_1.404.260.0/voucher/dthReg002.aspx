<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthReg002.aspx.cs" Inherits="dthReg002" %>
<%@ PreviousPageType VirtualPath="~/dthReg001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>

<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS">
        <span><span style="font-size: 14pt">
        </span></span></span>
        <table style="font-weight: normal; font-size: 10pt; width: 655px; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px; background-color: #ffffff">
                    <span style="font-weight: bold; font-size: 12pt; font-family: 'Trebuchet MS'"><span
                        style="font-weight: bold; font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span>Death Claim Registration</span></td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                    <asp:Label ID="lblsucess" runat="server" ForeColor="LimeGreen" Text="Intimation Successfully Registered"
                        Visible="False" Width="406px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Policy No.</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Main Life or <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Spouse</span></td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblmof" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    <asp:Label ID="testlbl" runat="server" Font-Bold="True" Width="326px" ForeColor="#FF0033" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Name of Deceased</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblnameofdead" runat="server" Font-Bold="True" Width="498px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 8px; background-color: #f0f0f0">
                    <asp:Label ID="lbldatemismatch" runat="server" ForeColor="#FF0000" Width="566px"></asp:Label>&nbsp;</td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Date of Death</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:TextBox ID="txtdtofdth" runat="server" Width="87px" MaxLength="8" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Date of Intimation</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofintim" runat="server" Font-Bold="True" Width="92px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-weight: normal; height: 8px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="font-weight: normal; height: 8px; background-color: #f0f0f0;
                    text-align: left">
                    &nbsp;&nbsp; YYYYMMDD</td>
                <td colspan="2" style="font-weight: normal; height: 8px; background-color: #f0f0f0;
                    text-align: left">
                    &nbsp;&nbsp; YYYYMMDD</td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Policy Status</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolstat" runat="server" Font-Bold="True" Width="106px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Method of Inform</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblmethofinfo" runat="server" Font-Bold="True" Width="110px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Sum Assured</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblsumassured" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Table/Term</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbltab" runat="server" Font-Bold="True" Width="50px" Font-Italic="False"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Font-Bold="True" Width="50px"></asp:Label>
                </td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Name of Insured</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblnameofInsured" runat="server" Font-Bold="True" Width="428px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Address of Insured</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblassuredad1" runat="server" Font-Bold="True" Width="428px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    &nbsp;
                    <asp:Label ID="lblassuredad2" runat="server" Font-Bold="True" Width="428px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Date of Comm.</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofcomm" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Date of Exit</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofexit" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Civil or Forces</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblcof" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                </td>
                <td style="width: 156px; height: 20px; text-align: left">
                </td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0;
                    text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    <asp:Label ID="lblageatentstr" runat="server" Font-Bold="True" Visible="False" Width="122px">Age At Entry</asp:Label></td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblageatentry" runat="server" Font-Bold="True" Visible="False" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    <asp:Label ID="lblageatdthstr" runat="server" Font-Bold="True" Visible="False" Width="122px">Age At Death</asp:Label></td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblageatdth" runat="server" Font-Bold="True" Visible="False" Width="122px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0;
                    text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Informers ID</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoid" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Informers Relation</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinforel" runat="server" Font-Bold="True" Width="140px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Informers Name</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoname" runat="server" Font-Bold="True" Width="428px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 19px">
                </td>
                <td style="width: 172px; height: 19px; text-align: left">
                    Informers Address</td>
                <td colspan="3" style="height: 19px; text-align: left">
                    :
                    <asp:Label ID="lblinfoad1" runat="server" Font-Bold="True" Width="412px"></asp:Label></td>
                <td style="width: 38590576px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 19px">
                </td>
                <td style="width: 172px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblinfoad2" runat="server" Font-Bold="True" Width="412px"></asp:Label></td>
                <td style="width: 38590576px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 19px">
                </td>
                <td style="width: 172px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblinfoad3" runat="server" Font-Bold="True" Width="412px"></asp:Label></td>
                <td style="width: 38590576px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 19px">
                </td>
                <td style="width: 172px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblinfoad4" runat="server" Font-Bold="True" Width="412px"></asp:Label></td>
                <td style="width: 38590576px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left" colspan="4">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left">
                    Informers Tele.</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfotel" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td colspan="2" style="height: 20px; text-align: left">
                </td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0; margin-bottom: 1px;">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="height: 20px" colspan="4">
                    CLAIM FORM</td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 172px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 174px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 153px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 156px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left;">
                    Claim No.</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:TextBox ID="txtclmno" runat="server" Height="15px" MaxLength="10" Width="115px" Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Policy Duration</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolicyDuratn" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtclmno"
                        ErrorMessage="Please Enter Claim Number"></asp:RequiredFieldValidator></td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 5px">
                </td>
                <td style="height: 5px; text-align: center;" colspan="4">
                    <asp:Label ID="Label2" runat="server" Text="Nominees" Visible="False" Width="126px" style="font-family: 'Trebuchet MS'; text-decoration: underline"></asp:Label></td>
                <td style="width: 38590576px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 5px">
                </td>
                <td style="height: 5px; text-align: left;" colspan="4">
                    <asp:Table ID="Table2" runat="server" Width="712px" HorizontalAlign="Left" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:Table>
                </td>
                <td style="width: 38590576px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 172px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 174px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 153px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 156px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 5px">
                </td>
                <td colspan="4" style="height: 5px; text-align: center">
                    <asp:Label ID="lblcoverfor" runat="server" style="font-family: 'Trebuchet MS'; text-decoration: underline"></asp:Label></td>
                <td style="width: 38590576px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 5px">
                </td>
                <td colspan="4" style="height: 5px; text-align: left">
                    <asp:Table ID="Table3" runat="server" Width="710px" HorizontalAlign="Left" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:Table>
                </td>
                <td style="width: 38590576px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 172px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 174px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 153px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 156px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 19px">
                </td>
                <td style="width: 172px; height: 19px; text-align: left;">
                    Age Admit</td>
                <td style="width: 174px; height: 19px; text-align: left">
                    :
                    <asp:DropDownList ID="ddlageadmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="75px">
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;Amount</td>
                <td style="width: 153px; height: 19px; text-align: left">
                    <asp:TextBox ID="TxtAgeEntry" runat="server" Width="85px" style="text-align: right" Font-Names="Trebuchet MS" Font-Size="10pt">0.00</asp:TextBox>
                    &nbsp; Interest</td>
                <td style="width: 156px; height: 19px; text-align: left">
                    :
                    <asp:TextBox ID="TxtAgeEntryInter" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Style="text-align: right" Width="85px">0.00</asp:TextBox></td>
                <td style="width: 38590576px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 172px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 174px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 153px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 156px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left;">
                    Revivals</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:DropDownList ID="ddlrinsYN" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="75px">
                    </asp:DropDownList></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Deposits</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldeposits" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 172px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 174px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 153px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 156px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left;">
                    Total Bonus</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbltotbons" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Reinsurance</td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblreinsyn" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 172px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 174px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 153px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 156px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px">
                </td>
                <td style="width: 172px; height: 20px; text-align: left;">
                    Bonus Surrenders</td>
                <td style="width: 174px; height: 20px; text-align: left">
                    :
                    <asp:DropDownList ID="ddlbonsurrYN" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="75px" >
                        <asp:ListItem Value="N">No</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 153px; height: 20px; text-align: left">
                    Surrendered Year
                </td>
                <td style="width: 156px; height: 20px; text-align: left">
                    :
                    <asp:TextBox ID="txtbonsurryr" runat="server" Height="15px" MaxLength="4" Width="115px" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 38590576px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 651px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                    <asp:Label ID="lblmessage" runat="server" ForeColor="#FF3300" Width="407px"></asp:Label></td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="6">
                    <asp:Label ID="Label1" runat="server" Font-Size="10pt" Text="Previous Loans" Visible="False"
                        Width="215px" Font-Bold="True" Font-Underline="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="6">
                    <asp:Table ID="Table1" runat="server" Width="710px" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px">
                    <asp:Button ID="btnregister" runat="server" Text="--Register--" OnClick="btnregister_Click" OnClientClick="cForm7(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="109px" />
                    <asp:Button ID="btnloanreciept" runat="server" Text="--Print Loan Reciept--" OnClientClick="cForm2(this.form1)" Visible="False" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="154px"  PostBackUrl="~/loanReciept.aspx" />&nbsp;
                    <asp:Button ID="btnprint" runat="server" Text="--Print Details--"  OnClientClick="cForm1(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" PostBackUrl="~/dthReg003.aspx"  />
                    <asp:Button ID="btnnext" OnClientClick="cForm7(this.form1)" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        PostBackUrl="~/dthreq.aspx" Text="--Next--" Width="80px" /></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 20px; background-color: #f0f0f0">
                    &nbsp;&nbsp;
                </td>
                <td style="width: 38590576px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='dthReg003.aspx';

}

function cForm2(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='loanReciept.aspx';

}

function cForm3(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='legalHieres001.aspx';

}

function cForm4(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='assignee001.aspx';

}
function cForm5(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='nomDetEnt01.aspx';

}
function cForm6(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='livingPrt001.aspx';

}
function cForm7(form)
{ 
 form1.target='';
 form1.action='';

}

</script>

</html>
