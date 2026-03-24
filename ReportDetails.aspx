<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDetails.aspx.cs" Inherits="MAS_Claim_Payments.ReportDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 917px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">

              
    <div>
       <h2> Detailed Report Of MAS Claims</h2>
        <div style="overflow-x:auto; overflow-y:auto; max-height: 300px;"> 

       
         <asp:GridView ID="GridView2" runat="server" Font-Size="Small" Height="78px" Width="16px" AutoGenerateColumns="False" PageSize="5" CssClass="auto-style8" OnRowDataBound="GridView2_RowDataBound">
             <HeaderStyle Font-Size="10pt" />
            <%-- <EmptyDataRowStyle HorizontalAlign="Center" />--%>
             <Columns>
                 <asp:BoundField DataField="NUM" HeaderText ="" />
                 <asp:BoundField DataField="POL_NO" HeaderText ="Policy No" />
                 <asp:BoundField DataField="CLAIM_NO" HeaderText ="Claim No" />
                 <asp:BoundField DataField="SBU" HeaderText ="Company Name" />
                 <asp:BoundField DataField="INSURED_NAME" HeaderText="Lifeassured Name" />
                 <asp:BoundField DataField="claimant_name" HeaderText="Claiment Name" />
                 <asp:BoundField DataField="Relashionship" HeaderText="Relationship to life assured" />
                 <asp:BoundField DataField="AMOUNT" HeaderText="Claim Amount" />
                 <asp:BoundField DataField="PAYEE_NAME" HeaderText="Payee Name" />
                 <asp:BoundField DataField="ACC_NO" HeaderText="Account NO" />
                 <asp:BoundField DataField="BANK_NAME" HeaderText="Bank" />
                 <asp:BoundField DataField="BANK_BRANCH_NAME" HeaderText="Branch " />
                 <asp:BoundField DataField="STATUS" HeaderText="Claim Status" />
                 <asp:BoundField DataField="DATE_OF_CLAIM" HeaderText="Claim Date" />
                 <asp:BoundField DataField="CHQDATE" HeaderText="Paid Date" />
                 <asp:BoundField DataField="CLAIM_TYPE" HeaderText="Claim Type" />
                 <asp:BoundField DataField="Payment_type" HeaderText="Payment Type" />
                 <asp:BoundField DataField="CHQNO" HeaderText="Slip Reference No" />
             </Columns>
             <EditRowStyle HorizontalAlign="Center" />
             <SelectedRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
         </asp:GridView>
        
     </div>
     <div>
         <div style="text-align:center"> </div> 
         <div class="auto-style1">
             <br />
         <asp:Button ID="Button2" runat="server" Text="Export To Excel" Onclick="btnExport_Click" style="width: 139px" />
         
       <%-- <EmptyDataRowStyle HorizontalAlign="Center" />--%>     <%--  <input name="B1" onclick="window.print()" type="submit" value="PRINT" />--%>       <%--    <asp:Button ID="Button1" runat="server" Text="Button" />--%>
             <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
         </div>
     </div>
    </div>
 
       
    <asp:HiddenField ID="hdfFrm" runat="server" />
    <asp:HiddenField ID="hdfTo" runat="server" />
    <asp:HiddenField ID="hdfPolNo" runat="server" />
    <asp:HiddenField ID="hdfNIC" runat="server" />

        </div>
    </form>
</body>
</html>
