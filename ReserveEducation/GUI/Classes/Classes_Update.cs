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

namespace ReserveEducation.GUI.Classes
{
    public partial class Classes_Update_Frm : Form
    {
        private StudentClass data;
        public Classes_Update_Frm(StudentClass _data = null)
        {
            InitializeComponent();
            if (_data != null)
            {
                data = _data;
                Classes_btnUpdate.Text = "Sửa";
            }
            else
            {
                data = new StudentClass();
                Classes_btnUpdate.Text = "Thêm";
            }
            Classes_txtName.Text = data.Name;

            var pagedSpecialize = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                PageSize = 10000000,
            });
            foreach (var item in pagedSpecialize.Data)
            {
                cmbSpecialization.Items.Add(item);
            }
            cmbSpecialization.SelectedIndex = pagedSpecialize.Data.FindIndex(x => x.ID == data.SpecializationID);
        }
        private void Classes_btnUpdate_Click(object sender, EventArgs e)
        {
            if (data.Name == string.Empty)
            {
                MessageBox.Show("Nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (cmbSpecialization.Text == string.Empty)
            {
                MessageBox.Show("Chọn chuyên ngành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            bool result = data.ID > 0 ? ClassService.Update(data) : ClassService.Create(data);
            if (result)
            {
                this.Close();
            }
        }

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.SpecializationID = (cmbSpecialization.SelectedItem as Specialization).ID;
        }

        private void Classes_txtName_TextChanged(object sender, EventArgs e)
        {
            data.Name = Classes_txtName.Text;
        }
    }
}
