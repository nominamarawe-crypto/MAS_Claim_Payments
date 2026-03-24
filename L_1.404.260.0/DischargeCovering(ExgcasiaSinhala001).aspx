<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DischargeCovering(ExgcasiaSinhala001).aspx.cs" Inherits="DischargeCovering_ExgcasiaSinhala_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style>
        @font-face {
    font-family: "Sandaya";
    src: url("fonts/SANDHYA.woff2");
    src: local("Sandaya"),url("fonts/SANDHYA.woff2"),url("fonts/SANDHYA.ttf"),url("fonts/SANDHYA.woff"),url("fonts/SANDHYA.eot"),url("fonts/SANDHYA.svg");
    font-weight: normal;
    font-style: normal;
    }
    </style>
</head>
<body>
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
    <div>
        <table>
            <tr>
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <strong><span style="font-size: 11pt; font-family: Sandaya">,shdmosxps ;emE,</span></strong></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px; text-align: right">
                    <strong>"<span style="font-size: 11pt; font-family: Sandaya">w.;s rys;hs<span style="font-family: Times New Roman">"</span></span></strong></td>
                <td style="width: 100px; font-family: Times New Roman; height: 21px">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px; text-align: center">
                    <asp:Literal ID="LITCUS" runat="server" Visible="False"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-size: 11pt; font-family: Sandaya">wm fhduqj (<span> </span>cS$ysusluz$1$<span
                        style="font-size: 12pt; font-family: Times New Roman"><asp:Literal ID="litclmno"
                            runat="server"></asp:Literal></span></span></td>
                <td style="font-size: 12pt; width: 100px; font-family: Times New Roman; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-family: Sandaya">oskh ( <span style="font-family: Times New Roman">
                        <asp:Literal ID="litDate" runat="server"></asp:Literal></span></span></td>
                <td style="width: 100px; font-family: Times New Roman; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-family: Sandaya">ms%h uy;auhdfKks$uy;aushks<span><span> </span></span>
                    </span>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-family: Sandaya; text-decoration: underline"><strong>cSjs; rlaIK Tmamq
                        wxlh(<span style="font-family: Times New Roman"><asp:Literal ID="litpolno" runat="server"></asp:Literal></span></strong></span></td>
                <td style="width: 100px; font-family: Times New Roman; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-family: Sandaya"><strong><span style="text-decoration: underline">
                        rlaIs;(</span></strong><span style="font-family: Times New Roman"><asp:Literal ID="litdthname"
                            runat="server"></asp:Literal><span style="text-decoration: underline">&nbsp; <strong><span>
                                &nbsp;<span style="font-family: Sandaya"><span style="font-weight: bold; text-decoration: underline;">^ush.sh&amp;</span></span></span></strong></span></span></span></td>
                <td style="width: 100px; font-family: Times New Roman; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px; text-align: justify;">
                    <span style="font-family: Sandaya"><span style="font-size: 11pt; text-align: justify">
                        hf:dala; rlaIK Tmamqj hgf;a mek ke.S we;s urK ysuslu iuznkaOfhka j.lSu ms,sf.k ms,S.ekSfuz
                        ,smsh fuz iu. tjd we;'</span></span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 11pt"><span style="font-family: Sandaya">ysusluz lghq;= ksrdlrKh
                            lsrSu i|yd fuz iu. ms&lt;sfh, lr tjd we;s f.jd ksu lsrsfuz l=js;dkaish yd jeo.;a
                            ksfjzokh Tn jsiska ksis mrsos iuzmQrAK lr wm fj; tjk f,i ldreKslj okajd isgsuq</span>.</span></p>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-size: 11pt; font-family: Sandaya">fuhg- jsYajdiS</span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-size: 11pt; font-family: Sandaya">YS% ,xld bkaIQrkaia fldamfrAIka ,hs*a ,susgvz</span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    ................................</td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <span style="font-size: 11pt; font-family: Sandaya">cSjs; l&lt;uKdlre fjkqjg</span></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px">
                    <table style="font-size: 11pt; width: 580px">
                        <tr>
                            <td style="width: 67px; height: 10px">
                                <asp:Literal ID="litCopyto" runat="server" Text="Copy To :"></asp:Literal></td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="litbrName" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2"
                                    runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbtrad4"
                                    runat="server"></asp:Literal><br />
                                <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                                <asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2"
                                    runat="server"></asp:Literal><asp:Literal ID="litagtad3" runat="server"></asp:Literal><br />
                                <asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 11px">
                            </td>
                            <td colspan="2" style="height: 11px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 10px">
                                <asp:Literal ID="litto" runat="server" Text="TO :-"></asp:Literal></td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="litCopyName" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad1" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad2" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad3" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 10px">
                            </td>
                            <td colspan="2" style="height: 10px">
                                <asp:Literal ID="Litcad5" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 67px; height: 15px">
                            </td>
                            <td style="width: 113px; height: 15px">
                            </td>
                            <td style="width: 83px; height: 15px">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td style="width: 31px; height: 21px">
                </td>
                <td style="width: 576px; height: 21px; text-align: center;">
                    <asp:Button ID="btnprint" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" Height="23px" OnClick="btnprint_Click" OnClientClick="cForm1(this.form1)"
                        PostBackUrl="~/AdmitCoverLetterSIn002.aspx" Text="  Print  " Width="106px" />&nbsp;<asp:Button
                            ID="btn_word" runat="server" Font-Bold="True" Height="23px" OnClick="Button1_Click"
                            PostBackUrl="~/AdmitCoverLetterSIn002.aspx" Text="Get Word Document" Width="148px" /><asp:HiddenField
                                ID="hdfpol" runat="server" />
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
