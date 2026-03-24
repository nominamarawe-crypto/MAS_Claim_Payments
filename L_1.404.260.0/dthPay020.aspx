<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthPay020.aspx.cs" Inherits="dthPay020" %>
<%@ PreviousPageType VirtualPath="~/dthPay001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
   
  <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
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
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span></strong>
        <table style="font-weight: normal; font-size: 10pt; width: 681px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="4" style="height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 18px; background-color: #ffffff">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt"><strong>Death Claim Payments</strong></span></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Red"
                        Visible="False" Width="492px"></asp:Label></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Policy Number</td>
                <td style="width: 459px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 149px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 459px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Life Type</td>
                <td style="width: 459px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbllifetype" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 149px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 459px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Cause of Death</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblcauseOfDeath" runat="server" Width="441px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 149px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 459px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 65px;">
                </td>
                <td style="width: 149px; text-align: left; height: 65px;" valign="top">
                    Decision</td>
                <td align="left" style="vertical-align: top; width: 459px; text-align: left; height: 65px;"
                    valign="top">
                    <asp:TextBox ID="txtdecision" runat="server" Height="56px" MaxLength="500" TextMode="MultiLine"
                        Width="451px" ForeColor="#FF3333" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
                <td style="width: 15px; height: 65px;">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 149px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 459px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lblsumassPVal" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtsumPVL" runat="server" MaxLength="12" Font-Bold="True" ></asp:TextBox>
                    <asp:CheckBox ID="chksumOnExg" runat="server" Text="Sum Assured on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtsumPVL" ErrorMessage="Please Enter a Numeric Value for Sum Assured/PVL" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lbladb" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtadb" runat="server" MaxLength="12" Font-Bold="True"></asp:TextBox>
                    <asp:CheckBox ID="chkADBpaylater" runat="server" Text="Pay Later" />
                    <asp:CheckBox ID="chkadbOnEx" runat="server" Text="ADB on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="Label1" runat="server" Text="Please Enter the Liable Amount"></asp:Label><asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtadb" ErrorMessage="Please Enter a Numeric Value for ADB" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lblfpu" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtfpu" runat="server" MaxLength="12" Font-Bold="True"></asp:TextBox>
                    <asp:CheckBox ID="chkfpuOnExg" runat="server" Text="FPU on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtfpu" ErrorMessage="Please Enter a Numeric Value for FPU" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lblfe" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtfe" runat="server" MaxLength="12" Font-Bold="True"></asp:TextBox>
                    <asp:CheckBox ID="chkFEpayearly" runat="server" Text="Pay Earlier" />&nbsp;<asp:CheckBox ID="chkFeOnExg" runat="server" Text="Funeral Expences on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: left">
                    <asp:Label ID="Label2" runat="server" Text="Please Enter the Liable Amount"></asp:Label>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtfe" ErrorMessage="Please Enter a Numeric Value for Funeral Expences" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
           <%-- <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lblSJGross" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtSJGrossAmt" runat="server" MaxLength="12" Font-Bold="True"></asp:TextBox>
                    </td>
            </tr>--%>
            <%--<tr>
                <td style="width: 14px; height: 18px"> 
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lblSJPaid" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtSJPaidAmt" runat="server" MaxLength="12" Font-Bold="True" AutoPostBack="true"
                        ontextchanged="txtSJPaidAmt_TextChanged"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="linkSJPaid" runat="server" onclick="linkSJPaid_Click" >View SJ Paid Amount</asp:LinkButton>
                    
                    </td>
            </tr>--%>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    <asp:Label ID="lblsj" runat="server" Width="142px"></asp:Label></td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtsj" runat="server" MaxLength="12" Font-Bold="True"></asp:TextBox>
                    <asp:CheckBox ID="chkSjonExg" runat="server" Text="Swarna Jayanthi on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtsj" ErrorMessage="Please Enter a Numeric Value for Swarna Jayanthi" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Loan Capital</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtLoan" runat="server" MaxLength="12" Font-Bold="False" ReadOnly="True" Font-Names="Trebuchet MS" Font-Size="10pt" Width="126px">0.0</asp:TextBox>
                    Interest
                    <asp:TextBox ID="txtLoanint" runat="server" Font-Bold="False" MaxLength="12" ReadOnly="True" Font-Names="Trebuchet MS" Font-Size="10pt" Width="122px">0.0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td colspan="3" style="height: 18px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:CustomValidator ID="CustomValidator14"
                        runat="server" ClientValidationFunction="test" ControlToValidate="txtLoan" ErrorMessage="Please Enter a Numeric Value for Loan Capital"
                        Font-Bold="False"></asp:CustomValidator>&nbsp; &nbsp;
                    <asp:CustomValidator ID="CustomValidator13" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtLoanint" ErrorMessage="Please Enter a Numeric Value for Loan Interest"
                        Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Other Additions</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    <asp:TextBox ID="txtotheradd" runat="server" Font-Bold="False" MaxLength="12" Font-Names="Trebuchet MS" Font-Size="10pt" Width="126px">0.0</asp:TextBox>
                    <asp:CheckBox ID="chkotheraddOnExg" runat="server" Text="Other Additions  on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator7" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtotheradd" ErrorMessage="Please Enter a Numeric Value for Other Additions"
                        Font-Bold="False"></asp:CustomValidator>&nbsp;</td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Other Deductions</td>
                <td style="width: 459px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtotherdeduct" runat="server" MaxLength="12" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt">0.0</asp:TextBox></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator6" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtotherdeduct" ErrorMessage="Please Enter a Numeric Value for Other Deductions" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Refund of Premiums</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtrefofPrems" runat="server" MaxLength="12" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt">0.0</asp:TextBox>
                    <asp:CheckBox ID="chkrefpremonExg" runat="server" Text="Refund of Premniums on Exgracia" Width="252px" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator8" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtrefofPrems" ErrorMessage="Please Enter a Numeric Value for Premium Refunds" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Refund of Deposit</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtRefofdep" runat="server" Font-Bold="False" MaxLength="12" ReadOnly="True" Font-Names="Trebuchet MS" Font-Size="10pt">0.0</asp:TextBox>
                    <asp:CheckBox ID="chkRefdep" runat="server" Text="Refund Deposit" Width="200px" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator12" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtRefofdep" ErrorMessage="Please Enter a Numeric Value for Premium Refunds"
                        Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Total Bonus</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtvestedbons" runat="server" MaxLength="12" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt">0.0</asp:TextBox>
                    Vested
                    <asp:TextBox ID="txtinterimbons" runat="server" Font-Bold="False" MaxLength="12" Font-Names="Trebuchet MS" Font-Size="10pt">0.0</asp:TextBox>
                    <asp:Literal ID="litintbon" runat="server" Text="Interim"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator9" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtvestedbons" ErrorMessage="Please Enter a Numeric Value for Vested Bonus" Font-Bold="False"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator11" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtinterimbons" ErrorMessage="Please Enter a Numeric Value for Interim Bonus" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Amt. Pol. Com. Year</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:CheckBox ID="chkPolcomyr" runat="server" Text="Yes" Width="200px" Checked="True" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator15" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtrefofPrems" ErrorMessage="Please Enter a Numeric Value for Premium Refunds"
                        Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Paid Stage Payments</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:CheckBox ID="chkStage1" runat="server" Text="1st Stage Paid" Width="116px" Checked="True" Enabled="False" />
                    <asp:CheckBox ID="chkStage2" runat="server" Text="2nd Stage Paid" Width="124px" Checked="True" Enabled="False" />
                    <asp:CheckBox ID="ChkStage3" runat="server" Text="3rd Stage Paid" Width="124px" Checked="True" Enabled="False" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Stage Payment Deductable Amount</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:CheckBox ID="deductStage1" runat="server" Text="1st Stage Amount" Width="116px" Checked="True" Enabled="True" />
                    <asp:CheckBox ID="deductStage2" runat="server" Text="2nd Stage Amount" Width="124px" Checked="True" Enabled="True" />
                    <asp:CheckBox ID="deductStage3" runat="server" Text="3rd Stage Amount" Width="124px" Checked="True" Enabled="True" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="width: 149px; height: 18px; text-align: left">
                    Amt. for Age Difference</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:DropDownList ID="ddlagediff" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt">
                        <asp:ListItem Value="N">Age OK</asp:ListItem>
                        <asp:ListItem Value="O">Age Overstated</asp:ListItem>
                        <asp:ListItem Value="Y">Age Understated</asp:ListItem>
                    </asp:DropDownList>
                    Amount<asp:TextBox ID="txtagediffamt" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" MaxLength="12">0.0</asp:TextBox>Interest<asp:TextBox ID="txtagediffamtInt" runat="server" Font-Bold="False" MaxLength="12" Font-Names="Trebuchet MS" Font-Size="10pt">0.0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtagediffamt" ErrorMessage="Please Enter a Numeric Value for Age Difference" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 37px">
                </td>
                <td style="width: 149px; height: 37px; text-align: left">
                    Existing Demmands</td>
                <td rowspan="" style="vertical-align: middle; height: 37px; text-align: center; width: 459px;" align="center" valign="middle">
                    <asp:Table ID="Table1" runat="server" Height="10px" Width="352px">
                    </asp:Table>
                </td>
                <td style="width: 15px; height: 37px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 149px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 459px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
                <td style="width: 190px; height: 18px; text-align: left">
                    Minutes</td>
                <td style="width: 459px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtminutes" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        MaxLength="200" TextMode="MultiLine" Width="401px"></asp:TextBox></td>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
            </tr>
            <%--<tr id="pnlHavePayment" runat="server">
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
                <td style="width: 190px; height: 18px; text-align: left" colspan="2">
                    <asp:Label ID="lblhasPayWarr" runat="server"></asp:Label></td>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
            </tr>--%>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="2">
                    <asp:CustomValidator ID="cv" runat="server" Width="327px" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 18px">
                    <asp:Button ID="btnok" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnok_Click" Text="   OK   " />
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Submit" PostBackUrl="~/dthPay002.aspx" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnExit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                        Text="  Exit  " /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 149px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 459px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr >
                <td colspan="4">
                    <asp:Table ID="Table2" runat="server" Height="10px" Width="352px">
                    </asp:Table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
