using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCelendar.model
{
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime Date { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public String Location { get; set; }
        public String Detail { get; set; }
        public int Priority { get; set; }
        public int TimeTagID { get; set; }
        public bool IsFullDay { get; set; }
        public int CategoryID { get; set; }

        public Task(int taskId, string taskName, DateTime date, string timeFrom, string timeTo, string location, string detail, int priority, int timeTagId, bool isFullDay, int categoryId)
        {
            TaskID = taskId;
            TaskName = taskName;
            Date = date;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            Location = location;
            Detail = detail;
            Priority = priority;
            TimeTagID = timeTagId;
            IsFullDay = isFullDay;
            CategoryID = categoryId;
        }

        public Task(string taskName, DateTime date, string timeFrom, string timeTo, string location, string detail, int priority, int timeTagId, bool isFullDay, int categoryId)
        {
            TaskName = taskName;
            Date = date;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            Location = location;
            Detail = detail;
            Priority = priority;
            TimeTagID = timeTagId;
            IsFullDay = isFullDay;
            CategoryID = categoryId;
        }

        public Task()
        {
            TaskName = "Default Name";
            Detail = "";
            Location = "";
            Priority = 5;
            IsFullDay = true;
            TimeFrom = "00:01";
            TimeTo = "23:59";
        }

        public Task(DataRow dr)
        {
            TaskID = Convert.ToInt32(dr["taskid"]);
            TaskName = dr["taskname"].ToString();
            Date = Convert.ToDateTime(dr["date"]);
            TimeFrom = dr["timefrom"].ToString();
            TimeTo = dr["timeto"].ToString();
            Location = dr["location"].ToString();
            Detail = dr["detail"].ToString();
            Priority = Convert.ToInt32(dr["priority"].ToString());
            TimeTagID = Convert.ToInt32(dr["timeTagID"].ToString());
            IsFullDay = Convert.ToBoolean(dr["fullday"].ToString());
            CategoryID = Convert.ToInt32(dr["categoryID"].ToString());
        }

        public override string ToString()
        {
            return $"id {TaskID} , name= {TaskName}, date = {Date} , timeFrom = {TimeFrom} \n " +
                   $" timto = {TimeTo}, location ={Location}, detail ={Detail}, priority = {Priority} \n" +
                   $"timeTag = {TimeTagID} , is full={IsFullDay}, cateID = {CategoryID}   ";
        }
    }
}
