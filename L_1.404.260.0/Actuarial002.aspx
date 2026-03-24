<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actuarial002.aspx.cs" Inherits="Actuarial002" %>

<%@ PreviousPageType VirtualPath="~/Actuarial001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .style10
        {
            height: 22px;
            }
        .style11
        {
            height: 42px;
        }
        .style12
        {
            text-align: left;
            width: 189px;
        }
        .style14
        {
            height: 22px;
            text-align: left;
            width: 189px;
        }
        .style15
        {
            width: 195px;
            text-align: left;
        }
        .style17
        {
            width: 195px;
            height: 22px;
            text-align: left;
        }
        .style18
        {
            text-align: left;
        }
        .style19
        {
            width: 134px;
            height: 22px;
            text-align: left;
        }
        .style20
        {
            width: 134px;
            height: 42px;
            text-align: left;
        }
        .style21
        {
            text-align: left;
            width: 154px;
        }
        .style22
        {
            height: 22px;
            text-align: left;
            width: 154px;
        }
        .style23
        {
            height: 42px;
            text-align: left;
            width: 154px;
        }
        .style24
        {
            width: 134px;
            height: 20px;
            text-align: left;
        }
        .style25
        {
            width: 195px;
            height: 20px;
            text-align: left;
        }
        .style26
        {
            height: 20px;
        }
        .style27
        {
            height: 20px;
            text-align: left;
            width: 154px;
        }
        .style28
        {
            height: 20px;
            text-align: left;
            width: 189px;
        }
        .style29
        {
            height: 20px;
            text-align: right;
        }
        .style30
        {
            height: 42px;
            text-align: right;
        }
        .policyDetail
        {
            width:680px;
            border-collapse:collapse;
        }
        .policyDetail td, th
        {
            
            width:170px;
            border:1px solid black;
        }
        .coverDetail
        {
            width:550px;
            border-collapse:collapse;
        }
        .coverDetail td, th
        { 
            border:1px solid black;
        }

        .coverLeft
        {
            width: 425px;
            text-align:left !important;
            padding-left: 10px;
        } 
        .coverRight
        {
            width: 125px;
            text-align:right !important;
            padding-right: 10px;
        } 
        
        .nom 
        {
            border:0px;
            width:680px;
        } 
              
        .nom th, td
        {
            /*width:auto;*/
            border:0px;
            text-align:center;
        }
        .nomNew 
        {
            text-align:left !important;
        } 
        .diplayIntitial{
            display:initial !important;
        }
        .tb1Col1 {
            width:10px;
        }
        .tb1Col2 {
            width:200px;
        }
        .tb1Col3 {
            width:200px;
        }
        .tb1Col4 {
            width:200px;
        }
        .tb1Col5 {
            width:20px;
        }
        .tb1Col6 {
            width:25px;
        }
        .tb2Col1 {
            width:40px;
        }
        .tb2Col2 {
            width:130px;
        }
        .tb3Col3 {
            width:200px;
        }
        .tb3Col4 {
            width:200px;
        }
        .tb5Col5 {
            width:20px;
        }
        .tb6Col6 {
            width:25px;
        }

        .textleft{
            text-align:left !important;
        }

       select {
        color:black !important;
        }
       select:disabled{
           opacity:1 !important;
       }
        input {
            color:black !important;
        }

        .p-0{
            padding :0px;
            text-align:left !important;
        }
        
    </style>

    <style type="text/css" media="print">
.notprint
{
    display:none;
}
.onlyPrint{
    display:block;
}
.pagebreak { page-break-before: always; }

select {
    -webkit-appearance: none;
    -moz-appearance: none;
    text-indent: 1px;
    text-overflow: '';
    border : none;
}
input {
    border: none;
}
</style>
</head>
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
    function test(source, arguments) {

        if (!IsNumeric(arguments.Value))
        { arguments.IsValid = false; }

        else
        { arguments.IsValid = true; }
    }   

    function print_window() {
        window.print();
    }
</script>

