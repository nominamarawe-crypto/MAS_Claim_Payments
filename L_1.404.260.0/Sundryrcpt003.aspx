<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sundryrcpt003.aspx.cs" Inherits="Sundryrcpt003" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/sundryrcpt002.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 706px; font-family: 'Trebuchet MS'; text-align: center">
            <tr>
                <td colspan="4" style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px; text-align: center">
                    <strong>SUNDRY RECEIPT DETAILS</strong></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    CLAIM NUMBER</td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litclm" runat="server"></asp:Literal></td>
                <td style="width: 160px; height: 15px; text-align: left">
                </td>
                <td style="width: 125px; height: 15px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 160px; height: 15px; background-color: #f0f0f0; text-align: left">
                </td>
                <td style="width: 136px; height: 15px; background-color: #f0f0f0; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    POLICY NUMBER</td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litpol" runat="server"></asp:Literal></td>
                <td style="width: 160px; height: 15px; text-align: left">
                    COMMENCEMENT DATE</td>
                <td style="width: 125px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="litcomdt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    TABLE/TERM</td>
                <td style="font-weight: normal; width: 150px; height: 15px; text-align: left">
                    :<asp:Literal ID="littbtr" runat="server"></asp:Literal></td>
                <td style="width: 160px; height: 15px; text-align: left; font-size: 10pt;">
                    <font face="Trebuchet MS" size="2">GROUP IND./P.A. CODE NO</font></td>
                <td style="width: 125px; height: 15px; text-align: left">
                    <strong>:</strong><asp:Literal ID="LITPACD" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="height: 15px; text-align: left" colspan="4">
                    RECEIVED FROM &nbsp;&nbsp;
                    <asp:Literal ID="litnm" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px; text-align: left">
                    &nbsp;<asp:Literal ID="litamtwd" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    <strong>AS INDICATED BELOW :</strong></td>
                <td colspan="2" style="height: 15px; text-align: center">
                    <strong>DIFFERENCE OF PREMIUMS</strong></td>
                <td style="width: 125px; height: 15px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; text-align: left">
                    <strong><span style="text-decoration: underline">DUE YEAR MONTH</span></strong></td>
                <td style="width: 150px; height: 15px; text-align: left">
                    <strong><span style="text-decoration: underline"><font face="Trebuchet MS" size="2">
                        PREMIUM AMOUNT</font></span></strong></td>
                <td style="width: 160px; height: 15px; text-align: left">
                    <strong><span style="text-decoration: underline">DUE YEAR MONTH</span></strong></td>
                <td style="width: 125px; height: 15px; text-align: left">
                    <strong><span style="text-decoration: underline"><font face="Trebuchet MS" size="2">
                        PREMIUM AMOUNT</font></span></strong></td>
            </tr>
            <tr>
                <td style="width: 146px; height: 15px; text-align: left;">
                    <asp:Literal ID="litdueyrmn" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px; text-align: left;">
                <asp:Literal ID="litprmfst" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px;">
                </td>
                <td style="width: 146px; height: 15px;">
                </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 15px; text-align: left">
                    <asp:Literal ID="litnxtdue" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px; text-align: left">
                    <asp:Literal ID="litprmnxt" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px">
                </td>
                <td style="width: 146px; height: 15px">
                </td>
            </tr>
                       
            <% 
                 int i=1;
                 int j = 1;
                int k=1;
                 double yearlyprm1 = 0.0;
                 double yearlyprm2 = 0.0;
                 int year =int.Parse( comdt.ToString().Substring(0, 4));
                 int mnth = int.Parse(comdt.ToString().Substring(4, 2));          
                for (int count = 1; count <= paiddue; count++)
                {                    
                    if (prms1.Count >= count)
                    {
                        yearlyprm1 = double.Parse(prms1[count-1].ToString());                        
                    }
                    year = year + 1;
                    litdueyrmn1.Text = year.ToString() + "/" + mnth.ToString();
                    if (prms2.Count >= count)
                    {
                        
                        yearlyprm2 = double.Parse(prms2[count-1].ToString());
                       
                    }
                    year = year + 1;
                    litdueyrmn2.Text = year.ToString() + "/" + mnth.ToString();
                   lityrlyprm.Text = yearlyprm1.ToString();
                   lityrlyprm2.Text = yearlyprm2.ToString(); 
                    
                             
            %>
            <tr>
            <%
                if (i <= paiddue)
                {
                    
            %>
                <td style="width: 146px; height: 15px; text-align: left">
                    &nbsp;<asp:Literal ID="litdueyrmn1" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px; text-align: left">
                    <asp:Literal ID="lityrlyprm" runat="server"></asp:Literal></td>
            <%
                    j++;
                }
                i++;               
                if (i <= paiddue)
                {
            %>
                <td style="width: 146px; height: 15px; text-align: left;">
                    <asp:Literal ID="litdueyrmn2" runat="server"></asp:Literal></td>
                <td style="width: 146px; height: 15px">
                    <asp:Literal ID="lityrlyprm2" runat="server"></asp:Literal></td>
            </tr>
            <%  
                    k++;          
                }
                i++;
                 } 
            %>
            <tr>
                <td colspan="4" style="height: 15px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 15px; background-color: #f0f0f0" colspan="4">
                    <asp:Table ID="Table1" runat="server" Width="509px">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px">
                </td>
                <td style="width: 150px; height: 15px">
                </td>
                <td style="width: 160px; height: 15px">
                </td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px; text-align: left">
                    <asp:Label ID="lblmsg" runat="server" Width="570px" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px">
                </td>
                <td style="width: 150px; height: 15px">
                    <asp:Button ID="Btn_sub" runat="server" OnClick="Btn_sub_Click"
                        Text="Print" Width="103px" /></td>
                <td style="width: 160px; height: 15px">
                    </td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 150px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 160px; height: 15px; background-color: #f0f0f0">
                </td>
                <td style="width: 146px; height: 15px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 168px; height: 15px">
                </td>
                <td style="width: 150px; height: 15px">
                </td>
                <td style="width: 160px; height: 15px">
                </td>
                <td style="width: 125px; height: 15px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hdfepf" runat="server" />
        <asp:HiddenField ID="hdfbrn" runat="server" />
    </form>
</body>
</html>
