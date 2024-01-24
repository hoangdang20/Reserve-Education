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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ReserveEducation.GUI.Subjects
{
    public partial class SubjectStudent : Form
    {
        List<StudentClass> classesTotal;
        List<StudentClass> classes;

        List<Specialization> specializationsTotal;

        int? specializationID = null;
        Subject subject;
        Specialization specialization = null;
        StudentClass studentClass = null;

        public SubjectStudent(Subject _subject)
        {
            InitializeComponent();
            subject = _subject;
            specializationID = subject.SpecializationID;
            var students = StudentSubjectService.GetStudents(subject);

            Subject_txtSubjectName.Text = subject.Name;
            Subject_txtSubjectCode.Text = subject.Code;
            Subject_txtSpecialization.Text = subject.Specialization.Name;

            foreach (var item in students)
            {
                ListViewItem listViewItem = new ListViewItem(item.Code);
                listViewItem.SubItems.Add(item.Name);
                listViewItem.SubItems.Add(item.StudentClass.Name);
                lsvStudentIsNotPassed.Items.Add(listViewItem);
            }


            var specializations = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                PageSize = 100000000,
            });
            specializationsTotal = specializations.Data;
            StudentSubject_cmbSpecializationFilter.Items.Clear();
            StudentSubject_cmbSpecializationFilter.Items.Add("Chọn tất cả");
            StudentSubject_cmbSpecializationFilter.SelectedIndex = 0;
            foreach (var item in specializationsTotal)
            {
                StudentSubject_cmbSpecializationFilter.Items.Add(item);
            }

            var classes = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                SpecializationID = subject.SpecializationID,
                PageSize = 100000000,
            });
            classesTotal = classes.Data;
            StudentSubject_cmbClassesFilter.Items.Clear();
            StudentSubject_cmbClassesFilter.Items.Add("Chọn tất cả");
            StudentSubject_cmbClassesFilter.SelectedIndex = 0;
            foreach (var item in classesTotal)
            {
                StudentSubject_cmbClassesFilter.Items.Add(item);
            }
        }

        private void StudentSubject_btnFilter_Click(object sender, EventArgs e)
        {
            var students = StudentSubjectService.GetStudents(subject, specialization, studentClass);
            lsvStudentIsNotPassed.Items.Clear();
            foreach (var item in students)
            {
                ListViewItem listViewItem = new ListViewItem(item.Code);
                listViewItem.SubItems.Add(item.Name);
                listViewItem.SubItems.Add(item.StudentClass.Name);
                lsvStudentIsNotPassed.Items.Add(listViewItem);
            }
        }

        private void StudentSubject_cmbSpecializationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            int? idSpecialization = null;
            int? idClass = null;

            var selectedSpecialization = specializationsTotal.FirstOrDefault(f => f.Name == StudentSubject_cmbSpecializationFilter.Text);
            if (selectedSpecialization != null)
            {
                idSpecialization = selectedSpecialization.ID;
            }
            specialization = selectedSpecialization;

            var _classes = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                SpecializationID = idSpecialization,
                PageSize = 100000000,
            });
            if (_classes != null)
            {
                classesTotal = _classes.Data;
                StudentSubject_cmbClassesFilter.Items.Clear();
                StudentSubject_cmbClassesFilter.Items.Add("Chọn tất cả");
                StudentSubject_cmbClassesFilter.SelectedIndex = 0;
                foreach (var item in classesTotal)
                {
                    StudentSubject_cmbClassesFilter.Items.Add(item);
                }
                classes = _classes.Data;

            }

        }

        private void StudentSubject_cmbClassesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(classes!= null)
            {
                var selectedClasses = classes.FirstOrDefault(f => f.Name == StudentSubject_cmbClassesFilter.Text);
                studentClass = selectedClasses;
            }
            
        }
    }
}
