<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCoverLetterSIn001.aspx.cs" Debug ="true" Inherits="AdmitCoverLetter" %>
<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link rel="stylesheet" href="Style/Stylefont.css" /> 
    <title>SRI LANKA INSURANCE DEATH CLAIM SYSTEM</title>
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
<body style="text-align: center" >
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

             foreach (ArrayList CopyToArr in CopyArray)
             {
                 Index++;
                 string Hascopy = "No";
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
                 if (Index == 1)
                 {
                     LITCUS.Text = "CUSTOMER   COPY";
                     litCopyto.Visible = false;                     
                     litbrName.Visible=false;
                     litbrad1.Visible=false;
                     litbrad2.Visible=false;
                     litbrad3.Visible = false;
                     litbtrad4.Visible = false;
                     
                     litagtname.Visible=false;
                     litagtad1.Visible=false;
                     litagtad2.Visible=false;
                     litagtad3.Visible=false;
                     litagtad4.Visible = false;

                     litto.Visible = false;
                     litCopyName.Visible = false;
                     Litcad1.Visible = false;
                     Litcad2.Visible = false;
                     Litcad3.Visible = false;
                     Litcad4.Visible = false;
                 }
                 
                 if (Index == 2)
                 {
                     Hascopy = "Yes";                     
                     //LITCUS.Text = "BRANCH   COPY";                    
                     litCopyto.Visible = true;  
                     //litbrName.Text = CopyToName;
                     //litbrad1.Text = CopyToAddress1;
                     //litbrad2.Text = CopyToAddress2;
                     //litbrad3.Text = CopyToAddress3;
                     //litbtrad4.Text = CopyToAddress4;

                     if (CopyArray.Count>2)
                     {
                         ArrayList CopyToArr2 = (ArrayList)CopyArray[2];
                         
                         litagtname.Visible = true;
                         litagtad1.Visible = true;
                         litagtad2.Visible = true;
                         litagtad3.Visible = true;
                         litagtad4.Visible = true;

                                               
                         litagtname.Text = CopyToArr2[0].ToString()+"(INSURANCE ADVISOR)";
                         litagtad1.Text = CopyToArr2[1].ToString();
                         litagtad2.Text = CopyToArr2[2].ToString();
                         litagtad3.Text = CopyToArr2[3].ToString();
                         litagtad4.Text = CopyToArr2[4].ToString();
                     }
                     if (CopyArray.Count > 1)
                     {
                         ArrayList CopyToArr3 = (ArrayList)CopyArray[1];
                         if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                         {                            

                             litagtname.Text = CopyToArr3[0].ToString() + "(INSURANCE ADVISOR)";
                             litagtad1.Text = CopyToArr3[1].ToString();
                             litagtad2.Text = CopyToArr3[2].ToString();
                             litagtad3.Text = CopyToArr3[3].ToString();
                             litagtad4.Text = CopyToArr3[4].ToString();
                         }
                         if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                         {
                             
                             litbrName.Text = CopyToName;
                             litbrad1.Text = CopyToAddress1;
                             litbrad2.Text = CopyToAddress2;
                             litbrad3.Text = CopyToAddress3;
                             litbtrad4.Text = CopyToAddress4;
                         }
                         

                         //Show postal Address
                         litCopyName.Text = CopyToArr3[0].ToString();
                         Litcad1.Text = CopyToArr3[1].ToString();
                         Litcad2.Text = CopyToArr3[2].ToString();
                         Litcad3.Text = CopyToArr3[3].ToString();
                         Litcad4.Text = CopyToArr3[4].ToString();
                     }
                 }
                 if (Index == 3)
                 {
                     Hascopy = "Yes";

                     litagtname.Text = CopyToName + "(INSURANCE ADVISOR)";
                     litagtad1.Text = CopyToAddress1;                     
                     litagtad2.Text = CopyToAddress2;
                    litagtad3.Text = CopyToAddress3;                   
                     litagtad4.Text = CopyToAddress4;
                     if (CopyToArr.Count>2)
                     { 
                         ArrayList CopyToArr4 = (ArrayList)CopyArray[2];
                         
                         litCopyName.Text =CopyToArr4[0].ToString();
                         Litcad1.Text = CopyToArr4[1].ToString();
                         Litcad2.Text = CopyToArr4[2].ToString();
                         Litcad3.Text = CopyToArr4[3].ToString();
                         Litcad4.Text = CopyToArr4[4].ToString();
                         Litcad5.Text = CopyToArr4[5].ToString();
                     }
                    
                 }
                 if (Hascopy == "Yes")
                 {
                     
                     if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                     {
                         
                         litbrName.Visible = true;
                         litbrad1.Visible = true;
                         litbrad2.Visible = true;
                         litbrad3.Visible = true;
                         litbtrad4.Visible = true;
                     }
                     if (CopyToArr[CopyToArr.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                     {                        
                         litagtname.Visible = true;
                         litagtad1.Visible = true;
                         litagtad2.Visible = true;
                         litagtad3.Visible = true;
                         litagtad4.Visible = true;
                     }
                     litto.Visible = true;
                     litCopyName.Visible = true;
                     Litcad1.Visible = true;
                     Litcad2.Visible = true;
                     Litcad3.Visible = true;
                     Litcad4.Visible = true;
                 }
                 
             %>
             <%}
         }
         catch
         { }
         %> 

    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
        <table style="width: 700px; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px">
                </td>
                <td style="width: 577px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px">
                </td>
                <td style="width: 577px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px">
                </td>
                <td style="width: 577px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 14px;">
                </td>
                <td style="width: 577px; height: 14px;">
                    <strong><span style="font-size: 11pt; font-family: Sandaya">s,shdmosxps ;emE,</span></strong></td>
                <td style="width: 100px; height: 14px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px; text-align: right;">
                    <strong>"<span style="font-size: 11pt; font-family: Sandaya">w.;s rys;hs</span>"</strong></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px; font-weight: bold; text-align: center;">
                    &nbsp;<asp:Literal ID="LITCUS" runat="server" Visible="False"></asp:Literal></td>
                <td style="width: 100px; height: 10px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; text-align: left; height: 10px;">
                    <span></span><span style="font-size: 11pt;">
                        wm fhduqj (<span style="font-family: Trebuchet MS">
                    </span>cS$ysusluz$1$<span style="font-family: Trebuchet MS"><span style="font-size: 10pt"><asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></span></td>
                <td style="width: 100px; height: 10px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <span>oskh (</span><span style="font-size: 10pt; font-family: Trebuchet MS"><asp:Literal ID="litDate" runat="server"></asp:Literal></span></td>
                <td style="width: 100px; height: 10px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <span>ms%h uy;auhdfKks$uy;aushks<span><span> </span></span></span>
                </td>
                <td style="width: 100px; height: 10px; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 11pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 11pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; font-weight: bold; height: 10px; text-decoration: underline;">
                    <span style="font-family: Sandaya">cSjs; rlaIK Tmamq wxlh(</span><span style="font-size: 10pt"><asp:Literal ID="litpolno" runat="server"></asp:Literal></span></td>
                <td style="width: 100px; height: 10px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 11pt; font-family: Sandaya;">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; font-weight: bold; height: 10px; text-decoration: underline;">
                    <span>rlaIs;(</span><span style="font-size: 10pt; font-family: Trebuchet MS"><asp:Literal ID="litdthname" runat="server"></asp:Literal></span> <span>^ush.sh&amp;</span></td>
                <td style="width: 100px; height: 10px; font-size: 11pt; font-family: Sandaya;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 15px;">
                </td>
                <td style="width: 577px; text-align: justify; height: 15px;">
                    <span style="font-size: 11pt; font-family: Sandaya">hf:dala; rlaIK Tmamqj hgf;a mek
                        ke.S we;s urK ysuslu iuznkaOfhka j.lSu ms,sf.k ms,S.ekSfuz ,smsh fuz iu. tjd we;'</span></td>
                <td style="width: 100px; height: 15px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 15px;">
                </td>
                <td style="width: 577px; text-align: justify; height: 15px;">
                    <span style="font-size: 11pt; font-family: Sandaya">ysusluz lghq;= ksrdlrKh lsrSu i|yd
                        my; olajd we;s wjYH;d wm fj; ,nd fok fuka ldreKslj okajuq'</span></td>
                <td style="width: 100px; height: 15px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 19px;">
                </td>
                <td style="width: 577px; height: 19px;">
                    <asp:Table ID="tblRequiremnt" runat="server" Width="575px" Font-Names="Sandaya" Font-Size="11pt" style="text-justify: auto; vertical-align: middle; text-align: justify" HorizontalAlign="Justify" Height="20px">
                    </asp:Table>
                </td>
                <td style="width: 100px; height: 19px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px">
                </td>
                <td style="font-size: 11pt; width: 577px; font-family: Sandaya; height: 10px">
                    <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px">
                </td>
                <td style="font-size: 11pt; width: 577px; font-family: Sandaya; height: 10px">
                    <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px">
                </td>
                <td style="width: 577px; height: 10px">
                    <span style="font-family: Sandaya"><span style="font-size: 11pt">
                        <asp:Literal ID="litreq21" runat="server"></asp:Literal></span></span><span style="font-family: Trebuchet MS"><span
                            style="font-size: 10pt"><asp:Literal ID="litnomname" runat="server"></asp:Literal><span
                                style="font-size: 11pt; font-family: Sandaya; text-justify: auto; text-align: justify;"><asp:Literal ID="litreq2" runat="server"></asp:Literal></span></span></span></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">ia;=;shs'</span></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">fuhg- jsYajdiS</span></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">YS% ,xld bkaIQrkaia fldamfrAIka ,hs*a ,susgvz</span></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    ................................</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px;">
                </td>
                <td style="width: 577px; height: 10px;">
                    <span style="font-size: 11pt; font-family: Sandaya">cSjs; l&lt;uKdlre fjkqjg</span></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px">
                </td>
                <td style="width: 577px; height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px">
                </td>
                <td style="height: 10px" colspan="2">
                    <table style="width: 580px">
                        <tr>
                            <td style="width: 58px; height: 10px">
                    <asp:Literal ID="litCopyto" runat="server" Text="Copy To :"></asp:Literal></td>
                            <td style="height: 10px" colspan="2">
                    <asp:Literal ID="litbrName" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbtrad4" runat="server"></asp:Literal><br />
                    <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                    <asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2" runat="server"></asp:Literal><asp:Literal ID="litagtad3" runat="server"></asp:Literal><br />
                                <asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                    </td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                                <asp:Literal ID="litto" runat="server" Text="TO :-"></asp:Literal></td>
                            <td colspan="2" style="height: 10px">
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
                        <tr>
                            <td style="width: 58px; height: 15px">
                            </td>
                            <td style="width: 113px; height: 15px">
                            </td>
                            <td style="width: 83px; height: 15px">
                            </td>
                        </tr>
                    </table>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 31px; height: 10px">
                </td>
                <td style="width: 577px; height: 10px; text-align: center;">
                    &nbsp;</td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
        </table>
        </asp:Panel>
       
 <asp:Button ID="btnprint" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" PostBackUrl="~/AdmitCoverLetterSIn002.aspx" Text="  Print  " OnClientClick="cForm1(this.form1)"  OnClick="btnprint_Click" Height="23px" Width="106px" /><asp:Button ID="btnExit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Text="  Exit  " Height="23px" Width="104px" />
                    <asp:Button ID="btn_word" runat="server" Font-Bold="True" Height="23px" OnClick="Button1_Click"
                        Text="Get Word Document" Width="148px" PostBackUrl="~/AdmitCoverLetterSIn002.aspx" /><br />
        <br />
      <table style="width: 700px">
            
        </table>
     
        <asp:HiddenField ID="hdfpol" runat="server" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
    <p class="break"></p>
    </div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp;
    </form>
</body>
<script type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='AdmitCoverLetterSIn002.aspx';

}
function cForm8(form)
{
 form1.target='';
 form1.action='';

}

</script>
</html>