namespace ReserveEducation.GUI.Subjects
{
    partial class SubjectStudent
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
            this.StudentSubject_btnFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StudentSubject_cmbSpecializationFilter = new System.Windows.Forms.ComboBox();
            this.StudentSubject_txtKeywordFilter = new System.Windows.Forms.TextBox();
            this.StudentSubject_cmbClassesFilter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Subject_txtSpecialization = new System.Windows.Forms.TextBox();
            this.Subject_txtSubjectCode = new System.Windows.Forms.TextBox();
            this.Subject_txtSubjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lsvStudentIsNotPassed = new System.Windows.Forms.ListView();
            this.StudentCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StudentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StudentClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // StudentSubject_btnFilter
            // 
            this.StudentSubject_btnFilter.Location = new System.Drawing.Point(6, 148);
            this.StudentSubject_btnFilter.Name = "StudentSubject_btnFilter";
            this.StudentSubject_btnFilter.Size = new System.Drawing.Size(174, 35);
            this.StudentSubject_btnFilter.TabIndex = 12;
            this.StudentSubject_btnFilter.Text = "Lọc";
            this.StudentSubject_btnFilter.UseVisualStyleBackColor = true;
            this.StudentSubject_btnFilter.Click += new System.EventHandler(this.StudentSubject_btnFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Từ khoá";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.StudentSubject_cmbSpecializationFilter);
            this.groupBox2.Controls.Add(this.StudentSubject_btnFilter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.StudentSubject_txtKeywordFilter);
            this.groupBox2.Controls.Add(this.StudentSubject_cmbClassesFilter);
            this.groupBox2.Location = new System.Drawing.Point(331, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 195);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ngành";
            // 
            // StudentSubject_cmbSpecializationFilter
            // 
            this.StudentSubject_cmbSpecializationFilter.DropDownHeight = 80;
            this.StudentSubject_cmbSpecializationFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentSubject_cmbSpecializationFilter.FormattingEnabled = true;
            this.StudentSubject_cmbSpecializationFilter.IntegralHeight = false;
            this.StudentSubject_cmbSpecializationFilter.Location = new System.Drawing.Point(6, 73);
            this.StudentSubject_cmbSpecializationFilter.Name = "StudentSubject_cmbSpecializationFilter";
            this.StudentSubject_cmbSpecializationFilter.Size = new System.Drawing.Size(174, 21);
            this.StudentSubject_cmbSpecializationFilter.TabIndex = 13;
            this.StudentSubject_cmbSpecializationFilter.SelectedIndexChanged += new System.EventHandler(this.StudentSubject_cmbSpecializationFilter_SelectedIndexChanged);
            // 
            // StudentSubject_txtKeywordFilter
            // 
            this.StudentSubject_txtKeywordFilter.Location = new System.Drawing.Point(6, 33);
            this.StudentSubject_txtKeywordFilter.Name = "StudentSubject_txtKeywordFilter";
            this.StudentSubject_txtKeywordFilter.Size = new System.Drawing.Size(174, 20);
            this.StudentSubject_txtKeywordFilter.TabIndex = 9;
            // 
            // StudentSubject_cmbClassesFilter
            // 
            this.StudentSubject_cmbClassesFilter.DropDownHeight = 80;
            this.StudentSubject_cmbClassesFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentSubject_cmbClassesFilter.FormattingEnabled = true;
            this.StudentSubject_cmbClassesFilter.IntegralHeight = false;
            this.StudentSubject_cmbClassesFilter.Location = new System.Drawing.Point(6, 113);
            this.StudentSubject_cmbClassesFilter.Name = "StudentSubject_cmbClassesFilter";
            this.StudentSubject_cmbClassesFilter.Size = new System.Drawing.Size(174, 21);
            this.StudentSubject_cmbClassesFilter.TabIndex = 8;
            this.StudentSubject_cmbClassesFilter.SelectedIndexChanged += new System.EventHandler(this.StudentSubject_cmbClassesFilter_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Subject_txtSpecialization);
            this.groupBox1.Controls.Add(this.Subject_txtSubjectCode);
            this.groupBox1.Controls.Add(this.Subject_txtSubjectName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 152);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin môn học";
            // 
            // Subject_txtSpecialization
            // 
            this.Subject_txtSpecialization.Location = new System.Drawing.Point(6, 115);
            this.Subject_txtSpecialization.Name = "Subject_txtSpecialization";
            this.Subject_txtSpecialization.ReadOnly = true;
            this.Subject_txtSpecialization.Size = new System.Drawing.Size(156, 20);
            this.Subject_txtSpecialization.TabIndex = 8;
            // 
            // Subject_txtSubjectCode
            // 
            this.Subject_txtSubjectCode.Location = new System.Drawing.Point(6, 75);
            this.Subject_txtSubjectCode.Name = "Subject_txtSubjectCode";
            this.Subject_txtSubjectCode.ReadOnly = true;
            this.Subject_txtSubjectCode.Size = new System.Drawing.Size(156, 20);
            this.Subject_txtSubjectCode.TabIndex = 2;
            // 
            // Subject_txtSubjectName
            // 
            this.Subject_txtSubjectName.Location = new System.Drawing.Point(6, 31);
            this.Subject_txtSubjectName.Name = "Subject_txtSubjectName";
            this.Subject_txtSubjectName.ReadOnly = true;
            this.Subject_txtSubjectName.Size = new System.Drawing.Size(156, 20);
            this.Subject_txtSubjectName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã môn học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chuyên ngành";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên môn học";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lsvStudentIsNotPassed);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(181, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 411);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sinh viên chưa qua môn";
            // 
            // lsvStudentIsNotPassed
            // 
            this.lsvStudentIsNotPassed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StudentCode,
            this.StudentName,
            this.StudentClass});
            this.lsvStudentIsNotPassed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvStudentIsNotPassed.HideSelection = false;
            this.lsvStudentIsNotPassed.Location = new System.Drawing.Point(6, 23);
            this.lsvStudentIsNotPassed.Name = "lsvStudentIsNotPassed";
            this.lsvStudentIsNotPassed.Size = new System.Drawing.Size(319, 367);
            this.lsvStudentIsNotPassed.TabIndex = 12;
            this.lsvStudentIsNotPassed.UseCompatibleStateImageBehavior = false;
            this.lsvStudentIsNotPassed.View = System.Windows.Forms.View.Details;
            // 
            // StudentCode
            // 
            this.StudentCode.Text = "Mã sinh viên";
            this.StudentCode.Width = 80;
            // 
            // StudentName
            // 
            this.StudentName.Text = "Họ tên";
            this.StudentName.Width = 120;
            // 
            // StudentClass
            // 
            this.StudentClass.Text = "Lớp";
            this.StudentClass.Width = 100;
            // 
            // SubjectStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "SubjectStudent";
            this.Text = "SubjectStudent";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StudentSubject_btnFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox StudentSubject_txtKeywordFilter;
        private System.Windows.Forms.ComboBox StudentSubject_cmbClassesFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Subject_txtSubjectCode;
        private System.Windows.Forms.TextBox Subject_txtSubjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Subject_txtSpecialization;
        private System.Windows.Forms.ListView lsvStudentIsNotPassed;
        private System.Windows.Forms.ColumnHeader StudentCode;
        private System.Windows.Forms.ColumnHeader StudentName;
        private System.Windows.Forms.ColumnHeader StudentClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox StudentSubject_cmbSpecializationFilter;
    }
}