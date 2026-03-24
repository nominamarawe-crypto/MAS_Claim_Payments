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
using System.Data.Odbc;


/// <summary>
/// Last Updated Dushan 28/08/2009
/// /// Last Updated Buddhika 21/08/2009
/// </summary>
/// 
[Serializable()]
public class General
{
    private double bonus = 0;
    private int duedate = 0;
    DataManager Ora_DataManager;

    public General()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Boolean DthoutExist(long polno)
    {
        DataManager dm = new DataManager();
        try
        {

            string dthoutsel = "select * from LPHS.DTHOUT where POLNO=" + polno + " and TRANSCODE='C'";
            if (dm.existRecored(dthoutsel) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.connClose();
            throw Ex;
        }
    }

    public string LapsetoInforce(long polno, int dtofdth, DataManager dm)
    {
        int table, com, lapsedate, days = 0, years = 0, months = 0, paymode, due = 0, pac = 0, x;

        string status, pmcode;
        try
        {
            polMasRead pmr = new polMasRead(int.Parse(polno.ToString()), dm);
            DateDifference dd;
            table = pmr.TBL;
            com = pmr.COM;
            paymode = pmr.MOD;
            pac = pmr.PAC;
            pmcode = pmr.COD;

            if (paymode == 5)
            {
                status = "I";
            }
            else
            {
                switch (paymode)
                {
                    case 1: x = 12; break;
                    case 2: x = 6; break;
                    case 3: x = 3; break;
                    default: x = 1; break;
                }

                #region------------Demand Reader---------------
                string maxduesel = "select max(LLDUE) from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3)";
                if (dm.existRecored(maxduesel) != 0)
                {
                    dm.readSql(maxduesel);
                    OracleDataReader demandreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (demandreader.Read())
                    {
                        if (!demandreader.IsDBNull(0)) { due = demandreader.GetInt32(0); } else { due = 0; }
                    }
                    demandreader.Close();
                    demandreader.Dispose();
                }
                #endregion

                duedate = int.Parse(due.ToString() + com.ToString().Substring(6, 2));
                duedate = this.DateAdjust(duedate, 0, x, 0);

                #region----------Unsettled Dues-------------
                int unsetdems = 0, totmonths, yrs, mnths;
                string unsetdemsel = "select count(pddue) from lphs.demand where PDPOL=" + polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue < " + due + "";
                if (dm.existRecored(unsetdemsel) != 0)
                {
                    dm.readSql(unsetdemsel);
                    OracleDataReader unsetdemreader = dm.oraComm.ExecuteReader();
                    while (unsetdemreader.Read())
                    {
                        if (!unsetdemreader.IsDBNull(0)) { unsetdems = unsetdemreader.GetInt32(0); }
                    }
                    unsetdemreader.Close();
                }
                totmonths = unsetdems * x;
                yrs = totmonths / 12;
                mnths = totmonths % 12;
                duedate = this.DateAdjust(duedate, 0, -mnths, -yrs);
                #endregion

                #region------------LpolHis Reader For Child policies---------------
                bool childPlnFlag = false;
                if (table == 34 || table == 38 || table == 39 || table == 46 || table == 49)
                {
                    //string lpolHisSel = "select * from LPHS.LPOLHIS a where A.PHPOL=" + polno + " and A.PHMOS='M'";
                    string lpolHisSel = "select B.DDTOFDTH from LPHS.LPOLHIS a, LPHS.DTHINT b " +
                                        "where a.phpol=B.DPOLNO and A.PHCLAIM=B.DCLM and  A.PHPOL=" + polno + "  and A.PHMOS='M'";

                    if (dm.existRecored(lpolHisSel) != 0)
                    {
                        dm.readSql(lpolHisSel);
                        OracleDataReader lPolHisReader = dm.oraComm.ExecuteReader();
                        while (lPolHisReader.Read())
                        {
                            if (!lPolHisReader.IsDBNull(0)) { dtofdth = Convert.ToInt32(lPolHisReader.GetInt32(0)); }
                        }
                        lPolHisReader.Close();
                    } 
                }

                #endregion

                if (pac > 50) { months = 6; }
                else
                {
                    dd = new DateDifference(com, duedate);
                    if (table == 27 || table == 50)
                    {
                        if (dd.Years >= 1) { years = 2; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                    else
                    {
                        if (dd.Years >= 3) { months = 6; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                }
                if (pmcode.Equals("F"))
                {
                    status = "I";
                }
                else if (this.DateAdjust(duedate, days, months, years) >= dtofdth)
                {
                    status = "I";
                }
                else
                {
                    status = "L";
                }
            }

            return status;
        }
        catch (Exception Ex)
        {
            throw new Exception("No ledger Records Found...");
        }
    }
   
 
    //public string LapsetoInforce(DatabaseAccessLayer dal, int polno, int dtofdth, int table, int com, int paymode, int pac, string pmcode,int PolicyTerm)
    //{
    //    int  lapsedate, days = 0, years = 0, months = 0,  due = 0,  x;
    //    int maturityDate = com + (PolicyTerm * 10000);

    //    if (table == 3 && dtofdth > maturityDate)
    //        dtofdth = maturityDate;
    //    string status;
    //    try
    //    {
    //        DateDifference dd;
    //        if (paymode == 5)
    //        {
    //            status = "I";
    //        }
    //        else
    //        {
    //            switch (paymode)
    //            {
    //                case 1: x = 12; break;
    //                case 2: x = 6; break;
    //                case 3: x = 3; break;
    //                default: x = 1; break;
    //            }

    //            #region------------Demand Reader---------------
    //            string maxduesel = "select  max(LLDUE) from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 )";
              
    //                using (DataTable dataTable = dal.ReadSQLtoDataTable(maxduesel))
    //                {
    //                    using (DataTableReader ledgerReader = dataTable.CreateDataReader())
    //                    {
    //                        while (ledgerReader.Read())
    //                        {
    //                            if (!ledgerReader.IsDBNull(0)) { due = Convert.ToInt32(ledgerReader[0]); }
    //                            else { throw new Exception("No Ledger Records found"); }
    //                        }
    //                    }
    //                }
    //                duedate = int.Parse(due.ToString() + com.ToString().Substring(6, 2));
    //                duedate = this.DateAdjust(duedate, 0, x, 0);
                
                   
    //            #endregion

    //            #region----------Unsettled Dues-------------
    //            int unsetdems = 0, totmonths, yrs, mnths;
    //            string unsetdemsel = "select count(pddue) from lphs.demand where PDPOL=" + polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue < " + due + "";

    //            using (DataTable dataTable = dal.ReadSQLtoDataTable(unsetdemsel))
    //            {
    //                using (DataTableReader demandreader = dataTable.CreateDataReader())
    //                {
    //                    while (demandreader.Read())
    //                    {
    //                        if (!demandreader.IsDBNull(0)) { unsetdems = Convert.ToInt32(demandreader[0]); }
    //                    }
    //                }
    //            }
                
    //            totmonths = unsetdems * x;
    //            yrs = totmonths / 12;
    //            mnths = totmonths % 12;
    //            duedate = this.DateAdjust(duedate, 0, -mnths, -yrs);
    //            #endregion

    //            if (pac > 50) { months = 6; }
    //            else
    //            {
    //                dd = new DateDifference(com, duedate);
    //                if (table == 27 || table == 50)
    //                {
    //                    if (dd.Years >= 1) { years = 2; }
    //                    else if (paymode == 4) { days = 15; }
    //                    else { days = 30; }
    //                }
    //                else
    //                {
    //                    if (dd.Years >= 3) { months = 6; }
    //                    else if (paymode == 4) { days = 15; }
    //                    else { days = 30; }
    //                }
    //            }
    //            if (duedate >= maturityDate)
    //            {
    //                status = "I";
    //            }
    //            else
    //            {
    //                if (pmcode.Equals("F"))
    //                {
    //                    status = "I";
    //                }
    //                else if (this.DateAdjust(duedate, days, months, years) >= dtofdth)
    //                {
    //                    status = "I";
    //                }
    //                else
    //                {
    //                    status = "L";
    //                }
    //            }
    //        }

    //        // Added By Shamaal
    //        // Check if the policy is paid up. If it is change the state in to Laps (L)
    //        string type = "";
    //        string queryNew = "select LPCOD from LPHS.LIFLAPS where LPPOL=" + polno + " ";

    //        Ora_DataManager = new DataManager();
            
    //        if (Ora_DataManager.existRecored(queryNew) != 0)
    //        {
    //            Ora_DataManager.readSql(queryNew);
    //            OracleDataReader dthreader = Ora_DataManager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //            while (dthreader.Read())
    //            {
    //                if (!dthreader.IsDBNull(0)) { type = dthreader.GetString(0); }
                   
    //            }
    //            dthreader.Close();
    //            dthreader.Dispose();
               
    //        }

    //        if (type =="P")
    //        {
    //            status = "L";
    //        }

    //        return status;
    //    }
    //    catch (Exception Ex)
    //    {
    //        throw new Exception("No ledger Records Found...");
    //    }
    //}

    public string LapsetoInforce(DatabaseAccessLayer dal, int polno, int dtofdth, int table, int com, int paymode, int pac, string pmcode, int PolicyTerm, string mos)
    {
        int lapsedate, days = 0, years = 0, months = 0, due = 0, x;
        int payTerm = 0, diffTrm = 0, tempDueDate = 0, endPayingTermDate = 0;
        int maturityDate = com + (PolicyTerm * 10000);
        bool isTable58Infor = false;

        if (table == 3 && dtofdth > maturityDate)
            dtofdth = maturityDate;
        string status;
        try
        {
            DateDifference dd;
            if (paymode == 5)
            {
                status = "I";
            }
            else
            {
                switch (paymode)
                {
                    case 1: x = 12; break;
                    case 2: x = 6; break;
                    case 3: x = 3; break;
                    default: x = 1; break;
                }

                #region------------PayTerm Reader---------------
                string patTrmsel = "select pmptr from lphs.premast where pmpol=" + polno + "";

                using (DataTable dataTable = dal.ReadSQLtoDataTable(patTrmsel))
                {
                    using (DataTableReader premastReader = dataTable.CreateDataReader())
                    {
                        while (premastReader.Read())
                        {
                            if (!premastReader.IsDBNull(0)) { payTerm = Convert.ToInt32(premastReader[0]); }
                            else { throw new Exception("No Policy Records found"); }
                        }
                    }
                }

                if (table == 58)
                {
                    string patTrmselLapses = "select lpptr from lphs.liflaps where lppol=" + polno + "";

                    using (DataTable dataTable = dal.ReadSQLtoDataTable(patTrmselLapses))
                    {
                        using (DataTableReader lapeseReader = dataTable.CreateDataReader())
                        {
                            while (lapeseReader.Read())
                            {
                                if (!lapeseReader.IsDBNull(0)) { payTerm = Convert.ToInt32(lapeseReader[0]); }
                                else { throw new Exception("No Policy Records found"); }
                            }
                        }
                    }
                }

                #endregion

                #region------------Demand Reader---------------
                //string maxduesel = "select  max(LLDUE) from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3)";
                string maxduesel = "select  max(LLDUE) from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldat<=" + dtofdth + "";

                using (DataTable dataTable = dal.ReadSQLtoDataTable(maxduesel))
                {
                    using (DataTableReader ledgerReader = dataTable.CreateDataReader())
                    {
                        while (ledgerReader.Read())
                        {
                            if (!ledgerReader.IsDBNull(0)) { due = Convert.ToInt32(ledgerReader[0]); }
                            else { throw new Exception("No Ledger Records found"); }
                        }
                    }
                }
                duedate = int.Parse(due.ToString() + com.ToString().Substring(6, 2));
                duedate = this.DateAdjust(duedate, 0, x, 0);


                if (table == 30 && PolicyTerm == payTerm)
                {
                    payTerm = PolicyTerm - 5;
                    diffTrm = PolicyTerm - payTerm; 
                    tempDueDate = duedate + (diffTrm * 10000);
                }

                //Task 31420 - Table 58
                if (table == 58 && payTerm > 0)
                {
                    endPayingTermDate = com + (payTerm * 10000);

                    if (duedate >= endPayingTermDate) { isTable58Infor = true; }
                }

                #region------------LpolHis Reader For Child policies---------------
                bool childPlnFlag = false;
                if (table == 34 || table == 38 || table == 39 || table == 46 || table == 49 || table == 56)
                {
                    string lpolHisRecsSel = "select * from LPHS.LPOLHIS a where A.PHPOL=" + polno + " and A.PHMOS='M'";
                    using (DataTable lpolHisRecTable = dal.ReadSQLtoDataTable(lpolHisRecsSel))
                    {
                        using (DataTableReader lpolHisRecReader = lpolHisRecTable.CreateDataReader())
                        {
                            while (lpolHisRecReader.Read())
                            { 
                                childPlnFlag = true;
                            }
                        }
                    }

                    if (childPlnFlag)
                    {
                        //Table 56 changes
                        //string lpolHisSel = "select B.DDTOFDTH from LPHS.LPOLHIS a, LPHS.DTHINT b " +
                        //                    "where a.phpol=B.DPOLNO and A.PHCLAIM=B.DCLM and  A.PHPOL=" + polno + "  and A.PHMOS='M'";
                        string lpolHisSel = "select B.DDTOFDTH from LPHS.LPOLHIS a, LPHS.DTHINT b, LPHS.DTHREF c "+
                                            "where a.phpol=B.DPOLNO and A.PHCLAIM=B.DCLM and a.phpol=C.DRPOLNO and "+
                                            "A.PHCLAIM=C.DRCLMNO and  A.PHPOL=" + polno + "  and A.PHMOS='M' and c.memoaprv='Y'";

                        using (DataTable lpolHisTable = dal.ReadSQLtoDataTable(lpolHisSel))
                        {
                            using (DataTableReader lpolHisReader = lpolHisTable.CreateDataReader())
                            {
                                while (lpolHisReader.Read())
                                {
                                    if (!lpolHisReader.IsDBNull(0)) { dtofdth = Convert.ToInt32(lpolHisReader[0]); } 
                                }
                            }
                        }
                    }
                }

                #endregion

                #endregion

                #region----------Unsettled Dues-------------
                int unsetdems = 0, totmonths, yrs, mnths;
                string unsetdemsel = "select count(pddue) from lphs.demand where PDPOL=" + polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue < " + due + "";

                using (DataTable dataTable = dal.ReadSQLtoDataTable(unsetdemsel))
                {
                    using (DataTableReader demandreader = dataTable.CreateDataReader())
                    {
                        while (demandreader.Read())
                        {
                            if (!demandreader.IsDBNull(0)) { unsetdems = Convert.ToInt32(demandreader[0]); }
                        }
                    }
                }

                totmonths = unsetdems * x;
                yrs = totmonths / 12;
                mnths = totmonths % 12;
                duedate = this.DateAdjust(duedate, 0, -mnths, -yrs);
                #endregion

                if (pac > 50) { months = 6; }
                else
                {
                    dd = new DateDifference(com, duedate);
                    //Task 27711 
                    //if (table == 27 || table == 50)
                    if (table == 27 || (table == 50 && mos == "M"))
                    {
                        if (dd.Years >= 1) { years = 2; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                    else if (table == 55)
                    {
                        if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                    else if(table == 58)
                    {
                        if (dd.Years >= 2) { months = 6; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                    else
                    {
                        if (dd.Years >= 3) { months = 6; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                }
                if ((duedate >= maturityDate || tempDueDate >= maturityDate) && (table != 12 && PolicyTerm == 0))
                {
                    status = "I";
                }
                else
                {
                    if (pmcode.Equals("F") || isTable58Infor)
                    {
                        status = "I";
                    }
                    else if (this.DateAdjust(duedate, days, months, years) >= dtofdth)
                    {
                        status = "I";
                    }
                    else
                    {
                        status = "L";
                    }
                }
            }

            // Added By Shamaal
            // Check if the policy is paid up. If it is change the state in to Laps (L)
            string type = "";
            string queryNew = "select LPCOD from LPHS.LIFLAPS where LPPOL=" + polno + " ";

            Ora_DataManager = new DataManager();

            if (Ora_DataManager.existRecored(queryNew) != 0)
            {
                Ora_DataManager.readSql(queryNew);
                OracleDataReader dthreader = Ora_DataManager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthreader.Read())
                {
                    if (!dthreader.IsDBNull(0)) { type = dthreader.GetString(0); }

                }
                dthreader.Close();
                dthreader.Dispose();

            }

            string lpolHisQuery = "select phcod,phsta from lphs.lpolhis where phpol=" + polno + " ";
            string hisCode = "";
            string hisSta = "";

            Ora_DataManager = new DataManager();

            if (Ora_DataManager.existRecored(lpolHisQuery) != 0)
            {
                Ora_DataManager.readSql(lpolHisQuery);
                OracleDataReader dthHistryreader = Ora_DataManager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthHistryreader.Read())
                {
                    if (!dthHistryreader.IsDBNull(0)) { hisCode = dthHistryreader.GetString(0); }
                    if (!dthHistryreader.IsDBNull(1)) { hisSta = dthHistryreader.GetString(1); }
                }
                dthHistryreader.Close();
                dthHistryreader.Dispose();

            }

            if (type == "P")
            {
                status = "L";
            }

            if (hisCode == "P" && hisSta == "L")
            {
                status = "L";
            }

            if (hisCode == "F" && hisSta == "I")
            {
                status = "I";
            }

            return status;
        }
        catch (Exception Ex)
        {
            throw new Exception("No ledger Records Found...");
        }
    }
    
    
    public string policyStatusAtDeath(DatabaseAccessLayer dal, long polno, int dtofdth, int paymode, int table, int com, int pac, string pmcode)
    {
        int lapsedate, days = 0, years = 0, months = 0, due = 0, x;

        string status;
        try
        {
            DateDifference dd;
            if (paymode == 5)
            {
                status = "I";
            }
            else
            {
                switch (paymode)
                {
                    case 1: x = 12; break;
                    case 2: x = 6; break;
                    case 3: x = 3; break;
                    default: x = 1; break;
                }

                #region------------Demand Reader---------------
                //string maxduesel = "select max(LLDUE) from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 )";
                if (dal.IsRecordExist("select * from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 )"))
                {
                    using (DataTable dataTable = dal.ReadSQLtoDataTable("select max(LLDUE) from LCLM.LEDGER where LLPOL=" + polno + " and (lltyp = 1 or lltyp = 2 )"))
                    {
                        using (DataTableReader ledgerReader = dataTable.CreateDataReader())
                        {
                            while (ledgerReader.Read())
                            {
                                if (!ledgerReader.IsDBNull(0)) { due = Convert.ToInt32(ledgerReader[0]); }
                            }
                        }
                    }

                }
                else { throw new Exception("No Ledger Records found"); }
                #endregion

                duedate = int.Parse(due.ToString() + com.ToString().Substring(6, 2));
                duedate = this.DateAdjust(duedate, 0, x, 0);

                #region----------Unsettled Dues-------------
                int unsetdems = 0, totmonths, yrs, mnths;
                //string unsetdemsel = "select * from lphs.demand where PDPOL=" + polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue<" + due + "";
                //if (dal.IsRecordExist(unsetdemsel))
                // {
                using (DataTable dataTable = dal.ReadSQLtoDataTable("select count(pddue) from lphs.demand where PDPOL=" + polno + " and (pdcod='1' or pdcod='2' or pdcod='3') and pddue<" + due + ""))
                {
                    using (DataTableReader unsetdemreader = dataTable.CreateDataReader())
                    {
                        while (unsetdemreader.Read())
                        {
                            if (!unsetdemreader.IsDBNull(0)) { unsetdems = Convert.ToInt32(unsetdemreader[0]); }
                        }
                    }
                }
                // }
                totmonths = unsetdems * x;
                yrs = totmonths / 12;
                mnths = totmonths % 12;
                duedate = this.DateAdjust(duedate, 0, -mnths, -yrs);
                #endregion

                if (pac > 50) { months = 6; }
                else
                {
                    dd = new DateDifference(com, duedate);
                    if (table == 27 || table == 50)
                    {
                        if (dd.Years >= 1) { years = 2; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                    else
                    {
                        if (dd.Years >= 3) { months = 6; }
                        else if (paymode == 4) { days = 15; }
                        else { days = 30; }
                    }
                }
                if (pmcode.Equals("F"))
                {
                    status = "I";
                }
                else if (this.DateAdjust(duedate, days, months, years) >= dtofdth)
                {
                    status = "I";
                }
                else
                {
                    status = "L";
                }
            }

            return status;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
   
    public int DateAdjust(int date, int days, int months, int years)
    {
        string monthstr, daystr;
        int year, month, day;
        year = int.Parse(date.ToString().Substring(0, 4));
        month = int.Parse(date.ToString().Substring(4, 2));
        day = int.Parse(date.ToString().Substring(6, 2));

        day += days;
        month += months;
        year += years;

        if (month > 12)
        {
            month -= 12;
            year++;
        }

        if (month == 2 && day > 28)
        {
            day -= 28;
            month++;
        }
        else if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && day > 31)
        {
            day -= 31;
            month++;
        }
        else if ((month == 4 || month == 6 || month == 9 || month == 11 ) && day > 30)
        {
            day -= 30;
            month++;
        }
        if (month > 12)
        {
            month -= 12;
            year++;
        }
        if (month <= 0)
        {
            month += 12;
            year--;
        }
        monthstr = month.ToString();
        daystr = day.ToString();
        if (month < 10) { monthstr = "0" + month.ToString(); }
        if (day < 10) { daystr = "0" + day.ToString(); }
        int retdate = int.Parse(year.ToString() + monthstr + daystr);
        return retdate;
    }

    public string Formatdate(int date)
    {
        string retdate;

        if (date.ToString().Length == 8)
        {
            retdate = date.ToString().Substring(0, 4) + "/" + date.ToString().Substring(4, 2) + "/" + date.ToString().Substring(6, 2);
        }
        else if (date.ToString().Length == 6)
        {
            retdate = date.ToString().Substring(0, 4) + "/" + date.ToString().Substring(4, 2);
        }
        else
        {
            retdate = "-";
        }
        return retdate;
    }

    public double minumuthulapsepayment(long polno, string mos, DataManager dmm)
    {
        double paidup = 0, vestedbon = 0, interbon = 0, totalval;
        try
        {
            string dthrefsel = "select SMASS_PVAL, DRVESTEDBON, DRINTERIMBON from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
            if (dmm.existRecored(dthrefsel) != 0)
            {
                dmm.readSql(dthrefsel);
                OracleDataReader dthrefreader = dmm.oraComm.ExecuteReader();
                while (dthrefreader.Read())
                {
                    if (!dthrefreader.IsDBNull(0)) { paidup = dthrefreader.GetDouble(0); } else { paidup = 0; }
                    if (!dthrefreader.IsDBNull(1)) { vestedbon = dthrefreader.GetDouble(1); } else { vestedbon = 0; }
                    if (!dthrefreader.IsDBNull(2)) { interbon = dthrefreader.GetDouble(2); } else { interbon = 0; }
                }
                dthrefreader.Close();
                //dthrefreader.Dispose();
                bonus = vestedbon + interbon;
            }
            else
            {
                BonusCal bcal = new BonusCal();
                bonus = bcal.VestedBonus(polno, mos)[2];
            }
            totalval = paidup; //+ vestedbon + interbon;            
            return totalval;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public void Paymentcount(long polno, string mos, int noflag, DataManager dmread, DataManager dmex)
    {
        try
        {
            int maxpaid = 0;
            string dthseqfiel, dthreffield;

            //flag=1 for payment count and flag=2 for admit count
            if (noflag == 1) { dthseqfiel = "SQPAIDNO"; dthreffield = "DRPAIDNO"; }
            else { dthseqfiel = "SQADMITNO"; dthreffield = "DRADMITNO"; }

            string paycountsel = "select max(" + dthseqfiel + ") from LPHS.DTHSEQ";
            dmread.readSql(paycountsel);
            OracleDataReader paycountreader = dmread.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (paycountreader.Read())
            {
                if (paycountreader.IsDBNull(0)) { maxpaid = paycountreader.GetInt32(0); }
            }
            paycountreader.Close();
            //paycountreader.Dispose();

            maxpaid++;
            string paidnoupd = "update LPHS.DTHSEQ set " + dthseqfiel + "=" + maxpaid + "";
            dmex.insertRecords(paidnoupd);

            string dthrefupd = "update LPHS.DTHREF set " + dthreffield + "=" + maxpaid + " where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
            dmex.insertRecords(dthrefupd);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public int Write_Deposit_Adjestment(int brcode, long polno, string IPAddress, int EPF, DataManager dm)
    {
        int status = 0;
        double Deposit = 0;
        try
        {
            string rcptno = this.createAdjRcNo(brcode, DateTime.Now.Year, 55);

            int rcptnoInt = int.Parse(rcptno.ToString().Substring(rcptno.Length - 7, 7));

            polMasRead pmr = new polMasRead(int.Parse(polno.ToString()), dm);

            string depositsql = "select DPTAM,DPBOC,DPSUR,DPINT from lpay.deposit where DPPOL=" + polno + " and dpdel <> 1 and DPTAM > 0 ";
            dm.readSql(depositsql);
            OracleDataReader depositreader = dm.oraComm.ExecuteReader();

            Int64 boc = 0;
            string surname = " ";
            while (depositreader.Read())
            {
                double depamount = 0;
                if (!depositreader.IsDBNull(0))
                {
                    depamount = depositreader.GetDouble(0);
                    Deposit = Deposit + depamount;
                }
                if (!depositreader.IsDBNull(1))
                    boc = depositreader.GetInt64(1);
                if (!depositreader.IsDBNull(2))
                    surname = depositreader.GetString(2);
                if (!depositreader.IsDBNull(3))
                    surname = depositreader.GetString(3) + " " + surname;

                //string InsertDeposithis = "";
                //dm.insertRecords(InsertDeposithis);

                string DepositUpdate = "UPDATE LPAY.DEPOSIT SET DPTAM = 0 WHERE DPBOC=" + boc + "";
                dm.insertRecords(DepositUpdate);

                string InsertAdjdetails = " INSERT INTO LPHS.ADJDETAILS (ADBRN, ADREC, ADJDAT, ADJCOD, ADBOC, ADDDT, ADAMT, ADPOL, ADDEL, ADNAME) " +
                          " VALUES (" + brcode + "," + rcptnoInt + "," + DateTime.Now.ToString("yyyyMMdd")
                          + ",55," + boc + "," + DateTime.Now.ToString("yyyyMMdd") + "," + depamount
                          + "," + polno + ",0,'" + surname + "')";
                dm.insertRecords(InsertAdjdetails);
            }
            depositreader.Close();

            string InsertAdjpaymas = "INSERT INTO LPHS.ADJPAYMAS (LPBRN, LPPDT, LPBTP, LPREC, LPPOL, LPPTP, LPAM1, LPCCO, LPCA1, LPCA2, LPCA3, LPCA4, LPSBR, " +
                         " LPEDT, LPTIM, LPIPA, LPACD, LPOPR, LPSTA, LPCUR, LPCRT, LPDDT, LPDEN, LPDCOM, LPTBL, LPTRM, LPINST, LPPA, LPMD, LPAGT, " +
                         " LPORG, LONNO, LONSUF, LON_REC_NO) " +
                         " VALUES(" + brcode + "," + DateTime.Now.ToString("yyyyMMdd") + ",55," + rcptnoInt
                         + "," + polno + ",'O'," + Deposit + ",0," + Deposit + ",0,0,0,0," + DateTime.Now.ToString("yyyyMMdd")
                         + ",to_char(to_date('" + DateTime.Now.ToString("hh:mm:ss") + "','hh:MI:SS'),'hh:MI:SS'),'" + IPAddress
                         + "',0," + EPF + ",0,'LKR',1,0,0," + pmr.COM + "," + pmr.TBL + "," + pmr.TRM + ",0," + pmr.PAC + "," + pmr.MOD + "," + pmr.AGT + "," + pmr.ORG + ",0,0,0)";
            dm.insertRecords(InsertAdjpaymas);
        }
        catch (Exception exp)
        {
            status = -1;
            throw exp;
        }
        return status;
    }

    protected string createAdjRcNo(int brn, int year, int adjCode)
    {
        DataManager dmread = new DataManager();
        string rcptnoStr = "";
        int recieptNo = 0;

        string adjnoSelect = "select adrcno from lphs.adjno where adbrno=" + brn + " and adyear=" + year + " and adtype = " + adjCode + " ";
        if (dmread.existRecored(adjnoSelect) == 0)
        {
            string adjnoInsert = "INSERT INTO LPHS.ADJNO (ADBRNO ,ADYEAR ,ADTYPE ,ADRCNO ) VALUES (" + brn + " ," + year + " ," + adjCode + " ,1  )";
            dmread.insertRecords(adjnoInsert);
            recieptNo++;
        }
        else
        {
            dmread.readSql(adjnoSelect);
            OracleDataReader adjnoReader = dmread.oraComm.ExecuteReader();
            while (adjnoReader.Read())
            {
                recieptNo = adjnoReader.GetInt32(0);
                recieptNo++;
            }
            adjnoReader.Close();
            //adjnoReader.Dispose();
            string adjnoUpdate = "update lphs.adjno set ADRCNO=" + recieptNo + " where adbrno=" + brn + " and adyear=" + year + " and adtype = " + adjCode + " ";
            dmread.insertRecords(adjnoUpdate);
        }

        rcptnoStr = adjCode.ToString() + zeroFill(recieptNo, 7);

        return rcptnoStr;
    }

    protected string zeroFill(int num, int length)
    {
        int numLength = int.Parse((num.ToString().Length).ToString());
        string formattedNum = num.ToString();
        for (int i = 0; i < (length - numLength); i++)
        {
            formattedNum = "0" + formattedNum;

        }
        return formattedNum;
    }

    public double Deposit(long polno, DataManager dm)
    {
        double deposit = 0;
        string depositsql = "select sum(DPTAM) from lpay.deposit where DPPOL=" + polno + " and dpdel <> 1 ";
        if (dm.existRecored(depositsql) != 0)
        {
            dm.readSql(depositsql);
            OracleDataReader depositreader = dm.oraComm.ExecuteReader();
            while (depositreader.Read())
            {
                if (!depositreader.IsDBNull(0)) { deposit = depositreader.GetDouble(0); } else { deposit = 0; }
            }
            depositreader.Close();
        }
        return deposit;
    }

    public int StrToNumFilter(string strValue)
    {
        int num = 0;
        string letter, number = "";
        int length = strValue.Length;
        for (int i = 0; i < length; i++)
        {
            letter = strValue.Substring(i, 1);
            if (letter.Equals("0") || letter.Equals("1") || letter.Equals("2") || letter.Equals("3") || letter.Equals("4"))
            {
                number = number + letter;
            }
            else if (letter.Equals("5") || letter.Equals("6") || letter.Equals("7") || letter.Equals("8") || letter.Equals("9"))
            {
                number = number + letter;
            }
        }
        if (!number.Equals("")) { num = int.Parse(number); }
        return num;
    }

    public string NameWithInitials(string fullname)
    {
        string surname = "";
        string initials = "";
        string chara = "";
        string status = "";
        for (int i = fullname.Length; i > 0; i--)
        {
            chara = fullname.Substring(i - 1, 1);
            if (chara.Equals(" ")) { break; }
            else { surname = chara + surname; }
        }
        for (int i = 0; i < fullname.Length; i++)
        {
            chara = fullname.Substring(i, 1);
            if (chara.Equals(" ")) { break; }
            else { status = status + chara; }
        }
        status = status.ToUpper().Trim();

        #region-----------------------Remove Status from Name----------------
        //string statussel = "select ";
        //if(dm.existRecored())

        if (status.Equals("MR.") || status.Equals("MS.") || status.Equals("MRS.") || status.Equals("DR."))
        {
            fullname = fullname.Substring(status.Length + 1, fullname.Length - (status.Length + 1));
        }
        #endregion

        for (int j = 0; j < fullname.Length; j++)
        {
            string prevstr = "";
            chara = "";
            if (j == 0)
            {
                chara = fullname.Substring(0, 1).ToUpper();
                initials = chara + ".";
                //prevstr = chara;
            }
            else
            {
                chara = fullname.Substring(j, 1);
                if (chara.Equals(" ")) { initials += " " + fullname.Substring(j + 1, 1).ToUpper() + "."; }
            }
        }
        initials = initials.Substring(0, initials.Length - 2);
        return initials + surname;
    }

    public void PaidNo(long polno, string field, string mos, DataManager dm)
    {
        try
        {
            int number = 0;
            string paidnosel = "select " + field + " from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
            if (dm.existRecored(paidnosel) != 0)
            {
                dm.readSql(paidnosel);
                OracleDataReader paidnoreader = dm.oraComm.ExecuteReader();
                paidnoreader.Read();
                if (!paidnoreader.IsDBNull(0)) { number = paidnoreader.GetInt32(0); }
                //paidnoreader.Close();
            }

            if (number == 0)
            {
                string dthrefupd = "update LPHS.DTHREF set " + field + "=(select max(" + field + ")+1 from LPHS.DTHREF) where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
                dm.insertRecords(dthrefupd);
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public double ExgraciaAmt(long polno, string mos, string adblate, double exgrtotal, string payee, int num, DataManager dm)
    {
        double ADBONEX = 0, share = 0;
        string persel = "";

        string exgrAmtsSel = "select SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF ='" + mos + "' ";
        if (dm.existRecored(exgrAmtsSel) != 0)
        {
            dm.readSql(exgrAmtsSel);
            OracleDataReader exgrAmtsRead = dm.oraComm.ExecuteReader();
            while (exgrAmtsRead.Read())
            {
                if (!exgrAmtsRead.IsDBNull(1)) { ADBONEX = exgrAmtsRead.GetDouble(1); } else { ADBONEX = 0; }
            }
            exgrAmtsRead.Close();
        }
        if (adblate.Equals("Y")) { exgrtotal -= ADBONEX; }
        if (exgrtotal < 0) { exgrtotal = 0; }
        //else if (adblate.Equals("E")) { exgrtotal = ADBONEX; }
        if (payee.Equals("NOM"))
        {
            persel = "select NOMPER from LUND.NOMINEE where POLNO = " + polno + " and NOMNO=" + num + "";
        }
        else if (payee.Equals("LHI"))
        {
            persel = "select (LHSHARE)*100 from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + mos + "' and LHHNO=" + num + "";
        }
        if (!persel.Equals(""))
        {
            if (dm.existRecored(persel) != 0)
            {
                dm.readSql(persel);
                OracleDataReader persontagereader = dm.oraComm.ExecuteReader();
                while (persontagereader.Read())
                {
                    if (!persontagereader.IsDBNull(0)) { share = persontagereader.GetDouble(0); } else { share = 0; }
                }
                persontagereader.Close();
            }
        }
        else
        {
            share = 100;
        }
        return Math.Round(exgrtotal * share, 2) / 100;
    }

    public Boolean IsVouAmtDeposit(DataManager dm, long polno, string mos)
    {
        double depositamt = 0, netclm = 0;
        string dthrefsel = "select DRDEPOSITS, DRNETCLM from LPHS.DTHREF where DRPOLNO=" + polno + " and DRMOS='" + mos + "'";
        if (dm.existRecored(dthrefsel) != 0)
        {
            dm.readSql(dthrefsel);
            OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
            while (dthrefreader.Read())
            {
                if (!dthrefreader.IsDBNull(0)) { depositamt = dthrefreader.GetDouble(0); } else { depositamt = 0; }
                if (!dthrefreader.IsDBNull(1)) { netclm = dthrefreader.GetDouble(1); } else { netclm = 0; }
            }
            dthrefreader.Close();
        }
        if ((netclm == depositamt) && (netclm != 0)) { return true; }
        else { return false; }
    }

    public string getSurname(string EPF)
    {
        string username = "";
        OdbcConnection con = new OdbcConnection("DSN=PRODDSN;UID=INTERNET;PWD=INTERNET");
        try
        {
            con.Open();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT USRNAME FROM INTRANET.INTUSR WHERE (EPFNUM = '" + EPF + "')";
        try
        {
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (!dr.IsDBNull(0)) { username = dr.GetString(0); } else { username = ""; }
            }
            dr.Close();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        con.Close();
        return username;
    }

    public string voucher_number(string year, string brn, string voutyp, DataManager dm)
    {
        try
        {
            string sqlupdate, vou = "DT";
            if (voutyp.Equals("S"))
            {
                vou = "DS";
                voutyp = "D";
            }
            int maxsq = 0;
            string sql = "select max(VOUNO1)from lclm.vouno where VUBRNO=" + brn + " and VUYEAR=" + year + " and VUTYPE='" + voutyp + "'";
            OracleDataReader reader;
            dm.readSql(sql);
            //dm.oraComm.CommandText = sql;
            //oraComm.Connection = oraConn;
            reader = dm.oraComm.ExecuteReader();

            reader.Read();

            if (!reader.IsDBNull(0))
                maxsq = reader.GetInt32(0);
            reader.Close();

            if (maxsq > 0)
            {
                maxsq = maxsq + 1;
                sqlupdate = "update lclm.vouno set VOUNO1=" + maxsq + "where VUBRNO=" + brn + " and VUYEAR=" + year + "and VUTYPE='" + voutyp + "'";
            }
            else
            {
                maxsq = 1;
                sqlupdate = "insert into lclm.vouno(VUBRNO,VUYEAR,VUTYPE,VOUNO1) values (" + brn + "," + year + ",'" + voutyp + "'," + maxsq + ")";
            }
            dm.insertRecords(sqlupdate);
            string strbrn = brn.ToString().Trim();
            string strmaxsq = maxsq.ToString();

            if (strbrn.Length != 3)
            {
                string str = "";
                for (int i = 0; i < 3 - strbrn.Length; i++)
                { str = str + "0"; }
                strbrn = str + strbrn;
            }
            if (strmaxsq.Length != 5)
            {
                string str = "";
                for (int i = 0; i < 5 - strmaxsq.Length; i++)
                { str = str + "0"; }
                strmaxsq = str + strmaxsq;
            }

            // return strbrn + "/" + year.Trim() + "/S/" + strmaxsq;
            //return strbrn + "/D" + DateTime.Now.ToString("yyMMdd") + strmaxsq;
            if (voutyp.Equals("C")) { vou = "DC"; }
            return "T/" + DateTime.Now.ToString("yyMMdd").Substring(0, 2) + "/" + strbrn + "/" + vou + "/" + strmaxsq;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public Boolean IsAdbExgracia(long polno, string mos, DataManager dm)
    {
        double ADBONEX = 0;
        string exgrAmtsSel = "select SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + polno + " and MOF ='" + mos + "' ";
        if (dm.existRecored(exgrAmtsSel) != 0)
        {
            dm.readSql(exgrAmtsSel);
            OracleDataReader exgrAmtsRead = dm.oraComm.ExecuteReader();
            while (exgrAmtsRead.Read())
            {
                if (!exgrAmtsRead.IsDBNull(1)) { ADBONEX = exgrAmtsRead.GetDouble(1); } else { ADBONEX = 0; }
            }
            exgrAmtsRead.Close();
        }
        if (ADBONEX > 0) { return true; }
        else { return false; }
    }

    public int Account_code(long polno, string voutyp, DataManager dm)
    {
        int tbl, accode = 2118;
        polMasRead pmr = new polMasRead(int.Parse(polno.ToString()), dm);
        tbl = pmr.TBL;
        if (voutyp.Equals("CP"))
        {
            if (tbl == 34 || tbl == 38)
            {
                accode = 2235;
            }
            else
            {
                accode = 2118;
            }
        }
        return accode;
    }

    public double Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }
    public int Duedate
    {
        get { return duedate; }
        set { duedate = value; }
    }
}
