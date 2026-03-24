<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCoverLetterEng002.aspx.cs" Debug ="true" Inherits="AdmitCoverLetter" %>
<%@ PreviousPageType VirtualPath="~/AdmitCoverLetterEng001.aspx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SRI LANKA INSURANCE DEATH CLAIM SYSTEM</title>
    <style type="text/css">
    .break{page-break-before:always}
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
                     if (CopyArray.Count > 2)
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
                         }

                     }
                     
                     litCopyName.Text = CopyToName;
                     Litcad1.Text = CopyToAddress1;
                     Litcad2.Text = CopyToAddress2;
                     Litcad3.Text = CopyToAddress3;
                     Litcad4.Text = CopyToAddress4;
                 }
                                 
             %>
    <div style="text-align: center">
        <table style="width: 700px; font-size: 10pt; font-family: 'Trebuchet MS'; text-align: left;">
            <tr>
                <td style="width: 18px; height: 11px;">
                </td>
                <td style="width: 631px; height: 11px;">
                </td>
                <td style="width: 100px; height: 11px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 16px;">
                </td>
                <td style="width: 631px; height: 16px;">
                    <strong>REGISTERED POST</strong></td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px; text-align: right;">
                    <strong>"WITHOUT PREJUDICE"</strong></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px; font-weight: bold; text-align: center;">
                    </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 12px;">
                </td>
                <td style="width: 631px; height: 12px;">
                </td>
                <td style="width: 100px; height: 12px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; text-align: left; height: 10px;">
                    Our Ref : L/Claims/<asp:Literal ID="litclmno" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px">
                </td>
                <td style="width: 631px">
                    Date :
                    <asp:Literal ID="litDate" runat="server"></asp:Literal></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad3" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Dear Sir/Madom,</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; font-weight: bold; height: 10px; text-decoration: underline;">
                    Life Policy No:
                    <asp:Literal ID="litpolno" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; font-weight: bold; height: 10px; text-decoration: underline;">
                    On the Life of
                    <asp:Literal ID="litdthname" runat="server"></asp:Literal>
                    (deceased)</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 11px;">
                </td>
                <td style="width: 631px; height: 11px;">
                </td>
                <td style="width: 100px; height: 11px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px">
                </td>
                <td style="width: 631px; text-align: justify;">
                    We write with reference to the death claim submitted under the above policy and
                    pleasure in informing you that the liability under the above policy has been accepeted
                    according to the policy condition applicable and the letter of admission of liability
                    is enclosed herewith.</td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px">
                </td>
                <td style="width: 631px; text-align: justify;">
                    We regret to indicate you, that the following documents which were requested by our letter dated&nbsp;<asp:Literal ID="litletterdated" runat="server"></asp:Literal>
                    has not been submitted
                    to us up to this moment.Therefore we kindly request you to forward us the following requirements.</td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 15px;">
                </td>
                <td style="width: 631px; height: 15px; text-justify: auto; text-align: justify;">
                    <asp:Table ID="tblRequiremnt" runat="server" Width="625px" HorizontalAlign="Justify">
                    </asp:Table>
                </td>
                <td style="width: 100px; height: 15px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="text-justify: auto; width: 631px; height: 10px; text-align: justify">
                    <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="text-justify: auto; width: 631px; height: 10px; text-align: justify">
                    <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px; text-justify: auto; text-align: justify;">
                    <asp:Literal ID="litreq24" runat="server"></asp:Literal></td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Your prompt attention will be&nbsp; help us to settle this claim without delay.</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Thanking You,</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    Yours faithfully</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <strong>
                    SRI LANKA INSURANCE CORPORATION LIFE LTD</strong></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    .............................</td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px;">
                </td>
                <td style="width: 631px; height: 10px;">
                    <strong>
                    For Life Manager</strong></td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="height: 10px" colspan="2">
                    <table style="width: 636px">
                    <tr>
                        <td style="width: 58px; height: 10px">
                         <asp:Literal ID="litCopyto" runat="server" Text="Copy To:"></asp:Literal></td>
                        <%
                            if (Br_Copy)
                            {
                                 %>                        
                        
                            <td style="height: 10px" colspan="2">
                    <asp:Literal ID="litbrName" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2" runat="server"></asp:Literal>
                                <asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbtrad4" runat="server"></asp:Literal></td>
                        </tr>
                        <%
                            }
                        %>
                        
                        <% 
                 if (Ins_Adv_Copy)
                           {
                               %>
                        <tr>
                            <td style="width: 58px; height: 10px">
                            </td>
                            <td style="height: 10px" colspan="2">
                    <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                    <asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2" runat="server"></asp:Literal>
                    <asp:Literal ID="litagtad3" runat="server"></asp:Literal><asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                        </tr>
                         <%
                            }
                         %>
                       
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
                            <td style="width: 107px; height: 15px">
                            </td>
                            <td style="width: 64px; height: 15px">
                            </td>
                        </tr>
                    </table>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 18px; height: 10px">
                </td>
                <td style="width: 631px; height: 10px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
                <td style="width: 100px; height: 10px">
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
<%        
    /*Response.Clear();
    Response.Buffer = true;
    Page.EnableViewState = false;
    Response.ContentType = "application/msword";
    System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
    System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
    this.Panel1.RenderControl(oHtmlTextWriter);
    Response.Write(oStringWriter.ToString());
    Response.End();*/
         %>    
