<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PregressSin001.aspx.cs" Inherits="letters_PregressSin001" %>
<%@ PreviousPageType VirtualPath="~/dthPro002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/JavaScript">
    function textDisplay()
    {
        var CkValue = document.getElementById('CheckBox1').checked;
        
        if(CkValue == true)
        {
            document.getElementById('LbText').style.display = '';
        }
        else
        {
            document.getElementById('LbText').style.display = 'none';
        }
    }
        
    </script>
    
    <style type="text/css" media="print">
.BTN
{
	display:none;
	visibility:hidden;
	NoNavButtons:Disables; 
}
</style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div>
        <table style="width: 666px">
            <tr>
                <td colspan="2" style="height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <span style="font-size: 12pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">wm fhduqj(cS$ysusluz$&nbsp;<span style="font-size: 10pt;
                            font-family: Trebuchet MS">
                            <asp:Literal ID="LtClmno" runat="server"></asp:Literal></span></span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                    <asp:Label ID="lbldate" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"
                        Width="125px"></asp:Label></td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px; font-size: 10pt; font-family: 'Trebuchet MS';" colspan="2">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya">ms%h uy;auhdKks$uy;aushks</span>,<span style="font-family: Sandaya"><?xml
                            namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml namespace=""
                                prefix="O" ?><o:p></o:p></span></p>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <span style="font-size: 12pt; font-family: Sandaya; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA"><strong>cSjs; rlaIK Tmamq wxlh( <span style="font-size: 10pt;
                            font-family: Trebuchet MS">
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></span></strong></span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <span style="font-size: 12pt; font-family: Sandaya; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA"><strong>rlaIs; <span style="font-size: 10pt; font-family: Trebuchet MS">
                            <asp:Literal ID="litnameofdead" runat="server"></asp:Literal>
                            &nbsp; <span style="font-family: Sandaya"><span style="font-size: 12pt; font-family: Sandaya;
                                mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                ^ush.sh&amp;</span></span></span></strong></span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya">by; urK ysuslu iuznkaOj Tn jsiska tjk ,o f,aLK wm
                            fj; ,ens we;</span>.</p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya"></span>&nbsp;</p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        &nbsp;</p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya">ysuslfuz bosrs lghq;= isoqlruska mj;sk w;r bosrsfhaoS
                            ta iuznkaOj Tn fj; fkdmudj okajd tjSug lghq;= lrk nj ldreKslj okajuq</span>.</p>
                    <p>
                        <asp:CheckBox ID="CheckBox1" runat="server"  onclick = "textDisplay()" CssClass="BTN"/>
                        <asp:Label ID="LbText" runat="server" Font-Names="Sandaya" Font-Size="12pt" Width="487px">Tnf.a b,a,Su mrsos urK iy;slfha uq,a msgm; fuz iu. tjuq</asp:Label></p>
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya">fuhg - jsYajdiS<o:p></o:p></span></p>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" colspan="2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya">YS% ,xld bka<b style="mso-bidi-font-weight: normal">I</b>qjrkaia fldamfrAIka ,hs*a ,susgvz<o:p></o:p></span></p>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Sandaya">cSjs; l&lt;uKdlre fjkqjg<o:p></o:p></span></p>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
