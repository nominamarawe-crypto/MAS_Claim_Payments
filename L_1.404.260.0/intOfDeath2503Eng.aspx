<%@ Page Language="C#" AutoEventWireup="true" CodeFile="intOfDeath2503Eng.aspx.cs" Inherits="intOfDeath2501Eng" %>

<%@ PreviousPageType VirtualPath="~/dthreq002.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="X-UA-Compatible" content="IE=6" />
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .auto-style1 {
            height: 18px;
        }

        .auto-style2 {
            height: 18px;
        }

        .auto-style3 {
            height: 18px;
        }

        .auto-style4 {
            height: 18px;
        }

        .auto-style5 {
            height: 18px;
        }

        .auto-style6 {
            height: 18px;
        }

        .auto-style7 {
            height: 20px;
        }

        .auto-style8 {
            height: 20px;
        }

        .auto-style9 {
            height: 20px;
        }


    </style>
</head>
<script language="JavaScript" type="text/JavaScript">
<!--
    function MM_goToURL() { //v3.0
        var i, args = MM_goToURL.arguments; document.MM_returnValue = false;
        for (i = 0; i < (args.length - 1); i += 2) eval(args[i] + ".location='" + args[i + 1] + "'");
    }
//-->
</script>

<body style="text-align: center; background-color: #eeeeee">
    <form id="form1" runat="server">

        <%

//try
//{
//    //string CopyToName = "";
//    //string CopyToAddress1 = "";
//    //string CopyToAddress2 = "";
//    //string CopyToAddress3 = "";
//    //string CopyToAddress4 = "";
//    //string CopyToAddress5 = "";
//    int Index = 0;

//    foreach (ArrayList CopyArr in CopyToArr)
//    {
//        Index++;
//        if (Index == 1)
//        {
//            litCopy.Text = "CUSTOMER  COPY";
//            lblcopy1desc.Visible = false;                    
//            litcopy1.Visible = false;
//            litcopy2.Visible = false;
//            litcopy3.Visible = false;
//            litcusno.Visible = false;
//        }
//        if (Index == 2)
//        {
//            litCopy.Text = "BRANCH  COPY";
//            ArrayList CopyToArr2 = (ArrayList)CopyToArr[1];
//            if (CopyToArr2.Count != 0)
//            {
//                lblcopy1desc.Visible = true;
//               string BRCOPY=CopyToArr2[0].ToString()+CopyToArr2[1].ToString()+CopyToArr2[2].ToString()+CopyToArr2[3].ToString()+CopyToArr2[4].ToString();
//               litcopy1.Text = BRCOPY;
//               litcopy1.Visible = true;
//            }
//            if (CopyToArr.Count >= 3)
//            {
//                ArrayList CopyToArr3 = (ArrayList)CopyToArr[2];
//                if (CopyToArr3.Count != 0)
//                {                             
//                    string BRCOPY1 = CopyToArr3[0].ToString() + CopyToArr3[1].ToString() + CopyToArr3[2].ToString() + CopyToArr3[3].ToString() + CopyToArr3[4].ToString();
//                    litcopy2.Text = BRCOPY1;
//                }
//                litcopy2.Visible = true;
//            }
//            if (CopyToArr.Count == 4)
//            {
//                ArrayList CopyToArr4 = (ArrayList)CopyToArr[3];
//                if (CopyToArr4.Count != 0)
//                {
//                    string BRCOPY2 =  CopyToArr4[0].ToString() + " , " + CopyToArr4[1].ToString() + CopyToArr4[2].ToString() + CopyToArr4[3].ToString() + CopyToArr4[4].ToString() + CopyToArr4[5].ToString();
//                    litcopy3.Text = BRCOPY2;

//                }  litcopy3.Visible = true;
//            } 
//            litcusno.Visible = true;
//        }
//        if (Index == 3)
//        {
//            litCopy.Text = "CLOSER BRANCH  COPY";

//            lblcopy1desc.Visible = true;                    
//            litcopy1.Visible = true;
//            litcopy2.Visible = true;
//            litcusno.Visible = true;                     
//        }
//        if (Index == 4)
//        {
//            litCopy.Text = "INSURANCE ADVISORS'  COPY";

