using System;
using System.Collections.Generic;
using System.Web;
using System.Data.OracleClient;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for SwarnaJayanthiCover
/// </summary>
public class SwarnaJayanthiCover
{
    DataManager dm;
    Dictionary<int, double> dueWithSJRate;
    public DataTable dt = new DataTable();
    DataTable calcDetails;

    private long _policyNo;
    private int _dateOfCalc;
    private string _mos;
    private int _lastSJPayDate; //SWARNA JAYANTHI Last pay Date
    private int _coverNo;

    private int _mode;
    private double _premium;
    private int _commenceDate;
    private double _sJSumAssured;
    private int _sJStartDate;

    private double _sJAmount;
    private int _pointDate;
    private int _firstDayOfYear; // First day of year Ex: 2012 01 01
    private double _lastYearDuration; //Duration of the calculation date to first day of calculation year
    private double _sjrate;

    private int _year;
    private double _sjInterest;
    private double _yearFactor;
    private int _ledgerDue;
    private string _sjPayType;

    private double _refundableAmount;
    private string _errorMasaage;
    private int _policyAniversaryDate;
    private int _dateOfDeath;

    private string _entryType;

    private int _oldComDate;
    private int _newComDate;
    private double _oldPremium;
    private double _newPremium;



    #region --------------- Properties ---------------

    public double SJSumAssured
    {
        get { return _sJSumAssured; }
        set { _sJSumAssured = value; }
    }
    public int LastSJPayDate
    {
        get { return _lastSJPayDate; }
        set { _lastSJPayDate = value; }
    }
    public string Mos
    {
        get { return _mos; }
        set { _mos = value; }
    }
    public long PolicyNo
    {
        get { return _policyNo; }
        set { _policyNo = value; }
    }
    public int DateOfCalc
    {
        get { return _dateOfCalc; }
        set { _dateOfCalc = value; }
    }

    public double Premium
    {
        get { return _premium; }
        set { _premium = value; }
    }
    public int CommenceDate
    {
        get { return _commenceDate; }
        set { _commenceDate = value; }
    }
    public int CoverNo
    {
        get { return _coverNo; }
        set { _coverNo = value; }
    }
    public int Mode
    {
        get { return _mode; }
        set { _mode = value; }
    }
    public int SJStartDate
    {
        get { return _sJStartDate; }
        set { _sJStartDate = value; }
    }

