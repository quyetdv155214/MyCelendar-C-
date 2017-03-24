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
using MyCelendar.model;
using Task = MyCelendar.model.Task;

namespace MyCelendar
{
    public partial class fMain : Form
    {
        //        AdvancedFlowLayoutPanel pMyTask
        //                = new AdvancedFlowLayoutPanel();
        private TaskContext tc;

        private DatabaseContext db;
        private ExpandCollapsePanel ecp = null;
        public fMain()
        {
            InitializeComponent();
            tc = new TaskContext();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.taskCategoryTableAdapter.Fill(this.myCelendarDataSet.TaskCategory);

            setupUI();
            expandCollapsePanel3.GotFocus += new EventHandler(exGetfoucus);
        }

        private void setupUI()
        {

            mc_date.MaxSelectionCount = 1;
            db = new DatabaseContext();
            DataTable dataTable = db.GetAllTimeTags(Convert.ToInt32(cb_type.SelectedValue));
            List<TimeTag> listTimeTag = new List<TimeTag>();
            listTimeTag = db.getListTimeTag(dataTable, listTimeTag);
            clbTimeTag.DataSource = listTimeTag;
            clbTimeTag.DisplayMember = "TimeTagName";
            clbTimeTag.ValueMember = "TimeTagID";
            // 
            TaskContext tc = new TaskContext();
            List<Task> tasks = tc.GetAllTasks();
            reloadData(tasks);

        }

        void reloadData(List<Task> tasks)
        {
            pMyTask.Controls.Clear();

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
                                    //            ecp.UseAnimation = true; // enable animation for further user clicks

            // set up            
            ecp.Text = task.TaskName;
            Label taskID = new Label();
            TextBox taskName = new TextBox();
            DateTimePicker date = new DateTimePicker();
            DateTimePicker timeFrom = new DateTimePicker();
            DateTimePicker timeTo = new DateTimePicker();
            timeFrom.Format = DateTimePickerFormat.Custom;
            timeTo.Format = DateTimePickerFormat.Custom;
            timeFrom.CustomFormat = "HH:mm";
            timeTo.CustomFormat = "HH:mm";
          
            
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

            MyButton bt_close = new MyButton(ecp);
            bt_close.Text = "Close";

            MyButton bt_edit = new MyButton(task.TaskID, taskName, timeFrom, timeTo, location, detail, p1, p2, p3, p4, p5, timeTag, category, isFullDay, date);
            bt_edit.Text = "Edit";
            MyButton bt_dele = new MyButton(task.TaskID, ecp);
            bt_dele.Text = "Delete";
            GroupBox groupBox = new GroupBox();

            /*int id, TextBox taskName, TextBox timeFrom, TextBox timeTo, TextBox loction, TextBox detail, RadioButton p1, RadioButton p2, RadioButton p3, RadioButton p4, RadioButton p5, ComboBox timeTag, ComboBox category, CheckBox isFullDay, DateTimePicker date)
             */
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

            category.DataSource = db.getAllCategory();
            category.DisplayMember = "categoryName";
            category.ValueMember = "categoryID";
            timeTag.DataSource = db.GetAllTimeTags(1);
            timeTag.DisplayMember = "TimeTagName";
            timeTag.ValueMember = "TimeTagID";
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
            // close event
            bt_close.Click += new EventHandler(Button_Close_Click);
            // dele event
            bt_dele.Click += new EventHandler(Button_Dele_Click);
            // edit event
            bt_edit.Click += new EventHandler(Button_Edit_Click);



            pMyTask.Controls.Add(ecp);


        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {

            MyButton bt = (MyButton)sender;
            //            bt.date.Enabled = true;
            //            bt.category.Enabled = true;
            //            bt.detail.Enabled = true;
            //            bt.isFullDay.Enabled = true;
            //            bt.loction.Enabled = true;
            //            bt.p1.Enabled = true;
            //            bt.p2.Enabled = true;
            //            bt.p3.Enabled = true;
            //            bt.p4.Enabled = true;
            //            bt.p5.Enabled = true;
            //            bt.timeTag.Enabled = true;
            //            bt.taskName.Enabled = true;
            //            bt.timeTo.Enabled = true;
            //            bt.timeFrom.Enabled = true;
            Task t = bt.getData();
            Console.WriteLine(t.ToString());
            if (bt.Text.Equals("Save"))
            {
                tc.editTask(t);
                bt.enDisable();
                
                bt.Text = "Edit";
            }
            else
            {
                bt.enDisable();
                bt.category.DataSource = db.getAllCategory();
                bt.category.DisplayMember = "categoryName";
                bt.category.ValueMember = "categoryID";
                bt.timeTag.DataSource = db.GetAllTimeTags(1);
                bt.timeTag.DisplayMember = "TimeTagName";
                bt.timeTag.ValueMember = "TimeTagID";
                bt.Text = "Save";
            }
            //
            //            MessageBox.Show(bt.id.ToString());
        }

        void checkPriority(Task task, RadioButton rd)
        {
            var taskPriority = task.Priority;
            if (rd.Text.Equals(taskPriority.ToString()))
            {
                rd.Checked = true;
            }
        }

        void exGetfoucus(Object sender,
            EventArgs e)
        {
            DataTable allCategory = db.getAllCategory();
            comboBox1.DataSource = allCategory;
            comboBox1.DisplayMember = "categoryName";
            comboBox1.ValueMember = "categoryID";
        }

        void Button_Dele_Click(Object sender,
            EventArgs e)
        {
            MyButton bt = (MyButton)sender;
            var dele = MessageBox.Show("Xóa đi éo lấy lại được đâu ! ", "DELETE", MessageBoxButtons.OKCancel);
            if (dele == DialogResult.OK)
            {
                bool deleteTask = tc.deleteTask(bt.id);
                if (deleteTask)
                {
//                                        bt.panel.Visible = false;
                    TaskContext tc = new TaskContext();
                    List<Task> tasks = tc.GetAllTasks();
                    reloadData(tasks);
                    MessageBox.Show("deleted");
                    
                }
                else
                {
                    MessageBox.Show("loi me roi eo đi lít được");
                }
            }
            else
            {

            }

            //            MessageBox.Show(bt.id.ToString());
        }
        void Button_Close_Click(Object sender,
            EventArgs e)
        {
            MyButton clickedButton = (MyButton)sender;
            clickedButton.panel.UseAnimation = false;
            clickedButton.panel.IsExpanded = false;
            //            clickedButton.panel.UseAnimation = true;

            //            ecp.IsExpanded = false;
            //            MessageBox.Show("Click close");
        }

        private void mc_date_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpk_date.Value = mc_date.SelectionRange.Start;
            cbSDate.Checked = true;

        }

