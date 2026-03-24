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

/// <summary>
/// Summary description for polMasRead
/// </summary>
public class polMasRead
{
    private string cOD, sta;
    private int pOL, cOM, tBL, tRM, mOD, dUE, pAC, aGT, oRG, bRN, oBR, pTR;
    private double pRM;
    private long sUM;

	public polMasRead(int polno, DataManager dm)
	{
        this.POL = polno;
        string premSel = "select PMCOD, PMCOM, PMTBL, PMTRM, PMSUM, PMMOD, PMPRM, PMDUE, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR from LPHS.PREMAST where pmpol = " + polno + " ";
        if (dm.existRecored(premSel) != 0)
        {
            dm.readSql(premSel);
            OracleDataReader premread = dm.oraComm.ExecuteReader();
            while (premread.Read())
            {
                #region ------ read ----
                sta = "I";
                if (!premread.IsDBNull(0)) { cOD = premread.GetString(0); } else { cOD = ""; }
                if (!premread.IsDBNull(1)) { cOM = premread.GetInt32(1); } else { cOM = 0; }
                if (!premread.IsDBNull(2)) { tBL = premread.GetInt32(2); } else { tBL = 0; }
                if (!premread.IsDBNull(3)) { tRM = premread.GetInt32(3); } else { tRM = 0; }
                if (!premread.IsDBNull(4)) { sUM = premread.GetInt64(4); } else { sUM = 0; }
                if (!premread.IsDBNull(5)) { mOD = premread.GetInt32(5); } else { mOD = 0; }
                if (!premread.IsDBNull(6)) { pRM = premread.GetDouble(6); } else { pRM = 0; }
                if (!premread.IsDBNull(7)) { dUE = premread.GetInt32(7); } else { dUE = 0; }
                if (!premread.IsDBNull(8)) { pAC = premread.GetInt32(8); } else { pAC = 0; }
                if (!premread.IsDBNull(9)) { aGT = premread.GetInt32(9); } else { aGT = 0; }
                if (!premread.IsDBNull(10)) { oRG = premread.GetInt32(10); } else { oRG = 0; }
                if (!premread.IsDBNull(11)) { bRN = premread.GetInt32(11); } else { bRN = 0; }
                if (!premread.IsDBNull(12)) { oBR = premread.GetInt32(12); } else { oBR = 0; }
                if (!premread.IsDBNull(13)) { pTR = premread.GetInt32(13); } else { pTR = 0; }
                #endregion
            }
            premread.Close();
            //premread.Dispose();
        }
        else 
        {
            string lapseSel = "select LPCOD, LPCOM, LPTBL, LPTRM, LPSUM, LPMOD, LPPRM, LPDUE, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR from LPHS.LIFLAPS where LPPOL = " + polno + " ";           
            if (dm.existRecored(lapseSel) != 0)
            {
                dm.readSql(lapseSel);
                OracleDataReader lapseread = dm.oraComm.ExecuteReader();
                while (lapseread.Read())
                {
                    #region ------ read ----
                    sta = "L";
                    if (!lapseread.IsDBNull(0)) { cOD = lapseread.GetString(0); } else { cOD = ""; }
                    if (!lapseread.IsDBNull(1)) { cOM = lapseread.GetInt32(1); } else { cOM = 0; }
                    if (!lapseread.IsDBNull(2)) { tBL = lapseread.GetInt32(2); } else { tBL = 0; }
                    if (!lapseread.IsDBNull(3)) { tRM = lapseread.GetInt32(3); } else { tRM = 0; }
                    if (!lapseread.IsDBNull(4)) { sUM = lapseread.GetInt64(4); } else { sUM = 0; }
                    if (!lapseread.IsDBNull(5)) { mOD = lapseread.GetInt32(5); } else { mOD = 0; }
                    if (!lapseread.IsDBNull(6)) { pRM = lapseread.GetDouble(6); } else { pRM = 0; }
                    if (!lapseread.IsDBNull(7)) { dUE = lapseread.GetInt32(7); } else { dUE = 0; }
                    if (!lapseread.IsDBNull(8)) { pAC = lapseread.GetInt32(8); } else { pAC = 0; }
                    if (!lapseread.IsDBNull(9)) { aGT = lapseread.GetInt32(9); } else { aGT = 0; }
                    if (!lapseread.IsDBNull(10)) { oRG = lapseread.GetInt32(10); } else { oRG = 0; }
                    if (!lapseread.IsDBNull(11)) { bRN = lapseread.GetInt32(11); } else { bRN = 0; }
                    if (!lapseread.IsDBNull(12)) { oBR = lapseread.GetInt32(12); } else { oBR = 0; }
                    if (!lapseread.IsDBNull(13)) { pTR = lapseread.GetInt32(13); } else { pTR = 0; }
                    #endregion
                }
                lapseread.Close();
                //lapseread.Dispose();
            }
            else 
            {
                string lpolhissel = "select PHCOD, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where PHPOL = " + polno + " ";               
                if (dm.existRecored(lpolhissel) != 0)
                {
                    dm.readSql(lpolhissel);
                    OracleDataReader lpolhisRead = dm.oraComm.ExecuteReader();
                    while (lpolhisRead.Read())
                    {
                        #region ------ read ----
                       
                        if (!lpolhisRead.IsDBNull(0)) { cOD = lpolhisRead.GetString(0); } else { cOD = ""; }
                        if (!lpolhisRead.IsDBNull(1)) { cOM = lpolhisRead.GetInt32(1); } else { cOM = 0; }
                        if (!lpolhisRead.IsDBNull(2)) { tBL = lpolhisRead.GetInt32(2); } else { tBL = 0; }
                        if (!lpolhisRead.IsDBNull(3)) { tRM = lpolhisRead.GetInt32(3); } else { tRM = 0; }
                        if (!lpolhisRead.IsDBNull(4)) { sUM = lpolhisRead.GetInt64(4); } else { sUM = 0; }
                        if (!lpolhisRead.IsDBNull(5)) { mOD = lpolhisRead.GetInt32(5); } else { mOD = 0; }
                        if (!lpolhisRead.IsDBNull(6)) { pRM = lpolhisRead.GetDouble(6); } else { pRM = 0; }
                        if (!lpolhisRead.IsDBNull(7)) { dUE = lpolhisRead.GetInt32(7); } else { dUE = 0; }
                        if (!lpolhisRead.IsDBNull(8)) { pAC = lpolhisRead.GetInt32(8); } else { pAC = 0; }
                        if (!lpolhisRead.IsDBNull(9)) { aGT = lpolhisRead.GetInt32(9); } else { aGT = 0; }
                        if (!lpolhisRead.IsDBNull(10)) { oRG = lpolhisRead.GetInt32(10); } else { oRG = 0; }
                        if (!lpolhisRead.IsDBNull(11)) { bRN = lpolhisRead.GetInt32(11); } else { bRN = 0; }
                        if (!lpolhisRead.IsDBNull(12)) { oBR = lpolhisRead.GetInt32(12); } else { oBR = 0; }
                        if (!lpolhisRead.IsDBNull(13)) { pTR = lpolhisRead.GetInt32(13); } else { pTR = 0; }
                        if (!lpolhisRead.IsDBNull(14)) { sta = lpolhisRead.GetString(14); } else { sta = ""; }
                        
                        #endregion
                    }
                    lpolhisRead.Close();
                    //lpolhisRead.Dispose();
                }
                else
                {
                    OldChildProtRead ocr = new OldChildProtRead(polno, dm);
                    if (ocr.Exist == 1)
                    {
                        cOM = ocr.Com;
                        tBL = ocr.Tbl;
                        tRM = ocr.Trm;
                        sUM = long.Parse(ocr.Sumass.ToString());
                    }
                    else
                    {
                        //dm.connclose();
                        throw new Exception("No Policy Details");
                    }
                }
            }
        }

	}

