<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secondReq001.aspx.cs" Inherits="secondReq001" %>

<%@ PreviousPageType VirtualPath="~/dthreq002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style type="text/css">    
     .leftmargin
    {
        margin-left:20px;
    } 
    .tableTextAlign
    {
        text-align:justify;
    } 
    .englishWord
    { 
        text-align:justify;
    } 
</style> 
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 640px; font-size: 10pt;">
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px; font-weight:bold; font-size: 11pt;" colspan="2" align="left">
                Registered Post</td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="height: 20px; font-weight:bold; font-size: 11pt;" colspan="2" align="right">
                “WITHOUT PREJUDICE”</td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                Our Ref : L/Claims/1/D/ <asp:Label ID="ltlClaimNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                <asp:Label ID="lblLetterDate" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                <asp:Label ID="lblName" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                <asp:Label ID="lblAdd1" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr><tr>
                <td style="height: 20px" colspan="5" align="left">
                <asp:Label ID="lblAdd2" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr><tr>
                <td style="height: 20px" colspan="5" align="left">
                <asp:Label ID="lblAdd3" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr><tr>
                <td style="height: 20px" colspan="5" align="left">
                <asp:Label ID="lblAdd4" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                Dear Sir / Madam,</td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                <u><b>Life Policy No : <asp:Label ID="lblPolNo" runat="server"></asp:Label></b></u></td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                <u><b>On the Life of <asp:Label ID="lblNameofDeath" CssClass="englishWord" runat="server"></asp:Label> (deceased)</b></u></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                We write with reference to the death claim submitted under the above policy and acknowledge the documents.</td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <asp:Panel ID="pnlPendingReq" runat="server" Visible="false">
             <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                In order to process this claim pleases send us the following documents which we requested from our <asp:Label ID="lblFirstDate" CssClass="englishWord" runat="server"></asp:Label> dated letter.</td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                <asp:Table ID="tblFirstReq" CssClass="englishWord" runat="server"></asp:Table></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="pnlSecReq" CssClass="englishWord" runat="server" Visible="false">
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                <asp:Label ID="txtSecReqDescription" CssClass="englishWord" runat="server"></asp:Label>
                <%--Additional to above requirements please send us the following documents.--%></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                <asp:Table ID="tblSecReq" CssClass="englishWord" runat="server"></asp:Table></td>
            </tr>
            <asp:Panel ID="pnlNom" runat="server" Visible="false">
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                <asp:Label ID="lblSecondReq" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            </asp:Panel>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="pnlAddWord" runat="server" Visible="false">
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                <asp:Label ID="lblAddWord" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            </asp:Panel>
            <tr>
                <td style="height: 20px" colspan="5" class="tableTextAlign">
                Therefore, we kindly request you to forward us the above documents to process this claim further. Your earlier attention in this regard will help us to finalize this claim without delay.</td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                Thanking you,</td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                Yours faithfully,</td>
            </tr>
            <tr>
                <td style="height: 20px; padding-top:10px;" colspan="5" align="left">
                Sri Lanka Insurance Corporation Life Ltd</td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 9px; text-align :left">
                    <%--<asp:Label ID="lblSignature" runat="server" Text="" Visible="false"> </asp:Label>--%>
                    <asp:Panel runat="server" ID="lblSignature" Visible="false">
                            <asp:Image ID="SignatureImage" ImageUrl="~/Image/UserSignature.png" runat="server" style="width: 140px; height: 40px;" alt="signature" />
                        </asp:Panel>
                </td>
            </tr> 
            <tr>
                <td style="height: 20px" colspan="5" align="left">
                For Life Manager</td>
            </tr>
            <tr>
                <td style="height: 20px; text-align:center; text-align :left;" colspan="3">
                   <asp:Label  ID="lblSigName" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblDesig" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lbldip" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblComp" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblepf" runat="server" Text="" Visible="false"> </asp:Label>
                    </td>
                
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
            </tr>
            
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <asp:Panel ID="pnlPrintCopy" runat="server" Visible="false">
            <tr>
                <td style="height: 20px" align="left" colspan="5">
                Copy :-<asp:Label ID="lblPrintCopy" CssClass="englishWord leftmargin" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            </asp:Panel>
            <%--<asp:Panel ID="pnlPrintTo" runat="server" Visible="false">
            <tr>
                <td style="width: 100px; height: 20px" align="left">
                fhuqj (</td>
                <td style="width: 540px; height: 20px" colspan="4" align="left">
                <asp:Label ID="lblPrintTo" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            </asp:Panel>--%>
            <tr>
                <td style="height: 20px; font-size:8pt;" colspan="5" align="left">
                <b>Our contact Nos. 2357247  /  2357225  /  2357290  /  2357252  /  2357253  /  2357205  /  2357221</b></td>
            </tr>
            <tr>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
                <td style="width: 128px; height: 20px;">
                </td>
                <td style="width: 128px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="height: 20px" colspan="5">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" PostBackUrl="~/secondReq002.aspx"
                        Text="Print" Width="91px" Font-Bold="True" />
                <asp:Button ID="btnExit" runat="server" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue"
                            Text="  Exit  " Width="96px" Font-Bold="True"/>
                <asp:Button ID="btn_word" runat="server" OnClick="btn_word_Click" PostBackUrl="~/secondReq002.aspx" Text="Get Word Document"
                                Width="148px" Font-Bold="True"/></td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
