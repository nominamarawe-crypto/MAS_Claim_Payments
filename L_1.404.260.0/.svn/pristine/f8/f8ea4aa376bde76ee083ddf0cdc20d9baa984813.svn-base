
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

public partial class readAmountFunction : System.Web.UI.Page
{

    //**************** readToArray ****************

    public int[] readToArray(string amount)
    {
        int iTemp;
        int iNumLength = amount.Length;
        int[] arrSingleNum = new int[iNumLength];
        iTemp = amount.Length - 1; //- 1;
        for (int i = 0; i < iNumLength; i++) 
        {
            arrSingleNum[iTemp] = int.Parse((amount.ToString()).Substring(i,1));
            iTemp--;
        }

        return arrSingleNum;
    }

    //************ readThreeDigitAmount *****************************

    public string readThreeDigitAmount(string amount, string [] name, string [] name1, string [] name3, int iStart, string str) 
    {
        String strAmount = "";
        int iNumLength = amount.Length;
        int[] arrSingleNum = new int[iNumLength];
        arrSingleNum = readToArray(amount);
        
        for (int j = iStart; j < iNumLength; j++)
        { 
            if (j==iStart)
            {
                int n = arrSingleNum[j];
                strAmount =name[n];                
            }

            if (j == (iStart + 1)) {

                int n2 = arrSingleNum[j];
                if ((arrSingleNum[j] == 1) && (arrSingleNum[j - 1] == 0))
                {
                    strAmount = "TEN";
                }
                else if (arrSingleNum[j] == 1)
                {
                    int nn = arrSingleNum[j - 1];
                    strAmount = name3[nn];
                }
                else
                {
                    strAmount = name1[n2] + strAmount;
                }                
                if ((double.Parse(amount) > 100) && ((double.Parse(amount)% 100) != 0))
                {
                    strAmount = str + strAmount;
                }         			
            }
            if (j == (iStart + 2))
            {
                int n3 = arrSingleNum[j];
                if (arrSingleNum[j] != 0)               
                {
                    strAmount = name[n3] + " HUNDRED  " + strAmount;
                }
            }                        
        }
        return strAmount;       
    }

