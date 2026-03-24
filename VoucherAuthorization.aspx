<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VoucherAuthorization.aspx.cs" Inherits="MAS_Claim_Payments.VoucherAuthorization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
            text-align: center;
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
            text-align: left;
            width: 19px;
            height: 229px;
        }
        .auto-style2 {
            text-align: center;
            height: 229px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" class="style1" style="font-family: 'Trebuchet MS'; font-size: small; color: #000000;">
        <tr>
            <td class="style23" style="text-align: center; font-weight: 700; color: SteelBlue">&nbsp;</td>
            <td class="style3" colspan="2" style="text-align: center; font-weight: 700; color: SteelBlue">VOUCHER AUTHORIZATION</td>
        </tr>
        <tr>
            <td align="center" class="style27">&nbsp;</td>
            <td align="center" colspan="2" style="text-align: left">&nbsp;</td>
        </tr>
        
        <tr>
            <td class="style26">&nbsp;</td>
            <td class="style13">NIC Number</td>
            <td class="style30" style="text-align: left">:<asp:TextBox ID="tbxNic" runat="server" MaxLength="12" Width="150px"></asp:TextBox>
                <span class="style30">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxNic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </span></td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">&nbsp;</td>
            <td class="style16"><asp:RegularExpressionValidator ID="regExpValPayeeName2" runat="server" ControlToValidate="tbxNic" ErrorMessage="Invalid NIC No Format" ForeColor="Red" ValidationExpression="[0-9]{9}[V|v|X|x]|[A-Z][0-9]*|[1-2][0-9]{11}|0"></asp:RegularExpressionValidator>
            </td>
        </tr>
       
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td class="style27" style="text-align: center">&nbsp;</td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnSubmit" runat="server" class="button button1" onclick="btnSubmit_Click" Text="Submit" />
                <asp:Button ID="btnReset" runat="server" CausesValidation="False" class="button button1" onclick="btnReset_Click" Text="Reset" />
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <% 
            if (!this.tbxNic.Text.Equals(""))
            {
                if (this.gvIndividualVous.Rows.Count > 0)
                {
                %>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2" colspan="2">
                <asp:GridView ID="gvIndividualVous" runat="server" AutoGenerateColumns="False" CellPadding="1" CellSpacing="1" DataSourceID="sqlDSIndiVouchers" Width="650px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvIndividualVous_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="CLAIM_NO" HeaderText="CLAIM_NO" SortExpression="CLAIM_NO">
                        </asp:BoundField>
                        <asp:BoundField DataField="VOU_NO" HeaderText="VOU_NO" SortExpression="VOU_NO">
                        </asp:BoundField>
                        <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" SortExpression="AMOUNT">
                        </asp:BoundField>
                        <asp:BoundField DataField="INSURED_NAME" HeaderText="INSURED_NAME" SortExpression="INSURED_NAME">
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sqlDSIndiVouchers" runat="server" ConnectionString="<%$ ConnectionStrings:DBConString %>" ProviderName="<%$ ConnectionStrings:DBConString.ProviderName %>" SelectCommand="select CLAIM_NO, VOU_NO, AMOUNT, INSURED_NAME from SLIC_CHP.VOU_DETAILS_MAS  where NIC =:nic and VOU_STATUS = 'Vou.Printed'  and VOU_PRINTED_BY is not null and VOU_AUTHORIZED_BY is null">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="tbxNic" Name="nic" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </td>
        </tr>
        <%
            }
            else
            {
                %>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblError1" runat="server" ForeColor="Red">No voucher for authorization.</asp:Label>
            </td>
        </tr>
       <%
               }
           }

           %>
    </table>
</asp:Content>
