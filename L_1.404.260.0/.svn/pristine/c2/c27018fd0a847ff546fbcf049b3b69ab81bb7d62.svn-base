<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADBDischargeSin001.aspx.cs" Inherits="ADBDischargeSin001" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/ADBApproveMemo002.aspx" %>
<%@ Reference Page="~/readAmountFunction.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
     P.breakhere {page-break-before: always}
</style>
    <title>SriLanka Insurance - Death Claims</title>

    <script src="JavaScript/FormValidation.js" type="text/javascript" language="javascript"></script>

    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric(arguments.Value))
            {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }   
    
<!--
function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
//-->
 
    </script>

    <style type="text/css">
    .break{page-break-before:always}
    @font-face
    {
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
<body style="text-align: center" onload="window.print()">
    <form id="form1" runat="server">
        <%
            try
            {
                string payeeName = "";
                string relationship = "";
                string reltype = "";
                double payeeAmt = 0;
                double percentage = 0;
                string affiNomiAssiLPTdat = "";

                foreach (string[] payeedetArr in arrList)
                {
                    payeeName = payeedetArr[0];
                    relationship = payeedetArr[1];
                    if (relationship == "ML")
                    {
                        this.litrel.Text = "Main Life";
                    }
                    else if (relationship == "SL")
                    {
                        this.litrel.Text = "Second Life";
                    }
                    else if (relationship == "Nominee")
                    {
                        this.litrel.Text = "Nominee";
                    }
                    reltype = payeedetArr[2];
                    payeeAmt = double.Parse(payeedetArr[3]);
                    percentage = double.Parse(payeedetArr[4]);
                    affiNomiAssiLPTdat = payeedetArr[5];

                    this.LitpayeeName.Text = payeeName;

                    if (relationship == "Son")
                    { this.litrel.Text = "mq; d"; }
                    if (relationship == "Daughter")
                    { this.litrel.Text = "oshKsh"; }
                    if (relationship == "Spouce")
                    { this.litrel.Text = "iylre$ldrsh"; }
                    if (relationship == "Brother")
                    { this.litrel.Text = "ifydaorhd"; }
                    if (relationship == "Sister")
                    { this.litrel.Text = "ifydaorsh"; }
                    if (relationship == "Mother")
                    { this.litrel.Text = "uj"; }
                    if (relationship == "Father")
                    { this.litrel.Text = "mshd"; }

                    this.LitPayeeType.Text = reltype;
                     
 
                     
                    double netclm100 = 0;
                    if (payeeAmt < 0) { netclm100 = 0; }
                    else { netclm100 = (Math.Round(payeeAmt, 2) * 100); }
                    if (netclm100 != 0)
                    {
                        string netclminwords = netclm100.ToString().Substring(0, (netclm100.ToString().Length - 2)) + "." + netclm100.ToString().Substring((netclm100.ToString().Length - 2), 2);
                        readAmountFunction readamt = new readAmountFunction();
                        this.LitSumInWords.Text = readamt.readAmount(netclminwords, "SRI LANKAN RUPEES", "CENTS ");
                    }
                    else
                    {
                        this.LitSumInWords.Text = "ZERO SRI LANKAN RUPEES AND ZERO CENTS ONLY";
                    }
                    this.litSumInFigures.Text = String.Format("{0:N}", payeeAmt);
                    //==============================================================
                    string Fulname = "";
                    string status = "";
                    DataManager dthintobj = new DataManager();


                    string polpersonalSel = "";
                    polpersonalSel = "select fullname,STATUS,SURNAME from LUND.POLPERSONAL where polno = " + polNo + " and PRPERTYPE = 1 ";
                    if (dthintobj.existRecored(polpersonalSel) != 0)
                    {
                        dthintobj.readSql(polpersonalSel);
                        System.Data.OracleClient.OracleDataReader polperReader = dthintobj.oraComm.ExecuteReader();
                        polperReader.Read();
                        {
                            if (!polperReader.IsDBNull(0)) { Fulname = polperReader.GetString(0).ToUpper().Trim(); } else { Fulname = ""; }
                            if (!polperReader.IsDBNull(1)) { status = polperReader.GetString(1).Trim(); } else { status = ""; }
                            if (Fulname.Contains("&"))
                            {
                                string namejoin = "";
                                string concatname = "";
                                string[] mnlifenm = Fulname.Split('.');
                                status = mnlifenm[0].ToString() + "." + mnlifenm[1].ToString() + ".";
                                for (int a = 2; a < mnlifenm.Length; a++)
                                {
                                    if (mnlifenm[a].ToString().Trim().Length == 1)
                                    {
                                        namejoin = mnlifenm[a].ToString().Trim() + ".";
                                    }
                                    else
                                    {
                                        namejoin = mnlifenm[a].ToString() + " ";
                                    }
                                    concatname = concatname + namejoin;
                                }
                                Fulname = concatname;
                            }

                            else if ((Fulname.Contains("MR.")) || (Fulname.Contains("MRS.")) || (Fulname.Contains("MISS.")) || (Fulname.Contains("DR.")) || (Fulname.Contains("REV.")) || (Fulname.Contains("PROF.")) || (Fulname.Contains("MS.")) || (Fulname.Contains("MASTER.")) || (Fulname.Contains("DR.")) || (Fulname.Contains("DR.(MRS)")) || (Fulname.Contains("DR.(MISS)")))
                            {
                                string namejoin_ = "";
                                string concatname_ = "";
                                string[] mnlifenm = Fulname.Split('.');
                                status = mnlifenm[0].ToString() + ".";
                                for (int a = 1; a < mnlifenm.Length; a++)
                                {
                                    if (mnlifenm[a].ToString().Trim().Length == 1)
                                    {
                                        namejoin_ = mnlifenm[a].ToString().Trim() + ".";
                                    }
                                    else
                                    {
                                        namejoin_ = mnlifenm[a].ToString() + " ";
                                    }
                                    concatname_ = concatname_ + namejoin_;
                                }
                                Fulname = concatname_;
                            }

                            if (status == "")
                            {
                                status = statusmn;
                            }

                        }
                        polperReader.Close();
                    }
                    if (Fulname == "")
                    {
                        status = "";
                        Fulname = phname;
                    }

                    //=============================================================== 

                    if (tbl == 34 || tbl == 38 || tbl == 39 || tbl == 46 || tbl == 49)
                    {
                        //===============================================================
                        DataManager dm = new DataManager();
                        int cvrno = 0;
                        string ChildFname = "";
                        string ChildStts = "";
                        string SelectAllcvrs = "select PRPERTYPE,FULLNAME,STATUS from lund.polpersonal where POLNO=" + polNo + "";
                        if (dm.existRecored(SelectAllcvrs) != 0)
                        {
                            dm.readSql(SelectAllcvrs);
                            System.Data.OracleClient.OracleDataReader rdchldcvr = dm.oraComm.ExecuteReader();
                            while (rdchldcvr.Read())
                            {
                                if (!rdchldcvr.IsDBNull(0)) { cvrno = rdchldcvr.GetInt32(0); } else { cvrno = 0; }
                                if (cvrno != 1 && cvrno != 2 && cvrno != 3)
                                {
                                    if (!rdchldcvr.IsDBNull(1)) { ChildFname = rdchldcvr.GetString(1).ToUpper().Trim(); } else { ChildFname = ""; }
                                    if (!rdchldcvr.IsDBNull(2)) { ChildStts = rdchldcvr.GetString(2).ToUpper().Trim(); } else { ChildStts = ""; }
                                    if ((ChildFname.Contains("MR.")) || (ChildFname.Contains("MRS.")) || (ChildFname.Contains("MISS.")) || (ChildFname.Contains("DR.")) || (ChildFname.Contains("REV.")) || (ChildFname.Contains("PROF.")) || (ChildFname.Contains("MS.")) || (ChildFname.Contains("MASTER.")) || (ChildFname.Contains("DR.")) || (ChildFname.Contains("DR.(MRS)")) || (ChildFname.Contains("DR.(MISS)")))
                                    {
                                        string[] chldnm = ChildFname.Split('.');
                                        ChildStts = chldnm[0].ToString() + ".";
                                        ChildFname = chldnm[1].ToString();
                                    }
                                }
                            }
                            rdchldcvr.Close();
                            this.litLifeassured.Text = status + Fulname + " & " + ChildStts + ChildFname;
                            dm.connClose();
                        }

                        else
                        {
                            this.litLifeassured.Text = status + Fulname;// +" & " + Fullname; ;
                        }

                        //===============================================================                    
                    }
                    else
                    {
                        #region Check Whether Spouse Cover Found for the Given Policy
                        DataManager dm = new DataManager();
                        string Fullname = "";
                        string SpsStatus = "";
                        string Selectcvr = "select FULLNAME,STATUS from lund.polpersonal where PRPERTYPE=2 and POLNO=" + polNo + "";
                        string ChkCvr_SP = "select RCOVR from lund.rcover where RPOL=" + polNo + " and RCOVR=101";
                        if (dm.existRecored(Selectcvr) != 0)
                        {
                            dm.readSql(Selectcvr);
                            System.Data.OracleClient.OracleDataReader reder1 = dm.oraComm.ExecuteReader();
                            while (reder1.Read())
                            {
                                if (!reder1.IsDBNull(0)) { Fullname = reder1.GetString(0).ToUpper().Trim(); } else { Fullname = ""; }
                                if (!reder1.IsDBNull(1)) { SpsStatus = reder1.GetString(1).Trim(); } else { SpsStatus = ""; }
                                if ((Fullname.Contains("MR.")) || (Fullname.Contains("MRS.")) || (Fullname.Contains("MISS.")) || (Fullname.Contains("DR.")) || (Fullname.Contains("REV.")) || (Fullname.Contains("PROF.")) || (Fullname.Contains("MS.")) || (Fullname.Contains("MASTER.")) || (Fullname.Contains("DR.")) || (Fullname.Contains("DR.(MRS)")) || (Fullname.Contains("DR.(MISS)")))
                                {
                                    string[] mnlifenm = Fullname.Split('.');
                                    SpsStatus = mnlifenm[0].ToString() + ".";
                                    Fullname = mnlifenm[1].ToString();
                                }
                            }
                            reder1.Close();
                            this.litLifeassured.Text = status + Fulname + " & " + SpsStatus + Fullname;
                            dm.connClose();
                        }
                        #endregion
                        else
                        {
                            this.litLifeassured.Text = status + Fulname;// +" & " + Fullname; ;
                        }
                    } 

                    this.litclmno.Text = claimNo.ToString();
                    this.litpolno.Text = polNo.ToString();

                    this.LitDateOfDeath.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                    this.LitIDCo.Text = comDate.ToString().Substring(0, 4) + "/" + comDate.ToString().Substring(4, 2) + "/" + comDate.ToString().Substring(6, 2);
                    this.LitDeceasedName.Text = nameOfDth;
                    this.litLifeAssured2.Text = nameOfDth;
                    
                    if (tbl == 34 || tbl == 38 || tbl == 39 || tbl == 46 || tbl == 49)
                    {
                        if (mos == "2")
                        {
                            this.litLifeAssured2.Text = nameOfDth;
                        }
                        if ((mos == "M" || mos == "S") && (recipient == "SL"))
                        {
                            LitPayeeType.Text = "Proposal";
                        }

                    }
                    if (mos == "S")
                    {
                        LitPayeeType.Text = "Proposal";
                    }

                    if (tbl == 14)
                    {
                        LitPayeeType.Text = "Proposal";
                    }
                    DataManager defObj = new DataManager();

                    if (LitPayeeType.Text.ToUpper() == "PROPOSAL")
                    {
                        string getpropdt = "select PRDATE from lund.promast where POLNO=" + polNo + "";
                        if (defObj.existRecored(getpropdt) != 0)
                        {
                            System.Data.OracleClient.OracleDataReader drprodt = defObj.oraComm.ExecuteReader();
                            while (drprodt.Read())
                            {
                                if (!drprodt.IsDBNull(0)) { TxtDated.Text = drprodt.GetInt32(0).ToString().Substring(0, 4) + "/" + drprodt.GetInt32(0).ToString().Substring(4, 2) + "/" + drprodt.GetInt32(0).ToString().Substring(6, 2); }
                            }
                            drprodt.Close();
                        }
                    }
                     
                     
                    if (int.Parse(affiNomiAssiLPTdat) > 9999999)
                    {
                        TxtDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                        // this.litDated.Text = affiNomiAssiLPTdat.Substring(0, 4) + "/" + affiNomiAssiLPTdat.Substring(4, 2) + "/" + affiNomiAssiLPTdat.Substring(6, 2);
                    }
                     
                    defObj.connClose(); 
                
        %>
        <div style="page-break-after: always">
            <table style="width: 651px">
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-size: 10pt; height: 10px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 8px; font-size: 10pt; text-align: left;">
                        <span style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                            mso-bidi-font-family: 'Times New Roman'">wfma fhduqj(cS$ysusluz$1 $<span style="font-size: 10pt;
                                font-family: Trebuchet MS"><asp:Literal ID="litclmno" runat="server"></asp:Literal></span></span></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 7px; font-size: 10pt;">
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 7px; width: 105px;">
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 7px">
                    </td>
                    <td colspan="2" style="height: 7px; font-size: 10pt;">
                        
                    </td>
                </tr>
                <tr style="font-weight: bold; font-size: 16pt">
                    <td colspan="6" style="height: 8px; font-size: 10pt;">
                      
                    </td>
                </tr>
                <tr style="font-weight: bold; font-size: 16pt">
                    <td colspan="6" style="height: 9px; font-size: 10pt;  text-align: left; font-weight:bold">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            <span style="font-size: 11pt; text-decoration: underline"></span><span style="font-size: 11pt">
                                <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; text-decoration: underline">
                                        <span style="font-family: Sandaya">wxl</span><span style="font-size: 10pt; font-family: 'Trebuchet MS'; ">&nbsp;</span><asp:Literal ID="litpolno" runat="server"></asp:Literal>
                                        <span style="font-size: 10pt; font-family: 'Trebuchet MS'; ">&nbsp;</span><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                                            <span style="font-size: 11pt"> orK Tmamqj f.jd
                                                ksu lsrSu </span></span></span></span></span></span></td>
                </tr>
                <tr style="font-size: 10pt; text-decoration: underline">
                    <td colspan="6" style="height: 9px; font-size: 10pt; text-align:left; font-weight:bold;">
                        <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            <span style="font-size: 10pt; font-family: Trebuchet MS;"></span><span style="font-size: 10pt">
                                <span style="font-family: Trebuchet MS">
                                    <asp:Literal ID="litLifeassured" runat="server"></asp:Literal>&nbsp; <span style="font-family: Sandaya">
                                        uy;d$uy;aush f.a</span></span></span></span><span style="mso-fareast-font-family: 'Times New Roman';
                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                            mso-bidi-font-family: 'Times New Roman'"><span><span style="font-size: 10pt"><span
                                                style="font-family: Trebuchet MS"><span style="font-family: Sandaya"> cSjs;h </span>
                                                 <span style="font-family: Sandaya">ms&lt;sn|j</span><span style="font-size: 10pt; font-family: 'Trebuchet MS'; ">&nbsp;</span><asp:Literal ID="LitIDCo"
                                                    runat="server"></asp:Literal><span style="font-size: 10pt; font-family: 'Trebuchet MS'; ">&nbsp;</span><span style="font-family: Sandaya"><span
                                                        style="font-size: 11pt">osk orK Tmamqjhs</span></span> 
                                            </span></span></span></span>
                    </td>
                </tr> 
                <tr style="font-size: 12pt">
                    <td colspan="6" style="height: 35px; font-size: 10pt; text-align: justify; line-height:22px; padding-top:15px;">
                        <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">
                            by; ku i|yka <span style="font-family: Trebuchet MS">
                                <asp:Literal ID="LitDeceasedName" runat="server"></asp:Literal></span> 
                            <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman';
                                font-weight: normal; font-size: 10pt;"><span style="font-family: Sandaya">uy;d$uy;aush jsiska</span>
                                <asp:Literal ID="litrel" runat="server"></asp:Literal>
                                 <span style="font-family: Sandaya">^ush.sh whg we;s kEluz fyda whs;sjdisluz i|yka
                                    lrkak</span><span style="font-family: Times New Roman">.</span><span style="font-family: 'Trebuchet MS';
                                        font-size: 10pt;"><span style="font-family: Sandaya">&amp; jk ud</span>&nbsp;<asp:Literal
                                            ID="LitpayeeName" runat="server"></asp:Literal>
                                         <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                            mso-bidi-font-family: 'Times New Roman'">fj;<span
                                                style="font-family: Sandaya"> <span style="font-size: 10pt; font-family: Trebuchet MS">
                                                    <asp:TextBox ID="TxtDated" runat="server" Height="13px" MaxLength="10" Visible="true"
                                                        Width="81px"></asp:TextBox>
                                                    <span style="font-family: 'Trebuchet MS'; font-size: 10pt;"><span style="font-family: Sandaya">
                                                        od;u hgf;a m%odkh lrk ,o</span> &nbsp;<span style="font-family: Trebuchet MS">
                                                            <asp:Literal ID="LitPayeeType" runat="server"></asp:Literal>
                                                            &nbsp; &nbsp;<span style="font-family: Sandaya">m%ldr mQrAj<span style="font-size: 11pt"> 
                                                                <span style="font-size: 10pt">Tmamqfjz ku i|yka <span style="font-family: 'Trebuchet MS';
                                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                    mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'; font-size: 10pt;">
                                                                    <span style="font-family: Sandaya">we;a;djqo </span>
                                                                    <asp:Literal ID="LitDateOfDeath" runat="server"></asp:Literal>&nbsp; <span style="font-family: 'Trebuchet MS';
                                                                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                        mso-bidi-language: AR-SA; mso-bidi-font-family: 'Sandya'; font-size: 10pt;"><span
                                                                            style="font-family: Sandaya">jeks osk ush.<u>s</u>hdjqo</span>&nbsp;
                                                                        <asp:Literal ID="litLifeAssured2" runat="server"></asp:Literal>
                                                                        <span style="font-size: 10pt; font-family: Sandaya;">uy;d$uy;aushf.a <span style="font-size: 10pt">
                                                                            cSjs;h ms&lt;sn| rC<b style="mso-bidi-font-weight: normal">I</b>K Tmamqj hgf;a<span
                                                                                style="mso-spacerun: yes"> </span>ud$wm<span style="mso-spacerun: yes"> </span>i;=jk
                                                                            ishtZu ysusluz yd whs;sjdisluz<span style="font-size: 11pt"> <span><span style="font-size: 10pt">
                                                                                mrsmQrAK jk </span><span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                    mso-bidi-font-family: 'Times New Roman'"><span style="font-size: 10pt">mrsoafoka <span style="font-size: 10pt; font-weight:bold;">yosis wk;=re m%;s,dNh</span> <asp:Label ID="lbladbonexgr" runat="server" Font-Names="Sandaya" Font-Size="10pt" Visible="False"> ^ohdkAjs;j& </asp:Label>
                                                                                    f.jSu fjkqfjka remsh,a <span
                                                                                            style="font-family: Trebuchet MS"><asp:Literal ID="LitSumInWords" runat="server"></asp:Literal></span>
                                                                                    </span><span style="font-size: 10pt; font-family: Trebuchet MS"><span style="font-size: 10pt">
                                                                                        ( <span style="font-family: Sandaya">re( <span style="font-family: Trebuchet MS">
                                                                                            <asp:Literal ID="litSumInFigures" runat="server"></asp:Literal>&nbsp;</span> </span>
                                                                                        ) &nbsp;<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                            mso-bidi-font-family: 'Times New Roman'">la <span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                mso-bidi-font-family: 'Times New Roman'; line-height: 15pt;">jq uqo,la YS% ,xld bkaIqjrkaia fldamfrAIka ,hs*a ,susgvz fj;ska ,nd.;a nj fuhska m%ldY lrus<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                    mso-bidi-font-family: 'Times New Roman'">$lruq</span><span style="font-size: 11pt;
                                                                                                        font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                                                                                        mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="font-size: 10pt">.</span><span
                                                                                                            style="font-size: 11pt; font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                            mso-bidi-font-family: 'Times New Roman'"><span style="font-size: 10pt"> ;jo tu Tmamqj</span>
                                                                                                            <span style="font-size: 10pt">wj,x.= lsrSu i|yd by; i|yka wdh;khg
                                                                                                                 fuhska Ndr fous<span style="font-family: Sandaya; mso-fareast-font-family: 'Times New Roman';
                                                                                                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                                                                                                    mso-bidi-font-family: 'Times New Roman'">$fouq</span><span style="font-family: 'Times New Roman';
                                                                                                                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                                                                        mso-bidi-language: AR-SA; line-height: 15pt;">.</span></span></span></span></span></span></span></span></span></span></span><span
                                                                                                                            style="mso-spacerun: yes"></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></td>
                </tr>
                 
                 <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya">20<span style="font-size: 10pt; font-family: Times New Roman">....................................</span>udifha<span style="font-size: 10pt; font-family: Times New Roman">....................................</span>jeksod<span style="font-size: 10pt; font-family: Times New Roman">....................................</span>ysoSh'</span> </td>
                    <td colspan="1" style="font-size: 10pt; width: 301px; height: 9px; text-align: right">
                         </td>
                    <td colspan="2" style="font-size: 10pt; font-family: 'Trebuchet MS'; height: 9px;
                        text-align: right">
                         
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 6px; text-align: left;" colspan="2">
                        </td>
                    <td style="height: 6px; text-align: left;" colspan="4">
                        &nbsp;&nbsp; .......................................................................</td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 745px; height: 6px; font-size: 9pt; font-family: 'Trebuchet MS';
                        text-align: right;">
                    </td>
                    <td style="height: 6px; text-align: center;" colspan="5">
                        <span style="font-family: Sandaya"><span style="font-size: 10pt">^m%;s,dNshdf.a w;aik&amp;</span></span></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                         <span style="font-family: Sandaya">idC<b style="mso-bidi-font-weight: normal">Is</b>
                            orK n,Odrshdf.a w;aik(</span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: left">
                        <span style="font-family: Sandaya"><span style="font-size: 10pt">^iudodkjsksYaphldr;=udf.a$ufyaia;%d;a;=udf.a$
 osjzreuz flduidrsia;=udf.a w;aik'
&amp;</span></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-size: 10pt; font-family: Sandaya">ku(<span style="font-family: Times New Roman">
                            ........................................................................................................</span></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-size: 10pt; font-family: Sandaya">,smskh( <span style="font-family: Times New Roman">
                            .................................................................................................</span></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Times New Roman">
                            ................................................................................................................</span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Times New Roman">
                            ................................................................................................................</span>
                    </td>
                    <td colspan="4" style="font-size: 10pt; height: 9px; text-align: center; ">
                        <span style="font-family: Times New Roman">
                            .......................................................................</span></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-size: 10pt; font-family: Sandaya">oskh(<span style="font-family: Times New Roman">
                            .....................................................................................................</span></span>
                    </td>
                    <td colspan="4" style="font-size: 10pt; height: 9px; text-align: center; ">
                    <span style="font-size: 10pt; font-family: Sandaya">ks, uqødj</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: justify">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; height: 9px; text-align: justify; width: 105px;">
                    </td>
                    <td colspan="2" style="font-size: 10pt; height: 9px; text-align: right">
                        <span style="font-family: Sandaya"></span>
                    </td>
                    <td colspan="1" style="font-size: 10pt; width: 424px; height: 9px; text-align: right;
                        font-family: 'Trebuchet MS';">
                    </td>
                </tr>
            </table> 
            <p class="break">
            </p>
        </div>
        <%
        
            }

        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
         
 
        %>
    </form>
</body>
</html>
