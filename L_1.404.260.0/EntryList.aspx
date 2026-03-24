<%@ Page Language="C#" debug="true" AutoEventWireup="true" CodeFile="EntryList.aspx.cs" Inherits="EntryList"  %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 842px; height: 150px">
            <tr>
                <td colspan="6" style="height: 10px">
                    <span style="font-size: 14pt; font-family: Trebuchet MS"><strong>Unauthorize Claim List</strong></span></td>
                <td colspan="1" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 10px; background-color: #f0f0f0">
                </td>
                <td colspan="1" style="height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 10px">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None"
                        BorderWidth="1px" CellPadding="3" DataKeyNames="Policy Number,Claim Number" DataSourceID="SqlDataSource1"
                        GridLines="Vertical" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                        Width="300px">
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:CommandField>
                            <asp:BoundField DataField="Policy Number" HeaderText="Policy Number" ReadOnly="True"
                                SortExpression="Policy Number">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Claim Number" HeaderText="Claim Number" ReadOnly="True"
                                SortExpression="Claim Number">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand='select POLNO "Policy Number",CLMNO "Claim Number" from lphs.dthout_temp'>
                    </asp:SqlDataSource>
                    &nbsp;
                </td>
                <td colspan="1" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 10px; background-color: #f0f0f0">
                </td>
                <td colspan="1" style="height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 10px">
                </td>
                <td colspan="1" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 10px; background-color: #f0f0f0">
                </td>
                <td colspan="1" style="height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
