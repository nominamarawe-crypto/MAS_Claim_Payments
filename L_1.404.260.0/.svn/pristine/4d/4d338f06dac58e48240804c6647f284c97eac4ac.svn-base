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

public partial class loanCalculation : System.Web.UI.Page
{
     
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           // this.testlbl.Text = ZeroFill(25,4);
           // this.testlbl.Text = getDateDif(20060825,20060625,"");
           // this.testlbl.Text = calcNextDue(20060825);
           // this.testlbl.Text = Convert.ToString(getMonthType(08, 2006));
           // this.testlbl.Text = GraceDate(20060825);
           // this.testlbl.Text = Convert.ToString(batchRun(double amtNDI, double amtLDC, double intRate, int matDate, int dtLDD, int dtDOP));
           // this.testlbl.Text = Convert.ToString(batchRun(200, 200, 15, 20080826, 20060426, 20060826));
           // this.testlbl.Text = Convert.ToString(calcNotInGrPeriod(20060825, 20060425, 100, 100, 100, 100, 1000, 1000, 10, 200, 200)[7]);
           //this.testlbl.Text = Convert.ToString(calcInGrPeriod(20060825, 20060425, 100, 100, 100, 100, 1000, 1000, 10, 200, 200)[5]);
           // this.testlbl.Text = Convert.ToString(calcNewB(20060825, 20060425, 100, 100, 100, 100, 1000, 1000, 10, 15, 20050302, 200, 200, 20)[6]);
           // this.testlbl.Text = Convert.ToString(calcLoanInt(20060825, 20060425, 100, 100, 100, 100, 1000, 1000, 10, 15, 20050302, 200, 200, 20, 20060706)[6]);
          //  this.testlbl.Text = Convert.ToString(calcMatureValues(20060825, 20060425, 20050302, 25000, 35600, 25000, 21000, 25000, 22000, 21, 2000, 25000, 20030605, 20070502, 20060828));

