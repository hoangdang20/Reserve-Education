namespace ReserveEducation.GUI
{
    partial class FacultyAdded_Frm
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
            this.txtName_Faculty = new System.Windows.Forms.TextBox();
            this.Faculty_btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên khoa:";
            // 
            // txtName_Faculty
            // 
            this.txtName_Faculty.Location = new System.Drawing.Point(16, 25);
            this.txtName_Faculty.Name = "txtName_Faculty";
            this.txtName_Faculty.Size = new System.Drawing.Size(356, 20);
            this.txtName_Faculty.TabIndex = 0;
            // 
            // Faculty_btnAdd
            // 
            this.Faculty_btnAdd.Location = new System.Drawing.Point(128, 51);
            this.Faculty_btnAdd.Name = "Faculty_btnAdd";
            this.Faculty_btnAdd.Size = new System.Drawing.Size(124, 23);
            this.Faculty_btnAdd.TabIndex = 2;
            this.Faculty_btnAdd.Text = "Thêm";
            this.Faculty_btnAdd.UseVisualStyleBackColor = true;
            this.Faculty_btnAdd.Click += new System.EventHandler(this.Faculty_btnAdd_Click);
            // 
            // FacultyAdded_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 84);
            this.Controls.Add(this.Faculty_btnAdd);
            this.Controls.Add(this.txtName_Faculty);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacultyAdded_Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khoa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName_Faculty;
        private System.Windows.Forms.Button Faculty_btnAdd;
    }
}