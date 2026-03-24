<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RefundMiniDthChld.aspx.cs" Inherits="RefundMiniDthChld" %>
<%@ PreviousPageType VirtualPath="~/dthPay002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body onload = "window.print()">
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 700px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Our Ref:L/Claims/1/
                        <asp:Literal ID="litclm" runat="server"></asp:Literal></span></td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    <span style="text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA"><strong style="text-decoration: underline">Discharge of Policy
                            No.
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></strong></span></td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 32px; height: 9px">
                </td>
                <td colspan="3" style="height: 9px; text-align: justify">
                    <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        On the life of
                        <asp:Literal ID="litnamedec" runat="server"></asp:Literal>
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            (deceased ) I
                            <asp:Literal ID="litnameass" runat="server"></asp:Literal>
                            <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                being the 1<sup>st</sup> life and the Proposer, do hereby acknowledge receipt from
                                the above-named Corporation,<span style="mso-spacerun: yes">&nbsp; </span>the sum
                                of
                                <asp:Literal ID="litamt_inword" runat="server"></asp:Literal>
                                <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                    (Rs
                                    <asp:Literal ID="litamt" runat="server"></asp:Literal>
                                    ) <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                        Being the refund of all premiums paid under the above-mentioned policy upon the
                                        death of the Beneficiary (according to its Policy Conditions) in full satisfaction
                                        and discharge of all my claims and demands under the said policy and which policy
                                        is hereby delivered up to the said Corporation to be cancelled.</span></span></span></span></span></td>
                <td style="font-size: 10pt; width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px">
                    <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">Dated at ....................................<span style="font-family: Trebuchet MS">
                            <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                this...........................&nbsp;
                                <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                    mso-bidi-language: AR-SA">of&nbsp; .........................</span></span></span></span></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 11px">
                </td>
                <td style="width: 248px; height: 11px">
                </td>
                <td colspan="2" style="height: 11px; text-align: right">
                    <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp; &nbsp; </span>
                </td>
                <td style="width: 100px; height: 11px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 19px">
                </td>
                <td style="width: 248px; height: 19px">
                </td>
                <td colspan="2" style="height: 19px; text-align: right">
                    .....................................</td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 21px">
                </td>
                <td style="width: 248px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: right">
                    Signature of Declaring &nbsp;&nbsp; &nbsp;</td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px; text-align: left">
                    .................................................</td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left">
                        Signature of Justice of Peace/Magistrate/</p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left">
                        <span style="mso-spacerun: yes">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
                        Commissioner of oaths</p>
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">Name &nbsp;&nbsp; .................................................</span></td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">Address .................................................</span></td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; .................................................</td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; .................................................</td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; .................................................</td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td style="width: 248px; height: 10px">
                </td>
                <td style="width: 140px; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        Official Seal</p>
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 32px; height: 10px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="width: 558px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
