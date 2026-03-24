<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthRev002.aspx.cs" Inherits="dthRev002" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/dthRev001.aspx"%>
<%@ Reference Page="~/loanCalculation.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>

</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span><span style="font-family: Trebuchet MS"><strong><span style="font-size: 14pt">
        </span></strong></span></span><table style="font-weight: bold; font-size: 10pt; width: 753px; font-family: 'Trebuchet MS';">
            <tr>
                <td style="width: 31px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 33px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px; background-color: #ffffff">
                    <span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Reverse</span></td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                    <asp:Label ID="lblsucess" runat="server" Text="Intimation Successfully Reveresed" Width="406px" ForeColor="#00CC33" Visible="False" Font-Bold="True" Font-Size="12pt"></asp:Label></td>
                <td style="width: 33px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Policy No.</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 146px; height: 20px; text-align: left">
                    Main Life or <span style="font-family: Times New Roman">
                        Spouse</span></td>
                <td style="width: 190px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblmof" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Name of Dead Person</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblnameofdead" runat="server" Font-Bold="False" Width="498px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; background-color: #f0f0f0">
                    &nbsp;</td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Date of Death</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofdth" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 146px; height: 20px; text-align: left">
                    Date of Intimation</td>
                <td style="width: 190px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofintim" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-weight: normal; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="font-weight: normal; height: 18px; background-color: #f0f0f0;
                    text-align: left">
                    &nbsp; YYYYMMDD</td>
                <td colspan="2" style="font-weight: normal; height: 18px; background-color: #f0f0f0;
                    text-align: left">
                    &nbsp; YYYYMMDD</td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Policy Status</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolstat" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 146px; height: 20px; text-align: left">
                    Method of Inform</td>
                <td style="width: 190px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblmethofinfo" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; background-color: #f0f0f0">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Sum Assured</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblsumassured" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 146px; height: 20px; text-align: left">
                    Table/Term</td>
                <td style="width: 190px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbltab" runat="server" Font-Bold="False" Width="50px"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Font-Bold="False" Width="50px"></asp:Label>
                </td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Name of Insured</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblnameofInsured" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Address of Insured</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblassuredad1" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblassuredad2" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Date of Commencement</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofcomm" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 146px; height: 20px; text-align: left">
                    <asp:Label ID="lblageatentrystr" runat="server" Font-Bold="True" Visible="False"
                        Width="122px">Age At Entry</asp:Label></td>
                <td style="width: 190px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblageatentry" runat="server" Font-Bold="False" Width="122px" Visible="False"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 18px; background-color: #f0f0f0;
                    text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Informers ID</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoid" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="height: 20px; text-align: left" colspan="2">
                    <asp:Label ID="testlbl" runat="server" ForeColor="#FF0033" Font-Bold="True"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 190px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 33px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Informers Name</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoname" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 219px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 201px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 190px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 33px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Informers Relationship</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinforel" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 219px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 201px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 190px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 33px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 19px">
                </td>
                <td style="width: 219px; height: 19px; text-align: left">
                    Informers Address</td>
                <td colspan="3" style="height: 19px; text-align: left">
                    :
                    <asp:Label ID="lblinfoad1" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 19px">
                </td>
                <td style="width: 219px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp; &nbsp;
                    <asp:Label ID="lblinfoad2" runat="server" Font-Bold="False" Width="426px"></asp:Label></td>
                <td style="width: 33px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 19px">
                </td>
                <td style="width: 219px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp; <asp:Label ID="lblinfoad3" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 19px">
                </td>
                <td style="width: 219px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp; &nbsp;
                    <asp:Label ID="lblinfoad4" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="width: 33px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 219px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 201px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 146px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 190px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 33px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 20px">
                </td>
                <td style="width: 219px; height: 20px; text-align: left">
                    Informers Tele.</td>
                <td style="width: 201px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfotel" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td colspan="2" style="height: 20px; text-align: left">
                </td>
                <td style="width: 33px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="border-bottom: black thin solid; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 219px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 201px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 190px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 33px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px">
                    &nbsp;<asp:Button ID="btnRev" runat="server" OnClick="btnReverse_Click" Text="Reverse" Font-Bold="True" Font-Names="Trebuchet MS" Width="84px" />&nbsp;<asp:Button
                        ID="btnexit" runat="server" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                        Text="  Exit  " Font-Bold="True" Font-Names="Trebuchet MS" Width="72px" /></td>
            </tr>
            <tr>
                <td style="width: 31px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 219px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 201px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 190px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 33px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
