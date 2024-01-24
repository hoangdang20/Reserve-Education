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

namespace ReserveEducation.GUI.Faculty
{
    public partial class Faculty_Updated_Frm : Form
    {
        int id = -1;
        public Faculty_Updated_Frm(int facultyId, string name)
        {
            InitializeComponent();
            id = facultyId;
            txtName_Faculty.Text = name;
        }

        private void Faculty_btnUpdate_Click(object sender, EventArgs e)
        {

            bool result = FacultyService.Update(id,txtName_Faculty.Text);
            if (result == true)
            {
                // MessageBox.Show("Sửa khoa thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
