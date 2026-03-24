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

public partial class dthOut002 : System.Web.UI.Page
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
    
    private int startdate;
    private int enddate;
    private int brCode;

    private long polno;
    private string MOS;
    private long claimNo;
    private double netClm;
    private double grossclm;
    private double amtout;
    private double TOTPAYAMT;
    private double exgraciaAmt;
    private string PAYEE;
    private string entepf;

    DataManager dm;
    ArrayList outList;
    ArrayList outList2;
    ArrayList outList3;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            startdate = this.PreviousPage.Startdate;
            enddate = this.PreviousPage.Enddate;
            brCode = this.PreviousPage.BrCode;
        }
                
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
               
                outList = new ArrayList();
                outList2 = new ArrayList();
                outList3 = new ArrayList();

                #region ----------- memo and distribution approved but claim not completed list -----------
                string dthrefSel = "select DRPOLNO, DRMOS, DRCLMNO, DRGROSSCLM, DRNETCLM, SMASS_PVAL, AMTOUT, " +
                    " PAYEE, TOTPAYAMT, EXGRACIA_AMOUNT, DENTEPF from LPHS.DTHREF " +
                    " where (completed = 'Y' and payautdt > " + enddate + " and dentdt < " + enddate + " and dentdt >= " + startdate + " and branch = " + brCode + ") " +
                    " or ((completed is null or completed <> 'Y' or completed <> 'R') and dentdt <= " + enddate + " and dentdt >= " + startdate + " and MEMOAPRV = 'Y' and DISTN_AUT > 0 and branch = " + brCode + ") ";

                if (dm.existRecored(dthrefSel) != 0)
                {
                    dm.readSql(dthrefSel);
                    OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader.Read())
                    {
                        if (!dthrefReader.IsDBNull(0)) { polno = dthrefReader.GetInt64(0); } else { polno = 0; }
                        if (!dthrefReader.IsDBNull(1)) { MOS = dthrefReader.GetString(1); } else { MOS = ""; }
                        if (!dthrefReader.IsDBNull(2)) { claimNo = dthrefReader.GetInt64(2); } else { claimNo = 0; }
                        if (!dthrefReader.IsDBNull(4)) { netClm = dthrefReader.GetDouble(4); } else { netClm = 0; }
                        if (!dthrefReader.IsDBNull(3)) { grossclm = dthrefReader.GetDouble(3); } else { grossclm = 0; }
                        if (!dthrefReader.IsDBNull(6)) { amtout = dthrefReader.GetDouble(6); } else { amtout = 0; }
                        if (!dthrefReader.IsDBNull(8)) { TOTPAYAMT = dthrefReader.GetDouble(8); } else { TOTPAYAMT = 0; }
                        if (!dthrefReader.IsDBNull(7)) { PAYEE = dthrefReader.GetString(7); } else { PAYEE = ""; }
                        if (!dthrefReader.IsDBNull(9)) { exgraciaAmt = dthrefReader.GetDouble(9); } else { exgraciaAmt = 0; }
                        if (!dthrefReader.IsDBNull(10)) { entepf = dthrefReader.GetString(10); } else { entepf = ""; }

                        outList.Add(new dthOutClms(polno, MOS, claimNo, netClm, grossclm, amtout, TOTPAYAMT, PAYEE, exgraciaAmt));

                    }
                    dthrefReader.Close();
                    dthrefReader.Dispose();

                    GridView1.DataSource = drawGrid();
                    GridView1.DataBind();
                }
                #endregion

                #region -------------- memo not yet approved list -----------

                string dthrefSel2 = "select DRPOLNO, DRMOS, DRCLMNO, DRGROSSCLM, DRNETCLM, SMASS_PVAL, AMTOUT, " +
                   " PAYEE, TOTPAYAMT, EXGRACIA_AMOUNT, DENTEPF from LPHS.DTHREF " +
                   " where (completed = 'Y' and payautdt > " + enddate + " and dentdt < " + enddate + " and dentdt >= " + startdate + " and branch = " + brCode + ") " +
                   " or ((completed is null or completed <> 'Y' or completed <> 'R') and dentdt <= " + enddate + " and dentdt >= " + startdate + " and ((MEMOAPRV <> 'Y' and MEMOAPRV <> 'R') or MEMOAPRV is null) and (DISTN_AUT = 0 or DISTN_AUT is null) and branch = " + brCode + ") ";

                if (dm.existRecored(dthrefSel2) != 0)
                {
                    dm.readSql(dthrefSel2);
                    OracleDataReader dthrefReader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader2.Read())
                    {
                        if (!dthrefReader2.IsDBNull(0)) { polno = dthrefReader2.GetInt64(0); } else { polno = 0; }
                        if (!dthrefReader2.IsDBNull(1)) { MOS = dthrefReader2.GetString(1); } else { MOS = ""; }
                        if (!dthrefReader2.IsDBNull(2)) { claimNo = dthrefReader2.GetInt64(2); } else { claimNo = 0; }
                        if (!dthrefReader2.IsDBNull(4)) { netClm = dthrefReader2.GetDouble(4); } else { netClm = 0; }
                        if (!dthrefReader2.IsDBNull(3)) { grossclm = dthrefReader2.GetDouble(3); } else { grossclm = 0; }
                        if (!dthrefReader2.IsDBNull(6)) { amtout = dthrefReader2.GetDouble(6); } else { amtout = 0; }
                        if (!dthrefReader2.IsDBNull(8)) { TOTPAYAMT = dthrefReader2.GetDouble(8); } else { TOTPAYAMT = 0; }
                        if (!dthrefReader2.IsDBNull(7)) { PAYEE = dthrefReader2.GetString(7); } else { PAYEE = ""; }
                        if (!dthrefReader2.IsDBNull(9)) { exgraciaAmt = dthrefReader2.GetDouble(9); } else { exgraciaAmt = 0; }
                        if (!dthrefReader2.IsDBNull(10)) { entepf = dthrefReader2.GetString(10); } else { entepf = ""; }

                        outList2.Add(new dthOutClms(polno, MOS, claimNo, netClm, grossclm, amtout, TOTPAYAMT, PAYEE, exgraciaAmt));

                    }
                    dthrefReader2.Close();
                    dthrefReader2.Dispose();

                    GridView2.DataSource = drawGrid2();
                    GridView2.DataBind();
                }

                #endregion

                #region -------------- memo approved but distribution not approved list -----------
                string dthrefSel3 = "select DRPOLNO, DRMOS, DRCLMNO, DRGROSSCLM, DRNETCLM, SMASS_PVAL, AMTOUT, " +
                 " PAYEE, TOTPAYAMT, EXGRACIA_AMOUNT, DENTEPF from LPHS.DTHREF " +
                 " where (completed = 'Y' and payautdt > " + enddate + " and dentdt < " + enddate + " and dentdt >= " + startdate + " and branch = " + brCode + ") " +
                 " or ((completed is null or completed <> 'Y' or completed <> 'R') and dentdt <= " + enddate + " and dentdt >= " + startdate + " and MEMOAPRV = 'Y' and (DISTN_AUT = 0 or DISTN_AUT is null) and branch = " + brCode + ") ";
                if (dm.existRecored(dthrefSel3) != 0)
                {
                    dm.readSql(dthrefSel3);
                    OracleDataReader dthrefReader3 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthrefReader3.Read())
                    {
                        if (!dthrefReader3.IsDBNull(0)) { polno = dthrefReader3.GetInt64(0); } else { polno = 0; }
                        if (!dthrefReader3.IsDBNull(1)) { MOS = dthrefReader3.GetString(1); } else { MOS = ""; }
                        if (!dthrefReader3.IsDBNull(2)) { claimNo = dthrefReader3.GetInt64(2); } else { claimNo = 0; }
                        if (!dthrefReader3.IsDBNull(4)) { netClm = dthrefReader3.GetDouble(4); } else { netClm = 0; }
                        if (!dthrefReader3.IsDBNull(3)) { grossclm = dthrefReader3.GetDouble(3); } else { grossclm = 0; }
                        if (!dthrefReader3.IsDBNull(6)) { amtout = dthrefReader3.GetDouble(6); } else { amtout = 0; }
                        if (!dthrefReader3.IsDBNull(8)) { TOTPAYAMT = dthrefReader3.GetDouble(8); } else { TOTPAYAMT = 0; }
                        if (!dthrefReader3.IsDBNull(7)) { PAYEE = dthrefReader3.GetString(7); } else { PAYEE = ""; }
                        if (!dthrefReader3.IsDBNull(9)) { exgraciaAmt = dthrefReader3.GetDouble(9); } else { exgraciaAmt = 0; }
                        if (!dthrefReader3.IsDBNull(10)) { entepf = dthrefReader3.GetString(10); } else { entepf = ""; }

                        outList3.Add(new dthOutClms(polno, MOS, claimNo, netClm, grossclm, amtout, TOTPAYAMT, PAYEE, exgraciaAmt));

                    }
                    dthrefReader3.Close();
                    dthrefReader3.Dispose();

                    GridView3.DataSource = drawGrid3();
                    GridView3.DataBind();
                }

                #endregion

                #region -------------- just intimated -----------
                DataTable dt = new DataTable();
                string dthintSl = "select a.dpolno, a.dmos, b.description, a.dinfodat, a.dpolst, a.dnod, a.ddtofdth " +
                    " from LPHS.DTHINT a, lclm.life_type_desc b where a.dmos = b.type and a.dsta = 0 and " +
                    " a.dinfodat >= " + startdate + " and a.dinfodat <= " + enddate + " and a.dpolbrn = " + brCode + " order by a.dinfodat ";
                OracleDataAdapter dat = new OracleDataAdapter(dthintSl, dm.oraConn);
                dat.Fill(dt);
                GridView4.DataSource = dt;
                GridView4.DataBind();

                #endregion

                dm.connclose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }

    protected ICollection drawGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("dtofint", typeof(string)));
        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("clmno", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofdth", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofcom", typeof(string)));
        dt.Columns.Add(new DataColumn("bsum", typeof(string)));
        dt.Columns.Add(new DataColumn("tbl", typeof(string)));
        dt.Columns.Add(new DataColumn("trm", typeof(string)));
        dt.Columns.Add(new DataColumn("epf", typeof(string)));      
        dt.Columns.Add(new DataColumn("netclm", typeof(string)));
        dt.Columns.Add(new DataColumn("grossclm", typeof(string)));
        dt.Columns.Add(new DataColumn("amtout", typeof(string)));

        foreach (dthOutClms outClmObj in outList)
        {
            if (outClmObj.Amtout > 0)
            {
                linkUrl = "<a  href=trnState001.aspx?polNo=" + outClmObj.Polno.ToString() + "&mos=" + outClmObj.mOS + ">" + outClmObj.Polno + "</a>";
                dr = dt.NewRow();
                dr[0] = outClmObj.Dtofint.ToString();
                dr[1] = linkUrl;
                dr[2] = outClmObj.ClaimNo.ToString();
                dr[3] = outClmObj.Dtofdth.ToString();
                dr[4] = outClmObj.dCO.ToString();
                dr[5] = outClmObj.bSA.ToString();
                dr[6] = outClmObj.Tbl.ToString();
                dr[7] = outClmObj.Trm.ToString();
                dr[8] = entepf;
                dr[9] = outClmObj.NetClm.ToString();
                dr[10] = outClmObj.Grossclm.ToString();
                dr[11] = outClmObj.Amtout.ToString();

                dt.Rows.Add(dr);
            }
        }

        DataView dv = new DataView(dt);
        return dv;

    }

    protected ICollection drawGrid2()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("dtofint", typeof(string)));
        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("clmno", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofdth", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofcom", typeof(string)));
        dt.Columns.Add(new DataColumn("bsum", typeof(string)));
        dt.Columns.Add(new DataColumn("tbl", typeof(string)));
        dt.Columns.Add(new DataColumn("trm", typeof(string)));
        dt.Columns.Add(new DataColumn("epf", typeof(string)));
        //dt.Columns.Add(new DataColumn("netclm", typeof(string)));
        //dt.Columns.Add(new DataColumn("grossclm", typeof(string)));
        //dt.Columns.Add(new DataColumn("amtout", typeof(string)));

        foreach (dthOutClms outClmObj in outList2)
        {
            //if (outClmObj.Amtout > 0)
            //{
                linkUrl = "<a  href=trnState001.aspx?polNo=" + outClmObj.Polno.ToString() + "&mos=" + outClmObj.mOS + ">" + outClmObj.Polno + "</a>";
                dr = dt.NewRow();
                dr[0] = outClmObj.Dtofint.ToString();
                dr[1] = linkUrl;
                dr[2] = outClmObj.ClaimNo.ToString();
                dr[3] = outClmObj.Dtofdth.ToString();
                dr[4] = outClmObj.dCO.ToString();
                dr[5] = outClmObj.bSA.ToString();
                dr[6] = outClmObj.Tbl.ToString();
                dr[7] = outClmObj.Trm.ToString();
                dr[8] = entepf;
                //dr[9] = outClmObj.NetClm.ToString();
                //dr[10] = outClmObj.Grossclm.ToString();
                //dr[11] = outClmObj.Amtout.ToString();

                dt.Rows.Add(dr);
            //}
        }

        DataView dv = new DataView(dt);
        return dv;

    }

    protected ICollection drawGrid3()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("dtofint", typeof(string)));
        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("clmno", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofdth", typeof(string)));
        dt.Columns.Add(new DataColumn("dtofcom", typeof(string)));
        dt.Columns.Add(new DataColumn("bsum", typeof(string)));
        dt.Columns.Add(new DataColumn("tbl", typeof(string)));
        dt.Columns.Add(new DataColumn("trm", typeof(string)));
        dt.Columns.Add(new DataColumn("epf", typeof(string)));
        dt.Columns.Add(new DataColumn("netclm", typeof(string)));
        dt.Columns.Add(new DataColumn("grossclm", typeof(string)));
        dt.Columns.Add(new DataColumn("amtout", typeof(string)));

        foreach (dthOutClms outClmObj in outList3)
        {
            //if (outClmObj.Amtout > 0)
            //{
                linkUrl = "<a  href=trnState001.aspx?polNo=" + outClmObj.Polno.ToString() + "&mos=" + outClmObj.mOS + ">" + outClmObj.Polno + "</a>";
                dr = dt.NewRow();
                dr[0] = outClmObj.Dtofint.ToString();
                dr[1] = linkUrl;
                dr[2] = outClmObj.ClaimNo.ToString();
                dr[3] = outClmObj.Dtofdth.ToString();
                dr[4] = outClmObj.dCO.ToString();
                dr[5] = outClmObj.bSA.ToString();
                dr[6] = outClmObj.Tbl.ToString();
                dr[7] = outClmObj.Trm.ToString();
                dr[8] = entepf;
                dr[9] = outClmObj.NetClm.ToString();
                dr[10] = outClmObj.Grossclm.ToString();
                dr[11] = outClmObj.Amtout.ToString();

                dt.Rows.Add(dr);
            //}
        }

        DataView dv = new DataView(dt);
        return dv;

    }

    protected void GridView4_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            polno = long.Parse(GridView4.Rows[e.NewSelectedIndex].Cells[1].Text);
            MOS = GridView4.Rows[e.NewSelectedIndex].Cells[2].Text;

            Response.Redirect("trnState001.aspx?polNo=" + polno.ToString() + "&mos=" + MOS + "", false);
        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
