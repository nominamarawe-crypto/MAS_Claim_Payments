<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBApproveMemo002.aspx.cs" Inherits="ADBApproveMemo002" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script language="JavaScript" type="text/JavaScript">
<!--
        function MM_goToURL() { //v3.0
            var i, args = MM_goToURL.arguments; document.MM_returnValue = false;
            for (i = 0; i < (args.length - 1); i += 2) eval(args[i] + ".location='" + args[i + 1] + "'");
        }
//-->
</script>

</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong>
        </strong></span>
        <table style="font-weight: normal; font-size: 10pt; width: 539px; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="4" style="height: 21px; background-color: #f0f0f0; text-align: center">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; background-color: #ffffff; text-align: center">
                    <strong>
                    <span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim ADB Payments</span></strong></td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0; text-align: center" colspan="4">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="#00CC33"
                        Width="309px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <span style="text-decoration: underline"><strong>ADB Payment Memo</strong></span></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 18px; text-align: left">
                    Policy Number</td>
                <td style="width: 166px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 18px; text-align: left">
                    Claim Number</td>
                <td style="width: 132px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblclmno" runat="server"  Width="110px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 18px; text-align: left">
                    Table/Term</td>
                <td style="width: 166px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbltab" runat="server"  Width="62px"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Width="62px"></asp:Label></td>
                <td style="width: 168px; height: 18px; text-align: left">
                     </td>
                <td style="width: 132px; height: 18px; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 18px; text-align: left">
                    Date of Commencement</td>
                <td style="width: 166px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblDCO" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 18px; text-align: left">
                    Date of Death</td>
                <td style="width: 132px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbldtofdth" runat="server"  Width="110px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                     </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                     </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                     </td>
            </tr>
            <asp:Panel ID="pnlRequirements" runat="server" Visible="false">
             <tr>
                <td colspan="4" style="border-bottom: black thin solid; height: 16px; text-align: left">
                    <strong><span style="text-decoration: underline">
                    REQUIREMENTS</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 17px;
                    background-color: #f0f0f0; text-align: center">
                </td>
            </tr>
              
            
            <tr>
                <td style="height: 20px; text-align: left" colspan="4">
                    <asp:Label ID="lblmissingReq" runat="server" ForeColor="#FF0033" Width="447px" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            </asp:Panel>
            <tr>
                <td colspan="4" style="border-bottom: black thin solid; height: 16px; text-align: left">
                    <strong><span style="text-decoration: underline">
                    LIABILITY</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 17px;
                    background-color: #f0f0f0; text-align: center">
                </td>
            </tr>
              
            
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                    Accidental Death Benefit</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblADBAmount" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                </td>
                <td style="width: 132px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                    Gross Claim</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblgrossclaim" runat="server"  Width="110px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    </td>
                <td style="width: 132px; height: 20px; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <asp:Panel ID="pnlDeductions1" runat="server" Visible="false">
            <tr>
                <td colspan="4" style="height: 20px; width: 22px; border-bottom: black thin solid; text-align: left;">
                    <strong><span style="text-decoration: underline">DEDUCTIONS</span></strong></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                   <asp:Label ID="lblDeduction1" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblDecucAmt1" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    </td>
                <td style="width: 132px; height: 20px; text-align: left">
                   </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="pnlDeductions2" runat="server" Visible="false">
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                   <asp:Label ID="lblDeduction2" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblDecucAmt2" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    </td>
                <td style="width: 132px; height: 20px; text-align: left">
                   </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            </asp:Panel>
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                   Net Amount Payable</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblNetAmt" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    </td>
                <td style="width: 132px; height: 20px; text-align: left">
                   </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
         
            
            <tr>
                <td style="width: 189px; height: 20px; text-align: left; vertical-align: top;" align="left" valign="top">
                    Minutes</td>
                <td style="width: 184px; height: 20px; text-align: left; vertical-align: top;" align="left" colspan="3" valign="top">
                    <asp:TextBox ID="txtminutes" runat="server" ReadOnly="True" TextMode="MultiLine"
                        Width="401px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: center" colspan="4">
                    <asp:Label ID="lblacceptRestrict" runat="server" ForeColor="#FF0033" Visible="False"
                        Width="442px" Font-Bold="False">This Claim Amount Exceeds Your Finantial Limit to Authorize</asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center">
                    <asp:CheckBox ID="Signature" OnCheckedChanged="ChkSig" runat="server" Text="Display Digital Signature" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; text-align: center">
                    <asp:Button ID="btnaccept" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Accept Memo" Width="141px" onclick="btnaccept_Click" />
                    <asp:Button ID="btnprint" runat="server" Text=" Print "  Font-Bold="True" 
                        Font-Names="Trebuchet MS" onclick="btnprint_Click"/>
                    <asp:Button ID="btnPayshare" runat="server" Visible="false"
                        Text="Distribution of Claim Payment" Font-Bold="True" Font-Names="Trebuchet MS" OnClick="btnPayshare_Click" />
                    </td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: center" colspan="4">
                    &nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        OnClientClick="cForm6(this.form1)" onclick="LinkButton1_Click"><<--Back Voucher Creation</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="height: 10px; text-align: center" colspan="4">
                    <asp:Button ID="btnDischargeEng" runat="server" Text="Discharge English" OnClientClick="cForm4(this.form1)" Font-Bold="True" Font-Names="Trebuchet MS" PostBackUrl="~/ADBDischargeEng001.aspx"/>
                    <asp:Button ID="btnDischargeSinh" runat="server" Text="Discharge Sinhala" OnClientClick="cForm5(this.form1)" Font-Bold="True" Font-Names="Trebuchet MS" Width="167px" PostBackUrl="~/ADBDischargeSin001.aspx"/>
                </td>
            </tr>
           
            
            <tr>
                <td style="width: 189px; height: 10px; background-color: window; text-align: left">
                </td>
                <td style="width: 166px; height: 10px; background-color: window; text-align: left">
                </td>
                <td style="width: 168px; height: 10px; background-color: window; text-align: left">
                </td>
                <td style="width: 132px; height: 10px; background-color: window; text-align: left">
                </td>
            </tr>
        </table>
    
    </div> 
    </form>
</body>
<script type="text/javascript" language="javascript">
    function cForm1(form) {
        win = window.open('', 'myWin', "toolbars=1,scrollbars=1,resizable=1");
        form1.target = 'myWin';
        form1.action = 'ADBApproveMemo003.aspx';

    }
    function cForm2(form) {
        win = window.open('', 'myWin', "toolbars=1,scrollbars=1,resizable=1");
        form1.target = 'myWin';
        form1.action = 'legalHieres001.aspx';

    }

    function cForm3(form) {
        win = window.open('', 'myWin', "toolbars=1,scrollbars=1,resizable=1");
        form1.target = 'myWin';
        form1.action = 'assignee001.aspx';

    }

    function cForm4(form) {
        win = window.open('', 'myWin', "toolbars=1,scrollbars=1,resizable=1");
        form1.target = 'myWin';
        form1.action = 'ADBDischargeEng001.aspx';

    }

    function cForm5(form) {
        win = window.open('', 'myWin', "toolbars=1,scrollbars=1,resizable=1");
        form1.target = 'myWin';
        form1.action = 'ADBDischargeSin001.aspx';

    }
    function cForm6(form) {
        form1.target = '';
        form1.action = '';

    }

</script>

</html>
