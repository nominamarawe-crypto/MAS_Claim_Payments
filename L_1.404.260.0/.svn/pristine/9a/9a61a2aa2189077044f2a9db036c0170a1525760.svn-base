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

public partial class intOfDeath2501Sin : System.Web.UI.Page
{
    private  int polno;
    private  string MOF;  
    //private string phname;
    private long cliamNo;
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
        if (day.Length < 2) day = "0" + day;

        ourDate = year + month + day;
        datetime[0] = ourDate;

        string y = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
        datetime[1] = y;
        return datetime;

    }
    DataManager formObj = new DataManager();

    private string LANG = "";
    private int INDEX = 0;
    private string NAME = "";
    private string ADDRESS1 = "";
    private string ADDRESS2 = "";
    private string ADDRESS3 = "";
    private string ADDRESS4 = "";
    string DNOD = "";
    private string poldocname;
    private string deathCertName;


    protected void Page_Load(object sender, EventArgs e)
    {
        string dreqSelect = "";
        string reqdesc = "";
        int reqcode = 0;
        int rows = 0;

        if (PreviousPage != null)//&& PreviousPage.IsCrossPagePostBack
        {
            polno = this.PreviousPage.Polno;
            MOF = this.PreviousPage.mof;
        }
        if (!Page.IsPostBack)
        {
            try
            {
                //--- nomi read ---    
                this.litpolno.Text = polno.ToString();
                string nomiselect = "select nomnam, nomad1, nomad2 from lund.nominee where polno = " + polno + " ";
                if (formObj.existRecored(nomiselect) != 0)
                {
                    formObj.readSql(nomiselect);
                    OracleDataReader nomireader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (nomireader.Read())
                    {
                        if (!nomireader.IsDBNull(0)) { NAME = nomireader.GetString(0); } else { NAME = ""; }
                        if (!nomireader.IsDBNull(1)) { ADDRESS1 = nomireader.GetString(1); } else { ADDRESS1 = ""; }
                        if (!nomireader.IsDBNull(2)) { ADDRESS2 = nomireader.GetString(2); } else { ADDRESS2 = ""; }
                    }
                    nomireader.Close();
                    nomireader.Dispose();

                    this.litname.Text = NAME;
                    this.litad1.Text = ADDRESS1;
                    this.litad2.Text = ADDRESS2;
                }
                else
                {
                    #region  //********* Name & Address Select **************
                    string DINAME = "";
                    string DIAD1 = "";
                    string DIAD2 = "";
                    string DIAD3 = "";
                    string DIAD4 = "";
                   

                    string dclmaddressSelect = "select  LANG, INDX, NAME, ADDR1, ADDR2, ADDR3, ADDR4 from LPHS.DCLMADDRESSES where POLNO = " + polno + " and MOS = '" + MOF + "' and lang = 'S' ";
                    if (formObj.existRecored(dclmaddressSelect) != 0)
                    {
                        formObj.readSql(dclmaddressSelect);
                        OracleDataReader dclmAdReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dclmAdReader.Read())
                        {
                            if (!dclmAdReader.IsDBNull(0)) { LANG = dclmAdReader.GetString(0); } else { LANG = ""; }
                            if (!dclmAdReader.IsDBNull(1)) { INDEX = dclmAdReader.GetInt32(1); } else { INDEX = 0; }
                            if (!dclmAdReader.IsDBNull(2)) { NAME = dclmAdReader.GetString(2); } else { NAME = ""; }
                            if (!dclmAdReader.IsDBNull(3)) { ADDRESS1 = dclmAdReader.GetString(3); } else { ADDRESS1 = ""; }
                            if (!dclmAdReader.IsDBNull(4)) { ADDRESS2 = dclmAdReader.GetString(4); } else { ADDRESS2 = ""; }
                            if (!dclmAdReader.IsDBNull(5)) { ADDRESS3 = dclmAdReader.GetString(5); } else { ADDRESS3 = ""; }
                            if (!dclmAdReader.IsDBNull(6)) { ADDRESS4 = dclmAdReader.GetString(6); } else { ADDRESS4 = ""; }

                            if (INDEX == 0)
                            {
                                this.litname.Text = NAME;
                                this.litad1.Text = ADDRESS1;
                                this.litad2.Text = ADDRESS2;
                                this.litad3.Text = ADDRESS3;
                                this.litad4.Text = ADDRESS4;
                            }
                            else if (INDEX == 1)
                            {
                                if ((NAME != null) && (!NAME.Equals("")))
                                {
                                    this.lblcopy1desc.Visible = true;
                                    this.litcopy1.Visible = true;
                                }

                                this.litcopy1.Text = NAME + "\" " + ADDRESS1 + " " + ADDRESS2 + " " + ADDRESS3 + " " + ADDRESS4;
                            }
                            else if (INDEX == 2)
                            {
                                if ((NAME != null) && (!NAME.Equals("")))
                                {
                                    this.lblcopy2dec.Visible = true;
                                    this.litcopy2.Visible = true;
                                }

                                this.litcopy2.Text = NAME + "\" " + ADDRESS1 + " " + ADDRESS2 + " " + ADDRESS3 + " " + ADDRESS4;
                            }
                            else if (INDEX == 3)
                            {
                                if ((NAME != null) && (!NAME.Equals("")))
                                {
                                    this.lblcopy3desc.Visible = true;
                                    this.litcopy3.Visible = true;
                                }

                                this.litcopy3.Text = NAME + "\" " + ADDRESS1 + " " + ADDRESS2 + " " + ADDRESS3 + " " + ADDRESS4;
                            }
                        }
                        dclmAdReader.Close();
                        dclmAdReader.Dispose();

                    //    string dthintSelect = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                    //    if (formObj.existRecored(dthintSelect) != 0)
                    //    {
                    //        formObj.readSql(dthintSelect);
                    //        OracleDataReader dthintReader = formObj.oraComm.ExecuteReader();
                    //        while (dthintReader.Read())
                    //        {
                    //            if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                    //            if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                    //        }
                    //        dthintReader.Close();
                    //    }

                    //    this.litnameofdead.Text = DNOD;
                    //  //  this.lblyrref.Text = epfStr;
                    //    this.litorref.Text = cliamNo.ToString();
                    //    this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                   }
                    else
                    {
                        string dthintSelect = "select DINAME, DIAD1, DIAD2, DIAD3, DIAD4, DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                        if (formObj.existRecored(dthintSelect) != 0)
                        {
                            formObj.readSql(dthintSelect);
                            OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                            while (dthintReader.Read())
                            {
                                if (!dthintReader.IsDBNull(0)) { DINAME = dthintReader.GetString(0); }
                                if (!dthintReader.IsDBNull(1)) { DIAD1 = dthintReader.GetString(1); }
                                if (!dthintReader.IsDBNull(2)) { DIAD2 = dthintReader.GetString(2); }
                                if (!dthintReader.IsDBNull(3)) { DIAD3 = dthintReader.GetString(3); }
                                if (!dthintReader.IsDBNull(4)) { DIAD4 = dthintReader.GetString(4); }
                                if (!dthintReader.IsDBNull(5)) { DNOD = dthintReader.GetString(5); }
                                if (!dthintReader.IsDBNull(6)) { cliamNo = dthintReader.GetInt64(6); }
                            }
                            dthintReader.Close();
                            dthintReader.Dispose();
                        }

                        this.litname.Text = DINAME;
                        this.litad1.Text = DIAD1;
                        this.litad2.Text = DIAD2;
                        this.litad3.Text = DIAD3;
                        this.litad4.Text = DIAD4;
                        this.litnameofdead.Text = DNOD;
                     //   this.lblyrref.Text = epfStr;
                        this.litorref.Text = cliamNo.ToString();
                        this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                    }

                    #endregion
                }
                string dthintSelect1 = "select DNOD, DCLM from LPHS.DTHINT where DPOLNO = " + polno + " and DMOS ='" + MOF + "' ";
                if (formObj.existRecored(dthintSelect1) != 0)
                {
                    formObj.readSql(dthintSelect1);
                    OracleDataReader dthintReader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dthintReader.Read())
                    {
                        if (!dthintReader.IsDBNull(0)) { DNOD = dthintReader.GetString(0); }
                        if (!dthintReader.IsDBNull(1)) { cliamNo = dthintReader.GetInt64(1); }
                    }
                    dthintReader.Close();
                    dthintReader.Dispose();
                }

                this.litnameofdead.Text = DNOD;
                //  this.lblyrref.Text = epfStr;
                this.litorref.Text = cliamNo.ToString();
                this.litdate.Text = this.setDate()[0].Substring(0, 4) + "/" + this.setDate()[0].Substring(4, 2) + "/" + this.setDate()[0].Substring(6, 2);
                  


                this.litpolno.Text = polno.ToString();
                bool existflag = false;
                dreqSelect = "select drcovtyp, drrema from lphs.dreq where drpol=" + polno + " and drtyp='" + MOF + "'  ";
                formObj.readSql(dreqSelect);
                OracleDataReader dreqreader = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreqreader.Read())
                {
                    existflag = true;
                    reqcode = dreqreader.GetInt32(0);

                    dreqSelect = "select DREQDESCSIN from lphs.dreqdesc where dreqcode=" + reqcode + "  ";
                    formObj.readSql(dreqSelect);
                    OracleDataReader dreqreader02 = formObj.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dreqreader02.Read())
                    {
                        if (reqcode == 9)
                        {
                            this.litnamepast.Visible = true;
                            this.litnameprev.Visible = true;
                            this.txtpoldocname.Visible = true;
                            this.tyxtdeathCertname.Visible = true;
                        }
                        if (!dreqreader02.IsDBNull(0)) { reqdesc = dreqreader02.GetString(0); } else { reqdesc = ""; }
                    }
                    int row = rows + 1;
                    this.createDynamicTable(row.ToString(), reqdesc, rows);
                    rows++;
                    //dreqreader02.Close();
                    //dreqreader02.Dispose();
                }
                dreqreader.Close();
                dreqreader.Dispose();

                if (!existflag)
                {
                    formObj.connclose();
                    throw new Exception("No Requirement Details!");
                }
                ViewState["polno"] = polno;
                ViewState["MOF"] = MOF;
            }
            catch (Exception ex)
            {
                formObj.connclose();
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        else
        {
            if (ViewState["polno"] != null) { polno = int.Parse(ViewState["polno"].ToString()); }
            if (ViewState["MOF"] != null) { MOF = ViewState["MOF"].ToString(); }
        }
    }
    private void createDynamicTable(string reqcode, string req, int rowNumber)
    {
        TableRow trow = new TableRow();
        TableCell tcell1 = new TableCell();
        TableCell tcell2 = new TableCell();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        lbl1.ID = "nominee" + rowNumber;
        lbl1.Attributes.Add("runat", "Server");
        lbl1.Attributes.Add("Name", "reqcode" + rowNumber); //Text Value
        lbl1.Text = reqcode + "'";

        lbl2.ID = "nominee" + rowNumber;
        lbl2.Attributes.Add("runat", "Server");
        lbl2.Attributes.Add("Name", "req" + rowNumber); //Text Value

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
        Table1.Rows.Add(trow);
        Table1.Rows[rowNumber].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        Table1.Rows[rowNumber].Cells[1].HorizontalAlign = HorizontalAlign.Left;
        Table1.Rows[rowNumber].Cells[0].VerticalAlign = VerticalAlign.Top;
        Table1.Rows[rowNumber].Cells[1].VerticalAlign = VerticalAlign.Top;
    }
    
    protected void btnprint_Click(object sender, EventArgs e)
    {
        poldocname = this.txtpoldocname.Text.Trim();
        deathCertName = this.tyxtdeathCertname.Text.Trim();
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
    public string Poldocname
    {
        get { return poldocname; }
        set { poldocname = value; }
    }
    public string DeathCertName
    {
        get { return deathCertName; }
        set { deathCertName = value; }
    }


}
