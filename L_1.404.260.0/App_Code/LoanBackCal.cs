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
/// Summary description for LoanBackCal
/// </summary>
public class LoanBackCal
{
    int polno;
    int dod;
    int loanno;
    int lastdue;
    int nextdue;
    int duedate;
    int totmonths;
    int sixmonthparts;
    int backdate;
    int backyy;
    int backmm;
    int duration;
    
    double intrate;
    double lastcap;
    double nextcap;
    double lastint;
    double nextint;
    double capital;
    double interest;
    double backint;

    string backmmstr;

    DataManager dm;
    DateDifference dd;
    DateDifference dd2;
    General gg;

	public LoanBackCal(int Thepolno, int Thedod, int Theloanno)
	{
        try
        {
            dm = new DataManager();
            gg = new General();
            polno = Thepolno;
            dod = Thedod;
            loanno = Theloanno;
            string lplmastsel = "select LMLON, LMITR, LMPDT, LMPCP, LMPIT, LMNID, LMNCP, LMNIT from LPHS.LPLMAST where LMPOL=" + polno + " and (LMSET<>'Y' or LMSET is null) and (LMCD1<>'D' or LMCD1 is null) and LMLON=" + loanno + "";
            if (dm.existRecored(lplmastsel) != 0)
            {
                dm.readSql(lplmastsel);
                OracleDataReader lplmastread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (lplmastread.Read())
                {
                    if (!lplmastread.IsDBNull(0)) { loanno = lplmastread.GetInt32(0); } else { loanno = 0; }
                    if (!lplmastread.IsDBNull(1)) { intrate = lplmastread.GetDouble(1); } else { intrate = 0; }
                    if (!lplmastread.IsDBNull(2)) { lastdue = lplmastread.GetInt32(2); } else { lastdue = 0; }
                    if (!lplmastread.IsDBNull(3)) { lastcap = lplmastread.GetInt32(3); } else { lastcap = 0; }
                    if (!lplmastread.IsDBNull(4)) { lastint = lplmastread.GetDouble(4); } else { lastint = 0; }
                    if (!lplmastread.IsDBNull(5)) { nextdue = lplmastread.GetInt32(5); } else { nextdue = 0; }
                    if (!lplmastread.IsDBNull(6)) { nextcap = lplmastread.GetDouble(6); } else { nextcap = 0; }
                    if (!lplmastread.IsDBNull(7)) { nextint = lplmastread.GetDouble(7); } else { nextint = 0; }
                }
                lplmastread.Close();
                lplmastread.Dispose();

                if (nextdue == 0)
                    backint = NormalInterestCal(lastdue, intrate, dod, lastcap);
                else
                {
                    //duedate = nextdue; //Edited as life req. 17/02/2009
                    duedate = lastdue;
                    capital = lastcap;
                    //backint = nextint;
                    backint = lastint;
                    intrate = intrate / 2;
                    if (dod <= duedate)
                    {
                        dd = new DateDifference(dod, duedate);
                        totmonths = dd.totMonths;
                        sixmonthparts = totmonths / 6;
                        backdate = duedate;
                        //backint = lastint;
                        for (int i = 0; i <= sixmonthparts; i++)
                        {
                            backyy = int.Parse(backdate.ToString().Substring(0, 4));
                            backmm = int.Parse(backdate.ToString().Substring(4, 2)) - 6;
                            if (backmm <= 0)
                            {
                                backmm += 12;
                                backyy--;
                            }
                            backint = ((backint * 100) - (capital * intrate)) / (100 + intrate);
                            if (backmm < 10) { backmmstr = "0" + backmm.ToString(); } else { backmmstr = backmm.ToString(); }
                            backdate = int.Parse(backyy.ToString() + backmmstr + duedate.ToString().Substring(6, 2));
                        }
                        dd2 = new DateDifference(backdate, dod);
                        duration = dd2.Months;
                        if (dd2.Days > 15) { duration++; }
                        double newint = (capital + backint) * duration * intrate / 600;
                        backint += newint;
                        backint = Math.Round(backint, 2);
                    }
                    else
                    {
                        double paidcap = 0, paidint=0;

                        dd = new DateDifference(duedate, dod);
                        totmonths = dd.Months;
                        sixmonthparts = totmonths / 6;
                        for (int i = 0; i < sixmonthparts; i++)
                        {
                            backint += (capital + backint) * intrate / 100;
                        }
                        int remainder = totmonths % 6;
                        if (dd.Days > 15) { remainder++; }
                        backint += (capital + backint) * remainder * intrate / 600;                        

                        #region----------------Chek Paid amount after last due-----------
                        string lplledgesel = "select LCAP, LINT from LPAY.LPLLEDG where LPOL=" + polno + " and LLON=" + loanno + " and (LPDT between " + gg.DateAdjust(duedate, 15, 0, 0) + " and " + dod + ")";
                        if (dm.existRecored(lplledgesel) != 0)
                        {
                            OracleDataReader ledgerreader = dm.oraComm.ExecuteReader();
                            while (ledgerreader.Read())
                            {
                                if (!ledgerreader.IsDBNull(0)) { paidcap = ledgerreader.GetDouble(0); }
                                if (!ledgerreader.IsDBNull(1)) { paidint = ledgerreader.GetDouble(1); }
                            }
                            ledgerreader.Close();
                            if (paidint <= backint)
                            {
                                lastcap -= paidcap;
                                backint -= paidint;
                            }
                            else
                            {
                                paidint -= backint;
                                backint = 0;
                                lastcap -= paidint;
                            }
                            if (lastcap < 0) { lastcap = 0; }
                        }
                        #endregion
                        backint = Math.Round(backint, 2);
                    }
                }
            }
            dm.connclose();
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw Ex;
        }
	}
    public double Loancap
    {
        get { return lastcap; }
        set { lastcap = value; }
    }
    public double Backinterest
    {
        get { return backint; }
        set { backint = value; }
    }
    public int Loanno
    {
        get { return loanno; }
        set { loanno = value; }
    }

    public  double NormalInterestCal(int Startdate,double Intrate, int dod, double cap)
    {
        int years, months, days, sixmonths,i=0;
        double interest=0;
        dd = new DateDifference(Startdate, dod);
        years = dd.Years;
        months = dd.totMonths;
        days = dd.Days;
        if (days > 15) { months++; }
        sixmonths = months / 6;
        while (i < sixmonths)
        {
            interest += (cap + interest) * intrate / 200;
            cap += interest;
            i++;
        }

        int remainder = months % 6;
        //if (days > 15) { remainder++; }
        interest += (cap + interest) * remainder * intrate / 1200;
        interest = Math.Round(interest, 2);
        return interest;
    }
}
