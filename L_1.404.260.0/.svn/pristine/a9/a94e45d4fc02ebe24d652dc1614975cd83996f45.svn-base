<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cvouDetEdit002.aspx.cs" Inherits="cvouDetEdit002" %>
<%@ Reference Page ="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sri Lanka Insurance - New Loans</title>
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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Child Protection Annual Payment Voucher Details Edit<table style="font-size: 10pt;
            width: 637px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 27px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="2" rowspan="2" style="background-color: #f0f0f0">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="LimeGreen"
                        Text="VOUCHER CREATED" Visible="False" Width="270px"></asp:Label>
                    <br />
                    <asp:Label ID="lblvouno" runat="server" Font-Bold="True" ForeColor="#3300FF" Width="124px"></asp:Label></td>
                <td style="font-size: 10pt; width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 27px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 27px; height: 18px">
                </td>
                <td style="width: 213px; height: 18px; text-align: left">
                    <strong>Policy Number</strong></td>
                <td style="font-size: 12pt; width: 403px; height: 18px; text-align: left">
                    <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Font-Size="10pt" Width="130px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 403px; height: 18px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 18px">
                </td>
                <td style="width: 213px; height: 18px; text-align: left">
                    <strong><span style="font-size: 10pt">Insured Name</span></strong></td>
                <td style="font-size: 12pt; width: 403px; height: 18px; text-align: left">
                    <asp:Label ID="lblphname" runat="server" Font-Bold="True" Font-Size="10pt" Width="306px"></asp:Label></td>
                <td style="font-size: 12pt; width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 403px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt; color: #000000">
                <td style="width: 27px; height: 21px">
                </td>
                <td style="width: 213px; height: 21px; text-align: left">
                    <strong><span style="font-size: 10pt">Net Claim Amount</span></strong></td>
                <td style="width: 403px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtnetClmAmt" runat="server" MaxLength="12"></asp:TextBox></td>
                <td style="width: 20px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; border-bottom: black thin solid; height: 17px; background-color: #f0f0f0">
                </td>
                <td colspan="2" style="border-bottom: black thin solid; height: 17px; background-color: #f0f0f0;
                    text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnetSurrAmt"
                        ErrorMessage="Please Enter Surrender Amount" Font-Bold="True" Font-Size="10pt"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtnetSurrAmt" ErrorMessage="Please Enter a Numeric Surrender Amount"
                        Font-Bold="True" Font-Size="10pt"></asp:CustomValidator></td>
                <td style="width: 20px; border-bottom: black thin solid; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px">
                </td>
                <td style="width: 213px; text-align: left">
                    <strong><span style="font-size: 10pt">Payee Name</span></strong></td>
                <td style="width: 403px; text-align: left">
                    <asp:TextBox ID="txtpayeename" runat="server" MaxLength="65" Width="307px"></asp:TextBox></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 17px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 403px; height: 17px; background-color: #f0f0f0; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpayeename"
                        ErrorMessage="Please Enter Payee Name" Font-Bold="True" Font-Size="10pt"></asp:RequiredFieldValidator></td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 27px; height: 21px">
                </td>
                <td style="width: 213px; height: 21px; text-align: left">
                    <strong>Address</strong></td>
                <td style="width: 403px; height: 21px; text-align: left">
                    <asp:TextBox ID="txtad1" runat="server" MaxLength="50" Width="307px"></asp:TextBox></td>
                <td style="width: 20px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 27px; height: 19px">
                </td>
                <td style="width: 213px; height: 19px; text-align: left">
                </td>
                <td style="width: 403px; height: 19px; text-align: left">
                    <asp:TextBox ID="txtad2" runat="server" MaxLength="50" Width="307px"></asp:TextBox></td>
                <td style="width: 20px; height: 19px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 403px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="border-bottom: black thin solid; height: 20px">
                    <strong><span style="font-size: 10pt">Voucher Details</span></strong></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 403px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 18px">
                </td>
                <td style="width: 213px; height: 18px; text-align: left">
                    <strong><span style="font-size: 10pt">Bank Name</span></strong></td>
                <td style="width: 403px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtbkname" runat="server" MaxLength="30" Width="307px"></asp:TextBox></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 403px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 18px">
                </td>
                <td style="width: 213px; height: 18px; text-align: left">
                    <strong><span style="font-size: 10pt">Branch Name</span></strong></td>
                <td style="width: 403px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtbkbrnname" runat="server" MaxLength="20" Width="307px"></asp:TextBox></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 403px; height: 17px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 17px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 17px">
                </td>
                <td style="width: 213px; height: 17px; text-align: left">
                    <strong><span style="font-size: 10pt">Choose SLI Account Number</span></strong></td>
                <td style="width: 403px; height: 17px; text-align: left">
                    <asp:DropDownList ID="ddlslicacctno" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 20px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="width: 27px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 403px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 27px; height: 18px">
                </td>
                <td style="width: 213px; height: 18px; text-align: left">
                    <strong><span style="font-size: 10pt">Customer's Account No.</span></strong></td>
                <td style="width: 403px; height: 18px; text-align: left">
                    <strong>
                        <asp:TextBox ID="txtcustAcct" runat="server" MaxLength="20" Width="307px"></asp:TextBox></strong></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 213px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 403px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 18px">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        OnClick="btnSubmit_Click" Text="Submit" /><asp:Button ID="btnexit" runat="server" Font-Bold="True"
                            Font-Names="Trebuchet MS" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                            Text="  Exit  " />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 18px; background-color: #f0f0f0">
                    </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 27px">
                </td>
                <td style="width: 213px">
                </td>
                <td style="width: 403px">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
        </table>
        </span></strong>
        <br />
    
    </div>
    </form>
</body>
</html>
