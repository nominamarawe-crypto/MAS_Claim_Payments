<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UploadData.aspx.cs" Inherits="MAS_Claim_Payments.UploadData" %>
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
            height: 167px;
        }
        .auto-style2 {
            text-align: center;
            height: 167px;
        }
        .auto-style3 {
            width: 77%;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            text-align: left;
            width: 19px;
            height: 27px;
        }
        .auto-style6 {
            text-align: center;
            height: 27px;
        }
        .auto-style7 {
            text-align: left;
            width: 19px;
            height: 118px;
        }
        .auto-style8 {
            text-align: center;
            height: 118px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" class="auto-style3" style="font-family: 'Trebuchet MS'; font-size: small; color: #000000;">
        <tr>
            <td class="style23" style="text-align: center; font-weight: 700; color: SteelBlue">&nbsp;</td>
            <td class="style3" colspan="2" style="text-align: center; font-weight: 700; color: SteelBlue">DATA UPLOAD</td>
        </tr>
        <tr>
            <td align="center" class="style27">&nbsp;</td>
            <td align="center" colspan="2" style="text-align: left">&nbsp;</td>
        </tr>
        
        <tr>
            <td class="style26">&nbsp;</td>
            <td class="style13">Select file</td>
            <td class="style30" style="text-align: left">:<asp:FileUpload ID="FileUpload1" runat="server" Width="380px" />
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6">&nbsp;</td>
            <td class="style16">&nbsp;</td>
        </tr>
       
        <tr>
            <td class="style27" style="text-align: center">&nbsp;</td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnSubmit" runat="server" class="button button1" onclick="btnSubmit_Click" Text="View Data" />
                <asp:Button ID="btnSaveData" runat="server" CausesValidation="False" class="button button1" onclick="btnSaveData_Click" Text="Save Data" />
            </td>
        </tr>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

    <%
        if (this.gv1.Rows.Count > 0)
        {
        %>
        
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2" colspan="2">
                <asp:GridView ID="gv1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="590px">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
                <br />
            </td>
        </tr>
        <%
            }
            %>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6" colspan="2">
                <strong>
                <asp:Label ID="lblResultMsg" runat="server" ForeColor="#006600"></asp:Label>
                </strong>
            </td>
        </tr>
       <%
           if (!this.lblRecCount.Text.Equals(""))
           {
           %>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="auto-style4" colspan="2">
                Uploaded Records Count : <asp:Label ID="lblRecCount" runat="server"></asp:Label>
            </td>
        </tr>
       <%
           }
           if (this.gv2.Rows.Count > 0)
           {
           %>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="auto-style4" colspan="2">
                Duplicate Records:
            </td>
        </tr>
       
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style8" colspan="2">
                <asp:GridView ID="gv2" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="590px">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </td>
        </tr>
       <%
           }
           %>
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                &nbsp;</td>
        </tr>
       
        <tr>
            <td class="style25">&nbsp;</td>
            <td class="style6" colspan="2">
                &nbsp;</td>
        </tr>
       
    </table>

</asp:Content>
