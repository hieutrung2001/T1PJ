using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            return await _context.Students.Include(s => s.Classes).OrderByDescending(c => c.Created).ToListAsync();
        }

        public Student GetStudentById(int id)
        {
            if (_context == null || _context.Students == null)
            {
                return null;
            }
            var result = _context.Students.Find(id);
            return result;
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
            if (_context == null || _context.Students == null)
            {
                return null;
            }
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public void Delete(int id)
        {
            if (_context == null || _context.Students == null)
            {
                return;
            }
            if (_context.Students.FirstOrDefault(s => s.Id == id) == null)
            {
                return;
            }
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Students.Remove(student);
            _context.SaveChangesAsync();
            
        }
    }
}
