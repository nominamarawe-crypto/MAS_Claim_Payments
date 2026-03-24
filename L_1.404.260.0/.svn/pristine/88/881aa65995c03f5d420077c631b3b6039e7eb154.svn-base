<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentForm.aspx.cs" Inherits="PaymentForm" %>
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

        .flex{
            display: -webkit-box; /* wkhtmltopdf uses this one */
            display: flex;
        }
        .flexend{
            -webkit-box-pack: end; /* wkhtmltopdf uses this one */
            justify-content: flex-end;
        }

        /* The container */
.conta {
  display: block;
  position: relative;
  padding-left: 35px;
  margin-bottom: 12px;
  cursor: pointer;
  font-size: 22px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default checkbox */
.conta input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
  height: 0;
  width: 0;
}

/* Create a custom checkbox */
.checkmark {
  position: absolute;
  top: -5px;
  left: 0;
  height: 20px;
  width: 20px;
  background-color: white;
  border:1px solid;
}

/* On mouse-over, add a grey background color */
.conta:hover input ~ .checkmark {
  background-color: white;
}

/* When the checkbox is checked, add a blue background */
.conta input:checked ~ .checkmark {
  background-color: white;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

/* Show the checkmark when checked */
.conta input:checked ~ .checkmark:after {
  display: block;
}

/* Style the checkmark/indicator */
.conta .checkmark:after {
  left: 6px;
  top: 3px;
  width: 5px;
  height: 10px;
  border: solid black;
  border-width: 0 3px 3px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
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
        <table style="font-weight: normal; font-size: 10pt; width: 1000px;font-family: 'Trebuchet MS'; padding:25px;">
            
            <tr>
                <td colspan="6" style="height: 17px; background-color: #ffffff">
                    <span style="font-weight: bold; font-size: 12pt; font-family: 'Trebuchet MS'"><span
                        style="font-weight: bold; font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span>Re-Insurance Payment Form</span></td>
            </tr>
            <tr style="border-bottom:1px solid black !important;">
                <td colspan="6">
                    <hr />
                </td>
            </tr>
            
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left">
                    <strong>Life Reinsurance Claim Advice No.</strong>
                     &nbsp;&nbsp;&nbsp;&nbsp;
                     <input type="text" style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/>
                </td>
            </tr>
            <%--<tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>--%>
            <tr style="border-bottom:1px solid black !important;">
                <td colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
           <tr>
                 <td colspan="6" style="text-align:left;display:flex" class="flex">
                    <div style="width:80px;"><strong >Ceding Co. :</strong></div>
                     <div style="width:30px">

                     </div>
                     <div style="width:850px">
                         <input type="text" value="Sri Lanka Insurance Corporation Life Ltd" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important"/>
                     </div>
                     
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex" class="flex">
                    <div style="width:80px;"><strong >Name :</strong></div>
                     <div style="width:30px">

                     </div>
                     <div style="width:850px">
                         <input type="text" value="" id="txtNameofDeath" runat="server" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important"/>
                     </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;justify-content:flex-end" class="flex flexend">
                    <div style="width:80px;"><strong >Currency :</strong></div>
                     <div style="width:20px">

                     </div>
                     <div style="width:200px">
                         <input type="text" value="LKR" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important"/>
                     </div>
                </td>
            </tr>
            <%--<tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>--%>
           <tr style="border-bottom:1px solid black !important;">
                <td colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" checked="checked">
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:200px">
                         We wish to advise you of the
                     </div>
                     <div style="width:20px">
                         
                     </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:60px">
                         
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" checked="checked">
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:200px">
                         death
                     </div>
                     <div style="width:20px">
                         
                     </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:60px">
                         
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:200px">
                         disability claim
                     </div>
                     <div style="width:200px">
                         
                     </div>
                     <div style="width:200px">
                         of the above insured
                     </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:500px">
                        Untill you hear from us further, please treat this claim as pending
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:920px">
                        We refer to our Claim Advice No &nbsp;&nbsp;<input type="text" style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/> &nbsp;&nbsp;dated &nbsp;&nbsp;<input type="text" style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/>&nbsp;&nbsp; and wish to supply you with further details.
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" checked="checked">
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:920px">
                        We completed/commenced claim settlement on &nbsp;&nbsp;<input type="text" id="txtSettlementon" runat="server" style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/> &nbsp;&nbsp;by paying the sum of &nbsp;&nbsp;<input type="text" id="txtPaySum" runat="server" value="Rs." style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/>&nbsp;&nbsp; and now request you
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:60px">
                        
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" checked="checked">
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:860px">
                        to credit us with your share in/after the  &nbsp;&nbsp;<input type="text" id="txtQuater" runat="server" style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/> &nbsp;&nbsp;quarter &nbsp;&nbsp;<input type="text" id="txtQYear" runat="server" value="" style="border-top:0px !important;border-left:0px !important;border-right:0px !important"/>
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:60px">
                        
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:860px">
                        to pay us your share in cash in accordance with the terms of our Agreement.
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:920px">
                       We have refused payment of the claim and our refusal has been accepted/rejected.
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                    <div style="width:60px;">
                        
                    </div>
                     <div style="width:200px">
                       Date of death
                     </div>
                     <div style="width:700px">
                         <input type="text" id="txtDateofDeath" runat="server" style="border-top:0px !important;border-left:0px !important;border-right:0px !important;width:100%"/> 
                     </div>
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                    <div style="width:60px;">
                        
                    </div>
                     <div style="width:200px">
                       Cause of death / disability
                     </div>
                     <div style="width:700px">
                         <input type="text" id="txtCauseofDeath" runat="server" style="border-top:0px !important;border-left:0px !important;border-right:0px !important;width:100%"/> 
                     </div>
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <%--<tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                    <table border="1" style="width:100%;border-spacing:0px;">
                      <tr>
                        <td rowspan="2" >Series/Cession No.</td>
                        <td rowspan="2" >Policy No.</td>
                        <td colspan="3" id="colspancolumn" runat="server" style="text-align:left;height:30px;">&nbsp;&nbsp;Amounts payable by MR</td>
                      </tr>
                      <tr>
                          <td style="height:30px;" id="basiccol" runat="server">Sum at Risk Life</td>
                          <td style="height:30px;" id="fpuCol" runat="server">FPU Benefit</td>
                          <td style="height:30px;" id="sjcol" runat="server">SJ Benefit</td>
                          <td style="height:30px;" id="adbcol" runat="server">ADB Benefit</td>
                          <td style="height:30px;" id="spousecol" runat="server">Spouse Benefit</td>
                          <td style="height:30px;" id="ciccol" runat="server">CIC Benefit</td>
                          <td style="height:30px;" id="tpdacol" runat="server">TPD(A) Benefit</td>
                          <td style="height:30px;" id="tpdscol" runat="server">TPD(S) Benefit</td>
                          <td style="height:30px;" id="ppdbcol" runat="server">PPDB Benefit</td>
                          <td style="height:30px;" id="wopacol" runat="server">WOP(A) Benefit</td>
                          <td style="height:30px;" id="wopscol" runat="server">WOP(S) Benefit</td>
                      </tr>
                      <tr>
                        <td style="height:45px;"><label id="lblSerialNo" runat="server"></label></td>
                        <td style="height:45px;"><label id="lblPolno" runat="server"></label></td>
                        <td style="height:45px;" id="basiccolval" runat="server"><label id="lblbasic" runat="server"></label></td>
                        <td style="height:45px;" id="fpuColval" runat="server"><label id="lblfpu" runat="server"></label></td>
                        <td style="height:45px;" id="sjcolval" runat="server"><label id="lblsj" runat="server"></label></td>
                        <td style="height:45px;" id="adbcolval" runat="server"><label id="lbladb" runat="server"></label></td>
                        <td style="height:45px;" id="spousecolval" runat="server"><label id="lblspouse" runat="server"></label></td>
                        <td style="height:45px;" id="ciccolval" runat="server"><label id="lblcic" runat="server"></label></td>
                        <td style="height:45px;" id="tpdacolval" runat="server"><label id="lbltpda" runat="server"></label></td>
                        <td style="height:45px;" id="tpdscolval" runat="server"><label id="lbltpds" runat="server"></label></td>
                        <td style="height:45px;" id="ppdbcolval" runat="server"><label id="lblppdb" runat="server"></label></td>
                        <td style="height:45px;" id="wopacolval" runat="server"><label id="lblwopa" runat="server"></label></td>
                        <td style="height:45px;" id="wopscolval" runat="server"><label id="lblwops" runat="server"></label></td>
                      </tr>
                      </table>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                    
                     <div style="width:300px">
                       The following claim papers are attached
                     </div>
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:100px">
                       
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:820px">
                       Death certificate
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:100px">
                       
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:820px">
                       Medical of official certificate of cause of death / disability
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:100px">
                       
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:820px">
                       Claimant Statement's Form
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:100px">
                       
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:820px">
                       Payment Voucher
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex;" class="flex">
                     <div style="width:100px">
                       
                     </div>
                    <div style="width:40px;">
                        <label class="conta">
                          <input type="checkbox" >
                          <span class="checkmark"></span>
                        </label>
                    </div>
                     <div style="width:820px">
                       Letter of Admission
                     </div>
                     
                    
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex" class="flex"> 
                    <div style="width:80px;"><strong >Remarks :</strong></div>
                     <div style="width:30px">

                     </div>
                     <div style="width:850px">
                         <input type="text" value="" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important"/>
                     </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex" class="flex">
                    <div style="width:200px;">
                        <input type="text" value="Colombo" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important;text-align:center"/>

                    </div>
                     <div style="width:180px;">

                     </div>
                      <div style="width:200px;">
                        <input type="text" id="txtDate" runat="server" value="" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important;text-align:center"/>

                    </div>
                     <div style="width:180px;">

                     </div>
                      <div style="width:200px;">
                        <input type="text" value="" style="width:100%;border-top:0px !important;border-left:0px !important;border-right:0px !important"/>

                    </div>
                </td>
            </tr>
            <tr>
                 <td colspan="6" style="text-align:left;display:flex" class="flex">
                    <div style="width:200px;text-align:center">
                        Place

                    </div>
                     <div style="width:180px;">

                     </div>
                      <div style="width:200px;text-align:center">
                        Date

                    </div>
                     <div style="width:180px;">

                     </div>
                      <div style="width:200px;text-align:center">
                        Signature

                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">


</script>

</html>



