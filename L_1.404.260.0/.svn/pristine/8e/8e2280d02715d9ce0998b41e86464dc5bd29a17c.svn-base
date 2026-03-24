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
/// Summary description for datescount
/// </summary>
public class datescount
{
    private int stdt, endt,dayfac;
    private int days;

	public datescount(int Thestdate, int Theenddt)
	{
        stdt = Thestdate;
        endt = Theenddt;

        int stmonth;
        int enmonth;
        int tempmonth;

        stmonth = int.Parse(stdt.ToString().Substring(4, 2));
        enmonth = int.Parse(endt.ToString().Substring(4, 2));

        tempmonth = stmonth;

        while(stmonth<=enmonth)
        {
            dayfac = this.Dayfac(stmonth);
            if (stmonth==tempmonth) { days = dayfac - int.Parse(stdt.ToString().Substring(6, 2))+1; }
            else if (stmonth == enmonth) { days += int.Parse(endt.ToString().Substring(6, 2)); }
            else { days += dayfac; }
            stmonth++;
        }
	}
    int Dayfac(int Month)
    {
        int factor;
        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
        {
            factor = 31;
        }
        else if (Month == 2)
        {
            factor = 28;
        }
        else
        {
            factor = 30;
        }
        return factor;
    }
    public int Days
    {
        get { return days; }
        set { days = value; }
    }
}
