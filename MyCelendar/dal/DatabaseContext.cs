using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCelendar.model;

namespace MyCelendar.dal
{

    class DatabaseContext
    {
        public static String getConnectionString()
        {
            return System.Configuration.ConfigurationManager
                .ConnectionStrings["MyCelendar.Properties.Settings.MyCelendarConnectionString"].ConnectionString;
        }

        public DataTable MyExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int MyExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                Console.WriteLine(data);
                connection.Close();

                return data;
            }


        }

        public object MyExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }

        public DataTable GetAllTimeTags(int catID)
        {
            List<TimeTag> list = new List<TimeTag>();
            string sql = "SELECT [timeTagID],[timeTagName],[categoryID],[timefrom],[timeto] " +
                         " FROM [dbo].[TimeTag] Where categoryID = @param ";
            DataTable table;
            try
            {
                table = MyExecuteQuery(sql, new object[] {catID});

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return table;

        }
    }
}
