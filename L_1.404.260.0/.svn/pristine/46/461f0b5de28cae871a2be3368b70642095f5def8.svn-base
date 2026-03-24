using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Class1
/// </summary>
public class surrenderFuction
{
	public surrenderFuction()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public double[] surrenderFunc(string polno, string ttype, string bonussSrrender, int bonussSrrenderyear, int ageAtEntry, int caldate)
    {

        double[] surrenderArr = new double[9];

        //********** global as in prev ********
        string calcdate = caldate.ToString();
           
            int tableeka=0;
            int termeka=0;
            int DCO=0;
            int exitym=0;
            int exitymcorrect=0;
            double sumassured=0;
            string polstat="";
                       
            int monthdiff=0;
            int yeardiff=0;

        //************ local v.bles ***********

        int lastpymntdatemnth = 0;
        int lastpymntdateyear = 0;
        int lastpymntdateym = 0;
        int nextaffectingym;
        int calcyear = 0;
        int calcmonth = 0;

        int DCOyear = 0;
        int DCOmnth = 0;
        int demandcount = 0;
        int earrliestmonth = 0;
        int earliestyear = 0;
        int earliestym = 0;
        string earrliestmonthstr = "";

        bool demandread = false;
        bool premastread = false;

        int demanddate = 0;

        //************** VARIABLES FOR SURRENDER AND BONUS *********


        string DCOstr = "";
       
   
        int commyr;
        int commmnth;
        int durationmnths;
        int durationyrs;
        int attainedage;
        double ouTerm;
        int bonuscount;
        double totbonus = 0;
        double totsurrbonus = 0;
        double vestedBonus = 0;
        double surrrenderedbons = 0;
        double svfactor;
        double surrvalue;
        double paidPrems;
        double paidupval;
        int surrbonuscount;
    
        //--------------------

       

        try {

            DataManager objDM = new DataManager();

            //*********************************** PREMAST ****************
            int monthproduct = 0;
            int monthdeduct;
            string mysql01 = "select pmtbl, pmtrm, pmsum, pmmod, pmprm, pmdue, pmcom from LPHS.PREMAST where pmpol='" + polno + "'";
            objDM.readSql(mysql01);

            OracleDataReader mypremastreader = objDM.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (mypremastreader.Read())
            {
                premastread = true;
                DCO = mypremastreader.GetInt32(6);
                DCOstr = DCO.ToString();
                string DCOyrstr = Convert.ToString(DCO).Substring(0, 4);
                string DCOmnthstr = Convert.ToString(DCO).Substring(4, 2);
                int modeeka = mypremastreader.GetInt32(3);

                switch (modeeka)
                {

                    case 1: monthproduct = 12;
                        break;
                    case 2: monthproduct = 6;
                        break;
                    case 3: monthproduct = 3;
                        break;
                    case 4: monthproduct = 1;
                        break;
                    default: break;
                }


                DCOyear = int.Parse(DCOyrstr);
                DCOmnth = int.Parse(DCOmnthstr);

                //************* Getting Next Affecting Date ***********************

                int lastpymntdate = mypremastreader.GetInt32(5);
                string lastpymntyearstr = Convert.ToString(lastpymntdate).Substring(0, 4);
                string lastpymntmnthstr = Convert.ToString(lastpymntdate).Substring(4, 2);
                int lastpymntyear = int.Parse(lastpymntyearstr);
                int lastpymntmnth = int.Parse(lastpymntmnthstr);

                lastpymntdatemnth = lastpymntmnth - 1;

                if (lastpymntdatemnth == 0)
                {
                    lastpymntdatemnth = 12;
                    lastpymntdateyear = lastpymntyear - 1;

                }
                else
                {
                    lastpymntdateyear = lastpymntyear;
                }

                if (Convert.ToString(lastpymntdatemnth).Length < 2)
                {
                    string lastpymntdatemnthstr = "0" + Convert.ToString(lastpymntdatemnth);
                    nextaffectingym = int.Parse(Convert.ToString(lastpymntdateyear) + lastpymntdatemnthstr);
                }
                else
                {
                    nextaffectingym = int.Parse(Convert.ToString(lastpymntdateyear) + Convert.ToString(lastpymntdatemnth));

                }

                //************* Earliest Date **************************

                string calcyrstr = calcdate.Substring(0, 4);
                string calcmnthstr = calcdate.Substring(4, 2);
                calcyear = int.Parse(calcyrstr);
                calcmonth = int.Parse(calcmnthstr);
                earrliestmonth = calcmonth - 6;
                earliestyear = calcyear;


                if ((earrliestmonth < 0) || (earrliestmonth == 0))
                {
                    earrliestmonth = 12 + calcmonth - 6;

                    earliestyear = earliestyear - 1;
                }

                string earliestymstr;

                if ((Convert.ToString(earrliestmonth)).Length < 2)
                {
                    earrliestmonthstr = "0" + Convert.ToString(earrliestmonth);
                    earliestymstr = Convert.ToString(earliestyear) + earrliestmonthstr;
                }
                else
                {
                   earliestymstr = Convert.ToString(earliestyear) + Convert.ToString(earrliestmonth);
                }


                earliestym = int.Parse(earliestymstr);


                //************* DEMAND **********************************

                string mydemandsql = "select pdcod, pddue from LPHS.DEMAND where pdpol='" + polno + "' ";
                objDM.readSql(mydemandsql);
                OracleDataReader mydemandreader = objDM.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (mydemandreader.Read())
                {
                    demandread = true;
                    string pdcodestr = mydemandreader.GetString(0);
                    if ((pdcodestr.Equals("1")) || (pdcodestr.Equals("2")) || (pdcodestr.Equals("3")))
                    {
                        demanddate = mydemandreader.GetInt32(1);

                        if (demanddate > nextaffectingym)
                        {
                            lastpymntdateym = nextaffectingym;



                           //*********************
                        }
                        else if ((demanddate <= nextaffectingym) && (demanddate > earliestym))
                        {
                            demandcount = demandcount + 1;
                            lastpymntdateym = demanddate;

                        }
                        else if ((demanddate <= nextaffectingym) && (demanddate < earliestym))
                        {
                            lastpymntdateym = earliestym;
                        }
                        else { }


                        //else
                        //{

                        //    demandcount = demandcount + 1;
                        //    earliestym = demanddate;

                        //    if (nextaffectingym < earliestym)
                        //    {
                        //        lastpymntdateym = nextaffectingym;
                        //    }
                        //    else
                        //    {
                        //        lastpymntdateym = earliestym;

                        //    }
                        //}
                    }
                    else
                    {
                        lastpymntdateym = nextaffectingym;
                    }

                }
                mydemandreader.Close();
                mydemandreader.Dispose();
                if (demandread == false)
                {
                    lastpymntdateym = nextaffectingym;
                }

                lastpymntdateyear = int.Parse(Convert.ToString(lastpymntdateym).Substring(0, 4));
                lastpymntdatemnth = int.Parse(Convert.ToString(lastpymntdateym).Substring(4, 2));

                //********* 20070119 insertion ********************************

                yeardiff = lastpymntdateyear - DCOyear;
                monthdiff = lastpymntdatemnth - DCOmnth;
                if (monthdiff < 0)
                {
                    monthdiff = lastpymntdatemnth + 12 - DCOmnth;
                    yeardiff--;
                }

                if (modeeka == 1)
                {
                    if (monthdiff > 0) { monthdiff = 0; yeardiff++; }

                }
                else if (modeeka == 2)
                {
                    if (monthdiff >= 6) { monthdiff = 0; yeardiff++; }
                    else { monthdiff = 6; }

                }
                else if (modeeka == 3)
                {

                    if (monthdiff >= 9) { monthdiff = 0; yeardiff++; }
                    else if (monthdiff >= 6 && monthdiff < 9) { monthdiff = 9; }
                    else if (monthdiff >= 3 && monthdiff < 6) { monthdiff = 6; }
                    else { monthdiff = 0; }
                }
                else if (modeeka == 4)
                {
                    if (monthdiff >= 12) { monthdiff = 0; yeardiff++; }
                }
                else { }

                if (demandcount > 0)
                {
                    monthdeduct = monthproduct * (demandcount - 1);
                    int nettotmonths = ((yeardiff * 12) + monthdiff) - monthdeduct;
                    double divisioneka = nettotmonths / 12;
                    yeardiff = (int)Math.Floor(divisioneka);
                    monthdiff = nettotmonths % 12;
                }
                                      
               
                polstat = "INFORCE";
               
                tableeka = mypremastreader.GetInt32(0);
                
                termeka = mypremastreader.GetInt32(1);
               
                sumassured = mypremastreader.GetDouble(2);
               
                exitym = lastpymntdateym;

            }
            mypremastreader.Close();
            mypremastreader.Dispose();
            // ******************** LIFLAPS *********************************
            if (!premastread)
            {
                int mode = 0;
                string mysql02 = "select lpcom, lptbl, lptrm, lpsum, lpmod, lpprm, lpdue  from LPHS.LIFLAPS where lppol='" + polno + "' ";
                objDM.readSql(mysql02);
                OracleDataReader mylapsreader = objDM.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                while (mylapsreader.Read())
                {

                    polstat = "LAPSED";
                     
                    tableeka = mylapsreader.GetInt32(1);
                    
                    termeka = mylapsreader.GetInt32(2);
                    
                    sumassured = mylapsreader.GetDouble(3);
                    DCO = mylapsreader.GetInt32(0);
                    DCOstr = DCO.ToString();
                    mode = mylapsreader.GetInt32(4);
                    exitym = mylapsreader.GetInt32(6);
                    string exityrstr = Convert.ToString(exitym).Substring(0, 4);
                    string exitmnthstr = Convert.ToString(exitym).Substring(4, 2);

                    string DCOyrstr = Convert.ToString(DCO).Substring(0, 4);
                    string DCOmnthstr = Convert.ToString(DCO).Substring(4, 2);

                    int exityear = int.Parse(exityrstr);
                    int exitmonth = int.Parse(exitmnthstr);
                    DCOyear = int.Parse(DCOyrstr);
                    DCOmnth = int.Parse(DCOmnthstr);

                    //************ eyear amd emonth ******

                    lastpymntdateyear = exityear;
                    lastpymntdatemnth = exitmonth - 1;
                    if (lastpymntdatemnth == 0) { lastpymntdatemnth = 12; lastpymntdateyear--; }
                                        
                }

                mylapsreader.Close();
                mylapsreader.Dispose();

                yeardiff = lastpymntdateyear - DCOyear;
                if (yeardiff < 0)
                {
                    objDM.connclose();
                    throw new Exception("Policy Commenced After Being Lapsed!");
                }
                monthdiff = lastpymntdatemnth - DCOmnth;
                if (monthdiff < 0)
                {
                    monthdiff = lastpymntdatemnth + 12 - DCOmnth;
                    yeardiff--;
                }
                if (yeardiff < 0)
                {
                    objDM.connclose();
                    throw new Exception("Policy Commenced After Being Lapsed!");
                }

                monthdiff++;

                if (monthdiff >= 12)
                {
                    monthdiff = 0;
                    yeardiff++;
                }

                //********* 20070119 insertion ********************************
                           
                if (mode == 1)
                {
                    if (monthdiff > 0) { monthdiff = 0; yeardiff++; }

                }
                else if (mode == 2)
                {
                    if (monthdiff >= 6) { monthdiff = 0; yeardiff++; }
                    else { monthdiff = 6; }

                }
                else if (mode == 3)
                {

                    if (monthdiff >= 9) { monthdiff = 0; yeardiff++; }
                    else if (monthdiff >= 6 && monthdiff < 9) { monthdiff = 9; }
                    else if (monthdiff >= 3 && monthdiff < 6) { monthdiff = 6; }
                    else { monthdiff = 0; }
                }
                else if (mode == 4)
                {
                    if (monthdiff >= 12) { monthdiff = 0; yeardiff++; }
                }
                else { }
                
                //-----------------------------------------------------------------
            }

            //********************** Duration ***************************

            string  calcyrstr01 = calcdate.Substring(0, 4);
            string  calcmnthstr01 = calcdate.Substring(4, 2);
            calcyear = int.Parse(calcyrstr01);
            calcmonth = int.Parse(calcmnthstr01);

            int calcday = int.Parse(calcdate.Substring(6, 2));

            string commyrstr = DCOstr.Substring(0, 4);
            string commmnthstr = DCOstr.Substring(4, 2);
            commyr = int.Parse(commyrstr);
            commmnth = int.Parse(commmnthstr);

            if (calcday < 15)
            {
                durationmnths = calcmonth - commmnth - 1;
            }
            else
            {
                durationmnths = calcmonth - commmnth;

            }
                        
            durationyrs = calcyear - commyr;

            if (durationmnths < 0)
            {
                durationyrs = durationyrs - 1;
                durationmnths = 12 + calcmonth - commmnth - 1;
            }

                                                if (termeka != 10 && durationyrs < 3)
                                                {
                                                    objDM.connclose();
                                                    throw new Exception();
                                                }
                                                else if (termeka == 10 && durationyrs < 2)
                                                {
                                                    objDM.connclose();
                                                    throw new Exception();
                                                }



            attainedage = durationyrs + ageAtEntry;

            if (durationmnths > 8)
            { attainedage++; }

           

            ouTerm = termeka - durationyrs;

            if (durationmnths > 3 && durationmnths < 9)
            {
                ouTerm = ouTerm - (0.5);
            }
            else if ((12 - durationmnths) < 6)
            {
                ouTerm = ouTerm - 1;
            }

                                    if (ouTerm == 0.5)
                                    {
                                        ouTerm = 1;
                                    }
                                    if (ouTerm == 0)
                                    {
                                        throw new Exception();
                                    }


            //************************** Bonus Calculation *********************************

            bool flag = false;
            int DCOym = int.Parse(Convert.ToString(DCO).Substring(0, 4));
            bonuscount = yeardiff;
            string incrementcountstr = "";
            string incrementcountstrdclr = "";

            int i;

            DataManager newbonmanager = new DataManager();

            for (i = 1; i < (bonuscount + 1); i++)
            {
                if (i < 10)
                {
                    incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                }
                else
                {
                    incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                }
            }

            incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));



