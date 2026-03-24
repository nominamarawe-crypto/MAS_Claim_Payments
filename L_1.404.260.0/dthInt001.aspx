<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthInt001.aspx.cs" Inherits="dthInt001" %>
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
    
  function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}    
</script>

</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS">
        <span><strong><span style="font-size: 14pt">
            Sri Lanka Insurance<br />
        </span>Death Intimation</strong></span><br />
        </span>
        <table style="width: 753px; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; border-bottom-width: thin; border-bottom-color: black;" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Name of Insured</td>
                <td style="height: 20px; text-align: left;" colspan="3">
                    :-<asp:Label ID="lblnameofInsured" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Address of Insured</td>
                <td style="height: 20px; text-align: left;" colspan="3">
                    :-<asp:Label ID="lblassuredad1" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                </td>
                <td style="height: 20px; text-align: left;" colspan="3">
                    &nbsp;
                    <asp:Label ID="lblassuredad2" runat="server" Font-Bold="False" Width="428px"></asp:Label></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Date of Commencement</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:Label ID="lbldtofcomm" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="height: 20px; width: 146px; text-align: left;">
                    </td>
                <td style="height: 20px; width: 190px; text-align: left;">
                    </td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; border-bottom: black thin solid;" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Policy No.</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:TextBox ID="txtpolno" runat="server" MaxLength="8" OnTextChanged="txtpolno_TextChanged" AutoPostBack="True" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="height: 20px; width: 146px; text-align: left;">
                    Main Life or <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Spouse</span></td>
                <td style="height: 20px; width: 190px; text-align: left;">
                    :-<asp:DropDownList ID="ddlMOS" runat="server" OnSelectedIndexChanged="ddlMOS_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; text-align: center;" colspan="6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Enter the Policy Number"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Enter a Numeric Policy Number"></asp:CustomValidator>
                    </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Name of Dead Person</td>
                <td style="height: 20px; text-align: left;" colspan="3">
                    :-<asp:TextBox ID="txtnameofdd" runat="server" Width="505px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtnameofdd"
                        ErrorMessage="Please Enter The Name of Dead"></asp:RequiredFieldValidator></td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Date of Death</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:TextBox ID="txtdtofdth" runat="server" MaxLength="8" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 20px; width: 146px; text-align: left;">
                    Date of Intimation</td>
                <td style="height: 20px; width: 190px; text-align: left;">
                    :-<asp:TextBox ID="txtdtofinfo" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 10px; background-color: #f0f0f0; font-weight: normal;" colspan="2">
                </td>
                <td style="height: 10px; background-color: #f0f0f0; font-weight: normal; text-align: left;" colspan="2">
                    &nbsp; yyyymmdd</td>
                <td style="height: 10px; background-color: #f0f0f0; text-align: left; font-weight: normal;" colspan="2">
                    &nbsp; yyyymmdd</td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Policy Status</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:Label ID="lblpolstat" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="height: 20px; width: 146px; text-align: left;">
                    Method of Inform</td>
                <td style="height: 20px; width: 190px; text-align: left;">
                    :-<asp:DropDownList ID="ddlinfometh" runat="server">
                    </asp:DropDownList></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Sum Assured</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:Label ID="lblsumassured" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td style="height: 20px; width: 146px; text-align: left;">
                    Table/Term</td>
                <td style="height: 20px; width: 190px; text-align: left;">
                    :-
                    <asp:Label ID="lbltab" runat="server" Font-Bold="False" Width="50px"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Font-Bold="False" Width="50px"></asp:Label>
                </td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; border-bottom: black thin solid; background-color: #f0f0f0; text-align: left; margin-bottom: 1px;" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Informers ID</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:TextBox ID="txtinfoid" runat="server" MaxLength="10" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 20px; width: 146px; text-align: left;">
                </td>
                <td style="height: 20px; width: 190px; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: left;" colspan="3">
                    </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Informers Name</td>
                <td style="height: 20px; text-align: left;" colspan="3">
                    :-<asp:TextBox ID="txtinfoname" runat="server" MaxLength="60" Width="505px" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Informers Relationship</td>
                <td style="height: 20px; text-align: left;" colspan="3">
                    :-<asp:TextBox ID="txtinforel" runat="server" Width="505px" MaxLength="25" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 31px;">
                </td>
                <td style="height: 19px; width: 219px; text-align: left;">
                    Informers Address</td>
                <td style="height: 19px; text-align: left;" colspan="3">
                    :-<asp:TextBox ID="txtinfoad1" runat="server" Width="505px" MaxLength="40" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 19px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 31px;">
                </td>
                <td style="height: 19px; width: 219px; text-align: left;">
                </td>
                <td style="height: 19px; text-align: left;" colspan="3">
                    &nbsp;
                    <asp:TextBox ID="txtinfoad2" runat="server" Width="505px" MaxLength="40" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 19px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 31px;">
                </td>
                <td style="height: 19px; width: 219px; text-align: left;">
                </td>
                <td style="height: 19px; text-align: left;" colspan="3">
                    &nbsp;
                    <asp:TextBox ID="txtinfoad3" runat="server" Width="505px" MaxLength="40" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 19px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 31px;">
                </td>
                <td style="height: 19px; width: 219px; text-align: left;">
                </td>
                <td style="height: 19px; text-align: left;" colspan="3">
                    &nbsp;
                    <asp:TextBox ID="txtinfoad4" runat="server" Width="505px" MaxLength="40" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 19px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; text-align: left;">
                    Informers Tele.</td>
                <td style="height: 20px; width: 201px; text-align: left;">
                    :-<asp:TextBox ID="txtinfotel" runat="server" MaxLength="10" Font-Names="Trebuchet MS"></asp:TextBox></td>
                <td style="height: 20px; text-align: left;" colspan="2">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtinfotel" ErrorMessage="Pleasse Enter a Numeric Telephone No."></asp:CustomValidator></td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 10px; background-color: #f0f0f0; border-bottom: black thin solid;" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px;">
                </td>
                <td style="height: 20px; width: 201px; text-align: left;">
                </td>
                <td style="height: 20px; width: 146px; text-align: left;">
                </td>
                <td style="height: 20px; width: 190px; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0;" colspan="6">
                    &nbsp;<asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="   Add   " Font-Bold="True" Font-Names="Trebuchet MS" />&nbsp;<asp:Button
                        ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update" Enabled="False" Font-Bold="True" Font-Names="Trebuchet MS" />
                    <asp:Button ID="btndel" runat="server" OnClick="btndel_Click" Text="Delete" Enabled="False" Font-Bold="True" Font-Names="Trebuchet MS" /></td>
            </tr>
            <tr>
                <td style="height: 20px;" colspan="6">
                    <asp:Button ID="btnreset" runat="server" OnClick="btnreset_Click" Text=" Reset " Font-Bold="True" Font-Names="Trebuchet MS" />
                    <asp:Button ID="btnexit" runat="server" Text="  Exit  "  OnClientClick = "MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Font-Bold="True" Font-Names="Trebuchet MS" /></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px;">
                </td>
                <td style="height: 20px; width: 201px;">
                </td>
                <td style="height: 20px; width: 146px;">
                </td>
                <td style="height: 20px; width: 190px; text-align: left;">
                </td>
                <td style="height: 20px; width: 33px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0; width: 31px;">
                </td>
                <td style="height: 20px; width: 219px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 201px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 146px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 190px; background-color: #f0f0f0;">
                </td>
                <td style="height: 20px; width: 33px; background-color: #f0f0f0;">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
