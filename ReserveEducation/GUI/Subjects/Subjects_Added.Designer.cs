namespace ReserveEducation.GUI.Subjects
{
    partial class SubjectAdded_Frm
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
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.cmbSpecialization_Subject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Subject_btnAdd = new System.Windows.Forms.Button();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên môn học";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(16, 64);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(356, 20);
            this.txtSubjectName.TabIndex = 1;
            // 
            // cmbSpecialization_Subject
            // 
            this.cmbSpecialization_Subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization_Subject.FormattingEnabled = true;
            this.cmbSpecialization_Subject.Location = new System.Drawing.Point(15, 103);
            this.cmbSpecialization_Subject.Name = "cmbSpecialization_Subject";
            this.cmbSpecialization_Subject.Size = new System.Drawing.Size(356, 21);
            this.cmbSpecialization_Subject.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chuyên ngành";
            // 
            // Subject_btnAdd
            // 
            this.Subject_btnAdd.Location = new System.Drawing.Point(125, 130);
            this.Subject_btnAdd.Name = "Subject_btnAdd";
            this.Subject_btnAdd.Size = new System.Drawing.Size(124, 23);
            this.Subject_btnAdd.TabIndex = 3;
            this.Subject_btnAdd.Text = "Thêm";
            this.Subject_btnAdd.UseVisualStyleBackColor = true;
            this.Subject_btnAdd.Click += new System.EventHandler(this.Subject_btnAdd_Click);
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Location = new System.Drawing.Point(16, 25);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(356, 20);
            this.txtSubjectCode.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã học phần";
            // 
            // SubjectAdded_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 160);
            this.Controls.Add(this.txtSubjectCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Subject_btnAdd);
            this.Controls.Add(this.cmbSpecialization_Subject);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SubjectAdded_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm môn học";
            this.Load += new System.EventHandler(this.SubjectAdded_Frm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.ComboBox cmbSpecialization_Subject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Subject_btnAdd;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.Label label3;
    }
}