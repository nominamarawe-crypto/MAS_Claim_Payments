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

public partial class OldChildProt_ChildProtRev002 : System.Web.UI.Page
{
    private long polno, clmno;
    private string mos, vouno, lifetyp, paynam, insnam, ad1, ad2, ad3, ad4;
    private int tbl, trm, dtofdth, npdue, matdate, com;
    private double sumass;
    private ArrayList vouindex;
    DataManager dm;
    DataManager dmread;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            dmread = new DataManager();            
            if (!Page.IsPostBack)
            {
                polno = this.PreviousPage.Polno;
                mos = this.PreviousPage.Mos;

                switch (mos)
                {
                    case "M": lifetyp = "Main Life"; break;
                    case "S": lifetyp = "Spouce"; break;
                    case "2": lifetyp = "Second Life"; break;
                }

                #region----------------Child Prot Out Read-------------
                string childprotoutsel = "select TBL, TERM, DTOFDTH, CLAIMNO, SUMASS, NPDUE, MATDATE, COM, PAYNAM, AD1, AD2, AD3, AD4" +
                    " from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + mos + "'";
                if (dmread.existRecored(childprotoutsel) != 0)
                {
                    dmread.readSql(childprotoutsel);
                    OracleDataReader childprotreader = dmread.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (childprotreader.Read())
                    {
                        if (!childprotreader.IsDBNull(0)) { tbl = childprotreader.GetInt32(0); } else { tbl = 0; }
                        if (!childprotreader.IsDBNull(1)) { trm = childprotreader.GetInt32(1); } else { trm = 0; }
                        if (!childprotreader.IsDBNull(2)) { dtofdth = childprotreader.GetInt32(2); } else { dtofdth = 0; }
                        if (!childprotreader.IsDBNull(3)) { clmno = childprotreader.GetInt64(3); } else { clmno = 0; }
                        if (!childprotreader.IsDBNull(4)) { sumass = childprotreader.GetDouble(4); } else { sumass = 0; }
                        if (!childprotreader.IsDBNull(5)) { npdue = childprotreader.GetInt32(5); } else { npdue = 0; }
                        if (!childprotreader.IsDBNull(6)) { matdate = childprotreader.GetInt32(6); } else { matdate = 0; }
                        if (!childprotreader.IsDBNull(7)) { com = childprotreader.GetInt32(7); } else { com = 0; }
                        if (!childprotreader.IsDBNull(8)) { paynam = childprotreader.GetString(8); } else { paynam = ""; }
                        if (!childprotreader.IsDBNull(9)) { ad1 = childprotreader.GetString(9); } else { ad1 = ""; }
                        if (!childprotreader.IsDBNull(10)) { ad2 = childprotreader.GetString(10); } else { ad2 = ""; }
                        if (!childprotreader.IsDBNull(11)) { ad3 = childprotreader.GetString(11); } else { ad3 = ""; }
                        if (!childprotreader.IsDBNull(12)) { ad4 = childprotreader.GetString(12); } else { ad4 = ""; }
                    }
                    childprotreader.Close();
                    childprotreader.Dispose();
                }
                else
                {
                    throw new Exception("No such claim found!");
                }

                string phnamesel = "select PNSTA, PNINT, PNSUR from LPHS.PHNAME where PNPOL=" + polno + "";
                if (dmread.existRecored(phnamesel) != 0)
                {
                    dmread.readSql(phnamesel);
                    OracleDataReader phnamereader = dmread.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (phnamereader.Read())
                    {
                        if (!phnamereader.IsDBNull(0)) { insnam = phnamereader.GetString(0); }
                        if (!phnamereader.IsDBNull(1)) { insnam += " " + phnamereader.GetString(1); }
                        if (!phnamereader.IsDBNull(2)) { insnam += " " + phnamereader.GetString(2); }
                    }
                }

                #endregion

                #region---------------Print Values----------------
                this.lblPolno.Text = polno.ToString();
                this.lblMos.Text = lifetyp;
                this.lblTbl.Text = tbl.ToString();
                this.lblTrm.Text = trm.ToString();
                this.lblDtofdth.Text = dtofdth.ToString();
                this.lblClmno.Text = clmno.ToString();
                this.lblSumass.Text = sumass.ToString();
                this.lblChilprotdue.Text = npdue.ToString();
                this.lblDtofcom.Text = com.ToString();
                this.lblinsname.Text = insnam;
                this.lblAd1.Text = ad1;
                this.lblAd2.Text = ad2;
                this.lblAd3.Text = ad3;
                this.lblAd4.Text = ad4;
                #endregion

                ViewState["polno"] = polno;
                ViewState["mos"] = mos;
            }
            else
            {
                if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
                if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
            }
        }
        catch (Exception Ex)
        {            
            dmread.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dmread = new DataManager();
            dm.begintransaction();
            vouindex = new ArrayList();
            string childprotoutsel = "select * from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + mos + "'";
            if (dm.existRecored(childprotoutsel) == 0)
            {
                throw new Exception("No such claim. Please check Policy Number & Life Type!");
            }
            string vounosel = "select VONO from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='DOC'";
            if (dm.existRecored(vounosel) != 0)
            {
                dmread.readSql(vounosel);
                OracleDataReader vounoreader = dmread.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (vounoreader.Read())
                {
                    if (!vounoreader.IsDBNull(0)) { vouno = vounoreader.GetString(0); } else { vouno = ""; }
                    vouindex.Add(vouno);
                }
                vounoreader.Close();
                vounoreader.Dispose();
            }
            foreach(string vounum in vouindex)//Cheque Print status
            {
                #region-----------------Cheque Printing Status------------------
            string tempcbsel = "select * from CASHBOOK.TEMP_CB where VOUNO='" + vounum + "' and PRINT1=1";
            if (dm.existRecored(tempcbsel) != 0)
            {
                throw new Exception("Cheque already printed. Cannot be reversed!");
            }            
            #endregion
            }
            foreach (string vounum in vouindex)
            {
                string deletetempcb = "UPDATE CASHBOOK.TEMP_CB SET DELETED = '1',STATUS='Cancelled',CHQCAN='1',VOU_LEVEL='N' where VOUNO='" + vounum + "'";
                dm.insertRecords(deletetempcb);
                //string deletetempdetl = "delete from CASHBOOK.TEMP_DETL where VOUNO='" + vounum + "'";
                //dm.insertRecords(deletetempdetl);
                //string voubankdetdel = "delete from LPHS.VOUBANKDET where VOUCHERNO='" + vounum + "' and POLICYNO=" + polno + "";
                //dm.insertRecords(voubankdetdel);
            }
            //Periodic Paydet
            string periodicdel = "delete from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='DOC'";
            dm.insertRecords(periodicdel);
            //Childprotout
            string childprotdel = "delete from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + " and MOS='" + mos + "'";
            dm.insertRecords(childprotdel);

            #region//-------------Reversing SLIC Vouchers-------------------------------
            string slicvousel = "select SVVOUNO from LPHS.SLICVOUCHERS where SVPOL=" + polno + "";
            if (dm.existRecored(slicvousel) != 0)
            {
                string vou;
                dm.readSql(slicvousel);
                OracleDataReader slicvoureader = dm.oraComm.ExecuteReader();
                while (slicvoureader.Read())
                {
                    if (!slicvoureader.IsDBNull(0)) { vou = slicvoureader.GetString(0); } else { vou = ""; }

                    string tempcbdel = "UPDATE CASHBOOK.TEMP_CB SET DELETED = '1',STATUS='Cancelled',CHQCAN='1',VOU_LEVEL='N' where VOUNO='" + vou + "'";
                    dm.insertRecords(tempcbdel);
                    string tempdetldel = "delete from CASHBOOK.TEMP_DETL where VOUNO='" + vou + "'";
                    dm.insertRecords(tempdetldel);
                }
                slicvoureader.Close();
                string slicvoudel = "delete from LPHS.SLICVOUCHERS where SVPOL=" + polno + "";
                dm.insertRecords(slicvoudel);
            }
            #endregion

            dm.commit();
            dm.connclose();
            dmread.connclose();
            this.lblMessage.Visible = true;
            this.btnSubmit.Enabled = false;
        }
        catch(Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            dmread.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
}
