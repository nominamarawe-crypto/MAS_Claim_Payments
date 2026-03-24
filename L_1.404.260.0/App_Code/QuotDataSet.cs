using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for QuotDataSet
/// </summary>
/// 
[Serializable()]
public class QuotDataSet
{
    private int term, matyear, yr;
    private double matval, deathval, deathval1, deathval2, deathval3, deathval4, deathval5, interest=0;
    private string deathval1str;
    private List<QuotDataSet> datalist_mat=new List<QuotDataSet>();
    private List<QuotDataSet> datalist_dth = new List<QuotDataSet>();

	public QuotDataSet()
	{
		
	}
    public void Fetch_Maturity(int trm, double sumass, double propotion)
    {
        matyear = DateTime.Now.Year;
        matyear += trm;
        QuotDataSet A = new QuotDataSet();
        A.Term = trm;
        A.Matyear = matyear;
        A.Matval = this.MaturityCal(sumass, propotion);
        Datalist_Maturity.Add(A);
    }
    public void Fetch_Death(double sumass, double interest, double propotion, int trm, string lifecov)
    {     
        for (int i = 0; i < trm; i++)
        {
            QuotDataSet B = new QuotDataSet();
            B.Year = i + 1;
            B.Deathval = this.Deathonmaturity(sumass, propotion, B.Year, interest, lifecov);
            Datalist_Death.Add(B);
        }
            
    }
    public double MaturityCal(double sumass, double propotion)
    {
        return Math.Round((propotion * sumass / 100000), 2);
    }
    public double Deathcal(double sumass, double interest, double duration)
    {
        double deathamt = 0;
        //if (sumass > 2500000)
        //{
        //    deathamt = sumass * Math.Pow((interest / 100) + 1, duration) + 1500000;
        //}
        //else
        //{
        deathamt = sumass * Math.Pow((interest / 100) + 1, duration);          
        //}
        return Math.Round(deathamt, 2);
    }
    public double Deathonmaturity(double sumass, double propotion, double year, double interest, string lifecov)
    {
        double deathamt = 0;
        if (lifecov.Equals("Y"))
        {
            if (sumass <= 2500000)
            {
                deathamt = this.MaturityCal(sumass, propotion);
            }
            else
            {
                deathamt = this.Deathcal(sumass, interest, year);
                this.Interest = deathamt - sumass;
                deathamt += 1500000;
            }
        }
        else
        {
            deathamt = this.Deathcal(sumass, interest, year);
            this.Interest = deathamt - sumass;
        }
        //if (i+2  < year)
        //{
        //    deathamt = 0;
        //}
        //}
        return Math.Round(deathamt, 2);
    }
    public List<QuotDataSet> Datalist_Maturity
    {
        get { return datalist_mat; }
        set { datalist_mat = value;}
    }
    public List<QuotDataSet> Datalist_Death
    {
        get { return datalist_dth; }
        set { datalist_dth = value; }
    }
    public int Term
    {
        get { return term; }
        set { term = value; }
    }
    public int Matyear
    {
        get { return matyear; }
        set { matyear = value; }
    }
    public double Matval
    {
        get { return matval; }
        set { matval = value; }
    }
    public int Year
    {
        get { return yr; }
        set { yr = value; }
    }
    public double Deathval
    {
        get { return deathval; }
        set { deathval = value; }
    }
    public double Deathval1
    {
        get { return deathval1; }
        set { deathval1 = value; }
    }
    public double Deathval2
    {
        get { return deathval2; }
        set { deathval2 = value; }
    }
    public double Deathval3
    {
        get { return deathval3; }
        set { deathval3 = value; }
    }
    public double Deathval4
    {
        get { return deathval4; }
        set { deathval4 = value; }
    }
    public double Deathval5
    {
        get { return deathval5; }
        set { deathval5 = value; }
    }
    public string Deathval1str
    {
        get { return deathval1str; }
        set { deathval1str = value; }
    }
    public double Interest
    {
        get { return interest; }
        set { interest = value; }
    }
}
