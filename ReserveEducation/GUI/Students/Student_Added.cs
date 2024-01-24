using ReserveEducation.Infrastructure;
using ReserveEducation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReserveEducation.Services;

namespace ReserveEducation.GUI.Students
{
    public partial class StudentAdded_Frm : Form
    {
        List<StudentClass> studentClasses;
        public StudentAdded_Frm(List<StudentClass> studentClasses)
        {
            InitializeComponent();
            this.studentClasses = studentClasses;
        }

        private void StudentAdded_Frm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        void loadData()
        {
            foreach (var item in studentClasses)
            {
                cmbClasses_Student.Items.Add(item);
            }
        }

        private void Student_btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentCode.Text))
            {
                MessageBox.Show("Nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentCode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtStudentName.Text))
            {
                MessageBox.Show("Nhập tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentName.Focus();
                return;
            }
            if (cmbClasses_Student.Text == string.Empty)
            {
                MessageBox.Show("Chọn lớp học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = StudentService.Create(txtStudentName.Text, txtStudentCode.Text, cmbClasses_Student.Text);
            if (result == true)
            {
                MessageBox.Show("Thêm sinh viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm sinh viên không thành công");
            }
            this.Close();
        }
    }
}
