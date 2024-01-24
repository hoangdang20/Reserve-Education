using ReserveEducation.Dtos.SubjectDto;
using ReserveEducation.Dtos;
using ReserveEducation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReserveEducation.Dtos.StudentDto;

namespace ReserveEducation.Services
{
    internal class StudentSubjectService
    {
        public static readonly ReserveEducationEntities db = FacultyService.db;
        public static PagedList<MappingStudentSubject> Query(SearchStudentSubjectDto request)
        {
            // request.Keyword = request.Keyword == null ? null : request.Keyword.ToLower();
            var data = db.MappingStudentSubjects.Where(x => (request.StudentID == null || x.StudentID == request.StudentID) && (request.SubjectID == null || x.SubjectID == request.SubjectID)).ToList();
            return new PagedList<MappingStudentSubject>(data, request.NumberPage, request.PageSize, data.Count());
        }
        public static bool Create(Student student, Subject subject)
        {
            try
            {
                if (db.MappingStudentSubjects.Any(x => x.StudentID == student.ID && x.SubjectID == subject.ID))
                {
                    return false;
                }
                var StudentSubject = new MappingStudentSubject
                {
                    SubjectID = subject.ID,
                    StudentID = student.ID,
                };
                db.MappingStudentSubjects.Add(StudentSubject);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Update(MappingStudentSubject studentSubject)
        {
            try
            {
                var studentSubjectToUpdate = db.MappingStudentSubjects.FirstOrDefault(s => s.ID == studentSubject.ID);
                if (studentSubjectToUpdate == null) return false;
                studentSubjectToUpdate.IsPassed = studentSubject.IsPassed;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Delete(Student student, Subject subject)
        {
            try
            {
                var mappingStudentSubjectToDelete = db.MappingStudentSubjects.FirstOrDefault(x => x.StudentID == student.ID && x.SubjectID == subject.ID);
                db.MappingStudentSubjects.Remove(mappingStudentSubjectToDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
