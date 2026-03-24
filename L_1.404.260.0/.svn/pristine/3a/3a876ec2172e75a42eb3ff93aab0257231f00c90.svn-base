<%@ Page Language="C#" AutoEventWireup="true" CodeFile="legalHieres003.aspx.cs" Inherits="legalHieres003" %>
<%@ PreviousPageType VirtualPath="~/legalHieres001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%--<%@ Reference Page="~/leganHieresDelete.aspx" %>
--%>
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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span></strong>
        <table style="font-weight: bold; font-size: 10pt; width: 703px; font-family: 'Trebuchet MS'">
            <tr>
                <td colspan="5" style="height: 18px; background-color: whitesmoke">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Legal Hieres</span></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px">
                    <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" ForeColor="#00C000" Text="Record Updated Succesfully"
                        Visible="False" Width="314px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0">
                    Deceased's</td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 114px; height: 5px; text-align: left">
                    <asp:Literal ID="lblwidow" runat="server" Text="Widow/Widower" Visible="False"></asp:Literal></td>
                <td colspan="3" style="height: 5px; text-align: left">
                    <asp:TextBox ID="txtwidowName" runat="server" MaxLength="100" TextMode="MultiLine" Width="401px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 114px; height: 5px; text-align: left">
                    <asp:Literal ID="lblwidowaddr" runat="server" Text="Residing At" Visible="False"></asp:Literal></td>
                <td colspan="3" style="height: 5px; text-align: left">
                    <asp:TextBox ID="txtwidowAd1" runat="server" MaxLength="100" Width="401px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr><td style="width: 20px; height: 18px">
            </td>
                <td style="width: 114px; height: 18px; text-align: left">
                    <asp:Literal ID="lblwidowDOB" runat="server" Text="Born on" Visible="False"></asp:Literal></td>
                <td style="width: 71px; height: 18px; text-align: left;">
                    <asp:TextBox ID="txtwidowDOB" runat="server" MaxLength="8" Width="103px" Visible="False"></asp:TextBox></td>
                <td style="width: 17px; height: 18px; text-align: left;">
                    <asp:Label ID="lblWidowshare" runat="server" Text="Share (%)"></asp:Label></td>
                <td style="width: 126px; height: 18px; text-align: left;">
                    <asp:TextBox ID="txtWidowshare" runat="server" Width="83px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 114px; height: 15px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="font-weight: normal; height: 15px; background-color: #f0f0f0;
                    text-align: left">
                    <asp:Literal ID="Literal1" runat="server" Text="yyyymmdd"></asp:Literal>
                    <asp:CustomValidator ID="cvspouce" runat="server" Font-Bold="True" Width="393px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 114px; height: 5px; text-align: left">
                    <asp:Literal ID="lblmother" runat="server" Text="Mother" Visible="False"></asp:Literal></td>
                <td colspan="3" style="height: 5px; text-align: left">
                    <asp:TextBox ID="txtmothersName" runat="server" MaxLength="100" TextMode="MultiLine" Width="401px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 114px; height: 5px; text-align: left">
                    <asp:Literal ID="lblmothersresi" runat="server" Text="Residing At" Visible="False"></asp:Literal></td>
                <td colspan="3" style="height: 5px; text-align: left">
                    <asp:TextBox ID="txtmothersAd1" runat="server" MaxLength="100" Width="401px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr><td style="width: 20px; height: 18px">
            </td>
                <td style="width: 114px; height: 18px; text-align: left">
                    <asp:Literal ID="lblmotherdob" runat="server" Text="Born on" Visible="False"></asp:Literal></td>
                <td style="width: 71px; height: 18px">
                    <asp:TextBox ID="txtmothersDOB" runat="server" MaxLength="8" Width="103px" Visible="False"></asp:TextBox></td>
                <td style="width: 17px; height: 18px; text-align: left;">
                    <asp:Label ID="lblMothershare" runat="server" Text="Share (%)"></asp:Label></td>
                <td style="width: 126px; height: 18px; text-align: left;">
                    <asp:TextBox ID="txtMothershare" runat="server" Width="83px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 114px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="font-weight: normal; height: 18px; background-color: #f0f0f0;
                    text-align: left">
                    <asp:Literal ID="Literal2" runat="server" Text="yyyymmdd"></asp:Literal>
                    <asp:CustomValidator ID="cvmother" runat="server" Font-Bold="True" Width="393px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 114px; height: 5px; text-align: left">
                    <asp:Literal ID="lblfather" runat="server" Text="Father" Visible="False"></asp:Literal></td>
                <td id="cellid" colspan="3" style="height: 5px; text-align: left">
                    <asp:TextBox ID="txtfathersName" runat="server" MaxLength="50" Width="401px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 114px; height: 5px; text-align: left">
                    <asp:Literal ID="lblfatherResi" runat="server" Text="Residing At" Visible="False"></asp:Literal></td>
                <td colspan="3" style="height: 5px; text-align: left">
                    <asp:TextBox ID="txtfathersAd1" runat="server" MaxLength="100" Width="401px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr><td style="width: 20px; height: 18px">
            </td>
                <td style="width: 114px; height: 18px; text-align: left">
                    <asp:Literal ID="lblfatherDOB" runat="server" Text="Born on" Visible="False"></asp:Literal></td>
                <td style="width: 71px; height: 18px">
                    <asp:TextBox ID="txtfathersDOB" runat="server" MaxLength="8" Width="103px" Visible="False"></asp:TextBox></td>
                <td style="width: 17px; height: 18px; text-align: left;">
                    <asp:Label ID="lblFathershare" runat="server" Text="Share (%)"></asp:Label></td>
                <td style="width: 126px; height: 18px; text-align: left;">
                    <asp:TextBox ID="txtFathershare" runat="server" Width="83px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 114px; height: 18px; background-color: #f0f0f0">
                </td>
                <td colspan="3" style="font-weight: normal; height: 18px; background-color: #f0f0f0;
                    text-align: left">
                    <asp:Literal ID="Literal3" runat="server" Text="yyyymmdd"></asp:Literal>
                    <asp:CustomValidator ID="cvfather" runat="server" Font-Bold="True" Width="393px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0">
                    <asp:Literal ID="lblchidren" runat="server" Text="Children"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; text-align: center">
                    <asp:Table ID="Table1" runat="server" HorizontalAlign="Left" Width="670px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0">
                    <asp:CustomValidator ID="cvchilderen" runat="server" Width="481px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0">
                    <asp:Literal ID="lblbroandsys" runat="server" Text="Brothers and Sisters"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; text-align: center">
                    <asp:Table ID="Table2" runat="server" HorizontalAlign="Left" Width="670px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; background-color: #f0f0f0">
                    <asp:CustomValidator ID="cvbrosys" runat="server" Width="481px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px">
                </td>
                <td style="width: 114px; height: 18px; text-align: left">
                </td>
                <td style="width: 71px; height: 18px">
                </td>
                <td style="width: 17px; height: 18px">
                </td>
                <td style="width: 126px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 114px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 71px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 17px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px">
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClick="btnSubmit_Click" Text="--Submit--" />
                    <asp:Button ID="btnexit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClientClick="self.close()"
                        Text="--Exit--" />
                    <asp:Button ID="btnshares" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                         Text="--Shares--" OnClick="btnshares_Click" />
                    <asp:Button ID="Button1" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        OnClick="Button1_Click" Text="--Delete--" /></td>
            </tr>
            <tr>
                <td style="width: 20px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 114px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 71px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 17px; height: 18px; background-color: #f0f0f0">
                </td>
                <td style="width: 126px; height: 18px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
