<%@ Page Language="C#" AutoEventWireup="true" CodeFile="livingPrt001.aspx.cs" Inherits="livingPrt001" %>
<%@ PreviousPageType VirtualPath="~/dthReg002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span></strong>
        <table style="font-weight: normal; font-size: 10pt; width: 697px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="5" style="height: 20px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px">
                    <strong>
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Living Partner Details</span></strong></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="5">
                    <asp:Label ID="lblsuccess" runat="server" Width="400px" Font-Bold="True" Font-Size="12pt" ForeColor="#00CC66"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Policy No.</td>
                <td style="width: 220px; height: 20px; text-align: left">
                    :<asp:Label ID="lblpolno" runat="server" Width="140px"></asp:Label></td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Branch</td>
                <td style="height: 20px; text-align: left">
                    :<asp:Label ID="lblbrn" runat="server" Width="74px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Name</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtsta" runat="server" MaxLength="13" Width="51px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:TextBox ID="txtsurname" runat="server" MaxLength="30" Width="355px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsurname"
                        Display="Dynamic" ErrorMessage="Please Enter Name?"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Full Name</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtfullname" runat="server" MaxLength="100" Width="417px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfullname"
                        Display="Dynamic" ErrorMessage="Please Enter Full Name?"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Date of Birth</td>
                <td style="width: 220px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txtdob" runat="server" MaxLength="8" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>YYYYMMDD</td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Age</td>
                <td style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtage" runat="server" MaxLength="2" Width="51px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="2">
                    </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="2">
                    </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Gender</td>
                <td style="width: 220px; height: 20px; text-align: left">
                    :<asp:DropDownList ID="ddlGender" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:DropDownList></td>
                <td style="width: 129px; height: 20px; text-align: left">
                    NIC No.</td>
                <td style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtnic" runat="server" MaxLength="10" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Occupation</td>
                <td style="width: 220px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txtoccu" runat="server" MaxLength="20" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 129px; height: 20px; text-align: left">
                    Passport No.</td>
                <td style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtpassprt" runat="server" MaxLength="14" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Telephone No.</td>
                <td style="width: 220px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txttelno" runat="server" MaxLength="20" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 129px; height: 20px; text-align: left">
                    E-Mail</td>
                <td style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtemail" runat="server" MaxLength="35" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Address</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtad1" runat="server" MaxLength="50" Width="417px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    &nbsp;<asp:TextBox ID="txtad2" runat="server" MaxLength="50" Width="417px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td style="width: 126px; height: 20px; text-align: left">
                    Partnership Date</td>
                <td style="height: 20px; text-align: left" colspan="3">
                    :<asp:TextBox ID="txtprtnrshipdt" runat="server" MaxLength="8" Width="125px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    YYYYMMDD<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtprtnrshipdt" ErrorMessage="Please Enter a Numeric Partnership Date?"
                        Width="277px" Display="Dynamic"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 20px">
                </td>
                <td colspan="4" style="height: 20px; text-align: center">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="--Submit--" Font-Bold="False" Font-Names="Trebuchet MS" Width="86px" Font-Size="10pt" />&nbsp;
                    <asp:Button ID="btnshares" runat="server"  Text="--Shares--" Font-Bold="False" Font-Names="Trebuchet MS" OnClick="btnshares_Click" Width="85px" Font-Size="10pt" /></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 129px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
