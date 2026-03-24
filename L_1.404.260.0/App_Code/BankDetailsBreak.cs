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
/// Summary description for BankDetailsBreak
/// </summary>
public class BankDetailsBreak
{
    private string hname21, hname11, hname1, hname2, totname;
	public BankDetailsBreak(string bnknam, string bnkbr, string acctno, string payeenam)
	{
        try
        {
            if (bnkbr.Trim() != "")
            {
                bnkbr = ", " + bnkbr;
            }
            string AccNo = acctno;
            if (AccNo.Trim() != "")
            {
                acctno = ", A/C-NO " + acctno;
            }
            
            hname1 = bnknam.ToUpper() + bnkbr.ToUpper() + acctno;

            hname2 = payeenam.ToUpper();
            totname = hname1 + " " + hname2;
            if (totname.Length>=135)
            {
                throw new Exception("Your bank details are too long to enter!");
            }
            if (hname1.Length >= 70 || hname1.Length == 0 || hname2.Length >= 65)
            {
                int length = totname.Length;
                //hname11 = hname1;
                if (length > 70)
                {
                    hname1 = totname.Substring(0, 70);
                    hname2 = totname.Substring(70, length - 70);
                    this.Filter(hname1, hname2, 70);
                }
                else
                {
                    hname1 = totname;
                    hname2 = "";
                }
                //hname21 = hname2;
                //hname2 = hname11.Substring(70, 84);               
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
	}
    public void Filter(string name1, string name2, int length)
    {
        //string temphname1;
        for (int i = length; i > 0; i--)
        {
            if (name1.Substring(i - 1, 1).Equals(" ")) 
            {
                //temphname1 = hname11;
                hname1 = name1.Substring(0, i-1);
                hname2 = name1.Substring(i, length - i) + name2;
                break;
            }            
            //charact = name.Substring(i-1, 1);
        }
        if (hname2.Length > 65)
        {
            hname1 = name1.Substring(0, 69) + "-";
            hname2 = name1.Substring(69, 1) + name2;
        }
    }
    public string Hname1
    {
        get { return hname1; }
        set { hname1 = value; }
    }
    public string Hname2
    {
        get { return hname2; }
        set { hname2 = value; }
    }
}
