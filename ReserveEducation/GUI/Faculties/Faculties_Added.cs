using ReserveEducation.Infrastructure;
using System;
using ReserveEducation.Dtos;
using ReserveEducation.Dtos.FacultiesDto;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReserveEducation.Services;

namespace ReserveEducation.GUI
{
    public partial class FacultyAdded_Frm : Form
    {
        public FacultyAdded_Frm()
        {
            InitializeComponent();
        }
        private void Faculty_btnAdd_Click(object sender, EventArgs e)
        {
            Infrastructure.Faculty faculty = new Infrastructure.Faculty
            {
                Name = txtName_Faculty.Text,
            };
            bool result = FacultyService.Create(faculty);
            if(result == true)
            {
                MessageBox.Show("Thêm khoa thành công", "Thông báo");
                this.Close();
            }
        }
    }
}
