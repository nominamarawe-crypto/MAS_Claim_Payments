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

public class SwarnaJayanthi
{
    private long polno;
    private int dtofcal;
    //private int days;
    //private int sjyear;
    private int covernum;
    private int mode;
    private int commence;
    private int term, refdt;
    private int sjstartdt;

    //private double stinter;
    //private double endinter;
    private double intfactor;
    //private double styrs;
    //private double enyrs;
    private double premium;
    private int COM;
    //private double roexamt, rhexamt, rdisconamt;

    private double sjamt;
    private double sjsumass;

    private string mos;
    
    //private string roexyn,rhexyn,rdisconyn;

    DataManager dm;
    SJyrscal yearsfacobj;
    IntRate intrateobj;

	public SwarnaJayanthi(long Thepolno, int Thedtofcal, string MOS, int Therefdt)
	{
        polno = Thepolno;
        dtofcal = Thedtofcal;
        mos = MOS;
        refdt = Therefdt;
        try
        {
            dm = new DataManager();
            if (mos.Equals("M")) { covernum = 10; }
            else if (mos.Equals("S")) { covernum = 110; }
            else if (mos.Equals("2")) { covernum = 210; }

            string sjcoveryesno = "select RMODE, RPRM, ROEX, RHEX, RDISCON, RCOMDAT, RSUMAS from LUND.RCOVER where RPOL=" + polno + " and RCOVR=" + covernum + "";
            if (dm.existRecored(sjcoveryesno) != 0)
            {
                dm.readSql(sjcoveryesno);
                OracleDataReader sjamtreader = dm.oraComm.ExecuteReader();
                while (sjamtreader.Read())
                {
                    if (!sjamtreader.IsDBNull(0)) { mode = sjamtreader.GetInt32(0); } else { mode = 0; }
                    if (!sjamtreader.IsDBNull(1)) { premium = sjamtreader.GetDouble(1); } else { premium = 0; }
                    //if (!sjamtreader.IsDBNull(2)) { roexyn = sjamtreader.GetString(2); } else { roexyn = ""; }
                    //if (!sjamtreader.IsDBNull(3)) { rhexyn = sjamtreader.GetString(3); } else { rhexyn = ""; }
                    //if (!sjamtreader.IsDBNull(4)) { rdisconyn = sjamtreader.GetString(4); } else { rdisconyn = ""; }
                    if (!sjamtreader.IsDBNull(5)) { commence = sjamtreader.GetInt32(5); } else { commence = 0; }
                    if (!sjamtreader.IsDBNull(6)) { sjsumass = sjamtreader.GetDouble(6); } else { sjsumass = 0; }
                }
                sjamtreader.Close();
                //sjamtreader.Dispose();

                #region//Commented as Life Dep. opinions. No loadings will be refunded with SJ
                //if (roexyn.Equals("Y"))
                //{
                //    string roexsel = "select OEAMT from LUND.ROCCEX where RPOL=" + polno + " and RCOVR="+covernum+"";
                //    dm.readSql(roexsel);
                //    OracleDataReader roccexreader=dm.oraComm.ExecuteReader();
                //    roccexreader.Read();
                //    if (!roccexreader.IsDBNull(0)) { roexamt = roccexreader.GetDouble(0); } else { roexamt = 0; }
                //    roccexreader.Close();
                //}
                //if (rhexyn.Equals("Y"))
                //{
                //    string rhesel = "select HEAMT from LUND.RHELEX where RPOL="+polno+" and RCOVR="+covernum+"";
                //    dm.readSql(rhesel);
                //    OracleDataReader rhereader = dm.oraComm.ExecuteReader();
                //    rhereader.Read();
                //    if (!rhereader.IsDBNull(0)) { rhexamt = rhereader.GetDouble(0); } else { rhexamt = 0; }
                //    rhereader.Close();
                //}
                //if (rdisconyn.Equals("Y"))
                //{
                //    string rdisconsel = "select DISAMT from LUND.RDISCON where RPOL=" + polno + " and RCOVR=" + covernum + "";
                //    dm.readSql(rdisconsel);
                //    OracleDataReader rdisconreader = dm.oraComm.ExecuteReader();
                //    rdisconreader.Read();
                //    if (!rdisconreader.IsDBNull(0)) { rdisconamt = rdisconreader.GetDouble(0); } else { rdisconamt = 0; }
                //    rdisconreader.Close();
                //}
                //premium += roexamt + rhexamt - rdisconamt;

                //lpolhisread comenceterm = new lpolhisread(polno);
                //commence= comenceterm.Commence;
                //term = comenceterm.Term;
                #endregion
                
                sjstartdt = int.Parse(Convert.ToString(int.Parse(commence.ToString().Substring(0, 4)) + 2) + commence.ToString().Substring(4, 4));
                if (refdt == 0 && sjstartdt > dtofcal) { sjamt = 0; }
                else
                {
                    int pointdt;
                    int ledgermod;
                    int ledgerdue;
                    //double ledgerprem;
                    int lastdue;
                    double endyrint;
                    double endyearsfac;
                    int pacod;


                    if (refdt == 0) { pointdt = commence; } else { pointdt = refdt; }
                    yearsfacobj = new SJyrscal(int.Parse(dtofcal.ToString().Substring(0, 4) + "0101"), dtofcal);
                    endyearsfac = yearsfacobj.Yearsfac;
                    intrateobj = new IntRate(int.Parse(dtofcal.ToString().Substring(0, 4)));
                    endyrint = intrateobj.Rate;
                    lastdue = int.Parse(dtofcal.ToString().Substring(0, 6));

                    #region---------Checking Ledger Entries----------------------

                    string ledgersel = "select LLDUE, LLMOD from LCLM.LEDGER where LLPOL=" + polno + " and LLDUE>=" + pointdt.ToString().Substring(0, 6) + " and LLDUE<" + lastdue + "";
                    if (dm.existRecored(ledgersel) != 0)
                    {
                        dm.readSql(ledgersel);
                        OracleDataReader ledgerread = dm.oraComm.ExecuteReader();
                        while (ledgerread.Read())
                        {
                            if (!ledgerread.IsDBNull(0)) { ledgerdue = ledgerread.GetInt32(0); } else { ledgerdue = 0; }
                            if (!ledgerread.IsDBNull(1)) { ledgermod = ledgerread.GetInt32(1); } else { ledgermod = 0; }
                            sjamt += Sjcalculation(ledgermod, ledgerdue, mode, premium, dtofcal, endyrint, endyearsfac);
                        }
                        ledgerread.Close();
                        //ledgerread.Dispose();
                    }
                    #endregion

                    #region---------Checking Unsettled dues----------commented as per life dept.------------
                    //string demandsel = "select PDDUE, PDPAC from LPHS.DEMAND where PDPOL=" + polno + " and (PDCOD='1' or PDCOD='2' or PDCOD='3') and PDDUE>=" + pointdt.ToString().Substring(0, 6) + " and PDDUE<=" + lastdue + "";
                    //if (dm.existRecored(demandsel) != 0)
                    //{
                    //    dm.readSql(demandsel);
                    //    OracleDataReader demandreader = dm.oraComm.ExecuteReader();
                    //    while (demandreader.Read())
                    //    {
                    //        if (!demandreader.IsDBNull(0)) { ledgerdue = demandreader.GetInt32(0); } else { ledgerdue = 0; }
                    //        if (!demandreader.IsDBNull(1)) { pacod = demandreader.GetInt32(1); } else { pacod = 0; }
                    //        ledgermod = this.Modcal(pacod);
                    //        sjamt += Sjcalculation(ledgermod, ledgerdue, mode, premium, dtofcal, endyrint, endyearsfac);
                    //    }
                    //    demandreader.Close();
                    //}
                    #endregion

                    #region------------amt. to policy complete year-------commented as per life dept.------
                    //int calyr=int.Parse(dtofcal.ToString().Substring(0, 4));                    
                    //int nextpolandt, months;
                    //double amount;
                    //int monthfac;
                    //if (int.Parse(calyr.ToString() + commence.ToString().Substring(4, 4)) < dtofcal)
                    //{
                    //    calyr++;
                    //}
                    //nextpolandt = int.Parse(calyr.ToString() + commence.ToString().Substring(4, 4));
                    //DateDifference dtdiff = new DateDifference(dtofcal, nextpolandt);
                    //months = dtdiff.Months;

                    //if (mode == 1) { amount = 0; }
                    //else if (mode == 2 && months >= 6) { amount = premium; }
                    //else if (mode == 3 && months >= 3) { monthfac = months / 3; amount = premium * monthfac; }
                    //else if (mode == 4) { amount = premium * months; }
                    //else { amount = 0; }
                    //sjamt += amount;
                    #endregion

                }
                sjamt *= 0.5;
                sjamt = Math.Round(sjamt,2);
            }
            else
            {
                sjamt = 0;
            }
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw (Ex);
        }
	}

