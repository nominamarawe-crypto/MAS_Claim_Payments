<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManualCheckEntryConfirm.aspx.cs" Inherits="trnState001" %>

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
        <span style="font-family: Trebuchet MS"><strong><span style="font-size: 14pt">
        </span></strong>
            <table style="font-weight: bold; font-size: 12pt; width: 603px; font-family: Trebuchet MS">
                <tr>
                    <td style="width: 49px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 166px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 220px; height: 21px; background-color: #f0f0f0">
                    </td>
                    <td style="width: 79px; height: 21px; background-color: #f0f0f0">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px">
                        <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                        </span>Manual Payment Record Entry Confirm</td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px; background-color: whitesmoke">
                    </td>
                </tr>
                <tr>
                    <td style="width: 49px; height: 21px;">
                    </td>
                    <td style="width: 166px; text-align: left; height: 21px;">
                        <span style="font-weight: normal; font-size: 10pt">Policy Number</span></td>
                    <td style="text-align: left; height: 21px;" colspan="2">
                        <span>
                            <asp:Label ID="lblPolNo" runat="server"  Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>
                        </span></td>
                </tr>
                
                <tr style="font-size: 12pt">
                    <td style="width: 49px; height: 21px">
                    </td>
                    <td style="width: 166px; height: 21px; text-align: left">
                        <span style="font-weight: normal; font-size: 10pt">Main Life or Spouse</span></td>
                    <td style="width: 220px; height: 21px; text-align: left">
                        <span style="font-size: 12pt">
                            <asp:Label ID="lbllMOS" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt">
                            </asp:Label>
                            <asp:Label ID="lblMOSShort" runat="server" Visible="false" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>
                            </span></td>
                    <td style="width: 79px; height: 21px">
                    </td>
                </tr>
                 <tr>
                    <td style="width: 49px; height: 21px;">
                    </td>
                    <td style="width: 166px; text-align: left; height: 21px;">
                        <span style="font-weight: normal; font-size: 10pt">Claim Number</span></td>
                    <td style="text-align: left; height: 21px;" colspan="2">
                        <span>
                            <asp:Label ID="lblClaimNo" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>

                       </span></td>
                </tr>
                <tr>
                    <td style="height: 21px;" colspan="4">
                    Are You Sure You eant to Add This Manual Payment Record ? 
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    <asp:Label runat="server" ID="lblMessage" Visible="false" ForeColor="Red" Font-Size="Small"></asp:Label>
                    <asp:Label ID="lblEPF" runat="server" Visible="false" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 21px; background-color: #ffffff">
                    </td>
                    <td colspan="2" style="height: 21px; background-color: #ffffff; text-align: left">
                        <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                            OnClick="btnsubmit_Click" Text="--Yes--" Width="98px" />
                            <asp:Button ID="Button1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                            OnClick="btnNo_Click" Text="--No--" Width="98px" NavigateUrl="~/ManualCheckEntry.aspx"  />
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                            NavigateUrl="~/ManualCheckEntry.aspx"><<--Back</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    </td>
                </tr>
            </table>
        </span>
    
    </div>
    </form>
</body>
</html>
