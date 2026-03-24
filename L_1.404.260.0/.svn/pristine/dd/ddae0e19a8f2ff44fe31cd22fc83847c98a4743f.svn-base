<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBApproveMemo003.aspx.cs" Inherits="ADBApproveMemo003" %>
<%@ PreviousPageType VirtualPath="~/ADBApproveMemo002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<body onload="window.print()" style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-weight: normal; font-size: 12pt; width: 701px">
            <tr>
                <td style="width: 19px; height: 20px; background-color: whitesmoke;">
                </td>
                <td colspan="4" style="height: 20px; width: 9px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 24px">
                    <span style="font-family: Trebuchet MS;"><strong>ADB Payment Memo</strong></span></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px; background-color: #f0f0f0;">
                </td>
                <td colspan="4" style="height: 20px; width: 9px; background-color: #f0f0f0;">
                    </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 18px">
                </td>
                <td style="width: 184px; height: 18px; text-align: left">
                    <strong><span style="font-size: 10pt; font-family: Trebuchet MS">Policy Number</span></strong></td>
                <td style="width: 178px; height: 18px; text-align: left; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <strong>:</strong>
                    <asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 18px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Claim Number</span></td>
                <td style="width: 192px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litclmno" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 18px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 18px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Table/Term</span></td>
                <td style="width: 178px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
                    :
                    <asp:Label ID="lbltab" runat="server" Width="54px"></asp:Label><asp:Label ID="lblterm" runat="server" Width="40px"></asp:Label></td>
                <td style="width: 228px; height: 18px; text-align: left; background-color: #f0f0f0;">
                     </td>
                <td style="width: 192px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
                     </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 18px">
                </td>
                <td style="width: 184px; height: 18px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Date of Commencement</span></td>
                <td style="width: 178px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litDCO" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 18px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Date of Death</span></td>
                <td style="width: 192px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litdtofdth" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; text-align: left; height: 20px; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS"></span></td>
                <td colspan="3" style="text-align: left; height: 20px; font-size: 10pt; width: 151px; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 10px">
                </td>
            </tr>
            <asp:Panel ID="pnlRequirements" runat="server" Visible="false">
            <tr>
                <td colspan="5" style="border-bottom: black thin solid; height: 11px; text-align: left; background-color: #f0f0f0;">
                    <strong><span style="font-family: Trebuchet MS; text-decoration: underline;">
                    REQUIREMENTS</span></strong></td>
            </tr>
            
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="height: 10px; text-align: left;font-size: 10pt; font-family: 'Trebuchet MS';" colspan="4">
                    <asp:Label ID="lblmissingReq" runat="server" ForeColor="#FF0033" Width="447px" Font-Bold="False"></asp:Label> </td>
            </tr>
            </asp:Panel>
             
            <tr>
                <td colspan="5" style="border-bottom: black thin solid; height: 11px; text-align: left; background-color: #f0f0f0;">
                    <strong><span style="font-family: Trebuchet MS; text-decoration: underline;">
                    LIABILITY</span></strong></td>
            </tr>
              
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="width: 184px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Accidental Death Benefit</span></td>
                <td style="width: 178px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litadb" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left">
                     </td>
                <td style="width: 192px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS; font-weight:bold;">
                    Gross Claim</span></td>
                <td style="width: 178px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-weight:bold; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litgrossclm" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; background-color: #f0f0f0; text-align: left;">
                     </td>
                <td style="width: 192px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 10px">
                </td>
            </tr>
            <asp:Panel ID="pnlDeductions1" runat="server" Visible="false">
            <tr>
                <td colspan="5" style="border-bottom: black thin solid; height: 12px; text-align: left; background-color: #f0f0f0;">
                    <strong style="border-bottom-width: thin; border-bottom-color: black"><span style="font-family: Trebuchet MS; text-decoration: underline;">
                    DEDUCTIONS</span></strong></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 7px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 7px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litDeducDes1" runat="server"></asp:Literal></td>
                <td style="width: 178px; height: 7px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litDedcAmt1" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 7px; text-align: left; background-color: #f0f0f0;">
                     </td>
                <td style="width: 192px; height: 7px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                     </td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="pnlDeductions2" runat="server" Visible="false">
            <tr>
                <td style="width: 19px; height: 16px">
                </td>
                <td style="width: 184px; height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litDeducDes2" runat="server"></asp:Literal></td>
                <td style="width: 178px; height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litDedcAmt2" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 16px; text-align: left">
                     </td>
                <td style="width: 192px; height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                     </td>
            </tr>
             
             </asp:Panel>
             
             
            
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 178px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 228px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 192px; height: 10px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="width: 184px; height: 10px; text-align: left">
                    <strong><span style="font-size: 10pt; font-family: Trebuchet MS">
                    Net Amount Payable</span></strong></td>
                <td style="width: 178px; height: 10px; text-align: left; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <strong>:</strong>
                    <asp:Literal ID="litNetAmt" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left">
                </td>
                <td style="width: 192px; height: 10px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 10px; text-align: left; background-color: #f0f0f0;">
                </td>
                <td style="width: 178px; height: 10px; text-align: left; background-color: #f0f0f0;">
                </td>
                <td style="width: 228px; height: 10px; text-align: left; background-color: #f0f0f0;">
                </td>
                <td style="width: 192px; height: 10px; text-align: left; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; vertical-align: top; text-align: left;">
                </td>
                <td style="width: 184px; height: 10px; text-align: left; vertical-align: top;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Minutes</span></td>
                <td style="height: 10px; text-align: left; vertical-align: top; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="3">
                    :
                    <asp:Literal ID="litminutes" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 9px; background-color: #f0f0f0;">
                </td>
                <td style="width: 178px; height: 9px; background-color: #f0f0f0;">
                </td>
                <td style="width: 228px; height: 9px; background-color: #f0f0f0;">
                </td>
                <td style="width: 192px; height: 9px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="height: 10px; text-align: left" colspan="4">
                <table style="font-weight: normal; font-size: 12pt; width:660px">
                    <tr>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">Prepared By : <asp:Literal ID="litname" runat="server" Visible="true"></asp:Literal></span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">Checked By :</span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">Approved By :</span></td>
                    </tr>
                    <tr>
                        <td style="width:220px">
                        <asp:Panel runat="server" ID="lblSignature" Visible="false">
                        <asp:Image ID="SignatureImage" ImageUrl="~/Image/UserSignature.png" runat="server" style="width: 140px; height: 40px;" alt="signature" />
                        </asp:Panel>
                        <asp:Label  ID="lblName" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblDesig" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lbldip" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblComp" runat="server" Text="" Visible="false"> </asp:Label>
                             </td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS"></span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS"></span></td>
                    </tr>
                    <tr>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">EPF : <asp:Literal ID="litepf" runat="server"></asp:Literal></span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">EPF :</span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">EPF :</span></td>
                    </tr>
                    <tr>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">Date : <asp:Literal ID="litdate" runat="server"></asp:Literal></span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">Date :</span></td>
                        <td style="width:220px"><span style="font-size: 10pt; font-family: Trebuchet MS">Date :</span></td>
                    </tr>
                </table>
                     </td>
            </tr>
            
            
            <tr>
                <td style="width: 19px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="width: 178px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="width: 228px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="width: 192px; height: 17px; background-color: #f0f0f0;">
                </td>
            </tr>
             
            
            <tr>
                <td style="width: 19px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0; text-align: center; font-size: 8pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="LtUserDetail" runat="server"></asp:Literal></td>
            </tr>
        </table>
    
    </div>
        
    </form>
</body>
</html>
