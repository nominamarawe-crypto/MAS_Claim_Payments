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

public partial class AdmitCoverLetter : System.Web.UI.Page
{
    private int  PolicyNo;
    private long ClaimNo;
    private  string nameofdeceased;
    private string MOF;
    private int INDEX;
    private string LANG;
    public ArrayList Address1;
    public  ArrayList AddressList1;
    public ArrayList AddressList2;
    public ArrayList AddressList3;
    public ArrayList CopyArray;
    private int AGENCY;
    private int AGENTCode;
    private string ReqType;
    private int FirSrReqDate;
    private int SecReqDate;
    private ArrayList AssuNameChng;
    private ArrayList NomineeNamChg;
    private ArrayList Ass_Nomihg;
    private ArrayList Ass_Nomihg1;
//    int reqcode = 0;
    DataManager dm;
    private  int ChechedBtn;
    private ArrayList ReqcodeList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Polno"] != null)
            {
                PolicyNo = int.Parse(Session["Polno"].ToString());
                litpolno.Text = PolicyNo.ToString();
            }
            if (Session["ClmNo"] != null)
            {
                ClaimNo = int.Parse(Session["ClmNo"].ToString());
                litclmno.Text = ClaimNo.ToString();
            }

            this.litDate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
            nameofdeceased = Session["NameDead"].ToString();
            litdthname.Text = nameofdeceased;

            if (Session["MOF"] != null)
            {
                MOF = Session["MOF"].ToString();
            }

            LANG = "E";
            Address1 = new ArrayList();
            AddressList1 = new ArrayList();
            AddressList2 = new ArrayList();
            AddressList3 = new ArrayList();
            CopyArray = new ArrayList();
            #region Load Claimnt Address
            DataManager dm = new DataManager();
            INDEX = 0;
            string nomiselect = "select nomnam, nomad1, nomad2 from lund.nominee where polno = " + PolicyNo + " ";
            if (dm.existRecored(nomiselect) != 0)
            {
                #region get Nominee name and address

                dm.readSql(nomiselect);
                OracleDataReader nomireader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (nomireader.Read())
                {
                    if (!nomireader.IsDBNull(0)) { Address1.Add(nomireader.GetString(0)); } else { Address1.Add(""); }
                    if (!nomireader.IsDBNull(1)) { Address1.Add(nomireader.GetString(1)); } else { Address1.Add(""); }
                    if (!nomireader.IsDBNull(2)) { Address1.Add(nomireader.GetString(2)); } else { Address1.Add(""); }
                    Address1.Add(""); Address1.Add(""); Address1.Add("");
                }
                nomireader.Close();
                nomireader.Dispose();

                #endregion
            }