    public string readThreeDigitAmountSinhala(string amount, string[] name, string[] name1, string[] name2, string[] name3, string[] name4, string[] name5, int iStart, string str)
    {
        String strAmount = "";
        int iNumLength = amount.Length;
        int[] arrSingleNum = new int[iNumLength];
        arrSingleNum = readToArray(amount);


        for (int j = iStart; j < iNumLength; j++)
        {
            if (j == iStart)
            {
                if (iStart <3)
                {
                    int n = arrSingleNum[j];
                    strAmount = name4[n];
                }
                else if (iNumLength > 3 && iStart == 3)
                {
                    int n = arrSingleNum[j];
                    strAmount = name2[n];
                }
                else
                {
                    int n = arrSingleNum[j];
                    strAmount = name[n];
                }
            }

            if (j == (iStart + 1))
            {
                int n2 = arrSingleNum[j];

                if ((arrSingleNum[j] == 1) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 2) && (arrSingleNum[j - 1] == 0))
                {
                    if (arrSingleNum.Length >= 5 && j>3)
                    {
                        strAmount = name1[n2].ToString();
                    }
                    else 
                    {
                    strAmount = name5[n2].ToString();
                    }
                }               
                
                if ((arrSingleNum[j] == 3) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 4) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 5) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 6) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 7) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 8) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                if ((arrSingleNum[j] == 9) && (arrSingleNum[j - 1] == 0))
                { strAmount = name5[n2].ToString(); }

                else if (arrSingleNum[j] == 1)
                {
                    int nn = arrSingleNum[j - 1];
                    strAmount = name3[nn];
                }
                else if ((arrSingleNum[j] == 1) && (arrSingleNum[j - 1] != 0))
                {
                    strAmount = name1[n2] + strAmount;
                }
                else if ((arrSingleNum[j] > 1) && (arrSingleNum[j - 1] != 0))
                {
                    strAmount = name1[n2] + strAmount;
                }

                if ((double.Parse(amount) > 100) && ((double.Parse(amount) % 100) != 0))
                {
                    strAmount = strAmount;
                }

            }
            if (j == (iStart + 2))
            {
                int n3 = arrSingleNum[j];
                if (arrSingleNum[j] != 0)
                {
                    strAmount = name[n3] + " ish  " + strAmount;
                }
            }

        }
        return strAmount;
    
    }

    //******************** readAmount ****************************

    //public string readAmount(string amount, string curType, string cts)
    //{

    //    string strAmount = "";
    //    string[] name ={ "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
    //    string[] name1 ={ "", "TEN ", "TWENTY ", "THIRTY ", "FORTY ", "FIFTY ", "SIXTY ", "SEVENTY ", "EIGHTY ", "NINETY " };
    //    string[] name3 ={ "", "ELEVEN ", "TWELVE", " THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", " SEVENTEEN", "EIGHTEEN", "NINETEEN" };

    //    int iRsLength = amount.Length - 3;
    //    int iCtsLength = amount.Length;

    //    string Rs = amount.Substring(0, iRsLength);
    //    string Cts = amount.Substring((iCtsLength - 2), 2);

    //    if (Cts.Equals("00"))
    //    { strAmount = readThreeDigitAmount(Rs, name, name1, name3, 0, " AND ") + " ONLY."; }
    //    else
    //    { strAmount = readThreeDigitAmount(Rs, name, name1, name3, 0, "") + " AND " + cts + readThreeDigitAmount(Cts, name, name1, name3, 0, " ") + " ONLY."; }
        
    //    //-------------------------------
    //    double temp1 = 0;
    //    double temp2 = 0;
    //    if ((iRsLength > 6) && ((iRsLength == 7)))
    //    {
    //        temp1 = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 7), 1));
    //    }
    //    else if ((iRsLength > 6) && ((iRsLength == 8)))
    //    {
    //        temp1 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 8), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 7), 1)));
    //    }
    //    else if ((iRsLength > 6) && ((iRsLength == 9)))
    //    {
    //        temp1 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 9), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 8), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 7), 1)));
    //    }
    //    else if ((iRsLength > 9) && (iRsLength == 10))
    //    {
    //        temp2 = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 10), 1));
    //    }
    //    else if ((iRsLength > 9) && (iRsLength == 11))
    //    {
    //        temp2 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 11), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 10), 1)));
    //    }
    //    else if ((iRsLength > 9) && (iRsLength == 12))
    //    {
    //        temp2 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 12), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 11), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 10), 1)));
    //    }

    //    #region //------------- old code --------------------
    //    if (iRsLength > 3)
    //    {
    //        double temp = 0;
    //        if (iRsLength == 4)
    //        {
    //            temp = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 4), 1));
    //        }
    //        else if (iRsLength == 5)
    //        {
    //            temp = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 5), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 4), 1)));
    //        }
    //        else if (iRsLength == 6)
    //        {
    //            temp = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 6), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 5), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 4), 1)));
    //        }

    //        if (temp != 0)
    //        {
    //            if (temp1 != 0)
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + strAmount;
    //            }
    //            else
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + " THOUSAND " + strAmount;
    //            }
    //        }
    //        else
    //        {
    //            if (iRsLength <= 6)
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + " THOUSAND " + strAmount;
    //            }
    //            else
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + " THOUSAND " + strAmount;
    //            }

    //        }
    //    }
    //    if (iRsLength > 6)
    //    {
    //        if (temp1 != 0)
    //        {
    //            if (temp2 != 0)
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + strAmount;
    //            }
    //            else
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + " MILLION " + strAmount;
    //            }
    //        }
    //        else
    //        {
    //            if (iRsLength <= 9)
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + " MILLION " + strAmount;
    //            }
    //            else
    //            {
    //                strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + " MILLION " + strAmount;
    //            }
    //        }
    //    }

    //    if (iRsLength > 9)
    //    {
    //        //var temp2=parseInt(Rs.charAt(Rs.length-11)+Rs.charAt(Rs.length-10)+Rs.charAt(Rs.length-9))
    //        //if(temp1 != 0)
    //        //{
    //        strAmount = readThreeDigitAmount(Rs, name, name1, name3, 9, " ") + " BILLION " + strAmount;
    //        //}
    //        //else
    //        //	strAmount=readThreeDigitAmount(Rs,name,name1,name3,9," ") +" BILLION " +strAmount ;
    //    }
    //    #endregion


    //    return curType + " " + strAmount;
    //}

    //Add on 2009/04/11....By buddhika..
    /*
   public string readAmount(string amount, string curType, string cts)
    {

        string strAmount = "";
        string[] name ={ "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
        string[] name1 ={ "", "TEN ", "TWENTY ", "THIRTY ", "FORTY ", "FIFTY ", "SIXTY ", "SEVENTY ", "EIGHTY ", "NINETY " };
        string[] name3 ={ "", "ELEVEN ", "TWELVE", " THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", " SEVENTEEN", "EIGHTEEN", "NINETEEN" };

        int iRsLength = amount.Length - 3;
        int iCtsLength = amount.Length;

        string Rs = amount.Substring(0, iRsLength);
        string Cts = amount.Substring((iCtsLength - 2), 2);

        if (Cts.Equals("00"))
            strAmount = readThreeDigitAmount(Rs, name, name1, name3, 0, " AND ") + " ONLY.";
        else
            strAmount = readThreeDigitAmount(Rs, name, name1, name3, 0, "") + " AND " + cts + readThreeDigitAmount(Cts, name, name1, name3, 0, " ") + " ONLY.";

        //-------------------------------
        double temp1 = 0;
        double temp2 = 0;
        if ((iRsLength > 6) && ((iRsLength == 7)))
        {
            temp1 = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 7), 1));
        }
        else if ((iRsLength > 6) && ((iRsLength == 8)))
        {
            temp1 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 8), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 7), 1)));
        }
        else if ((iRsLength > 6) && ((iRsLength == 9)))
        {
            temp1 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 9), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 8), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 7), 1)));
        }
        else if ((iRsLength > 9) && (iRsLength == 10))
        {
            temp2 = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 10), 1));
        }
        else if ((iRsLength > 9) && (iRsLength == 11))
        {
            temp2 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 11), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 10), 1)));
        }
        else if ((iRsLength > 9) && (iRsLength == 12))
        {
            temp2 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 12), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 11), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 10), 1)));
        }

        #region //------------- old code --------------------
        if (iRsLength > 3)
        {
            double temp = 0;
            if (iRsLength == 4)
            {
                temp = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 4), 1));
            }
            else if (iRsLength == 5)
            {
                temp = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 5), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 4), 1)));
            }
            else if (iRsLength == 6)
            {
                temp = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 6), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 5), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 4), 1)));
            }

            if (temp != 0)
            {
                if (temp1 != 0)
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + " THOUSAND " + strAmount;
                }
            }
            else
            {
                if (iRsLength <= 6)
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + " THOUSAND " + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 3, " ") + " THOUSAND " + strAmount;
                }

            }
        }
        if (iRsLength > 6)
        {
            if (temp1 != 0)
            {
                if (temp2 != 0)
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + " MILLION " + strAmount;
                }
            }
            else
            {
                if (iRsLength <= 9)
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + " MILLION " + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmount(Rs, name, name1, name3, 6, " ") + " MILLION " + strAmount;
                }
            }
        }

        if (iRsLength > 9)
        {
            //var temp2=parseInt(Rs.charAt(Rs.length-11)+Rs.charAt(Rs.length-10)+Rs.charAt(Rs.length-9))
            //if(temp1 != 0)
            //{
            strAmount = readThreeDigitAmount(Rs, name, name1, name3, 9, " ") + " BILLION " + strAmount;
            //}
            //else
            //	strAmount=readThreeDigitAmount(Rs,name,name1,name3,9," ") +" BILLION " +strAmount ;
        }
        #endregion

        return curType + " " + strAmount;
    }

*/

    public string readAmountSinhala(string amount, string curType, string cts)
    {

        string strAmount = "";
        //string[] name ={ "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
        //string[] name1 ={ "", "TEN ", "TWENTY ", "THIRTY ", "FORTY ", "FIFTY ", "SIXTY ", "SEVENTY ", "EIGHTY ", "NINETY " };
        //string[] name3 ={ "", "ELEVEN ", "TWELVE", " THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", " SEVENTEEN", "EIGHTEEN", "NINETEEN" };

        string[] name ={ "","tla ","fo"," ;=ka","ydr"," mka"," yh"," y;a"," wg"," kj"};
        string[] name1 ={ "", "oy ", "jsis ", ";sia ", "y;,sia ", "mkia ", "yeg ", "ye;a;E ", "wiQ ", "wkQ " };
        string[] name2 ={ "", " tla ", " fo ", ";=ka ", "y;r ", " mka ", " yh ", " y;a ", " wg ", " kj " };
        string[] name3 ={ "", "tfld<y", "fod<y", " oy;=k", "ody;r", "myf<dj", "odih", " ody;", "oywg", "oykjh" };
        string[] name4 ={ "", "tlla ", "folla ", ";=kla ", "y;rla ", "myla", "yhla", "y;la ", "wgla", "kjhla" };
        string[] name5 ={ "", "oyhla ", "jsiaila  ", ";syla ", "y;,syla ", "mkyla", "yegla", "ye;a;Ejla", "wiQjla", "wkQjla" };

        int iRsLength = amount.Length - 3;
        int iCtsLength = amount.Length;

        string Rs = amount.Substring(0, iRsLength);
        string Cts = amount.Substring((iCtsLength - 2), 2);

        if (Cts.Equals("00"))
        { strAmount = readThreeDigitAmountSinhala(Rs, name, name1,name2, name3,name4,name5, 0, " iy ") + " muKs"; }
        else
        { strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 0, "") + " iy " + cts + readThreeDigitAmountSinhala(Cts, name, name1, name2, name3, name4, name5, 0, " ") + " muKs"; }

        //-------------------------------
        double temp1 = 0;
        double temp2 = 0;
        if ((iRsLength > 6) && ((iRsLength == 7)))
        {
            temp1 = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 7), 1));
        }
        else if ((iRsLength > 6) && ((iRsLength == 8)))
        {
            temp1 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 8), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 7), 1)));
        }
        else if ((iRsLength > 6) && ((iRsLength == 9)))
        {
            temp1 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 9), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 8), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 7), 1)));
        }
        else if ((iRsLength > 9) && (iRsLength == 10))
        {
            temp2 = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 10), 1));
        }
        else if ((iRsLength > 9) && (iRsLength == 11))
        {
            temp2 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 11), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 10), 1)));
        }
        else if ((iRsLength > 9) && (iRsLength == 12))
        {
            temp2 = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 12), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 11), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 10), 1)));
        }

        #region //------------- old code --------------------
        if (iRsLength > 3)
        {
            double temp = 0;
            if (iRsLength == 4)
            {
                temp = double.Parse(Rs.ToString().Substring((Rs.ToString().Length - 4), 1));
            }
            else if (iRsLength == 5)
            {
                temp = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 5), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 4), 1)));
            }
            else if (iRsLength == 6)
            {
                temp = double.Parse((Rs.ToString().Substring((Rs.ToString().Length - 6), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 5), 1)) + (Rs.ToString().Substring((Rs.ToString().Length - 4), 1)));
            }

            if (temp != 0)
            {
                if (temp1 != 0)
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 3, " ") + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 3, " ") + " oyia " + strAmount;
                }
            }
            else
            {
                if (iRsLength <= 6)
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 3, " ") + " oyia " + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 3, " ") + " oyia " + strAmount;
                }

            }
        }
        if (iRsLength > 6)
        {
            if (temp1 != 0)
            {
                if (temp2 != 0)
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 6, " ") + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 6, " ") + " us,shk " + strAmount;
                }
            }
            else
            {
                if (iRsLength <= 9)
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 6, " ") + " us,shk " + strAmount;
                }
                else
                {
                    strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 6, " ") + " us,shk " + strAmount;
                }
            }
        }

        if (iRsLength > 9)
        {
            //var temp2=parseInt(Rs.charAt(Rs.length-11)+Rs.charAt(Rs.length-10)+Rs.charAt(Rs.length-9))
            //if(temp1 != 0)
            //{
            strAmount = readThreeDigitAmountSinhala(Rs, name, name1, name2, name3, name4, name5, 9, " ") + " ns,shk " + strAmount;
            //}
            //else
            //	strAmount=readThreeDigitAmount(Rs,name,name1,name3,9," ") +" BILLION " +strAmount ;
        }
        #endregion


        return curType + " " + strAmount;
    
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            //this.Label1.Text = readAmount("2000000.00", "RUPEES", "CENTS ");
            this.Label2.Text = readAmountSinhala("452320.25", "remsh,a", "Y; ");
        }
        catch(Exception ex) {
            EPage.Messege = ex.Message;
            Response.Redirect("EPage.aspx");
        }
    }

    #region  NEW Version Of readAmount
    //-------------------Added by Jayampathi -----------------------------------------------
    //-------------------2010-06-23 ---------------------------------------------------------
            public static string ReadThreeDigitAmount(string amount, string[] name, string[] name1, string[] name2,string strAnd )
        {
            String strAmount = "";
            int iNumLength = amount.Length-1;
            int position =1;
            while (iNumLength >= 0)
            {
                switch (position)
                {
                    case 1:
                        strAmount = name[int.Parse(amount.Substring(iNumLength, 1))]; 
                        break;
                    case 2:
                        if (int.Parse(amount.Substring(iNumLength, 1)) == 1)
                            strAmount = name1[int.Parse(amount.Substring((iNumLength + 1), 1))];
                        else
                            strAmount = name2[int.Parse(amount.Substring(iNumLength, 1))] + strAmount; 
                        break;
                    case 3:
                        if (strAmount == "")
                            strAnd = "";
                        strAmount = name[int.Parse(amount.Substring(iNumLength, 1))] + "HUNDRED " + strAnd + strAmount;
                        break;
                    default:
                        break;
                }
                iNumLength--;
                position++;
            }                       
            return strAmount;
        }
        public string readAmount(string amount, string strCurrency, string strCents)
        {
            string strAmount = "", strAnd = "AND ", strDecimal = "";
            string[] name ={ "", "ONE ", "TWO ", "THREE ", "FOUR ", "FIVE ", "SIX ", "SEVEN ", "EIGHT ", "NINE " };
            string[] name1 ={ "TEN ", "ELEVEN ", "TWELVE ", "THIRTEEN ", "FOURTEEN ", "FIFTEEN ", "SIXTEEN ", "SEVENTEEN ", "EIGHTEEN ", "NINETEEN " };
            string[] name2 ={ "", "TEN ", "TWENTY ", "THIRTY ", "FORTY ", "FIFTY ", "SIXTY ", "SEVENTY ", "EIGHTY ", "NINETY " };
            string[] name3 ={ "", "THOUSAND ", " MILLION ", "BILLION ", "trillion ", "quadrillion ", "quintillion ", "sextillion", "septillion" };

            string Rs = amount.Substring(0, amount.Length - 3);
            string Cts = amount.Substring((amount.Length - 2), 2);

            int wordingCount = 0;
            int numberLength = Rs.Length;
            if (int.Parse(Cts) != 0)
            {
                strDecimal = strAnd + strCents + ReadThreeDigitAmount(int.Parse(Cts).ToString(), name, name1, name2, "") + "ONLY. ";
                strAnd = "";
            }
            else
                strDecimal = "ONLY. ";
            while (numberLength > 3)
            {
                numberLength = numberLength - 3;
                if ( int.Parse(Rs.Substring(numberLength, 3)) !=0 )
                    strAmount = ReadThreeDigitAmount( int.Parse(Rs.Substring(numberLength, 3)).ToString(), name, name1, name2, strAnd) + name3[wordingCount] + strAmount;
                wordingCount++;
                strAnd = "";
            }
            strAmount = strCurrency +" "+ ReadThreeDigitAmount(int.Parse(Rs.Substring(0, numberLength)).ToString(), name, name1, name2, strAnd) + name3[wordingCount] + strAmount + strDecimal;

            return strAmount;

        }
    
# endregion
}
