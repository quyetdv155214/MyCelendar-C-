using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCelendar.model
{
    class TimeTag
    {
        public int TimeTagID { get; set; }
        public string TimeTagName { get; set; }
        public int CategoryID { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }

        public TimeTag(int timeTagId, string timeTagName, int categoryId, string timeFrom, string timeTo)
        {
            TimeTagID = timeTagId;
            TimeTagName = timeTagName;
            CategoryID = categoryId;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
        }

    }
}
