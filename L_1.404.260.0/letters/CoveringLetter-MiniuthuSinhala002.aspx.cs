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

public partial class letters_CoveringLetter_MiniuthuSinhala002 : System.Web.UI.Page
{
    private bool signatureDisplay;
    private bool IsDeferent;
    private int val;
    private string childName;

    protected void Page_Load(object sender, EventArgs e)
    {
        string EPF = "";

        if (PreviousPage != null)
        {
            signatureDisplay = this.PreviousPage.SIGNATUREDISPLAY;
            val = this.PreviousPage.Val;
            IsDeferent = this.PreviousPage.IsDeferentLetter;
            childName = this.PreviousPage.Childname;
        }

        if (!IsPostBack)
        {
            litad1.Text = Convert.ToString(this.PreviousPage.Ad1);
            litad2.Text = this.PreviousPage.Ad2;
            litad3.Text = this.PreviousPage.Ad3;
            litad4.Text = this.PreviousPage.Ad4;
            litname.Text = this.PreviousPage.Name;
            LtClmno.Text = Convert.ToString(this.PreviousPage.ClaimNo);
            Ltdue.Text = this.PreviousPage.DueYear;
            Ltdue2.Text=this.PreviousPage.DueYear;
            LtDate.Text = this.PreviousPage.DateOfBefore;
            litdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            litpolno.Text = Convert.ToString(this.PreviousPage.PolNo);
            Label1.Text = Convert.ToString(PreviousPage.BrName);
            if (LtDate.Text.Trim() != "")
                Panel1.Visible = true;
            else
                Panel1.Visible = false;
            litnameofdead.Text = this.PreviousPage.NameOfDeath;
            if (this.PreviousPage.TXT1 != "")
            {
                LtTxt1.Text = this.PreviousPage.TXT1 ;
            }
            if(this.PreviousPage.TXT2 != "")
            {
                Literal1.Text = this.PreviousPage.TXT2;
            }
        }

        #region Add signature 

        if (signatureDisplay)
        {
            lblSignature.Visible = true;
            lblName.Visible = true;
            lblepf.Visible = true;
            lblDesig.Visible = true;
            lbldip.Visible = true;
            lblComp.Visible = true;


            if (Session["EPFNum"] != null)
            {
                EPF = Session["EPFNum"].ToString();
            }

            else
            {
                Response.Redirect("SessionError.aspx");
            }

            if (EPF != "")
            {
                SignatureData signatureData = new SignatureData();
                signatureData = signatureData.getSignature(EPF);
                if (signatureData.Signature != null)
                {
                    lblSignature.Visible = true;
                    string ImageName = EPF.PadLeft(5, '0') + "_sign.png";
                    System.IO.File.WriteAllBytes(Server.MapPath("~/image/" + ImageName), signatureData.Signature);
                    SignatureImage.ImageUrl = "~/image/" + ImageName;
                    
                }
                else
                {
                    lblSignature.Visible = false;
                }
                this.lblName.Text = signatureData.UserName + " ";
                this.lbldip.Text = "Life Insurance Section";
                this.lblComp.Text = "Sri Lanka Insurance Corporation life Ltd";
                this.lblepf.Text = "( " + signatureData.EPF + " )";

                if (signatureData.Role != null)
                {
                    this.lblDesig.Text = signatureData.Role;
                }
                else
                {
                    this.lblDesig.Text = "Authorized Officer";
                }
            }
        }
        #endregion


        #region Task 39452

        if (IsDeferent)
        {
            pan1.Visible = false;
            pan2.Visible = true;
            this.lblchild.Text = childName;
            this.lblval.Text = val.ToString() + ".00";
        }
        #endregion


    }
}
