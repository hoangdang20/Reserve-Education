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
    internal class StudentService
    {
        public static readonly ReserveEducationEntities db = FacultyService.db;
        public static PagedList<Student> Query(SearchStudentDto request)
        {
            request.Keyword = request.Keyword == null ? null : request.Keyword.ToLower();
            var data = db.Students.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.Code.ToLower().Contains(request.Keyword)) && (request.ClassID == null || x.StudentClassID == request.ClassID)).ToList();
            return new PagedList<Student>(data, request.NumberPage, request.PageSize, data.Count());
        }

        public static bool Create(Student student)
        {
            try
            {
                if (db.Students.Any(x => x.Code == student.Code))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo");
                    return false;
                }
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(Student student)
        {
            try
            {
                var studentToUpdate = db.Students.FirstOrDefault(s => s.ID == student.ID);
                if (db.Students.Any(x => x.Code == student.Code && x.ID != student.ID))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo");
                    return false;
                }
                studentToUpdate.Name = student.Name;
                studentToUpdate.Code = student.Code;
                studentToUpdate.StudentClassID = student.StudentClassID;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(int studentID)
        {
            try
            {
                var tmp = db.MappingStudentSubjects.Where(x => x.StudentID == studentID);
                db.MappingStudentSubjects.RemoveRange(tmp);
                var studentToDelete = db.Students.FirstOrDefault(f => f.ID == studentID);
                db.Students.Remove(studentToDelete);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
