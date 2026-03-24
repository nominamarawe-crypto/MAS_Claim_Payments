<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SundryPrint003.aspx.cs" Inherits="SundryPrint003" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/Sundryrcpt002.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<style type="text/css">
    .break{page-break-before:always}
    </style>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.print();
}

// ]]>
</script>
    
    <style type="text/css" media="print">
    .notprint
    {
      display:none;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 721px; font-family: 'Trebuchet MS'; height: 20px">
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                </td>
                <td style="width: 162px; height: 20px">
                </td>
                <td style="width: 163px; height: 20px">
                </td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: center">
                    <strong>SUNDRY RECEIPT DETAILS</strong></td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    CLAIM NUMBER</td>
                <td style="width: 162px; height: 20px">
                    :<asp:Literal ID="litclm" runat="server"></asp:Literal></td>
                <td style="width: 163px; height: 20px">
                </td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    POLICY NUMBER</td>
                <td style="width: 162px; height: 20px">
                    :<asp:Literal ID="litpol" runat="server"></asp:Literal></td>
                <td style="height: 20px; width: 163px;" colspan="1">
                    COMMENCEMENT DATE</td>
                <td style="width: 136px; height: 20px">
                    :<asp:Literal ID="litcomdt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    TABLE/TERM</td>
                <td style="width: 162px; height: 20px">
                    :<asp:Literal ID="littbtr" runat="server"></asp:Literal></td>
                <td style="height: 20px; width: 163px;" colspan="1">
                    GROUP IND./P.A. CODE NO</td>
                <td style="width: 136px; height: 20px">
                    :<asp:Literal ID="LITPACD" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    RECEIVED FROM
                </td>
                <td colspan="2" style="height: 20px">
                    <asp:Literal ID="litnm" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="3">
                    <asp:Literal ID="litamtwd" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    <strong>AS INDICATED BELOW :</strong></td>
                <td style="height: 20px; text-align: center;" colspan="2">
                    <strong>DIFFERENCE OF PREMIUMS</strong></td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    <strong><span style="text-decoration: underline">DUE YEAR MONTH</span></strong></td>
                <td style="width: 162px; height: 20px; text-align: center;">
                    <strong><span style="text-decoration: underline">PREMIUM AMOUNT</span></strong></td>
                <td style="width: 163px; height: 20px; text-align: center;">
                    <strong><span style="text-decoration: underline; text-align: center;">DUE YEAR MONTH</span></strong></td>
                <td style="width: 136px; height: 20px; text-align: center;">
                    <strong><span style="text-decoration: underline">PREMIUM AMOUNT</span></strong></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    <asp:Literal ID="litdueyrmn" runat="server"></asp:Literal></td>
                <td style="width: 162px; height: 20px; text-align: center;">
                    <asp:Literal ID="litprmfst" runat="server"></asp:Literal></td>
                <td style="width: 163px; height: 20px">
                </td>
                <td style="width: 136px; height: 20px; text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                    <asp:Literal ID="litnxtdue" runat="server"></asp:Literal></td>
                <td style="width: 162px; height: 20px; text-align: center;">
                    <asp:Literal ID="litprmnxt" runat="server"></asp:Literal></td>
                <td style="width: 163px; height: 20px">
                </td>
                <td style="width: 136px; height: 20px; text-align: left;">
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
                //for (int count = 1; count <= paiddue; count++)
                //for (int count = 1; count < paiddue; count++)
                 for (int count = 1; count < (paiddue - 1); count++)
                {
                    litdueyrmn1.Text = "";
                    lityrlyprm.Text = "";
                    litdueyrmn2.Text = "";
                    lityrlyprm2.Text = "";
                     
                    if (prms1.Count >= count)
                    {                        
                        yearlyprm1 = double.Parse(prms1[count-1].ToString());
                        year = year + 1;
                        
                        litdueyrmn1.Text = year.ToString() + "/" + mnth.ToString();
                        lityrlyprm.Text = yearlyprm1.ToString("N2");                                     
                    }
                    
                    if (prms2.Count >= count)
                    {                        
                        yearlyprm2 = double.Parse(prms2[count-1].ToString());
                        year = year + 1;
                        
                        litdueyrmn2.Text = year.ToString() + "/" + mnth.ToString();
                        lityrlyprm2.Text = yearlyprm2.ToString("N2"); 
                    }  
            %>
            <tr>
            <%
                if (i <= paiddue)
                //if (i < paiddue)
                {
                    
            %>
                <td style="width: 133px; height: 20px">
                    <asp:Literal ID="litdueyrmn1" runat="server"></asp:Literal></td>
                <td style="width: 162px; height: 20px; text-align: center;">
                    <asp:Literal ID="lityrlyprm" runat="server"></asp:Literal></td>
                    
            <%
                    j++;
                }
                i++;               
                if (i <= paiddue)
                //if (i < paiddue)
                {
            %>
                <td style="width: 163px; height: 20px; text-align: center;">
                    <asp:Literal ID="litdueyrmn2" runat="server"></asp:Literal></td>
                <td style="width: 136px; height: 20px; text-align: center;">
                    <asp:Literal ID="lityrlyprm2" runat="server"></asp:Literal></td>
            <%  
               k++;          
               }
               i++;
               } 
            %>  
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 133px; font-family: 'Trebuchet MS'; height: 20px">
                    <font face="Trebuchet MS" size="2" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                        INTEREST</font></td>
                <td style="font-size: 10pt; width: 162px; font-family: 'Trebuchet MS'; height: 20px">
                    :
                    <asp:Literal ID="litAgediffInt" runat="server"></asp:Literal></td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    TOTAL</td>
                <td style="width: 162px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :
                    <asp:Literal ID="LitTotamt" runat="server"></asp:Literal></td>
                <td style="width: 163px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';"></td>
                <td style="width: 163px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 20px">
                    REASONS FOR ALTERATION (IN BRIEF) : &nbsp;</td>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 20px;
                    text-align: left">
                    DIFFERENCE OF PREMIUM OF AGE HAVING BEEN UNDERSTATED/OVERSTATED.</td>
            </tr>
            <tr>
                <td colspan="4" style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS';
                    height: 20px">
                    <font face="Trebuchet MS" size="2" style="font-size: 10pt; font-family: 'Trebuchet MS';
                        text-align: justify">&nbsp; </font>
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    AGENT ' S CODE</td>
                <td style="width: 162px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :<asp:Literal ID="litagtcd" runat="server"></asp:Literal></td>
                <td style="width: 163px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <font face="Trebuchet MS" size="2" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                        ORGANIZER ' S CODE</font></td>
                <td style="width: 163px; height: 20px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    :<asp:Literal ID="litorgcd" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 133px; font-family: 'Trebuchet MS'; height: 20px">
                    <font face="Trebuchet MS" size="2" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                        RECEIPT ISSUED BY</font></td>
                <td style="font-size: 10pt; width: 162px; font-family: 'Trebuchet MS'; height: 20px">
                    :<asp:Literal ID="litepf" runat="server"></asp:Literal></td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                    <font face="Trebuchet MS" size="2" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                        DEPARTMENT</font></td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                    : LIFE CLAIMS</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="font-size: 10pt; width: 133px; font-family: 'Trebuchet MS'; height: 20px">
                    <font face="Trebuchet MS" size="2" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                        DATE OF ADJUSTMENT</font></td>
                <td style="font-size: 10pt; width: 162px; font-family: 'Trebuchet MS'; height: 20px">
                    :<asp:Literal ID="litdt" runat="server"></asp:Literal></td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 133px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 162px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 163px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 133px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 162px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 20px;
                    text-align: center">
                    .........................</td>
            </tr>
            <tr>
                <td style="font-size: 10pt; width: 133px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td style="font-size: 10pt; width: 162px; font-family: 'Trebuchet MS'; height: 20px">
                </td>
                <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 20px;
                    text-align: center">
                    FOR LIFE / REGIONAL MANAGER</td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                    <input id="Button1" style="font-weight: bold; width: 91px" type="button" value="Print" class="notprint" onclick="return Button1_onclick()" /></td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 162px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 163px; height: 20px; background-color: #f0f0f0">
                </td>
                <td style="width: 136px; height: 20px; background-color: #f0f0f0">
                </td>
            </tr>
            <tr>
                <td style="width: 133px; height: 20px">
                </td>
                <td style="width: 162px; height: 20px">
                </td>
                <td style="width: 163px; height: 20px">
                </td>
                <td style="width: 136px; height: 20px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hdfepf" runat="server" />
        <asp:HiddenField ID="hdfbrn" runat="server" />
    </form>
</body>
</html>
