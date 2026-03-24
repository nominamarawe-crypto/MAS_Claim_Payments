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
/// Summary description for dthoutlistval
/// </summary>
[Serializable()]
public class dthoutlistval
{
    private int startdate;
    private int enddate;
    private int polno;
    private int claimno;
    private int comendate;
    private double paidamt;
    private double netclmamt;
    private double grossclm;
    private double netclm;
    private string adblatepay;
    private string comdatestr;
   
    private double outamt;

    private double adbamt = 0, adbpaidamt = 0;
    private double adboutamt;
    //private double paidamtLhi;

    private string monthstr, daystr;
    private int nopmat;
    private int noclaims=0;
    private int noclims1 = 0;
    private double Totnetamt = 0;
    private double Totpaidamt = 0;
    private double Totoutsamt = 0;
    private string payee;

    private int dthdate;
    private string dthdatestr;
    private List<dthoutlistval> dtoutlistMaker=new List<dthoutlistval>();
    DataManager dm; 
	public void Fetch(int Thestartdate,int Theenddate)
	{
        startdate = Thestartdate;
        enddate = Theenddate;

        try
        {
            dm = new DataManager();
             string DthOutsSel = "select POLNO,CLMNO,COMDATE,TBL,TRM,SUMASS,GROSSCLM,PDAMT,NETCLM  from                                                           where (PDDATE <>0  and TRANSCODE='B' and DTHPRO='N')";
             if (dm.existRecored(DthOutsSel) != 0)
             {
                 
                 dm.readSql(DthOutsSel);
                 OracleDataReader DthOutsReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                 while (DthOutsReader.Read())
                 {
                     dthoutlistval A = new dthoutlistval();
                     if (!DthOutsReader.IsDBNull(0)) { A.Polno = DthOutsReader.GetInt32(0); } else { A.Polno = 0; }
                     if (!DthOutsReader.IsDBNull(1)) { A.Claimno = DthOutsReader.GetInt32(1); } else { A.Claimno = 0; }
                     if (!DthOutsReader.IsDBNull(2)) {comendate = DthOutsReader.GetInt32(2); } else {comendate= 0; }
                     //if (!DthOutsReader.IsDBNull(3)) { tbl = DthOutsReader.GetInt32(3); } else { tbl = 0; }

                     //if (!DthOutsReader.IsDBNull(5)) { sumassu = DthOutsReader.GetDouble(5); } else { sumassu = 0; }
                     if (!DthOutsReader.IsDBNull(6)) { A.Grossclm = DthOutsReader.GetDouble(6); } else { A.Grossclm = 0; }
                     if (!DthOutsReader.IsDBNull(7)) { A.PaidAmt = DthOutsReader.GetDouble(7); } else { A.PaidAmt = 0; }
                     if (!DthOutsReader.IsDBNull(8)) { A.NetclmAmt = DthOutsReader.GetDouble(8); } else { A.NetclmAmt = 0; }

                     if (comendate > 99999)
                     {
                         
                         int day = int.Parse(comendate.ToString().Substring(0, 2));
                         int month = int.Parse(comendate.ToString().Substring(2, 2));
                         if (month < 10) { monthstr = "0" + month.ToString(); } else { monthstr = month.ToString(); }
                         if (day < 10) { daystr = "0" + day.ToString(); } else { daystr = day.ToString(); }
                         int year = int.Parse(comendate.ToString().Substring(4, 2));
                         if (day< 31)
                         {
                             comdatestr = "19"+year.ToString() + "/" + monthstr.ToString() + "/" + daystr.ToString();
                         }
                         else
                         {
                             comdatestr ="19"+ daystr.ToString() + "/" + monthstr.ToString() + "/" + year.ToString();
                         }
                         A.Comendate = comdatestr.ToString();
                     }
                     else
                     { A.Comendate = "-"; }
                     double pamt = A.PaidAmt;
                     double namt = A.NetclmAmt;
                     double outamt = namt - pamt;
                     if (outamt < 0) { outamt = 0; }
                     A.OutAmt = outamt;
                     nopmat = nopmat + 1;
                     //int nonamt = nonamt + 1;
                     noclaims = noclaims + 1;
                     A.DthDate = "-";
                     dtoutlistMaker.Add(A);
                 }
                 string dthrefsel = "select drpolno,DRCLMNO,DENTDT,DRGROSSCLM, payee, DRNETCLM, ADB_LATEPAY, ADBPAYAMT from LPHS.DTHREF where APRVDATE between " + startdate + " and " + enddate + " and APRVDATE is not null order by drpolno";
                if (dm.existRecored(dthrefsel) != 0)
                {
                 dm.readSql(dthrefsel);
                 OracleDataReader dthrefreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                 while (dthrefreader.Read())
                 {
                     dthoutlistval B= new dthoutlistval();
                     if (!dthrefreader.IsDBNull(0)) { B.Polno = dthrefreader.GetInt32(0); } else { B.Polno = 0; }
                     if (!dthrefreader.IsDBNull(1)) { B.Claimno = dthrefreader.GetInt32(1); } else { B.Claimno = 0; }
                     if (!dthrefreader.IsDBNull(2)) { comendate = dthrefreader.GetInt32(2); } else {comendate = 0; }
                     if (!dthrefreader.IsDBNull(3)) { B.Grossclm = dthrefreader.GetInt32(3); } else { B.Grossclm = 0; }
                     if (!dthrefreader.IsDBNull(5)) { netclm = dthrefreader.GetDouble(5); } else { netclm = 0; }
                     if (!dthrefreader.IsDBNull(4)) { payee = dthrefreader.GetString(4); } else {payee = ""; }
                     if (!dthrefreader.IsDBNull(6)) { adblatepay = dthrefreader.GetString(6); } else {adblatepay = ""; }
                     if (!dthrefreader.IsDBNull(7)) { adbamt = dthrefreader.GetDouble(7); } else { adbamt = 0; }
                     comdatestr = comendate.ToString().Substring(0, 4) + "/" + comendate.ToString().Substring(4, 2) + "/" + comendate.ToString().Substring(6, 2);

                     B.Comendate = comdatestr.ToString();
                      noclims1 = noclims1 + 1;
                     if (payee.Equals(""))
                     {
                         if (adblatepay.Equals("Y"))
                         {
                             outamt = netclm + adbamt;
                             B.OutAmt = outamt;
                         }
                         else
                         {
                             outamt = netclm;
                             B.OutAmt = outamt;
                         }
                     }


                     string dthintsel="select DDTOFDTH from LPHS.DTHINT where DPOLNO="+B.Polno+"";
                     if (dm.existRecored(dthintsel) != 0)
                     {
                         dm.readSql(dthintsel);
                         OracleDataReader dthintreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                         dthintreader.Read();
                         if (!dthintreader.IsDBNull(0)) { dthdate = dthintreader.GetInt32(0); } else { dthdate = 0; }
                         dthdatestr = dthdate.ToString().Substring(0, 4) + "/" + dthdate.ToString().Substring(4, 2) + "/" + dthdate.ToString().Substring(6, 2);
                         B.DthDate = dthdatestr.ToString();
                         dthintreader.Close();
                         dthintreader.Dispose();
                     }
                     #region--------------------Legal_Hires-------------------------

                     else if (payee.Equals("LHI"))
                     {
                         if (adblatepay.Equals("Y"))
                         {
                             string adbsel = "select sum(ADBAMT) from LPHS.LEGAL_HIRES where LHPOLNO=" + B.Polno + " and (ADBVOUNO is not null and ADBVOUDATE<" + enddate + ")";
                             if (dm.existRecored(adbsel) != 0)
                             {
                                 dm.readSql(adbsel);
                                 OracleDataReader adbreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                 adbreader.Read();
                                 if (!adbreader.IsDBNull(0)) { adbpaidamt = adbreader.GetDouble(0); } else { adbpaidamt = 0; }
                                 adbreader.Close();
                                 adbreader.Dispose();
                                 adboutamt = adbamt - adbpaidamt;
                             }
                         }
                         string lhisel = "select sum(LHAMOUNT) from LPHS.LEGAL_HIRES where LHPOLNO=" + B.Polno + " and (VOUNO is not null and VOUDATE<" + enddate + ")";
                         if (dm.existRecored(lhisel) != 0)
                         {
                             dm.readSql(lhisel);
                             OracleDataReader lhireader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                             lhireader.Read();
                             if (!lhireader.IsDBNull(0)) { paidamt = lhireader.GetDouble(0); } else { paidamt = 0; }
                             lhireader.Close();
                             lhireader.Dispose();
                             outamt = netclm - paidamt + adboutamt;
                             B.PaidAmt = paidamt;
                             B.OutAmt = outamt;
                         }
                     }
                     #endregion

                     #region---------------------Nominee----------------------------
                     else if (payee.Equals("NOM"))
                     {
                         if (adblatepay.Equals("Y"))
                         {
                             string adbsel = "select sum(ADBAMT) from LUND.NOMINEE where POLNO=" + B.polno + " and (ADBVOUNO is not null and ADBVOUDATE<" + enddate + ")";
                             if (dm.existRecored(adbsel) != 0)
                             {
                                 dm.readSql(adbsel);
                                 OracleDataReader adbreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                 adbreader.Read();
                                 if (!adbreader.IsDBNull(0)) { adbpaidamt = adbreader.GetDouble(0); } else { adbpaidamt = 0; }
                                 adbreader.Close();
                                 adbreader.Dispose();
                                 adboutamt = adbamt - adbpaidamt;
                             }
                         }
                         string nomshare = "select sum(NOMSHARE) from LUND.NOMINEE where POLNO=" + B.polno + " and (VOUNO is not null and VOUDATE<" + enddate + ")";
                         if (dm.existRecored(nomshare) != 0)
                         {
                             dm.readSql(nomshare);
                             OracleDataReader nomreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                             nomreader.Read();
                             if (!nomreader.IsDBNull(0)) { paidamt = nomreader.GetDouble(0); } else { paidamt = 0; }
                             nomreader.Close();
                             nomreader.Dispose();
                             outamt = netclm - paidamt + adboutamt;
                             B.PaidAmt = paidamt;
                             B.OutAmt = outamt;
                         }
                     }
                     #endregion

                     #region--------------------Assignee-------------------------
                     else if (payee.Equals("ASI"))
                     {
                         int voudate = 0, adbvoudate = 0;
                         string assignsel = "select VOUDATE, ADBVOUDATE from LUND.ASSIGNEE where POLNO=" + B.Polno + "";
                         if (dm.existRecored(assignsel) != 0)
                         {
                             dm.readSql(assignsel);
                             OracleDataReader assignreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                             while (assignreader.Read())
                             {
                                 if (!assignreader.IsDBNull(0)) { voudate = assignreader.GetInt32(0); } else { voudate = 0; }
                                 if (!assignreader.IsDBNull(1)) { adbvoudate = assignreader.GetInt32(1); } else { adbvoudate = 0; }
                                 if (adblatepay.Equals("Y") && (adbvoudate == 0 || adbvoudate > enddate))
                                 {
                                     adboutamt = adbamt;
                                 }
                                 if (voudate == 0 || voudate > enddate)
                                 {
                                     paidamt = 0;
                                     B.PaidAmt = paidamt;
                                 }
                                 else
                                 {
                                     paidamt = netclm;
                                     B.PaidAmt = paidamt;
                                 }
                                 assignreader.Close();
                                 outamt = netclm - paidamt + adbamt;
                                 B.OutAmt = outamt;
                             }
                             assignreader.Close();
                             assignreader.Dispose();
                         }
                     }

                     #endregion

                     #region-------------------Living_Partner----------------
                     else if (payee.Equals("LPT"))
                     {
                         int voudate = 0, adbvoudate = 0;
                         string livingprtsel = "select VOUDATE, ADBVOUDATE from LUND.LIVING_PRT where POLNO=" + B.Polno + "";
                         if (dm.existRecored(livingprtsel) != 0)
                         {
                             dm.readSql(livingprtsel);
                             OracleDataReader livingprtreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                             while (livingprtreader.Read())
                             {
                                 if (!livingprtreader.IsDBNull(0)) { voudate = livingprtreader.GetInt32(0); } else { voudate = 0; }
                                 if (!livingprtreader.IsDBNull(1)) { adbvoudate = livingprtreader.GetInt32(1); } else { adbvoudate = 0; }

                                 if (adblatepay.Equals("Y") && (adbvoudate == 0 || adbvoudate > enddate))
                                 {
                                     adboutamt = adbamt;
                                 }
                                 if (voudate == 0 || voudate > enddate)
                                 {
                                     paidamt = 0;
                                     B.PaidAmt = paidamt;
                                 }
                                 else
                                 {
                                     paidamt = netclm;
                                     B.PaidAmt = paidamt;
                                 }
                             }

                             livingprtreader.Close();
                             livingprtreader.Dispose();
                             outamt = netclm - paidamt + adbamt;
                             B.OutAmt = outamt;
                         }
                     }
                     #endregion

                     #region
                     else if ((payee.Equals("ML")) || (payee.Equals("SL")))
                     {
                         {
                             int voudate = 0, adbvoudate = 0;
                             string livingprtsel = "select VOUDATE, ADBVOUDATE from LPHS.LEGAL_HIRES where POLNO=" + B.Polno + "";
                             if (dm.existRecored(livingprtsel) != 0)
                             {
                                 dm.readSql(livingprtsel);
                                 OracleDataReader livingprtreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                 while (livingprtreader.Read())
                                 {
                                     if (!livingprtreader.IsDBNull(0)) { voudate = livingprtreader.GetInt32(0); } else { voudate = 0; }
                                     if (!livingprtreader.IsDBNull(1)) { adbvoudate = livingprtreader.GetInt32(1); } else { adbvoudate = 0; }

                                     if (adblatepay.Equals("Y") && (adbvoudate == 0 || adbvoudate > enddate))
                                     {
                                         adboutamt = adbamt;
                                     }
                                     if (voudate == 0 || voudate > enddate)
                                     {
                                         paidamt = 0;
                                         B.PaidAmt = paidamt;
                                     }
                                     else
                                     {
                                         paidamt = netclm;
                                         B.PaidAmt = paidamt;
                                     }
                                 }

                                 livingprtreader.Close();
                                 livingprtreader.Dispose();
                                 outamt = netclm - paidamt + adbamt;
                                 B.OutAmt = outamt;
                             }
                         }
                     }
                     #endregion
                     B.NetclmAmt = netclm;
                      Totnetamt +=netclm ;
                      Totpaidamt += paidamt;
                      Totoutsamt += outamt;
                     dtoutlistMaker.Add(B);
                 }
                 dthrefreader.Close();
                 dthrefreader.Dispose();
				 dm.connClose();
             }
             
             }
             
        }
        catch
        {
        }
    
    }

    public List<dthoutlistval> DthoutlistMaker
    {
        get { return dtoutlistMaker; }
        set { dtoutlistMaker = value; }
    }
    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public int Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public string Comendate
    {
        get { return comdatestr; }
        set { comdatestr = value; }
    }
    public double PaidAmt
    {
        get { return paidamt; }
        set { paidamt = value; }
    }
    public double NetclmAmt
    {
        get { return netclmamt; }
        set { netclmamt = value; }
    }
    public double Grossclm
    {
        get { return grossclm; }
        set { grossclm = value; }
    }
    public double OutAmt
    {
        get { return outamt; }
        set { outamt = value; }
    }
    public int NoofClaims
    {
        get { return noclims1; }
        set { noclims1 = value; }
    }
    public double TotNetClmAmt
    {
        get { return Totnetamt; }
        set { Totnetamt = value; }
    }
    public double TotPaidAmt
    {
        get { return Totpaidamt; }
        set { Totpaidamt = value; }
    }
    public double TotOutAmt
    {
        get { return Totoutsamt; }
        set { Totoutsamt = value; }
    }

    public string DthDate
    {
        get { return  dthdatestr; }
        set { dthdatestr = value; }
    }
}
