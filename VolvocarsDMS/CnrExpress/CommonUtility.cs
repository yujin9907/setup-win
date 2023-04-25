using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvocarsDMS.Common;

namespace VolvocarsDMS
{
    internal class CommonUtility
    {
        public static string? GetAppConfig(string key)
        {
            if (Sessions.AppConfig?.Rows.Count > 0)
            {
                DataRow dr = Sessions.AppConfig.Rows[0];

                return dr[key].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SetAppConfig(string key, string value)
        {
            if (Sessions.AppConfig?.Rows.Count > 0)
            {
                DataRow dr = Sessions.AppConfig.Rows[0];

                dr[key] = value;
            }
        }
    }
}
