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
            return await _context.Classes.Include(s => s.Students).OrderByDescending(c => c.Created).ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            if (_context == null || _context.Classes == null)
            {
                return null;
            }
            var result = await _context.Classes.Include(c => c.Students).FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<Class> Create(Class c)
        {
            if (_context == null || _context.Classes == null)
            {
                return null;
            }
            _context.Classes.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task<Class> Update(Class c)
        {
            if (_context == null || _context.Classes == null)
            {
                return null;
            }
            _context.Classes.Update(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public void Delete(int id)
        {
            if (_context == null || _context.Classes == null)
            {
                return;
            }
            if (_context.Classes.FirstOrDefault(s => s.Id == id) == null)
            {
                return;
            }
            var c = _context.Classes.FirstOrDefault(s => s.Id == id);
            _context.Classes.Remove(c);
            _context.SaveChangesAsync();

        }
    }
}
