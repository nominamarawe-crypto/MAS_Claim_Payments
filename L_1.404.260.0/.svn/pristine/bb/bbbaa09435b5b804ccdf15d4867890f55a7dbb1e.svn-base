<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nomDetEnt03.aspx.cs" Inherits="nomDetEnt03" %>
<%@ PreviousPageType VirtualPath="~/nomDetEnt02.aspx"%>
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
        <span style="font-family: Trebuchet MS"><strong>
        <span><span><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
        </span>Nominee Detail Update</span></span><br />
        </strong></span>
        <table style="font-weight: bold; width: 651px; text-align: center; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0">
                    <asp:Label ID="lblsuccess" runat="server" Font-Size="14pt" ForeColor="#00CC33" Width="244px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Policy No.</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:Label ID="lblpolno" runat="server" Width="122px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Nominee Name</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtname" runat="server" MaxLength="50" Width="401px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 19px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 19px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 19px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 19px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Nominee No.</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtNomNum" runat="server" MaxLength="2" ReadOnly="True" Width="51px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 19px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 19px; background-color: #f0f0f0">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 21px; height: 19px">
                </td>
                <td style="width: 129px; height: 19px; text-align: left">
                    Address</td>
                <td colspan="2" style="height: 19px; text-align: left">
                    :-
                    <asp:TextBox ID="txtAdd1" runat="server" MaxLength="50" Width="401px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtAdd2" runat="server" MaxLength="50" Width="401px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 102px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 127px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    NIC No.</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtNICno" runat="server" MaxLength="11" Width="201px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Date of Birth</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="8" Width="201px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtDOB" ErrorMessage="Please Enter a Numeric Date of Birth"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Nominate Date</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtnominateDate" runat="server" MaxLength="8" Width="201px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtnominateDate" ErrorMessage="Please Enter a Numeric Nominate Date"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Percentage</td>
                <td colspan="2" style="height: 20px; text-align: left">
                    :-
                    <asp:TextBox ID="txtPer" runat="server" MaxLength="3" Width="51px"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtPer" ErrorMessage="Please Enter a Numeric Percentage"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="percenatgeValidator" runat="server" ErrorMessage="Total Percenatage Exceeds 100! Please Enter a Proper Percentage."></asp:CustomValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px">
                    <asp:Button ID="btnUpd" runat="server" OnClick="btnUpd_Click" Text="Update" Font-Bold="True" Font-Names="Trebuchet MS" />
                    <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="Delete" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="10pt" />
                    <asp:Button ID="btnshares" runat="server" Text="Shares" Font-Bold="True" Font-Names="Trebuchet MS" OnClick="btnshares_Click" PostBackUrl="~/paymentDistn001.aspx" />&nbsp;<asp:Button
                        ID="btnExit" runat="server" OnClientClick="MM_goToURL('self','nomDetEnt01.ASPX');return document.MM_returnValue"
                        Text="  Exit  " Font-Bold="True" Font-Names="Trebuchet MS" /></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPer"
                        ErrorMessage="Please Enter the Percentage"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px">
                    <span style="color: #cc0066">
                        </span></td>
            </tr>
            <tr>
                <td style="width: 21px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
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
