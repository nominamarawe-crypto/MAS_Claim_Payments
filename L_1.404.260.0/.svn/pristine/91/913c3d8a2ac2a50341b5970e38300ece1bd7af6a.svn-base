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
/// Summary description for Dthintout
/// </summary>
/// 
[Serializable()]
public class Dthintout
{
    private int startdate;
    private int enddate;



    private double Bonusamt=0;
    private int polno;
    private int claimno;
    private double grossamt;
    private double netamt;
    private string causeofdeath;

    private double totgrossamt;
    private double totnetamt;

    private double sumassue;
    private string polstatus;
    private double basicsumassu;
    private string covername;
    private double coversumassu;
    private string lifetype;
    private int  inimatdate;
    private int coverno;


    private string intdatestr;

    private  double basicamt = 0;
    private double adbamt = 0;
    private double sjamt = 0;
    private double feamt = 0;
    private double fpuamt = 0;

    private double totliableamt = 0;
    private  double totbasicamtML = 0;
    private double totadbamtML = 0;
    private double totsjamtML = 0;
    private double totfeamtML = 0;
    private double totfpuamtML = 0;
    private double totbasicamtSp = 0;
    private double totadbamtSp= 0;
    private double totsjamtSp = 0;
    private double totfeamtSp = 0;

    private double totbasicamtSL = 0;
    private double totadbamtSL = 0;
    private double totsjamtSL = 0;
    private double totfeamtSL = 0;
    private double totfpuamtSL = 0;

    private double bomusamt;
    private double totbonusamt=0;

    private double TotalBasicAmt, TotalADBAmt, TotalSJAmt, TotalFEAmt, TotalFPUAmt, TotalLiableAmt,TotalBonusAmt;
    private int noofClaims;
    
