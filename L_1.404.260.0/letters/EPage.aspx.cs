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

public partial class EPage : System.Web.UI.Page
{
    private static string emesege = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        LabMesege.Text = emesege;  
    }

    public static string Messege
    {
        set { emesege = value; }
        get { return emesege; }
    }
}
