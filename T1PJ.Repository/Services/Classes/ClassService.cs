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
                Students = x.Students,
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
                Students = x.Students,
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task Create(Class c)
        {
            if (_context == null || _context.Classes == null)
            {
                throw new Exception("Context is null!");
            }
            if (c.Students == null)
            {

            }
            try
            {
                _context.Classes.Add(c);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Class c)
        {
            if (_context == null || _context.Classes == null)
            {
                throw new Exception("Class not found!");
            }
            try
            {
                var c1 = _context.Classes.Find(c.Id);
                c1.Name = c.Name;
                c1.Students = c.Students;
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            var c = _context.Classes.FirstOrDefault(s => s.Id == id);
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
