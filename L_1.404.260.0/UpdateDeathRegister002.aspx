<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateDeathRegister002.aspx.cs" Inherits="UpdateDeathRegister002" %>
<%@ PreviousPageType VirtualPath="~/UpdateDeathRegister001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    </head>
<script language="JavaScript" type="text/JavaScript">
<!--
    function MM_goToURL() { //v3.0
        var i, args = MM_goToURL.arguments; document.MM_returnValue = false;
        for (i = 0; i < (args.length - 1); i += 2) eval(args[i] + ".location='" + args[i + 1] + "'");
    }
//-->
</script>
<body>
<form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS">
        <span><span style="font-size: 14pt">
        </span></span></span>
        <table style="font-weight: normal; font-size: 10pt; width: 655px; font-family: 'Trebuchet MS';">
        <tr>
            <td colspan="6" style="height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 17px; background-color: #ffffff">
                <span style="font-weight: bold; font-size: 12pt; font-family: 'Trebuchet MS'">
                    <span style="font-weight: bold; font-size: 14pt">Sri Lanka Insurance<br />
                    </span>Manual Update Death Claim Register
                </span>
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0" colspan="4">
                <asp:Label ID="lblsucess" runat="server" ForeColor="LimeGreen" Text="Manual Details Successfully Updated"
                    Visible="False" Width="406px"></asp:Label></td>
            <td style="width: 25px; height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px"></td>
            <td style="width: 150px; height: 20px; text-align: left">Policy No.</td>
            <td style="width: 150px; height: 20px; text-align: left">:
                <asp:Label ID="lblpolno" runat="server" Font-Bold="True" Width="122px"></asp:Label>
            </td>
            <td style="width: 150px; height: 20px; text-align: left">Main Life or <span style="mso-fareast-font-family: 'Times New Roman';
                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    Spouse</span>
            </td>
            <td style="width: 150px; height: 20px; text-align: left">:
                <asp:Label ID="lblmof" runat="server" Font-Bold="True" Width="122px"></asp:Label>
            </td>
            <td style="width: 25px; height: 20px"></td>
        </tr>
         <tr>
            <td colspan="6" style="height: 20px; background-color: #f0f0f0"></td>
        </tr>            
        <tr style="color: #000000">
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Claim No</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:Label ID="lblClaimNo" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
            <td style="width: 150px; height: 20px; text-align: left">
                <%--Date of Intimation--%></td>
            <td style="width: 150px; height: 20px; text-align: left">
                <%--:
                <asp:Label ID="lbldtofintim" runat="server" Font-Bold="True" Width="92px"></asp:Label>--%></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: normal; height: 8px; background-color: #f0f0f0">
            </td>
            <td colspan="2" style="font-weight: normal; height: 8px; background-color: #f0f0f0;
                text-align: left"> </td>
            <td colspan="2" style="font-weight: normal; height: 8px; background-color: #f0f0f0;
                text-align: left">
                 </td>
        </tr> 
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Sum Assured</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:Label ID="lblsumassured" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
            <td style="width: 150px; height: 20px; text-align: left">
                Table/Term</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:Label ID="lbltab" runat="server" Font-Bold="True" Width="50px" Font-Italic="False"></asp:Label>
                <asp:Label ID="lblterm" runat="server" Font-Bold="True" Width="50px"></asp:Label>
            </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <%-- <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>--%>

         <%--<tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Policy Status</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:Label ID="lblPolStatus" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>--%>
        <tr>
            <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Name of Insured</td>
            <td colspan="3" style="height: 20px; text-align: left">
                :
                <asp:Label ID="lblnameofInsured" runat="server" Font-Bold="True" Width="440px"></asp:Label></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Address of Insured</td>
            <td colspan="3" style="height: 20px; text-align: left">
                :
                <asp:Label ID="lblassuredad1" runat="server" Font-Bold="True" Width="440px"></asp:Label></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
            </td>
            <td colspan="3" style="height: 20px; text-align: left">
                &nbsp;
                <asp:Label ID="lblassuredad2" runat="server" Font-Bold="True" Width="440px"></asp:Label></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Date of Comm.</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:Label ID="lbldtofcomm" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
            <td style="width: 150px; height: 20px; text-align: left">
                Date of Exit</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:Label ID="lbldtofexit" runat="server" Font-Bold="True" Width="122px"></asp:Label></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Civil or Forces</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :<asp:DropDownList ID="ddlcof" runat="server">
                        <asp:ListItem Value="C">Civil</asp:ListItem>
                        <asp:ListItem Value="A">Army</asp:ListItem>
                        <asp:ListItem Value="N">Navy</asp:ListItem>
                        <asp:ListItem Value="G">Air Force</asp:ListItem>
                        <asp:ListItem Value="P">Police</asp:ListItem>
                        <asp:ListItem Value="B">Buddhist Clergy</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 150px; height: 20px; text-align: left">
                </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
         <tr>
            <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0;
                text-align: left">
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0" colspan="4"> </td>
            <td style="width: 25px; height: 20px; background-color: #f0f0f0">
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Intimation Date</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtIntiDate" runat="server" Width="87px" Enabled="false" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                </td>
            <td style="width: 150px; height: 20px; text-align: left">
                </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <tr>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0; text-align:left">&nbsp;&nbsp; YYYYMMDD
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0; text-align:left"> 
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Confirmed Date</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtConfDate" runat="server" Width="87px" Enabled="false" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                Date Of Death</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtDtOfDth" runat="server" Width="87px" Enabled="false" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
         <tr>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0; text-align:left">&nbsp;&nbsp; YYYYMMDD
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0; text-align:left">&nbsp;&nbsp; YYYYMMDD
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Cause of Death</td>
            <td style="height: 20px; text-align: left" colspan="4">
                : 
                <asp:DropDownList ID="ddlDeathCause" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="DCAUSE" DataValueField="DSERIAL" Width="209px" Font-Names="Trebuchet MS" Font-Size="10pt">
                </asp:DropDownList> 
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DCAUSE, DSERIAL FROM LPHS.DCAUSEOFDTH">
                </asp:SqlDataSource>
                 
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Policy Completed</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:DropDownList ID="ddlPolComplete" runat="server">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                        <asp:ListItem Value="R">Repudiated</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 150px; height: 20px; text-align: left">Policy Status </td>
            <td style="width: 150px; height: 20px; text-align: left">: <asp:DropDownList ID="ddlPolStatus" runat="server">
                        <asp:ListItem Value="0">INT</asp:ListItem>
                        <asp:ListItem Value="1">REV</asp:ListItem>
                        <asp:ListItem Value="2">ACT</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0;
                text-align: left">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0" colspan="4"> </td>
            <td style="width: 25px; height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Is Exgracia</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:DropDownList ID="ddlIsExgracia" runat="server">
                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        
        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        <%--<tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Sum Assured on Exgracia</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtSumAssuredOnEx" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>--%>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Gross Claim</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtGrossClaim" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                Net Claim</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtNetClaim" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                ADB</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtADB" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                FPU</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtFPU" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                SJ</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtSJ" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">FE
                </td>
            <td style="width: 150px; height: 20px; text-align: left">:
                <asp:TextBox ID="txtFE" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Total Bonus</td>
            <td style="height: 20px; text-align: left" colspan="4">
                :
                <asp:TextBox ID="txtVestedBon" runat="server" Width="87px" Font-Bold="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;Vested
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtIntiBon" runat="server" Width="87px" Font-Bold="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;Interim</td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Deposits</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtDeposit" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">Default Premium
                </td>
            <td style="width: 150px; height: 20px; text-align: left">:
                <asp:TextBox ID="txtDefPre" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Default Interest</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtDefInt" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">Loan Capital
                </td>
            <td style="width: 150px; height: 20px; text-align: left">:
                <asp:TextBox ID="txtLoanCap" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Loan Interest</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtLoanInt" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">Other Deduction
                </td>
            <td style="width: 150px; height: 20px; text-align: left">:
                <asp:TextBox ID="txtOthDeduc" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
         <tr>
            <td colspan="6" style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0;
            text-align: left">
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0" colspan="4"> </td>
            <td style="width: 25px; height: 20px; background-color: #f0f0f0">
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Is Repudiated</td>
            <td style="height: 20px; text-align: left" colspan="4">
                :  <asp:RadioButtonList ID="rblIsRep" runat="server" RepeatDirection="Horizontal" Width="120px" Font-Bold="True">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Repudiated Reason</td>
            <td style="height: 20px; text-align: left" colspan="4">
                :
                <asp:TextBox ID="txtRepReason" runat="server" Width="300px" Font-Bold="True"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Repudiated Date</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtRepDate" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                </td>
            <td style="width: 150px; height: 20px; text-align: left"></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style=" height: 20px;  
            text-align: left; padding-left:185px" colspan="6">YYYYMMDD
            </td>
        </tr>

        <tr>
            <td style="border-bottom: black thin solid; height: 20px; background-color: #f0f0f0;
            text-align: left; padding-left:185px" colspan="6"> 
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0" colspan="4"> </td>
            <td style="width: 25px; height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Paid No.</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtPaidNo" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                Admin No.</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtAdminNo" runat="server" Width="87px" Font-Bold="True"></asp:TextBox></td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="height: 20px; background-color: #f0f0f0" colspan="6">
            </td>
        </tr>

        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                Paid Date</td>
            <td style="width: 150px; height: 20px; text-align: left">
                :
                <asp:TextBox ID="txtPaidDate" runat="server" Width="87px" Font-Bold="True" ></asp:TextBox></td>
            <td style="width: 150px; height: 20px; text-align: left">
                </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0; text-align:left">&nbsp;&nbsp; YYYYMMDD
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
            <td style="height: 20px; background-color: #f0f0f0">
            </td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px">
            </td>
            <td style="width: 150px; height: 20px; text-align: left">
                </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 150px; height: 20px; text-align: left"> </td>
            <td style="width: 25px; height: 20px">
            </td>
        </tr> 
        <tr>
            <td colspan="6" style="height: 20px">
                <asp:Button ID="btnUpdate" runat="server" Text="--Update--" Font-Bold="False" 
                    Font-Names="Trebuchet MS" Width="109px" onclick="btnUpdate_Click" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="10pt" ForeColor="Blue"
                            NavigateUrl="~/UpdateDeathRegister001.aspx"><<--Back</asp:HyperLink>
            </td>
        </tr>
        </table>
    </div>
</form>
    <%--<form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS">
        <span><span style="font-size: 14pt">
        </span></span></span>
        <table style="font-weight: normal; font-size: 10pt; width: 655px; font-family: 'Trebuchet MS';">
             
            
            
             
            
            
            
            
            
             
           </table>
    </div>
    </form>--%>
</body>
</html>
