using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Runtime.Serialization;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

[Serializable()]
public class DataManager
{
    [NonSerialized()]
    public OracleConnection oraConn = new OracleConnection();
    [NonSerialized()]
    public OracleCommand oraComm = new OracleCommand();
    [NonSerialized()]
    public OracleTransaction oraTrans;


	public DataManager()
	{
        try
        {
            oraConn.ConnectionString = ConfigurationManager.AppSettings["DBConString"];
            if (oraConn.State != ConnectionState.Open)
                oraConn.Open();
        }
        catch (Exception ee)
        {
            throw ee;
        }
		
	}

    public int addRecored(string sSql)
    {
        if (oraConn.State != ConnectionState.Open)
        { oraConn.Open(); }
        try
        {
            int numRows = 0;
            oraComm.Connection = oraConn;
            oraComm.CommandText = sSql;
            numRows = oraComm.ExecuteNonQuery();
            return numRows;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public string getBranchName(string branchCode)
    {
        int brnCode;
        string sqlQuery;
        string brName;
        DataManager ora;
        OracleDataReader reader;

        brName = "";
        brnCode = 0;
        if (branchCode != "")
        {

            brnCode = int.Parse(branchCode);

            sqlQuery = "SELECT BRNAM FROM GENPAY.BRANCH WHERE BRCOD='" + brnCode + "'";


            ora = new DataManager();
            ora.readSql(sqlQuery);
            reader = ora.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            reader.Read();

            if (!reader.IsDBNull(0))
                brName = reader.GetString(0);
            reader.Close();

        }

        return brName;
    }

    public int existRecored(string sSql)
    {
        if (oraConn.State != ConnectionState.Open)
        { oraConn.Open(); }
        try
        {
            int rows = 0;
            readSql(sSql);
            //OracleDataReader oraDtReader = oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            OracleDataReader oraDtReader = oraComm.ExecuteReader();
            while (oraDtReader.Read())
            {
                rows++;
            }
            oraDtReader.Close();
            return rows;
        }
        catch (Exception exp)
        {
            throw exp;
        }

    }


    public void fillGrid(string sSql, GridView myGrid)
    {
        try
        {
            OracleDataReader oraDbreder = oraComm.ExecuteReader();
            myGrid.DataSource = oraDbreder;
            myGrid.DataBind();

        }
        catch (Exception exp)
        {
            throw exp;
        }


    }


    public void readSql(string sql)
    {
        if (oraConn.State != ConnectionState.Open)
        { oraConn.Open(); }
        try
        {
            oraComm.CommandText = sql;
            oraComm.Connection = oraConn;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public void connClose()
    {
        oraConn.Close();
        oraConn.Dispose();
    }    
    public DataSet getrow(string sql)
    {
        try
        {
            oraComm.Connection = oraConn;
            //oraConn.ConnectionString = ConfigurationManager.AppSettings["DBConString"];
            OracleDataAdapter dataAdd = new OracleDataAdapter(sql, oraConn);
            DataSet ds = new DataSet();
            ds.Clear();
            dataAdd.Fill(ds);

            if (oraConn.State == ConnectionState.Open)
            {
                oraConn.Close();
            }
            return ds;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public void begintransaction()
    {
        oraTrans = oraConn.BeginTransaction();
        oraComm.Transaction = oraTrans;
    }
    public void rollback()
    {
        oraTrans.Rollback();
    }
    public void connclose()
    {
        if (oraConn.State != ConnectionState.Closed)
        {
            oraConn.Close();
            oraConn.Dispose();
        }
    }
    public void commit()
    {
        oraTrans.Commit();
    }

    public int insertRecords(string sSql)
    {
        if (oraConn.State != ConnectionState.Open)
        { oraConn.Open(); }
        try
        {
            int numRows = 0;
            oraComm.Connection = oraConn;
            oraComm.CommandText = sSql;

            numRows = oraComm.ExecuteNonQuery();

            return numRows;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }    

    public int DeleteRecords(string DelQuery)
    {
        int numRows = 0;
        oraComm.Connection = oraConn;
        oraComm.CommandText = DelQuery;

        numRows = oraComm.ExecuteNonQuery();

        return numRows;
    }
}