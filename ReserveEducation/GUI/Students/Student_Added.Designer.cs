namespace ReserveEducation.GUI.Students
{
    partial class StudentAdded_Frm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.cmbClasses_Student = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Student_btnAdd = new System.Windows.Forms.Button();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã sinh viên";
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.Location = new System.Drawing.Point(16, 64);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Size = new System.Drawing.Size(356, 20);
            this.txtStudentCode.TabIndex = 1;
            this.txtStudentCode.TextChanged += new System.EventHandler(this.txtStudentCode_TextChanged);
            // 
            // cmbClasses_Student
            // 
            this.cmbClasses_Student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasses_Student.FormattingEnabled = true;
            this.cmbClasses_Student.Location = new System.Drawing.Point(15, 103);
            this.cmbClasses_Student.Name = "cmbClasses_Student";
            this.cmbClasses_Student.Size = new System.Drawing.Size(356, 21);
            this.cmbClasses_Student.TabIndex = 2;
            this.cmbClasses_Student.SelectedIndexChanged += new System.EventHandler(this.cmbClasses_Student_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lớp học";
            // 
            // Student_btnAdd
            // 
            this.Student_btnAdd.Location = new System.Drawing.Point(125, 130);
            this.Student_btnAdd.Name = "Student_btnAdd";
            this.Student_btnAdd.Size = new System.Drawing.Size(124, 23);
            this.Student_btnAdd.TabIndex = 3;
            this.Student_btnAdd.Text = "Thêm";
            this.Student_btnAdd.UseVisualStyleBackColor = true;
            this.Student_btnAdd.Click += new System.EventHandler(this.Student_btnAdd_Click);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(16, 25);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(356, 20);
            this.txtStudentName.TabIndex = 0;
            this.txtStudentName.TextChanged += new System.EventHandler(this.txtStudentName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên sinh viên";
            // 
            // StudentAdded_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 160);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Student_btnAdd);
            this.Controls.Add(this.cmbClasses_Student);
            this.Controls.Add(this.txtStudentCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StudentAdded_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm môn học";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.ComboBox cmbClasses_Student;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Student_btnAdd;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label3;
    }
}