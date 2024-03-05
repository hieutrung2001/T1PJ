using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.Repository.Services.Classes
{
    public interface IClassService
    {
        Task<List<Class>> GetAll();
        Task<Class> GetClassById(int id);
        Task<Class> Create(Class c);
        Task<Class> Update(Class c);
        Task Delete(int id);
    }
}
