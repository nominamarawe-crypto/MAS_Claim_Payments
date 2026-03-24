using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAS_Claim_Payments.App_Code
{
    public class Authentication
    {
        private authorize objAuthorize = new authorize();
        private DataManager dManagerAuth;

        public Authentication()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int checkModuleAccess(string userId)
        {
            int retVal = 0;

            //if (!objAuthorize.IsUserAuthenticated(userId, "FREDM", "FUN01 "))
            if (!objAuthorize.IsUserAuthenticated(userId, "MASCL", "FUN01"))
            //if (!objAuthorize.IsUserAuthenticated(userId, "MASCL", "FUN03"))
            {
                retVal = 0;
            }
            else
            {
                retVal = 1;
            }

            return retVal;
        }

        public int checkVouCreation(string userId)
        {
            int retVal = 0;

            if (!objAuthorize.IsUserAuthenticated(userId, "MASCL", "FUN02"))
            {
                retVal = 0;
            }
            else
            {
                retVal = 1;
            }

            //return retVal;
            return 1;
        }

        public int checkVouAuthorization(string userId)
        {
            int retVal = 0;

            if (!objAuthorize.IsUserAuthenticated(userId, "MASCL", "FUN03"))
            {
                retVal = 0;
            }
            else
            {
                retVal = 1;
            }

            //return retVal;
            return 1;
        }



    }
}