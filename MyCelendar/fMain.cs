using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
        private ExpandCollapsePanel ecp = null;
        public fMain()
        {
            InitializeComponent();
            AdvancedFlowLayoutPanel advancedFlow;

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
            //            Panel panF1 = new  Panel();
             ecp = new ExpandCollapsePanel();
            ecp.ButtonStyle = ExpandCollapseButton.ExpandButtonStyle.Triangle;
            ecp.ButtonSize = ExpandCollapseButton.ExpandButtonSize.Small;
            ecp.Width = 510;
            ecp.Height = 400;
            ecp.BorderStyle = BorderStyle.FixedSingle;
            //            ecp.AutoScroll = true;

            ecp.Visible = true;
            //
            ecp.Font = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Bold);

            ecp.UseAnimation = false; // disable animation for immediately collapsing
            ecp.IsExpanded = false; // collapse all panels
            ecp.UseAnimation = true; // enable animation for further user clicks

            // set up            
            ecp.Text = task.TaskName;
            Label taskID = new Label();
            TextBox taskName = new TextBox();
            DateTimePicker date = new DateTimePicker();
            TextBox timeFrom = new TextBox();
            TextBox timeTo = new TextBox();
            TextBox location = new TextBox();
            TextBox detail = new TextBox();
            RadioButton p1 = new RadioButton();
            RadioButton p2 = new RadioButton();
            RadioButton p3 = new RadioButton();
            RadioButton p4 = new RadioButton();
            RadioButton p5 = new RadioButton();
            ComboBox timeTag = new ComboBox();
            CheckBox isFullDay = new CheckBox();
            ComboBox category = new ComboBox();

            MyButton bt_close = new MyButton();
            bt_close.Text = "Close";

            MyButton bt_edit = new MyButton();
            bt_edit.Text = "Edit";
            MyButton bt_dele = new MyButton();
            bt_dele.Text = "Delete";
            GroupBox groupBox = new GroupBox();

            // label
            Label t = new Label();
            t.Text = "To";


            Label lbName = new Label();
            lbName.Text = "Name";
            Label lbDate = new Label();
            lbDate.Text = "Date";
            Label lbTime = new Label();
            lbTime.Text = "Time";
            Label lbloc = new Label();
            lbloc.Text = "Location";
            Label lbDetail = new Label();
            lbDetail.Text = "Detail";
            Label lbPrio = new Label();
            lbPrio.Text = "Priority";
            Label lbTag = new Label();
            lbTag.Text = "Tag";
            Label lbCate = new Label();
            lbCate.Text = "Category";
            ecp.Controls.Add(t);
            ecp.Controls.Add(lbName);
            ecp.Controls.Add(lbDate);
            ecp.Controls.Add(lbTime);
            ecp.Controls.Add(lbloc);
            ecp.Controls.Add(lbDetail);
            ecp.Controls.Add(lbPrio);
            ecp.Controls.Add(lbTag);
            ecp.Controls.Add(lbCate);



            groupBox.Controls.Add(p1);
            groupBox.Controls.Add(p2);
            groupBox.Controls.Add(p3);
            groupBox.Controls.Add(p4);
            groupBox.Controls.Add(p5);

            //
            int nextY = 45;
            int nextX = 130;
            int w = 250;
            int h = 25;
            Size s = new Size(w, h);
            int tab = 50;

            Font f = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            // 
            ecp.Controls.Add(date);
            ecp.Controls.Add(taskID);
            ecp.Controls.Add(taskName);
            ecp.Controls.Add(timeFrom);
            ecp.Controls.Add(timeTo);
            ecp.Controls.Add(location);
            ecp.Controls.Add(detail);
            ecp.Controls.Add(p1);
            ecp.Controls.Add(p2);
            ecp.Controls.Add(p3);
            ecp.Controls.Add(p4);
            ecp.Controls.Add(p5);
            ecp.Controls.Add(timeTag);
            ecp.Controls.Add(isFullDay);
            ecp.Controls.Add(category);
            ecp.Controls.Add(bt_close);
            ecp.Controls.Add(bt_dele);
            ecp.Controls.Add(bt_edit);

            //            // id
            //            taskID.Text = task.TaskID.ToString();
            //            taskID.Location = new Point(nextX, nextY);
            //            nextY += 30;
            //            // name
            int temp = nextX - 100;
            lbName.Location = new Point(temp, nextY);
            taskName.Text = task.TaskName;
            taskName.Location = new Point(nextX, nextY);
            taskName.Font = f;
            taskName.AutoSize = false;
            taskName.Size = s;
            taskName.Enabled = false;
            nextY += 30;
            //date
            lbDate.Location = new Point(temp, nextY);

            date.Value = task.Date;
            date.Location = new Point(nextX, nextY);
            date.Font = f;
            date.Size = s;
            date.Enabled = false;
            nextY += 30;
            //from
            lbTime.Location = new Point(temp, nextY);

            timeFrom.Text = task.TimeFrom;
            timeFrom.Font = f;
            timeFrom.Enabled = false;
            timeFrom.Size = new Size(60, h);
            timeFrom.Location = new Point(nextX, nextY);
            //
            t.Location = new Point(nextX + 60, nextY);
            t.Size = new Size(30, 25);
            // to 
            timeTo.Text = task.TimeTo;
            timeTo.Font = f;
            timeTo.Enabled = false;
            timeTo.Size = new Size(60, 25);
            timeTo.Location = new Point(nextX + 90, nextY);

            isFullDay.Text = "Full Day";
            isFullDay.Location = new Point(nextX + 180, nextY);
            isFullDay.Size = s;
            isFullDay.Enabled = false;
            isFullDay.Font = f;
            nextY += 30;
            // loc
            lbloc.Location = new Point(temp, nextY);

            location.Text = task.Location;
            location.Size = s;
            location.Font = f;
            location.Enabled = false;

            location.Location = new Point(nextX, nextY);
            nextY += 30;

            // detail
            lbDetail.Location = new Point(temp, nextY);

            detail.Text = task.Detail;
            detail.Size = new Size(250, 70);

            detail.Font = f;
            detail.Multiline = true;
            detail.Location = new Point(nextX, nextY);
            detail.Enabled = false;
            nextY += 100;

            // p
            lbPrio.Location = new Point(temp, nextY);

            p1.Text = 1.ToString();
            p1.Location = new Point(nextX, nextY);
            checkPriority(task, p1);
            p1.Enabled = false;
            p1.AutoSize = true;
            p1.Font = f;

            p2.Text = 2.ToString();
            p2.Location = new Point(nextX + tab, nextY);
            checkPriority(task, p2);
            p2.Enabled = false;
            p2.AutoSize = true;
            p2.Font = f;


            p3.Text = 3.ToString();
            p3.Location = new Point(nextX + tab * 2, nextY);
            checkPriority(task, p3);
            p3.Enabled = false;
            p3.AutoSize = true;
            p3.Font = f;

            p4.Text = 4.ToString();
            p4.Location = new Point(nextX + tab * 3, nextY);
            checkPriority(task, p4);
            p4.Enabled = false;
            p4.AutoSize = true;
            p4.Font = f;

            p5.Text = 5.ToString();
            p5.Location = new Point(nextX + tab * 4, nextY);
            p5.AutoSize = true;
            checkPriority(task, p5);
            p5.Enabled = false;

            p5.Font = f;
            nextY += 30;

            //


            // 
            lbCate.Location = new Point(temp, nextY);

            category.Text += task.CategoryID;
            category.Size = new Size(100, h);
            category.Font = f;
            category.Enabled = false;
            category.Location = new Point(nextX, nextY);
            //
            lbTag.Location = new Point(nextX + 110, nextY);
            lbTag.Size = new Size(45, 25);
            //
            timeTag.Text = task.TimeTagID.ToString();
            timeTag.Location = new Point(nextX + 170, nextY);
            timeTag.Font = f;
            timeTag.Enabled = false;
            timeTag.Size = new Size(80, h);

            nextY += 30;
            nextY += 30;
            // xu ly ui 
            


            bt_close.Location = new Point(nextX + w, nextY);
            bt_edit.Location = new Point(nextX + w - bt_close.Width - 10, nextY);
            bt_dele.Location = new Point(nextX + w - bt_close.Width - 10 - bt_edit.Width - 10, nextY);
            bt_close.panel = ecp;
            bt_close.Click += new EventHandler(Button_Close_Click);


            pMyTask.Controls.Add(ecp);


        }

        void checkPriority(Task task, RadioButton rd )
        {
            var taskPriority = task.Priority;
            if (rd.Text.Equals(taskPriority.ToString()))
            {
                rd.Checked = true;
            }
        }
        void Button_Close_Click(Object sender,
            EventArgs e)
        {
            MyButton clickedButton = (MyButton)sender;
            clickedButton.panel.UseAnimation = false;
            clickedButton.panel.IsExpanded = false;
            clickedButton.panel.UseAnimation = true;

            //            ecp.IsExpanded = false;
//            MessageBox.Show("Click close");
        }

        private void mc_date_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpk_date.Value = mc_date.SelectionRange.Start;
        }

        private void dtpk_date_ValueChanged(object sender, EventArgs e)
        {
            mc_date.SetDate(dtpk_date.Value);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }



    class MyButton : Button
    {

        public ExpandCollapsePanel panel { get; set; }

       
    }


}
