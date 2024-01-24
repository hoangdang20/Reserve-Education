namespace ReserveEducation.GUI.Specializations
{
    partial class SpecializationAdded_Frm
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
            this.txtName_Specialization = new System.Windows.Forms.TextBox();
            this.cmb_Faculty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Specialization_btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên chuyên ngành:";
            // 
            // txtName_Specialization
            // 
            this.txtName_Specialization.Location = new System.Drawing.Point(16, 25);
            this.txtName_Specialization.Name = "txtName_Specialization";
            this.txtName_Specialization.Size = new System.Drawing.Size(356, 20);
            this.txtName_Specialization.TabIndex = 1;
            // 
            // cmb_Faculty
            // 
            this.cmb_Faculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Faculty.FormattingEnabled = true;
            this.cmb_Faculty.Location = new System.Drawing.Point(16, 64);
            this.cmb_Faculty.Name = "cmb_Faculty";
            this.cmb_Faculty.Size = new System.Drawing.Size(356, 21);
            this.cmb_Faculty.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Khoa:";
            // 
            // Specialization_btnAdd
            // 
            this.Specialization_btnAdd.Location = new System.Drawing.Point(131, 91);
            this.Specialization_btnAdd.Name = "Specialization_btnAdd";
            this.Specialization_btnAdd.Size = new System.Drawing.Size(124, 23);
            this.Specialization_btnAdd.TabIndex = 3;
            this.Specialization_btnAdd.Text = "Thêm";
            this.Specialization_btnAdd.UseVisualStyleBackColor = true;
            this.Specialization_btnAdd.Click += new System.EventHandler(this.Specialization_btnAdd_Click);
            // 
            // SpecializationAdded_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 119);
            this.Controls.Add(this.Specialization_btnAdd);
            this.Controls.Add(this.cmb_Faculty);
            this.Controls.Add(this.txtName_Specialization);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SpecializationAdded_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm chuyên ngành";
            this.Load += new System.EventHandler(this.SpecializationAdded_Frm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName_Specialization;
        private System.Windows.Forms.ComboBox cmb_Faculty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Specialization_btnAdd;
    }
}