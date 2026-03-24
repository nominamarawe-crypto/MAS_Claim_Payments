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

public partial class lnStatClmSetsum : System.Web.UI.Page
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

    DataManager dm;
    //private int yearMonth;
    private int fromDate;
    private int toDate;
    private int brcode;
    //private double branWiseTot;
    private string brname = "";

    //private long polno;
    //private string mos = "";
    //private int payDate;
    private string paytype = "";
    //private double payamt;
    private double totamount;
    //private string claimNo;
    private ArrayList arrList;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            fromDate = this.PreviousPage.FromDate;
            toDate = this.PreviousPage.ToDate;
        }
        dm = new DataManager();
        try
        {
            dateValidation dv = new dateValidation();
            if ((toDate.ToString().Length != 8) || (!dv.dateValid(toDate.ToString())))
            {
                throw new Exception("Invalid To Date!");
            }
            if ((fromDate.ToString().Length != 8) || (!dv.dateValid(fromDate.ToString())))
            {
                throw new Exception("Invalid From Date!");
            }

           

            int count = 0;
            //this.lblym.Text = yearMonth.ToString().Substring(0, 4) + "/" + yearMonth.ToString().Substring(4, 2);
            this.lblfromdate.Text = fromDate.ToString().Substring(0, 4) + "/" + fromDate.ToString().Substring(4, 2) + "/" + fromDate.ToString().Substring(6, 2);
            this.lbltodate.Text = toDate.ToString().Substring(0, 4) + "/" + toDate.ToString().Substring(4, 2) + "/" + toDate.ToString().Substring(6, 2);

            arrList = new ArrayList();

            string brcodeSelect = "select BRCOD from  GENPAY.BRANCH order by brcod ";
            dm.readSql(brcodeSelect);
            //OracleDataReader brcodeReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
			OracleDataReader brcodeReader = dm.oraComm.ExecuteReader();
            while (brcodeReader.Read())
            {
                brcode = brcodeReader.GetInt32(0);

                string[] branWiseTot = new string[6];
                 //branWiseTot[0] = branch
                 //branWiseTot[1] = death total
                 //branWiseTot[2] = maturity total
                 //branWiseTot[3] = surrender total
                 //branWiseTot[4] = stagepayment total
                 //branWiseTot[5] = new loan total

                branWiseTot[0] = Convert.ToString(brcode);

                string[] paymentType ={ "D", "M", "S", "P", "L" };
                int count2 = 0;
                for (int i = 0; i < paymentType.Length - 1; i++)
                {
                    count2++;
                    paytype = paymentType[i];

                    if (paytype.Equals("D"))
                    {
                        #region
                        string dthrefsel = "select sum(d.totpayamt) from lphs.dthref d, lphs.lpolhis l where  d.PAYAUTDT >=" + fromDate + " and d.PAYAUTDT <=" + toDate + " and d.completed = 'Y' and d.drpolno = l.phpol and l.phbrn = " + brcode + " ";
                        //substr(to_char(d.PAYAUTDT),1,6) = '" + yearMonth.ToString() + "'
                        if (dm.existRecored(dthrefsel) != 0)
                        {
                            dm.readSql(dthrefsel);
                            //OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader dthrefReader = dm.oraComm.ExecuteReader();
                            while (dthrefReader.Read())
                            {
                                if (!dthrefReader.IsDBNull(0)) { totamount = dthrefReader.GetDouble(0); } else { totamount = 0; }                             
                            }
                            dthrefReader.Close();
                            dthrefReader.Dispose();

                            branWiseTot[1] = totamount.ToString();                        
                        }

                        #endregion
                    }
                    else if (paytype.Equals("M"))
                    {
                        #region
                        string matselect = "select sum(f.PNETTOT)from LCLM.LCLMFNL f, lclm.lcmmast m where  f.PEDAT >=" + fromDate + " and f.PEDAT <=" + toDate + "  and f.pptype =  '1' and f.pclaimno = m.pclaimno and m.pobrn = " + brcode + " ";
                        //substr(to_char(f.PEDAT),1,6) = '" + yearMonth.ToString() + "' 
                        if (dm.existRecored(matselect) != 0)
                        {
                            dm.readSql(matselect);
                            //OracleDataReader matReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader matReader = dm.oraComm.ExecuteReader();
                            while (matReader.Read())
                            {
                                if (!matReader.IsDBNull(0)) { totamount = matReader.GetDouble(0); } else { totamount = 0; }                          
                            }
                            matReader.Close();
                            matReader.Dispose();

                            branWiseTot[2] = totamount.ToString();     
                        }

                        #endregion
                    }
                    else if (paytype.Equals("S"))
                    {
                        #region
                        string lsurefSelect = "select sum(lsunet) from LPHS.LSUREF where lsubrn = " + brcode + " and lsutyp = 'S' and LSUVDT >= " + fromDate + " and LSUVDT <= " + toDate + " and lsuvst = 'Y'  ";
                        //substr(to_char(LSUVDT),1,6) = '" + yearMonth.ToString() + "'
                        if (dm.existRecored(lsurefSelect) != 0)
                        {
                            dm.readSql(lsurefSelect);
                            //OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader lsurefReader = dm.oraComm.ExecuteReader();
                            while (lsurefReader.Read())
                            {
                                if (!lsurefReader.IsDBNull(0)) { totamount = lsurefReader.GetDouble(0); } else { totamount = 0; }                              
                            }
                            lsurefReader.Close();
                            lsurefReader.Dispose();

                            branWiseTot[3] = totamount.ToString();  
                        }

                        #endregion
                    }
                    else if (paytype.Equals("P"))
                    {
                        #region

                        string matselect = "select sum(f.PNETTOT)from LCLM.LCLMFNL f, lclm.lcmmast m where f.PEDAT >= " + fromDate + " and f.PEDAT <= "+toDate+" and f.pptype =  '2' and f.pclaimno = m.pclaimno and m.pobrn = " + brcode + " ";
                        if (dm.existRecored(matselect) != 0)
                        {
                            dm.readSql(matselect);
                            //OracleDataReader matReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader matReader = dm.oraComm.ExecuteReader();
                            while (matReader.Read())
                            {
                                if (!matReader.IsDBNull(0)) { totamount = matReader.GetDouble(0); } else { totamount = 0; } 
                            }
                            matReader.Close();
                            matReader.Dispose();

                            branWiseTot[4] = totamount.ToString();
                        }

                        #endregion
                    }
                    else if (paytype.Equals("L"))
                    {
                        #region

                        string lsurefSelect = "select sum(LSUGROSS) from LPHS.LSUREF where lsubrn = " + brcode + " and lsutyp = 'L' and LSUVDT >= " + fromDate + " and LSUVDT <= " + toDate + " and lsuvst = 'Y'  ";
                        if (dm.existRecored(lsurefSelect) != 0)
                        {
                            dm.readSql(lsurefSelect);
                            //OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
							OracleDataReader lsurefReader = dm.oraComm.ExecuteReader();
                            while (lsurefReader.Read())
                            {
                                if (!lsurefReader.IsDBNull(0)) { totamount = lsurefReader.GetDouble(0); } else { totamount = 0; } 
                            }
                            lsurefReader.Close();
                            lsurefReader.Dispose();

                            branWiseTot[3] = totamount.ToString();
                        }


                        #endregion
                    }

                } // --- for loop end ---

                arrList.Add(branWiseTot);

            }
            brcodeReader.Close();
            brcodeReader.Dispose();

            foreach (string[] strArr in arrList) 
            {
                brcode =int.Parse(strArr[0]);
               
                #region //-----getting branch name -----

                string brnamSel = "select brnam from lnb.branch where brcod = " + brcode + " ";
                if (dm.existRecored(brnamSel) != 0)
                {
                    dm.readSql(brnamSel);
                    OracleDataReader brnameReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (brnameReader.Read())
                    {
                        brname = brnameReader.GetString(0);
                    }
                    brnameReader.Close();
                    brnameReader.Dispose();
                }

                #endregion

                int positiveTotamountCount = 0;
               
                for (int i = 1; i < strArr.Length - 1; i++)
                {
                    if (strArr[i] != null) { totamount = double.Parse(strArr[i]); }
                    if (totamount > 0) { positiveTotamountCount++; }
                }

                if (positiveTotamountCount > 0) 
                {
                    count++;
                    this.createFirstRow(brcode, brname, count);

                    string ptpDesc = "";
                    int count2 = 0;

                    for (int i = 1; i < strArr.Length - 1; i++)
                    {
                        count2++;
                        if (strArr[i] != null) { totamount = double.Parse(strArr[i]); }

                        if (i == 1) { ptpDesc = "Deaths"; }
                        else if (i == 2) { ptpDesc = "Maturities"; }
                        else if (i == 3) { ptpDesc = "Surrenders"; }
                        else if (i == 4) { ptpDesc = "Stage Payments"; }
                        else if (i == 5) { ptpDesc = "New Loans"; }
                       
                            if (count2 == 1)
                            {
                                this.createSettledSummaryTable(totamount, ptpDesc, count2 - 1);
                                this.createSettledSummaryTable(totamount, ptpDesc, count2);
                            }
                            else
                            {
                                this.createSettledSummaryTable(totamount, ptpDesc, count2);
                            }                       
                    }
                }
            }

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    private void createFirstRow(int brn, string branme, int rowNumber)
    {
        TableRow trow = new TableRow();

        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();

        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "brn" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "brn" + rowNumber); //Text Value      
        lbl1.Text = "Branch Code : " + brn.ToString();
        lbl1.Font.Bold = true;

        lbl2.ID = "branme" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "branme" + rowNumber); //Text Value       
        lbl2.Text = "Branch Name : " + brname;
        lbl2.Font.Bold = true;

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);

        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);

        Table1.Rows.Add(trow);
    }

    private void createSettledSummaryTable(double totalAmount, string paytyp, int rowNumber)
    {
        TableRow trow = new TableRow();

        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        
        Label lbl1 = new Label();
        Label lbl2 = new Label();
      
        lbl1.ID = "paytyp" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "paytyp" + rowNumber); //Text Value
        if (rowNumber == 0) { lbl1.Text = "Paymnt Type"; }
        else { lbl1.Text = paytyp; }

        lbl2.ID = "totalAmount" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "totalAmount" + rowNumber); //Text Value
        if (rowNumber == 0) { lbl2.Text = "Total Settled Amount"; }
        else { lbl2.Text = String.Format("{0:N}", totalAmount); }
        
        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
   
        Table1.Rows.Add(trow);
    }

}
