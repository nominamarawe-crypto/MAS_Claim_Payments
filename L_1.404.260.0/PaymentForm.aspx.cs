using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PaymentForm : System.Web.UI.Page
{
    String printState = "2";
    private bool startConversion = false;
    private string ClaimNO = "";
    private string PolNo = "";
    private string MOF = "";
    private string ADB = "";
    private string ADBLATEPAY = "";
    DataManager dthintobj;

    private string nameOfDead;
    private string payDate;
    private string payDatestr;
    private string paySum;
    private string causeofDeath;
    private string quater;
    private string dateofDeath;

    private string serialNo;
    private string basicSum;
    private string adbSum;
    private string dibilitySum;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["pState"] != null)
                {
                    printState = Request.QueryString["pState"].ToString();
                }
                if (Request.QueryString["clmno"] != null)
                {
                    ClaimNO = Request.QueryString["clmno"].ToString();
                }
                if (Request.QueryString["polno"] != null)
                {
                    PolNo = Request.QueryString["polno"].ToString();
                }
                if (Request.QueryString["mos"] != null)
                {
                    MOF = Request.QueryString["mos"].ToString();
                }
                if (Request.QueryString["adb"] != null)
                {
                    ADB = Request.QueryString["adb"].ToString();
                }
                if (Request.QueryString["adblatepay"] != null)
                {
                    ADBLATEPAY = Request.QueryString["adblatepay"].ToString();
                }

                LoadData();
                startConversion = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }

    public void LoadData()
    {
        try
        {
            dthintobj = new DataManager();
            string EPF = Session["EPFNum"].ToString();

            using (DatabaseTransactionLayer dal = new DatabaseTransactionLayer())
            {
                try
                {
                    dal.OpenTransaction();
                    if (ADB == "1")
                    {
                        string checckmail = "SELECT * FROM LPHS.DTH_REINS_EMAIL_LOG WHERE  POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='ADB PAYMENT'";
                        if (!dal.IsRecordExist(checckmail))
                        {
                            string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                            (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                             VALUES ('" + PolNo + "','" + ClaimNO + "' , sysdate, '" + EPF + "','ADB PAYMENT')";
                            dal.ExecuteTableUpdateQuery(insertEmaillog);
                        }
                    }
                    else
                    {
                        string checckmail = "SELECT * FROM LPHS.DTH_REINS_EMAIL_LOG WHERE  POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='PAYMENT'";
                        if (!dal.IsRecordExist(checckmail))
                        {
                            string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                            (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                             VALUES ('" + PolNo + "','" + ClaimNO + "' , sysdate, '" + EPF + "','PAYMENT')";
                            dal.ExecuteTableUpdateQuery(insertEmaillog);
                        }

                    }

                    #region  ------------- DTHINT - Read Death intimation details ----------------
                    string dthintSelect = @"select dinfodat, dpolst, dnod, to_char(to_date(ddtofdth,'yyyyMMdd'),'yyyy/MM/dd'), dmoinf, diid, diname, diad1,diad2,diad3,diad4,
                            ditel, dinforel, dclm, dsta, dconfst, dcof,to_char(DENTDATE,'yyyyMMdd'),DMOS from lphs.dthint where dpolno=" + PolNo + " and dclm='" + ClaimNO + "'  ";
                    if (!dal.IsRecordExist(dthintSelect))
                    {
                        throw new Exception("No Death Intimation Details!");
                    }
                    else
                    {
                        using (DataTable dataTable = dal.ReadSQLtoDataTable(dthintSelect))
                        {
                            using (DataTableReader dthintREADER = dataTable.CreateDataReader())
                            {
                                while (dthintREADER.Read())
                                {
                                    if (!dthintREADER.IsDBNull(2)) { nameOfDead = dthintREADER.GetString(2); } else { nameOfDead = ""; }
                                    if (!dthintREADER.IsDBNull(3)) { dateofDeath = dthintREADER.GetString(3); } else { dateofDeath = "-"; }
                                }
                            }
                        }
                    }

                    string exgrAmtsSel = "select SUMONEX, ADBONEX, FPUONEX, FEONEX, SJONEX, OTHERADDONEX, REFOFPRMONEX from LPHS.EXGRACIA_AMTS where DPOLNUM = " + PolNo + " and MOF ='" + MOF + "' ";
                    double SUMONEX = 0, ADBONEX = 0, FPUONEX = 0, FEONEX = 0, SJONEX = 0, OTHERADDONEX = 0, REFOFPRMONEX = 0;
                    using (DataTable dt = dal.ReadSQLtoDataTable(exgrAmtsSel))
                    {
                        using (DataTableReader exgrAmtsRead = dt.CreateDataReader())
                        {
                            while (exgrAmtsRead.Read())
                            {
                                if (!exgrAmtsRead.IsDBNull(0)) { SUMONEX = double.Parse(exgrAmtsRead.GetDecimal(0).ToString()); } else { SUMONEX = 0; }
                                if (!exgrAmtsRead.IsDBNull(1)) { ADBONEX = double.Parse(exgrAmtsRead.GetDecimal(1).ToString()); } else { ADBONEX = 0; }
                                if (!exgrAmtsRead.IsDBNull(2)) { FPUONEX = double.Parse(exgrAmtsRead.GetDecimal(2).ToString()); } else { FPUONEX = 0; }
                                if (!exgrAmtsRead.IsDBNull(3)) { FEONEX = double.Parse(exgrAmtsRead.GetDecimal(3).ToString()); } else { FEONEX = 0; }
                                if (!exgrAmtsRead.IsDBNull(4)) { SJONEX = double.Parse(exgrAmtsRead.GetDecimal(4).ToString()); } else { SJONEX = 0; }
                                if (!exgrAmtsRead.IsDBNull(5)) { OTHERADDONEX = double.Parse(exgrAmtsRead.GetDecimal(5).ToString()); } else { OTHERADDONEX = 0; }
                                if (!exgrAmtsRead.IsDBNull(6)) { REFOFPRMONEX = double.Parse(exgrAmtsRead.GetDecimal(6).ToString()); } else { REFOFPRMONEX = 0; }
                            }
                        }
                    }
                    if(SUMONEX > 0)
                    {
                        basiccol.InnerText = "Sum at Risk Life (Exgratia)";
                    }
                    if (ADBONEX > 0)
                    {
                        adbcol.InnerText = "ADB Benefit (Exgratia)";
                    }
                    if (FPUONEX > 0)
                    {
                        fpuCol.InnerText = "FPU Benefit (Exgratia)";
                    }
                    if (SJONEX > 0)
                    {
                        sjcol.InnerText = "SJ Benefit (Exgratia)";
                    }
                    
                    
                    #endregion

                    if (ADB == "1")
                    {
                        #region--------------------------- DTHREF -------------------------------------------------------------
                        string payee = "";
                        string dthrefSel = "select APRVDATE, ADBPAYAMT, CAUSEOFDEATHSTR,to_char(to_date(APRVDATE,'yyyyMMdd'),'yyyy/MM/dd') from LPHS.DTHREF  where drpolno=" + PolNo + " and drclmno='" + ClaimNO + "' ";
                        if (dal.IsRecordExist(dthrefSel))
                        {

                            using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrefSel))
                            {
                                using (DataTableReader dthrefreader = dataTable.CreateDataReader())
                                {
                                    while (dthrefreader.Read())
                                    {

                                        if (!dthrefreader.IsDBNull(0)) { payDate = dthrefreader.GetDecimal(0).ToString(); } else { payDate = "-"; }
                                        if (!dthrefreader.IsDBNull(1)) { paySum = dthrefreader.GetDecimal(1).ToString("N"); } else { paySum = "-"; }
                                        if (!dthrefreader.IsDBNull(2)) { causeofDeath = dthrefreader.GetString(2); } else { causeofDeath = "-"; }
                                        if (!dthrefreader.IsDBNull(3)) { payDatestr = dthrefreader.GetString(3); } else { payDatestr = "-"; }

                                    }
                                }
                            }
                        }

                        #endregion




                        #region ReInsure Details

                        double shrbasic = 0;
                        double shrfpu = 0;
                        double shrsj = 0;
                        double shradb = 0;
                        double shrspouse = 0;
                        double shrcic = 0;
                        double shrtpda = 0;
                        double shrtpds = 0;
                        double shrtot = 0;
                        double shrppdb = 0;
                        double shrwopa = 0;
                        double shrwops = 0;
                        double shrbasicfac = 0;
                        double shrfpufac = 0;
                        double shrsjfac = 0;
                        double shradbfac = 0;
                        double shrspousefac = 0;
                        double shrcicfac = 0;
                        double shrtpdafac = 0;
                        double shrtpdsfac = 0;
                        double shrppdbfac = 0;
                        double shrwopafac = 0;
                        double shrwopsfac = 0;

                        string reinsuredetails = "select POLNO,CLAIMNO,AVAILABILITY,PERSON_NO,RE_INS_BASIC,RE_INS_FPU,RE_INS_SJ,RE_INS_ADB,RE_INS_SPOUSE,RE_INS_CI,RE_INS_TPD_A," +
                            "RE_INS_TPD_S,RE_INS_PPDB,RE_INS_WOP_A,RE_INS_WOP_S,RE_INS_BASIC_FAC,RE_INS_FPU_FAC,RE_INS_SJ_FAC,RE_INS_ADB_FAC,RE_INS_SPOUSE_FAC,RE_INS_CI_FAC,RE_INS_TPD_A_FAC," +
                             "RE_INS_TPD_S_FAC,RE_INS_PPDB_FAC,RE_INS_WOP_A_FAC,RE_INS_WOP_S_FAC,RE_INT_TOT,RE_INSURER,RE_TYPE,ENTRY_DATE,ENTRED_BY,RE_INS_STATUS,PAYMENT_DETAIL_SENT,PAYMENT_DETAIL_SENT_DATE " +
                            "FROM LPHS.DTH_REINSURANCE_DTL where CLAIMNO='" + ClaimNO + "'";
                        dthintobj.readSql(reinsuredetails);
                        OracleDataReader insreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (insreader.Read())
                        {
                            //if (!insreader.IsDBNull(2))
                            //{
                            //    ddlAvailbility.SelectedValue = insreader.GetString(2);
                            //}
                            if (!insreader.IsDBNull(3))
                            {
                                serialNo = insreader.GetInt32(3).ToString();
                            }
                            else
                            {
                                serialNo = "-";
                            }
                            //if (!insreader.IsDBNull(4))
                            //{
                            //    shrbasic = insreader.GetDouble(4);
                            //}
                            //if (!insreader.IsDBNull(5))
                            //{
                            //    shrfpu = insreader.GetDouble(5);
                            //}
                            //if (!insreader.IsDBNull(6))
                            //{
                            //    shrsj = insreader.GetDouble(6);
                            //}
                            if (!insreader.IsDBNull(7))
                            {
                                shradb = insreader.GetDouble(7);
                            }
                            //if (!insreader.IsDBNull(8))
                            //{
                            //    shrspouse = insreader.GetDouble(8);
                            //}
                            //if (!insreader.IsDBNull(9))
                            //{
                            //    shrcic = insreader.GetDouble(9);
                            //}
                            //if (!insreader.IsDBNull(10))
                            //{
                            //    shrtpda = insreader.GetDouble(10);
                            //}
                            //if (!insreader.IsDBNull(11))
                            //{
                            //    shrtpds = insreader.GetDouble(11);
                            //}
                            //if (!insreader.IsDBNull(12))
                            //{
                            //    shrppdb = insreader.GetDouble(12);
                            //}
                            //if (!insreader.IsDBNull(13))
                            //{
                            //    shrwopa = insreader.GetDouble(13);
                            //}
                            //if (!insreader.IsDBNull(14))
                            //{
                            //    shrwops = insreader.GetDouble(14);
                            //}

                            //if (!insreader.IsDBNull(15))
                            //{
                            //    shrbasicfac = insreader.GetDouble(15);
                            //}
                            //if (!insreader.IsDBNull(16))
                            //{
                            //    shrfpufac = insreader.GetDouble(16);
                            //}
                            //if (!insreader.IsDBNull(17))
                            //{
                            //    shrsjfac = insreader.GetDouble(17);
                            //}
                            if (!insreader.IsDBNull(18))
                            {
                                shradbfac = insreader.GetDouble(18);
                            }
                            //if (!insreader.IsDBNull(19))
                            //{
                            //    shrspousefac = insreader.GetDouble(19);
                            //}
                            //if (!insreader.IsDBNull(20))
                            //{
                            //    shrcicfac = insreader.GetDouble(20);
                            //}
                            //if (!insreader.IsDBNull(21))
                            //{
                            //    shrtpdafac = insreader.GetDouble(21);
                            //}
                            //if (!insreader.IsDBNull(22))
                            //{
                            //    shrtpdsfac = insreader.GetDouble(22);
                            //}
                            //if (!insreader.IsDBNull(23))
                            //{
                            //    shrppdbfac = insreader.GetDouble(23);
                            //}
                            //if (!insreader.IsDBNull(24))
                            //{
                            //    shrwopafac = insreader.GetDouble(24);
                            //}
                            //if (!insreader.IsDBNull(25))
                            //{
                            //    shrwopsfac = insreader.GetDouble(25);
                            //}
                        }
                        insreader.Close();
                        insreader.Dispose();
                        #endregion


                        #region Set  Data
                        txtNameofDeath.Value = nameOfDead;
                        txtSettlementon.Value = payDatestr;
                        txtPaySum.Value = "Rs. " + paySum;

                        string qmonth = payDate.Substring(4, 2);

                        txtQYear.Value = payDate.Substring(0, 4);

                        switch (qmonth)
                        {
                            case "01":
                                txtQuater.Value = "first";
                                break;
                            case "02":
                                txtQuater.Value = "first";
                                break;
                            case "03":
                                txtQuater.Value = "first";
                                break;
                            case "04":
                                txtQuater.Value = "second";
                                break;
                            case "05":
                                txtQuater.Value = "second";
                                break;
                            case "06":
                                txtQuater.Value = "second";
                                break;
                            case "07":
                                txtQuater.Value = "third";
                                break;
                            case "08":
                                txtQuater.Value = "third";
                                break;
                            case "09":
                                txtQuater.Value = "Third";
                                break;
                            case "10":
                                txtQuater.Value = "fourth";
                                break;
                            case "11":
                                txtQuater.Value = "fourth";
                                break;
                            case "12":
                                txtQuater.Value = "fourth";
                                break;
                        }

                        txtDateofDeath.Value = dateofDeath;
                        txtCauseofDeath.Value = causeofDeath;

                        lblSerialNo.InnerText = serialNo;

                        int colspan = 0;

                        //if ((shrbasic + shrbasicfac) > 0)
                        //{
                        //    colspan++;
                        //    basiccol.Visible = true;
                        //    basiccolval.Visible = true;
                        //    lblbasic.InnerText = "Rs. " + (shrbasic + shrbasicfac).ToString("N");
                        //}
                        //else
                        //{
                        basiccol.Visible = false;
                        basiccolval.Visible = false;
                        //}

                        //if ((shrfpu + shrfpufac) > 0)
                        //{
                        //    colspan++;
                        //    fpuCol.Visible = true;
                        //    fpuColval.Visible = true;
                        //    lblfpu.InnerText = "Rs. " + (shrfpu + shrfpufac).ToString("N");
                        //}
                        //else
                        //{
                        fpuCol.Visible = false;
                        fpuColval.Visible = false;
                        //}



                        //if ((shrsj + shrsjfac) > 0)
                        //{
                        //    colspan++;
                        //    sjcol.Visible = true;
                        //    sjcolval.Visible = true;
                        //    lblsj.InnerText = "Rs. " + (shrsj + shrsjfac).ToString("N");
                        //}
                        //else
                        //{
                        sjcol.Visible = false;
                        sjcolval.Visible = false;
                        //}

                        if ((shradb + shradbfac) > 0)
                        {
                            colspan++;
                            adbcol.Visible = true;
                            adbcolval.Visible = true;
                            lbladb.InnerText = "Rs. " + (shradb + shradbfac).ToString("N");
                        }
                        else
                        {
                            adbcol.Visible = false;
                            adbcolval.Visible = false;
                        }

                        //if ((shrspouse + shrspousefac) > 0)
                        //{
                        //    colspan++;
                        //    spousecol.Visible = true;
                        //    spousecolval.Visible = true;
                        //    lblspouse.InnerText = "Rs. " + (shrspouse + shrspousefac).ToString("N");
                        //}
                        //else
                        //{
                        spousecol.Visible = false;
                        spousecolval.Visible = false;
                        //}

                        //if ((shrcic + shrcicfac) > 0)
                        //{
                        //    colspan++;
                        //    ciccol.Visible = true;
                        //    ciccolval.Visible = true;
                        //    lblcic.InnerText = "Rs. " + (shrcic + shrcicfac).ToString("N");
                        //}
                        //else
                        //{
                        ciccol.Visible = false;
                        ciccolval.Visible = false;
                        //}

                        //if ((shrtpda + shrtpdafac) > 0)
                        //{
                        //    colspan++;
                        //    tpdacol.Visible = true;
                        //    tpdacolval.Visible = true;
                        //    lbltpda.InnerText = "Rs. " + (shrtpda + shrtpdafac).ToString("N");
                        //}
                        //else
                        //{
                        tpdacol.Visible = false;
                        tpdacolval.Visible = false;
                        //}

                        //if ((shrtpds + shrtpdsfac) > 0)
                        //{
                        //    colspan++;
                        //    tpdscol.Visible = true;
                        //    tpdscolval.Visible = true;
                        //    lbltpds.InnerText = "Rs. " + (shrtpds + shrtpdsfac).ToString("N");
                        //}
                        //else
                        //{
                        tpdscol.Visible = false;
                        tpdscolval.Visible = false;
                        //}

                        //if ((shrppdb + shrppdbfac) > 0)
                        //{
                        //    colspan++;
                        //    ppdbcol.Visible = true;
                        //    ppdbcolval.Visible = true;
                        //    lblppdb.InnerText = "Rs. " + (shrppdb + shrppdbfac).ToString("N");
                        //}
                        //else
                        //{
                        ppdbcol.Visible = false;
                        ppdbcolval.Visible = false;
                        //}

                        //if ((shrwopa + shrwops) > 0)
                        //{
                        //    colspan++;
                        //    wopacol.Visible = true;
                        //    wopacolval.Visible = true;
                        //    lblwopa.InnerText = "Rs. " + (shrwopa + shrwops).ToString("N");
                        //}
                        //else
                        //{
                        wopacol.Visible = false;
                        wopacolval.Visible = false;
                        //}

                        //if ((shrwops + shrwopsfac) > 0)
                        //{
                        //    colspan++;
                        //    wopscol.Visible = true;
                        //    wopscolval.Visible = true;
                        //    lblwops.InnerText = "Rs. " + (shrwops + shrwopsfac).ToString("N");
                        //}
                        //else
                        //{
                        wopscol.Visible = false;
                        wopscolval.Visible = false;
                        //}


                        colspancolumn.ColSpan = colspan;


                        lblPolno.InnerText = PolNo;

                        txtDate.Value = DateTime.Now.ToString("yyyy/MM/dd");
                        #endregion
                    }
                    else
                    {
                        #region--------------------------- DTHREF -------------------------------------------------------------
                        string payee = "";
                        string dthrefSel = "select APRVDATE, DRGROSSCLM, CAUSEOFDEATHSTR,to_char(to_date(APRVDATE,'yyyyMMdd'),'yyyy/MM/dd') from LPHS.DTHREF  where drpolno=" + PolNo + " and drclmno='" + ClaimNO + "' ";
                        if (dal.IsRecordExist(dthrefSel))
                        {

                            using (DataTable dataTable = dal.ReadSQLtoDataTable(dthrefSel))
                            {
                                using (DataTableReader dthrefreader = dataTable.CreateDataReader())
                                {
                                    while (dthrefreader.Read())
                                    {

                                        if (!dthrefreader.IsDBNull(0)) { payDate = dthrefreader.GetDecimal(0).ToString(); } else { payDate = "-"; }
                                        if (!dthrefreader.IsDBNull(1)) { paySum = dthrefreader.GetDecimal(1).ToString("N"); } else { paySum = "-"; }
                                        if (!dthrefreader.IsDBNull(2)) { causeofDeath = dthrefreader.GetString(2); } else { causeofDeath = "-"; }
                                        if (!dthrefreader.IsDBNull(3)) { payDatestr = dthrefreader.GetString(3); } else { payDatestr = "-"; }

                                    }
                                }
                            }
                        }

                        #endregion


                        #region ReInsure Details

                        double shrbasic = 0;
                        double shrfpu = 0;
                        double shrsj = 0;
                        double shradb = 0;
                        double shrspouse = 0;
                        double shrcic = 0;
                        double shrtpda = 0;
                        double shrtpds = 0;
                        double shrtot = 0;
                        double shrppdb = 0;
                        double shrwopa = 0;
                        double shrwops = 0;
                        double shrbasicfac = 0;
                        double shrfpufac = 0;
                        double shrsjfac = 0;
                        double shradbfac = 0;
                        double shrspousefac = 0;
                        double shrcicfac = 0;
                        double shrtpdafac = 0;
                        double shrtpdsfac = 0;
                        double shrppdbfac = 0;
                        double shrwopafac = 0;
                        double shrwopsfac = 0;

                        string reinsuredetails = "select POLNO,CLAIMNO,AVAILABILITY,PERSON_NO,RE_INS_BASIC,RE_INS_FPU,RE_INS_SJ,RE_INS_ADB,RE_INS_SPOUSE,RE_INS_CI,RE_INS_TPD_A," +
                            "RE_INS_TPD_S,RE_INS_PPDB,RE_INS_WOP_A,RE_INS_WOP_S,RE_INS_BASIC_FAC,RE_INS_FPU_FAC,RE_INS_SJ_FAC,RE_INS_ADB_FAC,RE_INS_SPOUSE_FAC,RE_INS_CI_FAC,RE_INS_TPD_A_FAC," +
                             "RE_INS_TPD_S_FAC,RE_INS_PPDB_FAC,RE_INS_WOP_A_FAC,RE_INS_WOP_S_FAC,RE_INT_TOT,RE_INSURER,RE_TYPE,ENTRY_DATE,ENTRED_BY,RE_INS_STATUS,PAYMENT_DETAIL_SENT,PAYMENT_DETAIL_SENT_DATE " +
                            "FROM LPHS.DTH_REINSURANCE_DTL where CLAIMNO='" + ClaimNO + "'";
                        dthintobj.readSql(reinsuredetails);
                        OracleDataReader insreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (insreader.Read())
                        {
                            //if (!insreader.IsDBNull(2))
                            //{
                            //    ddlAvailbility.SelectedValue = insreader.GetString(2);
                            //}
                            if (!insreader.IsDBNull(3))
                            {
                                serialNo = insreader.GetInt32(3).ToString();
                            }
                            else
                            {
                                serialNo = "-";
                            }
                            if (!insreader.IsDBNull(4))
                            {
                                shrbasic = insreader.GetDouble(4);
                            }
                            if (!insreader.IsDBNull(5))
                            {
                                shrfpu = insreader.GetDouble(5);
                            }
                            if (!insreader.IsDBNull(6))
                            {
                                shrsj = insreader.GetDouble(6);
                            }
                            if (!insreader.IsDBNull(7))
                            {
                                shradb = insreader.GetDouble(7);
                            }
                            if (!insreader.IsDBNull(8))
                            {
                                shrspouse = insreader.GetDouble(8);
                            }
                            if (!insreader.IsDBNull(9))
                            {
                                shrcic = insreader.GetDouble(9);
                            }
                            if (!insreader.IsDBNull(10))
                            {
                                shrtpda = insreader.GetDouble(10);
                            }
                            if (!insreader.IsDBNull(11))
                            {
                                shrtpds = insreader.GetDouble(11);
                            }
                            if (!insreader.IsDBNull(12))
                            {
                                shrppdb = insreader.GetDouble(12);
                            }
                            if (!insreader.IsDBNull(13))
                            {
                                shrwopa = insreader.GetDouble(13);
                            }
                            if (!insreader.IsDBNull(14))
                            {
                                shrwops = insreader.GetDouble(14);
                            }

                            if (!insreader.IsDBNull(15))
                            {
                                shrbasicfac = insreader.GetDouble(15);
                            }
                            if (!insreader.IsDBNull(16))
                            {
                                shrfpufac = insreader.GetDouble(16);
                            }
                            if (!insreader.IsDBNull(17))
                            {
                                shrsjfac = insreader.GetDouble(17);
                            }
                            if (!insreader.IsDBNull(18))
                            {
                                shradbfac = insreader.GetDouble(18);
                            }
                            if (!insreader.IsDBNull(19))
                            {
                                shrspousefac = insreader.GetDouble(19);
                            }
                            if (!insreader.IsDBNull(20))
                            {
                                shrcicfac = insreader.GetDouble(20);
                            }
                            if (!insreader.IsDBNull(21))
                            {
                                shrtpdafac = insreader.GetDouble(21);
                            }
                            if (!insreader.IsDBNull(22))
                            {
                                shrtpdsfac = insreader.GetDouble(22);
                            }
                            if (!insreader.IsDBNull(23))
                            {
                                shrppdbfac = insreader.GetDouble(23);
                            }
                            if (!insreader.IsDBNull(24))
                            {
                                shrwopafac = insreader.GetDouble(24);
                            }
                            if (!insreader.IsDBNull(25))
                            {
                                shrwopsfac = insreader.GetDouble(25);
                            }
                        }
                        insreader.Close();
                        insreader.Dispose();
                        #endregion


                        #region Set  Data
                        txtNameofDeath.Value = nameOfDead;
                        txtSettlementon.Value = payDatestr;
                        txtPaySum.Value = "Rs. " + paySum;

                        string qmonth = "";

                        if (payDate != "-")
                        {
                            qmonth = payDate.Substring(4, 2);

                            txtQYear.Value = payDate.Substring(0, 4);
                        }

                        

                        switch (qmonth)
                        {
                            case "01":
                                txtQuater.Value = "first";
                                break;
                            case "02":
                                txtQuater.Value = "first";
                                break;
                            case "03":
                                txtQuater.Value = "first";
                                break;
                            case "04":
                                txtQuater.Value = "second";
                                break;
                            case "05":
                                txtQuater.Value = "second";
                                break;
                            case "06":
                                txtQuater.Value = "second";
                                break;
                            case "07":
                                txtQuater.Value = "third";
                                break;
                            case "08":
                                txtQuater.Value = "third";
                                break;
                            case "09":
                                txtQuater.Value = "Third";
                                break;
                            case "10":
                                txtQuater.Value = "fourth";
                                break;
                            case "11":
                                txtQuater.Value = "fourth";
                                break;
                            case "12":
                                txtQuater.Value = "fourth";
                                break;
                        }

                        txtDateofDeath.Value = dateofDeath;
                        txtCauseofDeath.Value = causeofDeath;

                        lblSerialNo.InnerText = serialNo;

                        int colspan = 0;

                        if ((shrbasic + shrbasicfac) > 0)
                        {
                            colspan++;
                            basiccol.Visible = true;
                            basiccolval.Visible = true;
                            lblbasic.InnerText = "Rs. " + (shrbasic + shrbasicfac).ToString("N");
                        }
                        else
                        {
                            basiccol.Visible = false;
                            basiccolval.Visible = false;
                        }

                        if ((shrfpu + shrfpufac) > 0)
                        {
                            colspan++;
                            fpuCol.Visible = true;
                            fpuColval.Visible = true;
                            lblfpu.InnerText = "Rs. " + (shrfpu + shrfpufac).ToString("N");
                        }
                        else
                        {
                            fpuCol.Visible = false;
                            fpuColval.Visible = false;
                        }



                        if ((shrsj + shrsjfac) > 0)
                        {
                            colspan++;
                            sjcol.Visible = true;
                            sjcolval.Visible = true;
                            lblsj.InnerText = "Rs. " + (shrsj + shrsjfac).ToString("N");
                        }
                        else
                        {
                            sjcol.Visible = false;
                            sjcolval.Visible = false;
                        }

                        if (ADBLATEPAY == "Y")
                        {
                            adbcol.Visible = false;
                            adbcolval.Visible = false;
                        }
                        else
                        {
                            if ((shradb + shradbfac) > 0)
                            {
                                colspan++;
                                adbcol.Visible = true;
                                adbcolval.Visible = true;
                                lbladb.InnerText = "Rs. " + (shradb + shradbfac).ToString("N");
                            }
                            else
                            {
                                adbcol.Visible = false;
                                adbcolval.Visible = false;
                            }
                        }


                        if ((shrspouse + shrspousefac) > 0)
                        {
                            colspan++;
                            spousecol.Visible = true;
                            spousecolval.Visible = true;
                            lblspouse.InnerText = "Rs. " + (shrspouse + shrspousefac).ToString("N");
                        }
                        else
                        {
                            spousecol.Visible = false;
                            spousecolval.Visible = false;
                        }

                        if ((shrcic + shrcicfac) > 0)
                        {
                            colspan++;
                            ciccol.Visible = true;
                            ciccolval.Visible = true;
                            lblcic.InnerText = "Rs. " + (shrcic + shrcicfac).ToString("N");
                        }
                        else
                        {
                            ciccol.Visible = false;
                            ciccolval.Visible = false;
                        }

                        if ((shrtpda + shrtpdafac) > 0)
                        {
                            colspan++;
                            tpdacol.Visible = true;
                            tpdacolval.Visible = true;
                            lbltpda.InnerText = "Rs. " + (shrtpda + shrtpdafac).ToString("N");
                        }
                        else
                        {
                            tpdacol.Visible = false;
                            tpdacolval.Visible = false;
                        }

                        if ((shrtpds + shrtpdsfac) > 0)
                        {
                            colspan++;
                            tpdscol.Visible = true;
                            tpdscolval.Visible = true;
                            lbltpds.InnerText = "Rs. " + (shrtpds + shrtpdsfac).ToString("N");
                        }
                        else
                        {
                            tpdscol.Visible = false;
                            tpdscolval.Visible = false;
                        }

                        if ((shrppdb + shrppdbfac) > 0)
                        {
                            colspan++;
                            ppdbcol.Visible = true;
                            ppdbcolval.Visible = true;
                            lblppdb.InnerText = "Rs. " + (shrppdb + shrppdbfac).ToString("N");
                        }
                        else
                        {
                            ppdbcol.Visible = false;
                            ppdbcolval.Visible = false;
                        }

                        if ((shrwopa + shrwops) > 0)
                        {
                            colspan++;
                            wopacol.Visible = true;
                            wopacolval.Visible = true;
                            lblwopa.InnerText = "Rs. " + (shrwopa + shrwops).ToString("N");
                        }
                        else
                        {
                            wopacol.Visible = false;
                            wopacolval.Visible = false;
                        }

                        if ((shrwops + shrwopsfac) > 0)
                        {
                            colspan++;
                            wopscol.Visible = true;
                            wopscolval.Visible = true;
                            lblwops.InnerText = "Rs. " + (shrwops + shrwopsfac).ToString("N");
                        }
                        else
                        {
                            wopscol.Visible = false;
                            wopscolval.Visible = false;
                        }


                        colspancolumn.ColSpan = colspan;


                        lblPolno.InnerText = PolNo;

                        txtDate.Value = DateTime.Now.ToString("yyyy/MM/dd");
                        #endregion
                    }


                }
                catch (Exception ex)
                {
                    string err = "";
                    if (ex.ToString().Length > 1500)
                    {
                        err = ex.ToString().Substring(0, 1500);
                    }
                    else
                    {
                        err = ex.ToString();
                    }
                    err = err.Replace("'", "");
                    if (ADB == "1")
                    {
                        
                        string erroUpdate = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set ERROR='" + err + "' " +
                       "WHERE POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='ADB PAYMENT'";
                        dal.ExecuteTableUpdateQuery(erroUpdate);
                    }
                    else
                    {
                        string erroUpdate = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set ERROR='" + err + "' " +
                       "WHERE POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='PAYMENT'";
                        dal.ExecuteTableUpdateQuery(erroUpdate);
                    }
                    dal.CommitTransaction();
                    EPage.Messege = ex.Message.ToString();
                    Response.Redirect("EPage.aspx");
                }
                finally
                { dal.CloseDBConnection(); }
            }

        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        bool isValid = false;
        string errorMsg = string.Empty;

        if (startConversion)
        {
            // get html of the page
            TextWriter myWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(myWriter);
            base.Render(htmlWriter);

            //setup page options
            string pdf_page_size = "A4"; //A1, A2, A3, A4, A5, Letter, HalfLetter, Ledger, Legal
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);
            string pdf_orientation = "Portrait"; //Portrait, Landscape
            PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), pdf_orientation, true);
            int webPageWidth = 700;
            int webPageHeight = 0;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // header settings
            converter.Options.DisplayHeader = true;
            converter.Header.DisplayOnFirstPage = true;
            converter.Header.DisplayOnOddPages = false;
            converter.Header.DisplayOnEvenPages = false;
            converter.Header.Height = 0;

            // add some html content to the header
            //PdfHtmlSection headerHtml = new PdfHtmlSection(headerUrl);
            //headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
            //converter.Header.Add(headerHtml);

            // footer settings
            converter.Options.DisplayFooter = false;
            converter.Footer.DisplayOnFirstPage = true;
            converter.Footer.DisplayOnOddPages = false;
            converter.Footer.DisplayOnEvenPages = false;
            converter.Footer.Height = 0;

            // add some html content to the footer
            //PdfHtmlSection footerHtml = new PdfHtmlSection(footerUrl);
            //footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
            //converter.Footer.Add(footerHtml);

            //set document Security permissions
            converter.Options.SecurityOptions.CanAssembleDocument = true;
            converter.Options.SecurityOptions.CanCopyContent = false;
            converter.Options.SecurityOptions.CanEditAnnotations = false;
            converter.Options.SecurityOptions.CanEditContent = false;
            converter.Options.SecurityOptions.CanFillFormFields = false;
            converter.Options.SecurityOptions.CanPrint = true;

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;
            //converter.Options.MarginLeft = 2;
            // converter.Options.MarginRight = 1;

            string pdfName = "paymentform_" + ClaimNO + ".pdf";

            // create a new pdf document converting the html string of the page
            PdfDocument doc = converter.ConvertHtmlString(
                myWriter.ToString(), Request.Url.AbsoluteUri);

            // save pdf document
            if (printState == "1")
            {
                doc.Save(Response, false, pdfName);
                // close pdf document
                doc.Close();
            }
            else if (printState == "2")
            {
                DataManager dthintobj = new DataManager();
                using (DatabaseAccessLayer dal = new DatabaseTransactionLayer())
                {
                    try
                    {
                        dal.OpenTransaction();

                        string msg = "", msTyp = "", resTyp = "", pdfName_ = "";
                        String body = "";
                        string reciverAddr = "";
                        string dthDate = "";
                        string matDate = "";

                        string EPF = Session["EPFNum"].ToString();


                        //if (ADB == "1")
                        //{
                        //    string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                        //    (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                        //     VALUES ('" + PolNo + "','" + ClaimNO + "' , sysdate, '" + EPF + "','ADB PAYMENT')";
                        //    dal.ExecuteTableUpdateQuery(insertEmaillog);
                        //}
                        //else
                        //{
                        //    string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                        //    (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                        //     VALUES ('" + PolNo + "','" + ClaimNO + "' , sysdate, '" + EPF + "','PAYMENT')";
                        //    dal.ExecuteTableUpdateQuery(insertEmaillog);
                        //}

                        int plan_id = 200;
                        List<string> EMailDataListCC = null;
                        List<string> EMailDataListTO = null;
                        //List<string> EMailDataListBCC = null;

                        EMailData mailOb = new EMailData();
                        reciverAddr = mailOb.getEmailIDForDeathTO("ACTU", "TO", plan_id);


                        //------------add cc list -----------------------------
                        EMailDataListTO = new List<string>();
                        EMailDataListTO = mailOb.getEmailIDForDeath("ACTU", "TO", plan_id);
                        //-

                        //------------add cc list -----------------------------
                        EMailDataListCC = new List<string>();
                        EMailDataListCC = mailOb.getEmailIDForDeath("ACTU", "CC", plan_id);
                        //------------end adding --------------------------------


                        body = "Please find the attachment here with.";
                        //---------------------------send email settings ---------------------------------------------
                        //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

                        using (MemoryStream memoryStream = new MemoryStream(doc.Save()))
                        {
                            doc.Close();
                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();


                            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

                            string smtpClient = WebConfigurationManager.AppSettings["smtpClient"];
                            string mailAddress_ = WebConfigurationManager.AppSettings["mailAddress"];
                            string userName = WebConfigurationManager.AppSettings["userName"];
                            string password = WebConfigurationManager.AppSettings["password"];
                            int port = Convert.ToInt32(WebConfigurationManager.AppSettings["port"]);

                            MailMessage mm = new MailMessage(mailAddress_, reciverAddr);
                            mm.Subject = "Death Claim Re-Insurance Payment Form - Policy No: " + PolNo;
                            mm.Body = body;
                            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), pdfName));
                            mm.IsBodyHtml = true;

                            if (EMailDataListTO != null)
                            {
                                foreach (string item in EMailDataListTO)
                                {
                                    if (item.ToString().ToUpper() != reciverAddr.ToUpper())
                                    {
                                        mm.To.Add(item);
                                    }
                                }
                            }

                            if (EMailDataListCC != null)
                            {
                                foreach (string item in EMailDataListCC)
                                {
                                    mm.CC.Add(item);

                                }
                            }

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = smtpClient;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["ssl"]);
                            NetworkCredential NetworkCred = new NetworkCredential();
                            NetworkCred.UserName = userName;
                            NetworkCred.Password = password;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = port;
                            smtp.Send(mm);

                            if (ADB == "1")
                            {
                                string insertEmaillog = "UPDATE LPHS.DTH_REINS_EMAIL_LOG SET SENT_DATE=sysdate,SENT_BY='" + EPF + "',ERROR='' " +
                                    "WHERE POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='ADB PAYMENT'";
                                dal.ExecuteTableUpdateQuery(insertEmaillog);

                                string updatePayment = "UPDATE LPHS.DTH_REINSURANCE_DTL set ADB_PAYMENT_SENT=sysdate ,ADB_DETAIL_SENT='Y' " +
                                    " where CLAIMNO='" + ClaimNO + "'";
                                dal.ExecuteTableUpdateQuery(updatePayment);
                            }
                            else
                            {
                                string insertEmaillog = "UPDATE LPHS.DTH_REINS_EMAIL_LOG SET SENT_DATE=sysdate,SENT_BY='" + EPF + "',ERROR='' " +
                                    "WHERE POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='PAYMENT'";
                                dal.ExecuteTableUpdateQuery(insertEmaillog);

                                string updatePayment = "UPDATE LPHS.DTH_REINSURANCE_DTL set PAYMENT_DETAIL_SENT='Y'," +
                                    "PAYMENT_DETAIL_SENT_DATE=sysdate,RE_INS_STATUS='COMPLETED' where CLAIMNO='" + ClaimNO + "'";
                                dal.ExecuteTableUpdateQuery(updatePayment);
                            }




                        }

                        dal.CommitTransaction();
                        dal.CloseDBConnection();


                    }
                    catch (Exception ex)
                    {
                        //dal.RollbackTransaction();
                        string err = "";
                        if (ex.ToString().Length > 1500)
                        {
                            err = ex.ToString().Substring(0, 1500);
                        }
                        else
                        {
                            err = ex.ToString();
                        }
                        err = err.Replace("'", "");
                        if (ADB == "1")
                        {
                            string erroUpdate = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set ERROR='" + err + "' " +
                           "WHERE POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='ADB PAYMENT'";
                            dal.ExecuteTableUpdateQuery(erroUpdate);
                        }
                        else
                        {
                            string erroUpdate = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set ERROR='" + err + "' " +
                           "WHERE POLNO='" + PolNo + "' and CLAIMNO='" + ClaimNO + "' and TYPE='PAYMENT'";
                            dal.ExecuteTableUpdateQuery(erroUpdate);
                        }
                        dal.CommitTransaction();
                        dal.CloseDBConnection();
                        EPage.Messege = ex.Message.ToString();
                        Response.Redirect("EPage.aspx");
                    }
                }
                if (ADB == "1")
                {
                    Response.Redirect("~/ADBApproveMemo002.aspx?polino=" + PolNo + "&mos=" + MOF + "&claim_no=" + ClaimNO + "&status=1");
                }
                else
                {
                    Response.Redirect("~/dthPay002.aspx?polno=" + PolNo + "&mos=" + MOF + "&status=1");
                }

            }
            else
            {
                // render web page in browser
                base.Render(writer);
            }
        }
    }
}
