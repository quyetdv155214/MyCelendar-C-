using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyCelendar.model;


namespace MyCelendar.dal
{
    class TaskContext
    {
        DatabaseContext db = new DatabaseContext();
        public List<Task> GetAllTasks()

        {
            List<Task> tasks = new List<Task>();
            //            string sql = "SELECT [taskid],[taskname],[date],[timefrom],[timeto],[location],[detail],[priority],[timeTagID],[fullday],[categoryID]  FROM [dbo].[Task] Where [categoryID] = @catID and [date] = @date ";

            String sql = "SELECT [taskid],[taskname],[date],[timefrom],[timeto],[location],[detail],[priority],[timeTagID],[fullday],[categoryID]  FROM [dbo].[Task] ";
            DataTable table = db.MyExecuteQuery(sql);
            foreach (DataRow dr in table.Rows)
            {
                Task t = new Task(dr);
                tasks.Add(t);
                Console.WriteLine("task Context : add task");
            }
            return tasks;
        }

        public List<Task> SearchTasks(string date, int catId, string timeFrom, string timeTo, List<int> timeTag)
        {
            return null;
        }
    }
}
