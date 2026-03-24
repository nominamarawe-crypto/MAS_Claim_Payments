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

public partial class reminder : System.Web.UI.Page
{
    private long polno;
    private string MOF; 
    private int sentDate;
    private string remarks;
    //private int[] arr;

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

    DataManager reminderobj;
    protected ArrayList arrlist;
    protected ArrayList arrlist2;
    protected ArrayList arrlist3;

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!Page.IsPostBack)
        {
            //long temp = 0;
            //string tempstr = "";
            int yeardiff = 0;
            int monthdiff = 0;
            int datediff = 0;
            reminderobj = new DataManager();
            try
            {
               
                arrlist = new ArrayList();
                arrlist2 = new ArrayList();
                arrlist3 = new ArrayList();

                string FromDate = Request.QueryString["fromDate"];
                string ToDate = Request.QueryString["todate"];

                #region --------- first reminder ---------
                //string dreqsel = "select drpol, drsentdt, drtyp, drrema from lphs.dreq where (drrecdt=0 or drrecdt is null) and (REMINDERDT = 0 or REMINDERDT is null) order by drpol, drtyp";
                string dreqsel = "select distinct drpol, drsentdt, drtyp, drrema from lphs.dreq where (drrecdt=0 or drrecdt is null) and (REMINDERDT = 0 or REMINDERDT is null) and (drsentdt between " + FromDate + " and " + ToDate + ") group by drpol, drsentdt, drtyp, drrema order by drsentdt, drpol, drtyp";
                if (reminderobj.existRecored(dreqsel) != 0)
                {
                    int count = 0;
                    reminderobj.readSql(dreqsel);
                    OracleDataReader dreqreader = reminderobj.oraComm.ExecuteReader();
                    while (dreqreader.Read())
                    {
                       
                        polno = dreqreader.GetInt64(0);
                        if (!dreqreader.IsDBNull(1)) { sentDate = dreqreader.GetInt32(1); } else { sentDate = 0; }
                        if (!dreqreader.IsDBNull(2)) { MOF = dreqreader.GetString(2); } else { MOF = ""; }
                        if (!dreqreader.IsDBNull(3)) { remarks = dreqreader.GetString(3); } else { remarks = ""; }

                        yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                        monthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                        datediff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                        if (yeardiff > 0 || monthdiff > 0 || datediff > 14)
                        {
                            //if ((temp != polno) || (!tempstr.Equals(MOF)))
                            //{
                                count++;
                                arrlist.Add(new remainderValSet(polno, MOF, sentDate, remarks));
                            //}
                            //temp = polno;
                            //tempstr = MOF;
                        }
                    }
                    dreqreader.Close();

                    GridView1.DataSource = drawGrid();
                    GridView1.DataBind();
                }
              
                #endregion

                #region --------- second reminder ---------
                //string dreqsel2 = "select drpol, REMINDERDT, drtyp, drrema from lphs.dreq where (drrecdt=0 or drrecdt is null) and REMINDERDT > 0 and (SECOND_REMINDER_DT = 0 or SECOND_REMINDER_DT is null) order by drpol, drtyp ";
                string dreqsel2 = "select distinct drpol, REMINDERDT, drtyp, drrema from lphs.dreq where (drrecdt=0 or drrecdt is null) and REMINDERDT > 0 and (SECOND_REMINDER_DT = 0 or SECOND_REMINDER_DT is null)and (REMINDERDT between " + FromDate + " and " + ToDate + ") group by drpol, REMINDERDT, drtyp, drrema order by REMINDERDT, drpol, drtyp ";
                if (reminderobj.existRecored(dreqsel2) != 0)
                {
                    int count2 = 0;
                    reminderobj.readSql(dreqsel2);
                    OracleDataReader dreqreader2 = reminderobj.oraComm.ExecuteReader();
                    while (dreqreader2.Read())
                    {
                        polno = dreqreader2.GetInt64(0);
                        if (!dreqreader2.IsDBNull(1)) { sentDate = dreqreader2.GetInt32(1); } else { sentDate = 0; }
                        if (!dreqreader2.IsDBNull(2)) { MOF = dreqreader2.GetString(2); } else { MOF = ""; }
                        if (!dreqreader2.IsDBNull(3)) { remarks = dreqreader2.GetString(3); } else { remarks = ""; }

                        yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                        monthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                        datediff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                        if (yeardiff > 0 || monthdiff > 0 || datediff > 14)
                        {
                            count2++;
                            arrlist2.Add(new remainderValSet(polno, MOF, sentDate, remarks));
                        }
                    }
                    dreqreader2.Close();

                    GridView2.DataSource = drawGrid2();
                    GridView2.DataBind();
                }
                #endregion

                #region --------- third reminder ---------

                string dreqsel3 = "select distinct drpol, SECOND_REMINDER_DT, drtyp, drrema from "+
                    " lphs.dreq where (drrecdt=0 or drrecdt is null) and REMINDERDT > 0 and SECOND_REMINDER_DT >0 and (THIRD_REMINDER_DT = 0 or THIRD_REMINDER_DT is null)and (SECOND_REMINDER_DT between " + FromDate + " and " + ToDate + ") group by drpol, SECOND_REMINDER_DT, drtyp, drrema order by SECOND_REMINDER_DT, drpol, drtyp ";
                if (reminderobj.existRecored(dreqsel3) != 0)
                {
                    reminderobj.readSql(dreqsel3);
                    OracleDataReader dreqreader3 = reminderobj.oraComm.ExecuteReader();
                    while (dreqreader3.Read())
                    {
                        polno = dreqreader3.GetInt64(0);
                        if (!dreqreader3.IsDBNull(1)) { sentDate = dreqreader3.GetInt32(1); } else { sentDate = 0; }
                        if (!dreqreader3.IsDBNull(2)) { MOF = dreqreader3.GetString(2); } else { MOF = ""; }
                        if (!dreqreader3.IsDBNull(3)) { remarks = dreqreader3.GetString(3); } else { remarks = ""; }

                        yeardiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[0];
                        monthdiff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[1];
                        datediff = this.dateComparison(sentDate, int.Parse(this.setDate()[0]))[2];

                        if (yeardiff > 0 || monthdiff >= 1)
                        {
                            arrlist3.Add(new remainderValSet(polno, MOF, sentDate, remarks));
                        }
                    }
                    dreqreader3.Close();

                    GridView3.DataSource = drawGrid3();
                    GridView3.DataBind();
                }

                #endregion

                reminderobj.connclose();

            }
            catch (Exception ex)
            {
                reminderobj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }

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
       
    }

    protected ICollection drawGrid() {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("type", typeof(string)));
        dt.Columns.Add(new DataColumn("sentdate", typeof(string)));
        dt.Columns.Add(new DataColumn("remarks", typeof(string)));

        foreach (remainderValSet rmv in arrlist)
        {
            linkUrl = "<a  href=reminder002.aspx?polNo=" + rmv.Polno.ToString() + "&type=" + rmv.Type + "&sentdate=" + rmv.Sentdate + "&remarks=" + rmv.Remarks + ">" + rmv.Polno + "</a>";
            dr = dt.NewRow();
            dr[0] = linkUrl;
            dr[1] = this.lifetype(rmv.Type);
            dr[2] = rmv.Sentdate.ToString().Substring(0, 4) + "/" + rmv.Sentdate.ToString().Substring(4, 2) + "/" + rmv.Sentdate.ToString().Substring(6, 2);
            dr[3] = rmv.Remarks;
            dt.Rows.Add(dr);
        
        }

        DataView dv = new DataView(dt);
        return dv;

    }

    protected ICollection drawGrid2()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("type", typeof(string)));
        dt.Columns.Add(new DataColumn("sentdate", typeof(string)));
        dt.Columns.Add(new DataColumn("remarks", typeof(string)));

        foreach (remainderValSet rmv in arrlist2)
        {
            linkUrl = "<a  href=reminder002.aspx?polNo=" + rmv.Polno.ToString() + "&type=" + rmv.Type + "&sentdate=" + rmv.Sentdate + "&remarks=" + rmv.Remarks + ">" + rmv.Polno + "</a>";
            dr = dt.NewRow();
            dr[0] = linkUrl;
            dr[1] = this.lifetype(rmv.Type);
            dr[2] = rmv.Sentdate.ToString().Substring(0, 4) + "/" + rmv.Sentdate.ToString().Substring(4, 2) + "/" + rmv.Sentdate.ToString().Substring(6, 2);
            dr[3] = rmv.Remarks;
            dt.Rows.Add(dr);

        }

        DataView dv = new DataView(dt);
        return dv;

    }

    protected ICollection drawGrid3()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        string linkUrl = "";

        dt.Columns.Add(new DataColumn("polno", typeof(string)));
        dt.Columns.Add(new DataColumn("type", typeof(string)));
        dt.Columns.Add(new DataColumn("sentdate", typeof(string)));
        dt.Columns.Add(new DataColumn("remarks", typeof(string)));

        foreach (remainderValSet rmv in arrlist3)
        {
            linkUrl = "<a  href=reminder002.aspx?polNo=" + rmv.Polno.ToString() + "&type=" + rmv.Type + "&sentdate=" + rmv.Sentdate + "&remarks=" + rmv.Remarks + ">" + rmv.Polno + "</a>";
            dr = dt.NewRow();
            dr[0] = linkUrl;
            dr[1] = this.lifetype(rmv.Type);
            dr[2] = rmv.Sentdate.ToString().Substring(0, 4) + "/" + rmv.Sentdate.ToString().Substring(4, 2) + "/" + rmv.Sentdate.ToString().Substring(6, 2);
            dr[3] = rmv.Remarks;
            dt.Rows.Add(dr);

        }

        DataView dv = new DataView(dt);
        return dv;

    }

    protected string lifetype(string rmvType) {
        if (rmvType.Equals("M"))   return "Main Life";
        else if (rmvType.Equals("S"))  return "Spouse";
        else    return "Second Life";
           
    }

}
