<%@ Page Language="C#" AutoEventWireup="true" CodeFile="intOfDeath2503Eng002.aspx.cs" Debug="true" Inherits="intOfDeath2503Eng002" %>

<%@ PreviousPageType VirtualPath="~/intOfDeath2503Eng.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .break {
            page-break-before: always
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

<body style="text-align: center; background-color: #eeeeee">
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
                bool ClBR_Copy = false;
                bool resales_Copy = false;
                bool sales_Copy = false;
                foreach (ArrayList CopyArr in CopyToArr)
                {
                    Index++; string Hascopy = "No";
                    if (CopyArr[0] != null) { CopyToName = CopyArr[0].ToString(); }
                    else { CopyToName = ""; }
                    if (CopyArr[1] != null) { CopyToAddress1 = CopyArr[1].ToString(); }
                    else { CopyToAddress1 = ""; }
                    if (CopyArr[2] != null) { CopyToAddress2 = CopyArr[2].ToString(); }
                    else { CopyToAddress2 = ""; }
                    if (CopyArr[3] != null) { CopyToAddress3 = CopyArr[3].ToString(); }
                    else { CopyToAddress3 = ""; }
                    if (CopyArr[4] != null) { CopyToAddress4 = CopyArr[4].ToString(); }
                    else { CopyToAddress4 = ""; }
                    if (CopyArr[5] != null) { CopyToAddress5 = CopyArr[5].ToString(); }
                    else { CopyToAddress5 = ""; }

                    if (Index == 1)  ///// hide the addresses
                    {
                        litto.Visible = false; //litCopyto.Visible = false;
                        litbrName.Visible = false; litbrad1.Visible = false;
                        litbrad2.Visible = false; litbrad3.Visible = false; litbtrad4.Visible = false;
                        litagtname.Visible = false;
                        litagtad1.Visible = false; litagtad2.Visible = false; litagtad3.Visible = false;
                        //litagtad4.Visible = false;litto.Visible = false; litCopyName.Visible = false;
                        //Litcad1.Visible = false;  Litcad2.Visible = false;  Litcad3.Visible = false;
                        //Litcad4.Visible = false; 
                        Literal1.Visible = false;
                        Literal1.Visible = false;
                    }

                    if (Index == 2)
                    {
                        Literal1.Visible = true;
                        //litCopyto.Visible = true;
                        litto.Visible = true;
                        //litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                        //Litcad4.Visible = true;
                        if (CopyToArr.Count >= 1)
                        {
                            if (CopyArr[CopyArr.Count - 1].ToString() == "Customer Copy")
                            {
                                Cus_copy = true;
                            }
                            if (CopyArr[CopyArr.Count - 1].ToString() == "BRANCH   COPY")
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
                            if (CopyArr[CopyArr.Count - 1].ToString() == "CLOSER BRANCH COPY")
                            {
                                ClBR_Copy = true;
                                litclbr.Text = CopyToName + "(Closer Branch)";
                                litclad1.Text = CopyToAddress1;
                                litclad2.Text = CopyToAddress2;
                                litclad3.Text = CopyToAddress3;
                                litclad4.Text = CopyToAddress4;

                                litclbr.Visible = true;
                                litclad1.Visible = true;
                                litclad2.Visible = true;
                                litclad3.Visible = true;
                                litclad4.Visible = true;
                            }
                            if (CopyArr[CopyArr.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                Ins_Adv_Copy = true;
                                // litagtname.Text = CopyToName+"(Insurance Advisor)";
                                litagtad1.Text = CopyToAddress1 + "(Insurance Advisor)";
                                litagtad2.Text = CopyToAddress2;
                                litagtad3.Text = CopyToAddress3;
                                litagtad4.Text = CopyToAddress4;
                                litagtname.Visible = true;
                                litagtad1.Visible = true;
                                litagtad2.Visible = true;
                                litagtad3.Visible = true;
                                litagtad4.Visible = true;
                            }
                            //litCopyName.Visible = true;
                            //Litcad1.Visible = true;
                            //Litcad2.Visible = true;
                            //Litcad3.Visible = true;
                            //Litcad4.Visible = true;   
                            if (CopyArr[CopyArr.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                            {
                                resales_Copy = true;
                                litReMgr.Text = CopyArr[0].ToString();
                                litReMgrAd1.Text = CopyArr[1].ToString();
                                litReMgrAd2.Text = CopyArr[2].ToString();
                                litReMgr.Visible = true;
                                litReMgrAd1.Visible = true;
                            }

                            if (CopyArr[CopyArr.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                sales_Copy = true;
                                litSalMgr.Text = CopyArr[0].ToString();
                                litSalMgrAd1.Text = CopyArr[1].ToString();
                                litSalMgrAd2.Text = CopyArr[2].ToString();
                                litSalMgr.Visible = true;
                                litSalMgrAd1.Visible = true;
                                litSalMgrAd2.Visible = true;
                            }

                        }
                        if (CopyToArr.Count > 2)
                        {
                            ArrayList CopyToArr2 = (ArrayList)CopyToArr[2];
                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "CLOSER BRANCH COPY")
                            {
                                if (CopyToArr2.Count != 0)
                                {
                                    ClBR_Copy = true;
                                    litclbr.Text = CopyToArr2[0].ToString() + "(Closer Branch)";
                                    litclad1.Text = CopyToArr2[1].ToString();
                                    litclad2.Text = CopyToArr2[2].ToString();
                                    litclad3.Text = CopyToArr2[3].ToString();
                                    litclad4.Text = CopyToArr2[4].ToString();

                                    litclbr.Visible = true;
                                    litclad1.Visible = true;
                                    litclad2.Visible = true;
                                    litclad3.Visible = true;
                                    litclad4.Visible = true;
                                }
                            }
                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                if (CopyToArr2.Count != 0)
                                {
                                    Ins_Adv_Copy = true;
                                    //litagtcode.Text = CopyToArr2[6].ToString() ;
                                    litagtname.Text = CopyToArr2[0].ToString() + "(Insurance Advisor)";
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

                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                            {
                                resales_Copy = true;
                                litReMgr.Text = CopyToArr2[0].ToString();
                                litReMgrAd1.Text = CopyToArr2[1].ToString();
                                litReMgrAd2.Text = CopyToArr2[2].ToString();
                                litReMgr.Visible = true;
                                litReMgrAd1.Visible = true;
                            }

                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                sales_Copy = true;
                                litSalMgr.Text = CopyToArr2[0].ToString();
                                litSalMgrAd1.Text = CopyToArr2[1].ToString();
                                litSalMgrAd2.Text = CopyToArr2[2].ToString();
                                litSalMgr.Visible = true;
                                litSalMgrAd1.Visible = true;
                                litSalMgrAd2.Visible = true;
                            }

                        }
                        if (CopyToArr.Count > 3)
                        {
                            ArrayList CopyToArr3 = (ArrayList)CopyToArr[3];

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                if (CopyToArr3.Count != 0)
                                {
                                    Ins_Adv_Copy = true;
                                    // litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr3[0].ToString() + "(Insurance Advisor)";
                                    litagtad1.Text = CopyToArr3[1].ToString();
                                    litagtad2.Text = CopyToArr3[2].ToString();
                                    litagtad3.Text = CopyToArr3[3].ToString();
                                    litagtad4.Text = CopyToArr3[4].ToString();

                                    // litagtcode.Visible = true;
                                    litagtname.Visible = true;
                                    litagtad1.Visible = true;
                                    litagtad2.Visible = true;
                                    litagtad3.Visible = true;
                                    litagtad4.Visible = true;
                                }
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                            {
                                resales_Copy = true;
                                litReMgr.Text = CopyToArr3[0].ToString();
                                litReMgrAd1.Text = CopyToArr3[1].ToString();
                                litReMgrAd2.Text = CopyToArr3[2].ToString();
                                litReMgr.Visible = true;
                                litReMgrAd1.Visible = true;
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                sales_Copy = true;
                                litSalMgr.Text = CopyToArr3[0].ToString();
                                litSalMgrAd1.Text = CopyToArr3[1].ToString();
                                litSalMgrAd2.Text = CopyToArr3[2].ToString();
                                litSalMgr.Visible = true;
                                litSalMgrAd1.Visible = true;
                                litSalMgrAd2.Visible = true;
                            }
                        }
                        //litCopyName.Text = CopyToName;
                        //Litcad1.Text = CopyToAddress1;
                        //Litcad2.Text = CopyToAddress2;
                        //Litcad3.Text = CopyToAddress3;
                        //Litcad4.Text = CopyToAddress4; 
                    }
                    if (Index == 3)
                    {
                        Literal1.Visible = true;// litCopyto.Visible = true;
                        litto.Visible = true;
                        //litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                        //Litcad4.Visible = true; 

                        if (CopyToArr.Count >= 2)
                        {
                            ArrayList CopyToArr2 = (ArrayList)CopyToArr[2];
                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "CLOSER BRANCH COPY")
                            {
                                if (CopyToArr2.Count != 0)
                                {
                                    ClBR_Copy = true;
                                    litclbr.Text = CopyToArr2[0].ToString() + "(Closer Branch)";
                                    litclad1.Text = CopyToArr2[1].ToString();
                                    litclad2.Text = CopyToArr2[2].ToString();
                                    litclad3.Text = CopyToArr2[3].ToString();
                                    litclad4.Text = CopyToArr2[4].ToString();

                                    litclbr.Visible = true;
                                    litclad1.Visible = true;
                                    litclad2.Visible = true;
                                    litclad3.Visible = true;
                                    litclad4.Visible = true;
                                }
                            }
                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                if (CopyToArr2.Count != 0)
                                {
                                    Ins_Adv_Copy = true;
                                    // litagtcode.Text = CopyToArr2[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr2[0].ToString() + "(Insurance Advisor)";
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

                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                            {
                                resales_Copy = true;
                                litReMgr.Text = CopyToArr2[0].ToString();
                                litReMgrAd1.Text = CopyToArr2[1].ToString();
                                litReMgrAd2.Text = CopyToArr2[2].ToString();
                                litReMgr.Visible = true;
                                litReMgrAd1.Visible = true;
                            }

                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                sales_Copy = true;
                                litSalMgr.Text = CopyToArr2[0].ToString();
                                litSalMgrAd1.Text = CopyToArr2[1].ToString();
                                litSalMgrAd2.Text = CopyToArr2[2].ToString();
                                litSalMgr.Visible = true;
                                litSalMgrAd1.Visible = true;
                                litSalMgrAd2.Visible = true;
                            }

                        }
                        if (CopyToArr.Count > 3)
                        {
                            ArrayList CopyToArr3 = (ArrayList)CopyToArr[3];

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                if (CopyToArr3.Count != 0)
                                {
                                    Ins_Adv_Copy = true;
                                    //  litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr3[0].ToString() + "(Insurance Advisor)";
                                    litagtad1.Text = CopyToArr3[1].ToString();
                                    litagtad2.Text = CopyToArr3[2].ToString();
                                    litagtad3.Text = CopyToArr3[3].ToString();
                                    litagtad4.Text = CopyToArr3[4].ToString();

                                    //  litagtcode.Visible = true;
                                    litagtname.Visible = true;
                                    litagtad1.Visible = true;
                                    litagtad2.Visible = true;
                                    litagtad3.Visible = true;
                                    litagtad4.Visible = true;
                                }
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                            {
                                resales_Copy = true;
                                litReMgr.Text = CopyToArr3[0].ToString();
                                litReMgrAd1.Text = CopyToArr3[1].ToString();
                                litReMgrAd2.Text = CopyToArr3[2].ToString();
                                litReMgr.Visible = true;
                                litReMgrAd1.Visible = true;
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                sales_Copy = true;
                                litSalMgr.Text = CopyToArr3[0].ToString();
                                litSalMgrAd1.Text = CopyToArr3[1].ToString();
                                litSalMgrAd2.Text = CopyToArr3[2].ToString();
                                litSalMgr.Visible = true;
                                litSalMgrAd1.Visible = true;
                                litSalMgrAd2.Visible = true;
                            }
                        }
                        //litCopyName.Text = CopyToName;
                        //Litcad1.Text = CopyToAddress1;
                        // Litcad2.Text = CopyToAddress2;
                        //Litcad3.Text = CopyToAddress3;
                        //Litcad4.Text = CopyToAddress4;
                    }
                    if (Index == 4)
                    {
                        Literal1.Visible = true; //litCopyto.Visible = true; 
                        litto.Visible = true;
                        //litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                        //Litcad4.Visible = true; 


                        if (CopyToArr.Count > 3)
                        {
                            ArrayList CopyToArr3 = (ArrayList)CopyToArr[3];

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                if (CopyToArr3.Count != 0)
                                {
                                    //litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr3[0].ToString() + "(Insurance Advisor)";
                                    litagtad1.Text = CopyToArr3[1].ToString();
                                    litagtad2.Text = CopyToArr3[2].ToString();
                                    litagtad3.Text = CopyToArr3[3].ToString();
                                    litagtad4.Text = CopyToArr3[4].ToString();

                                    // litagtcode.Visible = true;
                                    litagtname.Visible = true;
                                    litagtad1.Visible = true;
                                    litagtad2.Visible = true;
                                    litagtad3.Visible = true;
                                    litagtad4.Visible = true;
                                }
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                            {
                                resales_Copy = true;
                                litReMgr.Text = CopyToArr3[0].ToString();
                                litReMgrAd1.Text = CopyToArr3[1].ToString();
                                litReMgrAd2.Text = CopyToArr3[2].ToString();
                                litReMgr.Visible = true;
                                litReMgrAd1.Visible = true;
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "SALES MANAGER COPY")
                            {
                                sales_Copy = true;
                                litSalMgr.Text = CopyToArr3[0].ToString();
                                litSalMgrAd1.Text = CopyToArr3[1].ToString();
                                litSalMgrAd2.Text = CopyToArr3[2].ToString();
                                litSalMgr.Visible = true;
                                litSalMgrAd1.Visible = true;
                                litSalMgrAd2.Visible = true;
                            }
                        }
                        //litCopyName.Text = CopyToName;
                        //Litcad1.Text = CopyToAddress1;
                        //Litcad2.Text = CopyToAddress2;
                        //Litcad3.Text = CopyToAddress3;
                        //Litcad4.Text = CopyToAddress4;
                    }
                    if (Index == 5)
                    {
                        ArrayList CopyToArr4 = (ArrayList)CopyToArr[4];

                        if (CopyToArr4[CopyToArr4.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                        {
                            if (CopyToArr4.Count != 0)
                            {
                                //  litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                litagtname.Text = CopyToArr4[0].ToString() + "(Insurance Advisor)";
                                litagtad1.Text = CopyToArr4[1].ToString();
                                litagtad2.Text = CopyToArr4[2].ToString();
                                litagtad3.Text = CopyToArr4[3].ToString();
                                litagtad4.Text = CopyToArr4[4].ToString();

                                //litagtcode.Visible = true;
                                litagtname.Visible = true;
                                litagtad1.Visible = true;
                                litagtad2.Visible = true;
                                litagtad3.Visible = true;
                                litagtad4.Visible = true;
                            }
                        }
                        if (CopyToArr4[CopyToArr4.Count - 1].ToString() == "REGIONAL MANAGER COPY")
                        {
                            resales_Copy = true;
                            litReMgr.Text = CopyToArr4[0].ToString();
                            litReMgrAd1.Text = CopyToArr4[1].ToString();
                            litReMgrAd2.Text = CopyToArr4[2].ToString();
                            litReMgr.Visible = true;
                            litReMgrAd1.Visible = true;
                        }

                        if (CopyToArr4[CopyToArr4.Count - 1].ToString() == "SALES MANAGER COPY")
                        {
                            sales_Copy = true;
                            litSalMgr.Text = CopyToArr4[0].ToString();
                            litSalMgrAd1.Text = CopyToArr4[1].ToString();
                            litSalMgrAd2.Text = CopyToArr4[2].ToString();
                            litSalMgr.Visible = true;
                            litSalMgrAd1.Visible = true;
                            litSalMgrAd2.Visible = true;
                        }
                    }
                }
        %>

        <div id="printDiv" style="text-align: center; width: 630px; background-color: white; padding: 0px 0px; margin-right: auto; margin-left: auto;padding-top:25px;">
            <table style="font-size: 9pt; width: 100%; font-family: 'Trebuchet MS'; text-align: left;">
                <tr>
                    <td style="width: 10px; height: 0px"></td>
                    <td style="width: 190px; height: 0px"></td>
                    <td style="width: 135px; height: 0px;"></td>
                    <td style="width: 135px; height: 0px;"></td>
                    <td style="width: 150px; height: 0px;"></td>
                    <td style="width: 10px; height: 0px"></td>
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
                    <td style="height: 20px; text-align: left; padding-top: 10px;" colspan="2">

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">REGISTERED POST</strong></td>
                    <td></td>
                    <td style="height: 20px; text-align: left; font-size: 9pt; padding: 0px;">
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
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2357253/2357205/2357221
                        </strong></td>
                    <td></td>
                    <td style="height: 20px; text-align: left; font-size: 9pt; padding: 0px;" colspan="1">Date :
                    <asp:Label ID="lbldate" runat="server" Font-Names="Trebuchet MS" Font-Size="9pt"></asp:Label></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="2"></td>
                    <td style="height: 10px"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="5">
                        <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="5">
                        <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="5">
                        <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="5">
                        <asp:Literal ID="litad3" runat="server"></asp:Literal>,<asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                </tr>

                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px; padding-top: 5px;" colspan="4">Dear Sir/Madam,</td>
                    <td style="height: 10px"></td>
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
                    <td style=""></td>
                    <td style="text-align: justify; padding-top: 5px;" colspan="4">We refer to your claim &nbsp;consequent to the death of the
                            Life Assured under the above policy.
                            <span id="otherDesc" runat="server">Please return at your earliest the enclosed Claim Forms duly filled in together
                            with the other documents list below, to enable us to consider our liability under
                            the Policy.</span></td>
                    <td style=""></td>
                </tr>

                <tr style="font-size: 9pt;">
                    <td style="height: 20px; padding-top: 5px;"></td>
                    <td style="height: 20px; text-align: left; padding-top: 5px;" colspan="4">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litrClmFrom" Text="CLAIMS FORMS" runat="server" Visible="false"></asp:Literal></strong></strong>
                         
                    </td>
                    <td style="height: 20px; padding-top: 5px;"></td>
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
                    <td style="height: 20px; text-align: left;" colspan="4">
                        <strong id="otherDesc2" runat="server" style="font-size: 9pt; font-family: 'Trebuchet MS'">OTHER DOCUMENTS. Original (Photocopies of these certificates are not acceptable)</strong>

                    </td>
                    <td style="height: 20px;"></td>
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
                    <td style="height: 10px"></td>
                    <td style="text-justify: auto; height: 10px; text-align: justify"
                        colspan="4">
                        <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="text-justify: auto; height: 10px; text-align: justify"
                        colspan="4">
                        <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="text-justify: auto; height: 10px; text-align: justify"
                        colspan="4">
                        <asp:Literal ID="litreq24" runat="server"></asp:Literal></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 20px"></td>
                    <td colspan="4" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 20px; text-align: justify; text-justify: auto;">
                        <asp:Table ID="tblNotices" runat="server" Width="100%" HorizontalAlign="Justify" CaptionAlign="Top" Font-Size="9pt" BorderWidth="0px" Font-Names="Trebuchet MS" Style="text-align: justify; margin-left: 0px;">
                        </asp:Table>
                    </td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>
                <%--<tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="height: 20px; text-align: justify; font-size: 9pt; font-family: 'Trebuchet MS';" colspan="2">
                       Claim forms should be signed by the nominee of this policy.  Please send the certified copy of the NIC of the nominee. If the Nominee was minor, the claim forms should be signed by the Father/Mother/Guardian of the child.</td>
                <td style="width: 37px; height: 20px; font-size: 9pt;">
                </td>
            </tr>--%>
                <tr id="desc1" runat="server">
                    <td style="height: 10px"></td>
                    <td style="text-justify: auto; height: 10px; text-align: justify"
                        colspan="4">We would kindly request your prompt attention in this matter as your claim on this policy cannot be processed until you submit above mentioned requirements,</td>
                    <td style="height: 10px"></td>
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
                    <td style="height: 6px" colspan="4">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <strong>
                                <asp:Literal ID="litrEnclose" Text="Enclosed" runat="server" Visible="false"></asp:Literal></strong>
                    </td>
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
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="3"></td>
                    <td style="height: 10px; padding: 0px 0px 0px 70px;">Thanking You,</td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="3"></td>
                    <td style="height: 10px; padding: 0px 0px 0px 70px;">Yours faithfully</td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="3"></td>
                    <td style="height: 10px; padding: 0px 0px 0px 70px;">
                        <strong>SRI LANKA INSURANCE CORPORATION LIFE LTD</strong></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td style="height: 10px" colspan="3"></td>

                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 9px; text-align: left; padding-left: 70px">
                       <%-- <asp:Label ID="lblSignature" runat="server" Text="" Visible="false"> </asp:Label>--%>
                        <asp:Panel runat="server" ID="lblSignature" Visible="false">
                            <asp:Image ID="SignatureImage" ImageUrl="~/Image/UserSignature.png" runat="server" style="width: 140px; height: 40px;" alt="signature" />
                        </asp:Panel>
                        
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr style="font-size: 9pt; height: 0px; line-height: 0px">
                    <td></td>
                    <td colspan="3"></td>
                    <td style="padding: 0px 0px 0px 70px;">.............................</td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="3"></td>
                    <td style="height: 10px; padding: 0px 0px 0px 70px;">
                        <strong>For Life Manager</strong></td>
                    <td style="height: 10px"></td>
                </tr>

                <tr>
                    <td class="auto-style1"></td>
                    <td style="height: 10px" colspan="3"></td>
                    <td style="height: 20px; text-align: center; text-align: left; padding-left: 70px">
                        <asp:Label ID="lblName" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblDesig" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lbldip" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblComp" runat="server" Text="" Visible="false"> </asp:Label>
                        <br />
                        <asp:Label ID="lblepf" runat="server" Text="" Visible="false"> </asp:Label>
                    </td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td style="height: 10px" colspan="3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="height: 6px; vertical-align: text-top; text-align: left;" colspan="5">
                        <%if (Ins_Adv_Copy == true || resales_Copy == true || sales_Copy == true || Br_Copy == true || ClBR_Copy == true)
                            {
                        %>
                        <asp:Literal ID="litto" runat="server" Text="Copy To :-"></asp:Literal></td>
                    <%} %>
                </tr>
                <%if (Ins_Adv_Copy == true)
                    {
                %>
                <tr>
                    <td style=""></td>
                    <td colspan="5" style="height: 8px; vertical-align: top; text-align: left;">
                        <asp:Literal ID="litagtname" runat="server"></asp:Literal><asp:Literal ID="litagtad1" runat="server"></asp:Literal><asp:Literal ID="litagtad2" runat="server"></asp:Literal><asp:Literal ID="litagtad3" runat="server"></asp:Literal><asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                </tr>
                <%
                    }
                    if (resales_Copy == true)
                    {
                %>
                <tr>
                    <td style=""></td>
                    <td colspan="5" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px">
                        <asp:Literal ID="litReMgr" runat="server"></asp:Literal>
                        <asp:Literal ID="litReMgrAd1" runat="server"></asp:Literal>
                        <asp:Literal ID="litReMgrAd2" runat="server"></asp:Literal>
                    </td>
                </tr>

                <%
                    }
                    if (sales_Copy == true)
                    {
                %>
                <tr>
                   <td style=""></td>
                    <td colspan="5" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 5px">
                        <asp:Literal ID="litSalMgr" runat="server"></asp:Literal>
                        <asp:Literal ID="litSalMgrAd1" runat="server"></asp:Literal>
                        <asp:Literal ID="litSalMgrAd2" runat="server"></asp:Literal>
                    </td>
                </tr>

                <%
                    }
                    if (Br_Copy == true)
                    {
                %>
                <%--<td style="width: 69px; height: 5px"></td>--%>
                <tr>
                <td style=""></td>
                <td colspan="5" style="height: 6px; font-size: 9pt; font-family: 'Trebuchet MS';">
                    <asp:Literal
                        ID="litbrName" runat="server"></asp:Literal><asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2"
                            runat="server"></asp:Literal><asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal
                                ID="litbtrad4" runat="server"></asp:Literal></td>
                </tr>
                            <%
                                }
                                if (ClBR_Copy == true)
                                {
                            %>

                <tr>
                    <td style=""></td>
                    <td colspan="5" style="height: 8px; vertical-align: top;">
                        <asp:Literal ID="litclbr" runat="server"></asp:Literal><asp:Literal ID="litclad1" runat="server"></asp:Literal><asp:Literal ID="litclad2" runat="server"></asp:Literal><asp:Literal ID="litclad3" runat="server"></asp:Literal><asp:Literal ID="litclad4" runat="server"></asp:Literal></td>
                </tr>
                <%
                    }
                %>

                <tr>
                    <td style=""></td>
                    <td colspan="5" style="height: 8px">
                        <asp:Literal ID="Literal1" runat="server" Text="(Please contact the claimant immediately and render all possible assistance in order to enable him/her to comply with the above requirements.)"></asp:Literal></td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <p class="break"></p>
        </div>
        <%
            }
            catch
            {

            }
        %>
    </form>
</body>
</html>
