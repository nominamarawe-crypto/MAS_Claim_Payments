using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SJyrscal
/// </summary>
public class SJyrscal
{
    private int stdt,endt;
    private double styrs;

    public SJyrscal(int Thestdt, int Theendt)
	{
        int days;
        stdt = Thestdt;
        endt = Theendt;
        datescount dtcount = new datescount(stdt, endt);
        days = dtcount.Days;
        styrs = days / 365.25;
        styrs = Math.Round(styrs, 2);        
	}
    public double Yearsfac
    {
        get { return styrs; }
        set { styrs = value; }
    }    
}
