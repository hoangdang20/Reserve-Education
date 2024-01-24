namespace ReserveEducation.GUI.Subjects
{
    partial class SubjectsUpdated_Frm
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
            this.Subject_btnSua = new System.Windows.Forms.Button();
            this.cmbSpecialization_Subject = new System.Windows.Forms.ComboBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Subject_btnSua
            // 
            this.Subject_btnSua.Location = new System.Drawing.Point(122, 124);
            this.Subject_btnSua.Name = "Subject_btnSua";
            this.Subject_btnSua.Size = new System.Drawing.Size(124, 23);
            this.Subject_btnSua.TabIndex = 3;
            this.Subject_btnSua.Text = "Sửa";
            this.Subject_btnSua.UseVisualStyleBackColor = true;
            this.Subject_btnSua.Click += new System.EventHandler(this.Subject_btnSua_Click);
            // 
            // cmbSpecialization_Subject
            // 
            this.cmbSpecialization_Subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization_Subject.FormattingEnabled = true;
            this.cmbSpecialization_Subject.Location = new System.Drawing.Point(15, 97);
            this.cmbSpecialization_Subject.Name = "cmbSpecialization_Subject";
            this.cmbSpecialization_Subject.Size = new System.Drawing.Size(357, 21);
            this.cmbSpecialization_Subject.TabIndex = 2;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(15, 58);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(357, 20);
            this.txtSubjectName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chuyên ngành:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên môn học:";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Location = new System.Drawing.Point(15, 19);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(357, 20);
            this.txtSubjectCode.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã học phần";
            // 
            // SubjectsUpdated_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 159);
            this.Controls.Add(this.txtSubjectCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Subject_btnSua);
            this.Controls.Add(this.cmbSpecialization_Subject);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SubjectsUpdated_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa khoa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Subject_btnSua;
        private System.Windows.Forms.ComboBox cmbSpecialization_Subject;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.Label label3;
    }
}