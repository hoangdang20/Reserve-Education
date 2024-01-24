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
        int id = -1;
        List<Infrastructure.Faculty> faculties;
        public Specializations_Updated_Frm(int specializationId, string name, string facultyName, List<Infrastructure.Faculty> faculties)
        {
            InitializeComponent();
            id = specializationId;
            txtName_Specialization.Text = name;
            cmb_Faculty.SelectedItem = facultyName;
            this.faculties = faculties;
            loadData(facultyName);

        }

        void loadData(string facultyName)
        {
            foreach (var item in faculties)
            {
                cmb_Faculty.Items.Add(item);
                if (item.Name == facultyName)
                {
                    cmb_Faculty.SelectedItem = item;
                }
            }
        }

        private void Specialization_btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName_Specialization.Text == string.Empty)
            {
                MessageBox.Show("Nhập tên chuyên ngành");
                return;
            }
            if (cmb_Faculty.Text == string.Empty)
            {
                MessageBox.Show("Chọn khoa");
                return;
            }
            bool result = SpecializationService.Update(id, txtName_Specialization.Text, cmb_Faculty.Text);
            if (result == true)
            {
                this.Close();
            }
        }
    }
}
