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

public partial class legalHieres002 : System.Web.UI.Page
{
    private bool nomiLives;
    private bool married;
    private bool spouceAilve;
    private bool motherAlive;
    private bool fatherAlive;
    private bool livingChildren;
    private int numOfchildren;
    private bool livingBroSis;
    private int numOfBroSis;
    private double totshare;

    //private bool valid;
    private int polno;
    private string MOF, flag;

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
    string epf = "";
    DataManager dm;

    private double totamount;
    private double outAmt;
    private long claimno;
    private int pageflag;

    protected void Page_Load(object sender, EventArgs e)
    {
        //epf = Session["EPFNum"].ToString();

        if (Session["EPFNum"] != null)
        {
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            EPage.Messege = "Your Session Variable Expired Please Log on to the System!";
            Response.Redirect("~/EPage.aspx");
            //throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
            pageflag = this.PreviousPage.Pageflag;
            flag = this.PreviousPage.Flag;
            
            totamount = this.PreviousPage.Totamount;
            outAmt = this.PreviousPage.OutAmt;
            claimno = this.PreviousPage.Claimno;

            nomiLives = this.PreviousPage.NomiLives;
            married = this.PreviousPage.Married;
            spouceAilve = this.PreviousPage.SpouceAilve;
            motherAlive = this.PreviousPage.MotherAlive;
            fatherAlive = this.PreviousPage.FatherAlive;
            livingChildren = this.PreviousPage.LivingChildren;
            numOfchildren = this.PreviousPage.NumOfchildren;
            livingBroSis = this.PreviousPage.LivingBroSis;
            numOfBroSis = this.PreviousPage.NumOfBroSis;          
        }
       // if (!Page.IsPostBack) {
        dm = new DataManager();
            try
            {
                #region ----------- view state --------
                if (!Page.IsPostBack)
                {
                    ViewState["polno"] = polno;
                    ViewState["MOF"] = MOF;

                    ViewState["totamount"] = totamount;
                    ViewState["outAmt"] = outAmt;
                    ViewState["claimno"] = claimno;
                    ViewState["flag"] = flag;
                    ViewState["pageflag"] = pageflag;
                    ViewState["nomiLives"] = nomiLives;
                    ViewState["married"] = married;
                    ViewState["spouceAilve"] = spouceAilve;
                    ViewState["motherAlive"] = motherAlive;
                    ViewState["fatherAlive"] = fatherAlive;
                    ViewState["livingChildren"] = livingChildren;
                    ViewState["numOfchildren"] = numOfchildren;
                    ViewState["livingBroSis"] = livingBroSis;
                    ViewState["numOfBroSis"] = numOfBroSis;

                }
                else
                {
                    if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                    if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }

                    if (ViewState["nomiLives"] != null) { nomiLives = (bool)ViewState["nomiLives"]; }
                    if (ViewState["married"] != null) { married = (bool)ViewState["married"]; }
                    if (ViewState["spouceAilve"] != null) { spouceAilve = (bool)ViewState["spouceAilve"]; }
                    if (ViewState["motherAlive"] != null) { motherAlive = (bool)ViewState["motherAlive"]; }
                    if (ViewState["fatherAlive"] != null) { fatherAlive = (bool)ViewState["fatherAlive"]; }
                    if (ViewState["livingChildren"] != null) { livingChildren = (bool)ViewState["livingChildren"]; }
                    if (ViewState["numOfchildren"] != null) { numOfchildren = (int)ViewState["numOfchildren"]; }
                    if (ViewState["livingBroSis"] != null) { livingBroSis = (bool)ViewState["livingBroSis"]; }
                    if (ViewState["numOfBroSis"] != null) { numOfBroSis = (int)ViewState["numOfBroSis"]; }
                    if (ViewState["pageflag"] != null) { pageflag = int.Parse(ViewState["pageflag"].ToString()); }
                    if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
                    if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                    if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
                    if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
                }
                #endregion

                string heireSS = "";

                if (flag != null && !flag.Equals("")) { this.btnexit.Visible = false; this.btnshares.Visible = true; }
                else { this.btnexit.Visible = true; this.btnshares.Visible = false; }

                #region //--------- making controls invisible ------------------
                if (nomiLives) throw new Exception("Nominee Exists! Please Pay to Nominee.");
                if (!married || !spouceAilve) { 
                    this.lblwidow.Visible = false;
                    this.txtwidowName.Visible = false;
                    this.lblwidowaddr.Visible = false;
                    this.txtwidowAd1.Visible = false;
                    this.txtwidowAd2.Visible = false;
                    this.txtwidowAd3.Visible = false;
                    this.txtwidowAd4.Visible = false;
                    this.lblwidowDOB.Visible = false;
                    this.txtwidowDOB.Visible = false;
                    this.lblwidowshare.Visible = false;
                    this.txtWodowshare.Visible = false;
                    Literal1.Visible = false;
                }
                if (!motherAlive) {
                    this.lblmother.Visible = false;
                    this.txtmothersName.Visible = false;
                    this.lblmothersresi.Visible = false;
                    this.txtmothersAd1.Visible = false;
                    this.txtmothersAd2.Visible = false;
                    this.txtmothersAd3.Visible = false;
                    this.txtmothersAd4.Visible = false;
                    this.lblmotherdob.Visible = false;
                    this.txtmothersDOB.Visible = false;
                    this.lblMothershare.Visible = false;
                    this.txtMothershare.Visible = false;
                    Literal2.Visible = false;
                }
                if (!fatherAlive) {
                    this.lblfather.Visible = false;
                    this.txtfathersName.Visible = false;
                    this.lblfatherResi.Visible = false;
                    this.txtfathersAd1.Visible = false;
                    this.txtfathersAd2.Visible = false;
                    this.txtfathersAd3.Visible = false;
                    this.txtfathersAd4.Visible = false;
                    this.lblfatherDOB.Visible = false;
                    this.txtfathersDOB.Visible = false;
                    this.lblFathershare.Visible = false;
                    this.txtFathershare.Visible = false;
                    Literal3.Visible = false;
                }
                if (!livingChildren) { this.lblchidren.Visible = false; }
                if (!livingBroSis) { this.lblbroandsys.Visible = false; }

                #endregion

                #region //--------- checking for previous heire details --------
                
      
                string lhSelect = "select lhhno, lhhire from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' ";
                if (dm.existRecored(lhSelect) != 0)
                {
                    dm.readSql(lhSelect);
                    OracleDataReader lhReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lhReader.Read())
                    {
                        if (!lhReader.IsDBNull(1)) { heireSS = lhReader.GetString(1); }

                        if (heireSS.Equals("Mother"))
                        {
                            this.lblmother.Visible = true;
                            this.txtmothersName.Visible = true;
                            this.lblmothersresi.Visible = true;
                            this.txtmothersAd1.Visible = true;
                            this.txtmothersAd2.Visible = true;
                            this.txtmothersAd3.Visible = true;
                            this.lblmotherdob.Visible = true;
                            this.txtmothersDOB.Visible = true;
                            this.lblMothershare.Visible = true;
                            this.txtMothershare.Visible = true;                            
                            Literal2.Visible = true;
                        }
                        else if (heireSS.Equals("Father"))
                        {
                            this.lblfather.Visible = true;
                            this.txtfathersName.Visible = true;
                            this.lblfatherResi.Visible = true;
                            this.txtfathersAd1.Visible = true;
                            this.txtfathersAd2.Visible = true;
                            this.txtfathersAd3.Visible = true;
                            this.lblfatherDOB.Visible = true;
                            this.txtfathersDOB.Visible = true;
                            this.lblFathershare.Visible = true;
                            this.txtFathershare.Visible = true;                            
                            Literal3.Visible = true;
                        }
                        else if (heireSS.Equals("Spouce"))
                        {
                            this.lblwidow.Visible = true;
                            this.txtwidowName.Visible = true;
                            this.lblwidowaddr.Visible = true;
                            this.txtwidowAd1.Visible = true;
                            this.txtwidowAd2.Visible = true;
                            this.txtwidowAd3.Visible = true;
                            this.lblwidowDOB.Visible = true;
                            this.txtwidowDOB.Visible = true;
                            this.lblwidowshare.Visible = true;
                            this.txtWodowshare.Visible = true;
                            Literal1.Visible = true;
                        }

                    }
                    lhReader.Close();
                    lhReader.Dispose();
                }
                
