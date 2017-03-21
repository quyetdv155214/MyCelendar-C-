using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakarovDev.ExpandCollapsePanel;
using MyCelendar.dal;
using Task = MyCelendar.model.Task;

namespace MyCelendar
{
    public partial class fMain : Form
    {
        private DatabaseContext db;
        public fMain()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.taskCategoryTableAdapter.Fill(this.myCelendarDataSet.TaskCategory);
            setupUI();
        }

        private void setupUI()
        {
            
            mc_date.MaxSelectionCount = 1;
            db = new DatabaseContext();
            DataTable dataTable = db.GetAllTimeTags(Convert.ToInt32(cb_type.SelectedValue));
            clbTimeTag.DataSource = dataTable;
            clbTimeTag.DisplayMember = "TimeTagName";
            clbTimeTag.ValueMember = "TimeTagID";
            // 
            TaskContext tc = new TaskContext();
            List<Task> tasks = tc.GetAllTasks();

            foreach (Task task in tasks)
            {
                setnewCom(task);
            }
        }

        public void setnewCom(Task task)
        {
            Panel pan = new  Panel();
            ExpandCollapsePanel ecp = new ExpandCollapsePanel();

            pan.AutoSize = true;
            pan.Width = 520;
            pan.Height = 35;
            pan.BorderStyle = BorderStyle.FixedSingle;

            pan.Controls.Add(ecp);

            ecp.Font = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Bold);

            ecp.UseAnimation = false; // disable animation for immediately collapsing
            ecp.IsExpanded = false; // collapse all panels
            ecp.UseAnimation = true; // enable animation for further user clicks
            ecp.ButtonStyle = ExpandCollapseButton.ExpandButtonStyle.Triangle;
            ecp.ButtonSize =ExpandCollapseButton.ExpandButtonSize.Small;
            ecp.Text = task.TaskName;
            ecp.BackColor =Color.Bisque;
            ecp.Width = 510;
            ecp.Visible = true;
            
            

            pMyTask.Controls.Add(pan);

            
        }

        private void mc_date_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpk_date.Value = mc_date.SelectionRange.Start;
        }

        private void dtpk_date_ValueChanged(object sender, EventArgs e)
        {
            mc_date.SetDate(dtpk_date.Value);
        }
    }
}
