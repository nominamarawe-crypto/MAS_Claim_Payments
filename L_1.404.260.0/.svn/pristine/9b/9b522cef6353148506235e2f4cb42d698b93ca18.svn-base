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

public partial class nomDetEnt01 : System.Web.UI.Page
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
    private int nomno;
    private  int nomnost;
    private string fullname;
    private string add1;
    private string add2;
    private int dateOfBirth;
    private string nicno;
    private int percentage;
    private string EPF = "";
    private int epfnum;
    private int rows3stat;
    private int nominateDate;

    private int totPercentage;
    private  int totPercentagest;
    DataManager proptopolObj;

    private  ArrayList arrList = new ArrayList();

    //******* variables for NOMINEE ***********

    private string NOMNAME;
    private int DOB;
    private string NIC, flag;
    private int PER;
    private int NOMNUM;
    //private  int brcode = 10;

    private double totamount;
    private double outAmt;
    private long claimno;
    private string MOF;

    protected void Page_Load(object sender, EventArgs e)
    {
        //polno = int.Parse(Request.QueryString["polno"].ToString());
        //string test = Request.QueryString["polno"].ToString();
        //EPF = Session["EPFNum"].ToString();

        
        string test = Request.QueryString["polno"];

        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;          
        }
        else if ((test != null) && (!test.Equals("")))
        {
            if (Request.QueryString["polno"] != null) { polno = int.Parse(Request.QueryString["polno"]); }
            if (Request.QueryString["flag"] != null) { flag = Request.QueryString["flag"].ToString(); }
            if (Request.QueryString["totamount"] != null) { totamount = double.Parse(Request.QueryString["totamount"].ToString()); }
            if (Request.QueryString["outAmt"] != null) { outAmt = double.Parse(Request.QueryString["outAmt"].ToString()); }
            if (Request.QueryString["claimno"] != null) { claimno = long.Parse(Request.QueryString["claimno"].ToString()); }
            if (Request.QueryString["theMof"] != null) { MOF = Request.QueryString["theMof"].ToString(); }
        }       

        proptopolObj = new DataManager();
        int rows3 = 0;
        try
        {
            if (Session["EPFNum"] != null || Session["brcode"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }
            else
            {
                throw new Exception("Your Session Variable Expired Please Log on to the System!");
            }


            if (!Page.IsPostBack)
            {
                epfnum = this.numberSeperator(EPF);

                if (flag != null && !flag.Equals("")) { this.btnExit.Visible = false; this.btnshares.Visible = true; }
                else { this.btnExit.Visible = true; this.btnshares.Visible = false; }
                               
                this.lblpolno.Text = polno.ToString();

                # region //----- existing nominees -------
                string nomSelect = "select NOMNO, NOMNAM, NOMDOB, NOMNIC, NOMPER from LUND.NOMINEE where POLNO = " + polno + " order by nomno ";

                if (proptopolObj.existRecored(nomSelect) != 0)
                {
                    proptopolObj.readSql(nomSelect);
                    OracleDataReader nomineeReader = proptopolObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomineeReader.Read())
                    {
                        if (!nomineeReader.IsDBNull(1)) { NOMNAME = nomineeReader.GetString(1); } else { NOMNAME = ""; }
                        if (!nomineeReader.IsDBNull(2)) { DOB = nomineeReader.GetInt32(2); } else { DOB = 0; }
                        if (!nomineeReader.IsDBNull(3)) { NIC = nomineeReader.GetString(3); } else { NIC = ""; }
                        if (!nomineeReader.IsDBNull(4)) { PER = nomineeReader.GetInt32(4); } else { PER = 0; }
                        if (!nomineeReader.IsDBNull(0)) { NOMNUM = nomineeReader.GetInt32(0); } else { NOMNUM = 0; }

                        totPercentage += PER;
                        if (nomno < NOMNUM) { nomno = NOMNUM; }

                        string[] arr = new string[4];
                        arr[0] = NOMNAME;
                        arr[1] = PER.ToString();
                        arr[2] = rows3.ToString();
                        arr[3] = NOMNUM.ToString();
                        arrList.Add(arr);
                        this.createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM);
                        rows3++;
                    }
                    nomineeReader.Close();
                    nomineeReader.Dispose();
                }
                else
                {
                    proptopolObj.connclose();
                    this.lblnommessage.Text = "No Nominee Details for this Policy";
                }
                #endregion

                nomno++;
                nomnost = nomno;
                ViewState["nomnost"] = nomnost;
                totPercentagest = totPercentage;

                if (totPercentage < 100) { this.btnSubmit.Enabled = true; }
                else { this.btnSubmit.Enabled = false; }

                rows3stat = rows3;

                ViewState["polno"] = polno;
                ViewState["nomnost"] = nomnost;               
                ViewState["totPercentagest"] = totPercentagest;
                ViewState["arrList"] = arrList;

                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["MOF"] = MOF;
                ViewState["flag"] = flag;
                ViewState["rows3stat"] = rows3stat;
            }
            else
            {
                if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
                if (ViewState["nomnost"] != null) { nomnost = int.Parse(ViewState["nomnost"].ToString()); }
                if (ViewState["totPercentagest"] != null) { totPercentagest = int.Parse(ViewState["totPercentagest"].ToString()); }
                if (ViewState["arrList"] != null) { arrList = (ArrayList)ViewState["arrList"]; }

                if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
                if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
                if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
                if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
                if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
                if (ViewState["rows3stat"] != null) { rows3stat = int.Parse(ViewState["rows3stat"].ToString()); }     

                foreach (string[] arr in arrList) 
                {
                    NOMNAME = arr[0].ToString();
                    PER = int.Parse(arr[1].ToString());
                    rows3 = int.Parse(arr[2].ToString());
                    NOMNUM = int.Parse(arr[3].ToString());
                    this.createNomineeTable(NOMNAME, PER.ToString(), rows3, NOMNUM);
                }
            }

            proptopolObj.connclose();

        }
        catch (Exception ex)
        {
            proptopolObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnUpd_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnshares_Click(object sender, EventArgs e)
    {

        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "");

        //proptopolObj = new DataManager();
        //try
        //{
        
        //    proptopolObj.connclose();
        //}
        //catch (Exception ex)
        //{
        //    proptopolObj.connclose();
        //    EPage.Messege = ex.Message;
        //    Response.Redirect("EPage.aspx");
        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        proptopolObj = new DataManager();
        try
        {                       
            fullname = this.txtname.Text.Trim();
            fullname = fullname.Replace('\'', ' ');
            add1 = this.txtAdd1.Text.Trim();
            add1 = add1.Replace('\'', ' ');
            add2 = this.txtAdd2.Text.Trim();
            add2 = add2.Replace('\'', ' ');
            if ((this.txtDOB.Text != null) && (!this.txtDOB.Text.Equals(""))) { dateOfBirth = int.Parse(this.txtDOB.Text.Trim()); }
            else { dateOfBirth = 0; }
            dateValidation dv = new dateValidation();
            if (!dv.dateValid(dateOfBirth.ToString())) { throw new Exception("Invalid Date of Birth"); }

            nicno = this.txtNICno.Text.Trim();
            nicno = nicno.Replace('\'', ' ');
            if ((this.txtPer.Text != null) && (!this.txtPer.Text.Equals(""))) { percentage = int.Parse(this.txtPer.Text.Trim()); } else { throw new Exception("Please Enter a Percentage"); }
            if ((this.txtnominatedate.Text != null) && (!this.txtnominatedate.Text.Equals(""))) { nominateDate = int.Parse(this.txtnominatedate.Text); }

            if ((totPercentagest + percentage) <= 100)
            {
                string nomiCheck = "select * from lund.nominee where polno=" + polno + "  and  NOMNO = " + nomnost + " ";
                if (proptopolObj.existRecored(nomiCheck) == 0)
                {
                    string nomInsert = "INSERT INTO LUND.NOMINEE (POLNO ,NOMNO ,NOMNAM ,NOMDOB ,NOMNIC ,NOMPER ,NOMAD1 ,NOMAD2 ,ENTEPF ,ENTDATE ,ENTIP, NOMINATEDATE )";
                    nomInsert += "VALUES (" + polno + " ," + nomnost + " ,'" + fullname + "' ," + dateOfBirth + " ,'" + nicno + "' ," + percentage + " , ";
                    nomInsert += " '" + add1 + "' ,'" + add2 + "' ,'" + EPF + "' ," + int.Parse(this.setDate()[0]) + " ,'" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "',  " + nominateDate + " )";

                    proptopolObj.insertRecords(nomInsert);

                    this.lblsuccess.Text = "Record Added Successfully!";
                }
                else
                {
                    proptopolObj.connclose();
                    throw new Exception("Record Already Exists!");
                }

                int rows3 = rows3stat + 1;

                this.createNomineeTable(fullname, percentage.ToString(), rows3, nomnost);

                                this.txtAdd1.Text = "";
                                this.txtAdd2.Text = "";
                                this.txtDOB.Text = "";
                                this.txtname.Text = "";
                                this.txtNICno.Text = ""; 
                                this.txtPer.Text = "";

                this.lblnommessage.Text = "Existing Nominees";

            }
            else {
                this.percenatgeValidator.IsValid = false;
                //throw new Exception("Total Percenatage Exceeds 100! Please Enter a Proper Percentage.");
            }
            proptopolObj.connclose();
        }
        catch (Exception ex)
        {
            proptopolObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    private void createNomineeTable(string nominee, string percentage, int rowNumber, int nomnum)
    {
        TableRow trow = new TableRow();
        TableCell tcell0 = new TableCell();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl0 = new Label();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl0.ID = "nomnum" + rowNumber;
        lbl0.Attributes.Add("runat", "Server");
        lbl0.Attributes.Add("Name", "nomnum" + rowNumber); //Text Value
        lbl0.Text = nomnum.ToString();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "nominee" + rowNumber); //Text Value
        lbl1.Text = nominee;

        lbl2.ID = "percentage" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "percentage" + rowNumber); //Text Value
        lbl2.Text = percentage + "%";

        tcell0.Controls.Add(lbl0);
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        trow.Cells.Add(tcell0);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        Table2.Rows.Add(trow);
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

    public int Polno {
        get { return polno; }
        set { polno = value; }
    }
    public int TotPercentagest {
        get { return totPercentagest; }
        set { totPercentagest = value; }
    }
    public double Totamount
    {
        get { return totamount; }
        set { totamount = value; }
    }
    public double OutAmt
    {
        get { return outAmt; }
        set { outAmt = value; }
    }
    public long Claimno
    {
        get { return claimno; }
        set { claimno = value; }
    }
    public string mOF
    {
        get { return MOF; }
        set { MOF = value; }
    }
    public string Flag
    {
        get { return flag; }
        set { flag = value; }
    }

}
