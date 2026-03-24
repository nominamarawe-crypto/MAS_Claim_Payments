<%@ Page Language="C#" AutoEventWireup="true" CodeFile="medCert.aspx.cs" Inherits="medCert" %>
<%@ PreviousPageType VirtualPath="~/dthreq002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style type="text/css">
     P.breakhere {page-break-before: always}
    .style1
    {
        width: 19px;
        height: 20px;
    }
    .style2
    {
        height: 20px;
    }
    .style3
    {
        width: 22px;
        height: 20px;
    }
    .style4
    {
        width: 19px;
        height: 9px;
    }
    .style5
    {
        height: 9px;
    }
    .style6
    {
        width: 22px;
        height: 9px;
    }
    </style> 
    <title>SriLanka Insurance - Death Claims</title>
</head>

<body onload="window.print()" style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 637px; font-size: 10pt; font-family: 'Trebuchet MS';">
            <tr>
                <td style="width: 19px; height: 30px">
                </td>
                <td style="height: 30px; text-align:right; vertical-align:top;" colspan="4">
                    <span style="font-size: 10pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        
                            <span style="font-size: 9pt; font-family: 'Trebuchet MS'; font-weight:bold;">LI/DC/FO/E/04 
                                 </span>
                    </span>
                </td>
                <td style="width: 22px; height: 30px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 30px">
                </td>
                <td style="height: 30px; text-align:right; padding-top:10px;" colspan="4">
                    <span style="font-size: 9pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        
                            <span style="font-size: 9pt; font-family: 'Trebuchet MS'; border: 1px solid black; padding:4px;">Our Ref : Life/Claims/ 
                                <asp:Literal ID="litclmno" runat="server"></asp:Literal></span>
                    </span></td>
                <td style="width: 22px; height: 30px">
                </td>
            </tr>
             
            <tr>
                <td colspan="6" style="height: 9px">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <b style="mso-bidi-font-weight: normal"><span style="font-size: 9pt; font-family: 'Times New Roman';
                            mso-hansi-font-family: Tunga">CERTIFICATE OF HOSPTIAL TREATMENT/LAST MEDICAL ATTENDANT'S
                            CERTIFICATE<?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></b></p>
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: justify">
                    <span style="font-size: 8pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        In connection with the claim under policy No. 
                        <span style="border-bottom:2px dotted; padding-left:15px; padding-right:15px;">
                        <asp:Literal ID="litpolno" runat="server"></asp:Literal>
                        </span>
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span style="font-size: 10pt; font-family: Trebuchet MS">
                            &nbsp;on the life of&nbsp; </span>
                            <span style="border-bottom:2px dotted; padding-left:30px; padding-right:30px;">
                            <asp:Literal ID="litname" runat="server"></asp:Literal></span></span></span></td>
                <td style="width: 22px; height: 9px; font-size: 12pt;">
                </td>
            </tr>
           
            <tr style="font-size: 8pt; font-family: 'Times New Roman'">
             <td style="width: 19px; height: 9px">
                </td>
                <td style="height: 9px; border-bottom: 1px black solid; margin-bottom: 1px;" 
                    colspan="4">(INSERT FULL NAME OF THE DECEASED)
                </td>
                 <td style="width: 19px; height: 9px">
                </td>
            </tr>
            <tr style="font-weight: bold; text-decoration: underline; font-size: 9pt;">
                <td style="height: 9px" colspan="6">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <u><span><span style="font-family: 'Times New Roman'">CERTICICATE OF HOSPITAL TREATMENT<?xml namespace=""
                            ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></u></p>
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 12pt;">
                <td style="width: 19px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
                <td colspan="5" 
                    style="height: 9px; font-weight: normal; text-decoration: none;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left">
                        <span style="font-size: 8pt; font-family: 'Trebuchet MS';">1.<span style="mso-spacerun: yes"> </span>In the hospital
                            records, what details are given in respect of the following:<o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="font-weight: bold; font-size: 8pt;">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width:600px;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(a)<span style="mso-tab-count: 1">&nbsp;</span>Name
                            of Patient :........................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(b)<span style="mso-tab-count: 1">&nbsp;</span>Age :........................................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(c)<span style="mso-tab-count: 1">&nbsp;</span>Reg.
                            No :...................................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(d)<span style="mso-tab-count: 1">&nbsp;</span>Address :..................................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
             
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(e)<span style="mso-tab-count: 1">&nbsp;</span>Date
                            and Time of Admission :..........................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(f)<span style="mso-tab-count: 1">&nbsp;</span>Ward
                            No :..................................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(g)<span style="mso-tab-count: 1">&nbsp;</span>Occupation :..............................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(h)<span style="mso-tab-count: 1">&nbsp;</span>Name
                            of physician / Surgeon :.........................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(i)<span style="mso-tab-count: 1">&nbsp;</span>Source
                            of Admission :....................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(j)<span style="mso-tab-count: 1">&nbsp;</span>What
                            is the diagnosis arrived in the hospital? :....................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(k)<span style="mso-tab-count: 1">&nbsp;</span>What
                            is the date of discharge and state of health at the</span><span>
                             </span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    &nbsp; &nbsp; &nbsp;time of discharge? (if discharged prior to death) :................................................................................<?xml namespace="" prefix="O" ?><o:p></o:p></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(l)<span style="mso-tab-count: 1">&nbsp;</span> 
                            Date of Death :...........................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(m)<span style="mso-tab-count: 1"></span> 
                            Time of Death :..........................................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(n)<span style="mso-tab-count: 1">&nbsp;</span>What
                            is the nature of the complaint and duration? :..............................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>(o)<span style="mso-tab-count: 1">&nbsp;</span>What
                            is the mode of onset? :..........................................................................................................<o:p></o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr  style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:400px; text-align:justify;" 
                    rowspan="4">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                         (p) Was there any other disease or illness 
                         which preceded or co-existed with the
                         ailment mentioned above at the time of his/her 
                         admission to the hospital? if so, what 
                         was it? Please give history of disease or illness stating</p>
                </td>
                <td style="font-weight: normal; text-align: left; text-decoration: none; width:10px; text-align:center; vertical-align:top; font-size:40px; font-family:'Gulim'" 
                    rowspan="5">
                    }</td>
                <td style="font-weight: normal; text-align: left; text-decoration: none; width:275px;" 
                    rowspan="4">
                    .............................................................</td>
                <td style="height: 15px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr>
                <td style="height: 2px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 2px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 2px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
             
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp; &nbsp;<span style="font-size: 9pt"> (a)<span style="mso-tab-count: 1">
                            &nbsp;</span>Date when such was observed by the patient ........................................................................<o:p></span></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp; &nbsp; <span style="font-size: 9pt">(b)<span style="mso-tab-count: 1">
                            &nbsp;</span>By whom he/she was treated ..............................................................................................<o:p></span></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; font-size: 10pt;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp; &nbsp; &nbsp;<span style="font-size: 8pt; font-family: Trebuchet MS"> (c)<span style="mso-tab-count: 1">
                        &nbsp; </span>By whom the
                        history has been reported ......................................................................................</span></span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; font-size: 10pt;">
                </td>
            </tr>
           
            <tr style="font-size: 8pt">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>Certified that the information given above is correct
                            as per records in Hospital.<o:p></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr> 
            <tr style="font-size: 8pt">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px">
                        <span>Signature ....................................................<?xml
                            namespace="" prefix="O" ?><o:p></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px">
                        <span>Name 
                    .........................................................<?xml
                            namespace="" prefix="O" ?><o:p></span></p>
                    </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                     <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px;">
                        <span>Qualifications Designations ..............................<?xml
                            namespace="" prefix="O" ?><o:p></span></p>
                     </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
                <td colspan="4" >
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px;">
                        <span>.................................................................<?xml
                            namespace="" prefix="O" ?><o:p></span></p></td>
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
                <td colspan="4" 
                    
                    style="height: 9px; font-weight: normal; text-decoration: none; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px;">
                        <span>Name of hospital ............................................<?xml
                            namespace="" prefix="O" ?><o:p></span></p>
                     </td>
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
                <td colspan="4" 
                    
                    style="height: 9px; font-weight: normal; text-decoration: none; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px;">
                        <span>Postal Address...............................................<?xml
                            namespace="" prefix="O" ?><o:p></span></p>
                     </td>
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
                <td colspan="4" 
                    style="height: 9px; font-weight: normal; text-decoration: none;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: left; margin-left:330px;">
                        <span>.................................................................<?xml
                            namespace="" prefix="O" ?><o:p></span></p>
                     
                </td>
                <td style="width: 22px; height: 9px; font-weight: normal; text-decoration: none;">
                </td>
            </tr>
            <tr style="font-size: 8pt">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left; border-bottom: 1px black solid;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span>Date...................................<o:p></o:p></span></p>
                </td>
                <td style="font-size: 11pt; width: 22px; height: 9px">
                </td>
            </tr> 
            <tr style="font-weight: bold; font-size: 8pt;">
                <td style="height: 9px" colspan="6">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <span><span style="font-family: 'Times New Roman'">(LAST MEDICAL ATTENDANT’S CERTIFICATE)<?xml namespace=""
                            ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></p>
                </td>
            </tr> 
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; tab-stops: right 459.0pt">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">Information to be supplied by the medical attendant of
                            the deceased in his/her last illness<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                prefix="o" ?><o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: justify">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Trebuchet MS; font-size: 8pt; text-align: justify"> 1.&nbsp; A.&nbsp;&nbsp;What is the exact cause
                            of death of the person mentioned above. (Besides defining the </span></p>
                </td>
                <td style="width: 22px; height: 9px; font-family: Times New Roman;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;disease or other cause of death in such terms as you consider appropriate, Kindly add the</span>
                    </p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td colspan="4" style="text-align: left" class="style2">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: Trebuchet MS"> 
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            distinctive technical name)</span></p>
                </td>
                <td style="font-family: Times New Roman;" class="style3">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp;<span style="font-family: Trebuchet MS">
                            <span style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)<span style="mso-tab-count: 1">
                            &nbsp;</span>Primary cause....................................................................................................................<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp;&nbsp;<span style="font-family: Trebuchet MS"><span
                            style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)<span style="mso-tab-count: 1">
                            &nbsp;</span>Secondary cause.................................................................................................................<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp;&nbsp;<span style="font-size: 8pt;
                            font-family: Trebuchet MS">B.<span style="mso-tab-count: 1">
                            &nbsp; </span>Was it ascertained by examination after death or inferred</span></span> </p>
                </td>
                <td style="width: 22px; height: 9px; font-family: Times New Roman;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt">
                            <span style="font-family: Trebuchet MS">from symptoms and appearance during life? ...................................................................................<?xml
                        namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp;&nbsp;<span style="font-size: 8pt;
                            font-family: Trebuchet MS">C.<span style="mso-tab-count: 1">
                            &nbsp; </span>How long had he/she been suffering from this disease before</span></span> </p>
                </td>
                <td style="width: 22px; height: 9px; font-family: Times New Roman;">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt">
                            <span style="font-family: Trebuchet MS">his/her death? ......................................................................................................................<?xml
                        namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp;&nbsp;<span style="font-size: 8pt;
                            font-family: Trebuchet MS">D.<span style="mso-tab-count: 1">
                            &nbsp; </span>What were the symptoms of the illness? ........................................................................................</span></span> </p>
                </td>
                <td style="width: 22px; height: 9px; font-family: Times New Roman;">
                </td>
            </tr> 
        </table>
    
    </div>
        <br /><p class="breakhere" />
        <br />
        <table style="width: 637px">
             
            <tr style="font-family: Times New Roman">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp; &nbsp; <span style="font-size: 8pt;
                            font-family: Trebuchet MS">E.<span style="mso-tab-count: 1">
                            &nbsp; </span>When were they first observed by the deceased? ..........................................................................</span></span> </p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt">
                            <span style="font-family: Trebuchet MS">(as reported by the deceased).<?xml
                        namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 9pt">&nbsp; &nbsp; &nbsp; <span style="font-size: 8pt;
                            font-family: Trebuchet MS">F.<span style="mso-tab-count: 1">
                            &nbsp; </span>What was the date on which you were first consulted during</span></span> </p>
                </td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td class="style4">
                </td>
                <td colspan="4" style="text-align: left" class="style5">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt">
                            <span style="font-family: Trebuchet MS">the illness? ..........................................................................................................................<?xml
                        namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></span></span></p>
                </td>
                <td class="style6">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="2" style="height: 9px; text-align: left; width:350px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp; &nbsp; &nbsp; <span style="font-size: 8pt;
                            font-family: Trebuchet MS">G.<span style="mso-tab-count: 1">
                            &nbsp; </span>Did you attend on him during the whole of its course?</span></span></p>
                </td>
                <td style="width:10px; text-align: left; text-align:center; vertical-align:top; font-size:30px; font-family:'Gulim'"" rowspan="2">
                    }</td>
                <td style="height: 9px; width:150px; text-align: left">
                    &nbsp;</td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 19px; height: 9px">
                </td>
                <td colspan="2" style="height: 9px; text-align: left; width:350px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt">
                            <span style="font-family: Trebuchet MS">if not state during what period. </span></span></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                </td>
                <td style="height: 9px; text-align: left; width:150px; vertical-align:top;">
                    <span style="font-family: Trebuchet MS; font-size: 8pt;">..........................................................</span></td>
                <td style="width: 22px; height: 9px">
                </td>
            </tr>
             
            <tr style="font-weight: bold; text-decoration: underline; font-family: Times New Roman;">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                 <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <table>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                        <span>2. <span style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            Do you have any reason to suppose or to suspect that the death </span> </span></span> 
                    </p></td>
                            <td style="width:10px;  vertical-align:middle; font-size:40px; font-family:'Gulim'""" rowspan="4">}</td>
                            <td style="width:175px vertical-align:middle; font-family: Trebuchet MS; font-size: 8pt;" rowspan="4">............................................</td>
                        </tr>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 8pt"><span>&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>disease was caused or aggravated by intemperate of the deceased? </span> </span>
                        </span></span>
                    </p></td>
                        </tr>
                        <tr>
                            <td style="width:375px;"><span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                            Did any other disease or illness precede or coexist with that  </span></span></span></td>
                        </tr>
                        <tr>
                            <td style="width:375px;"> <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS"><span style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span><span style="font-family: Trebuchet MS"><span
                                style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                mso-bidi-language: AR-SA">which immediately caused his/her death? </span></span></span></span></span></span></span></span></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
                
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt; font-family: Trebuchet MS">if so, please give details.</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt; font-family: Trebuchet MS;
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">Date of such observation? 
                    .......................................................................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt; font-family: Trebuchet MS;
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">By whom treated? 
                    .................................................................................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 8pt; font-family: Trebuchet MS;
                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                        mso-bidi-language: AR-SA">By whom, history was reported to you? 
                    ......................................................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr> 
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="3">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                        <span>3.<span style="mso-tab-count: 1">&nbsp;</span>(a)<span
                            style="mso-tab-count: 1"> &nbsp;</span>Was the deceased treated during his/her last
                            illness by any other</span> </span></span></p>
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <table>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                         <span style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            medical practitioner or in any hospital before you were</span></span> 
                    </p></td>
                            <td style="width:10px;  vertical-align:middle; font-size:40px; font-family:'Gulim'""" rowspan="2">}</td>
                            <td style="width:175px; vertical-align:top; font-family: Trebuchet MS; font-size: 8pt;" rowspan="2">............................................<br /><br />............................................</td>
                        </tr>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 8pt"><span>&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>consulted? if so, please give their names and addresses. </span> </span>
                        </span></span>
                    </p></td>
                        </tr>
                        
                        
                    </table>
                    </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>
             
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <table>
                        <tr>
                            <td style="width:450px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;<span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                            (b)<span style="mso-tab-count: 1"> &nbsp;</span>Did any other medical practitioner attend on him/her in consultation  </span></span></span>
                    </p></td>
                            <td style="width:10px;  vertical-align:middle; font-size:40px; font-family:'Gulim'""" rowspan="2">}</td>
                            <td style="width:150px; vertical-align:middle; font-family: Trebuchet MS; font-size: 8pt;" rowspan="2">......................................</td>
                        </tr>
                        <tr>
                            <td style="width:450px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS">
                            <span style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span>with yourself? if so, please state their names and addresses.</span></span></span></span></span>
                    </p></td>
                        </tr>
                        
                        
                    </table>
                    </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>  
              
             <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <table>
                        <tr>
                            <td style="width:400px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;<span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                            (c)<span style="mso-tab-count: 1"> &nbsp;</span>Were you the
                        deceased’s usual medical attendant? If so, for</span></span></span>
                    </p></td>
                            <td style="width:10px;  vertical-align:middle; font-size:40px; font-family:'Gulim'""" rowspan="3">}</td>
                            <td style="width:150px; vertical-align:middle; font-family: Trebuchet MS; font-size: 8pt;" rowspan="3">..............................................</td>
                        </tr>
                        <tr>
                            <td style="width:400px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS">
                            <span style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span>how long and for what ailment did you treat the deceased</span></span></span></span></span>
                    </p></td>
                        </tr>
                        <tr>
                            <td style="width:400px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS">
                            <span style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span>during the 3 years preceding his/her last illness?</span></span></span></span></span>
                    </p></td>
                        </tr>
                        
                    </table>
                    </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>  
             <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <table>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;<span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                            (d)<span style="mso-tab-count: 1"> &nbsp;</span>Do you have any other information/remarks to make in</span></span></span>
                    </p></td>
                            <td style="width:10px;  vertical-align:middle; font-size:40px; font-family:'Gulim'""" rowspan="3">}</td>
                            <td style="width:175px; vertical-align:middle; font-family: Trebuchet MS; font-size: 8pt;" rowspan="3">......................................................</td>
                        </tr>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS">
                            <span style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span>connection with this claim concerning the deceased’s</span></span></span></span></span>
                    </p></td>
                        </tr>
                        <tr>
                            <td style="width:375px;"><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <span style="font-size: 8pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Trebuchet MS">
                            <span style="font-size: 8pt"><span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            <span>ailment, habits,, mode of living etc?</span></span></span></span></span>
                    </p></td>
                        </tr>
                        
                    </table>
                    </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;">
                </td>
            </tr>  
               
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 19px;">
                </td>
                 <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">&nbsp;I...................................................................................................................................being
                            the<?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                 <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">(PLEASE
                            GIVE THE FULL NAME)<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                 <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify;">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">Medical Attendant of the deceased the Medical Practitioner
                            acting for the Medical Attendant of the deceased<span>.....................................................................................................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                 <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">(PLEASE GIVE THE FULL NAME)<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9x">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify;">
                        <span style="font-family: 'Trebuchet MS';"><span style="font-size: 8pt">I do here by solemnly declare that the foregoing statements
                            are true and correct to the best of&nbsp; <span style="font-family: Trebuchet MS">my knowledge and belief and that the deceased did not
                        die by his/her own act.<o:p></o:p>&nbsp;</span></span></span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span><span><span style="font-size: 8pt; font-family: Trebuchet MS">
                            Dated at.............................this.................................day
                            of.......................................20.................&nbsp;</span></span></span></span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span><span><span style="font-size: 8pt; font-family: Trebuchet MS"></span></span>
                        </span></span><span><span><span><span><span style="font-family: Trebuchet MS"><span
                            style="font-size: 8pt">Code No.....................................................................(State
                            here the Code Number if, you are an Authorized Medical Examiner of the Company)<o:p></o:p></span></span></span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px; font-family: Times New Roman;">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
               <td style="height: 9px; width:300px; font-weight: normal; text-align: left; text-decoration: none;">
                    <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">
                        WITNESS TO SIGNATURE AND 
                        IDENITY
                        OF <span style="mso-fareast-font-family: 'Times New Roman';
                            mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                            MEDICAL ATTENDANT</span></span></span></span></td>
               <td style="height: 9px; font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:250px;" 
                    colspan="3">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">SIGNATURE OF MEDICAL ATTENDANT</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                <td style="height: 9px; width:300px; font-weight: normal; text-align: left; text-decoration: none;">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">Signature ....................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:275px;" 
                    colspan="3">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">Signature ........................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                <td style="height: 9px; width:300px; font-weight: normal; text-align: left; text-decoration: none;">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">Occupation ..................................................</span></td>
                    <td style="height: 9px; font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:275px;" 
                    colspan="3">
                        <span style="font-size: 8pt; font-family: Trebuchet MS;">Qualifications & Designation ................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                 <td style="height: 9px; width:300px; font-weight: normal; text-align: left; text-decoration: none;">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">Postal Address ..............................................</span></td>
                    <td style="height: 9px; font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:275px;" 
                    colspan="3">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">Postal Address ..................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                 <td style="height: 9px; width:300px; font-weight: normal; text-align: left; text-decoration: none;">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">.................................................................</span></td>
                    <td style="height: 9px; font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:275px;" 
                    colspan="3"><span style="font-size: 8pt; font-family: Trebuchet MS;">.....................................................................</span>
                    </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                 <td style="height: 9px; width:300px; font-weight: normal; text-align: left; text-decoration: none;">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">.................................................................</span></td>
                    <td style="height: 9px; font-weight: normal; text-align: left; vertical-align:top; text-decoration: none; width:275px;" 
                    colspan="3">
                    <span style="font-size: 8pt; font-family: Trebuchet MS;">.....................................................................</span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none;" 
                    colspan="4">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: center; text-decoration: none;" 
                    colspan="4">
                    <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">21, Vauxhall Street, Colombo 02, Sri Lanka</span></span></span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>
            <tr>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
                <td style="height: 9px; font-weight: normal; text-align: center; text-decoration: none;" 
                    colspan="4">
                    <span><span style="font-family: Trebuchet MS"><span style="font-size: 8pt">Tele. 2357247 2357253 Fax. 2357236 web. www.srilankainsurance.com</span></span></span></td>
                <td style="height: 9px; font-weight: normal; text-align: left; text-decoration: none; width: 20px;">
                </td>
            </tr>   
        </table>
          
    </form>
</body>
</html>
