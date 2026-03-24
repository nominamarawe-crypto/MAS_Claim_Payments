<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignee001.aspx.cs" Inherits="assignee001" %>
<%@ PreviousPageType VirtualPath="~/dthReg002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
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
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        <strong><span></span></strong>
        </span><strong>
        <span></span>
        </strong></span>
        <table style="font-weight: bold; width: 683px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #ffffff">
                    <span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span><strong><span style="font-size: 12pt">Assignees</span></strong></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0" colspan="3">
                    <asp:Label ID="lblsucess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="#33CC66"
                        Text="Record Updated Succesfully" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                    Policy No.</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:Label ID="lblpolno" runat="server" Width="96px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 109px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                    Assignee Name</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtSta" runat="server" Width="181px" MaxLength="13"></asp:TextBox>
                    <asp:TextBox ID="txtInt" runat="server" Width="181px" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtSurname" runat="server" Width="373px" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 19px; background-color: #f0f0f0">
                </td>
                <td style="width: 109px; height: 19px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 19px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 19px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                    Full Name</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtFullNmae" runat="server" Width="369px" MaxLength="100"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 109px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                    Short Name</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtShortName" runat="server" Width="369px" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 109px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 19px">
                </td>
                <td style="width: 109px; height: 19px; text-align: left">
                    Address</td>
                <td colspan="2" style="height: 19px; text-align: left">
                    :-
                    <asp:TextBox ID="txtAdd1" runat="server" Width="367px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAdd2" runat="server" Width="369px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtAdd3" runat="server" MaxLength="50" Width="369px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 109px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                    Account No.</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtAcctNo" runat="server" Width="181px" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAcctNo"
                        ErrorMessage="At Least Please Enter the Account No." Font-Bold="False"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtAcctNo" ErrorMessage="Please Enter a Numeric Account No."
                        Width="237px" Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 109px; height: 20px; text-align: left">
                    Assignment Date</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtasignmentDate" runat="server" MaxLength="8" Width="181px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="3">
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtasignmentDate" ErrorMessage="Please Enter a Numeric Asignment Date"
                        Width="287px" Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Font-Bold="True" Font-Names="Trebuchet MS" Width="80px" />
                    <asp:Button ID="btnshares" runat="server" Text="Shares" Font-Bold="True" Font-Names="Trebuchet MS" OnClick="btnshares_Click" Width="73px" />
                    </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 109px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