            string bonsql = "select " + incrementcountstr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + tableeka + " ";

            newbonmanager.readSql(bonsql);
            OracleDataReader bonfilereader = newbonmanager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (bonfilereader.Read())
            {
                flag = true;
                for (int j = 0; j < bonuscount; j++)
                {
                    double annualbonus = bonfilereader.GetDouble(j);
                    totbonus = totbonus + annualbonus;

                }

            }
            bonfilereader.Close();
            bonfilereader.Dispose();

            if (!flag)
            { totbonus = 0; }


            vestedBonus = (totbonus * sumassured) / 1000;

            if (tableeka == 34)///change on 2008/10/16 for tabel 34
            {
                vestedBonus = totbonus;
            }
           
            
            //*************************************** Bonus Logic ******************************************

            //************** Inforce ****************************************

            if (polstat.Equals("INFORCE"))
            {

                if (bonussSrrender.Equals("N"))
                {

                    if (termeka < bonuscount)
                    {
                        totbonus = 0;
                       

                    }
                    else
                    {
                        //this.lblbonval.Text = String.Format("{0:N}", vestedBonus);
                    }

                }

               //**************** Inforce and bonus suurendered ************************************

                else
                {
                    surrbonuscount = bonussSrrenderyear - commyr + 1;
                    incrementcountstr = "";
                    i = 0;

                    if (termeka < bonuscount)
                    {
                        totbonus = 0;
                       
                    }
                    else
                    {

                        for (i = 1; i < (surrbonuscount + 1); i++)
                        {
                            if (i < 10)
                            {
                                incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                                incrementcountstrdclr = incrementcountstrdclr + "BONY" + "0" + Convert.ToString(i) + ", ";
                            }
                            else
                            {
                                incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                                incrementcountstrdclr = incrementcountstrdclr + "BONY" + Convert.ToString(i) + ", ";
                            }


                        }

                        incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));
                        incrementcountstrdclr = incrementcountstrdclr.Substring(0, incrementcountstrdclr.LastIndexOf(","));



                        string bonsqlinf = "select " + incrementcountstr + "," + incrementcountstrdclr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + tableeka + " ";

                        newbonmanager.readSql(bonsqlinf);
                        OracleDataReader bonfilereaderinf = newbonmanager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                        while (bonfilereaderinf.Read())
                        {
                            flag = true;
                            for (int j = 0; j < surrbonuscount; j++)
                            {
                                double annualbonus = bonfilereaderinf.GetDouble(j);
                                int bondeclaredyr = bonfilereaderinf.GetInt32(j + surrbonuscount);
                                if (bondeclaredyr > bonussSrrenderyear)
                                { break; }
                                else
                                { totsurrbonus = totsurrbonus + annualbonus; }
                            }

                        }
                        bonfilereaderinf.Close();
                        bonfilereaderinf.Dispose();

                        surrrenderedbons = (totsurrbonus * sumassured) / 1000;
                        //   surrrenderedbons = vestedBonus - surrrenderedbons;
                          

                    }


                }

            }

             //*************** policy lapsed *********************************************

            else
            {
                if (bonussSrrender.Equals("N"))
                {
                    if (termeka < bonuscount)
                    {
                        totbonus = 0;
                    }
                    else
                    {
                        // this.lblbonval.Text = string.Format("{0:N}", vestedBonus);
                    }
                }

                 //*********** Lapse and bonus surrendered *****************************

                else
                {
                    surrbonuscount = bonussSrrenderyear - commyr + 1;
                    incrementcountstr = "";
                    i = 0;

                    if (termeka < bonuscount)
                    {
                        totbonus = 0;
                      
                    }
                    else
                    {

                        for (i = 1; i < (surrbonuscount + 1); i++)
                        {
                            if (i < 10)
                            {
                                incrementcountstr = incrementcountstr + "BONB" + "0" + Convert.ToString(i) + ", ";
                                incrementcountstrdclr = incrementcountstrdclr + "BONY" + "0" + Convert.ToString(i) + ", ";
                            }
                            else
                            {
                                incrementcountstr = incrementcountstr + "BONB" + Convert.ToString(i) + ", ";
                                incrementcountstrdclr = incrementcountstrdclr + "BONY" + Convert.ToString(i) + ", ";
                            }

                        }

                        incrementcountstrdclr = incrementcountstrdclr.Substring(0, incrementcountstrdclr.LastIndexOf(","));
                        incrementcountstr = incrementcountstr.Substring(0, incrementcountstr.LastIndexOf(","));


                        string bonsqlapse = "select " + incrementcountstr + ", " + incrementcountstrdclr + " from lphs.lplbons where lplbons.bonyea = " + DCOym + " and lplbons.bontab=" + tableeka + " ";

                        newbonmanager.readSql(bonsqlapse);
                        OracleDataReader bonfilereaderlapse = newbonmanager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);

                        while (bonfilereaderlapse.Read())
                        {
                            flag = true;
                            for (int j = 0; j < (surrbonuscount); j++)
                            {
                                double annualbonus = bonfilereaderlapse.GetDouble(j);
                                int bondeclaredyr = bonfilereaderlapse.GetInt32(j + surrbonuscount);
                                if (bondeclaredyr > bonussSrrenderyear)
                                { break; }
                                else
                                { totsurrbonus = totsurrbonus + annualbonus; }

                            }

                        }
                        bonfilereaderlapse.Close();
                        bonfilereaderlapse.Dispose();

                        surrrenderedbons = (totsurrbonus * sumassured) / 1000;

                    }

                }


            }

            //****************** Surrender Value Calculaiton **************************

            double unexpiredDuratnCeil = Math.Ceiling(ouTerm);
            double unexpiredDuratnflr = Math.Floor(ouTerm);


            bool flag2 = false;
            bool flag3 = false;
            double svfactorflr = 0;
            double svfactorceil = 0;
            int termsvfs = 0;

            //************ table Change ********************

            if ((tableeka == 5) || (tableeka == 27) || (tableeka == 14))
            {
                termsvfs = 0;
            }
            else
            {
                termsvfs = termeka;
            }


            DataManager svfmanager = new DataManager();
            string sqlsvflread1 = "select svfval4 from lphs.lplsvfs where svftab=" + tableeka + " and svfterm=" + termsvfs + " and svfage=" + attainedage + " and svfoterm=" + unexpiredDuratnflr + "  ";
            string sqlsvflread2 = "select svfval4 from lphs.lplsvfs where svftab=" + tableeka + " and svfterm=" + termsvfs + " and svfage=" + attainedage + " and svfoterm=" + unexpiredDuratnCeil + "  ";

            svfmanager.readSql(sqlsvflread1);
            OracleDataReader svfreader1 = svfmanager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (svfreader1.Read())
            {
                flag2 = true;
                svfactorflr = svfreader1.GetDouble(0);

            }
            svfreader1.Close();
            svfreader1.Dispose();

            svfmanager.readSql(sqlsvflread2);
            OracleDataReader svfreader2 = svfmanager.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            while (svfreader2.Read())
            {
                flag3 = true;
                svfactorceil = svfreader2.GetDouble(0);

            }
            svfreader2.Close();
            svfreader2.Dispose();

            if ((!flag2) && (!flag3))
            {
                svfactor = 0;
            }

            svfactor = ((svfactorceil + svfactorflr) / 2) / 10000;


            

            if (ttype.Equals("S"))
            {
                paidPrems = (double)yeardiff + ((double)monthdiff / 12);
            }
            else
            {
                paidPrems = (double)yeardiff;
            }


            if (tableeka == 29)
            {

                sumassured += (0.05 * yeardiff * sumassured);
                paidupval = ((sumassured / termeka) * paidPrems) + vestedBonus;
                surrvalue = (((sumassured / termeka) * paidPrems) + vestedBonus) * svfactor;

            }
            else
            {

                paidupval = ((sumassured / termeka) * paidPrems) + vestedBonus;

                surrvalue = (((sumassured / termeka) * paidPrems) + vestedBonus) * svfactor;

            }


           

            if (surrrenderedbons > 0)
            {
                paidupval = paidupval - surrrenderedbons;  //vestedBonus;
                surrvalue = (((sumassured / termeka) * paidPrems) + (vestedBonus - surrrenderedbons)) * svfactor;
                vestedBonus = vestedBonus - surrrenderedbons;
            }

            if ((tableeka == 13) && (termeka == 20))
            {
                if (durationyrs < 10)
                { surrvalue = surrvalue; }

                else if (((durationyrs == 10) || (durationyrs > 10)) && (durationyrs < 15))
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.2))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.2));
                }

                else if (((durationyrs == 15) || (durationyrs > 15)) && (durationyrs < 20))
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.4))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.4));
                }

                else
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.6))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.6));
                }

            }
            else if ((tableeka == 13) && (termeka == 15))
            {
                if (durationyrs < 5)
                { surrvalue = surrvalue; }

                else if (((durationyrs == 5) || (durationyrs > 5)) && (durationyrs < 10))
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.2))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.2));
                }

                else if (((durationyrs == 10) || (durationyrs > 10)) && (durationyrs < 15))
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.4))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.4));
                }

                else
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.6))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.6));
                }


            }
            else if ((tableeka == 13) && (termeka == 10))
            {
                if (durationyrs < 4)
                { surrvalue = surrvalue; }

                else if (((durationyrs == 4) || (durationyrs > 4)) && (durationyrs < 7))
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.2))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.2));
                }

                else if (((durationyrs == 7) || (durationyrs > 7)) && (durationyrs < 10))
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.3))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.3));
                }

                else
                {
                    surrvalue = ((((sumassured / termeka) * paidPrems) + vestedBonus) - (sumassured * (0.5))) * svfactor;
                    paidupval = paidupval - (sumassured * (0.5));
                }

            }
            else
            { surrvalue = surrvalue; }


            if (ttype.Equals("L"))
            {
                surrvalue = surrvalue * (0.9);
            }
            else
            {
                surrvalue = surrvalue;
            }

            // **************** fill Grid (Loan File) ***************************


            DataManager objgrid = new DataManager();

            string loansql = "select lmlon as Loan_Number,lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, lmset, lmcd1  from lphs.lplmast where lmpol=" + polno + "";

            objgrid.readSql(loansql);
            OracleDataReader myloanreader = objgrid.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            int rows = 0;
            double loantotal = 0;
            double loaninttot = 0;
            double availableamt = 0;
            bool loanflag = false;

            while (myloanreader.Read())
            {
                loanflag = true;
                double[] arr = new double[9];
                long LoanNum = myloanreader.GetInt64(0);
                int lmpdt = myloanreader.GetInt32(1);
                int lmnid = myloanreader.GetInt32(2);
                int lmlrd = myloanreader.GetInt32(3);
                double lmpit = myloanreader.GetDouble(4);
                double lmnit = myloanreader.GetDouble(5);
                double lmpcp = myloanreader.GetDouble(6);
                double lmncp = myloanreader.GetDouble(7);
                double lmipy = myloanreader.GetDouble(8);
                double lmcpy = myloanreader.GetDouble(9);
                double lmitr = myloanreader.GetDouble(10);
                double lmcit = myloanreader.GetDouble(11);
                double lmccp = myloanreader.GetDouble(12);
                int lmcdt = myloanreader.GetInt32(13);
                int lmmdt = myloanreader.GetInt32(14);
                string lmset = "";
                if (!myloanreader.IsDBNull(15))
                {
                    lmset = myloanreader.GetString(15);
                }
                string lmcd1 = "";
                if (!myloanreader.IsDBNull(16))
                {
                    lmcd1 = myloanreader.GetString(16);
                }



                if ((!lmset.Equals("Y")) && (!(lmcd1.Equals("D"))))
                {
                    arr = calcAllValues(lmpdt, lmnid, lmlrd, lmpit, lmnit, lmpcp, lmncp, lmipy, lmcpy, lmitr, lmcit, lmccp, lmcdt, lmmdt, caldate);

                    loantotal += arr[5];
                    loaninttot += arr[8];

                    
                    rows++;
                }


            }
            myloanreader.Close();
            myloanreader.Dispose();

            availableamt = Math.Round((surrvalue - (loantotal + loaninttot)), 2);

                       
            if (loanflag)
            {
               
            }

            surrenderArr[0] = svfactor;
            surrenderArr[1] = surrvalue;
            surrenderArr[2] = surrrenderedbons;
            surrenderArr[3] = availableamt;
            surrenderArr[4] = loantotal;
            surrenderArr[5] = loaninttot;
            surrenderArr[6] = availableamt;
            surrenderArr[7] = yeardiff;
            surrenderArr[8] = monthdiff;

            objDM.connclose();
            newbonmanager.connclose();
            svfmanager.connclose();
            objgrid.connclose();

        }
        catch(Exception ex){
            //objDM.connclose();
            throw ex;
        }


    return surrenderArr;
    
    }

    //********************************* c# version of loan clculation function **************************************

    public static string ZeroFill(int seqNo, int iNumLength)
    {
        int iLength = Convert.ToString(seqNo).Length;
        int numOfZero = iNumLength - iLength;
        string temp = "0";
        if (numOfZero != 0)
        {
            for (int i = 0; i < (numOfZero - 1); i++)
            { temp = temp + "0"; }

            string ZeroFill = temp + Convert.ToString(seqNo);
            return ZeroFill;
        }
        else
        {
            string ZeroFill = Convert.ToString(seqNo);
            return ZeroFill;
        }

    }
    //******************** getMonthType **************************

    public static int getMonthType(int mm, int yyyy)
    {
        int dates = 0;
        if ((mm == 1) || (mm == 3) || (mm == 5) || (mm == 7) || (mm == 8) || (mm == 10) || (mm == 12))
        { dates = 31; }

        if ((mm == 4) || (mm == 6) || (mm == 9) || (mm == 11))
        { dates = 30; }

        if ((mm == 2) && ((yyyy % 4) != 0))
        { dates = 28; }

        if ((mm == 2) && ((yyyy % 4) == 0))
        { dates = 29; }

        return dates;

    }

    //******************** getDateDif ****************************


    public static string getDateDif(int date1, int date2, string a)
    {
        int d1 = int.Parse(Convert.ToString(date1).Substring(6, 2));
        int m1 = int.Parse(Convert.ToString(date1).Substring(4, 2));
        int y1 = int.Parse(Convert.ToString(date1).Substring(0, 4));
        int d2 = int.Parse(Convert.ToString(date2).Substring(6, 2));
        int m2 = int.Parse(Convert.ToString(date2).Substring(4, 2));
        int y2 = int.Parse(Convert.ToString(date2).Substring(0, 4));
        int dt1 = 0;
        int mn1 = 0;
        int mn2 = 0;
        int ye1 = 0;

        if (d1 >= d2)
        {
            dt1 = d1 - d2;
            mn1 = m1;
        }
        else
        {
            dt1 = d1 + getMonthType(m1, y1) - d2;
            mn1 = m1 - 1;
        }
        if (mn1 >= m2)
        {
            mn2 = mn1 - m2;
            ye1 = y1;
        }
        else
        {
            mn2 = mn1 + 12 - m2;
            ye1 = y1 - 1;
        }
        if (mn1 >= m2)
        {
            mn2 = mn1 - m2;
            ye1 = y1;
        }
        else
        {
            mn2 = mn1 + 12 - m2;
            ye1 = y1 - 1;
        }
        if (ye1 >= y2)
        {
            ye1 = ye1 - y2;
        }
        else
        {
            ye1 = 0;
        }

        string getDateDif = ZeroFill(ye1, 4) + a + ZeroFill(mn2, 2) + a + ZeroFill(dt1, 2);
        return getDateDif;

    }

    //******************* calcNextDue *********************************

    public static string calcNextDue(int dateLD)
    {
        if (dateLD != 0)
        {
            int iyear = int.Parse(Convert.ToString(dateLD).Substring(0, 4));
            int iMonth = int.Parse(Convert.ToString(dateLD).Substring(4, 2));
            int iDate = int.Parse(Convert.ToString(dateLD).Substring(6, 2));

            iMonth += 6;

            if (iMonth > 12)
            {
                iMonth -= 12;
                iyear += 1;

            }
            string calcNextDue = Convert.ToString(iyear) + ZeroFill(iMonth, 2) + ZeroFill(iDate, 2);
            return calcNextDue;
        }
        else
        {
            string calcNextDue = "0";
            return calcNextDue;
        }

    }

    //******************* GraceDate *************************

    public static string GraceDate(int date1)
    {

        if (date1 != 0)
        {
            int iYear = 0;
            int iMonth = 0;
            int iDate = 0;

            int yy = int.Parse(Convert.ToString(date1).Substring(0, 4));
            int mm = int.Parse(Convert.ToString(date1).Substring(4, 2));
            int dd = int.Parse(Convert.ToString(date1).Substring(6, 2));
            int nOfDtsInMon = getMonthType(mm, yy);
            iYear = yy;
            int dtTemp = dd + 15;
            if ((dtTemp < nOfDtsInMon) || (dtTemp == nOfDtsInMon))
            {
                iMonth = mm;
                iDate = dtTemp;
            }
            else
            {
                iMonth = mm + 1;
                iDate = (dtTemp % nOfDtsInMon);
                if (iMonth == 13)
                {
                    iMonth = 1;
                    iYear = yy + 1;
                }
            }

            string GraceDate = Convert.ToString(iYear) + ZeroFill(iMonth, 2) + ZeroFill(iDate, 2);
            return GraceDate;

        }
        else
        {
            string GraceDate = "0";
            return GraceDate;

        }
    }

    //******************* getDateDif ***********************

    public static double batchRun(double amtNDI, double amtLDC, double intRate, int matDate, int dtLDD, int dtDOP)
    {
        int dtNx = int.Parse(calcNextDue(dtLDD));
        int dtLst = 0;
        int dtNxt = 0;
        int dts = 0;
        int mnth = 0;
        double batchRun = 0;

        if (dtDOP > dtNxt)
        {
            dtLst = dtNx;
            dtNxt = int.Parse(calcNextDue(dtNx));
        }
        else
        {
            dtLst = dtLDD;
            dtNxt = dtNx;
        }

        if ((dtLst < matDate) && (matDate < dtNxt))
        {
            dts = int.Parse(getDateDif(matDate, dtLst, "").Substring(6, 2));

            if (dts > 15)
            {
                mnth = int.Parse(getDateDif(matDate, dtLst, "").Substring(4, 2)) + 1;
            }
            else
            {
                mnth = int.Parse(getDateDif(matDate, dtLst, "").Substring(4, 2));
            }

            batchRun = ((amtNDI + amtLDC) * ((intRate * mnth) / 1200)) + amtNDI;
            return batchRun;
        }
        else
        {
            batchRun = ((amtNDI + amtLDC) * (intRate / 200)) + amtNDI;
            return batchRun;
        }

    }

    //****************** calcNotInGrPeriod ******************************

    public static double[] calcNotInGrPeriod(int dtLDD, int dtNDD, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, int brCond, double amtCAofIP, double amtCAofCap)
    {
        double amtNDI_f = 0.0;
        double amtNDC_f = 0.0;
        double amtLDI_f = 0.0;
        double amtLDC_f = 0.0;
        double[] arrLoanData = new double[8];

        if (amtInPay != 0)
        {
            amtNDI_f = amtNDI - amtInPay;
            amtNDC_f = amtNDC - amtCapPay;
            amtLDI_f = amtNDI;
            amtLDC_f = amtNDC;

        }
        else
        {
            amtNDI_f = amtNDI;
            amtNDC_f = amtNDC;
            amtLDI_f = amtLDI;
            amtLDC_f = amtLDC;

        }


        arrLoanData[0] = dtLDD;
        arrLoanData[1] = dtNDD;
        arrLoanData[2] = amtLDI_f;
        arrLoanData[3] = amtNDI_f;
        arrLoanData[4] = amtLDC_f;
        arrLoanData[5] = amtNDC_f;
        arrLoanData[6] = amtCAofIP;
        arrLoanData[7] = amtCAofCap;

        return arrLoanData;

    }

    //****************** calcInGrPeriod *****************************

    public static double[] calcInGrPeriod(int dtLDD, int dtNDD, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, double intRate, int matDate, int dtDOP)
    {

        //  double amtNDC_f = amtNDC - amtCapPay;
        //  double amtLDI_f = amtNDI - amtInPay;

        //  double amtNDI_f = batchRun(amtLDI_f, amtLDC, intRate, matDate, dtLDD, dtDOP);

        double[] arrLoanData = new double[8];
        arrLoanData[0] = dtLDD;
        arrLoanData[1] = dtNDD;
        arrLoanData[2] = amtLDI;    // _f;
        arrLoanData[3] = amtNDI;    // _f;
        arrLoanData[4] = amtLDC;
        arrLoanData[5] = amtNDC;    // _f;
        arrLoanData[6] = 0;
        arrLoanData[7] = 0;

        return arrLoanData;

    }

    //************************* calcNewB *************************************

    public static double[] calcNewB(int dtLDD, int dtNDD, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, int brCond, double intRate, int matDate, double amtCAofIP, double amtCAofCap, int dtDOP)
    {
        double nxtDueInt = 0;

        if (brCond == 0)
        {
            dtNDD = dtNDD;
            nxtDueInt = amtNDI;
        }
        else
        {
            dtNDD = int.Parse(calcNextDue(dtLDD));
            nxtDueInt = batchRun(amtNDI, amtLDC, intRate, matDate, dtLDD, dtDOP);
        }
        amtLDI = nxtDueInt;
        double amtNDI_f = nxtDueInt - amtInPay;

        amtLDC = amtNDC;
        double amtNDC_f = amtNDC - amtCapPay;

        double amtCACap = amtCAofCap;
        double[] arrLoanData = new double[8];
        arrLoanData[0] = dtLDD;
        arrLoanData[1] = dtNDD;
        arrLoanData[2] = amtLDI;
        arrLoanData[3] = amtNDI_f;
        arrLoanData[4] = amtLDC;
        arrLoanData[5] = amtNDC_f;
        arrLoanData[6] = amtCAofIP;
        arrLoanData[7] = amtCAofCap;

        return arrLoanData;
    }

    //********************** calcLoanInt ******************************
    // additional 2 parameters included

    public static double[] calcLoanInt(int dtLDD, int dtNDD, int dtDOP, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, double intRate, int dtDOC, int matDate, int caAddCond, double amtCAofIP, double amtCAofCap)
    {
        int needBr = 0;
        double[] calcLoanInt;
        int dtEOGP = int.Parse(GraceDate(dtLDD));
        int dtNDofDOC = int.Parse(calcNextDue(dtDOC));
        int dtND = int.Parse(calcNextDue(dtLDD));

        if ((dtDOP < dtNDofDOC) && (dtDOP != 0))
        {
            if (dtNDD == 0)
            {
                needBr = 1;
            }
            else
            {
                needBr = 0;
            }

            calcLoanInt = calcNewB(dtLDD, dtND, amtNDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, needBr, intRate, matDate, amtCAofIP, amtCAofCap, dtDOP);
            return calcLoanInt;
        }

       // ***** else if 1 ***************

        else if ((dtLDD < dtDOP) && (dtDOP <= dtEOGP))
        {
            double amtNDI_cal = (amtNDI - (amtLDC * (intRate / 200))) / ((intRate / 200) + 1);
            if (amtNDI_cal < 1)
            {
                amtNDI_cal = 0;
            }

            calcLoanInt = calcInGrPeriod(dtLDD, dtNDD, amtLDI, amtNDI_cal, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, matDate, dtDOP);
            return calcLoanInt;
        }

            // ********** else if 2 ********

        else if ((dtEOGP < dtDOP) && (dtDOP <= dtNDD))
        {
            calcLoanInt = calcNotInGrPeriod(dtLDD, dtNDD, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, 0, amtCAofIP, amtCAofCap);
            return calcLoanInt;
        }

            /*   20061004
            // *********** else if 3 ************

        else if (dtDOP > dtNDD)
        {
            int dtLstDD = dtNDD;			//set last due date
            int dtNxtDD = int.Parse(calcNextDue(dtNDD));  //set next due date

            //calculate grace period
            int dtGraceDate = int.Parse(GraceDate(dtNDD));

            if (dtDOP > dtGraceDate)
            {
                double nxtDueInt = batchRun(amtNDI, amtLDC, intRate, matDate, dtLDD, dtDOP);
                calcLoanInt = calcNotInGrPeriod(dtLstDD, dtNxtDD, amtNDI, nxtDueInt, amtLDC, amtNDC, amtInPay, amtCapPay, 1, amtCAofIP, amtCAofCap);
                return calcLoanInt;
            }
            else
            {
                calcLoanInt = calcInGrPeriod(dtLstDD, dtNxtDD, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, matDate, dtDOP);
                return calcLoanInt;
            }

        }
             
             */

        else
        {
            calcLoanInt = new double[8];
            return calcLoanInt;
        }
    }



    //********************* calcAllValues ********************************



    public static double[] calcAllValues(int dtLDD, int dtNDD, int dtDOP, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, double intRate, double amtCAofIP, double amtCAofCap, int dtDOC, int matDate, int today)
    {
        double currInt = 0;
        int dts = 0;
        int mnth = 0;
        double[] arr = new double[9];
        double[] fstSet;

        if (dtDOP == 0)
        {
            dtDOP = dtLDD;
        }

        if (dtDOP > dtLDD)
        {
            fstSet = calcLoanInt(dtLDD, dtNDD, dtDOP, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, dtDOC, matDate, 0, amtCAofIP, amtCAofCap);
        }
        else
        {
          //  fstSet = calcLoanInt(dtLDD, dtNDD, today, amtLDI, amtNDI, amtLDC, amtNDC, 0, 0, intRate, dtDOC, matDate, 0, amtCAofIP, amtCAofCap);

            fstSet = calcInGrPeriod(dtLDD, dtNDD, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, matDate, dtDOP);

        }

        for (int i = 0; i < fstSet.Length; i++)
        {
            arr[i] = fstSet[i];
        }

        int dtNDofDOC = int.Parse(calcNextDue(dtDOC));
        if (matDate <= today)
        {
            today = matDate;
        }
        //*************** big logic ******************************
        if ((fstSet[5]) != 0)
        {
            if ((fstSet[1]) < today)                            
            {
                if (today < int.Parse(GraceDate((int)fstSet[1])))
                {

                    currInt = fstSet[3];
                    //  return currInt;
                }
                else
                {

                    dts = int.Parse(getDateDif(today, (int)fstSet[1], "").Substring(4, 6));

                    if (dts > 15)
                    {
                        mnth = int.Parse(getDateDif(today, (int)fstSet[1], "").Substring(4, 6)) + 1;
                    }
                    else
                    {
                        mnth = int.Parse(getDateDif(today, (int)fstSet[1], "").Substring(4, 6));
                    }
                    double k = intRate / 200;			// rate for 6 months

                    currInt = fstSet[3] + (((fstSet[5] + fstSet[3]) * k) * (mnth / 6));
                    //  return currInt;

                }
            }
            else
            {

                if (today < dtNDofDOC)              // corrected
                {
                    currInt = fstSet[3];
                    // return currInt;
                }
                else
                {

                    if (today < int.Parse(GraceDate((int)fstSet[0])))
                    {
                        currInt = fstSet[3];
                        //    return currInt;
                    }
                    else
                    {

                        dts = int.Parse(getDateDif(today, (int)fstSet[0], "").Substring(6, 2));

                        if (dts > 15)
                        {
                            mnth = int.Parse(getDateDif(today, (int)fstSet[0], "").Substring(4, 2)) + 1;
                        }
                        else
                        {
                            mnth = int.Parse(getDateDif(today, (int)fstSet[0], "").Substring(4, 2));
                        }

                        double aNDI = fstSet[3] + amtCAofIP;

                        //---------- new insertion - 20061004 ----------- get the date Different till the maturity

                        int Matdts = 0;
                        int matMonth = 0;
                        double iRateDivider = 0.0;

                        if (matDate < fstSet[1])
                        {

                            Matdts = int.Parse(getDateDif(matDate, (int)fstSet[0], "").Substring(6, 2));

                            if (Matdts > 15)
                            {
                                matMonth = int.Parse(getDateDif(matDate, (int)fstSet[0], "").Substring(4, 2)) + 1;

                            }
                            else
                            {
                                matMonth = int.Parse(getDateDif(matDate, (int)fstSet[0], "").Substring(4, 2));

                            }

                            iRateDivider = 1200 / matMonth;

                        }
                        else
                        {

                            iRateDivider = 200;
                            matMonth = 6;

                        }

                        //-------------------------------------

                        double k = intRate / iRateDivider;			// rate for 6 months

                        double amtIforL6M = (aNDI - (fstSet[5] + amtCAofCap) * k) / (k + 1);    //calculate the NDI of last 6 th month -> derived from (amtIforL6M + fstSet(5))k + amtIforL6M = aNDI 
                        currInt = ((aNDI - amtIforL6M) * mnth / matMonth) - amtCAofIP + amtIforL6M;
                        //  return currInt;
                    }

                }

            }

        }
        else
        {
            currInt = 0;
            //  return currInt;
        }

        //******** returning value *********

        arr[8] = currInt;
        return arr;


    }


}
