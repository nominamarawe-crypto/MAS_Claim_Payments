<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthInt020.aspx.cs" Inherits="dthInt020" %>
<%@ PreviousPageType VirtualPath="~/dthInt010.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script  type="text/javascript" language="javascript">
</script>
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
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span></strong>
        <table style="font-weight: bold; font-size: 10pt; width: 669px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 20px;
                    background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 20px;
                    background-color: white">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Intimation</span></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 20px;
                    background-color: #f0f0f0">
                    <asp:Label ID="lblsuccess" runat="server" Font-Size="14pt" ForeColor="#00CC33" Visible="False"
                        Width="401px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Name of Insured</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:Label ID="lblnameofInsured" runat="server" Font-Bold="True" Width="418px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 19px; text-align: left">
                    Address of Insured</td>
                <td colspan="3" style="height: 19px; text-align: left">
                    :<asp:Label ID="lblassuredad1" runat="server" Font-Bold="True" Width="428px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblassuredad2" runat="server" Font-Bold="True" Width="428px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Date of Comm.</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:Label ID="lbldtofcomm" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 204px; height: 20px; text-align: left">
                    Civil or Forces</td>
                <td style="width: 249px; height: 20px; text-align: left">
                    :<asp:DropDownList ID="ddlcof" runat="server">
                        <asp:ListItem Value="C">Civil</asp:ListItem>
                        <asp:ListItem Value="A">Army</asp:ListItem>
                        <asp:ListItem Value="N">Navy</asp:ListItem>
                        <asp:ListItem Value="G">Air Force</asp:ListItem>
                        <asp:ListItem Value="P">Police</asp:ListItem>
                        <asp:ListItem Value="B">Buddhist Clergy</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Policy No.</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:Label ID="lblpolno" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 204px; height: 20px; text-align: left">
                    Main Life or <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                        mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Spouse</span></td>
                <td style="width: 249px; height: 20px; text-align: left">
                    :<asp:Label ID="lblmof" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0; text-align: center">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtnameofdd"
                        ErrorMessage="Please Enter The Name of Dead" Display="Dynamic" Font-Bold="False"></asp:RequiredFieldValidator>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Name of Deceased</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtnameofdd" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="505px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtofinfo"
                        ErrorMessage="Please Enter the Date of Intimation" Width="227px" Display="Dynamic" Font-Bold="False"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtdtofinfo" ErrorMessage="Pleasse Enter a Numeric Date of Intimation"
                        Font-Bold="False" Display="Dynamic"></asp:CustomValidator></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 927px; height: 20px; text-align: left">
                    Date of Death</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txtdtofdth" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="8" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 204px; height: 20px; text-align: left">
                    Date of Intimation</td>
                <td style="width: 249px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txtdtofinfo" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" MaxLength="8"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="font-weight: normal; height: 10px; background-color: #f0f0f0; width: 927px;">
                </td>
                <td colspan="2" style="font-weight: normal; height: 10px; background-color: #f0f0f0;
                    text-align: left">
                    &nbsp; YYYYMMDD<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtdtofdth" ErrorMessage="Pleasse Enter a Numeric Date of Death"
                        Font-Bold="False" Display="Dynamic"></asp:CustomValidator></td>
                <td colspan="1" style="font-weight: normal; height: 10px; background-color: #f0f0f0;
                    text-align: left; width: 249px;">
                    &nbsp; YYYYMMDD</td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Policy Status</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:Label ID="lblpolstat" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 204px; height: 20px; text-align: left">
                    Method of Inform</td>
                <td style="width: 249px; height: 20px; text-align: left">
                    :<asp:DropDownList ID="ddlinfometh" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Sum Assured</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:Label ID="lblsumassured" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
                <td style="width: 204px; height: 20px; text-align: left">
                    Table/Term</td>
                <td style="width: 249px; height: 20px; text-align: left">
                    :<asp:Label ID="lbltab" runat="server" Font-Bold="True" Width="50px"></asp:Label>
                    <asp:Label ID="lblterm" runat="server" Font-Bold="True" Width="50px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="margin-bottom: 1px; border-bottom: black thin solid; height: 20px;
                    background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Informers ID</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txtinfoid" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="12"></asp:TextBox></td>
                <td style="width: 204px; height: 20px; text-align: left">
                </td>
                <td style="width: 249px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Informers Name</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtinfoname" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="60" Width="505px" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Informers Relationship</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    :<asp:TextBox ID="txtinforel" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="25" Width="505px" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 19px; text-align: left">
                    Informers Address</td>
                <td colspan="3" style="height: 19px; text-align: left">
                    :<asp:TextBox ID="txtinfoad1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="40" Width="505px" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp;
                    <asp:TextBox ID="txtinfoad2" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="40" Width="505px" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp;
                    <asp:TextBox ID="txtinfoad3" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="40" Width="505px" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 19px; text-align: left">
                </td>
                <td colspan="3" style="height: 19px; text-align: left">
                    &nbsp;
                    <asp:TextBox ID="txtinfoad4" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="40" Width="505px" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr><td style="width: 927px; height: 20px; background-color: #f0f0f0; text-align: left">
            </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                    Informers Tel.</td>
                <td style="width: 168px; height: 20px; text-align: left">
                    :<asp:TextBox ID="txtinfotel" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        MaxLength="10" Font-Size="10pt"></asp:TextBox></td>
                <td colspan="2" style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtinfotel" ErrorMessage="Pleasse Enter a Numeric Telephone No." Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                </td>
                <td style="width: 168px; height: 20px; text-align: left">
                </td>
                <td style="height: 20px; text-align: center" colspan="2">
                    <asp:LinkButton ID="btn2501" runat="server" PostBackUrl="~/form2501.aspx" OnClientClick="cForm1(this.form1)">Form 2501 English</asp:LinkButton>
                    |<asp:LinkButton ID="btn2501sin" runat="server" PostBackUrl="~/form2501Sin.aspx" OnClientClick="cForm2(this.form1)">Form 2501 Sinhala</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom: black 2px solid; height: 10px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0">
                    <asp:CustomValidator ID="cv1" runat="server" Width="407px" Font-Bold="False"></asp:CustomValidator>
                    &nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px">
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Submit" OnClick="btnSubmit_Click"/>
                    <asp:Button ID="btnDel" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnDel_Click" Text="Delete"/>
                    <asp:Button ID="btnreset" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnreset_Click" Text=" Reset "/>&nbsp;<asp:Button ID="btnexit" runat="server"
                            Font-Bold="True" Font-Names="Trebuchet MS" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                            Text="  Exit  " />
                    <asp:Button ID="btnnext" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="  Next  " PostBackUrl="~/dthReg001.aspx"/></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; text-align: left">
                </td>
                <td colspan="2" style="height: 20px; text-align: right">
                    <asp:Label ID="lblInvmsg" runat="server" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt"
                        ForeColor="Red" Text="More investment policies found for this policy holder. "
                        Visible="False"></asp:Label></td>
                <td style="width: 249px; height: 20px; text-align: left">
                    <asp:LinkButton ID="hlInvpol" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                        ForeColor="Red" PostBackUrl="~/Invest_Pol_Display.aspx" OnClientClick="cForm1(this.form1)" Visible="False">View</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 927px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 168px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 204px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 249px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1, width=600,height=500, top=180, left=250"); 
 form1.target='myWin';
 form1.action='Invest_Pol_Display.aspx';
}
</script>
</html>
