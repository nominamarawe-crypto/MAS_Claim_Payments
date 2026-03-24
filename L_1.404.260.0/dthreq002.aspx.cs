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
using System.Net;
using System.Web.Configuration;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Odbc;



public partial class dthreq002 : System.Web.UI.Page
{
    private int polno;
    private string MOF;
    //private string errdesc = "";


    public List<int> rule = new List<int>();
    public List<int> noticeId = new List<int>();
    //automation death claim-task 32340
    public List<int> checkedReq = new List<int>();
    public string alreadyReceivedRemark;
    public string notice;
    public ArrayList checkedReqList = new ArrayList();
    List<string> noticeNameList = new List<string>();

    public int polno1;
    public string MOF1;
    public bool assigneeflag;
    private string EPF;
    DatabaseAccessLayer dal = new DatabaseTransactionLayer();
    public bool SignatureDisplay;

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

    private int req;
    private string phname;

    private int reqcode;
    private string remarks;
    private int sentDate;
    private int recievedDate;
    private string systemType;

    protected ArrayList arr;
    protected ArrayList arr2;
    DataManager dthReqObj;
    string LettType = "O";
    private List<int> _rule;
    private List<int> _noticeId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            EPF = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        lblsuccess.Text = "";
        if (PreviousPage != null) //&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mos;

