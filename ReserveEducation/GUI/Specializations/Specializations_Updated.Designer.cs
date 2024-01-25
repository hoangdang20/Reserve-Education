namespace ReserveEducation.GUI.Specializations
{
    partial class Specializations_Updated_Frm
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
            this.Specialization_btnUpdate = new System.Windows.Forms.Button();
            this.cmb_Faculty = new System.Windows.Forms.ComboBox();
            this.Specialization_txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Specialization_btnUpdate
            // 
            this.Specialization_btnUpdate.Location = new System.Drawing.Point(137, 91);
            this.Specialization_btnUpdate.Name = "Specialization_btnUpdate";
            this.Specialization_btnUpdate.Size = new System.Drawing.Size(124, 23);
            this.Specialization_btnUpdate.TabIndex = 8;
            this.Specialization_btnUpdate.Text = "Sửa";
            this.Specialization_btnUpdate.UseVisualStyleBackColor = true;
            this.Specialization_btnUpdate.Click += new System.EventHandler(this.Specialization_btnUpdate_Click);
            // 
            // cmb_Faculty
            // 
            this.cmb_Faculty.DropDownHeight = 80;
            this.cmb_Faculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Faculty.FormattingEnabled = true;
            this.cmb_Faculty.IntegralHeight = false;
            this.cmb_Faculty.Location = new System.Drawing.Point(15, 64);
            this.cmb_Faculty.Name = "cmb_Faculty";
            this.cmb_Faculty.Size = new System.Drawing.Size(357, 21);
            this.cmb_Faculty.TabIndex = 7;
            this.cmb_Faculty.SelectedIndexChanged += new System.EventHandler(this.cmb_Faculty_SelectedIndexChanged);
            // 
            // Specialization_txtName
            // 
            this.Specialization_txtName.Location = new System.Drawing.Point(15, 25);
            this.Specialization_txtName.Name = "Specialization_txtName";
            this.Specialization_txtName.Size = new System.Drawing.Size(357, 20);
            this.Specialization_txtName.TabIndex = 6;
            this.Specialization_txtName.TextChanged += new System.EventHandler(this.Specialization_txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Khoa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên chuyên ngành:";
            // 
            // Specializations_Updated_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 120);
            this.Controls.Add(this.Specialization_btnUpdate);
            this.Controls.Add(this.cmb_Faculty);
            this.Controls.Add(this.Specialization_txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Specializations_Updated_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin chuyên ngành";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Specialization_btnUpdate;
        private System.Windows.Forms.ComboBox cmb_Faculty;
        private System.Windows.Forms.TextBox Specialization_txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}