        private void dtpk_date_ValueChanged(object sender, EventArgs e)
        {
            mc_date.SetDate(dtpk_date.Value);
            cbSDate.Checked = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void getDataSearch()
        {
            String date = dtpk_date.Text;
            int catId = Convert.ToInt32(cb_type.SelectedValue.ToString());
            //            foreach (var checkedItem in clbTimeTag.CheckedItems)
            //                checkedItem;
            //            String timeFrom, String timeTo, List<int> timeTag
            List<int> timeTag = null;
            timeTag = new List<int>();
            foreach (object item in clbTimeTag.CheckedItems)
            {
                TimeTag tag = (TimeTag)item;
                timeTag.Add(tag.TimeTagID);

            }

        }

        private void btAll_Click(object sender, EventArgs e)
        {
            TaskContext tc = new TaskContext();
            List<Task> tasks = tc.GetAllTasks();
            reloadData(tasks);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            //            getDataSearch();
            String date = dtpk_date.Text;
            if (!cbSDate.Checked) date = null;
            int? catId = Convert.ToInt32(cb_type.SelectedValue.ToString());
            if (!cbSCategory.Checked || catId == 1)
            {
                catId = null;
            }
            //            foreach (var checkedItem in clbTimeTag.CheckedItems)
            //                checkedItem;
            //            String timeFrom, String timeTo, List<int> timeTag
            List<int> timeTag = null;
            timeTag = new List<int>();
            foreach (object item in clbTimeTag.CheckedItems)
            {
                TimeTag tag = (TimeTag)item;
                timeTag.Add(tag.TimeTagID);

            }
            if (!cbSTag.Checked)
            {
                timeTag = null;
            }
            String timeFrom = null;
            String timeTo = null;
            if (dtpk_timeFrom.Checked)
            {
                timeFrom = dtpk_timeFrom.Text;
                Console.WriteLine(timeFrom);
            }
            if (dtpk_timeTo.Checked)
            {
                timeTo = dtpk_timeTo.Text;
                Console.WriteLine(timeTo);
            }
            String name = tbSearchName.Text;
            if (!cbSName.Checked)
            {
                name = null;
            }

            List<Task> searchTasks = tc.SearchTasks(name, date, catId, timeFrom, timeTo, timeTag);
            reloadData(searchTasks);
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSCategory.Checked = true;
            DataTable dataTable = db.GetAllTimeTags(Convert.ToInt32(cb_type.SelectedValue));
            List<TimeTag> listTimeTag = new List<TimeTag>();
            listTimeTag = db.getListTimeTag(dataTable, listTimeTag);
            clbTimeTag.DataSource = listTimeTag;
            clbTimeTag.DisplayMember = "TimeTagName";
            clbTimeTag.ValueMember = "TimeTagID";

        }

        private void cbSName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cbACategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable allTimeTags = db.GetAllTimeTags(Convert.ToInt32(cbACategory.SelectedValue));
            List<TimeTag> list = new List<TimeTag>();
//            list.Add(new TimeTag(-1, "None", "00:01", "23:59"));

            db.getListTimeTag(allTimeTags, list);

            cbATimeTag.DataSource = list;
            cbATimeTag.DisplayMember = "TimeTagName";
            cbATimeTag.ValueMember = "TimeTagID";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable allTimeTags = db.GetAllTimeTags(Convert.ToInt32(cb_type.SelectedValue));
            List<TimeTag> list = new List<TimeTag>();
            list.Add(new TimeTag(-1, "None", "00:01", "23:59"));

            list = db.getListTimeTag(allTimeTags, list);
            clbTimeTag.DataSource = list;
            clbTimeTag.DisplayMember = "TimeTagName";
            clbTimeTag.ValueMember = "TimeTagID";

        }

