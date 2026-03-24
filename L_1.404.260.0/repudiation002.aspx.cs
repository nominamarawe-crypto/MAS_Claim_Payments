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

public partial class repudiation002 : System.Web.UI.Page
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
    private string MOF;

    private int repudiatedate;
    private string repuReason;
    private string repuReasonSin;
    private string RorL;
    private string epf;
    private int clmno;

    DataManager dm; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            RorL = this.PreviousPage.ROrl;

            ViewState["RorL"] = RorL;
        }
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                //epf = "";
                //clmno = 0;

                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblmos.Text = "Main Life"; }
                else if (MOF.Equals("S")) { this.lblmos.Text = "Spouce"; }
                else if (MOF.Equals("2")) { this.lblmos.Text = "Second Life"; }
                this.txtrepudDate.Text = this.setDate()[0];

                string memoaprv = "";
                string completed = "";

                #region ------------- claimno --------
                string dthrefSele = "select drclmno, memoaprv, completed from lphs.dthref where drpolno = " + polno + " and drmos = '" + MOF + "' ";
                if (dm.existRecored(dthrefSele) != 0)
                {
                    dm.readSql(dthrefSele);
                    OracleDataReader oraDtReader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (oraDtReader2.Read())
                    {
                        if (!oraDtReader2.IsDBNull(0)) { clmno = oraDtReader2.GetInt32(0); } else { clmno = 0; }
                        if (!oraDtReader2.IsDBNull(1)) { memoaprv = oraDtReader2.GetString(1); } else { memoaprv = ""; }
                        if (!oraDtReader2.IsDBNull(2)) { completed = oraDtReader2.GetString(2); } else { completed = ""; }
                    }
                    oraDtReader2.Close();

                    if (memoaprv.Equals("Y")) { throw new Exception("Status Report Approved. Cannot Repudiate or Lapsed or No Contract."); }
                    if (completed.Equals("R"))
                    {
                        this.btnRepudiate.Enabled = false;
                        string repusel = "select REPU_REASON, REPU_DATE, REPU_REASON_SIN from LPHS.DTH_REPUDIATION where policyno = " + polno + " and life_type = '" + MOF + "' ";
                        if (dm.existRecored(repusel) != 0)
                        {
                            dm.readSql(repusel);
                            OracleDataReader oraDtReader3 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (oraDtReader3.Read())
                            {
                                if (!oraDtReader3.IsDBNull(0)) { repuReason = oraDtReader3.GetString(0); } else { repuReason = ""; }
                                if (!oraDtReader3.IsDBNull(1)) { repudiatedate = oraDtReader3.GetInt32(1); } else { repudiatedate = 0; }
                                if (!oraDtReader3.IsDBNull(2)) { repuReasonSin = oraDtReader3.GetString(2); } else { repuReasonSin = ""; }
                            }
                            oraDtReader3.Close();

                            this.txtrepreason.Text = repuReason;
                            this.txtrepudDate.Text = repudiatedate.ToString();
                            this.txtrepureasSin.Text = repuReasonSin;
                        }
                    }

                }
                #endregion
 
                string status = "";
                string phname = "";
                string sql = "";
                string sql2 = "";
                string sql3 = "";
                                                 
                sql = "select  STATUS, FULLNAME from LUND.POLPERSONAL where POLNO='" + polno + "' and PRPERTYPE=(SELECT DECODE('" + MOF + "', 'M', '1','S','2','2', '3') result from dual)";
                sql2 = "select  STATUS, FULLNAME from LUND.POLPERSONAL_HISTORY where POLNO='" + polno + "' and PRPERTYPE=(SELECT DECODE('" + MOF + "', 'M', '1','S','2','2', '3') result from dual)";

                if (dm.existRecored(sql) != 0)
                {
                    dm.readSql(sql);
                    OracleDataReader oraPolDetailsReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (oraPolDetailsReader.Read())
                    {
                        if (!oraPolDetailsReader.IsDBNull(0)) { status = oraPolDetailsReader.GetString(0); }
                        if (!oraPolDetailsReader.IsDBNull(1)) { phname = oraPolDetailsReader.GetString(1); }
                    }
                    oraPolDetailsReader.Close();
                }
                else if (dm.existRecored(sql2) != 0)
                {
                    dm.readSql(sql2);
                    OracleDataReader oraPolHisDetailsReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                    while (oraPolHisDetailsReader.Read())
                    {
                        if (!oraPolHisDetailsReader.IsDBNull(0)) { status = oraPolHisDetailsReader.GetString(0); }
                        if (!oraPolHisDetailsReader.IsDBNull(1)) { phname = oraPolHisDetailsReader.GetString(1); }
                    }
                    oraPolHisDetailsReader.Close();
                }

                if (phname != null && phname != "")
                {
                    sql3 = "select lphs.GET_NAMEWITHINITIALS('" + phname + "') from dual";
                    if (dm.existRecored(sql3) != 0)
                    {
                        dm.readSql(sql3);
                        OracleDataReader oraDtReaderName = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                        while (oraDtReaderName.Read())
                        {
                            if (!oraDtReaderName.IsDBNull(0))
                            {
                                phname = status + " " + oraDtReaderName.GetString(0);
                            }
                        }
                        oraDtReaderName.Close();
                    }
                }
                   
                this.lblname.Text = phname;
                 
                if (RorL.Equals("L")) 
                {
                    this.lblrepudiatedate.Visible = false;
                    //this.lblrepureasoneng.Visible = false;
                    this.lblrepureasonsin.Visible = false;
                    this.txtrepreason.Text = "Lapse";
                    this.txtrepureasSin.Visible = false;
                    this.txtrepudDate.Visible = false;
                    this.btnrepulettereng.Visible = false;
                    this.btnrepulettersin.Visible = false;
                    this.btnlapselettereng.Visible = true;
                    this.btnlapselettersin.Visible = true;
                }
                if (RorL.Equals("R")) 
                {
                    this.lblrepudiatedate.Visible = true;
                    //this.lblrepureasoneng.Visible = true;
                    this.lblrepureasonsin.Visible = true;                   
                    this.txtrepureasSin.Visible = true;
                    this.txtrepudDate.Visible = true;
                    this.btnrepulettereng.Visible = true;
                    this.btnrepulettersin.Visible = true;
                    this.btnlapselettereng.Visible = false;
                    this.btnlapselettersin.Visible = false;
                }
                if (RorL.Equals("N"))
                {
                    this.lblrepudiatedate.Visible = false;
                    //this.lblrepureasoneng.Visible = false;
                    this.lblrepureasonsin.Visible = false;
                    this.txtrepreason.Text = "No Contract";
                    this.txtrepureasSin.Visible = false;
                    this.txtrepudDate.Visible = false;
                    this.btnrepulettereng.Visible = false;
                    this.btnrepulettersin.Visible = false;
                    this.btnlapselettereng.Visible = false;
                    this.btnlapselettersin.Visible = false;
                }
                if (RorL.Equals("S"))
                {
                    this.lblrepudiatedate.Visible = false;
                    //this.lblrepureasoneng.Visible = false;
                    this.lblrepureasonsin.Visible = false;
                    this.txtrepreason.Text = "Special Payment";
                    this.txtrepureasSin.Visible = false;
                    this.txtrepudDate.Visible = false;
                    this.btnrepulettereng.Visible = false;
                    this.btnrepulettersin.Visible = false;
                    this.btnlapselettereng.Visible = false;
                    this.btnlapselettersin.Visible = false;
                }

                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["epf"] = epf;
                ViewState["clmno"] = clmno;
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
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
            if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
            if (ViewState["RorL"] != null) { RorL = ViewState["RorL"].ToString(); }
        }
    }

    protected void btnRepudiate_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        try 
        {
            dm = new DataManager();
            dm.begintransaction();
            repudiatedate = int.Parse(this.txtrepudDate.Text);
            repuReason = this.txtrepreason.Text;
            repuReasonSin = this.txtrepureasSin.Text;

            string repuUpd = "update lphs.dthref set payautdt = " + int.Parse(this.setDate()[0]) + ", payautepf= '" + epf + "', completed = 'R', MEMOAPRV = 'R' where drpolno = " + polno + " and drmos = '" + MOF + "' ";
            dm.insertRecords(repuUpd);

            string SEQ = "";
            if(RorL.Equals("L") || RorL.Equals("R")){
                string sql3 = "";
                if (RorL.Equals("L"))
                {
                    sql3 = "select LAPS_PREFIX || '/' || lpad((LAPS_SEQ + 1),6,'0') from LPHS.DTH_REPUDIATION_SEQ";
                }
                else if (RorL.Equals("R"))
                {
                    sql3 = "select REPU_PREFIX || '/' || lpad((REPU_SEQ + 1),6,'0') from LPHS.DTH_REPUDIATION_SEQ";
                }
                if (dm.existRecored(sql3) != 0)
                {
                    dm.readSql(sql3);
                    OracleDataReader oraDtReaderName = dm.oraComm.ExecuteReader();

                    while (oraDtReaderName.Read())
                    {
                        if (!oraDtReaderName.IsDBNull(0))
                        {
                            SEQ = oraDtReaderName.GetString(0);
                        }
                    }
                    oraDtReaderName.Close();
                }
            }

            string dthrepudSel = "select policyno from LPHS.DTH_REPUDIATION where policyno = " + polno + " and life_type = '" + MOF + "'  ";
            if (dm.existRecored(dthrepudSel) == 0) 
            {
                string repuInsert = "INSERT INTO LPHS.DTH_REPUDIATION (REPU_SEQ,POLICYNO ,LIFE_TYPE ,REPU_REASON ,REPU_DATE ,ENTDATE ,ENTEPF, REPU_REASON_SIN )" +
                    " VALUES ('"+ SEQ + "'," + polno + " ,'" + MOF + "' ,'" + repuReason + "' ," + repudiatedate + " ," + int.Parse(this.setDate()[0]) + " ,'" + epf + "', '" + repuReasonSin + "'  )";
                dm.insertRecords(repuInsert);

                if (RorL.Equals("L") || RorL.Equals("R"))
                {
                    string sql3 = "";
                    if (RorL.Equals("L"))
                    {
                        sql3 = "update LPHS.DTH_REPUDIATION_SEQ set LAPS_SEQ=LAPS_SEQ+1";
                    }
                    else if (RorL.Equals("R"))
                    {
                        sql3 = "update LPHS.DTH_REPUDIATION_SEQ set REPU_SEQ=REPU_SEQ+1";
                    }
                    dm.insertRecords(sql3);
                }
            }
            else { throw new Exception("Already Repudiated"); }



            this.Label1.Visible = true;
            this.btnRepudiate.Enabled = false;
            dm.commit();
            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public int Clmno 
    {
        get { return clmno; }
        set { clmno = value; }
    }


}
