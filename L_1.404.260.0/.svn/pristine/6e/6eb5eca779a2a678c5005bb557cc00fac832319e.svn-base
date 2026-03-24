<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sundryrcpt002.aspx.cs" Inherits="Sundryrcpt002" %>
<%@ PreviousPageType VirtualPath="~/sundryrcpt001.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="JavaScript/ValidateNumeric.js" language="javascript" type="text/javascript"></script>
        <script type="text/javascript">
        
     function checkbx(txt,chk)
    {   
    if(chk.checked)
    {   
    txt.disabled=false;
    }
    else
    {
    txt.disabled=true;
    }   
    
    }      
    
</script>
    
</head>
<body >
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-size: 10pt; width: 706px; font-family: 'Trebuchet MS'; text-align: center;">
            <tr>
                <td colspan="4" style="height: 15px; width: 146px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px; width: 146px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px; text-align: center;">
                    <strong>SUNDRY RECEIPT DETAILS</strong></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    Policy Number</td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litpol" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 15px; text-align: left">
                    Claim Number</td>
                <td style="width: 125px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litclm" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    Table/Term</td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="littbtr" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 15px; text-align: left">
                    Commencement Date</td>
                <td style="width: 125px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litcomdt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    Premium</td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litprm" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 15px; text-align: left">
                    Policy Status</td>
                <td style="width: 125px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litpolst" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    Name</td>
                <td colspan="3" style="height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litnm" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    Age Diff Premium Amount</td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litagedfamt" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 15px; text-align: left">
                    Age Diff Interest</td>
                <td style="width: 125px; height: 15px; text-align: left">
                    :<asp:Literal ID="litAgediffInt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 15px; text-align: left;">
                    Payment Mode</td>
                <td style="width: 146px; height: 15px; text-align: left;">
                    :<asp:Literal ID="litpymd" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px;">
                </td>
                <td style="width: 146px; height: 15px;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    Difference of First Premium</td>
                <td colspan="2" style="height: 15px; text-align: left">
                    <strong>:</strong><asp:TextBox ID="Txtdiffsinprm" runat="server" Width="97px"></asp:TextBox>&nbsp;<asp:Literal
                        ID="litdueyrmn" runat="server"></asp:Literal></td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    1st Year Total Premium (Excluding 1st Premium)
                </td>
                <td style="height: 15px; text-align: left" colspan="2">
                    <strong>:</strong><asp:TextBox ID="Txtremprm" runat="server" Width="95px"></asp:TextBox>
                    <asp:Literal ID="litnxtdue" runat="server"></asp:Literal></td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 16px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 16px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 16px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 16px; background-color: #f0f0f0;">
                </td>
            </tr>
            
             <%--<% 
                 int i=1;
                for (int count = 1; count <= term-1; count++)
                {
                                  
            %>--%>
            <%--<%
                }
                 i++;
                 } 
            %>--%>
           
            <tr>
                <td style="height: 15px" colspan="4">
                    <asp:Table ID="Table1" runat="server" Width="609px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0;">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px">
                </td>
                <td style="width: 150px; height: 15px">
                    <asp:Button ID="Btn_sub" runat="server" OnClick="Btn_sub_Click" Text="Submit" Width="103px" PostBackUrl="~/SundryPrint003.aspx" /></td>
                <td style="width: 136px; height: 15px">
                    <%--<asp:Button ID="Btn_can" runat="server" Text="Button" Width="113px" />--%></td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="height: 15px; background-color: #f0f0f0; text-align: left;" colspan="4">
                    <asp:Label ID="lblerr" runat="server" Font-Bold="True" ForeColor="Red" Width="633px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px">
                </td>
                <td style="width: 150px; height: 15px">
                </td>
                <td style="width: 136px; height: 15px">
                </td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hdfmos" runat="server" />
        <asp:HiddenField ID="hdfepf" runat="server" />
        <asp:HiddenField ID="hdfbrn" runat="server" />
    </form>
</body>
</html>
