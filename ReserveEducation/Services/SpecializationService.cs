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
            var data = db.Specializations.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.ID.ToString().ToLower().Contains(request.Keyword)) && (request.FacultyID == null || x.FacultyID == request.FacultyID)).ToList();
            return new PagedList<Specialization>(data, request.NumberPage, request.PageSize, data.Count());
        }

        public static bool Create(string newSpecializationName, string newFacultyName)
        {
            try
            {
                if (db.Specializations.Any(x => x.Name == newSpecializationName))
                {
                    MessageBox.Show("Tên chuyên ngành đã tồn tại", "Thông báo");
                    return false;
                }
                Specialization specialization = new Specialization
                {
                    Name = newSpecializationName,
                    FacultyID = db.Faculties.FirstOrDefault(x => x.Name == newFacultyName).ID,
                };
                db.Specializations.Add(specialization);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Update(int specializationID, string newspecializationName, string newfacultyName)
        {
            try
            {
                var specializationToUpdate = db.Specializations.FirstOrDefault(s => s.ID == specializationID);
                if (db.Specializations.Any(x => x.Name == newspecializationName && x.Faculty.Name == newfacultyName))
                {
                    MessageBox.Show("Tên chuyên ngành đã tồn tại", "Thông báo");
                    return false;
                }
                specializationToUpdate.Name = newspecializationName;
                specializationToUpdate.FacultyID = db.Faculties.FirstOrDefault(f => f.Name == newfacultyName).ID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Delete(int specializationID)
        {
            try
            {
                var specializationToDelete = db.Specializations.FirstOrDefault(f => f.ID == specializationID);
                db.Specializations.Remove(specializationToDelete);
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
