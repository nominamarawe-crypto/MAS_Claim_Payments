<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EPage.aspx.cs" Inherits="EPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    
</head>
<body>
<script language ="JavaScript" type ="text/javascript" >
    function backPage()
    {
        history.back(1);
    }
    </script>
    <form id="form1" runat="server">
<%--    <asp:ImageButton ID="ImageButton1" runat="server" Height="43px" Onclick= "javascript:backPage()"
            Width="70px" ImageUrl="~/NBack.gif" />
--%>            &nbsp;<div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    <br />
        <br />
<input type="button" value="<< Back" onclick="backPage();"><br />
        <br />
        <asp:Label ID="LabMesege" runat="server" Font-Size="X-Large" ForeColor="Red" Height="65px"
            Width="574px"></asp:Label>&nbsp;</div>
            
    </form>
</body>
</html>
