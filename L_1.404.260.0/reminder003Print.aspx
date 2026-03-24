<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reminder003Print.aspx.cs" Inherits="reminder003" %>
<%@ Reference Page="~/EPage.aspx" %>
<%@ PreviousPageType VirtualPath="~/reminder003.aspx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style type="text/css">
     P.breakhere {page-break-before: always}
</style> 

    <title>SriLanka Insurance - Death Claims</title>
</head>
<body onload="window.print()" style="text-align: left">
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
        <% 
            int index = 0;
            bool brcopy = false;
            bool agcopy = false;
            bool Rgcod = false;
            bool Rgsm = false;
            
            foreach (ArrayList AddCopy in CopyToArray)
            {
                index++;
                if (Rem_no == 1)
                {
                    litceo.Visible = false;
                    lblsubsequentrem.Visible = false;
                    litsubseqdt1.Visible = false;
                    litsubseqdt2.Visible = false;
                    lblforthirdreminders.Visible = false;
                    lblforlastreminder.Visible = false;
                    lblforlastreminder2.Visible = false;
                    lblcopyto.Visible = false;
                    litceo.Visible = false;
                    lbllast.Visible = false;
                }
                else
                {
                    litceo.Visible = true;
                    lblsubsequentrem.Visible = true;
                    litsubseqdt1.Visible = true;
                    litsubseqdt2.Visible = true;
                    lblforthirdreminders.Visible = true;
                    lblforlastreminder.Visible = true;
                    lblforlastreminder2.Visible = true;
                    lblcopyto.Visible = true;
                    if ((litceo.Text != null) && (!litceo.Text.Equals(""))) { lblcopyto.Visible = true; }
                    else { lblcopyto.Visible = false; }
                    litceo.Visible = true;
                    lbllast.Visible = true;
                }                
                if (sentDate > 0 && remindersentdate == 0 && secondremsentdt == 0)
                {                    
                    lblsubsequentrem.Text = "";
                    litsubseqdt1.Text = "";
                    litsubseqdt2.Text = "";
                    lblforthirdreminders.Text = "";
                    lblforlastreminder.Text = "";
                    lblforlastreminder2.Text = "";
                    litceo.Text = "";
                }
                else if (remindersentdate > 0 && secondremsentdt == 0)
                {                   
                    litsubseqdt2.Text = "";
                    lblforthirdreminders.Text = "";
                    lblforlastreminder.Text = "";
                    lblforlastreminder2.Text = "";
                    litceo.Text = "";
                }
                if (index == 1)
                { 
                    litceo.Visible=false;//hide ceo address
                    litto.Visible = false;
                    lblcopyto.Visible = false;
                    
                    #region Hide Br Admin Officers address
                    litbrname.Visible=false;litbrad1.Visible=false;
                    litbrad2.Visible=false;litbrad3.Visible=false;
                    litbrad4.Visible=false;
                    #endregion
                    #region Hide Agent address
                    litag1.Visible=false;litagad1.Visible=false;
                    litagad2.Visible=false;litagad3.Visible=false;
                    litagad4.Visible=false;litagad5.Visible=false;
                    #endregion
                    #region Hide Regional Coordinators Address
                    litrgcdname.Visible=false;litrgcdname.Visible=false;
                    litrgcdad1.Visible=false;litrgcdad2.Visible=false;
                    litrgcdad3.Visible=false;litrgcdad4.Visible=false;
                    #endregion
                    #region Hide Regional Sales Managers Address
                    litrgsmname.Visible=false;litrgsmad1.Visible=false;
                    litrgsmad2.Visible=false;litrgsmad3.Visible=false;
                    litrgsmad4.Visible = false;
                    #endregion
                    #region Hide Postal Address
                    litpostname.Visible=false;litpostad1.Visible=false;
                    litpostad2.Visible=false;litpostad3.Visible=false;
                    litpostad4.Visible = false; litpostad5.Visible = false;
                    #endregion

                }
                if (index == 2)
                {
                    lblcopyto.Visible = true;
                    litto.Visible = true;
                    if (CopyToArray.Count > 1)
                    {
                        if (AddCopy[AddCopy.Count - 1].ToString() == "BR ADMIN")
                        {
                            brcopy = true;
                            litbrname.Text=AddCopy[0].ToString();
                            litbrad1.Text=AddCopy[1].ToString();
                            litbrad2.Text=AddCopy[2].ToString();
                            litbrad3.Text=AddCopy[3].ToString();
                            litbrad4.Text = AddCopy[4].ToString();                            
                            
                            #region Show Br Admin Officers address
                            litbrname.Visible = true; litbrad1.Visible = true;
                            litbrad2.Visible = true; litbrad3.Visible = true;
                            litbrad4.Visible = true;
                            #endregion
                        }
                        else if (AddCopy[AddCopy.Count - 1].ToString() == "AG COPY" || AddCopy[AddCopy.Count - 1].ToString() == "SM COPY")
                        {
                            agcopy = true;
                            litag1.Text=AddCopy[0].ToString();
                            litagad1.Text=AddCopy[1].ToString();
                            litagad2.Text=AddCopy[2].ToString();
                            litagad3.Text=AddCopy[3].ToString();
                            litagad4.Text = AddCopy[4].ToString();
                            litagad5.Text = AddCopy[5].ToString();

                            #region Show Agent address
                            litag1.Visible = true; litagad1.Visible = true;
                            litagad2.Visible = true; litagad3.Visible = true;
                            litagad4.Visible = true; litagad5.Visible = true;
                            #endregion
                        }
                        else if (AddCopy[AddCopy.Count - 1].ToString() == "RG COD")
                        {
                            Rgcod = true;
                            litrgcdname.Text = AddCopy[0].ToString();
                            litrgcdad1.Text = AddCopy[1].ToString();
                            litrgcdad2.Text = AddCopy[2].ToString();
                            litrgcdad3.Text = AddCopy[3].ToString();
                            litrgcdad4.Text = AddCopy[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgcdname.Visible = true; 
                            litrgcdad1.Visible = true; litrgcdad2.Visible = true;
                            litrgcdad3.Visible = true; litrgcdad4.Visible = true;
                            #endregion
                        }
                        else
                        {
                            Rgsm = true;
                            litrgsmname.Text = AddCopy[0].ToString();
                            litrgsmad1.Text = AddCopy[1].ToString();
                            litrgsmad2.Text = AddCopy[2].ToString();
                            litrgsmad3.Text = AddCopy[3].ToString();
                            litrgsmad4.Text = AddCopy[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgsmname.Visible = true; litrgsmad1.Visible = true;
                            litrgsmad2.Visible = true; litrgsmad3.Visible = true;
                            litrgsmad4.Visible = true; 
                            #endregion
                        }
                        if (CopyToArray.Count > 2)
                        {
                            ArrayList add2 = (ArrayList)CopyToArray[2];
                            if (add2[add2.Count - 1].ToString() == "AG COPY" || add2[add2.Count - 1].ToString() == "SM COPY")
                            {
                                agcopy = true;
                            }
                            litag1.Text = add2[0].ToString();
                            litagad1.Text = add2[1].ToString();
                            litagad2.Text = add2[2].ToString();
                            litagad3.Text = add2[3].ToString();
                            litagad4.Text = add2[4].ToString();
                            litagad5.Text = add2[5].ToString();

                            #region Show Agent address
                            litag1.Visible = true; litagad1.Visible = true;
                            litagad2.Visible = true; litagad3.Visible = true;
                            litagad4.Visible = true; litagad5.Visible = true;
                            #endregion
                        }
                        if (CopyToArray.Count > 3)
                        {
                            ArrayList add3 = (ArrayList)CopyToArray[3];
                            if (add3[add3.Count - 1].ToString() == "RG COD")
                            {
                                Rgcod = true;
                            }
                            litrgcdname.Text = add3[0].ToString();
                            litrgcdad1.Text = add3[1].ToString();
                            litrgcdad2.Text = add3[2].ToString();
                            litrgcdad3.Text = add3[3].ToString();
                            litrgcdad4.Text = add3[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgcdname.Visible = true;
                            litrgcdad1.Visible = true; litrgcdad2.Visible = true;
                            litrgcdad3.Visible = true; litrgcdad4.Visible = true;
                            #endregion
                        }
                        if (CopyToArray.Count > 4)
                        {
                            ArrayList add4 = (ArrayList)CopyToArray[4];
                            if (add4[add4.Count - 1].ToString() == "RG SM")
                            {
                                Rgsm = true;
                            }
                            
                            litrgsmname.Text = add4[0].ToString();
                            litrgsmad1.Text = add4[1].ToString();
                            litrgsmad2.Text = add4[2].ToString();
                            litrgsmad3.Text = add4[3].ToString();
                            litrgsmad4.Text = add4[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgsmname.Visible = true; litrgsmad1.Visible = true;
                            litrgsmad2.Visible = true; litrgsmad3.Visible = true;
                            litrgsmad4.Visible = true;
                            #endregion
                        }
                    
                    }
                    litpostname.Text=AddCopy[0].ToString();
                    litpostad1.Text=AddCopy[1].ToString();
                    litpostad2.Text=AddCopy[2].ToString();
                    litpostad3.Text=AddCopy[3].ToString();
                    litpostad4.Text=AddCopy[4].ToString();
                    litpostad5.Text = AddCopy[5].ToString();

                    #region Show Postal Address
                    litpostname.Visible = true; litpostad1.Visible = true;
                    litpostad2.Visible = true; litpostad3.Visible = true;
                    litpostad4.Visible = true; litpostad5.Visible = true;
                    #endregion
                    
                    
                }
                if (index == 3)
                {
                    lblcopyto.Visible = true;
                    if (CopyToArray.Count > 2)
                    {                      
                       if (AddCopy[AddCopy.Count - 1].ToString() == "AG COPY" || AddCopy[AddCopy.Count - 1].ToString() == "SM COPY")
                        {
                            agcopy = true;
                            litag1.Text = AddCopy[0].ToString();
                            litagad1.Text = AddCopy[1].ToString();
                            litagad2.Text = AddCopy[2].ToString();
                            litagad3.Text = AddCopy[3].ToString();
                            litagad4.Text = AddCopy[4].ToString();
                            litagad5.Text = AddCopy[5].ToString();

                            #region Show Agent address
                            litag1.Visible = true; litagad1.Visible = true;
                            litagad2.Visible = true; litagad3.Visible = true;
                            litagad4.Visible = true; litagad5.Visible = true;
                            #endregion
                        }
                        else if (AddCopy[AddCopy.Count - 1].ToString() == "RG COD")
                        {
                            Rgcod = true;
                            litrgcdname.Text = AddCopy[0].ToString();
                            litrgcdad1.Text = AddCopy[1].ToString();
                            litrgcdad2.Text = AddCopy[2].ToString();
                            litrgcdad3.Text = AddCopy[3].ToString();
                            litrgcdad4.Text = AddCopy[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgcdname.Visible = true;
                            litrgcdad1.Visible = true; litrgcdad2.Visible = true;
                            litrgcdad3.Visible = true; litrgcdad4.Visible = true;
                            #endregion
                        }
                        else
                        {
                            Rgsm = true;
                            litrgsmname.Text = AddCopy[0].ToString();
                            litrgsmad1.Text = AddCopy[1].ToString();
                            litrgsmad2.Text = AddCopy[2].ToString();
                            litrgsmad3.Text = AddCopy[3].ToString();
                            litrgsmad4.Text = AddCopy[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgsmname.Visible = true; litrgsmad1.Visible = true;
                            litrgsmad2.Visible = true; litrgsmad3.Visible = true;
                            litrgsmad4.Visible = true;
                            #endregion
                        }

                    }
                    litpostname.Text = AddCopy[0].ToString();
                    litpostad1.Text = AddCopy[1].ToString();
                    litpostad2.Text = AddCopy[2].ToString();
                    litpostad3.Text = AddCopy[3].ToString();
                    litpostad4.Text = AddCopy[4].ToString();
                    litpostad5.Text = AddCopy[5].ToString();

                    #region Show Postal Address
                    litpostname.Visible = true; litpostad1.Visible = true;
                    litpostad2.Visible = true; litpostad3.Visible = true;
                    litpostad4.Visible = true; litpostad5.Visible = true;
                    #endregion
                }

                if (index == 4)
                {
                    lblcopyto.Visible = true;
                    if (CopyToArray.Count > 3)
                    {
                        if (AddCopy[AddCopy.Count - 1].ToString() == "RG COD")
                        {
                            Rgcod = true;
                            litrgcdname.Text = AddCopy[0].ToString();
                            litrgcdad1.Text = AddCopy[1].ToString();
                            litrgcdad2.Text = AddCopy[2].ToString();
                            litrgcdad3.Text = AddCopy[3].ToString();
                            litrgcdad4.Text = AddCopy[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgcdname.Visible = true;
                            litrgcdad1.Visible = true; litrgcdad2.Visible = true;
                            litrgcdad3.Visible = true; litrgcdad4.Visible = true;
                            #endregion
                        }
                        else
                        {
                            Rgsm = true;
                            litrgsmname.Text = AddCopy[0].ToString();
                            litrgsmad1.Text = AddCopy[1].ToString();
                            litrgsmad2.Text = AddCopy[2].ToString();
                            litrgsmad3.Text = AddCopy[3].ToString();
                            litrgsmad4.Text = AddCopy[4].ToString();

                            #region Show Regional Coordinator Address
                            litrgsmname.Visible = true; litrgsmad1.Visible = true;
                            litrgsmad2.Visible = true; litrgsmad3.Visible = true;
                            litrgsmad4.Visible = true;
                            #endregion
                        }
                    }
                    litpostname.Text = AddCopy[0].ToString();
                    litpostad1.Text = AddCopy[1].ToString();
                    litpostad2.Text = AddCopy[2].ToString();
                    litpostad3.Text = AddCopy[3].ToString();
                    litpostad4.Text = AddCopy[4].ToString();
                    litpostad5.Text = AddCopy[5].ToString();

                    #region Show Postal Address
                    litpostname.Visible = true; litpostad1.Visible = true;
                    litpostad2.Visible = true; litpostad3.Visible = true;
                    litpostad4.Visible = true; litpostad5.Visible = true;
                    #endregion          
                }
                if (index == 5)
                {
                    lblcopyto.Visible = true;
                    if (CopyToArray.Count >4)
                    {
                        Rgsm = true;
                        litrgsmname.Text = AddCopy[0].ToString();
                        litrgsmad1.Text = AddCopy[1].ToString();
                        litrgsmad2.Text = AddCopy[2].ToString();
                        litrgsmad3.Text = AddCopy[3].ToString();
                        litrgsmad4.Text = AddCopy[4].ToString();
                        
                        #region Show Regional Coordinator Address
                        litrgsmname.Visible = true; litrgsmad1.Visible = true;
                        litrgsmad2.Visible = true; litrgsmad3.Visible = true;
                        litrgsmad4.Visible = true;
                        #endregion                       
                    }
                    litpostname.Text = AddCopy[0].ToString();
                    litpostad1.Text = AddCopy[1].ToString();
                    litpostad2.Text = AddCopy[2].ToString();
                    litpostad3.Text = AddCopy[3].ToString();
                    litpostad4.Text = AddCopy[4].ToString();
                    litpostad5.Text = AddCopy[5].ToString();

                    #region Show Postal Address
                    litpostname.Visible = true; litpostad1.Visible = true;
                    litpostad2.Visible = true; litpostad3.Visible = true;
                    litpostad4.Visible = true; litpostad5.Visible = true;
                    #endregion
                }
          %>
        <div style="text-align: center">
        <span style="font-size: 24pt"></span>
            <br />
            
        <table style="width: 637px; font-size: 12pt;">
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td style="width: 35px; height: 20px">
                </td>
                <td style="width: 260px; height: 20px">
                </td>
                <td style="width: 90px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal"><u><span><span style="font-family: Trebuchet MS">
                            <asp:Label ID="lblremi_no" runat="server" Width="174px"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml
                                namespace="" prefix="O" ?><o:p></o:p></span></span></u></b></p>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;"><span style="font-family: Trebuchet MS">
                        </span></span>
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;">
                        <span style="font-family: Trebuchet MS">
                        Our Ref: Life/ Claims/B/</span><asp:Label ID="lblEPF" runat="server" Width="90px" Font-Names="Trebuchet MS"></asp:Label></span></td>
            </tr>
            <tr style="font-size: 12pt; font-weight: bold; text-decoration: underline;">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-weight: normal; text-decoration: none;">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Times New Roman';">
                    <asp:Label ID="lbldate" runat="server" Width="90px" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label></td>
            </tr>
            <tr style="font-size: 12pt; font-weight: bold; text-decoration: underline;">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-weight: normal; text-decoration: none;">
                <td style="width: 15px; height: 17px">
                </td>
                <td colspan="3" style="height: 17px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litName" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd1" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 15px">
                </td>
                <td colspan="3" style="height: 15px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd2" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd3" runat="server"></asp:Literal></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litAd4" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; font-size: 10pt; font-family: 'Times New Roman';">
                        <span style="font-family: Trebuchet MS">
                        Dear Sir/Madam,</span></p>
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman;">
                <td style="width: 15px; height: 7px">
                </td>
                <td colspan="3" style="height: 7px; vertical-align: top;">
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman;">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        <span><span style="font-family: Trebuchet MS; font-size: 10pt; font-weight: bold; text-decoration: underline;"><strong><span style="text-decoration: underline; font-size: 10pt;">
                            Policy No: </span></strong>
                            <asp:Literal ID="litpolno" runat="server"></asp:Literal></span></span></span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; font-size: 10pt; font-weight: bold; text-decoration: underline;">
                        <span style="font-family: Trebuchet MS; text-decoration: underline;"><strong>On the Life of&nbsp; </strong></span>
                            <asp:Literal ID="litlifeassured" runat="server"></asp:Literal><span></span></span></td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px">
                </td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="width: 15px; height: 13px">
                </td>
                <td colspan="3" style="height: 13px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify; font-size: 10pt; font-family: 'Trebuchet MS';">
                        This refers to the death claim under the above policy. <span style="font-family: Trebuchet MS;
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA; mso-bidi-font-family: 'Times New Roman'">We would like
                            to draw your kind attention to our letter dated&nbsp;</span>
                        <asp:Literal ID="litdated" runat="server"></asp:Literal>
                        <asp:Label ID="lblsubsequentrem" runat="server" Style="text-align: center"
                            Width="200px">and subsequent reminder/s dated </asp:Label>&nbsp;
                        <asp:Literal ID="litsubseqdt1" runat="server"></asp:Literal>
                        <asp:Literal ID="litsubseqdt2" runat="server"></asp:Literal>
                        .</p>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblforthirdreminders" runat="server" Style="text-align: left" Width="415px" Visible="False">and kindly request you to forward the following documents urgently.</asp:Label></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="3" style="height: 16px; text-align: left">
                    <span style="font-size: 10pt; font-family: 'Trebuchet MS'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Please forward us the following requirements within 14 days to process this claim.</span></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 12px">
                </td>
                <td colspan="3" style="height: 12px; text-align: left">
                    <asp:Table ID="Table1" runat="server" HorizontalAlign="Justify" Width="614px" style="font-size: 10pt; font-family: 'Trebuchet MS'">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Literal ID="litreq21" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblforlastreminder" runat="server" Style="text-align: left" Width="613px" Visible="False">Also we would like to inform you that if we do not receive any respond from you for this letter within 14 days, we are compelled to treat this as an abandoned claim & close your claim.</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lblforlastreminder2" runat="server" Style="text-align: left" Width="613px" Visible="False">We are looking forward to receipt the above documents urgently</asp:Label></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: justify; font-size: 10pt; font-family: 'Trebuchet MS';">
                        Thank you,</p>
                </td>
                <td style="width: 90px; height: 16px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt; font-size: 10pt; font-family: 'Trebuchet MS';">
                        Yours truly,</p>
                </td>
                <td style="width: 90px; height: 16px; text-align: left; font-size: 12pt;">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 14px">
                </td>
                <td colspan="2" style="height: 14px; text-align: left; font-size: 11pt; font-family: 'Trebuchet MS';">
                    <span></span><span style="font-size: 10pt"><strong>SRI LANKA INSURANCE CORPORATION LIFE LTD</strong></span></td>
                <td style="width: 90px; height: 14px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 21px">
                </td>
                <td colspan="2" style="height: 21px; text-align: left">
                    ..................................</td>
                <td style="width: 90px; height: 21px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal; font-size: 10pt; font-family: 'Trebuchet MS';">For Life Manager.<o:p></o:p></b></p>
                </td>
                <td style="width: 90px; height: 20px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="2" style="height: 8px; text-align: left;">
                </td>
                <td style="width: 90px; height: 8px; text-align: left">
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 8px">
                </td>
                <td colspan="3" style="height: 8px; text-align: left">
                    <table style="font-size: 10pt; width: 614px; font-family: 'Trebuchet MS'">
                        <tr>
                            <td style="width: 50px">
                    <asp:Label ID="lblcopyto" runat="server" Style="text-align: center" Width="63px">Copy To:</asp:Label></td>
                            <td colspan="2">
                        <asp:Literal ID="litceo" runat="server" Text="Chief Executive Officer - Life"></asp:Literal></td>
                        </tr>
                        <%if (brcopy)
                          { %>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                    <asp:Literal ID="litbrname" runat="server"></asp:Literal><asp:Literal ID="litbrad1"
                        runat="server"></asp:Literal><asp:Literal ID="litbrad2" runat="server"></asp:Literal><asp:Literal
                            ID="litbrad3" runat="server"></asp:Literal><asp:Literal ID="litbrad4" runat="server"></asp:Literal></td>
                        </tr>
                        <%}
                          if (agcopy)
                          {
                        %>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                    <asp:Literal ID="litag1" runat="server"></asp:Literal><asp:Literal ID="litagad1"
                        runat="server"></asp:Literal><asp:Literal ID="litagad2" runat="server"></asp:Literal><asp:Literal
                            ID="litagad3" runat="server"></asp:Literal><asp:Literal ID="litagad4" runat="server"></asp:Literal>
                    <asp:Literal ID="litagad5" runat="server"></asp:Literal></td>
                        </tr>
                        <%
                            }
                            if (Rgcod)
                            {
                        %>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                    <asp:Literal ID="litrgcdname" runat="server"></asp:Literal><asp:Literal ID="litrgcdad1"
                        runat="server"></asp:Literal><asp:Literal ID="litrgcdad2" runat="server"></asp:Literal><asp:Literal
                            ID="litrgcdad3" runat="server"></asp:Literal><asp:Literal ID="litrgcdad4" runat="server"></asp:Literal></td>
                        </tr>
                        <%
                            }
                            if (Rgsm)
                            { %>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                    <asp:Literal ID="litrgsmname" runat="server"></asp:Literal><asp:Literal ID="litrgsmad1"
                        runat="server"></asp:Literal><asp:Literal ID="litrgsmad2" runat="server"></asp:Literal><asp:Literal
                            ID="litrgsmad3" runat="server"></asp:Literal><asp:Literal ID="litrgsmad4" runat="server"></asp:Literal></td>
                        </tr>
                        <%} %>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td style="width: 206px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                    <asp:Literal ID="litto" runat="server" Text="TO :"></asp:Literal></td>
                            <td style="width: 206px">
                    <asp:Literal ID="litpostname" runat="server"></asp:Literal></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td style="width: 206px">
                    <asp:Literal ID="litpostad1" runat="server"></asp:Literal></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td style="width: 206px">
                    <asp:Literal ID="litpostad2" runat="server"></asp:Literal></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td style="width: 206px">
                    <asp:Literal ID="litpostad3" runat="server"></asp:Literal></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                    <asp:Literal ID="litpostad4" runat="server"></asp:Literal>
                                <asp:Literal ID="litpostad5" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td style="width: 206px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>            
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left; font-size: 10pt; font-family: 'Trebuchet MS';">
                    <asp:Label ID="lbllast" runat="server" Width="440px" Visible="False">(Please obtain above requirements and forward us as soon as possible.)</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <b style="mso-bidi-font-weight: normal"><span style="font-size: 10pt; font-family: Trebuchet MS">
                            Our contact Nos. 2357247/2357225 /2357221/2357760/2357205</span></b><span style="font-size: 10pt"><?xml
                                namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 15px; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                        </td>
            </tr>
        </table>
            
            <br />
            &nbsp;</div><p class="breakhere" />
    
    <%
        }//foreach
    %>
    </asp:Panel>
    </form>
</body>
</html>
