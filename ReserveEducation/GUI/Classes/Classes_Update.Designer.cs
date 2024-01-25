namespace ReserveEducation.GUI.Classes
{
    partial class Classes_Update_Frm
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
            this.Classes_btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Classes_txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Classes_btnUpdate
            // 
            this.Classes_btnUpdate.Location = new System.Drawing.Point(123, 89);
            this.Classes_btnUpdate.Name = "Classes_btnUpdate";
            this.Classes_btnUpdate.Size = new System.Drawing.Size(124, 23);
            this.Classes_btnUpdate.TabIndex = 9;
            this.Classes_btnUpdate.Text = "Sửa";
            this.Classes_btnUpdate.UseVisualStyleBackColor = true;
            this.Classes_btnUpdate.Click += new System.EventHandler(this.Classes_btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chuyên ngành";
            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.DropDownHeight = 80;
            this.cmbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.IntegralHeight = false;
            this.cmbSpecialization.Location = new System.Drawing.Point(10, 62);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(363, 21);
            this.cmbSpecialization.TabIndex = 7;
            this.cmbSpecialization.SelectedIndexChanged += new System.EventHandler(this.cmbSpecialization_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên lớp";
            // 
            // Classes_txtName
            // 
            this.Classes_txtName.Location = new System.Drawing.Point(10, 24);
            this.Classes_txtName.Name = "Classes_txtName";
            this.Classes_txtName.Size = new System.Drawing.Size(363, 20);
            this.Classes_txtName.TabIndex = 5;
            this.Classes_txtName.TextChanged += new System.EventHandler(this.Classes_txtName_TextChanged);
            // 
            // Classes_Update_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 118);
            this.Controls.Add(this.Classes_btnUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Classes_txtName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Classes_Update_Frm";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa lớp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Classes_btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Classes_txtName;
    }
}