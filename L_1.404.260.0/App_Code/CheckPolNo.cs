using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.OracleClient;

/// <summary>
/// Summary description for CheckPolNo
/// </summary>
public class CheckPolNo
{
    private string SelQry;
    DataManager dm ;

	public CheckPolNo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string CheckPolicyNumber(int Polno)
    {
        dm = new DataManager();
        string Flag ="";
        SelQry = "Select POLNO from lphs.dthout where POLNO=" + Polno + "";
        if (dm.existRecored(SelQry) != 0)
        {
            Flag = "D";
        }
        else if (dm.existRecored(SelQry) == 0)
        {
            SelQry = "Select EXTPOL from lphs.exsurren where EXTPOL=" + Polno + "";
            if (dm.existRecored(SelQry) != 0)
            {
                Flag = "E";
            }
            else if (dm.existRecored(SelQry) == 0)
            {
                SelQry = "select LMPOL from lclm.lifmats where LMPOL=" + Polno + "";
                if (dm.existRecored(SelQry) != 0)
                {
                    Flag = "M";
                }
                else if (dm.existRecored(SelQry) == 0)
                {
                    SelQry = "select PMPOL from lphs.premast where PMPOL=" + Polno + "";
                    if (dm.existRecored(SelQry) != 0)
                    {
                        Flag = "P";
                    }
                    else
                    {
                        SelQry = "select LPPOL from lphs.liflaps where LPPOL=" + Polno + "";
                        if (dm.existRecored(SelQry) != 0)
                        {
                            Flag = "L";
                        }
                        else
                        {
                            Flag = "";
                        }
                    }
                }
            }
        
        }
        return Flag;
    }

    public int GetTable(int Polno)
    {
        dm = new DataManager();
        int table = 0;
        SelQry = "Select TBL from lphs.dthout where POLNO=" + Polno + "";
        if (dm.existRecored(SelQry) != 0)
        {
            dm.readSql(SelQry);
            OracleDataReader red = dm.oraComm.ExecuteReader();
            while (red.Read())
            {
                table = red.GetInt32(0);
            }
            red.Close();

        }
        else if (dm.existRecored(SelQry) == 0)
        {
            SelQry = "Select EXTTBL from lphs.exsurren where EXTPOL=" + Polno + "";
            if (dm.existRecored(SelQry) != 0)
            {
                dm.readSql(SelQry);
                OracleDataReader red = dm.oraComm.ExecuteReader();
                while (red.Read())
                {
                    table = red.GetInt32(0);
                }
                red.Close();
            }
            else if (dm.existRecored(SelQry) == 0)
            {
                SelQry = "select LMTBL from lclm.lifmats where LMPOL=" + Polno + "";
                if (dm.existRecored(SelQry) != 0)
                {
                    dm.readSql(SelQry);
                    OracleDataReader red = dm.oraComm.ExecuteReader();
                    while (red.Read())
                    {
                        table = red.GetInt32(0);
                    }
                    red.Close();
                }
                else if (dm.existRecored(SelQry) == 0)
                {
                    SelQry = "select PMTBL from lphs.premast where PMPOL=" + Polno + "";
                    if (dm.existRecored(SelQry) != 0)
                    {
                        dm.readSql(SelQry);
                        OracleDataReader red = dm.oraComm.ExecuteReader();
                        while (red.Read())
                        {
                            table = red.GetInt32(0);
                        }
                        red.Close();
                    }
                    else
                    {
                        SelQry = "select LPTBL from lphs.liflaps where LPPOL=" + Polno + "";
                        if (dm.existRecored(SelQry) != 0)
                        {
                            dm.readSql(SelQry);
                            OracleDataReader red = dm.oraComm.ExecuteReader();
                            while (red.Read())
                            {
                                table = red.GetInt32(0);
                            }
                            red.Close();
                        }
                        else
                        {
                            dm.readSql(SelQry);
                            OracleDataReader red = dm.oraComm.ExecuteReader();
                            while (red.Read())
                            {
                                table = red.GetInt32(0);
                            }
                            red.Close();
                        }
                    }
                }
            }
        }
        return table;
    }
}
