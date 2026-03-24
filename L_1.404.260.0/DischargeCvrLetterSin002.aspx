<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DischargeCvrLetterSin002.aspx.cs" Inherits="letters_DischargeCvrLetter" %>
<%@ PreviousPageType VirtualPath="~/dischargeCvrLetterSin.aspx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Discharge Cver </title>
    <style type="text/css">
    .break{page-break-before:always}
    @font-face {
    font-family: "Sandaya";
    src: url("fonts/SANDHYA.woff2");
    src: local("Sandaya"),url("fonts/SANDHYA.woff2"),url("fonts/SANDHYA.ttf"),url("fonts/SANDHYA.woff"),url("fonts/SANDHYA.eot"),url("fonts/SANDHYA.svg");
    font-weight: normal;
    font-style: normal;
}
    </style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <%
       
         try
         {
             string CopyToName = "";
             string CopyToAddress1 = "";
             string CopyToAddress2 = "";
             string CopyToAddress3 = "";
             string CopyToAddress4 = "";
             string CopyToAddress5 = "";
             int Index = 0;
             bool Cus_copy = false;
             bool Br_Copy = false;
           
             bool Ins_Adv_Copy = false;

             foreach (ArrayList CopyToArr in CopyArray)
             {
                
                 
                 Index++;
//                 string Hascopy = "No";
                 if (CopyToArr[0] != null) { CopyToName = CopyToArr[0].ToString(); }
                 else { CopyToName = ""; }
                 if (CopyToArr[1] != null) { CopyToAddress1 = CopyToArr[1].ToString(); }
                 else { CopyToAddress1 = ""; }
                 if (CopyToArr[2] != null) { CopyToAddress2 = CopyToArr[2].ToString(); }
                 else { CopyToAddress2 = ""; }
                 if (CopyToArr[3] != null) { CopyToAddress3 = CopyToArr[3].ToString(); }
                 else { CopyToAddress3 = ""; }
                 if (CopyToArr[4] != null) { CopyToAddress4 = CopyToArr[4].ToString(); }
                 else { CopyToAddress4 = ""; }
                 if (CopyToArr[5] != null) { CopyToAddress5 = CopyToArr[5].ToString(); }
                 else { CopyToAddress5 = ""; }
                 if (Index == 1)  ///// hide the addresses
                 {
                     litto.Visible = false; litCopyto.Visible = false;
                    litbrName.Visible = false; litbrad1.Visible = false;
                     litbrad2.Visible = false; litbrad3.Visible = false; litbtrad4.Visible = false;
                      litagtname.Visible = false;
                     litagtad1.Visible = false; litagtad2.Visible = false; litagtad3.Visible = false;
                     litagtad4.Visible = false; litto.Visible = false; litCopyName.Visible = false;
                     Litcad1.Visible = false; Litcad2.Visible = false; Litcad3.Visible = false;
                     Litcad4.Visible = false; 
                 }

                 if (Index == 2)
                 {
                      litCopyto.Visible = true; litto.Visible = true;
                     litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                     Litcad4.Visible = true;
                     if (CopyArray.Count >= 1)
                     {
                         if (CopyToArr[CopyToArr.Count - 1].ToString() == "Customer Copy")
                         {
                             Cus_copy = true;
                         }
                         if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                         {
                             Br_Copy = true;
                             litbrName.Text = CopyToName;
                             litbrad1.Text = CopyToAddress1;
                             litbrad2.Text = CopyToAddress2;
                             litbrad3.Text = CopyToAddress3;
                             litbtrad4.Text = CopyToAddress4;
                             litbrName.Visible = true;
                             litbrad1.Visible = true;
                             litbrad2.Visible = true;
                             litbrad3.Visible = true;
                             litbtrad4.Visible = true;

                         }

                         if (CopyToArr[CopyToArr.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                         {
                             Ins_Adv_Copy = true;
                             litagtname.Text = CopyToName + "(Insurance Advisor)";
                             litagtad1.Text = CopyToAddress1;
                             litagtad2.Text = CopyToAddress2;
                             litagtad3.Text = CopyToAddress3;
                             litagtad4.Text = CopyToAddress4;
                             litagtname.Visible = true;
                             litagtad1.Visible = true;
                             litagtad2.Visible = true;
                             litagtad3.Visible = true;
                             litagtad4.Visible = true;
                         }
                         litCopyName.Visible = true;
                         Litcad1.Visible = true;
                         Litcad2.Visible = true;
                         Litcad3.Visible = true;
                         Litcad4.Visible = true;

                     }
                     if (CopyArray.Count >= 3)
                     {
                         
                         ArrayList CopyToArr2 = (ArrayList)CopyArray[2];

                         if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                         {
                             if (CopyToArr2.Count != 0)
                             {
                                 Ins_Adv_Copy = true;
                                 //litagtcode.Text = CopyToArr2[6].ToString() + "(Insurance Advisor)";
                                 litagtname.Text = CopyToArr2[0].ToString() + "(INSURANCE ADVISOR)";
                                 litagtad1.Text = CopyToArr2[1].ToString();
                                 litagtad2.Text = CopyToArr2[2].ToString();
                                 litagtad3.Text = CopyToArr2[3].ToString();
                                 litagtad4.Text = CopyToArr2[4].ToString();

                                // litagtcode.Visible = true;
                                 litagtname.Visible = true;
                                 litagtad1.Visible = true;
                                 litagtad2.Visible = true;
                                 litagtad3.Visible = true;
                                 litagtad4.Visible = true;
                             }
                         }

                     }
                   
                     litCopyName.Text = CopyToName;
                     Litcad1.Text = CopyToAddress1;
                     Litcad2.Text = CopyToAddress2;
                     Litcad3.Text = CopyToAddress3;
                     Litcad4.Text = CopyToAddress4;
                 }
                 if (Index == 3)
                 {
                     litCopyto.Visible = true; litto.Visible = true;
                     litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                     Litcad4.Visible = true;

                     if (CopyArray.Count >= 3)
                     {
                         ArrayList CopyToArr2 = (ArrayList)CopyArray[2];

                         if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                         {
                             if (CopyToArr2.Count != 0)
                             {
                                 Ins_Adv_Copy = true;
                                 //litagtcode.Text = CopyToArr2[6].ToString() + "(Insurance Advisor)";
                                 litagtname.Text = CopyToArr2[0].ToString() + "(INSURANCE ADVISOR)";
                                 litagtad1.Text = CopyToArr2[1].ToString();
                                 litagtad2.Text = CopyToArr2[2].ToString();
                                 litagtad3.Text = CopyToArr2[3].ToString();
                                 litagtad4.Text = CopyToArr2[4].ToString();

                                 //litagtcode.Visible = true;
                                 litagtname.Visible = true;
                                 litagtad1.Visible = true;
                                 litagtad2.Visible = true;
                                 litagtad3.Visible = true;
                                 litagtad4.Visible = true;
                             }
                             litCopyName.Text = CopyToName;
                             Litcad1.Text = CopyToAddress1;
                             Litcad2.Text = CopyToAddress2;
                             Litcad3.Text = CopyToAddress3;
                             Litcad4.Text = CopyToAddress4;
                         }
                         else if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "File Copy")
                         {
                             if (CopyToArr2.Count != 0)
                             {
                                 Ins_Adv_Copy = true;
                                 
                                 //litagtcode.Text = CopyToArr2[6].ToString() + "(Insurance Advisor)";
                                 litagtname.Text = CopyToArr2[0].ToString();
                                 litagtad1.Text = CopyToArr2[1].ToString();
                                 litagtad2.Text = CopyToArr2[2].ToString();
                                 litagtad3.Text = CopyToArr2[3].ToString();
                                 litagtad4.Text = CopyToArr2[4].ToString();

                                 //litagtcode.Visible = true;
                                 litagtname.Visible = true;
                                 litagtad1.Visible = true;
                                 litagtad2.Visible = true;
                                 litagtad3.Visible = true;
                                 litagtad4.Visible = true;

                                 litbrName.Visible = true;
                                 litbrad1.Visible = true;
                                 litbrad2.Visible = true;
                                 litbrad3.Visible = true;
                                 litbtrad4.Visible = true;

                                 litto.Visible = false;
                                 litCopyName.Visible = false;
                                 Litcad1.Visible = false;
                                 Litcad2.Visible = false;
                                 Litcad3.Visible = false;
                                 Litcad4.Visible = false;
                             }
                         }

                     }                     
                     
                 }
                                 
             %>
    <div>
        <table style="width: 700px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 34px; font-family: Trebuchet MS; height: 10px">
                </td>
                <td style="height: 10px; font-family: Trebuchet MS;" colspan="2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal"><span style="font-size: 12pt"><span style="font-family: Sandaya">
                            ,shdmosxps ;emE,<?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml
                                namespace="" prefix="O" ?><o:p></o:p></span></span></b></p>
                </td>
                <td style="height: 10px; font-family: Trebuchet MS; font-size: 10pt;" colspan="2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span><span style="font-family: Times New Roman">‘</span><span style="font-size: 11pt;
                            font-family: Sandaya">w.;s rys;hs</span><span style="font-size: 11pt; font-family: Times New Roman">’</span><span
                                style="font-size: 11pt; font-family: Sandaya"><o:p></o:p></span><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="1" style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: 'Trebuchet MS'"><span style="font-size: 11pt; font-family: Sandaya">
                            wm fhduqj(cS$ysusluz$1$</span><asp:Literal ID="litclm"
                            runat="server"></asp:Literal></span></p>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                    <asp:Literal ID="litdt" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td colspan="2" style="height: 9px">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                        mso-bidi-language: AR-SA; mso-ansi-language: EN-US; mso-fareast-language: EN-US">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">ms%h uy;auhdKks$uy;aushks</span><span
                            style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-bidi-font-family: 'Times New Roman'; mso-bidi-language: AR-SA; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US">,</span></span></span></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="1" style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <span style="text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                        mso-bidi-font-family: 'Times New Roman'; mso-bidi-language: AR-SA; mso-ansi-language: EN-US;
                        mso-fareast-language: EN-US"><strong style="font-size: 10pt; font-family: 'Trebuchet MS';
                            text-decoration: underline"><span style="font-size: 11pt; font-family: Sandaya">cSjs;
                                rlaIK Tmamq wxlh(</span><asp:Literal ID="litpolno" runat="server"></asp:Literal></strong></span></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="1" style="width: 34px; height: 9px">
                </td>
                <td style="height: 9px" colspan="2">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; text-decoration: underline;
                        mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                        mso-bidi-language: AR-SA; mso-ansi-language: EN-US; mso-fareast-language: EN-US">
                        <strong style="font-size: 10pt; font-family: 'Trebuchet MS'; text-decoration: underline">
                            <span style="font-size: 11pt; font-family: Sandaya">rlaIs;&nbsp;</span>
                            <asp:Literal ID="litdesname" runat="server"></asp:Literal>&nbsp; <span style="font-size: 11pt;
                                font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                mso-bidi-language: AR-SA; mso-ansi-language: EN-US; mso-fareast-language: EN-US">
                                ^ush.sh&amp;</span></strong></span></td>
                <td style="width: 100px; height: 9px; font-size: 10pt;">
                </td>
                <td style="width: 100px; height: 9px; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="1" style="width: 34px; height: 9px">
                </td>
                <td colspan="3" style="height: 9px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: 'Trebuchet MS'"><span style="font-size: 11pt"><span style="font-family: Sandaya">
                            hf:dala; rlaIK Tmamqj hgf;a mek ke.S we;s urK ysuslu iuznkaOfhka j.lSu ms&lt;sf.k
                            we;s nj i;=gska okajd isgsuq</span><span style="font-family: Times New Roman">.</span></span></span></p>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 3px">
                </td>
                <td style="width: 109px; height: 3px">
                </td>
                <td style="width: 100px; height: 3px">
                </td>
                <td style="width: 100px; height: 3px">
                </td>
                <td style="width: 100px; height: 3px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td colspan="1" style="width: 34px; font-family: Trebuchet MS; height: 9px">
                </td>
                <td style="height: 9px; font-family: Trebuchet MS;" colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">ysusluz lghq;= ksrdlrKh
                            lsrSu i|yd fuz iu. ms&lt;sfh, lr tjd we;s f.jd ksu lsrsfuz l=js;dkaish yd jeo.;a
                            ksfjzokh Tn jsiska ksis mrsos iuzmQrAK lr wm fj; tjk f,i ldreKslj okajd isgsuq</span><span
                                style="font-family: Times New Roman">.</span></span></p>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 3px">
                </td>
                <td style="width: 109px; height: 3px">
                </td>
                <td style="width: 100px; height: 3px">
                </td>
                <td style="width: 100px; height: 3px">
                </td>
                <td style="width: 100px; height: 3px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                    <span style="mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                        mso-bidi-language: AR-SA; mso-ansi-language: EN-US; mso-fareast-language: EN-US">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">fuhg - jsYajdiS<?xml
                            namespace="" prefix="O" ?><o:p></o:p></span></span></span></td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; font-family: Trebuchet MS; height: 9px">
                </td>
                <td style="font-family: Trebuchet MS; height: 9px" colspan="2">
                    <span style="font-size: 11pt"><span style="font-family: Sandaya">YS% ,xld bka<b style="mso-bidi-font-weight: normal">I</b>qjrkaia fldamfrAIka ,hs*a ,susgvz<o:p></o:p></span></span></td>
                <td style="font-size: 10pt; width: 100px; height: 9px">
                </td>
                <td style="font-size: 10pt; width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 14px">
                </td>
                <td style="width: 109px; height: 14px">
                </td>
                <td style="width: 100px; height: 14px">
                </td>
                <td style="width: 100px; height: 14px">
                </td>
                <td style="width: 100px; height: 14px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 17px">
                </td>
                <td style="width: 109px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; font-family: Trebuchet MS; height: 9px">
                </td>
                <td colspan="2" style="font-family: Trebuchet MS; height: 9px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">cSjs; l&lt;uKdlre fjkqjg<o:p></o:p></span></span></p>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 10px">
                </td>
                <td style="width: 109px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td colspan="3" style="height: 9px">
                    &nbsp;
                    <table style="width: 636px">
                        <tr>
                            <td style="width: 81px; height: 10px">
                                &nbsp;<asp:Literal ID="litCopyto" runat="server" Text="Copy To:-"></asp:Literal></td>
                            <%
                            if (Br_Copy)
                            {
                            %>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="litbrName" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2"
                                    runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbtrad4"
                                    runat="server"></asp:Literal></td>
                        </tr>
                        <%
                            }
                        %>
                        <% 
                 if (Ins_Adv_Copy)
                           {
                        %>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                                <asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2"
                                    runat="server"></asp:Literal>
                                <asp:Literal ID="litagtad3" runat="server"></asp:Literal><asp:Literal ID="litagtad4"
                                    runat="server"></asp:Literal></td>
                        </tr>
                        <%
                            }
                        %>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 10px">
                                <asp:Literal ID="litto" runat="server" Text="TO :-"></asp:Literal></td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="litCopyName" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad1" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad2" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad3" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad5" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 81px; height: 15px">
                            </td>
                            <td style="width: 107px; height: 15px">
                            </td>
                            <td style="width: 64px; height: 15px">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 9px">
                </td>
                <td colspan="3" style="height: 9px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 34px; height: 9px">
                </td>
                <td style="width: 109px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
        </table>
    <p class ="break"></p>
    </div>
    <%
     }
    }
      catch(Exception ex){ }
          
         %>
    </form>
</body>
</html>
