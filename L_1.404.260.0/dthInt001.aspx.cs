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

public partial class dthInt001 : System.Web.UI.Page
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
    private string MOF;
    private  int infodat;
    private  int dateofDeath;
    private  int clm;
    private  string polstat;
    private  string NOD;
    private  string methOfInfo;
    private  string infoID;
    private  string infoname;
    private  string infoad1;
    private  string infoad2;
    private  string infoad3;
    private  string infoad4;
    private  string inforel;
    private  long infotel = 0;
    private  int BRN = 0;
    private  string entEPF = "";
    private  string error = "";

    private double sumassured;
    private int table;
    private int term;
    private int dateofComm;
    private string phname;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;

    DataManager dthintobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["brcode"] != null && Session["EPFNum"] != null)
            {
                //branch = Convert.ToInt32(Session["brcode"]);
                entEPF = Session["EPFNum"].ToString();
                BRN = Convert.ToInt32(Session["brcode"]);
            }
            else
            {
                throw new Exception("Your Session Variable Expired Please Log on to the System!");
            }

            if (!Page.IsPostBack)
            {
                this.txtdtofinfo.Text = setDate()[0];
                // this.txtdtofdth.Text = setDate()[0];
                this.ddlMOS.Items.Add(new ListItem("Main Life", "M"));
                this.ddlMOS.Items.Add(new ListItem("Spouse", "S"));
                this.ddlMOS.Items.Add(new ListItem("Second Life", "2"));

                this.ddlinfometh.Items.Add(new ListItem("Counter", "COUN"));
                this.ddlinfometh.Items.Add(new ListItem("Mail", "MAIL"));
                this.ddlinfometh.Items.Add(new ListItem("Call", "CALL"));
            }
            else
            {
                if (!this.ddlMOS.SelectedItem.Value.Equals("M"))
                    this.txtnameofdd.Text = "";
            }

        }
        catch (Exception ex) {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)  
    {
        dthintobj = new DataManager();
            try
            {
               
                polno = int.Parse(this.txtpolno.Text.Trim());
                MOF = this.ddlMOS.SelectedItem.Value;
                infodat = int.Parse(this.txtdtofinfo.Text.Trim());
                dateofDeath = int.Parse(this.txtdtofdth.Text.Trim());
                
                string polstatus = this.lblpolstat.Text;
                if (polstatus.Equals("INFORCE"))
                {
                    polstat = "I";
                }
                else {
                    polstat = "L";
                }
                
                NOD = this.txtnameofdd.Text.Trim();
                methOfInfo = this.ddlinfometh.Text.Trim();
                infoID = this.txtinfoid.Text.Trim();
                infoname = this.txtinfoname.Text.Trim();
                infoad1 = this.txtinfoad1.Text.Trim();
                infoad2 = this.txtinfoad2.Text.Trim();
                infoad3 = this.txtinfoad3.Text.Trim();
                infoad4 = this.txtinfoad4.Text.Trim();
                if (!(this.txtinfotel.Text.Equals(null)) && !(this.txtinfotel.Text.Equals("")))
                {
                    infotel = Convert.ToInt64(this.txtinfotel.Text);
                }
                inforel = this.txtinforel.Text;

                dthintobj.begintransaction();

                string dthintCheck = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";

                if (dthintobj.existRecored(dthintCheck) == 0)
                {
                    string dthintInsertSQL = "insert into lphs.dthint (dpolno, dmos, dclm, dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1, diad2, diad3, diad4, ditel, drecbrn, dentepf, denttim, dentip, dinforel) ";
                    dthintInsertSQL += " values (" + polno + ", '" + MOF + "', " + clm + ", " + infodat + ", '" + polstat + "', '" + NOD + "', " + dateofDeath + ", '" + methOfInfo + "', '" + infoID + "', '" + infoname + "', '" + infoad1 + "','" + infoad2 + "','" + infoad3 + "','" + infoad4 + "'," + infotel + "," + BRN + ", '" + entEPF + "', '" + setDate()[1] + "', '" + Context.Request.ServerVariables["REMOTE_ADDR"].ToString() + "', '"+inforel+"' ) ";
                    dthintobj.insertRecords(dthintInsertSQL);
                }
                else
                {
                    dthintobj.connclose();
                    throw new Exception("Details Already Exist!");
                }

                dthintobj.commit();
                dthintobj.connclose();
            }
            catch (Exception ex)
            {

                if (error.Equals(null) || error.Equals(""))
                {
                    EPage.Messege = ex.Message;
                }
                else
                {
                    EPage.Messege = error;

                }
                Response.Redirect("EPage.aspx");
            }

            formclear();
            this.txtpolno.Text = "";
            this.lblpolstat.Text = "";
            this.ddlMOS.SelectedItem.Value = "M";
            this.lblsumassured.Text = "";
            this.lbltab.Text = "";
            this.lblterm.Text = "";
            this.lbldtofcomm.Text = "";
          
            this.lblnameofInsured.Text = "";
            this.lblassuredad1.Text = "";
            this.lblassuredad2.Text = "";
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        this.formclear();
    }
    
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        dthintobj = new DataManager();
        try {
           
            polno = int.Parse(this.txtpolno.Text.Trim());
            MOF = this.ddlMOS.SelectedItem.Value;
            infodat = int.Parse(this.txtdtofinfo.Text.Trim());
            if ((!this.txtdtofdth.Text.Trim().Equals(null)) && (!this.txtdtofdth.Text.Trim().Equals("")))
            { dateofDeath = int.Parse(this.txtdtofdth.Text.Trim()); }
           
            string polstatus = this.lblpolstat.Text;
            if (polstatus.Equals("INFORCE"))  polstat = "I";
            
            else  polstat = "L";
            
            NOD = this.txtnameofdd.Text.Trim();
            methOfInfo = this.ddlinfometh.Text.Trim();
            infoID = this.txtinfoid.Text.Trim();
            infoname = this.txtinfoname.Text.Trim();
            infoad1 = this.txtinfoad1.Text.Trim();
            infoad2 = this.txtinfoad2.Text.Trim();
            infoad3 = this.txtinfoad3.Text.Trim();
            infoad4 = this.txtinfoad4.Text.Trim();
            if (!(this.txtinfotel.Text.Equals(null)) && !(this.txtinfotel.Text.Equals("")))
            {
                infotel = Convert.ToInt64(this.txtinfotel.Text);
            }
            inforel = this.txtinforel.Text;

            dthintobj.begintransaction();

            string updateprecondition = "select * from lphs.dthint where  dpolno=" + polno + " and dmos='" + MOF + "' and dsta='0' and dconfst is null ";

            if (dthintobj.existRecored(updateprecondition) != 0)
            {
                string dthintUPDSQL = "update lphs.dthint set dclm=" + clm + ",  dinfodat= " + infodat + ", dpolst='" + polstat + "', dnod='" + NOD + "', ddtofdth=" + dateofDeath + ", dmoinf='" + methOfInfo + "', diid='" + infoID + "', diname='" + infoname + "', diad1= '" + infoad1 + "', diad2= '" + infoad2 + "', diad3= '" + infoad3 + "', diad4= '" + infoad4 + "', ditel=" + infotel + ", dupdepf='" + entEPF + "', dupdbrn=" + BRN + ", dupddate=" + int.Parse(setDate()[0]) + ", dinforel='" + inforel + "' where dpolno=" + polno + " and dmos='" + MOF + "' and dsta='0' and dconfst is null";
                dthintobj.insertRecords(dthintUPDSQL);

            }
            else
            {
                dthintobj.connclose();
                throw new Exception("Details Either Confirmed or Converted! Cannot Update.");
            }

            dthintobj.commit();
            dthintobj.connclose();
        }
        catch(Exception ex){
            if (error.Equals(null) || error.Equals(""))   EPage.Messege = ex.Message;
            
            else    EPage.Messege = error;
            
            Response.Redirect("EPage.aspx");
        
        }
    }

    protected void btndel_Click(object sender, EventArgs e)
    {
        dthintobj = new DataManager();
        try
        {
          
            polno = int.Parse(this.txtpolno.Text.Trim());
            MOF = this.ddlMOS.SelectedItem.Value;
            infodat = int.Parse(this.txtdtofinfo.Text.Trim());
            dateofDeath = int.Parse(this.txtdtofdth.Text.Trim());
          
            string polstatus = this.lblpolstat.Text;
            if (polstatus.Equals("INFORCE"))
            {
                polstat = "I";
            }
            else
            {
                polstat = "L";
            }
            NOD = this.txtnameofdd.Text.Trim();
            methOfInfo = this.ddlinfometh.Text.Trim();
            infoID = this.txtinfoid.Text.Trim();
            infoname = this.txtinfoname.Text.Trim();
            infoad1 = this.txtinfoad1.Text.Trim();
            infoad2 = this.txtinfoad2.Text.Trim();
            infoad3 = this.txtinfoad3.Text.Trim();
            infoad4 = this.txtinfoad4.Text.Trim();
            if (!(this.txtinfotel.Text.Equals(null)) && !(this.txtinfotel.Text.Equals("")))
            {
                infotel = Convert.ToInt64(this.txtinfotel.Text);
            }
            inforel = this.txtinforel.Text;

            dthintobj.begintransaction();

            string updateprecondition = "select * from lphs.dthint where  dpolno=" + polno + " and dmos='" + MOF + "' and dsta='0' and dconfst is null ";

            if (dthintobj.existRecored(updateprecondition) != 0)
            {
                string dthintDelSQL = "delete from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' and dsta='0' and dconfst is null";
                dthintobj.insertRecords(dthintDelSQL);

            }
            else
            {
                dthintobj.connclose();
                throw new Exception("Details Either Confirmed or Converted! Cannot Delete.");
            }

            dthintobj.commit();
            formclear();
            this.txtpolno.Text = "";
            this.lblpolstat.Text = "";
            this.ddlMOS.SelectedItem.Value = "M";
            this.lblsumassured.Text = "";
            this.lbltab.Text = "";
            this.lblterm.Text = "";
            this.lbldtofcomm.Text = "";
           
            this.lblnameofInsured.Text = "";
            this.lblassuredad1.Text = "";
            this.lblassuredad2.Text = "";

            dthintobj.connclose();
        }
        catch (Exception ex) {
            if (error.Equals(null) || error.Equals(""))
            {
                EPage.Messege = ex.Message;
            }
            else
            {
                EPage.Messege = error;
            }
            Response.Redirect("EPage.aspx");
        }

    }
     
    protected void ddlMOS_SelectedIndexChanged(object sender, EventArgs e)
    {
        dthintobj = new DataManager();
        try
        {
           
            if (this.txtpolno.Text.Equals(null) || this.txtpolno.Text.Equals(""))
            {
                this.RequiredFieldValidator1.IsValid = false;
            }
            else
            {
                polno = int.Parse(this.txtpolno.Text.Trim());
                MOF = this.ddlMOS.SelectedItem.Value;
            }

            string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom from lphs.premast where pmpol=" + polno + " ";
            string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom from lphs.liflaps where lppol=" + polno + " ";

            if (dthintobj.existRecored(premastSelect) != 0)
            {
                dthintobj.readSql(premastSelect);
                OracleDataReader premReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                premReader.Read();
                sumassured = premReader.GetDouble(0);
                table = premReader.GetInt32(1);
                term = premReader.GetInt32(2);
                dateofComm = premReader.GetInt32(3);
                polstat = "I";
                premReader.Close();
                premReader.Dispose();
            }
            else if (dthintobj.existRecored(liflapsSelect) != 0)
            {
                dthintobj.readSql(liflapsSelect);
                OracleDataReader lapsReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                lapsReader.Read();
                sumassured = lapsReader.GetDouble(0);
                table = lapsReader.GetInt32(1);
                term = lapsReader.GetInt32(2);
                dateofComm = lapsReader.GetInt32(3);
                polstat = "L";
                lapsReader.Close();
                lapsReader.Dispose();
            }
            else
            {
                string lsurefcheck = "select * from lphs.dthref where DRPOLNO=" + polno + " and DRMOS='" + MOF + "'";
                if (dthintobj.existRecored(lsurefcheck) == 0)
                {
                    dthintobj.connclose();
                    throw new Exception("No Policy Details!");
                }
                else
                {
                    dthintobj.connclose();
                    throw new Exception("Policy Registered! Cannot Alter.");
                }

            }

            this.lblsumassured.Text = String.Format("{0:N}", sumassured);
            this.lbltab.Text = table.ToString();
            this.lblterm.Text = term.ToString();
            this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);

            // ************** PHNAME  ********************************************************************

            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            dthintobj.readSql(sql);
            OracleDataReader oraDtReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (oraDtReader.Read())
            {
                if (!oraDtReader.IsDBNull(0))
                {
                    phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                }
                if (!oraDtReader.IsDBNull(3))
                {
                    ad1 = (oraDtReader.GetString(3));
                }
                if (!oraDtReader.IsDBNull(4))
                {
                    ad2 = (oraDtReader.GetString(4));
                }
                if (!oraDtReader.IsDBNull(5))
                {
                    ad3 = (oraDtReader.GetString(5));
                }
                if (!oraDtReader.IsDBNull(6))
                {
                    ad4 = (oraDtReader.GetString(6));
                }

            }
            oraDtReader.Close();
            oraDtReader.Dispose();

            this.lblnameofInsured.Text = phname;
            if (MOF.Equals("M"))
            {
                this.txtnameofdd.Text = phname;
            }
            this.lblassuredad1.Text = ad1 + " " + ad2;
            this.lblassuredad2.Text = ad3 + " " + ad4;


            //--------------------------------------------------------------------------------------------------
            string dthintCheck = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";
            if (dthintobj.existRecored(dthintCheck) != 0)
            {
                this.btnupdate.Enabled = true;
                this.btndel.Enabled = true;
                this.btnsubmit.Enabled = false;

                string dthintDetails = "select dclm, dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1, diad2, diad3, diad4, ditel, dinforel from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";
                dthintobj.readSql(dthintDetails);
                OracleDataReader dthintReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    clm = dthintReader.GetInt32(0);
                    infodat = dthintReader.GetInt32(1);
                    dateofDeath = dthintReader.GetInt32(4);
                    if (!dthintReader.IsDBNull(2))
                    {
                        polstat = dthintReader.GetString(2);
                    }
                    if (!dthintReader.IsDBNull(3))
                    {
                        NOD = dthintReader.GetString(3);
                    }
                    if (!dthintReader.IsDBNull(5))
                    {
                        methOfInfo = dthintReader.GetString(5);
                    }
                    if (!dthintReader.IsDBNull(6))
                    {
                        infoID = dthintReader.GetString(6);
                    }
                    if (!dthintReader.IsDBNull(7))
                    {
                        infoname = dthintReader.GetString(7);
                    }
                    if (!dthintReader.IsDBNull(8))
                    {
                        infoad1 = dthintReader.GetString(8);
                    }
                    if (!dthintReader.IsDBNull(9))
                    {
                        infoad2 = dthintReader.GetString(9);
                    }
                    if (!dthintReader.IsDBNull(10))
                    {
                        infoad3 = dthintReader.GetString(10);
                    }
                    if (!dthintReader.IsDBNull(11))
                    {
                        infoad4 = dthintReader.GetString(11);
                    }
                    if (!dthintReader.IsDBNull(12))
                    {
                        infotel = dthintReader.GetInt64(12);
                    }
                    if (!dthintReader.IsDBNull(13))
                    {
                        inforel = dthintReader.GetString(13);
                    }

                }
                dthintReader.Close();
                dthintReader.Dispose();

                this.txtnameofdd.Text = NOD;
                this.txtdtofinfo.Text = infodat.ToString();
                this.txtdtofdth.Text = dateofDeath.ToString();
                this.txtinfoname.Text = infoname;
                this.txtinfoad1.Text = infoad1;
                this.txtinfoad2.Text = infoad2;
                this.txtinfoad3.Text = infoad3;
                this.txtinfoad4.Text = infoad4;
                this.txtinfoid.Text = infoID;
                this.txtinfotel.Text = infotel.ToString();
                this.txtinforel.Text = inforel;
                this.lblpolstat.Text = polstatselect(polstat);
                this.ddlinfometh.SelectedIndex = infomethselect(methOfInfo);

            }
            else
            {
                formclear();
                this.btnsubmit.Enabled = true;
                this.btndel.Enabled = false;
                this.btnupdate.Enabled = false;
            }
            dthintobj.connclose();
        }
        catch (Exception ex) {
            dthintobj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }        
    }

    protected void txtpolno_TextChanged(object sender, EventArgs e)
    #region
    {
        dthintobj = new DataManager();
        try
        {
          
            polno = int.Parse(this.txtpolno.Text.Trim());
            MOF = this.ddlMOS.SelectedItem.Value;

            string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom from lphs.premast where pmpol=" + polno + " ";
            string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom from lphs.liflaps where lppol=" + polno + " ";

            if (dthintobj.existRecored(premastSelect) != 0)
            {
                dthintobj.readSql(premastSelect);
                OracleDataReader premReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                premReader.Read();
                sumassured = premReader.GetDouble(0);
                table = premReader.GetInt32(1);
                term = premReader.GetInt32(2);
                dateofComm = premReader.GetInt32(3);
                polstat = "I";
                premReader.Close();
                premReader.Dispose();
            }
            else if (dthintobj.existRecored(liflapsSelect) != 0)
            {
                dthintobj.readSql(liflapsSelect);
                OracleDataReader lapsReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                lapsReader.Read();
                sumassured = lapsReader.GetDouble(0);
                table = lapsReader.GetInt32(1);
                term = lapsReader.GetInt32(2);
                dateofComm = lapsReader.GetInt32(3);
                polstat = "L";
                lapsReader.Close();
                lapsReader.Dispose();
            }
            else
            {
                dthintobj.connclose();
                throw new Exception("No Policy Details!");
            }

            this.lblsumassured.Text = String.Format("{0:N}", sumassured);
            this.lbltab.Text = table.ToString();
            this.lblterm.Text = term.ToString();
            this.lbldtofcomm.Text = dateofComm.ToString().Substring(0, 4) + "/" + dateofComm.ToString().Substring(4, 2) + "/" + dateofComm.ToString().Substring(6, 2);

            // ************** PHNAME  ********************************************************************

            string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
            dthintobj.readSql(sql);
            OracleDataReader oraDtReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (oraDtReader.Read())
            {
                if (!oraDtReader.IsDBNull(0))
                {
                    phname = oraDtReader.GetString(0) + " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);
                }
                if (!oraDtReader.IsDBNull(3))
                {
                    ad1 = (oraDtReader.GetString(3));
                }
                if (!oraDtReader.IsDBNull(4))
                {
                    ad2 = (oraDtReader.GetString(4));
                }
                if (!oraDtReader.IsDBNull(5))
                {
                    ad3 = (oraDtReader.GetString(5));
                }
                if (!oraDtReader.IsDBNull(6))
                {
                    ad4 = (oraDtReader.GetString(6));
                }

            }
            oraDtReader.Close();
            oraDtReader.Dispose();

            this.lblnameofInsured.Text = phname;
            if (MOF.Equals("M")) {
                this.txtnameofdd.Text = phname;
            }
            this.lblassuredad1.Text = ad1 + " " + ad2;
            this.lblassuredad2.Text = ad3 + " " + ad4;

           
            //-----------------------------------------------------------------------------------------------

            string dthintCheck = "select * from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";
            if (dthintobj.existRecored(dthintCheck) != 0)
            {
                this.btnupdate.Enabled = true;
                this.btndel.Enabled = true;
                this.btnsubmit.Enabled = false;

                string dthintDetails = "select dclm, dinfodat, dpolst, dnod, ddtofdth, dmoinf, diid, diname, diad1, diad2, diad3, diad4, ditel, dinforel from lphs.dthint where dpolno=" + polno + " and dmos='" + MOF + "' ";
                dthintobj.readSql(dthintDetails);
                OracleDataReader dthintReader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {

                    clm = dthintReader.GetInt32(0);
                    infodat = dthintReader.GetInt32(1);
                    dateofDeath = dthintReader.GetInt32(4);
                    //if (!dthintReader.IsDBNull(2))
                    //{
                    //    polstat = dthintReader.GetString(2);
                    //}
                    if (!dthintReader.IsDBNull(3))
                    {
                        NOD = dthintReader.GetString(3);
                    }
                    if (!dthintReader.IsDBNull(5))
                    {
                        methOfInfo = dthintReader.GetString(5);
                    }
                    if (!dthintReader.IsDBNull(6))
                    {
                        infoID = dthintReader.GetString(6);
                    }
                    if (!dthintReader.IsDBNull(7))
                    {
                        infoname = dthintReader.GetString(7);
                    }
                    if (!dthintReader.IsDBNull(8))
                    {
                        infoad1 = dthintReader.GetString(8);
                    }
                    if (!dthintReader.IsDBNull(9))
                    {
                        infoad2 = dthintReader.GetString(9);
                    }
                    if (!dthintReader.IsDBNull(10))
                    {
                        infoad3 = dthintReader.GetString(10);
                    }
                    if (!dthintReader.IsDBNull(11))
                    {
                        infoad4 = dthintReader.GetString(11);
                    }
                   
                    infotel = dthintReader.GetInt64(12);
                    
                    if (!dthintReader.IsDBNull(13))
                    {
                        inforel = dthintReader.GetString(13);
                    }
                }
                dthintReader.Close();
                dthintReader.Dispose();
               
                this.txtdtofinfo.Text = infodat.ToString();
                if (!MOF.Equals("M"))
                {
                    this.txtnameofdd.Text = NOD;
                }
                else {
                    this.txtnameofdd.Text = phname;
                }
             
                this.txtdtofinfo.Text = infodat.ToString();
                this.txtdtofdth.Text = dateofDeath.ToString();
                this.txtinfoname.Text = infoname;
                this.txtinfoad1.Text = infoad1;
                this.txtinfoad2.Text = infoad2;
                this.txtinfoad3.Text = infoad3;
                this.txtinfoad4.Text = infoad4;
                this.txtinfoid.Text = infoID;
                this.txtinforel.Text = inforel;
                this.txtinfotel.Text = infotel.ToString();
                this.lblpolstat.Text = polstatselect(polstat);
                this.ddlinfometh.SelectedIndex = infomethselect(methOfInfo);


               
            }
            else
            {
                formclear();
                this.btnsubmit.Enabled = true;
                this.lblpolstat.Text = polstatselect(polstat);
                this.btndel.Enabled = false;
                this.btnupdate.Enabled = false;
            }
            dthintobj.connclose();
        }
        catch (Exception ex) {

            if (error.Equals(null) || error.Equals(""))
            {
                EPage.Messege = ex.Message;

            }
            else {
                EPage.Messege = error;
            
            }
            Response.Redirect("EPage.aspx");
        }

    }
    #endregion
    private void formclear()
    {
        this.ddlinfometh.SelectedIndex = infomethselect("COUN");
        this.txtdtofinfo.Text = setDate()[0];
        
        this.txtinforel.Text = "";
        this.txtinfoad1.Text = "";
        this.txtinfoad2.Text = "";
        this.txtinfoad3.Text = "";
        this.txtinfoad4.Text = "";
        this.txtinfoid.Text = "";
        this.txtinfotel.Text = "";
        this.txtinfoname.Text = "";

      

    }
    private string polstatselect(string polstat)
    {
        string i = "";

        if (polstat.Equals("L"))
        {
            i = "LAPSED";
        }
        else {
            i = "INFORCE";
        }
        return i;

        }

    private int infomethselect(string infometh)
    {

        int j = 0;
        if (infometh.Equals("MAIL")) {
            j = 1;
        }
        if (infometh.Equals("CALL"))
        {
            j = 2;
        }
        
        return j;
    }
}
