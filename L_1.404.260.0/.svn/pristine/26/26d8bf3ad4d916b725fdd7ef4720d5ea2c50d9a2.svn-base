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

public partial class SpouseCVREntry : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    private string epf;
    private string Fullname;
    private string Surname;
    private int DOB;
    private int Polno;
    private int CommDate;
    DataManager dm;
    private int DthDate;
    private int tble;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            epf = Session["EPFNum"].ToString();
            authorize authentication = new authorize();

            if (!Page.IsPostBack)
            {
                try
                {
                    //Change by Dulan Task 25215 - 2015-09-07 ********************************               
                    #region -------------- Check Authority -----------------------

                    objUserAuthentication = new User_Authentication();
                    if (!objUserAuthentication.IsUserAuthenticated(Convert.ToString(Session["UserId"]), "DTHCLM", "FUNC05"))
                    {
                        throw new Exception("You have no Authority for this option");
                    }

                    #endregion.

                    //Change by Dulan Task 25215 - 2015-09-07 ********************************
                }
                catch (Exception ex)
                {
                    EPage.Messege = ex.Message;
                    Response.Redirect("EPage.aspx");
                }
            }

            //if (Session["EPFNum"] != null && Session["brcode"] != null && Session["UserId"] != null)
            //{
            //    string userId = (string)Session["UserId"];
            //    if (!authentication.IsUserAuthenticated(userId, "DTH", "DTH_OUT003"))
            //    {
            //        EPage.Messege = "No Authority for this function  @ ";
            //        Response.Redirect("EPage.aspx", false);
            //    }
            //    else
            //    {
            //        //AgestmentDetails aj = new AgestmentDetails();
            //        //hdepf.Value = Session["EPFNum"].ToString();
            //        //hdbrn.Value = Session["brcode"].ToString();
            //        //hduserid.Value = Session["UserId"].ToString();               
            //    }
            //}
            //else
            //{
            //    EPage.Messege = "Your Session Variable Expired@ Please Log to the system again ";
            //    Response.Redirect("EPage.aspx", false);
            //}

            dm = new DataManager();
            if (Request.QueryString.Get("polno") != null)
            {
                Polno = int.Parse(Request.QueryString.Get("polno"));
                CommDate = int.Parse(Request.QueryString.Get("comdt"));
                txtpolno.Text = Polno.ToString();
                txtcomdt.Text = CommDate.ToString();
                hdfdthdt.Value = Request.QueryString.Get("dthdate");
                Session["ddt"] = hdfdthdt.Value;
                DthDate = int.Parse(Request.QueryString.Get("dthdate"));
            }
            else 
            {
                btn_back.Visible = false;
            }

            string GetPolperdet = "select polno,PRPERTYPE,DOB,SURNAME,FULLNAME from lund.polpersonal where polno=" + Polno + " and PRPERTYPE=2";
            if (dm.existRecored(GetPolperdet) != 0)
            {
                dm.readSql(GetPolperdet);
                OracleDataReader red = dm.oraComm.ExecuteReader();
                while (red.Read())
                {
                    if (!red.IsDBNull(0)) { Polno = red.GetInt32(0); } else { Polno = 0; }
                    if (!red.IsDBNull(2)) { DOB = red.GetInt32(2); } else { DOB = 0; }
                    if (!red.IsDBNull(3)) { Surname = red.GetString(3); } else { Surname = ""; }
                    if (!red.IsDBNull(4)) { Fullname = red.GetString(4); } else { Fullname = ""; }
                }
                red.Close();
                txtpolno.Text = Polno.ToString();
                txtdob.Text = DOB.ToString();
                if ((Fullname != null && Fullname != "") || (Surname != null && Surname != ""))
                {
                    string OtherName = Fullname.Remove((Fullname.Length - Surname.Length), Surname.Length);
                    txtothNames.Text = OtherName;
                    txtsurname.Text = Surname;
                }
            }

        }
        else
        {
            if (Session["ddt"] != null)
            {
                hdfdthdt.Value = Session["ddt"].ToString();
            }
            CheckPolNo chk = new CheckPolNo();
            tble=chk.GetTable(int.Parse(txtpolno.Text.Trim()));
            if (tble == 34 || tble == 38 || tble == 39 || tble == 46 || tble == 49)
            {
                lblmsg.Text = "You Cannot add Spouse for Table " + tble.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
           
        }
    }
    protected void btn_sub_Click(object sender, EventArgs e)
    {              
        string SelSPCVR="";
        string Flag = "";
        if (txtothNames.Text != "" || txtsurname.Text != "")
        {
            Fullname = txtothNames.Text.Trim() + " " + txtsurname.Text.Trim();
            Fullname = Fullname.ToUpper();
            Surname = txtsurname.Text.Trim();
            Surname = Surname.ToUpper();
        }
        if (txtdob.Text != "")
        {
            DOB = int.Parse(txtdob.Text);
        }
        if (txtpolno.Text != "")
        {
            Polno = int.Parse(txtpolno.Text.Trim());
        }
        if (txtcomdt.Text != "")
        {
            CommDate = int.Parse(txtcomdt.Text.Trim());
        }

        dm = new DataManager();
        CheckPolNo chkpol = new CheckPolNo();
        Flag=chkpol.CheckPolicyNumber(Polno);
        if (Flag != "" &&(tble != 34 && tble != 38 && tble != 39 && tble != 46 && tble != 49))           
        {
            try
            {
                dm.begintransaction();
                SelSPCVR = "select * from lund.polpersonal where POLNO=" + Polno + " and PRPERTYPE=2";
                if (dm.existRecored(SelSPCVR) == 0)
                {
                    string InsertManSP_CVR_POL = "insert into lund.polpersonal(PRPERTYPE,POLNO,DOB,FULLNAME,SURNAME,ENTERED_MODE)values(2," + Polno + "," + DOB + ",'" + Fullname + "','" + Surname + "',9)";
                    dm.insertRecords(InsertManSP_CVR_POL);
                }
                else
                {
                    string UpdateSP_CVR_POL = "update lund.polpersonal set DOB=" + DOB + ",FULLNAME='" + Fullname + "',SURNAME='" + Surname + "' where POLNO=" + Polno + " and ENTERED_MODE=9";
                    dm.insertRecords(UpdateSP_CVR_POL);
                }

                SelSPCVR = "select * from lund.rcover where RPOL=" + Polno + " and RCOVR=2";
                if (dm.existRecored(SelSPCVR) == 0)
                {
                    string InsertManSP_CVR_RCVR = "insert into lund.rcover(RPOL,RCOVR,RCOMDAT,ENTERED_MODE)values(" + Polno + ",2," + CommDate + ",9)";
                    dm.insertRecords(InsertManSP_CVR_RCVR);
                }
                else
                {
                    string UpdateManSP_CVR_RCVR = "update lund.rcover set RCOMDAT=" + CommDate + " where RPOL=" + Polno + " and ENTERED_MODE=9 and RCOVR=2";
                    dm.insertRecords(UpdateManSP_CVR_RCVR);
                }

                dm.commit();
                lblmsg.Text = "Spouse Cover added Successfully..";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                dm.rollback();
                lblmsg.Text = "Error while inserting Spouse Cover...";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            dm.connClose();
        }
        else
        {
            if (Flag == "")
            {
                lblmsg.Text = "This Policy Number doesn't exist in the database...";
            }
            if (tble == 34 || tble == 38 || tble == 39 || tble == 46 || tble == 49)
            {
                lblmsg.Text = "You Cannot add Spouse for Table " + tble.ToString();
                Btn_back1.Visible = true;
            }
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("DthOldEntry.aspx?pol=" + int.Parse(txtpolno.Text.Trim()) + "&dthdt=" + int.Parse(hdfdthdt.Value) + "");
    }
    protected void Btn_back1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}
    
