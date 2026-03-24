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

public partial class docsCallPremsSin001 : System.Web.UI.Page
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
        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        return datetime;

    }

    private int polno;
    private string MOF;
    private string dc;
   
    private long cliamNo;
    private string nod;
    private string soldierNo;
    private string regiment;
    private string placeOfDeath;

    private  string prem;
    private string gebasa;

    private  int DCO;
    private string LPayDate;
    private  int due;

    private string copy1;
    private string copy2;
    private string copy3;
    private string copy4;
    private string copy5;
    private string copy6;
    private string copy7;
    //private string copy8;

    private int dateofdeath = 0;


    private ArrayList MonthlyIns;

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;
            dc = this.PreviousPage.CallDC;
        }


      

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                this.lblpolno.Text = polno.ToString();

                string DNOD = "";
              

                #region
                string dthintSelect = "select DNOD, DCLM, ddtofdth from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                        if (!dthintReader.IsDBNull(2)) { dateofdeath = dthintReader.GetInt32(2); }
                    }
                    dthintReader.Close();
                }
                #endregion

                #region

                string LpaydateSele = "select to_char(to_date(lldat,'yyyy/mm/dd'),'yyyy/mm/dd') from lclm.ledger where llpol = " + polno + " ";
                if (dm.existRecored(LpaydateSele) != 0)
                {
                    dm.readSql(LpaydateSele);
                    OracleDataReader premreader = dm.oraComm.ExecuteReader();
                    while (premreader.Read())
                    {
                        if (!premreader.IsDBNull(0)) { LPayDate = premreader.GetString(0); } else { LPayDate = ""; }
                    }
                    premreader.Close();
                }
                txtLPayDate.Text = LPayDate.ToString();
                string premSele = "select pmprm, pmcom, pmdue from lphs.premast where pmpol = " + polno + " ";
                if (dm.existRecored(premSele) != 0)
                {
                    dm.readSql(premSele);
                    OracleDataReader premreader = dm.oraComm.ExecuteReader();
                    while (premreader.Read())
                    {
                        if (!premreader.IsDBNull(0)) { prem = premreader.GetDouble(0).ToString(); } else { prem = ""; }
                        if (!premreader.IsDBNull(1)) { DCO = premreader.GetInt32(1); } else { DCO = 0; }
                        if (!premreader.IsDBNull(2)) { due = premreader.GetInt32(2); } else { due = 0; }
                    }
                    premreader.Close();
                }
                else
                {
                    string lapsSele = "select lpprm, lpcom, lpdue from lphs.liflaps where lppol = " + polno + " ";
                    if (dm.existRecored(lapsSele) != 0)
                    {
                        dm.readSql(lapsSele);
                        OracleDataReader lapseader = dm.oraComm.ExecuteReader();
                        while (lapseader.Read())
                        {
                            if (!lapseader.IsDBNull(0)) { prem = lapseader.GetDouble(0).ToString(); } else { prem = ""; }
                            if (!lapseader.IsDBNull(1)) { DCO = lapseader.GetInt32(1); } else { DCO = 0; }
                            if (!lapseader.IsDBNull(2)) { due = lapseader.GetInt32(2); } else { due = 0; }
                        }
                        lapseader.Close();
                    }
                    else 
                    {
                        string polhisSele = "select phprm, phcom, phdue from lphs.lpolhis where phpol = " + polno + " ";
                        if (dm.existRecored(polhisSele) != 0)
                        {
                            dm.readSql(polhisSele);
                            OracleDataReader polhiseader = dm.oraComm.ExecuteReader();
                            while (polhiseader.Read())
                            {
                                if (!polhiseader.IsDBNull(0)) { prem = polhiseader.GetDouble(0).ToString(); } else { prem = ""; }
                                if (!polhiseader.IsDBNull(1)) { DCO = polhiseader.GetInt32(1); } else { DCO = 0; }
                                if (!polhiseader.IsDBNull(2)) { due = polhiseader.GetInt32(2); } else { due = 0; }
                            }
                            polhiseader.Close();
                        }
                        else { throw new Exception("No Policy Details"); }
                       
                    }
                }

                //#endregion
                //string LANG = "S";
                //int INDEX = 0;
                //#region Load Claimnt Address(modified By Kumudu)
                //string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX=" + INDEX + "";
                //if (dm.existRecored(dclmAddressSelect) != 0)
                //{
                //    txtcopy1.Text = "oekquz  fokakd";
                //    dm.readSql(dclmAddressSelect);
                //    OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                //    while (dthintReader.Read())
                //    {
                //        if (!dthintReader.IsDBNull(0)) { txtcopy5.Text = dthintReader.GetString(0); }
                //        else { txtcopy5.Text = ""; }
                //        if (!dthintReader.IsDBNull(1)) { txtcopy6.Text = dthintReader.GetString(1); }
                //        else { txtcopy6.Text = ""; }
                //        if (!dthintReader.IsDBNull(2)) { txtcopy7.Text = dthintReader.GetString(2); }
                //        else { txtcopy7.Text = ""; }
                //        if (!dthintReader.IsDBNull(3)) { txtcopy8.Text = dthintReader.GetString(3); }
                //        else { txtcopy8.Text = ""; }
                //        if (!dthintReader.IsDBNull(4)) { txtcopy8.Text = dthintReader.GetString(3) + dthintReader.GetString(4); }
                //        else { txtcopy8.Text = dthintReader.GetString(3); }

                //    }

                //}

                string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX = 0";
                if (dm.existRecored(dclmaddressSelect) != 0)
                {
                    dm.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        //if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
                        //if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader.IsDBNull(2)) { TxtName.Text = dclmAdReader.GetString(2); } else { TxtName.Text = ""; }
                        if (!dclmAdReader.IsDBNull(3)) { txtcopy1.Text = dclmAdReader.GetString(3); } else { txtcopy1.Text = ""; }
                        if (!dclmAdReader.IsDBNull(4)) { txtcopy2.Text = dclmAdReader.GetString(4); } else { txtcopy2.Text = ""; }
                        if (!dclmAdReader.IsDBNull(5)) { txtcopy3.Text = dclmAdReader.GetString(5); } else { txtcopy3.Text = ""; }
                        if (!dclmAdReader.IsDBNull(6)) { txtcopy4.Text = dclmAdReader.GetString(6); } else { txtcopy4.Text = ""; }

                    }
                    dclmAdReader.Close();

                }
                else
                {

                    string dthintSelect1 = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect1) != 0)
                    {
                        dm.readSql(dthintSelect1);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { TxtName.Text = dthintReader.GetString(0); }
                            if (!dthintReader.IsDBNull(1)) { txtcopy1.Text = dthintReader.GetString(1); }
                            if (!dthintReader.IsDBNull(2)) { txtcopy2.Text = dthintReader.GetString(2); }
                            if (!dthintReader.IsDBNull(3)) { txtcopy3.Text = dthintReader.GetString(3); }
                            if (!dthintReader.IsDBNull(4)) { txtcopy4.Text = dthintReader.GetString(4); }
                            //if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5); }
                            //if (!dthintReader.IsDBNull(6)) { LtClmno.Text = dthintReader.GetInt64(6).ToString(); }
                        }
                        dthintReader.Close();
                    }
                }
                #endregion


                this.txtprm.Text = prem;
                this.lbldco.Text = DCO.ToString().Substring(0, 4) + "/" + DCO.ToString().Substring(4, 2) + "/" + DCO.ToString().Substring(6, 2);
                this.txtexityrmn.Text = due.ToString().Substring(0, 4) + "/" + due.ToString().Substring(4, 2);
                this.lblourref.Text = cliamNo.ToString();

                if (dateofdeath > 0)
                {
                    this.lbdtofdth.Text = dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2);
                }
                this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
               // this.txtnod.Text = DNOD;

                if (dc.Equals("Army"))
                {
                    this.litname.Text = "wOHCI ^jegqma yd f,aLK&";
                    this.litad1.Text = "hqo yuqod jegqma yd f,aLK ldhH_d,h";
                    this.litad2.Text = "hqo yuqod ckmoh";
                    this.litad3.Text = "mkdf.dv";
                    this.litad4.Text = "fydaud.u";

                    this.Literal1.Visible = true;
                    this.litDir.Visible = true;
                    this.litadd.Visible = true;
                    this.litSubasadaka.Visible = true;
                    this.Ltadd2.Visible = true;
                    this.LtAdd3.Visible = true;
                    this.txtcopy7.Visible = true;
                }
                else if (dc.Equals("Navy"))
                {
                    this.litname.Text = "fcHIaG udKav,sl ks,OdrS iqNidOl";
                    this.litad1.Text = "kdjsl iqNidOl wOHCI fjkqjg";
                    this.litad2.Text = "YS% ,xld kdjsl yuqod uQ,ia:dkh";
                    this.litCol.Visible = true;
                    this.litad3.Text = " ";
                }
                else if (dc.Equals("Air"))
                {
                    this.litname.Text = "rlaIK wxYNdr ks,Odrs";
                    this.litad1.Text = "rlaIK wxYh";
                    this.litad2.Text = "Y%S ,xld .+jkayuqod uQ,ia:dkh";
                    this.litCol.Visible = true;
                    this.litad3.Text = " ";
                }


                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["dc"] = dc;

                ViewState["prem"] = prem;
                ViewState["DCO"] = DCO;
                ViewState["due"] = due;
                ViewState["LastPay"] = LPayDate;
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("~/EPage.aspx");
            }

        }
        else
        {
            if (txtNoofDefPrm.Text != "")
            {
                CreateDynTextBox(int.Parse(txtNoofDefPrm.Text));
            }

            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["dc"] != null) { dc = ViewState["dc"].ToString(); }

            if (ViewState["prem"] != null) { prem = ViewState["prem"].ToString(); }
            if (ViewState["DCO"] != null) { DCO = int.Parse(ViewState["DCO"].ToString()); }
            if (ViewState["due"] != null) { due = int.Parse(ViewState["due"].ToString()); }
            if(ViewState["LastPay"]!=null){LPayDate=ViewState["LastPay"].ToString();}
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        nod = this.txtnod.Text.Trim();
        soldierNo = this.txtsoldierno.Text.Trim();
        placeOfDeath = this.txtplaceofdth.Text.Trim();
        prem = this.txtprm.Text.Trim();
        regiment = this.txtregiment.Text.Trim();
        gebasa = this.txtgebasa.Text.Trim();
        dateofdeath = int.Parse(this.lbdtofdth.Text.Replace("/", ""));
        cliamNo = int.Parse(this.lblourref.Text);
        LPayDate = txtLPayDate.Text.Replace("/", "");
        Due = int.Parse(txtexityrmn.Text.Replace("/",""));
        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
        copy5 = this.txtcopy5.Text.Trim();
        copy6 = this.TxtText.Text.Trim();
        copy7 = this.txtcopy7.Text.Trim();
        //copy8 = this.txtcopy8.Text.Trim();

        if (txtNoofDefPrm.Text != "")
        {
            int Count = int.Parse(txtNoofDefPrm.Text);

            MonthlyIns = new ArrayList();
            for (int i = 0; i < Count; i++)
            {
                MonthlyIns.Add(((TextBox)this.tblDynamic.FindControl("DyTextBox" + i.ToString())).Text);
                MonthlyIns.Add(((TextBox)this.tblDynamic.FindControl("DyTextBox1" + i.ToString())).Text);
            }
        
       //  string s = ((TextBox)this.tblDynamic.FindControl("DyTextBox1")).Text;
        }

        Server.Transfer("~/letters/docsCallPremsSin002.aspx",false);
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mos
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public string CallDC
    {
        get { return dc; }
        set { dc = value; }
    }
    public string Nod
    {
        get { return nod; }
        set { nod = value; }
    }
    public string SoldierNo
    {
        get { return soldierNo; }
        set { soldierNo = value; }
    }

    public string Prem
    {
        get { return prem; }
        set { prem = value; }
    }
    public int dCO
    {
        get { return DCO; }
        set { DCO = value; }
    }
    public int Due
    {
        get { return due; }
        set { due = value; }
    }

    public string  LastPayDate
    {
        get { return LPayDate; }
        set { LPayDate = value; }
    }
    public string Regiment
    {
        get { return regiment; }
        set { regiment = value; }
    }
    public int DateofDeath
    {
        get { return dateofdeath; }
        set { dateofdeath = value; }
    }
    public string PlaceOfDeath
    {
        get { return placeOfDeath; }
        set { placeOfDeath = value; }
    }
    public string Gebasa
    {
        get { return gebasa; }
        set { gebasa = value; }
    }
    public long CliamNo
    {
        get { return cliamNo; }
        set { cliamNo = value; }
    }

    public string Copy1
    {
        get { return copy1; }
        set { copy1 = value; }
    }
    public string Copy2
    {
        get { return copy2; }
        set { copy2 = value; }
    }
    public string Copy3
    {
        get { return copy3; }
        set { copy3 = value; }
    }
    public string Copy4
    {
        get { return copy4; }
        set { copy4 = value; }
    }
    public string Copy5
    {
        get { return copy5; }
        set { copy5 = value; }
    }
    public string Copy6
    {
        get { return copy6; }
        set { copy6 = value; }
    }
    public string Copy7
    {
        get { return copy7; }
        set { copy7 = value; }
    }
    //public string Copy8
    //{
    //    get { return copy8; }
    //    set { copy8 = value; }
    //}

    public ArrayList MONTHLYINST
    {
        get { return MonthlyIns; }
        set { MonthlyIns = value; }
    }
    private int state = 0;

    public int State
    {
        get { return state; }
        set { state = value; }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int NofoDefPrms = int.Parse(txtNoofDefPrm.Text);
      //CreateDynTextBox(NofoDefPrms);

    }

    #region Generate Text Boxes for Defauul Prem1ums
    public void CreateDynTextBox(int Count)
    {
        for (int i = 0; i < Count; i++)
        {

            TableRow tr = new TableRow();
            tblDynamic.Rows.Add(tr);
            TableCell tc1 = new TableCell();
            TextBox DyTextBox = new TextBox();
            DyTextBox.ID = "DyTextBox" + i.ToString();
            DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
            DyTextBox.ControlStyle.Font.Size = 11;
            DyTextBox.Width = 150;
            tc1.Controls.Add(DyTextBox);
            tr.Cells.Add(tc1);

            TableCell tc2 = new TableCell();
            Label Dynlbl = new Label();
            Dynlbl.ID = "Dynlbl" + i.ToString();
            Dynlbl.Text = "isg";
            Dynlbl.ControlStyle.Font.Name = "Sandaya";
            Dynlbl.ControlStyle.Font.Size = 11;
            Dynlbl.Width = 50;
            tc2.Controls.Add(Dynlbl);
            tr.Cells.Add(tc2);

            TableCell tc3 = new TableCell();
            TextBox DyTextBox1 = new TextBox();
            DyTextBox1.ID = "DyTextBox1" + i.ToString();
            DyTextBox1.ControlStyle.Font.Name = "Trebuchet MS";
            DyTextBox1.ControlStyle.Font.Size = 11;
            DyTextBox1.Width = 150;
            tc3.Controls.Add(DyTextBox1);
            tr.Cells.Add(tc3);

            TableCell tc4 = new TableCell();
            Label Dynlbl1 = new Label();
            Dynlbl1.ID = "Dynlbl1" + i.ToString();
            Dynlbl1.Text = "olajd";
            Dynlbl1.ControlStyle.Font.Name = "Sandaya";
            Dynlbl1.ControlStyle.Font.Size = 11;
            Dynlbl1.Width = 50;
            tc4.Controls.Add(Dynlbl1);
            tr.Cells.Add(tc4);

            tblDynamic.Rows.Add(tr);
           // tblDynamic.Rows.Add(tr);


        }
    }
    #endregion

    protected void Button1_Click(object sender, EventArgs e)
    {
        state = 1;
        nod = this.txtnod.Text.Trim();
        soldierNo = this.txtsoldierno.Text.Trim();
        placeOfDeath = this.txtplaceofdth.Text.Trim();
        prem = this.txtprm.Text.Trim();
        regiment = this.txtregiment.Text.Trim();
        gebasa = this.txtgebasa.Text.Trim();
        dateofdeath = int.Parse(this.lbdtofdth.Text.Replace("/", ""));
        cliamNo = int.Parse(this.lblourref.Text);
        LPayDate = txtLPayDate.Text.Replace("/", "");
        Due = int.Parse(txtexityrmn.Text.Replace("/", ""));
        copy1 = this.txtcopy1.Text.Trim();
        copy2 = this.txtcopy2.Text.Trim();
        copy3 = this.txtcopy3.Text.Trim();
        copy4 = this.txtcopy4.Text.Trim();
        copy5 = this.txtcopy5.Text.Trim();
        copy6 = this.TxtText.Text.Trim();
        copy7 = this.txtcopy7.Text.Trim();
        //copy8 = this.txtcopy8.Text.Trim();

        if (txtNoofDefPrm.Text != "")
        {
            int Count = int.Parse(txtNoofDefPrm.Text);

            MonthlyIns = new ArrayList();
            for (int i = 0; i < Count; i++)
            {
                MonthlyIns.Add(((TextBox)this.tblDynamic.FindControl("DyTextBox" + i.ToString())).Text);
                MonthlyIns.Add(((TextBox)this.tblDynamic.FindControl("DyTextBox1" + i.ToString())).Text);
            }

            //  string s = ((TextBox)this.tblDynamic.FindControl("DyTextBox1")).Text;
        }

        Server.Transfer("~/letters/docsCallPremsSin002.aspx", false);
    }
}
