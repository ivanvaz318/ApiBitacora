using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAOApi
{
    public static class SqlDataReaderExtensions
    {
        public static List<T> MapToList<T>(this SqlDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            T obj;
            while (reader.Read())
            {
                obj = new T();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                    {
                        prop.SetValue(obj, reader[prop.Name]);
                    }
                }
                list.Add(obj);
            }

            return list;
        }

        public static string MapToListJson<T>(this SqlDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            T obj;
            var jsonResult = new StringBuilder();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Construir el JSON de cada fila y agregarlo al StringBuilder
                    var jsonString = reader.GetValue(0).ToString();

                    jsonResult.Append(jsonString);
                }

            }
            return jsonResult.ToString();
        }

    }
}
