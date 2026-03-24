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
using System.Runtime.Serialization;
/// <summary>
/// Summary description for OraManager
/// </summary>

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
            reader.Dispose();

        }

        return brName;
    }
    public int getBranchcode(string branchname)
    {
        int brnCode;
        string sqlQuery;
        string brName;
        DataManager ora;
        OracleDataReader reader;

        brName = "";
        brnCode = 0;
        if (branchname != "")
        {

            brName = branchname;

            sqlQuery = "SELECT BRCOD FROM GENPAY.BRANCH WHERE Trim(BRNAM)='" + brName.Trim() + "'";


            ora = new DataManager();
            ora.readSql(sqlQuery);
            reader = ora.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            reader.Read();

            if (!reader.IsDBNull(0))
                brnCode = reader.GetInt32(0);
            reader.Close();
            reader.Dispose();

        }

        return brnCode;
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

            //while (oraDtReader.Read())
            //{
              
            if (oraDtReader.HasRows)
            {
                rows = 1;
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
    public int getMaxId(string sql)
    {
        try
        {

            int id = 0;
            readSql(sql);
            OracleDataReader oraDtReader = oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (oraDtReader.Read())
            {
                if (!oraDtReader.IsDBNull(0))
                {
                    id = oraDtReader.GetInt32(0);
                }
            }
            oraDtReader.Close();
            oraDtReader.Dispose();
            return id + 1;

        }
        catch (Exception exp)
        {
            throw exp;
        }
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

        oraTrans = oraConn.BeginTransaction(IsolationLevel.ReadCommitted);

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

    public string voucher_number(string year, string brn)
    {

        string sqlupdate;
        int maxsq = 0;
        string sql = "select max(VOUNO1)from lclm.vouno where VUBRNO=" + brn + " and VUYEAR=" + year + " and VUTYPE='D'";
        OracleDataReader reader;
        oraComm.CommandText = sql;
        oraComm.Connection = oraConn;
        reader = oraComm.ExecuteReader(CommandBehavior.CloseConnection);

        reader.Read();

        if (!reader.IsDBNull(0))
            maxsq = reader.GetInt32(0);
        //reader.Close();

        if (maxsq > 0)
        {
            maxsq = maxsq + 1;
            sqlupdate = "update lclm.vouno set VOUNO1=" + maxsq + "where VUBRNO=" + brn + " and VUYEAR=" + year + "and VUTYPE='D'";
        }
        else
        {
            maxsq = 1;
            sqlupdate = "insert into lclm.vouno(VUBRNO,VUYEAR,VUTYPE,VOUNO1) values (" + brn + "," + year + ",'D'," + maxsq + ")";
        }
        this.insertRecords(sqlupdate);
        string strbrn = brn.ToString().Trim();
        string strmaxsq = maxsq.ToString();

        if (strbrn.Length != 3)
        {
            string str = "";
            for (int i = 0; i < 3 - strbrn.Length; i++)
            { str = str + "0"; }
            strbrn = str + strbrn;
        }
        if (strmaxsq.Length != 5)
        {
            string str = "";
            for (int i = 0; i < 5 - strmaxsq.Length; i++)
            { str = str + "0"; }
            strmaxsq = str + strmaxsq;
        }

        // return strbrn + "/" + year.Trim() + "/S/" + strmaxsq;
        //return strbrn + "/D" + DateTime.Now.ToString("yyMMdd") + strmaxsq;
        return "T/" + DateTime.Now.ToString("yyMMdd").Substring(0, 2) + "/" + strbrn + "/DT/" + strmaxsq;
    }

    public string voucher_numberSL(string year, string brn)
    {
        string sqlupdate;
        int maxsq = 0;
        string sql = "select max(VOUNO1)from lclm.vouno where VUBRNO=" + brn + " and VUYEAR=" + year + " and VUTYPE='D'";
        OracleDataReader reader;
        oraComm.CommandText = sql;
        oraComm.Connection = oraConn;
        reader = oraComm.ExecuteReader(CommandBehavior.CloseConnection);

        reader.Read();

        if (!reader.IsDBNull(0))
            maxsq = reader.GetInt32(0);
        //reader.Close();

        if (maxsq > 0)
        {
            maxsq = maxsq + 1;
            sqlupdate = "update lclm.vouno set VOUNO1=" + maxsq + "where VUBRNO=" + brn + " and VUYEAR=" + year + "and VUTYPE='D'";
        }
        else
        {
            maxsq = 1;
            sqlupdate = "insert into lclm.vouno(VUBRNO,VUYEAR,VUTYPE,VOUNO1) values (" + brn + "," + year + ",'D'," + maxsq + ")";
        }
        this.insertRecords(sqlupdate);
        string strbrn = brn.ToString().Trim();
        string strmaxsq = maxsq.ToString();

        if (strbrn.Length != 3)
        {
            string str = "";
            for (int i = 0; i < 3 - strbrn.Length; i++)
            { str = str + "0"; }
            strbrn = str + strbrn;
        }
        if (strmaxsq.Length != 5)
        {
            string str = "";
            for (int i = 0; i < 5 - strmaxsq.Length; i++)
            { str = str + "0"; }
            strmaxsq = str + strmaxsq;
        }

        // return strbrn + "/" + year.Trim() + "/S/" + strmaxsq;
        //return strbrn + "/D" + DateTime.Now.ToString("yyMMdd") + strmaxsq;
        return "T/" + DateTime.Now.ToString("yyMMdd").Substring(0, 2) + "/" + strbrn + "/DS/" + strmaxsq;
    }

    public string voucher_numberCP(string year, string brn)
    {

        string sqlupdate;
        int maxsq = 0;
        string sql = "select max(VOUNO1)from lclm.vouno where VUBRNO=" + brn + " and VUYEAR=" + year + " and VUTYPE='C'";
        OracleDataReader reader;
        oraComm.CommandText = sql;
        oraComm.Connection = oraConn;
        reader = oraComm.ExecuteReader(CommandBehavior.CloseConnection);

        reader.Read();

        if (!reader.IsDBNull(0))
            maxsq = reader.GetInt32(0);
        //reader.Close();

        if (maxsq > 0)
        {
            maxsq = maxsq + 1;
            sqlupdate = "update lclm.vouno set VOUNO1=" + maxsq + "where VUBRNO=" + brn + " and VUYEAR=" + year + "and VUTYPE='C'";
        }
        else
        {
            maxsq = 1;
            sqlupdate = "insert into lclm.vouno(VUBRNO,VUYEAR,VUTYPE,VOUNO1) values (" + brn + "," + year + ",'C'," + maxsq + ")";
        }
        this.insertRecords(sqlupdate);
        string strbrn = brn.ToString().Trim();
        string strmaxsq = maxsq.ToString();

        if (strbrn.Length != 3)
        {
            string str = "";
            for (int i = 0; i < 3 - strbrn.Length; i++)
            { str = str + "0"; }
            strbrn = str + strbrn;
        }
        if (strmaxsq.Length != 5)
        {
            string str = "";
            for (int i = 0; i < 5 - strmaxsq.Length; i++)
            { str = str + "0"; }
            strmaxsq = str + strmaxsq;
        }

        // return strbrn + "/" + year.Trim() + "/S/" + strmaxsq;
        return "T/" + DateTime.Now.ToString("yyMMdd").Substring(0, 2) + "/" + strbrn + "/DC/" + strmaxsq;
    }
    public int DeleteRecords(string DelQuery)
    {
        int numRows = 0;
        oraComm.Connection = oraConn;
        oraComm.CommandText = DelQuery;

        numRows = oraComm.ExecuteNonQuery();

        return numRows;
    }

    public int EpfCode(string epf)
    {
        string inte = "0";
        char temp;
        char[] validchar ={ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        for (int i = 0; i < epf.Length; i++)
        {
            temp = char.Parse(epf.Substring(i, 1));
            for (int n = 0; n < 10; n++)
            {
                if (validchar[n] == temp)
                {
                    inte += temp;
                }
            }
        }
        return int.Parse(inte);
    }
}

