using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCelendar.model
{
    class TaskCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public TaskCategory(int categoryId, string categoryName)
        {
            CategoryID = categoryId;
            CategoryName = categoryName;
        }

        public TaskCategory(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
