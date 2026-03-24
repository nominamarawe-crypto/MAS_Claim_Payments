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

public partial class Sundryrcpt002 : System.Web.UI.Page
{
    private long Polno;
    private int pol;
    private string mos;
    private long Clmno;
    private double ageamt;
    private double AgeDiffInt;
    private int commdate;
    private int tble;
    public int term;
    private int pacode;
    private int agt;
    private int org;
    private int serbr;
    private double prm;
    private string polst;
    private int mode;
    string selqry;
    private int totinstlmnts;
    private double singlprmdiff;
    private double remnprmdiff;
    private double yrlyprm;
    private int dueyr;
    private int duemnth;
    private int nextdueyr;
    private int nextduemn;
    private int nextduelstyr;
    private int nextduelstmn;
    private int fstyrdueyr;
    private int fstyrduemn;
    private int fstyrdueyrend;
    private int fstyrduemnend;
    private int lstyrdueyrend;
    private int lstyrduemnend;
    private ArrayList Prms1;
    private ArrayList Prms2;
    private string name;
    public int dthdate;
    private int paiddue;
    private int paidduemnth;
    private int paidduedays;
    private string entEPF;
    private int BRN;
    DataManager dm;
    private bool isfirst;
    private int pdyrs;
    private int maxPaidDate;
    private int maxLedgerDue;
    protected void Page_Load(object sender, EventArgs e)
    {
        dm = new DataManager();
        if (Session["EPFNum"] != null)
        {
            entEPF = Session["EPFNum"].ToString();
            hdfepf.Value = entEPF;
            BRN = Convert.ToInt32(Session["brcode"]);
            hdfbrn.Value = BRN.ToString();
        }
        else
        {
            EPage.Messege = "Session Expired.Please log to the system again...";
            Response.Redirect("EPage.aspx");
        }
        if(!IsPostBack)
        {
            if (PreviousPage != null)
            {
               
                Polno = PreviousPage.POLNO;
                mos = PreviousPage.mos;
                hdfmos.Value = mos;
                pol = int.Parse(Polno.ToString());
                polMasRead policyread = new polMasRead(pol, dm);   
                #region Get Claim Details
                string seldthref = "select DRCLMNO,DRAGEADMIT,AGE_AMT,AGEDIFINRST from lphs.dthref where DRPOLNO=" + Polno + " and DRMOS='" + mos + "'";
                if (dm.existRecored(seldthref) != 0)
                {
                    dm.readSql(seldthref);
                    OracleDataReader red = dm.oraComm.ExecuteReader();
                    while (red.Read())
                    {
                        if (!red.IsDBNull(0)) { Clmno = red.GetInt32(0); } else { Clmno = 0; }
                        if (!red.IsDBNull(2)) { ageamt = red.GetDouble(2); } else { ageamt = 0.0; }
                        if (!red.IsDBNull(2)) { AgeDiffInt = red.GetDouble(3); } else { AgeDiffInt = 0.0; }
                        litAgediffInt.Text = AgeDiffInt.ToString("N2");
                    }
                    red.Close();

                }
                #endregion

                #region Get Policy Details
                commdate = policyread.COM;
                tble = policyread.TBL;
                term = policyread.TRM;
                pacode = policyread.PAC;
                agt = policyread.AGT;
                org = policyread.ORG;
                serbr = policyread.OBR;
                prm = policyread.PRM;
                mode = policyread.MOD;

                #endregion

                #region checkprmst
                selqry = "select * from lphs.premast where pmpol=" + Polno + "";
                if (dm.existRecored(selqry) != 0)
                {
                    polst = "Inforce";
                }
                else
                {
                    string statusofpol = "";
                    string selstatusqry = "select PHSTA from lphs.lpolhis where phpol=" + Polno + "";
                    dm.readSql(selstatusqry);
                    OracleDataReader drred = dm.oraComm.ExecuteReader();
                    while (drred.Read())
                    {
                        if (!drred.IsDBNull(0)) { statusofpol = drred.GetString(0); } else { statusofpol = ""; }

                    }
                    drred.Close();
                    if (statusofpol == "I")
                    {
                        polst = "Inforce";
                    }
                    else
                    {
                        polst = "Lapse";
                    }
                }
                #endregion

                #region Read phname

                selqry = "select PNSTA|| ' ' ||PNINT|| ' ' ||PNSUR from lphs.phname where pnpol=" + Polno + "";
                if (dm.existRecored(selqry) != 0)
                {
                    #region Get Data From PHNAME
                    dm.readSql(selqry);
                    OracleDataReader read = dm.oraComm.ExecuteReader();
                    while (read.Read())
                    {
                        if (!read.IsDBNull(0)) { litnm.Text = read.GetString(0).Trim(); }
                    }
                    name = litnm.Text;
                    read.Close();
                    #endregion
                }
                #endregion

                #region Get Death Date
                string getdthdt = "select DDTOFDTH from lphs.dthint where DPOLNO=" + Polno + " and DMOS='"+mos+"'";
                if (dm.existRecored(getdthdt) != 0)
                {
                    dm.readSql(getdthdt);
                    OracleDataReader red1 = dm.oraComm.ExecuteReader();
                    while (red1.Read())
                    {
                        if (!red1.IsDBNull(0)) { dthdate = red1.GetInt32(0); } else { dthdate = 0; }
                    }
                    red1.Close();
                }
                #endregion

                #region Task 26992
                string getLegerMax = "select  max(LLDUE) from LCLM.LEDGER where LLPOL=" + Polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldat<=" + dthdate + "";
                if (dm.existRecored(getLegerMax) != 0)
                {
                    dm.readSql(getLegerMax);
                    OracleDataReader red1 = dm.oraComm.ExecuteReader();
                    while (red1.Read())
                    {
                        if (!red1.IsDBNull(0)) { maxLedgerDue = red1.GetInt32(0); } else { maxLedgerDue = 0; }
                    }
                    red1.Close();
                }

                if (maxLedgerDue > 0)
                {
                    int x;
                    switch (mode)
                    {
                        case 1: x = 12; break;
                        case 2: x = 6; break;
                        case 3: x = 3; break;
                        default: x = 1; break;
                    }
                    General gg = new General();
                    maxPaidDate = int.Parse(maxLedgerDue + commdate.ToString().Substring(6, 2));
                    maxPaidDate = gg.DateAdjust(maxPaidDate, 0, x, 0);
                }
                #endregion

                #region Calc paid years
                //paiddue = this.dateComparison(commdate, dthdate)[0];
                //paidduemnth = this.dateComparison(commdate, dthdate)[1];
                //paidduedays = this.dateComparison(commdate, dthdate)[2];
                paiddue = this.dateComparison(commdate, maxPaidDate)[0];
                paidduemnth = this.dateComparison(commdate, maxPaidDate)[1];
                paidduedays = this.dateComparison(commdate, maxPaidDate)[2];
                //if (paidduemnth > 1)
                //if (paidduemnth >= 1)
                if (paidduemnth > 0)
                {
                    pdyrs = paiddue + 1;
                }
                else
                {
                    pdyrs = paiddue; 
                }
                #endregion

                #region Calculate premium diff
                if (mode == 4)
                {
                    totinstlmnts = pdyrs * 12;
                    singlprmdiff = (ageamt / totinstlmnts);
                    remnprmdiff = singlprmdiff * 11;
                }
                else if (mode == 3)
                {
                    totinstlmnts = pdyrs * 4;
                    singlprmdiff = (ageamt / totinstlmnts);
                    remnprmdiff = singlprmdiff * 3;
                }
                else if (mode == 2)
                {
                    totinstlmnts = pdyrs * 2;
                    singlprmdiff = (ageamt / totinstlmnts);
                    remnprmdiff = singlprmdiff;
                }
                else
                {
                    totinstlmnts = pdyrs;
                    singlprmdiff = (ageamt / totinstlmnts);
                }
                #endregion

                #region Craete Dues
                dueyr = int.Parse(commdate.ToString().Substring(0, 4));
                duemnth = int.Parse(commdate.ToString().Substring(4, 2));
                if (mode == 4)
                {
                    nextduemn = duemnth + 1;
                    if (nextduemn > 12)
                    {
                        nextdueyr = dueyr + 1;
                        nextduemn = nextduemn - 12;
                    }
                    else
                    {
                        nextdueyr = dueyr;
                    }
                    nextduelstmn = nextduemn + 10;
                    if (nextduelstmn > 12)
                    {
                        nextduelstyr = nextdueyr + 1;
                        nextduelstmn = nextduelstmn - 12;
                    }
                    else
                    {
                        nextduelstyr = nextdueyr;
                    }
                }
                else if (mode == 3)
                {
                    nextduemn = duemnth + 3;
                    if (nextduemn > 12)
                    {
                        nextdueyr = dueyr + 1;
                        nextduemn = nextduemn - 12;
                    }
                    else
                    {
                        nextdueyr = dueyr;
                    }
                    //nextduelstmn = nextduelstmn + 8;
                    nextduelstmn = nextduemn + 8;
                    if (nextduelstmn > 12)
                    {
                        nextduelstyr = nextdueyr + 1;
                        nextduelstmn = nextduelstmn - 12;
                    }
                    else
                    {
                        nextduelstyr = nextdueyr;
                    }
                }
                else if (mode == 2)
                {
                    nextduemn = duemnth + 6;
                    if (nextduemn > 12)
                    {
                        nextdueyr = dueyr + 1;
                        nextduemn = nextduemn - 12;
                    }
                    else
                    {
                        nextdueyr = dueyr;
                    }
                    //nextduelstmn = nextduelstmn + 5;
                    nextduelstmn = nextduemn + 5;
                    if (nextduelstmn > 12)
                    {
                        nextduelstyr = nextdueyr + 1;
                        nextduelstmn = nextduelstmn - 12;
                    }
                    else
                    {
                        nextduelstyr = nextdueyr;
                    }
                }
                else
                {
                    nextduemn = duemnth + 12;
                    if (nextduemn > 12)
                    {
                        nextdueyr = dueyr + 1;
                        nextduemn = nextduemn - 12;
                    }
                    else
                    {
                        nextdueyr = dueyr;
                    }

                    nextduelstmn = nextduemn + 12;
                    if (nextduelstmn > 12)
                    {
                        nextduelstyr = nextdueyr + 1;
                        nextduelstmn = nextduelstmn - 12;
                    }
                    else
                    {
                        nextduelstyr = nextdueyr;
                    }
                }

                #endregion

                #region Assign values
                litpol.Text = Polno.ToString();
                litclm.Text = Clmno.ToString();
                litagedfamt.Text = ageamt.ToString();
                litcomdt.Text = commdate.ToString().Substring(0, 4) + "/" + commdate.ToString().Substring(4, 2) + "/" + commdate.ToString().Substring(6, 2);
                littbtr.Text = tble.ToString() + "/" + term.ToString();
                litprm.Text = prm.ToString("N2");
                litpolst.Text = polst;
                litpymd.Text = mode.ToString();
                Txtdiffsinprm.Text = singlprmdiff.ToString("N2");
                Txtremprm.Text = remnprmdiff.ToString("N2");
                if (duemnth.ToString().Length != 2)
                {
                    litdueyrmn.Text = dueyr.ToString() + "/ 0" + duemnth.ToString();
                }
                else
                {
                    litdueyrmn.Text = dueyr.ToString() + duemnth.ToString();
                }
                if (nextduemn.ToString().Length != 2)
                {
                    litnxtdue.Text = nextdueyr.ToString() + "/ 0" + nextduemn.ToString() + " TO " + nextduelstyr.ToString() + "/" + nextduelstmn.ToString();
                }
                else
                {
                    litnxtdue.Text = nextdueyr.ToString() + "/" + nextduemn.ToString() + " TO " + nextduelstyr.ToString() + "/" + nextduelstmn.ToString();
                }


                #endregion
                                
                isfirst = true;
                CreateDynamicTable(isfirst);
            }

        }
        else
        {
            Session["EPFNum"] = hdfepf.Value;
            Session["brcode"] = hdfbrn.Value;
            Polno = int.Parse(litpol.Text);
            mos = hdfmos.Value;
            polMasRead policyread = new polMasRead(int.Parse(Polno.ToString()), dm);  

            #region Get Claim Details
            string seldthref = "select DRCLMNO,DRAGEADMIT,AGE_AMT from lphs.dthref where DRPOLNO=" + Polno + " and DRMOS='" + mos + "'";
            if (dm.existRecored(seldthref) != 0)
            {
                dm.readSql(seldthref);
                OracleDataReader red = dm.oraComm.ExecuteReader();
                while (red.Read())
                {
                    if (!red.IsDBNull(0)) { Clmno = red.GetInt32(0); } else { Clmno = 0; }
                    if (!red.IsDBNull(2)) { ageamt = red.GetDouble(2); } else { ageamt = 0.0; }

                }
                red.Close();

            }
            #endregion

            #region Get Policy Details
            commdate = policyread.COM;
            tble = policyread.TBL;
            term = policyread.TRM;
            pacode = policyread.PAC;
            agt = policyread.AGT;
            org = policyread.ORG;
            serbr = policyread.OBR;
            prm = policyread.PRM;
            mode = policyread.MOD;
            AgeDiffInt = double.Parse(litAgediffInt.Text);
            #endregion

            #region checkprmst
            selqry = "select * from lphs.premast where pmpol=" + Polno + "";
            if (dm.existRecored(selqry) != 0)
            {
                polst = "Inforce";
            }
            else
            {
                polst = "Lapse";
            }
            #endregion

            #region Read phname

            selqry = "select PNSTA|| ' ' ||PNINT|| ' ' ||PNSUR from lphs.phname where pnpol=" + Polno + "";
            if (dm.existRecored(selqry) != 0)
            {
                #region Get Data From PHNAME
                dm.readSql(selqry);
                OracleDataReader read = dm.oraComm.ExecuteReader();
                while (read.Read())
                {
                    if (!read.IsDBNull(0)) { litnm.Text = read.GetString(0).Trim(); }
                }
                name = litnm.Text;
                read.Close();
                #endregion
            }
            #endregion

            #region Get Death Date
            string getdthdt = "select DDTOFDTH from lphs.dthint where DPOLNO=" + Polno + " and DMOS='" + mos + "'";
            if (dm.existRecored(getdthdt) != 0)
            {
                dm.readSql(getdthdt);
                OracleDataReader red1 = dm.oraComm.ExecuteReader();
                while (red1.Read())
                {
                    if (!red1.IsDBNull(0)) { dthdate = red1.GetInt32(0); } else { dthdate = 0; }
                }
                red1.Close();
            }
            #endregion

            #region Task 26992
            string getLegerMax = "select  max(LLDUE) from LCLM.LEDGER where LLPOL=" + Polno + " and (lltyp = 1 or lltyp = 2 or lltyp = 3) and lldat<=" + dthdate + "";
            if (dm.existRecored(getLegerMax) != 0)
            {
                dm.readSql(getLegerMax);
                OracleDataReader red1 = dm.oraComm.ExecuteReader();
                while (red1.Read())
                {
                    if (!red1.IsDBNull(0)) { maxLedgerDue = red1.GetInt32(0); } else { maxLedgerDue = 0; }
                }
                red1.Close();
            }

            if (maxLedgerDue > 0)
            {
                int x;
                switch (mode)
                {
                    case 1: x = 12; break;
                    case 2: x = 6; break;
                    case 3: x = 3; break;
                    default: x = 1; break;
                }
                General gg = new General();
                maxPaidDate = int.Parse(maxLedgerDue + commdate.ToString().Substring(6, 2));
                maxPaidDate = gg.DateAdjust(maxPaidDate, 0, x, 0);
            }
            #endregion

            #region Calc paid years
            //paiddue = this.dateComparison(commdate, dthdate)[0];
            //paidduemnth = this.dateComparison(commdate, dthdate)[1];
            //paidduedays = this.dateComparison(commdate, dthdate)[2];
            paiddue = this.dateComparison(commdate, maxPaidDate)[0];
            paidduemnth = this.dateComparison(commdate, maxPaidDate)[1];
            paidduedays = this.dateComparison(commdate, maxPaidDate)[2];
            //if (paidduemnth > 1)
            //if (paidduemnth >= 1)
            if (paidduemnth > 0)
            {
                pdyrs = paiddue + 1;
            }
            else
            { 
                pdyrs = paiddue; 
            }
            #endregion

            #region Calculate premium diff
            if (mode == 4)
            {
                totinstlmnts = pdyrs * 12;
                singlprmdiff = (ageamt / totinstlmnts);
                remnprmdiff = singlprmdiff * 11;
            }
            else if (mode == 3)
            {
                totinstlmnts = pdyrs * 4;
                singlprmdiff = (ageamt / totinstlmnts);
                remnprmdiff = singlprmdiff * 3;
            }
            else if (mode == 2)
            {
                totinstlmnts = pdyrs * 2;
                singlprmdiff = (ageamt / totinstlmnts);
                remnprmdiff = singlprmdiff;
            }
            else
            {
                totinstlmnts = pdyrs;
                singlprmdiff = (ageamt / totinstlmnts);
            }
            #endregion

            #region Craete Dues
            dueyr = int.Parse(commdate.ToString().Substring(0, 4));
            duemnth = int.Parse(commdate.ToString().Substring(4, 2));
            if (mode == 4)
            {
                nextduemn = duemnth + 1;
                if (nextduemn > 12)
                {
                    nextdueyr = dueyr + 1;
                    nextduemn = nextduemn - 12;
                }
                else
                {
                    nextdueyr = dueyr;
                }
                nextduelstmn = nextduemn + 10;
                if (nextduelstmn > 12)
                {
                    nextduelstyr = nextdueyr + 1;
                    nextduelstmn = nextduelstmn - 12;
                }
                else
                {
                    nextduelstyr = nextdueyr;
                }
            }
            else if (mode == 3)
            {
                nextduemn = duemnth + 3;
                if (nextduemn > 12)
                {
                    nextdueyr = dueyr + 1;
                    nextduemn = nextduemn - 12;
                }
                else
                {
                    nextdueyr = dueyr;
                }
                //nextduelstmn = nextduelstmn + 8;
                nextduelstmn = nextduemn + 8;
                if (nextduelstmn > 12)
                {
                    nextduelstyr = nextdueyr + 1;
                    nextduelstmn = nextduelstmn - 12;
                }
                else
                {
                    nextduelstyr = nextdueyr;
                }
            }
            else if (mode == 2)
            {
                nextduemn = duemnth + 6;
                if (nextduemn > 12)
                {
                    nextdueyr = dueyr + 1;
                    nextduemn = nextduemn - 12;
                }
                else
                {
                    nextdueyr = dueyr;
                }
                //nextduelstmn = nextduelstmn + 5;
                nextduelstmn = nextduemn + 5;
                if (nextduelstmn > 12)
                {
                    nextduelstyr = nextdueyr + 1;
                    nextduelstmn = nextduelstmn - 12;
                }
                else
                {
                    nextduelstyr = nextdueyr;
                }
            }
            else
            {
                nextduemn = duemnth + 12;
                if (nextduemn > 12)
                {
                    nextdueyr = dueyr + 1;
                    nextduemn = nextduemn - 12;
                }
                else
                {
                    nextdueyr = dueyr;
                }

                nextduelstmn = nextduemn + 12;
                if (nextduelstmn > 12)
                {
                    nextduelstyr = nextdueyr + 1;
                    nextduelstmn = nextduelstmn - 12;
                }
                else
                {
                    nextduelstyr = nextdueyr;
                }
            }

            #endregion

            #region Assign values
            litpol.Text = Polno.ToString();
            litclm.Text = Clmno.ToString();
            litagedfamt.Text = ageamt.ToString();
            litcomdt.Text = commdate.ToString().Substring(0, 4) + "/" + commdate.ToString().Substring(4, 2) + "/" + commdate.ToString().Substring(6, 2);
            littbtr.Text = tble.ToString() + "/" + term.ToString();
            litprm.Text = prm.ToString("N2");
            litpolst.Text = polst;
            litpymd.Text = mode.ToString();
            Txtdiffsinprm.Text = singlprmdiff.ToString("N2");
            Txtremprm.Text = remnprmdiff.ToString("N2");
            if (duemnth.ToString().Length != 2)
            {
                litdueyrmn.Text = dueyr.ToString() + "/ 0" + duemnth.ToString();
            }
            else
            {
                litdueyrmn.Text = dueyr.ToString() + duemnth.ToString();
            }
            if (nextduemn.ToString().Length != 2)
            {
                litnxtdue.Text = nextdueyr.ToString() + "/ 0" + nextduemn.ToString() + " TO " + nextduelstyr.ToString() + "/" + nextduelstmn.ToString();
            }
            else
            {
                litnxtdue.Text = nextdueyr.ToString() + "/" + nextduemn.ToString() + " TO " + nextduelstyr.ToString() + "/" + nextduelstmn.ToString();
            }


            #endregion
            
            isfirst = false;
            CreateDynamicTable(isfirst);
        }        
    }