    public double SJAmount
    {
        get { return _sJAmount; }
        set { _sJAmount = value; }
    }
    public int PointDate
    {
        get { return _pointDate; }
        set { _pointDate = value; }
    }
    public int FirstDayOfYear
    {
        get { return _firstDayOfYear; }
        set { _firstDayOfYear = value; }
    }
    public double LastYearDuration
    {
        get { return _lastYearDuration; }
        set
        {
            _lastYearDuration = Math.Round(value, 2);
            //_lastYearDuration = value;
        }
    }
    public double SJRate
    {
        get { return _sjrate; }
        set
        {
            _sjrate = Math.Round(value, 2);

        }
    }

    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }
    public double SJInterest
    {
        get { return _sjInterest; }
        set
        {
            _sjInterest = Math.Round(value, 15);
        }
    }
    public double YearFactor
    {
        get { return _yearFactor; }
        set
        {
            _yearFactor = Math.Round(value, 2);
        }
    }

    public string SjPayType
    {
        get { return _sjPayType; }
        set { _sjPayType = value; }
    }

    public int LedgerDue
    {
        get { return _ledgerDue; }
        set { _ledgerDue = value; }
    }

    public double RefundableAmount
    {
        get { return _refundableAmount; }
        set { _refundableAmount = Math.Round(value, 2); }
    }

    public string ErrorMasaage
    {
        get { return _errorMasaage; }
        set { _errorMasaage = value; }
    }

    public int PolicyAniversaryDate
    {
        get { return _policyAniversaryDate; }
        set { _policyAniversaryDate = value; }
    }

    public int DateOfDeath
    {
        get { return _dateOfDeath; }
        set { _dateOfDeath = value; }
    }

    public string EntryType
    {
        get { return _entryType; }
        set { _entryType = value; }
    }

    public double OldPremium
    {
        get { return _oldPremium; }
        set { _oldPremium = value; }
    }

    public double NewPremium
    {
        get { return _newPremium; }
        set { _newPremium = value; }
    }

    public int OldCommenceDate
    {
        get { return _oldComDate; }
        set { _oldComDate = value; }
    }

    public int NewCommenceDate
    {
        get { return _newComDate; }
        set { _newComDate = value; }
    }
    #endregion

    #region -------------- Constructers --------------
    public SwarnaJayanthiCover(long policyNO, int dateOfCalc, string mos, int sjLastPayDate)
    {
        //
        // TODO: Add constructor logic here
        //
        PolicyNo = policyNO;
        DateOfCalc = dateOfCalc;
        Mos = mos;
        LastSJPayDate = sjLastPayDate;

        SjPayType = "death";//Default
        EntryType = "system";// to check input coming from EntryForm or system
        DateOfDeath = DateOfCalc;

    }

    public SwarnaJayanthiCover(long policyNO, int dateOfCalc, string mos, int sjLastPayDate, string swarnaJayanthiPayType, int policyCommenceDate)
    {
        //
        // TODO: Add constructor logic here
        //
        PolicyNo = policyNO;
        DateOfCalc = dateOfCalc;
        Mos = mos;
        LastSJPayDate = sjLastPayDate;
        CommenceDate = policyCommenceDate;

        SjPayType = swarnaJayanthiPayType;
        EntryType = "manual";// to check input coming from EntryForm or system
        DateOfDeath = DateOfCalc;        

    } 
    #endregion

    public void SetCoverNumber()
    {
        if (Mos.Equals("M"))
        {
            CoverNo = 10;
        }
        else if (Mos.Equals("S"))
        {
            CoverNo = 110;
        }
        else if (Mos.Equals("2"))
        {
            CoverNo = 210;
        }
    }
    public bool SetCoverDetails()
    {
        try
        {
            dm = new DataManager();
            //string sjcoveryesno = "select RMODE, RPRM, ROEX, RHEX, RDISCON, RCOMDAT, RSUMAS from LUND.RCOVER where RPOL=" + PolicyNo + " and RCOVR=" + CoverNo + "";
            string sjcoveryesno = "select a.RMODE, (nvl(a.RPRM,0) + nvl(C.OEAMT,0) + nvl(B.HEAMT,0) - nvl(D.DISAMT,0)) as premium, a.ROEX, a.RHEX, a.RDISCON, a.RCOMDAT, a.RSUMAS " +
                                  "from LUND.RCOVER a full outer JOIN LUND.RHELEX b on A.RPOL=B.RPOL and A.RCOVR=B.RCOVR " +
                                  "full outer JOIN LUND.ROCCEX c on A.RPOL=c.RPOL and A.RCOVR=c.RCOVR " +
                                  "full outer JOIN LUND.RDISCON d on A.RPOL=d.RPOL and A.RCOVR=d.RCOVR " +
                                  "where  a.RPOL=" + PolicyNo + " and a.RCOVR=" + CoverNo + "";
            if (dm.existRecored(sjcoveryesno) != 0)
            {
                dm.readSql(sjcoveryesno);
                OracleDataReader sjamtreader = dm.oraComm.ExecuteReader();
                while (sjamtreader.Read())
                {
                    if (!sjamtreader.IsDBNull(0)) { Mode = sjamtreader.GetInt32(0); } else { Mode = 0; }
                    if (!sjamtreader.IsDBNull(1)) { Premium = sjamtreader.GetDouble(1); } else { Premium = 0; }

                    if (EntryType != "manual")
                    {
                        if (!sjamtreader.IsDBNull(5)) { CommenceDate = sjamtreader.GetInt32(5); } else { CommenceDate = 0; }
                    }
                    if (!sjamtreader.IsDBNull(6)) { SJSumAssured = sjamtreader.GetDouble(6); } else { SJSumAssured = 0; }
                }

                sjamtreader.Close();
                dm.connclose();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw (Ex);
        }
    }
    public void SetCommencementDateFromPremast()
    {
        try
        {
            dm = new DataManager();
            string sjcoveryesno = "   select PMCOM from lphs.premast where pmpol= " + PolicyNo + " ";
            if (dm.existRecored(sjcoveryesno) != 0)
            {
                dm.readSql(sjcoveryesno);
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) { CommenceDate = reader.GetInt32(0); } else { CommenceDate = 0; }

                }
                reader.Close();
                reader.Dispose();
                dm.connclose();
            }
            else
            {
                ErrorMasaage = "There are no record for Policy number " + PolicyNo + "  ";
                throw new Exception(ErrorMasaage);
            }
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw (Ex);
        }
    }
    public void SetSwarnaJayanthiStartDate()
    {
        // SJStartDate = Commence Date + 2 Years
        string startDate = Convert.ToString(int.Parse(CommenceDate.ToString().Substring(0, 4)) + 2) + CommenceDate.ToString().Substring(4, 4);
        startDate = ValidationDateForMonth(startDate); ////ValidationDateForMonth
        SJStartDate = int.Parse(startDate);
       
    }

    public void SetPointDate()
    {
        if (LastSJPayDate == 0)
        {
            bool isHaveSJSumAssAlter = GetSumAssuredAlterPremium(int.Parse(DateOfCalc.ToString().Substring(0, 6)));

            if (isHaveSJSumAssAlter)
            {
                LastSJPayDate = PointDate = OldCommenceDate;
            }
            else
            {
                LastSJPayDate = PointDate = CommenceDate;
            }
        }
        else
        {
            PointDate = LastSJPayDate;//LastPayDate
        }

    }
    public double GetYearDuration(int start, int end)
    {
        int days = GetDateDifference(start, end);
        double yearPortion = days / 365.25;

        return yearPortion;
    }
    public int GetDateDifference(int start, int end)
    {
        DateTime startDate = DateTime.ParseExact(start.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(end.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        int days = endDate.Subtract(startDate).Days;
        return days;

    }
    public int GetYear(int date)
    {
        int yr = int.Parse(date.ToString().Substring(0, 4));
        return yr;
    }

    public int GetFirstDateOfYear(int date)
    {
        int firstdate;
        try
        {
            firstdate = int.Parse(date.ToString().Substring(0, 4) + "0101");
        }
        catch (Exception ex)
        {
            throw;
        }

        return firstdate;
    }
    public int GetLastDateOfYear(int date)
    {
        int lastdate;
        try
        {
            lastdate = int.Parse(date.ToString().Substring(0, 4) + "1231");
        }
        catch (Exception ex)
        {
            throw;
        }

        return lastdate;
    }
    public double GetCommenceYearDuration(int caldate)
    {
        double duration = GetYearDuration(caldate, GetLastDateOfYear(caldate));
        return duration;
    }
    public void SetSwarnaJayanthiRateForYear()
    {
        try
        {
            dm = new DataManager();
            string intsel = "select RATE from LPHS.SJ_INTEREST_RATES where YEAR=" + Year + " ";
            if (dm.existRecored(intsel) != 0)
            {
                dm.readSql(intsel);
                OracleDataReader interestReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                interestReader.Read();
                if (!interestReader.IsDBNull(0)) { SJRate = interestReader.GetDouble(0); } else { SJRate = 0; }
                interestReader.Close();
                interestReader.Dispose();
            }
            else
            {
                SJRate = 0;
                throw new Exception("Swarana Jayanthi Interest Rate for Year " + Year + " Not Yet Defined");
            }
            dm.connclose();
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw (Ex);
        }
    }

    public double GetAnnualPremium(int PremMode, double amount)
    {
        int multiplier;

        if (PremMode == 1) { multiplier = 1; }
        else if (PremMode == 2) { multiplier = 2; }
        else if (PremMode == 3) { multiplier = 4; }
        else { multiplier = 12; }

        double annualprem = amount * multiplier;
        return annualprem;
    }
    public double GetRepremium(int rMode, double annualPremium)
    {
        int divider;

        if (rMode == 1) { divider = 1; }
        else if (rMode == 2) { divider = 2; }
        else if (rMode == 3) { divider = 4; }
        else { divider = 12; }

        double prem = annualPremium / divider;
        return prem;
    }    
    public int SetCalculatingDateFromYear(int currentCalcYear)
    {
        string mounthAndDate = CommenceDate.ToString().Substring(4, 4);
        string date = currentCalcYear.ToString() + mounthAndDate;
        date = ValidationDateForMonth(date);////ValidationDateForMonth
        int currentCalculationDateForYear = int.Parse(date);
        return currentCalculationDateForYear;
    }

    /// <summary>
    /// SetCalculatingDateFromPremiumPaidtDate/Due Date
    /// </summary>
    /// <param name="currentCalcYear"></param>
    /// <returns></returns>
    public int SetCalculatingDateFromPremiumPaidtDate(int currentCalcYear)
    {
        string Date = CommenceDate.ToString().Substring(6, 2);

        string AdjustLedgerDue = LedgerDue.ToString().Substring(0, 6) + Date; //no need to substring if length 6 
        AdjustLedgerDue = ValidationDateForMonth(AdjustLedgerDue);////ValidationDateForMonth
        int currentCalculationDateForYear = int.Parse(AdjustLedgerDue);
        return currentCalculationDateForYear;
    }

    public string ValidationDateForMonth(string yearMonthDate)
    {
        string monthDate = yearMonthDate.Substring(4, 4);
        int monthDateInt = int.Parse(monthDate);
        if (monthDateInt > 228 && monthDateInt < 232)
        {
            monthDate = "0228";
            yearMonthDate = yearMonthDate.Substring(0, 4) + monthDate;
        }
        else if(monthDateInt == 431 || monthDateInt ==631 || monthDateInt ==931 || monthDateInt ==1131) 
        {
            yearMonthDate = yearMonthDate.Substring(0, 6) + "30";
        }
        return yearMonthDate;
    }
    public double GetCalculatingYearDuration(int year)
    {
        //double duration = GetYearDuration(SetCalculatingDateFromYear(year), GetLastDateOfYear(year));
        double duration = GetYearDuration(SetCalculatingDateFromPremiumPaidtDate(year), GetLastDateOfYear(year));
        duration = Math.Round(duration, 2);
        return duration;
    }

    #region ----------------For Refunding--------------------

    public void ValidatePointDateForGetPaybleDues()
    {
        if (SjPayType == "refund")
        {
            if ((DateOfCalc - SJStartDate) < 2)
            {
                try
                {
                    throw new Exception("SwarnaJayanthi Start Date = " + SJStartDate + " . To Refund Policy Should be fulfill two years  ");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                string monthDate = CommenceDate.ToString().Substring(4, 4);
                //string policyAnniversaryDateStr = PointDate.ToString().Substring(0, 4) + monthDate;
                string policyAnniversaryDateStr = DateOfCalc.ToString().Substring(0, 4) + monthDate;
                policyAnniversaryDateStr = ValidationDateForMonth(policyAnniversaryDateStr);
                PolicyAniversaryDate = int.Parse(policyAnniversaryDateStr);


                if (DateOfCalc - PolicyAniversaryDate >= 0)
                {
                    //PointDate = policyAnniversaryDate; //Set Point Date 
                }
                else
                {
                    PolicyAniversaryDate = PolicyAniversaryDate - 10000; //Reduce year
                    PolicyAniversaryDate = int.Parse(ValidationDateForMonth(PolicyAniversaryDate.ToString()));
                }
            }
        }

    }

    #endregion

    public void LoadPaybleLedgerDuesWithRate()
    {
        dueWithSJRate = new Dictionary<int, double>();
        StringBuilder sql = new StringBuilder();
        sql.Append(" select LLDUE , (select NVL(MAX(rate),0) from LPHS.SJ_INTEREST_RATES where  year= substr( LLDUE,1,4) ) as  rate , NVL(MAX(LLMOD),0) ");
        sql.Append(" from LCLM.LEDGER ");
        sql.Append(" WHERE LLPOL=" + PolicyNo + " and LLDUE >= substr( " + PointDate + ",1,6) and LLDUE <= substr( " + DateOfCalc + ",1,6)  ");
        sql.Append(" GROUP BY LLDUE ");

        dm = new DataManager();
        string qry = sql.ToString();
        if (dm.existRecored(qry) != 0)
        {
            dm.readSql(qry);
            OracleDataReader ledgerread = dm.oraComm.ExecuteReader();
            while (ledgerread.Read())
            {
                int due;
                if (!ledgerread.IsDBNull(0))
                {
                    due = ledgerread.GetInt32(0);
                }
                else { due = 0; }
                if (!ledgerread.IsDBNull(1))
                {
                    SJRate = ledgerread.GetDouble(1);
                }
                else { SJRate = 0; }
                dueWithSJRate.Add(due, SJRate);
            }

            ledgerread.Close();
            dm.connclose();
        }

    }
    public void LoadDataTablePaybleLedgerDuesWithRate()
    {
        dueWithSJRate = new Dictionary<int, double>();
        StringBuilder sql = new StringBuilder();
        if (SjPayType == "refund")
        {
            sql.Append(" select LLDUE , (select NVL(MAX(rate),0) from LPHS.SJ_INTEREST_RATES where  year= substr( LLDUE,1,4) ) as  rate , NVL(MAX(LLMOD),0) ");
            sql.Append(" from LCLM.LEDGER ");
            sql.Append(" WHERE LLPOL=" + PolicyNo + " and LLDUE >  substr( " + LastSJPayDate + ",1,6)  and LLDUE <= substr( " + PolicyAniversaryDate + " ,1,6) ");
            sql.Append(" GROUP BY LLDUE ");
        }
        else if (SjPayType == "death")
        {           
            if (CommenceDate == LastSJPayDate)
            {
                sql.Append(" select LLDUE , (select NVL(MAX(rate),0) from LPHS.SJ_INTEREST_RATES where  year= substr( LLDUE,1,4) ) as  rate , NVL(MAX(LLMOD),0) ");
                sql.Append(" from LCLM.LEDGER ");
                sql.Append(" WHERE LLPOL=" + PolicyNo + " and LLDUE >= substr( " + LastSJPayDate + ",1,6) AND LLDAT <=" + DateOfCalc + " ");
                sql.Append(" GROUP BY LLDUE ");
            }
            else if (OldCommenceDate == LastSJPayDate)
            {
                sql.Append(" select LLDUE , (select NVL(MAX(rate),0) from LPHS.SJ_INTEREST_RATES where  year= substr( LLDUE,1,4) ) as  rate , NVL(MAX(LLMOD),0) ");
                sql.Append(" from LCLM.LEDGER ");
                sql.Append(" WHERE LLPOL=" + PolicyNo + " and LLDUE >= substr( " + LastSJPayDate + ",1,6) AND LLDAT <=" + DateOfCalc + " ");
                sql.Append(" GROUP BY LLDUE ");
            }
            else
            {
                sql.Append(" select LLDUE , (select NVL(MAX(rate),0) from LPHS.SJ_INTEREST_RATES where  year= substr( LLDUE,1,4) ) as  rate , NVL(MAX(LLMOD),0) ");
                sql.Append(" from LCLM.LEDGER ");
                sql.Append(" WHERE LLPOL=" + PolicyNo + " and LLDUE > substr( " + LastSJPayDate + ",1,6) AND LLDAT <=" + DateOfCalc + " ");
                sql.Append(" GROUP BY LLDUE ");
            }
        }
        else
        {
            sql.Append(" select LLDUE , (select NVL(MAX(rate),0) from LPHS.SJ_INTEREST_RATES where  year= substr( LLDUE,1,4) ) as  rate , NVL(MAX(LLMOD),0) ");
            sql.Append(" from LCLM.LEDGER ");
            sql.Append(" WHERE LLPOL=" + PolicyNo + " and LLDUE > substr( " + LastSJPayDate + ",1,6)  ");
            sql.Append(" GROUP BY LLDUE ");
        }

        //dm = new DataManager();

        //calcDetails = new DataTable();
        //calcDetails = dm.GetDataTable(sql.ToString());
        //dm.connclose();

        calcDetails = new DataTable();
        using (DatabaseAccessLayer dal = new DatabaseReadOnlyLayer())
        {
            dal.OpenDBConnection();
            calcDetails= dal.ReadSQLtoDataTable(sql.ToString());
            dal.CloseDBConnection();
        }
    }

    /// <summary>
    /// swarna jayanthi Premium Calculate according to Ledger Mode
    /// 
    /// </summary>
    /// <param name="ledgerMode"></param>
    public double SetSwarnaJayanthiPremiumAcordingToLedgerMode(int ledgerMode)
    {
        double swarnaJayanthiAnnualPremium = GetAnnualPremium(Mode, Premium);//(SwarnaJayanthi Mode, SwarnaJayanthi Premium)
        // SwarJayanthi Premium According To Ledger Premium
        double sPremAcToLedPrem = GetRepremium(ledgerMode, swarnaJayanthiAnnualPremium);
        return sPremAcToLedPrem;
    }
    public void CalculateFinalRefundableAmount()
    {
        double amount = 0.00;
        if (SjPayType.Equals("death"))
        {
            //amount = SJSumAssured + SJAmount / 2;
            amount = SJAmount / 2;
        }
        else
        {
            amount = SJAmount / 2;
        }

        RefundableAmount = amount;
    }
    public void IsSwarnaJayanthiRateExistForYear(int rateYear)
    {

        try
        {

            //dm = new DataManager();
            //string intsel = "select YEAR, RATE from LPHS.SJ_INTEREST_RATES   ";
            //if (dm.existRecored(intsel) != 0)
            //{
            //    dm.readSql(intsel);
            //    OracleDataReader interestreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //    interestreader.Read();
            //    if (!interestreader.IsDBNull(0)) { SJRate = interestreader.GetDouble(0); } else { SJRate = 0; }
            //    interestreader.Close();
            //    interestreader.Dispose();
            //}
            //else
            //{
            //    SJRate = 0;
            //    ErrorMasaage = "Swarana Jayanthi Interest Rate for Year " + rateYear + " Not Yet Defined";
            //    throw new Exception(ErrorMasaage);
            //}
            //dm.connclose();
        }
        catch (Exception Ex)
        {
            //dm.connclose();
            //throw (Ex);
        }
    }
    public int GetMaturityDate()
    {
        int term = 0;
        int maturitydate = 0;

        StringBuilder sql = new StringBuilder();
        sql.Append("  select pmpol,pmcom,pmtrm   from lphs.policymaster where pmpol =" + PolicyNo + " ");

        dm = new DataManager();
        string qry = sql.ToString();

        if (dm.existRecored(qry) != 0)
        {
            dm.readSql(qry);
            OracleDataReader premastread = dm.oraComm.ExecuteReader();
            while (premastread.Read())
            {
                if (!premastread.IsDBNull(2))
                {
                    term = premastread.GetInt32(2);
                }
                else { term = 0; }
            }

            premastread.Close();
            dm.connclose();
            maturitydate = CommenceDate + term * 10000;
        }
        else
        {
            maturitydate = GetMaturityDateFromLPOLHIS();
        }

        return maturitydate;
    }

    public int GetMaturityDateFromLPOLHIS()
    {
        int term = 0;
        int maturitydate = 0;

        StringBuilder sql = new StringBuilder();
        sql.Append("  select pHpol,pHcom,pHtrm   from lphs.LPOLHIS where pHpol =" + PolicyNo + " ");

        dm = new DataManager();
        string qry = sql.ToString();

        if (dm.existRecored(qry) != 0)
        {
            dm.readSql(qry);
            OracleDataReader reader = dm.oraComm.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(2))
                {
                    term = reader.GetInt32(2);
                }
                else { term = 0; }
            }

            reader.Close();
            dm.connclose();
            maturitydate = CommenceDate + term * 10000;
        }
        else
        {
            throw new Exception("cannot find policy number in lpohis or policy master table");
        }

        return maturitydate;
    }
  

    #region ------------SwarnaJayanthi Rate-----------------

    public void LoadAllRates()
    {
        int commYear = 0;
        dueWithSJRate = new Dictionary<int, double>();

        bool isHaveSJSumAssAlter = GetSumAssuredAlterPremium(int.Parse(DateOfCalc.ToString().Substring(0, 6)));

        if (isHaveSJSumAssAlter)
        {
            commYear = GetYear(OldCommenceDate);
        }
        else
        {
            commYear = GetYear(CommenceDate);
        }

        StringBuilder sql = new StringBuilder();
        sql.Append(" select YEAR, RATE from LPHS.SJ_INTEREST_RATES where YEAR>= " + commYear + " ");

        dm = new DataManager();
        string qry = sql.ToString();
        if (dm.existRecored(qry) != 0)
        {
            dm.readSql(qry);
            OracleDataReader ledgerread = dm.oraComm.ExecuteReader();
            while (ledgerread.Read())
            {
                int due; double rate;
                if (!ledgerread.IsDBNull(0))
                {
                    due = ledgerread.GetInt32(0);
                }
                else { due = 0; }
                if (!ledgerread.IsDBNull(1))
                {
                    rate = ledgerread.GetDouble(1);
                }
                else { rate = 0; }
                dueWithSJRate.Add(due, rate);
            }

            ledgerread.Close();
            dm.connclose();
        }
    }

    public double GetSwarnaJayanthiRate(int year)
    {
        bool isHaveRate = dueWithSJRate.ContainsKey(year);
        double rate;
        if (isHaveRate)
        {
            dueWithSJRate.TryGetValue(year, out rate);
            rate = Math.Round(rate, 2);
            return rate;
        }
        else
        {
            ErrorMasaage = "Swarana Jayanthi Interest Rate for Year " + year + " Not Yet Defined.to add new rate go to </br>  Admin->Finacial Authority ->Interest Rate Entry Dissability/SwarnaJayanthi ";
            throw new Exception(ErrorMasaage);
        }
    }

    #endregion

    public double GetLastDueYearDurationAccodToExelSheet(int year)
    {
        year = int.Parse(year.ToString().Substring(0, 4));
        double duration = GetYearDuration(SetCalculatingDateFromPremiumPaidtDate(year), DateOfCalc);
        duration = Math.Round(duration, 2);
        return duration;
    }
 
    #region ..................Calculation ..................

    public void SwarnaJayanthiCalculation()
    {
        SetCoverNumber();

        bool isHaveSJCover = SetCoverDetails();
        if (isHaveSJCover)
        {
            NewPremium = Premium;

            if (SjPayType == "death")
            {
                ValidateDeath();
            }
            else if (SjPayType == "refund")
            {
                ValidateRefund();
            }
            else if (SjPayType == "maturity")
            {
                ValidateMaturity();
            }

            SetPointDate();
            //ValidateSwarnaJayanthiLastPayDate();
            SetSwarnaJayanthiStartDate();

            ValidatePointDateForGetPaybleDues();  //to determine calculating date
            LoadDataTablePaybleLedgerDuesWithRate(); /// LoadPaybleLedgerDuesWithRate();
            LastYearDuration = GetYearDuration(GetFirstDateOfYear(DateOfCalc), DateOfCalc);// Calculation date - Calculation year/01/01

            LoadAllRates();//Load all Rates

            #region ---------Init GridView Column --------
            dt.Columns.Add("Due", typeof(string));
            dt.Columns.Add("Mode", typeof(string));///*****************************
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Rate", typeof(string));
            dt.Columns.Add("Premium", typeof(string));
            dt.Columns.Add("Duration", typeof(string));
            dt.Columns.Add("Premium + Interest", typeof(string));
            #endregion

            foreach (DataRow dr in calcDetails.Rows)
            {
                LedgerDue = Convert.ToInt32(dr[0].ToString());
                SJRate = Convert.ToDouble(dr[1].ToString());
                int ledgerMode = Convert.ToInt32(dr[2].ToString());

                bool isHaveSJSumAssAlter = GetSumAssuredAlterPremium(LedgerDue);

                if (isHaveSJSumAssAlter)
                {
                    if (LedgerDue < int.Parse(NewCommenceDate.ToString().Substring(0, 6)))
                    {
                        Premium = OldPremium;
                    }
                    else
                    {
                        Premium = NewPremium;
                    }
                }
                
                if (SJRate == 0.0)
                {
                    IsSwarnaJayanthiRateExistForYear(GetYear(LedgerDue));
                }

                Premium = SetSwarnaJayanthiPremiumAcordingToLedgerMode(ledgerMode);//Adust SwarnaJayanthi Premium

                for (int i = GetYear(DateOfCalc); i >= GetYear(LedgerDue); i--)
                {
                    SJRate = GetSwarnaJayanthiRate(i);
                    Year = i;
                    InterestCalculation(i);
                }
                SJAmount = SJAmount + SJInterest;


                #region -------------Add Data To GridView----------------
                DataRow drNewRow = dt.NewRow();

                drNewRow["Due"] = LedgerDue;
                drNewRow["Mode"] = ledgerMode;///*****************************
                drNewRow["Year"] = LedgerDue.ToString().Substring(0, 4);
                drNewRow["Rate"] = SJRate;
                drNewRow["Premium"] = Premium;
                drNewRow["Duration"] = YearFactor;
                drNewRow["Premium + Interest"] = SJInterest;
                dt.Rows.Add(drNewRow);

                #endregion
            }

            //SJInterest = SJInterest;
            CalculateFinalRefundableAmount();

        }
    
    }

    public void ValidateDeath()
    {
        int maturitydate = GetMaturityDate();
        if (DateOfCalc > maturitydate)
        {
            ErrorMasaage = "To death, Calculation date should be less than Maturity date ";
            throw new Exception(ErrorMasaage);
        }

    }

    public void ValidateRefund()
    {
        int maturitydate = GetMaturityDate();
        if (DateOfCalc < maturitydate)
        {
            if (DateOfCalc <= LastSJPayDate)
            {
                ErrorMasaage = "To Refund, Calculation date should be greater than SwarnaJayanthi Last pay Date";
                throw new Exception(ErrorMasaage);
            }
        }
        else
        {
            ErrorMasaage = "To refund, Calculation date should be leass than Maturity date ";
            throw new Exception(ErrorMasaage);
        }
    }

    public void ValidateMaturity()
    {
        int maturitydate = GetMaturityDate();
        if (!(DateOfCalc > maturitydate))
        {
            ErrorMasaage = "Date of calculation(" + DateOfCalc + ") should greater than maturity date(" + maturitydate + ")  ";
            throw new Exception(ErrorMasaage);
        }

    }

    public void ValidateSwarnaJayanthiLastPayDate()
    {
        string dateMonthOfCommenceDay = CommenceDate.ToString().Substring(4, 4);
        string dateNonthOfLastSJPayDate = LastSJPayDate.ToString().Substring(4, 4);
        if (LastSJPayDate >= CommenceDate)
        {
            if (dateMonthOfCommenceDay != dateNonthOfLastSJPayDate)
            {
                ErrorMasaage = "SwarnaJayanthi Last Pay Date ( " + LastSJPayDate + " )  should be Policy Anniversary date";
                throw new Exception(ErrorMasaage);
            }
        }
        else
        {
            ErrorMasaage = "SwarnaJayanthi Last Pay Date ( " + LastSJPayDate + " )  should be Greater than Policy Commence date ( "+CommenceDate+" ) ";
            throw new Exception(ErrorMasaage);
        }
    }

    public void InterestCalculation(int year)
    {
        double interestFactor = 1;

        if (year.ToString() == DateOfCalc.ToString().Substring(0, 4))
        {
            YearFactor = LastYearDuration;
            /////////////////  Addtionaly to map exel sheeet
            if(DateOfCalc.ToString().Substring(0, 4) == LedgerDue.ToString().Substring(0, 4))
            {
                YearFactor = GetLastDueYearDurationAccodToExelSheet(LedgerDue);
            }
            /////////////////
            SJInterest = Premium * Math.Pow(1 + (SJRate / 100), YearFactor);
        }
        else if (Year.ToString() == LedgerDue.ToString().Substring(0, 4))
        {
            YearFactor = GetCalculatingYearDuration(year);
            //SetCalculatingDateFromYear
            interestFactor = Math.Pow(1 + (SJRate / 100), YearFactor);
        }
        else
        {
            YearFactor = 1;
            interestFactor = 1 + (SJRate / 100);
        }

        SJInterest = SJInterest * interestFactor;

    }

    public bool GetSumAssuredAlterPremium(int dateAccept)
    {
        try
        {
            dm = new DataManager();
            string sjcoveryesno = "select a.rsumas, b.rsumas, a.rprm, b.rprm, c.old_com_date, c.new_com_date " +
                                  "from LUND.RCOVER a, LUND.RCOVER_HISTORY b, LUND.COVER_ADD_REMOVE c " +
                                  "where a.rpol=b.rpol and a.rcovr=b.rcovr and a.rpol=c.policy_no " +
                                  "and a.rcovr=" + CoverNo + " and a.rpol=" + PolicyNo + " and a.rsumas<>b.rsumas " +
                                  "and B.SQNO=C.END_NO and C.ACCEPT_DATE<to_date(to_char(" + DateOfCalc + "),'YYYYMMDD') " +
                                  "and C.ACCEPT_DATE<to_date(to_char(" + int.Parse(dateAccept.ToString() + CommenceDate.ToString().Substring(6, 2)) + "),'YYYYMMDD')" +
                                  "order by b.sqno";
            if (dm.existRecored(sjcoveryesno) != 0)
            {
                dm.readSql(sjcoveryesno);
                OracleDataReader sjamtreader = dm.oraComm.ExecuteReader();
                while (sjamtreader.Read())
                {
                    if (!sjamtreader.IsDBNull(3)) { OldPremium = sjamtreader.GetDouble(3); } else { OldPremium = 0; }
                    if (!sjamtreader.IsDBNull(4)) { OldCommenceDate = sjamtreader.GetInt32(4); } else { OldCommenceDate = 0; }
                    if (!sjamtreader.IsDBNull(5)) { NewCommenceDate = sjamtreader.GetInt32(5); } else { NewCommenceDate = 0; } 
                }

                sjamtreader.Close();
                dm.connclose();
                return true;
            }
            else
            {
                dm.connclose();
                return false;
            }
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw (Ex);
        }
    }


	#endregion

   

}

    

//#region ----enum for SwarnaJayanthi type------
//enum SJType
//{
//    Death,
//    Refund,
//    Maturity
//};
//#endregion
