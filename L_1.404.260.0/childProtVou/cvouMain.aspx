<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cvouMain.aspx.cs" Inherits="cvouMain" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - New Loans</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 789px">
            <tr>
                <td style="width: 26px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 26px; height: 19px; text-align: center">
                </td>
                <td style="width: 160px; height: 19px; text-align: center">
                    <asp:LinkButton ID="linkvouprint" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                        OnClick="linkvouprint_Click" PostBackUrl="~/ChildProt/ChildProt001.aspx">Voucher Print</asp:LinkButton></td>
                <td style="width: 160px; height: 19px; text-align: center">
                    <asp:LinkButton ID="linkvoureprint" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                        PostBackUrl="~/ChildProt/ChildProt001.aspx" OnClick="linkvoureprint_Click">Voucher Re-print</asp:LinkButton></td>
                <td style="width: 160px; height: 19px; text-align: center">
                    <asp:LinkButton ID="linkvouedit" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                        OnClick="linkvouedit_Click" PostBackUrl="~/ChildProt/cvouDetEdit001.aspx">Voucher Details Edit</asp:LinkButton></td>
                <td style="width: 160px; height: 19px; text-align: center">
                    <asp:LinkButton ID="linkvouauth" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                        PostBackUrl="~/ChildProt/ChildProt001.aspx" OnClick="linkvouauth_Click">Voucher Authorization</asp:LinkButton></td>
                <td style="width: 160px; height: 19px; text-align: center">
                    <asp:LinkButton ID="linkvoudelete" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                        PostBackUrl="~/ChildProt/ChildProt001.aspx" OnClick="linkvoudelete_Click">Voucher Delete</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 26px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 160px; height: 20px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 160px; height: 20px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 160px; height: 20px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 160px; height: 20px; background-color: #f0f0f0; text-align: center">
                    </td>
                    <td style="width: 160px; height: 20px; background-color: #f0f0f0; text-align: center">
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
