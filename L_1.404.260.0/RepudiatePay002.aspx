<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepudiatePay002.aspx.cs" Inherits="RepudiatePay002" %>
<%@ PreviousPageType VirtualPath="~/RepudiatePay001.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
<script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric(arguments.Value))
            {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->    
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 236px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; height: 21px; text-align: left;">
                    &nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px">
                </td>
                <td colspan="2" style="text-align: center">
                    <strong><span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt; font-family: Trebuchet MS;">Special Payment for Repudiated Death Claims</span></strong></td>
                <td style="width: 23px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; height: 21px; background-color: #f0f0f0; text-align: left;">
                    &nbsp;</td>
                <td style="height: 21px; background-color: #f0f0f0; width: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Exgracia Claim Amount</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; height: 21px; background-color: #f0f0f0; text-align: left;">
                    &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Width="237px" Height="16px"></asp:CustomValidator>&nbsp;</td>
                <td style="height: 21px; background-color: #f0f0f0; width: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Vested Bonus</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtBonus" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 236px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left; height: 21px;">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtBonus" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Interim Bonus</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtInterimbon" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 236px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left; height: 21px;">
                    <asp:CustomValidator ID="CustomValidator11" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtInterimbon" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 11px">
                </td>
                <td style="width: 236px; height: 11px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Deposits</span></strong></td>
                <td style="width: 305px; height: 11px; text-align: left">
                    <asp:TextBox ID="txtDeposit" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;<asp:CheckBox
                        ID="chkPaydeposit" runat="server" Checked="True" Font-Names="Trebuchet MS" Font-Size="Smaller"
                        Text="Refund Deposit" /></td>
                <td style="width: 23px; height: 11px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Other Additions</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtOtheradds" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left">
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtOtheradds" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Default Premium</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtDefprem" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 236px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left; height: 21px;">
                    <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtDefprem" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Default Premium Interest</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtDefpremint" runat="server"></asp:TextBox></td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; height: 21px; background-color: #f0f0f0; text-align: left">
                    &nbsp;</td>
                <td style="width: 23px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Amount to Complete
                        Policy Year</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtAmtcompolyr" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; height: 21px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; height: 21px; background-color: #f0f0f0; text-align: left">
                    <asp:CustomValidator ID="CustomValidator7" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtAmtcompolyr" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Loan Capital</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtLoancap" runat="server"></asp:TextBox>&nbsp;</td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left">
                    <asp:CustomValidator ID="CustomValidator8" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtLoancap" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 22px">
                </td>
                <td style="width: 236px; height: 22px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Loan Interest</span></strong></td>
                <td style="width: 305px; height: 22px; text-align: left">
                    <asp:TextBox ID="txtLoanint" runat="server"></asp:TextBox></td>
                <td style="width: 23px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="width: 236px; background-color: #f0f0f0; text-align: right; height: 21px;">
                    &nbsp;</td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left; height: 21px;">
                    <asp:CustomValidator ID="CustomValidator9" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtLoanint" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Other Deductions</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtOtherdeduct" runat="server"></asp:TextBox></td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; background-color: #f0f0f0">
                    &nbsp;</td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left">
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtOtherdeduct" Display="Dynamic" ErrorMessage="Amount not in correct form"
                        Font-Bold="False" Font-Size="10pt" Height="16px" Width="237px"></asp:CustomValidator></td>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
            </tr>
            <% if ((Table == 38 || Table == 39 || Table == 46 || Table == 49 || Table == 34) && Mos == "M")
               {  %>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td style="width: 236px; height: 21px; text-align: right;">
                    <strong><span style="font-size: 11pt; font-family: Trebuchet MS">Is Future Payment</span></strong></td>
                <td style="width: 305px; height: 21px; text-align: left">
                    <asp:DropDownList ID="ddlFuturePay" runat="server" Width="80px">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 23px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <% } %>
            <tr>
                <td style="width: 23px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px">
                    <asp:Button ID="cmdSubmit" runat="server" Text="Submit" Width="70px" Font-Bold="True" OnClick="cmdSubmit_Click" />
                    <asp:Button
                        ID="Button2" runat="server" Text="Exit" Width="70px" Font-Bold="True" />&nbsp;<asp:Button
                        ID="cmdNext" runat="server" Enabled="False" Font-Bold="True" PostBackUrl="~/RepudiatePay003.aspx"
                        Text="Next" Width="70px" OnClick="cmdNext_Click" /></td>
                <td style="width: 23px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
                <td style="width: 236px; background-color: #f0f0f0">
                </td>
                <td style="width: 305px; background-color: #f0f0f0; text-align: left;">
                    &nbsp;</td>
                <td style="width: 23px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
