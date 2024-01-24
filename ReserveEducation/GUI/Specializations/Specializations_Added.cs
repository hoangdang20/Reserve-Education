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
    public partial class SpecializationAdded_Frm : Form
    {
        List<Infrastructure.Faculty> faculties;
        public SpecializationAdded_Frm(List<Infrastructure.Faculty> faculties)
        {
            InitializeComponent();
            this.faculties = faculties;
        }
        private void SpecializationAdded_Frm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        void loadData()
        {
            foreach (var item in faculties)
            {
                cmb_Faculty.Items.Add(item);
            }
        }

        private void Specialization_btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName_Specialization.Text == string.Empty)
            {
                MessageBox.Show("Nhập tên chuyên ngành");
            }
            else if (cmb_Faculty.Text == string.Empty)
            {
                MessageBox.Show("Chọn khoa");
            }
            else
            {
                bool result = SpecializationService.Create(txtName_Specialization.Text, cmb_Faculty.Text);
                if(result == true){
                    MessageBox.Show("Thêm chuyên ngành thành công");
                }
                else
                {
                    MessageBox.Show("Thêm chuyên ngành không thành công");
                }
                this.Close();

            }
        }
    }
}
