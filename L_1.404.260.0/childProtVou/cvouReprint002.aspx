<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cvouReprint002.aspx.cs" Inherits="cvouReprint002" %>
<%@ PreviousPageType VirtualPath="~/childProtVou/cvouReprint001.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>
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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Child Protection Annual Payment Voucher Reprinting<br />
            <table style="font-weight: normal; font-size: 10pt; width: 649px; font-family: Arial;
                font-variant: normal">
                <tr>
                    <td style="width: 10px; height: 18px">
                        &nbsp;</td>
                    <td colspan="4" style="height: 18px">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        VOUCHER FOR ANNUAL PAYMENT OF CHILD PROTECTION</p>
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
                        CLAIM NO.</td>
                    <td style="width: 161px; height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblclaimno" runat="server" Width="140px"></asp:Label></td>
                    <td style="width: 152px; height: 18px; text-align: left">
                    </td>
                    <td style="width: 134px; height: 18px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 511px; text-align: left">
                    CLASS OF INSURANCE</td>
                    <td style="width: 161px; text-align: left">
                    : LIFE</td>
                    <td style="width: 152px; text-align: left">
                    </td>
                    <td style="width: 134px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 511px; text-align: left">
                        VOUCHER TYPE</td>
                    <td style="width: 161px; text-align: left">
                        : DEATH</td>
                    <td style="width: 152px; text-align: left">
                    </td>
                    <td style="width: 134px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 8pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    </td>
                    <td colspan="3" style="height: 18px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 8pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                        <span style="font-size: 10pt">NET AMOUNT PAYABLE RS.</span></td>
                    <td style="width: 161px; height: 18px; text-align: left">
                        <span style="font-size: 10pt">: </span>
                        <asp:Label ID="lblamtinfigures" runat="server" Font-Size="10pt" Width="140px"></asp:Label></td>
                    <td style="width: 152px; height: 18px; text-align: left">
                    </td>
                    <td style="width: 134px; height: 18px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td rowspan="2" style="width: 580px; text-align: left">
                        NET AMOUNT PAYABLE<br />
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    (IN WORDS)</td>
                    <td colspan="3" rowspan="2" style="vertical-align: middle; text-align: left">
                        :
                        <asp:Label ID="lblamtinwords" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    NAME OF BANK, BRANCH</td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblbkbranch" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                        <span>
                    BANK ACCOUNT NO.</span></td>
                    <td colspan="3" style="font-size: 10pt; height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblacctno" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                        NAME OF PAYEE</td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblnameofpayee" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    NIC NO. /PASSPORT NO.</td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblnicorpassport" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    </td>
                    <td style="width: 161px; height: 18px; text-align: center">
                    ................................</td>
                    <td colspan="2" style="height: 18px; text-align: center">
                    .......................................</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    </td>
                    <td style="width: 161px; height: 18px; text-align: center">
                    PREPARED BY</td>
                    <td colspan="2" style="height: 18px; text-align: center">
                    CHECKED BY</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="font-size: 10pt; width: 10px; height: 18px; text-align: left">
                    </td>
                    <td style="font-size: 10pt; width: 580px; height: 18px; text-align: left">
                        <span>DATE</span></td>
                    <td style="font-size: 10pt; width: 161px; height: 18px; text-align: left">
                        <span>: </span>
                        <asp:Label ID="lblcurrentdate" runat="server" Font-Size="8pt" Width="108px"></asp:Label></td>
                    <td style="font-size: 10pt; width: 152px; height: 18px; text-align: left">
                        <span>: </span>
                        <asp:Label ID="lblcurrenttime" runat="server" Font-Size="8pt" Width="108px"></asp:Label></td>
                    <td style="font-size: 10pt; width: 134px; height: 18px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td colspan="4" style="height: 18px; text-align: justify">
                    DECLARATION : I CERTIFY TO MY PERSONAL KNOWLEDGE/ON CERTIFICATES/DOCUMENTS IN THE
                    RELEVANT FILE THAT THE ABOVE MENTIONED TRANSACTION WAS DULY APPROVED AND THAT THE
                    PAYMENT OF THE AMOUNT STATED IN THIS VOUCHER IN WORDS AND FIGURES TO THE PAYEE SHOWN
                    HEREIN IS IN ACCORDANCE WITH THE CONTRACT REGULATIONS AND THAT ALL SUPPLIES/SERVICES
                    HAS BEEN DULY PERFORMED RENDERED.<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                        prefix="o" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><?xml
                                namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></td>
                </tr>
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    CERTIFYING OFFICER</td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        : ..........................................................</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    DESIGNATION</td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        : ..........................................................</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    SIGNATURE</td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        : ..........................................................</td>
                </tr>
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                        DATE OF CHEQUE</td>
                    <td colspan="2" style="height: 18px; text-align: left">
                        : ...............................................</td>
                    <td style="width: 134px; height: 18px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    CHEQUE NUMBER</td>
                    <td colspan="2" style="height: 18px; text-align: left">
                        : ...............................................</td>
                    <td style="width: 134px; height: 18px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                        ACOUNT CODE</td>
                    <td style="width: 161px; height: 18px; text-align: left">
                        : 002118</td>
                    <td style="width: 152px; height: 18px; text-align: left">
                        ACOUNT CODE</td>
                    <td style="width: 134px; height: 18px; text-align: left">
                        : 002142</td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                        AMOUNT</td>
                    <td style="width: 161px; height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblclmAmt" runat="server" Font-Size="10pt" Width="100px"></asp:Label></td>
                    <td style="width: 152px; height: 18px; text-align: left">
                        AMOUNT</td>
                    <td style="width: 134px; height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblExgrAmt" runat="server" Font-Size="10pt" Width="100px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    </td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblad2" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
                    <td style="width: 10px; height: 18px">
                    </td>
                    <td style="width: 580px; height: 18px; text-align: left">
                    </td>
                    <td colspan="3" style="height: 18px; text-align: left">
                        :
                        <asp:Label ID="lblad3" runat="server" Width="400px"></asp:Label></td>
                </tr>
                <tr style="font-size: 10pt">
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
                <tr style="font-size: 10pt">
                    <td colspan="5" style="height: 18px">
                        <span style="font-family: Courier New">
                            <asp:Button ID="btnprint" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                                OnClick="btnprint_Click" OnClientClick="cForm1(this.form1)" PostBackUrl="~/childProtVou/cvouReprint003.aspx"
                                Text=" Reprint " /><asp:Button ID="btnexit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                                   OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                                    Text="  Exit  " />
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                            Font-Size="10pt" ForeColor="Blue"><<--Back</asp:HyperLink></span></td>
                </tr>
                <tr style="font-size: 10pt">
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
<script  type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='cvouReprint003.aspx';

}

</script>

</html>
