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

public partial class legalHieres003 : System.Web.UI.Page
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

    DataManager dm;
    private int polno;
    private string MOF, flag;

    private int LHHNO;
    private string LHHIRE;
    private string LHNAME;
    private string LHAD1;
    private int LHDOB;
    private string LHMST;
    private double LHSHARE;
    private double LHAMOUNT;
    //private double share;
    //int affidavitDate;

    private string lhname;
    private string lhad1;
    private int lhdob;
    private string lhmst;

    private double totamount;
    private double outAmt;
    private long claimno; 

    protected void Page_Load(object sender, EventArgs e)
    {
        //polno = int.Parse(Request.QueryString["polno"]);
        //MOF = (string)Request.QueryString["theMof"];

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;

            flag = this.PreviousPage.Flag;
            totamount = this.PreviousPage.Totamount;
            outAmt = this.PreviousPage.OutAmt;
            claimno = this.PreviousPage.Claimno;
        }
        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                if (flag != null && !flag.Equals("")) { this.btnexit.Visible = false; this.btnshares.Visible = true; }
                else { this.btnexit.Visible = true; this.btnshares.Visible = false; }

                #region -------------- legal heires -----------------
                string lheireSelect = "select LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHSHARE, LHAMOUNT from LPHS.LEGAL_HIRES where lhpolno = " + polno + " and lhmof ='" + MOF + "' ";
                if (dm.existRecored(lheireSelect) != 0)
                {
                    dm.readSql(lheireSelect);
                    OracleDataReader lhreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lhreader.Read())
                    {
                        //int childrenCount = 0;
                        //int broSisCount = 0;

                        if (!lhreader.IsDBNull(0)) { LHHNO = lhreader.GetInt32(0); } else { LHHNO = 0; }
                        if (!lhreader.IsDBNull(1)) { LHHIRE = lhreader.GetString(1); } else { LHHIRE = ""; }
                        if (!lhreader.IsDBNull(2)) { LHNAME = lhreader.GetString(2); } else { LHNAME = ""; }
                        if (!lhreader.IsDBNull(3)) { LHAD1 = lhreader.GetString(3); } else { LHAD1 = ""; }
                        if (!lhreader.IsDBNull(4)) { LHDOB = lhreader.GetInt32(4); } else { LHDOB = 0; }
                        if (!lhreader.IsDBNull(5)) { LHMST = lhreader.GetString(5); } else { LHMST = ""; }
                        if (!lhreader.IsDBNull(6)) { LHSHARE = lhreader.GetDouble(6); } else { LHSHARE = 0; }
                        if (!lhreader.IsDBNull(7)) { LHAMOUNT = lhreader.GetDouble(7); } else { LHAMOUNT = 0; }

                        if ((LHHIRE.Equals("Spouce")) && (!Page.IsPostBack))
                        {
                            this.lblwidow.Visible = true;
                            this.txtwidowName.Visible = true;
                            this.lblwidowaddr.Visible = true;
                            this.txtwidowAd1.Visible = true;
                            this.lblwidowDOB.Visible = true;
                            this.txtwidowDOB.Visible = true;
                            Literal1.Visible = true;

                            this.txtwidowName.Text = LHNAME;
                            if (LHAD1 != "")
                            {
                                this.txtwidowAd1.Text = LHAD1;
                            }
                            else
                            {
                                this.txtwidowAd1.Text = "";
                            }
                            if (LHDOB != 0)
                            {
                                this.txtwidowDOB.Text = LHDOB.ToString();
                            }
                            else
                            {
                                this.txtwidowDOB.Text = "";
                            }

                        }
                        else if ((LHHIRE.Equals("Mother")) && (!Page.IsPostBack))
                        {
                            this.lblmother.Visible = true;
                            this.txtmothersName.Visible = true;
                            this.lblmothersresi.Visible = true;
                            this.txtmothersAd1.Visible = true;
                            this.lblmotherdob.Visible = true;
                            this.txtmothersDOB.Visible = true;
                            Literal2.Visible = true;

                            this.txtmothersName.Text = LHNAME;
                            if (LHAD1 != "")
                            {
                                this.txtmothersAd1.Text = LHAD1;
                            }
                            else
                            {
                                this.txtmothersAd1.Text = "";
                            }
                            if (LHDOB != 0)
                            {
                                this.txtmothersDOB.Text = LHDOB.ToString();
                            }
                            else
                            {
                                this.txtmothersDOB.Text = "";
                            }
                        }
                        else if ((LHHIRE.Equals("Father")) && (!Page.IsPostBack))
                        {
                            this.lblfather.Visible = true;
                            this.txtfathersName.Visible = true;
                            this.lblfatherResi.Visible = true;
                            this.txtfathersAd1.Visible = true;
                            this.lblfatherDOB.Visible = true;
                            this.txtfathersDOB.Visible = true;
                            Literal3.Visible = true;

                            this.txtfathersName.Text = LHNAME;
                            if (LHAD1 != "")
                            {
                                this.txtfathersAd1.Text = LHAD1;
                            }
                            else
                            {
                                this.txtfathersAd1.Text = "";
                            }
                            if (LHDOB != 0)
                            {
                                this.txtfathersDOB.Text = LHDOB.ToString();
                            }
                            else
                            {
                                this.txtfathersDOB.Text = "";
                            }

                        }
                        else if (LHHIRE.Equals("Son"))
                        {
                            //childrenCount++;
                            this.createChildrenTable(LHHIRE, LHMST, LHNAME, LHAD1, LHDOB, LHHNO);
                        }
                        else if (LHHIRE.Equals("Daughter"))
                        {
                            //childrenCount++;
                            this.createChildrenTable(LHHIRE, LHMST, LHNAME, LHAD1, LHDOB, LHHNO);
                        }
                        else if (LHHIRE.Equals("Brother"))
                        {
                            //broSisCount++;
                            this.createBroSisTable(LHHIRE, LHMST, LHNAME, LHAD1, LHDOB, LHHNO);
                        }
                        else if (LHHIRE.Equals("Sister"))
                        {
                            //broSisCount++;
                            this.createBroSisTable(LHHIRE, LHMST, LHNAME, LHAD1, LHDOB, LHHNO);
                        }
                    }
                    lhreader.Close();
                    lhreader.Dispose();
                }

                #endregion

                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;

                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["flag"] = flag;
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

            if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int count=0;
        dm = new DataManager();
        try
        {
            dateValidation dv = new dateValidation();
            string lheireSelect = "select LHHNO, LHHIRE, LHNAME, LHAD1, LHDOB, LHMST, LHSHARE, LHAMOUNT from LPHS.LEGAL_HIRES where lhpolno = " + polno + " and lhmof ='" + MOF + "' ";
            if (dm.existRecored(lheireSelect) != 0)
            {
                
                 dm.readSql(lheireSelect);
                OracleDataReader lhreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (lhreader.Read())
                {
                    count++;
                    if (!lhreader.IsDBNull(0)) { LHHNO = lhreader.GetInt32(0); } else { LHHNO = 0; }
                    if (!lhreader.IsDBNull(1)) { LHHIRE = lhreader.GetString(1); } else { LHHIRE = ""; }
                    if (!lhreader.IsDBNull(2)) { LHNAME = lhreader.GetString(2); } else { LHNAME = ""; }
                    if (!lhreader.IsDBNull(3)) { LHAD1 = lhreader.GetString(3); } else { LHAD1 = ""; }
                    if (!lhreader.IsDBNull(4)) { LHDOB = lhreader.GetInt32(4); } else { LHDOB = 0; }
                    if (!lhreader.IsDBNull(5)) { LHMST = lhreader.GetString(5); } else { LHMST = ""; }
                    if (!lhreader.IsDBNull(6)) { LHSHARE = lhreader.GetDouble(6); } else { LHSHARE = 0; }
                    if (!lhreader.IsDBNull(7)) { LHAMOUNT = lhreader.GetDouble(7); } else { LHAMOUNT = 0; }

                    if (LHHIRE.Equals("Spouce"))
                    {
                        lhname = this.txtwidowName.Text.Trim();
                        if (this.txtwidowAd1.Text != "")
                        {
                            lhad1 = this.txtwidowAd1.Text.Trim();
                        }
                        else
                        {
                            lhad1 = "";
                        }
                       // if (!numeric(this.txtwidowDOB.Text)) { this.cvspouce.IsValid = false; this.cvspouce.Text = "Please enter a numeric Date of birth for widow/widower"; }
                        if (this.txtwidowDOB.Text != "")
                        {
                            if ((this.txtwidowDOB.Text != null) && (!this.txtwidowDOB.Text.Equals("")))
                            {
                                lhdob = int.Parse(this.txtwidowDOB.Text);
                            }
                            if (!dv.dateValid(lhdob.ToString()))
                            {
                                throw new Exception("Invalid Widow DOB");
                            }

                        }
                        else
                        {
                            lhdob = 0;
                        }

                        lhmst = "M";
                        lhUpdate(LHHIRE, lhname, lhad1, lhdob, lhmst, LHHNO);
                    }
                    else if (LHHIRE.Equals("Mother"))
                    {
                        lhname = this.txtmothersName.Text.Trim();
                        if (this.txtmothersAd1.Text != "")
                        {
                            lhad1 = this.txtmothersAd1.Text.Trim();
                        }
                        else
                        {
                            lhad1 = "";
                        }
                       // if (!numeric(this.txtwidowDOB.Text)) { this.cvspouce.IsValid = false; this.cvspouce.Text = "Please enter a numeric Date of birth for Mother"; }
                        if (this.txtwidowDOB.Text != "")
                        {
                            if ((this.txtwidowDOB.Text != null) && (!this.txtwidowDOB.Text.Equals("")))
                            {
                                lhdob = int.Parse(this.txtmothersDOB.Text);
                            }
                            if (!dv.dateValid(lhdob.ToString()))
                            {
                                throw new Exception("Invalid Mothers DOB");
                            }

                        }
                        else
                        {
                            lhdob = 0;
                        }
                        lhmst = "M";
                        lhUpdate(LHHIRE, lhname, lhad1, lhdob, lhmst, LHHNO);
                       
                    }
                    else if (LHHIRE.Equals("Father"))
                    {
                        lhname = this.txtfathersName.Text.Trim();
                        if (this.txtfathersAd1.Text != "")
                        {
                            lhad1 = this.txtfathersAd1.Text.Trim();
                        }
                        else
                        {
                            lhad1 = "";
                        }
                        //if (!numeric(this.txtwidowDOB.Text)) { this.cvspouce.IsValid = false; this.cvspouce.Text = "Please enter a numeric Date of birth for Father"; }
                        if (this.txtwidowDOB.Text != "")
                        {
                            if ((this.txtwidowDOB.Text != null) && (!this.txtwidowDOB.Text.Equals("")))
                            {
                                lhdob = int.Parse(this.txtfathersDOB.Text);
                            }
                            if (!dv.dateValid(lhdob.ToString()))
                            {
                                throw new Exception("Invalid Fathers DOB");
                            }

                        }
                        else
                        {
                            lhdob = 0;
                        }
                        lhmst = "M";
                        lhUpdate(LHHIRE, lhname, lhad1, lhdob, lhmst, LHHNO);
                    }
                    else if ((LHHIRE.Equals("Son"))||(LHHIRE.Equals("Daughter")))
                    {
                        string ddlsexStr = "ddlSon_daughter" + LHHNO;
                        string txtnameStr = "txtChildName" + LHHNO;
                        string txtDOBStr = "txtDOB" + LHHNO;
                        string ddlmaritalstatusStr = "ddlMaritalStatus" + LHHNO;
                        string txtaddrStr = "txtAddr" + LHHNO;
                        string txtchshareStr = "txtchShare" + count;
                        string  ddlsex="";
                        string txtname = "";
                        string txtDateOfBirth = "";
                        string ddlmarry = "";
                        string txtAddress = "";


                        if (ViewState["Child" + count] != null)
                        {
                          ddlsex = ViewState["Child" + count].ToString();
                        }
                        if (ViewState["ChildName" + count] != null)
                        {
                          txtname = ViewState["ChildName" + count].ToString();
                        }
                        if (ViewState["DOB" + count] != null)
                        {
                           txtDateOfBirth = ViewState["DOB" + count].ToString();
                        }
                        if (ViewState["MaritalSt"+count] != null)
                        {
                            ddlmarry = ViewState["MaritalSt" + count].ToString();
                        }
                        if (ViewState["Address" + count] != null)
                        {
                            txtAddress = ViewState["Address" + count].ToString();
                        }
                        //TextBox txtDushan = new TextBox();
                        //txtDushan = (TextBox)FindControl(txtchshareStr);
                        //if (txtDushan.Text != null) { share = double.Parse(txtDushan.Text.Trim()); }
                        //DropDownList ddlsex = (DropDownList)Table2.FindControl(ddlsexStr);
                        //TextBox txtname = new TextBox();
                        // txtname = (TextBox)Table1.FindControl(txtnameStr);
                        //TextBox txtDateOfBirth = new TextBox();
                       // txtDateOfBirth = (TextBox)Table1.FindControl(txtDOBStr);
                        //DropDownList ddlmarry = new DropDownList();
                        //ddlmarry = (DropDownList)Table1.FindControl(ddlmaritalstatusStr);
                        //TextBox txtAddress = new TextBox();
                        //txtAddress = (TextBox)Table1.FindControl(txtaddrStr);
                        
                        lhname = txtname.Trim();
                        if (txtAddress != null)
                        {
                            lhad1 = txtAddress.Trim();
                        }
                        else
                        {
                            lhad1 = "";
                        }
                        //if (!numeric(txtDateOfBirth.Trim())) { throw new Exception("Please enter a numeric Date of birth for child " + LHHNO.ToString()); }
                        if (txtDateOfBirth != null && txtDateOfBirth != "0" && txtDateOfBirth.Trim()!="")
                        {
                            if ((txtDateOfBirth != null) && (!txtDateOfBirth.Equals("")))
                            {
                                lhdob = int.Parse(txtDateOfBirth.Trim());
                            }
                            if (!dv.dateValid(lhdob.ToString()))
                            {
                                throw new Exception("Invalid Child DOB");
                            }

                        }
                        else
                        {
                            lhdob = 0;
                        }
                        lhmst = ddlmarry;
                        lhUpdate(LHHIRE, lhname, lhad1, lhdob, lhmst, LHHNO);
                        
                    }
                    else if ((LHHIRE.Equals("Brother")) || (LHHIRE.Equals("Sister")))
                    {
                        string ddlsexStr = "ddlBro_Sis" + LHHNO;
                        string txtnameStr = "txtBroName" + LHHNO;
                        string txtDOBStr = "txtDOBnew" + LHHNO;
                        string ddlmaritalstatusStr = "ddlMaritalStatusNew" + LHHNO;
                        string txtaddrStr = "txtAddrNew" + LHHNO;

                        string ddlsex = "";
                        string txtname ="";
                        string txtDateOfBirth="";
                        string ddlmarry = "";
                        string  txtAddress ="";

                        if (ViewState["BrotherSister" + count] != null)
                        {
                            ddlsex = ViewState["BrotherSister" + count].ToString();
                        }
                        if (ViewState["Name" + count] != null)
                        {
                            txtname = ViewState["Name" + count].ToString();
                        }
                        if (ViewState["BRSDOB"+count] != null)
                        {
                            txtDateOfBirth = ViewState["BRSDOB" + count].ToString();
                        }
                        if (ViewState["BRSMaritalSt" + count] != null)
                        {
                            ddlmarry = ViewState["BRSMaritalSt" + count].ToString();
                        }
                        if (ViewState["BRSAddress"+count]!=null)
                        {
                         txtAddress = ViewState["BRSAddress"+count].ToString();
                        }

                        //ddlsex = (DropDownList)FindControl(ddlsexStr);
                            
                        //txtname = (TextBox)FindControl(txtnameStr);
                        //txtDateOfBirth = (TextBox)FindControl(txtDOBStr);
                        //ddlmarry = (DropDownList)FindControl(ddlmaritalstatusStr);
                        //txtAddress = (TextBox)FindControl(txtaddrStr);

                        lhname = txtname.Trim();
                        //if (!numeric(txtDateOfBirth.Trim())) { throw new Exception("Please enter a numeric Date of birth for Brother/sister " + LHHNO); }
                        if (txtDateOfBirth != null && txtDateOfBirth != "0" && txtDateOfBirth.Trim()!="")
                        {
                            if ((txtDateOfBirth != null) && (!txtDateOfBirth.Equals("")))
                            {
                                lhdob = int.Parse(txtDateOfBirth.Trim());
                            }
                            if (!dv.dateValid(lhdob.ToString()))
                            {
                                throw new Exception("Invalid Brothr Sister DOB");
                            }

                        }
                        else
                        {
                            lhdob = 0;
                        }
                        lhmst = ddlmarry;
                        if (txtAddress != null)
                        {
                            lhad1 = txtAddress.Trim();
                        }
                        else
                        {
                            lhad1 = "";
                        }
                        lhUpdate(LHHIRE, lhname, lhad1, lhdob, lhmst, LHHNO);
                    }
                }
                lhreader.Close();
                lhreader.Dispose();
                this.lblsuccess.Visible = true;
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

    private void lhUpdate(string hire, string name, string addr, int DOB, string mst, int hno) 
    {
        string lhupd = "update lphs.legal_hires set LHNAME = '" + name + "' ,LHAD1 ='" + addr + "' ,LHDOB =" + DOB + " ,LHMST ='" + mst + "'where lhpolno = " + polno + " and lhmof = '" + MOF + "' and lhhno = " + hno + " ";
        dm.insertRecords(lhupd); 
    }

    protected bool numeric(string s)
    {

        for (int i = 0; i < s.Length; i++)
        {
            try
            {
                int.Parse(s.Substring(i, 1));
            }
            catch
            {
                return false;
            }

        }
        return true;

    }

    private void createChildrenTable(string sORd, string mst, string name, string ad, int dob, int loopCount)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();

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

        DropDownList ddl11 = new DropDownList();
        ddl11.ID = "ddlSon_daughter" + loopCount;
        ddl11.Attributes.Add("runat", "Server");
        ddl11.Attributes.Add("Name", "ddlSon_daughter" + loopCount); //Text Value
        ddl11.Items.Add(new ListItem("Son", "Son"));
        ddl11.Items.Add(new ListItem("Daughter", "Daughter"));
        if (sORd.Equals("Son")) { ddl11.SelectedIndex = 0; }
        else if (sORd.Equals("Daughter")) { ddl11.SelectedIndex = 1; }

        ViewState["Child" + loopCount.ToString()] = sORd;

        TextBox txt11 = new TextBox();
        txt11.Width = 400;
        txt11.MaxLength = 80;
        txt11.ID = "txtChildName" + loopCount;
        txt11.Attributes.Add("runat", "Server");
        txt11.Attributes.Add("Name", "txtChildName" + loopCount);
        txt11.Text = name;

        ViewState["ChildName" + loopCount.ToString()] = name;
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
        if (dob != 0)
        {
            txt21.Text = dob.ToString();
        }
        else
        {
            txt21.Text = "";
        }

        ViewState["DOB" + loopCount.ToString()] = dob.ToString(); 

        DropDownList ddl21 = new DropDownList();
        ddl21.ID = "ddlMaritalStatus" + loopCount;
        ddl21.Attributes.Add("runat", "Server");
        ddl21.Attributes.Add("Name", "ddlMaritalStatus" + loopCount);
        ddl21.Items.Add(new ListItem("Married", "M"));
        ddl21.Items.Add(new ListItem("Un Married", "U"));
        if (mst.Equals("M")) { ddl21.SelectedIndex = 0; }
        else if (mst.Equals("U")) { ddl21.SelectedIndex = 1; }

        ViewState["MaritalSt" + loopCount.ToString()] = mst; 

        //----------------------
        Label lbl31 = new Label();
        lbl31.ID = "lbladdress" + loopCount;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "lbladdress" + loopCount);
        lbl31.Text = "Residing At";
        TextBox txt31 = new TextBox();
        txt31.Width = 400;
        txt31.MaxLength = 100;
        txt31.ID = "txtAddr" + loopCount;
        txt31.Attributes.Add("runat", "Server");
        txt31.Attributes.Add("Name", "txtAddr" + loopCount);
        if (ad != "")
        {
            txt31.Text = ad;
        }
        else
        {
            txt31.Text = "";
        }
        ViewState["Address" + loopCount.ToString()] = ad;

        Label lbl32 = new Label();
        lbl32.ID = "lblchShare" + loopCount;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "lblchShare" + loopCount);
        lbl32.Text = "Share(%)";

        TextBox txt33 = new TextBox();
        txt33.ID = "txtchShare" + loopCount;
        txt33.Attributes.Add("runat", "Server");
        txt33.Attributes.Add("Name", "txtchShare" + loopCount);

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
        tcell34.Controls.Add(txt33);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);
        trow3.Cells.Add(tcell33);
        trow3.Cells.Add(tcell34);

        Table1.Rows.Add(trow1);
        Table1.Rows.Add(trow2);
        Table1.Rows.Add(trow3);

    }

    private void createBroSisTable(string bOs, string mst, string name, string ad, int dob, int loopCount)
    {
        TableRow trow1 = new TableRow();
        TableRow trow2 = new TableRow();
        TableRow trow3 = new TableRow();

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

        DropDownList ddl11 = new DropDownList();
        ddl11.ID = "ddlBro_Sis" + loopCount;
        ddl11.Attributes.Add("runat", "Server");
        ddl11.Attributes.Add("Name", "ddlBro_Sis" + loopCount); //Text Value
        ddl11.Items.Add(new ListItem("Brother", "Brother"));
        ddl11.Items.Add(new ListItem("Sister", "Sister"));
        if (bOs.Equals("Brother")) { ddl11.SelectedIndex = 0; }
        else if (bOs.Equals("Sister")) { ddl11.SelectedIndex = 1; }

        ViewState["BrotherSister" + loopCount.ToString()] = bOs; 

        TextBox txt11 = new TextBox();
        txt11.Width = 400;
        txt11.MaxLength = 80;
        txt11.ID = "txtBroName" + loopCount;
        txt11.Attributes.Add("runat", "Server");
        txt11.Attributes.Add("Name", "txtBroName" + loopCount);
        txt11.Text = name;

        ViewState["Name" + loopCount.ToString()] = name; 
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
        if (dob != 0)
        {
            txt21.Text = dob.ToString();
        }
        else
        {
            txt21.Text = "";
        }

        ViewState["BRSDOB" + loopCount.ToString()] = dob.ToString();

        DropDownList ddl21 = new DropDownList();
        ddl21.ID = "ddlMaritalStatusNew" + loopCount;
        ddl21.Attributes.Add("runat", "Server");
        ddl21.Attributes.Add("Name", "ddlMaritalStatusNew" + loopCount);
        ddl21.Items.Add(new ListItem("Married", "M"));
        ddl21.Items.Add(new ListItem("Un Married", "U"));
        if (mst.Equals("M")) { ddl21.SelectedIndex = 0; }
        else if (mst.Equals("U")) { ddl21.SelectedIndex = 1; }

        ViewState["BRSMaritalSt" + loopCount.ToString()] = mst;

        //----------------------
        Label lbl31 = new Label();
        lbl31.ID = "lbladdressNew" + loopCount;
        lbl31.Attributes.Add("runat", "Server");
        lbl31.Attributes.Add("Name", "lbladdressNew" + loopCount);
        lbl31.Text = "Residing At";
        TextBox txt31 = new TextBox();
        txt31.Width = 400;
        txt31.MaxLength = 100;
        txt31.ID = "txtAddrNew" + loopCount;
        txt31.Attributes.Add("runat", "Server");
        txt31.Attributes.Add("Name", "txtAddrNew" + loopCount);
        if (ad != "")
        {
            txt31.Text = ad;
        }
        else
        {
            txt31.Text = "";
        }

        ViewState["BRSAddress" + loopCount.ToString()] = ad;

        Label lbl32 = new Label();
        lbl32.ID = "lblbsShare" + loopCount;
        lbl32.Attributes.Add("runat", "Server");
        lbl32.Attributes.Add("Name", "lblbsShare" + loopCount);
        lbl32.Text = "Share(%)";

        TextBox txt33 = new TextBox();
        txt33.ID = "txtBsshare" + loopCount;
        txt33.Attributes.Add("runat", "Server");
        txt33.Attributes.Add("Name", "txtBsshare" + loopCount);
        
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
        tcell34.Controls.Add(txt33);
        trow3.Cells.Add(tcell31);
        trow3.Cells.Add(tcell32);
        trow3.Cells.Add(tcell33);
        trow3.Cells.Add(tcell34);

        Table2.Rows.Add(trow1);
        Table2.Rows.Add(trow2);
        Table2.Rows.Add(trow3);

    }
   
    protected void btnshares_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/leganHieresDelete.aspx?polno=" + polno + "&theMof=" + MOF + "");
    }
}
