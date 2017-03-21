namespace MyCelendar
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tab = new System.Windows.Forms.TabControl();
            this.tbView = new System.Windows.Forms.TabPage();
            this.panelView = new System.Windows.Forms.Panel();
            this.gbTask = new System.Windows.Forms.GroupBox();
            this.pMyTask = new MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel();
            this.pCategory = new System.Windows.Forms.Panel();
            this.clbTimeTag = new System.Windows.Forms.CheckedListBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.taskCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myCelendarDataSet = new MyCelendar.MyCelendarDataSet();
            this.pCelendar = new System.Windows.Forms.Panel();
            this.mc_date = new System.Windows.Forms.MonthCalendar();
            this.dtpk_date = new System.Windows.Forms.DateTimePicker();
            this.tbAdd = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskCategoryTableAdapter = new MyCelendar.MyCelendarDataSetTableAdapters.TaskCategoryTableAdapter();
            this.tab.SuspendLayout();
            this.tbView.SuspendLayout();
            this.panelView.SuspendLayout();
            this.gbTask.SuspendLayout();
            this.pCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myCelendarDataSet)).BeginInit();
            this.pCelendar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tbView);
            this.tab.Controls.Add(this.tbAdd);
            this.tab.Location = new System.Drawing.Point(4, 27);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(832, 599);
            this.tab.TabIndex = 6;
            // 
            // tbView
            // 
            this.tbView.Controls.Add(this.panelView);
            this.tbView.Location = new System.Drawing.Point(4, 22);
            this.tbView.Name = "tbView";
            this.tbView.Padding = new System.Windows.Forms.Padding(3);
            this.tbView.Size = new System.Drawing.Size(824, 573);
            this.tbView.TabIndex = 0;
            this.tbView.Text = "View";
            this.tbView.UseVisualStyleBackColor = true;
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.gbTask);
            this.panelView.Controls.Add(this.pCategory);
            this.panelView.Controls.Add(this.pCelendar);
            this.panelView.Location = new System.Drawing.Point(3, 3);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(808, 564);
            this.panelView.TabIndex = 4;
            // 
            // gbTask
            // 
            this.gbTask.Controls.Add(this.pMyTask);
            this.gbTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTask.Location = new System.Drawing.Point(246, 9);
            this.gbTask.Name = "gbTask";
            this.gbTask.Padding = new System.Windows.Forms.Padding(30);
            this.gbTask.Size = new System.Drawing.Size(559, 538);
            this.gbTask.TabIndex = 5;
            this.gbTask.TabStop = false;
            this.gbTask.Text = "My Task";
            // 
            // pMyTask
            // 
            this.pMyTask.AutoScroll = true;
            this.pMyTask.Location = new System.Drawing.Point(19, 40);
            this.pMyTask.Name = "pMyTask";
            this.pMyTask.Size = new System.Drawing.Size(526, 498);
            this.pMyTask.TabIndex = 0;
            // 
            // pCategory
            // 
            this.pCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCategory.Controls.Add(this.clbTimeTag);
            this.pCategory.Controls.Add(this.cb_type);
            this.pCategory.Location = new System.Drawing.Point(6, 218);
            this.pCategory.Name = "pCategory";
            this.pCategory.Size = new System.Drawing.Size(234, 329);
            this.pCategory.TabIndex = 4;
            // 
            // clbTimeTag
            // 
            this.clbTimeTag.FormattingEnabled = true;
            this.clbTimeTag.Location = new System.Drawing.Point(4, 31);
            this.clbTimeTag.Name = "clbTimeTag";
            this.clbTimeTag.Size = new System.Drawing.Size(223, 289);
            this.clbTimeTag.TabIndex = 1;
            // 
            // cb_type
            // 
            this.cb_type.DataSource = this.taskCategoryBindingSource;
            this.cb_type.DisplayMember = "categoryName";
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(4, 4);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(223, 21);
            this.cb_type.TabIndex = 0;
            this.cb_type.ValueMember = "categoryID";
            // 
            // taskCategoryBindingSource
            // 
            this.taskCategoryBindingSource.DataMember = "TaskCategory";
            this.taskCategoryBindingSource.DataSource = this.myCelendarDataSet;
            // 
            // myCelendarDataSet
            // 
            this.myCelendarDataSet.DataSetName = "MyCelendarDataSet";
            this.myCelendarDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pCelendar
            // 
            this.pCelendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCelendar.Controls.Add(this.mc_date);
            this.pCelendar.Controls.Add(this.dtpk_date);
            this.pCelendar.Location = new System.Drawing.Point(3, 9);
            this.pCelendar.Name = "pCelendar";
            this.pCelendar.Size = new System.Drawing.Size(234, 202);
            this.pCelendar.TabIndex = 3;
            // 
            // mc_date
            // 
            this.mc_date.Location = new System.Drawing.Point(3, 25);
            this.mc_date.Name = "mc_date";
            this.mc_date.TabIndex = 0;
            this.mc_date.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_date_DateChanged);
            // 
            // dtpk_date
            // 
            this.dtpk_date.Location = new System.Drawing.Point(3, 3);
            this.dtpk_date.Name = "dtpk_date";
            this.dtpk_date.Size = new System.Drawing.Size(227, 20);
            this.dtpk_date.TabIndex = 2;
            this.dtpk_date.ValueChanged += new System.EventHandler(this.dtpk_date_ValueChanged);
            // 
            // tbAdd
            // 
            this.tbAdd.Location = new System.Drawing.Point(4, 22);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tbAdd.Size = new System.Drawing.Size(824, 573);
            this.tbAdd.TabIndex = 1;
            this.tbAdd.Text = "Add";
            this.tbAdd.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // taskCategoryTableAdapter
            // 
            this.taskCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 633);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fMain";
            this.Text = "My Celendar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab.ResumeLayout(false);
            this.tbView.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            this.gbTask.ResumeLayout(false);
            this.pCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myCelendarDataSet)).EndInit();
            this.pCelendar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tbView;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Panel pCategory;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Panel pCelendar;
        private System.Windows.Forms.MonthCalendar mc_date;
        private System.Windows.Forms.DateTimePicker dtpk_date;
        private System.Windows.Forms.TabPage tbAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbTask;
        private System.Windows.Forms.CheckedListBox clbTimeTag;
        private MyCelendarDataSet myCelendarDataSet;
        private System.Windows.Forms.BindingSource taskCategoryBindingSource;
        private MyCelendarDataSetTableAdapters.TaskCategoryTableAdapter taskCategoryTableAdapter;
        private MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel pMyTask;
    }
}