    #region Create Dynamc Table
    
    private void CreateDynamicTable(bool first)
    {
        dueyr = int.Parse( commdate.ToString().Substring(0, 4));
        duemnth = int.Parse(commdate.ToString().Substring(4, 2));

        #region Calculate Yearly Premiums

        if (mode == 4)
        {
            yrlyprm = singlprmdiff * 12;
        }
        if (mode == 3)
        {
            yrlyprm = singlprmdiff * 4;
        }
        if (mode == 2)
        {
            yrlyprm = singlprmdiff * 2;
        }
        if (mode == 1)
        {
            yrlyprm = singlprmdiff;
        }
        #endregion

        // Fetch the number of Rows and Columns for the table   
        // using the properties  
        int i=1;
        fstyrdueyr = dueyr ;
        // Now iterate through the table and add your controls   
        //for (int count = 1; count <= paiddue; count++)
        //for (int count = 1; count < paiddue; count++)
        for (int count = 1; count <= pdyrs; count++)
        {
                 fstyrdueyr = fstyrdueyr + 1;
                fstyrduemn = duemnth;
                

                TableRow tr = new TableRow();
                //if (i <= paiddue )
                //if (i < paiddue)
                if (i <= pdyrs)
                {                    

                    TableCell tc2 = new TableCell();
                    Label lbl = new Label();
                    lbl.ID = "lbl" + i.ToString();
                    if (fstyrduemn.ToString().Length != 2)
                    {
                        lbl.Text = fstyrdueyr.ToString() + "/ 0" + fstyrduemn.ToString();
                    }
                    else
                    {
                        lbl.Text = fstyrdueyr.ToString() + "/" + fstyrduemn.ToString();
                    }

                    TableCell tc = new TableCell();
                    TextBox txtBox = new TextBox();
                    txtBox.ID = "txt" + i.ToString();
                    txtBox.Text = yrlyprm.ToString("N2");
                    txtBox.Enabled = false;
                   
                    txtBox.Attributes.Add("onblur", "chkNumeric(" + txtBox.ID + ",'.')");

                    CheckBox chk = new CheckBox();
                    chk.ID = "chk" + i.ToString();
                    chk.Attributes.Add("onclick", "checkbx("+txtBox.ID+",this)");
                    // Add the control to the TableCell  
                    tc2.Controls.Add(lbl);
                    tc.Controls.Add(txtBox);
                    tc.Controls.Add(chk);
                    // Add the TableCell to the TableRow  
                    tr.Cells.Add(tc2);
                    tr.Cells.Add(tc);

                }
                i++;
                fstyrdueyr = fstyrdueyr + 1;
                fstyrduemn = duemnth;
                //if (i <= paiddue)
                //if (i < paiddue)
                if (i <= pdyrs)
                {   
                    TableCell tc3 = new TableCell();
                    Label lbl_ = new Label();
                    lbl_.ID = "lbl_" + i.ToString();
                    if (fstyrduemn.ToString().Length != 2)
                    {
                        lbl_.Text = fstyrdueyr.ToString() + "/ 0" + fstyrduemn.ToString();
                    }
                    else
                    {
                        lbl_.Text = fstyrdueyr.ToString() + "/" + fstyrduemn.ToString();
                    }

                    TableCell tc1 = new TableCell();
                    TextBox txtBox_ = new TextBox();
                    txtBox_.ID = "txt_" + i.ToString();
                    txtBox_.Text = yrlyprm.ToString("N2");
                    txtBox_.Enabled = false;
                    
                    txtBox_.Attributes.Add("onblur", "chkNumeric(" + txtBox_.ID + ",'.')");

                    CheckBox chk_ = new CheckBox();
                    chk_.ID = "chk_" + i.ToString();
                    chk_.Attributes.Add("onclick", "checkbx(" + txtBox_.ID + ",this)");
                    // Add the control to the TableCell 
                    tc3.Controls.Add(lbl_);
                    tc1.Controls.Add(txtBox_);
                    tc1.Controls.Add(chk_);
                    // Add the TableCell to the TableRow  
                    tr.Cells.Add(tc3);
                    tr.Cells.Add(tc1);

                }
                i++;        
           
                Table1.Rows.Add(tr);
            
            Table1.EnableViewState = true;
            ViewState["Table1"] = true;
        } 
    }
    #endregion

