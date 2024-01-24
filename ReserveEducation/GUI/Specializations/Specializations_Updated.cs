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

namespace ReserveEducation.GUI.Specializations
{
    public partial class Specializations_Updated_Frm : Form
    {
        Specialization data;
        public Specializations_Updated_Frm(Specialization _data = null)
        {
            InitializeComponent();
            if (_data != null)
            {
                data = _data;
                Specialization_btnUpdate.Text = "Sửa";
            }
            else
            {
                data = new Specialization();
                Specialization_btnUpdate.Text = "Thêm";
            }
            Specialization_txtName.Text = data.Name;
            var facultyTotal = FacultyService.Query(new Dtos.FacultiesDto.SearchFacultiesDto()
            {
                PageSize = 10000000,
            });
            foreach (var item in facultyTotal.Data)
            {
                cmb_Faculty.Items.Add(item);
            }
            cmb_Faculty.SelectedIndex = facultyTotal.Data.FindIndex(x => x.ID == data.FacultyID);
        }

        private void Specialization_btnUpdate_Click(object sender, EventArgs e)
        {
            if (Specialization_txtName.Text == string.Empty)
            {
                MessageBox.Show("Nhập tên chuyên ngành");
                return;
            }
            if (cmb_Faculty.Text == string.Empty)
            {
                MessageBox.Show("Chọn khoa");
                return;
            }
            bool result = data.ID > 0 ? SpecializationService.Update(data) : SpecializationService.Create(data);
            if (result)
            {
                this.Close();
            }
        }

        private void cmb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.FacultyID = (cmb_Faculty.SelectedItem as Faculty).ID;
        }

        private void Specialization_txtName_TextChanged(object sender, EventArgs e)
        {
            data.Name = Specialization_txtName.Text;
        }
    }
}
