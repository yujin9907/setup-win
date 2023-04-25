using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS
{
    internal class LogManager
    {
        public static void Write(string? status, string? classname, string? methodname, string message)
        {
            string Folder = string.Empty;
            string FolderToday = string.Empty;
            string FolderDelete = string.Empty;

            string FilePath = string.Empty;
            string? FileNameMax = string.Empty;

            string Today = string.Empty;

            DirectoryInfo directoryInfo;
            FileInfo fileInfo;

            #region Folder create
            Today = System.DateTime.Today.ToString("yyyy-MM-dd");

            if (Application.StartupPath.EndsWith("\\"))
            {
                Folder = Application.StartupPath + "LOG";
            }
            else
            {
                Folder = Application.StartupPath + "\\LOG";
            }

            FolderToday = Folder + "\\" + Today.Substring(0, 7);
            directoryInfo = new DirectoryInfo(FolderToday);
            if (!directoryInfo.Exists) directoryInfo.Create();
            #endregion

            #region File create
            FileNameMax = directoryInfo.GetFiles().Max(f => f.Name);
            if (string.IsNullOrEmpty(FileNameMax))
            {
                FileNameMax = Today + "-0001.log";
            }
            else if (FileNameMax.Substring(0, 10) != Today.Substring(0, 10))
            {
                FileNameMax = Today + "-0001.log";
            }
            else
            {
                FilePath = FolderToday + "\\" + FileNameMax;
                fileInfo = new FileInfo(FilePath);
                if (fileInfo.Length > 1048576)
                {
                    FileNameMax = FileNameMax.Substring(0, 11) + (int.Parse(FileNameMax.Substring(11, 4)) + 1).ToString("0000") + ".log";
                }
            }
            FilePath = FolderToday + "\\" + FileNameMax;
            #endregion

            #region Log Write
            using (StreamWriter outputFile = new StreamWriter(FilePath, true))
            {
                outputFile.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + status + "\t" + classname + "\t" + methodname + "\t" + message.Replace(Environment.NewLine, " "));

            }

            #endregion
        }

    }
}
