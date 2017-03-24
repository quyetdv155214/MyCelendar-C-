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
            string sql = "SELECT [timeTagID],[timeTagName],[categoryID],[timefrom],[timeto] " +
                         " FROM [dbo].[TimeTag] Where categoryID = @param ";
            DataTable table;
            if (catID == 1)
            {
                sql += " or 1 = 1 ";
            }
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

        public List<TimeTag> getListTimeTag(DataTable dt, List<TimeTag> list )
        {
          
            foreach (DataRow dr in dt.Rows)
            {
                TimeTag tt = new TimeTag();
                tt.CategoryID = Convert.ToInt32(dr["categoryID"]);
                tt.TimeFrom = dr["timefrom"].ToString();
                tt.TimeTo = dr["timeto"].ToString();
                tt.TimeTagName = dr["timeTagName"].ToString();
                try
                {
                    tt.TimeTagID = Convert.ToInt32(dr["timeTagID"]);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                list.Add(tt);
              
            }
            return list;

        }

        public DataTable getAllCategory()
        {
            String sql = "SELECT [categoryID] , [categoryName] FROM [dbo].[TaskCategory] where categoryID !=1";
            DataTable dataTable = MyExecuteQuery(sql);
            return dataTable;
        }

        public bool addCate(String name)
        {
            String sql = "INSERT INTO [dbo].[TaskCategory] ([categoryName]) VALUES ( @name )";
            int i = MyExecuteNonQuery(sql, new object[] {name});
            return i > 0;

        }

        public bool addTimeTag(TimeTag timeTag)
        {
            String sql =
                "INSERT INTO [dbo].[TimeTag] ([timeTagName] ,[categoryID],[timefrom] ,[timeto]) VALUES ( @name  , @catId , @timefrom , @timeTo )";
            int i = MyExecuteNonQuery(sql, new object[]
            {
                timeTag.TimeTagName,
                timeTag.CategoryID,
                timeTag.TimeFrom,
                timeTag.TimeTo
            });
            return i > 0;
        }


    }
}
