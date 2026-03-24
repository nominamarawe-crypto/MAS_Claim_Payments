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

public partial class lnStatClmSetdet : System.Web.UI.Page
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
    private int fromDate;
    private int toDate;
    //private int yearMonth;
    private int brcode;
    private string brname = "";
    private long polno;
    private string clmno;
    //private double amt;
    private int payDate;
    private string paytype = "";
    private double totamount;
    //private double totamount2;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)// && PreviousPage.IsCrossPagePostBack
        {
            fromDate = this.PreviousPage.FromDate;
            toDate = this.PreviousPage.ToDate;
            brcode = this.PreviousPage.Brcode;
        }

        if (!Page.IsPostBack)
        {
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

              
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;

                double accumulatedTotal = 0;

                #region //----- getting branch name -----

                //this.lblfromdate.Text = yearMonth.ToString().Substring(0, 4) + "/" + yearMonth.ToString().Substring(4, 2);
                this.lblfromdate.Text = fromDate.ToString().Substring(0, 4) + "/" + fromDate.ToString().Substring(4, 2) + "/" + fromDate.ToString().Substring(6, 2);
                this.lbltodate.Text = toDate.ToString().Substring(0, 4) + "/" + toDate.ToString().Substring(4, 2) + "/" + toDate.ToString().Substring(6, 2);
                this.lblbrcode.Text = brcode.ToString();

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
                this.lblbrname.Text = brname;

                #endregion

                string[] paymentType ={ "D", "M", "S", "P", "L" };
                for (int i = 0; i < paymentType.Length; i++)
                {
                    paytype = paymentType[i];

                    if (paytype.Equals("D"))
                    {
                        #region
                        string dthrefsel = "select d.drpolno, d.drclmno, d.totpayamt, d.PAYAUTDT from lphs.dthref d, lphs.lpolhis l where d.PAYAUTDT >= " + fromDate + " and d.PAYAUTDT <= " + toDate + " and d.completed = 'Y' and d.drpolno = l.phpol and l.phbrn =" + brcode + " ";
                        //substr(to_char(d.PAYAUTDT),1,6) = '" + yearMonth.ToString() + "'
                        if (dm.existRecored(dthrefsel) != 0)
                        {
                            accumulatedTotal = 0;
                            dm.readSql(dthrefsel);
                            OracleDataReader dthrefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (dthrefReader.Read())
                            {
                                if (!dthrefReader.IsDBNull(0)) { polno = dthrefReader.GetInt64(0); }
                                if (!dthrefReader.IsDBNull(1)) { clmno = dthrefReader.GetInt32(1).ToString(); } else { clmno = ""; }
                                if (!dthrefReader.IsDBNull(2)) { totamount = dthrefReader.GetDouble(2); } else { totamount = 0; }
                                if (!dthrefReader.IsDBNull(3)) { payDate = dthrefReader.GetInt32(3); } else { payDate = 0; }

                                #region //----------- getting records corresponding to the branch ------------

                                //string lpolhisSel = "select phbrn from lphs.lpolhis where phpol = " + polno + " and phbrn =" + brcode + " ";
                                //if (dm.existRecored(lpolhisSel) != 0) 
                                //{
                                accumulatedTotal += totamount;
                                count1++;
                                if (count1 == 1)
                                {
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count1 - 1);
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count1);
                                }
                                else { this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count1); }
                                //}

                                #endregion

                            }
                            dthrefReader.Close();
                            dthrefReader.Dispose();

                            count1++;
                            this.createSettlementTable(0, "0", accumulatedTotal, 0, paytype, count1); 
                        }
                        #endregion
                    }
                    else if (paytype.Equals("M"))
                    {
                        #region
                        // ----- problem of how to exactly distinguish maturities and stage payments ----
                        // pptyp 1 maturity 2 stage payments

                        string lclmfnlSel = "select f.PCLAIMNO, f.PPOLNO, f.PEDAT, f.PNETTOT from lclm.LCLMFNL f, lclm.LCMMAST m where f.PEDAT >= " + fromDate + " and f.PEDAT <=" + toDate + "  and f.pptype =  '1' and f.PCLAIMNO = m.PCLAIMNO and m.pobrn = " + brcode + " ";
                        //substr(to_char(f.PEDAT),1,6) = '" + yearMonth.ToString() + "'
                        if (dm.existRecored(lclmfnlSel) != 0)
                        {
                            accumulatedTotal = 0;
                            dm.readSql(lclmfnlSel);
                            OracleDataReader lclmfnlReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (lclmfnlReader.Read())
                            {
                                if (!lclmfnlReader.IsDBNull(0)) { clmno = lclmfnlReader.GetString(0); } else { clmno = ""; }
                                if (!lclmfnlReader.IsDBNull(1)) { polno = lclmfnlReader.GetInt64(1); } else { polno = 0; }
                                if (!lclmfnlReader.IsDBNull(2)) { payDate = lclmfnlReader.GetInt32(2); } else { payDate = 0; }
                                if (!lclmfnlReader.IsDBNull(3)) { totamount = lclmfnlReader.GetDouble(3); } else { totamount = 0; }

                                #region //----------- getting records corresponding to the branch ------------

                                //string lcmmastSel = "select pobrn from lclm.LCMMAST where PCLAIMNO = '" + clmno + "' and pobrn = " + brcode + " ";
                                //if (dm.existRecored(lcmmastSel) != 0) 
                                //{
                                accumulatedTotal += totamount;
                                count2++;
                                if (count2 == 1)
                                {
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count2 - 1);
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count2);
                                }
                                else { this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count2); }
                                //}

                                #endregion
                            }
                            lclmfnlReader.Close();
                            lclmfnlReader.Dispose();

                            count2++;
                            this.createSettlementTable(0, "0", accumulatedTotal, 0, paytype, count2); 
                        }
                        #endregion
                    }
                    else if (paytype.Equals("S"))
                    {
                        #region
                        string lsurefSelect = "select lsupol, lsunet, lsuvdt, lsuvno, lsusuf from LPHS.LSUREF where lsutyp = 'S' and lsubrn = " + brcode + "  and LSUVDT >=" + fromDate + " and LSUVDT <= " + toDate + " and lsuvst = 'Y' ";
                        //substr(to_char(LSUVDT),1,6) = '" + yearMonth.ToString() + "'
                        if (dm.existRecored(lsurefSelect) != 0)
                        {
                            accumulatedTotal = 0;
                            dm.readSql(lsurefSelect);
                            OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (lsurefReader.Read())
                            {
                                count3++;
                                if (!lsurefReader.IsDBNull(4)) { clmno = (lsurefReader.GetInt32(4)).ToString(); } else { clmno = ""; }
                                if (!lsurefReader.IsDBNull(0)) { polno = lsurefReader.GetInt64(0); } else { polno = 0; }
                                if (!lsurefReader.IsDBNull(2)) { payDate = lsurefReader.GetInt32(2); } else { payDate = 0; }
                                if (!lsurefReader.IsDBNull(1)) { totamount = lsurefReader.GetDouble(1); } else { totamount = 0; }
                               
                                accumulatedTotal += totamount;
                                if (count3 == 1)
                                {
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count3 - 1);
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count3);
                                }
                                else { this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count3); }
                            }
                            lsurefReader.Close();
                            lsurefReader.Dispose();

                            count3++;
                            this.createSettlementTable(0, "0", accumulatedTotal, 0, paytype, count3); 
                        }
                        #endregion
                    }
                    else if (paytype.Equals("P"))
                    {
                        #region
                        string lclmfnlSel = "select f.PCLAIMNO, f.PPOLNO, f.PEDAT, f.PNETTOT from lclm.LCLMFNL f, lclm.LCMMAST m where  f.PEDAT >=" + fromDate + " and f.PEDAT <= " + toDate + " and f.pptype =  '2' and f.PCLAIMNO = m.PCLAIMNO and m.pobrn = " + brcode + " ";
                        //substr(to_char(f.PEDAT),1,6) = '" + yearMonth.ToString() + "'
                        if (dm.existRecored(lclmfnlSel) != 0)
                        {
                            accumulatedTotal = 0;
                            dm.readSql(lclmfnlSel);
                            OracleDataReader lclmfnlReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (lclmfnlReader.Read())
                            {
                                if (!lclmfnlReader.IsDBNull(0)) { clmno = lclmfnlReader.GetString(0); } else { clmno = ""; }
                                if (!lclmfnlReader.IsDBNull(1)) { polno = lclmfnlReader.GetInt64(1); }
                                if (!lclmfnlReader.IsDBNull(2)) { payDate = lclmfnlReader.GetInt32(2); } else { payDate = 0; }
                                if (!lclmfnlReader.IsDBNull(3)) { totamount = lclmfnlReader.GetDouble(3); } else { totamount = 0; }

                                #region //----------- getting records corresponding to the branch ------------

                                //string lcmmastSel = "select pobrn from lclm.LCMMAST where PCLAIMNO = '" + clmno + "' and pobrn = " + brcode + "";
                                //if (dm.existRecored(lcmmastSel) != 0)
                                //{
                                count4++;
                                accumulatedTotal += totamount;
                                if (count4 == 1)
                                {
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count4 - 1);
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count4);
                                }
                                else { this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count4); }
                                //}

                                #endregion
                            }
                            lclmfnlReader.Close();
                            lclmfnlReader.Dispose();

                            count4++;
                            this.createSettlementTable(0, "0", accumulatedTotal, 0, paytype, count4); 
                        }
                        #endregion
                    }
                    else if (paytype.Equals("L"))
                    {
                        #region
                        string lsurefSelect = "select lsupol, LSUGROSS, lsuvdt, lsuvno, lsusuf from LPHS.LSUREF where "+
                            "lsutyp = 'L' and lsubrn = " + brcode + "  and  LSUVDT >=" + fromDate + " and LSUVDT <= " + toDate + "  and lsuvst = 'Y'  "+
                            " and NEWLOANNO not in (select lmlon from lphs.lplmast where (lmcd3 = 'I' or lmcd3 = 'L') and (lmset <> 'Y' or lmset is null)) ";
                        //substr(to_char(LSUVDT),1,6) = '" + yearMonth.ToString() + "' 
                        //LSULOANGRANTAMT
                        if (dm.existRecored(lsurefSelect) != 0)
                        {
                            accumulatedTotal = 0;
                            dm.readSql(lsurefSelect);
                            OracleDataReader lsurefReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (lsurefReader.Read())
                            {
                                count5++;
                                if (!lsurefReader.IsDBNull(4)) { clmno = lsurefReader.GetInt32(4).ToString(); } else { clmno = ""; }
                                if (!lsurefReader.IsDBNull(0)) { polno = lsurefReader.GetInt64(0); } else { polno = 0; }
                                if (!lsurefReader.IsDBNull(2)) { payDate = lsurefReader.GetInt32(2); } else { payDate = 0; }
                                if (!lsurefReader.IsDBNull(1)) { totamount = lsurefReader.GetDouble(1); } else { totamount = 0; }
                                
                                accumulatedTotal += totamount;
                                if (count5 == 1)
                                {
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count5 - 1);
                                    this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count5);
                                }
                                else { this.createSettlementTable(polno, clmno, totamount, payDate, paytype, count5); }

                            }
                            lsurefReader.Close();
                            lsurefReader.Dispose();

                            count5++;
                            this.createSettlementTable(0, "0", accumulatedTotal, 0, paytype, count5); 
                        }
                        #endregion
                    }
                } //--- for loop end --------

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

    private void createSettlementTable(long policyNo, string claimno, double totamount, int paydate, string bizType, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        TableCell tcell3 = new TableCell();
        TableCell tcell4 = new TableCell();
        TableCell tcell5 = new TableCell();

        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();
        Label lbl5 = new Label();

        lbl1.ID = "policyNo" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "policyNo" + rowNumber); //Text Value
        if (rowNumber == 0) { lbl1.Text = "Policy No."; lbl1.Font.Bold = true; }
        else { if (policyNo == 0) { lbl1.Text = ""; } else { lbl1.Text = policyNo.ToString(); } }

        lbl2.ID = "claimno" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "claimno" + rowNumber); //Text Value
        if (rowNumber == 0) { lbl2.Text = "Claim No."; lbl2.Font.Bold = true; }
        else { if (claimno.Equals("0")) { lbl2.Text = ""; } else { lbl2.Text = claimno; } }

        lbl3.ID = "totamount" + rowNumber;
        lbl3.Attributes.Add("runat", "Server");
        lbl3.Attributes.Add("Name", "totamount" + rowNumber); //Text Value
        if (rowNumber == 0) { lbl3.Text = "Total Amounnt"; lbl3.Font.Bold = true; }
        else { if (policyNo == 0) { lbl3.Font.Bold = true; } lbl3.Text = String.Format("{0:N}", totamount); } 
             
        lbl4.ID = "paydate" + rowNumber;
        lbl4.Attributes.Add("runat", "Server");
        lbl4.Attributes.Add("Name", "paydate" + rowNumber); //Text Value
        if (rowNumber == 0) { lbl4.Text = "Date"; lbl4.Font.Bold = true; }
        else { if (paydate == 0) { lbl4.Font.Bold = true; lbl4.Text = "Total"; } else { lbl4.Text = paydate.ToString().Substring(0, 4) + "/" + paydate.ToString().Substring(4, 2) + "/" + paydate.ToString().Substring(6, 2); } }

        tcell1.Controls.Add(lbl1);
        tcell2.Controls.Add(lbl2);
        tcell3.Controls.Add(lbl3);
        tcell4.Controls.Add(lbl4);

        trow.Cells.Add(tcell4);
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        trow.Cells.Add(tcell3);

        if (bizType.Equals("D")) { Table1.Rows.Add(trow); }
        else if (bizType.Equals("M")) { Table2.Rows.Add(trow); }
        else if (bizType.Equals("S")) { Table3.Rows.Add(trow); }
        else if (bizType.Equals("P")) { Table4.Rows.Add(trow); }
        else if (bizType.Equals("L")) { Table5.Rows.Add(trow); }

    }

   
}
