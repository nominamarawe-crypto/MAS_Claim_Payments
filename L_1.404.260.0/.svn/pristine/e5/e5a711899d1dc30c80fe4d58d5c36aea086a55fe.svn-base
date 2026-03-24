<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secondReq002.aspx.cs" Inherits="secondReq001" %>
<%@ PreviousPageType VirtualPath="~/secondReq001.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="X-UA-Compatible" content="IE=6" />
<head id="Head1" runat="server">

    <title>Untitled Page</title>
    <style type="text/css">
	.pageBreakDiv
	{
		page-break-before:always;
	}
	 
	.tableTextAlign
    {
        text-align:justify;
        font-size: 10pt;
    } 
    .englishWord
    {
        text-align:justify;
        font-size: 10pt;
    } 
    </style>
    <script language="javascript" type="text/javascript">


        window.onload = function () {
            printDiv('printDiv');
        }
        function printDiv(printPanel) {
            var printContents = document.getElementById(printPanel).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;

            window.print();
            document.body.innerHTML = originalContents;
        }

    </script>
</head>
<body >
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
            string toName = "";
            string printCopy = "";
            string printTo = "";
            string brName = "";
            string clbrName = "";
            string inadName = "";
            string ReSalName = "";
            string SalName = "";
            int Index = 0;
            int Index1 = 0;
            bool Cus_copy = false;
            bool Br_Copy = false;
            bool Ins_Adv_Copy = false;
            bool ClBR_Copy = false;
            bool ReSal_Copy = false;
            bool Sal_Copy = false;

            foreach (ArrayList CopyArr in CopyToArr)
            {
                Index++; //string Hascopy = "No";
                if (CopyToArr.Count != Index)
                {
                    if (CopyArr[0] != null) { CopyToName = CopyArr[0].ToString(); }
                    else { CopyToName = ""; }
                    if (CopyArr[1] != null) { CopyToAddress1 = CopyArr[1].ToString(); }
                    else { CopyToAddress1 = ""; }
                    if (CopyArr[2] != null) { CopyToAddress2 = CopyArr[2].ToString(); }
                    else { CopyToAddress2 = ""; }
                    if (CopyArr.Count > 3)
                    {
                        if (CopyArr[3] != null) { CopyToAddress3 = CopyArr[3].ToString(); }
                        else { CopyToAddress3 = ""; }
                    }
                    if (CopyArr.Count > 4)
                    {
                        if (CopyArr[4] != null) { CopyToAddress4 = CopyArr[4].ToString(); }
                        else { CopyToAddress4 = ""; }
                    }
                    if (CopyArr.Count > 5)
                    {
                        if (CopyArr[5] != null) { CopyToAddress5 = CopyArr[5].ToString(); }
                        else { CopyToAddress5 = ""; }
                    }
                }


                if (Index == 1)  ///// hide the addresses
                {
                    pnlPrintCopy.Visible = false;
                    //pnlPrintTo.Visible = false;
                }
                else
                {
                    foreach (ArrayList CopyArr1 in CopyToArr)
                    {
                        Index1++;
                        if (CopyToArr.Count != Index1 && Index != Index1)
                        {
                            if (CopyArr1[CopyArr1.Count - 1].ToString() == "Customer Copy")
                            {
                                Cus_copy = true;
                            }
                            else if (CopyArr1[CopyArr1.Count - 1].ToString() == "BRANCH  COPY")
                            {
                                Br_Copy = true;
                                if (CopyArr1[0].ToString() != null && CopyArr1[0].ToString() != "")
                                {
                                    brName = CopyArr1[0].ToString();
                                }
                                if (CopyArr1[1].ToString() != null && CopyArr1[1].ToString() != "")
                                {
                                    brName += CopyArr1[1].ToString();
                                }
                                if (CopyArr1[2].ToString() != null && CopyArr1[2].ToString() != "")
                                {
                                    brName += CopyArr1[2].ToString();
                                }
                                if (CopyArr1[3].ToString() != null && CopyArr1[3].ToString() != "")
                                {
                                    brName += CopyArr1[3].ToString();
                                }
                                if (CopyArr1[4].ToString() != null && CopyArr1[4].ToString() != "")
                                {
                                    brName += CopyArr1[4].ToString();
                                }
                            }
                            else if (CopyArr1[CopyArr1.Count - 1].ToString() == "CLOSER BRANCH  COPY")
                            {
                                ClBR_Copy = true;
                                if (CopyArr1[0].ToString() != null && CopyArr1[0].ToString() != "")
                                {
                                    clbrName = CopyArr1[0].ToString().Replace(",", "") + " (Closer Branch),";
                                }
                                if (CopyArr1[1].ToString() != null && CopyArr1[1].ToString() != "")
                                {
                                    clbrName += CopyArr1[1].ToString();
                                }
                                if (CopyArr1[2].ToString() != null && CopyArr1[2].ToString() != "")
                                {
                                    clbrName += CopyArr1[2].ToString();
                                }
                                if (CopyArr1[3].ToString() != null && CopyArr1[3].ToString() != "")
                                {
                                    clbrName += CopyArr1[3].ToString();
                                }
                                if (CopyArr1[4].ToString() != null && CopyArr1[4].ToString() != "")
                                {
                                    clbrName += CopyArr1[4].ToString();
                                }
                            }
                            else if (CopyArr1[CopyArr1.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
                            {
                                ReSal_Copy = true;
                                if (CopyArr1[0].ToString() != null && CopyArr1[0].ToString() != "")
                                {
                                    ReSalName = CopyArr1[0].ToString();
                                }
                                if (CopyArr1[1].ToString() != null && CopyArr1[1].ToString() != "")
                                {
                                    ReSalName += CopyArr1[1].ToString();
                                }
                                if (CopyArr1[2].ToString() != null && CopyArr1[2].ToString() != "")
                                {
                                    ReSalName += CopyArr1[2].ToString();
                                }
                                if (CopyArr1[3].ToString() != null && CopyArr1[3].ToString() != "")
                                {
                                    ReSalName += CopyArr1[3].ToString();
                                }
                            }
                            else if (CopyArr1[CopyArr1.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                Sal_Copy = true;
                                if (CopyArr1[0].ToString() != null && CopyArr1[0].ToString() != "")
                                {
                                    SalName = CopyArr1[0].ToString();
                                }
                                if (CopyArr1[1].ToString() != null && CopyArr1[1].ToString() != "")
                                {
                                    SalName += CopyArr1[1].ToString();
                                }
                                if (CopyArr1[2].ToString() != null && CopyArr1[2].ToString() != "")
                                {
                                    SalName += CopyArr1[2].ToString();
                                }
                            }
                            else if (CopyArr1[CopyArr1.Count - 1].ToString() == "INSURANCE ADVISORS'  COPY")
                            {
                                Ins_Adv_Copy = true;
                                if (CopyArr1[0].ToString() != null && CopyArr1[0].ToString() != "")
                                {
                                    inadName = CopyArr1[0].ToString().Replace(",", "") + " (Insurance Advisor),";
                                }
                                if (CopyArr1[1].ToString() != null && CopyArr1[1].ToString() != "")
                                {
                                    inadName += CopyArr1[1].ToString();
                                }
                                if (CopyArr1[2].ToString() != null && CopyArr1[2].ToString() != "")
                                {
                                    inadName += CopyArr1[2].ToString();
                                }
                                if (CopyArr1[3].ToString() != null && CopyArr1[3].ToString() != "")
                                {
                                    inadName += CopyArr1[3].ToString();
                                }
                                if (CopyArr1[4].ToString() != null && CopyArr1[4].ToString() != "")
                                {
                                    inadName += CopyArr1[4].ToString();
                                }
                            }

                            if (Br_Copy)
                            {
                                printCopy = "<span style='margin-left:20px'>" + brName + "</span>";
                            }
                            if (ClBR_Copy)
                            {
                                printCopy += "<br /><span style='margin-left:55px'>" + clbrName + "</span>";
                            }
                            if (ReSal_Copy)
                            {
                                printCopy += "<br /><span style='margin-left:55px'>" + ReSalName + "</span>";
                            }
                            if (Sal_Copy)
                            {
                                printCopy += "<br /><span style='margin-left:55px'>" + SalName + "</span>";
                            }
                            if (Ins_Adv_Copy)
                            {
                                printCopy += "<br /><span style='margin-left:55px'>" + inadName + "</span>";
                            }

                            if (printCopy.Length > 0 && CopyToArr.Count == Index)
                            {
                                printCopy = printCopy.Trim().Replace(",", ", ");
                                printCopy = printCopy.Trim().Replace("..", ".");
                                lblPrintCopy.Text = printCopy;
                                pnlPrintCopy.Visible = true;
                            }
                        }

                        if (CopyToName != null && CopyToName != "")
                        {
                            printTo = CopyToName;
                        }
                        if (CopyToAddress1 != null && CopyToAddress1 != "")
                        {
                            printTo += CopyToAddress1;
                        }
                        if (CopyToAddress2 != null && CopyToAddress2 != "")
                        {
                            printTo += CopyToAddress2;
                        }
                        if (CopyToAddress3 != null && CopyToAddress3 != "")
                        {
                            printTo += CopyToAddress3;
                        }
                        if (CopyToAddress4 != null && CopyToAddress4 != "")
                        {
                            printTo += CopyToAddress4;
                        }
                        printTo += ".";

                        if (printTo.Length > 1 && CopyToArr.Count != Index)
                        {
                            printTo = printTo.Replace(",", ", ");
                            printTo = printTo.Replace(". .", ".");
                            printTo = "<span style='margin-left:20px'>" + printTo + "</span>";
                            printCopy = printTo;
                            lblPrintCopy.Text = printCopy;
                            pnlPrintCopy.Visible = true;
                        }
                    }
                    Index1 = 0;
                    printTo = "";
                    printCopy = "";
                    Br_Copy = false;
                    ClBR_Copy = false;
                    Ins_Adv_Copy = false;
                }

                CopyToName = "";
                CopyToAddress1 = "";
                CopyToAddress2 = "";
                CopyToAddress3 = "";
                CopyToAddress4 = "";
                CopyToAddress5 = "";
            } %>
    <div id="printDiv" style="text-align: center; width: 640px; background-color: white; padding: 0px 0px; padding-left: 40px; margin-right: auto; margin-left: auto">
        <table style="font-size: 10pt; ">
             <tr>
                 <td style="height: 0px"></td>
                 <td style="height: 0px"></td>
                 <td style="height: 0px"></td>
                 <td style="height: 0px"></td>
                 <td style="height: 0px"></td>
             </tr>
            <tr>
                <td style="height: 12px; font-weight:bold; font-size: 11pt;" colspan="2" align="left">
                Registered Post</td>
                <td style="height: 12px">
                </td>
                <td style="height: 12px; font-weight:bold; font-size: 11pt;" colspan="2" align="right">
                “WITHOUT PREJUDICE”</td>
            </tr>
            <%--<tr>
                <td style="width: 128px; height: 10px">
                </td>
                <td style="width: 128px; height: 10px">
                </td>
                <td style="width: 128px; height: 10px">
                </td>
                <td style="width: 128px; height: 10px;">
                </td>
                <td style="width: 128px; height: 10px">
                </td>
            </tr>--%>
            <tr>
                <td style="height: 10px;"" colspan="5" align="left">
                Our Ref : L/Claims/1/D/ <asp:Label ID="ltlClaimNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="5" align="left">
                <asp:Label ID="lblLetterDate" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            <%--<tr>
                <td style="width: 128px; height: 5px">
                </td>
                <td style="width: 128px; height: 5px">
                </td>
                <td style="width: 128px; height: 5px">
                </td>
                <td style="width: 128px; height: 5px">
                </td>
                <td style="width: 128px; height: 5px">
                </td>
            </tr>--%>
            <tr>
                <td style="height: 10px" colspan="5" align="left">
                <asp:Label ID="lblName" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="5" align="left">
                <asp:Label ID="lblAdd1" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr><tr>
                <td style="height: 10px" colspan="5" align="left">
                <asp:Label ID="lblAdd2" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr><tr>
                <td style="height: 10px" colspan="5" align="left">
                <asp:Label ID="lblAdd3" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr><tr>
                <td style="height: 10px" colspan="5" align="left">
                <asp:Label ID="lblAdd4" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            
            <tr>
                <td style="height: 10px; padding-top:5px;" colspan="5" align="left">
                Dear Sir / Madam,</td>
            </tr>
            
            <tr>
                <td style="height: 10px; padding-top:6px;" colspan="5" align="left">
                <u><b>Life Policy No : <asp:Label ID="lblPolNo" CssClass="englishWord" runat="server"></asp:Label></b></u></td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="5" align="left">
                <u><b>On the Life of <asp:Label ID="lblNameofDeath" CssClass="englishWord" runat="server"></asp:Label> (deceased)</b></u></td>
            </tr>
            <tr>
                <td style="height: 10px; padding-top:5px;" colspan="5" class="tableTextAlign">
                We write with reference to the death claim submitted under the above policy and acknowledge the documents.</td>
            </tr>
           
            <asp:Panel ID="pnlPendingReq" runat="server" Visible="false">
             <tr>
                <td style="height: 20px; padding-top:5px;" colspan="5" class="tableTextAlign">
                In order to process this claim pleases send us the following documents which we requested from our <asp:Label ID="lblFirstDate" CssClass="englishWord" runat="server"></asp:Label> dated letter.</td>
            </tr>
            
            <tr>
                <td style="height: 10px; padding-top:5px;" colspan="5" class="tableTextAlign">
                <asp:Table ID="tblFirstReq" CssClass="englishWord" runat="server"></asp:Table></td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="pnlSecReq" runat="server" Visible="false">
            <tr>
                <td style="height: 10px; padding-top:5px;" colspan="5" class="tableTextAlign">
                <asp:Label ID="txtSecReqDescription" CssClass="englishWord" runat="server"></asp:Label>
                <%--Additional to above requirements please send us the following documents.--%></td>
            </tr>
             
            <tr>
                <td style="height: 10px; padding-top:5px;" colspan="5" class="tableTextAlign">
                <asp:Table ID="tblSecReq" CssClass="englishWord" runat="server"></asp:Table></td>
            </tr>
            <asp:Panel ID="pnlNom" runat="server" Visible="false">
            <tr>
                <td style="height: 10px" colspan="5" class="tableTextAlign">
                <asp:Label ID="lblSecondReq" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            </asp:Panel>
            
            </asp:Panel>
            <asp:Panel ID="pnlAddWord" runat="server" Visible="false">
            <tr>
                <td style="height: 10px" colspan="5" class="tableTextAlign">
                <asp:Label ID="lblAddWord" CssClass="englishWord" runat="server"></asp:Label></td>
            </tr>
            </asp:Panel>
            <tr>
                <td style="height: 10px" colspan="5" class="tableTextAlign">
                Therefore, we kindly request you to forward us the above documents to process this claim further. Your earlier attention in this regard will help us to finalize this claim without delay.</td>
            </tr>
            
            <tr>
                <td style="height: 10px; padding-top:10px;" colspan="5" align="left">
                Thanking you,</td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="5" align="left">
                Yours faithfully,</td>
            </tr>
            <tr>
                <td style="height: 10px; padding-top:10px;" colspan="5" align="left">
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
                <td style="height: 10px" colspan="5" align="left">
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
                
                <td style="height: 10px">
                </td>
                <td style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px;">
                </td>
                <td style="height: 10px">
                </td>
            </tr>
            <asp:Panel ID="pnlPrintCopy" runat="server" Visible="false">
            <tr>
                <td style="height: 10px" align="left" colspan="5">
                Copy:- <asp:Label ID="lblPrintCopy" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px;">
                </td>
                <td style="height: 10px">
                </td>
            </tr>
            </asp:Panel>
             
            <tr>
                <td style="height: 10px; font-size:8pt; border-bottom:none;" colspan="5" align="left">
                <b>Our contact Nos. 2357247  /  2357225  /  2357290  /  2357252  /  2357253  /  2357205  /  2357221</b></td>
            </tr>
            
        </table> 
        <%  if (CopyToArr.Count != Index)
            {%>
        <ol style="margin:0px; list-style-type: none; display:none; border-bottom:none; ">
            <li class="pageBreakDiv" style="border-bottom:none;"></li>
        </ol><%}%>
           
        <%--<br clear="all" style="page-break-before:always" />--%>
    </div>
     <%
         }
         catch{ }
            %>    
            
    </form>
</body>
</html>