<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS">
        <span><span style="font-size: 14pt">
        </span></span></span>
        <table style="font-weight: normal; font-size: 10pt; width: 655px;margin-left:40px; font-family: 'Trebuchet MS';">
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>--%>
            <tr>
                <td colspan="6" style="height: 17px; background-color: #ffffff">
                    <span style="font-weight: bold; font-size: 12pt; font-family: 'Trebuchet MS'"><span
                        style="font-weight: bold; font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span>Re-Insurance Entry</span></td>
            </tr>
            <%--<tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td colspan="6" style="text-align:left">
                   <h3 style="margin-bottom:0px"><b>Death Claim Details</b></h3>
                </td>
            </tr>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style="text-align: left" class="tb1Col2">
                    Claim No.</td>
                <td style="text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblClmNo" runat="server" Width="122px" Text="" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left" class="tb1Col4">
                   </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style=" text-align: left" class="tb1Col2">
                    Policy No.</td>
                <td style=" text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left" class="tb1Col4">
                    </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style=" text-align: left" class="tb1Col2">
                    Plan No.</td>
                <td style=" text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblPlanNo" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style=" text-align: left" class="tb1Col4">
                    </td>
                <td style=" text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    <asp:Label ID="testlbl" runat="server" Font-Bold="True" Width="326px" ForeColor="#FF0033" Visible="False"></asp:Label></td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style=" text-align: left" class="tb1Col2">
                    DOC of the Policy</td>
                <td style="text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblDOC" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style=" text-align: left" class="tb1Col4">
                    </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style="text-align: left" class="tb1Col2">
                    Name of the Deceased/Claimant</td>
                <td style="text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblName" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left" class="tb1Col4">
                    </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style="text-align: left" class="tb1Col2">
                    Gender</td>
                <td style=" text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblGender" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left" class="tb1Col4">
                    </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style="text-align: left" class="tb1Col2">
                    Date of Birth</td>
                <td style="text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblDOB" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left" class="tb1Col4">
                    </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="" class="tb1Col1">
                </td>
                <td style="text-align: left" class="tb1Col2">
                    Claim Type</td>
                <td style="text-align: left" class="tb1Col3">
                    :
                    <asp:Label ID="lblClaimTyp" runat="server"  Width="122px" Text="Death" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left" class="tb1Col4">
                    </td>
                <td style="text-align: left" class="tb1Col5">
                    </td>
                <td style="" class="tb1Col6">
                </td>
            </tr>
        </table>
        <table style="font-weight: normal; font-size: 10pt; width: 655px;margin-left:40px; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="6" style="text-align:left">
                   <h4 style="margin-bottom:0px"><b>Death Claim Infromation:</b></h4>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="coverGrid" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="false"  Width="230px" 
                    OnPageIndexChanging="coverGrid_PageIndexChanging">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="" SortExpression="">
                            <ItemTemplate >
                                
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="40px" CssClass="p-0"/>
                        </asp:TemplateField>
                            <asp:BoundField DataField="CoverName" HeaderText="Payee" ItemStyle-Width="100px" ItemStyle-CssClass="p-0"/>
                            <asp:TemplateField HeaderText="" SortExpression="">
                            <ItemTemplate>
                                :
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="20px"  CssClass="p-0" />
                        </asp:TemplateField>
                            <asp:BoundField DataField="Sumass" HeaderText="Name" ItemStyle-Width="70px" ItemStyle-CssClass="p-0"/>
                        </Columns>
                        
                    </asp:GridView>
                </td>
            </tr>
            <%--<%--<%--<tr>
                <td style=" height: 20px" class="tb2Col1">
                </td>
                <td style=" height: 20px; text-align: left" class="tb2Col2">
                   Basic SA</td>
                <td style=" height: 20px; text-align: left" class="tb2Col3">
                    :
                    <asp:Label ID="lblBasicSum" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="height: 20px; text-align: left" class="tb2Col4">
                   </td>
                <td style=" height: 20px; text-align: left" class="tb2Col5">
                    </td>
                <td style=" height: 20px " class="tb2Col6">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <%--<tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   FPU SA</td>
                <td style=" height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblFPUSum" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <%--<tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                  SJ SA</td>
                <td style=" height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblSJSum" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <%--<tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   ADB SA</td>
                <td style=" height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblADBSum" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <%--<tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   Spouse SA</td>
                <td style=" height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblSpuseSum" runat="server"  Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <%--<tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   CIC SA</td>
                <td style=" height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblCICSum" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>--%>
        </table>
        <table style="font-weight: normal; font-size: 10pt; width: 655px;margin-left:40px; font-family: 'Trebuchet MS';">
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 20px;">
                    </td>
            </tr>--%>
            <tr>
                <td style="width:10px;">
                </td>
                <td style="width:285px;text-align: left">
                   Policy Status</td>
                <td style="text-align: left">
                    :
                    <asp:Label ID="lblPolstatus" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left">
                   </td>
                <td style="text-align: left">
                    </td>
                <td style="">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="">
                </td>
                <td style="text-align: left">
                   Life Type of Deceased/Claimant</td>
                <td style="text-align: left">
                    :
                    <asp:Label ID="lifType" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left">
                   </td>
                <td style="text-align: left">
                    </td>
                <td style="">
                </td>
            </tr>
           <%-- <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="">
                </td>
                <td style="text-align: left">
                  Date of Death/Disability/CIC</td>
                <td style="text-align: left">
                    :
                    <asp:Label ID="lblDOD" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left">
                   </td>
                <td style="text-align: left">
                    </td>
                <td style="">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="">
                </td>
                <td style="text-align: left">
                   Caused of Death/Disability/Type of CIC Illness</td>
                <td style=" height: 20px; text-align: left">
                    :
                    <asp:Label ID="lblCauseofDeath" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left">
                   </td>
                <td style="text-align: left">
                    </td>
                <td style="">
                </td>
            </tr>
        </table>
        <table style="font-weight: normal; font-size: 10pt; width: 655px;margin-left:40px; font-family: 'Trebuchet MS';">
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td colspan="6" style="text-align:left">
                   <h4 style="margin-bottom:0px"><b>Email Details</b></h4>
                </td>
            </tr>
            <tr>
                <td style="width:10px;">
                </td>
                <td style="width:150px;text-align: left">
                   Sent Date/Time</td>
                <td style="text-align: left">
                    :
                    <asp:Label ID="lblEmailSentAt" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left">
                   </td>
                <td style="text-align: left">
                    </td>
                <td style="">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style="">
                </td>
                <td style="text-align: left">
                   Sent By</td>
                <td style="text-align: left">
                    :
                    <asp:Label ID="lblEmailSentBy" runat="server" Width="122px" CssClass="diplayIntitial"></asp:Label></td>
                <td style="text-align: left">
                   </td>
                <td style="text-align: left">
                    </td>
                <td style="">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
        </table>
        <table style="font-weight: normal; font-size: 10pt; width: 655px;margin-left:40px; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="6" style="text-align:left">
                   <h4 style="margin-bottom:0px"><b>Re-Insurance Details Entry</b></h4>
                </td>
            </tr>
            <%--<tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px;">
                </td>
                <td style="width: 165px; text-align: left; height: 21px;">
                    <span><strong>ReInsurance Availability</strong></span></td>
                <td style="text-align: left; height: 21px;" colspan="2">
                    <span><span style="font-size: 12pt"><strong></strong></span><asp:DropDownList ID="ddlAvailbility" runat="server" Font-Names="Trebuchet MS" Width="113px" Font-Size="10pt">
                             <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:DropDownList></span></td>
            </tr>--%>
            <tr>
                <td style="width:10px; height: 20px">
                </td>
                <td style="width:180px; height: 20px; text-align: left">
                   ReInsurance Availability</td>
                <td style=" height: 20px; text-align: left">
                    <asp:DropDownList ID="ddlAvailbility" runat="server" Font-Names="Trebuchet MS" Width="113px" Font-Size="10pt">
                            <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                             <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="availabiltyRequired" InitialValue="-1" ErrorMessage="Please select availability" ControlToValidate="ddlAvailbility"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 20px; text-align: left">
                    
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width:10px; height: 20px">
                </td>
                <td style="width:180px; height: 20px; text-align: left">
                   Re-Insurance Person No</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtRePerNO" runat="server" Width="87px" MaxLength="8"  ></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRePerNO"
                        ErrorMessage="Please Fill the Person No" Font-Size="10pt" Width="181px" Font-Bold="False" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtRePerNO" ErrorMessage="Please Give a Numeric Value"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
             <%--<tr>
                <td colspan="6" style="height: 20px;"">
                    </td>
            </tr>--%>
        </table>
       <%-- <div class="pagebreak"></div>--%>
        <table style="font-weight: normal; font-size: 10pt; width: 655px;margin-left:40px; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="8" style="text-align:left">
                   <h4 style="margin-bottom:0px"><b>Re-Insurance Share</b></h4>
                </td>
            </tr>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   &nbsp;</td>
                <td style=" height: 20px; text-align: left">
                    Treaty Portion
                </td>
                <td style="height: 20px; text-align: left">
                   
                   </td>
                <td style=" height: 20px; text-align: left">
                    Fac Portion
                </td>
                <td style="height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   Basic</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrBasic" runat="server" Width="87px" MaxLength="8"  AutoPostBack="true" OnTextChanged="txtShrBasic_TextChanged"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrBasic" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrBasicFac" runat="server" Width="87px" MaxLength="8"  AutoPostBack="true" OnTextChanged="txtShrBasicFac_TextChanged"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator14" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrBasicFac" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   FPU</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrFPU" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrFPU_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrFPU" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrFPUFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrFPUFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator15" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrFPUFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   SJ</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrSJ" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrSJ_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrSJ" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrSJFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrSJFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator16" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrSJFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
           <%-- <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   ADB</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrADB" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrADB_TextChanged" AutoPostBack="true"></asp:TextBox>
                   
                </td>
                <td style="height: 20px; text-align: left">
                     <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrADB" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrADBFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrADBFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                   
                </td>
                <td style="height: 20px; text-align: left">
                     <asp:CustomValidator ID="CustomValidator17" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrADBFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   Spouse</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrSpouse" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrSpouse_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator6" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrSpouse" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrSpouseFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrSpouseFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator18" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrSpouseFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   CI</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrCIC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrCIC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator7" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrCIC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrCICFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrCICFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator19" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrCICFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   TPD(A)</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrTPDA" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrTPDA_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator8" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrTPDA" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrTPDAFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrTPDAFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator20" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrTPDAFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   TPD(S)</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrTPDS" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrTPDS_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator9" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrTPDS" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrTPDSFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrTPDSFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator21" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrTPDSFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   PPDB</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrPPDB" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrPPDB_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator11" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrPPDB" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtShrPPDBFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtShrPPDBFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator22" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtShrPPDBFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   WOP (A)</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtshrwopa" runat="server" Width="87px" MaxLength="8" OnTextChanged="txtshrwopa_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator12" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtshrwopa" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtshrwopaFAC" runat="server" Width="87px" MaxLength="8" OnTextChanged="txtshrwopaFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator23" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtshrwopaFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   WOP (S)</td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtshrwops" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtshrwops_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator13" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtshrwops" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtshrwopsFAC" runat="server" Width="87px" MaxLength="8"  OnTextChanged="txtshrwopsFAC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator24" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtshrwopsFAC" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   <b>Total</b></td>
                <td style=" height: 20px; text-align: left">
                    <asp:TextBox ID="txtshrTot" runat="server" Width="87px" MaxLength="8" ></asp:TextBox>
                    
                </td>
                <td style="height: 20px; text-align: left">
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtshrTot" ErrorMessage="Please Give a Valid Amount"
                        Font-Bold="False" Font-Size="10pt" Width="225px" Display="Dynamic"></asp:CustomValidator>
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   Re-Insurer</td>
                <td style=" height: 20px; text-align: left">
                    <asp:DropDownList ID="ddlInsure" runat="server" Font-Names="Trebuchet MS" Width="113px" Font-Size="10pt">
                             <asp:ListItem Text="MUNICH" Value="MUNICH"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>
            <tr>
                <td style=" height: 20px">
                </td>
                <td style=" height: 20px; text-align: left">
                   Treaty/Facultative</td>
                <td style=" height: 20px; text-align: left">
                    
                    <asp:DropDownList ID="ddlfac" runat="server" Font-Names="Trebuchet MS" Width="113px" Font-Size="10pt">
                             <asp:ListItem Text="Treaty" Value="Treaty"></asp:ListItem>
                            <asp:ListItem Text="Facultative" Value="Facultative"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 20px; text-align: left">
                   </td>
                <td style=" height: 20px; text-align: left">
                    </td>
                <td style=" height: 20px">
                </td>
            </tr>
            <%--<tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                    </td>
            </tr>--%>

            
    </table>
          <table class="notprint" style="font-weight: normal; font-size: 10pt; width: 655px; font-family: 'Trebuchet MS';">
          <tr>
                <td style="height: 10px" colspan="6">
                    <asp:Table ID="Table1" runat="server" Width="710px" Font-Names="Trebuchet MS" Font-Size="10pt">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px">
                    <asp:Button ID="btnregister" runat="server" Text="--Submit--" OnClick="btnregister_Click" Font-Bold="False" class="notprint" Font-Names="Trebuchet MS" Width="109px" PostBackUrl="~/Actuarial002.aspx"/>
                    <input id="Button1" style="font-weight: bold;
                    width: 76px" title="Print" type="button" value="Print" onclick="return print_window();" class="notprint" /> 
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 20px; background-color: #f0f0f0">
                    &nbsp;&nbsp;
                </td>
                <td style=" height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; background-color: #ffffff" colspan="5">
                    <asp:Label ID="lblsucess" runat="server" ForeColor="LimeGreen" BackColor="#d1e7dd" Text="Re-Insurance Successfully Registered"
                        Visible="False" Width="406px"></asp:Label>
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="#ff0000" BackColor="#ffa6a6" Text=""
                        Visible="False" Width="406px"></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td style=" height: 20px; background-color: #f0f0f0">
                </td>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                    <asp:Label ID="lblsucess" runat="server" ForeColor="LimeGreen" BackColor="#d1e7dd" Text="Re-Insurance Successfully Registered"
                        Visible="False" Width="406px"></asp:Label>
                     <asp:Label ID="lblErr" runat="server" ForeColor="#842029" BackColor="#f8d7da" Text=""
                        Visible="False" Width="406px"></asp:Label>
                </td>
                <td style=" height: 20px; background-color: #f0f0f0">
                </td>
            </tr>--%>
        </table>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">


</script>

</html>

