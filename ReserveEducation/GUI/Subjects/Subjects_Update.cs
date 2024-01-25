using ReserveEducation.Infrastructure;
using ReserveEducation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEducation.GUI.Subjects
{
    public partial class SubjectsUpdated_Frm : Form
    {
        private Subject data;

        public SubjectsUpdated_Frm(Subject _data = null)
        {
            InitializeComponent();
            if (_data != null )
            {
                data = _data;
                Subject_btnUpdate.Text = "Sửa";

            }
            else
            {
                data = new Subject();
                Subject_btnUpdate.Text = "Thêm";
            }
            txtSubjectCode.Text = data.Code;
            txtSubjectName.Text = data.Name;

            var pagedSpecialize = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                PageSize = 10000000,
            });
            foreach (var item in pagedSpecialize.Data)
            {
                cmbSpecialization_Subject.Items.Add(item);
            }
            cmbSpecialization_Subject.SelectedIndex = pagedSpecialize.Data.FindIndex(x => x.ID == data.SpecializationID);
        }
        

        private void Subject_btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectName.Text))
            {
                MessageBox.Show("Nhập tên môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                MessageBox.Show("Nhập mã học phần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectCode.Focus();
                return;
            }
            if (cmbSpecialization_Subject.Text == string.Empty)
            {
                MessageBox.Show("Chọn chuyên ngành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = data.ID > 0 ? SubjectService.Update(data) : SubjectService.Create(data);
            if (result == true)
            {
                this.Close();
            }
        }

        private void txtSubjectCode_TextChanged(object sender, EventArgs e)
        {
            data.Code = txtSubjectCode.Text;
        }

        private void txtSubjectName_TextChanged(object sender, EventArgs e)
        {
            data.Name = txtSubjectName.Text;
        }

        private void cmbSpecialization_Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.SpecializationID = (cmbSpecialization_Subject.SelectedItem as Specialization).ID;
        }
    }
}
