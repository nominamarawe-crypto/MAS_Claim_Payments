using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

/// <summary>
/// Summary description for polpersonalread
/// </summary>
public class polpersonalread
{
    private int polno;
    private int pertype;
    private int DOB;

    private string status;
    private string fname, ffname;
    private string sname;
    private string firstlife;
    private string child;
    private string seclife, secsta, secsname, secfname;
    private int secdob, nomdob,cdob=0;
    private string nomname, nomadd1, nomadd2, nomadd3, nomadd4;

    DataManager dm;

	public polpersonalread(int Thepolno)
	{
        try
        {
            dm = new DataManager();
            polno = Thepolno;
            string polpersonalsel = "select PRPERTYPE, STATUS, SURNAME, FULLNAME, DOB from LUND.POLPERSONAL where POLNO=" + polno + "";
            if (dm.existRecored(polpersonalsel) != 0)
            {
                dm.readSql(polpersonalsel);
                OracleDataReader polpersonalread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (polpersonalread.Read())
                {
                    if (!polpersonalread.IsDBNull(0)) { pertype = polpersonalread.GetInt32(0); } else { pertype = 0; }
                    if (!polpersonalread.IsDBNull(1)) { status = polpersonalread.GetString(1); } else { status = ""; }
                    if (!polpersonalread.IsDBNull(2)) { sname = polpersonalread.GetString(2); } else { sname = ""; }
                    if (!polpersonalread.IsDBNull(3)) { fname = polpersonalread.GetString(3); } else { fname = ""; }
                    if (!polpersonalread.IsDBNull(4)) { DOB = polpersonalread.GetInt32(4); } else { DOB = 0; }
                    if (pertype == 1) 
                    { 
                        firstlife = NameCreater(status,fname); 
                        ffname = fname; 
                    } //changed for old child prot claims

                    else if (pertype == 2 || pertype == 4) 
                    { 
                        seclife = NameCreater(status, fname);
                        secdob = DOB; 
                        secsta = status; 
                        secsname = sname; 
                        secfname = fname; 
                    }
                    if (pertype == 4) 
                    { 
                        child = NameCreater(status, fname);
                        cdob = DOB;
                    }
                    //else if (pertype == 9) { nomname = fname; }
                }
                polpersonalread.Close();
                polpersonalread.Dispose();
            }
            string nomineesel = "select NOMNAM, NOMDOB, NOMAD1, NOMAD2, NOMAD3, NOMAD4 from LUND.NOMINEE where POLNO=" + polno + " and NOMNO=1";
            if (dm.existRecored(nomineesel) != 0)
            {
                dm.readSql(nomineesel);
                OracleDataReader nomineereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (nomineereader.Read())
                {
                    if (!nomineereader.IsDBNull(0)) { nomname = nomineereader.GetString(0); } else { nomname = ""; }
                    if (!nomineereader.IsDBNull(1)) { nomdob = nomineereader.GetInt32(1); } else { nomdob = 0; }
                    if (!nomineereader.IsDBNull(2)) { nomadd1 = nomineereader.GetString(2); } else { nomadd1 = ""; }
                    if (!nomineereader.IsDBNull(3)) { nomadd2 = nomineereader.GetString(3); } else { nomadd2 = ""; }
                    if (!nomineereader.IsDBNull(4)) { nomadd3 = nomineereader.GetString(4); } else { nomadd3 = ""; }
                    if (!nomineereader.IsDBNull(5)) { nomadd4 = nomineereader.GetString(5); } else { nomadd4 = ""; }
                }
                nomineereader.Close();
                nomineereader.Dispose();
            }
            if (firstlife == null)
            {
                string phnamesel = "select PNSTA||' '||PNINT||' '||PNSUR from LPHS.PHNAME where PNPOL="+polno+"";
                if (dm.existRecored(phnamesel) != 0)
                {
                    dm.readSql(phnamesel);
                    OracleDataReader phnamereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (phnamereader.Read())
                    {
                        if (!phnamereader.IsDBNull(0)) { firstlife = phnamereader.GetString(0); } else { firstlife = ""; }
                    }
                    phnamereader.Close();
                    phnamereader.Dispose();
                }
            }
        }
        catch(Exception Ex)
        {
            throw Ex;
        }
	}

    public string NameCreater(string status, string fname)
    {
        string name = "";
        int isStatus = 0;
        if (status != null)
        {
            string[] sta = fname.Split('.');
            string stat = (sta[0].ToUpper()).Trim();
            switch (stat)
            {
                case "MR":
                    { isStatus = 1; break; }
                case "MASTER":
                    { isStatus = 1; break; }
                case "MRS":
                    { isStatus = 1; break; }
                case "MISS":
                    { isStatus = 1; break; }
                default:
                    { isStatus = 0; break; }
            }

            if (isStatus != 0)
            {
                name = fname;
            }
            else
            {
                name = status + " " + fname;
            }
        }
        else
        {
            name = fname;
        }

        return name;
    }

    public string Firstlife
    {
        get { return firstlife; }
        set { firstlife = value; }
    }
    public string FirstlifeFullname
    {
        get { return ffname; }
        set { ffname = value; }
    }
    public string Seclife
    {
        get { return seclife; }
        set { seclife = value; }
    }
    public string Child
    {
        get { return child; }
        set { child = value; }
    }
    public string Nomname
    {
        get { return nomname; }
        set { nomname = value; }
    }
    public int Secdob
    {
        get { return secdob; }
        set { secdob = value; }
    }
    public string Secsta
    {
        get { return secsta; }
        set { secsta = value; }
    }
    public string Secsname
    {
        get { return secsname; }
        set { secsname = value; }
    }
    public string Secfname
    {
        get { return secfname; }
        set { secfname = value; }
    }
    public int Nomdob
    {
        get { return nomdob; }
        set { nomdob = value; }
    }
    
    public int Cdob
    {
        get { return cdob; }
        set { cdob = value; }
    }
    public string Nomadd1
    {
        get { return nomadd1; }
        set { nomadd1 = value; }

    }
    public string Nomadd2
    {
        get { return nomadd2; }
        set { nomadd2 = value; }

    }
    public string Nomadd3
    {
        get { return nomadd3; }
        set { nomadd3 = value; }

    }
    public string Nomadd4
    {
        get { return nomadd4; }
        set { nomadd4 = value; }

    }
}
