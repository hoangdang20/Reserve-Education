namespace ReserveEducation.GUI.Faculties
{
    partial class Faculty_Updated_Frm
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
            this.txtName_Faculty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Faculty_btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName_Faculty
            // 
            this.txtName_Faculty.Location = new System.Drawing.Point(12, 25);
            this.txtName_Faculty.Name = "txtName_Faculty";
            this.txtName_Faculty.Size = new System.Drawing.Size(360, 20);
            this.txtName_Faculty.TabIndex = 0;
            this.txtName_Faculty.TextChanged += new System.EventHandler(this.txtName_Faculty_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhập tên:";
            // 
            // Faculty_btnUpdate
            // 
            this.Faculty_btnUpdate.Location = new System.Drawing.Point(127, 51);
            this.Faculty_btnUpdate.Name = "Faculty_btnUpdate";
            this.Faculty_btnUpdate.Size = new System.Drawing.Size(124, 23);
            this.Faculty_btnUpdate.TabIndex = 2;
            this.Faculty_btnUpdate.Text = "Sửa";
            this.Faculty_btnUpdate.UseVisualStyleBackColor = true;
            this.Faculty_btnUpdate.Click += new System.EventHandler(this.Faculty_btnUpdate_Click);
            // 
            // Faculty_Updated_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 85);
            this.Controls.Add(this.Faculty_btnUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName_Faculty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Faculty_Updated_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin khoa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName_Faculty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Faculty_btnUpdate;
    }
}