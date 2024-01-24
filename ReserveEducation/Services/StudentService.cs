﻿using ReserveEducation.Dtos;
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
            var data = db.Students.Where(x => (request.Keyword == null || x.Name.ToLower().Contains(request.Keyword) || x.Code.ToLower().Contains(request.Keyword) || x.ID.ToString().ToLower().Contains(request.Keyword)) && (request.ClassID == null || x.StudentClassID == request.ClassID)).ToList();
            return new PagedList<Student>(data, request.NumberPage, request.PageSize, data.Count());
        }

        public static bool Create(string newStudentName,string newStudentCode, string newClassName)
        {
            try
            {
                if (db.Students.Any(x => x.Code == newStudentCode))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo");
                    return false;
                }
                Student student = new Student
                {
                    Name = newStudentName,
                    Code = newStudentCode,
                    StudentClassID = db.StudentClasses.FirstOrDefault(x => x.Name == newClassName).ID,
                };
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Update(int studentID, string newStudentName, string newStudentCode, string newClassName)
        {
            try
            {
                var studentToUpdate = db.Students.FirstOrDefault(s => s.ID == studentID);
                if (db.Students.Any(x => x.Name == newStudentCode && x.ID != studentID))
                {
                    MessageBox.Show("Sinh viên đã tồn tại", "Thông báo");
                    return false;
                }
                studentToUpdate.Name = newStudentName;
                studentToUpdate.Code = newStudentCode;
                studentToUpdate.StudentClassID = db.StudentClasses.FirstOrDefault(f => f.Name == newClassName).ID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Delete(int studentID)
        {
            try
            {
                var studentToDelete = db.Students.FirstOrDefault(f => f.ID == studentID);
                db.Students.Remove(studentToDelete);
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