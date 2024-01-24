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
        Student data;
        public StudentAdded_Frm()
        {
            InitializeComponent();

            var studentClasses = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                PageSize = 10000000,
            });
            foreach (var item in studentClasses.Data)
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

            bool result = StudentService.Create(data);
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

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            data.Name = txtStudentName.Text;
        }

        private void txtStudentCode_TextChanged(object sender, EventArgs e)
        {
            data.Code = txtStudentCode.Text;
        }

        private void cmbClasses_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.StudentClassID = (cmbClasses_Student.SelectedItem as StudentClass).ID;
        }
    }
}
