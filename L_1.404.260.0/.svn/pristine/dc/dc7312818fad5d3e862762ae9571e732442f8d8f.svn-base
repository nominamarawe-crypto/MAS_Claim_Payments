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

public partial class assignee001 : System.Web.UI.Page
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

    private int polno;   
    private string sta;
    private string initial;
    private string surname;
    private string fullname;
    private string shortNmae;
    private string add1;
    private string add2;
    private string add3;
    private long acctNo;
    private int assignmentDate;
    private string EPF = "";
    //private string EPF = Convert.ToString(Session["EPFNum"]);

    DataManager dm;
    private double totamount;
    private double outAmt;
    private long claimno;
    private string MOF, flag;

    protected void Page_Load(object sender, EventArgs e)
    {
        string test = "";
        test = Request.QueryString["polno"];

        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
        }
        else if ((test != null) && (!test.Equals("")))
        {
            polno = int.Parse(Request.QueryString["polno"]);
            if (Request.QueryString["flag"] != null) { flag = Request.QueryString["flag"].ToString(); }
            if (Request.QueryString["totamount"] != null) { totamount = double.Parse(Request.QueryString["totamount"].ToString()); }
            if (Request.QueryString["outAmt"] != null) { outAmt = double.Parse(Request.QueryString["outAmt"].ToString()); }
            if (Request.QueryString["claimno"] != null) { claimno = long.Parse(Request.QueryString["claimno"].ToString()); }
            if (Request.QueryString["theMof"] != null) { MOF = Request.QueryString["theMof"].ToString(); }
        }       

        if (!Page.IsPostBack)
        {

            dm = new DataManager();
            try
            {
                if (flag != null && !flag.Equals("")) { //this.btnExit.Visible = false; 
                    this.btnshares.Visible = true; }
                else { //this.btnExit.Visible = true; 
                    this.btnshares.Visible = false; }

                this.lblpolno.Text = polno.ToString();
                string assigneeSelect = "select ASS_STATUS ,ASS_INITIAL ,ASS_SURNAME ,ASS_FULLNAME ,ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, ASSIGNDATE,ASS_AD3 from LUND.ASSIGNEE where POLICY_NO =" + polno + " ";
                if (dm.existRecored(assigneeSelect) != 0)
                {
                    dm.readSql(assigneeSelect);
                    OracleDataReader asiReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (asiReader.Read())
                    {
                        if (!asiReader.IsDBNull(0)) { sta = asiReader.GetString(0); } else { sta = ""; }
                        if (!asiReader.IsDBNull(1)) { initial = asiReader.GetString(1); } else { initial = ""; }
                        if (!asiReader.IsDBNull(2)) { surname = asiReader.GetString(2); } else { surname = ""; }
                        if (!asiReader.IsDBNull(3)) { fullname = asiReader.GetString(3); } else { fullname = ""; }
                        if (!asiReader.IsDBNull(4)) { shortNmae = asiReader.GetString(4); } else { shortNmae = ""; }
                        if (!asiReader.IsDBNull(5)) { add1 = asiReader.GetString(5); } else { add1 = ""; }
                        if (!asiReader.IsDBNull(6)) { add2 = asiReader.GetString(6); } else { add2 = ""; }
                        if (!asiReader.IsDBNull(7)) { acctNo = asiReader.GetInt64(7); } else { acctNo = 0; }
                        if (!asiReader.IsDBNull(8)) { assignmentDate = asiReader.GetInt32(8); } else { assignmentDate = 0; }
                        if (!asiReader.IsDBNull(9)) { add3 = asiReader.GetString(9); } else { add3 = ""; }
                    }
                    asiReader.Close();
                    asiReader.Dispose();

                    this.txtSta.Text = sta;
                    this.txtInt.Text = initial;
                    this.txtSurname.Text = surname;
                    this.txtFullNmae.Text = fullname;
                    this.txtShortName.Text = shortNmae;
                    this.txtAdd1.Text = add1;
                    this.txtAdd2.Text = add2;
                    this.txtAdd3.Text = add3;
                    this.txtAcctNo.Text = acctNo.ToString();
                    this.txtasignmentDate.Text = assignmentDate.ToString();
                }
                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["MOF"] = MOF;
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
            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
        }
        
    }  

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        //string EPF = Session["EPFNum"].ToString();
        try
        {          
            sta = this.txtSta.Text.Trim();
            initial = this.txtInt.Text.Trim();
            surname = this.txtSurname.Text.Trim();
            fullname = this.txtFullNmae.Text.ToString();
            shortNmae = this.txtShortName.Text.Trim();
            add1 = this.txtAdd1.Text.Trim();
            add2 = this.txtAdd2.Text.Trim();
            add3 = this.txtAdd3.Text.Trim();
            acctNo = long.Parse(this.txtAcctNo.Text.Trim());

            sta = sta.Replace('\'', ' ');
            initial = initial.Replace('\'', ' ');
            surname = surname.Replace('\'', ' ');
            fullname = fullname.Replace('\'', ' ');
            shortNmae = shortNmae.Replace('\'', ' ');
            add1 = add1.Replace('\'', ' ');
            add2 = add2.Replace('\'', ' ');
            if ((this.txtasignmentDate.Text != null) && (!this.txtasignmentDate.Text.Equals(""))) { assignmentDate = int.Parse(this.txtasignmentDate.Text); }

          

            string assigneeSelect = "select * from LUND.ASSIGNEE where POLICY_NO =" + polno + " ";
            if (dm.existRecored(assigneeSelect) == 0) {
                string prassigneeInsert = "INSERT INTO LUND.ASSIGNEE (ASS_STATUS ,ASS_INITIAL ,ASS_SURNAME ,ASS_FULLNAME ,ASS_SHORTNAME, ASS_AD1, ASS_AD2, ACCT_NO, POLICY_NO, ENTDT, ENTEPF, ASSIGNDATE,ASS_AD3 ) ";
                prassigneeInsert += " VALUES ('" + sta + "' ,'" + initial + "' ,'" + surname + "' ,'" + fullname + "' ,'" + shortNmae + "', '" + PrepareApostrophe(add1) + "', '" + PrepareApostrophe(add2) + "', " + acctNo + ", " + polno + ", " + int.Parse(this.setDate()[0]) + ",  '" + EPF + "', " + assignmentDate + ",'" + PrepareApostrophe(add3) + "' )";
                dm.insertRecords(prassigneeInsert);
            }
            else {
                string prassigneeUpd = "UPDATE LUND.ASSIGNEE SET ASS_STATUS = '" + sta + "' , ASS_INITIAL = '" + initial + "' , ASS_SURNAME = '" + surname + "' , ASS_FULLNAME = '" + fullname + "' , ASS_SHORTNAME = '" + shortNmae + "' , ASS_AD1 = '" +PrepareApostrophe(add1) + "' , ASS_AD2 = '" +PrepareApostrophe(add2) + "' , ACCT_NO = " + acctNo + ", ASSIGNDATE = " + assignmentDate + ",ASS_AD3='" + PrepareApostrophe(add3) + "' WHERE POLICY_NO = " + polno + " ";
                dm.insertRecords(prassigneeUpd);
                //throw new Exception("Record Already Exists!");            
            }

            this.lblsucess.Visible = true;

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnshares_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "");
    }

    public string PrepareApostrophe(string str)
    {
        string newStr = "";
        bool pZero = false, pEnd = false, pMiddle = false;

        if (str.IndexOf("'") < 0) return str;


        pZero = str.IndexOf("'") == 0 ? true : false;
        pEnd = str.LastIndexOf("'") + 1 == str.Length ? true : false;
        pMiddle = str.Substring(1, str.Length - 2).LastIndexOf("'") > 0 ? true : false;


        newStr = pZero && pMiddle && pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 2).Replace("'", "'||chr(39)||'") + "'||chr(39)|| '"
            : !pZero && pMiddle && pEnd ? str.Substring(0, (str.Length - 1)).Replace("'", "'||chr(39)||'") + "'||chr(39)|| '"
            : pZero && !pMiddle && pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 2) + "'||chr(39)|| '"
            : pZero && pMiddle && !pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 1).Replace("'", "'||chr(39)||'")
            : pZero && !pMiddle && !pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 1)
            : !pZero && !pMiddle && pEnd ? str.Substring(0, str.Length - 1) + "'||chr(39)|| '"
            : !pZero && pMiddle && !pEnd ? str.Substring(0, str.Length).Replace("'", "'||chr(39)||'")
            : str;

        return newStr;
    }
}
