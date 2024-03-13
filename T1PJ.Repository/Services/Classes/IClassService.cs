using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.Domain.Entity;
using T1PJ.Domain.Model.Classes;
using T1PJ.Domain.Model.Paginations;
using T1PJ.Domain.Model.Paginations;

namespace T1PJ.Core.Services.Classes
{
    public interface IClassService
    {
        Task<JsonData<IndexModel>> LoadTable(Pagination model);
        Task<List<Class>> GetAll();
        Task<Class> GetClassById(int id);
        Task Create(Class c);
        Task Update(Class c);
        Task Delete(int id);
    }
}
