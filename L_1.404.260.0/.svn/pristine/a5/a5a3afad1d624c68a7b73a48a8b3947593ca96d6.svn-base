using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class DthClmRegDet
{
    private long polno;
    private string mof;
    private int dthrefDate;
    private int claimno;
    private string assuredName;
    private string address;
    private int dco;
    private int table;
    private int term;
    private long bsumAssu;
    private long adb;
    private long fpu;
    private long fe;
    private long sj;
    private int dtofIntimation;
    private int dtofDeath;
    private string causeofDeath;
    private double vestedBonus;
    private double interimBonus;
    private double deposits;
    private double grossclm;
    private double defprem;
    private double defInterest;
    private int polCompleteYear;
    private double loanCap;
    private double loanInt;
    private double otherDeductions;
    private double netClm;
    private int paidNo, admitNo;
    private int entdt;
    private int repudate;
    private string repuReason;
    private int PAYAUTDT;
    private string cof;

    DataManager dm;
    
	public DthClmRegDet(long pol, string whosLife)
	{
        this.polno = pol;
        this.mof = whosLife;

        dm = new DataManager();

        int counter = 0;
        try
        {
            //------------- dthref -----------------
            string completed = "";

            string dthrefSelect = "select DRPOLNO, DRMOS, DRCLMNO, ADBPAYAMT, DRVESTEDBON, DRINTERIMBON, SJPAYAMT, FEPAYAMT,";
            dthrefSelect += "FPUPAYAMT, DRDEPOSITS, DROTHERADITNS, DRGROSSCLM, DEOTHERDEDUCT, DRDEFPREM, DRINT, DRLONCAP, DRLOANINT, ";
            dthrefSelect += "DRNETCLM, DRPAIDNO, DRNETSURR, CAUSEOFDEATHSTR, DENTDT, completed, PAYAUTDT, DRADMITNO from LPHS.DTHREF where DRPOLNO = " + polno + " and DRMOS = '" + mof + "' and (completed = 'Y' or completed = 'R' ) ";
            dm.readSql(dthrefSelect);
            OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dthrefReader.Read())
            {
                counter++;

                #region
                //this.polno = dthrefReader.GetInt32(0);
                //if (!dthrefReader.IsDBNull(1)) { this.mof = dthrefReader.GetString(1); }
                if (!dthrefReader.IsDBNull(2)) { this.claimno = dthrefReader.GetInt32(2); } else { claimno = 0; }
                if (!dthrefReader.IsDBNull(3)) { this.adb = dthrefReader.GetInt64(3); } else { adb = 0; }
                if (!dthrefReader.IsDBNull(4)) { this.vestedBonus = dthrefReader.GetDouble(4); } else { vestedBonus = 0; }
                if (!dthrefReader.IsDBNull(5)) { this.interimBonus = dthrefReader.GetDouble(5); } else { interimBonus = 0; }
                if (!dthrefReader.IsDBNull(6)) { this.sj = dthrefReader.GetInt64(6); } else { sj = 0; }
                if (!dthrefReader.IsDBNull(7)) { this.fe = dthrefReader.GetInt64(7); } else { fe = 0; }
                if (!dthrefReader.IsDBNull(8)) { this.fpu = dthrefReader.GetInt64(8); } else { fpu = 0; }
                if (!dthrefReader.IsDBNull(9)) { this.deposits = dthrefReader.GetDouble(9); } else { deposits = 0; }
                if (!dthrefReader.IsDBNull(11)) { this.grossclm = dthrefReader.GetDouble(11); } else { grossclm = 0; }
                if (!dthrefReader.IsDBNull(12)) { this.otherDeductions = dthrefReader.GetDouble(12); } else { otherDeductions = 0; }
                if (!dthrefReader.IsDBNull(13)) { this.defprem = dthrefReader.GetDouble(13); } else { defprem = 0; }
                if (!dthrefReader.IsDBNull(14)) { this.defInterest = dthrefReader.GetDouble(14); } else { defInterest = 0; }
                if (!dthrefReader.IsDBNull(15)) { this.loanCap = dthrefReader.GetDouble(15); } else { loanCap = 0; }
                if (!dthrefReader.IsDBNull(16)) { this.loanInt = dthrefReader.GetDouble(16); } else { loanInt = 0; }
                if (!dthrefReader.IsDBNull(17)) { this.netClm = dthrefReader.GetDouble(17); } else { netClm = 0; }
                if (!dthrefReader.IsDBNull(18)) { this.paidNo = dthrefReader.GetInt32(18); } else { paidNo = 0; }
                if (!dthrefReader.IsDBNull(20)) { this.causeofDeath = dthrefReader.GetString(20); } else { causeofDeath = ""; }
                if (!dthrefReader.IsDBNull(21)) { this.entdt = dthrefReader.GetInt32(21); } else { entdt = 0; }
                if (!dthrefReader.IsDBNull(22)) { completed = dthrefReader.GetString(22); } else { completed = ""; }
                if (!dthrefReader.IsDBNull(23)) { this.PAYAUTDT = dthrefReader.GetInt32(23); } else { PAYAUTDT = 0; }
                if (!dthrefReader.IsDBNull(24)) { this.admitNo = dthrefReader.GetInt32(24); } else { admitNo = 0; }

                #endregion

                #region  //--------- dthint --------------------

                string dthintSelect = "select DINFODAT, DPOLST, DNOD, DDTOFDTH, dcof  ";
                dthintSelect += " from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + mof + "' ";
                dm.readSql(dthintSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    counter++;
                    if (!dthintReader.IsDBNull(0)) { this.dtofIntimation = dthintReader.GetInt32(0); }
                    if (!dthintReader.IsDBNull(3)) { this.dtofDeath = dthintReader.GetInt32(3); }
                    if (!dthintReader.IsDBNull(4)) { this.cof = dthintReader.GetString(4); }
                }
                //dthintReader.Close();
                //dthintReader.Dispose();


                if (cof == null) { this.cof = "NOT DEFINE"; }
                else
                {
                    if (cof.Equals("C")) { this.cof = "CIVIL"; }
                    else if (cof.Equals("A")) { this.cof = "ARMY"; }
                    else if (cof.Equals("N")) { this.cof = "NAVY"; }
                    else if (cof.Equals("G")) { this.cof = "AIR FORCE"; }
                    else if (cof.Equals("B")) { this.cof = "BUDDHIST CLERGY"; }
                    //else if (cof==null) { this.cof = "NOT DEFINE"; }
                }
                #endregion

                #region  //--------- dth_repudiation --------------------

                if (completed.Equals("R")) 
                {
                    string repusel = "select REPU_REASON, REPU_DATE from LPHS.DTH_REPUDIATION where POLICYNO = " + polno + " and LIFE_TYPE = '" + mof + "' ";
                    if (dm.existRecored(repusel) != 0) 
                    {
                        this.PAYAUTDT = 0;
                        dm.readSql(repusel);
                        OracleDataReader repuReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (repuReader.Read()) {
                            if (!repuReader.IsDBNull(0)) { repuReason = repuReader.GetString(0); } else { repuReason = ""; }
                            if (!repuReader.IsDBNull(1)) { repudate = repuReader.GetInt32(1); } else { repudate = 0; }                        
                        }
                        //repuReader.Close();
                        //repuReader.Dispose();
                    }
                }

                #endregion

                #region  //---------- lopolhis -------------------

                string lpolhisSelect = "select PHCOM, PHTBL, PHTRM, PHSUM  from LPHS.LPOLHIS where phpol=" + polno + " and phtyp = 'D' and phmos = '" + mof + "' ";
                dm.readSql(lpolhisSelect);
                OracleDataReader lpolhisReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (lpolhisReader.Read())
                {
                    counter++;
                    if (!lpolhisReader.IsDBNull(0)) { this.dco = lpolhisReader.GetInt32(0); }
                    if (!lpolhisReader.IsDBNull(1)) { this.table = lpolhisReader.GetInt32(1); }
                    if (!lpolhisReader.IsDBNull(2)) { this.term = lpolhisReader.GetInt32(2); }
                    if (!lpolhisReader.IsDBNull(3)) { this.bsumAssu = lpolhisReader.GetInt64(3); }

                }
                //lpolhisReader.Close();
                //lpolhisReader.Dispose();

                #endregion

                #region    //---------------- phname ----------------

                string phnameSelect = "select PNSTA, PNINT, PNSUR, PNAD1, PNAD2, PNAD3, PNAD4 from LPHS.PHNAME where pnpol=" + polno + " ";
                dm.readSql(phnameSelect);
                OracleDataReader phnameReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (phnameReader.Read())
                {
                    counter++;
                    string name1 = "";
                    string name2 = "";
                    string name3 = "";
                    string ad1 = "";
                    string ad2 = "";
                    string ad3 = "";
                    string ad4 = "";

                    if (!phnameReader.IsDBNull(0)) { name1 = phnameReader.GetString(0); }
                    if (!phnameReader.IsDBNull(1)) { name2 = phnameReader.GetString(1); }
                    if (!phnameReader.IsDBNull(2)) { name3 = phnameReader.GetString(2); }

                    if (!phnameReader.IsDBNull(3)) { ad1 = phnameReader.GetString(3); }
                    if (!phnameReader.IsDBNull(4)) { ad2 = phnameReader.GetString(4); }
                    if (!phnameReader.IsDBNull(5)) { ad3 = phnameReader.GetString(5); }
                    if (!phnameReader.IsDBNull(6)) { ad4 = phnameReader.GetString(6); }

                    this.assuredName = name1 + " " + name2 + " " + name3;
                    this.address = ad1 + " " + ad2 + " " + ad3 + " " + ad4;

                }
                //phnameReader.Close();
                //phnameReader.Dispose();

                #endregion
            }
            dthrefReader.Close();
            dthrefReader.Dispose();
 
            dm.connclose();
        }
        catch (Exception ex){
            throw new Exception(ex + counter.ToString());
        
        }
	}

    public long Polno {
        get { return polno; }
        set { polno = value; }
    }
    public string Mof
    {
        get { return mof; }
        set { mof = value; }
    }
    public int DthrefDate
    {
        get { return dthrefDate; }
        set { dthrefDate = value; }
    }
    public int Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public string AssuredName
    {
        get { return assuredName; }
        set { assuredName = value; }
    }
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public int Dco
    {
        get { return dco; }
        set { dco = value; }
    }
    public int Table
    {
        get { return table; }
        set { table = value; }
    }
    public int Term
    {
        get { return term; }
        set { term = value; }
    }
    public long BsumAssu
    {
        get { return bsumAssu; }
        set { bsumAssu = value; }
    }
    public long Adb
    {
        get { return adb; }
        set { adb = value; }
    }
    public long Fpu
    {
        get { return fpu; }
        set { fpu = value; }
    }
    public long Fe
    {
        get { return fe; }
        set { fe = value; }
    }
    public long Sj
    {
        get { return sj; }
        set { sj = value; }
    }
    public int DtofIntimation
    {
        get { return dtofIntimation; }
        set { dtofIntimation = value; }
    }
    public int DtofDeath
    {
        get { return dtofDeath; }
        set { dtofDeath = value; }
    }
    public string CauseofDeath
    {
        get { return causeofDeath; }
        set { causeofDeath = value; }
    }
    public double VestedBonus
    {
        get { return vestedBonus; }
        set { vestedBonus = value; }
    }
    public double InterimBonus
    {
        get { return interimBonus; }
        set { interimBonus = value; }
    }
    public double Deposits
    {
        get { return deposits; }
        set { deposits = value; }
    }
    public double Grossclm
    {
        get { return grossclm; }
        set { grossclm = value; }
    }
    public double Defprem
    {
        get { return defprem; }
        set { defprem = value; }
    }
    public double DefInterest
    {
        get { return defInterest; }
        set { defInterest = value; }
    }
    public int PolCompleteYear
    {
        get { return polCompleteYear; }
        set { polCompleteYear = value; }
    }
    public double LoanCap
    {
        get { return loanCap; }
        set { loanCap = value; }
    }
    public double LoanInt
    {
        get { return loanInt; }
        set { loanInt = value; }
    }
    public double OtherDeductions
    {
        get { return otherDeductions; }
        set { otherDeductions = value; }
    }
    public double NetClm
    {
        get { return netClm; }
        set { netClm = value; }
    }
    public int PaidNo
    {
        get { return paidNo; }
        set { paidNo = value; }
    }
    public int Admitno
    {
        get { return admitNo; }
        set { admitNo = value; }
    }
    public int Entdt
    {
        get { return entdt; }
        set { entdt = value; }    
    }
    public int Repudate
    {
        get { return repudate; }
        set { repudate = value; }
    }
    public string RepuReason
    {
        get { return repuReason; }
        set { repuReason = value; }
    }
    public int pAYAUTDT
    {
        get { return PAYAUTDT; }
        set { PAYAUTDT = value; }
    }
    public string Cof
    {
        get { return cof; }
        set { cof = value; }
    }
}
