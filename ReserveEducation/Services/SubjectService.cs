using ReserveEducation.Dtos.SubjectDto;
using ReserveEducation.Dtos;
using ReserveEducation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEducation.Services
{
    internal class SubjectService
    {
        public static readonly ReserveEducationEntities db = FacultyService.db;
        public static PagedList<Subject> Query(SearchSubjectDto request)
        {
            request.Keyword = request.Keyword == null ? null : request.Keyword.ToLower();
            var data = db.Subjects.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.Code.ToLower().Contains(request.Keyword) || x.ID.ToString().ToLower().Contains(request.Keyword)) && (request.SpecializationID == null || x.SpecializationID == request.SpecializationID)).ToList();
            return new PagedList<Subject>(data, request.NumberPage, request.PageSize, data.Count());
        }
        public static bool Create(Subject data)
        {
            try
            {
                if (db.Subjects.Any(x => x.Code == data.Code))
                {
                    MessageBox.Show("Mã môn học đã tồn tại", "Thông báo");
                    return false;
                }

                if (db.Subjects.Any(x => x.Name == data.Name))
                {
                    MessageBox.Show("Tên môn học đã tồn tại", "Thông báo");
                    return false;
                }
                Subject subject = new Subject
                {
                    Name = data.Name,
                    Code = data.Code,
                    SpecializationID = data.SpecializationID,
                };
                db.Subjects.Add(subject);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Update(Subject data)
        {
            try
            {
                var subjectToUpdate = db.Subjects.FirstOrDefault(s => s.ID == data.ID);
                if (db.Subjects.Any(x => x.Name == data.Name&&x.SpecializationID == data.SpecializationID))
                {
                    MessageBox.Show("Tên môn học đã tồn tại", "Thông báo");
                    return false;
                }
                subjectToUpdate.Name = data.Name;
                subjectToUpdate.Code = data.Code;
                subjectToUpdate.SpecializationID = data.SpecializationID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Delete(int subjectID)
        {
            try
            {
                var subjectToDelete = db.Subjects.FirstOrDefault(f => f.ID == subjectID);
                db.Subjects.Remove(subjectToDelete);
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
