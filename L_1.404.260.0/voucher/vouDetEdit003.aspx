<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vouDetEdit003.aspx.cs" Inherits="vouDetEdit003" %>
<%@ PreviousPageType VirtualPath="~/voucher/vouDetEdit002.aspx"%>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - Death Claims</title>
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
        <table style="font-weight: bold; font-size: 10pt; width: 685px; font-family: 'Trebuchet MS'">
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 21px; background-color: #f0f0f0">
                </td>
                <td colspan="2" rowspan="1" style="background-color: #f0f0f0; height: 21px;">
                    &nbsp;</td>
                <td style="font-size: 10pt; width: 20px; height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 18px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Voucher Details Edit</span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                        <asp:Label ID="lblsuccess" runat="server" Font-Size="10pt" ForeColor="#00CC33" Text="Updates Successfull"
                            Visible="False" Width="409px"></asp:Label></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                </td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                </td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    Policy Number</td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    Life</td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblmos" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    Claim No.</td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    :
                    <asp:Label ID="lblclaimno" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">Insured Name</span></td>
                <td style="font-size: 10pt; width: 378px; height: 18px; text-align: left">
                    <span style="font-size: 11pt">: </span>
                    <asp:Label ID="lblphname" runat="server" Font-Bold="True" Font-Size="10pt" Width="348px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 21px">
                </td>
                <td style="width: 179px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">Net Claim &nbsp;Amount</span></td>
                <td style="width: 378px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">: </span>
                    <asp:Label ID="lblnetamt" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="width: 20px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; border-bottom: black thin solid; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; border-bottom: black thin solid; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; border-bottom: black thin solid; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; border-bottom: black thin solid; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px">
                </td>
                <td style="width: 179px; text-align: left">
                    <span style="font-size: 10pt">Payee Name</span></td>
                <td style="width: 378px; text-align: left">
                    <span style="font-size: 10pt">: &nbsp;</span><asp:TextBox ID="txtpayeename" runat="server" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpayeename"
                        ErrorMessage="Please Enter Payee Name" Font-Bold="True" Font-Size="10pt"></asp:RequiredFieldValidator></td>
                <td style="width: 20px; color: #000000; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt; color: #000000">
                <td style="width: 21px; height: 21px">
                </td>
                <td style="width: 179px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">Receipient Name</span></td>
                <td style="width: 378px; height: 21px; text-align: left">
                    :
                    <asp:TextBox ID="txtNamewithins" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Width="307px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Change" /></td>
                <td style="font-weight: bold; width: 20px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; color: #000000">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt; color: #000000">
                <td style="width: 21px; height: 21px">
                </td>
                <td style="width: 179px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">Address</span></td>
                <td style="width: 378px; height: 21px; text-align: left">
                    <span>:&nbsp; </span>
                    <asp:TextBox ID="txtad1" runat="server" MaxLength="50" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="font-weight: bold; width: 20px; height: 21px">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt;">
                <td style="width: 21px; height: 19px">
                </td>
                <td style="width: 179px; height: 19px; text-align: left">
                </td>
                <td style="width: 378px; height: 19px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtad2" runat="server" MaxLength="50" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 20px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px">
                </td>
                <td style="width: 179px; text-align: left">
                </td>
                <td style="width: 378px; text-align: left">
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtad3" runat="server" MaxLength="50" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px">
                </td>
                <td style="width: 179px; text-align: left">
                </td>
                <td style="width: 378px; text-align: left">
                    &nbsp; &nbsp;
                    <asp:TextBox ID="txtad4" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        MaxLength="50" Width="307px"></asp:TextBox></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="border-bottom: black thin solid; height: 20px">
                    <span style="font-size: 11pt">Voucher Details</span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">Bank Name</span></td>
                <td style="width: 378px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">: &nbsp;</span><asp:TextBox ID="txtbkname" runat="server" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 18px">
                </td>
                <td style="width: 179px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">Branch Name</span></td>
                <td style="width: 378px; height: 18px; text-align: left">
                    <span style="font-size: 10pt">:&nbsp; </span>
                    <asp:TextBox ID="txtbkbrnname" runat="server" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 17px">
                </td>
                <td style="width: 180px; height: 17px; text-align: left">
                    <span style="font-size: 10pt">Customer's Account No.</span></td>
                <td style="width: 378px; height: 17px; text-align: left">
                    : &nbsp;<asp:TextBox ID="txtcustAcct" runat="server" Width="307px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox></td>
                <td style="width: 20px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 180px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 17px">
                </td>
                <td style="width: 179px; height: 17px; text-align: left">
                    <span style="font-size: 10pt">Choose SLI Account Number</span></td>
                <td style="width: 378px; height: 17px; text-align: left">
                    :&nbsp;
                    <asp:DropDownList ID="ddlslicacctno" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt" Width="122px">
                    </asp:DropDownList></td>
                <td style="width: 20px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 179px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 378px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 18px">
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnSubmit_Click" Text="--Submit--" Font-Size="10pt" />
                    <asp:Button ID="btnexit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnexit_Click" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                        Text="--Exit--" Width="84px" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/voucher/vouPrintMain.aspx"><<--Back</asp:HyperLink></td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 18px; background-color: #f0f0f0; text-align: right">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 21px">
                </td>
                <td style="width: 179px">
                </td>
                <td style="width: 378px">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
        </table>
    
    <br />
    
    </div>
    </form>
</body>
</html>
