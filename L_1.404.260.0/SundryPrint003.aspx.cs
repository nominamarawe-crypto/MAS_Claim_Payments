using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

public partial class SundryPrint003 : System.Web.UI.Page
{
    #region Define Variables

    public ArrayList prms1;
    public ArrayList prms2;
    private long polno;
    private long clmno;
    private double ageamt;
    private double Agedifint;
    public int comdt;
    private int tble;
    public int trm;
    private int mode;
    private int pacd;
    private int agtcd;
    private int orgcd;
    private int serbr;
    private double prm;
    private string polst;
    private string name;
    private int dueyr;
    private int duemnth;
    private int fstyrdueyr;
    private int fstyrduemn;
    private int nextduyr;
    private int nextduemn;
    private int nextdulsyr;
    private int nextduelsmn;
    private double sngleprm;
    private double remprm;
    public int paiddue;
    public int paidduemn;
    public int paiddueday;
    private string entEPF;
    private int BRN;
    private double singleprm;
    private ArrayList Allprms;
    int rcptno = 0;

    DataManager dm;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Session EPF

        prms1 = new ArrayList();
        prms2 = new ArrayList();
        Allprms = new ArrayList();
        dm = new DataManager();
        if (Session["EPFNum"] != null)
        {
            entEPF = Session["EPFNum"].ToString();
            hdfepf.Value = entEPF;
            BRN = Convert.ToInt32(Session["brcode"]);
            hdfbrn.Value = BRN.ToString();
        }
        else
        {
            EPage.Messege = "Session Expired.Please log to the system again...";
            Response.Redirect("EPage.aspx");
        }
        #endregion        

