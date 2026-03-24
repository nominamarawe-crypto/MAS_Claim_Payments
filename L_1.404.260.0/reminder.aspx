<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reminder.aspx.cs" Inherits="reminder" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center" id="DIV1" runat="server">
        <span style="font-family: Trebuchet MS"><strong>
        <span><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
        </span>Death Calim Reminders</span><br />
        </strong></span>
        <table style="width: 723px; font-size: 10pt; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
            <tr>
                <td style="width: 20px; height: 17px">
                </td>
                <td style="height: 17px; text-align: left">
                    <strong><span style="font-size: 14pt"></span></strong>
                </td>
                <td style="width: 20px; height: 17px; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: left">
                    <strong><span style="color: #ff0000">Death Claim Entitled Policies
                        with Requirements not Recieved within 14 days.</span></strong></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="625px">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:HyperLinkField DataTextField="polno" HeaderText="Policy Number" />
                            <asp:BoundField DataField="type" HeaderText="Life Type" />
                            <asp:BoundField DataField="sentdate" HeaderText="Sent Date" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        </Columns>
                        <RowStyle BackColor="#E3EAEB" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: left">
                    <strong><span style="color: #ff0000">Death Claim Entitled Policies with Requirements
                        not Recieved within 14 days Since the First Reminder was Sent.</span></strong></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px">
                    <br />
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="625px">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:HyperLinkField DataTextField="polno" HeaderText="Policy Number" />
                            <asp:BoundField DataField="type" HeaderText="Life Type" />
                            <asp:BoundField DataField="sentdate" HeaderText="Sent Date" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        </Columns>
                        <RowStyle BackColor="#E3EAEB" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: left">
                    <strong><span style="color: #ff0000">Death Claim Entitled Policies with Requirements
                        not Recieved within a Month Since the Second Reminder was Sent.</span></strong></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px">
                    <br />
                    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="625px">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:HyperLinkField DataTextField="polno" HeaderText="Policy Number" />
                            <asp:BoundField DataField="type" HeaderText="Life Type" />
                            <asp:BoundField DataField="sentdate" HeaderText="Sent Date" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        </Columns>
                        <RowStyle BackColor="#E3EAEB" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: center">
                    <asp:HyperLink ID="linkBack" runat="server" Font-Bold="False" ForeColor="#0000CC"
                        NavigateUrl="~/Home.aspx" Font-Size="10pt"><<--Back</asp:HyperLink></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
