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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Update(int facultyID, string newfacultyName)
        {
            db.Configuration.AutoDetectChangesEnabled = true;
            try
            {
                var facultyToUpdate = db.Faculties.FirstOrDefault(f => f.ID == facultyID);
                if (facultyToUpdate == null)
                {
                    MessageBox.Show("Không tìm thấy khoa cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (db.Faculties.Any(x => x.Name == newfacultyName && x.ID != facultyID))
                {
                    MessageBox.Show("Tên khoa đã tồn tại", "Thông báo");
                    return false;
                }

                facultyToUpdate.Name = newfacultyName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Delete(int facultyID)
        {
            try
            {
                var facultyToDelete = db.Faculties.FirstOrDefault(f => f.ID == facultyID);
                db.Faculties.Remove(facultyToDelete);
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