            /*
             
            string x = "20060503";
            string x1 = x.Substring(0,4);
            string x2 = x.Substring(4,2);
            string x3 = x.Substring(6,2); 

            this.testlbl.Text = x1+" "+x2+" "+ x3;
            
             */


        }
        catch (Exception ex)
        {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }

        
    }

    //*********************** Functions ****************************
    //******************** Zero Fill *******************************

    public static string ZeroFill(int seqNo, int iNumLength)
    {
        int iLength = Convert.ToString(seqNo).Length;
        int numOfZero = iNumLength - iLength;
        string temp = "0";
        if (numOfZero != 0)
        {
            for (int i = 0; i < (numOfZero-1); i++)
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
        if (( mm == 1 )||( mm == 3 ) ||( mm == 5 ) ||( mm == 7 ) ||( mm == 8 ) ||( mm == 10 ) || ( mm == 12 ) )
        { dates = 31;  }

        if (( mm == 4 ) ||( mm == 6 ) ||( mm == 9 ) ||( mm == 11 ) )
        { dates = 30; }
        
        if ( (mm == 2) && ((yyyy % 4) != 0))
        { dates = 28; }

        if ((mm == 2) && ((yyyy % 4) == 0))
        { dates = 29; }

        return dates;

    }

    //******************** getDateDif ****************************


    public static string getDateDif(int date1, int date2, string a)
    {
        string getDateDif = "";
        if (date1 > date2)
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

            getDateDif = ZeroFill(ye1, 4) + a + ZeroFill(mn2, 2) + a + ZeroFill(dt1, 2);
           
        }
        else { getDateDif = "00000000"; }
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
        else {
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
        else {
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

        if (dtDOP > dtNxt) {
		dtLst = dtNx;
		dtNxt = int.Parse(calcNextDue(dtNx));
        }
	    else{
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
        else {
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

        //if (amtInPay != 0)
        if ((amtInPay != 0) || (amtCapPay != 0))        //--- modifyied on 20070601
        {
            amtNDI_f = amtNDI - amtInPay;
            amtNDC_f = amtNDC - amtCapPay;
            amtLDI_f = amtNDI;
            amtLDC_f = amtNDC;

        }
        else {
            amtNDI_f = amtNDI;
            amtNDC_f = amtNDC;
            amtLDI_f = amtLDI;
            amtLDC_f = amtLDC;
        
        }
               
        arrLoanData[0]= dtLDD;
        arrLoanData[1]= dtNDD;
        arrLoanData[2] = amtLDI_f;
        arrLoanData[3] = amtNDI_f;
        arrLoanData[4] = amtLDC_f;
        arrLoanData[5] = amtNDC_f;
        arrLoanData[6]= amtCAofIP;
        arrLoanData[7]= amtCAofCap;
       
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
        double amtNDI_f = 0;
        double amtNDC_f = 0;

        if (brCond == 0)
        {
            dtNDD = dtNDD;
            nxtDueInt = amtNDI;
            amtLDC = amtNDC;                 //-------- 20070626 ------
            amtNDC_f = amtNDC - amtCapPay;   //-------- 20070626 ------
        }
        else
        {
            dtNDD = int.Parse(calcNextDue(dtLDD));
            amtNDC_f = amtLDC;
            nxtDueInt = batchRun(amtNDI, amtLDC, intRate, matDate, dtLDD, dtDOP);
            amtLDC = amtNDC_f;      //  amtLDC become 0, because of the batch run function
        }

        amtLDI = nxtDueInt;
        amtNDI_f = nxtDueInt - amtInPay;

        //amtLDC = amtNDC;
        //double amtNDC_f= amtNDC - amtCapPay ;

        double amtCACap = amtCAofCap ;
        double[] arrLoanData = new double[8];
        arrLoanData[0]= dtLDD;
		arrLoanData[1]= dtNDD;
		arrLoanData[2]= amtLDI;
		arrLoanData[3]= amtNDI_f;
		arrLoanData[4]= amtLDC;
		arrLoanData[5]= amtNDC_f;
		arrLoanData[6]= amtCAofIP;
        arrLoanData[7]= amtCAofCap;

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

        //if ((dtDOP < dtNDofDOC) && (dtDOP != 0))
        if ((dtDOP <= dtNDofDOC) && (dtDOP != 0))           //-------- 20070626 ------
        {
            if (dtNDD == 0) { needBr = 1; }
            else { needBr = 0; }

            calcLoanInt = calcNewB(dtLDD, dtND, amtNDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, needBr, intRate, matDate, amtCAofIP, amtCAofCap, dtDOP);
            return calcLoanInt;
        }
        
            // ***** else if 1 ***************

                //else if ((dtLDD < dtDOP) && (dtDOP <= dtEOGP))
                else if ((dtLDD <= dtDOP) && (dtDOP <= dtEOGP))      //-------- 20070626 ------
                {
                    //double amtNDI_cal = (amtNDI - (amtLDC * (intRate / 200))) / ((intRate / 200) + 1);
                    //if (amtNDI_cal < 1) { amtNDI_cal = 0; }

                    calcLoanInt = calcInGrPeriod(dtLDD, dtNDD, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, matDate, dtDOP);
                    return calcLoanInt;
                }

            // ********** else if 2 ********

        else if ((dtEOGP < dtDOP) && (dtDOP <= dtNDD))
        {
            calcLoanInt = calcNotInGrPeriod(dtLDD, dtNDD, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, 0, amtCAofIP, amtCAofCap);
            return calcLoanInt;
        }
        
        #region ------------ commented ------------
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
        #endregion

        else {
            calcLoanInt =new double [8];
            return calcLoanInt ;
        }
    }



    //********************* calcAllValues ********************************

    

    public static double[] calcAllValues(int dtLDD, int dtNDD, int dtDOP, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, double intRate, double amtCAofIP, double amtCAofCap, int dtDOC, int matDate, int today)
    {
        double currInt=0;
        int dts = 0;
        int mnth = 0;
        double[] arr = new double[9]; 
        double[] fstSet;

        if (dtDOP == 0) { dtDOP = dtLDD; }

        //----------- 20070831 ------------
        if (amtNDC == 0 && dtNDD != 0) { throw new Exception("Loan Capital is Zero for this Loan"); } //20090106 from amal
        if (amtNDC == 0 && dtNDD == 0) amtNDC = amtLDC; //20090106 from amal
        //if (((dtNDD != 0) && int.Parse((getDateDif(today, dtNDD, "").ToString().Substring(0, 6))) > 5)) { throw new Exception("This Record is Incorrect in the Database"); }

        if (dtDOP >= dtLDD){
            fstSet = calcLoanInt(dtLDD, dtNDD, dtDOP, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, dtDOC, matDate, 0, amtCAofIP, amtCAofCap);
        }
        else {
          //  fstSet = calcLoanInt(dtLDD, dtNDD, today, amtLDI, amtNDI, amtLDC, amtNDC, 0, 0, intRate, dtDOC, matDate, 0, amtCAofIP, amtCAofCap);

            fstSet = calcInGrPeriod(dtLDD, dtNDD, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, matDate, dtDOP);
        }

        for (int i = 0; i < fstSet.Length; i++ ) {
            arr[i] = fstSet[i];
        }

        int dtNDofDOC = int.Parse(calcNextDue(dtDOC));
        if (matDate <= today) {
            today = matDate;
        }
        //*************** big logic ******************************
        if ((fstSet[5]) != 0)
        {
            if ((fstSet[1]) < today)                            //----------- posibility of recorrection ????????????
            {
                if (today < int.Parse(GraceDate((int)fstSet[1]))){

                    currInt = fstSet[3];
                  //  return currInt;
                }
                else {

                    dts = int.Parse(getDateDif(today, (int)fstSet[1], "").Substring (6,2));
                
                    if (dts > 15) {
			 			mnth =  int.Parse (getDateDif (today,(int)fstSet[1],"").Substring(4, 2)) + 1;
                    }
			 		else{
                        mnth = int.Parse (getDateDif(today, (int)fstSet[1], "").Substring(4, 2)) ;
			  		}
                    double k = intRate / 200;			// rate for 6 months

                    currInt = fstSet[3] + (((fstSet[5] + fstSet[3]) * k) * ((double)mnth / 6));
                  //  return currInt;

                }
            }
            else 
            {
                //------------ 20070831 -------------------------
                //if (today < dtNDofDOC)              // corrected
                //{
                //    currInt = fstSet[3];
                //   // return currInt;
                //}
                //else 
                //{                   
                    //if (today < int.Parse(GraceDate((int)fstSet[0])))
                    //{
                    //    currInt = fstSet[3];
                    ////    return currInt;
                    //}

                    if ((today < int.Parse(GraceDate((int)fstSet[0]))) && (today > dtNDofDOC)) 
                    {
                        currInt = fstSet[2];
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
                //}
            }    
            
        }
        else {
            currInt = 0;
          //  return currInt;
        }

        //******** returning value *********

        arr[8] = currInt;
        return arr;


    }

    //****************** calcMatureValues ***************************

    public static double[] calcMatureValues(int dtLDD, int dtNDD, int dtDOP, double amtLDI, double amtNDI, double amtLDC, double amtNDC, double amtInPay, double amtCapPay, double intRate, double amtCAofIP, double amtCAofCap, int dtDOC, int matDate, int today) 
    {
        double[] arr = new double[9];
        double[] fstSet;
        double currInt = 0;
        int calcNDD = 0;
        int dts = 0;
        int mnth = 0;


            if (dtDOP == 0) {
                dtDOP = dtLDD;
            }
    
        if (dtDOP > dtLDD) {
            fstSet = calcLoanInt(dtLDD, dtNDD, dtDOP, amtLDI, amtNDI, amtLDC, amtNDC, amtInPay, amtCapPay, intRate, dtDOC, matDate, 0, amtCAofIP, amtCAofCap);
        }
            
        else{
            fstSet = calcLoanInt(dtLDD, dtNDD, today, amtLDI, amtNDI, amtLDC, amtNDC, 0, 0, intRate, dtDOC, matDate, 0, amtCAofIP, amtCAofCap);
        }

        for (int i = 0; i < fstSet.Length; i++)
        {
            arr[i] = fstSet[i];
        }

        int dtNDofDOC = int.Parse(calcNextDue(dtDOC));

        //********* complex logic ************

        if ((fstSet[5]) != 0)
        {
            if ((fstSet[1]) < matDate)
            {
                double k = intRate / 200;

                if (matDate < int.Parse(GraceDate((int)fstSet[1])))
                {
                    dts = int.Parse(getDateDif(matDate, (int)fstSet[1], "").Substring(6, 2));
                    if (dts > 15)
                    {
                        mnth = int.Parse(getDateDif(matDate, (int)fstSet[1], "").Substring(4, 2)) + 1;
                    }
                    else
                    {
                        mnth = int.Parse(getDateDif(matDate, (int)fstSet[1], "").Substring(4, 2));
                    }

                    currInt = fstSet[3] + (((fstSet[5] + fstSet[3]) * k) * (mnth / 6));
                   // return currInt;

                }
                else
                {

                   calcNDD = (int)fstSet[1];
			 		double tempInterest = fstSet[3];
			 		while (matDate > calcNDD ) { 
			 			calcNDD = int.Parse(calcNextDue(calcNDD));
			 			tempInterest = tempInterest + ( ( fstSet[5]+ tempInterest ) * k);
					}
			 		currInt = tempInterest;
                   // return currInt;

                }
            }
            else
            {

                if (dtDOP < dtNDofDOC)
                {
                    currInt = fstSet[3];
                   // return currInt;
                }
                else
                {

                    if (matDate < int.Parse(GraceDate((int)fstSet[1])))
                    {
                        currInt = fstSet[2];
                      //  return currInt;
                    }
                    else
                    {

                        dts = int.Parse(getDateDif(matDate, (int)fstSet[0], "").Substring(6, 2));

                        if (dts > 15)
                        {
                            mnth = int.Parse(getDateDif(matDate, (int)fstSet[0], "").Substring(4, 2)) + 1;
                        }
                        else
                        {
                            mnth = int.Parse(getDateDif(matDate, (int)fstSet[0], "").Substring(4, 2));
                        }

                        double aNDI = fstSet[3] + amtCAofIP;
                        double k = intRate / 200;			// rate for 6 months

                        double amtIforL6M = (aNDI - (fstSet[4] + amtCAofCap) * k) / (k + 1);    //calculate the NDI of last 6 th month -> derived from (amtIforL6M + fstSet(5))k + amtIforL6M = aNDI 
                        currInt = ((aNDI - amtIforL6M) * mnth / 6) - amtCAofIP + amtIforL6M;
                       // return currInt;
                    }

                }

            }

        }
        else
        {
            currInt = 0;
          //  return currInt;
        }

        arr[8] = currInt;
        return arr;

    }

    

}
