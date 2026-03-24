<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherCreation.aspx.cs" Inherits="MAS_Claim_Payments.VoucherCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>


    <style type="text/css">

    .style1
    {
        width: 65%;
    }
        .style23
        {
            height: 22px;
            font-size: medium;
            width: 19px;
        }
        .style3
    {
        height: 22px;
        font-size: medium;
    }
        .style27
        {
            width: 19px;
        }
        .style25
        {
            text-align: left;
            width: 19px;
        }
        .style6
        {
            text-align: left;
        }
        .style16
        {
            width: 214px;
        }
        .style10
        {
            width: 240px;
        }
        .style30
        {
            color: #0000FF;
        }
        .style5
        {
            color: #0000FF;
        }
        .style33
        {
            width: 133px;
            text-align: left;
        }
        .style26
        {
            width: 19px;
            text-align: left;
            height: 17px;
        }
        .style13
        {
            width: 133px;
            text-align: left;
            height: 17px;
        }
        .style29
        {
            height: 2px;
        }
        .auto-style1 {
        font-size: small;
    }
    .auto-style2 {
        width: 19px;
        height: 49px;
    }
    .auto-style3 {
        height: 49px;
    }
        .auto-style4 {
            text-align: left;
            width: 19px;
            height: 25px;
        }
        .auto-style5 {
            text-align: left;
            height: 25px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script  language="javascript" type="text/javascript">
    $(function () {
        $("input[id$='tbxDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
    });
    </script>

    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxDateFrom']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>

    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxDateTo']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>

    <table align="center" class="style1">
        <tr>
            <td class="style23" style="text-align: center; font-weight: 700; color: SteelBlue">&nbsp;</td>
            <td class="auto-style1" colspan="3" style="text-align: center; font-weight: 700; color: SteelBlue">VOUCHER CREATION</td>
        </tr>
        <tr>
            <td colspan="4" style="background-color: #D8E4F8">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style27">&nbsp;</td>
            <td align="center" colspan="3" style="text-align: left">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="D">Up to Claim Date</asp:ListItem>
                    <asp:ListItem Value="DR">Claim Date Range</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">&nbsp;</td>
            <td class="style16">&nbsp;</td>
            <td class="style10">&nbsp;</td>
        </tr>
        <%
        if (this.RadioButtonList1.SelectedValue.Equals("D"))
        {
         %>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">Date</td>
            <td class="style4" colspan="2">:<asp:TextBox ID="tbxDate" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                <span class="style30">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </span>&nbsp;<span class="style30">YYYY-MM-DD </span><span __designer:mapid="5e" class="style5">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="tbxDate" ErrorMessage="Invalid" ForeColor="Red" ValidationExpression="^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$"></asp:RegularExpressionValidator>
                </span></td>
        </tr>
        <%
        }
        else if (this.RadioButtonList1.SelectedValue.Equals("DR"))
        {
        
         %>
    
        <tr>
            <td class="style25"></td>
            <td class="style33">Date Range</td>
            <td class="style16">From :<asp:TextBox ID="tbxDateFrom" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                <span class="style30">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDateFrom" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </span></td>
            <td class="style10">To :<asp:TextBox ID="tbxDateTo" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                <span class="style30">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxDateTo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </span></td>
        </tr>
        <tr>
            <td class="style26">&nbsp;</td>
            <td class="style13">&nbsp;</td>
            <td class="style30" style="text-align: center">&nbsp; YYYY-MM-DD <span __designer:mapid="5e" class="style5">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="tbxDateFrom" ErrorMessage="Invalid" ForeColor="Red" ValidationExpression="^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$"></asp:RegularExpressionValidator>
                </span></td>
            <td class="style30" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; YYYY-MM-DD <span __designer:mapid="5e" class="style5">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="tbxDateTo" ErrorMessage="Invalid" ForeColor="Red" ValidationExpression="^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$"></asp:RegularExpressionValidator>
                </span></td>
        </tr>
        <%
        }
         %>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">&nbsp;</td>
            <td class="style16">&nbsp;</td>
            <td class="style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="style29" colspan="4" style="background-color: #D8E4F8">&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" style="text-align: center"></td>
            <td colspan="3" style="text-align: center" class="auto-style3">
                <asp:Button ID="btnSubmit" runat="server" class="button button1" onclick="btnSubmit_Click" Text="Submit" />
                <asp:Button ID="btnReset" runat="server" CausesValidation="False" class="button button1" onclick="btnReset_Click" Text="Reset" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5" colspan="3">
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td class="style6" colspan="4">
                <asp:GridView ID="gvClaims" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="No claims to create vouchers." OnSelectedIndexChanged="gvClaims_SelectedIndexChanged" OnSelectedIndexChanging="gvClaims_SelectedIndexChanging" Width="526px">
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
        </tr>
       
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
