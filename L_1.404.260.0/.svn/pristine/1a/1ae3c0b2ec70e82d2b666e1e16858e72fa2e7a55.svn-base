<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthReg003.aspx.cs" Inherits="dthReg003" %>
<%@ PreviousPageType VirtualPath="~/dthReg002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS">
        </span>
        <table style="font-weight: normal; font-size: 10pt; width: 309px; font-family: Trebuchet MS;">
            <tr>
                <td style="width: 162px; height: 20px; text-align: left">
                </td>
                <td colspan="2" style="height: 20px; text-align: center">
                    <strong><span style="font-size: 11pt">SRI LANKA INSURACE<br />
                        DEATH CLAIM REGISTRATION.</span></strong></td>
                <td style="width: 165px; height: 20px; text-align: left; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                </td>
                <td style="width: 170px; height: 20px; text-align: left">
                </td>
                <td style="width: 166px; height: 20px; text-align: left">
                </td>
                <td style="width: 165px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Claim No.</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblclmno" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Policy No.</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    </td>
                <td style="width: 170px; height: 20px; text-align: left">
                    &nbsp;</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Main Life or <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Spouse</span></td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblmof" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Name of Deceased</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblnameofdead" runat="server" Font-Bold="False" Width="498px"></asp:Label></td>
            </tr>
            <tr style="color: #000000; font-size: 10pt;">
                <td style="width: 162px; height: 20px; text-align: left">
                    Date of Comm.</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofcomm" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Civil or Forces</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblcof" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="color: #000000; font-size: 10pt;">
                <td style="width: 162px; height: 20px; text-align: left">
                    Date of Death</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofdth" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Date of Intimation</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldtofintim" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Policy Status</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpolstat" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Method of Inform</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblmethofinfo" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    <asp:Label ID="lblageatentstr" runat="server" Font-Bold="False" Visible="False" Width="122px">Age At Entry</asp:Label></td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblageatentry" runat="server" Font-Bold="False" Visible="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    <asp:Label ID="lblageatdthstr" runat="server" Font-Bold="False" Visible="False" Width="122px">Age At Death</asp:Label></td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblageatdth" runat="server" Font-Bold="False" Visible="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Sum Assured</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblsumassured" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Table/Term</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbltab" runat="server" Font-Bold="False" Width="50px"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Font-Bold="False" Width="50px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Policy Duration (Paid)</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblduyrs" runat="server" Font-Bold="False" Width="122px"></asp:Label>
                </td>
                <td style="width: 165px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="border-bottom: black thin solid; height: 8px">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 17px; text-align: left">
                    Name of Insured</td>
                <td colspan="3" style="height: 17px; text-align: left">
                    :
                    <asp:Label ID="lblnameofInsured" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Address of Insured</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblassuredad1" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblassuredad2" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="border-bottom: black thin solid; height: 8px; text-align: left">
                    &nbsp;
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Informers ID</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoid" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left; border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                    Death Cetificate</td>
                <td style="width: 165px; height: 20px; text-align: left; border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Informers Relationship</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinforel" runat="server" Font-Bold="False" Width="148px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    Claiment Statement</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Informers Name</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoname" runat="server" Font-Bold="False" Width="154px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    Original Policy</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Informers Tele.</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfotel" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    LMA Report &amp; DT</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Informers Address</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinfoad1" runat="server" Font-Bold="False" Width="156px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    Inquest &amp; PM</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                </td>
                <td style="width: 170px; height: 20px; text-align: left">
                    &nbsp;<asp:Label ID="lblinfoad2" runat="server" Font-Bold="False" Width="104px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    B Certificate &amp; MC</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                </td>
                <td style="width: 170px; height: 20px; text-align: left">
                    &nbsp;<asp:Label ID="lblinfoad3" runat="server" Font-Bold="False" Width="104px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    Duty &amp; Service No.</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                </td>
                <td style="width: 170px; height: 20px; text-align: left">
                    &nbsp;<asp:Label ID="lblinfoad4" runat="server" Font-Bold="False" Width="98px"></asp:Label></td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 166px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 165px; border-bottom: black thin solid; height: 20px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="margin-bottom: 1px; border-bottom: black thin solid; height: 8px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 5px; text-align: center">
                    <asp:Label ID="Label2" runat="server" Text="Nominees" Visible="False" Width="126px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 5px; text-align: left">
                    <asp:Table ID="Table2" runat="server" HorizontalAlign="Left" Width="712px">
                    </asp:Table>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 5px; text-align: center">
                    <asp:Label ID="lblcoverfor" runat="server"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 5px; text-align: left">
                    <asp:Table ID="Table3" runat="server" HorizontalAlign="Left" Width="710px">
                    </asp:Table>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 19px; text-align: left">
                    Age Admit</td>
                <td style="width: 170px; height: 19px; text-align: left">
                    :&nbsp;
                    <asp:Label ID="lblageadmit" runat="server" Font-Bold="False" Width="26px"></asp:Label>
                    &nbsp; &nbsp;&nbsp; Amount</td>
                <td style="width: 166px; height: 19px; text-align: left">
                    :<asp:Label ID="LbAgeAdminAmt" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Width="61px"></asp:Label>Interest</td>
                <td style="width: 165px; height: 19px; text-align: left">
                    :
                    <asp:Label ID="LbAgeAmtInt" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Width="61px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Revivals</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :&nbsp;
                    <asp:Label ID="lblrevivals" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Deposits</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldeposits" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Total Bonus</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :&nbsp;
                    <asp:Label ID="lbltotbons" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Reinsurance</td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblreinsyn" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 162px; height: 20px; text-align: left">
                    Bonus Surrenders</td>
                <td style="width: 170px; height: 20px; text-align: left">
                    :&nbsp;
                    <asp:Label ID="lblbonsurrenders" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    Surrendered Year
                </td>
                <td style="width: 165px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblbonsurryr" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 20px">
                    <asp:Label ID="Label1" runat="server" Font-Size="10.5pt" Text="Previous Loans" Visible="False"
                        Width="215px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 10px">
                    <asp:Table ID="Table1" runat="server" Width="710px" Height="18px">
                    </asp:Table>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 20px;
                    text-align: left">
                    Authorized By &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; : ---------------------------</td>
            </tr>
            <tr>
                <td colspan="4" style="font-size: 8pt; font-family: 'Trebuchet MS'; height: 20px">
                    <asp:Literal ID="LtUserDetails" runat="server"></asp:Literal></td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>

</html>
