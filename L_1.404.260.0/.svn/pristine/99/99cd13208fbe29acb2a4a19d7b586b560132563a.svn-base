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

public partial class letters_CoveringLetter_MiniuthuSinhala001 : System.Web.UI.Page
{
    int INDEX = 0;
    string LANG = "";
    private long dob, nomdob, age = 0, nomAge = 0;
    private int polno;
    private string MOF;
    private bool signatureDisplay;
    private bool isDeferentLetter;
    private string EPF;

    private string nomname;
    private string childname;
    private int val;
    polpersonalread polperobj;
    DataManager dm;

    private string dueYear = String.Empty;

    public int PolNo
    {
        get { return polno; }
        set { polno = value; }
    }

    public string DueYear
    {
        get { return dueYear; }
        set { dueYear = value; }
    }

    private string dateOfBefore = String.Empty;

    public string DateOfBefore
    {
        get { return dateOfBefore; }
        set { dateOfBefore = value; }
    }

    private string ad1;

    public string Ad1
    {
        get { return ad1; }
        set { ad1 = value; }
    }

    private string ad2;

    public string Ad2
    {
        get { return ad2; }
        set { ad2 = value; }
    }

    private string ad3;

    public string Ad3
    {
        get { return ad3; }
        set { ad3 = value; }
    }

    private string ad4;

