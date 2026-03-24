<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepudiatePay003.aspx.cs" Inherits="RepudiatePay003" %>
<%@ PreviousPageType VirtualPath="~/RepudiatePay002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script  type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='RepudiatePay003.aspx';
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 37px; height: 21px">
                </td>
                <td style="width: 174px; height: 21px">
                    &nbsp;</td>
                <td style="width: 157px; height: 21px">
                </td>
                <td style="width: 173px; height: 21px">
                </td>
                <td style="width: 126px; height: 21px">
                </td>
                <td style="width: 36px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px">
                </td>
                <td colspan="4" style="text-align: center">
                    <strong><span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt; font-family: Trebuchet MS">
                        <asp:Label ID="lblHeading" runat="server"></asp:Label></span></strong></td>
                <td style="width: 36px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 21px;">
                </td>
                <td style="width: 174px; height: 21px;">
                    &nbsp;</td>
                <td style="width: 157px; height: 21px;">
                </td>
                <td style="width: 173px; height: 21px;">
                </td>
                <td style="width: 126px; height: 21px;">
                </td>
                <td style="width: 36px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 8px">
                </td>
                <td style="width: 174px; height: 8px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Policy Number</span></td>
                <td style="width: 157px; height: 8px">
                    :
                    <asp:Label ID="lblpolno" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 8px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Claim Number</span></td>
                <td style="width: 126px; height: 8px">
                    :
                    <asp:Label ID="lblclmno" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 8px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 5px;">
                </td>
                <td style="width: 174px; height: 5px;">
                    &nbsp;</td>
                <td style="width: 157px; height: 5px;">
                </td>
                <td style="width: 173px; height: 5px;">
                </td>
                <td style="width: 126px; height: 5px;">
                </td>
                <td style="width: 36px; height: 5px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 9px;">
                </td>
                <td style="width: 174px; height: 9px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Table/Term</span></td>
                <td style="width: 157px; height: 9px;">
                    :
                    <asp:Label ID="lbltab" runat="server" Width="62px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Width="62px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 9px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Policy Status</span></td>
                <td style="width: 126px; height: 9px;">
                    :
                    <asp:Label ID="lblpolstat" runat="server" Width="110px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 9px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 1px;">
                </td>
                <td style="width: 174px; height: 1px;">
                    &nbsp;</td>
                <td style="width: 157px; height: 1px;">
                </td>
                <td style="width: 173px; height: 1px;">
                </td>
                <td style="width: 126px; height: 1px;">
                </td>
                <td style="width: 36px; height: 1px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 2px;">
                </td>
                <td style="width: 174px; height: 2px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Date of Commencement</span></td>
                <td style="width: 157px; height: 2px;">
                    :
                    <asp:Label ID="lblCom" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 2px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Date of Death</span></td>
                <td style="width: 126px; height: 2px;">
                    :
                    <asp:Label ID="lbldtofdth" runat="server" Width="110px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 2px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 10px;">
                </td>
                <td colspan="4" style="border-bottom: black thin solid; height: 10px;">
                    &nbsp;</td>
                <td style="width: 36px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 3px">
                </td>
                <td style="width: 174px; height: 3px">
                    &nbsp;</td>
                <td style="width: 157px; height: 3px">
                </td>
                <td style="width: 173px; height: 3px">
                </td>
                <td style="width: 126px; height: 3px">
                </td>
                <td style="width: 36px; height: 3px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 9px;">
                </td>
                <td style="width: 174px; height: 9px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Exgracia Claim Amount</span></td>
                <td style="width: 157px; height: 9px;">
                    :
                    <asp:Label ID="lblExclaim" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 9px;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Claim Amount</span></td>
                <td style="width: 126px; height: 9px;">
                    :
                    <asp:Label ID="lblClaim" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 9px;">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 16px">
                </td>
                <td style="width: 174px; height: 16px">
                    &nbsp;</td>
                <td style="width: 157px; height: 16px">
                </td>
                <td style="width: 173px; height: 16px">
                </td>
                <td style="width: 126px; height: 16px">
                </td>
                <td style="width: 36px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 10px">
                </td>
                <td style="width: 174px; height: 10px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Bonus Amount</span></td>
                <td style="width: 157px; height: 10px">
                    :
                    <asp:Label ID="lblBonus" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 10px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Deposit</span></td>
                <td style="width: 126px; height: 10px">
                    :
                    <asp:Label ID="lblDeposit" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 7px">
                </td>
                <td style="width: 174px; height: 7px">
                    &nbsp;</td>
                <td style="width: 157px; height: 7px">
                </td>
                <td style="width: 173px; height: 7px">
                </td>
                <td style="width: 126px; height: 7px">
                </td>
                <td style="width: 36px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 7px">
                </td>
                <td style="width: 174px; height: 7px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Other Additions</span></td>
                <td style="width: 157px; height: 7px">
                    :
                    <asp:Label ID="lblOtheradds" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 7px">
                </td>
                <td style="width: 126px; height: 7px">
                </td>
                <td style="width: 36px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 7px">
                </td>
                <td style="width: 174px; height: 7px">
                </td>
                <td style="width: 157px; height: 7px">
                </td>
                <td style="width: 173px; height: 7px">
                </td>
                <td style="width: 126px; height: 7px">
                </td>
                <td style="width: 36px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 15px">
                </td>
                <td style="height: 15px; border-bottom: black thin solid; text-align: center;" colspan="4">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Deductions</span></strong></td>
                <td style="width: 36px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 12px">
                </td>
                <td style="width: 174px; height: 12px">
                    &nbsp;</td>
                <td style="width: 157px; height: 12px">
                </td>
                <td style="width: 173px; height: 12px">
                </td>
                <td style="width: 126px; height: 12px">
                </td>
                <td style="width: 36px; height: 12px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 13px">
                </td>
                <td style="width: 174px; height: 13px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Default Premium</span></td>
                <td style="width: 157px; height: 13px">
                    :
                    <asp:Label ID="lblDefprem" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 13px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Premium Interest</span></td>
                <td style="width: 126px; height: 13px">
                    :
                    <asp:Label ID="lblPremint" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 8px">
                </td>
                <td style="width: 174px; height: 8px">
                    &nbsp;</td>
                <td style="width: 157px; height: 8px">
                </td>
                <td style="width: 173px; height: 8px">
                </td>
                <td style="width: 126px; height: 8px">
                </td>
                <td style="width: 36px; height: 8px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 14px">
                </td>
                <td style="width: 174px; height: 14px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Loan Capital</span></td>
                <td style="width: 157px; height: 14px">
                    :
                    <asp:Label ID="lblLoancap" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 14px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Loan Interest</span></td>
                <td style="width: 126px; height: 14px">
                    :
                    <asp:Label ID="lblLoanint" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 13px">
                </td>
                <td style="width: 174px; height: 13px">
                    &nbsp;</td>
                <td style="width: 157px; height: 13px">
                </td>
                <td style="width: 173px; height: 13px">
                </td>
                <td style="width: 126px; height: 13px">
                </td>
                <td style="width: 36px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 21px">
                </td>
                <td style="width: 174px; height: 21px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Amt. to Complete Policy Year</span></td>
                <td style="width: 157px; height: 21px">
                    :
                    <asp:Label ID="lblComplyr" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 21px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Other Deduction</span></td>
                <td style="width: 126px; height: 21px">
                    :
                    <asp:Label ID="lblOtherdeduct" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 36px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 15px">
                </td>
                <td style="width: 174px; height: 15px">
                    &nbsp;</td>
                <td style="width: 157px; height: 15px">
                </td>
                <td style="width: 173px; height: 15px">
                </td>
                <td style="width: 126px; height: 15px">
                </td>
                <td style="width: 36px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 14px">
                </td>
                <td style="width: 174px; height: 14px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Total</span></td>
                <td style="width: 157px; height: 14px">
                    :
                    <asp:Label ID="lblTotal" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 173px; height: 14px">
                </td>
                <td style="width: 126px; height: 14px">
                </td>
                <td style="width: 36px; height: 14px">
                </td>
            </tr>
            <% if ((Table == 38 || Table == 39 || Table == 46 || Table == 49 || Table == 34) && Mos == "M")
               {  %>
            <tr>
                <td style="width: 37px; height: 15px">
                </td>
                <td style="width: 174px; height: 15px">
                    &nbsp;</td>
                <td style="width: 157px; height: 15px">
                </td>
                <td style="width: 173px; height: 15px">
                </td>
                <td style="width: 126px; height: 15px">
                </td>
                <td style="width: 36px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 14px">
                </td>
                <td style="width: 174px; height: 14px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Is Future Payment</span></td>
                <td style="width: 157px; height: 14px">
                    :
                     <asp:DropDownList ID="ddlFuturePay" runat="server" Width="80px">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 173px; height: 14px">
                </td>
                <td style="width: 126px; height: 14px">
                </td>
                <td style="width: 36px; height: 14px">
                </td>
            </tr
            <% } %>
            <tr>
                <td style="width: 37px; height: 12px">
                </td>
                <td colspan="4" style="height: 12px">
                    &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="This Claim Amount Exceeds Your Finantial Limit to Authorize"
                        Width="538px"></asp:Label></td>
                <td style="width: 36px; height: 12px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: center">
                    <asp:Button ID="btnAccept" runat="server" Font-Bold="True" Text="Accept" Width="80px" Height="28px" OnClick="btnAccept_Click" />
                    <asp:Button ID="btnPrint" runat="server" Font-Bold="True" Text="Print" Width="80px" Height="28px" PostBackUrl="~/RepudiatePay004.aspx" OnClientClick="cForm1(this.form1)" OnClick="btnPrint_Click" />
                    <asp:Button ID="Button3" runat="server" Font-Bold="True" Text="Distribution" Width="80px" Height="28px" OnClick="Button3_Click" /></td>
                <td style="width: 36px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 12px">
                </td>
                <td style="width: 174px; height: 12px">
                    &nbsp;</td>
                <td style="width: 157px; height: 12px">
                </td>
                <td style="width: 173px; height: 12px">
                </td>
                <td style="width: 126px; height: 12px">
                </td>
                <td style="width: 36px; height: 12px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 12px">
                </td>
                <td style="width: 174px; height: 12px">
                </td>
                <td style="width: 157px; height: 12px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"><strong>Discharge Letters</strong></span></td>
                <td style="width: 173px; height: 12px">
                    <asp:Button ID="cmdDissin" runat="server" Font-Bold="True" Height="28px" Text="Sinhala" OnClick="cmdDissin_Click" />
                    <asp:Button ID="cmdDiseng" runat="server" Font-Bold="True" Height="28px" Text="English" OnClick="cmdDiseng_Click" /></td>
                <td style="width: 126px; height: 12px">
                </td>
                <td style="width: 36px; height: 12px">
                </td>
            </tr>
            <tr>
                <td style="width: 37px; height: 12px">
                </td>
                <td style="width: 174px; height: 12px">
                    &nbsp;</td>
                <td style="width: 157px; height: 12px">
                </td>
                <td style="width: 173px; height: 12px">
                </td>
                <td style="width: 126px; height: 12px">
                </td>
                <td style="width: 36px; height: 12px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
