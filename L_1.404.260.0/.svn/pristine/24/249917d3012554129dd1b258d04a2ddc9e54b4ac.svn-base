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
using System.Collections.Generic;

/// <summary>
/// Summary description for AmtPolComyear
/// </summary>
public class AmtPolComyear
{
    polMasRead pmr;
    DateDifference dd;
    General gg;
    dateValidation dv;
    private int com;
    private int acccomdt;
    private int mode;
    private int polmonths;
    private int noofprems;
    private double polcomamt, paidprems, prem;
    private List<long> ledDemand;
    private List<long> ledPaidDemand;

	public AmtPolComyear(long polno, int dtofaccident, string mos, DataManager dm)
	{
        int x=24;
        string greater;
        
        pmr = new polMasRead(int.Parse(polno.ToString()), dm,mos);
        gg = new General();
        com = pmr.COM;
        
        if (com != 0)
        {
            if (com == dtofaccident)//When Death occured on com date query should be changed this way
            {
                greater = ">=";
            }
            else
            {
                greater = ">";
            }
            mode = pmr.MOD;
            if (int.Parse(dtofaccident.ToString().Substring(4, 4)) < int.Parse(com.ToString().Substring(4, 4)))
            {
                acccomdt = int.Parse(dtofaccident.ToString().Substring(0, 4) + com.ToString().Substring(4, 4));
            }
            else
            {
                acccomdt = int.Parse(Convert.ToString(int.Parse(dtofaccident.ToString().Substring(0, 4)) + 1) + com.ToString().Substring(4, 4));
            }

            acccomdt =gg.DateAdjust(acccomdt, 0, -1, 0);
            if (acccomdt < dtofaccident) { dtofaccident = acccomdt; }
            dd = new DateDifference(dtofaccident, acccomdt);

            #region-----------------------No of Premiums--------------------------
            if (mode == 1) { x = 12; }
            else if (mode == 2) { x = 6; }
            else if (mode == 3) { x = 3; }
            else if (mode == 4) { x = 1; }
            polmonths = dd.totMonths;
            if (dd.Days > 0) { polmonths++; }
            noofprems = polmonths / x;
            #endregion
            

            //create demands for ledger
            //by chandana
            ledDemand = new List<long>();
            ledDemand = GetDueToCompleteYear(dtofaccident, noofprems, mode,com);
            ledDemand.Sort();

            ledPaidDemand = new List<long>();
            ledPaidDemand = GetLedgerDue(polno, dm);
            ledPaidDemand.Sort();

            //string disablemassel = "select * from LCLM.DISABLE_MAS where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "' and PREM_AMT>0";
                //if (dm.existRecored(disablemassel) != 0)
                //{
                //    {
                //        diaMasRead dmr = new diaMasRead(int.Parse(polno.ToString()), distype.ToString(), mos, intimno, dm);
                //        prem = dmr.Premamt;
                //    }
                //}
                //else
                //{
                prem = pmr.PRM;
            //}
            polcomamt = prem * noofprems;

            #region--------------------Reducing Paid Premiums---------------
            double premcount = 0;
            long _dues = 0;
            //string ledgersel = "select count(LLPRM) from LCLM.LEDGER where LLDUE||'" + com.ToString().Substring(6, 2) + "'" + greater + dtofaccident + " and LLDUE||'" + com.ToString().Substring(6, 2) + "'<=" + acccomdt + " and LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 )";
            string ledgersel = "select LLDUE from LCLM.LEDGER where LLDUE||'" + com.ToString().Substring(6, 2) + "'" + greater + dtofaccident + " and LLDUE||'" + com.ToString().Substring(6, 2) + "'<=" + acccomdt + " and LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 )";


            if (dm.existRecored(ledgersel) != 0)
            {
                dm.readSql(ledgersel);
                OracleDataReader ledgerreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while(ledgerreader.Read())
                {
                    if (!ledgerreader.IsDBNull(0))
                    {
                        _dues = ledgerreader.GetInt64(0);
                        ledDemand.Remove(_dues);
                        premcount++;
                    }
                }
                ledgerreader.Close();
                ledgerreader.Dispose();
            }

            if (ledPaidDemand.Count > 0)
            {
                for (int i = 0; i < ledPaidDemand.Count; i++)
                {
                    long ledPaidDue = ledPaidDemand[i];
                    for (int j = 0; j < ledDemand.Count; j++)
                    {
                        long ledDemandDue = ledDemand[j];
                        if (ledPaidDue == ledDemandDue)
                        {
                            ledDemand.Remove(ledPaidDue);
                            premcount++;
                        }
                    }
                }
            }

            paidprems = premcount * prem;     
            #endregion

            polcomamt -= paidprems;
        }
        else
        {
            polcomamt = 0;
        }
    }


