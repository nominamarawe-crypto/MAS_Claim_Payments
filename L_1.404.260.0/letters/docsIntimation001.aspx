<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="docsIntimation001.aspx.cs" Inherits="docsIntimation001" %>
<%@ Reference Page="~/dthreq002.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
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
        <br />
        <table style="font-size: 10pt; width: 543px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px">
                    <strong><span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Intimation Stage Documents</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 64px;">
                </td>
                <td style="width: 198px; text-align: left; height: 64px;">
                    <span>Policy Number</span></td>
                <td style="font-size: 10pt; text-align: left; height: 64px;" colspan="2">
                    <span><strong><span style="font-size: 12pt"> </span></strong>
                        <asp:TextBox ID="txtpolno" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt" Width="117px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpolno"
                        ErrorMessage="Please Give the Policy Number" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Width="197px" Display="Dynamic"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtpolno" ErrorMessage="Please Give a Numeric Policy Number"
                        Font-Bold="False" Font-Size="10pt" Width="239px" Display="Dynamic"></asp:CustomValidator></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 198px; height: 21px; text-align: left">
                    <span>Main Life or Spouse</span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span><span style="font-size: 12pt"><strong> </strong></span>
                        <asp:DropDownList ID="ddlMOS" runat="server" AutoPostBack="True" Font-Names="Trebuchet MS" Font-Size="10pt" Width="129px">
                        </asp:DropDownList></span></td>
                <td style="width: 102px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="4" style="height: 21px; background-color: whitesmoke">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 198px; height: 21px; text-align: left">
                </td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" Text="--Submit--" Font-Size="10pt" />
                    <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink></td>
                <td style="width: 102px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: #f0f0f0" colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td style="width: 102px">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 198px; height: 22px; background-color: #f0f0f0">
                    <strong>English</strong></td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: center">
                    <strong>Sinhala</strong></td>
                <td style="width: 102px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                    </td>
                <td style="width: 198px; height: 22px; background-color: #f0f0f0; text-align: center;">
                    <asp:HyperLink ID="HP_CallPOLNO" runat="server" NavigateUrl="~/docsCallPolnoEng001.aspx">Call Policy Number (Civil)</asp:HyperLink></td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: center">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/letters/docsCallPolnoSin001.aspx">Call Policy Number(Civil)</asp:HyperLink></td>
                <td style="width: 102px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                    <strong></strong></td>
                <td style="width: 198px; height: 22px; background-color: #f0f0f0">
                    <asp:HyperLink ID="HyperLink1" runat="server" Visible="False">Call Policy Number (Army)</asp:HyperLink></td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: center">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/letters/docsCallPolnoArmySin001.aspx">Call Policy Number(Army)</asp:HyperLink></td>
                <td style="width: 102px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 198px; height: 22px; background-color: #f0f0f0">
                </td>
                <td style="width: 220px; height: 22px; background-color: #f0f0f0; text-align: right">
                    </td>
                <td style="width: 102px; height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
