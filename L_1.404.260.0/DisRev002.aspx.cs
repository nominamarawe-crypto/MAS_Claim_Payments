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

public partial class DisRev002 : System.Web.UI.Page
{
    private long polno;
    private string intimno;
    private double dsum;
    private int distype;
    private string vouno, ppdbvou;
    private int tbl;
    private int term;
    private double amount;
    private string mos;
    private int covnum;
    private double premium;
    private string rrate;
    private string roex;
    private string rhex;
    private double rdiscon, polcomamt;
    private string clmstate;
    private double balamt;
    private int entrytype;
    private int npdue;
    private int dtofacc;
    private ArrayList vouIndexes;
    DataManager dm;
    DissabilityTypesRead dtr;
    polMasRead pmr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            polno = this.PreviousPage.Polno;
            intimno = this.PreviousPage.Intimno;
        }
        if (!Page.IsPostBack)
        {
            try
            {
                dm = new DataManager();
                vouIndexes = new ArrayList();

                #region-------------------DisableMas-----------------

                string disablemassel = "select DSUM, DISABILITY_TYPE, PPDBVOUNO, PAYAMT, MOS, CLMSTATE, PAYMENT_BAL, ENTRY_TYPE, POLCOMYR_AMT, DTOFACCIDENT from LCLM.DISABLE_MAS where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
                if (dm.existRecored(disablemassel) != 0)
                {
                    dm.readSql(disablemassel);
                    OracleDataReader disamasreader = dm.oraComm.ExecuteReader();
                    while (disamasreader.Read())
                    {
                        if (!disamasreader.IsDBNull(0)) { dsum = disamasreader.GetDouble(0); } else { dsum = 0; }
                        if (!disamasreader.IsDBNull(1)) { distype = disamasreader.GetInt32(1); } else { distype = 0; }
                        if (!disamasreader.IsDBNull(2)) { ppdbvou = disamasreader.GetString(2); } else { ppdbvou = ""; }
                        if (!disamasreader.IsDBNull(3)) { amount = disamasreader.GetDouble(3); } else { amount = 0; }
                        if (!disamasreader.IsDBNull(4)) { mos = disamasreader.GetString(4); } else { mos = ""; }
                        if (!disamasreader.IsDBNull(5)) { clmstate = disamasreader.GetString(5); } else { clmstate = ""; }
                        if (!disamasreader.IsDBNull(6)) { balamt = disamasreader.GetDouble(6); } else { balamt = 0; }
                        if (!disamasreader.IsDBNull(7)) { entrytype = disamasreader.GetInt32(7); } else { entrytype = 0; }
                        if (!disamasreader.IsDBNull(8)) { polcomamt = disamasreader.GetDouble(8); } else { polcomamt = 0; }
                        if (!disamasreader.IsDBNull(9)) { dtofacc = disamasreader.GetInt32(9); } else { dtofacc = 0; }
                    }
                    disamasreader.Close();
                }
                else
                {
                    throw new Exception("No Disability Claim Found for This Policy no. and Intimation no.");
                }
                #endregion

                #region--------------------Premast-------------------
                pmr = new polMasRead(int.Parse(polno.ToString()), dm);
                tbl = pmr.TBL;
                term = pmr.TRM;
                premium = pmr.PRM;

                #endregion

                #region-----------------Voucher Numbers-----------
                //----Periodic_Paydet
                string periosel = "select VONO, PAID_AMT from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='" + intimno + "'";
                if (dm.existRecored(periosel) != 0)
                {
                    dm.readSql(periosel);
                    OracleDataReader perioreader = dm.oraComm.ExecuteReader();
                    while (perioreader.Read())
                    {
                        if (!perioreader.IsDBNull(0)) { vouno = perioreader.GetString(0); } else { vouno = ""; }
                        vouIndexes.Add(vouno);
                    }
                    if (ppdbvou != null && !ppdbvou.Equals(""))
                    {
                        vouIndexes.Add(ppdbvou);
                    }
                }
                //Terminated Vouchers
                string terminlistsel = "select VOUCHERNO from LCLM.DISABILITY_TERMINATE where POLNO=" + polno + " and INTIMNO='" + intimno + "'";
                if (dm.existRecored(terminlistsel) != 0)
                {
                    dm.readSql(terminlistsel);
                    OracleDataReader terminlistreader = dm.oraComm.ExecuteReader();
                    while (terminlistreader.Read())
                    {
                        if (!terminlistreader.IsDBNull(0)) { vouno = terminlistreader.GetString(0); } else { vouno = ""; }
                        vouIndexes.Add(vouno);
                    }                    
                }
                #endregion

                #region------------------Display Values--------------
                dtr = new DissabilityTypesRead();
                this.lblDistype.Text = dtr.GetDisabilityTypes(distype).ToString();
                this.lblPolno.Text = polno.ToString();
                this.lblTbl.Text = tbl.ToString();
                this.lblTerm.Text = term.ToString();
                this.lblDsum.Text = dsum.ToString();
                this.lblIntimno.Text = intimno.ToString();
                #endregion

                dm.connClose();
            }
            catch (Exception Ex)
            {
                dm.connClose();
                EPage.Messege = Ex.Message;                
                Response.Redirect("~/EPage.aspx");
            }

            #region----------------viewstate-------------
            ViewState["vouIndexes"] = vouIndexes;
            ViewState["ppdbvou"] = ppdbvou;
            ViewState["polno"] = polno;
            ViewState["intimno"] = intimno;
            ViewState["distype"] = distype;
            ViewState["mos"] = mos;
            ViewState["prem"] = premium;
            ViewState["clmstate"] = clmstate;
            ViewState["dsum"] = dsum;
            ViewState["entrytype"] = entrytype;
            ViewState["polcomamt"] = polcomamt;
            ViewState["dtofacc"] = dtofacc;
            #endregion
        }
        else
        {
            #region---------------viewstate load----------------
            if (ViewState["vouIndexes"] != null) { vouIndexes = (ArrayList)ViewState["vouIndexes"]; }
            if (ViewState["ppdbvou"] != null) { ppdbvou = ViewState["ppdbvou"].ToString(); }
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["intimno"] != null) { intimno = ViewState["intimno"].ToString(); }
            if (ViewState["distype"] != null) { distype = int.Parse(ViewState["distype"].ToString()); }
            if (ViewState["mos"] != null) { mos = ViewState["mos"].ToString(); }
            if (ViewState["prem"] != null) { premium = double.Parse(ViewState["prem"].ToString()); }
            if (ViewState["clmstate"] != null) { clmstate = ViewState["clmstate"].ToString(); }
            if (ViewState["dsum"] != null) { dsum = double.Parse(ViewState["dsum"].ToString()); }
            if (ViewState["entrytype"] != null) { entrytype = int.Parse(ViewState["entrytype"].ToString()); }
            if (ViewState["polcomamt"] != null) { polcomamt=double.Parse(ViewState["polcomamt"].ToString());}
            if (ViewState["dtofacc"] != null) { dtofacc = int.Parse(ViewState["dtofacc"].ToString()); }
            #endregion
        }
    }
    protected void btnReverse_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();

            if (clmstate.Equals("COMPLETED")||clmstate.Equals("TERMINATED")) { clmstate = "INFORCE"; }
            if (distype == 1 || distype == 3) { balamt = dsum; }
            if (entrytype == 1) { }
          

            #region-----------------Cheque Printing Status--------------
            int printstatus;
            foreach (string vounum in vouIndexes)
            {
                string tempcbsel = "select PRINT1 from CASHBOOK.TEMP_CB where VOUNO='" + vounum + "'";
                if (dm.existRecored(tempcbsel) != 0)
                {
                    dm.readSql(tempcbsel);
                    OracleDataReader tempcbreader = dm.oraComm.ExecuteReader();
                    while (tempcbreader.Read())
                    {
                        if (!tempcbreader.IsDBNull(0)) { printstatus = tempcbreader.GetInt32(0); } else { printstatus = 0; }
                        if (printstatus == 1)
                        {
                            throw new Exception("Cheque Already Printed. Cannot Reverse!");
                        }
                    }
                }
            }
            #endregion

            foreach (string vounum in vouIndexes)
            {
                #region-------------------tempcb--------------
                string tempcbdel = "delete from CASHBOOK.TEMP_CB where POLNO=" + polno + " and VOUNO='" + vounum + "'";
                dm.insertRecords(tempcbdel);
                #endregion

                #region-------------tempdetl------------------
                string temdetldel = "delete from CASHBOOK.TEMP_DETL where VOUNO='" + vounum + "'";
                dm.insertRecords(temdetldel);
                #endregion

                #region----------------vouBankDet-------------
                string voubankdetdel = "delete from LPHS.VOUBANKDET where VOUCHERNO='" + vounum + "'";
                dm.insertRecords(voubankdetdel);
                #endregion
            }

            #region-----------------------Terminate List-------------
            string terminlistdel = "delete from LCLM.DISABILITY_TERMINATE where POLNO=" + polno + " and INTIMNO='" + intimno + "'";
            dm.insertRecords(terminlistdel);
            #endregion

            #region----------------Mode Changes-----------------------
            string modechngdel = "delete from LCLM.DISABILITY_MODE_CHNG where POLNO=" + polno + " and INTIMNO='" + intimno + "'";
            dm.insertRecords(modechngdel);

            #endregion

            #region-----------------Periodic_Paydet---------------
            string periodicdel = "delete from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and INTIMNO='"+intimno+"'";
            dm.insertRecords(periodicdel);
            #endregion            

            #region----------------DisableMas----------
            npdue = this.Paystdate(dtofacc);
            npdue = int.Parse(npdue.ToString().Substring(0, 6));
            string disamasupd = "update LCLM.DISABLE_MAS set CLMSTATE='" + clmstate + "', PAYMENT_BAL=" + balamt + ", POLCOMYR_AMT_BAL=" + polcomamt + ", NPDUE="+npdue+" where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
            dm.insertRecords(disamasupd);
            #endregion

            dm.commit();
            dm.connClose();
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connClose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
        lblMessage.Visible = true;
        btnReverse.Enabled = false;
        btnCompltrev.Visible = true;
    }
    protected void btnCompltrev_Click(object sender, EventArgs e)
    {
        try
        {
            int moscal=0;
            int seqno;
            double prem=0;

            dm = new DataManager();
            dm.begintransaction();
            if (mos.Equals("S")) { moscal = 100; }
            else if (mos.Equals("2")) { moscal = 200; }
            else if (mos.Equals("C")) { moscal = 300; }

            if (distype == 1) { covnum = 3; }
            else if (distype == 2) { covnum = 8; }
            else if (distype == 3) { covnum = 12; }
            else { covnum = 0; }

            covnum += moscal;

            #region------------------DisableMas---------------
            string disablemassel = "delete from LCLM.DISABLE_MAS where POLICY_NO=" + polno + " and INTIMNO='" + intimno + "'";
            dm.insertRecords(disablemassel);
            #endregion

            #region---------------Recover Cover Details------------
            double prm;
            string disacovchng = "select RCOVR, SQNO, PREM from LCLM.DISABILITY_COVER_CHANGE where RPOL=" + polno + " and INTIMNO='" + intimno + "'";
            if (dm.existRecored(disacovchng) != 0)
            {
                dm.readSql(disacovchng);
                OracleDataReader disacovreader = dm.oraComm.ExecuteReader();
                while (disacovreader.Read())
                {
                    if (!disacovreader.IsDBNull(0)) { covnum = disacovreader.GetInt32(0); } else { covnum = 0; }
                    if (!disacovreader.IsDBNull(1)) { seqno = disacovreader.GetInt32(1); } else { seqno = 0; }
                    if (!disacovreader.IsDBNull(2)) { prem = disacovreader.GetDouble(2); } else { prem=0;}
                    string rcoverexistsel = "select * from LUND.RCOVER where RPOL=" + polno + " and RCOVR=" + covnum + "";
                    if (dm.existRecored(rcoverexistsel) != 0)
                    {
                        string rcoverinsert = "insert into LUND.RCOVER(RPOL, RCOVR, RCOMDAT, RSUMAS, RMODE, RTERM, RPRM, RRATE, ROEX, RHEX, RDISCON, ENTERED_MODE) select RPOL, RCOVR, RCOMDAT, RSUMAS, RMODE, RTERM, RPRM," +
                            " RRATE, ROEX, RHEX, RDISCON, ENTERED_MODE from LUND.RCOVER_HISTORY where RPOL=" + polno + " and RCOVR=" + covnum + " and SQNO=" + seqno + "";
                        dm.insertRecords(rcoverinsert);
                    }

                    #region-------------Premium Adjustment-----------------
                    //string rcoversel = "select RPRM, RRATE, ROEX, RHEX, RDISCON from LUND.RCOVER_HISTORY where RPOL=" + polno + " and RCOVR=" + covnum + " and SQNO=" + seqno + "";
                    //if (dm.existRecored(rcoversel) != 0)
                    //{
                        //dm.readSql(rcoversel);
                        //OracleDataReader rcovreader = dm.oraComm.ExecuteReader();
                        //while (rcovreader.Read())
                        //{
                        //    if (!rcovreader.IsDBNull(0)) { prem = rcovreader.GetDouble(0); } else { prem = 0; }
                            //if (!rcovreader.IsDBNull(1)) { rrate = rcovreader.GetDouble(1); } else { rrate = 0; }
                            //if (!rcovreader.IsDBNull(2)) { roex = rcovreader.GetDouble(2); } else { roex = 0; }
                            //if (!rcovreader.IsDBNull(3)) { rhex = rcovreader.GetDouble(3); } else { rhex = 0; }
                            //if (!rcovreader.IsDBNull(4)) { rdiscon = rcovreader.GetDouble(4); } else { rdiscon = 0; }
                        //}

                    prm = premium + prem;//set premium to new value

                    string premastupd = "update LPHS.PREMAST set PMPRM=" + prm + " where PMPOL=" + polno + "";
                    dm.insertRecords(premastupd);
                    //}
                    #endregion
                }
            }
            #endregion

            


            dm.commit();
            dm.connClose();
            btnCompltrev.Enabled = false;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connClose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    public int Paystdate(int date)
    {
        int nextyr, nextmn;
        string mnthstr;
        nextyr = int.Parse(date.ToString().Substring(0, 4));
        nextmn = int.Parse(date.ToString().Substring(4, 2));
        nextmn++;
        if (nextmn == 13) { nextmn = 1; nextyr++; }
        if (nextmn < 10) { mnthstr = "0" + nextmn; }
        else { mnthstr = nextmn.ToString(); }
        return int.Parse(nextyr.ToString() + mnthstr + date.ToString().Substring(6, 2));
    }
}
