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

public partial class payeeInq002 : System.Web.UI.Page
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

    private  int polno;
    private  string MOF;
    private string payee;
          
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        //{
        //    polno = this.PreviousPage.Polno;
        //    MOF = this.PreviousPage.mos;
        //}

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
              
                //payeeInq001 payeeInq001obj = new payeeInq001();
                //polno = payeeInq001obj.Polno;
                //MOF = payeeInq001obj.mos;

                if (Request.QueryString["polno"] != null) { polno = int.Parse(Request.QueryString["polno"]); }
                if (Request.QueryString["mos"] != null) { MOF = Request.QueryString["mos"].ToString(); }

                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblmos.Text = "Main Life"; }
                else if (MOF.Equals("S")) { this.lblmos.Text = "Spouce"; }
                else if (MOF.Equals("2")) { this.lblmos.Text = "Second Life"; }

                string dthrefSel = "select payee from lphs.dthref where drpolno = " + polno + " and drmos = '" + MOF + "' and memoaprv = 'Y' and payee is not null ";
                if (dm.existRecored(dthrefSel) != 0)
                {
                    dm.readSql(dthrefSel);
                    OracleDataReader payeereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (payeereader.Read())
                    {
                        if (!payeereader.IsDBNull(0)) { payee = payeereader.GetString(0); } else { payee = ""; }
                    }
                    payeereader.Close();
                    payeereader.Dispose();

                    string sql = "";
                    DataTable dt = new DataTable();
                    if (payee.Equals("NOM"))
                    {
                        #region
                        this.lblassignee.Visible = false;
                        this.lbllegheires.Visible = false;
                        this.lbllprt.Visible = false;
                        //this.lblnom.Visible = false;

                        sql = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, VOUNO, ADBVOUNO, nominatedate  from LUND.NOMINEE where polno  = " + polno + " ";

                        OracleDataAdapter dat = new OracleDataAdapter(sql, dm.oraConn);
                        dat.Fill(dt);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                        #endregion
                    }
                    else if (payee.Equals("LHI"))
                    {
                        #region
                        this.lblassignee.Visible = false;
                        //this.lbllegheires.Visible = false;
                        this.lbllprt.Visible = false;
                        this.lblnom.Visible = false;

                        sql = "select LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHREMARKS, LHSHARE, LHAMOUNT, VOUNO, ADBVOUNO, ADBAMT, AFFIDAVITDATE from LPHS.LEGAL_HIRES where LHPOLNO = " + polno + " and LHMOF = '" + MOF + "' ";
                        OracleDataAdapter dat = new OracleDataAdapter(sql, dm.oraConn);
                        dat.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        #endregion
                    }
                    else if (payee.Equals("ASI"))
                    {
                        #region
                        //this.lblassignee.Visible = false;
                        this.lbllegheires.Visible = false;
                        this.lbllprt.Visible = false;
                        this.lblnom.Visible = false;

                        sql = "select ASS_STATUS, ASS_INITIAL, ASS_SURNAME, ASS_FULLNAME, ASS_SHORTNAME, ASS_AD1, " +
                        " ASS_AD2 from LUND.ASSIGNEE  where policy_no  = " + polno + " ";

                        OracleDataAdapter dat = new OracleDataAdapter(sql, dm.oraConn);
                        dat.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        #endregion
                    }
                    else if (payee.Equals("LPT"))
                    {
                        #region
                        this.lblassignee.Visible = false;
                        this.lbllegheires.Visible = false;
                        //this.lbllprt.Visible = false;
                        this.lblnom.Visible = false;

                        sql = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, VOUNO, ADBVOUNO, PRTNRSHIPDATE from LUND.LIVING_PRT where polno = " + polno + " ";
                        OracleDataAdapter dat = new OracleDataAdapter(sql, dm.oraConn);
                        dat.Fill(dt);
                        GridView4.DataSource = dt;
                        GridView4.DataBind();
                        #endregion
                    }
                }
                else
                {
                    dm.connclose();
                    throw new Exception("Payee not yet Confirmed or Status Report not yet Accepted. Please Use other Inquiry.");
                }

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
}
