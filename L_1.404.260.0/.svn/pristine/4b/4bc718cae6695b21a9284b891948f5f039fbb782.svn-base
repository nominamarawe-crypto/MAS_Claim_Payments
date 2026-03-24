<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateChildProtPayments002.aspx.cs"
    Inherits="UpdateChildProtPayments002" %>

<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sri Lanka Insurance - Child Protect Payments</title>
    <script type="text/javascript" language="javascript">
        function cForm1(form) {
            win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
            form1.target = 'myWin';
            form1.action = 'UpdateChildProtPayments002.aspx';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <table style="font-weight: bold; font-size: 10pt; width: 650px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0; text-align: center">
            <tr>
                <td style="height: 18px" colspan="4">
                    <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
                        Insurance<br />
                        <span></span></span>Death Claims -&nbsp; Annual Child Protection Manual Payments
                        Updates
                        <br />
                    </span></strong>
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
                <td style="width: 136px; height: 18px; text-align: left">
                    Policy No.
                </td>
                <td style="width: 128px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="105px"></asp:Label>
                </td>
                <td style="width: 157px; height: 18px; text-align: left">
                    Claim No.
                </td>
                <td style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblclmno" runat="server" Width="105px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 18px">
                    <asp:Label ID="lblmessage" runat="server" ForeColor="LimeGreen" Width="325px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 18px; text-align: left">
                    Manual Paid Vouchers
                </td>
                <td style="width: 157px; height: 18px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px">
                    <%--<asp:Table ID="tblManualVou" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                        HorizontalAlign="Left" Width="640px">
                    </asp:Table>--%>
                    <asp:GridView ID="gvManualVouchers" ShowHeader="true" runat="server" AutoGenerateColumns="False"
                        Style="border: 1px solid #dddddd;" HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged"
                                        AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Voucher No" ItemStyle-Width="125px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblVouNo" runat="server" Text='<%# bind("VouNo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#eeeeee" />
                                <ItemStyle Width="125px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Policy No" ItemStyle-Width="125px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPolNo" runat="server" Text='<%# bind("Polno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#eeeeee" />
                                <ItemStyle Width="125px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Claim No" ItemStyle-Width="125px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblClmNo" runat="server" Text='<%# bind("ClaimNo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#eeeeee" />
                                <ItemStyle Width="125px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paid Amount" ItemStyle-Width="125px" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaidAmt" runat="server" Text='<%# bind("PaidAmount","{0:n}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#eeeeee" />
                                <ItemStyle Width="125px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
            <asp:Panel ID="pnlPaidDue" runat="server" Visible="false">
                <tr>
                    <td colspan="2" style="height: 18px; text-align: left">
                        Select Paid Due/Dues
                    </td>
                    <td style="width: 157px; height: 18px">
                    </td>
                    <td style="height: 18px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 20px">
                        <%--<asp:Table ID="tblManualVou" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                        HorizontalAlign="Left" Width="640px">
                    </asp:Table>--%>
                        <asp:GridView ID="gvPaidDues" ShowHeader="true" runat="server" AutoGenerateColumns="False"
                            Style="border: 1px solid #dddddd;" HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelectDue_CheckedChanged"
                                            AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paid Due/Dues" ItemStyle-Width="125px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaymentDue" runat="server" Text='<%# bind("PaymentDue") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#eeeeee" />
                                    <ItemStyle Width="125px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Due Amount" ItemStyle-Width="125px" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDueAmt" runat="server" Text='<%# bind("DueAmount","{0:n}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#eeeeee" />
                                    <ItemStyle Width="125px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=""  ItemStyle-Width="25px" >
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnClmTyp" runat="server" Value='<%# bind("ClaimType") %>' /> 
                                </ItemTemplate> 
                                <ItemStyle Width="25px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=""  ItemStyle-Width="25px" >
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDueAmt" runat="server" Value='<%# bind("DueAmount") %>' /> 
                                </ItemTemplate> 
                                <ItemStyle Width="25px" />
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlButton" runat="server" Visible="false">
                <tr>
                    <td colspan="4" style="height: 18px">
                    <asp:Label ID="lblMessage1" runat="server" ForeColor="red" Width="325px"></asp:Label>
                </td>
                </tr>
                <tr>
                    <td style="width: 136px; height: 18px">
                    </td>
                    <td colspan="2" style="height: 18px; text-align: right">
                        <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                            Text="Update" onclick="btnUpdate_Click" /><asp:Button ID="btnBack" 
                            runat="server" Font-Bold="True"
                              Font-Names="Trebuchet MS" Text="Back" Width="88px" 
                            onclick="btnBack_Click" />
                    </td>
                    <td style="height: 18px">
                    </td>
                </tr>
            </asp:Panel>
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
