<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dthoutreport.aspx.cs" Inherits="dthoutreport" %>
<%@ PreviousPageType VirtualPath="~/Outstanding DeathReport/dthoutlist002.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script  type="text/javascript" language="javascript">
function cForm1(form)
{
 win=window.open('','myWin',"toolbars=1,scrollbars=1"); 
 form1.target='myWin';
 form1.action='dtoutreport.aspx';
}


}

function btnprint_onclick() {

}


}



</script>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center; font-family: Times New Roman;" onload="window.print()">
    <form id="form1" runat="server">
    <div style="text-align: left">
        <strong><span> <span style="font-size: 14pt">
            </span><strong><span>
                <br />
                <br />
                <br />
                <br />
                <br />
                <table>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 618px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 173px;">
                        </td>
                        <td style="width: 618px; height: 173px;">
                            <span style="font-family: Trebuchet MS">
                            To &nbsp; &nbsp; &nbsp;&nbsp; : &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                &nbsp;SENIOR MANAGER LIFE<br />
                            <br />
                            THROUGH: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ASSISTANT&nbsp; MANAGERESS(LIFE
                            CLAIMS)<br />
                            <br />
                            FOR THE MONTHLY ENDED:</span><asp:Literal ID="lblEndDate" runat="server"></asp:Literal><br />
                            <br />
                            <span style="font-family: Trebuchet MS">
                            <span style="text-decoration: underline">
                            Death Claims Details<br />
                            </span>
                            <br />
                            </span>
                        </td>
                        <td style="width: 100px; height: 173px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 618px">
        <table border="1" cellpadding="0" cellspacing="0" style="width: 617px; text-align: center">
            <tr>
                <td align="left" bgcolor="silver" style="width: 249px; height: 40px">
                    <strong><span style="font-family: Trebuchet MS">Reporting Stage</span></strong></td>
                <td align="right" bgcolor="silver" style="width: 203px; height: 40px">
                    <strong><span style="font-family: Trebuchet MS">No Of Claims</span>&nbsp;</strong></td>
                <td align="right" bgcolor="silver" style="width: 215px; height: 40px">
                    <strong> <span style="font-family: Trebuchet MS">Amount Rs</span></strong></td>
            </tr>
            <tr>
                <td align="left" bgcolor="linen" style="width: 249px; height: 21px">
                </td>
                <td align="right" bgcolor="linen" style="width: 203px; height: 21px">
                </td>
                <td align="right" bgcolor="linen" style="width: 215px; height: 21px">
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="linen" style="width: 249px; height: 21px">
                    <strong><span style="font-family: Trebuchet MS">Death Claims Received</span></strong></td>
                <td align="right" bgcolor="linen" style="width: 203px; height: 21px">
                    <asp:Literal ID="lblNoReciv" runat="server"></asp:Literal></td>
                <td align="right" bgcolor="linen" style="width: 215px; height: 21px">
                    <asp:Literal ID="lblRecivAmt" runat="server"></asp:Literal>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="linen" style="width: 249px; height: 17px">
                    <strong><span style="font-family: Trebuchet MS">Death Claims Paid</span></strong></td>
                <td align="right" bgcolor="linen" style="width: 203px; height: 17px">
                    <asp:Literal ID="lblnoPaid" runat="server"></asp:Literal></td>
                <td align="right" bgcolor="linen" style="width: 215px; height: 17px">
                    <asp:Literal ID="lblPaid" runat="server"></asp:Literal>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" bgcolor="#faf0e6" style="width: 249px; height: 21px">
                    <strong><span style="font-family: Trebuchet MS">Death Claims Rejected</span></strong></td>
                <td align="right" bgcolor="#faf0e6" style="width: 203px; height: 21px">
                    <asp:Literal ID="lblNoRejct" runat="server"></asp:Literal></td>
                <td align="right" bgcolor="#faf0e6" style="width: 215px; height: 21px">
                    <asp:Literal ID="lblRejctAmt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="left" bgcolor="#faf0e6" style="width: 249px; height: 21px">
                    <strong><span style="font-family: Trebuchet MS">Death Claims Lapse</span></strong></td>
                <td align="right" bgcolor="#faf0e6" style="width: 203px; height: 21px">
                    <asp:Literal ID="lblNoLaps" runat="server"></asp:Literal></td>
                <td align="right" bgcolor="#faf0e6" style="width: 215px; height: 21px">
                    <asp:Literal ID="lblLapsAmt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="left" bgcolor="#faf0e6" style="width: 249px; height: 21px">
                    <strong><span style="font-family: Trebuchet MS">Death Claims Outstanding</span></strong></td>
                <td align="right" bgcolor="#faf0e6" style="width: 203px; height: 21px">
                    <asp:Literal ID="lblNoOustand" runat="server"></asp:Literal></td>
                <td align="right" bgcolor="#faf0e6" style="width: 215px; height: 21px">
                    <asp:Literal ID="lblOutstdAmt" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="left" bgcolor="#faf0e6" style="width: 249px; height: 21px">
                </td>
                <td align="right" bgcolor="#faf0e6" style="width: 203px; height: 21px">
                </td>
                <td align="right" bgcolor="#faf0e6" style="width: 215px; height: 21px">
                </td>
            </tr>
        </table>
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 125px">
                        </td>
                        <td style="width: 618px; height: 125px">
                            <span style="font-family: Trebuchet MS">
                            DATE:</span><asp:Literal ID="lblCurrentDate" runat="server"></asp:Literal><br />
                            <br />
                            <br />
                            <span style="font-family: Trebuchet MS">
                            PREPAIRED BY:</span>......................................................<br />
                            <br />
                            <br />
                            <span style="font-family: Trebuchet MS">
                            CHECKED BY :</span>........................................................<br />
                            <br />
                        </td>
                        <td style="width: 100px; height: 125px">
                        </td>
                    </tr>
                </table>
                
            </span></strong>
        </span></strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
    
    </form>
</body>

</html>
