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
        List<Subject> subjects;
        List<Subject> subjectsToTal;
        string keywordSubject = null;
        int idSpecialization_FilterSubject = -1;
        int subjectsTotalPage = 0;
        int subjectsPage = 1;


        List<Infrastructure.Specialization> specializations;
        List<MappingStudentSubject> studentSubjects;
        int studentID = -1;
        List<StudentClass> classStudents;

        int SelectedFilter = 0;
        public Student_Updated(Student student, List<Subject> subjects, List<Infrastructure.Specialization> specializations, List<MappingStudentSubject> studentSubjects, List<StudentClass> classStudents)
        {
            InitializeComponent();
            Student_txtStudentCode.Text = student.Code;
            Student_txtStudentName.Text = student.Name;
            studentID = student.ID;

            this.subjects = subjects;
            this.subjectsToTal = subjects;
            this.specializations = specializations;
            this.studentSubjects = studentSubjects;
            this.classStudents = classStudents;
            loadSubject();
            loadComboboxSpecialization();
            loadClasses(student.StudentClass.Name);
            loadComboboxSelcet();
            StudentSubject_txtSelectedSubjectTotal.Text = cklbSubjects.CheckedItems.Count.ToString();
        }

        void loadClasses(string className)
        {
            foreach (var item in classStudents)
            {
                Student_cmbClasses.Items.Add(item);
                if (item.Name == className)
                {
                    Student_cmbClasses.SelectedItem = item;
                }
            }
        }
        void loadSubject()
        {
            cklbSubjects.Items.Clear();
            foreach (var item in subjects)
            {
                if (SelectedFilter == 0)
                {
                    int index = cklbSubjects.Items.Add(item.Name);
                    if (studentSubjects.Any(x => x.StudentID == studentID && x.SubjectID == item.ID))
                    {
                        cklbSubjects.SetItemChecked(index, true);
                    }
                }
                else if (SelectedFilter == 1)
                {
                    if (studentSubjects.Any(x => x.StudentID == studentID && x.SubjectID == item.ID))
                    {
                        int index = cklbSubjects.Items.Add(item.Name);
                        cklbSubjects.SetItemChecked(index, true);
                    }
                }
                else if (SelectedFilter == 2)
                {
                    if (!studentSubjects.Any(x => x.StudentID == studentID && x.SubjectID == item.ID))
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
        void loadComboboxSpecialization()
        {
            StudentSubject_cmbSpecializationFilter.Items.Add("");
            foreach (var item in specializations)
            {
                StudentSubject_cmbSpecializationFilter.Items.Add(item);
            }
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
            keywordSubject = StudentSubject_txtKeywordFilter.Text.Trim();
            subjectsPage = 1;
            idSpecialization_FilterSubject = -1;
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
                Keyword = keywordSubject,
                NumberPage = subjectsPage,
                SpecializationID = idSpecialization_FilterSubject,
                PageSize = 10000000,
            });
            subjects = data.Data;
            SelectedFilter = StudentSubject_cmbSelectFilter.SelectedIndex;
            loadSubject();
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
            bool result = StudentService.Update(studentID, Student_txtStudentName.Text, Student_txtStudentCode.Text, Student_cmbClasses.Text);
            if (result == true)
            {
                this.Close();
            }
        }
    }
}
