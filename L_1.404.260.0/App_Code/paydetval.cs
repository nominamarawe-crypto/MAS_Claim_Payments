using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.OracleClient;
/// <summary>
/// Summary description for paydetval
/// </summary>
public class paydetval
{
    private int startdate;
    private int enddate;

    private double paidAmt1 = 0;
    private int comendate;
    private string vouno;
    private int tbl;
    private int trm;
    private int maturity;
    private string comendateYearstr;
    private string comendateMonthstr;
    private string comendateDaystr;
    private string maturitystr;
    private int matdate;

    private int polno;
    private int paydue1;
    private int paydue;

    private double paidamt;
    private int nextdue;
    private double total;
    private double unpaidtot;
    private double paidamtper;
    private List<paydetval> paydetlistMaker = new List<paydetval>();
    DataManager dm;
    DateDifference dd;
    public void Fetch(int Thestartdate, int Theenddate)
    {
        startdate = Thestartdate;
        enddate = Theenddate;
        try
        {
            dm = new DataManager();
            #region
            string DthPartsel = "select  a.POLNO,b.PHCOM,b.PHSUM ,a.PAYMENT_DUE,a.PAID_AMT,a.VONO,b.PHTBL,b.PHTRM, to_number(min(A.payment_due)||substr(B.PHCOM, 7,2)) from LCLM.PERIODIC_PAYDET  a,LPHS.LPOLHIS  b where  a.POLNO=b.PHPOL and a.CLMTYPE='DTC'  and  a.VONO is null group by a.POLNO";

            if (dm.existRecored(DthPartsel) != 0)
            {
                dm.readSql(DthPartsel);
                OracleDataReader DthpartReader = dm.oraComm.ExecuteReader();
                while (DthpartReader.Read())
                {
                    if (!DthpartReader.IsDBNull(0)) { polno = DthpartReader.GetInt32(0); } else { polno = 0; }
                    if (!DthpartReader.IsDBNull(1)) { comendate = DthpartReader.GetInt32(1); } else { comendate = 0; }
                    //if (!DthpartReader.IsDBNull(3)) { paydue = DthpartReader.GetInt32(3); } else { paydue = 0; }
                    if (!DthpartReader.IsDBNull(4)) { paidAmt1 = DthpartReader.GetInt32(4) ; } else { paidAmt1 = 0; }
                    if (!DthpartReader.IsDBNull(5)) { vouno = DthpartReader.GetString(5); } else { vouno = ""; }
                    if (!DthpartReader.IsDBNull(6)) { tbl = DthpartReader.GetInt32(6); } else { tbl = 0; }
                    if (!DthpartReader.IsDBNull(7)) { trm = DthpartReader.GetInt32(7); } else { trm = 0; }


                    comendateYearstr = comendate.ToString().Substring(0, 4);
                    comendateMonthstr = comendate.ToString().Substring(4, 2);
                    comendateDaystr = comendate.ToString().Substring(6, 2);
                    maturity = int.Parse(comendateYearstr) + trm;

                  int   matdate = int.Parse(maturity.ToString() + comendateMonthstr.ToString() + comendateDaystr.ToString());


                  #region---------------Table 39, 49-------------------

                  if (tbl == 39 || tbl == 49)
                  {
                      if (paydue < enddate && startdate < matdate)
                      {
                          int pointendate, pointstdate;
                          if (paydue < startdate)
                          {
                              pointstdate = int.Parse(startdate.ToString().Substring(0, 4) + paydue.ToString().Substring(4, 4));
                          }
                          else
                          {
                              pointstdate = paydue;
                          }
                          if (matdate < enddate) { pointendate = matdate; }
                          else { pointendate = enddate; }

                          //while (pointstdate < pointendate)
                          //{
                              int years = 0;
                              dd = new DateDifference(pointstdate, pointendate);
                              years = dd.Years;
                              total = paidamt * years;
                              //string periopaysel = "select sum(PAID_AMT) from lclm.periodic_paydet where payment_due between " + int.Parse(pointstdate.ToString().Substring(0, 6)) + " and " + int.Parse(pointendate.ToString().Substring(0, 6)) + " and vono is not null --or voudate<" + enddate + "";
                              //if (dm.existRecored(periopaysel) != 0)
                              //{
                              //    dm.readSql(periopaysel);
                              //    OracleDataReader periopayselreder = dm.oraComm.ExecuteReader();
                              //    if (!periopayselreder.IsDBNull(0)) { paidamtper = periopayselreder.GetInt32(0); } else { paidamtper = 0; }


                              //    periopayselreder.Close();
                              //}
                          //}
                          //----------------------Paid amount here--------------
                          //{
                          //}
                      }
                  }
                  #endregion


                  // string   payduestr = paydue.ToString();
               //  paydue =int.Parse( payduestr.ToString() + comendateDaystr.ToString());
                  



                }
                DthpartReader.Close();
            }

            #endregion

            #region-----------------Commented-----------------------------

            //string DthPartsel2 = "select A.polno, min(A.payment_due), B.PHTBL, to_number(min(A.payment_due)||substr(B.PHCOM, 7,2)), A.PAID_AMT from lclm.periodic_paydet A, lphs.lpolhis B where A.vono is null and A.polno=B.phpol and (B.PHTBL=39 or B.PHTBL=49) and A.CLMTYPE='DTC' group by A.polno, B.PHTBL, B.PHCOM, A.PAID_AMT";

            //if (dm.existRecored(DthPartsel2) != 0)
            //{
            //    dm.readSql(DthPartsel2);
            //    OracleDataReader DthpartReader2 = dm.oraComm.ExecuteReader();
            //    while (DthpartReader2.Read())
            //    {
                  
            //        if (!DthpartReader2.IsDBNull(0)) { polno = DthpartReader2.GetInt32(0); } else { polno = 0; }
            //        if (!DthpartReader2.IsDBNull(3)) { paydue = DthpartReader2.GetInt32(3); } else { paydue = 0; }
            //        if (!DthpartReader2.IsDBNull(2)) { paidamt = DthpartReader2.GetDouble(2); } else { paidamt = 0; }

            //      //make matdate
            //        if (paydue < enddate && startdate < matdate)
            //        {
            //            int pointendate, pointstdate;
            //            if (paydue < startdate)
            //            {
            //                pointstdate = int.Parse(startdate.ToString().Substring(0, 4) + paydue.ToString().Substring(4, 4));
            //            }
            //            else
            //            {
            //                pointstdate = paydue;
            //            }
            //            if (matdate < enddate) { pointendate = matdate; }
            //            else { pointendate = enddate; }

            //            while (pointstdate < pointendate)
            //            {
            //                int years = 0;
            //                dd = new DateDifference(pointstdate, pointendate);
            //                years = dd.Years;
            //                total = paidamt * years;
            //                string periopaysel = "select sum(PAID_AMT) from lclm.periodic_paydet where payment_due between " + int.Parse(pointstdate.ToString().Substring(0, 6)) + " and " + int.Parse(pointendate.ToString().Substring(0, 6)) + " and vono is not null --and voudate<"+enddate+"";
            //                if (dm.existRecored(periopaysel) != 0)
            //                {
            //                    dm.readSql(periopaysel);
            //                    OracleDataReader periopayselreder= dm.oraComm.ExecuteReader();
            //                    if (!periopayselreder.IsDBNull(0)) { paidamtper = periopayselreder.GetInt32(0); } else { paidamtper = 0; }
                                

            //                    periopayselreder.Close();
            //                }
                            
            //            }
                        
            //        }

            //    }

            //}
            #endregion
        }
        catch (Exception exp)
         {
             throw exp; 
         }
    
    }
}
