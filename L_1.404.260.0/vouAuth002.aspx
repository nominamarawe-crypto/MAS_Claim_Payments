<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouAuth002.aspx.cs" Inherits="vouAuth002" %>
<%@ Reference Page ="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - New Loans</title>
    
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Loan Voucher Authorization<table style="font-size: 10pt; width: 649px; font-family: 'Trebuchet MS';
            font-variant: normal">
            <tr>
                <td style="width: 10px; height: 18px">
                    &nbsp;</td>
                <td colspan="4" style="height: 18px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        VOUCHER FOR PAYMENT OF POLICY LOAN</p>
                </td>
            </tr>
            <tr>
                <td style="height: 18px" colspan="5">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#00CC33"
                        Text="Voucher Authorized" Visible="False" Width="423px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    PAYMENT VOUCHER NO.</td>
                <td style="width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblvouno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 18px; text-align: left">
                    DATE</td>
                <td style="width: 134px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbldate" runat="server" Width="108px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    ASSURED'S NAME</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblassuredname" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    POLICY NO.</td>
                <td style="width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    FULL AMT. OF BONUS</td>
                <td style="width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblfullbons" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NEW LOAN NO.</td>
                <td style="width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblloanno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NET LOAN VALUE</td>
                <td style="width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblloanval" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td colspan="3" style="height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NET AMOUNT PAYABLE</td>
                <td style="width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblamtinfigures" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NET AMOUNT PAYABLE</td>
                <td colspan="3" style="vertical-align: top; text-align: left" rowspan="2">
                    :
                    <asp:Label ID="lblamtinwords" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: center">
                    (IN WORDS)</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NAME OF BANK, BRANCH</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblbkbranch" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    BANK ACCOUNT NO.</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblacctno" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NAME OF PAYEE</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblnameofpayee" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    NIC NO. /PASSPORT NO.</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblnicorpassport" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: center">
                    ................................</td>
                <td colspan="2" style="height: 18px; text-align: center">
                    .......................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: center">
                    PREPARED BY</td>
                <td colspan="2" style="height: 18px; text-align: center">
                    CHECKED BY</td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 10px; height: 18px; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 580px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">DATE</span></td>
                <td style="font-size: 10pt; width: 161px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblcurrentdate" runat="server" Font-Size="10pt" Width="108px"></asp:Label></td>
                <td style="font-size: 10pt; width: 152px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblcurrenttime" runat="server" Font-Size="10pt" Width="108px"></asp:Label></td>
                <td style="font-size: 10pt; width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td colspan="4" style="height: 18px; text-align: justify">
                    DECLARATION : I CERTIFY TO MY PERSONAL KNOWLEDGE/ON CERTIFICATES/DOCUMENTS IN THE
                    RELEVANT FILE THAT THE ABOVE MENTIONED TRANSACTION WAS DULY APPROVED AND THAT THE
                    PAYMENT OF THE AMOUNT STATED IN THIS VOUCHER IN WORDS AND FIGURES TO THE PAYEE SHOWN
                    HEREIN IS IN ACCORDANCE WITH THE CONTRACT REGULATIONS AND THAT ALL SUPPLIES/SERVICES
                    HAS BEEN DULY PERFORMED RENDERED.<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                        prefix="o" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    CERTIFYING OFFICER</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    DESIGNATION</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    SIGNATURE</td>
                <td colspan="3" style="height: 18px; text-align: left">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    DATE OF CHEQUE</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    : ...............................................</td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    CHEQUE NUMBER</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    : ...............................................</td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    ACOUNT CODE</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    : 001290</td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        CHEQUE TO BE POSTED TO<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><o:p></o:p></p>
                </td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblad1" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblad2" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                </td>
                <td colspan="3" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblad3" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    <span style="font-family: Courier New"></span>
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: left">
                </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px">
                    <span style="font-family: Courier New">
                        <asp:Button ID="btnok" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                            OnClick="btnok_Click" Text="Authorize" /><asp:Button ID="btnExit" runat="server"
                                Font-Bold="True" Font-Names="Trebuchet MS" Text="  Exit  " OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" ForeColor="Blue" NavigateUrl="~/vouMain.aspx"><<--Back</asp:HyperLink></span></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 18px">
                </td>
                <td style="width: 580px; height: 18px; text-align: left">
                    <span style="font-family: Courier New"></span>
                </td>
                <td style="width: 161px; height: 18px; text-align: left">
                </td>
                <td style="width: 152px; height: 18px; text-align: right">
                    </td>
                <td style="width: 134px; height: 18px; text-align: left">
                </td>
            </tr>
        </table>
        </span></strong>
    
    </div>
    </form>
</body>
</html>
