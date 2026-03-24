using System;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Web.UI.WebControls;
/// <summary>
/// Created by Jayampathi
/// Date : 2010/11/15
/// Summary description for DatabaseConnection
/// </summary>
public abstract class DatabaseAccessLayer : IDisposable 
{

    void IDisposable.Dispose() { }

    public DatabaseAccessLayer()
    {
        try
        {
            oraConn = new OracleConnection();
            oraConn.ConnectionString = connString;
            oraConn.Open();
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    private string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    private OracleConnection oraConn;

    public enum ParaType
    {
        VarChar = OracleType.VarChar,
        Number = OracleType.Number,
        Float = OracleType.Float
    };
    public OracleConnection DBConnection
    {
        get { return oraConn; }
    }
    public void OpenDBConnection()
    {

    }
    public void CloseDBConnection()
    {
        try
        {
            if (oraConn.State.ToString().Equals("Open"))
            {
                oraConn.Close();
                oraConn.Dispose();
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public abstract int CountRecords(string sql);
    public abstract double Count(string sql);
    public abstract bool IsRecordExist(string sql);
    public abstract void DisplayRecordsInGridView(GridView gridView, string sql);
    public abstract DataTable ReadSQLtoDataTable(string sql);
    public abstract bool HasRecords(DataTable dtTable);
    public abstract void OpenTransaction();
    public abstract void CommitTransaction();
    public abstract void RollbackTransaction();


    public virtual void ExecuteTableUpdateQuery(string sql)
    {
        throw new Exception("Function Not Support\n");
    }
    public virtual void ExecuteSotredProcedure(string procedureName, List<StoredProcedureInputParameters> paraList)
    {
        throw new Exception("Function Not Support\n");
    }
    public virtual List<StoredProcedureInputParameters> ExecuteSotredProcedure(string procedureName, List<StoredProcedureInputParameters> paraList, List<StoredProcedureInputParameters> outParamList)
    {
        throw new Exception("Function Not Support\n");
    }
    public virtual void UpdateOrInsertRecords(string sql)
    {
        throw new Exception("Function Not Support\n");
    }
}

