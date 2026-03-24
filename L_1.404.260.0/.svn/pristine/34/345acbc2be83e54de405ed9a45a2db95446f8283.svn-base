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

public partial class livingPrt001 : System.Web.UI.Page
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
    private  string MOF, flag;

    private string sta;
    private string surname;
    private string fullname;

    private int DOB;
    private int age;
    private string gender;
    private string NICno;
    private string passportno;
    private string email;
    private string telno;
    private string occupation;
    private string ad1;
    private string ad2;
    private int partnershipDate;

    private int brn;
    private string epf;

    DataManager livingPrtObj;
    private double totamount;
    private double outAmt;
    private long claimno;
    int PRPERTYPE = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string test = Request.QueryString["polno"];
        epf = Session["EPFNum"].ToString();

        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos01;
        }
        else if ((test != null) && (!test.Equals("")))
        {
            polno = int.Parse(Request.QueryString["polno"]);
            MOF = (string)Request.QueryString["theMof"];
            if (Request.QueryString["flag"] != null) { flag = Request.QueryString["flag"].ToString(); }
            if (Request.QueryString["totamount"] != null) { totamount = double.Parse(Request.QueryString["totamount"].ToString()); }
            if (Request.QueryString["outAmt"] != null) { outAmt = double.Parse(Request.QueryString["outAmt"].ToString()); }
            if (Request.QueryString["claimno"] != null) { claimno = long.Parse(Request.QueryString["claimno"].ToString()); }            
        }       

        if (!Page.IsPostBack)
        {
            livingPrtObj = new DataManager();
            try
            {
                if (flag != null && !flag.Equals("")) { 
                    //this.btnExit.Visible = false; 
                    this.btnshares.Visible = true; }
                else { 
                    //this.btnExit.Visible = true; 
                    this.btnshares.Visible = false; }

                this.lblpolno.Text = polno.ToString();
                this.lblbrn.Text = brn.ToString();

                this.ddlGender.Items.Add(new ListItem("Male", "M"));
                this.ddlGender.Items.Add(new ListItem("Female", "F"));

                if (MOF == "M")
                    PRPERTYPE = 1;
                if (MOF == "2")
                    PRPERTYPE = 3;
                #region ------------- polpersonal --------------
                string polpersonalSel = "select DOB ,AGE ,SEXCODE ,NICNO ,PASSPORTNO ,OCCUPATION ,STATUS ,SURNAME ,FULLNAME ,EMAIL ,TELEPHONE from LUND.POLPERSONAL where polno =" + polno + " and PRPERTYPE=" + PRPERTYPE + " ";
                if (livingPrtObj.existRecored(polpersonalSel) != 0)
                {
                    livingPrtObj.readSql(polpersonalSel);
                    OracleDataReader polpersonalReader = livingPrtObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (polpersonalReader.Read())
                    {
                        if (!polpersonalReader.IsDBNull(0)) { DOB = polpersonalReader.GetInt32(0); } else { DOB = 0; }
                        if (!polpersonalReader.IsDBNull(1)) { age = polpersonalReader.GetInt32(1); } else { age = 0; }
                        if (!polpersonalReader.IsDBNull(2)) { gender = polpersonalReader.GetString(2); } else { gender = ""; }
                        if (!polpersonalReader.IsDBNull(3)) { NICno = polpersonalReader.GetString(3); } else { NICno = ""; }
                        if (!polpersonalReader.IsDBNull(4)) { passportno = polpersonalReader.GetString(4); } else { passportno = ""; }
                        if (!polpersonalReader.IsDBNull(5)) { occupation = polpersonalReader.GetString(5); } else { occupation = ""; }
                        if (!polpersonalReader.IsDBNull(6)) { sta = polpersonalReader.GetString(6); } else { sta = ""; }
                        if (!polpersonalReader.IsDBNull(7)) { surname = polpersonalReader.GetString(7); } else { surname = ""; }
                        if (!polpersonalReader.IsDBNull(8)) { fullname = polpersonalReader.GetString(8); } else { fullname = ""; }
                        if (!polpersonalReader.IsDBNull(9)) { email = polpersonalReader.GetString(9); } else { email = ""; }
                        if (!polpersonalReader.IsDBNull(10)) { telno = polpersonalReader.GetString(10); } else { telno = ""; }
                    }
                    polpersonalReader.Close();
                    polpersonalReader.Dispose();

                    if (DOB > 10000000) { this.txtdob.Text = DOB.ToString().Substring(0, 4) + "/" + DOB.ToString().Substring(4, 2) + "/" + DOB.ToString().Substring(6, 2); }
                    this.txtage.Text = age.ToString();
                    if ((gender != null) && (gender.Equals("M"))) { this.ddlGender.SelectedIndex = 0; }
                    else if ((gender != null) && (gender.Equals("F"))) { this.ddlGender.SelectedIndex = 1; }
                    else { }
                    this.txtnic.Text = NICno.ToString();
                    this.txtpassprt.Text = passportno.ToString();
                    this.txtoccu.Text = occupation.ToString();
                    this.txtsta.Text = sta.ToString();
                    this.txtsurname.Text = surname.ToString();
                    this.txtfullname.Text = fullname.ToString();
                    this.txtemail.Text = email.ToString();
                    this.txttelno.Text = telno.ToString();

                }

                #endregion

                string livingPrtSel = "select NOMAD1 ,NOMAD2, PRTNRSHIPDATE from LUND.LIVING_PRT where POLNO = " + polno + " ";
                if (livingPrtObj.existRecored(livingPrtSel) != 0)
                {
                    livingPrtObj.readSql(livingPrtSel);
                    OracleDataReader livingPrtReader = livingPrtObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (livingPrtReader.Read())
                    {
                        if (!livingPrtReader.IsDBNull(0)) { ad1 = livingPrtReader.GetString(0); }
                        if (!livingPrtReader.IsDBNull(1)) { ad2 = livingPrtReader.GetString(1); }
                        if (!livingPrtReader.IsDBNull(2)) { partnershipDate = livingPrtReader.GetInt32(2); } else { partnershipDate = 0; }
                    }
                    livingPrtReader.Close();
                    livingPrtReader.Dispose();

                    this.txtad1.Text = ad1;
                    this.txtad2.Text = ad2;
                    this.txtprtnrshipdt.Text = partnershipDate.ToString();
                }

                livingPrtObj.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["brn"] = brn;
                ViewState["epf"] = epf;

                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["flag"] = flag;
            }
            catch (Exception ex)
            {
                livingPrtObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["brn"] != null) { brn = int.Parse(ViewState["brn"].ToString()); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }

            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        livingPrtObj = new DataManager();
        try
        {            
            livingPrtObj.begintransaction();

            dateValidation dv = new dateValidation();

            sta = this.txtsta.Text.Trim();
            surname = this.txtsurname.Text.Trim();
            fullname = this.txtfullname.Text.Trim();
                        
            if ((this.txtdob.Text != null) && (!this.txtdob.Text.Equals(""))) { DOB = int.Parse(this.txtdob.Text.Trim()); }
            if (!dv.dateValid(DOB.ToString())) { throw new Exception("Invalid DOB"); }
            //if ((DOB > 0) && (this.txtdob.Text.ToString().Trim().Length < 8)) { this.cvdob.Text = "DOB Should be 8 Digits Long"; this.cvdob.IsValid = false; return; }
            if ((this.txtage.Text != null) && (!this.txtage.Text.Equals(""))) { age = int.Parse(this.txtage.Text.Trim()); }
            gender = this.ddlGender.SelectedItem.Value.ToString();
            NICno = this.txtnic.Text.Trim();
            passportno = this.txtpassprt.Text.Trim();
            email = this.txtemail.Text.Trim();
            telno = this.txttelno.Text.Trim();
            occupation = this.txtoccu.Text.Trim();
            ad1 = this.txtad1.Text.Trim();
            ad2 = this.txtad2.Text.Trim();

            NICno = NICno.Replace('\'', ' ');
            passportno = passportno.Replace('\'', ' ');
            email = email.Replace('\'', ' ');
            telno = telno.Replace('\'', ' ');
            occupation = occupation.Replace('\'', ' ');
            ad1 = ad1.Replace('\'', ' ');
            ad2 = ad2.Replace('\'', ' ');
            if ((this.txtprtnrshipdt.Text != null) && (!this.txtprtnrshipdt.Text.Equals(""))) { partnershipDate = int.Parse(this.txtprtnrshipdt.Text); }

            //----------- polpersonal insert -------------

            //string POLPERSONALselect = "select * from LUND.POLPERSONAL where polno=" + polno + " and PRPERTYPE = 9  ";
            //if (livingPrtObj.existRecored(POLPERSONALselect) == 0)
            //{
            //    string polpersonalInsert = "INSERT INTO LUND.POLPERSONAL (PRPERTYPE ,DOB ,AGE ,SEXCODE ,NICNO ,PASSPORTNO ,OCCUPATION ,STATUS ,SURNAME ,FULLNAME ,EMAIL ,TELEPHONE ,POLNO )";
            //    polpersonalInsert += "VALUES (9 ," + DOB + " ," + age + " ,'" + gender + "' , '" + NICno + "' ,'" + passportno + "' ,'" + occupation + "' ,'" + sta + "' ,'" + surname + "' ,'" + fullname + "' ,'" + email + "' ,'" + telno + "' ," + polno + "  )";
            //    livingPrtObj.insertRecords(polpersonalInsert);
            //}
            //else 
            //{
            //    string polpersonalUpd = "UPDATE LUND.POLPERSONAL SET DOB = " + DOB + " , AGE = " + age + " , SEXCODE = '" + gender + "' , NICNO = '" + NICno + "' , PASSPORTNO = '" + passportno + "' , OCCUPATION = '" + occupation + "' ,";
            //    polpersonalUpd += "STATUS = '" + sta + "' , SURNAME = '" + surname + "' , FULLNAME = '" + fullname + "' , EMAIL = '" + email + "' , TELEPHONE = '" + telno + "'  WHERE polno = " + polno + " and PRPERTYPE = 9  ";
            //    livingPrtObj.insertRecords(polpersonalUpd);
            //}

            //----------- living_prt insert --------------

            string livingprtSelect = "select * from LUND.LIVING_PRT where POLNO = " + polno + " ";
            if (livingPrtObj.existRecored(livingprtSelect) == 0)
            {
                string livingprtInsert = "INSERT INTO LUND.LIVING_PRT (POLNO ,NOMNAM ,NOMDOB ,NOMNIC ,NOMPER ,NOMAD1 ,NOMAD2 ,ENTEPF ,ENTDATE ,ENTIP, PRTNRSHIPDATE ) VALUES ";
                livingprtInsert += "(" + polno + " ,'" + fullname + "' ," + DOB + " ,'" + NICno + "' , 100 ,'" + ad1 + "' ,'" + ad2 + "' ,'" + epf + "' ," + int.Parse(this.setDate()[0]) + " ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', " + partnershipDate + "  )";
                livingPrtObj.insertRecords(livingprtInsert);
            }
            else {
                string livingprtUpd = "UPDATE LUND.LIVING_PRT SET NOMNAM = '" + fullname + "' , NOMDOB = " + DOB + " , NOMNIC = '" + NICno + "' , NOMAD1 = '" + ad1 + "' , NOMAD2 = '" + ad2 + "', PRTNRSHIPDATE = " + partnershipDate + " WHERE polno = " + polno + " ";
                livingPrtObj.insertRecords(livingprtUpd);
            }

            this.lblsuccess.Text = "Record Updated Successfully!";

            livingPrtObj.commit();
            livingPrtObj.connclose();
        }
        catch (Exception ex)
        {
            livingPrtObj.rollback();
            livingPrtObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

    }

    private int numberSeperator(string epf)
    {
        int x = 0;
        string s = "";
    a: for (int i = 0; i < epf.Length; i++)
        {
            try
            {
                x = int.Parse(epf.Substring(i, 1));
                s += x.ToString();
            }
            catch (Exception ex)
            {
                continue;
            }

        }
        return int.Parse(s);
    }
    
    protected void btnshares_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "");
    }
}