        if (Page.PreviousPage != null)
        {
            #region Get Values

            prms1 = PreviousPage.PRMS1;
            prms2 = PreviousPage.PRMS2;
            polno = PreviousPage.pol_no;
            clmno = PreviousPage.CLMNO;
            ageamt = PreviousPage.AGEAMT;
            Agedifint = PreviousPage.AGEDIFAMT;
            double TotAmt=ageamt+Agedifint;
            LitTotamt.Text = TotAmt.ToString("N2");
            comdt = PreviousPage.COMMDT;
            polMasRead pmred = new polMasRead(int.Parse(polno.ToString()), dm);
            tble = pmred.TBL;
            trm = pmred.TRM;
            mode = pmred.MOD;
            pacd = pmred.PAC;
            agtcd = pmred.AGT;
            orgcd = pmred.ORG;
            serbr = pmred.OBR;
            prm = pmred.PRM;
            polst = PreviousPage.Polst;
            name = PreviousPage.NAME;
            dueyr = int.Parse(comdt.ToString().Substring(0, 4));
            duemnth = int.Parse(comdt.ToString().Substring(4, 2));
            nextduyr = PreviousPage.NEXTDUYR;
            nextduemn = PreviousPage.NEXTDUMN;
            nextdulsyr = PreviousPage.NEXTDULSYR;
            nextduelsmn = PreviousPage.NEXTDULSMN;
            singleprm = PreviousPage.SINGLEPRM;
            remprm = PreviousPage.REMPRMS;
            paiddue = PreviousPage.PDDUE;
            paidduemn = PreviousPage.PDDUEMN;
            paiddueday = PreviousPage.PDDUEDAYS;
            //lblmsg.Text = "";

            #endregion            

            #region Assign Values
            litpol.Text = polno.ToString();
            litclm.Text = clmno.ToString();
            littbtr.Text = tble.ToString() + "/" + trm.ToString();
            litcomdt.Text = comdt.ToString().Substring(0, 4) + "/" + comdt.ToString().Substring(4, 2) + "/" + comdt.ToString().Substring(6, 2);
            litnm.Text = name;
            LITPACD.Text = pacd.ToString();
            litprmfst.Text = singleprm.ToString("N2");
            litdueyrmn.Text = dueyr.ToString() + "/" + duemnth.ToString();
            litprmnxt.Text = remprm.ToString("N2");
            litnxtdue.Text = nextduyr.ToString() + "/" + nextduemn.ToString() + " TO " + nextdulsyr.ToString() + "/" + nextduelsmn.ToString();
            litagtcd.Text = agtcd.ToString();
            litorgcd.Text = orgcd.ToString();
            litepf.Text = dm.EpfCode(entEPF).ToString();
            litAgediffInt.Text = Agedifint.ToString("N2");
            #endregion

            #region Write Data to Lclm.ledger from the code 5

            try
            {
                string fstdue = "";
                dm = new DataManager();
                string selsundry = "select * from lclm.sundry_rcpt where SCLMNO='" + clmno + "' and  SPOLNO=" + polno + "  and SYSCODE='D' and DELCOD=0";

                if (dm.existRecored(selsundry) == 0)
                {
                    dm.begintransaction();
                    #region Set Current Date
                    string Currday = "";
                    string curmnth = "";
                    string Curr_Date = "";
                    int Curryear = DateTime.Now.Year;
                    int Currmnth = DateTime.Now.Month;
                    if (Currmnth < 10)
                    { curmnth = "0" + Currmnth.ToString(); }
                    else
                    { curmnth = Currmnth.ToString(); }
                    int Currdate = DateTime.Now.Day;
                    if (Currdate < 10)
                    { Curr_Date = "0" + Currdate.ToString(); }
                    else
                    { Curr_Date = Currdate.ToString(); }
                    Currday = Curryear.ToString() + curmnth + Curr_Date;
                    litdt.Text = Currday;
                    #endregion

                    #region Write Data to RCPTNO
                    string insert = "";
                    int d_today = DateTime.Now.Year;

                    string selrcptno = "select * FROM  LPAY.RCPTNO where RCBRNO =" + BRN + " and RCYEAR =" + d_today + " and RCTYPE = 16";
                    if (dm.existRecored(selrcptno) != 0)
                    {
                        dm.readSql(selrcptno);
                        OracleDataReader reader = dm.oraComm.ExecuteReader();
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) { rcptno = reader.GetInt32(0); } else { rcptno = 0; }
                        }
                        reader.Close();
                        rcptno = rcptno + 1;
                        insert = "UPDATE LPAY.RCPTNO set RCNO=" + rcptno + " where RCBRNO=" + BRN + " and RCYEAR=" + d_today + "  and RCTYPE= 16";
                        dm.insertRecords(insert);

                    }
                    else
                    {
                        rcptno = 1;
                        insert = "insert into LPAY.RCPTNO (RCBRNO, RCYEAR, RCTYPE, RCNO) values(" + BRN + "," + d_today + ",16," + rcptno + " )";
                        dm.insertRecords(insert);
                    }
                    #endregion

                    if (duemnth.ToString().Length != 2)
                    {
                        fstdue = dueyr.ToString() + "0" + duemnth.ToString();
                    }
                    else
                    {
                        fstdue = dueyr.ToString() + duemnth.ToString();
                    }
                    int lltype = 5;
                    int llcode = 8;
                    //string fstlldate = "";
                    int nextdueyr = dueyr;
                    double ageint = 0.0;
                    string IP = Request.ServerVariables.Get("REMOTE_ADDR");
                    double fstprm = System.Math.Round((singleprm + remprm), 2);

                    #region Write Data to LCLM.LEDGER

                    string sql = "select * from lclm.ledger where LLPOL=" + polno + " and LLTYP=5  and lldue=" + int.Parse(fstdue) + "";
                    if (dm.existRecored(sql) == 0)
                    {
                        insert = "insert into lclm.ledger(LLPOL,LLDUE,LLTYP,LLCOD,LLPRM,LLMOD,LLDAT,LLPBR,LLREC) " +
                                    " values(" + polno + "," + int.Parse(fstdue) + "," + lltype + "," + llcode + "," + fstprm + "," + mode + "," + int.Parse(Currday) + "," + BRN + ",'" + rcptno + "')";
                        dm.insertRecords(insert);
                    }
                    int j = 0;
                    int k = 0;
                    //for (int i = 0; i < paiddue; i++)
                    for (int i = 0; i < (paiddue-1); i++)
                    //for (int i = 0; i < paiddue; i++)
                    {
                        nextdueyr = nextdueyr + 1;
                        if (duemnth.ToString().Length != 2)
                        {
                            fstdue = nextdueyr.ToString() + "0" + duemnth.ToString();
                        }
                        else
                        {
                            fstdue = nextdueyr.ToString() + duemnth.ToString();
                        }
                        if (i % 2 == 0)
                        {
                            fstprm = double.Parse(prms1[k].ToString());
                            k++;

                        }
                        if (i % 2 != 0)
                        {
                            fstprm = double.Parse(prms2[j].ToString());
                            j++;
                        }
                        string sql1 = "select * from lclm.ledger where LLPOL=" + polno + " and LLTYP=5  and lldue=" + int.Parse(fstdue) + "";
                        if (dm.existRecored(sql1) == 0)
                        {
                            insert = "insert into lclm.ledger(LLPOL,LLDUE,LLTYP,LLCOD,LLPRM,LLMOD,LLDAT,LLPBR,LLREC) " +
                                    " values(" + polno + "," + int.Parse(fstdue) + "," + lltype + "," + llcode + "," + fstprm + "," + mode + "," + int.Parse(Currday) + "," + BRN + ",'" + rcptno + "')";
                            dm.insertRecords(insert);
                        }
                    }
                    #endregion

                    #region Write Data to SUNDRY_RCPT and SUNDRY_DETAIL
                    int due_yr = dueyr;
                    selsundry = "select * from lclm.sundry_rcpt where SCLMNO='" + clmno + "' and  SPOLNO=" + polno + " and RCPTNO=" + rcptno + " and SYSCODE='D'";
                    if (dm.existRecored(selsundry) == 0)
                    {
                        insert = "insert into lclm.sundry_rcpt(SCLMNO,SPOLNO,RCPTNO,SDIFFPR,COMMDATE,TBLE,TERM,PACODE,RCVDNAME,ENTRYEPF,ENTRYIP,ENTRYDATE,PRINT,SYSCODE,ENTRY_BR,DIFFINT)" +
                                "values('" + clmno + "'," + polno + "," + rcptno + "," + ageamt + "," + comdt + "," + tble + "," + trm + "," + pacd + ",'" + name + "','" + entEPF + "','" + IP + "',sysdate,1,'D'," + BRN + "," + Agedifint + ")";
                        dm.insertRecords(insert);

                        for (int h = 0; h <= 1; h++)
                        {
                            if (h == 0)
                            {
                                sngleprm = singleprm;
                                string mnthstr = "";
                                mnthstr = duemnth.ToString();
                                if (mnthstr.Length < 2)
                                {
                                    mnthstr = "0" + mnthstr;
                                }
                                fstdue = dueyr.ToString() + mnthstr;

                            }
                            if (h == 1)
                            {
                                sngleprm = remprm;
                                string mnthstr = "";
                                mnthstr = (duemnth + 1).ToString();
                                if (mnthstr.Length < 2)
                                {
                                    mnthstr = "0" + mnthstr;
                                }
                                fstdue = dueyr.ToString() + mnthstr;
                            }
                            insert = "insert into lclm.sundry_detail(SCLMNO,SPOLNO,SRECNO,DUEYRMN,PRMAMT) values('" + clmno + "'," + polno + "," + rcptno + "," + fstdue + "," + sngleprm + ")";
                            dm.insertRecords(insert);
                        }
                        j = 0;
                        k = 0;
                        //for (int i = 0; i < paiddue; i++)
                        for (int i = 0; i < (paiddue-1); i++)
                        {
                            string StrMnth = "";
                            due_yr = due_yr + 1;
                            StrMnth = duemnth.ToString();
                            if (StrMnth.Length < 2)
                            {
                                StrMnth = "0" + StrMnth;
                            }

                            int fst_due = int.Parse(due_yr.ToString() + StrMnth);
                            if (i % 2 == 0)
                            {
                                fstprm = double.Parse(prms1[k].ToString());
                                k++;

                            }
                            if (i % 2 != 0)
                            {
                                fstprm = double.Parse(prms2[j].ToString());
                                j++;
                            }
                            string selsundet = "select * from lclm.sundry_detail where SCLMNO='" + clmno + "' and SPOLNO=" + polno + " and DUEYRMN=" + fst_due + " ";
                            if (dm.existRecored(selsundet) == 0)
                            {
                                insert = "insert into lclm.sundry_detail(SCLMNO,SPOLNO,SRECNO,DUEYRMN,PRMAMT) values('" + clmno + "'," + polno + "," + rcptno + "," + fst_due + "," + fstprm + ")";
                               dm.insertRecords(insert);
                            }

                        }
                    }
                    else
                    {
                        insert = "UPDATE lclm.sundry_rcpt set SDIFFPR=" + ageamt + ",ENTRYEPF='" + entEPF + "',ENTRYIP='" + IP + "',ENTRYDATE=sysdate,SYSCODE='D',ENTRY_BR=" + BRN + ",DIFFINT=" + ageint + " where SCLMNO='" + clmno + "' And SPOLNO=" + polno + " And RCPTNO=" + rcptno + "";
                        dm.insertRecords(insert);
                    }
                    #endregion

                    #region Write Data into LPAYMAS
                    //use code =16 for lpaymas from sundry receipt(Death)
                    //LPBTP=16 --- LPACD=2235--LPPTP=3


                    string[] ti = DateTime.Now.ToString().Split(' ');
                    string currtime = ti[1].ToString() + ti[2].ToString();

                    string sellpaymas = "select * FROM  LPAY.LPAYMAS where LPBRN=" + BRN + " and LPBTP=16 and LPPTD=" + int.Parse(Currday) + " and LPREC=" + rcptno + "";
                    if (dm.existRecored(sellpaymas) == 0)
                    {
                        insert = "insert into LPAY.LPAYMAS(LPBRN,LPPTD,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPAM1,LPCA1,LPCA2,LPACD,LPSTA,LPOPR,LPEDT,LPTIM,LPIPA,LPSBR,LPMD1)" +
                                " values(" + BRN + "," + int.Parse(Currday) + ",16," + rcptno + "," + polno + "," + polno + ",3," + ageamt + "," + ageamt + "," + Agedifint + ",2235,0," +
                                " '" + dm.EpfCode(entEPF) + "'," + int.Parse(Currday) + ",'" + currtime + "','" + IP + "'," + serbr + ",5) ";
                        dm.insertRecords(insert);
                    }
                    #endregion

                    #region Write Sundry Data to LPAYCOM
                    //use code =16 for lpaycom from sundry receipt
                    fstdue = dueyr.ToString() + duemnth.ToString();
                    string LCCOD = "";
                    string sellpaycom = "select * FROM  LPAY.LPAYCOM where LCPBR=" + BRN + " and LCBTP=16 and LCPDT=" + int.Parse(Currday) + " and LCREC='" + rcptno + "' and LCDUE=" + int.Parse(fstdue) + "";
                    if (dm.existRecored(sellpaycom) == 0)
                    {
                        
                        int ndueyr = dueyr;
                        int l = 0;
                        int n = 0;
                        LCCOD = "8";
                        //for (int x = 0; x <= paiddue; x++)
                        for (int x = 0; x < (paiddue-1); x++)
                        {
                            if (x == 0)
                            {
                                fstprm = singleprm + remprm;
                            }
                            else
                            {
                                if (x % 2 == 0)
                                {
                                    fstprm = double.Parse(prms2[l].ToString());
                                    l++;

                                }
                                if (x % 2 != 0)
                                {
                                    fstprm = double.Parse(prms1[n].ToString());
                                    n++;
                                }
                            }

                            if (duemnth.ToString().Length != 2)
                            {
                                fstdue = ndueyr.ToString() + "0" + duemnth.ToString();
                            }
                            else
                            {
                                fstdue = ndueyr.ToString() + duemnth.ToString();
                            }
                            string selcom = "select * FROM  LPAY.LPAYCOM where LCPBR=" + BRN + " and LCBTP=16 and LCPDT=" + int.Parse(Currday) + " and LCREC='" + rcptno + "' and LCDUE=" + int.Parse(fstdue) + "";
                            if (dm.existRecored(selcom) == 0)
                            {
                                insert = "insert into LPAY.LPAYCOM(LCPBR,LCPDT,LCBTP,LCREC,LCPOL,LCDUE,LCTBL,LCTRM,LCMOD,LCPRM,LCCDT,LCPAC,LCAGT,LCORG,LCSBR,LCFST,LCCOD)" +
                                       " values(" + BRN + "," + int.Parse(Currday) + ",'16','" + rcptno + "'," + polno + "," + int.Parse(fstdue) + "," + tble + "," + trm + "," + mode + "," + fstprm + "," + comdt + "," + pacd + "," +
                                       " " + agtcd + "," + orgcd + "," + serbr + ",0,'" + LCCOD + "') ";
                                dm.insertRecords(insert);
                            }
                            ndueyr = ndueyr + 1;

                        }
                    }
                    #endregion

                    dm.commit();
                    //dm.rollback();
                    dm.oraConn.Close();
                    //lblmsg.Text = "Successfully Updated Sundry Receipt Data....";
                   // lblmsg.ForeColor = System.Drawing.Color.Green;
                }

                else
                {
                    EPage.Messege = "This Sundry Receipt has already been Issued...";
                   // lblmsg.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("EPage.aspx");
                }


            }
            catch (Exception exc)
            {
                EPage.Messege = "Sundry Receipt is Already Issued OR Data Insertion  Error....";

               // lblmsg.ForeColor = System.Drawing.Color.Red;
                dm.rollback();
                Response.Redirect("EPage.aspx");

            }
            #endregion

            //CreateDynamicTable();
            Session["EPFNum"] = hdfepf.Value;
            Session["brcode"] = hdfbrn.Value;
            
        }
        else
        { 
        
        }
    }
}
