<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lapseLetter002.aspx.cs" Inherits="lapseLetter002" %>
<%@ PreviousPageType VirtualPath="~/repudiation002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
     
     <style type="text/css">
    .break{page-break-before:always}

    </style>   
    
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
    
    
     function test(source, arguments)
    {
    	
     if (!IsNumeric(arguments.Value))
               {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
  function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}    
</script>
</head>
<body onload = "window.print()">
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
                     litname.Text = CopyToName;
                     litad1.Text = CopyToAddress1;
                     litad2.Text = CopyToAddress2;
                     litad3.Text = CopyToAddress3;
                     litad4.Text = CopyToAddress4;
                     
                     litCopyto.Visible = false;
                     litcopyto1.Visible=false;
                     litbrName.Visible=false;
                     litbrad1.Visible=false;
                     litbrad2.Visible=false;
                     litbrad3.Visible = false;
                     litbtrad4.Visible = false;
                     
                     litcopyto2.Visible=false;
                     litagtcode.Visible=false;
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
                     LITCUS.Text = "BRANCH   COPY";                    
                     litCopyto.Visible = true;  
                     litbrName.Text = CopyToName;
                     litbrad1.Text = CopyToAddress1;
                     litbrad2.Text = CopyToAddress2;
                     litbrad3.Text = CopyToAddress3;
                     litbtrad4.Text = CopyToAddress4;

                     ArrayList CopyToArr2 =(ArrayList) CopyArray[2];
                     
                     litagtcode.Visible = true;
                     litagtname.Visible = true;
                     litagtad1.Visible = true;
                     litagtad2.Visible = true;
                     litagtad3.Visible = true;
                     litagtad4.Visible = true;

                     litcopyto2.Visible = true;
                     litagtcode.Text = CopyToArr2[6].ToString();
                     litagtname.Text = CopyToArr2[0].ToString();
                     litagtad1.Text = CopyToArr2[1].ToString();
                     litagtad2.Text = CopyToArr2[2].ToString();
                     litagtad3.Text = CopyToArr2[3].ToString();
                     litagtad4.Text = CopyToArr2[4].ToString();

                     ArrayList CopyToArr3 = (ArrayList)CopyArray[1];

                     //Show postal Address
                     litCopyName.Text = CopyToArr3[0].ToString();
                     Litcad1.Text = CopyToArr3[1].ToString();
                     Litcad2.Text = CopyToArr3[2].ToString();
                     Litcad3.Text = CopyToArr3[3].ToString();
                     Litcad4.Text = CopyToArr3[4].ToString();
               
                    
                      }
                 if (Index == 3)
                 {
                     Hascopy = "Yes";
                     LITCUS.Text = " INSURANCE  ADVISOR'S  COPY ";
                     litcopyto2.Visible = true;
                     litagtcode.Text = CopyToArr[6].ToString();
                     litagtname.Text = CopyToName;
                     litagtad1.Text = CopyToAddress1;                     
                     litagtad2.Text = CopyToAddress2;
                    litagtad3.Text = CopyToAddress3;                   
                     litagtad4.Text = CopyToAddress4;

                     ArrayList CopyToArr4 = (ArrayList)CopyArray[2];

                     litCopyName.Text ="Agent Code : "+ CopyToArr4[6].ToString() + "," + CopyToArr4[0].ToString();
                     Litcad1.Text = CopyToArr4[1].ToString();
                     Litcad2.Text = CopyToArr4[2].ToString();
                     Litcad3.Text = CopyToArr4[3].ToString();
                     Litcad4.Text = CopyToArr4[4].ToString();
                     Litcad5.Text = CopyToArr4[5].ToString();
                  
                    
                 }
                 if (Hascopy == "Yes")
                 {
                     litcopyto1.Visible = true;
                     litbrName.Visible = true;
                     litbrad1.Visible = true;
                     litbrad2.Visible = true;
                     litbrad3.Visible = true;
                     litbtrad4.Visible = true;
                     litagtcode.Visible = true;
                     litagtname.Visible = true;
                     litagtad1.Visible = true;
                     litagtad2.Visible = true;
                     litagtad3.Visible = true;
                     litagtad4.Visible = true;

                     litto.Visible = true;
                     litCopyName.Visible = true;
                     Litcad1.Visible = true;
                     Litcad2.Visible = true;
                     Litcad3.Visible = true;
                     Litcad4.Visible = true;
               
                 }
                 
             %>
    
    
    <div style="text-align: center">
        <table style="width: 637px">
            <tr>
                <td style="width: 17px; height: 20px">
                </td>
                <td style="width: 74px; height: 20px">
                </td>
                <td style="width: 256px; height: 20px">
                </td>
                <td style="width: 84px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 20px">
                </td>
                <td style="width: 74px; height: 20px">
                </td>
                <td style="width: 256px; height: 20px">
                </td>
                <td style="width: 84px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 20px">
                </td>
                <td style="width: 74px; height: 20px">
                </td>
                <td style="width: 256px; height: 20px">
                </td>
                <td style="width: 84px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 20px">
                </td>
                <td style="width: 74px; height: 20px">
                </td>
                <td style="width: 256px; height: 20px">
                </td>
                <td style="width: 84px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: center; font-size: 11pt; font-family: 'Trebuchet MS'; font-weight: bold;">
                    <asp:Literal ID="LITCUS" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 25px">
                </td>
                <td colspan="3" style="height: 25px; text-align: center">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left">
                    <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt">
                            <b style="mso-bidi-font-weight: normal"><span style="font-family: Sandaya">,shdmosxps
                                ;emE,</span></b><span style="font-family: Sandaya"><?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><o:p></o:p></span></p>
                    </span></td>
            </tr>
            <tr>
                <td style="width: 17px; height: 15px">
                </td>
                <td colspan="3" style="height: 15px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left">
                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'">wfma fhduqj( cS$yssusluz$</span><span style="font-family: 'Times New Roman';
                                mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                mso-bidi-language: AR-SA">1/</span></span><asp:Literal ID="litclmno" runat="server"></asp:Literal></span></td>
            </tr>
            <tr style="font-weight: bold; font-size: 14pt; text-decoration: underline">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="font-weight: normal; height: 10px; text-align: left; text-decoration: none; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <span><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'"><span style="font-size: 11pt">oskh(</span></span></span><asp:Literal
                            ID="litdate" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-weight: bold; text-decoration: underline">
                <td style="width: 17px; height: 15px">
                </td>
                <td colspan="3" style="height: 15px; text-align: left">
                </td>
            </tr>
            <tr style="font-weight: normal; font-size: 14pt; text-decoration: underline">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left; text-decoration: none; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litname" runat="server"></asp:Literal><span style="font-size: 10pt"></span></td>
            </tr>
            <tr style="font-weight: bold; font-size: 14pt; text-decoration: underline">
                <td style="font-weight: normal; font-size: 11pt; width: 17px; height: 10px; text-decoration: none">
                </td>
                <td colspan="3" style="font-weight: normal; font-size: 10pt; width: 15px; height: 10px;
                    text-align: left; text-decoration: none; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">uy;auhdKks$uy;aushks</span>,</span></p>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="vertical-align: top; height: 10px">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 10px">
                </td>
                <td colspan="3" style="height: 10px; text-align: left">
                    <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt;">
                        <span><strong><span style="font-size: 11pt; font-family: 'Trebuchet MS'; text-decoration: underline;
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'; font-weight: bold;">
                            <span style="font-family: Sandaya">Tmamq wxlh( </span>
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal>&nbsp;</span></strong></span></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-weight: bold; font-size: 11pt; text-decoration: underline;">
                        <span><strong><span style="font-size: 12pt; font-family: Sandaya; text-decoration: underline;
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">ush.sh </span>
                        </strong></span>
                        <asp:Literal ID="litlifeassured" runat="server"></asp:Literal>
                        &nbsp; <span
                            style="font-size: 12pt; font-family: Sandaya; text-decoration: underline; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'"><strong>uy;d</strong></span></span></td>
            </tr>
            <tr style="font-size: 14pt">
                <td style="width: 17px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px">
                </td>
            </tr>
            <tr style="font-size: 14pt">
                <td style="width: 17px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: justify">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">by; wxl orK rla<b
                            style="mso-bidi-font-weight: normal">I</b>Kh hgf;a Tn jsiska bosrsm;a lrk ,o ysuslu
                            iuznkaOfhks</span>.<span style="font-family: Sandaya"><?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                prefix="o" ?><o:p></o:p></span></span></p>
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 14pt">
                <td style="width: 17px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 14pt">
                <td style="font-weight: normal; height: 12px; text-align: justify; width: 17px;">
                </td>
                <td colspan="3" style="font-weight: normal; height: 12px; text-align: justify">
                    <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                        mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                        <span style="font-size: 11pt">fuu Tmamqj fjkqfjka &nbsp;<span style="font-family: Trebuchet MS">
                            <asp:Literal ID="litlapseddate" runat="server"></asp:Literal></span></span><span style="mso-spacerun: yes"><span
                                style="font-size: 11pt"> <span style="font-family: Sandaya">isg bosrshg f.jSug kshus; jdrsl fkdf.jSu
                            fya;=fjka tosk isg wm%dKsslj mj;S</span><span style="font-family: Times New Roman">.</span><span
                                        style="font-family: Sandaya"><span style="mso-spacerun: yes">&nbsp; </span>Tmamq fldkafoais wkqj wm%dKslj we;s rCIKhla u; wmf.a lsis|q j.lSula fkdue;</span><span
                                            style="font-family: Times New Roman">.</span><span style="font-family: Sandaya"><span
                                                style="mso-spacerun: yes">&nbsp; </span>tu ksid cSjs; rCIs;hd ushhk jsg wm%dKslj
                            meje;s fuu rCIK Tmamqj hgf;a Tn bosrsm;a lsrSug fhoqk ysuslu fjkqfjka lsisu f.jSula
                            l&lt; fkdyels nejz b;d lK.dgqfjka oekquz fouq</span><span style="font-family: Times New Roman">.<o:p></o:p></span></span></span></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                        <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                <span style="font-family: Sandaya"><span style="font-size: 11pt">fuhg - jsYajdiS<o:p></o:p></span></span></p>
                        </span>
                </td>
                <td style="width: 84px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: Sandaya">Y%S ,xld bk<b style="mso-bidi-font-weight: normal">aI</b>qjrkaia fldamfrAIka ,hs*a ,susgvz<o:p></o:p></span></p>
                </td>
                <td style="width: 84px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left">
                </td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                </td>
                <td style="width: 84px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 17px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left">
                    <span style="font-size: 11pt"><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                        mso-bidi-font-family: 'Times New Roman'">cSjs; l&lt;uKdldr fjkqjg</span><span style="font-family: 'Times New Roman';
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA">.</span></span></td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left">
                </td>
                <td style="width: 84px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="font-size: 10pt; width: 74px; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litCopyto" runat="server" Text="Copy To :"></asp:Literal></td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litcopyto1" runat="server" Text="Branch Administration Officer"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litbrName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2"
                        runat="server"></asp:Literal><asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal
                            ID="litbtrad4" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litcopyto2" runat="server" Text="Insurance Advisor :-"></asp:Literal>
                    <asp:Literal ID="litagtcode" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litagtname" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2"
                        runat="server"></asp:Literal><asp:Literal ID="litagtad3" runat="server"></asp:Literal><asp:Literal
                            ID="litagtad4" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litto" runat="server" Text="TO :-"></asp:Literal></td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litCopyName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="Litcad1" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="Litcad2" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="Litcad3" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="Litcad4" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 10px">
                </td>
                <td colspan="1" style="width: 74px; height: 10px; text-align: left">
                </td>
                <td colspan="2" style="font-size: 10pt; height: 10px; text-align: left; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="Litcad5" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 17px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                </td>
                <td style="width: 84px; height: 20px; text-align: left">
                </td>
            </tr>
        </table>
    
    <p class="break"></p>
    </div>
   <%}
         }
         catch
         { }
         %>  
    </form>
</body>
</html>
