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
/// Summary description for Table56
/// </summary>
///
[Serializable()]
public class Table56
{
    private int endorsementNo;
    private double mainlifeCoverAmount;
    private double mainlifeOEXAmount;
    private double mainlifeHEXAmount;
    private double mainlifeDISAmount;
    DataManager dm;

	public Table56()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Boolean isHavePremiumPaidCover(long polno)
    {
        dm = new DataManager();
        try
        {

            string rcoversel = "select * from LUND.RCOVER where rcovr>100 and rprm>0 and rpol=" + polno + "";
            if (dm.existRecored(rcoversel) != 0)
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

    public Boolean isOCCEXHave(long polno)
    {
        dm = new DataManager();
        try
        {

            string rcoversel = "select * from LUND.RCOVER where rcovr<100 and roex='Y' and rpol=" + polno + "";
            if (dm.existRecored(rcoversel) != 0)
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

    public Boolean isHEXHave(long polno)
    {
        dm = new DataManager();
        try
        {

            string rcoversel = "select * from LUND.RCOVER where rcovr<100 and rhex='Y' and rpol=" + polno + "";
            if (dm.existRecored(rcoversel) != 0)
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

    public Boolean isDiscountHave(long polno)
    {
        dm = new DataManager();
        try
        {

            string rcoversel = "select * from LUND.RCOVER where rcovr<100 and rdiscon='Y' and rpol=" + polno + "";
            if (dm.existRecored(rcoversel) != 0)
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

    public int getCoverEndorsementNo(long polno)
    {
        dm.oraComm.Connection = dm.oraConn;
        dm.oraComm.CommandType = CommandType.StoredProcedure;
        dm.oraComm.CommandText = "LPHS.AJUSTMENT.getEndorsementNo";
        dm.oraComm.Parameters.Clear();
        dm.oraComm.Parameters.AddWithValue("p_pol", polno.ToString());
        dm.oraComm.Parameters.AddWithValue("p_type", "P");
        OracleParameter para = new OracleParameter("p_out", OracleType.Number);
        para.Size = 3;
        para.Direction = ParameterDirection.Output;
        dm.oraComm.Parameters.Add(para);
        dm.oraComm.ExecuteNonQuery();

        endorsementNo = int.Parse(dm.oraComm.Parameters["p_out"].Value.ToString());
        dm.oraComm.Parameters.Clear();

        return endorsementNo;
    }

    public double getMainLifeCoverAmount(long polno)
    {
        dm = new DataManager();
        try
        {

            string rcoversel = "select sum(nvl(rprm,0)) from LUND.RCOVER where rcovr<100  and rpol=" + polno + "";
            if (dm.existRecored(rcoversel) != 0)
            {
                dm.readSql(rcoversel);
                OracleDataReader rcoverreader = dm.oraComm.ExecuteReader();
                while (rcoverreader.Read())
                {
                    if (!rcoverreader.IsDBNull(0)) { mainlifeCoverAmount = rcoverreader.GetDouble(0); } else { mainlifeCoverAmount = 0; }
                }
            }
            else
            {
                mainlifeCoverAmount = 0;
            }
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.connClose();
            throw Ex;
        }

        return mainlifeCoverAmount;
    }

    public double getMainLifeOEXAmount(long polno)
    {
        dm = new DataManager();
        try
        {

            string roccexsel = "select sum(nvl(oeamt,0)) from LUND.ROCCEX where rcovr<100 and  rpol=" + polno + "";
            if (dm.existRecored(roccexsel) != 0)
            {
                dm.readSql(roccexsel);
                OracleDataReader roccexreader = dm.oraComm.ExecuteReader();
                while (roccexreader.Read())
                {
                    if (!roccexreader.IsDBNull(0)) { mainlifeOEXAmount = roccexreader.GetDouble(0); } else { mainlifeOEXAmount = 0; }
                }
            }
            else
            {
                mainlifeOEXAmount = 0;
            }
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.connClose();
            throw Ex;
        }

        return mainlifeOEXAmount;
    }

    public double getMainLifeHEXAmount(long polno)
    {
        dm = new DataManager();
        try
        {

            string rhexsel = "select sum(nvl(heamt,0)) from LUND.RHELEX where rcovr<100 and  rpol=" + polno + "";
            if (dm.existRecored(rhexsel) != 0)
            {
                dm.readSql(rhexsel);
                OracleDataReader rhexreader = dm.oraComm.ExecuteReader();
                while (rhexreader.Read())
                {
                    if (!rhexreader.IsDBNull(0)) { mainlifeHEXAmount = rhexreader.GetDouble(0); } else { mainlifeHEXAmount = 0; }
                }
            }
            else
            {
                mainlifeHEXAmount = 0;
            }
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.connClose();
            throw Ex;
        }

        return mainlifeHEXAmount;
    }

    public double getMainLifeDiscountAmount(long polno)
    {
        dm = new DataManager();
        try
        {

            string rdiscsel = "select sum(nvl(disamt,0)) from LUND.RDISCON where rcovr<100 and  rpol=" + polno + "";
            if (dm.existRecored(rdiscsel) != 0)
            {
                dm.readSql(rdiscsel);
                OracleDataReader rdiscreader = dm.oraComm.ExecuteReader();
                while (rdiscreader.Read())
                {
                    if (!rdiscreader.IsDBNull(0)) { mainlifeDISAmount = rdiscreader.GetDouble(0); } else { mainlifeDISAmount = 0; }
                }
            }
            else
            {
                mainlifeDISAmount = 0;
            }
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.connClose();
            throw Ex;
        }

        return mainlifeDISAmount;
    }
}