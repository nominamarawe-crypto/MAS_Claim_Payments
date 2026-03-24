<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthReg003.aspx.cs" Inherits="dthReg003" %>
<%@ PreviousPageType VirtualPath="~/dthReg002.aspx"%>
<%@ Reference Page="~/EPage.aspx" %>
<%@ Reference Page="~/loanCalculation.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SriLanka Insurance - Death Claims</title>
    <style type="text/css">
        .body
        {
            font-size: 12px;
            font-family: Trebuchet MS;
        }
         
        .colon
        {
            padding-right:5px;
        }
        
        
        table,th,td
        {
            border:0px;
        }
        
        .details  
        {
           border:0px;
           width:680px;
        }
        
         .details th
        {
           border:0px;
           text-align:center;
        } 
              
        .details td
        {
           border:0px;
           text-align:left;
        }
        

 
        
        .policyDetail
        {
            width:680px;
            border-collapse:collapse;
        }
        .policyDetail td, th
        {
            
            width:170px;
            border:1px solid black;
        }
        
        .coverDetail
        {
            width:550px;
            border-collapse:collapse;
        }
        .coverDetail td, th
        { 
            border:1px solid black;
        }

        .coverLeft
        {
            width: 425px;
            text-align:left !important;
            padding-left: 10px;
        } 
        .coverRight
        {
            width: 125px;
            text-align:right !important;
            padding-right: 10px;
        } 
        .nom 
        {
           border:0px;
           width:680px;
        } 
              
        .nom th, td
        {
		   width:auto;
           border:0px;
           text-align:center;
        }
        .nomNew 
        {
            text-align:left !important;
        } 
        
        .horLine {
            border-style: solid; border-color: #000000; vertical-align:middle;
        }
        .extraMsg 
        {
            font-size: 8px;
        }
        
    </style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div style="width: 680px;font-size: 12px;">
        <span style="font-family: Trebuchet MS">
        </span>

       <table class="details" >
         <tr > 
                <th colspan="4">
                    <b>SRI LANKA INSURANCE</b> <br />
                        <u>Death Claim Registration</u>
                    <br />
                    
                </th>                    
         </tr>

           

          <tr>
                <td width="160px"  > Claim No </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lblclmno" runat="server"  ></asp:Label> </td>
                <td width="150px"  >  Name of the Informer </td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblinfoname" runat="server"  ></asp:Label></td>
          </tr>

          <tr>
                <td width="160px"  > Policy No </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lblpolno" runat="server"  ></asp:Label></td>
                <td width="150px"  > Main Life or Spouse </td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblmof" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
          </tr>
          <tr>
                <td width="160px"  > Date of Commencement </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lbldtofcomm" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td width="150px"  >  Civil or Forces </td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblcof" runat="server" ></asp:Label> </td>
          </tr>

          <tr>
                <td width="160px"  > Date of Death </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lbldtofdth" runat="server"  ></asp:Label> </td>
                <td width="150px"  > Date of Intimation</td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lbldtofintim" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
          </tr>

          <tr>
                <td width="160px"  > Policy Status </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lblpolstat" runat="server"  ></asp:Label></td>
                <td width="150px"  > Age at Death </td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblageatdth" runat="server" Font-Bold="False" Visible="False" Width="122px"></asp:Label></td>
          </tr>
          <tr>
                <td width="160px"  > Age at Entry </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lblageatentry" runat="server"   Visible="False"  ></asp:Label></td>
                <td width="150px"  > Sum Assured </td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblsumassured" runat="server"  ></asp:Label></td>
          </tr>

          <tr>
                <td width="160px"  > Table/Term </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lbltab" runat="server" Font-Bold="False" Width="50px"></asp:Label>
                                      <asp:Label ID="lblterm" runat="server" Font-Bold="False" Width="50px"></asp:Label></td>
                <td width="150px"  > Policy Duration </td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblduyrs" runat="server"  ></asp:Label>
                </td>
          </tr>
           <tr>
                <td width="160px"  > Name of the deceased</td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lblnameofdead" runat="server"  ></asp:Label></td>
                <td width="150px"  >  </td>
                <td width="190px"  > &nbsp;</td>
          </tr>
           <tr id="pnlHavePayment" runat="server">
                <td width="160px" colspan="4" >
                    <asp:Label ID="lblhasPayWarr" runat="server"></asp:Label>
                </td>
          </tr>
        </table> 
       
       <hr class="horLine"  />

       <table  class="policyDetail"  style="width:680px;"  >
       <tr >
            <td>Death Certificate</td>
            <td>&nbsp;</td>
            <td>Inquest & PM</td>
            <td></td>
       </tr>
       <tr>
            <td>Claimant Statement</td>
            <td>&nbsp;</td>
            <td>Birth Certificate & MC</td>
            <td></td>
       </tr>

       <tr>
            <td>Original Policy</td>
            <td></td>
            <td>Duty & Service No</td>
            <td></td>
       </tr>

       <tr>
            <td>LMA Report & DT</td>
            <td>&nbsp;</td>
            <td>Other</td>
            <td> &nbsp;</td>
       </tr>
       
       </table>

        <br />
            <asp:Label ID="Label2" runat="server" Text="Nominees" Visible="False" 
            Font-Bold="True" style="display:block; text-align:center;" Font-Italic="False" 
            Font-Underline="True"></asp:Label>
            <asp:Table ID="Table2" runat="server" class="nom"> </asp:Table>     
            <br/>
             <asp:Label ID="Label3" runat="server" Text="Pending Nominees" Visible="False" 
            Font-Bold="True" style="display:block; text-align:center;" Font-Italic="False" 
            Font-Underline="True"></asp:Label>
            <asp:Table ID="Table4" runat="server" class="nom"> </asp:Table>
        <br/>
            <asp:Label ID="lblcoverfor" runat="server"  Font-Bold="True" 
            style=" text-align:center;" Font-Underline="True" 
            Width="680px"></asp:Label> <br />
            <asp:Table ID="Table3" runat="server"  class="nom"> </asp:Table>   
            

       <hr class="horLine"  />

       <table id="details" class="details">          

          <tr>
                <td width="160px"  > Age Admit </td>
                <td width="180px"  > <span class="colon">:</span> <asp:Label ID="lblageadmit" runat="server" Font-Bold="False" Width="26px"></asp:Label>  </td>
                <td width="150px"  >  Revivals</td>
                <td width="190px"  > <span class="colon">:</span>
                    <asp:Label ID="lblrevivals" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
          </tr>

          <tr>
                <td width="160px"  > Total Bonuses</td>
                <td width="180px"  > <span class="colon">:</span><asp:Label ID="lbltotbons" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
                <td width="150px"  > Deposits </td>
                <td width="190px"  > <span class="colon">:</span><asp:Label ID="lbldeposits" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
          </tr>
          <tr>
                <td width="160px"  > Bonus Surrenders </td>
                <td width="180px"  > <span class="colon">:</span><asp:Label ID="lblbonsurrenders" runat="server" Font-Bold="False" Width="122px"></asp:Label> </td>
                <td width="150px"  >  Reinsurance </td>
                <td width="190px"  > <span class="colon">:</span><asp:Label ID="lblreinsyn" runat="server" Font-Bold="False" Width="122px"></asp:Label> </td>
          </tr>

          <tr>
                <td width="160px"  > Loan amount </td>
                <td width="180px"  > <span class="colon">:</span>  <asp:Label ID="LbAgeAdminAmt" runat="server" Width="61px" ></asp:Label>   </td>
                <td width="150px"  > Surrender Year</td>
                <td width="190px"  > <span class="colon">:</span> <asp:Label ID="lblbonsurryr" runat="server" Font-Bold="False" Width="122px"></asp:Label></td>
          </tr>

          <tr>
               
                <td width="150px"  > Loan Interest</td>
                <td width="190px"  > <span class="colon">:</span>  <asp:Label ID="LbAgeAmtInt" runat="server"  Width="61px" ></asp:Label> </td>

                <td width="160px"  > <%--Bonus--%> </td>
                <td width="180px"  > <span class="colon"><%--:--%></span> <asp:Label ID="lblBonuses" runat="server" Font-Bold="False" Width="122px" Visible="false"></asp:Label> </td>
          </tr>
        
        </table> 

        <br />
        <asp:Label ID="lblAMLDesignatedPersons" runat="server" ForeColor="#FF3300" Font-Bold="true" Visible="false"></asp:Label>
        <br /><br />

       <table class="details">
            <tr >
                <td colspan="2">  <b>Entered By</b> &nbsp; &nbsp;: ---------------------------</td>
                 <td colspan="2"> <b>Checked By</b>   &nbsp; &nbsp; : ---------------------------</td>
            </tr>
           <tr>
               <td colspan="4" style="text-align: center">
        <asp:Label ID="LtUserDetails" runat="server" Font-Size="10px" Width="235px"></asp:Label></td>
           </tr>
       </table>
       <hr class="horLine"  />
       <b>Decision :-</b>&nbsp;
        <asp:Table ID="Table1" runat="server" Width="710px" Height="18px" Visible="false"> </asp:Table>


        
                <asp:Label ID="lblmethofinfo" runat="server" Font-Bold="False" Width="122px"            Visible="False"></asp:Label>
                <asp:Label ID="lblageatentstr" runat="server" Font-Bold="False" Visible="False" Width="122px" Text="Age At Entry"  ></asp:Label>
                <asp:Label ID="lblageatdthstr" runat="server" Font-Bold="False" Visible="False" Width="122px" Text="Age At Death" ></asp:Label>
                <asp:Label ID="lblassuredad1" runat="server" Font-Bold="False" Width="428px"            Visible="False"></asp:Label>
                <asp:Label ID="lblnameofInsured" runat="server" Font-Bold="False" Width="428px"            Visible="False"></asp:Label>

                <asp:Label ID="lblassuredad2" runat="server" Font-Bold="False" Width="428px"            Visible="False"></asp:Label>
                <asp:Label ID="lblinfoad1" runat="server" Font-Bold="False" Width="156px"            Visible="False"></asp:Label>
                <asp:Label ID="Label1" runat="server" Font-Size="10.5pt" Text="Previous Loans" Visible="False" Width="215px"></asp:Label>
                <asp:Label ID="lblinfoad3" runat="server" Font-Bold="False" Width="104px"            Visible="False"></asp:Label>
                <asp:Label ID="lblinfoid" runat="server" Font-Bold="False" Width="122px"            Visible="False"></asp:Label>
                <asp:Label ID="lblinfotel" runat="server" Font-Bold="False" Width="122px"            Visible="False"></asp:Label>
                <asp:Label ID="lblinforel" runat="server" Font-Bold="False" Width="148px"            Visible="False"></asp:Label>
                <asp:Label ID="lblinfoad4" runat="server" Font-Bold="False" Width="98px"            Visible="False"></asp:Label>
                <asp:Label ID="lblinfoad2" runat="server" Font-Bold="False" Width="104px"            Visible="False"></asp:Label>


        <br />
        <br />
    
    </div>
    </form>
</body>

</html>
