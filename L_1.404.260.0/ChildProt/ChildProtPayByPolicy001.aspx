<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildProtPayByPolicy001.aspx.cs" Inherits="ChildProt_ChildProtPayByPolicy001" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	
     if (!IsNumeric(arguments.Value))
               {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
  function MM_goToURL() 
  { //v3.0
    var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
    for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
  }
        
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-weight: bold; font-size: 12pt; width: 603px; font-family: Trebuchet MS;
            text-align: center">
            <tr>
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td colspan="2" style="text-align: center">
                    <span style="font-size: 14pt">Sri Lanka Insurance<br />
                    </span>Child Protect Payments</td>
                <td style="font-size: 12pt; width: 79px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px">
                </td>
                <td style="width: 171px; text-align: left">
                    <span style="font-size: 10pt">Policy Number</span></td>
                <td colspan="2" style="text-align: left">
                    <span>
                        <asp:TextBox ID="txtpolno" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                            MaxLength="8" Width="103px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server" ControlToValidate="txtpolno" ErrorMessage="Please Give the Policy Number"
                                Font-Bold="False" Font-Size="10pt" Width="209px"></asp:RequiredFieldValidator><asp:CustomValidator
                                    ID="CustomValidator1" runat="server" ClientValidationFunction="test" ControlToValidate="txtpolno"
                                    ErrorMessage="Please Give a Numeric Policy Number" Font-Bold="False" Font-Size="10pt"
                                    Width="249px"></asp:CustomValidator></span></td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 171px; height: 21px; text-align: left">
                    <span style="font-size: 10pt">Main Life or Spouse</span></td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <span style="font-size: 12pt">
                        <asp:DropDownList ID="ddlMOS" runat="server" Enabled="False" Font-Names="Trebuchet MS"
                            Font-Size="10pt" Width="108px">
                        </asp:DropDownList></span></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 57px; height: 21px">
                </td>
                <td style="width: 171px; height: 21px; text-align: left">
                </td>
                <td style="width: 220px; height: 21px; text-align: left">
                    <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnsubmit_Click" Text="--Submit--" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                        NavigateUrl="~/voucher/vouPrintMain.aspx"><<--Back</asp:HyperLink></td>
                <td style="width: 79px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 57px; height: 18px">
                </td>
                <td colspan="2" style="height: 18px">
                    &nbsp;<asp:CustomValidator ID="cv1" runat="server" Font-Bold="False" Font-Size="10pt"
                        ValidationGroup="sb" Width="417px"></asp:CustomValidator></td>
                <td style="width: 79px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 22px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
