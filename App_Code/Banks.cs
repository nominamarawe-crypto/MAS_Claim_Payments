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
/// Summary description for Banks
/// </summary>
public class Banks
{
    private int bankCode = 0;
    private string bankName = string.Empty;

	public Banks()
	{		
	}

    public int BankCode
    {
        get
        {
            return bankCode;
        }
        set
        {
            bankCode = value;
        }
    }

    public string BankName
    {
        get
        {
            return bankName;
        }
        set
        {
            bankName = value;
        }
    }
}
