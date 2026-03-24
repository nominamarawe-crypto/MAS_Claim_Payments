using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class dthClmRegister001 : System.Web.UI.Page
{
    private long polno;
    private string mof;

    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2)
        {
            month = "0" + month;
        }
        if (day.Length < 2)
        {
            day = "0" + day;
        }

        ourDate = year + month + day;
        datetime[0] = ourDate;
        // return ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        // return y;
        return datetime;

    }

    ArrayList arr;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        try
        {
            int count = 0;
            arr = new ArrayList();

            string dthrefselect = "select drpolno, drmos from lphs.dthref where (completed = 'Y' or completed = 'R') Order by DRCLMNO";
            dm.readSql(dthrefselect);
            OracleDataReader drefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (drefReader.Read())
            {
                count++;
                polno = drefReader.GetInt64(0);
                mof = drefReader.GetString(1);

                DthClmRegDet DCRobj = new DthClmRegDet(polno, mof);
                arr.Add(DCRobj);
            }
            drefReader.Close();
            drefReader.Dispose();

            GridView1.DataSource = drawGrid();
            GridView1.DataBind();

        }
        catch (Exception ex) 
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

    }

    protected ICollection drawGrid() {
        DataTable dt = new DataTable();
        DataRow dr;
        int counter = 0;

        dt.Columns.Add(new DataColumn("entdt", typeof(string)));
        dt.Columns.Add(new DataColumn("clmno", typeof(string)));
        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("name", typeof(string)));
        dt.Columns.Add(new DataColumn("address", typeof(string)));
        dt.Columns.Add(new DataColumn("DCO", typeof(string)));
        dt.Columns.Add(new DataColumn("table", typeof(string)));
        dt.Columns.Add(new DataColumn("term", typeof(string)));
        dt.Columns.Add(new DataColumn("sumass", typeof(string)));
        dt.Columns.Add(new DataColumn("ADB", typeof(string)));
        dt.Columns.Add(new DataColumn("FPU", typeof(string)));
        dt.Columns.Add(new DataColumn("SJ", typeof(string)));
        dt.Columns.Add(new DataColumn("FE", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofinti", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofdth", typeof(string)));
        dt.Columns.Add(new DataColumn("causeofdth", typeof(string)));
        dt.Columns.Add(new DataColumn("vestedbons", typeof(string)));
        dt.Columns.Add(new DataColumn("intbons", typeof(string)));
        dt.Columns.Add(new DataColumn("deposits", typeof(string)));
        dt.Columns.Add(new DataColumn("grossclm", typeof(string)));
        dt.Columns.Add(new DataColumn("defprem", typeof(string)));
        dt.Columns.Add(new DataColumn("defint", typeof(string)));
        dt.Columns.Add(new DataColumn("polcomplyear", typeof(string)));
        dt.Columns.Add(new DataColumn("loancap", typeof(string)));
        dt.Columns.Add(new DataColumn("loanint", typeof(string)));
        dt.Columns.Add(new DataColumn("otherded", typeof(string)));
        dt.Columns.Add(new DataColumn("netclm", typeof(string)));
        dt.Columns.Add(new DataColumn("paidno", typeof(string)));
        dt.Columns.Add(new DataColumn("pddate", typeof(string)));
        dt.Columns.Add(new DataColumn("repudate", typeof(string)));
        dt.Columns.Add(new DataColumn("repreason", typeof(string)));
        dt.Columns.Add(new DataColumn("cof", typeof(string)));
        dt.Columns.Add(new DataColumn("admitno", typeof(string)));

        try
        {
            foreach (DthClmRegDet dcr in arr)
            {
                counter++;
                dr = dt.NewRow();

                if (dcr.Entdt > 9999999) { dr[0] = dcr.Entdt.ToString().Substring(0, 4) + "/" + dcr.Entdt.ToString().Substring(4, 2) + "/" + dcr.Entdt.ToString().Substring(6, 2); }
                dr[1] = dcr.Claimno.ToString();
                dr[2] = dcr.Polno.ToString();
                dr[3] = dcr.AssuredName;
                dr[4] = dcr.Address;
                dr[5] = dcr.Dco.ToString();
                dr[6] = dcr.Table.ToString();
                dr[7] = dcr.Term.ToString();
                dr[8] = dcr.BsumAssu.ToString();
                dr[9] = dcr.Adb.ToString();
                dr[10] = dcr.Fpu.ToString();
                dr[11] = dcr.Sj.ToString();
                dr[12] = dcr.Fe.ToString();
                if (dcr.DtofIntimation > 9999999) { dr[13] = dcr.DtofIntimation.ToString().Substring(0, 4) + "/" + dcr.DtofIntimation.ToString().Substring(4, 2) + "/" + dcr.DtofIntimation.ToString().Substring(6, 2); }
                if (dcr.DtofDeath > 9999999) { dr[14] = dcr.DtofDeath.ToString().Substring(0, 4) + "/" + dcr.DtofDeath.ToString().Substring(4, 2) + "/" + dcr.DtofDeath.ToString().Substring(6, 2); }
                dr[15] = dcr.CauseofDeath;
                dr[16] = dcr.VestedBonus.ToString();
                dr[17] = dcr.InterimBonus.ToString();
                dr[18] = dcr.Deposits.ToString();
                dr[19] = dcr.Grossclm.ToString();
                dr[20] = dcr.Defprem.ToString();
                dr[21] = dcr.DefInterest.ToString();
                dr[22] = dcr.PolCompleteYear.ToString();
                dr[23] = dcr.LoanCap.ToString();
                dr[24] = dcr.LoanInt.ToString();
                dr[25] = dcr.OtherDeductions.ToString();
                dr[26] = dcr.NetClm.ToString();
                dr[27] = dcr.PaidNo.ToString();
                if (dcr.pAYAUTDT > 9999999) { dr[28] = dcr.pAYAUTDT.ToString().Substring(0, 4) + "/" + dcr.pAYAUTDT.ToString().Substring(4, 2) + "/" + dcr.pAYAUTDT.ToString().Substring(6, 2); }
                if (dcr.Repudate > 9999999) { dr[29] = dcr.Repudate.ToString().Substring(0, 4) + "/" + dcr.Repudate.ToString().Substring(4, 2) + "/" + dcr.Repudate.ToString().Substring(6, 2); }
                dr[30] = dcr.RepuReason;
                dr[31] = dcr.Cof;
                dr[32] = dcr.Admitno.ToString();
                dt.Rows.Add(dr);
            }
        }
        catch (Exception ex) {
            throw new Exception(counter.ToString() + " " + ex);
        }

        DataView dv = new DataView(dt);
        return dv;

    }
    
    protected void GridView1_PageIndexChanging(object sender, EventArgs e)
    {

    }
}
