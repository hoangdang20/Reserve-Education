using ReserveEducation.Dtos;
using ReserveEducation.GUI;
using ReserveEducation.GUI.Classes;
using ReserveEducation.GUI.Faculties;
using ReserveEducation.GUI.Subjects;
using ReserveEducation.GUI.Specializations;
using ReserveEducation.GUI.Students;
using ReserveEducation.GUI.StudentSubject;
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

namespace ReserveEducation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            loadData();
        }
        List<Faculty> faculties = new List<Faculty>();
        List<Faculty> facultiesTotal = new List<Faculty>();
        string keywordFaculty = null;
        int facultiesTotalPage = 0;
        int facultiesPage = 1;

        List<Specialization> specializations = new List<Specialization>();
        List<Specialization> specializationsTotal = new List<Specialization>();
        string keywordSpecialization = null;
        int? idFaculty_FilterSpecialization;
        int specializationsTotalPage = 0;
        int specializationsPage = 1;

        List<StudentClass> studentClasses = new List<StudentClass>();
        List<StudentClass> studentClassesTotal = new List<StudentClass>();
        string keywordClass = null;
        int? idSpecialization_FilterClasses;
        int classesTotalPage = 0;
        int classesPage = 1;

        List<Subject> subjects = new List<Subject>();
        List<Subject> subjectsTotal = new List<Subject>();
        string keywordSubject = null;
        int? idSpecialization_FilterSubject;
        int subjectsTotalPage = 0;
        int subjectsPage = 1;

        List<Student> students = new List<Student>();
        List<Student> studentsTotal = new List<Student>();
        string keywordStudent = null;
        int? idClass_FilterStudent;
        int studentsTotalPage = 0;
        int studentsPage = 1;
        List<MappingStudentSubject> studentSubjects = new List<MappingStudentSubject>();
        List<MappingStudentSubject> studentSubjectsTotal = new List<MappingStudentSubject>();
        void loadData()
        {
            loadDataFaculty();
            loadDataSpecialization();
            loadDataStudentClass();
            loadDataSubject();
            loadDataStudent();
        }
        #region FacultyHandling
        void loadDataFaculty()
        {
            var data = FacultyService.Query(new Dtos.FacultiesDto.SearchFacultiesDto()
            {
                Keyword = keywordFaculty,
                PageSize = 19,
            });
            faculties = data.Data;
            FacultyMapDataToGridView();
            facultiesPage = 1;
            numberPageFaculty(data);
            facultiesTotalPage = data.TotalPage;
            loadComboboxDataFaculty();
        }
        void loadComboboxDataFaculty()
        {
            var data = FacultyService.Query(new Dtos.FacultiesDto.SearchFacultiesDto()
            {
                PageSize = 1000000,
            });
            facultiesTotal = data.Data;
            loadComboBoxFaculty_Specialization();
        }
        void numberPageFaculty(PagedList<Faculty> pagedList)
        {
            facultiesTotalPage = pagedList.TotalPage;
            lblnumberPageFaculty.Text = $"{facultiesPage}/{pagedList.TotalPage}";
        }
        void FacultyMapDataToGridView()
        {
            dgvFaculties.Rows.Clear();
            dgvFaculties.Columns[0].Visible = false;
            foreach (var item in faculties)
            {
                int index = dgvFaculties.Rows.Add();
                dgvFaculties.Rows[index].Cells[0].Value = item.ID;
                dgvFaculties.Rows[index].Cells[1].Value = item.Name;
                (dgvFaculties.Rows[index].Cells[2] as DataGridViewButtonCell).Value = "Sửa";
                (dgvFaculties.Rows[index].Cells[3] as DataGridViewButtonCell).Value = "Xoá";
            }

        }
        private void Faculties_btnAdd_Click(object sender, EventArgs e)
        {
            Faculty_Updated_Frm Add_Faculty = new Faculty_Updated_Frm();
            Add_Faculty.ShowDialog();
            loadDataFaculty();
        }
        private void Faculty_CellContentClick_btUpdate(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["Faculty_btnUpdate"].Index && e.RowIndex >= 0)
            {
                Faculty_Updated_Frm updateFaculty = new Faculty_Updated_Frm(faculties[e.RowIndex]);
                updateFaculty.ShowDialog();
                loadDataFaculty();
                loadDataSpecialization();
            }
            else if (e.ColumnIndex == senderGrid.Columns["Faculty_btnDelete"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa khoa này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedRow = dgvFaculties.Rows[e.RowIndex];
                    int facultyID = int.Parse(selectedRow.Cells[0].Value.ToString());
                    bool deleteResult = FacultyService.Delete(facultyID);
                    if (deleteResult == true)
                    {
                        MessageBox.Show("Xóa khoa thành công", "Thông báo");
                        loadDataFaculty();
                        loadDataSpecialization();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khoa thất bại", "Thông báo");
                    }
                }
            }

        }
        private void Faculties_btnFilter_Click(object sender, EventArgs e)
        {
            keywordFaculty = Faculties_txtKeyWord_Filter.Text.Trim();
            facultiesPage = 1;
            var data = FacultyService.Query(new Dtos.FacultiesDto.SearchFacultiesDto()
            {
                Keyword = keywordFaculty,
                NumberPage = facultiesPage,
                PageSize = 19,
            });
            faculties = data.Data;
            numberPageFaculty(data);
            FacultyMapDataToGridView();
        }
        private void Faculty_btnBack_Click(object sender, EventArgs e)
        {
            facultiesPage--;
            facultiesPage = facultiesPage < 1 ? 1 : facultiesPage;
            var data = FacultyService.Query(new Dtos.FacultiesDto.SearchFacultiesDto()
            {
                Keyword = keywordFaculty,
                NumberPage = facultiesPage,
                PageSize = 19,
            });
            faculties = data.Data;
            FacultyMapDataToGridView();
            numberPageFaculty(data);
        }
        private void Faculty_btnContinue_Click(object sender, EventArgs e)
        {
            facultiesPage++;
            facultiesPage = facultiesPage < facultiesTotalPage ? facultiesPage : facultiesTotalPage;
            var data = FacultyService.Query(new Dtos.FacultiesDto.SearchFacultiesDto()
            {
                Keyword = keywordFaculty,
                NumberPage = facultiesPage,
                PageSize = 19,
            });
            faculties = data.Data;
            FacultyMapDataToGridView();
            numberPageFaculty(data);
        }
        #endregion

        #region SpecializationHandling
        void loadDataSpecialization()
        {
            var data = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                Keyword = keywordSpecialization,
                FacultyID = idFaculty_FilterSpecialization,
                PageSize = 19,
            });
            specializations = data.Data;
            SpecializationsMapDataToGridView();
            specializationsPage = 1;
            numberPageSpecialization(data);
            specializationsTotalPage = data.TotalPage;
            loadComboBoxDataSpecialization();
        }

        void loadComboBoxDataSpecialization()
        {
            var data = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                PageSize = 1000000,
            });
            specializationsTotal = data.Data;
            loadComboBoxSpecialization_Class();
            loadComboBoxSpecialization_Subject();
        }
        void loadComboBoxFaculty_Specialization()
        {
            Specialization_cmbFaculty_Filter.Items.Clear();
            Specialization_cmbFaculty_Filter.Items.Add("Tất cả");
            foreach (var item in facultiesTotal)
            {
                Specialization_cmbFaculty_Filter.Items.Add(item);
            }
        }
        private void Specialization_btnAdd_Click(object sender, EventArgs e)
        {
            Specializations_Updated_Frm addSpecialization = new Specializations_Updated_Frm();
            addSpecialization.ShowDialog();
            loadDataSpecialization();
        }
        void SpecializationsMapDataToGridView()
        {
            dgvSpecializations.Rows.Clear();
            dgvSpecializations.Columns[0].Visible = false;
            foreach (var item in specializations)
            {
                int index = dgvSpecializations.Rows.Add();
                dgvSpecializations.Rows[index].Cells[0].Value = item.ID;
                dgvSpecializations.Rows[index].Cells[1].Value = item.Name;
                dgvSpecializations.Rows[index].Cells[2].Value = item.Faculty.Name;
                (dgvSpecializations.Rows[index].Cells[3] as DataGridViewButtonCell).Value = "Sửa";
                (dgvSpecializations.Rows[index].Cells[4] as DataGridViewButtonCell).Value = "Xoá";
            }
        }

        private void Specialization_dgvSpecialization_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["Specialization_btnUpdate"].Index && e.RowIndex >= 0)
            {
                Specializations_Updated_Frm updateSpecialization = new Specializations_Updated_Frm(specializations[e.RowIndex]);
                updateSpecialization.ShowDialog();
                loadDataSpecialization();
                loadDataStudentClass();
                loadDataSubject();
            }
            else if (e.ColumnIndex == senderGrid.Columns["Specialization_btnDelete"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa chuyên ngành này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedRow = dgvSpecializations.Rows[e.RowIndex];
                    int specializationID = int.Parse(selectedRow.Cells[0].Value.ToString());
                    bool deleteResult = SpecializationService.Delete(specializationID);
                    if (deleteResult == true)
                    {
                        MessageBox.Show("Xóa chuyên ngành thành công", "Thông báo");
                        loadDataSpecialization();
                        loadDataStudentClass();
                        loadDataSubject();
                    }
                    else
                    {
                        MessageBox.Show("Xóa chuyên ngành thất bại", "Thông báo");
                    }
                }
            }
        }
        private void Specialization_btnFilter_Click(object sender, EventArgs e)
        {
            keywordSpecialization = Specialization_txtKeyWord_Filter.Text.Trim();
            specializationsPage = 1;
            idFaculty_FilterSpecialization = null;
            if (!string.IsNullOrEmpty(Specialization_cmbFaculty_Filter.Text.Trim()))
            {
                var selectedFaculty = facultiesTotal.FirstOrDefault(f => f.Name == Specialization_cmbFaculty_Filter.Text);
                if (selectedFaculty != null)
                {
                    idFaculty_FilterSpecialization = selectedFaculty.ID;
                }
            }
            var data = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                Keyword = keywordSpecialization,
                NumberPage = specializationsPage,
                FacultyID = idFaculty_FilterSpecialization,
                PageSize = 19,
            });
            specializations = data.Data;
            SpecializationsMapDataToGridView();
            numberPageSpecialization(data);
        }
        void numberPageSpecialization(PagedList<Specialization> pagedList)
        {
            specializationsTotalPage = pagedList.TotalPage;
            lblnumberPageSpecialization.Text = $"{specializationsPage}/{pagedList.TotalPage}";
        }
        private void Specialization_btnContinue_Click(object sender, EventArgs e)
        {
            specializationsPage++;
            specializationsPage = specializationsPage < specializationsTotalPage ? specializationsPage : specializationsTotalPage;
            var data = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                Keyword = keywordSpecialization,
                FacultyID = idFaculty_FilterSpecialization,
                NumberPage = specializationsPage,
                PageSize = 19,
            });
            specializations = data.Data;
            SpecializationsMapDataToGridView();
            numberPageSpecialization(data);
        }

        private void Specialization_btnBack_Click(object sender, EventArgs e)
        {
            specializationsPage--;
            specializationsPage = specializationsPage < 1 ? 1 : specializationsPage;
            var data = SpecializationService.Query(new Dtos.SpecializationDto.SearchSpecializationDto()
            {
                Keyword = keywordSpecialization,
                FacultyID = idFaculty_FilterSpecialization,
                NumberPage = specializationsPage,
                PageSize = 19,
            });
            specializations = data.Data;
            SpecializationsMapDataToGridView();
            numberPageSpecialization(data);
        }
        #endregion

        #region StudentClassesHandling1
        void loadDataStudentClass()
        {
            var data = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                Keyword = keywordClass,
                SpecializationID = idSpecialization_FilterClasses,
            });
            studentClasses = data.Data;
            StudentClassesMapDataToGridView();
            classesPage = 1;
            numberPageClass(data);
            classesTotalPage = data.TotalPage;
            loadComboboxDataClass();
        }
        void loadComboboxDataClass()
        {
            var data = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                PageSize = 1000000,
            });
            studentClassesTotal = data.Data;
            loadComboBoxClass_Student();
            
        }
        void loadComboBoxSpecialization_Class()
        {
            Classes_cmbSpecialization_Filter.Items.Clear();
            Classes_cmbSpecialization_Filter.Items.Add("");
            foreach (var item in specializationsTotal)
            {
                Classes_cmbSpecialization_Filter.Items.Add(item);
            }
        }

        private void Classes_btnAdd_Click(object sender, EventArgs e)
        {
            Classes_Update_Frm Add_Class = new Classes_Update_Frm();
            Add_Class.ShowDialog();
            loadDataStudentClass();
        }

        void StudentClassesMapDataToGridView()
        {
            dgvClasses.Rows.Clear();
            foreach (var it in studentClasses)
            {
                int index = dgvClasses.Rows.Add();
                dgvClasses.Rows[index].Cells[0].Value = it.ID;
                dgvClasses.Rows[index].Cells[1].Value = it.Name;
                dgvClasses.Rows[index].Cells[2].Value = it.Specialization.Name;
                dgvClasses.Rows[index].Cells[3].Value = it.Students.Count();
                (dgvClasses.Rows[index].Cells[4] as DataGridViewButtonCell).Value = "Sửa";
                (dgvClasses.Rows[index].Cells[5] as DataGridViewButtonCell).Value = "Xoá";
            }
        }

        private void Classes_dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["Class_btnUpdate"].Index)
            {
                Classes_Update_Frm updateClass = new Classes_Update_Frm(studentClasses[e.RowIndex]); ;
                updateClass.ShowDialog();
                loadDataStudentClass();
                loadDataStudent();
            }
            else if (e.ColumnIndex == senderGrid.Columns["Class_btnDelete"].Index)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa lớp không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var selectedRow = dgvClasses.Rows[e.RowIndex];
                    int classID = int.Parse(selectedRow.Cells[0].Value.ToString());
                    bool deleteResult = ClassService.Delete(classID);
                    if (deleteResult == true)
                    {
                        MessageBox.Show("Xóa lớp thành công", "Thông báo");
                        loadDataStudentClass();
                        loadDataStudent();
                    }
                    else
                    {
                        MessageBox.Show("Xóa lớp thất bại", "Thông báo");
                    }
                }
            }
        }

        private void Class_btnFilter_Click(object sender, EventArgs e)
        {
            keywordClass = Classes_txtKeyWord_Filter.Text.Trim();
            idSpecialization_FilterClasses = null;
            specializationsPage = 1;
            if (!string.IsNullOrEmpty(Classes_cmbSpecialization_Filter.Text.Trim()))
            {
                var selectedSpecialization = specializationsTotal.FirstOrDefault(x => x.Name == Classes_cmbSpecialization_Filter.Text);
                if (selectedSpecialization != null)
                {
                    idSpecialization_FilterClasses = selectedSpecialization.ID;
                }
            }
            var data = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                Keyword = keywordClass,
                SpecializationID = idSpecialization_FilterClasses,
                NumberPage = specializationsPage,
            });
            studentClasses = data.Data;
            StudentClassesMapDataToGridView();
            numberPageClass(data);
        }
        void numberPageClass(PagedList<StudentClass> pagedList)
        {
            classesTotalPage = pagedList.TotalPage;
            lblnumberPageClass.Text = $"{classesPage}/{pagedList.TotalPage}";
        }
        private void Classes_btnBack_Click(object sender, EventArgs e)
        {
            classesPage--;
            classesPage = classesPage < 1 ? 1 : classesPage;
            var data = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                Keyword = keywordClass,
                SpecializationID = idSpecialization_FilterClasses,
                NumberPage = classesPage,
            });
            classesTotalPage = data.TotalPage;
            studentClasses = data.Data;
            StudentClassesMapDataToGridView();
            numberPageClass(data);
        }

        private void Classes_btnContinue_Click(object sender, EventArgs e)
        {
            classesPage++;
            classesPage = classesPage < classesTotalPage ? classesPage : classesTotalPage;
            var data = ClassService.Query(new Dtos.ClassDto.SearchClassDto()
            {
                Keyword = keywordClass,
                SpecializationID = idSpecialization_FilterClasses,
                NumberPage = classesPage,
            });
            studentClasses = data.Data;
            StudentClassesMapDataToGridView();
            numberPageClass(data);
        }
        #endregion

        #region SubjectHangling

        void loadDataSubject()
        {
            var data = SubjectService.Query(new Dtos.SubjectDto.SearchSubjectDto()
            {
                Keyword = keywordSubject,
                SpecializationID = idSpecialization_FilterSubject,
                PageSize = 20,
            });
            subjects = data.Data;
            SubjectsMapDataToGridView();
            numberPageSubject(data);
            subjectsTotalPage = data.TotalPage;
            loadComboBoxDataSubject();
        }
        void loadComboBoxDataSubject()
        {
            var data = SubjectService.Query(new Dtos.SubjectDto.SearchSubjectDto()
            {
                PageSize = 1000000,
            });
            subjectsTotal = data.Data;

        }
        void loadComboBoxSpecialization_Subject()
        {
            Subjects_cmbSpecialization_Filter.Items.Clear();
            Subjects_cmbSpecialization_Filter.Items.Add("Chọn tất cả");
            foreach (var item in specializationsTotal)
            {
                Subjects_cmbSpecialization_Filter.Items.Add(item);
            }
        }
        void SubjectsMapDataToGridView()
        {
            dgvSubjects.Rows.Clear();
            foreach (var it in subjects)
            {
                int index = dgvSubjects.Rows.Add();
                dgvSubjects.Rows[index].Cells[0].Value = it.ID;
                dgvSubjects.Rows[index].Cells[1].Value = it.Code;
                dgvSubjects.Rows[index].Cells[2].Value = it.Name;
                dgvSubjects.Rows[index].Cells[3].Value = it.Specialization.Name;
                (dgvSubjects.Rows[index].Cells[4] as DataGridViewButtonCell).Value = "Sửa";
                (dgvSubjects.Rows[index].Cells[5] as DataGridViewButtonCell).Value = "Xoá";
            }
        }
        private void Subjects_btnAdd_Click(object sender, EventArgs e)
        {
            SubjectsUpdated_Frm subject = new SubjectsUpdated_Frm();
            subject.ShowDialog();
            loadDataSubject();
        }
        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["Subject_btnUpdate"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dgvSubjects.Rows[e.RowIndex];
                SubjectsUpdated_Frm updateSubject = new SubjectsUpdated_Frm(subjects[e.RowIndex]);                updateSubject.ShowDialog();
                loadDataSubject();

            }
            else if (e.ColumnIndex == senderGrid.Columns["Subject_btnDelete"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa môn học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedRow = dgvSubjects.Rows[e.RowIndex];
                    int subjectID = int.Parse(selectedRow.Cells[0].Value.ToString());
                    bool deleteResult = SubjectService.Delete(subjectID);
                    if (deleteResult == true)
                    {
                        MessageBox.Show("Xóa môn học thành công", "Thông báo");
                        loadDataSubject();
                    }
                    else
                    {
                        MessageBox.Show("Xóa môn học thất bại", "Thông báo");
                    }
                }
            }
        }
        private void Subjects_btnFilter_Click(object sender, EventArgs e)
        {
            keywordSubject = Subjects_txtKeyWord_Filter.Text.Trim();
            subjectsPage = 1;
            idSpecialization_FilterSubject = null;
            if (!string.IsNullOrEmpty(Subjects_cmbSpecialization_Filter.Text.Trim()))
            {
                var selectedSpecialization = specializationsTotal.FirstOrDefault(f => f.Name == Subjects_cmbSpecialization_Filter.Text);
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
                PageSize = 20,
            });
            subjects = data.Data;
            SubjectsMapDataToGridView();
            numberPageSubject(data);
        }
        void numberPageSubject(PagedList<Subject> pagedList)
        {
            subjectsTotalPage = pagedList.TotalPage;
            lblnumberPageSubject.Text = $"{subjectsPage}/{pagedList.TotalPage}";
        }


        private void Subject_btnContinue_Click(object sender, EventArgs e)
        {
            subjectsPage++;
            subjectsPage = subjectsPage < subjectsTotalPage ? subjectsPage : subjectsTotalPage;
            var data = SubjectService.Query(new Dtos.SubjectDto.SearchSubjectDto()
            {
                Keyword = keywordSubject,
                SpecializationID = idSpecialization_FilterSubject,
                NumberPage = subjectsPage,
                PageSize = 20,
            });
            subjects = data.Data;
            SubjectsMapDataToGridView();
            numberPageSubject(data);
        }

        private void Subject_btnBack_Click(object sender, EventArgs e)
        {
            subjectsPage--;
            subjectsPage = subjectsPage < 1 ? 1 : subjectsPage;
            var data = SubjectService.Query(new Dtos.SubjectDto.SearchSubjectDto()
            {
                Keyword = keywordSubject,
                SpecializationID = idSpecialization_FilterSubject,
                NumberPage = subjectsPage,
                PageSize = 20,
            });
            subjects = data.Data;
            SubjectsMapDataToGridView();
            numberPageSubject(data);
        }
        #endregion

        #region StudentHandling
        void loadDataStudent()
        {
            var data = StudentService.Query(new Dtos.StudentDto.SearchStudentDto()
            {
                Keyword = keywordStudent,
                ClassID = idClass_FilterStudent,
                PageSize = 20,
            });
            students = data.Data;
            StudentsMapDataToGridView();
            numberPageStudent(data);
            studentsTotalPage = data.TotalPage;
            loadStudentsTotal();

            loadStudentSubject();
        }
        void loadComboBoxClass_Student()
        {
            Student_cmbClass_Filter.Items.Clear();
            Student_cmbClass_Filter.Items.Add("Chọn tất cả");
            foreach (var item in studentClassesTotal)
            {
                Student_cmbClass_Filter.Items.Add(item);
            }
        }
        void loadStudentsTotal()
        {
            var data = StudentService.Query(new Dtos.StudentDto.SearchStudentDto()
            {
                PageSize = 1000000,
            });
            studentsTotal = data.Data;
        }
        void StudentsMapDataToGridView()
        {
            dgvStudents.Rows.Clear();
            foreach (var it in students)
            {
                int index = dgvStudents.Rows.Add();
                dgvStudents.Rows[index].Cells[0].Value = it.ID;
                dgvStudents.Rows[index].Cells[1].Value = it.Name;
                dgvStudents.Rows[index].Cells[2].Value = it.Code;
                dgvStudents.Rows[index].Cells[3].Value = it.StudentClass.Name;
                (dgvStudents.Rows[index].Cells[4] as DataGridViewButtonCell).Value = "Sửa";
                (dgvStudents.Rows[index].Cells[5] as DataGridViewButtonCell).Value = "Xoá";
            }
        }
        private void Student_btnAdd_Click(object sender, EventArgs e)
        {
            StudentAdded_Frm addStudent = new StudentAdded_Frm();
            addStudent.ShowDialog();
            loadDataStudent();
            loadDataStudentClass();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["Student_btnUpdate"].Index && e.RowIndex >= 0)
            {
                Student_Updated f = new Student_Updated(students[e.RowIndex]);
                f.ShowDialog();
                loadDataStudent();
                loadDataStudentClass();
                loadStudentSubject();

            }
            else if (e.ColumnIndex == senderGrid.Columns["Student_btnDelete"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedRow = dgvStudents.Rows[e.RowIndex];
                    int studentID = int.Parse(selectedRow.Cells[0].Value.ToString());
                    bool deleteResult = StudentService.Delete(studentID);
                    if (deleteResult == true)
                    {
                        MessageBox.Show("Xóa sinh viên thành công", "Thông báo");
                        loadDataStudent();
                        loadDataStudentClass();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thất bại", "Thông báo");
                    }
                }
            }
        }
        private void Student_btnFilter_Click(object sender, EventArgs e)
        {
            keywordStudent = Student_txtKeyWord_Filter.Text.Trim();
            studentsPage = 1;
            idClass_FilterStudent = null;
            if (!string.IsNullOrEmpty(Student_cmbClass_Filter.Text.Trim()))
            {
                var selectedClass = studentClassesTotal.FirstOrDefault(f => f.Name == Student_cmbClass_Filter.Text);
                if (selectedClass != null)
                {
                    idClass_FilterStudent = selectedClass.ID;
                }
            }
            var data = StudentService.Query(new Dtos.StudentDto.SearchStudentDto()
            {
                Keyword = keywordStudent,
                NumberPage = studentsPage,
                ClassID = idClass_FilterStudent,
                PageSize = 20,
            });
            students = data.Data;
            StudentsMapDataToGridView();
            numberPageStudent(data);
        }
        void numberPageStudent(PagedList<Student> pagedList)
        {
            studentsTotalPage = pagedList.TotalPage;
            lblnumberPageStudent.Text = $"{studentsPage}/{pagedList.TotalPage}";
        }

        private void Student_btnContinue_Click(object sender, EventArgs e)
        {
            studentsPage++;
            studentsPage = studentsPage < studentsTotalPage ? studentsPage : studentsTotalPage;
            var data = StudentService.Query(new Dtos.StudentDto.SearchStudentDto()
            {
                Keyword = keywordStudent,
                ClassID = idClass_FilterStudent,
                NumberPage = studentsPage,
                PageSize = 20,
            });
            students = data.Data;
            StudentsMapDataToGridView();
            numberPageStudent(data);
        }

        private void Student_btnBack_Click(object sender, EventArgs e)
        {
            studentsPage--;
            studentsPage = studentsPage < 1 ? 1 : studentsPage;
            var data = StudentService.Query(new Dtos.StudentDto.SearchStudentDto()
            {
                Keyword = keywordStudent,
                ClassID = idClass_FilterStudent,
                NumberPage = studentsPage,
                PageSize = 20,
            });
            students = data.Data;
            StudentsMapDataToGridView();
            numberPageStudent(data);
        }

        #endregion

        void loadStudentSubject()
        {
            var data = StudentSubjectService.Query(new Dtos.StudentDto.SearchStudentSubjectDto()
            {
                PageSize = 10000000,
            });
            studentSubjectsTotal = data.Data;
        }
        private void dgvStudents_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
