using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAS_Claim_Payments.App_Code
{
    public class FormatData
    {
        private ReadAmountInWords readAmt = new ReadAmountInWords();
        public string getClmType(string clmId)
        {
            string desc = "";

            if (clmId == "D") { desc = "Death"; }
            else if (clmId == "Dis") { desc = "Disability"; }
            else if (clmId == "Hos") { desc = "Hospital Cash"; }
            else if (clmId == "Fun") { desc = "Funeral Expenses"; }
            else if (clmId == "ED") { desc = "Ex-gratia Death"; }
            else if (clmId == "EDis") { desc = "Ex-gratia Disability"; }
            else if (clmId == "EHos") { desc = "Ex-gratia Hospital Cash"; }
            else if (clmId == "EFun") { desc = "Ex-gratia Funeral Expenses"; }

            return desc;
        }

        public string getPaymntType(string paymntId)
        {
            string desc = "";

            if (paymntId == "N") { desc = "Normal"; }
            else if (paymntId == "E") { desc = "Ex-Gratia"; }            

            return desc;
        }

        public string get_netAmtPayInWords(double amount)
        {
            string amountInWords = ""; string cents = ""; string rupees = "";
            string amnt = amount.ToString();
            int dotIndex = (amnt).IndexOf('.');
            if (dotIndex > 0)
            {
                rupees = (amnt).Substring(0, dotIndex);
                cents = (amnt).Substring(dotIndex + 1);
                int centsLength = cents.Length;

                if (centsLength == 1) { cents = cents + "0"; }
                if (centsLength > 2) { cents = (Math.Round(double.Parse(cents))).ToString(); }
            }
            else
            {
                rupees = amnt;
                cents = "00";
            }

            string amount2 = rupees + "." + cents;

            amountInWords = readAmt.readAmount((amount2.ToString()), "RUPEES", "CENTS ");
            return amountInWords;
        }

        public string format_hname(string hName)
        {
            if (hName.Contains(("BANK OF CEYLON").ToUpper())) { hName = hName.Replace("BANK OF CEYLON", "BOC"); }
            else if (hName.Contains("COMMERCIAL BANK OF CEYLON LTD.")) { hName = hName.Replace("COMMERCIAL BANK OF CEYLON LTD.", "COM BANK"); }
            else if (hName.Contains("HATTON NATIONAL BANK")) { hName = hName.Replace("HATTON NATIONAL BANK", "HNB"); }
            else if (hName.Contains("HONGKONG AND SHANGHAI BANK")) { hName = hName.Replace("HONGKONG AND SHANGHAI BANK", "HSBC"); }
            else if (hName.Contains("HONGKONG & SHANGHAI BANK CO.OP")) { hName = hName.Replace("HONGKONG & SHANGHAI BANK CO.OP", "HSBC"); }
            else if (hName.Contains("PAN ASIA BANKING CORPORATION LTD.")) { hName = hName.Replace("PAN ASIA BANKING CORPORATION LTD.", "PAN ASIA BANK"); }
            else if (hName.Contains("DFCC VARDHANA BANK LTD")) { hName = hName.Replace("DFCC VARDHANA BANK LTD", "DFCC BANK"); }
            else if (hName.Contains("NATIONAL SAVINGS BANK,")) { hName = hName.Replace("NATIONAL SAVINGS BANK,", "NSB"); }
            else if (hName.Contains("NATIONAL SAVING BANK")) { hName = hName.Replace("NATIONAL SAVING BANK", "NSB"); }
            else if (hName.Contains("NATIONAL  SAVING  BANK")) { hName = hName.Replace("NATIONAL  SAVING  BANK", "NSB"); }
            else if (hName.Contains("CENTRAL BANK OF SRI LANKA")) { hName = hName.Replace("CENTRAL BANK OF SRI LANKA", "CENTRAL BANK"); }
            else if (hName.Contains("CITY BANK N. A.")) { hName = hName.Replace("CITY BANK N. A.", "CITY BANK"); }
            else if (hName.Contains("HABIB BANK LTD")) { hName = hName.Replace("HABIB BANK LTD", "HABIB BANK"); }
            else if (hName.Contains("STANDARD CHARTERED BANK")) { hName = hName.Replace("STANDARD CHARTERED BANK", "STAND CHA BANK"); }
            else if (hName.Contains("INDIAN BANK")) { hName = hName.Replace("INDIAN BANK", "IND BANK"); }
            else if (hName.Contains("INDIAN OVERSEAS BANK")) { hName = hName.Replace("INDIAN OVERSEAS BANK", "IND OVER BANK"); }
            else if (hName.Contains("PEOPLES BANK")) { hName = hName.Replace("PEOPLES BANK", "PEOP BANK"); }
            else if (hName.Contains("STATE BANK OF INDIA")) { hName = hName.Replace("STATE BANK OF INDIA", "STAT BANK INDIA"); }
            else if (hName.Contains("UNION BANK LTD. (PAKISTAN)")) { hName = hName.Replace("UNION BANK LTD. (PAKISTAN)", "UNION BANK(PAK)"); }
            else if (hName.Contains("NATIONS TRUST BANK")) { hName = hName.Replace("NATIONS TRUST BANK", "NAT TRUST BANK"); }
            else if (hName.Contains("DEUTSCHE BANK")) { hName = hName.Replace("DEUTSCHE BANK", "DEUT BANK"); }
            else if (hName.Contains("NDB BANK")) { hName = hName.Replace("NDB BANK", "NDB"); }
            else if (hName.Contains("HDFC BANK")) { hName = hName.Replace("HDFC BANK", "HDFC"); }
            else if (hName.Contains("MUSLIM COMMERCIAL BANK")) { hName = hName.Replace("MUSLIM COMMERCIAL BANK", "MUS COM BANK"); }
            else if (hName.Contains("SAMPATH BANK")) { hName = hName.Replace("SAMPATH BANK", "SAM BANK"); }
            else if (hName.Contains("SEYLAN BANK")) { hName = hName.Replace("SEYLAN BANK", "SEY BANK"); }
            else if (hName.Contains("AMANA BANK")) { hName = hName.Replace("AMANA BANK", "AMANA B."); }
            else if (hName.Contains("AMERICAN EXPRESS BANK LTD")) { hName = hName.Replace("AMERICAN EXPRESS BANK LTD", "AME EXP BANK"); }
            else if (hName.Contains("SANASA DEVELOPMENT BANK")) { hName = hName.Replace("SANASA DEVELOPMENT BANK", "SANASA BANK"); }
            else if (hName.Contains("PUBLIC BANK BERHAD")) { hName = hName.Replace("PUBLIC BANK BERHAD", "PUB BANK BER"); }
            else if (hName.Contains("UNION BANK OF COLOMBO LTD.")) { hName = hName.Replace("UNION BANK OF COLOMBO LTD.", "UNION BANK COLOMBO"); }
            else if (hName.Contains("ICICI BANK")) { hName = hName.Replace("ICICI BANK", "ICICI"); }
            else if (hName.Contains("REGIONAL DEVELOPMENT BANK")) { hName = hName.Replace("REGIONAL DEVELOPMENT BANK", "RDB"); }

            return hName;
        }

        public string PrepareApostrophe(string str)
        {
            string newStr = "";
            bool pZero = false, pEnd = false, pMiddle = false;
            if (str.IndexOf("'") < 0) return str;
            pZero = str.IndexOf("'") == 0 ? true : false;
            pEnd = str.LastIndexOf("'") + 1 == str.Length ? true : false;
            pMiddle = str.Substring(1, str.Length - 2).LastIndexOf("'") > 0 ? true : false;


            newStr = pZero && pMiddle && pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 2).Replace("'", "'||chr(39)||'") + "'||chr(39)|| '"
                : !pZero && pMiddle && pEnd ? str.Substring(0, (str.Length - 1)).Replace("'", "'||chr(39)||'") + "'||chr(39)|| '" : pZero && !pMiddle && pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 2) + "'||chr(39)|| '"
                : pZero && pMiddle && !pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 1).Replace("'", "'||chr(39)||'")
                : pZero && !pMiddle && !pEnd ? "'||chr(39)||'" + str.Substring(1, str.Length - 1)
                : !pZero && !pMiddle && pEnd ? str.Substring(0, str.Length - 1) + "'||chr(39)|| '"
                : !pZero && pMiddle && !pEnd ? str.Substring(0, str.Length).Replace("'", "'||chr(39)||'") : str;
            return newStr;
        }

        public string replaceQuote(string str)
        {
            if (str.Contains("'"))
            {
                if (countQuotes(str) == 1)
                    str = str.Replace("'", "''");
            }
            return str;
        }

        public int countQuotes(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\'')
                {
                    count++;
                }
            }
            return count;
        }

        public bool validateAccountNo(string accuntNo, int bkCode, int brCode)
        {            
            bool validated = true;            

            if (!accuntNo.Equals(""))
            {
                if (accuntNo.Length == 15)
                {
                    int accBranchCode = int.Parse(accuntNo.Substring(0, 3));

                    if (accBranchCode == brCode)
                    {
                        validated = true;
                    }
                    else
                    {
                        validated = false;
                    }
                }
                else if (accuntNo.Length > 15)
                {
                    validated = false;
                }
            }          

            return validated;           
        }

    }
}