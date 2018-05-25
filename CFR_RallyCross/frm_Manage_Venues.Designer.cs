namespace CFR_RallyCross
{
    partial class frm_Manage_Venues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Venues));
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dgv_Venues = new System.Windows.Forms.DataGridView();
            this.clm_Venue_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Zip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create.Location = new System.Drawing.Point(12, 12);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(125, 31);
            this.btn_Create.TabIndex = 0;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(143, 12);
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
            this.btn_Delete.Location = new System.Drawing.Point(274, 12);
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
            // dgv_Venues
            // 
            this.dgv_Venues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Venues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_Venue_ID,
            this.clm_Name,
            this.clm_Address,
            this.clm_City,
            this.clm_State,
            this.clm_Zip});
            this.dgv_Venues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Venues.Location = new System.Drawing.Point(0, 0);
            this.dgv_Venues.Name = "dgv_Venues";
            this.dgv_Venues.Size = new System.Drawing.Size(624, 380);
            this.dgv_Venues.TabIndex = 4;
            // 
            // clm_Venue_ID
            // 
            this.clm_Venue_ID.HeaderText = "ID";
            this.clm_Venue_ID.Name = "clm_Venue_ID";
            this.clm_Venue_ID.ReadOnly = true;
            this.clm_Venue_ID.Width = 40;
            // 
            // clm_Name
            // 
            this.clm_Name.HeaderText = "Name";
            this.clm_Name.Name = "clm_Name";
            // 
            // clm_Address
            // 
            this.clm_Address.HeaderText = "Address";
            this.clm_Address.Name = "clm_Address";
            // 
            // clm_City
            // 
            this.clm_City.HeaderText = "City";
            this.clm_City.Name = "clm_City";
            // 
            // clm_State
            // 
            this.clm_State.HeaderText = "State";
            this.clm_State.Name = "clm_State";
            // 
            // clm_Zip
            // 
            this.clm_Zip.HeaderText = "Zip";
            this.clm_Zip.Name = "clm_Zip";
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
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Venues);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Create);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Close);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Update);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Delete);
            this.splitContainer1.Size = new System.Drawing.Size(624, 441);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 5;
            // 
            // frm_Manage_Venues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Manage_Venues";
            this.Text = "Manage Venues";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venues)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_Venues;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Venue_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_City;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Zip;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}