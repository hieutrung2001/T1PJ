using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Context;
using T1PJ.DataLayer.Entity;

namespace T1PJ.Repository.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly T1PJContext _context;

        public StudentService(T1PJContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
            if (_context == null || _context.Students == null)
            {
                return null;
            }
            return await _context.Students.AsNoTracking().Select(x => new Student
            {
                Id = x.Id,
                FullName = x.FullName,
                Dob = x.Dob,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                Classes = x.Classes,
            }).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            if (_context == null || _context.Students == null)
            {
                return null;
            }
            var result = await _context.Students.FindAsync(id);
            var result1 = await _context.Students.AsNoTracking().Where(x => x.Id == id).FirstAsync();
            return result1;
        }

        public async Task<Student> Create(Student student)
        {
            if (_context == null || _context.Students == null)
            {
                return null;
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(Student student)
        {
            
            var result = _context.Students.Find(student.Id);
            if (result is null|| _context.Students == null)
            {
                return null;
            }
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (_context == null || _context.Students == null)
            {
                throw new Exception("Student not found!");
            }
            if (student == null)
            {
                throw new Exception("Student not found!");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Student>> GetStudentsOfClass(int classId)
        {
            if (_context == null || _context.Students == null)
            {
                return null;
            }
            var studentsOfClass = new List<Student>();
            var students = await GetAll();
            if (students != null)
            {
                foreach (var item in students)
                {
                    if (item.Classes?.Count > 0)
                    {
                        foreach (var y in item.Classes)
                        {
                            if (y.Id == classId)
                            {
                                studentsOfClass.Add(item);
                                break;
                            }
                        }
                    }
                }
                return studentsOfClass;
            }
            return [];
        }
    }
}
