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
/// Summary description for BankBranches
/// </summary>
public class BankBranches
{
    private int branchCode = 0;
    private string branchName = string.Empty;

	public BankBranches()
	{		
	}

    public int BranchCode
    {
        get
        {
            return branchCode;
        }
        set
        {
            branchCode = value;
        }
    }

    public string BranchName
    {
        get
        {
            return branchName;
        }
        set
        {
            branchName = value;
        }
    }
        
}