    DataManager dm;
    BonusCal bonuscalobj = new BonusCal();
    private List<Dthintout> dthintlistMaker = new List<Dthintout>();
    public void Fetch(int Thestartdate, int Theenddate) 
    {
        startdate = Thestartdate;
        enddate = Theenddate;
        try
        {
            dm = new DataManager();

            string dthrefsel = "select  drpolno,drmos,drclmno, drgrossclm, drnetclm,CAUSEOFDEATHSTR from lphs.dthref where  DENTDT  between " + startdate + "  and " + enddate + "";
            if (dm.existRecored(dthrefsel) != 0)
            {
                dm.readSql(dthrefsel);
                OracleDataReader dthrefreader = dm.oraComm.ExecuteReader();
                while (dthrefreader.Read())
                {
                    Dthintout A=new Dthintout();
                    if (!dthrefreader.IsDBNull(0)) { polno = dthrefreader.GetInt32(0); } else { polno = 0; }
                    if (!dthrefreader.IsDBNull(1)) { lifetype = dthrefreader.GetString(1);  } else { lifetype = ""; }
                    if (!dthrefreader.IsDBNull(2)) { claimno = dthrefreader.GetInt32(2); } else { claimno = 0; }
                    if (!dthrefreader.IsDBNull(3)) { grossamt = dthrefreader.GetDouble(3); } else { grossamt = 0; }
                    if (!dthrefreader.IsDBNull(4)) { netamt = dthrefreader.GetDouble(4); } else { netamt = 0; }
                    if (!dthrefreader.IsDBNull(5)) { causeofdeath= dthrefreader.GetString(5); } else { causeofdeath= ""; }

                    totgrossamt += grossamt;
                    totnetamt += netamt;
                    if (lifetype.Equals("M"))
                    {
                        string rcoversel = "select RSUMAS,RCOVR from lund.rcover where rpol='" +polno+ "'";
                        if (dm.existRecored(rcoversel) != 0)
                        {
                            dm.readSql(rcoversel);
                            OracleDataReader rcoverread = dm.oraComm.ExecuteReader();
                            basicamt = 0;
                            adbamt = 0;
                            sjamt = 0;
                            feamt = 0;
                            fpuamt = 0;
                            bomusamt = 0;
                            while(rcoverread.Read())
                            {                                
                                if (!rcoverread.IsDBNull(0)) { coversumassu = rcoverread.GetDouble(0); } else { coversumassu = 0; }
                                if (!rcoverread.IsDBNull(1)) { coverno = rcoverread.GetInt32(1); } else { coverno = 0; }

                              

                                if (coverno == 1) {  basicamt = coversumassu;  }
                                else if ((coverno == 2)&&(causeofdeath.Equals("ACCIDENT"))) { adbamt = coversumassu;  }
                                else if (coverno == 4) {  fpuamt = coversumassu; }
                                else if (coverno == 10) {  sjamt = coversumassu;  }
                                else if (coverno == 11) { feamt = coversumassu;  }
                                else { covername = ""; }

                                
                             }
                             totbasicamtML += basicamt;
                             totadbamtML += adbamt;
                             totfpuamtML += fpuamt;
                             totfeamtML += feamt;
                             totsjamtML += sjamt;
                            // totliableamt = (basicamt + adbamt + sjamt + feamt + fpuamt );
                           

                        }
                    } 
                   else if (lifetype.Equals("S"))
                    {
                        string rcoversel = "select RSUMAS,RCOVR from lund.rcover where rpol=" + polno + "";
                        if (dm.existRecored(rcoversel) != 0)
                        {
                            dm.readSql(rcoversel);
                            OracleDataReader rcoverread = dm.oraComm.ExecuteReader();
                            basicamt = 0;
                            adbamt = 0;
                            sjamt = 0;
                            feamt = 0;
                            bomusamt = 0;
                            while (rcoverread.Read())
                            {
                                if (!rcoverread.IsDBNull(0)) { coversumassu = rcoverread.GetDouble(0); } else { coversumassu = 0; }
                                if (!rcoverread.IsDBNull(1)) { coverno = rcoverread.GetInt32(1); } else { coverno = 0; }


                                if (coverno == 1) { basicamt = coversumassu;  }
                                else if ((coverno == 102) && (causeofdeath.Equals("ACCIDENT"))) { adbamt = coversumassu;  }
                                else if (coverno == 110) {  sjamt = coversumassu; }
                                else if (coverno == 111) {  feamt = coversumassu;  }
                                else { covername = ""; }
                               
                               

                            }
                            totbasicamtSL += basicamt;
                            totadbamtSL += adbamt;
                            totfpuamtSL += fpuamt;
                            totfeamtSL += feamt;
                            totsjamtSL += sjamt;

                            //totliableamt = (basicamt + adbamt + sjamt + feamt );
                           

                        }
                    }
                    else if ((lifetype.Equals("2")) || (lifetype.Equals("C")))
                    {
                        string rcoversel = "select RSUMAS,RCOVR from lund.rcover where rpol='" + polno + "'";
                        if (dm.existRecored(rcoversel) != 0)
                        {
                            dm.readSql(rcoversel);
                            OracleDataReader rcoverread = dm.oraComm.ExecuteReader();
                            basicamt = 0;
                            adbamt = 0;
                            sjamt = 0;
                            feamt = 0;
                            fpuamt = 0;
                            bomusamt = 0;
                            while (rcoverread.Read())
                            {
                                if (!rcoverread.IsDBNull(0)) { coversumassu = rcoverread.GetDouble(0); } else { coversumassu = 0; }
                                if (!rcoverread.IsDBNull(1)) { coverno = rcoverread.GetInt32(1); } else { coverno = 0; }

                                if (coverno == 1) {  basicamt = coversumassu;  }
                                else if ((coverno == 202)&&(causeofdeath.Equals("ACCIDENT"))) { adbamt = coversumassu;  }
                                else if (coverno == 204) {  fpuamt = coversumassu;  }
                                else if (coverno == 210) {  sjamt = coversumassu;  }
                                else if (coverno == 211) {  feamt = coversumassu;  }
                                else { covername = ""; }
                               
                             }
                             totbasicamtSp += basicamt;
                             totadbamtSp += adbamt;
                             totsjamtSp += sjamt;
                             totfeamtSp += feamt;

                            //totliableamt = (basicamt + adbamt + sjamt + feamt);
                           
                        }
                    }

                    TOTBasic = (totbasicamtML + totbasicamtSL + totbasicamtSp);
                    TotalSJAmt = (totsjamtML + totsjamtSL + totsjamtSp);
                    TotalADBAmt = (totadbamtML + totadbamtSL + totadbamtSp);
                    TotalFEAmt = (totfeamtML + totfeamtSL + totfeamtSp);
                    TotalFPUAmt = (totfpuamtML + totfpuamtSL);
                    TotalLiableAmt = (TOTBasic + TotalSJAmt + TotalADBAmt + TotalFEAmt + TotalFPUAmt);
                    noofClaims = DthIntListMake.Count+1;
                    //TotalLiableAmt += totliableamt;
                    A.TOTLiabeAmt =TotalLiableAmt;
                    DthIntListMake.Add(A);
                    A.NoofClaims = noofClaims;
                   
                   }
                dthrefreader.Close();
				dthrefreader.Dispose();
                }
            dm.connClose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public List<Dthintout> DthIntListMake
    {
        get { return dthintlistMaker; }
        set { dthintlistMaker = value; }
    }
    public int Polno
    {
        get { return polno; }
        set { polno = value;}
    }

    public double BasicSumAsu
    {
        get { return basicsumassu; }
        set { basicsumassu = value;}
    }

    public string Cvrname
    {
        get { return covername; }
        set { covername = value;}
    }

    public double CoverSumAsu
    {
        get { return coversumassu; }
        set { coversumassu= value; }
    }

    public string IntimationDt
    {
        get { return intdatestr; }
        set { intdatestr = value;}
    }

    public string LifeType
    {
        get { return lifetype; }
        set { lifetype = value; }
    }
    public double Bonus
    {
        get { return Bonusamt; }
        set { Bonusamt = value; }
    }

    public double BasicCoverSumAsu
    {
        get { return basicamt; }
        set { basicamt = value; }
    }
    public double ADBCoverSumAsu
    {
        get { return adbamt; }
        set { adbamt = value; }
    }

    public double SJCoverSumAsu
    {
        get { return sjamt; }
        set { sjamt = value; }
    }
    public double FECoverSumAsu
    {
        get { return feamt; }
        set { feamt= value; }
    }
    public double FPUSumAsu
    {
        get { return fpuamt; }
        set { fpuamt = value; }
    }

    public double TOTLiable
    {
        get { return totliableamt; }
        set { totliableamt = value; }
    }

    public double TOTBasic
    {
        get { return TotalBasicAmt; }
        set { TotalBasicAmt = value; }
    }
    public double TOTAdb
    {
        get { return TotalADBAmt; }
        set { TotalADBAmt = value; }
    }
    public double TOTSj
    {
        get { return TotalSJAmt; }
        set { TotalSJAmt = value; }
    }
    public double TOTFe
    {
        get { return TotalFEAmt; }
        set { TotalFEAmt = value; }
    }

    public double TOTFpu
    {
        get { return TotalFPUAmt; }
        set { TotalFPUAmt = value; }
    }
    public double TOTLiabeAmt
    {
        get { return TotalLiableAmt; }
        set { TotalLiableAmt = value; }
    }

    public int NoofClaims
    {
        get { return noofClaims; }
        set {noofClaims=value; }
    
    }

    public double TOTBonus
    {
        get { return TotalBonusAmt; }
        set { TotalBonusAmt = value; }
    }
    public double TOTGrossAmt
    {
        get { return totgrossamt; }
        set { totgrossamt = value; }
    }
    public double TOTNetAmt
    {
        get { return totnetamt; }
        set { totnetamt = value; }
    }
}