//            lblcopy1desc.Visible = true;                     
//            litcopy1.Visible = true;
//            litcopy2.Visible = true;
//            litcopy3.Visible = true;
//            litcusno.Visible = true;
//        }
//    }
//}
//catch
//{ }
        %>
        <div id="printDiv" style="text-align: center; width: 630px; background-color: white; padding: 0px 0px; margin-right: auto; margin-left: auto">
            <table style="width: 100%; font-size: 9pt;">
                <tr>
                    <td style="width: 10px; height: 0px"></td>
                    <td style="width: 190px; height: 0px"></td>
                    <td style="width: 135px; height: 0px; "></td>
                    <td style="width: 135px; height: 0px; "></td>
                    <td style="width: 150px; height: 0px; "></td>
                    <td style="width: 10px; height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px;"></td>
                    <td style="height: 20px; text-align: center; border: 1px solid black" colspan="2">

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">LI/DC/FO/SE/05</strong>
                    </td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 18px"></td>
                    <td style="height: 18px; text-align: left" colspan="2">

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">WITHOUT PREJUDICE &nbsp;&nbsp; </strong>
                    </td>
                    <td style="height: 18px"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">Form No. 2503 </strong>
                    </td>
                    <td class="auto-style3"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td colspan="4" style="height: 20px; text-align: center; font-weight: bold; font-size: 9pt; font-family: 'Trebuchet MS';">
                        <asp:Literal ID="litCopy" runat="server" Visible="False"></asp:Literal></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left; padding-top: 10px;" colspan="2">

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">REGISTERED POST</strong></td>
                    <td></td>
                    <td style="height: 20px; text-align: left; font-size: 9pt; padding: 0px;" >
                        <span style="font-size: 9pt; font-family: Trebuchet MS;">Your ref:</span><br />
                        <br />
                        <span style="font-size: 9pt; font-family: Trebuchet MS; border: 1px solid black; padding: 0px;">Our Ref:L/Claims/1/<asp:Literal
                            ID="litorref" runat="server"></asp:Literal></span></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left;" colspan="2">

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">Telephone No: 2357247/2357225/2357290/2357252  
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2357253/2357205/2357221
                        </strong></td>
                    <td></td>
                    <td style="height: 20px; text-align: left; font-size: 9pt; padding: 0px;" colspan="1">Date :
                    <asp:Label ID="lbldate" runat="server" Font-Names="Trebuchet MS" Font-Size="9pt"></asp:Label></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td colspan="2" style="height: 20px; text-align: left"></td>
                    <td colspan="2" style="font-size: 9pt; height: 20px; text-align: right"></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="5">
                        <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="5">
                        <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="5">
                        <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="5">
                        <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="5">
                        <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                </tr>

                <tr style="font-size: 9pt">
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; font-size: 9pt; padding-top: 5px; font-family: 'Trebuchet MS';" colspan="2">Dear Sir/Madam,<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                        prefix="o" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></td>
                    <td style="height: 8px;"></td>
                    <td style="height: 8px;"></td>
                    <td style="height: 8px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left; padding-top: 5px;" colspan="4">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <u>Life Policy No :<asp:Literal ID="litpolno" runat="server"></asp:Literal></u></strong>
                    </td>
                    <td style="height: 8px"></td>
                </tr>
                <tr>
                    <td style="height: 8px"></td>
                    <td style="height: 8px; text-align: left;" colspan="4">


                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'"><u>On the Life
                            of
                                <asp:Literal ID="litnameofdead"
                                    runat="server"></asp:Literal>(Deceased)</u></strong>
                    </td>
                    <td style="height: 8px; font-size: 9pt;"></td>
                </tr>
                <tr>
                    <td style="height: 6px"></td>
                    <td style="height: 6px; text-align: justify; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="4">We refer to your claim &nbsp;consequent to the death of the
                            Life Assured under the above policy.
                            
                            <span id="otherDesc" runat="server">Please return at your earliest the enclosed Claim Forms duly filled in together
                            with the other documents listed below, to enable us to consider our liability under
                            the Policy.
                            </span>
                    </td>
                    <td style="height: 6px; font-size: 9pt;"></td>
                </tr>

                <tr style="font-size: 9pt">
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left; padding-top: 5px;" colspan="5">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litrClmFrom" Text="CLAIMS FORMS" runat="server" Visible="false"></asp:Literal></strong>

                    </td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td colspan="4" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: justify; text-justify: auto;">
                        <asp:Table ID="tblClmForm" runat="server" Width="100%" HorizontalAlign="Justify" CaptionAlign="Top" Font-Size="9pt" BorderWidth="0px" Font-Names="Trebuchet MS" Style="text-align: justify; padding-left: 15px;">
                        </asp:Table>
                    </td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left;" colspan="5">
                        <strong id="otherDesc2" runat="server" style="font-size: 9pt; font-family: 'Trebuchet MS'">OTHER DOCUMENTS. Original (Photocopies of these certificates are not acceptable)</strong>

                    </td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td colspan="4" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: justify; text-justify: auto;">
                        <asp:Table ID="tblOtherDoc" runat="server" Width="100%" HorizontalAlign="Justify" CaptionAlign="Top" Font-Size="9pt" BorderWidth="0px" Font-Names="Trebuchet MS" Style="text-align: justify; padding-left: 15px;">
                        </asp:Table>
                    </td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>

                <tr>
                    <td class="auto-style7"></td>
                    <td colspan="4" style="text-justify: auto; font-size: 9pt; font-family: 'Trebuchet MS'; text-align: justify"
                        class="auto-style8">
                        <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
                    <td style="font-size: 9pt;" class="auto-style9"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td colspan="4" style="text-justify: auto; font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: justify">
                        <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 20px"></td>
                    <td colspan="4" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: justify; text-justify: auto;">
                        <asp:Literal ID="litreq24" runat="server"></asp:Literal></td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>
                <tr>
                    <%--<td style="width: 10px; height: 20px">
                </td>--%>
                    <td colspan="5" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: justify; text-justify: auto;">
                        <asp:Table ID="tblNotices" Width="100%" runat="server" HorizontalAlign="Justify" CaptionAlign="Top" Font-Size="9pt" BorderWidth="0px" Font-Names="Trebuchet MS" Style="text-align: justify; margin-left: 0px;">
                        </asp:Table>
                    </td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>

                <%--<tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="height: 20px; text-align: justify; font-size: 9pt; padding-top:5px; font-family: 'Trebuchet MS';" colspan="4">
                       Claim forms should be signed by the nominee of this policy.  Please send the certified copy of the NIC of the nominee. If the Nominee was minor, the claim forms should be signed by the Father/Mother/Guardian of the child.</td>
                <td style="width: 37px; height: 20px; font-size: 9pt;">
                </td>
            </tr>--%>
                <tr id="desc1" runat="server">
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: justify; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="4">We would kindly request your prompt attention in this matter as your claim on this policy cannot be processed until you submit above mentioned requirements, </td>
                    <td style="height: 20px; font-size: 9pt;"></td>
                </tr>
                <tr>
                    <td style="height: 6px"></td>
                    <td style="height: 6px; text-align: left;" colspan="4">
                        <asp:Literal ID="litreq23new" runat="server" Visible="false"></asp:Literal><br />
                        <asp:Literal ID="litreqAll" runat="server"></asp:Literal>
                    </td>
                    <td style="height: 6px"></td>
                </tr>

                <tr style="font-size: 9pt">
                    <td style="height: 6px"></td>
                    <td style="height: 6px">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litrEnclose" Text="Enclosed" runat="server" Visible="false"></asp:Literal></strong>
                    </td>
                    <td style="height: 6px; "></td>
                    <td style="height: 6px; "></td>
                    <td style="height: 6px; "></td>
                    <td style="height: 6px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 6px"></td>
                    <td style="height: 6px" colspan="4">
                        <asp:Table ID="tblEnclose" runat="server" Width="100%" HorizontalAlign="Justify" CaptionAlign="Top" Font-Size="9pt" BorderWidth="0px" Font-Names="Trebuchet MS" Style="text-align: justify; padding-left: 30px;">
                        </asp:Table>
                    </td>
                    <td style="height: 6px"></td>
                </tr>

                <tr style="font-size: 9pt">
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left;" colspan="2"></td>
                    <td></td>
                    <td style="height: 20px; text-align: left; padding: 0px 0px 0px 70px;" colspan="1">Yours faithfully</td>
                    <td style="height: 20px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: left;"></td>
                    <td colspan="2" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: left"></td>
                    <td></td>
                    <td colspan="1" style="font-size: 9pt; padding: 0px 0px 0px 70px; font-family: 'Trebuchet MS'; height: 20px; text-align: left">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">SRI LANKA INSURANCE CORPORATION LIFE LTD</strong>
                    </td>
                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: left"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 9px"></td>
                <td colspan="2" style="height: 9px; text-align: left"></td>
                <td></td>
                <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 9px; text-align:left; padding-left:70px">
			            <%--<asp:Label ID="lblSignature" runat="server" Text="" Visible="false"> </asp:Label>--%>
                    <asp:Panel runat="server" ID="lblSignature" Visible="false">
                        <asp:Image ID="SignatureImage" ImageUrl="~/Image/UserSignature.png" runat="server" style="width: 140px; height: 40px;" alt="signature" />
                    </asp:Panel>
		        </td>
                    <td style="height: 9px"></td>
                </tr>
                <tr style="font-size: 9pt; height: 5px; line-height:0px">
                    <td ></td>
                    <td style="text-align: left;" colspan="2"></td>
                    <td></td>
                    <td style=" font-size: 9pt; padding: 0px 0px 0px 70px; font-family: 'Trebuchet MS'; text-align: left;" colspan="1">....................................</td>
                    <td ></td>
                </tr>

                <tr style="font-size: 9pt;" id ="dis">
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left;" colspan="2"></td>
                    <td></td>
                    <td style="height: 20px; text-align: left" colspan="1">
                    <strong  style="font-size: 9pt; padding: 0px 0px 0px 70px; font-family: 'Trebuchet MS'"> 
			        For Life Manager </strong></td>
                    <td style="width: 37px; height: 20px; font-size: 9pt;">
                    </td>
                </tr>

                <tr style="font-size: 9pt">
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px; text-align: left;" colspan="2">
                        </td>
                    <td></td>
                    <td style="height: 20px; text-align:center; text-align :left; padding-left: 70px">
                        <asp:Label  ID="lblName" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblDesig" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lbldip" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblComp" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblepf" runat="server" Text="" Visible="false"> </asp:Label>
                    </td>
                    <td style="height: 20px; font-size: 9pt;">
                    </td>
                </tr>

                <tr>
                    <td style="height: 6px"></td>
                    <td style="height: 6px; text-align: left;" valign="top">
                        <asp:Label ID="lblcopy1desc" runat="server" Text="C.c To :- " Visible="true" Width="65px" Font-Names="Trebuchet MS" Font-Size="9pt"></asp:Label></td>
                    <td style="height: 6px; text-align: left; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="3" valign="top">
                        <asp:Literal ID="litcopy1" runat="server"></asp:Literal><br />
                        <asp:Literal ID="litcopy2" runat="server"></asp:Literal><br />
                        <asp:Literal ID="litcopy3" runat="server"></asp:Literal><br />
                        <asp:Literal ID="litcopy4" runat="server"></asp:Literal><br />
                        <asp:Literal ID="litcopy5" runat="server"></asp:Literal></td>
                    <td style="height: 6px"></td>
                </tr>
                <tr>
                    <td style="height: 5px"></td>
                    <td style="height: 5px; text-align: justify; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="4"></td>
                    <td style="height: 5px"></td>
                </tr>
                <tr>
                    <td style="height: 6px"></td>
                    <td colspan="4" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 6px; text-align: justify">
                        <asp:Literal ID="litcusno" runat="server" Text="(Please contact the claimant immediately and render all possible assistance in order to enable him/her to comply with the above requirements.)"></asp:Literal></td>
                    <td style="height: 6px"></td>
                </tr>
                <tr>
                    <td style="height: 6px"></td>
                    <td style="height: 6px; text-align: center;" colspan="4">&nbsp;</td>
                    <td style="height: 6px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 20px"></td>
                    <td style="height: 20px; text-align: left;" colspan="2"></td>
                    <td style="height: 20px;">&nbsp;</td>
                    <td style="height: 20px; text-align: left;">
                        <span style="font-size: 8.5pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"></span></td>
                    <td style="height: 20px"></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button ID="btnprint" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                Font-Size="10pt" PostBackUrl="~/intOfDeath2503Eng002.aspx" Text="  Print  " OnClientClick="cForm1(this.form1)" OnClick="btnprint_Click" Height="26px" Width="100px" />
            <asp:Button ID="btnExit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                Font-Size="10pt" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Text="  Exit  " Height="26px" Width="100px" />
            <asp:Button ID="btn_word" runat="server" Font-Bold="True" Height="26px" Text="Get Word Document" OnClick="btn_word_Click"
                Width="140px" PostBackUrl="~/intOfDeath2503Eng002.aspx" /><br />
        </div>
        &nbsp;
    </form>
</body>
<script type="text/javascript" language="javascript">
    function cForm1(form) {
        win = window.open('', 'myWin', "toolbars=1,scrollbars=1");
        form1.target = 'myWin';
        form1.action = 'intOfDeath2503Eng002.aspx';

    }
    function cForm8(form) {
        form1.target = '';
        form1.action = '';

    }

</script>
</html>
