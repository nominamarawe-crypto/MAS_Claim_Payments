<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolReStat002.aspx.cs" Inherits="PolReStat002" %>
<%@ PreviousPageType VirtualPath="~/PolReStat001.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Death Claim-Policy Restate</title>
      <script language ="JavaScript" type ="text/javascript" >
    function backPage()
    {
        history.back(1);
    }
    </script>
         <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
     
    <script type="text/javascript">    
    
     function test(source, arguments)
    {
    	
     if (!IsNumeric(arguments.Value))
               {arguments.IsValid = false;}          
             
     else
            {arguments.IsValid = true;}
    }   
    
  function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}</script>
 <script src="JavaScript/ValidateNumeric.js" language="javascript" type="text/javascript"></script>
   <script language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-family: Trebuchet MS"><span style="font-size: 14pt">Sri Lanka
            Insurance<br />
        </span><span style="font-size: 12pt">Death Claims - Policy Restate<br />
            <br />
        </span></span></strong>
            <table style="font-family: Times New Roman" >
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left; height: 20px;">
                    </td>
                    <td colspan="5" style="background-color: #cccccc; text-align: center; height: 20px;">
                        <asp:Label ID="lblsuccess" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                            Font-Size="12pt" ForeColor="#00CC33" Text="Updates Successfull" Visible="False"
                            Width="427px"></asp:Label></td>
                    <td style="width: 31px; background-color: #cccccc; height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; text-align: left; height: 18px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 18px;">
                        <span style="font-size: 11pt">Policy Nimber</span></td>
                    <td style="width: 142px; text-align: left; height: 18px;">
                        <asp:Literal ID="litPolNum" runat="server"></asp:Literal></td>
                    <td style="width: 42px; height: 18px; text-align: left">
                    </td>
                    <td style="width: 141px; height: 18px; text-align: left;">
                        Date of Death</td>
                    <td style="width: 118px; height: 18px; text-align: left;">
                        <asp:Literal ID="litDOD" runat="server"></asp:Literal></td>
                    <td style="width: 31px; height: 18px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left; height: 20px;">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc; height: 20px;">
                        <span style="font-size: 11pt">Name</span></td>
                    <td style="width: 142px; background-color: #cccccc; text-align: left; height: 20px;">
                        <asp:Literal ID="litName" runat="server"></asp:Literal></td>
                    <td style="width: 42px; height: 20px; background-color: #cccccc">
                    </td>
                    <td style="width: 141px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 118px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 31px; background-color: #cccccc; height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; height: 20px;">
                    </td>
                    <td style="width: 156px; height: 20px; text-align: left;">
                        <span style="font-size: 11pt">Address</span></td>
                    <td style="width: 142px; text-align: left; font-size: 12pt; height: 20px;">
                        <asp:Literal ID="litAdd1" runat="server"></asp:Literal></td>
                    <td style="font-size: 12pt; width: 42px; height: 20px">
                    </td>
                    <td style="width: 141px; font-size: 12pt; height: 20px;">
                    </td>
                    <td style="width: 118px; font-size: 12pt; height: 20px;">
                    </td>
                    <td style="width: 31px; font-size: 12pt; height: 20px;">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 156px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 142px; background-color: #cccccc; text-align: left; height: 20px;">
                        <asp:Literal ID="litAdd2" runat="server"></asp:Literal></td>
                    <td style="width: 42px; height: 20px; background-color: #cccccc">
                    </td>
                    <td style="width: 141px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 118px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 31px; background-color: #cccccc; height: 20px;">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; height: 20px;">
                    </td>
                    <td style="width: 156px; height: 20px;">
                    </td>
                    <td style="width: 142px; text-align: left; height: 20px;">
                        <asp:Literal ID="litAdd3" runat="server"></asp:Literal></td>
                    <td style="width: 42px; height: 20px">
                    </td>
                    <td style="width: 141px; height: 20px;">
                    </td>
                    <td style="width: 118px; height: 20px;">
                    </td>
                    <td style="width: 31px; height: 20px;">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; background-color: #cccccc; height: 20px;">
                        </td>
                    <td style="width: 156px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 142px; background-color: #cccccc; text-align: left; height: 20px;">
                        <asp:Literal ID="litAdd4" runat="server"></asp:Literal></td>
                    <td style="width: 42px; height: 20px; background-color: #cccccc">
                    </td>
                    <td style="width: 141px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 118px; background-color: #cccccc; height: 20px;">
                    </td>
                    <td style="width: 31px; background-color: #cccccc; height: 20px;">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; text-align: left; height: 21px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 21px;">
                    </td>
                    <td style="width: 142px; text-align: left; height: 21px;">
                    </td>
                    <td style="width: 42px; height: 21px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; height: 21px;">
                    </td>
                    <td style="width: 118px; text-align: left; height: 21px;"></td>
                    <td style="width: 31px; text-align: left; height: 21px;">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc;">
                        <span>
                        Current Status</span></td>
                    <td style="width: 142px; background-color: #cccccc; text-align: left;">
                        <asp:Literal ID="litCstat" runat="server"></asp:Literal></td>
                    <td style="width: 42px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc;">
                        <span>Policy Status</span></td>
                    <td style="width: 118px; background-color: #cccccc;">
                        <asp:DropDownList ID="ddlStat" runat="server" Width="154px">
                            <asp:ListItem Selected="True" Value="NO">-----select------</asp:ListItem>
                            <asp:ListItem Value="INF">Inforece</asp:ListItem>
                            <asp:ListItem Value="LPS">Lapse</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 31px; background-color: #cccccc">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; text-align: left">
                        .</td>
                    <td style="width: 156px; text-align: left">
                    </td>
                    <td style="width: 142px; text-align: left">
                    </td>
                    <td style="width: 42px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left">
                    </td>
                    <td style="width: 118px; text-align: left">
                    </td>
                    <td style="width: 31px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="width: 32px; background-color: #cccccc; text-align: left; height: 26px;">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc; height: 26px;">
                        <span style="font-size: 11pt">Date of Commencement</span></td>
                    <td style="width: 142px; background-color: #cccccc; height: 26px;">
                        <asp:TextBox ID="txtComDat" runat="server" MaxLength="8"></asp:TextBox></td>
                    <td style="width: 42px; height: 26px; background-color: #cccccc; text-align: left">
                        <span style="font-size: 8pt; color: #ff0000">(YYYYMMDD)</span></td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc; height: 26px;">
                        <span style="font-size: 11pt">Maturity Date</span></td>
                    <td style="width: 118px; background-color: #cccccc; height: 26px;">
                        <asp:TextBox ID="txtMatDat" runat="server" MaxLength="8"></asp:TextBox></td>
                    <td style="width: 31px; background-color: #cccccc; height: 26px;">
                        <span style="font-size: 8pt; color: #ff3333">(YYYYMMDD)</span></td>
                </tr>
                <tr>
                    <td style="width: 32px; text-align: left; height: 20px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 20px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtComDat"
                                ErrorMessage="Invalid Date" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; text-align: left; height: 20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComDat"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 20px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; height: 20px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtMatDat"
                                ErrorMessage="Invalid Date" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 118px; text-align: left; height: 20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMatDat"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 31px; text-align: left; height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Table</span></td>
                    <td style="width: 142px; background-color: #cccccc;">
                        <asp:TextBox ID="txtTbl" runat="server" MaxLength="3"></asp:TextBox></td>
                    <td style="width: 42px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Term</span></td>
                    <td style="width: 118px; background-color: #cccccc;">
                        <asp:TextBox ID="txtTrm" runat="server" MaxLength="2"></asp:TextBox></td>
                    <td style="width: 31px; background-color: #cccccc">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; height: 22px; text-align: left">
                    </td>
                    <td style="width: 156px; height: 22px; text-align: left">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtTbl"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; height: 22px; text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTbl"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 22px; text-align: left">
                    </td>
                    <td style="width: 141px; height: 22px; text-align: left">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtTrm"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 118px; height: 22px; text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTrm"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 31px; height: 22px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left; height: 21px;">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc; height: 21px;">
                        <span style="font-size: 11pt">Sum Assured</span></td>
                    <td style="width: 142px; background-color: #cccccc; height: 21px;">
                        <asp:TextBox ID="txtSumAss" runat="server" MaxLength="18"></asp:TextBox></td>
                    <td style="width: 42px; height: 21px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc; height: 21px;">
                        <span style="font-size: 11pt">Mode of Payment</span></td>
                    <td style="width: 118px; background-color: #cccccc; height: 21px;">
                        <asp:TextBox ID="txtMod" runat="server" MaxLength="1"></asp:TextBox></td>
                    <td style="width: 31px; background-color: #cccccc; height: 21px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; text-align: left; height: 21px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 21px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtSumAss"
                                ErrorMessage="Invalid Currency" MaximumValue="9999999999" MinimumValue="0" Type="Currency"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; text-align: left; height: 21px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSumAss"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 21px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; height: 21px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txtMod"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 118px; text-align: left; height: 21px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMod"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 31px; text-align: left; height: 21px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Premium</span></td>
                    <td style="width: 142px; background-color: #cccccc;">
                        <asp:TextBox ID="txtPrm" runat="server" MaxLength="18"></asp:TextBox></td>
                    <td style="width: 42px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Next Effecting</span></td>
                    <td style="width: 118px; background-color: #cccccc;">
                        <asp:TextBox ID="txtNEdat" runat="server" MaxLength="6"></asp:TextBox></td>
                    <td style="width: 31px; background-color: #cccccc">
                        <span style="font-size: 10pt"><span style="font-size: 8pt; color: #ff0033">(YYYYMM)</span></span></td>
                </tr>
                <tr>
                    <td style="width: 32px; text-align: left; height: 17px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 17px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtPrm"
                                ErrorMessage="Invalid Currency" MaximumValue="9999999999" MinimumValue="0" Type="Currency"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; text-align: left; height: 17px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrm"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 17px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; height: 17px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txtNEdat"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 118px; text-align: left; height: 17px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNEdat"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 31px; text-align: left; height: 17px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">PA code</span></td>
                    <td style="width: 142px; background-color: #cccccc;">
                        <asp:TextBox ID="txtPAcod" runat="server" MaxLength="8"></asp:TextBox></td>
                    <td style="width: 42px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Agent Code</span></td>
                    <td style="width: 118px; background-color: #cccccc;">
                        <asp:TextBox ID="txtAgCod" runat="server" MaxLength="8"></asp:TextBox></td>
                    <td style="width: 31px; background-color: #cccccc">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; height: 22px; text-align: left">
                    </td>
                    <td style="width: 156px; height: 22px; text-align: left">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtPAcod"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; height: 22px; text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPAcod"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 22px; text-align: left">
                    </td>
                    <td style="width: 141px; height: 22px; text-align: left">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txtAgCod"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 118px; height: 22px; text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAgCod"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 31px; height: 22px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 156px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Organizer Code</span></td>
                    <td style="width: 142px; background-color: #cccccc;">
                        <asp:TextBox ID="txtOrCod" runat="server" MaxLength="5"></asp:TextBox></td>
                    <td style="width: 42px; background-color: #cccccc; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; background-color: #cccccc;">
                        <span style="font-size: 11pt">Branch Code</span></td>
                    <td style="width: 118px; background-color: #cccccc;">
                        <asp:TextBox ID="txtBrCod" runat="server" MaxLength="4"></asp:TextBox></td>
                    <td style="width: 31px; background-color: #cccccc">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; text-align: left; height: 20px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 20px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtOrCod"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; text-align: left; height: 20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOrCod"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 20px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; height: 20px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator14" runat="server" ControlToValidate="txtBrCod"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 118px; text-align: left; height: 20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBrCod"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 31px; text-align: left; height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc; height: 21px;">
                    </td>
                    <td style="width: 156px; background-color: #cccccc; height: 21px; text-align: left;">
                        Policy Originated Branch</td>
                    <td style="width: 142px; background-color: #cccccc; height: 21px; text-align: left;">
                        <asp:TextBox ID="txtOrBrn" runat="server" MaxLength="4">0</asp:TextBox></td>
                    <td style="width: 42px; height: 21px; background-color: #cccccc">
                    </td>
                    <td style="width: 141px; background-color: #cccccc; height: 21px;">
                    </td>
                    <td style="width: 118px; background-color: #cccccc; height: 21px;">
                    </td>
                    <td style="width: 31px; background-color: #cccccc; height: 21px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; text-align: left; height: 20px;">
                    </td>
                    <td style="width: 156px; text-align: left; height: 20px;">
                        <span style="font-size: 11pt">
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOrBrn"
                                ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="0" Type="Double"
                                ValidationGroup="a"></asp:RangeValidator></span></td>
                    <td style="width: 142px; text-align: left; height: 20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrBrn"
                            ErrorMessage="Pls Fill This Field" ValidationGroup="a" Width="113px"></asp:RequiredFieldValidator></td>
                    <td style="width: 42px; height: 20px; text-align: left">
                    </td>
                    <td style="width: 141px; text-align: left; height: 20px;">
                        <span style="font-size: 11pt"></span>
                    </td>
                    <td style="width: 118px; text-align: left; height: 20px;">
                    </td>
                    <td style="width: 31px; text-align: left; height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 32px; background-color: #cccccc">
                        </td>
                    <td style="width: 156px; background-color: #cccccc;">
                        </td>
                    <td style="width: 142px; background-color: #cccccc;">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="101px" OnClick="btnsubmit_Click" ValidationGroup="a" /></td>
                    <td style="width: 42px; background-color: #cccccc">
                    </td>
                    <td style="width: 141px; background-color: #cccccc;">
                        <asp:Button ID="btnreset" runat="server" Text="Reset" Width="93px" /></td>
                    <td style="width: 118px; background-color: #cccccc;">
                        <input onclick="backPage();" type="button" value="<< Back" /></td>
                    <td style="width: 31px; background-color: #cccccc">
                    </td>
                </tr>
            </table>
       
    
    </div>
        <asp:HiddenField ID="hdstat" runat="server" />
    </form>
</body>
</html>
