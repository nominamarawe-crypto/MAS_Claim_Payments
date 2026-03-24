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
/// Summary description for surrDet
/// </summary>
public class surrDet
{
    private  int polno;
    private  int authDate;
    private  int refno;
    private  int branch;
    private  int surryear;
    
    private int reqdate;
    private string polstat;
    private double surrval;
    private double loancap;
    private double loanint;
    private double WOamt;
    private double netamt;

    private bool ch1;
    private bool ch2;
    private bool ch3;
    private bool ch4;
    private bool ch5;
    private bool ch6;
    private bool ch7;

    public int Polno {
        get { return polno; }
        set { polno = value; }
    }
    public int AuthDate {
        get { return authDate; }
        set { authDate = value; }
    }
    public int Refno {
        get { return refno; }
        set { refno = value; }
    }
    public int Branch {
        get { return branch; }
        set { branch = value; }
    }
    public int Surryear {
        get { return surryear; }
        set { surryear = value; }
    }

    //**************************

    public int Reqdate {
        get { return reqdate; }
        set { reqdate = value; }
    }
    public string Polstat {
        get { return polstat; }
        set { polstat = value; }
    }
    public double Surrval {
        get { return surrval; }
        set { surrval = value; }
    }
    public double Loancap {
        get { return loancap; }
        set { loancap = value; }
    }
    public double Loanint {
        get { return loanint; }
        set { loanint = value; }
    }
    public double wOamt {
        get { return WOamt; }
        set { WOamt = value; }
    }
    public double Netamt {
        get { return netamt; }
        set { netamt = value; }
    }

    public bool Ch1{
        get { return ch1; }
        set { ch1 = value; }
    }
    public bool Ch2{
        get { return ch2; }
        set { ch2 = value; }
    }
    public bool Ch3{
        get { return ch3; }
        set { ch3 = value; }
    }
    public bool Ch4{
        get { return ch4; }
        set { ch4 = value; }
    }
    public bool Ch5{
        get { return ch5; }
        set { ch5 = value; }
    }
    public bool Ch6{
        get { return ch6; }
        set { ch6 = value; }
    }
    public bool Ch7 {
        get { return ch7; }
        set { ch7 = value; }
    }




}
