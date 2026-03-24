<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymentDistn001.aspx.cs" Inherits="paymentDistn001" %>
<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
        <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
    
    
     function test(source, arguments)
    {
    	
     if (!IsNumeric02(arguments.Value))
               {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
  function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}

    
    
</script>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span><span><span style="font-family: Trebuchet MS">
        <table style="width: 605px; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="5">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 4px">
                    <span style="font-size: 12pt"><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span>Death Calim Payments</span></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: whitesmoke; text-align: center">
                    <asp:Label ID="lblsuccess" runat="server" Font-Size="12pt" ForeColor="#00CC33" Width="327px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px;">
                </td>
                <td style="height: 18px; width: 176px; text-align: left;">
                    Policy No.</td>
                <td style="height: 18px; width: 153px; text-align: left;">
                    <asp:Label ID="lblpolno" runat="server" Width="118px" Font-Bold="False"></asp:Label></td>
                <td style="width: 147px; height: 18px; text-align: left">
                    Calim No.</td>
                <td style="height: 18px; text-align: left; width: 122px;">
                    <asp:Label ID="lblclmno" runat="server" Width="118px" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="5">
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 35px;">
                </td>
                <td style="height: 19px; width: 176px; text-align: left;">
                    Total Payment</td>
                <td style="height: 19px; text-align: left;" colspan="3">
                    <asp:TextBox ID="txttotPay" runat="server" MaxLength="12" ReadOnly="True"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txttotPay" ErrorMessage="Please Enter a Numeric Amount" Width="217px" Display="Dynamic" Font-Bold="False" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="4">
                    </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px;">
                </td>
                <td style="height: 18px; width: 176px; text-align: left;">
                    Exgracia Payment</td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    <asp:TextBox ID="txtexpay" runat="server" MaxLength="12" ReadOnly="True"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtexpay" ErrorMessage="Please Enter a Numeric Exgracia Amount"
                        Width="239px" Display="Dynamic" Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="4">
                    </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px;">
                </td>
                <td style="height: 18px; width: 176px; text-align: left;">
                    Payment Receipients</td>
                <td style="height: 18px; text-align: left;" colspan="3">
                    <asp:DropDownList ID="ddlReciepients" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReciepients_SelectedIndexChanged" Width="136px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; width: 176px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; width: 20px; background-color: #f0f0f0;">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="height: 18px; width: 122px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px;" colspan="5">
                    <asp:Button ID="btnConf" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnConf_Click" Text="--Confirm--" />
                    <asp:Button ID="btnReject" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnReject_Click" Text="--Reject--" />
                    <asp:Button ID="btnSubmit" runat="server" Text="--Shares--" Font-Bold="False" 
                        Font-Names="Trebuchet MS" PostBackUrl="~/paymentDistn002.aspx" 
                        onclick="btnSubmit_Click" />
                    <asp:Button ID="btnExit" runat="server" Text="--Exit--"  OnClientClick="MM_goToURL('self','Home.aspx');return document.MM_returnValue"  Font-Bold="False" Font-Names="Trebuchet MS" /></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="4">
                    <asp:Label ID="lblalert" runat="server" Width="331px" ForeColor="Red" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 18px;" colspan="5">
                    <asp:CustomValidator ID="cv" runat="server" Width="395px" Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 35px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; width: 176px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; width: 20px; background-color: #f0f0f0;">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="height: 18px; width: 122px; background-color: #f0f0f0;">
                </td>
            </tr>
        </table>
    
    <br />
        </span>
        </span>
        </span>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='dthPay003.aspx';

}


</script>

</html>
