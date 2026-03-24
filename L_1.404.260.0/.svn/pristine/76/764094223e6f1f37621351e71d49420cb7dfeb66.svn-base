<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthreq002.aspx.cs" Inherits="dthreq002" %>
<%@ PreviousPageType VirtualPath="~/dthreq.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

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
<script language="JavaScript" type="text/JavaScript">
function chkBal()
{
    //var chkbox; 
    //var i=02; 
    //debugger;
    var chkbox1=document.getElementById("GridView1_ctl02_ch");//grdid +'_ctl' + i + '_' + obj);
    var chkbox2=document.getElementById("GridView1_ctl04_ch");
    var chkbox10=document.getElementById("GridView1_ctl15_ch");
    var chkbox18=document.getElementById("GridView1_ctl03_ch");
    var b3=document.getElementById("Button3");
    var b4=document.getElementById("Button4"); 
    var b5=document.getElementById("Button5");
    var b6=document.getElementById("Button6");
    var b7=document.getElementById("Button7");
    var b8 = document.getElementById("Button8");
    var b9 = document.getElementById("Button9");
    var b10 = document.getElementById("Button10");
    var b11 = document.getElementById("Button11");
    
    if (chkbox1.checked)
    {        
        b3.disabled = false;
        b4.disabled = false;
        b11.disabled = false;
    }
    else
    {
        b3.disabled = true;
        b4.disabled = true;
        b11.disabled = true;
    }
    if (chkbox2.checked)
    {        
        b5.disabled = false;
    }
    else
    {
        b5.disabled = true;
    }
    if (chkbox10.checked)
    {
        b6.disabled=false;
        b7.disabled = false;
        b10.disabled = false;
    }
    else
    {
        b6.disabled=true;
        b7.disabled = true;
        b10.disabled = true;
    }
    if (chkbox18.checked)
    {
        b8.disabled = false;
        b9.disabled = false;
    }
    else
    {
        b8.disabled = true;
        b9.disabled = true;
    }
}
</script>
</head>

