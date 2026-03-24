using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

/// <summary>
/// Summary description for PaymentDueCreater
/// </summary>
public class PaymentDueCreater
{
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
        // return ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        // return y;
        return datetime;
    }


    private int polno;
    private double paidUpValue;
    private int clmno;
    private int memoAprvDate;
    private string isFuturePayment;
    private int COM;
    private int TBL;
    private string STA;
    private int MOD;
    private double SUM;
    private int dateofdth;
    private double PAYAMT;
    private string maturity;

    private int dueYM;
    private int maxPaymntdue;
    private int maxNextdue;
    private int mat_date;
    private int paymntDue;
    private double BONUS;
    private double PAYAMT1;
    private double STAMPDUTY;
    private string lifeType, clmtyp ="DTC";
    private ArrayList vouIndexes;
    private int TRM = -1;


    DataManager dm;
    lpolhisread lpolobj;
    BonusCal bcal;
    public void createDue(int dueYeMo)
    {
        dm = new DataManager();
        dueYM = dueYeMo;
        int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
        int showdate;
        int showdate1;
        
        if (currentYM.ToString().Substring(4, 2) == "11")
        {
            showdate1 = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "01");
        }
        else if (currentYM.ToString().Substring(4, 2) == "12")
        {
            showdate1 = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "02");
        }
        else
        {
            showdate1 = currentYM + 2;
        }

        if (dueYM.ToString().Substring(4, 2) == "11")
        {
            showdate = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "01");
        }
        else if (dueYM.ToString().Substring(4, 2) == "12")
        {
            showdate = int.Parse(Convert.ToString(int.Parse(dueYM.ToString().Substring(0, 4)) + 1) + "02");
        }
        else
        {
            showdate = dueYM + 2;
        }


        string dthrefsel = "select DISTINCT DRPOLNO, SMASS_PVAL, DRCLMNO, APRVDATE, IS_FUTUER_PAYMENT,STA ,TBL,COM,MOD,SUM,TRM " +
            "from LPHS.DTHREF a INNER JOIN (select EXTPOL as POLNO,EXTTBL as TBL,'' as STA ,EXTCOM as COM,EXTMD as MOD," +
            "EXTSUM as SUM, -1 as TRM from LPHS.EXSURREN UNION select PHPOL as POLNO,PHTBL as TBL,PHSTA as STA,PHCOM as COM," +
            "PHMOD as MOD,PHSUM as SUM,PHTRM as TRM from lphs.lpolhis where phtyp='D' and phmos='M') b ON a.DRPOLNO=b.POLNO " +
            "where DRMOS='M' and (IS_FUTUER_PAYMENT IN ('Y') OR IS_FUTUER_PAYMENT IS NULL) and b.TBL in (39,49)";
        if (dm.existRecored(dthrefsel) != 0)
        {
            dm.readSql(dthrefsel);
            OracleDataReader dthRefReader = dm.oraComm.ExecuteReader();
              
            while (dthRefReader.Read())
                    {
        

                        if (!dthRefReader.IsDBNull(0)) { polno = dthRefReader.GetInt32(0); } else { polno = 0; }
                        if (!dthRefReader.IsDBNull(1)) { paidUpValue = dthRefReader.GetDouble(1); } else { paidUpValue = 0.0; }
                        if (!dthRefReader.IsDBNull(2)) { clmno = dthRefReader.GetInt32(2); } else { clmno = 0; }
                        if (!dthRefReader.IsDBNull(3)) { memoAprvDate = dthRefReader.GetInt32(3); } else { memoAprvDate = 0; }
                        if (!dthRefReader.IsDBNull(4)) { isFuturePayment = dthRefReader.GetString(4); } else { isFuturePayment = ""; }
                        if (!dthRefReader.IsDBNull(5)) { STA = dthRefReader.GetString(5); } else { STA = ""; }
                        if (!dthRefReader.IsDBNull(6)) { TBL = dthRefReader.GetInt32(6); } else { TBL = 0; }
                        if (!dthRefReader.IsDBNull(7)) { COM = dthRefReader.GetInt32(7); } else { COM = 0; }
                        if (!dthRefReader.IsDBNull(8)) { MOD = dthRefReader.GetInt32(8); } else { MOD = 0; }
                        if (!dthRefReader.IsDBNull(9)) { SUM = dthRefReader.GetDouble(9); } else { SUM = 0; }
                        if (!dthRefReader.IsDBNull(10)) { TRM = dthRefReader.GetInt32(10); } else { TRM = 0; }


                        //string exsurenSel = "select EXTTBL,EXTCOM,EXTMD,EXTSUM from LPHS.EXSURREN where EXTPOL=" + polno + " AND EXTTBL in ('39','49')";
                        //if (dm.existRecored(exsurenSel) != 0)
                        //{
                        //    dm.readSql(exsurenSel);
                        //    OracleDataReader exsurenReader = dm.oraComm.ExecuteReader();
                        //    while (exsurenReader.Read())
                        //    {
                        //        if (!exsurenReader.IsDBNull(0)) { TBL = exsurenReader.GetInt32(0); } else { TBL = 0; }
                        //        if (!exsurenReader.IsDBNull(1)) { COM = exsurenReader.GetInt32(1); } else { COM = 0; }
                        //        if (!exsurenReader.IsDBNull(2)) { MOD = exsurenReader.GetInt32(2); } else { MOD = 0; }
                        //        if (!exsurenReader.IsDBNull(3)) { SUM = exsurenReader.GetDouble(3); } else { SUM = 0; }
                        //        flag1 = true;
                        //    }
                        //}
                        //string lpolhisSel = "select phsta,phtbl,PHCOM,PHMOD,PHSUM,PHTRM from lphs.lpolhis where phpol=" + polno + " and phtyp='D' and phmos='M' AND phtbl in ('39','49')";
                        //if (dm.existRecored(lpolhisSel) != 0)
                        //{
                        //    dm.readSql(lpolhisSel);
                        //    OracleDataReader lpolhisReader = dm.oraComm.ExecuteReader();
                        //    while (lpolhisReader.Read())
                        //    {
                        //        if (!lpolhisReader.IsDBNull(0)) { STA = lpolhisReader.GetString(0); } else { STA = ""; }
                        //        if (!lpolhisReader.IsDBNull(1)) { TBL = lpolhisReader.GetInt32(1); } else { TBL = 0; }
                        //        if (!lpolhisReader.IsDBNull(2)) { COM = lpolhisReader.GetInt32(2); } else { COM = 0; }
                        //        if (!lpolhisReader.IsDBNull(3)) { MOD = lpolhisReader.GetInt32(3); } else { MOD = 0; }
                        //        if (!lpolhisReader.IsDBNull(4)) { SUM = lpolhisReader.GetDouble(4); } else { SUM = 0; }
                        //        if (!lpolhisReader.IsDBNull(5)) { TRM = lpolhisReader.GetInt32(5); } else { TRM = 0; }
                        //        flag1 = true;
                        //    }
                        //}

                        if (TRM == -1)
                        {
                            string childprotoutsel = "select TERM from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and CLAIMNO=" + clmno + "";
                            dm.readSql(childprotoutsel);
                            if (dm.existRecored(childprotoutsel) != 0)
                            {
                                OracleDataReader childprotoutreader = dm.oraComm.ExecuteReader();
                                childprotoutreader.Read();
                                if (!childprotoutreader.IsDBNull(0)) { TRM = childprotoutreader.GetInt32(0); } else { TRM = 0; }
                            }
                        }

                        maturity = (int.Parse(COM.ToString().Substring(0, 4)) + TRM).ToString() + COM.ToString().Substring(4, 4);
                        mat_date = int.Parse(maturity.Replace("/", ""));


                        if (isFuturePayment != "N")
                        {


                            if (STA == "L" && (TBL == 39 || TBL == 49) && memoAprvDate > 20130327) //Table 39 and 49 paid up values
                            {
                                lpolobj = new lpolhisread(polno);
                                COM = lpolobj.Commence;

                                string dthintsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DMOS='M'";
                                if (dm.existRecored(dthintsel) != 0)
                                {
                                    dm.readSql(dthintsel);
                                    OracleDataReader dthIntReader = dm.oraComm.ExecuteReader();
                                    while (dthIntReader.Read())
                                    {
                                        if (!dthIntReader.IsDBNull(0)) { dateofdth = dthIntReader.GetInt32(0); } else { dateofdth = 0; }
                                    }
                                }

                                PAYAMT = paidUpValue * .15;

                                int maturtyYM = int.Parse(maturity.Substring(0, 6));
                                int dateOfDthYM = int.Parse(dateofdth.ToString().Substring(0, 6));
                                int nextDue = this.nextDuelaps(dateofdth, COM);

                                #region ------- Create non existing liable dues -------
                                string maxNextDueSel = "select max(payment_due), max(next_due),INTIMNO, LIFE_TYP,CLMTYPE from lclm.PERIODIC_PAYDET " +
                                                        "where POLNO = " + polno + " and (CLMTYPE='DTC' or CLMTYPE='DOC') group by INTIMNO, LIFE_TYP,CLMTYPE";
                                string s2 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO='" + clmno + "' and " +
                                             "(CLMTYPE='DTC' or CLMTYPE='DOC') and LIFE_TYP = 'M' and PAYMENT_DUE=" + nextDue + "";

                                if (showdate1 > dueYM)
                                {
                                    if (dm.existRecored(maxNextDueSel) != 0)
                                    {
                                        dm.readSql(maxNextDueSel);
                                        OracleDataReader dueReader = dm.oraComm.ExecuteReader();
                                        while (dueReader.Read())
                                        {
                                            if (!dueReader.IsDBNull(0)) { maxPaymntdue = dueReader.GetInt32(0); } else { maxPaymntdue = 0; }
                                            if (!dueReader.IsDBNull(1)) { maxNextdue = dueReader.GetInt32(1); } else { maxNextdue = 0; }
                                            if (!dueReader.IsDBNull(2)) { clmno = int.Parse(dueReader.GetString(2)); } else { clmno = 0; }
                                            if (!dueReader.IsDBNull(3)) { lifeType = dueReader.GetString(3); } else { lifeType = ""; }
                                            if (!dueReader.IsDBNull(4)) { clmtyp = dueReader.GetString(4); } else { clmtyp = ""; }
                                        }
                                        dueReader.Close();
                                    }

                                    if (dm.existRecored(s2) == 0)
                                    {
                                        while (int.Parse(maxPaymntdue.ToString()) <= showdate1)
                                        {
                                            if (maturtyYM < maxPaymntdue) { break; }

                                            //yyyy

                                            int dthYear = int.Parse(dateofdth.ToString().Substring(0, 4));
                                            int dthMonth = int.Parse(dateofdth.ToString().Substring(4, 2));
                                            int dthDate = int.Parse(dateofdth.ToString().Substring(6, 2));

                                            int comYear = int.Parse(COM.ToString().Substring(0, 4));
                                            int comMonth = int.Parse(COM.ToString().Substring(4, 2));
                                            int comDate = int.Parse(COM.ToString().Substring(6, 2));

                                            string s1 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE=" + nextDue + "";
                                            if (dm.existRecored(s1) == 0)
                                            {
                                                if (dthMonth == comMonth)
                                                {

                                                    if (dthDate <= comDate)
                                                    {
                                                        string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + nextDue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                                        dm.insertRecords(periodicinsert);
                                                    }
                                                }
                                                else
                                                {

                                                    string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + nextDue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                                    dm.insertRecords(periodicinsert);

                                                }
                                            }
                                            maxPaymntdue = this.nextDue(1, nextDue, 1);
                                            nextDue = maxPaymntdue;

                                            //if (nextDue == maturtyYM)
                                            //{
                                            //    //BonusCal totalBonus = new BonusCal();
                                            //    //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                                            //    General gg = new General();
                                            //    gg.minumuthulapsepayment(polno, "M", dm);
                                            //    double totbonus = gg.Bonus;
                                            //    PAYAMT = PAYAMT + totbonus;
                                            //    //------------------------------------
                                            //    //???????????add calculated value for paid amount.
                                            //    //------------------------------------------                            
                                            //}
                                        }
                                    }

                                    while (int.Parse(maxPaymntdue.ToString()) <= showdate1)
                                    {
                                        string s1 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and INTIMNO='" + clmno + "' and CLMTYPE = '" + clmtyp + "' and LIFE_TYP = 'M' and PAYMENT_DUE=" + maxPaymntdue + "";
                                        if (maturtyYM < maxPaymntdue) { break; }
                                        if (dm.existRecored(s1) == 0)
                                        {
                                            string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + maxPaymntdue + ", " + PAYAMT + ",'DTH','M','" + clmno + "' )";
                                            dm.insertRecords(periodicinsert);
                                        }
                                        maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);
                                        //nextDue = maxPaymntdue;

                                        //if (nextDue == maturtyYM)
                                        //{
                                        //    //BonusCal totalBonus = new BonusCal();
                                        //    //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                                        //    General gg = new General();
                                        //    gg.minumuthulapsepayment(polno, "M", dm);
                                        //    double totbonus = gg.Bonus;
                                        //    PAYAMT = PAYAMT + totbonus;
                                        //    //------------------------------------
                                        //    //???????????add calculated value for paid amount.
                                        //    //------------------------------------------                            
                                        //}
                                    }

                                }
                                #endregion
                                //if (STA == "L" && (TBL == 39 || TBL == 49) && memoAprvDate > 20130327) //Table 39 and 49 paid up values
                                //{
                                #region--------- Paydet Select --------------------------
                                //int count = 0;

                                ////int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
                                //string paydetSel = "select PAYMENT_DUE, PAID_AMT from lclm.PERIODIC_PAYDET where POLNO = " + polno + "  and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE <= " + showdate + " and (vono is null or vono = '' or vono = 'XXXX') ";
                                //if (dm.existRecored(paydetSel) != 0)
                                //{
                                //    vouIndexes = new ArrayList();
                                //    dm.readSql(paydetSel);
                                //    OracleDataReader paydetReader = dm.oraComm.ExecuteReader();
                                //    int matdate = int.Parse(mat_date.ToString().Substring(0, 6));
                                //    while (paydetReader.Read())
                                //    {
                                //        if (count == 0) { this.createDuesTable(paymntDue, PAYAMT, count, BONUS, PAYAMT1, STAMPDUTY); }
                                //        count++;
                                //        if (!paydetReader.IsDBNull(0))
                                //        {
                                //            paymntDue = paydetReader.GetInt32(0);

                                //        }
                                //        else
                                //        {
                                //            paymntDue = 0;
                                //        }
                                //        if (!paydetReader.IsDBNull(1)) { PAYAMT = paydetReader.GetDouble(1); }
                                //        PAYAMT1 = PAYAMT;
                                //        if (paymntDue == matdate)
                                //        {
                                //            //BonusCal totalBonus = new BonusCal();
                                //            //double totbonus = totalBonus.VestedBonus(polno, "M")[2];
                                //            //General gg = new General();
                                //            //gg.minumuthulapsepayment(polno, "M", dm);
                                //            //double totbonus = gg.Bonus;
                                //            bcal = new BonusCal();
                                //            double totbonus = bcal.MinimuthuBonusCal(mat_date, COM, MOD, "L", TBL, SUM, polno)[2];
                                //            PAYAMT1 = PAYAMT;
                                //            PAYAMT = PAYAMT + totbonus;
                                //            BONUS = totbonus;

                                //            //------------------------------------
                                //            //???????????add calculated value for paid amount.
                                //            //------------------------------------------                            
                                //        }
                                //        #region Task 38380 Stamp Duty

                                //        //check stamp duty
                                //        double stamp_duty = 0;
                                //        string checkstmpduty = "select nvl(max(stamp_duty),0) from (select stamp_duty,EFFECTIVE_DATE," +
                                //            "max(EFFECTIVE_DATE) over (partition by EFFECTIVE_AMOUNT) max_effect from (select * from " +
                                //            "(select * from lphs.dth_stamp_deduct  where effective_amount < '" + PAYAMT + "' and effective_date <= sysdate) a " +
                                //            "where a.effective_amount in (select max(effective_amount) from lphs.dth_stamp_deduct  where " +
                                //            "effective_amount < '" + PAYAMT + "' and effective_date <= sysdate))) where EFFECTIVE_DATE = max_effect";
                                //        if (dm.existRecored(checkstmpduty) != 0)
                                //        {
                                //            dm.readSql(checkstmpduty);
                                //            OracleDataReader checkstampreader = dm.oraComm.ExecuteReader();
                                //            checkstampreader.Read();
                                //            if (!checkstampreader.IsDBNull(0)) { stamp_duty = checkstampreader.GetInt32(0); } else { stamp_duty = 0; }
                                //            checkstampreader.Close();
                                //            checkstampreader.Dispose();
                                //        }
                                //        STAMPDUTY = stamp_duty;
                                //        PAYAMT = PAYAMT - STAMPDUTY;
                                //        #endregion

                                //        this.createDuesTable(paymntDue, PAYAMT, count, BONUS, PAYAMT1, STAMPDUTY);
                                //        vouIndexes.Add(paymntDue.ToString());
                                //    }
                                //    paydetReader.Close();
                                //}

                                ////yyyy
                                //else
                                //{
                                //    dm.oraConn.Dispose();
                                //    throw new Exception("Voucher/s Already Created or no such Dues");
                                //}
                                ////--yyyy

                                #endregion

                            }
                            else
                            {
                                string maxNextDueSel1 = "select max(payment_due), max(next_due),INTIMNO, LIFE_TYP from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' group by INTIMNO, LIFE_TYP";
                                if (dm.existRecored(maxNextDueSel1) != 0)
                                {
                                    dm.readSql(maxNextDueSel1);
                                    OracleDataReader dueReader = dm.oraComm.ExecuteReader();
                                    while (dueReader.Read())
                                    {
                                        if (!dueReader.IsDBNull(0)) { maxPaymntdue = dueReader.GetInt32(0); } else { maxPaymntdue = 0; }
                                        if (!dueReader.IsDBNull(1)) { maxNextdue = dueReader.GetInt32(1); } else { maxNextdue = 0; }
                                        if (!dueReader.IsDBNull(2)) { clmno = int.Parse(dueReader.GetString(2)); } else { clmno = 0; }
                                        if (!dueReader.IsDBNull(3)) { lifeType = dueReader.GetString(3); } else { lifeType = ""; }
                                    }
                                    dueReader.Close();
                                    //dueReader.Dispose();
                                    //string poldetlSel = "select INTIMNO, LIFE_TYP from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = 'DTC'";
                                    //dm.readSql(poldetlSel);
                                    //OracleDataReader poldetReader = dm.oraComm.ExecuteReader();
                                    //while (poldetReader.Read())
                                    //{
                                    //    if (!dueReader.IsDBNull(0)) { clmno = dueReader.GetInt32(0); } else { clmno = 0; }
                                    //    if (!dueReader.IsDBNull(1)) { lifeType = dueReader.GetString(1); } else { lifeType = ""; }
                                    //}
                                    //poldetReader.Close();

                                    if (maxPaymntdue <= showdate1)//maxPaymntdue))
                                    {
                                        if (showdate1 > dueYM)
                                        {
                                        a:
                                            //maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);

                                            //while (int.Parse (maxPaymntdue.ToString()+mat_date.ToString ().Substring(6,2)) <= int.Parse (this.setDate()[0]))
                                            while (int.Parse(maxPaymntdue.ToString()) <= showdate1)
                                            {
                                                string s1 = "select * from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and CLMTYPE = '" + clmtyp + "' and PAYMENT_DUE=" + maxPaymntdue + "";
                                                string payamountsel = "select distinct PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='" + clmno + "' and CLMTYPE='" + clmtyp + "'";
                                                if (dm.existRecored(payamountsel) != 0)
                                                {
                                                    OracleDataReader periodicpayreader = dm.oraComm.ExecuteReader();
                                                    periodicpayreader.Read();
                                                    if (!periodicpayreader.IsDBNull(0)) { PAYAMT = periodicpayreader.GetDouble(0); } else { PAYAMT = 0; }
                                                    periodicpayreader.Close();
                                                    //periodicpayreader.Dispose();
                                                }

                                                //string deletedues="delete from 
                                                //maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);
                                                // maturity check 

                                                int matdateYM = int.Parse(mat_date.ToString().Substring(0, 6));
                                                if (matdateYM < maxPaymntdue) { break; }
                                                if (dm.existRecored(s1) == 0)
                                                {
                                                    string periodicinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", '" + clmtyp + "', " + maxPaymntdue + ", " + PAYAMT + ",'DTH','" + lifeType + "','" + clmno + "' )";
                                                    dm.insertRecords(periodicinsert);
                                                }
                                                maxPaymntdue = this.nextDue(1, maxPaymntdue, 1);
                                                //if (matdateYM < maxNextdue) { this.lblmessage.Text = "Policy will be Matured by the Next Due"; break; }

                                                // completion check
                                                //int pymnt_end_dtYM = matdateYM;//int.Parse(pymnt_end_dt.ToString().Substring(0, 6));
                                                //if (pymnt_end_dtYM == maxNextdue) { break; }
                                                //if (pymnt_end_dtYM < maxNextdue) { this.lblmessage.Text = "Part Settlements will be Completed by the Next Due"; break; }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    
                }
        }
    }

    protected int nextDuelaps(int dateOfDth, int polComDate)
    {
        int dthYear = int.Parse(dateOfDth.ToString().Substring(0, 4));
        int dthMonth = int.Parse(dateOfDth.ToString().Substring(4, 2));
        int dthDay = int.Parse(dateOfDth.ToString().Substring(6, 2));

        int comYear = int.Parse(polComDate.ToString().Substring(0, 4));
        int comMonth = int.Parse(polComDate.ToString().Substring(4, 2));
        int comDay = int.Parse(polComDate.ToString().Substring(6, 2));

        int nextDueYr = 0;
        int nextDueMth = 0;

        int nextDuYM = 0;

        if (dthMonth < comMonth || ((dthMonth == comMonth) && (dthDay<= comDay)))
        {
            nextDueYr = dthYear;
            nextDueMth = comMonth;

            if (nextDueMth < 10)
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + "0" + nextDueMth.ToString());
            }
            else
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + nextDueMth.ToString());
            }
        }
        else
        {
            dthYear++;
            nextDueYr = dthYear;
            nextDueMth = comMonth;

            if (nextDueMth < 10)
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + "0" + nextDueMth.ToString());
            }
            else
            {
                nextDuYM = int.Parse(nextDueYr.ToString() + nextDueMth.ToString());
            }
        }
        return nextDuYM;
    }

    protected int nextDue(int mod, int lastDue, int premCount)
    {
        int lastDueYear = int.Parse(lastDue.ToString().Substring(0, 4));
        int lastDueMonth = int.Parse(lastDue.ToString().Substring(4, 2));
        int nextDueYear = 0;
        int nextDueMonth = 0;
        int nextDueYM = 0;
        int x = 0;

        x = 12;


        int monthCount = premCount * x;
        if (monthCount >= 12)
        {
            int years = (int)Math.Floor((decimal)(monthCount / 12));
            int months = monthCount % 12;

            nextDueMonth = lastDueMonth + months;
            nextDueYear = lastDueYear + years;
            if (nextDueMonth > 12)
            {
                nextDueMonth -= 12;
                nextDueYear++;
            }
            if (nextDueMonth < 10)
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + "0" + nextDueMonth.ToString());
            }
            else
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + nextDueMonth.ToString());
            }
        }
        else
        {
            nextDueMonth = lastDueMonth + monthCount;
            nextDueYear = lastDueYear;
            if (nextDueMonth > 12)
            {
                nextDueMonth -= 12;
                nextDueYear++;
            }
            if (nextDueMonth < 10)
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + "0" + nextDueMonth.ToString());
            }
            else
            {
                nextDueYM = int.Parse(nextDueYear.ToString() + nextDueMonth.ToString());
            }
        }


        return nextDueYM;
    }

}