    private List<long> GetDueToCompleteYear(long dateOfAccident, int noOfPremium, int mode,long commencement)
    {
        //by chandana
        int tmp;
        string tmpPolComDt = "";
        bool isDateValid = false;
        //DateTime? _dt = null;

        dv = new dateValidation();

        DateTime? _dateOfDeath = null;

        DateTime? _polComDate = null;


        //DateTime? _dod = null;
        List<long> _rtnlst = new List<long>();

       // _dt = new DateTime(int.Parse(startDueOrDate.ToString().Substring(0, 4)), int.Parse(startDueOrDate.ToString().Substring(4, 2)), 1);
        _dateOfDeath = new DateTime(int.Parse(dateOfAccident.ToString().Substring(0, 4)), int.Parse(dateOfAccident.ToString().Substring(4, 2)), int.Parse(dateOfAccident.ToString().Substring(6, 2)));
        tmp = mode == 1 ? 12 : mode == 2 ? 6 : mode == 3 ? 3 : mode == 4 ? 1 : 0;
        //if (int.Parse(commencement.ToString().Substring(4, 4)) < int.Parse(startDueOrDate.ToString().Substring(4, 4)))
        //    //_dt = _dt.Value.AddMonths(tmp);
        //    _tmpDt = _tmpDt.Value.AddMonths(tmp);

        tmpPolComDt = dateOfAccident.ToString().Substring(0, 4) + commencement.ToString().Substring(4, 2) + commencement.ToString().Substring(6, 2);
        isDateValid = dv.dateValid(tmpPolComDt);

        if (tmpPolComDt.Substring(4, 4) == "0229" && !isDateValid)
        {
            tmpPolComDt = (int.Parse(tmpPolComDt) - 1).ToString();
            _polComDate = new DateTime(int.Parse(tmpPolComDt.ToString().Substring(0, 4)), int.Parse(tmpPolComDt.ToString().Substring(4, 2)), int.Parse(tmpPolComDt.ToString().Substring(6, 2))); 
        }
        else
        {
            _polComDate = new DateTime(int.Parse(dateOfAccident.ToString().Substring(0, 4)), int.Parse(commencement.ToString().Substring(4, 2)), int.Parse(commencement.ToString().Substring(6, 2)));
        }

        if (_polComDate <= _dateOfDeath)
            _polComDate = _polComDate.Value.AddYears(1);

        for (int i = 0; i < noOfPremium; i++)
        {
            _polComDate = _polComDate.Value.AddMonths(-tmp);
            _rtnlst.Add(long.Parse(_polComDate.Value.Year.ToString() + (_polComDate.Value.Month < 10
                            ? "0" + _polComDate.Value.Month.ToString()
                            : _polComDate.Value.Month.ToString())));

            
        }
     

       return _rtnlst;

    }

    private List<long> GetLedgerDue(long polNo, DataManager dm)
    {
        long paidDues = 0;
        List<long> paidDuelst = new List<long>();

        string ledgersel = "select LLDUE from LCLM.LEDGER where LLPOL=" + polNo + " and (lltyp = 1 or lltyp = 2 )";

        if (dm.existRecored(ledgersel) != 0)
        {
            dm.readSql(ledgersel);
            OracleDataReader ledgerreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (ledgerreader.Read())
            {
                if (!ledgerreader.IsDBNull(0))
                {
                    paidDues = ledgerreader.GetInt64(0);
                    paidDuelst.Add(paidDues); 
                }
            }
            ledgerreader.Close();
            ledgerreader.Dispose();
        }

        return paidDuelst;

    }

    

    public List<long> DuesToComplete
    {
        get { return ledDemand; }
    }

    public double Polcomamt
    {
        get { return polcomamt; }
        set { polcomamt = value; }
    }
    public int Accomdt
    {
        get { return acccomdt; }
        set { acccomdt = value; }
    }
    public int Noofprems
    {
        get { return noofprems; }
        set { noofprems = value; }
    }
}
