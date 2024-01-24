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

namespace ReserveEducation.GUI.Subjects
{
    public partial class SubjectAdded_Frm : Form
    {
        List<Specialization> specializations;
        public SubjectAdded_Frm(List<Specialization> specializations)
        {
            InitializeComponent();
            this.specializations = specializations;
        }

        private void SubjectAdded_Frm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        void loadData()
        {
            foreach (var item in specializations)
            {
                cmbSpecialization_Subject.Items.Add(item);
            }
        }

        private void Subject_btnAdd_Click(object sender, EventArgs e)
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

            bool result = SubjectService.Create(txtSubjectName.Text,txtSubjectCode.Text, cmbSpecialization_Subject.Text);
            if (result == true)
            {
                MessageBox.Show("Thêm môn học thành công");
                this.Close();
            }
        }
    }
}
