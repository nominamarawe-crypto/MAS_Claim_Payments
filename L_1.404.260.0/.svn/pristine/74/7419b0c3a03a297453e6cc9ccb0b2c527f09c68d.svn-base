<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lnStatClmSetsum010.aspx.cs" Inherits="lnStatClmSetsum010" %>

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
        <strong><span style="font-size: 14pt; font-family: Trebuchet MS">
        </span></strong><span style="font-size: 12pt"><span style="font-family: Trebuchet MS">
            <strong>
                <table style="font-weight: bold; font-size: 12pt; width: 603px; font-family: Trebuchet MS">
                    <tr>
                        <td colspan="4" style="height: 21px; background-color: #f0f0f0">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 21px; background-color: #ffffff">
                            <span style="font-size: 14pt">Sri Lanka Insurance<br />
                            </span><span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong>Monthly Branchwise Claim Settlements Summary</strong></span></span></td>
                    </tr>
                    <tr>
                        <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 224px; height: 21px; text-align: left">
                            <span style="font-size: 10pt; font-weight: normal;">From Date</span></td>
                        <td style="font-size: 12pt; height: 21px; text-align: left" colspan="2">
                            <span>
                                <asp:TextBox ID="txtfromdate" runat="server" MaxLength="8" Width="115px"></asp:TextBox>
                            <asp:CustomValidator ID="cv1" runat="server" ClientValidationFunction="test" ControlToValidate="txtfromdate"
                                ErrorMessage="Please Give a Numeric From Date" Font-Size="10pt" Width="211px" Display="Dynamic" Font-Bold="False"></asp:CustomValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfromdate"
                                ErrorMessage="Please Give the From Date" Font-Bold="False" Font-Size="10pt" Width="195px" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0; text-align: left;">
                            </td>
                        <td colspan="2" style="font-weight: normal; height: 21px; background-color: #f0f0f0;
                            text-align: left">
                            <span style="font-size: 10pt">YYYYMMDD</span></td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 224px; height: 21px; text-align: left">
                            <span style="font-size: 10pt; font-weight: normal;">To Date</span></td>
                        <td style="font-size: 12pt; height: 21px; text-align: left" colspan="2">
                            <span>
                                <asp:TextBox ID="txttodate" runat="server" MaxLength="8" Width="115px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                                ControlToValidate="txttodate" ErrorMessage="Please Give a Numeric To Date" Font-Size="10pt"
                                Width="211px" Display="Dynamic" Font-Bold="False"></asp:CustomValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                                ErrorMessage="Please Give the To Date" Font-Bold="False" Font-Size="10pt" Width="195px" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td colspan="2" style="height: 21px; background-color: whitesmoke">
                        </td>
                        <td colspan="2" style="font-size: 12pt; height: 21px; background-color: whitesmoke;
                            text-align: left">
                            <span style="font-weight: normal; font-size: 10pt">YYYYMMDD</span></td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 224px; height: 21px; text-align: left">
                        </td>
                        <td colspan="2" style="font-size: 12pt; height: 21px; text-align: left">
                            <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                                OnClick="btnsubmit_Click" PostBackUrl="~/lnStatClmSetsum.aspx" Text="--Submit--" Width="100px" />
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                                NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                        </td>
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0; text-align: left;">
                            </td>
                        <td colspan="2" style="font-weight: normal; height: 21px; background-color: #f0f0f0;
                            text-align: left">
                            <span style="font-size: 10pt"></span></td>
                    </tr>
                </table>
            </strong></span></span>
    
    </div>
    </form>
</body>
</html>
