namespace Task_14
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DVG1 = new DataGridView();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            TextBoxName = new TextBox();
            textBoxAge = new TextBox();
            textBoxAddress = new TextBox();
            textBoxGrade = new TextBox();
            TextBoxId = new TextBox();
            textBoxDeptid = new TextBox();
            DeptId = new Label();
            Grade = new Label();
            Address = new Label();
            Age = new Label();
            ID = new Label();
            Name = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)DVG1).BeginInit();
            SuspendLayout();
            // 
            // DVG1
            // 
            DVG1.AccessibleName = "";
            DVG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DVG1.Location = new Point(12, -3);
            DVG1.Name = "DVG1";
            DVG1.RowHeadersWidth = 51;
            DVG1.Size = new Size(799, 221);
            DVG1.TabIndex = 0;
            DVG1.CellContentClick += dataGridView1_CellContentClick;
            DVG1.RowHeaderMouseDoubleClick += DVG1_RowHeaderMouseDoubleClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(637, 370);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 369);
            button1.Name = "button1";
            button1.Size = new Size(144, 29);
            button1.TabIndex = 2;
            button1.Text = "Add Trainee";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(162, 369);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 4;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(262, 369);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(12, 234);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(125, 27);
            TextBoxName.TabIndex = 6;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new Point(274, 234);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(125, 27);
            textBoxAge.TabIndex = 7;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(405, 234);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(125, 27);
            textBoxAddress.TabIndex = 8;
            // 
            // textBoxGrade
            // 
            textBoxGrade.Location = new Point(536, 234);
            textBoxGrade.Name = "textBoxGrade";
            textBoxGrade.Size = new Size(125, 27);
            textBoxGrade.TabIndex = 9;
            // 
            // TextBoxId
            // 
            TextBoxId.Location = new Point(143, 234);
            TextBoxId.Name = "TextBoxId";
            TextBoxId.Size = new Size(125, 27);
            TextBoxId.TabIndex = 10;
            TextBoxId.TextChanged += TextBoxId_TextChanged;
            // 
            // textBoxDeptid
            // 
            textBoxDeptid.Location = new Point(667, 234);
            textBoxDeptid.Name = "textBoxDeptid";
            textBoxDeptid.Size = new Size(125, 27);
            textBoxDeptid.TabIndex = 11;
            // 
            // DeptId
            // 
            DeptId.AutoSize = true;
            DeptId.Location = new Point(700, 273);
            DeptId.Name = "DeptId";
            DeptId.Size = new Size(55, 20);
            DeptId.TabIndex = 12;
            DeptId.Text = "DeptId";
            DeptId.Click += label1_Click;
            // 
            // Grade
            // 
            Grade.AutoSize = true;
            Grade.Location = new Point(575, 273);
            Grade.Name = "Grade";
            Grade.Size = new Size(49, 20);
            Grade.TabIndex = 13;
            Grade.Text = "Grade";
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.Location = new Point(440, 273);
            Address.Name = "Address";
            Address.Size = new Size(62, 20);
            Address.TabIndex = 14;
            Address.Text = "Address";
            Address.Click += Address_Click;
            // 
            // Age
            // 
            Age.AutoSize = true;
            Age.Location = new Point(306, 273);
            Age.Name = "Age";
            Age.Size = new Size(36, 20);
            Age.TabIndex = 15;
            Age.Text = "Age";
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(179, 273);
            ID.Name = "ID";
            ID.Size = new Size(24, 20);
            ID.TabIndex = 16;
            ID.Text = "ID";
            ID.Click += label4_Click;
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(44, 273);
            Name.Name = "Name";
            Name.Size = new Size(49, 20);
            Name.TabIndex = 17;
            Name.Text = "Name";
            Name.Click += Name_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Name);
            Controls.Add(ID);
            Controls.Add(Age);
            Controls.Add(Address);
            Controls.Add(Grade);
            Controls.Add(DeptId);
            Controls.Add(textBoxDeptid);
            Controls.Add(TextBoxId);
            Controls.Add(textBoxGrade);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxAge);
            Controls.Add(TextBoxName);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(DVG1);
          //  Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)DVG1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DVG1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button3;
        private Button button4;
        private TextBox TextBoxName;
        private TextBox textBoxAge;
        private TextBox textBoxAddress;
        private TextBox textBoxGrade;
        private TextBox TextBoxId;
        private TextBox textBoxDeptid;
        private Label DeptId;
        private Label Grade;
        private Label Address;
        private Label Age;
        private Label ID;
        private Label Name;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}
