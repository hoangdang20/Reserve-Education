using ReserveEducation.Dtos;
using ReserveEducation.Dtos.FacultiesDto;
using ReserveEducation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEducation.Services
{
    internal class FacultyService
    {
        public static readonly ReserveEducationEntities db = new ReserveEducationEntities();
        public static PagedList<Faculty> Query(SearchFacultiesDto request)
        {
            request.Keyword = request.Keyword == null ? null : request.Keyword.ToLower();
            var temo = db.Faculties.ToList();
            var data = db.Faculties.Where(x => request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.ID.ToString().ToLower().Contains(request.Keyword)).ToList();
            return new PagedList<Faculty>(data, request.NumberPage, request.PageSize, data.Count());
        }

        public static bool Create(Faculty faculty)
        {
            try
            {
                if (db.Faculties.Any(x => x.Name == faculty.Name))
                {
                    MessageBox.Show("Tên khoa đã tồn tại", "Thông báo");
                    return false;
                }
                db.Faculties.Add(faculty);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(Faculty faculty)
        {
            try
            {
                var facultyToUpdate = db.Faculties.FirstOrDefault(f => f.ID == faculty.ID);
                if (db.Faculties.Any(x => x.Name == faculty.Name && x.ID != faculty.ID))
                {
                    MessageBox.Show("Tên khoa đã tồn tại", "Thông báo");
                    return false;
                }
                facultyToUpdate.Name = faculty.Name;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(int facultyID)
        {
            try
            {
                var facultyToDelete = db.Faculties.FirstOrDefault(f => f.ID == facultyID);
                if (facultyToDelete.Specializations.Count() > 0)
                {
                    return false;
                }
                db.Faculties.Remove(facultyToDelete);
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
