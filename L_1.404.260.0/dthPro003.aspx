<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthPro003.aspx.cs" Inherits="dthPro003" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/dthPro002.aspx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    <link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
    <script src="JavaScript/CalendarControl.js"  language="javascript" type="text/javascript"/>
    <script type="text/javascript">
        
     function test(source, arguments)
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
<style type="text/css">
        .style1
        {
            height: 18px;
            width: 137px;
        }
        .style2
        {
            height: 20px;
            width: 137px;
        }
        .style3
        {
            height: 21px;
            width: 137px;
        }
        .style4
        {
            height: 3px;
            width: 137px;
        }
    </style>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong>
        </strong></span>
        <table style="font-weight: normal; font-size: 10pt; width: 681px; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 18px; background-color: #ffffff">
                    <strong>
                    <span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Processing</span></strong></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0; text-align: center" colspan="2">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Fuchsia"
                        Visible="False" Width="492px"></asp:Label></td>
                <td style="width: 15px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 148px; height: 18px; text-align: left">
                    Policy Number</td>
                <td style="width: 190px; height: 18px; text-align: left">
                    <asp:Label ID="lblpolno" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 148px; height: 18px; text-align: left">
                    Status</td>
                <td style="width: 190px; height: 18px; text-align: left">
                    <asp:Label ID="lblpolstat" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 148px; height: 18px; text-align: left">
                    Life Type</td>
                <td style="width: 190px; height: 18px; text-align: left">
                    <asp:Label ID="lbllifetype" runat="server" Width="168px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 148px; height: 18px; text-align: left">
                    Cause of Death</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="DCAUSE" DataValueField="DSERIAL" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Width="209px" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 148px; height: 20px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 190px; height: 20px; background-color: #f0f0f0; text-align: left">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand='SELECT "DCAUSE", "DSERIAL" FROM "LPHS"."DCAUSEOFDTH"'>
                    </asp:SqlDataSource>
                </td>
                <td style="width: 15px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 148px; height: 18px; text-align: left">
                    Cause of Death</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    <asp:TextBox ID="txtcauseStr" runat="server" MaxLength="100" Width="421px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
               <td rowspan="1" style="width: 14px; height: 21px">
                </td>
                <td rowspan="1" style="width: 148px; height: 21px; text-align: left" valign="top">
                    Decision Date</td>
                <td align="left" rowspan="1" style="vertical-align: top; text-align: left" 
                    valign="top" class="style3">                   
                    <span><strong><span style="font-size: 12pt"></span></strong><asp:TextBox ID="txtDecisonDate" runat="server" MaxLength="8" Width="113px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="17px" ImageUrl="~/Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('txtDecisonDate'));" Width="16px" />(YYYYMMDD)<asp:Label 
                        ID="lbldate" runat="server" Text=""></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDecisonDate"
                        ErrorMessage="Please Give the Date of Death Claim" Font-Bold="False" Font-Size="10pt"
                        Width="219px" Display="Dynamic" ValidationGroup="Date"></asp:RequiredFieldValidator>
                         
                        </span></td>
                <td rowspan="1" style="width: 15px; height: 21px">
                </td>           
            </tr>

            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
               <td rowspan="1" style="width: 14px; height: 21px">
                </td>
                <td rowspan="1" style="width: 148px; height: 21px; text-align: left" valign="top">
                    ADB Decision Date</td>
                <td align="left" rowspan="1" style="vertical-align: top; text-align: left" 
                    valign="top" class="style3">                   
                    <span><strong><span style="font-size: 12pt"></span></strong><asp:TextBox ID="txtADBDecisonDate" runat="server" MaxLength="8" Width="113px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="17px" ImageUrl="~/Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('txtADBDecisonDate'));" Width="16px" />(YYYYMMDD)
                        <asp:Label ID="lblADBDate" runat="server" Text=""></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtADBDecisonDate"
                        ErrorMessage="Please Give the Date of Death Claim" Font-Bold="False" Font-Size="10pt"
                        Width="219px" Display="Dynamic" ValidationGroup="Date"></asp:RequiredFieldValidator>
                         
                        </span></td>
                <td rowspan="1" style="width: 15px; height: 21px">
                </td>           
            </tr>

            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 21px;">
                </td>
                <td style="width: 148px; text-align: left; height: 21px;" valign="top">
                    Decision</td>
                <td align="left" style="vertical-align: top; width: 190px; text-align: left; height: 21px;"
                    valign="top">
                    <asp:TextBox ID="txtdecision" runat="server" Height="55px" MaxLength="1000" TextMode="MultiLine"
                        Width="421px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 15px; height: 21px;">
                </td>
            </tr>
            <%-- <tr>
                <td rowspan="1" style="height: 21px; background-color: ghostwhite;" colspan="4">
                </td>
            </tr>
           <tr>
                <td rowspan="1" style="width: 14px; height: 21px">
                </td>
                <td rowspan="1" style="width: 148px; height: 21px; text-align: left" valign="top">
                    Swarna Jayanthi Last Paid date</td>
                <td align="left" rowspan="1" style="vertical-align: top; width: 190px; height: 21px;
                    text-align: left" valign="top">
                    <asp:TextBox ID="txtSjdate" runat="server"></asp:TextBox></td>
                <td rowspan="1" style="width: 15px; height: 21px">
                </td>
            </tr>--%>
            <tr>
                <td style="height: 18px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 3px;">
                </td>
                 <%--//yyyy commented--%>
                <td style="width: 148px; text-align: left; height: 3px;" valign="top">
                    Existing Demmands <%--<td rowspan="3" style="width: 148px; text-align: left; height: 3px;" valign="top">
                    Existing Demmands--%></td>
                <td align="left" rowspan="3" style="vertical-align: top; width: 190px; text-align: left; height: 3px;"
                    valign="top">
                    <asp:Table ID="Table1" runat="server" Height="2px" Width="336px" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:Table>
                </td>
                <td rowspan="3" style="width: 15px; height: 3px;">
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td rowspan="1" style="width: 14px; height: 20px;">
                </td>
                <td rowspan="1" style="width: 148px; text-align: left; height: 20px;" valign="top">
                </td>
                <td align="left" rowspan="1" style="vertical-align: top; text-align: left; height: 20px;"
                    valign="top" colspan="2">
                    <asp:CustomValidator ID="cv" runat="server" Width="327px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 19px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="height: 17px" colspan="4">
                    <asp:Button ID="btnok" runat="server" OnClick="btnok_Click" Text="--OK--" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Width="77px" />
                    &nbsp;<asp:Button
                        ID="btnnext" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Next--" Font-Size="10pt" Width="86px" OnClick="btnnext_Click" />&nbsp;
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/repudiation001.aspx" Font-Names="Trebuchet MS" Font-Size="10pt"><<--Back To Repudiaton</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
