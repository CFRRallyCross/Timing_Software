namespace CFR_RallyCross
{
    partial class frm_Manage_Events
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Events));
            this.dgv_Events = new System.Windows.Forms.DataGridView();
            this.clm_DriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_VenueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Events)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Events
            // 
            this.dgv_Events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Events.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_DriverID,
            this.clm_Number,
            this.clm_Name,
            this.clm_Date,
            this.clm_Status,
            this.clm_VenueID});
            this.dgv_Events.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Events.Location = new System.Drawing.Point(0, 0);
            this.dgv_Events.Name = "dgv_Events";
            this.dgv_Events.Size = new System.Drawing.Size(624, 380);
            this.dgv_Events.TabIndex = 1;
            // 
            // clm_DriverID
            // 
            this.clm_DriverID.HeaderText = "ID";
            this.clm_DriverID.Name = "clm_DriverID";
            this.clm_DriverID.ReadOnly = true;
            this.clm_DriverID.Width = 50;
            // 
            // clm_Number
            // 
            this.clm_Number.HeaderText = "Event #";
            this.clm_Number.Name = "clm_Number";
            this.clm_Number.Width = 75;
            // 
            // clm_Name
            // 
            this.clm_Name.HeaderText = "Name";
            this.clm_Name.Name = "clm_Name";
            this.clm_Name.Width = 150;
            // 
            // clm_Date
            // 
            this.clm_Date.HeaderText = "Date";
            this.clm_Date.Name = "clm_Date";
            // 
            // clm_Status
            // 
            this.clm_Status.HeaderText = "Status";
            this.clm_Status.Name = "clm_Status";
            this.clm_Status.Width = 75;
            // 
            // clm_VenueID
            // 
            this.clm_VenueID.HeaderText = "Venue ID";
            this.clm_VenueID.Name = "clm_VenueID";
            this.clm_VenueID.Width = 75;
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(487, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(125, 31);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(274, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(125, 31);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(143, 12);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(125, 31);
            this.btn_Update.TabIndex = 4;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create.Location = new System.Drawing.Point(12, 12);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(125, 31);
            this.btn_Create.TabIndex = 7;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Events);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Create);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Update);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Close);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Delete);
            this.splitContainer1.Size = new System.Drawing.Size(624, 441);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 8;
            // 
            // frm_Manage_Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 1024);
            this.Name = "frm_Manage_Events";
            this.Text = "Manage Events";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Events)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Events;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_DriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_VenueID;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}