        private void cbFull_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFull.Checked)
            {
                dtpk_AtimeFrom.Checked = false;
                dtpk_AtimeTo.Checked = false; dtpk_AtimeFrom.Enabled = false;
                dtpk_AtimeTo.Enabled = false;
            }
            else
            {
                dtpk_AtimeFrom.Checked = true;
                dtpk_AtimeTo.Checked = true; dtpk_AtimeFrom.Enabled = true;
                dtpk_AtimeTo.Enabled = true;
            }
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            btSave.date = dtpk_ADate;
            btSave.category = cbACategory;
            btSave.timeTo = dtpk_AtimeTo;
            btSave.timeFrom = dtpk_AtimeFrom;
            String timeFrom = dtpk_AtimeFrom.Text;
            String timeTo = dtpk_AtimeTo.Text;
            if (Convert.ToDateTime(timeTo) < Convert.ToDateTime(timeFrom))
            {
                MessageBox.Show("timeTo > timeFrom please"); return;
            }
            btSave.isFullDay = cbFull;
            btSave.p1 = rdP1;
            btSave.p2 = rdP2;
            btSave.p3 = rdP3;
            btSave.p4 = rdP4;
            btSave.p5 = rdP5;
            btSave.detail = tbADetail;
            btSave.timeTag = cbATimeTag;
            btSave.loction = tbALoc;
            btSave.taskName = tbAName;
            if (tbAName.Text.Equals("") || tbAName.Text == null)
            {
                MessageBox.Show("Enter Name");
                return;
              
            }
            //
            bool task = tc.insertTask(btSave.getData());
            if (task)
            {
                MessageBox.Show("save");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpk_ADate.Value = monthCalendar1.SelectionRange.Start;
           
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void myButton1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            bool addCate = db.addCate(name);
            if (addCate)
            {
                label17.Text = "Add new category : " + name;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            DataTable allCategory = db.getAllCategory();
            comboBox1.DataSource = allCategory;
            comboBox1.DisplayMember = "categoryName";
            comboBox1.ValueMember = "categoryID";

        }

        private void expandCollapsePanel3_SizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ahih");
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            int catid = Convert.ToInt32(comboBox1.SelectedValue);
            Console.WriteLine(catid);
            String name = textBox2.Text;
            String timeFrom = dateTimePicker1.Text;
            String timeTo = dateTimePicker2.Text;
            Console.WriteLine(timeFrom);
            Console.WriteLine(timeTo);
            if (Convert.ToDateTime(timeTo) < Convert.ToDateTime(timeFrom))
            {
                MessageBox.Show("timeTo > timeFrom please");return;
            }
            bool addTimeTag = db.addTimeTag(new TimeTag(catid, name, timeFrom, timeTo));
            if (addTimeTag)
            {
                label18.Text = "Add new tag : " + name;
            }
        }