    #region Submit Data
   
    protected void Btn_sub_Click(object sender, EventArgs e)
    {
        double tot = 0.0;
        double fulltot=0.0;
        Prms1=new ArrayList();
        Prms2 = new ArrayList();
        pol = int.Parse(litpol.Text);
        dm = new DataManager();
        int j = 1;
        polMasRead policyread1 = new polMasRead(pol, dm);
        term = policyread1.TRM;
        //for (int i = 1; i <= (paiddue+1); i++)
        for (int i = 1; i < (paiddue + 1); i++)
        //for (int i = 1; i <= (pdyrs + 1); i++)
        {
            //if ((i <= paiddue) && (j % 2 == 1))
            if ((i <= paiddue) && (j % 2 == 1))
            //if ((i <= pdyrs) && (j % 2 == 1))
            {
                TextBox txtname1 = new TextBox();
                txtname1 = (TextBox)Table1.FindControl("txt" + i.ToString());
                if (txtname1.Text != null)
                {
                    Prms1.Add(txtname1.Text);
                    tot=double.Parse(txtname1.Text);
                    fulltot = fulltot + tot;
                }
            }

            //if ((i <= paiddue) && (j % 2 == 0))
            if ((i < paiddue) && (j % 2 == 0))
            {
                TextBox txtname2 = new TextBox();
                txtname2 = (TextBox)Table1.FindControl("txt_" + i.ToString());
                if (txtname2.Text != null)
                {
                    Prms2.Add(txtname2.Text);
                    tot = double.Parse(txtname2.Text);
                    fulltot = fulltot + tot;
                }
            }
            j=i+1;            
        }
        fulltot = fulltot+singlprmdiff + remnprmdiff;
        double diff = 0;
        diff =  double.Parse(ageamt.ToString("N2")) -double.Parse(fulltot.ToString("N2"));
        if (diff > 0.0)
        {   
            lblerr.Text = "Age amount is Greater than Total of Yearly Premium Differences...Rs."+(diff.ToString("N2"));
        }
        else if (diff < 0.0)
        {
            lblerr.Text = "Age amount is Less than Total of Yearly Premium Differences...Rs." + (diff.ToString("N2"));
        }
        else
        {
            //Server.Transfer("SundryPrint003.aspx");
        }
    }
    #endregion

