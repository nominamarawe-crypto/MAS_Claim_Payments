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
/// Summary description for Childprotpay
/// </summary>
[Serializable()]
public class Childprotpay
{
    private long polno;
    private int tbl;
    private int minduedate;
    private double amount;
    private double paidtot;
    private int comendate;
    private int trm;
    private int paydate;
    private string paydatestr;


    private string comendateYearstr;
    private string comendateMonthstr;
    private string comendateDaystr;
    private string comendatestr;
    private int maturity;
    private int matdate;
    private int enddate;
    private int startdate;
    private double total;
    private double paidtotal;
    private double balamt;
    private double paidamt;

    private double paidamt2 = 0;
    private double totpaidamt = 0;
    private string vouno;
    private double unpaidamt2;
    private double unpaidamt1;


    private double Totpaidamt1=0;
    private double Totunpaidamt1 = 0;
    private double Totpaidamt2 = 0;
    private double Totunpaidamt2 = 0;
    private double totalpaidamt = 0;
    private double totalUnpaidamt = 0;

    public string claimNo;
    public string vouNo;
    public int paymentDue;
    public string claimType;
    public double dueAmount;

    private List<Childprotpay> childprolistMaker = new List<Childprotpay>();
    DataManager dm;
    /// <summary>
    /// </summary>
    /// <param name="Thestartdate"></param>
    /// <param name="Theenddate"></param>
      //DateDifference dd;
    public void Fetch(int Thestartdate, int Theenddate)
    {
        startdate = Thestartdate;
        enddate = Theenddate;
        try
        {
            dm = new DataManager();
            string periosel = "SELECT A.POLNO, B.PHTBL, TO_NUMBER(MIN(A.PAYMENT_DUE) || SUBSTR(B.PHCOM, 7, 2)) AS MINDATE, A.PAID_AMT AS PAIDAMT, B.PHCOM, B.PHTRM,A.PAYDATE FROM LCLM.PERIODIC_PAYDET A INNER JOIN LPHS.LPOLHIS B ON A.POLNO = B.PHPOL WHERE (A.CLMTYPE = 'DTC') GROUP BY A.POLNO, B.PHTBL, B.PHCOM, A.PAID_AMT, B.PHTRM,A.PAYDATE HAVING(TO_NUMBER(TO_CHAR(MIN(A.PAYMENT_DUE)) || SUBSTR(TO_CHAR(B.PHCOM), 7, 2))<" + enddate + ")";
            if (dm.existRecored(periosel) != 0)
            {
                dm.readSql(periosel);
                //OracleDataReader perioreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
				OracleDataReader perioreader = dm.oraComm.ExecuteReader();
                while (perioreader.Read())                
                {
                    Childprotpay A = new Childprotpay();
                    if (!perioreader.IsDBNull(0)) { A.Polno = perioreader.GetInt64(0); } else { A.Polno = 0; }
                    if (!perioreader.IsDBNull(1)) { A.Tbl = perioreader.GetInt32(1); } else { A.Tbl = 0; }
                    if (!perioreader.IsDBNull(2)) { A.Mindate = perioreader.GetInt32(2); } else { A.Mindate = 0; }
                    if (!perioreader.IsDBNull(3)) { A.Amount = perioreader.GetInt64(3); } else { A.Amount = 0; }
                    if (!perioreader.IsDBNull(4)) { comendate = perioreader.GetInt32(4); } else { comendate= 0; }
                   //if (!perioreader.IsDBNull(5)) { paidtot = perioreader.GetInt32(5); } else { paidtot = 0; }
                    if (!perioreader.IsDBNull(5)) { trm = perioreader.GetInt32(5); } else { trm = 0; }
                    if (!perioreader.IsDBNull(6)) {paydate= perioreader.GetInt32(6); } else { paydate = 0; }

                    if (paydate != 0)
                    {
                        paydatestr = paydate.ToString().Substring(0, 4) + "/" + paydate.ToString().Substring(4, 2) + "/" + paydate.ToString().Substring(6, 2);
                        A.Paydate = paydatestr.ToString();
                    }
                    else
                    {
                        A.Paydate = "-";
                    }

                    comendateYearstr = comendate.ToString().Substring(0, 4);
                    comendateMonthstr = comendate.ToString().Substring(4, 2);
                    comendateDaystr = comendate.ToString().Substring(6, 2);
                    comendatestr = comendateYearstr.ToString() + "/" + comendateMonthstr.ToString() + "/" + comendateDaystr.ToString();
                    A.Comensdate = comendatestr.ToString();
                    if (A.Tbl == 39 || A.Tbl == 49)
                    {
                        maturity = int.Parse(comendateYearstr) + trm;
                        matdate = int.Parse(maturity.ToString() + comendateMonthstr.ToString() + comendateDaystr.ToString());
                       
                        //matdate = 0; //get maturity
                        //int pointendate, pointstdate;
                        //if (A.Mindate < startdate)
                        //{
                        //    pointstdate = int.Parse(startdate.ToString().Substring(0, 4) + A.Mindate.ToString().Substring(4, 4));
                        //}
                        //else
                        //{
                        //    pointstdate = A.Mindate;
                        //}
                        //if (matdate < enddate) { pointendate = matdate; }
                        //else { pointendate = enddate; }

                        //int years = 0;
                        //dd = new DateDifference(pointstdate, pointendate);
                        //years = dd.Years;
                        //A.Total = A.Amount * years;
                        double tot=0;
                        int nextdueyr;
                        int nextdue=A.Mindate;                        
                        while (nextdue <= enddate && nextdue<=matdate && nextdue.ToString().Length==8)
                        {
                            if (nextdue >= startdate)
                            {
                                tot += A.Amount;
                            }
                            nextdueyr=int.Parse(nextdue.ToString().Substring(0,4));
                            nextdueyr++;
                            nextdue = int.Parse(nextdueyr.ToString() + nextdue.ToString().Substring(4, 4));
                        }
                        A.Total = tot;
                      
                        string paidamtsel = "SELECT  SUM(A.PAID_AMT) FROM LCLM.PERIODIC_PAYDET A INNER JOIN LPHS.LPOLHIS B ON A.POLNO = B.PHPOL WHERE (A.CLMTYPE = 'DTC') and A.POLNO=" + A.Polno + " and (A.VONO is not null or A.VONO<>'XXXX') GROUP BY A.POLNO, B.PHTBL, B.PHCOM, A.PAID_AMT HAVING(TO_NUMBER(TO_CHAR(MIN(A.PAYMENT_DUE)) || SUBSTR(TO_CHAR(B.PHCOM), 7, 2)) between " + startdate + " and " + enddate + ")";
                        if (dm.existRecored(paidamtsel) != 0)
                        {
                            dm.readSql(paidamtsel);
                            //OracleDataReader paidamtreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader paidamtreader = dm.oraComm.ExecuteReader();
                            paidamtreader.Read();
                            if (!paidamtreader.IsDBNull(0)) { paidtotal = paidamtreader.GetDouble(0); } else { paidtotal = 0; }
                            paidamtreader.Close();
							paidamtreader.Dispose();

                         
                         
                            Totpaidamt1  += paidtotal;
                          
                        }
                        if (A.Total != 0)
                        {
                           unpaidamt1 = A.Total - paidtotal;
                           A.Balamt = unpaidamt1;
                           Totunpaidamt1  += unpaidamt1;
                        }
                    }
                    else
                    {
                        if ((A.Tbl == 38) || (A.Tbl == 46))
                        {
                        string paidamtsel2="SELECT A.PAID_AMT, TO_NUMBER(A.PAYMENT_DUE || SUBSTR(B.PHCOM, 7, 2)) AS DUEDATE, A.VONO FROM LCLM.PERIODIC_PAYDET A INNER JOIN LPHS.LPOLHIS B ON A.POLNO = B.PHPOL WHERE (TO_NUMBER(TO_CHAR(A.PAYMENT_DUE) || SUBSTR(TO_CHAR(B.PHCOM), 7, 2)) BETWEEN " + startdate + " AND " + enddate + ") AND A.POLNO=" +A.Polno+ "";
                        if (dm.existRecored(paidamtsel2) != 0)
                        {
                            dm.readSql(paidamtsel2);
                            //OracleDataReader paidamtreader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader paidamtreader2 = dm.oraComm.ExecuteReader();
                            while (paidamtreader2.Read())
                            {
                                if (!paidamtreader2.IsDBNull(0)) { paidamt2 = paidamtreader2.GetDouble(0); } else { paidamt2 = 0; }
                                if (!paidamtreader2.IsDBNull(2)) { vouno = paidamtreader2.GetString(2); } else { vouno = ""; }

                                if (vouno.Equals("") || vouno.Equals("XXXX"))
                                {
                                    A.Balamt = paidamt2;
                                    Totunpaidamt2 += paidamt2;
                                 }
                                else
                                {
                                    A.PaidAmount = paidamt2;
                                    Totpaidamt2 += paidamt2;
                                    
                                }

                             }
                             paidamtreader2.Close();
							 paidamtreader2.Dispose();
                           }

                        }
                    }                    
                    childprolistMaker.Add(A);                
                }
                perioreader.Close();
                perioreader.Dispose();
                totalpaidamt = (Totpaidamt1 + Totpaidamt2);
                totalUnpaidamt = (Totunpaidamt1 + Totunpaidamt2);
                  
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public List<Childprotpay> FetchManualPaidVouchers(string vouno1, string vouno2)
    {
        List<Childprotpay> manVou = new List<Childprotpay>();
        try
        {
            dm = new DataManager();

            string periodicSel = "select A.POLNO, A.CLAIMNO,A.VOUNO, A.TOTAMOUNT " +
                                 "from CASHBOOK.TEMP_CB a " +
                                 "where (A.VOUNO='" + vouno1 + "' or A.VOUNO='" + vouno2 + "')";

            if (dm.existRecored(periodicSel) != 0)
            {
                dm.readSql(periodicSel); 
                OracleDataReader perioreader = dm.oraComm.ExecuteReader();
                while (perioreader.Read())
                {
                    Childprotpay vou = new Childprotpay();
                    if (!perioreader.IsDBNull(0)) { vou.Polno = int.Parse(perioreader.GetString(0)); } else { Polno = 0; }
                    if (!perioreader.IsDBNull(1)) { vou.ClaimNo = perioreader.GetString(1); } else { ClaimNo = ""; }
                    if (!perioreader.IsDBNull(2)) { vou.VouNo = perioreader.GetString(2); } else { VouNo = ""; }
                    if (!perioreader.IsDBNull(3)) { vou.PaidAmount = perioreader.GetDouble(3); } else { PaidAmount = 0.0; } 
                    manVou.Add(vou);
                }
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

        return manVou;
    }

    public List<Childprotpay> FetchManualPaidDues(int polNo, int dueym, string mos)
    {
        List<Childprotpay> manDues = new List<Childprotpay>();
        try
        {
            dm = new DataManager();

            string periodicSel = "select A.POLNO, A.INTIMNO, A.PAYMENT_DUE, A.CLMTYPE, A.PAID_AMT " +
                                     "from LCLM.PERIODIC_PAYDET a " +
                                     "where (A.VONO is null or A.VONO = 'XXXX') and A.LIFE_TYP='" + mos + "' and A.PAYMENT_DUE<=" + dueym + " and A.POLNO=" + polNo + " order by A.PAYMENT_DUE";

            if (dm.existRecored(periodicSel) != 0)
            {
                dm.readSql(periodicSel);
                OracleDataReader perioreader = dm.oraComm.ExecuteReader();
                while (perioreader.Read())
                {
                    Childprotpay dues = new Childprotpay();
                    if (!perioreader.IsDBNull(0)) { dues.Polno = perioreader.GetInt32(0); } else { Polno = 0; }
                    if (!perioreader.IsDBNull(1)) { dues.ClaimNo = perioreader.GetString(1); } else { ClaimNo = ""; }
                    if (!perioreader.IsDBNull(2)) { dues.PaymentDue = perioreader.GetInt32(2); } else { PaymentDue = 0; }
                    if (!perioreader.IsDBNull(3)) { dues.ClaimType = perioreader.GetString(3); } else { ClaimType = ""; }
                    if (!perioreader.IsDBNull(4)) { dues.DueAmount = perioreader.GetDouble(4); } else { DueAmount = 0; }
                    manDues.Add(dues);
                }
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

        return manDues;
    }

    public List<Childprotpay> ChildprotecList
    {
        get { return childprolistMaker; }
        set { childprolistMaker = value; }
    
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }

    public string Comensdate
    {
        get { return comendatestr; }
        set {comendatestr=value; }
    }
    public int Tbl
    {
        get { return tbl; }
        set { tbl = value; }
    }

    public string Paydate
    {
        get { return paydatestr; }
        set { paydatestr = value; }
    }
    public int Mindate
    {
        get { return minduedate; }
        set { minduedate = value; }
    }
    public double Amount
    {
        get { return amount; }
        set {amount= value; }
    }
    public double Total
    {
        get { return total; }
        set { total = value; }
    } 
    public double Paidtotal
    {
        get { return paidtotal; }
        set { paidtotal = value; } 
    }
    public double Balamt
    {
        get { return balamt; }
        set { balamt = value; }
    }
    public double TotalUnpaidAmt
    {
        get { return totalUnpaidamt; }
        set {totalUnpaidamt = value; }
    }

    public double TotalPaidAmt
    {
        get { return totalpaidamt; }
        set {totalpaidamt = value; }
    }

    public double PaidAmount
    {
        get { return paidamt; }
        set {paidamt = value; }
    }
    public string ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }
    public string VouNo
    {
        get { return vouNo; }
        set { vouNo = value; }
    }
    public int PaymentDue
    {
        get { return paymentDue; }
        set { paymentDue = value; }
    }
    public string ClaimType
    {
        get { return claimType; }
        set { claimType = value; }
    }
    public double DueAmount
    {
        get { return dueAmount; }
        set { dueAmount = value; }
    }
}
