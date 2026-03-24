<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reminder002.aspx.cs" Inherits="reminder002" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/reminder.aspx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>

</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong>
        <span><span style="font-size: 14pt">
            Sri Lanka Insurance</span><br />
        Death Calim Reminders</span><br />
        </strong></span>
        <table style="width: 723px; font-size: 10pt; font-family: 'Trebuchet MS'; background-color: #f0f0f0;">
            <tr>
                <td style="width: 20px; height: 17px">
                </td>
                <td style="height: 17px; text-align: center">
                    <strong><span style="font-size: 14pt">
                        <asp:Label ID="lblsuccess" runat="server" Font-Size="12pt" ForeColor="#009933" Width="202px"></asp:Label></span></strong></td>
                <td style="width: 20px; height: 17px; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: left">
                    <strong><span style="color: windowtext"><span>Policy Number :-&nbsp; </span>
                        <asp:Label ID="lblpolno" runat="server" Width="154px"></asp:Label><span style="font-size: 12pt">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span style="font-size: 10pt"> Life Type :- </span>
                        </span>
                        <asp:Label ID="lbllifetype" runat="server" Width="154px"></asp:Label></span></strong></td>
                <td style="width: 20px; height: 18px; font-size: 10pt;">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 17px">
                </td>
                <td style="height: 17px; text-align: center">
                    <strong><span style="font-size: 14pt">
                        <asp:Label ID="lblmsg" runat="server" Font-Size="10pt" ForeColor="#009933" Width="292px"></asp:Label></span></strong></td>
                <td style="width: 20px; height: 17px; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="625px" CaptionAlign="Top" HorizontalAlign="Left">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="rownum" />
                            <asp:BoundField DataField="doc" HeaderText="Document" />
                            <asp:BoundField DataField="sentdate" HeaderText="Sent Date" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        </Columns>
                        <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" VerticalAlign="Top" />
                        <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Left" VerticalAlign="Top" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                        <EmptyDataRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:GridView>
                </td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: center">
                    &nbsp;<asp:Button ID="btnRemove" runat="server" Text="--Remove from List--" OnClientClick="cForm8(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" s OnClick="btnRemove_Click" Font-Size="10pt"/>
                    <asp:Button ID="btnexit" runat="server" Text="--Exit--" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="10pt" /></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: center">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="cForm1(this.form1)"
                        PostBackUrl="~/reminder003.aspx" Font-Bold="True">English Reminder Letter</asp:LinkButton>
                    |
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="cForm2(this.form1)"
                        PostBackUrl="~/reminder004.aspx" Font-Bold="True">Sinhala Reminder Letter</asp:LinkButton></td>
                <td style="width: 20px; height: 18px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 20px; height: 18px">
                </td>
                <td style="height: 18px; text-align: left">
                </td>
                <td style="width: 20px; height: 18px">
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
 form1.action='reminder003.aspx';
}
function cForm2(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='reminder004.aspx';
}

function cForm8(form)
{
 form1.target='';
 form1.action='';
}

</script>

</html>
