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

public partial class prtSettle002 : System.Web.UI.Page
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
    private string disable;
    private string intimno;
    private string clmstatus;
    private double polcomyramt;
    private int duedate;

    private double PAYAMT;
    private double netclm;
    private int paymode;
    private int dtofaccident, dueYM;   //static
    private int paymntDue;
    private string epf="6664";    //static
    private  int statCount;    //static
    private ArrayList vouIndexes;      //static
    private int maxPaymntdue, maxNextdue, mat_date, pymnt_end_dt;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region ---------- query string --------
            if (Request.QueryString["polNo"] != null)
            {
                
                polno = long.Parse(Request.QueryString["polNo"]);
            }
            else
            {
                polno = this.PreviousPage.Polno;
            }
            ViewState.Add("polnoQstr", polno);
            if (Request.QueryString["mos"] != null)
            {
                MOS = Request.QueryString["mos"].ToString();
            }
            else
            {
                MOS = this.PreviousPage.Mos;
            }
            ViewState.Add("mosQstr", mos);
            if (Request.QueryString["disType"] != null)
            {                
                disType = Request.QueryString["disType"].ToString();
            }
            else
            {
                disType = this.PreviousPage.Distype.ToString();
            }
            ViewState.Add("disTypeQstr", disType);
            if (Request.QueryString["intimno"] != null)
            {
                intimno = Request.QueryString["intimno"].ToString();
            }
            else
            {
                intimno = this.PreviousPage.Intimno;
            }
            ViewState.Add("intimnoQstr", intimno);
            if (Request.QueryString["givendue"] != null)
            {
                //ViewState.Add("givendueQstr", int.Parse(Request.QueryString["givendue"]));
                duedate = int.Parse(Request.QueryString["givendue"].ToString());
                dueYM = int.Parse(duedate.ToString().Substring(0, 6));                
            }
            else
            {
                duedate = int.Parse(this.setDate()[0]);
                dueYM = int.Parse(duedate.ToString().Substring(0, 6));
            }
            ViewState["givendueQstr"] = dueYM.ToString();
            ViewState["EPF"] = epf;            

            #endregion
        }
        else
        {
            if (ViewState["polnoQstr"] != null) { polno = long.Parse(ViewState["polnoQstr"].ToString()); }
            if (ViewState["mosQstr"] != null) { MOS = ViewState["mosQstr"].ToString(); }
            if (ViewState["disTypeQstr"] != null) { disType = ViewState["disTypeQstr"].ToString(); }
            if (ViewState["intimnoQstr"] != null) { intimno = ViewState["intimnoQstr"].ToString(); }
            if (ViewState["givendueQstr"] != null) { dueYM = int.Parse(ViewState["givendueQstr"].ToString()); }
            if (ViewState["EPF"] != null) { epf = ViewState["EPF"].ToString(); }
            if (ViewState["polcomyramt"] != null) { polcomyramt = double.Parse(ViewState["polcomyramt"].ToString()); }
        }

        try
        {
            if (polno > 0)
            {
                DissabilityTypesRead disabletype = new DissabilityTypesRead();
                disable = disabletype.GetDisabilityTypes(int.Parse(disType));
                this.lblpolno.Text = polno.ToString();
                this.lblintimNo.Text = intimno;
                this.lbldisType.Text = disable;
                if (MOS.Equals("M")) { this.lbllifeType.Text = "Main Life"; }
                else if (MOS.Equals("S")) { this.lbllifeType.Text = "Spouce"; }
                else if (MOS.Equals("2")) { this.lbllifeType.Text = "Second Life"; }
            }            
                dm = new DataManager();
                dm.begintransaction();
                vouIndexes = new ArrayList();
                //dm.begintransaction();
                //prtSettle001 prtSettle001Obj = new prtSettle001();
                //dueYM = prtSettle001Obj.DueYM;
                if (dueYM > 0) { this.lbldue.Text = dueYM.ToString().Substring(0, 4) + "/" + dueYM.ToString().Substring(4, 2); }

                #region ------- disable_mas -------
                string disaMasSelect = "select PAYAMT, paymode, dtofaccident, NETCLM, mat_date, pymnt_end_dt, clmstate, POLCOMYR_AMT_BAL, DSUM FROM LCLM.DISABLE_MAS WHERE policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' and MGR_DECISION = 'Y' and (CLMSTATE='ACCEPTED' or CLMSTATE='INFORCE' or CLMSTATE='TERMINATED')";
                if (dm.existRecored(disaMasSelect) != 0)
                {
                    dm.readSql(disaMasSelect);
                    OracleDataReader disaMasReader = dm.oraComm.ExecuteReader();
                    while (disaMasReader.Read())
                    {
                        if (!disaMasReader.IsDBNull(0)) { PAYAMT = disaMasReader.GetDouble(0); } else { PAYAMT = 0; }
                        if (!disaMasReader.IsDBNull(1)) { paymode = disaMasReader.GetInt32(1); } else { paymode = 0; }
                        if (!disaMasReader.IsDBNull(2)) { dtofaccident = disaMasReader.GetInt32(2); } else { dtofaccident = 0; }
                        if (!disaMasReader.IsDBNull(3)) { netclm = disaMasReader.GetDouble(3); } else { netclm = 0; }
                        if (!disaMasReader.IsDBNull(4)) { mat_date = disaMasReader.GetInt32(4); } else { mat_date = 0; }
                        if (!disaMasReader.IsDBNull(5)) { pymnt_end_dt = disaMasReader.GetInt32(5); } else { pymnt_end_dt = 0; }
                        if (!disaMasReader.IsDBNull(6)) { clmstatus = disaMasReader.GetString(6); } else { clmstatus = ""; }
                        if (!disaMasReader.IsDBNull(7)) { polcomyramt = disaMasReader.GetDouble(7); } else { polcomyramt = 0; }
                    }
                    disaMasReader.Close();

                    switch (paymode)
                    {
                        case 1: this.lblpaymode.Text = "Annually"; break;
                        case 2: this.lblpaymode.Text = "Half Yearly"; break;
                        case 3: this.lblpaymode.Text = "Quarterly"; break;
                        case 4: this.lblpaymode.Text = "Monthly"; break;
                        default: break;
                    }
                    this.lbltotclm.Text = String.Format("{0:N}", netclm);
                    this.lbldtofaccident.Text = dtofaccident.ToString().Substring(0, 4) + "/" + dtofaccident.ToString().Substring(4, 2) + "/" + dtofaccident.ToString().Substring(6, 2);
                    this.lblmatdate.Text = mat_date.ToString().Substring(0, 4) + "/" + mat_date.ToString().Substring(4, 2) + "/" + mat_date.ToString().Substring(6, 2);
                }
                else { throw new Exception("No Inforce Claim Found!"); }
                #endregion

                #region ------- Create non existing liable dues -------

                int currentYM = int.Parse(this.setDate()[0]);
                
                if (!disType.Equals("2"))
                {
                    string maxNextDueSel = "select max(payment_due), max(next_due) from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' ";
                    if (dm.existRecored(maxNextDueSel) != 0)
                    {
                        dm.readSql(maxNextDueSel);
                        OracleDataReader dueReader = dm.oraComm.ExecuteReader();
                        while (dueReader.Read())
                        {
                            if (!dueReader.IsDBNull(0)) { maxPaymntdue = dueReader.GetInt32(0); } else { maxPaymntdue = 0; }
                            if (!dueReader.IsDBNull(1)) { maxNextdue = dueReader.GetInt32(1); } else { maxNextdue = 0; }
                        }
                        dueReader.Close();

                        if ((maxPaymntdue > 0) && (maxPaymntdue <= currentYM))//maxPaymntdue))
                        {
                            if (currentYM < dueYM) { throw new Exception("Cannot Create Future Dues! Please Enter Current or Past Due YM."); } // if not a future due
                            else
                            {
                            a:
                                
                                int matdateYM = int.Parse(mat_date.ToString().Substring(0, 6));
                                int pymnt_end_dtYM = int.Parse(pymnt_end_dt.ToString().Substring(0, 6));
                                double paymt;
                                paymt = this.PaymentAmount(paymode, PAYAMT);
                                while (maxPaymntdue <= dueYM)
                                {
                                    maxPaymntdue = this.nextDue(paymode, maxPaymntdue, 1);
                                    if (clmstatus.Equals("COMPLETED") || clmstatus.Equals("TERMINATED")) { break; }
                                    else if (pymnt_end_dtYM < maxPaymntdue) { termin_handle("COMPLETED"); break; }
                                    else if (matdateYM < maxPaymntdue) { termin_handle("MATURITY"); break; }
                                    string s1 = "select polno from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and PAYMENT_DUE = " + maxPaymntdue + " ";
                                    if (dm.existRecored(s1) == 0)
                                    {
                                        string periodicpaydetInsrt = "INSERT INTO LCLM.PERIODIC_PAYDET (POLNO ,CLMTYPE ,PAYMENT_DUE, DIS_CLM_TYP ,LIFE_TYP, INTIMNO, PAID_AMT )" +
                                                "VALUES (" + polno + " ,'D' , " + maxPaymntdue + ", '" + disType + "' ,'" + MOS + "', '" + intimno + "'," + paymt + " )";
                                        dm.insertRecords(periodicpaydetInsrt);
                                    }
                                    //string deletedues="delete from 
                                    
                                    // maturity check 
                                    
                                    //if (matdateYM < maxNextdue) { this.lblmessage.Text = "Policy will be Matured by the Next Due"; break; }

                                    // completion check                                    
                                    //if (pymnt_end_dtYM == maxNextdue) { break; }
                                    //if (pymnt_end_dtYM < maxNextdue) { this.lblmessage.Text = "Part Settlements will be Completed by the Next Due"; break; }
                                }
                            }
                        }
                    }
                }

                #endregion

                #region ------- periodic_pay_det -------

                int count = 0;
                //int currentYM = int.Parse(this.setDate()[0].Substring(0, 6));
                string paydetSel = "select PAYMENT_DUE, PAID_AMT from lclm.PERIODIC_PAYDET where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and intimno = '" + intimno + "' and PAYMENT_DUE <= " + dueYM + " and (vono is null or vono = '' or vono = 'XXXX') ";
                if (dm.existRecored(paydetSel) != 0)
                {
                    dm.readSql(paydetSel);
                    OracleDataReader paydetReader = dm.oraComm.ExecuteReader();
                    while (paydetReader.Read())
                    {
                        if (count == 0) { this.createDuesTable(paymntDue, PAYAMT, count); }
                        count++;
                        if (!paydetReader.IsDBNull(0)) { paymntDue = paydetReader.GetInt32(0); } else { paymntDue = 0; }
                        if (!paydetReader.IsDBNull(1)) { PAYAMT = paydetReader.GetInt32(1); }
                        this.createDuesTable(paymntDue, PAYAMT, count);
                        vouIndexes.Add(paymntDue.ToString());
                    }
                    paydetReader.Close();

                    statCount = count;
                }
                else 
                {
                    if (clmstatus.Equals("COMPLETED")) { throw new Exception("Payments Completed!"); }
                    else if (clmstatus.Equals("TERMINATED")) { throw new Exception("Payments Terminated!"); }
                    else { throw new Exception("Voucher/s Already Created or no such Dues"); }
                    
                }

                #endregion

                #region ------------ grid -------------
                DataManager dma = new DataManager();
                DataTable dt = new DataTable();
                string minuteSel = "select MINUTE_COUNT, MINUTE from LCLM.DISABILITY_MINUTES where POLICY_NO= " + polno + " and MOS= '" + MOS + "' and DIS_TYPE= '" + disType + "' and INTIMNO= '" + intimno + "' ";
                OracleDataAdapter dat = new OracleDataAdapter(minuteSel, dma.oraConn);
                dat.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dma.connClose();
                #endregion

                ViewState["polcomyramt"] = polcomyramt;
                if (polcomyramt > 0) 
                {
                    lblPolcom.Visible = true;
                    lblPolcomamt.Visible = true;
                    lblPolcomamt.Text = String.Format("{0:N}", polcomyramt);
                    chkpolcom.Visible = true; 
                    chkpolcom.Checked = true; 
                }
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

    protected void btnVouCr_Click(object sender, EventArgs e)
    {
        try
        {
            string vouflg;
            dm = new DataManager();
            dm.begintransaction();
            int i = 0;
            double amt = 0, totamt = 0, polcomyearbal;
            polcomyearbal = polcomyramt;
            foreach (string vouindex in vouIndexes)
            {
                
                i++;
                paymntDue = int.Parse(vouindex);
                string chk = "chk" + i;
                CheckBox chkVouOK = new CheckBox();
                chkVouOK = (CheckBox)Table1.FindControl(chk);

                #region-----------Update for Pol. Com. Year---------------
                if ((chkpolcom.Checked) && (chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                {
                    string perioamtsel = "select PAID_AMT from LCLM.PERIODIC_PAYDET where PAYMENT_DUE=" + vouindex + " and POLNO=" + polno + " and INTIMNO='" + intimno + "'";
                    dm.readSql(perioamtsel);
                    OracleDataReader perioamtreader = dm.oraComm.ExecuteReader();
                    while (perioamtreader.Read())
                    {
                        if (!perioamtreader.IsDBNull(0)) { amt = perioamtreader.GetDouble(0); } else { amt = 0; }
                    }
                    if (amt < polcomyearbal) { totamt += amt; polcomyearbal -= amt; amt = 0; }
                    else { amt -= polcomyearbal; totamt += polcomyearbal; polcomyearbal = 0; }
                    string periopayupd = "update LCLM.PERIODIC_PAYDET set PAID_AMT=" + amt + " where PAYMENT_DUE=" + vouindex + " and POLNO=" + polno + " and INTIMNO='" + intimno + "'";
                    dm.insertRecords(periopayupd);
                }
                #endregion

                if ((chkVouOK != null) && (chkVouOK.Checked) && (chkVouOK.Enabled))
                {
                    vouflg = "XXXX";
                }
                else
                {
                    vouflg = "";
                }
                string paydetUpd = "update LCLM.PERIODIC_PAYDET set vono = '" + vouflg + "' where POLNO = " + polno + " and clmtype = 'D' and DIS_CLM_TYP = '" + disType + "' and LIFE_TYP = '" + MOS + "' and PAYMENT_DUE = " + paymntDue + " and (vono is null or vono = '' or vono ='XXXX') ";
                    dm.insertRecords(paydetUpd);                
            }
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
    protected void termin_handle(string terminReson)
    {
        if (terminReson.Equals("COMPLETED"))
        {
            string dis_masUpd = "update lclm.disable_mas set clmstate = 'COMPLETED' where policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' ";
            dm.insertRecords(dis_masUpd);
            string dreqUpd = "update lclm.pdbreq set DRCLMSTATE = 'COMPLETED' where DRPOL = " + polno + " and DRTYP = '" + disType + "' and LIFE_TYPE = '" + MOS + "' and intimno = '" + intimno + "' and " +
                      " APPEAL_CNT = 0 and DRCLMSTATE = 'ACCEPTED' ";
            dm.insertRecords(dreqUpd);
        }
        else
        {
            string disTermSel = "select POLNO from LCLM.DISABILITY_TERMINATE where POLNO =" + polno + " and MOS ='" + MOS + "' and DISTYPE='" + disType + "'  ";
            if (dm.existRecored(disTermSel) == 0)
            {
                string dis_ter_insert = "INSERT INTO LCLM.DISABILITY_TERMINATE (POLNO ,MOS ,DISTYPE ,TRMNT_REASON ,ENTRYDATE ,ENTRYIP, ENTRYEPF, INTIMNO )" +
                                  " VALUES (" + polno + " ,'" + MOS + "' ,'" + disType + "' ,'" + terminReson + "' ," + int.Parse(this.setDate()[0]) + " ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', '" + epf + "', '" + intimno + "')";
                dm.insertRecords(dis_ter_insert);

                string dis_masUpd = "update lclm.disable_mas set clmstate = 'TERMINATED' where policy_no = " + polno + " and disability_type = '" + disType + "' and mos = '" + MOS + "' and intimno = '" + intimno + "' ";
                dm.insertRecords(dis_masUpd);

                string dreqUpd = "update lclm.pdbreq set DRCLMSTATE = 'TERMINATED' where DRPOL = " + polno + " and DRTYP = '" + disType + "' and LIFE_TYPE = '" + MOS + "' and intimno = '" + intimno + "' and " +
                       " APPEAL_CNT = 0 and DRCLMSTATE = 'ACCEPTED' ";
                dm.insertRecords(dreqUpd);
            }
        }
    }

    private void createDuesTable(int Due, double payamt, int count)
    {
        TableRow trow01 = new TableRow();

        TableCell tcel11 = new TableCell();
        TableCell tcel12 = new TableCell();
        TableCell tcel13 = new TableCell();

        Label lbl11 = new Label();
        Label lbl12 = new Label();
        CheckBox chk01 = new CheckBox();

        chk01.ID = "chk" + count;
        chk01.Attributes.Add("runat", "Server");
        chk01.Attributes.Add("Name", "chk" + count); //Text Value

        lbl11.ID = "due" + count;
        lbl11.Attributes.Add("runat", "Server");
        lbl11.Attributes.Add("Name", "due" + count); //Text Value
        if (count == 0) { lbl11.Text = "Due"; }
        else { lbl11.Text = Due.ToString().Substring(0, 4) + "/" + Due.ToString().Substring(4, 2); }

        lbl12.ID = "payamt" + count;
        lbl12.Attributes.Add("runat", "Server");
        lbl12.Attributes.Add("Name", "payamt" + count); //Text Value
        if (count == 0) { lbl12.Text = "Pay Amount"; }
        else { lbl12.Text = String.Format("{0:N}", payamt); }

        tcel11.Controls.Add(lbl11);
        tcel12.Controls.Add(lbl12);
        if (count > 0) { tcel13.Controls.Add(chk01); }

        trow01.Cells.Add(tcel11);
        trow01.Cells.Add(tcel12);
        trow01.Cells.Add(tcel13);

        Table1.Rows.Add(trow01);

    }

    protected int nextDue(int mod, int lastDue, int premCount)
    {
        int lastDueYear = int.Parse(lastDue.ToString().Substring(0, 4));
        int lastDueMonth = int.Parse(lastDue.ToString().Substring(4, 2));
        int nextDueYear = 0;
        int nextDueMonth = 0;
        int nextDueYM = 0;
        int x = 0;

        if (mod == 1) { x = 12; }
        else if (mod == 2) { x = 6; }
        else if (mod == 3) { x = 3; }
        else if (mod == 4) { x = 1; }
        else { }
        if (mod != 5)
        {
            int monthCount = premCount * x;
            if (monthCount >= 12)
            {
                int years = (int)Math.Floor((decimal)(monthCount / 12));
                int months = monthCount % 12;

                nextDueMonth = lastDueMonth + months;
                nextDueYear = lastDueYear + years;
                if (nextDueMonth > 12)
                {
                    nextDueMonth -= 12;
                    nextDueYear++;
                }
                if (nextDueMonth < 10)
                {
                    nextDueYM = int.Parse(nextDueYear.ToString() + "0" + nextDueMonth.ToString());
                }
                else
                {
                    nextDueYM = int.Parse(nextDueYear.ToString() + nextDueMonth.ToString());
                }
            }
            else
            {
                nextDueMonth = lastDueMonth + monthCount;
                nextDueYear = lastDueYear;
                if (nextDueMonth > 12)
                {
                    nextDueMonth -= 12;
                    nextDueYear++;
                }
                if (nextDueMonth < 10)
                {
                    nextDueYM = int.Parse(nextDueYear.ToString() + "0" + nextDueMonth.ToString());
                }
                else
                {
                    nextDueYM = int.Parse(nextDueYear.ToString() + nextDueMonth.ToString());
                }
            }
        }
        else { nextDueYM = lastDue; }
        return nextDueYM;
    }

    public double PaymentAmount(int mode, double amt)
    {
        int multilier;
        double amount;
        if (mode == 1) { multilier = 12; }
        else if (mode == 2) { multilier = 6; }
        else if (mode == 3) { multilier = 3; }
        else multilier = 1;
        amount = amt * multilier;
        //add option to check this amount

        return Math.Round(amount, 2);
    }

    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOS; }
        set { MOS = value; }
    }
    public string DisType
    {
        get { return disType; }
        set { disType = value; }
    }
    public string Intimno
    {
        get { return intimno; }
        set { intimno = value; }
    }
    public int DueYM
    {
        get { return dueYM; }
        set { dueYM = value; }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("minute001.aspx?polNo=" + polno + "&mos=" + MOS + "&disType=" + disType + "&intimno=" + intimno + "");
    }
}
