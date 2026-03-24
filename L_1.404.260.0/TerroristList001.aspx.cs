using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TerroristList001 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string URL1 = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
        string URL = "<script type='text/javascript'>window.open('" + URL1 + "/BEELIFE_HEALTH_CLAIMS/Web/Claims/Reports/AMLDesignatedList001.aspx?','_blank');</script>";
        Response.Write(URL);
    }
}