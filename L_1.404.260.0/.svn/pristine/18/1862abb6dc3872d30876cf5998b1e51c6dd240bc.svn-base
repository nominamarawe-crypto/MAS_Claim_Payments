<%@ Page Language="C#" AutoEventWireup="true" CodeFile="childProtPay001.aspx.cs" Inherits="chuldProtPay001" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>    
    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric02(arguments.Value))
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
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span>Child Protection Periodic Claims Due to
            <asp:TextBox ID="txtdue" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                Font-Size="10pt" OnTextChanged="txtdue_TextChanged" MaxLength="6" style="text-align: center" ></asp:TextBox></span></strong><br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333"
            GridLines="None" OnSelectedIndexChanging="GridView1_SelectedIndexChanged" Width="816px">
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="POLNO" HeaderText="Policy No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="PTABLE" HeaderText="Table" />
                <asp:BoundField DataField="LASTDUE" HeaderText="Last Due" />
                <asp:BoundField DataField="NEXTDUE" HeaderText="Next Due">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="START_DATE" HeaderText="Start Date" />
                <asp:BoundField DataField="END_DATE" HeaderText="End Date" />
                <asp:BoundField DataField="PAY_AMT" HeaderText="Pay Amt." />
                <asp:BoundField DataField="PAYMENT_COUNT" HeaderText="Payment Count" />
                <asp:BoundField DataField="MATDATE" HeaderText="Maturity Date" />
                <asp:BoundField DataField="SUMASSURED_PVAL" HeaderText="Sum Assured" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdue"
            ErrorMessage="Please Give the Due Year Month" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="10pt" Width="225px"></asp:RequiredFieldValidator><asp:CustomValidator
                ID="CustomValidator1" runat="server" ClientValidationFunction="test" ControlToValidate="txtdue"
                ErrorMessage="Please Give a Numeric Due Year Month" Font-Bold="True" Font-Names="Trebuchet MS"
                Font-Size="10pt" Width="275px"></asp:CustomValidator>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="10pt" ForeColor="Blue" NavigateUrl="~/Home.aspx"><<--Back</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
