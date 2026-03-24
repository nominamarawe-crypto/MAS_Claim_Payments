<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCoverLetterEng001.aspx.cs" Debug ="true" Inherits="AdmitCoverLetter" %>
<%@ PreviousPageType VirtualPath="~/dthPay002.aspx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SRI LANKA INSURANCE DEATH CLAIM SYSTEM</title>
    <style type="text/css">
    .break{page-break-before:always}

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

<body  style="text-align: center">
    <form id="form1" runat="server">
    
     <%--<%       
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
                     //litcopyto1.Visible=false;
                     litbrName.Visible=false;
                     litbrad1.Visible=false;
                     litbrad2.Visible=false;
                     litbrad3.Visible = false;
                     litbtrad4.Visible = false;
                     
                     //litcopyto2.Visible=false;
                     //litagtcode.Visible=false;
                     litagtname.Visible=false;
                     litagtad1.Visible=false;
                     litagtad2.Visible=false;
                     litagtad3.Visible=false;
                     litagtad4.Visible = false;

                     litto.Visible = false;
                 }
                 
                 if (Index == 2)
                 {
                     Hascopy = "Yes";                     
                                       
                     litCopyto.Visible = true;  
                     litbrName.Text = CopyToName;
                     litbrad1.Text = CopyToAddress1;
                     litbrad2.Text = CopyToAddress2;
                     litbrad3.Text = CopyToAddress3;
                     litbtrad4.Text = CopyToAddress4;

                     if(CopyArray.Count>2)
                     {                 
                     
                     ArrayList CopyToArr2 =(ArrayList) CopyArray[2];
                     LITCUS.Text = CopyToArr2[CopyToArr2.Count-1].ToString();  
                     //litagtcode.Visible = true;
                     litagtname.Visible = true;
                     litagtad1.Visible = true;
                     litagtad2.Visible = true;
                     litagtad3.Visible = true;
                     litagtad4.Visible = true;

                     //litcopyto2.Visible = true;
                     //litagtcode.Text = CopyToArr2[6].ToString();
                     litagtname.Text = CopyToArr2[0].ToString();
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
                             //litcopyto2.Visible = true;
                             //litagtcode.Text = CopyToArr3[6].ToString();
                             litagtname.Text = CopyToArr3[0].ToString();
                             litagtad1.Text = CopyToArr3[1].ToString();
                             litagtad2.Text = CopyToArr3[2].ToString();
                             litagtad3.Text = CopyToArr3[3].ToString();
                             litagtad4.Text = CopyToArr3[4].ToString();
                         }
                         if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                         {
                             litCopyto.Visible = true;
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
                     litto.Visible = true;
                     Hascopy = "Yes";
                     
                     //litcopyto2.Visible = true;
                     //litagtcode.Text = CopyToArr[6].ToString();
                     litagtname.Text = CopyToName;
                     litagtad1.Text = CopyToAddress1;                     
                     litagtad2.Text = CopyToAddress2;
                    litagtad3.Text = CopyToAddress3;                   
                     litagtad4.Text = CopyToAddress4;
                     if (CopyArray.Count > 2)
                     {
                         ArrayList CopyToArr4 = (ArrayList)CopyArray[2];
                         LITCUS.Text = CopyToArr4[CopyToArr4.Count - 1].ToString();
                         litCopyName.Text = CopyToArr4[0].ToString();
                         Litcad1.Text = CopyToArr4[1].ToString();
                         Litcad2.Text = CopyToArr4[2].ToString();
                         Litcad3.Text = CopyToArr4[3].ToString();
                         Litcad4.Text = CopyToArr4[4].ToString();
                         Litcad5.Text = CopyToArr4[5].ToString();
                     }
                    
                 }
                 if (Hascopy == "Yes")
                 {
                     litto.Visible = true;
                     if (CopyToArr[CopyToArr.Count - 1].ToString() == "BRANCH   COPY")
                     {
                         //litcopyto1.Visible = true;
                         litbrName.Visible = true;
                         litbrad1.Visible = true;
                         litbrad2.Visible = true;
                         litbrad3.Visible = true;
                         litbtrad4.Visible = true;
                     }
                     if (CopyToArr[CopyToArr.Count - 1].ToString() == "INSURANCE  ADVISOR'S  COPY")
                     {
                        
                        // litagtcode.Visible = true;
                         litagtname.Visible = true;
                         litagtad1.Visible = true;
                         litagtad2.Visible = true;
                         litagtad3.Visible = true;
                         litagtad4.Visible = true;
                     }
                 }
                 
              }
         }
         catch
         { }
         %>--%>   

    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
        <table style="width: 700px; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
            <tr>
                <td style="width: 11px; height: 20px;">
                </td>
                <td style="width: 631px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 20px;">
                </td>
                <td style="width: 631px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 14px;">
                </td>
                <td style="width: 631px; height: 14px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td style="width: 631px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td style="width: 631px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 20px;">
                </td>
                <td style="width: 631px; height: 20px;">
                    <strong>REGISTERED POST</strong></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px; text-align: right;">
                    <strong>"WITHOUT PREJUDICE"</strong></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 12px;">
                </td>
                <td style="width: 631px; height: 12px; font-weight: bold; text-align: center;">
                    <asp:Literal ID="LITCUS" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 20px;">
                </td>
                <td style="width: 631px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 19px;">
                </td>
                <td style="width: 631px; text-align: left; height: 19px;">
                    Our Ref : L/Claims/<asp:Literal ID="litclmno" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 20px;">
                </td>
                <td style="width: 631px; height: 20px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td style="width: 631px">
                    Date :
                    <asp:Literal ID="litDate" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 19px;">
                </td>
                <td style="width: 631px; height: 19px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 18px;">
                </td>
                <td style="width: 631px; height: 18px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Dear Sir/Madom,</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; font-weight: bold; height: 10px; text-decoration: underline;">
                    Life Policy No:
                    <asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; font-weight: bold; height: 10px; text-decoration: underline;">
                    On the Life of
                    <asp:Literal ID="litdthname" runat="server"></asp:Literal>
                    (deceased)</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px;">
                </td>
                <td style="width: 631px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td style="width: 631px; text-align: justify; text-justify: auto;">
                    We write with reference to the death claim submitted under the above policy and
                    pleasure in informing you that the liability under the above policy has been accepeted
                    according to the policy condition applicable and the letter of admission of liability
                    is enclosed herewith.</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 56px;">
                </td>
                <td style="width: 631px; text-align: justify; text-justify: auto; height: 56px;">
                    We regret to indicate you, that the following documents which were requested by
                    our letter dated
                    &nbsp;<asp:Literal ID="litletterdated" runat="server"></asp:Literal>
                    has not been submitted to us up to this moment.Therefore we kindly request you to forward us the following requirements.</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td style="width: 631px; text-justify: auto; text-align: justify;">
                    <asp:Table ID="tblRequiremnt" runat="server" Width="626px" HorizontalAlign="Justify" style="text-justify: auto; text-align: justify">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px">
                </td>
                <td style="text-justify: auto; width: 631px; height: 10px; text-align: justify">
                    <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px">
                </td>
                <td style="text-justify: auto; width: 631px; height: 10px; text-align: justify">
                    <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px; text-justify: auto; text-align: justify;">
                    <asp:Literal ID="litreq24" runat="server" Visible="False"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Your prompt attention will be&nbsp; help us to settle this claim without delay.</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Thanking You,</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Yours faithfully</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <strong>
                    SRI LANKA INSURANCE CORPORATION LIFE LTD</strong></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    .............................</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <strong>
                    For Life Manager</strong></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px">
                </td>
                <td style="height: 10px" colspan="1">
                    <table style="width: 578px">
                        <tr>
                            <td style="width: 58px; height: 10px">
                    <asp:Literal ID="litCopyto" runat="server" Text="Copy To :"></asp:Literal></td>
                            <td style="height: 10px">
                    <asp:Literal ID="litbrName" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2" runat="server"></asp:Literal><asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbtrad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px">
                    <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                    <asp:Literal ID="litagtad1" runat="server"></asp:Literal>
                    <asp:Literal ID="litagtad2" runat="server"></asp:Literal><asp:Literal ID="litagtad3" runat="server"></asp:Literal><asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 15px">
                            </td>
                            <td style="height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 8px">
                                <asp:Literal ID="litto" runat="server" Text="TO :-"></asp:Literal></td>
                            <td style="height: 8px">
                                <asp:Literal ID="litCopyName" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px">
                                <asp:Literal ID="Litcad1" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px">
                                <asp:Literal ID="Litcad2" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px">
                                <asp:Literal ID="Litcad3" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px">
                                <asp:Literal ID="Litcad4" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px">
                                <asp:Literal ID="Litcad5" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>
        <br />
    <p class="break"></p>
    </div>
    
   
   <asp:Button ID="btnprint" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" PostBackUrl="~/AdmitCoverLetterEng002.aspx" Text="  Print  " OnClientClick="cForm1(this.form1)"  OnClick="btnprint_Click" Height="23px" Width="89px" />
                    <asp:Button ID="btnExit" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="10pt" OnClientClick="MM_goToURL('self','Home.ASPX');return document.MM_returnValue" Text="  Exit  " Height="23px" Width="96px" />
        <asp:Button ID="btn_word" runat="server" OnClick="btn_word_Click" Text="Get Word Document" Height="23px" Width="148px" Font-Bold="True" PostBackUrl="~/AdmitCoverLetterEng002.aspx" />

        <asp:HiddenField ID="hdfpol" runat="server" />
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