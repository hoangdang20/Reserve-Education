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

namespace ReserveEducation.GUI.Faculties
{
    public partial class Faculty_Updated_Frm : Form
    {
        private Faculty data;

        public Faculty_Updated_Frm(Faculty _data = null)
        {
            InitializeComponent();
            if (_data != null)
            {
                data = _data;
                Faculty_btnUpdate.Text = "Sửa";

            }
            else
            {
                data = new Faculty();
                Faculty_btnUpdate.Text = "Thêm";
            }
            txtName_Faculty.Text = data.Name;
        }

        private void Faculty_btnUpdate_Click(object sender, EventArgs e)
        {
            if(data.Name == string.Empty)
            {
                MessageBox.Show("Nhập tên khoa");
                return;
            }

            bool result = data.ID > 0 ? FacultyService.Update(data) : FacultyService.Create(data);
            if (result)
            {
                this.Close();
            }
        }

        private void txtName_Faculty_TextChanged(object sender, EventArgs e)
        {
            data.Name = txtName_Faculty.Text;
        }
    }
}
