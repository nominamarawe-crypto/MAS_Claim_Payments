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
/// Summary description for NumberSeparate
/// </summary>
public class NumberSeparate
{
    private string number;

	public NumberSeparate(string word)
	{
        try
        {
            int i=0;
            string num="", numstr;
            while (i < word.Length)
            {
                numstr = word.ToString().Substring(i, 1);
                if (numstr!=null && (numstr.Equals("0") || numstr.Equals("1") || numstr.Equals("2") || numstr.Equals("3") || numstr.Equals("4") || numstr.Equals(",")))
                {
                    num += numstr;
                }
                else if (numstr != null && (numstr.Equals("5") || numstr.Equals("6") || numstr.Equals("7") || numstr.Equals("8") || numstr.Equals("9")))
                {
                    num += numstr;
                }
                num = num.Trim();
                i++;
            }
            if(!num.Equals(""))
            number = num;//long.Parse(num);
            else
                number = " ";
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
	}
    public string Number
    {
        get { return number; }
        set { number = value; }
    }
}
