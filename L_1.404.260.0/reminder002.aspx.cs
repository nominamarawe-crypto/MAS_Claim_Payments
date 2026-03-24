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

public partial class reminder002 : System.Web.UI.Page
{
    private long polno;
    private string MOF;
    private int sentDate;
    private string remarks = "";
    private int reqcode;

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
    DataManager reqlistobj;
    ArrayList arr;
    private int remidercountFlag;
    private ArrayList reqCodeArray = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        arr = new ArrayList();
              
        int yeardiff = 0;
        int mnthdiff = 0;
        int dawasdiff = 0;
        string LettType = "O";
        if (!Page.IsPostBack)
        {
            reqlistobj = new DataManager();
            try
            {
                remidercountFlag = 0;
               
                polno = int.Parse(Request.QueryString["polNo"]);
                MOF = Request.QueryString["type"].ToString();
               // sentDate = int.Parse(Request.QueryString["sentdate"].ToString());
               // remarks = Request.QueryString["remarks"].ToString();

                ViewState.Add("polnoQstr", long.Parse(Request.QueryString["polNo"]));
                ViewState.Add("type", Request.QueryString["type"].ToString());
                ViewState.Add("sentdate", int.Parse(Request.QueryString["sentdate"]));
                ViewState.Add("remarks", Request.QueryString["remarks"].ToString());

                int rowNum = 1;
                bool existflag = false;
               
                string dreqSelect = "select drcovtyp, drrema, DRSENTDT from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and (REMINDERDT = 0 or REMINDERDT is null) ";
                if (reqlistobj.existRecored(dreqSelect) != 0)
                {
                    #region ---------- if first reminder ---------
                    this.lblmsg.Text = "First Reminder";
                    remidercountFlag = 1;
                    reqlistobj.readSql(dreqSelect);
                    OracleDataReader dreqreader = reqlistobj.oraComm.ExecuteReader();
                    while (dreqreader.Read())
                    {
                        existflag = true;
                        if (!dreqreader.IsDBNull(0)) { reqcode = dreqreader.GetInt32(0); } else { reqcode = 0; }
                        if (!dreqreader.IsDBNull(2)) { sentDate = dreqreader.GetInt32(2); } else { sentDate = 0; }
                        if (!dreqreader.IsDBNull(1)) { remarks = dreqreader.GetString(1); } else { remarks = ""; }

                        yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                        mnthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                        dawasdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                        if (yeardiff > 0 || mnthdiff > 0 || dawasdiff > 14)
                        {
                            arr.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks,LettType));
                            reqCodeArray.Add(reqcode);
                            rowNum++;
                        }
                    }
                    dreqreader.Close();
                 
                    #endregion
                }
                else
                {
                    #region ---------- if second reminder ---------
                    int rowNum2 = 1;
                    remidercountFlag = 2;
                    string dreqSelect2 = "select drcovtyp, drrema, REMINDERDT from lphs.dreq where drpol=" + polno + " " +
                        " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and REMINDERDT > 0 and (SECOND_REMINDER_DT = 0 or SECOND_REMINDER_DT is null) ";
                    if (reqlistobj.existRecored(dreqSelect2) != 0)
                    {
                        this.lblmsg.Text = "Second Reminder";
                        reqlistobj.readSql(dreqSelect2);
                        OracleDataReader dreqreader2 = reqlistobj.oraComm.ExecuteReader();
                        while (dreqreader2.Read())
                        {
                            if (!dreqreader2.IsDBNull(0)) { reqcode = dreqreader2.GetInt32(0); } else { reqcode = 0; }
                            if (!dreqreader2.IsDBNull(2)) { sentDate = dreqreader2.GetInt32(2); } else { sentDate = 0; }
                            if (!dreqreader2.IsDBNull(1)) { remarks = dreqreader2.GetString(1); } else { remarks = ""; }

                            yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                            mnthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                            dawasdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                            if (yeardiff > 0 || mnthdiff > 0 || dawasdiff > 14)
                            {
                                arr.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks,LettType));
                                reqCodeArray.Add(reqcode);
                                rowNum2++;
                            }
                        }
                        dreqreader2.Close();
                    }                  
                    else
                    {
                        #region ---------- if third reminder ---------
                        int rowNum3 = 1;
                        remidercountFlag = 3;
                        string dreqSelect3 = "select drcovtyp, drrema, SECOND_REMINDER_DT from lphs.dreq where drpol=" + polno + " " +
                       " and drtyp='" + MOF + "' and (drrecdt=0 or drrecdt is null) and REMINDERDT > 0 and SECOND_REMINDER_DT > 0 and (THIRD_REMINDER_DT = 0 or THIRD_REMINDER_DT is null) ";
                        if (reqlistobj.existRecored(dreqSelect3) != 0)
                        {
                            this.lblmsg.Text = "Third Reminder";
                            reqlistobj.readSql(dreqSelect3);
                            OracleDataReader dreqreader3 = reqlistobj.oraComm.ExecuteReader();
                            while (dreqreader3.Read())
                            {
                                if (!dreqreader3.IsDBNull(0)) { reqcode = dreqreader3.GetInt32(0); } else { reqcode = 0; }
                                if (!dreqreader3.IsDBNull(2)) { sentDate = dreqreader3.GetInt32(2); } else { sentDate = 0; }
                                if (!dreqreader3.IsDBNull(1)) { remarks = dreqreader3.GetString(1); } else { remarks = ""; }

                                yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                                mnthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                                dawasdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];
                               
                                if (yeardiff > 0 || mnthdiff >= 1)
                                {
                                    arr.Add(new reminderDocset(rowNum3, reqcode, sentDate, remarks, LettType));
                                    reqCodeArray.Add(reqcode);
                                    rowNum3++;                                
                                }
                            }
                            dreqreader3.Close();                        
                        }
                        else { throw new Exception("No Requirement Details!"); }
                        #endregion
                    }
                    #endregion
                }

                GridView1.DataSource = CreateDataSource();
                GridView1.DataBind();

                //if (!existflag)
                //{
                //    throw new Exception("No Requirement Details!");
                //}               

                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) this.lbllifetype.Text = "Main Life";
                else if (MOF.Equals("S")) this.lbllifetype.Text = "Spouce";
                else if (MOF.Equals("2")) this.lbllifetype.Text = "Second life";
                else { }

                reqlistobj.connclose();

                ViewState["remidercountFlag"] = remidercountFlag;
                ViewState["reqCodeArray"] = reqCodeArray;
 
            }
            catch (Exception ex)
            {
                reqlistobj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else 
        {
            polno = (long)ViewState["polnoQstr"];
            MOF = (string)ViewState["type"];
            sentDate = (int)ViewState["sentdate"];
            remarks = (string)ViewState["remarks"];

            if (ViewState["remidercountFlag"] != null) { remidercountFlag = int.Parse(ViewState["remidercountFlag"].ToString()); }
            if (ViewState["reqCodeArray"] != null) { reqCodeArray = (ArrayList)ViewState["reqCodeArray"]; }
        }        
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        
    }


    protected void btnRemove_Click(object sender, EventArgs e)
    {
        reqlistobj = new DataManager();
        try
        {
           
            foreach (int x in reqCodeArray)
            {
                string dreqsel = "select * from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRCOVTYP = " + x + " ";
                if (reqlistobj.existRecored(dreqsel) != 0)
                {
                    string dreqUpd = "";
                    if (remidercountFlag == 1) {  dreqUpd = "update lphs.dreq set REMINDERDT = " + int.Parse(this.setDate()[0]) + " where drpol=" + polno + " and drtyp='" + MOF + "' and DRCOVTYP = " + x + " "; }
                    else if (remidercountFlag == 2) { dreqUpd = "update lphs.dreq set SECOND_REMINDER_DT = " + int.Parse(this.setDate()[0]) + " where drpol=" + polno + " and drtyp='" + MOF + "' and DRCOVTYP = " + x + " "; }
                    else if (remidercountFlag == 3) { dreqUpd = "update lphs.dreq set THIRD_REMINDER_DT = " + int.Parse(this.setDate()[0]) + " where drpol=" + polno + " and drtyp='" + MOF + "' and DRCOVTYP = " + x + " "; }
                    reqlistobj.insertRecords(dreqUpd);
                    this.lblsuccess.Text = "Removed";
                }
            }
            reqlistobj.connclose();
            this.btnRemove.Enabled = false;
        }
        catch (Exception ex)
        {
            reqlistobj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    public ICollection CreateDataSource()
    {
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("rownum", typeof(int)));
        dt.Columns.Add(new DataColumn("doc", typeof(string)));
        dt.Columns.Add(new DataColumn("sentdate", typeof(int)));
        dt.Columns.Add(new DataColumn("remarks", typeof(string)));

        foreach (reminderDocset req in arr)
        {
            dr = dt.NewRow();
            dr[0] = req.Rownum;
            dr[1] = req.Reqdesc;
            dr[2] = req.Sentdat;
            dr[3] = req.Rema;
            dt.Rows.Add(dr);
        }

        DataView dv = new DataView(dt);
        return dv;
    }

    public int[] dateComparison(int startdate, int enddate)
    {       
        //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;
        bool leapYearStart = false;
        bool leapYearEnd = false;

        if ((styear % 4 == 0) && ((styear % 100 != 0) || (styear % 400 == 0))) { leapYearStart = true; }
        if ((endyear % 4 == 0) && ((endyear % 100 != 0) || (endyear % 400 == 0))) { leapYearEnd = true; }

        #region date difference is positive

        //--- dawas wenasa ---

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if (leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 29 - startDawasa;
            if (leapYearEnd)
            {
                endmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else
            {
                dawaswenasa = 0;
            }
        }
        else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            endmnth--;
            //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        //--- maasa wenasa ----
        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            endyear--;
            //if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        //--- awurudu wenasa ---

        awuuduwenasa = endyear - styear;

        #endregion

        //**************** if start date comes after end date ********************************

        #region date difference is negetive

        if (awuuduwenasa < 0)
        {
            endyear++;
            dawaswenasa = startDawasa - enddawasa;
            if ((dawaswenasa < 0) && ((endmnth == 1) || (endmnth == 3) || (endmnth == 5) || (endmnth == 7) || (endmnth == 8) || (endmnth == 10) || (endmnth == 12)))
            {
                dawaswenasa = startDawasa + 31 - enddawasa;
                stmnth--;
            }
            else if ((dawaswenasa < 0) && ((endmnth == 4) || (endmnth == 6) || (endmnth == 9) || (endmnth == 11)))
            {
                dawaswenasa = startDawasa + 30 - enddawasa;
                stmnth--;
            }
            else if (leapYearStart && (dawaswenasa < 0) && ((endmnth == 2)))
            {
                dawaswenasa = startDawasa + 29 - enddawasa;
                if (leapYearEnd)
                {
                    stmnth--;
                }
                else
                {
                    dawaswenasa = 0;
                }
            }
            else if (!leapYearStart && (dawaswenasa < 0) && ((stmnth == 2)))
            {
                dawaswenasa = startDawasa + 28 - enddawasa;
                stmnth--;
                //if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
            }
            else { }

            //--- maasa wenasa ----
            maasawenasa = stmnth - endmnth;
            if (maasawenasa < 0)
            {
                maasawenasa = stmnth + 12 - endmnth;
                styear--;
                //if (awuuduwenasa < 0) awuuduwenasa = 0;
            }

            //--- awurudu wenasa ---

            awuuduwenasa = styear - endyear;

            dawaswenasa *= -1;
            maasawenasa *= -1;
            awuuduwenasa *= -1;

            //awuuduwenasa++;
            //maasawenasa -= 12;
        }
        //else if (awuuduwenasa < -1) { throw new Exception("Year Difference is Minus!"); }
        else { }

        #endregion

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
    

        #region old code
        /*
        //end date is today, startdate, enddate should be yyyymmdd format
        int[] arr = new int[3];
        int enddawasa = int.Parse(enddate.ToString().Substring(6, 2));
        int startDawasa = int.Parse(startdate.ToString().Substring(6, 2));
        int stmnth = int.Parse(startdate.ToString().Substring(4, 2));
        int endmnth = int.Parse(enddate.ToString().Substring(4, 2));
        int styear = int.Parse(startdate.ToString().Substring(0, 4));
        int endyear = int.Parse(enddate.ToString().Substring(0, 4));
        int dawaswenasa = 0;
        int maasawenasa = 0;
        int awuuduwenasa = 0;

        awuuduwenasa = endyear - styear;
        if (awuuduwenasa < 0) { throw new Exception(); }

        maasawenasa = endmnth - stmnth;
        if (maasawenasa < 0)
        {
            maasawenasa = endmnth + 12 - stmnth;
            awuuduwenasa--;
            if (awuuduwenasa < 0) awuuduwenasa = 0;
        }

        dawaswenasa = enddawasa - startDawasa;
        if ((dawaswenasa < 0) && ((stmnth == 1) || (stmnth == 3) || (stmnth == 5) || (stmnth == 7) || (stmnth == 8) || (stmnth == 10) || (stmnth == 12)))
        {
            dawaswenasa = enddawasa + 31 - startDawasa;
            maasawenasa--;
            if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 4) || (stmnth == 6) || (stmnth == 9) || (stmnth == 11)))
        {
            dawaswenasa = enddawasa + 30 - startDawasa;
            maasawenasa--;
            if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else if ((dawaswenasa < 0) && ((stmnth == 2)))
        {
            dawaswenasa = enddawasa + 28 - startDawasa;
            maasawenasa--;
            if (maasawenasa < 0) { maasawenasa = 0; awuuduwenasa--; if (awuuduwenasa < 0)awuuduwenasa = 0; }
        }
        else { }

        arr[0] = awuuduwenasa;
        arr[1] = maasawenasa;
        arr[2] = dawaswenasa;

        return arr;
        */
        #endregion
    }
    public long Polno {
        get { return polno; }
        set { polno = value; }
    }
    public string mof {
        get { return MOF; }
        set { MOF = value; }
    }

    
}
