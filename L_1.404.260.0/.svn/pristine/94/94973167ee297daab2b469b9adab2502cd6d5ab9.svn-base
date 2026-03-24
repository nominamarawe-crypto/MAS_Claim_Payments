<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildProtPay002.aspx.cs" Inherits="ChildProt_ChildProtPay002" %>
<%@ Reference Page ="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Child Protect Payments</title>
    <script  type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='ChildProtPay002.aspx';
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
            <span></span></span>Death Claims -&nbsp; Annual Child Protection Payments Due to
            <asp:Label ID="lbldue" runat="server" ForeColor="#990066" Font-Size="10pt"></asp:Label><br />
        </span></strong>
        <br />
       
     
        <table style="font-weight: bold; font-size: 10pt; width: 650px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0; text-align: center">
            <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td style="width: 128px; height: 18px">
                </td>
                <td style="width: 157px; height: 18px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px; text-align: left">
                    Policy No.</td>
                <td style="width: 128px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="105px"></asp:Label></td>
                <td style="width: 157px; height: 18px; text-align: left">
                    Maturity Date</td>
                <td style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblmatdate" runat="server" Width="105px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px; text-align: left">
                    Claim No.</td>
                <td style="width: 128px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblclmno" runat="server" Width="105px"></asp:Label></td>
                <td style="width: 157px; height: 18px; text-align: left">
                    Date of Death</td>
                <td style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbldtofdeath" runat="server" Width="105px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 18px">
                    <asp:Label ID="lblmessage" runat="server" ForeColor="#FF0033" Width="325px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 18px; text-align: left">
                    Outstanding Dues</td>
                <td style="width: 157px; height: 18px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px">
                    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                        HorizontalAlign="Left" Width="640px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td style="width: 128px; height: 18px">
                </td>
                <td colspan="2" style="height: 18px; text-align: right">
                    &nbsp;
                </td>
            </tr>
                        <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td style="text-align:right " colspan="2">
                    <asp:CheckBox ID="Signature" OnCheckedChanged="ChkSig" runat="server" Text="Display Digital Signature" /> 
                </td>
                <td style="width: 157px; height: 18px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td colspan="2" style="height: 18px; text-align: right">
                    <asp:Button ID="btnVouCr" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnVouCr_Click" Text="Create Voucher" /><asp:Button ID="btnExit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                        Text="  Exit  " Width="88px" /></td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td style="width: 128px; height: 18px">
                </td>
                <td style="width: 157px; height: 18px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 15px">
                </td>
                <td colspan="2" style="height: 15px; text-align: right">
                    Discharge Letter&nbsp;<asp:Button ID="btnDischgsin" runat="server" Font-Bold="True" Text="Sinhala" OnClientClick="cForm1(this.form1)" OnClick="btnDischgsin_Click" Height="27px" Width="90px" PostBackUrl="~/letters/minimuthudischgsin001.aspx" /><asp:Button
                        ID="btnDischgeng" runat="server" Font-Bold="True" Text="English" OnClientClick="cForm1(this.form1)" Height="27px" OnClick="btnDischgeng_Click" Width="90px" PostBackUrl="~/letters/minimuthudischgsin002.aspx" /></td>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td colspan="2" style="height: 18px; text-align: right">
                    Certificate of Residence
                    <asp:Button ID="btnCerressin" runat="server" Font-Bold="True"
                        Text="Sinhala" OnClientClick="cForm1(this.form1)" Height="27px" Width="90px" OnClick="btnCerressin_Click" PostBackUrl="~/letters/minimuthusin001.aspx" /><asp:Button ID="btnCerreseng" runat="server" Font-Bold="True" Text="English" OnClientClick="cForm1(this.form1)" Height="27px" OnClick="btnCerreseng_Click" Width="90px" PostBackUrl="~/letters/minimuthueng001.aspx" /></td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 18px" colspan="3">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;Minimuthu DischargeCovering
                    Letter
                    <asp:Button ID="Button1" runat="server" Font-Bold="True"
                        Text="Sinhala" OnClientClick="cForm1(this.form1)" Height="27px" Width="90px" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Font-Bold="True" Text="English" OnClientClick="cForm1(this.form1)" Height="27px" Width="90px" OnClick="Button2_Click" /></td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 18px">
                </td>
                <td style="width: 128px; height: 18px">
                </td>
                <td style="width: 157px; height: 18px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
        </table>
   
   
    </div>
    </form>
</body>
</html>
