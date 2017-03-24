using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCelendar.dal;

namespace MyCelendar
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMain());
//            TaskContext tc = new TaskContext();
//            List<int> i  = new List<int>();
//            i.Add(1);
//            i.Add(2);
//            i.Add(3);
//            tc.SearchTasks(null, 1, "7:00","8:00", null);
            

        }
    }
}
