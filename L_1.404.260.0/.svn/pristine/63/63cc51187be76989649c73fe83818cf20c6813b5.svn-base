<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReInsuranceInq002.aspx.cs" Inherits="ReInsuranceInq002" %>
<%@ PreviousPageType VirtualPath="~/ReInsuranceInq001.aspx"%>
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
            /*border:0px;*/
            width:680px;
        } 
              
        .nom th, td
        {
            /*width:auto;*/
            /*border:0px;*/
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

    </style>
    <style type="text/css">
        .onlyPrint{
            display:none;
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
        <table style="font-weight: normal; font-size: 10pt; width: 1000px;font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="6" style="height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px; background-color: #ffffff">
                    <span style="font-weight: bold; font-size: 12pt; font-family: 'Trebuchet MS'"><span
                        style="font-weight: bold; font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span>Re-Insurance Inquiry</span></td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            
            
            <tr>
                 <td colspan="6">
                    <asp:GridView ID="inqGrid" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" BorderColor="Black" BorderWidth="2px" Width="100%" 
                    OnPageIndexChanging="inqGrid_PageIndexChanging">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ClaimNo" HeaderText="Claim No" />
                            <asp:BoundField DataField="PolNo" HeaderText="Policy Number" />
                            <asp:BoundField DataField="EmailSentDate" HeaderText="Email Sent Date" />
                            <asp:BoundField DataField="Stage" HeaderText="Re-Insurance Stage" />
                            <asp:BoundField DataField="Filled" HeaderText="Actuarial Filled" />
                            <asp:BoundField DataField="FilledDate" HeaderText="Actuarial Filled Date" />
                            <asp:BoundField DataField="PaymentSentDate" HeaderText="Payment Details Send Date" />
                            <asp:BoundField DataField="Availability" HeaderText="Re-Insurance Availability" />
                           <%-- <asp:BoundField DataField="ShrDetails" HeaderText="Re-Insurance Share Details" />--%>
                            <asp:HyperLinkField DataTextField="ShrDetails" HeaderText="Share Details" HeaderStyle-CssClass="notprint" ItemStyle-CssClass="notprint"/>
                            <asp:HyperLinkField DataTextField="Link" HeaderText="" HeaderStyle-CssClass="notprint" ItemStyle-CssClass="notprint"/>
                            <asp:HyperLinkField DataTextField="ADBLink" HeaderText="" HeaderStyle-CssClass="notprint" ItemStyle-CssClass="notprint"/>
                            
                        </Columns>
                       <%-- <HeaderStyle BackColor="" Font-Bold="True" ForeColor="#E7E7FF" />--%>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:right">
                    <input id="Button1" style="font-weight: bold;
                    width: 76px" title="Print" type="button" value="Print" onclick="return print_window();" class="notprint" />
                </td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">


</script>

</html>


