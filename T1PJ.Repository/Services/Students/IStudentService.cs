using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using T1PJ.Domain.Entity;
using T1PJ.Domain.Model.Paginations;
using T1PJ.Domain.Model.Students;
using T1PJ.Domain.Model.Paginations;

namespace T1PJ.Core.Services.Students
{
    public interface IStudentService
    {
        Task<JsonData<IndexModel>> LoadTable(Pagination model);
        Task<List<Student>> GetAll();
        Task<List<Student>> GetStudentsOfClass(int classId);
        Task<Student> GetStudentById(int id);
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task Delete(int id);
    }
}
