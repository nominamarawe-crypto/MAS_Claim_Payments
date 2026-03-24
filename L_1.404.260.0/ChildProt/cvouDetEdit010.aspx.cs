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

public partial class cvouDetEdit010 : System.Web.UI.Page
{
    private long polno;
    private string MOS;
//    private int Payment_due;
    private double payAmt;
    private string vouno;
    private string payeename;
    private int nomCount;
    private string payee;
    private int tbl;
    protected ArrayList payeeDetList;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //{
        //    polno = this.PreviousPage.Polno;
        //    MOS = PreviousPage.mos;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["polino"] != null)
            {
                polno = int.Parse(Request.QueryString["polino"].ToString());
                ViewState.Add("polnoQstr", polno.ToString());
                if (Request.QueryString["mos"] != null)
                {
                    MOS = Request.QueryString["mos"].ToString();
                    ViewState.Add("mosQstr", MOS.ToString());
                }

            }
            else
            {
                polno = this.PreviousPage.Polno;
                MOS = PreviousPage.mos;
            }
            dm = new DataManager();
            try
            {
                payeeDetList = new ArrayList();

                string periodicsel = "";

                string childprotoutsel = "select tbl from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + "";

                if (dm.existRecored(childprotoutsel) != 0)
                {
                    dm.readSql(childprotoutsel);
                    OracleDataReader oldChildReader = dm.oraComm.ExecuteReader();
                    while (oldChildReader.Read())
                    {
                        if (!oldChildReader.IsDBNull(0)) { tbl = oldChildReader.GetInt32(0); } else { tbl = 0; }
                        payee = "OUT";
                    }
                    oldChildReader.Close();
                }

                string lpolhisSel = "select phtbl from lphs.lpolhis where phpol=" + polno + " and phtyp='D' and phmos='M'";
                if (dm.existRecored(lpolhisSel) != 0)
                {
                    dm.readSql(lpolhisSel);
                    OracleDataReader lpolhisReader = dm.oraComm.ExecuteReader();
                    while (lpolhisReader.Read())
                    {
                        if (!lpolhisReader.IsDBNull(0)) { tbl = lpolhisReader.GetInt32(0); } else { tbl = 0; }
                    }
                    lpolhisReader.Close();
                }

                string exsurenSel = "select EXTTBL from LPHS.EXSURREN where EXTPOL=" + polno + "";
                if (dm.existRecored(exsurenSel) != 0)
                {
                    dm.readSql(exsurenSel);
                    OracleDataReader exsurenReader = dm.oraComm.ExecuteReader();
                    while (exsurenReader.Read())
                    {
                        if (!exsurenReader.IsDBNull(0)) { tbl = exsurenReader.GetInt32(0); } else { tbl = 0; }
                    }
                    exsurenReader.Close();
                }

                if (tbl == 38)
                {
                    throw new Exception("Table 38 vouchers cann't edit this system! Please contact Maturity Department.");
                }
               
                //string nomCunt = "select count(*) from LUND.NOMINEE where POLNO = " + polno + " order by nomno "; - #Task 38266
                string nomCunt = "select  count(distinct(nomnam)) from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";
                if (dm.existRecored(nomCunt) != 0)
                {
                    dm.readSql(nomCunt);
                    OracleDataReader nomineeCountReader = dm.oraComm.ExecuteReader();
                    while (nomineeCountReader.Read())
                    {
                        if (!nomineeCountReader.IsDBNull(0)) { nomCount = nomineeCountReader.GetInt32(0); } else { nomCount = 0; }
                    }
                    nomineeCountReader.Close();
                }

                if (nomCount > 1 && (payee != "OUT" || tbl == 49))
                //if (nomCount > 1 || (payee == "OUT" && nomCount > 1))
                {
                    periodicsel = "select VOU_NO, SUM(PAID_AMT), INTI_NO from LCLM.NOM_PERIODIC_PAYDET where POLICY_NO=" + polno + " and LIFE_TYPE='M' and (CLAIM_TYPE='DTC' or CLAIM_TYPE='DOC') and VOU_NO is not null and VOU_NO != 'XXXX' group by VOU_NO, INTI_NO";
                }
                else
                {
                    periodicsel = "select VONO, SUM(PAID_AMT), INTIMNO from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and LIFE_TYP='" + MOS + "' and (CLMTYPE='DTC' or CLMTYPE='DOC') and VONO is not null and VONO != 'XXXX' group by VONO, INTIMNO";
                }

                if (dm.existRecored(periodicsel) != 0)
                {
                    dm.readSql(periodicsel);
                    OracleDataReader periodicread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (periodicread.Read())
                    {
                        //if (!periodicread.IsDBNull(0)) { Payment_due = periodicread.GetInt32(0); } else { Payment_due = 0; }
                        if (!periodicread.IsDBNull(0)) { vouno = periodicread.GetString(0); } else { vouno = ""; }
                        if (!periodicread.IsDBNull(1)) { payAmt = periodicread.GetDouble(1); } else { payAmt = 0; }
                        string payeedatasel = "select PAYEENAME from LPHS.VOUBANKDET where VOUCHERNO = '" + vouno + "'";
                        if (dm.existRecored(payeedatasel) != 0)
                        {
                            dm.readSql(payeedatasel);
                            OracleDataReader payeedataread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (payeedataread.Read())
                            {
                                if (!payeedataread.IsDBNull(0)) { payeename = payeedataread.GetString(0); } else { payeename = ""; }
                            }
                            //payeedataread.Close();
                            //payeedataread.Dispose();
                        }
                        payeeDetList.Add(new vouPrintFields(vouno, "Nominee", payeename, payAmt, 0));
                    }
                    periodicread.Close();
                    //periodicread.Dispose();
                }
                else
                {
                    dm.oraConn.Dispose();
                    throw new Exception("No Voucher has created yet!");
                }
                DataGrid1.DataSource = CreateDataSource();
                DataGrid1.DataBind();
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
    }
    public ICollection CreateDataSource()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("vouno", typeof(string)));
        dt.Columns.Add(new DataColumn("payee", typeof(string)));
        dt.Columns.Add(new DataColumn("name", typeof(string)));
        dt.Columns.Add(new DataColumn("amount", typeof(string)));

        foreach (vouPrintFields vpf in payeeDetList)
        {
            linkUrl = "<a  href=cvouDetEdit002.aspx?vouno=" + vpf.Vouno + "&payee=" + vpf.Payee + "&amount=" + vpf.Share + "&polno=" + polno.ToString() + "&mos=" + MOS + ">" + vpf.Vouno + "</a>";
            dr = dt.NewRow();

            dr[0] = linkUrl;
            dr[1] = vpf.Payee;
            dr[2] = vpf.PayeeName;
            dr[3] = vpf.Share;

            dt.Rows.Add(dr);
        }

        DataView dv = new DataView(dt);
        return dv;
    }
}
