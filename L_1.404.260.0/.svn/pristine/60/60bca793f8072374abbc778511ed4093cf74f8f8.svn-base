<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouPrint002.aspx.cs" Inherits="vouPrint002" %>
<%@ Reference Page ="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Policy Surrenders</title>
    
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
        <strong><span style="font-family: Trebuchet MS"/><span/><span style="font-family: Trebuchet MS">
            <span style="font-size: 14pt">Sri Lanka
            Insurance<br/>
            </span>
         Policy Surrender Voucher</span></strong><table style="width: 649px; font-size: 9pt; font-family: Arial; font-variant: normal;">
            <tr>
                <td style="height: 18px; width: 10px;">
                    &nbsp;</td>
                <td colspan="4" style="height: 18px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        VOUCHER FOR PAYMENT OF POLICY SURRENDER</p>
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                </td>
                <td style="height: 18px; text-align: left; width: 161px;">
                </td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    PAYMENT VOUCHER NO.</td>
                <td style="height: 18px; text-align: left; width: 161px;">
                    :
                    <asp:Label ID="lblvouno" runat="server" Width="140px"></asp:Label></td>
                <td style="height: 18px; text-align: left; width: 152px;">
                    DATE</td>
                <td style="height: 18px; text-align: left; width: 134px;">
                    :
                    <asp:Label ID="lbldate" runat="server" Width="108px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    ASSURED'S NAME</td>
                <td style="height: 18px; text-align: left" colspan="3">
                    :
                    <asp:Label ID="lblassuredname" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    POLICY NO.</td>
                <td style="height: 18px; text-align: left; width: 161px;">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="140px"></asp:Label></td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
    <tr>
        <td style="height: 18px; width: 10px;">
        </td>
        <td style="height: 18px; text-align: left; width: 580px;">
            CLASS OF INSURANCE</td>
        <td style="height: 18px; text-align: left; width: 161px;">
            : LIFE</td>
        <td style="height: 18px; text-align: left; width: 152px;">
        </td>
        <td style="height: 18px; text-align: left; width: 134px;">
        </td>
    </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    FULL AMT. OF BONUS RS.</td>
                <td style="height: 18px; text-align: left; width: 161px;">
                    :
                    <asp:Label ID="lblfullbons" runat="server" Width="140px"></asp:Label></td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
             <tr>
                 <td style="width: 10px">
                 </td>
                 <td style="width: 511px; text-align: left">
                     <asp:Label ID="Label1" runat="server" Visible="False" Width="140px">OLD LOAN NO.</asp:Label></td>
                 <td style="width: 161px; text-align: left">
                     <asp:Label ID="lbloldloanNo" runat="server" Visible="False" Width="140px"></asp:Label></td>
                 <td style="width: 152px; text-align: left">
                 </td>
                 <td style="width: 134px; text-align: left">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10px">
                 </td>
                 <td style="width: 511px; text-align: left">
                     <asp:Label ID="Label2" runat="server" Visible="False" Width="140px">OLD LOAN CAPITAL</asp:Label></td>
                 <td style="width: 161px; text-align: left">
                     <asp:Label ID="lbloldLoanCapital" runat="server" Visible="False" Width="140px"></asp:Label></td>
                 <td style="width: 152px; text-align: left">
                 </td>
                 <td style="width: 134px; text-align: left">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10px">
                 </td>
                 <td style="width: 511px; text-align: left">
                     <asp:Label ID="Label3" runat="server" Visible="False" Width="140px">OLD LOAN INTEREST</asp:Label></td>
                 <td style="width: 161px; text-align: left">
                     <asp:Label ID="lbloldLoanInterest" runat="server" Visible="False" Width="140px"></asp:Label></td>
                 <td style="width: 152px; text-align: left">
                 </td>
                 <td style="width: 134px; text-align: left">
                 </td>
             </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 10pt; font-family: Arial">SURRENDER</span> NO.</p>
                </td>
                <td style="height: 18px; text-align: left; width: 161px;">
                    :
                    <asp:Label ID="lblloanno" runat="server" Width="140px"></asp:Label></td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    SURRENDER VALUE RS.</td>
                <td style="height: 18px; text-align: left; width: 161px;">
                    :
                    <asp:Label ID="lblloanval" runat="server" Width="140px"></asp:Label></td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                </td>
                <td style="height: 6px; text-align: left" colspan="3">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    NET AMOUNT PAYABLE RS.</td>
                <td style="height: 18px; text-align: left; width: 161px;">
                    :
                    <asp:Label ID="lblamtinfigures" runat="server" Width="140px"></asp:Label></td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    NET AMOUNT PAYABLE</td>
                <td style="height: 18px; text-align: left; vertical-align: top;" colspan="3">
                    :
                    <asp:Label ID="lblamtinwords" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: center; width: 580px;">
                    (IN WORDS)</td>
                <td style="height: 18px; text-align: left; width: 161px;">
                </td>
                <td style="height: 18px; text-align: left; width: 152px;">
                </td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    NAME OF BANK, BRANCH</td>
                <td style="height: 18px; text-align: left" colspan="3">
                    :
                    <asp:Label ID="lblbkbranch" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    BANK ACCOUNT NO.</td>
                <td style="height: 18px; text-align: left" colspan="3">
                    :
                    <asp:Label ID="lblacctno" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    NAME OF PAYEE</td>
                <td style="height: 18px; text-align: left" colspan="3">
                    :
                    <asp:Label ID="lblnameofpayee" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    NIC NO. /PASSPORT NO.</td>
                <td style="height: 18px; text-align: left" colspan="3">
                    :
                    <asp:Label ID="lblnicorpassport" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                </td>
                <td style="height: 6px; text-align: left; width: 161px;">
                </td>
                <td style="height: 6px; text-align: left; width: 152px;">
                </td>
                <td style="height: 6px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                </td>
                <td style="height: 18px; text-align: center; width: 161px;">
                    ................................</td>
                <td style="height: 18px; text-align: center" colspan="2">
                    .......................................</td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                </td>
                <td style="height: 18px; text-align: center; width: 161px;">
                    PREPARED BY</td>
                <td style="height: 18px; text-align: center" colspan="2">
                    CHECKED BY</td>
            </tr>
            <tr>
                <td style="height: 18px; font-size: 10pt; text-align: left; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; font-size: 10pt; width: 580px;">
                    <span style="font-size: 8pt">DATE</span></td>
                <td style="height: 18px; text-align: left; font-size: 10pt; width: 161px;">
                    <span style="font-size: 8pt">: </span>
                    <asp:Label ID="lblcurrentdate" runat="server" Font-Size="8pt" Width="108px"></asp:Label></td>
                <td style="height: 18px; text-align: left; font-size: 10pt; width: 152px;">
                    <span style="font-size: 8pt">: </span>
                    <asp:Label ID="lblcurrenttime" runat="server" Font-Size="8pt" Width="108px"></asp:Label></td>
                <td style="height: 18px; text-align: left; font-size: 10pt; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                </td>
                <td style="height: 6px; text-align: left; width: 161px;">
                </td>
                <td style="height: 6px; text-align: left; width: 152px;">
                </td>
                <td style="height: 6px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: justify" colspan="4">
                        DECLARATION : I CERTIFY TO MY PERSONAL KNOWLEDGE/ON CERTIFICATES/DOCUMENTS IN THE
                        RELEVANT FILE THAT THE ABOVE MENTIONED TRANSACTION WAS DULY APPROVED AND THAT THE
                        PAYMENT OF THE AMOUNT STATED IN THIS VOUCHER IN WORDS AND FIGURES TO THE PAYEE SHOWN
                        HEREIN IS IN ACCORDANCE WITH THE CONTRACT REGULATIONS AND THAT ALL SUPPLIES/SERVICES
                        HAS BEEN DULY PERFORMED/RENDERED.<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                </td>
                <td style="height: 6px; text-align: left; width: 161px;">
                </td>
                <td style="height: 6px; text-align: left; width: 152px;">
                </td>
                <td style="height: 6px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; width: 580px; text-align: left;">
                    CERTIFYING OFFICER</td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    DESIGNATION</td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    SIGNATURE</td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    : ..........................................................</td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                </td>
                <td style="height: 6px; text-align: left; width: 161px;">
                </td>
                <td style="height: 6px; text-align: left; width: 152px;">
                </td>
                <td style="height: 6px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    DATE OF CHEQUE</td>
                <td style="height: 18px; text-align: left;" colspan="2">
                    : ...............................................</td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    CHEQUE NUMBER</td>
                <td style="height: 18px; text-align: left;" colspan="2">
                    : ...............................................</td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    ACOUNT CODE</td>
                <td style="height: 18px; text-align: left;" colspan="2">
                    : 002392</td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                </td>
                <td style="height: 6px; text-align: left; width: 161px;">
                </td>
                <td style="height: 6px; text-align: left; width: 152px;">
                </td>
                <td style="height: 6px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        CHEQUE TO BE POSTED TO<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><o:p></o:p></p>
                </td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    :
                    <asp:Label ID="lblad1" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                </td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    :
                    <asp:Label ID="lblad2" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                </td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    :
                    <asp:Label ID="lblad3" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 6px; width: 10px;">
                </td>
                <td style="height: 6px; text-align: left; width: 580px;">
                    <span style="font-family: Courier New"></span>
                </td>
                <td style="height: 6px; text-align: left; width: 161px;">
                </td>
                <td style="height: 6px; text-align: left; width: 152px;">
                </td>
                <td style="height: 6px; text-align: left; width: 134px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px;" colspan="5">
                    <span style="font-family: Courier New">
                        <asp:Button ID="btnprint" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                          OnClientClick="cForm1(this.form1)"  OnClick="btnprint_Click" PostBackUrl="~/vouPrint003.aspx" Text=" Print " /></span></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 10px;">
                </td>
                <td style="height: 18px; text-align: left; width: 580px;">
                    <span style="font-family: Courier New"></span>
                </td>
                <td style="height: 18px; text-align: left; width: 161px;">
                </td>
                <td style="height: 18px; text-align: right; width: 152px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="14pt" ForeColor="Blue" NavigateUrl="~/vouMain.aspx">Back</asp:HyperLink></td>
                <td style="height: 18px; text-align: left; width: 134px;">
                </td>
            </tr>
        </table>
        &nbsp;</div>
    </form>
</body>
<script  type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='vouPrint003.aspx';

}

</script>

</html>
