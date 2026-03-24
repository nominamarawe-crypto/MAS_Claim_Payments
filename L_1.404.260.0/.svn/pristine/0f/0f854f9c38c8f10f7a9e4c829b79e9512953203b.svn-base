<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwarnaJayanthiEnqueryPage.aspx.cs" Inherits="SwarnaJayanthiEnqueryPage" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>


</head>
<body>
    <form id="form1" runat="server">        
         <h3>Refund Of Premium Calculation Under SwarnaJayanthi Calculation (Date Format YYYYMMDD) </h3>
        <table  >
        <tr>
                <th></th>
                    
                <th width="200">
                   </th>
                <th width="100">
                    </th>

                    <th></th>
                    
                <th width="200">
                   </th>
                <th width="100">
                    </th>
                    <th></th>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Policy No:</td>
                <td>
                    <asp:TextBox ID="txtPolNo" runat="server"   MaxLength="8"></asp:TextBox></td>
            
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ErrorMessage="*" ControlToValidate="txtPolNo" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </td>
                <td>
                     Date Of Commencement</td>
                <td>
                     <asp:TextBox ID="txtDateOfCommencement" runat="server" MaxLength="8" 
                         ToolTip="Ex: 20121030"></asp:TextBox></td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ErrorMessage="*" ControlToValidate="txtDateOfCommencement"></asp:RequiredFieldValidator>
                    
                     <asp:RangeValidator ID="RangeValidator3" runat="server" 
                         ControlToValidate="txtDateOfCommencement" 
                         ErrorMessage="Enter Correct Format" ForeColor="Red" 
                         MaximumValue="99999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                    
                 </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Date of Calculation</td>
                <td>
                    <asp:TextBox ID="txtDateOfCalculation" runat="server" MaxLength="8" ></asp:TextBox></td>
            
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="*" ControlToValidate="txtDateOfCalculation" ForeColor="Red"></asp:RequiredFieldValidator></td>
                <td>
                  First Day of the Calculation Date</td>
                <td>
                     <asp:TextBox ID="txtDateOfFirstDayOfCalculation" runat="server" MaxLength="8"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="*" ControlToValidate="txtDateOfFirstDayOfCalculation"></asp:RequiredFieldValidator>

<asp:RangeValidator ID="RangeValidator5" runat="server" 
                         ControlToValidate="txtDateOfFirstDayOfCalculation" 
                         ErrorMessage="Enter Correct Format" ForeColor="Red" 
                         MaximumValue="99999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                  </td>
            </tr>
             <tr>
             <td>
                    &nbsp;</td>
                <td>SwarnaJayanthi Last Pay Date
                 </td>
                <td>
                    <asp:TextBox ID="txtSJLastPayDate" runat="server" Text="0" 
                        ToolTip="Ex 20120531 or if there are no Start Date,Set to 0" MaxLength="8"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="*" ControlToValidate="txtSJLastPayDate" ForeColor="Red"></asp:RequiredFieldValidator></td>
                <td>
                Calculation Type
                 </td>
                <td>
                    
                    <asp:DropDownList ID="ddlCalcType" runat="server">
                        <asp:ListItem Text= "Death" Value ="death"> </asp:ListItem>
                         <asp:ListItem Text= "Refund" Value ="refund"> </asp:ListItem>
                          <asp:ListItem Text= "Maturity" Value ="maturity" Selected="True"> </asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
                <td>
                </td>
                     
            </tr>

             <tr>
             <td>
                    &nbsp;</td>
                <td>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" 
                        ControlToValidate="txtDateOfCalculation" 
                        ErrorMessage="Date of Calculation not in correct format" ForeColor="Red" 
                        MaximumValue="99999999" MinimumValue="0" ToolTip="Ex 20120430" Type="Integer"></asp:RangeValidator>
                 </td>
                <td>
                 
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtSJLastPayDate" 
                        ErrorMessage="SwarnaJayanthi Last Pay Date not in correct format" 
                        ForeColor="Red" MaximumValue="999999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                 
                </td>

                <td></td>
                <td>
                                        
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                        ControlToValidate="txtPolNo" ErrorMessage="Policy Number not in correct format<br/>" 
                        MaximumValue="999999999" MinimumValue="1" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                    
                    
                </td>
                <td>
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" 
                        onclick="btnCalculate_Click" />
                </td>
                     
            </tr>
            <tr>
             <td>
                    &nbsp;</td>
                <td>
                 </td>
                <td>
                 
                    &nbsp;</td>

                <td></td>
                <td>
                    
                    &nbsp;</td>
                <td>
                
                </td>
                     
            </tr>
        </table>

    <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True">
    
   
    </asp:GridView>
    <br />
      

    <table >
        <tr>
            <th>
                &nbsp;
            </th>
            <th width="200">
                &nbsp;
            </th>
            <th width="200">
                &nbsp;
            </th>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
               <asp:Label ID="Label1" runat="server" Text= "Total Accumulation Amount :" 
                    Font-Bold="True" ></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                 <asp:Label ID="lblRefund" runat="server" Text="Total Refundable Amount :" 
                     Font-Bold="True"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="lblRefundableAmount" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <%--<asp:Button ID="Button1" runat="server" Text="Test Button" 
        onclick="Button1_Click" />--%>
        <br />    <br />    <br />
    </form>
</body>
</html>
