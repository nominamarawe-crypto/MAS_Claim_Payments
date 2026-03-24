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
/// Summary description for AppCode
/// </summary>
public class AppCode
{
    public bool dateValid(string theDate)
    {
        bool valid = true;
        int year = int.Parse(theDate.Substring(0, 4));
        int month = int.Parse(theDate.Substring(4, 2));
        int day = int.Parse(theDate.Substring(6, 2));

        if ((year < 1965) || (year > 2100)) { valid = false; }
        if ((month <= 0) || (month > 12)) { valid = false; }
        if ((day <= 0) || (day > 31)) { valid = false; }

        if (((month == 2) || (month == 4) || (month == 6) || (month == 9) || (month == 8) || (month == 11)) && (day == 31)) { valid = false; }

        else if ((month == 2) && (day == 30) || (day == 31)) { valid = false; }

        else if ((!((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))) && (month == 2) && (day == 29)) { valid = false; }

        return valid;
    }
}
