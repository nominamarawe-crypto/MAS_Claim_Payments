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

public partial class addEnt001 : System.Web.UI.Page
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
    private int polno;
    private string MOF;
    private string epf;

    private string LANG = "";
    private int INDEX = 0;
    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    private string ADDRESS3 = "";
    private string ADDRESS4 = "";
    private string stcd = "";

    DataManager dm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EPFNum"] != null)
        {
            //branch = Convert.ToInt32(Session["brcode"]);
            epf = Session["EPFNum"].ToString();
        }
        else
        {
            throw new Exception("Your Session Variable Expired Please Log on to the System!");
        }

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;        
        }

        if (!Page.IsPostBack)
        {

            dm = new DataManager();
            try
            {
                this.lblpolno.Text = polno.ToString();
                if (MOF.Equals("M")) { this.lblLifetype.Text = "Main Life"; }
                else if (MOF.Equals("S")) { this.lblLifetype.Text = "Spouce"; }
                else if (MOF.Equals("2")) { this.lblLifetype.Text = "Second Life"; }

                string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' ";
                if (dm.existRecored(dclmaddressSelect) != 0)
                {
                    dm.readSql(dclmaddressSelect);
                    OracleDataReader dclmAdReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dclmAdReader.Read())
                    {
                        #region
                        if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
                        if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
                        if (!dclmAdReader.IsDBNull(2)) { NAME = dclmAdReader.GetString(2); } else { NAME = ""; }
                        if (!dclmAdReader.IsDBNull(3)) { ADDRESS1 = dclmAdReader.GetString(3); } else { ADDRESS1 = ""; }
                        if (!dclmAdReader.IsDBNull(4)) { ADDRESS2 = dclmAdReader.GetString(4); } else { ADDRESS2 = ""; }
                        if (!dclmAdReader.IsDBNull(5)) { ADDRESS3 = dclmAdReader.GetString(5); } else { ADDRESS3 = ""; }
                        if (!dclmAdReader.IsDBNull(6)) { ADDRESS4 = dclmAdReader.GetString(6); } else { ADDRESS4 = ""; }

                        if (LANG.Equals("E"))
                        {
                            if (INDEX == 0) 
                            {
                                this.txtEngMailName.Text = NAME;
                                this.txtmailadEng1.Text = ADDRESS1;
                                this.txtmailadEng2.Text = ADDRESS2;
                                this.txtmailadEng3.Text = ADDRESS3;
                                this.txtmailadEng4.Text = ADDRESS4;
                            }
                            else if (INDEX == 1)
                            {
                                this.txtengcopy1Name.Text = NAME;
                                this.txtEngCopy11.Text = ADDRESS1;
                                this.txtEngCopy12.Text = ADDRESS2;
                                this.txtEngCopy13.Text = ADDRESS3;
                                this.txtEngCopy14.Text = ADDRESS4;
                            }
                            else if (INDEX == 2)
                            {
                                this.txtengcopy2Name.Text = "BRANCH MANAGER - LIFE,";                               
                                this.txtEngCopy21.Text = ADDRESS1;
                                this.txtEngCopy22.Text = ADDRESS2;
                              
                            }
                            //else if (INDEX == 3)
                            //{
                            //    //this.txtengcopy3Name.Text = NAME; 
                            //    //this.txtEngCopy31.Text = ADDRESS1;
                            //    //this.txtEngCopy32.Text = ADDRESS2;
                            //    //this.txtEngCopy33.Text = ADDRESS3;
                            //    //this.txtEngCopy34.Text = ADDRESS4;
                            //}
                            //else if (INDEX == 4)
                            //{
                            //    this.txtOtherEngName.Text = NAME;
                            //    this.txtanotheradEng1.Text = ADDRESS1;
                            //    this.txtanotheradEng2.Text = ADDRESS2;
                            //}
                            else if (INDEX == 5)
                            {
                                this.TxtRegionName.Text = NAME;
                                this.TxtRegionAd1.Text = ADDRESS1;
                                //this.txtanotheradEng2.Text = ADDRESS2;
                            }
                            else if (INDEX == 6)
                            {
                                //this.TxtRegSalAddress1.Text = NAME;
                                this.TxtRegSalAddress1.Text = "Regional Manager - Life";
                                this.TxtRegSalAddress2.Text = ADDRESS1;
                                //this.txtanotheradEng2.Text = ADDRESS2;
                            }
                        }
                        #endregion
                    }
                    dclmAdReader.Close();
                    dclmAdReader.Dispose();
                }
                else
                {

                    #region  //********* Name & Address Select ***************

                    string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    if (dm.existRecored(dthintSelect) != 0)
                    {
                        dm.readSql(dthintSelect);
                        OracleDataReader dthintReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dthintReader.Read())
                        {
                            if (!dthintReader.IsDBNull(0)) { NAME = dthintReader.GetString(0); } else { NAME = ""; }
                            if (!dthintReader.IsDBNull(1)) { ADDRESS1 = dthintReader.GetString(1); } else { ADDRESS1 = ""; }
                            if (!dthintReader.IsDBNull(2)) { ADDRESS2 = dthintReader.GetString(2); } else { ADDRESS2 = ""; }
                            if (!dthintReader.IsDBNull(3)) { ADDRESS3 = dthintReader.GetString(3); } else { ADDRESS3 = ""; }
                            if (!dthintReader.IsDBNull(4)) { ADDRESS4 = dthintReader.GetString(4); } else { ADDRESS4 = ""; }
                        }
                        dthintReader.Close();
                        dthintReader.Dispose();

                        this.txtEngMailName.Text = NAME;
                        this.txtmailadEng1.Text = ADDRESS1;
                        this.txtmailadEng2.Text = ADDRESS2;
                        this.txtmailadEng3.Text = ADDRESS3;
                        this.txtmailadEng4.Text = ADDRESS4;
                    }

                    #endregion
                   
                    else
                    {
                        //--- nomi read ---              

                        string nomiselect = "select nomnam, nomad1, nomad2 from lund.nominee where polno = " + polno + " ";
                        if (dm.existRecored(nomiselect) != 0)
                        {
                            dm.readSql(nomiselect);
                            OracleDataReader nomireader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (nomireader.Read())
                            {
                                if (!nomireader.IsDBNull(0)) { NAME = nomireader.GetString(0); } else { NAME = ""; }
                                if (!nomireader.IsDBNull(1)) { ADDRESS1 = nomireader.GetString(1); } else { ADDRESS1 = ""; }
                                if (!nomireader.IsDBNull(2)) { ADDRESS2 = nomireader.GetString(2); } else { ADDRESS2 = ""; }
                            }
                            nomireader.Close();
                            nomireader.Dispose();

                            this.txtEngMailName.Text = NAME;
                            this.txtmailadEng1.Text = ADDRESS1;
                            this.txtmailadEng2.Text = ADDRESS2;
                        }
                    }

                    #region  //********* Agent & Address Select **************

                    string INT = "";
                    string status = "";
                    string AD5 = "";
                    
                    string agentSelect = "select INT, NAME, AD1, AD2, AD3, AD4, AD5, STATUS, stcd from AGENT.AGENT where AGENCY = (select phagt from lphs.lpolhis where phpol = " + polno + " and phtyp = 'D' and phmos = '" + MOF + "' ) ";
                    if (dm.existRecored(agentSelect) != 0) 
                    {
                        dm.readSql(agentSelect);
                        OracleDataReader agentReader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (agentReader.Read())
                        {
                            if (!agentReader.IsDBNull(0)) { INT = agentReader.GetString(0); } else { INT = ""; }
                            if (!agentReader.IsDBNull(1)) { NAME = agentReader.GetString(1); } else { NAME = ""; }
                            if (!agentReader.IsDBNull(2)) { ADDRESS1 = agentReader.GetString(2); } else { ADDRESS1 = ""; }
                            if (!agentReader.IsDBNull(3)) { ADDRESS2 = agentReader.GetString(3); } else { ADDRESS2 = ""; }
                            if (!agentReader.IsDBNull(4)) { ADDRESS3 = agentReader.GetString(4); } else { ADDRESS3 = ""; }
                            if (!agentReader.IsDBNull(5)) { ADDRESS4 = agentReader.GetString(5); } else { ADDRESS4 = ""; }
                            if (!agentReader.IsDBNull(6)) { AD5 = agentReader.GetString(6); } else { AD5 = ""; }
                            if (!agentReader.IsDBNull(7)) { status = agentReader.GetString(7); } else { status = ""; }
                            if (!agentReader.IsDBNull(8)) { stcd = agentReader.GetString(8).Trim(); } else { stcd = ""; }
                        }
                        agentReader.Close();
                        agentReader.Dispose();

                        NAME = status + " " + INT + "" + NAME;
                        if ((AD5 != null) && (!AD5.Equals(""))) { ADDRESS4 = ADDRESS4 + " " + AD5; }
                      
                        this.txtengcopy1Name.Text = NAME;
                        this.txtEngCopy11.Text = ADDRESS1;
                        this.txtEngCopy12.Text = ADDRESS2;
                        this.txtEngCopy13.Text = ADDRESS3;
                        this.txtEngCopy14.Text = ADDRESS4;

                        //this.txtSinCopy1Name.Text = NAME;
                        //this.txtSinCopy11.Text = ADDRESS1;
                        //this.txtSinCopy12.Text = ADDRESS2;
                        //this.txtSinCopy13.Text = ADDRESS3;
                        //this.txtSinCopy14.Text = ADDRESS4;

                        if (stcd.Equals("9")) //20071011
                        {
                            this.lblagentterminted1.Text = "Agent Terminated";
                            //this.lblagtter2.Text = "Agent Terminated";
                        }
                        if (stcd.Equals("8")) //20071011
                        {
                            this.lblagentterminted1.Text = "Agent Deceased";
                            //this.lblagtter2.Text = "Agent Deceased";
                        }
                        if (stcd.Equals("5")) //20071011
                        {
                            this.lblagentterminted1.Text = "Agent Resign";
                            //this.lblagtter2.Text = "Agent Resign";
                        }
                    }

                    #endregion
                }

                dm.connclose();

                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
                ViewState["epf"] = epf;
                ViewState["stcd"] = stcd;
               }
            catch (Exception ex)
            {
                dm.connclose();
                EPage.Messege = ex.Message; 
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            //polno = int.Parse(ViewState["polno"].ToString());
            //MOF = ViewState["mof"].ToString();
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
            if (ViewState["epf"] != null) { epf = ViewState["epf"].ToString(); }
            if (ViewState["stcd"] != null) { stcd = ViewState["stcd"].ToString(); }
        }

    }

    //protected void btnaddOtherEng_Click(object sender, EventArgs e)
    //{
    //    this.lblotherEngName.Visible = true;
    //    this.txtOtherEngName.Visible = true;
    //    this.lblotherEngAd.Visible = true;
    //    this.txtanotheradEng1.Visible = true;
    //    this.txtanotheradEng2.Visible = true;
    //    this.txtanotheradEng3.Visible = true;
    //    this.txtanotheradEng4.Visible = true;
    //    this.btnaddOtherEng.Enabled = false;
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //String brachnm = DropDownList1.SelectedItem.Text;
        //String clsbrach = DropDownList2.SelectedItem.Text;
        dm = new DataManager();


        try
        {
            for (int i = 0; i < 10; i++)
            {
                #region //--------- Retreiving Values ----

                if (i == 0)
                {
                    INDEX = 0;
                    LANG = "E";
                    if (this.txtEngMailName.Text != null) { NAME = this.txtEngMailName.Text.Trim(); } else { NAME = ""; }
                    if (this.txtmailadEng1.Text != null) { ADDRESS1 = this.txtmailadEng1.Text.Trim(); } else { ADDRESS1 = ""; }
                    if (this.txtmailadEng2.Text != null) { ADDRESS2 = this.txtmailadEng2.Text.Trim(); } else { ADDRESS2 = ""; }
                    if (this.txtmailadEng3.Text != null) { ADDRESS3 = this.txtmailadEng3.Text.Trim(); } else { ADDRESS3 = ""; }
                    if (this.txtmailadEng4.Text != null) { ADDRESS4 = this.txtmailadEng4.Text.Trim(); } else { ADDRESS4 = ""; }
                    string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                    if (dm.existRecored(dclmAddressSelect) != 0)
                    {
                        string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                            "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                        dm.insertRecords(dclmAddressUpdate);
                    }
                    else
                    {
                        string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                            "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                        dm.insertRecords(dclmAddressInsert);

                    }

                    //Sachinda 2023.10.10

                    string dclmAddressSelectReq = "select * from LPHS.DTHINT where dpolno = " + polno + " and dmos = '" + MOF + "' ";
                    if (dm.existRecored(dclmAddressSelectReq) != 0)
                    {
                        string dclmAddressUpdate1 = "UPDATE LPHS.DTHINT SET DINAME = '" + NAME + "' , DIAD1 = '" + ADDRESS1 + "' , DIAD2 = '" + ADDRESS2 + "' ," +
                            "DIAD3 = '" + ADDRESS3 + "' , DIAD4 = '" + ADDRESS4 + "'  WHERE dpolno = " + polno + " and dmos = '" + MOF + "'";
                        dm.insertRecords(dclmAddressUpdate1);
                    }
                    else
                    {
                        string dclmAddressInsert1 = "INSERT INTO LPHS.DTHINT (DPOLNO ,DMOS ,DINAME,DIAD1,DIAD2,DIAD3,DIAD4)" +
                            "VALUES (" + polno + " ,'" + MOF + "' ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "')";
                        dm.insertRecords(dclmAddressInsert1);

                    }

                    //
                }
                else if (i == 1)
                {
                    INDEX = 1;
                    LANG = "E";
                    if ((txtengcopy1Name.Text.Trim() != "AGENT DIRECT" || lblagentterminted1.Text.Trim() != "") && txtengcopy1Name.Text.Trim() != "")
                    {
                        if (this.txtengcopy1Name.Text != null) { NAME = this.txtengcopy1Name.Text.Trim(); } else { NAME = ""; }
                        if (this.txtEngCopy11.Text != null) { ADDRESS1 = this.txtEngCopy11.Text.Trim(); } else { ADDRESS1 = ""; }
                        if (this.txtEngCopy12.Text != null) { ADDRESS2 = this.txtEngCopy12.Text.Trim(); } else { ADDRESS2 = ""; }
                        if (this.txtEngCopy13.Text != null) { ADDRESS3 = this.txtEngCopy13.Text.Trim(); } else { ADDRESS3 = ""; }
                        if (this.txtEngCopy14.Text != null) { ADDRESS4 = this.txtEngCopy14.Text.Trim(); } else { ADDRESS4 = ""; }

                        string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                        if (dm.existRecored(dclmAddressSelect) != 0)
                        {
                            string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                                "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                            dm.insertRecords(dclmAddressUpdate);
                        }
                        else
                        {
                            string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                                "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                            dm.insertRecords(dclmAddressInsert);
                        } 
                    }
                    
                }
                else if (i == 2)
                {
                    INDEX = 2;
                    LANG = "E";
                    if (txtEngCopy22.Text.Trim() != "")
                    {
                        if (this.txtengcopy2Name.Text != null) { NAME = this.txtengcopy2Name.Text.Trim(); } else { NAME = ""; }
                        if (this.txtEngCopy21.Text != null) { ADDRESS1 = this.txtEngCopy21.Text.Trim(); } else { ADDRESS1 = ""; }
                        if (this.txtEngCopy22.Text != null) { ADDRESS2 = this.txtEngCopy22.Text.Trim(); } else { ADDRESS2 = ""; }
                        ADDRESS3 = "";
                        ADDRESS4 = "";

                        string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                        if (dm.existRecored(dclmAddressSelect) != 0)
                        {
                            string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                                "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                            dm.insertRecords(dclmAddressUpdate);
                        }
                        else
                        {
                            string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                                "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                            dm.insertRecords(dclmAddressInsert);
                        }
                    }

                }
                else if (i == 3)
                {
                    INDEX = 3;
                    LANG = "E";
                    //if (txtEngCopy32.Text.Trim() != "")
                    //{
                    //    if (this.txtengcopy3Name.Text != null) { NAME = this.txtengcopy3Name.Text.Trim(); } else { NAME = ""; }
                    //    if (this.txtEngCopy31.Text != null) { ADDRESS1 = this.txtEngCopy31.Text.Trim(); } else { ADDRESS1 = ""; }
                    //    if (this.txtEngCopy32.Text != null) { ADDRESS2 = this.txtEngCopy32.Text.Trim(); } else { ADDRESS2 = ""; }
                    //    //if (this.txtEngCopy33.Text != null) { ADDRESS3 = this.txtEngCopy33.Text.Trim(); } else { ADDRESS3 = ""; }
                    //   // if (this.txtEngCopy34.Text != null) { ADDRESS4 = this.txtEngCopy34.Text.Trim(); } else { ADDRESS4 = ""; }
                    //    string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                    //    if (dm.existRecored(dclmAddressSelect) != 0)
                    //    {
                    //        string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                    //            "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                    //        dm.insertRecords(dclmAddressUpdate);
                    //    }
                    //    else
                    //    {
                    //        string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                    //            "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                    //        dm.insertRecords(dclmAddressInsert);
                    //    }
                    //}
                    string dclmAddressUpdate = "INSERT INTO LPHS.DCLMADDRESSES_HIS select * from LPHS.DCLMADDRESSES WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                    dm.insertRecords(dclmAddressUpdate);
                    string dclmAddressRemove = "DELETE FROM LPHS.DCLMADDRESSES WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                    dm.insertRecords(dclmAddressRemove);
                }

                else if (i == 4)
                {
                    INDEX = 5;
                    LANG = "E";
                    if (TxtRegionAd1.Text.Trim() != "")
                    {
                        if (this.TxtRegionName.Text != null) { NAME = this.TxtRegionName.Text.Trim(); } else { NAME = ""; }
                        if (this.TxtRegionAd1.Text != null) { ADDRESS1 = this.TxtRegionAd1.Text.Trim(); } else { ADDRESS1 = ""; }
                        string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                        if (dm.existRecored(dclmAddressSelect) != 0)
                        {
                            string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                                "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                            dm.insertRecords(dclmAddressUpdate);
                        }
                        else
                        {
                            string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                                "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                            dm.insertRecords(dclmAddressInsert);
                        }
                    }
                }
                else if (i == 5)
                {
                    INDEX = 6;
                    LANG = "E";
                    if (TxtRegSalAddress2.Text.Trim() != "")
                    {
                        if (this.TxtRegSalAddress1.Text != null) { NAME = this.TxtRegSalAddress1.Text.Trim(); } else { NAME = ""; }
                        if (this.TxtRegSalAddress2.Text != null) { ADDRESS1 = this.TxtRegSalAddress2.Text.Trim(); } else { ADDRESS1 = ""; }
                        string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                        if (dm.existRecored(dclmAddressSelect) != 0)
                        {
                            string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                                "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                            dm.insertRecords(dclmAddressUpdate);
                        }
                        else
                        {
                            string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                                "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                            dm.insertRecords(dclmAddressInsert);
                        }
                    }
                }
                else if (i == 8)
                {
                    INDEX = 4;
                    LANG = "E";
                    //if (txtanotheradEng2.Text.Trim() != "")
                    //{
                    //    if (this.txtOtherEngName.Text != null) { NAME = this.txtOtherEngName.Text.Trim(); } else { NAME = ""; }
                    //    if (this.txtanotheradEng1.Text != null) { ADDRESS1 = this.txtanotheradEng1.Text.Trim(); } else { ADDRESS1 = ""; }
                    //    if (this.txtanotheradEng2.Text != null) { ADDRESS2 = this.txtanotheradEng2.Text.Trim(); } else { ADDRESS2 = ""; }
                    //    //if (this.txtanotheradEng3.Text != null) { ADDRESS3 = this.txtanotheradEng3.Text.Trim(); } else { ADDRESS3 = ""; }
                    //    //if (this.txtanotheradEng4.Text != null) { ADDRESS4 = this.txtanotheradEng4.Text.Trim(); } else { ADDRESS4 = ""; }
                    //    string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                    //    if (dm.existRecored(dclmAddressSelect) != 0)
                    //    {
                    //        string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                    //            "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                    //        dm.insertRecords(dclmAddressUpdate);
                    //    }
                    //    else
                    //    {
                    //        string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                    //            "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                    //        dm.insertRecords(dclmAddressInsert);
                    //    }
                    //}
                    string dclmAddressUpdate = "INSERT INTO LPHS.DCLMADDRESSES_HIS select * from LPHS.DCLMADDRESSES WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                    dm.insertRecords(dclmAddressUpdate);
                    string dclmAddressRemove = "DELETE FROM LPHS.DCLMADDRESSES WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                    dm.insertRecords(dclmAddressRemove);
                }

                #endregion

                NAME = NAME.Replace('\'', ' ');
                ADDRESS1 = ADDRESS1.Replace('\'', ' ');
                ADDRESS2 = ADDRESS2.Replace('\'', ' ');
                ADDRESS3 = ADDRESS3.Replace('\'', ' ');
                ADDRESS4 = ADDRESS4.Replace('\'', ' ');

                //string dclmAddressSelect = "select * from LPHS.DCLMADDRESSES where polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + "  ";
                //if (dm.existRecored(dclmAddressSelect) != 0)
                //{
                //    string dclmAddressUpdate = "UPDATE LPHS.DCLMADDRESSES SET NAME = '" + NAME + "' , ADDR1 = '" + ADDRESS1 + "' , ADDR2 = '" + ADDRESS2 + "' ," +
                //        "ADDR3 = '" + ADDRESS3 + "' , ADDR4 = '" + ADDRESS4 + "', upddate = " + int.Parse(this.setDate()[0]) + ", updepf = '" + epf + "' WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and INDX = " + INDEX + " ";
                //    dm.insertRecords(dclmAddressUpdate);

                //    if (txtEngCopy22.Text.Trim() == "" && txtEngCopy32.Text.Trim() == "")
                //    {
                //        string DeleteBranch = "DELETE FROM LPHS.DCLMADDRESSES WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and (INDX = 2 OR INDX = 3)";
                //        dm.insertRecords(DeleteBranch);
                //    }
                //}
                //else
                //{
                //    string dclmAddressInsert = "INSERT INTO LPHS.DCLMADDRESSES (POLNO ,MOS ,LANG ,INDX ,NAME ,ADDR1 ,ADDR2 ,ADDR3 ,ADDR4, entdate, entepf )" +
                //        "VALUES (" + polno + " ,'" + MOF + "' ,'" + LANG + "' ," + INDEX + " ,'" + NAME + "' ,'" + ADDRESS1 + "' ,'" + ADDRESS2 + "' ,'" + ADDRESS3 + "' ,'" + ADDRESS4 + "', " + int.Parse(this.setDate()[0]) + ", '" + epf + "'  )";
                //    dm.insertRecords(dclmAddressInsert);

                //    if (txtEngCopy22.Text.Trim() == "" && txtEngCopy32.Text.Trim() == "")
                //    {
                //        string DeleteBranch = "DELETE FROM LPHS.DCLMADDRESSES WHERE polno = " + polno + " and mos = '" + MOF + "'and LANG = '" + LANG + "' and (INDX = 2 OR INDX = 3)";
                //        dm.insertRecords(DeleteBranch);
                //    }
                //}
                NAME = string.Empty;
                ADDRESS1 = string.Empty;
                ADDRESS2 = string.Empty;
                ADDRESS3 = string.Empty;
                ADDRESS4 = string.Empty;
            }

            this.lblsuccess.Text = "Record Added Successfully!";

            dm.connclose();
        }
        catch (Exception ex)
        {
            dm.connclose();
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
        //btnaddOtherEng.Enabled = false;
    }
   
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.DropDownList1.SelectedItem.Text.Equals("-SELECT-"))
        {
            this.txtEngCopy22.Text = this.DropDownList1.SelectedItem.Text;
            this.txtEngCopy22.Text = this.txtEngCopy22.Text.ToUpper();
        }
        else
        {
            this.txtEngCopy22.Text = "";
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!this.DropDownList2.SelectedItem.Text.Equals("-SELECT-"))
        //{
        //    this.txtEngCopy32.Text = this.DropDownList2.SelectedItem.Text;
        //    this.txtEngCopy32.Text = this.txtEngCopy32.Text.ToUpper();
        //}
        //else
        //{
        //    this.txtEngCopy32.Text = "";
        //}
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!this.DropDownList3.SelectedItem.Text.Equals("-SELECT-"))
        //{
        //    this.txtanotheradEng2.Text = this.DropDownList3.SelectedItem.Text.ToUpper();
        //}
        //else
        //{
        //    this.txtanotheradEng2.Text = "";
        //}
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.DropDownList4.SelectedItem.Text.Trim().ToUpper().Equals("-SELECT-"))
        {
            this.TxtRegionAd1.Text = this.DropDownList4.SelectedItem.Text.ToUpper();
            TxtRegSalAddress2.Text = this.DropDownList4.SelectedItem.Text.ToUpper();
        }
        else
        {
            this.TxtRegionAd1.Text = "";
            TxtRegSalAddress2.Text = "";
        }
    }
}
