using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AutoReq
/// </summary>

[Serializable()]
public class AutoReq
{
    public AutoReq()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string GetValidRuleSql(int policyStatus, int lifeType,int polno,string MOF,DataManager dthReqObj)
    {
        int plan = 0;
        string ageProof = "";
        string isLifCover = "";
        string COF = "";
        int ageAdmitted = 0;
        int lifeCover = 0;
        int COF_ID = 0;

        //get planid
        if (policyStatus == 1)
        {
            string sql1 = "select pmtbl from lphs.premast where PMPOL= " + polno;
            if (dthReqObj.existRecored(sql1) != 0)
            {
                dthReqObj.readSql(sql1);
                OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader1.Read())
                {
                    if (!reader1.IsDBNull(0)) { plan = reader1.GetInt32(0); }
                }
                reader1.Close();
            }
            else
            {
                string sqllpolhis = "select phtbl from LPHS.lpolhis where phPOL=" + polno;
                if (dthReqObj.existRecored(sqllpolhis) != 0)
                {
                    dthReqObj.readSql(sqllpolhis);
                    OracleDataReader reader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) { plan = reader.GetInt32(0); }
                    }
                    reader.Close();
                }
            }
        }
        else
        {
            string sql2 = "select lptbl from LPHS.LIFLAPS where LPPOL= " + polno;
            if (dthReqObj.existRecored(sql2) != 0)
            {
                dthReqObj.readSql(sql2);
                OracleDataReader reader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    if (!reader2.IsDBNull(0)) { plan = reader2.GetInt32(0); }
                }
                reader2.Close();
            }
            else
            {
                string sqllpolhis2 = "select phtbl from LPHS.lpolhis where phPOL=" + polno;
                if (dthReqObj.existRecored(sqllpolhis2) != 0)
                {
                    dthReqObj.readSql(sqllpolhis2);
                    OracleDataReader reader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) { plan = reader.GetInt32(0); }
                    }
                    reader.Close();
                }
            }
        }

        //age admitted
        string sql4 = "select AGEPROOF from LUND.POLPERSONAL where POLNO=" + polno + " and PRPERTYPE=" + lifeType;
        if (dthReqObj.existRecored(sql4) != 0)
        {
            dthReqObj.readSql(sql4);
            OracleDataReader reader4 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader4.Read())
            {
                if (!reader4.IsDBNull(0)) { ageProof = reader4.GetString(0); } else { ageAdmitted = 0; }
            }
            if (ageProof == "Y") { ageAdmitted = 1; } else { ageAdmitted = 0; }
            reader4.Close();
        }


        //51 Life covers YES or NO
        if (plan == 51)
        {
            string sql6 = "select LIFCOVER from LNB.INVEST_POLICY where POLNO=" + polno + "";
            if (dthReqObj.existRecored(sql6) != 0)
            {
                dthReqObj.readSql(sql6);
                OracleDataReader reader6 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader6.Read())
                {
                    if (!reader6.IsDBNull(0)) { isLifCover = reader6.GetString(0); } else { ageAdmitted = 0; }
                }
                if (isLifCover == "Y") { lifeCover = 1; } else { lifeCover = 0; }
                reader6.Close();
            }
        }


        //Civil or Forces
        string sql9 = "select DCOF from LPHS.DTHINT where DPOLNO='" + polno + "' and DMOS='" + MOF + "'";
        if (dthReqObj.existRecored(sql9) != 0)
        {
            dthReqObj.readSql(sql9);
            OracleDataReader reader9 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader9.Read())
            {
                if (!reader9.IsDBNull(0)) { COF = reader9.GetString(0); } else { COF = ""; }
            }
            reader9.Close();

            switch (COF)
            {
                case "C":
                    COF_ID = 1;
                    break;
                case "A":
                    COF_ID = 2;
                    break;
                case "N":
                    COF_ID = 3;
                    break;
                case "G":
                    COF_ID = 4;
                    break;
                case "P":
                    COF_ID = 5;
                    break;
                case "B":
                    COF_ID = 6;
                    break;
                default:
                    COF_ID = 1;
                    break;
            }
        }


        //Current Status
        string policyCurrentStatus = "0";
        string cstat = "";
        string sqlInforce = "select CPOLSTAT from LPHS.DTHREF where DRPOLNO= '" + polno+"' and DRMOS='"+ MOF + "'";
        if (dthReqObj.existRecored(sqlInforce) != 0)
        {
            dthReqObj.readSql(sqlInforce);
            OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader1.Read())
            {
                if (!reader1.IsDBNull(0)) { cstat = reader1.GetString(0); } else { cstat = ""; }
            }
            reader1.Close();
        }
        if(cstat == "I")
        {
            policyCurrentStatus = "1";
        }else if (cstat == "L")
        {
            policyCurrentStatus = "2";
        }

        //Continue Life Type
        string continueLifeType = "0";
        if (policyCurrentStatus == "1")
        {
            string sqlspouse = "select * from lund.rcover where RCOVR='101' and RPOL='" + polno + "'";
            if (dthReqObj.existRecored(sqlspouse) != 0)
            {
                dthReqObj.readSql(sqlspouse);
                OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader1.Read())
                {
                    continueLifeType = "2";
                }
                reader1.Close();
            }
        }


        string sql = "select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=1 and PARAM_VALUE_ID=" + policyStatus
               + ")INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where ( PARAM_ID=4 and PARAM_VALUE_ID=" + lifeType
               + ")INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=5 and PARAM_VALUE_ID=" + plan
               + ") INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=7 and PARAM_VALUE_ID=" + ageAdmitted + ")"
                //" INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=8 and PARAM_VALUE_ID=" + lifeCover + ")" +
                + " INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=9 and PARAM_VALUE_ID=" + COF_ID + ")";

        if (plan == 51)
        {
            sql += " INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID = 8 and PARAM_VALUE_ID = " + lifeCover + ")";
        }
        //if (policyCurrentStatus != "0" && continueLifeType != "0" && MOF == "M")
        //{
        //    sql += " INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=10 and PARAM_VALUE_ID='" + policyCurrentStatus + "') ";
        //}
        //if (policyCurrentStatus != "0" && continueLifeType != "0")
        //{
        //    sql += " INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=10 and PARAM_VALUE_ID='" + policyCurrentStatus + "') ";
        //}
        if (policyCurrentStatus != "0")
        {
            sql += " INTERSECT select DISTINCT(RULE_ID)  from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=10 and PARAM_VALUE_ID in ('" + policyCurrentStatus + "','0')) ";
        }

        if (MOF == "M")
        {
            sql += " INTERSECT select DISTINCT(RULE_ID) from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=11 and PARAM_VALUE_ID='" + continueLifeType + "') ";
        }
        //sql += " INTERSECT select DISTINCT(RULE_ID) from lclm.DTH_REQUIREMENT_RULE where (PARAM_ID=11 and PARAM_VALUE_ID='" + continueLifeType + "') ";

        sql += " INTERSECT SELECT DTH_RULE_ID FROM LCLM.DTH_RULE WHERE IS_DELETED=0 ";

        return sql;
    }



    public int getPolicyStatus(DataManager dthReqObj,int polno)
    {
        int policyStatus = 0;
        int term = 0;
        int table = 0;
        int comDate = 0;
        int mod = 0;
        int maxdue = 0;
        int exitDue = 0;
        string status = "";
        int paidup = 0;
        DateTime nextDue = new DateTime();

        string polst = "";
        int doddth = 0;

        string sql1 = "select DPOLST,ddtofdth from LPHS.dthint where dpolno='" + polno+"'";
        if (dthReqObj.existRecored(sql1) != 0)
        {
            dthReqObj.readSql(sql1);
            OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader1.Read())
            {
                if (!reader1.IsDBNull(0)) { polst = reader1.GetString(0); }
                if (!reader1.IsDBNull(1)) { doddth = reader1.GetInt32(1); }
            }
            reader1.Close();

            if (polst == "I")
            {
                policyStatus = 1;
            }
            else if (polst == "L")
            {
                policyStatus = 2;
                string sql2 = "select lpcom,lptrm,lptbl,lpmod from LPHS.LIFLAPS where LPPOL= " + polno;
                if (dthReqObj.existRecored(sql2) != 0)
                {
                    dthReqObj.readSql(sql2);
                    OracleDataReader reader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader2.Read())
                    {
                        if (!reader2.IsDBNull(0)) { comDate = reader2.GetInt32(0); }
                        if (!reader2.IsDBNull(1)) { term = reader2.GetInt32(1); }
                        if (!reader2.IsDBNull(2)) { table = reader2.GetInt32(2); }
                        if (!reader2.IsDBNull(3)) { mod = reader2.GetInt32(3); }
                    }
                    string sql3 = "select max(LLDUE) from LCLM.LEDGER where LLPOL= " + polno + " and LLDAT <= '" + doddth + "'";
                    if (dthReqObj.existRecored(sql3) != 0)
                    {
                        dthReqObj.readSql(sql3);
                        OracleDataReader reader3 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader3.Read())
                        {
                            if (!reader3.IsDBNull(0)) { maxdue = reader3.GetInt32(0); }
                        }
                        if (maxdue > 0)
                        {
                            DateTime dt = DateTime.Parse(maxdue.ToString().Substring(0, 4) + "/" + maxdue.ToString().Substring(4, 2) + "/" + "01");
                            if (mod == 1)
                            {
                                nextDue = dt.AddMonths(12);
                            }
                            else if (mod == 2)
                            {
                                nextDue = dt.AddMonths(6);
                            }
                            else if (mod == 3)
                            {
                                nextDue = dt.AddMonths(3);
                            }
                            else
                            {
                                nextDue = dt.AddMonths(1);
                            }
                            exitDue = int.Parse(nextDue.ToString("yyyyMMdd").Substring(0, 6));

                            paidup = isPaidup(term, comDate, exitDue, table);


                            if (paidup == 1)
                            {
                                policyStatus = 3;
                            }
                            else
                            {
                                policyStatus = 2;
                            }
                        }
                        else
                        {
                            policyStatus = 2;
                        }
                        reader3.Close();


                    }
                    else
                    {
                        policyStatus = 2;
                    }
                    reader2.Close();

                }
                else
                {
                    string sql4 = "select PHSTA from LPHS.lpolhis where phpol= " + polno;
                    if (dthReqObj.existRecored(sql4) != 0)
                    {
                        dthReqObj.readSql(sql4);
                        OracleDataReader reader4 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader4.Read())
                        {
                            if (!reader4.IsDBNull(0)) { status = reader4.GetString(0); }
                        }

                        if (status == "I")
                        {
                            policyStatus = 1;
                        }
                        else
                        {
                            string sql5 = "select phcom,phtrm,phtbl,phmod from LPHS.lpolhis where phPOL= " + polno;
                            if (dthReqObj.existRecored(sql5) != 0)
                            {
                                dthReqObj.readSql(sql5);
                                OracleDataReader reader5 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                while (reader5.Read())
                                {
                                    if (!reader5.IsDBNull(0)) { comDate = reader5.GetInt32(0); }
                                    if (!reader5.IsDBNull(1)) { term = reader5.GetInt32(1); }
                                    if (!reader5.IsDBNull(2)) { table = reader5.GetInt32(2); }
                                    if (!reader5.IsDBNull(3)) { mod = reader5.GetInt32(3); }
                                }

                                string sql6 = "select max(LLDUE) from LCLM.LEDGER where LLPOL= " + polno;
                                if (dthReqObj.existRecored(sql6) != 0)
                                {
                                    dthReqObj.readSql(sql6);
                                    OracleDataReader reader6 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                    while (reader6.Read())
                                    {
                                        if (!reader6.IsDBNull(0)) { maxdue = reader6.GetInt32(0); }

                                    }
                                    if (maxdue > 0)
                                    {
                                        DateTime dt = DateTime.Parse(maxdue.ToString().Substring(0, 4) + "/" + maxdue.ToString().Substring(4, 2) + "/" + "01");
                                        if (mod == 1)
                                        {
                                            nextDue = dt.AddMonths(12);
                                        }
                                        else if (mod == 2)
                                        {
                                            nextDue = dt.AddMonths(6);
                                        }
                                        else if (mod == 3)
                                        {
                                            nextDue = dt.AddMonths(3);
                                        }
                                        else
                                        {
                                            nextDue = dt.AddMonths(1);
                                        }
                                        exitDue = int.Parse(nextDue.ToString("yyyyMMdd").Substring(0, 6));

                                        paidup = isPaidup(term, comDate, exitDue, table);

                                        if (paidup == 1)
                                        {
                                            policyStatus = 3;
                                        }
                                        else
                                        {
                                            policyStatus = 2;
                                        }
                                    }
                                    else
                                    {
                                        policyStatus = 2;
                                    }
                                    reader6.Close();
                                }
                                else
                                {
                                    policyStatus = 2;
                                }

                                reader5.Close();

                            }
                        }
                    }
                }
            }

        }
        return policyStatus;
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
        else if (table == 45 || table == 57)
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


    public int getLifeType(string mof)
    {
        int lifeType = 0;
        string MOF = mof;
        if (MOF == "M")
        {
            lifeType = 1;
        }
        else if (MOF == "S")
        {
            lifeType = 2;
        }

        else if (MOF == "2")
        {
            lifeType = 3;
        }
        else if (MOF == "C")
        {
            lifeType = 4;
        }
        return lifeType;
    }

    public List<int> getCovers(DataManager dthReqObj,int polno)
    {
        List<int> rCovers = new List<int>();
        string sql3 = "select rcovr from LUND.RCOVER where rpol= " + polno;
        if (dthReqObj.existRecored(sql3) != 0)
        {
            dthReqObj.readSql(sql3);
            OracleDataReader reader3 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader3.Read())
            {
                if (!reader3.IsDBNull(0)) { rCovers.Add(reader3.GetInt32(0)); }
            }
            reader3.Close();
        }

        return rCovers;
    }


    

    public List<string> getNotices(int polno, string MOF,DataManager dthReqObj,string lang)
    {
        List<string> notecedescList = new List<string>();
        List<int> noticelist = new List<int>();

        int lifeType = 0;
        int policyStatus = 0;
        //int ruleId = 0;
        List<int> ruleList = new List<int>();
        bool validRule = false;

        //get policy states
        policyStatus = this.getPolicyStatus(dthReqObj, polno);
        //get life type
        lifeType = this.getLifeType(MOF);
        //get ridercovers
        List<int> rCovers = this.getCovers(dthReqObj, polno);
        //check valid rules
        string sql5 = this.GetValidRuleSql(policyStatus, lifeType, polno, MOF, dthReqObj);
        bool Is_ReInsure = false;
        Is_ReInsure = this.isReAssign(dthReqObj, polno, MOF);

        if (dthReqObj.existRecored(sql5) != 0)
        {
            dthReqObj.readSql(sql5);
            OracleDataReader reader5 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader5.Read())
            {
                if (!reader5.IsDBNull(0)) { ruleList.Add(reader5.GetInt32(0)); }
            }
            reader5.Close();

            foreach(int ruleId in ruleList)
            {
                validRule = false;
                if (this.IsRuleWithRiders(dthReqObj, ruleId))
                {
                    foreach (int coverId in rCovers)
                    {
                        string sql6 = "select rule_id from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=6 and PARAM_VALUE_ID=" + coverId + " and RULE_ID=" + ruleId;
                        if (dthReqObj.existRecored(sql6) != 0)
                        {
                            validRule = true;
                        }
                        //else
                        //{
                        //    validRule = false;
                        //    break;
                        //}
                    }
                }
                else
                {
                    validRule = true;
                }
                if (validRule)
                {
                    string langColumn = "DESCRIPTION_EN";
                    if(lang == "en")
                    {
                        langColumn = "DESCRIPTION_EN";
                    }else if (lang == "si")
                    {
                        langColumn = "DESCRIPTION_SI";
                    }else if (lang == "tm")
                    {
                        langColumn = "DESCRIPTION_TM";
                    }
                    string sql8 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=3 and RULE_ID = " + ruleId
                        + "AND PARAM_VALUE_ID IN (SELECT NOTICE_ID FROM LCLM.DTH_NOTICES WHERE IS_DELETED = 0)";
                    if (dthReqObj.existRecored(sql8) != 0)
                    {
                        dthReqObj.readSql(sql8);
                        OracleDataReader reader8 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        int noticeid = 0;
                        int row = 0;
                        
                        while (reader8.Read())
                        {

                            if (!reader8.IsDBNull(0))
                            {
                                if (!noticelist.Contains(reader8.GetInt32(0)))
                                {
                                    row++;
                                    noticelist.Add(reader8.GetInt32(0));
                                    noticeid = reader8.GetInt32(0);
                                    if(noticeid == 8 && Is_ReInsure)
                                    {

                                    }
                                    else
                                    {
                                        string noticeSelect = "select " + langColumn + " FROM LCLM.DTH_NOTICES WHERE NOTICE_ID=" + noticeid + "  ";
                                        dthReqObj.readSql(noticeSelect);
                                        OracleDataReader noticeReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                                        string notecedesc = "";
                                        while (noticeReader.Read())
                                        {
                                            if (!noticeReader.IsDBNull(0)) { notecedesc = noticeReader.GetString(0); }
                                            notecedesc = notecedesc.Replace("<", "&lt;");
                                            notecedesc = notecedesc.Replace(">", "&gt;");
                                            notecedescList.Add(notecedesc);
                                        }
                                    }
                                    
                                }
                            }



                            //noticeReader.Close();
                            //noticeReader.Dispose();
                        }

                    }
                }
            }
        }

        return notecedescList;
    }


    public bool IsRuleWithRiders(DataManager dthReqObj, int ruleid)
    {
        bool IsRuleWithRiders = false;
        string sql3 = "select * from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=6 and RULE_ID='"+ruleid+"'";
        if (dthReqObj.existRecored(sql3) != 0)
        {
            dthReqObj.readSql(sql3);
            OracleDataReader reader3 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader3.Read())
            {
                IsRuleWithRiders = true;
            }
            reader3.Close();
        }

        return IsRuleWithRiders;
    }


    public bool isReAssign(DataManager dthReqObj, int polno,string MOF)
    {
        bool IsReInsure = false;

        string reinsure = "";
        //string sql1 = "select DRRINSYN from LPHS.dthref where drpolno='" + polno + "' and drmos='"+MOF+"'";
        string sql1 = "select * from LUND.assignee where policy_no='"+polno+"'";
        if (dthReqObj.existRecored(sql1) != 0)
        {
            dthReqObj.readSql(sql1);
            OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader1.Read())
            {
                //if (!reader1.IsDBNull(0)) { reinsure = reader1.GetString(0); }
                reinsure = "Y";
            }
            reader1.Close();

            if (reinsure == "Y")
            {
                IsReInsure = true;
            }
        }
        return IsReInsure;
    }


    //TASK:32340
    //public int getPolicyStatus()
    //{
    //    int policyStatus = 0;
    //    int term = 0;
    //    int table = 0;
    //    int comDate = 0;
    //    int mod = 0;
    //    int maxdue = 0;
    //    int exitDue = 0;
    //    string status = "";
    //    int paidup = 0;
    //    DateTime nextDue = new DateTime();
    //    dthReqObj = new DataManager();

    //    string sql1 = "select * from lphs.premast where PMPOL= " + polno;
    //    if (dthReqObj.existRecored(sql1) != 0)
    //    {
    //        policyStatus = 1;
    //    }
    //    else
    //    {
    //        string sql2 = "select lpcom,lptrm,lptbl,lpmod from LPHS.LIFLAPS where LPPOL= " + polno;
    //        if (dthReqObj.existRecored(sql2) != 0)
    //        {
    //            dthReqObj.readSql(sql2);
    //            OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //            while (reader1.Read())
    //            {
    //                if (!reader1.IsDBNull(0)) { comDate = reader1.GetInt32(0); }
    //                if (!reader1.IsDBNull(1)) { term = reader1.GetInt32(1); }
    //                if (!reader1.IsDBNull(2)) { table = reader1.GetInt32(2); }
    //                if (!reader1.IsDBNull(3)) { mod = reader1.GetInt32(3); }
    //            }
    //            string sql3 = "select max(LLDUE) from LCLM.LEDGER where LLPOL= " + polno;
    //            if (dthReqObj.existRecored(sql3) != 0)
    //            {
    //                dthReqObj.readSql(sql3);
    //                OracleDataReader reader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                while (reader2.Read())
    //                {
    //                    if (!reader2.IsDBNull(0)) { maxdue = reader2.GetInt32(0); }
    //                }
    //                if (maxdue > 0)
    //                {
    //                    DateTime dt = DateTime.Parse(maxdue.ToString().Substring(0, 4) + "/" + maxdue.ToString().Substring(4, 2) + "/" + "01");
    //                    if (mod == 1)
    //                    {
    //                        nextDue = dt.AddMonths(12);
    //                    }
    //                    else if (mod == 2)
    //                    {
    //                        nextDue = dt.AddMonths(6);
    //                    }
    //                    else if (mod == 3)
    //                    {
    //                        nextDue = dt.AddMonths(3);
    //                    }
    //                    else
    //                    {
    //                        nextDue = dt.AddMonths(1);
    //                    }
    //                    exitDue = int.Parse(nextDue.ToString("yyyyMMdd").Substring(0, 6));

    //                    paidup = isPaidup(term, comDate, exitDue, table);

    //                    //    using (OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]))
    //                    //    {
    //                    //        OracleCommand command = new OracleCommand();
    //                    //        OracleDataReader dr = null;

    //                    //        command.Connection = connection;
    //                    //        command.CommandText = "VALUATION.VMEX.IS_PAIDUP";
    //                    //        command.CommandType = CommandType.StoredProcedure;
    //                    //        command.Parameters.AddWithValue("p_trm", term);
    //                    //        command.Parameters.AddWithValue("p_com", comDate);
    //                    //        command.Parameters.AddWithValue("p_exitdue", exitDue);
    //                    //        command.Parameters.AddWithValue("p_tbl", table);

    //                    //        OracleParameter paramCursor = new OracleParameter("selectData", OracleType.Cursor);
    //                    //        paramCursor.Direction = ParameterDirection.Output;
    //                    //        command.Parameters.Add(paramCursor);

    //                    //        connection.Open();
    //                    //        //dthReqObj = new DataManager();
    //                    //        dr = command.ExecuteReader();
    //                    //        if (dr.HasRows)
    //                    //        {
    //                    //            while (dr.Read())
    //                    //            {
    //                    //                if (!dr.IsDBNull(0)) { paidup = dr.GetInt32(0); } else { paidup = 0; }
    //                    //            }
    //                    //        }
    //                    //    }
    //                    if (paidup == 1)
    //                    {
    //                        policyStatus = 3;
    //                    }
    //                    else
    //                    {
    //                        policyStatus = 2;
    //                    }
    //                }
    //                else
    //                {
    //                    policyStatus = 2;
    //                }
    //                reader2.Close();


    //            }
    //            else
    //            {
    //                policyStatus = 2;
    //            }
    //            reader1.Close();

    //        }
    //        else
    //        {
    //            string sql4 = "select PHSTA from LPHS.lpolhis where phpol= " + polno;
    //            if (dthReqObj.existRecored(sql4) != 0)
    //            {
    //                dthReqObj.readSql(sql4);
    //                OracleDataReader reader4 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                while (reader4.Read())
    //                {
    //                    if (!reader4.IsDBNull(0)) { status = reader4.GetString(0); }
    //                }

    //                if (status == "I")
    //                {
    //                    policyStatus = 1;
    //                }

    //                else
    //                {
    //                    string sql5 = "select phcom,phtrm,phtbl,phmod from LPHS.lpolhis where phPOL= " + polno;
    //                    if (dthReqObj.existRecored(sql5) != 0)
    //                    {
    //                        dthReqObj.readSql(sql5);
    //                        OracleDataReader reader5 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                        while (reader5.Read())
    //                        {
    //                            if (!reader5.IsDBNull(0)) { comDate = reader5.GetInt32(0); }
    //                            if (!reader5.IsDBNull(1)) { term = reader5.GetInt32(1); }
    //                            if (!reader5.IsDBNull(2)) { table = reader5.GetInt32(2); }
    //                            if (!reader5.IsDBNull(3)) { mod = reader5.GetInt32(3); }
    //                        }

    //                        string sql6 = "select max(LLDUE) from LCLM.LEDGER where LLPOL= " + polno;
    //                        if (dthReqObj.existRecored(sql6) != 0)
    //                        {
    //                            dthReqObj.readSql(sql6);
    //                            OracleDataReader reader6 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                            while (reader6.Read())
    //                            {
    //                                if (!reader6.IsDBNull(0)) { maxdue = reader6.GetInt32(0); }

    //                            }
    //                            if (maxdue > 0)
    //                            {
    //                                DateTime dt = DateTime.Parse(maxdue.ToString().Substring(0, 4) + "/" + maxdue.ToString().Substring(4, 2) + "/" + "01");
    //                                if (mod == 1)
    //                                {
    //                                    nextDue = dt.AddMonths(12);
    //                                }
    //                                else if (mod == 2)
    //                                {
    //                                    nextDue = dt.AddMonths(6);
    //                                }
    //                                else if (mod == 3)
    //                                {
    //                                    nextDue = dt.AddMonths(3);
    //                                }
    //                                else
    //                                {
    //                                    nextDue = dt.AddMonths(1);
    //                                }
    //                                exitDue = int.Parse(nextDue.ToString("yyyyMMdd").Substring(0, 6));

    //                                paidup = isPaidup(term, comDate, exitDue, table);


    //                                //    dthReqObj = new DataManager();
    //                                //    using (OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]))
    //                                //    {

    //                                //        OracleCommand command = new OracleCommand();
    //                                //        OracleDataReader dr = null;

    //                                //        //command.Connection = connection;
    //                                //        command.CommandText = "VALUATION.VMEX.IS_PAIDUP";
    //                                //        command.CommandType = CommandType.StoredProcedure;
    //                                //        command.Parameters.AddWithValue("p_trm", term);
    //                                //        command.Parameters.AddWithValue("p_com", comDate);
    //                                //        command.Parameters.AddWithValue("p_exitdue", exitDue);
    //                                //        command.Parameters.AddWithValue("p_tbl", table);

    //                                //        OracleParameter paramCursor = new OracleParameter("selectData", OracleType.Cursor);
    //                                //        paramCursor.Direction = ParameterDirection.Output;
    //                                //        command.Parameters.Add(paramCursor);

    //                                //        connection.Open();
    //                                //        //dthReqObj = new DataManager();
    //                                //        dr = command.ExecuteReader();
    //                                //        if (dr.HasRows)
    //                                //        {
    //                                //            while (dr.Read())
    //                                //            {
    //                                //                if (!dr.IsDBNull(0)) { paidup = dr.GetInt32(0); } else { paidup = 0; }
    //                                //            }
    //                                //        }
    //                                //    }
    //                                if (paidup == 1)
    //                                {
    //                                    policyStatus = 3;
    //                                }
    //                                else
    //                                {
    //                                    policyStatus = 2;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                policyStatus = 2;
    //                            }
    //                            reader6.Close();
    //                        }
    //                        else
    //                        {
    //                            policyStatus = 2;
    //                        }

    //                        reader5.Close();

    //                    }
    //                }
    //            }
    //        }

    //    }

    //    return policyStatus;
    //}


    ////get requirments
    //public void checkRequirments()
    //{
    //    try
    //    {
    //        int lifeType = 0;
    //        int policyStatus = 0;
    //        int plan = 0;
    //        if (polno == 0)
    //        {
    //            polno = this.PreviousPage.Polno;
    //        }
    //        if (MOF == "")
    //        {
    //            MOF = this.PreviousPage.mos;
    //        }

    //        string ageProof = "";
    //        int ageAdmitted = 0;
    //        int ruleId = 0;
    //        bool validRule = false;

    //        string COF = "";
    //        int COF_ID = 0;

    //        dthReqObj = new DataManager();

    //        AutoReq autoReq = new AutoReq();

    //        //get policy states
    //        policyStatus = autoReq.getPolicyStatus(dthReqObj, polno);
    //        //get life type
    //        lifeType = autoReq.getLifeType(MOF);

    //        //get planid
    //        if (policyStatus == 1)
    //        {
    //            string sql1 = "select pmtbl from lphs.premast where PMPOL= " + polno;
    //            if (dthReqObj.existRecored(sql1) != 0)
    //            {
    //                dthReqObj.readSql(sql1);
    //                OracleDataReader reader1 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                while (reader1.Read())
    //                {
    //                    if (!reader1.IsDBNull(0)) { plan = reader1.GetInt32(0); }
    //                }
    //                reader1.Close();
    //            }
    //            else
    //            {
    //                string sql = "select phtbl from LPHS.lpolhis where phPOL=" + polno;
    //                if (dthReqObj.existRecored(sql) != 0)
    //                {
    //                    dthReqObj.readSql(sql);
    //                    OracleDataReader reader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                    while (reader.Read())
    //                    {
    //                        if (!reader.IsDBNull(0)) { plan = reader.GetInt32(0); }
    //                    }
    //                    reader.Close();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            string sql2 = "select lptbl from LPHS.LIFLAPS where LPPOL= " + polno;
    //            if (dthReqObj.existRecored(sql2) != 0)
    //            {
    //                dthReqObj.readSql(sql2);
    //                OracleDataReader reader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                while (reader2.Read())
    //                {
    //                    if (!reader2.IsDBNull(0)) { plan = reader2.GetInt32(0); }
    //                }
    //                reader2.Close();
    //            }
    //            else
    //            {
    //                string sql = "select phtbl from LPHS.lpolhis where phPOL=" + polno;
    //                if (dthReqObj.existRecored(sql) != 0)
    //                {
    //                    dthReqObj.readSql(sql);
    //                    OracleDataReader reader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
    //                    while (reader.Read())
    //                    {
    //                        if (!reader.IsDBNull(0)) { plan = reader.GetInt32(0); }
    //                    }
    //                    reader.Close();
    //                }
    //            }
    //        }

    //        List<int> rCovers = autoReq.getCovers(dthReqObj, polno);

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

}
