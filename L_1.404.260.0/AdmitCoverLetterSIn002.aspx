<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCoverLetterSIn002.aspx.cs" Debug ="true" Inherits="AdmitCoverLetter" %>
<%@ PreviousPageType VirtualPath="~/AdmitCoverLetterSIn001.aspx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
    .break{page-break-before:always}
    @font-face {
            font-family: "Sandaya";
            src: url("fonts/SANDHYA.woff2") format("woff2"),
                 url("fonts/SANDHYA.woff") format("woff"),
                 url("fonts/SANDHYA.ttf") format("truetype"),
                 url("fonts/SANDHYA.eot") format("embedded-opentype"),
                 url("fonts/SANDHYA.svg#Sandaya") format("svg");
            font-weight: normal;
            font-style: normal;
        }
    </style>
</head>
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
</script>
<body onload ="window.print()">
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
                     if (CopyArray.Count >= 2)
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

                     if (CopyArray.Count >= 2)
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
                 //if (Index == 1)
                 //{
                 //    //LITCUS.Text = "CUSTOMER   COPY";
                 //    litCopyto.Visible = false;
                 //    litcopyto1.Visible = false;
                 //    litbrName.Visible = false;
                 //    litbrad1.Visible = false;
                 //    litbrad2.Visible = false;
                 //    litbrad3.Visible = false;
                 //    litbtrad4.Visible = false;

                 //    litcopyto2.Visible = false;
                 //    litagtcode.Visible = false;
                 //    litagtname.Visible = false;
                 //    litagtad1.Visible = false;
                 //    litagtad2.Visible = false;
                 //    litagtad3.Visible = false;
                 //    litagtad4.Visible = false;

                 //    litto.Visible = false;
                 //    litCopyName.Visible = false;
                 //    Litcad1.Visible = false;
                 //    Litcad2.Visible = false;
                 //    Litcad3.Visible = false;
                 //    Litcad4.Visible = false;
                 //}

                 //if (Index == 2)
                 //{
                 //    Hascopy = "Yes";
                 //    //LITCUS.Text = "BRANCH   COPY";                    
                 //    litCopyto.Visible = true;
                 //    //litbrName.Text = CopyToName;
                 //    //litbrad1.Text = CopyToAddress1;
                 //    //litbrad2.Text = CopyToAddress2;
                 //    //litbrad3.Text = CopyToAddress3;
                 //    //litbtrad4.Text = CopyToAddress4;
                 //    if (CopyToArr[CopyToArr.Count - 1].ToString() == "Customer Copy")
                 //    {
                 //        Cus_copy = true;
                 //    }
                 //    if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                 //    {
                 //        Br_Copy = true;
                 //    }
                 //    if (CopyToArr[CopyToArr.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                 //    {
                 //        Ins_Adv_Copy = true;
                 //    }
                 //    if (CopyArray.Count > 2)
                 //    {
                 //        ArrayList CopyToArr2 = (ArrayList)CopyArray[2];

                 //        litagtcode.Visible = true;
                 //        litagtname.Visible = true;
                 //        litagtad1.Visible = true;
                 //        litagtad2.Visible = true;
                 //        litagtad3.Visible = true;
                 //        litagtad4.Visible = true;

                 //        litcopyto2.Visible = true;
                 //        litagtcode.Text = CopyToArr2[6].ToString();
                 //        litagtname.Text = CopyToArr2[0].ToString();
                 //        litagtad1.Text = CopyToArr2[1].ToString();
                 //        litagtad2.Text = CopyToArr2[2].ToString();
                 //        litagtad3.Text = CopyToArr2[3].ToString();
                 //        litagtad4.Text = CopyToArr2[4].ToString();
                 //    }
                 //    if (CopyArray.Count > 1)
                 //    {
                 //        ArrayList CopyToArr3 = (ArrayList)CopyArray[1];
                 //        if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                 //        {
                 //            litcopyto2.Visible = true;
                 //            litcopyto1.Visible = false;
                 //            litagtcode.Text = CopyToArr3[6].ToString();
                 //            litagtname.Text = CopyToArr3[0].ToString();
                 //            litagtad1.Text = CopyToArr3[1].ToString();
                 //            litagtad2.Text = CopyToArr3[2].ToString();
                 //            litagtad3.Text = CopyToArr3[3].ToString();
                 //            litagtad4.Text = CopyToArr3[4].ToString();
                 //        }
                 //        if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                 //        {
                 //            litcopyto1.Visible = true;
                 //            litcopyto2.Visible = false;
                 //            litbrName.Text = CopyToName;
                 //            litbrad1.Text = CopyToAddress1;
                 //            litbrad2.Text = CopyToAddress2;
                 //            litbrad3.Text = CopyToAddress3;
                 //            litbtrad4.Text = CopyToAddress4;
                 //        }


                 //        //Show postal Address
                 //        litCopyName.Text = CopyToArr3[0].ToString();
                 //        Litcad1.Text = CopyToArr3[1].ToString();
                 //        Litcad2.Text = CopyToArr3[2].ToString();
                 //        Litcad3.Text = CopyToArr3[3].ToString();
                 //        Litcad4.Text = CopyToArr3[4].ToString();
                 //    }
                 //}
                 //if (Index == 3)
                 //{
                 //    Hascopy = "Yes";

                 //    litcopyto2.Visible = true;
                 //    litagtcode.Text = CopyToArr[6].ToString();
                 //    litagtname.Text = CopyToName;
                 //    litagtad1.Text = CopyToAddress1;
                 //    litagtad2.Text = CopyToAddress2;
                 //    litagtad3.Text = CopyToAddress3;
                 //    litagtad4.Text = CopyToAddress4;
                 //    if (CopyToArr.Count > 2)
                 //    {
                 //        ArrayList CopyToArr4 = (ArrayList)CopyArray[2];

                 //        litCopyName.Text = "Agent Code :" + CopyToArr4[6].ToString() + "," + CopyToArr4[0].ToString();
                 //        Litcad1.Text = CopyToArr4[1].ToString();
                 //        Litcad2.Text = CopyToArr4[2].ToString();
                 //        Litcad3.Text = CopyToArr4[3].ToString();
                 //        Litcad4.Text = CopyToArr4[4].ToString();
                 //        Litcad5.Text = CopyToArr4[5].ToString();
                 //    }

                 //}
                 //if (Hascopy == "Yes")
                 //{

                 //    if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                 //    {
                 //        litcopyto1.Visible = true;
                 //        litbrName.Visible = true;
                 //        litbrad1.Visible = true;
                 //        litbrad2.Visible = true;
                 //        litbrad3.Visible = true;
                 //        litbtrad4.Visible = true;
                 //    }
                 //    if (CopyToArr[CopyToArr.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                 //    {
                 //        litcopyto2.Visible = true;
                 //        litagtcode.Visible = true;
                 //        litagtname.Visible = true;
                 //        litagtad1.Visible = true;
                 //        litagtad2.Visible = true;
                 //        litagtad3.Visible = true;
                 //        litagtad4.Visible = true;
                 //    }
                 //    litto.Visible = true;
                 //    litCopyName.Visible = true;
                 //    Litcad1.Visible = true;
                 //    Litcad2.Visible = true;
                 //    Litcad3.Visible = true;
                 //    Litcad4.Visible = true;
                 //}
                 
                 
             %>

    <div style="text-align: center">
       
        <table style="width: 628px; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
            <tr>
                <td style="width: 16px; height: 20px;">
                </td>
                <td style="width: 582px; height: 20px;">
                </td>
                <td style="width: 20px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 20px">
                </td>
                <td style="width: 582px; height: 20px">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 20px">
                </td>
                <td style="width: 582px; height: 20px">
                </td>
                <td style="width: 20px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 20px;">
                </td>
                <td style="width: 582px; height: 20px;">
                </td>
                <td style="width: 20px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 20px;">
                </td>
                <td style="width: 582px; height: 20px;">
                    <strong><span style="font-size: 11pt; font-family: Sandaya">s,shdmosxps ;emE,</span></strong></td>
                <td style="width: 20px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px; text-align: right;">
                    <strong>"<span style="font-size: 11pt; font-family: Sandaya">w.;s rys;hs</span>"</strong></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px; height: 18px;">
                </td>
                <td style="width: 582px; height: 18px;">
                </td>
                <td style="width: 20px; height: 18px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px; height: 13px;">
                </td>
                <td style="width: 582px; text-align: left; height: 13px;">
                    <span></span><span>
                        wm fhduqj (<span style="font-size: 10pt; font-family: Trebuchet MS">
                    </span>cS$ysusluz$1 $<span style="font-size: 10pt; font-family: Trebuchet MS"><asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></td>
                <td style="width: 20px; font-size: 11pt; font-family: Sandaya; height: 13px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px">
                </td>
                <td style="width: 582px">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px">
                </td>
                <td style="width: 582px">
                    <span>oskh (<span style="font-size: 10pt; font-family: Trebuchet MS"><asp:Literal ID="litDate" runat="server"></asp:Literal></span></span>
                    </td>
                <td style="width: 20px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px">
                </td>
                <td style="width: 582px">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                </td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <span style="font-family: Sandaya"><span style="font-size: 11pt">ms%h uy;auhdfKks$uy;aushks<span><span style="font-family: Sandaya"> </span></span></span></span>
                </td>
                <td style="width: 20px; height: 10px; font-size: 11pt;">
                </td>
            </tr>
            <tr style="font-size: 11pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                </td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; font-weight: bold; height: 10px; text-decoration: underline;">
                    <span style="font-family: Sandaya">cSjs; rlaIK Tmamq wxlh(</span><asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; font-weight: bold; height: 10px; text-decoration: underline;">
                    <span style="font-size: 11pt; font-family: Sandaya">rlaIs;(</span>
                    <asp:Literal ID="litdthname" runat="server"></asp:Literal>
                    <span style="font-family: Sandaya"><span style="font-size: 11pt">
                    &nbsp; <span>^ush.sh&amp;</span></span></span></td>
                <td style="width: 20px; height: 10px; font-size: 10pt; font-family: Trebuchet MS;">
                </td>
            </tr>
            <tr style="font-size: 10pt; font-family: Trebuchet MS;">
                <td style="width: 16px; height: 22px;">
                </td>
                <td style="width: 582px; height: 22px;">
                </td>
                <td style="width: 20px; height: 22px;">
                </td>
            </tr>
            <tr style="font-size: 10pt; font-family: Trebuchet MS;">
                <td style="width: 16px">
                </td>
                <td style="width: 582px; text-align: justify;">
                    <span style="font-size: 11pt; font-family: Sandaya">hf:dala; rlaIK Tmamqj hgf;a mek
                        ke.S we;s urK ysuslu iuznkaOfhka j.lSu ms,sf.k ms,S.ekSfuz ,smsh fuz iu. tjd we;'</span></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                </td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px">
                </td>
                <td style="width: 582px; text-align: justify;">
                    <span style="font-size: 11pt; font-family: Sandaya">ysusluz lghq;= ksrdlrKh lsrSu i|yd
                        my; olajd we;s wjYH;d wm fj; ,nd fok fuka ldreKslj okajuq'</span></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                </td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 37px;">
                </td>
                <td style="width: 582px; text-justify: auto; text-align: justify; height: 37px;">
                    <asp:Table ID="tblRequiremnt" runat="server" Width="579px" Font-Names="Sandaya" Font-Size="11pt" HorizontalAlign="Justify" Height="20px" style="text-justify: auto; text-align: justify">
                    </asp:Table>
                </td>
                <td style="width: 20px; height: 37px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px">
                </td>
                <td style="font-size: 11pt; width: 582px; font-family: Sandaya; height: 10px">
                    <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px">
                </td>
                <td style="font-size: 11pt; width: 582px; font-family: Sandaya; height: 10px">
                    <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px">
                </td>
                <td style="width: 582px; height: 10px">
                    <span style="font-size: 11pt; font-family: Sandaya">
                        <asp:Literal ID="litreq21" runat="server"></asp:Literal>
                    </span><span style="font-size: 10pt; font-family: Trebuchet MS">
                        <asp:Literal ID="litnomname" runat="server"></asp:Literal>
                        <span style="font-size: 11pt; font-family: Sandaya; text-justify: auto; text-align: justify;">
                            <asp:Literal ID="litreq2" runat="server"></asp:Literal></span></span></td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">ia;=;shs'</span></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                </td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">fuhg- jsYajdiS</span></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">YS% ,xld bkaIQrkaia fldamfrAIka ,hs*a ,susgvz</span></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                </td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    ................................</td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px;">
                </td>
                <td style="width: 582px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">cSjs; l&lt;uKdlre fjkqjg</span></td>
                <td style="width: 20px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px">
                </td>
                <td style="width: 582px; height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 16px; height: 10px">
                </td>
                <td style="height: 10px" colspan="2">
                    <table style="width: 578px">
                        <tr>
                            <td style="width: 58px; height: 18px">
                    <asp:Literal ID="litCopyto" runat="server" Text="Copy To :"></asp:Literal></td>
                    <%
                        if (Br_Copy == true)
                        {
                                 %> 
                            <td style="height: 18px" colspan="2">
                    <asp:Literal ID="litbrName" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbtrad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 16px">
                            </td>
                            <td style="height: 16px" colspan="2">
                    <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                    <asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2" runat="server"></asp:Literal><asp:Literal ID="litagtad3" runat="server"></asp:Literal><br />
                                <asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                        </tr>
                        <%
                        }
                  %>
                  
                  <% 
                 if (Ins_Adv_Copy == true)
                     {
                               %>
                        <%
                      }
                  %>
                        <tr>
                            <td style="width: 58px; height: 15px">
                            </td>
                            <td colspan="2" style="height: 15px">
                    </td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 8px">
                                <asp:Literal ID="litto" runat="server" Text="TO :-"></asp:Literal></td>
                            <td colspan="2" style="height: 8px">
                                <asp:Literal ID="litCopyName" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad1" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad2" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad3" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad5" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table> <p class="break"></p>       
        <br />
        <br />    
     
    
    </div>
    <%}
    }
    catch
    { }
   %>         
            
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='AdmitCoverLetterEng002.aspx';

}
function cForm8(form)
{
 form1.target='';
 form1.action='';

}

</script>
</html>