<body onload="JavaScript:chkBal();" style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong>
        <span><span style="font-size: 14pt">
        </span></span>
        </strong></span>
        <table style="width: 767px; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td colspan="5" style="height: 21px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px; background-color: #ffffff">
                    <span style="font-size: 14pt">
            Sri Lanka Insurance<br />
                    </span><span style="font-size: 12pt">Death Claim Requirments</span></td>
            </tr>
            <tr>
                <td colspan="5" style="background-color: #f0f0f0; height: 21px;">
                    <span style="color: #cc00cc"><span style="font-size: 12pt">
                    <span>Policy No. :-</span> 
                    </span></span>
                    <asp:Label ID="lblpolno" runat="server" Font-Size="12pt" Width="73px" ForeColor="#CC00CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px">
                    <asp:Label ID="lblMOS" runat="server" Font-Bold="True" Font-Size="12pt" Width="192px" ForeColor="#CC00CC"></asp:Label></td>
            </tr>
            <tr>
                <td style="background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="background-color: #f0f0f0; height: 21px;" colspan="4">
                    Name of Insured :
                    <asp:Label ID="lblnameofins" runat="server" Font-Bold="True" Font-Size="10pt" Width="466px"></asp:Label></td>
            </tr>
            <tr>
        
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="height: 21px; text-align: left;" colspan="3">
                    &nbsp;<asp:Label ID="lblsuccess" runat="server" ForeColor="#00CC33" Text="Details Added Successfully"
                        Visible="False" Width="224px"></asp:Label>
                </td>
                <td style="width: 123px; height: 21px; text-align: left; font-size: 12pt;">
                    </td>
            </tr>
            <tr>
                <td style="height: 21px; background-color: #f0f0f0;" colspan="5">
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="height: 22px;" colspan="4">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1"
                        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                        Height="143px" CaptionAlign="Top" HorizontalAlign="Center" Width="760px" 
                        EnableModelValidation="True" >
                        <FooterStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField> <ItemTemplate>
                            <asp:CheckBox ID="ch" onclick ="chkBal()" runat="server" />
                            </ItemTemplate></asp:TemplateField>
                            <asp:BoundField DataField="DREQCODE" HeaderText="Requirement Code" ReadOnly="True"
                                SortExpression="DREQCODE" >
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DREQDESSHORT" HeaderText="Requirement Description" SortExpression="DREQDESSHORT" />
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <EditRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand='SELECT DREQDESSHORT, DREQCODE FROM LPHS.DREQDESC WHERE (IS_SHOW_DEATH = &#039;Y&#039;) ORDER BY DREQCODE'>
                    </asp:SqlDataSource>
                </td>

               
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="height: 22px;" colspan="4">
                     <asp:GridView ID="grdNoticeList" runat="server" BackColor="White" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                        Height="143px" CaptionAlign="Top" HorizontalAlign="Center" Width="760px" 
                        EnableModelValidation="True" >
                        <FooterStyle BackColor="#CCCCCC" />
                        <Columns>
                          
                            <asp:BoundField DataField="NOTICE_ID" HeaderText="Notice ID" ReadOnly="True"
                                SortExpression="NOTICE_ID" >
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTICE_NAME" HeaderText="Notice Name" SortExpression="NOTICE_ID" />
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <EditRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:GridView>
                   <%-- <asp:SqlDataSource ID="SqlNoticeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand='select NOTICE_ID,NOTICE_NAME FROM LCLM.DTH_NOTICES where '>
                    </asp:SqlDataSource>--%>
                </td>
            </tr>
            <asp:Panel ID="pnlSentReq" runat="server" Visible="false">
            <tr>
                <td style="background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="background-color: #f0f0f0; height: 21px;" colspan="4">
                    <span style="font-size: 12pt; color: #0000ff">
                        <asp:Label ID="lblwording" runat="server" Text="Sent Requirements" Width="340px"></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 24px;">
                </td>
                <td style="text-align: left;" colspan="4">
                    <asp:Table ID="Table1" runat="server" BorderStyle="Double" BorderWidth="1px" HorizontalAlign="Left"
                        Width="700px" CaptionAlign="Left">
                    </asp:Table>
                </td>
            </tr>
            </asp:Panel>
           
            <asp:Panel ID="pnlCollected" runat="server" Visible="false">
            <tr>
                <td style="background-color: #f0f0f0; height: 21px;">
                </td>
                <td style="background-color: #f0f0f0; height: 21px;" colspan="4">
                    <span style="font-size: 12pt; color: #0000ff">
                        <asp:Label ID="lblwording1" runat="server" Text="Collected Document" Width="340px"></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 24px;">
                </td>
                <td style="text-align: left;" colspan="4">
                    <asp:Table ID="Table2" runat="server" BorderStyle="Double" BorderWidth="1px" HorizontalAlign="Left"
                        Width="700px" CaptionAlign="Left">
                    </asp:Table>
                </td>
            </tr>
            </asp:Panel>
            <tr>
                <td style="width: 111px; height: 21px; background-color: #f0f0f0;">
                </td>
                <td style="height: 21px; background-color: #f0f0f0;">
                </td>
                <td style="width: 11px; height: 21px; background-color: #f0f0f0;">
                </td>
                <td style="width: 5px; height: 21px; background-color: #f0f0f0;">
                </td>
                <td style="width: 123px; height: 21px; background-color: #f0f0f0;">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px; background-color: #f0f0f0">
                    <asp:Button ID="btnaddEnt" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        PostBackUrl="~/addEnt001.aspx" Text="--Address Entry--" OnClientClick="cForm10(this.form1)" Width="101px" />
                    <asp:Button ID="btnsubmit" runat="server" Text="--Submit--" OnClientClick="cForm8(this.form1)"  OnClick="btnsubmit_Click" Font-Bold="False" Font-Names="Trebuchet MS" Width="100px" PostBackUrl="~/dthreq002.aspx" />
                    <asp:Button ID="btnexit" runat="server" Text="--Exit--" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Font-Bold="False" Font-Names="Trebuchet MS" Width="100px" />
                    <asp:Button
                        ID="btnDelete" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="cForm8(this.form1)"  PostBackUrl="~/dthreq002.aspx" 
                        Text="--Delete--" Width="100px" OnClick="btnDelete_Click" />
                    <asp:Button
                        ID="btnnext" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="cForm8(this.form1)"
                        Text="--Next--" Width="100px" PostBackUrl="~/dthPro001.aspx" />
                    <asp:Button
                        ID="btnCheckSelected" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="cForm17(this.form1)" 
                        Text="--Check Selected--" Width="120px" PostBackUrl="~/checkSelectedReq.aspx" OnClick="btnCheckSelected_Click" />
                </td>
            </tr>
            <tr>
                <td style="height: 16px; text-align: center;" colspan="5">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Font-Bold="False" Font-Size="10pt"
                        Width="361px"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 21px; text-align: left;" colspan="5">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <table style="width: 848px">
                        
                        <tr>
                            <td>
                               
                            </td>
                            <td>
                                
                            </td>

                            <td colspan="3">
                                 <asp:CheckBox ID="Signature" OnCheckedChanged="ChkSig" runat="server" Text="Display Digital Signature" /> 
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 28px; height: 15px">
                            </td>
                            <td style="width: 348px; height: 15px; text-align: right">
                                <strong>&nbsp;Document Request</strong></td>
                            <td style="width: 31px; height: 15px; text-align: right">
                    <asp:Button ID="Button1" runat="server" Text="-- English (2503)--" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="cForm1(this.form1)" Width="115px"  PostBackUrl="~/intOfDeath2503Eng.aspx"/></td>
                            <td style="width: 36px; height: 15px; text-align: left">
                    <asp:Button ID="Button2" runat="server" Text="--Sinhala (2503)--" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="cForm2(this.form1)" Width="115px"  PostBackUrl="~/Intofdth2503Sin.aspx" /></td>
                            <td style="width: 414px; height: 15px; text-align:left">
                             <asp:Button ID="Button12" runat="server" Text="--Tamil (2503)--" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="cForm18(this.form1)" Width="115px"  PostBackUrl="~/intOfDeath2503Tam.aspx" /></td>

                        </tr>
                        <tr>
                            <td style="width: 28px; height: 29px">
                            </td>
                            <td style="width: 348px; height: 29px; text-align: right">
                                &nbsp;<strong>Second Request of
                    Requirements</strong></td>
                            <td style="width: 31px; height: 29px; text-align: right">
                                <asp:Button ID="brnsecondReq" runat="server" OnClientClick="cForm9(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Text="--English--" Width="115px" PostBackUrl="~/secondReq001.aspx" /></td>
                            <td style="width: 36px; height: 29px; text-align: left">
                    <asp:Button ID="btn_Sec_Req_InSinhala" runat="server" OnClientClick="cForm12(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Text="--Sinhala--"  Width="115px"  PostBackUrl="~/secondReq001Sin.aspx" /></td>
                            <td style="width: 414px; height: 29px">
                             <asp:Button ID="btn_Sec_Req_InTamil" runat="server" OnClientClick="cForm16(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Text="--Tamil--"  Width="115px"  PostBackUrl="~/secondReq001Tam.aspx" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 28px;">
                            </td>
                            <td style="width: 348px; text-align: right">
                                <strong>Claimant's Statement</strong></td>
                            <td style="width: 31px; text-align: right">
                                <asp:Button ID="Button3" runat="server" Text="--English (2505)--" OnClientClick="cForm3(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/claimentStt2505Eng.aspx" /></td>
                            <td style="width: 36px; text-align: left">
                    <asp:Button ID="Button4" runat="server" Text="--Sinhala (2504)--" OnClientClick="cForm4(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/claimentStt2504Sin.aspx" /></td>
                            <td style="width: 414px;">
                    <asp:Button ID="Button11" runat="server" Text="--Tamil (2506)--" OnClientClick="cForm14(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/claimentStt2506Tam.aspx" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 28px; height: 29px;">
                            </td>
                            <td style="width: 348px; text-align: right; height: 29px;">
                                <strong>Affidavit</strong></td>
                            <td style="width: 31px; text-align: right; height: 29px;">
                                <asp:Button ID="Button6" runat="server" Text="--English--" OnClientClick="cForm6(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/affidavitEng.aspx"/></td>
                            <td style="width: 36px; text-align: left; height: 29px;">
                                <asp:Button ID="Button7" runat="server" Text="--Sinhala--" OnClientClick="cForm7(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/affidavitSin.aspx"  /></td>
                            <td style="width: 414px; height: 29px;">
                                <asp:Button ID="Button10" runat="server" Text="--Tamil--" OnClientClick="cForm15(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/affidavitTam.aspx" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 28px; height: 29px;">
                            </td>
                            <td style="width: 348px; text-align: right; height: 29px;">
                                <strong>Assignee Statement</strong></td>
                            <td style="width: 31px; text-align: right; height: 29px;">
                                <asp:Button ID="Button8" runat="server" Text="--English--" OnClientClick="cForm11(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/assigneesttmnt001.aspx" /></td>
                            <td style="width: 36px; text-align: left; height: 29px;">
                                <asp:Button ID="Button9" runat="server" Text="--Sinhala--" OnClientClick="cForm13(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="115px"  PostBackUrl="~/assigneesttmntSin001.aspx" /></td>
                            <td style="width: 414px; height: 29px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px; text-align: center">
                    <%--<asp:Button ID="Button8" runat="server" Text="--Assignee Statement--" OnClientClick="cForm11(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="185px"  PostBackUrl="~/assigneesttmnt001.aspx" />--%>
                    <asp:Button ID="Button5" runat="server" Text="--Medical Certificates--" OnClientClick="cForm5(this.form1)" Font-Bold="False" Font-Names="Trebuchet MS" Width="185px" PostBackUrl="~/medCert.aspx"/></td>
            </tr>
            <% if (assigneeflag)
               {%>
            <% }%>
            <tr>
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="height: 21px; text-align: right;" colspan="4">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/letters/docsIntimation001.aspx" Width="186px">Intimation Stage Documents</asp:HyperLink></td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='intOfDeath2503Eng.aspx';

}
function cForm2(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='intOfDeath2503Sin.aspx';

}
function cForm3(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='claimentStt2505Eng.aspx';

}
function cForm4(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='claimentStt2504Sin.aspx';

}
function cForm5(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='medCert.aspx';

}
function cForm6(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='affidavitEng.aspx';

}
function cForm7(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='affidavitSin.aspx';

}
function cForm9(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='secondReq001.aspx';
 
}

function cForm10(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='addEnt001.aspx';
 
}
function cForm11(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='assigneesttmnt001.aspx';

}

function cForm13(form) {
    win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
    form1.target = 'myWin';
    form1.action = 'assigneesttmntSin001.aspx';

}

function cForm8(form)
{
 form1.target='';
 form1.action='';

}

function cForm12(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='secondReq001Sin.aspx';

}

function cForm14(form) {
    win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
    form1.target = 'myWin';
    form1.action = 'claimentStt2506Tam.aspx';

}

function cForm15(form) {
    win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
    form1.target = 'myWin';
    form1.action = 'affidavitTam.aspx';

}
function cForm16(form) {
    win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
    form1.target = 'myWin';
    form1.action = 'secondReq001Tam.aspx';

}
function cForm17(form) {
    win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
    form1.target = 'myWin';
    form1.action = 'checkSelectedReq.aspx';

    }

    function cForm18(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='intOfDeath2503Tam.aspx';

}
</script>
</html>
