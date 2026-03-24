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

public partial class PolCont002 : System.Web.UI.Page
{
    private long Polno;
    private string mos;
    DataManager dm;
    private string DNAme;
    private int deathdate;
    private int CommDate;
    private int Clmno;
    private int tble;
    private int trm;
    private int mode;
    private double prm;
    private int Dueyrmn;
    private int demDueyrmn;
    private double Dem_prm;
    private int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage!=null)
        {
            #region Get Prevois page Values and assign them
           
            Polno = PreviousPage.POLNO;
            mos = PreviousPage.mos;
            litpol.Text = Polno.ToString();

            if (mos=="M")
            {
               litliftype.Text ="Main Life";
            }
            else if (mos=="S")
            {
               litliftype.Text ="Spouse";
            }
            else if (mos=="2")
            {
               litliftype.Text ="Second Life";
            }
            else
            {
                litliftype.Text ="Child";
            }
               
            #endregion

            #region Enable Disable Txtboxes
            if (mos == "M")
            {
                txttbl.Enabled = true;
                txttrm.Enabled = true;
                txtmd.Enabled = true;
                txtcurrprm.Enabled = false;
                txtadjprm.Enabled = true;                
            }
            else if (mos == "S")
            {                
                txttbl.Enabled = false;
                txttrm.Enabled = false;
                txtmd.Enabled = false;
                txtcurrprm.Enabled = false;
                txtadjprm.Enabled = true;
            }
            #endregion
        }
        if (!IsPostBack)
        {
            dm = new DataManager();

            #region Read Lpolhis

            string Getpolhis = "select PHPOL,PHCOM,PHTBL,PHTRM,PHSUM,PHMOD,PHPRM,PHDUE,PHPAC " +
                             " from LPHS.LPOLHIS where PHPOL=" + Polno + " and PHMOS='" + mos + "' and PHTYP='D'  ";
            if (dm.existRecored(Getpolhis) != 0)
            {
                dm.readSql(Getpolhis);
                OracleDataReader red_1 = dm.oraComm.ExecuteReader();
                while (red_1.Read())
                {
                    if (!red_1.IsDBNull(1)) { CommDate = red_1.GetInt32(1); } else { CommDate = 0; }
                    if (!red_1.IsDBNull(2)) { tble = red_1.GetInt32(2); } else { tble = 0; }
                    if (!red_1.IsDBNull(3)) { trm = red_1.GetInt32(3); } else { trm = 0; }
                    if (!red_1.IsDBNull(5)) { mode = red_1.GetInt32(5); } else { mode = 0; }
                    if (!red_1.IsDBNull(6)) { prm = red_1.GetDouble(6); } else { prm = 0.0; }
                    if (!red_1.IsDBNull(7)) { Dueyrmn = red_1.GetInt32(7); } else { Dueyrmn = 0; }

                }
                red_1.Close();
            }
            #endregion

            #region Read DTHINT

            string GetdedName = "select DNOD,DDTOFDTH,DCLM from lphs.dthint where DPOLNO=" + Polno + " and DMOS='" + mos + "'";
            if (dm.existRecored(GetdedName) != 0)
            {
                dm.readSql(GetdedName);
                OracleDataReader red_2 = dm.oraComm.ExecuteReader();
                while (red_2.Read())
                {
                    if (!red_2.IsDBNull(0)) { DNAme = red_2.GetString(0); } else { DNAme = ""; }
                    if (!red_2.IsDBNull(1)) { deathdate = red_2.GetInt32(1); } else { deathdate = 0; }
                    if (!red_2.IsDBNull(2)) { Clmno = red_2.GetInt32(2); } else { Clmno = 0; }
                }
                red_2.Close();
            }
            #endregion

            #region Assign Values

            litnmdecs.Text = DNAme;
            litdthdt.Text = deathdate.ToString().Substring(0, 4) + "/" + deathdate.ToString().Substring(4, 2) + "/" + deathdate.ToString().Substring(6, 2);
            litclm.Text = Clmno.ToString();
            litcomdt.Text = CommDate.ToString().Substring(0, 4) + "/" + CommDate.ToString().Substring(4, 2) + "/" + CommDate.ToString().Substring(6, 2);
            txttbl.Text = tble.ToString();
            txttrm.Text = trm.ToString();
            txtmd.Text = mode.ToString();
            txtcurrprm.Text = prm.ToString("N2");
            txtadjprm.Text = "0.0";
            txtdueyrmn.Text = Dueyrmn.ToString();
            #endregion

            #region Display Existing Demands
            string GetDemands = "select PDDUE,PDPRM from lphs.demand where PDPOL=" + Polno + " ";//and PDCOD=1
            if (dm.existRecored(GetDemands) != 0)
            {
                dm.readSql(GetDemands);
                OracleDataReader red_3 = dm.oraComm.ExecuteReader();
                TableHeaderRow trhr = new TableHeaderRow();
                TableHeaderCell tcell1 = new TableHeaderCell();
                TableHeaderCell tcell2 = new TableHeaderCell();
                tcell1.Text = "Due YearMonth";
                tcell2.Text = "Premium";
                trhr.Controls.Add(tcell1);
                trhr.Controls.Add(tcell2);
                Table1.Controls.Add(trhr);

                while (red_3.Read())
                { 
                    if(!red_3.IsDBNull(0)){demDueyrmn=red_3.GetInt32(0);}else{demDueyrmn=0;}
                    if(!red_3.IsDBNull(1)){Dem_prm=red_3.GetDouble(1);}else{Dem_prm=0.0;}
                    i++;
                    CreateDynamicTable(i,demDueyrmn, Dem_prm);
                }
                red_3.Close();
            }
            #endregion
        }
        else
        {
            #region Assign Values
            
            Polno = int.Parse(litpol.Text);
            Clmno = int.Parse(litclm.Text);
            string[] com = litcomdt.Text.Split('/');
            CommDate = int.Parse(com[0].ToString() + com[1].ToString() + com[2].ToString());
            tble = int.Parse(txttbl.Text.Trim());
            trm = int.Parse(txttrm.Text.Trim());
            mode = int.Parse(txtmd.Text.Trim());
            prm = double.Parse(txtcurrprm.Text.Trim());

            #endregion

            #region Display Existing Demands
            string GetDemands = "select PDDUE,PDPRM from lphs.demand where PDPOL=" + Polno + " ";//and PDCOD=1
            if (dm.existRecored(GetDemands) != 0)
            {
                dm.readSql(GetDemands);
                OracleDataReader red_3 = dm.oraComm.ExecuteReader();
                TableHeaderRow trhr = new TableHeaderRow();
                TableHeaderCell tcell1 = new TableHeaderCell();
                TableHeaderCell tcell2 = new TableHeaderCell();
                tcell1.Text = "Due YearMonth";
                tcell2.Text = "Premium";
                trhr.Controls.Add(tcell1);
                trhr.Controls.Add(tcell2);
                Table1.Controls.Add(trhr);

                while (red_3.Read())
                {
                    if (!red_3.IsDBNull(0)) { demDueyrmn = red_3.GetInt32(0); } else { demDueyrmn = 0; }
                    if (!red_3.IsDBNull(1)) { Dem_prm = red_3.GetDouble(1); } else { Dem_prm = 0.0; }
                    i++;
                    CreateDynamicTable(i, demDueyrmn, Dem_prm);
                }
                red_3.Close();
            }
            #endregion
        }
        dm.connClose();
    }

    #region Create Dynamc Table

    private void CreateDynamicTable(int j,int dueyrmn,double prm)
    {

        // Fetch the number of Rows and Columns for the table   
        // using the properties 
        // Now iterate through the table and add your controls   
           
        TableRow tr = new TableRow();        
        TableCell tc = new TableCell();
        TableCell tc1 = new TableCell();

        TextBox txtBox = new TextBox();
        txtBox.ID = "txt" + j.ToString();
        txtBox.Text =Dueyrmn.ToString();
        txtBox.Width=75;

        TextBox txtBox_ = new TextBox();
        txtBox_.ID = "txt_" + j.ToString();
        txtBox_.Text = prm.ToString("N2");
        txtBox_.Width = 75;

         tc.Controls.Add(txtBox);
         tc1.Controls.Add(txtBox_);
         // Add the TableCell to the TableRow  
         tr.Cells.Add(tc);
         tr.Cells.Add(tc1);
         Table1.Rows.Add(tr);
         Table1.EnableViewState = true;
         ViewState["Table1"] = true;
       
    }
    #endregion
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