    public string Ad4
    {
        get { return ad4; }
        set { ad4 = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int claimNo;

    public int ClaimNo
    {
        get { return claimNo; }
        set { claimNo = value; }
    }

    private string nameOfDeath;

    public string NameOfDeath
    {
        get { return nameOfDeath; }
        set { nameOfDeath = value; }
    }

    private string txt1;

    public string TXT1
    {
        get { return txt1; }
        set { txt1 = value; }
    }

    private string txt2;

    public string TXT2
    {
        get { return txt2; }
        set { txt2 = value; }
    }

    private string brname;

    public string BrName
    {
        get { return brname; }
        set { brname = value; }
    }

    public bool SIGNATUREDISPLAY
    {
        get { return signatureDisplay; }
        set { signatureDisplay = value; }
    }
    public bool IsDeferentLetter
    {
        get { return isDeferentLetter; }
        set { isDeferentLetter = value; }
    }
    public string Childname
    {
        get { return childname; }
        set { childname = value; }
    }
    public int Val
    {
        get { return val; }
        set { val = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["polino"] != null)
            polno = int.Parse(Request.QueryString["polino"]);

        if (Request.QueryString["lifeType"] != null)
            MOF = Request.QueryString["lifeType"];

        if (Request.QueryString["SignatureDisplay"] != null)
            signatureDisplay = bool.Parse(Request.QueryString["SignatureDisplay"]);





        #region Add signature 

        if (signatureDisplay)
        {
            lblSignature.Visible = true;
            lblName.Visible = true;
            lblepf.Visible = true;
            lblDesig.Visible = true;
            lbldip.Visible = true;
            lblComp.Visible = true;


            if (Session["EPFNum"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }

            else
            {
                Response.Redirect("SessionError.aspx");
            }

            if (EPF != "")
            {
                SignatureData signatureData = new SignatureData();
                signatureData = signatureData.getSignature(EPF);
                if (signatureData.Signature != null)
                    if (signatureData.Signature != null)
                    {
                        lblSignature.Visible = true;
                        string ImageName = EPF.PadLeft(5, '0') + "_sign.png";
                        System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                        SignatureImage.ImageUrl = "~/image/" + ImageName;
                       
                    }
                    else
                {
                    lblSignature.Visible = false;
                }
                this.lblName.Text = signatureData.UserName + " ";
                this.lbldip.Text = "Life Insurance Section";
                this.lblComp.Text = "Sri Lanka Insurance Corporation Life Ltd";
                this.lblepf.Text = "( " + signatureData.EPF + " )";

                if (signatureData.Role != null)
                {
                    this.lblDesig.Text = signatureData.Role;
                }
                else
                {
                    this.lblDesig.Text = "Authorized Officer";
                }
            }
        }
        #endregion


        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            //string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'E' and INDX = 0";
            //if (dm.existRecored(dclmaddressSelect) != 0)
            //{
            //    dm.readSql(dclmaddressSelect);
            //    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //    while (dclmAdReader.Read())
            //    {
            //        if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
            //        if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
            //        if (!dclmAdReader.IsDBNull(2)) { litname.Text = dclmAdReader.GetString(2); } else { litname.Text = ""; }
            //        if (!dclmAdReader.IsDBNull(3)) { litad1.Text = dclmAdReader.GetString(3); } else { litad1.Text = ""; }
            //        if (!dclmAdReader.IsDBNull(4)) { litad2.Text = dclmAdReader.GetString(4); } else { litad2.Text = ""; }
            //        if (!dclmAdReader.IsDBNull(5)) { litad3.Text = dclmAdReader.GetString(5); } else { litad3.Text = ""; }
            //        if (!dclmAdReader.IsDBNull(6)) { litad4.Text = dclmAdReader.GetString(6); } else { litad4.Text = ""; }

            //        if (INDEX == 0)
            //        {
            //            // this.litname.Text = NAME;
            //            // this.litad1.Text = ADDRESS1;
            //            // this.litad2.Text = ADDRESS2;
            //            //  this.litad3.Text = ADDRESS3;
            //            // this.litad4.Text = ADDRESS4;
            //        }
            //        else if (INDEX == 1)
            //        {
            //            // if ((NAME != null) && (!NAME.Equals(""))) { this.litcopy1.Visible = true; }

            //            //this.litcopy1.Text = NAME + ", " + ADDRESS1 + " " + ADDRESS2 + " " + ADDRESS3 + " " + ADDRESS4;
            //        }
            //    }
            //    dclmAdReader.Close();

            //    string dthintSelect = "select DNOD, DCLM,DINAME from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
            //    if (dm.existRecored(dthintSelect) != 0)
            //    {
            //        dm.readSql(dthintSelect);
            //        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //        while (dthintReader.Read())
            //        {
            //            //if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
            //            //if (!dthintReader.IsDBNull(1)) { LtClmno.Text = dthintReader.GetInt64(1).ToString(); }
            //            if (!dthintReader.IsDBNull(2)) { litnameofdead.Text = dthintReader.GetString(2); }
            //        }
            //        dthintReader.Close();
            //    }

            //    //this.litnameofdead.Text = DNOD;
            //    //this.litourref.Text = cliamNo.ToString();
            //    //this.lblyrref.Text = epfStr;
            //    this.litdate.Text = DateTime.Now.ToString("yyyy/MM/dd");



            //}
            //else
            //{

            //string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
            //if (dm.existRecored(dthintSelect) != 0)
            //{
            //    dm.readSql(dthintSelect);
            //    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            //    while (dthintReader.Read())
            //    {
            //        if (!dthintReader.IsDBNull(0)) { litnameofdead.Text = dthintReader.GetString(0); }
            //        if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); }
            //        if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); }
            //        if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); }
            //        if (!dthintReader.IsDBNull(4)) { litad4.Text = dthintReader.GetString(4); }
            //        //if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5); }
            //        if (!dthintReader.IsDBNull(6)) { LtClmno.Text = dthintReader.GetInt64(6).ToString(); }
            //    }
            //    dthintReader.Close();
            //}
            //else
            //{

            ViewState["signatureDisplay"] = signatureDisplay;

            OldChildProtRead objAddress = new OldChildProtRead(polno, dm);
            polpersonalread ppr = new polpersonalread(polno);
            DateDifference objdd;




            //seclife = ppr.Secfname;
            #region Task 39452
            if(ppr.Cdob != 0)
            {
                dob = ppr.Cdob;
            }
            else
            {
                dob = ppr.Secdob;
            }
            
            nomname = ppr.Nomname;
            nomdob = ppr.Nomdob;
            if (dob > 0)
            {
                objdd = new DateDifference(int.Parse(dob.ToString()), 0);
                age = objdd.Years;
            }
            if (nomdob > 0)
            {
                objdd = new DateDifference(int.Parse(nomdob.ToString()), 0);
                nomAge = objdd.Years;
            }
            if (age < 18 && (nomname == null || nomAge < 18))
            {
                dm = new DataManager();
                string paidval = "select distinct PAID_AMT from LCLM.PERIODIC_PAYDET where (CLMTYPE='DTC' or CLMTYPE='DOC') and POLNO=" + polno + "";
                if (dm.existRecored(paidval) != 0)
                {
                    dm.readSql(paidval);
                    OracleDataReader exsurenReader = dm.oraComm.ExecuteReader();
                    while (exsurenReader.Read())
                    {
                        if (!exsurenReader.IsDBNull(0)) { val = exsurenReader.GetInt32(0); } else { val = 0; }
                    }
                }
                childname = ppr.Child;
                pan1.Visible = false;
                pan2.Visible = true;
                this.lblchild.Text = childname;
                this.lblval.Text = val.ToString()+".00";
                isDeferentLetter = true;
            }
            #endregion

            ViewState["isDeferentLetter"] = isDeferentLetter;
            ViewState["childname"] = childname;
            ViewState["val"] = val;

            if (objAddress.Exist == 1)
            {
                litname.Text = objAddress.NAME;
                litad1.Text = objAddress.Ad1;
                litad2.Text = objAddress.Ad2;
                litad3.Text = objAddress.Ad3;
                litad4.Text = objAddress.Ad4;
                LtClmno.Text = objAddress.Clmno.ToString();
            }
            else
            {
                //if (dob > 0)
                //{
                //    objdd = new DateDifference(int.Parse(dob.ToString()), 0);
                //    age = objdd.Years;
                //}
                //if (age >= 18) { this.litname.Text = seclife.ToString(); }
                //else { this.litname.Text = nomname.ToString(); }
                objAddress.Addressfetch(polno, 0, dm);
                litname.Text = objAddress.NAME;
                litad1.Text = objAddress.Ad1;
                litad2.Text = objAddress.Ad2;
                litad3.Text = objAddress.Ad3;
                litad4.Text = objAddress.Ad4;
                //LtClmno.Text = objAddress.Clmno.ToString();
                string dthintSelect = "select DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (dm.existRecored(dthintSelect) != 0)
                {
                    dm.readSql(dthintSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        //if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(0)) { LtClmno.Text = dthintReader.GetInt64(0).ToString(); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }
            }

            string sql = "select  pnsta, pnint,PNSUR from LPHS.PHNAME where pnpol='" + polno + "'";
            if (dm.existRecored(sql) != 0)
            {
                dm.readSql(sql);
                OracleDataReader oraDtReader = dm.oraComm.ExecuteReader();

                while (oraDtReader.Read())
                {
                    string status = "";
                    string initials = "";
                    string surname = "";
                    if (!oraDtReader.IsDBNull(0))
                        status = oraDtReader.GetString(0);
                    if (!oraDtReader.IsDBNull(1))
                        initials = oraDtReader.GetString(1);
                    if (!oraDtReader.IsDBNull(2))
                        surname = oraDtReader.GetString(2);

                    litnameofdead.Text = status + " " + initials + " " + surname;
                }
                oraDtReader.Close();
                //oraDtReader.Dispose();
            }
            // }


            //this.litnameofdead.Text = DNOD;
            //this.lblyrref.Text = epfStr;
            //this.litourref.Text = cliamNo.ToString();
            this.litdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.litpolno.Text = polno.ToString();

            //}
        }
        else
        {
            if (ViewState["SignatureDisplay"] != null) { signatureDisplay = bool.Parse(ViewState["signatureDisplay"].ToString()); }
            if (ViewState["isDeferentLetter"] != null) { isDeferentLetter = bool.Parse(ViewState["isDeferentLetter"].ToString()); }
            if (ViewState["val"] != null) { val = int.Parse(ViewState["val"].ToString()); }
            if (ViewState["childname"] != null) { childname = ViewState["childname"].ToString(); }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        dueYear = TxtDue.Text.Trim();
        if (isDeferentLetter)
        {
            dueYear = TxtDue2.Text.Trim();
        }
        dateOfBefore = TxtDate.Text.Trim();
        ad1 = litad1.Text.Trim();
        ad2 = litad2.Text.Trim();
        ad3 = litad3.Text.Trim();
        ad4 = litad4.Text.Trim();
        name = litname.Text.Trim();
        claimNo = Convert.ToInt32(LtClmno.Text.Trim());
        polno = Convert.ToInt32(litpolno.Text.Trim());
        nameOfDeath = litnameofdead.Text.Trim();
        txt1 = Txt1.Text.Trim();
        txt2 = Txt2.Text.Trim();
        brname = TxtBranch.Text.Trim();
        

        Server.Transfer("~/letters/CoveringLetter-MiniuthuSinhala002.aspx", true);
    }
}
