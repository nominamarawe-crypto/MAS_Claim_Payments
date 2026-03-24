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

public partial class cvouauth002 : System.Web.UI.Page
{
    private long polno;
    private string MOS;
    private int Payment_due;
    private double payAmt;
    private string vouno, tempvou;
    private string payeename;
    protected ArrayList payeeDetList;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOS = PreviousPage.mos;

            dm = new DataManager();
            try
            {
                payeeDetList = new ArrayList();
                tempvou = "";
                string periodicsel = "select PAYMENT_DUE, VONO, PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and LIFE_TYP='" + MOS + "' and (CLMTYPE='DTC' or CLMTYPE='DOC') and VONO is not null and VONO != 'XXXX'";
                if (dm.existRecored(periodicsel) != 0)
                {
                    dm.readSql(periodicsel);
                    OracleDataReader periodicread = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (periodicread.Read())
                    {
                        if (!periodicread.IsDBNull(0)) { Payment_due = periodicread.GetInt32(0); } else { Payment_due = 0; }
                        if (!periodicread.IsDBNull(1)) { vouno = periodicread.GetString (1); } else { vouno = ""; }
                        //if (!periodicread.IsDBNull(2)) { payAmt = periodicread.GetDouble(2); } else { payAmt = 0; }

                        if (!tempvou.Equals(vouno))
                        {
                            tempvou = vouno;
                            string totalamtsel = "select sum(PAID_AMT) from LCLM.PERIODIC_PAYDET where VONO='" + vouno + "'";
                            if (dm.existRecored(totalamtsel) != 0)
                            {
                                dm.readSql(totalamtsel);
                                OracleDataReader totalamtreader = dm.oraComm.ExecuteReader();
                                totalamtreader.Read();
                                if (!totalamtreader.IsDBNull(0)) { payAmt = totalamtreader.GetDouble(0); } else { payAmt = 0; }
                            }
                        }
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
                    periodicread.Dispose();
                }
                else 
                {
                    dm.oraConn.Dispose();
                    throw new Exception("No Vouchers has created yet!"); 
                }

               /* #region-----------check voucher print-------------
                string vouprintsel = "select VPDATE from CASHBOOK.TEMP_CB where VOUNO=" + vouno + " and VPDATE is not null";
                if (dm.existRecored(vouprintsel) == 0)
                {
                    throw new Exception ("No Vouchers Printed!");
                }
                #endregion*/

                DataGrid1.DataSource = CreateDataSource();
                DataGrid1.DataBind();
                dm.connClose();
            }
            catch (Exception ex)
            {
                dm.connclose();
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
            linkUrl = "<a  href=cvouAuth003.aspx?vouno=" + vpf.Vouno + "&payee=" + vpf.Payee + "&amount=" + vpf.Share + "&polno=" + polno.ToString() + "&mos=" + MOS + ">" + vpf.Vouno + "</a>";
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
