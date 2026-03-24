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

public partial class ibslRep002 : System.Web.UI.Page
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

    private int fromdate, todate, brcode;
    public int criteria;
    //private double sumfrom, sumto;
    private string cause, polstat, cof;
    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            fromdate = this.PreviousPage.Fromdate;
            todate = this.PreviousPage.Todate;
            brcode = this.PreviousPage.Brcode;
            //sumfrom = this.PreviousPage.Sumfrom;
            //sumto = this.PreviousPage.Sumto;
            cause = this.PreviousPage.Cause;
            polstat = this.PreviousPage.Polstat;
            cof = this.PreviousPage.Cof;
            criteria = this.PreviousPage.Criteria;    
        }

        if (!Page.IsPostBack)
        {
            dm = new DataManager();
            try
            {
                string ss1 = "";
                string ss2 = "";
                string ss3 = "";
                string ss4 = "";

                #region --- general cases ----

                if (brcode == 0 && cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                           " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "

                }
                else if (brcode == 0 && cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and  b.dcof = '" + cof + "'  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "'  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                }
                else if (brcode == 0 && cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and b.dpolst = '" + polstat + "' and a.completed = 'R'";//  and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                }
                else if (brcode == 0 && cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";// and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode == 0 && !cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode == 0 && !cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' ;}and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' ;}and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' ;}and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' ;}and a.completed = 'R'";// and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode == 0 && !cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode == 0 && !cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                    " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                } //*******
                else if (brcode != 0 && cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                }
                else if (brcode != 0 && cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                     " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
 
                }
                else if (brcode != 0 && cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                    " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                }
                else if (brcode != 0 && cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                    " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "

                }//*******
                else if (brcode != 0 && !cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode != 0 && !cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                   " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode != 0 && !cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                         " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode != 0 && !cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    ss1 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm, (a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon) as total from lphs.dthref a, lphs.dthint b " +
                    " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss2 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss3 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                    ss4 = "select a.drpolno as polno, a.drclmno as clmno, a.smass_pval as sumpval, a.fpupayamt as fpu, a.adbpayamt as adb, a.sjpayamt as sj, a.fepayamt as fe, (a.drvestedbon + a.drinterimbon) as totbons, a.drnetclm as netclm, a.drgrossclm as grossclm from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }

                #endregion
                
                #region --- grid views ----


                if (criteria == 1)
                {
                    // recieved
                    DataTable dt = new DataTable();
                    OracleDataAdapter dat = new OracleDataAdapter(ss1, dm.oraConn);
                    dat.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (criteria == 2)
                {
                    // paid
                    DataTable dt2 = new DataTable();
                    OracleDataAdapter dat2 = new OracleDataAdapter(ss2, dm.oraConn);
                    dat2.Fill(dt2);
                    GridView2.DataSource = dt2;
                    GridView2.DataBind();
                }
                else if (criteria == 3)
                {
                    // outstanding
                    DataTable dt3 = new DataTable();
                    OracleDataAdapter dat3 = new OracleDataAdapter(ss3, dm.oraConn);
                    dat3.Fill(dt3);
                    GridView3.DataSource = dt3;
                    GridView3.DataBind();
                }
                else if (criteria == 4)
                {
                    // rejected
                    DataTable dt4 = new DataTable();
                    OracleDataAdapter dat4 = new OracleDataAdapter(ss4, dm.oraConn);
                    dat4.Fill(dt4);
                    GridView4.DataSource = dt4;
                    GridView4.DataBind();
                }
                #endregion

                string totss1 = "";
                string totss2 = "";
                string totss3 = "";
                string totss4 = "";

                if (cause == null) { cause = ""; }
                if (polstat == null) { polstat = ""; }
                if (cof == null) { cof = ""; }

                #region --- total cases ---
                if (brcode == 0 && cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                            " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                }
                else if (brcode == 0 && cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "'  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "'  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dcof = '" + cof + "'  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "'  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode == 0 && cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode == 0 && cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                         " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  
                }
                else if (brcode == 0 && !cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode == 0 && !cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode == 0 && !cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                         " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.dcauseofdth = " + cause + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";// and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";// and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + "  and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode == 0 && !cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + "  and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                } //*******
                else if (brcode != 0 && cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.memoaprv = 'Y' and a.completed = 'Y'";//a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  and 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "  

                }
                else if (brcode != 0 && cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + "  and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + "  and  b.dcof = '" + cof + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "
                }
                else if (brcode != 0 && cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                         " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + "  and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode != 0 && cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                        " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";// and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + "

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }//*******
                else if (brcode != 0 && !cause.Equals("*") && polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode != 0 && !cause.Equals("*") && polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                             " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + "  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                else if (brcode != 0 && !cause.Equals("*") && !polstat.Equals("*") && cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                          " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dpolst = '" + polstat + "'  and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dpolst = '" + polstat + "'  and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dpolst = '" + polstat + "'  and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dpolst = '" + polstat + "'  and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 
                }
                else if (brcode != 0 && !cause.Equals("*") && !polstat.Equals("*") && !cof.Equals("*"))
                {
                    totss1 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.smass_pval + a.fpupayamt + a.adbpayamt + a.sjpayamt + a.fepayamt + a.drvestedbon + a.drinterimbon), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and (a.memoaprv is null or a.memoaprv <> 'Y')";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss2 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and a.completed = 'Y'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss3 = "select  sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.memoaprv = 'Y' and ((a.completed <> 'Y' and a.completed <> 'R') or a.completed is null)";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                    totss4 = "select sum(a.smass_pval) , sum(a.fpupayamt), sum(a.adbpayamt), sum(a.sjpayamt), sum(a.fepayamt), sum(a.drvestedbon + a.drinterimbon), sum(a.drnetclm), sum(a.drgrossclm) from lphs.dthref a, lphs.dthint b " +
                      " where a.drpolno = b.dpolno and a.drmos = b.dmos and a.dentdt >= " + fromdate + " and a.dentdt <= " + todate + " and a.branch = " + brcode + " and a.dcauseofdth = " + cause + " and  b.dcof = '" + cof + "' and b.dpolst = '" + polstat + "' and a.completed = 'R'";//and a.smass_pval >= " + sumfrom + " and a.smass_pval <= " + sumto + " 

                }
                #endregion
                
                #region --- criteria ---
                //for (int i = 0; i < 4; i++)
                //{
            
                string selQuery = "";
                double tempsum = 0;
                double tempfpu = 0;
                double tempadb = 0;
                double tempsj = 0;
                double tempfe = 0;
                double tempbon = 0;
                double temptotal = 0;
                double tempgrosstot = 0;

                switch (criteria)
                {
                    case 1: selQuery = totss1; break;
                    case 2: selQuery = totss2; break;
                    case 3: selQuery = totss3; break;
                    case 4: selQuery = totss4; break;
                    default: break;
                }

                if (dm.existRecored(selQuery) != 0)
                {
                    dm.readSql(selQuery);
                    OracleDataReader theReader = dm.oraComm.ExecuteReader();
                    while (theReader.Read())
                    {
                        if (!theReader.IsDBNull(0)) { tempsum = theReader.GetDouble(0); } else { tempsum = 0; }
                        if (!theReader.IsDBNull(1)) { tempfpu = theReader.GetDouble(1); } else { tempfpu = 0; }
                        if (!theReader.IsDBNull(2)) { tempadb = theReader.GetDouble(2); } else { tempadb = 0; }
                        if (!theReader.IsDBNull(3)) { tempsj = theReader.GetDouble(3); } else { tempsj = 0; }
                        if (!theReader.IsDBNull(4)) { tempfe = theReader.GetDouble(4); } else { tempfe = 0; }
                        if (!theReader.IsDBNull(5)) { tempbon = theReader.GetDouble(5); } else { tempbon = 0; }
                        if (!theReader.IsDBNull(6)) { temptotal = theReader.GetDouble(6); } else { temptotal = 0; }
                        if (!theReader.IsDBNull(7)) { tempgrosstot = theReader.GetDouble(7); } else { tempgrosstot = 0; }
                    }
                    theReader.Close();
                    theReader.Dispose();

                    switch (criteria)
                    {
                        case 1: this.lblsumtot1.Text = tempsum.ToString();
                            this.lblfpu1.Text = tempfpu.ToString();
                            this.lbladb1.Text = tempadb.ToString();
                            this.lblsj1.Text = tempsj.ToString();
                            this.lblfe1.Text = tempfe.ToString();
                            this.lblbon1.Text = tempbon.ToString();
                            this.lbltoto1.Text = temptotal.ToString();
                            this.lblrecievetot.Text = temptotal.ToString();
                            break;
                        case 2: this.lblsumtot2.Text = tempsum.ToString();
                            this.lblfpu2.Text = tempfpu.ToString();
                            this.lbladb2.Text = tempadb.ToString();
                            this.lblsj2.Text = tempsj.ToString();
                            this.lblfe2.Text = tempfe.ToString();
                            this.lblbon2.Text = tempbon.ToString();
                            this.lbltoto2.Text = temptotal.ToString();
                            this.lblpaidtot.Text = temptotal.ToString();
                            this.gross2.Text = tempgrosstot.ToString();
                            break;
                        case 3: this.lblsumtot3.Text = tempsum.ToString();
                            this.lblfpu3.Text = tempfpu.ToString();
                            this.lbladb3.Text = tempadb.ToString();
                            this.lblsj3.Text = tempsj.ToString();
                            this.lblfe3.Text = tempfe.ToString();
                            this.lblbon3.Text = tempbon.ToString();
                            this.lbltoto3.Text = temptotal.ToString();
                            this.lblouttot.Text = temptotal.ToString();
                            this.gross3.Text = tempgrosstot.ToString();
                            break;
                        case 4: this.lblsumtot4.Text = tempsum.ToString();
                            this.lblfpu4.Text = tempfpu.ToString();
                            this.lbladb4.Text = tempadb.ToString();
                            this.lblsj4.Text = tempsj.ToString();
                            this.lblfe4.Text = tempfe.ToString();
                            this.lblbon4.Text = tempbon.ToString();
                            this.lbltoto4.Text = temptotal.ToString();
                            this.lblrejecttot.Text = temptotal.ToString();
                            this.gross4.Text = tempgrosstot.ToString();
                            break;
                        default: break;
                    }
                }
                //}
                #endregion

                dm.connclose();
            }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        
        }
    }
}
