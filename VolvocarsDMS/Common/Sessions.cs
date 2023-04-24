using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS.Common
{
    internal class Sessions
    {

        private static DataTable? _AppConfig;

        public static FrmMain? MainForm { get; set; }

        private static string? _ApiServer;

        private static string? _Token;
        private static bool? _IsApiLog;

        private static string? _UserId;
        private static string? _UserName;
        private static string? _UserDeptCd;
        private static string? _UserDeptNm;
        private static string? _UserPosCd;
        private static string? _UserPosNm;


        public static DataTable? AppConfig { get { return _AppConfig; } set { _AppConfig = value; } }

        public static string? ApiServer { get { return _ApiServer; } set { _ApiServer = value; } }

        public static string? Token { get { return _Token; } set { _Token = value; } }

        public static bool? IsApiLog { get { return _IsApiLog; } set { _IsApiLog = value; } }

        public static string? UserId { get { return _UserId; } set { _UserId = value; } }
        public static string? UserName { get { return _UserName; } set { _UserName = value; } }
        public static string? UserDeptCd { get { return _UserDeptCd; } set { _UserDeptCd = value; } }
        public static string? UserDeptNm { get { return _UserDeptNm; } set { _UserDeptNm = value; } }
        public static string? UserPosCd { get { return _UserPosCd; } set { _UserPosCd = value; } }
        public static string? UserPosNm { get { return _UserPosNm; } set { _UserPosNm = value; } }
    }
}