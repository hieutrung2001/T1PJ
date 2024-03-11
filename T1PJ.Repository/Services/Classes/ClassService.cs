using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Context;
using T1PJ.DataLayer.Entity;

namespace T1PJ.Repository.Services.Classes
{
    public class ClassService : IClassService
    {
        private readonly T1PJContext _context;

        public ClassService(T1PJContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAll()
        {
            if (_context == null || _context.Classes == null)
            {
                return null;
            }
            return await _context.Classes.AsNoTracking().Select(x => new Class
            {
                Id = x.Id,
                Name = x.Name,
                StudentClasses = x.StudentClasses,
            }).ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            if (_context == null || _context.Classes == null)
            {
                return null;
            }
            var result = await _context.Classes.AsNoTracking().Select(x => new Class
            {
                Id = x.Id,
                Name = x.Name,
                StudentClasses = x.StudentClasses,
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task Create(Class c)
        {
            if (_context == null || _context.Classes == null)
            {
                throw new Exception("Context is null!");
            }
            _context.Classes.Add(c);
            await _context.SaveChangesAsync();
            if (c.StudentClasses?.Count > 0)
            {
                foreach (var item in c.StudentClasses)
                {
                    item.ClassId = c.Id;
                    _context.StudentClasses.Add(new StudentClass { ClassId = c.Id, StudentId = item.StudentId });
                }
                _context.Classes.Update(c);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Class c)
        {
            if (_context == null || _context.Classes == null)
            {
                throw new Exception("Class not found!");
            }
            var c1 = _context.Classes.Select(x => new Class
            {
                Id = x.Id,
                StudentClasses = x.StudentClasses,
            }).FirstOrDefault(s => s.Id == c.Id);
            c1.Name = c.Name;
            if (c1.StudentClasses.Count > 0)
            {
                var results = c.StudentClasses;
                List<bool> checks = new List<bool>(results.Count);
                checks.AddRange(Enumerable.Repeat(false, results.Count));
                var j = 0;
                foreach (var item in c1.StudentClasses)
                {
                    if (c.StudentClasses.Contains(item))
                    {
                        checks[j++] = true;
                        continue;
                    }
                    else
                    {
                        _context.StudentClasses.Remove(item);
                        
                    }
                }
                for (var i = 0; i < c.StudentClasses.Count; ++i)
                {
                    if (!checks[i])
                    {
                        var studentClass = new StudentClass { ClassId = c.Id, StudentId = c.StudentClasses[i].StudentId };
                        c1.StudentClasses.Add(studentClass);
                        _context.StudentClasses.Add(studentClass);
                    }
                }
                //_context.Classes.Update(c1);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var c = _context.Classes.Find(id);
            if (_context == null || _context.Classes == null)
            {
                throw new Exception("Class not found!");
            }
            if (c is null)
            {
                throw new Exception("Class not found!");
            }
            _context.Classes.Remove(c);
            await _context.SaveChangesAsync();
        }
    }
}
