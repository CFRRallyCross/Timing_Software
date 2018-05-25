namespace CFR_RallyCross
{
    partial class frm_Create_Event
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Create_Event));
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.lbl_Number = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.dt_Event_Date = new System.Windows.Forms.DateTimePicker();
            this.lbl_Venue = new System.Windows.Forms.Label();
            this.cmb_Venue = new System.Windows.Forms.ComboBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Number
            // 
            this.txt_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Number.Location = new System.Drawing.Point(132, 12);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(140, 26);
            this.txt_Number.TabIndex = 0;
            // 
            // lbl_Number
            // 
            this.lbl_Number.AutoSize = true;
            this.lbl_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Number.Location = new System.Drawing.Point(12, 15);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(114, 20);
            this.lbl_Number.TabIndex = 1;
            this.lbl_Number.Text = "Event Number:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(12, 47);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(100, 20);
            this.lbl_Name.TabIndex = 3;
            this.lbl_Name.Text = "Event Name:";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(132, 44);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(140, 26);
            this.txt_Name.TabIndex = 2;
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date.Location = new System.Drawing.Point(12, 81);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(93, 20);
            this.lbl_Date.TabIndex = 5;
            this.lbl_Date.Text = "Event Date:";
            // 
            // dt_Event_Date
            // 
            this.dt_Event_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Event_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Event_Date.Location = new System.Drawing.Point(132, 76);
            this.dt_Event_Date.Name = "dt_Event_Date";
            this.dt_Event_Date.Size = new System.Drawing.Size(140, 26);
            this.dt_Event_Date.TabIndex = 6;
            this.dt_Event_Date.Value = new System.DateTime(2018, 5, 14, 13, 53, 7, 380);
            // 
            // lbl_Venue
            // 
            this.lbl_Venue.AutoSize = true;
            this.lbl_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Venue.Location = new System.Drawing.Point(12, 111);
            this.lbl_Venue.Name = "lbl_Venue";
            this.lbl_Venue.Size = new System.Drawing.Size(60, 20);
            this.lbl_Venue.TabIndex = 7;
            this.lbl_Venue.Text = "Venue:";
            // 
            // cmb_Venue
            // 
            this.cmb_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Venue.FormattingEnabled = true;
            this.cmb_Venue.Location = new System.Drawing.Point(132, 108);
            this.cmb_Venue.Name = "cmb_Venue";
            this.cmb_Venue.Size = new System.Drawing.Size(140, 28);
            this.cmb_Venue.TabIndex = 8;
            // 
            // btn_Create
            // 
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create.Location = new System.Drawing.Point(12, 142);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(260, 31);
            this.btn_Create.TabIndex = 9;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(12, 179);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(126, 27);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(146, 179);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(126, 27);
            this.btn_Close.TabIndex = 11;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frm_Create_Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.cmb_Venue);
            this.Controls.Add(this.lbl_Venue);
            this.Controls.Add(this.dt_Event_Date);
            this.Controls.Add(this.lbl_Date);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Number);
            this.Controls.Add(this.txt_Number);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Create_Event";
            this.Text = "Create Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.Label lbl_Number;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.DateTimePicker dt_Event_Date;
        private System.Windows.Forms.Label lbl_Venue;
        private System.Windows.Forms.ComboBox cmb_Venue;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Close;
    }
}