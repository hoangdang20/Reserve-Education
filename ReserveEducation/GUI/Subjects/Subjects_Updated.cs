using ReserveEducation.Infrastructure;
using ReserveEducation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEducation.GUI.Subjects
{
    public partial class SubjectsUpdated_Frm : Form
    {
        int id = -1;
        List<Infrastructure.Specialization> specializations;
        public SubjectsUpdated_Frm(int subjectID, string subjectCode, string subjectName, string specializationName, List<Infrastructure.Specialization> specializations)
        {
            InitializeComponent();
            id = subjectID;
            txtSubjectName.Text = subjectName;
            txtSubjectCode.Text = subjectCode;
            cmbSpecialization_Subject.SelectedText = specializationName;
            this.specializations = specializations;
            loadData(specializationName);

        }

        void loadData(string specializationName)
        {
            foreach (var item in specializations)
            {
                cmbSpecialization_Subject.Items.Add(item);
                if(item.Name == specializationName)
                {
                    cmbSpecialization_Subject.SelectedItem = item;
                }
            }
        }

        private void Subject_btnSua_Click(object sender, EventArgs e)
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

            bool result = SubjectService.Update(id, txtSubjectCode.Text, txtSubjectName.Text, cmbSpecialization_Subject.Text);
            if (result == true)
            {
                this.Close();
            }
        }

    }
}
