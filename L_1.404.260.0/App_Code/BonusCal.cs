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
/// Summary description for BonusCal
/// </summary>
/// 
[Serializable()]
public class BonusCal
{
    double totbonus = 0;
    int interimboncount = 0;
    int yeardiff = 0;
    int monthdiff = 0;
    int lastpaymentY = 0;
    double vestedbonus;
    double interimbonus;
    private int dthdate;
    private int PHCOM = 0;
    private int PHTBL = 0;
    private int PHTRM = 0;
    private double PHSUM = 0;
    private int PHMOD = 0;
    private double PHPRM = 0;
    private string PHSTA = "";
    private int DUE = 0;
    DataManager dm;
    OldChildProtRead ocpr;
    General gg;
    lpolhisread lpolhis;

    public BonusCal()
    {

    }
    public double[] VestedBonus(long polno, string MOS)
    {
        try
        {
            double[] arrbonus = new double[3];
            dm = new DataManager();
            #region --------------------------Bonus Calculation-------------------------------------
            string childprotsel = "select * from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + MOS + "'";
            string lpolhisSel = "select PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHSTA, PHDUE from LPHS.LPOLHIS where PHPOL = " + polno + " and phmos = '" + MOS + "' and phtyp = 'D' ";
            if (dm.existRecored(lpolhisSel) != 0)
            {
                dm.readSql(lpolhisSel);
                OracleDataReader lpolhisReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (lpolhisReader.Read())
                {
                    if (!lpolhisReader.IsDBNull(0)) { PHCOM = lpolhisReader.GetInt32(0); } else { PHCOM = 0; }
                    if (!lpolhisReader.IsDBNull(1)) { PHTBL = lpolhisReader.GetInt32(1); } else { PHTBL = 0; }
                    if (!lpolhisReader.IsDBNull(2)) { PHTRM = lpolhisReader.GetInt32(2); } else { PHTRM = 0; }
                    if (!lpolhisReader.IsDBNull(3)) { PHSUM = lpolhisReader.GetDouble(3); } else { PHSUM = 0; }
                    if (!lpolhisReader.IsDBNull(4)) { PHMOD = lpolhisReader.GetInt32(4); } else { PHMOD = 0; }
                    if (!lpolhisReader.IsDBNull(5)) { PHPRM = lpolhisReader.GetDouble(5); } else { PHPRM = 0; }
                    if (!lpolhisReader.IsDBNull(6)) { PHSTA = lpolhisReader.GetString(6); } else { PHSTA = ""; }
                    if (!lpolhisReader.IsDBNull(7)) { DUE = lpolhisReader.GetInt32(7); } else { DUE = 0; }
                }
                lpolhisReader.Close();
                lpolhisReader.Dispose();
            }
            else if (dm.existRecored(childprotsel) != 0)
            {
                ocpr = new OldChildProtRead(polno, dm);
                PHCOM = ocpr.Com;
                PHTBL = ocpr.Tbl;
                PHTRM = ocpr.Trm;
                PHSUM = ocpr.Sumass;
                PHMOD = 1;
                dthdate = ocpr.Dtofdth;
            }
            //string dthintsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DMOS='M'";
            string dthintsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DMOS='" + MOS + "'";
            if (dm.existRecored(dthintsel) != 0)
            {
                dm.readSql(dthintsel);
                OracleDataReader dthpayread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                dthpayread.Read();
                if (!dthpayread.IsDBNull(0)) { dthdate = dthpayread.GetInt32(0); } else { dthdate = 0; }
                dthpayread.Close();
                dthpayread.Dispose();
            }
            int matdate = 0;
            int DCOym = 0;
            if (PHCOM > 0)
            {
                matdate = int.Parse((int.Parse(PHCOM.ToString().Substring(0, 4)) + PHTRM).ToString() + PHCOM.ToString().Substring(4, 4));

                DCOym = int.Parse(Convert.ToString(PHCOM).Substring(0, 4));
            }
            else
            {
                //dthintsel = "select COMDATE from LPHS.DTHOUT_TEMP where POLNO=" + polno + " and MOS='M'";
                dthintsel = "select COMDATE from LPHS.DTHOUT_TEMP where POLNO=" + polno + " and MOS='" + MOS + "'";
                if (dm.existRecored(dthintsel) != 0)
                {
                    dm.readSql(dthintsel);
                    OracleDataReader dthpayread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    dthpayread.Read();
                    if (!dthpayread.IsDBNull(0)) { PHCOM = dthpayread.GetInt32(0); } else { PHCOM = 0; }
                    dthpayread.Close();
                    dthpayread.Dispose();
                }
                if (PHCOM > 0)
                {
                    matdate = int.Parse((int.Parse(PHCOM.ToString().Substring(0, 4)) + PHTRM).ToString() + PHCOM.ToString().Substring(4, 4));

                    DCOym = int.Parse(Convert.ToString(PHCOM).Substring(0, 4));
                }
            }
            if (dthdate > 0)
            {
                yeardiff = int.Parse(dthdate.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(PHCOM).Substring(0, 4));
            }
            else
            {
                //dthintsel = "select DTOFDTH from LPHS.DTHOUT_TEMP where POLNO=" + polno + " and MOS='M'";
                dthintsel = "select DTOFDTH from LPHS.DTHOUT_TEMP where POLNO=" + polno + " and MOS='" + MOS + "'";
                if (dm.existRecored(dthintsel) != 0)
                {
                    dm.readSql(dthintsel);
                    OracleDataReader dthpayread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    dthpayread.Read();
                    if (!dthpayread.IsDBNull(0)) { dthdate = dthpayread.GetInt32(0); } else { dthdate = 0; }
                    dthpayread.Close();
                    dthpayread.Dispose();
                }
                if (dthdate > 0)
                {
                    yeardiff = int.Parse(dthdate.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(PHCOM).Substring(0, 4));
                }
            }

            bool flag = false;
            int bonuscount = yeardiff;

            string incrementcountstr = "";
            string incrementcountstrdclr = "";
            int i;
            double temp = 0;
            if (bonuscount > 0)
            {
                for (i = 1; i < (bonuscount + 1); i++)
                {
                    if (i < 10)
                    {
                        incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                    }
                    else
                    {
                        incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                    }
                }

                incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));

                string bonsql = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + PHTBL + " ";

                dm.readSql(bonsql);
                OracleDataReader bonfilereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (bonfilereader.Read())
                {
                    flag = true;
                    for (int j = 0; j < bonuscount; j++)
                    {
                        double annualbonus = 0;
                        if (!bonfilereader.IsDBNull(j)) { annualbonus = bonfilereader.GetDouble(j); }
                        totbonus = totbonus + annualbonus;
                        if (annualbonus == 0)
                        {
                            interimboncount++;
                            break;
                        }
                        else { temp = annualbonus; }
                    }

                }
                bonfilereader.Close();
                bonfilereader.Dispose();
                if (!flag)
                { totbonus = 0; }
            }
            vestedbonus = (totbonus * PHSUM) / 1000;
            if (interimboncount < 0) { interimboncount = 0; }
            interimbonus = (temp * interimboncount * PHSUM) / 1000;
            if (PHTBL == 34)
            {
                vestedbonus = totbonus;
            }
            arrbonus[0] = interimbonus;
            arrbonus[1] = vestedbonus;
            arrbonus[2] = interimbonus + vestedbonus;
            dm.connclose();
            #endregion//------------------------------------------------------------------------------
            return arrbonus;
        }
        catch (Exception Ex)
        {
            dm.connclose();
            throw Ex;
        }
    }

    #region --------------- Minimuthu Bonus Calculation ------------------
    public double[] MinimuthuBonusCal(int matDate,int comDate,int mod,string polSta,int tbl,double sumAss,int polNo)
    {
        gg = new General();
        dm = new DataManager();
        lpolhis = new lpolhisread(polNo);
        double[] arrbonus = new double[3];
        int polDuraYrs = 0;
        int polDuraMnths = 0;
        int polDuraDays = 0;
        int bonuscount = 0;
        double totbonus = 0;
        int interimboncount = 0;
        int yeardiff = 0;
        int monthdiff = 0;
        int lastpaymentY = 0;

        if (polSta.Equals("I"))
        {
            polDuraYrs = this.dateComparison(comDate, matDate)[0];
            polDuraMnths = this.dateComparison(comDate, matDate)[1];
            polDuraDays = this.dateComparison(comDate, matDate)[2];
            if (polDuraDays > 15) { polDuraMnths++; if (polDuraMnths >= 12) { polDuraMnths = 0; polDuraYrs++; } }
        }
        else
        {
            //---------- include code to read the ledger table to get the last paymnet date
            DUE = lpolhis.DUE;

            if (DUE == 0)
            {
                DUE = gg.Duedate;
            }

            int dueYMD = int.Parse(DUE.ToString() + comDate.ToString().Substring(6, 2));
            polDuraYrs = this.dateComparison(comDate, dueYMD)[0];
            polDuraMnths = this.dateComparison(comDate, dueYMD)[1];
            polDuraDays = this.dateComparison(comDate, dueYMD)[2];
            if (polDuraDays > 15)
            {
                polDuraMnths++;
                if (polDuraMnths >= 12)
                { polDuraMnths = 0; polDuraYrs++; }
            }

        }

        int DMym = int.Parse(Convert.ToString(matDate).Substring(0, 4));
        int DComym = int.Parse(Convert.ToString(comDate).Substring(0, 4));
        if (polSta.Equals("I"))
        {
            yeardiff = int.Parse(matDate.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(comDate).Substring(0, 4));
        }
        else if (polSta.Equals("L"))
        {
            //yeardiff = int.Parse(DUE.ToString().Substring(0, 4)) - int.Parse(Convert.ToString(dateofComm).Substring(0, 4));
            int multiplier = 0;
            if (mod == 1) { multiplier = 12; }
            else if (mod == 2) { multiplier = 6; }
            else if (mod == 3) { multiplier = 3; }
            else if (mod == 4) { multiplier = 1; }
            lastpaymentY = int.Parse(comDate.ToString().Substring(0, 4)) + polDuraYrs - 1;

            yeardiff = this.dateComparison(comDate, int.Parse(DUE.ToString() + comDate.ToString().Substring(6, 2)))[0];
            monthdiff = this.dateComparison(comDate, int.Parse(DUE.ToString() + comDate.ToString().Substring(6, 2)))[1];

        }
        else { }
        bool flag = false;

        //----- excluding bonus not declared years ----

        //bonuscount = lastpaymentY - int.Parse(dateofComm.ToString().Substring(0, 4));
        bonuscount = yeardiff;
        if (polSta.Equals("L"))
        {
            if (lastpaymentY == 1963 || lastpaymentY == 1967 || lastpaymentY == 1972 || lastpaymentY == 1974 || lastpaymentY == 1976 || lastpaymentY == 1981 || lastpaymentY == 1984 || lastpaymentY == 1986 || lastpaymentY == 1989 || lastpaymentY == 1991 || lastpaymentY == 1996)
            {
                if (int.Parse(DUE.ToString().Substring(0, 4)) < (int.Parse(comDate.ToString().Substring(0, 4)) + polDuraYrs)) { bonuscount--; }
            }
            else if (lastpaymentY == 1964 || lastpaymentY == 1968 || lastpaymentY == 1977 || lastpaymentY == 1982 || lastpaymentY == 1987) { bonuscount -= 2; }
            else if (lastpaymentY == 1965 || lastpaymentY == 1969 || lastpaymentY == 1978) { bonuscount -= 3; }
            else if (lastpaymentY == 1970 || lastpaymentY == 1979) { bonuscount -= 4; }
        }

        string incrementcountstr = "";
        // string incrementcountstrdclr = "";
        int i;
        double temp = 0;
        if (bonuscount > 0)
        {
            for (i = 1; i < (bonuscount + 1); i++)
            {
                if (i < 10)
                {
                    incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                }
                else
                {
                    incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                }
            }

            incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));

            //string bonsql = "select " + incrementcountstr + " from lphs.lplbons_old where lplbons_old.bonyea = " + DCOym + " and lplbons_old.bontab=" + table + " ";
            string bonsql = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + DComym + " and lplbons.bontab=" + tbl + " ";

            if (dm.existRecored(bonsql) != 0)            
            {
                dm.readSql(bonsql);
                OracleDataReader bonfilereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (bonfilereader.Read())
                {
                    flag = true;
                    for (int j = 0; j < bonuscount; j++)
                    {
                        double annualbonus = 0;
                        if (!bonfilereader.IsDBNull(j)) { annualbonus = bonfilereader.GetDouble(j); }
                        totbonus = totbonus + annualbonus;
                        if (annualbonus == 0)
                        {
                            interimboncount++;
                            break;
                        }
                        else { temp = annualbonus; }
                    }

                }
                bonfilereader.Close();
                bonfilereader.Dispose();
                if (!flag)
                { totbonus = 0; }
            } 
        }
        vestedbonus = (totbonus * sumAss) / 1000;
        if (tbl == 34)
        { vestedbonus = totbonus; }
        //interimboncount--;
        if (interimboncount < 0) { interimboncount = 0; }
        if (int.Parse(comDate.ToString().Substring(0, 4)) != 2009)
        {
            interimbonus = (temp * interimboncount * sumAss) / 1000;
        }
        #region-----------New Interim bonus calculation of 2009
        else//This part added for new Bonus calculation of 2009-------
        {
            // polMasRead pmr = new polMasRead(polno, dthRegObj);
            //COM = pmr.COM;
            int matyear = int.Parse(matDate.ToString().Substring(0, 4));
            if ((int.Parse(matyear.ToString() + comDate.ToString().Substring(4, 4)) > matDate) || (matyear == 2010))
            {
                matyear--;
            }
            string bonuscal = "select LPHS.INT_BONUS_CAL(" + polNo + ", " + yeardiff + ", " + matyear + ", " + sumAss + ", " + tbl + ") from dual";
             
            if (dm.existRecored(bonuscal) != 0)
            {
                dm.readSql(bonuscal);
                OracleDataReader bonusreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                bonusreader.Read();

                while (bonusreader.Read())
                {
                    if (!bonusreader.IsDBNull(0)) { interimbonus = Convert.ToDouble(bonusreader[0]); }
                }
                bonusreader.Close();
                bonusreader.Dispose();
            } 
            interimbonus *= interimboncount;
        }
        //------------------------------------------------------------------
        #endregion
        arrbonus[0] = interimbonus;
        arrbonus[1] = vestedbonus;
        arrbonus[2] = interimbonus + vestedbonus;
        dm.connclose(); 
        return arrbonus;
    }
    #endregion

    public int[] dateComparison(int startdate, int enddate)
    {
        //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;

    }
}
