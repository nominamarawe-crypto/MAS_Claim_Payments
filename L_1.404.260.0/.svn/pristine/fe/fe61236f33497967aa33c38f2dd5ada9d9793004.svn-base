<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileScanningReport002.aspx.cs" Inherits="FileScanningReport002" %>

<%@ PreviousPageType VirtualPath="~/FileScanningReport001.aspx" %>
<%@ Reference Page="~/EPage.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sri Lanka Insurance - File Scanning Requested Report</title>
    <style type="text/css">
        .ScanFileDetails {
            width: 680px;
            border-collapse: collapse;
        }

            .ScanFileDetails td, th {
                border: 1px solid black;
                text-align: center;
                font-size: 12px;
            }

        .textAlign {
            text-align: left !important;
        }
    </style>
    <script src="JavaScript/FormValidation.js" type="text/javascript" language="javascript"></script>

    <script type="text/javascript">    

        function test(source, arguments) {

            if (!IsNumeric(arguments.Value))
            { arguments.IsValid = false; }

            else
            { arguments.IsValid = true; }
        }

        function MM_goToURL() { //v3.0
            var i, args = MM_goToURL.arguments; document.MM_returnValue = false;
            for (i = 0; i < (args.length - 1); i += 2) eval(args[i] + ".location='" + args[i + 1] + "'");
        }

    </script>
    <script language="javascript" type="text/javascript">


        function printDiv(printPanel) {
            document.getElementById('btnprint').style.visibility = 'hidden';
            document.getElementById('HyperLink1').style.visibility = 'hidden';
            document.getElementById('lblmessage').style.visibility = 'hidden';

            var printContents = document.getElementById(printPanel).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
            document.getElementById('btnprint').style.visibility = 'visible';
            document.getElementById('HyperLink1').style.visibility = 'visible';
            document.getElementById('lblmessage').style.visibility = 'visible';
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <strong><span style="font-size: 14pt; font-family: Trebuchet MS"></span></strong><span style="font-size: 12pt"><span style="font-family: Trebuchet MS">
                <strong>
                    <div id="printPanelDiv">
                        <table style="font-size: 10pt; width: 659px; font-family: 'Trebuchet MS'">
                            <tr>
                                <td colspan="5" style="height: 19px; background-color: #f0f0f0"></td>
                            </tr>

                            <tr>
                                <td align="center" colspan="5" style="height: 19px; background-color: #ffffff">
                                    <span style="font-size: 14pt">Sri Lanka Insurance<br />
                                    </span><span style="font-size: 12pt"><span style="font-family: Trebuchet MS"><strong>File Scanning Requested Report</strong></span></span></td>
                            </tr>
                            <tr>
                                <td colspan="5" style="height: 19px; background-color: #f0f0f0"></td>
                            </tr>
                            <tr>
                                <td style="width: 20px; height: 20px"></td>
                                <td style="width: 80px; height: 20px; text-align: left">
                                    <span style="font-size: 10pt">Requested Date</span></td>
                                <td style="width: 92px; height: 20px; text-align: left">
                                    <span style="font-size: 10pt">:</span><asp:Label ID="lblRequestedDate" runat="server" Font-Size="10pt"
                                        Width="83px"></asp:Label></td>
                                <td style="width: 158px; height: 20px; text-align: left">
                                    <span style="font-size: 10pt">Requested Branch</span></td>
                                <td style="width: 158px; height: 20px; text-align: left">:<asp:Label ID="lblRequestedBranch" runat="server" Font-Size="10pt"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 80px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 92px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 19px; background-color: #f0f0f0"></td>
                            </tr>
                            <tr>
                                <td style="width: 20px; height: 20px"></td>
                                <td colspan="4" style="height: 20px; text-align: left">
                                    <asp:Table ID="tblScanRequestedFiles" runat="server" Font-Bold="False" Font-Size="12pt" Width="600px">
                                    </asp:Table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 80px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 92px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 19px; background-color: #f0f0f0"></td>
                            </tr>
                            <tr>
                                <td style="width: 20px; height: 20px"></td>
                                <td colspan="4" style="height: 20px">
                                    <asp:Label ID="lblmessage" runat="server" ForeColor="#CC0066" Width="431px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 80px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 92px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 19px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 19px; background-color: #f0f0f0"></td>
                            </tr>
                            <tr>
                                <td style="width: 20px; height: 20px"></td>
                                <td style="width: 80px; height: 20px"></td>
                                <td style="width: 92px; height: 20px"></td>
                                <td style="width: 158px; height: 20px">
                                    <asp:Button ID="btnprint" runat="server" Text="--Print Details--"
                                         OnClientClick="printDiv('printPanelDiv')" Font-Bold="False" Font-Names="Trebuchet MS"/>
                                </td>
                                <td style="width: 158px; height: 20px; text-align: left">
                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Blue"
                                        NavigateUrl="~/FileScanningReport001.aspx"><<--Back</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; background-color: #f0f0f0"></td>
                                <td style="width: 80px; height: 20px; background-color: #f0f0f0"></td>
                                <td style="width: 92px; height: 20px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 20px; background-color: #f0f0f0"></td>
                                <td style="width: 158px; height: 20px; background-color: #f0f0f0"></td>
                            </tr>
                        </table>
                    </div>
                </strong></span></span>

        </div>
    </form>
</body>
</html>
