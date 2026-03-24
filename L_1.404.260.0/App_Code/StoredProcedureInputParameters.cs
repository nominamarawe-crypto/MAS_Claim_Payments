using System;
using System.Data;
/// <summary>
/// Summary description for StoredProcedureInputParameters
/// </summary>
public class StoredProcedureInputParameters
{
    public StoredProcedureInputParameters()
    {

    }

    private string parameterName;
    private string parameterValue;
    private DatabaseAccessLayer.ParaType paraType;
    private int parameterSize;
    private object value;
    public string ParamenterName
    {
        get { return parameterName; }
    }
    public string ParameterValue
    {
        get { return parameterValue; }
    }
    public int ParamSize
    {
        get { return parameterSize; }
    }
    public DatabaseAccessLayer.ParaType ParamType
    {
        get { return paraType; }
    }
    public object Value
    {
        get { return value; }
    }
    public StoredProcedureInputParameters(string parameterName, string parameterValue)
    {
        this.parameterName = parameterName;
        this.parameterValue = parameterValue;
        this.value = parameterValue;
    }
    public StoredProcedureInputParameters(string parameterName, DatabaseAccessLayer.ParaType pt, int size)
    {
        this.parameterName = parameterName;
        this.parameterSize = size;
        this.paraType = pt;
    }
    public StoredProcedureInputParameters(string parameterName, object parameterValue)
    {
        this.parameterName = parameterName;
        this.value = parameterValue;
    }
}
