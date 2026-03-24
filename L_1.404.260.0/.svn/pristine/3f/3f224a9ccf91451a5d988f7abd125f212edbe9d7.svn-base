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
using System.Data.Odbc;

public partial class OldClaimMain : System.Web.UI.Page
{
    DataManager dm;
    private string TraCode;
    private int polno;
    private long loanno;
    private double loancptl;
    CheckDefPrms defprm = new CheckDefPrms();
    private string dateofdeath;
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

                #endregion.

                //Change by Dulan Task 25215 - 2015-09-07 ********************************
            }
            catch (Exception ex)
            {
                EPage.Messege = ex.Message;
                Response.Redirect("EPage.aspx");
            }
        }
        dm = new DataManager();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        dm = new DataManager();
        string ExistPolno1 = "";
        string ExistPolno = "";
        string PolInMaturity = "";
        string premastpolno = "";
        string Lapsepolno = "";
        if(txtdthdt.Text!="")
        {
            dateofdeath = txtdthdt.Text;
        }

        #region Check Policy Number In DTHREF
        string SelectPrm = "SELECT * FROM LPHS.DTHREF WHERE DRPOLNO=" + int.Parse(txtpolno.Text) + "";
        if (dm.existRecored(SelectPrm) == 0)
        {
            ExistPolno = "select POLNO,Trim(TRANSCODE) from LPHS.DTHOUT WHERE POLNO=" + int.Parse(txtpolno.Text) + " and nvl(dthpro,'N')<>'Y' and ( Trim(TRANSCODE)='B' or Trim(TRANSCODE)='A' OR Trim(TRANSCODE)='C') ";
            ExistPolno1 = "select EXTPOL,EXTCL from LPHS.EXSURREN WHERE EXTPOL=" + int.Parse(txtpolno.Text) + " and Trim(EXTCL)='D'";
            premastpolno = "select PMPOL,PMCOD from lphs.premast where PMPOL=" + int.Parse(txtpolno.Text) + "";
            Lapsepolno = "select LPPOL,LPCOD from lphs.liflaps where LPPOL=" + int.Parse(txtpolno.Text) + "";
            PolInMaturity = "select LMPOL,LMTCD from lclm.lifmats where LMPOL=" + int.Parse(txtpolno.Text) + "";
           
            #region Check Policy Number In DTHOUT Table
            if (dm.existRecored(ExistPolno) != 0)
            {
                OracleDataReader red = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
                dm.readSql(ExistPolno);
                while (red.Read())
                {
                    TraCode = red.GetString(1);
                }
                red.Close();
            }
            #endregion


            #region Check Exit Table
            else if (dm.existRecored(ExistPolno) == 0)
            {               
                if (dm.existRecored(ExistPolno1) != 0)
                {
                    TraCode = "A";
                    // Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text + "&TraCode= " + TraCode + "");
                }                
            }
            #endregion

            #region Check Premast/Lapse
            if (dm.existRecored(ExistPolno1) == 0)
            {
                if (dm.existRecored(premastpolno) != 0)
                {
                    TraCode = "A";
                    // Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text + "&TraCode= " + TraCode + "");
                }
                else if (dm.existRecored(Lapsepolno) != 0)
                {
                    TraCode = "A";
                }
            }
            #endregion
            if ((dm.existRecored(ExistPolno) == 0)&&(dm.existRecored(ExistPolno1) == 0) && (dm.existRecored(premastpolno) == 0) && (dm.existRecored(Lapsepolno) == 0))
            {
                if (dm.existRecored(PolInMaturity) != 0)
                {
                    TraCode = "A";
                }
            }

            #region Check Loans
            if ((dm.existRecored(ExistPolno) != 0) || (dm.existRecored(ExistPolno1) != 0) || (dm.existRecored(PolInMaturity) != 0) || (dm.existRecored(premastpolno) != 0) || (dm.existRecored(Lapsepolno) != 0))
            {
                string Chcklntbl = "select LMPOL,LMLON,LMNCP from lphs.lplmast where LMPOL=" + int.Parse(txtpolno.Text) + " and LMNCP>0 and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
                if (dm.existRecored(Chcklntbl) != 0)
                {
                    OracleDataReader rd = dm.oraComm.ExecuteReader();
                    while (rd.Read())
                    {
                        if (!rd.IsDBNull(0)) { polno = rd.GetInt32(0); }
                        if (!rd.IsDBNull(1)) { loanno = rd.GetInt64(1); }
                        if (!rd.IsDBNull(2)) { loancptl = rd.GetDouble(2); }
                    }
                    rd.Close();
                    Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text + "&TraCode= " + TraCode + "&dthdt=" + dateofdeath + "&Isauth=false");
                    //EPage.Messege = "This Policy has a loan.(Loan No:" + loanno.ToString() + ",  Next Due Capital:"+loancptl.ToString("N2")+")  Please Settle it and ReTry.. ";
                    //Response.Redirect("EPage.aspx");
                }
                else
                {
                    Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text + "&TraCode= " + TraCode + "&dthdt=" + dateofdeath + "&Isauth=false");             
                }
            }
            else
            {
                EPage.Messege = "Sorry!! This Policy Number Doesn't exists.";
                Response.Redirect("EPage.aspx");
            }
            #endregion
        }
        else
        {
            EPage.Messege = "Sorry!! This Policy Number has already Rgistered...";
            Response.Redirect("EPage.aspx");    
        }
        #endregion
               
        //if (dm.existRecored(SelectPrm) == 0)
        //{
        //    if (dm.existRecored(ExistPolno) != 0)
        //    {
        //        OracleDataReader red=dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
        //        dm.readSql(ExistPolno);
        //        while(red.Read())
        //        {
        //            TraCode=red.GetString(1);
        //        }
        //        red.Close();
        //       // Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text+"&TraCode= " +TraCode+ "");
        //    }
        //    else if (dm.existRecored(ExistPolno) == 0)
        //    {
        //        TraCode = "A";
        //        if (dm.existRecored(ExistPolno1) != 0)
        //        {
        //           // Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text + "&TraCode= " + TraCode + "");
        //        }
                
        //    }
        //    if ((dm.existRecored(ExistPolno) != 0) || (dm.existRecored(ExistPolno1) != 0))
        //    {
        //        string Chcklntbl = "select LMPOL,LMLON,LMNCP from lphs.lplmast where LMPOL=" + int.Parse(txtpolno.Text) + " and LMNCP>0 and (lmset <> 'Y' or lmset is null) and (lmcd1 <> 'D' or lmcd1 is null)";
        //        if (dm.existRecored(Chcklntbl) != 0)
        //        {
        //            OracleDataReader rd = dm.oraComm.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                if (!rd.IsDBNull(0)) { polno = rd.GetInt32(0); }
        //                if (!rd.IsDBNull(1)) { loanno = rd.GetInt64(1); }
        //                if (!rd.IsDBNull(2)) { loancptl = rd.GetDouble(2); }
        //            }
        //            rd.Close();

        //            EPage.Messege = "This Policy has a loan.(Loan No:" + loanno.ToString() + ",  Next Due Capital:"+loancptl.ToString("N2")+")  Please Settle it and ReTry.. ";
        //            Response.Redirect("EPage.aspx");
        //        }
        //        else
        //        {                 
        //        Response.Redirect("DthOldEntry.aspx?pol=" + txtpolno.Text + "&TraCode= " + TraCode + "");             
        //        }
        //    }
        //    else
        //    {
        //        EPage.Messege = "Sorry!! This Policy Number Doesn't exists.";
        //        Response.Redirect("EPage.aspx");
        //    }
            
        //}
        //else
        //{
                   
        //}
    }
    protected void txtpolno_TextChanged(object sender, EventArgs e)
    {
        dm = new DataManager();
       
        int dtdt=0;
        if (txtpolno.Text != "")
        {
            string GetdtDate = "select DTOFDTH from lphs.dthout_temp where POLNO=" + int.Parse(txtpolno.Text.Trim()) + "";
            if (dm.existRecored(GetdtDate) != 0)
            {
                dm.readSql(GetdtDate);
                OracleDataReader red = dm.oraComm.ExecuteReader();
                while (red.Read())
                {
                    if (!red.IsDBNull(0)) { dtdt = red.GetInt32(0); } else { dtdt = 0; }
                }
                red.Close();
            }
            if (dtdt > 0)
            {
                txtdthdt.Text = dtdt.ToString();
            }
        }
    }
}
