<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loanRecReprint001.aspx.cs" Inherits="loanRecReprint001" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Loan Reciept</title>
        <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
    
    
     function test(source, arguments)
    {
    	
     if (!IsNumeric(arguments.Value))
               {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
    
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span><table style="font-size: 10pt; width: 603px; font-family: 'Trebuchet MS'; font-weight: bold;">
            <tr>
                <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Loan Reciept Reprint</span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 71px; height: 21px;">
                </td>
                <td style="width: 193px; text-align: left; height: 21px;">
                    <span style="font-weight: normal;">Policy Number</span></td>
                <td style="font-size: 10pt; width: 220px; text-align: left; height: 21px;">
                    <span><span style="font-size: 12pt"> </span>
                        <asp:TextBox ID="txtpolno" runat="server" AutoPostBack="True" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt" ></asp:TextBox></span></td>
                <td style="font-size: 10pt; width: 79px; height: 21px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 71px; height: 21px">
                </td>
                <td style="width: 193px; height: 21px; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 220px; height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" OnClientClick="cForm1(this.form1)"  PostBackUrl="~/loanRecReprint002.aspx" Text="--Submit--" Width="94px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                <td style="font-size: 10pt; width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
        </span>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
     win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
     form1.target='myWin';
     form1.action='loanRecReprint002.aspx';
}
</script>
</html>
