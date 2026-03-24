<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClaimReport.aspx.cs" Inherits="MAS_Claim_Payments.ClaimReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script src="../js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>

    <style type="text/css">
    .style1
    {
        width: 665px;
        height: 20px;
    }
        .style2
        {
            color: #0000FF;
        }
        .style8
        {
            height: 25px;
            width: 607px;
        }
        .style9
        {
            height: 21px;
            width: 336px;
        }
        .style10
        {
            height: 25px;
            width: 336px;
        }
        .style11
        {
            height: 21px;
            width: 333px;
        }
        .style12
        {
            height: 25px;
            width: 333px;
        }
        .style13
        {
            height: 21px;
            width: 328px;
        }
        .style14
        {
            height: 25px;
            width: 328px;
        }
        .style15
        {
            height: 21px;
            width: 325px;
        }
        .style16
        {
            height: 25px;
            width: 325px;
        }
        .style17
        {
            height: 21px;
            width: 320px;
        }
        .style18
        {
            height: 25px;
            width: 320px;
        }
        .style19
        {
            height: 21px;
            width: 315px;
        }
        .style20
        {
            height: 25px;
            width: 315px;
        }
        .style22
        {
            height: 25px;
            width: 318px;
        }
        .style23
        {
            height: 25px;
            width: 326px;
        }
        .style24
        {
            height: 2px;
            width: 303px;
        }
        .style25
        {
            height: 21px;
            width: 303px;
        }
        .style26
        {
            height: 25px;
            width: 303px;
        }
        .style27
        {
            width: 31px;
        }
        .style28
        {
            height: 21px;
            width: 31px;
        }
        .style29
        {
            height: 21px;
            width: 200px;
            text-align: right;
        }
        .style30
        {
            width: 200px;
            text-align: right;
        }
        
        .ProcessingImg 
        {
          display: block;
          visibility: visible;
          position: absolute;
          z-index: 999;
          top: 0px;
          left: 0px;
          width: 105%;
          height: 105%;
          background-color:white;
          vertical-align:bottom;
          padding-top: 20%;
          filter: alpha(opacity=75);
          opacity: 0.75;
          font-size:large;
          color:blue;
          font-style:italic;
          font-weight:400;
          background-image: url("../Images/processing.gif");
          background-repeat: no-repeat;
          background-attachment: fixed;
          background-position: center;
          
        }         

        .auto-style5 {
            text-align: left;
        }
        .auto-style6 {
            height: 2px;
            width: 391px;
            text-align: left;
        }

        .auto-style7 {
            width: 665px;
            height: 400px;
        }

