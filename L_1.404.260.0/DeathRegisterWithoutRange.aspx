<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeathRegisterWithoutRange.aspx.cs" Inherits="DeathRegisterWithoutRange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Death Register (Without Range)</title>
    <style type="text/css"> 
    .gvPagerCss span
    {
        background-color:#DEE1E7;
        font-size:20px;
    }  
    .gvPagerCss td
    {
        padding-left: 5px;   
        padding-right: 5px;  
    }
      .FixedHeader{
    position: relative;
    top: expression(this.offsetParent.scrollTop);
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
   
    <div>
    <asp:GridView ID="GridViewDeathRegisterView" runat="server" EnableSortingAndPagingCallbacks="True" OnPageIndexChanging="GridViewDeathRegisterView_PageIndexChanging" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="20">
            <PagerSettings FirstPageText="First Page" LastPageText="Last Page" NextPageText="Next" PreviousPageText="Prev" Mode="NumericFirstLast" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" CssClass="gvPagerCss" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" CssClass="FixedHeader" />
        </asp:GridView>
    </div>
        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export" /><br /> <asp:Label ID="lblMassage" runat="server" Text="" EnableViewState="False" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
