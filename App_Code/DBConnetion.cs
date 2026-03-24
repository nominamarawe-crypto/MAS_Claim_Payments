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
/// Summary description for DBConnetion
/// </summary>
public class DBConnetion
{
    public OracleConnection conn = new OracleConnection();
    public OracleCommand cmd = new OracleCommand();
    public OracleTransaction oraTrans;

    public DBConnetion()
    {
        try
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["DBConString"];
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        catch (Exception ee)
        {
            throw ee;
        }
	}

    public void readSql(string sql)
    {
        if (conn.State != ConnectionState.Open)
        { conn.Open(); }
        try
        {

            cmd.CommandText = sql;
            cmd.Connection = conn;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public int AddRecored(string sSql)
    {
        if (conn.State != ConnectionState.Open)
        { conn.Open(); }
        try
        {
            int numRows = 0;
            //cmd.O oraTrans
            cmd.Connection = conn;
            cmd.CommandText = sSql;
            numRows = cmd.ExecuteNonQuery();
            return numRows;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public string GetBranchName(string branchCode)
    {
        int brnCode;
        string sqlQuery;
        string brName;
        DBConnetion ora;
        OracleDataReader reader;

        brName = "";
        brnCode = 0;
        if (branchCode != "")
        {

            brnCode = int.Parse(branchCode);

            sqlQuery = "SELECT BRNAM FROM GENPAY.BRANCH WHERE BRCOD='" + brnCode + "'";


            ora = new DBConnetion();
            ora.ReadSql(sqlQuery);
            reader = ora.cmd.ExecuteReader(CommandBehavior.CloseConnection);

            reader.Read();

            if (!reader.IsDBNull(0))
                brName = reader.GetString(0);
            reader.Close();

        }

        return brName;
    }

    public int existRecored(string sSql)
    {
        if (conn.State != ConnectionState.Open)
        { conn.Open(); }
        try
        {
            int rows = 0;
            ReadSql(sSql);
            OracleDataReader oraDtReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oraDtReader.Read())
            {
                rows++;
            }
            return rows;
        }
        catch (Exception exp)
        {
            throw exp;
        }

    }


    public void FillGrid(string sSql, GridView myGrid)
    {
        try
        {
            OracleDataReader oraDbreder = cmd.ExecuteReader();
            myGrid.DataSource = oraDbreder;
            myGrid.DataBind();

        }
        catch (Exception exp)
        {
            throw exp;
        }


    }


    public void ReadSql(string sql)
    {
        if (conn.State != ConnectionState.Open)
        { conn.Open(); }
        try
        {
            cmd.CommandText = sql;
            cmd.Connection = conn;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

   
    public int GetMaxId(string sql)
    {
        try
        {

            int id = 0;
            ReadSql(sql);
            OracleDataReader oraDtReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oraDtReader.Read())
            {
                if (!oraDtReader.IsDBNull(0))
                {
                    id = oraDtReader.GetInt32(0);
                }
            }

            return id + 1;

        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public DataSet Getrow(string sql)
    {

        try
        {
            cmd.Connection = conn;
            //conn.ConnectionString = ConfigurationManager.AppSettings["DBConString"];
            OracleDataAdapter dataAdd = new OracleDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ds.Clear();
            dataAdd.Fill(ds);


            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public void Begintransaction()
    {

        oraTrans = conn.BeginTransaction();
        cmd.Transaction = oraTrans;
    }
    public void rollback()
    {
        oraTrans.Rollback();
    }
    public void ConnClose()
    {
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public void commit()
    {
       oraTrans.Commit();
     //   oraTrans.Rollback();
    }

    public int InsertRecords(string sSql)
    {
        if (conn.State != ConnectionState.Open)
        { conn.Open(); }
        try
        {
            int numRows = 0;
            cmd.Connection = conn;
            cmd.CommandText = sSql;

            numRows = cmd.ExecuteNonQuery();

            return numRows;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public string Voucher_number(string year, string brn)
    {

        string sqlupdate;
        int maxsq = 0;
        string sql = "select max(VOUNO1)from lclm.vouno where VUBRNO=" + brn + " and VUYEAR=" + year + " and VUTYPE='S'";
        OracleDataReader reader;
        cmd.CommandText = sql;
        cmd.Connection = conn;
        reader = cmd.ExecuteReader();

        reader.Read();

        if (!reader.IsDBNull(0))
            maxsq = reader.GetInt32(0);
        reader.Close();

        if (maxsq > 0)
        {

            maxsq = maxsq + 1;
            sqlupdate = "update lclm.vouno set VOUNO1=" + maxsq + "where VUBRNO=" + brn + " and VUYEAR=" + year + "and VUTYPE='S'";

        }
        else
        {
            maxsq = 1;
            sqlupdate = "insert into lclm.vouno(VUBRNO,VUYEAR,VUTYPE,VOUNO1) values (" + brn + "," + year + ",'S'," + maxsq + ")";
        }
        this.InsertRecords(sqlupdate);
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
        return strbrn + "/S" + DateTime.Now.ToString("yyMMdd") + strmaxsq;
    }
   

}
