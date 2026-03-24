using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class testpage : System.Web.UI.Page
{
    BankDetailsBreak bdb;
    string name1, name2;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Int32.MaxValue.ToString());
        //Response.Write("        ");
        //Response.Write(Int64.MaxValue.ToString());
        try
        {
            bdb = new BankDetailsBreak("Kandurata Sanwardthrakireeme Bank", "Angunukolapelessa Postal Branch", "82562566256 2663521", "MR. WIHARA WATHTHE GEDARA UDAHA WALAWWE LOKU");
            name1 = bdb.Hname1;
            name2 = bdb.Hname2;
        }
        catch (Exception Ex)
        {
            
        }

    }
}