            polno1 = polno;
            MOF1 = MOF;
        }
        dthReqObj = new DataManager();
        if (!Page.IsPostBack)
        {

            #region Check the Policy has old Requiremnts posted  2008-06-27 Changed

            bool existflag = false;
            string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "'  ";
            dthReqObj.readSql(dreqSelect);
            OracleDataReader dreqreader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dreqreader.Read())
            {
                existflag = true;
            }
            dreqreader.Close();
            dthReqObj.connClose();
            if (existflag == true)
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
                Button12.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button12.Enabled = false;

            }
            #endregion


            dthReqObj = new DataManager();
            try
            {

                string dthrefSelect = "select drpolno from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' ";
                if (dthReqObj.existRecored(dthrefSelect) == 0) { throw new Exception("No Details in Death Reference File! Details not Registered."); }

                string dthrefSelect2 = "select drpolno from lphs.dthref where drpolno=" + polno + " and drmos='" + MOF + "' and (drassigneenom  =  'Y'  or payee  = 'ASI')";
                if (dthReqObj.existRecored(dthrefSelect2) == 0) { assigneeflag = false; } else { assigneeflag = true; }


                // ************** PHNAME  ************************
                #region
                string sql = "select  pnsta, pnint, LPHS.PHNAME.PNSUR, phname.pnad1, phname.pnad2, phname.pnad3, phname.pnad4  from LPHS.PHNAME where pnpol='" + polno + "'";
                dthReqObj.readSql(sql);
                OracleDataReader oraDtReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (oraDtReader.Read())
                {
                    if (!oraDtReader.IsDBNull(0)) { phname = oraDtReader.GetString(0); }
                    if (!oraDtReader.IsDBNull(1)) { phname += " " + oraDtReader.GetString(1); }
                    if (!oraDtReader.IsDBNull(2)) { phname += " " + oraDtReader.GetString(2); }
                    //+ " " + oraDtReader.GetString(1) + " " + oraDtReader.GetString(2);

                }
                oraDtReader.Close();
                oraDtReader.Dispose();
                this.lblnameofins.Text = phname;

                #endregion
                //------------------------------------------------
                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblMOS.Text = "MAIN LIFE"; } else if (MOF.Equals("S")) { this.lblMOS.Text = "SPOUCE"; } else { this.lblMOS.Text = "SECOND LIFE"; }

                #region //-------- Sent Requirements ------
                ArrayList arr2 = new ArrayList();
                ArrayList arr3 = new ArrayList();
                int rowNum = 1;
                int rowNum2 = 1;
                string dreqSelectCheck = "select drcovtyp, drrema, DRSENTDT, DRRECDT, SYSTEM_TYPE from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0 and SYSTEM_TYPE='D'";
                if (dthReqObj.existRecored(dreqSelectCheck) == 0)
                {
                    getRequirmments();
                }
                //string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0  ";
                string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT, DRRECDT, SYSTEM_TYPE from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0 ";
                if (dthReqObj.existRecored(dreqSelect2) != 0)
                {
                    dthReqObj.readSql(dreqSelect2);
                    OracleDataReader dreqreader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader2.Read())
                    {
                        if (!dreqreader2.IsDBNull(0)) { reqcode = dreqreader2.GetInt32(0); } else { reqcode = 0; }
                        if (!dreqreader2.IsDBNull(2)) { sentDate = dreqreader2.GetInt32(2); } else { sentDate = 0; }
                        if (!dreqreader2.IsDBNull(1)) { remarks = dreqreader2.GetString(1); } else { remarks = ""; }
                        if (!dreqreader2.IsDBNull(3)) { recievedDate = dreqreader2.GetInt32(3); } else { recievedDate = 0; }
                        if (!dreqreader2.IsDBNull(4)) { systemType = dreqreader2.GetString(4); } else { systemType = ""; }

                        if (reqcode != 24)
                        {
                            if (systemType == "D" && recievedDate == 0)
                            {
                                arr2.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks, LettType));
                                rowNum++;
                            }

                            if (systemType == "D" && recievedDate > 0)
                            {
                                arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                                rowNum2++;
                            }
                        }
                        //else if (systemType == "T" && recievedDate == 0)
                        //{
                        //    arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                        //    rowNum2++;
                        //}

                        //----------------Editted By Dushan--------
                        if (GridView1.Rows.Count >= reqcode && systemType == "D")
                        {
                            if (recievedDate == 0)
                            {
                                for (int i = 0; i < GridView1.Rows.Count; i++)
                                {
                                    if (reqcode == int.Parse(GridView1.Rows[i].Cells[1].Text))
                                    {
                                        CheckBox cb = new CheckBox();
                                        cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                                        cb.Checked = true;
                                    }
                                }
                                //CheckBox cb = new CheckBox();
                                //cb = (CheckBox)GridView1.Rows[reqcode - 1].Cells[0].FindControl("ch");
                                //cb.Checked = true;
                            }
                        }
                    }
                    dreqreader2.Close();
                    dreqreader2.Dispose();

                    int mostype = 0;
                    if (MOF == "M") { mostype = 1; } else if (MOF == "S") { mostype = 2; } else if (MOF == "2") { mostype = 3; } else if (MOF == "C") { mostype = 4; }

                    string dreqSelect3 = "select distinct(to_number(DC_DOCCODE)), REMARKS, to_number(to_char(ENRTYDATE,'yyyyMMdd')) as sendDt, to_number(to_char(ACCPTDATE,'yyyyMMdd')) as recDt, 'T' as sys_type from LPHS.DCT_DOCCOLLECT where DC_POLNO=" + polno + " and DC_LIFETYPE=" + mostype + " and DC_DOCCODE not like 'OT%'";
                    if (dthReqObj.existRecored(dreqSelect3) != 0)
                    {
                        dthReqObj.readSql(dreqSelect3);
                        OracleDataReader dreqreader3 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dreqreader3.Read())
                        {
                            if (!dreqreader3.IsDBNull(0)) { reqcode = dreqreader3.GetInt32(0); } else { reqcode = 0; }
                            if (!dreqreader3.IsDBNull(2)) { sentDate = dreqreader3.GetInt32(2); } else { sentDate = 0; }
                            if (!dreqreader3.IsDBNull(1)) { remarks = dreqreader3.GetString(1); } else { remarks = ""; }
                            if (!dreqreader3.IsDBNull(3)) { recievedDate = dreqreader3.GetInt32(3); } else { recievedDate = 0; }
                            if (!dreqreader3.IsDBNull(4)) { systemType = dreqreader3.GetString(4); } else { systemType = ""; }



                            if (reqcode != 24)
                            {
                                if (systemType == "T" && recievedDate == 0)
                                {
                                    arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                                    rowNum2++;
                                }
                            }
                        }
                        dreqreader3.Close();
                        dreqreader3.Dispose();
                    }

                    int count = 0;
                    int count2 = 0;
                    foreach (reminderDocset reqObj in arr2)
                    {
                        count++;
                        createReqDescTable(count.ToString(), reqObj.Reqdesc, (count - 1));
                    }

                    foreach (reminderDocset reqObj in arr3)
                    {
                        count2++;
                        createClollectedReqDescTable(count2.ToString(), reqObj.Reqdesc, (count2 - 1));
                    }

                    if (arr2.Count > 0)
                    {
                        pnlSentReq.Visible = true;
                    }

                    if (arr3.Count > 0)
                    {
                        pnlCollected.Visible = true;
                    }
                }
                else
                {
                    //checkRequirments();
                    //getRequirmments();
                }

                #endregion

                dthReqObj.connclose();

                //----------------------
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["req"] = req;
                ViewState["reqcode"] = reqcode;
                ViewState["arr"] = arr;
                ViewState["arr2"] = arr2;
                ViewState["assigneeflag"] = assigneeflag;



            }
            catch (Exception ex)
            {
                dthReqObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            polno1 = polno;
            MOF1 = MOF;

            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }

            if (ViewState["req"] != null) { req = int.Parse(ViewState["req"].ToString()); }
            if (ViewState["reqcode"] != null) { reqcode = int.Parse(ViewState["reqcode"].ToString()); }
            if (ViewState["arr"] != null) { arr = (ArrayList)ViewState["arr"]; }
            if (ViewState["arr2"] != null) { arr2 = (ArrayList)ViewState["arr2"]; }
            if (ViewState["assigneeflag"] != null) { assigneeflag = (bool)ViewState["assigneeflag"]; }
        }


        checkedReqList = getCheckedReqList();
        getNotices();
        grdNoticeList.DataSource = CreateDataSource();
        grdNoticeList.DataBind();

    }


    protected void btnCheckSelected_Click(object sender, EventArgs e)
    {
        getMatchingNotices();
    }

    public void getMatchingNotices()
    {
        try
        {
            int lifeType = 0;
            int policyStatus = 0;

            if (polno == 0)
            {
                polno = this.PreviousPage.Polno;
            }
            if (MOF == "")
            {
                MOF = this.PreviousPage.mos;
            }

            int ruleId = 0;
            bool validRule = false;
            dthReqObj = new DataManager();

            AutoReq autoReq = new AutoReq();

            //get policy states
            policyStatus = autoReq.getPolicyStatus(dthReqObj, polno);
            //get life type
            lifeType = autoReq.getLifeType(MOF);

            //get ridercovers
            List<int> rCovers = autoReq.getCovers(dthReqObj, polno);


            //check valid rules

            string sql5 = autoReq.GetValidRuleSql(policyStatus, lifeType, polno, MOF, dthReqObj);

            if (dthReqObj.existRecored(sql5) != 0)
            {
                dthReqObj.readSql(sql5);
                OracleDataReader reader5 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader5.Read())
                {
                    if (!reader5.IsDBNull(0)) { ruleId = reader5.GetInt32(0); }

                    if (autoReq.IsRuleWithRiders(dthReqObj, ruleId))
                    {
                        validRule = false;
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
                        //string sql7 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=2 and RULE_ID = " + ruleId;
                        //if (dthReqObj.existRecored(sql7) != 0)
                        //{
                        //    dthReqObj.readSql(sql7);
                        //    OracleDataReader reader7 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        //    while (reader7.Read())
                        //    {
                        //        //if (!reader7.IsDBNull(0)) { rule.Add(reader7.GetInt32(0)); }
                        //        if (!reader7.IsDBNull(0)) { rule.Add(reader7.GetInt32(0)); }
                        //    }
                        //    //reader7.Close();


                        //}
                        string sql8 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=3 and RULE_ID = " + ruleId
                            + "AND PARAM_VALUE_ID IN (SELECT NOTICE_ID FROM LCLM.DTH_NOTICES WHERE IS_DELETED = 0)";
                        if (dthReqObj.existRecored(sql8) != 0)
                        {
                            dthReqObj.readSql(sql8);
                            OracleDataReader reader8 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader8.Read())
                            {
                                if (!reader8.IsDBNull(0))
                                {
                                    if (!noticeId.Contains(reader8.GetInt32(0)))
                                    {
                                        noticeId.Add(reader8.GetInt32(0));
                                    }
                                }
                            }
                            //reader8.Close();
                        }
                    }
                }
                reader5.Close();
            }




            ////int c = GridView1.Rows.Count;
            ////CheckBox chk = (CheckBox)GridView1.Rows[1].Cells[0].FindControl("ch");
            //string a = GridView1.Rows[1].Cells[0].Text;
            //foreach (int ruleid in rule)
            //{
            //    for (int i = 0; i < GridView1.Rows.Count; i++)
            //    {
            //        int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
            //        if (id == ruleid)
            //        {
            //            CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
            //            chk.Checked = true;
            //        }
            //    }
            //}
        }

        catch (Exception ex)
        {
            throw ex;
        }

    }



    //automation death claim-task 32340
    public void getRequirmments()
    {
        try
        {
            int lifeType = 0;
            int policyStatus = 0;
            int plan = 0;
            if (polno == 0)
            {
                polno = this.PreviousPage.Polno;
            }
            if (MOF == "")
            {
                MOF = this.PreviousPage.mos;
            }


            //int ruleId = 0;
            List<int> ruleList = new List<int>();
            bool validRule = false;
            dthReqObj = new DataManager();

            AutoReq autoReq = new AutoReq();

            //get policy states
            policyStatus = autoReq.getPolicyStatus(dthReqObj, polno);
            //get life type
            lifeType = autoReq.getLifeType(MOF);

            //get ridercovers
            List<int> rCovers = autoReq.getCovers(dthReqObj, polno);

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

            //check valid rules
            string sql5 = autoReq.GetValidRuleSql(policyStatus, lifeType, polno, MOF, dthReqObj);

            if (dthReqObj.existRecored(sql5) != 0)
            {
                dthReqObj.readSql(sql5);
                OracleDataReader reader5 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader5.Read())
                {
                    if (!reader5.IsDBNull(0)) { ruleList.Add(reader5.GetInt32(0)); }

                }
                reader5.Close();

                foreach (int ruleId in ruleList)
                {
                    validRule = false;
                    if (autoReq.IsRuleWithRiders(dthReqObj, ruleId))
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
                        string sql7 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=2 and RULE_ID = " + ruleId;
                        if (dthReqObj.existRecored(sql7) != 0)
                        {
                            dthReqObj.readSql(sql7);
                            OracleDataReader reader7 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader7.Read())
                            {
                                //if (!reader7.IsDBNull(0)) { rule.Add(reader7.GetInt32(0)); }
                                if (!reader7.IsDBNull(0)) { rule.Add(reader7.GetInt32(0)); }
                            }
                            reader7.Close();


                        }
                        string sql8 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=3 and RULE_ID = " + ruleId
                            + "AND PARAM_VALUE_ID IN (SELECT NOTICE_ID FROM LCLM.DTH_NOTICES WHERE IS_DELETED = 0)";
                        if (dthReqObj.existRecored(sql8) != 0)
                        {
                            dthReqObj.readSql(sql8);
                            OracleDataReader reader8 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader8.Read())
                            {
                                if (!reader8.IsDBNull(0))
                                {
                                    if (!noticeId.Contains(reader8.GetInt32(0)))
                                    {
                                        noticeId.Add(reader8.GetInt32(0));
                                    }
                                }
                            }
                            reader8.Close();
                        }
                    }
                }
            }
            ////int c = GridView1.Rows.Count;
            ////CheckBox chk = (CheckBox)GridView1.Rows[1].Cells[0].FindControl("ch");
            //string a = GridView1.Rows[1].Cells[0].Text;
            foreach (int ruleid in rule)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                    if (id == ruleid)
                    {
                        CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                        chk.Checked = true;
                    }
                }
            }

            if (autoReq.isReAssign(dthReqObj, polno, MOF) && ((CheckBox)GridView1.Rows[0].Cells[0].FindControl("ch")).Checked)
            {
                ((CheckBox)GridView1.Rows[0].Cells[0].FindControl("ch")).Checked = false;
                ((CheckBox)GridView1.Rows[1].Cells[0].FindControl("ch")).Checked = true;
                if (plan != 22)
                {
                    //Sachinda 2023.10.24 - Task 42076
                    ((CheckBox)GridView1.Rows[4].Cells[0].FindControl("ch")).Checked = false;
                    ((CheckBox)GridView1.Rows[5].Cells[0].FindControl("ch")).Checked = true;
                }

            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void getNotices()
    {
        try
        {
            int lifeType = 0;
            int policyStatus = 0;
            if (polno == 0)
            {
                polno = this.PreviousPage.Polno;
            }
            if (MOF == "")
            {
                MOF = this.PreviousPage.mos;
            }


            //int ruleId = 0;
            List<int> ruleList = new List<int>();
            bool validRule = false;
            dthReqObj = new DataManager();
            AutoReq autoReq = new AutoReq();

            //get policy states
            policyStatus = autoReq.getPolicyStatus(dthReqObj, polno);
            //get life type
            lifeType = autoReq.getLifeType(MOF);


            //get ridercovers
            List<int> rCovers = autoReq.getCovers(dthReqObj, polno);


            //check valid rules
            string sql5 = autoReq.GetValidRuleSql(policyStatus, lifeType, polno, MOF, dthReqObj);

            bool Is_ReInsure = false;
            Is_ReInsure = autoReq.isReAssign(dthReqObj, polno, MOF);


            if (dthReqObj.existRecored(sql5) != 0)
            {
                dthReqObj.readSql(sql5);
                OracleDataReader reader5 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader5.Read())
                {
                    if (!reader5.IsDBNull(0)) { ruleList.Add(reader5.GetInt32(0)); }
                }
                reader5.Close();

                foreach (int ruleId in ruleList)
                {
                    validRule = false;
                    if (autoReq.IsRuleWithRiders(dthReqObj, ruleId))
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
                        string sql7 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=2 and RULE_ID = " + ruleId;
                        if (dthReqObj.existRecored(sql7) != 0)
                        {
                            dthReqObj.readSql(sql7);
                            OracleDataReader reader7 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader7.Read())
                            {
                                //if (!reader7.IsDBNull(0)) { rule.Add(reader7.GetInt32(0)); }
                                if (!reader7.IsDBNull(0)) { rule.Add(reader7.GetInt32(0)); }
                            }
                            reader7.Close();


                        }
                        string sql8 = "select DISTINCT(PARAM_VALUE_ID) from lclm.DTH_REQUIREMENT_RULE where PARAM_ID=3 and RULE_ID = " + ruleId
                            + "AND PARAM_VALUE_ID IN (SELECT NOTICE_ID FROM LCLM.DTH_NOTICES WHERE IS_DELETED = 0)";
                        if (dthReqObj.existRecored(sql8) != 0)
                        {
                            dthReqObj.readSql(sql8);
                            OracleDataReader reader8 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader8.Read())
                            {
                                if (!reader8.IsDBNull(0))
                                {
                                    if (!noticeId.Contains(reader8.GetInt32(0)))
                                    {
                                        if (reader8.GetInt32(0) == 8 && Is_ReInsure)
                                        {

                                        }
                                        else
                                        {
                                            noticeId.Add(reader8.GetInt32(0));
                                        }

                                    }
                                }
                            }
                            reader8.Close();
                        }
                    }
                }
            }
            ////int c = GridView1.Rows.Count;
            ////CheckBox chk = (CheckBox)GridView1.Rows[1].Cells[0].FindControl("ch");
            //string a = GridView1.Rows[1].Cells[0].Text;
            //foreach (int ruleid in rule)
            //{
            //    for (int i = 0; i < GridView1.Rows.Count; i++)
            //    {
            //        int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
            //        if (id == ruleid)
            //        {
            //            CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
            //            chk.Checked = true;
            //        }
            //    }
            //}
        }

        catch (Exception ex)
        {
            throw ex;
        }

    }



    public ArrayList getCheckedReqList()
    {
        string s = "";
        string insertSQL = "";
        string updSql = "";
        int reqcode = 0;
        int maxSentDate = 0;
        int reqRecDate = 0;
        bool alreadyExistFlag = false;
        bool isSecondReminder = false;
        bool isReqAlreadyRec = false;
        dthReqObj = new DataManager();
        ArrayList RequestList = new ArrayList();

        try
        {
            #region ------ already exist flag and max sent date -----
            string dthreqFirstSelect2 = "select DRSENTDT from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' ";
            string dthreqFirstSelect = "select max(DRSENTDT) from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' ";
            if (dthReqObj.existRecored(dthreqFirstSelect2) != 0)
            {
                alreadyExistFlag = true;
                dthReqObj.readSql(dthreqFirstSelect);
                OracleDataReader dthreqFirstReder = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthreqFirstReder.Read())
                {
                    if (!dthreqFirstReder.IsDBNull(0)) { maxSentDate = dthreqFirstReder.GetInt32(0); } else { maxSentDate = 0; }
                }
                dthreqFirstReder.Close();
                dthreqFirstReder.Dispose();
            }

            #endregion

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                s = GridView1.Rows[i].Cells[1].Text;
                reqcode = int.Parse(s);



                CheckBox cb = new CheckBox();
                cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                if (cb.Checked)
                {
                    #region ----- logic for  -----
                    string dthreqSelect = "select SECONDREQUESTYN, DRRECDT from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + "  ";
                    if (dthReqObj.existRecored(dthreqSelect) != 0)
                    {
                        string SECONDREQUESTYN = "";
                        dthReqObj.readSql(dthreqSelect);
                        OracleDataReader dthreqRederrqcount = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthreqRederrqcount.Read())
                        {
                            if (!dthreqRederrqcount.IsDBNull(0)) { SECONDREQUESTYN = dthreqRederrqcount.GetString(0); } else { SECONDREQUESTYN = ""; }
                            if (!dthreqRederrqcount.IsDBNull(1)) { reqRecDate = dthreqRederrqcount.GetInt32(1); } else { reqRecDate = 0; }
                        }
                        dthreqRederrqcount.Close();
                        dthreqRederrqcount.Dispose();
                        //this.CustomValidator1.IsValid = false;
                        //this.CustomValidator1.Text = "Reqirement " + reqcode.ToString() + " Already Sent.";
                        //return;

                        if (reqRecDate > 0)
                        {
                            isReqAlreadyRec = true;
                            alreadyReceivedRemark = "Received by tracking";

                        }
                        else
                        {
                            alreadyReceivedRemark = "";
                        }

                        if (SECONDREQUESTYN == "Y")
                        {

                            alreadyReceivedRemark = "Received by tracking";

                        }
                        else
                        {
                            alreadyReceivedRemark = "";
                        }

                    }
                    //-----------------------------

                    DataManager dm = new DataManager();

                    string desc = "";
                    string dreqSelect = "select DREQDESSHORT from lphs.dreqdesc where DREQCODE=" + reqcode + "  ";
                    dm.readSql(dreqSelect);
                    OracleDataReader dreqreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader.Read())
                    {
                        if (!dreqreader.IsDBNull(0)) { desc = dreqreader.GetString(0); }
                        RequestList.Add(new SelectedReqList(reqcode, desc, alreadyReceivedRemark));

                    }
                    dreqreader.Close();
                    dreqreader.Dispose();


                    //----------------------
                    #endregion
                    isReqAlreadyRec = false;

                }

            }
        }
        catch (Exception ex)
        {
            dthReqObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        return RequestList;
    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string s = "";
        string insertSQL = "";
        string updSql = "";
        int reqcode = 0;
        int maxSentDate = 0;
        int reqRecDate = 0;
        bool alreadyExistFlag = false;
        bool isSecondReminder = false;
        bool isReqAlreadyRec = false;
        dthReqObj = new DataManager();
        try
        {
            #region ------ already exist flag and max sent date -----
            string dthreqFirstSelect2 = "select DRSENTDT from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' ";
            string dthreqFirstSelect = "select max(DRSENTDT) from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' ";
            if (dthReqObj.existRecored(dthreqFirstSelect2) != 0)
            {
                alreadyExistFlag = true;
                dthReqObj.readSql(dthreqFirstSelect);
                OracleDataReader dthreqFirstReder = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthreqFirstReder.Read())
                {
                    if (!dthreqFirstReder.IsDBNull(0)) { maxSentDate = dthreqFirstReder.GetInt32(0); } else { maxSentDate = 0; }
                }
                dthreqFirstReder.Close();
                dthreqFirstReder.Dispose();
            }
            //else { alreadyExistFlag = false; }
            #endregion



            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                s = GridView1.Rows[i].Cells[1].Text;
                reqcode = int.Parse(s);

                //string dthreqSelect2 = "select SECONDREQUESTYN from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + "  ";
                //if (dthReqObj.existRecored(dthreqSelect2) != 0)
                //{
                //    alreadyExistFlag = true;
                //}
                //else
                //{
                //    alreadyExistFlag = false;
                //}

                CheckBox cb = new CheckBox();
                cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                if (cb.Checked)
                {
                    #region ----- logic for  -----
                    string dthreqSelect = "select SECONDREQUESTYN, DRRECDT from lphs.dreq where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + "  ";
                    if (dthReqObj.existRecored(dthreqSelect) != 0)
                    {
                        string SECONDREQUESTYN = "";
                        dthReqObj.readSql(dthreqSelect);
                        OracleDataReader dthreqRederrqcount = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthreqRederrqcount.Read())
                        {
                            if (!dthreqRederrqcount.IsDBNull(0)) { SECONDREQUESTYN = dthreqRederrqcount.GetString(0); } else { SECONDREQUESTYN = ""; }
                            if (!dthreqRederrqcount.IsDBNull(1)) { reqRecDate = dthreqRederrqcount.GetInt32(1); } else { reqRecDate = 0; }
                        }
                        dthreqRederrqcount.Close();
                        dthreqRederrqcount.Dispose();
                        //this.CustomValidator1.IsValid = false;
                        //this.CustomValidator1.Text = "Reqirement " + reqcode.ToString() + " Already Sent.";
                        //return;

                        if (reqRecDate > 0)
                        {
                            isReqAlreadyRec = true;
                            alreadyReceivedRemark = "Received by tracking";

                        }
                        else
                        {
                            alreadyReceivedRemark = "";
                        }
                        if (SECONDREQUESTYN == "Y")
                        {

                            alreadyReceivedRemark = "Received by tracking";

                        }
                        else
                        {
                            alreadyReceivedRemark = "";
                        }

                        if (SECONDREQUESTYN.Equals("N") && (reqRecDate == 0 || reqRecDate == null))
                        {
                            updSql = "update LPHS.DREQ set SECONDREQUESTYN = 'Y', SECONDREQUESTDATE = " + int.Parse(this.setDate()[0]) + ", SYSTEM_TYPE='D' where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + " ";
                        }
                        else if (isReqAlreadyRec)
                        {
                            updSql = "update LPHS.DREQ set SECONDREQUESTYN = 'Y', DRRECDT = 0, SECONDREQUESTDATE=0, SYSTEM_TYPE='D' where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + " ";
                        }
                        else
                        {
                            updSql = "update LPHS.DREQ set SECONDREQUESTYN = 'N', SECONDREQUESTDATE = " + int.Parse(this.setDate()[0]) + ", SYSTEM_TYPE='D' where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + " ";
                        }
                        //else 
                        //{
                        //    updSql = "update LPHS.DREQ  set SECONDREQUESTYN = 'N' where DRPOL=" + polno + " and  DRTYP='" + MOF + "' and DRCOVTYP=" + reqcode + " ";
                        //}
                        dthReqObj.insertRecords(updSql);
                    }
                    else if (alreadyExistFlag)
                    {
                        insertSQL = "INSERT INTO LPHS.DREQ (DRPOL ,DRTYP ,DRCOVTYP ,DRSENTDT ,DRRECDT ,DRCMPLYN ,DRREMA ,DRMOO, SECONDREQUESTYN ) VALUES (" + polno + " ,'" + MOF + "' , " + reqcode + "," + int.Parse(this.setDate()[0]) + " , NULL ,'' ,'' ,'', 'Y')";
                        dthReqObj.insertRecords(insertSQL);
                    }
                    //else if ((alreadyExistFlag) && (maxSentDate != int.Parse(this.setDate()[0])))
                    //{
                    //    insertSQL = "INSERT INTO LPHS.DREQ (DRPOL ,DRTYP ,DRCOVTYP ,DRSENTDT ,DRRECDT ,DRCMPLYN ,DRREMA ,DRMOO, SECONDREQUESTYN, SECONDREQUESTDATE ) VALUES (" + polno + " ,'" + MOF + "' , " + reqcode + "," + int.Parse(this.setDate()[0]) + " , NULL ,'' ,'' ,'', 'Y' , " + int.Parse(this.setDate()[0]) + "  )";
                    //    dthReqObj.insertRecords(insertSQL);
                    //}
                    //else if ((alreadyExistFlag) && (maxSentDate == int.Parse(this.setDate()[0])))
                    //{
                    //    insertSQL = "INSERT INTO LPHS.DREQ (DRPOL ,DRTYP ,DRCOVTYP ,DRSENTDT ,DRRECDT ,DRCMPLYN ,DRREMA ,DRMOO, SECONDREQUESTYN ) VALUES (" + polno + " ,'" + MOF + "' , " + reqcode + "," + int.Parse(this.setDate()[0]) + " , NULL ,'' ,'' ,'', 'N'  )";
                    //    dthReqObj.insertRecords(insertSQL);
                    //}
                    //else if (!alreadyExistFlag && isSecondReminder)
                    //{
                    //    insertSQL = "INSERT INTO LPHS.DREQ (DRPOL ,DRTYP ,DRCOVTYP ,DRSENTDT ,DRRECDT ,DRCMPLYN ,DRREMA ,DRMOO, SECONDREQUESTYN ) VALUES (" + polno + " ,'" + MOF + "' , " + reqcode + "," + int.Parse(this.setDate()[0]) + " , NULL ,'' ,'' ,'', 'Y'  )";
                    //    dthReqObj.insertRecords(insertSQL);
                    //}
                    else if (!alreadyExistFlag)
                    {
                        insertSQL = "INSERT INTO LPHS.DREQ (DRPOL ,DRTYP ,DRCOVTYP ,DRSENTDT ,DRRECDT ,DRCMPLYN ,DRREMA ,DRMOO, SECONDREQUESTYN ) VALUES (" + polno + " ,'" + MOF + "' , " + reqcode + "," + int.Parse(this.setDate()[0]) + " , NULL ,'' ,'' ,'', 'N'  )";
                        dthReqObj.insertRecords(insertSQL);
                    }


                    #endregion
                    isReqAlreadyRec = false;
                }
            }



            #region //-------- Sent Requirements ------
            ArrayList arr2 = new ArrayList();
            ArrayList arr3 = new ArrayList();
            int rowNum = 1;
            int rowNum2 = 1;
            string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT, SYSTEM_TYPE, DRRECDT from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0";
            if (dthReqObj.existRecored(dreqSelect2) != 0)
            {
                dthReqObj.readSql(dreqSelect2);
                OracleDataReader dreqreader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader2.Read())
                {
                    if (!dreqreader2.IsDBNull(0)) { reqcode = dreqreader2.GetInt32(0); }
                    if (!dreqreader2.IsDBNull(2)) { sentDate = dreqreader2.GetInt32(2); }
                    if (!dreqreader2.IsDBNull(1)) { remarks = dreqreader2.GetString(1); }
                    if (!dreqreader2.IsDBNull(3)) { systemType = dreqreader2.GetString(3); }
                    if (!dreqreader2.IsDBNull(4)) { recievedDate = dreqreader2.GetInt32(4); } else { recievedDate = 0; }

                    if (reqcode != 24)
                    {
                        if (systemType == "D" && recievedDate == 0)
                        {
                            arr2.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks, LettType));
                            rowNum++;
                        }
                    }
                    //else if (systemType == "T" && recievedDate == 0)
                    //{
                    //    arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                    //    rowNum2++;
                    //}
                }
                dreqreader2.Close();
                dreqreader2.Dispose();

                int mostype = 0;
                if (MOF == "M") { mostype = 1; } else if (MOF == "S") { mostype = 2; } else if (MOF == "2") { mostype = 3; } else if (MOF == "C") { mostype = 4; }

                string dreqSelect3 = "select to_number(DC_DOCCODE), REMARKS, to_number(to_char(ENRTYDATE,'yyyyMMdd')) as sendDt, to_number(to_char(ACCPTDATE,'yyyyMMdd')) as recDt, 'T' as sys_type from LPHS.DCT_DOCCOLLECT where DC_POLNO=" + polno + " and DC_LIFETYPE=" + mostype + " and DC_DOCCODE not like 'OT%'";
                if (dthReqObj.existRecored(dreqSelect2) != 0)
                {
                    dthReqObj.readSql(dreqSelect3);
                    OracleDataReader dreqreader3 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader3.Read())
                    {
                        if (!dreqreader3.IsDBNull(0)) { reqcode = dreqreader3.GetInt32(0); } else { reqcode = 0; }
                        if (!dreqreader3.IsDBNull(2)) { sentDate = dreqreader3.GetInt32(2); } else { sentDate = 0; }
                        if (!dreqreader3.IsDBNull(1)) { remarks = dreqreader3.GetString(1); } else { remarks = ""; }
                        if (!dreqreader3.IsDBNull(3)) { recievedDate = dreqreader3.GetInt32(3); } else { recievedDate = 0; }
                        if (!dreqreader3.IsDBNull(4)) { systemType = dreqreader3.GetString(4); } else { systemType = ""; }

                        if (reqcode != 24)
                        {
                            if (systemType == "T" && recievedDate == 0)
                            {
                                arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                                rowNum2++;
                            }
                        }
                    }
                    dreqreader3.Close();
                    dreqreader3.Dispose();
                }

                int count = 0;
                int count2 = 0;

                foreach (reminderDocset req in arr2)
                {
                    count++;
                    createReqDescTable(count.ToString(), req.Reqdesc, (count - 1));
                }

                foreach (reminderDocset reqObj in arr3)
                {
                    count2++;
                    createClollectedReqDescTable(count2.ToString(), reqObj.Reqdesc, (count2 - 1));
                }

                if (arr2.Count > 0)
                {
                    pnlSentReq.Visible = true;
                }

                if (arr3.Count > 0)
                {
                    pnlCollected.Visible = true;
                }
            }

            #endregion

            this.lblsuccess.Visible = true;
            dthReqObj.connclose();
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button12.Enabled = true;
        }
        catch (Exception ex)
        {
            dthReqObj.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    public int Polno
    {
        get { return polno; }
        set { polno = value; }
    }
    public string mof
    {
        get { return MOF; }
        set { MOF = value; }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    private void createReqDescTable(string count, string reqDesc, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "count" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "count" + rowNumber); //Text Value
        lbl1.Text = count + ".";

        lbl2.ID = "reqDesc" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "reqDesc" + rowNumber); //Text Value
        lbl2.Text = reqDesc;
        //lbl2.Style["HORIZONTAL-ALIGN"] = "left";

        tcell1.Controls.Add(lbl1);
        tcell1.Style["VERTICAL-ALIGN"] = "top";
        tcell2.Controls.Add(lbl2);
        tcell1.Style["ALIGN"] = "left";  //HORIZONTAL-
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        Table1.Rows.Add(trow);
    }

    private void createClollectedReqDescTable(string count, string reqDesc, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "count" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "count" + rowNumber); //Text Value
        lbl1.Text = count + ".";

        lbl2.ID = "reqDesc" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "reqDesc" + rowNumber); //Text Value
        lbl2.Text = reqDesc;
        //lbl2.Style["HORIZONTAL-ALIGN"] = "left";

        tcell1.Controls.Add(lbl1);
        tcell1.Style["VERTICAL-ALIGN"] = "top";
        tcell2.Controls.Add(lbl2);
        tcell1.Style["ALIGN"] = "left";  //HORIZONTAL-
        trow.Cells.Add(tcell1);
        trow.Cells.Add(tcell2);
        Table2.Rows.Add(trow);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string reqstr;
        string secrequest;
        int reqint;
        dthReqObj = new DataManager();
        try
        {
            dthReqObj.begintransaction();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                if (cb.Checked)
                {

                    reqstr = GridView1.Rows[i].Cells[1].Text;
                    reqint = int.Parse(reqstr);
                    string reqirementsel = "select SECONDREQUESTYN from LPHS.DREQ where DRPOL=" + polno + " and DRCOVTYP=" + reqint + "";
                    if (dthReqObj.existRecored(reqirementsel) != 0)
                    {
                        dthReqObj.readSql(reqirementsel);
                        OracleDataReader dthreqreader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        dthreqreader.Read();
                        if (!dthreqreader.IsDBNull(0)) { secrequest = dthreqreader.GetString(0); } else { secrequest = ""; }
                        string reqdelinsert = "insert into LPHS.DTHREQDEL (REQCODE, POLNO, DELDATE, DELEPF, SECONDREQUESTYN) values(" + reqint + "," + polno + "," + int.Parse(this.setDate()[0]) + ", '" + EPF + "','" + secrequest + "')";
                        dthReqObj.insertRecords(reqdelinsert);
                        string deletereq = "delete from LPHS.DREQ where DRPOL=" + polno + " and DRCOVTYP=" + reqint + "";
                        dthReqObj.insertRecords(deletereq);
                        //dthreqreader.Close();
                        //dthreqreader.Dispose();
                    }
                    cb.Checked = false;
                }
            }
            dthReqObj.commit();
            Sentrequirements();
            dthReqObj.connClose();
            lblsuccess.Text = "Records Deleted!";
            lblsuccess.Visible = true;
        }
        catch (Exception Ex)
        {
            dthReqObj.rollback();
            EPage.Messege = Ex.Message;
            Response.Redirect("~/EPage.aspx");

        }
    }
    void Sentrequirements()
    {
        #region //-------- Sent Requirements ------
        ArrayList arr2 = new ArrayList();
        ArrayList arr3 = new ArrayList();
        int rowNum = 1;
        int rowNum2 = 1;
        string dreqSelect2 = "select drcovtyp, drrema, DRSENTDT, SYSTEM_TYPE, DRRECDT from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "' and DRSENTDT > 0 ";
        if (dthReqObj.existRecored(dreqSelect2) != 0)
        {
            dthReqObj.readSql(dreqSelect2);
            OracleDataReader dreqreader2 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dreqreader2.Read())
            {
                if (!dreqreader2.IsDBNull(0)) { reqcode = dreqreader2.GetInt32(0); }
                if (!dreqreader2.IsDBNull(2)) { sentDate = dreqreader2.GetInt32(2); }
                if (!dreqreader2.IsDBNull(1)) { remarks = dreqreader2.GetString(1); }
                if (!dreqreader2.IsDBNull(3)) { systemType = dreqreader2.GetString(3); }
                if (!dreqreader2.IsDBNull(4)) { recievedDate = dreqreader2.GetInt32(4); } else { recievedDate = 0; }

                if (reqcode != 24)
                {
                    if (systemType == "D" && recievedDate == 0)
                    {
                        arr2.Add(new reminderDocset(rowNum, reqcode, sentDate, remarks, LettType));
                        rowNum++;
                    }
                }
                //else if (systemType == "T" && recievedDate == 0)
                //{
                //    arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                //    rowNum2++;
                //}

                if (recievedDate == 0 && systemType == "D")
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (reqcode == int.Parse(GridView1.Rows[i].Cells[1].Text))
                        {
                            CheckBox cb = new CheckBox();
                            cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                            cb.Checked = true;
                        }
                    }
                    //CheckBox cb = new CheckBox();
                    //cb = (CheckBox)GridView1.Rows[reqcode - 1].Cells[0].FindControl("ch");
                    //cb.Checked = true;
                }
            }
            dreqreader2.Close();
            dreqreader2.Dispose();

            int mostype = 0;
            if (MOF == "M") { mostype = 1; } else if (MOF == "S") { mostype = 2; } else if (MOF == "2") { mostype = 3; } else if (MOF == "C") { mostype = 4; }

            string dreqSelect3 = "select to_number(DC_DOCCODE), REMARKS, to_number(to_char(ENRTYDATE,'yyyyMMdd')) as sendDt, to_number(to_char(ACCPTDATE,'yyyyMMdd')) as recDt, 'T' as sys_type from LPHS.DCT_DOCCOLLECT where DC_POLNO=" + polno + " and DC_LIFETYPE=" + mostype + " and DC_DOCCODE not like 'OT%'";
            if (dthReqObj.existRecored(dreqSelect2) != 0)
            {
                dthReqObj.readSql(dreqSelect3);
                OracleDataReader dreqreader3 = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader3.Read())
                {
                    if (!dreqreader3.IsDBNull(0)) { reqcode = dreqreader3.GetInt32(0); } else { reqcode = 0; }
                    if (!dreqreader3.IsDBNull(2)) { sentDate = dreqreader3.GetInt32(2); } else { sentDate = 0; }
                    if (!dreqreader3.IsDBNull(1)) { remarks = dreqreader3.GetString(1); } else { remarks = ""; }
                    if (!dreqreader3.IsDBNull(3)) { recievedDate = dreqreader3.GetInt32(3); } else { recievedDate = 0; }
                    if (!dreqreader3.IsDBNull(4)) { systemType = dreqreader3.GetString(4); } else { systemType = ""; }

                    if (reqcode != 24)
                    {
                        if (systemType == "T" && recievedDate == 0)
                        {
                            arr3.Add(new reminderDocset(rowNum2, reqcode, sentDate, remarks, LettType));
                            rowNum2++;
                        }
                    }
                }
                dreqreader3.Close();
                dreqreader3.Dispose();
            }

            int count = 0;
            int count2 = 0;
            foreach (reminderDocset req in arr2)
            {
                count++;
                createReqDescTable(count.ToString(), req.Reqdesc, (count - 1));
            }

            foreach (reminderDocset reqObj in arr3)
            {
                count2++;
                createClollectedReqDescTable(count2.ToString(), reqObj.Reqdesc, (count2 - 1));
            }

            if (arr2.Count > 0)
            {
                pnlSentReq.Visible = true;
            }

            if (arr3.Count > 0)
            {
                pnlCollected.Visible = true;
            }
        }

        #endregion
    }

    public ICollection CreateDataSource()
    {
        dthReqObj = new DataManager();

        arr = new ArrayList();
        arr2 = new ArrayList();



        foreach (int ntc in noticeId)
        {
            string noticeSelect = "select NOTICE_NAME FROM LCLM.DTH_NOTICES WHERE NOTICE_ID=" + ntc + "  ";
            dthReqObj.readSql(noticeSelect);
            OracleDataReader noticeReader = dthReqObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (noticeReader.Read())
            {

                if (!noticeReader.IsDBNull(0)) { notice = noticeReader.GetString(0); }
                noticeNameList.Add(notice);

            }
            noticeReader.Close();
            noticeReader.Dispose();
        }

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("NOTICE_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("NOTICE_NAME", typeof(string)));

        int k = 1;

        foreach (string ntcDisc in noticeNameList)
        {
            dr = dt.NewRow();
            dr[0] = k;
            dr[1] = ntcDisc;

            dt.Rows.Add(dr);
            k++;
        }

        DataView dv = new DataView(dt);
        return dv;
    }
    //public void findRule(int polno)
    //{
    //    int LifeType = getLifeType(MOF);
    //      int PolicyStatus = getPolicyStatus();

    //    if (LifeType==1&&PolicyStatus==1)
    //    {

    //    }



    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ChkSig(object sender, EventArgs e)
    {
        if (Signature.Checked)
        {
            SignatureDisplay = true;
        }
    }
}