    public polMasRead(int polno, DataManager dm,string pType)
    {
        this.POL = polno;
        string premSel = "select PMCOD, PMCOM, PMTBL, PMTRM, PMSUM, PMMOD, PMPRM, PMDUE, PMPAC, PMAGT, PMORG, PMBRN, PMOBR, PMPTR from LPHS.PREMAST where pmpol = " + polno + " ";
        if (dm.existRecored(premSel) != 0)
        {
            dm.readSql(premSel);
            OracleDataReader premread = dm.oraComm.ExecuteReader();
            while (premread.Read())
            {
                #region ------ read ----
                sta = "I";
                if (!premread.IsDBNull(0)) { cOD = premread.GetString(0); } else { cOD = ""; }
                if (!premread.IsDBNull(1)) { cOM = premread.GetInt32(1); } else { cOM = 0; }
                if (!premread.IsDBNull(2)) { tBL = premread.GetInt32(2); } else { tBL = 0; }
                if (!premread.IsDBNull(3)) { tRM = premread.GetInt32(3); } else { tRM = 0; }
                if (!premread.IsDBNull(4)) { sUM = premread.GetInt64(4); } else { sUM = 0; }
                if (!premread.IsDBNull(5)) { mOD = premread.GetInt32(5); } else { mOD = 0; }
                if (!premread.IsDBNull(6)) { pRM = premread.GetDouble(6); } else { pRM = 0; }
                if (!premread.IsDBNull(7)) { dUE = premread.GetInt32(7); } else { dUE = 0; }
                if (!premread.IsDBNull(8)) { pAC = premread.GetInt32(8); } else { pAC = 0; }
                if (!premread.IsDBNull(9)) { aGT = premread.GetInt32(9); } else { aGT = 0; }
                if (!premread.IsDBNull(10)) { oRG = premread.GetInt32(10); } else { oRG = 0; }
                if (!premread.IsDBNull(11)) { bRN = premread.GetInt32(11); } else { bRN = 0; }
                if (!premread.IsDBNull(12)) { oBR = premread.GetInt32(12); } else { oBR = 0; }
                if (!premread.IsDBNull(13)) { pTR = premread.GetInt32(13); } else { pTR = 0; }
                #endregion
            }
            premread.Close();
            //premread.Dispose();
        }
        else
        {
            string lapseSel = "select LPCOD, LPCOM, LPTBL, LPTRM, LPSUM, LPMOD, LPPRM, LPDUE, LPPAC, LPAGT, LPORG, LPBRN, LPOBR, LPPTR from LPHS.LIFLAPS where LPPOL = " + polno + " ";
            if (dm.existRecored(lapseSel) != 0)
            {
                dm.readSql(lapseSel);
                OracleDataReader lapseread = dm.oraComm.ExecuteReader();
                while (lapseread.Read())
                {
                    #region ------ read ----
                    sta = "L";
                    if (!lapseread.IsDBNull(0)) { cOD = lapseread.GetString(0); } else { cOD = ""; }
                    if (!lapseread.IsDBNull(1)) { cOM = lapseread.GetInt32(1); } else { cOM = 0; }
                    if (!lapseread.IsDBNull(2)) { tBL = lapseread.GetInt32(2); } else { tBL = 0; }
                    if (!lapseread.IsDBNull(3)) { tRM = lapseread.GetInt32(3); } else { tRM = 0; }
                    if (!lapseread.IsDBNull(4)) { sUM = lapseread.GetInt64(4); } else { sUM = 0; }
                    if (!lapseread.IsDBNull(5)) { mOD = lapseread.GetInt32(5); } else { mOD = 0; }
                    if (!lapseread.IsDBNull(6)) { pRM = lapseread.GetDouble(6); } else { pRM = 0; }
                    if (!lapseread.IsDBNull(7)) { dUE = lapseread.GetInt32(7); } else { dUE = 0; }
                    if (!lapseread.IsDBNull(8)) { pAC = lapseread.GetInt32(8); } else { pAC = 0; }
                    if (!lapseread.IsDBNull(9)) { aGT = lapseread.GetInt32(9); } else { aGT = 0; }
                    if (!lapseread.IsDBNull(10)) { oRG = lapseread.GetInt32(10); } else { oRG = 0; }
                    if (!lapseread.IsDBNull(11)) { bRN = lapseread.GetInt32(11); } else { bRN = 0; }
                    if (!lapseread.IsDBNull(12)) { oBR = lapseread.GetInt32(12); } else { oBR = 0; }
                    if (!lapseread.IsDBNull(13)) { pTR = lapseread.GetInt32(13); } else { pTR = 0; }
                    #endregion
                }
                lapseread.Close();
                //lapseread.Dispose();
            }
            else
            {
                string lpolhissel = "select PHCOD, PHCOM, PHTBL, PHTRM, PHSUM, PHMOD, PHPRM, PHDUE, PHPAC, PHAGT, PHORG, PHBRN, PHOBR, PHPTR, PHSTA from LPHS.LPOLHIS where phmos='" + pType + "' and  PHPOL = " + polno + " ";
                if (dm.existRecored(lpolhissel) != 0)
                {
                    dm.readSql(lpolhissel);
                    OracleDataReader lpolhisRead = dm.oraComm.ExecuteReader();
                    while (lpolhisRead.Read())
                    {
                        #region ------ read ----

                        if (!lpolhisRead.IsDBNull(0)) { cOD = lpolhisRead.GetString(0); } else { cOD = ""; }
                        if (!lpolhisRead.IsDBNull(1)) { cOM = lpolhisRead.GetInt32(1); } else { cOM = 0; }
                        if (!lpolhisRead.IsDBNull(2)) { tBL = lpolhisRead.GetInt32(2); } else { tBL = 0; }
                        if (!lpolhisRead.IsDBNull(3)) { tRM = lpolhisRead.GetInt32(3); } else { tRM = 0; }
                        if (!lpolhisRead.IsDBNull(4)) { sUM = lpolhisRead.GetInt64(4); } else { sUM = 0; }
                        if (!lpolhisRead.IsDBNull(5)) { mOD = lpolhisRead.GetInt32(5); } else { mOD = 0; }
                        if (!lpolhisRead.IsDBNull(6)) { pRM = lpolhisRead.GetDouble(6); } else { pRM = 0; }
                        if (!lpolhisRead.IsDBNull(7)) { dUE = lpolhisRead.GetInt32(7); } else { dUE = 0; }
                        if (!lpolhisRead.IsDBNull(8)) { pAC = lpolhisRead.GetInt32(8); } else { pAC = 0; }
                        if (!lpolhisRead.IsDBNull(9)) { aGT = lpolhisRead.GetInt32(9); } else { aGT = 0; }
                        if (!lpolhisRead.IsDBNull(10)) { oRG = lpolhisRead.GetInt32(10); } else { oRG = 0; }
                        if (!lpolhisRead.IsDBNull(11)) { bRN = lpolhisRead.GetInt32(11); } else { bRN = 0; }
                        if (!lpolhisRead.IsDBNull(12)) { oBR = lpolhisRead.GetInt32(12); } else { oBR = 0; }
                        if (!lpolhisRead.IsDBNull(13)) { pTR = lpolhisRead.GetInt32(13); } else { pTR = 0; }
                        if (!lpolhisRead.IsDBNull(14)) { sta = lpolhisRead.GetString(14); } else { sta = ""; }

                        #endregion
                    }
                    lpolhisRead.Close();
                    //lpolhisRead.Dispose();
                }
                else
                {
                    OldChildProtRead ocr = new OldChildProtRead(polno, dm);
                    if (ocr.Exist == 1)
                    {
                        cOM = ocr.Com;
                        tBL = ocr.Tbl;
                        tRM = ocr.Trm;
                        sUM = long.Parse(ocr.Sumass.ToString());
                    }
                    else
                    {
                        //dm.connclose();
                        throw new Exception("No Policy Details");
                    }
                }
            }
        }

    }



