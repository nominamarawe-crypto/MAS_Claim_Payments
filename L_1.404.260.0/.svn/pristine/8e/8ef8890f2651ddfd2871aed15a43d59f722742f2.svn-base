<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkSelectedReq.aspx.cs" Inherits="checkSelectedReq" %>

<%@ PreviousPageType VirtualPath="~/dthreq002.aspx"%>
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

<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><strong>
        <span><span style="font-size: 14pt">
        </span></span>
        </strong></span>
        
        <table style="width: 767px; font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';">


             <tr>
                <td colspan="5" style="height: 21px; background-color: blue; text-align:left ">
                      &nbsp;<asp:Label runat="server" ForeColor="white" Text="Requirements"
                        Visible="True" Width="224px"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="5" style="height: 21px;">
                </td>
            </tr>

            <tr>
        
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="height: 21px; text-align: left;" colspan="3">
                    &nbsp;<asp:Label runat="server" ForeColor="black" Text="Selected Requirements"
                        Visible="True" Width="224px"></asp:Label>
                </td>
                <td style="width: 123px; height: 21px; text-align: left; font-size: 12pt;">
                    </td>
            </tr>
            <tr>
                <td style="height: 21px;" colspan="5">
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="height: 22px;" colspan="4">
                    <asp:GridView ID="grdViewSelected" runat="server" BackColor="White" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                        Height="143px" CaptionAlign="Top" HorizontalAlign="Center" Width="760px" 
                        EnableModelValidation="True" >
                        <FooterStyle BackColor="#CCCCCC" />
                        <Columns>
                      
                             <asp:BoundField DataField="REQID" HeaderText="Req ID" ReadOnly="True"
                                SortExpression="REQID" >
                                   <ItemStyle Width="100px" />                
                            </asp:BoundField>

                            <asp:BoundField DataField="REQDESC" HeaderText="Requirement" ReadOnly="True"
                                SortExpression="REQID" >
                                <ItemStyle Width="200px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="REQREMARK" HeaderText="Remark" SortExpression="REQID" />
                      
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <%--<AlternatingRowStyle BackColor="#CCCCCC" />--%>
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <EditRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:GridView>

                  <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand='SELECT DREQDESSHORT, DREQCODE FROM LPHS.DREQDESC WHERE (IS_SHOW_DEATH = &#039;Y&#039;) ORDER BY DREQCODE'>
                    </asp:SqlDataSource>--%>
                </td>
            </tr>
             <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="height: 22px;" colspan="4">
                    <asp:Label ID="lblNoReq" Visible="false" runat="server" Text="--No Selected Requirements--" ForeColor="Black" BackColor="#c8c8c8"></asp:Label>

                  <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand='SELECT DREQDESSHORT, DREQCODE FROM LPHS.DREQDESC WHERE (IS_SHOW_DEATH = &#039;Y&#039;) ORDER BY DREQCODE'>
                    </asp:SqlDataSource>--%>
                </td>
            </tr>
          
            <tr>
                <td style="width: 111px; height: 21px; ">
                </td>
                <td style="height: 21px; ">
                </td>
                <td style="width: 11px; height: 21px; ">
                </td>
                <td style="width: 5px; height: 21px; ">
                </td>
                <td style="width: 123px; height: 21px;">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px; background-color: blue; text-align:left ">
                      &nbsp;<asp:Label runat="server" ForeColor="white" Text="Notices"
                        Visible="True" Width="224px"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="5" style="height: 21px;">
                </td>
            </tr>

            <tr>
        
                <td style="width: 24px; height: 21px;">
                </td>
                <td style="height: 21px; text-align: left;" colspan="3">
                    &nbsp;<asp:Label runat="server" ForeColor="black" Text="Selected Notices"
                        Visible="True" Width="224px"></asp:Label>
                </td>
                <td style="width: 123px; height: 21px; text-align: left; font-size: 12pt;">
                    </td>
            </tr>
            <tr>
                <td style="height: 21px;" colspan="5">
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="height: 22px;" colspan="4">
                    <asp:GridView ID="gvNotices" runat="server" BackColor="White" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                        Height="143px" CaptionAlign="Top" HorizontalAlign="Center" Width="760px" 
                        EnableModelValidation="True" >
                        <FooterStyle BackColor="#CCCCCC" />
                        <Columns>
                      
                             <asp:BoundField DataField="REQID" HeaderText="Notice ID" ReadOnly="True"
                                SortExpression="REQID" >
                                   <ItemStyle Width="100px" />                
                            </asp:BoundField>

                            <asp:BoundField DataField="REQDESC" HeaderText="Notice" ReadOnly="True"
                                SortExpression="REQID" >
                                <ItemStyle Width="200px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="REQREMARK" HeaderText="Remark" SortExpression="REQID" />
                      
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <%--<AlternatingRowStyle BackColor="#CCCCCC" />--%>
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <EditRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:GridView>

                  <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand='SELECT DREQDESSHORT, DREQCODE FROM LPHS.DREQDESC WHERE (IS_SHOW_DEATH = &#039;Y&#039;) ORDER BY DREQCODE'>
                    </asp:SqlDataSource>--%>
                </td>
            </tr>

            <tr>
                <td style="width: 24px; height: 22px;">
                </td>
                <td style="height: 22px;" colspan="4">
                    <asp:Label ID="lblNoNotices" Visible="false" runat="server" Text="--No Selected Notices--" ForeColor="Black" BackColor="#c8c8c8"></asp:Label>

                  <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand='SELECT DREQDESSHORT, DREQCODE FROM LPHS.DREQDESC WHERE (IS_SHOW_DEATH = &#039;Y&#039;) ORDER BY DREQCODE'>
                    </asp:SqlDataSource>--%>
                </td>
            </tr>
         
          
            <tr>
                <td style="width: 111px; height: 21px; ">
                </td>
                <td style="height: 21px; ">
                </td>
                <td style="width: 11px; height: 21px; ">
                </td>
                <td style="width: 5px; height: 21px; ">
                </td>
                <td style="width: 123px; height: 21px;">
                    </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 21px; ">
                   
                    <asp:Button ID="btnClose" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                      OnClientClick="self.close()"  Text="Close" Width="92px" BackColor="Blue" ForeColor="White" />
                  </td>
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
</script>
</html>
