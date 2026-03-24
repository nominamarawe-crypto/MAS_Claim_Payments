<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeathClaimReport01.aspx.cs" Inherits="DeathClaimReport01" %>
<%@ PreviousPageType VirtualPath="~/DeathClaimReport.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .fixedHeader
    {
    overflow: auto;
    height:174px;
            width: 903px;
        }

    table th
    {
    border-width: 4px;
    border-color: Black;
    background-color: Gray;
    position: relative;
    top: expression(this.parentNode.parentNode.parentNode.scrollTop-1);
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
        
           
    .style1
    {
        width: 127px;
    }
    .style2
    {
        width: 113px;
    }
        
           
    .style3
    {
        width: 147px;
    }
        
           
    .auto-style1 {
        width: 147px;
        height: 110px;
    }
    .auto-style2 {
        height: 110px;
    }
    .auto-style3 {
        width: 105px;
        height: 110px;
    }
        
           
    </style>  


    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
       function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='DeathClaimReport02.aspx';

}
        
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

 <script language="javascript" type="text/javascript">


     function printDiv(printPanel) {
         var printContents = document.getElementById(printPanel).innerHTML;
         var originalContents = document.body.innerHTML;

         document.body.innerHTML = printContents;

         window.print();

         document.body.innerHTML = originalContents;
     }

    </script>

</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div  id="printPanelDiv" style="width: 905px" >
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span><span style="font-size: 12pt">Death Claim Period Report<br />
        </span></span></strong>
   <table style="font-weight: bold; font-size: 10pt; width: 905px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
             <td style="text-align: left; " class="auto-style1">
                </td>
              
                <td colspan= "3" class="auto-style2">
                    <asp:Label ID="lblerror" runat="server" Text="" ForeColor ="Red"></asp:Label>
                </td>
                 <td style="text-align: left; " class="auto-style3">
                </td>
             </tr>
            <tr>
                <td style="text-align: left; " class="style3">
                </td>
                <td style="text-align: left; " class="style2">
                </td>
                <td style="text-align: left; " class="style1">
                    
                </td>
                <td style="text-align: left ; width: 200px;">
                                             </td>
                <td style="text-align: left ; width: 105px;">
                </td>
            </tr>
        </table>
        <div class="fixedHeader" style="Height:auto">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None" 
            Width="900px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="DRPOLNO" HeaderText="Policy Number" ItemStyle-Width="100" > 
                    <ItemStyle HorizontalAlign="Right" /> 
                </asp:BoundField>
                <asp:BoundField DataField="DRCLMNO" HeaderText="Claim No" ItemStyle-Width="100"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="100px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="DECISION_DATE" HeaderText="Decision Date" 
                    ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy }"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="100px"></ItemStyle>
                 </asp:BoundField>

                 <%-- Added by Rumesha--%>

                <asp:BoundField DataField="ADB_DECISION_DATE" HeaderText="ADB Decision Date" 
                    ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy }"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="100px"></ItemStyle>
                 </asp:BoundField>

                  <asp:BoundField DataField="APRVDATE" HeaderText="Payment Memo Approval Date" 
                    ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy }" NullDisplayText="0" > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="100px"></ItemStyle>
                 </asp:BoundField>

                 <%-- Added by Rumesha--%>
                <asp:BoundField DataField="MEMO_APPROVE_DATE" HeaderText="ADB Approval Date" 
                    ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy }" NullDisplayText="0" > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="100px"></ItemStyle>
                 </asp:BoundField>

                 <asp:BoundField DataField="DISTN_AUTDATE" HeaderText="Shares Approval Date" 
                    ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy }" NullDisplayText="0"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="100px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="D1" HeaderText="Duration 01 ( From Decision Date to Payment memo approval Date)" ItemStyle-Width="150"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="D2" HeaderText="Duration 02 ( From Decision Date to Shares approval Date)" ItemStyle-Width="150"  > 
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>

               <%-- Added by Rumesha--%>
                <asp:BoundField DataField="D3" HeaderText="Duration 03 ( From ADB Decision Date to ADB approval Date)" ItemStyle-Width="150" >
                   <%-- <ItemStyle HorizontalAlign="Right" />--%>
<ItemStyle Width="150px"></ItemStyle>
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
      

     
                     
                     
   </div>
    <table style="font-weight: bold; font-size: 10pt; width: 905px; font-family: 'Trebuchet MS';
            background-color: #f0f0f0">
            <tr>
             <td style="text-align: left; " class="style3">
                </td>
              
                <td colspan= "3">
                   <%-- <asp:Label ID="lblerror" runat="server" Text="" ForeColor ="Red"></asp:Label>--%>
                </td>
                 <td style="text-align: left ; width: 105px;">
                </td>
             </tr>
            <tr>
                <td style="text-align: left; " class="style3">
                </td>
                <td style="text-align: left; " class="style2">
                    <asp:Button ID="BtnExcell" runat="server" Text="Export" 
                        onclick="BtnExcell_Click"  Width="100px"  />
                </td>
                <td style="text-align: left; " class="style1">
                    <asp:Button ID="btnPTint" runat="server" Text="Print" Width="100px"  
                        onclick="btnPTint_Click" OnClientClick="printDiv('printPanelDiv')" />
                       
                        <%--<asp:Button ID="btnPrint" runat="server" OnClientClick="printDiv('MainContent_printPanelDiv');return false"
                                    Text="Print" Visible="False" />--%>
                </td>
                <td style="text-align: left ; width: 200px;">
                                    <asp:Button ID="btnExit" runat="server" Text="Exit" Width="100px"  PostBackUrl="~/DeathClaimReport.aspx"/>
                
                </td>
                <td style="text-align: left ; width: 105px;">
                </td>
            </tr>
        </table>
        <br />
        
        <br />
    </form>
</body>
</html>

