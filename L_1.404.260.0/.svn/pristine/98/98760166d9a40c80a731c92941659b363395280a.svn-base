<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DthRefClaimEntry.aspx.cs" Inherits="DthRefClaimEntry" %>
<%@ PreviousPageType VirtualPath ="~/DthOldEntry.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="JavaScript/ValidateNumeric.js" language="javascript" type="text/javascript"></script> 
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
history.back();
}
function back() {
debugger;
history.back();
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
        <table style="font-size: 10pt; width: 778px; font-family: 'Trebuchet MS'; height: 304px">
            <tr>
                <td colspan="4" style="text-align: center">
                    <strong><span style="font-size: 14pt; font-family: Trebuchet MS">Outstanding Death Claim Entry</span></strong></td>
                <td colspan="1" style="width: 181px">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f0f0f0; text-align: left">
                    Policy Number</td>
                <td style="width: 464px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
                <td style="width: 286px; height: 10px; background-color: #f0f0f0; text-align: left">
                    Claim Number</td>
                <td style="width: 243px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:Literal ID="litclm" runat="server"></asp:Literal></td>
                <td style="width: 181px; height: 10px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; text-align: left">
                    Proposal Number</td>
                <td style="width: 464px; height: 10px; text-align: left">
                    <asp:Literal ID="litpropno" runat="server"></asp:Literal></td>
                <td style="width: 286px; height: 10px; text-align: left">
                </td>
                <td style="width: 243px; height: 10px">
                </td>
                <td style="width: 181px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f0f0f0; text-align: left">
                    Name</td>
                <td colspan="3" style="height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td colspan="1" style="height: 10px; background-color: #f0f0f0; text-align: left; width: 181px;">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; text-align: left">
                    <span>
                    Sum Assured</span></td>
                <td style="width: 464px; height: 10px; text-align: left">
                    <asp:TextBox ID="txtsumass" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk1" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 10px; text-align: left">
                    </td>
                <td style="width: 243px; height: 10px; text-align: left">
                    </td>
                <td style="width: 181px; height: 10px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <span>ADB</span></td>
                <td style="width: 464px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <asp:TextBox ID="txtadb" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk2" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    Age Admitted</td>
                <td style="width: 243px; height: 10px; background-color: #f0f0f0; text-align: left;">
                    <asp:DropDownList ID="ddl_ageadmityn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ageadmityn_SelectedIndexChanged"
                        Width="93px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 181px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="chk17" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; text-align: left;">
                    <span>
                    Vested Bonus</span></td>
                <td style="width: 464px; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtvestedbns" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk3" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 10px; text-align: left;">
                    <span>
                    Interim Bonus</span></td>
                <td style="width: 243px; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtinterim" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; text-align: left">
                    <asp:CheckBox ID="chk18" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <span>
                    Surrender Bonus</span></td>
                <td style="width: 464px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtsurrbns" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk4" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <span>
                    Swarna Jayanthi</span></td>
                <td style="width: 243px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtswjynthi" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="chk19" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; text-align: left;">
                    <span>FE</span></td>
                <td style="width: 464px; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtfe" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk5" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 10px; text-align: left;">
                    <span>FPU</span></td>
                <td style="width: 243px; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtfpu" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; text-align: left">
                    <asp:CheckBox ID="chk20" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <span>
                    Deposit</span></td>
                <td style="width: 464px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtdep" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');" ReadOnly="True">0</asp:TextBox><asp:CheckBox ID="chk6" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <span>
                    Other Additions</span></td>
                <td style="width: 243px; background-color: #f0f0f0; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtadd" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="chk21" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px; background-color: white; text-align: left;">
                    <span>
                    Gross Claim</span></td>
                <td style="width: 464px; height: 11px; background-color: white; text-align: left;">
                    <asp:TextBox ID="txtgross" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk7" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: white; text-align: left;">
                    </td>
                <td style="width: 243px; height: 11px; background-color: white; text-align: left;">
                    </td>
                <td style="width: 181px; height: 11px; background-color: white; text-align: left">
                    </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f1f1f1; text-align: left">
                    <span>
                    Amount to Complete Policy Year</span></td>
                <td style="width: 464px; height: 10px; background-color: #f1f1f1; text-align: left">
                    <asp:TextBox ID="txtamtcompolyr" runat="server" Height="15px" onblur="checkNumeric(this,'.');"
                        Width="116px">0</asp:TextBox><asp:CheckBox ID="chk8" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 243px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 181px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; background-color: #f1f1f1; height: 10px; text-align: left;">
                    <span>
                    Other Deductions</span></td>
                <td style="width: 464px; background-color: #f1f1f1; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtdedu" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk9" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; background-color: #f1f1f1; height: 10px; text-align: left;">
                    <span>
                    Defualt Premiums</span></td>
                <td style="width: 243px; background-color: #f1f1f1; height: 10px; text-align: left; font-weight: bold; color: #000000;">
                    <asp:TextBox ID="txtdefprm" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; background-color: #f1f1f1; text-align: left; color: #000000;">
                    <asp:CheckBox ID="chk22" runat="server" Visible="False" style="font-weight: bold;" Text="OK" /></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 793px; height: 11px; background-color: white; text-align: left">
                    Loan Captal</td>
                <td style="width: 464px; height: 11px; background-color: white; text-align: left">
                    <asp:TextBox ID="txtloan" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk10" runat="server" Visible="False" style="font-weight: bold;" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: white; text-align: left">
                    <span>
                    Interest for Loan</span></td>
                <td style="width: 243px; height: 11px; background-color: white; text-align: left">
                    <asp:TextBox ID="txtint4ln" runat="server" Height="15px" Width="89px" onblur="checkNumeric(this,'.');">0</asp:TextBox>
                    <asp:Literal ID="litintrate" runat="server"></asp:Literal>%</td>
                <td style="width: 181px; height: 11px; background-color: white; text-align: left">
                    <asp:CheckBox ID="chk24" runat="server" Visible="False" Font-Bold="True" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <strong>
                    Net Claim</strong></td>
                <td style="width: 464px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="txtntclm" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk11" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /><br />
                    <asp:CheckBox ID="CHKeXGRA" runat="server" Font-Bold="True" Text="Exgracia Included" Visible="False" /></td>
                <td style="width: 286px; height: 10px; background-color: #f0f0f0; text-align: left">
                    ADB Pay Amount</td>
                <td style="width: 243px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="abdpay" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="chk25" runat="server" Visible="False" Font-Bold="True" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: white; text-align: left">
                    SwarnaJayanthi Pay Amount</td>
                <td style="width: 464px; height: 10px; background-color: white; text-align: left">
                    <asp:TextBox ID="sjpay" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk12" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: white; text-align: left">
                    FPU Pay Amount</td>
                <td style="width: 243px; height: 10px; background-color: white; text-align: left">
                    <asp:TextBox ID="fpupay" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 10px; background-color: white; text-align: left">
                    <asp:CheckBox ID="chk26" runat="server" Visible="False" Font-Bold="True" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px; background-color: #f0f0f0; text-align: left">
                    FE Pay Amount</td>
                <td style="width: 464px; height: 11px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="fepay" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk13" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: #f0f0f0; text-align: left">
                    Paid Up Value</td>
                <td style="width: 243px; height: 11px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="paidupval" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox>&nbsp;</td>
                <td style="width: 181px; height: 11px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="chk27" runat="server" Visible="False" Font-Bold="True" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: white; text-align: left">
                    Premium Refund</td>
                <td style="width: 464px; height: 10px; background-color: white; text-align: left">
                    <asp:TextBox ID="txtrefprms" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk14" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: white; text-align: left">
                    Outstanding Amount</td>
                <td style="width: 243px; height: 10px; background-color: white; text-align: left">
                    <asp:TextBox ID="txtoutamt" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox>&nbsp;
                </td>
                <td style="width: 181px; height: 10px; background-color: white; text-align: left">
                    <asp:CheckBox ID="chk28" runat="server" Visible="False" Font-Bold="True" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px; background-color: #f0f0f0; text-align: left">
                    Total Paid Amount</td>
                <td style="width: 464px; height: 11px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="totalpdamt" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk15" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: #f0f0f0; text-align: left">
                    Age Amount</td>
                <td style="width: 243px; height: 11px; background-color: #f0f0f0; text-align: left">
                    <asp:TextBox ID="txtageamt" runat="server" Height="15px" Width="121px" onblur="checkNumeric(this,'.');">0</asp:TextBox></td>
                <td style="width: 181px; height: 11px; background-color: #f0f0f0; text-align: left">
                    <asp:CheckBox ID="chk29" runat="server" Visible="False" Font-Bold="True" Text="OK" /></td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px; background-color: white; text-align: left">
                    Exgracia Amount</td>
                <td style="width: 464px; height: 11px; background-color: white; text-align: left">
                    <asp:TextBox ID="txtexgamt" runat="server" Height="15px" Width="117px" onblur="checkNumeric(this,'.');">0</asp:TextBox><asp:CheckBox ID="chk16" runat="server" Visible="False" style="font-weight: bold; color: #000000" Text="OK" /></td>
                <td style="width: 286px; height: 11px; background-color: white; text-align: left">
                    </td>
                <td style="width: 243px; height: 11px; background-color: white; text-align: left">
                    </td>
                <td style="width: 181px; height: 11px; background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px; background-color: white; text-align: left">
                    </td>
                <td style="width: 464px; height: 11px; background-color: white; text-align: left">
                    </td>
                <td style="width: 286px; height: 11px; background-color: white; text-align: left">
                </td>
                <td style="width: 243px; height: 11px; background-color: white; text-align: left">
                </td>
                <td style="width: 181px; height: 11px; background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 11px; background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f1f1f1; text-align: left">
                    Cause of Death</td>
                <td style="height: 10px; background-color: #f1f1f1; text-align: left" colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                        DataTextField="DCAUSE" DataValueField="DSERIAL" Font-Names="Trebuchet MS" Font-Size="10pt"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="205px">
                    </asp:DropDownList></td>
                <td style="width: 243px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 181px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: white; text-align: left">
                </td>
                <td style="height: 10px; background-color: white; text-align: left" colspan="2">
                    <asp:TextBox ID="txtcsofdth" runat="server" Width="269px" Visible="False"></asp:TextBox></td>
                <td style="width: 243px; height: 10px; background-color: white; text-align: left">
                </td>
                <td style="width: 181px; height: 10px; background-color: white; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 464px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 286px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 243px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
                <td style="width: 181px; height: 10px; background-color: #f1f1f1; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px;">
                </td>
                <td colspan="4" style="height: 11px; text-align: left">
                    <asp:Button ID="btnsub" runat="server" Font-Bold="True" Height="24px" OnClick="btnsub_Click"
                        Text="Submit" Width="99px" />
                    <asp:Button ID="btnloanreciept" runat="server" Font-Bold="True"
                            Height="25px" Text="Loan Receipt" Width="99px" OnClick="btnloanreciept_Click" Visible="False" />&nbsp;
                    <input id="Button1" type="button" runat="server" value="Back" onclick="return Button1_onclick()" style="font-weight: bold; width: 110px; height: 25px" />
                </td>
            </tr>
            <tr>
                <td style="width: 793px; height: 11px">
                </td>
                <td colspan="4" style="height: 11px; text-align: left">
                    <asp:Button ID="btn_next" runat="server" Font-Bold="True" Text="Distribution of Claim Payment" Width="211px" Height="25px" OnClick="btn_next_Click" Visible="False" />
                    <asp:Button ID="btn_memo" runat="server" Font-Bold="True" Text="Payment Memo & Distribution" Width="211px" Height="25px" OnClick="btn_memo_Click" Visible="False" /></td>
            </tr>
        </table>
                    <asp:Label ID="lblerr" runat="server" Font-Bold="True" ForeColor="Red" Width="616px" style="text-align: left"></asp:Label><br />
        <asp:Label ID="lblerr2" runat="server" Font-Bold="True" ForeColor="Red" Style="text-align: left"
            Width="616px"></asp:Label><br />
                    <asp:Label ID="lblsuc" runat="server" Font-Bold="True" ForeColor="Green" Width="616px" style="text-align: left"></asp:Label><br />
        <br />
        <asp:HiddenField ID="hdfmos" runat="server" />
        <asp:HiddenField ID="hdftrm" runat="server" />
        <asp:HiddenField ID="hdfbr" runat="server" />
        <asp:HiddenField ID="hdfmode" runat="server" />
        <asp:HiddenField ID="hdftbl" runat="server" />
        <asp:HiddenField ID="hdfepf" runat="server" />
        <asp:HiddenField ID="hdftracd" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand='SELECT "DCAUSE", "DSERIAL" FROM "LPHS"."DCAUSEOFDTH"'>
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdfcomdt" runat="server" />
        <asp:HiddenField ID="hdfintbonst" runat="server" />
        <asp:HiddenField ID="hdfauth" runat="server" />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <br />
                    <br />
    
    </div>
    </form>
</body>
</html>
