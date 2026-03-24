using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for ReInsurance
/// </summary>
/// 
[Serializable]
public class ReInsurance
{
    private string claimno;
    private string polno;
    private string emailsentdate;
    private string stage;
    private string filled;
    private string filleddate;
    private string paymentsentdate;
    private string availability;
    private string shrdetails;
    private string link;
    private string adblink;
    private string paymentsent;
    private string adbsentdate;
    public ReInsurance()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<ReInsurance> GetInqList(string type,string polno, DataManager dm)
    {
        List<ReInsurance> inqlist = new List<ReInsurance>();
        string poltest = "";
        try
        {
            string subsql = "";
            if(type != "1")
            {
                if(type == "2")
                {
                    subsql = " and a.POLNO='" + polno + "'";
                }
                if (type == "3")
                {
                    subsql = " and (b.RE_INS_STATUS='PENDING' or b.RE_INS_STATUS is Null) and b.AVAILABILITY='Y'";
                }
                if (type == "4")
                {
                    subsql = " and b.RE_INS_STATUS='COMPLETED'";
                }
            }
            string inqselect = "select a.CLAIMNO,a.POLNO,to_char(a.sent_date,'yyyy/MM/dd'),a.SENT_BY,b.AVAILABILITY,b.RE_INT_TOT,to_char(b.ENTRY_DATE,'yyyy/MM/dd')," +
                "b.ENTRED_BY,b.PAYMENT_DETAIL_SENT,to_char(b.PAYMENT_DETAIL_SENT_DATE,'yyyy/MM/dd'),c.AMTOUT,c.PAYAUTDT,d.DPOLST,c.DRMOS,to_char(b.ADB_PAYMENT_SENT,'yyyy/MM/dd'),c.ADB_LATEPAY,a.ERROR,e.ERROR,f.ERROR from LPHS.DTH_REINS_EMAIL_LOG a LEFT OUTER JOIN " +
                "LPHS.DTH_REINSURANCE_DTL b on a.CLAIMNO = b.CLAIMNO LEFT OUTER JOIN LPHS.DTHREF c on a.CLAIMNO = c.DRCLMNO AND A.POLNO=C.DRPOLNO LEFT OUTER JOIN LPHS.DTHINT d on a.CLAIMNO= d.DCLM AND A.POLNO=D.DPOLNO  " +
                "LEFT OUTER JOIN (select * from LPHS.DTH_REINS_EMAIL_LOG where TYPE='PAYMENT') e on a.CLAIMNO = e.CLAIMNO " +
                "LEFT OUTER JOIN(select * from LPHS.DTH_REINS_EMAIL_LOG where TYPE = 'ADB PAYMENT') f " +
                "on a.CLAIMNO = f.CLAIMNO  WHERE a.TYPE = 'REGISTRATION'" + subsql + " order by a.SENT_DATE";
            if (dm.existRecored(inqselect) != 0)
            {
                dm.readSql(inqselect);
                OracleDataReader inqreader = dm.oraComm.ExecuteReader();

                while (inqreader.Read())
                {
                    ReInsurance reins = new ReInsurance();
                    if (!inqreader.IsDBNull(0)) { reins.ClaimNo = inqreader.GetString(0); }
                    if (!inqreader.IsDBNull(1)) { reins.PolNo = inqreader.GetInt32(1).ToString(); }
                    poltest = reins.PolNo;
                    if (!inqreader.IsDBNull(2)) { reins.EmailSentDate = inqreader.GetString(2); }
                    if (!inqreader.IsDBNull(4)) { reins.Availability = inqreader.GetString(4).ToString() == "Y" ? "Yes" : "No"; } else { reins.Availability = "-"; }
                    if (!inqreader.IsDBNull(5)) { reins.ShrDetails = inqreader.GetDouble(5) > 0 ? "Yes" : "No"; } else { reins.ShrDetails = "-"; }
                    if (!inqreader.IsDBNull(6)) { reins.FilledDate = inqreader.GetString(6); reins.Filled = "Yes"; } else { reins.FilledDate = "-";reins.Filled = "No"; }
                    if (!inqreader.IsDBNull(8)) { reins.PaymentSent = inqreader.GetString(8) == "Y" ? "Yes" : "No"; } else { reins.PaymentSent = "No"; }
                    if (!inqreader.IsDBNull(9)) { reins.PaymentSentDate = inqreader.GetString(9); } else { reins.PaymentSentDate = "-"; }
                    int payaudt = 0;
                    double amtout = 0;
                    string polstat = "";
                    string MOF = "";
                    string adblatepay = "";
                    if (!inqreader.IsDBNull(10)) { amtout = inqreader.GetDouble(10); }
                    if (!inqreader.IsDBNull(11)) { payaudt = inqreader.GetInt32(11); }
                    if (!inqreader.IsDBNull(12)) { polstat = inqreader.GetString(12); }
                    if (!inqreader.IsDBNull(13)) { MOF = inqreader.GetString(13); }
                    if (!inqreader.IsDBNull(14)) { reins.ADBSentDate = inqreader.GetString(14); }
                    if (!inqreader.IsDBNull(15)) { adblatepay = inqreader.GetString(15); }
                    if (!inqreader.IsDBNull(16)) {
                        reins.EmailSentDate = "SENT FAILD";
                    }
                    if (!inqreader.IsDBNull(17))
                    {
                        //reins.PaymentSent = "No";
                        reins.PaymentSentDate = "SENT FAILD";
                    }
                    if (!inqreader.IsDBNull(18))
                    {
                        reins.ADBSentDate = "SENT FAILD";
                    }

                  
                    if (payaudt == 0)
                    {
                        reins.Stage = "Registration";
                    }
                    if(amtout > 0)
                    {
                        reins.Stage = "Paid - Part of Claim";
                    }
                    if (amtout == 0 && payaudt > 0)
                    {
                        reins.Stage = "Paid - Full Claim";
                    }

                    if(reins.PaymentSent == "Yes")
                    {
                        reins.Link = "<a href=PaymentForm.aspx?pState=1&clmno="+reins.ClaimNo+"&polno="+reins.PolNo+ "&adblatepay="+adblatepay+ "&mos="+MOF+">Download Form</a>";
                    }

                    if (!string.IsNullOrEmpty(reins.ADBSentDate) && reins.ADBSentDate.Length > 0)
                    {
                        reins.ADBLink = "<a href=PaymentForm.aspx?pState=1&clmno=" + reins.ClaimNo + "&polno=" + reins.PolNo + "&adb=1&mos="+MOF+" > ADB Form</a>";
                    }

                    reins.ShrDetails = "<a target=_blank href=Actuarial002.aspx?clmno=" + reins.ClaimNo + "&polno=" + reins.PolNo + "> Share Details</a>";

                    bool IsLapsedNoPaidUp = false;
                    if (polstat == "L")
                    {
                        int MOD = 0;
                        int TBL = 0;
                        int COM = 0;
                        int TRM = 0;
                        #region--------------------------- Policy History ----------------------------------------------------------
                        string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue, pmmod, PMCOD, PMPAC from lphs.premast where pmpol=" + reins.PolNo + " ";
                        string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, lpmod, LPCOD, LPPAC from lphs.liflaps where lppol=" + reins.PolNo + " ";
                        string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phmod , PHCOD, PHPAC, phsta from lphs.lpolhis where phpol=" + reins.PolNo + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                        string query = "";
                        if (dm.existRecored(premastSelect) > 0)
                        { query = premastSelect; }
                        else if (dm.existRecored(liflapsSelect) > 0)
                        { query = liflapsSelect; }
                        else if (dm.existRecored(polhisSelect) > 0)
                        { query = polhisSelect; }
                        else
                        { 
                            //throw new Exception("No Policy Details!"); 
                        }

                        if(query != "")
                        {
                            if (dm.existRecored(query) != 0)
                            {
                                dm.readSql(query);
                                OracleDataReader persreader = dm.oraComm.ExecuteReader();
                                while (persreader.Read())
                                {
                                    if (!persreader.IsDBNull(1)) { TBL = Convert.ToInt32(persreader[1]); } else { TBL = 0; }
                                    if (!persreader.IsDBNull(2)) { TRM = Convert.ToInt32(persreader[2]); } else { TRM = 0; }
                                    if (!persreader.IsDBNull(3)) { COM = Convert.ToInt32(persreader[3]); } else { COM = 0; }
                                    if (!persreader.IsDBNull(5)) { MOD = Convert.ToInt32(persreader[5]); } else { MOD = 0; }
                                }
                                persreader.Close();
                                persreader.Dispose();
                            }
                            int paidDue = 0;
                            string sqlpaidCOunt = "select nvl(max(LLDUE),0) from lclm.ledger where LLPOL='" + reins.PolNo + "'";

                            if (dm.existRecored(sqlpaidCOunt) != 0)
                            {
                                dm.readSql(sqlpaidCOunt);
                                OracleDataReader persreader = dm.oraComm.ExecuteReader();
                                while (persreader.Read())
                                {
                                    if (!persreader.IsDBNull(0)) { paidDue = Convert.ToInt32(persreader[0]); } else { paidDue = 0; }
                                }
                                persreader.Close();
                                persreader.Dispose();
                            }
                            DateTime nextDue = new DateTime();
                            int exitDue = 0;
                            if (paidDue > 0 && paidDue.ToString().Length == 6)
                            {
                                DateTime dt = DateTime.Parse(paidDue.ToString().Substring(0, 4) + "/" + paidDue.ToString().Substring(4, 2) + "/" + "01");
                                if (MOD == 1)
                                {
                                    nextDue = dt.AddMonths(12);
                                }
                                else if (MOD == 2)
                                {
                                    nextDue = dt.AddMonths(6);
                                }
                                else if (MOD == 3)
                                {
                                    nextDue = dt.AddMonths(3);
                                }
                                else
                                {
                                    nextDue = dt.AddMonths(1);
                                }
                                exitDue = int.Parse(nextDue.ToString("yyyyMMdd").Substring(0, 6));
                            }
                            int isPaidUp = 0;
                            if(exitDue > 0)
                            {
                                isPaidUp = isPaidup(TRM, COM, exitDue, TBL);
                            }
                            

                            if (isPaidUp == 0)
                            {
                                IsLapsedNoPaidUp = true;
                            }
                        }
                       
                        #endregion

                        
                    }

                    if (!IsLapsedNoPaidUp)
                    {
                        inqlist.Add(reins);
                    }
                    
                }

                inqreader.Close();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

        return inqlist;
    }


    public void sendReInuranceEmail(int polno, long claimNo,string EPF)
    {
        string msg = "", msTyp = "", resTyp = "", pdfName_ = "";
        String body = "";
        string reciverAddr = "";
        string dthDate = "";
        string matDate = "";

        int plan_id = 200;
        List<string> EMailDataListCC = null;
        List<string> EMailDataListTO = null;
        //List<string> EMailDataListBCC = null;
        DataManager dthintobj = new DataManager();
        try
        {
            string reinsemailcheck = "select * from lphs.DTH_REINS_EMAIL_LOG where POLNO='" + polno + "' and CLAIMNO='" + claimNo + "' AND TYPE='REGISTRATION' AND SENT_DATE is not null";
            if (dthintobj.existRecored(reinsemailcheck) == 0)
            {

                

                string liftyp = "";
                string gender = "";
                string dob = "";
                string polpersubsql = "";
                string status = "";
                string basicsum = "-";
                string fpusum = "-";
                string fpucov = "";
                string sjsum = "-";
                string sjcov = "";
                string adbsum = "-";
                string adbcov = "";
                string spousesum = "-";
                string cicsum = "-";
                string ciccov = "";
                string MOF = "";
                string polstat = "";
                string causeofDeath = "";
                int TBL = 0;
                int TRM = 0;
                int COM = 0;
                string nameOfDead = "";
                string dateofdeath = "";

                try
                {
                    string dthint = "select DMOS,DPOLST,DNOD,DDTOFDTH from LPHS.DTHINT where DPOLNO='" + polno + "' and DCLM='" + claimNo + "'";

                    if (dthintobj.existRecored(dthint) != 0)
                    {
                        dthintobj.readSql(dthint);
                        OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (persreader.Read())
                        {
                            if (!persreader.IsDBNull(0)) { MOF = persreader.GetString(0); }
                            if (!persreader.IsDBNull(1)) { polstat = persreader.GetString(1); }
                            if (!persreader.IsDBNull(2)) { nameOfDead = persreader.GetString(2); }
                            if (!persreader.IsDBNull(3)) { dateofdeath = persreader.GetInt32(3).ToString(); }
                        }
                        persreader.Close();
                        persreader.Dispose();
                    }
                    else
                    {
                        throw new Exception("No Intimation found..!");
                    }

                    status = polstat == "I" ? "Inforce" : "Lapse";

                    switch (MOF)
                    {
                        case "M":
                            liftyp = "Main Life";
                            polpersubsql = "where polno='" + polno + "' and prpertype='1'";
                            fpucov = "('4')";
                            sjcov = "('10')";
                            adbcov = "('2')";
                            ciccov = "('5','6')";
                            break;
                        case "S":
                            polpersubsql = "where polno='" + polno + "' and prpertype='2'";
                            liftyp = "Spouse";
                            fpucov = "('104')";
                            sjcov = "('110')";
                            adbcov = "('102')";
                            ciccov = "('105','106')";
                            break;
                        case "2":
                            polpersubsql = "where polno='" + polno + "' and prpertype='3'";
                            liftyp = "Second Life";
                            fpucov = "('204')";
                            sjcov = "('210')";
                            adbcov = "('202')";
                            ciccov = "('205','206')";
                            break;
                        case "C":
                            polpersubsql = "where polno='" + polno + "' and prpertype in ('4','5','6',7','8')";
                            liftyp = "Child";
                            fpucov = "('304','404','504','604','704')";
                            sjcov = "('310','410','510','610','710')";
                            adbcov = "('302','402','502','602','702')";
                            ciccov = "('7')";
                            break;
                        default:
                            polpersubsql = "where polno='" + polno + "' and prpertype='1'";
                            liftyp = "Main Life";
                            break;
                    }

                    string dthRef = "select CAUSEOFDEATHSTR from lphs.dthref where DRPOLNO='" + polno + "' and DRCLMNO='" + claimNo + "'";

                    if (dthintobj.existRecored(dthRef) != 0)
                    {
                        dthintobj.readSql(dthRef);
                        OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (persreader.Read())
                        {
                            if (!persreader.IsDBNull(0)) { causeofDeath = persreader.GetString(0).Trim(); }
                        }
                        persreader.Close();
                        persreader.Dispose();
                    }
                    else
                    {
                        throw new Exception("No Death Registration found..!");
                    }

                    if (!string.IsNullOrEmpty(causeofDeath))
                    {
                        string sqlpersonal = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL " + polpersubsql;

                        if (dthintobj.existRecored(sqlpersonal) != 0)
                        {
                            dthintobj.readSql(sqlpersonal);
                            OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (persreader.Read())
                            {
                                if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
                                if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
                            }
                            persreader.Close();
                            persreader.Dispose();
                        }
                        else
                        {
                            string sqlpersonalhis = "select to_char(to_date(DOB,'yyyyMMdd'),'yyyy/MM/dd'),(case when SEXCODE = 'F' then 'FEMALE' else 'MALE' end) as GENDER from LUND.POLPERSONAL_HISTORY " + polpersubsql;
                            dthintobj.readSql(sqlpersonalhis);
                            OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (persreader.Read())
                            {
                                if (!persreader.IsDBNull(0)) { dob = persreader.GetString(0); }
                                if (!persreader.IsDBNull(1)) { gender = persreader.GetString(1); }
                            }
                            persreader.Close();
                            persreader.Dispose();
                        }

                        int MOD = 0;
                        #region--------------------------- Policy History ----------------------------------------------------------
                        string premastSelect = "select pmsum, pmtbl, pmtrm, pmcom, pmdue, pmmod, PMCOD, PMPAC from lphs.premast where pmpol=" + polno + " ";
                        string liflapsSelect = "select lpsum, lptbl, lptrm, lpcom, lpdue, lpmod, LPCOD, LPPAC from lphs.liflaps where lppol=" + polno + " ";
                        string polhisSelect = "select phsum, phtbl, phtrm, phcom, phdue, phmod , PHCOD, PHPAC, phsta from lphs.lpolhis where phpol=" + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ";
                        string query = "";
                        if (dthintobj.existRecored(premastSelect) > 0)
                        { query = premastSelect; }
                        else if (dthintobj.existRecored(liflapsSelect) > 0)
                        { query = liflapsSelect; }
                        else if (dthintobj.existRecored(polhisSelect) > 0)
                        { query = polhisSelect; }
                        else
                        { throw new Exception("No Policy Details!"); }

                        if (dthintobj.existRecored(query) != 0)
                        {
                            dthintobj.readSql(query);
                            OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (persreader.Read())
                            {
                                if (!persreader.IsDBNull(1)) { TBL = Convert.ToInt32(persreader[1]); } else { TBL = 0; }
                                if (!persreader.IsDBNull(2)) { TRM = Convert.ToInt32(persreader[2]); } else { TRM = 0; }
                                if (!persreader.IsDBNull(3)) { COM = Convert.ToInt32(persreader[3]); } else { COM = 0; }
                                if (!persreader.IsDBNull(5)) { MOD = Convert.ToInt32(persreader[5]); } else { MOD = 0; }
                            }
                            persreader.Close();
                            persreader.Dispose();
                        }

                        //using (DataTable dataTable = dal.ReadSQLtoDataTable(query))
                        //{
                        //    using (DataTableReader premReader = dataTable.CreateDataReader())
                        //    {
                        //        while (premReader.Read())
                        //        {
                        //            //if (!premReader.IsDBNull(0)) { sumassured = Convert.ToDouble(premReader[0]); } else { sumassured = 0; }
                        //            if (!premReader.IsDBNull(1)) { TBL = Convert.ToInt32(premReader[1]); } else { TBL = 0; }
                        //            if (!premReader.IsDBNull(2)) { TRM = Convert.ToInt32(premReader[2]); } else { TRM = 0; }
                        //            if (!premReader.IsDBNull(3)) { COM = Convert.ToInt32(premReader[3]); } else { COM = 0; }
                        //            //if (!premReader.IsDBNull(4)) { DUE = Convert.ToInt32(premReader[4]); } else { DUE = 0; }
                        //            //if (!premReader.IsDBNull(5)) { MOD = Convert.ToInt32(premReader[5]); } else { MOD = 0; }
                        //            //if (!premReader.IsDBNull(6)) { COD = premReader[6].ToString(); } else { COD = ""; }
                        //            //if (!premReader.IsDBNull(7)) { PAC = Convert.ToInt32(premReader[7]); } else { PAC = 0; }
                        //        }
                        //    }
                        //}
                        #endregion

                        bool IsLapsedNoPaidUp = false;

                        if (status == "Lapse")
                        {
                            int paidDue = 0;
                            string sqlpaidCOunt = "select nvl(max(LLDUE),0) from lclm.ledger where LLPOL='" + polno + "'";

                            if (dthintobj.existRecored(sqlpaidCOunt) != 0)
                            {
                                dthintobj.readSql(sqlpaidCOunt);
                                OracleDataReader persreader = dthintobj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while (persreader.Read())
                                {
                                    if (!persreader.IsDBNull(0)) { paidDue = Convert.ToInt32(persreader[0]); } else { paidDue = 0; }
                                }
                                persreader.Close();
                                persreader.Dispose();
                            }
                            DateTime nextDue = new DateTime();
                            int exitDue = 0;
                            if (paidDue > 0)
                            {
                                DateTime dt = DateTime.Parse(paidDue.ToString().Substring(0, 4) + "/" + paidDue.ToString().Substring(4, 2) + "/" + "01");
                                if (MOD == 1)
                                {
                                    nextDue = dt.AddMonths(12);
                                }
                                else if (MOD == 2)
                                {
                                    nextDue = dt.AddMonths(6);
                                }
                                else if (MOD == 3)
                                {
                                    nextDue = dt.AddMonths(3);
                                }
                                else
                                {
                                    nextDue = dt.AddMonths(1);
                                }
                                exitDue = int.Parse(nextDue.ToString("yyyyMMdd").Substring(0, 6));
                            }
                            int isPaidUp = 0;
                            isPaidUp = isPaidup(TRM, COM, exitDue, TBL);

                            if (isPaidUp == 0)
                            {
                                IsLapsedNoPaidUp = true;
                            }
                        }


                        //int paycount = 0;
                        //switch (MOD)
                        //{
                        //    case 1:
                        //        paycount = 1;
                        //        break;
                        //    case 2:
                        //        paycount = 6;
                        //        break;
                        //    case 3:
                        //        paycount = 3;
                        //        break;
                        //    case 4:
                        //        paycount = 12;
                        //        break;
                        //    case 5:
                        //        paycount = 1;
                        //        break;
                        //    default:
                        //        paycount = 0;
                        //        break;
                        //}
                        //if (status == "Lapse")
                        //{
                        //    if(paidCount < paycount)
                        //    {
                        //        IsLapsedNoPaidUp = true;
                        //    }

                        //}

                        if (!IsLapsedNoPaidUp)
                        {
                            string reinsemailcheckmail = "select * from lphs.DTH_REINS_EMAIL_LOG where POLNO='" + polno + "' and CLAIMNO='" + claimNo + "' AND TYPE='REGISTRATION'";
                            if(dthintobj.existRecored(reinsemailcheckmail) == 0)
                            {
                                string insertEmaillog = @"INSERT INTO LPHS.DTH_REINS_EMAIL_LOG 
                                    (POLNO,CLAIMNO,ENTRY_DATE,ENTRY_BY,TYPE)
                                     VALUES ('" + polno + "','" + claimNo + "' , sysdate, '" + EPF + "','REGISTRATION')";
                                dthintobj.insertRecords(insertEmaillog);
                            }
                            

                            Covers covers = new Covers();
                            List<Covers> coverlist = new List<Covers>();
                            coverlist = covers.GetolicyCovers(polno.ToString(), dthintobj);



                            EMailData mailOb = new EMailData();
                            reciverAddr = mailOb.getEmailIDForDeathTO("ACTU", "TO", plan_id);


                            //------------add cc list -----------------------------
                            EMailDataListTO = new List<string>();
                            EMailDataListTO = mailOb.getEmailIDForDeath("ACTU", "TO", plan_id);
                            //-

                            //------------add cc list -----------------------------
                            EMailDataListCC = new List<string>();
                            EMailDataListCC = mailOb.getEmailIDForDeath("ACTU", "CC", plan_id);
                            //------------end adding --------------------------------


                            body = "<h3><b>New Death Claim Registration</b></h3>" +
                                "<table style='font-family:Arial;font-size:11pt;'>" +
                                "<tr><td>Claim No</td><td>:</td><td>" + claimNo + "</td></tr>" +
                                "<tr><td>Policy No</td><td>:</td><td>" + polno + "</td></tr>" +
                                "<tr><td>Plan No</td><td>:</td><td>" + TBL + "</td></tr>" +
                                "<tr><td>Term</td><td>:</td><td>" + TRM + "</td></tr>" +
                                "<tr><td>DOC of the Policy</td><td>:</td><td>" + COM.ToString().Substring(0, 4) + "/" + COM.ToString().Substring(4, 2) + "/" + COM.ToString().Substring(6, 2) + "</td></tr>" +
                                "<tr><td>Name of the Deceased/Claimant</td><td>:</td><td>" + nameOfDead + "</td></tr>" +
                                "<tr><td>Gender</td><td>:</td><td>" + gender + "</td></tr>" +
                                "<tr><td>Date of Birth</td><td>:</td><td>" + dob + "</td></tr>" +
                                "<tr><td>Claim Type</td><td>:</td><td>Death</td></tr>" +
                                "</table>" +
                                "<h4>Death Claim Information</h4>" +
                                "<table style='font-family:Arial;font-size:11pt;margin-left:25px'>";
                            foreach (Covers cov in coverlist)
                            {
                                body += "<tr><td>" + cov.CoverName + "</td><td>:</td><td>" + cov.Sumass + "</td></tr>";
                            }


                            body += "</table>" +
                            "<br>" +
                            "<table style = 'font-family:Arial;font-size:11pt;' > " +
                            "<tr><td>Policy Status</td><td>:</td><td>" + status + "</td></tr>" +
                            "<tr><td>Life Type of Deceased/Claimant</td><td>:</td><td>" + liftyp + "</td></tr>" +
                            "<tr><td>Date of Death/Disability/CIC</td><td>:</td><td>" + dateofdeath.ToString().Substring(0, 4) + "/" + dateofdeath.ToString().Substring(4, 2) + "/" + dateofdeath.ToString().Substring(6, 2) + "</td></tr>" +
                            "<tr><td>Caused of Death/Disability/Type of CIC Illness</td><td>:</td><td>" + causeofDeath + "</td></tr>" +
                            "</table>";




                            //---------------------------send email settings ---------------------------------------------
                            //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

                            string smtpClient = WebConfigurationManager.AppSettings["smtpClient"];
                            string mailAddress_ = WebConfigurationManager.AppSettings["mailAddress"];
                            string userName = WebConfigurationManager.AppSettings["userName"];
                            string password = WebConfigurationManager.AppSettings["password"];
                            int port = Convert.ToInt32(WebConfigurationManager.AppSettings["port"]);

                            MailMessage mm = new MailMessage(mailAddress_, reciverAddr);
                            mm.Subject = "New Death Claim Registration - Policy No: " + polno;
                            mm.Body = body;
                            //string pdfname = "Acturail-" + lblpolno.Text + ".pdf";
                            //mm.Attachments.Add(new Attachment(ms, pdfname));
                            mm.IsBodyHtml = true;

                            if (EMailDataListTO != null)
                            {
                                foreach (string item in EMailDataListTO)
                                {
                                    if (item.ToString().ToUpper() != reciverAddr.ToUpper())
                                    {
                                        mm.To.Add(item);

                                    }
                                }
                            }

                            if (EMailDataListCC != null)
                            {
                                foreach (string item in EMailDataListCC)
                                {
                                    mm.CC.Add(item);

                                }
                            }

                            //if (EMailDataListBCC != null)
                            //{
                            //    foreach (string item in EMailDataListBCC)
                            //    {
                            //        mm.Bcc.Add(item);

                            //    }
                            //}

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = smtpClient;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["ssl"]);
                            NetworkCredential NetworkCred = new NetworkCredential();
                            NetworkCred.UserName = userName;
                            NetworkCred.Password = password;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = port;

                            smtp.Send(mm);
                            string updateEmaillog = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set SENT_DATE=sysdate,SENT_BY='" + EPF + "',ERROR='' " +
                                "WHERE POLNO='" + polno + "' and CLAIMNO='" + claimNo + "' and TYPE='REGISTRATION'";
                            dthintobj.insertRecords(updateEmaillog);
                            //dal.ExecuteTableUpdateQuery(insertEmaillog);
                        }
                    }
                }catch(Exception ex)
                {
                    string err = "";
                    if (ex.ToString().Length > 1500)
                    {
                        err = ex.ToString().Substring(0, 1500);
                    }
                    else
                    {
                        err = ex.ToString();
                    }
                    err = err.Replace("'", "");
                    
                    string erroUpdate = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set ERROR='" + err + "' " +
                    "WHERE POLNO='" + polno + "' and CLAIMNO='" + claimNo + "' and TYPE='REGISTRATION'";
                    dthintobj.insertRecords(erroUpdate);
                    //dthintobj.connclose();
                }
            }
            else
            {
                //Email Already Sent
            }

            dthintobj.connclose();
        }
        catch (Exception ex)
        {
            string err = "";
            if (ex.ToString().Length > 1500)
            {
                err = ex.ToString().Substring(0, 1500);
            }
            else
            {
                err = ex.ToString();
            }
            err = err.Replace("'", "");
            string erroUpdate = "UPDATE LPHS.DTH_REINS_EMAIL_LOG set ERROR='"+ err + "' " +
                           "WHERE POLNO='" + polno + "' and CLAIMNO='" + claimNo + "' and TYPE='REGISTRATION'";
            dthintobj.insertRecords(erroUpdate);
            dthintobj.connclose();
            throw new Exception(ex.Message);
            
        }

    }

    public int isPaidup(int term, int comDate, int exitDue, int table)
    {

        int paidUp = 0;
        double monthDif = 0;
        DateTime com = DateTime.Parse(comDate.ToString().Substring(0, 4) + "/" + comDate.ToString().Substring(4, 2) + "/" + comDate.ToString().Substring(6, 2));
        DateTime Due = DateTime.Parse(exitDue.ToString().Substring(0, 4) + "/" + exitDue.ToString().Substring(4, 2) + "/" + "01");

        monthDif = (Convert.ToDouble((((Due.Year - com.Year) * 12) + Due.Month - com.Month))) / 12;
        monthDif = Math.Round(monthDif, 2);

        if (table == 1 || table == 2 || table == 3 || table == 4 || (table == 12 && term == 0))
        {
            if (monthDif >= 3)
            {
                paidUp = 1;
            }
        }
        else if (table == 45)
        {
            if (monthDif >= 1)
            {
                paidUp = 1;
            }
        }
        else
        {
            if (term > 10 && monthDif >= 3)
            {
                paidUp = 1;
            }
            else if (term <= 10 && monthDif >= 2)
            {
                paidUp = 1;
            }
        }
        return paidUp;
    }

    public string ClaimNo
    {
        get { return claimno; }
        set { claimno = value; }
    }
    
    public string PolNo
    {
        get { return polno; }
        set { polno = value; }
    }
    public string EmailSentDate
    {
        get { return emailsentdate; }
        set { emailsentdate = value; }
    }
    public string Stage
    {
        get { return stage; }
        set { stage = value; }
    }
    public string Filled
    {
        get { return filled; }
        set { filled = value; }
    }
    public string FilledDate
    {
        get { return filleddate; }
        set { filleddate = value; }
    }
    public string PaymentSentDate
    {
        get { return paymentsentdate; }
        set { paymentsentdate = value; }
    }

    public string ADBSentDate
    {
        get { return adbsentdate; }
        set { adbsentdate = value; }
    }

    public string Availability
    {
        get { return availability; }
        set { availability = value; }
    }

    public string ShrDetails
    {
        get { return shrdetails; }
        set { shrdetails = value; }
    }

    public string Link
    {
        get { return link; }
        set { link = value; }
    }

    public string ADBLink
    {
        get { return adblink; }
        set { adblink = value; }
    }

    public string PaymentSent
    {
        get { return paymentsent; }
        set { paymentsent = value; }
    }


}
