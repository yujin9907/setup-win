using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS
{
    internal class JsonHelper
    {
        public static DataTable? FromJson(string filepath)
        {
            return JsonConvert.DeserializeObject<DataTable>(System.IO.File.ReadAllText(filepath));
        }

        public static string ToJson(DataTable dt)
        {
            StringBuilder JSONString = new ();

            if (dt.Rows.Count > 0)
            {
                JSONString.Append('[');
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JSONString.Append('{');

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JSONString.Append('}');
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }

                JSONString.Append(']');
            }

            return JSONString.ToString();
        }

    }
}
