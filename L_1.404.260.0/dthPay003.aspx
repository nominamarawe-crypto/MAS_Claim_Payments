<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthPay003.aspx.cs" Inherits="dthPay003" %>
<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .style1
        {
            width: 19px;
            height: 10px;
        }
        .style2
        {
            width: 184px;
            height: 10px;
        }
        .style3
        {
            height: 10px;
        }
        .auto-style7 {
            height: 20px;
            width: 190px;
        }
        .auto-style8 {
            height: 17px;
            width: 190px;
        }
        .auto-style9 {
            width: 178px;
            height: 10px;
        }
        .auto-style10 {
            width: 228px;
            height: 10px;
        }
        .auto-style11 {
            width: 192px;
            height: 10px;
        }
    </style>
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
                    <span style="font-family: Trebuchet MS;"><strong>STATUS REPORT</strong></span></td>
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
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Policy Status</span></td>
                <td style="width: 192px; height: 18px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
                    :
                    <asp:Literal ID="litpolstat" runat="server"></asp:Literal></td>
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
                <td style="width: 19px; height: 7px;">
                </td>
                <td colspan="4" style="text-align: center; height: 7px;">
                    <strong style="font-size: 10pt; font-family: 'Trebuchet MS'"><span style="font-size: 10pt;
                        font-family: Trebuchet MS"></span>
                        <asp:Literal ID="Literal1" runat="server" Text="Payee :" Visible="False"></asp:Literal>
                        <asp:Literal ID="litpayeewho" runat="server"></asp:Literal></strong></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 1px; background-color: #f0f0f0;">
                </td>
                <td colspan="4" style="height: 1px; width: 9px; background-color: #f0f0f0;">
                    <asp:Table ID="Table1" runat="server" HorizontalAlign="Left" style="text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" Width="653px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 8px">
                </td>
                <td colspan="4" style="height: 8px; text-align: left">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" Font-Names="Trebuchet MS" Font-Size="10pt" PageSize="20" style="font-size: 10pt; font-family: 'Trebuchet MS'" Width="686px">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="LHHIRE" HeaderText="Hierer No" SortExpression="LHHIRE">
                                <ItemStyle HorizontalAlign="Left" Width="10px" />
                                <HeaderStyle HorizontalAlign="Left" Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LHNAME" HeaderText="Name" SortExpression="LHNAME">
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LHDOB" HeaderText="Date of Birth" SortExpression="LHDOB">
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LHMST" HeaderText="Marital Status" SortExpression="LHMST">
                                <ItemStyle HorizontalAlign="Left" Width="10px" />
                                <HeaderStyle HorizontalAlign="Left" Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LHSHARE" HeaderText="Share" SortExpression="LHSHARE">
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LHAMOUNT" HeaderText="Amount" SortExpression="LHAMOUNT">
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LHAD1" HeaderText="Address" SortExpression="LHAD1">
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 7px;">
                </td>
                <td colspan="4" style="text-align: left; height: 7px;">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="border-bottom: black thin solid; height: 11px; text-align: center; background-color: #f0f0f0;">
                    <strong><span style="font-family: Trebuchet MS; text-decoration: underline;">
                    LIABILITY</span></strong></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 18px">
                </td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    <asp:Literal ID="litsumassdesc" runat="server"></asp:Literal></span></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">:
                    <asp:Literal ID="litsumassured" runat="server"></asp:Literal></span></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="height: 7px; background-color: #f0f0f0; text-align: center;" colspan="5">
                    <strong><span style="font-family: Trebuchet MS; text-decoration: underline;">RIDER COVERS</span></strong></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="width: 184px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    ADB</span></td>
                <td style="width: 178px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litadb" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Swarna Jayanthi</span></td>
                <td style="width: 192px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litsj" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 11px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 11px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    FPU</span></td>
                <td style="width: 178px; height: 11px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litfpu" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 11px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Funeral Expenses</span></td>
                <td style="width: 192px; height: 11px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litfe" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 10px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Refund of Premiums</span></td>
                <td style="width: 178px; height: 10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litrefofprms" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Other Additions</span></td>
                <td style="width: 192px; height: 10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litotheradditns" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="width: 184px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Vested Bonus
                    <br /><asp:Label runat="server" ID="lblFrom">From </asp:Label><asp:Literal ID="LiteralComm" runat="server"></asp:Literal><asp:Label runat="server" ID="lblTo"> to </asp:Label><asp:Literal ID="LiteralBonus" runat="server"></asp:Literal>
                </span>
                        </td>
                <td style="width: 178px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litvestedBonus" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Interim Bonus <br />
                </span></td>
                <td style="width: 192px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litinterimbons" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Stage Payment</span></td>
                <td style="width: 178px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litStagePayment" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    &nbsp;</span></td>
                <td style="width: 192px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    <%--:--%>
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Gross Claim</span></td>
                <td style="width: 178px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litgrossclaim" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Deposit Refunds</span></td>
                <td style="width: 192px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litdeprefunds" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="border-bottom: black thin solid; height: 12px; background-color: #f0f0f0;">
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
                <td style="width: 184px; height: 7px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Default Premiums</span></td>
                <td style="width: 178px; height: 7px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litdefprems" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 7px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Premium Interest</span></td>
                <td style="width: 192px; height: 7px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litpremint" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 16px">
                </td>
                <td style="width: 184px; height: 16px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Prem. Completed Year</span></td>
                <td style="width: 178px; height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litpremcmplyr" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 16px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Prems. to Complete Year</span></td>
                <td style="width: 192px; height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litPCY" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 10px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Amt. to Complete Year</span></td>
                <td style="width: 178px; height: 10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litACY" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Other Deductions</span></td>
                <td style="width: 192px; height: 10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litotherdeduct" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 10px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Stage Payment Deduction</span></td>
                <td style="width: 178px; height: 10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litStagePayDeduction" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left; background-color: #f0f0f0;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    </span></td>
                <td style="width: 192px; height: 10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';">
                    
                    <asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="width: 184px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Loan Capital</span></td>
                <td style="width: 178px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litloancap" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Loan Interest</span></td>
                <td style="width: 192px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litloanInt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Surrendered Bonus</span></td>
                <td style="width: 178px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litsurrbons" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Bonus Surr. Year</span></td>
                <td style="width: 192px; height: 10px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litbonsurryear" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="font-size: 10pt; width: 184px; font-family: 'Trebuchet MS'; height: 10px;
                    text-align: left">
                    Age Difference Amount</td>
                <td style="font-size: 10pt; width: 178px; font-family: 'Trebuchet MS'; height: 10px;
                    text-align: left">
                    :
                    <asp:Literal ID="litagediff" runat="server"></asp:Literal></td>
                <td style="font-size: 10pt; width: 228px; font-family: 'Trebuchet MS'; height: 10px;
                    text-align: left">
                    Age Difference Interest</td>
                <td style="font-size: 10pt; width: 192px; font-family: 'Trebuchet MS'; height: 10px;
                    text-align: left">
                    :
                    <asp:Literal ID="litagediffIntst" runat="server"></asp:Literal></td>
            </tr>
            
            <tr>
                <td style="width: 19px; height: 10px">
                </td>
                <td style="width: 184px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Net Claim</span></td>
                <td style="width: 178px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litnetclm" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Amt. Outstanding</span></td>
                <td style="width: 192px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="litamtoutstan" runat="server"></asp:Literal></td>
            </tr>
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
                    Total</span></strong></td>
                <td style="width: 178px; height: 10px; text-align: left; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <strong>:</strong>
                    <asp:Literal ID="littot" runat="server"></asp:Literal></td>
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
                <td style="vertical-align: top; text-align: left;" class="style1">
                </td>
                <td style="text-align: left; vertical-align: top;" class="style2">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Minutes</span></td>
                <td style="text-align: left; vertical-align: top; font-size: 10pt; font-family: 'Trebuchet MS';" 
                    colspan="3" class="style3">
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
                <td >
                </td>
                <td style="text-align: left" >
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Prepared By</span></td>
                <td style="text-align: left; font-size: 10pt; font-family: 'Trebuchet MS'; line-height:0px" class="auto-style7">
                    
                    <asp:Panel runat="server" ID="lblSignature1" Visible="false">
                            <asp:Image ID="SignatureImage1" ImageUrl="~/Image/UserSignature.png" runat="server" style="width: 140px; height: 40px;" alt="signature" />
                    </asp:Panel>

                </td>
                <td style="text-align: left" class="auto-style10">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">Date</span></td>
                <td style="text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" class="auto-style11">
                    :
                    <asp:Literal ID="litdate" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td ></td>
                <td ></td>
                <td style=" padding-left:10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';" class="auto-style7" >
                    
                    <asp:Label  ID="lblName1" runat="server" Text="" Visible="false"> </asp:Label>
                    <br />
                    <asp:Label ID="lblDesig1" runat="server" Text="" Visible="false"> </asp:Label>
                    <br />
                    <asp:Label ID="lbldip1" runat="server" Text="" Visible="false"> </asp:Label>
                    <br />
                    <asp:Label ID="lblComp1" runat="server" Text="" Visible="false"> </asp:Label>

                </td>
                <td >
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 20px; background-color: #f0f0f0; text-align: left;">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    EPF</span></td>
                <td style="width: 178px; height: 20px; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
                    :
                    <asp:Literal ID="litepf" runat="server"></asp:Literal></td>
                <td style="width: 228px; height: 20px; background-color: #f0f0f0;">
                </td>
                <td style="width: 192px; height: 20px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px">
                </td>
                <td style="width: 184px; height: 20px; text-align: left">
                    &nbsp;&nbsp;
                </td>
                <td style="width: 178px; height: 20px; text-align: left">
                    </td>
                <td style="width: 228px; height: 20px; text-align: left">
                </td>
                <td style="width: 192px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="width: 184px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="background-color: #f0f0f0; text-align:left; padding-left:5px; line-height:0px" class="auto-style8">
                <%--<asp:Label ID="lblSignature" runat="server" Text="" Visible="false"> </asp:Label>--%>
                    <asp:Panel runat="server" ID="lblSignature" Visible="false">
                            <asp:Image ID="SignatureImage" ImageUrl="~/Image/UserSignature.png" runat="server" style="width: 140px; height: 40px;" alt="signature" />
                        </asp:Panel>
                </td>
                <td style="width: 228px; height: 17px; background-color: #f0f0f0;">
                </td>
                <td style="width: 192px; height: 17px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px">
                </td>
                <td style="width: 184px; height: 20px; text-align: left">
                    <span style="font-size: 10pt; font-family: Trebuchet MS">
                    Authorized By</span></td>
                <td style="width: 178px; height: 0px; text-align: left; line-height:0px;">
                    : -------------------</td>
                <td style="width: 228px; height: 20px; text-align: left">
                </td>
                <td style="width: 192px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 20px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="width: 184px; height: 20px; text-align: left; background-color: #f0f0f0;">
                </td>
                <td style=" padding-left:10px; text-align: left; background-color: #f0f0f0; font-size: 10pt; font-family: 'Trebuchet MS';" class="auto-style7" colspan="2">
                <asp:Label  ID="lblName" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblDesig" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lbldip" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblComp" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblepf" runat="server" Text="" Visible="false"> </asp:Label>
                    

                </td>
<%--                <td style="width: 228px; height: 20px; text-align: left; background-color: #f0f0f0;">--%>
                </td>
                <td style="width: 192px; height: 20px; text-align: left; background-color: #f0f0f0;">
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
        <asp:HiddenField ID="hdfmof" runat="server" />
        <asp:HiddenField ID="hdfpolno" runat="server" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select LHHIRE, LHNAME , LHAD1 , LHDOB, LHMST , LHSHARE , LHAMOUNT  from LPHS.LEGAL_HIRES where LHPOLNO = :polno and LHMOF =:MOF ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdfpolno" Name="polno" PropertyName="Value" />
                            <asp:ControlParameter ControlID="hdfmof" Name="MOF" PropertyName="Value" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    </form>
</body>
</html>
