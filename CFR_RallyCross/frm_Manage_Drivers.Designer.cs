namespace CFR_RallyCross
{
    partial class frm_Manage_Drivers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Drivers));
            this.dgv_Drivers = new System.Windows.Forms.DataGridView();
            this.clm_DriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_MemberNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Hometown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Drivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Drivers
            // 
            this.dgv_Drivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Drivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_DriverID,
            this.clm_Last,
            this.clm_First,
            this.clm_MemberNumber,
            this.clm_Hometown,
            this.clm_Email});
            this.dgv_Drivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Drivers.Location = new System.Drawing.Point(0, 0);
            this.dgv_Drivers.Name = "dgv_Drivers";
            this.dgv_Drivers.Size = new System.Drawing.Size(624, 380);
            this.dgv_Drivers.TabIndex = 0;
            // 
            // clm_DriverID
            // 
            this.clm_DriverID.HeaderText = "ID";
            this.clm_DriverID.Name = "clm_DriverID";
            this.clm_DriverID.ReadOnly = true;
            this.clm_DriverID.Width = 50;
            // 
            // clm_Last
            // 
            this.clm_Last.HeaderText = "Last Name";
            this.clm_Last.Name = "clm_Last";
            // 
            // clm_First
            // 
            this.clm_First.HeaderText = "First Name";
            this.clm_First.Name = "clm_First";
            // 
            // clm_MemberNumber
            // 
            this.clm_MemberNumber.HeaderText = "Member #";
            this.clm_MemberNumber.Name = "clm_MemberNumber";
            // 
            // clm_Hometown
            // 
            this.clm_Hometown.HeaderText = "Hometown";
            this.clm_Hometown.Name = "clm_Hometown";
            // 
            // clm_Email
            // 
            this.clm_Email.HeaderText = "Email";
            this.clm_Email.Name = "clm_Email";
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(12, 12);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(125, 31);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(143, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(125, 31);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(487, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(125, 31);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Drivers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Update);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Close);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Delete);
            this.splitContainer1.Size = new System.Drawing.Size(624, 441);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 4;
            // 
            // frm_Manage_Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 1024);
            this.Name = "frm_Manage_Drivers";
            this.Text = "Manage Drivers";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Drivers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Drivers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_DriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_First;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_MemberNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Hometown;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Email;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}