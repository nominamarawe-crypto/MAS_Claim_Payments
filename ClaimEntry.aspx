<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClaimEntry.aspx.cs" Inherits="MAS_Claim_Payments.ClaimEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    <script src="js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style4 {
            width: 175px;
        }
        .auto-style5 {
            height: 25px;
            width: 175px;
        }
        .style2
        {
            color: #0000FF;
        }
        .auto-style7 {
        text-align: center;
        color: steelblue;
    }
        .auto-style8 {
            width: 14px;
        }
        .auto-style9 {
            height: 25px;
            width: 14px;
        }
        .auto-style10 {
            height: 33px;
        }
        .auto-style11 {
            width: 175px;
            height: 33px;
        }
        .auto-style12 {
            width: 14px;
            height: 33px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script  language="javascript" type="text/javascript">
     $(function () {
         $("input[id$='tbxClaimdt']").datepicker({ dateFormat: "yy-mm-dd", changeMonth: true, changeYear: true });
     });
    </script>

    <table class="ui-accordion">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7" colspan="3"><strong style="text-align: center; font-weight: 700; color: SteelBlue">CLAIM ENTRY</strong></td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11">Policy No</td>
            <td class="auto-style10">:
                <asp:TextBox ID="tbxPolNo" runat="server" MaxLength="10" Width="150px" AutoPostBack="True" OnTextChanged="tbxNIC_TextChanged"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxPolNo" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style10"></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">NIC No</td>
            <td>:
                <asp:TextBox ID="tbxNIC" runat="server" MaxLength="12" Width="150px" AutoPostBack="True" OnTextChanged="tbxNIC_TextChanged"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNIC" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:Label ID="lblNICError" runat="server" ForeColor="Red"></asp:Label>
            &nbsp;<asp:RegularExpressionValidator ID="regExpValNIC" runat="server" ControlToValidate="tbxNIC" ErrorMessage="Invalid NIC No Format" ForeColor="Red" ValidationExpression="[0-9]{9}[V|v|X|x]|[1-2][0-9]{11}"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Insured Name</td>
            <td>:
                <asp:TextBox ID="tbxInsuredName" runat="server" MaxLength="200" Width="390px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbxInsuredName" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<a name="pageup12"><asp:RegularExpressionValidator ID="regExpValTel7" runat="server" ControlToValidate="tbxInsuredName" ErrorMessage="Invalid Insured Name" ForeColor="Red" ValidationExpression=".*[^0-9].*"></asp:RegularExpressionValidator>
                </a>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">EPF No</td>
            <td>:
                <asp:TextBox ID="tbxEPF" runat="server" MaxLength="5" Width="100px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Claimant Name</td>
            <td>:
                <asp:TextBox ID="tbxClaimantName" runat="server" MaxLength="200" Width="390px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbxClaimantName" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<a name="pageup13"><asp:RegularExpressionValidator ID="regExpValTel8" runat="server" ControlToValidate="tbxClaimantName" ErrorMessage="Invalid Claimant Name" ForeColor="Red" ValidationExpression=".*[^0-9].*"></asp:RegularExpressionValidator>
                </a>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Relashionship</td>
            <td>:
                <asp:TextBox ID="tbxRelationShip" runat="server" MaxLength="50" Width="190px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbxRelationShip" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Payment Type</td>
            <td>:
                <asp:DropDownList ID="ddlPayType" runat="server">
                    <asp:ListItem Value="S">--Select--</asp:ListItem>
                    <asp:ListItem Value="N">Normal</asp:ListItem>
                    <asp:ListItem Value="E">Ex-Gratia</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Claim Type</td>
            <td>:
                <asp:DropDownList ID="ddlClmType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClmType_SelectedIndexChanged">
                    <asp:ListItem Value="S">--Select--</asp:ListItem>
                    <asp:ListItem Value="D">Death</asp:ListItem>
                    <asp:ListItem Value="Dis">Disability</asp:ListItem>
                    <asp:ListItem Value="Hos">Hospital Cash</asp:ListItem>
                    <asp:ListItem Value="Fun">Funeral Expenses</asp:ListItem>
                    <asp:ListItem Value="ED">Ex-Gratia Death</asp:ListItem>
                    <asp:ListItem Value="EDis">Ex-Gratia Disability</asp:ListItem>
                    <asp:ListItem Value="EHos">Ex-Gratia Hospital Cash</asp:ListItem>
                    <asp:ListItem Value="EFun">Ex-Gratia Funeral Expenses</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Date of Claim</td>
            <td>:
                <asp:TextBox ID="tbxClaimdt" runat="server" MaxLength="12" Width="150px"></asp:TextBox>
&nbsp;&nbsp;<span class="style2">YYYY-MM-DD <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxClaimdt" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;</span><asp:RegularExpressionValidator ID="regExValFrm" runat="server" ControlToValidate="tbxClaimdt" Display="Dynamic" ErrorMessage="Invalid Date" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Payee Name</td>
            <td colspan="2">:
                <asp:TextBox ID="tbxPayeeName" runat="server" MaxLength="200" Width="390px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxPayeeName" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<a name="pageup5"><asp:RegularExpressionValidator ID="regExpValTel4" runat="server" ControlToValidate="tbxPayeeName" ErrorMessage="Invalid Payee Name" ForeColor="Red" ValidationExpression=".*[^0-9].*"></asp:RegularExpressionValidator>
                </a>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Amount</td>
            <td>:
                <asp:TextBox ID="tbxAmount" runat="server" MaxLength="12"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxAmount" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExValAmount" runat="server" ControlToValidate="tbxAmount" ErrorMessage="Invalid Amount" ForeColor="Red" ValidationExpression="^\$?(\d{1,2},?(\d{2},?)*\d{2}(.\d{0,2})?|\d{1,2}(.\d{2})?)$"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Bank Name</td>
            <td>:
                <asp:DropDownList ID="ddlBanks" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            &nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Branch Name</td>
            <td>:
                <asp:DropDownList ID="ddlBranches" runat="server" DataSourceID="sqlDSBankBranches" DataTextField="EXPR2" DataValueField="EXPR1">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlDSBankBranches" runat="server" ConnectionString="<%$ ConnectionStrings:DBConString %>" ProviderName="<%$ ConnectionStrings:DBConString.ProviderName %>" SelectCommand="SELECT BRCODE AS EXPR1, CONCAT(CONCAT(CONCAT(UPPER(BBRNCH), ' ('),BRCODE), ')') AS EXPR2 FROM GENPAY.BNKBRN WHERE (BCODE = :bankCode) UNION SELECT - 1 AS EXPR1, ' -Select Branch-' AS EXPR2 FROM SYS.&quot;DUAL&quot; ORDER BY EXPR2">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlBanks" DefaultValue="" Name="bankCode" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11">Account No</td>
            <td class="auto-style10">:
                <asp:TextBox ID="tbxAccNo" runat="server" MaxLength="15" Width="170px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxAccNo" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxAccNo" ErrorMessage="Invalid Account no" ForeColor="Red" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style10"></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Account Code</td>
            <td>:
                <asp:Literal ID="ltrAccCode" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Mobile No</td>
            <td>:
                <asp:TextBox ID="tbxMobile" runat="server" MaxLength="10"></asp:TextBox>
            &nbsp;<a name="pageup9"><asp:RegularExpressionValidator ID="regExpValTel6" runat="server" ControlToValidate="tbxMobile" ErrorMessage="Invalid Phone Number" ForeColor="Red" ValidationExpression="07[0|1|2|5|6|7|8|4][0-9]{7}"></asp:RegularExpressionValidator>
                </a>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">Email Address</td>
            <td>:
                <asp:TextBox ID="tbxEmail" runat="server" MaxLength="100"></asp:TextBox>
            &nbsp;<a name="pageup11"><asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="tbxEmail" ErrorMessage="Invalid email address" ForeColor="Red" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
                </a>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style5"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1" colspan="3">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" />
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1" colspan="3"><asp:Label ID="lblSubmitError" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblSuccessMsg" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style5"><a name="pageup">
                
                </a></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style9"></td>
        </tr>
        
    </table>



</asp:Content>
