using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


[Serializable()]
public class PolDet
{
    //******** surr001 ********
    public string polno;
    public int caldate;
    public string ttype;

    //******* surr002 **********
    private string phname;
    private int ageAtEntry;
    private int tableeka;
    private int termeka;
    private int DCO;
    private int exitym;
    private int exitymcorrect;
    private int mode;
    private double premium;
    private double sumassured;
    private string polstat;
    private string ad1;
    private string ad2;
    private string ad3;
    private string ad4;
    private string bonussSrrenderYN;
    private string reciepientName;
    private int bonussSrrenderyear;
    private int monthdiff;
    private int yeardiff;
    private int refdate;
    private double totdepamt;
    private string name1;
    private string name2;
    private string ageadmit;
    private string polass;
    private string yrref;
    private string otherpat;
    private double surrval;
    private double loanout;
    private double loanintout;
    private double availableamt;
    private double vestedBonus;
    private double surrrenderedbons;
    private double paidupval;
    private double svfacor;
    private int attainedage;
    private int agtcode;

    public string Otherpat {
        get { return otherpat; }
        set { otherpat = value; }
    }
    public string Yrref {
        get { return yrref; }
        set { yrref = value; }
    }
    public string Ageadmit{
        get { return ageadmit; }
        set { ageadmit = value; }
    }
    public string Polass {
        get { return polass; }
        set { polass = value; }
    }
    public string Name1 {
        get { return name1; }
        set { name1 = value; }
    }
    public string Name2 {
        get { return name2; }
        set { name2 = value; }
    }

    public string Polno{
        get { return polno; }
        set { polno = value; }
    }
    public string Ttype{
        get { return ttype; }
        set { ttype = value; }
    }
    public string Phname{
        get { return phname; }
        set { phname = value; }
    }
    public string Polstat{
        get { return polstat; }
        set { polstat = value; }
    }
    public string Ad1{
        get { return ad1; }
        set { ad1 = value; }
    }
    public string Ad2{
        get { return ad2; }
        set { ad2 = value; }
    }
    public string Ad3{
        get { return ad3; }
        set { ad3 = value; }
    }
    public string Ad4{
        get { return ad4; }
        set { ad4 = value; }
    }
    public string BonussSrrenderYN{
        get { return bonussSrrenderYN; }
        set { bonussSrrenderYN = value; }
    }
    public int Caldate
    {
        get { return caldate; }
        set { caldate = value; }
    }
    public int AgeAtEntry
    {
        get { return ageAtEntry; }
        set { ageAtEntry = value; }
    }
    public int Tableeka
    {
        get { return tableeka; }
        set { tableeka = value; }
    }
    public int Termeka
    {
        get { return termeka; }
        set { termeka = value; }
    }
    public int dCO
    {
        get { return DCO; }
        set { DCO = value; }
    }
    public int Exitym
    {
        get { return exitym; }
        set { exitym = value; }
    }
    public int Exitymcorrect
    {
        get { return exitymcorrect; }
        set { exitymcorrect = value; }
    }
    public double Sumassured
    {
        get { return sumassured; }
        set { sumassured = value; }
    }
    public int BonussSrrenderyear
    {
        get { return bonussSrrenderyear; }
        set { bonussSrrenderyear = value; }
    }
    public int Monthdiff
    {
        get { return monthdiff; }
        set { monthdiff = value; }
    }
    public int Yeardiff
    {
        get { return yeardiff; }
        set { yeardiff = value; }
    }

    public double Totdepamt {
        get { return totdepamt; }
        set { totdepamt = value; }
    }
    public double Premium {
        get { return premium; }
        set { premium = value; }
    }
    public int Refdate {
        get { return refdate; }
        set { refdate = value; }
    }
    public int Mode {
        get { return mode; }
        set { mode = value; }
    }
    public double Surrval{
     get { return surrval; }
        set { surrval = value; }
    }
    public double Loanout{
        get { return loanout; }
        set { loanout = value; }
    }
    public double Loanintout{
        get { return loanintout; }
        set { loanintout = value; }
    }
    public double Availableamt {

        get { return availableamt; }
        set { availableamt = value; }
    }

    public double VestedBonus {
        get { return vestedBonus; }
        set { vestedBonus = value; }
    }
    public double Surrrenderedbons {
        get { return surrrenderedbons; }
        set { surrrenderedbons = value; }
    }

    public double Paidupval {
        get { return paidupval; }
        set { paidupval = value; }
    }
    public string ReciepientName {
        get { return reciepientName; }
        set { reciepientName = value; }
    }
    public double Svfacor {
        get { return svfacor; }
        set { svfacor = value; }
    }
    public int Attainedage {
        get { return attainedage; }
        set { attainedage = value; }
    }
    public int Agtcode {
        get { return agtcode; }
        set { agtcode = value; }    
    }


}
