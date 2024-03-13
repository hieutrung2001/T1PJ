using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using T1PJ.Domain.Context;
using T1PJ.Domain.Entity;
using T1PJ.Domain.Model.Paginations;
using T1PJ.Domain.Model.Students;
using T1PJ.Domain.Model.Paginations;

namespace T1PJ.Core.Services.Students
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
            return await _context.Students.AsNoTracking().Select(x => new Student
            {
                Id = x.Id,
                FullName = x.FullName,
                Dob = x.Dob,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                StudentClasses = x.StudentClasses,
            }).ToListAsync();
        }

        public async Task<JsonData<IndexModel>> LoadTable(Pagination model)
        {
            int recordsTotal = await _context.Students.CountAsync();
            int recordsFiltered = recordsTotal;
            var results = await _context.Students.AsNoTracking().Select(x => new IndexModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Dob = x.Dob,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                StudentClasses = x.StudentClasses,
            }).Skip(model.Start).Take(model.Length).ToListAsync();
            if (model.Order != null)
            {
                if (model.Order[0].Dir == "asc")
                {
                    if (model.Order[0].Column == 0)
                    {
                        results = results.OrderBy(data => data.FullName).ToList();
                    } else if (model.Order[0].Column == 2)
                    {
                        results = results.OrderBy(data => data.Address).ToList();
                    }
                }
                else
                {
                    if (model.Order[0].Column == 0)
                    {
                        results = results.OrderByDescending(data => data.FullName).ToList();
                    }
                    else if (model.Order[0].Column == 2)
                    {
                        results = results.OrderByDescending(data => data.Address).ToList();
                    }
                }
            }
            if (!string.IsNullOrEmpty(model.Search.Value))
            {
                results = results.Where(m => m.FullName.ToLower().Contains(model.Search.Value.ToLower())
                                            || m.Address.ToLower().Contains(model.Search.Value.ToLower())).ToList();
                recordsFiltered = results.Count();
            }
            
            return new JsonData<IndexModel> { Draw = model.Draw, RecordsFiltered = recordsFiltered, RecordsTotal = recordsTotal, Data = results };
        }

        public async Task<Student> GetStudentById(int id)
        {
            var result1 = await _context.Students.AsNoTracking().Where(x => x.Id == id).FirstAsync();
            return result1;
        }

        public async Task<Student> Create(Student student)
        {
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
            result.FullName = student.FullName;
            result.Address = student.Address;
            result.PhoneNumber = student.PhoneNumber;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                throw new Exception("Student not found!");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Student>> GetStudentsOfClass(int classId)
        {
            var studentsOfClass = new List<Student>();
            var students = await GetAll();
            if (students != null)
            {
                foreach (var item in students)
                {
                    if (item.StudentClasses?.Count > 0)
                    {
                        foreach (var y in item.StudentClasses)
                        {
                            if (y.ClassId == classId)
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