                #endregion

                if (!married && spouceAilve) { throw new Exception("How can there be a spouce if the Deceased is not married!"); }

                if ((!spouceAilve) &&(!motherAlive) && (!fatherAlive) && (!livingChildren) && (!livingBroSis))
                {
                    dm.connclose();
                    throw new Exception("Deceased Hasn't Legal Hires Please Select Another Option!");
                }

                for (int i = 0; i < numOfchildren; i++)
                {
                    this.createChildrenTable(i);
                }
                for (int j = 0; j < numOfBroSis; j++)
                {
                    this.createBroSisTable(j);
                }
                dm.connclose();

              
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");            
            }
        
       // }
            
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        totshare = 0;
        DataManager dmr = new DataManager();         
        try
        {
            dmr.begintransaction();
            string lhSelect = "select lhhno, lhhire from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' ";
            if (dmr.existRecored(lhSelect) != 0)
            {
                string sqldelete = "Delete from lphs.legal_hires where lhpolno=" + polno + "";
                dmr.DeleteRecords(sqldelete);                   
                this.btnSubmit.Text = "Update";
            }
            else
            {
                this.btnSubmit.Text = "Save";
            }
            //dm.begintransaction();
            double shareamt;
            string hirenamme = "";
            int affidavitDate = 0;
            int HirNo = 0;
            if ((this.txtaffidavitDate.Text != null) && (!this.txtaffidavitDate.Equals(""))) { affidavitDate = int.Parse(this.txtaffidavitDate.Text); }

            dateValidation dv = new dateValidation();

            if (married && spouceAilve)
            {
                #region
                shareamt = (double.Parse(this.txtWodowshare.Text.Trim()))/100;
                totshare += shareamt;
                if (totshare > 1)
                {
                    throw new Exception("Share amount exceeds 100%");
                }
                string widowname = this.txtwidowName.Text.Trim();
                widowname = widowname.Replace('\'', ' ');
                string widowAddress1 = "";
                string widowAddress2 = "";
                string widowAddress3 = "";
                string widowAddress4 = "";

                if (txtwidowAd1.Text != "") { widowAddress1 = this.txtwidowAd1.Text.Trim(); }
                else { widowAddress1 = ""; }                
                if (txtwidowAd2.Text != ""){widowAddress2 = this.txtwidowAd2.Text.Trim();}
                else { widowAddress2 = ""; }
                if (txtwidowAd3.Text != "") { widowAddress3 = this.txtwidowAd3.Text.Trim(); }
                else { widowAddress3 = ""; }
                if (txtwidowAd3.Text != "") { widowAddress4 = this.txtwidowAd4.Text.Trim(); }
                else { widowAddress4 = ""; }
                widowAddress1 = widowAddress1.Replace('\'', ' ');
                widowAddress2 = widowAddress2.Replace('\'', ' ');
                widowAddress3 = widowAddress3.Replace('\'', ' ');
                widowAddress4 = widowAddress4.Replace('\'', ' ');
                int widowDOB = 0;
                if (this.txtwidowDOB.Text != "")
                {
                    if ((this.txtwidowDOB.Text != null) && (!this.txtwidowDOB.Text.Equals("")))
                    {
                        widowDOB = int.Parse(this.txtwidowDOB.Text);
                    }
                    if (!dv.dateValid(widowDOB.ToString()))
                    {
                        throw new Exception("Invalid Widow DOB");
                    }
                }
                else
                {
                    widowDOB = 0;
                }               
                
               if (this.btnSubmit.Text == "Save")
                {
                    lhInsert("Spouce", widowname, widowAddress1, widowAddress2, widowAddress3, widowAddress4, widowDOB, "M", affidavitDate, shareamt);
                }
                else
                {
                    HirNo++;
                    lhInsert("Spouce", widowname, widowAddress1, widowAddress2, widowAddress3, widowAddress4, widowDOB, "M", affidavitDate, shareamt);
                }
                #endregion
            }

            if (motherAlive)
            {
                #region
                string mothersName = this.txtmothersName.Text.Trim();
                shareamt = (double.Parse(this.txtMothershare.Text.Trim()))/100;
                totshare += shareamt;
                if (totshare > 1)
                {
                    throw new Exception("Share amount exceeds 100%");
                }
                mothersName = mothersName.Replace('\'', ' ');
                string mothersAddr1 = "";
                string mothersAddr2 = "";
                string mothersAddr3 = "";
                string mothersAddr4 = "";

                if (this.txtmothersAd1.Text != "") { mothersAddr1 = this.txtmothersAd1.Text.Trim(); }
                else { mothersAddr1 = ""; }
                if (this.txtmothersAd2.Text != "") { mothersAddr2 = this.txtmothersAd2.Text.Trim(); }
                else { mothersAddr2 = ""; }
                if (this.txtmothersAd3.Text != "") { mothersAddr3 = this.txtmothersAd3.Text.Trim(); }
                else { mothersAddr3 = ""; }
                if (this.txtmothersAd4.Text != "") { mothersAddr4 = this.txtmothersAd4.Text.Trim(); }
                else { mothersAddr4 = ""; }

                mothersAddr1 = mothersAddr1.Replace('\'', ' ');
                mothersAddr2 = mothersAddr2.Replace('\'', ' ');
                mothersAddr3 = mothersAddr3.Replace('\'', ' ');
                mothersAddr4 = mothersAddr4.Replace('\'', ' ');
               // if (!numeric(this.txtmothersDOB.Text)) { this.cvmother.IsValid = false; this.cvmother.Text = "Please enter a numeric Date of birth for Mother"; }
                int mothersDOB = 0;
                if (this.txtmothersDOB.Text != "")
                {
                    if ((this.txtmothersDOB.Text != null) && (!this.txtmothersDOB.Text.Equals(""))) { mothersDOB = int.Parse(this.txtmothersDOB.Text); }
                    if (!dv.dateValid(mothersDOB.ToString())) { throw new Exception("Invalid Mothers DOB"); }
                }
                else
                {
                    mothersDOB = 0;
                }
                    if (this.btnSubmit.Text == "Save")
                {
                    lhInsert("Mother", mothersName, mothersAddr1, mothersAddr2, mothersAddr3, mothersAddr4, mothersDOB, "M", affidavitDate, shareamt);
                }
                else
                {
                    HirNo++;
                    lhInsert("Mother", mothersName, mothersAddr1, mothersAddr2, mothersAddr3, mothersAddr4, mothersDOB, "M", affidavitDate, shareamt);
                }
                #endregion
            }
            if (fatherAlive)
            {
                #region
                string fathersName = this.txtfathersName.Text.Trim();
                fathersName = fathersName.Replace('\'', ' ');
                shareamt = (double.Parse(this.txtFathershare.Text.Trim()))/100;
                totshare += shareamt;
                if (totshare > 1)
                {
                    throw new Exception("Share amount exceeds 100%");
                }
                string fathersAddr1 = "";
                string fathersAddr2 = "";
                string fathersAddr3 = "";
                string fathersAddr4 = "";

                if (this.txtfathersAd1.Text != "") { fathersAddr1 = this.txtfathersAd1.Text.Trim(); }
                else { fathersAddr1 = ""; }
                if (this.txtfathersAd2.Text != "") { fathersAddr2 = this.txtfathersAd2.Text.Trim(); }
                else { fathersAddr2 = ""; }
                if (this.txtfathersAd3.Text != "") { fathersAddr3 = this.txtfathersAd3.Text.Trim(); }
                else { fathersAddr3 = ""; }
                if (this.txtfathersAd4.Text != "") { fathersAddr4 = this.txtfathersAd4.Text.Trim(); }
                else { fathersAddr4 = ""; }

                fathersAddr1 = fathersAddr1.Replace('\'', ' ');
                fathersAddr2 = fathersAddr2.Replace('\'', ' ');
                fathersAddr3 = fathersAddr3.Replace('\'', ' ');
                fathersAddr4 = fathersAddr4.Replace('\'', ' ');

                //if (!numeric(this.txtfathersDOB.Text)) { this.cvfather.IsValid = false; this.cvfather.Text = "Please enter a numeric Date of birth for Father"; }
                int fathersDOB = 0;
                if (this.txtfathersDOB.Text != "")
                {
                    if ((this.txtfathersDOB.Text != null) && (!this.txtfathersDOB.Text.Equals("")))
                    { 
                        fathersDOB = int.Parse(this.txtfathersDOB.Text);
                    }
                    if (!dv.dateValid(fathersDOB.ToString())) 
                    { 
                        throw new Exception("Invalid Fathers DOB");
                    }
                }
                else
                {
                    fathersDOB = 0;
                }
                if (this.btnSubmit.Text == "Save")
                {
                    lhInsert("Father", fathersName, fathersAddr1, fathersAddr2, fathersAddr3, fathersAddr4, fathersDOB, "M", affidavitDate, shareamt);
                }
                else
                {
                    HirNo++;
                    lhInsert("Father", fathersName, fathersAddr1, fathersAddr2, fathersAddr3, fathersAddr4, fathersDOB, "M", affidavitDate, shareamt);
              
                }
                #endregion
            }

            if (livingChildren)
            {
                #region
                for (int i = 0; i < numOfchildren; i++) {
                    
                    string ddlsexStr = "ddlSon_daughter" + i;
                    string txtnameStr = "txtChildName" + i;
                    string txtDOBStr = "txtDOB" + i;
                    string ddlmaritalstatusStr = "ddlMaritalStatus" + i;
                    string txtaddrStr1 = "txtAddr1" + i;
                    string txtaddrStr2 = "txtAddr2" + i;
                    string txtaddrStr3 = "txtAddr3" + i;
                    string txtaddrStr4 = "txtAddr4" + i;
                    string txtshareStr = "txtChildshare" + i;
                    
                    DropDownList ddlsex = (DropDownList)FindControl(ddlsexStr);
                    //  ddlsex = (DropDownList)FindControl(ddlsexStr);
                    TextBox txtname = new TextBox();
                    txtname = (TextBox)FindControl(txtnameStr);
                    TextBox txtDateOfBirth = new TextBox();
                    txtDateOfBirth = (TextBox)FindControl(txtDOBStr);
                    DropDownList ddlmarry = new DropDownList();
                    ddlmarry = (DropDownList)FindControl(ddlmaritalstatusStr);
                    TextBox txtAddress1 = new TextBox();
                    txtAddress1 = (TextBox)FindControl(txtaddrStr1);
                    TextBox txtAddress2 = new TextBox();
                    txtAddress2 = (TextBox)FindControl(txtaddrStr2);
                    TextBox txtAddress3 = new TextBox();
                    txtAddress3 = (TextBox)FindControl(txtaddrStr3);
                    TextBox txtAddress4 = new TextBox();
                    txtAddress4 = (TextBox)FindControl(txtaddrStr4);
                    TextBox txtchShare = new TextBox();
                    txtchShare = (TextBox)FindControl(txtshareStr);

                    hirenamme = ddlsex.SelectedItem.Value.ToString();
                    shareamt = (double.Parse(txtchShare.Text.Trim()))/100;
                    totshare += shareamt;
                    if (totshare > 1)
                    {
                        throw new Exception("Share amount exceeds 100%");
                    }
                    string childName = txtname.Text.Trim();
                    childName = childName.Replace('\'', ' ');
                    int childDOB = 0;
                    if (txtDateOfBirth.Text != "")
                    {
                        if ((txtDateOfBirth.Text != null) && (!txtDateOfBirth.Text.Equals("")))
                        {
                            childDOB = int.Parse(txtDateOfBirth.Text.Trim());
                        }
                        if (!dv.dateValid(childDOB.ToString()))
                        {
                            throw new Exception("Invalid Child DOB");
                        }
                    }
                    else
                    {
                        childDOB = 0;
                    }
                  //  if (!numeric(txtDateOfBirth.Text.Trim())) { throw new Exception("Please enter a numeric Date of birth for child " + i.ToString()); }
                    
                   //else { throw new Exception("Please Give Date of Birth of Child " + i.ToString()); }
                    string maritalSta = ddlmarry.SelectedItem.Value.ToString();
                    string childAddr1 = "";
                    string childAddr2 = "";
                    string childAddr3 = "";
                    string childAddr4 = "";
                    if (txtAddress1.Text != "") { childAddr1 = txtAddress1.Text.Trim(); }
                    else { childAddr1 = ""; }
                    if (txtAddress2.Text != "") { childAddr2 = txtAddress2.Text.Trim(); }
                    else { childAddr2 = ""; }
                    if (txtAddress3.Text != "") { childAddr3 = txtAddress3.Text.Trim(); }
                    else { childAddr3 = ""; }
                    if (txtAddress4.Text != "") { childAddr4 = txtAddress4.Text.Trim(); }
                    else { childAddr4 = ""; }
                    childAddr1 = childAddr1.Replace('\'', ' ');
                    childAddr2 = childAddr2.Replace('\'', ' ');
                    childAddr3 = childAddr3.Replace('\'', ' ');
                    childAddr4 = childAddr4.Replace('\'', ' ');
                    if (this.btnSubmit.Text == "Save")
                    {
                        lhInsert(hirenamme, childName, childAddr1, childAddr2, childAddr3, childAddr4, childDOB, maritalSta, affidavitDate, shareamt);
                    }
                    else
                    {
                        HirNo++;
                        lhInsert(hirenamme, childName, childAddr1, childAddr2, childAddr3, childAddr4, childDOB, maritalSta, affidavitDate, shareamt);
                    }
                }
                #endregion
            }
            if (livingBroSis)
            {
                #region
                for (int i = 0; i < numOfBroSis; i++)
                {
                    string ddlsexStr = "ddlBro_Sis" + i;
                    string txtnameStr = "txtBroName" + i;
                    string txtDOBStr = "txtDOBnew" + i;
                    string ddlmaritalstatusStr = "ddlMaritalStatusNew" + i;
                    string txtaddrStr1 = "txtAddrNew1" + i;
                    string txtaddrStr2 = "txtAddrNew2" + i;
                    string txtaddrStr3 = "txtAddrNew3" + i;
                    string txtaddrStr4 = "txtAddrNew4" + i;
                    string txtbsshareStr="txtBsshare"+i;

                    DropDownList ddlsex = new DropDownList();
                    TextBox txtname = new TextBox();
                    TextBox txtDateOfBirth = new TextBox();
                    DropDownList ddlmarry = new DropDownList();
                    TextBox txtAddress1 = new TextBox();
                    TextBox txtAddress2 = new TextBox();
                    TextBox txtAddress3 = new TextBox();
                    TextBox txtAddress4 = new TextBox();
                    TextBox txtBsshare = new TextBox();

                     ddlsex = (DropDownList)Table2.FindControl(ddlsexStr);
                     txtname = (TextBox)Table2.FindControl(txtnameStr);
                     txtDateOfBirth = (TextBox)Table2.FindControl(txtDOBStr);
                     ddlmarry = (DropDownList)Table2.FindControl(ddlmaritalstatusStr);
                     txtAddress1 = (TextBox)Table2.FindControl(txtaddrStr1);
                     txtAddress2 = (TextBox)Table2.FindControl(txtaddrStr2);
                     txtAddress3 = (TextBox)Table2.FindControl(txtaddrStr3);
                     txtAddress4 = (TextBox)Table2.FindControl(txtaddrStr4);
                     txtBsshare = (TextBox)Table2.FindControl(txtbsshareStr);

                    hirenamme = ddlsex.SelectedItem.Value.ToString();
                    shareamt = (double.Parse(txtBsshare.Text.Trim()))/100;
                    totshare += shareamt;
                    if ((totshare - 1) > 0.0001)   //(totshare > 1) 2011/05/25
                    {
                        throw new Exception("Share amount exceeds 100%");
                    }
                    string broname = txtname.Text.Trim();
                    broname = broname.Replace('\'', ' ');

                    int broDOB = 0;
                    if (txtDateOfBirth.Text != "")
                    {
                        if ((txtDateOfBirth.Text != null) && (!txtDateOfBirth.Text.Equals("")))
                        {
                            broDOB = int.Parse(txtDateOfBirth.Text.Trim());
                        }
                        if (!dv.dateValid(broDOB.ToString()))
                        {
                            throw new Exception("Invalid Brother or Sister DOB");
                        }

                    }
                    else
                    {
                        broDOB = 0;
                    }
                   // if (!numeric(txtDateOfBirth.Text.Trim())) { throw new Exception("Please enter a numeric Date of birth for Brother/sister " + i); }
                   
                    string maritalSta = ddlmarry.SelectedItem.Value.ToString();
                    string broAddr1 = "";
                    string broAddr2 = "";
                    string broAddr3 = "";
                    string broAddr4 = "";
                    if (txtAddress1.Text != "") { broAddr1 = txtAddress1.Text.Trim(); }
                    else { broAddr1 = ""; }
                    if (txtAddress2.Text != "") { broAddr2 = txtAddress2.Text.Trim(); }
                    else { broAddr2 = ""; }
                    if (txtAddress3.Text != "") { broAddr3 = txtAddress3.Text.Trim(); }
                    else { broAddr3 = ""; }
                    if (txtAddress4.Text != "") { broAddr4 = txtAddress4.Text.Trim(); }
                    else { broAddr4 = ""; }
                    broAddr1 = broAddr1.Replace('\'', ' ');
                    broAddr2 = broAddr2.Replace('\'', ' ');
                    broAddr3 = broAddr3.Replace('\'', ' ');
                    broAddr4 = broAddr4.Replace('\'', ' ');

                    if (this.btnSubmit.Text == "Save")
                    {
                        lhInsert(hirenamme, broname, broAddr1, broAddr2, broAddr3, broAddr4, broDOB, maritalSta, affidavitDate, shareamt);
                    }
                    else
                    {
                        HirNo++;
                        lhInsert(hirenamme, broname, broAddr1, broAddr2, broAddr3, broAddr4, broDOB, maritalSta, affidavitDate, shareamt);
                    }
                }

                #endregion
            }

            this.lblsuccess.Visible = true;
            this.btnSubmit.Text = "Update";
            dmr.commit();
            dmr.connclose();
        }
        catch (Exception ex) {
            dmr.rollback();
            dmr.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");        
        }
        //dm.connclose();
    }

    private void createChildrenTable(int loopCount)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();
        TableRow trow4 = new TableRow();
        TableRow trow5 = new TableRow();
        TableRow trow6 = new TableRow();
        
        TableCell tcell11 = new TableCell();
        tcell11.Style["text-align"] = "Left";
        TableCell tcell12 = new TableCell();
        tcell12.Style["text-align"] = "Left";
        TableCell tcell21 = new TableCell();
        tcell21.Style["text-align"] = "Left";
        TableCell tcell22 = new TableCell();
        tcell22.Style["text-align"] = "Left";
        TableCell tcell23 = new TableCell();
        tcell23.Style["text-align"] = "Left";
        TableCell tcell31 = new TableCell();
        tcell31.Style["text-align"] = "Left";
        TableCell tcell32 = new TableCell();
        tcell32.Style["text-align"] = "Left";
        TableCell tcell33 = new TableCell();
        tcell33.Style["text-align"] = "Left";
        TableCell tcell34 = new TableCell();
        tcell34.Style["text-align"] = "Left";
        TableCell tcell41 = new TableCell();
        tcell41.Style["text-align"] = "Left";
        TableCell tcell42 = new TableCell();
        tcell42.Style["text-align"] = "Left";
        TableCell tcell51 = new TableCell();
        tcell51.Style["text-align"] = "Left";
        TableCell tcell52 = new TableCell();
        tcell52.Style["text-align"] = "Left";
        TableCell tcell61 = new TableCell();
        tcell61.Style["text-align"] = "Left";
        TableCell tcell62 = new TableCell();
        tcell62.Style["text-align"] = "Left";

        DropDownList ddl11 = new DropDownList();
        ddl11.ID = "ddlSon_daughter" + loopCount;
        ddl11.Attributes.Add("runat", "Server");
        ddl11.Attributes.Add("Name", "ddlSon_daughter" + loopCount); //Text Value
        ddl11.Items.Add(new ListItem("Son", "Son"));
        ddl11.Items.Add(new ListItem("Daughter", "Daughter"));
        TextBox txt11 = new TextBox();
        txt11.Width = 400;
        txt11.MaxLength = 80;
        txt11.ID = "txtChildName" + loopCount;
        txt11.Attributes.Add("runat", "Server");
        txt11.Attributes.Add("Name", "txtChildName" + loopCount); 
        //-----------------------
        Label lbl21 = new Label();
        lbl21.ID = "DOB" + loopCount;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "DOB" + loopCount); 
        lbl21.Text = "Date of Birth";
        TextBox txt21 = new TextBox();
        txt21.MaxLength = 8;
        txt21.ID = "txtDOB" + loopCount;
        txt21.Attributes.Add("runat", "Server");
        txt21.Attributes.Add("Name", "txtDOB" + loopCount); 
        DropDownList ddl21 = new DropDownList();
        ddl21.ID = "ddlMaritalStatus" + loopCount;
        ddl21.Attributes.Add("runat", "Server");
        ddl21.Attributes.Add("Name", "ddlMaritalStatus" + loopCount);
        ddl21.Items.Add(new ListItem("Married", "M"));
        ddl21.Items.Add(new ListItem("Un Married", "U"));
        //----------------------
        Label lbl31 = new Label();
        lbl31.ID = "lbladdress" + loopCount;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "lbladdress" + loopCount);
        lbl31.Text = "Residing At";

        Label lbl32 = new Label();
        lbl32.ID = "lblChildshare" + loopCount;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "lblChildshare" + loopCount);
        lbl32.Text = "Share";

        TextBox txt31 = new TextBox();
        txt31.Width = 400;
        txt31.MaxLength = 100;
        txt31.ID = "txtAddr1" + loopCount;
        txt31.Attributes.Add("runat", "Server");
        txt31.Attributes.Add("Name", "txtAddr1" + loopCount);

        TextBox txt41 = new TextBox();
        txt41.Width = 400;
        txt41.MaxLength = 50;
        txt41.ID = "txtAddr2" + loopCount;
        txt41.Attributes.Add("runat", "Server");
        txt41.Attributes.Add("Name", "txtAddr2" + loopCount);

        TextBox txt51 = new TextBox();
        txt51.Width = 400;
        txt51.MaxLength = 50;
        txt51.ID = "txtAddr3" + loopCount;
        txt51.Attributes.Add("runat", "Server");
        txt51.Attributes.Add("Name", "txtAddr3" + loopCount);

        TextBox txt61 = new TextBox();
        txt61.Width = 400;
        txt61.MaxLength = 50;
        txt61.ID = "txtAddr4" + loopCount;
        txt61.Attributes.Add("runat", "Server");
        txt61.Attributes.Add("Name", "txtAddr4" + loopCount);

        TextBox txt32 = new TextBox();
        txt32.Width = 40;
        txt32.MaxLength = 6;
        txt32.ID = "txtChildshare" + loopCount;
        txt32.Attributes.Add("runat", "Server");
        txt32.Attributes.Add("Name", "txtChildshare" + loopCount);

        tcell11.Controls.Add(ddl11);
        tcell12.Controls.Add(txt11);
        trow1.Cells.Add(tcell11);
        trow1.Cells.Add(tcell12);

        tcell21.Controls.Add(lbl21);
        tcell22.Controls.Add(txt21);
        tcell23.Controls.Add(ddl21);
        trow2.Cells.Add(tcell21);
        trow2.Cells.Add(tcell22);
        trow2.Cells.Add(tcell23);

        tcell31.Controls.Add(lbl31);
        tcell32.Controls.Add(txt31);
        tcell33.Controls.Add(lbl32);
        tcell34.Controls.Add(txt32);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);
        trow3.Cells.Add(tcell33);
        trow3.Cells.Add(tcell34);

        tcell42.Controls.Add(txt41);
        trow4.Cells.Add(tcell41);
        trow4.Cells.Add(tcell42);

        tcell52.Controls.Add(txt51);
        trow5.Cells.Add(tcell51);
        trow5.Cells.Add(tcell52);

        tcell62.Controls.Add(txt61);
        trow6.Cells.Add(tcell61);
        trow6.Cells.Add(tcell62);

        Table1.Rows.Add(trow1);
        Table1.Rows.Add(trow2);
        Table1.Rows.Add(trow3);
        Table1.Rows.Add(trow4);
        Table1.Rows.Add(trow5);
        Table1.Rows.Add(trow6);
    }

    private void createBroSisTable(int loopCount)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();
        TableRow trow4 = new TableRow();
        TableRow trow5 = new TableRow();
        TableRow trow6 = new TableRow();

        TableCell tcell11 = new TableCell();
        tcell11.Style["text-align"] = "Left";
        TableCell tcell12 = new TableCell();
        tcell12.Style["text-align"] = "Left";
        TableCell tcell21 = new TableCell();
        tcell21.Style["text-align"] = "Left";
        TableCell tcell22 = new TableCell();
        tcell22.Style["text-align"] = "Left";
        TableCell tcell23 = new TableCell();
        tcell23.Style["text-align"] = "Left";
        TableCell tcell31 = new TableCell();
        tcell31.Style["text-align"] = "Left";
        TableCell tcell32 = new TableCell();
        tcell32.Style["text-align"] = "Left";
        TableCell tcell33 = new TableCell();
        tcell33.Style["text-align"] = "Left";
        TableCell tcell34 = new TableCell();
        tcell34.Style["text-align"] = "Left";
        TableCell tcell41 = new TableCell();
        tcell41.Style["text-align"] = "Left";
        TableCell tcell42 = new TableCell();
        tcell42.Style["text-align"] = "Left";
        TableCell tcell51 = new TableCell();
        tcell51.Style["text-align"] = "Left";
        TableCell tcell52 = new TableCell();
        tcell52.Style["text-align"] = "Left";
        TableCell tcell61 = new TableCell();
        tcell61.Style["text-align"] = "Left";
        TableCell tcell62 = new TableCell();
        tcell62.Style["text-align"] = "Left";

        DropDownList ddl11 = new DropDownList();
        ddl11.ID = "ddlBro_Sis" + loopCount;
        ddl11.Attributes.Add("runat", "Server");
        ddl11.Attributes.Add("Name", "ddlBro_Sis" + loopCount); //Text Value
        ddl11.Items.Add(new ListItem("Brother", "Brother"));
        ddl11.Items.Add(new ListItem("Sister", "Sister"));
        TextBox txt11 = new TextBox();
        txt11.Width = 400;
        txt11.MaxLength = 80;
        txt11.ID = "txtBroName" + loopCount;
        txt11.Attributes.Add("runat", "Server");
        txt11.Attributes.Add("Name", "txtBroName" + loopCount);
        //-----------------------
        Label lbl21 = new Label();
        lbl21.ID = "lblDOB" + loopCount;
        lbl21.Attributes.Add("runat", "Server");
        lbl21.Attributes.Add("Name", "lblDOB" + loopCount);
        lbl21.Text = "Date of Birth";
        TextBox txt21 = new TextBox();
        txt21.MaxLength = 8;
        txt21.ID = "txtDOBnew" + loopCount;
        txt21.Attributes.Add("runat", "Server");
        txt21.Attributes.Add("Name", "txtDOBnew" + loopCount);
        DropDownList ddl21 = new DropDownList();
        ddl21.ID = "ddlMaritalStatusNew" + loopCount;
        ddl21.Attributes.Add("runat", "Server");
        ddl21.Attributes.Add("Name", "ddlMaritalStatusNew" + loopCount);
        ddl21.Items.Add(new ListItem("Married", "M"));
        ddl21.Items.Add(new ListItem("Un Married", "U"));
        //----------------------
        Label lbl31 = new Label();
        lbl31.ID = "lbladdressNew" + loopCount;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "lbladdressNew" + loopCount);
        lbl31.Text = "Residing At";

        TextBox txt31 = new TextBox();
        txt31.Width = 400;
        txt31.MaxLength = 100;
        txt31.ID = "txtAddrNew1" + loopCount;
        txt31.Attributes.Add("runat", "Server");
        txt31.Attributes.Add("Name", "txtAddrNew1" + loopCount);

        TextBox txt41 = new TextBox();
        txt41.Width = 400;
        txt41.MaxLength = 50;
        txt41.ID = "txtAddrNew2" + loopCount;
        txt41.Attributes.Add("runat", "Server");
        txt41.Attributes.Add("Name", "txtAddrNew2" + loopCount);

        TextBox txt51 = new TextBox();
        txt51.Width = 400;
        txt51.MaxLength = 50;
        txt51.ID = "txtAddrNew3" + loopCount;
        txt51.Attributes.Add("runat", "Server");
        txt51.Attributes.Add("Name", "txtAddrNew3" + loopCount);

        TextBox txt61 = new TextBox();
        txt61.Width = 400;
        txt61.MaxLength = 50;
        txt61.ID = "txtAddrNew4" + loopCount;
        txt61.Attributes.Add("runat", "Server");
        txt61.Attributes.Add("Name", "txtAddrNew4" + loopCount);

        Label lbl32 = new Label();
        lbl32.ID = "lblBsshare" + loopCount;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "lblBsshare" + loopCount);
        lbl32.Text = "Share";

        TextBox txt32 = new TextBox();
        txt32.Width = 40;
        txt32.MaxLength = 6;
        txt32.ID="txtBsshare"+loopCount;
        txt32.Attributes.Add("runat", "Server");
        txt32.Attributes.Add("Name", "txtBsshare" + loopCount);

        tcell11.Controls.Add(ddl11);
        tcell12.Controls.Add(txt11);
        trow1.Cells.Add(tcell11);
        trow1.Cells.Add(tcell12);

        tcell21.Controls.Add(lbl21);
        tcell22.Controls.Add(txt21);
        tcell23.Controls.Add(ddl21);
        trow2.Cells.Add(tcell21);
        trow2.Cells.Add(tcell22);
        trow2.Cells.Add(tcell23);

        tcell31.Controls.Add(lbl31);
        tcell32.Controls.Add(txt31);
        tcell33.Controls.Add(lbl32);
        tcell34.Controls.Add(txt32);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);
        trow3.Cells.Add(tcell33);
        trow3.Cells.Add(tcell34);

        tcell42.Controls.Add(txt41);
        trow4.Cells.Add(tcell41);
        trow4.Cells.Add(tcell42);

        tcell52.Controls.Add(txt51);
        trow5.Cells.Add(tcell51);
        trow5.Cells.Add(tcell52);

        tcell62.Controls.Add(txt61);
        trow6.Cells.Add(tcell61);
        trow6.Cells.Add(tcell62);

        Table2.Rows.Add(trow1);
        Table2.Rows.Add(trow2);
        Table2.Rows.Add(trow3);
        Table2.Rows.Add(trow4);
        Table2.Rows.Add(trow5);
        Table2.Rows.Add(trow6);
    }

    private void lhInsert(string hire, string name, string addr1, string addr2, string addr3, string addr4, int DOB, string mst, int affdvtDat, double Share) {
        DataManager dmm = new DataManager();
        dm = new DataManager();
        try
        {
            dmm.begintransaction();
            int hiereNo = 0;
            string heireSS = "";
            bool ma = false;
            bool pa = false;
            bool spou = false;
            int temp = 0;
            string lhSelect = "select lhhno, lhhire from lphs.legal_hires where lhpolno=" + polno + " and lhmof='" + MOF + "' ";
            if (dmm.existRecored(lhSelect) == 0)
            {
                string lhInsert = "INSERT INTO LPHS.LEGAL_HIRES (LHPOLNO ,LHMOF ,LHHNO ,LHHIRE ,LHNAME ,LHAD1 ,LHDOB ,LHMST ,LHREMARKS ,LHENTDT ,LHENTEPF ,LHENTIP, LHSHARE, LHAD2, LHAD3, LHAD4)";
                lhInsert += "VALUES (" + polno + " ,'" + MOF + "' , " + (hiereNo + 1) + ",'" + hire + "' ,'" + name + "' ,'" + addr1 + "' ," + DOB + " ,'" + mst + "' ,'' ," + int.Parse(this.setDate()[0]) + " ,'" + epf + "' ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "'" +
                    ", " + Share + ", '" + addr2 + "', '" + addr3 + "', '" + addr4 + "')";
                dmm.insertRecords(lhInsert);
            }
            else
            {
                dm.readSql(lhSelect);
                OracleDataReader lhReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (lhReader.Read())
                {
                    if (!lhReader.IsDBNull(1)) { heireSS = lhReader.GetString(1); }
                    if (heireSS.Equals("Mother")) { ma = true; }
                    else if (heireSS.Equals("Father")) { pa = true; }
                    else if (heireSS.Equals("Spouce")) { spou = true; }
                    else { }
                    temp = lhReader.GetInt32(0);
                    if (hiereNo < temp) { hiereNo = temp; }
                }
                lhReader.Close();
                lhReader.Dispose();
                hiereNo++;

                if (!(hire.Equals("Spouce") && (spou)) && !(hire.Equals("Mother") && (ma)) && !(hire.Equals("Father") && (pa)))
                {
                    string lhInsert = "INSERT INTO LPHS.LEGAL_HIRES (LHPOLNO ,LHMOF ,LHHNO ,LHHIRE ,LHNAME ,LHAD1 ,LHDOB ,LHMST ,LHREMARKS ,LHENTDT ,LHENTEPF ,LHENTIP, LHSHARE, LHAD2, LHAD3, LHAD4 )";
                    lhInsert += "VALUES (" + polno + " ,'" + MOF + "' , " + hiereNo + ",'" + hire + "' ,'" + name + "' ,'" + addr1 + "' ," + DOB + " ,'" + mst + "' ,'' ," + int.Parse(this.setDate()[0]) + " ,'" + epf + "' ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', " + Share + ", " +
                        "'" + addr2 + "', '" + addr3 + "', '" + addr4 + "')";
                    dmm.insertRecords(lhInsert);
                }
                else { hiereNo--; }
            }
            dmm.commit();
            dmm.connclose();
        }
        catch (Exception ex)
        {
            dmm.rollback(); dmm.connclose(); throw ex;
        }        
    }

    private void lhUpdate(string hire, string name, string addr1, string addr2, string addr3, string addr4, int DOB, string mst, int hno)
    {
        string lhupd = "update lphs.legal_hires set LHNAME = '" + name + "', LHAD1 ='" + addr1 + "', LHAD2='" + addr2 + "', LHAD3='" + addr3 + "', LHAD4='" + addr4 + "', LHDOB =" + DOB + ", LHMST ='" + mst + "'where lhpolno = " + polno + " and lhmof = '" + MOF + "' and lhhno = " + hno + " ";
        dm.insertRecords(lhupd);
    }

    protected bool numeric(string s) {

        for (int i = 0; i < s.Length; i++) {
            try
            {
                int.Parse(s.Substring(i, 1));
            }
            catch {
                return false;
            }

        } 
        return true;
    
    }


    protected void btnshares_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "&pageflag="+pageflag+"");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/leganHieresDelete.aspx?polno=" + polno + "&theMof=" + MOF + "");
    }
}
