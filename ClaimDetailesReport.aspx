<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClaimDetailesReport.aspx.cs" Inherits="MAS_Claim_Payments.ClaimDetailesReport " EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css" media="print">
      
    </style>

     <style type="text/css">
         .auto-style1 {
             text-align: center;
         }
     </style>

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

  
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
                 <asp:BoundField DataField="EPF" HeaderText="EPF" />
                 <asp:BoundField DataField="INSURED_NAME" HeaderText="Lifeassured Name" />
                 <asp:BoundField DataField="claimant_name" HeaderText="Claiment Name" />
                 <asp:BoundField DataField="NIC" HeaderText="NIC No" />
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
                 <asp:BoundField DataField="REF" HeaderText="Reference No as printed on the bank statement" />
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
             
           

            
        
</asp:Content>
