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
                //                Console.WriteLine("task Context : add task");
            }
            return tasks;
        }

        public List<Task> SearchTasks(String name,String date, int? catId, String timeFrom, String timeTo, List<int> timeTag)
        {
            List<Task> list = GetAllTasks();
            List<Task> temp = new List<Task>();
            Console.WriteLine(list.Count);

            if (name != null && !name.Equals(""))
            {
                foreach (Task t in list)
                {
                    if (!t.TaskName.Contains(name))
                    {
                        temp.Add(t);
                    }
                }
            }

            if (date != null && !date.Equals(""))
            {
                Console.WriteLine(" date " + date);
                foreach (Task t in list)
                {
                    if (t.Date != Convert.ToDateTime(date))
                    {
                        temp.Add(t);
                    }
                }
            }
            if (catId != null)
            {
                Console.WriteLine("cat " + catId);
                foreach (Task t in list)
                {
                    if (t.CategoryID != catId)
                    {
                        temp.Add(t);
                    }
                }
            }
            if (timeFrom != null)
            {
                foreach (Task t in list)
                {

                    if (Convert.ToDateTime(t.TimeFrom) < Convert.ToDateTime(timeFrom))
                    {
                        temp.Add(t);
                    }
                }

            }
            if (timeTo != null)
            {
                foreach (Task t in list)
                {
                    if (Convert.ToDateTime(t.TimeTo) > Convert.ToDateTime(timeTo))
                    {

                        
                        temp.Add(t);

                    }
//                    Console.WriteLine(
//                        Convert.ToDateTime(t.TimeTo));
//                    Console.WriteLine(Convert.ToDateTime(timeTo));
                }
            }
            if (timeTag != null && timeTag.Count > 0)
            {
                foreach (Task t in list)
                {
                    bool ch = false;
                    foreach (int i in timeTag)
                    {
                        if (t.TimeTagID == i)
                        {
                            ch = true;
                            break;

                        }
                    }
                    if (!ch)
                    {
                        temp.Add(t);
                    }
                }

            }
            foreach (Task task in temp)
            {
                list.Remove(task);
            }
            Console.WriteLine(list.Count);

            return list;
        }
        public bool deleteTask(int taskID)
        {
            String sql = "DELETE FROM [dbo].[Task] WHERE taskid = @id";
            int query = db.MyExecuteNonQuery(sql, new object[] { taskID });
            if (query > 0)
            {
                Console.WriteLine("delete task " + taskID);
                return true;
            }
            return false;
        }

        public bool editTask(Task t)
        {

            String sql =
                "UPDATE [dbo].[Task] SET " +
                "[taskname] = @name ," +
                " [date] = @date ," +
                " [timefrom] = @timefrom ," +
                " [timeto] = @timeto ," +
                " [location] = @location ," +
                " [detail] = @detail ," +
                " [priority] = @priority ," +
                " [timeTagID] = @timetag , " +
                "[fullday] = @isFull ," +
                "[categoryID] = @cate  " +
                "WHERE taskid = @taskId ";
            int query = db.MyExecuteNonQuery(sql, new object[]
            {
                t.TaskName,
                t.Date,
                t.TimeFrom,
                t.TimeTo,
                t.Location,
                t.Detail,
                t.Priority,
                t.TimeTagID,
                t.IsFullDay ? 1:0,
                t.CategoryID,
                t.TaskID
            });
            if (query > 1)
            {
                return true;
            }
            return false;
        }

        public bool insertTask(Task t)
        {
            String sql =
                "INSERT INTO [dbo].[Task] ([taskname] ,[date],[timefrom],[timeto],[location],[detail] ,[priority],[timeTagID] , [fullday] ,[categoryID])VALUES (" +
                " @name , @date ,  @from , @to , @loc ,  @detail , @prio , @timetag , @full , @cate )";
            int query = db.MyExecuteNonQuery(sql, new object[]
           {
                t.TaskName,
                t.Date,
                t.TimeFrom,
                t.TimeTo,
                t.Location,
                t.Detail,
                t.Priority,
                t.TimeTagID,
                t.IsFullDay ? 1:0,
                t.CategoryID
           });
            return query > 0;

        }
    }
}
