<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SlicvouEdit001.aspx.cs" Inherits="SlicvouEdit001" %>
<%@ PreviousPageType VirtualPath="~/voucher/vouDetEdit002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/ChildProt/childProtPay003.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<script language ="JavaScript" type ="text/javascript" >
    function backPage()
    {
        history.back(1);
    }
    </script>

    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Sri Lanka Insurance<br />
            SLIC Voucher Edit for Death Claims<br />
        </strong>
        <tr style="font-size: 10pt">
        <td colspan="4" style="height: 21px; background-color: whitesmoke">
                <asp:Label ID="lblsuccess" runat="server" Font-Size="10pt" ForeColor="#00CC33" Text="Updates Successfull"
                    Visible="False" Width="409px"></asp:Label></td>
        </tr>
        <br />
        <td colspan="4" style="height: 21px; background-color: whitesmoke">
        <asp:Label ID="Labelfail" runat="server" Font-Size="10pt" ForeColor="Red" Text="Updates Failed"
            Visible="False" Width="409px"></asp:Label></td>
        </tr>
            <br />
            <table>
                <tr>
                    <td style="width: 180px; height: 21px;">
                        Payer
                    </td>
                    <td style="width: 448px; height: 21px; ">
                            <asp:TextBox ID="txtPayer" runat="server" Width="274px" TabIndex="6" ToolTip="Organizer code" MaxLength="5" style="position: static" Font-Names="Trebuchet MS" Font-Size="10pt"  Enabled="False"></asp:TextBox>
                      </td>
                </tr>
                <tr>
                    <td style="width: 180px; height: 21px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ammount
                    </td>
                    <td style="width: 448px; height: 21px; ">
                            <asp:TextBox ID="txtAmount" runat="server" Width="274px" TabIndex="6" ToolTip="Organizer code" MaxLength="10" style="position: static" Font-Names="Trebuchet MS" Font-Size="10pt" type="number"></asp:TextBox>
                      </td>
                </tr
                <tr>
                    <td style="width: 180px; height: 21px;">
                        &nbsp;Reason
                    </td>
                    <td style="width: 448px; height: 21px; ">
                            <asp:TextBox ID="txtReason" runat="server" Width="274px" TabIndex="6" ToolTip="Organizer code" MaxLength="300" style="position: static" Font-Names="Trebuchet MS" Font-Size="10pt" ></asp:TextBox>
                      </td>
                </tr>
                <tr>
                    <td style="width: 180px; height: 21px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Account No
                    </td>
                    <td style="border-top-style: none; border-right-style: none; border-left-style: none;
                         height: 15px; border-bottom-style: none">
                         <asp:DropDownList ID="LisAccNo" runat="server" TabIndex="9" Font-Names="Trebuchet MS"
                             Font-Size="10pt" SkinID="LisAccNo"  style="width: 274px; height: 21px; " Enabled="False">
                             <asp:ListItem Value="1030001487">1030001487</asp:ListItem>
                             <asp:ListItem Value="1364403002">1364403002</asp:ListItem>
                             <asp:ListItem Value="0001092995">0001092995</asp:ListItem>
                             <asp:ListItem Value="000000000962">000000000962</asp:ListItem>
                         </asp:DropDownList>
                     </td>
                </tr>
                <tr>
                    
                    <td colspan="3" style="height: 21px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="28px" Text="Update"
                            Width="77px" OnClick="Button1_Click" OnClientClick="backPage()" />
                        <asp:Button ID="Button2" runat="server" Font-Bold="True" Height="28px" PostBackUrl="~/Home.aspx"
                            Text="Cancel" Width="76px" /></td>
                    <td style="width: 23px; height: 21px">
                    </td>
                </tr>
                <br />
                <td colspan="4" style="height: 21px; font-weight:bold; background-color: whitesmoke">
                    <asp:Label ID="Label1" runat="server" Font-Size="10pt" ForeColor="Red"
                    Visible="False" Width="409px"></asp:Label></td>
               
            </table>
    
    </div>
    </form>
</body>
</html>
