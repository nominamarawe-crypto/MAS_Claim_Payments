using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Collections.Generic;
/// <summary>
/// Summary description for DatabaseTransactionLayer
/// </summary>
public class DatabaseTransactionLayer : DatabaseAccessLayer
{
    private OracleTransaction oraTransaction;

    public DatabaseTransactionLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override void OpenTransaction()
    {
        oraTransaction = base.DBConnection.BeginTransaction();
    }
    public override void CommitTransaction()
    {
        oraTransaction.Commit();
    }
    public override void RollbackTransaction()
    {
        oraTransaction.Rollback();
    }

    public override bool IsRecordExist(string sql)
    {
        OracleCommand oracleCommand = new OracleCommand();
        OracleDataReader dr = null;
        bool recordExist = false;
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.Transaction = oraTransaction;
            oracleCommand.CommandText = sql;
            dr = oracleCommand.ExecuteReader();
            recordExist = dr.HasRows;
        }
        catch (Exception exp)
        {
            throw exp;
        }
        finally
        {
            oracleCommand.Dispose();
            dr.Close();
            dr.Dispose();
        }
        return recordExist;
    }
    public override void DisplayRecordsInGridView(GridView gridView, string sql)
    {    // this method should not be here 
        // GridView is  a web control

        OracleCommand oracleCommand = new OracleCommand();
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandText = sql;
            oracleCommand.Transaction = oraTransaction;
            OracleDataReader dr = oracleCommand.ExecuteReader();
            gridView.DataSource = dr;
            gridView.DataBind();

        }
        catch (Exception exp)
        { throw exp; }
    }

    public override DataTable ReadSQLtoDataTable(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(sql, base.DBConnection, oraTransaction);

            adapter.Fill(dt);
            adapter.Dispose();
        }
        catch (Exception exp)
        {
            throw exp;
        }
        return dt;
    }
    public override bool HasRecords(DataTable dtTable)
    {
        bool recordExist = false;
        try
        {
            using (DataTableReader dtr = dtTable.CreateDataReader())
            {
                recordExist = dtr.HasRows;
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
        
        return recordExist;
    }

    //added by sindu
    public override double Count(string sql)
    {
        OracleCommand oracleCommand = new OracleCommand();
        OracleDataReader dr = null;
        double recordCount = 0;
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandText = sql;
            oracleCommand.Transaction = oraTransaction;
            dr = oracleCommand.ExecuteReader();
            while (dr.Read())
            {
                recordCount = dr.GetInt32(0);
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
        finally
        {
            oracleCommand.Dispose();
            dr.Close();
            dr.Dispose();
        }
        return recordCount;
    }
    public override int CountRecords(string sql)
    {
        OracleCommand oracleCommand = new OracleCommand();
        OracleDataReader dr = null;
        int recordCount = 0;
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandText = sql;
            oracleCommand.Transaction = oraTransaction;
            dr = oracleCommand.ExecuteReader();
            while (dr.Read())
            {
                recordCount = dr.GetInt32(0);
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
        finally
        {
            oracleCommand.Dispose();
            dr.Close();
            dr.Dispose();
        }
        return recordCount;
    }

 
    public override void ExecuteTableUpdateQuery(string updateQuery)
    {
        OracleCommand oracleCommand = new OracleCommand();
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.CommandText = updateQuery;
            oracleCommand.Transaction = oraTransaction;
            oracleCommand.ExecuteNonQuery();
        }
        catch (Exception exp)
        {
            throw exp;
        }
        finally
        {
            oracleCommand.Dispose();
        }

    }
    public override void ExecuteSotredProcedure(string procedureName, List<StoredProcedureInputParameters> paraList)
    {
        OracleCommand oracleCommand = new OracleCommand();
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.CommandText = procedureName;
            oracleCommand.Transaction = oraTransaction;
            foreach (StoredProcedureInputParameters p in paraList)
            {
                oracleCommand.Parameters.AddWithValue(p.ParamenterName, p.Value);
            }
            oracleCommand.ExecuteNonQuery();
        }
        catch (Exception exp)
        {
            throw exp;
        }
        finally
        {
            oracleCommand.Dispose();
        }
    }

    public override List<StoredProcedureInputParameters> ExecuteSotredProcedure(string procedureName, List<StoredProcedureInputParameters> inputParaList, List<StoredProcedureInputParameters> outParamList)
    {
        string errorCount = "";
        OracleCommand oracleCommand = new OracleCommand();
        List<StoredProcedureInputParameters> outputList = new List<StoredProcedureInputParameters>();
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.CommandText = procedureName;
            oracleCommand.Transaction = oraTransaction;
            foreach (StoredProcedureInputParameters p in inputParaList)
            {
                oracleCommand.Parameters.AddWithValue(p.ParamenterName, p.Value);
            }

            /*OracleParameter prm2 = oracleCommand.Parameters.Add("p_Erroressage", OracleType.VarChar, 60);//p_Error  out varchar
            // prm2.Direction = ParameterDirection.InputOutput;
             // prm2 = oracleCommand.Parameters.Add("p_Error", OracleType.VarChar, 60); 
            // prm2.Direction = ParameterDirection.InputOutput;
           */
            foreach (StoredProcedureInputParameters p in outParamList)
            {
                oracleCommand.Parameters.Add(p.ParamenterName, (OracleType)p.ParamType, p.ParamSize);
                oracleCommand.Parameters[p.ParamenterName].Direction = ParameterDirection.Output;
            }
            oracleCommand.ExecuteNonQuery();
            foreach (StoredProcedureInputParameters p in outParamList)
            {
                outputList.Add(new StoredProcedureInputParameters(p.ParamenterName, oracleCommand.Parameters[p.ParamenterName].Value));
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
        finally
        {
            oracleCommand.Dispose();
        }
        return outputList;
    }
}
