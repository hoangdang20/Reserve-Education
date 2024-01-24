using System;
using System.Collections.Generic;
using ReserveEducation.Dtos.ClassDto;
using ReserveEducation.Dtos;
using ReserveEducation.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEducation.Services
{
    internal class ClassService
    {
        public static readonly ReserveEducationEntities db = FacultyService.db;
        public static PagedList<StudentClass> Query(SearchClassDto request)
        {
            request.Keyword = request.Keyword == null ? null : request.Keyword.ToLower();
            var data = db.StudentClasses.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.ID.ToString().Contains(request.Keyword)) && (request.SpecializationID == null || x.SpecializationID == request.SpecializationID)).ToList();
            return new PagedList<StudentClass>(data, request.NumberPage, request.PageSize, data.Count());
        }

        public static bool Create(StudentClass data)
        {
            try
            {
                if (db.StudentClasses.Any(x => x.Name == data.Name))
                {
                    MessageBox.Show("Tên lớp đã tồn tại", "Thông báo");
                    return false;
                }
                db.StudentClasses.Add(data);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(StudentClass student)
        {
            try
            {
                var studentClassToUpdate = db.StudentClasses.FirstOrDefault(c => c.ID == student.ID);
                if (db.StudentClasses.Any(x => x.Name == student.Name && x.SpecializationID == student.SpecializationID))
                {
                    MessageBox.Show("Tên lớp đã tồn tại");
                    return false;
                }
                studentClassToUpdate.Name = student.Name;
                studentClassToUpdate.SpecializationID = student.SpecializationID;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(int studentClassID)
        {
            try
            {
                var studentClassToDelete = db.StudentClasses.FirstOrDefault(c => c.ID == studentClassID);
                if (studentClassToDelete.Students.Count() > 0)
                {
                    return false;
                }
                db.StudentClasses.Remove(studentClassToDelete);
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
