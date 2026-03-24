<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBPaymemtMemo002.aspx.cs" Inherits="ADBPaymemtMemo002" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
    <style type="text/css">
        .style1
        {
            height: 18px;
            width: 445px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span></strong>
        <table style="font-weight: normal; font-size: 10pt; width: 681px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #ffffff">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt"><strong>Death Claim ADB Payments</strong></span></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" 
                    style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Red"
                        Visible="False" Width="492px"></asp:Label></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                    Policy Number</td>
                <td style="width: 410px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                    colspan="2">
                </td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                    Claim No.</td>
                <td style="width: 410px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblClaimNo" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                    colspan="2">
                </td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                    Life Type</td>
                <td style="width: 410px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lbllifetype" runat="server" Width="168px"></asp:Label></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                    colspan="2">
                </td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                    Cause of Death</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblcauseOfDeath" runat="server" Width="375px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                    colspan="2">
                </td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                    Decision</td>
                <td style="width: 410px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtdecision" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        MaxLength="200" TextMode="MultiLine" Width="401px" ForeColor="#FF3333" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                    colspan="2">
                </td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                     Accidental Death Benefit Amount</td>
                <td style="height: 18px; text-align: left" colspan="2">
                    <asp:TextBox ID="txtADBAmt" runat="server" MaxLength="12" Font-Bold="True" ></asp:TextBox>
                     <asp:CheckBox ID="chkadbOnEx" runat="server" Text="ADB on Exgracia" /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" 
                    style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtADBAmt" ErrorMessage="Please Enter a Numeric Value for ADB" Font-Bold="False"></asp:CustomValidator></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1">
                    </td>
                <td style="text-align: left" class="style1">
                     </td>
                <td style="width: 410px; height: 18px; text-align: left">
                     </td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
             <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                     colspan="2">
                <asp:Label ID="lblDeduction" runat="server" Width="142px" Text="Deductions" Font-Bold="true"></asp:Label></td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>     
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1">
                    </td>
                <td style="text-align: left" class="style1">
                     <strong style="margin-left:40px">Description</strong> </td>
                <td style="width: 410px; height: 18px; text-align: left">
                     <strong style="margin-left:40px">Amount</strong></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr> 
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1">
                    <asp:CheckBox ID="chkDeduct1" runat="server" 
                        oncheckedchanged="chkDeduct1_CheckedChanged" AutoPostBack="true" />
                    </td>
                <td style="text-align: left" class="style1">
                    <asp:TextBox ID="txtOtherdeductDes1" Width="150px" runat="server" 
                        MaxLength="100" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Enabled="false"></asp:TextBox></td>
                <td style="width: 410px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtotherdeductAmt1" runat="server" MaxLength="12" Font-Bold="False" Font-Names="Trebuchet MS" Enabled="false" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" 
                    style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                runat="server" ControlToValidate="txtotherdeductAmt1" ErrorMessage="Please Enter the Amount"
                                Font-Bold="False" Font-Size="10pt" Width="209px"></asp:RequiredFieldValidator>--%></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px">
                </td>
                <td style="text-align: left" class="style1">
                   <asp:CheckBox ID="chkDeduct2" runat="server" 
                        oncheckedchanged="chkDeduct2_CheckedChanged"  AutoPostBack="true" /> </td>
                <td style="text-align: left" class="style1">
                    <asp:TextBox ID="txtOtherdeductDes2" Width="150px" runat="server" 
                        MaxLength="12" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" Enabled="false" ></asp:TextBox></td>
                <td style="width: 410px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtotherdeductAmt2" runat="server" MaxLength="100" Font-Bold="False" Font-Names="Trebuchet MS" Enabled="false" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 15px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" 
                    style="height: 18px; background-color: #f0f0f0; text-align: center">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server" ControlToValidate="txtOtherdeductDes2" ErrorMessage="Please Enter the Amount"
                                Font-Bold="False" Font-Size="10pt" Width="209px"></asp:RequiredFieldValidator>--%></td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
                
            <tr>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
                <td style="text-align: left" class="style1" colspan="2">
                    Minutes</td>
                <td style="width: 410px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtminutes" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        MaxLength="500" TextMode="MultiLine" Width="401px"></asp:TextBox></td>
                <td style="width: 190px; height: 18px; text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0;">
                </td>
                <td style="height: 18px; background-color: #f0f0f0;" colspan="3">
                     </td>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0;">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px">
                    <asp:Button ID="btnok" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnok_Click" Text="   OK   " />
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Text="Cancel ADB" onclick="btnCancel_Click"/>
                    <asp:Button ID="btnReopen" runat="server" Font-Bold="True" Visible="false" Font-Names="Trebuchet MS"
                        Text="Reopen ADB" onclick="btnReopen_Click"/>
                    <asp:Button ID="btnExit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                        Text="  Exit  " /></td>
            </tr>
            <tr>
                <td style="width: 14px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; text-align: left" class="style1" 
                    colspan="2">
                </td>
                <td style="width: 410px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 15px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
