<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ibslRep002.aspx.cs" Inherits="ibslRep002" %>
<%@ PreviousPageType VirtualPath="~/ibslRep001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
    .fixedHeader
    {
    overflow: auto;
    height:350px;    
    }

    table th
    {
    border-width: 4px;
    border-color: Black;
    background-color: Gray;
    position: relative;
    top: expression(this.parentNode.parentNode.
                   parentNode.scrollTop-1);
    }
</style>
<style type="text/css">
        .LeftAlign
        {
            text-align: Left;
        }
        
        .RightAlign
        {
            text-align: Right;
        }
        
           
    </style>  


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
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span><span style="font-size: 12pt">IBSL Reports<br />
        </span></span></strong>
        <% if (criteria == 1)
           { %>
        <table style="font-weight: bold; font-size: 10pt; width: 751px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
                <td colspan="3" style="text-align: left">
                    <span style="color: #990066">Death Claims Recieved</span></td>
            </tr>
        </table>
        
        <%--<div id="NewFixedheaderDiv1">
             <table id ="Fixedheader1" border="1" width="900" >
             <tr>
                <td colspan="1" style="width: 100px;  ">Policy Number
                     </td>
                <td colspan="1" style="width: 100px;  ">Claim No.     
                </td>
                <td colspan="1" style="width: 100px;  ">Sum Assured 
                     </td>
                <td colspan="1" style="width: 100px;  ">FPU
                    </td>
                <td colspan="1" style="width: 100px;  ">ADB
                     </td>
                <td colspan="1" style="width: 100px;  "> SJ
                     </td>
                <td colspan="1" style="width: 100px;  ">FE
                     </td>
                <td colspan="1" style="width: 100px;  ">Bonus
                     </td>
                <td colspan="1" style="width: 100px;  ">Total 
                     </td>
            </tr>
        </table>
        </div>--%>
       
        
        <div class="fixedHeader">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None"
            Width="900px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="polno" HeaderText="Policy Number" ItemStyle-Width="100" > 
                    <ItemStyle HorizontalAlign="Right" /> 
                </asp:BoundField>
                <asp:BoundField DataField="clmno" HeaderText="Claim No." ItemStyle-Width="100"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
                 </asp:BoundField>
                <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" ItemStyle-Width="100"  >
                  <%--  <ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
                <asp:BoundField DataField="fpu" HeaderText="FPU" ItemStyle-Width="100">
                    <%--<ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
                <asp:BoundField DataField="adb" HeaderText="ADB" ItemStyle-Width="100">
                    <%--<ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
                <asp:BoundField DataField="sj" HeaderText="SJ" ItemStyle-Width="100">
                    <%--<ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
                <asp:BoundField DataField="fe" HeaderText="FE" ItemStyle-Width="100" >
                    <%--<ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
                <asp:BoundField DataField="totbons" HeaderText="Bonus" ItemStyle-Width="100">
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-Width="100">
                    <%--<ItemStyle HorizontalAlign="Right" />--%>
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
      <%} %>
     
        <table style="font-weight: bold; font-size: 10pt; width: 900px; font-family: 'Trebuchet MS ';
            background-color: #f0f0f0"  border="1" >
            <% if (criteria == 1)
               {%>
            <tr>
                <td colspan="1" style="width: 100px;  ">
                    Total</td>
                <td colspan="1" style="width: 100px;  ">
                </td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsumtot1" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfpu1" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lbladb1" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsj1" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfe1" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblbon1" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lbltoto1" runat="server"  ></asp:Label></td>
            </tr>
            <%}
              if (criteria == 2)
              { %>
            <tr>
                <td colspan="11" style="text-align: left">
                    <span style="color: #990066">Death Claims Paid</span></td>
            </tr><%} %>
        </table>
        
        <% if (criteria == 2)
           { %>
            
         <%-- <div id="NewFixedheaderDiv2">
             <table id ="Fixedheader2" border="1" width="1000" >
             <tr>
                <td colspan="1" style="width: 100px;  ">Policy Num
                     </td>
                <td colspan="1" style="width: 100px;  ">Claim No.     
                </td>
                <td colspan="1" style="width: 100px;  ">Sum Assured 
                     </td>
                <td colspan="1" style="width: 100px;  ">FPU
                    </td>
                <td colspan="1" style="width: 100px;  ">ADB
                     </td>
                <td colspan="1" style="width: 100px;  "> SJ   
                     </td>
                <td colspan="1" style="width: 100px;  ">FE
                     </td>
                <td colspan="1" style="width: 100px;  ">Bonus
                     </td>
                <td colspan="1" style="width: 100px;  ">Gross Claim   
                     </td>
                <td colspan="1" style="width: 100px;  ">Net Claim  
                     </td>
            </tr>
        </table>
        </div> --%>
        
           
           <div class="fixedHeader">
           
  
           
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None"
            Width="1000px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
           <%-- <Columns>
                <asp:BoundField DataField="polno" HeaderText="Policy Number" />
                <asp:BoundField DataField="clmno" HeaderText="Claim No." />
                <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="fpu" HeaderText="FPU" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="adb" HeaderText="ADB" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="sj" HeaderText="SJ" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="fe" HeaderText="FE" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="totbons" HeaderText="Bonus" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" />
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>--%>
            
            <Columns>
                <asp:BoundField DataField="polno" HeaderText="Policy Number" ItemStyle-Width="100" > 
                     
                </asp:BoundField>
                <asp:BoundField DataField="clmno" HeaderText="Claim No." ItemStyle-Width="100"  > 
                   
                 </asp:BoundField>
                <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" ItemStyle-Width="100"  >
              
                </asp:BoundField>
                <asp:BoundField DataField="fpu" HeaderText="FPU" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="adb" HeaderText="ADB" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="sj" HeaderText="SJ" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="fe" HeaderText="FE" ItemStyle-Width="100" >
                    
                </asp:BoundField>
                <asp:BoundField DataField="totbons" HeaderText="Bonus" ItemStyle-Width="100">
                   
                </asp:BoundField>
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" ItemStyle-Width="100"/>
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" ItemStyle-Width="100">
                    
                </asp:BoundField>
            </Columns>
            
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        <%} %>
        <table style="font-weight: bold; font-size: 10pt; width: 1000px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0 " border="1"  > 
            <% if (criteria == 2)
               { %>
            <tr>
                <td colspan="1" style="width: 100px; ">
                    Total</td>
                <td colspan="1" style="width: 100px;   ">
                </td>
                <td colspan="1" style="width: 100px;   ">
                    <asp:Label ID="lblsumtot2" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfpu2" runat="server"   ></asp:Label></td>
                <td colspan="1" style="width: 100px;   ">
                    <asp:Label ID="lbladb2" runat="server"   ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsj2" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;   ">
                    <asp:Label ID="lblfe2" runat="server"   ></asp:Label></td>
                <td colspan="1" style="width: 100px;   ">
                    <asp:Label ID="lblbon2" runat="server"   ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="gross2" runat="server" ></asp:Label></td>
                <td colspan="1" style="width: 100px;" >
                    <asp:Label ID="lbltoto2" runat="server"  ></asp:Label></td>
            </tr><%} 
                     if (criteria == 3){
                     %>
            <tr>
                <td colspan="12" style="text-align: left">
                    <span style="color: #990066">Death Claims Outstanding</span></td>
            </tr><%} %>
        </table>
    
    </div><% 
              if (criteria == 3)
              {
                     %>
                        
              <%--  <div id="NewFixedheaderDiv3">
             <table id ="Fixedheader3" border="1" width="1000" >
             <tr>
                <td colspan="1" style="width: 100px;  ">Policy Number
                     </td>
                <td colspan="1" style="width: 100px;  ">Claim No.     
                </td>
                <td colspan="1" style="width: 100px;  ">Sum Assured 
                     </td>
                <td colspan="1" style="width: 100px;  ">FPU
                    </td>
                <td colspan="1" style="width: 100px;  ">ADB
                     </td>
                <td colspan="1" style="width: 100px;  "> SJ   
                     </td>
                <td colspan="1" style="width: 100px;  ">FE
                     </td>
                <td colspan="1" style="width: 100px;  ">Bonus
                     </td>
                <td colspan="1" style="width: 100px;  ">Gross Claim   
                     </td>
                <td colspan="1" style="width: 100px;  ">Net Claim  
                     </td>
            </tr>
        </table>
        </div>  --%>
               
                     
                     <div class="fixedHeader">
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None"
            Width="1000px">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <%--<Columns>
            <asp:BoundField DataField="polno" HeaderText="Policy Number" />
            <asp:BoundField DataField="clmno" HeaderText="Claim No." />
            <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="fpu" HeaderText="FPU" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="adb" HeaderText="ADB" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="sj" HeaderText="SJ" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="fe" HeaderText="FE" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="totbons" HeaderText="Bonus" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" />
            <asp:BoundField DataField="netclm" HeaderText="Net Claim" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>--%>
        
        <Columns>
                <asp:BoundField DataField="polno" HeaderText="Policy Number" ItemStyle-Width="100" > 
                     
                </asp:BoundField>
                <asp:BoundField DataField="clmno" HeaderText="Claim No." ItemStyle-Width="100"  > 
                   
                 </asp:BoundField>
                <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" ItemStyle-Width="100"  >
              
                </asp:BoundField>
                <asp:BoundField DataField="fpu" HeaderText="FPU" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="adb" HeaderText="ADB" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="sj" HeaderText="SJ" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="fe" HeaderText="FE" ItemStyle-Width="100" >
                    
                </asp:BoundField>
                <asp:BoundField DataField="totbons" HeaderText="Bonus" ItemStyle-Width="100">
                   
                </asp:BoundField>
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" ItemStyle-Width="100"/>
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" ItemStyle-Width="100">
                    
                </asp:BoundField>
            </Columns>
        
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </div>
    <%} %>
        <table style="font-weight: bold; font-size: 10pt; width: 1000px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0" border="1">
            <tr><%if (criteria == 3)
                  { %>
                <td colspan="1" style="width: 100px;  ">
                    Total</td>
                <td colspan="1" style="width: 100px;  ">
                </td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsumtot3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfpu3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lbladb3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsj3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfe3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblbon3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="gross3" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lbltoto3" runat="server"  ></asp:Label></td>
            </tr><%}if (criteria == 4){ %>
            <tr>
                <td colspan="12" style="text-align: left">
                    <span style="color: #990066">Death Claims Rejected</span></td>
            </tr><%} %>
        </table>
        <% if (criteria == 4)
           { %>
          
          <%-- <div id="NewFixedheaderDiv4">
             <table id ="Fixedheader4" border="1" width="1000" >
             <tr>
                <td colspan="1" style="width: 100px;  ">Policy Number
                     </td>
                <td colspan="1" style="width: 100px;  ">Claim No.     
                </td>
                <td colspan="1" style="width: 100px;  ">Sum Assured 
                     </td>
                <td colspan="1" style="width: 100px;  ">FPU
                    </td>
                <td colspan="1" style="width: 100px;  ">ADB
                     </td>
                <td colspan="1" style="width: 100px;  "> SJ   
                     </td>
                <td colspan="1" style="width: 100px;  ">FE
                     </td>
                <td colspan="1" style="width: 100px;  ">Bonus
                     </td>
                <td colspan="1" style="width: 100px;  ">Gross Claim   
                     </td>
                <td colspan="1" style="width: 100px;  ">Net Claim  
                     </td>
            </tr>
        </table>
        </div>   --%>
           
           <div class="fixedHeader">
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None"
            Width="1000px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
           <%-- <Columns>
                <asp:BoundField DataField="polno" HeaderText="Policy Number" />
                <asp:BoundField DataField="clmno" HeaderText="Claim No." />
                <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="fpu" HeaderText="FPU" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="adb" HeaderText="ADB" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="sj" HeaderText="SJ" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="fe" HeaderText="FE" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="totbons" HeaderText="Bonus" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" />
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>--%>
            
             <Columns>
                <asp:BoundField DataField="polno" HeaderText="Policy Number" ItemStyle-Width="100" > 
                     
                </asp:BoundField>
                <asp:BoundField DataField="clmno" HeaderText="Claim No." ItemStyle-Width="100"  > 
                   
                 </asp:BoundField>
                <asp:BoundField DataField="sumpval" HeaderText="Sum Assured" ItemStyle-Width="100"  >
              
                </asp:BoundField>
                <asp:BoundField DataField="fpu" HeaderText="FPU" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="adb" HeaderText="ADB" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="sj" HeaderText="SJ" ItemStyle-Width="100">
                    
                </asp:BoundField>
                <asp:BoundField DataField="fe" HeaderText="FE" ItemStyle-Width="100" >
                    
                </asp:BoundField>
                <asp:BoundField DataField="totbons" HeaderText="Bonus" ItemStyle-Width="100">
                   
                </asp:BoundField>
                <asp:BoundField DataField="grossclm" HeaderText="Gross Claim" ItemStyle-Width="100"/>
                <asp:BoundField DataField="netclm" HeaderText="Net Claim" ItemStyle-Width="100">
                    
                </asp:BoundField>
            </Columns>
            
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        <%} %>
        <table style="font-weight: bold; font-size: 10pt; width: 1000px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0"  border="1">
            <%if (criteria == 4)
              { %>
            <tr>
                <td colspan="1" style="width: 100px;  ">
                    Total</td>
                <td colspan="1" style="width: 100px;  ">
                </td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsumtot4" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfpu4" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lbladb4" runat="server" ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblsj4" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblfe4" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lblbon4" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="gross4" runat="server"  ></asp:Label></td>
                <td colspan="1" style="width: 100px;  ">
                    <asp:Label ID="lbltoto4" runat="server"  ></asp:Label></td>
            </tr><%} %>
        </table>
        <br />
        <table style="font-weight: bold; font-size: 10pt; width: 600px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
                <td colspan="4" style="width: 282px; text-align: center">
                    Activity</td>
                <td colspan="7" style="width: 406px; text-align: center">
                    Total</td>
            </tr>
            <tr>
                <td colspan="4" style="width: 282px; text-align: left">
                    Death Claims Recieved</td>
                <td colspan="7" style="width: 406px; text-align: center">
                    <asp:Label ID="lblrecievetot" runat="server" Style="text-align: right" Width="150px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 282px; text-align: left">
                    Death Claims Paid</td>
                <td colspan="7" style="width: 406px; text-align: center">
                    <asp:Label ID="lblpaidtot" runat="server" Style="text-align: right" Width="150px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 282px; text-align: left">
                    Death Claims Outstanding</td>
                <td colspan="7" style="width: 406px; text-align: center">
                    <asp:Label ID="lblouttot" runat="server" Style="text-align: right" Width="150px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 282px; text-align: left">
                    Death Claims Rejected</td>
                <td colspan="7" style="width: 406px; text-align: center">
                    <asp:Label ID="lblrejecttot" runat="server" Style="text-align: right" Width="150px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 282px; text-align: center">
                </td>
                <td colspan="7" style="width: 406px; text-align: center">
                </td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
