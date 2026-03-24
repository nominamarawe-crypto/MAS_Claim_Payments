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

public partial class OldChildProt_Oldchildprot002 : System.Web.UI.Page
{
    private long polno;
    private string mos, phsta, phint, phnam, phfullnam, sta, init, paynam, ad1, ad2, ad3, ad4, epf, slfnam, slsnam, slsta, slname;
    private int dtofDth, npdue, tbl, trm, com, matdate, clmno, sldob;
    private double sumass, bonus;

    DataManager dm;
    BonusCal bc;

    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["EPFNum"] != null)
            {
                //branch = Convert.ToInt32(Session["brcode"]);
                epf = Session["EPFNum"].ToString();
            }
            else
            {
                Response.Redirect("~/SessionError.aspx");
            }

            try
            {
                dm = new DataManager();
                if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
                {
                    polno = this.PreviousPage.Polno;
                    mos = this.PreviousPage.Mos;
                }

                ddlMos.Items.Add(new ListItem("Main Life", "M"));
                ddlMos.Items.Add(new ListItem("Spouce", "S"));
                ddlMos.Items.Add(new ListItem("Second Life", "2"));

                ddlpaysta.Items.Add(new ListItem("MR.", "MR."));
                ddlpaysta.Items.Add(new ListItem("MAST.", "MAST."));
                ddlpaysta.Items.Add(new ListItem("MS.", "MS."));
                ddlpaysta.Items.Add(new ListItem("DR.", "DR."));
                ddlpaysta.Items.Add(new ListItem("REV.", "REV."));

                ddlPhsta.Items.Add(new ListItem("MR.", "MR."));
                ddlPhsta.Items.Add(new ListItem("MAST.", "MAST."));
                ddlPhsta.Items.Add(new ListItem("MS.", "MS."));
                ddlPhsta.Items.Add(new ListItem("DR.", "DR."));
                ddlPhsta.Items.Add(new ListItem("REV.", "REV."));

                ddlSlnam.Items.Add(new ListItem("MR.", "MR."));
                ddlSlnam.Items.Add(new ListItem("MAST.", "MAST."));
                ddlSlnam.Items.Add(new ListItem("MS.", "MS."));
                ddlSlnam.Items.Add(new ListItem("DR.", "DR."));
                ddlSlnam.Items.Add(new ListItem("REV.", "REV."));

                ddlTable.Items.Add(new ListItem("38", "38"));
                ddlTable.Items.Add(new ListItem("39", "39"));
                ddlTable.Items.Add(new ListItem("46", "46"));
                ddlTable.Items.Add(new ListItem("49", "49"));
				ddlTable.Items.Add(new ListItem("34", "34"));

                #region----------------Check Policy---------------------------

                #region----------------Polpersonal--------------
                string polpersonalsel = "select STATUS, SURNAME, FULLNAME, DOB from LUND.POLPERSONAL where POLNO=" + polno + " and PRPERTYPE=2";
                if (dm.existRecored(polpersonalsel) != 0)
                {
                    polpersonalread ppr = new polpersonalread(int.Parse(polno.ToString()));
                    sldob = ppr.Secdob;
                    slsta = ppr.Secsta;
                    slsnam = ppr.Secsname;
                    slfnam = ppr.Secfname;
                    phfullnam = ppr.FirstlifeFullname;
                }
                else
                {
                    this.btnUpdsl.Enabled = false;
                }
                #endregion

                string phnamesel = "select PNSTA, PNINT, PNSUR from LPHS.PHNAME where PNPOL=" + polno + "";
                if (dm.existRecored(phnamesel) != 0)
                {
                    dm.readSql(phnamesel);
                    OracleDataReader phnamereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (phnamereader.Read())
                    {
                        if (!phnamereader.IsDBNull(0)) { phsta = phnamereader.GetString(0); }
                        if (!phnamereader.IsDBNull(1)) { phint = phnamereader.GetString(1); }
                        if (!phnamereader.IsDBNull(2)) { phnam = phnamereader.GetString(2); }
                    }
                    phnamereader.Close();
                    phnamereader.Dispose();
                }
                //#region--------------------Read Entered Data-------------------------------------
                string childprotsel = "select CLAIMNO, DTOFDTH, MOS, TBL, TERM, SUMASS, NPDUE, MATDATE, COM, PAYNAM, AD1, AD2, AD3, AD4" +
                    " ,NOMSTA, NOMINT, NOMNAME from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + "";
                if (dm.existRecored(childprotsel) != 0)
                {
                    this.btnSubmit.Visible = false;
                    this.btnEdit.Visible = true;
                    this.btnNext.Enabled = true;
                    dm.readSql(childprotsel);
                    OracleDataReader childprotreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (childprotreader.Read())
                    {
                        if (!childprotreader.IsDBNull(0)) { clmno = childprotreader.GetInt32(0); }
                        if (!childprotreader.IsDBNull(1)) { dtofDth = childprotreader.GetInt32(1); }
                        if (!childprotreader.IsDBNull(2)) { mos = childprotreader.GetString(2); }
                        if (!childprotreader.IsDBNull(3)) { tbl = childprotreader.GetInt32(3); }
                        if (!childprotreader.IsDBNull(4)) { trm = childprotreader.GetInt32(4); }
                        if (!childprotreader.IsDBNull(5)) { sumass = childprotreader.GetDouble(5); }
                        if (!childprotreader.IsDBNull(6)) { npdue = childprotreader.GetInt32(6); }
                        if (!childprotreader.IsDBNull(7)) { matdate = childprotreader.GetInt32(7); }
                        if (!childprotreader.IsDBNull(8)) { com = childprotreader.GetInt32(8); }
                        //if (!childprotreader.IsDBNull(9)) { paynam = childprotreader.GetString(9); }
                        if (!childprotreader.IsDBNull(10)) { ad1 = childprotreader.GetString(10); }
                        if (!childprotreader.IsDBNull(11)) { ad2 = childprotreader.GetString(11); }
                        if (!childprotreader.IsDBNull(12)) { ad3 = childprotreader.GetString(12); }
                        if (!childprotreader.IsDBNull(13)) { ad4 = childprotreader.GetString(13); }
                        //if (!childprotreader.IsDBNull(14)) { phsta = childprotreader.GetString(14); }
                        //if (!childprotreader.IsDBNull(15)) { phint = childprotreader.GetString(15); }
                        //if (!childprotreader.IsDBNull(16)) { phnam = childprotreader.GetString(16); }
                        if (!childprotreader.IsDBNull(14)) { sta = childprotreader.GetString(14); }
                        if (!childprotreader.IsDBNull(15)) { init = childprotreader.GetString(15); }
                        if (!childprotreader.IsDBNull(16)) { paynam = childprotreader.GetString(16); }
                        //if (!childprotreader.IsDBNull(19)) { slsta = childprotreader.GetString(19); }
                        //if (!childprotreader.IsDBNull(20)) { slsnam = childprotreader.GetString(20); }
                        //if (!childprotreader.IsDBNull(21)) { slfnam = childprotreader.GetString(21); }
                    }
                    childprotreader.Close();
                    childprotreader.Dispose();
                                        
                    #region--------------------Set Values---------------------------
                    //this.txtClmno.Text = clmno.ToString();
                    this.txtDtofdth.Text = dtofDth.ToString();
                    //this.ddlMos.SelectedValue = mos;
                    //this.ddlTable.SelectedValue = tbl.ToString();
                    //this.txtTerm.Text = trm.ToString();
                    //this.txtSumass.Text = sumass.ToString();
                    this.txtNpdue.Text = npdue.ToString();
                    this.txtCom.Text = com.ToString();
                    //this.txtPaynam.Text = paynam;
                    this.txtAd1.Text = ad1;
                    this.txtAd2.Text = ad2;
                    this.txtAd3.Text = ad3;
                    this.txtAd4.Text = ad4;
                    this.ddlpaysta.SelectedValue = sta;
                    this.txtInit.Text = init;
                    this.txtPaynam.Text = paynam;
                    this.txtPhfullnam.Text = phfullnam;                    
                    this.txtDob.Text = sldob.ToString();
                    #endregion
                    //this.txtNpdue.ReadOnly = true;
                }
                else
                {
                    this.btnSubmit.Visible = true;

                    string dthrefsel = "select * from LPHS.DTHREF where DRPOLNO=" + polno + "";
                    if (dm.existRecored(dthrefsel) != 0)
                    {
                        throw new Exception("This Claim already intimated!");
                    }
                    //string premastsel = "select * from LPHS.PREMAST where PMPOL=" + polno + "";
                    //if (dm.existRecored(premastsel) != 0)
                    //{
                    //    throw new Exception("Please intimate the Death Claim!");
                    //}
                    string lapsesel = "select * from LPHS.LIFLAPS where LPPOL=" + polno + "";
                    if (dm.existRecored(lapsesel) != 0)
                    {
                        throw new Exception("Policy Lapsed!");
                    }

                    #region-------------DthOut---------------------------
                    string dthoutread = "select CLMNO, TBL, TRM, SUMASS from LPHS.DTHOUT where POLNO=" + polno + "";
                    string dthexitsel = "select EXTTBL, EXTTRM, EXTSUM from LPHS.EXSURREN where EXTPOL=" + polno + "";
                    if (dm.existRecored(dthoutread) != 0)
                    {
                        dm.readSql(dthoutread);
                        OracleDataReader dthoutreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthoutreader.Read())
                        {
                            if (!dthoutreader.IsDBNull(0)) { clmno = dthoutreader.GetInt32(0); } else { clmno = 0; }
                            if (!dthoutreader.IsDBNull(1)) { tbl = dthoutreader.GetInt32(1); } else { tbl = 0; }
                            if (!dthoutreader.IsDBNull(2)) { trm = dthoutreader.GetInt32(2); } else { trm = 0; }
                            if (!dthoutreader.IsDBNull(3)) { sumass = dthoutreader.GetInt32(3); } else { sumass = 0; }
                        }
                        dthoutreader.Dispose();
                    }
                    else if (dm.existRecored(dthexitsel) != 0)
                    {
                        dm.readSql(dthexitsel);
                        OracleDataReader dthexistreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthexistreader.Read())
                        {
                            if (!dthexistreader.IsDBNull(0)) { tbl = dthexistreader.GetInt32(0); } else { tbl = 0; }
                            if (!dthexistreader.IsDBNull(1)) { trm = dthexistreader.GetInt32(1); } else { trm = 0; }
                            if (!dthexistreader.IsDBNull(2)) { sumass = dthexistreader.GetDouble(2); } else { sumass = 0; }
                        }
                        dthexistreader.Dispose();
                    }
                    else
                    {
                        throw new Exception("Policy number does not exist");
                    }
                    #endregion
                }
                //#endregion

                
                #endregion                
                                

                if (tbl != 38 && tbl != 39 && tbl != 46 && tbl != 49 && tbl != 0 && tbl != 34)
                {
                    throw new Exception("Table " + tbl + " does not entitle for child protection payments!");
                }
                if (tbl == 0)
                {
                    this.ddlTable.Enabled = true;
                    this.lblError.Visible = true;

                }

                //bc = new BonusCal();
                //bonus = bc.VestedBonus(polno, mos);
                ViewState["polno"] = polno;
                ViewState["bonus"] = bonus;
                ViewState["epf"] = epf;
                //ViewState["mos"] = mos;
                //ViewState["clmno"] = clmno;
                //ViewState["tbl"] = tbl;
                //ViewState["trm"] = trm;
                //ViewState["sumass"] = sumass;

                if (clmno > 0)
                {
                    this.txtClmno.Text = clmno.ToString();
                    this.ddlTable.SelectedValue = tbl.ToString();
                    this.txtTerm.Text = trm.ToString();
                    this.txtSumass.Text = sumass.ToString();
                    
                }

                this.lblPolno.Text = polno.ToString();
                this.ddlMos.SelectedValue = mos;
                this.ddlPhsta.SelectedValue = phsta;
                this.txtPhint.Text = phint;
                this.txtPhname.Text = phnam;
                this.ddlSlnam.SelectedValue = slsta;
                this.txtslsurnam.Text = slsnam;
                this.txtslfullnam.Text = slfnam;
                //this.txtBonus.Text = bonus.ToString();
                dm.connclose();
            }
            catch (Exception Ex)
            {
                dm.connclose();
                EPage.Messege = Ex.Message;
                Response.Redirect("~/EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = long.Parse(ViewState["polno"].ToString()); }
            if (ViewState["bonus"] != null) { bonus = double.Parse(ViewState["bonus"].ToString()); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
            //if (ViewState["clmno"] != null) { clmno = int.Parse(ViewState["clmno"].ToString()); }
            //ViewState["tbl"]
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int lastdue, paydue, nextdue;
        double payamt;
        string payee, polholnam;

        try
        {
            dm = new DataManager();
            dm.begintransaction();

            mos = this.ddlMos.SelectedValue;
            dtofDth = int.Parse(this.txtDtofdth.Text.Trim());
            npdue = int.Parse(this.txtNpdue.Text.Trim());
            com = int.Parse(this.txtCom.Text.Trim());
            tbl = int.Parse(this.ddlTable.SelectedValue);
            trm = int.Parse(this.txtTerm.Text.Trim());
            clmno = int.Parse(this.txtClmno.Text.Trim());
            sumass = double.Parse(this.txtSumass.Text.Trim());
            phsta = this.ddlPhsta.SelectedValue;
            sta = this.ddlpaysta.SelectedValue;
            init = this.txtInit.Text;
            phint = this.txtPhint.Text;
            paynam = this.txtPaynam.Text;
            phnam = this.txtPhname.Text;
            ad1 = this.txtAd1.Text.Trim();
            ad2 = this.txtAd2.Text.Trim();
            ad3 = this.txtAd3.Text.Trim();
            ad4 = this.txtAd4.Text.Trim();
            slsta = this.ddlSlnam.SelectedValue;
            slsnam = this.txtslsurnam.Text;
            slfnam = this.txtslfullnam.Text;
            sldob = int.Parse(this.txtDob.Text.Trim());
            phfullnam = this.txtPhfullnam.Text;

            payee = sta + " " + init + " " + paynam;
            polholnam = phsta + " " + phint + " " + phnam;
            slname = slsta + " " + slfnam + " " + slsnam;


            #region-------------------oldchildprot-----------------

            matdate = int.Parse(Convert.ToString(int.Parse(com.ToString().Substring(0, 4)) + trm) + com.ToString().Substring(4, 4));
            npdue = int.Parse(npdue.ToString().Substring(0, 6));

            string childprotsel = "select * from LPHS.DTH_CHILDPROT_OUT where POLNO=" + polno + "";
            if (dm.existRecored(childprotsel) == 0)
            {
                string childprotinsert = "insert into LPHS.DTH_CHILDPROT_OUT (POLNO, CLAIMNO, DTOFDTH, MOS, TBL, TERM, SUMASS, NPDUE, MATDATE, COM, PAYNAM, AD1, AD2, AD3, AD4, ENTEPF, ENTDATE, NOMSTA, NOMINT, NOMNAME)" +
                    " values(" + polno + ", " + clmno + ", " + dtofDth + ", '" + mos + "', " + tbl + ", " + trm + ", " + sumass + ", " + npdue + ", " + matdate + ", " + com + ", '" + payee + "', '" + ad1 + "', '" + ad2 + "', '" + ad3 + "', '" + ad4 + "', " +
                    "'" + epf + "', sysdate, '" + sta + "', '" + init + "', '" + paynam + "')";
                dm.insertRecords(childprotinsert);
            }
            else
            {
                throw new Exception("This Claim already added!");
            }
            #endregion

            #region------------------------------Periodic_paydet---------------
            paydue = npdue;
            if (tbl == 39 || tbl == 49)
            {
                payamt = sumass * .15;
                lastdue = 0;

                if (paydue <= int.Parse(matdate.ToString().Substring(0, 6)))
                {
                    nextdue = this.Nextdue(paydue);
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);
                    lastdue = paydue;
                    paydue = nextdue;
                }

                while (paydue <= int.Parse(this.setDate()[0].Substring(0, 6)) && paydue <= int.Parse(matdate.ToString().Substring(0, 6)))
                {
                    nextdue = this.Nextdue(paydue);
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);
                    lastdue = paydue;
                    paydue = nextdue;
                }
            }
            else if (tbl == 38)
            {
                int i = 0;
                lastdue = 0;
                if (paydue <= int.Parse(matdate.ToString().Substring(0, 6)) - 300)
                {
                    paydue = int.Parse(matdate.ToString().Substring(0, 6)) - 300;
                }
                while (paydue <= int.Parse(matdate.ToString().Substring(0, 6)) && paydue >= npdue && i < 4)
                {
                    nextdue = this.Nextdue(paydue);
                    if (int.Parse(paydue.ToString().Substring(0, 4)) == int.Parse(matdate.ToString().Substring(0, 4)))
                    {
                        payamt = sumass * .4;
                    }
                    else
                    {
                        payamt = sumass * .2;
                    }
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);

                    i++;
                    lastdue = paydue;
                    paydue = nextdue;
                }
            }
            else if (tbl == 46)
            {
                int i = 0;
                lastdue = 0;
                if (paydue < int.Parse(matdate.ToString().Substring(0, 6)))
                {
                    paydue = int.Parse(matdate.ToString().Substring(0, 6));
                }
                while (paydue <= int.Parse(matdate.ToString().Substring(0, 6)) + 200 && i < 3)
                {
                    nextdue = this.Nextdue(paydue);
                    payamt = sumass * .35;
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);

                    i++;
                    lastdue = paydue;
                    paydue = nextdue;
                }
            }
            else if (tbl == 34)
            {
                lastdue = 0;
                nextdue = 0;
                paydue = int.Parse(matdate.ToString().Substring(0, 6));
                payamt = sumass * 4;
                string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                    " '" + mos + "', " + clmno + ")";
                dm.insertRecords(periodicpayinsert);
            }
            #endregion
             
            #region----------------------PHNAME-----------------
            string phnamesel = "select * from LPHS.PHNAME where PNPOL=" + polno + "";
            if (dm.existRecored(phnamesel) == 0)
            {
                string phnameinsert = "insert into LPHS.PHNAME (PNPOL, PNPRO, PNSTA, PNINT, PNSUR, PNAD1, PNAD2, PNAD3, PNAD4)" +
                    " values (" + polno + ", 0, '" + phsta + "', '" + phint + "', '" + phnam + "', '" + ad1 + "', '" + ad2 + "', '" + ad3 + "', '" + ad4 + "' )";
                dm.insertRecords(phnameinsert);
            }
            #endregion

            #region-----------------Polpersonal & Nominee--------------
            //firstlife insert
            this.Polpersonalinsert(1, 0, phsta, phnam, phfullnam);
            //Second Life insert
            this.Polpersonalinsert(4, sldob, slsta, slsnam, slfnam);
            //Nominee Insert
            string nomineesel = "select * from LUND.NOMINEE where POLNO=" + polno + "";
            if (dm.existRecored(nomineesel) == 0)
            {
                string nomineeinsert = "insert into LUND.NOMINEE(POLNO, NOMNO, NOMNAM) values(" + polno + ", 1, '" + payee + "')";
                dm.insertRecords(nomineeinsert);
            }            
            #endregion

            this.btnSubmit.Enabled = false;
            this.btnNext.Enabled = true;
            dm.commit();
            dm.connclose();
            this.lblMessage.Visible = true;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }

    }
    public int Nextdue(int date)
    {
        int year = int.Parse(date.ToString().Substring(0, 4));
        year++;
        return int.Parse(year.ToString() + date.ToString().Substring(4, 2));
    }
    public long Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string Mos
    {
        get { return mos; }
        set { mos = value; }
    }
    
    public void Polpersonalinsert(int pertyp, int dob, string sta, string snam, string fnam)
    {
        string seclifesel = "select * from LUND.POLPERSONAL where POLNO=" + polno + " and PRPERTYPE=" + pertyp + "";
        if (dm.existRecored(seclifesel) == 0)
        {
            string seclifeinsert = "insert into LUND.POLPERSONAL(PRPERTYPE, DOB, POLNO, STATUS, SURNAME, FULLNAME) values(" + pertyp + ", " + dob + ", " + polno + ", '" + sta + "', '" + snam + "', '" + fnam + "')";
            dm.insertRecords(seclifeinsert);
        }
        else
        {
            string seclifeedit = "update LUND.POLPERSONAL set DOB=" + dob + ", STATUS='" + sta + "', SURNAME='" + snam + "', FULLNAME='" + fnam + "' where POLNO=" + polno + " and PRPERTYPE="+pertyp+"";
            dm.insertRecords(seclifeedit);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int lastdue, paydue, nextdue;
        double payamt;
        string payee, polholnam;

        try
        {
            dm = new DataManager();
            dm.begintransaction();

            #region---------------------Read Values-----------------
            mos = this.ddlMos.SelectedValue;
            dtofDth = int.Parse(this.txtDtofdth.Text.Trim());
            npdue = int.Parse(this.txtNpdue.Text.Trim());
            com = int.Parse(this.txtCom.Text.Trim());
            tbl = int.Parse(this.ddlTable.SelectedValue);
            trm = int.Parse(this.txtTerm.Text.Trim());
            clmno = int.Parse(this.txtClmno.Text.Trim());
            sumass = double.Parse(this.txtSumass.Text.Trim());
            phsta = this.ddlPhsta.SelectedValue;
            sta = this.ddlpaysta.SelectedValue;
            init = this.txtInit.Text;
            phint = this.txtPhint.Text;
            paynam = this.txtPaynam.Text;
            phnam = this.txtPhname.Text;
            phfullnam = this.txtPhfullnam.Text;
            ad1 = this.txtAd1.Text.Trim();
            ad2 = this.txtAd2.Text.Trim();
            ad3 = this.txtAd3.Text.Trim();
            ad4 = this.txtAd4.Text.Trim();
            slsta = this.ddlSlnam.SelectedValue;
            slsnam = this.txtslsurnam.Text;
            slfnam = this.txtslfullnam.Text;
            sldob = int.Parse(this.txtDob.Text.Trim());
            #endregion

            payee = sta + " " + init + " " + paynam;
            polholnam = phsta + " " + phint + " " + phnam;
            slname = slsta + " " + slsnam + " " + slfnam;
            
            #region-------------------oldchildprot-----------------

            matdate = int.Parse(Convert.ToString(int.Parse(com.ToString().Substring(0, 4)) + trm) + com.ToString().Substring(4, 4));
            npdue = int.Parse(npdue.ToString().Substring(0, 6));

            string oldchildprotedit = "update LPHS.DTH_CHILDPROT_OUT set CLAIMNO=" + clmno + ", DTOFDTH=" + dtofDth + ", TBL=" + tbl + ", TERM=" + trm + ", SUMASS=" + sumass + ", NPDUE=" + npdue + ", " +
                "MATDATE=" + matdate + ", COM=" + com + ", AD1='" + ad1 + "', AD2='" + ad2 + "', AD3='" + ad3 + "', AD4='" + ad4 + "', EDITEPF=" + epf + ", EDITDATE=sysdate, EDITCOUNT=(EDITCOUNT+1), NOMSTA='" + sta + "', NOMINT='" + init + "'" +
                ", NOMNAME='" + paynam + "' where POLNO=" + polno + " and MOS='" + mos + "'";
            dm.insertRecords(oldchildprotedit);
            #endregion

            #region------------------------------Periodic_paydet---------------
            string periosel = "select * from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='DOC' and DIS_CLM_TYP='DTH' and (VONO is not null and VONO<>'XXXX')";
            if (dm.existRecored(periosel) != 0)
            {
                throw new Exception("Voucher already created. please use reverse option!");
            }

            string periodicdel = "delete from LCLM.PERIODIC_PAYDET where POLNO=" + polno + " and CLMTYPE='DOC' and DIS_CLM_TYP='DTH'";
            dm.insertRecords(periodicdel);

            paydue = npdue;
            if (tbl == 39 || tbl == 49)
            {
                payamt = sumass * .15;
                lastdue = 0;

                if (paydue <= int.Parse(matdate.ToString().Substring(0, 6)))
                {
                    nextdue = this.Nextdue(paydue);
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);
                    lastdue = paydue;
                    paydue = nextdue;
                }

                while (paydue <= int.Parse(this.setDate()[0].Substring(0, 6)) && paydue <= int.Parse(matdate.ToString().Substring(0, 6)))
                {
                    nextdue = this.Nextdue(paydue);
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);
                    lastdue = paydue;
                    paydue = nextdue;
                }
            }
            else if (tbl == 38)
            {
                int i = 0;
                lastdue = 0;
                if (paydue < int.Parse(matdate.ToString().Substring(0, 6)) - 300)
                {
                    paydue = int.Parse(matdate.ToString().Substring(0, 6)) - 300;
                }
                while (paydue <= int.Parse(matdate.ToString().Substring(0, 6)) && paydue >= npdue && i < 4)
                {
                    nextdue = this.Nextdue(paydue);
                    if (int.Parse(paydue.ToString().Substring(0, 4)) == int.Parse(matdate.ToString().Substring(0, 4)))
                    {
                        payamt = sumass * .4;
                    }
                    else
                    {
                        payamt = sumass * .2;
                    }
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);

                    i++;
                    lastdue = paydue;
                    paydue = nextdue;
                }
            }
            else if (tbl == 46)
            {
                int i = 0;
                lastdue = 0;
                if (paydue < int.Parse(matdate.ToString().Substring(0, 6)))
                {
                    paydue = int.Parse(matdate.ToString().Substring(0, 6));
                }
                while (paydue <= int.Parse(matdate.ToString().Substring(0, 6)) + 200 && i < 3)
                {
                    nextdue = this.Nextdue(paydue);
                    payamt = sumass * .35;
                    string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                        " '" + mos + "', " + clmno + ")";
                    dm.insertRecords(periodicpayinsert);

                    i++;
                    lastdue = paydue;
                    paydue = nextdue;
                }
            }
            else if (tbl == 34)
            {
                lastdue = 0;
                nextdue = 0;
                paydue = int.Parse(matdate.ToString().Substring(0, 6));
                payamt = sumass * 4;
                string periodicpayinsert = "insert into LCLM.PERIODIC_PAYDET (POLNO, CLMTYPE, PAYMENT_DUE, LAST_DUE, NEXT_DUE, PAID_AMT, DIS_CLM_TYP, LIFE_TYP, INTIMNO) values(" + polno + ", 'DOC', " + paydue + ", " + lastdue + ", " + nextdue + ", " + payamt + ", 'DTH', " +
                    " '" + mos + "', " + clmno + ")";
                dm.insertRecords(periodicpayinsert);
            }
            #endregion

            #region-----------------PHName------------------------
            string phnameupd = "update LPHS.PHNAME set PNSTA='" + phsta + "', PNINT='" + phint + "', PNSUR='" + phnam + "', PNAD1='" + ad1 + "', PNAD2='" + ad2 + "', PNAD3='" + ad3 + "', PNAD4='" + ad4 + "' where PNPOL=" + polno + "";
            dm.insertRecords(phnameupd);
            #endregion

            #region-----------------Polpersonal & Nominee--------------
            //first life insert
            this.Polpersonalinsert(1, 0, phsta, phnam, phfullnam);
            //Second Life insert
            this.Polpersonalinsert(2, sldob, slsta, slsnam, slfnam);
            //Nominee Insert
            string nomineeupd = "update LUND.NOMINEE set NOMNAM='" + payee + "' where POLNO=" + polno + " and NOMNO=1";
            dm.insertRecords(nomineeupd);
            
            #endregion
            dm.commit();
            this.btnEdit.Enabled = false;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
    protected void btnUpdsl_Click(object sender, EventArgs e)
    {
        try
        {
            dm = new DataManager();
            dm.begintransaction();
            lblMessage.Visible = false;
            #region---------------------Read Values-----------------
            mos = this.ddlMos.SelectedValue;
            //dtofDth = int.Parse(this.txtDtofdth.Text.Trim());
            //npdue = int.Parse(this.txtNpdue.Text.Trim());
            //com = int.Parse(this.txtCom.Text.Trim());
            //tbl = int.Parse(this.ddlTable.SelectedValue);
            //trm = int.Parse(this.txtTerm.Text.Trim());
            //clmno = int.Parse(this.txtClmno.Text.Trim());
            //sumass = double.Parse(this.txtSumass.Text.Trim());
            phsta = this.ddlPhsta.SelectedValue;
            sta = this.ddlpaysta.SelectedValue;
            init = this.txtInit.Text;
            //phint = this.txtPhint.Text;
            paynam = this.txtPaynam.Text;
            phnam = this.txtPhname.Text;
            phfullnam = this.txtPhfullnam.Text;
            ad1 = this.txtAd1.Text.Trim();
            ad2 = this.txtAd2.Text.Trim();
            ad3 = this.txtAd3.Text.Trim();
            ad4 = this.txtAd4.Text.Trim();
            slsta = this.ddlSlnam.SelectedValue;
            slsnam = this.txtslsurnam.Text;
            slfnam = this.txtslfullnam.Text;
            sldob = int.Parse(this.txtDob.Text.Trim());
            string payee = sta + " " + init + " " + paynam;

            #endregion

            //first life insert
            this.Polpersonalinsert(1, 0, phsta, phnam, phfullnam);
            //Second Life insert
            this.Polpersonalinsert(2, sldob, slsta, slsnam, slfnam);


            string oldchildprotedit = "update LPHS.DTH_CHILDPROT_OUT set NOMSTA='" + sta + "', NOMINT='" + init + "', NOMNAME='" + paynam + "', AD1='" + ad1 + "', AD2='" + ad2 + "', AD3='" + ad3 + "', AD4='" + ad4 + "', EDITEPF=" + epf + ", EDITDATE=sysdate, EDITCOUNT=(EDITCOUNT+1) where POLNO=" + polno + " and MOS='" + mos + "'";
            dm.insertRecords(oldchildprotedit);

            string nomineeupd = "update LUND.NOMINEE set NOMNAM='" + payee + "' where POLNO=" + polno + " and NOMNO=1";
            dm.insertRecords(nomineeupd);

            dm.commit();
            lblMessage.Visible = true;
        }
        catch (Exception Ex)
        {
            dm.rollback();
            dm.connclose();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");
        }
    }
}
