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
using System.Data.OracleClient;

/// <summary>
/// Summary description for AMLDesignatedPerson
/// </summary>
public class AMLDesignatedPerson
{
    private string personType;
    private string fullName;
    private string dateOfbirth;
    private string passport;
    private string amlDesignatedType;

    DataManager dm;

    public List<AMLDesignatedPerson> GetPolPersonalList(long polno, string systemStage)
    {
        try
        {
            dm = new DataManager();
            List<AMLDesignatedPerson> polPersonalList = new List<AMLDesignatedPerson>();

            if (systemStage == "R")
            {
                string polPersonread = "select decode(PRPERTYPE,'1','First Life','2','Spouse','3','Second Life') as person_type,FULLNAME,DOB,PASSPORTNO " +
                                        "from LUND.POLPERSONAL where POLNO='" + polno + "' and PRPERTYPE in (1,2,3)";
                if (dm.existRecored(polPersonread) != 0)
                {
                    dm.readSql(polPersonread);
                    OracleDataReader polPersonreader = dm.oraComm.ExecuteReader();
                    while (polPersonreader.Read())
                    {
                        AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                        if (!polPersonreader.IsDBNull(0)) { polPerson.PersonType = polPersonreader.GetString(0); } else { polPerson.PersonType = ""; }
                        if (!polPersonreader.IsDBNull(1)) { polPerson.FullName = polPersonreader.GetString(1); } else { polPerson.FullName = ""; }
                        if (!polPersonreader.IsDBNull(2)) { polPerson.DateOfBirth = polPersonreader.GetInt32(2).ToString(); } else { polPerson.DateOfBirth = ""; }
                        if (!polPersonreader.IsDBNull(3)) { polPerson.Passport = polPersonreader.GetString(3); } else { polPerson.Passport = ""; }

                        polPersonalList.Add(polPerson);
                    }
                    polPersonreader.Close();
                }

                string nomineeread = "select 'NOMINEE' || ' (' || NOMNO || ')' as person_type, NOMNAM, NOMDOB from lund.nominee where polno='" + polno + "'";
                if (dm.existRecored(nomineeread) != 0)
                {
                    dm.readSql(nomineeread);
                    OracleDataReader nomineereader = dm.oraComm.ExecuteReader();
                    while (nomineereader.Read())
                    {
                        AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                        if (!nomineereader.IsDBNull(0)) { polPerson.PersonType = nomineereader.GetString(0); } else { polPerson.PersonType = ""; }
                        if (!nomineereader.IsDBNull(1)) { polPerson.FullName = nomineereader.GetString(1); } else { polPerson.FullName = ""; }
                        if (!nomineereader.IsDBNull(2)) { polPerson.DateOfBirth = nomineereader.GetInt32(2).ToString(); } else { polPerson.DateOfBirth = ""; }
                        polPerson.Passport = "";
                         
                        polPersonalList.Add(polPerson);
                    }
                    nomineereader.Close();
                }
            }
            else if (systemStage == "P")
            {
                string legalHiereread = "select 'Legal heirs' || ' (' || LHHNO || ')' as person_type, LHNAME, LHDOB from LPHS.LEGAL_HIRES where LHPOLNO='" + polno + "'";
                if (dm.existRecored(legalHiereread) != 0)
                {
                    dm.readSql(legalHiereread);
                    OracleDataReader legalHierereader = dm.oraComm.ExecuteReader();
                    while (legalHierereader.Read())
                    {
                        AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                        if (!legalHierereader.IsDBNull(0)) { polPerson.PersonType = legalHierereader.GetString(0); } else { polPerson.PersonType = ""; }
                        if (!legalHierereader.IsDBNull(1)) { polPerson.FullName = legalHierereader.GetString(1); } else { polPerson.FullName = ""; }
                        if (!legalHierereader.IsDBNull(2)) { polPerson.DateOfBirth = legalHierereader.GetInt32(2).ToString(); } else { polPerson.DateOfBirth = ""; }
                        polPerson.Passport = "";

                        polPersonalList.Add(polPerson);
                    }
                    legalHierereader.Close();
                }

                string livingPartnerread = "select 'Living Partner' || ' (' || rownum || ')' as person_type, NOMNAM, NOMDOB from LUND.LIVING_PRT where POLNO='" + polno + "'";
                if (dm.existRecored(livingPartnerread) != 0)
                {
                    dm.readSql(livingPartnerread);
                    OracleDataReader livingPartnerreader = dm.oraComm.ExecuteReader();
                    while (livingPartnerreader.Read())
                    {
                        AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                        if (!livingPartnerreader.IsDBNull(0)) { polPerson.PersonType = livingPartnerreader.GetString(0); } else { polPerson.PersonType = ""; }
                        if (!livingPartnerreader.IsDBNull(1)) { polPerson.FullName = livingPartnerreader.GetString(1); } else { polPerson.FullName = ""; }
                        if (!livingPartnerreader.IsDBNull(2)) { polPerson.DateOfBirth = livingPartnerreader.GetInt32(2).ToString(); } else { polPerson.DateOfBirth = ""; }
                        polPerson.Passport = "";

                        polPersonalList.Add(polPerson);
                    }
                    livingPartnerreader.Close();
                }

                string nomineeread = "select 'NOMINEE' || ' (' || NOMNO || ')' as person_type, NOMNAM, NOMDOB from lund.nominee where polno='" + polno + "'";
                if (dm.existRecored(nomineeread) != 0)
                {
                    dm.readSql(nomineeread);
                    OracleDataReader nomineereader = dm.oraComm.ExecuteReader();
                    while (nomineereader.Read())
                    {
                        AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                        if (!nomineereader.IsDBNull(0)) { polPerson.PersonType = nomineereader.GetString(0); } else { polPerson.PersonType = ""; }
                        if (!nomineereader.IsDBNull(1)) { polPerson.FullName = nomineereader.GetString(1); } else { polPerson.FullName = ""; }
                        if (!nomineereader.IsDBNull(2)) { polPerson.DateOfBirth = nomineereader.GetInt32(2).ToString(); } else { polPerson.DateOfBirth = ""; }
                        polPerson.Passport = "";

                        polPersonalList.Add(polPerson);
                    }
                    nomineereader.Close();
                }
            }

            return polPersonalList;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }

    public string Get_AMLDesignatedList(long polno, string systemStage)
    {
        string AMLDesignatedSrt = "";
        string person_type = "", full_name = "", dob = "", passport = "";
        string searchSql1 = " ", searchSql2 = " ", searchSql3 = " ";

        List<AMLDesignatedPerson> polPersonalList = new List<AMLDesignatedPerson>();
        List<AMLDesignatedPerson> AMLDesignatedList = new List<AMLDesignatedPerson>();


        polPersonalList = this.GetPolPersonalList(polno, systemStage);

        if (polPersonalList.Count > 0)
        {
            for (int i = 0; i < polPersonalList.Count; i++)
            {
                person_type = "";
                full_name = "";
                dob = "";
                passport = "";
                searchSql1 = "";
                searchSql2 = "";
                searchSql3 = "";

                person_type = polPersonalList[i].PersonType;
                full_name = polPersonalList[i].FullName;

                if (full_name.Length > 12)
                {
                    full_name = full_name.Remove(0, 3);
                }

                dob = polPersonalList[i].DateOfBirth;
                passport = polPersonalList[i].Passport;

                if (!full_name.ToString().Trim().Equals(""))
                { 
                    full_name = full_name.Trim().ToUpper().ToString();
                    searchSql1 = "SELECT * FROM SLICCOMMON.TERRORISTLIST WHERE UPPER(TR_NAME) LIKE '%" + full_name + "%' and rownum=1";
                }

                if (dob.Trim().Length > 0 && !dob.Trim().Equals(""))
                {
                    searchSql2 = "SELECT * FROM SLICCOMMON.TERRORISTLIST WHERE (TO_CHAR(dob,'yyyyMMdd') =" + dob + ") and rownum=1";
                }

                if (!passport.Trim().Equals(""))
                {
                    passport = passport.Trim().ToUpper().ToString();
                    searchSql3 = "SELECT * FROM SLICCOMMON.TERRORISTLIST WHERE (UPPER(REPLACE(PASSPORT_NO,' ','')) LIKE '%" + this.RemoveSpace(passport) + "%') and rownum=1";
                }

                if (!searchSql1.Trim().Equals(""))
                {
                    if (dm.existRecored(searchSql1) != 0)
                    {
                        dm.readSql(searchSql1);
                        OracleDataReader searchSql1reader = dm.oraComm.ExecuteReader();
                        while (searchSql1reader.Read())
                        {
                            AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                            polPerson.AMLDesignatedType = "Name";
                            polPerson.PersonType = polPersonalList[i].PersonType;

                            AMLDesignatedList.Add(polPerson);
                        }
                        searchSql1reader.Close();
                    }
                }

                if (!searchSql2.Trim().Equals(""))
                {
                    if (dm.existRecored(searchSql2) != 0)
                    {
                        dm.readSql(searchSql2);
                        OracleDataReader searchSql2reader = dm.oraComm.ExecuteReader();
                        while (searchSql2reader.Read())
                        {
                            AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                            polPerson.AMLDesignatedType = "Date of Birth";
                            polPerson.PersonType = polPersonalList[i].PersonType;

                            AMLDesignatedList.Add(polPerson);
                        }
                        searchSql2reader.Close();
                    }
                }

                if (!searchSql3.Trim().Equals(""))
                {
                    if (dm.existRecored(searchSql3) != 0)
                    {
                        dm.readSql(searchSql3);
                        OracleDataReader searchSql3reader = dm.oraComm.ExecuteReader();
                        while (searchSql3reader.Read())
                        {
                            AMLDesignatedPerson polPerson = new AMLDesignatedPerson();

                            polPerson.AMLDesignatedType = "Passport";
                            polPerson.PersonType = polPersonalList[i].PersonType;

                            AMLDesignatedList.Add(polPerson);
                        }
                        searchSql3reader.Close();
                    }
                }
            }
        }

        if (AMLDesignatedList.Count > 0)
        {
            AMLDesignatedSrt = this.AMLDesignatedErrorMessage(AMLDesignatedList);
        }

        return AMLDesignatedSrt;
    }

    public string AMLDesignatedErrorMessage(List<AMLDesignatedPerson> amlDesignatedList)
    {
        string AMLDesignatedSrt = "";
        string errorMsg = "";

        if (amlDesignatedList.Count > 0)
        {
            AMLDesignatedSrt = "Please check AML Designated Person list";

            for (int i = 0; i < amlDesignatedList.Count; i++)
            {
                if (i == 0) { errorMsg = " - ("; }

                if (personType != amlDesignatedList[i].PersonType)
                {
                    personType = amlDesignatedList[i].PersonType;

                    if (i == 0)
                    {
                        errorMsg += personType + " - ";
                    }
                    else
                    {
                        errorMsg = errorMsg.Remove(errorMsg.Length - 2);
                        errorMsg += " / " + personType + " - ";
                    }
                }

                errorMsg += amlDesignatedList[i].AMLDesignatedType + ", ";

                if (i == (amlDesignatedList.Count - 1))
                {
                    errorMsg = errorMsg.Remove(errorMsg.Length - 2);
                    errorMsg += ")";
                }
            }
        }

        AMLDesignatedSrt += errorMsg;

        return AMLDesignatedSrt;
    }

    public string RemoveSpace(string str)
    {
        char[] spArray = new char[str.Length];
        spArray = str.ToCharArray();
        string concatVal = "";
        for (int sp = 0; sp < spArray.Length; sp++)
        {
            if (!spArray[sp].Equals(' '))
                concatVal = concatVal + spArray[sp].ToString();

        }

        return concatVal.Trim().ToUpper();

    }


    public string PersonType
    {
        get { return personType; }
        set { personType = value; }
    }

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    public string DateOfBirth
    {
        get { return dateOfbirth; }
        set { dateOfbirth = value; }
    }

    public string Passport
    {
        get { return passport; }
        set { passport = value; }
    }

    public string AMLDesignatedType
    {
        get { return amlDesignatedType; }
        set { amlDesignatedType = value; }
    }
}