    public double InterestFactor(int styr, int enyr)
    {
        string intrratesel = "select RATE, YEAR from LPHS.SJ_INTEREST_RATES where YEAR>" + styr + " and YEAR<" + enyr + "";
        intfactor = 1;
        if (dm.existRecored(intrratesel) != 0)
        {
            int Year;
            double rate;
            dm.readSql(intrratesel);
            OracleDataReader interestreader = dm.oraComm.ExecuteReader();            
            while (interestreader.Read())
            {
                if (!interestreader.IsDBNull(0)) { rate = interestreader.GetDouble(0); } else { rate = 0; }
                if (!interestreader.IsDBNull(1)) { Year = interestreader.GetInt32(1); } else { Year = 0; }
                //if (Year == int.Parse(pointdt.ToString().Substring(0, 4))) { stinter = rate / 100; }
                //else if (Year == int.Parse(dtofcal.ToString().Substring(0, 4))) { endinter = rate / 100; }
                intfactor *= 1 + (rate / 100);
            }
            interestreader.Close();
            //interestreader.Dispose();
        }
        return intfactor;
    }    

    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2)
        {
            month = "0" + month;
        }
        if (day.Length < 2)
        {
            day = "0" + day;
        }
        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;        
        return datetime;
    }

    public double Premium(int pmode, double amt)
    {
        int multiplier;
        double annualprem;

        if (pmode == 1) { multiplier = 1; }
        else if (pmode == 2) { multiplier = 2; }
        else if (pmode == 3) { multiplier = 4; }
        else { multiplier = 12; }

        annualprem = amt * multiplier;
        return annualprem;
    }
    public double Repremium(int rmode, double amt)
    {
        int divider;
        double prem;

        if (rmode == 1) { divider = 1; }
        else if (rmode == 2) { divider = 2; }
        else if (rmode == 3) { divider = 4; }
        else { divider = 12; }

        prem = amt / divider;
        return prem;
    }

    public int Modcal(int Pacod)
    {
        int mmode;
        if (Pacod <= 12) { mmode = 1; }
        else if (Pacod >= 21 && Pacod <= 26) { mmode = 2; }
        else if (Pacod == 31 || Pacod == 32 || Pacod == 33) { mmode = 3; }
        else { mmode = 4; }

        return mmode;
    }

    public double Sjcalculation(int ldmod, double lddue, int dtmod, double dtprem, int caldt, double calyrint, double endfac)
    {
        double swjamt=0;
        double ldprem;
        double sameyearfac;
        double styearsfac;        
        double intfac;
        double styrint;

        if (ldmod == dtmod)
        {
            ldprem = dtprem;
        }
        else //finding the swarnajayanthi premium when mode has changed.
        {
            #region-----This was commented because Mr. Jayantha adviced to calculate premium according to the mod-----
            //string rcoverhissel = "select RPRM from LUND.RCOVER_HISTORY where RPOL=" + polno + " and RCOVR=" + covernum + " and RMODE=" + ledgermod + "";
            //if (dm.existRecored(rcoverhissel) != 0)
            //{
            //    dm.readSql(rcoverhissel);
            //    OracleDataReader rcoverhisreader = dm.oraComm.ExecuteReader();
            //    rcoverhisreader.Read();
            //    if (!rcoverhisreader.IsDBNull(0)) { ledgerprem = rcoverhisreader.GetDouble(0); } else { ledgerprem = 0; }
            //    rcoverhisreader.Close();
            //}
            //else
            //{
            //    throw new Exception("SJ Premium Mode Has Changed. No Relevent History Records found!");
            //}
            #endregion

            ldprem = this.Repremium(ldmod, this.Premium(dtmod, dtprem));
        }
        if (int.Parse(lddue.ToString().Substring(0, 4)) == int.Parse(caldt.ToString().Substring(0, 4)))
        {
            yearsfacobj = new SJyrscal(int.Parse(lddue.ToString() + commence.ToString().Substring(6, 2)), caldt);
            sameyearfac = yearsfacobj.Yearsfac;
            swjamt += ldprem * Math.Pow(1 + (calyrint / 100), sameyearfac);
        }
        else
        {
            yearsfacobj = new SJyrscal(int.Parse(lddue.ToString() + commence.ToString().Substring(6, 2)), int.Parse(lddue.ToString().Substring(0, 4) + "1231"));
            styearsfac = yearsfacobj.Yearsfac;
            intrateobj = new IntRate(int.Parse(lddue.ToString().Substring(0, 4)));
            styrint = intrateobj.Rate;
            intfac = 1;
            if ((int.Parse(caldt.ToString().Substring(0, 4)) - int.Parse(lddue.ToString().Substring(0, 4))) > 1)
            {
                intfac = this.InterestFactor(int.Parse(lddue.ToString().Substring(0, 4)), int.Parse(caldt.ToString().Substring(0, 4)));
            }
            swjamt += ldprem * Math.Pow(1 + (calyrint / 100), endfac) * intfac * Math.Pow(1 + (styrint / 100), styearsfac);
        }
        return swjamt;
    }

    public double Sjamt
    {
        get { return sjamt; }
        set { sjamt = value; }
    }
    public double Sumass
    {
        get { return sjsumass; }
        set { sjsumass = value; }
    }
}
