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

public partial class PolReStat002 : System.Web.UI.Page
{
    private int polnum;
    private int dthdat;
    private string oldstat;
    int ComDat;
    int Table;
    int Term;
    int Mode;
    int NextEffDat;
    int PACod;
    int AgntCod;
    int OrgCod;
    int BrCod;
    int OriBrn;
    double Prm;
    double SumAss;
    string phname;
    string ad1;
    string ad2;
    string ad3;
    string ad4;
    string newstat;


    DataManager dm = new DataManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)
        {
            polnum = this.PreviousPage.PolNum;
            dthdat = this.PreviousPage.DeathDate;
            oldstat = ((HiddenField)PreviousPage.FindControl("hdstat")).Value.ToString();
            hdstat.Value = oldstat;
        }
        if (!Page.IsPostBack)
        {
            this.litDOD.Text = dthdat.ToString();
            this.litPolNum.Text = polnum.ToString();
            if (oldstat != "NO")
            {

                ReadTables data = new ReadTables(polnum, oldstat, dm);
                litCstat.Text = data.Status;
                txtComDat.Text = data.ComDat.ToString();
                txtMatDat.Text = data.MatDat.ToString();
                txtTbl.Text = data.Table.ToString();
                txtTrm.Text = data.Term.ToString();
                txtSumAss.Text = data.SumAss.ToString();
                txtMod.Text = data.Mode.ToString();
                txtPrm.Text = data.Prem.ToString();
                txtNEdat.Text = data.Due.ToString();
                txtPAcod.Text = data.PACod.ToString();
                txtAgCod.Text = data.AgtCod.ToString();
                txtOrCod.Text = data.OrgCod.ToString();
                txtBrCod.Text = data.SBranch.ToString();
                txtOrBrn.Text = data.OriBrn.ToString();

                #region Name and Address...........
                string sql = "select  pnsta, pnint, PNSUR, pnad1, pnad2, pnad3, pnad4  from LPHS.PHNAME where pnpol='" + polnum + "'";
                if (dm.existRecored(sql) != 0)
                {
                    dm.readSql(sql);
                    OracleDataReader oraDtReader = dm.oraComm.ExecuteReader();
                    while (oraDtReader.Read())
                    {
                        if ((!oraDtReader.IsDBNull(0)) && (!oraDtReader.IsDBNull(1)) && (!oraDtReader.IsDBNull(2)))
                        {
                            phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                        }
                        else { phname = ""; }

                        if (!oraDtReader.IsDBNull(3)) { ad1 = (oraDtReader.GetString(3)); } else { ad1 = ""; }
                        if (!oraDtReader.IsDBNull(4)) { ad2 = (oraDtReader.GetString(4)); } else { ad2 = ""; }
                        if (!oraDtReader.IsDBNull(5)) { ad3 = (oraDtReader.GetString(5)); } else { ad3 = ""; }
                        if (!oraDtReader.IsDBNull(6)) { ad4 = (oraDtReader.GetString(6)); } else { ad4 = ""; }
                    }
                    oraDtReader.Read();
                }
                
                litName.Text = phname;
                litAdd1.Text = ad1;
                litAdd2.Text = ad2;
                litAdd3.Text = ad3;
                litAdd4.Text = ad4;

                #endregion
            }
            else
            {
                litCstat.Text = "Policy Not Found";
            }
            
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStat.SelectedValue == "NO")
            {
                throw new Exception("Please Select Policy State.");
            }
            oldstat = hdstat.Value;
            newstat = ddlStat.SelectedValue;
            polnum = int.Parse(litPolNum.Text);
            if (txtComDat.Text != null) { ComDat = int.Parse(txtComDat.Text); }
            if (txtTbl.Text != null) { Table = int.Parse(txtTbl.Text); }
            if (txtTrm.Text != null) { Term = int.Parse(txtTrm.Text); }
            if (txtMod.Text != null) { Mode = int.Parse(txtMod.Text); }
            if (txtNEdat.Text != null) { NextEffDat = int.Parse(txtNEdat.Text); }
            if (txtPAcod.Text != null) { PACod = int.Parse(txtPAcod.Text); }
            if (txtAgCod.Text != null) { AgntCod = int.Parse(txtAgCod.Text); }
            if (txtOrCod.Text != null) { OrgCod = int.Parse(txtOrCod.Text); }
            if (txtBrCod.Text != null) { BrCod = int.Parse(txtBrCod.Text); }
            if (txtPrm.Text != null) { Prm = double.Parse(txtPrm.Text); }
            if (txtSumAss.Text != null) { SumAss = double.Parse(txtSumAss.Text); }
            if (txtOrBrn.Text != null) { OriBrn = int.Parse(txtOrBrn.Text); }

            dm.begintransaction();
            dm.oraComm.Connection = dm.oraConn;
            dm.oraComm.CommandType = CommandType.StoredProcedure;
            dm.oraComm.CommandText = "LPHS.DEATH_CLAIM.POLRESTATE";
            dm.oraComm.Parameters.Clear();
            dm.oraComm.Parameters.AddWithValue("polnum", polnum);
            dm.oraComm.Parameters.AddWithValue("comdate", ComDat);
            dm.oraComm.Parameters.AddWithValue("tbl", Table);
            dm.oraComm.Parameters.AddWithValue("trm", Term);
            dm.oraComm.Parameters.AddWithValue("sumass", SumAss);
            dm.oraComm.Parameters.AddWithValue("pmod", Mode);
            dm.oraComm.Parameters.AddWithValue("prm",Prm );
            dm.oraComm.Parameters.AddWithValue("pacod", PACod);
            dm.oraComm.Parameters.AddWithValue("exdue", NextEffDat);
            dm.oraComm.Parameters.AddWithValue("agtcod", AgntCod);
            dm.oraComm.Parameters.AddWithValue("orgcod", OrgCod);
            dm.oraComm.Parameters.AddWithValue("brcod", BrCod);
            dm.oraComm.Parameters.AddWithValue("oribrn", OriBrn);
            dm.oraComm.Parameters.AddWithValue("oldstat", oldstat);
            dm.oraComm.Parameters.AddWithValue("newstate", newstat);
           
            dm.oraComm.ExecuteNonQuery();
            dm.oraComm.Parameters.Clear();
            dm.oraComm.Dispose();
            lblsuccess.Visible = true;
            btnsubmit.Enabled = false;
            btnreset.Enabled = false;
            
        }
        catch (Exception exp)
        {
            dm.connClose();
            EPage.Messege = exp.Message;
            Response.Redirect("EPage.aspx");
        }
    
    }
}
