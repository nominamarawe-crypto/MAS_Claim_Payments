<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ibslRep001.aspx.cs" Inherits="ibslRep001" %>

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
    
     function test2(source, arguments)
    {
    	    	
     if (!IsNumeric02(arguments.Value))
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
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt"><span style="font-size: 12pt">
        </span>
        </span>
            <table style="font-weight: normal; font-size: 10pt; width: 549px; font-family: 'Trebuchet MS';
                background-color: #f0f0f0">
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px; background-color: #ffffff">
                        <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                        </span>
            <span style="font-size: 12pt"><strong>
            IBSL Reports</strong></span></td>
                </tr>
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td style="width: 21px; height: 21px;">
                    </td>
                    <td style="width: 125px; text-align: left; height: 21px;">
                        From Date</td>
                    <td style="width: 220px; text-align: left; height: 21px;">
                        <asp:TextBox ID="txtfromdate" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate" ErrorMessage="?"
                            Font-Bold="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1"
                                runat="server" ClientValidationFunction="test" ControlToValidate="txtfromdate"
                                ErrorMessage="?" Display="Dynamic"></asp:CustomValidator>YYYYMMDD</td>
                    <td style="font-size: 12pt; width: 20px; height: 21px;">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 21px; height: 21px">
                    </td>
                    <td style="width: 125px; height: 21px; text-align: left">
                        <span style="font-size: 10pt">To Date</span></td>
                    <td style="width: 220px; height: 21px; text-align: left">
                        <asp:TextBox ID="txttodate" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate" ErrorMessage="?"
                            Font-Bold="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator2"
                                runat="server" ClientValidationFunction="test" ControlToValidate="txttodate"
                                ErrorMessage="?" Display="Dynamic"></asp:CustomValidator><span style="font-size: 10pt">YYYYMMDD</span></td>
                    <td style="width: 20px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 21px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 125px; height: 21px; background-color: #f0f0f0; text-align: left">
                        Branch</td>
                    <td style="height: 21px; background-color: #f0f0f0; text-align: left" colspan="2">
                        <asp:DropDownList ID="ddlbrnall" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbrnall_SelectedIndexChanged" Width="84px" Font-Names="Trebuchet MS" Font-Size="10pt">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="1">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlbrn" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                            DataTextField="BRNAM" DataValueField="BRCOD" Enabled="False" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 21px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 125px; height: 21px; background-color: #f0f0f0; text-align: left">
                        Branch Code</td>
                    <td style="width: 220px; height: 21px; background-color: #f0f0f0; text-align: left">
                        <asp:TextBox ID="txtbrcode" runat="server" MaxLength="3" Font-Names="Trebuchet MS" Font-Size="10pt" Width="77px">0</asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbrcode" ErrorMessage="?"
                            Font-Bold="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator3"
                                runat="server" ClientValidationFunction="test" ControlToValidate="txtbrcode"
                                ErrorMessage="?" Display="Dynamic"></asp:CustomValidator></td>
                    <td style="width: 20px; height: 21px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td style="width: 21px; height: 21px;">
                    </td>
                    <td style="width: 125px; text-align: left; font-weight: normal; height: 21px;">
                        Civil or Forces</td>
                    <td style="width: 220px; text-align: left; height: 21px;">
                        <asp:DropDownList ID="ddlcof" runat="server" Width="84px" Font-Names="Trebuchet MS" Font-Size="10pt">
                            <asp:ListItem Value="*">All</asp:ListItem>
                            <asp:ListItem Value="C">Civil</asp:ListItem>
                            <asp:ListItem Value="A">Army</asp:ListItem>
                            <asp:ListItem Value="N">Navy</asp:ListItem>
                            <asp:ListItem Value="G">Air Force</asp:ListItem>
                            <asp:ListItem Value="P">Police</asp:ListItem>
                            <asp:ListItem Value="B">Buddhist Clergy</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 20px; height: 21px;">
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td style="width: 21px; height: 21px;">
                    </td>
                    <td style="width: 125px; text-align: left; font-weight: normal; height: 21px;">
                        Policy Status</td>
                    <td style="width: 220px; text-align: left; height: 21px;"><asp:DropDownList ID="ddliol" runat="server" Width="85px" Font-Names="Trebuchet MS" Font-Size="10pt">
                        <asp:ListItem Value="*">All</asp:ListItem>
                        <asp:ListItem Value="I">Inforce</asp:ListItem>
                        <asp:ListItem Value="L">Lapse</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="width: 20px; height: 21px;">
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td style="width: 21px; height: 21px;">
                    </td>
                    <td style="width: 125px; text-align: left; font-weight: normal; height: 21px;">
                        Cause of Death</td>
                    <td style="text-align: left; height: 21px;" colspan="2"><asp:DropDownList ID="ddlcauseall" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcauseall_SelectedIndexChanged" Width="84px" Font-Names="Trebuchet MS" Font-Size="10pt">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Select</asp:ListItem>
                    </asp:DropDownList>
                        <asp:DropDownList ID="ddlcause" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                            DataTextField="DCAUSE" DataValueField="DSERIAL" Enabled="False" Font-Names="Trebuchet MS" Font-Size="10pt" >
                            <asp:ListItem Value="*">All</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 21px; height: 21px;">
                    </td>
                    <td style="width: 125px; text-align: left; height: 21px;">
                        Criteria</td>
                    <td style="width: 220px; text-align: left; height: 21px;">
                        <asp:DropDownList ID="ddlcriteria" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt" >
                            <asp:ListItem Value="1">Death Claims Recieved</asp:ListItem>
                            <asp:ListItem Value="2">Death Claims Paid</asp:ListItem>
                            <asp:ListItem Value="3">Death Claims Outstanding</asp:ListItem>
                            <asp:ListItem Value="4">Death Claims Rejected</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 20px; height: 21px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 21px; height: 21px">
                    </td>
                    <td style="width: 125px; height: 21px; text-align: left">
                    </td>
                    <td style="width: 220px; height: 21px; text-align: left">
                        <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                            OnClick="btnsubmit_Click" PostBackUrl="~/ibslRep002.aspx" Text="--Submit--" Width="98px" Font-Size="10pt" />
                        &nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                            NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                    <td style="width: 20px; height: 21px">
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td style="width: 21px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="height: 21px; background-color: #f0f0f0; text-align: left" colspan="2">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand='SELECT "DCAUSE", "DSERIAL" FROM "LPHS"."DCAUSEOFDTH"'>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT BRCOD, BRNAM  FROM   GENPAY.BRANCH order by brnam">
                        </asp:SqlDataSource>
                    </td>
                    <td style="width: 20px; height: 21px; background-color: #f0f0f0">
                    </td>
                </tr>
            </table>
            </span>
    
    </div>
    </form>
</body>
</html>
