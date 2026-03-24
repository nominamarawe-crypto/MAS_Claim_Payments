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

public partial class nomDetEnt03 : System.Web.UI.Page
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
    private  int nomno;
    private string fullname;
    private string add1;
    private string add2;
    private int dateOfBirth;
    private string nicno;
    private int percentage;
    private string EPF = "";
    //private int epfnum;
    private int nominateDate;

    private int totPercentagest;
    DataManager proptopolObj;

    private double totamount;
    private double outAmt;
    private long claimno;
    private string MOF, flag;

    protected void Page_Load(object sender, EventArgs e)
    {
        //EPF = Session["EPFNum"].ToString();

        if (Session["EPFNum"] != null || Session["brcode"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            nomno = this.PreviousPage.Nomno;
            totPercentagest = this.PreviousPage.TotPercentagest;

            totamount = this.PreviousPage.Totamount;
            outAmt = this.PreviousPage.OutAmt;
            claimno = this.PreviousPage.Claimno;
            MOF = this.PreviousPage.mOF;
            flag = this.PreviousPage.Flag;
        }
        if (!Page.IsPostBack)
        {
            proptopolObj = new DataManager();
            try
            {
                if (flag != null && !flag.Equals("")) { this.btnExit.Visible = false; this.btnshares.Visible = true; }
                else { this.btnExit.Visible = true; this.btnshares.Visible = false; }

                string nomSelect = "select NOMNAM, NOMDOB, NOMNIC, NOMPER, NOMAD1, NOMAD2, NOMINATEDATE from LUND.NOMINEE where polno=" + polno + " and nomno = " + nomno + "   ";
                if (proptopolObj.existRecored(nomSelect) != 0)
                {
                    proptopolObj.readSql(nomSelect);
                    OracleDataReader nomReader = proptopolObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomReader.Read())
                    {
                        if (!nomReader.IsDBNull(0)) { fullname = nomReader.GetString(0); } else { fullname = ""; }
                        if (!nomReader.IsDBNull(1)) { dateOfBirth = nomReader.GetInt32(1); } else { dateOfBirth = 0; }
                        if (!nomReader.IsDBNull(2)) { nicno = nomReader.GetString(2); } else { nicno = ""; }
                        if (!nomReader.IsDBNull(3)) { percentage = nomReader.GetInt32(3); } else { percentage = 0; }
                        if (!nomReader.IsDBNull(4)) { add1 = nomReader.GetString(4); } else { add1 = ""; }
                        if (!nomReader.IsDBNull(5)) { add2 = nomReader.GetString(5); } else { add2 = ""; }
                        if (!nomReader.IsDBNull(6)) { nominateDate = nomReader.GetInt32(6); } else { nominateDate = 0; }
                    }
                    nomReader.Close();
                    nomReader.Dispose();

                }
                else
                {
                    proptopolObj.connclose();
                    throw new Exception("No Such Record Exists!");
                }


                this.lblpolno.Text = polno.ToString();
                this.txtNomNum.Text = nomno.ToString();

                this.txtname.Text = fullname;
                this.txtDOB.Text = dateOfBirth.ToString();
                this.txtNICno.Text = nicno;
                this.txtPer.Text = percentage.ToString();
                this.txtAdd1.Text = add1;
                this.txtAdd2.Text = add2;
                this.txtnominateDate.Text = nominateDate.ToString();

                proptopolObj.connclose();

                ViewState["polno"] = polno;
                ViewState["nomno"] = nomno;
                ViewState["totPercentagest"] = totPercentagest;

                ViewState["totamount"] = totamount;
                ViewState["outAmt"] = outAmt;
                ViewState["claimno"] = claimno;
                ViewState["MOF"] = MOF;
                ViewState["flag"] = flag;
            }
            catch (Exception ex)
            {
                proptopolObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else 
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["nomno"] != null) { nomno = int.Parse(ViewState["nomno"].ToString()); }
            if (ViewState["totPercentagest"] != null) { totPercentagest = int.Parse(ViewState["totPercentagest"].ToString()); }

            if (ViewState["totamount"] != null) { totamount = double.Parse(ViewState["totamount"].ToString()); }
            if (ViewState["outAmt"] != null) { outAmt = double.Parse(ViewState["outAmt"].ToString()); }
            if (ViewState["claimno"] != null) { claimno = long.Parse(ViewState["claimno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["flag"] != null) { flag = ViewState["flag"].ToString(); }
        }
    }
    protected void btnUpd_Click(object sender, EventArgs e)
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
            nicno = this.txtNICno.Text.Trim();
            nicno = nicno.Replace('\'', ' ');
            percentage = int.Parse(this.txtPer.Text.Trim());
            if ((this.txtnominateDate.Text != null) && (!this.txtnominateDate.Text.Equals(""))) { nominateDate = int.Parse(this.txtnominateDate.Text); }

            if (percentage <= 100)
            {
                string nomiCheck = "select * from lund.nominee where polno=" + polno + "  and  NOMNO = " + nomno + " ";
                if (proptopolObj.existRecored(nomiCheck) != 0)
                {
                    string nomiUpd = "UPDATE LUND.NOMINEE SET NOMNAM = '" + fullname + "' , NOMDOB = " + dateOfBirth + " , NOMNIC = '" + nicno + "' , NOMPER = " + percentage + " , NOMAD1 = '" + add1 + "' , NOMAD2 = '" + add2 + "' , ";
                    nomiUpd += "ENTEPF = '" + EPF + "' , ENTDATE = " + int.Parse(this.setDate()[0]) + " , ENTIP = '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', NOMINATEDATE = " + nominateDate + " WHERE polno = " + polno + "  and nomno = " + nomno + " ";

                    proptopolObj.insertRecords(nomiUpd);
                    this.lblsuccess.Text = "Record Updated Successfully!";
                }
                else
                {
                    proptopolObj.connclose();
                    throw new Exception("No Such Record Exists!");
                }
            }
            else
            {
                this.percenatgeValidator.IsValid = false;
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
    protected void btnDel_Click(object sender, EventArgs e)
    {
        proptopolObj = new DataManager();
        try
        {          
            string nomiCheck = "select * from lund.nominee where polno=" + polno + "  and  NOMNO = " + nomno + " ";
            if (proptopolObj.existRecored(nomiCheck) != 0)
            {
                string nomiDel = "delete from lund.nominee where polno=" + polno + "  and  NOMNO = " + nomno + " ";
                proptopolObj.insertRecords(nomiDel);
                this.lblsuccess.Text = "Record Deleted!";
            }
            else
            {
                proptopolObj.connclose();
                throw new Exception("No Such Record Exists!");
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

    protected void btnshares_Click(object sender, EventArgs e)
    {
        Response.Redirect("paymentDistn001.aspx?polno=" + polno + "&theMof=" + MOF + "&claimno=" + claimno + "&totamount=" + totamount + "&outAmt=" + outAmt + "");
    }
}