    public ArrayList PRMS1
    {
        get { return Prms1; }
        set { Prms1 = value; }
    }
    public ArrayList PRMS2
    {
        get { return Prms2; }
        set { Prms2 = value; }
    }
    public long pol_no
    {
        get { return Polno; }
        set { Polno = value; }
    }
    public long CLMNO
    {
        get { return Clmno; }
        set { Clmno = value; }
    }
    public double AGEAMT
    {
        get { return ageamt; }
        set { ageamt = value; }
    }
    public double AGEDIFAMT
    {
        get { return AgeDiffInt; }
        set { AgeDiffInt = value; }
    }
    public int COMMDT
    {
        get { return commdate; }
        set { commdate = value; }
    }
    public string  Polst
    {
        get { return polst; }
        set { polst = value; }
    }
    public string NAME
    {
        get { return name; }
        set { name = value; }
    }
    public int NEXTDUYR
    {
        get { return nextdueyr; }
        set { nextdueyr = value; }
    }
    public int NEXTDUMN
    {
        get { return nextduemn; }
        set { nextduemn = value; }
    }
    public int NEXTDULSYR
    {
        get { return nextduelstyr; }
        set { nextduelstyr = value; }
    }
    public int NEXTDULSMN
    {
        get { return nextduelstmn; }
        set { nextduelstmn = value; }
    }
    public double SINGLEPRM
    {
        get { return singlprmdiff; }
        set { singlprmdiff = value; }
    }
    public double REMPRMS
    {
        get { return remnprmdiff; }
        set { remnprmdiff = value; }
    }
    public int PDDUE
    {
        get { return paiddue; }
        set { paiddue = value; }
    } 
    public int PDDUEMN
    {
        get { return paidduemnth; }
        set { paidduemnth = value; }
    }
    public int PDDUEDAYS
    {
        get { return paidduedays; }
        set { paidduedays = value; }
    }

    #region Date Comparison
    public int[] dateComparison(int startdate, int enddate)
    {
        //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;

    }

    #endregion
}
