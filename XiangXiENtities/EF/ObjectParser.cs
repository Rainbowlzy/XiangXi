using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace XiangXiEntities1.EF
{
    public class ObjectParser
    {
        public static DataTable GetDataTable(string connectionString, string commandText, params SqlParameter[] parms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddRange(parms);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public static Dictionary<string, string> Parse(object o)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (o == null)
            {
                return dictionary;
            }
            foreach (PropertyInfo property in o.GetType().GetProperties())
            {
                Type type = property.GetType();
                string name = property.Name;
                string value = (property.GetValue(o) ?? "").ToString();
                if (type == typeof(DateTime))
                {
                    dictionary.Add(name,
                        DateTime.Parse(value).ToString("yyyy-M-d"));
                }
                else
                {
                    dictionary.Add(name, value);
                }
            }
            return dictionary;
        }
    }
}