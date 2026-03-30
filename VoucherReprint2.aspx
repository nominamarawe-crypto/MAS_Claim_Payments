<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoucherReprint2.aspx.cs" Inherits="MAS_Claim_Payments.VoucherReprint2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 780px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style5 {
            width: 268435392px;
        }
        .auto-style6 {
            width: 804px;
        }
        .auto-style7 {
            font-size: xx-small;
        }
    </style>

    <style type="text/css" media="print">
    .notprint
    {
      display:none;
    }
</style>

  <script language="javascript" type="text/javascript">
// <![CDATA[

        function btnPrint_onclick() {
            window.print();
            var btn = document.getElementById('btnHidden');
            btn.style.visibility = 'visible';
            btn.click();
            btn.style.visibility = 'hidden';
        }

        

// ]]>
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="text-align: left" class="auto-style6">
            <table align="left" class="auto-style1" style="color: #000000;">    
        <tr>
            <td class="style35" colspan="6" style="text-align: center">
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lblPayMode" runat="server" Font-Bold="True" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" Font-Underline="True" 
                    style="text-align: center; font-size: 11pt;">SLIP</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" 
                style="text-align: left; border-bottom-color: #000000; border-bottom-width: 1px; border-bottom-style: solid;">
                <asp:Label ID="lblTopic11" runat="server" Font-Bold="True" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 11pt;" Text="LAB Claim Voucher-"></asp:Label>
                <asp:Label ID="lblVouGenBranch" runat="server" Font-Bold="True" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 11pt;"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDate2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style33" colspan="6" style="text-align: right">
                <asp:Label ID="lblAnnPayDate" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;" Text="Date of Claim"></asp:Label>
                <asp:Label ID="lbl36" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
                &nbsp;<asp:Label ID="lblAnnDate" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style33" colspan="6" style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHeadOfAccount3" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;" Text="Payment Type"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl144" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblPaymntType" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHeadOfAccount4" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;" Text="Claim Type/ Voucher Type"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl145" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblClmType" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHeadOfAccount" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt;" Text="Head of Account"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl26" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblHeadOfAccount2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;" Text="LAB Claim Payments"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVouNum" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Payment Voucher No"></asp:Label>
            </td>
            <td class="auto-style2" colspan="2" style="text-align: right">
                <asp:Label ID="lbl34" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblVouNum2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt; font-family: 'Trebuchet MS';"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblPolicyNo" runat="server" Font-Bold="False" 
                    Font-Names="Times New Roman" Font-Size="10" 
                    style="text-align: center; font-family: 'Trebuchet MS'; font-size: 10pt;" 
                    Text="Policy No"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl2" runat="server" Font-Bold="False" 
                    Font-Names="Times New Roman" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblPolicyNo2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt; font-family: 'Trebuchet MS';"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblClaimNo" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Claim No"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" 
                    Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblClaimNo2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblInsuredName" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Insured Name"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl3" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" 
                    Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblInsuredName2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblIEPF_User" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" style="text-align: center" 
                    Text="EPF"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl146" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblUser_epf" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblAnnPayment" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" style="text-align: center" 
                    Text="Claim Amount"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl27" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblClmAmt2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblNetAmtPay" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Net Amount Payable Rs."></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl7" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" 
                    Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblNetAmtPay2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="Smaller" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="lblNetAmtPayWords" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" style="text-align: left" 
                    Text="Net Amount Payable (In Words)" Width="270px"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl8" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" 
                    Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td class="style17" colspan="3">
                <asp:Label ID="lblNetAmtPayWords2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
            </td>
        </tr>
      
       
            <tr>
                <td>
                    <asp:Label ID="lblBankName" runat="server" Font-Bold="False" 
                        Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                        Text="Bank Name"></asp:Label>
                </td>
                <td colspan="2" style="text-align: right">
                    <asp:Label ID="lbl35" runat="server" Font-Bold="False" 
                        Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="lblBankName2" runat="server" Font-Bold="False" 
                        Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblBankBranch" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Bank Branch"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl17" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td class="style6" colspan="3">
                <asp:Label ID="lblBankBranch2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblBankAccNo" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Bank Account No"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl18" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td class="style6" colspan="3">
                <asp:Label ID="lblBankAccNo2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt;"></asp:Label>
            </td>
        </tr>
       
            <tr>
                <td class="style19">
                    <asp:Label ID="lblNameOfPayee" runat="server" Font-Bold="False" 
                        Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                        Text="Name of Payee"></asp:Label>
                </td>
                <td colspan="2" style="text-align: right">
                    <asp:Label ID="lbl19" runat="server" Font-Bold="False" 
                        Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
                </td>
                <td class="style6" colspan="3">
                    <asp:Label ID="lblNameOfPayee2" runat="server" Font-Bold="False" 
                        Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="lblNICPassport" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="NIC No / Passport No"></asp:Label>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lbl21" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td class="style6" colspan="3">
                <asp:Label ID="lblNICPassport2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                &nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblEpf" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
                <asp:Label ID="lblBlank1" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 8pt;" Text="..........................."></asp:Label>
            </td>
            <td class="style20">
                <asp:Label ID="lblBlank2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 8pt;" Text="..........................."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                &nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblBlank3" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Prepared By"></asp:Label>
            </td>
            <td class="style20">
                <asp:Label ID="lblCheckedBy" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Checked By"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="6" 
                style="font-family: 'Trebuchet MS'; font-size: smaller">
                D<span class="style55">eclaration: I certify to my personal knowledge/on 
                certificates/documents in the relevant file that the above mentioned transaction 
                was duly approved and that the payment of the amount stated in this voucher in 
                words and figures to the payee shown herein is in accordance with the contract 
                regulations and that all supplies/services has been duly performed/rendered.</span></td>
        </tr>
        <tr>
            <td class="style19" colspan="6">
                ________________________________________________________________________________</td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                <asp:Label ID="lblCertOfficer" runat="server" Font-Bold="True" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Certifying Officer"></asp:Label>
            </td>
            <td class="style6" colspan="3">
                <asp:Label ID="lblAccDept" runat="server" Font-Bold="True" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 10pt;" Text="Accounts Dept. Use Only"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                <asp:Label ID="lblCertOfficerName" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text="Name"></asp:Label>
                <asp:Label ID="lbl9" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" 
                    Font-Size="10" style="text-align: center" Text=":"></asp:Label>
                <span class="style49">..........................................</span></td>
            <td class="auto-style5">
                <asp:Label ID="lblAccAmount" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Amount"></asp:Label>
                </td>
            <td class="style6" colspan="2">
                :<asp:Label ID="lblAccAmount2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                <asp:Label ID="lblDesignation" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Designation"></asp:Label>
                <span class="style41"><span class="style49"><span class="style47">
                <asp:Label ID="lbl28" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
                </span></span></span><span class="style49">..................................</span></td>
            <td class="auto-style5">
                <asp:Label ID="lblAccCode" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Account Code"></asp:Label>
                </td>
            <td class="style6" colspan="2">
                :<asp:Label ID="lblAccCod" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10pt" style="text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                <asp:Label ID="lblSignature" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" 
                    Text="Signature"></asp:Label>
                <span class="style50"><span class="style41"><span class="style47">
                <asp:Label ID="lbl143" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
                </span></span><span class="style47">.....................................</span></span></td>
            <td class="auto-style5">
                &nbsp;&nbsp;</td>
            <td class="style6" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="style6" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" valign=" " width="1">
                ________________________________________________________________________________</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lblTel" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text="Tel"></asp:Label>
            </td>
            <td class="style37" style="text-align: right">
                <asp:Label ID="lbl32" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center" Text=":"></asp:Label>
            </td>
            <td class="style6" colspan="3">
                <asp:Label ID="lblTel2" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" style="text-align: center"></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="3">
                <strong><span class="auto-style7">Reprint</span></strong>
                <asp:Label ID="lblDate4" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 7pt;"></asp:Label>
                &nbsp;<asp:Label ID="lblTime" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 7pt;"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblMachineIP" runat="server" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Font-Size="10" 
                    style="text-align: center; font-size: 7pt;"></asp:Label>
                
            </td>
        </tr>
        
        <tr>
            <td class="style19" colspan="6">
                &nbsp;</td>
        </tr> 
        
       
        <tr class="notprint">
            <td  colspan="6" class="auto-style2" >
               
                <input id="btnPrint" class="notprint" onclick="return btnPrint_onclick()" type="button" value="Print"  />
               
                <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back" />

                <asp:Button ID="btnBack2" runat="server"  Text="Back" OnClick="btnBack2_Click" />
            </td>
            <asp:Button ID="btnHidden" runat="server" style =" display:none" onclick="btnHidden_Click" />
        </tr> 
        
       
        </table>
        </div>
        </div>
    </form>
</body>
</html>
