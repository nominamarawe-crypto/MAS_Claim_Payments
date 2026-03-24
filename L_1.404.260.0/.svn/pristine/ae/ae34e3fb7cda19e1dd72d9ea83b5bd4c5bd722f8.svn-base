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

[Serializable()]
public class dthOutClms
{

    private long polno;
    private string MOS;
    private long claimNo;
    private double netClm;
    private double grossclm;
    private double amtout;
    private double TOTPAYAMT;
    private string PAYEE;
    private int dtofint;
    private int dtofdth;
    private int DCO;
    private long BSA;
    private int tbl;
    private int trm;
    private double totPaidAmount;
    private double cliamOutstanding;
    private double exgraciaAmt;

    DataManager dmo;

    public dthOutClms(long polnoP, string MOSP, long claimNoP, double netClmP, double grossclmP, double amtoutP, double TOTPAYAMTP, string PAYEEP, double exgraciaP)
    {
        dmo = new DataManager();

        if (PAYEE == null) { PAYEE = ""; }
        this.polno = polnoP;
        this.MOS = MOSP;
        this.claimNo = claimNoP;
        this.netClm = netClmP;
        this.grossclm = grossclmP;
        this.amtout = amtoutP;
        this.TOTPAYAMT = TOTPAYAMTP;
        this.PAYEE = PAYEEP;
        this.exgraciaAmt = exgraciaP;

        #region //------------ dthint --------------
        string dthintDetails = "select dinfodat, ddtofdth  from lphs.dthint where dpolno=" + polno + " and dmos='" + MOS + "' ";
         if (dmo.existRecored(dthintDetails) != 0)
         {
             dmo.readSql(dthintDetails);
             OracleDataReader dthintReader = dmo.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
             while (dthintReader.Read())
             {
                 if (!dthintReader.IsDBNull(0)) { dtofint = dthintReader.GetInt32(0); }
                 if (!dthintReader.IsDBNull(1)) { dtofdth = dthintReader.GetInt32(1); }
             }
             dthintReader.Close();
             dthintReader.Dispose();
         }
        #endregion

        #region //------------ lpolhis --------------

         string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phsta from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOS + "' ";
         if (dmo.existRecored(polhisSelect) != 0) 
         {
             dmo.readSql(polhisSelect);
             OracleDataReader polhisReader = dmo.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
             polhisReader.Read();
             if (!polhisReader.IsDBNull(0)) { BSA = polhisReader.GetInt64(0); } else { BSA = 0; }
             if (!polhisReader.IsDBNull(1)) { tbl = polhisReader.GetInt32(1); } else { tbl = 0; }
             if (!polhisReader.IsDBNull(2)) { trm = polhisReader.GetInt32(2); } else { trm = 0; }
             if (!polhisReader.IsDBNull(3)) { DCO = polhisReader.GetInt32(3); } else { DCO = 0; }
             polhisReader.Close();
             polhisReader.Dispose();
         }

        #endregion

        #region //------------ amount outstanding --------------

         if (PAYEE.Equals("LHI"))
         {
             #region
             string heireSelect = "select sum(LHAMOUNT) from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOS + "' and vousta = 'Y' and vouno is not null ";
             if (dmo.existRecored(heireSelect) != 0)
             {
                 dmo.readSql(heireSelect);
                 OracleDataReader heireSelectReader = dmo.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                 heireSelectReader.Read();
                 if (!heireSelectReader.IsDBNull(0)) { totPaidAmount = heireSelectReader.GetDouble(0); }
                 heireSelectReader.Close();
                 heireSelectReader.Dispose();

                 totPaidAmount += ((totPaidAmount / TOTPAYAMT) * exgraciaAmt);

             }

             #endregion
         }
         else if (PAYEE.Equals("ASI"))
         {
             #region
              string asiSelect = "select vouno from LUND.ASSIGNEE  where POLICY_NO = " + polno + " and vousta = 'Y' and vouno is not null";
              if (dmo.existRecored(asiSelect) != 0)
              {
                  totPaidAmount = TOTPAYAMT + exgraciaAmt;              
              }

             #endregion
         }
         else if (PAYEE.Equals("NOM"))
         {
             #region
             double PER = 0;
              string nomSelect = "select sum(NOMPER) from LUND.NOMINEE where POLNO = " + polno + " and vousta = 'Y' and vouno is not null";
              if (dmo.existRecored(nomSelect) != 0)
              {
                  dmo.readSql(nomSelect);
                  OracleDataReader nomineeReader = dmo.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                  nomineeReader.Read();
                  if (!nomineeReader.IsDBNull(0)) { PER = nomineeReader.GetDouble(0); } else { PER = 0; }
                  nomineeReader.Close();
                  nomineeReader.Dispose();
                  totPaidAmount = (TOTPAYAMT * PER) + (exgraciaAmt * PER);
              }

             #endregion
         }
         else if (PAYEE.Equals("LPT"))
         {
             #region
             string living_prtSelect = "select vouno from LUND.LIVING_PRT where polno = " + polno + " and vousta = 'Y' and vouno is not null ";
             if (dmo.existRecored(living_prtSelect) != 0)
             {
                 totPaidAmount = TOTPAYAMT + exgraciaAmt;
             }

             #endregion
         }

        #endregion

        //?????????????? exgracia ??????????????????????????

         cliamOutstanding = TOTPAYAMT - (totPaidAmount + amtout);
        

         dmo.connclose();
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mOS
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public long ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }
    public double NetClm
    {
        get { return netClm; }
        set { netClm = value; }
    }
    public double Grossclm
    {
        get { return grossclm; }
        set { grossclm = value; }
    }
    public double Amtout
    {
        get { return cliamOutstanding; }
        set { cliamOutstanding = value; }
    }
    public double tOTPAYAMT
    {
        get { return TOTPAYAMT; }
        set { TOTPAYAMT = value; }
    }
    public string pAYEE
    {
        get { return PAYEE; }
        set { PAYEE = value; }
    }
    public int Dtofint
    {
        get { return dtofint; }
        set { dtofint = value; }
    }
    public int Dtofdth
    {
        get { return dtofdth; }
        set { dtofdth = value; }
    }
    public int dCO
    {
        get { return DCO; }
        set { DCO = value; }
    }
    public long bSA
    {
        get { return BSA; }
        set { BSA = value; }
    }
    public int Tbl
    {
        get { return tbl; }
        set { tbl = value; }
    }
    public int Trm
    {
        get { return trm; }
        set { trm = value; }
    }
    public double CliamOutstanding
    {
        get { return cliamOutstanding; }
        set { cliamOutstanding = value; }
    }

}
