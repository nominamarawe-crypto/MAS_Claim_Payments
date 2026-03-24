using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SwarnaJayanthiEnqueryPage : System.Web.UI.Page
{
    User_Authentication objUserAuthentication;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack != true)
        {
            string polNO = Request.QueryString["policyNo"];
            string dateOFDeath = Request.QueryString["dateOfDeath"];
            string mOS= Request.QueryString["mos"];
            string sJLastPaidDate = Request.QueryString["SJLastPayDate"];
            if ((polNO != null)  )
            {
                txtPolNo.Text = polNO;
                
            }
            if (dateOFDeath != null)
            {
                
                txtDateOfCalculation.Text = dateOFDeath;
            }


            if ((polNO != null) && (dateOFDeath != null) && (mOS != null) && (sJLastPaidDate != null))
            {
                int policynumber = int.Parse(polNO);
                int dateofdeath = int.Parse(dateOFDeath);
                int sJlastpaydate = int.Parse(polNO);
                SwarnaJayanthiCover ss = new SwarnaJayanthiCover(policynumber, dateofdeath, mOS, sJlastpaydate);

                ss.SwarnaJayanthiCalculation();

                GridView1.DataSource = ss.dt;
                GridView1.DataBind();
                lblTotalAmount.Text = ss.SJAmount.ToString();
                lblRefundableAmount.Text = ss.RefundableAmount.ToString();

                txtPolNo.Text = ss.PolicyNo.ToString();
                txtDateOfCommencement.Text = ss.CommenceDate.ToString();
                txtDateOfCalculation.Text = ss.DateOfCalc.ToString();
                txtDateOfFirstDayOfCalculation.Text = ss.GetFirstDateOfYear(ss.DateOfCalc).ToString();
                txtSJLastPayDate.Text = ss.LastSJPayDate.ToString();
            }

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
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDateOfCommencement.Text.Trim() == null || txtDateOfCommencement.Text.Trim() == "" || txtDateOfFirstDayOfCalculation.Text.Trim() == null || txtDateOfFirstDayOfCalculation.Text.Trim() == "")
            {
                txtDateOfCommencement.Text = "0";
                txtDateOfFirstDayOfCalculation.Text = "0";
            }
            int polNum = int.Parse(txtPolNo.Text.ToString());
            int p2 = int.Parse(txtDateOfCommencement.Text.ToString());
            int dateOfCalc = int.Parse(txtDateOfCalculation.Text.ToString());
            int SJayanthiLastPayDate = int.Parse(txtSJLastPayDate.Text.ToString());
            int polCommenceDate = int.Parse(txtDateOfCommencement.Text.ToString());
            string payType = ddlCalcType.SelectedItem.Value.ToString();//Selected value of death or refund

            SwarnaJayanthiCover ss = new SwarnaJayanthiCover(polNum, dateOfCalc, "M", SJayanthiLastPayDate, payType, polCommenceDate); //dateOfCalc == date of death
            //ss.SwarnaJayanthiCaculation();
            //ss.SwarnaJayanthiCaculation();
            ss.SwarnaJayanthiCalculation();

            GridView1.DataSource = ss.dt;
            GridView1.DataBind();
            lblTotalAmount.Text = ss.SJAmount.ToString();
            lblRefundableAmount.Text = ss.RefundableAmount.ToString();

            txtPolNo.Text = ss.PolicyNo.ToString();
            txtDateOfCommencement.Text = ss.CommenceDate.ToString();
            txtDateOfCalculation.Text = ss.DateOfCalc.ToString();
            txtDateOfFirstDayOfCalculation.Text = ss.GetFirstDateOfYear(ss.DateOfCalc).ToString();
            txtSJLastPayDate.Text = ss.LastSJPayDate.ToString();
        }
        catch (Exception ex)
        {
            //EPage.Messege = ex.Message;
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    public void CalculateSwarnaJayanthi()
    {



    }

    #region MyRegion
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    int p1 = int.Parse(txtPolNo.Text.ToString());
    //    int p2 = int.Parse(txtDateOfCommencement.Text.ToString());
    //    int p3 = int.Parse(txtDateOfCalculation.Text.ToString());
    //    int p4 = int.Parse(txtSJLastPayDate.Text.ToString());
    //    string p5 = ddlCalcType.SelectedItem.Value.ToString();
    //    int polCommenceDate = int.Parse(txtDateOfCommencement.Text.ToString());

    //    SwarnaJayanthiCover ss = new SwarnaJayanthiCover(p1, p3, "M", p4, p5, polCommenceDate);
    //    //ss.SwarnaJayanthiCaculation();
    //    //ss.SwarnaJayanthiCaculation();
    //    ss.NewSwarnaJayanthiCalculation();


    //    GridView1.DataSource = ss.dt;
    //    GridView1.DataBind();
    //    lblTotalAmount.Text = ss.SJAmount.ToString();
    //    lblRefundableAmount.Text = (ss.SJAmount / 2).ToString();//lblRefundableAmount.Text = ss.RefundableAmount.ToString();

    //    txtPolNo.Text = ss.PolicyNo.ToString();
    //    txtDateOfCommencement.Text = ss.CommenceDate.ToString();
    //    txtDateOfCalculation.Text = ss.DateOfCalc.ToString();
    //    txtDateOfFirstDayOfCalculation.Text = ss.GetFirstDateOfYear(ss.DateOfCalc).ToString();
    //    txtSJLastPayDate.Text = ss.LastSJPayDate.ToString();


    //} 
    #endregion
}
