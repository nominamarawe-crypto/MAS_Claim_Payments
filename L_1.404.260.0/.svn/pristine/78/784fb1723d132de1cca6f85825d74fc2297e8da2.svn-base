<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthPay002.aspx.cs" Inherits="dthPay002" %>
<%@ PreviousPageType VirtualPath="~/dthPay020.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
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
                    </span><span style="font-size: 12pt">Death Claim Payments</span></strong></td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0; text-align: center" colspan="4">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="#00CC33"
                        Width="309px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <span style="text-decoration: underline"><strong>STATUS REPORT</strong></span></td>
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
                    Policy Status</td>
                <td style="width: 132px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolstat" runat="server"  Width="110px"></asp:Label></td>
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
                    <asp:Label ID="lblSpace" runat="server" Visible="False" Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="lblLifecov" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Visible="False">Life Cover</asp:Label></td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="lblLifecovyn" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 17px; text-align: left">
                    <asp:Label ID="lblSp" runat="server" Visible="False" Width="146px">Single Premium</asp:Label></td>
                <td style="width: 166px; height: 17px; text-align: left">
                    <asp:Label ID="lblSpval" runat="server" Visible="False" Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 17px; text-align: left">
                    <asp:Label ID="lblIntrate" runat="server" Visible="False" Width="146px">Interest</asp:Label></td>
                <td style="width: 132px; height: 17px; text-align: left">
                    <asp:Label ID="lblIntrateval" runat="server" Visible="False" Width="146px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom: black thin solid; height: 16px; background-color: #f0f0f0;
                    text-align: center">
                    <asp:Label ID="lblmissingReq" runat="server" ForeColor="#FF0033" Width="447px" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="4">
                    <strong><span style="text-decoration: underline">
                    </span></strong></td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: center" colspan="4">
                    <asp:Label ID="lblpydis" runat="server" Font-Bold="True" Text="PAYEE" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 16px; text-align: justify" colspan="4">
                    <asp:Label ID="lblpayee" runat="server" Width="449px"></asp:Label><br />
                    <asp:Table ID="Table1" runat="server" HorizontalAlign="Justify" Width="670px" Font-Names="Trebuchet MS">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="background-color: #f0f0f0; text-align: left; height: 16px;">
                    <asp:Label ID="lbl_nominees" runat="server" ForeColor="Red" Width="675px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 16px; background-color: white; text-align: center">
                    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" HorizontalAlign="Left"
                        Width="666px">
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
                    &nbsp;&nbsp;
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select LHHIRE, LHNAME , LHAD1 , LHDOB, LHMST , LHSHARE , LHAMOUNT  from LPHS.LEGAL_HIRES where LHPOLNO = :polno and LHMOF =:MOF ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblpolno" Name="polno" PropertyName="Text" />
                            <asp:ControlParameter ControlID="hdfmof" Name="MOF" PropertyName="Value" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 16px; background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="lbl_legalhrs" runat="server" Width="675px" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom: black thin solid; height: 16px; text-align: center">
                    <strong><span style="text-decoration: underline">
                    LIABILITY</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 17px;
                    background-color: #f0f0f0; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="2">
                    <asp:Label ID="lblsumassDesc" runat="server"></asp:Label></td>
                <td style="text-align: left" colspan="2">
                    :
                    <asp:Label ID="lblsumassured" runat="server"  Width="146px"></asp:Label></td>
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
                <td colspan="4" style="height: 20px; text-align: center">
                    <span style="text-decoration: underline"><strong>RIDER COVER</strong></span></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                    Vested Bonus</td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; text-align: left">
                    ADB</td>
                <td style="width: 166px; height: 16px; text-align: left">
                    :
                    <asp:Label ID="lbladb" runat="server" Width="104px"></asp:Label></td>
                <td style="width: 168px; height: 16px; text-align: left">
                    Swarna Jayanthi</td>
                <td style="width: 132px; height: 16px; text-align: left">
                    :
                    <asp:Label ID="lblsj" runat="server" Width="110px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: left" colspan="2">
                    <asp:Label ID="lblADBliability" runat="server" ForeColor="#3300FF" Text="ADB Liable But Pending"
                        Width="155px"></asp:Label>
                    <asp:Label ID="lblADBonexgr" runat="server" ForeColor="#3300FF" Text="ADB Liable But Pending"
                        Width="155px"></asp:Label></td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; text-align: left">
                    FPU</td>
                <td style="width: 166px; height: 16px; text-align: left">
                    :
                    <asp:Label ID="lblfpu" runat="server" Width="104px"></asp:Label></td>
                <td style="width: 168px; height: 16px; text-align: left">
                    Funeral Expenses</td>
                <td style="width: 132px; height: 16px; text-align: left">
                    :
                    <asp:Label ID="lblfe" runat="server" Width="110px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: left" colspan="3">
                    <asp:Label ID="lblFEliability" runat="server" ForeColor="#3300FF" Text="FE Liable But Already Paid"
                        Width="175px"></asp:Label></td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                    Refund of Premiums</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblrefundofPrems" runat="server"  Width="146px"></asp:Label></td>
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
                    <asp:Label ID="Label1" runat="server" Width="146px">Vested Bonus</asp:Label>
                    <br /><asp:Label ID="lblFrom" runat="server" Width="146px">from</asp:Label><asp:Literal ID="LiteralComm" runat="server"></asp:Literal><asp:Label ID="lblTo" runat="server" Width="146px">to</asp:Label><asp:Literal ID="LiteralBonus" runat="server"></asp:Literal>
                </td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblvestedBonus" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Interim Bonus <br /><!--from <asp:Literal ID="LiteralBonus2" runat="server"></asp:Literal> to <asp:Literal ID="LiteralDeath" runat="server"></asp:Literal>--></td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblinterimbons" runat="server"  Width="110px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: left" colspan="2">
                    <asp:Label ID="lblBonuspay" runat="server" ForeColor="#3300FF" Text="Bonus will be paid at maturity"
                        Visible="False" Width="199px"></asp:Label></td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                    Other Additions</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblotheradditns" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Deposit Refunds</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldeprefunds" runat="server"  Width="110px"></asp:Label></td>
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
                     Stage Payment</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblStgPmnt" runat="server" Width="146px">0.00</asp:Label></td>
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
           
            <tr>
                <td colspan="4" style="height: 20px; width: 22px; border-bottom: black thin solid; text-align: center;">
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
                    Default Premiums</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbldefprems" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Premium Interest</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpremint" runat="server"  Width="110px"></asp:Label></td>
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
                    Premium Completed Year</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblpremcompldyr" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Prem. to Comp. the Year</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblPCY" runat="server" Width="110px"></asp:Label></td>
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
                    Amt. to Complete the Year</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblACY" runat="server" Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Other Deductions</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblotherdeduct" runat="server"  Width="110px"></asp:Label></td>
            </tr>
             <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                    Stage Payment Deduction</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblStagePayDeduction" runat="server" Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    </td>
                <td style="width: 132px; height: 20px; text-align: left">
                    
                    <asp:Label ID="Label4" runat="server"  Width="110px"></asp:Label></td>
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
                <td style="height: 16px; text-align: left">
                    Dues to be Completed</td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <asp:Label ID="lbDuestoPay" runat="server" Width="511px"></asp:Label></td>
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
                    Loan Capital</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblloancap" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Loan Interest</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblloanint" runat="server"  Width="110px"></asp:Label></td>
            </tr>
            <tr>
                 <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                 <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px;  text-align: left">
                    Back Calculation Capital</td>
                <td style="width: 166px; height: 16px; text-align: left">
                    :
                    <asp:Label ID="lblBackloancap" runat="server"  Width="146px"></asp:Label>
                </td>
                <td style="width: 168px; height: 16px;  text-align: left">
                    Back Calculation Interrest</td>
                <td style="width: 132px; height: 16px;  text-align: left">
                &nbsp;:
                    <asp:Label ID="lblBackloanint" runat="server"  Width="110px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 189px; height: 16px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
                <td style="width: 166px; height: 16px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
                <td style="width: 132px; height: 16px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 189px; height: 20px; text-align: left">
                    Surrendered Bonus</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblsurrenderedbonus" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Bonus Surrendered Year</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblbonsurryear" runat="server"  Width="110px"></asp:Label></td>
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
                <td style="width: 189px; height: 16px; text-align: left">
                    Age Difference Amount</td>
                <td style="width: 184px; height: 16px; text-align: left">
                    :
                    <asp:Literal ID="litagediff" runat="server"></asp:Literal></td>
                <td style="width: 168px; height: 16px; text-align: left">
                    Age Difference Interest</td>
                <td style="width: 184px; height: 16px; text-align: left">
                    :
                    <asp:Literal ID="litagediffIntst" runat="server"></asp:Literal></td>
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
                    Amount Outstanding</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblamtoutst" runat="server"  Width="146px"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align: left">
                    Net Claim</td>
                <td style="width: 132px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblnetclaim" runat="server"  Width="110px"></asp:Label></td>
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
                    Total</td>
                <td style="width: 166px; height: 20px; text-align: left">
                    :
                    <asp:Label ID="lbltot" runat="server"  Width="146px"></asp:Label></td>
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
                        OnClick="btnaccept_Click" OnClientClick="cForm6(this.form1)" Text="Accept Memo" Width="141px" />
                    <asp:Button ID="btnprint" runat="server" Text=" Print " OnClientClick="cForm1(this.form1)" Font-Bold="True" Font-Names="Trebuchet MS"  OnClick="btnprint_Click"  />
                    <asp:Button ID="btnPayshare" runat="server"
                        Text="Distribution of Claim Payment" OnClientClick="cForm6(this.form1)" OnClick="btnPayshare_Click" Font-Bold="True" Font-Names="Trebuchet MS" />
                    </td>
            </tr>
            <tr>
                <td style="height: 16px; background-color: #f0f0f0; text-align: center" colspan="4">
                    &nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" PostBackUrl="~/dthVou001.aspx" OnClientClick="cForm6(this.form1)"><<--Back Voucher Creation</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 10px; text-align: left">
                </td>
                <td style="width: 166px; height: 10px; text-align: right">
                    <asp:Button ID="btnDischargeEng" runat="server" Text="Discharge English" OnClientClick="cForm4(this.form1)" Font-Bold="True" Font-Names="Trebuchet MS" PostBackUrl="~/discharge001.aspx" OnClick="btnDischargeEng_Click"/></td>
                <td colspan="2" style="height: 10px; text-align: left">
                    <asp:Button ID="btnDischargeSinh" runat="server" Text="Discharge Sinhala" OnClientClick="cForm5(this.form1)" Font-Bold="True" Font-Names="Trebuchet MS" Width="167px" /></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 10px; text-align: left">
                </td>
                <td style="width: 166px; height: 10px; text-align: right">
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" OnClientClick="cForm4(this.form1)"
                        Text="Discharge Deposit English" Width="161px" PostBackUrl="~/DischargeDeposit.aspx" /></td>
                <td style="height: 10px; text-align: left" colspan="2">
                    <asp:Button ID="Button2" runat="server" Text="Discharge Deposit Sinhala" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="10pt" OnClientClick="cForm4(this.form1)" Width="169px" PostBackUrl="~/DischargeDepositSinhala.aspx" /></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 10px; text-align: left">
                </td>
                <td style="width: 166px; height: 10px; text-align: right">
                </td>
                <td colspan="2" style="height: 10px; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px; background-color: #ffffff">
                    <asp:Label ID="lblerre" runat="server" ForeColor="Red" Width="439px"></asp:Label></td>
                <td style="width: 159px; height: 10px; background-color: #ffffff">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 11px; background-color: #f0f0f0; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; <strong>English </strong>
                </td>
                <td colspan="2" style="height: 11px; background-color: #f0f0f0; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<strong> Sinhala</strong></td>
                <td style="width: 159px; height: 11px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 132px; height: 8px; background-color: window; text-align: left" colspan="2">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/AdmitCoverLetterEng001.aspx"
                        Width="227px" >Admit Covering Letter</asp:HyperLink></td>
                <td style="width: 132px; height: 8px; background-color: window; text-align: left" colspan="2">
                    <asp:HyperLink ID="HyperLink3"
                        runat="server" Width="223px" NavigateUrl="~/AdmitCoverLetterSIn001.aspx">Admit Covering Letter</asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:HyperLink ID="HyperLink4" runat="server" Width="227px" NavigateUrl="~/IntOfDthClmAmountEng001.aspx">Intimation of Death Claim Amount</asp:HyperLink></td>
                <td colspan="2" style="height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:HyperLink ID="HyperLink5"
                        runat="server" Width="223px" NavigateUrl="~/IntOfDthClmAmountSin001.aspx">Intimation of Death Claim Amount</asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px; text-align: left">
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/DischargeCvrLetter.aspx"
                        Width="225px">Discharge Cover Letter</asp:LinkButton></td>
                <td colspan="2" style="height: 10px; text-align: left">
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/DischargeCvrLetterSin.aspx"
                        Width="223px">Discharge Cover Letter</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/RefundMiniDthChld.aspx"
                        Width="225px">Refund Minimuthu Death Of Child</asp:LinkButton></td>
                <td colspan="2" style="height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/RefundMiniDthChldSin.aspx"
                        Width="225px">Refund Minimuthu Death Of Child</asp:LinkButton></td>
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
        <br />
        <asp:HiddenField ID="hdfmof" runat="server" />
        <asp:HiddenField ID="hdfpolno" runat="server" />
        <br />
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1,resizable=1"); 
 form1.target='myWin';
 form1.action='dthPay003.aspx';
}
function cForm2(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1,resizable=1"); 
 form1.target='myWin';
 form1.action='legalHieres001.aspx';

}

function cForm3(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1,resizable=1"); 
 form1.target='myWin';
 form1.action='assignee001.aspx';

}

function cForm4(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1,resizable=1"); 
 form1.target='myWin';
 form1.action='discharge001.aspx';

}

function cForm5(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1,resizable=1"); 
 form1.target='myWin';
 form1.action='discharge002.aspx';

}
function cForm6(form)
{
 form1.target='';
 form1.action='';

}

</script>

</html>