p.MsoNormal{
margin-bottom:.0001pt;
text-align:justify;
text-justify:inter-ideograph;
font-family:Calibri;
font-size:10.5000pt;
            margin-left: 0pt;
            margin-right: 0pt;
            margin-top: 0pt;
        }

        .auto-style8 {
            height: 21px;
        }
        .auto-style9 {
            width: 796px;
        }
        .auto-style10 {
            width: 765px;
        }
        .auto-style11 {
            width: 665px;
        }
        .auto-style12 {
            text-align: left;
            height: 21px;
        }
        .auto-style13 {
            text-align: center;
        }

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <%--<script type="text/javascript">

        $(window).on('load', function () {
            $("#coverScreen").hide();
        });

        function btnSubmit_4_Click(btnObj) {
            $("#coverScreen").show();
        }  

    </script>--%>
 <%-- <div class="ProcessingImg" id="coverScreen"></div>--%>
    
    <!-- Display processing... -->

    <script  language="javascript" type="text/javascript">
     $(function () {
         $("input[id$='tbxFromDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
     });
    </script>

    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxToDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>

    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxActurialFromDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxActurialToDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxActurialDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxActurialMatFromDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxActurialMatToDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
                 $(function () {
                     $("input[id$='tbxActurialMatDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
                 });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxPCRFromDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxPCRToDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='tbxDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("input[id$='txtDate']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
        });
    </script>
    

    <table style="background-color: #ffffff; font-family: 'Trebuchet MS'; font-size: small; color: #000000;" align="center" class="auto-style9">
            <tr>
                <td style="text-align: center; " class="style1">
                    <asp:Label ID="lblTopp" runat="server" Font-Bold="True" 
                        Font-Names="Trebuchet MS" Font-Size="Medium"
                        Text="MAS CLAIMS - REPORTS" ForeColor="SteelBlue"></asp:Label>
                        </td>
            </tr>
            <tr>
                <td style="text-align: center; " class="style1">
                </td>
            </tr>
            <tr style="background-color: #ffffff">
                <td style="text-align: center; " class="auto-style11">
                    <p class="MsoNormal" style="text-align: center">
                        <span style="mso-spacerun:'yes';font-family:Calibri;mso-fareast-font-family:宋体;font-size:10.5000pt;mso-font-kerning:1.0000pt;"><strong>Claims Report</strong></span></p>
                </td>
            </tr>
            
            <tr style="background-color: #ffffff">
                
                <td style="text-align: center" class="auto-style7">
        <table style="border: 1px none black; text-align: center; " 
                        id="tble" align="center" class="auto-style10">
            <tr>
                <td style="background-color: #D8E4F8;" colspan="2" class="auto-style8">
                    &nbsp; &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
           
            <tr style="font-weight: bold">
                <td colspan="2" style="height: 20px; text-align: center">
                </td>
            </tr>
           
            <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman; font-weight: bold;">
                <td colspan="2" style="height: 24px;" class="auto-style13">
                    <asp:Label ID="lblOptSelect" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" Text="Please Select Your Option"></asp:Label>
                    &nbsp; &nbsp;
                    <asp:DropDownList ID="ddlHistory" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlHistory_SelectedIndexChanged" Font-Names="Trebuchet MS" 
                        Font-Size="Small" Width="109px">
                        <asp:ListItem Value="1">Policy No</asp:ListItem>
                        <asp:ListItem Value="2">NIC</asp:ListItem>
                        <asp:ListItem Value="3">Date Range </asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                </td>
            </tr>
           
            
            
            <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman; font-weight: bold;">
                <td colspan="2" style="height: 24px;" class="auto-style5">
                    &nbsp;</td>
            </tr>
           
            
            
            <tr style="color: #000000; font-size: 12pt; font-family: Times New Roman;">
                <td colspan="2" class="auto-style5">
                        <asp:Label ID="lblPolNo" runat="server" Text="Policy No" Font-Names="Trebuchet MS" Font-Size="Small"></asp:Label>
                    &nbsp;&nbsp; &nbsp;<asp:TextBox ID="tbxPolNo" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                    &nbsp;
                    <span style="font-size: 9pt; font-family: Trebuchet MS">
                    <%--<asp:RegularExpressionValidator ID="regExValPolNo" runat="server" 
                        BorderColor="Transparent" ControlToValidate="tbxPolNo" Display="Dynamic" ErrorMessage="Invalid"
                        Font-Names="Trebuchet MS" Font-Size="Small" SetFocusOnError="True" 
                        ValidationExpression="[0-9]*" ForeColor="Red"></asp:RegularExpressionValidator>--%></span></td>
            </tr>
           
            <tr style="color: #000000">
                <td colspan="2" style="height: 2px; text-align: right">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr style="color: #000000">
                <td class="auto-style6">
                    <span style="font-size: 9pt; font-family: Trebuchet MS">
                        <asp:Label ID="lblFrmDate" runat="server" Text="From Claim Date" 
                        Font-Names="Trebuchet MS" Font-Size="Small"></asp:Label>&nbsp;:&nbsp; </span>
                    <asp:TextBox ID="tbxFromDate" runat="server" Visible="True" MaxLength="10" Width="121px"></asp:TextBox>
                &nbsp;<span class="style2">YYYY-MM-DD</span></td>
                <td style="height: 2px; " class="auto-style5">
                    <span style="font-size: 9pt; font-family: Trebuchet MS">
                        <asp:Label ID="lblToDate" runat="server" Text="To Claim Date" 
                        Font-Names="Trebuchet MS" Font-Size="Small"></asp:Label>&nbsp;:&nbsp; </span>
                    <asp:TextBox ID="tbxToDate" runat="server" Visible="True" ToolTip="YYYY/MM/DD" 
                        MaxLength="10" Width="110px" ontextchanged="tbxToDate_TextChanged"></asp:TextBox>&nbsp;<span 
                        class="style2">YYYY-MM-DD</span></td>
            </tr>
            
            <%--<tr style="color: #000000">
                <td class="style25">
                    <asp:RequiredFieldValidator ID="reqFieValFrmDate" runat="server" ControlToValidate="tbxFromDate"
                        ErrorMessage="*Required" Font-Names="Trebuchet MS" Font-Size="Small"
                        SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExValFrm" runat="server" ControlToValidate="tbxFromDate"
                        Display="Dynamic" ErrorMessage="Invalid" Font-Names="Trebuchet MS"
                        Font-Size="Small" SetFocusOnError="True" 
                        ValidationExpression="^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$" 
                        ForeColor="Red"></asp:RegularExpressionValidator></td>
                <td style="height: 21px; text-align: center">
                    <asp:RequiredFieldValidator ID="reqFieValToDate" runat="server" ControlToValidate="tbxToDate"
                        ErrorMessage="*Required" Font-Names="Trebuchet MS" 
                        Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExValTo" runat="server" ControlToValidate="tbxToDate"
                        Display="Dynamic" ErrorMessage="Invalid" Font-Names="Trebuchet MS"
                        Font-Size="Small" SetFocusOnError="True" 
                        ValidationExpression="^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$" 
                        ForeColor="Red"></asp:RegularExpressionValidator></td>
            </tr>--%>
            
            
           
            <tr style="color: #000000">
                <td colspan="2" style="height: 21px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="2" class="auto-style12">
                    <asp:Label ID="lblNIC" runat="server" Font-Names="Trebuchet MS" Font-Size="Small" Text="NIC" Visible="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:TextBox ID="tbxNIC" runat="server" Visible="True" MaxLength="12" Width="200px"></asp:TextBox>
                    &nbsp;<%--<asp:RequiredFieldValidator ID="reqFieValClmNo2" runat="server" ControlToValidate="tbxNIC"
                        Enabled="False" ErrorMessage="*Required" Font-Names="Trebuchet MS" 
                        Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="regExpValNIC" runat="server" ControlToValidate="tbxNIC" ErrorMessage="Invalid NIC No Format" ForeColor="Red" ValidationExpression="[0-9]{9}[V|v|X|x]|[1-2][0-9]{11}"></asp:RegularExpressionValidator>
                    </td>
            </tr>
            
            <tr style="color: #000000">
                <td colspan="2" style="height: 21px; text-align: center">
                    &nbsp;</td>
            </tr>
            
            
            
           
           
           
           
                    
            <tr style="color: #000000">
                <td style="height: 18px; text-align: center; background-color: #D8E4F8;" 
                    colspan="2">
                    &nbsp;</td>
            </tr>  
            <tr style="color: #000000">
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnSubmitMain" class="button button1" runat="server" onclick="btnSubmitMain_Click" 
                        Text="Submit" />
                    <asp:Button ID="btnResetMain0" class="button button1" runat="server" onclick="btnResetMain_Click" 
                        Text="Reset" />
                    </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="2" style="height: 21px; text-align: center">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red"></asp:Label></td>
            </tr>
             <tr style="color: #000000">
     <td colspan="2" style="height: 21px; text-align: center">
         <div>
    <br />
    <br />
</div>

         </td>
 </tr>

            </table>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            
            
                 
           
            
            
                <tr style="background-color: #ffffff">
                <td style="text-align: center" class="auto-style11">
                    </td>
    </tr>
             
            

            
        
</asp:Content>
