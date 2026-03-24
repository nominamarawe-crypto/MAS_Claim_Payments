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
/// Summary description for ControlData
/// </summary>
public class ControlData
{
	//lsusuf, lsubrn, lsuyear, lsupol
    private  int lsusuf;
    private int lsubrn;
    private int lsuyear;
    private int lsupol;

    public  ControlData(int Lsusuf, int Lsubrn, int Lsuyear, int Lsupol)
    {
        this.lsusuf = Lsusuf;
        this.lsubrn = Lsubrn;
        this.lsuyear = Lsuyear;
        this.lsupol = Lsupol;
    }

    public int Lsusuf 
    {
        get { return this.lsusuf; }
        set {this.lsusuf = value; }
    }

    public int Lsubrn
    {
        get { return this.lsubrn; }
        set { this.lsubrn = value; }
    }
    public int Lsuyear
    {
        get { return this.lsuyear; }
        set { this.lsuyear = value; }
    }
    public int Lsupol
    {
        get { return this.lsupol; }
        set { this.lsupol = value; }
    }


}
