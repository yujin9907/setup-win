using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS.Common
{
    internal class Constants
    {
        public static string AppConfigFilepath
        {
            get
            {
                if (Application.StartupPath.EndsWith("\\"))
                {
                    return Application.StartupPath + "App.Config";
                }
                else
                {
                    return Application.StartupPath + "\\" + "App.Config";
                }
            }
        }
    }
}
