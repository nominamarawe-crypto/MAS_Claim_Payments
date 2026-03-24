using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

public partial class ChildProt_ChildProtPay001 : System.Web.UI.Page
{
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

    DataManager dm;
    ArrayList cprotarray1, cprotarray2;
    int fromdate;
    int fromym;
    int todate;
    int toym;
    int polno;
    //int paydue;
   // int nextdue;
    private int claimno;
    private int dateofdth;
    int dueYM;
    //double payamt;
    int TBL;
    int TRM;
    int COM;
    string comstr;
    int enddt;
    int maturity;
    string maturitystr;
    string enddat;
    bool receiptNotPrinted, receiptPrinted = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fromdate = int.Parse(PreviousPage.FromDate.ToString());
            todate = int.Parse(PreviousPage.ToDate.ToString());
        }
        fromym = int.Parse(fromdate.ToString().Substring(0, 6));
        toym = int.Parse(todate.ToString().Substring(0, 6));
        try
        {
            dm = new DataManager();
            cprotarray1 = new ArrayList();
            cprotarray2 = new ArrayList();
            dueYM = int.Parse(this.setDate()[0].Substring(0, 6));
            //this.txtdue.Text = dueYM.ToString();
            this.lblFrom.Text = fromdate.ToString().Substring(0,4)+"/"+fromdate.ToString().Substring(4,2)+"/"+fromdate.ToString().Substring(6,2);
            this.lblTo.Text = todate.ToString().Substring(0,4)+"/"+todate.ToString().Substring(4,2)+"/"+todate.ToString().Substring(6,2);

            PaymentDueCreater cr = new PaymentDueCreater();
            cr.createDue(dueYM);

            #region-------------Periodic_Paydet Discharge receipt not printed----------------
            string periodicpaydetsel = "select distinct a.POLNO,a.INTIMNO,b.COM,a.PAYMENT_DUE from LCLM.PERIODIC_PAYDET a " +
                "INNER JOIN (select EXTPOL as POLNO, '' as INTIMNO, EXTCOM as COM  from LPHS.EXSURREN " +
                "UNION select PHPOL as POLNO, PHCLAIM as INTIMNO, PHCOM as COM from lphs.lpolhis " +
                "where phtyp = 'D' and phmos = 'M') b ON a.POLNO = b.POLNO where (a.CLMTYPE = 'DTC' or a.CLMTYPE = 'DOC') and a.PAYMENT_DUE <= " + toym + " and a.PAYMENT_DUE >= " + fromym + " AND a.DISCHARGE = 0 " +
                "group by a.POLNO, a.INTIMNO, b.COM, a.PAYMENT_DUE " +
                "ORDER BY a.PAYMENT_DUE, SUBSTR(b.COM,5,4)";
            //string periodicpaydetsel1 = "select distinct POLNO, INTIMNO from LCLM.PERIODIC_PAYDET where (CLMTYPE='DTC' or CLMTYPE='DOC') and PAYMENT_DUE<=" + toym + "  and PAYMENT_DUE>=" + fromym + " AND DISCHARGE = 0 group by POLNO, INTIMNO";
            if (dm.existRecored(periodicpaydetsel) != 0)
            {
                receiptNotPrinted = true;
                dm.readSql(periodicpaydetsel);
                OracleDataReader periodicpaydetread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (periodicpaydetread.Read())
                {
                    if (!periodicpaydetread.IsDBNull(0)) { polno = periodicpaydetread.GetInt32(0); } else { polno = 0; }
                    //if (!periodicpaydetread.IsDBNull(1)) { paydue = periodicpaydetread.GetInt32(1); } else { paydue = 0; }
                    //if (!periodicpaydetread.IsDBNull(2)) { nextdue = periodicpaydetread.GetInt32(2); } else { nextdue = 0; }
                    //if (!periodicpaydetread.IsDBNull(1)) { payamt = periodicpaydetread.GetDouble(1); } else { payamt = 0; }
                    if (!periodicpaydetread.IsDBNull(1)) { claimno = int.Parse(periodicpaydetread.GetString(1)); } else { claimno = 0; }

                    string lpolhissel = "select PHTBL,PHCOM, PHTRM from LPHS.LPOLHIS where PHPOL=" + polno + "";
                    if (dm.existRecored(lpolhissel) != 0)
                    {
                        dm.readSql(lpolhissel);
                        OracleDataReader lpolhisread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        lpolhisread.Read();
                        if (!lpolhisread.IsDBNull(0)) { TBL = lpolhisread.GetInt32(0); } else { TBL = 0; }
                        if (!lpolhisread.IsDBNull(1)) { COM = lpolhisread.GetInt32(1); } else { COM = 0; }
                        if (!lpolhisread.IsDBNull(2)) { TRM = lpolhisread.GetInt32(2); } else { TRM = 0; }
                        //lpolhisread.Close();
                        //lpolhisread.Dispose();

                        string dthintsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DCLM=" + claimno + " ";
                        dm.readSql(dthintsel);
                        OracleDataReader dthintreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        dthintreader.Read();
                        if (!dthintreader.IsDBNull(0)) { dateofdth = dthintreader.GetInt32(0); } else { dateofdth = 0; }
                        //dthintreader.Close();
                        //dthintreader.Dispose();
                    }
                    else
                    {
                        string childprotoutsel = "select TBL, COM, TERM, DTOFDTH from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and CLAIMNO=" + claimno + "";
                        dm.readSql(childprotoutsel);
                        if (dm.existRecored(childprotoutsel) != 0)
                        {
                            OracleDataReader childprotoutreader = dm.oraComm.ExecuteReader();
                            childprotoutreader.Read();
                            if (!childprotoutreader.IsDBNull(0)) { TBL = childprotoutreader.GetInt32(0); } else { TBL = 0; }
                            if (!childprotoutreader.IsDBNull(1)) { COM = childprotoutreader.GetInt32(1); } else { COM = 0; }
                            if (!childprotoutreader.IsDBNull(2)) { TRM = childprotoutreader.GetInt32(2); } else { TRM = 0; }
                            if (!childprotoutreader.IsDBNull(3)) { dateofdth = childprotoutreader.GetInt32(3); } else { dateofdth = 0; }
                        }

                    }
                    maturity = int.Parse(COM.ToString().Substring(0, 4)) + TRM;
                    enddt = int.Parse(maturity.ToString() + COM.ToString().Substring(4, 4));

                    if (TBL == 39 || TBL == 49)
                    {
                        if (int.Parse(dateofdth.ToString().Substring(4, 4)) < int.Parse(COM.ToString().Substring(4, 4)))
                        {
                            comstr = dateofdth.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                        }
                        else
                        {
                            comstr = Convert.ToString(int.Parse(dateofdth.ToString().Substring(0, 4)) + 1) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                        }
                        enddat = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                    }
                    else if (TBL == 38)
                    {
                        comstr = Convert.ToString(maturity - 3) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                        enddat = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                    }
                    else if (TBL == 46)
                    {
                        comstr = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                        enddat = Convert.ToString(maturity + 3) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                    }
                    maturitystr = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);

                    string periodicpayverify = "select PAYMENT_DUE from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and PAYMENT_DUE<=" + toym + "  and PAYMENT_DUE>=" + fromym + "";
                    if (dm.existRecored(periodicpayverify) != 0)
                    {
                        dm.readSql(periodicpayverify);
                        OracleDataReader perioverifyreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        int flag = 0;
                        while (perioverifyreader.Read())
                        {
                            int finddue;
                            if (!perioverifyreader.IsDBNull(0)) { finddue = perioverifyreader.GetInt32(0); } else { finddue = 0; }
                            finddue = int.Parse(finddue.ToString() + COM.ToString().Substring(6, 2));
                            if ((finddue <= todate) && (finddue >= fromdate))
                                flag = 1;
                        }
                        if (flag == 1)
                            cprotarray1.Add(new childprotvou(polno, TBL, comstr, enddat, maturitystr, 0));
                    }
                }
                periodicpaydetread.Close();
                //periodicpaydetread.Dispose();
            }
            //else
            //{
            //    dm.oraConn.Dispose();
            //    throw new Exception("No child protect payments!");
            //}
            #endregion

            #region-------------Periodic_Paydet   Discharge receipt printed----------------

            string periodicpaydetsel2 = "select distinct a.POLNO,a.INTIMNO,b.COM, a.PAYMENT_DUE from LCLM.PERIODIC_PAYDET a " +
                "INNER JOIN (select EXTPOL as POLNO, '' as INTIMNO, EXTCOM as COM  from LPHS.EXSURREN " +
                "UNION select PHPOL as POLNO, PHCLAIM as INTIMNO, PHCOM as COM from lphs.lpolhis " +
                "where phtyp = 'D' and phmos = 'M') b ON a.POLNO = b.POLNO where (a.CLMTYPE = 'DTC' or a.CLMTYPE = 'DOC') and a.PAYMENT_DUE <= " + toym + " and a.PAYMENT_DUE >= " + fromym + " AND a.DISCHARGE = 1 " +
                "group by a.POLNO, a.INTIMNO, b.COM, a.PAYMENT_DUE " +
                "ORDER BY a.PAYMENT_DUE, SUBSTR(b.COM,5,4)";
            string periodicpaydetsel3 = "select distinct POLNO, INTIMNO from LCLM.PERIODIC_PAYDET where (CLMTYPE='DTC' or CLMTYPE='DOC') and PAYMENT_DUE<=" + toym + "  and PAYMENT_DUE>=" + fromym + "AND DISCHARGE = 1 group by POLNO, INTIMNO";
            if (dm.existRecored(periodicpaydetsel2) != 0)
            {
                receiptPrinted = true;
                dm.readSql(periodicpaydetsel2);
                OracleDataReader periodicpaydetread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (periodicpaydetread.Read())
                {
                    if (!periodicpaydetread.IsDBNull(0)) { polno = periodicpaydetread.GetInt32(0); } else { polno = 0; }
                    //polno = 1406822;
                    //if (!periodicpaydetread.IsDBNull(1)) { paydue = periodicpaydetread.GetInt32(1); } else { paydue = 0; }
                    //if (!periodicpaydetread.IsDBNull(2)) { nextdue = periodicpaydetread.GetInt32(2); } else { nextdue = 0; }
                    //if (!periodicpaydetread.IsDBNull(1)) { payamt = periodicpaydetread.GetDouble(1); } else { payamt = 0; }
                    if (!periodicpaydetread.IsDBNull(1)) { claimno = int.Parse(periodicpaydetread.GetString(1)); } else { claimno = 0; }

                    string lpolhissel = "select PHTBL,PHCOM, PHTRM from LPHS.LPOLHIS where PHPOL=" + polno + "";
                    if (dm.existRecored(lpolhissel) != 0)
                    {
                        dm.readSql(lpolhissel);
                        OracleDataReader lpolhisread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        lpolhisread.Read();
                        if (!lpolhisread.IsDBNull(0)) { TBL = lpolhisread.GetInt32(0); } else { TBL = 0; }
                        if (!lpolhisread.IsDBNull(1)) { COM = lpolhisread.GetInt32(1); } else { COM = 0; }
                        if (!lpolhisread.IsDBNull(2)) { TRM = lpolhisread.GetInt32(2); } else { TRM = 0; }
                        //lpolhisread.Close();
                        //lpolhisread.Dispose();

                        string dthintsel = "select DDTOFDTH from LPHS.DTHINT where DPOLNO=" + polno + " and DCLM=" + claimno + " ";
                        dm.readSql(dthintsel);
                        OracleDataReader dthintreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        dthintreader.Read();
                        if (!dthintreader.IsDBNull(0)) { dateofdth = dthintreader.GetInt32(0); } else { dateofdth = 0; }
                        //dthintreader.Close();
                        //dthintreader.Dispose();
                    }
                    else
                    {
                        string childprotoutsel = "select TBL, COM, TERM, DTOFDTH from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and CLAIMNO=" + claimno + "";
                        dm.readSql(childprotoutsel);
                        if (dm.existRecored(childprotoutsel) != 0)
                        {
                            OracleDataReader childprotoutreader = dm.oraComm.ExecuteReader();
                            childprotoutreader.Read();
                            if (!childprotoutreader.IsDBNull(0)) { TBL = childprotoutreader.GetInt32(0); } else { TBL = 0; }
                            if (!childprotoutreader.IsDBNull(1)) { COM = childprotoutreader.GetInt32(1); } else { COM = 0; }
                            if (!childprotoutreader.IsDBNull(2)) { TRM = childprotoutreader.GetInt32(2); } else { TRM = 0; }
                            if (!childprotoutreader.IsDBNull(3)) { dateofdth = childprotoutreader.GetInt32(3); } else { dateofdth = 0; }
                        }

                    }
                    maturity = int.Parse(COM.ToString().Substring(0, 4)) + TRM;
                    enddt = int.Parse(maturity.ToString() + COM.ToString().Substring(4, 4));

                    if (TBL == 39 || TBL == 49)
                    {
                        if (int.Parse(dateofdth.ToString().Substring(4, 4)) < int.Parse(COM.ToString().Substring(4, 4)))
                        {
                            comstr = dateofdth.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                        }
                        else
                        {
                            comstr = Convert.ToString(int.Parse(dateofdth.ToString().Substring(0, 4)) + 1) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                        }
                        enddat = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                    }

                    else if (TBL == 38)
                    {
                        comstr = Convert.ToString(maturity - 3) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                        enddat = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                    }
                    else if (TBL == 46)
                    {
                        comstr = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);
                        enddat = Convert.ToString(maturity + 3) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2);
                    }
                    maturitystr = enddt.ToString().Substring(0, 4) + "/" + enddt.ToString().Substring(4, 2) + "/" + enddt.ToString().Substring(6, 2);

                    string periodicpayverify = "select PAYMENT_DUE from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and PAYMENT_DUE<=" + toym + "  and PAYMENT_DUE>=" + fromym + "";
                    if (dm.existRecored(periodicpayverify) != 0)
                    {
                        dm.readSql(periodicpayverify);
                        OracleDataReader perioverifyreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        int flag = 0;
                        while (perioverifyreader.Read())
                        {
                            int finddue;
                            if (!perioverifyreader.IsDBNull(0)) { finddue = perioverifyreader.GetInt32(0); } else { finddue = 0; }
                            finddue = int.Parse(finddue.ToString() + COM.ToString().Substring(6, 2));
                            if ((finddue <= todate) && (finddue >= fromdate))
                                flag = 1;
                        }
                        if (flag == 1)
                            cprotarray2.Add(new childprotvou(polno, TBL, comstr, enddat, maturitystr, 0));
                    }
                }
                periodicpaydetread.Close();
                //periodicpaydetread.Dispose();
            }
            //else
            //{
            //    dm.oraConn.Dispose();
            //    throw new Exception("No child protect payments!");
            //}
            #endregion


            if (!receiptPrinted && !receiptNotPrinted)
            {
                dm.oraConn.Dispose();
                throw new Exception("No child protect payments!");
            }

            DataGrid1.DataSource = CreateDataSource();
            DataGrid1.DataBind();
            DataGrid2.DataSource = CreateDataSource2();
            DataGrid2.DataBind();
            dm.connClose();
            dm.oraConn.Dispose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            dm.oraConn.Dispose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    public ICollection CreateDataSource()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";
        int i = 0;
        dt.Columns.Add(new DataColumn("polNo", typeof(string)));
        dt.Columns.Add(new DataColumn("table", typeof(string)));
        dt.Columns.Add(new DataColumn("startDt", typeof(string)));
        dt.Columns.Add(new DataColumn("endDate", typeof(string)));
        dt.Columns.Add(new DataColumn("maturityDt", typeof(string)));


        foreach (childprotvou childprotobj in cprotarray1)
        {
            if (childprotobj.Table == 39 || childprotobj.Table == 49)
            {
                linkUrl = "<a  href=ChildProtPay002.aspx?polNo=" + childprotobj.Polno + "&maturityDt=" + childprotobj.Maturitydt + "&dueYm=" + dueYM + ">" + childprotobj.Polno + "</a>";
                dr = dt.NewRow();
                dr[0] = linkUrl;
                dr[1] = childprotobj.Table.ToString();
                dr[2] = childprotobj.Startdt.ToString();
                dr[3] = childprotobj.Enddate.ToString();
                dr[4] = childprotobj.Maturitydt.ToString();

                dt.Rows.Add(dr);
                i++;
            }
        }

        if (i != 0)
        {
            RNotPrinted.Visible = true;
        }
        DataView dv = new DataView(dt);
        return dv;
    }

    public ICollection CreateDataSource2()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";
        int i = 0;

        dt.Columns.Add(new DataColumn("polNo", typeof(string)));
        dt.Columns.Add(new DataColumn("table", typeof(string)));
        dt.Columns.Add(new DataColumn("startDt", typeof(string)));
        dt.Columns.Add(new DataColumn("endDate", typeof(string)));
        dt.Columns.Add(new DataColumn("maturityDt", typeof(string)));


        foreach (childprotvou childprotobj in cprotarray2)
        {
            if (childprotobj.Table == 39 || childprotobj.Table == 49)
            {
                linkUrl = "<a  href=ChildProtPay002.aspx?polNo=" + childprotobj.Polno + "&maturityDt=" + childprotobj.Maturitydt + "&dueYm=" + dueYM + ">" + childprotobj.Polno + "</a>";
                dr = dt.NewRow();
                dr[0] = linkUrl;
                dr[1] = childprotobj.Table.ToString();
                dr[2] = childprotobj.Startdt.ToString();
                dr[3] = childprotobj.Enddate.ToString();
                dr[4] = childprotobj.Maturitydt.ToString();

                dt.Rows.Add(dr);
                i++;
            }
        }

        if (i != 0)
        {
            RPrinted.Visible = true;
        }
        DataView dv = new DataView(dt);
        return dv;
    }

    protected void txtdue_TextChanged(object sender, EventArgs e)
    {
        //dueYM = txtdue.Text;
    }
}
