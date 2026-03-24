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

public partial class PolReStat001 : System.Web.UI.Page
{
   
    private int polno;
    private int DOD;//Date of Death
    AppCode app = new AppCode();
    DataManager dm = new DataManager();
    User_Authentication objUserAuthentication;

    protected void Page_Load(object sender, EventArgs e)
    {
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

                #endregion

                //Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        this.txtpolnum.Text = "";
        this.txtDOD.Text = "";
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {

            DOD = int.Parse(this.txtDOD.Text.Trim());

            if ((DOD.ToString().Length != 8) || (!app.dateValid(DOD.ToString())))
            {
                this.cv1.IsValid = false;
                this.cv1.Text = "Invalid Last Due Date";
            }
            if (this.txtpolnum.Text == "")
            {
                this.cv1.IsValid = false;
                this.cv1.Text = "Invalid Policy Number Date";
            }
            polno = int.Parse(this.txtpolnum.Text.Trim());
            string Premast = "select * from LPHS.PREMAST where PMPOL=" + polno + "";
            string Lapse = "select * from  LPHS.LIFLAPS where LPPOL=" + polno + "";
            string maturity = "select * from LCLM.LIFMATS where LMPOL=" + polno + "";
            string ClimMaster = "select  PVOUNO from LCLM.LCMMAST where PPOLNO=" + polno + "";
            if (dm.existRecored(ClimMaster) != 0)
            {
                int VouNum = 0;
                dm.readSql(ClimMaster);
                OracleDataReader reader = dm.oraComm.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) { VouNum = int.Parse(reader.GetString(0)); } else { VouNum = 0; }
                }
                reader.Close();
                if (VouNum == 0)
                {
                    hdstat.Value = "CLM";
                }
                else
                {
                    throw new Exception("Maturity Already Paid.");
                }
            }
            else if (dm.existRecored(Premast) != 0)
            {
                hdstat.Value = "INF";
            }
            else if (dm.existRecored(Lapse) != 0)
            {
                hdstat.Value = "LPS";
            }
            else if (dm.existRecored(maturity) != 0)
            {
                hdstat.Value = "MAT";
            }
            else
            {
                hdstat.Value = "NO";
            }
            
        }
        catch (Exception exp)
        {
            dm.connClose();
            EPage.Messege = exp.Message;
            Response.Redirect("EPage.aspx");
        }
        Server.Transfer("PolReStat002.aspx");
    }
    public int PolNum
    {
        get { return polno; }
        set { polno = value; }
    }
    public int DeathDate
    {
        get { return DOD; }
        set { DOD = value; }
    }
}
