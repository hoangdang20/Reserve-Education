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
            var data = db.Subjects.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.Code.ToLower().Contains(request.Keyword) || x.ID.ToString().ToLower().Contains(request.Keyword)) && (request.SpecializationID == -1 || x.SpecializationID == request.SpecializationID)).ToList();
            return new PagedList<Subject>(data, request.NumberPage, request.PageSize, data.Count());
        }
        public static bool Create(string newSubjectName, string newSubjectCode, string newSpecializationName)
        {
            try
            {
                if (db.Subjects.Any(x => x.Code == newSubjectCode))
                {
                    MessageBox.Show("Mã môn học đã tồn tại", "Thông báo");
                    return false;
                }

                if (db.Subjects.Any(x => x.Name == newSubjectName))
                {
                    MessageBox.Show("Tên môn học đã tồn tại", "Thông báo");
                    return false;
                }
                Subject subject = new Subject
                {
                    Name = newSubjectName,
                    Code = newSubjectCode,
                    SpecializationID = db.Specializations.FirstOrDefault(x => x.Name == newSpecializationName).ID,
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
        public static bool Update(int subjectID, string newSubjectCode, string newSubjectName, string newSpecializationName)
        {
            try
            {
                var subjectToUpdate = db.Subjects.FirstOrDefault(s => s.ID == subjectID);
                if (db.Subjects.Any(x => x.Name == newSubjectName && x.ID != subjectID))
                {
                    MessageBox.Show("Tên môn học đã tồn tại", "Thông báo");
                    return false;
                } 
                if (db.Subjects.Any(x => x.Code == newSubjectCode && x.ID != subjectID))
                {
                    MessageBox.Show("Mã môn học đã tồn tại", "Thông báo");
                    return false;
                }
                subjectToUpdate.Name = newSubjectName;
                subjectToUpdate.Code = newSubjectCode;
                subjectToUpdate.SpecializationID = db.Specializations.FirstOrDefault(f => f.Name == newSpecializationName).ID;
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
