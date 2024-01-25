using ReserveEducation.Dtos.SpecializationDto;
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
    internal class SpecializationService
    {
        public static readonly ReserveEducationEntities db = FacultyService.db;
        public static PagedList<Specialization> Query(SearchSpecializationDto request)
        {
            request.Keyword = request.Keyword == null ? null : request.Keyword.ToLower();
            var data = db.Specializations.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword)) && (request.FacultyID == null || x.FacultyID == request.FacultyID)).ToList();
            return new PagedList<Specialization>(data, request.NumberPage, request.PageSize, data.Count());
        }

        public static bool Create(Specialization data)
        {
            try
            {
                if (db.Specializations.Any(x => x.Name == data.Name))
                {
                    MessageBox.Show("Tên chuyên ngành đã tồn tại", "Thông báo");
                    return false;
                }
                db.Specializations.Add(data);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(Specialization data)
        {
            try
            {
                var specializationToUpdate = db.Specializations.FirstOrDefault(s => s.ID == data.ID);
                if (db.Specializations.Any(x => x.Name == data.Name && x.ID != data.ID))
                {
                    MessageBox.Show("Tên chuyên ngành đã tồn tại", "Thông báo");
                    return false;
                }
                specializationToUpdate.Name = data.Name;
                specializationToUpdate.FacultyID = data.FacultyID;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(int specializationID)
        {
            try
            {
                var specializationToDelete = db.Specializations.FirstOrDefault(f => f.ID == specializationID);
                if (specializationToDelete.StudentClasses.Count() > 0 || specializationToDelete.Subjects.Count() > 0)
                {
                    return false;
                }
                db.Specializations.Remove(specializationToDelete);
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
