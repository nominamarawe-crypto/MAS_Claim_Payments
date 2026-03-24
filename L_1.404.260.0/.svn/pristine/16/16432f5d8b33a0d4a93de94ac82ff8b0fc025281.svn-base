<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lnStatClmSetdet010.aspx.cs" Inherits="lnStatClmSetdet010" %>

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
                <table style="font-size: 12pt; width: 555px; font-family: 'Trebuchet MS'">
                    <tr>
                        <td colspan="4" style="height: 21px; background-color: #f0f0f0">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 21px; background-color: #ffffff">
                            <span style="font-size: 14pt">Sri Lanka Insurance<br />
                            </span><span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong>Monthly Branchwise Claim Settlement Details</strong></span></span></td>
                    </tr>
                    <tr>
                        <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 126px; height: 21px; text-align: left">
                            <span style="font-size: 10pt"><strong style="font-weight: normal">From Date</strong></span></td>
                        <td style="font-size: 12pt; height: 21px; text-align: left" colspan="2">
                            <span style="font-weight: normal"><strong></strong><asp:TextBox ID="txtfromdate" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt" Width="117px"></asp:TextBox><span
                                style="font-size: 10pt">YYYYMMDD<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfromdate"
                                ErrorMessage="Please Give the From Date" Font-Bold="False" Font-Size="10pt" Width="175px" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cv1" runat="server" ClientValidationFunction="test" ControlToValidate="txtfromdate"
                                ErrorMessage="Please Give a Numeric From Date" Font-Bold="False" Font-Size="10pt"
                                Width="219px" Display="Dynamic"></asp:CustomValidator></span></span></td>
                    </tr>
                    <tr style="font-size: 12pt">
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                        </td>
                        <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 126px; height: 21px; text-align: left">
                            <span style="font-size: 10pt"><strong style="font-weight: normal">To Date</strong></span></td>
                        <td style="font-size: 12pt; height: 21px; text-align: left" colspan="2">
                            <span style="font-weight: normal"><strong></strong><asp:TextBox ID="txttodate" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt" Width="117px"></asp:TextBox><span
                                style="font-size: 10pt">YYYYMMDD<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttodate"
                                ErrorMessage="Please Give the To Date" Font-Bold="False" Font-Size="10pt" Width="175px" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                                ControlToValidate="txttodate" ErrorMessage="Please Give a To Date" Font-Bold="False"
                                Font-Size="10pt" Width="219px" Display="Dynamic"></asp:CustomValidator></span></span></td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                        </td>
                        <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 126px; height: 21px; text-align: left">
                            <span style="font-size: 10pt"><strong style="font-weight: normal">Branch</strong></span></td>
                        <td style="font-size: 12pt; width: 220px; height: 21px; text-align: left">
                            <span><strong></strong><asp:TextBox ID="txtbrn" runat="server" MaxLength="4" Font-Names="Trebuchet MS" Font-Size="10pt" Width="117px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbrn"
                                ErrorMessage="Please Give the Branch" Font-Bold="False" Font-Size="10pt" Width="157px" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cv2" runat="server" ClientValidationFunction="test" ControlToValidate="txtbrn"
                                ErrorMessage="Please Give a Numeric Branch" Font-Bold="False" Font-Size="10pt"
                                Width="203px" Display="Dynamic"></asp:CustomValidator></span></td>
                        <td style="font-size: 12pt; width: 79px; height: 21px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 21px; background-color: whitesmoke">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px">
                        </td>
                        <td style="width: 126px; height: 21px; text-align: left">
                        </td>
                        <td style="font-size: 12pt; width: 220px; height: 21px; text-align: left">
                            <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                                OnClick="btnsubmit_Click" PostBackUrl="~/lnStatClmSetdet.aspx" Text="--Submit--" Font-Size="10pt" Width="98px" />
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                                NavigateUrl="~/Home.aspx"><--Back</asp:HyperLink></td>
                        <td style="font-size: 12pt; width: 79px; height: 21px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 57px; height: 21px; background-color: #f0f0f0">
                        </td>
                        <td colspan="3" style="height: 21px; background-color: #f0f0f0; text-align: left">
                            &nbsp;</td>
                    </tr>
                </table>
            </strong></span></span>
    
    </div>
    </form>
</body>
</html>
