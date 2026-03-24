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


public partial class payeedatachange003 : System.Web.UI.Page
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

    private long polno;
    private string MOS;
    private string disType;
    private string disability;
    private string intimno;
    private string phname;
    private string PAYEENAME;
    private string AD1;
    private string AD2;
    private string AD3;
    private string AD4;
    private string Bankname;
    private string BankBranch;
    private string Account;
    private string Slicacc;
    private string Clause;
    private int MOD, newmode;
    private int Table;
    private double PAYAMT;
    private string EPF;
    private int chngcount;

    DataManager dm;
    DissabilityTypesRead dtr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            EPF = "6664";
            if (Request.QueryString["polNo"] != null)
            {
                ViewState.Add("polnoQstr", int.Parse(Request.QueryString["polNo"]));
                polno = int.Parse(Request.QueryString["polNo"]);
            }
            if (Request.QueryString["mos"] != null)
            {
                ViewState.Add("mosQstr", Request.QueryString["mos"].ToString());
                MOS = Request.QueryString["mos"].ToString();
            }
            if (Request.QueryString["disType"] != null)
            {
                ViewState.Add("disTypeQstr", Request.QueryString["disType"].ToString());
                disType = Request.QueryString["disType"].ToString();
            }
            if (Request.QueryString["intimno"] != null)
            {
                ViewState.Add("intimnoQstr", Request.QueryString["intimno"].ToString());
                intimno = Request.QueryString["intimno"].ToString();
            }   
            this.ddlslicacctno.Items.Add(new ListItem("1030001487", "1030001487"));
            this.ddlslicacctno.Items.Add(new ListItem("1364403002", "1364403002"));
            this.ddlmode.Items.Add(new ListItem("Annually", "1"));
            this.ddlmode.Items.Add(new ListItem("Half Yearly", "2"));
            this.ddlmode.Items.Add(new ListItem("Quarterly", "3"));
            this.ddlmode.Items.Add(new ListItem("Monthly", "4"));
            try
            {
                dm = new DataManager();
                this.lblpolno.Text = polno.ToString();
                dtr = new DissabilityTypesRead();
                disability = dtr.GetDisabilityTypes(int.Parse(disType));
                this.lbldisType.Text = disability.ToString();
                this.lblintimNo.Text = intimno;
                if (MOS.Equals("M")) { this.lblmof.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lblmof.Text = "Spouse"; }
                else if (MOS.Equals("2")) { this.lblmof.Text = "Second Life"; }

                #region----------------Mode Change Read-----------------
                string modechngread = "select CHNGCOUNT, PAYNAME, AD1, AD2, AD3, AD4, PAYMODE, ACCTNO, SLICAC, BANKNAME, BANKBRANCH from LCLM.DISABILITY_MODE_CHNG where POLNO=" + polno + " and INTIMNO='" + intimno + "' and AUTH_DATE=0";
                if (dm.existRecored(modechngread) != 0)
                {
                    dm.readSql(modechngread);
                    OracleDataReader modechngreader = dm.oraComm.ExecuteReader();
                    while (modechngreader.Read())
                    {
                        if (!modechngreader.IsDBNull(0)) { chngcount = modechngreader.GetInt32(0); } else { chngcount = 0; }
                        if (!modechngreader.IsDBNull(1)) { PAYEENAME = modechngreader.GetString(1); } else { PAYEENAME = ""; }
                        if (!modechngreader.IsDBNull(2)) { AD1 = modechngreader.GetString(2); } else { AD1 = ""; }
                        if (!modechngreader.IsDBNull(3)) { AD2 = modechngreader.GetString(3); } else { AD2 = ""; }
                        if (!modechngreader.IsDBNull(4)) { AD3 = modechngreader.GetString(4); } else { AD3 = ""; }
                        if (!modechngreader.IsDBNull(5)) { AD4 = modechngreader.GetString(5); } else { AD4 = ""; }
                        if (!modechngreader.IsDBNull(6)) { newmode = modechngreader.GetInt32(6); } else { newmode = 0; }
                        if (!modechngreader.IsDBNull(7)) { Account = modechngreader.GetString(7); } else { Account = ""; }
                        if (!modechngreader.IsDBNull(8)) { Slicacc = modechngreader.GetString(8); } else { Slicacc = ""; }
                        if (!modechngreader.IsDBNull(9)) { Bankname = modechngreader.GetString(9); } else { Bankname = ""; }
                        if (!modechngreader.IsDBNull(10)) { BankBranch = modechngreader.GetString(10); } else { BankBranch = ""; }                    }
                }
                else
                {
                    throw new Exception("No Changes Found to Authorize!");
                }
                #endregion

                #region ----------Adjust Payamt-------
                //if (MOD == 1) { PAYAMT = PAYAMT / 12; }
                //else if (MOD == 2) { PAYAMT = PAYAMT / 6; }
                //else if (MOD == 3) { PAYAMT = PAYAMT / 3; }                    
                #endregion

                #region-----------premast------
                string premastsel = "select PMTBL, PMTRM from LPHS.PREMAST where PMPOL=" + polno + "";
                if (dm.existRecored(premastsel)!=0)
                {
                    dm.readSql(premastsel);
                    OracleDataReader premastread = dm.oraComm.ExecuteReader();
                    while (premastread.Read())
                    {
                        if (!premastread.IsDBNull(0)) { Table = premastread.GetInt32(0); } else { Table = 0; }
                    }
                }

                #endregion

                #region ------set values on the form---------
                this.txtpayeename.Text = PAYEENAME;
                this.txtad1.Text = AD1;
                this.txtad2.Text = AD2;
                this.txtad3.Text = AD3;
                this.txtad4.Text = AD4;
                this.txtbkname.Text = Bankname;
                this.txtbkbrnname.Text = BankBranch;
                this.txtcustAcct.Text = Account;
                this.ddlslicacctno.SelectedValue = Slicacc.ToString();
                this.ddlmode.SelectedValue = newmode.ToString();
                //if ((Table == 39) && (Clause == "64"))
                //{
                //    this.ddlmode.SelectedValue = "1";
                //    ddlmode.Enabled = false;
                //}
                #endregion                

                #region -*-*-*-*-*-*-*-*-*-View State-*-*-*-*-*-*-*-
                ViewState["polno"] = polno;
                ViewState["MOS"] = MOS;
                ViewState["disType"] = disType;
                ViewState["intimno"] = intimno;
                ViewState["disability"] = disability;
                ViewState["PAYAMT"] = PAYAMT;
                ViewState["MOD"] = MOD;
                ViewState["EPF"] = EPF;


                #endregion
                dm.connClose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }
            if (ViewState["disType"] != null) { disType = ViewState["disType"].ToString(); }
            if (ViewState["intimno"] != null) { intimno = ViewState["intimno"].ToString(); }
            if (ViewState["disability"] != null) { disability = ViewState["disability"].ToString(); }
            if (ViewState["PAYAMT"] != null) { PAYAMT = double.Parse (ViewState["PAYAMT"].ToString()); }
            if (ViewState["MOD"] != null) { MOD = int.Parse(ViewState["MOD"].ToString()); }
            if (ViewState["EPF"] != null) { EPF = ViewState["EPF"].ToString(); }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            AD1 = this.txtad1.Text;
            AD2 = this.txtad2.Text;
            AD3 = this.txtad3.Text;
            AD4 = this.txtad4.Text;
            Bankname = this.txtbkname.Text;
            BankBranch = this.txtbkbrnname.Text;
            Account = this.txtcustAcct.Text;
            Slicacc = this.ddlslicacctno.SelectedItem.Value;
            newmode = int.Parse (this.ddlmode.SelectedItem.Value);

            #region --------------Adjust Payamt------------------------
            //if (MOD == 1) { PAYAMT *= 12; }
            //else if (MOD == 2) { PAYAMT *= 6; }
            //else if (MOD == 3) { PAYAMT *= 3; }
            #endregion

            dm = new DataManager();
            dm.begintransaction();

            

            #region--------------Disability Mode Change---------

            int chngcount=0;
            string disabilitymodesel = "select max(CHGCOUNT) from LCLM.DISABILITY_MODE_CHNG where POLNO=" + polno + " and INTIMNO='"+intimno+"'";
            if (dm.existRecored(disabilitymodesel) != 0)
            {
                dm.readSql(disabilitymodesel);
                OracleDataReader disamodereader = dm.oraComm.ExecuteReader();
                while (disamodereader.Read())
                {
                    if (!disamodereader.IsDBNull(0)) { chngcount = disamodereader.GetInt32(0); } else { chngcount = 0; }
                }
            }
            chngcount++;
            string disamodinsert = "insert into LCLM.DISABILITY_MODE_CHNG(POLNO, INTIMNO, LASTMODE, NEWMODE, CHANGED_DATE, CHG_EPF, CHGCOUNT) values("+polno+",'"+intimno+"',"+MOD+", "+newmode+", "+this.setDate()[0]+", "+EPF+", "+chngcount+")";
            dm.insertRecords(disamodinsert);

            #endregion

            lblsuccess.Text = "Successfully Updated";
            btnAuth.Enabled = false;
            dm.commit();
            dm.connClose();
        }
        catch (Exception ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");            
        }
    }
    protected void btnAuth_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();
            PAYEENAME = this.txtpayeename.Text;
            AD1 = this.txtad1.Text;
            AD2 = this.txtad2.Text;
            AD3 = this.txtad3.Text;
            AD4 = this.txtad4.Text;
            Bankname = this.txtbkname.Text;
            BankBranch = this.txtbkbrnname.Text;
            Account = this.txtcustAcct.Text;
            Slicacc = this.ddlslicacctno.SelectedItem.Value;
            newmode = int.Parse(this.ddlmode.SelectedItem.Value);

            #region----------------Disable_Mas Update-----------------
            string upddismast = "update LCLM.DISABLE_MAS set AD1='" + AD1 + "', AD2='" + AD2 + "', AD3='" + AD3 + "', AD4='" + AD4 + "',BNKNAME='" + Bankname + "', BNKBRN='" + BankBranch + "', ACCTNO='" + Account + "', SLICACCTNO='" + Slicacc + "', PAYMODE=" + newmode + ", PAYEENAME='" + PAYEENAME + "' where ";
            upddismast += " policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' and MGR_DECISION = 'Y' and (clmstate = 'ACCEPTED' or clmstate = 'INFORCE' or clmstate = 'TERMINATED')";
            dm.insertRecords(upddismast);
            #endregion

            #region---------------PeriodicPaydet---------------
            string periodel = "delete from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='" + intimno + "' and (vono is null or vono = '' or vono = 'XXXX')";
            dm.insertRecords(periodel);
            #endregion

            string modechngupd = "update LCLM.DISABILITY_MODE_CHNG set AUTH_EPF='" + EPF + "', AUTH_DATE=" + this.setDate()[0] + " where POLNO=" + polno + " and INTIMNO='"+intimno+"'";
            dm.insertRecords(modechngupd);
            dm.commit();
            btnAuth.Enabled = false;
            lblsuccess.Text = "Mode Change Authorized!";
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }
}
