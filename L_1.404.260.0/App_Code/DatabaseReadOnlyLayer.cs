using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Collections.Generic;

/// <summary>
/// Created by Jayampathi
/// Date : 2010/11/15
/// Summary description for DatabaseReadOnlyLayer
/// </summary>
public class DatabaseReadOnlyLayer : DatabaseAccessLayer
{
    public DatabaseReadOnlyLayer()
    {
    }
    public override void OpenTransaction()
    {
        throw new Exception("Function Not Support");
    }
    public override void CommitTransaction()
    {
        throw new Exception("Function Not Support");
    }
    public override void RollbackTransaction()
    {
        throw new Exception("Function Not Support");
    }

    public override bool IsRecordExist(string sql)
    {
        
        // = null;
        bool recordExist = false;
        try
        {
            using (OracleCommand oracleCommand = new OracleCommand())
            {
                oracleCommand.Connection = base.DBConnection;
                oracleCommand.CommandText = sql;
                using (OracleDataReader dr = oracleCommand.ExecuteReader())
                {
                    recordExist = dr.HasRows ;
                }
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
       /* finally
        {
            oracleCommand.Dispose();
            dr.Close();
            dr.Dispose();
        }*/
        return recordExist;
    }
    public override void DisplayRecordsInGridView(GridView gridView, string sql)
    {// this method should not be here 
        // GridView is  a web control
        OracleCommand oracleCommand = new OracleCommand();
        try
        {
            oracleCommand.Connection = base.DBConnection;
            oracleCommand.CommandText = sql;
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
            adapter.SelectCommand = new OracleCommand(sql, base.DBConnection);

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
            DataTableReader dtr = dtTable.CreateDataReader();
            recordExist = dtr.HasRows;
            dtr.Close();
            dtr.Dispose();

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
            dr = oracleCommand.ExecuteReader();
            while (dr.Read())
            {
                recordCount = dr.GetDouble(0);
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
            foreach (StoredProcedureInputParameters p in inputParaList)
            {
                oracleCommand.Parameters.AddWithValue(p.ParamenterName, p.ParameterValue);
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
