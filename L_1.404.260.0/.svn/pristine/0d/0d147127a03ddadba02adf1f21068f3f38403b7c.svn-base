<%@ Page Language="C#" AutoEventWireup="true" CodeFile="repudiation002.aspx.cs" Inherits="repudiation002" %>
<%@ PreviousPageType VirtualPath="~/repudiation001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

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
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt">
        </span></span><table style="font-weight: bold; font-size: 10pt;
            width: 605px; font-family: 'Trebuchet MS'; text-align: center">
            <tr>
                <td colspan="4" style="border-bottom-width: thin; border-bottom-color: black; height: 20px;
                    background-color: #f0f0f0">
                    </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; text-align: center">
                    <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Repudiation</span></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: whitesmoke; text-align: center">
                    <asp:Label ID="Label1" runat="server" ForeColor="#00CC33" Text="Update Successfull"
                        Visible="False" Width="393px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; text-align: left">
                    Policy No.</td>
                <td style="width: 195px; height: 20px; text-align: left">
                    <asp:Label ID="lblpolno" runat="server" Width="111px"></asp:Label></td>
                <td style="width: 146px; height: 20px; text-align: left">
                    Life Type</td>
                <td style="width: 190px; height: 20px; text-align: left">
                    <asp:Label ID="lblmos" runat="server" Width="111px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 195px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 190px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 287px; height: 19px; text-align: left">
                    Name of Life Assured</td>
                <td colspan="3" style="height: 19px; text-align: left">
                    <asp:Label ID="lblname" runat="server" Width="361px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 195px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 190px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; text-align: left">
                    <asp:Label ID="lblrepudiatedate" runat="server" Width="135px">Repudiate Date</asp:Label></td>
                <td style="height: 20px; text-align: left; font-weight: normal;" colspan="3">
                    <asp:TextBox ID="txtrepudDate" runat="server" MaxLength="8" Width="115px"></asp:TextBox>
                    YYYYMMDD<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrepudDate"
                        ErrorMessage="Please Enter the Repudiate Date" Display="Dynamic" Font-Bold="False"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="test"
                        ControlToValidate="txtrepudDate" ErrorMessage="Pleae Enter a Numeric Repudiate Date" Display="Dynamic" Font-Bold="False"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; background-color: #f0f0f0; text-align: center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; text-align: left">
                    <asp:Label ID="lblrepureasoneng" runat="server" Width="135px">Repudiation Reason</asp:Label></td>
                <td colspan="3" style="height: 20px; text-align: left">
                    <asp:TextBox ID="txtrepreason" runat="server" Width="375px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="color: #000000; height: 20px; background-color: #f0f0f0; text-align: center">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtrepreason"
                        ErrorMessage="Please Enter the Repudiate Reason" Display="Dynamic" Font-Bold="False"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; text-align: left">
                    <asp:Label ID="lblrepureasonsin" runat="server" Width="161px">Repu. Reason in Sinhala</asp:Label></td>
                <td colspan="3" style="height: 20px; text-align: left">
                    <asp:TextBox ID="txtrepureasSin" runat="server" Font-Names="Sandaya" Font-Size="10pt"
                        MaxLength="75" Width="375px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="color: #000000; height: 20px; background-color: #f0f0f0; text-align: center">
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="height: 20px; text-align: center" colspan="4"><asp:Button ID="btnrepulettereng"  runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Repudiation Letter English--" PostBackUrl="~/RepudiatnLetter001.aspx" OnClientClick="cForm1(this.form1)" />
                    <asp:Button ID="btnrepulettersin" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Repudiation Letter Sinhala--" PostBackUrl="~/RepudiatnLetter002.aspx" OnClientClick="cForm2(this.form1)"/></td>
            </tr>
            <tr>
                <td style="height: 20px; text-align: center" colspan="4">
                    <asp:Button ID="btnlapselettereng" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Lapse Letter English--" PostBackUrl="~/lapseLetter001.aspx" OnClientClick="cForm3(this.form1)"/>
                    <asp:Button ID="btnlapselettersin" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Lapse Letter Sinhala--" PostBackUrl="~/lapseLetter002.aspx" OnClientClick="cForm4(this.form1)"/></td>
            </tr>
            <tr>
                <td colspan="4" style="font-weight: normal; height: 10px; background-color: #f0f0f0;">
                    <asp:Button ID="btnRepudiate" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Text="--Repudiate--" OnClick="btnRepudiate_Click" OnClientClick="cForm8(this.form1)" Width="124px"/>
                    <asp:Button ID="btnexit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                        Text="--Exit--" Width="124px" /></td>
            </tr>
            <tr>
                <td style="height: 20px; text-align: center" colspan="4">
                    <asp:Button ID="cmdExgracia" runat="server" Text="Exgracia Payment" Visible="False" />
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 287px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 195px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 190px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='RepudiatnLetter001.aspx';

}
function cForm2(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='RepudiatnLetter002.aspx';

}
function cForm3(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='lapseLetter001.aspx';

}
function cForm4(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='lapseLetter002.aspx';

}
function cForm8(form)
{
 form1.target='';
 form1.action='';

}



</script>
</html>
