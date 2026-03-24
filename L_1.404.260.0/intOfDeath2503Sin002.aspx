<%@ Page Language="C#" AutoEventWireup="true" CodeFile="intOfDeath2503Sin002.aspx.cs" Inherits="intOfDeath2503Sin002" %>

<%@ PreviousPageType VirtualPath="~/IntofDth2503Sin.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .break {
            page-break-before: always
        }

        .style1 {
            height: 25px;
        }

        .style2 {
            height: 25px;
        }

        .style3 {
            height: 25px;
        }
        @font-face {
            font-family: "Sandaya";
            src: url("fonts/SANDHYA.woff2");
            src: local("Sandaya"),url("fonts/SANDHYA.woff2"),url("fonts/SANDHYA.ttf"),url("fonts/SANDHYA.woff"),url("fonts/SANDHYA.eot"),url("fonts/SANDHYA.svg");
            font-weight: normal;
            font-style: normal;
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
                        // litto.Visible = false; 
                        litCopyto.Visible = false;
                        litbrName.Visible = false; litbrad1.Visible = false;
                        litbrad2.Visible = false; litbrad3.Visible = false; litbtrad4.Visible = false;
                        litagtname.Visible = false;
                        litagtad1.Visible = false; litagtad2.Visible = false; litagtad3.Visible = false;
                        //litagtad4.Visible = false; litto.Visible = false; litCopyName.Visible = false;
                        //Litcad1.Visible = false; Litcad2.Visible = false; Litcad3.Visible = false;
                        // Litcad4.Visible = false; litcusno.Visible = false; 
                        litcusno.Visible = false;
                    }

                    if (Index == 2)
                    {
                        litcusno.Visible = true;
                        litCopyto.Visible = true; //litto.Visible = true;
                                                  //litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                                                  //                    Litcad4.Visible = true; litcusno.Visible = true;
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

                            if (CopyArr[CopyArr.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
                            //litCopyName.Visible = true;
                            //Litcad1.Visible = true;
                            //Litcad2.Visible = true;
                            //Litcad3.Visible = true;
                            //Litcad4.Visible = true;

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
                                    //litagtcode.Text = CopyToArr2[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr2[0].ToString() + "(Insurance Advisor)";
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

                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
                                    //litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr3[0].ToString() + "(Insurance Advisor)";
                                    litagtad1.Text = CopyToArr3[1].ToString();
                                    litagtad2.Text = CopyToArr3[2].ToString();
                                    litagtad3.Text = CopyToArr3[3].ToString();
                                    litagtad4.Text = CopyToArr3[4].ToString();

                                    //litagtcode.Visible = true;
                                    litagtname.Visible = true;
                                    litagtad1.Visible = true;
                                    litagtad2.Visible = true;
                                    litagtad3.Visible = true;
                                    litagtad4.Visible = true;
                                }
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
                        // Litcad3.Text = CopyToAddress3;
                        //Litcad4.Text = CopyToAddress4;
                    }
                    if (Index == 3)
                    {
                        litcusno.Visible = true;
                        litCopyto.Visible = true; //litto.Visible = true;
                                                  //litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                                                  //                    Litcad4.Visible = true; litcusno.Visible = true;

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
                                    //litagtcode.Text = CopyToArr2[6].ToString() + "(Insurance Advisor)";
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
                            if (CopyToArr2[CopyToArr2.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
                                    //litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr3[0].ToString() + "(Insurance Advisor)";
                                    litagtad1.Text = CopyToArr3[1].ToString();
                                    litagtad2.Text = CopyToArr3[2].ToString();
                                    litagtad3.Text = CopyToArr3[3].ToString();
                                    litagtad4.Text = CopyToArr3[4].ToString();

                                    //litagtcode.Visible = true;
                                    litagtname.Visible = true;
                                    litagtad1.Visible = true;
                                    litagtad2.Visible = true;
                                    litagtad3.Visible = true;
                                    litagtad4.Visible = true;
                                }
                            }

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
                        litcusno.Visible = true;
                        litCopyto.Visible = true; //litto.Visible = true;
                                                  //litCopyName.Visible = true; Litcad1.Visible = true; Litcad2.Visible = true;
                                                  ////                    Litcad4.Visible = true; litcusno.Visible = true;


                        if (CopyToArr.Count > 3)
                        {
                            ArrayList CopyToArr3 = (ArrayList)CopyToArr[3];

                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "INSURANCE ADVISOR'S COPY")
                            {
                                if (CopyToArr3.Count != 0)
                                {
                                    //  litagtcode.Text = CopyToArr3[6].ToString() + "(Insurance Advisor)";
                                    litagtname.Text = CopyToArr3[0].ToString() + "(Insurance Advisor)";
                                    litagtad1.Text = CopyToArr3[1].ToString();
                                    litagtad2.Text = CopyToArr3[2].ToString();
                                    litagtad3.Text = CopyToArr3[3].ToString();
                                    litagtad4.Text = CopyToArr3[4].ToString();

                                    //litagtcode.Visible = true;
                                    litagtname.Visible = true;
                                    litagtad1.Visible = true;
                                    litagtad2.Visible = true;
                                    litagtad3.Visible = true;
                                    litagtad4.Visible = true;
                                }
                            }
                            if (CopyToArr3[CopyToArr3.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
                        // Litcad1.Text = CopyToAddress1;
                        // Litcad2.Text = CopyToAddress2;
                        // Litcad3.Text = CopyToAddress3;
                        // Litcad4.Text = CopyToAddress4;
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
                        if (CopyToArr4[CopyToArr4.Count - 1].ToString() == "REGIONAL SALES MANAGER COPY")
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
        <div id="printDiv" style="text-align: center; width: 635px; background-color: white; padding: 0px 0px; margin-right: auto; margin-left: auto;padding-top:25px;">
            <table style="font-size: 9pt; width: 100%; font-family: 'Trebuchet MS'; text-align: left;">
                <tr>
                    <td style="width: 10px; height: 0px"></td>
                    <td style="width: 190px; height: 0px"></td>
                    <td style="width: 135px; height: 0px;"></td>
                    <td style="width: 135px; height: 0px;"></td>
                    <td style="width: 150px; height: 0px;"></td>
                    <td style="width: 10px; height: 0px"></td>
                </tr>
                <%--<tr>
                    <td style="height: 10px"></td>
                    <td></td>
                    <td></td>
                    <td style="height: 10px" colspan="2"></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td></td>
                    <td></td>
                    <td style="height: 10px" colspan="2"></td>
                    <td style="height: 10px"></td>
                </tr>--%>
                <tr>
                    <td class="style1"></td>
                    <td style="text-align: right; padding-top: 5px;" colspan="4" class="style2">
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS';"><span style="font-size: 9pt; font-family: Trebuchet MS; padding: 3px; border: 1px solid black">LI/DC/FO/SE/05</span></strong>
                    </td>
                    <td class="style3"></td>
                </tr>
                <tr>
                    <td style="height: 16px"></td>
                    <td colspan="4">
                        <span style="font-size: 9pt; font-family: 'Sandaya'">fmdarudxlh(</span> <span style="font-size: 9pt; font-family: 'Trebuchet MS'">2503</span>

                        <span style="font-family: Sandaya; padding-left: 390px; text-decoration: underline;"><strong>w.;s rys;hs</strong></span>
                    </td>
                    <td style="height: 16px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 2px"></td>
                    <td style="height: 2px" colspan="4"></td>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="height: 12px"></td>
                    <td style="height: 12px" colspan="4">
                        <strong style="font-size: 9pt; font-family: 'Sandaya'">oqrl:k wxlh (</strong>
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">2357247/2357225/2357290/2357252/2357253/2357205/2357221</strong>

                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'"><%--<asp:Literal ID="litorYourRef" runat="server"></asp:Literal>--%></strong>
                        <strong><span style="font-family: Sandaya; padding-left: 25px;">Tfnz fhduqj (</span></strong>
                    </td>
                    <td style="height: 12px"></td>
                </tr>
                <tr>
                    <td style="height: 16px"></td>
                    <td style="height: 16px" colspan="4">
                        <strong style="font-size: 9pt; font-family: 'Sandaya'">,sLs; ;emEf,ks</strong>

                        <span style="font-family: Sandaya; padding-left: 395px;"><strong>oskh ( </strong></span>
                        <strong style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litdate" runat="server"></asp:Literal></strong>

                    </td>
                    <td style="height: 16px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 3px"></td>
                    <td style="height: 3px" colspan="4"></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 25px"></td>
                    <td style="height: 25px; padding-top: 5px; padding-bottom: 5px;" colspan="4">
                        <table style="margin-left: 250px;">
                            <tr>
                                <td style="border: 1px solid black; text-align: center"><span style="font-size: 9pt; font-family: 'Sandaya';">ms&lt;s;=frA wfma fhduqj ioZyka lrkak</span></td>
                                <td style="border: 1px solid black; text-align: center">
                                    <span style="font-size: 9pt; font-family: 'Sandaya'">cS' ysusluz$1$</span>
                                    <span style="font-size: 9pt; font-family: 'Trebuchet MS'">
                                        <asp:Literal ID="litorref" runat="server"></asp:Literal>
                                    </span>
                                </td>
                            </tr>
                        </table>
                        <%--<span style="border: 1px solid black; padding:5px; margin-left:240px;"><span style="font-size: 9pt; font-family: 'Sandaya'; border-right: 1px solid black; padding:7px; ">ms&lt;s;=frA wfma fhduqj ioZyka lrkak</span>
                       <span style="font-size: 9pt; font-family: 'Sandaya'">cS' ysusluz$1$</span> <span
                            style="font-size: 9pt; font-family: 'Trebuchet MS'">
                            <asp:Literal ID="litorref" runat="server"></asp:Literal></span></span>--%>
                    </td>
                    <td style="height: 25px"></td>
                </tr>
                <tr>
                    <td style="height: 3px"></td>
                    <td style="height: 3px" colspan="4"></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="4">
                        <asp:Literal ID="litname" runat="server"></asp:Literal></td>
                    <td style="font-size: 9pt; font-family: Sandaya; height: 10px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 10px"></td>
                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 10px"
                        colspan="4">
                        <asp:Literal ID="litad1" runat="server"></asp:Literal></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 10px"></td>
                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 10px"
                        colspan="4">
                        <asp:Literal ID="litad2" runat="server"></asp:Literal></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr style="font-family: Sandaya">
                    <td style="height: 10px"></td>
                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 10px"
                        colspan="4">
                        <asp:Literal ID="litad3" runat="server"></asp:Literal>,<asp:Literal ID="litad4" runat="server"></asp:Literal></td>
                    <td style="font-size: 9pt; height: 10px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 5px"></td>
                    <td style="height: 5px" colspan="4"></td>
                    <td style="height: 5px"></td>
                </tr>
                <tr style="font-size: 9pt; font-family: Sandaya">
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="4">
                        <span style="font-family: Sandaya"><span>ms%h uy;auhdfKks$uy;aushks<span style="font-family: Trebuchet MS">,</span></span></span></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 6px"></td>
                    <td style="height: 6px" colspan="4"></td>
                    <td style="height: 6px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 10px"></td>
                    <td style="font-weight: bold; height: 10px; text-align: left; text-decoration: underline"
                        colspan="4">
                        <span style="font-size: 9pt"><span style="font-family: Sandaya">cSjs; rlaIK Tmamq wxl <span
                            style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">(<span style="font-size: 9pt; font-family: Trebuchet MS">
                                <asp:Literal
                                    ID="litpolno" runat="server"></asp:Literal>&nbsp;
                                    <span style="font-size: 9pt; font-family: Sandaya">ush.sh </span>&nbsp;<span
                                        style="font-family: Trebuchet MS"><asp:Literal ID="litnameofdead" runat="server"></asp:Literal>
                                        &nbsp; &nbsp; </span><span
                                            style="font-family: Trebuchet MS"><span style="font-size: 9pt; font-family: Sandaya">ush$uhd</span></span></span></span></span></span></span></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr style="font-family: Trebuchet MS">
                    <td style="height: 3px"></td>
                    <td style="height: 3px" colspan="4"></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr style="font-family: Trebuchet MS">
                    <td style="height: 14px;"></td>
                    <td style="text-align: justify; height: 14px;" colspan="4">
                        <span style="font-size: 9pt"><span style="font-family: Sandaya; text-justify: initial; text-align: justify;">by; ku ioZyka rCIs;hdf.a wNdjh fya;=fldgf.k tu rCIK Tmamqj hgf;a mek ke.S ;sfnk ysusluz ms'<'snoZjhs'</span></span></td>
                    <td style="font-size: 9pt; height: 14px;"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 6px"></td>
                    <td style="font-family: Trebuchet MS; height: 6px; text-align: justify"
                        colspan="4">
                        <span><span style="font-size: 9pt; font-family: Sandaya" id="otherDesc" runat="server">fuu Tmamqj hgf;a wmf.a bosrs lghq;= ioZyd fuz iu€ tjd we;s wdlD;s m;% ksis f,i iuzmQrAKlr my; ,shjs,s iu€ fkdmudj wm fj; ,efnkakg i,iajk f,i fuhska b,a,uq'</span></span></td>
                    <td style="height: 6px"></td>
                </tr>
                <tr style="font-family: Trebuchet MS">
                    <td style="height: 1px"></td>
                    <td style="height: 1px" colspan="4"></td>
                    <td style="height: 1px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 3px"></td>
                    <td style="font-family: Trebuchet MS; height: 3px; text-align: left"
                        colspan="2">
                        <strong><span style="font-size: 9pt"><span style="font-family: Sandaya; text-justify: initial; text-align: justify;">
                            <asp:Literal ID="litrClmFrom" Text="wdlD;s m;%" runat="server" Visible="false"></asp:Literal>
                        </span></span></strong></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px; text-justify: auto; text-align: left;"
                        colspan="4">
                        <asp:Table ID="tblClmForm" runat="server" Font-Names="Sandaya" HorizontalAlign="Left"
                            Width="100%" Font-Size="9pt" Height="1px" Style="line-height: normal; text-justify: auto; text-align: justify;">
                        </asp:Table>
                    </td>
                    <td style="height: 10px"></td>
                </tr>
                <tr style="font-family: Trebuchet MS">
                    <td style="height: 1px"></td>
                    <td style="height: 1px" colspan="4"></td>
                    <td style="height: 1px"></td>
                </tr>
                <tr style="font-size: 9pt">
                    <td style="height: 3px"></td>
                    <td style="font-family: Trebuchet MS; height: 3px; text-align: justify"
                        colspan="4">
                        <strong><span style="font-size: 9pt"><span id="otherDesc2" runat="server" style="font-family: Sandaya; text-justify: initial; text-align: left;">by; ioyka wlD;sm;% iu. my; ioyka wjYH;do wm fj; tjSug lghq;= lrkak'
                        </span><span style="font-family: Trebuchet MS">.</span></span></strong></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px; text-justify: auto; text-align: justify;"
                        colspan="4">
                        <asp:Table ID="tblOtherDoc" runat="server" Font-Names="Sandaya" HorizontalAlign="left"
                            Width="100%" Font-Size="9pt" Height="1px" Style="line-height: normal; text-justify: auto; text-align: justify;">
                        </asp:Table>
                    </td>
                    <td style="height: 10px"></td>
                </tr>
                <asp:Panel ID="ReqId" runat="server" Visible="false">
                    <tr>
                        <td style="height: 15px"></td>
                        <td style="text-justify: auto; font-size: 9pt; font-family: Sandaya; height: 15px; text-align: justify"
                            colspan="4">
                            <asp:Literal ID="litreq22" runat="server"></asp:Literal></td>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                        <td style="text-justify: auto; font-size: 9pt; font-family: Sandaya; height: 15px; text-align: justify"
                            colspan="4">
                            <asp:Literal ID="litreq23" runat="server"></asp:Literal></td>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                        <td style="text-justify: auto; height: 15px; text-align: justify"
                            colspan="4">
                            <span style="font-size: 9pt; font-family: Sandaya">
                                <asp:Literal ID="litreq21" runat="server"></asp:Literal></span><asp:Literal ID="litnomname" runat="server"></asp:Literal><span style="font-size: 9pt; font-family: Sandaya; text-justify: auto; text-align: justify;"><asp:Literal ID="litreq2" runat="server"></asp:Literal></span></td>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td style="height: 3px"></td>
                        <td style="height: 3px" colspan="4"></td>
                        <td style="height: 3px"></td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td style="width: 10px; height: 20px"></td>
                    <td colspan="4" style="font-size: 9pt; font-family: Sandaya; height: 20px; text-align: justify; text-justify: auto;">
                        <asp:Table ID="tblNotices" runat="server" Width="100%" Font-Names="Sandaya" HorizontalAlign="Justify" CaptionAlign="Top" Font-Size="9pt" BorderWidth="0px" Style="text-align: justify; margin-left: 0px;">
                        </asp:Table>
                    </td>
                    <td style="font-size: 9pt; height: 20px"></td>
                </tr>
                <%--<tr>
                    <td style="width: 21px; height: 10px">
                    </td>
                    <td style="width: 631px; height: 10px; text-align: justify" colspan="2">
                        <span style="font-size: 9pt; font-family: Sandaya; text-justify: auto; text-align: justify;">
                           fuz iu. tjd we;s ysusluz fm`ru kdusl m%;s,dNshd jsiska iuzmQrAK l,hq;=h wehf.a$Tyqf.a cd;sl yeoqqkquzmf;ys iy;sl lrk ,o msgm;la wm fj; tjSug lghq;= lrkak' kdusl m%;s,dNshd nd,jhialdr wfhla kuz fuz iu. tjk ysusluz lshkakdf.a m%ldYkh Tyqf.a$wehf.a mshd$uj$Ndrlrefjla jsiska iuzmQrAK l, hq;=h'</span></td>
                    <td style="width: 100px; height: 10px">
                    </td>
                </tr>--%>
                <tr>
                    <td style="height: 3px"></td>
                    <td style="height: 3px" colspan="4"></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr id="desc1" runat="server">
                    <td style="height: 10px"></td>
                    <td style="height: 10px; text-align: justify" colspan="4">
                        <span style="font-size: 9pt; font-family: Sandaya; text-justify: auto; text-align: justify;">ysusluz .ek jevsoqr ls%hd lsrSug wmg yelsjkqfha by;ska b,a,d we;s wjYH;djhka iuzmQrAKjQjdg miqj nejska fuu wjYH;djhka blaukska imqrd,Sug wjYH lghq;= lrk fuka ldreKslj okajd isgsuqq'</span></td>
                    <td style="height: 10px"></td>
                </tr>

                <tr>
                    <td style="height: 3px"></td>
                    <td style="height: 3px" colspan="4">
                        <asp:Panel ID="ReqNew" runat="server" Visible="false">
                            <span style="font-size: 9pt; font-family: Sandaya">
                                <asp:Literal ID="litreq23new" runat="server" Visible="false"></asp:Literal></span><br />
                        </asp:Panel>
                        <span style="font-size: 9pt; font-family: Sandaya">
                            <asp:Literal ID="litreqAll" runat="server"></asp:Literal></span>
                    </td>
                    <td style="height: 3px"></td>
                </tr>
                <tr>
                    <td style="height: 1px"></td>
                    <td style="height: 1px" colspan="4"></td>
                    <td style="height: 1px"></td>
                </tr>

                <tr style="font-size: 9pt">
                    <td style="height: 3px"></td>
                    <td style="font-family: Trebuchet MS; height: 3px; text-align: justify"
                        colspan="4">
                        <strong><span style="font-size: 9pt"><span style="font-family: Sandaya; text-justify: distribute; text-align: justify;">
                            <asp:Literal ID="litrEnclose" Text="nyd,Suz" runat="server" Visible="false"></asp:Literal>
                        </span></span></strong></td>
                    <td style="height: 3px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px; text-justify: auto; text-align: justify;"
                        colspan="4">
                        <asp:Table ID="tblEnclose" runat="server" Font-Names="Sandaya" HorizontalAlign="Left"
                            Width="100%" Font-Size="9pt" Height="1px" Style="line-height: normal; text-justify: auto; text-align: justify;">
                        </asp:Table>
                    </td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px"></td>
                    <td></td>
                    <td></td>
                    <td style="height: 10px">
                        <span style="font-size: 9pt"><span style="font-family: Sandaya">fuhg - jsYajdiS<?xml
                            namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px"></span></td>
                    <td></td>
                    <td></td>
                    <td style="height: 10px">
                        <span style="font-size: 9pt"><span style="font-family: Sandaya">YS% ,xld bkaIqjrkaia fldamfrAIka ,hs*a ,susgvz<o:p></o:p></span></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 4px"></td>
                    <td style="height: 4px"></td>
                    <td style="height: 4px"></td>
                    <td style="height: 4px"></td>
                    <td style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 9px; text-align: left;">
                        <asp:Panel runat="server" ID="lblSignature" Visible="false">
                            <asp:Image ID="SignatureImage" ImageUrl="~/Image/UserSignature.png" runat="server" Style="width: 140px; height: 40px;" alt="signature" />
                        </asp:Panel>
                    </td>
                    <td style="height: 4px"></td>
                </tr>
                <tr style="height: 0px; line-height: 0">
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>.............................</td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px"></td>
                    <td></td>
                    <td></td>
                    <td style="height: 10px">
                        <strong><span style="font-size: 9pt; font-family: Sandaya">cSjs; l&lt;uKdlre fjkqjg</span></strong></td>
                    <td style="height: 10px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px"></td>
                    <td style="height: 10px"></td>
                    <td style="height: 10px"></td>
                    <td style="height: 20px; text-align: left; font-family:'Times New Roman';">
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
                    <td style="height: 3px"></td>
                    <td style="height: 3px" colspan="2">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
                    <td style="height: 3px"></td>
                </tr>
                <tr>
                    <td style="height: 10px"></td>
                    <td style="height: 10px" colspan="4">
                        <table style="height: 122px; width: 100%; font-size: 9pt;">
                            <tr>
                                <td style="font-size: 9pt; width: 69px; font-family: Sandaya; height: 5px; vertical-align: top;">
                                    <%if (Ins_Adv_Copy == true || resales_Copy == true || sales_Copy == true || Br_Copy == true || ClBR_Copy == true)
                                        {
                                    %>
                                    <asp:Literal ID="litCopyto" runat="server" Text="msgm;a (-"></asp:Literal></td>
                                <%} %>

                                <%
                                    if (Ins_Adv_Copy == true)
                                    {
                                %>
                            </tr>
                            <tr>
                                <%--<td style="width: 69px; height: 5px"></td>--%>
                                <td colspan="3" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 5px">
                                    <asp:Literal ID="litagtname" runat="server"></asp:Literal>
                                    <asp:Literal ID="litagtad1" runat="server"></asp:Literal>
                                    <asp:Literal ID="litagtad2" runat="server"></asp:Literal>
                                    <asp:Literal ID="litagtad3" runat="server"></asp:Literal>
                                    <asp:Literal ID="litagtad4" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                }
                                if (resales_Copy == true)
                                {
                            %>
                            <tr>
                                <%--<td style="width: 69px; height: 5px"></td>--%>
                                <td colspan="3" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 5px">
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
                                <%--<td style="width: 69px; height: 5px"></td>--%>
                                <td colspan="3" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 5px">
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
                                <td colspan="3" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 5px">
                                    <asp:Literal
                                        ID="litbrName" runat="server"></asp:Literal>
                                    <asp:Literal ID="litbrad1" runat="server"></asp:Literal><asp:Literal ID="litbrad2"
                                        runat="server"></asp:Literal><asp:Literal ID="litbrad3" runat="server"></asp:Literal><asp:Literal
                                            ID="litbtrad4" runat="server"></asp:Literal></td>
                            </tr>

                <%
                    }
                    if (ClBR_Copy == true)
                    {
                %>
                <tr>
                    <%--<td style="width: 69px; height: 5px"></td>--%>
                    <td colspan="3" style="font-size: 9pt; font-family: 'Trebuchet MS'; height: 5px">
                        <asp:Literal ID="litclbr" runat="server"></asp:Literal><asp:Literal ID="litclad1" runat="server"></asp:Literal><asp:Literal ID="litclad2" runat="server"></asp:Literal><asp:Literal ID="litclad3" runat="server"></asp:Literal><asp:Literal ID="litclad4" runat="server"></asp:Literal></td>
                </tr>
                <%
                    }
                %>


                <tr>
                    <td colspan="3" style="font-size: 9pt; font-family: Sandaya; height: 15px; text-align: left">
                        <asp:Literal ID="litcusno" runat="server" Text="^lreKdlr ysusluz lshkakd wm%udoj yuqjS wm b,a,d we;s wjYH;djhka imqrd,Sug Tng oshyels yeu Wojzjlau fokak&"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 9pt; font-family: Sandaya; height: 15px; text-align: right"></td>
                </tr>
            </table>
                    </td>
                    <td style="height: 10px"></td>
            </tr>
            </table>
            <p class="break"></p>
        </div>
        <%
            }
            catch
            { }
        %>
    </form>
</body>
</html>
