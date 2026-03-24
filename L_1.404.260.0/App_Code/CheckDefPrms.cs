using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.OracleClient;

/// <summary>
/// Summary description for CheckDefPrms
/// </summary>
public class CheckDefPrms
{
    private string memoApprv = "";
    DataManager dthpayObj;
    private ArrayList arr01;
    private ArrayList arr02;
    private string STA;
    private int countStatic;

	public CheckDefPrms()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string[] setDate()
    {
        string[] datetime = new string[2];
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string ourDate;
        if (month.Length < 2) month = "0" + month;

        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;
        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;

        return datetime;
    }

    public int DefPremiums(int dateofdeath, int polno, int COM)
    {
        #region //****** Demmands ********

        //******** Showing Demmands ******
        int dateofdthYM = int.Parse(dateofdeath.ToString().Substring(0, 6));
        int demanddate = 0;
        double demandPrem = 0.0;
        memoApprv = "N";

        int count = 0;
        arr01 = new ArrayList();
        arr02 = new ArrayList();
        dthpayObj = new DataManager();
        string mydemandsql = "select pdcod, pddue, pdprm from LPHS.DEMAND where pdpol='" + polno + "' and " +
            "( pdcod = '1' or pdcod = '2' or pdcod = '3') and pddue <= " + dateofdthYM + " and pddue < " + int.Parse(this.setDate()[0].Substring(0, 6)) + " order by pddue ";
        if (dthpayObj.existRecored(mydemandsql) != 0)
        {
            dthpayObj.readSql(mydemandsql);
            OracleDataReader mydemandreader01 = dthpayObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (mydemandreader01.Read())
            {
                count++;
                demanddate = mydemandreader01.GetInt32(1);
                demandPrem = mydemandreader01.GetDouble(2);
                int demanddateYMD = int.Parse(demanddate.ToString() + COM.ToString().Substring(6, 2));
                if (demanddateYMD < dateofdeath)
                {
                    arr01.Add(demanddate.ToString());
                    arr02.Add(demandPrem.ToString());
                    if (count == 1)
                    {
                        this.createDemmandTable(demanddate.ToString(), count - 1, memoApprv, STA);
                        this.createDemmandTable(demanddate.ToString(), count, memoApprv, STA);
                    }
                    else { this.createDemmandTable(demanddate.ToString(), count, memoApprv, STA); }
                }
            }
            countStatic = count;
            mydemandreader01.Close();
            mydemandreader01.Dispose();
        }
        return count;

        #endregion
    }
    private void createDemmandTable(string due, int rowNumber, string payst, string polst)
    {
        try
        {
            Table Table1 = new Table();
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            CheckBox chk01 = new CheckBox();

            lbl1.ID = "due" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "due" + rowNumber); //Text Value
            if (rowNumber == 0) { lbl1.Text = "Due"; }
            else { lbl1.Text = due; }

            lbl2.ID = "LoanNumber" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "due" + rowNumber); //Text Value
            lbl2.Text = "Wave Demmands?";

            chk01.ID = "chk" + rowNumber;
            chk01.Attributes.Add("runat", "Server");
            chk01.Attributes.Add("Name", "chk" + rowNumber); //Text Value         
            //if (payst.Equals("Y") || polst.Equals("L")) { chk01.Enabled = false; }
            //else { chk01.Enabled = true; }

            tcell1.Controls.Add(lbl1);
            if (rowNumber == 0) { tcell2.Controls.Add(lbl2); }
            else { tcell2.Controls.Add(chk01); }
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            Table1.Rows.Add(trow);
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

}
