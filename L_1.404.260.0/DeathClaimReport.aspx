<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeathClaimReport.aspx.cs" Inherits="DeathClaimReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <script src="JavaScript/FormValidation.js"  type="text/javascript"  language="javascript"></script>
    
    <script type="text/javascript">
        
     function test(source, arguments)
    {
    	    	
     if (!IsNumeric(arguments.Value))
            {arguments.IsValid = false;}          
              
     else
            {arguments.IsValid = true;}
    }  
    
     function test2(source, arguments)
    {
    	    	
     if (!IsNumeric02(arguments.Value))
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


   function validation(){

   var ControlName = document.getElementById("ddlSearchBy");
    if(ControlName.value == "P")  
      {
             if(document.getElementById("txtPloicy").value == "")  
              {
           
                   alert ("Plocy No is required");
                   return false;
      
              }
            else{
             return true;
            }
      }
    else{
    
         if(document.getElementById("txtfromdate").value == "")  
                  {       
                       alert ("From date is required");
                       return false;
      
                  }
          else if(document.getElementById("txttodate").value == "")  
                  {         
                       alert (" To date is required");
                       return false;
      
                  }
          else{
          return true;
          }
    
    }
   
   }

</script>
<link href="JavaScript/CalendarControl.css" rel="stylesheet" type="text/css"/>
    <script src="JavaScript/CalendarControl.js"  language="javascript" type="text/javascript">
</script>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 21px;
            width: 64px;
        }
        .style3
        {
            height: 21px;
            width: 27px;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: Trebuchet MS"><span style="font-size: 14pt"><span style="font-size: 12pt">
        </span>
        </span>
            <table style="font-weight: normal; font-size: 10pt; width: 549px; font-family: 'Trebuchet MS';
                background-color: #f0f0f0">
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="background-color: #ffffff" class="style1">
                        <span style="font-size: 14pt">Sri Lanka
            Insurance<br />
                        </span>
            <span style="font-size: 12pt"><strong>
           Death Claim Period Report</strong></span></td>
                </tr>
                <tr>
                    <td style="height: 21px; background-color: #f0f0f0" colspan="4">
                    </td>
                </tr>
                  <tr style="font-weight: bold">
                    <td class="style2">
                    </td>
                    <td style="width: 125px; text-align: left; font-weight: normal; height: 21px;">
                        Search Type</td>
                    <td style="width: 220px; text-align: left; height: 21px;">
                    <asp:DropDownList ID="ddlSearchType" runat="server" Width="85px" Font-Names="Trebuchet MS" Font-Size="10pt">
                        <asp:ListItem Value="D1">Duration 1</asp:ListItem>
                        <asp:ListItem Value="D2">Duration 2</asp:ListItem>
                        <asp:ListItem Value="D3">Duration 3</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td class="style3">
                    </td>
                </tr>
                     <tr style="font-size: 10pt">
                    <td class="style2">
                    </td>
                    <td style="width: 125px; text-align: left; font-weight: normal; height: 21px;">
                        Search By</td>
                    <td style="width: 220px; height: 21px; text-align: left">
                     <asp:DropDownList ID="ddlSearchBy" runat="server" Width="85px" 
                            Font-Names="Trebuchet MS" Font-Size="10pt" 
                            onselectedindexchanged="ddlSearchBy_SelectedIndexChanged" 
                            AutoPostBack="True">
                        <asp:ListItem Value="P">Policy No</asp:ListItem>
                        <asp:ListItem Value="D">Date wise</asp:ListItem>
                    </asp:DropDownList>
                        
                        </td>
                    <td class="style3">
                    </td>
                </tr>
                
                <tr>
                    <td style="background-color: #f0f0f0" class="style2">
                    </td>
                    <td style="width: 125px; height: 21px; background-color: #f0f0f0; text-align: left">
                        Policy No </td>
                    <td style="width: 220px; height: 21px; background-color: #f0f0f0; text-align: left">
                        <asp:TextBox ID="txtPloicy" runat="server" MaxLength="8" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:TextBox>
                   <asp:CustomValidator ID="CustomValidator3"
                                runat="server" ClientValidationFunction="test2" ControlToValidate="txtPloicy"
                                ErrorMessage="Invalid Policy" Display="Dynamic"></asp:CustomValidator></td>
                    <td style="background-color: #f0f0f0" class="style3">
                    </td>
                </tr>
            </table>
          </span>
    
            <asp:Panel ID="pnl" runat="server" Visible="false" Width="550px"  >
            <table style="font-weight: normal; font-size: 10pt; width: 549px; font-family: 'Trebuchet MS';
                background-color: #f0f0f0">
                 <tr>
                    <td class="style2">

                    </td>
                    <td style="width: 125px; text-align: left; height: 21px;">
                        From Date</td>
                    <td style="width: 220px; text-align: left; height: 21px;">
                        <asp:TextBox ID="txtfromdate" runat="server" MaxLength="8" 
                            Font-Names="Trebuchet MS" Font-Size="10pt" Enabled="False" ></asp:TextBox>
                        <asp:Image ID="ifrom" runat="server" Height="17px" ImageUrl="~/Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('txtfromdate'));" Width="16px" />
                        <asp:CustomValidator ID="CustomValidator1"
                                runat="server" ClientValidationFunction="test" ControlToValidate="txtfromdate"
                                ErrorMessage="???" Display="Dynamic"></asp:CustomValidator>YYYYMMDD</td>
                    <td style="font-size: 12pt; " class="style3">
                    </td>
                </tr>
                 <tr style="font-size: 12pt">
                    <td class="style2">
                    </td>
                    <td style="width: 125px; height: 21px; text-align: left">
                        <span style="font-size: 10pt">To Date</span></td>
                    <td style="width: 220px; height: 21px; text-align: left">
                        <asp:TextBox ID="txttodate" runat="server" MaxLength="8" 
                            Font-Names="Trebuchet MS" Font-Size="10pt" Enabled="False" ></asp:TextBox>
                            <asp:Image ID="ito" runat="server" Height="17px" ImageUrl="~/Image/SmallCalendar.gif" onclick="showCalendarControl(document.getElementById('txttodate'));" Width="16px" />
                            <asp:CustomValidator ID="CustomValidator2"
                                runat="server" ClientValidationFunction="test" ControlToValidate="txttodate"
                                ErrorMessage="???" Display="Dynamic"></asp:CustomValidator><span style="font-size: 10pt">YYYYMMDD</span></td>
                    <td class="style3">
                    </td>
                </tr>
        </table>
          </asp:Panel>
               
          
                
                <table style="font-weight: normal; font-size: 10pt; width: 549px; font-family: 'Trebuchet MS';
                background-color: #f0f0f0">
                <tr style="font-weight: bold">
                    <td class="style2">
                    </td>
                    <td style="width: 125px; text-align: left; font-weight: normal; height: 21px;">
                        &nbsp;</td>
                    <td style="width: 220px; text-align: left; height: 21px;">&nbsp;</td>
                    <td class="style3">
                    </td>
                </tr>
               
                <tr>
                    <td colspan="4" style="height: 21px">
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor ="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td style="width: 125px; height: 21px; text-align: left">
                    </td>
                    <td style="width: 220px; height: 21px; text-align: left">
                        <asp:Button ID="btnsubmit" runat="server" Font-Bold="False" Font-Names="Trebuchet MS" OnClientClick="return validation();"
                            OnClick="btnsubmit_Click" Text="--Submit--" Width="98px" Font-Size="10pt" />
                        &nbsp;
                        </td>
                    <td class="style3">
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td style="background-color: #f0f0f0" class="style2">
                    </td>
                    <td style="height: 21px; background-color: #f0f0f0; text-align: left" colspan="2">
                        &nbsp;</td>
                    <td style="background-color: #f0f0f0" class="style3">
                    </td>
                </tr>
            </table>
            </span>
    
    </div>
    </form>
</body>
</html>