            //else
            //{
                string dclmAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + PolicyNo + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=" + INDEX + "";
                if (dm.existRecored(dclmAddressSelect) != 0)
                {
                    dm.readSql(dclmAddressSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { litname.Text = dthintReader.GetString(0); AddressList1.Add(dthintReader.GetString(0)); }
                        else { litname.Text = ""; }
                        if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); AddressList1.Add(dthintReader.GetString(1)); }
                        else { litad1.Text = ""; }
                        if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); AddressList1.Add(dthintReader.GetString(2)); }
                        else { litad2.Text = ""; }
                        if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); AddressList1.Add(dthintReader.GetString(3)); }
                        else { litad3.Text = ""; }
                        if (!dthintReader.IsDBNull(4)) { litad4.Text = dthintReader.GetString(4); AddressList1.Add(dthintReader.GetString(4)); }
                        else { litad4.Text = ""; }
                        AddressList1.Add("");
                        AddressList1.Add(""); AddressList1.Add("");
                        if (AddressList1[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList1);
                        }
                    }
                    dthintReader.Dispose();
                }
                    /*
                else
                {
                    #region //**********Get Informer name from DthInt Table if that not exist in Devlaimeraddress Table

                    string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + PolicyNo + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect) != 0)
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader();
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { litname.Text = dthintReader.GetString(0); AddressList1.Add(litname.Text); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(1)) { litad1.Text = dthintReader.GetString(1); AddressList1.Add(litad1.Text); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(2)) { litad2.Text = dthintReader.GetString(2); AddressList1.Add(litad2.Text); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(3)) { litad3.Text = dthintReader.GetString(3); AddressList1.Add(litad3.Text); } else { AddressList1.Add(""); }
                            if (!dthintReader.IsDBNull(4)) { litad4.Text = dthintReader.GetString(4); AddressList1.Add(litad4.Text); } else { AddressList1.Add(""); }
                            //if (!dthintReader.IsDBNull(5)) { this.lblyrref.Text = dthintReader.GetString(5); AddressList1.Add(lblyrref.Text); } else { AddressList1.Add(""); }
                            //if (!dthintReader.IsDBNull(6)) { this.litorref.Text = dthintReader.GetInt64(6); }
                        }
                        dthintReader.Close();
                        AddressList1.Add("");
                        AddressList1.Add(""); AddressList1.Add("");
                        this.litname.Text = AddressList1[0].ToString();
                        this.litad1.Text = AddressList1[1].ToString();
                        this.litad2.Text = AddressList1[2].ToString();
                        this.litad3.Text = AddressList1[3].ToString();
                        this.litad4.Text = AddressList1[4].ToString();
                        //this.litnameofdead.Text = DNOD;
                        // this.lblyrref.Text = epfStr;
                        //this.litorref.Text = cliamNo.ToString();
                       // this.lbldate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                        if (AddressList1[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList1);
                        }
                    }
                    #endregion
                }*/

            #endregion
            //}

            #region Load Branch Administration Officers Address

            INDEX = 2;
            string BranchAddressSelect = "select NAME,ADDR1,ADDR2,ADDR3,ADDR4 from LPHS.DCLMADDRESSES where polno = " + PolicyNo + " and mos = '" + MOF + "' and LANG='" + LANG + "' and INDX=2";
            if (dm.existRecored(BranchAddressSelect) != 0)
            {

                dm.readSql(BranchAddressSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { AddressList2.Add(dthintReader.GetString(0)); }
                    else { AddressList2.Add(""); }
                    if (!dthintReader.IsDBNull(1)) { AddressList2.Add(dthintReader.GetString(1)); }
                    else { AddressList2.Add(""); }
                    if (!dthintReader.IsDBNull(2)) { AddressList2.Add(dthintReader.GetString(2)); }
                    else { AddressList2.Add(""); }

                    if (!dthintReader.IsDBNull(3)) { AddressList2.Add(dthintReader.GetString(3)); }
                    else { AddressList2.Add(""); }
                    if (!dthintReader.IsDBNull(4)) { AddressList2.Add(dthintReader.GetString(4)); }
                    else { AddressList2.Add(""); }
                    AddressList2.Add(""); AddressList2.Add("");
                    AddressList2.Add("BRANCH   COPY");
                    if (AddressList2[0].ToString() != "")
                    {
                        CopyArray.Add(AddressList2);
                    }

                }
                dthintReader.Dispose();

            }

            #endregion

            #region Load Agent Code


            string AgentCodeSelect = "select DRAGT from LPHS.DTHREF where DRPOLNO = " + PolicyNo + " ";
            if (dm.existRecored(AgentCodeSelect) != 0)
            {
                dm.readSql(AgentCodeSelect);
                OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dthintReader.Read())
                {
                    if (!dthintReader.IsDBNull(0)) { AGENTCode = dthintReader.GetInt32(0); }
                }
                dthintReader.Dispose();
                AGENCY = AGENTCode;
            }

            #endregion

            #region Load Insurance Advisors Address


            if (AGENCY != 0)
            {
                string InsuranceOffAddressSelect = "select STATUS ||''||INT||''||NAME as NAME,AD1,AD2,AD3,AD4,AD5 from AGENT.AGENT where AGENCY = " + AGENCY + " and STCD<>'5' and STCD<>'8' and STCD<>'9'";
                if (dm.existRecored(InsuranceOffAddressSelect) != 0)
                {
                    dm.readSql(InsuranceOffAddressSelect);
                    OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { AddressList3.Add(dthintReader.GetString(0).Trim()); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(1)) { AddressList3.Add(dthintReader.GetString(1)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(2)) { AddressList3.Add(dthintReader.GetString(2)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(3)) { AddressList3.Add(dthintReader.GetString(3)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(4)) { AddressList3.Add(dthintReader.GetString(4)); }
                        else { AddressList3.Add(""); }
                        if (!dthintReader.IsDBNull(5)) { AddressList3.Add(dthintReader.GetString(5)); }
                        else { AddressList3.Add(""); }
                        AddressList3.Add(AGENCY);
                        AddressList3.Add("INSURANCE  ADVISOR'S  COPY");
                        if (AddressList3[0].ToString() != "")
                        {
                            CopyArray.Add(AddressList3);
                        }
                    }
                    dthintReader.Dispose();
                }
            }

            #endregion

            #region Get the Requiements which has not received yet

            int reqcode;
            string reqdesc = "";
            int rows = 0;
            string dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + PolicyNo + " and drtyp='" + MOF + "' and (drrecdt is null or drrecdt = 0) ";
            dm.readSql(dreqSelect);
            OracleDataReader dreqreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dreqreader.Read())
            {

                reqcode = dreqreader.GetInt32(0);
                ReqcodeList.Add(reqcode);
                dreqSelect = "select dreqdsesceng from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
                dm.readSql(dreqSelect);
                OracleDataReader dreqreader02 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader02.Read())
                {
                    if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); }
                }
                //dreqreader02.Close();
                //dreqreader02.Dispose();
                int row = rows + 1;
                this.createDynamicTable(row.ToString(), reqdesc, rows, reqcode);

                if (reqcode != 22 && reqcode != 23 && reqcode != 24)
                {
                    rows++;
                }
            }
            if (Session["Req21"] != null)
            { litreq24.Text = Session["Req21"].ToString(); }
            if (Session["Req22"] != null)
            { litreq22.Text = Session["Req22"].ToString(); }
            if (Session["Req23"] != null)
            { litreq23.Text = Session["Req23"].ToString(); }
            dreqreader.Close();
            #endregion      


        #region get Date of reqirement sent
        string SelectSecondReqDate = "select SECONDREQUESTYN,DRSENTDT,SECONDREQUESTDATE from lphs.dreq where drpol=" + PolicyNo + "";
        if (dm.existRecored(SelectSecondReqDate) != 0)
        {

            dm.readSql(SelectSecondReqDate);
            OracleDataReader dthintReader2 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dthintReader2.Read())
            {
                if (!dthintReader2.IsDBNull(0)) {ReqType= dthintReader2.GetString(0); }
                else { ReqType=""; }
                if (!dthintReader2.IsDBNull(1)) { FirSrReqDate=dthintReader2.GetInt32(1); }
                else { FirSrReqDate=0; }
                if (!dthintReader2.IsDBNull(2)) { SecReqDate=dthintReader2.GetInt32(2); }
                else { SecReqDate=0; }

            }
            dthintReader2.Dispose();
            if(ReqType=="N")
            {
                litletterdated.Text = FirSrReqDate.ToString().Substring(0, 4) + "/" + FirSrReqDate.ToString().Substring(4, 2) + "/" + FirSrReqDate.ToString().Substring(6, 2);
            }
            else
            {
                litletterdated.Text = SecReqDate.ToString().Substring(0, 4) + "/" + SecReqDate.ToString().Substring(4, 2) + "/" + SecReqDate.ToString().Substring(6, 2);
            }
        }
        #endregion
    }
    else
    {
        #region Get the Requiements which has not received yet
        if (Session["Polno"] != null)
        {
            PolicyNo = int.Parse(Session["Polno"].ToString());
        }
        if (Session["MOF"] != null)
        {
            MOF = Session["MOF"].ToString();
        }
        dm = new DataManager();
        int reqcode;
        string reqdesc = "";
        int rows = 0;
        string dreqSelect1 = "select drcovtyp, drrema from lphs.dreq where drpol=" + PolicyNo + " and drtyp='" + MOF + "' and (drrecdt is null or drrecdt = 0) ";
        dm.readSql(dreqSelect1);
        OracleDataReader dreqreader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        while (dreqreader.Read())
        {

            reqcode = dreqreader.GetInt32(0);
            ReqcodeList.Add(reqcode);
            string dreqSelect2 = "select dreqdsesceng from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
            dm.readSql(dreqSelect2);
            OracleDataReader dreqreader02 = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dreqreader02.Read())
            {
                if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); }
            }
            //dreqreader02.Close();
            //dreqreader02.Dispose();

            int row = rows + 1;
            this.CreateDynTable(row.ToString(), reqdesc, rows, reqcode);
            if (reqcode != 22 && reqcode != 23 && reqcode != 24)
            {
                rows++;
            }
        }
        if (Session["Req21"] != null)
        { litreq24.Text = Session["Req21"].ToString(); }
        if (Session["Req22"] != null)
        { litreq22.Text = Session["Req22"].ToString(); }
        if (Session["Req23"] != null)
        { litreq23.Text = Session["Req23"].ToString(); }

        dreqreader.Close();
        dreqreader.Dispose();
        #endregion      
    }

    }

    private void createDynamicTable(string reqcode, string req, int rowNumber,int RecordNumber)
    {
        if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            lbl1.ID = "Number" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
            lbl1.Text = reqcode + ".";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";
            
            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";
            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            tblRequiremnt.Rows.Add(trow);

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if(RecordNumber == 19 || RecordNumber == 20)
                {
                for (int i = 0; i < 7; i++)
                {

                    tblRequiremnt.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                    tblRequiremnt.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                    tblRequiremnt.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                    tblRequiremnt.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                    TableRow tr = new TableRow();
                    tblRequiremnt.Rows.Add(tr);

                    TableCell tc = new TableCell();
                    Label Dynlbl1 = new Label();
                    if (RecordNumber == 19)
                    {
                        Dynlbl1.ID = "Dynlbl9" + i.ToString();
                    }
                    if (RecordNumber == 20)
                    {
                        Dynlbl1.ID = "Dynlbl10" + i.ToString();
                    }
                   

                    if (i == 0) { Dynlbl1.Text = "I."; }
                    if (i == 1) { Dynlbl1.Text = "II."; }
                    if (i == 2) { Dynlbl1.Text = "III."; }
                    if (i == 3) { Dynlbl1.Text = "IV."; }
                    if (i == 4) { Dynlbl1.Text = "V."; }
                    if (i == 5) { Dynlbl1.Text = "VI."; }
                    if (i == 6) { Dynlbl1.Text = "VII."; }


                    Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                    Dynlbl1.ControlStyle.Font.Size = 10;
                    Dynlbl1.Width = 10;
                    tc.Controls.Add(Dynlbl1);
                    tr.Cells.Add(tc);



                    TableCell tc1 = new TableCell();
                    TextBox DyTextBox = new TextBox();
                    if (RecordNumber == 19)
                    {
                        Session["ReqCode9"] = RecordNumber;
                        DyTextBox.ID = "DyTextBox9" + i.ToString();
                    }
                    if (RecordNumber == 20)
                    {
                        Session["ReqCode10"] = RecordNumber;
                        DyTextBox.ID = "DyTextBox10" + i.ToString();
                    }
                    

                    DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                    DyTextBox.ControlStyle.Font.Size = 10;
                    DyTextBox.Width = 350;
                    tc1.Controls.Add(DyTextBox);
                    tr.Cells.Add(tc1);
                    tblRequiremnt.Rows.Add(tr);
                    // tblDynamic.Rows.Add(tr);


                }
            }
            if (RecordNumber == 21)
            {
                ArrayList Changes = new ArrayList();
                Changes.Add("Assignee Name Change");
                Changes.Add("Beneficiarie Name Change");

                for (int j = 0; j < 2; j++)
                {
                    TableRow tr1 = new TableRow();

                    TableCell tchead = new TableCell();
                    TableCell tchead1 = new TableCell();

                    Label headlbl = new Label();
                    headlbl.Text = Changes[j].ToString();
                    headlbl.Font.Bold = true;
                    headlbl.Font.Underline = true;
                    headlbl.ControlStyle.Font.Name = "Trebuchet MS";
                    headlbl.ControlStyle.Font.Size = 10;
                    headlbl.Width = 200;

                    tchead1.Controls.Add(headlbl);
                    tr1.Cells.Add(tchead);
                    tr1.Cells.Add(tchead1);

                    tblRequiremnt.Rows.Add(tr1);

                    for (int i = 0; i < 7; i++)
                    {
                        tblRequiremnt.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                        tblRequiremnt.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                        tblRequiremnt.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                        tblRequiremnt.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                        TableRow tr = new TableRow();
                        tblRequiremnt.Rows.Add(tr);

                        TableCell tc = new TableCell();
                        Label Dynlbl1 = new Label();

                        Dynlbl1.ID = "Dynlbl20" + j.ToString() + i.ToString();


                        if (i == 0) { Dynlbl1.Text = "I."; }
                        if (i == 1) { Dynlbl1.Text = "II."; }
                        if (i == 2) { Dynlbl1.Text = "III."; }
                        if (i == 3) { Dynlbl1.Text = "IV."; }
                        if (i == 4) { Dynlbl1.Text = "V."; }
                        if (i == 5) { Dynlbl1.Text = "VI."; }
                        if (i == 6) { Dynlbl1.Text = "VII."; }


                        Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                        Dynlbl1.ControlStyle.Font.Size = 10;
                        Dynlbl1.Width = 10;
                        tc.Controls.Add(Dynlbl1);
                        tr.Cells.Add(tc);



                        TableCell tc1 = new TableCell();
                        TextBox DyTextBox = new TextBox();

                        if (RecordNumber == 21)
                        {
                            Session["ReqCode11"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox20" + j.ToString() + i.ToString();
                        }

                        DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                        DyTextBox.ControlStyle.Font.Size = 10;
                        DyTextBox.Width = 350;
                        tc1.Controls.Add(DyTextBox);
                        tr.Cells.Add(tc1);
                        tblRequiremnt.Rows.Add(tr);
                    }
                }
            
            }

                TableRow trdes = new TableRow();
                tblRequiremnt.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString();
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString();
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                }

                if (RecordNumber == 19)
                {
                    Dynlbl2.Text = "If the above names were used to refer one and same person, please forwards us a Grama Niladhari certificate certifying the above difference counter signed by Divisional Secretary of the Area.";
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.Text = "if the above names refer to the one and same person, please forward us a certified affidavit for that affect further please note that your signature should be placed on Rs. 25/- stamp and attested by a Justice of Peace";
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.Text = "If the above names were used to refer the life assured, please forwards us a Grama Niladhari certificate counter signed by Divisional Secretary of the Area for the effect of the differnt found in the life assured's name & an affidavit signed by you and attested by a justice of peace stating that the name difference found in your names were used to refer one and same person. Please note that your signature should be placed on Rs. 25/- stamp.";
                }
                Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
                Dynlbl2.ControlStyle.Font.Size = 10;
                Dynlbl2.Width = 600;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);


            }

            //tblRequiremnt.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            //tblRequiremnt.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            //tblRequiremnt.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            //tblRequiremnt.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;
        }
        if (RecordNumber == 22)
        {
            Session["Req22"] = req;
        }
        if (RecordNumber == 23)
        {
            Session["Req23"] = req;
        }
        if (RecordNumber == 24)
        {
            if (Address1 != null)
            {
                if (Address1.Count != 0)
                {
                    string Nominees = "";
                    Nominees = Address1[0].ToString();
                    for (int i = 0; i < Address1.Count; i++)
                    {
                        if (i != 0)
                        {
                            Nominees = Nominees + "," + Address1[i].ToString();
                        }
                        i += 2;
                    }
                    Session["Req21"] = req + Nominees + "the claim forms should be signed him/her. If the Nominee was minor, the claim forms should be signed by the legal guardian of the child";
                }
            }
        }
    }

    private void CreateDynTable(string reqcode, string req, int rowNumber, int RecordNumber)
    {
        if (RecordNumber != 22 && RecordNumber != 23 && RecordNumber != 24)
        {
            TableRow trow = new TableRow();
            TableCell tcell1 = new TableCell();
            TableCell tcell2 = new TableCell();
            Label lbl1 = new Label();
            Label lbl2 = new Label();

            lbl1.ID = "Number" + rowNumber;
            lbl1.Attributes.Add("runat", "Server");
            lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
            lbl1.Text = reqcode + ".";

            lbl2.ID = "ReqName" + rowNumber;
            lbl2.Attributes.Add("runat", "Server");
            lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value
            lbl2.Width = 600;
            lbl2.Style["text-align"] = "justify";
            if (req.EndsWith("."))
            {
                lbl2.Text = req.Remove(req.Length - 1);
            }
            else
            {
                lbl2.Text = req;
            }

            tcell1.Controls.Add(lbl1);
            tcell2.Controls.Add(lbl2);
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);
            tblRequiremnt.Rows.Add(trow);

            if (RecordNumber == 19 || RecordNumber == 20 || RecordNumber == 21)
            {
                if(RecordNumber==19 || RecordNumber==20)
                {
                for (int i = 0; i < 7; i++)
                {
                    tblRequiremnt.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                    tblRequiremnt.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                    tblRequiremnt.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                    tblRequiremnt.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                    TableRow tr = new TableRow();
                    tblRequiremnt.Rows.Add(tr);

                    TableCell tc = new TableCell();
                    Label Dynlbl1 = new Label();
                    if (RecordNumber == 19)
                    {
                        Dynlbl1.ID = "Dynlbl9" + i.ToString();
                    }
                    if (RecordNumber == 20)
                    {
                        Dynlbl1.ID = "Dynlbl10" + i.ToString();
                    }
                    if (RecordNumber == 21)
                    {
                        Dynlbl1.ID = "Dynlbl11" + i.ToString();
                    }

                    if (i == 0) { Dynlbl1.Text = "I."; }
                    if (i == 1) { Dynlbl1.Text = "II."; }
                    if (i == 2) { Dynlbl1.Text = "III."; }
                    if (i == 3) { Dynlbl1.Text = "IV."; }
                    if (i == 4) { Dynlbl1.Text = "V."; }
                    if (i == 5) { Dynlbl1.Text = "VI."; }
                    if (i == 6) { Dynlbl1.Text = "VII."; }


                    Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                    Dynlbl1.ControlStyle.Font.Size = 10;
                    Dynlbl1.Width = 10;
                    tc.Controls.Add(Dynlbl1);
                    tr.Cells.Add(tc);



                    TableCell tc1 = new TableCell();
                    TextBox DyTextBox = new TextBox();
                    if (RecordNumber == 19)
                    {
                        Session["ReqCode9"] = RecordNumber;
                        DyTextBox.ID = "DyTextBox9" + i.ToString();
                    }
                    if (RecordNumber == 20)
                    {
                        Session["ReqCode10"] = RecordNumber;
                        DyTextBox.ID = "DyTextBox10" + i.ToString();
                    }
                    if (RecordNumber == 21)
                    {
                        Session["ReqCode11"] = RecordNumber;
                        DyTextBox.ID = "DyTextBox11" + i.ToString();
                    }

                    DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                    DyTextBox.ControlStyle.Font.Size = 10;
                    DyTextBox.Width = 600;
                    tc1.Controls.Add(DyTextBox);
                    tr.Cells.Add(tc1);
                    tblRequiremnt.Rows.Add(tr);
                    // tblDynamic.Rows.Add(tr);


                }
            }
            if (RecordNumber == 21)
            {
                ArrayList Changes = new ArrayList();
                Changes.Add("Assignee Name Change");
                Changes.Add("Beneficiarie Name Change");

                for (int j = 0; j < 2; j++)
                {
                    TableRow tr1 = new TableRow();

                    TableCell tchead = new TableCell();
                    TableCell tchead1 = new TableCell();

                    Label headlbl = new Label();
                    headlbl.Text = Changes[j].ToString();
                    headlbl.ControlStyle.Font.Name = "Trebuchet MS";
                    headlbl.ControlStyle.Font.Size = 10;
                    headlbl.Width = 10;

                    tchead.Controls.Add(headlbl);
                    tr1.Cells.Add(tchead);
                    tr1.Cells.Add(tchead1);

                    tblRequiremnt.Rows.Add(tr1);

                    for (int i = 0; i < 7; i++)
                    {
                        tblRequiremnt.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
                        tblRequiremnt.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
                        tblRequiremnt.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
                        tblRequiremnt.Rows[i].Cells[1].VerticalAlign = VerticalAlign.Top;


                        TableRow tr = new TableRow();
                        tblRequiremnt.Rows.Add(tr);

                        TableCell tc = new TableCell();
                        Label Dynlbl1 = new Label();

                        Dynlbl1.ID = "Dynlbl20" + j.ToString() + i.ToString();


                        if (i == 0) { Dynlbl1.Text = "I."; }
                        if (i == 1) { Dynlbl1.Text = "II."; }
                        if (i == 2) { Dynlbl1.Text = "III."; }
                        if (i == 3) { Dynlbl1.Text = "IV."; }
                        if (i == 4) { Dynlbl1.Text = "V."; }
                        if (i == 5) { Dynlbl1.Text = "VI."; }
                        if (i == 6) { Dynlbl1.Text = "VII."; }


                        Dynlbl1.ControlStyle.Font.Name = "Trebuchet MS";
                        Dynlbl1.ControlStyle.Font.Size = 10;
                        Dynlbl1.Width = 10;
                        tc.Controls.Add(Dynlbl1);
                        tr.Cells.Add(tc);



                        TableCell tc1 = new TableCell();
                        TextBox DyTextBox = new TextBox();

                        if (RecordNumber == 21)
                        {
                            Session["ReqCode11"] = RecordNumber;
                            DyTextBox.ID = "DyTextBox20" + j.ToString() + i.ToString();
                        }

                        DyTextBox.ControlStyle.Font.Name = "Trebuchet MS";
                        DyTextBox.ControlStyle.Font.Size = 10;
                        DyTextBox.Width = 350;
                        tc1.Controls.Add(DyTextBox);
                        tr.Cells.Add(tc1);
                        tblRequiremnt.Rows.Add(tr);
                    }
                }
            }

                TableRow trdes = new TableRow();
                tblRequiremnt.Rows.Add(trdes);

                TableCell tc5 = new TableCell();


                TableCell tc4 = new TableCell();
                Label Dynlbl2 = new Label();
                if (RecordNumber == 19)
                {
                    Dynlbl2.ID = "Dynlbl19" + 1.ToString();
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.ID = "Dynlbl110" + 1.ToString();
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.ID = "Dynlbl111" + 1.ToString();
                }

                if (RecordNumber == 19)
                {
                    Dynlbl2.Text = "If the above names were used to refer one and same person, please forwards us a Grama Niladhari certificate certifying the above difference counter signed by Divisional Secretary of the Area.";
                }
                if (RecordNumber == 20)
                {
                    Dynlbl2.Text = "if the above names refer to the one and same person, please forward us a certified affidavit for that affect further please note that your signature should be placed on Rs. 25/- stamp and attested by a Justice of Peace";
                }
                if (RecordNumber == 21)
                {
                    Dynlbl2.Text = "If the above names were used to refer the life assured, please forwards us a Grama Niladhari certificate counter signed by Divisional Secretary of the Area for the effect of the differnt found in the life assured's name & an affidavit signed by you and attested by a justice of peace stating that the name difference found in your names were used to refer one and same person. Please note that your signature should be placed on Rs. 25/- stamp.";
                }
                Dynlbl2.ControlStyle.Font.Name = "Trebuchet MS";
                Dynlbl2.ControlStyle.Font.Size = 10;
                Dynlbl2.Width = 600;
                tc4.Controls.Add(Dynlbl2);
                trdes.Cells.Add(tc5);
                trdes.Cells.Add(tc4);


            }

            tblRequiremnt.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Justify;
            tblRequiremnt.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
            tblRequiremnt.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
            tblRequiremnt.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;
        }
        if (RecordNumber == 22)
        {
            Session["Req22"] = req;
        }
        if (RecordNumber == 23)
        {
            Session["Req23"] = req;
        }
        if (RecordNumber == 24)
        {
            if (Address1 != null)
            {
                if (Address1.Count != 0)
                {
                    string Nominees = "";
                    Nominees = Address1[0].ToString();
                    for (int i = 0; i < Address1.Count; i++)
                    {
                        if (i != 0)
                        {
                            Nominees = Nominees + "," + Address1[i].ToString();
                        }
                        i += 2;
                    }
                    litreq24.Text = req + Nominees + "the claim forms should be signed him/her. If the Nominee was minor, the claim forms should be signed by the legal guardian of the child";
                }
            }
        }
    }
   
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

    protected void btnprint_Click(object sender, EventArgs e)
    {
        ChechedBtn = 1;
        AssuNameChng = new ArrayList();
        NomineeNamChg = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nomihg1 = new ArrayList();
        for (int a = 0; a < ReqcodeList.Count; a++)
        {
            if (int.Parse(ReqcodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblRequiremnt.FindControl("DyTextBox9" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        AssuNameChng.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblRequiremnt.FindControl("DyTextBox10" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        NomineeNamChg.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 21)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        TextBox txtname2 = new TextBox();
                        txtname2 = (TextBox)tblRequiremnt.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nomihg1.Add(txtname2.Text);
                            }

                        }
                    }
                }
            }
        }
        
    }

    public int Polno
    {
        get { return PolicyNo; }
        set { PolicyNo = value; }
    }
    public string mof
    {
        get { return MOF; }
        set { MOF = value; }
    }       
    public ArrayList AssuNameChange
    {
        get { return AssuNameChng; }
        set { AssuNameChng = value; }
    }
    public ArrayList NomineeNameChange
    {
        get { return NomineeNamChg; }
        set { NomineeNamChg = value; }
    }
    public ArrayList AssureandNomineeChanged
    {
        get { return Ass_Nomihg; }
        set { Ass_Nomihg = value; }
    }
    public ArrayList AssureandNomineeChanged1
    {
        get { return Ass_Nomihg1; }
        set { Ass_Nomihg1 = value; }
    }
    public int CHECKEDBTN
    {
        get { return ChechedBtn; }
        set { ChechedBtn = value; }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ChechedBtn = 2;
        AssuNameChng = new ArrayList();
        NomineeNamChg = new ArrayList();
        Ass_Nomihg = new ArrayList();
        Ass_Nomihg1 = new ArrayList();
        for (int a = 0; a < ReqcodeList.Count; a++)
        {
            if (int.Parse(ReqcodeList[a].ToString()) == 19)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblRequiremnt.FindControl("DyTextBox9" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        AssuNameChng.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    TextBox txtname2 = new TextBox();
                    txtname2 = (TextBox)tblRequiremnt.FindControl("DyTextBox10" + i.ToString());
                    if (txtname2.Text != "")
                    {
                        NomineeNamChg.Add(txtname2.Text);
                    }
                }
            }
            if (int.Parse(ReqcodeList[a].ToString()) == 21)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        TextBox txtname2 = new TextBox();
                        txtname2 = (TextBox)tblRequiremnt.FindControl("DyTextBox20" + j.ToString() + i.ToString());
                        if (txtname2.Text != "")
                        {
                            if (j == 0)
                            {
                                Ass_Nomihg.Add(txtname2.Text);
                            }
                            else
                            {
                                Ass_Nomihg1.Add(txtname2.Text);
                            }

                        }
                    }
                }
            }
        }
              
    }
    protected void btn_word_Click(object sender, EventArgs e)
    {

    }
}
