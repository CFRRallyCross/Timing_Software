namespace CFR_RallyCross
{
    partial class frm_Register_Driver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Register_Driver));
            this.cmb_FirstName = new System.Windows.Forms.ComboBox();
            this.cmb_LastName = new System.Windows.Forms.ComboBox();
            this.lbl_First = new System.Windows.Forms.Label();
            this.lbl_last = new System.Windows.Forms.Label();
            this.lbl_Event = new System.Windows.Forms.Label();
            this.cmb_Event = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Hometown = new System.Windows.Forms.ComboBox();
            this.cmb_MemberNumber = new System.Windows.Forms.ComboBox();
            this.cmb_Model = new System.Windows.Forms.ComboBox();
            this.cmb_Year = new System.Windows.Forms.ComboBox();
            this.cmb_Make = new System.Windows.Forms.ComboBox();
            this.cmb_Class = new System.Windows.Forms.ComboBox();
            this.txt_VehicleNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_PaymentType = new System.Windows.Forms.ComboBox();
            this.cmb_PaymentReceived = new System.Windows.Forms.ComboBox();
            this.cmb_CheckedIn = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_PaymentAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.dgv_Registration = new System.Windows.Forms.DataGridView();
            this.clm_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_PaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_PaymentReceived = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clm_CheckedIN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Registration)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_FirstName
            // 
            this.cmb_FirstName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_FirstName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_FirstName.FormattingEnabled = true;
            this.cmb_FirstName.Location = new System.Drawing.Point(117, 60);
            this.cmb_FirstName.Name = "cmb_FirstName";
            this.cmb_FirstName.Size = new System.Drawing.Size(216, 21);
            this.cmb_FirstName.TabIndex = 2;
            // 
            // cmb_LastName
            // 
            this.cmb_LastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_LastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_LastName.FormattingEnabled = true;
            this.cmb_LastName.Location = new System.Drawing.Point(117, 87);
            this.cmb_LastName.Name = "cmb_LastName";
            this.cmb_LastName.Size = new System.Drawing.Size(216, 21);
            this.cmb_LastName.TabIndex = 3;
            // 
            // lbl_First
            // 
            this.lbl_First.AutoSize = true;
            this.lbl_First.Location = new System.Drawing.Point(12, 63);
            this.lbl_First.Name = "lbl_First";
            this.lbl_First.Size = new System.Drawing.Size(60, 13);
            this.lbl_First.TabIndex = 20;
            this.lbl_First.Text = "First Name:";
            // 
            // lbl_last
            // 
            this.lbl_last.AutoSize = true;
            this.lbl_last.Location = new System.Drawing.Point(12, 90);
            this.lbl_last.Name = "lbl_last";
            this.lbl_last.Size = new System.Drawing.Size(61, 13);
            this.lbl_last.TabIndex = 21;
            this.lbl_last.Text = "Last Name:";
            // 
            // lbl_Event
            // 
            this.lbl_Event.AutoSize = true;
            this.lbl_Event.Location = new System.Drawing.Point(12, 9);
            this.lbl_Event.Name = "lbl_Event";
            this.lbl_Event.Size = new System.Drawing.Size(78, 13);
            this.lbl_Event.TabIndex = 19;
            this.lbl_Event.Text = "Event Number:";
            // 
            // cmb_Event
            // 
            this.cmb_Event.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Event.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Event.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Event.FormattingEnabled = true;
            this.cmb_Event.Location = new System.Drawing.Point(117, 6);
            this.cmb_Event.Name = "cmb_Event";
            this.cmb_Event.Size = new System.Drawing.Size(216, 21);
            this.cmb_Event.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Hometown:";
            // 
            // cmb_Hometown
            // 
            this.cmb_Hometown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Hometown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Hometown.FormattingEnabled = true;
            this.cmb_Hometown.Location = new System.Drawing.Point(117, 114);
            this.cmb_Hometown.Name = "cmb_Hometown";
            this.cmb_Hometown.Size = new System.Drawing.Size(216, 21);
            this.cmb_Hometown.TabIndex = 4;
            // 
            // cmb_MemberNumber
            // 
            this.cmb_MemberNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_MemberNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_MemberNumber.FormattingEnabled = true;
            this.cmb_MemberNumber.Location = new System.Drawing.Point(117, 33);
            this.cmb_MemberNumber.Name = "cmb_MemberNumber";
            this.cmb_MemberNumber.Size = new System.Drawing.Size(216, 21);
            this.cmb_MemberNumber.TabIndex = 1;
            this.cmb_MemberNumber.SelectedIndexChanged += new System.EventHandler(this.cmb_MemberNumber_SelectedIndexChanged);
            // 
            // cmb_Model
            // 
            this.cmb_Model.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Model.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Model.FormattingEnabled = true;
            this.cmb_Model.Location = new System.Drawing.Point(117, 248);
            this.cmb_Model.Name = "cmb_Model";
            this.cmb_Model.Size = new System.Drawing.Size(216, 21);
            this.cmb_Model.TabIndex = 9;
            // 
            // cmb_Year
            // 
            this.cmb_Year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Year.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Year.FormattingEnabled = true;
            this.cmb_Year.Location = new System.Drawing.Point(117, 194);
            this.cmb_Year.Name = "cmb_Year";
            this.cmb_Year.Size = new System.Drawing.Size(216, 21);
            this.cmb_Year.TabIndex = 7;
            // 
            // cmb_Make
            // 
            this.cmb_Make.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Make.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Make.FormattingEnabled = true;
            this.cmb_Make.Location = new System.Drawing.Point(117, 221);
            this.cmb_Make.Name = "cmb_Make";
            this.cmb_Make.Size = new System.Drawing.Size(216, 21);
            this.cmb_Make.TabIndex = 8;
            // 
            // cmb_Class
            // 
            this.cmb_Class.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Class.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Class.FormattingEnabled = true;
            this.cmb_Class.Location = new System.Drawing.Point(117, 167);
            this.cmb_Class.Name = "cmb_Class";
            this.cmb_Class.Size = new System.Drawing.Size(216, 21);
            this.cmb_Class.TabIndex = 6;
            // 
            // txt_VehicleNumber
            // 
            this.txt_VehicleNumber.Location = new System.Drawing.Point(117, 141);
            this.txt_VehicleNumber.Name = "txt_VehicleNumber";
            this.txt_VehicleNumber.Size = new System.Drawing.Size(216, 20);
            this.txt_VehicleNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "SCCA Member #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Vehicle #:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Class:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Make:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Model:";
            // 
            // cmb_PaymentType
            // 
            this.cmb_PaymentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_PaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_PaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PaymentType.FormattingEnabled = true;
            this.cmb_PaymentType.Items.AddRange(new object[] {
            "Cash",
            "Credit Card"});
            this.cmb_PaymentType.Location = new System.Drawing.Point(117, 275);
            this.cmb_PaymentType.Name = "cmb_PaymentType";
            this.cmb_PaymentType.Size = new System.Drawing.Size(216, 21);
            this.cmb_PaymentType.TabIndex = 10;
            // 
            // cmb_PaymentReceived
            // 
            this.cmb_PaymentReceived.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_PaymentReceived.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_PaymentReceived.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PaymentReceived.FormattingEnabled = true;
            this.cmb_PaymentReceived.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmb_PaymentReceived.Location = new System.Drawing.Point(117, 302);
            this.cmb_PaymentReceived.Name = "cmb_PaymentReceived";
            this.cmb_PaymentReceived.Size = new System.Drawing.Size(216, 21);
            this.cmb_PaymentReceived.TabIndex = 11;
            // 
            // cmb_CheckedIn
            // 
            this.cmb_CheckedIn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_CheckedIn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_CheckedIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CheckedIn.FormattingEnabled = true;
            this.cmb_CheckedIn.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmb_CheckedIn.Location = new System.Drawing.Point(117, 329);
            this.cmb_CheckedIn.Name = "cmb_CheckedIn";
            this.cmb_CheckedIn.Size = new System.Drawing.Size(216, 21);
            this.cmb_CheckedIn.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Payment Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Payment Received:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Checked In:";
            // 
            // txt_PaymentAmount
            // 
            this.txt_PaymentAmount.Location = new System.Drawing.Point(117, 356);
            this.txt_PaymentAmount.Name = "txt_PaymentAmount";
            this.txt_PaymentAmount.Size = new System.Drawing.Size(216, 20);
            this.txt_PaymentAmount.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 359);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Payment Amount:";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(15, 390);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 28;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(96, 390);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 14;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // dgv_Registration
            // 
            this.dgv_Registration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Registration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_ID,
            this.clm_FirstName,
            this.clm_LastName,
            this.clm_Class,
            this.clm_Number,
            this.clm_PaymentAmount,
            this.clm_PaymentReceived,
            this.clm_CheckedIN});
            this.dgv_Registration.Location = new System.Drawing.Point(348, 6);
            this.dgv_Registration.Name = "dgv_Registration";
            this.dgv_Registration.Size = new System.Drawing.Size(782, 370);
            this.dgv_Registration.TabIndex = 29;
            // 
            // clm_ID
            // 
            this.clm_ID.HeaderText = "ID";
            this.clm_ID.Name = "clm_ID";
            this.clm_ID.ReadOnly = true;
            this.clm_ID.Width = 25;
            // 
            // clm_FirstName
            // 
            this.clm_FirstName.HeaderText = "First";
            this.clm_FirstName.Name = "clm_FirstName";
            this.clm_FirstName.ReadOnly = true;
            this.clm_FirstName.Width = 125;
            // 
            // clm_LastName
            // 
            this.clm_LastName.HeaderText = "Last";
            this.clm_LastName.Name = "clm_LastName";
            this.clm_LastName.ReadOnly = true;
            this.clm_LastName.Width = 125;
            // 
            // clm_Class
            // 
            this.clm_Class.HeaderText = "Class";
            this.clm_Class.Name = "clm_Class";
            this.clm_Class.Width = 50;
            // 
            // clm_Number
            // 
            this.clm_Number.HeaderText = "Number";
            this.clm_Number.Name = "clm_Number";
            this.clm_Number.Width = 50;
            // 
            // clm_PaymentAmount
            // 
            this.clm_PaymentAmount.HeaderText = "Payment Amount";
            this.clm_PaymentAmount.Name = "clm_PaymentAmount";
            this.clm_PaymentAmount.Width = 125;
            // 
            // clm_PaymentReceived
            // 
            this.clm_PaymentReceived.HeaderText = "Payment Received";
            this.clm_PaymentReceived.Name = "clm_PaymentReceived";
            this.clm_PaymentReceived.Width = 125;
            // 
            // clm_CheckedIN
            // 
            this.clm_CheckedIN.HeaderText = "Checked In";
            this.clm_CheckedIN.Name = "clm_CheckedIN";
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(348, 390);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 30;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(177, 390);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 31;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(429, 390);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Remove.TabIndex = 32;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(1055, 390);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(75, 23);
            this.btn_Import.TabIndex = 33;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // frm_Register_Driver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 425);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.dgv_Registration);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_PaymentAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_CheckedIn);
            this.Controls.Add(this.cmb_PaymentReceived);
            this.Controls.Add(this.cmb_PaymentType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_VehicleNumber);
            this.Controls.Add(this.cmb_Class);
            this.Controls.Add(this.cmb_Make);
            this.Controls.Add(this.cmb_Year);
            this.Controls.Add(this.cmb_Model);
            this.Controls.Add(this.cmb_MemberNumber);
            this.Controls.Add(this.cmb_Hometown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Event);
            this.Controls.Add(this.lbl_Event);
            this.Controls.Add(this.lbl_last);
            this.Controls.Add(this.lbl_First);
            this.Controls.Add(this.cmb_LastName);
            this.Controls.Add(this.cmb_FirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Register_Driver";
            this.Text = "Register Driver";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Registration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_FirstName;
        private System.Windows.Forms.ComboBox cmb_LastName;
        private System.Windows.Forms.Label lbl_First;
        private System.Windows.Forms.Label lbl_last;
        private System.Windows.Forms.Label lbl_Event;
        private System.Windows.Forms.ComboBox cmb_Event;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Hometown;
        private System.Windows.Forms.ComboBox cmb_MemberNumber;
        private System.Windows.Forms.ComboBox cmb_Model;
        private System.Windows.Forms.ComboBox cmb_Year;
        private System.Windows.Forms.ComboBox cmb_Make;
        private System.Windows.Forms.ComboBox cmb_Class;
        private System.Windows.Forms.TextBox txt_VehicleNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_PaymentType;
        private System.Windows.Forms.ComboBox cmb_PaymentReceived;
        private System.Windows.Forms.ComboBox cmb_CheckedIn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_PaymentAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.DataGridView dgv_Registration;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_PaymentAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clm_PaymentReceived;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clm_CheckedIN;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Import;
    }
}