    public string STATUS
    {
        get { return sta; }
        set { sta = value; }
    }
    public string COD 
    {
        get { return cOD; }
        set { cOD = value; }
    }
    public int POL
    {
        get { return pOL; }
        set { pOL = value; }
    }

    public int COM
    {
        get { return cOM; }
        set { cOM = value; }
    }
    public int TBL
    {
        get { return tBL; }
        set { tBL = value; }
    }
    public int TRM
    {
        get { return tRM; }
        set { tRM = value; }
    }
    public long SUM
    {
        get { return sUM; }
        set { sUM = value; }
    }
    public int MOD
    {
        get { return mOD; }
        set { mOD = value; }
    }
    public double PRM
    {
        get { return pRM; }
        set { pRM = value; }
    }
    public int DUE
    {
        get { return dUE; }
        set { dUE = value; }
    }
    public int PAC
    {
        get { return pAC; }
        set { pAC = value; }
    }
    public int AGT
    {
        get { return aGT; }
        set { aGT = value; }
    }
    public int ORG
    {
        get { return oRG; }
        set { oRG = value; }
    }
    public int BRN
    {
        get { return bRN; }
        set { bRN = value; }
    }
    public int OBR
    {
        get { return oBR; }
        set { oBR = value; }
    }
    public int PTR
    {
        get { return pTR; }
        set { pTR = value; }
    }

}