        private void expandCollapsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }



    class MyButton : Button
    {
        public MyButton(ExpandCollapsePanel panel)
        {
            this.panel = panel;
        }

        public MyButton()
        {
        }

        public MyButton(int id, TextBox taskName, DateTimePicker timeFrom, DateTimePicker timeTo, TextBox loction, TextBox detail, RadioButton p1, RadioButton p2, RadioButton p3, RadioButton p4, RadioButton p5, ComboBox timeTag, ComboBox category, CheckBox isFullDay, DateTimePicker date)
        {
            this.id = id;
            this.taskName = taskName;
            this.timeFrom = timeFrom;
            this.timeTo = timeTo;
            this.loction = loction;
            this.detail = detail;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.timeTag = timeTag;
            this.category = category;
            this.isFullDay = isFullDay;
            this.date = date;
        }

        public MyButton(int id)
        {
            this.id = id;
        }

        public MyButton(int taskTaskId, ExpandCollapsePanel ecp)
        {
            id = taskTaskId;
            ecp = panel;
        }

        public int id { get; set; }
        public ExpandCollapsePanel panel { get; set; }
        public TextBox taskName { get; set; }
        public DateTimePicker timeFrom { get; set; }
        public DateTimePicker timeTo { get; set; }
        public TextBox loction { get; set; }
        public TextBox detail { get; set; }
        public RadioButton p1 { get; set; }
        public RadioButton p2 { get; set; }
        public RadioButton p3 { get; set; }
        public RadioButton p4 { get; set; }
        public RadioButton p5 { get; set; }
        public ComboBox timeTag { get; set; }
        public ComboBox category { get; set; }
        public CheckBox isFullDay { get; set; }
        public DateTimePicker date { get; set; }

        public void enDisable()
        {
            taskName.Enabled = !taskName.Enabled;
            timeFrom.Enabled = !timeFrom.Enabled;
            timeTo.Enabled = !timeTo.Enabled;
            loction.Enabled = !loction.Enabled;
            detail.Enabled = !detail.Enabled;
            p1.Enabled = !p1.Enabled;
            p2.Enabled = !p2.Enabled;
            p3.Enabled = !p3.Enabled;
            p4.Enabled = !p4.Enabled;
            p5.Enabled = !p5.Enabled;
            timeTag.Enabled = !timeTag.Enabled;
            category.Enabled = !category.Enabled;
            isFullDay.Enabled = !isFullDay.Enabled;
            date.Enabled = !date.Enabled;


        }
        public Task getData()
        {
            Task t = new Task();
            t.TaskID = id;
            t.TaskName = taskName.Text;
            t.Location = loction.Text;
            t.CategoryID = Convert.ToInt32(category.SelectedValue);
            t.Date = date.Value;
            t.IsFullDay = isFullDay.Checked;
            if (isFullDay.Checked)
            {
                t.TimeFrom = "00:01";
                t.TimeTo = "23:59";
            }
            t.Detail = detail.Text;
            t.TimeFrom = timeFrom.Text;
            t.TimeTo = timeTo.Text;
            t.TimeTagID = Convert.ToInt32(timeTag.SelectedValue);
            if (p1.Checked)
            {
                t.Priority = 1;
            }
            else if (p2.Checked)
            {
                t.Priority = 2;
            }
            else if (p3.Checked)
            {
                t.Priority = 3;
            }
            else if (p4.Checked)
            {
                t.Priority = 4;
            }
            else if (p5.Checked)
            {
                t.Priority = 5;
            }

            return t;
        }


    }


}
