<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assigneesttmnt001.aspx.cs" Inherits="assigneesttmnt001" %>
<%@ PreviousPageType VirtualPath="~/dthreq002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style type="text/css">
     P.breakhere {page-break-before: always}
    .style1
    {
        width: 20px;
        height: 10px;
    }
    .style2
    {
        width: 577px;
        height: 10px;
    }
    .style3
    {
        width: 20px;
        height: 10px;
    }
</style> 

     <title>SriLanka Insurance - Death Claims</title>
</head>
<body onload="window.print()" style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
      
        <table style="font-size: 9pt; width: 637px; font-family: 'Trebuchet MS'">
            <tr>
                <td style="width: 20px; height:75px; ">
                </td>
                <td style="width: 577px; text-align: right; vertical-align:top; padding-top:10px;">
                <span style="font-size: 12pt; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';  font-weight:bold; border: 1px solid black; padding:4px;
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <span style="font-size: 10pt; font-family: Trebuchet MS;">LI/DC/FO/SE/24 </span> </span>
                </td>
                <td style="width: 20px; height:75px;">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 30px">
                </td>
                <td style="width: 577px; text-align: right;  padding-top:10px; height: 30px">
                    <span style="font-size: 10pt; font-family: Trebuchet MS; border: 1px solid black; padding:4px;">
                        Ref No/L/Claims/<asp:Literal ID="LitClmNo" runat="server"></asp:Literal></span>
                </td>
                <td style="width: 20px; height: 30px">
                </td>
            </tr>
             
            <tr>
                <td style="width: 20px">
                </td>
                <td style="width: 577px">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td style="width: 577px">
                    <span style="text-decoration: underline; font-size: 10pt"><strong>STATEMENT OF
                                THE CLOSEST RELATIVE OF THE DECEASED<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></strong></span><p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                            <b style="mso-bidi-font-weight: normal"><u><span><span style="font-family: Trebuchet MS">
                                <span style="font-size: 10pt">LIFE ASSURED
                                AND THE ASSIGNEE OF THE POLICY/IES<o:p></o:p></span></span></span></u></b></p>
                </td>
                <td style="width: 20px">
                </td>
            </tr> 
            <tr>
                <td style="width: 20px">
                </td>
                <td style="width: 577px; text-align: justify; padding-top:10px; padding-bottom:10px;">
                    (All particulars to be stated below should be written
                            legibly using words/figures /dashes and blanks will
                            not be accepted.)<o:p></o:p></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="width: 577px; height: 9px; text-align: justify">
                    <strong><span style="text-decoration: underline">PART I</span></strong><span> (To be competed by the closest relative and Assignee)<o:p></o:p></span></td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 6px">
                </td>
                <td style="width: 577px; height: 6px; text-align: justify">
                    1.<span style="mso-tab-count: 1"> </span>Full Name
                            of the deceased Life Assured:
                            <span style="border-bottom:2px dotted black; padding-left:15px; padding-right:15px;"><asp:Literal ID="litName" runat="server"></asp:Literal></span><?xml
                                namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></td>
                <td style="width: 20px; height: 6px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 8px">
                </td>
                <td style="width: 577px; height: 8px; text-align: justify">
                    2.<span style="mso-tab-count: 1"> </span>Life insurance Policy
                            No/s&nbsp;<span style="border-bottom:2px dotted black; padding-left:15px; padding-right:15px;"><asp:Literal ID="litpolno" runat="server"></asp:Literal></span><?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                prefix="o" ?><o:p></o:p></td>
                <td style="width: 20px; height: 8px">
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td style="text-align: justify" class="style2">
                    3.<span style="mso-tab-count: 1"> </span><u>Details
                            of the death:<o:p></o:p></u></td>
                <td class="style3">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="width: 577px; height: 9px; text-align: justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;3:1 <b style="mso-bidi-font-weight: normal">
                    <b><u>Date of Death</u><span style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><u>Time of Death</u><span style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <u>Place of Death</u><span style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <u>Age at Death</u> <span style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <u>Cause of Death</u></b></td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 7px">
                </td>
                <td style="width: 577px; height: 7px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.................. 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.................. 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;................... 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;..................
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;........................</td>
                <td style="width: 20px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="width: 577px; height: 9px; text-align: justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;3:2 Name & Address of Hospital/Nursing Home/Dispensary where the deceased was treated.</td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 3px">
                </td>
                <td style="width: 577px; height: 3px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 3px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="width: 577px; height: 9px; text-align: justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;3:3 Date of<span style="mso-spacerun: yes">&nbsp; </span>admission
                            to hospital (if not admitted, state dates of treatment even as an outdoor <br /><span style="margin-left:37px;">patient):</span></td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 6px">
                </td>
                <td style="width: 577px; height: 6px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 6px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="width: 577px; height: 9px; text-align: justify">
                    &nbsp;&nbsp;&nbsp;&nbsp;<span
                            style="font-family: Trebuchet MS"><span style="font-size: 9pt">3:4 Name and Address of the last employer, and the occupation</span></span></td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td style="width: 577px; height: 9px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 6px">
                </td>
                <td style="width: 577px; height: 6px; text-align: justify" class="style2">
                    4.<span style="mso-tab-count: 1"> </span>Has the deceased complained of any illness during the period of 3
                            years prior to the terminal illness? 
                            <br /><span style="margin-left:15px;">If so, furnish the following information:</span></td>
                <td style="width: 20px; height: 6px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;4:1 Names and addresses of the doctors who attended the illness/es:...........................................</td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 8px">
                </td>
                <td style="width: 577px; height: 8px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 8px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 7px">
                </td>
                <td style="width: 577px; height: 7px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 7px">
                </td>
                <td style="width: 577px; height: 7px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;4:2 Nature of the complaint/s:<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><o:p></o:p></td>
                <td style="width: 20px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 7px">
                </td>
                <td style="width: 577px; height: 7px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;4:3 Period/s of treatment:<o:p></o:p></td>
                <td style="width: 20px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 6px">
                </td>
                <td style="width: 577px; height: 6px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.............................................................................................................................</td>
                <td style="width: 20px; height: 6px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 5px">
                </td>
                <td style="width: 577px; height: 5px; text-align: left">
                    5.<span style="mso-tab-count: 1"> </span>Details of other life insurance policies (if any) held by the deceased
                    <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p>&nbsp; &nbsp; &nbsp;</td>
                <td style="width: 20px; height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 7px">
                </td>
                <td style="width: 577px; height: 7px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><span style="text-decoration: underline">Policy No</span></strong>
                    <span><span style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <strong><span style="text-decoration: underline">Name of Insurance/Office</span></strong> 
                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <strong><span style="text-decoration: underline">Sum Assured </span></strong>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b style="mso-bidi-font-weight: normal"><u>Date of Policy<?xml
                                                namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p><span style="mso-tab-count: 2"></span></u></b><span
                                    style="mso-tab-count: 1"></span></span></span></td>
                <td style="width: 20px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 6px;">
                </td>
                <td style="width: 577px; text-align: left; height: 6px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;..................&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    ..........................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...........................</td>
                <td style="width: 20px; height: 6px;">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 6px;">
                </td>
                <td style="width: 577px; text-align: left; height: 6px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;..................&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    ..........................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...........................</td>
                <td style="width: 20px; height: 6px;">
                </td>
            </tr>
          <tr>
                <td style="width: 20px; height: 6px;">
                </td>
                <td style="width: 577px; text-align: left; height: 6px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;..................&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    ..........................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...........................</td>
                <td style="width: 20px; height: 6px;">
                </td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td style="width: 577px; text-align: left">
                </td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td style="width: 577px; text-align: left">
                6.<span style="mso-tab-count: 1"> </span>Particulars of the closest relative who makes this statement:<?xml namespace="" prefix="O" ?><o:p></o:p></td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td style="width: 577px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;6:1 Full Name :...........................................................................................................</td>
                <td style="width: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;6:2 Address :..............................................................................................................</td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;................................................................................................................</td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;................................................................................................................</td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;6:3 Age :...................................................................................................................&nbsp; 
                    <span style="mso-spacerun: yes">
                            </span>
                </td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;6:4 Relationship to the deceased :....................................................................................</td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: left">
                </td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: right">
                    P.T.O 
                </td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 4px">
                </td>
                <td style="width: 577px; height: 4px; text-align: right; font-weight:bold">
                    ----> 
                </td>
                <td style="width: 20px; height: 4px">
                </td>
            </tr>
        </table>
        <br />
    
    </div>
        <p class="breakhere" />
        <br /><br />
        <br /><div style="page-break-after: always">
        <table style="width: 637px">
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: center;"><span style="font-family: Trebuchet MS"><span style="font-size: 10pt">(-2-)</span></span>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: left; width: 577px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">I do herby declare that the answers to the questions appearing
                            over leaf are complete and true
                        in each and every respect.<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 14px">
                </td>
                <td colspan="4" style="height: 14px; text-align: left; width: 577px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <span>Further, I hereby authorize the Insurance Corporation of Sri Lanka to obtain any information or report that
                            may be required from the previous employer/s of the deceased and from any hospital/s and medical
                            attendant/s who have treated the deceased.</span></span></span></p>
                </td>
                <td style="width: 20px; height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 11px">
                </td>
                <td colspan="4" style="height: 11px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 11px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; text-align: left; width: 577px;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">Dated at .............................this..........................day of...............................20..................<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 13px">
                </td>
                <td colspan="4" style="height: 13px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt 340px;text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">......................................................</span></span></span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt; margin-left:340px;"> 
                        Signature or left Thumb impression of the
                            
                        </span></span>
                        </span>
                    </p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt; margin-left:340px;">closest relative
                            of the deceased.<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 13px">
                </td>
                <td colspan="4" style="height: 13px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt 3.5in; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">.......................................................</span></span></span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt; margin-left:350px;">
                        Signature of Assignee and official Seal
                            <o:p></o:p>
                        </span></span>
                        </span>
                    </p>
                    
                </td>
                <td style="width: 20px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <b style="mso-bidi-font-weight: normal"><u><span>To be completed
                            by witnesses</span></u></b><b style="mso-bidi-font-weight: normal"><span>:<o:p></o:p></span></b></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 9pt; font-family: Trebuchet MS">
                        Declared before me after the contents were duly read over and explained by me</span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        Signature<span style="margin-left:25px; "></span>:<span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        Name<span style="margin-left:46px; "></span>:<span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
             <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        Designation<span style="margin-left:14px; "></span>:<span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
             <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        Address<span style="margin-left:35px; "></span>:<span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr> 
           <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <span style="margin-left:82px; "></span><span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr> 
           <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <span style="margin-left:82px; "></span><span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr> 
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        Official Seal<span style="margin-left:12px; "></span>:<span style="margin-left:5px;">.........................................................</span></span></span></span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr> 
             
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <b style="mso-bidi-font-weight: normal"><u><span><span style="font-family: Trebuchet MS">
                            <span style="font-size: 10pt">Note:<o:p></o:p></span></span></span></u></b></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 13px">
                </td>
                <td colspan="4" style="height: 13px; width: 577px; text-align: left;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt 1in; text-indent: -0.5in; text-align: left;
                        mso-list: l0 level1 lfo1; tab-stops: list 1.0in">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <span><span style="mso-list: Ignore">a)<span style="font-weight: normal; line-height: normal; font-style: normal; font-variant: normal;">
                            &nbsp;</span></span></span>
                        <span>
                        This statement must be witnessed by responsible person<o:p></o:p></span></span></span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt 1in; text-indent: -0.5in; text-align: left;
                        mso-list: l0 level1 lfo1; tab-stops: list 1.0in">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <span><span style="mso-list: Ignore">b)<span style="font-weight: normal; line-height: normal; font-style: normal; font-variant: normal;">
                            &nbsp;</span></span></span>
                        <span>If thumb impression is placed, It should be certified by a J.P. or Attorney-at-Law.<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 11px">
                </td>
                <td colspan="4" style="height: 11px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-size: 11pt">---------------------------------------------------------------------------------------------------------------------</span></p>
                </td>
                <td style="width: 20px; height: 11px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span style="font-family: Trebuchet MS"><span style="font-size: 9pt">
                        <b style="mso-bidi-font-weight: normal"><u><span>PART II</span></u></b><span> (To be completed by the assignee of the policy/ies)<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 8px">
                </td>
                <td colspan="4" style="height: 8px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 8px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 12px">
                </td>
                <td colspan="4" style="height: 12px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS; font-size: 9pt"> 
                        I/We ............................................................................................................................</span></span><span></p>
                </td>
                <td style="width: 20px; height: 12px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: center;">
                <span style="font-size: 9pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        (Name of Assignee)</span></td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 13px">
                </td>
                <td colspan="4" style="height: 13px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">...................................................................................................................................</span></span></span></p>
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">do hereby claim policy monies as Assignee under the policy/ies
                            referred to above.<o:p></o:p></span></span></span></p>
                </td>
                <td style="width: 20px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify">
                        <span><span style="font-family: Trebuchet MS"><span style="font-size: 9pt">Date:.........................................</span></span></span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                        <span style="font-size: 11pt"><span style="mso-tab-count: 8">  &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span><span style="font-size: 9pt;
                                font-family: Trebuchet MS">.........................................................</span></span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: right;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">                          
                            <span style="font-family: Trebuchet MS"><span style="font-size: 9pt; margin-right:45px;">Signature of Assignee<o:p></o:p></span></span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 15px">
                </td>
                <td colspan="4" style="height: 15px; width: 577px; text-align: left;">
                </td>
                <td style="width: 20px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 9px">
                </td>
                <td colspan="4" style="height: 9px; width: 577px; text-align: right;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                        
                            <span style="font-size: 10pt; font-family: Trebuchet MS">Address: ....................................................</span></p>
                </td>
                <td style="width: 20px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: right;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                          <span style="font-size: 10pt; font-family: Trebuchet MS">....................................................</span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: right;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                          <span style="font-size: 10pt; font-family: Trebuchet MS">....................................................</span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 10px">
                </td>
                <td colspan="4" style="height: 10px; width: 577px; text-align: right;">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right">
                          <span style="font-size: 10pt; font-family: Trebuchet MS">....................................................</span></p>
                </td>
                <td style="width: 20px; height: 10px">
                </td>
            </tr>
             
        </table>
        </div>
    </form>
</body>
</html>
