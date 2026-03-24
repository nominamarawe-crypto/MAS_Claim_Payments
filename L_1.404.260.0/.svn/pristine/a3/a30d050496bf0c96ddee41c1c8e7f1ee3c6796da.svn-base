using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

[Serializable()]
public class vouPrintFields
{
    private string vouno = "";
    private string payee = "";
    private string payeeName = "";
    private double share = 0;
    private double exgraciaShare = 0;

    public vouPrintFields(string theVouno, string thePayee, string thePayeeName, double theShare, double exgrshare) 
    {
        this.vouno = theVouno;
        this.payee = thePayee;
        this.payeeName = thePayeeName;
        this.share = theShare;
        this.exgraciaShare = exgrshare;
	}

    public string Vouno
    {
        get { return this.vouno; }
        set { this.vouno = value; }
    }
    public string Payee
    {
        get { return this.payee; }
        set { this.payee = value; }
    }
    public string PayeeName
    {
        get { return this.payeeName; }
        set { this.payeeName = value; }
    }
    public double Share
    {
        get { return this.share; }
        set { this.share = value; }
    }
    public double ExgraciaShare
    {
        get { return this.exgraciaShare; }
        set { this.exgraciaShare = value; }
    }
}
