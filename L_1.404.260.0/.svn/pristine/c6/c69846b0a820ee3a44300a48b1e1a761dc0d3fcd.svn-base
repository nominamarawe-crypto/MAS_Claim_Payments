using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SignatureData
/// </summary>
public class SignatureData
{
    public string UserName;
    public byte[] Signature;
    public string EPF;
    public string Role;

    DataManager dm;
    public SignatureData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SignatureData getSignature(String epf)
    {
        dm = new DataManager();
        byte[] _imgData = null;
        SignatureData signaturedata = new SignatureData();
        signaturedata.EPF = epf;

        //--------- for testing
        //signaturedata.EPF = 
            //"06393";
            //"07661";

        string query = "SELECT a.USRNAME,a.USER_SIG,a.DESIGNATIONID,b.DESCRIPTION_ENG FROM INTRANET.INTUSR a LEFT OUTER JOIN " +
                       "INTRANET.USERDESIGNATION b on a.DESIGNATIONID = b.DESIGNATIONID WHERE EPFNUM ='" + signaturedata.EPF + "'";

        if (dm.existRecored(query) != 0)
        {
            dm.readSql(query);
            OracleDataReader signaturereader = dm.oraComm.ExecuteReader(CommandBehavior.CloseConnection);
            OracleLob oracleLob = null;
            while (signaturereader.Read())
            {
                if (!signaturereader.IsDBNull(0)) signaturedata.UserName = signaturereader.GetString(0);
                if (!signaturereader.IsDBNull(1))
                {
                    //_imgData = (byte[])signaturereader[1];
                    oracleLob = signaturereader.GetOracleLob(1);

                    signaturedata.Signature = (byte[])oracleLob.Value;

                    //signaturedata.Signature = Convert.ToBase64String(_imgData);
                }
                if (!signaturereader.IsDBNull(3)) { signaturedata.Role = signaturereader.GetString(3); }
            }

            if(signaturedata.Role == "Minor Staff" || signaturedata.Role == "Clerk")
            {
                signaturedata.Role = "Authorized Officer";
            }


            signaturereader.Close();
            signaturereader.Dispose();
        }
        dm.connClose();

        return signaturedata;
    }

    public string GetAbsoluteUrl(string relativeUrl, string AbsoluteUri)
    {
        relativeUrl = relativeUrl.Replace("~/", string.Empty);
        string[] splits = AbsoluteUri.Split('/');
        if (splits.Length >= 2)
        {
            string url = splits[0] + "//";
            for (int i = 2; i < splits.Length - 1; i++)
            {
                url += splits[i];
                url += "/";
            }

            return url + relativeUrl;
        }
        return relativeUrl;
    }
}
