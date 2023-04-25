using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS.Common
{
    internal class UrlRoutes
    {
        #region Auth
        public static string AuthToken()
        {
            return "auth/token";
        }


        #endregion

        #region Master
        public static string MasterInternal()
        {
            return "v1/master/internal";
        }
        #endregion


        #region Companies
        public static string MasterCompanies()
        {
            return "v1/companies";
        }
        
        public static string MasterCompaniesSave()
        {
            return "v1/companies";
        }

        public static string MasterCompaniesDelete()
        {
            return "v1/companies";
        }
        #endregion

        #region Dealer
        public static string DealerEmployee()
        {
            return "v1/dealer/employee";
        }


        #endregion

        #region System
        public static string SystemGrantMenu()
        {
            return "v1/system/grant/menu";
        }


        #endregion




    }
}
