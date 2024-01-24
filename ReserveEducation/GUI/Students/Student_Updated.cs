using ReserveEducation.Infrastructure;
using ReserveEducation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEducation.GUI.StudentSubject
{
    public partial class Student_Updated : Form
    {
        string keywordSubject = null;
        int ?idSpecialization_FilterSubject = null;
        Student data;
        List<Subject> subjects;
        List<Specialization> specializations;
        int SelectedFilter = 0;
        public Student_Updated(Student _data)
        {
            InitializeComponent();
            data = _data;

            Student_txtStudentCode.Text = data.Code;
            Student_txtStudentName.Text = data.Name;

            var subjectsTotal = SubjectService.Query(new Dtos.SubjectDto.SearchSubjectDto()
            {
                PageSize = 10000000,
            });
            subjects = subjectsTotal.Data;

            loadSubjectChecked();
            loadSpecialization();
            loadClasses(data.StudentClass.Name);
            loadComboboxSelcet();
            StudentSubject_txtSelectedSubjectTotal.Text = cklbSubjects.CheckedItems.Count.ToString();
        }
        void loadSpecialization()
        {
            var specializationTotal = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                PageSize = 10000000,
            });
            specializations = specializationTotal.Data;
            StudentSubject_cmbSpecializationFilter.Items.Add("Tất cả");
            foreach (var item in specializations)
            {
                StudentSubject_cmbSpecializationFilter.Items.Add(item);
            }
        }
        void loadClasses(string className)
        {
            var studentClassesTotal = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                PageSize = 10000000,
            });
            StudentSubject_cmbSpecializationFilter.Items.Add("Tất cả");
            foreach (var item in studentClassesTotal.Data)
            {
                Student_cmbClasses.Items.Add(item);
            }
            Student_cmbClasses.SelectedIndex = studentClassesTotal.Data.FindIndex(x => x.ID == data.StudentClassID);
        }
        void loadSubjectChecked()
        {
            var studentSubject = StudentSubjectService.Query(new Dtos.StudentDto.SearchStudentSubjectDto()
            {
                PageSize = 10000000,
            });
            var studentSubjects = studentSubject.Data;
            cklbSubjects.Items.Clear();
            foreach (var item in subjects)
            {
                if (SelectedFilter == 0)
                {
                    int index = cklbSubjects.Items.Add(item.Name);
                    if (studentSubjects.Any(x => x.StudentID == data.ID && x.SubjectID == item.ID))
                    {
                        cklbSubjects.SetItemChecked(index, true);
                    }
                }
                else if (SelectedFilter == 1)
                {
                    if (studentSubjects.Any(x => x.StudentID == data.ID && x.SubjectID == item.ID))
                    {
                        int index = cklbSubjects.Items.Add(item.Name);
                        cklbSubjects.SetItemChecked(index, true);
                    }
                }
                else if (SelectedFilter == 2)
                {
                    if (!studentSubjects.Any(x => x.StudentID == data.ID && x.SubjectID == item.ID))
                    {
                        cklbSubjects.Items.Add(item.Name);
                    }
                }
            }
        }
        void loadComboboxSelcet()
        {
            StudentSubject_cmbSelectFilter.Items.Add("Tất cả");
            StudentSubject_cmbSelectFilter.SelectedIndex = 0;
            StudentSubject_cmbSelectFilter.Items.Add("Đã chọn");
            StudentSubject_cmbSelectFilter.Items.Add("Chưa chọn");
        }

        private void cklbSubjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedItem = cklbSubjects.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                bool result = StudentSubjectService.Create(selectedItem, Student_txtStudentCode.Text);
            }
            else
            {
                bool result = StudentSubjectService.Delete(selectedItem, Student_txtStudentCode.Text);
            }
            StudentSubject_txtSelectedSubjectTotal.Text = cklbSubjects.CheckedItems.Count.ToString();
        }

        private void StudentSubject_btnFilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StudentSubject_cmbSpecializationFilter.Text.Trim()))
            {
                var selectedSpecialization = specializations.FirstOrDefault(f => f.Name == StudentSubject_cmbSpecializationFilter.Text);
                if (selectedSpecialization != null)
                {
                    idSpecialization_FilterSubject = selectedSpecialization.ID;
                }
            }
            var data = SubjectService.Query(new Dtos.SubjectDto.SearchSubjectDto()
            {
                SpecializationID = idSpecialization_FilterSubject,
                Keyword = StudentSubject_txtKeywordFilter.Text.Trim(),
                PageSize = 10000000,
            }) ;
            subjects = data.Data;
            SelectedFilter = StudentSubject_cmbSelectFilter.SelectedIndex;
            loadSubjectChecked();
        }

        private void Student_btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Student_txtStudentCode.Text))
            {
                MessageBox.Show("Nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Student_txtStudentCode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Student_txtStudentName.Text))
            {
                MessageBox.Show("Nhập tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Student_txtStudentName.Focus();
                return;
            }
            if (Student_cmbClasses.Text == string.Empty)
            {
                MessageBox.Show("Chọn lớp học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result = StudentService.Update(data);
            if (result == true)
            {
                this.Close();
            }
        }

        private void Student_txtStudentName_TextChanged(object sender, EventArgs e)
        {
            data.Name = Student_txtStudentName.Text;
        }

        private void Student_txtStudentCode_TextChanged(object sender, EventArgs e)
        {
            data.Code = Student_txtStudentCode.Text;
        }

        private void Student_cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.StudentClassID = (Student_cmbClasses.SelectedItem as StudentClass).ID;

        }
    }
}
