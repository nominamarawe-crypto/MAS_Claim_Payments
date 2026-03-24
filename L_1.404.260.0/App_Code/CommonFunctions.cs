using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public class CommonFunctions : IDisposable
{
	public CommonFunctions() 
	{
		//
		// TODO: Add constructor logic here
		//
    }
    void IDisposable.Dispose() { }
    public string ZeroFill(int NoToBeFormat, int neededLength)
    {
        int LengthOfNo = NoToBeFormat.ToString().Length;
        int numOfZero = neededLength - LengthOfNo;
        string temp = "0";
        if (numOfZero != 0)
        {
            for (int i = 1; i < (numOfZero); i++)
            {
                temp = temp + "0";
            }
        }
        if (numOfZero != 0)
            return temp + NoToBeFormat.ToString();
        else
            return NoToBeFormat.ToString();
    }
    public string NumFilter(string numberToBeFilter)
    {
        if (numberToBeFilter != "")
        {
            string numberPart = "";
            string numberSet = "0123456789";
            for (int i = 0; i < numberToBeFilter.Length; i++)
            {
                char a = char.Parse(numberToBeFilter.Substring(i, 1));
                if (numberSet.IndexOf(a) != -1)
                    numberPart = numberPart + a;
            }
            return numberPart;
        }
        else
            return "0";
    }
}
