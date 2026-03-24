using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for demmand
/// </summary>
public class demmand
{
    private int polno;
    private int demanddate;
    private int table;
    private double prm;
    private double defaultlatefee;
    private double missedPrems;

    DataManager dmobj = new DataManager();
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

    public demmand(int Polno, int Table, double Prm, int dateofdth)
	{
        this.polno = Polno;
        this.table = Table;
        this.prm = Prm;

        int dateofdthYM = int.Parse(dateofdth.ToString().Substring(0, 6));

        string mydemandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' and ( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= "+dateofdthYM+" ";
        dmobj.readSql(mydemandsql);
        OracleDataReader mydemandreader = dmobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        bool demandread = false;
        int demandCount = 0;
        int duration = 0;
        double defint = 0;
        double totdefint = 0;
        double remainderint = 0;
       
        while (mydemandreader.Read())
        {
            demandread = true;
            string pdcodestr = mydemandreader.GetString(0);
            if ((pdcodestr.Equals("1")) || (pdcodestr.Equals("2")) || (pdcodestr.Equals("3")))
            {
                demanddate = mydemandreader.GetInt32(1);
                demandCount++;
                duration = Duration(demanddate, dateofdthYM);
                double durationin6monthparts = duration/6;
                int duratnin6monthpartsint = (int)Math.Round(durationin6monthparts);
                int remainderparts = duration % 6;

                for (int i = 0; i < duratnin6monthpartsint; i++) {
                    if (table != 42)
                    {
                        defint = prm * (0.12) * (0.5);
                        prm += defint;
                        totdefint += defint;
                    }
                    else {
                        defint = prm * (0.15) * (0.5);
                        prm += defint;
                        totdefint += defint;                    
                    }
                }
                if (table != 42) { remainderint = prm * (0.12) * remainderparts / 12; }

                else { remainderint = prm * (0.15) * remainderparts / 12; }

                defaultlatefee = defaultlatefee + totdefint + remainderint;
                if (defaultlatefee < 0) { defaultlatefee = 0; }

            }
        
        }
        mydemandreader.Close();
        mydemandreader.Dispose();
        missedPrems = demandCount * prm;
	}
        
    public int Duration(int dema, int dtOfDthYm) {
       
        int totmonths = 0;
        if (dema > dtOfDthYm) { totmonths = 0; }
        int endtyr = int.Parse(dtOfDthYm.ToString().Substring(0,4));
        int endmnth = int.Parse(dtOfDthYm.ToString().Substring(4, 2));
        int startyr = int.Parse(dema.ToString().Substring(0, 4));
        int startmnth = int.Parse(dema.ToString().Substring(4, 2));
       
        int monthdiff = endmnth - startmnth;
        if (monthdiff < 0) {
            monthdiff = endmnth + 12 - startmnth;
            endtyr--;
        }
        int yeardiff = endtyr - startyr;
        totmonths = (yeardiff * 12) + monthdiff;
        return totmonths;
    }
    public double Defaultlatefee {
        get { return this.defaultlatefee; }
        set { this.defaultlatefee = value; }
    }
    public double MissedPrems {
        get { return this.missedPrems; }
        set { this.missedPrems = value; }
    }
}
