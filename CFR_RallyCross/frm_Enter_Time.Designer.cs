namespace CFR_RallyCross
{
    partial class frm_Enter_Time
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Enter_Time));
            this.dgv_TimeEntry = new System.Windows.Forms.DataGridView();
            this.clm_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_First_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Last_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Driver_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Stage_Review = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Raw_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Cones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Gates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Off_Course = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dgv_Stages_Completed = new System.Windows.Forms.DataGridView();
            this.clm_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Stages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_Vehicle_Number = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Raw_Entry = new System.Windows.Forms.Label();
            this.lbl_Cones_Entry = new System.Windows.Forms.Label();
            this.lbl_Gates_Entry = new System.Windows.Forms.Label();
            this.lbl_Off_Course = new System.Windows.Forms.Label();
            this.chk_OffCourse = new System.Windows.Forms.CheckBox();
            this.txt_RawTime = new System.Windows.Forms.MaskedTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.num_Gates = new System.Windows.Forms.NumericUpDown();
            this.num_Cones = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.btn_Update = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimeEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stages_Completed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Gates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Cones)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_TimeEntry
            // 
            this.dgv_TimeEntry.AllowUserToDeleteRows = false;
            this.dgv_TimeEntry.AllowUserToOrderColumns = true;
            this.dgv_TimeEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TimeEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_ID,
            this.clm_First_Name,
            this.clm_Last_Name,
            this.clm_Driver_Number,
            this.clm_Stage_Review,
            this.clm_Raw_Time,
            this.clm_Cones,
            this.clm_Gates,
            this.clm_Off_Course});
            this.dgv_TimeEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_TimeEntry.Location = new System.Drawing.Point(0, 0);
            this.dgv_TimeEntry.Name = "dgv_TimeEntry";
            this.dgv_TimeEntry.Size = new System.Drawing.Size(744, 180);
            this.dgv_TimeEntry.TabIndex = 10;
            // 
            // clm_ID
            // 
            this.clm_ID.HeaderText = "ID";
            this.clm_ID.Name = "clm_ID";
            this.clm_ID.ReadOnly = true;
            this.clm_ID.Width = 50;
            // 
            // clm_First_Name
            // 
            this.clm_First_Name.HeaderText = "First Name";
            this.clm_First_Name.Name = "clm_First_Name";
            this.clm_First_Name.ReadOnly = true;
            // 
            // clm_Last_Name
            // 
            this.clm_Last_Name.HeaderText = "Last Name";
            this.clm_Last_Name.Name = "clm_Last_Name";
            this.clm_Last_Name.ReadOnly = true;
            // 
            // clm_Driver_Number
            // 
            this.clm_Driver_Number.HeaderText = "Number";
            this.clm_Driver_Number.Name = "clm_Driver_Number";
            this.clm_Driver_Number.ReadOnly = true;
            this.clm_Driver_Number.Width = 50;
            // 
            // clm_Stage_Review
            // 
            this.clm_Stage_Review.HeaderText = "Stage";
            this.clm_Stage_Review.Name = "clm_Stage_Review";
            this.clm_Stage_Review.Width = 50;
            // 
            // clm_Raw_Time
            // 
            this.clm_Raw_Time.HeaderText = "Raw Time";
            this.clm_Raw_Time.Name = "clm_Raw_Time";
            this.clm_Raw_Time.Width = 80;
            // 
            // clm_Cones
            // 
            this.clm_Cones.HeaderText = "Cones";
            this.clm_Cones.Name = "clm_Cones";
            this.clm_Cones.Width = 50;
            // 
            // clm_Gates
            // 
            this.clm_Gates.HeaderText = "Gates";
            this.clm_Gates.Name = "clm_Gates";
            this.clm_Gates.Width = 50;
            // 
            // clm_Off_Course
            // 
            this.clm_Off_Course.HeaderText = "Off Course";
            this.clm_Off_Course.Name = "clm_Off_Course";
            this.clm_Off_Course.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clm_Off_Course.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clm_Off_Course.Width = 80;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(12, 193);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(144, 27);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(12, 157);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(294, 30);
            this.btn_Submit.TabIndex = 5;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(162, 193);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(144, 27);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dgv_Stages_Completed
            // 
            this.dgv_Stages_Completed.AllowUserToDeleteRows = false;
            this.dgv_Stages_Completed.AllowUserToResizeRows = false;
            this.dgv_Stages_Completed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Stages_Completed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_FirstName,
            this.clm_LastName,
            this.clm_Class,
            this.clm_Number,
            this.clm_Stages});
            this.dgv_Stages_Completed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Stages_Completed.Location = new System.Drawing.Point(0, 0);
            this.dgv_Stages_Completed.Name = "dgv_Stages_Completed";
            this.dgv_Stages_Completed.RowHeadersVisible = false;
            this.dgv_Stages_Completed.Size = new System.Drawing.Size(420, 230);
            this.dgv_Stages_Completed.TabIndex = 12;
            // 
            // clm_FirstName
            // 
            this.clm_FirstName.HeaderText = "First Name";
            this.clm_FirstName.Name = "clm_FirstName";
            this.clm_FirstName.ReadOnly = true;
            this.clm_FirstName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clm_FirstName.Width = 95;
            // 
            // clm_LastName
            // 
            this.clm_LastName.HeaderText = "Last Name";
            this.clm_LastName.Name = "clm_LastName";
            this.clm_LastName.ReadOnly = true;
            this.clm_LastName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clm_LastName.Width = 95;
            // 
            // clm_Class
            // 
            this.clm_Class.HeaderText = "Class";
            this.clm_Class.Name = "clm_Class";
            this.clm_Class.ReadOnly = true;
            this.clm_Class.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clm_Class.Width = 50;
            // 
            // clm_Number
            // 
            this.clm_Number.HeaderText = "Number";
            this.clm_Number.Name = "clm_Number";
            this.clm_Number.ReadOnly = true;
            this.clm_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clm_Number.Width = 50;
            // 
            // clm_Stages
            // 
            this.clm_Stages.HeaderText = "Stages Completed";
            this.clm_Stages.Name = "clm_Stages";
            this.clm_Stages.ReadOnly = true;
            this.clm_Stages.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmb_Vehicle_Number
            // 
            this.cmb_Vehicle_Number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Vehicle_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Vehicle_Number.FormattingEnabled = true;
            this.cmb_Vehicle_Number.Location = new System.Drawing.Point(185, 12);
            this.cmb_Vehicle_Number.Name = "cmb_Vehicle_Number";
            this.cmb_Vehicle_Number.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_Vehicle_Number.Size = new System.Drawing.Size(121, 33);
            this.cmb_Vehicle_Number.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Vehicle Number:";
            // 
            // lbl_Raw_Entry
            // 
            this.lbl_Raw_Entry.AutoSize = true;
            this.lbl_Raw_Entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Raw_Entry.Location = new System.Drawing.Point(69, 53);
            this.lbl_Raw_Entry.Name = "lbl_Raw_Entry";
            this.lbl_Raw_Entry.Size = new System.Drawing.Size(113, 25);
            this.lbl_Raw_Entry.TabIndex = 23;
            this.lbl_Raw_Entry.Text = "Raw Time:";
            // 
            // lbl_Cones_Entry
            // 
            this.lbl_Cones_Entry.AutoSize = true;
            this.lbl_Cones_Entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cones_Entry.Location = new System.Drawing.Point(15, 93);
            this.lbl_Cones_Entry.Name = "lbl_Cones_Entry";
            this.lbl_Cones_Entry.Size = new System.Drawing.Size(70, 24);
            this.lbl_Cones_Entry.TabIndex = 25;
            this.lbl_Cones_Entry.Text = "Cones:";
            // 
            // lbl_Gates_Entry
            // 
            this.lbl_Gates_Entry.AutoSize = true;
            this.lbl_Gates_Entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gates_Entry.Location = new System.Drawing.Point(115, 93);
            this.lbl_Gates_Entry.Name = "lbl_Gates_Entry";
            this.lbl_Gates_Entry.Size = new System.Drawing.Size(63, 24);
            this.lbl_Gates_Entry.TabIndex = 27;
            this.lbl_Gates_Entry.Text = "Gates:";
            // 
            // lbl_Off_Course
            // 
            this.lbl_Off_Course.AutoSize = true;
            this.lbl_Off_Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Off_Course.Location = new System.Drawing.Point(215, 93);
            this.lbl_Off_Course.Name = "lbl_Off_Course";
            this.lbl_Off_Course.Size = new System.Drawing.Size(54, 24);
            this.lbl_Off_Course.TabIndex = 29;
            this.lbl_Off_Course.Text = "DNF:";
            // 
            // chk_OffCourse
            // 
            this.chk_OffCourse.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_OffCourse.BackColor = System.Drawing.SystemColors.Window;
            this.chk_OffCourse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_OffCourse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_OffCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_OffCourse.Location = new System.Drawing.Point(212, 120);
            this.chk_OffCourse.Name = "chk_OffCourse";
            this.chk_OffCourse.Size = new System.Drawing.Size(94, 31);
            this.chk_OffCourse.TabIndex = 4;
            this.chk_OffCourse.Text = "NO";
            this.chk_OffCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_OffCourse.UseVisualStyleBackColor = false;
            this.chk_OffCourse.CheckedChanged += new System.EventHandler(this.chk_OffCourse_CheckedChanged);
            // 
            // txt_RawTime
            // 
            this.txt_RawTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RawTime.Location = new System.Drawing.Point(185, 50);
            this.txt_RawTime.Mask = "###.###";
            this.txt_RawTime.Name = "txt_RawTime";
            this.txt_RawTime.Size = new System.Drawing.Size(121, 31);
            this.txt_RawTime.TabIndex = 1;
            this.txt_RawTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.num_Gates);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.num_Cones);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Gates_Entry);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Off_Course);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Clear);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Cones_Entry);
            this.splitContainer1.Panel1.Controls.Add(this.txt_RawTime);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Raw_Entry);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Submit);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_Vehicle_Number);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Close);
            this.splitContainer1.Panel1.Controls.Add(this.chk_OffCourse);
            this.splitContainer1.Panel1MinSize = 320;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Stages_Completed);
            this.splitContainer1.Size = new System.Drawing.Size(744, 230);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 30;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1MinSize = 230;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_TimeEntry);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(744, 441);
            this.splitContainer2.SplitterDistance = 230;
            this.splitContainer2.TabIndex = 0;
            // 
            // num_Gates
            // 
            this.num_Gates.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Gates.Location = new System.Drawing.Point(112, 120);
            this.num_Gates.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.num_Gates.Name = "num_Gates";
            this.num_Gates.Size = new System.Drawing.Size(94, 31);
            this.num_Gates.TabIndex = 3;
            // 
            // num_Cones
            // 
            this.num_Cones.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Cones.Location = new System.Drawing.Point(12, 120);
            this.num_Cones.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.num_Cones.Name = "num_Cones";
            this.num_Cones.Size = new System.Drawing.Size(94, 31);
            this.num_Cones.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Delete,
            this.btn_Update});
            this.toolStrip1.Location = new System.Drawing.Point(0, 180);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(744, 27);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Delete
            // 
            this.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(101, 24);
            this.btn_Delete.Text = "Delete Entry";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(95, 24);
            this.btn_Update.Text = "Update List";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // frm_Enter_Time
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 441);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(760, 480);
            this.Name = "frm_Enter_Time";
            this.Text = "Enter Time";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimeEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stages_Completed)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_Gates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Cones)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_TimeEntry;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_Stages_Completed;
        private System.Windows.Forms.ComboBox cmb_Vehicle_Number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Raw_Entry;
        private System.Windows.Forms.Label lbl_Cones_Entry;
        private System.Windows.Forms.Label lbl_Gates_Entry;
        private System.Windows.Forms.Label lbl_Off_Course;
        private System.Windows.Forms.CheckBox chk_OffCourse;
        private System.Windows.Forms.MaskedTextBox txt_RawTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_First_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Last_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Driver_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Stage_Review;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Raw_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Cones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Gates;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clm_Off_Course;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Stages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Update;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.NumericUpDown num_Gates;
        private System.Windows.Forms.NumericUpDown num_Cones;
    }
}