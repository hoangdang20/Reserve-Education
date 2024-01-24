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
        public static bool Create(string newSubjectName, string newStudentCode)
        {
            try
            {
                MappingStudentSubject mappingStudentSubject = new MappingStudentSubject
                {
                    SubjectID = db.Subjects.FirstOrDefault(x => x.Name == newSubjectName).ID,
                    StudentID = db.Students.FirstOrDefault(x => x.Code == newStudentCode).ID,
                };
                db.MappingStudentSubjects.Add(mappingStudentSubject);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Update(string newSubjectName, string newStudentCode, bool isPassed)
        {
            try
            {
                var mappingStudentSubjectToUpdate = db.MappingStudentSubjects.FirstOrDefault(s => s.Subject.Name == newSubjectName && s.Student.Code == newStudentCode);
                mappingStudentSubjectToUpdate.IsPassed = isPassed;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Delete(string newSubjectName, string newStudentCode)
        {
            try
            {
                var mappingStudentSubjectToDelete = db.MappingStudentSubjects.Where(s => s.Subject.Name == newSubjectName && s.Student.Code == newStudentCode);
                db.MappingStudentSubjects.RemoveRange(mappingStudentSubjectToDelete);
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
