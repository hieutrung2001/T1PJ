using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Paginations;
using T1PJ.Domain.Model.Students;

namespace T1PJ.Repository.Services.Students
{
    public interface IStudentService
    {
        Task<JsonData> LoadTable(Pagination model);
        Task<List<Student>> GetAll();
        Task<List<Student>> GetStudentsOfClass(int classId);
        Task<Student> GetStudentById(int id);
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task Delete(int id);
    }
}
