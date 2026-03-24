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

public partial class vouPrint002 : System.Web.UI.Page
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

    DataManager dm = new DataManager();
    SLICVouprint slivp;

    private  long polno;
    private  string MOS;
    private  string payee = "";
    private  double totamount;
    private  double amtOut;
    private  long claimno;
    private  double exgraciaAmt;

    private string name = "";
    private string vouno = "";
    private string ADBvouno = "";
    private double share;
    private double ADBshare;
    private double exgrShare;   
    private double PER;
    private double ADBONEX;
    private double ADBONEXshare;
    protected ArrayList payeeDetList;
    protected ArrayList payeeDetADBList;
    public bool SignatureDisplay;


    protected void Page_Load(object sender, EventArgs e)
    {
        Session["signatureDisplay"] = null;
        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOS = this.PreviousPage.mos;
            totamount = this.PreviousPage.Totamount;
            payee = this.PreviousPage.Payee;
            amtOut = this.PreviousPage.AmtOut;
            claimno = this.PreviousPage.Claimno;
            exgraciaAmt = this.PreviousPage.ExgraciaAmt;
            ADBONEX = this.PreviousPage.aDBONEX;

            ViewState["polno"] = polno;
            ViewState["MOS"] = MOS;
            ViewState["totamount"] = totamount;
            ViewState["payee"] = payee;
            ViewState["amtOut"] = amtOut;
            ViewState["claimno"] = claimno;
            ViewState["exgraciaAmt"] = exgraciaAmt;
            ViewState["ADBONEX"] = ADBONEX;
        }
        else 
        {
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOS"] != null) { MOS = ViewState["MOS"].ToString(); }
            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["payee"] != null) { payee = ViewState["payee"].ToString(); }
            if (ViewState["amtOut"] != null) { amtOut = double.Parse(ViewState["amtOut"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["exgraciaAmt"] != null) { exgraciaAmt = double.Parse(ViewState["exgraciaAmt"].ToString()); }
            if (ViewState["ADBONEX"] != null) { ADBONEX = double.Parse(ViewState["ADBONEX"].ToString()); }
            //polno = 0;
            //MOS = "";
            //totamount = 0;
            //payee = "";
            //amtOut = 0;
            //claimno = 0;
            //exgraciaAmt = 0;
            //ADBONEX = 0;
        }
        dm = new DataManager();
        
        try
        {
            double amount;
            double amountAdb;
            int payeenum;
            payeeDetList = new ArrayList();
            payeeDetADBList = new ArrayList();
            

            if (payee.Equals("NOM"))
            {
                #region

                //string nomSelect = "select NOMNAM, NOMPER, VOUNO, ADBVOUNO, NOMNO from LUND.NOMINEE where POLNO = " + polno + " and vouno is not null order by nomno ";
                string nomSelect = "select a.NOMNAM, a.NOMPER, b.VOUNO, a.ADBVOUNO, a.NOMNO " +
                                   "from LUND.NOMINEE a inner join CASHBOOK.TEMP_CB b on to_char(a.polno)=b.polno and a.vouno=b.vouno " +
                                   "inner join lphs.dthref c on a.polno=c.drpolno and to_char(c.DRCLMNO)=b.CLAIMNO " +
                                   "where a.POLNO = " + polno + " and c.DRMOS='" + MOS + "'";
                if (dm.existRecored(nomSelect) != 0)
                {
                    dm.readSql(nomSelect);
                    OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomineeReader.Read())
                    {
                        if (!nomineeReader.IsDBNull(0)) { name = nomineeReader.GetString(0); } else { name = ""; }
                        if (!nomineeReader.IsDBNull(1)) { PER = nomineeReader.GetDouble(1); } else { PER = 0; }
                        if (!nomineeReader.IsDBNull(2)) { vouno = nomineeReader.GetString(2); } else { vouno = ""; }
                        if (!nomineeReader.IsDBNull(3)) { ADBvouno = nomineeReader.GetString(3); } else { ADBvouno = ""; }
                        if (!nomineeReader.IsDBNull(4)) { payeenum = nomineeReader.GetInt32(4); } else { payeenum = 0; }
                        amount = this.Sliamount(polno, "NOM", MOS, payeenum, dm);
                        share = Math.Truncate(Math.Round(totamount * PER, 4)) / 100;
                        share -= amount;

                        amountAdb = this.SliamountADB(polno, "NOM", MOS, payeenum, dm);
                        ADBshare = Math.Truncate(Math.Round(amtOut * PER, 4)) / 100;
                        ADBshare -= amountAdb;

                        exgrShare = Math.Truncate(Math.Round(exgraciaAmt * PER, 4)) / 100;
                        ADBONEXshare = Math.Truncate(Math.Round(ADBONEX * PER, 4)) / 100;
                        if (share - exgrShare < 0) { exgrShare += share - exgrShare; }
                        payeeDetList.Add(new vouPrintFields(vouno, "Nominee", name, share, exgrShare));
                        if ((ADBvouno != null) && (!ADBvouno.Equals("")))
                        {
                            payeeDetADBList.Add(new vouPrintFields(ADBvouno, "Nominee", name, ADBshare, ADBONEXshare));
                        }
                    }
                    //nomineeReader.Close();
                    //nomineeReader.Dispose();
                }
                else { this.lblmessage.Visible = true; }

                #endregion
            }
            else if (payee.Equals("LHI")||payee.Equals("ML")||payee.Equals("SL"))
            {
                #region

                string heireSelect = "select lhhire, lhname, LHAMOUNT, VOUNO, ADBVOUNO, ADBAMT, LHSHARE, LHHNO from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOS + "' and vouno is not null ";
                if (dm.existRecored(heireSelect) != 0)
                {
                    string payeetype="";
                    dm.readSql(heireSelect);
                    OracleDataReader heireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (heireSelectReader.Read())
                    {
                        if (!heireSelectReader.IsDBNull(0)) { payeetype = heireSelectReader.GetString(0); } else { payee = ""; }
                        if (!heireSelectReader.IsDBNull(1)) { name = heireSelectReader.GetString(1); } else { name = ""; }
                        if (!heireSelectReader.IsDBNull(2)) { share = heireSelectReader.GetDouble(2); } else { share = 0; }
                        if (!heireSelectReader.IsDBNull(3)) { vouno = heireSelectReader.GetString(3); } else { vouno = ""; }
                        if (!heireSelectReader.IsDBNull(4)) { ADBvouno = heireSelectReader.GetString(4); } else { ADBvouno = ""; }
                        if (!heireSelectReader.IsDBNull(5)) { ADBshare = heireSelectReader.GetDouble(5); } else { ADBshare = 0; }
                        if (!heireSelectReader.IsDBNull(6)) { PER = heireSelectReader.GetDouble(6); } else { PER = 0; }
                        if (!heireSelectReader.IsDBNull(7)) { payeenum = heireSelectReader.GetInt32(7); } else { payeenum = 0; }

                        exgrShare = Math.Truncate(Math.Round(exgraciaAmt * PER * 100, 4)) / 100;
                        ADBONEXshare = Math.Truncate(Math.Round(ADBONEX * PER * 100, 4)) / 100;
                        amount = this.Sliamount(polno, payee, MOS, payeenum, dm);
                        //amountAdb = this.SliamountADB(polno, payee, MOS, payeenum, dm);
                        share -= amount;
                        //ADBshare -= amountAdb;
                        if (share - exgrShare < 0) { exgrShare += share - exgrShare; }
                        payeeDetList.Add(new vouPrintFields(vouno, payeetype, name, share, exgrShare));
                        if ((ADBvouno != null) && (!ADBvouno.Equals("")))
                        {
                            payeeDetADBList.Add(new vouPrintFields(ADBvouno, payeetype, name, ADBshare, ADBONEXshare));
                        }
                    }
                    //heireSelectReader.Close();
                    //heireSelectReader.Dispose();
                }
                else { this.lblmessage.Visible = true; }

                #endregion
            }
            else if (payee.Equals("ASI"))
            {
                #region

                string asiSelect = "select ASS_FULLNAME, VOUNO, ADBVOUNO from LUND.ASSIGNEE  where POLICY_NO = " + polno + " and vouno is not null ";
                if (dm.existRecored(asiSelect) != 0)
                {
                    dm.readSql(asiSelect);
                    OracleDataReader prassReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (prassReader.Read())
                    {
                        if (!prassReader.IsDBNull(0)) { name = prassReader.GetString(0); } else { name = ""; }
                        if (!prassReader.IsDBNull(1)) { vouno = prassReader.GetString(1); } else { vouno = ""; }
                        if (!prassReader.IsDBNull(2)) { ADBvouno = prassReader.GetString(2); } else { ADBvouno = ""; }

                        share = totamount;
                        amount = this.Sliamount(polno, "ASI", MOS, 1, dm);
                        amountAdb = this.SliamountADB(polno, "ASI", MOS, 1, dm);
                        share -= amount;
                        if (share - exgraciaAmt < 0) { exgraciaAmt += share - exgraciaAmt; }
                        payeeDetList.Add(new vouPrintFields(vouno, "Assignee", name, share, exgraciaAmt));
                        
                        ADBshare = amtOut;
                        ADBshare -= amountAdb;
                        ADBONEXshare = ADBONEX;
                        if ((ADBvouno != null) && (!ADBvouno.Equals("")))
                        {
                            payeeDetADBList.Add(new vouPrintFields(ADBvouno, "Assignee", name, ADBshare, ADBONEXshare));
                        }
                    }
                    //prassReader.Close();
                    //prassReader.Dispose();
                }
                else { this.lblmessage.Visible = true; }

                #endregion
            }
            else if (payee.Equals("LPT"))
            {
                #region

                string living_prtSelect = "select NOMNAM, NOMPER, VOUNO, ADBVOUNO from LUND.LIVING_PRT where polno = " + polno + " and vouno is not null  ";
                if (dm.existRecored(living_prtSelect) != 0)
                {
                    dm.readSql(living_prtSelect);
                    OracleDataReader nomineeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomineeReader.Read())
                    {
                        if (!nomineeReader.IsDBNull(0)) { name = nomineeReader.GetString(0); } else { name = ""; }
                        if (!nomineeReader.IsDBNull(1)) { PER = nomineeReader.GetDouble(1); } else { PER = 0; }
                        if (!nomineeReader.IsDBNull(2)) { vouno = nomineeReader.GetString(2); } else { vouno = ""; }
                        if (!nomineeReader.IsDBNull(3)) { ADBvouno = nomineeReader.GetString(3); } else { ADBvouno = ""; }

                        share = (totamount * PER) / 100;
                        ADBshare = (amtOut * PER) / 100;
                        exgrShare = (exgraciaAmt * PER) / 100;
                        ADBONEXshare = (ADBONEX * PER) / 100;
                        amount = this.Sliamount(polno, "LPT", MOS, 1, dm);
                        amountAdb = this.SliamountADB(polno, "LPT", MOS, 1, dm);
                        share -= amount;
                        ADBshare -= amountAdb;
                        if (share - exgrShare < 0) { exgrShare += share - exgrShare; }
                        payeeDetList.Add(new vouPrintFields(vouno, "Living_Partner", name, share, exgrShare));
                        if ((ADBvouno != null) && (!ADBvouno.Equals(""))) 
                        {
                            payeeDetADBList.Add(new vouPrintFields(ADBvouno, "Living_Partner", name, ADBshare, ADBONEXshare));
                        }

                    }
                    //nomineeReader.Close();
                    //nomineeReader.Dispose();
                }
                else { this.lblmessage.Visible = true; }

                #endregion
            }

            #region ---------- ADB Payee ---------------
            string adbheireSelect = "select LHHIRE, PAYEENAME, VOUNO, PAYEEAMOUNT, PAYEESHARE, PAYEENO from lphs.DTH_ADBPAYMENT_DISTN where POLICY_NO=" + polno + " and MOS='" + MOS + "' and VOUNO is not null ";
            if (dm.existRecored(adbheireSelect) != 0)
            {
                string payeetype = "";
                dm.readSql(adbheireSelect);
                OracleDataReader adbheireSelectReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (adbheireSelectReader.Read())
                {
                    if (!adbheireSelectReader.IsDBNull(0)) { payeetype = adbheireSelectReader.GetString(0); } else { payee = ""; }
                    if (!adbheireSelectReader.IsDBNull(1)) { name = adbheireSelectReader.GetString(1); } else { name = ""; } 
                    if (!adbheireSelectReader.IsDBNull(2)) { ADBvouno = adbheireSelectReader.GetString(2); } else { ADBvouno = ""; }
                    if (!adbheireSelectReader.IsDBNull(3)) { ADBshare = adbheireSelectReader.GetDouble(3); } else { ADBshare = 0; }
                    if (!adbheireSelectReader.IsDBNull(4)) { PER = adbheireSelectReader.GetDouble(4); } else { PER = 0; }
                    if (!adbheireSelectReader.IsDBNull(5)) { payeenum = adbheireSelectReader.GetInt32(5); } else { payeenum = 0; }
                     
                    ADBONEXshare = Math.Truncate(Math.Round(ADBONEX * PER * 100, 4)) / 100; 

                    amountAdb = this.SliamountADB(polno, "LHI", MOS, payeenum, dm);
                    //ADBshare = Math.Truncate(Math.Round(amtOut * PER, 4)) / 100;
                    ADBshare -= amountAdb; 

                    if ((ADBvouno != null) && (!ADBvouno.Equals("")))
                    {
                        payeeDetADBList.Add(new vouPrintFields(ADBvouno, payeetype, name, ADBshare, ADBONEXshare));
                    }
                } 
            }
            else { this.lblmessage.Visible = true; }

            #endregion

            DataGrid1.DataSource = CreateDataSource();
            DataGrid1.DataBind();

            if (payeeDetADBList.Count > 0)
            {
                this.Label1.Visible = true;
                GridView1.DataSource = CreateDataSource2();
                GridView1.DataBind();
            }
            slivp = new SLICVouprint();
            slivp.Fetch(polno, dm, claimno, "vouPrint003.aspx", MOS);
            if (slivp.Voulist.Count > 0)
            {
                this.lblSlicvou.Visible = true;
                GridView2.DataSource = slivp.Voulist;
                GridView2.DataBind();
            }
            
            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("~/EPage.aspx");
        }


        if (IsPostBack)
        {
            if (ViewState["signatureDisplay"] != null) { SignatureDisplay = bool.Parse(ViewState["signatureDisplay"].ToString()); }
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
            linkUrl = "<a  href=vouPrint003.aspx?vouno="+vpf.Vouno+"&payee="+vpf.Payee+"&amount="+vpf.Share+"&polno="+polno.ToString()+"&mos="+ MOS+"&clmno="+claimno+"&exgrshare="+vpf.ExgraciaShare+"&slicflag=0>"+vpf.Vouno+"</a>";
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

    public ICollection CreateDataSource2()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("vouno", typeof(string)));
        dt.Columns.Add(new DataColumn("payee", typeof(string)));
        dt.Columns.Add(new DataColumn("name", typeof(string)));
        dt.Columns.Add(new DataColumn("amount", typeof(string)));

        foreach (vouPrintFields vpf in payeeDetADBList)
        {
            linkUrl = "<a  href=vouPrint003.aspx?vouno=" + vpf.Vouno + "&payee=" + vpf.Payee + "&amount=" + vpf.Share + "&polno=" + polno.ToString() + "&mos=" + MOS + "&clmno=" + claimno + "&exgrshare=" + vpf.ExgraciaShare + "&slicflag=0>" + vpf.Vouno + "</a>";
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

    private double Sliamount(long polino, string svpayee, string svmos, int payeenum, DataManager dm)
    {
        double sliamt = 0;
        string balancesel = "select sum(SVAMT) from LPHS.SLICVOUCHERS where SVPOL=" + polino + " and SVPAYEE='" + svpayee + "' and SVMOS='" + svmos + "' and SVPAYNUM=" + payeenum + " and SYSTEM_TYPE='NP'";
        if (dm.existRecored(balancesel) != 0)
        {
            dm.readSql(balancesel);
            OracleDataReader balancereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (balancereader.Read())
            {
                if (!balancereader.IsDBNull(0)) { sliamt = balancereader.GetDouble(0); } else { sliamt = 0; }
            }
            //balancereader.Close();
            //balancereader.Dispose();
        }
        return sliamt;
    }

    private double SliamountADB(long polino, string svpayee, string svmos, int payeenum, DataManager dm)
    {
        double sliamt = 0;
        string balancesel = "select sum(SVAMT) from LPHS.SLICVOUCHERS where SVPOL=" + polino + " and SVPAYEE='" + svpayee + "' and SVMOS='" + svmos + "' and SVPAYNUM=" + payeenum + " and SYSTEM_TYPE='PP'";
        if (dm.existRecored(balancesel) != 0)
        {
            dm.readSql(balancesel);
            OracleDataReader balancereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (balancereader.Read())
            {
                if (!balancereader.IsDBNull(0)) { sliamt = balancereader.GetDouble(0); } else { sliamt = 0; }
            }
            //balancereader.Close();
            //balancereader.Dispose();
        }
        return sliamt;
    }

    protected void ChkSig(object sender, EventArgs e)
    {
        if (Signature.Checked)
        {
            SignatureDisplay = true;
            Session["signatureDisplay"] = "true";


        }
        else
        {
            SignatureDisplay = false;
            Session["signatureDisplay"] = "false";
        }
        ViewState["signatureDisplay"] = SignatureDisplay;
    }


    public bool SIGNATUREDISPLAY
    {
        get { return SignatureDisplay; }
        set { SignatureDisplay = value; }
    }
}
