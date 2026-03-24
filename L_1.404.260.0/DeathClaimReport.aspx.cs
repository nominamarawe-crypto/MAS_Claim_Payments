using System;
using System.Collections.Generic; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeathClaimReport : System.Web.UI.Page
{
    private int fromdate, todate, policyno;
    private string criteria, searchby;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (validation())
        {
            if (ddlSearchBy.SelectedItem.Value == "D")
            {
                fromdate = int.Parse(this.txtfromdate.Text);
                todate = int.Parse(this.txttodate.Text);
            }
            else
            {
                policyno = int.Parse(this.txtPloicy.Text);
            }
            criteria = this.ddlSearchType.SelectedItem.Value;
            searchby = this.ddlSearchBy.SelectedItem.Value;

            Server.Transfer("~/DeathClaimReport01.aspx");
       }
        
    }
    private bool validation() {

        if (ddlSearchBy.SelectedItem.Value == "P")
        {
           if(string.IsNullOrEmpty(txtPloicy.Text))
           {
               lblError.Text = "Policy is required";
             return false;
           }
            else{
           return true;
           }
        }
        else
        {
           
            if(string.IsNullOrEmpty(txtfromdate.Text))
            {
                lblError.Text = "Formdate is required";
             return false;
            }
            else{

               if(string.IsNullOrEmpty(txttodate.Text))
               {
               lblError.Text = "Todate is required";
                return false;
                }
               else{
               return true;
           }
             
           }
        }
    
    }
    public int Fromdate
    {
        get { return fromdate; }
        set { fromdate = value; }
    }
    public int Todate
    {
        get { return todate; }
        set { todate = value; }
    }
    public int Policyno
    {
        get { return policyno; }
        set { policyno = value; }
    }
    public string Criteria
    {
        get { return criteria; }
        set { criteria = value; }
    }
    public string Searchby
    {
        get { return searchby; }
        set { searchby = value; }
    }
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSearchBy.SelectedItem.Value == "D")  
             {
                 pnl.Visible = true;
                 txtPloicy.Enabled = false;
                 txtPloicy.Text = string.Empty;
                 txtfromdate.Enabled = true;
                 txttodate.Enabled = true;
                 
             }
             else
             {

                 txtfromdate.Text = string.Empty;
                 txttodate.Text = string.Empty;
                 pnl.Visible = false;
                 txtPloicy.Enabled = true;
             }
    }
}
